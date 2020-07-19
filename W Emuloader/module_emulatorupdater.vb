Imports System.IO
Imports System.IO.Compression
Imports System.Net

Module module_emulatorupdater

    Public Sub emulator_updater()
        Dim uptodate_list As String()
        Using currentlinks = New WebClient()
            Try
                currentlinks.DownloadFile("https://tungstencore.com/cdn/emulatorlinks.txt", ".\modules\emulatorlinks.txt")
                currentlinks.Dispose()
                uptodate_list = File.ReadAllLines(".\modules\emulatorlinks.txt")
            Catch ex As Exception
            End Try
        End Using
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
        If main.currenttab_metadata(0) = "Visual Boy Advance-M" Then
            Dim newversion As String() = uptodate_list(0).Split(",")


            If Not main.currenttab_metadata(5) = newversion(4) Then
                Dim arguments As String()
                arguments = {newversion(0)}

                main.thread_emulator_update.RunWorkerAsync(arguments)
            Else
                Call main.launch_emulator()
            End If
        ElseIf main.currenttab_metadata(0) = "Snes9x" Then
            Dim newversion As String() = uptodate_list(7).Split(",")


            If Not main.currenttab_metadata(5) = newversion(4) Then
                Dim arguments As String()
                arguments = {newversion(0)}

                main.thread_emulator_update.RunWorkerAsync(arguments)
            Else
                Call main.launch_emulator()
            End If
        End If

    End Sub

    Public Sub jumpin_updater()
        If File.Exists(".\lastplayed.dat") Then
            Dim jumpin_metadata As String() = File.ReadAllLines(".\lastplayed.dat")
            main.lbl_jumpin_romname.Text = jumpin_metadata(1)
            main.lbl_jumpin_lastplayed.Text = "Last played " & jumpin_metadata(2)
            main.lbl_jumpin_emuname.Text = jumpin_metadata(0)
            main.picturebox_boxart_jumpin.BackgroundImage = System.Drawing.Image.FromFile(jumpin_metadata(3))
        End If
    End Sub

    Public Sub lastplayed()
        Dim lastplayed As String() = File.ReadAllLines(".\roms\" & main.currenttab_metadata(1) & "\metadata\lastplayed.dat")
        For Each x In lastplayed
            Dim current_played As String() = x.Split(",")
            If current_played(0) = main.listbox_installedroms.FocusedItem.SubItems(0).Text Then
                main.lbl_last_played.Text = "Last played on " & current_played(1)
                Exit For
            Else
                main.lbl_last_played.Text = "Last played never"
            End If
        Next
    End Sub
End Module
