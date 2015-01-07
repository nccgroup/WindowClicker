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

Public Class NewWindow
    ' Details used to monitor for any new windows which appear
    '=========================================================

    Public WindowTitle As String = ""
    Public IsCaseSensitive As Boolean = False
    Public IsFullTitle As Boolean = True

    Sub New(ByVal NewTitle As String, ByVal MatchFullTitle As Boolean)
        WindowTitle = NewTitle
        IsCaseSensitive = False     ' No way to check case-sensitively in current API
        IsFullTitle = MatchFullTitle
    End Sub

End Class
