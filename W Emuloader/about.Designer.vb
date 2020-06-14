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
        Me.picturebox_logo = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lbl_version = New System.Windows.Forms.Label()
        Me.lbl_website = New System.Windows.Forms.Label()
        Me.lbl_patreon = New System.Windows.Forms.Label()
        Me.picturebox_tungsten = New System.Windows.Forms.PictureBox()
        CType(Me.picturebox_logo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picturebox_tungsten, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'picturebox_logo
        '
        Me.picturebox_logo.BackgroundImage = CType(resources.GetObject("picturebox_logo.BackgroundImage"), System.Drawing.Image)
        Me.picturebox_logo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.picturebox_logo.Location = New System.Drawing.Point(12, 12)
        Me.picturebox_logo.Name = "picturebox_logo"
        Me.picturebox_logo.Size = New System.Drawing.Size(557, 99)
        Me.picturebox_logo.TabIndex = 1
        Me.picturebox_logo.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(784, 180)
        Me.PictureBox1.TabIndex = 2
        Me.PictureBox1.TabStop = False
        '
        'lbl_version
        '
        Me.lbl_version.AutoSize = True
        Me.lbl_version.Location = New System.Drawing.Point(21, 114)
        Me.lbl_version.Name = "lbl_version"
        Me.lbl_version.Size = New System.Drawing.Size(68, 13)
        Me.lbl_version.TabIndex = 3
        Me.lbl_version.Text = "version 1.0.0"
        '
        'lbl_website
        '
        Me.lbl_website.AutoSize = True
        Me.lbl_website.Location = New System.Drawing.Point(21, 140)
        Me.lbl_website.Name = "lbl_website"
        Me.lbl_website.Size = New System.Drawing.Size(151, 13)
        Me.lbl_website.TabIndex = 4
        Me.lbl_website.Text = "Go to https://parthkataria.com"
        '
        'lbl_patreon
        '
        Me.lbl_patreon.AutoSize = True
        Me.lbl_patreon.Location = New System.Drawing.Point(21, 167)
        Me.lbl_patreon.Name = "lbl_patreon"
        Me.lbl_patreon.Size = New System.Drawing.Size(72, 13)
        Me.lbl_patreon.TabIndex = 5
        Me.lbl_patreon.Text = "Go to patreon"
        '
        'picturebox_tungsten
        '
        Me.picturebox_tungsten.BackgroundImage = CType(resources.GetObject("picturebox_tungsten.BackgroundImage"), System.Drawing.Image)
        Me.picturebox_tungsten.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.picturebox_tungsten.Location = New System.Drawing.Point(672, 12)
        Me.picturebox_tungsten.Name = "picturebox_tungsten"
        Me.picturebox_tungsten.Size = New System.Drawing.Size(100, 100)
        Me.picturebox_tungsten.TabIndex = 6
        Me.picturebox_tungsten.TabStop = False
        '
        'about
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(784, 211)
        Me.Controls.Add(Me.picturebox_tungsten)
        Me.Controls.Add(Me.lbl_patreon)
        Me.Controls.Add(Me.lbl_website)
        Me.Controls.Add(Me.lbl_version)
        Me.Controls.Add(Me.picturebox_logo)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "about"
        Me.Text = "About Emuloader"
        CType(Me.picturebox_logo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picturebox_tungsten, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents picturebox_logo As PictureBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents lbl_version As Label
    Friend WithEvents lbl_website As Label
    Friend WithEvents lbl_patreon As Label
    Friend WithEvents picturebox_tungsten As PictureBox
End Class
