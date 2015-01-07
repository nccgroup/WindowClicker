<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLoopEvent
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.lblStart = New System.Windows.Forms.Label()
        Me.lblEnd = New System.Windows.Forms.Label()
        Me.lblStep = New System.Windows.Forms.Label()
        Me.udStart = New System.Windows.Forms.NumericUpDown()
        Me.udEnd = New System.Windows.Forms.NumericUpDown()
        Me.udStep = New System.Windows.Forms.NumericUpDown()
        CType(Me.udStart, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.udEnd, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.udStep, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Location = New System.Drawing.Point(34, 103)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 0
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(119, 103)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'lblStart
        '
        Me.lblStart.AutoSize = True
        Me.lblStart.Location = New System.Drawing.Point(12, 13)
        Me.lblStart.Name = "lblStart"
        Me.lblStart.Size = New System.Drawing.Size(62, 13)
        Me.lblStart.TabIndex = 2
        Me.lblStart.Text = "Start Value:"
        '
        'lblEnd
        '
        Me.lblEnd.AutoSize = True
        Me.lblEnd.Location = New System.Drawing.Point(12, 39)
        Me.lblEnd.Name = "lblEnd"
        Me.lblEnd.Size = New System.Drawing.Size(59, 13)
        Me.lblEnd.TabIndex = 3
        Me.lblEnd.Text = "End Value:"
        '
        'lblStep
        '
        Me.lblStep.AutoSize = True
        Me.lblStep.Location = New System.Drawing.Point(12, 68)
        Me.lblStep.Name = "lblStep"
        Me.lblStep.Size = New System.Drawing.Size(32, 13)
        Me.lblStep.TabIndex = 4
        Me.lblStep.Text = "Step:"
        '
        'udStart
        '
        Me.udStart.Location = New System.Drawing.Point(95, 13)
        Me.udStart.Maximum = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.udStart.Minimum = New Decimal(New Integer() {999999, 0, 0, -2147483648})
        Me.udStart.Name = "udStart"
        Me.udStart.Size = New System.Drawing.Size(87, 20)
        Me.udStart.TabIndex = 5
        '
        'udEnd
        '
        Me.udEnd.Location = New System.Drawing.Point(95, 39)
        Me.udEnd.Maximum = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.udEnd.Minimum = New Decimal(New Integer() {999999, 0, 0, -2147483648})
        Me.udEnd.Name = "udEnd"
        Me.udEnd.Size = New System.Drawing.Size(87, 20)
        Me.udEnd.TabIndex = 6
        Me.udEnd.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'udStep
        '
        Me.udStep.Location = New System.Drawing.Point(95, 66)
        Me.udStep.Maximum = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.udStep.Minimum = New Decimal(New Integer() {999999, 0, 0, -2147483648})
        Me.udStep.Name = "udStep"
        Me.udStep.Size = New System.Drawing.Size(87, 20)
        Me.udStep.TabIndex = 7
        Me.udStep.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'frmLoopEvent
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(206, 135)
        Me.Controls.Add(Me.udStep)
        Me.Controls.Add(Me.udEnd)
        Me.Controls.Add(Me.udStart)
        Me.Controls.Add(Me.lblStep)
        Me.Controls.Add(Me.lblEnd)
        Me.Controls.Add(Me.lblStart)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLoopEvent"
        Me.Text = "Loop Event"
        CType(Me.udStart, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.udEnd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.udStep, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents lblStart As System.Windows.Forms.Label
    Friend WithEvents lblEnd As System.Windows.Forms.Label
    Friend WithEvents lblStep As System.Windows.Forms.Label
    Friend WithEvents udStart As System.Windows.Forms.NumericUpDown
    Friend WithEvents udEnd As System.Windows.Forms.NumericUpDown
    Friend WithEvents udStep As System.Windows.Forms.NumericUpDown
End Class
