Imports System.IO

Module load_functions
    Public Sub load_installed_roms()
        main.listbox_installedroms.Items.Clear()
        If File.Exists(".\custom.eldr") = False Then
            System.IO.File.Create(".\custom.eldr").Dispose()
        End If

        Dim customromlist As String() = File.ReadAllLines(".\custom.eldr")


        If Directory.Exists(".\roms\" & main.currenttab_metadata(1)) = False Then
            Directory.CreateDirectory(".\roms\" & main.currenttab_metadata(1))
        End If
        Dim rom_directory As New DirectoryInfo(".\roms\" & main.currenttab_metadata(1))

        If main.currenttab_metadata(1) = "GBA" Then

            For Each f In rom_directory.GetFiles
                If f.ToString.Contains("sav") Then

                ElseIf f.ToString.Contains(".gba") Then
                    main.listbox_installedroms.Items.Add(New ListViewItem(New String() {f.ToString.Replace(".gba", ""), "GBA", System.IO.Path.GetFullPath(f.FullName)}))

                ElseIf f.ToString.Contains(".gbc") Then
                    main.listbox_installedroms.Items.Add(New ListViewItem(New String() {f.ToString.Replace(".gbc", ""), "GBC", System.IO.Path.GetFullPath(f.FullName)}))

                ElseIf f.ToString.Contains(".gb") = True And f.ToString.Contains(".gbc") = False And f.ToString.Contains(".gba") = False Then
                    main.listbox_installedroms.Items.Add(New ListViewItem(New String() {f.ToString.Replace(".gb", ""), "GB", System.IO.Path.GetFullPath(f.FullName)}))
                End If

            Next

            If Directory.Exists(".\roms\GBC") = False Then
                Directory.CreateDirectory(".\roms\GBC")
            End If
            Dim rom_directory2 As New DirectoryInfo(".\roms\GBC\")
            For Each f In rom_directory2.GetFiles
                If f.ToString.Contains("XT") Then
                ElseIf f.ToString.Contains(".gbc") Then
                    main.listbox_installedroms.Items.Add(New ListViewItem(New String() {f.ToString.Replace(".gbc", ""), "GBC", System.IO.Path.GetFullPath(f.FullName)}))
                ElseIf f.ToString.Contains(".gb") = True And f.ToString.Contains(".gbc") = False And f.ToString.Contains(".gba") = False Then
                    main.listbox_installedroms.Items.Add(New ListViewItem(New String() {f.ToString.Replace(".gb", ""), "GB", System.IO.Path.GetFullPath(f.FullName)}))
                End If

            Next

            If Directory.Exists(".\roms\GB") = False Then
                Directory.CreateDirectory(".\roms\GB")
            End If
            Dim rom_directory3 As New DirectoryInfo(".\roms\GB\")
            For Each f In rom_directory3.GetFiles
                If f.ToString.Contains("XT") Then
                ElseIf f.ToString.Contains(".gb") Then
                    main.listbox_installedroms.Items.Add(New ListViewItem(New String() {f.ToString.Replace(".gb", ""), "GB", System.IO.Path.GetFullPath(f.FullName)}))
                End If

            Next

            For Each x In customromlist
                Dim custom_directory As New DirectoryInfo(x)
                For Each f In custom_directory.GetFiles
                    If f.ToString.Contains(".gba") Then
                        main.listbox_installedroms.Items.Add(New ListViewItem(New String() {f.ToString.Replace(".gba", ""), "GBA", System.IO.Path.GetFullPath(f.FullName)}))
                    ElseIf f.ToString.Contains(".gbc") Then
                        main.listbox_installedroms.Items.Add(New ListViewItem(New String() {f.ToString.Replace(".gbc", ""), "GBC", System.IO.Path.GetFullPath(f.FullName)}))

                    ElseIf f.ToString.Contains(".gb") = True And f.ToString.Contains(".gbc") = False And f.ToString.Contains(".gba") = False Then
                        main.listbox_installedroms.Items.Add(New ListViewItem(New String() {f.ToString.Replace(".gb", ""), "GB", System.IO.Path.GetFullPath(f.FullName)}))
                    End If

                Next
            Next



        ElseIf main.currenttab_metadata(1) = "3DS" Then
            For Each f In rom_directory.GetFiles
                If f.ToString.Contains("XT") Then
                ElseIf f.ToString.Contains(".3ds") Or f.ToString.Contains(".cxi") Or f.ToString.Contains(".cia") Then
                    main.listbox_installedroms.Items.Add(New ListViewItem(New String() {f.ToString.Replace(".3ds", "").ToString.Replace(".cia", "").ToString.Replace(".cxi", ""), "3DS", System.IO.Path.GetFullPath(f.FullName)}))
                End If

            Next

            For Each x In customromlist
                Dim custom_directory As New DirectoryInfo(x)
                For Each f In custom_directory.GetFiles
                    If f.ToString.Contains(".3ds") Or f.ToString.Contains(".cxi") Or f.ToString.Contains(".cia") Then

                        main.listbox_installedroms.Items.Add(New ListViewItem(New String() {f.ToString.Replace(".3ds", "").ToString.Replace(".cia", "").ToString.Replace(".cxi", ""), "3DS", System.IO.Path.GetFullPath(f.FullName)}))
                    End If

                Next
            Next
        ElseIf main.currenttab_metadata(1) = "NDS" Then
            For Each f In rom_directory.GetFiles
                If f.ToString.Contains("XT") Then
                ElseIf f.ToString.Contains(".nds") Then
                    main.listbox_installedroms.Items.Add(New ListViewItem(New String() {f.ToString.Replace(".nds", ""), "NDS", System.IO.Path.GetFullPath(f.FullName)}))
                End If

            Next

            For Each x In customromlist
                Dim custom_directory As New DirectoryInfo(x)
                For Each f In custom_directory.GetFiles
                    If f.ToString.Contains(".nds") Then

                        main.listbox_installedroms.Items.Add(New ListViewItem(New String() {f.ToString.Replace(".nds", ""), "NDS", System.IO.Path.GetFullPath(f.FullName)}))
                    End If

                Next
            Next
        ElseIf main.currenttab_metadata(1) = "N64" Then
            For Each f In rom_directory.GetFiles
                If f.ToString.Contains("XT") Then
                ElseIf f.ToString.Contains(".z64") Or f.ToString.Contains(".v64") Or f.ToString.Contains(".m64") Then
                    main.listbox_installedroms.Items.Add(New ListViewItem(New String() {f.ToString.Replace(".z64", "").Replace(".v64", "").Replace(".n64", ""), "N64", System.IO.Path.GetFullPath(f.FullName)}))
                End If

            Next

            For Each x In customromlist
                Dim custom_directory As New DirectoryInfo(x)
                For Each f In custom_directory.GetFiles
                    If f.ToString.Contains(".z64") Or f.ToString.Contains(".v64") Or f.ToString.Contains(".m64") Then

                        main.listbox_installedroms.Items.Add(New ListViewItem(New String() {f.ToString.Replace(".z64", "").Replace(".v64", "").Replace(".n64", ""), "N64", System.IO.Path.GetFullPath(f.FullName)}))
                    End If

                Next
            Next
        ElseIf main.currenttab_metadata(1) = "PSP" Then
            For Each f In rom_directory.GetFiles
                If f.ToString.Contains("XT") Then
                ElseIf f.ToString.Contains(".iso") Then
                    main.listbox_installedroms.Items.Add(New ListViewItem(New String() {f.ToString.Replace(".iso", ""), "PSP", System.IO.Path.GetFullPath(f.FullName)}))
                End If

            Next

            For Each x In customromlist
                Dim custom_directory As New DirectoryInfo(x)
                For Each f In custom_directory.GetFiles
                    If f.ToString.Contains(".iso") Or f.ToString.Contains(".cso") Then

                        main.listbox_installedroms.Items.Add(New ListViewItem(New String() {f.ToString.Replace(".iso", ""), "PSP", System.IO.Path.GetFullPath(f.FullName)}))
                    End If

                Next
            Next
        ElseIf main.currenttab_metadata(1) = "WII" Then
            For Each f In rom_directory.GetFiles
                If f.ToString.Contains("XT") Then
                ElseIf f.ToString.Contains(".iso") Then
                    main.listbox_installedroms.Items.Add(New ListViewItem(New String() {f.ToString.Replace(".iso", ""), "WII", System.IO.Path.GetFullPath(f.FullName)}))
                End If

            Next



            For Each x In customromlist
                Dim custom_directory As New DirectoryInfo(x)
                For Each f In custom_directory.GetFiles
                    If f.ToString.Contains(".iso") Or f.ToString.Contains(".elf") Then

                        main.listbox_installedroms.Items.Add(New ListViewItem(New String() {f.ToString.Replace(".iso", ""), "WII", System.IO.Path.GetFullPath(f.FullName)}))
                    End If

                Next
            Next

            If Directory.Exists(".\roms\GC") = False Then
                Directory.CreateDirectory(".\roms\GC")
            End If
            Dim rom_directory2 As New DirectoryInfo(".\roms\GC\")
            For Each f In rom_directory2.GetFiles
                If f.ToString.Contains("XT") Then
                ElseIf f.ToString.Contains(".iso") Then
                    main.listbox_installedroms.Items.Add(New ListViewItem(New String() {f.ToString.Replace(".iso", ""), "GC", System.IO.Path.GetFullPath(f.FullName)}))
                End If

            Next
        ElseIf main.currenttab_metadata(1) = "WIIU" Then

            Dim rom_directory_wiiU = IO.Directory.GetFiles(".\roms\" & main.currenttab_metadata(1), "*.rpx", IO.SearchOption.AllDirectories)

            For Each f In rom_directory_wiiU
                Dim fullpath As String = System.IO.Path.GetFullPath(f)
                Dim filepath As String = fullpath.Replace(System.IO.Path.GetFullPath(".\roms\" & main.currenttab_metadata(1)), "")
                Dim filename As String() = filepath.Split("\")
                main.listbox_installedroms.Items.Add(New ListViewItem(New String() {filename(1), "WIIU", f}))


            Next

            For Each x In customromlist
                Try
                    Dim rom_directory_wiiU2 = IO.Directory.GetFiles(x, "*.rpx", IO.SearchOption.AllDirectories)
                    For Each f In rom_directory_wiiU2
                        Dim fullpath As String = System.IO.Path.GetFullPath(f)
                        Dim filepath As String = fullpath.Replace(x, "")
                        Dim filename As String() = filepath.Split("\")
                        main.listbox_installedroms.Items.Add(New ListViewItem(New String() {filename(1), "WIIU", f}))

                    Next
                Catch ex As Exception
                End Try

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
                emu_tab_metadata_list.emutabs_metadata(index) = currentmetadata
                index = index + 1
            Next


        End If
    End Sub
End Module
