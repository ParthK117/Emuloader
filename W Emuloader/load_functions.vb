Imports System.IO

Module load_functions
    Public Sub load_installed_roms()
        main.listbox_installedroms.Items.Clear()
        If File.Exists(".\custom.eldr") = False Then
            System.IO.File.Create(".\custom.eldr").Dispose()
        End If
        Dim customromlist As String() = File.ReadAllLines(".\custom.eldr")
        Try
            Dim myFiles As New List(Of String)
            If main.dark = 1 Or main.dark = 2 Or main.dark = 3 Then
                For Each file As String In My.Computer.FileSystem.GetFiles(".\resources\banners\dark\")
                    myFiles.Add(file)
                Next
            Else
                For Each file As String In My.Computer.FileSystem.GetFiles(".\resources\banners\light\")
                    myFiles.Add(file)
                Next
            End If
            Dim rnd As New Random
            main.panel_banner.BackgroundImage = System.Drawing.Image.FromFile((myFiles(rnd.Next(0, myFiles.Count))))
        Catch ex As Exception
        End Try

        If File.Exists(".\roms\" & main.currenttab_metadata(1) & "\metadata\lastplayed.dat") = False Then
            System.IO.Directory.CreateDirectory(".\roms\" & main.currenttab_metadata(1) & "\metadata\")
            System.IO.File.Create(".\roms\" & main.currenttab_metadata(1) & "\metadata\lastplayed.dat").Dispose()
        End If

        Dim rom_directory As New DirectoryInfo(".\roms\" & main.currenttab_metadata(1))
        Dim platform_id As String = ""

        Select Case main.currenttab_metadata(1)
            Case "GBA"
                For Each f In rom_directory.GetFiles
                    If f.ToString.Contains(".gba") Then
                        main.listbox_installedroms.Items.Add(New ListViewItem(New String() {f.ToString, "GBA", System.IO.Path.GetFullPath(f.FullName)}))
                    ElseIf f.ToString.Contains(".gbc") Then
                        main.listbox_installedroms.Items.Add(New ListViewItem(New String() {f.ToString, "GBC", System.IO.Path.GetFullPath(f.FullName)}))
                    ElseIf f.ToString.Contains(".gb") = True And f.ToString.Contains(".gbc") = False And f.ToString.Contains(".gba") = False Then
                        main.listbox_installedroms.Items.Add(New ListViewItem(New String() {f.ToString, "GB", System.IO.Path.GetFullPath(f.FullName)}))

                    End If
                    If main.global_settings(13).Contains("1") And (f.ToString.Contains(".zip") Or f.ToString.Contains(".7z") Or f.ToString.Contains(".rar")) Then
                        main.listbox_installedroms.Items.Add(New ListViewItem(New String() {f.ToString, "GBA", System.IO.Path.GetFullPath(f.FullName)}))
                    End If
                Next
                Directory.CreateDirectory(".\roms\GBC")
                Dim rom_directory_gbc As New DirectoryInfo(".\roms\GBC\")
                For Each f In rom_directory_gbc.GetFiles
                    If f.ToString.Contains(".gbc") Then
                        main.listbox_installedroms.Items.Add(New ListViewItem(New String() {f.ToString, "GBC", System.IO.Path.GetFullPath(f.FullName)}))
                    ElseIf f.ToString.Contains(".gb") = True And f.ToString.Contains(".gbc") = False And f.ToString.Contains(".gba") = False Then
                        main.listbox_installedroms.Items.Add(New ListViewItem(New String() {f.ToString, "GB", System.IO.Path.GetFullPath(f.FullName)}))
                    End If
                    If main.global_settings(13).Contains("1") And (f.ToString.Contains(".zip") Or f.ToString.Contains(".7z") Or f.ToString.Contains(".rar")) Then
                        main.listbox_installedroms.Items.Add(New ListViewItem(New String() {f.ToString, "GBC", System.IO.Path.GetFullPath(f.FullName)}))
                    End If
                Next
                Directory.CreateDirectory(".\roms\GB")
                Dim rom_directory_gb As New DirectoryInfo(".\roms\GB\")
                For Each f In rom_directory_gb.GetFiles
                    If f.ToString.Contains(".gb") Then
                        main.listbox_installedroms.Items.Add(New ListViewItem(New String() {f.ToString, "GB", System.IO.Path.GetFullPath(f.FullName)}))
                    End If
                    If main.global_settings(13).Contains("1") And (f.ToString.Contains(".zip") Or f.ToString.Contains(".7z") Or f.ToString.Contains(".rar")) Then
                        main.listbox_installedroms.Items.Add(New ListViewItem(New String() {f.ToString, "GB", System.IO.Path.GetFullPath(f.FullName)}))
                    End If
                Next
                For Each custom_directory_entry In customromlist
                    Dim custom_directory As New DirectoryInfo(custom_directory_entry)
                    For Each f In custom_directory.GetFiles
                        If f.ToString.Contains(".gba") Then
                            main.listbox_installedroms.Items.Add(New ListViewItem(New String() {f.ToString, "GBA", System.IO.Path.GetFullPath(f.FullName)}))
                        ElseIf f.ToString.Contains(".gbc") Then
                            main.listbox_installedroms.Items.Add(New ListViewItem(New String() {f.ToString, "GBC", System.IO.Path.GetFullPath(f.FullName)}))
                        ElseIf f.ToString.Contains(".gb") = True And f.ToString.Contains(".gbc") = False And f.ToString.Contains(".gba") = False Then
                            main.listbox_installedroms.Items.Add(New ListViewItem(New String() {f.ToString, "GB", System.IO.Path.GetFullPath(f.FullName)}))
                        End If
                    Next
                Next

            Case "3DS"
                platform_id = "3DS"
                For Each f In rom_directory.GetFiles
                    If f.ToString.Contains(".3ds") Or f.ToString.Contains(".cxi") Or f.ToString.Contains(".cia") Then
                        main.listbox_installedroms.Items.Add(New ListViewItem(New String() {f.ToString, platform_id, System.IO.Path.GetFullPath(f.FullName)}))
                    End If
                    If main.global_settings(13).Contains("1") And (f.ToString.Contains(".zip") Or f.ToString.Contains(".7z") Or f.ToString.Contains(".rar")) Then
                        main.listbox_installedroms.Items.Add(New ListViewItem(New String() {f.ToString, "3DS", System.IO.Path.GetFullPath(f.FullName)}))
                    End If
                Next
                For Each custom_directory_entry In customromlist
                    Dim custom_directory As New DirectoryInfo(custom_directory_entry)
                    For Each f In custom_directory.GetFiles
                        If f.ToString.Contains(".3ds") Or f.ToString.Contains(".cxi") Or f.ToString.Contains(".cia") Then
                            main.listbox_installedroms.Items.Add(New ListViewItem(New String() {f.ToString, platform_id, System.IO.Path.GetFullPath(f.FullName)}))
                        End If
                    Next
                Next

            Case "NDS"
                platform_id = "NDS"
                For Each f In rom_directory.GetFiles
                    If f.ToString.Contains(".nds") Then
                        main.listbox_installedroms.Items.Add(New ListViewItem(New String() {f.ToString, platform_id, System.IO.Path.GetFullPath(f.FullName)}))
                    End If
                    If main.global_settings(13).Contains("1") And (f.ToString.Contains(".zip") Or f.ToString.Contains(".7z") Or f.ToString.Contains(".rar")) Then
                        main.listbox_installedroms.Items.Add(New ListViewItem(New String() {f.ToString, "NDS", System.IO.Path.GetFullPath(f.FullName)}))
                    End If
                Next
                For Each custom_directory_entry In customromlist
                    Dim custom_directory As New DirectoryInfo(custom_directory_entry)
                    For Each f In custom_directory.GetFiles
                        If f.ToString.Contains(".nds") Then
                            main.listbox_installedroms.Items.Add(New ListViewItem(New String() {f.ToString, platform_id, System.IO.Path.GetFullPath(f.FullName)}))
                        End If
                    Next
                Next

            Case "N64"
                platform_id = "N64"
                For Each f In rom_directory.GetFiles
                    If f.ToString.Contains(".z64") Or f.ToString.Contains(".v64") Or f.ToString.Contains(".m64") Then
                        main.listbox_installedroms.Items.Add(New ListViewItem(New String() {f.ToString, platform_id, System.IO.Path.GetFullPath(f.FullName)}))
                    End If
                    If main.global_settings(13).Contains("1") And (f.ToString.Contains(".zip") Or f.ToString.Contains(".7z") Or f.ToString.Contains(".rar")) Then
                        main.listbox_installedroms.Items.Add(New ListViewItem(New String() {f.ToString, "N64", System.IO.Path.GetFullPath(f.FullName)}))
                    End If
                Next
                For Each custom_directory_entry In customromlist
                    Dim custom_directory As New DirectoryInfo(custom_directory_entry)
                    For Each f In custom_directory.GetFiles
                        If f.ToString.Contains(".z64") Or f.ToString.Contains(".v64") Or f.ToString.Contains(".m64") Then

                            main.listbox_installedroms.Items.Add(New ListViewItem(New String() {f.ToString, platform_id, System.IO.Path.GetFullPath(f.FullName)}))
                        End If
                    Next
                Next

            Case "PSP"
                platform_id = "PSP"
                For Each f In rom_directory.GetFiles
                    If f.ToString.Contains(".iso") Then
                        main.listbox_installedroms.Items.Add(New ListViewItem(New String() {f.ToString, platform_id, System.IO.Path.GetFullPath(f.FullName)}))
                    End If
                    If main.global_settings(13).Contains("1") And (f.ToString.Contains(".zip") Or f.ToString.Contains(".7z") Or f.ToString.Contains(".rar")) Then
                        main.listbox_installedroms.Items.Add(New ListViewItem(New String() {f.ToString, "PSP", System.IO.Path.GetFullPath(f.FullName)}))
                    End If
                Next
                For Each custom_directory_entry In customromlist
                    Dim custom_directory As New DirectoryInfo(custom_directory_entry)
                    For Each f In custom_directory.GetFiles
                        If f.ToString.Contains(".iso") Or f.ToString.Contains(".cso") Then
                            main.listbox_installedroms.Items.Add(New ListViewItem(New String() {f.ToString, platform_id, System.IO.Path.GetFullPath(f.FullName)}))
                        End If
                    Next
                Next

            Case "WII"
                platform_id = "WII"
                For Each f In rom_directory.GetFiles
                    If f.ToString.Contains(".iso") Then
                        main.listbox_installedroms.Items.Add(New ListViewItem(New String() {f.ToString, platform_id, System.IO.Path.GetFullPath(f.FullName)}))
                    End If
                    If main.global_settings(13).Contains("1") And (f.ToString.Contains(".zip") Or f.ToString.Contains(".7z") Or f.ToString.Contains(".rar")) Then
                        main.listbox_installedroms.Items.Add(New ListViewItem(New String() {f.ToString, "WII", System.IO.Path.GetFullPath(f.FullName)}))
                    End If
                Next
                For Each custom_directory_entry In customromlist
                    Dim custom_directory As New DirectoryInfo(custom_directory_entry)
                    For Each f In custom_directory.GetFiles
                        If f.ToString.Contains(".iso") Or f.ToString.Contains(".elf") Then
                            main.listbox_installedroms.Items.Add(New ListViewItem(New String() {f.ToString, platform_id, System.IO.Path.GetFullPath(f.FullName)}))
                        End If
                    Next
                Next
                Directory.CreateDirectory(".\roms\GC")
                Dim rom_directory_gc As New DirectoryInfo(".\roms\GC\")
                For Each f In rom_directory_gc.GetFiles
                    If f.ToString.Contains(".iso") Then
                        main.listbox_installedroms.Items.Add(New ListViewItem(New String() {f.ToString, "GC", System.IO.Path.GetFullPath(f.FullName)}))
                    End If
                    If main.global_settings(13).Contains("1") And (f.ToString.Contains(".zip") Or f.ToString.Contains(".7z") Or f.ToString.Contains(".rar")) Then
                        main.listbox_installedroms.Items.Add(New ListViewItem(New String() {f.ToString, "GC", System.IO.Path.GetFullPath(f.FullName)}))
                    End If
                Next

            Case "WIIU"
                platform_id = "WIIU"
                Dim rom_directory_wiiU = IO.Directory.GetFiles(".\roms\" & main.currenttab_metadata(1), "*.rpx", IO.SearchOption.AllDirectories)
                For Each f In rom_directory_wiiU
                    Dim fullpath As String = System.IO.Path.GetFullPath(f)
                    Dim filepath As String = fullpath.Replace(System.IO.Path.GetFullPath(".\roms\" & main.currenttab_metadata(1)), "")
                    Dim filename As String() = filepath.Split("\")
                    main.listbox_installedroms.Items.Add(New ListViewItem(New String() {filename(1), platform_id, f}))
                Next
                For Each custom_directory_entry In customromlist
                    Try
                        Dim rom_directory_wiiU2 = IO.Directory.GetFiles(custom_directory_entry, "*.rpx", IO.SearchOption.AllDirectories)
                        For Each f In rom_directory_wiiU2
                            Dim fullpath As String = System.IO.Path.GetFullPath(f)
                            Dim filepath As String = fullpath.Replace(custom_directory_entry, "")
                            Dim filename As String() = filepath.Split("\")
                            main.listbox_installedroms.Items.Add(New ListViewItem(New String() {filename(1), platform_id, f}))
                        Next
                    Catch ex As Exception
                    End Try
                Next

            Case "SNES"
                platform_id = "SNES"
                For Each f In rom_directory.GetFiles
                    If f.ToString.Contains(".smc") Or f.ToString.Contains(".sfc") Or f.ToString.Contains(".bin") Then
                        main.listbox_installedroms.Items.Add(New ListViewItem(New String() {f.ToString, platform_id, System.IO.Path.GetFullPath(f.FullName)}))
                    End If
                    If main.global_settings(13).Contains("1") And (f.ToString.Contains(".zip") Or f.ToString.Contains(".7z") Or f.ToString.Contains(".rar")) Then
                        main.listbox_installedroms.Items.Add(New ListViewItem(New String() {f.ToString, "SNES", System.IO.Path.GetFullPath(f.FullName)}))
                    End If
                Next
                For Each custom_directory_entry In customromlist
                    Dim custom_directory As New DirectoryInfo(custom_directory_entry)
                    For Each f In custom_directory.GetFiles
                        If f.ToString.Contains(".smc") Or f.ToString.Contains(".sfc") Or f.ToString.Contains(".bin") Then
                            main.listbox_installedroms.Items.Add(New ListViewItem(New String() {f.ToString, platform_id, System.IO.Path.GetFullPath(f.FullName)}))
                        End If
                    Next
                Next

            Case "NES"
                platform_id = "NES"
                For Each f In rom_directory.GetFiles
                    If f.ToString.Contains(".nes") Then
                        main.listbox_installedroms.Items.Add(New ListViewItem(New String() {f.ToString, platform_id, System.IO.Path.GetFullPath(f.FullName)}))
                    End If
                    If main.global_settings(13).Contains("1") And (f.ToString.Contains(".zip") Or f.ToString.Contains(".7z") Or f.ToString.Contains(".rar")) Then
                        main.listbox_installedroms.Items.Add(New ListViewItem(New String() {f.ToString, "NES", System.IO.Path.GetFullPath(f.FullName)}))
                    End If
                Next
                For Each custom_directory_entry In customromlist
                    Dim custom_directory As New DirectoryInfo(custom_directory_entry)
                    For Each f In custom_directory.GetFiles
                        If f.ToString.Contains(".nes") Then
                            main.listbox_installedroms.Items.Add(New ListViewItem(New String() {f.ToString, platform_id, System.IO.Path.GetFullPath(f.FullName)}))
                        End If
                    Next
                Next

            Case "PSX"
                platform_id = "PSX"
                For Each f In rom_directory.GetFiles
                    If f.ToString.Contains(".bin") Or f.ToString.Contains(".img") Or f.ToString.Contains(".iso") Then
                        main.listbox_installedroms.Items.Add(New ListViewItem(New String() {f.ToString, platform_id, System.IO.Path.GetFullPath(f.FullName)}))
                    End If
                    If main.global_settings(13).Contains("1") And (f.ToString.Contains(".zip") Or f.ToString.Contains(".7z") Or f.ToString.Contains(".rar")) Then
                        main.listbox_installedroms.Items.Add(New ListViewItem(New String() {f.ToString, "PSX", System.IO.Path.GetFullPath(f.FullName)}))
                    End If
                Next
                For Each custom_directory_entry In customromlist
                    Dim custom_directory As New DirectoryInfo(custom_directory_entry)
                    For Each f In custom_directory.GetFiles
                        If f.ToString.Contains(".img") Or f.ToString.Contains(".iso") Or f.ToString.Contains(".bin") Then
                            main.listbox_installedroms.Items.Add(New ListViewItem(New String() {f.ToString, platform_id, System.IO.Path.GetFullPath(f.FullName)}))
                        End If
                    Next
                Next

            Case "MGD"
                platform_id = "MGD"
                For Each f In rom_directory.GetFiles
                    If f.ToString.Contains(".md") Or f.ToString.Contains(".gen") Or f.ToString.Contains(".bin") Then
                        main.listbox_installedroms.Items.Add(New ListViewItem(New String() {f.ToString, platform_id, System.IO.Path.GetFullPath(f.FullName)}))
                    End If
                    If main.global_settings(13).Contains("1") And (f.ToString.Contains(".zip") Or f.ToString.Contains(".7z") Or f.ToString.Contains(".rar")) Then
                        main.listbox_installedroms.Items.Add(New ListViewItem(New String() {f.ToString, "MGD", System.IO.Path.GetFullPath(f.FullName)}))
                    End If
                Next
                For Each custom_directory_entry In customromlist
                    Dim custom_directory As New DirectoryInfo(custom_directory_entry)
                    For Each f In custom_directory.GetFiles
                        If f.ToString.Contains(".md") Or f.ToString.Contains(".gen") Or f.ToString.Contains(".bin") Then
                            main.listbox_installedroms.Items.Add(New ListViewItem(New String() {f.ToString, platform_id, System.IO.Path.GetFullPath(f.FullName)}))
                        End If
                    Next
                Next

            Case "DC"
                platform_id = "DC"
                For Each f In rom_directory.GetFiles
                    If f.ToString.Contains(".gdi") Or f.ToString.Contains(".cdi") Or f.ToString.Contains(".chd") Then
                        main.listbox_installedroms.Items.Add(New ListViewItem(New String() {f.ToString, platform_id, System.IO.Path.GetFullPath(f.FullName)}))
                    End If
                    If main.global_settings(13).Contains("1") And (f.ToString.Contains(".zip") Or f.ToString.Contains(".7z") Or f.ToString.Contains(".rar")) Then
                        main.listbox_installedroms.Items.Add(New ListViewItem(New String() {f.ToString, "DC", System.IO.Path.GetFullPath(f.FullName)}))
                    End If
                Next
                For Each custom_directory_entry In customromlist
                    Dim custom_directory As New DirectoryInfo(custom_directory_entry)
                    For Each f In custom_directory.GetFiles
                        If f.ToString.Contains(".gdi") Or f.ToString.Contains(".cdi") Or f.ToString.Contains(".ghd") Then
                            main.listbox_installedroms.Items.Add(New ListViewItem(New String() {f.ToString, platform_id, System.IO.Path.GetFullPath(f.FullName)}))
                        End If
                    Next
                Next

            Case "PS2"
                platform_id = "PS2"
                For Each f In rom_directory.GetFiles
                    If f.ToString.Contains(".iso") Or f.ToString.Contains(".bin") Then
                        main.listbox_installedroms.Items.Add(New ListViewItem(New String() {f.ToString, platform_id, System.IO.Path.GetFullPath(f.FullName)}))
                    End If
                    If main.global_settings(13).Contains("1") And (f.ToString.Contains(".zip") Or f.ToString.Contains(".7z") Or f.ToString.Contains(".rar")) Then
                        main.listbox_installedroms.Items.Add(New ListViewItem(New String() {f.ToString, "PS2", System.IO.Path.GetFullPath(f.FullName)}))
                    End If
                Next
                For Each custom_directory_entry In customromlist
                    Dim custom_directory As New DirectoryInfo(custom_directory_entry)
                    For Each f In custom_directory.GetFiles
                        If f.ToString.Contains(".iso") Or f.ToString.Contains(".bin") Then
                            main.listbox_installedroms.Items.Add(New ListViewItem(New String() {f.ToString, platform_id, System.IO.Path.GetFullPath(f.FullName)}))
                        End If
                    Next
                Next

            Case "SWH"
                platform_id = "SWH"
                For Each f In rom_directory.GetFiles
                    If f.ToString.Contains(".xci") Or f.ToString.Contains(".nsp") Then
                        main.listbox_installedroms.Items.Add(New ListViewItem(New String() {f.ToString, platform_id, System.IO.Path.GetFullPath(f.FullName)}))
                    End If
                    If main.global_settings(13).Contains("1") And (f.ToString.Contains(".zip") Or f.ToString.Contains(".7z") Or f.ToString.Contains(".rar")) Then
                        main.listbox_installedroms.Items.Add(New ListViewItem(New String() {f.ToString, "SWH", System.IO.Path.GetFullPath(f.FullName)}))
                    End If
                Next
                For Each custom_directory_entry In customromlist
                    Dim custom_directory As New DirectoryInfo(custom_directory_entry)
                    For Each f In custom_directory.GetFiles
                        If f.ToString.Contains(".xci") Or f.ToString.Contains(".nsp") Then
                            main.listbox_installedroms.Items.Add(New ListViewItem(New String() {f.ToString, platform_id, System.IO.Path.GetFullPath(f.FullName)}))
                        End If
                    Next
                Next
            Case "STN"
                platform_id = "STN"
                Dim rom_directory_wiiU = IO.Directory.GetFiles(".\roms\" & main.currenttab_metadata(1), "*.cue", IO.SearchOption.AllDirectories)
                For Each f In rom_directory_wiiU
                    Dim fullpath As String = System.IO.Path.GetFullPath(f)
                    Dim filepath As String = fullpath.Replace(System.IO.Path.GetFullPath(".\roms\" & main.currenttab_metadata(1)), "")
                    Dim filename As String() = filepath.Split("\")
                    main.listbox_installedroms.Items.Add(New ListViewItem(New String() {filename(1), platform_id, f}))
                Next
                For Each custom_directory_entry In customromlist
                    Try
                        Dim rom_directory_wiiU2 = IO.Directory.GetFiles(custom_directory_entry, "*.cue", IO.SearchOption.AllDirectories)
                        For Each f In rom_directory_wiiU2
                            Dim fullpath As String = System.IO.Path.GetFullPath(f)
                            Dim filepath As String = fullpath.Replace(custom_directory_entry, "")
                            Dim filename As String() = filepath.Split("\")
                            main.listbox_installedroms.Items.Add(New ListViewItem(New String() {filename(1), platform_id, f}))
                        Next
                    Catch ex As Exception
                    End Try
                Next
        End Select
        Call main.retrieveboxart()
        If main.listbox_installedroms.Items.Count = 0 Then
            main.listbox_installedroms.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)
        Else
            main.listbox_installedroms.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent)
        End If
        main.listbox_installedroms.Columns.Item(2).Width = 0
        main.listbox_installedroms.AutoResizeColumn(1, ColumnHeaderAutoResizeStyle.HeaderSize)

        If main.checkbox_extensions.Checked = False Then
            For Each item In main.listbox_installedroms.Items
                Dim fullname As String() = (item.subitems(0).text).split(".")
                item.subitems(0).text = fullname(0)
            Next
        End If

        If Not main.listbox_installedroms.Items.Count = 0 Then
            main.listbox_installedroms.Items(0).Selected = True
            main.listbox_installedroms.FocusedItem = main.listbox_installedroms.Items(0)
            Call main.listbox_installedroms_SelectedIndexChanged(Nothing, EventArgs.Empty)
        End If
    End Sub

    Public Sub loadconfig()
        If File.Exists(".\installed.eldr") = True Then
            Dim installedeldr As String() = File.ReadAllLines(".\installed.eldr")
            Dim index As Integer = 0
            Dim emutabs = {main.emu_one, main.emu_two, main.emu_three, main.emu_four, main.emu_five, main.emu_six, main.emu_seven, main.emu_eight, main.emu_nine}
            For Each eldr_entry In installedeldr
                Dim currentmetadata As String()
                If eldr_entry.Contains("VBAM") Then
                    emutabs(index).Text = "VBA-M"
                    emutabs(index).Visible = True
                    currentmetadata = File.ReadAllLines(".\" & eldr_entry & "\vbam.eldr")
                ElseIf eldr_entry.Contains("CITRA") Then
                    emutabs(index).Text = "Citra"
                    emutabs(index).Visible = True
                    currentmetadata = File.ReadAllLines(".\" & eldr_entry & "\citra.eldr")
                ElseIf eldr_entry.Contains("DESMUME") Then
                    emutabs(index).Text = "DeSmuME"
                    emutabs(index).Visible = True
                    currentmetadata = File.ReadAllLines(".\" & eldr_entry & "\desmume.eldr")
                ElseIf eldr_entry.Contains("PROJECT64") Then
                    emutabs(index).Text = "Project64"
                    emutabs(index).Visible = True
                    currentmetadata = File.ReadAllLines(".\" & eldr_entry & "\project64.eldr")
                ElseIf eldr_entry.Contains("PPSSPP") Then
                    emutabs(index).Text = "PPSSPP"
                    emutabs(index).Visible = True
                    currentmetadata = File.ReadAllLines(".\" & eldr_entry & "\ppsspp.eldr")
                ElseIf eldr_entry.Contains("DOLPHIN") Then
                    emutabs(index).Text = "Dolphin"
                    emutabs(index).Visible = True
                    currentmetadata = File.ReadAllLines(".\" & eldr_entry & "\dolphin.eldr")
                ElseIf eldr_entry.Contains("CEMU") Then
                    emutabs(index).Text = "Cemu"
                    emutabs(index).Visible = True
                    currentmetadata = File.ReadAllLines(".\" & eldr_entry & "\cemu.eldr")
                ElseIf eldr_entry.Contains("SNES9X") Then
                    emutabs(index).Text = "Snes9x"
                    emutabs(index).Visible = True
                    currentmetadata = File.ReadAllLines(".\" & eldr_entry & "\snes9x.eldr")
                ElseIf eldr_entry.Contains("MESEN") Then
                    emutabs(index).Text = "Mesen"
                    emutabs(index).Visible = True
                    currentmetadata = File.ReadAllLines(".\" & eldr_entry & "\mesen.eldr")
                ElseIf eldr_entry.Contains("EPSXE") Then
                    emutabs(index).Text = "ePSXe"
                    emutabs(index).Visible = True
                    currentmetadata = File.ReadAllLines(".\" & eldr_entry & "\epsxe.eldr")
                ElseIf eldr_entry.Contains("FUSION") Then
                    emutabs(index).Text = "Fusion"
                    emutabs(index).Visible = True
                    currentmetadata = File.ReadAllLines(".\" & eldr_entry & "\fusion.eldr")
                ElseIf eldr_entry.Contains("REDREAM") Then
                    emutabs(index).Text = "Redream"
                    emutabs(index).Visible = True
                    currentmetadata = File.ReadAllLines(".\" & eldr_entry & "\redream.eldr")
                ElseIf eldr_entry.Contains("PCSX2") Then
                    emutabs(index).Text = "PCSX2"
                    emutabs(index).Visible = True
                    currentmetadata = File.ReadAllLines(".\" & eldr_entry & "\pcsx2.eldr")
                ElseIf eldr_entry.Contains("YUZU") Then
                    emutabs(index).Text = "yuzu"
                    emutabs(index).Visible = True
                    currentmetadata = File.ReadAllLines(".\" & eldr_entry & "\yuzu.eldr")
                ElseIf eldr_entry.Contains("DUCKSTATION") Then
                    emutabs(index).Text = "DuckStation"
                    emutabs(index).Visible = True
                    currentmetadata = File.ReadAllLines(".\" & eldr_entry & "\duckstation.eldr")
                ElseIf eldr_entry.Contains("MELONDS") Then
                    emutabs(index).Text = "melonDS"
                    emutabs(index).Visible = True
                    currentmetadata = File.ReadAllLines(".\" & eldr_entry & "\melonds.eldr")
                ElseIf eldr_entry.Contains("KRONOS") Then
                    emutabs(index).Text = "Kronos"
                    emutabs(index).Visible = True
                    currentmetadata = File.ReadAllLines(".\" & eldr_entry & "\kronos.eldr")
                ElseIf eldr_entry.Contains("MGBA") Then
                    emutabs(index).Text = "mGBA"
                    emutabs(index).Visible = True
                    currentmetadata = File.ReadAllLines(".\" & eldr_entry & "\mgba.eldr")
                End If
                emu_tab_metadata_list.emutabs_metadata(index) = currentmetadata
                index = index + 1
            Next
        End If
    End Sub
End Module
