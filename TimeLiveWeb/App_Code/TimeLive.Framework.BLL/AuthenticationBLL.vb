Imports Microsoft.VisualBasic
Imports TimeLiveDataSetTableAdapters
<System.ComponentModel.DataObject()> _
Public Class AuthenticationBLL

    Private _AuthenticationTableAdapter As AuthenticationTableAdapter = Nothing

    Protected ReadOnly Property Adapter() As AuthenticationTableAdapter
        Get
            If _AuthenticationTableAdapter Is Nothing Then
                _AuthenticationTableAdapter = New AuthenticationTableAdapter()
            End If

            Return _AuthenticationTableAdapter
        End Get
    End Property

    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
        Public Function GetAuthentication() As TimeLiveDataSet.AuthenticationDataTable
        Return Adapter.GetData
    End Function

    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAuthenticationByAccount(ByVal AccountId As Integer) As TimeLiveDataSet.AuthenticationDataTable
        Return Adapter.GetDataByAccountId(AccountId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)> _
    Public Function UpdateAuthenticationSetting( _
    ByVal Original_AccountId As Integer, ByVal ActiveDirectoryAuthentication As Double, ByVal Domain As String, _
    ByVal DirectoryName As String) As Boolean

        ' Update the product record

        Dim Authentication As TimeLiveDataSet.AuthenticationDataTable = Adapter.GetDataByAccountId(Original_AccountId)

        Dim AuthenticationRow As TimeLiveDataSet.AuthenticationRow = Authentication.Rows(0)

        With AuthenticationRow
            .ActiveDirectoryAuthentication = ActiveDirectoryAuthentication
            .Domain = Domain
            .DirectoryName = DirectoryName
        End With


        Dim rowsAffected As Integer = Adapter.Update(AuthenticationRow)

        CacheManager.ClearCache("AuthenticationDataTable", , True)

        ' Return true if precisely one row was updated, otherwise false
        Return rowsAffected = 1
    End Function
End Class
