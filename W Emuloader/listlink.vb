Imports System.IO
Imports System.Net

Public Class listlink
    Private Sub listlink_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If main.dark = True Then
            BackColor = Color.FromArgb(21, 32, 43)
            textbox_url.BackColor = Color.FromArgb(31, 45, 58)
            textbox_url.ForeColor = Color.White
        End If
    End Sub

    Private Sub btn_import_MouseDown(sender As Object, e As MouseEventArgs) Handles btn_import.MouseDown
        btn_import.BackgroundImage = System.Drawing.Image.FromFile(".\resources\importclick.png")
        Dim urls As String() = textbox_url.Lines

        For Each line In urls
            Dim timestamp As String = Date.Now.ToString("HH-mm-ss-dd-MM-yyyy")
            Using importlinks = New WebClient()
                Try
                    importlinks.DownloadFile(line, ".\lists\" & timestamp & ".eldr")
                    importlinks.Dispose()
                    If Directory.Exists(".\lists\") Then
                    Else
                        My.Computer.FileSystem.CreateDirectory(".\lists\")
                    End If
                    Dim imported_list_downloads As String() = File.ReadAllLines(".\lists\" & timestamp & ".eldr")
                    Dim showsource As Boolean = False
                    Dim metadata As String()
                    If imported_list_downloads(0).Contains("#") Then

                        metadata = Split(imported_list_downloads(0), "#")
                        If metadata(2) = "verify" Then
                            Process.Start(metadata(3))
                        End If
                        showsource = True
                    End If



                    For Each x In imported_list_downloads
                        If Not x.Contains("#") Then
                            Dim x_split As String() = Split(x, ",")
                            '  listbox_availableroms.Items.Add(x_split(0))
                            Dim file_source As String = x_split(3)
                            If file_source.Contains("google") Then
                                file_source = "Google Drive"
                            ElseIf showsource = True Then
                                file_source = metadata(0)
                            Else
                                file_source = "Other"
                            End If
                            main.listbox_availableroms.Items.Add(New ListViewItem(New String() {x_split(0), x_split(1), x_split(2), file_source, x_split(3)}))
                        End If
                    Next
                    main.listbox_availableroms.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent)
                    main.listbox_availableroms.AutoResizeColumn(2, ColumnHeaderAutoResizeStyle.HeaderSize)
                    main.listbox_availableroms.Columns.Item(4).Width = 0




                Catch ex As Exception
                    MsgBox("Invalid Link")
                End Try
            End Using
        Next
    End Sub

    Private Sub btn_import_MouseEnter(sender As Object, e As EventArgs) Handles btn_import.MouseEnter
        btn_import.BackgroundImage = System.Drawing.Image.FromFile(".\resources\importwhite.png")
    End Sub

    Private Sub btn_import_MouseLeave(sender As Object, e As EventArgs) Handles btn_import.MouseLeave
        btn_import.BackgroundImage = System.Drawing.Image.FromFile(".\resources\importblack.png")
    End Sub


    Private Sub btn_import_MouseUp(sender As Object, e As MouseEventArgs) Handles btn_import.MouseUp
        btn_import.BackgroundImage = System.Drawing.Image.FromFile(".\resources\importwhite.png")
    End Sub
End Class