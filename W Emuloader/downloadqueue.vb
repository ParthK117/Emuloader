﻿Imports System.Net
Imports System.IO
Imports System.IO.Compression
Imports System.ComponentModel

Public Class downloadqueue
    Public Shared spartan As New System.Drawing.Text.PrivateFontCollection()
    Dim arguments As String()

    Private Sub downloadqueue_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If main.panel_search.Visible = True Then
            listbox_queue.Items.Add(New ListViewItem(New String() {main.listbox_search.FocusedItem.SubItems(0).Text,
main.listbox_search.FocusedItem.SubItems(1).Text,
main.listbox_search.FocusedItem.SubItems(2).Text,
main.listbox_search.FocusedItem.SubItems(3).Text,
main.listbox_search.FocusedItem.SubItems(4).Text}))
        Else
            listbox_queue.Items.Add(New ListViewItem(New String() {main.listbox_availableroms.FocusedItem.SubItems(0).Text,
  main.listbox_availableroms.FocusedItem.SubItems(1).Text,
  main.listbox_availableroms.FocusedItem.SubItems(2).Text,
  main.listbox_availableroms.FocusedItem.SubItems(3).Text,
  main.listbox_availableroms.FocusedItem.SubItems(4).Text}))
        End If
        Call launch_downloader()

        Dim spartanfont12 As New System.Drawing.Font(main.spartan.Families(0), 12)
        listbox_queue.Font = spartanfont12

        If main.dark = True Then
            Me.BackColor = Color.FromArgb(21, 32, 43)
            listbox_queue.BackColor = Color.FromArgb(21, 32, 43)
            listbox_queue.ForeColor = Color.White
        End If
    End Sub



    Public Sub launch_downloader()
        main.picturebox_loading.Visible = True


        Dim platform_id As String
        If listbox_queue.Items(0).SubItems(2).Text = "GBA" Then
            platform_id = ".gba"
            If Directory.Exists(".\roms\GBA") = False Then
                Directory.CreateDirectory(".\roms\GBA")
            End If
        ElseIf listbox_queue.Items(0).SubItems(2).Text = "3DS" Then
            platform_id = ".3ds"
            If Directory.Exists(".\roms\3DS") = False Then
                Directory.CreateDirectory(".\roms\3DS")
            End If
        ElseIf listbox_queue.Items(0).SubItems(2).Text = "NDS" Then
            platform_id = ".nds"
            If Directory.Exists(".\roms\NDS") = False Then
                Directory.CreateDirectory(".\roms\NDS")
            End If
        ElseIf listbox_queue.Items(0).SubItems(2).Text = "N64" Then
            platform_id = ".z64"
            If Directory.Exists(".\roms\N64") = False Then
                Directory.CreateDirectory(".\roms\N64")
            End If
        ElseIf listbox_queue.Items(0).SubItems(2).Text = "PSP" Then
            platform_id = ".iso"
            If Directory.Exists(".\roms\PSP") = False Then
                Directory.CreateDirectory(".\roms\PSP")
            End If
        ElseIf listbox_queue.Items(0).SubItems(2).Text = "WII" Then
            platform_id = ".iso"
            If Directory.Exists(".\roms\WII") = False Then
                Directory.CreateDirectory(".\roms\WII")
            End If
        ElseIf listbox_queue.Items(0).SubItems(2).Text = "GBC" Then
            platform_id = ".gbc"
            If Directory.Exists(".\roms\GBC") = False Then
                Directory.CreateDirectory(".\roms\GBC")
            End If
        ElseIf listbox_queue.Items(0).SubItems(2).Text = "GB" Then
            platform_id = ".gb"
            If Directory.Exists(".\roms\GB") = False Then
                Directory.CreateDirectory(".\roms\GB")
            End If
        ElseIf listbox_queue.Items(0).SubItems(2).Text = "PSX" Then
            platform_id = ".iso"
            If Directory.Exists(".\roms\PSX") = False Then
                Directory.CreateDirectory(".\roms\PSX")
            End If
        ElseIf listbox_queue.Items(0).SubItems(2).Text = "PS2" Then
            platform_id = ".iso"
            If Directory.Exists(".\roms\PS2") = False Then
                Directory.CreateDirectory(".\roms\PS2")
            End If
        ElseIf listbox_queue.Items(0).SubItems(2).Text = "MGD" Then
            platform_id = ".bin"
            If Directory.Exists(".\roms\MGD") = False Then
                Directory.CreateDirectory(".\roms\MGD")
            End If
        ElseIf listbox_queue.Items(0).SubItems(2).Text = "NES" Then
            platform_id = ".nes"
            If Directory.Exists(".\roms\NES") = False Then
                Directory.CreateDirectory(".\roms\NES")
            End If
        ElseIf listbox_queue.Items(0).SubItems(2).Text = "SNES" Then
            platform_id = ".smc"
            If Directory.Exists(".\roms\SNES") = False Then
                Directory.CreateDirectory(".\roms\SNES")
            End If
        ElseIf listbox_queue.Items(0).SubItems(2).Text = "DC" Then
            platform_id = ".gdi"
            If Directory.Exists(".\roms\DC") = False Then
                Directory.CreateDirectory(".\roms\DC")
            End If
        End If



        main.lbl_status.Text = "Downloading " & listbox_queue.Items(0).SubItems(0).Text
        main.lbl_status.Location = New Point((main.panel_top.Width - main.lbl_status.Width) \ 2, (main.panel_top.Height - main.lbl_status.Height) \ 2)

        Dim corrected_name As String
        corrected_name = listbox_queue.Items(0).SubItems(0).Text.Replace(":", "$").Replace(" ", "$")

        If Not listbox_queue.Items(0).SubItems(4).Text.Contains("http") Then
            Dim b As Byte() = Convert.FromBase64String(listbox_queue.Items(0).SubItems(4).Text)
            listbox_queue.Items(0).SubItems(4).Text = System.Text.Encoding.UTF8.GetString(b)
        End If
        arguments = {corrected_name & platform_id, listbox_queue.Items(0).SubItems(2).Text, listbox_queue.Items(0).SubItems(4).Text}


        timer_updateprogress.Enabled = True
        downloader.RunWorkerAsync(arguments)




    End Sub



    Private Sub downloader_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles downloader.DoWork
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
        Dim arguments As String() = (e.Argument)
        Dim iszip = False



        Using downloader_client = New WebClient()
            Try

                downloader_client.DownloadFile(arguments(2), ".\roms\" & arguments(1) & "\" & arguments(0).Replace("$", " "))
                downloader_client.Dispose()



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
                    p.Arguments = ("e" & " " & Chr(34) & System.IO.Path.GetFullPath(".\roms\" & arguments(1) & "\" & arguments(0).Replace("$", " ")) & Chr(34) & " -o" & Chr(34) & System.IO.Path.GetFullPath(".\roms\" & arguments(1) & "\") & Chr(34))
                    un7z = Process.Start(p)
                    un7z.WaitForExit()
                    If File.Exists(System.IO.Path.GetFullPath(".\roms\" & arguments(1) & "\" & arguments(0).Replace("$", " "))) Then
                        File.Delete(System.IO.Path.GetFullPath(".\roms\" & arguments(1) & "\" & arguments(0).Replace("$", " ")))
                    End If
                End If



            Catch ex As Exception
                downloader_client.Dispose()
                MessageBox.Show("Error downloading")


            End Try
        End Using

    End Sub

    Private Sub downloader_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles downloader.RunWorkerCompleted
        timer_updateprogress.Enabled = False
        main.lbl_status.Text = "Downloaded " & listbox_queue.Items(0).SubItems(0).Text
        Call load_installed_roms()
        main.lbl_status.Location = New Point((main.panel_top.Width - main.lbl_status.Width) \ 2, (main.panel_top.Height - main.lbl_status.Height) \ 2)
        listbox_queue.Items(0).Remove()
        If listbox_queue.Items.Count = 0 Then
            main.picturebox_loading.Visible = False
            Me.Close()
        Else
            Call launch_downloader()
        End If
    End Sub


    Private Sub timer_updateprogress_Tick(sender As Object, e As EventArgs) Handles timer_updateprogress.Tick
        If File.Exists(".\roms\" & arguments(1) & "\" & arguments(0).Replace("$", " ")) Then
            Dim currfile As New FileInfo(".\roms\" & arguments(1) & "\" & arguments(0).Replace("$", " "))
            Dim currentsize As Double = (currfile.Length / 1000000)
            Dim reportedsize As String = listbox_queue.Items(0).SubItems(1).Text
            If reportedsize.Contains("GB") Then
                reportedsize = (reportedsize.Replace(" ", "").Replace("GB", "") * 1000)
            End If
            If reportedsize.Contains("MB") Then
                reportedsize = (reportedsize.Replace(" ", "").Replace("MB", ""))
            End If
            If reportedsize.Contains("KB") Then
                reportedsize = (reportedsize.Replace(" ", "").Replace("KB", "") / 1000)
            End If
            Dim displaysize As Double = Math.Round(((currentsize / reportedsize) * 100), 2)
            If displaysize > 100 Then
                displaysize = 99.99
            End If
            main.lbl_status.Text = "Downloading " & listbox_queue.Items(0).SubItems(0).Text & " " & displaysize & "%"
            main.lbl_status.Location = New Point((main.panel_top.Width - main.lbl_status.Width) \ 2, (main.panel_top.Height - main.lbl_status.Height) \ 2)
        End If
    End Sub
End Class