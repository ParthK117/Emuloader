Imports System.IO
Module module_skins
    Public Sub darkmode()
        main.BackColor = Color.FromArgb(21, 32, 43)
        main.panel_left.BackColor = Color.FromArgb(31, 45, 58)
        main.panel_right.BackColor = Color.FromArgb(31, 45, 58)
        main.listbox_availableroms.BackColor = Color.FromArgb(21, 32, 43)
        main.listbox_installedroms.BackColor = Color.FromArgb(21, 32, 43)
        main.listbox_installedroms.ForeColor = Color.White
        main.listbox_availableroms.ForeColor = Color.White
        main.lbl_play.ForeColor = Color.FromArgb(23, 191, 99)
        main.lbl_browse.ForeColor = Color.FromArgb(23, 191, 99)
        main.checkbox_filepath.ForeColor = Color.White
        main.checkbox_fullscreen.ForeColor = Color.White
        main.btn_browse.ForeColor = Color.FromArgb(23, 191, 99)
        main.tab_browse.BackColor = Color.FromArgb(23, 191, 99)
        main.tab_search.BackColor = Color.FromArgb(23, 191, 99)
        main.tab_all.BackColor = Color.FromArgb(23, 191, 99)
        main.listbox_search.BackColor = Color.FromArgb(21, 32, 43)
        main.textbox_search.BackColor = Color.FromArgb(21, 32, 43)
        main.textbox_search.ForeColor = Color.White
        main.btn_all.ForeColor = Color.FromArgb(23, 191, 99)
        main.listbox_search.ForeColor = Color.White
        main.panel_top.BackColor = Color.FromArgb(37, 51, 64)
        main.paneL_menubar.BackgroundImage = System.Drawing.Image.FromFile(".\resources\exitdark.png")
        main.lbl_status.ForeColor = Color.White
        main.picturebox_loading.Image = System.Drawing.Image.FromFile(".\resources\loadingdark.gif")
        newemulator.BackColor = Color.FromArgb(21, 32, 43)
        newemulator.listbox_emulators.BackColor = Color.FromArgb(31, 45, 58)
        newemulator.textbox_search.BackColor = Color.FromArgb(31, 45, 58)
        newemulator.listbox_emulators.ForeColor = Color.White
        newemulator.textbox_search.ForeColor = Color.White
        newemulator.lbl_emulator_name.ForeColor = Color.White
        newemulator.lbl_platform.ForeColor = Color.White
        newemulator.lbl_source.ForeColor = Color.White
        newemulator.lbl_version_number.ForeColor = Color.White
        main.lbl_sortby.ForeColor = Color.White
        main.lbl_tags.ForeColor = Color.White
        main.lbl_region.ForeColor = Color.White
        main.lbl_downloads.ForeColor = Color.FromArgb(23, 191, 99)
        main.listbox_queue.BackColor = Color.FromArgb(21, 32, 43)
        main.listbox_queue.ForeColor = Color.White
        main.lbl_speed.ForeColor = Color.White
        main.lbl_peak.ForeColor = Color.White
        main.lbl_total.ForeColor = Color.White
        settings.BackColor = Color.FromArgb(21, 32, 43)
        settings.load_boxart_on_startup.ForeColor = Color.White
        settings.load_skin.ForeColor = Color.White
        settings.listbox_settings.BackColor = Color.FromArgb(21, 32, 43)
        settings.listbox_settings.ForeColor = Color.White
        settings.lbl_settingstitle.ForeColor = Color.FromArgb(23, 191, 99)
        settings.checkbox_autoupdate.ForeColor = Color.White
        settings.checkbox_exit_on_taskbar.ForeColor = Color.White
        parameters.BackColor = Color.FromArgb(21, 32, 43)
        parameters.lbl_params_title.ForeColor = Color.FromArgb(23, 191, 99)
        settings.checkbox_fancy.ForeColor = Color.White
        main.lbl_last_played.ForeColor = Color.White
        main.lbl_rom_top_name.ForeColor = Color.White
        main.btn_opentop.BackgroundImage = System.Drawing.Image.FromFile(".\resources\opentopdark.png")
        main.btn_openright.BackgroundImage = System.Drawing.Image.FromFile(".\resources\openrightdark.png")
        main.btn_openright_downloads.BackgroundImage = System.Drawing.Image.FromFile(".\resources\openrightdark.png")
        main.btn_openright_browse.BackgroundImage = System.Drawing.Image.FromFile(".\resources\openrightdark.png")
        main.btn_closetop.BackgroundImage = System.Drawing.Image.FromFile(".\resources\closetopdark.png")
        main.btn_closeright.BackgroundImage = System.Drawing.Image.FromFile(".\resources\closerightdark.png")
        Dim settings2 As New List(Of String)
        settings2.AddRange(File.ReadAllLines(".\settings.dat"))
        If settings2(5).Contains("1") Then
            main.panel_download_chart.Location = New Point(0, 85)
            main.lbl_networkusage.Location = New Point(912, 15)
            main.lbl_speed.Location = New Point(849, 36)
            main.lbl_peak.Location = New Point(887, 59)
            main.lbl_total.Location = New Point(891, 82)
            main.picturebox_download.Image = System.Drawing.Image.FromFile(".\resources\wavyblack.gif")
            main.lbl_downloads.BringToFront()
            main.listbox_queue.Height = 592
            main.listbox_queue.Location = New Point(3, 267)
        Else
            main.panel_download_chart.Location = New Point(0, 0)
            main.lbl_networkusage.Location = New Point(912, 59)
            main.lbl_speed.Location = New Point(849, 82)
            main.lbl_peak.Location = New Point(887, 105)
            main.lbl_total.Location = New Point(891, 129)
            main.picturebox_download.Image = System.Drawing.Image.FromFile(".\resources\rainydark.gif")
            main.lbl_downloads.BringToFront()
            main.listbox_queue.Height = 677
            main.listbox_queue.Location = New Point(3, 181)
        End If
    End Sub
    Public Sub lightmode()
        main.BackColor = Color.White
        main.panel_left.BackColor = Color.FromArgb(247, 249, 250)
        main.panel_right.BackColor = Color.FromArgb(247, 249, 250)
        main.listbox_availableroms.BackColor = Color.White
        main.listbox_installedroms.BackColor = Color.White
        main.listbox_installedroms.ForeColor = Color.Black
        main.listbox_availableroms.ForeColor = Color.Black
        main.lbl_play.ForeColor = Color.Black
        main.lbl_browse.ForeColor = Color.Black
        main.checkbox_filepath.ForeColor = Color.Black
        main.checkbox_fullscreen.ForeColor = Color.Black
        main.btn_browse.ForeColor = Color.Black
        main.tab_browse.BackColor = Color.Black
        main.tab_search.BackColor = Color.Black
        main.tab_all.BackColor = Color.Black
        main.listbox_search.BackColor = Color.White
        main.textbox_search.BackColor = Color.White
        main.textbox_search.ForeColor = Color.Black
        main.btn_all.ForeColor = Color.Black
        main.listbox_search.ForeColor = Color.Black
        main.panel_top.BackColor = Color.FromArgb(238, 238, 238)
        main.paneL_menubar.BackgroundImage = System.Drawing.Image.FromFile(".\resources\exit.png")
        main.lbl_status.ForeColor = Color.Black
        main.picturebox_loading.Image = System.Drawing.Image.FromFile(".\resources\loading.gif")
        newemulator.BackColor = Color.White
        newemulator.listbox_emulators.BackColor = Color.White
        newemulator.textbox_search.BackColor = Color.White
        newemulator.listbox_emulators.ForeColor = Color.Black
        newemulator.textbox_search.ForeColor = Color.Black
        newemulator.lbl_emulator_name.ForeColor = Color.Black
        newemulator.lbl_platform.ForeColor = Color.Black
        newemulator.lbl_source.ForeColor = Color.Black
        newemulator.lbl_version_number.ForeColor = Color.Black
        main.lbl_sortby.ForeColor = Color.Black
        main.lbl_region.ForeColor = Color.Black
        main.lbl_downloads.ForeColor = Color.Black
        main.listbox_queue.BackColor = Color.White
        main.listbox_queue.ForeColor = Color.Black
        main.lbl_speed.ForeColor = Color.Black
        main.lbl_peak.ForeColor = Color.Black
        main.lbl_total.ForeColor = Color.Black
        settings.BackColor = Color.White
        settings.load_boxart_on_startup.ForeColor = Color.Black
        settings.load_skin.ForeColor = Color.Black
        settings.listbox_settings.BackColor = Color.White
        settings.listbox_settings.ForeColor = Color.Black
        settings.lbl_settingstitle.ForeColor = Color.Black
        settings.checkbox_autoupdate.ForeColor = Color.Black
        settings.checkbox_exit_on_taskbar.ForeColor = Color.Black
        parameters.BackColor = Color.White
        parameters.lbl_params_title.ForeColor = Color.Black
        settings.checkbox_fancy.ForeColor = Color.Black
        main.lbl_last_played.ForeColor = Color.Black
        main.lbl_rom_top_name.ForeColor = Color.Black
        main.btn_opentop.BackgroundImage = System.Drawing.Image.FromFile(".\resources\opentop.png")
        main.btn_openright.BackgroundImage = System.Drawing.Image.FromFile(".\resources\openright.png")
        main.btn_openright_downloads.BackgroundImage = System.Drawing.Image.FromFile(".\resources\openright.png")
        main.btn_openright_browse.BackgroundImage = System.Drawing.Image.FromFile(".\resources\openright.png")
        main.btn_closetop.BackgroundImage = System.Drawing.Image.FromFile(".\resources\closetop.png")
        main.btn_closeright.BackgroundImage = System.Drawing.Image.FromFile(".\resources\closeright.png")
        Dim settings2 As New List(Of String)
        settings2.AddRange(File.ReadAllLines(".\settings.dat"))
        If settings2(5).Contains("1") Then
            main.panel_download_chart.Location = New Point(0, 85)
            main.lbl_networkusage.Location = New Point(912, 15)
            main.lbl_speed.Location = New Point(849, 36)
            main.lbl_peak.Location = New Point(887, 59)
            main.lbl_total.Location = New Point(891, 82)
            main.picturebox_download.Image = System.Drawing.Image.FromFile(".\resources\wavywhite.gif")
            main.lbl_downloads.BringToFront()
            main.listbox_queue.Height = 592
            main.listbox_queue.Location = New Point(3, 267)
        Else
            main.panel_download_chart.Location = New Point(0, 0)
            main.lbl_networkusage.Location = New Point(912, 59)
            main.lbl_speed.Location = New Point(849, 82)
            main.lbl_peak.Location = New Point(887, 105)
            main.lbl_total.Location = New Point(891, 129)
            main.picturebox_download.Image = System.Drawing.Image.FromFile(".\resources\rainylight.gif")
            main.lbl_downloads.BringToFront()
            main.listbox_queue.Height = 677
            main.listbox_queue.Location = New Point(3, 181)
        End If

    End Sub

    Public Sub darkermode()
        main.BackColor = Color.FromArgb(25, 28, 40)
        main.panel_left.BackColor = Color.FromArgb(32, 37, 52)
        main.panel_right.BackColor = Color.FromArgb(32, 37, 52)
        main.listbox_availableroms.BackColor = Color.FromArgb(25, 28, 40)
        main.listbox_installedroms.BackColor = Color.FromArgb(25, 28, 40)
        main.listbox_installedroms.ForeColor = Color.White
        main.listbox_availableroms.ForeColor = Color.White
        main.lbl_play.ForeColor = Color.White
        main.lbl_browse.ForeColor = Color.White
        main.checkbox_filepath.ForeColor = Color.White
        main.checkbox_fullscreen.ForeColor = Color.White
        main.btn_browse.ForeColor = Color.White
        main.tab_browse.BackColor = Color.White
        main.tab_search.BackColor = Color.White
        main.tab_all.BackColor = Color.White
        main.listbox_search.BackColor = Color.FromArgb(25, 28, 40)
        main.textbox_search.BackColor = Color.FromArgb(25, 28, 40)
        main.textbox_search.ForeColor = Color.White
        main.btn_all.ForeColor = Color.White
        main.listbox_search.ForeColor = Color.White
        main.panel_top.BackColor = Color.FromArgb(32, 37, 52)
        main.paneL_menubar.BackgroundImage = System.Drawing.Image.FromFile(".\resources\exitdarker.png")
        main.lbl_status.ForeColor = Color.White
        main.picturebox_loading.Image = System.Drawing.Image.FromFile(".\resources\loadingdarker.gif")
        newemulator.BackColor = Color.FromArgb(25, 28, 40)
        newemulator.listbox_emulators.BackColor = Color.FromArgb(25, 28, 40)
        newemulator.textbox_search.BackColor = Color.FromArgb(25, 28, 40)
        newemulator.listbox_emulators.ForeColor = Color.White
        newemulator.textbox_search.ForeColor = Color.White
        newemulator.lbl_emulator_name.ForeColor = Color.White
        newemulator.lbl_platform.ForeColor = Color.White
        newemulator.lbl_source.ForeColor = Color.White
        newemulator.lbl_version_number.ForeColor = Color.White
        main.lbl_sortby.ForeColor = Color.White
        main.lbl_tags.ForeColor = Color.White
        main.lbl_region.ForeColor = Color.White
        main.lbl_downloads.ForeColor = Color.White
        main.listbox_queue.BackColor = Color.FromArgb(25, 28, 40)
        main.listbox_queue.ForeColor = Color.White
        main.lbl_speed.ForeColor = Color.White
        main.lbl_peak.ForeColor = Color.White
        main.lbl_total.ForeColor = Color.White
        settings.BackColor = Color.FromArgb(25, 28, 40)
        settings.load_boxart_on_startup.ForeColor = Color.White
        settings.load_skin.ForeColor = Color.White
        settings.listbox_settings.BackColor = Color.FromArgb(25, 28, 40)
        settings.listbox_settings.ForeColor = Color.White
        settings.lbl_settingstitle.ForeColor = Color.White
        settings.checkbox_autoupdate.ForeColor = Color.White
        settings.checkbox_exit_on_taskbar.ForeColor = Color.White
        parameters.BackColor = Color.FromArgb(25, 28, 40)
        parameters.lbl_params_title.ForeColor = Color.White
        settings.checkbox_fancy.ForeColor = Color.White
        main.lbl_last_played.ForeColor = Color.White
        main.lbl_rom_top_name.ForeColor = Color.White
        main.btn_opentop.BackgroundImage = System.Drawing.Image.FromFile(".\resources\opentopdark.png")
        main.btn_openright.BackgroundImage = System.Drawing.Image.FromFile(".\resources\openrightdark.png")
        main.btn_openright_downloads.BackgroundImage = System.Drawing.Image.FromFile(".\resources\openrightdark.png")
        main.btn_openright_browse.BackgroundImage = System.Drawing.Image.FromFile(".\resources\openrightdark.png")
        main.btn_closetop.BackgroundImage = System.Drawing.Image.FromFile(".\resources\closetopdark.png")
        main.btn_closeright.BackgroundImage = System.Drawing.Image.FromFile(".\resources\closerightdark.png")
        Dim settings2 As New List(Of String)
        settings2.AddRange(File.ReadAllLines(".\settings.dat"))
        If settings2(5).Contains("1") Then
            main.panel_download_chart.Location = New Point(0, 85)
            main.lbl_networkusage.Location = New Point(912, 15)
            main.lbl_speed.Location = New Point(849, 36)
            main.lbl_peak.Location = New Point(887, 59)
            main.lbl_total.Location = New Point(891, 82)
            main.picturebox_download.Image = System.Drawing.Image.FromFile(".\resources\wavydarker.gif")
            main.lbl_downloads.BringToFront()
            main.listbox_queue.Height = 592
            main.listbox_queue.Location = New Point(3, 267)
        Else
            main.panel_download_chart.Location = New Point(0, 0)
            main.lbl_networkusage.Location = New Point(912, 59)
            main.lbl_speed.Location = New Point(849, 82)
            main.lbl_peak.Location = New Point(887, 105)
            main.lbl_total.Location = New Point(891, 129)
            main.picturebox_download.Image = System.Drawing.Image.FromFile(".\resources\rainydarker.gif")
            main.lbl_downloads.BringToFront()
            main.listbox_queue.Height = 677
            main.listbox_queue.Location = New Point(3, 181)
        End If
    End Sub

    Public Sub darkestmode()
        main.BackColor = Color.FromArgb(12, 12, 12)
        main.panel_left.BackColor = Color.FromArgb(12, 12, 12)
        main.panel_right.BackColor = Color.FromArgb(12, 12, 12)
        main.listbox_availableroms.BackColor = Color.FromArgb(12, 12, 12)
        main.listbox_installedroms.BackColor = Color.FromArgb(12, 12, 12)
        main.listbox_installedroms.ForeColor = Color.White
        main.listbox_availableroms.ForeColor = Color.White
        main.lbl_play.ForeColor = Color.White
        main.lbl_browse.ForeColor = Color.White
        main.checkbox_filepath.ForeColor = Color.White
        main.checkbox_fullscreen.ForeColor = Color.White
        main.btn_browse.ForeColor = Color.White
        main.tab_browse.BackColor = Color.White
        main.tab_search.BackColor = Color.White
        main.tab_all.BackColor = Color.White
        main.listbox_search.BackColor = Color.FromArgb(12, 12, 12)
        main.textbox_search.BackColor = Color.FromArgb(12, 12, 12)
        main.textbox_search.ForeColor = Color.White
        main.btn_all.ForeColor = Color.White
        main.listbox_search.ForeColor = Color.White
        main.panel_top.BackColor = Color.FromArgb(12, 12, 12)
        main.paneL_menubar.BackgroundImage = System.Drawing.Image.FromFile(".\resources\exitdarkest.png")
        main.lbl_status.ForeColor = Color.White
        main.picturebox_loading.Image = System.Drawing.Image.FromFile(".\resources\loadingdarkest.gif")
        newemulator.BackColor = Color.FromArgb(25, 28, 40)
        newemulator.listbox_emulators.BackColor = Color.FromArgb(40, 40, 40)
        newemulator.textbox_search.BackColor = Color.FromArgb(40, 40, 40)
        newemulator.listbox_emulators.ForeColor = Color.White
        newemulator.textbox_search.ForeColor = Color.White
        newemulator.lbl_emulator_name.ForeColor = Color.White
        newemulator.lbl_platform.ForeColor = Color.White
        newemulator.lbl_source.ForeColor = Color.White
        newemulator.lbl_version_number.ForeColor = Color.White
        main.lbl_sortby.ForeColor = Color.White
        main.lbl_tags.ForeColor = Color.White
        main.lbl_region.ForeColor = Color.White
        main.lbl_downloads.ForeColor = Color.White
        main.listbox_queue.BackColor = Color.FromArgb(12, 12, 12)
        main.listbox_queue.ForeColor = Color.White
        main.lbl_speed.ForeColor = Color.White
        main.lbl_peak.ForeColor = Color.White
        main.lbl_total.ForeColor = Color.White
        settings.BackColor = Color.FromArgb(12, 12, 12)
        settings.load_boxart_on_startup.ForeColor = Color.White
        settings.load_skin.ForeColor = Color.White
        settings.listbox_settings.BackColor = Color.FromArgb(12, 12, 12)
        settings.listbox_settings.ForeColor = Color.White
        settings.lbl_settingstitle.ForeColor = Color.White
        settings.checkbox_autoupdate.ForeColor = Color.White
        settings.checkbox_exit_on_taskbar.ForeColor = Color.White
        parameters.BackColor = Color.FromArgb(12, 12, 12)
        parameters.lbl_params_title.ForeColor = Color.White
        settings.checkbox_fancy.ForeColor = Color.White
        main.lbl_last_played.ForeColor = Color.White
        main.lbl_rom_top_name.ForeColor = Color.White
        main.btn_opentop.BackgroundImage = System.Drawing.Image.FromFile(".\resources\opentopdark.png")
        main.btn_openright.BackgroundImage = System.Drawing.Image.FromFile(".\resources\openrightdark.png")
        main.btn_openright_downloads.BackgroundImage = System.Drawing.Image.FromFile(".\resources\openrightdark.png")
        main.btn_openright_browse.BackgroundImage = System.Drawing.Image.FromFile(".\resources\openrightdark.png")
        main.btn_closetop.BackgroundImage = System.Drawing.Image.FromFile(".\resources\closetopdark.png")
        main.btn_closeright.BackgroundImage = System.Drawing.Image.FromFile(".\resources\closerightdark.png")
        Dim settings2 As New List(Of String)
        settings2.AddRange(File.ReadAllLines(".\settings.dat"))
        If settings2(5).Contains("1") Then
            main.panel_download_chart.Location = New Point(0, 85)
            main.lbl_networkusage.Location = New Point(912, 15)
            main.lbl_speed.Location = New Point(849, 36)
            main.lbl_peak.Location = New Point(887, 59)
            main.lbl_total.Location = New Point(891, 82)
            main.picturebox_download.Image = System.Drawing.Image.FromFile(".\resources\wavydarkest.gif")
            main.lbl_downloads.BringToFront()
            main.listbox_queue.Height = 592
            main.listbox_queue.Location = New Point(3, 267)
        Else
            main.panel_download_chart.Location = New Point(0, 0)
            main.lbl_networkusage.Location = New Point(912, 59)
            main.lbl_speed.Location = New Point(849, 82)
            main.lbl_peak.Location = New Point(887, 105)
            main.lbl_total.Location = New Point(891, 129)
            main.picturebox_download.Image = System.Drawing.Image.FromFile(".\resources\rainydarkest.gif")
            main.lbl_downloads.BringToFront()
            main.listbox_queue.Height = 677
            main.listbox_queue.Location = New Point(3, 181)
        End If
    End Sub
End Module
