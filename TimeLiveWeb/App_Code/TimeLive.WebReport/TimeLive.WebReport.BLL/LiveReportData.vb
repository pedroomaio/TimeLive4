Imports ReportFilterTableAdapters
Imports dsReportDesignTableAdapters
Imports System.Data.SqlClient
Imports System.Data

<System.ComponentModel.DataObject()>
Public Class LiveReportData

    Dim DataSources As New DataTable
    Dim Reports As New DataTable
    Dim DataSourceFilterSet As New DataTable
    Private _vueAccountReportTableAdapter As New ReportFilterTableAdapters.vueAccountReportTableAdapter
    Private _vueAccountReportDataSourceMappingTableAdapter As New vueAccountReportDataSourceMappingTableAdapter

    Public Sub PrepareDataSources()

        Dim column As New DataColumn
        DataSources.Columns.Add("DatasourceName")
        DataSources.Columns.Add("ViewName")

        Dim objRow As DataRow
        objRow = DataSources.NewRow()
        objRow("DatasourceName") = "Detail Timesheet"
        objRow("ViewName") = "vueAccountEmployeeTimeEntry"
        DataSources.Rows.Add(objRow)

    End Sub

    Public Sub PrepareReports()
        Dim column As New DataColumn
        Reports.Columns.Add("ReportName")
        Reports.Columns.Add("DataSourceName")

        Dim objRow As DataRow
        objRow = Reports.NewRow()
        objRow("ReportName") = "Detail Timesheet Report"
        objRow("DataSourceName") = "Detail Timesheet Report"
        Reports.Rows.Add(objRow)

    End Sub
    Public Sub PrepareDatasourceFilters()
        DataSourceFilterSet.Columns.Add("DataSourceName")
        DataSourceFilterSet.Columns.Add("DataSourceName")

        Dim objRow As DataRow
        objRow = Reports.NewRow()
        objRow("ReportName") = "Detail Timesheet Report"
        objRow("DataSourceName") = "Detail Timesheet Report"
        Reports.Rows.Add(objRow)

    End Sub


    Public Function GetvueAccountReportFilterByAccountReportId(ByVal AccountReportId As Guid) As ReportFilter.vueAccountReportFilterDataTable
        Dim _vueAccountReportFilter As New ReportFilterTableAdapters.vueAccountReportFilterTableAdapter
        GetvueAccountReportFilterByAccountReportId = _vueAccountReportFilter.GetDataByAccountReportId(AccountReportId)
        Return GetvueAccountReportFilterByAccountReportId
    End Function

    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)>
    Public Function GetvueAccountReports() As ReportFilter.vueAccountReportDataTable
        Return _vueAccountReportTableAdapter.GetData
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)>
    Public Function GetvueAccountReportsByAccountReportId(ByVal AccountReportId As Guid) As ReportFilter.vueAccountReportDataTable
        Return _vueAccountReportTableAdapter.GetDataByAccountReportId(AccountReportId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)>
    Public Function GetvueAccountReportDataSourceMappingsByAccountReportId(ByVal AccountReportId As Guid) As dsReportDesign.vueAccountReportDataSourceMappingDataTable
        Return _vueAccountReportDataSourceMappingTableAdapter.GetDataByAccountReportId(AccountReportId)
    End Function
    Public Shared Function GetDataTable(ByVal ReportId As Guid, ByVal WhereClause As String, MissingPeriodReportWhereClause As String, MissingPeriodReportStartAndEndDate As Hashtable, ByVal TimesheetPeriodType As String) As DataTable
        Dim BLL As New LiveReportData
        Dim IsForTimeEntryReport As Boolean = False
        Dim dtDataSourceMapping As dsReportDesign.vueAccountReportDataSourceMappingDataTable = BLL.GetvueAccountReportDataSourceMappingsByAccountReportId(ReportId)
        Dim drDataSourceMapping As dsReportDesign.vueAccountReportDataSourceMappingRow
        If dtDataSourceMapping.Rows.Count > 0 Then
            drDataSourceMapping = dtDataSourceMapping.Rows(0)
            Dim objConnection As SqlConnection
            Dim sqladap As New SqlDataAdapter
            Dim strsql As String = ""
            Dim strsql1 As String = ""

            If drDataSourceMapping.ReportDataSourceName = "Timesheet Audit Trail" Or drDataSourceMapping.ReportDataSourceName = "Expense Sheet Audit Trail" Then
                Dim AccountId As String = "AccountId = " & DBUtilities.GetSessionAccountId & " and"
                Dim ReplaceAccountId As String = Replace(WhereClause, AccountId, " ")
                strsql1 = Replace(ReplaceAccountId, "AccountEmployeeId", "dbo.Audit.UserName")
            End If
            If drDataSourceMapping.ReportDataSourceName = "Timesheet Audit Trail" Then
                strsql = "SELECT CASE WHEN FieldName = 'AccountProjectId' THEN (select ProjectName from AccountProject where AccountProjectId = audit.oldvalue) " &
                "WHEN FieldName = 'AccountProjectTaskId' THEN (select TaskName from AccountProjectTask where AccountProjectTaskId = audit.oldvalue) " &
                "WHEN FieldName = 'AccountWorkTypeId' THEN (select AccountWorkType from AccountWorkType where AccountWorkTypeId = audit.oldvalue) " &
                "WHEN FieldName = 'AccountCostCenterId' THEN (select AccountCostCenter from AccountCostCenter where AccountCostCenterId = audit.oldvalue) " &
                "WHEN FieldName = 'StartTime' THEN Replace(RIGHT(CONVERT(varchar, Audit.OldValue, 109), 7), ' ', 0) " &
                "WHEN FieldName = 'EndTime' THEN Replace(RIGHT(CONVERT(varchar, Audit.OldValue, 109), 7), ' ', 0) " &
                "WHEN FieldName = 'TotalTime' THEN LEFT(CONVERT(varchar, CONVERT(datetime, Audit.OldValue), 8), 5) " &
                "WHEN FieldName = 'ApprovedOn' THEN CONVERT(nvarchar(100), DATEADD(mi, dbo.GET_TZVALUE(" & LocaleUtilitiesBLL.GetTimeZoneDifference(DBUtilities.GetEmployeeTimeZoneId) & "), Audit.OldValue)) " &
                "ELSE Audit.OldValue END AS OldValue, " &
                "CASE WHEN FieldName = 'AccountProjectId' THEN (select ProjectName from AccountProject where AccountProjectId = audit.newvalue) " &
                "WHEN FieldName = 'AccountProjectTaskId' THEN (select TaskName from AccountProjectTask where AccountProjectTaskId = audit.newvalue) " &
                "WHEN FieldName = 'AccountWorkTypeId' THEN (select AccountWorkType from AccountWorkType where AccountWorkTypeId = audit.newvalue) " &
                "WHEN FieldName = 'AccountCostCenterId' THEN (select AccountCostCenter from AccountCostCenter where AccountCostCenterId = audit.newvalue) " &
                "WHEN FieldName = 'StartTime' THEN Replace(RIGHT(CONVERT(varchar, Audit.NewValue, 109), 7), ' ', 0) " &
                "WHEN FieldName = 'EndTime' THEN Replace(RIGHT(CONVERT(varchar, Audit.NewValue, 109), 7), ' ', 0) " &
                "WHEN FieldName = 'TotalTime' THEN LEFT(CONVERT(varchar, CONVERT(datetime, Audit.NewValue), 8), 5) " &
                "WHEN FieldName = 'ApprovedOn' THEN CONVERT(nvarchar(100), DATEADD(mi, dbo.GET_TZVALUE(" & LocaleUtilitiesBLL.GetTimeZoneDifference(DBUtilities.GetEmployeeTimeZoneId) & "), Audit.NewValue)) " &
                "ELSE Audit.NewValue END AS NewValue, " &
                "CASE WHEN FieldName = 'AccountProjectId' THEN 'Project Name' WHEN FieldName = 'AccountProjectTaskId' THEN 'Task Name' " &
                "WHEN FieldName = 'AccountCostCenterId' THEN 'Cost Center' WHEN FieldName = 'AccountWorkTypeId' THEN 'Work Type' ELSE Audit.FieldName END AS FieldName, " &
                "dbo.Audit.UserName, dbo.Audit.UpdateDate, dbo.Audit.TableName, dbo.AccountProject.ProjectName, " &
                "dbo.AccountProjectTask.TaskName, CONVERT(varchar, dbo.AccountEmployeeTimeEntry.TimeEntryDate, 106) AS Date, dbo.AccountEmployeeTimeEntry.TotalTime, " &
                "CASE WHEN dbo.AccountPreferences.ShowEmployeeNameBy = 2  and dbo.AccountEmployee.IsDisabled = 1  THEN dbo.AccountEmployee.LastName + ' ' + dbo.AccountEmployee.FirstName + ' ' + '(Disbaled)' " &
                "WHEN dbo.AccountPreferences.ShowEmployeeNameBy = 2 and dbo.AccountEmployee.IsDisabled = 0 THEN dbo.AccountEmployee.LastName + ' ' + dbo.AccountEmployee.FirstName " &
                "WHEN dbo.AccountPreferences.ShowEmployeeNameBy = 1 and dbo.AccountEmployee.IsDisabled = 1 THEN dbo.AccountEmployee.FirstName + ' ' + dbo.AccountEmployee.LastName + ' ' + '(Disbaled)' " &
                "ELSE dbo.AccountEmployee.FirstName + ' ' + dbo.AccountEmployee.LastName END AS UpdatedBy " &
                "FROM dbo.AccountPreferences INNER JOIN dbo.AccountEmployee ON dbo.AccountPreferences.AccountId = dbo.AccountEmployee.AccountId RIGHT OUTER JOIN " &
                      "dbo.Audit LEFT OUTER JOIN dbo.AccountEmployeeTimeEntry ON CONVERT(Int, dbo.Audit.PK) = dbo.AccountEmployeeTimeEntry.AccountEmployeeTimeEntryId LEFT OUTER JOIN " &
                      "dbo.AccountProject ON dbo.AccountEmployeeTimeEntry.AccountProjectId = dbo.AccountProject.AccountProjectId LEFT OUTER JOIN " &
                      "dbo.AccountProjectTask ON dbo.AccountEmployeeTimeEntry.AccountProjectTaskId = dbo.AccountProjectTask.AccountProjectTaskId ON " &
                "dbo.AccountEmployee.AccountEmployeeId = dbo.Audit.UserName " &
                "Where (dbo.Audit.TableName = N'AccountEmployeeTimeEntry') and " & strsql1 & " UNION ALL " &
                "SELECT CASE WHEN FieldName = 'SubmittedBy' THEN (Select FirstName + ' ' + LastName From AccountEmployee where AccountEmployeeId = audit.oldvalue) " &
                "WHEN FieldName = 'ApprovedByEmployeeId' THEN (Select FirstName + ' ' + LastName From AccountEmployee where AccountEmployeeId = audit.oldvalue) " &
                "WHEN FieldName = 'RejectedByEmployeeId' THEN (Select FirstName + ' ' + LastName From AccountEmployee where AccountEmployeeId = audit.oldvalue) " &
                "WHEN FieldName = 'Submitted' THEN CASE WHEN Audit.OldValue <> '1' THEN 'No' WHEN Audit.OldValue = '1' THEN 'Yes' END " &
                "WHEN FieldName = 'Approved' THEN CASE WHEN Audit.OldValue <> '1' THEN 'No' WHEN Audit.OldValue = '1' THEN 'Yes' END " &
                "WHEN FieldName = 'Rejected' THEN CASE WHEN Audit.OldValue <> '1' THEN 'No' WHEN Audit.OldValue = '1' THEN 'Yes' END ELSE Audit.OldValue END AS OldValue, " &
                "CASE WHEN FieldName = 'SubmittedBy' THEN (Select FirstName + ' ' + LastName From AccountEmployee where AccountEmployeeId = audit.newvalue) " &
                "WHEN FieldName = 'ApprovedByEmployeeId' THEN (Select FirstName + ' ' + LastName From AccountEmployee where AccountEmployeeId = audit.newvalue) " &
                "WHEN FieldName = 'RejectedByEmployeeId' THEN (Select FirstName + ' ' + LastName From AccountEmployee where AccountEmployeeId = audit.newvalue) " &
                "WHEN FieldName = 'Submitted' THEN CASE WHEN Audit.NewValue <> '1' THEN 'No' WHEN Audit.NewValue = '1' THEN 'Yes' END WHEN FieldName = 'Approved' THEN " &
                "CASE WHEN Audit.NewValue <> '1' THEN 'No' WHEN Audit.NewValue = '1' THEN 'Yes' END WHEN FieldName = 'Rejected' THEN CASE WHEN Audit.NewValue <> '1' THEN 'No' " &
                "WHEN Audit.NewValue = '1' THEN 'Yes' END ELSE Audit.NewValue END AS NewValue, " &
                "CASE WHEN FieldName = 'SubmittedBy' THEN 'Submitted By' WHEN FieldName = 'ApprovedByEmployeeId' THEN 'Approved By' WHEN FieldName = 'RejectedByEmployeeId' " &
                "THEN 'Rejected By' ELSE Audit.FieldName END AS FieldName, " &
                "dbo.Audit.UserName, dbo.Audit.UpdateDate, dbo.Audit.TableName, NULL as ProjectName, NULL as TaskName,  CONVERT(varchar, dbo.AccountEmployeeTimeEntryPeriod.TimeEntryStartDate, 106) " &
                "+ ' - ' + CONVERT(varchar, dbo.AccountEmployeeTimeEntryPeriod.TimeEntryEndDate, 106) AS Date, NULL as TotalTime, " &
                "CASE WHEN dbo.AccountPreferences.ShowEmployeeNameBy = 2  and dbo.AccountEmployee.IsDisabled = 1  THEN dbo.AccountEmployee.LastName + ' ' + dbo.AccountEmployee.FirstName + ' ' + '(Disbaled)' " &
                "WHEN dbo.AccountPreferences.ShowEmployeeNameBy = 2 and dbo.AccountEmployee.IsDisabled = 0 THEN dbo.AccountEmployee.LastName + ' ' + dbo.AccountEmployee.FirstName " &
                "WHEN dbo.AccountPreferences.ShowEmployeeNameBy = 1 and dbo.AccountEmployee.IsDisabled = 1 THEN dbo.AccountEmployee.FirstName + ' ' + dbo.AccountEmployee.LastName + ' ' + '(Disbaled)' " &
                "ELSE dbo.AccountEmployee.FirstName + ' ' + dbo.AccountEmployee.LastName END AS UpdatedBy " &
                "FROM         dbo.AccountPreferences INNER JOIN dbo.AccountEmployee ON dbo.AccountPreferences.AccountId = dbo.AccountEmployee.AccountId RIGHT OUTER JOIN " &
                "dbo.Audit LEFT OUTER JOIN dbo.AccountEmployeeTimeEntryPeriod ON CONVERT(nvarchar(100), dbo.Audit.PK) = dbo.AccountEmployeeTimeEntryPeriod.AccountEmployeeTimeEntryPeriodId ON " &
                "dbo.AccountEmployee.AccountEmployeeId = dbo.Audit.UserName  Where (dbo.Audit.TableName = N'AccountEmployeeTimeEntryPeriod') and "
                '"LEFT OUTER JOIN dbo.AccountEmployeeTimeEntryPeriod ON Convert(nvarchar(100), dbo.Audit.PK) = dbo.AccountEmployeeTimeEntryPeriod.AccountEmployeeTimeEntryPeriodId " & _
                '"LEFT OUTER JOIN dbo.AccountEmployee ON dbo.Audit.UserName = dbo.AccountEmployee.AccountEmployeeId Where (dbo.Audit.TableName = N'AccountEmployeeTimeEntryPeriod') and "

                strsql = strsql & strsql1
            ElseIf drDataSourceMapping.ReportDataSourceName = "Expense Sheet Audit Trail" Then
                strsql = "SELECT dbo.Audit.Type, dbo.Audit.TableName, dbo.Audit.PK, dbo.Audit.FieldName AS AuditFieldName, dbo.Audit.OldValue AS AuditOldVal, dbo.Audit.NewValue AS AuditNewVal, " &
                "dbo.Audit.UpdateDate, dbo.Audit.UserName,  " &
                "CASE WHEN FieldName = 'AccountExpenseId' THEN (Select AccountExpenseName From AccountExpense where AccountExpenseId = Audit.OldValue) " &
                "WHEN FieldName = 'AccountProjectId' THEN (Select ProjectName From AccountProject where AccountProjectId = Audit.OldValue) " &
                "WHEN FieldName = 'AccountCurrencyId' THEN (Select CurrencyCode From vueAccountCurrency where AccountCurrencyId = Audit.OldValue) " &
                "WHEN FieldName = 'AccountPaymentMethodId' THEN (Select PaymentMethod From AccountPaymentMethod where AccountPaymentMethodId = Audit.OldValue) " &
                "WHEN FieldName = 'AccountTaxZoneId' THEN  (Select AccountTaxZone From AccountTaxZone where AccountTaxZoneId = Audit.OldValue) " &
                "WHEN FieldName = 'IsBillable' THEN CASE WHEN Audit.OldValue = '1' THEN 'Yes' " &
                "WHEN Audit.OldValue <> '1' THEN 'No' END WHEN FieldName = 'Reimburse' THEN CASE WHEN Audit.OldValue = '1' THEN 'Yes' WHEN Audit.OldValue <> '1' THEN 'No' " &
                "END WHEN FieldName = 'Amount' THEN Audit.OldValue WHEN FieldName = 'AmountBeforeTax' THEN Audit.OldValue " &
                "WHEN FieldName = 'TaxAmount' THEN Audit.OldValue WHEN FieldName = 'Quantity' THEN Audit.OldValue WHEN FieldName = 'Rate' THEN Audit.OldValue " &
                "ELSE Audit.OldValue END AS OldValue, CASE WHEN FieldName = 'AccountExpenseId ' THEN " &
                "(Select AccountExpenseName From AccountExpense where AccountExpenseId = Audit.NewValue) " &
                "WHEN FieldName = 'AccountProjectId' THEN (Select ProjectName From AccountProject where AccountProjectId = Audit.NewValue) " &
                "WHEN FieldName = 'AccountCurrencyId' THEN (Select CurrencyCode From vueAccountCurrency where AccountCurrencyId = Audit.NewValue) " &
                "WHEN FieldName = 'AccountPaymentMethodId' THEN (Select PaymentMethod From AccountPaymentMethod where AccountPaymentMethodId = Audit.NewValue) " &
                "WHEN FieldName = 'AccountTaxZoneId' THEN (Select AccountTaxZone From AccountTaxZone where AccountTaxZoneId = Audit.NewValue) " &
                "WHEN FieldName = 'IsBillable' THEN CASE WHEN Audit.NewValue = '1' THEN 'Yes' " &
                "WHEN Audit.NewValue <> '1' THEN 'No' END WHEN FieldName = 'Reimburse' THEN CASE WHEN Audit.NewValue = '1' THEN 'Yes' WHEN Audit.NewValue <> '1' THEN " &
                "'No' END WHEN FieldName = 'Amount' THEN CONVERT(char(100), CONVERT(decimal(10, 2), Audit.NewValue)) " &
                "WHEN FieldName = 'AmountBeforeTax' THEN CONVERT(char(100), CONVERT(decimal(10, 2), Audit.NewValue)) " &
                "WHEN FieldName = 'TaxAmount' THEN CONVERT(char(100), CONVERT(decimal(10, 2), Audit.NewValue)) WHEN FieldName = 'Quantity' THEN CONVERT(char(100), " &
                "CONVERT(decimal(10, 2), Audit.NewValue)) WHEN FieldName = 'Rate' THEN CONVERT(char(100), CONVERT(decimal(10, 2), Audit.NewValue)) " &
                "ELSE Audit.NewValue END AS NewValue, " &
                "CASE WHEN FieldName = 'AccountProjectId' THEN 'ProjectName' WHEN FieldName = 'AccountExpenseId' THEN 'ExpenseName' WHEN FieldName = 'AccountPaymentMethodId' " &
                "THEN 'PaymentMethod' WHEN FieldName = 'AccountCurrencyId' THEN 'Currency' WHEN FieldName = 'AccountTaxZoneId' THEN 'TaxZone' ELSE Audit.FieldName END " &
                "AS FieldName, " &
                "CASE WHEN dbo.AccountPreferences.ShowEmployeeNameBy = 2  and dbo.AccountEmployee.IsDisabled = 1  THEN dbo.AccountEmployee.LastName + ' ' + dbo.AccountEmployee.FirstName + ' ' + '(Disbaled)' " &
                "WHEN dbo.AccountPreferences.ShowEmployeeNameBy = 2 and dbo.AccountEmployee.IsDisabled = 0 THEN dbo.AccountEmployee.LastName + ' ' + dbo.AccountEmployee.FirstName " &
                "WHEN dbo.AccountPreferences.ShowEmployeeNameBy = 1 and dbo.AccountEmployee.IsDisabled = 1 THEN dbo.AccountEmployee.FirstName + ' ' + dbo.AccountEmployee.LastName + ' ' + '(Disbaled)' " &
                "ELSE dbo.AccountEmployee.FirstName + ' ' + dbo.AccountEmployee.LastName END AS UpdatedBy, " &
                "dbo.AccountExpenseEntry.AccountExpenseEntryDate AS Date, dbo.AccountExpenseEntry.AccountProjectId, " &
                "dbo.AccountExpenseEntry.AccountExpenseId, dbo.AccountExpenseEntry.Amount, dbo.AccountProject.ProjectName, dbo.AccountExpense.AccountExpenseName, " &
                "dbo.AccountPaymentMethod.PaymentMethod, dbo.AccountTaxZone.AccountTaxZone, dbo.vueAccountCurrency.CurrencyCode " &
                "FROM dbo.AccountPreferences INNER JOIN " &
                "dbo.AccountEmployee ON dbo.AccountPreferences.AccountId = dbo.AccountEmployee.AccountId RIGHT OUTER JOIN " &
                "dbo.Audit LEFT OUTER JOIN " &
                "dbo.AccountExpenseEntry ON CONVERT(Int, dbo.Audit.PK) = dbo.AccountExpenseEntry.AccountExpenseEntryId ON " &
                "dbo.AccountEmployee.AccountEmployeeId = dbo.Audit.UserName LEFT OUTER JOIN " &
                "dbo.AccountProject ON dbo.AccountExpenseEntry.AccountProjectId = dbo.AccountProject.AccountProjectId LEFT OUTER JOIN " &
                "dbo.AccountExpense ON dbo.AccountExpenseEntry.AccountExpenseId = dbo.AccountExpense.AccountExpenseId LEFT OUTER JOIN " &
                "dbo.AccountPaymentMethod ON " &
                "dbo.AccountExpenseEntry.AccountPaymentMethodId = dbo.AccountPaymentMethod.AccountPaymentMethodId LEFT OUTER JOIN " &
                "dbo.AccountTaxZone ON dbo.AccountExpenseEntry.AccountTaxZoneId = dbo.AccountTaxZone.AccountTaxZoneId LEFT OUTER JOIN " &
                "dbo.vueAccountCurrency ON dbo.AccountExpenseEntry.AccountCurrencyId = dbo.vueAccountCurrency.AccountCurrencyId " &
                "WHERE (dbo.Audit.TableName = 'AccountExpenseEntry') AND (dbo.Audit.Type = 'U') AND (dbo.Audit.FieldName IN ('AccountExpenseEntryDate', 'AccountProjectId', " &
                "'AccountExpenseId', 'Description', 'Amount', 'IsBillable', 'Quantity', 'Rate', 'AmountBeforeTax', 'TaxAmount', 'Reimburse', 'AccountCurrencyId', " &
                "'AccountPaymentMethodId', 'AccountTaxZoneId')) and " & strsql1 &
                "UNION ALL " &
                "SELECT dbo.Audit.Type, dbo.Audit.TableName, dbo.Audit.PK, dbo.Audit.FieldName AS AuditFieldName, dbo.Audit.OldValue AS AuditOldVal, dbo.Audit.NewValue AS AuditNewVal, " &
                "dbo.Audit.UpdateDate, dbo.Audit.UserName, " &
                "CASE WHEN FieldName = 'ApprovedByEmployeeId' THEN AccountEmployeeOld.FirstName + ' ' + AccountEmployeeOld.LastName " &
                "WHEN FieldName = 'RejectedByEmployeeId' THEN AccountEmployeeOld.FirstName + ' ' + AccountEmployeeOld.LastName WHEN FieldName = 'Approved' THEN " &
                "CASE WHEN Audit.OldValue = '1' THEN 'Yes' WHEN " &
                "Audit.OldValue <> '1' THEN 'No' END WHEN FieldName = 'Submitted' THEN CASE WHEN Audit.OldValue = '1' THEN 'Yes' WHEN Audit.OldValue <> '1' THEN 'No' END WHEN " &
                "FieldName = 'Rejected' THEN CASE WHEN Audit.OldValue = '1' THEN 'Yes' WHEN Audit.OldValue <> '1' THEN 'No' END ELSE Audit.OldValue END AS OldValue, " &
                "CASE WHEN FieldName = 'ApprovedByEmployeeId' THEN AccountEmployeeNew.FirstName + ' ' + AccountEmployeeNew.LastName WHEN FieldName = 'RejectedByEmployeeId' " &
                "THEN AccountEmployeeNew.FirstName + ' ' + AccountEmployeeNew.LastName WHEN FieldName = 'SubmittedDate' THEN CONVERT(nvarchar(16), Audit.NewValue, 112) " &
                "WHEN FieldName = 'Approved' THEN CASE WHEN Audit.NewValue = '1' THEN 'Yes' WHEN Audit.NewValue <> '1' THEN 'No' END WHEN FieldName = 'Submitted' THEN " &
                "CASE WHEN Audit.NewValue = '1' THEN 'Yes' WHEN Audit.NewValue <> '1' THEN 'No' END WHEN FieldName = 'Rejected' THEN CASE WHEN Audit.NewValue = '1' THEN " &
                "'Yes' WHEN Audit.NewValue <> '1' THEN 'No' END ELSE Audit.NewValue END AS NewValue, " &
                "CASE WHEN FieldName = 'ApprovedByEmployeeId' THEN 'ApprovedBy' WHEN FieldName = 'RejectedByEmployeeId' THEN 'RejectedBy' ELSE Audit.FieldName END AS " &
                "FieldName, " &
                "CASE WHEN dbo.AccountPreferences.ShowEmployeeNameBy = 2  and dbo.AccountEmployee.IsDisabled = 1  THEN dbo.AccountEmployee.LastName + ' ' + dbo.AccountEmployee.FirstName + ' ' + '(Disbaled)' " &
                "WHEN dbo.AccountPreferences.ShowEmployeeNameBy = 2 and dbo.AccountEmployee.IsDisabled = 0 THEN dbo.AccountEmployee.LastName + ' ' + dbo.AccountEmployee.FirstName " &
                "WHEN dbo.AccountPreferences.ShowEmployeeNameBy = 1 and dbo.AccountEmployee.IsDisabled = 1 THEN dbo.AccountEmployee.FirstName + ' ' + dbo.AccountEmployee.LastName + ' ' + '(Disbaled)' " &
                "ELSE dbo.AccountEmployee.FirstName + ' ' + dbo.AccountEmployee.LastName END AS UpdatedBy, " &
                "dbo.AccountEmployeeExpenseSheet.ExpenseSheetDate AS Date, NULL AS AccountProjectId, NULL " &
                "AS AccountExpenseId, NULL AS Amount, NULL as ProjectName, NULL as AccountExpenseName, NULL as PaymentMethod, NULL as AccountTaxZone, NULL as CurrencyCode " &
                "FROM         dbo.AccountPreferences INNER JOIN " &
                "dbo.AccountEmployeeExpenseSheet ON dbo.AccountPreferences.AccountId = dbo.AccountEmployeeExpenseSheet.AccountId RIGHT OUTER JOIN " &
                "dbo.Audit ON dbo.AccountEmployeeExpenseSheet.AccountEmployeeExpenseSheetId = CONVERT(nvarchar(100), dbo.Audit.PK) LEFT OUTER JOIN " &
                "dbo.AccountEmployee AS AccountEmployeeOld ON dbo.Audit.OldValue = CONVERT(varchar, AccountEmployeeOld.AccountEmployeeId)  " &
                "LEFT OUTER JOIN " &
                "dbo.AccountEmployee AS AccountEmployeeNew ON dbo.Audit.NewValue = CONVERT(varchar, AccountEmployeeNew.AccountEmployeeId)  " &
                "LEFT OUTER JOIN " &
                "dbo.AccountEmployee ON dbo.Audit.UserName = dbo.AccountEmployee.AccountEmployeeId " &
                "WHERE (dbo.Audit.TableName = 'AccountEmployeeExpenseSheet') AND (dbo.Audit.Type = 'U') AND (dbo.Audit.FieldName IN (N'ExpenseSheetDate', N'Description', 'Submitted', " &
                "'Approved', 'Rejected', 'SubmittedDate', 'ApprovedOn', 'ApprovedByEmployeeId', 'RejectedByEmployeeId', 'RejectedOn')) and "
                strsql = strsql & strsql1
            ElseIf drDataSourceMapping.ReportDataSourceName = "Time Entry" Then
                SPForTimeEntryReport1(DBUtilities.GetSessionAccountEmployeeId, WhereClause)
                SPForTimeEntryReport2(DBUtilities.GetSessionAccountEmployeeId, WhereClause)
                SPForTimeEntryReport3(DBUtilities.GetSessionAccountEmployeeId, WhereClause)
                SPForTimeEntryReport4(DBUtilities.GetSessionAccountEmployeeId, WhereClause)
                strsql = "Select * from TimeEntryReport_" & DBUtilities.GetSessionAccountEmployeeId & "_4" & " WITH (NOLOCK)" & IIf(WhereClause <> "", " Where ", "") & WhereClause
                IsForTimeEntryReport = True
            Else
                strsql = "Select * from " & drDataSourceMapping.ReportDatasource & " WITH (NOLOCK)" & IIf(WhereClause <> "", " Where ", "") & WhereClause
            End If

            Dim OrderByStr As String

            If GetDefaultReportDataSourceSort(drDataSourceMapping.ReportDataSourceName) <> "" Then
                strsql = strsql & " Order By " & GetDefaultReportDataSourceSort(drDataSourceMapping.ReportDataSourceName)
                OrderByStr = " Order By " & GetDefaultReportDataSourceSort(drDataSourceMapping.ReportDataSourceName)
            End If

            Dim ReportIsBillable As Integer = IsBillableByWhere(WhereClause)
            Dim ReportIsReimburse As Integer = IsReimburseByWhere(WhereClause)

            If drDataSourceMapping.ReportDataSourceName = "Expense Sheet" Then
                If (ReportIsBillable = 1 Or ReportIsReimburse = 1) Or (ReportIsBillable = 0 Or ReportIsReimburse = 0) Then

                    Dim Billable_Reimburse_Where As String
                    Billable_Reimburse_Where = ExpenseSheetMakeWhere(ReportIsBillable, ReportIsReimburse)

                    strsql = "SELECT dbo.vueAccountEmployeeExpenseSheetForReport.AccountEmployeeExpenseSheetId, dbo.vueAccountEmployeeExpenseSheetForReport.AccountId, " &
                         "dbo.vueAccountEmployeeExpenseSheetForReport.AccountEmployeeId, dbo.vueAccountEmployeeExpenseSheetForReport.Description, dbo.vueAccountEmployeeExpenseSheetForReport.ExpenseSheetDate, " &
                         "dbo.vueAccountEmployeeExpenseSheetForReport.Currency, dbo.vueAccountEmployeeExpenseSheetForReport.CurrencyCode, " &
                         "dbo.vueAccountEmployeeExpenseSheetForReport.AccountCurrencyId, dbo.vueAccountEmployeeExpenseSheetForReport.Status, dbo.vueAccountEmployeeExpenseSheetForReport.InApproval, " &
                         "dbo.vueAccountEmployeeExpenseSheetForReport.Submitted, dbo.vueAccountEmployeeExpenseSheetForReport.Rejected, dbo.vueAccountEmployeeExpenseSheetForReport.Approved, " &
                         "dbo.vueAccountEmployeeExpenseSheetForReport.SubmittedDate, dbo.vueAccountEmployeeExpenseSheetForReport.EmployeeName, dbo.vueAccountEmployeeExpenseSheetForReport.EMailAddress, " &
                         "dbo.vueAccountEmployeeExpenseSheetForReport.DayNo, dbo.vueAccountEmployeeExpenseSheetForReport.MonthNo, dbo.vueAccountEmployeeExpenseSheetForReport.WeekNo, " &
                         "dbo.vueAccountEmployeeExpenseSheetForReport.Year, dbo.vueAccountEmployeeExpenseSheetForReport.Period, dbo.vueAccountEmployeeExpenseSheetForReport.WeekDayName, " &
                         "dbo.vueAccountEmployeeExpenseSheetForReport.DepartmentName, dbo.vueAccountEmployeeExpenseSheetForReport.Role, dbo.vueAccountEmployeeExpenseSheetForReport.AccountLocation, " &
                         "dbo.vueAccountEmployeeExpenseSheetForReport.AccountDepartmentId, dbo.vueAccountEmployeeExpenseSheetForReport.AccountLocationId, dbo.vueAccountEmployeeExpenseSheetForReport.AccountRoleId, " &
                         "dbo.vueAccountEmployeeExpenseSheetForReport.EmployeeCode, dbo.vueAccountEmployeeExpenseSheetForReport.DepartmentCode, dbo.vueAccountEmployeeExpenseSheetForReport.ExchangeRate, " &
                         "CASE WHEN dbo.vueAccountEmployeeExpenseSheetForReport.Approved = 1 THEN dbo.vueAccountEmployeeExpenseSheetForReport.ApprovedOn ELSE NULL END AS ApprovedDate, " &
                         "CASE WHEN dbo.vueAccountEmployeeExpenseSheetForReport.Rejected = 1 THEN dbo.vueAccountEmployeeExpenseSheetForReport.RejectedOn ELSE NULL END AS RejectedDate, " &
                         "dbo.AccountEmployee.FirstName + ' ' + dbo.AccountEmployee.LastName AS ApprovedByEmployeeName, AccountEmployee_1.FirstName + ' ' + AccountEmployee_1.LastName AS RejectedByEmployeeName, " &
                         "dbo.vueAccountEmployeeExpenseSheetForReport.CustomField1, dbo.vueAccountEmployeeExpenseSheetForReport.CustomField2, dbo.vueAccountEmployeeExpenseSheetForReport.CustomField3, " &
                         "dbo.vueAccountEmployeeExpenseSheetForReport.CustomField4, dbo.vueAccountEmployeeExpenseSheetForReport.CustomField5, dbo.vueAccountEmployeeExpenseSheetForReport.CustomField6, " &
                         "dbo.vueAccountEmployeeExpenseSheetForReport.CustomField7, dbo.vueAccountEmployeeExpenseSheetForReport.CustomField8, dbo.vueAccountEmployeeExpenseSheetForReport.CustomField9, " &
                         "dbo.vueAccountEmployeeExpenseSheetForReport.CustomField10, dbo.vueAccountEmployeeExpenseSheetForReport.CustomField11, dbo.vueAccountEmployeeExpenseSheetForReport.CustomField12, " &
                         "dbo.vueAccountEmployeeExpenseSheetForReport.CustomField13, dbo.vueAccountEmployeeExpenseSheetForReport.CustomField14, dbo.vueAccountEmployeeExpenseSheetForReport.CustomField15, " &
                         "ISNULL((Select SUM(ISNULL(Amount, 0)) from dbo.vueAccountEmployeeExpenseSheetOnlyAmount where " + Billable_Reimburse_Where + " And AccountEmployeeExpenseSheetId = dbo.vueAccountEmployeeExpenseSheetForReport.AccountEmployeeExpenseSheetId),0) As Amount, " &
                         "ISNULL((Select SUM(ISNULL(Amount, 0)) from dbo.vueAccountEmployeeExpenseSheetOnlyAmount where " + Billable_Reimburse_Where + " And AccountEmployeeExpenseSheetId = dbo.vueAccountEmployeeExpenseSheetForReport.AccountEmployeeExpenseSheetId),0) As CurrencyAmount " &
