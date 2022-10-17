Imports Microsoft.VisualBasic
Imports ImageMagick
Imports System.Web.UI
Imports System.IO

Public Class MagickPDF
    Inherits Control
    Public Shared Function ConverPDFtoMultipleImages(ByVal PdfPath As String, ByVal Name As String, ByVal TempFileName As String) As List(Of String)

        Dim settings As New MagickReadSettings()
        ' Settings the density to 300 dpi will create an image with a better quality
        settings.Density = New Density(100, 100)

        Dim PathsOfImg As New List(Of String)

        Using images As New MagickImageCollection()
            ' Add all the pages of the pdf file to the collection
            Dim dlDir As String = System.Configuration.ConfigurationManager.AppSettings("UploadFilesPath")
            images.Read(dlDir & PdfPath, settings)

            Dim page As Integer = 1
            For Each image As MagickImage In images
                Dim path As String = System.IO.Path.GetTempPath() + Guid.NewGuid().ToString() + ".png"
                ' Write page to file that contains the page number
                Dim rnd As New Random()

                image.Write(path)
                page += 1
                PathsOfImg.Add(path)
            Next

        End Using
        Return PathsOfImg

    End Function

End Class