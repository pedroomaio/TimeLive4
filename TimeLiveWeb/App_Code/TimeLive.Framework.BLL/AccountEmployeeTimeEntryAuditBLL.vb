Imports Microsoft.VisualBasic
Imports AccountEmployeeTimeEntryAuditTableAdapters
''' <summary>
''' This class perform database operations for AccountEmployeeTimeEntryAudit table. AccountEmployeeTimeEntryAudit table 
''' store records for AccountEmployeeTimeEntryAudit data
''' </summary>
''' <remarks>AccountEmployeeTimeEntryAudit Business Layer class</remarks>
<System.ComponentModel.DataObject()> _
Public Class AccountEmployeeTimeEntryAuditBLL
    Private CacheKey As String
    Private _AccountEmployeeTimeEntryPeriodAuditTableAdapter As AccountEmployeeTimeEntryPeriodAuditTableAdapter = Nothing
    Private _AccountEmployeeTimeEntryAuditTableAdapter As AccountEmployeeTimeEntryAuditTableAdapter = Nothing
    ''' <summary>
    ''' Return Adapter object of AccountEmployeeTimeEntryPeriodAuditTableAdapter table adapter
    ''' </summary>
    ''' <value></value>
    ''' <returns>AccountEmployeeTimeEntryPeriodAuditTableAdapter table adapter</returns>
    ''' <remarks></remarks>
    Protected ReadOnly Property AccountEmployeeTimeEntryPeriodAuditAdapter() As AccountEmployeeTimeEntryPeriodAuditTableAdapter
        Get
            If _AccountEmployeeTimeEntryPeriodAuditTableAdapter Is Nothing Then
                _AccountEmployeeTimeEntryPeriodAuditTableAdapter = New AccountEmployeeTimeEntryPeriodAuditTableAdapter()
            End If
            Return _AccountEmployeeTimeEntryPeriodAuditTableAdapter
        End Get
    End Property
    ''' <summary>
    ''' Return Adapter object of AccountEmployeeTimeEntryAuditTableAdapter table adapter
    ''' </summary>
    ''' <value></value>
    ''' <returns>AccountEmployeeTimeEntryAuditTableAdapter table adapter</returns>
    ''' <remarks></remarks>
    Protected ReadOnly Property AccountEmployeeTimeEntryAuditAdapter() As AccountEmployeeTimeEntryAuditTableAdapter
        Get
            If _AccountEmployeeTimeEntryAuditTableAdapter Is Nothing Then
                _AccountEmployeeTimeEntryAuditTableAdapter = New AccountEmployeeTimeEntryAuditTableAdapter()
            End If
            Return _AccountEmployeeTimeEntryAuditTableAdapter
        End Get
    End Property
    ''' <summary>
    ''' Returns all AccountEmployeeTimeEntryPeriodAudit records
    ''' </summary>
    ''' <returns>Returns AccountEmployeeTimeEntryPeriodAudit datatable</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountEmployeeTimeEntryPeriodAudit() As AccountEmployeeTimeEntryAudit.AccountEmployeeTimeEntryPeriodAuditDataTable
        Return AccountEmployeeTimeEntryPeriodAuditAdapter.GetData
    End Function
    ''' <summary>
    ''' Returns all AccountEmployeeTimeEntryPeriodAudit records of specified AccountEmployeeTimeEntryPeriodId.
    ''' </summary>
    ''' <param name="AccountEmployeeTimeEntryPeriodId"></param>
    ''' <returns>AccountEmployeeTimeEntryPeriodAudit datatable</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountEmployeeTimeEntryPeriodAuditByPK(ByVal AccountEmployeeTimeEntryPeriodId As String) As AccountEmployeeTimeEntryAudit.AccountEmployeeTimeEntryPeriodAuditDataTable
        GetAccountEmployeeTimeEntryPeriodAuditByPK = AccountEmployeeTimeEntryPeriodAuditAdapter.GetDataByAccountEmployeeTimeEntryPeriodId(AccountEmployeeTimeEntryPeriodId)
        ' Add an empty row in table, if there is no row found. (ASP.Net GridView workaround)
        UIUtilities.FixTableForNoRecords(GetAccountEmployeeTimeEntryPeriodAuditByPK)
        Return GetAccountEmployeeTimeEntryPeriodAuditByPK
    End Function
    ''' <summary>
    ''' Returns all AccountEmployeeTimeEntryAudit records
    ''' </summary>
    ''' <returns>Returns AccountEmployeeTimeEntryAudit datatable</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountEmployeeTimeEntryAudit() As AccountEmployeeTimeEntryAudit.AccountEmployeeTimeEntryAuditDataTable
        Return AccountEmployeeTimeEntryAuditAdapter.GetData
    End Function
    ''' <summary>
    ''' Returns all AccountEmployeeTimeEntryAudit records of specified AccountEmployeeTimeEntryPeriodId.
    ''' </summary>
    ''' <param name="AccountEmployeeTimeEntryPeriodId"></param>
    ''' <returns>AccountEmployeeTimeEntryAudit datatable</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountEmployeeTimeEntryAuditByPK(ByVal AccountEmployeeTimeEntryPeriodId As Guid) As AccountEmployeeTimeEntryAudit.AccountEmployeeTimeEntryAuditDataTable
        GetAccountEmployeeTimeEntryAuditByPK = AccountEmployeeTimeEntryAuditAdapter.GetDataByAccountEmployeeTimeEntryPeriodId(AccountEmployeeTimeEntryPeriodId)
        ' Add an empty row in table, if there is no row found. (ASP.Net GridView workaround)
        UIUtilities.FixTableForNoRecords(GetAccountEmployeeTimeEntryAuditByPK)
        Return GetAccountEmployeeTimeEntryAuditByPK
    End Function
End Class
