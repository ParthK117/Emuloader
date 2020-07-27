Imports System.Net
Imports System.IO
Imports System.IO.Compression
Imports System.ComponentModel

Public Class main
    Dim drag As Boolean
    Dim mousex As Integer
    Dim mousey As Integer
    Dim index As Long = 0
    Dim speed As Long = 0
    Dim peak As Long = 0
    Dim total As Long = 0
    Public Shared currenttab_metadata As String() = {"na", "na", "na", "na", "na"}
    Public Shared gotham As New System.Drawing.Text.PrivateFontCollection()
    Public Shared spartan As New System.Drawing.Text.PrivateFontCollection()
    Public Shared labelgrey As Color
    Public Shared tab_index = 0
    Public Shared dark = 0
    Public Shared version_number = "1.0.0"
    Public Shared global_settings As New List(Of String)
    Public Shared boxart_url As String

    Private Sub main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Check if windows version is above 7
        If Environment.OSVersion.ToString.Contains("6.1") Then
            MessageBox.Show("Windows 7 and lower are not supported, Sorry.")
            Application.Exit()
        End If
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
        'Call check_for_updates sub which also builds and applies settings
        Call check_for_updates()
        'Loads fonts fro module_loadfonts
        Call main_loadfonts()
        'Loads loadconfig from load_functions
        Call loadconfig()
        'Call from module_loadfonts
        Call main_loadcolours()
        'Adds roms to browse menu
        Call load_roms_list()
        'Enables drag and drop
        Me.AllowDrop = True
        'Download log for download queue listview
        If File.Exists(".\downloadlog.dat") Then
            Dim history As String() = File.ReadAllLines(".\downloadlog.dat")
            For Each x In history
                Dim y As String() = x.Split(",")
                listbox_queue.Items.Add(New ListViewItem(New String() {y(0), y(1), y(2), y(3), y(4), y(5), y(6)}))
            Next
            listbox_queue.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent)
            listbox_queue.AutoResizeColumn(2, ColumnHeaderAutoResizeStyle.HeaderSize)
            listbox_queue.Columns.Item(4).Width = 0
        End If
        'add settings.dat to global variable
        global_settings.AddRange(File.ReadAllLines(".\settings.dat"))
        Dim firsttime As String() = (global_settings(6).Split("="))
        If firsttime(1).Contains("1") Then
            firstlaunch.ShowDialog()
            global_settings(6) = "firsttime=0"
            If File.Exists(".\settings.dat") Then
                My.Computer.FileSystem.DeleteFile(".\settings.dat")
            End If

            System.IO.File.Create(".\settings.dat").Dispose()
            Dim new_settings As String = global_settings(0) & vbNewLine & global_settings(1) & vbNewLine & global_settings(2) & vbNewLine & global_settings(3) & vbNewLine & global_settings(4) & vbNewLine & global_settings(5) & vbNewLine & global_settings(6) & vbNewLine & global_settings(7) & vbNewLine & global_settings(8) & vbNewLine & global_settings(9) & vbNewLine & global_settings(10) & vbNewLine & global_settings(11) & vbNewLine & global_settings(12)
            File.WriteAllText(".\settings.dat", new_settings)
        End If
        'Calls skin function to set a skin
        Dim checkbox_skin As String() = (global_settings(1).Split("="))
        Select Case checkbox_skin(1)
            Case 0
                Call lightmode()
            Case 1
                Call darkmode()
                dark = 1
            Case 2
                Call darkermode()
                dark = 2
            Case 3
                Call darkestmode()
                dark = 3
        End Select
        'Checks if windows bar or mac bar should be shown
        Dim checkbox_topbar As String() = (global_settings(7).Split("="))
        If checkbox_topbar(1) = "1" Then
            Me.FormBorderStyle = FormBorderStyle.Sizable
            paneL_menubar.Visible = False
        End If

        'Sets version number label using version_number global variable
        lbl_version.Text = "v" & version_number

        'sets network usage title forecolor
        lbl_networkusage.ForeColor = labelgrey

        'sets labels to the middle of their panels
        lbl_nothing.Location = New Point((panel_downloads.Width - lbl_nothing.Width) \ 2, (panel_downloads.Height - lbl_nothing.Height) \ 2)
        picturebox_patreon.Location = New Point((panel_left.Width - picturebox_patreon.Width) \ 2, 730)
        picturebox_tungsten.Location = New Point((panel_left.Width - picturebox_tungsten.Width) \ 2, 675)
        'To show big picture mode
        '    Dim wpfwindow = New mainux()
        '   wpfwindow.Show()

        'Calls jumpin updater from emulator updaters which populates the lastplayed section on the home panel.
        Call jumpin_updater()
    End Sub

    'dragging of borderless panel
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
        Select Case dark
            Case 0
                paneL_menubar.BackgroundImage = System.Drawing.Image.FromFile(".\resources\greenclick.png")
            Case 1
                paneL_menubar.BackgroundImage = System.Drawing.Image.FromFile(".\resources\greenclickdark.png")
            Case 2
                paneL_menubar.BackgroundImage = System.Drawing.Image.FromFile(".\resources\greenclickdarker.png")
            Case 3
                paneL_menubar.BackgroundImage = System.Drawing.Image.FromFile(".\resources\greenclickdarkest.png")
        End Select

    End Sub

    Private Sub btn_maximise_MouseLeave(sender As Object, e As EventArgs) Handles btn_maximise.MouseLeave
        Select Case dark
            Case 0
                paneL_menubar.BackgroundImage = System.Drawing.Image.FromFile(".\resources\exit.png")
            Case 1
                paneL_menubar.BackgroundImage = System.Drawing.Image.FromFile(".\resources\exitdark.png")
            Case 2
                paneL_menubar.BackgroundImage = System.Drawing.Image.FromFile(".\resources\exitdarker.png")
            Case 3
                paneL_menubar.BackgroundImage = System.Drawing.Image.FromFile(".\resources\exitdarkest.png")
        End Select
    End Sub

    Private Sub btn_minimise_MouseEnter(sender As Object, e As EventArgs) Handles btn_minimise.MouseEnter
        Select Case dark
            Case 0
                paneL_menubar.BackgroundImage = System.Drawing.Image.FromFile(".\resources\yellowclick.png")
            Case 1
                paneL_menubar.BackgroundImage = System.Drawing.Image.FromFile(".\resources\yellowclickdark.png")
            Case 2
                paneL_menubar.BackgroundImage = System.Drawing.Image.FromFile(".\resources\yellowclickdarker.png")
            Case 3
                paneL_menubar.BackgroundImage = System.Drawing.Image.FromFile(".\resources\yellowclickdarkest.png")
        End Select
    End Sub

    Private Sub btn_minimise_MouseLeave(sender As Object, e As EventArgs) Handles btn_minimise.MouseLeave
        Select Case dark
            Case 0
                paneL_menubar.BackgroundImage = System.Drawing.Image.FromFile(".\resources\exit.png")
            Case 1
                paneL_menubar.BackgroundImage = System.Drawing.Image.FromFile(".\resources\exitdark.png")
            Case 2
                paneL_menubar.BackgroundImage = System.Drawing.Image.FromFile(".\resources\exitdarker.png")
            Case 3
                paneL_menubar.BackgroundImage = System.Drawing.Image.FromFile(".\resources\exitdarkest.png")
        End Select
    End Sub

    Private Sub btn_exit_MouseLeave(sender As Object, e As EventArgs) Handles btn_exit.MouseLeave
        Select Case dark
            Case 0
                paneL_menubar.BackgroundImage = System.Drawing.Image.FromFile(".\resources\exit.png")
            Case 1
                paneL_menubar.BackgroundImage = System.Drawing.Image.FromFile(".\resources\exitdark.png")
            Case 2
                paneL_menubar.BackgroundImage = System.Drawing.Image.FromFile(".\resources\exitdarker.png")
            Case 3
                paneL_menubar.BackgroundImage = System.Drawing.Image.FromFile(".\resources\exitdarkest.png")
        End Select
    End Sub

    Private Sub btn_exit_MouseEnter(sender As Object, e As EventArgs) Handles btn_exit.MouseEnter
        Select Case dark
            Case 0
                paneL_menubar.BackgroundImage = System.Drawing.Image.FromFile(".\resources\redclick.png")
            Case 1
                paneL_menubar.BackgroundImage = System.Drawing.Image.FromFile(".\resources\redclickdark.png")
            Case 2
                paneL_menubar.BackgroundImage = System.Drawing.Image.FromFile(".\resources\redclickdarker.png")
            Case 3
                paneL_menubar.BackgroundImage = System.Drawing.Image.FromFile(".\resources\redclickdarkest.png")
        End Select
    End Sub

    Private Sub btn_newemu_MouseEnter(sender As Object, e As EventArgs) Handles btn_newemu.MouseEnter
        btn_newemu.Image = System.Drawing.Image.FromFile(".\resources\newemuwhite.png")
    End Sub

    Private Sub btn_newemu_MouseLeave(sender As Object, e As EventArgs) Handles btn_newemu.MouseLeave
        btn_newemu.Image = System.Drawing.Image.FromFile(".\resources\newemu.gif")
        GC.Collect()

    End Sub

    Private Sub btn_newemu_MouseDown(sender As Object, e As MouseEventArgs) Handles btn_newemu.MouseDown
        If ((global_settings(12).Split("="))(1)) = "1" Then
            MessageBox.Show("You cannot download new emulators in offline mode.")
        Else
            newemulator.Show()
        End If
        btn_newemu.Image = System.Drawing.Image.FromFile(".\resources\newemuclick.png")
    End Sub

    Private Sub btn_newemu_MouseUp(sender As Object, e As MouseEventArgs) Handles btn_newemu.MouseUp
        btn_newemu.Image = System.Drawing.Image.FromFile(".\resources\newemuwhite.png")
    End Sub

    Public Sub emu_one_Click(sender As Object, e As EventArgs) Handles emu_one.Click
        tab_index = 0
        Call module_emutabs.load_emutab()
        If dark = 1 Then
            emu_one.ForeColor = Color.FromArgb(23, 191, 99)
        ElseIf dark = 2 Or dark = 3 Then
            emu_one.ForeColor = Color.White
        Else
            emu_one.ForeColor = Color.Black
        End If
    End Sub

    Public Sub emu_two_Click(sender As Object, e As EventArgs) Handles emu_two.Click
        tab_index = 1
        Call module_emutabs.load_emutab()
        If dark = 1 Then
            emu_two.ForeColor = Color.FromArgb(23, 191, 99)
        ElseIf dark = 2 Or dark = 3 Then
            emu_two.ForeColor = Color.White
        Else
            emu_two.ForeColor = Color.Black
        End If
    End Sub

    Public Sub emu_three_Click(sender As Object, e As EventArgs) Handles emu_three.Click
        tab_index = 2
        Call module_emutabs.load_emutab()
        If dark = 1 Then
            emu_three.ForeColor = Color.FromArgb(23, 191, 99)
        ElseIf dark = 2 Or dark = 3 Then
            emu_three.ForeColor = Color.White
        Else
            emu_three.ForeColor = Color.Black
        End If
    End Sub

    Public Sub emu_four_Click(sender As Object, e As EventArgs) Handles emu_four.Click
        tab_index = 3
        Call module_emutabs.load_emutab()
        If dark = 1 Then
            emu_four.ForeColor = Color.FromArgb(23, 191, 99)
        ElseIf dark = 2 Or dark = 3 Then
            emu_four.ForeColor = Color.White
        Else
            emu_four.ForeColor = Color.Black
        End If
    End Sub

    Public Sub emu_five_Click(sender As Object, e As EventArgs) Handles emu_five.Click
        tab_index = 4
        Call module_emutabs.load_emutab()
        If dark = 1 Then
            emu_five.ForeColor = Color.FromArgb(23, 191, 99)
        ElseIf dark = 2 Or dark = 3 Then
            emu_five.ForeColor = Color.White
        Else
            emu_five.ForeColor = Color.Black
        End If
    End Sub

    Public Sub emu_six_Click(sender As Object, e As EventArgs) Handles emu_six.Click
        tab_index = 5
        Call module_emutabs.load_emutab()
        If dark = 1 Then
            emu_six.ForeColor = Color.FromArgb(23, 191, 99)
        ElseIf dark = 2 Or dark = 3 Then
            emu_six.ForeColor = Color.White
        Else
            emu_six.ForeColor = Color.Black
        End If
    End Sub

    Public Sub emu_seven_Click(sender As Object, e As EventArgs) Handles emu_seven.Click
        tab_index = 6
        Call module_emutabs.load_emutab()
        If dark = 1 Then
            emu_seven.ForeColor = Color.FromArgb(23, 191, 99)
        ElseIf dark = 2 Or dark = 3 Then
            emu_seven.ForeColor = Color.White
        Else
            emu_seven.ForeColor = Color.Black
        End If
    End Sub

    Public Sub emu_eight_Click(sender As Object, e As EventArgs) Handles emu_eight.Click
        tab_index = 7
        Call module_emutabs.load_emutab()
        If dark = 1 Then
            emu_eight.ForeColor = Color.FromArgb(23, 191, 99)
        ElseIf dark = 2 Or dark = 3 Then
            emu_eight.ForeColor = Color.White
        Else
            emu_eight.ForeColor = Color.Black
        End If
    End Sub

    Public Sub emu_nine_Click(sender As Object, e As EventArgs) Handles emu_nine.Click
        tab_index = 8
        Call module_emutabs.load_emutab()
        If dark = 1 Then
            emu_nine.ForeColor = Color.FromArgb(23, 191, 99)
        ElseIf dark = 2 Or dark = 3 Then
            emu_nine.ForeColor = Color.White
        Else
            emu_nine.ForeColor = Color.Black
        End If
    End Sub
    Private Sub btn_play_MouseEnter(sender As Object, e As EventArgs) Handles btn_play.MouseEnter
        btn_play.Image = System.Drawing.Image.FromFile(".\resources\playwhite.png")
    End Sub

    Private Sub btn_play_MouseLeave(sender As Object, e As EventArgs) Handles btn_play.MouseLeave
        If thread_emulator_update.IsBusy = False Then
            btn_play.Image = System.Drawing.Image.FromFile(".\resources\playblack.gif")
        End If
        GC.Collect()
    End Sub

    Public Sub btn_play_MouseDown(sender As Object, e As MouseEventArgs) Handles btn_play.MouseDown
        btn_play.Image = System.Drawing.Image.FromFile(".\resources\playclick.png")
        Call module_emulatorupdater.emulator_updater()
        Call jumpin_updater()
        Call lastplayed()
    End Sub

    Private Sub btn_play_MouseUp(sender As Object, e As MouseEventArgs) Handles btn_play.MouseUp
        If thread_emulator_update.IsBusy = True Then
            btn_play.Image = System.Drawing.Image.FromFile(".\resources\updatingplay.png")
        Else
            btn_play.Image = System.Drawing.Image.FromFile(".\resources\playwhite.png")
        End If

    End Sub

    Private Sub lbl_about_Click(sender As Object, e As EventArgs) Handles lbl_about.Click
        about.Show()
    End Sub

    Private Sub lbl_github_Click(sender As Object, e As EventArgs) Handles lbl_github.Click
        If ((global_settings(12).Split("="))(1)) = "1" Then
            MessageBox.Show("This feature is not available in offline mode.")
        Else
            Process.Start("https://github.com/ParthK117/W-Emuloader")
        End If
    End Sub

    Private Sub btn_import_MouseDown(sender As Object, e As MouseEventArgs) Handles btn_import.MouseDown
        panel_import_click.Visible = True
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
        If listbox_availableroms.SelectedItems IsNot Nothing And listbox_availableroms.FocusedItem IsNot Nothing Then
            lbl_rom_source.Visible = True
            lbl_rom_size.Visible = True
            lbl_rom_platform.Visible = True
            lbl_rom_name.Text = listbox_availableroms.FocusedItem.SubItems(0).Text
            lbl_rom_platform.Text = "Platform: " & listbox_availableroms.FocusedItem.SubItems(2).Text
            lbl_rom_source.Text = "From " & listbox_availableroms.FocusedItem.SubItems(3).Text
            lbl_rom_size.Text = "Size: " & listbox_availableroms.FocusedItem.SubItems(1).Text
        End If
    End Sub

    Private Sub listbox_search_SelectedIndexChanged(sender As Object, e As EventArgs) Handles listbox_search.SelectedIndexChanged
        If listbox_search.SelectedItems IsNot Nothing And listbox_search.FocusedItem IsNot Nothing Then
            lbl_rom_source.Visible = True
            lbl_rom_size.Visible = True
            lbl_rom_platform.Visible = True
            lbl_rom_name.Text = listbox_search.FocusedItem.SubItems(0).Text
            lbl_rom_platform.Text = "Platform: " & listbox_search.FocusedItem.SubItems(2).Text
            lbl_rom_source.Text = "From " & listbox_search.FocusedItem.SubItems(3).Text
            lbl_rom_size.Text = "Size: " & listbox_search.FocusedItem.SubItems(1).Text
        End If
    End Sub

    Private Sub btn_browse_Click(sender As Object, e As EventArgs) Handles btn_browse.Click
        If ((global_settings(12).Split("="))(1)) = "1" Then
            MessageBox.Show("You cannot download new games in offline mode.")
        Else
            tab_browse.Visible = True
            panel_cancel.Visible = False
            panel_browse.BringToFront()
            Dim emutabs = {emu_one, emu_two, emu_three, emu_four, emu_five, emu_six, emu_seven, emu_eight, emu_nine}
            For Each x In emutabs
                x.ForeColor = labelgrey
            Next
            panel_rom_info.Visible = True
            panel_rom_rightclick.Visible = False
            panel_import_click.Visible = False
            btn_showdownloads.ForeColor = main.labelgrey
            btn_parameters.ForeColor = main.labelgrey
        End If

    End Sub

    Private Sub load_roms_list()
        'This loads roms into the browse menu and is loaded in on main_load.
        'If lists directory doesn't exist the directory is made.
        If Directory.Exists(".\lists\") = False Then
            Directory.CreateDirectory(".\lists")
        End If
        'For every list file in the \lists\ directory, add the contents of the list file into imported_list_downloads, one entry for each game. 
        'Afterwards, Split the first entry (list metadata) on every occurance of #, and if # is contained then set showsource to true. This allows backwards compatibility with older lists that contained no metadata.
        Dim list_directory As New DirectoryInfo(".\lists\")
        For Each list In list_directory.GetFiles()
            Dim imported_list_downloads As New List(Of String)
            imported_list_downloads.AddRange(File.ReadAllLines(".\lists\" & list.ToString))
            Dim showsource As Boolean = False
            Dim metadata As String()
            If imported_list_downloads(0).Contains("#") Then
                metadata = Split(imported_list_downloads(0), "#")
                'If source metadata is found, showsource is flipped to true
                showsource = True
                imported_list_downloads.RemoveAt(0)
            End If


            Dim region As String
            'For every entry in imported list downloads (x), import into listview
            For Each entry In imported_list_downloads
                Dim entry_split As String() = Split(entry, ",")
                Dim file_source As String = entry_split(3)
                If file_source.Contains("google") Then
                    'Hardcode google drive recognition from url.
                    file_source = "Google Drive"
                ElseIf showsource = True Then
                    file_source = metadata(0)
                Else
                    file_source = "Other"
                End If
                'If keywords are found in the title of the game, the region string is changed accordingly.
                If entry_split(0).Contains("Europe") Or entry_split(0).Contains("(E)") Or entry_split(0).Contains("EUR") Or entry_split(0).Contains("Europe") Or entry_split(0).Contains("(F)") Or entry_split(0).Contains("(e)") Or entry_split(0).Contains("Ge") Or entry_split(0).Contains("Fr") Or entry_split(0).Contains("It") Or entry_split(0).Contains("Es") Then
                    region = "Europe"
                ElseIf entry_split(0).Contains("USA") Or entry_split(0).Contains("(U)") Or entry_split(0).Contains("usa") Or entry_split(0).Contains("(u)") Or entry_split(0).Contains("(usa)") Then
                    region = "USA"
                ElseIf entry_split(0).Contains("JPN") Or entry_split(0).Contains("(J)") Or entry_split(0).Contains("japan") Or entry_split(0).Contains("(j)") Or entry_split(0).Contains("(Japan)") Then
                    region = "Japan"
                Else
                    region = "Unknown"
                End If
                'The game is added to the listview.
                listbox_availableroms.Items.Add(New ListViewItem(New String() {entry_split(0), entry_split(1), entry_split(2), file_source, entry_split(3), region}))
            Next


            'The listview is autosized first by the content of each column, then the size column is resized to how big 'size' appears, and lastly the url column width is set to 0
            listbox_availableroms.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent)
            listbox_availableroms.AutoResizeColumn(2, ColumnHeaderAutoResizeStyle.HeaderSize)
            listbox_availableroms.Columns.Item(4).Width = 0
        Next
    End Sub

    Private Sub download_roms()
        'First function to be called to set up the queue listbox, which will then call launch_downloader
        Dim timestamp As String = Date.Now.ToString("dd-MM-yyyy")
        'Index is used to insert the currently selected item at the end of the queue, whilst keeping the currently downloading at the top, and completed downloads at the end.
        Dim index As Double = 0
        'Iterate on index every time a download status is queued or downloading.
        For Each entry In listbox_queue.Items
            If entry.subitems(5).text = "Queued" Or entry.subitems(5).text = "Downloading" Then
                index += 1
            End If
        Next
        'Check whether an entry from the search menu or all menu is used when pressing add to queue.
        If panel_search.Visible = True Then
            listbox_queue.Visible = True
            For Each x In listbox_search.SelectedItems
                listbox_queue.Items.Insert(index, New ListViewItem(New String() {x.SubItems(0).Text,
x.SubItems(1).Text,
x.SubItems(2).Text,
x.SubItems(3).Text,
x.SubItems(4).Text, "Queued", timestamp}))
                index += 1
            Next
        Else
            listbox_queue.Visible = True

            For Each x In listbox_availableroms.SelectedItems
                listbox_queue.Items.Insert(index, New ListViewItem(New String() {x.SubItems(0).Text,
x.SubItems(1).Text,
x.SubItems(2).Text,
x.SubItems(3).Text,
x.SubItems(4).Text, "Queued", timestamp}))
            Next
            index += 1
        End If
        'Call launch_downloader from downloads.vb module.
        Call launch_downloader()
    End Sub

    Private Sub btn_queue_MouseEnter(sender As Object, e As EventArgs) Handles btn_queue.MouseEnter
        btn_queue.Image = System.Drawing.Image.FromFile(".\resources\queuewhite.png")
    End Sub

    Private Sub btn_queue_MouseLeave(sender As Object, e As EventArgs) Handles btn_queue.MouseLeave
        btn_queue.Image = System.Drawing.Image.FromFile(".\resources\download.gif")
        GC.Collect()
    End Sub

    Private Sub btn_queue_MouseDown(sender As Object, e As MouseEventArgs) Handles btn_queue.MouseDown
        btn_queue.Image = System.Drawing.Image.FromFile(".\resources\queueclick.png")
        If listbox_availableroms.FocusedItem IsNot Nothing = True Or listbox_search.FocusedItem IsNot Nothing = True Then
            panel_download_chart.Visible = True
            'Call download_roms sub from above.
            Call download_roms()
        Else
            MsgBox("Pick something to download first")
        End If
    End Sub

    Private Sub btn_queue_MouseUp(sender As Object, e As MouseEventArgs) Handles btn_queue.MouseUp
        btn_queue.Image = System.Drawing.Image.FromFile(".\resources\queuewhite.png")
    End Sub

    Private Sub btn_exit_MouseDown(sender As Object, e As MouseEventArgs) Handles btn_exit.MouseDown
        Dim checkbox_exit As String() = (global_settings(4).Split("="))
        If checkbox_exit(1) = "0" Then
            Application.Exit()
        Else
            Me.ShowInTaskbar = False
            Me.WindowState = FormWindowState.Minimized
        End If
    End Sub

    Private Sub btn_minimise_MouseDown(sender As Object, e As MouseEventArgs) Handles btn_minimise.MouseDown
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub btn_maximise_MouseDown(sender As Object, e As MouseEventArgs) Handles btn_maximise.MouseDown
        If Me.WindowState = FormWindowState.Normal Then
            Me.WindowState = FormWindowState.Maximized
            lbl_status.Location = New Point((panel_top.Width - lbl_status.Width) \ 2, (panel_top.Height - lbl_status.Height) \ 2)
            lbl_nothing.Location = New Point((panel_downloads.Width - lbl_nothing.Width) \ 2, (panel_downloads.Height - lbl_nothing.Height) \ 2)
        Else
            Me.WindowState = FormWindowState.Normal
            lbl_status.Location = New Point((panel_top.Width - lbl_status.Width) \ 2, (panel_top.Height - lbl_status.Height) \ 2)
            lbl_nothing.Location = New Point((panel_downloads.Width - lbl_nothing.Width) \ 2, (panel_downloads.Height - lbl_nothing.Height) \ 2)
        End If
    End Sub

    Private Sub btn_import_roms_MouseEnter(sender As Object, e As EventArgs) Handles btn_import_roms.MouseEnter
        btn_import_roms.BackgroundImage = System.Drawing.Image.FromFile(".\resources\importromswhite.png")
    End Sub

    Private Sub btn_import_roms_MouseLeave(sender As Object, e As EventArgs) Handles btn_import_roms.MouseLeave
        btn_import_roms.BackgroundImage = System.Drawing.Image.FromFile(".\resources\importromsblack.png")
    End Sub

    Private Sub btn_import_roms_MouseDown(sender As Object, e As MouseEventArgs) Handles btn_import_roms.MouseDown
        'Folderbrowser is a hack to select a folder even though openfolderdialog does not support it.
        Dim folderBrowser As New OpenFileDialog()
        folderBrowser.ValidateNames = False
        folderBrowser.CheckFileExists = False
        folderBrowser.CheckPathExists = True
        folderBrowser.FileName = "(This folder)"
        If folderBrowser.ShowDialog() = DialogResult.OK Then
            'Gets the directory name of the folder or file.
            Dim folderPath As String = Path.GetDirectoryName(folderBrowser.FileName)
            'Adds the folderPath string to custom.eldr
            If File.Exists(".\custom.eldr") And (New FileInfo(".\custom.eldr").Length > 0) Then
                My.Computer.FileSystem.WriteAllText(".\custom.eldr", vbNewLine & folderPath, True)
            Else
                System.IO.File.Create(".\custom.eldr").Dispose()
                My.Computer.FileSystem.WriteAllText(".\custom.eldr", folderPath, False)
            End If
            'Calls load_installed_roms.
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
        'If the listbox is rightclicked it opens context menu for roms.
        If e.Button = MouseButtons.Right Then
            If listbox_installedroms.SelectedItems.Count > 0 Then
                panel_rom_rightclick.Visible = True
                panel_rom_rightclick.Location = New Point((e.X + 40), (e.Y + 190))
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
        'If a file exists at the installed roms path, first save the path to a string, then remove the entry from the listview and finally remove the file.
        If File.Exists(listbox_installedroms.FocusedItem.SubItems(2).Text) Then
            Dim file_to_delete As String = listbox_installedroms.FocusedItem.SubItems(2).Text
            listbox_installedroms.FocusedItem.Remove()
            My.Computer.FileSystem.DeleteFile(file_to_delete)
            'Hide the context menu.
            panel_rom_rightclick.Visible = False
        End If
    End Sub

    Private Sub btn_rom_properties_Click(sender As Object, e As EventArgs) Handles btn_rom_properties.Click
        romproperties.Show()
        'Call sub in romproperties form.
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
        Select Case dark
            Case 0
                btn_search.ForeColor = Color.Black
            Case 1
                btn_search.ForeColor = Color.FromArgb(23, 191, 99)
            Case 2
                btn_search.ForeColor = Color.White
            Case 3
                btn_search.ForeColor = Color.White
        End Select
        btn_all.ForeColor = labelgrey
        tab_all.Visible = False
        tab_search.Visible = True
        panel_search.Visible = True
    End Sub

    Private Sub btn_all_Click(sender As Object, e As EventArgs) Handles btn_all.Click
        Select Case dark
            Case 0
                btn_all.ForeColor = Color.Black
            Case 1
                btn_all.ForeColor = Color.FromArgb(23, 191, 99)
            Case 2
                btn_all.ForeColor = Color.White
            Case 3
                btn_all.ForeColor = Color.White
        End Select
        panel_platform_tags.Visible = False
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
            btn_search_europe.BackgroundImage = System.Drawing.Image.FromFile(".\resources\searcheuropeblack.png")
            btn_search_usa.BackgroundImage = System.Drawing.Image.FromFile(".\resources\searchusablack.png")
            btn_search_japan.BackgroundImage = System.Drawing.Image.FromFile(".\resources\searchjapanblack.png")
            btn_search_3ds.BackgroundImage = System.Drawing.Image.FromFile(".\resources\search3dsblack.png")
            btn_search_wii.BackgroundImage = System.Drawing.Image.FromFile(".\resources\searchwiiblack.png")
            btn_search_nds.BackgroundImage = System.Drawing.Image.FromFile(".\resources\searchndsblack.png")
            btn_search_gba.BackgroundImage = System.Drawing.Image.FromFile(".\resources\searchgbablack.png")
            btn_search_psp.BackgroundImage = System.Drawing.Image.FromFile(".\resources\searchpspblack.png")
            btn_search_n64.BackgroundImage = System.Drawing.Image.FromFile(".\resources\searchn64black.png")
            btn_search_gbc.BackgroundImage = System.Drawing.Image.FromFile(".\resources\searchgbcblack.png")
            btn_search_gb.BackgroundImage = System.Drawing.Image.FromFile(".\resources\searchgbblack.png")
            btn_search_nes.BackgroundImage = System.Drawing.Image.FromFile(".\resources\searchsnesblack.png")
            btn_search_snes.BackgroundImage = System.Drawing.Image.FromFile(".\resources\searchnesblack.png")
            btn_search_ps1.BackgroundImage = System.Drawing.Image.FromFile(".\resources\searchps1black.png")
            btn_search_ps2.BackgroundImage = System.Drawing.Image.FromFile(".\resources\searchps2black.png")
            btn_search_dc.BackgroundImage = System.Drawing.Image.FromFile(".\resources\searchdcblack.png")
            btn_search_mgd.BackgroundImage = System.Drawing.Image.FromFile(".\resources\searchmgdblack.png")
        End If
    End Sub

    Private Sub textbox_search_Click(sender As Object, e As EventArgs) Handles textbox_search.Click
        If textbox_search.Text = "Search" Then
            textbox_search.Text = ""
        End If
        Call hide_platform_tags()
        Call hide_region_tags()
        btn_platform_tags.ForeColor = labelgrey
    End Sub
    'Maximises window if top bar clicked.
    Private Sub panel_top_DoubleClick(sender As Object, e As EventArgs) Handles panel_top.DoubleClick
        If Me.WindowState = FormWindowState.Normal Then
            Me.WindowState = FormWindowState.Maximized
            lbl_status.Location = New Point((panel_top.Width - lbl_status.Width) \ 2, (panel_top.Height - lbl_status.Height) \ 2)
            lbl_nothing.Location = New Point((panel_downloads.Width - lbl_nothing.Width) \ 2, (panel_downloads.Height - lbl_nothing.Height) \ 2)
        Else
            Me.WindowState = FormWindowState.Normal
            lbl_status.Location = New Point((panel_top.Width - lbl_status.Width) \ 2, (panel_top.Height - lbl_status.Height) \ 2)
            lbl_nothing.Location = New Point((panel_downloads.Width - lbl_nothing.Width) \ 2, (panel_downloads.Height - lbl_nothing.Height) \ 2)
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
        'files is a list with the data of each item dropped in.
        Dim files() As String = e.Data.GetData(DataFormats.FileDrop)
        'For each item (drop_path) in the files list
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
                    Dim check As Boolean = False
                    Dim check_directory As String() = File.ReadAllLines(".\custom.eldr")
                    For Each x In check_directory
                        If x = folderPath Then
                            MessageBox.Show("You've already imported this rom/directory")
                            check = True
                            Exit For

                        End If
                    Next
                    If check = False Then
                        My.Computer.FileSystem.WriteAllText(".\custom.eldr", vbNewLine & folderPath, True)
                    End If
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
            btn_show_lists.BackColor = panel_top.BackColor
            btn_settings.BackColor = panel_right.BackColor
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
        Try
            If File.Exists(".\roms\" & currenttab_metadata(1) & "\metadata\boxartmatches.eldr") Then
                Dim find_art As String() = File.ReadAllLines(".\roms\" & currenttab_metadata(1) & "\metadata\boxartmatches.eldr")
                For Each x In find_art
                    Dim current_name As String() = x.Split("#")
                    If listbox_installedroms.FocusedItem IsNot Nothing = True Then
                        If listbox_installedroms.FocusedItem.SubItems(0).Text.Contains(current_name(0)) Then
                            Try
                                picturebox_boxart.BackgroundImage = System.Drawing.Image.FromFile(current_name(1))
                                romproperties.picturebox_boxart.BackgroundImage = System.Drawing.Image.FromFile(current_name(1))
                                picturebox_boxart_top.BackgroundImage = System.Drawing.Image.FromFile(current_name(1))
                                boxart_url = current_name(1)
                            Catch ex As Exception
                                picturebox_boxart.BackgroundImage = System.Drawing.Image.FromFile(".\modules\noimage.png")
                                romproperties.picturebox_boxart.BackgroundImage = System.Drawing.Image.FromFile(".\modules\noimage.png")
                                picturebox_boxart_top.BackgroundImage = System.Drawing.Image.FromFile(".\modules\noimage.png")
                                boxart_url = current_name(".\modules\noimage.png")
                            End Try

                        End If
                    End If
                Next

            End If
        Catch ex As Exception
        End Try
        If listbox_installedroms.FocusedItem IsNot Nothing = True Then
            lbl_installed_name.Text = listbox_installedroms.FocusedItem.SubItems(0).Text
            Dim size_rom As New IO.FileInfo(listbox_installedroms.FocusedItem.SubItems(2).Text)
            lbl_installed_size.Text = "Size: " & Math.Round((size_rom.Length / 1000000), 2) & " MB"
            lbl_installed_downloadtime.Text = "Downloaded on " & File.GetCreationTime(listbox_installedroms.FocusedItem.SubItems(2).Text)
            lbl_rom_top_name.Text = listbox_installedroms.FocusedItem.SubItems(0).Text
            Call lastplayed()
            GC.Collect()
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
        Dim checkbox_od As String() = (settings(11).Split("="))
        Dim checkbox_offline As String() = (settings(12).Split("="))
        If checkbox_loadart(1) = "1" And checkbox_od(1) = "1" And Not checkbox_offline(1) = "1" Then


            If File.Exists(".\roms\" & currenttab_metadata(1) & "\metadata\boxartmatches.eldr") Then
                Dim boxartmatches As String = File.ReadAllText(".\roms\" & currenttab_metadata(1) & "\metadata\boxartmatches.eldr")

                For Each x In listbox_installedroms.Items
                    If Not (boxartmatches.Replace(" ", "")).Contains((x.subitems(0).text).replace(" ", "")) Then
                        lbl_status.Text = "Downloading Boxart"
                        lbl_status.Location = New Point((panel_top.Width - lbl_status.Width) \ 2, (panel_top.Height - lbl_status.Height) \ 2)
                        picturebox_loading.Visible = True
                        If thread_getboxart.IsBusy = False Then

                            Dim arguments As String()
                            arguments = {currenttab_metadata(1), "boxartatonce"}

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
                    arguments = {currenttab_metadata(1), "boxartatonce"}

                    thread_getboxart.RunWorkerAsync(arguments)
                End If


            End If
        ElseIf checkbox_loadart(1) = "1" And checkbox_od(1) = "0" And Not checkbox_offline(1) = "1" Then

            If File.Exists(".\roms\" & currenttab_metadata(1) & "\metadata\boxartmatches.eldr") Then
                Dim boxartmatches As String = File.ReadAllText(".\roms\" & currenttab_metadata(1) & "\metadata\boxartmatches.eldr")

                For Each x In listbox_installedroms.Items
                    If Not (boxartmatches.Replace(" ", "")).Contains((x.subitems(0).text).replace(" ", "")) Then
                        lbl_status.Text = "Downloading Boxart"
                        lbl_status.Location = New Point((panel_top.Width - lbl_status.Width) \ 2, (panel_top.Height - lbl_status.Height) \ 2)
                        picturebox_loading.Visible = True
                        If thread_getboxart.IsBusy = False Then

                            Dim arguments As String()
                            arguments = {currenttab_metadata(1), "boxartod"}

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
                    arguments = {currenttab_metadata(1), "boxartod"}

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
        p.Arguments = (arguments(1) & " " & arguments(0) & " " & Chr(34) & Path.GetFullPath(".\boxart") & Chr(34) & " " & Chr(34) & Path.GetFullPath(".\roms\" & currenttab_metadata(1) & "\metadata\romnamelist.eldr") & Chr(34) & " " & Chr(34) & Path.GetFullPath(".\roms\" & currenttab_metadata(1) & "\metadata") & Chr(34))
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
        btn_search_gc.BackgroundImage = System.Drawing.Image.FromFile(".\resources\searchgcwhite.png")

    End Sub

    Private Sub btn_search_wiiu_Click(sender As Object, e As EventArgs) Handles btn_search_wiiu.Click
        emu_tab_metadata_list.tag_index = "WIIU"
        Call module_emutabs.button_tags()
        btn_search_wiiu.BackgroundImage = System.Drawing.Image.FromFile(".\resources\searchwiiuwhite.png")

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
        emu_tab_metadata_list.tag_index = "PSX"
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
        Dim result = MessageBox.Show("Are you sure you want to delete this emulator instance? Your roms for this platform will not be deleted.", "Deleting " & currenttab_metadata(0), MessageBoxButtons.YesNo)
        If result = DialogResult.Yes Then
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
            If Not custom.Count = 0 Then
                System.IO.File.Create(".\installed.eldr").Dispose()


                Dim writenew = New StreamWriter(".\installed.eldr", False)
                For Each x In custom
                    If x Is custom.Last Then
                        writenew.Write(x)
                    Else
                        writenew.Write(x & vbNewLine)
                    End If

                Next

                writenew.Flush()
                writenew.Close()
            End If
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
        End If
    End Sub

    Private Sub btn_play_delete_MouseUp(sender As Object, e As MouseEventArgs) Handles btn_play_delete.MouseUp
        btn_play_delete.BackgroundImage = System.Drawing.Image.FromFile(".\resources\deleteplaywhite.png")
    End Sub
    Public Sub check_for_updates()
        If Not File.Exists(".\settings.dat") Then
            Dim new_settings As String = "load=1" & vbNewLine & "dark=0" & vbNewLine & "version=" & version_number & vbNewLine & "autoupdate=1" & vbNewLine & "exitonx=0" & vbNewLine & "fancydl=0" & vbNewLine & "firstime=1" & vbNewLine & "windowsbar=0" & vbNewLine & "instantdelivery=1" & vbNewLine & "shop=google" & vbNewLine & "affiliate=0" & vbNewLine & "boxartod=0" & vbNewLine & "offline=0"
            File.WriteAllText(".\settings.dat", new_settings)
        Else
            Dim settings As New List(Of String)
            settings.AddRange(File.ReadAllLines(".\settings.dat"))

            If Not settings(2).Contains(version_number) Then
                File.Delete(".\settings.dat")
                Try
                    Dim new_settings As String = settings(0) & vbNewLine & settings(1) & vbNewLine & "version=" & version_number & vbNewLine & settings(3) & vbNewLine & settings(4) & vbNewLine & settings(5) & vbNewLine & settings(6) & vbNewLine & settings(7) & vbNewLine & settings(8) & vbNewLine & settings(9) & vbNewLine & settings(10) & vbNewLine & settings(11) & vbNewLine & settings(12)
                    File.WriteAllText(".\settings.dat", new_settings)
                Catch ex As Exception
                    MessageBox.Show("The new update is incompatible with your old settings, sorry. Launching first-time setup.")
                    Dim new_settings As String = "load=1" & vbNewLine & "dark=0" & vbNewLine & "version=" & version_number & vbNewLine & "autoupdate=1" & vbNewLine & "exitonx=0" & vbNewLine & "fancydl=0" & vbNewLine & "firstime=1" & vbNewLine & "windowsbar=0" & vbNewLine & "instantdelivery=1" & vbNewLine & "shop=google" & vbNewLine & "affiliate=0" & vbNewLine & "boxartod=0" & vbNewLine & "offline=0"
                    File.WriteAllText(".\settings.dat", new_settings)
                End Try
            End If
        End If
        Dim settings2 As New List(Of String)
        settings2.AddRange(File.ReadAllLines(".\settings.dat"))
        If settings2(3).Contains("1") And Not settings2(12).Contains("1") Then
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
        End If
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

    Private Sub btn_search_mgd_Click(sender As Object, e As EventArgs) Handles btn_search_mgd.Click
        emu_tab_metadata_list.tag_index = "MGD"
        Call module_emutabs.button_tags()
        btn_search_mgd.BackgroundImage = System.Drawing.Image.FromFile(".\resources\searchmgdwhite.png")
    End Sub

    Private Sub btn_search_dc_Click(sender As Object, e As EventArgs) Handles btn_search_dc.Click
        emu_tab_metadata_list.tag_index = "DC"
        Call module_emutabs.button_tags()
        btn_search_dc.BackgroundImage = System.Drawing.Image.FromFile(".\resources\searchdcwhite.png")
    End Sub

    Private Sub btn_platform_tags_Click(sender As Object, e As EventArgs) Handles btn_platform_tags.Click
        Call hide_region_tags()
        panel_platform_tags.Visible = True
        If dark = 1 Then
            btn_platform_tags.ForeColor = Color.FromArgb(23, 191, 99)
        ElseIf dark = 2 Or dark = 3 Then
            btn_platform_tags.ForeColor = Color.White
        Else

            btn_platform_tags.ForeColor = Color.Black
        End If


    End Sub

    Private Sub panel_browse_MouseDown(sender As Object, e As MouseEventArgs) Handles panel_browse.MouseDown
        Call hide_platform_tags()
        Call hide_region_tags()
    End Sub

    Private Sub listbox_search_MouseDown(sender As Object, e As MouseEventArgs) Handles listbox_search.MouseDown
        Call hide_platform_tags()
        Call hide_region_tags()
    End Sub
    Public Sub hide_platform_tags()
        panel_platform_tags.Visible = False
        btn_platform_tags.ForeColor = labelgrey
    End Sub
    Public Sub hide_region_tags()
        panel_region_tags.Visible = False
        btn_region.ForeColor = labelgrey
    End Sub

    Private Sub btn_region_Click(sender As Object, e As EventArgs) Handles btn_region.Click
        Call hide_platform_tags()

        panel_region_tags.Visible = True
        If dark = 1 Then
            btn_region.ForeColor = Color.FromArgb(23, 191, 99)
        ElseIf dark = 2 Or dark = 3 Then
            btn_region.ForeColor = Color.White
        Else
            btn_region.ForeColor = Color.Black
        End If
    End Sub

    Private Sub btn_search_europe_Click(sender As Object, e As EventArgs) Handles btn_search_europe.Click
        emu_tab_metadata_list.tag_index = "EUR"
        Call module_emutabs.button_regions()
        btn_search_europe.BackgroundImage = System.Drawing.Image.FromFile(".\resources\searcheuropewhite.png")
    End Sub

    Private Sub btn_search_usa_Click(sender As Object, e As EventArgs) Handles btn_search_usa.Click
        emu_tab_metadata_list.tag_index = "USA"
        Call module_emutabs.button_regions()
        btn_search_usa.BackgroundImage = System.Drawing.Image.FromFile(".\resources\searchusawhite.png")
    End Sub

    Private Sub btn_search_japan_Click(sender As Object, e As EventArgs) Handles btn_search_japan.Click
        emu_tab_metadata_list.tag_index = "JPN"
        Call module_emutabs.button_regions()
        btn_search_japan.BackgroundImage = System.Drawing.Image.FromFile(".\resources\searchjapanwhite.png")
    End Sub

    Private Sub btn_rom_viewfile_Click(sender As Object, e As EventArgs) Handles btn_rom_viewfile.Click
        If File.Exists(listbox_installedroms.FocusedItem.SubItems(2).Text) Then
            Dim path As String = listbox_installedroms.FocusedItem.SubItems(2).Text
            Process.Start("explorer.exe", "/select," + path)
        Else
            MsgBox("File not found.")
        End If
        panel_rom_rightclick.Visible = False
    End Sub

    Private Sub btn_rom_viewfile_MouseEnter(sender As Object, e As EventArgs) Handles btn_rom_viewfile.MouseEnter
        btn_rom_viewfile.BackgroundImage = System.Drawing.Image.FromFile(".\resources\viewfileblack.png")
    End Sub

    Private Sub btn_rom_viewfile_MouseLeave(sender As Object, e As EventArgs) Handles btn_rom_viewfile.MouseLeave
        btn_rom_viewfile.BackgroundImage = System.Drawing.Image.FromFile(".\resources\viewfilewhite.png")
    End Sub

    Private Sub notify_emuloader_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles notify_emuloader.MouseDoubleClick
        Me.WindowState = FormWindowState.Normal
        Me.ShowInTaskbar = True
        panel_blue_click.BringToFront()
    End Sub

    Private Sub notify_emuloader_Click(sender As Object, e As EventArgs) Handles notify_emuloader.Click


    End Sub

    Private Sub btn_showdownloads_Click(sender As Object, e As EventArgs) Handles btn_showdownloads.Click
        panel_downloads.BringToFront()
        panel_cancel.Visible = True
        If dark = 1 Or dark = 2 Or dark = 3 Then
            btn_showdownloads.ForeColor = Color.White
        Else
            btn_showdownloads.ForeColor = Color.Black
        End If
    End Sub

    Private Sub downloader_DoWork(sender As Object, e As DoWorkEventArgs) Handles downloader.DoWork
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
        Dim arguments As String() = (e.Argument)
        Dim iszip = False

        Try
            Dim downloader_proc As Process
            Dim p2 As New ProcessStartInfo
            p2.FileName = "anylink.exe"

            '   p.UseShellExecute = True
            p2.WindowStyle = ProcessWindowStyle.Hidden
            p2.WorkingDirectory = ".\modules\"
            p2.Arguments = (Chr(34) & arguments(2) & Chr(34) & " " & Chr(34) & System.IO.Path.GetFullPath(".\roms\" & arguments(1)) & "\" & arguments(0) & Chr(34))
            downloader_proc = Process.Start(p2)
            downloader_proc.WaitForExit()
            My.Computer.FileSystem.RenameFile(".\roms\" & arguments(1) & "\" & arguments(0), arguments(0).Replace("$", " "))

            Try


                Using zipFile2 = ZipFile.OpenRead(".\roms\" & arguments(1) & "\" & arguments(0).Replace("$", " "))
                    Dim entries = zipFile2.Entries
                    iszip = True

                End Using




                If iszip = True Then

                    'unzip file
                    If File.Exists(".\roms\" & arguments(1) & "\temp.zip") Then
                        My.Computer.FileSystem.DeleteFile(".\roms\" & arguments(1) & "\temp.zip")
                    End If
                    My.Computer.FileSystem.RenameFile(".\roms\" & arguments(1) & "\" & arguments(0).Replace("$", " "), "temp.zip")

                    '  ZipFile.ExtractToDirectory(".\roms\" & arguments(1) & "\temp.zip", ".\roms\" & arguments(1) & "\")

                    Using zipfile3 = ZipFile.OpenRead(".\roms\" & arguments(1) & "\temp.zip")
                        For Each entry As ZipArchiveEntry In zipfile3.Entries


                            entry.ExtractToFile(Path.Combine(".\roms\" & arguments(1) & "\", entry.FullName), True)

                        Next
                    End Using

                    My.Computer.FileSystem.DeleteFile(".\roms\" & arguments(1) & "\temp.zip")
                End If



            Catch __unusedInvalidDataException1__ As InvalidDataException

            Catch ex As IOException

                MessageBox.Show("Error unzipping")
            End Try


            If arguments(0).Contains(".7z") Or arguments(0).Contains(".rar") Then

                Dim un7z As Process
                Dim p As New ProcessStartInfo
                p.FileName = ".\7z.exe"

                '   p.UseShellExecute = True
                p.WindowStyle = ProcessWindowStyle.Hidden
                p.WorkingDirectory = ".\modules\7zip"
                p.Arguments = ("e" & " " & Chr(34) & System.IO.Path.GetFullPath(".\roms\" & arguments(1) & "\" & arguments(0).Replace("$", " ")) & Chr(34) & " -y -o" & Chr(34) & System.IO.Path.GetFullPath(".\roms\" & arguments(1) & "\") & Chr(34))
                '   MessageBox.Show("e" & " " & Chr(34) & System.IO.Path.GetFullPath(".\roms\" & arguments(1) & "\" & arguments(0).Replace("$", " ")) & Chr(34) & "-aoa -o" & Chr(34) & System.IO.Path.GetFullPath(".\roms\" & arguments(1) & "\") & Chr(34))
                un7z = Process.Start(p)
                un7z.WaitForExit()
                If File.Exists(System.IO.Path.GetFullPath(".\roms\" & arguments(1) & "\" & arguments(0).Replace("$", " "))) Then
                    File.Delete(System.IO.Path.GetFullPath(".\roms\" & arguments(1) & "\" & arguments(0).Replace("$", " ")))
                End If
            End If



        Catch ex As Exception

            MessageBox.Show("Error downloading")


        End Try

    End Sub

    Private Sub downloader_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles downloader.RunWorkerCompleted
        listbox_queue.Items(0).SubItems(5).Text = "Completed"
        If Not File.Exists(".\downloadlog.dat") Then
            File.Create(".\downloadlog.dat")
        End If
        Try
            Dim log As String = File.ReadAllText(".\downloadlog.dat")
            File.WriteAllText(".\downloadlog.dat", listbox_queue.Items(0).SubItems(0).Text & "," & listbox_queue.Items(0).SubItems(1).Text & "," & listbox_queue.Items(0).SubItems(2).Text & "," & listbox_queue.Items(0).SubItems(3).Text & "," & "removed" & "," & listbox_queue.Items(0).SubItems(5).Text & "," & listbox_queue.Items(0).SubItems(6).Text & vbNewLine & log)
        Catch ex As Exception
        End Try
        timer_updateprogress.Enabled = False
            lbl_status.Text = "Downloaded " & listbox_queue.Items(0).SubItems(0).Text
        lbl_status.Location = New Point((panel_top.Width - lbl_status.Width) \ 2, (panel_top.Height - lbl_status.Height) \ 2)
        Call load_installed_roms()

        Dim index As Double = 0
        For Each x In listbox_queue.Items
            If x.subitems(5).text = "Queued" Or x.subitems(5).text = "Downloading" Then
                index += 1
            End If
        Next
        Dim item = listbox_queue.Items(0)
        listbox_queue.Items.RemoveAt(0)
        listbox_queue.Items.Insert(index, item)
        For Each x In listbox_queue.Items
            If Not x.subitems(5).text = "Queued" Then
                picturebox_loading.Visible = False
                panel_download_chart.Visible = False
                lbl_speed.Text = "0 MB/s CURRENT"
                timer_updateprogress.Enabled = False
                notify_emuloader.Text = "Emuloader"
            Else

                picturebox_loading.Visible = True
                Call launch_downloader()
                Exit For
            End If
        Next

    End Sub

    Private Sub timer_updateprogress_Tick(sender As Object, e As EventArgs) Handles timer_updateprogress.Tick
        picturebox_loading.Visible = True

        Try
            Dim outputlog As String = File.ReadAllText(".\modules\outputlog.txt")
            Dim metadata As New List(Of String)
            metadata.AddRange(outputlog.Split(","))
            If metadata(0) = "wget" Then
                Dim displaysize As Double = Math.Round(((metadata(2) / metadata(3)) * 100), 2)
                lbl_status.Text = "Downloading " & listbox_queue.Items(0).SubItems(0).Text & " " & displaysize & "%"
                notify_emuloader.Text = "Downloading ROM" & " " & displaysize & "%"
                lbl_status.Location = New Point((panel_top.Width - lbl_status.Width) \ 2, (panel_top.Height - lbl_status.Height) \ 2)
            ElseIf metadata(0) = "wgetfailed" Then
                lbl_status.Text = "Downloading " & listbox_queue.Items(0).SubItems(0).Text

                Dim currfile As New FileInfo(".\roms\" & downloadqueue.arguments(1) & "\" & downloadqueue.arguments(0))
                Dim currentsize As Double = (currfile.Length)
                metadata(2) = currentsize
                lbl_status.Location = New Point((panel_top.Width - lbl_status.Width) \ 2, (panel_top.Height - lbl_status.Height) \ 2)
            End If




            Dim difference As Long = metadata(2) - speed
            If Math.Round((difference / 1000000), 2) > 1 Then
                lbl_speed.Text = Math.Round((difference / 1000000), 2) & " MB/s CURRENT"
            ElseIf Math.Round((difference / 1000), 2) > 0 Then
                lbl_speed.Text = Math.Round((difference / 1000), 2) & " KB/s CURRENT"
            End If

            If difference > peak Then

                If Math.Round((difference / 1000000), 2) > 1 Then
                    lbl_peak.Text = Math.Round((difference / 1000000), 2) & " MB/s PEAK"
                Else
                    lbl_peak.Text = Math.Round((difference / 1000), 2) & " KB/s PEAK"
                End If
                peak = difference
            End If
            speed = metadata(2)
            If difference > 0 Then
                total += difference
            End If

            If Math.Round((total / 1000000000), 2) > 1 Then
                lbl_total.Text = Math.Round((total / 1000000000), 2) & " GB TOTAL"
            ElseIf Math.Round((total / 1000000), 2) > 1 Then
                lbl_total.Text = Math.Round((total / 1000000), 2) & " MB TOTAL"
            ElseIf Math.Round((total / 1000), 2) > 0 Then
                lbl_total.Text = Math.Round((total / 1000), 2) & " KB TOTAL"
            End If
        Catch ex As Exception
            'file being used by python
        End Try


    End Sub

    Private Sub btn_parameters_Click(sender As Object, e As EventArgs) Handles btn_parameters.Click
        parameters.Show()

        If dark = 1 Or dark = 2 Or dark = 3 Then
            btn_parameters.ForeColor = Color.White
        Else
            btn_parameters.ForeColor = Color.Black
        End If
    End Sub

    Private Sub btn_fromeldr_Click(sender As Object, e As EventArgs) Handles btn_fromeldr.Click
        panel_import_click.Visible = False
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

    Private Sub btn_fromeldr_MouseEnter(sender As Object, e As EventArgs) Handles btn_fromeldr.MouseEnter
        btn_fromeldr.BackgroundImage = System.Drawing.Image.FromFile(".\resources\fromeldrblack.png")
    End Sub

    Private Sub btn_fromeldr_MouseLeave(sender As Object, e As EventArgs) Handles btn_fromeldr.MouseLeave
        btn_fromeldr.BackgroundImage = System.Drawing.Image.FromFile(".\resources\fromeldrwhite.png")
    End Sub
    Private Sub panel_browse_Click(sender As Object, e As EventArgs) Handles panel_browse.Click
        panel_import_click.Visible = False
    End Sub

    Private Sub btn_fromlink_Click(sender As Object, e As EventArgs) Handles btn_fromlink.Click
        panel_import_click.Visible = False
        listlink.Show()
    End Sub

    Private Sub btn_fromlink_MouseEnter(sender As Object, e As EventArgs) Handles btn_fromlink.MouseEnter
        btn_fromlink.BackgroundImage = System.Drawing.Image.FromFile(".\resources\fromlinkblack.png")
    End Sub

    Private Sub btn_fromlink_MouseLeave(sender As Object, e As EventArgs) Handles btn_fromlink.MouseLeave
        btn_fromlink.BackgroundImage = System.Drawing.Image.FromFile(".\resources\fromlinkwhite.png")
    End Sub

    Private Sub picturebox_tungsten_Click(sender As Object, e As EventArgs) Handles picturebox_tungsten.Click
        Process.Start("https://tungstencore.com/emuloader/")
    End Sub

    Private Sub btn_discord_Click(sender As Object, e As EventArgs) Handles btn_discord.Click
        Process.Start("https://discord.gg/bhnr6kM")
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        If Not listbox_queue.Items.Count = 0 Then
            If listbox_queue.Items(0).SubItems(5).Text = "Downloading" Then
                Dim result = MessageBox.Show("Are you sure you want to cancel all queued and current downloads?", "Currently downloading", MessageBoxButtons.YesNo)
                If result = DialogResult.Yes Then

                    If Not File.Exists(".\downloadlog.dat") Then
                        File.Create(".\downloadlog.dat")
                        File.WriteAllText(".\downloadlog.dat", listbox_queue.Items(0).SubItems(0).Text & "," & listbox_queue.Items(0).SubItems(1).Text & "," & listbox_queue.Items(0).SubItems(2).Text & "," & listbox_queue.Items(0).SubItems(3).Text & "," & "removed" & "," & "Cancelled" & "," & listbox_queue.Items(0).SubItems(6).Text)

                    Else
                        Dim log As String = File.ReadAllText(".\downloadlog.dat")
                        File.WriteAllText(".\downloadlog.dat", listbox_queue.Items(0).SubItems(0).Text & "," & listbox_queue.Items(0).SubItems(1).Text & "," & listbox_queue.Items(0).SubItems(2).Text & "," & listbox_queue.Items(0).SubItems(3).Text & "," & "removed" & "," & "Cancelled" & "," & listbox_queue.Items(0).SubItems(6).Text & vbNewLine & log)
                    End If

                    For Each x In listbox_queue.Items
                        If x.subitems(5).text = "Queued" Then
                            Dim log As String = File.ReadAllText(".\downloadlog.dat")
                            File.WriteAllText(".\downloadlog.dat", x.SubItems(0).Text & "," & x.SubItems(1).Text & "," & x.SubItems(2).Text & "," & x.SubItems(3).Text & "," & "removed" & "," & "Cancelled" & "," & x.SubItems(6).Text & vbNewLine & log)
                        End If
                    Next
                    Application.Exit()
                End If

            Else
                Application.Exit()
            End If
        Else
            Application.Exit()
        End If
    End Sub

    Private Sub ShowDownloadsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ShowDownloadsToolStripMenuItem.Click
        Me.WindowState = FormWindowState.Normal
        Me.ShowInTaskbar = True
        panel_blue_click.BringToFront()
        panel_downloads.BringToFront()
    End Sub

    Private Sub SettingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SettingsToolStripMenuItem.Click
        settings.Show()
    End Sub
    Private Sub Main_ResizeEnd(ByVal sender As Object, ByVal e As EventArgs) Handles Me.SizeChanged
        lbl_nothing.Location = New Point((panel_downloads.Width - lbl_nothing.Width) \ 2, (panel_downloads.Height - lbl_nothing.Height) \ 2)
        lbl_status.Location = New Point((panel_top.Width - lbl_status.Width) \ 2, (panel_top.Height - lbl_status.Height) \ 2)
        If Me.WindowState = FormWindowState.Maximized Then
            Dim screenHeight As Integer = Screen.PrimaryScreen.Bounds.Height
            If screenHeight.ToString = "1440" Then
                Me.MaximumSize = New Size(2560, 1440)
            ElseIf screenHeight.ToString = "1080" Then
                Me.MaximumSize = New Size(1920, 1080)
            End If
        Else
            Me.MaximumSize = New Size(4320, 4320)
        End If

    End Sub

    Private Sub button_cancel_MouseEnter(sender As Object, e As EventArgs) Handles btn_cancel.MouseEnter
        btn_cancel.BackgroundImage = System.Drawing.Image.FromFile(".\resources\cancelwhite.png")
    End Sub

    Private Sub button_cancel_MouseLeave(sender As Object, e As EventArgs) Handles btn_cancel.MouseLeave
        btn_cancel.BackgroundImage = System.Drawing.Image.FromFile(".\resources\cancelblack.png")
    End Sub

    Private Sub button_cancel_MouseDown(sender As Object, e As MouseEventArgs) Handles btn_cancel.MouseDown

        btn_cancel.BackgroundImage = System.Drawing.Image.FromFile(".\resources\cancelclick.png")
        If listbox_queue.SelectedItems IsNot Nothing And listbox_queue.FocusedItem IsNot Nothing Then
            If listbox_queue.SelectedItems IsNot Nothing And listbox_queue.FocusedItem.SubItems(5).Text = "Queued" Or listbox_queue.FocusedItem.SubItems(5).Text = "Downloading" And Not listbox_queue.FocusedItem.SubItems(5).Text = "Downloading" Then
                listbox_queue.FocusedItem.SubItems(5).Text = "Cancelled"
                If Not File.Exists(".\downloadlog.dat") Then
                    File.Create(".\downloadlog.dat")
                    File.WriteAllText(".\downloadlog.dat", listbox_queue.Items(0).SubItems(0).Text & "," & listbox_queue.Items(0).SubItems(1).Text & "," & listbox_queue.Items(0).SubItems(2).Text & "," & listbox_queue.Items(0).SubItems(3).Text & "," & "removed" & "," & listbox_queue.Items(0).SubItems(5).Text & "," & listbox_queue.Items(0).SubItems(6).Text)

                Else
                    Dim log As String = File.ReadAllText(".\downloadlog.dat")
                    File.WriteAllText(".\downloadlog.dat", listbox_queue.Items(0).SubItems(0).Text & "," & listbox_queue.Items(0).SubItems(1).Text & "," & listbox_queue.Items(0).SubItems(2).Text & "," & listbox_queue.Items(0).SubItems(3).Text & "," & "removed" & "," & listbox_queue.Items(0).SubItems(5).Text & "," & listbox_queue.Items(0).SubItems(6).Text & vbNewLine & log)
                End If

            ElseIf listbox_queue.FocusedItem.SubItems(5).Text = "Downloading" Then
                MessageBox.Show("Cannot cancel currently downloading file.")
            Else
                MessageBox.Show("Cannot cancel a past download.")
            End If


        Else
            MessageBox.Show("Nothing selected to cancel!")
        End If
    End Sub

    Private Sub listbox_queue_SelectedIndexChanged(sender As Object, e As EventArgs) Handles listbox_queue.SelectedIndexChanged
        If listbox_queue.SelectedItems IsNot Nothing And listbox_queue.FocusedItem IsNot Nothing Then
            lbl_rom_source.Visible = True
            lbl_rom_size.Visible = True
            lbl_rom_platform.Visible = True
            lbl_rom_platform.Text = "Platform: " & listbox_queue.FocusedItem.SubItems(2).Text
            lbl_rom_source.Text = "From " & listbox_queue.FocusedItem.SubItems(3).Text
            lbl_rom_size.Text = "Size: " & listbox_queue.FocusedItem.SubItems(1).Text
        End If
    End Sub

    Private Sub main_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dim checkbox_exit As String() = (global_settings(4).Split("="))
        If checkbox_exit(1) = "0" Then
            If Not listbox_queue.Items.Count = 0 Then
                If listbox_queue.Items(0).SubItems(5).Text = "Downloading" Then
                    Dim result = MessageBox.Show("Are you sure you want to cancel all queued and current downloads?", "Currently downloading", MessageBoxButtons.YesNo)
                    If result = DialogResult.Yes Then

                        If Not File.Exists(".\downloadlog.dat") Then
                            File.Create(".\downloadlog.dat")
                            File.WriteAllText(".\downloadlog.dat", listbox_queue.Items(0).SubItems(0).Text & "," & listbox_queue.Items(0).SubItems(1).Text & "," & listbox_queue.Items(0).SubItems(2).Text & "," & listbox_queue.Items(0).SubItems(3).Text & "," & "removed" & "," & "Cancelled" & "," & listbox_queue.Items(0).SubItems(6).Text)

                        Else
                            Dim log As String = File.ReadAllText(".\downloadlog.dat")
                            File.WriteAllText(".\downloadlog.dat", listbox_queue.Items(0).SubItems(0).Text & "," & listbox_queue.Items(0).SubItems(1).Text & "," & listbox_queue.Items(0).SubItems(2).Text & "," & listbox_queue.Items(0).SubItems(3).Text & "," & "removed" & "," & "Cancelled" & "," & listbox_queue.Items(0).SubItems(6).Text & vbNewLine & log)
                        End If

                        For Each x In listbox_queue.Items
                            If x.subitems(5).text = "Queued" Then
                                Dim log As String = File.ReadAllText(".\downloadlog.dat")
                                File.WriteAllText(".\downloadlog.dat", x.SubItems(0).Text & "," & x.SubItems(1).Text & "," & x.SubItems(2).Text & "," & x.SubItems(3).Text & "," & "removed" & "," & "Cancelled" & "," & x.SubItems(6).Text & vbNewLine & log)
                            End If
                        Next
                        Application.Exit()
                    Else
                        e.Cancel = True
                    End If

                Else
                    Application.Exit()
                End If
            Else
                Application.Exit()
            End If
        Else
            e.Cancel = True
            Me.ShowInTaskbar = False
            Me.WindowState = FormWindowState.Minimized
        End If
    End Sub

    Private Sub picturebox_twitter_Click(sender As Object, e As EventArgs) Handles picturebox_twitter.Click
        Process.Start("https://twitter.com/drgreenboys")
    End Sub

    Private Sub picturebox_patreon_Click(sender As Object, e As EventArgs) Handles picturebox_patreon.Click
        Process.Start("https://www.patreon.com/emuloader")
    End Sub

    Private Sub btn_closeright_Click(sender As Object, e As EventArgs) Handles btn_closeright.Click
        panel_right.Visible = False
        panel_browse.Width += 250
        panel_play.Width += 250
        panel_downloads.Width += 250
        panel_drag_drop.Width += 250
        btn_openright.Visible = True
        btn_openright_downloads.Visible = True
        btn_openright_browse.Visible = True
    End Sub

    Private Sub btn_openright_Click(sender As Object, e As EventArgs) Handles btn_openright.Click
        panel_right.Visible = True
        panel_browse.Width -= 250
        panel_play.Width -= 250
        panel_downloads.Width -= 250
        panel_drag_drop.Width -= 250
        btn_openright_downloads.Visible = False
        btn_openright_browse.Visible = False
        btn_openright.Visible = False
    End Sub

    Private Sub btn_closetop_Click(sender As Object, e As EventArgs) Handles btn_closetop.Click
        picturebox_boxart_top.Visible = False
        panel_top_info.Height = 70
        panel_banner.Height = 180
        panel_play_buttons.Anchor = AnchorStyles.Right And Not AnchorStyles.Top And Not AnchorStyles.Left And Not AnchorStyles.Bottom
        panel_play_buttons.Location = New Point(panel_top_info.Width - 228, 5)
        btn_opentop.Visible = True
        listbox_installedroms.Height += 126
        listbox_installedroms.Location = New Point(40, 184)
        lbl_last_played.Location = New Point(2, 32)
        lbl_rom_top_name.Location = New Point(0, 3)
    End Sub

    Private Sub btn_opentop_Click(sender As Object, e As EventArgs) Handles btn_opentop.Click
        picturebox_boxart_top.Visible = True
        panel_top_info.Height = 196
        panel_banner.Height = 309
        panel_play_buttons.Anchor = AnchorStyles.Left And Not AnchorStyles.Top And Not AnchorStyles.Right And Not AnchorStyles.Bottom
        panel_play_buttons.Location = New Point(208, 144)
        btn_opentop.Visible = False
        listbox_installedroms.Height -= 126
        listbox_installedroms.Location = New Point(40, 310)
        lbl_last_played.Location = New Point(204, 32)
        lbl_rom_top_name.Location = New Point(202, 3)
    End Sub

    Private Sub btn_extras_Click(sender As Object, e As EventArgs) Handles btn_extras.Click

    End Sub

    Private Sub btn_extras_MouseEnter(sender As Object, e As EventArgs) Handles btn_extras.MouseEnter
        btn_extras.BackgroundImage = System.Drawing.Image.FromFile(".\resources\extraswhite.png")
    End Sub

    Private Sub btn_extras_MouseLeave(sender As Object, e As EventArgs) Handles btn_extras.MouseLeave
        btn_extras.BackgroundImage = System.Drawing.Image.FromFile(".\resources\extrasblack.png")
    End Sub

    Private Sub btn_extras_MouseDown(sender As Object, e As MouseEventArgs) Handles btn_extras.MouseDown
        btn_extras.BackgroundImage = System.Drawing.Image.FromFile(".\resources\extrasclick.png")
    End Sub

    Private Sub btn_extras_MouseUp(sender As Object, e As MouseEventArgs) Handles btn_extras.MouseUp
        btn_extras.BackgroundImage = System.Drawing.Image.FromFile(".\resources\extraswhite.png")
    End Sub

    Private Sub btn_opentop_MouseEnter(sender As Object, e As EventArgs) Handles btn_opentop.MouseEnter
        If dark = 1 Or dark = 2 Or dark = 3 Then
            btn_opentop.BackgroundImage = System.Drawing.Image.FromFile(".\resources\opentopclickdark.png")
        Else
            btn_opentop.BackgroundImage = System.Drawing.Image.FromFile(".\resources\opentopclick.png")
        End If

    End Sub

    Private Sub btn_opentop_MouseLeave(sender As Object, e As EventArgs) Handles btn_opentop.MouseLeave
        If dark = 1 Or dark = 2 Or dark = 3 Then
            btn_opentop.BackgroundImage = System.Drawing.Image.FromFile(".\resources\opentopdark.png")
        Else
            btn_opentop.BackgroundImage = System.Drawing.Image.FromFile(".\resources\opentop.png")
        End If
    End Sub

    Private Sub btn_closetop_MouseEnter(sender As Object, e As EventArgs) Handles btn_closetop.MouseEnter
        If dark = 1 Or dark = 2 Or dark = 3 Then
            btn_closetop.BackgroundImage = System.Drawing.Image.FromFile(".\resources\closetopclickdark.png")
        Else
            btn_closetop.BackgroundImage = System.Drawing.Image.FromFile(".\resources\closetopclick.png")
        End If

    End Sub

    Private Sub btn_closetop_MouseLeave(sender As Object, e As EventArgs) Handles btn_closetop.MouseLeave
        If dark = 1 Or dark = 2 Or dark = 3 Then
            btn_closetop.BackgroundImage = System.Drawing.Image.FromFile(".\resources\closetopdark.png")
        Else
            btn_closetop.BackgroundImage = System.Drawing.Image.FromFile(".\resources\closetop.png")
        End If
    End Sub

    Private Sub btn_openright_MouseEnter(sender As Object, e As EventArgs) Handles btn_openright.MouseEnter
        If dark = 1 Or dark = 2 Or dark = 3 Then
            btn_openright.BackgroundImage = System.Drawing.Image.FromFile(".\resources\openrightclickdark.png")
        Else
            btn_openright.BackgroundImage = System.Drawing.Image.FromFile(".\resources\openrightclick.png")
        End If

    End Sub

    Private Sub btn_openright_MouseLeave(sender As Object, e As EventArgs) Handles btn_openright.MouseLeave
        If dark = 1 Or dark = 2 Or dark = 3 Then
            btn_openright.BackgroundImage = System.Drawing.Image.FromFile(".\resources\openrightdark.png")
        Else
            btn_openright.BackgroundImage = System.Drawing.Image.FromFile(".\resources\openright.png")
        End If
    End Sub

    Private Sub btn_closeright_MouseEnter(sender As Object, e As EventArgs) Handles btn_closeright.MouseEnter
        If dark = 1 Or dark = 2 Or dark = 3 Then
            btn_closeright.BackgroundImage = System.Drawing.Image.FromFile(".\resources\closerightclickdark.png")
        Else
            btn_closeright.BackgroundImage = System.Drawing.Image.FromFile(".\resources\closerightclick.png")
        End If

    End Sub

    Private Sub btn_closeright_MouseLeave(sender As Object, e As EventArgs) Handles btn_closeright.MouseLeave
        If dark = 1 Or dark = 2 Or dark = 3 Then
            btn_closeright.BackgroundImage = System.Drawing.Image.FromFile(".\resources\closerightdark.png")
        Else
            btn_closeright.BackgroundImage = System.Drawing.Image.FromFile(".\resources\closeright.png")
        End If
    End Sub

    Private Sub btn_dropbox_Click(sender As Object, e As EventArgs) Handles btn_dropbox.Click
        connectwithdropbox.Show()
    End Sub

    Private Sub btn_purchase_MouseEnter(sender As Object, e As EventArgs) Handles btn_purchase.MouseEnter
        btn_purchase.BackgroundImage = System.Drawing.Image.FromFile(".\resources\purchasewhite.png")
    End Sub

    Private Sub btn_purchase_MouseLeave(sender As Object, e As EventArgs) Handles btn_purchase.MouseLeave
        btn_purchase.BackgroundImage = System.Drawing.Image.FromFile(".\resources\purchaseblack.png")
    End Sub

    Private Sub btn_purchase_MouseDown(sender As Object, e As MouseEventArgs) Handles btn_purchase.MouseDown
        If listbox_availableroms.SelectedItems IsNot Nothing And listbox_availableroms.FocusedItem IsNot Nothing Then
            Dim searchterm As String = listbox_availableroms.FocusedItem.SubItems(0).Text.Replace(" ", "+").Replace(".7z", "").Replace(".zip", "").Replace("(", "").Replace(")", "").Replace("Ru", "").Replace("En", "").Replace("Jp", "").Replace("Europe", "").Replace("Ge", "").Replace("It", "").Replace("Fr", "").Replace("Es", "").Replace("Usa", "").Replace("Nl", "").Replace("Po", "").Replace("Sv", "").Replace("No", "").Replace("Da", "")
            If global_settings(9).Contains("google") Then
                Process.Start("https://www.google.com/search?q=" & searchterm & "+" & listbox_availableroms.FocusedItem.SubItems(2).Text & "&tbm=shop")
            ElseIf global_settings(9).Contains("amazonuk") Then
                Process.Start("https://www.amazon.co.uk/s?k=" & searchterm & "+" & listbox_availableroms.FocusedItem.SubItems(2).Text)
            ElseIf global_settings(9).Contains("amazon") Then
                Process.Start("https://www.amazon.com/s?k=" & searchterm & "+" & listbox_availableroms.FocusedItem.SubItems(2).Text)
            ElseIf global_settings(9).Contains("ebayuk") Then
                Process.Start("https://www.ebay.co.uk/sch/i.html?_nkw=" & searchterm & "+" & listbox_availableroms.FocusedItem.SubItems(2).Text)
            ElseIf global_settings(9).Contains("ebay") Then
                Process.Start("https://www.ebay.com/sch/i.html?_nkw=" & searchterm & "+" & listbox_availableroms.FocusedItem.SubItems(2).Text)
            End If
        End If
    End Sub

    Private Sub btn_soundtrack_MouseEnter(sender As Object, e As EventArgs) Handles btn_soundtrack.MouseEnter
        btn_soundtrack.BackgroundImage = System.Drawing.Image.FromFile(".\resources\ostwhite.png")
    End Sub

    Private Sub btn_soundtrack_MouseLeave(sender As Object, e As EventArgs) Handles btn_soundtrack.MouseLeave
        btn_soundtrack.BackgroundImage = System.Drawing.Image.FromFile(".\resources\ostblack.png")
    End Sub

    Private Sub btn_soundtrack_MouseDown(sender As Object, e As MouseEventArgs) Handles btn_soundtrack.MouseDown
        If listbox_availableroms.SelectedItems IsNot Nothing And listbox_availableroms.FocusedItem IsNot Nothing Then
            Dim searchterm As String = listbox_availableroms.FocusedItem.SubItems(0).Text.Replace(" ", "+").Replace(".7z", "").Replace(".zip", "").Replace("(", "").Replace(")", "").Replace("Ru", "").Replace("En", "").Replace("Jp", "").Replace("Europe", "").Replace("Ge", "").Replace("It", "").Replace("Fr", "").Replace("Es", "").Replace("Usa", "").Replace("Nl", "").Replace("Po", "").Replace("Sv", "").Replace("No", "").Replace("Da", "")


            If global_settings(9).Contains("google") Then
                Process.Start("https://www.google.com/search?q=" & searchterm & "+" & listbox_availableroms.FocusedItem.SubItems(2).Text & "+Official+Soundtrack" & "&tbm=shop")
            ElseIf global_settings(9).Contains("amazonuk") Then
                Process.Start("https://www.amazon.co.uk/s?k=" & searchterm & "+" & listbox_availableroms.FocusedItem.SubItems(2).Text & "+Official+Soundtrack")
            ElseIf global_settings(9).Contains("amazon") Then
                Process.Start("https://www.amazon.com/s?k=" & searchterm & "+" & listbox_availableroms.FocusedItem.SubItems(2).Text & "+Official+Soundtrack")
            ElseIf global_settings(9).Contains("ebayuk") Then
                Process.Start("https://www.ebay.co.uk/sch/i.html?_nkw=" & searchterm & "+" & listbox_availableroms.FocusedItem.SubItems(2).Text & "+Official+Soundtrack")
            ElseIf global_settings(9).Contains("ebay") Then
                Process.Start("https://www.ebay.com/sch/i.html?_nkw=" & searchterm & "+" & listbox_availableroms.FocusedItem.SubItems(2).Text & "+Official+Soundtrack")
            End If
        End If
    End Sub
    Private Sub btn_openright_downloads_MouseEnter(sender As Object, e As EventArgs) Handles btn_openright_downloads.MouseEnter
        If dark = 1 Or dark = 2 Or dark = 3 Then
            btn_openright_downloads.BackgroundImage = System.Drawing.Image.FromFile(".\resources\openrightclickdark.png")
        Else
            btn_openright_downloads.BackgroundImage = System.Drawing.Image.FromFile(".\resources\openrightclick.png")
        End If

    End Sub

    Private Sub btn_openright_downloads_MouseLeave(sender As Object, e As EventArgs) Handles btn_openright_downloads.MouseLeave
        If dark = 1 Or dark = 2 Or dark = 3 Then
            btn_openright_downloads.BackgroundImage = System.Drawing.Image.FromFile(".\resources\openrightdark.png")
        Else
            btn_openright_downloads.BackgroundImage = System.Drawing.Image.FromFile(".\resources\openright.png")
        End If
    End Sub
    Private Sub btn_openright_downloads_Click(sender As Object, e As EventArgs) Handles btn_openright_downloads.Click
        panel_right.Visible = True
        panel_browse.Width -= 250
        panel_play.Width -= 250
        panel_downloads.Width -= 250
        panel_drag_drop.Width -= 250
        btn_openright_downloads.Visible = False
        btn_openright.Visible = False
        btn_openright_browse.Visible = False
    End Sub

    Private Sub btn_openright_browse_MouseEnter(sender As Object, e As EventArgs) Handles btn_openright_browse.MouseEnter
        If dark = 1 Or dark = 2 Or dark = 3 Then
            btn_openright_browse.BackgroundImage = System.Drawing.Image.FromFile(".\resources\openrightclickdark.png")
        Else
            btn_openright_browse.BackgroundImage = System.Drawing.Image.FromFile(".\resources\openrightclick.png")
        End If

    End Sub

    Private Sub btn_openright_browse_MouseLeave(sender As Object, e As EventArgs) Handles btn_openright_browse.MouseLeave
        If dark = 1 Or dark = 2 Or dark = 3 Then
            btn_openright_browse.BackgroundImage = System.Drawing.Image.FromFile(".\resources\openrightdark.png")
        Else
            btn_openright_browse.BackgroundImage = System.Drawing.Image.FromFile(".\resources\openright.png")
        End If
    End Sub
    Private Sub btn_openright_browse_Click(sender As Object, e As EventArgs) Handles btn_openright_browse.Click
        panel_right.Visible = True
        panel_browse.Width -= 250
        panel_play.Width -= 250
        panel_downloads.Width -= 250
        panel_drag_drop.Width -= 250
        btn_openright_browse.Visible = False
        btn_openright.Visible = False
        btn_openright_browse.Visible = False
    End Sub

    Private Sub thread_emulator_update_DoWork(sender As Object, e As DoWorkEventArgs) Handles thread_emulator_update.DoWork
        If Not global_settings(12).Split("=")(1) = "1" Then
            Dim arguments As String() = (e.Argument)
            Using vba_m = New WebClient()
                Try
                    vba_m.DownloadFile(arguments(0), ".\" & main.currenttab_metadata(4) & "\update.zip")
                    vba_m.Dispose()
                Catch ex As Exception
                    vba_m.Dispose()
                    MessageBox.Show("Can't find Download, exiting.")
                End Try
            End Using

            If File.Exists(".\" & main.currenttab_metadata(4) & "\update.zip") Then
                Dim zipfilepath As String = ".\" & main.currenttab_metadata(4) & "\update.zip"
                Dim extractto As String = ".\" & main.currenttab_metadata(4)
                Using zipfile3 = ZipFile.OpenRead(zipfilepath)
                    For Each entry As ZipArchiveEntry In zipfile3.Entries


                        entry.ExtractToFile(Path.Combine(extractto, entry.FullName), True)

                    Next
                End Using
            End If
        End If
    End Sub

    Private Sub thread_emulator_update_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles thread_emulator_update.RunWorkerCompleted

        Call launch_emulator()

    End Sub

    Public Sub launch_emulator()
        btn_play.Image = System.Drawing.Image.FromFile(".\resources\playblack.gif")
        GC.Collect()
        Dim timestamp As String = Date.Now.ToString("dd/MM/yyyy")
        Dim existing As String() = File.ReadAllLines(".\roms\" & currenttab_metadata(1) & "\metadata\lastplayed.dat")
        Dim existing2 As String = File.ReadAllText(".\roms\" & currenttab_metadata(1) & "\metadata\lastplayed.dat")
        Dim canary As Boolean = False
        For Each x In existing
            Dim y As String() = x.Split(",")
            If y(0) = listbox_installedroms.FocusedItem.SubItems(0).Text Then
                File.WriteAllText(".\roms\" & currenttab_metadata(1) & "\metadata\lastplayed.dat", (existing2.Replace(x, listbox_installedroms.FocusedItem.SubItems(0).Text & "," & timestamp)))
                canary = True
                Exit For
            End If
        Next
        If canary = False Then
            File.WriteAllText(".\roms\" & currenttab_metadata(1) & "\metadata\lastplayed.dat", (existing2 & vbNewLine & listbox_installedroms.FocusedItem.SubItems(0).Text & "," & timestamp))

        End If

        Dim emulator As Process
        Dim p As New ProcessStartInfo

        Dim params As String = File.ReadAllText(".\" & currenttab_metadata(4) & "\cmdlineargs.ini")
        p.FileName = (".\" & currenttab_metadata(4) & "\" & currenttab_metadata(3))

        If currenttab_metadata(1) = "GBA" Then

            Dim rom_path As String = System.IO.Path.GetFullPath(listbox_installedroms.FocusedItem.SubItems(2).Text)
            p.Arguments = ("""" & rom_path & """ " & params)
        ElseIf currenttab_metadata(1) = "3DS" Then


            Dim rom_path As String = System.IO.Path.GetFullPath(listbox_installedroms.FocusedItem.SubItems(2).Text)
            p.Arguments = ("""" & rom_path & """ " & params)
        ElseIf currenttab_metadata(1) = "NDS" Then


            Dim rom_path As String = System.IO.Path.GetFullPath(listbox_installedroms.FocusedItem.SubItems(2).Text)
            p.Arguments = ("""" & rom_path & """ " & params)
        ElseIf currenttab_metadata(1) = "N64" Then


            Dim rom_path As String = System.IO.Path.GetFullPath(listbox_installedroms.FocusedItem.SubItems(2).Text)
            p.Arguments = ("""" & rom_path & """ " & params)
        ElseIf currenttab_metadata(1) = "PSP" Then


            Dim rom_path As String = System.IO.Path.GetFullPath(listbox_installedroms.FocusedItem.SubItems(2).Text)
            p.Arguments = ("""" & rom_path & """ " & params)
        ElseIf currenttab_metadata(1) = "WII" Then


            Dim rom_path As String = System.IO.Path.GetFullPath(listbox_installedroms.FocusedItem.SubItems(2).Text)
            p.Arguments = ("""" & rom_path & """ " & params)
        ElseIf currenttab_metadata(1) = "WIIU" Then


            Dim rom_path As String = System.IO.Path.GetFullPath(listbox_installedroms.FocusedItem.SubItems(2).Text)
            p.Arguments = ("-g" & """" & rom_path & """ " & params)
        ElseIf currenttab_metadata(1) = "SNES" Then


            Dim rom_path As String = System.IO.Path.GetFullPath(listbox_installedroms.FocusedItem.SubItems(2).Text)
            p.Arguments = ("""" & rom_path & """ " & params)
        ElseIf currenttab_metadata(1) = "NES" Then


            Dim rom_path As String = System.IO.Path.GetFullPath(listbox_installedroms.FocusedItem.SubItems(2).Text)
            p.Arguments = ("Mesen " & """" & rom_path & """ " & params)
        ElseIf currenttab_metadata(1) = "NES" Then


            Dim rom_path As String = System.IO.Path.GetFullPath(listbox_installedroms.FocusedItem.SubItems(2).Text)
            p.Arguments = ("-loadbin " & """" & rom_path & """ " & params)
        ElseIf currenttab_metadata(1) = "MGD" Then


            Dim rom_path As String = System.IO.Path.GetFullPath(listbox_installedroms.FocusedItem.SubItems(2).Text)
            p.Arguments = ("""" & rom_path & """ " & params)
        ElseIf currenttab_metadata(1) = "DC" Then


            Dim rom_path As String = System.IO.Path.GetFullPath(listbox_installedroms.FocusedItem.SubItems(2).Text)
            p.Arguments = ("""" & rom_path & """ " & params)
        ElseIf currenttab_metadata(1) = "PS2" Then


            Dim rom_path As String = System.IO.Path.GetFullPath(listbox_installedroms.FocusedItem.SubItems(2).Text)
            p.Arguments = ("""" & rom_path & """ " & params)
        End If




        If checkbox_fullscreen.Checked = True Then
            p.WindowStyle = ProcessWindowStyle.Maximized

        Else
            p.WindowStyle = ProcessWindowStyle.Normal

        End If

        emulator = Process.Start(p)

        If File.Exists(".\lastplayed.dat") = True Then
            File.Delete(".\lastplayed.dat")
        End If
        File.Create(".\lastplayed.dat").Dispose()
        File.WriteAllText(".\lastplayed.dat", currenttab_metadata(0) & vbNewLine & listbox_installedroms.FocusedItem.SubItems(0).Text & vbNewLine & timestamp & vbNewLine & boxart_url)
    End Sub

    Private Sub image_logo_Click(sender As Object, e As EventArgs) Handles image_logo.Click
        panel_home.BringToFront()
    End Sub

    Private Sub btn_play_jumpin_Click(sender As Object, e As EventArgs) Handles btn_play_jumpin.Click

    End Sub

    Private Sub btn_play_jumpin_MouseDown(sender As Object, e As MouseEventArgs) Handles btn_play_jumpin.MouseDown
        btn_play_jumpin.Image = System.Drawing.Image.FromFile(".\resources\playclick.png")
        Call jumpin_play()
    End Sub

    Private Sub btn_play_jumpin_MouseEnter(sender As Object, e As EventArgs) Handles btn_play_jumpin.MouseEnter
        btn_play_jumpin.Image = System.Drawing.Image.FromFile(".\resources\playwhite.png")
    End Sub

    Private Sub btn_play_jumpin_MouseLeave(sender As Object, e As EventArgs) Handles btn_play_jumpin.MouseLeave
        btn_play_jumpin.Image = System.Drawing.Image.FromFile(".\resources\playblack.gif")
        GC.Collect()
    End Sub

    Public Sub jumpin_play()
        panel_banner.Visible = False
        Dim index As Integer = 0
        For Each x In emu_tab_metadata_list.emutabs_metadata
            If (x(0)) = lbl_jumpin_emuname.Text Then
                Select Case index
                    Case 0
                        emu_one_Click(Nothing, Nothing)
                    Case 1
                        emu_two_Click(Nothing, Nothing)
                    Case 2
                        emu_three_Click(Nothing, Nothing)
                    Case 3
                        emu_four_Click(Nothing, Nothing)
                    Case 4
                        emu_five_Click(Nothing, Nothing)
                    Case 5
                        emu_six_Click(Nothing, Nothing)
                    Case 6
                        emu_seven_Click(Nothing, Nothing)
                    Case 7
                        emu_eight_Click(Nothing, Nothing)
                    Case 8
                        emu_nine_Click(Nothing, Nothing)
                End Select
                Exit For
            End If
            index += 1
        Next

        For Each y In listbox_installedroms.Items
            If y.subitems(0).text = lbl_jumpin_romname.Text Then
                y.Focused = True
                y.Selected = True
                y.EnsureVisible()
                btn_play_MouseDown(Nothing, Nothing)
                panel_banner.Visible = True
            End If
        Next
    End Sub
    ' Private Sub Main_Maximise(ByVal sender As Object, ByVal e As EventArgs) Handles Me.w
    '     lbl_nothing.Location = New Point((panel_downloads.Width - lbl_nothing.Width) \ 2, (panel_downloads.Height - lbl_nothing.Height) \ 2)
    '     lbl_status.Location = New Point((panel_top.Width - lbl_status.Width) \ 2, (panel_top.Height - lbl_status.Height) \ 2)
    ' End Sub
End Class
