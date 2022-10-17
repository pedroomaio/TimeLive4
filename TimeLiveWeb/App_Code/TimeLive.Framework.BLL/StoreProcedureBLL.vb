Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System
' ''Imports System.IO.Compression.GZipStream
' ''Imports System.IO.Compression
' ''Imports System.IO
' ''Imports ICSharpCode.SharpZipLib.Core
' ''Imports ICSharpCode.SharpZipLib.Zip

Public Class StoreProcedureBLL
    Public Function GetDataForDelete(ByVal AccountId As Integer, ByVal CN As SqlConnection)


        Dim objConnection As New SqlConnection(CN.ConnectionString)
        objConnection.Open()


        'Dim strsql As String

        'strsql = "IF  EXISTS (SELECT * FROM tempdb.dbo.sysobjects WHERE NAME = '##temp') DROP TABLE tempdb.[dbo].[##temp]"
        'DBUtilities.ExecuteCommand(strsql)


        Dim command As SqlCommand = _
        New SqlCommand("DeleteScript", objConnection)


        ' objConnection.Open()

        command.CommandType = CommandType.StoredProcedure
        command.Parameters.Clear()
        command.Parameters.Add("@AccountId", AccountId)
        command.CommandTimeout = 9000000
        command.ExecuteNonQuery()
        objConnection.Close()
    End Function
    Public Sub CreateZipFileDatabaseBackup(ByVal srcfile As String, ByVal dstfile As String, ByVal bufsize As Integer)
        ' ''Dim filestreamin As FileStream = New FileStream(srcfile, FileMode.Open, FileAccess.Read)
        ' ''Dim filestreamout As FileStream = New FileStream(dstfile, FileMode.Create, FileAccess.Write)
        ' ''Dim zipoutstream As ZipOutputStream = New ZipOutputStream(filestreamout)
        ' ''Dim buffer As Byte() = New Byte(4095) {}
        ' ''Dim entry As ZipEntry = New ZipEntry(Path.GetFileName(srcfile))
        ' ''zipoutstream.PutNextEntry(entry)
        ' ''Dim size As Integer
        ' ''Do
        ' ''    size = filestreamin.Read(buffer, 0, buffer.Length)
        ' ''    zipoutstream.Write(buffer, 0, size)
        ' ''Loop While size > 0
        ' ''zipoutstream.Close()
        ' ''filestreamout.Close()
        ' ''filestreamin.Close()
    End Sub
End Class
