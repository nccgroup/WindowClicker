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


Public Class MouseController

    Private Declare Auto Function GetDesktopWindow Lib "user32.dll" () As IntPtr

    '== Enum for mouse buttons ==
    Private Const LEFT_BUTTON As Integer = 0
    Private Const MIDDLE_BUTTON As Integer = 1
    Private Const RIGHT_BUTTON As Integer = 2

    '== Mouse events ==
    Private Const LEFT_MOUSE_DOWN As Integer = &H2
    Private Const LEFT_MOUSE_UP As Integer = &H4
    Private Const MIDDLE_MOUSE_DOWN = &H20
    Private Const MIDDLE_MOUSE_UP = &H40
    Private Const RIGHT_MOUSE_DOWN = &H8
    Private Const RIGHT_MOUSE_UP = &H10

    '== Set offset for input according to host system ==
    Private Const OFFSET_32_BIT = 4
    Private Const OFFSET_64_BIT = 8

    Private intCurrentSystem As Integer = OFFSET_64_BIT

    <StructLayout(LayoutKind.Explicit)> Private Structure INPUT_64
        <FieldOffset(0)> Public type As Integer
        <FieldOffset(OFFSET_64_BIT)> Public mi As MOUSEINPUT
        <FieldOffset(OFFSET_64_BIT)> Public ki As KEYBDINPUT
        <FieldOffset(OFFSET_64_BIT)> Public hi As HARDWAREINPUT
    End Structure

    <StructLayout(LayoutKind.Explicit)> Private Structure INPUT_32
        <FieldOffset(0)> Public type As Integer
        <FieldOffset(OFFSET_32_BIT)> Public mi As MOUSEINPUT
        <FieldOffset(OFFSET_32_BIT)> Public ki As KEYBDINPUT
        <FieldOffset(OFFSET_32_BIT)> Public hi As HARDWAREINPUT
    End Structure

    Private Structure MOUSEINPUT
        Public dx As Integer
        Public dy As Integer
        Public mouseData As Integer
        Public dwFlags As Integer
        Public time As Integer
        Public dwExtraInfo As IntPtr
    End Structure

    Private Structure KEYBDINPUT
        Public wVk As Short
        Public wScan As Short
        Public dwFlags As Integer
        Public time As Integer
        Public dwExtraInfo As IntPtr
    End Structure

    Private Structure HARDWAREINPUT
        Public uMsg As Integer
        Public wParamL As Short
        Public wParamH As Short
    End Structure

    <DllImport("user32.dll")> Private Shared Function SendInput(ByVal nInputs As Integer, ByVal pInputs() As INPUT_32, ByVal cbSize As Integer) As Integer
    End Function

    <System.Runtime.InteropServices.DllImport("user32.dll")> Public Shared Function FindWindow(ByVal lpClassName As String, ByVal lpWindowName As String) As IntPtr
    End Function

    <System.Runtime.InteropServices.DllImport("user32.dll")> Public Shared Function ShowWindow(ByVal hWnd As IntPtr, ByVal nCmdShow As Integer) As Boolean
    End Function

    <System.Runtime.InteropServices.DllImport("user32.dll")> Public Shared Function GetWindowThreadProcessId(ByVal hWnd As IntPtr, ByVal lpwdProcessId As IntPtr) As IntPtr
    End Function

    Public Sub LeftClick(ByVal ParentForm As Form, ByVal X As Integer, ByVal Y As Integer)
        ' Send a left-click event to the system using user-supplied data
        '===============================================================

        MouseClick(ParentForm, X, Y)

    End Sub

    Public Sub MiddleClick(ByVal ParentForm As Form, ByVal X As Integer, ByVal Y As Integer)
        ' Send a middle-click event to the system using user-supplied data
        '=================================================================

        MouseClick(ParentForm, X, Y, MIDDLE_BUTTON)

    End Sub

    Public Sub RightClick(ByVal ParentForm As Form, ByVal X As Integer, ByVal Y As Integer)
        ' Send a right-click event to the system using user-supplied data
        '================================================================

        MouseClick(ParentForm, X, Y, RIGHT_BUTTON)

    End Sub

    Private Sub MouseClick(ByVal ParentForm As Form, ByVal X As Integer, ByVal Y As Integer, Optional ByVal MouseButton As Integer = LEFT_BUTTON)
        ' Send a click event to the system using user-supplied data
        '==========================================================
        Dim ptScreenPoint As Point = ParentForm.PointToScreen(Point.Empty)
        Dim iptInputDetails(1) As INPUT_32


        '== Set screen Co-ordinates ==
        ptScreenPoint.X = X
        ptScreenPoint.Y = Y

        '== Move the cursor to the co-ordinate and send the click event ==
        Cursor.Position = ptScreenPoint

        '== Mouse-down event ==
        iptInputDetails(0).type = 0
        iptInputDetails(0).mi.dx = ptScreenPoint.X
        iptInputDetails(0).mi.dy = ptScreenPoint.Y

        Select Case MouseButton
            Case MIDDLE_BUTTON
                iptInputDetails(0).mi.dwFlags = MIDDLE_MOUSE_DOWN
            Case RIGHT_BUTTON
                iptInputDetails(0).mi.dwFlags = RIGHT_MOUSE_DOWN
            Case Else
                iptInputDetails(0).mi.dwFlags = LEFT_MOUSE_DOWN
        End Select


        '== Mouse-up event ==
        iptInputDetails(1).type = 0
        iptInputDetails(1).mi.dx = ptScreenPoint.X
        iptInputDetails(1).mi.dy = ptScreenPoint.Y

        Select Case MouseButton
            Case MIDDLE_BUTTON
                iptInputDetails(1).mi.dwFlags = MIDDLE_MOUSE_UP
            Case RIGHT_BUTTON
                iptInputDetails(1).mi.dwFlags = RIGHT_MOUSE_UP
            Case Else
                iptInputDetails(1).mi.dwFlags = LEFT_MOUSE_UP
        End Select


        '== Send events ==
        SendInput(2, iptInputDetails, Marshal.SizeOf(GetType(INPUT_32)))

    End Sub

End Class
