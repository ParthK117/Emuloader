Public Class about
    Private Sub about_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "About Emuloader Legacy " & main.version_number
        Dim opensansfont14 As New System.Drawing.Font(main.opensans.Families(0), 12)
        lbl_version.Font = opensansfont14
        lbl_patreon.Font = opensansfont14
        lbl_website.Font = opensansfont14
        lbl_version.Text = "Version Legacy " & main.version_number
    End Sub

    Private Sub lbl_website_Click(sender As Object, e As EventArgs) Handles lbl_website.Click
        Process.Start("https://parthkataria.com")
    End Sub

    Private Sub picturebox_tungsten_Click(sender As Object, e As EventArgs)
        Process.Start("https://tungstencore.com")
    End Sub
End Class