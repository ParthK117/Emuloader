Imports System.IO
Imports System.Net
Module dropbox
    Public Class dropbox_Class

    End Class
    Public Sub dropbox_status_check()
        If File.Exists(".\modules\access_token.dat") Then
            main.panel_connected.Visible = True
        End If
    End Sub

    Public Sub dropbox_gba(arguments2)
        '     Dim arguments As String() = (arguments2)
        '     Dim getart As Process
        '     Dim p As New ProcessStartInfo
        '     p.FileName = ".\getboxart.exe"
        '     p.WindowStyle = ProcessWindowStyle.Hidden
        '     p.WorkingDirectory = ".\modules\"
        '    p.Arguments = (arguments(1) & " " & arguments(0) & " " & Chr(34) & Path.GetFullPath(".\boxart") & Chr(34) & " " & Chr(34) & Path.GetFullPath(".\roms\" & currenttab_metadata(1) & "\metadata\romnamelist.eldr") & Chr(34) & " " & Chr(34) & Path.GetFullPath(".\roms\" & currenttab_metadata(1) & "\metadata") & Chr(34))
        '   getart = Process.Start(p)
    End Sub
End Module
