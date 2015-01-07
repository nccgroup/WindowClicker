Public Class frmReminder

    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs) Handles btnOK.Click
        ' Write user choice to registry
        '==============================

        If chkNotAgain.Checked Then
            OCRReminder = "0"
            SaveSetting("WindowClicker", "Settings", "OCRReminder", OCRReminder)
        End If

        Me.Hide()

    End Sub

End Class