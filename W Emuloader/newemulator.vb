Imports System.Net
Imports System.IO
Imports System.IO.Compression
Imports System.ComponentModel

Public Class newemulator

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If ListBox1.SelectedItem = "Visual Boy Advance-M (GBA)" Then
            visual_boy.RunWorkerAsync()
            main.lbl_status.Text = "Installing Visual Boy Advance-M"
            Call center_status_lbl()
        ElseIf ListBox1.SelectedItem = "Citra (3DS)" Then
            citra_3ds.RunWorkerAsync()
            main.lbl_status.Text = "Installing Citra"
            Call center_status_lbl()
        ElseIf ListBox1.SelectedItem = "DeSmuME (NDS)" Then
            desmume.RunWorkerAsync()
            main.lbl_status.Text = "Installing DeSmuME"
            Call center_status_lbl()
        ElseIf ListBox1.SelectedItem = "Project64 (N64)" Then
            project64.RunWorkerAsync()
            main.lbl_status.Text = "Installing Project64"
            Call center_status_lbl()
        ElseIf ListBox1.SelectedItem = "PPSSPP (PSP)" Then
            ppsspp.RunWorkerAsync()
            main.lbl_status.Text = "Installing PPSSPP"
            Call center_status_lbl()
        End If

    End Sub


    Private Sub newemulator_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12



    End Sub
    Private Sub center_status_lbl()
        main.lbl_status.Location = New Point((main.panel_top.Width - main.lbl_status.Width) \ 2, (main.panel_top.Height - main.lbl_status.Height) \ 2)
    End Sub

    Private Sub visual_boy_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles visual_boy.DoWork

        Dim timestamp As String = Date.Now.ToString("HH-mm-ss-dd-MM-yyyy")


        My.Computer.FileSystem.CreateDirectory(".\VBAM-" & timestamp)



        Using vba_m = New WebClient()
            Call center_status_lbl()
            Try
                vba_m.DownloadFile("https://github.com/visualboyadvance-m/visualboyadvance-m/releases/download/v2.1.4/visualboyadvance-m-Win-64bit.zip", ".\VBAM-" & timestamp & "\visualboyadvance-m-Win-64bit.zip")
                vba_m.Dispose()
            Catch ex As Exception
                vba_m.Dispose()
                MessageBox.Show("Can't find Download, exiting.")
            End Try
        End Using

        If File.Exists(".\VBAM-" & timestamp & "\visualboyadvance-m-Win-64bit.zip") Then
            Dim zipfilepath As String = ".\VBAM-" & timestamp & "\visualboyadvance-m-Win-64bit.zip"
            Dim extractto As String = ".\VBAM-" & timestamp & "\"
            ZipFile.ExtractToDirectory(zipfilepath, extractto)

        End If



        'save to settings
        If System.IO.File.Exists(".\installed.eldr") = False Then
            System.IO.File.Create(".\installed.eldr").Dispose()
            Dim installed_emus As String
            installed_emus = "VBAM-" & timestamp
            My.Computer.FileSystem.WriteAllText(".\installed.eldr", installed_emus, True)
        Else
            Dim installed_emus As String = File.ReadAllText(".\installed.eldr")
            installed_emus = installed_emus & vbNewLine & "VBAM-" & timestamp
            My.Computer.FileSystem.WriteAllText(".\installed.eldr", installed_emus, False)
        End If


        Dim datestamp As String = Date.Now.ToString("dd/MM/yyyy")
        Dim metadata As String = "Visual Boy Advance-M" & vbNewLine & "GBA" & vbNewLine & datestamp & vbNewLine & "visualboyadvance-m.exe" & vbNewLine & "VBAM-" & timestamp
        System.IO.File.Create(".\VBAM-" & timestamp & "\vbam.eldr").Dispose()
        My.Computer.FileSystem.WriteAllText(".\VBAM-" & timestamp & "\vbam.eldr", metadata, True)




        If Directory.Exists(".\roms\GBA") = False Then
            My.Computer.FileSystem.CreateDirectory(".\roms\GBA")
        End If

    End Sub

    Private Sub visual_boy_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles visual_boy.RunWorkerCompleted
        main.lbl_status.Text = "Installed Visual Boy Advance-M"
        Call center_status_lbl()
        Call main.loadconfig()
    End Sub

    Private Sub citra_3ds_DoWork(sender As Object, e As DoWorkEventArgs) Handles citra_3ds.DoWork
        Dim timestamp As String = Date.Now.ToString("HH-mm-ss-dd-MM-yyyy")


        My.Computer.FileSystem.CreateDirectory(".\CITRA-" & timestamp)



        Using citra_x = New WebClient()
            Call center_status_lbl()
            Try
                citra_x.DownloadFile("https://github.com/ParthK117/citraportable/releases/download/1536/citraportable.zip", ".\CITRA-" & timestamp & "\citraportable.zip")
                citra_x.Dispose()
            Catch ex As Exception
                citra_x.Dispose()
                MessageBox.Show("Can't find Download, exiting.")
            End Try
        End Using

        If File.Exists(".\CITRA-" & timestamp & "\citraportable.zip") Then
            Dim zipfilepath As String = ".\CITRA-" & timestamp & "\citraportable.zip"
            Dim extractto As String = ".\CITRA-" & timestamp & "\"
            ZipFile.ExtractToDirectory(zipfilepath, extractto)

        End If


        'save to settings
        If System.IO.File.Exists(".\installed.eldr") = False Then
            System.IO.File.Create(".\installed.eldr").Dispose()
            Dim installed_emus As String
            installed_emus = "CITRA-" & timestamp
            My.Computer.FileSystem.WriteAllText(".\installed.eldr", installed_emus, True)
        Else
            Dim installed_emus As String = File.ReadAllText(".\installed.eldr")
            installed_emus = installed_emus & vbNewLine & "CITRA-" & timestamp
            My.Computer.FileSystem.WriteAllText(".\installed.eldr", installed_emus, False)
        End If


        Dim datestamp As String = Date.Now.ToString("dd/MM/yyyy")
        Dim metadata As String = "Citra" & vbNewLine & "3DS" & vbNewLine & datestamp & vbNewLine & "citraportable\nightly-mingw\citra-qt.exe" & vbNewLine & "CITRA-" & timestamp
        System.IO.File.Create(".\CITRA-" & timestamp & "\citra.eldr").Dispose()
        My.Computer.FileSystem.WriteAllText(".\CITRA-" & timestamp & "\citra.eldr", metadata, True)




        If Directory.Exists(".\roms\3DS") = False Then
            My.Computer.FileSystem.CreateDirectory(".\roms\3DS")
        End If


    End Sub

    Private Sub citra_3ds_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles citra_3ds.RunWorkerCompleted
        main.lbl_status.Text = "Installed Citra"
        Call center_status_lbl()
        Call main.loadconfig()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub desmume_RunWorkerCompleted(sender As Object, e As EventArgs) Handles desmume.RunWorkerCompleted
        main.lbl_status.Text = "Installed DeSmuME"
        Call center_status_lbl()
        Call main.loadconfig()
    End Sub

    Private Sub desmume_DoWork(sender As Object, e As DoWorkEventArgs) Handles desmume.DoWork
        Dim timestamp As String = Date.Now.ToString("HH-mm-ss-dd-MM-yyyy")


        My.Computer.FileSystem.CreateDirectory(".\DESMUME-" & timestamp)



        Using desmume_x = New WebClient()

            Call center_status_lbl()
            Try
                desmume_x.DownloadFile("https://drive.google.com/uc?export=download&id=1d4qdS0_Qzv2aub0FkZ_zGzJgnIK_8Set", ".\DESMUME-" & timestamp & "\desmume-0.9.11-win64.zip")
                desmume_x.Dispose()
            Catch ex As Exception
                desmume_x.Dispose()
                MessageBox.Show("Can't find Download, exiting.")
            End Try
        End Using

        If File.Exists(".\DESMUME-" & timestamp & "\desmume-0.9.11-win64.zip") Then
            Dim zipfilepath As String = ".\DESMUME-" & timestamp & "\desmume-0.9.11-win64.zip"
            Dim extractto As String = ".\DESMUME-" & timestamp & "\"
            ZipFile.ExtractToDirectory(zipfilepath, extractto)

        End If


        'save to settings
        If System.IO.File.Exists(".\installed.eldr") = False Then
            System.IO.File.Create(".\installed.eldr").Dispose()
            Dim installed_emus As String
            installed_emus = "DESMUME-" & timestamp
            My.Computer.FileSystem.WriteAllText(".\installed.eldr", installed_emus, True)
        Else
            Dim installed_emus As String = File.ReadAllText(".\installed.eldr")
            installed_emus = installed_emus & vbNewLine & "DESMUME-" & timestamp
            My.Computer.FileSystem.WriteAllText(".\installed.eldr", installed_emus, False)
        End If


        Dim datestamp As String = Date.Now.ToString("dd/MM/yyyy")
        Dim metadata As String = "DeSmuME" & vbNewLine & "NDS" & vbNewLine & datestamp & vbNewLine & "desmume-0.9.11-win64\DeSmuME_0.9.11_x64.exe" & vbNewLine & "DESMUME-" & timestamp
        System.IO.File.Create(".\DESMUME-" & timestamp & "\desmume.eldr").Dispose()
        My.Computer.FileSystem.WriteAllText(".\DESMUME-" & timestamp & "\desmume.eldr", metadata, True)




        If Directory.Exists(".\roms\NDS") = False Then
            My.Computer.FileSystem.CreateDirectory(".\roms\NDS")
        End If


    End Sub

    Private Sub project64_RunWorkerCompleted(sender As Object, e As EventArgs) Handles project64.RunWorkerCompleted
        main.lbl_status.Text = "Installed Project64"
        Call center_status_lbl()
        Call main.loadconfig()
    End Sub

    Private Sub project64_DoWork(sender As Object, e As DoWorkEventArgs) Handles project64.DoWork
        Dim timestamp As String = Date.Now.ToString("HH-mm-ss-dd-MM-yyyy")


        My.Computer.FileSystem.CreateDirectory(".\PROJECT64-" & timestamp)



        Using project64_x = New WebClient()

            Call center_status_lbl()
            Try
                project64_x.DownloadFile("https://drive.google.com/uc?export=download&id=1-zZooDk0ukUSIvEV79twB9FRLrk7ONVr", ".\PROJECT64-" & timestamp & "\Project64 2.3.2 Portable.zip")
                project64_x.Dispose()
            Catch ex As Exception
                project64_x.Dispose()
                MessageBox.Show("Can't find Download, exiting.")
            End Try
        End Using

        If File.Exists(".\PROJECT64-" & timestamp & "\Project64 2.3.2 Portable.zip") Then
            Dim zipfilepath As String = ".\PROJECT64-" & timestamp & "\Project64 2.3.2 Portable.zip"
            Dim extractto As String = ".\PROJECT64-" & timestamp & "\"
            ZipFile.ExtractToDirectory(zipfilepath, extractto)

        End If


        'save to settings
        If System.IO.File.Exists(".\installed.eldr") = False Then
            System.IO.File.Create(".\installed.eldr").Dispose()
            Dim installed_emus As String
            installed_emus = "PROJECT64-" & timestamp
            My.Computer.FileSystem.WriteAllText(".\installed.eldr", installed_emus, True)
        Else
            Dim installed_emus As String = File.ReadAllText(".\installed.eldr")
            installed_emus = installed_emus & vbNewLine & "PROJECT64-" & timestamp
            My.Computer.FileSystem.WriteAllText(".\installed.eldr", installed_emus, False)
        End If


        Dim datestamp As String = Date.Now.ToString("dd/MM/yyyy")
        Dim metadata As String = "Project64" & vbNewLine & "N64" & vbNewLine & datestamp & vbNewLine & "Project64 2.3.2 FULL\Project64.exe" & vbNewLine & "PROJECT64-" & timestamp
        System.IO.File.Create(".\PROJECT64-" & timestamp & "\project64.eldr").Dispose()
        My.Computer.FileSystem.WriteAllText(".\PROJECT64-" & timestamp & "\project64.eldr", metadata, True)




        If Directory.Exists(".\roms\N64") = False Then
            My.Computer.FileSystem.CreateDirectory(".\roms\N64")
        End If
    End Sub

    Private Sub ppsspp_RunWorkerCompleted(sender As Object, e As EventArgs) Handles ppsspp.RunWorkerCompleted
        main.lbl_status.Text = "Installed PPSSPP"
        Call center_status_lbl()
        Call main.loadconfig()
    End Sub

    Private Sub ppsspp_DoWork(sender As Object, e As DoWorkEventArgs) Handles ppsspp.DoWork
        Dim timestamp As String = Date.Now.ToString("HH-mm-ss-dd-MM-yyyy")


        My.Computer.FileSystem.CreateDirectory(".\PPSSPP-" & timestamp)



        Using ppsspp_X = New WebClient()

            Call center_status_lbl()
            Try
                ppsspp_X.DownloadFile("https://www.ppsspp.org/files/1_9_3/ppsspp_win.zip", ".\PPSSPP-" & timestamp & "\ppsspp_win.zip")
                ppsspp_X.Dispose()
            Catch ex As Exception
                ppsspp_X.Dispose()
                MessageBox.Show("Can't find Download, exiting.")
            End Try
        End Using

        If File.Exists(".\PPSSPP-" & timestamp & "\ppsspp_win.zip") Then
            Dim zipfilepath As String = ".\PPSSPP-" & timestamp & "\ppsspp_win.zip"
            Dim extractto As String = ".\PPSSPP-" & timestamp & "\ppsspp_win\"
            ZipFile.ExtractToDirectory(zipfilepath, extractto)

        End If


        'save to settings
        If System.IO.File.Exists(".\installed.eldr") = False Then
            System.IO.File.Create(".\installed.eldr").Dispose()
            Dim installed_emus As String
            installed_emus = "PPSSPP-" & timestamp
            My.Computer.FileSystem.WriteAllText(".\installed.eldr", installed_emus, True)
        Else
            Dim installed_emus As String = File.ReadAllText(".\installed.eldr")
            installed_emus = installed_emus & vbNewLine & "PPSSPP-" & timestamp
            My.Computer.FileSystem.WriteAllText(".\installed.eldr", installed_emus, False)
        End If


        Dim datestamp As String = Date.Now.ToString("dd/MM/yyyy")
        Dim metadata As String = "Project64" & vbNewLine & "PSP" & vbNewLine & datestamp & vbNewLine & "ppsspp_win\PPSSPPWindows64.exe" & vbNewLine & "PPSSPP-" & timestamp
        System.IO.File.Create(".\PPSSPP-" & timestamp & "\ppsspp.eldr").Dispose()
        My.Computer.FileSystem.WriteAllText(".\PPSSPP-" & timestamp & "\ppsspp.eldr", metadata, True)




        If Directory.Exists(".\roms\PSP") = False Then
            My.Computer.FileSystem.CreateDirectory(".\roms\PSP")
        End If
    End Sub
End Class