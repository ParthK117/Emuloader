Module module_emutabs
    Public Sub emu_one()
        main.emu_one.ForeColor = Color.Black
        main.emu_two.ForeColor = main.labelgrey
        main.emu_three.ForeColor = main.labelgrey
        main.emu_four.ForeColor = main.labelgrey
        main.emu_five.ForeColor = main.labelgrey
        main.emu_six.ForeColor = main.labelgrey
        main.emu_seven.ForeColor = main.labelgrey
        main.emu_eight.ForeColor = main.labelgrey
        main.emu_nine.ForeColor = main.labelgrey


        main.currenttab_metadata = main.emutabs_metadata(0)
        main.panel_rom_info.Visible = False
        main.tab_browse.Visible = False
        main.panel_play.BringToFront()

        main.lbl_name.Text = main.currenttab_metadata(0)
        main.lbl_installedon.Text = "Installed on " & main.currenttab_metadata(2)
        main.lbl_platform.Text = "Platform: " & main.currenttab_metadata(1)
        Call main.load_installed_roms()
    End Sub
End Module
