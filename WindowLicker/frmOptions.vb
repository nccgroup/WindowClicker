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

Public Class frmOptions

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Me.Dispose()
    End Sub

    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs) Handles btnOK.Click
        ' Save data and close form
        '=========================

        With frmMain
            .intPause = udPause.Value
            .intDefaultRepeat = udRepeat.Value

            .blnIsGlobalSelectAll = chkSelectAll.Checked
            .blnIsGlobalDeselectAll = chkDeselectAll.Checked

            ' GUI Monitor
            IsGuiMonitor = chkEnableGuiMon.Checked
            If chkTerminate.Checked Then
                TerminateOnFirstChange = cboConditions.SelectedIndex = 0
                TerminateOnAllChange = Not TerminateOnFirstChange
            Else
                TerminateOnFirstChange = False
                TerminateOnAllChange = False
            End If
            MonitorInterval = udGuiMonitor.Value

            ' Log settings
            .blnIsAutoSave = (cbSave.Checked And cboFile.Text.Trim <> "")
            .strLogFile = cboFile.Text

            ' OCR settings
            If cboTesseract.Text.Trim <> "" Then trTextReader.TesseractLocation = cboTesseract.Text.Trim
            If txtArgs.Text.Trim <> "" Then trTextReader.TesseractArgs = txtArgs.Text.Trim
            If cboScreenshot.Text.Trim <> "" Then trTextReader.ImageDirectory = cboScreenshot.Text.Trim
        End With

        Me.Dispose()

    End Sub

    Private Sub frmOptions_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        ' Load data from main form
        '=========================

        With frmMain
            ' Pause settings
            udPause.Value = .intPause
            udRepeat.Value = .intDefaultRepeat

            ' Select behaviour for text controls
            chkSelectAll.Checked = .blnIsGlobalSelectAll
            chkDeselectAll.Checked = .blnIsGlobalDeselectAll

            ' GUI Monitor
            chkEnableGuiMon.Checked = IsGuiMonitor
            chkTerminate.Checked = TerminateOnFirstChange Or TerminateOnAllChange
            If chkTerminate.Checked And TerminateOnFirstChange Then
                cboConditions.SelectedIndex = 0
            Else
                cboConditions.SelectedIndex = 1
            End If
            udGuiMonitor.Value = MonitorInterval

            ' Log settings
            cbSave.Checked = .blnIsAutoSave
            cboFile.Text = .strLogFile

            ' OCR settings
            cboTesseract.Text = trTextReader.TesseractLocation
            txtArgs.Text = trTextReader.TesseractArgs
            cboScreenshot.Text = trTextReader.ImageDirectory
        End With

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

    Private Sub btnBrowse_Click(sender As System.Object, e As System.EventArgs) Handles btnBrowse.Click
        ' Set log location using OpenFile dialog
        '=======================================



    End Sub

    Private Sub btnTesseract_Click(sender As System.Object, e As System.EventArgs) Handles btnTesseract.Click
        ' Set OCR location using OpenFile dialog
        '=======================================



    End Sub

    Private Sub btnScreenShot_Click(sender As System.Object, e As System.EventArgs) Handles btnScreenShot.Click
        ' Set screenshot location using OpenDir dialog
        '=============================================


    End Sub

End Class