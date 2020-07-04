﻿Public Class romproperties
    Dim name_rom As String = main.listbox_installedroms.FocusedItem.SubItems(0).Text
    Private Sub romproperties_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If main.dark = 1 Then
            lbl_properties.ForeColor = Color.FromArgb(23, 191, 99)
            Me.BackColor = Color.FromArgb(21, 32, 43)
            lbl_file_path_identifier.ForeColor = Color.White
            lbl_file_path.ForeColor = Color.White
            lbl_rom_name_identifier.ForeColor = Color.White
            textbox_rom_name.ForeColor = Color.White
            textbox_rom_name.BackColor = Color.FromArgb(21, 32, 43)
            lbl_rom_name.ForeColor = Color.White
            lbl_platform_identifier.ForeColor = Color.White
            lbl_platform.ForeColor = Color.White
        ElseIf main.dark = 2 Then
            lbl_properties.ForeColor = Color.White
            Me.BackColor = Color.FromArgb(25, 28, 40)
            lbl_file_path_identifier.ForeColor = Color.White
            lbl_file_path.ForeColor = Color.White
            lbl_rom_name_identifier.ForeColor = Color.White
            textbox_rom_name.ForeColor = Color.White
            textbox_rom_name.BackColor = Color.FromArgb(25, 28, 40)
            lbl_rom_name.ForeColor = Color.White
            lbl_platform_identifier.ForeColor = Color.White
            lbl_platform.ForeColor = Color.White
        ElseIf main.dark = 3 Then
            lbl_properties.ForeColor = Color.White
            Me.BackColor = Color.FromArgb(12, 12, 12)
            lbl_file_path_identifier.ForeColor = Color.White
            lbl_file_path.ForeColor = Color.White
            lbl_rom_name_identifier.ForeColor = Color.White
            textbox_rom_name.ForeColor = Color.White
            textbox_rom_name.BackColor = Color.FromArgb(12, 12, 12)
            lbl_rom_name.ForeColor = Color.White
            lbl_platform_identifier.ForeColor = Color.White
            lbl_platform.ForeColor = Color.White
        End If

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
        lbl_platform.Text = main.listbox_installedroms.FocusedItem.SubItems(1).Text
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
            If Not main.currenttab_metadata(1) = "WIIU" Then
                Dim x As String = System.IO.Path.GetFileName(main.listbox_installedroms.FocusedItem.SubItems(2).Text)
                Dim x_split As String() = Split(x, ".")
                My.Computer.FileSystem.RenameFile(main.listbox_installedroms.FocusedItem.SubItems(2).Text, textbox_rom_name.Text & "." & x_split(1))
            Else
                MsgBox("Cannot rename WII-U game")
                textbox_rom_name.Text = main.listbox_installedroms.FocusedItem.SubItems(0).Text
            End If


            Me.Text = textbox_rom_name.Text & " Properties"

            lbl_rom_name.Text = textbox_rom_name.Text
            lbl_rom_name.Visible = True
            textbox_rom_name.Visible = False
            lbl_file_path.Text = lbl_file_path.Text.Replace(name_rom, textbox_rom_name.Text)
            main.listbox_installedroms.FocusedItem.SubItems(0).Text = textbox_rom_name.Text
            main.listbox_installedroms.FocusedItem.SubItems(2).Text = lbl_file_path.Text
            name_rom = main.listbox_installedroms.FocusedItem.SubItems(0).Text
            Call main.retrieveboxart()
            If Not main.thread_getboxart.IsBusy = True Then
                Dim arguments As String()
                arguments = {main.currenttab_metadata(1)}
                main.lbl_status.Text = "Downloading Boxart"
                main.lbl_status.Location = New Point((main.panel_top.Width - main.lbl_status.Width) \ 2, (main.panel_top.Height - main.lbl_status.Height) \ 2)
                main.thread_getboxart.RunWorkerAsync(arguments)
            End If
        End If
    End Sub
    Private Sub romproperties_Click(sender As Object, e As EventArgs) Handles Me.Click
        lbl_rom_name.Visible = True
        textbox_rom_name.Visible = False

        textbox_rom_name.Text = name_rom
    End Sub
End Class