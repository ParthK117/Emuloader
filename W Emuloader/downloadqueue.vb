Imports System.Net
Imports System.IO
Imports System.IO.Compression
Imports System.ComponentModel

Public Class downloadqueue
    Public Shared spartan As New System.Drawing.Text.PrivateFontCollection()

    Private Sub downloadqueue_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        listbox_queue.Items.Add(New ListViewItem(New String() {main.listbox_availableroms.FocusedItem.SubItems(0).Text,
          main.listbox_availableroms.FocusedItem.SubItems(1).Text,
          main.listbox_availableroms.FocusedItem.SubItems(2).Text,
          main.listbox_availableroms.FocusedItem.SubItems(3).Text,
          main.listbox_availableroms.FocusedItem.SubItems(4).Text}))
        Call launch_downloader()

        Dim spartanfont12 As New System.Drawing.Font(main.spartan.Families(0), 12)
        listbox_queue.Font = spartanfont12
    End Sub



    Public Sub launch_downloader()



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
        End If

        Dim arguments As String()

        main.lbl_status.Text = "Downloading " & listbox_queue.Items(0).SubItems(0).Text
        main.lbl_status.Location = New Point((main.panel_top.Width - main.lbl_status.Width) \ 2, (main.panel_top.Height - main.lbl_status.Height) \ 2)

        Dim corrected_name As String
        corrected_name = listbox_queue.Items(0).SubItems(0).Text.Replace(":", "$").Replace(" ", "$")
        arguments = {corrected_name & platform_id, listbox_queue.Items(0).SubItems(2).Text, listbox_queue.Items(0).SubItems(4).Text}



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




            Catch ex As Exception
                downloader_client.Dispose()
                MessageBox.Show("Error downloading")


            End Try
        End Using

    End Sub

    Private Sub downloader_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles downloader.RunWorkerCompleted
        main.lbl_status.Text = "Downloaded " & listbox_queue.Items(0).SubItems(0).Text
        Call main.load_installed_roms()
        main.lbl_status.Location = New Point((main.panel_top.Width - main.lbl_status.Width) \ 2, (main.panel_top.Height - main.lbl_status.Height) \ 2)
        listbox_queue.Items(0).Remove()
        If listbox_queue.Items.Count = 0 Then
            Me.Close()
        Else
            Call launch_downloader()
        End If
    End Sub
End Class