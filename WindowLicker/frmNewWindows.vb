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

Public Class frmNewWindows

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs)
        Me.Dispose()
    End Sub

    Private Sub btnAdd_Click(sender As System.Object, e As System.EventArgs) Handles btnAdd.Click
        ' Get new window details from user, add to collection and and to listview
        '========================================================================

        ' Get details
        frmAddWindow.ShowDialog(Me)

        ' Clear listview
        lvNewWindow.Clear()

        ' Get new listing
        ShowNewWindowList()

    End Sub

    Private Sub btnDelete_Click(sender As System.Object, e As System.EventArgs) Handles btnDelete.Click
        ' Delete currently selected item(s)
        '==================================

        If lvNewWindow.SelectedItems.Count < 1 Then Exit Sub

        For Each lviItem As ListViewItem In lvNewWindow.SelectedItems
            NewWindows.Remove(lviItem.Name)
            lvNewWindow.Items.Remove(lviItem)
        Next

    End Sub

    Private Sub ShowNewWindowList()
        ' Show the current list of new windows that the will be tracked by the GUI monitor
        '=================================================================================
        Dim lviItem As ListViewItem


        For Each nwNewWindow As NewWindow In NewWindows.Values

            '== Create new listvieitem and add details ==
            lviItem = New ListViewItem
            lviItem.Name = nwNewWindow.WindowTitle
            lviItem.Text = nwNewWindow.WindowTitle
            lviItem.SubItems.Add(nwNewWindow.IsFullTitle)

            '== Add finished item to listview ==
            lvNewWindow.Items.Add(lviItem)
        Next

    End Sub

    Private Sub frmNewWindows_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        ShowNewWindowList()
    End Sub

    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs) Handles btnOK.Click
        ' Activate GUIMonitor if required and close form
        '===============================================

        '== Activate monitor if required ==
        IsGuiMonitor = ((NewWindows.Count > 0) Or (MonitoredWindows.Count > 0) Or (frmMain.SnipCount > 0))

        frmMain.timTimer.Enabled = IsGuiMonitor
        frmMain.ActivateGUIMonitorToolStripMenuItem.Checked = IsGuiMonitor

        Me.Dispose()

    End Sub

End Class