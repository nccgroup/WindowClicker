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

Public Class frmLoopEvent

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs) Handles btnOK.Click
        ' If we have valid values then create a new event in main form
        '=============================================================

        If udStep.Value = 0 Then
            ' Invalid step size
            MsgBox("Invalid step size: Choose a non-zero value!", MsgBoxStyle.OkOnly, "Error")
        ElseIf (udStart.Value > udEnd.Value And udStep.Value > -1) Or (udStart.Value < udEnd.Value And udStep.Value < 1) Then
            ' Invalid values for a functioning loop
            MsgBox("Invalid values: Insert valid values to allow the loop to execute!", MsgBoxStyle.OkOnly, "Error")
        Else
            ' Valid settings
            frmMain.NewLoopData.StartVal = udStart.Value
            frmMain.NewLoopData.EndVal = udEnd.Value
            frmMain.NewLoopData.StepVal = udStep.Value

            frmMain.blnIsLoop = True

            Me.Close()
        End If

    End Sub

End Class