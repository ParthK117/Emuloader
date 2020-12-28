Imports System.IO

Module downloads
    Public Class downloadqueue
        Public Shared opensans As New System.Drawing.Text.PrivateFontCollection()
        Public Shared arguments As String()
        Public Shared reportedsize As Double
        Public Shared currentsize As Double

        Public Shared downloader_state As Boolean = False
        Public Shared downloader_process As New Process()
    End Class
    Public Sub launch_downloader()
        main.picturebox_loading.Visible = True


        Dim platform_id As String

        Select Case main.listbox_queue.Items(0).SubItems(2).Text
            Case "GBA"
                platform_id = ".gba"
                Directory.CreateDirectory(".\roms\GBA")
            Case "3DS"
                platform_id = ".3ds"
                Directory.CreateDirectory(".\roms\3DS")
            Case "NDS"
                platform_id = ".nds"
                Directory.CreateDirectory(".\roms\NDS")
            Case "N64"
                platform_id = ".z64"
                Directory.CreateDirectory(".\roms\N64")
            Case "PSP"
                platform_id = ".iso"
                Directory.CreateDirectory(".\roms\PSP")
            Case "WII"
                platform_id = ".iso"
                Directory.CreateDirectory(".\roms\WII")
            Case "GBC"
                platform_id = ".gbc"
                Directory.CreateDirectory(".\roms\GBC")
            Case "GB"
                platform_id = ".gb"
                Directory.CreateDirectory(".\roms\GB")
            Case "PSX"
                platform_id = ".iso"
                Directory.CreateDirectory(".\roms\PSX")
            Case "PS2"
                platform_id = ".iso"
                Directory.CreateDirectory(".\roms\PS2")
            Case "MGD"
                platform_id = ".bin"
                Directory.CreateDirectory(".\roms\MGD")
            Case "NES"
                platform_id = ".nes"
                Directory.CreateDirectory(".\roms\NES")
            Case "SNES"
                platform_id = ".smc"
                Directory.CreateDirectory(".\roms\SNES")
            Case "DC"
                platform_id = ".gdi"
                Directory.CreateDirectory(".\roms\DC")
            Case "SWH"
                platform_id = ".nsp"
                Directory.CreateDirectory(".\roms\SWH")
            Case "STN"
                platform_id = ".cue"
                Directory.CreateDirectory(".\roms\STN")
        End Select

        main.listbox_queue.Items(0).SubItems(5).Text = "Downloading"
        main.lbl_status.Text = "Downloading " & main.listbox_queue.Items(0).SubItems(0).Text
        main.lbl_status.Location = New Point((main.panel_top.Width - main.lbl_status.Width) \ 2, (main.panel_top.Height - main.lbl_status.Height) \ 2)
        
        Dim corrected_name As String
        corrected_name = main.listbox_queue.Items(0).SubItems(0).Text.Replace(":", "$").Replace(" ", "$")
        'converts from base64 to normal if its encrypted
        If Not main.listbox_queue.Items(0).SubItems(4).Text.Contains("http") Then
            Dim b As Byte() = Convert.FromBase64String(main.listbox_queue.Items(0).SubItems(4).Text)
            main.listbox_queue.Items(0).SubItems(4).Text = System.Text.Encoding.UTF8.GetString(b)
        End If
        downloadqueue.arguments = {corrected_name & platform_id, main.listbox_queue.Items(0).SubItems(2).Text, main.listbox_queue.Items(0).SubItems(4).Text, platform_id}
        main.listbox_queue.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent)
        main.listbox_queue.AutoResizeColumn(2, ColumnHeaderAutoResizeStyle.HeaderSize)
        main.listbox_queue.Columns.Item(4).Width = 0

        main.timer_updateprogress.Enabled = True
        If main.downloader.IsBusy = False Then
            main.picturebox_loading.Visible = True
            main.lbl_status.Location = New Point((main.panel_top.Width - main.lbl_status.Width) \ 2, (main.panel_top.Height - main.lbl_status.Height) \ 2)
            main.downloader.RunWorkerAsync(downloadqueue.arguments)
        End If

    End Sub
End Module
