Imports Microsoft.VisualBasic
Imports TimeLiveDataSetTableAdapters
Imports AccountExpenseEntryTableAdapters
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
''' <summary>
''' This class perform database operations for AccountExpenseEntry table. AccountExpenseEntry table 
''' store records for Expense Entry data
''' </summary>
''' <remarks>AccountExpenseEntry Business Layer class</remarks>
<System.ComponentModel.DataObject()>
Public Class AccountExpenseEntryBLL
    Private CacheKey As String
    Private _AccountExpenseEntryTableAdapter As AccountExpenseEntryTableAdapter = Nothing
    Private _AccountExpenseEntryApprovalTableAdapter As AccountExpenseEntryApprovalTableAdapter = Nothing
    Private _vueAccountExpenseEntryApprovalPendingTableAdapter As vueAccountExpenseEntryApprovalPendingTableAdapter = Nothing
    Private _vueAccountExpenseEntryWithLastStatusTableAdapter As vueAccountExpenseEntryWithLastStatusTableAdapter = Nothing
    Private _vueAccountExpenseEntryWithLastStatusForMobileTableAdapter As vueAccountExpenseEntryWithLastStatusForMobileTableAdapter = Nothing
    Private _vueAccountExpenseEntryStatusTableAdapter As vueAccountExpenseEntryStatusTableAdapter = Nothing
    ''' <summary>
    ''' Return Adapter object of AccountExpenseEntryTableAdapter table adapter
    ''' </summary>
    ''' <value></value>
    ''' <returns>AccountExpenseEntryTableAdapter table adapter</returns>
    ''' <remarks></remarks>
    Protected ReadOnly Property Adapter() As AccountExpenseEntryTableAdapter
        Get
            If _AccountExpenseEntryTableAdapter Is Nothing Then
                _AccountExpenseEntryTableAdapter = New AccountExpenseEntryTableAdapter()
            End If
            Return _AccountExpenseEntryTableAdapter
        End Get
    End Property
    ''' <summary>
    ''' Return Adapter object of AccountExpenseEntryApprovalTableAdapter table adapter
    ''' </summary>
    ''' <value></value>
    ''' <returns>AccountExpenseEntryApprovalTableAdapter table adapter</returns>
    ''' <remarks></remarks>
    Protected ReadOnly Property AccountExpenseEntryApprovalAdapter() As AccountExpenseEntryApprovalTableAdapter
        Get
            If _AccountExpenseEntryApprovalTableAdapter Is Nothing Then
                _AccountExpenseEntryApprovalTableAdapter = New AccountExpenseEntryApprovalTableAdapter()
            End If
            Return _AccountExpenseEntryApprovalTableAdapter
        End Get
    End Property
    ''' <summary>
    ''' Return Adapter object of vueAccountExpenseEntryApprovalPendingTableAdapter table adapter
    ''' </summary>
    ''' <value></value>
    ''' <returns>vueAccountExpenseEntryApprovalPendingTableAdapter table adapter</returns>
    ''' <remarks></remarks>
    Protected ReadOnly Property vueAccountExpenseEntryApprovalPendingAdapter() As vueAccountExpenseEntryApprovalPendingTableAdapter
        Get
            If _vueAccountExpenseEntryApprovalPendingTableAdapter Is Nothing Then
                _vueAccountExpenseEntryApprovalPendingTableAdapter = New vueAccountExpenseEntryApprovalPendingTableAdapter()
            End If
            Return _vueAccountExpenseEntryApprovalPendingTableAdapter
        End Get
    End Property
    ''' <summary>
    ''' Return Adapter object of vueAccountExpenseEntryWithLastStatusTableAdapter table adapter
    ''' </summary>
    ''' <value></value>
    ''' <returns>vueAccountExpenseEntryWithLastStatusTableAdapter table adapter</returns>
    ''' <remarks></remarks>
    Protected ReadOnly Property vueAccountExpenseEntryWithLastStatusAdapter() As vueAccountExpenseEntryWithLastStatusTableAdapter
        Get
            If _vueAccountExpenseEntryWithLastStatusTableAdapter Is Nothing Then
                _vueAccountExpenseEntryWithLastStatusTableAdapter = New vueAccountExpenseEntryWithLastStatusTableAdapter()
            End If
            Return _vueAccountExpenseEntryWithLastStatusTableAdapter
        End Get
    End Property
    ''' <summary>
    ''' Return Adapter object of vueAccountExpenseEntryForMobileTableAdapter table adapter
    ''' </summary>
    ''' <value></value>
    ''' <returns>vueAccountExpenseEntryForMobileTableAdapter table adapter</returns>
    ''' <remarks></remarks>
    Protected ReadOnly Property vueAccountExpenseEntryWithLastStatusForMobileAdapter() As vueAccountExpenseEntryWithLastStatusForMobileTableAdapter
        Get
            If _vueAccountExpenseEntryWithLastStatusForMobileTableAdapter Is Nothing Then
                _vueAccountExpenseEntryWithLastStatusForMobileTableAdapter = New vueAccountExpenseEntryWithLastStatusForMobileTableAdapter()
            End If
            Return _vueAccountExpenseEntryWithLastStatusForMobileTableAdapter
        End Get
    End Property
    ''' <summary>
    ''' Return Adapter object of vueAccountExpenseEntryStatusTableAdapter table adapter
    ''' </summary>
    ''' <value></value>
    ''' <returns>vueAccountExpenseEntryStatusTableAdapter table adapter</returns>
    ''' <remarks></remarks>
    Protected ReadOnly Property vueAccountExpenseEntryStatusAdapter() As vueAccountExpenseEntryStatusTableAdapter
        Get
            If _vueAccountExpenseEntryStatusTableAdapter Is Nothing Then
                _vueAccountExpenseEntryStatusTableAdapter = New vueAccountExpenseEntryStatusTableAdapter
            End If
            Return _vueAccountExpenseEntryStatusTableAdapter
        End Get
    End Property
    ''' <summary>
    ''' Returns all AccountExpenseEntry records
    ''' </summary>
    ''' <returns>Returns AccountExpenseEntry datatable</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)>
    Public Function GetAccountExpenseEntries() As TimeLiveDataSet.AccountExpenseEntryDataTable
        Return Adapter.GetData
    End Function
    ''' <summary>
    ''' Returns all AccountExpenseEntryApproval records
    ''' </summary>
    ''' <returns>Returns AccountExpenseEntryApproval datatable</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)>
    Public Function GetExpenseApprovals() As TimeLiveDataSet.AccountExpenseEntryApprovalDataTable
        Return AccountExpenseEntryApprovalAdapter.GetData
    End Function
    ''' <summary>
    ''' Returns all vueAccountExpenseEntryApprovalPending records
    ''' </summary>
    ''' <returns>Returns vueAccountExpenseEntryApprovalPending datatable</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)>
    Public Function GetvueAccountExpenseEntryApprovalPendings() As TimeLiveDataSet.vueAccountExpenseEntryApprovalPendingDataTable
        Return vueAccountExpenseEntryApprovalPendingAdapter.GetData
    End Function
    ''' <summary>
    ''' Returns all vueAccountExpenseEntryWithLastStatus records
    ''' </summary>
    ''' <returns>Returns vueAccountExpenseEntryWithLastStatus datatable</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)>
    Public Function GetvueAccountExpenseEntryWithLastStaus() As TimeLiveDataSet.vueAccountExpenseEntryWithLastStatusDataTable
        Return vueAccountExpenseEntryWithLastStatusAdapter.GetData()
    End Function
    ''' <summary>
    ''' Returns all vueAccountExpenseEntryWithLastStatus records of specified AccountId, AccountEmployeeId, 
    ''' AccountExpenseEntryDate and NotFixTable.
    ''' </summary>
    ''' <param name="AccountId"></param>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="AccountExpenseEntryDate"></param>
    ''' <param name="NotFixTable"></param>
    ''' <returns>vueAccountExpenseEntryWithLastStatus datatable</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)>
    Public Function GetvueAccountExpenseEntryWithLastStausByExpenseEntryDate(ByVal AccountId As Integer, ByVal AccountEmployeeId As Integer, ByVal AccountExpenseEntryDate As Date, Optional ByVal NotFixTable As Boolean = False) As TimeLiveDataSet.vueAccountExpenseEntryWithLastStatusDataTable
        GetvueAccountExpenseEntryWithLastStausByExpenseEntryDate = vueAccountExpenseEntryWithLastStatusAdapter.GetDataByExpenseEntryDate(AccountId, AccountEmployeeId, AccountExpenseEntryDate)
        If NotFixTable = False Then
            ' Add an empty row in table, if there is no row found. (ASP.Net GridView workaround)
            UIUtilities.FixTableForNoRecords(GetvueAccountExpenseEntryWithLastStausByExpenseEntryDate)
        End If
        Return GetvueAccountExpenseEntryWithLastStausByExpenseEntryDate
    End Function
    ''' <summary>
    ''' Returns all vueAccountExpenseEntryWithLastStatus records of specified AccountEmployeeExpenseSheetId.
    ''' </summary>
    ''' <param name="AccountEmployeeExpenseSheetId"></param>
    ''' <returns>vueAccountExpenseEntryWithLastStatus datatable</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)>
    Public Function GetvueAccountExpenseEntryWithLastStausByEmployeeExpenseSheetId(ByVal AccountEmployeeExpenseSheetId As Guid) As TimeLiveDataSet.vueAccountExpenseEntryWithLastStatusDataTable
        GetvueAccountExpenseEntryWithLastStausByEmployeeExpenseSheetId = vueAccountExpenseEntryWithLastStatusAdapter.GetDataByAccountEmployeeExpenseSheetId(DBUtilities.GetSessionAccountId, AccountEmployeeExpenseSheetId)
        ' Add an empty row in table, if there is no row found. (ASP.Net GridView workaround)
        UIUtilities.FixTableForNoRecords(GetvueAccountExpenseEntryWithLastStausByEmployeeExpenseSheetId)
        Return GetvueAccountExpenseEntryWithLastStausByEmployeeExpenseSheetId
    End Function

    Public Function GetDataForEntryArchivePopUp(ByVal filter As EntryArchiveFilter) As TimeLiveDataSet.vueAccountExpenseEntryWithLastStatusDataTable
        GetDataForEntryArchivePopUp = vueAccountExpenseEntryWithLastStatusAdapter.GetDataByAccountEmployeeExpenseSheetId(DBUtilities.GetSessionAccountId, filter.ExpenseSheetId.FirstOrDefault)
        ' Add an empty row in table, if there is no row found. (ASP.Net GridView workaround)
        UIUtilities.FixTableForNoRecords(GetDataForEntryArchivePopUp)
        Return GetDataForEntryArchivePopUp
    End Function

    Public Function GetDataForEntryArchivePopUpFiltred(ByVal filter As EntryArchiveFilter) As TimeLiveDataSet.vueAccountExpenseEntryWithLastStatusDataTable
        GetDataForEntryArchivePopUpFiltred = GetDataForEntryArchivePopUpFiltredSqlCommand(filter)
        ' Add an empty row in table, if there is no row found. (ASP.Net GridView workaround)
        UIUtilities.FixTableForNoRecords(GetDataForEntryArchivePopUpFiltred)
        Return GetDataForEntryArchivePopUpFiltred
    End Function

    Public Function GetDataForEntryArchivePopUpFiltredSqlCommand(ByVal filter As EntryArchiveFilter) As TimeLiveDataSet.vueAccountExpenseEntryWithLastStatusDataTable
        Dim sql As String = ""
        Dim adapterVue As New SqlDataAdapter
        Dim connection As New SqlConnection
        connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings("LiveConnectionString").ConnectionString
        adapterVue.SelectCommand = New SqlCommand("", connection)

        sql = sql + "DECLARE @TableOfSheets table(ExpenseEntryid int) "

        sql = sql + "Insert into @TableOfSheets "
        sql = sql + "Select AccountExpenseEntryid from AccountExpenseEntry a where "

        sql = sql + " (AccountId = @AccountId) and "

        adapterVue.SelectCommand.Parameters.Add("@AccountId", SqlDbType.Int)
        adapterVue.SelectCommand.Parameters("@AccountId").Value = 354

        If filter.AccountEmployeeId <> 0 Then
            sql = sql + "AccountEmployeeId = @AccountEmployeeId and "

            adapterVue.SelectCommand.Parameters.Add("@AccountEmployeeId", SqlDbType.Int)
            adapterVue.SelectCommand.Parameters("@AccountEmployeeId").Value = filter.AccountEmployeeId
        End If

        sql = sql + "("

        If filter.IncludeDataRange = True Then
            sql = sql + "(AccountExpenseEntryDate >= @AccountExpenseEntryStartDate and AccountExpenseEntryDate <= @AccountExpenseEntryEndDate) and "

            adapterVue.SelectCommand.Parameters.Add("@AccountExpenseEntryStartDate", SqlDbType.DateTime)
            adapterVue.SelectCommand.Parameters("@AccountExpenseEntryStartDate").Value = filter.StartDate

            adapterVue.SelectCommand.Parameters.Add("@AccountExpenseEntryEndDate", SqlDbType.DateTime)
            adapterVue.SelectCommand.Parameters("@AccountExpenseEntryEndDate").Value = filter.EndDate
        End If

        If filter.Approved = -1 Then
            sql = sql + "(Approved = Approved) "
        ElseIf filter.Approved = 0 Then
            sql = sql + "(Approved <> 1) "
        ElseIf filter.Approved = 1 Then
            sql = sql + "(Approved = 1) "
        End If

        adapterVue.SelectCommand.Parameters.Add("@Approval", SqlDbType.VarChar)
        adapterVue.SelectCommand.Parameters("@Approval").Value = filter.Approved

        sql = sql + ")"

        If filter.ExpenseTypes IsNot "" Then
            sql = sql + "and AccountExpenseId IN((Select AccountExpenseId from AccountExpense "
            sql = sql + "expense Where ','+@ExpenseTypes+',' LIKE '%,'"
            sql = sql + "+CAST(AccountExpenseTypeId AS varchar)+',%'))"
        End If

        adapterVue.SelectCommand.Parameters.Add("@ExpenseTypes", SqlDbType.NVarChar)
        adapterVue.SelectCommand.Parameters("@ExpenseTypes").Value = filter.ExpenseTypes

        Dim SpaceValues() As String = Split(" "c)

        If SpaceValues.Length >= 1 Then
            If SpaceValues(SpaceValues.Length - 1).Trim(" ") <> "and" Then
                sql = sql + " and "
            End If
        End If

        sql = sql + " PaymentStatusId = @PaymentStatusId "

        Dim params As New List(Of String)

        For index = 0 To filter.ExpenseSheetId.Count - 1
            params.Add("@Sheetparam" + index.ToString())
        Next

        If filter.ExpenseSheetId.Count >= 1 Then
            sql = sql + " And AccountEmployeeExpenseSheetId in(" + String.Join(",", params) + ") "
        End If

        adapterVue.SelectCommand.Parameters.Add("@PaymentStatusId", SqlDbType.Int)
        adapterVue.SelectCommand.Parameters("@PaymentStatusId").Value = filter.PaymentStatusId

        For index = 0 To filter.ExpenseSheetId.Count - 1
            adapterVue.SelectCommand.Parameters.Add(params(index), SqlDbType.NVarChar)
            adapterVue.SelectCommand.Parameters(params(index)).Value = filter.ExpenseSheetId(index).ToString()
        Next


        sql = sql + "Select * from vueAccountExpenseEntryWithLastStatus b "
        sql = sql + "Right join @TableOfSheets a On b.AccountExpenseEntryid = a.ExpenseEntryid"

        adapterVue.SelectCommand.CommandText = sql

        Dim dt As New DataTable
        adapterVue.Fill(dt)
        dt.Columns.Remove("ExpenseEntryId")

        Dim datatable As TimeLiveDataSet.vueAccountExpenseEntryWithLastStatusDataTable = New TimeLiveDataSet.vueAccountExpenseEntryWithLastStatusDataTable
        datatable.Merge(dt)
        Return datatable

    End Function

    Public Sub UpdatePaymentStatusOfEntrys(ByVal dt As TimeLiveDataSet.vueAccountExpenseEntryWithLastStatusDataTable, ByVal UpdateTo As Integer)

        Dim sql As String = ""
        Dim adapterVue As New SqlDataAdapter
        Dim connection As New SqlConnection
        connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings("LiveConnectionString").ConnectionString
        adapterVue.UpdateCommand = New SqlCommand("", connection)

        sql = sql + "Update AccountExpenseEntry "
        sql = sql + "SET PaymentStatusId = @paymentstatus "

        adapterVue.UpdateCommand.Parameters.Add("@paymentstatus", SqlDbType.Int)
        adapterVue.UpdateCommand.Parameters("@paymentstatus").Value = UpdateTo

        Dim params As New List(Of String)

        For index = 0 To dt.Rows.Count - 1
            params.Add("@Entryparam" + index.ToString())
        Next

        If dt.Rows.Count >= 1 Then
            sql = sql + "Where AccountExpenseEntryId in(" + String.Join(",", params) + ") "
        End If

        For index = 0 To dt.Rows.Count - 1
            adapterVue.UpdateCommand.Parameters.Add(params(index), SqlDbType.Int)
            adapterVue.UpdateCommand.Parameters(params(index)).Value = dt.Rows(index)("AccountExpenseEntryId").ToString()
        Next

        adapterVue.UpdateCommand.CommandText = sql

        connection.Open()
        Dim rowsaffected = adapterVue.UpdateCommand.ExecuteNonQuery()
        connection.Close()

    End Sub

    Public Sub UpdatePaymentStatusOfEntrys(ByVal entrys As List(Of Integer), ByVal UpdateTo As Integer)

        Dim sql As String = ""
        Dim adapterVue As New SqlDataAdapter
        Dim connection As New SqlConnection
        connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings("LiveConnectionString").ConnectionString
        adapterVue.UpdateCommand = New SqlCommand("", connection)

        sql = sql + "Update AccountExpenseEntry "
        sql = sql + "SET PaymentStatusId = @paymentstatus "

        adapterVue.UpdateCommand.Parameters.Add("@paymentstatus", SqlDbType.Int)
        adapterVue.UpdateCommand.Parameters("@paymentstatus").Value = UpdateTo

        Dim params As New List(Of String)

        For index = 0 To entrys.Count - 1
            params.Add("@Entryparam" + index.ToString())
        Next

        If entrys.Count >= 1 Then
            sql = sql + "Where AccountExpenseEntryId in(" + String.Join(",", params) + ") "
        End If

        For index = 0 To entrys.Count - 1
            adapterVue.UpdateCommand.Parameters.Add(params(index), SqlDbType.Int)
            adapterVue.UpdateCommand.Parameters(params(index)).Value = entrys(index).ToString()
        Next

        adapterVue.UpdateCommand.CommandText = sql

        connection.Open()
        Dim rowsaffected = adapterVue.UpdateCommand.ExecuteNonQuery()
        connection.Close()

    End Sub

    Public Sub UpdatePaymentStatusOfExpenseSheet(ByVal Sheet As Guid)

        Dim sql As String = ""
        Dim adapterVue As New SqlDataAdapter
        Dim connection As New SqlConnection
        connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings("LiveConnectionString").ConnectionString
        adapterVue.UpdateCommand = New SqlCommand("", connection)

        sql = sql + "Update AccountEmployeeExpenseSheet "
        sql = sql + "SET PaymentStatusId = (Select Min(PaymentStatusId) From AccountExpenseEntry entrys Where entrys.AccountEmployeeExpenseSheetId = @Sheet) "
        sql = sql + "Where AccountEmployeeExpenseSheetId = @Sheet"

        adapterVue.UpdateCommand.Parameters.Add("@Sheet", SqlDbType.UniqueIdentifier)
        adapterVue.UpdateCommand.Parameters("@Sheet").Value = Sheet

        adapterVue.UpdateCommand.CommandText = sql

        connection.Open()
        Dim rowsaffected = adapterVue.UpdateCommand.ExecuteNonQuery()
        connection.Close()

    End Sub

    Public Function GetCountOfPaymentStatus(ByVal Sheet As Guid) As EntryArchivePaymentStatusInfo

        Dim sql As String = ""
        Dim adapterVue As New SqlDataAdapter
        Dim connection As New SqlConnection
        connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings("LiveConnectionString").ConnectionString
        adapterVue.SelectCommand = New SqlCommand("", connection)

        sql = sql + "Select ReadyToPay = "
        sql = sql + "(Select Count(*) From AccountExpenseEntry entrys Where entrys.AccountEmployeeExpenseSheetId = @Sheet And PaymentStatusId = 1) "
        sql = sql + ", Paid = "
        sql = sql + "(Select Count(*) From AccountExpenseEntry entrys Where entrys.AccountEmployeeExpenseSheetId = @Sheet And PaymentStatusId = 2) "
        sql = sql + ", Total = "
        sql = sql + "(Select Count(*) From AccountExpenseEntry entrys Where entrys.AccountEmployeeExpenseSheetId = @Sheet) "

        adapterVue.SelectCommand.Parameters.Add("@Sheet", SqlDbType.UniqueIdentifier)
        adapterVue.SelectCommand.Parameters("@Sheet").Value = Sheet

        adapterVue.SelectCommand.CommandText = sql

        Dim nr As Integer

        Dim dt As New DataTable
        dt.Columns.Add("ReadyToPay", nr.GetType())
        dt.Columns.Add("Paid", nr.GetType())
        dt.Columns.Add("Total", nr.GetType())

        adapterVue.Fill(dt)

        Dim returnModel As New EntryArchivePaymentStatusInfo

        If dt.Rows.Count = 1 Then
            returnModel.ReadyToPay = CType(dt.Rows(0)("ReadyToPay"), Integer)
            returnModel.Paid = CType(dt.Rows(0)("Paid"), Integer)
            returnModel.Total = CType(dt.Rows(0)("Total"), Integer)
        End If

        Return returnModel

    End Function

    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)>
    Public Function GetvueAccountExpenseEntryWithLastStatusByExpenseSheetIdForMobile(ByVal AccountId As Integer, ByVal AccountEmployeeExpenseSheetId As Guid) As TimeLiveDataSet.vueAccountExpenseEntryWithLastStatusForMobileDataTable
        GetvueAccountExpenseEntryWithLastStatusByExpenseSheetIdForMobile = vueAccountExpenseEntryWithLastStatusForMobileAdapter.GetDataByAccountEmployeeExpenseSheetIdForMobile(AccountId, AccountEmployeeExpenseSheetId)
        ' Add an empty row in table, if there is no row found. (ASP.Net GridView workaround)
        'UIUtilities.FixTableForNoRecords(GetvueAccountExpenseEntryWithLastStatusByExpenseSheetIdForMobile)
        Return GetvueAccountExpenseEntryWithLastStatusByExpenseSheetIdForMobile
    End Function
    ''' <summary>
    ''' Returns all AccountExpenseEntry records of specified AccountId, AccountEmployeeId and AccountExpenseEntryDate.
    ''' </summary>
    ''' <param name="AccountId"></param>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="AccountExpenseEntryDate"></param>
    ''' <returns>AccountExpenseEntry datatable</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)>
    Public Function GetAccountExpenseEntriesByAccountExpenseEntryDate(ByVal AccountId As Integer, ByVal AccountEmployeeId As Integer, ByVal AccountExpenseEntryDate As Date) As TimeLiveDataSet.AccountExpenseEntryDataTable
        Return Adapter.GetDataByAccountExpenseEntryDate(AccountId, AccountEmployeeId, AccountExpenseEntryDate)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)>
    Public Function GetAccountExpenseEntriesByAccountIdAndDatabaseFieldName(ByVal AccountId As Integer, ByVal DatabaseFieldName As String) As TimeLiveDataSet.AccountExpenseEntryDataTable
        Return Adapter.GetDataByAccountIdAndDatabaseFieldName(AccountId, DatabaseFieldName)
    End Function
    ''' <summary>
    ''' Returns all AccountExpenseEntry records of specified AccountId.
    ''' </summary>
    ''' <param name="AccountId"></param>
    ''' <returns>AccountExpenseEntry datatable</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)>
    Public Function GetAccountExpenseEntriesByAccountId(ByVal AccountId As Integer) As TimeLiveDataSet.AccountExpenseEntryDataTable
        Return Adapter.GetDataByAccountId(AccountId)
    End Function
    ''' <summary>
    ''' Returns all AccountExpenseEntry records of specified AccountExpenseEntryId.
    ''' </summary>
    ''' <param name="AccountExpenseEntryId"></param>
    ''' <returns>AccountExpenseEntry datatable</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)>
    Public Function GetAccountExpenseEntriesByAccountExpenseEntryId(ByVal AccountExpenseEntryId As Integer) As TimeLiveDataSet.AccountExpenseEntryDataTable
        Return Adapter.GetDataByAccountExpenseEntryId(AccountExpenseEntryId)
    End Function
    ''' <summary>
    ''' Returns all AccountExpenseEntry records of specified AccountId and AccountExpenseEntryDate.
    ''' </summary>
    ''' <param name="AccountId"></param>
    ''' <param name="AccountExpenseEntryDate"></param>
    ''' <returns>AccountExpenseEntry datatable</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)>
    Public Function GetAccountExpenseEntriesByAccountIdAndAccountExpenseEntryDate(ByVal AccountId As Integer, ByVal AccountExpenseEntryDate As DateTime) As TimeLiveDataSet.AccountExpenseEntryDataTable
        Return Adapter.GetDataByAccountIdAndAccountExpenseEntryDate(AccountId, AccountExpenseEntryDate)
    End Function
    ''' <summary>
    ''' Returns all vueAccountExpenseEntry records of specified AccountId, AccountEmployeeId, AccountExpenseEntryDate and NotFixTable.
    ''' </summary>
    ''' <param name="AccountId"></param>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="AccountExpenseEntryDate"></param>
    ''' <param name="NotFixTable"></param>
    ''' <returns>vueAccountExpenseEntry datatable</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)>
    Public Function GetvueAccountExpenseEntriesByAccountExpenseEntryDate(ByVal AccountId As Integer, ByVal AccountEmployeeId As Integer, ByVal AccountExpenseEntryDate As Date, Optional ByVal NotFixTable As Boolean = False) As TimeLiveDataSet.vueAccountExpenseEntryDataTable
        Dim _vueAccountExpenseEntryTableAdapter As New vueAccountExpenseEntryTableAdapter
        GetvueAccountExpenseEntriesByAccountExpenseEntryDate = _vueAccountExpenseEntryTableAdapter.GetDataByAccountExpenseEntryDate(AccountId, AccountEmployeeId, AccountExpenseEntryDate)
        If NotFixTable = False Then
            ' Add an empty row in table, if there is no row found. (ASP.Net GridView workaround)
            UIUtilities.FixTableForNoRecords(GetvueAccountExpenseEntriesByAccountExpenseEntryDate)
        End If
        Return GetvueAccountExpenseEntriesByAccountExpenseEntryDate
    End Function
    ''' <summary>
    ''' Returns all vueAccountExpenseEntry records of specified AccountExpenseEntryId.
    ''' </summary>
    ''' <param name="AccountExpenseEntryId"></param>
    ''' <returns>vueAccountExpenseEntry datatable</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)>
    Public Function GetvueAccountExpenseEntriesByAccountExpenseEntryId(ByVal AccountExpenseEntryId As Integer) As TimeLiveDataSet.vueAccountExpenseEntryDataTable
        Dim _vueAccountExpenseEntryTableAdapter As New vueAccountExpenseEntryTableAdapter
        GetvueAccountExpenseEntriesByAccountExpenseEntryId = _vueAccountExpenseEntryTableAdapter.GetDataByAccountExpenseEntryId(AccountExpenseEntryId)
        Return GetvueAccountExpenseEntriesByAccountExpenseEntryId
    End Function
    ''' <summary>
    ''' Returns all vueAccountExpenseEntry records of specified AccountExpenseEntryId.
    ''' </summary>
    ''' <param name="AccountExpenseEntryId"></param>
    ''' <returns>vueAccountExpenseEntry datatable</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)>
    Public Function GetvueAccountExpenseEntriesByAccountExpenseEntryIdForMobile(ByVal AccountExpenseEntryId As Integer) As AccountExpenseEntry.vueAccountExpenseEntryForMobileDataTable
        Dim _vueAccountExpenseEntryForMobileTableAdapter As New vueAccountExpenseEntryForMobileTableAdapter
        GetvueAccountExpenseEntriesByAccountExpenseEntryIdForMobile = _vueAccountExpenseEntryForMobileTableAdapter.GetDataByAccountExpenseEntryId(AccountExpenseEntryId)
        Return GetvueAccountExpenseEntriesByAccountExpenseEntryIdForMobile
    End Function
    ''' <summary>
    ''' Returns all vueAccountExpenseEntry records of specified AccountId and AccountExpenseEntryId.
    ''' </summary>
    ''' <param name="AccountId"></param>
    ''' <param name="AccountExpenseId"></param>
    ''' <returns>vueAccountExpenseEntry datatable</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)>
    Public Function GetvueAccountExpenseEntriesByAccountIdAndAccountExpenseId(ByVal AccountId As Integer, ByVal AccountExpenseId As Integer) As TimeLiveDataSet.vueAccountExpenseEntryDataTable
        Dim _vueAccountExpenseEntryTableAdapter As New vueAccountExpenseEntryTableAdapter
        GetvueAccountExpenseEntriesByAccountIdAndAccountExpenseId = _vueAccountExpenseEntryTableAdapter.GetDataByAccountIdAndAccountExpenseId(AccountId, AccountExpenseId)
        Return GetvueAccountExpenseEntriesByAccountIdAndAccountExpenseId
    End Function
    ''' <summary>
    ''' Returns all vueAccountExpenseEntryForDetailExpenseReport records of specified AccountId, AccountEmployees, AccountProjectId, AccountClientId,
    ''' IncludeDateRange, AccountExpenseEntryStartDate, AccountExpenseEntryEndDate, Approval and Billable.
    ''' </summary>
    ''' <param name="AccountId"></param>
    ''' <param name="AccountEmployees"></param>
    ''' <param name="AccountProjectId"></param>
    ''' <param name="AccountClientId"></param>
    ''' <param name="IncludeDateRange"></param>
    ''' <param name="AccountExpenseEntryStartDate"></param>
    ''' <param name="AccountExpenseEntryEndDate"></param>
    ''' <param name="Approval"></param>
    ''' <param name="Billable"></param>
    ''' <returns>vueAccountExpenseEntryForDetailExpenseReport datatable</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)>
    Public Function GetDataForDetailExpenseReport(ByVal AccountId As Integer, ByVal AccountEmployees As String, ByVal AccountProjectId As Integer, ByVal AccountClientId As Long, ByVal IncludeDateRange As Boolean, ByVal AccountExpenseEntryStartDate As Date, ByVal AccountExpenseEntryEndDate As Date, ByVal Approval As String, ByVal Billable As String) As TimeLiveDataSet.vueAccountExpenseEntryForDetailExpenseReportDataTable
        Dim _vueAccountExpenseEntryForDetailExpenseReportTableAdapter As New vueAccountExpenseEntryForDetailExpenseReportTableAdapter
        Return _vueAccountExpenseEntryForDetailExpenseReportTableAdapter.GetDataByAccountIdAndEmployees(AccountId, AccountEmployees, AccountProjectId, AccountClientId, IncludeDateRange, AccountExpenseEntryStartDate, AccountExpenseEntryEndDate, Approval, Billable)
    End Function
    ''' <summary>
    ''' Returns all vueAccountExpenseEntryForDetailExpenseReport records of specified AccountId, AccountEmployees, AccountProjectId, AccountClientId,
    ''' IncludeDateRange, AccountExpenseEntryStartDate, AccountExpenseEntryEndDate, Approval and Billable.
    ''' </summary>
    ''' <param name="AccountId"></param>
    ''' <param name="AccountEmployees"></param>
    ''' <param name="AccountProjectId"></param>
    ''' <param name="AccountClientId"></param>
    ''' <param name="AccountExpenseEntryStartDate"></param>
    ''' <param name="AccountExpenseEntryEndDate"></param>
    ''' <param name="Approval"></param>
    ''' <param name="Billable"></param>
    ''' <returns>vueAccountExpenseEntryForDetailExpenseReport datatable</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)>
    Public Function GetDataForDetailExpenseReportForProjectSummaryReport(ByVal AccountId As Integer, ByVal AccountEmployees As String, ByVal AccountProjectId As Integer, ByVal AccountClientId As Long, ByVal AccountExpenseEntryStartDate As Date, ByVal AccountExpenseEntryEndDate As Date, ByVal Approval As String, ByVal Billable As String) As TimeLiveDataSet.vueAccountExpenseEntryForDetailExpenseReportDataTable
        Dim _vueAccountExpenseEntryForDetailExpenseReportTableAdapter As New vueAccountExpenseEntryForDetailExpenseReportTableAdapter
        Return _vueAccountExpenseEntryForDetailExpenseReportTableAdapter.GetDataByAccountIdAndEmployeesForProjectSummaryReport(AccountId, AccountEmployees, AccountProjectId, AccountClientId, AccountExpenseEntryStartDate, AccountExpenseEntryEndDate, Approval, Billable)
    End Function
    ''' <summary>
    ''' Returns all vueAccountExpenseEntryForDetailExpenseReport records of specified AccountId, AccountEmployees, AccountProjectId, AccountClientId,
    ''' IncludeDateRange, AccountExpenseEntryStartDate, AccountExpenseEntryEndDate, Approval and Billable.
    ''' </summary>
    ''' <param name="AccountId"></param>
    ''' <param name="AccountEmployees"></param>
    ''' <param name="AccountProjectId"></param>
    ''' <param name="AccountClientId"></param>
    ''' <param name="IncludeDateRange"></param>
    ''' <param name="AccountExpenseEntryStartDate"></param>
    ''' <param name="AccountExpenseEntryEndDate"></param>
    ''' <param name="Approval"></param>
    ''' <param name="Billable"></param>
    ''' <returns>vueAccountExpenseEntryForDetailExpenseReport datatable</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)>
    Public Function GetDataForDetailExpenseReportForExpenseEntryArchive(ByVal AccountId As Integer, ByVal AccountEmployees As String, ByVal AccountProjectId As Integer, ByVal AccountClientId As Long, ByVal IncludeDateRange As Boolean, ByVal AccountExpenseEntryStartDate As Date, ByVal AccountExpenseEntryEndDate As Date, ByVal Approval As String, ByVal Billable As String) As TimeLiveDataSet.vueAccountExpenseEntryForDetailExpenseReportDataTable
        Dim _vueAccountExpenseEntryForDetailExpenseReportTableAdapter As New vueAccountExpenseEntryForDetailExpenseReportTableAdapter
        Return _vueAccountExpenseEntryForDetailExpenseReportTableAdapter.GetDataByAccountIdAndEmployeesForExpenseEntryArchive(AccountId, AccountEmployees, AccountProjectId, AccountClientId, IncludeDateRange, AccountExpenseEntryStartDate, AccountExpenseEntryEndDate, Approval, Billable)
    End Function
    ''' <summary>
    ''' Returns all vueAccountExpenseEntryApprovalPending records of specified AccountProjectId, AccountEmployeeId, ExpenseEntryAccountEmployeeId, 
    ''' ExpenseEntryStartDate, ExpenseEntryEndDate, IncludeDateRange and AccountEmployeeExpenseSheetId.
    ''' </summary>
    ''' <param name="AccountProjectId"></param>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="ExpenseEntryAccountEmployeeId"></param>
    ''' <param name="ExpenseEntryStartDate"></param>
    ''' <param name="ExpenseEntryEndDate"></param>
    ''' <param name="IncludeDateRange"></param>
    ''' <param name="AccountEmployeeExpenseSheetId"></param>
    ''' <returns>vueAccountExpenseEntryApprovalPending datatable</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)>
    Public Function GetApprovalEntriesForTeamLeadForMobile(ByVal AccountProjectId As Integer, ByVal AccountEmployeeId As Integer, ByVal ExpenseEntryAccountEmployeeId As Integer, ByVal ExpenseEntryStartDate As Date, ByVal ExpenseEntryEndDate As Date, ByVal IncludeDateRange As Boolean, ByVal AccountEmployeeExpenseSheetId As Guid) As TimeLiveDataSet.vueAccountExpenseEntryApprovalPendingDataTable
        Dim _vueAccountExpenseEntryApprovalPendingTableAdapter As New vueAccountExpenseEntryApprovalPendingTableAdapter
        Return _vueAccountExpenseEntryApprovalPendingTableAdapter.GetApprovalEntriesForTeamLeadForMobile(ExpenseEntryAccountEmployeeId, IncludeDateRange, ExpenseEntryStartDate, ExpenseEntryEndDate, AccountEmployeeId, AccountProjectId, AccountEmployeeExpenseSheetId)
    End Function
    ''' <summary>
    ''' Returns all vueAccountExpenseEntryApprovalPending records of specified AccountProjectId, AccountEmployeeId, ExpenseEntryAccountEmployeeId, 
    ''' ExpenseEntryStartDate, ExpenseEntryEndDate, IncludeDateRange and AccountEmployeeExpenseSheetId.
    ''' </summary>
    ''' <param name="AccountProjectId"></param>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="ExpenseEntryAccountEmployeeId"></param>
    ''' <param name="ExpenseEntryStartDate"></param>
    ''' <param name="ExpenseEntryEndDate"></param>
    ''' <param name="IncludeDateRange"></param>
    ''' <param name="AccountEmployeeExpenseSheetId"></param>
    ''' <returns>vueAccountExpenseEntryApprovalPending datatable</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)>
    Public Function GetApprovalEntriesForTeamLead(ByVal AccountProjectId As Integer, ByVal AccountEmployeeId As Integer, ByVal ExpenseEntryAccountEmployeeId As Integer, ByVal ExpenseEntryStartDate As Date, ByVal ExpenseEntryEndDate As Date, ByVal IncludeDateRange As Boolean, ByVal AccountEmployeeExpenseSheetId As Guid) As TimeLiveDataSet.vueAccountExpenseEntryApprovalPendingDataTable
        Dim _vueAccountExpenseEntryApprovalPendingTableAdapter As New vueAccountExpenseEntryApprovalPendingTableAdapter
        Return _vueAccountExpenseEntryApprovalPendingTableAdapter.GetApprovalEntriesForTeamLead1(ExpenseEntryAccountEmployeeId, IncludeDateRange, ExpenseEntryStartDate, ExpenseEntryEndDate, AccountEmployeeId, AccountProjectId, AccountEmployeeExpenseSheetId)
    End Function
    ''' <summary>
    ''' Returns all vueAccountExpenseEntryApprovalPending records of specified AccountProjectId, AccountEmployeeId, ExpenseEntryAccountEmployeeId, 
    ''' ExpenseEntryStartDate, ExpenseEntryEndDate, IncludeDateRange and AccountEmployeeExpenseSheetId.
    ''' </summary>
    ''' <param name="AccountProjectId"></param>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="ExpenseEntryAccountEmployeeId"></param>
    ''' <param name="ExpenseEntryStartDate"></param>
    ''' <param name="ExpenseEntryEndDate"></param>
    ''' <param name="IncludeDateRange"></param>
    ''' <param name="AccountEmployeeExpenseSheetId"></param>
    ''' <returns>vueAccountExpenseEntryApprovalPending datatable</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)>
    Public Function GetApprovalEntriesForProjectManager(ByVal AccountProjectId As Integer, ByVal AccountEmployeeId As Integer, ByVal ExpenseEntryAccountEmployeeId As Integer, ByVal ExpenseEntryStartDate As Date, ByVal ExpenseEntryEndDate As Date, ByVal IncludeDateRange As Boolean, ByVal AccountEmployeeExpenseSheetId As Guid) As TimeLiveDataSet.vueAccountExpenseEntryApprovalPendingDataTable
        Dim _vueAccountExpenseEntryApprovalPendingTableAdapter As New vueAccountExpenseEntryApprovalPendingTableAdapter
        Return _vueAccountExpenseEntryApprovalPendingTableAdapter.GetApprovalEntriesForProjectManager1(ExpenseEntryAccountEmployeeId, IncludeDateRange, ExpenseEntryStartDate, ExpenseEntryEndDate, AccountEmployeeId, AccountProjectId, AccountEmployeeExpenseSheetId)
    End Function
    ''' <summary>
    ''' Returns all vueAccountExpenseEntryApprovalPending records of specified AccountProjectId, AccountEmployeeId, ExpenseEntryAccountEmployeeId, 
    ''' ExpenseEntryAccountEmployeeId, ExpenseEntryStartDate, ExpenseEntryEndDate, IncludeDateRange and AccountEmployeeExpenseSheetId.
    ''' </summary>
    ''' <param name="AccountProjectId"></param>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="ExpenseEntryAccountEmployeeId"></param>
    ''' <param name="ExpenseEntryStartDate"></param>
    ''' <param name="ExpenseEntryEndDate"></param>
    ''' <param name="IncludeDateRange"></param>
    ''' <param name="AccountEmployeeExpenseSheetId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)>
    Public Function GetApprovalEntriesForSpecificEmployee(ByVal AccountProjectId As Integer, ByVal AccountEmployeeId As Integer, ByVal ExpenseEntryAccountEmployeeId As Integer, ByVal ExpenseEntryStartDate As Date, ByVal ExpenseEntryEndDate As Date, ByVal IncludeDateRange As Boolean, ByVal AccountEmployeeExpenseSheetId As Guid) As TimeLiveDataSet.vueAccountExpenseEntryApprovalPendingDataTable
        Dim _vueAccountExpenseEntryApprovalPendingTableAdapter As New vueAccountExpenseEntryApprovalPendingTableAdapter
        Return _vueAccountExpenseEntryApprovalPendingTableAdapter.GetApprovalEntriesForSpecificEmployee1(ExpenseEntryAccountEmployeeId, IncludeDateRange, ExpenseEntryStartDate, ExpenseEntryEndDate, AccountEmployeeId, AccountProjectId, AccountEmployeeExpenseSheetId)
    End Function
    ''' <summary>
    ''' Returns all vueAccountExpenseEntryApprovalPending records of specified AccountProjectId, AccountEmployeeId, ExpenseEntryAccountEmployeeId, 
    ''' ExpenseEntryAccountEmployeeId, ExpenseEntryStartDate, ExpenseEntryEndDate, IncludeDateRange and AccountEmployeeExpenseSheetId.
    ''' </summary>
    ''' <param name="AccountProjectId"></param>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="ExpenseEntryAccountEmployeeId"></param>
    ''' <param name="ExpenseEntryStartDate"></param>
    ''' <param name="ExpenseEntryEndDate"></param>
    ''' <param name="IncludeDateRange"></param>
    ''' <param name="AccountEmployeeExpenseSheetId"></param>
    ''' <returns>AccountEmployeeTimeEntry</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)>
    Public Function GetApprovalEntriesForSpecificExternalUser(ByVal AccountProjectId As Integer, ByVal AccountEmployeeId As Integer, ByVal ExpenseEntryAccountEmployeeId As Integer, ByVal ExpenseEntryStartDate As Date, ByVal ExpenseEntryEndDate As Date, ByVal IncludeDateRange As Boolean, ByVal AccountEmployeeExpenseSheetId As Guid) As TimeLiveDataSet.vueAccountExpenseEntryApprovalPendingDataTable
        Dim _vueAccountExpenseEntryApprovalPendingTableAdapter As New vueAccountExpenseEntryApprovalPendingTableAdapter
        Return _vueAccountExpenseEntryApprovalPendingTableAdapter.GetApprovalEntriesForSpecificExternalUser1(ExpenseEntryAccountEmployeeId, IncludeDateRange, ExpenseEntryStartDate, ExpenseEntryEndDate, AccountEmployeeId, AccountProjectId, AccountEmployeeExpenseSheetId)
    End Function
    ''' <summary>
    ''' Get approval entries for employee manager of specified AccountProjectId, AccountEmployeeId, ExpenseEntryAccountEmployeeId,
    ''' ExpenseEntryStartDate, ExpenseEntryEndDate, AccountEmployeeExpenseSheetId
    ''' </summary>
    ''' <param name="AccountProjectId"></param>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="ExpenseEntryAccountEmployeeId"></param>
    ''' <param name="ExpenseEntryStartDate"></param>
    ''' <param name="ExpenseEntryEndDate"></param>
    ''' <param name="IncludeDateRange"></param>
    ''' <param name="AccountEmployeeExpenseSheetId"></param>
    ''' <returns>vueAccountExpenseEntryApprovalPending</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)>
    Public Function GetApprovalEntriesForEmployeeManager(ByVal AccountProjectId As Integer, ByVal AccountEmployeeId As Integer, ByVal ExpenseEntryAccountEmployeeId As Integer, ByVal ExpenseEntryStartDate As Date, ByVal ExpenseEntryEndDate As Date, ByVal IncludeDateRange As Boolean, ByVal AccountEmployeeExpenseSheetId As Guid) As TimeLiveDataSet.vueAccountExpenseEntryApprovalPendingDataTable
        Dim _vueAccountExpenseEntryApprovalPendingTableAdapter As New vueAccountExpenseentryApprovalPendingTableAdapter
        Return _vueAccountExpenseEntryApprovalPendingTableAdapter.GetApprovalEntriesForEmployeeManager1(ExpenseEntryAccountEmployeeId, IncludeDateRange, ExpenseEntryStartDate, ExpenseEntryEndDate, AccountEmployeeId, AccountProjectId, AccountEmployeeExpenseSheetId)
    End Function
    ''' <summary>
    ''' Get data for project expense detail report of specified AccountId, AccountEmployees, AccountProjectId, AccountClientId,
    ''' IncludeDateRange, AccountExpenseEntryStartDate, AccountExpenseEntryEndDate, Approval, Billable
    ''' </summary>
    ''' <param name="AccountId"></param>
    ''' <param name="AccountEmployees"></param>
    ''' <param name="AccountProjectId"></param>
    ''' <param name="AccountClientId"></param>
    ''' <param name="IncludeDateRange"></param>
    ''' <param name="AccountExpenseEntryStartDate"></param>
    ''' <param name="AccountExpenseEntryEndDate"></param>
    ''' <param name="Approval"></param>
    ''' <param name="Billable"></param>
    ''' <returns>vueAccountExpenseEntryForDetailExpenseReport</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)>
    Public Function GetDataForProjectExpenseDetailReport(ByVal AccountId As Integer, ByVal AccountEmployees As String, ByVal AccountProjectId As Integer, ByVal AccountClientId As Long, ByVal IncludeDateRange As Boolean, ByVal AccountExpenseEntryStartDate As Date, ByVal AccountExpenseEntryEndDate As Date, ByVal Approval As String, ByVal Billable As String) As TimeLiveDataSet.vueAccountExpenseEntryForDetailExpenseReportDataTable
        Dim _vueAccountExpenseEntryForDetailExpenseReportTableAdapter As New vueAccountExpenseEntryForDetailExpenseReportTableAdapter
        Return _vueAccountExpenseEntryForDetailExpenseReportTableAdapter.GetDataByAccountIdAndEmployees(AccountId, AccountEmployees, AccountProjectId, AccountClientId, IncludeDateRange, AccountExpenseEntryStartDate, AccountExpenseEntryEndDate, Approval, Billable)
    End Function
    ''' <summary>
    ''' Add expense entry of specified AccountId, AccountExpenseEntryDate, AccountEmployeeId, AccountProjectId, AccountExpenseId,
    ''' Amount, CreatedOn, CreatedByEmployeeId, ModifiedOn, ModifiedByEmployeeId, Description, IsBillable, Reimburse, AccountCurrencyId,
    ''' Quantity, Rate, AmountBeforeTax, TaxAmount, AccountPaymentMethodId, ExchangeRate, AccountTaxZoneId, Submitted, AccountEmployeeExpenseSheetId,
    ''' Approved, Rejected, IsFromImportClass
    ''' </summary>
    ''' <param name="AccountId"></param>
    ''' <param name="AccountExpenseEntryDate"></param>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="AccountProjectId"></param>
    ''' <param name="AccountExpenseId"></param>
    ''' <param name="Amount"></param>
    ''' <param name="CreatedOn"></param>
    ''' <param name="CreatedByEmployeeId"></param>
    ''' <param name="ModifiedOn"></param>
    ''' <param name="ModifiedByEmployeeId"></param>
    ''' <param name="Description"></param>
    ''' <param name="IsBillable"></param>
    ''' <param name="Reimburse"></param>
    ''' <param name="AccountCurrencyId"></param>
    ''' <param name="Quantity"></param>
    ''' <param name="Rate"></param>
    ''' <param name="AmountBeforeTax"></param>
    ''' <param name="TaxAmount"></param>
    ''' <param name="AccountPaymentMethodId"></param>
    ''' <param name="ExchangeRate"></param>
    ''' <param name="AccountTaxZoneId"></param>
    ''' <param name="Submitted"></param>
    ''' <param name="AccountEmployeeExpenseSheetId"></param>
    ''' <param name="Approved"></param>
    ''' <param name="Rejected"></param>
    ''' <param name="IsFromImportClass"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, True)>
    Public Function AddAccountExpenseEntry(
                ByVal AccountId As Integer, ByVal AccountExpenseEntryDate As Date, ByVal AccountEmployeeId As Integer, ByVal AccountClientId As Integer, ByVal AccountProjectId As Integer, ByVal AccountProjectTaskId As Integer, ByVal AccountExpenseId As Integer, ByVal Amount As Double, ByVal CreatedOn As DateTime, ByVal CreatedByEmployeeId As Integer, ByVal ModifiedOn As DateTime, ByVal ModifiedByEmployeeId As Integer, ByVal Description As String, ByVal IsBillable As Boolean, ByVal Reimburse As Boolean,
                  ByVal AccountCurrencyId As Integer, ByVal Quantity As Double, ByVal Rate As Double, ByVal AmountBeforeTax As Double, ByVal TaxAmount As Double, ByVal AccountPaymentMethodId As System.Nullable(Of Integer),
                ByVal ExchangeRate As Double, ByVal AccountTaxZoneId As Integer, ByVal Submitted As Boolean, ByVal AccountEmployeeExpenseSheetId As Guid, Optional ByVal Approved As Boolean = False, Optional ByVal Rejected As Boolean = False, Optional ByVal IsFromImportClass As Boolean = False, Optional ByVal CustomField1 As String = "",
                    Optional ByVal CustomField2 As String = "",
                    Optional ByVal CustomField3 As String = "",
                    Optional ByVal CustomField4 As String = "",
                    Optional ByVal CustomField5 As String = "",
                    Optional ByVal CustomField6 As String = "",
                    Optional ByVal CustomField7 As String = "",
                    Optional ByVal CustomField8 As String = "",
                    Optional ByVal CustomField9 As String = "",
                    Optional ByVal CustomField10 As String = "",
                    Optional ByVal CustomField11 As String = "",
                    Optional ByVal CustomField12 As String = "",
                    Optional ByVal CustomField13 As String = "",
                    Optional ByVal CustomField14 As String = "",
                    Optional ByVal CustomField15 As String = "") As Boolean
        _AccountExpenseEntryTableAdapter = New AccountExpenseEntryTableAdapter
        Dim ExchangeRateBLL As New AccountCurrencyExchangeRateBLL
        Dim AccountExpenseEntries As New TimeLiveDataSet.AccountExpenseEntryDataTable
        Dim AccountExpenseEntry As TimeLiveDataSet.AccountExpenseEntryRow = AccountExpenseEntries.NewAccountExpenseEntryRow
        With AccountExpenseEntry
            .AccountId = AccountId
            .AccountExpenseEntryDate = AccountExpenseEntryDate
            .AccountEmployeeId = AccountEmployeeId
            .AccountExpenseId = AccountExpenseId
            .AccountProjectId = AccountProjectId
            If AccountProjectTaskId <> 0 Then
                .AccountProjectTaskId = AccountProjectTaskId
            End If
            .Amount = Amount
            .CreatedOn = Now
            .CreatedByEmployeeId = CreatedByEmployeeId
            .ModifiedOn = Now
            .ModifiedByEmployeeId = ModifiedByEmployeeId
            .Description = Description
            .TeamLeadApproved = False
            .ProjectManagerApproved = False
            .AdministratorApproved = False
            .Billed = False
            .Approved = False
            .IsBillable = IsBillable
            .Reimburse = Reimburse
            .Rejected = False
            .AccountClientId = AccountClientId
            If AccountCurrencyId <> 0 Then
                .AccountCurrencyId = AccountCurrencyId
            End If
            .Quantity = Quantity
            .TaxAmount = TaxAmount
            .Rate = Rate
            If IsExpenseHasTaxAmount(AccountId, AccountExpenseId) = False Then
                .AmountBeforeTax = Amount
            Else
                .AmountBeforeTax = AmountBeforeTax
            End If
            If Not AccountPaymentMethodId.Value = 0 Then
                .AccountPaymentMethodId = AccountPaymentMethodId
            End If
            .ExchangeRate = ExchangeRateBLL.GetCurrentExchangeRateByCurrencyIdAndDate(AccountCurrencyId, AccountExpenseEntryDate)
            Dim dtAccountBaseCurrency As AccountCurrencyExchangeRate.vueAccountBaseCurrencyDataTable = New AccountCurrencyExchangeRateBLL().GetvueAccountBaseCurrencyByAccountId(DBUtilities.GetSessionAccountId)
            Dim drAccountBaseCurrency As AccountCurrencyExchangeRate.vueAccountBaseCurrencyRow
            If dtAccountBaseCurrency.Rows.Count > 0 Then
                drAccountBaseCurrency = dtAccountBaseCurrency.Rows(0)
                .AccountBaseCurrencyId = drAccountBaseCurrency.AccountBaseCurrencyId
            End If
            AccountExpenseEntry.Submitted = False
            If AccountTaxZoneId <> 0 Then
                .AccountTaxZoneId = AccountTaxZoneId
            End If
            If AccountEmployeeExpenseSheetId <> System.Guid.Empty Then
                .AccountEmployeeExpenseSheetId = AccountEmployeeExpenseSheetId
            End If
            If IsFromImportClass Then
                .Submitted = Submitted
                .Approved = Approved
                .Rejected = Rejected
            End If
            .IsEmailSend = False
            If CustomField1 <> "" Then
                .CustomField1 = CustomField1
            Else
                .Item("CustomField1") = System.DBNull.Value
            End If
            If CustomField2 <> "" Then
                .CustomField2 = CustomField2
            Else
                .Item("CustomField2") = System.DBNull.Value
            End If
            If CustomField3 <> "" Then
                .CustomField3 = CustomField3
            Else
                .Item("CustomField3") = System.DBNull.Value
            End If
            If CustomField4 <> "" Then
                .CustomField4 = CustomField4
            Else
                .Item("CustomField4") = System.DBNull.Value
            End If
            If CustomField5 <> "" Then
                .CustomField5 = CustomField5
            Else
                .Item("CustomField5") = System.DBNull.Value
            End If
            If CustomField6 <> "" Then
                .CustomField6 = CustomField6
            Else
                .Item("CustomField6") = System.DBNull.Value
            End If
            If CustomField7 <> "" Then
                .CustomField7 = CustomField7
            Else
                .Item("CustomField7") = System.DBNull.Value
            End If
            If CustomField8 <> "" Then
                .CustomField8 = CustomField8
            Else
                .Item("CustomField8") = System.DBNull.Value
            End If
            If CustomField9 <> "" Then
                .CustomField9 = CustomField9
            Else
                .Item("CustomField9") = System.DBNull.Value
            End If
            If CustomField10 <> "" Then
                .CustomField10 = CustomField10
            Else
                .Item("CustomField10") = System.DBNull.Value
            End If
            If CustomField11 <> "" Then
                .CustomField11 = CustomField11
            Else
                .Item("CustomField11") = System.DBNull.Value
            End If
            If CustomField12 <> "" Then
                .CustomField12 = CustomField12
            Else
                .Item("CustomField12") = System.DBNull.Value
            End If
            If CustomField13 <> "" Then
                .CustomField13 = CustomField13
            Else
                .Item("CustomField13") = System.DBNull.Value
            End If
            If CustomField14 <> "" Then
                .CustomField14 = CustomField14
            Else
                .Item("CustomField14") = System.DBNull.Value
            End If
            If CustomField15 <> "" Then
                .CustomField15 = CustomField15
            Else
                .Item("CustomField15") = System.DBNull.Value
            End If
            .PaymentStatusId = 0
        End With
        AccountExpenseEntries.AddAccountExpenseEntryRow(AccountExpenseEntry)
        Dim rowsAffected As Integer = Adapter.Update(AccountExpenseEntries)
        Return rowsAffected = 1
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, True)>
    Public Function AddAccountExpenseEntryForMobile(
                ByVal AccountId As Integer, ByVal AccountExpenseEntryDate As Date, ByVal AccountEmployeeId As Integer, ByVal AccountClientId As Integer, ByVal AccountProjectId As Integer, ByVal AccountProjectTaskId As Integer, ByVal AccountExpenseId As Integer, ByVal Amount As Double, ByVal CreatedOn As DateTime, ByVal CreatedByEmployeeId As Integer, ByVal ModifiedOn As DateTime, ByVal ModifiedByEmployeeId As Integer, ByVal Description As String, ByVal IsBillable As Boolean, ByVal Reimburse As Boolean,
                  ByVal AccountCurrencyId As Integer, ByVal Quantity As Double, ByVal Rate As Double, ByVal AmountBeforeTax As Double, ByVal TaxAmount As Double, ByVal AccountPaymentMethodId As System.Nullable(Of Integer),
                ByVal ExchangeRate As Double, ByVal AccountTaxZoneId As Integer, ByVal Submitted As Boolean, ByVal AccountEmployeeExpenseSheetId As Guid, Optional ByVal Approved As Boolean = False, Optional ByVal Rejected As Boolean = False, Optional ByVal IsFromImportClass As Boolean = False)
        _AccountExpenseEntryTableAdapter = New AccountExpenseEntryTableAdapter
        Dim ExchangeRateBLL As New AccountCurrencyExchangeRateBLL
        Dim AccountExpenseEntries As New TimeLiveDataSet.AccountExpenseEntryDataTable
        Dim AccountExpenseEntry As TimeLiveDataSet.AccountExpenseEntryRow = AccountExpenseEntries.NewAccountExpenseEntryRow
        With AccountExpenseEntry
            .AccountId = AccountId
            .AccountExpenseEntryDate = AccountExpenseEntryDate
            .AccountEmployeeId = AccountEmployeeId
            .AccountExpenseId = AccountExpenseId
            .AccountProjectId = AccountProjectId
            If AccountProjectTaskId <> 0 Then
                .AccountProjectTaskId = AccountProjectTaskId
            End If
            .Amount = Amount
            .CreatedOn = Now
            .CreatedByEmployeeId = CreatedByEmployeeId
            .ModifiedOn = Now
            .ModifiedByEmployeeId = ModifiedByEmployeeId
            .Description = Description
            .TeamLeadApproved = False
            .ProjectManagerApproved = False
            .AdministratorApproved = False
            .Billed = False
            .Approved = False
            .IsBillable = IsBillable
            .Reimburse = Reimburse
            .Rejected = False
            .AccountClientId = AccountClientId
            If AccountCurrencyId <> 0 Then
                .AccountCurrencyId = AccountCurrencyId
            End If
            .Quantity = Quantity
            .TaxAmount = TaxAmount
            .Rate = Rate
            If IsExpenseHasTaxAmount(AccountId, AccountExpenseId) = False Then
                .AmountBeforeTax = Amount
            Else
                .AmountBeforeTax = AmountBeforeTax
            End If
            If Not AccountPaymentMethodId.Value = 0 Then
                .AccountPaymentMethodId = AccountPaymentMethodId
            End If
            .ExchangeRate = ExchangeRateBLL.GetCurrentExchangeRateByCurrencyIdAndDate(AccountCurrencyId, AccountExpenseEntryDate)
            Dim dtAccountBaseCurrency As AccountCurrencyExchangeRate.vueAccountBaseCurrencyDataTable = New AccountCurrencyExchangeRateBLL().GetvueAccountBaseCurrencyByAccountId(DBUtilities.GetSessionAccountId)
            Dim drAccountBaseCurrency As AccountCurrencyExchangeRate.vueAccountBaseCurrencyRow
            If dtAccountBaseCurrency.Rows.Count > 0 Then
                drAccountBaseCurrency = dtAccountBaseCurrency.Rows(0)
                .AccountBaseCurrencyId = drAccountBaseCurrency.AccountBaseCurrencyId
            End If
            AccountExpenseEntry.Submitted = False
            If AccountTaxZoneId <> 0 Then
                .AccountTaxZoneId = AccountTaxZoneId
            End If
            If AccountEmployeeExpenseSheetId <> System.Guid.Empty Then
                .AccountEmployeeExpenseSheetId = AccountEmployeeExpenseSheetId
            End If
            If IsFromImportClass Then
                .Submitted = Submitted
                .Approved = Approved
                .Rejected = Rejected
            End If
            .IsEmailSend = False
        End With
        AccountExpenseEntries.AddAccountExpenseEntryRow(AccountExpenseEntry)
        Dim rowsAffected As Integer = Adapter.Update(AccountExpenseEntries)
        Return rowsAffected = 1
    End Function
    ''' <summary>
    ''' Set approval state
    ''' </summary>
    ''' <param name="GV"></param>
    ''' <remarks></remarks>
    Public Sub SetApprovalState(ByVal GV As GridView)
        Dim row As GridViewRow
        For Each row In GV.Rows
            Dim AccountExpenseEntries As TimeLiveDataSet.AccountExpenseEntryDataTable = Adapter.GetDataByAccountExpenseEntryId(GV.DataKeys(row.RowIndex)("AccountExpenseEntryId"))
            Dim AccountExpenseEntry As TimeLiveDataSet.AccountExpenseEntryRow
            If AccountExpenseEntries.Rows.Count > 0 Then
                AccountExpenseEntry = AccountExpenseEntries.Rows(0)
                Dim Project As TimeLiveDataSet.AccountProjectRow = New AccountProjectBLL().GetAccountProjectsByAccountProjectId(AccountExpenseEntry.AccountProjectId).Rows(0)
                If IsDBNull(Project("ExpenseApprovalTypeId")) OrElse Project.Item("ExpenseApprovalTypeId") = 0 Then
                    AccountExpenseEntry.Approved = True
                    Dim rowsAffected As Integer = Adapter.Update(AccountExpenseEntry)
                End If
            End If
        Next
    End Sub
    ''' <summary>
    ''' After update clear the cache 
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub AfterUpdate()
        CacheManager.ClearCache("AccountExpenseEntryDataTable", , , True)
    End Sub
    ''' <summary>
    ''' Update expense entry of specified AccountId, AccountExpenseEntryDate, Original_AccountExpenseEntryId, AccountEmployeeId,
    ''' AccountProjectId, AccountExpenseId, Amount, ModifiedOn, ModifiedByEmployeeId, Description, IsBillable, Reimburse, AccountCurrencyId,
    ''' Quantity, Rate, AmountBeforeTax, TaxAmount, AccountPaymentMethodId, AccountTaxZoneId, Rejected, Submitted, AccountEmployeeExpenseSheetId
    ''' </summary>
    ''' <param name="AccountId"></param>
    ''' <param name="AccountExpenseEntryDate"></param>
    ''' <param name="Original_AccountExpenseEntryId"></param>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="AccountProjectId"></param>
    ''' <param name="AccountExpenseId"></param>
    ''' <param name="Amount"></param>
    ''' <param name="ModifiedOn"></param>
    ''' <param name="ModifiedByEmployeeId"></param>
    ''' <param name="Description"></param>
    ''' <param name="IsBillable"></param>
    ''' <param name="Reimburse"></param>
    ''' <param name="AccountCurrencyId"></param>
    ''' <param name="Quantity"></param>
    ''' <param name="Rate"></param>
    ''' <param name="AmountBeforeTax"></param>
    ''' <param name="TaxAmount"></param>
    ''' <param name="AccountPaymentMethodId"></param>
    ''' <param name="AccountTaxZoneId"></param>
    ''' <param name="Rejected"></param>
    ''' <param name="Submitted"></param>
    ''' <param name="AccountEmployeeExpenseSheetId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)>
    Public Function UpdateAccountExpenseEntry(ByVal AccountId As Integer, ByVal AccountExpenseEntryDate As Date,
    ByVal Original_AccountExpenseEntryId As Integer, ByVal AccountEmployeeId As Integer,
    ByVal AccountClientId As Integer, ByVal AccountProjectId As Integer, ByVal AccountProjectTaskId As Integer, ByVal AccountExpenseId As Integer, ByVal Amount As Double,
    ByVal ModifiedOn As DateTime, ByVal ModifiedByEmployeeId As Integer, ByVal Description As String,
    ByVal IsBillable As Boolean, ByVal Reimburse As Boolean, ByVal AccountCurrencyId As Integer,
    ByVal Quantity As Double, ByVal Rate As Double, ByVal AmountBeforeTax As Double, ByVal TaxAmount As Double, ByVal AccountPaymentMethodId As System.Nullable(Of Integer),
    ByVal AccountTaxZoneId As Integer, ByVal Rejected As Boolean, ByVal Submitted As Boolean, ByVal AccountEmployeeExpenseSheetId As Guid, Optional ByVal CustomField1 As String = "",
                    Optional ByVal CustomField2 As String = "",
                    Optional ByVal CustomField3 As String = "",
                    Optional ByVal CustomField4 As String = "",
                    Optional ByVal CustomField5 As String = "",
                    Optional ByVal CustomField6 As String = "",
                    Optional ByVal CustomField7 As String = "",
                    Optional ByVal CustomField8 As String = "",
                    Optional ByVal CustomField9 As String = "",
                    Optional ByVal CustomField10 As String = "",
                    Optional ByVal CustomField11 As String = "",
                    Optional ByVal CustomField12 As String = "",
                    Optional ByVal CustomField13 As String = "",
                    Optional ByVal CustomField14 As String = "",
                    Optional ByVal CustomField15 As String = "") As Boolean

        Dim AccountExpenseEntries As TimeLiveDataSet.AccountExpenseEntryDataTable = Adapter.GetDataByAccountExpenseEntryId(Original_AccountExpenseEntryId)
        Dim AccountExpenseEntry As TimeLiveDataSet.AccountExpenseEntryRow = AccountExpenseEntries.Rows(0)
        Dim ExchangeRateBLL As New AccountCurrencyExchangeRateBLL
        'AddOldObjectInSession(Original_AccountExpenseEntryId)

        With AccountExpenseEntry
            .AccountExpenseEntryDate = AccountExpenseEntryDate
            .AccountEmployeeId = AccountEmployeeId
            .AccountProjectId = AccountProjectId
            If AccountProjectTaskId <> 0 Then
                .AccountProjectTaskId = AccountProjectTaskId
            Else
                .Item("AccountProjectTaskId") = DBNull.Value
            End If
            .AccountExpenseId = AccountExpenseId
            .Amount = Amount
            .ModifiedOn = Now
            .ModifiedByEmployeeId = ModifiedByEmployeeId
            .Description = Description
            .IsBillable = IsBillable
            .Reimburse = Reimburse
            .Quantity = Quantity
            .TaxAmount = TaxAmount
            .AccountClientId = AccountClientId
            .Rate = Rate
            If IsExpenseHasTaxAmount(AccountId, AccountExpenseId) = False Then
                .AmountBeforeTax = Amount
            Else
                .AmountBeforeTax = AmountBeforeTax
            End If
            If AccountPaymentMethodId.Value = 0 Then
                .Item("AccountPaymentMethodId") = DBNull.Value
            Else
                .AccountPaymentMethodId = AccountPaymentMethodId
            End If
            If AccountTaxZoneId <> 0 Then
                .AccountTaxZoneId = AccountTaxZoneId
            End If
            If AccountEmployeeExpenseSheetId <> System.Guid.Empty Then
                .AccountEmployeeExpenseSheetId = AccountEmployeeExpenseSheetId
            End If
            If Not IsDBNull(.Item("AccountCurrencyId")) Then
                'If .AccountCurrencyId <> AccountCurrencyId Then
                .ExchangeRate = ExchangeRateBLL.GetCurrentExchangeRateByCurrencyIdAndDate(AccountCurrencyId, AccountExpenseEntryDate)
                'End If
            End If
            If CustomField1 <> "" Then
                .CustomField1 = CustomField1
            Else
                .Item("CustomField1") = System.DBNull.Value
            End If
            If CustomField2 <> "" Then
                .CustomField2 = CustomField2
            Else
                .Item("CustomField2") = System.DBNull.Value
            End If
            If CustomField3 <> "" Then
                .CustomField3 = CustomField3
            Else
                .Item("CustomField3") = System.DBNull.Value
            End If
            If CustomField4 <> "" Then
                .CustomField4 = CustomField4
            Else
                .Item("CustomField4") = System.DBNull.Value
            End If
            If CustomField5 <> "" Then
                .CustomField5 = CustomField5
            Else
                .Item("CustomField5") = System.DBNull.Value
            End If
            If CustomField6 <> "" Then
                .CustomField6 = CustomField6
            Else
                .Item("CustomField6") = System.DBNull.Value
            End If
            If CustomField7 <> "" Then
                .CustomField7 = CustomField7
            Else
                .Item("CustomField7") = System.DBNull.Value
            End If
            If CustomField8 <> "" Then
                .CustomField8 = CustomField8
            Else
                .Item("CustomField8") = System.DBNull.Value
            End If
            If CustomField9 <> "" Then
                .CustomField9 = CustomField9
            Else
                .Item("CustomField9") = System.DBNull.Value
            End If
            If CustomField10 <> "" Then
                .CustomField10 = CustomField10
            Else
                .Item("CustomField10") = System.DBNull.Value
            End If
            If CustomField11 <> "" Then
                .CustomField11 = CustomField11
            Else
                .Item("CustomField11") = System.DBNull.Value
            End If
            If CustomField12 <> "" Then
                .CustomField12 = CustomField12
            Else
                .Item("CustomField12") = System.DBNull.Value
            End If
            If CustomField13 <> "" Then
                .CustomField13 = CustomField13
            Else
                .Item("CustomField13") = System.DBNull.Value
            End If
            If CustomField14 <> "" Then
                .CustomField14 = CustomField14
            Else
                .Item("CustomField14") = System.DBNull.Value
            End If
            If CustomField15 <> "" Then
                .CustomField15 = CustomField15
            Else
                .Item("CustomField15") = System.DBNull.Value
            End If
            .AccountCurrencyId = AccountCurrencyId
        End With

        Dim rowsAffected As Integer = Adapter.Update(AccountExpenseEntry)
        Return rowsAffected = 1
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)>
    Public Function UpdateAccountExpenseEntryForMobile(ByVal AccountId As Integer, ByVal AccountExpenseEntryDate As Date,
    ByVal Original_AccountExpenseEntryId As Integer, ByVal AccountEmployeeId As Integer,
    ByVal AccountClientId As Integer, ByVal AccountProjectId As Integer, ByVal AccountProjectTaskId As Integer, ByVal AccountExpenseId As Integer, ByVal Amount As Double,
    ByVal ModifiedOn As DateTime, ByVal ModifiedByEmployeeId As Integer, ByVal Description As String,
    ByVal IsBillable As Boolean, ByVal Reimburse As Boolean, ByVal AccountCurrencyId As Integer,
    ByVal Quantity As Double, ByVal Rate As Double, ByVal AmountBeforeTax As Double, ByVal TaxAmount As Double, ByVal AccountPaymentMethodId As System.Nullable(Of Integer),
    ByVal AccountTaxZoneId As Integer, ByVal AccountEmployeeExpenseSheetId As Guid) As Boolean

        Dim AccountExpenseEntries As TimeLiveDataSet.AccountExpenseEntryDataTable = Adapter.GetDataByAccountExpenseEntryId(Original_AccountExpenseEntryId)
        Dim AccountExpenseEntry As TimeLiveDataSet.AccountExpenseEntryRow = AccountExpenseEntries.Rows(0)
        Dim ExchangeRateBLL As New AccountCurrencyExchangeRateBLL
        'AddOldObjectInSession(Original_AccountExpenseEntryId)

        With AccountExpenseEntry
            .AccountExpenseEntryDate = AccountExpenseEntryDate
            .AccountEmployeeId = AccountEmployeeId
            .AccountProjectId = AccountProjectId
            If AccountProjectTaskId <> 0 Then
                .AccountProjectTaskId = AccountProjectTaskId
            Else
                .Item("AccountProjectTaskId") = DBNull.Value
            End If
            .AccountExpenseId = AccountExpenseId
            .Amount = Amount
            .ModifiedOn = Now
            .ModifiedByEmployeeId = ModifiedByEmployeeId
            .Description = Description
            .IsBillable = IsBillable
            .Reimburse = Reimburse
            .Quantity = Quantity
            .TaxAmount = TaxAmount
            .AccountClientId = AccountClientId
            .Rate = Rate
            If IsExpenseHasTaxAmount(AccountId, AccountExpenseId) = False Then
                .AmountBeforeTax = Amount
            Else
                .AmountBeforeTax = AmountBeforeTax
            End If
            If AccountPaymentMethodId.Value = 0 Then
                .Item("AccountPaymentMethodId") = DBNull.Value
            Else
                .AccountPaymentMethodId = AccountPaymentMethodId
            End If
            If AccountTaxZoneId <> 0 Then
                .AccountTaxZoneId = AccountTaxZoneId
            End If
            If AccountEmployeeExpenseSheetId <> System.Guid.Empty Then
                .AccountEmployeeExpenseSheetId = AccountEmployeeExpenseSheetId
            End If
            If Not IsDBNull(.Item("AccountCurrencyId")) Then
                If .AccountCurrencyId <> AccountCurrencyId Then
                    .ExchangeRate = ExchangeRateBLL.GetCurrentExchangeRateByCurrencyIdAndDate(AccountCurrencyId, AccountExpenseEntryDate)
                End If
            End If
            .AccountCurrencyId = AccountCurrencyId
        End With

        Dim rowsAffected As Integer = Adapter.Update(AccountExpenseEntry)
        Return rowsAffected = 1
    End Function
    ''' <summary>
    ''' Delete expense entry
    ''' </summary>
    ''' <param name="Original_AccountExpenseEntryId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Delete, True)>
    Public Function DeleteAccountExpenseEntry(ByVal Original_AccountExpenseEntryId As Integer) As Boolean
        Dim rowsAffected As Integer = Adapter.Delete(Original_AccountExpenseEntryId)
        AfterUpdate()
        Return rowsAffected = 1
    End Function
    ''' <summary>
    ''' Add expense approval of specified AccountExpenseEntryId, ExpenseApprovalTypeId, ExpenseApprovalPathId, ApprovedByEmployeeId,
    ''' Comments, IsRejected, IsApproved
    ''' </summary>
    ''' <param name="AccountExpenseEntryId"></param>
    ''' <param name="ExpenseApprovalTypeId"></param>
    ''' <param name="ExpenseApprovalPathId"></param>
    ''' <param name="ApprovedByEmployeeId"></param>
    ''' <param name="Comments"></param>
    ''' <param name="IsRejected"></param>
    ''' <param name="IsApproved"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, True)>
    Public Function AddExpenseApproval(
                ByVal AccountExpenseEntryId As Integer, ByVal ExpenseApprovalTypeId As Integer, ByVal ExpenseApprovalPathId As Integer, ByVal ApprovedByEmployeeId As Integer, ByVal Comments As String, ByVal IsRejected As Boolean, ByVal IsApproved As Boolean, ByVal ApprovalPathSequence As Integer
                    ) As Boolean

        _AccountExpenseEntryApprovalTableAdapter = New AccountExpenseEntryApprovalTableAdapter

        Dim ExpenseApprovals As New TimeLiveDataSet.AccountExpenseEntryApprovalDataTable
        Dim ExpenseApproval As TimeLiveDataSet.AccountExpenseEntryApprovalRow = ExpenseApprovals.NewAccountExpenseEntryApprovalRow

        With ExpenseApproval
            .AccountExpenseEntryId = AccountExpenseEntryId
            .ExpenseApprovalTypeId = ExpenseApprovalTypeId
            .ExpenseApprovalPathId = ExpenseApprovalPathId
            .ApprovedByEmployeeId = ApprovedByEmployeeId
            .ApprovedOn = Date.Now
            .Comments = Comments
            .IsRejected = IsRejected
            .IsApproved = IsApproved
            .ApprovalPathSequence = ApprovalPathSequence
        End With


        ExpenseApprovals.AddAccountExpenseEntryApprovalRow(ExpenseApproval)

        Dim rowsAffected As Integer = AccountExpenseEntryApprovalAdapter.Update(ExpenseApprovals)
        Return rowsAffected = 1
    End Function
    ''' <summary>
    ''' Lock team lead expense entry of specified Original_AccountExpenseEntryId, Approved
    ''' </summary>
    ''' <param name="Original_AccountExpenseEntryId"></param>
    ''' <param name="Approved"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)>
    Public Function LockTeamLeadExpenseEntry(ByVal Original_AccountExpenseEntryId As Integer,
                ByVal Approved As Boolean
                ) As Boolean

        ' Update the product record

        Dim AccountExpenseEntries As TimeLiveDataSet.AccountExpenseEntryDataTable = Adapter.GetDataByAccountExpenseEntryId(Original_AccountExpenseEntryId)
        Dim AccountExpenseEntry As TimeLiveDataSet.AccountExpenseEntryRow = AccountExpenseEntries.Rows(0)

        With AccountExpenseEntry
            .ModifiedOn = Now
            .Approved = Approved
            .Rejected = False
        End With


        Dim rowsAffected As Integer = Adapter.Update(AccountExpenseEntry)
        ' Return true if precisely one row was updated, otherwise false
        Return rowsAffected = 1
    End Function
    ''' <summary>
    ''' Lock team lead expense entry rejected of specified Original_AccountExpenseEntryId, Rejected
    ''' </summary>
    ''' <param name="Original_AccountExpenseEntryId"></param>
    ''' <param name="Rejected"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)>
    Public Function LockTeamLeadExpenseEntryRejected(ByVal Original_AccountExpenseEntryId As Integer,
                ByVal Rejected As Boolean
                ) As Boolean

        ' Update the product record

        Dim AccountExpenseEntries As TimeLiveDataSet.AccountExpenseEntryDataTable = Adapter.GetDataByAccountExpenseEntryId(Original_AccountExpenseEntryId)
        Dim AccountExpenseEntry As TimeLiveDataSet.AccountExpenseEntryRow = AccountExpenseEntries.Rows(0)

        With AccountExpenseEntry
            .ModifiedOn = Now
            .Rejected = Rejected
            .Submitted = False
        End With


        Dim rowsAffected As Integer = Adapter.Update(AccountExpenseEntry)
        ' Return true if precisely one row was updated, otherwise false
        Return rowsAffected = 1
    End Function
    ''' <summary>
    ''' Lock project manager expense entry of specified Original_AccountExpenseEntryId, Approved
    ''' </summary>
    ''' <param name="Original_AccountExpenseEntryId"></param>
    ''' <param name="Approved"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)>
    Public Function LockProjectManagerExpenseEntry(ByVal Original_AccountExpenseEntryId As Integer,
                    ByVal Approved As Boolean
                    ) As Boolean

        ' Update the product record

        Dim AccountExpenseEntries As TimeLiveDataSet.AccountExpenseEntryDataTable = Adapter.GetDataByAccountExpenseEntryId(Original_AccountExpenseEntryId)
        Dim AccountExpenseEntry As TimeLiveDataSet.AccountExpenseEntryRow = AccountExpenseEntries.Rows(0)

        With AccountExpenseEntry
            .ModifiedOn = Now
            .Approved = Approved
            .Rejected = False
        End With


        Dim rowsAffected As Integer = Adapter.Update(AccountExpenseEntry)
        ' Return true if precisely one row was updated, otherwise false
        Return rowsAffected = 1
    End Function
    ''' <summary>
    ''' Lock project manager expense entry rejected of specified Original_AccountExpenseEntryId, Rejected
    ''' </summary>
    ''' <param name="Original_AccountExpenseEntryId"></param>
    ''' <param name="Rejected"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)>
    Public Function LockProjectManagerExpenseEntryRejected(ByVal Original_AccountExpenseEntryId As Integer,
                    ByVal Rejected As Boolean
                    ) As Boolean

        ' Update the product record

        Dim AccountExpenseEntries As TimeLiveDataSet.AccountExpenseEntryDataTable = Adapter.GetDataByAccountExpenseEntryId(Original_AccountExpenseEntryId)
        Dim AccountExpenseEntry As TimeLiveDataSet.AccountExpenseEntryRow = AccountExpenseEntries.Rows(0)

        With AccountExpenseEntry
            .ModifiedOn = Now
            .Rejected = Rejected
            .Submitted = False
        End With


        Dim rowsAffected As Integer = Adapter.Update(AccountExpenseEntry)
        ' Return true if precisely one row was updated, otherwise false
        Return rowsAffected = 1
    End Function
    ''' <summary>
    ''' Lock specific employee expenseEntry of specified Original_AccountExpenseEntryId, Approved
    ''' </summary>
    ''' <param name="Original_AccountExpenseEntryId"></param>
    ''' <param name="Approved"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)>
    Public Function LockSpecificEmployeeExpenseEntry(ByVal Original_AccountExpenseEntryId As Integer,
                ByVal Approved As Boolean
                ) As Boolean

        ' Update the product record

        Dim AccountExpenseEntries As TimeLiveDataSet.AccountExpenseEntryDataTable = Adapter.GetDataByAccountExpenseEntryId(Original_AccountExpenseEntryId)
        Dim AccountExpenseEntry As TimeLiveDataSet.AccountExpenseEntryRow = AccountExpenseEntries.Rows(0)

        With AccountExpenseEntry
            .ModifiedOn = Now
            .Approved = Approved
            .Rejected = False
        End With


        Dim rowsAffected As Integer = Adapter.Update(AccountExpenseEntry)
        ' Return true if precisely one row was updated, otherwise false
        Return rowsAffected = 1
    End Function
    ''' <summary>
    ''' Lock specific employee expense entry rejected of specified Original_AccountExpenseEntryId, Rejected
    ''' </summary>
    ''' <param name="Original_AccountExpenseEntryId"></param>
    ''' <param name="Rejected"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)>
    Public Function LockSpecificEmployeeExpenseEntryRejected(ByVal Original_AccountExpenseEntryId As Integer,
                ByVal Rejected As Boolean
                ) As Boolean

        ' Update the product record

        Dim AccountExpenseEntries As TimeLiveDataSet.AccountExpenseEntryDataTable = Adapter.GetDataByAccountExpenseEntryId(Original_AccountExpenseEntryId)
        Dim AccountExpenseEntry As TimeLiveDataSet.AccountExpenseEntryRow = AccountExpenseEntries.Rows(0)

        With AccountExpenseEntry
            .ModifiedOn = Now
            .Rejected = Rejected
            .Submitted = False
        End With


        Dim rowsAffected As Integer = Adapter.Update(AccountExpenseEntry)
        ' Return true if precisely one row was updated, otherwise false
        Return rowsAffected = 1
    End Function
    ''' <summary>
    ''' Lock specific external user expense entry of specified Original_AccountExpenseEntryId, Approved
    ''' </summary>
    ''' <param name="Original_AccountExpenseEntryId"></param>
    ''' <param name="Approved"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)>
    Public Function LockSpecificExternalUserExpenseEntry(ByVal Original_AccountExpenseEntryId As Integer,
                ByVal Approved As Boolean
                ) As Boolean

        ' Update the product record

        Dim AccountExpenseEntries As TimeLiveDataSet.AccountExpenseEntryDataTable = Adapter.GetDataByAccountExpenseEntryId(Original_AccountExpenseEntryId)
        Dim AccountExpenseEntry As TimeLiveDataSet.AccountExpenseEntryRow = AccountExpenseEntries.Rows(0)

        With AccountExpenseEntry
            .ModifiedOn = Now
            .Approved = Approved
            .Rejected = False
        End With


        Dim rowsAffected As Integer = Adapter.Update(AccountExpenseEntry)
        ' Return true if precisely one row was updated, otherwise false
        Return rowsAffected = 1
    End Function
    ''' <summary>
    ''' Lock employee manager expense entry of specified Original_AccountExpenseEntryId, Approved
    ''' </summary>
    ''' <param name="Original_AccountExpenseEntryId"></param>
    ''' <param name="Approved"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)>
    Public Function LockEmployeeManagerExpenseEntry(ByVal Original_AccountExpenseEntryId As Integer,
            ByVal Approved As Boolean
            ) As Boolean

        ' Update the product record

        Dim AccountExpenseEntries As TimeLiveDataSet.AccountExpenseEntryDataTable = Adapter.GetDataByAccountExpenseEntryId(Original_AccountExpenseEntryId)
        Dim AccountExpenseEntry As TimeLiveDataSet.AccountExpenseEntryRow = AccountExpenseEntries.Rows(0)

        With AccountExpenseEntry
            .ModifiedOn = Now
            .Approved = Approved
            .Rejected = False
        End With


        Dim rowsAffected As Integer = Adapter.Update(AccountExpenseEntry)
        ' Return true if precisely one row was updated, otherwise false
        Return rowsAffected = 1
    End Function
    ''' <summary>
    ''' Lock specific external user expense entry rejected of specified Original_AccountExpenseEntryId, Rejected
    ''' </summary>
    ''' <param name="Original_AccountExpenseEntryId"></param>
    ''' <param name="Rejected"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)>
    Public Function LockSpecificExternalUserExpenseEntryRejected(ByVal Original_AccountExpenseEntryId As Integer,
                ByVal Rejected As Boolean
                ) As Boolean

        ' Update the product record

        Dim AccountExpenseEntries As TimeLiveDataSet.AccountExpenseEntryDataTable = Adapter.GetDataByAccountExpenseEntryId(Original_AccountExpenseEntryId)
        Dim AccountExpenseEntry As TimeLiveDataSet.AccountExpenseEntryRow = AccountExpenseEntries.Rows(0)

        With AccountExpenseEntry
            .ModifiedOn = Now
            .Rejected = Rejected
            .Submitted = False
        End With


        Dim rowsAffected As Integer = Adapter.Update(AccountExpenseEntry)
        ' Return true if precisely one row was updated, otherwise false
        Return rowsAffected = 1
    End Function
    ''' <summary>
    ''' Lock employee manager expense entry rejected of specified Original_AccountExpenseEntryId, Rejected
    ''' </summary>
    ''' <param name="Original_AccountExpenseEntryId"></param>
    ''' <param name="Rejected"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)>
    Public Function LockEmployeeManagerExpenseEntryRejected(ByVal Original_AccountExpenseEntryId As Integer,
                ByVal Rejected As Boolean
                ) As Boolean

        ' Update the product record

        Dim AccountExpenseEntries As TimeLiveDataSet.AccountExpenseEntryDataTable = Adapter.GetDataByAccountExpenseEntryId(Original_AccountExpenseEntryId)
        Dim AccountExpenseEntry As TimeLiveDataSet.AccountExpenseEntryRow = AccountExpenseEntries.Rows(0)

        With AccountExpenseEntry
            .ModifiedOn = Now
            .Rejected = Rejected
            .Submitted = False
        End With


        Dim rowsAffected As Integer = Adapter.Update(AccountExpenseEntry)
        ' Return true if precisely one row was updated, otherwise false
        Return rowsAffected = 1
    End Function
    ''' <summary>
    ''' Get data for expense by client report of specified AccountId, AccountClientId, AccountEmployees, AccountProjectId, AccountExpenseId,
    ''' IncludeDateRange, AccountExpenseEntryStartDate, AccountExpenseEntryEndDate
    ''' </summary>
    ''' <param name="AccountId"></param>
    ''' <param name="AccountClientId"></param>
    ''' <param name="AccountEmployees"></param>
    ''' <param name="AccountProjectId"></param>
    ''' <param name="AccountExpenseId"></param>
    ''' <param name="IncludeDateRange"></param>
    ''' <param name="AccountExpenseEntryStartDate"></param>
    ''' <param name="AccountExpenseEntryEndDate"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetDataForExpenseByClientReport(ByVal AccountId As Integer, ByVal AccountClientId As Integer, ByVal AccountEmployees As String, ByVal AccountProjectId As Integer, ByVal AccountExpenseId As Integer, ByVal IncludeDateRange As Boolean, ByVal AccountExpenseEntryStartDate As Date, ByVal AccountExpenseEntryEndDate As Date) As TimeLiveDataSet.vueAccountExpenseEntryForReportDataTable
        Dim _vueAccountExpenseEntryForReportTableAdapter As New vueAccountExpenseEntryForReportTableAdapter
        Return _vueAccountExpenseEntryForReportTableAdapter.GetDataByAccountIdAndEmployees(AccountId, AccountClientId, AccountEmployees, AccountProjectId, AccountExpenseId, IncludeDateRange, AccountExpenseEntryStartDate, AccountExpenseEntryEndDate)
    End Function
    ''' <summary>
    ''' Check new and old values 
    ''' </summary>
    ''' <param name="drAccountExpenseEntry"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function CheckNewAndOldValues(Optional ByVal drAccountExpenseEntry As TimeLiveDataSet.AccountExpenseEntryRow = Nothing) As Boolean

        Dim DataRow As DataRow

        DataRow = drAccountExpenseEntry

        Dim OlddrAccountExpenseEntry As TimeLiveDataSet.AccountExpenseEntryRow
        OlddrAccountExpenseEntry = System.Web.HttpContext.Current.Session("OldAccountExpenseEntry")


        If DataRow("AccountProjectId") <> OlddrAccountExpenseEntry.AccountProjectId Then
            Return True
        End If

        If DataRow("AccountExpenseId") <> OlddrAccountExpenseEntry.AccountExpenseId Then
            Return True
        End If

        If Not IsDBNull(DataRow.Item("Description")) Then
            If IsDBNull(OlddrAccountExpenseEntry.Item("Description")) OrElse DataRow("Description") <> OlddrAccountExpenseEntry.Description Then
                Return True
            End If
        End If

        If Not IsDBNull(DataRow.Item("Amount")) Then
            If IsDBNull(OlddrAccountExpenseEntry.Item("Amount")) OrElse DataRow("Amount") <> OlddrAccountExpenseEntry.Amount Then
                Return True
            End If
        End If

        If Not IsDBNull(DataRow.Item("IsBillable")) Then
            If IsDBNull(OlddrAccountExpenseEntry.Item("IsBillable")) OrElse DataRow("IsBillable") <> OlddrAccountExpenseEntry("IsBillable") Then
                Return True
            End If
        End If

        If Not IsDBNull(drAccountExpenseEntry.Item("Submitted")) Then
            If drAccountExpenseEntry.Submitted = True Then
                Return True
            End If
        End If
        Return False

    End Function
    ''' <summary>
    ''' Add old object in session of specified Original_AccountExpenseEntryId
    ''' </summary>
    ''' <param name="Original_AccountExpenseEntryId"></param>
    ''' <remarks></remarks>
    Public Sub AddOldObjectInSession(ByVal Original_AccountExpenseEntryId As Integer)

        Dim drAccountExpenseEntry As TimeLiveDataSet.AccountExpenseEntryRow
        Dim objAccountExpenseEntry As New AccountExpenseEntryBLL
        drAccountExpenseEntry = objAccountExpenseEntry.GetAccountExpenseEntriesByAccountExpenseEntryId(Original_AccountExpenseEntryId).Rows(0)

        System.Web.HttpContext.Current.Session.Add("OldAccountExpenseEntry", drAccountExpenseEntry)

    End Sub
    ''' <summary>
    ''' Delete is reject status approval of specified Original_AccountExpenseEntryId
    ''' </summary>
    ''' <param name="Original_AccountExpenseEntryId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)>
    Public Function DeleteIsRejectStatusApproval(ByVal Original_AccountExpenseEntryId As Integer
                ) As Boolean


        Dim AccountExpenseEntryApprovals As TimeLiveDataSet.AccountExpenseEntryApprovalDataTable = AccountExpenseEntryApprovalAdapter.GetDataByAccountExpenseEntryId(Original_AccountExpenseEntryId)
        Dim AccountExpenseEntryApproval As TimeLiveDataSet.AccountExpenseEntryApprovalRow
        If AccountExpenseEntryApprovals.Rows.Count > 0 Then
            AccountExpenseEntryApproval = AccountExpenseEntryApprovals.Rows(0)
            For Each AccountExpenseEntryApproval In AccountExpenseEntryApprovals.Rows
                If AccountExpenseEntryApproval.IsRejected = True Then
                    Dim rowsAffected As Integer = AccountExpenseEntryApprovalAdapter.Delete(AccountExpenseEntryApproval.ExpenseApprovalId)
                    rowsAffected = 1
                End If
            Next
        End If
    End Function
    ''' <summary>
    ''' Delete is approved status approval of specified Original_AccountExpenseEntryId
    ''' </summary>
    ''' <param name="Original_AccountExpenseEntryId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)>
    Public Function DeleteIsApprovedStatusApproval(ByVal Original_AccountExpenseEntryId As Integer
            ) As Boolean


        Dim AccountExpenseEntryApprovals As TimeLiveDataSet.AccountExpenseEntryApprovalDataTable = AccountExpenseEntryApprovalAdapter.GetDataByAccountExpenseEntryId(Original_AccountExpenseEntryId)
        Dim AccountExpenseEntryApproval As TimeLiveDataSet.AccountExpenseEntryApprovalRow
        If AccountExpenseEntryApprovals.Rows.Count > 0 Then
            AccountExpenseEntryApproval = AccountExpenseEntryApprovals.Rows(0)
            For Each AccountExpenseEntryApproval In AccountExpenseEntryApprovals.Rows
                If AccountExpenseEntryApproval.IsApproved = True Then
                    Dim rowsAffected As Integer = AccountExpenseEntryApprovalAdapter.Delete(AccountExpenseEntryApproval.ExpenseApprovalId)
                    rowsAffected = 1
                End If
            Next
        End If
    End Function
    ''' <summary>
    ''' Get approved expense entry for email of specified AccountExpenseEntryId
    ''' </summary>
    ''' <param name="AccountExpenseEntryId"></param>
    ''' <returns>vueAccountExpenseEntryApprovedEmail data table</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)>
    Public Function GetApprovedAccountExpenseEntryForEmail(ByVal AccountExpenseEntryId) As TimeLiveDataSet.vueAccountExpenseEntryApprovedEmailDataTable
        Dim _vueAccountExpenseEntryApprovedEmail As New vueAccountExpenseEntryApprovedEmailTableAdapter
        Return _vueAccountExpenseEntryApprovedEmail.GetDataByAccountExpenseEntryId(AccountExpenseEntryId)
    End Function
    ''' <summary>
    ''' Get rejected expense entry for email of specified AccountExpenseEntryId
    ''' </summary>
    ''' <param name="AccountExpenseEntryId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)>
    Public Function GetRejectedAccountExpenseEntryForEmail(ByVal AccountExpenseEntryId) As TimeLiveDataSet.vueAccountExpenseEntryRejectedEmailDataTable
        Dim _vueAccountExpenseEntryRejectedEmail As New vueAccountExpenseEntryRejectedEmailTableAdapter
        Return _vueAccountExpenseEntryRejectedEmail.GetDataByAccountExpenseEntryId(AccountExpenseEntryId)
    End Function
    ''' <summary>
    ''' Get approved expense entry for email by expense sheetid of specified EmployeeExpenseSheetId
    ''' </summary>
    ''' <param name="AccountEmployeeExpenseSheetId"></param>
    ''' <returns>vueAccountExpenseEntryApprovedEmailGroup data table</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)>
    Public Function GetApprovedAccountExpenseEntryForEmailByExpenseSheetId(ByVal AccountEmployeeExpenseSheetId As Guid) As AccountExpenseEntry.vueAccountExpenseEntryApprovedEmailGroupDataTable
        Dim _vueAccountExpenseEntryApprovedEmail As New vueAccountExpenseEntryApprovedEmailGroupTableAdapter
        Return _vueAccountExpenseEntryApprovedEmail.GetDataByAccountEmployeeExpenseSheetId(AccountEmployeeExpenseSheetId)
    End Function
    ''' <summary>
    ''' Get expense entries by date range of specified AccountId, StartDate, EndDate
    ''' </summary>
    ''' <param name="AccountEmployeeExpenseSheetId"></param>
    ''' <returns>vueAccountExpenseEntryForQB data table</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)>
    Public Function GetExpenseEntriesByDateRange(ByVal AccountId As Integer, ByVal StartDate As Date, ByVal EndDate As Date) As AccountExpenseEntry.vueAccountExpenseEntryForQBDataTable
        Dim _vueAccountExpenseEntryForQB As New vueAccountExpenseEntryForQBTableAdapter
        Return _vueAccountExpenseEntryForQB.GetDataByAccountIdAndDateRange(AccountId, StartDate, EndDate)
    End Function
    ''' <summary>
    ''' Get expense entries by date range of specified AccountId, AccountEmployeeId, StartDate, EndDate
    ''' </summary>
    ''' <param name="AccountEmployeeExpenseSheetId"></param>
    ''' <returns>vueAccountExpenseEntryForQB data table</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)>
    Public Function GetExpenseEntriesByEmployeeIdAndDateRange(ByVal AccountId As Integer, ByVal AccountEmployeeId As Integer, ByVal StartDate As Date, ByVal EndDate As Date) As AccountExpenseEntry.vueAccountExpenseEntryForQBDataTable
        Dim _vueAccountExpenseEntryForQB As New vueAccountExpenseEntryForQBTableAdapter
        Return _vueAccountExpenseEntryForQB.GetDataByAccountEmployeeIdAndDateRange(AccountId, AccountEmployeeId, StartDate, EndDate)
    End Function
    ''' <summary>
    ''' Get rejected expense entry for email by expense sheet id of specified AccountEmployeeExpenseSheetId
    ''' </summary>
    ''' <param name="AccountEmployeeExpenseSheetId"></param>
    ''' <returns>vueAccountExpenseEntryRejectedEmailGroup data table</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)>
    Public Function GetRejectedAccountExpenseEntryForEmailByExpenseSheetId(ByVal AccountEmployeeExpenseSheetId As Guid) As AccountExpenseEntry.vueAccountExpenseEntryRejectedEmailGroupDataTable
        Dim _vueAccountExpenseEntryRejectedEmail As New vueAccountExpenseEntryRejectedEmailGroupTableAdapter
        Return _vueAccountExpenseEntryRejectedEmail.GetDataByAccountEmployeeExpenseSheetId(AccountEmployeeExpenseSheetId)
    End Function
    ''' <summary>
    ''' Get pending expense entry approvals with preference by approver employee id of specified ApproverEmployeeId
    ''' </summary>
    ''' <param name="ApproverEmployeeId"></param>
    ''' <returns>vueAccountExpenseEntryApprovalPendingEmailWithPreference data table</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)>
    Public Function GetPendingExpenseEntryApprovalsWithPreferenceByApproverEmployeeId(ByVal ApproverEmployeeId As Integer) As TimeLiveDataSet.vueAccountExpenseEntryApprovalPendingEmailWithPreferenceDataTable
        Dim _vueAccountExpenseEntryApprovalPendingEmailWithPreferenceTableAdapter As New vueAccountExpenseEntryApprovalPendingEmailWithPreferenceTableAdapter
        Return _vueAccountExpenseEntryApprovalPendingEmailWithPreferenceTableAdapter.GetDataByApproverEmployeeId(ApproverEmployeeId)
    End Function
    ''' <summary>
    ''' Get pending expense entry approvals with preference group by approver employee id
    ''' </summary>
    ''' <returns>vueAccountExpenseEntryApprovalPendingEmailWithPreferenceGroupByApproverEmployeeId data table</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)>
    Public Function GetPendingExpenseEntryApprovalsWithPreferenceGroupByApproverEmployeeId() As TimeLiveDataSet.vueAccountExpenseEntryApprovalPendingEmailWithPreferenceGroupByApproverEmployeeIdDataTable
        Dim _vueAccountExpenseEntryApprovalPendingEmailWithPreferenceGroupByApproverEmployeeIdTableAdapter As New vueAccountExpenseEntryApprovalPendingEmailWithPreferenceGroupByApproverEmployeeIdTableAdapter
        _vueAccountExpenseEntryApprovalPendingEmailWithPreferenceGroupByApproverEmployeeIdTableAdapter.SetCommandTimeOut(1000)
        Return _vueAccountExpenseEntryApprovalPendingEmailWithPreferenceGroupByApproverEmployeeIdTableAdapter.GetData()
    End Function
    ''' <summary>
    ''' Get data for expense entry status of specified AccountExpenseEntryId
    ''' </summary>
    ''' <param name="AccountExpenseEntryId"></param>
    ''' <returns>vueAccountExpenseEntryStatus data table</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)>
    Public Function GetDataForExpenseEntryStatus(ByVal AccountExpenseEntryId As Integer) As AccountExpenseEntry.vueAccountExpenseEntryStatusDataTable
        Dim _vueAccountExpenseEntryStatusTableAdapter As New vueAccountExpenseEntryStatusTableAdapter
        Return _vueAccountExpenseEntryStatusTableAdapter.GetDatavueAccountExpenseEntryStatus(AccountExpenseEntryId)
    End Function
    ''' <summary>
    ''' Get prepared email message for approved expense entry of specified drvueAccountExpenseEntryApprovedEmail, Comments
    ''' </summary>
    ''' <param name="drvueAccountExpenseEntryApprovedEmail"></param>
    ''' <param name="Comments"></param>
    ''' <returns>StringDictionary</returns>
    ''' <remarks></remarks>
    Public Function GetPreparedEMailMessageForApprovedExpenseEntry(ByVal drvueAccountExpenseEntryApprovedEmail As DataRow, ByVal Comments As String) As StringDictionary
        Dim dict As New StringDictionary
        dict.Add("[employeename]", drvueAccountExpenseEntryApprovedEmail.Item("EmployeeName"))
        dict.Add("[expensesheetdate]", LocaleUtilitiesBLL.ConvertDateToDateBaseCultureOfUser(drvueAccountExpenseEntryApprovedEmail.Item("ExpenseSheetDate")))
        dict.Add("[expensesheetdescription]", drvueAccountExpenseEntryApprovedEmail.Item("ExpenseSheetDescription"))
        dict.Add("[currencyamount]", drvueAccountExpenseEntryApprovedEmail.Item("BaseCurrencyCode") & " " & String.Format("{0:N}", drvueAccountExpenseEntryApprovedEmail.Item("BaseCurrencyAmount")))
        dict.Add("[status]", "Approved")
        dict.Add("[comments]", Comments)
        dict.Add("[approvedby]", DBUtilities.GetSessionEmployeeName)
        Return dict
    End Function
    ''' <summary>
    ''' Send approved expense entry of specified AccountEmployeeExpenseSheetId, Comments
    ''' </summary>
    ''' <param name="AccountEmployeeExpenseSheetId"></param>
    ''' <param name="Comments"></param>
    ''' <remarks></remarks>
    Public Sub SendApprovedExpenseEntry(ByVal AccountEmployeeExpenseSheetId As Guid, ByVal Comments As String)
        Try
            Dim objvueAccountExpenseEntryApprovedEmail As New AccountExpenseEntryBLL
            Dim dtvueAccountExpenseEntryApprovedEmail As AccountExpenseEntry.vueAccountExpenseEntryApprovedEmailGroupDataTable = objvueAccountExpenseEntryApprovedEmail.GetApprovedAccountExpenseEntryForEmailByExpenseSheetId(AccountEmployeeExpenseSheetId)
            Dim drvueAccountExpenseEntryApprovedEmail As AccountExpenseEntry.vueAccountExpenseEntryApprovedEmailGroupRow
            If dtvueAccountExpenseEntryApprovedEmail.Rows.Count > 0 Then
                drvueAccountExpenseEntryApprovedEmail = dtvueAccountExpenseEntryApprovedEmail.Rows(0)
                EMailUtilities.SendEMail("Your expense has been approved", "ExpenseApprovedTemplate", GetPreparedEMailMessageForApprovedExpenseEntry(drvueAccountExpenseEntryApprovedEmail, Comments), drvueAccountExpenseEntryApprovedEmail.EMailAddress, drvueAccountExpenseEntryApprovedEmail.EmployeeName, , EMailUtilities.EXPENSE_APPROVED_NOTIFICATION_INFORMATION_FROM)
            End If
            Dim dtvueAccountExpenseEntryApprovedEmailToApprover As AccountExpenseEntry.vueAccountExpenseEntryApprovedEmailToApproverDataTable = objvueAccountExpenseEntryApprovedEmail.GetApprovedAccountExpenseEntryForEmailToApproverByExpenseSheetId(AccountEmployeeExpenseSheetId, DBUtilities.GetSessionAccountEmployeeId)
            Dim drvueAccountExpenseEntryApprovedEmailToApprover As AccountExpenseEntry.vueAccountExpenseEntryApprovedEmailToApproverRow
            If dtvueAccountExpenseEntryApprovedEmailToApprover.Rows.Count > 0 Then
                drvueAccountExpenseEntryApprovedEmailToApprover = dtvueAccountExpenseEntryApprovedEmailToApprover.Rows(0)
                EMailUtilities.SendEMail(drvueAccountExpenseEntryApprovedEmailToApprover.EmployeeName & "'s expense has been approved", "ExpenseApprovedTemplate", GetPreparedEMailMessageForApprovedExpenseEntry(drvueAccountExpenseEntryApprovedEmailToApprover, Comments), DBUtilities.GetSessionEmailAddress, DBUtilities.GetSessionEmployeeName, , EMailUtilities.EXPENSE_APPROVED_NOTIFICATION_INFORMATION_FROM)
            End If
        Catch ex As Exception
        End Try
    End Sub
    ''' <summary>
    ''' Send expense approved email of specified AccountEmployeeExpenseSheetId, Comments
    ''' </summary>
    ''' <param name="AccountEmployeeExpenseSheetId"></param>
    ''' <param name="Comments"></param>
    ''' <remarks></remarks>
    Public Sub SendExpenseApprovedEMail(ByVal AccountEmployeeExpenseSheetId As Guid, ByVal Comments As String, ByVal ExpenseEntryId As ArrayList)
        SendApprovedExpenseEntry(AccountEmployeeExpenseSheetId, Comments)
        SendExpenseApprovalPendingEmail(AccountEmployeeExpenseSheetId, ExpenseEntryId)
        EMailUtilities.DequeueEmail()
    End Sub
    ''' <summary>
    ''' Get prepared email message for rejected expense of specified drvueAccountExpenseEntryRejectedEmail, Comments
    ''' </summary>
    ''' <param name="drvueAccountExpenseEntryRejectedEmail"></param>
    ''' <param name="Comments"></param>
    ''' <returns>StringDictionary</returns>
    ''' <remarks></remarks>
    Public Function GetPreparedEMailMessageForRejectedExpense(ByVal drvueAccountExpenseEntryRejectedEmail As DataRow, ByVal Comments As String) As StringDictionary
        Dim dict As New StringDictionary
        dict.Add("[employeename]", drvueAccountExpenseEntryRejectedEmail.Item("EmployeeName"))
        dict.Add("[expensesheetdate]", LocaleUtilitiesBLL.ConvertDateToDateBaseCultureOfUser(drvueAccountExpenseEntryRejectedEmail.Item("ExpenseSheetDate")))
        dict.Add("[expensesheetdescription]", drvueAccountExpenseEntryRejectedEmail.Item("ExpenseSheetDescription"))
        dict.Add("[currencyamount]", drvueAccountExpenseEntryRejectedEmail.Item("BaseCurrencyCode") & " " & String.Format("{0:N}", drvueAccountExpenseEntryRejectedEmail.Item("BaseCurrencyAmount")))
        dict.Add("[status]", "Rejected")
        dict.Add("[comments]", Comments)
        dict.Add("[rejectedby]", DBUtilities.GetSessionEmployeeName)
        Return dict
    End Function
    ''' <summary>
    ''' Send rejected expense entry of specified AccountEmployeeExpenseSheetId, Comments
    ''' </summary>
    ''' <param name="AccountEmployeeExpenseSheetId"></param>
    ''' <param name="Comments"></param>
    ''' <remarks></remarks>
    Public Sub SendRejectedExpenseEntry(ByVal AccountEmployeeExpenseSheetId As Guid, ByVal Comments As String)
        Dim objvueAccountExpenseEntryRejectedEmail As New AccountExpenseEntryBLL
        Dim dtvueAccountExpenseEntryRejectedEmail As AccountExpenseEntry.vueAccountExpenseEntryRejectedEmailGroupDataTable = objvueAccountExpenseEntryRejectedEmail.GetRejectedAccountExpenseEntryForEmailByExpenseSheetId(AccountEmployeeExpenseSheetId)
        Dim drvueAccountExpenseEntryRejectedEmail As AccountExpenseEntry.vueAccountExpenseEntryRejectedEmailGroupRow
        If dtvueAccountExpenseEntryRejectedEmail.Rows.Count > 0 Then
            drvueAccountExpenseEntryRejectedEmail = dtvueAccountExpenseEntryRejectedEmail.Rows(0)
            EMailUtilities.SendEMail("Your expense has been rejected", "ExpenseRejectedTemplate", GetPreparedEMailMessageForRejectedExpense(drvueAccountExpenseEntryRejectedEmail, Comments), drvueAccountExpenseEntryRejectedEmail.EMailAddress, drvueAccountExpenseEntryRejectedEmail.EmployeeName, , EMailUtilities.EXPENSE_REJECTED_NOTIFICATION_INFORMATION_FROM)
        End If
        Dim dtvueAccountExpenseEntryRejectedEmailToApprover As AccountExpenseEntry.vueAccountExpenseEntryRejectedEmailToApproverDataTable = objvueAccountExpenseEntryRejectedEmail.GetRejectedAccountExpenseEntryForEmailToApproverByExpenseSheetId(AccountEmployeeExpenseSheetId)
        Dim drvueAccountExpenseEntryRejectedEmailToApprover As AccountExpenseEntry.vueAccountExpenseEntryRejectedEmailToApproverRow
        If dtvueAccountExpenseEntryRejectedEmailToApprover.Rows.Count > 0 Then
            drvueAccountExpenseEntryRejectedEmailToApprover = dtvueAccountExpenseEntryRejectedEmailToApprover.Rows(0)
            EMailUtilities.SendEMail(drvueAccountExpenseEntryRejectedEmailToApprover.EmployeeName & "'s expense has been rejected", "ExpenseRejectedTemplate", GetPreparedEMailMessageForRejectedExpense(drvueAccountExpenseEntryRejectedEmailToApprover, Comments), DBUtilities.GetSessionEmailAddress, DBUtilities.GetSessionEmployeeName, , EMailUtilities.EXPENSE_REJECTED_NOTIFICATION_INFORMATION_FROM)
        End If
    End Sub
    ''' <summary>
    ''' Send expense rejected email of specified AccountEmployeeExpenseSheetId, Comments
    ''' </summary>
    ''' <param name="AccountEmployeeExpenseSheetId"></param>
    ''' <param name="Comments"></param>
    ''' <remarks></remarks>
    Public Sub SendExpenseRejectedEMail(ByVal AccountEmployeeExpenseSheetId As Guid, ByVal Comments As String)
        SendRejectedExpenseEntry(AccountEmployeeExpenseSheetId, Comments)
        EMailUtilities.DequeueEmail()
    End Sub
    ''' <summary>
    ''' Get prepared email message for pending expense of specified strBody, strHeader
    ''' </summary>
    ''' <param name="strBody"></param>
    ''' <param name="strHeader"></param>
    ''' <returns>StringDictionary</returns>
    ''' <remarks></remarks>
    Public Function GetPreparedEMailMessageForPendingExpense(ByVal strBody As String, ByVal strHeader As String) As StringDictionary
        Dim dict As New StringDictionary
        dict.Add("[strBody]", strBody)
        dict.Add("[strHeader]", strHeader)
        Dim URL As String = "<a href=""" & System.Configuration.ConfigurationManager.AppSettings("SitePrefix") & "ProjectAdmin/ExpenseApproval.aspx""" & ">" & System.Configuration.ConfigurationManager.AppSettings("SitePrefix") & "ProjectAdmin/ExpenseApproval.aspx" & "</a>"
        dict.Add("[url]", URL)
        Return dict
    End Function
    ''' <summary>
    ''' Send pending expense of specified AccountEmployeeId
    ''' </summary>
    ''' <param name="AccountEmployeeId"></param>
    ''' <remarks></remarks>
    Public Sub SendPendingExpense(ByVal AccountEmployeeId As Integer, ByVal IsFromSubmitOrApproval As Boolean)
        Dim BLL As New AccountExpenseEntryBLL
        'Dim dtPendingApprovals As TimeLiveDataSet.vueAccountExpenseEntryApprovalPendingEmailWithPreferenceDataTable
        Dim dt As DataTable
        If IsFromSubmitOrApproval = False Then
            dt = BLL.GetPendingExpenseEntryApprovalsWithPreferenceByApproverEmployeeId(AccountEmployeeId)
        Else
            dt = BLL.GetPendingExpenseEntryApprovalsWithPreferenceByApproverEmployeeIdForEmail(AccountEmployeeId)
        End If

        If dt.Rows.Count > 0 Then
            Dim drPendingApprovals As DataRow = dt.Rows(0)
            Dim strBody As String = ""
            Dim strHeader As String = ""
            Dim TDate As String
            Dim Description As String = ""

            strHeader = strHeader & IIf(strHeader = "", "", "") & "<td align=" & "center" & ">" & ("Employee Name" & "</td>" & "<td align=" & "center" & ">" & "Date" & "</td>" & "<td align=" & "center" & ">" & "Description" & "</td>" & "<td align=" & "center" & ">" & " Amount " & "</td>" & "<td align=" & "center" & ">" & "SubmittedDate" & "</td>")

            For Each drPendingApprovals In dt.Rows

                Dim CultureName As String = drPendingApprovals.Item("CultureInfoName")

                TDate = LocaleUtilitiesBLL.ConvertDateBaseToUserLocaleAsString(drPendingApprovals.Item("ExpenseSheetDate"), CultureName)

                If IsDBNull(drPendingApprovals("Description")) Then
                    Description = ""
                Else
                    Description = drPendingApprovals.Item("Description")
                End If

                Dim SubmittedDate As String
                If IsDBNull(drPendingApprovals("SubmittedDate")) Then
                    SubmittedDate = Now.Date.ToString
                Else
                    SubmittedDate = LocaleUtilitiesBLL.ConvertDateBaseToUserLocaleAsString(drPendingApprovals.Item("SubmittedDate"), CultureName)
                End If

                strBody = strBody & IIf(strBody = "", "", "<br/>") & "<tr>" & "<td>" & (drPendingApprovals.Item("EmployeeName") & "</td>" & "<td>" & TDate.ToString & "</td>" & "<td>" & Description & "</td>" & "<td align=" & "left" & ">" & drPendingApprovals.Item("BaseCurrencyCode") & " " & String.Format("{0:N}", drPendingApprovals.Item("Amount")) & "</td>" & "<td align=" & "center" & ">" & SubmittedDate & "</td>" & "</tr>")
            Next
            EMailUtilities.SendEMail("Expense approvals are due", "ExpensePendingTemplate", GetPreparedEMailMessageForPendingExpense(strBody, strHeader), drPendingApprovals.Item("ApproverEmailAddress"), , , EMailUtilities.EXPENSE_APPROVAL_PENDING_NOTIFICATION_INFORMATION_FROM)
        End If
    End Sub
    ''' <summary>
    ''' Send expense pending email of specified AccountEmployeeId
    ''' </summary>
    ''' <param name="AccountEmployeeId"></param>
    ''' <remarks></remarks>
    Public Sub SendExpensePendingEMail(ByVal AccountEmployeeId As Integer)

        SendPendingExpense(AccountEmployeeId, False)

    End Sub
    ''' <summary>
    ''' Get user culture name of specified drPendingApprovals
    ''' </summary>
    ''' <param name="drPendingApprovals"></param>
    ''' <returns>English-US</returns>
    ''' <remarks></remarks>
    Public Function GetUserCultureName(ByVal drPendingApprovals As AccountExpenseEntry.vueAccountExpenseEntryApprovalPendingEmailWithPreferenceGroupByExpenseSheetAndApproverEmployeesRow)
        If IsDBNull(drPendingApprovals.Item("CultureInfoName")) Or drPendingApprovals.Item("CultureInfoName").ToString = "auto" Then
            Return "en-us"
        Else
            Return drPendingApprovals.Item("CultureInfoName")
        End If
    End Function
    ''' <summary>
    ''' Get default schedule email send time of specified data row
    ''' </summary>
    ''' <param name="dr"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetDefaultScheduleEmailSendTime(ByVal dr As DataRow) As DateTime
        Dim BLL As New AccountExpenseEntryBLL
        'Dim dt As TimeLiveDataSet.vueAccountExpenseEntryApprovalPendingEmailWithPreferenceGroupByApproverEmployeeIdDataTable = BLL.GetPendingExpenseEntryApprovalsWithPreferenceGroupByApproverEmployeeId
        'If dt.Rows.Count > 0 Then
        '= dt.Rows(0)

        If Not IsDBNull(dr.Item("ScheduledEmailSendTime")) Then
            Return dr.Item("ScheduledEmailSendTime")
        Else
            Return "11:00:00 PM"
        End If
        'End If
    End Function
    ''' <summary>
    ''' Get current exchange rate of specified AccountCurrencyId, ExpenseEntryDate
    ''' </summary>
    ''' <param name="AccountCurrencyId"></param>
    ''' <param name="ExpenseEntryDate"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetCurrenctExchangeRate(ByVal AccountCurrencyId As Integer, ByVal ExpenseEntryDate As Date) As Decimal

        Dim drExchangeRate As AccountCurrencyExchangeRate.AccountCurrencyExchangeRateRow

        Dim ExchangeRateBLL As New AccountCurrencyExchangeRateBLL

        Dim dtExchangeRate As AccountCurrencyExchangeRate.AccountCurrencyExchangeRateDataTable = ExchangeRateBLL.GetExchangeRateByAccountCurrencyIdAndExpenseEntryDate(AccountCurrencyId, ExpenseEntryDate)

        If dtExchangeRate.Rows.Count > 0 Then
            drExchangeRate = dtExchangeRate.Rows(0)
            If Not IsDBNull(drExchangeRate.Item("ExchangeRate")) Then
                Return drExchangeRate.ExchangeRate
            Else
                Return 0
            End If
        Else
            Dim drExchangeRates As AccountCurrencyExchangeRate.AccountCurrencyExchangeRateRow
            Dim dtExchangeRates As AccountCurrencyExchangeRate.AccountCurrencyExchangeRateDataTable = ExchangeRateBLL.GetExchangeRateByAccountCurrencyId(AccountCurrencyId)
            If dtExchangeRates.Rows.Count > 0 Then
                drExchangeRates = dtExchangeRates.Rows(0)
                If Not IsDBNull(drExchangeRates.Item("ExchangeRate")) Then
                    Return drExchangeRates.ExchangeRate
                End If
            End If
        End If
    End Function
    ''' <summary>
    ''' Update exchange rate of expense entry of specified ExchangeRate, StartDate, EndDate, AccountCurrencyId
    ''' </summary>
    ''' <param name="ExchangeRate"></param>
    ''' <param name="StartDate"></param>
    ''' <param name="EndDate"></param>
    ''' <param name="AccountCurrencyId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function UpdateExchangeRateOfExpenseEntry(ByVal ExchangeRate As Decimal, ByVal StartDate As Date, ByVal EndDate As Date, ByVal AccountCurrencyId As Integer) As Decimal
        Return Adapter.UpdateExchangeRateOfExpenseEntry(ExchangeRate, StartDate, EndDate, AccountCurrencyId)
    End Function
    ''' <summary>
    ''' Update exchange rate of expense entry unbillable of specified StartDate, EndDate, AccountCurrencyId
    ''' </summary>
    ''' <param name="StartDate"></param>
    ''' <param name="EndDate"></param>
    ''' <param name="AccountCurrencyId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function UpdateExchangeRateOfExpenseEntryUnBillable(ByVal StartDate As Date, ByVal EndDate As Date, ByVal AccountCurrencyId As Integer) As Decimal
        Return Adapter.UpdateExchangeRateOfExpenseEntryUnBillable(StartDate, EndDate, AccountCurrencyId)
    End Function
    ''' <summary>
    ''' Update account base currency id of specified AccountBaseCurrencyId, ExchangeRate, AccountCurrencyId
    ''' </summary>
    ''' <param name="AccountBaseCurrencyId"></param>
    ''' <param name="ExchangeRate"></param>
    ''' <param name="AccountCurrencyId"></param>
    ''' <remarks></remarks>
    Public Sub UpdateAccountBaseCurrencyId(ByVal AccountBaseCurrencyId As Integer, ByVal ExchangeRate As Decimal, ByVal AccountCurrencyId As Integer)
        Adapter.UpdateCurrencyOfWholeAccount(AccountCurrencyId, AccountBaseCurrencyId, ExchangeRate, DBUtilities.GetSessionAccountId)
    End Sub
    ''' <summary>
    ''' Update currencies of expense entry of specified Original_AccountId, AccountCurrencyId
    ''' </summary>
    ''' <param name="Original_AccountId"></param>
    ''' <param name="AccountCurrencyId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)>
    Public Function UpdateCurrenciesOfExpenseEntry(ByVal Original_AccountId As Integer, ByVal AccountCurrencyId As Integer) As Boolean
        Dim dr As TimeLiveDataSet.AccountExpenseEntryRow
        Dim dt As TimeLiveDataSet.AccountExpenseEntryDataTable
        Dim BLL As New AccountCurrencyExchangeRateBLL
        dt = Me.Adapter.GetDataByAccountId(Original_AccountId)
        If dt.Rows.Count > 0 Then
            dr = dt.Rows(0)
            For Each dr In dt.Rows
                dr.AccountCurrencyId = AccountCurrencyId
                dr.ExchangeRate = BLL.GetCurrentExchangeRateByCurrencyIdAndDate(AccountCurrencyId, dr.AccountExpenseEntryDate)
            Next
        End If

        Dim rowsAffected As Integer = Adapter.Update(dt)

        ' Return true if precisely one row was updated, otherwise false
        Return rowsAffected = 1
    End Function
    ''' <summary>
    ''' Update submitted of specified Submitted, ExpenseEntryDate
    ''' </summary>
    ''' <param name="Submitted"></param>
    ''' <param name="ExpenseEntryDate"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)>
    Public Function UpdateSubmitted(ByVal Submitted As Boolean, ByVal ExpenseEntryDate As Date) As Boolean
        Adapter.UpdateSubmitted(Submitted, ExpenseEntryDate)
    End Function
    ''' <summary>
    ''' Update rejected of specified Rejected, ExpenseEntryDate
    ''' </summary>
    ''' <param name="Rejected"></param>
    ''' <param name="ExpenseEntryDate"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)>
    Public Function UpdateRejected(ByVal Rejected As Boolean, ByVal ExpenseEntryDate As Date) As Boolean
        Adapter.UpdateRejected(Rejected, ExpenseEntryDate)
    End Function
    ''' <summary>
    ''' Update submitted by employee expense sheet id of specified Submitted, AccountEmployeeExpenseSheetId
    ''' </summary>
    ''' <param name="Submitted"></param>
    ''' <param name="AccountEmployeeExpenseSheetId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)>
    Public Function UpdateSubmittedByAccountEmployeeExpenseSheetId(ByVal Submitted As Boolean, ByVal AccountEmployeeExpenseSheetId As Guid) As Boolean
        Adapter.UpdateSubmittedByExpenseSheetId(Submitted, AccountEmployeeExpenseSheetId)
    End Function
    ''' <summary>
    ''' Update rejected by employee expense sheet id of specified Rejected, AccountEmployeeExpenseSheetId
    ''' </summary>
    ''' <param name="Rejected"></param>
    ''' <param name="AccountEmployeeExpenseSheetId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)>
    Public Function UpdateRejectedByAccountEmployeeExpenseSheetId(ByVal Rejected As Boolean, ByVal AccountEmployeeExpenseSheetId As Guid) As Boolean
        Adapter.UpdateRejectedByExpenseSheetId(Rejected, AccountEmployeeExpenseSheetId)
    End Function
    ''' <summary>
    ''' SetSubmittedStatus of specified StatusLabelName, StatusTextBoxName, StatusNoteLabelName, StatusImageName, Row, i, ApprovedDataItemName,
    ''' SubmittedDataItemName, SubmittedDataItemName, RejectedDataItemName, GV
    ''' </summary>
    ''' <param name="StatusLabelName"></param>
    ''' <param name="StatusTextBoxName"></param>
    ''' <param name="StatusNoteLabelName"></param>
    ''' <param name="StatusImageName"></param>
    ''' <param name="Row"></param>
    ''' <param name="i"></param>
    ''' <param name="ApprovedDataItemName"></param>
    ''' <param name="SubmittedDataItemName"></param>
    ''' <param name="RejectedDataItemName"></param>
    ''' <param name="GV"></param>
    ''' <remarks></remarks>
    Public Shared Sub SetSubmittedStatus(ByVal StatusLabelName As String, ByVal StatusTextBoxName As String, ByVal StatusNoteLabelName As String, ByVal StatusImageName As String, ByVal Row As GridViewRow, ByVal i As Integer, ByVal ApprovedDataItemName As String, ByVal SubmittedDataItemName As String, ByVal RejectedDataItemName As String, ByVal GV As GridView)
        Dim BLL As New AccountExpenseEntryBLL
        Dim dt As AccountExpenseEntry.vueAccountExpenseEntryStatusDataTable
        dt = BLL.GetDataForExpenseEntryStatus(DataBinder.Eval(Row.DataItem, "AccountExpenseEntryId"))
        Dim dr As AccountExpenseEntry.vueAccountExpenseEntryStatusRow
        If dt.Rows.Count > 0 Then
            dr = dt.Rows(0)
            Dim StatusText As String
            If Not IsDBNull(DataBinder.Eval(Row.DataItem, SubmittedDataItemName)) Then
                If DataBinder.Eval(Row.DataItem, SubmittedDataItemName) = True And DataBinder.Eval(Row.DataItem, ApprovedDataItemName) <> True Then
                    GVColumnVisible(GV, i)
                    StatusText = Resources.TimeLive.Resource.Submitted_By__ & dr.EmployeeName & Chr(13) & Resources.TimeLive.Resource.Status___Submitted & Chr(13) & Resources.TimeLive.Resource.Submitted_On__ & dr.ModifiedOn.Date
                    SetSubmitted(CType(Row.Cells(i).FindControl(StatusLabelName), Label), CType(Row.Cells(i).FindControl(StatusNoteLabelName), Label), CType(Row.Cells(i).FindControl(StatusTextBoxName), TextBox), StatusText, CType(Row.Cells(i).FindControl(StatusImageName), System.Web.UI.WebControls.Image))
                ElseIf DataBinder.Eval(Row.DataItem, ApprovedDataItemName) = True Then
                    GVColumnVisible(GV, i)
                    If IsDBNull(dr.Item("IsApproved")) OrElse dr.Item("IsApproved") = False Then
                        GVColumnVisible(GV, i)
                        StatusText = Resources.TimeLive.Resource.Status___Approved
                        SetApproved(CType(Row.Cells(i).FindControl(StatusLabelName), Label), CType(Row.Cells(i).FindControl(StatusNoteLabelName), Label), CType(Row.Cells(i).FindControl(StatusTextBoxName), TextBox), StatusText, CType(Row.Cells(i).FindControl(StatusImageName), System.Web.UI.WebControls.Image), "NotRequired")
                    ElseIf dr.Item("IsApproved") = True Then
                        GVColumnVisible(GV, i)
                        StatusText = Resources.TimeLive.Resource.Approved_By__ & dr.ApproverEmployeeName & Chr(13) & Resources.TimeLive.Resource.Status___Approved & Chr(13) & Resources.TimeLive.Resource.Approved_On__ & dr.ApprovedOn.Date
                        SetApproved(CType(Row.Cells(i).FindControl(StatusLabelName), Label), CType(Row.Cells(i).FindControl(StatusNoteLabelName), Label), CType(Row.Cells(i).FindControl(StatusTextBoxName), TextBox), StatusText, CType(Row.Cells(i).FindControl(StatusImageName), System.Web.UI.WebControls.Image), "Required")
                    End If
                ElseIf Not IsDBNull(DataBinder.Eval(Row.DataItem, RejectedDataItemName)) AndAlso Not DataBinder.Eval(Row.DataItem, RejectedDataItemName) = False Then
                    If DataBinder.Eval(Row.DataItem, RejectedDataItemName) = True Then
                        If DataBinder.Eval(Row.DataItem, RejectedDataItemName) = True Then
                            GVColumnVisible(GV, i)
                            StatusText = Resources.TimeLive.Resource.Rejected_By__ & dr.ApproverEmployeeName & Chr(13) & Resources.TimeLive.Resource.Status___Rejected & Chr(13) & Resources.TimeLive.Resource.Rejected_On__ & dr.ApprovedOn.Date
                            SetRejected(CType(Row.Cells(i).FindControl(StatusLabelName), Label), CType(Row.Cells(i).FindControl(StatusNoteLabelName), Label), CType(Row.Cells(i).FindControl(StatusTextBoxName), TextBox), StatusText, CType(Row.Cells(i).FindControl(StatusImageName), System.Web.UI.WebControls.Image))
                        End If
                    End If
                Else
                    GVColumnVisible(GV, i)
                    StatusText = Resources.TimeLive.Resource.Not_Submitted_
                    SetNotSubmitted(CType(Row.Cells(i).FindControl(StatusLabelName), Label), CType(Row.Cells(i).FindControl(StatusNoteLabelName), Label), CType(Row.Cells(i).FindControl(StatusTextBoxName), TextBox), StatusText, CType(Row.Cells(i).FindControl(StatusImageName), System.Web.UI.WebControls.Image))
                End If
            Else
                If IsDBNull(dr.Item("IsApproved")) Then
                    GVColumnVisible(GV, i)
                    StatusText = Resources.TimeLive.Resource.Status___Approved
                    SetApproved(CType(Row.Cells(i).FindControl(StatusLabelName), Label), CType(Row.Cells(i).FindControl(StatusNoteLabelName), Label), CType(Row.Cells(i).FindControl(StatusTextBoxName), TextBox), StatusText, CType(Row.Cells(i).FindControl(StatusImageName), System.Web.UI.WebControls.Image), "NotRequired")
                End If
            End If
        End If
    End Sub
    ''' <summary>
    ''' For visible grid view column
    ''' </summary>
    ''' <param name="GV"></param>
    ''' <param name="i"></param>
    ''' <remarks></remarks>
    Public Shared Sub GVColumnVisible(ByVal GV As GridView, ByVal i As Integer)
        If Not GV Is Nothing Then
            GV.Columns(i).Visible = True
        End If
    End Sub
    ''' <summary>
    ''' Set submitted of specified lblStatus, lblStatusNote, StatusTexbox, StatusText, StatusImage
    ''' </summary>
    ''' <param name="lblStatus"></param>
    ''' <param name="lblStatusNote"></param>
    ''' <param name="StatusTexbox"></param>
    ''' <param name="StatusText"></param>
    ''' <param name="StatusImage"></param>
    ''' <remarks></remarks>
    Public Shared Sub SetSubmitted(ByVal lblStatus As Label, ByVal lblStatusNote As Label, ByVal StatusTexbox As TextBox, ByVal StatusText As String, ByVal StatusImage As System.Web.UI.WebControls.Image)
        lblStatus.Text = Resources.TimeLive.Resource.Time_Entry_Status___Submitted
        lblStatusNote.Text = Resources.TimeLive.Resource.Note___Submitted___Waiting_For_Approval
        StatusTexbox.Text = StatusText
        StatusImage.Visible = True
        StatusImage.ImageUrl = "~/images/SubmittedStatus.gif"
    End Sub
    ''' <summary>
    ''' Set approved of specified lblStatus, lblStatusNote, StatusTexbox, StatusText, StatusImage, ApprovalType
    ''' </summary>
    ''' <param name="lblStatus"></param>
    ''' <param name="lblStatusNote"></param>
    ''' <param name="StatusTexbox"></param>
    ''' <param name="StatusText"></param>
    ''' <param name="StatusImage"></param>
    ''' <param name="ApprovalType"></param>
    ''' <remarks></remarks>
    Public Shared Sub SetApproved(ByVal lblStatus As Label, ByVal lblStatusNote As Label, ByVal StatusTexbox As TextBox, ByVal StatusText As String, ByVal StatusImage As System.Web.UI.WebControls.Image, ByVal ApprovalType As String)
        If ApprovalType = "Required" Then
            lblStatus.Text = Resources.TimeLive.Resource.Time_Entry_Status___Approved
            lblStatusNote.Text = Resources.TimeLive.Resource.Note___Approved
            StatusTexbox.Text = StatusText
            StatusImage.Visible = True
            StatusImage.ImageUrl = "~/images/ApprovedStatus.gif"
        ElseIf ApprovalType = "NotRequired" Then
            lblStatus.Text = Resources.TimeLive.Resource.Time_Entry_Status___Approved
            lblStatusNote.Text = Resources.TimeLive.Resource.Note___Approval_Not_Required_For_This_Time_Entry
            StatusTexbox.Text = StatusText
            StatusImage.Visible = True
            StatusImage.ImageUrl = "~/images/ApprovedStatus.gif"
        End If
    End Sub
    ''' <summary>
    ''' Set rejected of specified lblStatus, lblStatusNote, StatusTexbox, StatusText, StatusImage
    ''' </summary>
    ''' <param name="lblStatus"></param>
    ''' <param name="lblStatusNote"></param>
    ''' <param name="StatusTexbox"></param>
    ''' <param name="StatusText"></param>
    ''' <param name="StatusImage"></param>
    ''' <remarks></remarks>
    Public Shared Sub SetRejected(ByVal lblStatus As Label, ByVal lblStatusNote As Label, ByVal StatusTexbox As TextBox, ByVal StatusText As String, ByVal StatusImage As System.Web.UI.WebControls.Image)
        lblStatus.Text = Resources.TimeLive.Resource.Time_Entry_Status___Rejected
        lblStatusNote.Text = Resources.TimeLive.Resource.Note___Rejected___Waiting_For_Re_Submit
        StatusTexbox.Text = StatusText
        StatusImage.Visible = True
        StatusImage.ImageUrl = "~/images/RejectedStatus.gif"
    End Sub
    ''' <summary>
    ''' Set not submitted of specified lblStatus, lblStatusNote, StatusTexbox, StatusText, StatusImage
    ''' </summary>
    ''' <param name="lblStatus"></param>
    ''' <param name="lblStatusNote"></param>
    ''' <param name="StatusTexbox"></param>
    ''' <param name="StatusText"></param>
    ''' <param name="StatusImage"></param>
    ''' <remarks></remarks>
    Public Shared Sub SetNotSubmitted(ByVal lblStatus As Label, ByVal lblStatusNote As Label, ByVal StatusTexbox As TextBox, ByVal StatusText As String, ByVal StatusImage As System.Web.UI.WebControls.Image)
        lblStatus.Text = Resources.TimeLive.Resource.Time_Entry_Status___Not_Submitted
        lblStatusNote.Text = Resources.TimeLive.Resource.Note___Not_Submitted___Waiting_For_Submit
        StatusTexbox.Text = StatusText
        StatusImage.Visible = True
        StatusImage.ImageUrl = "~/images/NotSubmittedStatus.gif"
    End Sub
    ''' <summary>
    ''' Check expense has tax amount of specified AccountId, AccountExpenseId
    ''' </summary>
    ''' <param name="AccountId"></param>
    ''' <param name="AccountExpenseId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function IsExpenseHasTaxAmount(ByVal AccountId As Integer, ByVal AccountExpenseId As Integer) As Boolean
        Dim dtAccountExpenseWithTaxCode As TimeLiveDataSet.vueAccountExpenseWithTaxCodeDataTable = New AccountExpenseBLL().GetvueAccountExpensesWithTaxCodeByAccountIdAndAccountExpenseId(AccountId, AccountExpenseId)
        Dim drAccountExpenseWithTaxCode As TimeLiveDataSet.vueAccountExpenseWithTaxCodeRow
        If dtAccountExpenseWithTaxCode.Rows.Count > 0 Then
            drAccountExpenseWithTaxCode = dtAccountExpenseWithTaxCode.Rows(0)
            If Not IsDBNull(drAccountExpenseWithTaxCode.Item("TaxCode")) Then
                Return True
            End If
        End If
        Return False
    End Function
    ''' <summary>
    ''' Lock or unlock time entry
    ''' </summary>
    ''' <param name="row"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function DoUnlock(ByVal row As GridViewRow) As Boolean

        Dim Submitted As Boolean

        Dim IsApproved As Boolean
        Dim LockSubmittedRecords As Boolean = LocaleUtilitiesBLL.IsShowLockSubmittedRecords
        Dim LockApprovedRecords As Boolean = LocaleUtilitiesBLL.IsShowLockApprovedRecords

        Submitted = IIf(IsDBNull(DataBinder.Eval(row.DataItem, "Submitted")), False, DataBinder.Eval(row.DataItem, "Submitted"))
        IsApproved = IIf(IsDBNull(DataBinder.Eval(row.DataItem, "IsApproved")), False, DataBinder.Eval(row.DataItem, "IsApproved"))

        If (LockSubmittedRecords = True And Submitted = True) Or (LockApprovedRecords = True And IsApproved = True) Then
            Return False
        Else
            Return True
        End If

    End Function
    ''' <summary>
    ''' Do unlock for expense sheet
    ''' </summary>
    ''' <param name="row"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function DoUnlockForExpenseSheet(ByVal row As GridViewRow) As Boolean

        Dim Submitted As Boolean

        Dim IsApproved As Boolean
        Dim LockSubmittedRecords As Boolean = LocaleUtilitiesBLL.IsShowLockSubmittedRecords
        Dim LockApprovedRecords As Boolean = LocaleUtilitiesBLL.IsShowLockApprovedRecords

        Submitted = IIf(IsDBNull(DataBinder.Eval(row.DataItem, "Submitted")), False, DataBinder.Eval(row.DataItem, "Submitted"))
        IsApproved = IIf(IsDBNull(DataBinder.Eval(row.DataItem, "Approved")), False, DataBinder.Eval(row.DataItem, "Approved"))

        If (LockSubmittedRecords = True And Submitted = True) Or (LockApprovedRecords = True And IsApproved = True) Then
            Return False
        Else
            Return True
        End If

    End Function
    ''' <summary>
    ''' Get approval entries for team lead by expense sheet of specified AccountEmployeeId, ExpenseEntryAccountEmployeeId, ExpenseEntryStartDate,
    ''' ExpenseEntryEndDate, IncludeDateRange
    ''' </summary>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="ExpenseEntryAccountEmployeeId"></param>
    ''' <param name="ExpenseEntryStartDate"></param>
    ''' <param name="ExpenseEntryEndDate"></param>
    ''' <param name="IncludeDateRange"></param>
    ''' <returns>vueAccountExpenseEntryApprovalPending data table</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)>
    Public Function GetApprovalEntriesForTeamLeadByExpenseSheet(ByVal AccountEmployeeId As Integer, ByVal ExpenseEntryAccountEmployeeId As Integer, ByVal ExpenseEntryStartDate As Date, ByVal ExpenseEntryEndDate As Date, ByVal IncludeDateRange As Boolean) As TimeLiveDataSet.vueAccountExpenseEntryApprovalPendingDataTable
        Dim _vueAccountExpenseEntryApprovalPendingTableAdapter As New vueAccountExpenseentryApprovalPendingTableAdapter
        Return _vueAccountExpenseEntryApprovalPendingTableAdapter.GetApprovalEntriesForTeamLeadByExpenseSheet(ExpenseEntryAccountEmployeeId, IncludeDateRange, ExpenseEntryStartDate, ExpenseEntryEndDate, AccountEmployeeId)
    End Function
    ''' <summary>
    ''' GetApprovalEntriesForProjectManagerByExpenseSheet of specified AccountEmployeeId, ExpenseEntryAccountEmployeeId, ExpenseEntryStartDate,
    ''' ExpenseEntryEndDate, IncludeDateRange
    ''' </summary>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="ExpenseEntryAccountEmployeeId"></param>
    ''' <param name="ExpenseEntryStartDate"></param>
    ''' <param name="ExpenseEntryEndDate"></param>
    ''' <param name="IncludeDateRange"></param>
    ''' <returns>vueAccountExpenseEntryApprovalPending data table</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)>
    Public Function GetApprovalEntriesForProjectManagerByExpenseSheet(ByVal AccountEmployeeId As Integer, ByVal ExpenseEntryAccountEmployeeId As Integer, ByVal ExpenseEntryStartDate As Date, ByVal ExpenseEntryEndDate As Date, ByVal IncludeDateRange As Boolean) As TimeLiveDataSet.vueAccountExpenseEntryApprovalPendingDataTable
        Dim _vueAccountExpenseEntryApprovalPendingTableAdapter As New vueAccountExpenseentryApprovalPendingTableAdapter
        Return _vueAccountExpenseEntryApprovalPendingTableAdapter.GetApprovalEntriesForProjectManagerByExpenseSheet(ExpenseEntryAccountEmployeeId, IncludeDateRange, ExpenseEntryStartDate, ExpenseEntryEndDate, AccountEmployeeId)
    End Function
    ''' <summary>
    ''' Get approval entries for specific employee by expense sheet of specified AccountEmployeeId, ExpenseEntryAccountEmployeeId,
    ''' ExpenseEntryStartDate, ExpenseEntryEndDate, IncludeDateRange
    ''' </summary>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="ExpenseEntryAccountEmployeeId"></param>
    ''' <param name="ExpenseEntryStartDate"></param>
    ''' <param name="ExpenseEntryEndDate"></param>
    ''' <param name="IncludeDateRange"></param>
    ''' <returns>vueAccountExpenseEntryApprovalPending data table</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)>
    Public Function GetApprovalEntriesForSpecificEmployeeByExpenseSheet(ByVal AccountEmployeeId As Integer, ByVal ExpenseEntryAccountEmployeeId As Integer, ByVal ExpenseEntryStartDate As Date, ByVal ExpenseEntryEndDate As Date, ByVal IncludeDateRange As Boolean) As TimeLiveDataSet.vueAccountExpenseEntryApprovalPendingDataTable
        Dim _vueAccountExpenseEntryApprovalPendingTableAdapter As New vueAccountExpenseentryApprovalPendingTableAdapter
        Return _vueAccountExpenseEntryApprovalPendingTableAdapter.GetApprovalEntriesForSpecificEmployeeByExpenseSheet(ExpenseEntryAccountEmployeeId, IncludeDateRange, ExpenseEntryStartDate, ExpenseEntryEndDate, AccountEmployeeId)
    End Function
    ''' <summary>
    ''' Get approval entries for specific external user by expense sheet of specified AccountEmployeeId, ExpenseEntryAccountEmployeeId,
    ''' ExpenseEntryStartDate, ExpenseEntryEndDate, IncludeDateRange
    ''' </summary>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="ExpenseEntryAccountEmployeeId"></param>
    ''' <param name="ExpenseEntryStartDate"></param>
    ''' <param name="ExpenseEntryEndDate"></param>
    ''' <param name="IncludeDateRange"></param>
    ''' <returns>vueAccountExpenseEntryApprovalPending data table</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)>
    Public Function GetApprovalEntriesForSpecificExternalUserByExpenseSheet(ByVal AccountEmployeeId As Integer, ByVal ExpenseEntryAccountEmployeeId As Integer, ByVal ExpenseEntryStartDate As Date, ByVal ExpenseEntryEndDate As Date, ByVal IncludeDateRange As Boolean) As TimeLiveDataSet.vueAccountExpenseEntryApprovalPendingDataTable
        Dim _vueAccountExpenseEntryApprovalPendingTableAdapter As New vueAccountExpenseentryApprovalPendingTableAdapter
        Return _vueAccountExpenseEntryApprovalPendingTableAdapter.GetApprovalEntriesForSpecificExternalUserByExpenseSheet(ExpenseEntryAccountEmployeeId, IncludeDateRange, ExpenseEntryStartDate, ExpenseEntryEndDate, AccountEmployeeId)
    End Function
    ''' <summary>
    ''' Get approval entries for employee manager by expense sheet of specified AccountEmployeeId, ExpenseEntryAccountEmployeeId,
    ''' ExpenseEntryStartDate, ExpenseEntryEndDate, IncludeDateRange
    ''' </summary>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="ExpenseEntryAccountEmployeeId"></param>
    ''' <param name="ExpenseEntryStartDate"></param>
    ''' <param name="ExpenseEntryEndDate"></param>
    ''' <param name="IncludeDateRange"></param>
    ''' <returns>vueAccountExpenseEntryApprovalPending data table</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)>
    Public Function GetApprovalEntriesForEmployeeManagerByExpenseSheet(ByVal AccountEmployeeId As Integer, ByVal ExpenseEntryAccountEmployeeId As Integer, ByVal ExpenseEntryStartDate As Date, ByVal ExpenseEntryEndDate As Date, ByVal IncludeDateRange As Boolean) As TimeLiveDataSet.vueAccountExpenseEntryApprovalPendingDataTable
        Dim _vueAccountExpenseEntryApprovalPendingTableAdapter As New vueAccountExpenseentryApprovalPendingTableAdapter
        Return _vueAccountExpenseEntryApprovalPendingTableAdapter.GetApprovalEntriesForEmployeeManagerByExpenseSheet(ExpenseEntryAccountEmployeeId, IncludeDateRange, ExpenseEntryStartDate, ExpenseEntryEndDate, AccountEmployeeId)
    End Function
    ''' <summary>
    ''' Get view expense entry approval pending by employee expense sheet id of specified AccountEmployeeExpenseSheetId
    ''' </summary>
    ''' <param name="AccountEmployeeExpenseSheetId"></param>
    ''' <returns>vueAccountExpenseEntryApprovalPending data table</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)>
    Public Function GetvueAccountExpenseEntryApprovalPendingByEmployeeExpenseSheetId(ByVal AccountEmployeeExpenseSheetId As Guid) As TimeLiveDataSet.vueAccountExpenseEntryApprovalPendingDataTable
        Dim _vueAccountExpenseEntryApprovalPendingTableAdapter As New vueAccountExpenseentryApprovalPendingTableAdapter
        Return _vueAccountExpenseEntryApprovalPendingTableAdapter.GetDataByAccountEmployeeExpenseSheetId(AccountEmployeeExpenseSheetId)
    End Function
    ''' <summary>
    ''' BulkExpenseEntryApprovalEntriesForApproved of specified AccountEmployeeExpenseSheetId, Chk, Comments, ApprovalType,
    ''' ExpenseEntryAccountEmployeeId, IncludeDateRange, ExpenseEntryStartDate, ExpenseEntryEndDate, AccountEmployeeId
    ''' </summary>
    ''' <param name="AccountEmployeeExpenseSheetId"></param>
    ''' <param name="Chk"></param>
    ''' <param name="Comments"></param>
    ''' <param name="ApprovalType"></param>
    ''' <param name="ExpenseEntryAccountEmployeeId"></param>
    ''' <param name="IncludeDateRange"></param>
    ''' <param name="ExpenseEntryStartDate"></param>
    ''' <param name="ExpenseEntryEndDate"></param>
    ''' <param name="AccountEmployeeId"></param>
    ''' <remarks></remarks>
    Public Sub BulkExpenseEntryApprovalEntriesForApproved(ByVal AccountEmployeeExpenseSheetId As Guid, ByVal Chk As CheckBox, ByVal Comments As String,
    ByVal ApprovalType As String, ByVal ExpenseEntryAccountEmployeeId As Integer, ByVal IncludeDateRange As Boolean,
    ByVal ExpenseEntryStartDate As Date, ByVal ExpenseEntryEndDate As Date, ByVal AccountEmployeeId As System.Nullable(Of Integer), ByVal ApprovalPathSequence As Integer)

        If ApprovalType = "TeamLead" Then
            ApprovedTeamLeadEntries(AccountEmployeeExpenseSheetId, Chk, Comments, ExpenseEntryAccountEmployeeId, IncludeDateRange, ExpenseEntryStartDate, ExpenseEntryEndDate, AccountEmployeeId, ApprovalPathSequence)
        End If
        If ApprovalType = "ProjectManager" Then
            ApprovedProjectManagerEntries(AccountEmployeeExpenseSheetId, Chk, Comments, ExpenseEntryAccountEmployeeId, IncludeDateRange, ExpenseEntryStartDate, ExpenseEntryEndDate, AccountEmployeeId, ApprovalPathSequence)
        End If
        If ApprovalType = "SpecificEmployee" Then
            ApprovedSpecificEmployeeEntries(AccountEmployeeExpenseSheetId, Chk, Comments, ExpenseEntryAccountEmployeeId, IncludeDateRange, ExpenseEntryStartDate, ExpenseEntryEndDate, AccountEmployeeId, ApprovalPathSequence)
        End If
        If ApprovalType = "SpecificExternalUser" Then
            ApprovedSpecificExternalUserEntries(AccountEmployeeExpenseSheetId, Chk, Comments, ExpenseEntryAccountEmployeeId, IncludeDateRange, ExpenseEntryStartDate, ExpenseEntryEndDate, AccountEmployeeId, ApprovalPathSequence)
        End If
        If ApprovalType = "EmployeeManager" Then
            ApprovedEmployeeManagerEntries(AccountEmployeeExpenseSheetId, Chk, Comments, ExpenseEntryAccountEmployeeId, IncludeDateRange, ExpenseEntryStartDate, ExpenseEntryEndDate, AccountEmployeeId, ApprovalPathSequence)
        End If
    End Sub
    ''' <summary>
    ''' Bulk expense entry approval entries for rejected of specified AccountEmployeeExpenseSheetId, chk, Comments, ApprovalType,
    ''' ExpenseEntryAccountEmployeeId, IncludeDateRange, ExpenseEntryStartDate, ExpenseEntryEndDate, AccountEmployeeId
    ''' </summary>
    ''' <param name="AccountEmployeeExpenseSheetId"></param>
    ''' <param name="chk"></param>
    ''' <param name="Comments"></param>
    ''' <param name="ApprovalType"></param>
    ''' <param name="ExpenseEntryAccountEmployeeId"></param>
    ''' <param name="IncludeDateRange"></param>
    ''' <param name="ExpenseEntryStartDate"></param>
    ''' <param name="ExpenseEntryEndDate"></param>
    ''' <param name="AccountEmployeeId"></param>
    ''' <remarks></remarks>
    Public Sub BulkExpenseEntryApprovalEntriesForRejected(ByVal AccountEmployeeExpenseSheetId As Guid, ByVal chk As CheckBox, ByVal Comments As String,
    ByVal ApprovalType As String, ByVal ExpenseEntryAccountEmployeeId As Integer, ByVal IncludeDateRange As Boolean,
    ByVal ExpenseEntryStartDate As Date, ByVal ExpenseEntryEndDate As Date, ByVal AccountEmployeeId As System.Nullable(Of Integer), ByVal ApprovalPathSequence As Integer)

        If ApprovalType = "TeamLead" Then
            RejectTeamLeadEntries(AccountEmployeeExpenseSheetId, chk, Comments, ExpenseEntryAccountEmployeeId, IncludeDateRange, ExpenseEntryStartDate, ExpenseEntryEndDate, AccountEmployeeId, ApprovalPathSequence)
        End If
        If ApprovalType = "ProjectManager" Then
            RejectProjectManagerEntries(AccountEmployeeExpenseSheetId, chk, Comments, ExpenseEntryAccountEmployeeId, IncludeDateRange, ExpenseEntryStartDate, ExpenseEntryEndDate, AccountEmployeeId, ApprovalPathSequence)
        End If
        If ApprovalType = "SpecificEmployee" Then
            RejectSpecificEmployeeEntries(AccountEmployeeExpenseSheetId, chk, Comments, ExpenseEntryAccountEmployeeId, IncludeDateRange, ExpenseEntryStartDate, ExpenseEntryEndDate, AccountEmployeeId, ApprovalPathSequence)
        End If
        If ApprovalType = "SpecificExternalUser" Then
            RejectSpecificExternalUserEntries(AccountEmployeeExpenseSheetId, chk, Comments, ExpenseEntryAccountEmployeeId, IncludeDateRange, ExpenseEntryStartDate, ExpenseEntryEndDate, AccountEmployeeId, ApprovalPathSequence)
        End If
        If ApprovalType = "EmployeeManager" Then
            RejectEmployeeManagerEntries(AccountEmployeeExpenseSheetId, chk, Comments, ExpenseEntryAccountEmployeeId, IncludeDateRange, ExpenseEntryStartDate, ExpenseEntryEndDate, AccountEmployeeId, ApprovalPathSequence)
        End If
    End Sub
    ''' <summary>
    ''' Approved team lead entries of specified AccountEmployeeExpenseSheetId, Chk, Comments, ExpenseEntryAccountEmployeeId,
    ''' IncludeDateRange, ExpenseEntryStartDate, ExpenseEntryEndDate, AccountEmployeeId
    ''' </summary>
    ''' <param name="AccountEmployeeExpenseSheetId"></param>
    ''' <param name="Chk"></param>
    ''' <param name="Comments"></param>
    ''' <param name="ExpenseEntryAccountEmployeeId"></param>
    ''' <param name="IncludeDateRange"></param>
    ''' <param name="ExpenseEntryStartDate"></param>
    ''' <param name="ExpenseEntryEndDate"></param>
    ''' <param name="AccountEmployeeId"></param>
    ''' <remarks></remarks>
    Public Sub ApprovedTeamLeadEntries(ByVal AccountEmployeeExpenseSheetId As Guid, ByVal Chk As CheckBox, ByVal Comments As String,
    ByVal ExpenseEntryAccountEmployeeId As Integer, ByVal IncludeDateRange As Boolean,
    ByVal ExpenseEntryStartDate As Date, ByVal ExpenseEntryEndDate As Date, ByVal AccountEmployeeId As System.Nullable(Of Integer), ByVal ApprovalPathSequence As Integer)
        Dim TCount As Integer = 1
        Dim ExpenseSheetBLL As New AccountEmployeeExpenseSheetBLL
        Dim TLExpenseEntryId As New ArrayList
        Dim dtTeamLead As TimeLiveDataSet.vueAccountExpenseEntryApprovalPendingDataTable = Me.GetApprovalEntriesForTeamLead(0, AccountEmployeeId, ExpenseEntryAccountEmployeeId, ExpenseEntryStartDate, ExpenseEntryEndDate, IncludeDateRange, AccountEmployeeExpenseSheetId)
        Dim drTeamLead As TimeLiveDataSet.vueAccountExpenseEntryApprovalPendingRow
        If dtTeamLead.Rows.Count > 0 Then
            For Each drTeamLead In dtTeamLead.Rows
                If Chk.Checked = True And IsDBNull(drTeamLead.Item("IsApproved")) Then
                    Me.AddExpenseApproval(drTeamLead.AccountExpenseEntryId, drTeamLead.AccountApprovalTypeId, drTeamLead.AccountApprovalPathId, drTeamLead.LeaderEmployeeId, Comments, False, True, ApprovalPathSequence)
                    Me.UpdateInApprovalInExpenseSheet(AccountEmployeeExpenseSheetId, "Approved")
                    If drTeamLead.ApprovalPathSequence = drTeamLead.MaxApprovalPathSequence Then
                        Me.LockTeamLeadExpenseEntry(drTeamLead.AccountExpenseEntryId, True)
                        Me.UpdateMasterApprovedByDetail(AccountEmployeeExpenseSheetId)
                        ExpenseSheetBLL.UpdateApprovedByEmployeeId(drTeamLead.LeaderEmployeeId, AccountEmployeeExpenseSheetId)
                    End If
                    UpdateIsEmailSendByAccountExpenseEntryId(drTeamLead.AccountExpenseEntryId, False)
                        TLExpenseEntryId.Add(drTeamLead.AccountExpenseEntryId)
                        If TCount = dtTeamLead.Rows.Count Then
                            Me.SendExpenseApprovedEMail(AccountEmployeeExpenseSheetId, Comments, TLExpenseEntryId)
                        End If
                    ElseIf Chk.Checked = False And IsDBNull(drTeamLead.Item("IsApproved")) Then
                    ElseIf Chk.Checked = True And drTeamLead.Item("IsApproved") = False Then
                        Me.AddExpenseApproval(drTeamLead.AccountExpenseEntryId, drTeamLead.AccountApprovalTypeId, drTeamLead.AccountApprovalPathId, drTeamLead.LeaderEmployeeId, Comments, False, True, ApprovalPathSequence)
                        Me.UpdateInApprovalInExpenseSheet(AccountEmployeeExpenseSheetId, "Approved")
                        If drTeamLead.ApprovalPathSequence = drTeamLead.MaxApprovalPathSequence Then
                            Me.LockTeamLeadExpenseEntry(drTeamLead.AccountExpenseEntryId, True)
                            Me.UpdateMasterApprovedByDetail(AccountEmployeeExpenseSheetId)
                            ExpenseSheetBLL.UpdateApprovedByEmployeeId(drTeamLead.LeaderEmployeeId, AccountEmployeeExpenseSheetId)
                        End If
                        UpdateIsEmailSendByAccountExpenseEntryId(drTeamLead.AccountExpenseEntryId, False)
                        TLExpenseEntryId.Add(drTeamLead.AccountExpenseEntryId)
                        If TCount = dtTeamLead.Rows.Count Then
                            Me.SendExpenseApprovedEMail(AccountEmployeeExpenseSheetId, Comments, TLExpenseEntryId)
                        End If
                    ElseIf Chk.Checked = False And drTeamLead.Item("IsApproved") = True Then
                        Me.AddExpenseApproval(drTeamLead.AccountExpenseEntryId, drTeamLead.AccountApprovalTypeId, drTeamLead.AccountApprovalPathId, drTeamLead.LeaderEmployeeId, Comments, False, True, ApprovalPathSequence)
                    Me.UpdateInApprovalInExpenseSheet(AccountEmployeeExpenseSheetId, "Approved")
                    If drTeamLead.ApprovalPathSequence = drTeamLead.MaxApprovalPathSequence Then
                        Me.LockTeamLeadExpenseEntry(drTeamLead.AccountExpenseEntryId, True)
                        Me.UpdateMasterApprovedByDetail(AccountEmployeeExpenseSheetId)
                        ExpenseSheetBLL.UpdateApprovedByEmployeeId(drTeamLead.LeaderEmployeeId, AccountEmployeeExpenseSheetId)
                    End If
                    UpdateIsEmailSendByAccountExpenseEntryId(drTeamLead.AccountExpenseEntryId, False)
                    TLExpenseEntryId.Add(drTeamLead.AccountExpenseEntryId)
                    If TCount = dtTeamLead.Rows.Count Then
                        Me.SendExpenseApprovedEMail(AccountEmployeeExpenseSheetId, Comments, TLExpenseEntryId)
                    End If

                End If
                TCount += 1
            Next
        End If
    End Sub
    ''' <summary>
    ''' Approved project manager entries of specified AccountEmployeeExpenseSheetId, Chk, Comments, ExpenseEntryAccountEmployeeId,
    ''' IncludeDateRange, ExpenseEntryStartDate, ExpenseEntryEndDate, AccountEmployeeId
    ''' </summary>
    ''' <param name="AccountEmployeeExpenseSheetId"></param>
    ''' <param name="Chk"></param>
    ''' <param name="Comments"></param>
    ''' <param name="ExpenseEntryAccountEmployeeId"></param>
    ''' <param name="IncludeDateRange"></param>
    ''' <param name="ExpenseEntryStartDate"></param>
    ''' <param name="ExpenseEntryEndDate"></param>
    ''' <param name="AccountEmployeeId"></param>
    ''' <remarks></remarks>
    Public Sub ApprovedProjectManagerEntries(ByVal AccountEmployeeExpenseSheetId As Guid, ByVal Chk As CheckBox, ByVal Comments As String,
       ByVal ExpenseEntryAccountEmployeeId As Integer, ByVal IncludeDateRange As Boolean,
       ByVal ExpenseEntryStartDate As Date, ByVal ExpenseEntryEndDate As Date, ByVal AccountEmployeeId As System.Nullable(Of Integer), ByVal ApprovalPathSequence As Integer)
        Dim ExpenseSheetBLL As New AccountEmployeeExpenseSheetBLL
        Dim TCount As Integer = 1
        Dim PMExpenseEntryid As New ArrayList
        Dim dtPM As TimeLiveDataSet.vueAccountExpenseEntryApprovalPendingDataTable = Me.GetApprovalEntriesForProjectManager(0, AccountEmployeeId, ExpenseEntryAccountEmployeeId, ExpenseEntryStartDate, ExpenseEntryEndDate, IncludeDateRange, AccountEmployeeExpenseSheetId)
        Dim drPM As TimeLiveDataSet.vueAccountExpenseEntryApprovalPendingRow
        If dtPM.Rows.Count > 0 Then
            For Each drPM In dtPM.Rows
                If Chk.Checked = True And IsDBNull(drPM.Item("IsApproved")) Then
                    Me.AddExpenseApproval(drPM.AccountExpenseEntryId, drPM.AccountApprovalTypeId, drPM.AccountApprovalPathId, drPM.ProjectManagerEmployeeId, Comments, False, True, ApprovalPathSequence)
                    Me.UpdateInApprovalInExpenseSheet(AccountEmployeeExpenseSheetId, "Approved")
                    If drPM.ApprovalPathSequence = drPM.MaxApprovalPathSequence Then
                        Me.LockProjectManagerExpenseEntry(drPM.AccountExpenseEntryId, True)
                        Me.UpdateMasterApprovedByDetail(AccountEmployeeExpenseSheetId)
                        ExpenseSheetBLL.UpdateApprovedByEmployeeId(drPM.ProjectManagerEmployeeId, AccountEmployeeExpenseSheetId)
                    End If
                    UpdateIsEmailSendByAccountExpenseEntryId(drPM.AccountExpenseEntryId, False)
                        PMExpenseEntryid.Add(drPM.AccountExpenseEntryId)
                        If TCount = dtPM.Rows.Count Then
                            Me.SendExpenseApprovedEMail(AccountEmployeeExpenseSheetId, Comments, PMExpenseEntryid)
                        End If
                    ElseIf Chk.Checked = False And IsDBNull(drPM.Item("IsApproved")) Then
                    ElseIf Chk.Checked = True And drPM.Item("IsApproved") = False Then
                        Me.AddExpenseApproval(drPM.AccountExpenseEntryId, drPM.AccountApprovalTypeId, drPM.AccountApprovalPathId, drPM.ProjectManagerEmployeeId, Comments, False, True, ApprovalPathSequence)
                        Me.UpdateInApprovalInExpenseSheet(AccountEmployeeExpenseSheetId, "Approved")
                        If drPM.ApprovalPathSequence = drPM.MaxApprovalPathSequence Then
                            Me.LockProjectManagerExpenseEntry(drPM.AccountExpenseEntryId, True)
                            Me.UpdateMasterApprovedByDetail(AccountEmployeeExpenseSheetId)
                            ExpenseSheetBLL.UpdateApprovedByEmployeeId(drPM.ProjectManagerEmployeeId, AccountEmployeeExpenseSheetId)
                        End If
                        UpdateIsEmailSendByAccountExpenseEntryId(drPM.AccountExpenseEntryId, False)
                        PMExpenseEntryid.Add(drPM.AccountExpenseEntryId)
                        If TCount = dtPM.Rows.Count Then
                            Me.SendExpenseApprovedEMail(AccountEmployeeExpenseSheetId, Comments, PMExpenseEntryid)
                        End If
                    ElseIf Chk.Checked = False And drPM.Item("IsApproved") = True Then
                        Me.AddExpenseApproval(drPM.AccountExpenseEntryId, drPM.AccountApprovalTypeId, drPM.AccountApprovalPathId, drPM.ProjectManagerEmployeeId, Comments, False, True, ApprovalPathSequence)
                    Me.UpdateInApprovalInExpenseSheet(AccountEmployeeExpenseSheetId, "Approved")
                    If drPM.ApprovalPathSequence = drPM.MaxApprovalPathSequence Then
                        Me.LockProjectManagerExpenseEntry(drPM.AccountExpenseEntryId, True)
                        Me.UpdateMasterApprovedByDetail(AccountEmployeeExpenseSheetId)
                        ExpenseSheetBLL.UpdateApprovedByEmployeeId(drPM.ProjectManagerEmployeeId, AccountEmployeeExpenseSheetId)
                    End If
                    UpdateIsEmailSendByAccountExpenseEntryId(drPM.AccountExpenseEntryId, False)
                    PMExpenseEntryid.Add(drPM.AccountExpenseEntryId)
                    If TCount = dtPM.Rows.Count Then
                        Me.SendExpenseApprovedEMail(AccountEmployeeExpenseSheetId, Comments, PMExpenseEntryid)
                    End If
                End If
                TCount += 1
            Next
        End If
    End Sub
    ''' <summary>
    ''' Approved specific employee entries of specified AccountEmployeeExpenseSheetId, Chk, Comments, ExpenseEntryAccountEmployeeId,
    ''' IncludeDateRange, ExpenseEntryStartDate, ExpenseEntryEndDate, AccountEmployeeId
    ''' </summary>
    ''' <param name="AccountEmployeeExpenseSheetId"></param>
    ''' <param name="Chk"></param>
    ''' <param name="Comments"></param>
    ''' <param name="ExpenseEntryAccountEmployeeId"></param>
    ''' <param name="IncludeDateRange"></param>
    ''' <param name="ExpenseEntryStartDate"></param>
    ''' <param name="ExpenseEntryEndDate"></param>
    ''' <param name="AccountEmployeeId"></param>
    ''' <remarks></remarks>
    Public Sub ApprovedSpecificEmployeeEntries(ByVal AccountEmployeeExpenseSheetId As Guid, ByVal Chk As CheckBox, ByVal Comments As String,
       ByVal ExpenseEntryAccountEmployeeId As Integer, ByVal IncludeDateRange As Boolean,
       ByVal ExpenseEntryStartDate As Date, ByVal ExpenseEntryEndDate As Date, ByVal AccountEmployeeId As System.Nullable(Of Integer), ByVal ApprovalPathSequence As Integer)
        Dim TCount As Integer = 1
        Dim SEExpenseEntryId As New ArrayList
        Dim ExpenseSheetBLL As New AccountEmployeeExpenseSheetBLL
        Dim dtSE As TimeLiveDataSet.vueAccountExpenseEntryApprovalPendingDataTable = Me.GetApprovalEntriesForSpecificEmployee(0, AccountEmployeeId, ExpenseEntryAccountEmployeeId, ExpenseEntryStartDate, ExpenseEntryEndDate, IncludeDateRange, AccountEmployeeExpenseSheetId)
        Dim drSE As TimeLiveDataSet.vueAccountExpenseEntryApprovalPendingRow
        If dtSE.Rows.Count > 0 Then
            For Each drSE In dtSE.Rows
                If Chk.Checked = True And IsDBNull(drSE.Item("IsApproved")) Then
                    Me.AddExpenseApproval(drSE.AccountExpenseEntryId, drSE.AccountApprovalTypeId, drSE.AccountApprovalPathId, drSE.AccountEmployeeId, Comments, False, True, ApprovalPathSequence)
                    Me.UpdateInApprovalInExpenseSheet(AccountEmployeeExpenseSheetId, "Approved")
                    If drSE.ApprovalPathSequence = drSE.MaxApprovalPathSequence Then
                        Me.LockSpecificEmployeeExpenseEntry(drSE.AccountExpenseEntryId, True)
                        Me.UpdateMasterApprovedByDetail(AccountEmployeeExpenseSheetId)
                        ExpenseSheetBLL.UpdateApprovedByEmployeeId(drSE.AccountEmployeeId, AccountEmployeeExpenseSheetId)
                    End If
                    UpdateIsEmailSendByAccountExpenseEntryId(drSE.AccountExpenseEntryId, False)
                        SEExpenseEntryId.Add(drSE.AccountExpenseEntryId)
                        If TCount = dtSE.Rows.Count Then
                            Me.SendExpenseApprovedEMail(AccountEmployeeExpenseSheetId, Comments, SEExpenseEntryId)
                        End If
                    ElseIf Chk.Checked = False And IsDBNull(drSE.Item("IsApproved")) Then
                    ElseIf Chk.Checked = True And drSE.Item("IsApproved") = False Then
                        Me.AddExpenseApproval(drSE.AccountExpenseEntryId, drSE.AccountApprovalTypeId, drSE.AccountApprovalPathId, drSE.AccountEmployeeId, Comments, False, True, ApprovalPathSequence)
                        Me.UpdateInApprovalInExpenseSheet(AccountEmployeeExpenseSheetId, "Approved")
                        If drSE.ApprovalPathSequence = drSE.MaxApprovalPathSequence Then
                            Me.LockSpecificEmployeeExpenseEntry(drSE.AccountExpenseEntryId, True)
                            Me.UpdateMasterApprovedByDetail(AccountEmployeeExpenseSheetId)
                            ExpenseSheetBLL.UpdateApprovedByEmployeeId(drSE.AccountEmployeeId, AccountEmployeeExpenseSheetId)
                        End If
                        UpdateIsEmailSendByAccountExpenseEntryId(drSE.AccountExpenseEntryId, False)
                        SEExpenseEntryId.Add(drSE.AccountExpenseEntryId)
                        If TCount = dtSE.Rows.Count Then
                            Me.SendExpenseApprovedEMail(AccountEmployeeExpenseSheetId, Comments, SEExpenseEntryId)
                        End If
                    ElseIf Chk.Checked = False And drSE.Item("IsApproved") = True Then
                        Me.AddExpenseApproval(drSE.AccountExpenseEntryId, drSE.AccountApprovalTypeId, drSE.AccountApprovalPathId, drSE.AccountEmployeeId, Comments, False, True, ApprovalPathSequence)
                    Me.UpdateInApprovalInExpenseSheet(AccountEmployeeExpenseSheetId, "Approved")
                    If drSE.ApprovalPathSequence = drSE.MaxApprovalPathSequence Then
                        Me.LockSpecificEmployeeExpenseEntry(drSE.AccountExpenseEntryId, True)
                        Me.UpdateMasterApprovedByDetail(AccountEmployeeExpenseSheetId)
                        ExpenseSheetBLL.UpdateApprovedByEmployeeId(drSE.AccountEmployeeId, AccountEmployeeExpenseSheetId)
                    End If
                    UpdateIsEmailSendByAccountExpenseEntryId(drSE.AccountExpenseEntryId, False)
                    SEExpenseEntryId.Add(drSE.AccountExpenseEntryId)
                    If TCount = dtSE.Rows.Count Then
                        Me.SendExpenseApprovedEMail(AccountEmployeeExpenseSheetId, Comments, SEExpenseEntryId)
                    End If
                End If
                TCount += 1
            Next
        End If
    End Sub
    ''' <summary>
    ''' Approved specific external user entries of specified AccountEmployeeExpenseSheetId, Chk, Comments, ExpenseEntryAccountEmployeeId,
    ''' IncludeDateRange, ExpenseEntryStartDate, ExpenseEntryEndDate, AccountEmployeeId
    ''' </summary>
    ''' <param name="AccountEmployeeExpenseSheetId"></param>
    ''' <param name="Chk"></param>
    ''' <param name="Comments"></param>
    ''' <param name="ExpenseEntryAccountEmployeeId"></param>
    ''' <param name="IncludeDateRange"></param>
    ''' <param name="ExpenseEntryStartDate"></param>
    ''' <param name="ExpenseEntryEndDate"></param>
    ''' <param name="AccountEmployeeId"></param>
    ''' <remarks></remarks>
    Public Sub ApprovedSpecificExternalUserEntries(ByVal AccountEmployeeExpenseSheetId As Guid, ByVal Chk As CheckBox, ByVal Comments As String,
   ByVal ExpenseEntryAccountEmployeeId As Integer, ByVal IncludeDateRange As Boolean,
   ByVal ExpenseEntryStartDate As Date, ByVal ExpenseEntryEndDate As Date, ByVal AccountEmployeeId As System.Nullable(Of Integer), ByVal ApprovalPathSequence As Integer)
        Dim TCount As Integer = 1
        Dim SEUExpenseEntryId As New ArrayList
        Dim ExpenseSheetBLL As New AccountEmployeeExpenseSheetBLL
        Dim dtSEU As TimeLiveDataSet.vueAccountExpenseEntryApprovalPendingDataTable = Me.GetApprovalEntriesForSpecificExternalUser(0, AccountEmployeeId, ExpenseEntryAccountEmployeeId, ExpenseEntryStartDate, ExpenseEntryEndDate, IncludeDateRange, AccountEmployeeExpenseSheetId)
        Dim drSEU As TimeLiveDataSet.vueAccountExpenseEntryApprovalPendingRow
        If dtSEU.Rows.Count > 0 Then
            For Each drSEU In dtSEU.Rows
                If Chk.Checked = True And IsDBNull(drSEU.Item("IsApproved")) Then
                    Me.AddExpenseApproval(drSEU.AccountExpenseEntryId, drSEU.AccountApprovalTypeId, drSEU.AccountApprovalPathId, drSEU.AccountExternalUserId, Comments, False, True, ApprovalPathSequence)
                    Me.UpdateInApprovalInExpenseSheet(AccountEmployeeExpenseSheetId, "Approved")
                    If drSEU.ApprovalPathSequence = drSEU.MaxApprovalPathSequence Then
                        Me.LockSpecificExternalUserExpenseEntry(drSEU.AccountExpenseEntryId, True)
                        Me.UpdateMasterApprovedByDetail(AccountEmployeeExpenseSheetId)
                        ExpenseSheetBLL.UpdateApprovedByEmployeeId(drSEU.AccountExternalUserId, AccountEmployeeExpenseSheetId)
                    End If
                    UpdateIsEmailSendByAccountExpenseEntryId(drSEU.AccountExpenseEntryId, False)
                        SEUExpenseEntryId.Add(drSEU.AccountExpenseEntryId)
                        If TCount = dtSEU.Rows.Count Then
                            Me.SendExpenseApprovedEMail(AccountEmployeeExpenseSheetId, Comments, SEUExpenseEntryId)
                        End If
                    ElseIf Chk.Checked = False And IsDBNull(drSEU.Item("IsApproved")) Then
                    ElseIf Chk.Checked = True And drSEU.Item("IsApproved") = False Then
                        Me.AddExpenseApproval(drSEU.AccountExpenseEntryId, drSEU.AccountApprovalTypeId, drSEU.AccountApprovalPathId, drSEU.AccountExternalUserId, Comments, False, True, ApprovalPathSequence)
                        Me.UpdateInApprovalInExpenseSheet(AccountEmployeeExpenseSheetId, "Approved")
                        If drSEU.ApprovalPathSequence = drSEU.MaxApprovalPathSequence Then
                            Me.LockSpecificExternalUserExpenseEntry(drSEU.AccountExpenseEntryId, True)
                            Me.UpdateMasterApprovedByDetail(AccountEmployeeExpenseSheetId)
                            ExpenseSheetBLL.UpdateApprovedByEmployeeId(drSEU.AccountExternalUserId, AccountEmployeeExpenseSheetId)
                        End If
                        UpdateIsEmailSendByAccountExpenseEntryId(drSEU.AccountExpenseEntryId, False)
                        SEUExpenseEntryId.Add(drSEU.AccountExpenseEntryId)
                        If TCount = dtSEU.Rows.Count Then
                            Me.SendExpenseApprovedEMail(AccountEmployeeExpenseSheetId, Comments, SEUExpenseEntryId)
                        End If
                    ElseIf Chk.Checked = False And drSEU.Item("IsApproved") = True Then
                        Me.AddExpenseApproval(drSEU.AccountExpenseEntryId, drSEU.AccountApprovalTypeId, drSEU.AccountApprovalPathId, drSEU.AccountExternalUserId, Comments, False, True, ApprovalPathSequence)
                    Me.UpdateInApprovalInExpenseSheet(AccountEmployeeExpenseSheetId, "Approved")
                    If drSEU.ApprovalPathSequence = drSEU.MaxApprovalPathSequence Then
                        Me.LockSpecificExternalUserExpenseEntry(drSEU.AccountExpenseEntryId, True)
                        Me.UpdateMasterApprovedByDetail(AccountEmployeeExpenseSheetId)
                        ExpenseSheetBLL.UpdateApprovedByEmployeeId(drSEU.AccountExternalUserId, AccountEmployeeExpenseSheetId)
                    End If
                    UpdateIsEmailSendByAccountExpenseEntryId(drSEU.AccountExpenseEntryId, False)
                    SEUExpenseEntryId.Add(drSEU.AccountExpenseEntryId)
                    If TCount = dtSEU.Rows.Count Then
                        Me.SendExpenseApprovedEMail(AccountEmployeeExpenseSheetId, Comments, SEUExpenseEntryId)
                    End If
                End If
                TCount += 1
            Next
        End If
    End Sub
    ''' <summary>
    ''' Approved employee manager entries of specified AccountEmployeeExpenseSheetId, Chk, Comments, ExpenseEntryAccountEmployeeId, IncludeDateRange,
    ''' ExpenseEntryStartDate, ExpenseEntryEndDate, AccountEmployeeId
    ''' </summary>
    ''' <param name="AccountEmployeeExpenseSheetId"></param>
    ''' <param name="Chk"></param>
    ''' <param name="Comments"></param>
    ''' <param name="ExpenseEntryAccountEmployeeId"></param>
    ''' <param name="IncludeDateRange"></param>
    ''' <param name="ExpenseEntryStartDate"></param>
    ''' <param name="ExpenseEntryEndDate"></param>
    ''' <param name="AccountEmployeeId"></param>
    ''' <remarks></remarks>
    Public Sub ApprovedEmployeeManagerEntries(ByVal AccountEmployeeExpenseSheetId As Guid, ByVal Chk As CheckBox, ByVal Comments As String,
    ByVal ExpenseEntryAccountEmployeeId As Integer, ByVal IncludeDateRange As Boolean,
    ByVal ExpenseEntryStartDate As Date, ByVal ExpenseEntryEndDate As Date, ByVal AccountEmployeeId As System.Nullable(Of Integer), ByVal ApprovalPathSequence As Integer)
        Dim TCount As Integer = 1
        Dim EMExpenseEntryId As New ArrayList
        Dim ExpenseSheetBLL As New AccountEmployeeExpenseSheetBLL
        Dim dtEM As TimeLiveDataSet.vueAccountExpenseEntryApprovalPendingDataTable = Me.GetApprovalEntriesForEmployeeManager(0, AccountEmployeeId, ExpenseEntryAccountEmployeeId, ExpenseEntryStartDate, ExpenseEntryEndDate, IncludeDateRange, AccountEmployeeExpenseSheetId)
        Dim drEM As TimeLiveDataSet.vueAccountExpenseEntryApprovalPendingRow
        If dtEM.Rows.Count > 0 Then
            For Each drEM In dtEM.Rows
                If Chk.Checked = True And IsDBNull(drEM.Item("IsApproved")) Then
                    Me.AddExpenseApproval(drEM.AccountExpenseEntryId, drEM.AccountApprovalTypeId, drEM.AccountApprovalPathId, drEM.EmployeeManagerId, Comments, False, True, ApprovalPathSequence)
                    If drEM.ApprovalPathSequence = drEM.MaxApprovalPathSequence Then
                        Me.UpdateInApprovalInExpenseSheet(AccountEmployeeExpenseSheetId, "Approved")
                        Me.UpdateMasterApprovedByDetail(AccountEmployeeExpenseSheetId)
                        ExpenseSheetBLL.UpdateApprovedByEmployeeId(drEM.EmployeeManagerId, AccountEmployeeExpenseSheetId)
                    End If
                    UpdateIsEmailSendByAccountExpenseEntryId(drEM.AccountExpenseEntryId, False)
                        EMExpenseEntryId.Add(drEM.AccountExpenseEntryId)
                        If TCount = dtEM.Rows.Count Then
                            Me.SendExpenseApprovedEMail(AccountEmployeeExpenseSheetId, Comments, EMExpenseEntryId)
                        End If
                    ElseIf Chk.Checked = False And IsDBNull(drEM.Item("IsApproved")) Then
                    ElseIf Chk.Checked = True And drEM.Item("IsApproved") = False Then
                        Me.AddExpenseApproval(drEM.AccountExpenseEntryId, drEM.AccountApprovalTypeId, drEM.AccountApprovalPathId, drEM.EmployeeManagerId, Comments, False, True, ApprovalPathSequence)
                        Me.UpdateInApprovalInExpenseSheet(AccountEmployeeExpenseSheetId, "Approved")
                        If drEM.ApprovalPathSequence = drEM.MaxApprovalPathSequence Then
                            Me.LockEmployeeManagerExpenseEntry(drEM.AccountExpenseEntryId, True)
                            Me.UpdateMasterApprovedByDetail(AccountEmployeeExpenseSheetId)
                            ExpenseSheetBLL.UpdateApprovedByEmployeeId(drEM.EmployeeManagerId, AccountEmployeeExpenseSheetId)
                        End If
                        UpdateIsEmailSendByAccountExpenseEntryId(drEM.AccountExpenseEntryId, False)
                        EMExpenseEntryId.Add(drEM.AccountExpenseEntryId)
                        If TCount = dtEM.Rows.Count Then
                            Me.SendExpenseApprovedEMail(AccountEmployeeExpenseSheetId, Comments, EMExpenseEntryId)
                        End If
                    ElseIf Chk.Checked = False And drEM.Item("IsApproved") = True Then
                        Me.AddExpenseApproval(drEM.AccountExpenseEntryId, drEM.AccountApprovalTypeId, drEM.AccountApprovalPathId, drEM.EmployeeManagerId, Comments, False, True, ApprovalPathSequence)
                    Me.UpdateInApprovalInExpenseSheet(AccountEmployeeExpenseSheetId, "Approved")
                    If drEM.ApprovalPathSequence = drEM.MaxApprovalPathSequence Then

                        Me.LockEmployeeManagerExpenseEntry(drEM.AccountExpenseEntryId, True)
                        Me.UpdateMasterApprovedByDetail(AccountEmployeeExpenseSheetId)
                        ExpenseSheetBLL.UpdateApprovedByEmployeeId(drEM.EmployeeManagerId, AccountEmployeeExpenseSheetId)
                    End If
                    UpdateIsEmailSendByAccountExpenseEntryId(drEM.AccountExpenseEntryId, False)
                    EMExpenseEntryId.Add(drEM.AccountExpenseEntryId)
                    If TCount = dtEM.Rows.Count Then
                        Me.SendExpenseApprovedEMail(AccountEmployeeExpenseSheetId, Comments, EMExpenseEntryId)
                    End If
                End If
                TCount += 1
            Next
        End If
    End Sub
    ''' <summary>
    ''' Reject team lead entries of specified AccountEmployeeExpenseSheetId, Chk, Comments, ExpenseEntryAccountEmployeeId, IncludeDateRange,
    ''' ExpenseEntryStartDate, ExpenseEntryEndDate, AccountEmployeeId
    ''' </summary>
    ''' <param name="AccountEmployeeExpenseSheetId"></param>
    ''' <param name="Chk"></param>
    ''' <param name="Comments"></param>
    ''' <param name="ExpenseEntryAccountEmployeeId"></param>
    ''' <param name="IncludeDateRange"></param>
    ''' <param name="ExpenseEntryStartDate"></param>
    ''' <param name="ExpenseEntryEndDate"></param>
    ''' <param name="AccountEmployeeId"></param>
    ''' <remarks></remarks>
    Public Sub RejectTeamLeadEntries(ByVal AccountEmployeeExpenseSheetId As Guid, ByVal Chk As CheckBox, ByVal Comments As String,
   ByVal ExpenseEntryAccountEmployeeId As Integer, ByVal IncludeDateRange As Boolean,
   ByVal ExpenseEntryStartDate As Date, ByVal ExpenseEntryEndDate As Date, ByVal AccountEmployeeId As System.Nullable(Of Integer), ByVal ApprovalPathSequence As Integer)
        Dim TCount As Integer = 1
        Dim ExpenseSheetBll As New AccountEmployeeExpenseSheetBLL
        Dim dtTeamLead As TimeLiveDataSet.vueAccountExpenseEntryApprovalPendingDataTable = Me.GetApprovalEntriesForTeamLead(0, AccountEmployeeId, ExpenseEntryAccountEmployeeId, ExpenseEntryStartDate, ExpenseEntryEndDate, IncludeDateRange, AccountEmployeeExpenseSheetId)
        Dim drTeamLead As TimeLiveDataSet.vueAccountExpenseEntryApprovalPendingRow
        If dtTeamLead.Rows.Count > 0 Then
            drTeamLead = dtTeamLead.Rows(0)
            For Each drTeamLead In dtTeamLead.Rows
                If Chk.Checked = True Then
                    Me.AddExpenseApproval(drTeamLead.AccountExpenseEntryId, drTeamLead.AccountApprovalTypeId, drTeamLead.AccountApprovalPathId, drTeamLead.LeaderEmployeeId, Comments, True, False, ApprovalPathSequence)
                    Me.UpdateInApprovalInExpenseSheet(AccountEmployeeExpenseSheetId, "Rejected")
                    Me.LockTeamLeadExpenseEntryRejected(drTeamLead.AccountExpenseEntryId, True)
                    ExpenseSheetBll.UpdateMasterRejected(True, AccountEmployeeExpenseSheetId)
                    ExpenseSheetBll.UpdateRejectedByEmployeeId(drTeamLead.LeaderEmployeeId, AccountEmployeeExpenseSheetId)
                    ExpenseSheetBll.UpdateMasterSubmitted(False, AccountEmployeeExpenseSheetId)
                    If TCount = dtTeamLead.Rows.Count Then
                        Me.SendExpenseRejectedEMail(AccountEmployeeExpenseSheetId, Comments)
                    End If
                End If
                TCount += 1
            Next
        End If
    End Sub
    ''' <summary>
    ''' Reject project manager entries of specified AccountEmployeeExpenseSheetId, Chk, Comments, ExpenseEntryAccountEmployeeId,
    ''' IncludeDateRange, ExpenseEntryStartDate, ExpenseEntryEndDate, AccountEmployeeId
    ''' </summary>
    ''' <param name="AccountEmployeeExpenseSheetId"></param>
    ''' <param name="Chk"></param>
    ''' <param name="Comments"></param>
    ''' <param name="ExpenseEntryAccountEmployeeId"></param>
    ''' <param name="IncludeDateRange"></param>
    ''' <param name="ExpenseEntryStartDate"></param>
    ''' <param name="ExpenseEntryEndDate"></param>
    ''' <param name="AccountEmployeeId"></param>
    ''' <remarks></remarks>
    Public Sub RejectProjectManagerEntries(ByVal AccountEmployeeExpenseSheetId As Guid, ByVal Chk As CheckBox, ByVal Comments As String,
    ByVal ExpenseEntryAccountEmployeeId As Integer, ByVal IncludeDateRange As Boolean,
    ByVal ExpenseEntryStartDate As Date, ByVal ExpenseEntryEndDate As Date, ByVal AccountEmployeeId As System.Nullable(Of Integer), ByVal ApprovalPathSequence As Integer)
        Dim TCount As Integer = 1
        Dim ExpenseSheetBll As New AccountEmployeeExpenseSheetBLL
        Dim dtPM As TimeLiveDataSet.vueAccountExpenseEntryApprovalPendingDataTable = Me.GetApprovalEntriesForProjectManager(0, AccountEmployeeId, ExpenseEntryAccountEmployeeId, ExpenseEntryStartDate, ExpenseEntryEndDate, IncludeDateRange, AccountEmployeeExpenseSheetId)
        Dim drPM As TimeLiveDataSet.vueAccountExpenseEntryApprovalPendingRow
        If dtPM.Rows.Count > 0 Then
            For Each drPM In dtPM.Rows
                If Chk.Checked = True Then
                    Me.AddExpenseApproval(drPM.AccountExpenseEntryId, drPM.AccountApprovalTypeId, drPM.AccountApprovalPathId, drPM.ProjectManagerEmployeeId, Comments, True, False, ApprovalPathSequence)
                    Me.UpdateInApprovalInExpenseSheet(AccountEmployeeExpenseSheetId, "Rejected")
                    Me.LockProjectManagerExpenseEntryRejected(drPM.AccountExpenseEntryId, True)
                    ExpenseSheetBll.UpdateMasterRejected(True, AccountEmployeeExpenseSheetId)
                    ExpenseSheetBll.UpdateRejectedByEmployeeId(drPM.ProjectManagerEmployeeId, AccountEmployeeExpenseSheetId)
                    ExpenseSheetBll.UpdateMasterSubmitted(False, AccountEmployeeExpenseSheetId)
                    If TCount = dtPM.Rows.Count Then
                        Me.SendExpenseRejectedEMail(AccountEmployeeExpenseSheetId, Comments)
                    End If
                End If
                TCount += 1
            Next
        End If
    End Sub
    ''' <summary>
    ''' Reject specific employee entries of specified AccountEmployeeExpenseSheetId, Chk, Comments, ExpenseEntryAccountEmployeeId,
    ''' IncludeDateRange, ExpenseEntryStartDate, ExpenseEntryEndDate, AccountEmployeeId
    ''' </summary>
    ''' <param name="AccountEmployeeExpenseSheetId"></param>
    ''' <param name="Chk"></param>
    ''' <param name="Comments"></param>
    ''' <param name="ExpenseEntryAccountEmployeeId"></param>
    ''' <param name="IncludeDateRange"></param>
    ''' <param name="ExpenseEntryStartDate"></param>
    ''' <param name="ExpenseEntryEndDate"></param>
    ''' <param name="AccountEmployeeId"></param>
    ''' <remarks></remarks>
    Public Sub RejectSpecificEmployeeEntries(ByVal AccountEmployeeExpenseSheetId As Guid, ByVal Chk As CheckBox, ByVal Comments As String,
       ByVal ExpenseEntryAccountEmployeeId As Integer, ByVal IncludeDateRange As Boolean,
       ByVal ExpenseEntryStartDate As Date, ByVal ExpenseEntryEndDate As Date, ByVal AccountEmployeeId As System.Nullable(Of Integer), ByVal ApprovalPathSequence As Integer)
        Dim TCount As Integer = 1
        Dim ExpenseSheetBll As New AccountEmployeeExpenseSheetBLL
        Dim dtSE As TimeLiveDataSet.vueAccountExpenseEntryApprovalPendingDataTable = Me.GetApprovalEntriesForSpecificEmployee(0, AccountEmployeeId, ExpenseEntryAccountEmployeeId, ExpenseEntryStartDate, ExpenseEntryEndDate, IncludeDateRange, AccountEmployeeExpenseSheetId)
        Dim drSE As TimeLiveDataSet.vueAccountExpenseEntryApprovalPendingRow
        If dtSE.Rows.Count > 0 Then
            For Each drSE In dtSE.Rows
                If Chk.Checked = True Then
                    Me.AddExpenseApproval(drSE.AccountExpenseEntryId, drSE.AccountApprovalTypeId, drSE.AccountApprovalPathId, drSE.AccountEmployeeId, Comments, True, False, ApprovalPathSequence)
                    Me.UpdateInApprovalInExpenseSheet(AccountEmployeeExpenseSheetId, "Rejected")
                    Me.LockSpecificEmployeeExpenseEntryRejected(drSE.AccountExpenseEntryId, True)
                    ExpenseSheetBll.UpdateMasterRejected(True, AccountEmployeeExpenseSheetId)
                    ExpenseSheetBll.UpdateRejectedByEmployeeId(drSE.AccountEmployeeId, AccountEmployeeExpenseSheetId)
                    ExpenseSheetBll.UpdateMasterSubmitted(False, AccountEmployeeExpenseSheetId)
                    If TCount = dtSE.Rows.Count Then
                        Me.SendExpenseRejectedEMail(AccountEmployeeExpenseSheetId, Comments)
                    End If
                End If
                TCount += 1
            Next
        End If
    End Sub
    ''' <summary>
    ''' Reject specific external user entries of specified AccountEmployeeExpenseSheetId, Chk, Comments, ExpenseEntryAccountEmployeeId,
    ''' IncludeDateRange, ExpenseEntryStartDate, ExpenseEntryEndDate, AccountEmployeeId
    ''' </summary>
    ''' <param name="AccountEmployeeExpenseSheetId"></param>
    ''' <param name="Chk"></param>
    ''' <param name="Comments"></param>
    ''' <param name="ExpenseEntryAccountEmployeeId"></param>
    ''' <param name="IncludeDateRange"></param>
    ''' <param name="ExpenseEntryStartDate"></param>
    ''' <param name="ExpenseEntryEndDate"></param>
    ''' <param name="AccountEmployeeId"></param>
    ''' <remarks></remarks>
    Public Sub RejectSpecificExternalUserEntries(ByVal AccountEmployeeExpenseSheetId As Guid, ByVal Chk As CheckBox, ByVal Comments As String,
   ByVal ExpenseEntryAccountEmployeeId As Integer, ByVal IncludeDateRange As Boolean,
   ByVal ExpenseEntryStartDate As Date, ByVal ExpenseEntryEndDate As Date, ByVal AccountEmployeeId As System.Nullable(Of Integer), ByVal ApprovalPathSequence As Integer)
        Dim TCount As Integer = 1
        Dim ExpenseSheetBll As New AccountEmployeeExpenseSheetBLL
        Dim dtSEU As TimeLiveDataSet.vueAccountExpenseEntryApprovalPendingDataTable = Me.GetApprovalEntriesForSpecificExternalUser(0, AccountEmployeeId, ExpenseEntryAccountEmployeeId, ExpenseEntryStartDate, ExpenseEntryEndDate, IncludeDateRange, AccountEmployeeExpenseSheetId)
        Dim drSEU As TimeLiveDataSet.vueAccountExpenseEntryApprovalPendingRow
        If dtSEU.Rows.Count > 0 Then
            For Each drSEU In dtSEU.Rows
                If Chk.Checked = True Then
                    Me.AddExpenseApproval(drSEU.AccountExpenseEntryId, drSEU.AccountApprovalTypeId, drSEU.AccountApprovalPathId, drSEU.AccountExternalUserId, Comments, True, False, ApprovalPathSequence)
                    Me.UpdateInApprovalInExpenseSheet(AccountEmployeeExpenseSheetId, "Rejected")
                    Me.LockSpecificExternalUserExpenseEntryRejected(drSEU.AccountExpenseEntryId, True)
                    ExpenseSheetBll.UpdateMasterRejected(True, AccountEmployeeExpenseSheetId)
                    ExpenseSheetBll.UpdateRejectedByEmployeeId(drSEU.AccountExternalUserId, AccountEmployeeExpenseSheetId)
                    ExpenseSheetBll.UpdateMasterSubmitted(False, AccountEmployeeExpenseSheetId)
                    If TCount = dtSEU.Rows.Count Then
                        Me.SendExpenseRejectedEMail(AccountEmployeeExpenseSheetId, Comments)
                    End If
                End If
                TCount += 1
            Next
        End If
    End Sub
    ''' <summary>
    ''' Reject employee manager entries of specified AccountEmployeeExpenseSheetId, Chk, Comments, ExpenseEntryAccountEmployeeId,
    ''' IncludeDateRange, ExpenseEntryStartDate, ExpenseEntryEndDate, AccountEmployeeId
    ''' </summary>
    ''' <param name="AccountEmployeeExpenseSheetId"></param>
    ''' <param name="Chk"></param>
    ''' <param name="Comments"></param>
    ''' <param name="ExpenseEntryAccountEmployeeId"></param>
    ''' <param name="IncludeDateRange"></param>
    ''' <param name="ExpenseEntryStartDate"></param>
    ''' <param name="ExpenseEntryEndDate"></param>
    ''' <param name="AccountEmployeeId"></param>
    ''' <remarks></remarks>
    Public Sub RejectEmployeeManagerEntries(ByVal AccountEmployeeExpenseSheetId As Guid, ByVal Chk As CheckBox, ByVal Comments As String,
    ByVal ExpenseEntryAccountEmployeeId As Integer, ByVal IncludeDateRange As Boolean,
    ByVal ExpenseEntryStartDate As Date, ByVal ExpenseEntryEndDate As Date, ByVal AccountEmployeeId As System.Nullable(Of Integer), ByVal ApprovalPathSequence As Integer)
        Dim TCount As Integer = 1
        Dim ExpenseSheetBll As New AccountEmployeeExpenseSheetBLL
        Dim dtEM As TimeLiveDataSet.vueAccountExpenseEntryApprovalPendingDataTable = Me.GetApprovalEntriesForEmployeeManager(0, AccountEmployeeId, ExpenseEntryAccountEmployeeId, ExpenseEntryStartDate, ExpenseEntryEndDate, IncludeDateRange, AccountEmployeeExpenseSheetId)
        Dim drEM As TimeLiveDataSet.vueAccountExpenseEntryApprovalPendingRow
        If dtEM.Rows.Count > 0 Then
            For Each drEM In dtEM.Rows
                If Chk.Checked = True Then
                    Me.AddExpenseApproval(drEM.AccountExpenseEntryId, drEM.AccountApprovalTypeId, drEM.AccountApprovalPathId, drEM.EmployeeManagerId, Comments, True, False, ApprovalPathSequence)
                    Me.UpdateInApprovalInExpenseSheet(AccountEmployeeExpenseSheetId, "Rejected")
                    Me.LockEmployeeManagerExpenseEntryRejected(drEM.AccountExpenseEntryId, True)
                    ExpenseSheetBll.UpdateMasterRejected(True, AccountEmployeeExpenseSheetId)
                    ExpenseSheetBll.UpdateRejectedByEmployeeId(drEM.EmployeeManagerId, AccountEmployeeExpenseSheetId)
                    ExpenseSheetBll.UpdateMasterSubmitted(False, AccountEmployeeExpenseSheetId)
                    If TCount = dtEM.Rows.Count Then
                        Me.SendExpenseRejectedEMail(AccountEmployeeExpenseSheetId, Comments)
                    End If
                End If
                TCount += 1
            Next
        End If
    End Sub
    ''' <summary>
    ''' Update master approved by detail of specified AccountEmployeeExpenseSheetId
    ''' </summary>
    ''' <param name="AccountEmployeeExpenseSheetId"></param>
    ''' <remarks></remarks>
    Public Sub UpdateMasterApprovedByDetail(ByVal AccountEmployeeExpenseSheetId As Guid)
        Dim ExpenseSheetBll As New AccountEmployeeExpenseSheetBLL
        Dim dt As TimeLiveDataSet.AccountExpenseEntryDataTable = Adapter.GetDataByAccountEmployeeExpenseSheetId(AccountEmployeeExpenseSheetId)
        Dim dr As TimeLiveDataSet.AccountExpenseEntryRow
        If dt.Rows.Count > 0 Then
            Dim TotalApproved As Integer = 0
            dr = dt.Rows(0)
            For Each dr In dt.Rows
                If dr.Item("Approved").ToString = "True" Then
                    TotalApproved += 1
                End If
            Next
            If TotalApproved = dt.Rows.Count Then
                ExpenseSheetBll.UpdateApproved(True, AccountEmployeeExpenseSheetId)
            End If
        End If
    End Sub
    ''' <summary>
    ''' Get view expense entries read only of specified AccountEmployeeId, AccountEmployeeExpenseSheetId, ApprovalType
    ''' </summary>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="AccountEmployeeExpenseSheetId"></param>
    ''' <param name="ApprovalType"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)>
    Public Function GetvueAccountExpenseEntriesReadOnly(ByVal AccountEmployeeId As Integer, ByVal AccountEmployeeExpenseSheetId As Guid, ByVal ApprovalType As String) As AccountExpenseEntry.vueAccountExpenseEntryWithLastStatusReadOnlyDataTable
        If ApprovalType = "TeamLead" Then
            GetvueAccountExpenseEntriesReadOnly = Me.GetvueAccountExpenseEntryWithLastStatusReadOnlyForTeamLead(AccountEmployeeId, AccountEmployeeExpenseSheetId, DBUtilities.GetSessionAccountEmployeeId)
            UIUtilities.FixTableForNoRecords(GetvueAccountExpenseEntriesReadOnly)
        ElseIf ApprovalType = "ProjectManager" Then
            GetvueAccountExpenseEntriesReadOnly = Me.GetvueAccountExpenseEntryWithLastStatusReadOnlyForProjectManager(AccountEmployeeId, AccountEmployeeExpenseSheetId, DBUtilities.GetSessionAccountEmployeeId)
            UIUtilities.FixTableForNoRecords(GetvueAccountExpenseEntriesReadOnly)
        ElseIf ApprovalType = "SpecificEmployee" Then
            GetvueAccountExpenseEntriesReadOnly = Me.GetvueAccountExpenseEntryWithLastStatusReadOnlyForSpecificEmployee(AccountEmployeeId, AccountEmployeeExpenseSheetId, DBUtilities.GetSessionAccountEmployeeId)
            UIUtilities.FixTableForNoRecords(GetvueAccountExpenseEntriesReadOnly)
        ElseIf ApprovalType = "SpecificExternalUser" Then
            GetvueAccountExpenseEntriesReadOnly = Me.GetvueAccountExpenseEntryWithLastStatusReadOnlyForSpecificExternalUser(AccountEmployeeId, AccountEmployeeExpenseSheetId, DBUtilities.GetSessionAccountEmployeeId)
            UIUtilities.FixTableForNoRecords(GetvueAccountExpenseEntriesReadOnly)
        ElseIf ApprovalType = "EmployeeManager" Then
            GetvueAccountExpenseEntriesReadOnly = Me.GetvueAccountExpenseEntryWithLastStatusReadOnlyForEmployeeManager(AccountEmployeeId, AccountEmployeeExpenseSheetId, DBUtilities.GetSessionAccountEmployeeId)
            UIUtilities.FixTableForNoRecords(GetvueAccountExpenseEntriesReadOnly)
        End If
    End Function
    ''' <summary>
    ''' Get pending expense entry approvals with preference group by approver employees
    ''' </summary>
    ''' <returns>vueAccountExpenseEntryApprovalPendingEmailWithPreferenceGroupByExpenseSheet data table</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)>
    Public Function GetPendingExpenseEntryApprovalsWithPreferenceGroupByApproverEmployees() As AccountExpenseEntry.vueAccountExpenseEntryApprovalPendingEmailWithPreferenceGroupByExpenseSheetDataTable
        Dim _vueAccountExpenseEntryApprovalPendingEmailWithPreferenceGroupByExpenseSheetTableAdapter As New vueAccountExpenseEntryApprovalPendingEmailWithPreferenceGroupByExpenseSheetTableAdapter
        Return _vueAccountExpenseEntryApprovalPendingEmailWithPreferenceGroupByExpenseSheetTableAdapter.GetDataByApproverEmployeesGrouped
    End Function
    ''' <summary>
    ''' Get pending expense entry approvals with preference group by approver employee id of specified AccountEmployeeId
    ''' </summary>
    ''' <param name="AccountEmployeeId"></param>
    ''' <returns>vueAccountExpenseEntryApprovalPendingEmailWithPreferenceGroupByExpenseSheetAndApproverEmployees data table</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)>
    Public Function GetPendingExpenseEntryApprovalsWithPreferenceGroupByApproverEmployeeId(ByVal AccountEmployeeId As Integer) As AccountExpenseEntry.vueAccountExpenseEntryApprovalPendingEmailWithPreferenceGroupByExpenseSheetAndApproverEmployeesDataTable
        Dim _vueAccountExpenseEntryApprovalPendingEmailWithPreferenceGroupByExpenseSheetAndApproverEmployeesTableAdapter As New vueAccountExpenseEntryApprovalPendingEmailWithPreferenceGroupByExpenseSheetAndApproverEmployeesTableAdapter
        Return _vueAccountExpenseEntryApprovalPendingEmailWithPreferenceGroupByExpenseSheetAndApproverEmployeesTableAdapter.GetDataByApproverEmployeeId(AccountEmployeeId)
    End Function
    ''' <summary>
    ''' Get data for expense entry archive by expense sheet of specified AccountId, AccountEmployees, IncludeDateRange, AccountExpenseEntryStartDate,
    ''' AccountExpenseEntryEndDate
    ''' </summary>
    ''' <param name="AccountId"></param>
    ''' <param name="AccountEmployees"></param>
    ''' <param name="IncludeDateRange"></param>
    ''' <param name="AccountExpenseEntryStartDate"></param>
    ''' <param name="AccountExpenseEntryEndDate"></param>
    ''' <param name="Approval"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)>
    Public Function GetDataForExpenseEntryArchive(ByVal AccountId As Integer, ByVal AccountEmployees As String, ByVal IncludeDateRange As Boolean, ByVal AccountExpenseEntryStartDate As Date, ByVal AccountExpenseEntryEndDate As Date, ByVal Approval As String, ByVal ExpenseTypes As String, ByVal PaymentStatus As Integer, ByVal IsExpenseSheet As Boolean) As AccountExpenseEntry.vueAccountEmployeeExpenseSheetDataTable
        Dim _vueAccountEmployeeExpenseSheetTableAdapter As New vueAccountEmployeeExpenseSheetTableAdapter
        If IsExpenseSheet Then
            Return _vueAccountEmployeeExpenseSheetTableAdapter.GetDataByAccountIdAndEmployeesForExpenseEntryArchiveBySheet(AccountId, AccountEmployees, IncludeDateRange, AccountExpenseEntryStartDate, AccountExpenseEntryEndDate, Approval, ExpenseTypes, PaymentStatus)
        Else
            Return _vueAccountEmployeeExpenseSheetTableAdapter.GetDataByAccountIdAndEmployeesForExpenseEntryArchiveByEntry(AccountId, AccountEmployees, IncludeDateRange, AccountExpenseEntryStartDate, AccountExpenseEntryEndDate, Approval, ExpenseTypes, PaymentStatus)
        End If
    End Function
    ''' <summary>
    ''' Update expense entry archive of specified Original_AccountEmployeeExpenseSheetId, Approved, Submitted, EmployeeName
    ''' </summary>
    ''' <param name="Original_AccountEmployeeExpenseSheetId"></param>
    ''' <param name="Approved"></param>
    ''' <param name="Submitted"></param>
    ''' <param name="EmployeeName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)>
    Public Function UpdateExpenseEntryArchive(ByVal Original_AccountEmployeeExpenseSheetId As Guid,
        ByVal Approved As Boolean, ByVal Submitted As Boolean, ByVal EmployeeName As String) As Boolean

        Call New AccountEmployeeExpenseSheetBLL().UpdateExpenseArchiveMaster(Original_AccountEmployeeExpenseSheetId, Approved, Submitted)

        Dim AccountExpenseEntries As TimeLiveDataSet.AccountExpenseEntryDataTable = Adapter.GetDataByAccountEmployeeExpenseSheetId(Original_AccountEmployeeExpenseSheetId)
        Dim AccountExpenseEntry As TimeLiveDataSet.AccountExpenseEntryRow = AccountExpenseEntries.Rows(0)

        For Each AccountExpenseEntry In AccountExpenseEntries.Rows
            With AccountExpenseEntry
                .ModifiedOn = Now
                .Approved = Approved
                .Submitted = Submitted
                If Submitted = True Then
                    .Rejected = False
                End If
                If Approved = False Then
                    Me.DeleteIsApprovedStatusApproval(AccountExpenseEntry.AccountExpenseEntryId)
                End If
            End With
            Dim rowsAffected As Integer = Adapter.Update(AccountExpenseEntry)
        Next
        ' Return true if precisely one row was updated, otherwise false
        Return 1
    End Function
    ''' <summary>
    ''' Update in approval in expense sheet of specified AccountEmployeeExpenseSheetId, ApprovalType
    ''' </summary>
    ''' <param name="AccountEmployeeExpenseSheetId"></param>
    ''' <param name="ApprovalType"></param>
    ''' <remarks></remarks>
    Public Sub UpdateInApprovalInExpenseSheet(ByVal AccountEmployeeExpenseSheetId As Guid, ByVal ApprovalType As String)
        Dim BLL As New AccountEmployeeExpenseSheetBLL
        If ApprovalType = "Approved" Then
            BLL.UpdateInApproval(True, AccountEmployeeExpenseSheetId)
        ElseIf ApprovalType = "Rejected" And GetTotalIsApprovedFromExpenseApprovalByExpenseSheetId(AccountEmployeeExpenseSheetId) = True Then
            BLL.UpdateInApproval(False, AccountEmployeeExpenseSheetId)
        End If
    End Sub
    ''' <summary>
    ''' Get total is approved from expense approval by expense sheet id of specified AccountEmployeeExpenseSheetId
    ''' </summary>
    ''' <param name="AccountEmployeeExpenseSheetId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetTotalIsApprovedFromExpenseApprovalByExpenseSheetId(ByVal AccountEmployeeExpenseSheetId As Guid) As Boolean
        Dim TotalCount As Integer = 0
        Dim dt As TimeLiveDataSet.AccountExpenseEntryDataTable = Adapter.GetDataByAccountEmployeeExpenseSheetId(AccountEmployeeExpenseSheetId)
        Dim dr As TimeLiveDataSet.AccountExpenseEntryRow
        If dt.Rows.Count > 0 Then
            For Each dr In dt.Rows
                If GetIsApprovedFromExpenseApproval(dr.AccountExpenseEntryId) = True Then
                    TotalCount += 1
                End If
            Next
            If TotalCount = dt.Rows.Count Then
                Return True
            End If
        End If
    End Function
    ''' <summary>
    ''' GetIs approved from expense approval of specified AccountExpenseEntryId
    ''' </summary>
    ''' <param name="AccountExpenseEntryId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetIsApprovedFromExpenseApproval(ByVal AccountExpenseEntryId As Integer) As Boolean
        Dim dtApproval As TimeLiveDataSet.AccountExpenseEntryApprovalDataTable = AccountExpenseEntryApprovalAdapter.GetDataByAccountExpenseEntryId(AccountExpenseEntryId)
        Dim drApproval As TimeLiveDataSet.AccountExpenseEntryApprovalRow
        If dtApproval.Rows.Count > 0 Then
            For Each drApproval In dtApproval.Rows
                If Not IsDBNull(drApproval.Item("IsApproved")) Then
                    Return drApproval.IsApproved
                End If
            Next
        End If
    End Function
    ''' <summary>
    ''' Set expense status of specified ExpenseStatusLabel, StatusImage, AccountEmployeeExpenseSheetID
    ''' </summary>
    ''' <param name="ExpenseStatusLabel"></param>
    ''' <param name="StatusImage"></param>
    ''' <param name="AccountEmployeeExpenseSheetID"></param>
    ''' <remarks></remarks>
    Public Sub SetExpenseStatus(ByVal ExpenseStatusLabel As Label, ByVal StatusImage As System.Web.UI.WebControls.Image, ByVal AccountEmployeeExpenseSheetID As Guid)
        Dim BLL As New AccountEmployeeExpenseSheetBLL
        Dim dt As AccountExpenseEntry.AccountEmployeeExpenseSheetDataTable = BLL.GetAccountEmployeeExpenseSheetByAccountEmployeeExpenseSheetId(AccountEmployeeExpenseSheetID)
        Dim dr As AccountExpenseEntry.AccountEmployeeExpenseSheetRow

        If dt.Rows.Count > 0 Then
            dr = dt.Rows(0)
            If dr.Submitted = False And dr.Rejected = False And dr.Approved = False And dr.InApproval = False Then
                ExpenseStatusLabel.Text = ResourceHelper.GetFromResource("Not Submitted")
                StatusImage.ImageUrl = "~/images/NotSubmittedStatus.gif"
            ElseIf dr.Submitted = True And dr.Approved = True And dr.Rejected = False Then
                ExpenseStatusLabel.Text = ResourceHelper.GetFromResource("Approved")
                StatusImage.ImageUrl = "~/images/ApprovedStatus.gif"
            ElseIf dr.Rejected = True And dr.Submitted = False Then
                ExpenseStatusLabel.Text = ResourceHelper.GetFromResource("Rejected")
                StatusImage.ImageUrl = "~/images/RejectedStatus.gif"
            ElseIf dr.Submitted = True And dr.Rejected = False And dr.Approved = False And dr.InApproval = True Then
                ExpenseStatusLabel.Text = ResourceHelper.GetFromResource("Submitted")
                StatusImage.ImageUrl = "~/images/SubmittedStatus.gif"
            ElseIf dr.Submitted = True And dr.Rejected = False And dr.Approved = False And dr.InApproval = False Then
                ExpenseStatusLabel.Text = ResourceHelper.GetFromResource("Submitted")
                StatusImage.ImageUrl = "~/images/SubmittedStatus.gif"
            ElseIf dr.Submitted = False And dr.Approved = True Then
                ExpenseStatusLabel.Text = ResourceHelper.GetFromResource("Not Submitted")
                StatusImage.ImageUrl = "~/images/NotSubmittedStatus.gif"
            ElseIf dr.Submitted = False And dr.InApproval = True Then
                ExpenseStatusLabel.Text = ResourceHelper.GetFromResource("Not Submitted")
                StatusImage.ImageUrl = "~/images/NotSubmittedStatus.gif"
            ElseIf dr.Submitted = True And dr.Rejected = True And dr.Approved = True And dr.InApproval = True Then
                ExpenseStatusLabel.Text = ResourceHelper.GetFromResource("Approved")
                StatusImage.ImageUrl = "~/images/ApprovedStatus.gif"
            ElseIf dr.Submitted = True And dr.Rejected = True Then
                ExpenseStatusLabel.Text = ResourceHelper.GetFromResource("Submitted")
                StatusImage.ImageUrl = "~/images/SubmittedStatus.gif"
            End If
        Else
            ExpenseStatusLabel.Text = ResourceHelper.GetFromResource("Not Submitted")
            StatusImage.ImageUrl = "~/images/NotSubmittedStatus.gif"
        End If
    End Sub
    ''' <summary>
    ''' Get view expense entry with last status read only for team lead of specified AccountEmployeeId, AccountEmployeeExpenseSheetId, ViewerEmployeeId
    ''' </summary>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="AccountEmployeeExpenseSheetId"></param>
    ''' <param name="ViewerEmployeeId"></param>
    ''' <returns>vueAccountExpenseEntryWithLastStatusReadOnly data table</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)>
    Public Function GetvueAccountExpenseEntryWithLastStatusReadOnlyForTeamLead(ByVal AccountEmployeeId As Integer, ByVal AccountEmployeeExpenseSheetId As Guid, ByVal ViewerEmployeeId As Integer) As AccountExpenseEntry.vueAccountExpenseEntryWithLastStatusReadOnlyDataTable
        Dim _vueAccountExpenseEntryWithLastStatusReadOnlyTableAdapter As New vueAccountExpenseEntryWithLastStatusReadOnlyTableAdapter
        Return _vueAccountExpenseEntryWithLastStatusReadOnlyTableAdapter.GetDataForTeamLead(AccountEmployeeId, AccountEmployeeExpenseSheetId, ViewerEmployeeId)
    End Function
    ''' <summary>
    ''' Get view expense entry with last status read only for project manager of specified AccountEmployeeId, AccountEmployeeExpenseSheetId, ViewerEmployeeId
    ''' </summary>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="AccountEmployeeExpenseSheetId"></param>
    ''' <param name="ViewerEmployeeId"></param>
    ''' <returns>vueAccountExpenseEntryWithLastStatusReadOnly data table</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)>
    Public Function GetvueAccountExpenseEntryWithLastStatusReadOnlyForProjectManager(ByVal AccountEmployeeId As Integer, ByVal AccountEmployeeExpenseSheetId As Guid, ByVal ViewerEmployeeId As Integer) As AccountExpenseEntry.vueAccountExpenseEntryWithLastStatusReadOnlyDataTable
        Dim _vueAccountExpenseEntryWithLastStatusReadOnlyTableAdapter As New vueAccountExpenseEntryWithLastStatusReadOnlyTableAdapter
        Return _vueAccountExpenseEntryWithLastStatusReadOnlyTableAdapter.GetDataForProjectManager(AccountEmployeeId, AccountEmployeeExpenseSheetId, ViewerEmployeeId)
    End Function
    ''' <summary>
    ''' Get view expense entry with last status read only for specific employee of specified AccountEmployeeId, AccountEmployeeExpenseSheetId, ViewerEmployeeId
    ''' </summary>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="AccountEmployeeExpenseSheetId"></param>
    ''' <param name="ViewerEmployeeId"></param>
    ''' <returns>vueAccountExpenseEntryWithLastStatusReadOnly data table</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)>
    Public Function GetvueAccountExpenseEntryWithLastStatusReadOnlyForSpecificEmployee(ByVal AccountEmployeeId As Integer, ByVal AccountEmployeeExpenseSheetId As Guid, ByVal ViewerEmployeeId As Integer) As AccountExpenseEntry.vueAccountExpenseEntryWithLastStatusReadOnlyDataTable
        Dim _vueAccountExpenseEntryWithLastStatusReadOnlyTableAdapter As New vueAccountExpenseEntryWithLastStatusReadOnlyTableAdapter
        Return _vueAccountExpenseEntryWithLastStatusReadOnlyTableAdapter.GetDataForSpecificEmployee(AccountEmployeeId, AccountEmployeeExpenseSheetId, ViewerEmployeeId)
    End Function
    ''' <summary>
    ''' Get view expense entry with last status read only for specific external user of specified AccountEmployeeId, AccountEmployeeExpenseSheetId, ViewerEmployeeId
    ''' </summary>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="AccountEmployeeExpenseSheetId"></param>
    ''' <param name="ViewerEmployeeId"></param>
    ''' <returns>vueAccountExpenseEntryWithLastStatusReadOnly data table</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)>
    Public Function GetvueAccountExpenseEntryWithLastStatusReadOnlyForSpecificExternalUser(ByVal AccountEmployeeId As Integer, ByVal AccountEmployeeExpenseSheetId As Guid, ByVal ViewerEmployeeId As Integer) As AccountExpenseEntry.vueAccountExpenseEntryWithLastStatusReadOnlyDataTable
        Dim _vueAccountExpenseEntryWithLastStatusReadOnlyTableAdapter As New vueAccountExpenseEntryWithLastStatusReadOnlyTableAdapter
        _vueAccountExpenseEntryWithLastStatusReadOnlyTableAdapter.SetCommandTimeOut(1000)
        Return _vueAccountExpenseEntryWithLastStatusReadOnlyTableAdapter.GetDataForExternalUser(AccountEmployeeId, AccountEmployeeExpenseSheetId, ViewerEmployeeId)
    End Function
    ''' <summary>
    ''' Get view expense entry with last status read only for employee manager of specified AccountEmployeeId, AccountEmployeeExpenseSheetId, ViewerEmployeeId
    ''' </summary>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="AccountEmployeeExpenseSheetId"></param>
    ''' <param name="ViewerEmployeeId"></param>
    ''' <returns>vueAccountExpenseEntryWithLastStatusReadOnly data table</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)>
    Public Function GetvueAccountExpenseEntryWithLastStatusReadOnlyForEmployeeManager(ByVal AccountEmployeeId As Integer, ByVal AccountEmployeeExpenseSheetId As Guid, ByVal ViewerEmployeeId As Integer) As AccountExpenseEntry.vueAccountExpenseEntryWithLastStatusReadOnlyDataTable
        Dim _vueAccountExpenseEntryWithLastStatusReadOnlyTableAdapter As New vueAccountExpenseEntryWithLastStatusReadOnlyTableAdapter
        Return _vueAccountExpenseEntryWithLastStatusReadOnlyTableAdapter.GetDataByForEmployeeManager(AccountEmployeeId, AccountEmployeeExpenseSheetId, ViewerEmployeeId)
    End Function
    ''' <summary>
    ''' Get view reimbursement currency by account id of specified AccountId
    ''' </summary>
    ''' <param name="AccountId"></param>
    ''' <returns>vueAccountReimbursementCurrency data table</returns>
    ''' <remarks></remarks>
    Public Function GetvueAccountReimbursementCurrencyByAccountId(ByVal AccountId As Integer) As AccountExpenseEntry.vueAccountReimbursementCurrencyDataTable
        Dim _vueAccountReimbursementCurrencyTableAdapter As New vueAccountReimbursementCurrencyTableAdapter
        Return _vueAccountReimbursementCurrencyTableAdapter.GetDataByAccountId(AccountId)
    End Function
    ''' <summary>
    ''' Get total reimbursement amount by expense sheet id of specified AccountEmployeeExpenseSheetId, AccountReimbursementCurrencyId
    ''' </summary>
    ''' <param name="AccountEmployeeExpenseSheetId"></param>
    ''' <param name="AccountReimbursementCurrencyId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetTotalReimbursementAmountByExpenseSheetId(ByVal AccountEmployeeExpenseSheetId As Guid, ByVal AccountReimbursementCurrencyId As Integer)
        Dim TotalAmount As Double
        Dim ExchangeRate As Double
        Dim CurrencyBLL As New AccountCurrencyBLL
        Dim dtExpenseEntry As TimeLiveDataSet.vueAccountExpenseEntryWithLastStatusDataTable = New AccountExpenseEntryBLL().GetvueAccountExpenseEntryWithLastStausByEmployeeExpenseSheetId(AccountEmployeeExpenseSheetId)
        Dim drExpenseEntry As TimeLiveDataSet.vueAccountExpenseEntryWithLastStatusRow

        If dtExpenseEntry.Rows.Count > 0 Then
            drExpenseEntry = dtExpenseEntry.Rows(0)
            For Each drExpenseEntry In dtExpenseEntry.Rows
                If Not IsDBNull(drExpenseEntry.Item("Reimburse")) And drExpenseEntry.Item("Reimburse").ToString <> "False" Then
                    ExchangeRate = CurrencyBLL.GetExchangeRateByAccountCurrencyId(drExpenseEntry.AccountCurrencyId)
                    TotalAmount += drExpenseEntry.Amount / ExchangeRate
                End If
            Next
        End If
        Dim TotalReimbursementAmount As Double
        ExchangeRate = CurrencyBLL.GetExchangeRateByAccountCurrencyId(AccountReimbursementCurrencyId)
        TotalReimbursementAmount = ExchangeRate * TotalAmount
        Return String.Format("{0:N}", TotalReimbursementAmount)
    End Function
    ''' <summary>
    ''' Get total reimbursement amount of specified TotalAmount, AccountReimbursementCurrencyId
    ''' </summary>
    ''' <param name="TotalAmount"></param>
    ''' <param name="AccountReimbursementCurrencyId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetTotalReimbursementAmount(ByVal TotalAmount As String, ByVal AccountReimbursementCurrencyId As Integer, ByVal ExpenseSheetDate As Date)
        Dim ExchangeRate As Double
        Dim CurrencyBLL As New AccountCurrencyBLL
        Dim ExchangeRateBLL As New AccountCurrencyExchangeRateBLL
        ''Dim ExchangeRate As Double = CurrencyBLL.GetExchangeRateByAccountCurrencyId(AccountReimbursementCurrencyId)
        ExchangeRate = ExchangeRateBLL.GetCurrentExchangeRateByCurrencyIdAndDate(AccountReimbursementCurrencyId, ExpenseSheetDate)
        Dim TotalReimbursementAmount As Double = ExchangeRate * TotalAmount
        Return String.Format("{0:N}", TotalReimbursementAmount)
    End Function
    ''' <summary>
    ''' Add expense entry with expense sheet from import of specified AccountId, AccountExpenseEntryDate, AccountEmployeeId,
    ''' AccountProjectId, AccountExpenseId, Amount, CreatedOn, CreatedByEmployeeId, ModifiedOn, ModifiedByEmployeeId, Description,
    ''' IsBillable, Reimburse, AccountCurrencyId, Quantity, Rate, AmountBeforeTax, TaxAmount, AccountPaymentMethodId, ExchangeRate,
    ''' AccountTaxZoneId, Submitted, Approved, Rejected, ExpenseSheetDescription, ExpenseSheetDate, SubmittedDate, SheetApproved,
    ''' SheetRejected, SheetSubmitted, SheetInApproval
    ''' </summary>
    ''' <param name="AccountId"></param>
    ''' <param name="AccountExpenseEntryDate"></param>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="AccountProjectId"></param>
    ''' <param name="AccountExpenseId"></param>
    ''' <param name="Amount"></param>
    ''' <param name="CreatedOn"></param>
    ''' <param name="CreatedByEmployeeId"></param>
    ''' <param name="ModifiedOn"></param>
    ''' <param name="ModifiedByEmployeeId"></param>
    ''' <param name="Description"></param>
    ''' <param name="IsBillable"></param>
    ''' <param name="Reimburse"></param>
    ''' <param name="AccountCurrencyId"></param>
    ''' <param name="Quantity"></param>
    ''' <param name="Rate"></param>
    ''' <param name="AmountBeforeTax"></param>
    ''' <param name="TaxAmount"></param>
    ''' <param name="AccountPaymentMethodId"></param>
    ''' <param name="ExchangeRate"></param>
    ''' <param name="AccountTaxZoneId"></param>
    ''' <param name="Submitted"></param>
    ''' <param name="Approved"></param>
    ''' <param name="Rejected"></param>
    ''' <param name="ExpenseSheetDescription"></param>
    ''' <param name="ExpenseSheetDate"></param>
    ''' <param name="SubmittedDate"></param>
    ''' <param name="SheetApproved"></param>
    ''' <param name="SheetRejected"></param>
    ''' <param name="SheetSubmitted"></param>
    ''' <param name="SheetInApproval"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function AddAccountExpenseEntryWithExpenseSheetFromImport(
                 ByVal AccountId As Integer, ByVal AccountExpenseEntryDate As Date, ByVal AccountEmployeeId As Integer, ByVal AccountClientId As Integer, ByVal AccountProjectId As Integer, ByVal AccountProjectTaskId As Integer, ByVal AccountExpenseId As Integer, ByVal Amount As Double, ByVal CreatedOn As DateTime, ByVal CreatedByEmployeeId As Integer, ByVal ModifiedOn As DateTime, ByVal ModifiedByEmployeeId As Integer, ByVal Description As String, ByVal IsBillable As Boolean, ByVal Reimburse As Boolean,
                   ByVal AccountCurrencyId As Integer, ByVal Quantity As Double, ByVal Rate As Double, ByVal AmountBeforeTax As Double, ByVal TaxAmount As Double, ByVal AccountPaymentMethodId As System.Nullable(Of Integer),
                 ByVal ExchangeRate As Double, ByVal AccountTaxZoneId As Integer, ByVal Submitted As Boolean, ByVal Approved As Boolean, ByVal Rejected As Boolean, ByVal ExpenseSheetDescription As String, ByVal ExpenseSheetDate As Date,
    ByVal SubmittedDate As Date, ByVal SheetApproved As Boolean, ByVal SheetRejected As Boolean, ByVal SheetSubmitted As Boolean, ByVal SheetInApproval As Boolean) As Boolean

        If ExpenseSheetDescription = "" And Description <> "" Then
            ExpenseSheetDescription = Description
        ElseIf ExpenseSheetDescription = "" Then
            ExpenseSheetDescription = "."
        End If
        Dim objExpenseSheetBLL As New AccountEmployeeExpenseSheetBLL
        Dim AccountEmployeeExpenseSheetId As Guid

        If objExpenseSheetBLL.IsExpenseSheetExistsByAccountEmployeeIdADescriptionAndDate(AccountEmployeeId, ExpenseSheetDescription, ExpenseSheetDate) = False Then
            AccountEmployeeExpenseSheetId = objExpenseSheetBLL.AddAccountEmployeeExpenseSheet(AccountId, AccountEmployeeId, ExpenseSheetDescription, ExpenseSheetDate, SheetApproved, SheetRejected, SheetSubmitted, SheetApproved, SubmittedDate)
        Else
            AccountEmployeeExpenseSheetId = objExpenseSheetBLL.GetAccountEmployeeExpenseSheetIdByAccountEmployeeIdDescriptionAndDate(AccountEmployeeId, ExpenseSheetDescription, ExpenseSheetDate)
        End If

        Dim objExpenseEntryBLL As New AccountExpenseEntryBLL
        objExpenseEntryBLL.AddAccountExpenseEntry(AccountId, AccountExpenseEntryDate, AccountEmployeeId, AccountClientId, AccountProjectId,
        AccountProjectTaskId, AccountExpenseId, Amount, CreatedOn, CreatedByEmployeeId, ModifiedOn, ModifiedByEmployeeId, Description, IsBillable, Reimburse,
        AccountCurrencyId, Quantity, Rate, AmountBeforeTax, TaxAmount,
        AccountPaymentMethodId, ExchangeRate, AccountTaxZoneId, Submitted, AccountEmployeeExpenseSheetId, Approved, Rejected, True)

    End Function
    ''' <summary>
    ''' Insert expense entry by employee expense sheet id of specified AccountEmployeeExpenseSheetId, NewExpenseSheetId
    ''' </summary>
    ''' <param name="AccountEmployeeExpenseSheetId"></param>
    ''' <param name="NewExpenseSheetId"></param>
    ''' <remarks></remarks>
    Public Sub InsertAccountExpenseEntryByAccountEmployeeExpenseSheetId(ByVal AccountEmployeeExpenseSheetId As Guid, ByVal NewExpenseSheetId As Guid)
        Adapter.InsertExpenseEntryByEmployeeExpenseSheetId(AccountEmployeeExpenseSheetId, NewExpenseSheetId, DBUtilities.GetSessionAccountEmployeeId, Now.Date)
    End Sub
    ''' <summary>
    ''' Get expense entries by employee expense sheet id of specified AccountEmployeeExpenseSheetId
    ''' </summary>
    ''' <param name="AccountEmployeeExpenseSheetId"></param>
    ''' <returns>AccountExpenseEntry data table</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)>
    Public Function GetAccountExpenseEntriesByAccountEmployeeExpenseSheetId(ByVal AccountEmployeeExpenseSheetId As Guid) As TimeLiveDataSet.AccountExpenseEntryDataTable
        Return Adapter.GetDataByAccountEmployeeExpenseSheetId(AccountEmployeeExpenseSheetId)
    End Function
    ''' <summary>
    ''' Get approval entries for team lead summarized of specified AccountEmployeeId, ExpenseEntryAccountEmployeeId, ExpenseEntryStartDate,
    ''' ExpenseEntryEndDate, IncludeDateRange
    ''' </summary>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="ExpenseEntryAccountEmployeeId"></param>
    ''' <param name="ExpenseEntryStartDate"></param>
    ''' <param name="ExpenseEntryEndDate"></param>
    ''' <param name="IncludeDateRange"></param>
    ''' <returns>vueAccountExpenseEntryApprovalPendingSummary data table</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)>
    Public Function GetApprovalEntriesSummarizedForMobile(ByVal AccountEmployeeId As Integer, ByVal ExpenseEntryAccountEmployeeId As Integer, ByVal ExpenseEntryStartDate As Date, ByVal ExpenseEntryEndDate As Date, ByVal IncludeDateRange As Boolean) As AccountExpenseEntry.vueAccountExpenseEntryApprovalPendingSummaryDataTable
        Dim _vueAccountExpenseEntryApprovalPendingSummaryTableAdapter As New vueAccountExpenseEntryApprovalPendingSummaryTableAdapter
        Return _vueAccountExpenseEntryApprovalPendingSummaryTableAdapter.GetApprovalEntriesSummarizedForMobile(ExpenseEntryAccountEmployeeId, IncludeDateRange, ExpenseEntryStartDate, ExpenseEntryEndDate, AccountEmployeeId)
    End Function
    ''' <summary>
    ''' Get approval entries for team lead summarized of specified AccountEmployeeId, ExpenseEntryAccountEmployeeId, ExpenseEntryStartDate,
    ''' ExpenseEntryEndDate, IncludeDateRange
    ''' </summary>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="ExpenseEntryAccountEmployeeId"></param>
    ''' <param name="ExpenseEntryStartDate"></param>
    ''' <param name="ExpenseEntryEndDate"></param>
    ''' <param name="IncludeDateRange"></param>
    ''' <returns>vueAccountExpenseEntryApprovalPendingSummary data table</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)>
    Public Function GetApprovalEntriesForTeamLeadSummarized(ByVal AccountEmployeeId As Integer, ByVal ExpenseEntryAccountEmployeeId As Integer, ByVal ExpenseEntryStartDate As Date, ByVal ExpenseEntryEndDate As Date, ByVal IncludeDateRange As Boolean) As AccountExpenseEntry.vueAccountExpenseEntryApprovalPendingSummaryDataTable
        Dim _vueAccountExpenseEntryApprovalPendingSummaryTableAdapter As New vueAccountExpenseEntryApprovalPendingSummaryTableAdapter
        Return _vueAccountExpenseEntryApprovalPendingSummaryTableAdapter.GetApprovalEntriesForTeamLeadSummarized(ExpenseEntryAccountEmployeeId, IncludeDateRange, ExpenseEntryStartDate, ExpenseEntryEndDate, AccountEmployeeId)
    End Function
    ''' <summary>
    ''' GetApprovalEntriesForProjectManagerSummarized of specified AccountEmployeeId, ExpenseEntryAccountEmployeeId, ExpenseEntryStartDate,
    ''' ExpenseEntryEndDate, IncludeDateRange
    ''' </summary>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="ExpenseEntryAccountEmployeeId"></param>
    ''' <param name="ExpenseEntryStartDate"></param>
    ''' <param name="ExpenseEntryEndDate"></param>
    ''' <param name="IncludeDateRange"></param>
    ''' <returns>vueAccountExpenseEntryApprovalPendingSummary data table</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)>
    Public Function GetApprovalEntriesForProjectManagerSummarized(ByVal AccountEmployeeId As Integer, ByVal ExpenseEntryAccountEmployeeId As Integer, ByVal ExpenseEntryStartDate As Date, ByVal ExpenseEntryEndDate As Date, ByVal IncludeDateRange As Boolean) As AccountExpenseEntry.vueAccountExpenseEntryApprovalPendingSummaryDataTable
        Dim _vueAccountExpenseEntryApprovalPendingSummaryTableAdapter As New vueAccountExpenseEntryApprovalPendingSummaryTableAdapter
        Return _vueAccountExpenseEntryApprovalPendingSummaryTableAdapter.GetApprovalEntriesForProjectManagerSummarized(ExpenseEntryAccountEmployeeId, IncludeDateRange, ExpenseEntryStartDate, ExpenseEntryEndDate, AccountEmployeeId)
    End Function
    ''' <summary>
    ''' Get approval entries for specific employee Summarized of specified AccountEmployeeId, ExpenseEntryAccountEmployeeId,
    ''' ExpenseEntryStartDate, ExpenseEntryEndDate, IncludeDateRange
    ''' </summary>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="ExpenseEntryAccountEmployeeId"></param>
    ''' <param name="ExpenseEntryStartDate"></param>
    ''' <param name="ExpenseEntryEndDate"></param>
    ''' <param name="IncludeDateRange"></param>
    ''' <returns>vueAccountExpenseEntryApprovalPendingSummary data table</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)>
    Public Function GetApprovalEntriesForSpecificEmployeeSummarized(ByVal AccountEmployeeId As Integer, ByVal ExpenseEntryAccountEmployeeId As Integer, ByVal ExpenseEntryStartDate As Date, ByVal ExpenseEntryEndDate As Date, ByVal IncludeDateRange As Boolean) As AccountExpenseEntry.vueAccountExpenseEntryApprovalPendingSummaryDataTable
        Dim _vueAccountExpenseEntryApprovalPendingSummaryTableAdapter As New vueAccountExpenseEntryApprovalPendingSummaryTableAdapter
        Return _vueAccountExpenseEntryApprovalPendingSummaryTableAdapter.GetApprovalEntriesForSpecificEmployeeSummarized(ExpenseEntryAccountEmployeeId, IncludeDateRange, ExpenseEntryStartDate, ExpenseEntryEndDate, AccountEmployeeId)
    End Function
    ''' <summary>
    ''' Get approval entries for specific external user Summarized of specified AccountEmployeeId, ExpenseEntryAccountEmployeeId,
    ''' ExpenseEntryStartDate, ExpenseEntryEndDate, IncludeDateRange
    ''' </summary>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="ExpenseEntryAccountEmployeeId"></param>
    ''' <param name="ExpenseEntryStartDate"></param>
    ''' <param name="ExpenseEntryEndDate"></param>
    ''' <param name="IncludeDateRange"></param>
    ''' <returns>vueAccountExpenseEntryApprovalPendingSummary data table</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)>
    Public Function GetApprovalEntriesForSpecificExternalUserSummarized(ByVal AccountEmployeeId As Integer, ByVal ExpenseEntryAccountEmployeeId As Integer, ByVal ExpenseEntryStartDate As Date, ByVal ExpenseEntryEndDate As Date, ByVal IncludeDateRange As Boolean) As AccountExpenseEntry.vueAccountExpenseEntryApprovalPendingSummaryDataTable
        Dim _vueAccountExpenseEntryApprovalPendingSummaryTableAdapter As New vueAccountExpenseEntryApprovalPendingSummaryTableAdapter
        Return _vueAccountExpenseEntryApprovalPendingSummaryTableAdapter.GetApprovalEntriesForSpecificExternalUserSummarized(ExpenseEntryAccountEmployeeId, IncludeDateRange, ExpenseEntryStartDate, ExpenseEntryEndDate, AccountEmployeeId)
    End Function
    ''' <summary>
    ''' Get approval entries for employee manager Summarized of specified AccountEmployeeId, ExpenseEntryAccountEmployeeId,
    ''' ExpenseEntryStartDate, ExpenseEntryEndDate, IncludeDateRange
    ''' </summary>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="ExpenseEntryAccountEmployeeId"></param>
    ''' <param name="ExpenseEntryStartDate"></param>
    ''' <param name="ExpenseEntryEndDate"></param>
    ''' <param name="IncludeDateRange"></param>
    ''' <returns>vueAccountExpenseEntryApprovalPendingSummary data table</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)>
    Public Function GetApprovalEntriesForEmployeeManagerSummarized(ByVal AccountEmployeeId As Integer, ByVal ExpenseEntryAccountEmployeeId As Integer, ByVal ExpenseEntryStartDate As Date, ByVal ExpenseEntryEndDate As Date, ByVal IncludeDateRange As Boolean) As AccountExpenseEntry.vueAccountExpenseEntryApprovalPendingSummaryDataTable
        Dim _vueAccountExpenseEntryApprovalPendingSummaryTableAdapter As New vueAccountExpenseEntryApprovalPendingSummaryTableAdapter
        Return _vueAccountExpenseEntryApprovalPendingSummaryTableAdapter.GetApprovalEntriesForEmployeeManagerSummarized(ExpenseEntryAccountEmployeeId, IncludeDateRange, ExpenseEntryStartDate, ExpenseEntryEndDate, AccountEmployeeId)
    End Function
    ''' <summary>
    ''' Get pending expense entry approvals with preference by approver employee id and isemailsend = false of specified ApproverEmployeeId
    ''' </summary>
    ''' <param name="ApproverEmployeeId"></param>
    ''' <returns>vueAccountExpenseEntryApprovalPendingEmailWithPreference data table</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)>
    Public Function GetPendingExpenseEntryApprovalsWithPreferenceByApproverEmployeeIdForEmail(ByVal ApproverEmployeeId As Integer) As AccountExpenseEntry.vueAccountExpenseEntryApprovalPendingEmailInstantWithPreferenceDataTable
        Dim _vueAccountExpenseEntryApprovalPendingEmailInstantWithPreferenceTableAdapter As New vueAccountExpenseEntryApprovalPendingEmailInstantWithPreferenceTableAdapter
        Return _vueAccountExpenseEntryApprovalPendingEmailInstantWithPreferenceTableAdapter.GetDataByApproverEmployeeIdAndIsEmailSend(ApproverEmployeeId)
    End Function
    ''' <summary>
    ''' get pending expense approvals by expensesheetid grouped by approver employeeid for email.
    ''' </summary>
    ''' <param name="AccountEmployeeExpenseSheetId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)>
    Public Function GetPendingExpenseEntryApprovalsByExpenseSheetIdGroupByApproverEmployeeId(ByVal AccountEmployeeExpenseSheetId As Guid) As AccountExpenseEntry.vueAccountExpenseEntryApprovalPendingEmailInstantWithPreferenceGroupedDataTable
        Dim _vueAccountExpenseEntryApprovalPendingEmailInstantWithPreferenceGroupedTableAdapter As New vueAccountExpenseEntryApprovalPendingEmailInstantWithPreferenceGroupedTableAdapter
        Return _vueAccountExpenseEntryApprovalPendingEmailInstantWithPreferenceGroupedTableAdapter.GetDataByAccountEmployeeExpenseSheetId(AccountEmployeeExpenseSheetId)
    End Function
    ''' <summary>
    ''' Send email by sheetid.
    ''' </summary>
    ''' <param name="AccountEmployeeExpenseSheetId"></param>
    ''' <param name="ExpenseEntryIdArray"></param>
    ''' <remarks></remarks>
    Public Sub SendExpenseApprovalPendingEmail(ByVal AccountEmployeeExpenseSheetId As Guid, Optional ByVal ExpenseEntryIdArray As ArrayList = Nothing)
        Dim dt As AccountExpenseEntry.vueAccountExpenseEntryApprovalPendingEmailInstantWithPreferenceGroupedDataTable = Me.GetPendingExpenseEntryApprovalsByExpenseSheetIdGroupByApproverEmployeeId(AccountEmployeeExpenseSheetId)
        If dt.Rows.Count > 0 Then
            Dim dr As AccountExpenseEntry.vueAccountExpenseEntryApprovalPendingEmailInstantWithPreferenceGroupedRow = dt.Rows(0)
            For Each dr In dt.Rows
                Me.SendPendingExpense(dr.ApproverEmployeeId, True)
            Next
            If ExpenseEntryIdArray Is Nothing Then
                UpdateIsEmailSendByAccountEmployeeExpenseSheetId(AccountEmployeeExpenseSheetId)
            Else
                For n As Integer = 0 To ExpenseEntryIdArray.Count - 1
                    UpdateIsEmailSendByAccountExpenseEntryId(ExpenseEntryIdArray.Item(n), True)
                Next
            End If
            EMailUtilities.DequeueEmail()
        End If
    End Sub
    Public Sub UpdateAccountEmployeeExpenseSheetAndEntriesForMobile(ByVal AccountEmployeeExpenseSheetId As String)
        Try
            If AccountEmployeeExpenseSheetId.ToString <> "" Then
                Dim ExpenseSheetId As New Guid(AccountEmployeeExpenseSheetId)
                UpdateSubmittedByAccountEmployeeExpenseSheetId(True, ExpenseSheetId)
                Dim SheetBLL As New AccountEmployeeExpenseSheetBLL
                SheetBLL.UpdateSubmittedDate(Now.Date, ExpenseSheetId)
                SheetBLL.UpdateMasterSubmitted(True, ExpenseSheetId)
            End If
        Catch ex As Exception

        End Try
    End Sub
    ''' <summary>
    ''' Update IsEmailSend by AccountEmployeeExpenseSheetId.
    ''' </summary>
    ''' <param name="AccountEmployeeExpenseSheetId"></param>
    ''' <remarks></remarks>
    Public Sub UpdateIsEmailSendByAccountEmployeeExpenseSheetId(ByVal AccountEmployeeExpenseSheetId As Guid)
        Adapter.UpdateIsEmailSendByAccountEmployeeExpenseSheetId(AccountEmployeeExpenseSheetId)
    End Sub
    ''' <summary>
    ''' Update IsEmailSend by AccountExpenseEntryId.
    ''' </summary>
    ''' <param name="AccountExpenseEntryId"></param>
    ''' <param name="IsEmailSend"></param>
    ''' <remarks></remarks>
    Public Sub UpdateIsEmailSendByAccountExpenseEntryId(ByVal AccountExpenseEntryId As Integer, ByVal IsEmailSend As Boolean)
        Adapter.UpdateIsEmailSendByAccountExpenseEntryId(IsEmailSend, AccountExpenseEntryId)
    End Sub
    ''' <summary>
    ''' Get Approved Expense Entry For Email to Approver By ExpenseSheetId.
    ''' </summary>
    ''' <param name="AccountEmployeeExpenseSheetId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)>
    Public Function GetApprovedAccountExpenseEntryForEmailToApproverByExpenseSheetId(ByVal AccountEmployeeExpenseSheetId As Guid, ByVal ApproverId As Integer) As AccountExpenseEntry.vueAccountExpenseEntryApprovedEmailToApproverDataTable
        Dim _vueAccountExpenseEntryApprovedEmailToApproverTableAdapter As New vueAccountExpenseEntryApprovedEmailToApproverTableAdapter
        Return _vueAccountExpenseEntryApprovedEmailToApproverTableAdapter.GetDataByAccountEmployeeExpenseSheetId(AccountEmployeeExpenseSheetId, ApproverId)
    End Function
    ''' <summary>
    ''' Get Rejected Expense Entry For Email to Approver By ExpenseSheetId.
    ''' </summary>
    ''' <param name="AccountEmployeeExpenseSheetId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)>
    Public Function GetRejectedAccountExpenseEntryForEmailToApproverByExpenseSheetId(ByVal AccountEmployeeExpenseSheetId As Guid) As AccountExpenseEntry.vueAccountExpenseEntryRejectedEmailToApproverDataTable
        Dim _vueAccountExpenseEntryRejectedEmailToApproverTableAdapter As New vueAccountExpenseEntryRejectedEmailToApproverTableAdapter
        Return _vueAccountExpenseEntryRejectedEmailToApproverTableAdapter.GetDataByAccountEmployeeExpenseSheetId(AccountEmployeeExpenseSheetId)
    End Function
    Public Sub byteArrayToImage(ByVal byteArrayIn As Byte())
        Dim newImage As System.Drawing.Image

        Dim strFileName As String = "yourfilename.gif"
        ''= Server.MapPath("~Temp") & "yourfilename.gif"
        If byteArrayIn IsNot Nothing Then
            Using stream As New MemoryStream(byteArrayIn)
                newImage = System.Drawing.Image.FromStream(stream)
                newImage.Save(strFileName)
            End Using
        End If
    End Sub
    'Protected Sub PlainUploadFiles(ByVal files As String)

    '    If files.Count > 0 Then
    '        For i As Integer = 0 To files.Count - 1

    '            If file.ContentLength > 0 Then
    '                Dim FileStream = file.InputStream
    '                ''Dim FileReader = New bi
    '                Dim fs As Stream = file.InputStream
    '                Dim br As New BinaryReader(fs)
    '                Dim bytes As [Byte]() = br.ReadBytes(DirectCast(fs.Length, Long))
    '            End If
    '            'DS = DS + 1
    '        Next
    '    End If
    'End Sub
    ''' <summary>
    ''' BulkExpenseEntryApprovalEntriesForApproved of specified AccountEmployeeExpenseSheetId, Chk, Comments, ApprovalType,
    ''' ExpenseEntryAccountEmployeeId, IncludeDateRange, ExpenseEntryStartDate, ExpenseEntryEndDate, AccountEmployeeId
    ''' </summary>
    ''' <param name="AccountEmployeeExpenseSheetId"></param>
    ''' <param name="Chk"></param>
    ''' <param name="Comments"></param>
    ''' <param name="ApprovalType"></param>
    ''' <param name="ExpenseEntryAccountEmployeeId"></param>
    ''' <param name="IncludeDateRange"></param>
    ''' <param name="ExpenseEntryStartDate"></param>
    ''' <param name="ExpenseEntryEndDate"></param>
    ''' <param name="AccountEmployeeId"></param>
    ''' <remarks></remarks>
    Public Sub BulkExpenseEntryApprovalEntriesForApprovedForMobile(ByVal AccountEmployeeExpenseSheetId As Guid, ByVal Chk As Boolean, ByVal Comments As String,
    ByVal ApprovalType As String, ByVal ExpenseEntryAccountEmployeeId As Integer, ByVal IncludeDateRange As Boolean,
    ByVal ExpenseEntryStartDate As Date, ByVal ExpenseEntryEndDate As Date, ByVal AccountEmployeeId As System.Nullable(Of Integer), ByVal ApprovalPathSequence As Integer)


        ApprovedTeamLeadEntriesForMobile(AccountEmployeeExpenseSheetId, Chk, Comments, ExpenseEntryAccountEmployeeId, IncludeDateRange, ExpenseEntryStartDate, ExpenseEntryEndDate, AccountEmployeeId, ApprovalPathSequence)


    End Sub
    ''' <summary>
    ''' Approved team lead entries of specified AccountEmployeeExpenseSheetId, Chk, Comments, ExpenseEntryAccountEmployeeId,
    ''' IncludeDateRange, ExpenseEntryStartDate, ExpenseEntryEndDate, AccountEmployeeId
    ''' </summary>
    ''' <param name="AccountEmployeeExpenseSheetId"></param>
    ''' <param name="Chk"></param>
    ''' <param name="Comments"></param>
    ''' <param name="ExpenseEntryAccountEmployeeId"></param>
    ''' <param name="IncludeDateRange"></param>
    ''' <param name="ExpenseEntryStartDate"></param>
    ''' <param name="ExpenseEntryEndDate"></param>
    ''' <param name="AccountEmployeeId"></param>
    ''' <remarks></remarks>
    Public Sub ApprovedTeamLeadEntriesForMobile(ByVal AccountEmployeeExpenseSheetId As Guid, ByVal Chk As Boolean, ByVal Comments As String,
    ByVal ExpenseEntryAccountEmployeeId As Integer, ByVal IncludeDateRange As Boolean,
    ByVal ExpenseEntryStartDate As Date, ByVal ExpenseEntryEndDate As Date, ByVal AccountEmployeeId As System.Nullable(Of Integer), ByVal ApprovalPathSequence As Integer)
        Dim TCount As Integer = 1
        Dim ExpenseSheetBLL As New AccountEmployeeExpenseSheetBLL
        Dim TLExpenseEntryId As New ArrayList
        Dim dtTeamLead As TimeLiveDataSet.vueAccountExpenseEntryApprovalPendingDataTable = Me.GetApprovalEntriesForTeamLeadForMobile(0, AccountEmployeeId, ExpenseEntryAccountEmployeeId, ExpenseEntryStartDate, ExpenseEntryEndDate, IncludeDateRange, AccountEmployeeExpenseSheetId)
        Dim drTeamLead As TimeLiveDataSet.vueAccountExpenseEntryApprovalPendingRow
        If dtTeamLead.Rows.Count > 0 Then
            For Each drTeamLead In dtTeamLead.Rows
                If Chk = True And IsDBNull(drTeamLead.Item("IsApproved")) Then
                    Me.AddExpenseApproval(drTeamLead.AccountExpenseEntryId, drTeamLead.AccountApprovalTypeId, drTeamLead.AccountApprovalPathId, drTeamLead.LeaderEmployeeId, Comments, False, True, ApprovalPathSequence)
                    Me.UpdateInApprovalInExpenseSheet(AccountEmployeeExpenseSheetId, "Approved")
                    If drTeamLead.ApprovalPathSequence = drTeamLead.MaxApprovalPathSequence Then
                        Me.LockTeamLeadExpenseEntry(drTeamLead.AccountExpenseEntryId, True)
                        Me.UpdateMasterApprovedByDetail(AccountEmployeeExpenseSheetId)
                        ExpenseSheetBLL.UpdateApprovedByEmployeeId(drTeamLead.LeaderEmployeeId, AccountEmployeeExpenseSheetId)
                    End If
                    UpdateIsEmailSendByAccountExpenseEntryId(drTeamLead.AccountExpenseEntryId, False)
                    TLExpenseEntryId.Add(drTeamLead.AccountExpenseEntryId)
                    If TCount = dtTeamLead.Rows.Count Then
                        Me.SendExpenseApprovedEMail(AccountEmployeeExpenseSheetId, Comments, TLExpenseEntryId)
                    End If
                ElseIf Chk = False And IsDBNull(drTeamLead.Item("IsApproved")) Then
                ElseIf Chk = True And drTeamLead.Item("IsApproved") = False Then
                    Me.AddExpenseApproval(drTeamLead.AccountExpenseEntryId, drTeamLead.AccountApprovalTypeId, drTeamLead.AccountApprovalPathId, drTeamLead.LeaderEmployeeId, Comments, False, True, ApprovalPathSequence)
                    Me.UpdateInApprovalInExpenseSheet(AccountEmployeeExpenseSheetId, "Approved")
                    If drTeamLead.ApprovalPathSequence = drTeamLead.MaxApprovalPathSequence Then
                        Me.LockTeamLeadExpenseEntry(drTeamLead.AccountExpenseEntryId, True)
                        Me.UpdateMasterApprovedByDetail(AccountEmployeeExpenseSheetId)
                        ExpenseSheetBLL.UpdateApprovedByEmployeeId(drTeamLead.LeaderEmployeeId, AccountEmployeeExpenseSheetId)
                    End If
                    UpdateIsEmailSendByAccountExpenseEntryId(drTeamLead.AccountExpenseEntryId, False)
                    TLExpenseEntryId.Add(drTeamLead.AccountExpenseEntryId)
                    If TCount = dtTeamLead.Rows.Count Then
                        Me.SendExpenseApprovedEMail(AccountEmployeeExpenseSheetId, Comments, TLExpenseEntryId)
                    End If
                ElseIf Chk = False And drTeamLead.Item("IsApproved") = True Then
                    Me.AddExpenseApproval(drTeamLead.AccountExpenseEntryId, drTeamLead.AccountApprovalTypeId, drTeamLead.AccountApprovalPathId, drTeamLead.LeaderEmployeeId, Comments, False, True, ApprovalPathSequence)
                    Me.UpdateInApprovalInExpenseSheet(AccountEmployeeExpenseSheetId, "Approved")
                    If drTeamLead.ApprovalPathSequence = drTeamLead.MaxApprovalPathSequence Then
                        Me.LockTeamLeadExpenseEntry(drTeamLead.AccountExpenseEntryId, True)
                        Me.UpdateMasterApprovedByDetail(AccountEmployeeExpenseSheetId)
                        ExpenseSheetBLL.UpdateApprovedByEmployeeId(drTeamLead.LeaderEmployeeId, AccountEmployeeExpenseSheetId)
                    End If
                    UpdateIsEmailSendByAccountExpenseEntryId(drTeamLead.AccountExpenseEntryId, False)
                    TLExpenseEntryId.Add(drTeamLead.AccountExpenseEntryId)
                    If TCount = dtTeamLead.Rows.Count Then
                        Me.SendExpenseApprovedEMail(AccountEmployeeExpenseSheetId, Comments, TLExpenseEntryId)
                    End If

                End If
                TCount += 1
            Next
        End If
    End Sub
    ''' <summary>
    ''' Bulk expense entry approval entries for rejected of specified AccountEmployeeExpenseSheetId, chk, Comments, ApprovalType,
    ''' ExpenseEntryAccountEmployeeId, IncludeDateRange, ExpenseEntryStartDate, ExpenseEntryEndDate, AccountEmployeeId
    ''' </summary>
    ''' <param name="AccountEmployeeExpenseSheetId"></param>
    ''' <param name="chk"></param>
    ''' <param name="Comments"></param>
    ''' <param name="ApprovalType"></param>
    ''' <param name="ExpenseEntryAccountEmployeeId"></param>
    ''' <param name="IncludeDateRange"></param>
    ''' <param name="ExpenseEntryStartDate"></param>
    ''' <param name="ExpenseEntryEndDate"></param>
    ''' <param name="AccountEmployeeId"></param>
    ''' <remarks></remarks>
    Public Sub BulkExpenseEntryApprovalEntriesForRejectedForMobile(ByVal AccountEmployeeExpenseSheetId As Guid, ByVal chk As CheckBox, ByVal Comments As String,
    ByVal ApprovalType As String, ByVal ExpenseEntryAccountEmployeeId As Integer, ByVal IncludeDateRange As Boolean,
    ByVal ExpenseEntryStartDate As Date, ByVal ExpenseEntryEndDate As Date, ByVal AccountEmployeeId As System.Nullable(Of Integer), ByVal ApprovalPathSequence As Integer)

        If ApprovalType = "TeamLead" Then
            RejectTeamLeadEntries(AccountEmployeeExpenseSheetId, chk, Comments, ExpenseEntryAccountEmployeeId, IncludeDateRange, ExpenseEntryStartDate, ExpenseEntryEndDate, AccountEmployeeId, ApprovalPathSequence)
        End If
        If ApprovalType = "ProjectManager" Then
            RejectProjectManagerEntries(AccountEmployeeExpenseSheetId, chk, Comments, ExpenseEntryAccountEmployeeId, IncludeDateRange, ExpenseEntryStartDate, ExpenseEntryEndDate, AccountEmployeeId, ApprovalPathSequence)
        End If
        If ApprovalType = "SpecificEmployee" Then
            RejectSpecificEmployeeEntries(AccountEmployeeExpenseSheetId, chk, Comments, ExpenseEntryAccountEmployeeId, IncludeDateRange, ExpenseEntryStartDate, ExpenseEntryEndDate, AccountEmployeeId, ApprovalPathSequence)
        End If
        If ApprovalType = "SpecificExternalUser" Then
            RejectSpecificExternalUserEntries(AccountEmployeeExpenseSheetId, chk, Comments, ExpenseEntryAccountEmployeeId, IncludeDateRange, ExpenseEntryStartDate, ExpenseEntryEndDate, AccountEmployeeId, ApprovalPathSequence)
        End If
        If ApprovalType = "EmployeeManager" Then
            RejectEmployeeManagerEntries(AccountEmployeeExpenseSheetId, chk, Comments, ExpenseEntryAccountEmployeeId, IncludeDateRange, ExpenseEntryStartDate, ExpenseEntryEndDate, AccountEmployeeId, ApprovalPathSequence)
        End If
    End Sub
    Public Function GetApprovalCount(ByVal ApproverEmployeeId As Integer) As Integer
        Dim _vueAccountExpenseEntryApprovalPendingTableAdapter As New vueAccountExpenseEntryApprovalPendingSummaryTableAdapter()
        Return _vueAccountExpenseEntryApprovalPendingTableAdapter.GetExpenseEntryApprovalCount(ApproverEmployeeId)
    End Function

End Class


