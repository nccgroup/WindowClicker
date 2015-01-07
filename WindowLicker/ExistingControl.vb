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

Public Class ExistingControl

    Public ParentWindow As String = ""
    Public ParentHandle As IntPtr

    Public hWnd As IntPtr
    Public ControlClass As String = ""
    Public ControlName As String = ""
    Public ControlText As String = ""

    Sub New(ParentName As String, ParentHwnd As IntPtr, NewHwnd As IntPtr, NewClass As String, NewName As String, NewText As String)

        ParentWindow = ParentName
        ParentHandle = ParentHwnd

        hWnd = NewHwnd
        ControlClass = NewClass
        ControlName = NewName
        ControlText = NewText

    End Sub

End Class
