Imports System.IO

Public Class firstlaunch
    Dim settings As List(Of String)
    Private Sub firstlaunch_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        picturebox_logo.Left = (Me.ClientSize.Width / 2) - (picturebox_logo.Width / 2)
        btn_next.Left = (Me.ClientSize.Width / 2) - (btn_next.Width / 2)
        picturebox_pickacolour.Left = (Me.ClientSize.Width / 2) - (picturebox_pickacolour.Width / 2)
        picturebox_example.Left = (Me.ClientSize.Width / 2) - (picturebox_example.Width / 2)
        picturebox_add_sources.Left = (Me.ClientSize.Width / 2) - (picturebox_add_sources.Width / 2)
        picturebox_dragdrop.Left = (Me.ClientSize.Width / 2) - (picturebox_dragdrop.Width / 2)
        btn_search.Left = (Me.ClientSize.Width / 2) - (btn_search.Width / 2)
        picturebox_disclaimer.Left = (Me.ClientSize.Width / 2) - (picturebox_disclaimer.Width / 2)
        Me.TopMost = True
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
    Private Sub btn_dark_MouseEnter(sender As Object, e As EventArgs) Handles btn_dark.MouseEnter
        btn_dark.BackgroundImage = System.Drawing.Image.FromFile(".\resources\btndarkmodewhite.png")
    End Sub

    Private Sub btn_dark_MouseLeave(sender As Object, e As EventArgs) Handles btn_dark.MouseLeave
        btn_dark.BackgroundImage = System.Drawing.Image.FromFile(".\resources\btndarkmodeblack.png")
    End Sub

    Private Sub btn_dark_MouseDown(sender As Object, e As MouseEventArgs) Handles btn_dark.MouseDown
        main.global_settings(1) = "dark=1"
        panel_eldr.Visible = True
        panel_eldr.BringToFront()
    End Sub

    Private Sub btn_light_MouseEnter(sender As Object, e As EventArgs) Handles btn_light.MouseEnter
        btn_light.BackgroundImage = System.Drawing.Image.FromFile(".\resources\btnlightmodewhite.png")
    End Sub

    Private Sub btn_light_MouseLeave(sender As Object, e As EventArgs) Handles btn_light.MouseLeave
        btn_light.BackgroundImage = System.Drawing.Image.FromFile(".\resources\btnlightmodeblack.png")
    End Sub

    Private Sub btn_light_MouseDown(sender As Object, e As MouseEventArgs) Handles btn_light.MouseDown
        main.global_settings(1) = "dark=0"
        panel_eldr.Visible = True
        panel_eldr.BringToFront()
    End Sub

    Private Sub btn_search_Click(sender As Object, e As EventArgs) Handles btn_search.Click
        Process.Start("https://www.google.com/search?q=drive")
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
    Private Sub picturebox_disclaimer_Click(sender As Object, e As EventArgs) Handles picturebox_disclaimer.Click
        Process.Start("https://tungstencore.com/emuloader/#Disclaimer")
    End Sub
End Class