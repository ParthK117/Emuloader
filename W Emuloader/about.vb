Public Class about
    Private Sub about_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim spartanfont14 As New System.Drawing.Font(main.spartan.Families(0), 12)
        lbl_version.Font = spartanfont14
        lbl_patreon.Font = spartanfont14
        lbl_website.Font = spartanfont14
        lbl_version.Text = "Version " & main.version_number
    End Sub

    Private Sub lbl_website_Click(sender As Object, e As EventArgs) Handles lbl_website.Click
        Process.Start("https://parthkataria.com")
    End Sub

    Private Sub picturebox_tungsten_Click(sender As Object, e As EventArgs) Handles picturebox_tungsten.Click
        Process.Start("https://tungstencore.com")
    End Sub
End Class