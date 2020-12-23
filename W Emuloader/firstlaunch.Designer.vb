<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class firstlaunch
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(firstlaunch))
        Me.picturebox_logo = New System.Windows.Forms.PictureBox()
        Me.picturebox_disclaimer = New System.Windows.Forms.PictureBox()
        Me.btn_next = New System.Windows.Forms.PictureBox()
        Me.panel_logo = New System.Windows.Forms.Panel()
        Me.panel_colourpicker = New System.Windows.Forms.Panel()
        Me.btn_next_2 = New System.Windows.Forms.PictureBox()
        Me.combobox_theme = New System.Windows.Forms.ComboBox()
        Me.picturebox_preview = New System.Windows.Forms.PictureBox()
        Me.panel_conditions = New System.Windows.Forms.Panel()
        Me.richtext_conditions = New System.Windows.Forms.RichTextBox()
        Me.btn_next_3 = New System.Windows.Forms.PictureBox()
        Me.panel_sources = New System.Windows.Forms.Panel()
        Me.btn_wiki = New System.Windows.Forms.PictureBox()
        Me.btn_search = New System.Windows.Forms.PictureBox()
        Me.btn_finish = New System.Windows.Forms.PictureBox()
        CType(Me.picturebox_logo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picturebox_disclaimer, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btn_next, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panel_logo.SuspendLayout()
        Me.panel_colourpicker.SuspendLayout()
        CType(Me.btn_next_2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picturebox_preview, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panel_conditions.SuspendLayout()
        CType(Me.btn_next_3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panel_sources.SuspendLayout()
        CType(Me.btn_wiki, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btn_search, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btn_finish, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'picturebox_logo
        '
        Me.picturebox_logo.BackgroundImage = CType(resources.GetObject("picturebox_logo.BackgroundImage"), System.Drawing.Image)
        Me.picturebox_logo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.picturebox_logo.Location = New System.Drawing.Point(153, 119)
        Me.picturebox_logo.Name = "picturebox_logo"
        Me.picturebox_logo.Size = New System.Drawing.Size(653, 117)
        Me.picturebox_logo.TabIndex = 0
        Me.picturebox_logo.TabStop = False
        '
        'picturebox_disclaimer
        '
        Me.picturebox_disclaimer.BackgroundImage = CType(resources.GetObject("picturebox_disclaimer.BackgroundImage"), System.Drawing.Image)
        Me.picturebox_disclaimer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.picturebox_disclaimer.Location = New System.Drawing.Point(314, 353)
        Me.picturebox_disclaimer.Name = "picturebox_disclaimer"
        Me.picturebox_disclaimer.Size = New System.Drawing.Size(300, 60)
        Me.picturebox_disclaimer.TabIndex = 5
        Me.picturebox_disclaimer.TabStop = False
        '
        'btn_next
        '
        Me.btn_next.BackgroundImage = CType(resources.GetObject("btn_next.BackgroundImage"), System.Drawing.Image)
        Me.btn_next.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btn_next.Location = New System.Drawing.Point(376, 287)
        Me.btn_next.Name = "btn_next"
        Me.btn_next.Size = New System.Drawing.Size(176, 48)
        Me.btn_next.TabIndex = 2
        Me.btn_next.TabStop = False
        '
        'panel_logo
        '
        Me.panel_logo.Controls.Add(Me.btn_next)
        Me.panel_logo.Controls.Add(Me.picturebox_logo)
        Me.panel_logo.Controls.Add(Me.picturebox_disclaimer)
        Me.panel_logo.Location = New System.Drawing.Point(0, 0)
        Me.panel_logo.Name = "panel_logo"
        Me.panel_logo.Size = New System.Drawing.Size(944, 501)
        Me.panel_logo.TabIndex = 6
        '
        'panel_colourpicker
        '
        Me.panel_colourpicker.Controls.Add(Me.btn_next_2)
        Me.panel_colourpicker.Controls.Add(Me.combobox_theme)
        Me.panel_colourpicker.Controls.Add(Me.picturebox_preview)
        Me.panel_colourpicker.Location = New System.Drawing.Point(0, 0)
        Me.panel_colourpicker.Name = "panel_colourpicker"
        Me.panel_colourpicker.Size = New System.Drawing.Size(944, 501)
        Me.panel_colourpicker.TabIndex = 7
        Me.panel_colourpicker.Visible = False
        '
        'btn_next_2
        '
        Me.btn_next_2.BackgroundImage = CType(resources.GetObject("btn_next_2.BackgroundImage"), System.Drawing.Image)
        Me.btn_next_2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btn_next_2.Location = New System.Drawing.Point(756, 441)
        Me.btn_next_2.Name = "btn_next_2"
        Me.btn_next_2.Size = New System.Drawing.Size(176, 48)
        Me.btn_next_2.TabIndex = 11
        Me.btn_next_2.TabStop = False
        '
        'combobox_theme
        '
        Me.combobox_theme.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.combobox_theme.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.combobox_theme.FormattingEnabled = True
        Me.combobox_theme.Items.AddRange(New Object() {"Light", "Dark Blue", "Darker Purple", "Lights Out"})
        Me.combobox_theme.Location = New System.Drawing.Point(364, 452)
        Me.combobox_theme.Name = "combobox_theme"
        Me.combobox_theme.Size = New System.Drawing.Size(216, 28)
        Me.combobox_theme.TabIndex = 10
        '
        'picturebox_preview
        '
        Me.picturebox_preview.BackgroundImage = CType(resources.GetObject("picturebox_preview.BackgroundImage"), System.Drawing.Image)
        Me.picturebox_preview.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.picturebox_preview.Location = New System.Drawing.Point(12, 12)
        Me.picturebox_preview.Name = "picturebox_preview"
        Me.picturebox_preview.Size = New System.Drawing.Size(920, 418)
        Me.picturebox_preview.TabIndex = 9
        Me.picturebox_preview.TabStop = False
        '
        'panel_conditions
        '
        Me.panel_conditions.Controls.Add(Me.richtext_conditions)
        Me.panel_conditions.Controls.Add(Me.btn_next_3)
        Me.panel_conditions.Location = New System.Drawing.Point(0, 0)
        Me.panel_conditions.Name = "panel_conditions"
        Me.panel_conditions.Size = New System.Drawing.Size(944, 501)
        Me.panel_conditions.TabIndex = 12
        Me.panel_conditions.Visible = False
        '
        'richtext_conditions
        '
        Me.richtext_conditions.BackColor = System.Drawing.Color.White
        Me.richtext_conditions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.richtext_conditions.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.richtext_conditions.ForeColor = System.Drawing.Color.Black
        Me.richtext_conditions.Location = New System.Drawing.Point(12, 12)
        Me.richtext_conditions.Name = "richtext_conditions"
        Me.richtext_conditions.ReadOnly = True
        Me.richtext_conditions.Size = New System.Drawing.Size(920, 418)
        Me.richtext_conditions.TabIndex = 12
        Me.richtext_conditions.Text = resources.GetString("richtext_conditions.Text")
        '
        'btn_next_3
        '
        Me.btn_next_3.BackgroundImage = CType(resources.GetObject("btn_next_3.BackgroundImage"), System.Drawing.Image)
        Me.btn_next_3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btn_next_3.Location = New System.Drawing.Point(756, 441)
        Me.btn_next_3.Name = "btn_next_3"
        Me.btn_next_3.Size = New System.Drawing.Size(176, 48)
        Me.btn_next_3.TabIndex = 11
        Me.btn_next_3.TabStop = False
        '
        'panel_sources
        '
        Me.panel_sources.BackgroundImage = CType(resources.GetObject("panel_sources.BackgroundImage"), System.Drawing.Image)
        Me.panel_sources.Controls.Add(Me.btn_wiki)
        Me.panel_sources.Controls.Add(Me.btn_search)
        Me.panel_sources.Controls.Add(Me.btn_finish)
        Me.panel_sources.Location = New System.Drawing.Point(0, 0)
        Me.panel_sources.Name = "panel_sources"
        Me.panel_sources.Size = New System.Drawing.Size(944, 501)
        Me.panel_sources.TabIndex = 13
        Me.panel_sources.Visible = False
        '
        'btn_wiki
        '
        Me.btn_wiki.BackColor = System.Drawing.Color.Transparent
        Me.btn_wiki.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_wiki.Location = New System.Drawing.Point(525, 407)
        Me.btn_wiki.Name = "btn_wiki"
        Me.btn_wiki.Size = New System.Drawing.Size(282, 27)
        Me.btn_wiki.TabIndex = 13
        Me.btn_wiki.TabStop = False
        '
        'btn_search
        '
        Me.btn_search.BackColor = System.Drawing.Color.Transparent
        Me.btn_search.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_search.Location = New System.Drawing.Point(473, 363)
        Me.btn_search.Name = "btn_search"
        Me.btn_search.Size = New System.Drawing.Size(176, 27)
        Me.btn_search.TabIndex = 12
        Me.btn_search.TabStop = False
        '
        'btn_finish
        '
        Me.btn_finish.BackgroundImage = CType(resources.GetObject("btn_finish.BackgroundImage"), System.Drawing.Image)
        Me.btn_finish.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btn_finish.Location = New System.Drawing.Point(756, 441)
        Me.btn_finish.Name = "btn_finish"
        Me.btn_finish.Size = New System.Drawing.Size(176, 48)
        Me.btn_finish.TabIndex = 11
        Me.btn_finish.TabStop = False
        '
        'firstlaunch
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(944, 501)
        Me.Controls.Add(Me.panel_logo)
        Me.Controls.Add(Me.panel_sources)
        Me.Controls.Add(Me.panel_conditions)
        Me.Controls.Add(Me.panel_colourpicker)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "firstlaunch"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.picturebox_logo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picturebox_disclaimer, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btn_next, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panel_logo.ResumeLayout(False)
        Me.panel_colourpicker.ResumeLayout(False)
        CType(Me.btn_next_2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picturebox_preview, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panel_conditions.ResumeLayout(False)
        CType(Me.btn_next_3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panel_sources.ResumeLayout(False)
        CType(Me.btn_wiki, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btn_search, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btn_finish, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents picturebox_logo As PictureBox
    Friend WithEvents picturebox_disclaimer As PictureBox
    Friend WithEvents btn_next As PictureBox
    Friend WithEvents panel_logo As Panel
    Friend WithEvents panel_colourpicker As Panel
    Friend WithEvents combobox_theme As ComboBox
    Friend WithEvents picturebox_preview As PictureBox
    Friend WithEvents btn_next_2 As PictureBox
    Friend WithEvents panel_conditions As Panel
    Friend WithEvents richtext_conditions As RichTextBox
    Friend WithEvents btn_next_3 As PictureBox
    Friend WithEvents panel_sources As Panel
    Friend WithEvents btn_finish As PictureBox
    Friend WithEvents btn_search As PictureBox
    Friend WithEvents btn_wiki As PictureBox
End Class
