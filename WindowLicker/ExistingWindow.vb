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

Public Class ExistingWindow

    Public ProcessName As String = ""   ' Name of parent process
    Public WindowTitle As String = ""   ' The Title of the Main Window
    Public WindowClass As String = ""
    Public hWnd As IntPtr               ' The handle of the Main Window

    Sub New(ByVal NewClassName As String, ByVal NewTitle As String, ByVal NewhWnd As String)
        WindowClass = NewClassName
        WindowTitle = NewTitle
        hWnd = NewhWnd
    End Sub

End Class
