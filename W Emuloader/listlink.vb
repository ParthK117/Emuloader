Imports System.IO
Imports System.Net

Public Class listlink
    Private Sub listlink_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Select Case main.dark
            Case 1
                BackColor = Color.FromArgb(21, 32, 43)
                textbox_url.BackColor = Color.FromArgb(31, 45, 58)
                textbox_url.ForeColor = Color.White
                lbl_disclaimer.ForeColor = Color.White
            Case 2
                BackColor = Color.FromArgb(25, 28, 40)
                textbox_url.BackColor = Color.FromArgb(32, 37, 52)
                textbox_url.ForeColor = Color.White
                lbl_disclaimer.ForeColor = Color.White
            Case 3
                BackColor = Color.FromArgb(12, 12, 12)
                textbox_url.BackColor = Color.FromArgb(40, 40, 40)
                textbox_url.ForeColor = Color.White
                lbl_disclaimer.ForeColor = Color.White
        End Select
    End Sub

    Private Sub btn_import_MouseDown(sender As Object, e As MouseEventArgs) Handles btn_import.MouseDown
        btn_import.BackgroundImage = System.Drawing.Image.FromFile(".\resources\importclick.png")
        Dim result = MessageBox.Show("Emuloader's ELDR system is a way to turn your existing rom libraries which are stored in the cloud, as well as publicly available romhacks, homebrew and abandonware into a format more easily manipulated. Think of it as a compatibility layer and stopover tool. It is not to be used for piracy under any circumstances, you may not be allowed to download online backups, even if you own a physical copy of the game.


Do you confirm that you either own this content, or that this content has been allowed to be shared by the content owner and/or copyright holder?", "Verify ownership of content", MessageBoxButtons.YesNo)
        If result = DialogResult.Yes Then
            Dim urls As String() = textbox_url.Lines
            Dim index As Boolean = False
            For Each line In urls

                Dim timestamp As String = Date.Now.ToString("HH-mm-ss-dd-MM-yyyy")
                Using importlinks = New WebClient()
                    Try
                        importlinks.DownloadFile(line, ".\lists\" & timestamp & ".eldr")
                        importlinks.Dispose()
                        For Each listfile In Directory.GetFiles(".\lists")
                            Dim currfile As New FileInfo(listfile)
                            Dim currentsize As Double = (currfile.Length)
                            Dim newlist As New FileInfo(".\lists\" & timestamp & ".eldr")
                            Dim newlistsize As Double = (newlist.Length)
                            If currentsize = newlistsize And Not currfile.FullName = newlist.FullName Then
                                MessageBox.Show("You already have this .ELDR indexed.")
                                index = True
                                File.Delete(".\lists\" & timestamp & ".eldr")
                            End If
                        Next
                        If index = False Then
                            If Directory.Exists(".\lists\") Then
                            Else
                                My.Computer.FileSystem.CreateDirectory(".\lists\")
                            End If
                            Dim imported_list_downloads As New List(Of String)
                            imported_list_downloads.AddRange(File.ReadAllLines(".\lists\" & timestamp & ".eldr"))
                            Dim showsource As Boolean = False
                            Dim metadata As String()
                            If imported_list_downloads(0).Contains("#") Then
                                metadata = Split(imported_list_downloads(0), "#")
                                If metadata(2) = "verify" Then
                                    Process.Start(metadata(3))
                                End If
                                imported_list_downloads.RemoveAt(0)
                                showsource = True
                            End If
                            For Each entry In imported_list_downloads
                                Dim entry_split As String() = Split(entry, ",")
                                Dim file_source As String = entry_split(3)
                                If file_source.Contains("google") Then
                                    file_source = "Google Drive"
                                ElseIf showsource = True Then
                                    file_source = metadata(0)
                                Else
                                    file_source = "Other"
                                End If
                                main.listbox_availableroms.Items.Add(New ListViewItem(New String() {entry_split(0), entry_split(1), entry_split(2), file_source, entry_split(3)}))
                            Next
                            main.listbox_availableroms.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent)
                            main.listbox_availableroms.AutoResizeColumn(2, ColumnHeaderAutoResizeStyle.HeaderSize)
                            main.listbox_availableroms.Columns.Item(4).Width = 0
                        End If
                    Catch ex As Exception
                        MsgBox("Invalid Link or already indexed this before.")
                        File.Delete(".\lists\" & timestamp & ".eldr")
                    End Try
                End Using
            Next
        Else
            MessageBox.Show("Your source/eldr has not been imported. Please take a moment to review our stance on piracy and copyrighted content.", "Import failed.")
            Process.Start("https://tungstencore.com/emuloader/#Disclaimer")
        End If
        Me.Close()
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