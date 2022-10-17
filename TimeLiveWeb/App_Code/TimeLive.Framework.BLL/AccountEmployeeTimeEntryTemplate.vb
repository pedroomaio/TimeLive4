Imports Microsoft.VisualBasic
Imports AccountEmployeeTimeEntryTemplateTableAdapters
Imports System.Data.SqlClient
Imports System.Threading

''' <summary>
''' This class perform database operations for AccountEmployeeTimeEntry table. AccountEmployeeTimeEntry table 
''' store records for Timesheet data
''' </summary>
''' <remarks>AccountEmployeeTimeEntry Business Layer class</remarks>
<System.ComponentModel.DataObject()> _
Public Class AccountEmployeeTimeEntryTemplate
    Private _AccountEmployeeTimeEntryTemplateTableAdapter As AccountEmployeeTimeEntryTemplateTableAdapter = Nothing
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetDataByAccountEmployeeTimeEntryTemplateId(ByVal AccountEmployeeTimeEntryTemplateId As Guid) As AccountEmployeeTimeEntryTemplate.AccountEmployeeTimeEntryTemplateDataTable
        _AccountEmployeeTimeEntryTemplateTableAdapter = New AccountEmployeeTimeEntryTemplateTableAdapter
        Return _AccountEmployeeTimeEntryTemplateTableAdapter.GetDataByAccountEmployeeTimeEntryTemplateId(AccountEmployeeTimeEntryTemplateId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetData() As AccountEmployeeTimeEntryTemplate.AccountEmployeeTimeEntryTemplateDataTable
        _AccountEmployeeTimeEntryTemplateTableAdapter = New AccountEmployeeTimeEntryTemplateTableAdapter
        GetData = _AccountEmployeeTimeEntryTemplateTableAdapter.GetData
        UIUtilities.FixTableForNoRecords(GetData)
        Return GetData
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetDataByAccountEmployeeId(ByVal AccountEmployeeId As Integer) As AccountEmployeeTimeEntryTemplate.AccountEmployeeTimeEntryTemplateDataTable
        _AccountEmployeeTimeEntryTemplateTableAdapter = New AccountEmployeeTimeEntryTemplateTableAdapter
        GetDataByAccountEmployeeId = _AccountEmployeeTimeEntryTemplateTableAdapter.GetDataByAccountEmployeeId(AccountEmployeeId)

        Return AddBlankRowsInDataTable(GetDataByAccountEmployeeId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetDataByAccountEmployeeIdForTimesheet(ByVal AccountEmployeeId As Integer) As AccountEmployeeTimeEntryTemplate.AccountEmployeeTimeEntryTemplateDataTable
        _AccountEmployeeTimeEntryTemplateTableAdapter = New AccountEmployeeTimeEntryTemplateTableAdapter
        Return _AccountEmployeeTimeEntryTemplateTableAdapter.GetDataByAccountEmployeeId(AccountEmployeeId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, True)> _
    Public Function AddAccountEmployeeTimeEntryTemplate( _
                    ByVal AccountEmployeeId As System.Nullable(Of Integer), _
                    ByVal AccountProjectId As Integer, _
                    ByVal AccountProjectTaskId As Integer, _
                    ByVal AccountId As Integer _
                    ) As Integer
        ' Create a new ProductRow instance

        _AccountEmployeeTimeEntryTemplateTableAdapter = New AccountEmployeeTimeEntryTemplateTableAdapter

        Dim dtTimeEntryTemplate As New AccountEmployeeTimeEntryTemplate.AccountEmployeeTimeEntryTemplateDataTable
        Dim drTimeEntryTemplate As AccountEmployeeTimeEntryTemplate.AccountEmployeeTimeEntryTemplateRow = dtTimeEntryTemplate.NewAccountEmployeeTimeEntryTemplateRow

        Dim AccountEmployeeTimeEntryTemplateId As Guid = System.Guid.NewGuid

        With drTimeEntryTemplate
            .AccountEmployeeTimeEntryTemplateId = AccountEmployeeTimeEntryTemplateId
            .AccountId = AccountId
            .AccountEmployeeId = AccountEmployeeId
            .AccountProjectId = AccountProjectId
            .AccountProjectTaskId = AccountProjectTaskId
        End With

        dtTimeEntryTemplate.AddAccountEmployeeTimeEntryTemplateRow(drTimeEntryTemplate)

        ' Add the new product
        Dim rowsAffected As Integer = _AccountEmployeeTimeEntryTemplateTableAdapter.Update(dtTimeEntryTemplate)

        System.Web.HttpContext.Current.Session.Add("AccountEmployeeTimeEntryTemplateId", AccountEmployeeTimeEntryTemplateId)
        ' Return true if precisely one row was inserted, otherwise false
        Return rowsAffected = 1
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)> _
    Public Function UpdateAccountEmployeeTimeEntryTemplate(ByVal AccountEmployeeTimeEntryTemplateId As Guid, ByVal AccountEmployeeId As System.Nullable(Of Integer), _
                    ByVal AccountProjectId As Integer, _
                    ByVal AccountProjectTaskId As Integer, _
                    ByVal AccountId As Integer _
                    ) As Integer
        ' Create a new ProductRow instance

        ' Update the product record
        _AccountEmployeeTimeEntryTemplateTableAdapter = New AccountEmployeeTimeEntryTemplateTableAdapter
        Dim dtTimeEntryTemplate As AccountEmployeeTimeEntryTemplate.AccountEmployeeTimeEntryTemplateDataTable = _AccountEmployeeTimeEntryTemplateTableAdapter.GetDataByAccountEmployeeTimeEntryTemplateId(AccountEmployeeTimeEntryTemplateId)
        Dim drTimeEntryTemplate As AccountEmployeeTimeEntryTemplate.AccountEmployeeTimeEntryTemplateRow = dtTimeEntryTemplate.Rows(0)

        With drTimeEntryTemplate
            .AccountEmployeeTimeEntryTemplateId = AccountEmployeeTimeEntryTemplateId
            .AccountId = AccountId
            .AccountEmployeeId = AccountEmployeeId
            .AccountProjectId = AccountProjectId
            .AccountProjectTaskId = AccountProjectTaskId
        End With

        Dim rowsAffected As Integer = _AccountEmployeeTimeEntryTemplateTableAdapter.Update(dtTimeEntryTemplate)

        ' Return true if precisely one row was updated, otherwise false
        Return rowsAffected = 1
    End Function
    Public Function AddBlankRowsInDataTable(ByVal dtBlank As AccountEmployeeTimeEntryTemplateDataTable) As AccountEmployeeTimeEntryTemplate.AccountEmployeeTimeEntryTemplateDataTable
        '    Dim AccountTimeExpenseBillingTimesheetDatatable As AccountTimeExpenseBilling.AccountTimeExpenseBillingTimesheetDataTable

        Dim detailRow As AccountEmployeeTimeEntryTemplateRow
        For n As Integer = 1 To 5
            detailRow = dtBlank.NewAccountEmployeeTimeEntryTemplateRow
            detailRow.AccountProjectId = 0
            detailRow.AccountProjectTaskId = 0
            detailRow.AccountEmployeeTimeEntryTemplateId = System.Guid.Empty
            detailRow.AccountEmployeeId = 0
            dtBlank.Rows.Add(detailRow)
        Next
        Return dtBlank
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Delete, True)> _
    Public Function DeleteAccountEmployeeTimeEntryTemplate(ByVal Original_AccountEmployeeTimeEntryTemplateId As Guid) As Boolean
        _AccountEmployeeTimeEntryTemplateTableAdapter = New AccountEmployeeTimeEntryTemplateTableAdapter
        Dim rowsAffected As Integer = _AccountEmployeeTimeEntryTemplateTableAdapter.Delete(Original_AccountEmployeeTimeEntryTemplateId)

        ' Return true if precisely one row was deleted, otherwise false
        Return rowsAffected = 1
    End Function

End Class