"FROM            dbo.AccountEmployee As AccountEmployee_1 RIGHT OUTER JOIN " &
                         "dbo.vueAccountEmployeeExpenseSheetForReport On AccountEmployee_1.AccountEmployeeId = dbo.vueAccountEmployeeExpenseSheetForReport.RejectedByEmployeeId LEFT OUTER JOIN " &
                         "dbo.AccountEmployee On dbo.vueAccountEmployeeExpenseSheetForReport.ApprovedByEmployeeId = dbo.AccountEmployee.AccountEmployeeId Where " + ChangeWhereClauseForExpenseSheet(WhereClause, True) + " " + OrderByStr

                End If
            End If

            If drDataSourceMapping.SystemReportDataSourceId = New Guid("ee5f3316-3a5e-484e-ae9e-9b11f0990997") Then

                Dim FilterStartDate = System.Web.HttpContext.Current.Session("FilterStartDate")
                Dim FilterEndDate = System.Web.HttpContext.Current.Session("FilterEndDate")

                Dim AssignedProject As DropDownList = Nothing
                Dim AssignedEmployee As DropDownList = Nothing
                Dim StatusFilter As ListBox = Nothing
                Dim Chk_DisabledFilter As CheckBox = Nothing
                Dim Chk_SubmittedFilter As RadioButton = Nothing
                Dim Chk_SavedFilter As RadioButton = Nothing
                Dim Chk_NotSavedFilter As RadioButton = Nothing
                Dim Chk_RejectedFilter As RadioButton = Nothing
                Dim DepartmentsHdn As HiddenField = Nothing

                If System.Web.HttpContext.Current.Session("chk_DisabledFilter") IsNot Nothing Then
                    Chk_DisabledFilter = CType(System.Web.HttpContext.Current.Session("chk_DisabledFilter"), CheckBox)
                End If

                If System.Web.HttpContext.Current.Session("DepartmentsListMultiHdnField") IsNot Nothing Then
                    DepartmentsHdn = CType(System.Web.HttpContext.Current.Session("DepartmentsListMultiHdnField"), HiddenField)
                End If

                If System.Web.HttpContext.Current.Session("FilterAssignedProject") IsNot Nothing Then
                    AssignedProject = CType(System.Web.HttpContext.Current.Session("FilterAssignedProject"), DropDownList)
                End If

                If System.Web.HttpContext.Current.Session("FilterAssignedEmployees") IsNot Nothing Then
                    AssignedEmployee = CType(System.Web.HttpContext.Current.Session("FilterAssignedEmployees"), DropDownList)
                End If

                If System.Web.HttpContext.Current.Session("SubmittedStatus") IsNot Nothing Then
                    Chk_SubmittedFilter = CType(System.Web.HttpContext.Current.Session("SubmittedStatus"), CheckBox)
                End If

                If System.Web.HttpContext.Current.Session("SavedStatus") IsNot Nothing Then
                    Chk_SavedFilter = CType(System.Web.HttpContext.Current.Session("SavedStatus"), RadioButton)
                End If

                If System.Web.HttpContext.Current.Session("NotSavedStatus") IsNot Nothing Then
                    Chk_NotSavedFilter = CType(System.Web.HttpContext.Current.Session("NotSavedStatus"), RadioButton)
                End If

                If System.Web.HttpContext.Current.Session("RejectedStatus") IsNot Nothing Then
                    Chk_RejectedFilter = CType(System.Web.HttpContext.Current.Session("RejectedStatus"), RadioButton)
                End If
                WhereClause = ""

                Dim ds As New DataSet("TimeSheetsFaults")
                Dim table As New DataTable()

                Using con = New SqlConnection(DBUtilities.GetConnectionString)
                    Using cmdSP = New SqlCommand("spTimeSheetsFaults", con)

                        cmdSP.Parameters.AddWithValue("@StartDateGET", LocaleUtilitiesBLL.ConvertDateToBaseLocaleAsString(FilterStartDate))
                        cmdSP.Parameters.AddWithValue("@EndDateGET", LocaleUtilitiesBLL.ConvertDateToBaseLocaleAsString(FilterEndDate))

                        If AssignedEmployee IsNot Nothing Then
                            If AssignedEmployee.SelectedValue <> 0 And AssignedEmployee.SelectedItem.Value IsNot Nothing Then
                                cmdSP.Parameters.AddWithValue("@AssignedEmployeeGET", AssignedEmployee.SelectedItem.Value)
                            Else
                                cmdSP.Parameters.AddWithValue("@AssignedEmployeeGET", DBNull.Value)
                            End If
                        Else
                            cmdSP.Parameters.AddWithValue("@AssignedEmployeeGET", DBNull.Value)
                        End If

                        If DepartmentsHdn IsNot Nothing Then
                            If DepartmentsHdn.Value <> "" Then
                                cmdSP.Parameters.AddWithValue("@BusinessUnitsList", DepartmentsHdn.Value)
                            Else
                                cmdSP.Parameters.AddWithValue("@BusinessUnitsList", DBNull.Value)
                            End If
                        Else
                            cmdSP.Parameters.AddWithValue("@BusinessUnitsList", DBNull.Value)
                        End If

                        If AssignedProject IsNot Nothing Then
                            If AssignedProject.SelectedValue <> 0 Then
                                cmdSP.Parameters.AddWithValue("@ProjectNameGET", AssignedProject.SelectedItem.ToString())
                            Else
                                cmdSP.Parameters.AddWithValue("@ProjectNameGET", DBNull.Value)
                            End If
                        Else
                            cmdSP.Parameters.AddWithValue("@ProjectNameGET", DBNull.Value)
                        End If

                        If Chk_DisabledFilter IsNot Nothing Then
                            If Chk_DisabledFilter.Checked Then
                                cmdSP.Parameters.AddWithValue("@DisabledGET", True) '1
                            Else
                                cmdSP.Parameters.AddWithValue("@DisabledGET", False) '0
                            End If
                        Else
                            cmdSP.Parameters.AddWithValue("@DisabledGET", False)
                        End If


                        Using da = New SqlDataAdapter(cmdSP)
                            cmdSP.CommandType = CommandType.StoredProcedure
                            da.Fill(table)
                        End Using
                    End Using
                End Using
                Dim FiltredTable As New DataTable
                FiltredTable = table.Clone()

                If Chk_NotSavedFilter.Checked = True Then 'Not Saved
                    Dim query = table.AsEnumerable().Where(Function(r) r.Field(Of String)("Status") = "Not Saved")
                    For Each item As DataRow In query
                        FiltredTable.ImportRow(item)
                    Next

                End If
                If Chk_SavedFilter.Checked = True Then 'Saved
                    Dim query = table.AsEnumerable().Where(Function(r) r.Field(Of String)("Status") = "Saved")
                    For Each item As DataRow In query
                        FiltredTable.ImportRow(item)
                    Next
                End If
                If Chk_SubmittedFilter.Checked = True Then 'Submited
                    Dim query = table.AsEnumerable().Where(Function(r) r.Field(Of String)("Status") = "Submitted")
                    For Each item As DataRow In query
                        FiltredTable.ImportRow(item)
                    Next
                End If
                If Chk_RejectedFilter.Checked = True Then 'Rejected
                    Dim query = table.AsEnumerable().Where(Function(r) r.Field(Of String)("Status") = "Rejected")
                    For Each item As DataRow In query
                        FiltredTable.ImportRow(item)
                    Next
                End If

                Dim dv As DataView = FiltredTable.DefaultView
                dv.Sort = "EmployeeName , TimeEntryDate"
                FiltredTable = dv.ToTable()

                Return GetDataTableBySystemReportDataSourceId(drDataSourceMapping.SystemReportDataSourceId, FiltredTable, MissingPeriodReportWhereClause, MissingPeriodReportStartAndEndDate, TimesheetPeriodType, WhereClause)
            End If


            If Right(strsql, 4).ToUpper = " AND" Then
                strsql = Left(strsql, strsql.Length - 4)
            End If


            objConnection = New SqlClient.SqlConnection(DBUtilities.GetConnectionString)
            Dim cmd As New SqlClient.SqlCommand(strsql, objConnection)
            sqladap.SelectCommand = cmd
            sqladap.SelectCommand.CommandTimeout = 9000000
            Dim dt As New DataTable
            sqladap.Fill(dt)

            If IsForTimeEntryReport Then
                DeleteTempTableForTimeEntryReport(DBUtilities.GetSessionAccountEmployeeId)
            End If
            Return GetDataTableBySystemReportDataSourceId(drDataSourceMapping.SystemReportDataSourceId, dt, MissingPeriodReportWhereClause, MissingPeriodReportStartAndEndDate, TimesheetPeriodType, WhereClause)

        End If
    End Function

    Public Shared Function GetDataTableBySystemReportDataSourceId(SystemReportDataSourceId As Guid, dt As DataTable, MissingPeriodReportWhereClause As String, MissingPeriodReportStartAndEndDate As Hashtable, ByVal TimesheetPeriodType As String, WhereClause As String) As DataTable
        If SystemReportDataSourceId = New Guid("18966956-9937-4DA0-A6F3-465E6066D433") Or SystemReportDataSourceId = New Guid("0a0c26be-01ee-41cd-9503-797d8ce7b834") Then
            Dim dtMissingTimesheetPeriod As DataTable = New AccountEmployeeTimeEntryBLL().GetMissingTimeEntryPeriodReport(MissingPeriodReportWhereClause, MissingPeriodReportStartAndEndDate, WhereClause)
            If TimesheetPeriodType = "Both" Then
                dt.Merge(dtMissingTimesheetPeriod)
                Return dt
            ElseIf TimesheetPeriodType = "MissingPeriods" Then
                Return dtMissingTimesheetPeriod
            ElseIf TimesheetPeriodType = "EnteredPeriods" Then
                Return dt
            End If
        ElseIf SystemReportDataSourceId = New Guid("665306D7-D2D5-4A9B-A248-B7AD53D587E8") Then
            Return New AccountEmployeeTimeEntryBLL().GetTimeEntryPeriodicSubmissionReport(dt, MissingPeriodReportStartAndEndDate)
        Else
            Return dt
        End If
    End Function
    Public Shared Function GetDefaultReportDataSourceSort(ByVal ReportDataSourceName As String) As String
        If ReportDataSourceName = "Time Entry" Or ReportDataSourceName = "Employee Time Off Detail" Then
            Return "TimeEntryDate"
        ElseIf ReportDataSourceName = "Expense Entry" Then
            Return "AccountExpenseEntryDate"
        ElseIf ReportDataSourceName = "Attendance" Then
            Return "AttendanceDate"
        ElseIf ReportDataSourceName = "Expense Sheet" Then
            Return "ExpenseSheetDate"
        ElseIf ReportDataSourceName = "Time Entry Period" Then
            Return "TimeEntryStartDate"
        ElseIf ReportDataSourceName = "Timesheet Audit Trail" Or ReportDataSourceName = "Expense Sheet Audit Trail" Then
            Return "UpdateDate desc"
        ElseIf ReportDataSourceName = "Employee Time Off Audit Report" Then
            Return "SortOrder desc"
        End If
        Return ""
    End Function
    Public Shared Function GetSystemReportDataSourceIdByAccountReportId(ByVal AccountReportId As Guid) As String
        Dim BLL As New LiveReportData
        Dim dtDataSourceMapping As dsReportDesign.vueAccountReportDataSourceMappingDataTable = BLL.GetvueAccountReportDataSourceMappingsByAccountReportId(AccountReportId)
        Dim drDataSourceMapping As dsReportDesign.vueAccountReportDataSourceMappingRow
        If dtDataSourceMapping.Rows.Count > 0 Then
            drDataSourceMapping = dtDataSourceMapping.Rows(0)
            Return drDataSourceMapping.SystemReportDataSourceId.ToString
        End If
    End Function
    Public Shared Sub SPForTimeEntryReport1(AccountEmployeeId As Integer, WhereClause As String)
        Dim objConnection As SqlConnection
        objConnection = New SqlConnection(DBUtilities.GetConnectionString)
        Dim sqlCommand As New SqlClient.SqlCommand
        sqlCommand.Connection = objConnection
        'Dim strSQL As String = "Execute sp_TimeEntryReport " & AccountEmployeeId & ", " & "' dbo.AccountEmployee.AccountId = " & DBUtilities.GetSessionAccountId & "'"
        sqlCommand.Parameters.Add("@AccountEmployeeId", SqlDbType.Int).Value = AccountEmployeeId
        sqlCommand.Parameters.Add("@WhereClause", SqlDbType.NVarChar).Value = ChangeWhereClauseForTimeEntryReport(WhereClause)
        sqlCommand.CommandText = "usp_TimeEntryReport1"
        sqlCommand.CommandType = CommandType.StoredProcedure
        sqlCommand.CommandTimeout = 9000000
        Dim recordsAffected As Integer
        objConnection.Open()
        recordsAffected = sqlCommand.ExecuteNonQuery()
        objConnection.Close()
    End Sub
    Public Shared Sub SPForTimeEntryReport2(AccountEmployeeId As Integer, WhereClause As String)
        Dim objConnection As SqlConnection
        objConnection = New SqlConnection(DBUtilities.GetConnectionString)
        Dim sqlCommand As New SqlClient.SqlCommand
        sqlCommand.Connection = objConnection
        'Dim strSQL As String = "Execute sp_TimeEntryReport " & AccountEmployeeId & ", " & "' dbo.AccountEmployee.AccountId = " & DBUtilities.GetSessionAccountId & "'"
        sqlCommand.Parameters.Add("@AccountEmployeeId", SqlDbType.Int).Value = AccountEmployeeId
        sqlCommand.Parameters.Add("@WhereClause", SqlDbType.NVarChar).Value = ChangeWhereClauseForTimeEntryReport(WhereClause)
        sqlCommand.CommandText = "usp_TimeEntryReport2"
        sqlCommand.CommandType = CommandType.StoredProcedure
        sqlCommand.CommandTimeout = 9000000
        Dim recordsAffected As Integer
        objConnection.Open()
        recordsAffected = sqlCommand.ExecuteNonQuery()
        objConnection.Close()
    End Sub
    Public Shared Sub SPForTimeEntryReport3(AccountEmployeeId As Integer, WhereClause As String)
        Dim objConnection As SqlConnection
        objConnection = New SqlConnection(DBUtilities.GetConnectionString)
        Dim sqlCommand As New SqlClient.SqlCommand
        sqlCommand.Connection = objConnection
        'Dim strSQL As String = "Execute sp_TimeEntryReport " & AccountEmployeeId & ", " & "' dbo.AccountEmployee.AccountId = " & DBUtilities.GetSessionAccountId & "'"
        sqlCommand.Parameters.Add("@AccountEmployeeId", SqlDbType.Int).Value = AccountEmployeeId
        sqlCommand.Parameters.Add("@WhereClause", SqlDbType.NVarChar).Value = ChangeWhereClauseForTimeEntryReport(WhereClause)
        sqlCommand.CommandText = "usp_TimeEntryReport3"
        sqlCommand.CommandType = CommandType.StoredProcedure
        sqlCommand.CommandTimeout = 9000000
        Dim recordsAffected As Integer
        objConnection.Open()
        recordsAffected = sqlCommand.ExecuteNonQuery()
        objConnection.Close()
    End Sub
    Public Shared Sub SPForTimeEntryReport4(AccountEmployeeId As Integer, WhereClause As String)
        Dim objConnection As SqlConnection
        objConnection = New SqlConnection(DBUtilities.GetConnectionString)
        Dim sqlCommand As New SqlClient.SqlCommand
        sqlCommand.Connection = objConnection
        'Dim strSQL As String = "Execute sp_TimeEntryReport " & AccountEmployeeId & ", " & "' dbo.AccountEmployee.AccountId = " & DBUtilities.GetSessionAccountId & "'"
        sqlCommand.Parameters.Add("@AccountEmployeeId", SqlDbType.Int).Value = AccountEmployeeId
        sqlCommand.Parameters.Add("@WhereClause", SqlDbType.NVarChar).Value = ChangeWhereClauseForTimeEntryReport(WhereClause)
        sqlCommand.CommandText = "usp_TimeEntryReport4"
        sqlCommand.CommandType = CommandType.StoredProcedure
        sqlCommand.CommandTimeout = 9000000
        Dim recordsAffected As Integer
        objConnection.Open()
        recordsAffected = sqlCommand.ExecuteNonQuery()
        objConnection.Close()
    End Sub
    Public Shared Sub DeleteTempTableForTimeEntryReport(AccountEmployeeId As Integer)
        Dim objConnection As SqlConnection
        objConnection = New SqlConnection(DBUtilities.GetConnectionString)
        Dim sqlCommand As New SqlClient.SqlCommand
        sqlCommand.Connection = objConnection
        sqlCommand.Parameters.Add("@AccountEmployeeId", SqlDbType.Int).Value = AccountEmployeeId
        sqlCommand.CommandText = "usp_DeleteTempTableForTimeEntryReport"
        sqlCommand.CommandType = CommandType.StoredProcedure
        sqlCommand.CommandTimeout = 900000
        Dim recordsAffected As Integer
        objConnection.Open()
        recordsAffected = sqlCommand.ExecuteNonQuery()
        objConnection.Close()
    End Sub
    Public Shared Function ChangeWhereClauseForTimeEntryReport(WhereClause As String) As String
        Dim str As String = ""
        str = Replace(WhereClause, "AccountId", "Mainview.AccountId")
        str = Replace(str, "AccountEmployeeId", "Mainview.AccountEmployeeId")
        str = Replace(str, "AccountProjectId", "Mainview.AccountProjectId")
        str = Replace(str, "TimeEntryDate", "Mainview.TimeEntryDate")
        str = Replace(str, "AccountClientId", "Mainview.AccountClientId")
        str = Replace(str, "AccountProjectTaskId", "Mainview.AccountProjectTaskId")
        str = Replace(str, "AccountDepartmentId", "Mainview.AccountDepartmentId")
        str = Replace(str, "AccountLocationId", "Mainview.AccountLocationId")
        str = Replace(str, "AccountRoleId", "Mainview.AccountRoleId")
        str = Replace(str, "AccountProjectTypeId", "Mainview.AccountProjectTypeId")
        str = Replace(str, "AccountWorkTypeId", "Mainview.AccountWorkTypeId")
        str = Replace(str, "AccountBaseCurrencyId", "Mainview.AccountBaseCurrencyId")
        str = Replace(str, "AccountCostCenterId", "Mainview.AccountCostCenterId")
        str = Replace(str, "Approved", "Mainview.Approved")
        str = Replace(str, "IsBillable", "Mainview.IsBillable")
        str = Replace(str, "Submitted", "Mainview.Submitted")
        str = Replace(str, "Billed", "Mainview.Billed")
        str = Replace(str, "IsTimeOff", "Mainview.IsTimeOff")
        Return str
    End Function

    Public Shared Function ChangeWhereClauseForExpenseSheet(WhereClause As String, EditBounds As Boolean) As String
        Dim str As String = ""

        If EditBounds = True Then
            str = Replace(WhereClause, "AccountId", "vueAccountEmployeeExpenseSheetForReport.AccountId")
            str = Replace(str, "AccountEmployeeId", "vueAccountEmployeeExpenseSheetForReport.AccountEmployeeId")
            str = Replace(str, "AccountDepartmentId", "vueAccountEmployeeExpenseSheetForReport.AccountDepartmentId")
            str = Replace(str, "AccountLocationId", "vueAccountEmployeeExpenseSheetForReport.AccountLocationId")
            str = Replace(str, "AccountRoleId", "vueAccountEmployeeExpenseSheetForReport.AccountRoleId")
        End If

        str = Replace(str, "and (IsBillable = 1) And (Reimburse = 1)", "") 'Billable True , Reimburse True
        str = Replace(str, "and (IsBillable = 1) And (Reimburse = 0)", "") 'Billable True , Reimbuse False
        str = Replace(str, "and ((IsBillable <> 1) Or (IsBillable Is null)) And (Reimburse = 1)", "") 'Billable False , Reimbuse True

        str = Replace(str, "and (Reimburse = 1)", "")
        str = Replace(str, "and (Reimburse = 0)", "")

        str = Replace(str, "And (Reimburse = 0)", "")
        str = Replace(str, "And (Reimburse = 1)", "")

        str = Replace(str, "And (IsBillable = 0)", "")
        str = Replace(str, "And (IsBillable = 1)", "")

        str = Replace(str, "And ((IsBillable <> 0) Or (IsBillable Is null))", "")
        str = Replace(str, "And ((IsBillable <> 1) Or (IsBillable Is null))", "")


        str = Replace(str, "and (IsBillable = 1)", "") 'Reimburse Both , Billable True
        str = Replace(str, "and ((IsBillable <> 1) Or (IsBillable Is null))", "") 'Reimburse Both , Billable False

        If Right(str, 4).ToUpper = "AND " Then
            WhereClause = Left(str, str.Length - 4)
        End If

        Return str
    End Function

    Public Shared Function IsBillableByWhere(WhereClause As String) As Integer
        Dim str As String = ""
        str = WhereClause

        If str.Contains("(IsBillable = 1)") Then
            Return 1
        End If
        If str.Contains("(IsBillable = 0)") Or str.Contains("(IsBillable <> 1") Then
            Return 0
        End If

        Return 2
    End Function

    Public Shared Function IsReimburseByWhere(WhereClause As String) As Integer
        Dim str As String = ""
        str = WhereClause

        If str.Contains("(Reimburse = 1)") Then
            Return 1
        End If
        If str.Contains("(Reimburse = 0)") Or str.Contains("(Reimburse <> 1") Then
            Return 0
        End If

        Return 2
    End Function

    Public Shared Function ExpenseSheetMakeWhere(ByVal Billable As Integer, ByVal Reimburse As Integer) As String
        Dim str As String = ""

        If Billable = 1 Then
            str = str + "IsBillable = 1"
        End If

        If Billable = 0 Then
            str = str + "IsBillable = 0"
        End If

        If Billable <> 2 And Reimburse <> 2 Then
            str = str + " and "
        End If

        If Reimburse = 1 Then
            str = str + "Reimburse = 1"
        End If

        If Reimburse = 0 Then
            str = str + "Reimburse = 0"
        End If

        Return str
    End Function


End Class
