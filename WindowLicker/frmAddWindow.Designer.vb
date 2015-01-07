<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAddWindow
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAddWindow))
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.txtWindow = New System.Windows.Forms.TextBox()
        Me.gbSearch = New System.Windows.Forms.GroupBox()
        Me.rbPartial = New System.Windows.Forms.RadioButton()
        Me.rbFull = New System.Windows.Forms.RadioButton()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.gbSearch.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Location = New System.Drawing.Point(2, 11)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(72, 13)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "Window Title:"
        '
        'txtWindow
        '
        Me.txtWindow.Location = New System.Drawing.Point(78, 8)
        Me.txtWindow.Name = "txtWindow"
        Me.txtWindow.Size = New System.Drawing.Size(343, 20)
        Me.txtWindow.TabIndex = 1
        '
        'gbSearch
        '
        Me.gbSearch.Controls.Add(Me.rbPartial)
        Me.gbSearch.Controls.Add(Me.rbFull)
        Me.gbSearch.Location = New System.Drawing.Point(5, 34)
        Me.gbSearch.Name = "gbSearch"
        Me.gbSearch.Size = New System.Drawing.Size(239, 69)
        Me.gbSearch.TabIndex = 3
        Me.gbSearch.TabStop = False
        Me.gbSearch.Text = "Search Type"
        '
        'rbPartial
        '
        Me.rbPartial.AutoSize = True
        Me.rbPartial.Location = New System.Drawing.Point(7, 41)
        Me.rbPartial.Name = "rbPartial"
        Me.rbPartial.Size = New System.Drawing.Size(202, 17)
        Me.rbPartial.TabIndex = 1
        Me.rbPartial.TabStop = True
        Me.rbPartial.Text = "Window Title Contains Specified Text"
        Me.rbPartial.UseVisualStyleBackColor = True
        '
        'rbFull
        '
        Me.rbFull.AutoSize = True
        Me.rbFull.Checked = True
        Me.rbFull.Location = New System.Drawing.Point(7, 20)
        Me.rbFull.Name = "rbFull"
        Me.rbFull.Size = New System.Drawing.Size(139, 17)
        Me.rbFull.TabIndex = 0
        Me.rbFull.TabStop = True
        Me.rbFull.Text = "Match Full Window Title"
        Me.rbFull.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(264, 80)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 5
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(346, 80)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 4
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'frmAddWindow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(430, 116)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.gbSearch)
        Me.Controls.Add(Me.txtWindow)
        Me.Controls.Add(Me.lblTitle)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAddWindow"
        Me.Text = "Monitor For New Window"
        Me.gbSearch.ResumeLayout(False)
        Me.gbSearch.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents txtWindow As System.Windows.Forms.TextBox
    Friend WithEvents gbSearch As System.Windows.Forms.GroupBox
    Friend WithEvents rbPartial As System.Windows.Forms.RadioButton
    Friend WithEvents rbFull As System.Windows.Forms.RadioButton
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
End Class
