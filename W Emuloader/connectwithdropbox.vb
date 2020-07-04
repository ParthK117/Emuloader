Imports System.Threading
Imports System.IO
Public Class connectwithdropbox
    Private Sub connectwithdropbox_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btn_connect.Left = (Me.ClientSize.Width / 2) - (btn_connect.Width / 2)
        textbox_code.Left = (Me.ClientSize.Width / 2) - (textbox_code.Width / 2)
    End Sub

    Private Sub btn_connect_MouseEnter(sender As Object, e As EventArgs) Handles btn_connect.MouseEnter
        btn_connect.Image = System.Drawing.Image.FromFile(".\resources\connectdropboxwhite.png")
    End Sub

    Private Sub btn_connect_MouseLeave(sender As Object, e As EventArgs) Handles btn_connect.MouseLeave
        btn_connect.Image = System.Drawing.Image.FromFile(".\resources\connectdropboxblack.gif")
    End Sub

    Private Sub btn_connect_MouseDown(sender As Object, e As MouseEventArgs) Handles btn_connect.MouseDown
        Me.BackgroundImage = System.Drawing.Image.FromFile(".\resources\dropbox2.png")

        Dim connect As Process
        Dim p As New ProcessStartInfo
        p.FileName = "dropbox.exe"
        MessageBox.Show(System.IO.Path.GetFullPath(p.FileName))
        '   p.UseShellExecute = True
        p.WindowStyle = ProcessWindowStyle.Hidden
        p.WorkingDirectory = ".\modules\"
        p.Arguments = ("connect")
        connect = Process.Start(p)

        btn_finish.Visible = True
        btn_connect.Visible = False
        textbox_code.Visible = True
    End Sub


    Private Sub btn_finish_MouseDown(sender As Object, e As MouseEventArgs) Handles btn_finish.MouseDown
        If Not File.Exists(".\modules\authcode.dat") Then
            File.Create(".\modules\authcode.dat").Dispose()
            File.WriteAllText(".\modules\authcode.dat", textbox_code.Text)
        End If
        Me.BackgroundImage = System.Drawing.Image.FromFile(".\resources\dropboxfinishinte.png")
        Thread.Sleep(3000)
        Me.Close()
    End Sub

    Private Sub btn_finish_MouseEnter(sender As Object, e As EventArgs) Handles btn_finish.MouseEnter
        btn_finish.BackgroundImage = System.Drawing.Image.FromFile(".\resources\dropboxfinishwhite.png")
    End Sub

    Private Sub btn_finish_MouseLeave(sender As Object, e As EventArgs) Handles btn_finish.MouseLeave
        btn_finish.BackgroundImage = System.Drawing.Image.FromFile(".\resources\dropboxfinish.png")
    End Sub
End Class