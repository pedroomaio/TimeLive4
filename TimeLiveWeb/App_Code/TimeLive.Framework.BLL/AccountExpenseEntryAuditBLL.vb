Imports Microsoft.VisualBasic
Imports AccountExpenseEntryAuditTableAdapters
''' <summary>
''' This class perform database operations for Audit table. Audit table 
''' store records for AccountExpenseEntryAudit data
''' </summary>
''' <remarks></remarks>
<System.ComponentModel.DataObject()> _
Public Class AccountExpenseEntryAuditBLL
    Private CacheKey As String
    Private _AccountEmployeeExpenseSheetAuditTableAdapter As AccountEmployeeExpenseSheetAuditTableAdapter = Nothing
    Private _AccountExpenseEntryAuditAdapter As AccountExpenseEntryAuditTableAdapter = Nothing
    ''' <summary>
    ''' Return AccountEmployeeExpenseSheetAuditAdapter object of AccountEmployeeExpenseSheetAuditTableAdapter table adapter
    ''' </summary>
    ''' <value></value>
    ''' <returns>AccountEmployeeExpenseSheetAuditTableAdapter table adapter</returns>
    ''' <remarks></remarks>
    Protected ReadOnly Property AccountEmployeeExpenseSheetAuditAdapter() As AccountEmployeeExpenseSheetAuditTableAdapter
        Get
            If _AccountEmployeeExpenseSheetAuditTableAdapter Is Nothing Then
                _AccountEmployeeExpenseSheetAuditTableAdapter = New AccountEmployeeExpenseSheetAuditTableAdapter()
            End If
            Return _AccountEmployeeExpenseSheetAuditTableAdapter
        End Get
    End Property
    ''' <summary>
    ''' Return AccountExpenseEntryAuditAdapter object of AccountExpenseEntryAuditTableAdapter table adapter
    ''' </summary>
    ''' <value></value>
    ''' <returns>AccountExpenseEntryAuditAdapter table adapter</returns>
    ''' <remarks></remarks>
    Protected ReadOnly Property AccountExpenseEntryAuditAdapter() As AccountExpenseEntryAuditTableAdapter
        Get
            If _AccountExpenseEntryAuditAdapter Is Nothing Then
                _AccountExpenseEntryAuditAdapter = New AccountExpenseEntryAuditTableAdapter()
            End If
            Return _AccountExpenseEntryAuditAdapter
        End Get
    End Property
    ''' <summary>
    ''' Returns  AccountEmployeeExpenseSheetAudit record of specified AccountEmployeeExpenseSheetId.
    ''' </summary>
    ''' <param name="AccountEmployeeExpenseSheetId"></param>
    ''' <returns>AccountEmployeeExpenseSheetAudit datatable</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountEmployeeExpenseSheetAuditByEmployeeExpenseSheetId(ByVal AccountEmployeeExpenseSheetId As String) As AccountExpenseEntryAudit.AccountEmployeeExpenseSheetAuditDataTable
        GetAccountEmployeeExpenseSheetAuditByEmployeeExpenseSheetId = AccountEmployeeExpenseSheetAuditAdapter.GetDataByAccountEmployeeExpenseSheetId(AccountEmployeeExpenseSheetId, DBUtilities.GetSessionAccountId)
        ' Add an empty row in table, if there is no row found. (ASP.Net GridView workaround)
        UIUtilities.FixTableForNoRecords(GetAccountEmployeeExpenseSheetAuditByEmployeeExpenseSheetId)
        Return GetAccountEmployeeExpenseSheetAuditByEmployeeExpenseSheetId
    End Function
    ''' <summary>
    ''' Returns  AccountExpenseEntryAudit record of specified AccountEmployeeExpenseSheetId.
    ''' </summary>
    ''' <param name="AccountEmployeeExpenseSheetId"></param>
    ''' <returns>AccountExpenseEntryAudit datatable</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountExpenseEntryAuditByEmployeeExpenseSheetId(ByVal AccountEmployeeExpenseSheetId As Guid) As AccountExpenseEntryAudit.AccountExpenseEntryAuditDataTable
        GetAccountExpenseEntryAuditByEmployeeExpenseSheetId = AccountExpenseEntryAuditAdapter.GetDataByAccountEmployeeExpenseSheetId(AccountEmployeeExpenseSheetId, DBUtilities.GetSessionAccountId)
        ' Add an empty row in table, if there is no row found. (ASP.Net GridView workaround)
        UIUtilities.FixTableForNoRecords(GetAccountExpenseEntryAuditByEmployeeExpenseSheetId)
        Return GetAccountExpenseEntryAuditByEmployeeExpenseSheetId
    End Function
End Class
