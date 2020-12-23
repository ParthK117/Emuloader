Imports System.Net
Imports System.IO
Imports System.IO.Compression
Imports System.ComponentModel
Public Class manage_dropbox
    Public Shared cloud_platform As String = "GBA"
    Dim preferences As New List(Of String)
    Private Sub manage_dropbox_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12

        Dim opensansfont10 As New System.Drawing.Font(main.opensans.Families(0), 10)

        Dim opensansfont12 As New System.Drawing.Font(main.opensans.Families(0), 12)
        listbox_cloud.Font = opensansfont12
        listbox_platforms.Font = opensansfont12
        lbl_backup_gba.Font = opensansfont12
        lbl_preferences_gba.Font = opensansfont12
        lbl_restore_gba.Font = opensansfont12
        lbl_features_gba.Font = opensansfont12
        lbl_sync_gba.Font = opensansfont12
        checkbox_sync_settings_gba.Font = opensansfont12
        checkbox_dropbox_gba.Font = opensansfont12

        listbox_cloud.Font = opensansfont12
        listbox_platforms.Font = opensansfont12
        lbl_backup_nds.Font = opensansfont12
        lbl_preferences_nds.Font = opensansfont12
        lbl_restore_nds.Font = opensansfont12
        lbl_sync_nds.Font = opensansfont12
        checkbox_sync_settings_nds.Font = opensansfont12
        checkbox_dropbox_nds.Font = opensansfont12
        Dim gothamfont28 As New System.Drawing.Font(main.gotham.Families(0), 28)
        lbl_cloud.Font = gothamfont28

        listbox_cloud.SelectedItem = listbox_cloud.Items(0)

        Select Case main.dark
            Case 1
                BackColor = Color.FromArgb(21, 32, 43)
                listbox_cloud.BackColor = Color.FromArgb(31, 45, 58)
                listbox_cloud.ForeColor = Color.White
                listbox_platforms.ForeColor = Color.White
                listbox_platforms.BackColor = Color.FromArgb(31, 45, 58)
                lbl_cloud.ForeColor = Color.White
                panel_sync.ForeColor = Color.White
            Case 2
                BackColor = Color.FromArgb(25, 28, 40)
                listbox_cloud.BackColor = Color.FromArgb(32, 37, 52)
                listbox_cloud.ForeColor = Color.White
                lbl_cloud.ForeColor = Color.White
                listbox_platforms.ForeColor = Color.White
                listbox_platforms.BackColor = Color.FromArgb(32, 37, 52)
                panel_sync.ForeColor = Color.White
            Case 3
                BackColor = Color.FromArgb(12, 12, 12)
                listbox_cloud.BackColor = Color.FromArgb(40, 40, 40)
                listbox_cloud.ForeColor = Color.White
                listbox_platforms.ForeColor = Color.White
                listbox_platforms.BackColor = Color.FromArgb(40, 40, 40)
                lbl_cloud.ForeColor = Color.White
                listbox_cloud.ForeColor = Color.White
                panel_sync.ForeColor = Color.White
        End Select

        btn_backup_games_gba.ForeColor = Color.Black
        btn_restore_games_gba.ForeColor = Color.Black

        preferences.AddRange(File.ReadAllLines(".\modules\cloud_preferences.dat"))

        Dim checkbox_sync_gba As String() = (preferences(0).Split("="))
        Dim checkbox_sync_nds As String() = (preferences(0).Split("="))
        Dim checkbox_sync_snes As String() = (preferences(0).Split("="))

        If checkbox_sync_gba(1) = "1" Then
            checkbox_dropbox_gba.Checked = True
        End If

        If checkbox_sync_nds(1) = "1" Then
            checkbox_dropbox_nds.Checked = True
        End If

        listbox_platforms.SelectedItem = listbox_platforms.Items(0)
    End Sub

    Private Sub listbox_platforms_SelectedIndexChanged(sender As Object, e As EventArgs) Handles listbox_platforms.SelectedIndexChanged
        If listbox_platforms.SelectedItem = "GBA" Then
            panel_gba.BringToFront()
        ElseIf listbox_platforms.SelectedItem = "NDS" Then
            panel_nds.BringToFront()
        ElseIf listbox_platforms.SelectedItem = "SNES" Then
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

    Private Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        main.WindowState = FormWindowState.Normal
        If File.Exists(".\modules\cloud_preferences.dat") Then
            My.Computer.FileSystem.DeleteFile(".\modules\cloud_preferences.dat")
        End If

        System.IO.File.Create(".\modules\cloud_preferences.dat").Dispose()
        Dim new_settings As String = preferences(0) & vbNewLine & preferences(1) & vbNewLine & preferences(2)
        File.WriteAllText(".\modules\cloud_preferences.dat", new_settings)

        main.preferences.Clear()
        main.preferences.AddRange(preferences)
        Me.Close()
    End Sub

    Private Sub checkbox_dropbox_gba_CheckedChanged(sender As Object, e As EventArgs) Handles checkbox_dropbox_gba.CheckedChanged
        If checkbox_dropbox_gba.Checked = False Then
            preferences(0) = "sync_gba=0"
        Else
            preferences(0) = "sync_gba=1"
        End If
    End Sub

    Private Sub checkbox_dropbox_nds_CheckedChanged(sender As Object, e As EventArgs) Handles checkbox_dropbox_nds.CheckedChanged
        If checkbox_dropbox_nds.Checked = False Then
            preferences(1) = "sync_nds=0"
        Else
            preferences(1) = "sync_nds=1"
        End If
    End Sub
End Class