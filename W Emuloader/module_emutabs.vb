Module module_emutabs
    Public Class emu_tab_metadata_list
        Public Shared emu_one_metadata As String()
        Public Shared emu_two_metadata As String()
        Public Shared emu_three_metadata As String()
        Public Shared emu_four_metadata As String()
        Public Shared emu_five_metadata As String()
        Public Shared emu_six_metadata As String()
        Public Shared emu_seven_metadata As String()
        Public Shared emu_eight_metadata As String()
        Public Shared emu_nine_metadata As String()
        Public Shared emutabs_metadata = {emu_one_metadata, emu_two_metadata, emu_three_metadata, emu_four_metadata, emu_five_metadata, emu_six_metadata, emu_seven_metadata, emu_eight_metadata, emu_nine_metadata}
        Public Shared tag_index As String = ""

    End Class

    Public Sub load_emutab()
        main.emu_one.ForeColor = main.labelgrey
        main.emu_two.ForeColor = main.labelgrey
        main.emu_three.ForeColor = main.labelgrey
        main.emu_four.ForeColor = main.labelgrey
        main.emu_five.ForeColor = main.labelgrey
        main.emu_six.ForeColor = main.labelgrey
        main.emu_seven.ForeColor = main.labelgrey
        main.emu_eight.ForeColor = main.labelgrey
        main.emu_nine.ForeColor = main.labelgrey


        main.currenttab_metadata = emu_tab_metadata_list.emutabs_metadata(main.tab_index)
        main.panel_rom_info.Visible = False
        Call main.hide_platform_tags()
        Call main.hide_region_tags()
        main.tab_browse.Visible = False
        main.panel_play.BringToFront()

        main.lbl_name.Text = main.currenttab_metadata(0)
        main.lbl_installedon.Text = "Installed on " & main.currenttab_metadata(2)
        main.lbl_platform.Text = "Platform: " & main.currenttab_metadata(1)
        Call load_installed_roms()
    End Sub

    Public Sub button_tags()
        main.textbox_search.Text = "Search"
        main.listbox_search.Items.Clear()
        main.btn_search_gba.BackgroundImage = System.Drawing.Image.FromFile(".\resources\searchgbablack.png")
        main.btn_search_wii.BackgroundImage = System.Drawing.Image.FromFile(".\resources\searchwiiblack.png")
        main.btn_search_nds.BackgroundImage = System.Drawing.Image.FromFile(".\resources\searchndsblack.png")
        main.btn_search_3ds.BackgroundImage = System.Drawing.Image.FromFile(".\resources\search3dsblack.png")
        main.btn_search_psp.BackgroundImage = System.Drawing.Image.FromFile(".\resources\searchpspblack.png")
        main.btn_search_n64.BackgroundImage = System.Drawing.Image.FromFile(".\resources\searchn64black.png")
        main.btn_search_gbc.BackgroundImage = System.Drawing.Image.FromFile(".\resources\searchgbcblack.png")
        main.btn_search_gb.BackgroundImage = System.Drawing.Image.FromFile(".\resources\searchgbblack.png")
        main.btn_search_wiiu.BackgroundImage = System.Drawing.Image.FromFile(".\resources\searchwiiublack.png")
        main.btn_search_gc.BackgroundImage = System.Drawing.Image.FromFile(".\resources\searchgcblack.png")
        main.btn_search_ps1.BackgroundImage = System.Drawing.Image.FromFile(".\resources\searchps1black.png")
        main.btn_search_ps2.BackgroundImage = System.Drawing.Image.FromFile(".\resources\searchps2black.png")
        main.btn_search_nes.BackgroundImage = System.Drawing.Image.FromFile(".\resources\searchnesblack.png")
        main.btn_search_snes.BackgroundImage = System.Drawing.Image.FromFile(".\resources\searchsnesblack.png")
        main.btn_search_mgd.BackgroundImage = System.Drawing.Image.FromFile(".\resources\searchmgdblack.png")
        main.btn_search_dc.BackgroundImage = System.Drawing.Image.FromFile(".\resources\searchdcblack.png")
        main.btn_search_europe.BackgroundImage = System.Drawing.Image.FromFile(".\resources\searcheuropeblack.png")
        main.btn_search_usa.BackgroundImage = System.Drawing.Image.FromFile(".\resources\searchusablack.png")
        main.btn_search_japan.BackgroundImage = System.Drawing.Image.FromFile(".\resources\searchjapanblack.png")


        For Each line In main.listbox_availableroms.Items
            If line.subitems(2).text = emu_tab_metadata_list.tag_index Then
                Dim linestring As String() = {line.subitems(0).text, line.subitems(1).text, line.subitems(2).text, line.subitems(3).text, line.subitems(4).text}
                main.listbox_search.Items.Add(New ListViewItem(linestring))
            End If

        Next

        main.listbox_search.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent)
        main.listbox_search.AutoResizeColumn(2, ColumnHeaderAutoResizeStyle.HeaderSize)
        main.listbox_search.Columns.Item(4).Width = 0
    End Sub
    Public Sub button_regions()
        main.textbox_search.Text = "Search"
        main.listbox_search.Items.Clear()
        main.btn_search_europe.BackgroundImage = System.Drawing.Image.FromFile(".\resources\searcheuropeblack.png")
        main.btn_search_usa.BackgroundImage = System.Drawing.Image.FromFile(".\resources\searchusablack.png")
        main.btn_search_japan.BackgroundImage = System.Drawing.Image.FromFile(".\resources\searchjapanblack.png")
        main.btn_search_gba.BackgroundImage = System.Drawing.Image.FromFile(".\resources\searchgbablack.png")
        main.btn_search_wii.BackgroundImage = System.Drawing.Image.FromFile(".\resources\searchwiiblack.png")
        main.btn_search_nds.BackgroundImage = System.Drawing.Image.FromFile(".\resources\searchndsblack.png")
        main.btn_search_3ds.BackgroundImage = System.Drawing.Image.FromFile(".\resources\search3dsblack.png")
        main.btn_search_psp.BackgroundImage = System.Drawing.Image.FromFile(".\resources\searchpspblack.png")
        main.btn_search_n64.BackgroundImage = System.Drawing.Image.FromFile(".\resources\searchn64black.png")
        main.btn_search_gbc.BackgroundImage = System.Drawing.Image.FromFile(".\resources\searchgbcblack.png")
        main.btn_search_gb.BackgroundImage = System.Drawing.Image.FromFile(".\resources\searchgbblack.png")
        main.btn_search_wiiu.BackgroundImage = System.Drawing.Image.FromFile(".\resources\searchwiiublack.png")
        main.btn_search_gc.BackgroundImage = System.Drawing.Image.FromFile(".\resources\searchgcblack.png")
        main.btn_search_ps1.BackgroundImage = System.Drawing.Image.FromFile(".\resources\searchps1black.png")
        main.btn_search_ps2.BackgroundImage = System.Drawing.Image.FromFile(".\resources\searchps2black.png")
        main.btn_search_nes.BackgroundImage = System.Drawing.Image.FromFile(".\resources\searchnesblack.png")
        main.btn_search_snes.BackgroundImage = System.Drawing.Image.FromFile(".\resources\searchsnesblack.png")
        main.btn_search_mgd.BackgroundImage = System.Drawing.Image.FromFile(".\resources\searchmgdblack.png")
        main.btn_search_dc.BackgroundImage = System.Drawing.Image.FromFile(".\resources\searchdcblack.png")

        If emu_tab_metadata_list.tag_index = "EUR" Then
            For Each line In main.listbox_availableroms.Items
                If line.subitems(0).text.contains("Europe") Or line.subitems(0).text.contains("(E)") Or line.subitems(0).text.contains("EUR") Or line.subitems(0).text.contains("Europe") Or line.subitems(0).text.contains("(F)") Or line.subitems(0).text.contains("(e)") Then
                    Dim linestring As String() = {line.subitems(0).text, line.subitems(1).text, line.subitems(2).text, line.subitems(3).text, line.subitems(4).text}
                    main.listbox_search.Items.Add(New ListViewItem(linestring))
                End If

            Next
        End If

        If emu_tab_metadata_list.tag_index = "USA" Then
            For Each line In main.listbox_availableroms.Items
                If line.subitems(0).text.contains("USA") Or line.subitems(0).text.contains("(U)") Or line.subitems(0).text.contains("usa") Or line.subitems(0).text.contains("(u)") Or line.subitems(0).text.contains("(usa)") Then
                    Dim linestring As String() = {line.subitems(0).text, line.subitems(1).text, line.subitems(2).text, line.subitems(3).text, line.subitems(4).text}
                    main.listbox_search.Items.Add(New ListViewItem(linestring))
                End If

            Next
        End If

        If emu_tab_metadata_list.tag_index = "JPN" Then
            For Each line In main.listbox_availableroms.Items
                If line.subitems(0).text.contains("JPN") Or line.subitems(0).text.contains("(J)") Or line.subitems(0).text.contains("japan") Or line.subitems(0).text.contains("(j)") Or line.subitems(0).text.contains("(Japan)") Then
                    Dim linestring As String() = {line.subitems(0).text, line.subitems(1).text, line.subitems(2).text, line.subitems(3).text, line.subitems(4).text}
                    main.listbox_search.Items.Add(New ListViewItem(linestring))
                End If

            Next
        End If

        main.listbox_search.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent)
        main.listbox_search.AutoResizeColumn(2, ColumnHeaderAutoResizeStyle.HeaderSize)
        main.listbox_search.Columns.Item(4).Width = 0
    End Sub
End Module
