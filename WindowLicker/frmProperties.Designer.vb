<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProperties
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
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.lblName = New System.Windows.Forms.Label()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.lblEventType = New System.Windows.Forms.Label()
        Me.lblRepeat = New System.Windows.Forms.Label()
        Me.cboEventType = New System.Windows.Forms.ComboBox()
        Me.udRepeat = New System.Windows.Forms.NumericUpDown()
        Me.lblX = New System.Windows.Forms.Label()
        Me.lblY = New System.Windows.Forms.Label()
        Me.udX = New System.Windows.Forms.NumericUpDown()
        Me.udY = New System.Windows.Forms.NumericUpDown()
        Me.tcData = New System.Windows.Forms.TabControl()
        Me.tpStatic = New System.Windows.Forms.TabPage()
        Me.txtStatic = New System.Windows.Forms.TextBox()
        Me.tcFileContent = New System.Windows.Forms.TabPage()
        Me.txtFile = New System.Windows.Forms.TextBox()
        Me.tcLoop = New System.Windows.Forms.TabPage()
        Me.udStep = New System.Windows.Forms.NumericUpDown()
        Me.udEnd = New System.Windows.Forms.NumericUpDown()
        Me.udStart = New System.Windows.Forms.NumericUpDown()
        Me.lblStep = New System.Windows.Forms.Label()
        Me.lblEnd = New System.Windows.Forms.Label()
        Me.lblStart = New System.Windows.Forms.Label()
        Me.ofdOpenFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.chkSelectAll = New System.Windows.Forms.CheckBox()
        Me.chkDeselectAll = New System.Windows.Forms.CheckBox()
        CType(Me.udRepeat, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.udX, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.udY, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tcData.SuspendLayout()
        Me.tpStatic.SuspendLayout()
        Me.tcFileContent.SuspendLayout()
        Me.tcLoop.SuspendLayout()
        CType(Me.udStep, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.udEnd, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.udStart, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(353, 199)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 0
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(272, 199)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 1
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.Location = New System.Drawing.Point(4, 15)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(38, 13)
        Me.lblName.TabIndex = 2
        Me.lblName.Text = "Name:"
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(49, 13)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(379, 20)
        Me.txtName.TabIndex = 3
        '
        'lblEventType
        '
        Me.lblEventType.AutoSize = True
        Me.lblEventType.Location = New System.Drawing.Point(4, 43)
        Me.lblEventType.Name = "lblEventType"
        Me.lblEventType.Size = New System.Drawing.Size(65, 13)
        Me.lblEventType.TabIndex = 4
        Me.lblEventType.Text = "Event Type:"
        '
        'lblRepeat
        '
        Me.lblRepeat.AutoSize = True
        Me.lblRepeat.Location = New System.Drawing.Point(308, 42)
        Me.lblRepeat.Name = "lblRepeat"
        Me.lblRepeat.Size = New System.Drawing.Size(45, 13)
        Me.lblRepeat.TabIndex = 5
        Me.lblRepeat.Text = "Repeat:"
        '
        'cboEventType
        '
        Me.cboEventType.FormattingEnabled = True
        Me.cboEventType.Items.AddRange(New Object() {"LEFT_CLICK ", "RIGHT_CLICK", "DOUBLE_CLICK", "PASTE_LOOP_NUMBER", "PASTE_FILE_DATA", "PASTE_STATIC_TEXT"})
        Me.cboEventType.Location = New System.Drawing.Point(76, 40)
        Me.cboEventType.Name = "cboEventType"
        Me.cboEventType.Size = New System.Drawing.Size(206, 21)
        Me.cboEventType.TabIndex = 6
        '
        'udRepeat
        '
        Me.udRepeat.Location = New System.Drawing.Point(357, 40)
        Me.udRepeat.Maximum = New Decimal(New Integer() {99999, 0, 0, 0})
        Me.udRepeat.Name = "udRepeat"
        Me.udRepeat.Size = New System.Drawing.Size(71, 20)
        Me.udRepeat.TabIndex = 7
        Me.udRepeat.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'lblX
        '
        Me.lblX.AutoSize = True
        Me.lblX.Location = New System.Drawing.Point(4, 72)
        Me.lblX.Name = "lblX"
        Me.lblX.Size = New System.Drawing.Size(38, 13)
        Me.lblX.TabIndex = 8
        Me.lblX.Text = "X-Pos:"
        '
        'lblY
        '
        Me.lblY.AutoSize = True
        Me.lblY.Location = New System.Drawing.Point(2, 97)
        Me.lblY.Name = "lblY"
        Me.lblY.Size = New System.Drawing.Size(38, 13)
        Me.lblY.TabIndex = 9
        Me.lblY.Text = "Y-Pos:"
        '
        'udX
        '
        Me.udX.Increment = New Decimal(New Integer() {10, 0, 0, 0})
        Me.udX.Location = New System.Drawing.Point(42, 69)
        Me.udX.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.udX.Name = "udX"
        Me.udX.Size = New System.Drawing.Size(101, 20)
        Me.udX.TabIndex = 10
        '
        'udY
        '
        Me.udY.Increment = New Decimal(New Integer() {10, 0, 0, 0})
        Me.udY.Location = New System.Drawing.Point(41, 94)
        Me.udY.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.udY.Name = "udY"
        Me.udY.Size = New System.Drawing.Size(102, 20)
        Me.udY.TabIndex = 11
        '
        'tcData
        '
        Me.tcData.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.tcData.Controls.Add(Me.tpStatic)
        Me.tcData.Controls.Add(Me.tcFileContent)
        Me.tcData.Controls.Add(Me.tcLoop)
        Me.tcData.Location = New System.Drawing.Point(7, 130)
        Me.tcData.Name = "tcData"
        Me.tcData.SelectedIndex = 0
        Me.tcData.Size = New System.Drawing.Size(421, 66)
        Me.tcData.TabIndex = 12
        '
        'tpStatic
        '
        Me.tpStatic.Controls.Add(Me.txtStatic)
        Me.tpStatic.Location = New System.Drawing.Point(4, 25)
        Me.tpStatic.Name = "tpStatic"
        Me.tpStatic.Padding = New System.Windows.Forms.Padding(3)
        Me.tpStatic.Size = New System.Drawing.Size(413, 37)
        Me.tpStatic.TabIndex = 0
        Me.tpStatic.Text = "Static Text"
        Me.tpStatic.UseVisualStyleBackColor = True
        '
        'txtStatic
        '
        Me.txtStatic.Location = New System.Drawing.Point(4, 7)
        Me.txtStatic.Name = "txtStatic"
        Me.txtStatic.Size = New System.Drawing.Size(403, 20)
        Me.txtStatic.TabIndex = 0
        '
        'tcFileContent
        '
        Me.tcFileContent.Controls.Add(Me.txtFile)
        Me.tcFileContent.Location = New System.Drawing.Point(4, 25)
        Me.tcFileContent.Name = "tcFileContent"
        Me.tcFileContent.Padding = New System.Windows.Forms.Padding(3)
        Me.tcFileContent.Size = New System.Drawing.Size(413, 37)
        Me.tcFileContent.TabIndex = 1
        Me.tcFileContent.Text = "File Content"
        Me.tcFileContent.UseVisualStyleBackColor = True
        '
        'txtFile
        '
        Me.txtFile.Location = New System.Drawing.Point(4, 7)
        Me.txtFile.Name = "txtFile"
        Me.txtFile.Size = New System.Drawing.Size(403, 20)
        Me.txtFile.TabIndex = 0
        '
        'tcLoop
        '
        Me.tcLoop.Controls.Add(Me.udStep)
        Me.tcLoop.Controls.Add(Me.udEnd)
        Me.tcLoop.Controls.Add(Me.udStart)
        Me.tcLoop.Controls.Add(Me.lblStep)
        Me.tcLoop.Controls.Add(Me.lblEnd)
        Me.tcLoop.Controls.Add(Me.lblStart)
        Me.tcLoop.Location = New System.Drawing.Point(4, 25)
        Me.tcLoop.Name = "tcLoop"
        Me.tcLoop.Padding = New System.Windows.Forms.Padding(3)
        Me.tcLoop.Size = New System.Drawing.Size(413, 37)
        Me.tcLoop.TabIndex = 2
        Me.tcLoop.Text = "Loop Data"
        Me.tcLoop.UseVisualStyleBackColor = True
        '
        'udStep
        '
        Me.udStep.Location = New System.Drawing.Point(348, 7)
        Me.udStep.Name = "udStep"
        Me.udStep.Size = New System.Drawing.Size(62, 20)
        Me.udStep.TabIndex = 13
        Me.udStep.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'udEnd
        '
        Me.udEnd.Location = New System.Drawing.Point(217, 7)
        Me.udEnd.Name = "udEnd"
        Me.udEnd.Size = New System.Drawing.Size(87, 20)
        Me.udEnd.TabIndex = 12
        Me.udEnd.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'udStart
        '
        Me.udStart.Location = New System.Drawing.Point(62, 6)
        Me.udStart.Name = "udStart"
        Me.udStart.Size = New System.Drawing.Size(87, 20)
        Me.udStart.TabIndex = 11
        '
        'lblStep
        '
        Me.lblStep.AutoSize = True
        Me.lblStep.Location = New System.Drawing.Point(313, 10)
        Me.lblStep.Name = "lblStep"
        Me.lblStep.Size = New System.Drawing.Size(32, 13)
        Me.lblStep.TabIndex = 10
        Me.lblStep.Text = "Step:"
        '
        'lblEnd
        '
        Me.lblEnd.AutoSize = True
        Me.lblEnd.Location = New System.Drawing.Point(157, 10)
        Me.lblEnd.Name = "lblEnd"
        Me.lblEnd.Size = New System.Drawing.Size(59, 13)
        Me.lblEnd.TabIndex = 9
        Me.lblEnd.Text = "End Value:"
        '
        'lblStart
        '
        Me.lblStart.AutoSize = True
        Me.lblStart.Location = New System.Drawing.Point(1, 9)
        Me.lblStart.Name = "lblStart"
        Me.lblStart.Size = New System.Drawing.Size(62, 13)
        Me.lblStart.TabIndex = 8
        Me.lblStart.Text = "Start Value:"
        '
        'ofdOpenFileDialog
        '
        Me.ofdOpenFileDialog.FileName = "OpenFileDialog1"
        '
        'chkSelectAll
        '
        Me.chkSelectAll.AutoSize = True
        Me.chkSelectAll.Location = New System.Drawing.Point(168, 71)
        Me.chkSelectAll.Name = "chkSelectAll"
        Me.chkSelectAll.Size = New System.Drawing.Size(148, 17)
        Me.chkSelectAll.TabIndex = 13
        Me.chkSelectAll.Text = "Select All Before Pasting?"
        Me.chkSelectAll.UseVisualStyleBackColor = True
        '
        'chkDeselectAll
        '
        Me.chkDeselectAll.AutoSize = True
        Me.chkDeselectAll.Location = New System.Drawing.Point(168, 95)
        Me.chkDeselectAll.Name = "chkDeselectAll"
        Me.chkDeselectAll.Size = New System.Drawing.Size(165, 17)
        Me.chkDeselectAll.TabIndex = 14
        Me.chkDeselectAll.Text = "De-Select All Before Pasting?"
        Me.chkDeselectAll.UseVisualStyleBackColor = True
        '
        'frmProperties
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(440, 230)
        Me.Controls.Add(Me.chkDeselectAll)
        Me.Controls.Add(Me.chkSelectAll)
        Me.Controls.Add(Me.tcData)
        Me.Controls.Add(Me.udY)
        Me.Controls.Add(Me.udX)
        Me.Controls.Add(Me.lblY)
        Me.Controls.Add(Me.lblX)
        Me.Controls.Add(Me.udRepeat)
        Me.Controls.Add(Me.cboEventType)
        Me.Controls.Add(Me.lblRepeat)
        Me.Controls.Add(Me.lblEventType)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.lblName)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnCancel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmProperties"
        Me.Text = "Properties"
        CType(Me.udRepeat, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.udX, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.udY, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tcData.ResumeLayout(False)
        Me.tpStatic.ResumeLayout(False)
        Me.tpStatic.PerformLayout()
        Me.tcFileContent.ResumeLayout(False)
        Me.tcFileContent.PerformLayout()
        Me.tcLoop.ResumeLayout(False)
        Me.tcLoop.PerformLayout()
        CType(Me.udStep, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.udEnd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.udStart, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents lblEventType As System.Windows.Forms.Label
    Friend WithEvents lblRepeat As System.Windows.Forms.Label
    Friend WithEvents cboEventType As System.Windows.Forms.ComboBox
    Friend WithEvents udRepeat As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblX As System.Windows.Forms.Label
    Friend WithEvents lblY As System.Windows.Forms.Label
    Friend WithEvents udX As System.Windows.Forms.NumericUpDown
    Friend WithEvents udY As System.Windows.Forms.NumericUpDown
    Friend WithEvents tcData As System.Windows.Forms.TabControl
    Friend WithEvents tpStatic As System.Windows.Forms.TabPage
    Friend WithEvents tcFileContent As System.Windows.Forms.TabPage
    Friend WithEvents tcLoop As System.Windows.Forms.TabPage
    Friend WithEvents txtStatic As System.Windows.Forms.TextBox
    Friend WithEvents txtFile As System.Windows.Forms.TextBox
    Friend WithEvents udStep As System.Windows.Forms.NumericUpDown
    Friend WithEvents udEnd As System.Windows.Forms.NumericUpDown
    Friend WithEvents udStart As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblStep As System.Windows.Forms.Label
    Friend WithEvents lblEnd As System.Windows.Forms.Label
    Friend WithEvents lblStart As System.Windows.Forms.Label
    Friend WithEvents ofdOpenFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents chkSelectAll As System.Windows.Forms.CheckBox
    Friend WithEvents chkDeselectAll As System.Windows.Forms.CheckBox
End Class
