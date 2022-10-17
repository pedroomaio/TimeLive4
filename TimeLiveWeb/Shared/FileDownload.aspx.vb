Imports System.Configuration
Imports System.IO

Partial Class Shared_FileDownload
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim EncryptFN As String = Request.Url.Query.Replace("?", "")
            Dim DecryptFN As String = LicensingBLL.GetStringFromEncryptedValueByUTF8(EncryptFN).Replace("FileName=", "")
            Dim dlDir As String = System.Configuration.ConfigurationManager.AppSettings("UploadFilesPath")
            Dim strFileName As String = Server.UrlDecode(DecryptFN)
            Dim path As String = Server.MapPath(dlDir + strFileName)

            Response.Clear()

            If IsFileAnImage(path) Then
                Dim buffer = File.ReadAllBytes(path)

                Response.ContentType = "image/jpeg"
                Response.OutputStream.Write(buffer, 0, buffer.Length)
            Else
                Dim toDownload As System.IO.FileInfo = New System.IO.FileInfo(path)

                Response.ContentType = "application/octet-stream"
                Response.AddHeader("content-disposition", "attachment; filename=""" + toDownload.Name + """")

                Response.TransmitFile(path)
            End If

            Response.End()
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Function IsFileAnImage(strFileName As String) As Boolean
        Dim RetVal As Boolean = True
        Try
            Dim img As System.Drawing.Image = System.Drawing.Image.FromFile(strFileName)
            img.Dispose()
        Catch
            RetVal = False
        End Try
        Return RetVal
    End Function
End Class
