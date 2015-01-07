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

Public Class frmTextFields
    ' Form to show currently monitored text fields, including add/delete functionality
    '=================================================================================


    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs) Handles btnOK.Click
        ' Close form
        '============

        '== Activate monitor if required ==
        IsGuiMonitor = ((NewWindows.Count > 0) Or (MonitoredWindows.Count > 0) Or (frmMain.SnipCount > 0))

        frmMain.timTimer.Enabled = IsGuiMonitor
        frmMain.ActivateGUIMonitorToolStripMenuItem.Checked = IsGuiMonitor

        Me.Dispose()

    End Sub

    Private Sub frmTextFields_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        ' Show the current list of monitored text areas
        '==============================================
        Dim lviItem As New ListViewItem

        '== Check that we have a valid OCR application ==


        trTextReader.Compare = False

        '== Populate listview ==
        For Each deItem As TextArea In frmMain.ScreenSnips.Values
            lviItem.Name = deItem.ID
            lviItem.Text = deItem.ID
            lviItem.SubItems.Add(deItem.ClippedText)
            lviItem.SubItems.Add(deItem.ScreenArea.Left.ToString & ", " & deItem.ScreenArea.Top.ToString)
        Next

    End Sub

    Private Sub btnAdd_Click(sender As System.Object, e As System.EventArgs) Handles btnAdd.Click
        ' Add a new screen area and OCR any text
        '=======================================
        Dim intOriginalCount As Integer
        Dim lviItem As New ListViewItem


        '== Get number of items prior to addition ==
        intOriginalCount = frmMain.SnipCount

        '== Get new text area ==
        frmMain.AddTextArea()

        '== Only proceed if there's something to add ==
        If frmMain.SnipCount > intOriginalCount Then

        End If

    End Sub

    Private Sub btnDelete_Click(sender As System.Object, e As System.EventArgs) Handles btnDelete.Click
        ' Delete selected area from list view and from list of snippets
        '==============================================================
        Dim intOriginalCount As Integer
        Dim intIndex As Integer = 1
        Dim blnEmptySlot As Boolean = False

        Dim taTextArea As TextArea = Nothing
        Dim rctRect As New Rectangle
        Dim imgNewImage As Image = Nothing


        '== Do not proceed if there's nothing to delete ==
        If lvTextFields.SelectedItems.Count = 0 Or frmMain.SnipCount < 1 Then Exit Sub


        '== Get number of items prior to deletion ==
        intOriginalCount = frmMain.SnipCount

        '== Delete items from dictionary and listview ==
        For Each lviItem As ListViewItem In lvTextFields.SelectedItems
            frmMain.ScreenSnips.Remove(lviItem.Name)
            lviItem.Remove()
        Next

        '== Loop through snip dictionary and update indices ==
        Do While intIndex <= intOriginalCount

            If blnEmptySlot And frmMain.ScreenSnips.ContainsKey(intIndex) Then

                '== If previously empty slot was encountered thenj this item must be moved ==
                blnEmptySlot = False

                '== Copy current item details to new item ==
                taTextArea.ScreenArea = frmMain.ScreenSnips.Item(intIndex).ScreenArea
                taTextArea.SelectedImage = frmMain.ScreenSnips.Item(intIndex).SelectedImage
                taTextArea.ClippedText = frmMain.ScreenSnips.Item(intIndex).ClippedText
                taTextArea.ImageFile = frmMain.ScreenSnips.Item(intIndex).ImageFile

                '== Update dictionary by moving item to previous vacant slot ==
                frmMain.ScreenSnips.Add(taTextArea.ID, taTextArea)
                frmMain.ScreenSnips.Remove(intIndex)

            ElseIf Not frmMain.ScreenSnips.ContainsKey(intIndex) Then
                '== Prepare new item ready to hold details from next non-vacant slot ==
                blnEmptySlot = True
                taTextArea = New TextArea(intIndex, rctRect, imgNewImage)
            End If
        Loop

        frmMain.SnipCount = frmMain.ScreenSnips.Count

    End Sub

End Class