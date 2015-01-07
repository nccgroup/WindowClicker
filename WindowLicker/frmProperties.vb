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

Public Class frmProperties

    Private Const TREE_VIEW As Integer = 1
    Private Const LIST_VIEW As Integer = 2

    '== Record whether name as changed for Dictionary entry ==
    Public strOriginalName As String = ""

    '== Record which item is to be changed ==
    Public intContext As Integer
    Public strKey As String

    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs) Handles btnOK.Click
        ' Save new settings and close form
        '=================================

        UpdateItem(txtName.Text)
        Me.Dispose()

    End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Me.Dispose()
    End Sub

    Private Sub frmProperties_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        ' Load data from dictionary
        '==========================
        Dim geEvent As New GuiEvent

        '== Form just loaded so name hasn't changed yet ==
        txtName.Text = strOriginalName

        '== Get data for this dictionary item ==
        geEvent = GuiEvents.Item(strOriginalName)
        With geEvent
            cboEventType.SelectedIndex = .EventType
            udRepeat.Value = .Repeat
            udX.Value = .X
            udY.Value = .Y
            chkSelectAll.Checked = .SelectAll
            chkDeselectAll.Checked = .DeselectAll

            'Item data
            txtStatic.Text = .StaticText
            txtFile.Text = .DataFile
            udStart.Value = .LoopData.StartVal
            udEnd.Value = .LoopData.EndVal
            udStep.Value = .LoopData.StepVal

            ' Show relevant data
            Select Case .EventType
                Case GuiEvent.PASTE_FILE_DATA
                    tcData.SelectedTab = tcData.TabPages(1)
                Case GuiEvent.PASTE_LOOP_NUMBER
                    tcData.SelectedTab = tcData.TabPages(2)
                Case Else
                    tcData.SelectedTab = tcData.TabPages(0)
            End Select

        End With

    End Sub

    Private Sub UpdateItem(ByVal ItemName As String)
        ' Save new settings to collection
        '================================
        Dim geEvent As New GuiEvent


        '== Set data for this item ==
        With geEvent
            .EventType = cboEventType.SelectedIndex
            .Repeat = udRepeat.Value
            .X = udX.Value
            .Y = udY.Value

            .SelectAll = chkSelectAll.Checked
            .DeselectAll = chkDeselectAll.Checked

            'Item data
            .StaticText = txtStatic.Text
            .DataFile = txtFile.Text
            .LoopData.StartVal = udStart.Value
            .LoopData.EndVal = udEnd.Value
            .LoopData.StepVal = udStep.Value
        End With

        '== Has the item's name changed? ==
        If strOriginalName <> ItemName Then
            GuiEvents.Add(ItemName, geEvent)

            '== Make any necessary amendments to the list of copied items ==
            If CopiedEvents.Keys.Contains(strOriginalName) = False Then
                GuiEvents.Remove(strOriginalName)
            Else
                CopiedEvents.Item(strOriginalName) -= 1
                If CopiedEvents.Item(strOriginalName) = 0 Then GuiEvents.Remove(strOriginalName)
            End If

            '== Reflect any changes in the GUI ==
            If intContext = TREE_VIEW Then
                frmMain.tvEvent.Nodes(strKey).Name = ItemName
            ElseIf intContext = LIST_VIEW Then
                frmMain.lvDetail.Items(strKey).Name = ItemName
            End If
        Else
            '== Modify the existing item ==
            GuiEvents.Item(strOriginalName) = geEvent
        End If

    End Sub

    Private Sub chkSelectAll_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkSelectAll.CheckedChanged
        ' Although both boxes can be unchecked, they cannot both be checked at once
        '==========================================================================

        If chkSelectAll.Checked Then chkDeselectAll.Checked = False

    End Sub

    Private Sub chkDeselectAll_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkDeselectAll.CheckedChanged
        ' Although both boxes can be unchecked, they cannot both be checked at once
        '==========================================================================

        If chkDeselectAll.Checked Then chkSelectAll.Checked = False

    End Sub

End Class