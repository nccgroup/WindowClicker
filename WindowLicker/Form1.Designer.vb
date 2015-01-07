<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Me.components = New System.ComponentModel.Container()
        Me.timTimer = New System.Windows.Forms.Timer(Me.components)
        Me.mnuMenuStrip = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NewTestToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenPreviousTestToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveTestToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusBarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.sbStatusStrip = New System.Windows.Forms.StatusStrip()
        Me.spMain = New System.Windows.Forms.SplitContainer()
        Me.spData = New System.Windows.Forms.SplitContainer()
        Me.btnClick = New System.Windows.Forms.Button()
        Me.btnLoop = New System.Windows.Forms.Button()
        Me.ofdOpenFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.sfdSaveFileDialog = New System.Windows.Forms.SaveFileDialog()
        Me.btnFile = New System.Windows.Forms.Button()
        Me.btnStatic = New System.Windows.Forms.Button()
        Me.btnGo = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.spDetails = New System.Windows.Forms.SplitContainer()
        Me.tvEvent = New System.Windows.Forms.TreeView()
        Me.lvDetail = New System.Windows.Forms.ListView()
        Me.txtLog = New System.Windows.Forms.TextBox()
        Me.mnuMenuStrip.SuspendLayout()
        CType(Me.spMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.spMain.Panel1.SuspendLayout()
        Me.spMain.Panel2.SuspendLayout()
        Me.spMain.SuspendLayout()
        CType(Me.spData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.spData.Panel1.SuspendLayout()
        Me.spData.Panel2.SuspendLayout()
        Me.spData.SuspendLayout()
        CType(Me.spDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.spDetails.Panel1.SuspendLayout()
        Me.spDetails.Panel2.SuspendLayout()
        Me.spDetails.SuspendLayout()
        Me.SuspendLayout()
        '
        'timTimer
        '
        Me.timTimer.Interval = 500
        '
        'mnuMenuStrip
        '
        Me.mnuMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.ViewToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.mnuMenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.mnuMenuStrip.Name = "mnuMenuStrip"
        Me.mnuMenuStrip.Size = New System.Drawing.Size(859, 24)
        Me.mnuMenuStrip.TabIndex = 0
        Me.mnuMenuStrip.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewTestToolStripMenuItem, Me.OpenPreviousTestToolStripMenuItem, Me.SaveTestToolStripMenuItem, Me.ToolStripMenuItem1, Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'NewTestToolStripMenuItem
        '
        Me.NewTestToolStripMenuItem.Name = "NewTestToolStripMenuItem"
        Me.NewTestToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me.NewTestToolStripMenuItem.Size = New System.Drawing.Size(228, 22)
        Me.NewTestToolStripMenuItem.Text = "New Test"
        '
        'OpenPreviousTestToolStripMenuItem
        '
        Me.OpenPreviousTestToolStripMenuItem.Name = "OpenPreviousTestToolStripMenuItem"
        Me.OpenPreviousTestToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
        Me.OpenPreviousTestToolStripMenuItem.Size = New System.Drawing.Size(228, 22)
        Me.OpenPreviousTestToolStripMenuItem.Text = "Open Previous Test..."
        '
        'SaveTestToolStripMenuItem
        '
        Me.SaveTestToolStripMenuItem.Name = "SaveTestToolStripMenuItem"
        Me.SaveTestToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.SaveTestToolStripMenuItem.Size = New System.Drawing.Size(228, 22)
        Me.SaveTestToolStripMenuItem.Text = "Save Test..."
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(225, 6)
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.F4), System.Windows.Forms.Keys)
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(228, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'ViewToolStripMenuItem
        '
        Me.ViewToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StatusBarToolStripMenuItem})
        Me.ViewToolStripMenuItem.Name = "ViewToolStripMenuItem"
        Me.ViewToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.ViewToolStripMenuItem.Text = "View"
        '
        'StatusBarToolStripMenuItem
        '
        Me.StatusBarToolStripMenuItem.Checked = True
        Me.StatusBarToolStripMenuItem.CheckOnClick = True
        Me.StatusBarToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.StatusBarToolStripMenuItem.Name = "StatusBarToolStripMenuItem"
        Me.StatusBarToolStripMenuItem.Size = New System.Drawing.Size(126, 22)
        Me.StatusBarToolStripMenuItem.Text = "Status Bar"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AboutToolStripMenuItem})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.HelpToolStripMenuItem.Text = "Help"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(116, 22)
        Me.AboutToolStripMenuItem.Text = "About..."
        '
        'sbStatusStrip
        '
        Me.sbStatusStrip.Location = New System.Drawing.Point(0, 502)
        Me.sbStatusStrip.Name = "sbStatusStrip"
        Me.sbStatusStrip.Size = New System.Drawing.Size(859, 22)
        Me.sbStatusStrip.TabIndex = 1
        Me.sbStatusStrip.Text = "StatusStrip1"
        '
        'spMain
        '
        Me.spMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.spMain.IsSplitterFixed = True
        Me.spMain.Location = New System.Drawing.Point(0, 24)
        Me.spMain.Name = "spMain"
        Me.spMain.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'spMain.Panel1
        '
        Me.spMain.Panel1.Controls.Add(Me.btnCancel)
        Me.spMain.Panel1.Controls.Add(Me.btnGo)
        Me.spMain.Panel1.Controls.Add(Me.btnStatic)
        Me.spMain.Panel1.Controls.Add(Me.btnFile)
        Me.spMain.Panel1.Controls.Add(Me.btnLoop)
        Me.spMain.Panel1.Controls.Add(Me.btnClick)
        '
        'spMain.Panel2
        '
        Me.spMain.Panel2.Controls.Add(Me.spData)
        Me.spMain.Size = New System.Drawing.Size(859, 478)
        Me.spMain.SplitterDistance = 29
        Me.spMain.TabIndex = 2
        '
        'spData
        '
        Me.spData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.spData.Location = New System.Drawing.Point(0, 0)
        Me.spData.Name = "spData"
        '
        'spData.Panel1
        '
        Me.spData.Panel1.Controls.Add(Me.tvEvent)
        '
        'spData.Panel2
        '
        Me.spData.Panel2.Controls.Add(Me.spDetails)
        Me.spData.Size = New System.Drawing.Size(859, 445)
        Me.spData.SplitterDistance = 286
        Me.spData.TabIndex = 0
        '
        'btnClick
        '
        Me.btnClick.Location = New System.Drawing.Point(4, 4)
        Me.btnClick.Name = "btnClick"
        Me.btnClick.Size = New System.Drawing.Size(75, 23)
        Me.btnClick.TabIndex = 0
        Me.btnClick.Text = "Click"
        Me.btnClick.UseVisualStyleBackColor = True
        '
        'btnLoop
        '
        Me.btnLoop.Location = New System.Drawing.Point(104, 4)
        Me.btnLoop.Name = "btnLoop"
        Me.btnLoop.Size = New System.Drawing.Size(75, 23)
        Me.btnLoop.TabIndex = 1
        Me.btnLoop.Text = "Loop..."
        Me.btnLoop.UseVisualStyleBackColor = True
        '
        'ofdOpenFileDialog
        '
        Me.ofdOpenFileDialog.FileName = "OpenFileDialog1"
        '
        'btnFile
        '
        Me.btnFile.Location = New System.Drawing.Point(185, 4)
        Me.btnFile.Name = "btnFile"
        Me.btnFile.Size = New System.Drawing.Size(75, 23)
        Me.btnFile.TabIndex = 2
        Me.btnFile.Text = "File..."
        Me.btnFile.UseVisualStyleBackColor = True
        '
        'btnStatic
        '
        Me.btnStatic.Location = New System.Drawing.Point(267, 4)
        Me.btnStatic.Name = "btnStatic"
        Me.btnStatic.Size = New System.Drawing.Size(75, 23)
        Me.btnStatic.TabIndex = 3
        Me.btnStatic.Text = "Static Text..."
        Me.btnStatic.UseVisualStyleBackColor = True
        '
        'btnGo
        '
        Me.btnGo.Location = New System.Drawing.Point(362, 4)
        Me.btnGo.Name = "btnGo"
        Me.btnGo.Size = New System.Drawing.Size(75, 23)
        Me.btnGo.TabIndex = 4
        Me.btnGo.Text = "Go"
        Me.btnGo.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Enabled = False
        Me.btnCancel.Location = New System.Drawing.Point(442, 4)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 5
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'spDetails
        '
        Me.spDetails.Dock = System.Windows.Forms.DockStyle.Fill
        Me.spDetails.Location = New System.Drawing.Point(0, 0)
        Me.spDetails.Name = "spDetails"
        Me.spDetails.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'spDetails.Panel1
        '
        Me.spDetails.Panel1.Controls.Add(Me.lvDetail)
        '
        'spDetails.Panel2
        '
        Me.spDetails.Panel2.Controls.Add(Me.txtLog)
        Me.spDetails.Size = New System.Drawing.Size(569, 445)
        Me.spDetails.SplitterDistance = 189
        Me.spDetails.TabIndex = 0
        '
        'tvEvent
        '
        Me.tvEvent.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tvEvent.Location = New System.Drawing.Point(0, 0)
        Me.tvEvent.Name = "tvEvent"
        Me.tvEvent.Size = New System.Drawing.Size(286, 445)
        Me.tvEvent.TabIndex = 0
        '
        'lvDetail
        '
        Me.lvDetail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvDetail.Location = New System.Drawing.Point(0, 0)
        Me.lvDetail.Name = "lvDetail"
        Me.lvDetail.Size = New System.Drawing.Size(569, 189)
        Me.lvDetail.TabIndex = 0
        Me.lvDetail.UseCompatibleStateImageBehavior = False
        '
        'txtLog
        '
        Me.txtLog.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtLog.Location = New System.Drawing.Point(0, 0)
        Me.txtLog.Multiline = True
        Me.txtLog.Name = "txtLog"
        Me.txtLog.Size = New System.Drawing.Size(569, 252)
        Me.txtLog.TabIndex = 0
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(859, 524)
        Me.Controls.Add(Me.spMain)
        Me.Controls.Add(Me.sbStatusStrip)
        Me.Controls.Add(Me.mnuMenuStrip)
        Me.MainMenuStrip = Me.mnuMenuStrip
        Me.Name = "frmMain"
        Me.Text = "WindowClicker"
        Me.mnuMenuStrip.ResumeLayout(False)
        Me.mnuMenuStrip.PerformLayout()
        Me.spMain.Panel1.ResumeLayout(False)
        Me.spMain.Panel2.ResumeLayout(False)
        CType(Me.spMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.spMain.ResumeLayout(False)
        Me.spData.Panel1.ResumeLayout(False)
        Me.spData.Panel2.ResumeLayout(False)
        CType(Me.spData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.spData.ResumeLayout(False)
        Me.spDetails.Panel1.ResumeLayout(False)
        Me.spDetails.Panel2.ResumeLayout(False)
        Me.spDetails.Panel2.PerformLayout()
        CType(Me.spDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.spDetails.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents timTimer As System.Windows.Forms.Timer
    Friend WithEvents mnuMenuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NewTestToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenPreviousTestToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveTestToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StatusBarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents sbStatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents spMain As System.Windows.Forms.SplitContainer
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnGo As System.Windows.Forms.Button
    Friend WithEvents btnStatic As System.Windows.Forms.Button
    Friend WithEvents btnFile As System.Windows.Forms.Button
    Friend WithEvents btnLoop As System.Windows.Forms.Button
    Friend WithEvents btnClick As System.Windows.Forms.Button
    Friend WithEvents spData As System.Windows.Forms.SplitContainer
    Friend WithEvents ofdOpenFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents sfdSaveFileDialog As System.Windows.Forms.SaveFileDialog
    Friend WithEvents tvEvent As System.Windows.Forms.TreeView
    Friend WithEvents spDetails As System.Windows.Forms.SplitContainer
    Friend WithEvents lvDetail As System.Windows.Forms.ListView
    Friend WithEvents txtLog As System.Windows.Forms.TextBox

End Class
