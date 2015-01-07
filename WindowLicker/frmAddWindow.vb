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

Public Class frmAddWindow

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Me.Dispose()
    End Sub

    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs) Handles btnOK.Click
        ' Check if window title is in dictionary
        ' If new window then add the new details to the dictionary
        ' If already in dictionary then modify the existing entry
        '========================================================
        Dim strTitle As String
        Dim nwNewWindow As NewWindow


        strTitle = txtWindow.Text.Trim

        If strTitle = "" Then
            MsgBox("Please provide a window title!", MsgBoxStyle.Exclamation, "Error")
            Exit Sub
        Else

            If NewWindows.ContainsKey(strTitle) Then
                ' Modify existing item
                NewWindows.Item(strTitle).IsFullTitle = rbFull.Checked
            Else
                ' Add new item
                nwNewWindow = New NewWindow(strTitle, rbFull.Checked)
                NewWindows.Add(strTitle, nwNewWindow)
            End If
        End If


        '== Activate monitor if required ==
        IsGuiMonitor = ((NewWindows.Count > 0) Or (MonitoredWindows.Count > 0) Or (frmMain.SnipCount > 0))

        frmMain.timTimer.Enabled = IsGuiMonitor
        frmMain.ActivateGUIMonitorToolStripMenuItem.Checked = IsGuiMonitor

        Me.Dispose()

    End Sub

End Class