Imports System.IO

Public Class parameters
    Private Sub parameters_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If main.dark = True Then
            Me.BackColor = Color.FromArgb(21, 32, 43)
            lbl_params_title.ForeColor = Color.FromArgb(23, 191, 99)
        End If
        Dim gothamfont28 As New System.Drawing.Font(main.gotham.Families(0), 28)
        lbl_params_title.Font = gothamfont28
        textbox_parameters.Text = File.ReadAllText(".\" & main.currenttab_metadata(4) & "\cmdlineargs.ini")

        Dim spartanfont12 As New System.Drawing.Font(main.spartan.Families(0), 12)
        textbox_parameters.Font = spartanfont12
    End Sub

    Private Sub btn_save_MouseDown(sender As Object, e As MouseEventArgs) Handles btn_save.MouseDown
        If File.Exists(".\" & main.currenttab_metadata(4) & "\cmdlineargs.ini") Then
            My.Computer.FileSystem.DeleteFile(".\" & main.currenttab_metadata(4) & "\cmdlineargs.ini")
        End If

        System.IO.File.Create(".\" & main.currenttab_metadata(4) & "\cmdlineargs.ini").Dispose()

        File.WriteAllText((".\" & main.currenttab_metadata(4) & "\cmdlineargs.ini"), textbox_parameters.Text)

        Me.Close()
        main.btn_parameters.ForeColor = main.labelgrey

    End Sub

    Private Sub textbox_parameters_KeyDown(sender As Object, e As KeyEventArgs) Handles textbox_parameters.KeyDown
        If e.KeyCode = Keys.Enter Then
            If File.Exists(".\" & main.currenttab_metadata(4) & "\cmdlineargs.ini") Then
                My.Computer.FileSystem.DeleteFile(".\" & main.currenttab_metadata(4) & "\cmdlineargs.ini")
            End If

            System.IO.File.Create(".\" & main.currenttab_metadata(4) & "\cmdlineargs.ini").Dispose()

            File.WriteAllText((".\" & main.currenttab_metadata(4) & "\cmdlineargs.ini"), textbox_parameters.Text)

            Me.Close()
            main.btn_parameters.ForeColor = main.labelgrey
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