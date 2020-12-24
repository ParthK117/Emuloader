Imports System.IO
Imports System.IO.Compression
Imports System.Net

Module module_emulatorupdater
    Public Sub emulator_updater()
        Dim uptodate_list As String()
        Using currentlinks = New WebClient()
            Try
                If Not main.global_settings(12).Split("=")(1) = "1" Then
                    currentlinks.DownloadFile("https://tungstencore.com/cdn/emulatorlinks.txt", ".\modules\emulatorlinks.txt")
                    currentlinks.Dispose()
                End If
                uptodate_list = File.ReadAllLines(".\modules\emulatorlinks.txt")
            Catch ex As Exception
            End Try
        End Using
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
        Select Case main.currenttab_metadata(0)
            Case "Visual Boy Advance-M"
                Dim newversion As String() = uptodate_list(0).Split(",")
                If Not main.currenttab_metadata(5) = newversion(4) Then
                    Dim arguments As String()
                    arguments = {newversion(0)}
                    main.thread_emulator_update.RunWorkerAsync(arguments)
                Else
                    Call main.launch_emulator()
                End If
            Case "Snes9x"
                Dim newversion As String() = uptodate_list(7).Split(",")
                If Not main.currenttab_metadata(5) = newversion(4) Then
                    Dim arguments As String()
                    arguments = {newversion(0)}
                    main.thread_emulator_update.RunWorkerAsync(arguments)
                Else
                    Call main.launch_emulator()
                End If
            Case "Citra"
                Dim newversion As String() = uptodate_list(1).Split(",")
                If Not main.currenttab_metadata(5) = newversion(4) Then
                    Dim arguments As String()
                    arguments = {newversion(0)}
                    main.thread_emulator_update.RunWorkerAsync(arguments)
                Else
                    Call main.launch_emulator()
                End If
            Case "DeSmuME"
                Dim newversion As String() = uptodate_list(2).Split(",")
                If Not main.currenttab_metadata(5) = newversion(4) Then
                    Dim arguments As String()
                    arguments = {newversion(0)}
                    main.thread_emulator_update.RunWorkerAsync(arguments)
                Else
                    Call main.launch_emulator()
                End If
            Case "Project64"
                Dim newversion As String() = uptodate_list(3).Split(",")
                If Not main.currenttab_metadata(5) = newversion(4) Then
                    Dim arguments As String()
                    arguments = {newversion(0)}
                    main.thread_emulator_update.RunWorkerAsync(arguments)
                Else
                    Call main.launch_emulator()
                End If
            Case "PPSSPP"
                Dim newversion As String() = uptodate_list(4).Split(",")
                If Not main.currenttab_metadata(5) = newversion(4) Then
                    Dim arguments As String()
                    arguments = {newversion(0)}
                    main.thread_emulator_update.RunWorkerAsync(arguments)
                Else
                    Call main.launch_emulator()
                End If
            Case "Dolphin"
                Dim newversion As String() = uptodate_list(5).Split(",")
                If Not main.currenttab_metadata(5) = newversion(4) Then
                    Dim arguments As String()
                    arguments = {newversion(0)}
                    main.thread_emulator_update.RunWorkerAsync(arguments)
                Else
                    Call main.launch_emulator()
                End If
            Case "Cemu"
                Dim newversion As String() = uptodate_list(6).Split(",")
                If Not main.currenttab_metadata(5) = newversion(4) Then
                    Dim arguments As String()
                    arguments = {newversion(0)}
                    main.thread_emulator_update.RunWorkerAsync(arguments)
                Else
                    Call main.launch_emulator()
                End If
            Case "Mesen"
                Dim newversion As String() = uptodate_list(8).Split(",")
                If Not main.currenttab_metadata(5) = newversion(4) Then
                    Dim arguments As String()
                    arguments = {newversion(0)}
                    main.thread_emulator_update.RunWorkerAsync(arguments)
                Else
                    Call main.launch_emulator()
                End If
            Case "ePSXe"
                Dim newversion As String() = uptodate_list(9).Split(",")
                If Not main.currenttab_metadata(5) = newversion(4) Then
                    Dim arguments As String()
                    arguments = {newversion(0)}
                    main.thread_emulator_update.RunWorkerAsync(arguments)
                Else
                    Call main.launch_emulator()
                End If
            Case "Fusion"
                Dim newversion As String() = uptodate_list(10).Split(",")
                If Not main.currenttab_metadata(5) = newversion(4) Then
                    Dim arguments As String()
                    arguments = {newversion(0)}
                    main.thread_emulator_update.RunWorkerAsync(arguments)
                Else
                    Call main.launch_emulator()
                End If
            Case "Redream"
                Dim newversion As String() = uptodate_list(11).Split(",")
                If Not main.currenttab_metadata(5) = newversion(4) Then
                    Dim arguments As String()
                    arguments = {newversion(0)}
                    main.thread_emulator_update.RunWorkerAsync(arguments)
                Else
                    Call main.launch_emulator()
                End If
            Case "PCSX2"
                Dim newversion As String() = uptodate_list(12).Split(",")
                If Not main.currenttab_metadata(5) = newversion(4) Then
                    Dim arguments As String()
                    arguments = {newversion(0)}
                    main.thread_emulator_update.RunWorkerAsync(arguments)
                Else
                    Call main.launch_emulator()
                End If
            Case "yuzu"
                Dim newversion As String() = uptodate_list(13).Split(",")
                If Not main.currenttab_metadata(5) = newversion(4) Then
                    Dim arguments As String()
                    arguments = {newversion(0)}
                    main.thread_emulator_update.RunWorkerAsync(arguments)
                Else
                    Call main.launch_emulator()
                End If
            Case "DuckStation"
                Dim newversion As String() = uptodate_list(14).Split(",")
                If Not main.currenttab_metadata(5) = newversion(4) Then
                    Dim arguments As String()
                    arguments = {newversion(0)}
                    main.thread_emulator_update.RunWorkerAsync(arguments)
                Else
                    Call main.launch_emulator()
                End If
        End Select


    End Sub

    Public Sub jumpin_updater()
        If File.Exists(".\lastplayed.dat") Then
            Dim jumpin_metadata As String() = File.ReadAllLines(".\lastplayed.dat")
            main.lbl_jumpin_romname.Text = jumpin_metadata(1)
            main.lbl_jumpin_lastplayed.Text = "Last played " & jumpin_metadata(2)
            main.lbl_jumpin_emuname.Text = jumpin_metadata(0)
            Try
                main.picturebox_boxart_jumpin.BackgroundImage = System.Drawing.Image.FromFile(jumpin_metadata(3))
            Catch ex As Exception
                main.picturebox_boxart_jumpin.BackgroundImage = System.Drawing.Image.FromFile(".\modules\noimage.png")
            End Try
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
