Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Namespace SystemLicenseTableAdapters
    Public Class SystemLicenseTableAdapter
        Public Function GetPackageCode(PackageCode As String, IsTrakLive As Boolean)
            Dim objConnection As SqlConnection
            objConnection = New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("LiveConnectionString").ConnectionString)
            objConnection.Open()
            Dim sqlCommand As New SqlClient.SqlCommand
            sqlCommand.Connection = objConnection
            Dim strSQL As String = "select * from SystemLicense where PackageCode = " & PackageCode & "and IsTrakLive = " & IsTrakLive
            sqlCommand.CommandText = strSQL
            sqlCommand.CommandTimeout = 1000
            Dim recordsAffected As Integer
            recordsAffected = sqlCommand.ExecuteNonQuery()
            objConnection.Close()
        End Function
    End Class
End Namespace
