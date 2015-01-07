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

Public Class GuiEvent

    Public Const LEFT_CLICK = 0
    Public Const RIGHT_CLICK = 1
    Public Const DOUBLE_CLICK = 2
    Public Const PASTE_LOOP_NUMBER = 3
    Public Const PASTE_FILE_DATA = 4
    Public Const PASTE_STATIC_TEXT = 5
    Public Const MIDDLE_CLICK = 6
    Public Const KEY_DOWN = 7

    '== Mouse position ==
    Public X As Integer = 0
    Public Y As Integer = 0

    Public EventType As Integer = LEFT_CLICK

    '== How many times to repeat the event ==
    Public Repeat As Integer = 1

    '== Clear or append? ==
    Public SelectAll As Boolean = False
    Public DeselectAll As Boolean = False

    '== Event data ==
    Public StaticText As String = ""
    Public DataFile As String = ""
    Public LoopData As New LoopEvent

End Class
