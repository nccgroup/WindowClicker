' WindowClicker - GUI Automater
' Copyright (C) 2014 Nick Dunn
'
' This program is free software: you can redistribute it and/or modify
' it under the terms of the GNU General Public License as published by
' the Free Software Foundation, either version 3 of the License, or
' (at your option) any later version.
'
' This program is distributed in the hope that it will be useful,
' but WITHOUT ANY WARRANTY; without even the implied warranty of
' MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
' GNU General Public License for more details.
'
' You should have received a copy of the GNU General Public License
' along with this program.  If not, see <http://www.gnu.org/licenses/>.

Option Explicit On

Imports System.Runtime.InteropServices
Imports System.Text

Module modMain

    '== Dictionary of events to use for fuzzing ==
    Public GuiEvents As New Dictionary(Of String, GuiEvent)
    Public EventIndex As Integer = 1
    Public CopiedEvents As New Dictionary(Of String, Integer)

    Public blnIsEventsSaved As Boolean = False
    Public blnIsLogSaved As Boolean = False


    '== Class used to carry out OCR ==
    Public trTextReader As TextReader


    '== GUI Monitoring ==
    Public MonitorInterval As Integer = 10
    Public IsGuiMonitor As Boolean = False
    Public TerminateOnFirstChange As Boolean = True
    Public TerminateOnAllChange As Boolean = False

    Public ExistingWindows As New Dictionary(Of IntPtr, ExistingWindow)     ' Currently open windows
    Public ExistingControls As New Dictionary(Of IntPtr, ExistingControl)   ' All controls for all windows
    Public ExistingControlGroups As New Dictionary(Of IntPtr, ArrayList)    ' The keys for the controls, grouped by parent window

    Public MonitoredWindows As New Dictionary(Of IntPtr, MonitoredWindow)   ' These windows and controls will be monitored for changes to their text
    Public NewWindows As New Dictionary(Of String, NewWindow)               ' There will be an alert if these windows are created

    Public ChangedWindows As New Dictionary(Of IntPtr, MonitoredWindow)     ' This dictionary will be used to record changes to window titles in the event that we terminate when all changes have happened
    Public CreatedWindows As New Dictionary(Of String, NewWindow)           ' This dictionary will be used to record newly created windows in the event that we terminate when all changes have happened

    Private CurrentWindows As New System.Collections.ObjectModel.Collection(Of IntPtr)

    '== Notify user of invalid path? 1=on, 0=off ==
    Public OCRReminder As String = "1"


    '== Use Windows API to monitor the GUI state ==
    Public Declare Function FindWindow Lib "user32.dll" Alias "FindWindowA" (ByVal lpClassName As String, ByVal lpWindowName As String) As IntPtr
    Private Declare Auto Function FindWindowEx Lib "user32.dll" (ByVal hwndParent As IntPtr, ByVal hwndChildAfter As IntPtr, ByVal lpszClass As String, ByVal lpszWindow As String) As IntPtr
    Private Declare Function EnumWindows Lib "User32.dll" (ByVal WNDENUMPROC As EnumWindowDelegate, ByVal lparam As IntPtr) As Boolean
    Private Declare Function GetDesktopWindow Lib "user32" () As Long

    Private Declare Function GetWindowText Lib "user32" Alias "GetWindowTextA" (ByVal hwnd As Long, ByVal lpString As String, ByVal cch As Long) As Long
    Private Declare Function GetClassName Lib "user32" Alias "GetClassNameA" (ByVal hwnd As Integer, ByVal lpClassName As StringBuilder, ByVal nMaxCount As Integer) As Integer
    Private Declare Function IsWindowVisible Lib "user32.dll" (ByVal hwnd As IntPtr) As Boolean

    Private Declare Function SendMessageTimeoutString Lib "user32" Alias "SendMessageTimeoutA" (ByVal hwnd As Long, ByVal msg As Long, ByVal wParam As Long, ByVal lParam As String, ByVal fuFlags As Long, ByVal uTimeout As Long, lpdwResult As Long) As Long
    Private Declare Function GetWindowTextLength Lib "user32.dll" Alias "GetWindowTextLengthA" (ByVal hwnd As IntPtr) As Long

    Private Delegate Function EnumWindowProcess(ByVal Handle As IntPtr, ByVal Parameter As IntPtr) As Boolean
    Private Delegate Function EnumWindowDelegate(ByVal hWnd As IntPtr, ByVal Lparam As IntPtr) As Boolean

    '== Get window/control text length ==
    Private Declare Function SendMessage Lib "user32" Alias "SendMessageA" (ByVal hwnd As Int32, ByVal wMsg As Int32, ByVal wParam As Int32, ByVal lParam As Int32) As Int32
    '== Get window/control text ==
    Private Declare Function SendMessage Lib "user32" Alias "SendMessageA" (ByVal hwnd As Int32, ByVal wMsg As Int32, ByVal wParam As Int32, ByVal lParam As StringBuilder) As Int32

    <DllImport("User32.dll")> Private Function EnumChildWindows _
        (ByVal WindowHandle As IntPtr, ByVal Callback As EnumWindowProcess, ByVal lParam As IntPtr) As Boolean
    End Function

    Private Structure ControlDetails
        ' Placeholder for details returned from a control
        '================================================

        Public ControlTitle As String
        Public ClassName As String
        Public hWnd As Int32

    End Structure

    Public Sub EnumerateWindows()
        ' Obtain list of current visible windows on the DeskTop
        '======================================================

        Call EnumWindows(AddressOf EnumVisibleWindows, 0&)

    End Sub

    Public Function EnumVisibleWindows(ByVal hWnd As Long, ByVal lParam As Long) As Long
        ' Identify each visible window and add to dictionary
        '===================================================
        Dim ewExistingWindow As ExistingWindow
        Dim cdControl As ControlDetails
        Dim strTitle As String = ""
        Dim lngTextLength As Long = 0
        Dim lngRetVal As Long = 0


        '== Is window visible? ==
        If IsWindowVisible(hwnd) = True Then

            '== Get details for each control ==
            cdControl = GetWindowIdentification(hwnd)
            'lngTextLength = GetWindowTextLength(hwnd)
            'strTitle = Space(lngTextLength + 1)
            'GetWindowText(hwnd, strTitle, Len(strTitle))

            If cdControl.ControlTitle <> "" Then
                '== Add details to the control for the dictionary == 
                ewExistingWindow = New ExistingWindow("", cdControl.ControlTitle, hwnd)

                '== Add the control to the controls dictionary ==
                If ExistingWindows.ContainsKey(hwnd) Then
                    ExistingWindows.Item(hwnd) = ewExistingWindow
                Else
                    ExistingWindows.Add(hwnd, ewExistingWindow)
                End If
            End If
        End If

        '== A return value of true is necessary in order to continue enumeration ==
        EnumVisibleWindows = True

    End Function

    Public Function GetTextForHandle(ByVal hWnd As Long) As String
        ' Return the window title for a given window handle
        '==================================================
        Dim cdControl As ControlDetails
        Dim strRetVal As String = ""


        '== Is window visible? ==
        If IsWindowVisible(hWnd) = True Then

            '== Get details for specified window ==
            cdControl = GetWindowIdentification(hWnd)
            strRetVal = cdControl.ControlTitle
        End If

        Return strRetVal

    End Function

    Private Function GetControlText(ByVal hWnd As IntPtr) As String
        ' Obtain the current text of a control
        '=====================================
        Dim strCurrentText As String = Space(255)
        Dim strRetVal As String = ""


        Try
            If SendMessageTimeoutString(hWnd, &HD, 255, strCurrentText, &H2, 1000, 0) <> 0 Then
                strRetVal = Left(strCurrentText, InStr(strCurrentText, vbNullChar) - 1)
            End If
        Catch ex As Exception
            MsgBox("Error getting text value from control " & CStr(hWnd) & "!", MsgBoxStyle.Critical, "Error")
        End Try

        Return strRetVal

    End Function

    Public Sub EnumerateProcesses()
        ' Obtain a list of all current processes and any associated windows
        '==================================================================
        Dim ewExistingWindow As ExistingWindow
        Dim hWnd As IntPtr


        ExistingWindows.Clear()

        '== Enumerate current processes ==
        For Each prcProcess As Process In Process.GetProcesses

            '== Check that the process has an associated Window title and is NOT this app ==
            If (prcProcess.MainWindowTitle <> String.Empty) And (prcProcess.MainWindowTitle <> "WindowClicker") Then

                '== Add the new details to the dictionary ==
                hWnd = FindWindow(vbNullString, prcProcess.MainWindowTitle)
                ewExistingWindow = New ExistingWindow(prcProcess.ProcessName, prcProcess.MainWindowTitle, hWnd)
                ExistingWindows.Add(CStr(hWnd), ewExistingWindow)
            End If
        Next

    End Sub

    Public Sub EnumerateControls(ByVal ParentHwnd As IntPtr)
        ' Build a list of controls for the identified window
        '===================================================
        Dim arrHandles() As IntPtr
        Dim cdControl As ControlDetails
        Dim ecControl As ExistingControl
        Dim hWnd As IntPtr
        Dim sbClass As New StringBuilder(255)

        Dim strParentName As String = ""
        Dim strClass As String = ""
        Dim strName As String = ""


        '== Is the input parameter valid? ==
        If Not ExistingWindows.ContainsKey(ParentHwnd) Then Exit Sub

        '== Get child windows/controls for this handle ==
        arrHandles = GetChildWindows(ParentHwnd)

        '== Get name of parent window ==
        strParentName = ExistingWindows.Item(ParentHwnd).WindowTitle

        '== Associate controls with parent window using control groups dictionary ==
        If ExistingControlGroups.ContainsKey(ParentHwnd) Then
            '== Clear any previous list of controls for this window == 
            ExistingControlGroups.Item(ParentHwnd).Clear()
        Else
            '== Create new dictionary entry ==
            ExistingControlGroups.Add(ParentHwnd, New ArrayList)
        End If


        '== Iterate through child windows and obtain details ==
        For Each hWnd In arrHandles

            '== Get details for each control ==
            cdControl = GetWindowIdentification(hWnd)

            '== Get the class name for the control==
            GetClassName(hWnd, sbClass, 255)
            cdControl.ClassName = sbClass.ToString()

            '== Add details to the control for the dictionary ==
            ecControl = New ExistingControl(strParentName, ParentHwnd, hWnd, cdControl.ClassName, "", cdControl.ControlTitle)

            '== Add the control to the controls dictionary ==
            If ExistingControls.ContainsKey(hWnd) Then
                ExistingControls.Item(hWnd) = ecControl
            Else
                ExistingControls.Add(hWnd, ecControl)
            End If

            '== Add to list of controls for this window ==
            ExistingControlGroups.Item(ParentHwnd).Add(hWnd)
        Next

    End Sub

    Private Function GetChildWindows(ByVal ParentHandle As IntPtr) As IntPtr()
        ' Iterate through child windows of the provided handle and return array of handles
        '=================================================================================
        Dim lstChildWindows As New List(Of IntPtr)
        Dim hWnd As GCHandle
        Dim arrRetval As IntPtr()


        '== Get window handle ==
        hWnd = GCHandle.Alloc(lstChildWindows)

        Try
            '== Get controls for current window ==
            EnumChildWindows(ParentHandle, AddressOf EnumWindow, GCHandle.ToIntPtr(hWnd))
        Finally
            '== Clean up afterwards ==
            If hWnd.IsAllocated Then hWnd.Free()
        End Try

        '== Convert List back to Array in order to return appropriate value ==
        arrRetval = lstChildWindows.ToArray

        Return arrRetval

    End Function

    Private Function EnumWindow(ByVal hWnd As IntPtr, ByVal InputHandle As IntPtr) As Boolean
        ' Build up list of child windows/controls for current window handle
        '==================================================================
        Dim lstChildWindows As List(Of IntPtr)


        '== Get list for current window ==
        lstChildWindows = GCHandle.FromIntPtr(InputHandle).Target

        If lstChildWindows Is Nothing Then
            Throw New Exception("Failed to obtain List of Window Handles for current pointer.")
        Else
            '== Add the next control/child window ==
            lstChildWindows.Add(hWnd)
        End If

        Return True

    End Function

    Private Function GetWindowIdentification(ByVal hWnd As Integer) As ControlDetails
        ' Obtain text for current window
        '===============================
        Const WM_GETTEXT As Int32 = &HD
        Const WM_GETTEXTLENGTH As Int32 = &HE

        Dim intStrLen As Int32
        Dim cdControl As New ControlDetails()
        Dim sbWindowTitle As New StringBuilder()


        '== Get size of string required to hold window text ==
        intStrLen = SendMessage(hWnd, WM_GETTEXTLENGTH, 0, 0)

        '== Check that window text is *not* length zero ==
        If intStrLen > 0 Then
            sbWindowTitle = New StringBuilder(intStrLen + 1)
            SendMessage(hwnd, WM_GETTEXT, sbWindowTitle.Capacity, sbWindowTitle)
        End If

        '== Assign control properties ==
        '== We proceed even if string length is less than one as blank window text is feasible ==
        cdControl.ControlTitle = sbWindowTitle.ToString()
        cdControl.hWnd = hwnd

        Return cdControl

    End Function

End Module
