Imports AccountExpenseEntryforBillingTableAdapters
Imports Bestcode.MathParser
Imports AccountTimeExpenseBilling

Partial Class ProjectAdmin_Controls_ctlAccountInvoiceForm
    Inherits System.Web.UI.UserControl
    Dim objTimeSheet As New AccountTimeExpenseBillingBLL
    Dim BilledAmount As Double = 0
    Dim TimesheetAmount As Double = 0
    Dim TotalTime As Integer
    Dim taxtotal1 As Double
    Dim ExpenseTaxTotal1 As Double
    Dim taxtotal2 As Double
    Dim ExpenseTaxTotal2 As Double
    Dim invoiceno As Integer
    Dim PrintInvoice As Boolean = False
    Dim InvoiceExchangeRate As Double = 0
    Dim IsPopulate As Boolean = False
    Dim taxtotaltimesheet1 As Double = 0
    Dim taxtotalexpense1 As Double = 0
    Dim taxtotaltimesheet2 As Double = 0
    Dim taxtotalexpense2 As Double = 0
    Dim AccountProjectId As Integer = 0
    Dim GrandTotalAmount As Double = 0
    Public Sub ShowGrid()
        Me.dsAccountTimeExpenseBillingTimesheetObject.SelectParameters("BillingCycleStartDate").DefaultValue = CType(Me.FormView1.FindControl("BillingCycleStartDateTextBox"), eWorld.UI.CalendarPopup).SelectedDate
        Me.dsAccountTimeExpenseBillingTimesheetObject.SelectParameters("BillingCycleEndDate").DefaultValue = CType(Me.FormView1.FindControl("BillingCycleEndDateTextBox"), eWorld.UI.CalendarPopup).SelectedDate
        Me.dsAccountTimeExpenseBillingExpenseObject.SelectParameters("BillingCycleStartDate").DefaultValue = CType(Me.FormView1.FindControl("BillingCycleStartDateTextBox"), eWorld.UI.CalendarPopup).SelectedDate
        Me.dsAccountTimeExpenseBillingExpenseObject.SelectParameters("BillingCycleEndDate").DefaultValue = CType(Me.FormView1.FindControl("BillingCycleEndDateTextBox"), eWorld.UI.CalendarPopup).SelectedDate
        Me.dsAccountTimeExpenseBillingTimesheetObject.SelectParameters("AccountClientId").DefaultValue = CType(Me.FormView1.FindControl("ddlClientId"), DropDownList).SelectedValue
        Me.dsAccountTimeExpenseBillingExpenseObject.SelectParameters("AccountClientId").DefaultValue = CType(Me.FormView1.FindControl("ddlClientId"), DropDownList).SelectedValue
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not Me.IsPostBack Then
                If Not Me.Request.QueryString("AccountTimeExpenseBillingId") Is Nothing Then
                    Me.FormView1.ChangeMode(FormViewMode.Edit)
                    Me.FormView2.ChangeMode(FormViewMode.Edit)
                    Me.dsAccountTimeExpenseBillingObject.SelectParameters("AccountTimeExpenseBillingId").DefaultValue = Me.Request.QueryString("AccountTimeExpenseBillingId")
                    Me.dsAccountTimeExpenseBilling.SelectParameters("AccountTimeExpenseBillingId").DefaultValue = Me.Request.QueryString("AccountTimeExpenseBillingId")
                    Me.dsAccountTimeExpenseBillingTimesheetObject.SelectParameters("AccountTimeExpenseBillingId").DefaultValue = Me.Request.QueryString("AccountTimeExpenseBillingId")
                    Me.dsAccountTimeExpenseBillingExpenseObject.SelectParameters("AccountTimeExpenseBillingId").DefaultValue = Me.Request.QueryString("AccountTimeExpenseBillingId")
                    If CType(Me.FormView1.FindControl("ddlInvoiceGroup"), DropDownList).SelectedValue = "Task" Then
                        Me.dsAccountTimeExpenseBillingTimesheetObject.SelectParameters("IsParent").DefaultValue = False
                    Else
                        Me.dsAccountTimeExpenseBillingTimesheetObject.SelectParameters("IsParent").DefaultValue = True
                    End If
                    Me.btnPrint.Visible = True
                End If
            End If
            If CType(Me.FormView1.FindControl("ddlInvoiceGroup"), DropDownList).SelectedValue <> "ParentTask" Then
                Me.GridView1.Columns(3).Visible = True
                Me.GridView1.Columns(4).Visible = True
            Else
                Me.GridView1.Columns(3).Visible = False
                Me.GridView1.Columns(4).Visible = False
            End If
        Catch ex As Exception
            Dim label As String = ""
        End Try
        ''If CType(Me.FormView1.FindControl("ddlInvoiceGroup"), DropDownList).SelectedValue = "Task" Then
        ''    Me.dsAccountTimeExpenseBillingTimesheetObject.SelectParameters("AccountTimeExpenseBillingId").DefaultValue
        ''End If
    End Sub
    Public Sub InsertAccountTimeExpenseBilling()
        With dsAccountTimeExpenseBillingObject
            .InsertParameters("AccountId").DefaultValue = DBUtilities.GetSessionAccountId
            .InsertParameters("InvoiceNo").DefaultValue = CType(Me.FormView1.FindControl("InvoiceNoTextBox"), TextBox).Text
            .InsertParameters("InvoiceDate").DefaultValue = CType(Me.FormView1.FindControl("InvoiceDateTextBox"), eWorld.UI.CalendarPopup).SelectedDate
            .InsertParameters("PONumber").DefaultValue = CType(Me.FormView1.FindControl("PONumberTextBox"), TextBox).Text
            .InsertParameters("AccountProjectId").DefaultValue = CType(Me.FormView1.FindControl("ddlAccountProjectId"), DropDownList).SelectedValue
            .InsertParameters("GroupTimesheetBillingListBy").DefaultValue = CType(Me.FormView1.FindControl("ddlInvoiceGroup"), DropDownList).SelectedValue
            .InsertParameters("GroupExpenseBillingListBy").DefaultValue = CType(Me.FormView1.FindControl("ddlExpenseInvoiceGroup"), DropDownList).SelectedValue
            .InsertParameters("ParentAccountProjectTaskId").DefaultValue = CType(Me.FormView1.FindControl("ddlParentTaskId"), DropDownList).SelectedValue
            .InsertParameters("AccountClientId").DefaultValue = CType(Me.FormView1.FindControl("ddlClientId"), DropDownList).SelectedValue
            .InsertParameters("AccountCurrencyId").DefaultValue = CType(Me.FormView1.FindControl("ddlCurrencyId"), DropDownList).SelectedValue
            .InsertParameters("Description").DefaultValue = CType(Me.FormView2.FindControl("DescriptionTextBox"), TextBox).Text
            .InsertParameters("BillingCycleStartDate").DefaultValue = CType(Me.FormView1.FindControl("BillingCycleStartDateTextBox"), eWorld.UI.CalendarPopup).SelectedDate
            .InsertParameters("BillingCycleEndDate").DefaultValue = CType(Me.FormView1.FindControl("BillingCycleEndDateTextBox"), eWorld.UI.CalendarPopup).SelectedDate
            .InsertParameters("SubTotal").DefaultValue = CType(Me.FormView2.FindControl("SubTotalTextBox"), TextBox).Text
            .InsertParameters("TaxCode1").DefaultValue = CType(Me.FormView2.FindControl("Tax1TextBox"), TextBox).Text
            .InsertParameters("TaxCode2").DefaultValue = CType(Me.FormView2.FindControl("Tax2TextBox"), TextBox).Text
            .InsertParameters("GrandTotal").DefaultValue = CType(Me.FormView2.FindControl("GrandTotalTextBox"), TextBox).Text
            '.InsertParameters("Terms").DefaultValue = CType(Me.FormView2.FindControl("TermsTextBox"), TextBox).Text
            '.InsertParameters("BankDetails").DefaultValue = CType(Me.FormView2.FindControl("BankDetailsTextBox"), TextBox).Text
            .Insert()
        End With
    End Sub
    Public Sub UpdateAccountTimeExpenseBilling()
        With dsAccountTimeExpenseBillingObject
            Dim Original_AccountTimeExpenseBillingId As New Guid(Me.Request.QueryString("AccountTimeExpenseBillingId"))
            .UpdateParameters("Original_AccountTimeExpenseBillingId").DefaultValue = Convert.ToString(Original_AccountTimeExpenseBillingId)
            .UpdateParameters("AccountId").DefaultValue = DBUtilities.GetSessionAccountId
            .UpdateParameters("InvoiceNo").DefaultValue = CType(Me.FormView1.FindControl("InvoiceNoTextBox"), TextBox).Text
            .UpdateParameters("PONumber").DefaultValue = CType(Me.FormView1.FindControl("PONumberTextBox"), TextBox).Text
            .UpdateParameters("InvoiceDate").DefaultValue = CType(Me.FormView1.FindControl("InvoiceDateTextBox"), eWorld.UI.CalendarPopup).SelectedDate
            .UpdateParameters("GroupTimesheetBillingListBy").DefaultValue = CType(Me.FormView1.FindControl("ddlInvoiceGroup"), DropDownList).SelectedValue
            .UpdateParameters("GroupExpenseBillingListBy").DefaultValue = CType(Me.FormView1.FindControl("ddlExpenseInvoiceGroup"), DropDownList).SelectedValue
            .UpdateParameters("AccountProjectId").DefaultValue = CType(Me.FormView1.FindControl("ddlAccountProjectId"), DropDownList).SelectedValue
            .UpdateParameters("ParentAccountProjectTaskId").DefaultValue = CType(Me.FormView1.FindControl("ddlParentTaskId"), DropDownList).SelectedValue
            .UpdateParameters("AccountClientId").DefaultValue = CType(Me.FormView1.FindControl("ddlClientId"), DropDownList).SelectedValue
            .UpdateParameters("AccountCurrencyId").DefaultValue = CType(Me.FormView1.FindControl("ddlCurrencyId"), DropDownList).SelectedValue
            .UpdateParameters("Description").DefaultValue = CType(Me.FormView2.FindControl("DescriptionTextBox"), TextBox).Text
            .UpdateParameters("BillingCycleStartDate").DefaultValue = CType(Me.FormView1.FindControl("BillingCycleStartDateTextBox"), eWorld.UI.CalendarPopup).SelectedDate
            .UpdateParameters("BillingCycleEndDate").DefaultValue = CType(Me.FormView1.FindControl("BillingCycleEndDateTextBox"), eWorld.UI.CalendarPopup).SelectedDate
            .UpdateParameters("SubTotal").DefaultValue = CType(Me.FormView2.FindControl("SubTotalTextBox"), TextBox).Text
            .UpdateParameters("TaxCode1").DefaultValue = CType(Me.FormView2.FindControl("Tax1TextBox"), TextBox).Text
            .UpdateParameters("TaxCode2").DefaultValue = CType(Me.FormView2.FindControl("Tax2TextBox"), TextBox).Text
            .UpdateParameters("GrandTotal").DefaultValue = CType(Me.FormView2.FindControl("GrandTotalTextBox"), TextBox).Text
            '.UpdateParameters("Terms").DefaultValue = CType(Me.FormView2.FindControl("TermsTextBox"), TextBox).Text
            '.UpdateParameters("BankDetails").DefaultValue = CType(Me.FormView2.FindControl("BankDetailsTextBox"), TextBox).Text
            .Update()
        End With
    End Sub
    Public Sub InsertAccountTimeExpenseBillingTimesheet()

        Dim dtTimeSheet As AccountTimeExpenseBilling.vueAccountTimeExpenseBillingTimesheetDataTable
        Dim drTimeSheet As AccountTimeExpenseBilling.vueAccountTimeExpenseBillingTimesheetRow

        If CType(Me.FormView1.FindControl("ddlInvoiceGroup"), DropDownList).SelectedValue = "Task" Then
            dtTimeSheet = New AccountTimeExpenseBillingBLL().GetvueAccountTimeExpenseBillingTimesheetByAccountClientId(CType(Me.FormView1.FindControl("ddlClientId"), DropDownList).SelectedValue, CType(Me.FormView1.FindControl("BillingCycleStartDateTextBox"), eWorld.UI.CalendarPopup).SelectedDate, CType(Me.FormView1.FindControl("BillingCycleEndDateTextBox"), eWorld.UI.CalendarPopup).SelectedDate, AccountProjectId, CType(Me.FormView1.FindControl("ddlBillable"), DropDownList).SelectedValue, IIf(CType(Me.FormView1.FindControl("ddlParentTaskId"), DropDownList).SelectedValue = "", 0, CType(Me.FormView1.FindControl("ddlParentTaskId"), DropDownList).SelectedValue))
        ElseIf CType(Me.FormView1.FindControl("ddlInvoiceGroup"), DropDownList).SelectedValue = "TimeEntry" Then
            dtTimeSheet = New AccountTimeExpenseBillingBLL().GetvueAccountTimeExpenseBillingTimesheetByAccountClientIdWithTimeEntryGroup(CType(Me.FormView1.FindControl("ddlClientId"), DropDownList).SelectedValue, CType(Me.FormView1.FindControl("BillingCycleStartDateTextBox"), eWorld.UI.CalendarPopup).SelectedDate, CType(Me.FormView1.FindControl("BillingCycleEndDateTextBox"), eWorld.UI.CalendarPopup).SelectedDate, AccountProjectId, CType(Me.FormView1.FindControl("ddlBillable"), DropDownList).SelectedValue, IIf(CType(Me.FormView1.FindControl("ddlParentTaskId"), DropDownList).SelectedValue = "", 0, CType(Me.FormView1.FindControl("ddlParentTaskId"), DropDownList).SelectedValue))
        Else
            dtTimeSheet = New AccountTimeExpenseBillingBLL().GetvueAccountTimeExpenseBillingTimesheetByAccountClientIdForParentTask(CType(Me.FormView1.FindControl("ddlClientId"), DropDownList).SelectedValue, CType(Me.FormView1.FindControl("BillingCycleStartDateTextBox"), eWorld.UI.CalendarPopup).SelectedDate, CType(Me.FormView1.FindControl("BillingCycleEndDateTextBox"), eWorld.UI.CalendarPopup).SelectedDate, AccountProjectId, CType(Me.FormView1.FindControl("ddlBillable"), DropDownList).SelectedValue, IIf(CType(Me.FormView1.FindControl("ddlParentTaskId"), DropDownList).SelectedValue = "", 0, CType(Me.FormView1.FindControl("ddlParentTaskId"), DropDownList).SelectedValue))
        End If
        If dtTimeSheet.Rows.Count > 0 Then
            drTimeSheet = dtTimeSheet.Rows(0)
            For Each drTimeSheet In dtTimeSheet.Rows
                If CType(Me.FormView1.FindControl("ddlInvoiceGroup"), DropDownList).SelectedValue = "TimeEntry" Then
                    If LocaleUtilitiesBLL.ShowWorkTypeInInvoiceDescription Then
                        If Not IsDBNull(drTimeSheet.Item("TimesheetDescription")) Then
                            drTimeSheet.Description = drTimeSheet.AccountWorkType + " " + "-" + " " + drTimeSheet.TimesheetDescription
                        Else
                            drTimeSheet.Description = drTimeSheet.AccountWorkType + " " + "-" + " " + drTimeSheet.ProjectName + " " + "(" + drTimeSheet.TaskName + ")"
                        End If
                    Else
                        If Not IsDBNull(drTimeSheet.Item("TimesheetDescription")) Then
                            drTimeSheet.Description = drTimeSheet.TimesheetDescription
                        Else
                            drTimeSheet.Description = drTimeSheet.ProjectName + " " + "(" + drTimeSheet.TaskName + ")"
                        End If
                    End If

                Else
                    If Not IsDBNull(drTimeSheet.Item("TimesheetDescription")) Then
                        drTimeSheet.Description = drTimeSheet.TimesheetDescription
                    Else
                        drTimeSheet.Description = drTimeSheet.ProjectName + " " + "(" + drTimeSheet.TaskName + ")"
                    End If
                End If
                    If Not IsDBNull(drTimeSheet.Item("AccountEmployeeTimeEntryId")) Then
                        drTimeSheet.AccountEmployeeTimeEntryId = drTimeSheet.AccountEmployeeTimeEntryId
                    Else
                        drTimeSheet.AccountEmployeeTimeEntryId = 0
                End If
                If IsDBNull(drTimeSheet.Item("FixedBidBillingMode")) Then
                    drTimeSheet.BillHours = drTimeSheet.TotalHours
                ElseIf drTimeSheet.FixedBidBillingMode = 0 Then
                    drTimeSheet.BillHours = drTimeSheet.TotalHours
                Else
                    drTimeSheet.BillHours = 1
                End If

                    drTimeSheet.AccountTaxCodeId1 = 0
                    drTimeSheet.AccountTaxCodeId2 = 0
                    If CType(Me.FormView1.FindControl("ddlInvoiceGroup"), DropDownList).SelectedValue <> "ParentTask" Then
                        Dim dt As AccountCurrency.vueAccountCurrencyDataTable = New AccountCurrencyBLL().GetvueAccountCurrencyByAccountCurrencyId(CType(Me.FormView1.FindControl("ddlCurrencyId"), DropDownList).SelectedValue)
                        Dim dr As AccountCurrency.vueAccountCurrencyRow
                        If dt.Rows.Count > 0 Then
                            dr = dt.Rows(0)
                            InvoiceExchangeRate = dr.ExchangeRate
                            Dim BillingRateExchangeRate As Double = IIf(IsDBNull(drTimeSheet.Item("BillingRateExchangeRate")), 0, drTimeSheet.Item("BillingRateExchangeRate"))
                            If BillingRateExchangeRate <> 0.0 And dr.ExchangeRate <> 0 Then
                                drTimeSheet.TotalAmount = String.Format("{0:n2}", ((drTimeSheet.BillingRate * drTimeSheet.TotalHours) / (BillingRateExchangeRate * InvoiceExchangeRate)))
                                drTimeSheet.BillingRate = (drTimeSheet.BillingRate / BillingRateExchangeRate) * (InvoiceExchangeRate)
                            Else
                                drTimeSheet.TotalAmount = 0
                                drTimeSheet.BillingRate = 0
                            End If
                            drTimeSheet.ActualBillingRate = drTimeSheet.BillingRate
                        End If
                    Else
                        drTimeSheet.BillingRate = 0
                        drTimeSheet.ActualBillingRate = 0
                    End If
                    drTimeSheet.TaxCode1 = 0
                    drTimeSheet.TaxCode2 = 0
                    drTimeSheet.SubTotal = drTimeSheet.Amount

                    If CType(Me.FormView1.FindControl("ddlInvoiceGroup"), DropDownList).SelectedValue <> "ParentTask" Then
                        objTimeSheet.AddAccountTimeExpenseBillingTimesheet(objTimeSheet.GetLastInsertedId, DBUtilities.GetSessionAccountId, drTimeSheet.AccountProjectId, drTimeSheet.AccountProjectTaskId, drTimeSheet.Description, drTimeSheet.ActualBillingRate, drTimeSheet.BillingRate, drTimeSheet.TotalHours, drTimeSheet.BillHours, drTimeSheet.AccountTaxCodeId1, drTimeSheet.AccountTaxCodeId2, drTimeSheet.TotalAmount, drTimeSheet.TaxCode1, drTimeSheet.TaxCode2, drTimeSheet.AccountEmployeeTimeEntryId)
                    Else
                        objTimeSheet.AddAccountTimeExpenseBillingTimesheet(objTimeSheet.GetLastInsertedId, DBUtilities.GetSessionAccountId, drTimeSheet.AccountProjectId, drTimeSheet.ParentAccountProjectTaskId, drTimeSheet.Description, drTimeSheet.ActualBillingRate, drTimeSheet.BillingRate, drTimeSheet.TotalHours, drTimeSheet.BillHours, drTimeSheet.AccountTaxCodeId1, drTimeSheet.AccountTaxCodeId2, drTimeSheet.Amount, drTimeSheet.TaxCode1, drTimeSheet.TaxCode2, drTimeSheet.AccountEmployeeTimeEntryId)
                    End If
            Next
        End If
    End Sub
    Public Sub UpdateAccountTimeExpenseBillingTimesheet(ByVal row As GridViewRow)
        If Not IsDBNull(Me.GridView1.DataKeys(row.RowIndex).Item(1)) Or CType(row.FindControl("TotalAmountTextBox"), TextBox).Text > 0 Then
            '' ''Dim BLL As New AccountTimeExpenseBillingBLL
            '' ''Dim AccountTimeExpenseBillingTimesheetId As Guid
            '' ''Dim BillingId As New Guid(Me.Request.QueryString("AccountTimeExpenseBillingId"))
            '' ''Dim dtTimeSheet As AccountTimeExpenseBilling.AccountTimeExpenseBillingTimesheetDataTable = BLL.GetAccountTimeExpenseBillingTimesheetByAccountTimeExpenseBillingIdAndAccountProjectId(BillingId, Me.GridView1.DataKeys(row.RowIndex)(1), Me.GridView1.DataKeys(row.RowIndex)(2))
            '' ''Dim drTimeSheet As AccountTimeExpenseBilling.AccountTimeExpenseBillingTimesheetRow
            '' ''If dtTimeSheet.Rows.Count > 0 Then
            '' ''    drTimeSheet = dtTimeSheet.Rows(0)
            '' ''    AccountTimeExpenseBillingTimesheetId = drTimeSheet.AccountTimeExpenseBillingTimesheetId
            '' ''End If
            With dsAccountTimeExpenseBillingTimesheetObject
                .UpdateParameters("Original_AccountTimeExpenseBillingTimesheetId").DefaultValue = Convert.ToString(Me.GridView1.DataKeys(row.RowIndex)(4))
                Dim AccountTimeExpenseBillingId As New Guid(Me.Request.QueryString("AccountTimeExpenseBillingId"))
                .UpdateParameters("AccountTimeExpenseBillingId").DefaultValue = Convert.ToString(AccountTimeExpenseBillingId)
                .UpdateParameters("AccountId").DefaultValue = DBUtilities.GetSessionAccountId
                .UpdateParameters("AccountProjectId").DefaultValue = CType(row.FindControl("ddlAccountProjectId"), DropDownList).SelectedValue
                If CType(row.FindControl("ddlAccountProjectTaskId"), DropDownList).SelectedValue <> "" Then
                    .UpdateParameters("AccountProjectTaskId").DefaultValue = CType(row.FindControl("ddlAccountProjectTaskId"), DropDownList).SelectedValue
                Else
                    .UpdateParameters("AccountProjectTaskId").DefaultValue = CType(row.FindControl("ddlParentAccountProjectTaskId"), DropDownList).SelectedValue
                End If
                .UpdateParameters("Description").DefaultValue = CType(row.FindControl("DescriptionTextBox"), TextBox).Text
                .UpdateParameters("BillingRate").DefaultValue = Me.GridView1.DataKeys(row.RowIndex)(0)
                .UpdateParameters("ActualHours").DefaultValue = Me.GridView1.DataKeys(row.RowIndex)(7)
                .UpdateParameters("BillHours").DefaultValue = CType(row.FindControl("BillHoursTextBox"), TextBox).Text
                If Not IsDBNull(Me.GridView1.DataKeys(row.RowIndex)(9)) Then
                    .UpdateParameters("AccountEmployeeTimeEntryId").DefaultValue = Me.GridView1.DataKeys(row.RowIndex)(9)
                Else
                    .UpdateParameters("AccountEmployeeTimeEntryId").DefaultValue = 0
                End If
                Dim InvoiceBillingType As Boolean = DBUtilities.IsInvoiceBillingTypeDaily
                If InvoiceBillingType Then
                    Dim HoursBillingRate As Double = CType(row.FindControl("BillingRateTextBox"), TextBox).Text / DBUtilities.GetHoursPerDay
                    Dim HourlyBill As Double = CType(row.FindControl("BillHoursTextBox"), TextBox).Text * DBUtilities.GetHoursPerDay
                    .UpdateParameters("ActualBillingRate").DefaultValue = HoursBillingRate
                    .UpdateParameters("BillHours").DefaultValue = HourlyBill
                Else
                    .UpdateParameters("ActualBillingRate").DefaultValue = CType(row.FindControl("BillingRateTextBox"), TextBox).Text
                    .UpdateParameters("BillHours").DefaultValue = CType(row.FindControl("BillHoursTextBox"), TextBox).Text
                End If
                .UpdateParameters("TotalAmount").DefaultValue = CType(row.FindControl("TotalAmountTextBox"), TextBox).Text
                .UpdateParameters("AccountTaxCodeId1").DefaultValue = CType(row.FindControl("ddlAccountTaxCodeId1"), DropDownList).SelectedValue
                .UpdateParameters("AccountTaxCodeId2").DefaultValue = CType(row.FindControl("ddlAccountTaxCodeId2"), DropDownList).SelectedValue
                Me.GetAccountTaxCode1timesheet(row)
                .UpdateParameters("TaxCode1").DefaultValue = taxtotaltimesheet1
                Me.GetAccountTaxCode2timesheet(row)
                .UpdateParameters("TaxCode2").DefaultValue = taxtotaltimesheet2
                .Update()
                If PrintInvoice <> True Then
                    If Not IsDBNull(Me.GridView1.DataKeys(row.RowIndex).Item(1)) Then
                        If CType(Me.FormView1.FindControl("ddlInvoiceGroup"), DropDownList).SelectedValue = "ParentTask" Then
                            UpdateAccountEmployeeTimeEntryBillStatusForParentRecord(row)
                        Else
                            Me.UpdateAccountEmployeeTimeEntryBillStatus(row)
                        End If
                    End If
                End If
            End With
        End If
    End Sub
    Public Sub UpdateAccountEmployeeTimeEntryBillStatusForParentRecord(ByVal row As GridViewRow)
        Dim BLL As New AccountTimeExpenseBillingBLL
        Dim dtTimeEntryParent As AccountTimeExpenseBilling.AccountEmployeeTimeEntryForParentViewDataTable = BLL.GetAccountEmployeeTimeEntryByParentAccountProjectTaskId(CType(row.FindControl("ddlAccountProjectId"), DropDownList).SelectedValue, CType(row.FindControl("ddlParentAccountProjectTaskId"), DropDownList).SelectedValue, CType(Me.FormView1.FindControl("BillingCycleStartDateTextBox"), eWorld.UI.CalendarPopup).SelectedDate, CType(Me.FormView1.FindControl("BillingCycleEndDateTextBox"), eWorld.UI.CalendarPopup).SelectedDate)
        Dim drTimeEntryParent As AccountTimeExpenseBilling.AccountEmployeeTimeEntryForParentViewRow

        If dtTimeEntryParent.Rows.Count > 0 Then
            drTimeEntryParent = dtTimeEntryParent.Rows(0)
            For Each drTimeEntryParent In dtTimeEntryParent.Rows
                With ObjectDataSource1
                    .InsertParameters("AccountProjectId").DefaultValue = IIf(IsDBNull(Me.GridView1.DataKeys(row.RowIndex).Item(1)), "", Me.GridView1.DataKeys(row.RowIndex).Item(1))
                    .InsertParameters("AccountProjectTaskId").DefaultValue = drTimeEntryParent.AccountProjectTaskId
                    .InsertParameters("AccountTimeExpenseBillingTimesheetId").DefaultValue = Convert.ToString(Me.GridView1.DataKeys(row.RowIndex)(4))
                    .InsertParameters("TimeEntryStartDate").DefaultValue = CType(Me.FormView1.FindControl("BillingCycleStartDateTextBox"), eWorld.UI.CalendarPopup).SelectedDate
                    .InsertParameters("TimeEntryEndDate").DefaultValue = CType(Me.FormView1.FindControl("BillingCycleEndDateTextBox"), eWorld.UI.CalendarPopup).SelectedDate
                    .Insert()
                End With
            Next
        End If
    End Sub
    Public Sub InsertAccountTimeExpenseBillingExpense()
        Dim dtExpenseSheet As AccountTimeExpenseBilling.vueAccountTimeExpenseBillingExpenseDataTable
        Dim drExpenseSheet As AccountTimeExpenseBilling.vueAccountTimeExpenseBillingExpenseRow
        If CType(Me.FormView1.FindControl("ddlExpenseInvoiceGroup"), DropDownList).SelectedValue = "ExpenseName" Then
            dtExpenseSheet = New AccountTimeExpenseBillingBLL().GetvueAccountTimeExpenseBillingExpenseByAccountClientId(CType(Me.FormView1.FindControl("ddlClientId"), DropDownList).SelectedValue, CType(Me.FormView1.FindControl("BillingCycleStartDateTextBox"), eWorld.UI.CalendarPopup).SelectedDate, CType(Me.FormView1.FindControl("BillingCycleEndDateTextBox"), eWorld.UI.CalendarPopup).SelectedDate, AccountProjectId, CType(Me.FormView1.FindControl("ddlBillable"), DropDownList).SelectedValue)
        Else
            dtExpenseSheet = New AccountTimeExpenseBillingBLL().GetvueAccountTimeExpenseBillingExpenseByAccountClientIdWithExpenseEntryGroup(CType(Me.FormView1.FindControl("ddlClientId"), DropDownList).SelectedValue, CType(Me.FormView1.FindControl("BillingCycleStartDateTextBox"), eWorld.UI.CalendarPopup).SelectedDate, CType(Me.FormView1.FindControl("BillingCycleEndDateTextBox"), eWorld.UI.CalendarPopup).SelectedDate, AccountProjectId, CType(Me.FormView1.FindControl("ddlBillable"), DropDownList).SelectedValue)
        End If


        If dtExpenseSheet.Rows.Count > 0 Then
            drExpenseSheet = dtExpenseSheet.Rows(0)
            For Each drExpenseSheet In dtExpenseSheet.Rows
                If Not IsDBNull(drExpenseSheet.Item("ExpenseDescription")) Then
                    drExpenseSheet.Description = drExpenseSheet.ExpenseDescription
                Else
                    drExpenseSheet.Description = drExpenseSheet.ProjectName + " " + "(" + drExpenseSheet.AccountExpenseName + ")"
                End If
                If Not IsDBNull(drExpenseSheet.Item("AccountExpenseEntryId")) Then
                    drExpenseSheet.AccountExpenseEntryId = drExpenseSheet.AccountExpenseEntryId
                Else
                    drExpenseSheet.AccountExpenseEntryId = 0
                End If
                drExpenseSheet.AccountTaxCodeId1 = 0
                drExpenseSheet.AccountTaxCodeId2 = 0
                Dim dt As AccountCurrency.vueAccountCurrencyDataTable = New AccountCurrencyBLL().GetvueAccountCurrencyByAccountCurrencyId(CType(Me.FormView1.FindControl("ddlCurrencyId"), DropDownList).SelectedValue)
                Dim dr As AccountCurrency.vueAccountCurrencyRow
                If dt.Rows.Count > 0 Then
                    dr = dt.Rows(0)
                    InvoiceExchangeRate = dr.ExchangeRate
                    Dim ExchangeRate As Double = IIf(IsDBNull(drExpenseSheet.Item("ExchangeRate")), 0, drExpenseSheet.Item("ExchangeRate"))
                    If ExchangeRate <> 0 And dr.ExchangeRate <> 0 Then
                        drExpenseSheet.BilledExpenseAmount = String.Format("{0:n2}", drExpenseSheet.Amount / ExchangeRate * InvoiceExchangeRate)
                        drExpenseSheet.Amount = String.Format("{0:n2}", drExpenseSheet.Amount / ExchangeRate * InvoiceExchangeRate)
                    Else
                        drExpenseSheet.BilledExpenseAmount = 0
                        drExpenseSheet.Amount = 0
                    End If
                End If
                drExpenseSheet.TaxCode1 = 0
                drExpenseSheet.TaxCode2 = 0
                objTimeSheet.AddAccountTimeExpenseBillingExpense(objTimeSheet.GetLastInsertedId, DBUtilities.GetSessionAccountId, drExpenseSheet.AccountProjectId, drExpenseSheet.AccountExpenseTypeId, drExpenseSheet.AccountExpenseId, drExpenseSheet.Description, drExpenseSheet.Amount, drExpenseSheet.BilledExpenseAmount, drExpenseSheet.AccountTaxCodeId1, drExpenseSheet.AccountTaxCodeId2, drExpenseSheet.TaxCode1, drExpenseSheet.TaxCode2, drExpenseSheet.AccountExpenseEntryId)
            Next
        End If
    End Sub
    Public Sub UpdateAccountTimeExpenseBillingExpense(ByVal row As GridViewRow)
        If Not IsDBNull(Me.GridView2.DataKeys(row.RowIndex).Item(0)) Or CType(row.FindControl("BilledAmountTextBox"), TextBox).Text > 0 Then
            With dsAccountTimeExpenseBillingExpenseObject
                .UpdateParameters("Original_AccountTimeExpenseBillingExpenseId").DefaultValue = Convert.ToString(Me.GridView2.DataKeys(row.RowIndex)(4))
                .UpdateParameters("AccountId").DefaultValue = DBUtilities.GetSessionAccountId
                Dim AccountTimeExpenseBillingId As New Guid(Me.Request.QueryString("AccountTimeExpenseBillingId"))
                .UpdateParameters("AccountTimeExpenseBillingId").DefaultValue = Convert.ToString(AccountTimeExpenseBillingId)
                .UpdateParameters("AccountProjectId").DefaultValue = CType(row.FindControl("ddlAccountProjectId"), DropDownList).SelectedValue
                .UpdateParameters("AccountExpenseTypeId").DefaultValue = CType(row.FindControl("ddlExpenseType"), DropDownList).SelectedValue
                .UpdateParameters("AccountExpenseId").DefaultValue = CType(row.FindControl("ddlExpenseName"), DropDownList).SelectedValue
                .UpdateParameters("Description").DefaultValue = CType(row.FindControl("DescriptionTextBox"), TextBox).Text
                .UpdateParameters("ActualExpenseAmount").DefaultValue = Me.GridView2.DataKeys(row.RowIndex)(6)
                .UpdateParameters("BilledExpenseAmount").DefaultValue = CType(row.FindControl("BilledAmountTextBox"), TextBox).Text
                .UpdateParameters("AccountTaxCodeId1").DefaultValue = CType(row.FindControl("ddlAccountTaxCodeId1"), DropDownList).SelectedValue
                .UpdateParameters("AccountTaxCodeId2").DefaultValue = CType(row.FindControl("ddlAccountTaxCodeId2"), DropDownList).SelectedValue
                If Not IsDBNull(Me.GridView2.DataKeys(row.RowIndex)(9)) Then
                    .UpdateParameters("AccountExpenseEntryId").DefaultValue = Me.GridView2.DataKeys(row.RowIndex)(9)
                Else
                    .UpdateParameters("AccountExpenseEntryId").DefaultValue = 0
                End If
                Me.GetAccountTaxCode1expense(row)
                .UpdateParameters("TaxCode1").DefaultValue = taxtotalexpense1
                Me.GetAccountTaxCode2expense(row)
                .UpdateParameters("TaxCode2").DefaultValue = taxtotalexpense2
                .Update()
                If PrintInvoice <> True Then
                    If Not IsDBNull(Me.GridView2.DataKeys(row.RowIndex).Item(0)) Then
                        Me.UpdateAccountExpenseEntryBillStatus(row)
                    End If
                End If
            End With
        End If
    End Sub
    Public Sub UpdateAccountEmployeeTimeEntryBillStatus(ByVal row As GridViewRow)
        With ObjectDataSource1
            .InsertParameters("AccountProjectId").DefaultValue = IIf(IsDBNull(Me.GridView1.DataKeys(row.RowIndex).Item(1)), "", Me.GridView1.DataKeys(row.RowIndex).Item(1))
            .InsertParameters("AccountProjectTaskId").DefaultValue = IIf(IsDBNull(Me.GridView1.DataKeys(row.RowIndex).Item(2)), "", Me.GridView1.DataKeys(row.RowIndex).Item(2))
            .InsertParameters("AccountTimeExpenseBillingTimesheetId").DefaultValue = Convert.ToString(Me.GridView1.DataKeys(row.RowIndex)(4))
            .InsertParameters("TimeEntryStartDate").DefaultValue = CType(Me.FormView1.FindControl("BillingCycleStartDateTextBox"), eWorld.UI.CalendarPopup).SelectedDate
            .InsertParameters("TimeEntryEndDate").DefaultValue = CType(Me.FormView1.FindControl("BillingCycleEndDateTextBox"), eWorld.UI.CalendarPopup).SelectedDate
            .Insert()
        End With
    End Sub
    Public Sub UpdateAccountExpenseEntryBillStatus(ByVal row As GridViewRow)
        With ObjectDataSource2
            .InsertParameters("AccountProjectId").DefaultValue = IIf(IsDBNull(Me.GridView2.DataKeys(row.RowIndex).Item(0)), "", Me.GridView2.DataKeys(row.RowIndex).Item(0))
            .InsertParameters("AccountExpenseId").DefaultValue = IIf(IsDBNull(Me.GridView2.DataKeys(row.RowIndex).Item(2)), "", Me.GridView2.DataKeys(row.RowIndex).Item(2))
            .InsertParameters("AccountTimeExpenseBillingExpenseId").DefaultValue = Convert.ToString(Me.GridView2.DataKeys(row.RowIndex)(4))
            .InsertParameters("ExpenseEntryStartDate").DefaultValue = CType(Me.FormView1.FindControl("BillingCycleStartDateTextBox"), eWorld.UI.CalendarPopup).SelectedDate
            .InsertParameters("ExpenseEntryEndDate").DefaultValue = CType(Me.FormView1.FindControl("BillingCycleEndDateTextBox"), eWorld.UI.CalendarPopup).SelectedDate
            .Insert()
        End With
    End Sub
    Public Sub InsertAccountTimeExpenseBillingTimesheetNewRecord(ByVal row As GridViewRow)
        If CType(row.FindControl("TotalAmountTextBox"), TextBox).Text > 0 Then
            With dsAccountTimeExpenseBillingTimesheetObject
                If Me.FormView1.CurrentMode = FormViewMode.Edit Then
                    Dim AccountTimeExpenseBillingId As New Guid(Me.Request.QueryString("AccountTimeExpenseBillingId"))
                    .InsertParameters("AccountTimeExpenseBillingId").DefaultValue = Convert.ToString(AccountTimeExpenseBillingId)
                End If
                .InsertParameters("AccountId").DefaultValue = DBUtilities.GetSessionAccountId
                .InsertParameters("AccountProjectId").DefaultValue = CType(row.FindControl("ddlAccountProjectId"), DropDownList).SelectedValue
                If CType(Me.FormView1.FindControl("ddlInvoiceGroup"), DropDownList).SelectedValue <> "ParentTask" Then
                    .InsertParameters("AccountProjectTaskId").DefaultValue = CType(row.FindControl("ddlAccountProjectTaskId"), DropDownList).SelectedValue
                Else
                    .InsertParameters("AccountProjectTaskId").DefaultValue = CType(row.FindControl("ddlParentAccountProjectTaskId"), DropDownList).SelectedValue
                End If
                .InsertParameters("Description").DefaultValue = CType(row.FindControl("DescriptionTextBox"), TextBox).Text
                .InsertParameters("BillingRate").DefaultValue = Me.GridView1.DataKeys(row.RowIndex)(0)
                .InsertParameters("ActualHours").DefaultValue = Me.GridView1.DataKeys(row.RowIndex)(7)
                Dim InvoiceBillingType As Boolean = DBUtilities.IsInvoiceBillingTypeDaily
                If InvoiceBillingType Then
                    Dim HoursBillingRate As Double = CType(row.FindControl("BillingRateTextBox"), TextBox).Text / DBUtilities.GetHoursPerDay
                    Dim HourlyBill As Double = CType(row.FindControl("BillHoursTextBox"), TextBox).Text * DBUtilities.GetHoursPerDay
                    .InsertParameters("ActualBillingRate").DefaultValue = HoursBillingRate
                    .InsertParameters("BillHours").DefaultValue = HourlyBill
                Else
                    .InsertParameters("BillHours").DefaultValue = CType(row.FindControl("BillHoursTextBox"), TextBox).Text
                    .InsertParameters("ActualBillingRate").DefaultValue = CType(row.FindControl("BillingRateTextBox"), TextBox).Text
                End If

                .InsertParameters("TotalAmount").DefaultValue = CType(row.FindControl("TotalAmountTextBox"), TextBox).Text
                .InsertParameters("AccountTaxCodeId1").DefaultValue = CType(row.FindControl("ddlAccountTaxCodeId1"), DropDownList).SelectedValue
                .InsertParameters("AccountTaxCodeId2").DefaultValue = CType(row.FindControl("ddlAccountTaxCodeId2"), DropDownList).SelectedValue
                Me.GetAccountTaxCode1timesheet(row)
                .InsertParameters("TaxCode1").DefaultValue = taxtotaltimesheet1
                Me.GetAccountTaxCode2timesheet(row)
                .InsertParameters("TaxCode2").DefaultValue = taxtotaltimesheet2
                .Insert()
            End With
        End If
    End Sub
    Public Sub InsertAccountTimeExpenseBillingExpenseNewRecord(ByVal row As GridViewRow)
        If CType(row.FindControl("BilledAmountTextbox"), TextBox).Text > 0 Then
            With dsAccountTimeExpenseBillingExpenseObject
                If Me.FormView1.CurrentMode = FormViewMode.Edit Then
                    Dim AccountTimeExpenseBillingId As New Guid(Me.Request.QueryString("AccountTimeExpenseBillingId"))
                    .InsertParameters("AccountTimeExpenseBillingId").DefaultValue = Convert.ToString(AccountTimeExpenseBillingId)
                End If
                .InsertParameters("AccountId").DefaultValue = DBUtilities.GetSessionAccountId
                .InsertParameters("AccountProjectId").DefaultValue = CType(row.FindControl("ddlAccountProjectId"), DropDownList).SelectedValue
                .InsertParameters("AccountExpenseTypeId").DefaultValue = CType(row.FindControl("ddlExpenseType"), DropDownList).SelectedValue
                .InsertParameters("AccountExpenseId").DefaultValue = CType(row.FindControl("ddlExpenseName"), DropDownList).SelectedValue
                .InsertParameters("Description").DefaultValue = CType(row.FindControl("DescriptionTextBox"), TextBox).Text
                .InsertParameters("ActualExpenseAmount").DefaultValue = Me.GridView2.DataKeys(row.RowIndex)(6)
                .InsertParameters("BilledExpenseAmount").DefaultValue = CType(row.FindControl("BilledAmountTextbox"), TextBox).Text
                .InsertParameters("AccountTaxCodeId1").DefaultValue = CType(row.FindControl("ddlAccountTaxCodeId1"), DropDownList).SelectedValue
                .InsertParameters("AccountTaxCodeId2").DefaultValue = CType(row.FindControl("ddlAccountTaxCodeId2"), DropDownList).SelectedValue
                Me.GetAccountTaxCode1expense(row)
                .InsertParameters("TaxCode1").DefaultValue = taxtotalexpense1
                Me.GetAccountTaxCode2expense(row)
                .InsertParameters("TaxCode2").DefaultValue = taxtotalexpense2
                .Insert()
            End With
        End If
    End Sub
    Protected Sub dsAccountTimeExpenseBillingObject_Inserting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceMethodEventArgs)
        DBUtilities.SetRowForInserting(e)
    End Sub
    Protected Sub dsAccountTimeExpenseBillingObject_Updating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceMethodEventArgs)
        DBUtilities.SetRowForUpdating(e)
    End Sub
    Protected Sub dsAccountTimeExpenseBillingTimesheetObject_Inserting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceMethodEventArgs) Handles dsAccountTimeExpenseBillingTimesheetObject.Inserting
        If Me.FormView1.CurrentMode = FormViewMode.Insert Then
            e.InputParameters("AccountTimeExpenseBillingId") = New AccountTimeExpenseBillingBLL().GetLastInsertedId
        End If
    End Sub
    Protected Sub dsAccountTimeExpenseBillingExpenseObject_Inserting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceMethodEventArgs) Handles dsAccountTimeExpenseBillingExpenseObject.Inserting
        If Me.FormView1.CurrentMode = FormViewMode.Insert Then
            e.InputParameters("AccountTimeExpenseBillingId") = New AccountTimeExpenseBillingBLL().GetLastInsertedId
        End If
    End Sub
    Protected Sub btnPopulate_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If Me.FormView1.CurrentMode = FormViewMode.Insert Then
            If Me.GetInvoiceNo = False Then
                Me.btnSave.Visible = True
                IsPopulate = True
                Me.RowsCheck()
            End If
        End If
    End Sub
    Protected Sub btnPopulateUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If Me.FormView1.CurrentMode = FormViewMode.Edit Then
            If CType(Me.FormView1.FindControl("ddlCurrencyId"), DropDownList).SelectedValue <> Me.FormView1.DataKey.Item(0) Then
                IsPopulate = True
                IfCurrencyChanged()
                Me.RowsCheck()
                Me.Calculation()
                Me.GetAccountTaxCode1()
                Me.GetAccountTaxCode2()
            Else
                IsPopulate = True
                Me.RowsCheck()
                Me.Calculation()
                Me.GetAccountTaxCode1()
                Me.GetAccountTaxCode2()
                ''Response.Redirect("~/ProjectAdmin/AccountInvoiceForm.aspx?AccountTimeExpenseBillingId=" & objTimeSheet.GetLastInsertedId.ToString, False)
            End If
        End If
    End Sub
    Public Sub ShowNotFoundMessage(ByVal strMessage As String)
        Dim strScript As String = "alert('" & strMessage & "');"
        If (Not Me.Page.ClientScript.IsClientScriptBlockRegistered("clientScript")) Then
            ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "clientScript", strScript, True)
        End If
    End Sub
    Public Sub IfCurrencyChanged()
        Me.UpdateAccountTimeExpenseBilling()
    End Sub
    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then

            Dim dataValue As Object
            'Dim objDropdown As DropDownList
            'Dim dsObject As ObjectDataSource
            Dim dataValueTax1 As Object
            Dim objDropdownTax1 As DropDownList
            Dim dsObjectTax1 As ObjectDataSource
            Dim dataValueTax2 As Object
            Dim objDropdownTax2 As DropDownList
            Dim dsObjectTax2 As ObjectDataSource

            objDropdownTax1 = CType(e.Row.Cells(7).FindControl("ddlAccountTaxCodeId1"), DropDownList)
            dsObjectTax1 = CType(e.Row.Cells(7).FindControl("dsAccountTaxCodeObject"), ObjectDataSource)

            If Not objDropdownTax1 Is Nothing Then
                dataValueTax1 = DataBinder.Eval(e.Row.DataItem, "AccountTaxCodeId1")
                If Not IsDBNull(dataValueTax1) Then
                    objDropdownTax1.SelectedValue = dataValueTax1
                End If
            End If

            objDropdownTax2 = CType(e.Row.Cells(8).FindControl("ddlAccountTaxCodeId2"), DropDownList)
            dsObjectTax2 = CType(e.Row.Cells(8).FindControl("dsAccountTaxCodeObject2"), ObjectDataSource)

            If Not objDropdownTax2 Is Nothing Then
                dataValueTax2 = DataBinder.Eval(e.Row.DataItem, "AccountTaxCodeId2")
                If Not IsDBNull(dataValueTax2) Then
                    objDropdownTax2.SelectedValue = dataValueTax2
                End If
            End If
            Dim InvoiceBillingType As Boolean = DBUtilities.IsInvoiceBillingTypeDaily
            If Not Me.Request.QueryString("AccountTimeExpenseBillingId") Is Nothing Then
                If InvoiceBillingType Then
                    If DataBinder.Eval(e.Row.DataItem, "ActualBillingRate") <> 0 Then
                        Dim DaysBillingRate As Double = (DataBinder.Eval(e.Row.DataItem, "ActualBillingRate") * DBUtilities.GetHoursPerDay)
                        CType(e.Row.Cells(4).FindControl("BillingRateTextBox"), TextBox).Text = DaysBillingRate
                    Else
                        CType(e.Row.Cells(4).FindControl("BillingRateTextBox"), TextBox).Text = 0
                    End If
                    If DataBinder.Eval(e.Row.DataItem, "BillingRate") <> 0 Then
                        Dim DaysBillingRate As Double = (DataBinder.Eval(e.Row.DataItem, "BillingRate") * DBUtilities.GetHoursPerDay)
                        CType(e.Row.Cells(3).FindControl("Label4"), Label).Text = DaysBillingRate
                    End If
                    If DataBinder.Eval(e.Row.DataItem, "ActualHours") <> 0 Then
                        Dim ActualDays As Double = (DataBinder.Eval(e.Row.DataItem, "ActualHours") / DBUtilities.GetHoursPerDay)
                        CType(e.Row.Cells(5).FindControl("Label2"), Label).Text = ActualDays
                    End If
                    If DataBinder.Eval(e.Row.DataItem, "BillHours") <> 0 Then
                        Dim ActualDays As Double = (DataBinder.Eval(e.Row.DataItem, "BillHours") / DBUtilities.GetHoursPerDay)
                        CType(e.Row.Cells(6).FindControl("BillHoursTextBox"), TextBox).Text = ActualDays
                    End If
                Else
                    CType(e.Row.Cells(4).FindControl("BillingRateTextBox"), TextBox).Text = DataBinder.Eval(e.Row.DataItem, "ActualBillingRate")
                End If


                If CType(e.Row.Cells(2).FindControl("DescriptionTextBox"), TextBox).Text = "" Then
                    CType(e.Row.Cells(2).FindControl("DescriptionTextBox"), TextBox).Text = ""
                Else
                    CType(e.Row.Cells(2).FindControl("DescriptionTextBox"), TextBox).Text = DataBinder.Eval(e.Row.DataItem, "Description")
                End If

            End If

            If Not IsDBNull(DataBinder.Eval(e.Row.DataItem, "TaxCode1")) Then
                CType(Me.FormView2.FindControl("Tax1TextBox"), TextBox).Text = DataBinder.Eval(e.Row.DataItem, "TaxCode1")
                CType(Me.FormView2.FindControl("Tax2TextBox"), TextBox).Text = DataBinder.Eval(e.Row.DataItem, "TaxCode2")
            Else
                'CType(Me.FormView2.FindControl("Tax1TextBox"), TextBox).Text = 0
                'CType(Me.FormView2.FindControl("Tax2TextBox"), TextBox).Text = 0
            End If
            ''

            Dim dsObjectProject As ObjectDataSource
            dsObjectProject = Me.dsAccountProjectObjectTimesheet
            If Not dsObjectProject Is Nothing Then
                dataValue = DataBinder.Eval(e.Row.DataItem, "AccountProjectId")
                If IsDBNull(dataValue) Then
                    dataValue = 0
                End If
                If dataValue <> 0 Then
                    dataValue = DataBinder.Eval(e.Row.DataItem, "AccountProjectId")
                    Dim item As New System.Web.UI.WebControls.ListItem
                    item.Text = "Select"
                    item.Value = "0"
                    CType(e.Row.Cells(0).FindControl("ddlAccountProjectId"), DropDownList).Items.Add(item)
                    dsObjectProject.SelectParameters("AccountProjectId").DefaultValue = DataBinder.Eval(e.Row.DataItem, "AccountProjectId")
                    CType(e.Row.Cells(0).FindControl("ddlAccountProjectId"), DropDownList).SelectedValue = dataValue
                Else
                    Dim item As New System.Web.UI.WebControls.ListItem
                    item.Text = "Select"
                    item.Value = "0"
                    CType(e.Row.Cells(0).FindControl("ddlAccountProjectId"), DropDownList).Items.Add(item)
                    CType(e.Row.Cells(0).FindControl("ddlAccountProjectId"), DropDownList).SelectedValue = 0
                End If
            End If

            ''SetTaskValueOnRowDataBound
            Dim objDropdownTask As DropDownList
            Dim dsObjectTask As ObjectDataSource
            Dim dataValueTask As Object
            objDropdownTask = CType(e.Row.Cells(1).FindControl("ddlAccountProjectTaskId"), DropDownList)
            dsObjectTask = CType(e.Row.Cells(0).FindControl("dsAccountProjectTasksObject"), ObjectDataSource)
            If Not objDropdownTask Is Nothing Then
                If Not IsDBNull(DataBinder.Eval(e.Row.DataItem, "AccountProjectTaskId")) Then
                    dataValueTask = DataBinder.Eval(e.Row.DataItem, "AccountProjectTaskId")
                    objDropdownTask.SelectedValue = dataValueTask
                End If
                Dim MyCascading As AjaxControlToolkit.CascadingDropDown
                MyCascading = CType(e.Row.Cells(1).FindControl("ddlAccountProjectTaskIdCascadingDropDown"), AjaxControlToolkit.CascadingDropDown)
                If Not IsDBNull(dataValueTask) Then
                    MyCascading.SelectedValue = dataValueTask
                    MyCascading.Category = DBUtilities.GetSessionAccountId & "," & dataValueTask
                    objDropdownTask.SelectedValue = dataValueTask
                End If
            End If

            '''Set ParentTaskId On RowDataBound
            Dim objDropdownParentTask As DropDownList
            Dim dsObjectParentTask As ObjectDataSource
            Dim dataValueParentTask As Object
            objDropdownParentTask = CType(e.Row.Cells(1).FindControl("ddlParentAccountProjectTaskId"), DropDownList)
            dsObjectParentTask = CType(e.Row.Cells(0).FindControl("dsParentAccountProjectTasksObject"), ObjectDataSource)
            If Not objDropdownParentTask Is Nothing Then
                If Not IsDBNull(DataBinder.Eval(e.Row.DataItem, "AccountProjectTaskId")) Then
                    dataValueParentTask = DataBinder.Eval(e.Row.DataItem, "AccountProjectTaskId")
                    objDropdownParentTask.SelectedValue = dataValueParentTask
                End If
                Dim MyCascading As AjaxControlToolkit.CascadingDropDown
                MyCascading = CType(e.Row.Cells(1).FindControl("ddlParentAccountProjectTaskId_CascadingDropDown"), AjaxControlToolkit.CascadingDropDown)
                If Not IsDBNull(dataValueParentTask) Then
                    MyCascading.SelectedValue = dataValueParentTask
                    MyCascading.Category = DBUtilities.GetSessionAccountId
                    objDropdownParentTask.SelectedValue = dataValueParentTask
                End If
            End If
            If CType(Me.FormView1.FindControl("ddlInvoiceGroup"), DropDownList).SelectedValue <> "ParentTask" Then
                CType(e.Row.Cells(1).FindControl("ddlAccountProjectTaskId"), DropDownList).Visible = True
                CType(e.Row.Cells(1).FindControl("ddlParentAccountProjectTaskId"), DropDownList).Visible = False
                CType(e.Row.Cells(9).FindControl("TotalAmountTextBox"), TextBox).Enabled = False
                'e.Row.Cells(3).Visible = True
            Else
                CType(e.Row.Cells(1).FindControl("ddlParentAccountProjectTaskId"), DropDownList).Visible = True
                CType(e.Row.Cells(1).FindControl("ddlAccountProjectTaskId"), DropDownList).Visible = False
                CType(e.Row.Cells(9).FindControl("TotalAmountTextBox"), TextBox).Enabled = True
                'e.Row.Cells(3).Visible = False
            End If

        End If
    End Sub
    Protected Sub BillingRateTextBox_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim row As GridViewRow
        If Not IsValidAllTextBoxValueTimesheet() Then
            Return
        End If
        For Each row In Me.GridView1.Rows
            If CType(Me.FormView1.FindControl("ddlInvoiceGroup"), DropDownList).SelectedValue <> "ParentTask" Then
                CType(row.FindControl("TotalAmountTextBox"), TextBox).Text = String.Format("{0:n2}", CType(row.FindControl("BillingRateTextBox"), TextBox).Text * CType(row.FindControl("BillHoursTextBox"), TextBox).Text)
            Else
                CType(row.FindControl("TotalAmountTextBox"), TextBox).Text = String.Format("{0:n2}", CType(row.FindControl("TotalAmountTextBox"), TextBox).Text)
            End If
            Me.GetAccountTaxCode1()
            Me.GetAccountTaxCode2()
        Next
        Me.Calculation()
    End Sub
    Protected Sub BillHoursTextBox_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim row As GridViewRow
        If Not IsValidAllTextBoxValueTimesheet() Then
            Return
        End If
        For Each row In Me.GridView1.Rows
            If CType(Me.FormView1.FindControl("ddlInvoiceGroup"), DropDownList).SelectedValue <> "ParentTask" Then
                CType(row.FindControl("TotalAmountTextBox"), TextBox).Text = String.Format("{0:n2}", CType(row.FindControl("BillingRateTextBox"), TextBox).Text * CType(row.FindControl("BillHoursTextBox"), TextBox).Text)
            Else
                CType(row.FindControl("TotalAmountTextBox"), TextBox).Text = String.Format("{0:n2}", CType(row.FindControl("TotalAmountTextBox"), TextBox).Text)
            End If
            Me.GetAccountTaxCode1()
            Me.GetAccountTaxCode2()
        Next
        Me.Calculation()
    End Sub
    Protected Sub GridView2_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView2.DataBound
        If Me.GridView1.Rows.Count <> 0 Or Me.GridView2.Rows.Count <> 0 Then
            Me.FormView2.Visible = True
            Me.btnSave.Visible = True
        Else
            Me.FormView2.Visible = False
            Me.btnSave.Visible = False
        End If
    End Sub
    Protected Sub GridView2_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView2.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim dataValue As Object
            'Dim objDropdown As DropDownList
            'Dim dsObject As ObjectDataSource

            Dim dataValueTax1 As Object
            Dim objDropdownTax1 As DropDownList
            Dim dsObjectTax1 As ObjectDataSource

            Dim dataValueTax2 As Object
            Dim objDropdownTax2 As DropDownList
            Dim dsObjectTax2 As ObjectDataSource

            objDropdownTax1 = CType(e.Row.Cells(5).FindControl("ddlAccountTaxCodeId1"), DropDownList)
            dsObjectTax1 = CType(e.Row.Cells(5).FindControl("dsAccountTaxCodeObject"), ObjectDataSource)

            If Not objDropdownTax1 Is Nothing Then
                dataValueTax1 = DataBinder.Eval(e.Row.DataItem, "AccountTaxCodeId1")
                If Not IsDBNull(dataValueTax1) Then
                    objDropdownTax1.SelectedValue = dataValueTax1
                End If
            End If

            objDropdownTax2 = CType(e.Row.Cells(6).FindControl("ddlAccountTaxCodeId2"), DropDownList)
            dsObjectTax2 = CType(e.Row.Cells(6).FindControl("dsAccountTaxCodeObject2"), ObjectDataSource)

            If Not objDropdownTax2 Is Nothing Then
                dataValueTax2 = DataBinder.Eval(e.Row.DataItem, "AccountTaxCodeId2")
                If Not IsDBNull(dataValueTax2) Then
                    objDropdownTax2.SelectedValue = dataValueTax2
                End If
            End If

            Me.btnSave.Visible = True
            Me.FormView2.Visible = True

            If Not Me.Request.QueryString("AccountTimeExpenseBillingId") Is Nothing Then
                CType(e.Row.Cells(5).FindControl("BilledAmountTextbox"), TextBox).Text = DataBinder.Eval(e.Row.DataItem, "BilledExpenseAmount")
                If CType(e.Row.Cells(3).FindControl("DescriptionTextBox"), TextBox).Text = "" Then
                    CType(e.Row.Cells(3).FindControl("DescriptionTextBox"), TextBox).Text = ""
                Else
                    CType(e.Row.Cells(3).FindControl("DescriptionTextBox"), TextBox).Text = DataBinder.Eval(e.Row.DataItem, "Description")
                End If
            End If
            If Not IsDBNull(DataBinder.Eval(e.Row.DataItem, "TaxCode1")) Then
                CType(Me.FormView2.FindControl("Tax1TextBox"), TextBox).Text = DataBinder.Eval(e.Row.DataItem, "TaxCode1")
                CType(Me.FormView2.FindControl("Tax2TextBox"), TextBox).Text = DataBinder.Eval(e.Row.DataItem, "TaxCode2")
            Else
                'CType(Me.FormView2.FindControl("Tax1TextBox"), TextBox).Text = 0
                'CType(Me.FormView2.FindControl("Tax2TextBox"), TextBox).Text = 0
            End If

            Dim dsObjectProjectExpense As ObjectDataSource
            dsObjectProjectExpense = Me.dsAccountProjectObjectExpense
            If Not dsObjectProjectExpense Is Nothing Then
                dataValue = DataBinder.Eval(e.Row.DataItem, "AccountProjectId")
                If IsDBNull(dataValue) Then
                    dataValue = 0
                End If
                If dataValue <> 0 Then
                    dataValue = DataBinder.Eval(e.Row.DataItem, "AccountProjectId")
                    Dim item As New System.Web.UI.WebControls.ListItem
                    item.Text = "Select"
                    item.Value = "0"
                    CType(e.Row.Cells(0).FindControl("ddlAccountProjectId"), DropDownList).Items.Add(item)
                    dsObjectProjectExpense.SelectParameters("AccountProjectId").DefaultValue = DataBinder.Eval(e.Row.DataItem, "AccountProjectId")
                    CType(e.Row.Cells(0).FindControl("ddlAccountProjectId"), DropDownList).SelectedValue = dataValue
                Else
                    Dim item As New System.Web.UI.WebControls.ListItem
                    item.Text = "Select"
                    item.Value = "0"
                    CType(e.Row.Cells(0).FindControl("ddlAccountProjectId"), DropDownList).Items.Add(item)
                    CType(e.Row.Cells(0).FindControl("ddlAccountProjectId"), DropDownList).SelectedValue = 0
                End If
            End If
            If Not IsDBNull(DataBinder.Eval(e.Row.DataItem, "AccountExpenseId")) Then
                CType(e.Row.Cells(1).FindControl("ddlExpenseName"), DropDownList).SelectedValue = DataBinder.Eval(e.Row.DataItem, "AccountExpenseId")
            Else
                CType(e.Row.Cells(1).FindControl("ddlExpenseName"), DropDownList).SelectedValue = 0
            End If
            If Not IsDBNull(DataBinder.Eval(e.Row.DataItem, "AccountExpenseTypeId")) Then
                CType(e.Row.Cells(2).FindControl("ddlExpenseType"), DropDownList).SelectedValue = DataBinder.Eval(e.Row.DataItem, "AccountExpenseTypeId")
            Else
                CType(e.Row.Cells(2).FindControl("ddlExpenseType"), DropDownList).SelectedValue = 0
            End If
        End If
    End Sub
    Protected Sub BilledAmountTextbox_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not IsValidAllTextBoxValueExpensesheet() Then
            Return
        End If
        Me.GetAccountTaxCode1()
        Me.GetAccountTaxCode2()
        Me.Calculation()
    End Sub
    Public Function GetAccountTaxCode1() As Boolean
        Dim TimeBLL As New AccountTimeExpenseBillingBLL
        Dim row As GridViewRow
        taxtotal1 = 0
        ExpenseTaxTotal1 = 0
        For Each row In Me.GridView1.Rows
            Dim AccountTaxCodeId As Integer = CType(row.FindControl("ddlAccountTaxCodeId1"), DropDownList).SelectedValue
            If AccountTaxCodeId <> 0 Then
                Dim dtAccountExpenseWithTaxCode As AccountExpenseEntryforBilling.AccountTaxCodeDataTable = TimeBLL.GetAccountTimeExpenseBillingWithTaxCodeByAccountIdAndAccountTaxCodeId(DBUtilities.GetSessionAccountId, AccountTaxCodeId)
                Dim drAccountExpenseWithTaxCode As AccountExpenseEntryforBilling.AccountTaxCodeRow
                If dtAccountExpenseWithTaxCode.Rows.Count > 0 Then
                    drAccountExpenseWithTaxCode = dtAccountExpenseWithTaxCode.Rows(0)
                    If Not IsDBNull(drAccountExpenseWithTaxCode.Item("TaxCode")) Then
                        Try
                            Dim myParser As MathParser
                            myParser = New MathParser
                            myParser.X = Double.Parse(CType(row.FindControl("TotalAmountTextBox"), TextBox).Text)
                            myParser.SetVariable("Net", Double.Parse(CType(row.FindControl("TotalAmountTextBox"), TextBox).Text), Nothing)
                            myParser.Expression = drAccountExpenseWithTaxCode.Formula
                            myParser.OptimizationOn = True

                            drAccountExpenseWithTaxCode.Item("Formula") = myParser.ValueAsString()
                        Catch exception As Exception
                            System.Console.WriteLine(exception.StackTrace())
                            MsgBox(exception.Message)
                        End Try
                        If CType(row.FindControl("TotalAmountTextBox"), TextBox).Text <> 0 Then
                            taxtotal1 = taxtotal1 + drAccountExpenseWithTaxCode.Item("Formula")
                        End If
                    End If
                End If
            End If
        Next
        Dim expenserow As GridViewRow
        For Each expenserow In Me.GridView2.Rows
            Dim ExpenseAccountTaxCodeId As Integer = CType(expenserow.FindControl("ddlAccountTaxCodeId1"), DropDownList).SelectedValue
            If ExpenseAccountTaxCodeId <> 0 Then
                Dim dtAccountExpenseWithTaxCodeExpense As AccountExpenseEntryforBilling.AccountTaxCodeDataTable = TimeBLL.GetAccountTimeExpenseBillingWithTaxCodeByAccountIdAndAccountTaxCodeId(DBUtilities.GetSessionAccountId, ExpenseAccountTaxCodeId)
                Dim drAccountExpenseWithTaxCodeExpense As AccountExpenseEntryforBilling.AccountTaxCodeRow

                If dtAccountExpenseWithTaxCodeExpense.Rows.Count > 0 Then
                    drAccountExpenseWithTaxCodeExpense = dtAccountExpenseWithTaxCodeExpense.Rows(0)
                    If CType(expenserow.FindControl("BilledAmountTextBox"), TextBox).Text = "" Then
                        CType(expenserow.FindControl("BilledAmountTextBox"), TextBox).Text = 0
                    End If
                    If Not IsDBNull(drAccountExpenseWithTaxCodeExpense.Item("TaxCode")) Then
                        Try
                            Dim myParser As MathParser
                            myParser = New MathParser
                            myParser.X = Double.Parse(CType(expenserow.FindControl("BilledAmountTextBox"), TextBox).Text)
                            myParser.SetVariable("Net", Double.Parse(CType(expenserow.FindControl("BilledAmountTextBox"), TextBox).Text), Nothing)
                            myParser.Expression = drAccountExpenseWithTaxCodeExpense.Formula
                            myParser.OptimizationOn = True
                            drAccountExpenseWithTaxCodeExpense.Item("Formula") = myParser.ValueAsString()

                        Catch exception As Exception
                            System.Console.WriteLine(exception.StackTrace())
                            MsgBox(exception.Message)
                        End Try
                        If CType(expenserow.FindControl("BilledAmountTextBox"), TextBox).Text <> 0 Then
                            ExpenseTaxTotal1 = ExpenseTaxTotal1 + drAccountExpenseWithTaxCodeExpense.Item("Formula")
                        End If

                    End If
                End If
            End If
        Next
        If LocaleUtilitiesBLL.RoundOffValueInInvoice Then
            CType(Me.FormView2.FindControl("Tax1TextBox"), TextBox).Text = Math.Round(taxtotal1 + ExpenseTaxTotal1, 2)
        Else
            CType(Me.FormView2.FindControl("Tax1TextBox"), TextBox).Text = taxtotal1 + ExpenseTaxTotal1
        End If

        'GrandTotalAmount = CSng(CType(Me.FormView2.FindControl("SubTotalTextBox"), TextBox).Text) + CSng(CType(Me.FormView2.FindControl("Tax1TextBox"), TextBox).Text) + CSng(CType(Me.FormView2.FindControl("Tax2TextBox"), TextBox).Text)
        GrandTotalAmount = CDbl(CType(Me.FormView2.FindControl("SubTotalTextBox"), TextBox).Text) + CDbl(CType(Me.FormView2.FindControl("Tax1TextBox"), TextBox).Text) + CDbl(CType(Me.FormView2.FindControl("Tax2TextBox"), TextBox).Text)
        CType(Me.FormView2.FindControl("GrandTotalTextBox"), TextBox).Text = String.Format("{0:N}", GrandTotalAmount)
        'CType(Me.FormView2.FindControl("GrandTotalTextBox"), TextBox).Text = Val(CType(Me.FormView2.FindControl("SubTotalTextBox"), TextBox).Text) + Val(CType(Me.FormView2.FindControl("Tax1TextBox"), TextBox).Text) + Val(CType(Me.FormView2.FindControl("Tax2TextBox"), TextBox).Text)
        If Me.GridView1.Rows.Count = 0 Then
            CType(Me.FormView2.FindControl("Tax1TextBox"), TextBox).Text = 0
            CType(Me.FormView2.FindControl("GrandTotalTextBox"), TextBox).Text = CType(Me.FormView2.FindControl("SubTotalTextBox"), TextBox).Text
        End If
    End Function
    Public Function GetAccountTaxCode1timesheet(ByVal row As GridViewRow) As Boolean
        Dim TimeBLL As New AccountTimeExpenseBillingBLL
        taxtotaltimesheet1 = 0
        Dim AccountTaxCodeId As Integer = CType(row.FindControl("ddlAccountTaxCodeId1"), DropDownList).SelectedValue
        If AccountTaxCodeId <> 0 Then
            Dim dtAccountExpenseWithTaxCode As AccountExpenseEntryforBilling.AccountTaxCodeDataTable = TimeBLL.GetAccountTimeExpenseBillingWithTaxCodeByAccountIdAndAccountTaxCodeId(DBUtilities.GetSessionAccountId, AccountTaxCodeId)
            Dim drAccountExpenseWithTaxCode As AccountExpenseEntryforBilling.AccountTaxCodeRow
            If dtAccountExpenseWithTaxCode.Rows.Count > 0 Then
                drAccountExpenseWithTaxCode = dtAccountExpenseWithTaxCode.Rows(0)
                If Not IsDBNull(drAccountExpenseWithTaxCode.Item("TaxCode")) Then
                    Try
                        Dim myParser As MathParser
                        myParser = New MathParser
                        myParser.X = Double.Parse(CType(row.FindControl("TotalAmountTextBox"), TextBox).Text)
                        myParser.SetVariable("Net", Double.Parse(CType(row.FindControl("TotalAmountTextBox"), TextBox).Text), Nothing)
                        myParser.Expression = drAccountExpenseWithTaxCode.Formula
                        myParser.OptimizationOn = True
                        drAccountExpenseWithTaxCode.Item("Formula") = myParser.ValueAsString()

                    Catch exception As Exception
                        System.Console.WriteLine(exception.StackTrace())
                        MsgBox(exception.Message)
                    End Try
                    If CType(row.FindControl("TotalAmountTextBox"), TextBox).Text <> 0 Then
                        taxtotaltimesheet1 = taxtotaltimesheet1 + drAccountExpenseWithTaxCode.Item("Formula")
                    End If
                End If
            End If
        End If
    End Function
    Public Function GetAccountTaxCode1expense(ByVal row As GridViewRow) As Boolean
        Dim TimeBLL As New AccountTimeExpenseBillingBLL
        taxtotalexpense1 = 0
        Dim AccountTaxCodeId As Integer = CType(row.FindControl("ddlAccountTaxCodeId1"), DropDownList).SelectedValue
        If AccountTaxCodeId <> 0 Then
            Dim dtAccountExpenseWithTaxCode As AccountExpenseEntryforBilling.AccountTaxCodeDataTable = TimeBLL.GetAccountTimeExpenseBillingWithTaxCodeByAccountIdAndAccountTaxCodeId(DBUtilities.GetSessionAccountId, AccountTaxCodeId)
            Dim drAccountExpenseWithTaxCode As AccountExpenseEntryforBilling.AccountTaxCodeRow
            If dtAccountExpenseWithTaxCode.Rows.Count > 0 Then
                drAccountExpenseWithTaxCode = dtAccountExpenseWithTaxCode.Rows(0)

                If Not IsDBNull(drAccountExpenseWithTaxCode.Item("TaxCode")) Then
                    Try
                        Dim myParser As MathParser
                        myParser = New MathParser

                        myParser.X = Double.Parse(CType(row.FindControl("BilledAmountTextBox"), TextBox).Text)
                        myParser.SetVariable("Net", Double.Parse(CType(row.FindControl("BilledAmountTextBox"), TextBox).Text), Nothing)
                        myParser.Expression = drAccountExpenseWithTaxCode.Formula
                        myParser.OptimizationOn = True
                        drAccountExpenseWithTaxCode.Item("Formula") = myParser.ValueAsString()

                    Catch exception As Exception
                        System.Console.WriteLine(exception.StackTrace())
                        MsgBox(exception.Message)
                    End Try
                    If CType(row.FindControl("BilledAmountTextBox"), TextBox).Text <> 0 Then
                        taxtotalexpense1 = drAccountExpenseWithTaxCode.Item("Formula")
                    End If
                End If
            End If
        End If
    End Function
    Public Function GetAccountTaxCode2() As Boolean
        Dim TimeBLL As New AccountTimeExpenseBillingBLL
        Dim row As GridViewRow
        taxtotal2 = 0
        ExpenseTaxTotal2 = 0
        For Each row In Me.GridView1.Rows
            Dim AccountTaxCodeId As Integer = CType(row.FindControl("ddlAccountTaxCodeId2"), DropDownList).SelectedValue
            If AccountTaxCodeId <> 0 Then
                Dim dtAccountExpenseWithTaxCode As AccountExpenseEntryforBilling.AccountTaxCodeDataTable = TimeBLL.GetAccountTimeExpenseBillingWithTaxCodeByAccountIdAndAccountTaxCodeId(DBUtilities.GetSessionAccountId, AccountTaxCodeId)
                Dim drAccountExpenseWithTaxCode As AccountExpenseEntryforBilling.AccountTaxCodeRow
                If dtAccountExpenseWithTaxCode.Rows.Count > 0 Then
                    drAccountExpenseWithTaxCode = dtAccountExpenseWithTaxCode.Rows(0)

                    If Not IsDBNull(drAccountExpenseWithTaxCode.Item("TaxCode")) Then
                        Try
                            Dim myParser As MathParser
                            myParser = New MathParser

                            myParser.X = Double.Parse(CType(row.FindControl("TotalAmountTextBox"), TextBox).Text)
                            myParser.SetVariable("Net", Double.Parse(CType(row.FindControl("TotalAmountTextBox"), TextBox).Text), Nothing)
                            myParser.Expression = drAccountExpenseWithTaxCode.Formula
                            myParser.OptimizationOn = True

                            drAccountExpenseWithTaxCode.Item("Formula") = myParser.ValueAsString()

                        Catch exception As Exception
                            System.Console.WriteLine(exception.StackTrace())
                            MsgBox(exception.Message)
                        End Try
                        If CType(row.FindControl("TotalAmountTextBox"), TextBox).Text <> 0 Then
                            taxtotal2 = taxtotal2 + drAccountExpenseWithTaxCode.Item("Formula")
                        End If
                    End If
                End If
            End If
        Next
        Dim expenserow As GridViewRow
        For Each expenserow In Me.GridView2.Rows
            Dim ExpenseAccountTaxCodeId As Integer = CType(expenserow.FindControl("ddlAccountTaxCodeId2"), DropDownList).SelectedValue
            If ExpenseAccountTaxCodeId <> 0 Then
                Dim dtAccountExpenseWithTaxCodeExpense As AccountExpenseEntryforBilling.AccountTaxCodeDataTable = TimeBLL.GetAccountTimeExpenseBillingWithTaxCodeByAccountIdAndAccountTaxCodeId(DBUtilities.GetSessionAccountId, ExpenseAccountTaxCodeId)
                Dim drAccountExpenseWithTaxCodeExpense As AccountExpenseEntryforBilling.AccountTaxCodeRow

                If dtAccountExpenseWithTaxCodeExpense.Rows.Count > 0 Then
                    drAccountExpenseWithTaxCodeExpense = dtAccountExpenseWithTaxCodeExpense.Rows(0)
                    If CType(expenserow.FindControl("BilledAmountTextBox"), TextBox).Text = "" Then
                        CType(expenserow.FindControl("BilledAmountTextBox"), TextBox).Text = 0
                    End If
                    If Not IsDBNull(drAccountExpenseWithTaxCodeExpense.Item("TaxCode")) Then
                        Try
                            Dim myParser As MathParser
                            myParser = New MathParser
                            myParser.X = Double.Parse(CType(expenserow.FindControl("BilledAmountTextBox"), TextBox).Text)
                            myParser.SetVariable("Net", Double.Parse(CType(expenserow.FindControl("BilledAmountTextBox"), TextBox).Text), Nothing)
                            myParser.Expression = drAccountExpenseWithTaxCodeExpense.Formula
                            myParser.OptimizationOn = True

                            drAccountExpenseWithTaxCodeExpense.Item("Formula") = myParser.ValueAsString()

                        Catch exception As Exception
                            System.Console.WriteLine(exception.StackTrace())
                            MsgBox(exception.Message)
                        End Try
                        If CType(expenserow.FindControl("BilledAmountTextBox"), TextBox).Text <> 0 Then
                            ExpenseTaxTotal2 = ExpenseTaxTotal2 + drAccountExpenseWithTaxCodeExpense.Item("Formula")
                        End If
                    End If
                End If
            End If
        Next
        If LocaleUtilitiesBLL.RoundOffValueInInvoice Then
            CType(Me.FormView2.FindControl("Tax2TextBox"), TextBox).Text = Math.Round(taxtotal2 + ExpenseTaxTotal2, 2)
        Else
            CType(Me.FormView2.FindControl("Tax2TextBox"), TextBox).Text = taxtotal2 + ExpenseTaxTotal2
        End If
        'GrandTotalAmount = CSng(CType(Me.FormView2.FindControl("SubTotalTextBox"), TextBox).Text) + CSng(CType(Me.FormView2.FindControl("Tax1TextBox"), TextBox).Text) + CSng(CType(Me.FormView2.FindControl("Tax2TextBox"), TextBox).Text)
        GrandTotalAmount = CDbl(CType(Me.FormView2.FindControl("SubTotalTextBox"), TextBox).Text) + CDbl(CType(Me.FormView2.FindControl("Tax1TextBox"), TextBox).Text) + CDbl(CType(Me.FormView2.FindControl("Tax2TextBox"), TextBox).Text)
        CType(Me.FormView2.FindControl("GrandTotalTextBox"), TextBox).Text = String.Format("{0:N}", GrandTotalAmount)
        'CType(Me.FormView2.FindControl("GrandTotalTextBox"), TextBox).Text = Val(CType(Me.FormView2.FindControl("SubTotalTextBox"), TextBox).Text) + Val(CType(Me.FormView2.FindControl("Tax1TextBox"), TextBox).Text) + Val(CType(Me.FormView2.FindControl("Tax2TextBox"), TextBox).Text)
        If Me.GridView1.Rows.Count = 0 Then
            CType(Me.FormView2.FindControl("Tax2TextBox"), TextBox).Text = 0
            CType(Me.FormView2.FindControl("GrandTotalTextBox"), TextBox).Text = CType(Me.FormView2.FindControl("SubTotalTextBox"), TextBox).Text
        End If
    End Function
    Public Function GetAccountTaxCode2timesheet(ByVal row As GridViewRow) As Boolean
        Dim TimeBLL As New AccountTimeExpenseBillingBLL
        taxtotaltimesheet2 = 0
        Dim AccountTaxCodeId As Integer = CType(row.FindControl("ddlAccountTaxCodeId2"), DropDownList).SelectedValue
        If AccountTaxCodeId <> 0 Then
            Dim dtAccountExpenseWithTaxCode As AccountExpenseEntryforBilling.AccountTaxCodeDataTable = TimeBLL.GetAccountTimeExpenseBillingWithTaxCodeByAccountIdAndAccountTaxCodeId(DBUtilities.GetSessionAccountId, AccountTaxCodeId)
            Dim drAccountExpenseWithTaxCode As AccountExpenseEntryforBilling.AccountTaxCodeRow

            If dtAccountExpenseWithTaxCode.Rows.Count > 0 Then
                drAccountExpenseWithTaxCode = dtAccountExpenseWithTaxCode.Rows(0)

                If Not IsDBNull(drAccountExpenseWithTaxCode.Item("TaxCode")) Then
                    Try
                        Dim myParser As MathParser
                        myParser = New MathParser
                        myParser.X = Double.Parse(CType(row.FindControl("TotalAmountTextBox"), TextBox).Text)
                        myParser.SetVariable("Net", Double.Parse(CType(row.FindControl("TotalAmountTextBox"), TextBox).Text), Nothing)
                        myParser.Expression = drAccountExpenseWithTaxCode.Formula
                        myParser.OptimizationOn = True
                        drAccountExpenseWithTaxCode.Item("Formula") = myParser.ValueAsString()

                    Catch exception As Exception
                        System.Console.WriteLine(exception.StackTrace())
                        MsgBox(exception.Message)
                    End Try
                    If CType(row.FindControl("TotalAmountTextBox"), TextBox).Text <> 0 Then
                        taxtotaltimesheet2 = taxtotaltimesheet2 + drAccountExpenseWithTaxCode.Item("Formula")
                    End If
                End If
            End If
        End If
    End Function
    Public Function GetAccountTaxCode2expense(ByVal row As GridViewRow) As Boolean
        Dim TimeBLL As New AccountTimeExpenseBillingBLL
        taxtotalexpense2 = 0
        Dim AccountTaxCodeId As Integer = CType(row.FindControl("ddlAccountTaxCodeId2"), DropDownList).SelectedValue
        If AccountTaxCodeId <> 0 Then
            Dim dtAccountExpenseWithTaxCode As AccountExpenseEntryforBilling.AccountTaxCodeDataTable = TimeBLL.GetAccountTimeExpenseBillingWithTaxCodeByAccountIdAndAccountTaxCodeId(DBUtilities.GetSessionAccountId, AccountTaxCodeId)
            Dim drAccountExpenseWithTaxCode As AccountExpenseEntryforBilling.AccountTaxCodeRow

            If dtAccountExpenseWithTaxCode.Rows.Count > 0 Then
                drAccountExpenseWithTaxCode = dtAccountExpenseWithTaxCode.Rows(0)

                If Not IsDBNull(drAccountExpenseWithTaxCode.Item("TaxCode")) Then
                    Try
                        Dim myParser As MathParser
                        myParser = New MathParser
                        myParser.X = Double.Parse(CType(row.FindControl("BilledAmountTextBox"), TextBox).Text)
                        myParser.SetVariable("Net", Double.Parse(CType(row.FindControl("BilledAmountTextBox"), TextBox).Text), Nothing)
                        myParser.Expression = drAccountExpenseWithTaxCode.Formula
                        myParser.OptimizationOn = True

                        drAccountExpenseWithTaxCode.Item("Formula") = myParser.ValueAsString()
                    Catch exception As Exception
                        System.Console.WriteLine(exception.StackTrace())
                        MsgBox(exception.Message)
                    End Try
                    If CType(row.FindControl("BilledAmountTextBox"), TextBox).Text <> 0 Then
                        taxtotalexpense2 = drAccountExpenseWithTaxCode.Item("Formula")
                    End If
                End If
            End If
        End If
    End Function
    Protected Sub ddlAccountTaxCodeId1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.Calculation()
        GetAccountTaxCode1()
    End Sub
    Protected Sub ddlAccountTaxCodeId2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.Calculation()
        GetAccountTaxCode2()
    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim row As GridViewRow
        If Me.FormView1.CurrentMode = FormViewMode.Insert Then
            If Me.GetInvoiceNo <> True Then
                If Me.FormView1.DataKey("AccountTimeExpenseBillingId") <> System.Guid.Empty Then
                    Me.UpdateAccountTimeExpenseBilling()
                Else
                    Me.InsertAccountTimeExpenseBilling()
                End If
                For Each row In Me.GridView1.Rows
                    If Me.GridView1.DataKeys(row.RowIndex)("AccountTimeExpenseBillingId") <> System.Guid.Empty Then
                        Me.UpdateAccountTimeExpenseBillingTimesheet(row)
                    Else
                        Me.InsertAccountTimeExpenseBillingTimesheetNewRecord(row)
                    End If
                Next
                For Each row In Me.GridView2.Rows
                    If Me.GridView2.DataKeys(row.RowIndex)("AccountTimeExpenseBillingId") <> System.Guid.Empty Then
                        Me.UpdateAccountTimeExpenseBillingExpense(row)
                    Else
                        Me.InsertAccountTimeExpenseBillingExpenseNewRecord(row)
                    End If
                Next
                Response.Redirect("~/ProjectAdmin/AccountTimeExpenseBilling.aspx", False)
            End If
        End If
        If Me.FormView1.CurrentMode = FormViewMode.Edit Then
            Me.UpdateAccountTimeExpenseBilling()
            For Each row In Me.GridView1.Rows
                If Me.GridView1.DataKeys(row.RowIndex)("AccountTimeExpenseBillingTimesheetId") <> System.Guid.Empty Then
                    Me.UpdateAccountTimeExpenseBillingTimesheet(row)
                Else
                    Me.InsertAccountTimeExpenseBillingTimesheetNewRecord(row)
                End If
            Next
            For Each row In Me.GridView2.Rows
                If Me.GridView2.DataKeys(row.RowIndex)("AccountTimeExpenseBillingExpenseId") <> System.Guid.Empty Then
                    Me.UpdateAccountTimeExpenseBillingExpense(row)
                Else
                    Me.InsertAccountTimeExpenseBillingExpenseNewRecord(row)
                End If
            Next
            Response.Redirect("~/ProjectAdmin/AccountTimeExpenseBilling.aspx", False)
        End If
    End Sub
    Protected Sub btnPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        PrintInvoice = True
        Dim row As GridViewRow
        If Me.FormView1.CurrentMode = FormViewMode.Insert Then
            If Me.GetInvoiceNo <> True Then
                If Me.FormView1.DataKey("AccountTimeExpenseBillingId") <> System.Guid.Empty Then
                    Me.UpdateAccountTimeExpenseBilling()
                Else
                    Me.InsertAccountTimeExpenseBilling()
                End If
                For Each row In Me.GridView1.Rows
                    If Me.GridView1.DataKeys(row.RowIndex)("AccountTimeExpenseBillingId") <> System.Guid.Empty Then
                        Me.UpdateAccountTimeExpenseBillingTimesheet(row)
                    Else
                        Me.InsertAccountTimeExpenseBillingTimesheetNewRecord(row)
                    End If
                Next
                For Each row In Me.GridView2.Rows
                    If Me.GridView2.DataKeys(row.RowIndex)("AccountTimeExpenseBillingId") <> System.Guid.Empty Then
                        Me.UpdateAccountTimeExpenseBillingExpense(row)
                    Else
                        Me.InsertAccountTimeExpenseBillingExpenseNewRecord(row)
                    End If
                Next
                'Response.Redirect("~/Reports/AccountTimeExpenseBillingReport.aspx?AccountTimeExpenseBillingId=" & objTimeSheet.GetLastInsertedId.ToString, False)
            End If
        End If
        If Me.FormView1.CurrentMode = FormViewMode.Edit Then
            Me.UpdateAccountTimeExpenseBilling()
            For Each row In Me.GridView1.Rows
                If Me.GridView1.DataKeys(row.RowIndex)("AccountTimeExpenseBillingTimesheetId") <> System.Guid.Empty Then
                    Me.UpdateAccountTimeExpenseBillingTimesheet(row)
                Else
                    Me.InsertAccountTimeExpenseBillingTimesheetNewRecord(row)
                End If
            Next
            For Each row In Me.GridView2.Rows
                If Me.GridView2.DataKeys(row.RowIndex)("AccountTimeExpenseBillingExpenseId") <> System.Guid.Empty Then
                    Me.UpdateAccountTimeExpenseBillingExpense(row)
                Else
                    Me.InsertAccountTimeExpenseBillingExpenseNewRecord(row)
                End If
            Next
        End If
        If Me.FormView1.CurrentMode = FormViewMode.Insert Then
            Response.Redirect("~/Reports/AccountTimeExpenseBillingReport.aspx?AccountTimeExpenseBillingId=" & objTimeSheet.GetLastInsertedId.ToString, False)
        Else
            Response.Redirect("~/Reports/AccountTimeExpenseBillingReport.aspx?AccountTimeExpenseBillingId=" & Me.Request.QueryString("AccountTimeExpenseBillingId"), False)
        End If

    End Sub
    Protected Sub FormView1_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FormView1.DataBound
        AccountPagePermissionBLL.SetPagePermissionForGridView(129, Me.GridView1, Nothing, 10)
        AccountPagePermissionBLL.SetPagePermissionForGridView(129, Me.GridView2, Nothing, 8)
        If Me.FormView1.CurrentMode = FormViewMode.Insert Then
            Me.AutoInvoiceNumberNo(DBUtilities.GetSessionAccountId)
            CType(Me.FormView1.FindControl("ddlCurrencyId"), DropDownList).SelectedValue = DBUtilities.GetAccountBaseCurrencyId
            Me.dsAccountProjectObject.SelectParameters("AccountClientId").DefaultValue = CType(Me.FormView1.FindControl("ddlClientId"), DropDownList).SelectedValue
            Me.dsAccountProjectObjectTimesheet.SelectParameters("AccountClientId").DefaultValue = CType(Me.FormView1.FindControl("ddlClientId"), DropDownList).SelectedValue
            Me.dsAccountProjectObjectExpense.SelectParameters("AccountClientId").DefaultValue = CType(Me.FormView1.FindControl("ddlClientId"), DropDownList).SelectedValue

            If CType(Me.FormView1.FindControl("ddlClientId"), DropDownList).SelectedValue = "" Then
                btnSave.Enabled = False
                btnUpdate.Enabled = False
                btnPrint.Enabled = False
                CType(Me.FormView1.FindControl("btnPopulate"), Button).Enabled = False
            End If
            If CType(Me.FormView1.FindControl("ddlClientId"), DropDownList).SelectedValue <> "" Then
                Me.dsAccountProjectObject.SelectParameters("AccountClientId").DefaultValue = CType(Me.FormView1.FindControl("ddlClientId"), DropDownList).SelectedValue
            End If
            'If System.Configuration.ConfigurationManager.AppSettings("InvoiceDataSource") = "Yes" Then
            If DBUtilities.GetSessionAccountId = 7354 Then
                CType(Me.FormView1.FindControl("ddlInvoiceGroup"), DropDownList).SelectedValue = "TimeEntry"
            End If
        End If

        If Me.FormView1.CurrentMode = FormViewMode.Edit Then
            ''''Dim Original_AccountTimeExpenseBillingId As New Guid(Me.Request.QueryString("AccountTimeExpenseBillingId"))
            ''If Me.Request.QueryString("AccountTimeExpenseBillingId") Is Nothing Then
            If Not IsDBNull(Me.FormView1.DataItem("AccountClientId")) Then
                Me.dsAccountClientObjectEdit.SelectParameters("AccountPartyId").DefaultValue = Me.FormView1.DataItem("AccountClientId")
                CType(Me.FormView1.FindControl("ddlClientId"), DropDownList).SelectedValue = Me.FormView1.DataItem("AccountClientId")
            End If
            If Not IsDBNull(Me.FormView1.DataItem("AccountProjectId")) Then
                CType(Me.FormView1.FindControl("CascadingDropDown2"), AjaxControlToolkit.CascadingDropDown).SelectedValue = Me.FormView1.DataItem("AccountProjectId")
            End If
            If Not IsDBNull(Me.FormView1.DataItem("ParentAccountProjectTaskId")) Then
                CType(Me.FormView1.FindControl("ddlAccountProjectTaskIdCascadingDropDown"), AjaxControlToolkit.CascadingDropDown).SelectedValue = Me.FormView1.DataItem("ParentAccountProjectTaskId")
                'CType(Me.FormView1.FindControl("ddlParentTaskId"), DropDownList).SelectedValue = Me.FormView1.DataItem("ParentAccountProjectTaskId")
            End If
            If Not IsDBNull(Me.FormView1.DataItem("AccountClientId")) Then
                Me.dsAccountProjectObject.SelectParameters("AccountClientId").DefaultValue = Me.FormView1.DataItem("AccountClientId")
            End If
            If IsDBNull(Me.FormView1.DataItem("AccountClientId")) Then
                Me.dsAccountProjectObjectTimesheet.SelectParameters("AccountClientId").DefaultValue = CType(Me.FormView1.FindControl("ddlClientId"), DropDownList).SelectedValue
            Else
                Me.dsAccountProjectObjectTimesheet.SelectParameters("AccountClientId").DefaultValue = Me.FormView1.DataItem("AccountClientId")
            End If
            If IsDBNull(Me.FormView1.DataItem("AccountClientId")) Then
                Me.dsAccountProjectObjectExpense.SelectParameters("AccountClientId").DefaultValue = CType(Me.FormView1.FindControl("ddlClientId"), DropDownList).SelectedValue
            Else
                Me.dsAccountProjectObjectExpense.SelectParameters("AccountClientId").DefaultValue = Me.FormView1.DataItem("AccountClientId")
            End If
            If Not IsDBNull(Me.FormView1.DataItem("GroupTimesheetBillingListBy")) Then
                'Me.dsAccountClientObjectEdit.SelectParameters("AccountPartyId").DefaultValue = Me.FormView1.DataItem("AccountClientId")
                CType(Me.FormView1.FindControl("ddlInvoiceGroup"), DropDownList).SelectedValue = Me.FormView1.DataItem("GroupTimesheetBillingListBy")
            End If
            If Not IsDBNull(Me.FormView1.DataItem("GroupExpenseBillingListBy")) Then
                ''Me.dsAccountClientObjectEdit.SelectParameters("AccountPartyId").DefaultValue = Me.FormView1.DataItem("AccountClientId")
                CType(Me.FormView1.FindControl("ddlExpenseInvoiceGroup"), DropDownList).SelectedValue = Me.FormView1.DataItem("GroupExpenseBillingListBy")
            End If
            If Me.GridView1.Rows.Count <> 0 Or Me.GridView2.Rows.Count <> 0 Then
                CType(Me.FormView1.FindControl("ddlClientId"), DropDownList).Enabled = False
                If Me.GridView1.Rows.Count >= 10 Then
                    Me.GridView1.AllowPaging = False
                End If
                If Me.GridView2.Rows.Count >= 10 Then
                    Me.GridView2.AllowPaging = False
                End If
                If CType(Me.FormView1.FindControl("ddlClientId"), DropDownList).SelectedValue = "" Then
                    btnSave.Enabled = False
                    CType(Me.FormView1.FindControl("btnPopulateUpdate"), Button).Enabled = False
                End If
                Me.GridView1.DataBind()
                Me.GridView2.DataBind()
                Me.Calculation()
                Me.GetAccountTaxCode1()
                Me.GetAccountTaxCode2()
            End If
        End If
        If CType(Me.FormView1.FindControl("ddlClientId"), DropDownList).SelectedValue <> "" Then
            Me.btnSave.Attributes.Add("onclick", ResourceHelper.GetSaveMessageJavascriptForInvoice)
        Else
            Exit Sub
        End If
        Dim objRow As GridViewRow
        For Each objRow In Me.GridView1.Rows
            If CType(Me.FormView1.FindControl("ddlInvoiceGroup"), DropDownList).SelectedValue <> "ParentTask" Then
                CType(objRow.Cells(1).FindControl("ddlAccountProjectTaskId"), DropDownList).Visible = True
                CType(objRow.Cells(1).FindControl("ddlParentAccountProjectTaskId"), DropDownList).Visible = False
            Else
                CType(objRow.Cells(1).FindControl("ddlParentAccountProjectTaskId"), DropDownList).Visible = True
                CType(objRow.Cells(1).FindControl("ddlAccountProjectTaskId"), DropDownList).Visible = False
            End If
        Next

        ''Else
        ''Me.FormView1.Visible = True
        ' ''End If
    End Sub
    Private Sub AutoInvoiceNumberNo(ByVal AccountId As Integer)
        Dim TimeBLL As New AccountTimeExpenseBillingBLL
        Dim dtInvoiceNo As AccountTimeExpenseBilling.DataTable1DataTable = TimeBLL.GetAccountTimeExpenseBillingInvoiceNo(AccountId)
        Dim drInvoiceNo As AccountTimeExpenseBilling.DataTable1Row
        drInvoiceNo = dtInvoiceNo.Rows(0)
        If Not IsDBNull(drInvoiceNo.Item("InvoiceNo")) Then
            CType(Me.FormView1.FindControl("InvoiceNoTextBox"), TextBox).Text = drInvoiceNo.Item("InvoiceNo") + 1
        Else
            CType(Me.FormView1.FindControl("InvoiceNoTextBox"), TextBox).Text = 1
        End If
    End Sub
    Private Sub Calculation()

        If IsPopulate = False Then
            Dim TimesheetAmount As Double = 0
            Dim BilledAmount As Double = 0
            Dim row As GridViewRow

            For Each row In Me.GridView1.Rows
                If CType(row.FindControl("BillingRateTextBox"), TextBox).Text = "" Then
                    CType(row.FindControl("BillingRateTextBox"), TextBox).Text = 0
                End If
                If CType(row.FindControl("BillHoursTextBox"), TextBox).Text = "" Then
                    CType(row.FindControl("BillHoursTextBox"), TextBox).Text = 0
                End If
                If CType(Me.FormView1.FindControl("ddlInvoiceGroup"), DropDownList).SelectedValue <> "ParentTask" Then
                    CType(row.FindControl("TotalAmountTextBox"), TextBox).Text = String.Format("{0:n2}", CType(row.FindControl("BillingRateTextBox"), TextBox).Text * CType(row.FindControl("BillHoursTextBox"), TextBox).Text)
                Else
                    CType(row.FindControl("TotalAmountTextBox"), TextBox).Text = String.Format("{0:n2}", CType(row.FindControl("TotalAmountTextBox"), TextBox).Text)
                End If
                    TimesheetAmount = TimesheetAmount + CType(row.FindControl("TotalAmountTextBox"), TextBox).Text
            Next
            For Each row In Me.GridView2.Rows
                If CType(row.FindControl("BilledAmountTextbox"), TextBox).Text = "" Then
                    CType(row.FindControl("BilledAmountTextbox"), TextBox).Text = 0
                End If
                BilledAmount = BilledAmount + CType(row.FindControl("BilledAmountTextbox"), TextBox).Text
            Next

            CType(Me.FormView2.FindControl("SubTotalTextBox"), TextBox).Text = String.Format("{0:N}", TimesheetAmount + BilledAmount)

            'GrandTotalAmount = CSng(CType(Me.FormView2.FindControl("SubTotalTextBox"), TextBox).Text) + CSng(CType(Me.FormView2.FindControl("Tax1TextBox"), TextBox).Text) + CSng(CType(Me.FormView2.FindControl("Tax2TextBox"), TextBox).Text)
            GrandTotalAmount = CDbl(CType(Me.FormView2.FindControl("SubTotalTextBox"), TextBox).Text) + CDbl(CType(Me.FormView2.FindControl("Tax1TextBox"), TextBox).Text) + CDbl(CType(Me.FormView2.FindControl("Tax2TextBox"), TextBox).Text)
            CType(Me.FormView2.FindControl("GrandTotalTextBox"), TextBox).Text = String.Format("{0:N}", GrandTotalAmount)
            'CType(Me.FormView2.FindControl("GrandTotalTextBox"), TextBox).Text = Val(CType(Me.FormView2.FindControl("SubTotalTextBox"), TextBox).Text) + Val(CType(Me.FormView2.FindControl("Tax1TextBox"), TextBox).Text) + Val(CType(Me.FormView2.FindControl("Tax2TextBox"), TextBox).Text)
        End If
    End Sub
    Private Sub RowsCheck()
        Dim IsGroup As Boolean = False
        If CType(Me.FormView1.FindControl("ddlAccountProjectId"), DropDownList).SelectedValue = "" Then
            AccountProjectId = 0
        Else
            AccountProjectId = CType(Me.FormView1.FindControl("ddlAccountProjectId"), DropDownList).SelectedValue
        End If
        Dim dtTimeSheet As AccountTimeExpenseBilling.vueAccountTimeExpenseBillingTimesheetDataTable
        Dim dtExpenseSheet As AccountTimeExpenseBilling.vueAccountTimeExpenseBillingExpenseDataTable

        If CType(Me.FormView1.FindControl("ddlInvoiceGroup"), DropDownList).SelectedValue = "Task" Then
            dtTimeSheet = New AccountTimeExpenseBillingBLL().GetvueAccountTimeExpenseBillingTimesheetByAccountClientId(CType(Me.FormView1.FindControl("ddlClientId"), DropDownList).SelectedValue, CType(Me.FormView1.FindControl("BillingCycleStartDateTextBox"), eWorld.UI.CalendarPopup).SelectedDate, CType(Me.FormView1.FindControl("BillingCycleEndDateTextBox"), eWorld.UI.CalendarPopup).SelectedDate, AccountProjectId, CType(Me.FormView1.FindControl("ddlBillable"), DropDownList).SelectedValue, IIf(CType(Me.FormView1.FindControl("ddlParentTaskId"), DropDownList).SelectedValue = "", 0, CType(Me.FormView1.FindControl("ddlParentTaskId"), DropDownList).SelectedValue))
        ElseIf CType(Me.FormView1.FindControl("ddlInvoiceGroup"), DropDownList).SelectedValue = "TimeEntry" Then
            dtTimeSheet = New AccountTimeExpenseBillingBLL().GetvueAccountTimeExpenseBillingTimesheetByAccountClientIdWithTimeEntryGroup(CType(Me.FormView1.FindControl("ddlClientId"), DropDownList).SelectedValue, CType(Me.FormView1.FindControl("BillingCycleStartDateTextBox"), eWorld.UI.CalendarPopup).SelectedDate, CType(Me.FormView1.FindControl("BillingCycleEndDateTextBox"), eWorld.UI.CalendarPopup).SelectedDate, AccountProjectId, CType(Me.FormView1.FindControl("ddlBillable"), DropDownList).SelectedValue, IIf(CType(Me.FormView1.FindControl("ddlParentTaskId"), DropDownList).SelectedValue = "", 0, CType(Me.FormView1.FindControl("ddlParentTaskId"), DropDownList).SelectedValue))
        Else
            dtTimeSheet = New AccountTimeExpenseBillingBLL().GetvueAccountTimeExpenseBillingTimesheetByAccountClientIdForParentTask(CType(Me.FormView1.FindControl("ddlClientId"), DropDownList).SelectedValue, CType(Me.FormView1.FindControl("BillingCycleStartDateTextBox"), eWorld.UI.CalendarPopup).SelectedDate, CType(Me.FormView1.FindControl("BillingCycleEndDateTextBox"), eWorld.UI.CalendarPopup).SelectedDate, AccountProjectId, CType(Me.FormView1.FindControl("ddlBillable"), DropDownList).SelectedValue, IIf(CType(Me.FormView1.FindControl("ddlParentTaskId"), DropDownList).SelectedValue = "", 0, CType(Me.FormView1.FindControl("ddlParentTaskId"), DropDownList).SelectedValue))
        End If

        If CType(Me.FormView1.FindControl("ddlExpenseInvoiceGroup"), DropDownList).SelectedValue = "ExpenseName" Then
            dtExpenseSheet = New AccountTimeExpenseBillingBLL().GetvueAccountTimeExpenseBillingExpenseByAccountClientId(CType(Me.FormView1.FindControl("ddlClientId"), DropDownList).SelectedValue, CType(Me.FormView1.FindControl("BillingCycleStartDateTextBox"), eWorld.UI.CalendarPopup).SelectedDate, CType(Me.FormView1.FindControl("BillingCycleEndDateTextBox"), eWorld.UI.CalendarPopup).SelectedDate, AccountProjectId, CType(Me.FormView1.FindControl("ddlBillable"), DropDownList).SelectedValue)
        Else
            dtExpenseSheet = New AccountTimeExpenseBillingBLL().GetvueAccountTimeExpenseBillingExpenseByAccountClientIdWithExpenseEntryGroup(CType(Me.FormView1.FindControl("ddlClientId"), DropDownList).SelectedValue, CType(Me.FormView1.FindControl("BillingCycleStartDateTextBox"), eWorld.UI.CalendarPopup).SelectedDate, CType(Me.FormView1.FindControl("BillingCycleEndDateTextBox"), eWorld.UI.CalendarPopup).SelectedDate, AccountProjectId, CType(Me.FormView1.FindControl("ddlBillable"), DropDownList).SelectedValue)
        End If

        If dtTimeSheet.Rows.Count <> 0 Or dtExpenseSheet.Rows.Count <> 0 Then
            If Me.FormView1.CurrentMode = FormViewMode.Insert Then
                Me.InsertAccountTimeExpenseBilling()
                Me.InsertAccountTimeExpenseBillingTimesheet()
                Me.InsertAccountTimeExpenseBillingExpense()
                Me.btnPrint.Visible = True
                Me.UpdateCalculation()
                Response.Redirect("~/ProjectAdmin/AccountInvoiceForm.aspx?AccountTimeExpenseBillingId=" & objTimeSheet.GetLastInsertedId.ToString, False)
            Else
                Dim Original_AccountTimeExpenseBillingId As New Guid(Me.Request.QueryString("AccountTimeExpenseBillingId"))
                Dim AccountTimeExpenseBillingId = New AccountTimeExpenseBillingBLL().DeleteAccountTimeExpenseBilling(Original_AccountTimeExpenseBillingId)
                Dim AccountTimeExpenseBillingTimesheetId = New AccountTimeExpenseBillingBLL().DeleteAccountTimeExpenseBillingTimeSheet(Original_AccountTimeExpenseBillingId)
                Dim AccountTimeExpenseBillingExpenseId = New AccountTimeExpenseBillingBLL().DeleteAccountTimeExpenseBillingExpense(Original_AccountTimeExpenseBillingId)

                Me.InsertAccountTimeExpenseBilling()
                Me.InsertAccountTimeExpenseBillingTimesheet()
                Me.InsertAccountTimeExpenseBillingExpense()

                Me.btnPrint.Visible = True
                Me.UpdateCalculation()
                Response.Redirect("~/ProjectAdmin/AccountTimeExpenseBilling.aspx")
                ''temperary block this line..
                ''Response.Redirect("~/ProjectAdmin/AccountInvoiceForm.aspx?AccountTimeExpenseBillingId=" & objTimeSheet.GetLastInsertedId.ToString, False)
            End If
        End If
    End Sub
    Private Sub CurrencyCheck()
        Dim BaseCurrencyId As Integer
        If Not Me.IsPostBack Then
            CType(Me.FormView1.FindControl("ddlCurrencyId"), DropDownList).SelectedValue = BaseCurrencyId
        End If

        Dim dt As AccountCurrency.vueAccountCurrencyDataTable = New AccountCurrencyBLL().GetvueAccountCurrencyByAccountCurrencyId(IIf(CType(Me.FormView1.FindControl("ddlCurrencyId"), DropDownList).SelectedValue <> "", CType(Me.FormView1.FindControl("ddlCurrencyId"), DropDownList).SelectedValue, BaseCurrencyId))
        Dim dr As AccountCurrency.vueAccountCurrencyRow

        If dt.Rows.Count > 0 Then
            Dim timesheetrow As GridViewRow
            For Each timesheetrow In Me.GridView1.Rows
                dr = dt.Rows(0)
                If CType(timesheetrow.FindControl("TotalAmountTextBox"), TextBox).Text > 0 Then
                    CType(timesheetrow.FindControl("TotalAmountTextBox"), TextBox).Text = (CType(timesheetrow.FindControl("BillingRateTextBox"), TextBox).Text * CType(timesheetrow.FindControl("BillHoursTextBox"), TextBox).Text) / Me.GridView1.DataKeys(timesheetrow.RowIndex)(8) * dr.ExchangeRate
                End If
            Next
            Dim expenserow As GridViewRow
            For Each expenserow In Me.GridView2.Rows
                dr = dt.Rows(0)
                If CType(expenserow.FindControl("BilledAmountTextbox"), TextBox).Text > 0 Then
                    CType(expenserow.FindControl("BilledAmountTextbox"), TextBox).Text = Me.GridView2.DataKeys(expenserow.RowIndex)(7) / Me.GridView2.DataKeys(expenserow.RowIndex)(8) * dr.ExchangeRate
                End If
            Next
        End If
        Dim row As GridViewRow
        For Each row In Me.GridView1.Rows
            TimesheetAmount = TimesheetAmount + CType(row.FindControl("TotalAmountTextBox"), TextBox).Text
        Next
        For Each row In Me.GridView2.Rows
            BilledAmount = BilledAmount + CType(row.FindControl("BilledAmountTextbox"), TextBox).Text
        Next
        CType(Me.FormView2.FindControl("SubTotalTextBox"), TextBox).Text = String.Format("{0:N}", TimesheetAmount + BilledAmount)
        'GrandTotalAmount = CSng(CType(Me.FormView2.FindControl("SubTotalTextBox"), TextBox).Text) + CSng(CType(Me.FormView2.FindControl("Tax1TextBox"), TextBox).Text) + CSng(CType(Me.FormView2.FindControl("Tax2TextBox"), TextBox).Text)
        GrandTotalAmount = CDbl(CType(Me.FormView2.FindControl("SubTotalTextBox"), TextBox).Text) + CDbl(CType(Me.FormView2.FindControl("Tax1TextBox"), TextBox).Text) + CDbl(CType(Me.FormView2.FindControl("Tax2TextBox"), TextBox).Text)
        CType(Me.FormView2.FindControl("GrandTotalTextBox"), TextBox).Text = String.Format("{0:N}", GrandTotalAmount)
        'CType(Me.FormView2.FindControl("GrandTotalTextBox"), TextBox).Text = Val(CType(Me.FormView2.FindControl("SubTotalTextBox"), TextBox).Text) + Val(CType(Me.FormView2.FindControl("Tax1TextBox"), TextBox).Text) + Val(CType(Me.FormView2.FindControl("Tax2TextBox"), TextBox).Text)
    End Sub
    Public Function IsValidAllTextBoxValueTimesheet() As Boolean
        Dim AmountValue As Single
        Dim rowtimesheet As GridViewRow
        For Each rowtimesheet In Me.GridView1.Rows
            If Not Single.TryParse(CType(rowtimesheet.FindControl("BillingRateTextBox"), TextBox).Text, AmountValue) Then
                CType(rowtimesheet.FindControl("BillingRateTextBox"), TextBox).Text = 0
                Return False
            End If
        Next
        For Each rowtimesheet In Me.GridView1.Rows
            If Not Single.TryParse(CType(rowtimesheet.FindControl("BillHoursTextBox"), TextBox).Text, AmountValue) Then
                CType(rowtimesheet.FindControl("BillHoursTextBox"), TextBox).Text = 0
                Return False
            End If
        Next
        Return True
    End Function
    Public Function IsValidAllTextBoxValueExpensesheet() As Boolean
        Dim AmountValue As Single
        Dim rowexpensesheet As GridViewRow
        For Each rowexpensesheet In Me.GridView2.Rows
            If Not Single.TryParse(CType(rowexpensesheet.FindControl("BilledAmountTextBox"), TextBox).Text, AmountValue) Then
                CType(rowexpensesheet.FindControl("BilledAmountTextBox"), TextBox).Text = 0
                Return False
            End If
        Next
        Return True
    End Function
    Public Function IsValidInvoiceNoTextBox() As Boolean
        Dim TimeBLL As New AccountTimeExpenseBillingBLL
        Dim dtInvoiceNo As AccountTimeExpenseBilling.DataTable1DataTable = TimeBLL.GetAccountTimeExpenseBillingInvoiceNo(DBUtilities.GetSessionAccountId)
        Dim drInvoiceNo As AccountTimeExpenseBilling.DataTable1Row
        drInvoiceNo = dtInvoiceNo.Rows(0)
        If Not IsDBNull(drInvoiceNo.Item("InvoiceNo")) Or IsDBNull(drInvoiceNo.Item("InvoiceNo")) Then
            Dim InvoiceNo As Single
            If Not Single.TryParse(CType(Me.FormView1.FindControl("InvoiceNoTextBox"), TextBox).Text, InvoiceNo) Then
                Dim AccountId = DBUtilities.GetSessionAccountId
                CType(FormView1.FindControl("InvoiceNoTextBox"), TextBox).Text = drInvoiceNo.Item("InvoiceNo") + 1
                Return False
            End If
            Return True
        Else
            CType(FormView1.FindControl("InvoiceNoTextBox"), TextBox).Text = 1
        End If
    End Function
    Public Sub UpdateCalculation()
        If IsPopulate = True Then
            Dim AccountTimeExpenseBillingId = New AccountTimeExpenseBillingBLL().GetLastInsertedId
            Dim TaxCode1 = 0
            Dim TaxCode2 = 0
            Dim SubTotal As Double = 0
            'Timesheet
            Dim dtTimeSheet As AccountTimeExpenseBilling.ViewAccountTimeExpenseBillingTimesheetforEditDataTable = New AccountTimeExpenseBillingBLL().GetvueAccountTimeExpenseBillingTimesheetByAccountTimeExpenseBillingIdForCalculation(AccountTimeExpenseBillingId, IsPopulate)
            Dim drTimeSheet As AccountTimeExpenseBilling.ViewAccountTimeExpenseBillingTimesheetforEditRow
            If dtTimeSheet.Rows.Count > 0 Then
                drTimeSheet = dtTimeSheet.Rows(0)
                For Each drTimeSheet In dtTimeSheet.Rows
                    SubTotal = SubTotal + drTimeSheet.TotalAmount
                Next
            End If
            'Expensesheet
            Dim dtExpenseSheet As AccountTimeExpenseBilling.vueAccountTimeExpenseBillingExpenseForEditDataTable = New AccountTimeExpenseBillingBLL().GetvueAccountTimeExpenseBillingExpenseByAccountTimeExpenseBillingId(AccountTimeExpenseBillingId)
            Dim drExpenseSheet As AccountTimeExpenseBilling.vueAccountTimeExpenseBillingExpenseForEditRow
            If dtExpenseSheet.Rows.Count > 0 Then
                drExpenseSheet = dtExpenseSheet.Rows(0)
                For Each drExpenseSheet In dtExpenseSheet.Rows
                    SubTotal = SubTotal + drExpenseSheet.BilledExpenseAmount
                Next
            End If
            'TimeExpenseBilling
            Dim dtbilling As AccountTimeExpenseBilling.AccountTimeExpenseBillingDataTable = New AccountTimeExpenseBillingBLL().GetAccountTimeExpenseBillingByAccountIdAndAccountTimeExpenseBillingId(DBUtilities.GetSessionAccountId, AccountTimeExpenseBillingId)
            Dim drbilling As AccountTimeExpenseBilling.AccountTimeExpenseBillingRow
            If dtbilling.Rows.Count > 0 Then
                drbilling = dtbilling.Rows(0)
                CType(Me.FormView2.FindControl("SubTotalTextBox"), TextBox).Text = SubTotal
                If LocaleUtilitiesBLL.RoundOffValueInInvoice Then
                    CType(Me.FormView2.FindControl("Tax1TextBox"), TextBox).Text = Math.Round(TaxCode1, 2)
                    CType(Me.FormView2.FindControl("Tax2TextBox"), TextBox).Text = Math.Round(TaxCode2, 2)
                Else
                    CType(Me.FormView2.FindControl("Tax1TextBox"), TextBox).Text = TaxCode1
                    CType(Me.FormView2.FindControl("Tax2TextBox"), TextBox).Text = TaxCode2
                End If
                CType(Me.FormView2.FindControl("GrandTotalTextBox"), TextBox).Text = SubTotal
                objTimeSheet.UpdateAccountTimeExpenseBilling(AccountTimeExpenseBillingId, DBUtilities.GetSessionAccountId, CType(Me.FormView1.FindControl("ddlClientId"), DropDownList).SelectedValue, AccountProjectId, CType(Me.FormView1.FindControl("ddlCurrencyId"), DropDownList).SelectedValue, CType(Me.FormView2.FindControl("DescriptionTextBox"), TextBox).Text, CType(Me.FormView1.FindControl("BillingCycleStartDateTextBox"), eWorld.UI.CalendarPopup).SelectedDate, CType(Me.FormView1.FindControl("BillingCycleEndDateTextBox"), eWorld.UI.CalendarPopup).SelectedDate, CType(Me.FormView1.FindControl("InvoiceDateTextBox"), eWorld.UI.CalendarPopup).SelectedDate, CType(Me.FormView1.FindControl("InvoiceNoTextBox"), TextBox).Text, CType(Me.FormView1.FindControl("PONumberTextBox"), TextBox).Text, CType(Me.FormView2.FindControl("SubTotalTextBox"), TextBox).Text, CType(Me.FormView2.FindControl("Tax1TextBox"), TextBox).Text, CType(Me.FormView2.FindControl("Tax2TextBox"), TextBox).Text, CType(Me.FormView2.FindControl("GrandTotalTextBox"), TextBox).Text, "", "", IIf(CType(Me.FormView1.FindControl("ddlParentTaskId"), DropDownList).SelectedValue = "", 0, CType(Me.FormView1.FindControl("ddlParentTaskId"), DropDownList).SelectedValue), CType(Me.FormView1.FindControl("ddlInvoiceGroup"), DropDownList).SelectedValue, CType(Me.FormView1.FindControl("ddlExpenseInvoiceGroup"), DropDownList).SelectedValue)
            End If
            End If
    End Sub
    Protected Sub InvoiceNoTextBox_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not IsValidInvoiceNoTextBox() Then
            Return
        End If
        If Not CType(Me.FormView1.FindControl("InvoiceNoTextBox"), TextBox).Text = "" Then
            Me.GetInvoiceNo()
        End If
    End Sub
    Protected Sub CustomValidator2_ServerValidate1(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs)
        If Me.GetInvoiceNo = True Then
            args.IsValid = False
        End If
    End Sub
    Public Function GetInvoiceNo() As Boolean
        Dim TimeBLL As New AccountTimeExpenseBillingBLL
        Dim dtCheckInvoiceNo As AccountTimeExpenseBilling.vueAccountTimeExpenseBillingDataTable = TimeBLL.GetAccountTimeExpenseBillingByCheckInvoiceNo(DBUtilities.GetSessionAccountId, CType(Me.FormView1.FindControl("InvoiceNoTextBox"), TextBox).Text)
        If dtCheckInvoiceNo.Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs)
        Call New AccountTimeExpenseBillingBLL().DeleteAccountTimeExpenseBillingTimeSheetGridView(Me.GridView1.DataKeys(e.RowIndex)("AccountTimeExpenseBillingTimesheetId"))
        e.Cancel = True
        Me.GridView1.DataBind()
        Me.GetAccountTaxCode1()
        Me.GetAccountTaxCode2()
        Me.Calculation()
        If Not Me.GridView1.DataKeys(e.RowIndex)("AccountTimeExpenseBillingTimesheetId") = System.Guid.Empty Then
            Me.UpdateAccountTimeExpenseBilling()
        End If
    End Sub
    Protected Sub GridView2_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs)
        Call New AccountTimeExpenseBillingBLL().DeleteAccountTimeExpenseBillingExpenseGridView(Me.GridView2.DataKeys(e.RowIndex)("AccountTimeExpenseBillingExpenseId"))
        e.Cancel = True
        Me.GridView2.DataBind()
        Me.GetAccountTaxCode1()
        Me.GetAccountTaxCode2()
        Me.Calculation()
        If Not Me.GridView2.DataKeys(e.RowIndex)("AccountTimeExpenseBillingExpenseId") = System.Guid.Empty Then
            Me.UpdateAccountTimeExpenseBilling()
        End If
    End Sub
    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Response.Redirect("~/ProjectAdmin/AccountTimeExpenseBilling.aspx", False)
    End Sub
    Protected Sub btnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        PrintInvoice = True
        Dim row As GridViewRow
        If Me.FormView1.CurrentMode = FormViewMode.Insert Then
            If Me.GetInvoiceNo <> True Then
                If Me.FormView1.DataKey("AccountTimeExpenseBillingId") <> System.Guid.Empty Then
                    Me.UpdateAccountTimeExpenseBilling()
                Else
                    Me.InsertAccountTimeExpenseBilling()
                End If

                For Each row In Me.GridView1.Rows
                    If Me.GridView1.DataKeys(row.RowIndex)("AccountTimeExpenseBillingId") <> System.Guid.Empty Then
                        Me.UpdateAccountTimeExpenseBillingTimesheet(row)
                    Else
                        Me.InsertAccountTimeExpenseBillingTimesheetNewRecord(row)
                    End If
                Next
                For Each row In Me.GridView2.Rows
                    If Me.GridView2.DataKeys(row.RowIndex)("AccountTimeExpenseBillingId") <> System.Guid.Empty Then
                        Me.UpdateAccountTimeExpenseBillingExpense(row)
                    Else
                        Me.InsertAccountTimeExpenseBillingExpenseNewRecord(row)
                    End If
                Next
                Response.Redirect("~/ProjectAdmin/AccountTimeExpenseBilling.aspx", False)
            End If
        End If
        If Me.FormView1.CurrentMode = FormViewMode.Edit Then
            Me.UpdateAccountTimeExpenseBilling()

            For Each row In Me.GridView1.Rows
                If Me.GridView1.DataKeys(row.RowIndex)("AccountTimeExpenseBillingTimesheetId") <> System.Guid.Empty Then
                    Me.UpdateAccountTimeExpenseBillingTimesheet(row)
                Else
                    Me.InsertAccountTimeExpenseBillingTimesheetNewRecord(row)
                End If
            Next
            For Each row In Me.GridView2.Rows
                If Me.GridView2.DataKeys(row.RowIndex)("AccountTimeExpenseBillingExpenseId") <> System.Guid.Empty Then
                    Me.UpdateAccountTimeExpenseBillingExpense(row)
                Else
                    Me.InsertAccountTimeExpenseBillingExpenseNewRecord(row)
                End If
            Next
        End If
        Response.Redirect("~/ProjectAdmin/AccountTimeExpenseBilling.aspx", False)
    End Sub
    Protected Sub ddlClientId_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ProjectBll As New AccountProjectBLL
        Me.dsAccountProjectObjectTimesheet.SelectParameters("AccountClientId").DefaultValue = CType(Me.FormView1.FindControl("ddlClientId"), DropDownList).SelectedValue
        Me.dsAccountProjectObjectExpense.SelectParameters("AccountClientId").DefaultValue = CType(Me.FormView1.FindControl("ddlClientId"), DropDownList).SelectedValue
        Dim item As New System.Web.UI.WebControls.ListItem
        item.Text = "Select"
        item.Value = "0"
        Dim row As GridViewRow
        For Each row In Me.GridView2.Rows
            CType(row.Cells(0).FindControl("ddlAccountProjectId"), DropDownList).Items.Add(item)
        Next
        For Each row In Me.GridView1.Rows
            CType(row.Cells(0).FindControl("ddlAccountProjectId"), DropDownList).Items.Add(item)
        Next
        Me.GridView1.DataBind()
        Me.GridView2.DataBind()
    End Sub

    Protected Sub GridView1_DataBound(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim objRow As GridViewRow
        For Each objrow In Me.GridView1.Rows
            'Me.SetCascadingAccountId(objRow)
            'Me.SetCascadingAccountIdForParentTask(objRow)
        Next
        Dim dtclient As TimeLiveDataSet.AccountPartyDataTable = New AccountPartyBLL().GetAccountPartiesByAccountPartyId(CType(Me.FormView1.FindControl("ddlClientId"), DropDownList).SelectedValue)
        Dim drclient As TimeLiveDataSet.AccountPartyRow
        If dtclient.Rows.Count > 0 Then
            drclient = dtclient.Rows(0)
            If Not IsDBNull(drclient.Item("FixedBidBillingMode")) Then
                If drclient.FixedBidBillingMode <> 0 Then
                    Me.GridView1.Columns(5).Visible = False
                    Me.GridView1.Columns(6).Visible = False
                Else
                    Me.GridView1.Columns(5).Visible = True
                    Me.GridView1.Columns(6).Visible = True
                End If
            End If
        End If
        
    End Sub
    Public Sub SetCascadingAccountId(ByVal objRow As GridViewRow)
        Dim MyCascading As AjaxControlToolkit.CascadingDropDown
        MyCascading = CType(objRow.FindControl("ddlAccountProjectTaskIdCascadingDropDown"), AjaxControlToolkit.CascadingDropDown)
        Dim dsObject As ObjectDataSource
        dsObject = CType(objRow.Cells(0).FindControl("dsAccountProjectTasksObject"), ObjectDataSource)
        Dim AccountProjectTaskId As Integer = dsObject.SelectParameters("AccountProjectTaskId").DefaultValue
        MyCascading.Category = DBUtilities.GetSessionAccountId

    End Sub
    Public Sub SetCascadingAccountIdForParentTask(ByVal objRow As GridViewRow)
        Dim MyCascading As AjaxControlToolkit.CascadingDropDown
        MyCascading = CType(objRow.FindControl("ddlParentAccountProjectTaskId_CascadingDropDown"), AjaxControlToolkit.CascadingDropDown)
        Dim dsObject As ObjectDataSource
        dsObject = CType(objRow.Cells(0).FindControl("dsParentAccountProjectTasksObject"), ObjectDataSource)
        Dim AccountProjectTaskId As Integer = dsObject.SelectParameters("AccountProjectTaskId").DefaultValue
        MyCascading.Category = DBUtilities.GetSessionAccountId
    End Sub
    Public Sub SetTaskValueOnRowDataBound(ByVal objDropdown As DropDownList, ByVal dsObject As ObjectDataSource, ByVal dataValue As Object, ByVal MyCascading As AjaxControlToolkit.CascadingDropDown, ByVal Row As GridViewRow)
        objDropdown = CType(Row.Cells(1).FindControl("ddlAccountProjectTaskId"), DropDownList)
        dsObject = CType(Row.Cells(0).FindControl("dsAccountProjectTasksObject"), ObjectDataSource)
        If Not objDropdown Is Nothing Then
            If Not IsDBNull(DataBinder.Eval(Row.DataItem, "AccountProjectTaskId")) Then
                dataValue = DataBinder.Eval(Row.DataItem, "AccountProjectTaskId")
                objDropdown.SelectedValue = dataValue

            End If
        End If
        MyCascading = CType(Row.Cells(1).FindControl("ddlAccountProjectTaskIdCascadingDropDown"), AjaxControlToolkit.CascadingDropDown)
        MyCascading.SelectedValue = dataValue
        MyCascading.Category = DBUtilities.GetSessionAccountId
        objDropdown.SelectedValue = dataValue
    End Sub

    Protected Sub BilledAmountTextbox_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not IsValidAllTextBoxValueExpensesheet() Then
            Return
        End If
        Me.GetAccountTaxCode1()
        Me.GetAccountTaxCode2()
        Me.Calculation()
    End Sub

    Protected Sub BillHoursTextBox_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim row As GridViewRow
        If Not IsValidAllTextBoxValueTimesheet() Then
            Return
        End If
        For Each row In Me.GridView1.Rows
            If CType(Me.FormView1.FindControl("ddlInvoiceGroup"), DropDownList).SelectedValue <> "ParentTask" Then
                CType(row.FindControl("TotalAmountTextBox"), TextBox).Text = String.Format("{0:n2}", CType(row.FindControl("BillingRateTextBox"), TextBox).Text * CType(row.FindControl("BillHoursTextBox"), TextBox).Text)
            Else
                CType(row.FindControl("TotalAmountTextBox"), TextBox).Text = String.Format("{0:n2}", CType(row.FindControl("TotalAmountTextBox"), TextBox).Text)
            End If
            Me.GetAccountTaxCode1()
            Me.GetAccountTaxCode2()
        Next
        Me.Calculation()
    End Sub

    Protected Sub BillingRateTextBox_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim row As GridViewRow
        If Not IsValidAllTextBoxValueTimesheet() Then
            Return
        End If
        For Each row In Me.GridView1.Rows
            If CType(Me.FormView1.FindControl("ddlInvoiceGroup"), DropDownList).SelectedValue <> "ParentTask" Then
                CType(row.FindControl("TotalAmountTextBox"), TextBox).Text = String.Format("{0:n2}", CType(row.FindControl("BillingRateTextBox"), TextBox).Text * CType(row.FindControl("BillHoursTextBox"), TextBox).Text)
            Else
                CType(row.FindControl("TotalAmountTextBox"), TextBox).Text = String.Format("{0:n2}", CType(row.FindControl("TotalAmountTextBox"), TextBox).Text)
            End If
            Me.GetAccountTaxCode1()
            Me.GetAccountTaxCode2()
        Next
        Me.Calculation()
    End Sub
    Protected Sub ddlInvoiceGroup_SelectedIndexChanged(sender As Object, e As System.EventArgs)
        Dim objRow As GridViewRow
        For Each objRow In Me.GridView1.Rows
            If CType(Me.FormView1.FindControl("ddlInvoiceGroup"), DropDownList).SelectedValue <> "ParentTask" Then
                CType(objRow.Cells(1).FindControl("ddlAccountProjectTaskId"), DropDownList).Visible = True
                CType(objRow.Cells(1).FindControl("ddlParentAccountProjectTaskId"), DropDownList).Visible = False
            Else
                CType(objRow.Cells(1).FindControl("ddlParentAccountProjectTaskId"), DropDownList).Visible = True
                CType(objRow.Cells(1).FindControl("ddlAccountProjectTaskId"), DropDownList).Visible = False
            End If
        Next
    End Sub

    Protected Sub TotalAmountTextBox_TextChanged(sender As Object, e As System.EventArgs)
        Dim row As GridViewRow
        If Not IsValidAllTextBoxValueTimesheet() Then
            Return
        End If
        For Each row In Me.GridView1.Rows
            If CType(Me.FormView1.FindControl("ddlInvoiceGroup"), DropDownList).SelectedValue <> "ParentTask" Then
                CType(row.FindControl("TotalAmountTextBox"), TextBox).Text = String.Format("{0:n2}", CType(row.FindControl("BillingRateTextBox"), TextBox).Text * CType(row.FindControl("BillHoursTextBox"), TextBox).Text)
            Else
                CType(row.FindControl("TotalAmountTextBox"), TextBox).Text = String.Format("{0:n2}", CType(row.FindControl("TotalAmountTextBox"), TextBox).Text)
            End If
            Me.GetAccountTaxCode1()
            Me.GetAccountTaxCode2()
        Next
        Me.Calculation()
    End Sub

    Protected Sub FormView2_DataBound(sender As Object, e As System.EventArgs) Handles FormView2.DataBound
        If Me.FormView1.CurrentMode = FormViewMode.Insert Then
            CType(Me.FormView2.FindControl("DescriptionTextBox"), TextBox).Text = DBUtilities.GetInvoiceFooter
        End If
    End Sub

    Protected Sub ddlTaxCode1_SelectedIndexChanged(sender As Object, e As System.EventArgs)
        Dim row1 As GridViewRow
        For Each row1 In Me.GridView1.Rows
            CType(row1.FindControl("ddlAccountTaxCodeId1"), DropDownList).SelectedValue = CType(Me.FormView1.FindControl("ddlTaxCode1"), DropDownList).SelectedValue
        Next
        Dim row2 As GridViewRow
        For Each row2 In Me.GridView2.Rows
            CType(row2.FindControl("ddlAccountTaxCodeId1"), DropDownList).SelectedValue = CType(Me.FormView1.FindControl("ddlTaxCode1"), DropDownList).SelectedValue
        Next
        Me.Calculation()
        GetAccountTaxCode1()
    End Sub

    Protected Sub ddlTaxCode2_SelectedIndexChanged(sender As Object, e As System.EventArgs)
        Dim row1 As GridViewRow
        For Each row1 In Me.GridView1.Rows
            CType(row1.FindControl("ddlAccountTaxCodeId2"), DropDownList).SelectedValue = CType(Me.FormView1.FindControl("ddlTaxCode2"), DropDownList).SelectedValue
        Next
        Dim row2 As GridViewRow
        For Each row2 In Me.GridView2.Rows
            CType(row2.FindControl("ddlAccountTaxCodeId2"), DropDownList).SelectedValue = CType(Me.FormView1.FindControl("ddlTaxCode2"), DropDownList).SelectedValue
        Next
        Me.Calculation()
        GetAccountTaxCode2()
    End Sub
End Class