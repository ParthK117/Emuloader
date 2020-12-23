Imports System.IO

Public Class firstlaunch
    Dim settings As List(Of String)
    Private Sub firstlaunch_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        updates.Hide()
        picturebox_logo.Left = (Me.ClientSize.Width / 2) - (picturebox_logo.Width / 2)
        btn_next.Left = (Me.ClientSize.Width / 2) - (btn_next.Width / 2)
        picturebox_disclaimer.Left = (Me.ClientSize.Width / 2) - (picturebox_disclaimer.Width / 2)
        picturebox_preview.Left = (Me.ClientSize.Width / 2) - (picturebox_preview.Width / 2)
        combobox_theme.Left = (Me.ClientSize.Width / 2) - (combobox_theme.Width / 2)
        Me.TopMost = True
        combobox_theme.SelectedItem = combobox_theme.Items(0)
    End Sub

    Private Sub btn_next_MouseEnter(sender As Object, e As EventArgs) Handles btn_next.MouseEnter
        btn_next.BackgroundImage = System.Drawing.Image.FromFile(".\resources\nextwhite.png")
    End Sub

    Private Sub btn_next_MouseLeave(sender As Object, e As EventArgs) Handles btn_next.MouseLeave
        btn_next.BackgroundImage = System.Drawing.Image.FromFile(".\resources\nextblack.png")
    End Sub

    Private Sub btn_next_MouseDown(sender As Object, e As MouseEventArgs) Handles btn_next.MouseDown
        btn_next.BackgroundImage = System.Drawing.Image.FromFile(".\resources\nextclick.png")
    End Sub

    Private Sub btn_next_MouseUp(sender As Object, e As MouseEventArgs) Handles btn_next.MouseUp
        panel_colourpicker.Visible = True
        panel_colourpicker.BringToFront()
    End Sub

    Private Sub combobox_theme_SelectedIndexChanged(sender As Object, e As EventArgs) Handles combobox_theme.SelectedIndexChanged
        If combobox_theme.SelectedIndex = 1 Then
            main.global_settings(1) = "dark=1"
            picturebox_preview.BackgroundImage = System.Drawing.Image.FromFile(".\resources\previewdark.png")
        ElseIf combobox_theme.SelectedIndex = 0 Then
            main.global_settings(1) = "dark=0"
            picturebox_preview.BackgroundImage = System.Drawing.Image.FromFile(".\resources\previewlight.png")
        ElseIf combobox_theme.SelectedIndex = 2 Then
            main.global_settings(1) = "dark=2"
            picturebox_preview.BackgroundImage = System.Drawing.Image.FromFile(".\resources\previewdarker.png")
        ElseIf combobox_theme.SelectedIndex = 3 Then
            main.global_settings(1) = "dark=3"
            picturebox_preview.BackgroundImage = System.Drawing.Image.FromFile(".\resources\previewdarkest.png")
        End If
    End Sub

    Private Sub btn_next_2_MouseEnter(sender As Object, e As EventArgs) Handles btn_next_2.MouseEnter
        btn_next_2.BackgroundImage = System.Drawing.Image.FromFile(".\resources\nextwhite.png")
    End Sub

    Private Sub btn_next_2_MouseLeave(sender As Object, e As EventArgs) Handles btn_next_2.MouseLeave
        btn_next_2.BackgroundImage = System.Drawing.Image.FromFile(".\resources\nextblack.png")
    End Sub

    Private Sub btn_next_2_MouseDown(sender As Object, e As MouseEventArgs) Handles btn_next_2.MouseDown
        btn_next_2.BackgroundImage = System.Drawing.Image.FromFile(".\resources\nextclick.png")
    End Sub

    Private Sub btn_next_2_MouseUp(sender As Object, e As MouseEventArgs) Handles btn_next_2.MouseUp
        panel_conditions.Visible = True
        panel_conditions.BringToFront()
    End Sub

    Private Sub btn_finish_MouseEnter(sender As Object, e As EventArgs) Handles btn_finish.MouseEnter
        btn_finish.BackgroundImage = System.Drawing.Image.FromFile(".\resources\finishwhite.png")
    End Sub

    Private Sub btn_finish_MouseLeave(sender As Object, e As EventArgs) Handles btn_finish.MouseLeave
        btn_finish.BackgroundImage = System.Drawing.Image.FromFile(".\resources\finishblack.png")
    End Sub

    Private Sub btn_finish_MouseDown(sender As Object, e As MouseEventArgs) Handles btn_finish.MouseDown
        Me.Close()
    End Sub
    Private Sub btn_next_3_MouseEnter(sender As Object, e As EventArgs) Handles btn_next_3.MouseEnter
        btn_next_3.BackgroundImage = System.Drawing.Image.FromFile(".\resources\nextwhite.png")
    End Sub

    Private Sub btn_next_3_MouseLeave(sender As Object, e As EventArgs) Handles btn_next_3.MouseLeave
        btn_next_3.BackgroundImage = System.Drawing.Image.FromFile(".\resources\nextblack.png")
    End Sub

    Private Sub btn_next_3_MouseDown(sender As Object, e As MouseEventArgs) Handles btn_next_3.MouseDown
        btn_next_3.BackgroundImage = System.Drawing.Image.FromFile(".\resources\nextclick.png")
    End Sub

    Private Sub btn_next_3_MouseUp(sender As Object, e As MouseEventArgs) Handles btn_next_3.MouseUp
        panel_sources.Visible = True
        panel_sources.BringToFront()
    End Sub

    Private Sub btn_search_Click(sender As Object, e As EventArgs) Handles btn_search.Click
        Process.Start("https://www.google.com/search?q=emuloader+reddit")
    End Sub

    Private Sub btn_wiki_Click(sender As Object, e As EventArgs) Handles btn_wiki.Click
        Process.Start("https://tungstencore.com/docs/sources/")
    End Sub
End Class