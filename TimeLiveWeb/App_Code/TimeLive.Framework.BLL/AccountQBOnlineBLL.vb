Imports Microsoft.VisualBasic
Imports AccountQBOnlineTableAdapters
Public Class AccountQBOnlineBLL
    Private _AccountQBOnlineLogTableAdapter As AccountQBOnlineLogTableAdapter = Nothing
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected ReadOnly Property Adapter() As AccountQBOnlineLogTableAdapter
        Get
            If _AccountQBOnlineLogTableAdapter Is Nothing Then
                _AccountQBOnlineLogTableAdapter = New AccountQBOnlineLogTableAdapter()
            End If
            Return _AccountQBOnlineLogTableAdapter
        End Get
    End Property
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountQBOnlineLogs() As AccountQBOnline.AccountQBOnlineLogDataTable
        Return Adapter.GetData()
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountQBOnlineLogsAccountId(ByVal AccountId As Integer) As AccountQBOnline.AccountQBOnlineLogDataTable
        GetAccountQBOnlineLogsAccountId = Adapter.GetDataByAccountId(AccountId)
        UIUtilities.FixTableForNoRecords(GetAccountQBOnlineLogsAccountId)
        Return GetAccountQBOnlineLogsAccountId
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, True)> _
    Public Function AddAccountQBOnlineLog( _
                        ByVal AccountId As Integer, ByVal AccountEmployeeId As Integer, ByVal ExecutedDate As DateTime, ByVal EntityName As String, _
                        ByVal QBEntityName As String, ByVal DataDisplayName As String, ByVal ErrorCode As String, ByVal Message As String, ByVal MessageDetail As String _
                    ) As Boolean
        _AccountQBOnlineLogTableAdapter = New AccountQBOnlineLogTableAdapter
        Dim dt As New AccountQBOnline.AccountQBOnlineLogDataTable

        Dim dr As AccountQBOnline.AccountQBOnlineLogRow = dt.NewAccountQBOnlineLogRow

        ' Set all values from parameters to datarow attributes
        With dr
            .AccountQBOnlineLogId = System.Guid.NewGuid()
            .AccountId = AccountId
            .AccountEmployeeId = AccountEmployeeId
            .ExecutedDate = ExecutedDate
            .EntityName = EntityName
            .QBEntityName = QBEntityName
            .DataDisplayName = DataDisplayName
            .ErrorCode = ErrorCode
            .Message = Message
            .MessageDetail = MessageDetail
            .CreatedOn = Now
            .ModifiedOn = Now
        End With

        ' Add new row in datatable
        dt.AddAccountQBOnlineLogRow(dr)

        ' Call adapter update in order to insert record in database table
        Dim rowsAffected As Integer = Adapter.Update(dt)

        ' Return true if precisely one row was inserted, otherwise false
        Return rowsAffected = 1
    End Function
End Class
