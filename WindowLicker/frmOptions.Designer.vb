<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOptions
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
        Me.lblPause = New System.Windows.Forms.Label()
        Me.udPause = New System.Windows.Forms.NumericUpDown()
        Me.lblMilliSecs = New System.Windows.Forms.Label()
        Me.lblRepeat = New System.Windows.Forms.Label()
        Me.udRepeat = New System.Windows.Forms.NumericUpDown()
        Me.gbFile = New System.Windows.Forms.GroupBox()
        Me.btnBrowse = New System.Windows.Forms.Button()
        Me.cboFile = New System.Windows.Forms.ComboBox()
        Me.lblFile = New System.Windows.Forms.Label()
        Me.cbSave = New System.Windows.Forms.CheckBox()
        Me.sfdSaveFileDialog = New System.Windows.Forms.SaveFileDialog()
        Me.chkDeselectAll = New System.Windows.Forms.CheckBox()
        Me.chkSelectAll = New System.Windows.Forms.CheckBox()
        Me.gbGuiMonitor = New System.Windows.Forms.GroupBox()
        Me.lblMilliseconds = New System.Windows.Forms.Label()
        Me.udGuiMonitor = New System.Windows.Forms.NumericUpDown()
        Me.lblGuiCheck = New System.Windows.Forms.Label()
        Me.cboConditions = New System.Windows.Forms.ComboBox()
        Me.chkTerminate = New System.Windows.Forms.CheckBox()
        Me.chkEnableGuiMon = New System.Windows.Forms.CheckBox()
        Me.gbOCR = New System.Windows.Forms.GroupBox()
        Me.btnScreenShot = New System.Windows.Forms.Button()
        Me.cboScreenshot = New System.Windows.Forms.ComboBox()
        Me.lblScreenshot = New System.Windows.Forms.Label()
        Me.btnTesseract = New System.Windows.Forms.Button()
        Me.cboTesseract = New System.Windows.Forms.ComboBox()
        Me.lblTesseract = New System.Windows.Forms.Label()
        Me.lblArgs = New System.Windows.Forms.Label()
        Me.txtArgs = New System.Windows.Forms.TextBox()
        CType(Me.udPause, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.udRepeat, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbFile.SuspendLayout()
        Me.gbGuiMonitor.SuspendLayout()
        CType(Me.udGuiMonitor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbOCR.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(407, 368)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 0
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(488, 368)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'lblPause
        '
        Me.lblPause.AutoSize = True
        Me.lblPause.Location = New System.Drawing.Point(3, 16)
        Me.lblPause.Name = "lblPause"
        Me.lblPause.Size = New System.Drawing.Size(121, 13)
        Me.lblPause.TabIndex = 2
        Me.lblPause.Text = "Pause Between Events:"
        '
        'udPause
        '
        Me.udPause.Increment = New Decimal(New Integer() {10, 0, 0, 0})
        Me.udPause.Location = New System.Drawing.Point(125, 13)
        Me.udPause.Maximum = New Decimal(New Integer() {240000, 0, 0, 0})
        Me.udPause.Name = "udPause"
        Me.udPause.Size = New System.Drawing.Size(98, 20)
        Me.udPause.TabIndex = 3
        '
        'lblMilliSecs
        '
        Me.lblMilliSecs.AutoSize = True
        Me.lblMilliSecs.Location = New System.Drawing.Point(224, 16)
        Me.lblMilliSecs.Name = "lblMilliSecs"
        Me.lblMilliSecs.Size = New System.Drawing.Size(64, 13)
        Me.lblMilliSecs.TabIndex = 4
        Me.lblMilliSecs.Text = "Milliseconds"
        '
        'lblRepeat
        '
        Me.lblRepeat.AutoSize = True
        Me.lblRepeat.Location = New System.Drawing.Point(5, 46)
        Me.lblRepeat.Name = "lblRepeat"
        Me.lblRepeat.Size = New System.Drawing.Size(82, 13)
        Me.lblRepeat.TabIndex = 5
        Me.lblRepeat.Text = "Default Repeat:"
        '
        'udRepeat
        '
        Me.udRepeat.Location = New System.Drawing.Point(125, 43)
        Me.udRepeat.Maximum = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.udRepeat.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.udRepeat.Name = "udRepeat"
        Me.udRepeat.Size = New System.Drawing.Size(98, 20)
        Me.udRepeat.TabIndex = 6
        Me.udRepeat.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'gbFile
        '
        Me.gbFile.Controls.Add(Me.btnBrowse)
        Me.gbFile.Controls.Add(Me.cboFile)
        Me.gbFile.Controls.Add(Me.lblFile)
        Me.gbFile.Controls.Add(Me.cbSave)
        Me.gbFile.Location = New System.Drawing.Point(6, 67)
        Me.gbFile.Name = "gbFile"
        Me.gbFile.Size = New System.Drawing.Size(558, 77)
        Me.gbFile.TabIndex = 7
        Me.gbFile.TabStop = False
        '
        'btnBrowse
        '
        Me.btnBrowse.Location = New System.Drawing.Point(524, 39)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(29, 23)
        Me.btnBrowse.TabIndex = 3
        Me.btnBrowse.Text = "..."
        Me.btnBrowse.UseVisualStyleBackColor = True
        '
        'cboFile
        '
        Me.cboFile.FormattingEnabled = True
        Me.cboFile.Location = New System.Drawing.Point(57, 41)
        Me.cboFile.Name = "cboFile"
        Me.cboFile.Size = New System.Drawing.Size(461, 21)
        Me.cboFile.TabIndex = 2
        '
        'lblFile
        '
        Me.lblFile.AutoSize = True
        Me.lblFile.Location = New System.Drawing.Point(7, 43)
        Me.lblFile.Name = "lblFile"
        Me.lblFile.Size = New System.Drawing.Size(47, 13)
        Me.lblFile.TabIndex = 1
        Me.lblFile.Text = "Log File:"
        '
        'cbSave
        '
        Me.cbSave.AutoSize = True
        Me.cbSave.Location = New System.Drawing.Point(7, 14)
        Me.cbSave.Name = "cbSave"
        Me.cbSave.Size = New System.Drawing.Size(137, 17)
        Me.cbSave.TabIndex = 0
        Me.cbSave.Text = "Automatically Save Log"
        Me.cbSave.UseVisualStyleBackColor = True
        '
        'chkDeselectAll
        '
        Me.chkDeselectAll.AutoSize = True
        Me.chkDeselectAll.Location = New System.Drawing.Point(335, 42)
        Me.chkDeselectAll.Name = "chkDeselectAll"
        Me.chkDeselectAll.Size = New System.Drawing.Size(218, 17)
        Me.chkDeselectAll.TabIndex = 16
        Me.chkDeselectAll.Text = "De-Select All Before Every Paste Event?"
        Me.chkDeselectAll.UseVisualStyleBackColor = True
        '
        'chkSelectAll
        '
        Me.chkSelectAll.AutoSize = True
        Me.chkSelectAll.Location = New System.Drawing.Point(335, 14)
        Me.chkSelectAll.Name = "chkSelectAll"
        Me.chkSelectAll.Size = New System.Drawing.Size(204, 17)
        Me.chkSelectAll.TabIndex = 15
        Me.chkSelectAll.Text = "Select All Before Every Paste  Event?"
        Me.chkSelectAll.UseVisualStyleBackColor = True
        '
        'gbGuiMonitor
        '
        Me.gbGuiMonitor.Controls.Add(Me.lblMilliseconds)
        Me.gbGuiMonitor.Controls.Add(Me.udGuiMonitor)
        Me.gbGuiMonitor.Controls.Add(Me.lblGuiCheck)
        Me.gbGuiMonitor.Controls.Add(Me.cboConditions)
        Me.gbGuiMonitor.Controls.Add(Me.chkTerminate)
        Me.gbGuiMonitor.Controls.Add(Me.chkEnableGuiMon)
        Me.gbGuiMonitor.Location = New System.Drawing.Point(6, 150)
        Me.gbGuiMonitor.Name = "gbGuiMonitor"
        Me.gbGuiMonitor.Size = New System.Drawing.Size(558, 99)
        Me.gbGuiMonitor.TabIndex = 17
        Me.gbGuiMonitor.TabStop = False
        Me.gbGuiMonitor.Text = "GUI Monitor"
        '
        'lblMilliseconds
        '
        Me.lblMilliseconds.AutoSize = True
        Me.lblMilliseconds.Location = New System.Drawing.Point(241, 75)
        Me.lblMilliseconds.Name = "lblMilliseconds"
        Me.lblMilliseconds.Size = New System.Drawing.Size(64, 13)
        Me.lblMilliseconds.TabIndex = 6
        Me.lblMilliseconds.Text = "Milliseconds"
        '
        'udGuiMonitor
        '
        Me.udGuiMonitor.Location = New System.Drawing.Point(142, 72)
        Me.udGuiMonitor.Maximum = New Decimal(New Integer() {240000, 0, 0, 0})
        Me.udGuiMonitor.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.udGuiMonitor.Name = "udGuiMonitor"
        Me.udGuiMonitor.Size = New System.Drawing.Size(92, 20)
        Me.udGuiMonitor.TabIndex = 5
        Me.udGuiMonitor.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'lblGuiCheck
        '
        Me.lblGuiCheck.AutoSize = True
        Me.lblGuiCheck.Location = New System.Drawing.Point(6, 75)
        Me.lblGuiCheck.Name = "lblGuiCheck"
        Me.lblGuiCheck.Size = New System.Drawing.Size(128, 13)
        Me.lblGuiCheck.TabIndex = 4
        Me.lblGuiCheck.Text = "Check GUI Monitor Every"
        '
        'cboConditions
        '
        Me.cboConditions.FormattingEnabled = True
        Me.cboConditions.Items.AddRange(New Object() {"When First Condition Is Met", "When All Conditions Are Met"})
        Me.cboConditions.Location = New System.Drawing.Point(111, 43)
        Me.cboConditions.Name = "cboConditions"
        Me.cboConditions.Size = New System.Drawing.Size(312, 21)
        Me.cboConditions.TabIndex = 3
        '
        'chkTerminate
        '
        Me.chkTerminate.AutoSize = True
        Me.chkTerminate.Location = New System.Drawing.Point(7, 45)
        Me.chkTerminate.Name = "chkTerminate"
        Me.chkTerminate.Size = New System.Drawing.Size(97, 17)
        Me.chkTerminate.TabIndex = 1
        Me.chkTerminate.Text = "Terminate Test"
        Me.chkTerminate.UseVisualStyleBackColor = True
        '
        'chkEnableGuiMon
        '
        Me.chkEnableGuiMon.AutoSize = True
        Me.chkEnableGuiMon.Location = New System.Drawing.Point(7, 19)
        Me.chkEnableGuiMon.Name = "chkEnableGuiMon"
        Me.chkEnableGuiMon.Size = New System.Drawing.Size(119, 17)
        Me.chkEnableGuiMon.TabIndex = 0
        Me.chkEnableGuiMon.Text = "Enable GUI Monitor"
        Me.chkEnableGuiMon.UseVisualStyleBackColor = True
        '
        'gbOCR
        '
        Me.gbOCR.Controls.Add(Me.txtArgs)
        Me.gbOCR.Controls.Add(Me.lblArgs)
        Me.gbOCR.Controls.Add(Me.btnScreenShot)
        Me.gbOCR.Controls.Add(Me.cboScreenshot)
        Me.gbOCR.Controls.Add(Me.lblScreenshot)
        Me.gbOCR.Controls.Add(Me.btnTesseract)
        Me.gbOCR.Controls.Add(Me.cboTesseract)
        Me.gbOCR.Controls.Add(Me.lblTesseract)
        Me.gbOCR.Location = New System.Drawing.Point(6, 254)
        Me.gbOCR.Name = "gbOCR"
        Me.gbOCR.Size = New System.Drawing.Size(558, 104)
        Me.gbOCR.TabIndex = 18
        Me.gbOCR.TabStop = False
        Me.gbOCR.Text = "OCR"
        '
        'btnScreenShot
        '
        Me.btnScreenShot.Location = New System.Drawing.Point(523, 71)
        Me.btnScreenShot.Name = "btnScreenShot"
        Me.btnScreenShot.Size = New System.Drawing.Size(29, 23)
        Me.btnScreenShot.TabIndex = 15
        Me.btnScreenShot.Text = "..."
        Me.btnScreenShot.UseVisualStyleBackColor = True
        '
        'cboScreenshot
        '
        Me.cboScreenshot.FormattingEnabled = True
        Me.cboScreenshot.Location = New System.Drawing.Point(168, 72)
        Me.cboScreenshot.Name = "cboScreenshot"
        Me.cboScreenshot.Size = New System.Drawing.Size(349, 21)
        Me.cboScreenshot.TabIndex = 14
        '
        'lblScreenshot
        '
        Me.lblScreenshot.AutoSize = True
        Me.lblScreenshot.Location = New System.Drawing.Point(8, 76)
        Me.lblScreenshot.Name = "lblScreenshot"
        Me.lblScreenshot.Size = New System.Drawing.Size(157, 13)
        Me.lblScreenshot.TabIndex = 13
        Me.lblScreenshot.Text = "Screenshot Temporary Storage:"
        '
        'btnTesseract
        '
        Me.btnTesseract.Location = New System.Drawing.Point(523, 15)
        Me.btnTesseract.Name = "btnTesseract"
        Me.btnTesseract.Size = New System.Drawing.Size(29, 23)
        Me.btnTesseract.TabIndex = 12
        Me.btnTesseract.Text = "..."
        Me.btnTesseract.UseVisualStyleBackColor = True
        '
        'cboTesseract
        '
        Me.cboTesseract.FormattingEnabled = True
        Me.cboTesseract.Location = New System.Drawing.Point(132, 17)
        Me.cboTesseract.Name = "cboTesseract"
        Me.cboTesseract.Size = New System.Drawing.Size(385, 21)
        Me.cboTesseract.TabIndex = 11
        '
        'lblTesseract
        '
        Me.lblTesseract.AutoSize = True
        Me.lblTesseract.Location = New System.Drawing.Point(7, 21)
        Me.lblTesseract.Name = "lblTesseract"
        Me.lblTesseract.Size = New System.Drawing.Size(101, 13)
        Me.lblTesseract.TabIndex = 10
        Me.lblTesseract.Text = "Tesseract Location:"
        '
        'lblArgs
        '
        Me.lblArgs.AutoSize = True
        Me.lblArgs.Location = New System.Drawing.Point(7, 49)
        Me.lblArgs.Name = "lblArgs"
        Me.lblArgs.Size = New System.Drawing.Size(110, 13)
        Me.lblArgs.TabIndex = 16
        Me.lblArgs.Text = "Tesseract Arguments:"
        '
        'txtArgs
        '
        Me.txtArgs.Location = New System.Drawing.Point(132, 44)
        Me.txtArgs.Name = "txtArgs"
        Me.txtArgs.Size = New System.Drawing.Size(385, 20)
        Me.txtArgs.TabIndex = 17
        '
        'frmOptions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(572, 399)
        Me.Controls.Add(Me.gbOCR)
        Me.Controls.Add(Me.gbGuiMonitor)
        Me.Controls.Add(Me.chkDeselectAll)
        Me.Controls.Add(Me.chkSelectAll)
        Me.Controls.Add(Me.gbFile)
        Me.Controls.Add(Me.udRepeat)
        Me.Controls.Add(Me.lblRepeat)
        Me.Controls.Add(Me.lblMilliSecs)
        Me.Controls.Add(Me.udPause)
        Me.Controls.Add(Me.lblPause)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpButton = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmOptions"
        Me.Text = "Options"
        CType(Me.udPause, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.udRepeat, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbFile.ResumeLayout(False)
        Me.gbFile.PerformLayout()
        Me.gbGuiMonitor.ResumeLayout(False)
        Me.gbGuiMonitor.PerformLayout()
        CType(Me.udGuiMonitor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbOCR.ResumeLayout(False)
        Me.gbOCR.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents lblPause As System.Windows.Forms.Label
    Friend WithEvents udPause As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblMilliSecs As System.Windows.Forms.Label
    Friend WithEvents lblRepeat As System.Windows.Forms.Label
    Friend WithEvents udRepeat As System.Windows.Forms.NumericUpDown
    Friend WithEvents gbFile As System.Windows.Forms.GroupBox
    Friend WithEvents cboFile As System.Windows.Forms.ComboBox
    Friend WithEvents lblFile As System.Windows.Forms.Label
    Friend WithEvents cbSave As System.Windows.Forms.CheckBox
    Friend WithEvents sfdSaveFileDialog As System.Windows.Forms.SaveFileDialog
    Friend WithEvents btnBrowse As System.Windows.Forms.Button
    Friend WithEvents chkDeselectAll As System.Windows.Forms.CheckBox
    Friend WithEvents chkSelectAll As System.Windows.Forms.CheckBox
    Friend WithEvents gbGuiMonitor As System.Windows.Forms.GroupBox
    Friend WithEvents cboConditions As System.Windows.Forms.ComboBox
    Friend WithEvents chkTerminate As System.Windows.Forms.CheckBox
    Friend WithEvents chkEnableGuiMon As System.Windows.Forms.CheckBox
    Friend WithEvents lblMilliseconds As System.Windows.Forms.Label
    Friend WithEvents udGuiMonitor As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblGuiCheck As System.Windows.Forms.Label
    Friend WithEvents gbOCR As System.Windows.Forms.GroupBox
    Friend WithEvents btnScreenShot As System.Windows.Forms.Button
    Friend WithEvents cboScreenshot As System.Windows.Forms.ComboBox
    Friend WithEvents lblScreenshot As System.Windows.Forms.Label
    Friend WithEvents btnTesseract As System.Windows.Forms.Button
    Friend WithEvents cboTesseract As System.Windows.Forms.ComboBox
    Friend WithEvents lblTesseract As System.Windows.Forms.Label
    Friend WithEvents txtArgs As System.Windows.Forms.TextBox
    Friend WithEvents lblArgs As System.Windows.Forms.Label
End Class
