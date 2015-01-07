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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.mnuMenuStrip = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NewTestToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenPreviousTestToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveTestToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.SaveLogToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CopyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PasteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.SelectAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripSeparator()
        Me.FindToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LargeIconsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SmallIconsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ListToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DetailsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.StatusBarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PropertiesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.OptionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MonitorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExistingTextToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MonitoredTextToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExistingWindowsControlsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripSeparator()
        Me.AddNewWindowTitleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NewWindowTitlesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem5 = New System.Windows.Forms.ToolStripSeparator()
        Me.ActivateGUIMonitorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.sbStatusStrip = New System.Windows.Forms.StatusStrip()
        Me.tslStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tslProgressBar = New System.Windows.Forms.ToolStripProgressBar()
        Me.tslProgress = New System.Windows.Forms.ToolStripStatusLabel()
        Me.spMain = New System.Windows.Forms.SplitContainer()
        Me.btnClickSequence = New System.Windows.Forms.Button()
        Me.btnDoubleClick = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnGo = New System.Windows.Forms.Button()
        Me.btnStatic = New System.Windows.Forms.Button()
        Me.btnFile = New System.Windows.Forms.Button()
        Me.btnLoop = New System.Windows.Forms.Button()
        Me.btnClick = New System.Windows.Forms.Button()
        Me.spData = New System.Windows.Forms.SplitContainer()
        Me.tvEvent = New System.Windows.Forms.TreeView()
        Me.ilSmall = New System.Windows.Forms.ImageList(Me.components)
        Me.spDetails = New System.Windows.Forms.SplitContainer()
        Me.lvDetail = New System.Windows.Forms.ListView()
        Me.chName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chType = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chRepeat = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chData = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ilLarge = New System.Windows.Forms.ImageList(Me.components)
        Me.txtLog = New System.Windows.Forms.TextBox()
        Me.ofdOpenFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.sfdSaveFileDialog = New System.Windows.Forms.SaveFileDialog()
        Me.cmListView = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ContextCutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContextCopyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContextPasteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContextDeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.ContextSelectAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem9 = New System.Windows.Forms.ToolStripSeparator()
        Me.ContextPropertiesToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmTreeView = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.TreeCutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TreeCopyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TreePasteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TreeDeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.TreePropertiesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.timTimer = New System.Windows.Forms.Timer(Me.components)
        Me.mnuMenuStrip.SuspendLayout()
        Me.sbStatusStrip.SuspendLayout()
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
        Me.cmListView.SuspendLayout()
        Me.cmTreeView.SuspendLayout()
        Me.SuspendLayout()
        '
        'mnuMenuStrip
        '
        Me.mnuMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.ViewToolStripMenuItem, Me.ToolsToolStripMenuItem, Me.MonitorToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.mnuMenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.mnuMenuStrip.Name = "mnuMenuStrip"
        Me.mnuMenuStrip.Size = New System.Drawing.Size(775, 24)
        Me.mnuMenuStrip.TabIndex = 0
        Me.mnuMenuStrip.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewTestToolStripMenuItem, Me.OpenPreviousTestToolStripMenuItem, Me.SaveTestToolStripMenuItem, Me.ToolStripMenuItem1, Me.SaveLogToolStripMenuItem, Me.ToolStripSeparator1, Me.ExitToolStripMenuItem})
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
        'SaveLogToolStripMenuItem
        '
        Me.SaveLogToolStripMenuItem.Name = "SaveLogToolStripMenuItem"
        Me.SaveLogToolStripMenuItem.Size = New System.Drawing.Size(228, 22)
        Me.SaveLogToolStripMenuItem.Text = "Save Log..."
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(225, 6)
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.F4), System.Windows.Forms.Keys)
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(228, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CutToolStripMenuItem, Me.CopyToolStripMenuItem, Me.PasteToolStripMenuItem, Me.DeleteToolStripMenuItem, Me.ToolStripMenuItem2, Me.SelectAllToolStripMenuItem, Me.ToolStripMenuItem3, Me.FindToolStripMenuItem})
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(39, 20)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'CutToolStripMenuItem
        '
        Me.CutToolStripMenuItem.Name = "CutToolStripMenuItem"
        Me.CutToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.X), System.Windows.Forms.Keys)
        Me.CutToolStripMenuItem.Size = New System.Drawing.Size(164, 22)
        Me.CutToolStripMenuItem.Text = "Cut"
        '
        'CopyToolStripMenuItem
        '
        Me.CopyToolStripMenuItem.Name = "CopyToolStripMenuItem"
        Me.CopyToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.C), System.Windows.Forms.Keys)
        Me.CopyToolStripMenuItem.Size = New System.Drawing.Size(164, 22)
        Me.CopyToolStripMenuItem.Text = "Copy"
        '
        'PasteToolStripMenuItem
        '
        Me.PasteToolStripMenuItem.Name = "PasteToolStripMenuItem"
        Me.PasteToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.V), System.Windows.Forms.Keys)
        Me.PasteToolStripMenuItem.Size = New System.Drawing.Size(164, 22)
        Me.PasteToolStripMenuItem.Text = "Paste"
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(164, 22)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(161, 6)
        '
        'SelectAllToolStripMenuItem
        '
        Me.SelectAllToolStripMenuItem.Name = "SelectAllToolStripMenuItem"
        Me.SelectAllToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.A), System.Windows.Forms.Keys)
        Me.SelectAllToolStripMenuItem.Size = New System.Drawing.Size(164, 22)
        Me.SelectAllToolStripMenuItem.Text = "Select All"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(161, 6)
        '
        'FindToolStripMenuItem
        '
        Me.FindToolStripMenuItem.Name = "FindToolStripMenuItem"
        Me.FindToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F), System.Windows.Forms.Keys)
        Me.FindToolStripMenuItem.Size = New System.Drawing.Size(164, 22)
        Me.FindToolStripMenuItem.Text = "Find"
        '
        'ViewToolStripMenuItem
        '
        Me.ViewToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LargeIconsToolStripMenuItem, Me.SmallIconsToolStripMenuItem, Me.ListToolStripMenuItem, Me.DetailsToolStripMenuItem, Me.ToolStripSeparator2, Me.StatusBarToolStripMenuItem})
        Me.ViewToolStripMenuItem.Name = "ViewToolStripMenuItem"
        Me.ViewToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.ViewToolStripMenuItem.Text = "View"
        '
        'LargeIconsToolStripMenuItem
        '
        Me.LargeIconsToolStripMenuItem.CheckOnClick = True
        Me.LargeIconsToolStripMenuItem.Name = "LargeIconsToolStripMenuItem"
        Me.LargeIconsToolStripMenuItem.Size = New System.Drawing.Size(134, 22)
        Me.LargeIconsToolStripMenuItem.Text = "Large Icons"
        '
        'SmallIconsToolStripMenuItem
        '
        Me.SmallIconsToolStripMenuItem.CheckOnClick = True
        Me.SmallIconsToolStripMenuItem.Name = "SmallIconsToolStripMenuItem"
        Me.SmallIconsToolStripMenuItem.Size = New System.Drawing.Size(134, 22)
        Me.SmallIconsToolStripMenuItem.Text = "SmallIcons"
        '
        'ListToolStripMenuItem
        '
        Me.ListToolStripMenuItem.CheckOnClick = True
        Me.ListToolStripMenuItem.Name = "ListToolStripMenuItem"
        Me.ListToolStripMenuItem.Size = New System.Drawing.Size(134, 22)
        Me.ListToolStripMenuItem.Text = "List"
        '
        'DetailsToolStripMenuItem
        '
        Me.DetailsToolStripMenuItem.Checked = True
        Me.DetailsToolStripMenuItem.CheckOnClick = True
        Me.DetailsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.DetailsToolStripMenuItem.Name = "DetailsToolStripMenuItem"
        Me.DetailsToolStripMenuItem.Size = New System.Drawing.Size(134, 22)
        Me.DetailsToolStripMenuItem.Text = "Details"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(131, 6)
        '
        'StatusBarToolStripMenuItem
        '
        Me.StatusBarToolStripMenuItem.Checked = True
        Me.StatusBarToolStripMenuItem.CheckOnClick = True
        Me.StatusBarToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.StatusBarToolStripMenuItem.Name = "StatusBarToolStripMenuItem"
        Me.StatusBarToolStripMenuItem.Size = New System.Drawing.Size(134, 22)
        Me.StatusBarToolStripMenuItem.Text = "Status Bar"
        '
        'ToolsToolStripMenuItem
        '
        Me.ToolsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PropertiesToolStripMenuItem, Me.ToolStripSeparator3, Me.OptionsToolStripMenuItem})
        Me.ToolsToolStripMenuItem.Name = "ToolsToolStripMenuItem"
        Me.ToolsToolStripMenuItem.Size = New System.Drawing.Size(48, 20)
        Me.ToolsToolStripMenuItem.Text = "Tools"
        '
        'PropertiesToolStripMenuItem
        '
        Me.PropertiesToolStripMenuItem.Name = "PropertiesToolStripMenuItem"
        Me.PropertiesToolStripMenuItem.Size = New System.Drawing.Size(136, 22)
        Me.PropertiesToolStripMenuItem.Text = "Properties..."
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(133, 6)
        '
        'OptionsToolStripMenuItem
        '
        Me.OptionsToolStripMenuItem.Name = "OptionsToolStripMenuItem"
        Me.OptionsToolStripMenuItem.Size = New System.Drawing.Size(136, 22)
        Me.OptionsToolStripMenuItem.Text = "Options..."
        '
        'MonitorToolStripMenuItem
        '
        Me.MonitorToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExistingTextToolStripMenuItem, Me.MonitoredTextToolStripMenuItem, Me.ToolStripSeparator6, Me.ExistingWindowsControlsToolStripMenuItem, Me.ToolStripMenuItem4, Me.AddNewWindowTitleToolStripMenuItem, Me.NewWindowTitlesToolStripMenuItem, Me.ToolStripMenuItem5, Me.ActivateGUIMonitorToolStripMenuItem})
        Me.MonitorToolStripMenuItem.Name = "MonitorToolStripMenuItem"
        Me.MonitorToolStripMenuItem.Size = New System.Drawing.Size(84, 20)
        Me.MonitorToolStripMenuItem.Text = "GUI Monitor"
        '
        'ExistingTextToolStripMenuItem
        '
        Me.ExistingTextToolStripMenuItem.Name = "ExistingTextToolStripMenuItem"
        Me.ExistingTextToolStripMenuItem.Size = New System.Drawing.Size(271, 22)
        Me.ExistingTextToolStripMenuItem.Text = "Select Existing Text For Monitoring"
        '
        'MonitoredTextToolStripMenuItem
        '
        Me.MonitoredTextToolStripMenuItem.Name = "MonitoredTextToolStripMenuItem"
        Me.MonitoredTextToolStripMenuItem.Size = New System.Drawing.Size(271, 22)
        Me.MonitoredTextToolStripMenuItem.Text = "Currently Monitored Text..."
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(268, 6)
        '
        'ExistingWindowsControlsToolStripMenuItem
        '
        Me.ExistingWindowsControlsToolStripMenuItem.Name = "ExistingWindowsControlsToolStripMenuItem"
        Me.ExistingWindowsControlsToolStripMenuItem.Size = New System.Drawing.Size(271, 22)
        Me.ExistingWindowsControlsToolStripMenuItem.Text = "Monitor Existing Windows/Controls..."
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        Me.ToolStripMenuItem4.Size = New System.Drawing.Size(268, 6)
        '
        'AddNewWindowTitleToolStripMenuItem
        '
        Me.AddNewWindowTitleToolStripMenuItem.Name = "AddNewWindowTitleToolStripMenuItem"
        Me.AddNewWindowTitleToolStripMenuItem.Size = New System.Drawing.Size(271, 22)
        Me.AddNewWindowTitleToolStripMenuItem.Text = "Monitor For New Window Title..."
        '
        'NewWindowTitlesToolStripMenuItem
        '
        Me.NewWindowTitlesToolStripMenuItem.Name = "NewWindowTitlesToolStripMenuItem"
        Me.NewWindowTitlesToolStripMenuItem.Size = New System.Drawing.Size(271, 22)
        Me.NewWindowTitlesToolStripMenuItem.Text = "New Window Monitoring Details..."
        '
        'ToolStripMenuItem5
        '
        Me.ToolStripMenuItem5.Name = "ToolStripMenuItem5"
        Me.ToolStripMenuItem5.Size = New System.Drawing.Size(268, 6)
        '
        'ActivateGUIMonitorToolStripMenuItem
        '
        Me.ActivateGUIMonitorToolStripMenuItem.CheckOnClick = True
        Me.ActivateGUIMonitorToolStripMenuItem.Name = "ActivateGUIMonitorToolStripMenuItem"
        Me.ActivateGUIMonitorToolStripMenuItem.Size = New System.Drawing.Size(271, 22)
        Me.ActivateGUIMonitorToolStripMenuItem.Text = "Activate GUI Monitor"
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
        Me.sbStatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tslStatus, Me.tslProgressBar, Me.tslProgress})
        Me.sbStatusStrip.Location = New System.Drawing.Point(0, 527)
        Me.sbStatusStrip.Name = "sbStatusStrip"
        Me.sbStatusStrip.Size = New System.Drawing.Size(775, 22)
        Me.sbStatusStrip.TabIndex = 1
        '
        'tslStatus
        '
        Me.tslStatus.Name = "tslStatus"
        Me.tslStatus.Size = New System.Drawing.Size(56, 17)
        Me.tslStatus.Text = "Events: 0 "
        '
        'tslProgressBar
        '
        Me.tslProgressBar.AutoSize = False
        Me.tslProgressBar.Name = "tslProgressBar"
        Me.tslProgressBar.Size = New System.Drawing.Size(100, 16)
        '
        'tslProgress
        '
        Me.tslProgress.Name = "tslProgress"
        Me.tslProgress.Size = New System.Drawing.Size(0, 17)
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
        Me.spMain.Panel1.Controls.Add(Me.btnClickSequence)
        Me.spMain.Panel1.Controls.Add(Me.btnDoubleClick)
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
        Me.spMain.Size = New System.Drawing.Size(775, 503)
        Me.spMain.SplitterDistance = 30
        Me.spMain.TabIndex = 2
        '
        'btnClickSequence
        '
        Me.btnClickSequence.Location = New System.Drawing.Point(165, 4)
        Me.btnClickSequence.Name = "btnClickSequence"
        Me.btnClickSequence.Size = New System.Drawing.Size(75, 23)
        Me.btnClickSequence.TabIndex = 7
        Me.btnClickSequence.Text = "Mult Clicks"
        Me.btnClickSequence.UseVisualStyleBackColor = True
        '
        'btnDoubleClick
        '
        Me.btnDoubleClick.Location = New System.Drawing.Point(84, 4)
        Me.btnDoubleClick.Name = "btnDoubleClick"
        Me.btnDoubleClick.Size = New System.Drawing.Size(75, 23)
        Me.btnDoubleClick.TabIndex = 6
        Me.btnDoubleClick.Text = "Double Click"
        Me.btnDoubleClick.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Enabled = False
        Me.btnCancel.Location = New System.Drawing.Point(593, 4)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 5
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnGo
        '
        Me.btnGo.Location = New System.Drawing.Point(512, 4)
        Me.btnGo.Name = "btnGo"
        Me.btnGo.Size = New System.Drawing.Size(75, 23)
        Me.btnGo.TabIndex = 4
        Me.btnGo.Text = "Go"
        Me.btnGo.UseVisualStyleBackColor = True
        '
        'btnStatic
        '
        Me.btnStatic.Location = New System.Drawing.Point(255, 4)
        Me.btnStatic.Name = "btnStatic"
        Me.btnStatic.Size = New System.Drawing.Size(75, 23)
        Me.btnStatic.TabIndex = 3
        Me.btnStatic.Text = "Static Text..."
        Me.btnStatic.UseVisualStyleBackColor = True
        '
        'btnFile
        '
        Me.btnFile.Location = New System.Drawing.Point(336, 4)
        Me.btnFile.Name = "btnFile"
        Me.btnFile.Size = New System.Drawing.Size(75, 23)
        Me.btnFile.TabIndex = 2
        Me.btnFile.Text = "File..."
        Me.btnFile.UseVisualStyleBackColor = True
        '
        'btnLoop
        '
        Me.btnLoop.Location = New System.Drawing.Point(417, 4)
        Me.btnLoop.Name = "btnLoop"
        Me.btnLoop.Size = New System.Drawing.Size(75, 23)
        Me.btnLoop.TabIndex = 1
        Me.btnLoop.Text = "Loop..."
        Me.btnLoop.UseVisualStyleBackColor = True
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
        Me.spData.Size = New System.Drawing.Size(775, 469)
        Me.spData.SplitterDistance = 258
        Me.spData.TabIndex = 0
        '
        'tvEvent
        '
        Me.tvEvent.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tvEvent.ImageIndex = 0
        Me.tvEvent.ImageList = Me.ilSmall
        Me.tvEvent.Location = New System.Drawing.Point(0, 0)
        Me.tvEvent.Name = "tvEvent"
        Me.tvEvent.SelectedImageIndex = 5
        Me.tvEvent.Size = New System.Drawing.Size(258, 469)
        Me.tvEvent.TabIndex = 0
        '
        'ilSmall
        '
        Me.ilSmall.ImageStream = CType(resources.GetObject("ilSmall.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ilSmall.TransparentColor = System.Drawing.Color.Transparent
        Me.ilSmall.Images.SetKeyName(0, "imgClick")
        Me.ilSmall.Images.SetKeyName(1, "imgLoop")
        Me.ilSmall.Images.SetKeyName(2, "imgFile")
        Me.ilSmall.Images.SetKeyName(3, "imgText")
        Me.ilSmall.Images.SetKeyName(4, "imgHome")
        Me.ilSmall.Images.SetKeyName(5, "imgSelected")
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
        Me.spDetails.Size = New System.Drawing.Size(513, 469)
        Me.spDetails.SplitterDistance = 199
        Me.spDetails.TabIndex = 0
        '
        'lvDetail
        '
        Me.lvDetail.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.chName, Me.chType, Me.chRepeat, Me.chData})
        Me.lvDetail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvDetail.LargeImageList = Me.ilLarge
        Me.lvDetail.Location = New System.Drawing.Point(0, 0)
        Me.lvDetail.Name = "lvDetail"
        Me.lvDetail.Size = New System.Drawing.Size(513, 199)
        Me.lvDetail.SmallImageList = Me.ilSmall
        Me.lvDetail.TabIndex = 0
        Me.lvDetail.UseCompatibleStateImageBehavior = False
        Me.lvDetail.View = System.Windows.Forms.View.Details
        '
        'chName
        '
        Me.chName.Text = "Name"
        Me.chName.Width = 87
        '
        'chType
        '
        Me.chType.Text = "Type"
        Me.chType.Width = 106
        '
        'chRepeat
        '
        Me.chRepeat.Text = "Repeat"
        '
        'chData
        '
        Me.chData.Text = "Data"
        Me.chData.Width = 378
        '
        'ilLarge
        '
        Me.ilLarge.ImageStream = CType(resources.GetObject("ilLarge.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ilLarge.TransparentColor = System.Drawing.Color.Transparent
        Me.ilLarge.Images.SetKeyName(0, "imgClick")
        Me.ilLarge.Images.SetKeyName(1, "imgLoop")
        Me.ilLarge.Images.SetKeyName(2, "imgFile")
        Me.ilLarge.Images.SetKeyName(3, "imgText")
        '
        'txtLog
        '
        Me.txtLog.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtLog.Location = New System.Drawing.Point(0, 0)
        Me.txtLog.Multiline = True
        Me.txtLog.Name = "txtLog"
        Me.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtLog.Size = New System.Drawing.Size(513, 266)
        Me.txtLog.TabIndex = 0
        '
        'ofdOpenFileDialog
        '
        Me.ofdOpenFileDialog.FileName = "OpenFileDialog1"
        '
        'cmListView
        '
        Me.cmListView.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ContextCutToolStripMenuItem, Me.ContextCopyToolStripMenuItem, Me.ContextPasteToolStripMenuItem, Me.ContextDeleteToolStripMenuItem, Me.ToolStripSeparator4, Me.ContextSelectAllToolStripMenuItem, Me.ToolStripMenuItem9, Me.ContextPropertiesToolStripMenuItem1})
        Me.cmListView.Name = "cmContextMenu"
        Me.cmListView.Size = New System.Drawing.Size(137, 148)
        '
        'ContextCutToolStripMenuItem
        '
        Me.ContextCutToolStripMenuItem.Name = "ContextCutToolStripMenuItem"
        Me.ContextCutToolStripMenuItem.Size = New System.Drawing.Size(136, 22)
        Me.ContextCutToolStripMenuItem.Text = "Cut"
        '
        'ContextCopyToolStripMenuItem
        '
        Me.ContextCopyToolStripMenuItem.Name = "ContextCopyToolStripMenuItem"
        Me.ContextCopyToolStripMenuItem.Size = New System.Drawing.Size(136, 22)
        Me.ContextCopyToolStripMenuItem.Text = "Copy"
        '
        'ContextPasteToolStripMenuItem
        '
        Me.ContextPasteToolStripMenuItem.Name = "ContextPasteToolStripMenuItem"
        Me.ContextPasteToolStripMenuItem.Size = New System.Drawing.Size(136, 22)
        Me.ContextPasteToolStripMenuItem.Text = "Paste"
        '
        'ContextDeleteToolStripMenuItem
        '
        Me.ContextDeleteToolStripMenuItem.Name = "ContextDeleteToolStripMenuItem"
        Me.ContextDeleteToolStripMenuItem.Size = New System.Drawing.Size(136, 22)
        Me.ContextDeleteToolStripMenuItem.Text = "Delete"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(133, 6)
        '
        'ContextSelectAllToolStripMenuItem
        '
        Me.ContextSelectAllToolStripMenuItem.Name = "ContextSelectAllToolStripMenuItem"
        Me.ContextSelectAllToolStripMenuItem.Size = New System.Drawing.Size(136, 22)
        Me.ContextSelectAllToolStripMenuItem.Text = "Select All"
        '
        'ToolStripMenuItem9
        '
        Me.ToolStripMenuItem9.Name = "ToolStripMenuItem9"
        Me.ToolStripMenuItem9.Size = New System.Drawing.Size(133, 6)
        '
        'ContextPropertiesToolStripMenuItem1
        '
        Me.ContextPropertiesToolStripMenuItem1.Name = "ContextPropertiesToolStripMenuItem1"
        Me.ContextPropertiesToolStripMenuItem1.Size = New System.Drawing.Size(136, 22)
        Me.ContextPropertiesToolStripMenuItem1.Text = "Properties..."
        '
        'cmTreeView
        '
        Me.cmTreeView.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TreeCutToolStripMenuItem, Me.TreeCopyToolStripMenuItem, Me.TreePasteToolStripMenuItem, Me.TreeDeleteToolStripMenuItem, Me.ToolStripSeparator5, Me.TreePropertiesToolStripMenuItem})
        Me.cmTreeView.Name = "cmTreeView"
        Me.cmTreeView.Size = New System.Drawing.Size(137, 120)
        '
        'TreeCutToolStripMenuItem
        '
        Me.TreeCutToolStripMenuItem.Name = "TreeCutToolStripMenuItem"
        Me.TreeCutToolStripMenuItem.Size = New System.Drawing.Size(136, 22)
        Me.TreeCutToolStripMenuItem.Text = "Cut"
        '
        'TreeCopyToolStripMenuItem
        '
        Me.TreeCopyToolStripMenuItem.Name = "TreeCopyToolStripMenuItem"
        Me.TreeCopyToolStripMenuItem.Size = New System.Drawing.Size(136, 22)
        Me.TreeCopyToolStripMenuItem.Text = "Copy"
        '
        'TreePasteToolStripMenuItem
        '
        Me.TreePasteToolStripMenuItem.Name = "TreePasteToolStripMenuItem"
        Me.TreePasteToolStripMenuItem.Size = New System.Drawing.Size(136, 22)
        Me.TreePasteToolStripMenuItem.Text = "Paste"
        '
        'TreeDeleteToolStripMenuItem
        '
        Me.TreeDeleteToolStripMenuItem.Name = "TreeDeleteToolStripMenuItem"
        Me.TreeDeleteToolStripMenuItem.Size = New System.Drawing.Size(136, 22)
        Me.TreeDeleteToolStripMenuItem.Text = "Delete"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(133, 6)
        '
        'TreePropertiesToolStripMenuItem
        '
        Me.TreePropertiesToolStripMenuItem.Name = "TreePropertiesToolStripMenuItem"
        Me.TreePropertiesToolStripMenuItem.Size = New System.Drawing.Size(136, 22)
        Me.TreePropertiesToolStripMenuItem.Text = "Properties..."
        '
        'timTimer
        '
        Me.timTimer.Interval = 10
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(775, 549)
        Me.Controls.Add(Me.spMain)
        Me.Controls.Add(Me.sbStatusStrip)
        Me.Controls.Add(Me.mnuMenuStrip)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.mnuMenuStrip
        Me.MinimumSize = New System.Drawing.Size(530, 50)
        Me.Name = "frmMain"
        Me.Text = "WindowClicker"
        Me.mnuMenuStrip.ResumeLayout(False)
        Me.mnuMenuStrip.PerformLayout()
        Me.sbStatusStrip.ResumeLayout(False)
        Me.sbStatusStrip.PerformLayout()
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
        Me.cmListView.ResumeLayout(False)
        Me.cmTreeView.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub


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
    Friend WithEvents SaveLogToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tslStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tslProgressBar As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents btnDoubleClick As System.Windows.Forms.Button
    Friend WithEvents ToolsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OptionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LargeIconsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SmallIconsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ListToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DetailsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tslProgress As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents chName As System.Windows.Forms.ColumnHeader
    Friend WithEvents chType As System.Windows.Forms.ColumnHeader
    Friend WithEvents chData As System.Windows.Forms.ColumnHeader
    Friend WithEvents chRepeat As System.Windows.Forms.ColumnHeader
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CopyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PasteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SelectAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents FindToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnClickSequence As System.Windows.Forms.Button
    Friend WithEvents PropertiesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmListView As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ContextCutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContextCopyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContextPasteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContextDeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ContextSelectAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem9 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ContextPropertiesToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmTreeView As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents TreeCutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TreeCopyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TreePasteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TreeDeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TreePropertiesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ilSmall As System.Windows.Forms.ImageList
    Friend WithEvents ilLarge As System.Windows.Forms.ImageList
    Friend WithEvents MonitorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExistingWindowsControlsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents NewWindowTitlesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AddNewWindowTitleToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents timTimer As System.Windows.Forms.Timer
    Friend WithEvents ExistingTextToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ActivateGUIMonitorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MonitoredTextToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator

End Class
