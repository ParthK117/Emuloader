﻿Module module_loadfonts
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
        main.gotham.AddFontFile(".\resources\gotham.ttf")
        main.opensans.AddFontFile(".\resources\opensans.ttf")

        Dim gothamfont12 As New System.Drawing.Font(main.gotham.Families(0), 12)
        main.lbl_status.Font = gothamfont12
        main.lbl_library.Font = gothamfont12
        main.lbl_socialmedia.Font = gothamfont12
        main.lbl_wiki.Font = gothamfont12

        Dim gothamfont16 As New System.Drawing.Font(main.gotham.Families(0), 16)
        main.btn_browse.Font = gothamfont16

        Dim opensansfont16 As New System.Drawing.Font(main.opensans.Families(0), 16)
        main.listbox_availableroms.Font = opensansfont16
        main.listbox_installedroms.Font = opensansfont16
        main.listbox_search.Font = opensansfont16
        main.lbl_last_played.Font = opensansfont16
        main.lbl_jumpin_emuname.Font = opensansfont16
        main.lbl_jumpin_lastplayed.Font = opensansfont16

        Dim opensansfont12 As New System.Drawing.Font(main.opensans.Families(0), 12)
        main.listbox_queue.Font = opensansfont12

        Dim opensansfont14 As New System.Drawing.Font(main.opensans.Families(0), 14)
        main.lbl_rom_name.Font = opensansfont14
        main.lbl_rom_platform.Font = opensansfont14
        main.lbl_rom_size.Font = opensansfont14
        main.lbl_installed_name.Font = opensansfont14
        main.lbl_installed_downloadtime.Font = opensansfont14
        main.lbl_installed_size.Font = opensansfont14
        main.lbl_rom_source.Font = opensansfont14
        main.lbl_name.Font = opensansfont14
        main.lbl_platform.Font = opensansfont14
        main.lbl_installedon.Font = opensansfont14
        main.textbox_search.Font = opensansfont14
        main.lbl_speed.Font = opensansfont14
        main.lbl_networkusage.Font = opensansfont14
        main.lbl_peak.Font = opensansfont14
        main.lbl_total.Font = opensansfont14

        Dim opensansfont8 As New System.Drawing.Font(main.opensans.Families(0), 9)

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
        main.lbl_rom_top_name.Font = gothamfont18

        Dim gothamfont14 As New System.Drawing.Font(main.gotham.Families(0), 14)
        main.lbl_sortby.Font = gothamfont14
        main.lbl_tags.Font = gothamfont14
        main.btn_platform_tags.Font = gothamfont14
        main.btn_search.Font = gothamfont14
        main.btn_all.Font = gothamfont14
        main.btn_region.Font = gothamfont14


        Dim gothamfont20 As New System.Drawing.Font(main.gotham.Families(0), 20)
        main.lbl_jumpin.Font = gothamfont20
        main.lbl_jumpin_romname.Font = gothamfont20
        Dim gothamfont10 As New System.Drawing.Font(main.gotham.Families(0), 10)
        main.lbl_information.Font = gothamfont10

        Dim gothamfont28 As New System.Drawing.Font(main.gotham.Families(0), 28)
        main.lbl_play.Font = gothamfont28
        main.lbl_browse.Font = gothamfont28
        main.lbl_downloads.Font = gothamfont28
        main.lbl_home.Font = gothamfont28
        Dim gothamfont11 As New System.Drawing.Font(main.gotham.Families(0), 11)
        main.lbl_about.Font = gothamfont11
        main.lbl_github.Font = gothamfont11
        main.checkbox_fullscreen.Font = gothamfont11
        main.checkbox_filepath.Font = gothamfont11
        main.checkbox_extensions.Font = gothamfont11
        main.btn_showdownloads.Font = gothamfont11

    End Sub
End Module
