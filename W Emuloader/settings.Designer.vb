<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class settings
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(settings))
        Me.load_boxart_on_startup = New System.Windows.Forms.CheckBox()
        Me.btn_save = New System.Windows.Forms.PictureBox()
        Me.listbox_settings = New System.Windows.Forms.ListBox()
        Me.panel_general = New System.Windows.Forms.Panel()
        Me.checkbox_hoarder = New System.Windows.Forms.CheckBox()
        Me.checkbox_offline = New System.Windows.Forms.CheckBox()
        Me.combobox_boxart_method = New System.Windows.Forms.ComboBox()
        Me.checkbox_affiliate = New System.Windows.Forms.CheckBox()
        Me.combobox_provider = New System.Windows.Forms.ComboBox()
        Me.lbl_provider = New System.Windows.Forms.Label()
        Me.checkbox_topbar = New System.Windows.Forms.CheckBox()
        Me.checkbox_exit_on_taskbar = New System.Windows.Forms.CheckBox()
        Me.lbl_settingstitle = New System.Windows.Forms.Label()
        Me.panel_appearance = New System.Windows.Forms.Panel()
        Me.picturebox_wave = New System.Windows.Forms.PictureBox()
        Me.checkbox_fancy = New System.Windows.Forms.CheckBox()
        Me.panel_updates = New System.Windows.Forms.Panel()
        Me.checkbox_autoupdate = New System.Windows.Forms.CheckBox()
        Me.panel_delivery = New System.Windows.Forms.Panel()
        Me.checkbox_delivery = New System.Windows.Forms.CheckBox()
        Me.panel_theme = New System.Windows.Forms.Panel()
        Me.combobox_theme = New System.Windows.Forms.ComboBox()
        Me.load_skin = New System.Windows.Forms.CheckBox()
        Me.picturebox_preview = New System.Windows.Forms.PictureBox()
        CType(Me.btn_save, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panel_general.SuspendLayout()
        Me.panel_appearance.SuspendLayout()
        CType(Me.picturebox_wave, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panel_updates.SuspendLayout()
        Me.panel_delivery.SuspendLayout()
        Me.panel_theme.SuspendLayout()
        CType(Me.picturebox_preview, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'load_boxart_on_startup
        '
        Me.load_boxart_on_startup.AutoSize = True
        Me.load_boxart_on_startup.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.load_boxart_on_startup.Location = New System.Drawing.Point(12, 13)
        Me.load_boxart_on_startup.Name = "load_boxart_on_startup"
        Me.load_boxart_on_startup.Size = New System.Drawing.Size(365, 28)
        Me.load_boxart_on_startup.TabIndex = 0
        Me.load_boxart_on_startup.Text = "Download boxart automatically if missing"
        Me.load_boxart_on_startup.UseVisualStyleBackColor = True
        '
        'btn_save
        '
        Me.btn_save.BackgroundImage = CType(resources.GetObject("btn_save.BackgroundImage"), System.Drawing.Image)
        Me.btn_save.Location = New System.Drawing.Point(733, 438)
        Me.btn_save.Name = "btn_save"
        Me.btn_save.Size = New System.Drawing.Size(176, 48)
        Me.btn_save.TabIndex = 1
        Me.btn_save.TabStop = False
        '
        'listbox_settings
        '
        Me.listbox_settings.FormattingEnabled = True
        Me.listbox_settings.Items.AddRange(New Object() {"General", "Theme", "Appearance", "Updates"})
        Me.listbox_settings.Location = New System.Drawing.Point(12, 12)
        Me.listbox_settings.Name = "listbox_settings"
        Me.listbox_settings.Size = New System.Drawing.Size(201, 472)
        Me.listbox_settings.TabIndex = 5
        '
        'panel_general
        '
        Me.panel_general.Controls.Add(Me.checkbox_hoarder)
        Me.panel_general.Controls.Add(Me.checkbox_offline)
        Me.panel_general.Controls.Add(Me.combobox_boxart_method)
        Me.panel_general.Controls.Add(Me.checkbox_affiliate)
        Me.panel_general.Controls.Add(Me.combobox_provider)
        Me.panel_general.Controls.Add(Me.lbl_provider)
        Me.panel_general.Controls.Add(Me.checkbox_topbar)
        Me.panel_general.Controls.Add(Me.checkbox_exit_on_taskbar)
        Me.panel_general.Controls.Add(Me.load_boxart_on_startup)
        Me.panel_general.Location = New System.Drawing.Point(220, 60)
        Me.panel_general.Name = "panel_general"
        Me.panel_general.Size = New System.Drawing.Size(689, 372)
        Me.panel_general.TabIndex = 6
        '
        'checkbox_hoarder
        '
        Me.checkbox_hoarder.AutoSize = True
        Me.checkbox_hoarder.Font = New System.Drawing.Font("Aileron", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.checkbox_hoarder.Location = New System.Drawing.Point(12, 326)
        Me.checkbox_hoarder.Name = "checkbox_hoarder"
        Me.checkbox_hoarder.Size = New System.Drawing.Size(191, 27)
        Me.checkbox_hoarder.TabIndex = 8
        Me.checkbox_hoarder.Text = "Data hoarder mode"
        Me.checkbox_hoarder.UseVisualStyleBackColor = True
        '
        'checkbox_offline
        '
        Me.checkbox_offline.AutoSize = True
        Me.checkbox_offline.Font = New System.Drawing.Font("Aileron", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.checkbox_offline.Location = New System.Drawing.Point(12, 295)
        Me.checkbox_offline.Name = "checkbox_offline"
        Me.checkbox_offline.Size = New System.Drawing.Size(138, 27)
        Me.checkbox_offline.TabIndex = 7
        Me.checkbox_offline.Text = "Offline mode"
        Me.checkbox_offline.UseVisualStyleBackColor = True
        '
        'combobox_boxart_method
        '
        Me.combobox_boxart_method.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.combobox_boxart_method.FormattingEnabled = True
        Me.combobox_boxart_method.Items.AddRange(New Object() {"Download Boxart per game.", "Download all Boxart for platform."})
        Me.combobox_boxart_method.Location = New System.Drawing.Point(12, 49)
        Me.combobox_boxart_method.Name = "combobox_boxart_method"
        Me.combobox_boxart_method.Size = New System.Drawing.Size(330, 21)
        Me.combobox_boxart_method.TabIndex = 6
        '
        'checkbox_affiliate
        '
        Me.checkbox_affiliate.AutoSize = True
        Me.checkbox_affiliate.Font = New System.Drawing.Font("Aileron", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.checkbox_affiliate.Location = New System.Drawing.Point(12, 262)
        Me.checkbox_affiliate.Name = "checkbox_affiliate"
        Me.checkbox_affiliate.Size = New System.Drawing.Size(581, 27)
        Me.checkbox_affiliate.TabIndex = 5
        Me.checkbox_affiliate.Text = "Use our affiliate code when possible (help support development!)"
        Me.checkbox_affiliate.UseVisualStyleBackColor = True
        '
        'combobox_provider
        '
        Me.combobox_provider.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.combobox_provider.FormattingEnabled = True
        Me.combobox_provider.Items.AddRange(New Object() {"Google Shopping", "Amazon.com", "Amazon UK", "Ebay.com", "Ebay UK"})
        Me.combobox_provider.Location = New System.Drawing.Point(12, 221)
        Me.combobox_provider.Name = "combobox_provider"
        Me.combobox_provider.Size = New System.Drawing.Size(218, 21)
        Me.combobox_provider.TabIndex = 4
        '
        'lbl_provider
        '
        Me.lbl_provider.AutoSize = True
        Me.lbl_provider.Location = New System.Drawing.Point(9, 188)
        Me.lbl_provider.Name = "lbl_provider"
        Me.lbl_provider.Size = New System.Drawing.Size(221, 13)
        Me.lbl_provider.TabIndex = 3
        Me.lbl_provider.Text = "Search provider for buying physical and OST:"
        '
        'checkbox_topbar
        '
        Me.checkbox_topbar.AutoSize = True
        Me.checkbox_topbar.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.checkbox_topbar.Location = New System.Drawing.Point(12, 147)
        Me.checkbox_topbar.Name = "checkbox_topbar"
        Me.checkbox_topbar.Size = New System.Drawing.Size(241, 28)
        Me.checkbox_topbar.TabIndex = 2
        Me.checkbox_topbar.Text = "Use windows style topbar"
        Me.checkbox_topbar.UseVisualStyleBackColor = True
        '
        'checkbox_exit_on_taskbar
        '
        Me.checkbox_exit_on_taskbar.AutoSize = True
        Me.checkbox_exit_on_taskbar.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.checkbox_exit_on_taskbar.Location = New System.Drawing.Point(12, 85)
        Me.checkbox_exit_on_taskbar.Name = "checkbox_exit_on_taskbar"
        Me.checkbox_exit_on_taskbar.Size = New System.Drawing.Size(391, 52)
        Me.checkbox_exit_on_taskbar.TabIndex = 1
        Me.checkbox_exit_on_taskbar.Text = "Checked: Pressing 'X' moves to taskbar" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Unchecked: Pressing 'X' closes emuloader"
        Me.checkbox_exit_on_taskbar.UseVisualStyleBackColor = True
        '
        'lbl_settingstitle
        '
        Me.lbl_settingstitle.AutoSize = True
        Me.lbl_settingstitle.Font = New System.Drawing.Font("Gotham Bold", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_settingstitle.Location = New System.Drawing.Point(219, 12)
        Me.lbl_settingstitle.Name = "lbl_settingstitle"
        Me.lbl_settingstitle.Size = New System.Drawing.Size(165, 44)
        Me.lbl_settingstitle.TabIndex = 7
        Me.lbl_settingstitle.Text = "General"
        '
        'panel_appearance
        '
        Me.panel_appearance.Controls.Add(Me.picturebox_wave)
        Me.panel_appearance.Controls.Add(Me.checkbox_fancy)
        Me.panel_appearance.Location = New System.Drawing.Point(220, 60)
        Me.panel_appearance.Name = "panel_appearance"
        Me.panel_appearance.Size = New System.Drawing.Size(689, 372)
        Me.panel_appearance.TabIndex = 8
        '
        'picturebox_wave
        '
        Me.picturebox_wave.BackgroundImage = CType(resources.GetObject("picturebox_wave.BackgroundImage"), System.Drawing.Image)
        Me.picturebox_wave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.picturebox_wave.Location = New System.Drawing.Point(12, 47)
        Me.picturebox_wave.Name = "picturebox_wave"
        Me.picturebox_wave.Size = New System.Drawing.Size(567, 109)
        Me.picturebox_wave.TabIndex = 6
        Me.picturebox_wave.TabStop = False
        '
        'checkbox_fancy
        '
        Me.checkbox_fancy.AutoSize = True
        Me.checkbox_fancy.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.checkbox_fancy.Location = New System.Drawing.Point(7, 5)
        Me.checkbox_fancy.Name = "checkbox_fancy"
        Me.checkbox_fancy.Size = New System.Drawing.Size(417, 28)
        Me.checkbox_fancy.TabIndex = 5
        Me.checkbox_fancy.Text = "Fancy download animations (80MB download)"
        Me.checkbox_fancy.UseVisualStyleBackColor = True
        '
        'panel_updates
        '
        Me.panel_updates.Controls.Add(Me.checkbox_autoupdate)
        Me.panel_updates.Location = New System.Drawing.Point(220, 60)
        Me.panel_updates.Name = "panel_updates"
        Me.panel_updates.Size = New System.Drawing.Size(689, 372)
        Me.panel_updates.TabIndex = 9
        '
        'checkbox_autoupdate
        '
        Me.checkbox_autoupdate.AutoSize = True
        Me.checkbox_autoupdate.Location = New System.Drawing.Point(12, 13)
        Me.checkbox_autoupdate.Name = "checkbox_autoupdate"
        Me.checkbox_autoupdate.Size = New System.Drawing.Size(163, 17)
        Me.checkbox_autoupdate.TabIndex = 0
        Me.checkbox_autoupdate.Text = "Check for updates on startup"
        Me.checkbox_autoupdate.UseVisualStyleBackColor = True
        '
        'panel_delivery
        '
        Me.panel_delivery.Controls.Add(Me.checkbox_delivery)
        Me.panel_delivery.Location = New System.Drawing.Point(220, 60)
        Me.panel_delivery.Name = "panel_delivery"
        Me.panel_delivery.Size = New System.Drawing.Size(689, 372)
        Me.panel_delivery.TabIndex = 10
        '
        'checkbox_delivery
        '
        Me.checkbox_delivery.AutoSize = True
        Me.checkbox_delivery.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.checkbox_delivery.Location = New System.Drawing.Point(12, 13)
        Me.checkbox_delivery.Name = "checkbox_delivery"
        Me.checkbox_delivery.Size = New System.Drawing.Size(219, 28)
        Me.checkbox_delivery.TabIndex = 1
        Me.checkbox_delivery.Text = "Enable Instant Delivery"
        Me.checkbox_delivery.UseVisualStyleBackColor = True
        '
        'panel_theme
        '
        Me.panel_theme.Controls.Add(Me.combobox_theme)
        Me.panel_theme.Controls.Add(Me.load_skin)
        Me.panel_theme.Controls.Add(Me.picturebox_preview)
        Me.panel_theme.Location = New System.Drawing.Point(220, 60)
        Me.panel_theme.Name = "panel_theme"
        Me.panel_theme.Size = New System.Drawing.Size(689, 372)
        Me.panel_theme.TabIndex = 12
        '
        'combobox_theme
        '
        Me.combobox_theme.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.combobox_theme.FormattingEnabled = True
        Me.combobox_theme.Items.AddRange(New Object() {"Light", "Dark Blue", "Darker Purple", "Lights Out"})
        Me.combobox_theme.Location = New System.Drawing.Point(234, 332)
        Me.combobox_theme.Name = "combobox_theme"
        Me.combobox_theme.Size = New System.Drawing.Size(216, 21)
        Me.combobox_theme.TabIndex = 8
        '
        'load_skin
        '
        Me.load_skin.AutoSize = True
        Me.load_skin.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.load_skin.Location = New System.Drawing.Point(49, 323)
        Me.load_skin.Name = "load_skin"
        Me.load_skin.Size = New System.Drawing.Size(121, 28)
        Me.load_skin.TabIndex = 5
        Me.load_skin.Text = "Dark mode"
        Me.load_skin.UseVisualStyleBackColor = True
        Me.load_skin.Visible = False
        '
        'picturebox_preview
        '
        Me.picturebox_preview.BackgroundImage = CType(resources.GetObject("picturebox_preview.BackgroundImage"), System.Drawing.Image)
        Me.picturebox_preview.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.picturebox_preview.Location = New System.Drawing.Point(12, 13)
        Me.picturebox_preview.Name = "picturebox_preview"
        Me.picturebox_preview.Size = New System.Drawing.Size(663, 304)
        Me.picturebox_preview.TabIndex = 6
        Me.picturebox_preview.TabStop = False
        '
        'settings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(927, 498)
        Me.Controls.Add(Me.lbl_settingstitle)
        Me.Controls.Add(Me.listbox_settings)
        Me.Controls.Add(Me.btn_save)
        Me.Controls.Add(Me.panel_theme)
        Me.Controls.Add(Me.panel_appearance)
        Me.Controls.Add(Me.panel_delivery)
        Me.Controls.Add(Me.panel_general)
        Me.Controls.Add(Me.panel_updates)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "settings"
        Me.Text = "Settings"
        CType(Me.btn_save, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panel_general.ResumeLayout(False)
        Me.panel_general.PerformLayout()
        Me.panel_appearance.ResumeLayout(False)
        Me.panel_appearance.PerformLayout()
        CType(Me.picturebox_wave, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panel_updates.ResumeLayout(False)
        Me.panel_updates.PerformLayout()
        Me.panel_delivery.ResumeLayout(False)
        Me.panel_delivery.PerformLayout()
        Me.panel_theme.ResumeLayout(False)
        Me.panel_theme.PerformLayout()
        CType(Me.picturebox_preview, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents load_boxart_on_startup As CheckBox
    Friend WithEvents btn_save As PictureBox
    Friend WithEvents listbox_settings As ListBox
    Friend WithEvents panel_general As Panel
    Friend WithEvents lbl_settingstitle As Label
    Friend WithEvents panel_appearance As Panel
    Friend WithEvents panel_updates As Panel
    Friend WithEvents checkbox_autoupdate As CheckBox
    Friend WithEvents checkbox_exit_on_taskbar As CheckBox
    Friend WithEvents checkbox_fancy As CheckBox
    Friend WithEvents picturebox_wave As PictureBox
    Friend WithEvents checkbox_topbar As CheckBox
    Friend WithEvents panel_delivery As Panel
    Friend WithEvents checkbox_delivery As CheckBox
    Friend WithEvents panel_theme As Panel
    Friend WithEvents combobox_theme As ComboBox
    Friend WithEvents load_skin As CheckBox
    Friend WithEvents picturebox_preview As PictureBox
    Friend WithEvents checkbox_affiliate As CheckBox
    Friend WithEvents combobox_provider As ComboBox
    Friend WithEvents lbl_provider As Label
    Friend WithEvents combobox_boxart_method As ComboBox
    Friend WithEvents checkbox_offline As CheckBox
    Friend WithEvents checkbox_hoarder As CheckBox
End Class
