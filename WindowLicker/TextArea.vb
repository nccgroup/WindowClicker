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

Public Class TextArea

    Public ID As Integer = 0            ' This will uniquely identify each text image/area
    Public ScreenArea As Rectangle      ' Screen area which holds text
    Public SelectedImage As Image       ' Image of screen area holding the text
    Public ClippedText As String = ""   ' Text identified by OCR component
    Public ImageFile As String = ""    ' Filename associated with image/area

    Public Sub New(IDNum As Integer, SelectedArea As Rectangle, CurrentImage As Image, Optional TextContent As String = "", Optional Filename As String = "")

        ID = IDNum
        ScreenArea = SelectedArea
        SelectedImage = CurrentImage
        ClippedText = TextContent
        ImageFile = Filename

    End Sub

End Class
