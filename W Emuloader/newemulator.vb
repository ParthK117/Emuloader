Imports System.Net
Imports System.IO
Imports System.IO.Compression
Imports System.ComponentModel

Public Class newemulator
    Dim arguments As String()
    Dim list_of_emulators As String() = {"Visual Boy Advance-M (GBA)", "Citra (3DS)", "DeSmuME (NDS)", "Project64 (N64)", "PPSSPP (PSP)", "Dolphin (WII)"}


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

        listbox_emulators.SelectedItem = listbox_emulators.Items(0)
    End Sub
    Private Sub center_status_lbl()
        main.lbl_status.Location = New Point((main.panel_top.Width - main.lbl_status.Width) \ 2, (main.panel_top.Height - main.lbl_status.Height) \ 2)
    End Sub

    Private Sub emulator_downloader_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles emulator_downloader.DoWork
        Dim arguments As String() = (e.Argument)
        Dim timestamp As String = Date.Now.ToString("HH-mm-ss-dd-MM-yyyy")


        My.Computer.FileSystem.CreateDirectory(".\" & arguments(0) & "-" & timestamp)



        Using vba_m = New WebClient()
            Call center_status_lbl()
            Try
                vba_m.DownloadFile(arguments(1), ".\" & arguments(0) & "-" & timestamp & "\" & arguments(2))
                vba_m.Dispose()
            Catch ex As Exception
                vba_m.Dispose()
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
        Dim metadata As String = arguments(5) & vbNewLine & arguments(3) & vbNewLine & datestamp & vbNewLine & arguments(4) & vbNewLine & arguments(0) & "-" & timestamp
        System.IO.File.Create(".\" & arguments(0) & "-" & timestamp & "\" & arguments(6)).Dispose()
        My.Computer.FileSystem.WriteAllText(".\" & arguments(0) & "-" & timestamp & "\" & arguments(6), metadata, True)




        If Directory.Exists(".\roms\" & arguments(3)) = False Then
            My.Computer.FileSystem.CreateDirectory(".\roms\" & arguments(3))
        End If

    End Sub

    Private Sub emulator_downloader_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles emulator_downloader.RunWorkerCompleted
        main.lbl_status.Text = "Installed " & arguments(5)
        main.picturebox_loading.Visible = False
        Call center_status_lbl()
        Call main.loadconfig()
    End Sub

    Private Sub textbox_search_TextChanged(sender As Object, e As EventArgs) Handles textbox_search.TextChanged
        listbox_emulators.Items.Clear()
        For Each x In list_of_emulators
            If x.IndexOf(textbox_search.Text, 0, StringComparison.CurrentCultureIgnoreCase) > -1 Then
                listbox_emulators.Items.Add(x)
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
            If listbox_emulators.SelectedItem.ToString = "Visual Boy Advance-M (GBA)" Then
                lbl_emulator_name.Text = "Visual Boy Advance-M"
                lbl_platform.Text = "Platform: Game Boy Advance (+GBC, GB)"
                lbl_source.Text = "Source: GitHub"
                lbl_version_number.Text = "Version 2.1.4"
                picturebox_emulogo.BackgroundImage = System.Drawing.Image.FromFile(".\resources\vbam.png")
            End If
            If listbox_emulators.SelectedItem.ToString = "Citra (3DS)" Then
                lbl_emulator_name.Text = "Citra"
                lbl_platform.Text = "Platform: Nintendo 3DS"
                lbl_source.Text = "Source: GitHub (Repackaged for Emuloader)"
                lbl_version_number.Text = "Version Nightly 1547"
                picturebox_emulogo.BackgroundImage = New System.Drawing.Bitmap(".\resources\citra.png")
            End If
            If listbox_emulators.SelectedItem.ToString = "DeSmuME (NDS)" Then
                lbl_emulator_name.Text = "DeSmuME"
                lbl_platform.Text = "Platform: Nintendo DS"
                lbl_source.Text = "Source: Google Drive (Emuloader Repack)"
                lbl_version_number.Text = "Version 0.9.11"
                picturebox_emulogo.BackgroundImage = New System.Drawing.Bitmap(".\resources\desmume.png")
            End If
            If listbox_emulators.SelectedItem.ToString = "Project64 (N64)" Then
                lbl_emulator_name.Text = "Project64"
                lbl_platform.Text = "Platform: Nintendo 64"
                lbl_source.Text = "Source: Google Drive (Emuloader Repack)"
                lbl_version_number.Text = "Version 2.3.2"
                picturebox_emulogo.BackgroundImage = New System.Drawing.Bitmap(".\resources\project64.png")
            End If
            If listbox_emulators.SelectedItem.ToString = "PPSSPP (PSP)" Then
                lbl_emulator_name.Text = "PPSSPP"
                lbl_platform.Text = "Platform: Sony PSP"
                lbl_source.Text = "Source: PPSSPP.org"
                lbl_version_number.Text = "Version 1.9.3"
                picturebox_emulogo.BackgroundImage = New System.Drawing.Bitmap(".\resources\ppsspp.png")
            End If
            If listbox_emulators.SelectedItem.ToString = "Dolphin (WII)" Then
                lbl_emulator_name.Text = "Dolphin"
                lbl_platform.Text = "Platform: Nintendo Wii (+Gamecube)"
                lbl_source.Text = "Source: Google Drive (Emuloader Repack)"
                lbl_version_number.Text = "Version 5.0-11991"
                picturebox_emulogo.BackgroundImage = New System.Drawing.Bitmap(".\resources\dolphin.png")
            End If
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

        If listbox_emulators.SelectedItem = "Visual Boy Advance-M (GBA)" Then
            arguments = {"VBAM", "https://github.com/visualboyadvance-m/visualboyadvance-m/releases/download/v2.1.4/visualboyadvance-m-Win-64bit.zip", "visualboyadvance-m-Win-64bit.zip", "GBA", "visualboyadvance-m.exe", "Visual Boy Advance-M", "vbam.eldr", "\"}

            emulator_downloader.RunWorkerAsync(arguments)
            main.lbl_status.Text = "Installing Visual Boy Advance-M"
            Call center_status_lbl()
        ElseIf listbox_emulators.SelectedItem = "Citra (3DS)" Then
            arguments = {"CITRA", "https://github.com/ParthK117/citraportable/releases/download/1536/citraportable.zip", "citraportable.zip", "3DS", "citraportable\nightly-mingw\citra-qt.exe", "Citra", "citra.eldr", "\"}

            emulator_downloader.RunWorkerAsync(arguments)
            main.lbl_status.Text = "Installing Citra"
            Call center_status_lbl()
        ElseIf listbox_emulators.SelectedItem = "DeSmuME (NDS)" Then
            arguments = {"DESMUME", "https://drive.google.com/uc?export=download&id=1d4qdS0_Qzv2aub0FkZ_zGzJgnIK_8Set", "desmume-0.9.11-win64.zip", "NDS", "desmume-0.9.11-win64\DeSmuME_0.9.11_x64.exe", "DeSmuME", "desmume.eldr", "\"}

            emulator_downloader.RunWorkerAsync(arguments)
            main.lbl_status.Text = "Installing DeSmuME"
            Call center_status_lbl()
        ElseIf listbox_emulators.SelectedItem = "Project64 (N64)" Then
            arguments = {"PROJECT64", "https://drive.google.com/uc?export=download&id=1-zZooDk0ukUSIvEV79twB9FRLrk7ONVr", "Project64 2.3.2 Portable.zip", "N64", "Project64 2.3.2 FULL\Project64.exe", "Project64", "project64.eldr", "\"}

            emulator_downloader.RunWorkerAsync(arguments)
            main.lbl_status.Text = "Installing Project64"
            Call center_status_lbl()
        ElseIf listbox_emulators.SelectedItem = "PPSSPP (PSP)" Then
            arguments = {"PPSSPP", "https://www.ppsspp.org/files/1_9_3/ppsspp_win.zip", "ppsspp_win.zip", "PSP", "\ppsspp_win\PPSSPPWindows64.exe", "PPSSPP", "ppsspp.eldr", "\ppsspp_win\"}

            emulator_downloader.RunWorkerAsync(arguments)
            main.lbl_status.Text = "Installing PPSSPP"
            Call center_status_lbl()
        ElseIf listbox_emulators.SelectedItem = "Dolphin (WII)" Then
            arguments = {"DOLPHIN", "https://drive.google.com/uc?export=download&id=1YLnQrjUwCRatH4TNyDg0un4M7UUV-MwZ", "Dolphin-x64.zip", "WII", "\Dolphin-x64\Dolphin.exe", "Dolphin", "dolphin.eldr", "\"}

            emulator_downloader.RunWorkerAsync(arguments)
            main.lbl_status.Text = "Installing Dolphin"
            Call center_status_lbl()
        End If
        main.picturebox_loading.Visible = True
        MessageBox.Show(arguments(5) & " will be installed")
        Me.Close()
    End Sub
End Class