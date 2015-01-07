<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTextFields
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
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.lvTextFields = New System.Windows.Forms.ListView()
        Me.chTitle = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chFullTitle = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chPosition = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(484, 418)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 2
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(86, 418)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(75, 23)
        Me.btnDelete.TabIndex = 5
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(5, 418)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(75, 23)
        Me.btnAdd.TabIndex = 4
        Me.btnAdd.Text = "Add..."
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'lvTextFields
        '
        Me.lvTextFields.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.chTitle, Me.chFullTitle, Me.chPosition})
        Me.lvTextFields.Location = New System.Drawing.Point(5, 12)
        Me.lvTextFields.Name = "lvTextFields"
        Me.lvTextFields.Size = New System.Drawing.Size(554, 400)
        Me.lvTextFields.TabIndex = 6
        Me.lvTextFields.UseCompatibleStateImageBehavior = False
        Me.lvTextFields.View = System.Windows.Forms.View.Details
        '
        'chTitle
        '
        Me.chTitle.Text = "ID"
        Me.chTitle.Width = 62
        '
        'chFullTitle
        '
        Me.chFullTitle.Text = "Text"
        Me.chFullTitle.Width = 392
        '
        'chPosition
        '
        Me.chPosition.Text = "Position"
        Me.chPosition.Width = 96
        '
        'frmTextFields
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(564, 446)
        Me.Controls.Add(Me.lvTextFields)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.btnOK)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmTextFields"
        Me.Text = "Monitored Text Fields"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents lvTextFields As System.Windows.Forms.ListView
    Friend WithEvents chTitle As System.Windows.Forms.ColumnHeader
    Friend WithEvents chFullTitle As System.Windows.Forms.ColumnHeader
    Friend WithEvents chPosition As System.Windows.Forms.ColumnHeader
End Class
