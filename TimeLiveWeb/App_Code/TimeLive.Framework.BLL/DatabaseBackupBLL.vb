Imports Microsoft.VisualBasic
Imports System.IO
Imports System.Reflection
Public Class DatabaseBackupBLL
    Public Function RecursivelyDeleteOldBackupFiles()
        Dim directory As String = System.Configuration.ConfigurationManager.AppSettings("UploadFilesPath")
        Dim strRoot As String = System.Web.Hosting.HostingEnvironment.MapPath(directory)
        'System.Web.HttpContext.Current.Request.MapPath(directory)
        Me.DeleteBackupFiles(strRoot)
    End Function
    Public Function DeleteBackupFiles(ByVal dir As String) As Boolean
        Try
            If Not System.IO.Directory.Exists(dir) Then
                Exit Function
            Else
                Dim names As String() = Directory.GetFiles(dir, "*.bak*", SearchOption.AllDirectories)
                For Each file As String In names
                    'If DateDiff("d", FileDateTime(file), Now) >= 1 Then
                    System.IO.File.Delete(file)
                    'End If
                Next
            End If
        Catch ex As Exception
        End Try
    End Function
End Class
