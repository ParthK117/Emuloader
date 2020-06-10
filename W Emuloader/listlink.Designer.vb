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
        Me.textbox_url = New System.Windows.Forms.TextBox()
        Me.btn_import = New System.Windows.Forms.PictureBox()
        CType(Me.btn_import, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'textbox_url
        '
        Me.textbox_url.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textbox_url.Location = New System.Drawing.Point(3, 4)
        Me.textbox_url.Multiline = True
        Me.textbox_url.Name = "textbox_url"
        Me.textbox_url.Size = New System.Drawing.Size(499, 161)
        Me.textbox_url.TabIndex = 0
        Me.textbox_url.WordWrap = False
        '
        'btn_import
        '
        Me.btn_import.BackgroundImage = CType(resources.GetObject("btn_import.BackgroundImage"), System.Drawing.Image)
        Me.btn_import.Location = New System.Drawing.Point(402, 171)
        Me.btn_import.Name = "btn_import"
        Me.btn_import.Size = New System.Drawing.Size(100, 38)
        Me.btn_import.TabIndex = 1
        Me.btn_import.TabStop = False
        '
        'listlink
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(504, 212)
        Me.Controls.Add(Me.btn_import)
        Me.Controls.Add(Me.textbox_url)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "listlink"
        Me.Text = "Import from link (one per line)"
        CType(Me.btn_import, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents textbox_url As TextBox
    Friend WithEvents btn_import As PictureBox
End Class
