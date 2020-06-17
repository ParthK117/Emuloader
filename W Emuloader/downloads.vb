Imports System.IO

Module downloads
    Public Class downloadqueue
        Public Shared spartan As New System.Drawing.Text.PrivateFontCollection()
        Public Shared arguments As String()
        Public Shared reportedsize As Double
        Public Shared currentsize As Double

        Public Shared downloader_state As Boolean = False
        Public Shared downloader_process As New Process()
    End Class
    Public Sub launch_downloader()
        main.picturebox_loading.Visible = True


        Dim platform_id As String
        If main.listbox_queue.Items(0).SubItems(2).Text = "GBA" Then
            platform_id = ".gba"
            If Directory.Exists(".\roms\GBA") = False Then
                Directory.CreateDirectory(".\roms\GBA")
            End If
        ElseIf main.listbox_queue.Items(0).SubItems(2).Text = "3DS" Then
            platform_id = ".3ds"
            If Directory.Exists(".\roms\3DS") = False Then
                Directory.CreateDirectory(".\roms\3DS")
            End If
        ElseIf main.listbox_queue.Items(0).SubItems(2).Text = "NDS" Then
            platform_id = ".nds"
            If Directory.Exists(".\roms\NDS") = False Then
                Directory.CreateDirectory(".\roms\NDS")
            End If
        ElseIf main.listbox_queue.Items(0).SubItems(2).Text = "N64" Then
            platform_id = ".z64"
            If Directory.Exists(".\roms\N64") = False Then
                Directory.CreateDirectory(".\roms\N64")
            End If
        ElseIf main.listbox_queue.Items(0).SubItems(2).Text = "PSP" Then
            platform_id = ".iso"
            If Directory.Exists(".\roms\PSP") = False Then
                Directory.CreateDirectory(".\roms\PSP")
            End If
        ElseIf main.listbox_queue.Items(0).SubItems(2).Text = "WII" Then
            platform_id = ".iso"
            If Directory.Exists(".\roms\WII") = False Then
                Directory.CreateDirectory(".\roms\WII")
            End If
        ElseIf main.listbox_queue.Items(0).SubItems(2).Text = "GBC" Then
            platform_id = ".gbc"
            If Directory.Exists(".\roms\GBC") = False Then
                Directory.CreateDirectory(".\roms\GBC")
            End If
        ElseIf main.listbox_queue.Items(0).SubItems(2).Text = "GB" Then
            platform_id = ".gb"
            If Directory.Exists(".\roms\GB") = False Then
                Directory.CreateDirectory(".\roms\GB")
            End If
        ElseIf main.listbox_queue.Items(0).SubItems(2).Text = "PSX" Then
            platform_id = ".iso"
            If Directory.Exists(".\roms\PSX") = False Then
                Directory.CreateDirectory(".\roms\PSX")
            End If
        ElseIf main.listbox_queue.Items(0).SubItems(2).Text = "PS2" Then
            platform_id = ".iso"
            If Directory.Exists(".\roms\PS2") = False Then
                Directory.CreateDirectory(".\roms\PS2")
            End If
        ElseIf main.listbox_queue.Items(0).SubItems(2).Text = "MGD" Then
            platform_id = ".bin"
            If Directory.Exists(".\roms\MGD") = False Then
                Directory.CreateDirectory(".\roms\MGD")
            End If
        ElseIf main.listbox_queue.Items(0).SubItems(2).Text = "NES" Then
            platform_id = ".nes"
            If Directory.Exists(".\roms\NES") = False Then
                Directory.CreateDirectory(".\roms\NES")
            End If
        ElseIf main.listbox_queue.Items(0).SubItems(2).Text = "SNES" Then
            platform_id = ".smc"
            If Directory.Exists(".\roms\SNES") = False Then
                Directory.CreateDirectory(".\roms\SNES")
            End If
        ElseIf main.listbox_queue.Items(0).SubItems(2).Text = "DC" Then
            platform_id = ".gdi"
            If Directory.Exists(".\roms\DC") = False Then
                Directory.CreateDirectory(".\roms\DC")
            End If
        End If



        main.lbl_status.Text = "Downloading " & main.listbox_queue.Items(0).SubItems(0).Text
        main.lbl_status.Location = New Point((main.panel_top.Width - main.lbl_status.Width) \ 2, (main.panel_top.Height - main.lbl_status.Height) \ 2)

        Dim corrected_name As String
        corrected_name = main.listbox_queue.Items(0).SubItems(0).Text.Replace(":", "$").Replace(" ", "$")

        If Not main.listbox_queue.Items(0).SubItems(4).Text.Contains("http") Then
            Dim b As Byte() = Convert.FromBase64String(main.listbox_queue.Items(0).SubItems(4).Text)
            main.listbox_queue.Items(0).SubItems(4).Text = System.Text.Encoding.UTF8.GetString(b)
        End If
        downloadqueue.arguments = {corrected_name & platform_id, main.listbox_queue.Items(0).SubItems(2).Text, main.listbox_queue.Items(0).SubItems(4).Text}
        main.listbox_queue.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent)
        main.listbox_queue.AutoResizeColumn(2, ColumnHeaderAutoResizeStyle.HeaderSize)
        main.listbox_queue.Columns.Item(4).Width = 0

        main.timer_updateprogress.Enabled = True
        If main.downloader.IsBusy = False Then
            main.downloader.RunWorkerAsync(downloadqueue.arguments)
        End If

    End Sub


    Delegate Sub downloader_box_Delg(downloader_text As String)
    Public downloader_delegate As downloader_box_Delg = New downloader_box_Delg(AddressOf downloader_output)
    Public Sub downloader_output(downloader_text As String)
        If downloader_text IsNot Nothing Then
            Dim speed_split As String() = Split(downloader_text, ",")
            '   downloadqueue.reportedsize = speed_split(3)
            '    downloadqueue.currentsize = speed_split(2)

        Else
            MessageBox.Show("")
        End If


    End Sub
    Public Sub downloader_process_OutputDataReceived(ByVal sender As Object, ByVal e As DataReceivedEventArgs)
        If main.InvokeRequired = True Then
            main.Invoke(downloader_delegate, e.Data)
        Else
            downloader_output(e.Data)
        End If
    End Sub

    Public Sub kill_downloader()
        If downloadqueue.downloader_state = True Then
            Try
                downloadqueue.downloader_process.Kill()
            Catch ex As Exception
            End Try
            RemoveHandler downloadqueue.downloader_process.ErrorDataReceived, AddressOf downloader_process_OutputDataReceived
            RemoveHandler downloadqueue.downloader_process.OutputDataReceived, AddressOf downloader_process_OutputDataReceived
            downloadqueue.downloader_process.CancelErrorRead()
            downloadqueue.downloader_process.CancelOutputRead()
            downloadqueue.downloader_state = False
            'lbl_status.Text = "Status: Stopped"
        End If
    End Sub
    Public Sub downloader()
        downloadqueue.downloader_process.StartInfo.FileName = ".\modules\anylink"
        downloadqueue.downloader_process.StartInfo.Arguments = (Chr(34) & downloadqueue.arguments(2) & Chr(34) & " " & Chr(34) & downloadqueue.arguments(0) & Chr(34))
        downloadqueue.downloader_process.StartInfo.WorkingDirectory = ".\roms\" & downloadqueue.arguments(1)
        downloadqueue.downloader_process.StartInfo.RedirectStandardError = True
        downloadqueue.downloader_process.StartInfo.RedirectStandardOutput = True
        downloadqueue.downloader_process.EnableRaisingEvents = True
        downloadqueue.downloader_process.StartInfo.UseShellExecute = False
        downloadqueue.downloader_process.StartInfo.CreateNoWindow = False
        Application.DoEvents()
        AddHandler downloadqueue.downloader_process.ErrorDataReceived, AddressOf downloader_process_OutputDataReceived
        AddHandler downloadqueue.downloader_process.OutputDataReceived, AddressOf downloader_process_OutputDataReceived
        downloadqueue.downloader_process.Start()
        downloadqueue.downloader_process.BeginErrorReadLine()
        downloadqueue.downloader_process.BeginOutputReadLine()
        downloadqueue.downloader_state = True
    End Sub

End Module
