Imports System.IO
Imports System.Net

Public Class settings
    Dim settings As New List(Of String)
    Private Sub settings_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        settings.AddRange(File.ReadAllLines(".\settings.dat"))
        Dim checkbox_loadart As String() = (settings(0).Split("="))
        If checkbox_loadart(1) = "1" Then
            load_boxart_on_startup.Checked = True
        End If
        Dim checkbox_skin As String() = (settings(1).Split("="))
        If checkbox_skin(1) = "1" Then
            load_skin.Checked = True
        End If
        Dim checkbox_update As String() = (settings(3).Split("="))
        If checkbox_update(1) = "1" Then
            checkbox_autoupdate.Checked = True
        End If
        Dim exitonx As String() = (settings(4).Split("="))
        If exitonx(1) = "1" Then
            checkbox_exit_on_taskbar.Checked = True
        End If
        Dim fancy As String() = (settings(5).Split("="))
        If fancy(1) = "1" Then
            checkbox_fancy.Checked = True
        End If
        Dim topbar As String() = (settings(7).Split("="))
        If topbar(1) = "1" Then
            checkbox_topbar.Checked = True
        End If
        Dim spartanfont14 As New System.Drawing.Font(main.spartan.Families(0), 14)
        load_boxart_on_startup.Font = spartanfont14
        load_skin.Font = spartanfont14
        checkbox_autoupdate.Font = spartanfont14
        checkbox_exit_on_taskbar.Font = spartanfont14
        checkbox_fancy.Font = spartanfont14
        checkbox_topbar.Font = spartanfont14

        Dim spartanfont16 As New System.Drawing.Font(main.spartan.Families(0), 16)
        listbox_settings.Font = spartanfont16

        Dim gothamfont28 As New System.Drawing.Font(main.gotham.Families(0), 28)
        lbl_settingstitle.Font = gothamfont28

        If main.dark = True Then
            Me.BackColor = Color.FromArgb(21, 32, 43)
            load_boxart_on_startup.ForeColor = Color.White
            load_skin.ForeColor = Color.White
            checkbox_autoupdate.ForeColor = Color.White
            listbox_settings.BackColor = Color.FromArgb(21, 32, 43)
            listbox_settings.ForeColor = Color.White
            lbl_settingstitle.ForeColor = Color.FromArgb(23, 191, 99)
            checkbox_exit_on_taskbar.ForeColor = Color.White
            checkbox_topbar.ForeColor = Color.White
            checkbox_fancy.ForeColor = Color.White
            picturebox_wave.BackgroundImage = System.Drawing.Image.FromFile(".\resources\egwavedark.png")
        End If
        listbox_settings.SelectedItem = listbox_settings.Items(0)
    End Sub

    Private Sub load_boxart_on_startup_CheckedChanged(sender As Object, e As EventArgs) Handles load_boxart_on_startup.CheckedChanged
        If load_boxart_on_startup.Checked = True Then
            settings(0) = "load=1"
        Else
            settings(0) = "load=0"
        End If

    End Sub


    Private Sub btn_save_MouseDown(sender As Object, e As MouseEventArgs) Handles btn_save.MouseDown
        main.WindowState = FormWindowState.Normal
        If File.Exists(".\settings.dat") Then
            My.Computer.FileSystem.DeleteFile(".\settings.dat")
        End If

        System.IO.File.Create(".\settings.dat").Dispose()
        Dim new_settings As String = settings(0) & vbNewLine & settings(1) & vbNewLine & "version=" & main.version_number & vbNewLine & settings(3) & vbNewLine & settings(4) & vbNewLine & settings(5) & vbNewLine & "firsttime=0" & vbNewLine & settings(7)
        File.WriteAllText(".\settings.dat", new_settings)
        main.global_settings.Clear()
        main.global_settings.AddRange(File.ReadAllLines(".\settings.dat"))

        If settings(5).Contains("1") Then
            main.lbl_status.Location = New Point((main.panel_top.Width - main.lbl_status.Width) \ 2, (main.panel_top.Height - main.lbl_status.Height) \ 2)
            If Not File.Exists(".\resources\wavyblack.gif") Or Not File.Exists(".\resources\wavywhite.gif") Then
                Using dlanimations As New WebClient
                    Try
                        dlanimations.DownloadFile("https://github.com/ParthK117/Emuloader/releases/download/r-dlanimations/wavyblack.gif", ".\resources\wavyblack.gif")
                        dlanimations.DownloadFile("https://github.com/ParthK117/Emuloader/releases/download/r-dlanimations/wavywhite.gif", ".\resources\wavywhite.gif")
                        dlanimations.Dispose()
                    Catch ex As Exception
                    End Try
                    main.lbl_status.Text = "Downloaded fancy animations"
                End Using

            End If
        Else
        End If
        If load_skin.Checked = True Then
            Call darkmode()
            main.dark = True
        Else
            Call lightmode()
            main.dark = False
        End If
        If checkbox_topbar.Checked = True Then
            main.FormBorderStyle = FormBorderStyle.Sizable
            main.paneL_menubar.Visible = False
        Else
            main.FormBorderStyle = FormBorderStyle.None
            main.paneL_menubar.Visible = True
        End If
        Me.Close()


    End Sub

    Private Sub load_skin_CheckedChanged(sender As Object, e As EventArgs) Handles load_skin.CheckedChanged
        If load_skin.Checked = True Then
            settings(1) = "dark=1"
        Else
            settings(1) = "dark=0"
        End If
    End Sub


    Private Sub btn_save_MouseEnter(sender As Object, e As EventArgs) Handles btn_save.MouseEnter
        btn_save.BackgroundImage = System.Drawing.Image.FromFile(".\resources\savewhite.png")
    End Sub

    Private Sub btn_save_MouseLeave(sender As Object, e As EventArgs) Handles btn_save.MouseLeave
        btn_save.BackgroundImage = System.Drawing.Image.FromFile(".\resources\saveblack.png")
    End Sub

    Private Sub btn_save_MouseUp(sender As Object, e As MouseEventArgs) Handles btn_save.MouseUp
        btn_save.BackgroundImage = System.Drawing.Image.FromFile(".\resources\savewhite.png")
    End Sub

    Private Sub listbox_settings_SelectedIndexChanged(sender As Object, e As EventArgs) Handles listbox_settings.SelectedIndexChanged
        If listbox_settings.SelectedItem = "General" Then
            lbl_settingstitle.Text = "General"
            panel_general.BringToFront()
        ElseIf listbox_settings.SelectedItem = "Appearance" Then
            lbl_settingstitle.Text = "Appearance"
            panel_appearance.BringToFront()
        ElseIf listbox_settings.SelectedItem = "Updates" Then
            lbl_settingstitle.Text = "Updates"
            panel_updates.BringToFront()
        End If
    End Sub

    Private Sub checkbox_autoupdate_CheckedChanged(sender As Object, e As EventArgs) Handles checkbox_autoupdate.CheckedChanged
        If checkbox_autoupdate.Checked = True Then
            settings(3) = "autoupdate=1"
        Else
            settings(3) = "autoupdate=0"
        End If
    End Sub

    Private Sub checkbox_exit_on_taskbar_CheckedChanged(sender As Object, e As EventArgs) Handles checkbox_exit_on_taskbar.CheckedChanged
        If checkbox_exit_on_taskbar.Checked = True Then
            settings(4) = "exitonx=1"
        Else
            settings(4) = "exitonx=0"
        End If
    End Sub

    Private Sub checkbox_fancy_CheckedChanged(sender As Object, e As EventArgs) Handles checkbox_fancy.CheckedChanged
        If checkbox_fancy.Checked = True Then
            settings(5) = "fancydl=1"
        Else
            settings(5) = "fancydl=0"
        End If
    End Sub

    Private Sub checkbox_topbar_CheckedChanged(sender As Object, e As EventArgs) Handles checkbox_topbar.CheckedChanged
        If checkbox_topbar.Checked = True Then
            settings(7) = "windowsbar=1"
        Else
            settings(7) = "windowsbar=0"
        End If
    End Sub
End Class