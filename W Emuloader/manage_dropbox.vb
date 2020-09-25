Imports System.Net
Imports System.IO
Imports System.IO.Compression
Imports System.ComponentModel
Public Class manage_dropbox
    Private Sub manage_dropbox_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12

        Dim spartanfont10 As New System.Drawing.Font(main.spartan.Families(0), 10)

        Dim spartanfont12 As New System.Drawing.Font(main.spartan.Families(0), 12)
        listbox_cloud.Font = spartanfont12

        Dim gothamfont28 As New System.Drawing.Font(main.gotham.Families(0), 28)
        lbl_cloud.Font = gothamfont28

        listbox_cloud.SelectedItem = listbox_cloud.Items(0)

        Select Case main.dark
            Case 1
                BackColor = Color.FromArgb(21, 32, 43)
                listbox_cloud.BackColor = Color.FromArgb(31, 45, 58)
                panel_settings.BackColor = Color.FromArgb(31, 45, 58)
                listbox_cloud.ForeColor = Color.White
                '           textbox_search.ForeColor = Color.White
                lbl_cloud.ForeColor = Color.White
                '         lbl_platform.ForeColor = Color.White
                '        lbl_source.ForeColor = Color.White
         '       lbl_version_number.ForeColor = Color.White
            Case 2
                BackColor = Color.FromArgb(25, 28, 40)
                listbox_cloud.BackColor = Color.FromArgb(32, 37, 52)
                panel_settings.BackColor = Color.FromArgb(32, 37, 52)
                listbox_cloud.ForeColor = Color.White
                '     textbox_search.ForeColor = Color.White
                lbl_cloud.ForeColor = Color.White
                '   lbl_platform.ForeColor = Color.White
                '  lbl_source.ForeColor = Color.White
               ' lbl_version_number.ForeColor = Color.White
            Case 3
                BackColor = Color.FromArgb(12, 12, 12)
                listbox_cloud.BackColor = Color.FromArgb(40, 40, 40)
                panel_settings.BackColor = Color.FromArgb(40, 40, 40)
                listbox_cloud.ForeColor = Color.White
                '   textbox_search.ForeColor = Color.White
                lbl_cloud.ForeColor = Color.White
                ' lbl_platform.ForeColor = Color.White
                'lbl_source.ForeColor = Color.White
                '  lbl_version_number.ForeColor = Color.White
        End Select
    End Sub
End Class