Imports Microsoft.VisualBasic
Imports AccountTimeExpenseBillingTableAdapters
Imports TimeLiveDataSetTableAdapters.IdentityQueryTableAdapter
Imports AccountEmployeeTimeEntryforBillingTableAdapters
Imports AccountExpenseEntryforBillingTableAdapters
Imports AccountTimeExpenseBillingReportTableAdapters
Imports AccountTimeExpenseBilling
''' <summary>
''' This class perform database operations for AccountTimeExpenseBilling table. AccountTimeExpenseBilling table 
''' store records for Account Time Expense Billing data 
''' </summary>
''' <remarks>AccountTimeExpenseBilling Business Layer class</remarks>
<System.ComponentModel.DataObject()> _
Public Class AccountTimeExpenseBillingBLL
    Dim strCacheKey As String
    Private _AccountEmployeeTimeEntryForParentViewTableAdapter As AccountEmployeeTimeEntryForParentViewTableAdapter = Nothing
    Private _vueAccountTimeExpenseBillingTimesheetTableAdapter As vueAccountTimeExpenseBillingTimesheetTableAdapter = Nothing
    Private _AccountTimeExpenseBillingTableAdapter As AccountTimeExpenseBillingTableAdapter = Nothing
    Private _vueAccountTimeExpenseBillingTableAdapter As vueAccountTimeExpenseBillingTableAdapter = Nothing
    Private _AccountTimeExpenseBillingTimesheetTableAdapter As AccountTimeExpenseBillingTimesheetTableAdapter = Nothing
    Private _vueAccountTimeExpenseBillingExpenseTableAdapter As vueAccountTimeExpenseBillingExpenseTableAdapter = Nothing
    Private _AccountTimeExpenseBillingExpenseTableAdapter As AccountTimeExpenseBillingExpenseTableAdapter = Nothing
    Private _AccountEmployeeTimeEntryTableAdapter As AccountEmployeeTimeEntryTableAdapter = Nothing
    Private _AccountExpenseEntryTableAdapter As AccountExpenseEntryTableAdapter = Nothing
    Private _AccountTimeExpenseBillingReportTableAdapter As AccountTimeExpenseBillingReportTableAdapter = Nothing
    Private _AccountTimeExpenseBillingTimesheetReportTableAdapter As AccountTimeExpenseBillingTimesheetReportTableAdapter = Nothing
    Private _AccountTimeExpenseBillingExpenseReportTableAdapter As AccountTimeExpenseBillingExpenseReportTableAdapter = Nothing
    Private _vueAccountTimeExpenseBillingTimesheetEditTableAdapter As ViewAccountTimeExpenseBillingTimesheetforEditTableAdapter
    Private _vueAccountTimeExpenseBillingExpenseEditTableAdapter As vueAccountTimeExpenseBillingExpenseForEditTableAdapter
    ''' <summary>
    ''' Return Adapter object of AccountTimeExpenseBillingTableAdapter table adapter
    ''' </summary>
    ''' <value></value>
    ''' <returns>AccountTimeExpenseBillingTableAdapter table adapter</returns>
    ''' <remarks></remarks>
    Protected ReadOnly Property Adapter() As AccountTimeExpenseBillingTableAdapter
        Get
            If _AccountTimeExpenseBillingTableAdapter Is Nothing Then
                _AccountTimeExpenseBillingTableAdapter = New AccountTimeExpenseBillingTableAdapter()
            End If

            Return _AccountTimeExpenseBillingTableAdapter
        End Get
    End Property
    Protected ReadOnly Property Adapters() As vueAccountTimeExpenseBillingTableAdapter
        Get
            If _vueAccountTimeExpenseBillingTableAdapter Is Nothing Then
                _vueAccountTimeExpenseBillingTableAdapter = New vueAccountTimeExpenseBillingTableAdapter()
            End If

            Return _vueAccountTimeExpenseBillingTableAdapter
        End Get
    End Property
    Protected ReadOnly Property Adapterss() As vueAccountTimeExpenseBillingTimesheetTableAdapter
        Get
            If _vueAccountTimeExpenseBillingTimesheetTableAdapter Is Nothing Then
                _vueAccountTimeExpenseBillingTimesheetTableAdapter = New vueAccountTimeExpenseBillingTimesheetTableAdapter()
            End If

            Return _vueAccountTimeExpenseBillingTimesheetTableAdapter
        End Get
    End Property
    Protected ReadOnly Property AccountTimeExpenseBillingTimesheetTableAdapter() As AccountTimeExpenseBillingTimesheetTableAdapter
        Get
            If _AccountTimeExpenseBillingTimesheetTableAdapter Is Nothing Then
                _AccountTimeExpenseBillingTimesheetTableAdapter = New AccountTimeExpenseBillingTimesheetTableAdapter()
            End If

            Return _AccountTimeExpenseBillingTimesheetTableAdapter
        End Get
    End Property
    Protected ReadOnly Property vueAccountTimeExpenseBillingExpenseTableAdapter() As vueAccountTimeExpenseBillingExpenseTableAdapter
        Get
            If _vueAccountTimeExpenseBillingExpenseTableAdapter Is Nothing Then
                _vueAccountTimeExpenseBillingExpenseTableAdapter = New vueAccountTimeExpenseBillingExpenseTableAdapter()
            End If

            Return _vueAccountTimeExpenseBillingExpenseTableAdapter
        End Get
    End Property
    Protected ReadOnly Property AccountTimeExpenseBillingExpenseTableAdapter() As AccountTimeExpenseBillingExpenseTableAdapter
        Get
            If _AccountTimeExpenseBillingExpenseTableAdapter Is Nothing Then
                _AccountTimeExpenseBillingExpenseTableAdapter = New AccountTimeExpenseBillingExpenseTableAdapter()
            End If

            Return _AccountTimeExpenseBillingExpenseTableAdapter
        End Get
    End Property
    Protected ReadOnly Property AccountEmployeeTimeEntryTableAdapter() As AccountEmployeeTimeEntryTableAdapter
        Get
            If _AccountEmployeeTimeEntryTableAdapter Is Nothing Then
                _AccountEmployeeTimeEntryTableAdapter = New AccountEmployeeTimeEntryTableAdapter()
            End If

            Return _AccountEmployeeTimeEntryTableAdapter
        End Get
    End Property
    Protected ReadOnly Property AccountExpenseEntryTableAdapter() As AccountExpenseEntryTableAdapter
        Get
            If _AccountExpenseEntryTableAdapter Is Nothing Then
                _AccountExpenseEntryTableAdapter = New AccountExpenseEntryTableAdapter()
            End If

            Return _AccountExpenseEntryTableAdapter
        End Get
    End Property
    Protected ReadOnly Property AccountTimeExpenseBillingReportTableAdapter() As AccountTimeExpenseBillingReportTableAdapter
        Get
            If _AccountTimeExpenseBillingReportTableAdapter Is Nothing Then
                _AccountTimeExpenseBillingReportTableAdapter = New AccountTimeExpenseBillingReportTableAdapter()
            End If

            Return _AccountTimeExpenseBillingReportTableAdapter
        End Get
    End Property
    Protected ReadOnly Property AccountTimeExpenseBillingTimesheetReportTableAdapter() As AccountTimeExpenseBillingTimesheetReportTableAdapter
        Get
            If _AccountTimeExpenseBillingTimesheetReportTableAdapter Is Nothing Then
                _AccountTimeExpenseBillingTimesheetReportTableAdapter = New AccountTimeExpenseBillingTimesheetReportTableAdapter()
            End If

            Return _AccountTimeExpenseBillingTimesheetReportTableAdapter
        End Get
    End Property
    Protected ReadOnly Property AccountTimeExpenseBillingExpenseReportTableAdapter() As AccountTimeExpenseBillingExpenseReportTableAdapter
        Get
            If _AccountTimeExpenseBillingExpenseReportTableAdapter Is Nothing Then
                _AccountTimeExpenseBillingExpenseReportTableAdapter = New AccountTimeExpenseBillingExpenseReportTableAdapter()
            End If

            Return _AccountTimeExpenseBillingExpenseReportTableAdapter
        End Get
    End Property
    Protected ReadOnly Property vueAccountTimeExpenseBillingTimesheetEditTableAdapter() As ViewAccountTimeExpenseBillingTimesheetforEditTableAdapter
        Get
            If _vueAccountTimeExpenseBillingTimesheetEditTableAdapter Is Nothing Then
                _vueAccountTimeExpenseBillingTimesheetEditTableAdapter = New ViewAccountTimeExpenseBillingTimesheetforEditTableAdapter()
            End If

            Return _vueAccountTimeExpenseBillingTimesheetEditTableAdapter
        End Get
    End Property
    Protected ReadOnly Property vueAccountTimeExpenseBillingExpenseEditTableAdapter() As vueAccountTimeExpenseBillingExpenseForEditTableAdapter
        Get
            If _vueAccountTimeExpenseBillingExpenseEditTableAdapter Is Nothing Then
                _vueAccountTimeExpenseBillingExpenseEditTableAdapter = New vueAccountTimeExpenseBillingExpenseForEditTableAdapter()
            End If

            Return _vueAccountTimeExpenseBillingExpenseEditTableAdapter
        End Get
    End Property
    ''' <summary>
    ''' Returns all AccountTimeExpenseBilling records
    ''' </summary>
    ''' <returns>Returns AccountTimeExpenseBilling datatable</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountTimeExpenseBilling() As AccountTimeExpenseBilling.AccountTimeExpenseBillingDataTable
        Return Adapter.GetData
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountTimeExpenseBillingByAccountId(ByVal AccountId As Integer) As AccountTimeExpenseBilling.AccountTimeExpenseBillingDataTable
        GetAccountTimeExpenseBillingByAccountId = Adapter.GetDataByAccountId(AccountId)

        UIUtilities.FixTableForNoRecords(GetAccountTimeExpenseBillingByAccountId)

        Return GetAccountTimeExpenseBillingByAccountId
    End Function

    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountTimeExpenseBillingByCheckInvoiceNo(ByVal AccountId As Integer, ByVal InvoiceNumber As String) As AccountTimeExpenseBilling.vueAccountTimeExpenseBillingDataTable
        Return Adapters.GetDataByCheckInvoiceNumber(AccountId, InvoiceNumber)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetvueAccountTimeExpenseBillingByAccountId(ByVal AccountId As Integer) As AccountTimeExpenseBilling.vueAccountTimeExpenseBillingDataTable
        GetvueAccountTimeExpenseBillingByAccountId = Adapters.GetDataByAccountTimeExpenseBillingByAccountId(AccountId)

        UIUtilities.FixTableForNoRecords(GetvueAccountTimeExpenseBillingByAccountId)

        Return GetvueAccountTimeExpenseBillingByAccountId
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetvueAccountTimeExpenseBillingTimesheetByAccountClientIdForParentTask(ByVal AccountClientId As Integer, ByVal BillingCycleStartDate As Date, ByVal BillingCycleEndDate As Date, ByVal AccountProjectId As Integer, ByVal IsBillable As String, ByVal ParentAccountProjectTaskId As Integer) As AccountTimeExpenseBilling.vueAccountTimeExpenseBillingTimesheetDataTable
        GetvueAccountTimeExpenseBillingTimesheetByAccountClientIdForParentTask = Adapterss.GetDataByAccountClientIdForParentTask(AccountClientId, BillingCycleStartDate, BillingCycleEndDate, AccountProjectId, IsBillable, ParentAccountProjectTaskId)
        'Return AddBlankRowsInDataTable(GetvueAccountTimeExpenseBillingTimesheetByAccountClientId)
        Return GetvueAccountTimeExpenseBillingTimesheetByAccountClientIdForParentTask
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetvueAccountTimeExpenseBillingTimesheetByAccountClientIdWithTimeEntryGroup(ByVal AccountClientId As Integer, ByVal BillingCycleStartDate As Date, ByVal BillingCycleEndDate As Date, ByVal AccountProjectId As Integer, ByVal IsBillable As String, ByVal ParentAccountProjectTaskId As Integer) As AccountTimeExpenseBilling.vueAccountTimeExpenseBillingTimesheetDataTable
        If DBUtilities.GetSessionAccountId <> 7354 Then
            GetvueAccountTimeExpenseBillingTimesheetByAccountClientIdWithTimeEntryGroup = Adapterss.GetDataByAccountClientIdAndGroupByTimeEntry(AccountClientId, BillingCycleStartDate, BillingCycleEndDate, AccountProjectId, IsBillable, ParentAccountProjectTaskId)
        Else
            GetvueAccountTimeExpenseBillingTimesheetByAccountClientIdWithTimeEntryGroup = Adapterss.GetDataByAccountClientIdAndGroupByTaskAndTimesheetDescription(AccountClientId, BillingCycleStartDate, BillingCycleEndDate, AccountProjectId, IsBillable, ParentAccountProjectTaskId)
        End If
        'GetvueAccountTimeExpenseBillingTimesheetByAccountClientIdWithTimeEntryGroup = Adapterss.GetDataByAccountClientIdAndGroupByTimeEntry(AccountClientId, BillingCycleStartDate, BillingCycleEndDate, AccountProjectId, IsBillable, ParentAccountProjectTaskId)
        'Return AddBlankRowsInDataTable(GetvueAccountTimeExpenseBillingTimesheetByAccountClientId)
        Return GetvueAccountTimeExpenseBillingTimesheetByAccountClientIdWithTimeEntryGroup
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetvueAccountTimeExpenseBillingTimesheetByAccountClientId(ByVal AccountClientId As Integer, ByVal BillingCycleStartDate As Date, ByVal BillingCycleEndDate As Date, ByVal AccountProjectId As Integer, ByVal IsBillable As String, ByVal ParentAccountProjectTaskId As Integer) As AccountTimeExpenseBilling.vueAccountTimeExpenseBillingTimesheetDataTable
        GetvueAccountTimeExpenseBillingTimesheetByAccountClientId = Adapterss.GetDataByAccountClientId(AccountClientId, BillingCycleStartDate, BillingCycleEndDate, AccountProjectId, IsBillable, ParentAccountProjectTaskId)
        'Return AddBlankRowsInDataTable(GetvueAccountTimeExpenseBillingTimesheetByAccountClientId)
        Return GetvueAccountTimeExpenseBillingTimesheetByAccountClientId
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetvueAccountTimeExpenseBillingByAccountClientId(ByVal AccountClientId As Integer, ByVal BillingCycleStartDate As Date, ByVal BillingCycleEndDate As Date, ByVal AccountProjectId As Integer, ByVal Billed As String) As AccountTimeExpenseBilling.vueAccountTimeExpenseBillingTimesheetDataTable
        Dim _vueAccountTimeExpenseBillingTimesheetTableAdapter As New vueAccountTimeExpenseBillingTimesheetTableAdapter
        GetvueAccountTimeExpenseBillingByAccountClientId = _vueAccountTimeExpenseBillingTimesheetTableAdapter.GetvueAccountTimeExpenseBillingByAccountClientId(AccountClientId, BillingCycleStartDate, BillingCycleEndDate, AccountProjectId, Billed)
        Return GetvueAccountTimeExpenseBillingByAccountClientId
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetvueAccountTimeExpenseBillingTimesheetByAccountTimeExpenseBillingId(ByVal AccountTimeExpenseBillingId As Guid, ByVal IsPopulate As Boolean, ByVal IsParent As Boolean) As AccountTimeExpenseBilling.ViewAccountTimeExpenseBillingTimesheetforEditDataTable
        GetvueAccountTimeExpenseBillingTimesheetByAccountTimeExpenseBillingId = vueAccountTimeExpenseBillingTimesheetEditTableAdapter.GetDataByAccountTimeExpenseBillingId(AccountTimeExpenseBillingId)
        Return AddBlankRowsInDataTable(GetvueAccountTimeExpenseBillingTimesheetByAccountTimeExpenseBillingId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetvueAccountTimeExpenseBillingTimesheetByAccountTimeExpenseBillingIdForCalculation(ByVal AccountTimeExpenseBillingId As Guid, ByVal IsPopulate As Boolean) As AccountTimeExpenseBilling.ViewAccountTimeExpenseBillingTimesheetforEditDataTable
        GetvueAccountTimeExpenseBillingTimesheetByAccountTimeExpenseBillingIdForCalculation = vueAccountTimeExpenseBillingTimesheetEditTableAdapter.GetDataByAccountTimeExpenseBillingId(AccountTimeExpenseBillingId)
        Return GetvueAccountTimeExpenseBillingTimesheetByAccountTimeExpenseBillingIdForCalculation
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountEmployeeTimeEntryByParentAccountProjectTaskId(ByVal AccountProjectId As Integer, ByVal ParentAccountProjectTaskId As Integer, ByVal BillingCycleStartDate As Date, ByVal BillingCycleEndDate As Date) As AccountTimeExpenseBilling.AccountEmployeeTimeEntryForParentViewDataTable
        Dim _AccountEmployeeTimeEntryForParentViewTableAdapter As New AccountEmployeeTimeEntryForParentViewTableAdapter
        GetAccountEmployeeTimeEntryByParentAccountProjectTaskId = _AccountEmployeeTimeEntryForParentViewTableAdapter.GetDataByParentAccountProjectTaskId(AccountProjectId, ParentAccountProjectTaskId, BillingCycleStartDate, BillingCycleEndDate)
        Return GetAccountEmployeeTimeEntryByParentAccountProjectTaskId
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetvueAccountTimeExpenseBillingExpenseByAccountClientId(ByVal AccountClientId As Integer, ByVal BillingCycleStartDate As Date, ByVal BillingCycleEndDate As Date, ByVal AccountProjectId As Integer, ByVal IsBillable As String) As AccountTimeExpenseBilling.vueAccountTimeExpenseBillingExpenseDataTable
        Return vueAccountTimeExpenseBillingExpenseTableAdapter.GetDataByAccountClientId(AccountClientId, BillingCycleStartDate, BillingCycleEndDate, AccountProjectId, IsBillable)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetvueAccountTimeExpenseBillingExpenseByAccountClientIdWithExpenseEntryGroup(ByVal AccountClientId As Integer, ByVal BillingCycleStartDate As Date, ByVal BillingCycleEndDate As Date, ByVal AccountProjectId As Integer, ByVal IsBillable As String) As AccountTimeExpenseBilling.vueAccountTimeExpenseBillingExpenseDataTable
        Return vueAccountTimeExpenseBillingExpenseTableAdapter.GetDataByAccountClientIdAndGroupByExpenseEntry(AccountClientId, BillingCycleStartDate, BillingCycleEndDate, AccountProjectId, IsBillable)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetvueAccountTimeExpenseBillingExpenseByAccountTimeExpenseBillingId(ByVal AccountTimeExpenseBillingId As Guid) As AccountTimeExpenseBilling.vueAccountTimeExpenseBillingExpenseForEditDataTable

        GetvueAccountTimeExpenseBillingExpenseByAccountTimeExpenseBillingId = vueAccountTimeExpenseBillingExpenseEditTableAdapter.GetDataByAccountTimeExpenseBillingId(AccountTimeExpenseBillingId)

        Return AddBlankRowsInDataTableExpense(GetvueAccountTimeExpenseBillingExpenseByAccountTimeExpenseBillingId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountEmployeeTimeEntryByAccountTimeExpenseBillingTimesheeetId(ByVal AccountProjectId As Integer, ByVal AccountProjectTaskId As Integer, ByVal AccountTimeExpenseBillingTimesheetId As Integer, ByVal TimeEntryStartDate As DateTime, ByVal TimeEntryEndDate As DateTime) As AccountEmployeeTimeEntryforBilling.AccountEmployeeTimeEntryDataTable

        GetAccountEmployeeTimeEntryByAccountTimeExpenseBillingTimesheeetId = AccountEmployeeTimeEntryTableAdapter.GetDataByAccountProjectIdandAccountProjectTaskId(AccountProjectId, AccountProjectTaskId, TimeEntryStartDate, TimeEntryEndDate)

        UIUtilities.FixTableForNoRecords(GetAccountEmployeeTimeEntryByAccountTimeExpenseBillingTimesheeetId)

        Return GetAccountEmployeeTimeEntryByAccountTimeExpenseBillingTimesheeetId
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountTimeExpenseBillingByAccountIdAndIsDisabled(ByVal AccountId As Integer, ByVal AccountTimeExpenseBillingId As Guid) As AccountTimeExpenseBilling.AccountTimeExpenseBillingDataTable
        Return Adapter.GetDataByAccountIdandIsDisabled(AccountId, AccountTimeExpenseBillingId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountTimeExpenseBillingByAccountIdAndAccountTimeExpenseBillingId(ByVal AccountId As Integer, ByVal AccountTimeExpenseBillingId As Guid) As AccountTimeExpenseBilling.AccountTimeExpenseBillingDataTable
        Return Adapter.GetDataByAccountTimeExpenseBillingIdandAccountId(AccountId, AccountTimeExpenseBillingId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountTimeExpenseBillingByAccountTimeExpenseBillingId(ByVal AccountTimeExpenseBillingId As Guid) As AccountTimeExpenseBilling.AccountTimeExpenseBillingDataTable
        Return Adapter.GetDataByAccountTimeExpenseBillingId(AccountTimeExpenseBillingId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountTimeExpenseBillingTimesheetByAccountTimeExpenseBillingIdAndAccountProjectId(ByVal AccountTimeExpenseBillingId As Guid, ByVal AccountProjectId As Integer, ByVal AccountProjectTaskId As Integer) As AccountTimeExpenseBilling.AccountTimeExpenseBillingTimesheetDataTable
        Return AccountTimeExpenseBillingTimesheetTableAdapter.GetDataByAccountTimeExpenseBillingIdAndAccountProjectId(AccountTimeExpenseBillingId, AccountProjectId, AccountProjectTaskId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountTimeExpenseBillingTimesheetByAccountTimeExpenseBillingId(ByVal AccountTimeExpenseBillingId As Guid) As AccountTimeExpenseBilling.AccountTimeExpenseBillingTimesheetDataTable
        Return AccountTimeExpenseBillingTimesheetTableAdapter.GetDataByAccountTimeExpenseBillingId(AccountTimeExpenseBillingId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountTimeExpenseBillingExpenseByAccountTimeExpenseBillingId(ByVal AccountTimeExpenseBillingId As Guid) As AccountTimeExpenseBilling.AccountTimeExpenseBillingExpenseDataTable
        Return AccountTimeExpenseBillingExpenseTableAdapter.GetDataByAccountTimeExpenseBillingId(AccountTimeExpenseBillingId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetEmployeeTimeEntryByAccountTimeExpenseBillingTimesheeetId(ByVal AccountTimeExpenseBillingTimesheetId As Guid) As AccountEmployeeTimeEntryforBilling.AccountEmployeeTimeEntryDataTable
        Return AccountEmployeeTimeEntryTableAdapter.GetDataByTimeEntryByAccountTimeExpenseBillingTimesheetId(AccountTimeExpenseBillingTimesheetId)
    End Function
    '<System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    'Public Function GetAccountTimeExpenseBillingTimesheetByAccountTimeExpenseBillingIdBlank(ByVal AccountTimeExpenseBillingId As Guid) As AccountTimeExpenseBilling.AccountTimeExpenseBillingTimesheetDataTable
    '   Return AddBlankRowsInDataTable(AccountTimeExpenseBillingTimesheetTableAdapter.GetDataByAccountTimeExpenseBillingId(AccountTimeExpenseBillingId))
    'End Function
    '<System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    'Public Function GetAccountTimeExpenseBillingTimesheetByAccountTimeExpenseBillingTimesheetId(ByVal AccountTimeExpenseBillingTimesheetId As Guid) As AccountTimeExpenseBilling.AccountTimeExpenseBillingTimesheetDataTable
    '    Return AccountTimeExpenseBillingTimesheetTableAdapter.GetDataByAccountTimeExpenseBillingTimesheetId(AccountTimeExpenseBillingTimesheetId)
    'End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountEmployeeTimeEntryByAccountTimeExpenseBillingTimesheetId(ByVal AccountProjectId As Integer, ByVal AccountProjectTaskId As Integer, ByVal TimeEntryStartDate As DateTime, ByVal TimeEntryEndDate As DateTime) As AccountEmployeeTimeEntryforBilling.AccountEmployeeTimeEntryDataTable
        Return AccountEmployeeTimeEntryTableAdapter.GetDataByAccountProjectIdandAccountProjectTaskId(AccountProjectId, AccountProjectTaskId, TimeEntryStartDate, TimeEntryEndDate)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountExpenseEntryByAccountProjectIdandAccountExpenseId(ByVal AccountProjectId As Integer, ByVal AccountExpenseId As Integer, ByVal ExpenseEntryStartDate As DateTime, ByVal ExpenseEntryEndDate As DateTime) As AccountExpenseEntryforBilling.AccountExpenseEntryDataTable
        Return AccountExpenseEntryTableAdapter.GetDataByAccountProjectIdandAccountExpenseId(AccountProjectId, AccountExpenseId, ExpenseEntryStartDate, ExpenseEntryEndDate)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetvueAccountExpensesWithTaxCodeByAccountIdAndAccountTaxCodeId(ByVal AccountTaxCodeId As Integer) As AccountExpenseEntryforBilling.vueAccountExpenseWithTaxCodeDataTable
        Dim _vueAccountExpenseWithTaxCodeTableAdapter As New vueAccountExpenseWithTaxCodeTableAdapter
        GetvueAccountExpensesWithTaxCodeByAccountIdAndAccountTaxCodeId = _vueAccountExpenseWithTaxCodeTableAdapter.GetDataByAccountIdandAccountTaxCodeId(AccountTaxCodeId)
        Return GetvueAccountExpensesWithTaxCodeByAccountIdAndAccountTaxCodeId
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountTimeExpenseBillingWithTaxCodeByAccountIdAndAccountTaxCodeId(ByVal AccountId As Integer, ByVal AccountTaxCodeId As Integer) As AccountExpenseEntryforBilling.AccountTaxCodeDataTable
        Dim _AccountTimeExpenseBillingWithTaxCodeTableAdapter As New AccountTaxCodeTableAdapter
        GetAccountTimeExpenseBillingWithTaxCodeByAccountIdAndAccountTaxCodeId = _AccountTimeExpenseBillingWithTaxCodeTableAdapter.GetDataByAccountIdandAccountTaxCodeId(AccountId, AccountTaxCodeId)
        Return GetAccountTimeExpenseBillingWithTaxCodeByAccountIdAndAccountTaxCodeId
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountTimeExpenseBillingReportByInvoiceNo(ByVal AccountId As Integer, ByVal AccountTimeExpenseBillingId As Guid) As AccountTimeExpenseBillingReport.AccountTimeExpenseBillingReportDataTable
        Return AccountTimeExpenseBillingReportTableAdapter.GetDataByAccountIdandAccountTimeExpenseBillingId(AccountId, AccountTimeExpenseBillingId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountTimeExpenseBillingReportByAccountIdAndAccountTimeExpenseBillingId(ByVal AccountId As Integer, ByVal AccountTimeExpenseBillingId As Guid) As AccountTimeExpenseBillingReport.AccountTimeExpenseBillingReportDataTable
        Return AccountTimeExpenseBillingReportTableAdapter.GetDataByAccountIdandAccountTimeExpenseBillingId(AccountId, AccountTimeExpenseBillingId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetvueAccountTimeExpenseBillingReportByAccountIdAndAccountTimeExpenseBillingId(ByVal AccountId As Integer, ByVal AccountTimeExpenseBillingId As Guid) As AccountTimeExpenseBillingReport.vueAccountTimeExpenseBillingReportDataTable
        Dim _vueAccountTimeExpenseBillingReprotTableAdapter As New vueAccountTimeExpenseBillingReportTableAdapter
        Return _vueAccountTimeExpenseBillingReprotTableAdapter.GetDataByAccountIdAndAccountTimeExpenseBillingId(AccountId, AccountTimeExpenseBillingId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountTimeExpenseBillingExpenseReportByAccountIdAndAccountTimeExpenseBillingId(ByVal AccountId As Integer, ByVal AccountTimeExpenseBillingId As Guid) As AccountTimeExpenseBillingReport.AccountTimeExpenseBillingExpenseReportDataTable
        Return AccountTimeExpenseBillingExpenseReportTableAdapter.GetDataByAccountIdandAccountTimeExpenseBillingId(AccountId, AccountTimeExpenseBillingId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetDataByAccountIdAndEmployeesForTimeBillingWorksheet(ByVal AccountId As Integer, ByVal AccountClientId As Integer, ByVal AccountProjectId As Integer, ByVal AccountProjectTaskId As Integer, ByVal TimeEntryStartDate As Date, ByVal TimeEntryEndDate As Date, ByVal Billed As String, ByVal IncludeDateRange As Boolean) As AccountTimeExpenseBilling.vueTimeBillingWorksheetDataTable
        Dim _vueTimeBillingWorksheetTableAdapter As New vueTimeBillingWorksheetTableAdapter
        Return _vueTimeBillingWorksheetTableAdapter.GetDataByAccountIdAndEmployeesForTimeBillingWorksheet(AccountId, AccountProjectId, AccountProjectTaskId, AccountClientId, IncludeDateRange, TimeEntryStartDate, TimeEntryEndDate, Billed)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetDataByAccountIdAndEmployeesForExpenseBillingWorksheet(ByVal AccountId As Integer, ByVal AccountClientId As Integer, ByVal AccountProjectId As Integer, ByVal AccountExpenseId As Integer, ByVal AccountExpenseTypeId As Integer, ByVal ExpenseEntryStartDate As Date, ByVal ExpenseEntryEndDate As Date, ByVal Billed As String, ByVal IncludeDateRange As Boolean) As AccountTimeExpenseBilling.vueExpenseBillingWorksheetDataTable
        Dim _vueExpenseBillingWorksheetTableAdapter As New vueExpenseBillingWorksheetTableAdapter
        Return _vueExpenseBillingWorksheetTableAdapter.GetDataByAccountIdAndEmployeesForExpenseBillingWorksheet(AccountId, AccountClientId, AccountProjectId, AccountExpenseId, AccountExpenseTypeId, IncludeDateRange, ExpenseEntryStartDate, ExpenseEntryEndDate, Billed)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountTimeExpenseBillingInvoiceNo(ByVal AccountId As Integer) As AccountTimeExpenseBilling.DataTable1DataTable
        Dim _DataTable1TableAdapter As New DataTable1TableAdapter
        GetAccountTimeExpenseBillingInvoiceNo = _DataTable1TableAdapter.GetDataByLastInvoiceNo(AccountId)
        Return GetAccountTimeExpenseBillingInvoiceNo
    End Function
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="AccountId"></param>
    ''' <param name="AccountClientId"></param>
    ''' <param name="AccountProjectId"></param>
    ''' <param name="AccountCurrencyId"></param>
    ''' <param name="Description"></param>
    ''' <param name="BillingCycleStartDate"></param>
    ''' <param name="BillingCycleEndDate"></param>
    ''' <param name="InvoiceDate"></param>
    ''' <param name="InvoiceNo"></param>
    ''' <param name="PONumber"></param>
    ''' <param name="SubTotal"></param>
    ''' <param name="TaxCode1"></param>
    ''' <param name="TaxCode2"></param>
    ''' <param name="GrandTotal"></param>
    ''' <param name="IsPaid"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, True)> _
    Public Function AddAccountTimeExpenseBilling(ByVal AccountId As Integer, ByVal AccountClientId As Integer, _
    ByVal AccountProjectId As Integer, ByVal AccountCurrencyId As Integer, ByVal Description As String, _
    ByVal BillingCycleStartDate As Date, ByVal BillingCycleEndDate As Date, ByVal InvoiceDate As Date, _
    ByVal InvoiceNo As String, ByVal PONumber As String, ByVal SubTotal As Double, ByVal TaxCode1 As Double, _
    ByVal TaxCode2 As Double, ByVal GrandTotal As Double, ByVal IsPaid As Boolean, ByVal Terms As String, ByVal BankDetails As String, ByVal ParentAccountProjectTaskId As Integer, _
    ByVal GroupTimesheetBillingListBy As String, ByVal GroupExpenseBillingListBy As String) As Boolean

        _AccountTimeExpenseBillingTableAdapter = New AccountTimeExpenseBillingTableAdapter

        Dim dtAccountTimeExpenseBilling As New AccountTimeExpenseBilling.AccountTimeExpenseBillingDataTable
        Dim drAccountTimeExpenseBilling As AccountTimeExpenseBilling.AccountTimeExpenseBillingRow = dtAccountTimeExpenseBilling.NewAccountTimeExpenseBillingRow
        Dim AccountTimeExpenseBillingId As Guid = System.Guid.NewGuid

        With drAccountTimeExpenseBilling
            .AccountTimeExpenseBillingId = AccountTimeExpenseBillingId
            .InvoiceNumber = InvoiceNo
            .PONumber = PONumber
            .InvoiceDate = InvoiceDate
            .AccountId = AccountId
            .AccountClientId = AccountClientId
            .AccountProjectId = AccountProjectId
            .AccountCurrencyId = AccountCurrencyId
            .Description = Description
            .BillingCycleStartDate = BillingCycleStartDate
            .BillingCycleEndDate = BillingCycleEndDate
            .CreatedOn = Now
            .CreatedByEmployeeId = DBUtilities.GetSessionAccountEmployeeId
            .ModifiedOn = Now
            .ModifiedByEmployeeId = DBUtilities.GetSessionAccountEmployeeId
            .IsDisabled = False
            .SubTotal = SubTotal
            .TaxCode1 = TaxCode1
            .TaxCode2 = TaxCode2
            .GrandTotal = GrandTotal
            .IsPaid = False
            .Terms = Terms
            .BankDetails = BankDetails
            .ParentAccountProjectTaskId = ParentAccountProjectTaskId
            .GroupTimesheetBillingListBy = GroupTimesheetBillingListBy
            .GroupExpenseBillingListBy = GroupExpenseBillingListBy
        End With

        dtAccountTimeExpenseBilling.AddAccountTimeExpenseBillingRow(drAccountTimeExpenseBilling)

        ' Add the new product
        Dim rowsAffected As Integer = Adapter.Update(dtAccountTimeExpenseBilling)
        System.Web.HttpContext.Current.Session.Add("AccountTimeExpenseBillingId", AccountTimeExpenseBillingId)
        ' Return true if precisely one row was inserted, otherwise false
        Return rowsAffected = 1

    End Function
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="Original_AccountTimeExpenseBillingId"></param>
    ''' <param name="AccountId"></param>
    ''' <param name="AccountClientId"></param>
    ''' <param name="AccountProjectId"></param>
    ''' <param name="AccountCurrencyId"></param>
    ''' <param name="Description"></param>
    ''' <param name="BillingCycleStartDate"></param>
    ''' <param name="BillingCycleEndDate"></param>
    ''' <param name="InvoiceDate"></param>
    ''' <param name="InvoiceNo"></param>
    ''' <param name="PONumber"></param>
    ''' <param name="SubTotal"></param>
    ''' <param name="TaxCode1"></param>
    ''' <param name="TaxCode2"></param>
    ''' <param name="GrandTotal"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)> _
    Public Function UpdateAccountTimeExpenseBilling(ByVal Original_AccountTimeExpenseBillingId As Guid, _
    ByVal AccountId As Integer, ByVal AccountClientId As Integer, ByVal AccountProjectId As Integer, _
    ByVal AccountCurrencyId As Integer, ByVal Description As String, ByVal BillingCycleStartDate As Date, _
    ByVal BillingCycleEndDate As Date, ByVal InvoiceDate As Date, ByVal InvoiceNo As String, ByVal PONumber As String, _
    ByVal SubTotal As Double, ByVal TaxCode1 As Double, ByVal TaxCode2 As Double, ByVal GrandTotal As Double, ByVal Terms As String, ByVal BankDetails As String, _
    ByVal ParentAccountProjectTaskId As Integer, ByVal GroupTimesheetBillingListBy As String, ByVal GroupExpenseBillingListBy As String) As Boolean

        ' Update the product record

        Dim dtAccountTimeExpenseBilling As AccountTimeExpenseBilling.AccountTimeExpenseBillingDataTable = Adapter.GetDataByAccountTimeExpenseBillingId(Original_AccountTimeExpenseBillingId)
        Dim drAccountTimeExpenseBilling As AccountTimeExpenseBilling.AccountTimeExpenseBillingRow = dtAccountTimeExpenseBilling.Rows(0)

        With drAccountTimeExpenseBilling
            .InvoiceNumber = InvoiceNo
            .AccountTimeExpenseBillingId = Original_AccountTimeExpenseBillingId
            .InvoiceDate = InvoiceDate
            .PONumber = PONumber
            .AccountId = AccountId
            .AccountClientId = AccountClientId
            .AccountProjectId = AccountProjectId
            .AccountCurrencyId = AccountCurrencyId
            .Description = Description
            .BillingCycleStartDate = BillingCycleStartDate
            .BillingCycleEndDate = BillingCycleEndDate
            .CreatedOn = Now
            .CreatedByEmployeeId = DBUtilities.GetSessionAccountEmployeeId
            .ModifiedOn = Now
            .ModifiedByEmployeeId = DBUtilities.GetSessionAccountEmployeeId
            .SubTotal = SubTotal
            .TaxCode1 = TaxCode1
            .TaxCode2 = TaxCode2
            .GrandTotal = GrandTotal
            .Terms = Terms
            .BankDetails = BankDetails
            .ParentAccountProjectTaskId = ParentAccountProjectTaskId
            .GroupTimesheetBillingListBy = GroupTimesheetBillingListBy
            .GroupExpenseBillingListBy = GroupExpenseBillingListBy
        End With

        Dim rowsAffected As Integer = Adapter.Update(dtAccountTimeExpenseBilling)

        ' Return true if precisely one row was updated, otherwise false
        Return rowsAffected = 1
    End Function
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="AccountTimeExpenseBillingId"></param>
    ''' <param name="AccountId"></param>
    ''' <param name="AccountProjectId"></param>
    ''' <param name="AccountProjectTaskId"></param>
    ''' <param name="Description"></param>
    ''' <param name="ActualBillingRate"></param>
    ''' <param name="BillingRate"></param>
    ''' <param name="ActualHours"></param>
    ''' <param name="BillHours"></param>
    ''' <param name="AccountTaxCodeId1"></param>
    ''' <param name="AccountTaxCodeId2"></param>
    ''' <param name="TotalAmount"></param>
    ''' <param name="TaxCode1"></param>
    ''' <param name="TaxCode2"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, True)> _
    Public Function AddAccountTimeExpenseBillingTimesheet(ByVal AccountTimeExpenseBillingId As Guid, _
    ByVal AccountId As Integer, ByVal AccountProjectId As Integer, ByVal AccountProjectTaskId As Integer, _
    ByVal Description As String, ByVal ActualBillingRate As Double, ByVal BillingRate As Double, _
    ByVal ActualHours As Double, ByVal BillHours As Double, ByVal AccountTaxCodeId1 As Integer, ByVal AccountTaxCodeId2 As Integer, _
    ByVal TotalAmount As Double, ByVal TaxCode1 As Double, ByVal TaxCode2 As Double, ByVal AccountEmployeeTimeEntryId As Integer)

        ' Update the product record
        _AccountTimeExpenseBillingTimesheetTableAdapter = New AccountTimeExpenseBillingTimesheetTableAdapter
        Dim dtAccountTimeExpenseBillingTimesheet As New AccountTimeExpenseBilling.AccountTimeExpenseBillingTimesheetDataTable
        Dim drAccountTimeExpenseBillingTimesheet As AccountTimeExpenseBilling.AccountTimeExpenseBillingTimesheetRow = dtAccountTimeExpenseBillingTimesheet.NewAccountTimeExpenseBillingTimesheetRow
        Dim AccountTimeExpenseBillingTimesheetId As Guid = System.Guid.NewGuid

        With drAccountTimeExpenseBillingTimesheet
            .AccountId = AccountId
            .AccountTimeExpenseBillingId = AccountTimeExpenseBillingId
            .AccountTimeExpenseBillingTimesheetId = AccountTimeExpenseBillingTimesheetId
            If AccountProjectId = 0 Then
                .Item("AccountProjectId") = System.DBNull.Value
            Else
                .AccountProjectId = AccountProjectId
            End If
            If AccountProjectTaskId = 0 Then
                .Item("AccountProjectTaskId") = System.DBNull.Value
            Else
                .AccountProjectTaskId = AccountProjectTaskId
            End If
            .Description = Description
            .ActualBillingRate = ActualBillingRate
            .BillingRate = BillingRate
            .ActualHours = ActualHours
            .BillHours = BillHours
            If AccountTaxCodeId1 = 0 Then
                .Item("AccountTaxCodeId1") = System.DBNull.Value
            Else
                .AccountTaxCodeId1 = AccountTaxCodeId1
            End If
            If AccountTaxCodeId2 = 0 Then
                .Item("AccountTaxCodeId2") = System.DBNull.Value
            Else
                .AccountTaxCodeId2 = AccountTaxCodeId2
            End If
            .TotalAmount = TotalAmount
            .TaxCode1 = TaxCode1
            .TaxCode2 = TaxCode2
            .CreatedOn = Now
            .CreatedByEmployeeId = DBUtilities.GetSessionAccountEmployeeId
            .ModifiedOn = Now
            .ModifiedByEmployeeId = DBUtilities.GetSessionAccountEmployeeId
            If AccountEmployeeTimeEntryId <> 0 Then
                .AccountEmployeeTimeEntryId = AccountEmployeeTimeEntryId
            Else
                .Item("AccountEmployeeTimeEntryId") = System.DBNull.Value
            End If
        End With

        dtAccountTimeExpenseBillingTimesheet.AddAccountTimeExpenseBillingTimesheetRow(drAccountTimeExpenseBillingTimesheet)

        ' Add the new product
        Dim rowsAffected As Integer = AccountTimeExpenseBillingTimesheetTableAdapter.Update(dtAccountTimeExpenseBillingTimesheet)
        'Return rowsAffected = 1

        'If AccountTimeExpenseBillingTimesheetId = System.Guid.Empty Then
        '    Dim a As TimeLiveDataSet.IdentityQueryRow
        '    Dim ad As New TimeLiveDataSetTableAdapters.IdentityQueryTableAdapter
        '    a = ad.GetAccountTimeExpenseBillingTimesheetLastId.Rows(0)
        '    AccountTimeExpenseBillingTimesheetId = a.LastId
        'End If
        System.Web.HttpContext.Current.Session.Add("AccountTimeExpenseBillingTimesheetId", AccountTimeExpenseBillingTimesheetId)
        Return rowsAffected = 1

    End Function
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="Original_AccountTimeExpenseBillingTimesheetId"></param>
    ''' <param name="AccountTimeExpenseBillingId"></param>
    ''' <param name="AccountId"></param>
    ''' <param name="AccountProjectId"></param>
    ''' <param name="AccountProjectTaskId"></param>
    ''' <param name="Description"></param>
    ''' <param name="ActualBillingRate"></param>
    ''' <param name="BillingRate"></param>
    ''' <param name="ActualHours"></param>
    ''' <param name="BillHours"></param>
    ''' <param name="AccountTaxCodeId1"></param>
    ''' <param name="AccountTaxCodeId2"></param>
    ''' <param name="TotalAmount"></param>
    ''' <param name="TaxCode1"></param>
    ''' <param name="TaxCode2"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)> _
    Public Function UpdateAccountTimeExpenseBillingTimesheet(ByVal Original_AccountTimeExpenseBillingTimesheetId As Guid, _
    ByVal AccountTimeExpenseBillingId As Guid, ByVal AccountId As Integer, ByVal AccountProjectId As Integer, _
    ByVal AccountProjectTaskId As Integer, ByVal Description As String, ByVal ActualBillingRate As Double, _
    ByVal BillingRate As Double, ByVal ActualHours As Double, ByVal BillHours As Double, _
    ByVal AccountTaxCodeId1 As Integer, ByVal AccountTaxCodeId2 As Integer, ByVal TotalAmount As Double, _
    ByVal TaxCode1 As Double, ByVal TaxCode2 As Double, ByVal AccountEmployeeTimeEntryId As Integer)

        ' Update the product record
        'AddOldObjectInSession(Original_AccountTimeExpenseBillingTimesheetId)
        Dim dtAccountTimeExpenseBillingTimesheet As AccountTimeExpenseBilling.AccountTimeExpenseBillingTimesheetDataTable = AccountTimeExpenseBillingTimesheetTableAdapter.GetDataByAccountTimeExpenseBillingTimesheetId(Original_AccountTimeExpenseBillingTimesheetId)
        Dim drAccountTimeExpenseBillingTimesheet As AccountTimeExpenseBilling.AccountTimeExpenseBillingTimesheetRow = dtAccountTimeExpenseBillingTimesheet.Rows(0)

        'AddOldObjectInSession(Original_AccountTimeExpenseBillingTimesheetId)

        With drAccountTimeExpenseBillingTimesheet
            .AccountId = AccountId
            .AccountTimeExpenseBillingId = AccountTimeExpenseBillingId
            If AccountProjectId = 0 Then
                .Item("AccountProjectId") = System.DBNull.Value
            Else
                .AccountProjectId = AccountProjectId
            End If
            If AccountProjectTaskId = 0 Then
                .Item("AccountProjectTaskId") = System.DBNull.Value
            Else
                .AccountProjectTaskId = AccountProjectTaskId
            End If
            .Description = Description
            .ActualBillingRate = ActualBillingRate
            .BillingRate = BillingRate
            .ActualHours = ActualHours
            .BillHours = BillHours
            If AccountTaxCodeId1 = 0 Then
                .Item("AccountTaxCodeId1") = System.DBNull.Value
            Else
                .AccountTaxCodeId1 = AccountTaxCodeId1
            End If
            If AccountTaxCodeId2 = 0 Then
                .Item("AccountTaxCodeId2") = System.DBNull.Value
            Else
                .AccountTaxCodeId2 = AccountTaxCodeId2
            End If
            .TotalAmount = TotalAmount
            .TaxCode1 = TaxCode1
            .TaxCode2 = TaxCode2
            .CreatedOn = Now
            .CreatedByEmployeeId = DBUtilities.GetSessionAccountEmployeeId
            .ModifiedOn = Now
            .ModifiedByEmployeeId = DBUtilities.GetSessionAccountEmployeeId
            If AccountEmployeeTimeEntryId <> 0 Then
                .AccountEmployeeTimeEntryId = AccountEmployeeTimeEntryId
            Else
                .Item("AccountEmployeeTimeEntryId") = System.DBNull.Value
            End If
            '.AccountTimeExpenseBillingTimesheetId = Original_AccountTimeExpenseBillingTimesheetId
        End With

        Dim rowsAffected As Integer = AccountTimeExpenseBillingTimesheetTableAdapter.Update(dtAccountTimeExpenseBillingTimesheet)
        ' Return true if precisely one row was updated, otherwise false
        Return rowsAffected = 1

    End Function
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="AccountTimeExpenseBillingId"></param>
    ''' <param name="AccountId"></param>
    ''' <param name="AccountProjectId"></param>
    ''' <param name="AccountExpenseTypeId"></param>
    ''' <param name="AccountExpenseId"></param>
    ''' <param name="Description"></param>
    ''' <param name="ActualExpenseAmount"></param>
    ''' <param name="BilledExpenseAmount"></param>
    ''' <param name="AccountTaxCodeId1"></param>
    ''' <param name="AccountTaxCodeId2"></param>
    ''' <param name="TaxCode1"></param>
    ''' <param name="TaxCode2"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, True)> _
    Public Function AddAccountTimeExpenseBillingExpense(ByVal AccountTimeExpenseBillingId As Guid, _
    ByVal AccountId As Integer, ByVal AccountProjectId As Integer, ByVal AccountExpenseTypeId As Integer, _
    ByVal AccountExpenseId As Integer, ByVal Description As String, ByVal ActualExpenseAmount As Double, ByVal BilledExpenseAmount As Double, _
    ByVal AccountTaxCodeId1 As Integer, ByVal AccountTaxCodeId2 As Integer, ByVal TaxCode1 As Double, ByVal TaxCode2 As Double, ByVal AccountExpenseEntryId As Integer)

        ' Update the product record
        _AccountTimeExpenseBillingExpenseTableAdapter = New AccountTimeExpenseBillingExpenseTableAdapter
        Dim dtAccountTimeExpenseBillingExpense As New AccountTimeExpenseBilling.AccountTimeExpenseBillingExpenseDataTable
        Dim drAccountTimeExpenseBillingExpense As AccountTimeExpenseBilling.AccountTimeExpenseBillingExpenseRow = dtAccountTimeExpenseBillingExpense.NewAccountTimeExpenseBillingExpenseRow
        Dim AccountTimeExpenseBillingExpenseId As Guid = System.Guid.NewGuid

        With drAccountTimeExpenseBillingExpense
            .AccountId = AccountId
            .AccountTimeExpenseBillingId = AccountTimeExpenseBillingId
            .AccountTimeExpenseBillingExpenseId = AccountTimeExpenseBillingExpenseId
            If AccountProjectId = 0 Then
                .Item("AccountProjectId") = System.DBNull.Value
            Else
                .AccountProjectId = AccountProjectId
            End If
            If AccountExpenseTypeId = 0 Then
                .Item("AccountExpenseTypeId") = System.DBNull.Value
            Else
                .AccountExpenseTypeId = AccountExpenseTypeId
            End If
            If AccountExpenseId = 0 Then
                .Item("AccountExpenseId") = System.DBNull.Value
            Else
                .AccountExpenseId = AccountExpenseId
            End If
            .Description = Description
            .ActualExpenseAmount = ActualExpenseAmount
            .BilledExpenseAmount = BilledExpenseAmount
            If AccountTaxCodeId1 = 0 Then
                .Item("AccountTaxCodeId1") = System.DBNull.Value
            Else
                .AccountTaxCodeId1 = AccountTaxCodeId1
            End If
            If AccountTaxCodeId2 = 0 Then
                .Item("AccountTaxCodeId2") = System.DBNull.Value
            Else
                .AccountTaxCodeId2 = AccountTaxCodeId2
            End If
            .TaxCode1 = TaxCode1
            .TaxCode2 = TaxCode2
            .CreatedOn = Now
            .CreatedByEmployeeId = DBUtilities.GetSessionAccountEmployeeId
            .ModifiedOn = Now
            .ModifiedByEmployeeId = DBUtilities.GetSessionAccountEmployeeId
            If AccountExpenseEntryId <> 0 Then
                .AccountExpenseEntryId = AccountExpenseEntryId
            Else
                .Item("AccountExpenseEntryId") = System.DBNull.Value
            End If
        End With

        dtAccountTimeExpenseBillingExpense.AddAccountTimeExpenseBillingExpenseRow(drAccountTimeExpenseBillingExpense)

        ' Return true if precisely one row was updated, otherwise false

        ' Add the new product
        Dim rowsAffected As Integer = AccountTimeExpenseBillingExpenseTableAdapter.Update(dtAccountTimeExpenseBillingExpense)

        'If AccountTimeExpenseBillingExpenseId = System.Guid.Empty Then
        '    Dim a As TimeLiveDataSet.IdentityQueryRow
        '    Dim ad As New TimeLiveDataSetTableAdapters.IdentityQueryTableAdapter
        '    a = ad.GetAccountTimeExpenseBillingExpenseLastId.Rows(0)
        '    AccountTimeExpenseBillingExpenseId = a.LastId
        'End If
        System.Web.HttpContext.Current.Session.Add("AccountTimeExpenseBillingExpenseId", AccountTimeExpenseBillingExpenseId)
        ' Return true if precisely one row was inserted, otherwise false
        Return rowsAffected = 1

    End Function
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="Original_AccountTimeExpenseBillingExpenseId"></param>
    ''' <param name="AccountTimeExpenseBillingId"></param>
    ''' <param name="AccountId"></param>
    ''' <param name="AccountProjectId"></param>
    ''' <param name="AccountExpenseId"></param>
    ''' <param name="AccountExpenseTypeId"></param>
    ''' <param name="Description"></param>
    ''' <param name="ActualExpenseAmount"></param>
    ''' <param name="BilledExpenseAmount"></param>
    ''' <param name="AccountTaxCodeId1"></param>
    ''' <param name="AccountTaxCodeId2"></param>
    ''' <param name="TaxCode1"></param>
    ''' <param name="TaxCode2"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)> _
    Public Function UpdateAccountTimeExpenseBillingExpense(ByVal Original_AccountTimeExpenseBillingExpenseId As Guid, _
    ByVal AccountTimeExpenseBillingId As Guid, ByVal AccountId As Integer, ByVal AccountProjectId As Integer, _
    ByVal AccountExpenseId As Integer, ByVal AccountExpenseTypeId As Integer, ByVal Description As String, _
    ByVal ActualExpenseAmount As Double, ByVal BilledExpenseAmount As Double, _
    ByVal AccountTaxCodeId1 As Integer, ByVal AccountTaxCodeId2 As Integer, _
    ByVal TaxCode1 As Double, ByVal TaxCode2 As Double, ByVal AccountExpenseEntryId As Integer)


        ' Update the product record

        Dim dtAccountTimeExpenseBillingExpense As AccountTimeExpenseBilling.AccountTimeExpenseBillingExpenseDataTable = AccountTimeExpenseBillingExpenseTableAdapter.GetDataByAccountTimeExpenseBillingExpenseId(Original_AccountTimeExpenseBillingExpenseId)
        Dim drAccountTimeExpenseBillingExpense As AccountTimeExpenseBilling.AccountTimeExpenseBillingExpenseRow = dtAccountTimeExpenseBillingExpense.Rows(0)
        'AddOldObjectInSession(Original_AccountTimeExpenseBillingTimesheetId)

        With drAccountTimeExpenseBillingExpense
            .AccountId = AccountId
            .AccountTimeExpenseBillingId = AccountTimeExpenseBillingId
            If AccountProjectId = 0 Then
                .Item("AccountProjectId") = System.DBNull.Value
            Else
                .AccountProjectId = AccountProjectId
            End If
            If AccountExpenseTypeId = 0 Then
                .Item("AccountExpenseTypeId") = System.DBNull.Value
            Else
                .AccountExpenseTypeId = AccountExpenseTypeId
            End If
            If AccountExpenseId = 0 Then
                .Item("AccountExpenseId") = System.DBNull.Value
            Else
                .AccountExpenseId = AccountExpenseId
            End If
            .Description = Description
            .ActualExpenseAmount = ActualExpenseAmount
            .BilledExpenseAmount = BilledExpenseAmount
            If AccountTaxCodeId1 = 0 Then
                .Item("AccountTaxCodeId1") = System.DBNull.Value
            Else
                .AccountTaxCodeId1 = AccountTaxCodeId1
            End If
            If AccountTaxCodeId2 = 0 Then
                .Item("AccountTaxCodeId2") = System.DBNull.Value
            Else
                .AccountTaxCodeId2 = AccountTaxCodeId2
            End If
            .TaxCode1 = TaxCode1
            .TaxCode2 = TaxCode2
            .CreatedOn = Now
            .CreatedByEmployeeId = DBUtilities.GetSessionAccountEmployeeId
            .ModifiedOn = Now
            .ModifiedByEmployeeId = DBUtilities.GetSessionAccountEmployeeId
            If AccountExpenseEntryId <> 0 Then
                .AccountExpenseEntryId = AccountExpenseEntryId
            Else
                .Item("AccountExpenseEntryId") = System.DBNull.Value
            End If
        End With

        Dim rowsAffected As Integer = AccountTimeExpenseBillingExpenseTableAdapter.Update(dtAccountTimeExpenseBillingExpense)

        ' Return true if precisely one row was updated, otherwise false
        Return rowsAffected = 1

    End Function
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="AccountProjectId"></param>
    ''' <param name="AccountProjectTaskId"></param>
    ''' <param name="AccountTimeExpenseBillingTimesheetId"></param>
    ''' <param name="Billed"></param>
    ''' <param name="TimeEntryStartDate"></param>
    ''' <param name="TimeEntryEndDate"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, True)> _
    Public Function UpdateAccountEmployeeTimeEntryBillStatus(ByVal AccountProjectId As Integer, ByVal AccountProjectTaskId As Integer, _
    ByVal AccountTimeExpenseBillingTimesheetId As Guid, ByVal Billed As Boolean, _
    ByVal TimeEntryStartDate As DateTime, ByVal TimeEntryEndDate As DateTime) As Boolean

        ' Update the product record

        Dim dtAccountTimeEntryBillStatus As AccountEmployeeTimeEntryforBilling.AccountEmployeeTimeEntryDataTable = AccountEmployeeTimeEntryTableAdapter.GetDataByAccountProjectIdandAccountProjectTaskId(AccountProjectId, AccountProjectTaskId, TimeEntryStartDate, TimeEntryEndDate)
        If dtAccountTimeEntryBillStatus.Rows.Count <> 0 Then
            Dim drAccountTimeEntryBillStatus As AccountEmployeeTimeEntryforBilling.AccountEmployeeTimeEntryRow = dtAccountTimeEntryBillStatus.Rows(0)
            With drAccountTimeEntryBillStatus

                For Each drAccountTimeEntryBillStatus In dtAccountTimeEntryBillStatus.Rows
                    drAccountTimeEntryBillStatus.AccountTimeExpenseBillingTimesheetId = AccountTimeExpenseBillingTimesheetId
                    drAccountTimeEntryBillStatus.Billed = True
                Next

                Dim rowsAffected As Integer = AccountEmployeeTimeEntryTableAdapter.Update(dtAccountTimeEntryBillStatus)

            End With
        End If

    End Function
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="AccountTimeExpenseBillingExpenseId"></param>
    ''' <param name="AccountProjectId"></param>
    ''' <param name="AccountExpenseId"></param>
    ''' <param name="Billed"></param>
    ''' <param name="ExpenseEntryStartDate"></param>
    ''' <param name="ExpenseEntryEndDate"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, True)> _
    Public Function UpdateAccountExpenseEntryBillStatus(ByVal AccountTimeExpenseBillingExpenseId As Guid, _
    ByVal AccountProjectId As Integer, ByVal AccountExpenseId As Integer, ByVal Billed As Boolean, _
    ByVal ExpenseEntryStartDate As DateTime, ByVal ExpenseEntryEndDate As DateTime) As Boolean
        ' Update the product record
        Dim dtAccountExpenseEntryBillStatus As AccountExpenseEntryforBilling.AccountExpenseEntryDataTable = AccountExpenseEntryTableAdapter.GetDataByAccountProjectIdandAccountExpenseId(AccountProjectId, AccountExpenseId, ExpenseEntryStartDate, ExpenseEntryEndDate)
        If dtAccountExpenseEntryBillStatus.Rows.Count <> 0 Then
            Dim drAccountExpenseEntryBillStatus As AccountExpenseEntryforBilling.AccountExpenseEntryRow = dtAccountExpenseEntryBillStatus.Rows(0)

            With drAccountExpenseEntryBillStatus

                For Each drAccountExpenseEntryBillStatus In dtAccountExpenseEntryBillStatus.Rows
                    drAccountExpenseEntryBillStatus.AccountTimeExpenseBillingExpenseId = AccountTimeExpenseBillingExpenseId
                    drAccountExpenseEntryBillStatus.Billed = True
                Next

                Dim rowsAffected As Integer = AccountExpenseEntryTableAdapter.Update(dtAccountExpenseEntryBillStatus)

            End With
        End If
        ' Return true if precisely one row was updated, otherwise false
    End Function
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="Original_AccountEmployeeTimeEntryId"></param>
    ''' <param name="Billed"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)> _
    Public Function UpdateTimeBillingWorksheet(ByVal Original_AccountEmployeeTimeEntryId As Integer, _
        ByVal Billed As Boolean _
        ) As Boolean

        ' Update the product record

        If Original_AccountEmployeeTimeEntryId = 0 Then
            Exit Function
        End If

        Dim AccountEmployeeTimeEntries As AccountEmployeeTimeEntryforBilling.AccountEmployeeTimeEntryDataTable = AccountEmployeeTimeEntryTableAdapter.GetDataByAccountEmployeeTimeEntryId(Original_AccountEmployeeTimeEntryId)
        Dim AccountEmployeeTimeEntry As AccountEmployeeTimeEntryforBilling.AccountEmployeeTimeEntryRow = AccountEmployeeTimeEntries.Rows(0)

        With AccountEmployeeTimeEntry

            .ModifiedOn = Now
            .Billed = Billed
            'If Approved = False Then
            '    Me.DeleteIsApprovedStatusApproval(Original_AccountEmployeeTimeEntryId)
            'End If
        End With

        Dim rowsAffected As Integer = AccountEmployeeTimeEntryTableAdapter.Update(AccountEmployeeTimeEntry)
        ' Return true if precisely one row was updated, otherwise false
        Return rowsAffected = 1

    End Function
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="Original_AccountExpenseEntryId"></param>
    ''' <param name="Billed"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)> _
    Public Function UpdateExpenseBillingWorksheet(ByVal Original_AccountExpenseEntryId As Integer, _
            ByVal Billed As Boolean) As Boolean

        ' Update the product record

        Dim AccountExpenseEntries As AccountExpenseEntryforBilling.AccountExpenseEntryDataTable = AccountExpenseEntryTableAdapter.GetDataByAccountExpenseEntryId(Original_AccountExpenseEntryId)
        Dim AccountExpenseEntry As AccountExpenseEntryforBilling.AccountExpenseEntryRow = AccountExpenseEntries.Rows(0)

        With AccountExpenseEntry
            .ModifiedOn = Now
            .Billed = Billed
            'If Approved = False Then
            '    Me.DeleteIsApprovedStatusApproval(Original_AccountExpenseEntryId)
            'End If
        End With

        Dim rowsAffected As Integer = AccountExpenseEntryTableAdapter.Update(AccountExpenseEntry)
        ' Return true if precisely one row was updated, otherwise false
        Return rowsAffected = 1

    End Function
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="Original_AccountTimeExpenseBillingId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Delete, True)> _
    Public Function DeleteAccountTimeExpenseBilling(ByVal Original_AccountTimeExpenseBillingId As Guid) As Boolean
        Dim rowsAffected As Integer = Adapter.DeleteQuery(Original_AccountTimeExpenseBillingId)

        Return rowsAffected = 1
    End Function
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="Original_AccountTimeExpenseBillingId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Delete, True)> _
    Public Function DeleteAccountTimeExpenseBillingTimeSheet(ByVal Original_AccountTimeExpenseBillingId As Guid) As Boolean
        Dim rowsAffected As Integer = AccountTimeExpenseBillingTimesheetTableAdapter.DeleteQuery(Original_AccountTimeExpenseBillingId)

        Return rowsAffected = 1
    End Function
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="Original_AccountTimeExpenseBillingTimesheetId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Delete, True)> _
    Public Function DeleteAccountTimeExpenseBillingTimeSheetGridView(ByVal Original_AccountTimeExpenseBillingTimesheetId As Guid) As Boolean
        Dim rowsAffected As Integer = AccountTimeExpenseBillingTimesheetTableAdapter.Delete(Original_AccountTimeExpenseBillingTimesheetId)

        Return rowsAffected = 1
    End Function
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="Original_AccountTimeExpenseBillingId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Delete, True)> _
    Public Function DeleteAccountTimeExpenseBillingExpense(ByVal Original_AccountTimeExpenseBillingId As Guid) As Boolean
        Dim rowsAffected As Integer = AccountTimeExpenseBillingExpenseTableAdapter.DeleteQuery(Original_AccountTimeExpenseBillingId)

        Return rowsAffected = 1
    End Function
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="Original_AccountTimeExpenseBillingExpenseId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function DeleteAccountTimeExpenseBillingExpenseGridView(ByVal Original_AccountTimeExpenseBillingExpenseId As Guid) As Boolean
        Dim rowsAffected As Integer = AccountTimeExpenseBillingExpenseTableAdapter.Delete(Original_AccountTimeExpenseBillingExpenseId)

        Return rowsAffected = 1
    End Function
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="Original_AccountEmployeeTimeEntryId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Delete, True)> _
    Public Function DeleteAccountEmployeeTimeEntry(ByVal Original_AccountEmployeeTimeEntryId As Integer) As Boolean
        Dim rowsAffected As Integer = AccountEmployeeTimeEntryTableAdapter.Delete(Original_AccountEmployeeTimeEntryId)

        ' Return true if precisely one row was deleted, otherwise false
        Return rowsAffected = 1
    End Function
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="Original_AccountExpenseEntryId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Delete, True)> _
    Public Function DeleteAccountExpenseEntry(ByVal Original_AccountExpenseEntryId As Integer) As Boolean
        Dim rowsAffected As Integer = AccountExpenseEntryTableAdapter.Delete(Original_AccountExpenseEntryId)
        ' Return true if precisely one row was deleted, otherwise false
        Return rowsAffected = 1
    End Function
    Public Function GetLastInsertedId() As Guid
        'Dim a As TimeLiveDataSet.IdentityQueryRow
        'Dim ad As New TimeLiveDataSetTableAdapters.IdentityQueryTableAdapter
        'a = ad.GetAccountTimeExpenseBillingLastId.Rows(0)
        'Return a.LastId
        Return System.Web.HttpContext.Current.Session("AccountTimeExpenseBillingId")
    End Function
    Public Function GetLastInsertedIdTimesheet() As Guid
        'Dim a As TimeLiveDataSet.IdentityQueryRow
        'Dim ad As New TimeLiveDataSetTableAdapters.IdentityQueryTableAdapter
        'a = ad.GetAccountTimeExpenseBillingTimesheetLastId.Rows(0)
        'Return a.LastId
        Return System.Web.HttpContext.Current.Session("AccountTimeExpenseBillingTimesheetId")
    End Function
    Public Function GetLastInsertedIdExpense() As Guid
        'Dim a As TimeLiveDataSet.IdentityQueryRow
        'Dim ad As New TimeLiveDataSetTableAdapters.IdentityQueryTableAdapter
        'a = ad.GetAccountTimeExpenseBillingExpenseLastId.Rows(0)
        'Return a.LastId
        Return System.Web.HttpContext.Current.Session("AccountTimeExpenseBillingExpenseId")
    End Function
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="Original_AccountTimeExpenseBillingId"></param>
    ''' <param name="IsPaid"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)> _
        Public Function UpdateInvoicePaid(ByVal Original_AccountTimeExpenseBillingId As Guid, ByVal IsPaid As Boolean) As Boolean

        ' Update the product record

        Dim dtAccountTimeExpenseBilling As AccountTimeExpenseBilling.AccountTimeExpenseBillingDataTable = Adapter.GetDataByAccountTimeExpenseBillingId(Original_AccountTimeExpenseBillingId)
        Dim drAccountTimeExpenseBilling As AccountTimeExpenseBilling.AccountTimeExpenseBillingRow = dtAccountTimeExpenseBilling.Rows(0)

        With drAccountTimeExpenseBilling
            .AccountTimeExpenseBillingId = Original_AccountTimeExpenseBillingId
            .IsPaid = IsPaid
        End With

        Dim rowsAffected As Integer = Adapter.Update(dtAccountTimeExpenseBilling)

        ' Return true if precisely one row was updated, otherwise false
        Return rowsAffected = 1
    End Function
    Public Function AddBlankRowsInDataTable(ByVal dtBlank As ViewAccountTimeExpenseBillingTimesheetforEditDataTable) As AccountTimeExpenseBilling.ViewAccountTimeExpenseBillingTimesheetforEditDataTable
        '    Dim AccountTimeExpenseBillingTimesheetDatatable As AccountTimeExpenseBilling.AccountTimeExpenseBillingTimesheetDataTable

        Dim detailRow As ViewAccountTimeExpenseBillingTimesheetforEditRow
        For n As Integer = 1 To 5
            detailRow = dtBlank.NewViewAccountTimeExpenseBillingTimesheetforEditRow
            detailRow.AccountClientId = 0
            detailRow.AccountProjectId = 0
            detailRow.AccountProjectTaskId = 0
            detailRow.BillingRate = 0
            detailRow.BillHours = 0
            detailRow.ActualBillingRate = 0
            detailRow.ActualHours = 0
            detailRow.AccountTimeExpenseBillingTimesheetId = System.Guid.Empty
            detailRow.AccountTimeExpenseBillingId = System.Guid.Empty
            detailRow.TotalAmount = 0
            dtBlank.Rows.Add(detailRow)
        Next
        Return dtBlank
    End Function
    Public Function AddBlankRowsInDataTableExpense(ByVal dtBlank As vueAccountTimeExpenseBillingExpenseForEditDataTable) As AccountTimeExpenseBilling.vueAccountTimeExpenseBillingExpenseForEditDataTable
        Dim detailRow As vueAccountTimeExpenseBillingExpenseForEditRow
        For n As Integer = 1 To 5
            detailRow = dtBlank.NewvueAccountTimeExpenseBillingExpenseForEditRow
            detailRow.AccountClientId = 0
            detailRow.AccountProjectId = 0
            detailRow.AccountExpenseId = 0
            detailRow.AccountTimeExpenseBillingExpenseId = System.Guid.Empty
            detailRow.AccountTimeExpenseBillingId = System.Guid.Empty
            detailRow.AccountExpenseTypeId = 0
            detailRow.ActualExpenseAmount = 0
            detailRow.BilledExpenseAmount = 0
            dtBlank.Rows.Add(detailRow)
        Next
        Return dtBlank
    End Function
End Class
