Public Class romproperties
    Dim name_rom As String = main.listbox_installedroms.FocusedItem.SubItems(0).Text
    Private Sub romproperties_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        Dim grey As Color
        grey = Color.FromArgb(247, 249, 250)

        Dim lightgrey As Color
        lightgrey = Color.FromArgb(238, 238, 238)

        Dim labelgrey As Color = Color.FromArgb(120, 127, 142)



        Dim spartanfont10 As New System.Drawing.Font(main.spartan.Families(0), 10)

        Dim spartanfont12 As New System.Drawing.Font(main.spartan.Families(0), 12)
        lbl_file_path.Font = spartanfont12
        lbl_rom_name.Font = spartanfont12
        lbl_platform.Font = spartanfont12

        Dim gothamfont28 As New System.Drawing.Font(main.gotham.Families(0), 28)
        lbl_properties.Font = gothamfont28

        Dim gothamfont12 As New System.Drawing.Font(main.gotham.Families(0), 12)
        lbl_properties.Font = gothamfont28

        lbl_file_path_identifier.Font = gothamfont12
        lbl_file_path_identifier.ForeColor = labelgrey
        lbl_rom_name_identifier.Font = gothamfont12
        lbl_rom_name_identifier.ForeColor = labelgrey
        lbl_platform_identifier.Font = gothamfont12
        lbl_platform_identifier.ForeColor = labelgrey


    End Sub
    Public Sub load_rom_properties()
        name_rom = main.listbox_installedroms.FocusedItem.SubItems(0).Text
        lbl_file_path.Text = main.listbox_installedroms.FocusedItem.SubItems(2).Text
        Me.Text = main.listbox_installedroms.FocusedItem.SubItems(0).Text & " Properties"

        lbl_rom_name.Text = name_rom
        textbox_rom_name.Text = name_rom
    End Sub
    Private Sub lbl_rom_name_Click(sender As Object, e As EventArgs) Handles lbl_rom_name.Click
        lbl_rom_name.Visible = False
        textbox_rom_name.Visible = True
        textbox_rom_name.Select()
    End Sub


    Private Sub textbox_rom_name_KeyDown(sender As Object, e As KeyEventArgs) Handles textbox_rom_name.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim x As String = System.IO.Path.GetFileName(main.listbox_installedroms.FocusedItem.SubItems(2).Text)
            Dim x_split As String() = Split(x, ".")
            My.Computer.FileSystem.RenameFile(main.listbox_installedroms.FocusedItem.SubItems(2).Text, textbox_rom_name.Text & "." & x_split(1))
            Me.Text = textbox_rom_name.Text & " Properties"

            lbl_rom_name.Text = textbox_rom_name.Text
            lbl_rom_name.Visible = True
            textbox_rom_name.Visible = False
            lbl_file_path.Text = lbl_file_path.Text.Replace(name_rom, textbox_rom_name.Text)
            main.listbox_installedroms.FocusedItem.SubItems(0).Text = textbox_rom_name.Text
            main.listbox_installedroms.FocusedItem.SubItems(2).Text = lbl_file_path.Text
            name_rom = main.listbox_installedroms.FocusedItem.SubItems(0).Text
        End If
    End Sub
    Private Sub romproperties_Click(sender As Object, e As EventArgs) Handles Me.Click
        lbl_rom_name.Visible = True
        textbox_rom_name.Visible = False

        textbox_rom_name.Text = name_rom
    End Sub
End Class