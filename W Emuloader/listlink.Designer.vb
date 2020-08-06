<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class listlink
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(listlink))
        Me.btn_import = New System.Windows.Forms.PictureBox()
        Me.textbox_url = New System.Windows.Forms.RichTextBox()
        Me.lbl_disclaimer = New System.Windows.Forms.Label()
        CType(Me.btn_import, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btn_import
        '
        Me.btn_import.BackgroundImage = CType(resources.GetObject("btn_import.BackgroundImage"), System.Drawing.Image)
        Me.btn_import.Location = New System.Drawing.Point(402, 174)
        Me.btn_import.Name = "btn_import"
        Me.btn_import.Size = New System.Drawing.Size(100, 36)
        Me.btn_import.TabIndex = 1
        Me.btn_import.TabStop = False
        '
        'textbox_url
        '
        Me.textbox_url.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.textbox_url.Location = New System.Drawing.Point(3, 4)
        Me.textbox_url.Name = "textbox_url"
        Me.textbox_url.Size = New System.Drawing.Size(499, 157)
        Me.textbox_url.TabIndex = 2
        Me.textbox_url.Text = ""
        '
        'lbl_disclaimer
        '
        Me.lbl_disclaimer.AutoSize = True
        Me.lbl_disclaimer.Location = New System.Drawing.Point(12, 164)
        Me.lbl_disclaimer.Name = "lbl_disclaimer"
        Me.lbl_disclaimer.Size = New System.Drawing.Size(259, 52)
        Me.lbl_disclaimer.TabIndex = 3
        Me.lbl_disclaimer.Text = resources.GetString("lbl_disclaimer.Text")
        '
        'listlink
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(504, 220)
        Me.Controls.Add(Me.lbl_disclaimer)
        Me.Controls.Add(Me.textbox_url)
        Me.Controls.Add(Me.btn_import)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "listlink"
        Me.Text = "Import from link (one per line)"
        CType(Me.btn_import, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btn_import As PictureBox
    Friend WithEvents textbox_url As RichTextBox
    Friend WithEvents lbl_disclaimer As Label
End Class
