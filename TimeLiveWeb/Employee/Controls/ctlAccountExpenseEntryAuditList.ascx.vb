Imports SMInformatik.Util
Partial Class Employee_Controls_ctlAccountExpenseEntryAuditList
    Inherits System.Web.UI.UserControl
    Dim OldVal As String
    Dim NewVal As String
    Dim AccountExpenseId As Integer
    Dim AccountProjectId As Integer
    Dim AccountPaymentMethodId As Integer
    Dim AccountCurrencyId As Integer
    Dim AccountTaxZoneId As Integer
    Dim AccountEmployeeId As Integer
    Public Sub SetAndUpdateValuesForExpenseEntryAudit()
        Dim AccountEmployeeExpenseSheetId As New Guid(Me.Request.QueryString("AccountEmployeeExpenseSheetId"))
        Dim BLL As New AccountExpenseEntryAuditBLL
        Dim dt As AccountExpenseEntryAudit.AccountExpenseEntryAuditDataTable
        Dim AccountExpense As New AccountExpenseBLL
        Dim dtExpense As TimeLiveDataSet.AccountExpenseDataTable
        Dim AccountProjectBLL As New AccountProjectBLL
        Dim dtProject As TimeLiveDataSet.AccountProjectDataTable
        Dim AccountPaymentMethod As New AccountPaymentMethodBLL
        Dim dtPaymentMethod As TimeLiveDataSet.AccountPaymentMethodDataTable
        Dim AccountCurrency As New AccountCurrencyBLL
        Dim dtCurrency As AccountCurrency.vueAccountCurrencyDataTable
        Dim AccountTaxZone As New AccountTaxZoneBLL
        Dim dtTaxZone As TimeLiveDataSet.AccountTaxZoneDataTable
        dt = BLL.GetAccountExpenseEntryAuditByEmployeeExpenseSheetId(AccountEmployeeExpenseSheetId)
        dt.Columns.Add("OldForeignValue")
        dt.Columns.Add("NewForeignValue")
        Dim objRow As AccountExpenseEntryAudit.AccountExpenseEntryAuditRow
        If dt.Rows.Count >= 1 And Not IsDBNull(dt.Rows.Item(0)("FieldName")) Then
            For Each objRow In dt.Rows
                'For AccountExpenseId
                If objRow.FieldName = "AccountExpenseId" Then
                    objRow.FieldName = "ExpenseName"
                    AccountExpenseId = objRow("OldValue")
                    dtExpense = AccountExpense.GetAccountExpensesByAccountExpenseId(AccountExpenseId)
                    Dim objExpenseRow As TimeLiveDataSet.AccountExpenseRow
                    If dtExpense.Rows.Count > 0 Then
                        objExpenseRow = dtExpense.Rows(0)
                        dt.Columns("OldForeignValue").DefaultValue = objExpenseRow("AccountExpenseName")
                        OldVal = IIf(IsDBNull(dt.Columns("OldForeignValue").DefaultValue), OldVal, dt.Columns("OldForeignValue").DefaultValue)
                        objRow("OldValue") = OldVal
                    End If
                    AccountExpenseId = objRow("NewValue")
                    dtExpense = AccountExpense.GetAccountExpensesByAccountExpenseId(AccountExpenseId)
                    If dtExpense.Rows.Count > 0 Then
                        objExpenseRow = dtExpense.Rows(0)
                        dt.Columns("NewForeignValue").DefaultValue = objExpenseRow("AccountExpenseName")
                        NewVal = IIf(IsDBNull(dt.Columns("NewForeignValue").DefaultValue), NewVal, dt.Columns("NewForeignValue").DefaultValue)
                        objRow("NewValue") = NewVal
                    End If
                End If
                'For AccountProjectId
                If objRow.FieldName = "AccountProjectId" Then
                    objRow.FieldName = "ProjectName"
                    AccountProjectId = objRow("OldValue")
                    dtProject = AccountProjectBLL.GetAccountProjectsByAccountProjectId(AccountProjectId)
                    Dim objProjectRow As TimeLiveDataSet.AccountProjectRow
                    If dtProject.Rows.Count > 0 Then
                        objProjectRow = dtProject.Rows(0)
                        dt.Columns("OldForeignValue").DefaultValue = objProjectRow("ProjectName")
                        OldVal = IIf(IsDBNull(dt.Columns("OldForeignValue").DefaultValue), OldVal, dt.Columns("OldForeignValue").DefaultValue)
                        objRow("OldValue") = OldVal
                    End If
                    AccountProjectId = objRow("NewValue")
                    dtProject = AccountProjectBLL.GetAccountProjectsByAccountProjectId(AccountProjectId)
                    If dtProject.Rows.Count > 0 Then
                        objProjectRow = dtProject.Rows(0)
                        dt.Columns("NewForeignValue").DefaultValue = objProjectRow("ProjectName")
                        NewVal = IIf(IsDBNull(dt.Columns("NewForeignValue").DefaultValue), NewVal, dt.Columns("NewForeignValue").DefaultValue)
                        objRow("NewValue") = NewVal
                    End If
                End If
                'For AccountPaymentMethodId
                If objRow.FieldName = "AccountPaymentMethodId" Then
                    objRow.FieldName = "PaymentMethod"
                    AccountPaymentMethodId = IIf(IsDBNull(objRow("OldValue")), Nothing, objRow("OldValue"))
                    dtPaymentMethod = AccountPaymentMethod.GetAccountPaymentMethodByAccountPaymentMethodId(AccountPaymentMethodId)
                    Dim objPaymentMethodRow As TimeLiveDataSet.AccountPaymentMethodRow
                    If dtPaymentMethod.Rows.Count > 0 Then
                        objPaymentMethodRow = dtPaymentMethod.Rows(0)
                        dt.Columns("OldForeignValue").DefaultValue = objPaymentMethodRow("PaymentMethod")
                        OldVal = IIf(IsDBNull(dt.Columns("OldForeignValue").DefaultValue), OldVal, dt.Columns("OldForeignValue").DefaultValue)
                        objRow("OldValue") = OldVal
                    End If
                    AccountPaymentMethodId = IIf(IsDBNull(objRow("NewValue")), Nothing, objRow("NewValue"))
                    dtPaymentMethod = AccountPaymentMethod.GetAccountPaymentMethodByAccountPaymentMethodId(AccountPaymentMethodId)
                    If dtPaymentMethod.Rows.Count > 0 Then
                        objPaymentMethodRow = dtPaymentMethod.Rows(0)
                        dt.Columns("NewForeignValue").DefaultValue = objPaymentMethodRow("PaymentMethod")
                        NewVal = IIf(IsDBNull(dt.Columns("NewForeignValue").DefaultValue), NewVal, dt.Columns("NewForeignValue").DefaultValue)
                        objRow("NewValue") = NewVal
                    End If
                End If
                'For AccountCurrencyId
                If objRow.FieldName = "AccountCurrencyId" Then
                    objRow.FieldName = "Currency"
                    AccountCurrencyId = IIf(IsDBNull(objRow("OldValue")), Nothing, objRow("OldValue"))
                    dtCurrency = AccountCurrency.GetvueAccountCurrencyByAccountCurrencyId(AccountCurrencyId)
                    Dim objCurrencyRow As AccountCurrency.vueAccountCurrencyRow
                    If dtCurrency.Rows.Count > 0 Then
                        objCurrencyRow = dtCurrency.Rows(0)
                        dt.Columns("OldForeignValue").DefaultValue = objCurrencyRow("CurrencyCode")
                        OldVal = IIf(IsDBNull(dt.Columns("OldForeignValue").DefaultValue), OldVal, dt.Columns("OldForeignValue").DefaultValue)
                        objRow("OldValue") = OldVal
                    End If
                    AccountCurrencyId = IIf(IsDBNull(objRow("NewValue")), Nothing, objRow("NewValue"))
                    dtCurrency = AccountCurrency.GetvueAccountCurrencyByAccountCurrencyId(AccountCurrencyId)
                    If dtCurrency.Rows.Count > 0 Then
                        objCurrencyRow = dtCurrency.Rows(0)
                        dt.Columns("NewForeignValue").DefaultValue = objCurrencyRow("CurrencyCode")
                        NewVal = IIf(IsDBNull(dt.Columns("NewForeignValue").DefaultValue), NewVal, dt.Columns("NewForeignValue").DefaultValue)
                        objRow("NewValue") = NewVal
                    End If
                End If
                'For AccountTaxZoneId
                If objRow.FieldName = "AccountTaxZoneId" Then
                    objRow.FieldName = "TaxZone"
                    AccountTaxZoneId = IIf(IsDBNull(objRow("OldValue")), Nothing, objRow("OldValue"))
                    dtTaxZone = AccountTaxZone.GetAccountTaxZonesByAccountTaxZoneId(AccountTaxZoneId)
                    Dim ObjTaxZoneRow As TimeLiveDataSet.AccountTaxZoneRow
                    If dtTaxZone.Rows.Count > 0 Then
                        ObjTaxZoneRow = dtTaxZone.Rows(0)
                        dt.Columns("OldForeignValue").DefaultValue = ObjTaxZoneRow("AccountTaxZone")
                        OldVal = IIf(IsDBNull(dt.Columns("OldForeignValue").DefaultValue), OldVal, dt.Columns("OldForeignValue").DefaultValue)
                        objRow("OldValue") = OldVal
                    End If
                    AccountTaxZoneId = IIf(IsDBNull(objRow("NewValue")), Nothing, objRow("NewValue"))
                    dtTaxZone = AccountTaxZone.GetAccountTaxZonesByAccountTaxZoneId(AccountTaxZoneId)
                    If dtTaxZone.Rows.Count > 0 Then
                        ObjTaxZoneRow = dtTaxZone.Rows(0)
                        dt.Columns("NewForeignValue").DefaultValue = ObjTaxZoneRow("AccountTaxZone")
                        NewVal = IIf(IsDBNull(dt.Columns("NewForeignValue").DefaultValue), NewVal, dt.Columns("NewForeignValue").DefaultValue)
                        objRow("NewValue") = NewVal
                    End If
                End If
            Next
        End If
        Dim GridView1 As New GridView
        Me.gvExpenseEntryAudit.DataSource = dt
        Me.gvExpenseEntryAudit.DataBind()
        IIf(IsDBNull("OldForeignValue"), OldVal, NewVal)
        IIf(IsDBNull("NewForeignValue"), NewVal, OldVal)
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Me.SetAndUpdateValuesForExpenseEntryAudit()
            Me.SetAndUpdateValuesForExpenseSheetAudit()
        End If
    End Sub
    Protected Sub gvExpenseEntryAudit_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvExpenseEntryAudit.RowDataBound
        'UIUtilities.ClearCellsForNoRecords(e.Row)
        If e.Row.RowType = DataControlRowType.DataRow Then
            If Not IsDBNull(DataBinder.Eval(e.Row.DataItem, "ProjectName")) Then
                CType(e.Row.Cells(1).FindControl("Label2"), Label).Text = IIf(DataBinder.Eval(e.Row.DataItem, "ProjectName").ToString.Length > 25, Left(DataBinder.Eval(e.Row.DataItem, "ProjectName"), 23) & "..", DataBinder.Eval(e.Row.DataItem, "ProjectName"))
                If DataBinder.Eval(e.Row.DataItem, "ProjectName").ToString.Length > 25 Then
                    CType(e.Row.Cells(1).FindControl("Label2"), Label).ToolTip = DataBinder.Eval(e.Row.DataItem, "ProjectName")
                End If
            End If
            If Not IsDBNull(DataBinder.Eval(e.Row.DataItem, "AccountExpenseName")) Then
                CType(e.Row.Cells(2).FindControl("Label3"), Label).Text = IIf(DataBinder.Eval(e.Row.DataItem, "AccountExpenseName").ToString.Length > 25, Left(DataBinder.Eval(e.Row.DataItem, "AccountExpenseName"), 23) & "..", DataBinder.Eval(e.Row.DataItem, "AccountExpenseName"))
                If DataBinder.Eval(e.Row.DataItem, "AccountExpenseName").ToString.Length > 25 Then
                    CType(e.Row.Cells(2).FindControl("Label3"), Label).ToolTip = DataBinder.Eval(e.Row.DataItem, "AccountExpenseName")
                End If
            End If
                If CType(e.Row.Cells(0).FindControl("Label1"), Label).Text <> "" Then
                    Dim SysDatetime As DateTime = CType(e.Row.Cells(0).FindControl("Label1"), Label).Text
                    Dim dtdatetime As SMDateTime
                    With SysDatetime
                        dtdatetime = New SMDateTime(SMTimeZone.CurrentTimeZone, .Year, .Month, .Day, .Hour, .Minute, .Second)
                    End With
                    SysDatetime = LocaleUtilitiesBLL.GetCurrentDateTimeFromUserTimeZoneForSMTimeZone(dtdatetime, GetTimeZoneId(DBUtilities.GetSessionAccountEmployeeId))
                    CType(e.Row.Cells(0).FindControl("Label1"), Label).Text = SysDatetime
                End If

            
                UpdateDoubleDataTypeFields(e.Row)
                UpdateBooleanDataTypeFields(e.Row, False)
                UpdateDateTimeDataTypeFields(e.Row, False)
        End If
       
    End Sub
    Public Sub UpdateDateTimeDataTypeFields(ByVal Row As GridViewRow, ByVal IsFromExpenseSheetGrid As Boolean)
        Dim LabelText As String = CType(Row.Cells(IIf(IsFromExpenseSheetGrid, 2, 5)).FindControl("lblFieldName"), Label).Text
        If LabelText = "AccountExpenseEntryDate" Or LabelText = "ExpenseSheetDate" Or LabelText = "SubmittedDate" Or LabelText = "ApprovedOn" Or LabelText = "RejectedOn" Then
            UpdateNewAndOldValuesForDateTimeFields(Row, IsFromExpenseSheetGrid)
        End If
    End Sub
    Public Sub UpdateDoubleDataTypeFields(ByVal row As GridViewRow)
        Dim LabelText As String = CType(row.Cells(5).FindControl("lblFieldName"), Label).Text
        If LabelText = "Amount" Or LabelText = "AmountBeforeTax" Or LabelText = "TaxAmount" Or LabelText = "Quantity" Or LabelText = "Rate" Then
            UpdateOldAndNewValuesForDoubleFields(row)
        End If
    End Sub
    Public Sub UpdateBooleanDataTypeFields(ByVal row As GridViewRow, ByVal IsFromExpenseSheetGrid As Boolean)
        Dim LabelText As String = CType(row.Cells(IIf(IsFromExpenseSheetGrid, 2, 5)).FindControl("lblFieldName"), Label).Text
        If LabelText = "IsBillable" Or LabelText = "Reimburse" Or LabelText = "Approved" Or LabelText = "Rejected" Or LabelText = "Submitted" Then
            UpdateOldAndNewValuesForBooleanFields(row, IsFromExpenseSheetGrid)
        End If
    End Sub
    Public Sub UpdateOldAndNewValuesForDoubleFields(ByVal row As GridViewRow)
        CType(row.Cells(6).FindControl("lblOldValue"), Label).Text = String.Format("{0:N}", CDbl(DataBinder.Eval(row.DataItem, "OldValue")))
        CType(row.Cells(7).FindControl("lblNewValue"), Label).Text = String.Format("{0:N}", CDbl(DataBinder.Eval(row.DataItem, "NewValue")))
    End Sub
    Public Sub UpdateOldAndNewValuesForBooleanFields(ByVal row As GridViewRow, ByVal IsFromExpenseSheetGrid As Boolean)
        CType(row.Cells(IIf(IsFromExpenseSheetGrid, 3, 6)).FindControl("lblOldValue"), Label).Text = IIf(DataBinder.Eval(row.DataItem, "OldValue").ToString <> "1", "No", "Yes")
        CType(row.Cells(IIf(IsFromExpenseSheetGrid, 4, 7)).FindControl("lblNewValue"), Label).Text = IIf(DataBinder.Eval(row.DataItem, "NewValue").ToString <> "1", "No", "Yes")
    End Sub
    Public Sub UpdateNewAndOldValuesForDateTimeFields(ByVal row As GridViewRow, ByVal IsFromExpenseSheetGrid As Boolean)
        Dim OldValue As String = ""
        Dim NewValue As String = ""
        If Not IsDBNull(DataBinder.Eval(row.DataItem, "OldValue")) Then
            OldValue = Convert.ToDateTime(DataBinder.Eval(row.DataItem, "OldValue"))
        End If
        If Not IsDBNull(DataBinder.Eval(row.DataItem, "NewValue")) Then
            NewValue = Convert.ToDateTime(DataBinder.Eval(row.DataItem, "NewValue"))
        End If
        CType(row.Cells(IIf(IsFromExpenseSheetGrid, 3, 6)).FindControl("lblOldValue"), Label).Text = OldValue
        CType(row.Cells(IIf(IsFromExpenseSheetGrid, 4, 7)).FindControl("lblNewValue"), Label).Text = NewValue
    End Sub
    Protected Sub gvExpenseSheetAudit_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvExpenseSheetAudit.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            If CType(e.Row.Cells(0).FindControl("Label1"), Label).Text <> "" Then
                Dim SysDatetime As DateTime = CType(e.Row.Cells(0).FindControl("Label1"), Label).Text
                Dim dtdatetime As SMDateTime
                With SysDatetime
                    dtdatetime = New SMDateTime(SMTimeZone.CurrentTimeZone, .Year, .Month, .Day, .Hour, .Minute, .Second)
                End With
                SysDatetime = LocaleUtilitiesBLL.GetCurrentDateTimeFromUserTimeZoneForSMTimeZone(dtdatetime, GetTimeZoneId(DBUtilities.GetSessionAccountEmployeeId))
                CType(e.Row.Cells(0).FindControl("Label1"), Label).Text = SysDatetime
            End If
            UpdateBooleanDataTypeFields(e.Row, True)
            UpdateDateTimeDataTypeFields(e.Row, True)
        End If
    End Sub
    Public Sub SetAndUpdateValuesForExpenseSheetAudit()
        Dim AccountEmployeeExpenseSheetId As New Guid(Me.Request.QueryString("AccountEmployeeExpenseSheetId"))
        Dim BLL As New AccountExpenseEntryAuditBLL
        Dim dt As AccountExpenseEntryAudit.AccountEmployeeExpenseSheetAuditDataTable
        Dim EmployeeBLL As New AccountEmployeeBLL
        Dim dtEmployee As AccountEmployee.AccountEmployeeDataTable
        dt = BLL.GetAccountEmployeeExpenseSheetAuditByEmployeeExpenseSheetId(AccountEmployeeExpenseSheetId.ToString)
        dt.Columns.Add("OldForeignValue")
        dt.Columns.Add("NewForeignValue")
        Dim objRow As AccountExpenseEntryAudit.AccountEmployeeExpenseSheetAuditRow
        If dt.Rows.Count >= 1 And Not IsDBNull(dt.Rows.Item(0)("FieldName")) Then
            For Each objRow In dt.Rows
                'For ApprovedBy
                If objRow.FieldName = "ApprovedByEmployeeId" Then
                    objRow.FieldName = "ApprovedBy"
                    AccountEmployeeId = IIf(IsDBNull(objRow("OldValue")), 0, objRow("OldValue"))
                    dtEmployee = EmployeeBLL.GetAccountEmployeesByAccountEmployeeId(AccountEmployeeId)
                    Dim objEmployeeRow As AccountEmployee.AccountEmployeeRow
                    If dtEmployee.Rows.Count > 0 Then
                        objEmployeeRow = dtEmployee.Rows(0)
                        dt.Columns("OldForeignValue").DefaultValue = objEmployeeRow("FirstName") & " " & objEmployeeRow("LastName")
                        OldVal = IIf(IsDBNull(dt.Columns("OldForeignValue").DefaultValue), OldVal, dt.Columns("OldForeignValue").DefaultValue)
                        objRow("OldValue") = OldVal
                    End If
                    AccountEmployeeId = IIf(IsDBNull(objRow("NewValue")), 0, objRow("NewValue"))
                    dtEmployee = EmployeeBLL.GetAccountEmployeesByAccountEmployeeId(AccountEmployeeId)
                    If dtEmployee.Rows.Count > 0 Then
                        objEmployeeRow = dtEmployee.Rows(0)
                        dt.Columns("NewForeignValue").DefaultValue = objEmployeeRow("FirstName") & " " & objEmployeeRow("LastName")
                        NewVal = IIf(IsDBNull(dt.Columns("NewForeignValue").DefaultValue), NewVal, dt.Columns("NewForeignValue").DefaultValue)
                        objRow("NewValue") = NewVal
                    End If
                End If
                'For RejectedBy
                If objRow.FieldName = "RejectedByEmployeeId" Then
                    objRow.FieldName = "RejectedBy"
                    AccountEmployeeId = IIf(IsDBNull(objRow("OldValue")), 0, objRow("OldValue"))
                    dtEmployee = EmployeeBLL.GetAccountEmployeesByAccountEmployeeId(AccountEmployeeId)
                    Dim objEmployeeRow As AccountEmployee.AccountEmployeeRow
                    If dtEmployee.Rows.Count > 0 Then
                        objEmployeeRow = dtEmployee.Rows(0)
                        dt.Columns("OldForeignValue").DefaultValue = objEmployeeRow("FirstName") & " " & objEmployeeRow("LastName")
                        OldVal = IIf(IsDBNull(dt.Columns("OldForeignValue").DefaultValue), OldVal, dt.Columns("OldForeignValue").DefaultValue)
                        objRow("OldValue") = OldVal
                    End If
                    AccountEmployeeId = IIf(IsDBNull(objRow("NewValue")), 0, objRow("NewValue"))
                    dtEmployee = EmployeeBLL.GetAccountEmployeesByAccountEmployeeId(AccountEmployeeId)
                    If dtEmployee.Rows.Count > 0 Then
                        objEmployeeRow = dtEmployee.Rows(0)
                        dt.Columns("NewForeignValue").DefaultValue = objEmployeeRow("FirstName") & " " & objEmployeeRow("LastName")
                        NewVal = IIf(IsDBNull(dt.Columns("NewForeignValue").DefaultValue), NewVal, dt.Columns("NewForeignValue").DefaultValue)
                        objRow("NewValue") = NewVal
                    End If
                End If
            Next
        End If
        gvExpenseSheetAudit.DataSource = dt
        gvExpenseSheetAudit.DataBind()
        IIf(IsDBNull("OldForeignValue"), OldVal, NewVal)
        IIf(IsDBNull("NewForeignValue"), NewVal, OldVal)
    End Sub
    ''' <summary>
    ''' Get timezone id
    ''' </summary>
    ''' <param name="AccountEmployeeID"></param>
    ''' <returns>timezoneid</returns>
    ''' <remarks></remarks>
    Public Shared Function GetTimeZoneId(ByVal AccountEmployeeID As Integer) As Byte
        Dim dt As AccountEmployee.AccountEmployeeDataTable = New AccountEmployeeBLL().GetAccountEmployeesByAccountEmployeeId(AccountEmployeeID)
        Dim dr As AccountEmployee.AccountEmployeeRow
        If dt.Rows.Count > 0 Then
            dr = dt.Rows(0)
            If Not IsDBNull(dr.Item("TimeZoneId")) Then
                Return dr.TimeZoneId
            End If
        End If
        Return 6
    End Function
End Class

