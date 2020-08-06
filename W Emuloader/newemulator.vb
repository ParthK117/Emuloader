Imports System.Net
Imports System.IO
Imports System.IO.Compression
Imports System.ComponentModel

Public Class newemulator
    Dim arguments As String()
    Dim list_of_emulators As String() = {"Visual Boy Advance-M (GBA)", "Citra (3DS)", "DeSmuME (NDS)", "Project64 (N64)", "PPSSPP (PSP)", "Dolphin (WII)", "Cemu (WIIU)", "Snes9x (SNES)", "Mesen (NES)", "ePSXe (PSX)", "Fusion (MGD)", "Redream (DC)", "PCSX2 (PS2)", "yuzu (SWH)"}
    Dim uptodate_list As String()
    Dim vnumber As String

    Private Sub newemulator_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
        listbox_emulators.Items.AddRange(list_of_emulators)

        Dim spartanfont10 As New System.Drawing.Font(main.spartan.Families(0), 10)
        listbox_emulators.Font = spartanfont10
        textbox_search.Font = spartanfont10

        Dim spartanfont12 As New System.Drawing.Font(main.spartan.Families(0), 12)
        lbl_emulator_name.Font = spartanfont12
        lbl_source.Font = spartanfont12
        lbl_version_number.Font = spartanfont12
        lbl_platform.Font = spartanfont12

        Using currentlinks = New WebClient()
            Try
                currentlinks.DownloadFile("https://tungstencore.com/cdn/emulatorlinks.txt", ".\modules\emulatorlinks.txt")
                currentlinks.Dispose()
                uptodate_list = File.ReadAllLines(".\modules\emulatorlinks.txt")
            Catch ex As Exception
            End Try
        End Using
        listbox_emulators.SelectedItem = listbox_emulators.Items(0)

        Select Case main.dark
            Case 1
                BackColor = Color.FromArgb(21, 32, 43)
                listbox_emulators.BackColor = Color.FromArgb(31, 45, 58)
                textbox_search.BackColor = Color.FromArgb(31, 45, 58)
                listbox_emulators.ForeColor = Color.White
                textbox_search.ForeColor = Color.White
                lbl_emulator_name.ForeColor = Color.White
                lbl_platform.ForeColor = Color.White
                lbl_source.ForeColor = Color.White
                lbl_version_number.ForeColor = Color.White
            Case 2
                BackColor = Color.FromArgb(25, 28, 40)
                listbox_emulators.BackColor = Color.FromArgb(32, 37, 52)
                textbox_search.BackColor = Color.FromArgb(32, 37, 52)
                listbox_emulators.ForeColor = Color.White
                textbox_search.ForeColor = Color.White
                lbl_emulator_name.ForeColor = Color.White
                lbl_platform.ForeColor = Color.White
                lbl_source.ForeColor = Color.White
                lbl_version_number.ForeColor = Color.White
            Case 3
                BackColor = Color.FromArgb(12, 12, 12)
                listbox_emulators.BackColor = Color.FromArgb(40, 40, 40)
                textbox_search.BackColor = Color.FromArgb(40, 40, 40)
                listbox_emulators.ForeColor = Color.White
                textbox_search.ForeColor = Color.White
                lbl_emulator_name.ForeColor = Color.White
                lbl_platform.ForeColor = Color.White
                lbl_source.ForeColor = Color.White
                lbl_version_number.ForeColor = Color.White
        End Select
    End Sub

    Private Sub center_status_lbl()
        main.lbl_status.Location = New Point((main.panel_top.Width - main.lbl_status.Width) \ 2, (main.panel_top.Height - main.lbl_status.Height) \ 2)
    End Sub

    Private Sub emulator_downloader_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles emulator_downloader.DoWork
        Dim arguments As String() = (e.Argument)
        Dim timestamp As String = Date.Now.ToString("HH-mm-ss-dd-MM-yyyy")
        Directory.CreateDirectory(".\" & arguments(0) & "-" & timestamp)

        Using emulator_downloadclient = New WebClient()
            Call center_status_lbl()
            Try
                emulator_downloadclient.DownloadFile(arguments(1), ".\" & arguments(0) & "-" & timestamp & "\" & arguments(2))
                emulator_downloadclient.Dispose()
            Catch ex As Exception
                emulator_downloadclient.Dispose()
                MessageBox.Show("Can't find Download, exiting.")
            End Try
        End Using

        If File.Exists(".\" & arguments(0) & "-" & timestamp & "\" & arguments(2)) Then
            Dim zipfilepath As String = ".\" & arguments(0) & "-" & timestamp & "\" & arguments(2)
            Dim extractto As String = ".\" & arguments(0) & "-" & timestamp & arguments(7)
            ZipFile.ExtractToDirectory(zipfilepath, extractto)
        End If

        'save to settings
        If System.IO.File.Exists(".\installed.eldr") = False Then
            System.IO.File.Create(".\installed.eldr").Dispose()
            Dim installed_emus As String
            installed_emus = ".\" & arguments(0) & "-" & timestamp
            My.Computer.FileSystem.WriteAllText(".\installed.eldr", installed_emus, True)
        Else
            Dim installed_emus As String = File.ReadAllText(".\installed.eldr")
            installed_emus = installed_emus & vbNewLine & ".\" & arguments(0) & "-" & timestamp
            My.Computer.FileSystem.WriteAllText(".\installed.eldr", installed_emus, False)
        End If

        Dim datestamp As String = Date.Now.ToString("dd/MM/yyyy")
        Dim metadata As String = arguments(5) & vbNewLine & arguments(3) & vbNewLine & datestamp & vbNewLine & arguments(4) & vbNewLine & arguments(0) & "-" & timestamp & vbNewLine & arguments(8)
        System.IO.File.Create(".\" & arguments(0) & "-" & timestamp & "\" & arguments(6)).Dispose()
        My.Computer.FileSystem.WriteAllText(".\" & arguments(0) & "-" & timestamp & "\" & arguments(6), metadata, True)
        System.IO.File.Create(".\" & arguments(0) & "-" & timestamp & "\cmdlineargs.ini").Dispose()
        Directory.CreateDirectory(".\roms\" & arguments(3))
    End Sub

    Private Sub emulator_downloader_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles emulator_downloader.RunWorkerCompleted
        main.lbl_status.Text = "Installed " & arguments(5)
        main.picturebox_loading.Visible = False
        Call center_status_lbl()
        Call loadconfig()
    End Sub

    Private Sub textbox_search_TextChanged(sender As Object, e As EventArgs) Handles textbox_search.TextChanged
        'To search for emulators
        listbox_emulators.Items.Clear()
        For Each emulator In list_of_emulators
            If emulator.IndexOf(textbox_search.Text, 0, StringComparison.CurrentCultureIgnoreCase) > -1 Then
                listbox_emulators.Items.Add(emulator)
            End If
        Next
        If textbox_search.Text = "" Then
            listbox_emulators.Items.Clear()
            listbox_emulators.Items.AddRange(list_of_emulators)
        End If
    End Sub

    Private Sub textbox_search_Click(sender As Object, e As EventArgs) Handles textbox_search.Click
        If textbox_search.Text = "Search" Then
            textbox_search.Text = ""
        End If
    End Sub

    Private Sub listbox_emulators_SelectedIndexChanged(sender As Object, e As EventArgs) Handles listbox_emulators.SelectedIndexChanged
        If listbox_emulators.SelectedItem IsNot Nothing Then
            Select Case listbox_emulators.SelectedItem.ToString
                Case "Visual Boy Advance-M (GBA)"
                    Dim vbam As String() = uptodate_list(0).Split(",")
                    lbl_emulator_name.Text = "Visual Boy Advance-M"
                    lbl_platform.Text = "Platform: Game Boy Advance (+GBC, GB)"
                    lbl_source.Text = "Source: GitHub"
                    lbl_version_number.Text = vbam(4)
                    vnumber = vbam(4)
                    picturebox_emulogo.BackgroundImage = System.Drawing.Image.FromFile(".\resources\vbam.png")
                Case "Citra (3DS)"
                    Dim citra As String() = uptodate_list(1).Split(",")
                    lbl_emulator_name.Text = "Citra"
                    lbl_platform.Text = "Platform: Nintendo 3DS"
                    lbl_source.Text = "Source: GitHub (Repackaged for Emuloader)"
                    lbl_version_number.Text = citra(4)
                    vnumber = citra(4)
                    picturebox_emulogo.BackgroundImage = New System.Drawing.Bitmap(".\resources\citra.png")
                Case "DeSmuME (NDS)"
                    Dim desmume As String() = uptodate_list(2).Split(",")
                    lbl_emulator_name.Text = "DeSmuME"
                    lbl_platform.Text = "Platform: Nintendo DS"
                    lbl_source.Text = "Source: Google Drive (Emuloader Repack)"
                    lbl_version_number.Text = desmume(4)
                    vnumber = desmume(4)
                    picturebox_emulogo.BackgroundImage = New System.Drawing.Bitmap(".\resources\desmume.png")
                Case "Project64 (N64)"
                    Dim project64 As String() = uptodate_list(3).Split(",")
                    lbl_emulator_name.Text = "Project64"
                    lbl_platform.Text = "Platform: Nintendo 64"
                    lbl_source.Text = "Source: Google Drive (Emuloader Repack)"
                    lbl_version_number.Text = project64(4)
                    vnumber = project64(4)
                    picturebox_emulogo.BackgroundImage = New System.Drawing.Bitmap(".\resources\project64.png")
                Case "PPSSPP (PSP)"
                    Dim ppsspp As String() = uptodate_list(4).Split(",")
                    lbl_emulator_name.Text = "PPSSPP"
                    lbl_platform.Text = "Platform: Sony PSP"
                    lbl_source.Text = "Source: PPSSPP.org"
                    lbl_version_number.Text = ppsspp(4)
                    vnumber = ppsspp(4)
                    picturebox_emulogo.BackgroundImage = New System.Drawing.Bitmap(".\resources\ppsspp.png")
                Case "Dolphin (WII)"
                    Dim dolphin As String() = uptodate_list(5).Split(",")
                    lbl_emulator_name.Text = "Dolphin"
                    lbl_platform.Text = "Platform: Nintendo Wii (+Gamecube)"
                    lbl_source.Text = "Source: Google Drive (Emuloader Repack)"
                    lbl_version_number.Text = dolphin(4)
                    vnumber = dolphin(4)
                    picturebox_emulogo.BackgroundImage = New System.Drawing.Bitmap(".\resources\dolphin.png")
                Case "Cemu (WIIU)"
                    Dim cemu As String() = uptodate_list(6).Split(",")
                    lbl_emulator_name.Text = "Cemu"
                    lbl_platform.Text = "Platform: Nintendo Wii U"
                    lbl_source.Text = "Source: cemu.info"
                    lbl_version_number.Text = cemu(4)
                    vnumber = cemu(4)
                    picturebox_emulogo.BackgroundImage = New System.Drawing.Bitmap(".\resources\cemu.png")
                Case "Snes9x (SNES)"
                    Dim snes9x As String() = uptodate_list(7).Split(",")
                    lbl_emulator_name.Text = "Snes9x"
                    lbl_platform.Text = "Platform: Nintendo SNES"
                    lbl_source.Text = "Source: s9x-w32.de"
                    lbl_version_number.Text = snes9x(4)
                    vnumber = snes9x(4)
                    picturebox_emulogo.BackgroundImage = New System.Drawing.Bitmap(".\resources\snes9x.png")
                Case "Mesen (NES)"
                    Dim mesen As String() = uptodate_list(8).Split(",")
                    lbl_emulator_name.Text = "Mesen"
                    lbl_platform.Text = "Platform: Nintendo NES"
                    lbl_source.Text = "Source: Github"
                    lbl_version_number.Text = mesen(4)
                    vnumber = mesen(4)
                    picturebox_emulogo.BackgroundImage = New System.Drawing.Bitmap(".\resources\mesen.png")
                Case "ePSXe (PSX)"
                    Dim epsxe As String() = uptodate_list(9).Split(",")
                    lbl_emulator_name.Text = "ePSXe"
                    lbl_platform.Text = "Platform: Sony Playstation"
                    lbl_source.Text = "Source: epsxe.com"
                    lbl_version_number.Text = epsxe(4)
                    vnumber = epsxe(4)
                    picturebox_emulogo.BackgroundImage = New System.Drawing.Bitmap(".\resources\epsxe.jpg")
                Case "Fusion (MGD)"
                    Dim emulator_meta As String() = uptodate_list(10).Split(",")
                    lbl_emulator_name.Text = "Fusion"
                    lbl_platform.Text = "Platform: Sega Megadrive/Genesis"
                    lbl_source.Text = "Source: Github (Emuloader Repack)"
                    lbl_version_number.Text = emulator_meta(4)
                    vnumber = emulator_meta(4)
                    picturebox_emulogo.BackgroundImage = New System.Drawing.Bitmap(".\resources\fusion.png")
                Case "Redream (DC)"
                    Dim emulator_meta As String() = uptodate_list(11).Split(",")
                    lbl_emulator_name.Text = "Redream"
                    lbl_platform.Text = "Platform: Sega Dreamcast"
                    lbl_source.Text = "Source: redream.io"
                    lbl_version_number.Text = emulator_meta(4)
                    vnumber = emulator_meta(4)
                    picturebox_emulogo.BackgroundImage = New System.Drawing.Bitmap(".\resources\redream.png")
                Case "PCSX2 (PS2)"
                    Dim emulator_meta As String() = uptodate_list(12).Split(",")
                    lbl_emulator_name.Text = "PCSX2"
                    lbl_platform.Text = "Platform: Playstation 2"
                    lbl_source.Text = "Source: Google Drive (Emuloader Repack)"
                    lbl_version_number.Text = emulator_meta(4)
                    vnumber = emulator_meta(4)
                    picturebox_emulogo.BackgroundImage = New System.Drawing.Bitmap(".\resources\pcsx2.png")
                Case "yuzu (SWH)"
                    Dim emulator_meta As String() = uptodate_list(13).Split(",")
                    lbl_emulator_name.Text = "yuzu"
                    lbl_platform.Text = "Platform: Switch"
                    lbl_source.Text = "Source: Github (Emuloader Repack)"
                    lbl_version_number.Text = emulator_meta(4)
                    vnumber = emulator_meta(4)
                    picturebox_emulogo.BackgroundImage = New System.Drawing.Bitmap(".\resources\yuzu.png")

            End Select
        End If
    End Sub

    Private Sub btn_install_MouseEnter(sender As Object, e As EventArgs) Handles btn_install.MouseEnter
        btn_install.BackgroundImage = New System.Drawing.Bitmap(".\resources\installwhite.png")
    End Sub

    Private Sub btn_install_MouseLeave(sender As Object, e As EventArgs) Handles btn_install.MouseLeave
        btn_install.BackgroundImage = New System.Drawing.Bitmap(".\resources\installblack.png")
    End Sub

    Private Sub btn_install_MouseDown(sender As Object, e As MouseEventArgs) Handles btn_install.MouseDown
        btn_install.BackgroundImage = New System.Drawing.Bitmap(".\resources\installclick.png")
        Select Case listbox_emulators.SelectedItem
            Case "Visual Boy Advance-M (GBA)"
                Dim vbam As String() = uptodate_list(0).Split(",")
                arguments = {"VBAM", vbam(0), vbam(1), "GBA", vbam(2), "Visual Boy Advance-M", "vbam.eldr", vbam(3), vnumber}
                emulator_downloader.RunWorkerAsync(arguments)
                main.lbl_status.Text = "Installing Visual Boy Advance-M"
                Call center_status_lbl()
            Case "Citra (3DS)"
                Dim citra As String() = uptodate_list(1).Split(",")
                arguments = {"CITRA", citra(0), citra(1), "3DS", citra(2), "Citra", "citra.eldr", citra(3), vnumber}
                emulator_downloader.RunWorkerAsync(arguments)
                main.lbl_status.Text = "Installing Citra"
                Call center_status_lbl()
            Case "DeSmuME (NDS)"
                Dim desmume As String() = uptodate_list(2).Split(",")
                arguments = {"DESMUME", desmume(0), desmume(1), "NDS", desmume(2), "DeSmuME", "desmume.eldr", desmume(3), vnumber}
                emulator_downloader.RunWorkerAsync(arguments)
                main.lbl_status.Text = "Installing DeSmuME"
                Call center_status_lbl()
            Case "Project64 (N64)"
                Dim project64 As String() = uptodate_list(3).Split(",")
                arguments = {"PROJECT64", project64(0), project64(1), "N64", project64(2), "Project64", "project64.eldr", project64(3), vnumber}
                emulator_downloader.RunWorkerAsync(arguments)
                main.lbl_status.Text = "Installing Project64"
                Call center_status_lbl()
            Case "PPSSPP (PSP)"
                Dim ppsspp As String() = uptodate_list(4).Split(",")
                arguments = {"PPSSPP", ppsspp(0), ppsspp(1), "PSP", ppsspp(2), "PPSSPP", "ppsspp.eldr", ppsspp(3), vnumber}
                emulator_downloader.RunWorkerAsync(arguments)
                main.lbl_status.Text = "Installing PPSSPP"
                Call center_status_lbl()
            Case "Dolphin (WII)"
                Dim dolphin As String() = uptodate_list(5).Split(",")
                arguments = {"DOLPHIN", dolphin(0), dolphin(1), "WII", dolphin(2), "Dolphin", "dolphin.eldr", dolphin(3), vnumber}
                emulator_downloader.RunWorkerAsync(arguments)
                main.lbl_status.Text = "Installing Dolphin"
                Call center_status_lbl()
            Case "Cemu (WIIU)"
                Dim cemu As String() = uptodate_list(6).Split(",")
                arguments = {"CEMU", cemu(0), cemu(1), "WIIU", cemu(2), "Cemu", "cemu.eldr", cemu(3), vnumber}
                emulator_downloader.RunWorkerAsync(arguments)
                main.lbl_status.Text = "Installing Cemu"
                Call center_status_lbl()
            Case "Snes9x (SNES)"
                Dim snes9x As String() = uptodate_list(7).Split(",")
                arguments = {"SNES9X", snes9x(0), snes9x(1), "SNES", snes9x(2), "Snes9x", "snes9x.eldr", snes9x(3), vnumber}
                emulator_downloader.RunWorkerAsync(arguments)
                main.lbl_status.Text = "Installing Snes9x (SNES)"
                Call center_status_lbl()
            Case "Mesen (NES)"
                Dim mesen As String() = uptodate_list(8).Split(",")
                arguments = {"MESEN", mesen(0), mesen(1), "NES", mesen(2), "Mesen", "mesen.eldr", mesen(3), vnumber}
                emulator_downloader.RunWorkerAsync(arguments)
                main.lbl_status.Text = "Installing Mesen (NES)"
                Call center_status_lbl()
            Case "ePSXe (PSX)"
                Dim epsxe As String() = uptodate_list(9).Split(",")
                arguments = {"EPSXE", epsxe(0), epsxe(1), "PSX", epsxe(2), "ePSXe", "epsxe.eldr", epsxe(3), vnumber}
                emulator_downloader.RunWorkerAsync(arguments)
                main.lbl_status.Text = "Installing ePSXe (PSX)"
                Call center_status_lbl()
                MessageBox.Show("ePSXe currently has a bug and will crash unless you set CPU Overclocking to x1, so ensure you do this.")
            Case "Fusion (MGD)"
                Dim emulator_meta As String() = uptodate_list(10).Split(",")
                arguments = {"FUSION", emulator_meta(0), emulator_meta(1), "MGD", emulator_meta(2), "Fusion", "fusion.eldr", emulator_meta(3), vnumber}
                emulator_downloader.RunWorkerAsync(arguments)
                main.lbl_status.Text = "Installing Fusion (MGD)"
                Call center_status_lbl()
            Case "Redream (DC)"
                Dim emulator_meta As String() = uptodate_list(11).Split(",")
                arguments = {"REDREAM", emulator_meta(0), emulator_meta(1), "DC", emulator_meta(2), "Redream", "redream.eldr", emulator_meta(3), vnumber}
                emulator_downloader.RunWorkerAsync(arguments)
                main.lbl_status.Text = "Installing Redream (DC)"
                Call center_status_lbl()
            Case "PCSX2 (PS2)"
                Dim emulator_meta As String() = uptodate_list(12).Split(",")
                arguments = {"PCSX2", emulator_meta(0), emulator_meta(1), "PS2", emulator_meta(2), "PCSX2", "pcsx2.eldr", emulator_meta(3), vnumber}
                emulator_downloader.RunWorkerAsync(arguments)
                main.lbl_status.Text = "Installing PCSX2 (PS2)"
                Call center_status_lbl()
                MessageBox.Show("PCSX2 requires a PS2 Bios to function.")
            Case "yuzu (SWH)"
                Dim emulator_meta As String() = uptodate_list(13).Split(",")
                arguments = {"YUZU", emulator_meta(0), emulator_meta(1), "SWH", emulator_meta(2), "yuzu", "yuzu.eldr", emulator_meta(3), vnumber}
                emulator_downloader.RunWorkerAsync(arguments)
                main.lbl_status.Text = "Installing yuzu (SWH)"
                Call center_status_lbl()
        End Select
        main.picturebox_loading.Visible = True
        MessageBox.Show(arguments(5) & " will be installed")
        Me.Close()
    End Sub
End Class