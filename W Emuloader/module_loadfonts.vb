Module module_loadfonts
    Public Sub main_loadcolours()
        Dim grey As Color
        grey = Color.FromArgb(247, 249, 250)

        Dim lightgrey As Color
        lightgrey = Color.FromArgb(238, 238, 238)

        main.labelgrey = Color.FromArgb(120, 127, 142)

        main.panel_left.BackColor = grey
        main.panel_right.BackColor = grey
        main.panel_top.BackColor = lightgrey
        main.panel_seperator.BackColor = lightgrey


        main.lbl_library.ForeColor = main.labelgrey
        main.btn_search.ForeColor = main.labelgrey
        main.emu_one.ForeColor = main.labelgrey
        main.emu_two.ForeColor = main.labelgrey
        main.emu_three.ForeColor = main.labelgrey
        main.emu_four.ForeColor = main.labelgrey
        main.emu_five.ForeColor = main.labelgrey
        main.emu_six.ForeColor = main.labelgrey
        main.emu_seven.ForeColor = main.labelgrey
        main.emu_eight.ForeColor = main.labelgrey
        main.emu_nine.ForeColor = main.labelgrey


        main.lbl_information.ForeColor = main.labelgrey
        main.lbl_name.ForeColor = main.labelgrey
        main.lbl_installedon.ForeColor = main.labelgrey
        main.lbl_platform.ForeColor = main.labelgrey
        main.lbl_github.ForeColor = main.labelgrey
        main.lbl_about.ForeColor = main.labelgrey
        main.lbl_twitter.ForeColor = main.labelgrey
        main.lbl_patreon.ForeColor = main.labelgrey
        main.lbl_licensing.ForeColor = main.labelgrey
        main.lbl_rom_name.ForeColor = main.labelgrey
        main.lbl_rom_platform.ForeColor = main.labelgrey
        main.lbl_version.ForeColor = main.labelgrey
        main.btn_showdownloads.ForeColor = main.labelgrey
        main.btn_platform_tags.ForeColor = main.labelgrey
        main.btn_parameters.ForeColor = main.labelgrey
        main.btn_region.ForeColor = main.labelgrey
        main.lbl_nothing.ForeColor = main.labelgrey
        main.lbl_rom_source.ForeColor = main.labelgrey
        main.lbl_rom_size.ForeColor = main.labelgrey
        main.lbl_installed_size.ForeColor = main.labelgrey
        main.lbl_installed_name.ForeColor = main.labelgrey
        main.lbl_installed_downloadtime.ForeColor = main.labelgrey
        main.lbl_status.Location = New Point((main.panel_top.Width - main.lbl_status.Width) \ 2, (main.panel_top.Height - main.lbl_status.Height) \ 2)
        main.picturebox_tungsten.Location = New Point((main.panel_left.Width - main.picturebox_tungsten.Width) \ 2, 690)
        main.picturebox_drag.Location = New Point((main.panel_drag_drop.Width - main.picturebox_drag.Width) \ 2, (main.panel_drag_drop.Height - main.picturebox_drag.Height) \ 2)
    End Sub

    Public Sub main_loadfonts()

        main.gotham.AddFontFile(".\resources\gotham.otf")
        main.spartan.AddFontFile(".\resources\spartanmb.otf")
        Dim gothamfont12 As New System.Drawing.Font(main.gotham.Families(0), 12)
        main.lbl_status.Font = gothamfont12
        main.lbl_library.Font = gothamfont12


        Dim gothamfont16 As New System.Drawing.Font(main.gotham.Families(0), 16)
        main.btn_browse.Font = gothamfont16


        Dim spartanfont16 As New System.Drawing.Font(main.spartan.Families(0), 16)
        main.listbox_availableroms.Font = spartanfont16
        main.listbox_installedroms.Font = spartanfont16
        main.listbox_search.Font = spartanfont16


        Dim spartanfont12 As New System.Drawing.Font(main.spartan.Families(0), 12)
        main.listbox_queue.Font = spartanfont12

        Dim spartanfont14 As New System.Drawing.Font(main.spartan.Families(0), 14)
        main.lbl_rom_name.Font = spartanfont14
        main.lbl_rom_platform.Font = spartanfont14
        main.lbl_rom_size.Font = spartanfont14
        main.lbl_installed_name.Font = spartanfont14
        main.lbl_installed_downloadtime.Font = spartanfont14
        main.lbl_installed_size.Font = spartanfont14
        main.lbl_rom_source.Font = spartanfont14
        main.lbl_name.Font = spartanfont14
        main.lbl_platform.Font = spartanfont14
        main.lbl_installedon.Font = spartanfont14
        main.textbox_search.Font = spartanfont14
        main.lbl_speed.Font = spartanfont14
        main.lbl_networkusage.Font = spartanfont14
        main.lbl_peak.Font = spartanfont14
        main.lbl_total.Font = spartanfont14

        Dim gothamfont18 As New System.Drawing.Font(main.gotham.Families(0), 18)
        main.emu_one.Font = gothamfont18
        main.emu_two.Font = gothamfont18
        main.emu_three.Font = gothamfont18
        main.emu_four.Font = gothamfont18
        main.emu_five.Font = gothamfont18
        main.emu_six.Font = gothamfont18
        main.emu_seven.Font = gothamfont18
        main.emu_eight.Font = gothamfont18
        main.emu_nine.Font = gothamfont18


        Dim gothamfont14 As New System.Drawing.Font(main.gotham.Families(0), 14)
        main.lbl_sortby.Font = gothamfont14
        main.lbl_tags.Font = gothamfont14
        main.btn_platform_tags.Font = gothamfont14
        main.btn_search.Font = gothamfont14
        main.btn_all.Font = gothamfont14
        main.btn_region.Font = gothamfont14

        Dim gothamfont10 As New System.Drawing.Font(main.gotham.Families(0), 10)
        main.lbl_information.Font = gothamfont10

        Dim gothamfont28 As New System.Drawing.Font(main.gotham.Families(0), 28)
        main.lbl_play.Font = gothamfont28
        main.lbl_browse.Font = gothamfont28
        main.lbl_downloads.Font = gothamfont28

        Dim gothamfont11 As New System.Drawing.Font(main.gotham.Families(0), 11)
        main.lbl_about.Font = gothamfont11
        main.lbl_github.Font = gothamfont11
        main.lbl_twitter.Font = gothamfont11
        main.lbl_patreon.Font = gothamfont11
        main.checkbox_fullscreen.Font = gothamfont11
        main.checkbox_filepath.Font = gothamfont11
        main.btn_showdownloads.Font = gothamfont11

    End Sub
End Module
