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
Imports System.Reflection
Imports System.Windows.Forms


Public Class MouseData

    '== Button click events ==
    Public Event LeftButtonClick(ByVal sender As Object, ByVal e As MouseEventArgs)
    Public Event RightButtonClick(ByVal sender As Object, ByVal e As MouseEventArgs)

    '== Hooking delegate function ==
    Private Delegate Function MouseHookCallBack(ByVal nCode As Integer, ByVal wParam As Integer, ByVal lParam As IntPtr) As Integer

    Private mhcCallBackDelegate As MouseHookCallBack
    Private intMouseHookID As Integer

    Private Enum MouseMessages
        '== Mouse event enum ==
        WM_LEFT_BTN_DOWN = 513
        WM_LEFT_BTN_UP = 514
        WM_LEFT_DBLCLICK = 515
        WM_RIGHT_BTN_DOWN = 516
        WM_RIGHT_BTN_UP = 517
        WM_RIGHT_DBLCLICK = 518
    End Enum

    <StructLayout(LayoutKind.Sequential)> Private Structure ScreenPoint
        '== Mouse co-ordinates ==
        Public x As Integer
        Public y As Integer
    End Structure

    <StructLayout(LayoutKind.Sequential)> Private Structure MouseHookStruct
        '== Mouse data used for hooking ==
        Public pt As ScreenPoint
        Public hwnd As Integer
        Public wHitTestCode As Integer
        Public dwExtraInfo As Integer
    End Structure

    '== Hook into Windows DLL for mouse events==
    <DllImport("user32.dll", CharSet:=CharSet.Auto, CallingConvention:=CallingConvention.StdCall)> Private Shared Function CallNextHookEx( _
            ByVal idHook As Integer, _
            ByVal nCode As Integer, _
            ByVal wParam As IntPtr, _
            ByVal lParam As IntPtr) As Integer
    End Function

    <DllImport("User32.dll", CharSet:=CharSet.Auto, CallingConvention:=CallingConvention.StdCall, SetLastError:=True)> Private Shared Function SetWindowsHookEx _
            (ByVal idHook As Integer, ByVal HookProc As MouseHookCallBack, ByVal hInstance As IntPtr, ByVal wParam As Integer) As Integer
    End Function

    <DllImport("user32.dll", CharSet:=CharSet.Auto, CallingConvention:=CallingConvention.StdCall, SetLastError:=True)> _
    Private Shared Function UnhookWindowsHookEx(ByVal idHook As Integer) As Integer
    End Function

    Public Sub New()
        ' Class constructor for MouseData
        '================================

        If intMouseHookID = 0 Then
            '== Get Windows Hook to monmitor mouse events ==
            mhcCallBackDelegate = AddressOf MouseHookProc
            intMouseHookID = SetWindowsHookEx(CInt(14), mhcCallBackDelegate, Marshal.GetHINSTANCE(Assembly.GetExecutingAssembly.GetModules()(0)), 0)

            '== Check for success/failure ==
            If intMouseHookID = 0 Then
                MsgBox("Failed to create hook into user32.dll!", MsgBoxStyle.Critical, "Error")
            End If
        End If

    End Sub

    Public Sub Dispose()
        ' Class destructor - clean up all data, hooks, etc.
        '==================================================

        If Not intMouseHookID = -1 Then
            UnhookWindowsHookEx(intMouseHookID)
            mhcCallBackDelegate = Nothing
        End If

        '== Mark as closed ==
        intMouseHookID = -1

    End Sub

    Private Function MouseHookProc(ByVal nCode As Integer, ByVal wParam As Integer, ByVal lParam As IntPtr) As Integer
        ' Monitor Windows events and raise an event in any case where it's an event we're looking for
        '============================================================================================
        Dim mhsMouseData As MouseHookStruct

        '== Do we have a valid event? ==
        If nCode >= 0 Then

            '== Obtain mouse data from system ==
            mhsMouseData = Marshal.PtrToStructure(lParam, GetType(MouseHookStruct))

            '== Check for mouse events ==
            Select Case wParam
                Case MouseMessages.WM_LEFT_BTN_UP
                    '== Left click ==
                    RaiseEvent LeftButtonClick(Nothing, New MouseEventArgs(MouseButtons.Left, 1, mhsMouseData.pt.x, mhsMouseData.pt.y, 0))
                Case MouseMessages.WM_RIGHT_BTN_UP
                    '== Right click ==
                    RaiseEvent RightButtonClick(Nothing, New MouseEventArgs(MouseButtons.Right, 1, mhsMouseData.pt.x, mhsMouseData.pt.y, 0))
            End Select
        End If

        Return CallNextHookEx(intMouseHookID, nCode, wParam, lParam)

    End Function

End Class
