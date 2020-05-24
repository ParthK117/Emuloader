<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class main
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(main))
        Me.image_logo = New System.Windows.Forms.PictureBox()
        Me.panel_left = New System.Windows.Forms.Panel()
        Me.emu_nine = New System.Windows.Forms.Label()
        Me.emu_eight = New System.Windows.Forms.Label()
        Me.emu_seven = New System.Windows.Forms.Label()
        Me.emu_six = New System.Windows.Forms.Label()
        Me.emu_five = New System.Windows.Forms.Label()
        Me.emu_four = New System.Windows.Forms.Label()
        Me.picturebox_tungsten = New System.Windows.Forms.PictureBox()
        Me.lbl_licensing = New System.Windows.Forms.Label()
        Me.lbl_patreon = New System.Windows.Forms.Label()
        Me.lbl_github = New System.Windows.Forms.Label()
        Me.lbl_twitter = New System.Windows.Forms.Label()
        Me.lbl_about = New System.Windows.Forms.Label()
        Me.emu_three = New System.Windows.Forms.Label()
        Me.emu_two = New System.Windows.Forms.Label()
        Me.emu_one = New System.Windows.Forms.Label()
        Me.lbl_library = New System.Windows.Forms.Label()
        Me.tab_browse = New System.Windows.Forms.PictureBox()
        Me.btn_browse = New System.Windows.Forms.Label()
        Me.btn_newemu = New System.Windows.Forms.PictureBox()
        Me.panel_right = New System.Windows.Forms.Panel()
        Me.panel_rom_info = New System.Windows.Forms.Panel()
        Me.btn_queue = New System.Windows.Forms.PictureBox()
        Me.lbl_rom_platform = New System.Windows.Forms.Label()
        Me.lbl_rom_name = New System.Windows.Forms.Label()
        Me.checkbox_fullscreen = New System.Windows.Forms.CheckBox()
        Me.btn_play = New System.Windows.Forms.PictureBox()
        Me.lbl_platform = New System.Windows.Forms.Label()
        Me.lbl_installedon = New System.Windows.Forms.Label()
        Me.lbl_name = New System.Windows.Forms.Label()
        Me.panel_seperator = New System.Windows.Forms.Panel()
        Me.lbl_information = New System.Windows.Forms.Label()
        Me.panel_top = New System.Windows.Forms.Panel()
        Me.lbl_status = New System.Windows.Forms.Label()
        Me.paneL_menubar = New System.Windows.Forms.Panel()
        Me.btn_maximise = New System.Windows.Forms.Panel()
        Me.btn_minimise = New System.Windows.Forms.Panel()
        Me.btn_exit = New System.Windows.Forms.Panel()
        Me.btn_about = New System.Windows.Forms.PictureBox()
        Me.panel_play = New System.Windows.Forms.Panel()
        Me.panel_rom_rightclick = New System.Windows.Forms.Panel()
        Me.btn_rom_delete = New System.Windows.Forms.PictureBox()
        Me.btn_rom_rename = New System.Windows.Forms.PictureBox()
        Me.checkbox_filepath = New System.Windows.Forms.CheckBox()
        Me.btn_import_roms = New System.Windows.Forms.PictureBox()
        Me.listbox_installedroms = New System.Windows.Forms.ListView()
        Me.installed_name = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.installed_platform = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.installed_directory = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lbl_play = New System.Windows.Forms.Label()
        Me.panel_browse = New System.Windows.Forms.Panel()
        Me.listbox_availableroms = New System.Windows.Forms.ListView()
        Me.column_name = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.column_size = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.column_platform = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.column_source = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.column_url = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btn_import = New System.Windows.Forms.PictureBox()
        Me.lbl_browse = New System.Windows.Forms.Label()
        Me.import_list = New System.Windows.Forms.OpenFileDialog()
        CType(Me.image_logo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panel_left.SuspendLayout()
        CType(Me.picturebox_tungsten, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tab_browse, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btn_newemu, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panel_right.SuspendLayout()
        Me.panel_rom_info.SuspendLayout()
        CType(Me.btn_queue, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btn_play, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panel_top.SuspendLayout()
        Me.paneL_menubar.SuspendLayout()
        CType(Me.btn_about, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panel_play.SuspendLayout()
        Me.panel_rom_rightclick.SuspendLayout()
        CType(Me.btn_rom_delete, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btn_rom_rename, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btn_import_roms, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panel_browse.SuspendLayout()
        CType(Me.btn_import, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'image_logo
        '
        Me.image_logo.BackgroundImage = CType(resources.GetObject("image_logo.BackgroundImage"), System.Drawing.Image)
        Me.image_logo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.image_logo.Location = New System.Drawing.Point(12, 17)
        Me.image_logo.Name = "image_logo"
        Me.image_logo.Size = New System.Drawing.Size(154, 65)
        Me.image_logo.TabIndex = 1
        Me.image_logo.TabStop = False
        '
        'panel_left
        '
        Me.panel_left.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.panel_left.BackColor = System.Drawing.Color.Gainsboro
        Me.panel_left.Controls.Add(Me.emu_nine)
        Me.panel_left.Controls.Add(Me.emu_eight)
        Me.panel_left.Controls.Add(Me.emu_seven)
        Me.panel_left.Controls.Add(Me.emu_six)
        Me.panel_left.Controls.Add(Me.emu_five)
        Me.panel_left.Controls.Add(Me.emu_four)
        Me.panel_left.Controls.Add(Me.picturebox_tungsten)
        Me.panel_left.Controls.Add(Me.lbl_licensing)
        Me.panel_left.Controls.Add(Me.lbl_patreon)
        Me.panel_left.Controls.Add(Me.lbl_github)
        Me.panel_left.Controls.Add(Me.lbl_twitter)
        Me.panel_left.Controls.Add(Me.lbl_about)
        Me.panel_left.Controls.Add(Me.emu_three)
        Me.panel_left.Controls.Add(Me.emu_two)
        Me.panel_left.Controls.Add(Me.emu_one)
        Me.panel_left.Controls.Add(Me.lbl_library)
        Me.panel_left.Controls.Add(Me.tab_browse)
        Me.panel_left.Controls.Add(Me.btn_browse)
        Me.panel_left.Controls.Add(Me.btn_newemu)
        Me.panel_left.Controls.Add(Me.image_logo)
        Me.panel_left.Location = New System.Drawing.Point(0, 40)
        Me.panel_left.Name = "panel_left"
        Me.panel_left.Size = New System.Drawing.Size(250, 860)
        Me.panel_left.TabIndex = 2
        '
        'emu_nine
        '
        Me.emu_nine.AutoSize = True
        Me.emu_nine.Font = New System.Drawing.Font("Gotham Bold", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.emu_nine.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.emu_nine.Location = New System.Drawing.Point(22, 520)
        Me.emu_nine.Name = "emu_nine"
        Me.emu_nine.Size = New System.Drawing.Size(202, 29)
        Me.emu_nine.TabIndex = 19
        Me.emu_nine.Text = "Emulator Name"
        Me.emu_nine.Visible = False
        '
        'emu_eight
        '
        Me.emu_eight.AutoSize = True
        Me.emu_eight.Font = New System.Drawing.Font("Gotham Bold", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.emu_eight.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.emu_eight.Location = New System.Drawing.Point(22, 480)
        Me.emu_eight.Name = "emu_eight"
        Me.emu_eight.Size = New System.Drawing.Size(202, 29)
        Me.emu_eight.TabIndex = 18
        Me.emu_eight.Text = "Emulator Name"
        Me.emu_eight.Visible = False
        '
        'emu_seven
        '
        Me.emu_seven.AutoSize = True
        Me.emu_seven.Font = New System.Drawing.Font("Gotham Bold", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.emu_seven.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.emu_seven.Location = New System.Drawing.Point(22, 440)
        Me.emu_seven.Name = "emu_seven"
        Me.emu_seven.Size = New System.Drawing.Size(202, 29)
        Me.emu_seven.TabIndex = 17
        Me.emu_seven.Text = "Emulator Name"
        Me.emu_seven.Visible = False
        '
        'emu_six
        '
        Me.emu_six.AutoSize = True
        Me.emu_six.Font = New System.Drawing.Font("Gotham Bold", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.emu_six.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.emu_six.Location = New System.Drawing.Point(21, 400)
        Me.emu_six.Name = "emu_six"
        Me.emu_six.Size = New System.Drawing.Size(202, 29)
        Me.emu_six.TabIndex = 16
        Me.emu_six.Text = "Emulator Name"
        Me.emu_six.Visible = False
        '
        'emu_five
        '
        Me.emu_five.AutoSize = True
        Me.emu_five.Font = New System.Drawing.Font("Gotham Bold", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.emu_five.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.emu_five.Location = New System.Drawing.Point(21, 360)
        Me.emu_five.Name = "emu_five"
        Me.emu_five.Size = New System.Drawing.Size(202, 29)
        Me.emu_five.TabIndex = 15
        Me.emu_five.Text = "Emulator Name"
        Me.emu_five.Visible = False
        '
        'emu_four
        '
        Me.emu_four.AutoSize = True
        Me.emu_four.Font = New System.Drawing.Font("Gotham Bold", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.emu_four.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.emu_four.Location = New System.Drawing.Point(21, 320)
        Me.emu_four.Name = "emu_four"
        Me.emu_four.Size = New System.Drawing.Size(202, 29)
        Me.emu_four.TabIndex = 14
        Me.emu_four.Text = "Emulator Name"
        Me.emu_four.Visible = False
        '
        'picturebox_tungsten
        '
        Me.picturebox_tungsten.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.picturebox_tungsten.BackgroundImage = CType(resources.GetObject("picturebox_tungsten.BackgroundImage"), System.Drawing.Image)
        Me.picturebox_tungsten.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.picturebox_tungsten.Location = New System.Drawing.Point(38, 690)
        Me.picturebox_tungsten.Name = "picturebox_tungsten"
        Me.picturebox_tungsten.Size = New System.Drawing.Size(175, 25)
        Me.picturebox_tungsten.TabIndex = 13
        Me.picturebox_tungsten.TabStop = False
        '
        'lbl_licensing
        '
        Me.lbl_licensing.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbl_licensing.AutoSize = True
        Me.lbl_licensing.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_licensing.Location = New System.Drawing.Point(35, 838)
        Me.lbl_licensing.Name = "lbl_licensing"
        Me.lbl_licensing.Size = New System.Drawing.Size(177, 13)
        Me.lbl_licensing.TabIndex = 12
        Me.lbl_licensing.Text = "Licensed under GPLv3, open-source."
        '
        'lbl_patreon
        '
        Me.lbl_patreon.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbl_patreon.AutoSize = True
        Me.lbl_patreon.Font = New System.Drawing.Font("Gotham Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_patreon.Location = New System.Drawing.Point(152, 792)
        Me.lbl_patreon.Name = "lbl_patreon"
        Me.lbl_patreon.Size = New System.Drawing.Size(67, 18)
        Me.lbl_patreon.TabIndex = 11
        Me.lbl_patreon.Text = "Patreon"
        '
        'lbl_github
        '
        Me.lbl_github.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbl_github.AutoSize = True
        Me.lbl_github.Font = New System.Drawing.Font("Gotham Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_github.Location = New System.Drawing.Point(34, 792)
        Me.lbl_github.Name = "lbl_github"
        Me.lbl_github.Size = New System.Drawing.Size(61, 18)
        Me.lbl_github.TabIndex = 10
        Me.lbl_github.Text = "GitHub"
        '
        'lbl_twitter
        '
        Me.lbl_twitter.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbl_twitter.AutoSize = True
        Me.lbl_twitter.Font = New System.Drawing.Font("Gotham Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_twitter.Location = New System.Drawing.Point(152, 736)
        Me.lbl_twitter.Name = "lbl_twitter"
        Me.lbl_twitter.Size = New System.Drawing.Size(62, 18)
        Me.lbl_twitter.TabIndex = 9
        Me.lbl_twitter.Text = "Twitter"
        '
        'lbl_about
        '
        Me.lbl_about.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbl_about.AutoSize = True
        Me.lbl_about.Font = New System.Drawing.Font("Gotham Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_about.Location = New System.Drawing.Point(34, 736)
        Me.lbl_about.Name = "lbl_about"
        Me.lbl_about.Size = New System.Drawing.Size(55, 18)
        Me.lbl_about.TabIndex = 5
        Me.lbl_about.Text = "About"
        '
        'emu_three
        '
        Me.emu_three.AutoSize = True
        Me.emu_three.Font = New System.Drawing.Font("Gotham Bold", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.emu_three.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.emu_three.Location = New System.Drawing.Point(21, 280)
        Me.emu_three.Name = "emu_three"
        Me.emu_three.Size = New System.Drawing.Size(202, 29)
        Me.emu_three.TabIndex = 8
        Me.emu_three.Text = "Emulator Name"
        Me.emu_three.Visible = False
        '
        'emu_two
        '
        Me.emu_two.AutoSize = True
        Me.emu_two.Font = New System.Drawing.Font("Gotham Bold", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.emu_two.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.emu_two.Location = New System.Drawing.Point(21, 240)
        Me.emu_two.Name = "emu_two"
        Me.emu_two.Size = New System.Drawing.Size(202, 29)
        Me.emu_two.TabIndex = 7
        Me.emu_two.Text = "Emulator Name"
        Me.emu_two.Visible = False
        '
        'emu_one
        '
        Me.emu_one.AutoSize = True
        Me.emu_one.Font = New System.Drawing.Font("Gotham Bold", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.emu_one.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.emu_one.Location = New System.Drawing.Point(21, 200)
        Me.emu_one.Name = "emu_one"
        Me.emu_one.Size = New System.Drawing.Size(202, 29)
        Me.emu_one.TabIndex = 6
        Me.emu_one.Text = "Emulator Name"
        Me.emu_one.Visible = False
        '
        'lbl_library
        '
        Me.lbl_library.AutoSize = True
        Me.lbl_library.Font = New System.Drawing.Font("Gotham Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_library.Location = New System.Drawing.Point(22, 170)
        Me.lbl_library.Name = "lbl_library"
        Me.lbl_library.Size = New System.Drawing.Size(114, 19)
        Me.lbl_library.TabIndex = 5
        Me.lbl_library.Text = "MY LIBRARY"
        '
        'tab_browse
        '
        Me.tab_browse.BackColor = System.Drawing.Color.Black
        Me.tab_browse.Location = New System.Drawing.Point(0, 111)
        Me.tab_browse.Name = "tab_browse"
        Me.tab_browse.Size = New System.Drawing.Size(6, 40)
        Me.tab_browse.TabIndex = 4
        Me.tab_browse.TabStop = False
        '
        'btn_browse
        '
        Me.btn_browse.AutoSize = True
        Me.btn_browse.Font = New System.Drawing.Font("Gotham Bold", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_browse.Location = New System.Drawing.Point(22, 118)
        Me.btn_browse.Name = "btn_browse"
        Me.btn_browse.Size = New System.Drawing.Size(91, 25)
        Me.btn_browse.TabIndex = 3
        Me.btn_browse.Text = "Browse"
        '
        'btn_newemu
        '
        Me.btn_newemu.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_newemu.BackgroundImage = CType(resources.GetObject("btn_newemu.BackgroundImage"), System.Drawing.Image)
        Me.btn_newemu.Location = New System.Drawing.Point(38, 607)
        Me.btn_newemu.Name = "btn_newemu"
        Me.btn_newemu.Size = New System.Drawing.Size(176, 48)
        Me.btn_newemu.TabIndex = 2
        Me.btn_newemu.TabStop = False
        '
        'panel_right
        '
        Me.panel_right.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panel_right.BackColor = System.Drawing.Color.Gainsboro
        Me.panel_right.Controls.Add(Me.panel_rom_info)
        Me.panel_right.Controls.Add(Me.checkbox_fullscreen)
        Me.panel_right.Controls.Add(Me.btn_play)
        Me.panel_right.Controls.Add(Me.lbl_platform)
        Me.panel_right.Controls.Add(Me.lbl_installedon)
        Me.panel_right.Controls.Add(Me.lbl_name)
        Me.panel_right.Controls.Add(Me.panel_seperator)
        Me.panel_right.Controls.Add(Me.lbl_information)
        Me.panel_right.Location = New System.Drawing.Point(1350, 40)
        Me.panel_right.Name = "panel_right"
        Me.panel_right.Size = New System.Drawing.Size(250, 860)
        Me.panel_right.TabIndex = 3
        '
        'panel_rom_info
        '
        Me.panel_rom_info.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panel_rom_info.Controls.Add(Me.btn_queue)
        Me.panel_rom_info.Controls.Add(Me.lbl_rom_platform)
        Me.panel_rom_info.Controls.Add(Me.lbl_rom_name)
        Me.panel_rom_info.Location = New System.Drawing.Point(0, 60)
        Me.panel_rom_info.Name = "panel_rom_info"
        Me.panel_rom_info.Size = New System.Drawing.Size(250, 800)
        Me.panel_rom_info.TabIndex = 6
        '
        'btn_queue
        '
        Me.btn_queue.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_queue.BackgroundImage = CType(resources.GetObject("btn_queue.BackgroundImage"), System.Drawing.Image)
        Me.btn_queue.Location = New System.Drawing.Point(36, 702)
        Me.btn_queue.Name = "btn_queue"
        Me.btn_queue.Size = New System.Drawing.Size(176, 48)
        Me.btn_queue.TabIndex = 8
        Me.btn_queue.TabStop = False
        '
        'lbl_rom_platform
        '
        Me.lbl_rom_platform.AutoSize = True
        Me.lbl_rom_platform.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_rom_platform.Location = New System.Drawing.Point(14, 30)
        Me.lbl_rom_platform.Name = "lbl_rom_platform"
        Me.lbl_rom_platform.Size = New System.Drawing.Size(187, 23)
        Me.lbl_rom_platform.TabIndex = 7
        Me.lbl_rom_platform.Text = "Tell me what you think!"
        '
        'lbl_rom_name
        '
        Me.lbl_rom_name.AutoSize = True
        Me.lbl_rom_name.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_rom_name.Location = New System.Drawing.Point(14, 1)
        Me.lbl_rom_name.MaximumSize = New System.Drawing.Size(200, 23)
        Me.lbl_rom_name.Name = "lbl_rom_name"
        Me.lbl_rom_name.Size = New System.Drawing.Size(133, 23)
        Me.lbl_rom_name.TabIndex = 5
        Me.lbl_rom_name.Text = "Prerelease Build"
        '
        'checkbox_fullscreen
        '
        Me.checkbox_fullscreen.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.checkbox_fullscreen.AutoSize = True
        Me.checkbox_fullscreen.Font = New System.Drawing.Font("Gotham Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.checkbox_fullscreen.Location = New System.Drawing.Point(36, 712)
        Me.checkbox_fullscreen.Name = "checkbox_fullscreen"
        Me.checkbox_fullscreen.Size = New System.Drawing.Size(180, 22)
        Me.checkbox_fullscreen.TabIndex = 9
        Me.checkbox_fullscreen.Text = "Launch in fullscreen"
        Me.checkbox_fullscreen.UseVisualStyleBackColor = True
        '
        'btn_play
        '
        Me.btn_play.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_play.BackgroundImage = CType(resources.GetObject("btn_play.BackgroundImage"), System.Drawing.Image)
        Me.btn_play.Location = New System.Drawing.Point(36, 762)
        Me.btn_play.Name = "btn_play"
        Me.btn_play.Size = New System.Drawing.Size(176, 48)
        Me.btn_play.TabIndex = 5
        Me.btn_play.TabStop = False
        '
        'lbl_platform
        '
        Me.lbl_platform.AutoSize = True
        Me.lbl_platform.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_platform.Location = New System.Drawing.Point(14, 120)
        Me.lbl_platform.Name = "lbl_platform"
        Me.lbl_platform.Size = New System.Drawing.Size(121, 23)
        Me.lbl_platform.TabIndex = 4
        Me.lbl_platform.Text = "Platform: WIN"
        '
        'lbl_installedon
        '
        Me.lbl_installedon.AutoSize = True
        Me.lbl_installedon.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_installedon.Location = New System.Drawing.Point(14, 90)
        Me.lbl_installedon.Name = "lbl_installedon"
        Me.lbl_installedon.Size = New System.Drawing.Size(198, 23)
        Me.lbl_installedon.TabIndex = 3
        Me.lbl_installedon.Text = "Installed on 01/01/1970"
        '
        'lbl_name
        '
        Me.lbl_name.AutoSize = True
        Me.lbl_name.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_name.Location = New System.Drawing.Point(14, 60)
        Me.lbl_name.Name = "lbl_name"
        Me.lbl_name.Size = New System.Drawing.Size(129, 23)
        Me.lbl_name.TabIndex = 2
        Me.lbl_name.Text = "Emulator Name"
        '
        'panel_seperator
        '
        Me.panel_seperator.Location = New System.Drawing.Point(18, 45)
        Me.panel_seperator.Name = "panel_seperator"
        Me.panel_seperator.Size = New System.Drawing.Size(213, 3)
        Me.panel_seperator.TabIndex = 1
        '
        'lbl_information
        '
        Me.lbl_information.AutoSize = True
        Me.lbl_information.Font = New System.Drawing.Font("Gotham Bold", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_information.Location = New System.Drawing.Point(15, 20)
        Me.lbl_information.Name = "lbl_information"
        Me.lbl_information.Size = New System.Drawing.Size(104, 16)
        Me.lbl_information.TabIndex = 0
        Me.lbl_information.Text = "INFORMATION"
        '
        'panel_top
        '
        Me.panel_top.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panel_top.BackColor = System.Drawing.Color.White
        Me.panel_top.Controls.Add(Me.lbl_status)
        Me.panel_top.Controls.Add(Me.paneL_menubar)
        Me.panel_top.Controls.Add(Me.btn_about)
        Me.panel_top.Location = New System.Drawing.Point(0, 0)
        Me.panel_top.Name = "panel_top"
        Me.panel_top.Size = New System.Drawing.Size(1600, 40)
        Me.panel_top.TabIndex = 3
        '
        'lbl_status
        '
        Me.lbl_status.AutoSize = True
        Me.lbl_status.Font = New System.Drawing.Font("Gotham Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_status.Location = New System.Drawing.Point(562, 11)
        Me.lbl_status.Name = "lbl_status"
        Me.lbl_status.Size = New System.Drawing.Size(61, 19)
        Me.lbl_status.TabIndex = 4
        Me.lbl_status.Text = "Ready"
        '
        'paneL_menubar
        '
        Me.paneL_menubar.BackgroundImage = CType(resources.GetObject("paneL_menubar.BackgroundImage"), System.Drawing.Image)
        Me.paneL_menubar.Controls.Add(Me.btn_maximise)
        Me.paneL_menubar.Controls.Add(Me.btn_minimise)
        Me.paneL_menubar.Controls.Add(Me.btn_exit)
        Me.paneL_menubar.Location = New System.Drawing.Point(10, 10)
        Me.paneL_menubar.Name = "paneL_menubar"
        Me.paneL_menubar.Size = New System.Drawing.Size(80, 20)
        Me.paneL_menubar.TabIndex = 2
        '
        'btn_maximise
        '
        Me.btn_maximise.BackColor = System.Drawing.Color.Transparent
        Me.btn_maximise.Location = New System.Drawing.Point(54, 0)
        Me.btn_maximise.Name = "btn_maximise"
        Me.btn_maximise.Size = New System.Drawing.Size(23, 20)
        Me.btn_maximise.TabIndex = 2
        '
        'btn_minimise
        '
        Me.btn_minimise.BackColor = System.Drawing.Color.Transparent
        Me.btn_minimise.Location = New System.Drawing.Point(28, 0)
        Me.btn_minimise.Name = "btn_minimise"
        Me.btn_minimise.Size = New System.Drawing.Size(21, 20)
        Me.btn_minimise.TabIndex = 1
        '
        'btn_exit
        '
        Me.btn_exit.BackColor = System.Drawing.Color.Transparent
        Me.btn_exit.Location = New System.Drawing.Point(4, 0)
        Me.btn_exit.Name = "btn_exit"
        Me.btn_exit.Size = New System.Drawing.Size(18, 20)
        Me.btn_exit.TabIndex = 0
        '
        'btn_about
        '
        Me.btn_about.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_about.BackgroundImage = CType(resources.GetObject("btn_about.BackgroundImage"), System.Drawing.Image)
        Me.btn_about.Location = New System.Drawing.Point(1497, 2)
        Me.btn_about.Name = "btn_about"
        Me.btn_about.Size = New System.Drawing.Size(100, 36)
        Me.btn_about.TabIndex = 1
        Me.btn_about.TabStop = False
        Me.btn_about.Visible = False
        '
        'panel_play
        '
        Me.panel_play.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panel_play.Controls.Add(Me.panel_rom_rightclick)
        Me.panel_play.Controls.Add(Me.checkbox_filepath)
        Me.panel_play.Controls.Add(Me.btn_import_roms)
        Me.panel_play.Controls.Add(Me.listbox_installedroms)
        Me.panel_play.Controls.Add(Me.lbl_play)
        Me.panel_play.Location = New System.Drawing.Point(250, 40)
        Me.panel_play.Name = "panel_play"
        Me.panel_play.Size = New System.Drawing.Size(1100, 860)
        Me.panel_play.TabIndex = 4
        '
        'panel_rom_rightclick
        '
        Me.panel_rom_rightclick.BackColor = System.Drawing.Color.White
        Me.panel_rom_rightclick.Controls.Add(Me.btn_rom_delete)
        Me.panel_rom_rightclick.Controls.Add(Me.btn_rom_rename)
        Me.panel_rom_rightclick.Location = New System.Drawing.Point(611, 112)
        Me.panel_rom_rightclick.Name = "panel_rom_rightclick"
        Me.panel_rom_rightclick.Size = New System.Drawing.Size(125, 60)
        Me.panel_rom_rightclick.TabIndex = 11
        Me.panel_rom_rightclick.Visible = False
        '
        'btn_rom_delete
        '
        Me.btn_rom_delete.BackgroundImage = CType(resources.GetObject("btn_rom_delete.BackgroundImage"), System.Drawing.Image)
        Me.btn_rom_delete.Location = New System.Drawing.Point(0, 30)
        Me.btn_rom_delete.Name = "btn_rom_delete"
        Me.btn_rom_delete.Size = New System.Drawing.Size(125, 30)
        Me.btn_rom_delete.TabIndex = 1
        Me.btn_rom_delete.TabStop = False
        '
        'btn_rom_rename
        '
        Me.btn_rom_rename.BackgroundImage = CType(resources.GetObject("btn_rom_rename.BackgroundImage"), System.Drawing.Image)
        Me.btn_rom_rename.Location = New System.Drawing.Point(0, 0)
        Me.btn_rom_rename.Name = "btn_rom_rename"
        Me.btn_rom_rename.Size = New System.Drawing.Size(125, 30)
        Me.btn_rom_rename.TabIndex = 0
        Me.btn_rom_rename.TabStop = False
        '
        'checkbox_filepath
        '
        Me.checkbox_filepath.AutoSize = True
        Me.checkbox_filepath.Font = New System.Drawing.Font("Gotham Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.checkbox_filepath.Location = New System.Drawing.Point(40, 85)
        Me.checkbox_filepath.Name = "checkbox_filepath"
        Me.checkbox_filepath.Size = New System.Drawing.Size(167, 22)
        Me.checkbox_filepath.TabIndex = 10
        Me.checkbox_filepath.Text = "Show full file path"
        Me.checkbox_filepath.UseVisualStyleBackColor = True
        '
        'btn_import_roms
        '
        Me.btn_import_roms.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_import_roms.BackgroundImage = CType(resources.GetObject("btn_import_roms.BackgroundImage"), System.Drawing.Image)
        Me.btn_import_roms.Location = New System.Drawing.Point(956, 6)
        Me.btn_import_roms.Name = "btn_import_roms"
        Me.btn_import_roms.Size = New System.Drawing.Size(139, 36)
        Me.btn_import_roms.TabIndex = 5
        Me.btn_import_roms.TabStop = False
        '
        'listbox_installedroms
        '
        Me.listbox_installedroms.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.listbox_installedroms.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.listbox_installedroms.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.installed_name, Me.installed_platform, Me.installed_directory})
        Me.listbox_installedroms.Font = New System.Drawing.Font("Gotham Bold", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.listbox_installedroms.ForeColor = System.Drawing.Color.Black
        Me.listbox_installedroms.HideSelection = False
        Me.listbox_installedroms.Location = New System.Drawing.Point(40, 120)
        Me.listbox_installedroms.MultiSelect = False
        Me.listbox_installedroms.Name = "listbox_installedroms"
        Me.listbox_installedroms.Size = New System.Drawing.Size(1055, 735)
        Me.listbox_installedroms.TabIndex = 4
        Me.listbox_installedroms.UseCompatibleStateImageBehavior = False
        Me.listbox_installedroms.View = System.Windows.Forms.View.Details
        '
        'installed_name
        '
        Me.installed_name.Text = "Name"
        Me.installed_name.Width = 120
        '
        'installed_platform
        '
        Me.installed_platform.Text = "Platform"
        Me.installed_platform.Width = 120
        '
        'installed_directory
        '
        Me.installed_directory.Text = ""
        Me.installed_directory.Width = 0
        '
        'lbl_play
        '
        Me.lbl_play.AutoSize = True
        Me.lbl_play.Font = New System.Drawing.Font("Gotham Bold", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_play.Location = New System.Drawing.Point(30, 38)
        Me.lbl_play.Name = "lbl_play"
        Me.lbl_play.Size = New System.Drawing.Size(99, 44)
        Me.lbl_play.TabIndex = 1
        Me.lbl_play.Text = "Play"
        '
        'panel_browse
        '
        Me.panel_browse.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panel_browse.Controls.Add(Me.listbox_availableroms)
        Me.panel_browse.Controls.Add(Me.btn_import)
        Me.panel_browse.Controls.Add(Me.lbl_browse)
        Me.panel_browse.Location = New System.Drawing.Point(250, 40)
        Me.panel_browse.Name = "panel_browse"
        Me.panel_browse.Size = New System.Drawing.Size(1100, 860)
        Me.panel_browse.TabIndex = 5
        '
        'listbox_availableroms
        '
        Me.listbox_availableroms.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.listbox_availableroms.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.listbox_availableroms.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.column_name, Me.column_size, Me.column_platform, Me.column_source, Me.column_url})
        Me.listbox_availableroms.Font = New System.Drawing.Font("Gotham Bold", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.listbox_availableroms.ForeColor = System.Drawing.Color.Black
        Me.listbox_availableroms.HideSelection = False
        Me.listbox_availableroms.Location = New System.Drawing.Point(40, 120)
        Me.listbox_availableroms.Name = "listbox_availableroms"
        Me.listbox_availableroms.Size = New System.Drawing.Size(1055, 736)
        Me.listbox_availableroms.TabIndex = 3
        Me.listbox_availableroms.UseCompatibleStateImageBehavior = False
        Me.listbox_availableroms.View = System.Windows.Forms.View.Details
        '
        'column_name
        '
        Me.column_name.Text = "Name"
        Me.column_name.Width = 120
        '
        'column_size
        '
        Me.column_size.Tag = ""
        Me.column_size.Text = "Size"
        Me.column_size.Width = 120
        '
        'column_platform
        '
        Me.column_platform.Text = "Platform"
        Me.column_platform.Width = 120
        '
        'column_source
        '
        Me.column_source.Text = "Source"
        Me.column_source.Width = 120
        '
        'column_url
        '
        Me.column_url.Text = ""
        Me.column_url.Width = 0
        '
        'btn_import
        '
        Me.btn_import.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_import.BackgroundImage = CType(resources.GetObject("btn_import.BackgroundImage"), System.Drawing.Image)
        Me.btn_import.Location = New System.Drawing.Point(994, 6)
        Me.btn_import.Name = "btn_import"
        Me.btn_import.Size = New System.Drawing.Size(100, 36)
        Me.btn_import.TabIndex = 2
        Me.btn_import.TabStop = False
        '
        'lbl_browse
        '
        Me.lbl_browse.AutoSize = True
        Me.lbl_browse.Font = New System.Drawing.Font("Gotham Bold", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_browse.Location = New System.Drawing.Point(30, 38)
        Me.lbl_browse.Name = "lbl_browse"
        Me.lbl_browse.Size = New System.Drawing.Size(158, 44)
        Me.lbl_browse.TabIndex = 0
        Me.lbl_browse.Text = "Browse"
        '
        'import_list
        '
        Me.import_list.FileName = "Roms here"
        '
        'main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1600, 900)
        Me.Controls.Add(Me.panel_top)
        Me.Controls.Add(Me.panel_right)
        Me.Controls.Add(Me.panel_left)
        Me.Controls.Add(Me.panel_play)
        Me.Controls.Add(Me.panel_browse)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "main"
        Me.Text = "Emuloader"
        CType(Me.image_logo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panel_left.ResumeLayout(False)
        Me.panel_left.PerformLayout()
        CType(Me.picturebox_tungsten, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tab_browse, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btn_newemu, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panel_right.ResumeLayout(False)
        Me.panel_right.PerformLayout()
        Me.panel_rom_info.ResumeLayout(False)
        Me.panel_rom_info.PerformLayout()
        CType(Me.btn_queue, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btn_play, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panel_top.ResumeLayout(False)
        Me.panel_top.PerformLayout()
        Me.paneL_menubar.ResumeLayout(False)
        CType(Me.btn_about, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panel_play.ResumeLayout(False)
        Me.panel_play.PerformLayout()
        Me.panel_rom_rightclick.ResumeLayout(False)
        CType(Me.btn_rom_delete, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btn_rom_rename, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btn_import_roms, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panel_browse.ResumeLayout(False)
        Me.panel_browse.PerformLayout()
        CType(Me.btn_import, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents image_logo As PictureBox
    Friend WithEvents panel_left As Panel
    Friend WithEvents panel_right As Panel
    Friend WithEvents panel_top As Panel
    Friend WithEvents btn_about As PictureBox
    Friend WithEvents paneL_menubar As Panel
    Friend WithEvents btn_maximise As Panel
    Friend WithEvents btn_minimise As Panel
    Friend WithEvents btn_exit As Panel
    Friend WithEvents btn_newemu As PictureBox
    Friend WithEvents tab_browse As PictureBox
    Friend WithEvents btn_browse As Label
    Friend WithEvents lbl_library As Label
    Friend WithEvents emu_three As Label
    Friend WithEvents emu_two As Label
    Friend WithEvents emu_one As Label
    Friend WithEvents lbl_status As Label
    Friend WithEvents lbl_information As Label
    Friend WithEvents panel_seperator As Panel
    Friend WithEvents lbl_name As Label
    Friend WithEvents lbl_installedon As Label
    Friend WithEvents lbl_platform As Label
    Friend WithEvents lbl_about As Label
    Friend WithEvents lbl_patreon As Label
    Friend WithEvents lbl_github As Label
    Friend WithEvents lbl_twitter As Label
    Friend WithEvents lbl_licensing As Label
    Friend WithEvents btn_play As PictureBox
    Friend WithEvents panel_play As Panel
    Friend WithEvents panel_browse As Panel
    Friend WithEvents lbl_browse As Label
    Friend WithEvents picturebox_tungsten As PictureBox
    Friend WithEvents btn_import As PictureBox
    Friend WithEvents import_list As OpenFileDialog
    Friend WithEvents panel_rom_info As Panel
    Friend WithEvents listbox_availableroms As ListView
    Friend WithEvents column_name As ColumnHeader
    Friend WithEvents column_size As ColumnHeader
    Friend WithEvents column_source As ColumnHeader
    Friend WithEvents column_platform As ColumnHeader
    Friend WithEvents lbl_rom_platform As Label
    Friend WithEvents lbl_rom_name As Label
    Friend WithEvents column_url As ColumnHeader
    Friend WithEvents btn_queue As PictureBox
    Friend WithEvents listbox_installedroms As ListView
    Friend WithEvents installed_name As ColumnHeader
    Friend WithEvents installed_platform As ColumnHeader
    Friend WithEvents lbl_play As Label
    Friend WithEvents checkbox_fullscreen As CheckBox
    Friend WithEvents emu_nine As Label
    Friend WithEvents emu_eight As Label
    Friend WithEvents emu_seven As Label
    Friend WithEvents emu_six As Label
    Friend WithEvents emu_five As Label
    Friend WithEvents emu_four As Label
    Friend WithEvents btn_import_roms As PictureBox
    Friend WithEvents installed_directory As ColumnHeader
    Friend WithEvents checkbox_filepath As CheckBox
    Friend WithEvents panel_rom_rightclick As Panel
    Friend WithEvents btn_rom_rename As PictureBox
    Friend WithEvents btn_rom_delete As PictureBox
End Class
