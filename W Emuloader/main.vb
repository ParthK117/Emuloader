Imports System.Net
Imports System.IO
Imports System.IO.Compression
Public Class main
    Dim drag As Boolean
    Dim mousex As Integer
    Dim mousey As Integer
    Dim emu_one_metadata As String()
    Dim emu_two_metadata As String()
    Dim emu_three_metadata As String()
    Dim emu_four_metadata As String()
    Dim emu_five_metadata As String()
    Dim emu_six_metadata As String()
    Dim emu_seven_metadata As String()
    Dim emu_eight_metadata As String()
    Dim emu_nine_metadata As String()
    Dim emutabs_metadata = {emu_one_metadata, emu_two_metadata, emu_three_metadata, emu_four_metadata, emu_five_metadata, emu_six_metadata, emu_seven_metadata, emu_eight_metadata, emu_nine_metadata}
    Dim currenttab_metadata As String() = {"na", "na", "na", "na", "na"}
    Public Shared gotham As New System.Drawing.Text.PrivateFontCollection()
    Public Shared spartan As New System.Drawing.Text.PrivateFontCollection()

    Dim labelgrey As Color
    '0.1.0

    Private Sub main_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
        panel_play.SendToBack()
        Call loadfonts()
        Call loadconfig()
        Dim grey As Color
        grey = Color.FromArgb(247, 249, 250)

        Dim lightgrey As Color
        lightgrey = Color.FromArgb(238, 238, 238)

        labelgrey = Color.FromArgb(120, 127, 142)

        panel_left.BackColor = grey
        panel_right.BackColor = grey
        panel_top.BackColor = lightgrey
        panel_seperator.BackColor = lightgrey


        lbl_library.ForeColor = labelgrey
        btn_search.ForeColor = labelgrey
        emu_one.ForeColor = labelgrey
        emu_two.ForeColor = labelgrey
        emu_three.ForeColor = labelgrey
        emu_four.ForeColor = labelgrey
        emu_five.ForeColor = labelgrey
        emu_six.ForeColor = labelgrey
        emu_seven.ForeColor = labelgrey
        emu_eight.ForeColor = labelgrey
        emu_nine.ForeColor = labelgrey


        lbl_information.ForeColor = labelgrey
        lbl_name.ForeColor = labelgrey
        lbl_installedon.ForeColor = labelgrey
        lbl_platform.ForeColor = labelgrey
        lbl_github.ForeColor = labelgrey
        lbl_about.ForeColor = labelgrey
        lbl_twitter.ForeColor = labelgrey
        lbl_patreon.ForeColor = labelgrey
        lbl_licensing.ForeColor = labelgrey
        lbl_rom_name.ForeColor = labelgrey
        lbl_rom_platform.ForeColor = labelgrey
        lbl_version.ForeColor = labelgrey

        lbl_status.Location = New Point((panel_top.Width - lbl_status.Width) \ 2, (panel_top.Height - lbl_status.Height) \ 2)
        picturebox_tungsten.Location = New Point((panel_left.Width - picturebox_tungsten.Width) \ 2, 690)
        picturebox_drag.Location = New Point((panel_drag_drop.Width - picturebox_drag.Width) \ 2, (panel_drag_drop.Height - picturebox_drag.Height) \ 2)

        Call load_roms_list()

        Me.AllowDrop = True
    End Sub

    Private Sub panel_top_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles panel_top.MouseDown
        drag = True
        mousex = Windows.Forms.Cursor.Position.X - Me.Left
        mousey = Windows.Forms.Cursor.Position.Y - Me.Top
    End Sub
    Private Sub panel_top_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles panel_top.MouseMove
        If drag Then
            Me.Top = Windows.Forms.Cursor.Position.Y - mousey
            Me.Left = Windows.Forms.Cursor.Position.X - mousex
        End If
    End Sub
    Private Sub panel_top_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles panel_top.MouseUp
        drag = False
    End Sub



    'About button
    Private Sub btn_about_Click(sender As Object, e As EventArgs) Handles btn_about.Click

    End Sub

    Private Sub btn_about_MouseEnter(sender As Object, e As EventArgs) Handles btn_about.MouseEnter
        btn_about.BackgroundImage = System.Drawing.Image.FromFile(".\resources\settingsblack.png")
    End Sub

    Private Sub btn_about_MouseLeave(sender As Object, e As EventArgs) Handles btn_about.MouseLeave
        btn_about.BackgroundImage = System.Drawing.Image.FromFile(".\resources\settingswhite.png")
    End Sub

    Private Sub btn_about_MouseDown(sender As Object, e As MouseEventArgs) Handles btn_about.MouseDown
        btn_about.BackgroundImage = System.Drawing.Image.FromFile(".\resources\settingsclick.png")
    End Sub

    Private Sub btn_about_MouseUp(sender As Object, e As MouseEventArgs) Handles btn_about.MouseUp
        btn_about.BackgroundImage = System.Drawing.Image.FromFile(".\resources\settingsblack.png")
    End Sub


    Private Sub btn_maximise_MouseEnter(sender As Object, e As EventArgs) Handles btn_maximise.MouseEnter
        paneL_menubar.BackgroundImage = System.Drawing.Image.FromFile(".\resources\greenclick.png")
    End Sub

    Private Sub btn_maximise_MouseLeave(sender As Object, e As EventArgs) Handles btn_maximise.MouseLeave
        paneL_menubar.BackgroundImage = System.Drawing.Image.FromFile(".\resources\exit.png")
    End Sub

    Private Sub btn_minimise_MouseEnter(sender As Object, e As EventArgs) Handles btn_minimise.MouseEnter
        paneL_menubar.BackgroundImage = System.Drawing.Image.FromFile(".\resources\yellowclick.png")
    End Sub

    Private Sub btn_minimise_MouseLeave(sender As Object, e As EventArgs) Handles btn_minimise.MouseLeave
        paneL_menubar.BackgroundImage = System.Drawing.Image.FromFile(".\resources\exit.png")
    End Sub


    Private Sub btn_exit_MouseLeave(sender As Object, e As EventArgs) Handles btn_exit.MouseLeave
        paneL_menubar.BackgroundImage = System.Drawing.Image.FromFile(".\resources\exit.png")
    End Sub

    Private Sub btn_exit_MouseEnter(sender As Object, e As EventArgs) Handles btn_exit.MouseEnter
        paneL_menubar.BackgroundImage = System.Drawing.Image.FromFile(".\resources\redclick.png")
    End Sub

    Private Sub btn_newemu_MouseEnter(sender As Object, e As EventArgs) Handles btn_newemu.MouseEnter
        btn_newemu.BackgroundImage = System.Drawing.Image.FromFile(".\resources\newemuwhite.png")
    End Sub

    Private Sub btn_newemu_MouseLeave(sender As Object, e As EventArgs) Handles btn_newemu.MouseLeave
        btn_newemu.BackgroundImage = System.Drawing.Image.FromFile(".\resources\newemublack.png")

    End Sub

    Private Sub btn_newemu_MouseDown(sender As Object, e As MouseEventArgs) Handles btn_newemu.MouseDown
        GC.Collect()
        btn_newemu.BackgroundImage = System.Drawing.Image.FromFile(".\resources\newemuclick.png")
        newemulator.Show()

    End Sub

    Private Sub btn_newemu_MouseUp(sender As Object, e As MouseEventArgs) Handles btn_newemu.MouseUp
        btn_newemu.BackgroundImage = System.Drawing.Image.FromFile(".\resources\newemuwhite.png")

    End Sub
    Private Sub loadfonts()

        gotham.AddFontFile(".\resources\gotham.otf")
        spartan.AddFontFile(".\resources\spartanmb.otf")
        Dim gothamfont12 As New System.Drawing.Font(gotham.Families(0), 12)
        lbl_status.Font = gothamfont12
        lbl_library.Font = gothamfont12


        Dim gothamfont16 As New System.Drawing.Font(gotham.Families(0), 16)
        btn_browse.Font = gothamfont16


        Dim spartanfont16 As New System.Drawing.Font(spartan.Families(0), 16)
        listbox_availableroms.Font = spartanfont16
        listbox_installedroms.Font = spartanfont16
        listbox_search.Font = spartanfont16

        Dim spartanfont14 As New System.Drawing.Font(spartan.Families(0), 14)
        lbl_rom_name.Font = spartanfont14
        lbl_rom_platform.Font = spartanfont14
        lbl_name.Font = spartanfont14
        lbl_platform.Font = spartanfont14
        lbl_installedon.Font = spartanfont14
        textbox_search.Font = spartanfont14

        Dim gothamfont18 As New System.Drawing.Font(gotham.Families(0), 18)
        emu_one.Font = gothamfont18
        emu_two.Font = gothamfont18
        emu_three.Font = gothamfont18
        emu_four.Font = gothamfont18
        emu_five.Font = gothamfont18
        emu_six.Font = gothamfont18
        emu_seven.Font = gothamfont18
        emu_eight.Font = gothamfont18
        emu_nine.Font = gothamfont18


        Dim gothamfont10 As New System.Drawing.Font(gotham.Families(0), 10)
        lbl_information.Font = gothamfont10

        Dim gothamfont28 As New System.Drawing.Font(gotham.Families(0), 28)
        lbl_play.Font = gothamfont28
        lbl_browse.Font = gothamfont28

        Dim gothamfont11 As New System.Drawing.Font(gotham.Families(0), 11)
        lbl_about.Font = gothamfont11
        lbl_github.Font = gothamfont11
        lbl_twitter.Font = gothamfont11
        lbl_patreon.Font = gothamfont11
        checkbox_fullscreen.Font = gothamfont11
        checkbox_filepath.Font = gothamfont11
    End Sub
    Public Sub loadconfig()


        If File.Exists(".\installed.eldr") = True Then
            Dim installedeldr As String() = File.ReadAllLines(".\installed.eldr")
            Dim index As Integer = 0
            Dim emutabs = {emu_one, emu_two, emu_three, emu_four, emu_five, emu_six, emu_seven, emu_eight, emu_nine}

            For Each x In installedeldr
                Dim currentmetadata As String()
                If x.Contains("VBAM") Then

                    emutabs(index).Text = "VBA-M"
                    emutabs(index).Visible = True


                    currentmetadata = File.ReadAllLines(".\" & x & "\vbam.eldr")
                    emutabs_metadata(index) = currentmetadata

                End If

                If x.Contains("CITRA") Then

                    emutabs(index).Text = "Citra"
                    emutabs(index).Visible = True


                    currentmetadata = File.ReadAllLines(".\" & x & "\citra.eldr")
                    emutabs_metadata(index) = currentmetadata

                End If
                If x.Contains("DESMUME") Then

                    emutabs(index).Text = "DeSmuME"
                    emutabs(index).Visible = True


                    currentmetadata = File.ReadAllLines(".\" & x & "\desmume.eldr")
                    emutabs_metadata(index) = currentmetadata

                End If
                If x.Contains("PROJECT64") Then

                    emutabs(index).Text = "Project64"
                    emutabs(index).Visible = True


                    currentmetadata = File.ReadAllLines(".\" & x & "\project64.eldr")
                    emutabs_metadata(index) = currentmetadata

                End If
                If x.Contains("PPSSPP") Then

                    emutabs(index).Text = "PPSSPP"
                    emutabs(index).Visible = True


                    currentmetadata = File.ReadAllLines(".\" & x & "\ppsspp.eldr")
                    emutabs_metadata(index) = currentmetadata

                End If
                If x.Contains("DOLPHIN") Then

                    emutabs(index).Text = "Dolphin"
                    emutabs(index).Visible = True


                    currentmetadata = File.ReadAllLines(".\" & x & "\dolphin.eldr")
                    emutabs_metadata(index) = currentmetadata

                End If
                index = index + 1
            Next


        End If

    End Sub

    Private Sub emu_one_Click(sender As Object, e As EventArgs) Handles emu_one.Click
        emu_one.ForeColor = Color.Black
        emu_two.ForeColor = labelgrey
        emu_three.ForeColor = labelgrey
        emu_four.ForeColor = labelgrey
        emu_five.ForeColor = labelgrey
        emu_six.ForeColor = labelgrey
        emu_seven.ForeColor = labelgrey
        emu_eight.ForeColor = labelgrey
        emu_nine.ForeColor = labelgrey


        currenttab_metadata = emutabs_metadata(0)
        panel_rom_info.Visible = False
        tab_browse.Visible = False
        panel_play.BringToFront()

        lbl_name.Text = currenttab_metadata(0)
        lbl_installedon.Text = "Installed on " & currenttab_metadata(2)
        lbl_platform.Text = "Platform: " & currenttab_metadata(1)
        Call load_installed_roms()
    End Sub

    Private Sub emu_two_Click(sender As Object, e As EventArgs) Handles emu_two.Click
        emu_one.ForeColor = labelgrey
        emu_two.ForeColor = Color.Black
        emu_three.ForeColor = labelgrey
        emu_four.ForeColor = labelgrey
        emu_five.ForeColor = labelgrey
        emu_six.ForeColor = labelgrey
        emu_seven.ForeColor = labelgrey
        emu_eight.ForeColor = labelgrey
        emu_nine.ForeColor = labelgrey

        currenttab_metadata = emutabs_metadata(1)
        panel_rom_info.Visible = False
        tab_browse.Visible = False
        panel_play.BringToFront()


        lbl_name.Text = currenttab_metadata(0)
        lbl_installedon.Text = "Installed on " & currenttab_metadata(2)
        lbl_platform.Text = "Platform: " & currenttab_metadata(1)
        Call load_installed_roms()
    End Sub

    Private Sub emu_three_Click(sender As Object, e As EventArgs) Handles emu_three.Click
        emu_one.ForeColor = labelgrey
        emu_two.ForeColor = labelgrey
        emu_three.ForeColor = Color.Black
        emu_four.ForeColor = labelgrey
        emu_five.ForeColor = labelgrey
        emu_six.ForeColor = labelgrey
        emu_seven.ForeColor = labelgrey
        emu_eight.ForeColor = labelgrey
        emu_nine.ForeColor = labelgrey

        currenttab_metadata = emutabs_metadata(2)
        panel_rom_info.Visible = False
        tab_browse.Visible = False
        panel_play.BringToFront()


        lbl_name.Text = currenttab_metadata(0)
        lbl_installedon.Text = "Installed on " & currenttab_metadata(2)
        lbl_platform.Text = "Platform: " & currenttab_metadata(1)
        Call load_installed_roms()
    End Sub

    Private Sub emu_four_Click(sender As Object, e As EventArgs) Handles emu_four.Click
        emu_one.ForeColor = labelgrey
        emu_two.ForeColor = labelgrey
        emu_three.ForeColor = labelgrey
        emu_four.ForeColor = Color.Black
        emu_five.ForeColor = labelgrey
        emu_six.ForeColor = labelgrey
        emu_seven.ForeColor = labelgrey
        emu_eight.ForeColor = labelgrey
        emu_nine.ForeColor = labelgrey

        currenttab_metadata = emutabs_metadata(3)
        panel_rom_info.Visible = False
        tab_browse.Visible = False
        panel_play.BringToFront()


        lbl_name.Text = currenttab_metadata(0)
        lbl_installedon.Text = "Installed on " & currenttab_metadata(2)
        lbl_platform.Text = "Platform: " & currenttab_metadata(1)
        Call load_installed_roms()
    End Sub

    Private Sub emu_five_Click(sender As Object, e As EventArgs) Handles emu_five.Click
        emu_one.ForeColor = labelgrey
        emu_two.ForeColor = labelgrey
        emu_three.ForeColor = labelgrey
        emu_four.ForeColor = labelgrey
        emu_five.ForeColor = Color.Black
        emu_six.ForeColor = labelgrey
        emu_seven.ForeColor = labelgrey
        emu_eight.ForeColor = labelgrey
        emu_nine.ForeColor = labelgrey

        currenttab_metadata = emutabs_metadata(4)
        panel_rom_info.Visible = False
        tab_browse.Visible = False
        panel_play.BringToFront()


        lbl_name.Text = currenttab_metadata(0)
        lbl_installedon.Text = "Installed on " & currenttab_metadata(2)
        lbl_platform.Text = "Platform: " & currenttab_metadata(1)
        Call load_installed_roms()
    End Sub

    Private Sub emu_six_Click(sender As Object, e As EventArgs) Handles emu_six.Click
        emu_one.ForeColor = labelgrey
        emu_two.ForeColor = labelgrey
        emu_three.ForeColor = labelgrey
        emu_four.ForeColor = labelgrey
        emu_five.ForeColor = labelgrey
        emu_six.ForeColor = Color.Black
        emu_seven.ForeColor = labelgrey
        emu_eight.ForeColor = labelgrey
        emu_nine.ForeColor = labelgrey

        currenttab_metadata = emutabs_metadata(5)
        panel_rom_info.Visible = False
        tab_browse.Visible = False
        panel_play.BringToFront()


        lbl_name.Text = currenttab_metadata(0)
        lbl_installedon.Text = "Installed on " & currenttab_metadata(2)
        lbl_platform.Text = "Platform: " & currenttab_metadata(1)
        Call load_installed_roms()
    End Sub

    Private Sub emu_seven_Click(sender As Object, e As EventArgs) Handles emu_seven.Click
        emu_one.ForeColor = labelgrey
        emu_two.ForeColor = labelgrey
        emu_three.ForeColor = labelgrey
        emu_four.ForeColor = labelgrey
        emu_five.ForeColor = labelgrey
        emu_six.ForeColor = labelgrey
        emu_seven.ForeColor = Color.Black
        emu_eight.ForeColor = labelgrey
        emu_nine.ForeColor = labelgrey

        currenttab_metadata = emutabs_metadata(6)
        panel_rom_info.Visible = False
        tab_browse.Visible = False
        panel_play.BringToFront()


        lbl_name.Text = currenttab_metadata(0)
        lbl_installedon.Text = "Installed on " & currenttab_metadata(2)
        lbl_platform.Text = "Platform: " & currenttab_metadata(1)
        Call load_installed_roms()
    End Sub

    Private Sub emu_eight_Click(sender As Object, e As EventArgs) Handles emu_eight.Click
        emu_one.ForeColor = labelgrey
        emu_two.ForeColor = labelgrey
        emu_three.ForeColor = labelgrey
        emu_four.ForeColor = labelgrey
        emu_five.ForeColor = labelgrey
        emu_six.ForeColor = labelgrey
        emu_seven.ForeColor = labelgrey
        emu_eight.ForeColor = Color.Black
        emu_nine.ForeColor = labelgrey

        currenttab_metadata = emutabs_metadata(7)
        panel_rom_info.Visible = False
        tab_browse.Visible = False
        panel_play.BringToFront()


        lbl_name.Text = currenttab_metadata(0)
        lbl_installedon.Text = "Installed on " & currenttab_metadata(2)
        lbl_platform.Text = "Platform: " & currenttab_metadata(1)
        Call load_installed_roms()
    End Sub

    Private Sub emu_nine_Click(sender As Object, e As EventArgs) Handles emu_nine.Click
        emu_one.ForeColor = labelgrey
        emu_two.ForeColor = labelgrey
        emu_three.ForeColor = labelgrey
        emu_four.ForeColor = labelgrey
        emu_five.ForeColor = labelgrey
        emu_six.ForeColor = labelgrey
        emu_seven.ForeColor = labelgrey
        emu_eight.ForeColor = labelgrey
        emu_nine.ForeColor = Color.Black

        currenttab_metadata = emutabs_metadata(8)
        panel_rom_info.Visible = False
        tab_browse.Visible = False
        panel_play.BringToFront()


        lbl_name.Text = currenttab_metadata(0)
        lbl_installedon.Text = "Installed on " & currenttab_metadata(2)
        lbl_platform.Text = "Platform: " & currenttab_metadata(1)
        Call load_installed_roms()
    End Sub
    Private Sub btn_play_MouseEnter(sender As Object, e As EventArgs) Handles btn_play.MouseEnter
        btn_play.BackgroundImage = System.Drawing.Image.FromFile(".\resources\playwhite.png")
    End Sub

    Private Sub btn_play_MouseLeave(sender As Object, e As EventArgs) Handles btn_play.MouseLeave
        btn_play.BackgroundImage = System.Drawing.Image.FromFile(".\resources\playblack.png")
    End Sub

    Private Sub btn_play_MouseDown(sender As Object, e As MouseEventArgs) Handles btn_play.MouseDown
        btn_play.BackgroundImage = System.Drawing.Image.FromFile(".\resources\playclick.png")




        Dim emulator As Process
        Dim p As New ProcessStartInfo


        p.FileName = (".\" & currenttab_metadata(4) & "\" & currenttab_metadata(3))

        If currenttab_metadata(1) = "GBA" Then

            Dim rom_path As String = System.IO.Path.GetFullPath(listbox_installedroms.FocusedItem.SubItems(2).Text)
            p.Arguments = ("""" & rom_path & """")
        ElseIf currenttab_metadata(1) = "3DS" Then


            Dim rom_path As String = System.IO.Path.GetFullPath(listbox_installedroms.FocusedItem.SubItems(2).Text)
            p.Arguments = ("""" & rom_path & """")
        ElseIf currenttab_metadata(1) = "NDS" Then


            Dim rom_path As String = System.IO.Path.GetFullPath(listbox_installedroms.FocusedItem.SubItems(2).Text)
            p.Arguments = ("""" & rom_path & """")
        ElseIf currenttab_metadata(1) = "N64" Then


            Dim rom_path As String = System.IO.Path.GetFullPath(listbox_installedroms.FocusedItem.SubItems(2).Text)
            p.Arguments = ("""" & rom_path & """")
        ElseIf currenttab_metadata(1) = "PSP" Then


            Dim rom_path As String = System.IO.Path.GetFullPath(listbox_installedroms.FocusedItem.SubItems(2).Text)
            p.Arguments = ("""" & rom_path & """")
        ElseIf currenttab_metadata(1) = "WII" Then


            Dim rom_path As String = System.IO.Path.GetFullPath(listbox_installedroms.FocusedItem.SubItems(2).Text)
            p.Arguments = ("""" & rom_path & """")
        End If




        If checkbox_fullscreen.Checked = True Then
            p.WindowStyle = ProcessWindowStyle.Maximized

        Else
            p.WindowStyle = ProcessWindowStyle.Normal

        End If

        emulator = Process.Start(p)
    End Sub

    Private Sub btn_play_MouseUp(sender As Object, e As MouseEventArgs) Handles btn_play.MouseUp
        btn_play.BackgroundImage = System.Drawing.Image.FromFile(".\resources\playwhite.png")
    End Sub

    Private Sub lbl_about_Click(sender As Object, e As EventArgs) Handles lbl_about.Click
        Process.Start("https://github.com/ParthK117/W-Emuloader")
    End Sub

    Private Sub lbl_twitter_Click(sender As Object, e As EventArgs) Handles lbl_twitter.Click
        Process.Start("https://twitter.com/drgreenboys")
    End Sub

    Private Sub lbl_patreon_Click(sender As Object, e As EventArgs) Handles lbl_patreon.Click
        Process.Start("https://github.com/ParthK117/W-Emuloader")
    End Sub

    Private Sub lbl_github_Click(sender As Object, e As EventArgs) Handles lbl_github.Click
        Process.Start("https://github.com/ParthK117/W-Emuloader")
    End Sub

    Private Sub btn_import_MouseDown(sender As Object, e As MouseEventArgs) Handles btn_import.MouseDown
        btn_import.BackgroundImage = System.Drawing.Image.FromFile(".\resources\importclick.png")
        import_list.Filter = "Emuloader Files (*.eldr*)|*.eldr"
        If import_list.ShowDialog = Windows.Forms.DialogResult.OK AndAlso File.Exists(".\lists\" & System.IO.Path.GetFileName(import_list.FileName)) = False Then


            Dim imported_list_downloads As String() = File.ReadAllLines(import_list.FileName)
            Dim showsource As Boolean = False
            Dim metadata As String()
            If imported_list_downloads(0).Contains("#") Then
                metadata = Split(imported_list_downloads(0), "#")
                showsource = True
            End If



            For Each x In imported_list_downloads
                If Not x.Contains("#") Then
                    Dim x_split As String() = Split(x, ",")
                    '  listbox_availableroms.Items.Add(x_split(0))
                    Dim file_source As String = x_split(3)
                    If file_source.Contains("google") Then
                        file_source = "Google Drive"
                    ElseIf showsource = True Then
                        file_source = metadata(0)
                    Else
                        file_source = "Other"
                    End If
                    listbox_availableroms.Items.Add(New ListViewItem(New String() {x_split(0), x_split(1), x_split(2), file_source, x_split(3)}))
                End If
            Next
            listbox_availableroms.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent)
            listbox_availableroms.AutoResizeColumn(2, ColumnHeaderAutoResizeStyle.HeaderSize)
            listbox_availableroms.Columns.Item(4).Width = 0
            If Directory.Exists(".\lists\") Then
            Else
                My.Computer.FileSystem.CreateDirectory(".\lists\")
            End If



            System.IO.File.Copy(import_list.FileName, ".\lists\" & System.IO.Path.GetFileName(import_list.FileName))
        ElseIf Windows.Forms.DialogResult.Cancel Then
        Else
            MessageBox.Show("List already imported")
        End If


    End Sub

    Private Sub btn_import_MouseEnter(sender As Object, e As EventArgs) Handles btn_import.MouseEnter
        btn_import.BackgroundImage = System.Drawing.Image.FromFile(".\resources\importwhite.png")
    End Sub

    Private Sub btn_import_MouseLeave(sender As Object, e As EventArgs) Handles btn_import.MouseLeave
        btn_import.BackgroundImage = System.Drawing.Image.FromFile(".\resources\importblack.png")
    End Sub


    Private Sub btn_import_MouseUp(sender As Object, e As MouseEventArgs) Handles btn_import.MouseUp
        btn_import.BackgroundImage = System.Drawing.Image.FromFile(".\resources\importwhite.png")
    End Sub

    Private Sub listbox_availableroms_SelectedIndexChanged(sender As Object, e As EventArgs) Handles listbox_availableroms.SelectedIndexChanged
        lbl_rom_name.Text = listbox_availableroms.FocusedItem.SubItems(0).Text
        lbl_rom_platform.Text = "Platform: " & listbox_availableroms.FocusedItem.SubItems(2).Text
    End Sub

    Private Sub listbox_search_SelectedIndexChanged(sender As Object, e As EventArgs) Handles listbox_search.SelectedIndexChanged
        lbl_rom_name.Text = listbox_search.FocusedItem.SubItems(0).Text
        lbl_rom_platform.Text = "Platform: " & listbox_search.FocusedItem.SubItems(2).Text
    End Sub

    Private Sub btn_browse_Click(sender As Object, e As EventArgs) Handles btn_browse.Click
        tab_browse.Visible = True
        panel_browse.BringToFront()
        emu_one.ForeColor = labelgrey
        emu_two.ForeColor = labelgrey
        emu_three.ForeColor = labelgrey
        panel_rom_info.Visible = True
        panel_rom_rightclick.Visible = False
    End Sub

    Private Sub load_roms_list()
        If Directory.Exists(".\lists\") = False Then
            Directory.CreateDirectory(".\lists")

        End If
        Dim list_directory As New DirectoryInfo(".\lists\")
        For Each f In list_directory.GetFiles()
            Dim imported_list_downloads As String() = File.ReadAllLines(".\lists\" & f.ToString)
            Dim showsource As Boolean = False
            Dim metadata As String()
            If imported_list_downloads(0).Contains("#") Then
                metadata = Split(imported_list_downloads(0), "#")
                showsource = True
            End If



            For Each x In imported_list_downloads
                If Not x.Contains("#") Then
                    Dim x_split As String() = Split(x, ",")
                    '  listbox_availableroms.Items.Add(x_split(0))
                    Dim file_source As String = x_split(3)
                    If file_source.Contains("google") Then
                        file_source = "Google Drive"
                    ElseIf showsource = True Then
                        file_source = metadata(0)
                    Else
                        file_source = "Other"
                    End If
                    listbox_availableroms.Items.Add(New ListViewItem(New String() {x_split(0), x_split(1), x_split(2), file_source, x_split(3)}))
                End If
            Next
            listbox_availableroms.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent)
            listbox_availableroms.AutoResizeColumn(2, ColumnHeaderAutoResizeStyle.HeaderSize)
            listbox_availableroms.Columns.Item(4).Width = 0
        Next
    End Sub

    Private Sub download_roms()
        If downloadqueue.Visible = True Then
            If panel_search.Visible = True Then
                downloadqueue.listbox_queue.Items.Add(New ListViewItem(New String() {listbox_search.FocusedItem.SubItems(0).Text,
listbox_search.FocusedItem.SubItems(1).Text,
listbox_search.FocusedItem.SubItems(2).Text,
listbox_search.FocusedItem.SubItems(3).Text,
listbox_search.FocusedItem.SubItems(4).Text}))
            Else
                downloadqueue.listbox_queue.Items.Add(New ListViewItem(New String() {listbox_availableroms.FocusedItem.SubItems(0).Text,
  listbox_availableroms.FocusedItem.SubItems(1).Text,
  listbox_availableroms.FocusedItem.SubItems(2).Text,
  listbox_availableroms.FocusedItem.SubItems(3).Text,
  listbox_availableroms.FocusedItem.SubItems(4).Text}))
            End If

        Else
            downloadqueue.Show()
        End If




    End Sub


    Private Sub btn_queue_MouseEnter(sender As Object, e As EventArgs) Handles btn_queue.MouseEnter
        btn_queue.BackgroundImage = System.Drawing.Image.FromFile(".\resources\queuewhite.png")
    End Sub

    Private Sub btn_queue_MouseLeave(sender As Object, e As EventArgs) Handles btn_queue.MouseLeave
        btn_queue.BackgroundImage = System.Drawing.Image.FromFile(".\resources\queueblack.png")
    End Sub

    Private Sub btn_queue_MouseDown(sender As Object, e As MouseEventArgs) Handles btn_queue.MouseDown
        btn_queue.BackgroundImage = System.Drawing.Image.FromFile(".\resources\queueclick.png")
        Call download_roms()

    End Sub

    Private Sub btn_queue_MouseUp(sender As Object, e As MouseEventArgs) Handles btn_queue.MouseUp
        btn_queue.BackgroundImage = System.Drawing.Image.FromFile(".\resources\queuewhite.png")
    End Sub

    Public Sub load_installed_roms()
        listbox_installedroms.Items.Clear()
        If File.Exists(".\custom.eldr") = False Then
            System.IO.File.Create(".\custom.eldr").Dispose()
        End If

        Dim customromlist As String() = File.ReadAllLines(".\custom.eldr")

        If currenttab_metadata(1) = "GBA" Then
            If Directory.Exists(".\roms\GBA") = False Then
                Directory.CreateDirectory(".\roms\GBA")
            End If
            Dim rom_directory As New DirectoryInfo(".\roms\GBA\")
            For Each f In rom_directory.GetFiles
                If f.ToString.Contains("sav") Then

                ElseIf f.ToString.Contains(".gba") Then
                    listbox_installedroms.Items.Add(New ListViewItem(New String() {f.ToString.Replace(".gba", ""), "GBA", System.IO.Path.GetFullPath(f.FullName)}))

                ElseIf f.ToString.Contains(".gbc") Then
                    listbox_installedroms.Items.Add(New ListViewItem(New String() {f.ToString.Replace(".gbc", ""), "GBC", System.IO.Path.GetFullPath(f.FullName)}))

                ElseIf f.ToString.Contains(".gb") = True And f.ToString.Contains(".gbc") = False And f.ToString.Contains(".gba") = False Then
                    listbox_installedroms.Items.Add(New ListViewItem(New String() {f.ToString.Replace(".gb", ""), "GB", System.IO.Path.GetFullPath(f.FullName)}))
                End If

            Next

            If Directory.Exists(".\roms\GBC") = False Then
                Directory.CreateDirectory(".\roms\GBC")
            End If
            Dim rom_directory2 As New DirectoryInfo(".\roms\GBC\")
            For Each f In rom_directory2.GetFiles
                If f.ToString.Contains("XT") Then
                ElseIf f.ToString.Contains(".gbc") Then
                    listbox_installedroms.Items.Add(New ListViewItem(New String() {f.ToString.Replace(".gbc", ""), "GBC", System.IO.Path.GetFullPath(f.FullName)}))
                ElseIf f.ToString.Contains(".gb") = True And f.ToString.Contains(".gbc") = False And f.ToString.Contains(".gba") = False Then
                    listbox_installedroms.Items.Add(New ListViewItem(New String() {f.ToString.Replace(".gb", ""), "GB", System.IO.Path.GetFullPath(f.FullName)}))
                End If

            Next

            If Directory.Exists(".\roms\GB") = False Then
                Directory.CreateDirectory(".\roms\GB")
            End If
            Dim rom_directory3 As New DirectoryInfo(".\roms\GB\")
            For Each f In rom_directory3.GetFiles
                If f.ToString.Contains("XT") Then
                ElseIf f.ToString.Contains(".gb") Then
                    listbox_installedroms.Items.Add(New ListViewItem(New String() {f.ToString.Replace(".gb", ""), "GB", System.IO.Path.GetFullPath(f.FullName)}))
                End If

            Next

            For Each x In customromlist
                Dim custom_directory As New DirectoryInfo(x)
                For Each f In custom_directory.GetFiles
                    If f.ToString.Contains(".gba") Then
                        listbox_installedroms.Items.Add(New ListViewItem(New String() {f.ToString.Replace(".gba", ""), "GBA", System.IO.Path.GetFullPath(f.FullName)}))
                    ElseIf f.ToString.Contains(".gbc") Then
                        listbox_installedroms.Items.Add(New ListViewItem(New String() {f.ToString.Replace(".gbc", ""), "GBC", System.IO.Path.GetFullPath(f.FullName)}))

                    ElseIf f.ToString.Contains(".gb") = True And f.ToString.Contains(".gbc") = False And f.ToString.Contains(".gba") = False Then
                        listbox_installedroms.Items.Add(New ListViewItem(New String() {f.ToString.Replace(".gb", ""), "GB", System.IO.Path.GetFullPath(f.FullName)}))
                    End If

                Next
            Next



        ElseIf currenttab_metadata(1) = "3DS" Then
            If Directory.Exists(".\roms\3DS") = False Then
                Directory.CreateDirectory(".\roms\3DS")
            End If
            Dim rom_directory As New DirectoryInfo(".\roms\3DS\")
            For Each f In rom_directory.GetFiles
                If f.ToString.Contains("XT") Then
                ElseIf f.ToString.Contains(".3ds") Then
                    listbox_installedroms.Items.Add(New ListViewItem(New String() {f.ToString.Replace(".3ds", ""), "3DS", System.IO.Path.GetFullPath(f.FullName)}))
                End If

            Next

            For Each x In customromlist
                Dim custom_directory As New DirectoryInfo(x)
                For Each f In custom_directory.GetFiles
                    If f.ToString.Contains(".3ds") Then

                        listbox_installedroms.Items.Add(New ListViewItem(New String() {f.ToString.Replace(".3ds", ""), "3DS", System.IO.Path.GetFullPath(f.FullName)}))
                    End If

                Next
            Next
        ElseIf currenttab_metadata(1) = "NDS" Then
            If Directory.Exists(".\roms\NDS") = False Then
                Directory.CreateDirectory(".\roms\NDS")
            End If
            Dim rom_directory As New DirectoryInfo(".\roms\NDS\")
            For Each f In rom_directory.GetFiles
                If f.ToString.Contains("XT") Then
                ElseIf f.ToString.Contains(".nds") Then
                    listbox_installedroms.Items.Add(New ListViewItem(New String() {f.ToString.Replace(".nds", ""), "NDS", System.IO.Path.GetFullPath(f.FullName)}))
                End If

            Next

            For Each x In customromlist
                Dim custom_directory As New DirectoryInfo(x)
                For Each f In custom_directory.GetFiles
                    If f.ToString.Contains(".nds") Then

                        listbox_installedroms.Items.Add(New ListViewItem(New String() {f.ToString.Replace(".nds", ""), "NDS", System.IO.Path.GetFullPath(f.FullName)}))
                    End If

                Next
            Next
        ElseIf currenttab_metadata(1) = "N64" Then
            If Directory.Exists(".\roms\N64") = False Then
                Directory.CreateDirectory(".\roms\N64")
            End If
            Dim rom_directory As New DirectoryInfo(".\roms\N64\")
            For Each f In rom_directory.GetFiles
                If f.ToString.Contains("XT") Then
                ElseIf f.ToString.Contains(".z64") Then
                    listbox_installedroms.Items.Add(New ListViewItem(New String() {f.ToString.Replace(".z64", ""), "N64", System.IO.Path.GetFullPath(f.FullName)}))
                End If

            Next

            For Each x In customromlist
                Dim custom_directory As New DirectoryInfo(x)
                For Each f In custom_directory.GetFiles
                    If f.ToString.Contains(".z64") Then

                        listbox_installedroms.Items.Add(New ListViewItem(New String() {f.ToString.Replace(".z64", ""), "N64", System.IO.Path.GetFullPath(f.FullName)}))
                    End If

                Next
            Next
        ElseIf currenttab_metadata(1) = "PSP" Then
            If Directory.Exists(".\roms\PSP") = False Then
                Directory.CreateDirectory(".\roms\PSP")
            End If
            Dim rom_directory As New DirectoryInfo(".\roms\PSP\")
            For Each f In rom_directory.GetFiles
                If f.ToString.Contains("XT") Then
                ElseIf f.ToString.Contains(".iso") Then
                    listbox_installedroms.Items.Add(New ListViewItem(New String() {f.ToString.Replace(".iso", ""), "PSP", System.IO.Path.GetFullPath(f.FullName)}))
                End If

            Next

            For Each x In customromlist
                Dim custom_directory As New DirectoryInfo(x)
                For Each f In custom_directory.GetFiles
                    If f.ToString.Contains(".iso") Or f.ToString.Contains(".cso") Then

                        listbox_installedroms.Items.Add(New ListViewItem(New String() {f.ToString.Replace(".iso", ""), "PSP", System.IO.Path.GetFullPath(f.FullName)}))
                    End If

                Next
            Next
        ElseIf currenttab_metadata(1) = "WII" Then
            If Directory.Exists(".\roms\WII") = False Then
                Directory.CreateDirectory(".\roms\WII")
            End If
            Dim rom_directory As New DirectoryInfo(".\roms\WII\")
            For Each f In rom_directory.GetFiles
                If f.ToString.Contains("XT") Then
                ElseIf f.ToString.Contains(".iso") Then
                    listbox_installedroms.Items.Add(New ListViewItem(New String() {f.ToString.Replace(".iso", ""), "WII", System.IO.Path.GetFullPath(f.FullName)}))
                End If

            Next

            For Each x In customromlist
                Dim custom_directory As New DirectoryInfo(x)
                For Each f In custom_directory.GetFiles
                    If f.ToString.Contains(".iso") Or f.ToString.Contains(".elf") Then

                        listbox_installedroms.Items.Add(New ListViewItem(New String() {f.ToString.Replace(".iso", ""), "WII", System.IO.Path.GetFullPath(f.FullName)}))
                    End If

                Next
            Next
        End If



        If listbox_installedroms.Items.Count = 0 Then
            listbox_installedroms.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)

        Else
            listbox_installedroms.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent)
        End If
        listbox_installedroms.Columns.Item(2).Width = 0
        listbox_installedroms.AutoResizeColumn(1, ColumnHeaderAutoResizeStyle.HeaderSize)

    End Sub

    Private Sub btn_exit_MouseDown(sender As Object, e As MouseEventArgs) Handles btn_exit.MouseDown
        Application.Exit()
    End Sub

    Private Sub btn_minimise_MouseDown(sender As Object, e As MouseEventArgs) Handles btn_minimise.MouseDown
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub btn_maximise_MouseDown(sender As Object, e As MouseEventArgs) Handles btn_maximise.MouseDown
        If Me.WindowState = FormWindowState.Normal Then

            Me.WindowState = FormWindowState.Maximized
            lbl_status.Location = New Point((panel_top.Width - lbl_status.Width) \ 2, (panel_top.Height - lbl_status.Height) \ 2)
        Else

            Me.WindowState = FormWindowState.Normal
            lbl_status.Location = New Point((panel_top.Width - lbl_status.Width) \ 2, (panel_top.Height - lbl_status.Height) \ 2)
        End If
    End Sub



    Private Sub btn_import_roms_MouseEnter(sender As Object, e As EventArgs) Handles btn_import_roms.MouseEnter
        btn_import_roms.BackgroundImage = System.Drawing.Image.FromFile(".\resources\importromswhite.png")
    End Sub

    Private Sub btn_import_roms_MouseLeave(sender As Object, e As EventArgs) Handles btn_import_roms.MouseLeave
        btn_import_roms.BackgroundImage = System.Drawing.Image.FromFile(".\resources\importromsblack.png")
    End Sub

    Private Sub btn_import_roms_MouseDown(sender As Object, e As MouseEventArgs) Handles btn_import_roms.MouseDown
        btn_import_roms.BackgroundImage = System.Drawing.Image.FromFile(".\resources\importromsclick.png")

        Dim folderBrowser As New OpenFileDialog()

        folderBrowser.ValidateNames = False
        folderBrowser.CheckFileExists = False
        folderBrowser.CheckPathExists = True
        folderBrowser.FileName = "This folder."
        If folderBrowser.ShowDialog() = DialogResult.OK Then

            Dim folderPath As String = Path.GetDirectoryName(folderBrowser.FileName)


            If File.Exists(".\custom.eldr") And (New FileInfo(".\custom.eldr").Length > 0) Then

                My.Computer.FileSystem.WriteAllText(".\custom.eldr", vbNewLine & folderPath, True)

            Else
                System.IO.File.Create(".\custom.eldr").Dispose()
                My.Computer.FileSystem.WriteAllText(".\custom.eldr", folderPath, False)
            End If









            Call load_installed_roms()
        End If

    End Sub

    Private Sub btn_import_roms_MouseUp(sender As Object, e As MouseEventArgs) Handles btn_import_roms.MouseUp
        btn_import_roms.BackgroundImage = System.Drawing.Image.FromFile(".\resources\importromswhite.png")
    End Sub

    Private Sub checkbox_filepath_CheckedChanged(sender As Object, e As EventArgs) Handles checkbox_filepath.CheckedChanged
        If checkbox_filepath.Checked = True Then
            listbox_installedroms.Columns.Item(2).Width = 200
        End If
        If checkbox_filepath.Checked = False Then
            listbox_installedroms.Columns.Item(2).Width = 0
        End If
    End Sub



    Private Sub listbox_installedroms_MouseDown(sender As Object, e As MouseEventArgs) Handles listbox_installedroms.MouseDown

    End Sub

    Private Sub listbox_installedroms_MouseUp(sender As Object, e As MouseEventArgs) Handles listbox_installedroms.MouseUp
        If e.Button = MouseButtons.Right Then
            If listbox_installedroms.SelectedItems.Count > 0 Then

                panel_rom_rightclick.Visible = True

                panel_rom_rightclick.Location = New Point((e.X + 40), (e.Y + 120))
            End If
        Else
            panel_rom_rightclick.Visible = False
        End If
    End Sub

    Private Sub btn_rom_rename_Click(sender As Object, e As EventArgs) Handles btn_rom_rename.Click
        romproperties.Show()
        Call romproperties.load_rom_properties()
        panel_rom_rightclick.Visible = False
        lbl_rom_name.Visible = False
        romproperties.textbox_rom_name.Visible = True
        romproperties.textbox_rom_name.Select()
    End Sub

    Private Sub btn_rom_rename_MouseEnter(sender As Object, e As EventArgs) Handles btn_rom_rename.MouseEnter
        btn_rom_rename.BackgroundImage = System.Drawing.Image.FromFile(".\resources\renameblack.png")
    End Sub

    Private Sub btn_rom_rename_MouseLeave(sender As Object, e As EventArgs) Handles btn_rom_rename.MouseLeave
        btn_rom_rename.BackgroundImage = System.Drawing.Image.FromFile(".\resources\renamewhite.png")
    End Sub

    Private Sub btn_rom_delete_MouseEnter(sender As Object, e As EventArgs) Handles btn_rom_delete.MouseEnter
        btn_rom_delete.BackgroundImage = System.Drawing.Image.FromFile(".\resources\deleteblack.png")
    End Sub

    Private Sub btn_rom_delete_MouseLeave(sender As Object, e As EventArgs) Handles btn_rom_delete.MouseLeave
        btn_rom_delete.BackgroundImage = System.Drawing.Image.FromFile(".\resources\deletewhite.png")
    End Sub

    Private Sub btn_rom_delete_Click(sender As Object, e As EventArgs) Handles btn_rom_delete.Click

        If File.Exists(listbox_installedroms.FocusedItem.SubItems(2).Text) Then

            My.Computer.FileSystem.DeleteFile(listbox_installedroms.FocusedItem.SubItems(2).Text)
            listbox_installedroms.FocusedItem.Remove()
            panel_rom_rightclick.Visible = False
        End If
    End Sub

    Private Sub btn_rom_properties_Click(sender As Object, e As EventArgs) Handles btn_rom_properties.Click
        romproperties.Show()
        Call romproperties.load_rom_properties()
        panel_rom_rightclick.Visible = False
    End Sub

    Private Sub btn_rom_properties_MouseEnter(sender As Object, e As EventArgs) Handles btn_rom_properties.MouseEnter
        btn_rom_properties.BackgroundImage = System.Drawing.Image.FromFile(".\resources\propertiesblack.png")
    End Sub

    Private Sub btn_rom_properties_MouseLeave(sender As Object, e As EventArgs) Handles btn_rom_properties.MouseLeave
        btn_rom_properties.BackgroundImage = System.Drawing.Image.FromFile(".\resources\propertieswhite.png")
    End Sub

    Private Sub btn_search_Click(sender As Object, e As EventArgs) Handles btn_search.Click
        btn_search.ForeColor = Color.Black
        btn_all.ForeColor = labelgrey
        tab_all.Visible = False
        tab_search.Visible = True
        panel_search.Visible = True
    End Sub

    Private Sub btn_all_Click(sender As Object, e As EventArgs) Handles btn_all.Click
        btn_all.ForeColor = Color.Black
        btn_search.ForeColor = labelgrey
        tab_all.Visible = True
        tab_search.Visible = False
        panel_search.Visible = False
    End Sub

    Private Sub textbox_search_KeyDown(sender As Object, e As KeyEventArgs) Handles textbox_search.KeyDown
        If e.KeyCode = Keys.Enter Then
            listbox_search.Items.Clear()

            For Each line In listbox_availableroms.Items
                If line.Subitems(0).text.IndexOf(textbox_search.Text, 0, StringComparison.CurrentCultureIgnoreCase) > -1 Then
                    Dim linestring As String() = {line.subitems(0).text, line.subitems(1).text, line.subitems(2).text, line.subitems(3).text, line.subitems(4).text}
                    listbox_search.Items.Add(New ListViewItem(linestring))
                End If
            Next

            listbox_search.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent)
            listbox_search.AutoResizeColumn(2, ColumnHeaderAutoResizeStyle.HeaderSize)
            listbox_search.Columns.Item(4).Width = 0
        End If
    End Sub

    Private Sub textbox_search_Click(sender As Object, e As EventArgs) Handles textbox_search.Click
        If textbox_search.Text = "Search" Then
            textbox_search.Text = ""
        End If
    End Sub

    Private Sub panel_top_DoubleClick(sender As Object, e As EventArgs) Handles panel_top.DoubleClick
        If Me.WindowState = FormWindowState.Normal Then

            Me.WindowState = FormWindowState.Maximized
            lbl_status.Location = New Point((panel_top.Width - lbl_status.Width) \ 2, (panel_top.Height - lbl_status.Height) \ 2)
        Else

            Me.WindowState = FormWindowState.Normal
            lbl_status.Location = New Point((panel_top.Width - lbl_status.Width) \ 2, (panel_top.Height - lbl_status.Height) \ 2)
        End If
    End Sub



    Private Sub btn_search_gba_click(sender As Object, e As MouseEventArgs) Handles btn_search_gba.Click
        textbox_search.Text = "Search"
        listbox_search.Items.Clear()
        btn_search_gba.BackgroundImage = System.Drawing.Image.FromFile(".\resources\searchgbawhite.png")
        btn_search_wii.BackgroundImage = System.Drawing.Image.FromFile(".\resources\searchwiiblack.png")
        btn_search_nds.BackgroundImage = System.Drawing.Image.FromFile(".\resources\searchndsblack.png")
        btn_search_3ds.BackgroundImage = System.Drawing.Image.FromFile(".\resources\search3dsblack.png")
        btn_search_psp.BackgroundImage = System.Drawing.Image.FromFile(".\resources\searchpspblack.png")
        btn_search_n64.BackgroundImage = System.Drawing.Image.FromFile(".\resources\searchn64black.png")
        btn_search_gbc.BackgroundImage = System.Drawing.Image.FromFile(".\resources\searchgbcblack.png")
        btn_search_gb.BackgroundImage = System.Drawing.Image.FromFile(".\resources\searchgbblack.png")

        For Each line In listbox_availableroms.Items
            If line.subitems(2).text = "GBA" Then
                Dim linestring As String() = {line.subitems(0).text, line.subitems(1).text, line.subitems(2).text, line.subitems(3).text, line.subitems(4).text}
                listbox_search.Items.Add(New ListViewItem(linestring))
            End If

        Next

        listbox_search.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent)
        listbox_search.AutoResizeColumn(2, ColumnHeaderAutoResizeStyle.HeaderSize)
        listbox_search.Columns.Item(4).Width = 0


    End Sub

    Private Sub btn_search_gbc_click(sender As Object, e As MouseEventArgs) Handles btn_search_gbc.Click
        textbox_search.Text = "Search"
        listbox_search.Items.Clear()
        btn_search_gbc.BackgroundImage = System.Drawing.Image.FromFile(".\resources\searchgbcwhite.png")
        btn_search_wii.BackgroundImage = System.Drawing.Image.FromFile(".\resources\searchwiiblack.png")
        btn_search_nds.BackgroundImage = System.Drawing.Image.FromFile(".\resources\searchndsblack.png")
        btn_search_3ds.BackgroundImage = System.Drawing.Image.FromFile(".\resources\search3dsblack.png")
        btn_search_psp.BackgroundImage = System.Drawing.Image.FromFile(".\resources\searchpspblack.png")
        btn_search_n64.BackgroundImage = System.Drawing.Image.FromFile(".\resources\searchn64black.png")
        btn_search_gba.BackgroundImage = System.Drawing.Image.FromFile(".\resources\searchgbablack.png")
        btn_search_gb.BackgroundImage = System.Drawing.Image.FromFile(".\resources\searchgbblack.png")

        For Each line In listbox_availableroms.Items
            If line.subitems(2).text = "GBC" Then
                Dim linestring As String() = {line.subitems(0).text, line.subitems(1).text, line.subitems(2).text, line.subitems(3).text, line.subitems(4).text}
                listbox_search.Items.Add(New ListViewItem(linestring))
            End If

        Next

        listbox_search.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent)
        listbox_search.AutoResizeColumn(2, ColumnHeaderAutoResizeStyle.HeaderSize)
        listbox_search.Columns.Item(4).Width = 0


    End Sub

    Private Sub btn_search_gb_click(sender As Object, e As MouseEventArgs) Handles btn_search_gb.Click
        textbox_search.Text = "Search"
        listbox_search.Items.Clear()
        btn_search_gb.BackgroundImage = System.Drawing.Image.FromFile(".\resources\searchgbwhite.png")
        btn_search_wii.BackgroundImage = System.Drawing.Image.FromFile(".\resources\searchwiiblack.png")
        btn_search_nds.BackgroundImage = System.Drawing.Image.FromFile(".\resources\searchndsblack.png")
        btn_search_3ds.BackgroundImage = System.Drawing.Image.FromFile(".\resources\search3dsblack.png")
        btn_search_psp.BackgroundImage = System.Drawing.Image.FromFile(".\resources\searchpspblack.png")
        btn_search_n64.BackgroundImage = System.Drawing.Image.FromFile(".\resources\searchn64black.png")
        btn_search_gbc.BackgroundImage = System.Drawing.Image.FromFile(".\resources\searchgbcblack.png")
        btn_search_gba.BackgroundImage = System.Drawing.Image.FromFile(".\resources\searchgbablack.png")

        For Each line In listbox_availableroms.Items
            If line.subitems(2).text = "GB" Then
                Dim linestring As String() = {line.subitems(0).text, line.subitems(1).text, line.subitems(2).text, line.subitems(3).text, line.subitems(4).text}
                listbox_search.Items.Add(New ListViewItem(linestring))
            End If

        Next

        listbox_search.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent)
        listbox_search.AutoResizeColumn(2, ColumnHeaderAutoResizeStyle.HeaderSize)
        listbox_search.Columns.Item(4).Width = 0


    End Sub

    Private Sub btn_search_wii_click(sender As Object, e As MouseEventArgs) Handles btn_search_wii.Click
        textbox_search.Text = "Search"
        listbox_search.Items.Clear()
        btn_search_wii.BackgroundImage = System.Drawing.Image.FromFile(".\resources\searchwiiwhite.png")
        btn_search_gba.BackgroundImage = System.Drawing.Image.FromFile(".\resources\searchgbablack.png")
        btn_search_nds.BackgroundImage = System.Drawing.Image.FromFile(".\resources\searchndsblack.png")
        btn_search_3ds.BackgroundImage = System.Drawing.Image.FromFile(".\resources\search3dsblack.png")
        btn_search_psp.BackgroundImage = System.Drawing.Image.FromFile(".\resources\searchpspblack.png")
        btn_search_n64.BackgroundImage = System.Drawing.Image.FromFile(".\resources\searchn64black.png")
        btn_search_gbc.BackgroundImage = System.Drawing.Image.FromFile(".\resources\searchgbcblack.png")
        btn_search_gb.BackgroundImage = System.Drawing.Image.FromFile(".\resources\searchgbblack.png")

        For Each line In listbox_availableroms.Items
            If line.subitems(2).text = "WII" Then
                Dim linestring As String() = {line.subitems(0).text, line.subitems(1).text, line.subitems(2).text, line.subitems(3).text, line.subitems(4).text}
                listbox_search.Items.Add(New ListViewItem(linestring))
            End If

        Next

        listbox_search.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent)
        listbox_search.AutoResizeColumn(2, ColumnHeaderAutoResizeStyle.HeaderSize)
        listbox_search.Columns.Item(4).Width = 0


    End Sub

    Private Sub btn_search_nds_click(sender As Object, e As MouseEventArgs) Handles btn_search_nds.Click
        textbox_search.Text = "Search"
        listbox_search.Items.Clear()
        btn_search_nds.BackgroundImage = System.Drawing.Image.FromFile(".\resources\searchndswhite.png")
        btn_search_wii.BackgroundImage = System.Drawing.Image.FromFile(".\resources\searchwiiblack.png")
        btn_search_gba.BackgroundImage = System.Drawing.Image.FromFile(".\resources\searchgbablack.png")
        btn_search_3ds.BackgroundImage = System.Drawing.Image.FromFile(".\resources\search3dsblack.png")
        btn_search_psp.BackgroundImage = System.Drawing.Image.FromFile(".\resources\searchpspblack.png")
        btn_search_n64.BackgroundImage = System.Drawing.Image.FromFile(".\resources\searchn64black.png")
        btn_search_gbc.BackgroundImage = System.Drawing.Image.FromFile(".\resources\searchgbcblack.png")
        btn_search_gb.BackgroundImage = System.Drawing.Image.FromFile(".\resources\searchgbblack.png")

        For Each line In listbox_availableroms.Items
            If line.subitems(2).text = "NDS" Then
                Dim linestring As String() = {line.subitems(0).text, line.subitems(1).text, line.subitems(2).text, line.subitems(3).text, line.subitems(4).text}
                listbox_search.Items.Add(New ListViewItem(linestring))
            End If

        Next

        listbox_search.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent)
        listbox_search.AutoResizeColumn(2, ColumnHeaderAutoResizeStyle.HeaderSize)
        listbox_search.Columns.Item(4).Width = 0


    End Sub

    Private Sub btn_search_3ds_click(sender As Object, e As MouseEventArgs) Handles btn_search_3ds.Click
        textbox_search.Text = "Search"
        listbox_search.Items.Clear()
        btn_search_3ds.BackgroundImage = System.Drawing.Image.FromFile(".\resources\search3dswhite.png")
        btn_search_wii.BackgroundImage = System.Drawing.Image.FromFile(".\resources\searchwiiblack.png")
        btn_search_nds.BackgroundImage = System.Drawing.Image.FromFile(".\resources\searchndsblack.png")
        btn_search_gba.BackgroundImage = System.Drawing.Image.FromFile(".\resources\searchgbablack.png")
        btn_search_psp.BackgroundImage = System.Drawing.Image.FromFile(".\resources\searchpspblack.png")
        btn_search_n64.BackgroundImage = System.Drawing.Image.FromFile(".\resources\searchn64black.png")
        btn_search_gbc.BackgroundImage = System.Drawing.Image.FromFile(".\resources\searchgbcblack.png")
        btn_search_gb.BackgroundImage = System.Drawing.Image.FromFile(".\resources\searchgbblack.png")

        For Each line In listbox_availableroms.Items
            If line.subitems(2).text = "3DS" Then
                Dim linestring As String() = {line.subitems(0).text, line.subitems(1).text, line.subitems(2).text, line.subitems(3).text, line.subitems(4).text}
                listbox_search.Items.Add(New ListViewItem(linestring))
            End If

        Next

        listbox_search.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent)
        listbox_search.AutoResizeColumn(2, ColumnHeaderAutoResizeStyle.HeaderSize)
        listbox_search.Columns.Item(4).Width = 0


    End Sub

    Private Sub btn_search_n64_click(sender As Object, e As MouseEventArgs) Handles btn_search_n64.Click
        textbox_search.Text = "Search"
        listbox_search.Items.Clear()
        btn_search_n64.BackgroundImage = System.Drawing.Image.FromFile(".\resources\searchn64white.png")
        btn_search_wii.BackgroundImage = System.Drawing.Image.FromFile(".\resources\searchwiiblack.png")
        btn_search_nds.BackgroundImage = System.Drawing.Image.FromFile(".\resources\searchndsblack.png")
        btn_search_3ds.BackgroundImage = System.Drawing.Image.FromFile(".\resources\search3dsblack.png")
        btn_search_psp.BackgroundImage = System.Drawing.Image.FromFile(".\resources\searchpspblack.png")
        btn_search_gba.BackgroundImage = System.Drawing.Image.FromFile(".\resources\searchgbablack.png")
        btn_search_gbc.BackgroundImage = System.Drawing.Image.FromFile(".\resources\searchgbcblack.png")
        btn_search_gb.BackgroundImage = System.Drawing.Image.FromFile(".\resources\searchgbblack.png")

        For Each line In listbox_availableroms.Items
            If line.subitems(2).text = "N64" Then
                Dim linestring As String() = {line.subitems(0).text, line.subitems(1).text, line.subitems(2).text, line.subitems(3).text, line.subitems(4).text}
                listbox_search.Items.Add(New ListViewItem(linestring))
            End If

        Next

        listbox_search.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent)
        listbox_search.AutoResizeColumn(2, ColumnHeaderAutoResizeStyle.HeaderSize)
        listbox_search.Columns.Item(4).Width = 0


    End Sub

    Private Sub btn_search_psp_click(sender As Object, e As MouseEventArgs) Handles btn_search_psp.Click
        textbox_search.Text = "Search"
        listbox_search.Items.Clear()
        btn_search_psp.BackgroundImage = System.Drawing.Image.FromFile(".\resources\searchpspwhite.png")
        btn_search_wii.BackgroundImage = System.Drawing.Image.FromFile(".\resources\searchwiiblack.png")
        btn_search_nds.BackgroundImage = System.Drawing.Image.FromFile(".\resources\searchndsblack.png")
        btn_search_3ds.BackgroundImage = System.Drawing.Image.FromFile(".\resources\search3dsblack.png")
        btn_search_gba.BackgroundImage = System.Drawing.Image.FromFile(".\resources\searchgbablack.png")
        btn_search_n64.BackgroundImage = System.Drawing.Image.FromFile(".\resources\searchn64black.png")
        btn_search_gbc.BackgroundImage = System.Drawing.Image.FromFile(".\resources\searchgbcblack.png")
        btn_search_gb.BackgroundImage = System.Drawing.Image.FromFile(".\resources\searchgbblack.png")

        For Each line In listbox_availableroms.Items
            If line.subitems(2).text = "PSP" Then
                Dim linestring As String() = {line.subitems(0).text, line.subitems(1).text, line.subitems(2).text, line.subitems(3).text, line.subitems(4).text}
                listbox_search.Items.Add(New ListViewItem(linestring))
            End If

        Next

        listbox_search.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent)
        listbox_search.AutoResizeColumn(2, ColumnHeaderAutoResizeStyle.HeaderSize)
        listbox_search.Columns.Item(4).Width = 0


    End Sub
    Private Sub main_DragDrop(sender As System.Object, e As System.Windows.Forms.DragEventArgs) Handles Me.DragDrop
        Dim files() As String = e.Data.GetData(DataFormats.FileDrop)
        For Each drop_path In files


            If File.Exists(drop_path.ToString) = True AndAlso drop_path.ToString.Contains(".eldr") Then


                Dim imported_list_downloads As String() = File.ReadAllLines(drop_path.ToString)
                Dim showsource As Boolean = False
                Dim metadata As String()
                If imported_list_downloads(0).Contains("#") Then
                    metadata = Split(imported_list_downloads(0), "#")
                    showsource = True
                End If



                For Each x In imported_list_downloads
                    If Not x.Contains("#") Then
                        Dim x_split As String() = Split(x, ",")
                        '  listbox_availableroms.Items.Add(x_split(0))
                        Dim file_source As String = x_split(3)
                        If file_source.Contains("google") Then
                            file_source = "Google Drive"
                        ElseIf showsource = True Then
                            file_source = metadata(0)
                        Else
                            file_source = "Other"
                        End If
                        listbox_availableroms.Items.Add(New ListViewItem(New String() {x_split(0), x_split(1), x_split(2), file_source, x_split(3)}))
                    End If
                Next
                listbox_availableroms.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent)
                listbox_availableroms.AutoResizeColumn(2, ColumnHeaderAutoResizeStyle.HeaderSize)
                listbox_availableroms.Columns.Item(4).Width = 0
                If Directory.Exists(".\lists\") Then
                Else
                    My.Computer.FileSystem.CreateDirectory(".\lists\")
                End If



                System.IO.File.Copy(drop_path.ToString, ".\lists\" & System.IO.Path.GetFileName(drop_path.ToString))



            ElseIf File.Exists(drop_Path.ToString) = True AndAlso Not drop_Path.ToString.Contains(".eldr") Then
                Dim folderPath As String = Path.GetDirectoryName(drop_path.ToString)


                If File.Exists(".\custom.eldr") And (New FileInfo(".\custom.eldr").Length > 0) Then

                    My.Computer.FileSystem.WriteAllText(".\custom.eldr", vbNewLine & folderPath, True)

                Else
                    System.IO.File.Create(".\custom.eldr").Dispose()
                    My.Computer.FileSystem.WriteAllText(".\custom.eldr", folderPath, False)
                End If









                Call load_installed_roms()
            Else
                MessageBox.Show("Could not import")
            End If




        Next

        Me.Opacity = 1
        panel_drag_drop.Visible = False
        panel_drag_drop.SendToBack()

    End Sub

    Private Sub main_DragEnter(sender As System.Object, e As System.Windows.Forms.DragEventArgs) Handles Me.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        End If
        Me.Opacity = 0.9
        panel_drag_drop.Visible = True
        panel_drag_drop.BringToFront()
    End Sub

    Private Sub main_DragLeave(sender As Object, e As EventArgs) Handles Me.DragLeave
        Me.Opacity = 1
        panel_drag_drop.Visible = False
        panel_drag_drop.SendToBack()
    End Sub
End Class
