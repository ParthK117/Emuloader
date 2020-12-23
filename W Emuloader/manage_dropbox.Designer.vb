<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class manage_dropbox
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(manage_dropbox))
        Me.panel_sync = New System.Windows.Forms.Panel()
        Me.panel_nds = New System.Windows.Forms.Panel()
        Me.lbl_preferences_nds = New System.Windows.Forms.Label()
        Me.btn_restore_games_nds = New System.Windows.Forms.Button()
        Me.checkbox_dropbox_nds = New System.Windows.Forms.CheckBox()
        Me.lbl_restore_nds = New System.Windows.Forms.Label()
        Me.lbl_sync_nds = New System.Windows.Forms.Label()
        Me.btn_backup_games_nds = New System.Windows.Forms.Button()
        Me.lbl_backup_nds = New System.Windows.Forms.Label()
        Me.checkbox_sync_settings_nds = New System.Windows.Forms.CheckBox()
        Me.lbl_features_gba = New System.Windows.Forms.Label()
        Me.panel_gba = New System.Windows.Forms.Panel()
        Me.lbl_preferences_gba = New System.Windows.Forms.Label()
        Me.btn_restore_games_gba = New System.Windows.Forms.Button()
        Me.checkbox_dropbox_gba = New System.Windows.Forms.CheckBox()
        Me.lbl_restore_gba = New System.Windows.Forms.Label()
        Me.lbl_sync_gba = New System.Windows.Forms.Label()
        Me.btn_backup_games_gba = New System.Windows.Forms.Button()
        Me.lbl_backup_gba = New System.Windows.Forms.Label()
        Me.checkbox_sync_settings_gba = New System.Windows.Forms.CheckBox()
        Me.btn_save = New System.Windows.Forms.PictureBox()
        Me.lbl_cloud = New System.Windows.Forms.Label()
        Me.listbox_cloud = New System.Windows.Forms.ListBox()
        Me.listbox_platforms = New System.Windows.Forms.ListBox()
        Me.panel_sync.SuspendLayout()
        Me.panel_nds.SuspendLayout()
        Me.panel_gba.SuspendLayout()
        CType(Me.btn_save, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'panel_sync
        '
        Me.panel_sync.BackColor = System.Drawing.Color.Transparent
        Me.panel_sync.Controls.Add(Me.panel_nds)
        Me.panel_sync.Controls.Add(Me.lbl_features_gba)
        Me.panel_sync.Controls.Add(Me.panel_gba)
        Me.panel_sync.Location = New System.Drawing.Point(261, 56)
        Me.panel_sync.Name = "panel_sync"
        Me.panel_sync.Size = New System.Drawing.Size(521, 373)
        Me.panel_sync.TabIndex = 0
        '
        'panel_nds
        '
        Me.panel_nds.Controls.Add(Me.lbl_preferences_nds)
        Me.panel_nds.Controls.Add(Me.btn_restore_games_nds)
        Me.panel_nds.Controls.Add(Me.checkbox_dropbox_nds)
        Me.panel_nds.Controls.Add(Me.lbl_restore_nds)
        Me.panel_nds.Controls.Add(Me.lbl_sync_nds)
        Me.panel_nds.Controls.Add(Me.btn_backup_games_nds)
        Me.panel_nds.Controls.Add(Me.lbl_backup_nds)
        Me.panel_nds.Controls.Add(Me.checkbox_sync_settings_nds)
        Me.panel_nds.Location = New System.Drawing.Point(3, 3)
        Me.panel_nds.Name = "panel_nds"
        Me.panel_nds.Size = New System.Drawing.Size(515, 248)
        Me.panel_nds.TabIndex = 11
        '
        'lbl_preferences_nds
        '
        Me.lbl_preferences_nds.AutoSize = True
        Me.lbl_preferences_nds.Location = New System.Drawing.Point(5, 15)
        Me.lbl_preferences_nds.Name = "lbl_preferences_nds"
        Me.lbl_preferences_nds.Size = New System.Drawing.Size(108, 13)
        Me.lbl_preferences_nds.TabIndex = 0
        Me.lbl_preferences_nds.Text = "Preferences for NDS:"
        '
        'btn_restore_games_nds
        '
        Me.btn_restore_games_nds.Enabled = False
        Me.btn_restore_games_nds.Location = New System.Drawing.Point(8, 192)
        Me.btn_restore_games_nds.Name = "btn_restore_games_nds"
        Me.btn_restore_games_nds.Size = New System.Drawing.Size(162, 48)
        Me.btn_restore_games_nds.TabIndex = 8
        Me.btn_restore_games_nds.Text = "Restore roms folder from Dropbox"
        Me.btn_restore_games_nds.UseVisualStyleBackColor = True
        '
        'checkbox_dropbox_nds
        '
        Me.checkbox_dropbox_nds.AutoSize = True
        Me.checkbox_dropbox_nds.Location = New System.Drawing.Point(8, 64)
        Me.checkbox_dropbox_nds.Name = "checkbox_dropbox_nds"
        Me.checkbox_dropbox_nds.Size = New System.Drawing.Size(247, 17)
        Me.checkbox_dropbox_nds.TabIndex = 1
        Me.checkbox_dropbox_nds.Text = "Sync saves with dropbox after session finishes."
        Me.checkbox_dropbox_nds.UseVisualStyleBackColor = True
        '
        'lbl_restore_nds
        '
        Me.lbl_restore_nds.AutoSize = True
        Me.lbl_restore_nds.Location = New System.Drawing.Point(5, 173)
        Me.lbl_restore_nds.Name = "lbl_restore_nds"
        Me.lbl_restore_nds.Size = New System.Drawing.Size(47, 13)
        Me.lbl_restore_nds.TabIndex = 7
        Me.lbl_restore_nds.Text = "Restore:"
        '
        'lbl_sync_nds
        '
        Me.lbl_sync_nds.AutoSize = True
        Me.lbl_sync_nds.Location = New System.Drawing.Point(5, 40)
        Me.lbl_sync_nds.Name = "lbl_sync_nds"
        Me.lbl_sync_nds.Size = New System.Drawing.Size(48, 13)
        Me.lbl_sync_nds.TabIndex = 2
        Me.lbl_sync_nds.Text = "Syncing:"
        '
        'btn_backup_games_nds
        '
        Me.btn_backup_games_nds.Enabled = False
        Me.btn_backup_games_nds.Location = New System.Drawing.Point(8, 136)
        Me.btn_backup_games_nds.Name = "btn_backup_games_nds"
        Me.btn_backup_games_nds.Size = New System.Drawing.Size(162, 33)
        Me.btn_backup_games_nds.TabIndex = 6
        Me.btn_backup_games_nds.Text = "Backup roms folder"
        Me.btn_backup_games_nds.UseVisualStyleBackColor = True
        '
        'lbl_backup_nds
        '
        Me.lbl_backup_nds.AutoSize = True
        Me.lbl_backup_nds.Location = New System.Drawing.Point(5, 117)
        Me.lbl_backup_nds.Name = "lbl_backup_nds"
        Me.lbl_backup_nds.Size = New System.Drawing.Size(47, 13)
        Me.lbl_backup_nds.TabIndex = 3
        Me.lbl_backup_nds.Text = "Backup:"
        '
        'checkbox_sync_settings_nds
        '
        Me.checkbox_sync_settings_nds.AutoSize = True
        Me.checkbox_sync_settings_nds.Enabled = False
        Me.checkbox_sync_settings_nds.Location = New System.Drawing.Point(8, 89)
        Me.checkbox_sync_settings_nds.Name = "checkbox_sync_settings_nds"
        Me.checkbox_sync_settings_nds.Size = New System.Drawing.Size(235, 17)
        Me.checkbox_sync_settings_nds.TabIndex = 5
        Me.checkbox_sync_settings_nds.Text = "Sync emulator settings after session finishes."
        Me.checkbox_sync_settings_nds.UseVisualStyleBackColor = True
        '
        'lbl_features_gba
        '
        Me.lbl_features_gba.Location = New System.Drawing.Point(8, 254)
        Me.lbl_features_gba.Name = "lbl_features_gba"
        Me.lbl_features_gba.Size = New System.Drawing.Size(487, 99)
        Me.lbl_features_gba.TabIndex = 9
        Me.lbl_features_gba.Text = "More features will be available in coming updates, contribute via Patreon or Ko-f" &
    "i to aid in development!"
        '
        'panel_gba
        '
        Me.panel_gba.Controls.Add(Me.lbl_preferences_gba)
        Me.panel_gba.Controls.Add(Me.btn_restore_games_gba)
        Me.panel_gba.Controls.Add(Me.checkbox_dropbox_gba)
        Me.panel_gba.Controls.Add(Me.lbl_restore_gba)
        Me.panel_gba.Controls.Add(Me.lbl_sync_gba)
        Me.panel_gba.Controls.Add(Me.btn_backup_games_gba)
        Me.panel_gba.Controls.Add(Me.lbl_backup_gba)
        Me.panel_gba.Controls.Add(Me.checkbox_sync_settings_gba)
        Me.panel_gba.Location = New System.Drawing.Point(3, 3)
        Me.panel_gba.Name = "panel_gba"
        Me.panel_gba.Size = New System.Drawing.Size(515, 248)
        Me.panel_gba.TabIndex = 10
        '
        'lbl_preferences_gba
        '
        Me.lbl_preferences_gba.AutoSize = True
        Me.lbl_preferences_gba.Location = New System.Drawing.Point(5, 15)
        Me.lbl_preferences_gba.Name = "lbl_preferences_gba"
        Me.lbl_preferences_gba.Size = New System.Drawing.Size(107, 13)
        Me.lbl_preferences_gba.TabIndex = 0
        Me.lbl_preferences_gba.Text = "Preferences for GBA:"
        '
        'btn_restore_games_gba
        '
        Me.btn_restore_games_gba.Enabled = False
        Me.btn_restore_games_gba.Location = New System.Drawing.Point(8, 192)
        Me.btn_restore_games_gba.Name = "btn_restore_games_gba"
        Me.btn_restore_games_gba.Size = New System.Drawing.Size(162, 48)
        Me.btn_restore_games_gba.TabIndex = 8
        Me.btn_restore_games_gba.Text = "Restore roms folder from Dropbox"
        Me.btn_restore_games_gba.UseVisualStyleBackColor = True
        '
        'checkbox_dropbox_gba
        '
        Me.checkbox_dropbox_gba.AutoSize = True
        Me.checkbox_dropbox_gba.Location = New System.Drawing.Point(8, 64)
        Me.checkbox_dropbox_gba.Name = "checkbox_dropbox_gba"
        Me.checkbox_dropbox_gba.Size = New System.Drawing.Size(247, 17)
        Me.checkbox_dropbox_gba.TabIndex = 1
        Me.checkbox_dropbox_gba.Text = "Sync saves with dropbox after session finishes."
        Me.checkbox_dropbox_gba.UseVisualStyleBackColor = True
        '
        'lbl_restore_gba
        '
        Me.lbl_restore_gba.AutoSize = True
        Me.lbl_restore_gba.Location = New System.Drawing.Point(5, 173)
        Me.lbl_restore_gba.Name = "lbl_restore_gba"
        Me.lbl_restore_gba.Size = New System.Drawing.Size(47, 13)
        Me.lbl_restore_gba.TabIndex = 7
        Me.lbl_restore_gba.Text = "Restore:"
        '
        'lbl_sync_gba
        '
        Me.lbl_sync_gba.AutoSize = True
        Me.lbl_sync_gba.Location = New System.Drawing.Point(5, 40)
        Me.lbl_sync_gba.Name = "lbl_sync_gba"
        Me.lbl_sync_gba.Size = New System.Drawing.Size(48, 13)
        Me.lbl_sync_gba.TabIndex = 2
        Me.lbl_sync_gba.Text = "Syncing:"
        '
        'btn_backup_games_gba
        '
        Me.btn_backup_games_gba.Enabled = False
        Me.btn_backup_games_gba.Location = New System.Drawing.Point(8, 136)
        Me.btn_backup_games_gba.Name = "btn_backup_games_gba"
        Me.btn_backup_games_gba.Size = New System.Drawing.Size(162, 33)
        Me.btn_backup_games_gba.TabIndex = 6
        Me.btn_backup_games_gba.Text = "Backup roms folder"
        Me.btn_backup_games_gba.UseVisualStyleBackColor = True
        '
        'lbl_backup_gba
        '
        Me.lbl_backup_gba.AutoSize = True
        Me.lbl_backup_gba.Location = New System.Drawing.Point(5, 117)
        Me.lbl_backup_gba.Name = "lbl_backup_gba"
        Me.lbl_backup_gba.Size = New System.Drawing.Size(47, 13)
        Me.lbl_backup_gba.TabIndex = 3
        Me.lbl_backup_gba.Text = "Backup:"
        '
        'checkbox_sync_settings_gba
        '
        Me.checkbox_sync_settings_gba.AutoSize = True
        Me.checkbox_sync_settings_gba.Enabled = False
        Me.checkbox_sync_settings_gba.Location = New System.Drawing.Point(8, 89)
        Me.checkbox_sync_settings_gba.Name = "checkbox_sync_settings_gba"
        Me.checkbox_sync_settings_gba.Size = New System.Drawing.Size(235, 17)
        Me.checkbox_sync_settings_gba.TabIndex = 5
        Me.checkbox_sync_settings_gba.Text = "Sync emulator settings after session finishes."
        Me.checkbox_sync_settings_gba.UseVisualStyleBackColor = True
        '
        'btn_save
        '
        Me.btn_save.BackgroundImage = CType(resources.GetObject("btn_save.BackgroundImage"), System.Drawing.Image)
        Me.btn_save.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_save.Location = New System.Drawing.Point(603, 5)
        Me.btn_save.Name = "btn_save"
        Me.btn_save.Size = New System.Drawing.Size(176, 48)
        Me.btn_save.TabIndex = 10
        Me.btn_save.TabStop = False
        '
        'lbl_cloud
        '
        Me.lbl_cloud.AutoSize = True
        Me.lbl_cloud.Font = New System.Drawing.Font("Gotham Bold", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_cloud.Location = New System.Drawing.Point(264, 9)
        Me.lbl_cloud.Name = "lbl_cloud"
        Me.lbl_cloud.Size = New System.Drawing.Size(131, 44)
        Me.lbl_cloud.TabIndex = 3
        Me.lbl_cloud.Text = "Cloud"
        '
        'listbox_cloud
        '
        Me.listbox_cloud.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.listbox_cloud.BackColor = System.Drawing.Color.White
        Me.listbox_cloud.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.listbox_cloud.FormattingEnabled = True
        Me.listbox_cloud.Items.AddRange(New Object() {"Syncing", "Backup", "Restore", "Version control"})
        Me.listbox_cloud.Location = New System.Drawing.Point(3, 2)
        Me.listbox_cloud.Name = "listbox_cloud"
        Me.listbox_cloud.Size = New System.Drawing.Size(255, 119)
        Me.listbox_cloud.TabIndex = 1
        Me.listbox_cloud.Visible = False
        '
        'listbox_platforms
        '
        Me.listbox_platforms.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.listbox_platforms.BackColor = System.Drawing.Color.White
        Me.listbox_platforms.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.listbox_platforms.FormattingEnabled = True
        Me.listbox_platforms.Items.AddRange(New Object() {"GBA", "NDS"})
        Me.listbox_platforms.Location = New System.Drawing.Point(3, 2)
        Me.listbox_platforms.Name = "listbox_platforms"
        Me.listbox_platforms.Size = New System.Drawing.Size(255, 431)
        Me.listbox_platforms.TabIndex = 2
        '
        'manage_dropbox
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(784, 441)
        Me.Controls.Add(Me.btn_save)
        Me.Controls.Add(Me.listbox_platforms)
        Me.Controls.Add(Me.lbl_cloud)
        Me.Controls.Add(Me.listbox_cloud)
        Me.Controls.Add(Me.panel_sync)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "manage_dropbox"
        Me.Text = "Manage Backups"
        Me.panel_sync.ResumeLayout(False)
        Me.panel_nds.ResumeLayout(False)
        Me.panel_nds.PerformLayout()
        Me.panel_gba.ResumeLayout(False)
        Me.panel_gba.PerformLayout()
        CType(Me.btn_save, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents panel_sync As Panel
    Friend WithEvents listbox_cloud As ListBox
    Friend WithEvents lbl_cloud As Label
    Friend WithEvents listbox_platforms As ListBox
    Friend WithEvents lbl_preferences_gba As Label
    Friend WithEvents lbl_sync_gba As Label
    Friend WithEvents checkbox_dropbox_gba As CheckBox
    Friend WithEvents lbl_features_gba As Label
    Friend WithEvents btn_restore_games_gba As Button
    Friend WithEvents lbl_restore_gba As Label
    Friend WithEvents btn_backup_games_gba As Button
    Friend WithEvents checkbox_sync_settings_gba As CheckBox
    Friend WithEvents lbl_backup_gba As Label
    Friend WithEvents btn_save As PictureBox
    Friend WithEvents panel_gba As Panel
    Friend WithEvents panel_nds As Panel
    Friend WithEvents lbl_preferences_nds As Label
    Friend WithEvents btn_restore_games_nds As Button
    Friend WithEvents checkbox_dropbox_nds As CheckBox
    Friend WithEvents lbl_restore_nds As Label
    Friend WithEvents lbl_sync_nds As Label
    Friend WithEvents btn_backup_games_nds As Button
    Friend WithEvents lbl_backup_nds As Label
    Friend WithEvents checkbox_sync_settings_nds As CheckBox
End Class
