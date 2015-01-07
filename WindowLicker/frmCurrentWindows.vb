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

Public Class frmCurrentWindows

    '===============================================================
    '== Temporary placeholder for anything that will be monitored ==
    '== On clicking OK this list will replace the original list   ==
    '---------------------------------------------------------------
    Private dicWindows As New Dictionary(Of IntPtr, MonitoredWindow)


    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Me.Dispose()
    End Sub

    Private Sub frmCurrentWindows_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        ' Popultate controls with current windows
        '========================================

        '== Get current visible windows and add to treeview ==
        RefreshTree()

        '== Mark any windows that are currently being monitored ==
        MarkMonitoredWindows()

    End Sub

    Private Sub MarkMonitoredWindows()
        ' Mark any windows that are currently being monitored in the ListView
        '====================================================================

        If lvWindows.Items.Count < 1 Then Exit Sub

        For Each itmItem As IntPtr In MonitoredWindows.Keys
            If lvWindows.Items.ContainsKey(itmItem.ToString) Then
                lvWindows.Items(itmItem.ToString).Checked = True
            End If
        Next

    End Sub

    Private Sub frmCurrentWindows_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        ' Reposition the OK and Cancel buttons when form is resized
        '==========================================================
        On Error Resume Next

        'If Me.Width < 200 Then Me.Width = 200

        btnCancel.Left = Me.Width - 96
        btnOK.Left = btnCancel.Left - 80

    End Sub

    Private Sub tvWindows_AfterSelect(sender As System.Object, e As System.Windows.Forms.TreeViewEventArgs) Handles tvWindows.AfterSelect
        ' Show windows or controls as appropriate
        '========================================

        If tvWindows.Nodes("0").IsSelected = True Then
            ShowWindows()
        Else
            ShowControls()
        End If

    End Sub

    Private Sub ShowWindows()
        ' Show windows for the desktop
        '=============================
        Dim lviItem As ListViewItem


        lvWindows.Items.Clear()
        For Each ewWindow As ExistingWindow In ExistingWindows.Values

            lviItem = New ListViewItem
            lviItem.Name = ewWindow.hWnd.ToString
            lviItem.Text = ewWindow.hWnd.ToString
            lviItem.SubItems.Add(ewWindow.ProcessName)
            lviItem.SubItems.Add(ewWindow.WindowTitle)
            lvWindows.Items.Add(lviItem)
        Next

        MarkMonitoredWindows()

    End Sub

    Private Sub ShowControls()
        ' Show controls for this Window
        '==============================
        Dim ecExistingControl As ExistingControl
        Dim lviItem As ListViewItem
        Dim hWnd As IntPtr


        '== Get handle for the window ==
        hWnd = FindWindow(vbNullString, tvWindows.SelectedNode.Text)

        '== Refresh list of controls for this window title ==
        EnumerateControls(hWnd)

        '== Clear the listview ==
        lvWindows.Items.Clear()


        '== Check that a valid list exists ==
        If Not ExistingControlGroups.ContainsKey(hWnd) Then Exit Sub

        '== Populate with new items ==
        For Each ptrHandle As IntPtr In ExistingControlGroups.Item(hWnd)

            ecExistingControl = ExistingControls.Item(ptrHandle)

            lviItem = New ListViewItem
            lviItem.Name = ptrHandle.ToString
            lviItem.Text = ptrHandle.ToString
            lviItem.SubItems.Add(ecExistingControl.ControlClass)
            lviItem.SubItems.Add(ecExistingControl.ControlName)
            lviItem.SubItems.Add(ecExistingControl.ControlText)
            lvWindows.Items.Add(lviItem)
        Next

        MarkMonitoredWindows()

    End Sub

    Private Sub btnRefresh_Click(sender As System.Object, e As System.EventArgs) Handles btnRefresh.Click
        ' Clear the treeview
        ' Get current visible windows and add to treeview
        '================================================

        RefreshTree()

    End Sub

    Private Sub RefreshTree()
        ' Populate dictionary with current, visible windows and add to treeview
        '======================================================================

        '== Clear any previous windows from the dictionary and GUI==
        ExistingWindows.Clear()
        tvWindows.Nodes.Clear()

        '== Add desktop node - all windows nodes to be children of desktop ==
        tvWindows.Nodes.Add("0", "DeskTop", 0)

        '== Get current windows and populate the treeview ==
        EnumerateWindows()
        For Each itmItem As KeyValuePair(Of IntPtr, ExistingWindow) In ExistingWindows
            tvWindows.Nodes("0").Nodes.Add(itmItem.Key.ToString, itmItem.Value.WindowTitle, 1)
        Next

        '== Expand the tree if any windows are present ==
        If tvWindows.Nodes("0").Nodes.Count > 0 Then tvWindows.Nodes("0").Expand()

    End Sub

    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs) Handles btnOK.Click
        ' Modify the dictionary with any windows or controls which will be monitored, then exit
        '======================================================================================

        '== Copy new monitor lists across ==
        MonitoredWindows = New Dictionary(Of IntPtr, MonitoredWindow)(dicWindows)

        '== Activate monitor if required ==
        IsGuiMonitor = ((NewWindows.Count > 0) Or (MonitoredWindows.Count > 0) Or (frmMain.SnipCount > 0))

        frmMain.timTimer.Enabled = IsGuiMonitor
        frmMain.ActivateGUIMonitorToolStripMenuItem.Checked = IsGuiMonitor

        '== Close form ==
        Me.Dispose()

    End Sub

    Private Sub lvWindows_ItemCheck(sender As Object, e As System.Windows.Forms.ItemCheckEventArgs) Handles lvWindows.ItemCheck
        ' Add/remove the selected item to/from the dictionary as appropriate
        '===================================================================
        Dim mwWindow As MonitoredWindow


        '== Is item being checked or unchecked? ==
        If e.NewValue = CheckState.Checked Then

            '== Check if we have a window or a control ==
            If ExistingWindows.ContainsKey(lvWindows.Items(e.Index).Name) Then
                mwWindow = New MonitoredWindow(ExistingWindows.Item(lvWindows.Items(e.Index).Name).WindowTitle, lvWindows.Items(e.Index).Name)
            ElseIf ExistingControls.ContainsKey(lvWindows.Items(e.Index).Name) Then
                mwWindow = New MonitoredWindow(ExistingControls.Item(lvWindows.Items(e.Index).Name).ControlText, lvWindows.Items(e.Index).Name)
            Else
                '== This shouldn't happen ==
                Exit Sub
            End If

            '== Add to the dictionary of monitored windows ==
            If dicWindows.ContainsKey(lvWindows.Items(e.Index).Name) Then
                dicWindows.Item(lvWindows.Items(e.Index).Name) = mwWindow
            Else
                dicWindows.Add(lvWindows.Items(e.Index).Name, mwWindow)
            End If
        Else
            '== Remove from dictionary ==
            If dicWindows.ContainsKey(lvWindows.Items(e.Index).Name) Then
                dicWindows.Remove(lvWindows.Items(e.Index).Name)
            End If
        End If

    End Sub

End Class