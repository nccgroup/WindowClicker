<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCurrentWindows
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCurrentWindows))
        Me.spMain = New System.Windows.Forms.SplitContainer()
        Me.spWindows = New System.Windows.Forms.SplitContainer()
        Me.tvWindows = New System.Windows.Forms.TreeView()
        Me.ilControls = New System.Windows.Forms.ImageList(Me.components)
        Me.lvWindows = New System.Windows.Forms.ListView()
        Me.chHwnd = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chControlType = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chText = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        CType(Me.spMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.spMain.Panel1.SuspendLayout()
        Me.spMain.Panel2.SuspendLayout()
        Me.spMain.SuspendLayout()
        CType(Me.spWindows, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.spWindows.Panel1.SuspendLayout()
        Me.spWindows.Panel2.SuspendLayout()
        Me.spWindows.SuspendLayout()
        Me.SuspendLayout()
        '
        'spMain
        '
        Me.spMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.spMain.IsSplitterFixed = True
        Me.spMain.Location = New System.Drawing.Point(0, 0)
        Me.spMain.Name = "spMain"
        Me.spMain.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'spMain.Panel1
        '
        Me.spMain.Panel1.Controls.Add(Me.spWindows)
        '
        'spMain.Panel2
        '
        Me.spMain.Panel2.Controls.Add(Me.btnRefresh)
        Me.spMain.Panel2.Controls.Add(Me.btnOK)
        Me.spMain.Panel2.Controls.Add(Me.btnCancel)
        Me.spMain.Size = New System.Drawing.Size(880, 546)
        Me.spMain.SplitterDistance = 517
        Me.spMain.TabIndex = 0
        '
        'spWindows
        '
        Me.spWindows.Dock = System.Windows.Forms.DockStyle.Fill
        Me.spWindows.Location = New System.Drawing.Point(0, 0)
        Me.spWindows.Name = "spWindows"
        '
        'spWindows.Panel1
        '
        Me.spWindows.Panel1.Controls.Add(Me.tvWindows)
        '
        'spWindows.Panel2
        '
        Me.spWindows.Panel2.Controls.Add(Me.lvWindows)
        Me.spWindows.Size = New System.Drawing.Size(880, 517)
        Me.spWindows.SplitterDistance = 293
        Me.spWindows.TabIndex = 0
        '
        'tvWindows
        '
        Me.tvWindows.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tvWindows.ImageIndex = 0
        Me.tvWindows.ImageList = Me.ilControls
        Me.tvWindows.Location = New System.Drawing.Point(0, 0)
        Me.tvWindows.Name = "tvWindows"
        Me.tvWindows.SelectedImageIndex = 0
        Me.tvWindows.Size = New System.Drawing.Size(293, 517)
        Me.tvWindows.TabIndex = 0
        '
        'ilControls
        '
        Me.ilControls.ImageStream = CType(resources.GetObject("ilControls.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ilControls.TransparentColor = System.Drawing.Color.Transparent
        Me.ilControls.Images.SetKeyName(0, "Computer.png")
        Me.ilControls.Images.SetKeyName(1, "AppWindowHS.bmp")
        Me.ilControls.Images.SetKeyName(2, "ThumbnailView.png")
        '
        'lvWindows
        '
        Me.lvWindows.CheckBoxes = True
        Me.lvWindows.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.chHwnd, Me.chControlType, Me.chName, Me.chText})
        Me.lvWindows.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvWindows.Location = New System.Drawing.Point(0, 0)
        Me.lvWindows.Name = "lvWindows"
        Me.lvWindows.Size = New System.Drawing.Size(583, 517)
        Me.lvWindows.TabIndex = 0
        Me.lvWindows.UseCompatibleStateImageBehavior = False
        Me.lvWindows.View = System.Windows.Forms.View.Details
        '
        'chHwnd
        '
        Me.chHwnd.Text = "hWnd"
        Me.chHwnd.Width = 85
        '
        'chControlType
        '
        Me.chControlType.Text = "Control Type"
        Me.chControlType.Width = 122
        '
        'chName
        '
        Me.chName.Text = "Name"
        Me.chName.Width = 111
        '
        'chText
        '
        Me.chText.Text = "Text"
        Me.chText.Width = 308
        '
        'btnRefresh
        '
        Me.btnRefresh.Location = New System.Drawing.Point(5, 1)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(75, 23)
        Me.btnRefresh.TabIndex = 2
        Me.btnRefresh.Text = "Refresh"
        Me.btnRefresh.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(720, 1)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 1
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(800, 1)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 0
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'frmCurrentWindows
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(880, 546)
        Me.Controls.Add(Me.spMain)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmCurrentWindows"
        Me.Text = "Current Windows"
        Me.spMain.Panel1.ResumeLayout(False)
        Me.spMain.Panel2.ResumeLayout(False)
        CType(Me.spMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.spMain.ResumeLayout(False)
        Me.spWindows.Panel1.ResumeLayout(False)
        Me.spWindows.Panel2.ResumeLayout(False)
        CType(Me.spWindows, System.ComponentModel.ISupportInitialize).EndInit()
        Me.spWindows.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents spMain As System.Windows.Forms.SplitContainer
    Friend WithEvents spWindows As System.Windows.Forms.SplitContainer
    Friend WithEvents tvWindows As System.Windows.Forms.TreeView
    Friend WithEvents lvWindows As System.Windows.Forms.ListView
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents chHwnd As System.Windows.Forms.ColumnHeader
    Friend WithEvents chControlType As System.Windows.Forms.ColumnHeader
    Friend WithEvents chText As System.Windows.Forms.ColumnHeader
    Friend WithEvents ilControls As System.Windows.Forms.ImageList
    Friend WithEvents btnRefresh As System.Windows.Forms.Button
    Friend WithEvents chName As System.Windows.Forms.ColumnHeader
End Class
