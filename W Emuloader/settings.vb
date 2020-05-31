Imports System.IO

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

    End Sub

    Private Sub load_boxart_on_startup_CheckedChanged(sender As Object, e As EventArgs) Handles load_boxart_on_startup.CheckedChanged
        If load_boxart_on_startup.Checked = True Then
            settings(0) = "load=1"
        Else
            settings(0) = "load=0"
        End If

    End Sub


    Private Sub btn_save_MouseDown(sender As Object, e As MouseEventArgs) Handles btn_save.MouseDown
        If File.Exists(".\settings.dat") Then
            My.Computer.FileSystem.DeleteFile(".\settings.dat")
        End If

        System.IO.File.Create(".\settings.dat").Dispose()
        File.WriteAllLines(".\settings.dat", settings)
        If load_skin.Checked = True Then
            Call darkmode()
            main.dark = True
        Else
            Call lightmode()
            main.dark = False
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
End Class