Imports System.IO
Imports System.IO.Compression
Imports System.Net

Module module_emulatorupdater
    Public Class oneeeee

    End Class

    Public Sub emulator_updater()
        Dim uptodate_list As String()
        Using currentlinks = New WebClient()
            Try
                currentlinks.DownloadFile("https://tungstencore.com/cdn/emulatorlinks.txt", ".\modules\emulatorlinks.txt")
                currentlinks.Dispose()
                uptodate_list = File.ReadAllLines(".\modules\emulatorlinks.txt")
            Catch ex As Exception
            End Try
        End Using
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
        If main.currenttab_metadata(0) = "Visual Boy Advance-M" Then
            Dim newversion As String() = uptodate_list(0).Split(",")


            If Not main.currenttab_metadata(5) = newversion(4) Then
                Dim arguments As String()
                arguments = {newversion(0)}

                main.thread_emulator_update.RunWorkerAsync(arguments)
            Else
                Call main.launch_emulator()
            End If
        End If

    End Sub
End Module
