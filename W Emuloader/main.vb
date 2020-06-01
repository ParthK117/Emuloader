Imports System.Net
Imports System.IO
Imports System.IO.Compression
Imports System.ComponentModel

Public Class main
    Dim drag As Boolean
    Dim mousex As Integer
    Dim mousey As Integer

    Public Shared currenttab_metadata As String() = {"na", "na", "na", "na", "na"}
    Public Shared gotham As New System.Drawing.Text.PrivateFontCollection()
    Public Shared spartan As New System.Drawing.Text.PrivateFontCollection()
    Public Shared labelgrey As Color
    Public Shared tab_index = 0
    Public Shared dark = False
    Public Shared version_number = "0.5.2"

    '0.1.0

    Private Sub main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
        Call check_for_updates()
        panel_play.SendToBack()
        Call main_loadfonts()
        Call loadconfig()

        Call main_loadcolours()

        Call load_roms_list()
        Me.AllowDrop = True

        Dim settings As New List(Of String)
        settings.AddRange(File.ReadAllLines(".\settings.dat"))
        Dim checkbox_skin As String() = (settings(1).Split("="))
        If checkbox_skin(1) = "1" Then
            Call darkmode()
            dark = True
        End If
        lbl_version.Text = "v" & version_number
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
        If dark = "1" Then
            paneL_menubar.BackgroundImage = System.Drawing.Image.FromFile(".\resources\greenclickdark.png")
        Else
            paneL_menubar.BackgroundImage = System.Drawing.Image.FromFile(".\resources\greenclick.png")
        End If

    End Sub

    Private Sub btn_maximise_MouseLeave(sender As Object, e As EventArgs) Handles btn_maximise.MouseLeave
        If dark = "1" Then
            paneL_menubar.BackgroundImage = System.Drawing.Image.FromFile(".\resources\exitdark.png")
        Else
            paneL_menubar.BackgroundImage = System.Drawing.Image.FromFile(".\resources\exit.png")
        End If
    End Sub

    Private Sub btn_minimise_MouseEnter(sender As Object, e As EventArgs) Handles btn_minimise.MouseEnter
        If dark = "1" Then
            paneL_menubar.BackgroundImage = System.Drawing.Image.FromFile(".\resources\yellowclickdark.png")
        Else
            paneL_menubar.BackgroundImage = System.Drawing.Image.FromFile(".\resources\yellowclick.png")
        End If
    End Sub

    Private Sub btn_minimise_MouseLeave(sender As Object, e As EventArgs) Handles btn_minimise.MouseLeave
        If dark = "1" Then
            paneL_menubar.BackgroundImage = System.Drawing.Image.FromFile(".\resources\exitdark.png")
        Else
            paneL_menubar.BackgroundImage = System.Drawing.Image.FromFile(".\resources\exit.png")
        End If
    End Sub


    Private Sub btn_exit_MouseLeave(sender As Object, e As EventArgs) Handles btn_exit.MouseLeave
        If dark = "1" Then
            paneL_menubar.BackgroundImage = System.Drawing.Image.FromFile(".\resources\exitdark.png")
        Else
            paneL_menubar.BackgroundImage = System.Drawing.Image.FromFile(".\resources\exit.png")
        End If
    End Sub

    Private Sub btn_exit_MouseEnter(sender As Object, e As EventArgs) Handles btn_exit.MouseEnter
        If dark = "1" Then
            paneL_menubar.BackgroundImage = System.Drawing.Image.FromFile(".\resources\redclickdark.png")
        Else
            paneL_menubar.BackgroundImage = System.Drawing.Image.FromFile(".\resources\redclick.png")
        End If
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

    Private Sub emu_one_Click(sender As Object, e As EventArgs) Handles emu_one.Click
        tab_index = 0
        Call module_emutabs.load_emutab()
        If dark = True Then
            emu_one.ForeColor = Color.FromArgb(23, 191, 99)
        Else
            emu_one.ForeColor = Color.Black
        End If


    End Sub

    Private Sub emu_two_Click(sender As Object, e As EventArgs) Handles emu_two.Click
        tab_index = 1
        Call module_emutabs.load_emutab()

        If dark = True Then
            emu_two.ForeColor = Color.FromArgb(23, 191, 99)
        Else
            emu_two.ForeColor = Color.Black
        End If
    End Sub

    Private Sub emu_three_Click(sender As Object, e As EventArgs) Handles emu_three.Click
        tab_index = 2
        Call module_emutabs.load_emutab()
        If dark = True Then
            emu_three.ForeColor = Color.FromArgb(23, 191, 99)
        Else
            emu_three.ForeColor = Color.Black
        End If
    End Sub

    Private Sub emu_four_Click(sender As Object, e As EventArgs) Handles emu_four.Click
        tab_index = 3
        Call module_emutabs.load_emutab()
        If dark = True Then
            emu_four.ForeColor = Color.FromArgb(23, 191, 99)
        Else
            emu_four.ForeColor = Color.Black
        End If
    End Sub

    Private Sub emu_five_Click(sender As Object, e As EventArgs) Handles emu_five.Click
        tab_index = 4
        Call module_emutabs.load_emutab()
        If dark = True Then
            emu_five.ForeColor = Color.FromArgb(23, 191, 99)
        Else
            emu_five.ForeColor = Color.Black
        End If
    End Sub

    Private Sub emu_six_Click(sender As Object, e As EventArgs) Handles emu_six.Click
        tab_index = 5
        Call module_emutabs.load_emutab()
        If dark = True Then
            emu_six.ForeColor = Color.FromArgb(23, 191, 99)
        Else
            emu_six.ForeColor = Color.Black
        End If
    End Sub

    Private Sub emu_seven_Click(sender As Object, e As EventArgs) Handles emu_seven.Click
        tab_index = 6
        Call module_emutabs.load_emutab()
        If dark = True Then
            emu_seven.ForeColor = Color.FromArgb(23, 191, 99)
        Else
            emu_seven.ForeColor = Color.Black
        End If
    End Sub

    Private Sub emu_eight_Click(sender As Object, e As EventArgs) Handles emu_eight.Click
        tab_index = 7
        Call module_emutabs.load_emutab()
        If dark = True Then
            emu_eight.ForeColor = Color.FromArgb(23, 191, 99)
        Else
            emu_eight.ForeColor = Color.Black
        End If
    End Sub

    Private Sub emu_nine_Click(sender As Object, e As EventArgs) Handles emu_nine.Click
        tab_index = 8
        Call module_emutabs.load_emutab()
        If dark = True Then
            emu_nine.ForeColor = Color.FromArgb(23, 191, 99)
        Else
            emu_nine.ForeColor = Color.Black
        End If
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
        ElseIf currenttab_metadata(1) = "WIIU" Then


            Dim rom_path As String = System.IO.Path.GetFullPath(listbox_installedroms.FocusedItem.SubItems(2).Text)
            p.Arguments = ("-g" & """" & rom_path & """")
        ElseIf currenttab_metadata(1) = "SNES" Then


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
        Process.Start("https://patreon.com/emuloader")
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
                If metadata(2) = "verify" Then
                    Process.Start(metadata(3))
                End If
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
        Dim emutabs = {emu_one, emu_two, emu_three, emu_four, emu_five, emu_six, emu_seven, emu_eight, emu_nine}
        For Each x In emutabs
            x.ForeColor = labelgrey
        Next
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
        If listbox_availableroms.FocusedItem IsNot Nothing = True Or listbox_search.FocusedItem IsNot Nothing = True Then
            Call download_roms()
        Else
            MsgBox("Pick something to download first")
        End If
    End Sub

    Private Sub btn_queue_MouseUp(sender As Object, e As MouseEventArgs) Handles btn_queue.MouseUp
        btn_queue.BackgroundImage = System.Drawing.Image.FromFile(".\resources\queuewhite.png")
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
        If dark = True Then
            btn_search.ForeColor = Color.FromArgb(23, 191, 99)
        Else
            btn_search.ForeColor = Color.Black
        End If
        btn_all.ForeColor = labelgrey
        tab_all.Visible = False
        tab_search.Visible = True
        panel_search.Visible = True
    End Sub

    Private Sub btn_all_Click(sender As Object, e As EventArgs) Handles btn_all.Click
        If dark = True Then
            btn_all.ForeColor = Color.FromArgb(23, 191, 99)
        Else
            btn_all.ForeColor = Color.Black
        End If

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

            btn_search_3ds.BackgroundImage = System.Drawing.Image.FromFile(".\resources\search3dsblack.png")
            btn_search_wii.BackgroundImage = System.Drawing.Image.FromFile(".\resources\searchwiiblack.png")
            btn_search_nds.BackgroundImage = System.Drawing.Image.FromFile(".\resources\searchndsblack.png")
            btn_search_gba.BackgroundImage = System.Drawing.Image.FromFile(".\resources\searchgbablack.png")
            btn_search_psp.BackgroundImage = System.Drawing.Image.FromFile(".\resources\searchpspblack.png")
            btn_search_n64.BackgroundImage = System.Drawing.Image.FromFile(".\resources\searchn64black.png")
            btn_search_gbc.BackgroundImage = System.Drawing.Image.FromFile(".\resources\searchgbcblack.png")
            btn_search_gb.BackgroundImage = System.Drawing.Image.FromFile(".\resources\searchgbblack.png")
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
        emu_tab_metadata_list.tag_index = "GBA"
        Call module_emutabs.button_tags()
        btn_search_gba.BackgroundImage = System.Drawing.Image.FromFile(".\resources\searchgbawhite.png")


    End Sub

    Private Sub btn_search_gbc_click(sender As Object, e As MouseEventArgs) Handles btn_search_gbc.Click
        emu_tab_metadata_list.tag_index = "GBC"
        Call module_emutabs.button_tags()
        btn_search_gbc.BackgroundImage = System.Drawing.Image.FromFile(".\resources\searchgbcwhite.png")


    End Sub

    Private Sub btn_search_gb_click(sender As Object, e As MouseEventArgs) Handles btn_search_gb.Click
        emu_tab_metadata_list.tag_index = "GB"
        Call module_emutabs.button_tags()
        btn_search_gb.BackgroundImage = System.Drawing.Image.FromFile(".\resources\searchgbwhite.png")

    End Sub

    Private Sub btn_search_wii_click(sender As Object, e As MouseEventArgs) Handles btn_search_wii.Click
        emu_tab_metadata_list.tag_index = "WII"
        Call module_emutabs.button_tags()
        btn_search_wii.BackgroundImage = System.Drawing.Image.FromFile(".\resources\searchwiiwhite.png")

    End Sub

    Private Sub btn_search_nds_click(sender As Object, e As MouseEventArgs) Handles btn_search_nds.Click
        emu_tab_metadata_list.tag_index = "NDS"
        Call module_emutabs.button_tags()
        btn_search_nds.BackgroundImage = System.Drawing.Image.FromFile(".\resources\searchndswhite.png")


    End Sub

    Private Sub btn_search_3ds_click(sender As Object, e As MouseEventArgs) Handles btn_search_3ds.Click
        emu_tab_metadata_list.tag_index = "3DS"
        Call module_emutabs.button_tags()
        btn_search_3ds.BackgroundImage = System.Drawing.Image.FromFile(".\resources\search3dswhite.png")
    End Sub

    Private Sub btn_search_n64_click(sender As Object, e As MouseEventArgs) Handles btn_search_n64.Click
        emu_tab_metadata_list.tag_index = "N64"
        Call module_emutabs.button_tags()
        btn_search_n64.BackgroundImage = System.Drawing.Image.FromFile(".\resources\searchn64white.png")

    End Sub

    Private Sub btn_search_psp_click(sender As Object, e As MouseEventArgs) Handles btn_search_psp.Click
        emu_tab_metadata_list.tag_index = "PSP"
        Call module_emutabs.button_tags()
        btn_search_psp.BackgroundImage = System.Drawing.Image.FromFile(".\resources\searchpspwhite.png")

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
                    If metadata(2) = "verify" Then
                        Process.Start(metadata(3))
                    End If
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



            ElseIf File.Exists(drop_path.ToString) = True AndAlso Not drop_path.ToString.Contains(".eldr") Then
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

    Private Sub btn_expand_Click(sender As Object, e As EventArgs) Handles btn_expand.Click

        If panel_blue_click.Visible = True Then
            panel_blue_click.Visible = False
        Else
            panel_blue_click.Visible = True
        End If


    End Sub

    Private Sub btn_expand_MouseEnter(sender As Object, e As EventArgs) Handles btn_expand.MouseEnter

        If dark = "1" Then
            btn_expand.BackgroundImage = System.Drawing.Image.FromFile(".\resources\blueclickdark.png")
        Else
            btn_expand.BackgroundImage = System.Drawing.Image.FromFile(".\resources\blueclick.png")
        End If
    End Sub

    Private Sub btn_expand_MouseLeave(sender As Object, e As EventArgs) Handles btn_expand.MouseLeave
        If panel_blue_click.Visible = False Then
            btn_expand.BackgroundImage = System.Drawing.Image.FromFile(".\resources\blue.png")
        End If

    End Sub

    Private Sub listbox_installedroms_SelectedIndexChanged(sender As Object, e As EventArgs) Handles listbox_installedroms.SelectedIndexChanged
        If File.Exists(".\roms\" & currenttab_metadata(1) & "\metadata\boxartmatches.eldr") Then
            Dim find_art As String() = File.ReadAllLines(".\roms\" & currenttab_metadata(1) & "\metadata\boxartmatches.eldr")
            For Each x In find_art
                Dim current_name As String() = x.Split("#")
                If listbox_installedroms.FocusedItem IsNot Nothing = True Then
                    If listbox_installedroms.FocusedItem.SubItems(0).Text.Contains(current_name(0)) Then
                        picturebox_boxart.BackgroundImage = System.Drawing.Image.FromFile(current_name(1))
                        romproperties.picturebox_boxart.BackgroundImage = System.Drawing.Image.FromFile(current_name(1))

                    End If
                End If
            Next

        End If
    End Sub

    Public Sub retrieveboxart()


        If Directory.Exists(".\roms\" & currenttab_metadata(1) & "\metadata\") = False Then
            Directory.CreateDirectory(".\roms\" & currenttab_metadata(1) & "\metadata\")
        End If

        If Directory.Exists(".\boxart") = False Then
            Directory.CreateDirectory(".\boxart\")
        End If

        If File.Exists(".\roms\" & currenttab_metadata(1) & "\metadata\romnamelist.eldr") Then
            My.Computer.FileSystem.DeleteFile(".\roms\" & currenttab_metadata(1) & "\metadata\romnamelist.eldr")
        End If

        System.IO.File.Create(".\roms\" & currenttab_metadata(1) & "\metadata\romnamelist.eldr").Dispose()
        Dim romnamelist As New List(Of String)
        For Each x In listbox_installedroms.Items
            romnamelist.Add(x.subitems(0).text)
        Next
        File.WriteAllLines((".\roms\" & currenttab_metadata(1) & "\metadata\romnamelist.eldr"), romnamelist)

        Dim settings As New List(Of String)
        settings.AddRange(File.ReadAllLines(".\settings.dat"))
        Dim checkbox_loadart As String() = (settings(0).Split("="))
        If checkbox_loadart(1) = "1" Then


            If File.Exists(".\roms\" & currenttab_metadata(1) & "\metadata\boxartmatches.eldr") Then
                Dim boxartmatches As String = File.ReadAllText(".\roms\" & currenttab_metadata(1) & "\metadata\boxartmatches.eldr")

                For Each x In listbox_installedroms.Items
                    If Not (boxartmatches.Replace(" ", "")).Contains((x.subitems(0).text).replace(" ", "")) Then
                        lbl_status.Text = "Downloading Boxart"
                        lbl_status.Location = New Point((panel_top.Width - lbl_status.Width) \ 2, (panel_top.Height - lbl_status.Height) \ 2)
                        picturebox_loading.Visible = True
                        If thread_getboxart.IsBusy = False Then

                            Dim arguments As String()
                            arguments = {currenttab_metadata(1)}

                            thread_getboxart.RunWorkerAsync(arguments)

                        End If
                        Exit For
                    End If
                Next
            Else
                lbl_status.Text = "Downloading Boxart"
                picturebox_loading.Visible = True
                lbl_status.Location = New Point((panel_top.Width - lbl_status.Width) \ 2, (panel_top.Height - lbl_status.Height) \ 2)

                If thread_getboxart.IsBusy = False Then

                    Dim arguments As String()
                    arguments = {currenttab_metadata(1), System.IO.Path.GetFullPath(".\roms\" & currenttab_metadata(1))}

                    thread_getboxart.RunWorkerAsync(arguments)
                End If


            End If
        End If
    End Sub

    Private Sub thread_getboxart_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles thread_getboxart.DoWork
        Dim arguments As String() = (e.Argument)

        Dim getart As Process
        Dim p As New ProcessStartInfo
        p.FileName = ".\getboxart.exe"

        '   p.UseShellExecute = True
        p.WindowStyle = ProcessWindowStyle.Hidden
        p.WorkingDirectory = ".\modules\"
        p.Arguments = (arguments(0) & " " & Chr(34) & Path.GetFullPath(".\boxart") & Chr(34) & " " & Chr(34) & Path.GetFullPath(".\roms\" & currenttab_metadata(1) & "\metadata\romnamelist.eldr") & Chr(34) & " " & Chr(34) & Path.GetFullPath(".\roms\" & currenttab_metadata(1) & "\metadata") & Chr(34))
        getart = Process.Start(p)
        getart.WaitForExit()
    End Sub

    Private Sub thread_getboxart_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles thread_getboxart.RunWorkerCompleted
        lbl_status.Text = "Downloaded Boxart"
        picturebox_loading.Visible = False
        lbl_status.Location = New Point((panel_top.Width - lbl_status.Width) \ 2, (panel_top.Height - lbl_status.Height) \ 2)
    End Sub

    Private Sub btn_search_gc_Click(sender As Object, e As EventArgs) Handles btn_search_gc.Click
        emu_tab_metadata_list.tag_index = "GC"
        Call module_emutabs.button_tags()
        btn_search_gba.BackgroundImage = System.Drawing.Image.FromFile(".\resources\searchgcwhite.png")

    End Sub

    Private Sub btn_search_wiiu_Click(sender As Object, e As EventArgs) Handles btn_search_wiiu.Click
        emu_tab_metadata_list.tag_index = "WIIU"
        Call module_emutabs.button_tags()
        btn_search_gba.BackgroundImage = System.Drawing.Image.FromFile(".\resources\searchwiiuwhite.png")

    End Sub

    Private Sub btn_show_folders_Click(sender As Object, e As EventArgs) Handles btn_show_folders.Click
        Process.Start(".\roms")
        panel_blue_click.Visible = False
        btn_expand.BackgroundImage = System.Drawing.Image.FromFile(".\resources\blue.png")
    End Sub

    Private Sub btn_show_folders_MouseEnter(sender As Object, e As EventArgs) Handles btn_show_folders.MouseEnter
        btn_show_folders.BackgroundImage = System.Drawing.Image.FromFile(".\resources\foldersblack.png")
    End Sub

    Private Sub btn_show_folders_MouseLeave(sender As Object, e As EventArgs) Handles btn_show_folders.MouseLeave
        btn_show_folders.BackgroundImage = System.Drawing.Image.FromFile(".\resources\folderswhite.png")
    End Sub

    Private Sub btn_prettify_Click(sender As Object, e As EventArgs) Handles btn_prettify.Click
        panel_blue_click.Visible = False
        btn_expand.BackgroundImage = System.Drawing.Image.FromFile(".\resources\blue.png")
        Call prettify()
    End Sub

    Private Sub btn_prettify_MouseEnter(sender As Object, e As EventArgs) Handles btn_prettify.MouseEnter
        btn_prettify.BackgroundImage = System.Drawing.Image.FromFile(".\resources\prettifyblack.png")
    End Sub

    Private Sub btn_prettify_MouseLeave(sender As Object, e As EventArgs) Handles btn_prettify.MouseLeave
        btn_prettify.BackgroundImage = System.Drawing.Image.FromFile(".\resources\prettifywhite.png")
    End Sub

    Private Sub btn_settings_Click(sender As Object, e As EventArgs) Handles btn_settings.Click
        panel_blue_click.Visible = False
        btn_expand.BackgroundImage = System.Drawing.Image.FromFile(".\resources\blue.png")
        settings.Show()
    End Sub

    Private Sub btn_settings_MouseEnter(sender As Object, e As EventArgs) Handles btn_settings.MouseEnter
        btn_settings.BackgroundImage = System.Drawing.Image.FromFile(".\resources\settingsblack.png")
    End Sub

    Private Sub btn_settings_MouseLeave(sender As Object, e As EventArgs) Handles btn_settings.MouseLeave
        btn_settings.BackgroundImage = System.Drawing.Image.FromFile(".\resources\settingswhite.png")
    End Sub
    Public Sub prettify()

        If File.Exists(".\modules\gamepaths.dat") Then
            My.Computer.FileSystem.DeleteFile(".\modules\gamepaths.dat")
        End If

        System.IO.File.Create(".\modules\gamepaths.dat").Dispose()
        Dim gamepaths As New List(Of String)
        For Each x In listbox_installedroms.Items
            gamepaths.Add(System.IO.Path.GetFileName(x.subitems(2).text) + "#" + x.subitems(2).text + "#" + System.IO.Path.GetDirectoryName(x.subitems(2).text))
        Next
        File.WriteAllLines((".\modules\gamepaths.dat"), gamepaths)
        Dim arguments As String = (currenttab_metadata(1))

        Dim prettifypy As Process
        Dim p As New ProcessStartInfo
        p.FileName = ".\prettify.exe"

        '   p.UseShellExecute = True
        p.WindowStyle = ProcessWindowStyle.Hidden
        p.WorkingDirectory = ".\modules\"
        p.Arguments = (arguments)
        prettifypy = Process.Start(p)
        prettifypy.WaitForExit()
        Call load_installed_roms()
    End Sub

    Private Sub btn_search_ps1_Click(sender As Object, e As EventArgs) Handles btn_search_ps1.Click
        emu_tab_metadata_list.tag_index = "PS1"
        Call module_emutabs.button_tags()
        btn_search_ps1.BackgroundImage = System.Drawing.Image.FromFile(".\resources\searchps1white.png")
    End Sub

    Private Sub btn_search_ps2_Click(sender As Object, e As EventArgs) Handles btn_search_ps2.Click
        emu_tab_metadata_list.tag_index = "PS2"
        Call module_emutabs.button_tags()
        btn_search_ps2.BackgroundImage = System.Drawing.Image.FromFile(".\resources\searchps2white.png")
    End Sub

    Private Sub btn_show_lists_Click(sender As Object, e As EventArgs) Handles btn_show_lists.Click
        Process.Start(".\lists")
        panel_blue_click.Visible = False
        btn_expand.BackgroundImage = System.Drawing.Image.FromFile(".\resources\blue.png")
    End Sub

    Private Sub btn_show_lists_MouseLeave(sender As Object, e As EventArgs) Handles btn_show_lists.MouseLeave
        btn_show_lists.BackgroundImage = System.Drawing.Image.FromFile(".\resources\listswhite.png")
    End Sub

    Private Sub btn_show_lists_MouseEnter(sender As Object, e As EventArgs) Handles btn_show_lists.MouseEnter
        btn_show_lists.BackgroundImage = System.Drawing.Image.FromFile(".\resources\listsblack.png")
    End Sub


    Private Sub btn_play_delete_MouseEnter(sender As Object, e As EventArgs) Handles btn_play_delete.MouseEnter
        btn_play_delete.BackgroundImage = System.Drawing.Image.FromFile(".\resources\deleteplaywhite.png")
    End Sub

    Private Sub btn_play_delete_MouseLeave(sender As Object, e As EventArgs) Handles btn_play_delete.MouseLeave
        btn_play_delete.BackgroundImage = System.Drawing.Image.FromFile(".\resources\deleteplayblack.png")
    End Sub

    Private Sub btn_play_delete_MouseDown(sender As Object, e As MouseEventArgs) Handles btn_play_delete.MouseDown
        btn_play_delete.BackgroundImage = System.Drawing.Image.FromFile(".\resources\deleteplayclick.png")

        Dim directoryName As String = ".\" & currenttab_metadata(4)
        For Each deleteFile In Directory.GetFiles(directoryName, "*.*", SearchOption.AllDirectories)
            File.Delete(deleteFile)
        Next
        Directory.Delete(".\" & currenttab_metadata(4), True)

        Dim custom As New List(Of String)
        Dim custom2 As New List(Of String)
        custom.AddRange(File.ReadAllLines(".\installed.eldr"))
        custom2.AddRange(File.ReadAllLines(".\installed.eldr"))
        Dim newindex = 0
        For Each x In custom2
            If x.Contains(currenttab_metadata(4)) Then
                custom.RemoveAt(newindex)
            End If
            newindex = newindex + 1
        Next
        If File.Exists(".\installed.eldr") Then
            My.Computer.FileSystem.DeleteFile(".\installed.eldr")
        End If

        System.IO.File.Create(".\installed.eldr").Dispose()

        File.WriteAllText(".\installed.eldr", String.Join(vbNewLine, custom))

        Dim emutabs = {emu_one, emu_two, emu_three, emu_four, emu_five, emu_six, emu_seven, emu_eight, emu_nine}
        For Each x In emutabs
            x.Visible = False
            x.ForeColor = labelgrey
        Next
        tab_browse.Visible = True
        panel_browse.BringToFront()
        panel_rom_info.Visible = True
        panel_rom_rightclick.Visible = False
        Call loadconfig()

    End Sub

    Private Sub btn_play_delete_MouseUp(sender As Object, e As MouseEventArgs) Handles btn_play_delete.MouseUp
        btn_play_delete.BackgroundImage = System.Drawing.Image.FromFile(".\resources\deleteplaywhite.png")
    End Sub
    Public Sub check_for_updates()
        If Not File.Exists(".\settings.dat") Then
            Dim new_settings As String = "load=1" & vbNewLine & "dark=0" & vbNewLine & "version=" & version_number
            File.WriteAllText(".\settings.dat", new_settings)
        Else
            Dim settings As New List(Of String)
            settings.AddRange(File.ReadAllLines(".\settings.dat"))

            If Not settings(2).Contains(version_number) Then
                File.Delete(".\settings.dat")
                Dim new_settings As String = settings(0) & vbNewLine & settings(1) & vbNewLine & "version=" & version_number
                File.WriteAllText(".\settings.dat", new_settings)
            End If
        End If
        Try
            Dim getupdate As Process
            Dim p As New ProcessStartInfo
            p.FileName = ".\eldr.exe"
            p.WindowStyle = ProcessWindowStyle.Hidden
            getupdate = Process.Start(p)
            getupdate.WaitForExit()
            If File.Exists(".\neweldr\eldr.exe") Then
                File.Delete(".\eldr.exe")
                File.Move(".\neweldr\eldr.exe", ".\eldr.exe")
                Directory.Delete(".\neweldr")
            End If
        Catch ex As Exception
        End Try
        If File.Exists(".\Emuload.exe") Then
            File.Delete(".\Emuload.exe")
        End If
    End Sub

    Private Sub btn_search_snes_Click(sender As Object, e As EventArgs) Handles btn_search_snes.Click
        emu_tab_metadata_list.tag_index = "SNES"
        Call module_emutabs.button_tags()
        btn_search_snes.BackgroundImage = System.Drawing.Image.FromFile(".\resources\searchsneswhite.png")
    End Sub

    Private Sub btn_search_nes_Click(sender As Object, e As EventArgs) Handles btn_search_nes.Click
        emu_tab_metadata_list.tag_index = "NES"
        Call module_emutabs.button_tags()
        btn_search_nes.BackgroundImage = System.Drawing.Image.FromFile(".\resources\searchneswhite.png")
    End Sub
End Class
