<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNewWindows
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmNewWindows))
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.lvNewWindow = New System.Windows.Forms.ListView()
        Me.chTitle = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chFullTitle = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.SuspendLayout()
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(5, 405)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(75, 23)
        Me.btnAdd.TabIndex = 0
        Me.btnAdd.Text = "Add..."
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(306, 404)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 1
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(86, 405)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(75, 23)
        Me.btnDelete.TabIndex = 3
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'lvNewWindow
        '
        Me.lvNewWindow.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.chTitle, Me.chFullTitle})
        Me.lvNewWindow.Location = New System.Drawing.Point(5, 5)
        Me.lvNewWindow.Name = "lvNewWindow"
        Me.lvNewWindow.Size = New System.Drawing.Size(377, 394)
        Me.lvNewWindow.TabIndex = 4
        Me.lvNewWindow.UseCompatibleStateImageBehavior = False
        Me.lvNewWindow.View = System.Windows.Forms.View.Details
        '
        'chTitle
        '
        Me.chTitle.Text = "Window Title"
        Me.chTitle.Width = 264
        '
        'chFullTitle
        '
        Me.chFullTitle.Text = "Match Full Title?"
        Me.chFullTitle.Width = 107
        '
        'frmNewWindows
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(386, 432)
        Me.Controls.Add(Me.lvNewWindow)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnAdd)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmNewWindows"
        Me.Text = "New Window Monitor"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents lvNewWindow As System.Windows.Forms.ListView
    Friend WithEvents chTitle As System.Windows.Forms.ColumnHeader
    Friend WithEvents chFullTitle As System.Windows.Forms.ColumnHeader
End Class
