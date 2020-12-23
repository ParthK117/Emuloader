<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class about
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(about))
        Me.lbl_version = New System.Windows.Forms.Label()
        Me.lbl_website = New System.Windows.Forms.Label()
        Me.lbl_patreon = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lbl_version
        '
        Me.lbl_version.BackColor = System.Drawing.Color.Transparent
        Me.lbl_version.ForeColor = System.Drawing.Color.White
        Me.lbl_version.Location = New System.Drawing.Point(709, 9)
        Me.lbl_version.Name = "lbl_version"
        Me.lbl_version.Size = New System.Drawing.Size(178, 53)
        Me.lbl_version.TabIndex = 3
        Me.lbl_version.Text = "version 1.0.0"
        Me.lbl_version.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lbl_website
        '
        Me.lbl_website.BackColor = System.Drawing.Color.Transparent
        Me.lbl_website.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lbl_website.Location = New System.Drawing.Point(731, 508)
        Me.lbl_website.Name = "lbl_website"
        Me.lbl_website.Size = New System.Drawing.Size(156, 22)
        Me.lbl_website.TabIndex = 4
        '
        'lbl_patreon
        '
        Me.lbl_patreon.BackColor = System.Drawing.Color.Transparent
        Me.lbl_patreon.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lbl_patreon.Location = New System.Drawing.Point(670, 435)
        Me.lbl_patreon.Name = "lbl_patreon"
        Me.lbl_patreon.Size = New System.Drawing.Size(217, 21)
        Me.lbl_patreon.TabIndex = 5
        '
        'about
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(899, 539)
        Me.Controls.Add(Me.lbl_patreon)
        Me.Controls.Add(Me.lbl_website)
        Me.Controls.Add(Me.lbl_version)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "about"
        Me.Text = "About Emuloader"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lbl_version As Label
    Friend WithEvents lbl_website As Label
    Friend WithEvents lbl_patreon As Label
End Class
