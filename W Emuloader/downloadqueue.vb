Imports System.Net
Imports System.IO
Imports System.IO.Compression
Imports System.ComponentModel

Public Class downloadqueue


    Private Sub downloadqueue_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        listbox_queue.Items.Add(New ListViewItem(New String() {main.listbox_availableroms.FocusedItem.SubItems(0).Text,
          main.listbox_availableroms.FocusedItem.SubItems(1).Text,
          main.listbox_availableroms.FocusedItem.SubItems(2).Text,
          main.listbox_availableroms.FocusedItem.SubItems(3).Text,
          main.listbox_availableroms.FocusedItem.SubItems(4).Text}))
        Call launch_downloader()

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
        End If

        Dim arguments As String()

        main.lbl_status.Text = "Downloading " & listbox_queue.Items(0).SubItems(0).Text
        main.lbl_status.Location = New Point((main.panel_top.Width - main.lbl_status.Width) \ 2, (main.panel_top.Height - main.lbl_status.Height) \ 2)


        Dim corrected_name As String
        corrected_name = listbox_queue.Items(0).SubItems(0).Text.Replace(" ", "$")
        arguments = {corrected_name & platform_id, listbox_queue.Items(0).SubItems(2).Text, listbox_queue.Items(0).SubItems(4).Text}



        downloader.RunWorkerAsync(arguments)




    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs)
        Call launch_downloader()
    End Sub



    Private Sub downloader_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles downloader.DoWork
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
        Dim arguments As String() = (e.Argument)

        Using downloader_client = New WebClient()
            Try
                downloader_client.DownloadFile(arguments(2), ".\roms\" & arguments(1) & "\" & arguments(0).Replace("$", " "))
                downloader_client.Dispose()

            Catch ex As Exception
                downloader_client.Dispose()
                MessageBox.Show("Faulty download link")

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