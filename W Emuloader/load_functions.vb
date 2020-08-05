﻿Imports System.IO

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
                For Each file As String In My.Computer.FileSystem.GetFiles(".\resources\banners\dark\" & main.currenttab_metadata(1))
                    myFiles.Add(file)
                Next
            Else
                For Each file As String In My.Computer.FileSystem.GetFiles(".\resources\banners\light\" & main.currenttab_metadata(1))
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
                Next
                Directory.CreateDirectory(".\roms\GBC")
                Dim rom_directory_gbc As New DirectoryInfo(".\roms\GBC\")
                For Each f In rom_directory_gbc.GetFiles
                    If f.ToString.Contains(".gbc") Then
                        main.listbox_installedroms.Items.Add(New ListViewItem(New String() {f.ToString, "GBC", System.IO.Path.GetFullPath(f.FullName)}))
                    ElseIf f.ToString.Contains(".gb") = True And f.ToString.Contains(".gbc") = False And f.ToString.Contains(".gba") = False Then
                        main.listbox_installedroms.Items.Add(New ListViewItem(New String() {f.ToString, "GB", System.IO.Path.GetFullPath(f.FullName)}))
                    End If
                Next
                Directory.CreateDirectory(".\roms\GB")
                Dim rom_directory_gb As New DirectoryInfo(".\roms\GB\")
                For Each f In rom_directory_gb.GetFiles
                    If f.ToString.Contains(".gb") Then
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
                    If f.ToString.Contains("XT") Then
                    ElseIf f.ToString.Contains(".iso") Then
                        main.listbox_installedroms.Items.Add(New ListViewItem(New String() {f.ToString, platform_id, System.IO.Path.GetFullPath(f.FullName)}))
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

        End Select
        If main.currenttab_metadata(1) = "PSX" Then
            For Each f In rom_directory.GetFiles
                If f.ToString.Contains("XT") Then
                ElseIf f.ToString.Contains(".bin") Or f.ToString.Contains(".img") Or f.ToString.Contains(".iso") Then
                    main.listbox_installedroms.Items.Add(New ListViewItem(New String() {f.ToString.Replace(".iso", "").Replace(".img", "").Replace(".bin", ""), "PSX", System.IO.Path.GetFullPath(f.FullName)}))
                End If

            Next

            For Each x In customromlist
                Dim custom_directory As New DirectoryInfo(x)
                For Each f In custom_directory.GetFiles
                    If f.ToString.Contains(".img") Or f.ToString.Contains(".iso") Or f.ToString.Contains(".bin") Then

                        main.listbox_installedroms.Items.Add(New ListViewItem(New String() {f.ToString.Replace(".img", "").Replace(".iso", "").Replace(".bin", ""), "PSX", System.IO.Path.GetFullPath(f.FullName)}))
                    End If

                Next
            Next
        ElseIf main.currenttab_metadata(1) = "MGD" Then
            For Each f In rom_directory.GetFiles
                If f.ToString.Contains(".md") Or f.ToString.Contains(".gen") Or f.ToString.Contains(".bin") Then
                    main.listbox_installedroms.Items.Add(New ListViewItem(New String() {f.ToString.Replace(".gen", "").Replace(".md", "").Replace(".bin", ""), "MGD", System.IO.Path.GetFullPath(f.FullName)}))
                End If

            Next

            For Each x In customromlist
                Dim custom_directory As New DirectoryInfo(x)
                For Each f In custom_directory.GetFiles
                    If f.ToString.Contains(".md") Or f.ToString.Contains(".gen") Or f.ToString.Contains(".bin") Then

                        main.listbox_installedroms.Items.Add(New ListViewItem(New String() {f.ToString.Replace(".gen", "").Replace(".md", "").Replace(".bin", ""), "MGD", System.IO.Path.GetFullPath(f.FullName)}))
                    End If

                Next
            Next
        ElseIf main.currenttab_metadata(1) = "DC" Then
            For Each f In rom_directory.GetFiles
                If f.ToString.Contains("XT") Then
                ElseIf f.ToString.Contains(".gdi") Or f.ToString.Contains(".cdi") Or f.ToString.Contains(".chd") Then
                    main.listbox_installedroms.Items.Add(New ListViewItem(New String() {f.ToString.Replace(".gdi", "").Replace(".cdi", "").Replace(".chd", ""), "DC", System.IO.Path.GetFullPath(f.FullName)}))
                End If

            Next

            For Each x In customromlist
                Dim custom_directory As New DirectoryInfo(x)
                For Each f In custom_directory.GetFiles
                    If f.ToString.Contains(".gdi") Or f.ToString.Contains(".cdi") Or f.ToString.Contains(".ghd") Then

                        main.listbox_installedroms.Items.Add(New ListViewItem(New String() {f.ToString.Replace(".gdi", "").Replace(".cdi", "").Replace(".ghd", ""), "DC", System.IO.Path.GetFullPath(f.FullName)}))
                    End If

                Next
            Next
        ElseIf main.currenttab_metadata(1) = "PS2" Then
            For Each f In rom_directory.GetFiles
                If f.ToString.Contains("XT") Then
                ElseIf f.ToString.Contains(".iso") Or f.ToString.Contains(".bin") Then
                    main.listbox_installedroms.Items.Add(New ListViewItem(New String() {f.ToString.Replace(".iso", "").Replace(".bin", ""), "PS2", System.IO.Path.GetFullPath(f.FullName)}))
                End If

            Next

            For Each x In customromlist
                Dim custom_directory As New DirectoryInfo(x)
                For Each f In custom_directory.GetFiles
                    If f.ToString.Contains(".iso") Or f.ToString.Contains(".bin") Then

                        main.listbox_installedroms.Items.Add(New ListViewItem(New String() {f.ToString.Replace(".iso", "").Replace(".bin", ""), "PS2", System.IO.Path.GetFullPath(f.FullName)}))
                    End If

                Next
            Next
        End If

        Call main.retrieveboxart()





        If main.listbox_installedroms.Items.Count = 0 Then
            main.listbox_installedroms.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)

        Else
            main.listbox_installedroms.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent)
        End If
        main.listbox_installedroms.Columns.Item(2).Width = 0
        main.listbox_installedroms.AutoResizeColumn(1, ColumnHeaderAutoResizeStyle.HeaderSize)
    End Sub

    Public Sub loadconfig()
        If File.Exists(".\installed.eldr") = True Then
            Dim installedeldr As String() = File.ReadAllLines(".\installed.eldr")
            Dim index As Integer = 0
            Dim emutabs = {main.emu_one, main.emu_two, main.emu_three, main.emu_four, main.emu_five, main.emu_six, main.emu_seven, main.emu_eight, main.emu_nine}

            For Each x In installedeldr
                Dim currentmetadata As String()
                If x.Contains("VBAM") Then
                    emutabs(index).Text = "VBA-M"
                    emutabs(index).Visible = True
                    currentmetadata = File.ReadAllLines(".\" & x & "\vbam.eldr")
                End If

                If x.Contains("CITRA") Then
                    emutabs(index).Text = "Citra"
                    emutabs(index).Visible = True
                    currentmetadata = File.ReadAllLines(".\" & x & "\citra.eldr")
                End If
                If x.Contains("DESMUME") Then
                    emutabs(index).Text = "DeSmuME"
                    emutabs(index).Visible = True
                    currentmetadata = File.ReadAllLines(".\" & x & "\desmume.eldr")
                End If
                If x.Contains("PROJECT64") Then
                    emutabs(index).Text = "Project64"
                    emutabs(index).Visible = True
                    currentmetadata = File.ReadAllLines(".\" & x & "\project64.eldr")
                End If
                If x.Contains("PPSSPP") Then
                    emutabs(index).Text = "PPSSPP"
                    emutabs(index).Visible = True
                    currentmetadata = File.ReadAllLines(".\" & x & "\ppsspp.eldr")
                End If
                If x.Contains("DOLPHIN") Then
                    emutabs(index).Text = "Dolphin"
                    emutabs(index).Visible = True
                    currentmetadata = File.ReadAllLines(".\" & x & "\dolphin.eldr")
                End If
                If x.Contains("CEMU") Then
                    emutabs(index).Text = "Cemu"
                    emutabs(index).Visible = True
                    currentmetadata = File.ReadAllLines(".\" & x & "\cemu.eldr")
                End If
                If x.Contains("SNES9X") Then
                    emutabs(index).Text = "Snes9x"
                    emutabs(index).Visible = True
                    currentmetadata = File.ReadAllLines(".\" & x & "\snes9x.eldr")
                End If
                If x.Contains("MESEN") Then
                    emutabs(index).Text = "Mesen"
                    emutabs(index).Visible = True
                    currentmetadata = File.ReadAllLines(".\" & x & "\mesen.eldr")
                End If
                If x.Contains("EPSXE") Then
                    emutabs(index).Text = "ePSXe"
                    emutabs(index).Visible = True
                    currentmetadata = File.ReadAllLines(".\" & x & "\epsxe.eldr")
                End If
                If x.Contains("FUSION") Then
                    emutabs(index).Text = "Fusion"
                    emutabs(index).Visible = True
                    currentmetadata = File.ReadAllLines(".\" & x & "\fusion.eldr")
                End If
                If x.Contains("REDREAM") Then
                    emutabs(index).Text = "Redream"
                    emutabs(index).Visible = True
                    currentmetadata = File.ReadAllLines(".\" & x & "\redream.eldr")
                End If
                If x.Contains("PCSX2") Then
                    emutabs(index).Text = "PCSX2"
                    emutabs(index).Visible = True
                    currentmetadata = File.ReadAllLines(".\" & x & "\pcsx2.eldr")
                End If
                emu_tab_metadata_list.emutabs_metadata(index) = currentmetadata
                index = index + 1
            Next

        End If
    End Sub
End Module
