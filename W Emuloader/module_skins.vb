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
    End Sub
End Module
