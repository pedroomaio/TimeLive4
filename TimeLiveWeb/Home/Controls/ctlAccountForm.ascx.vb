Imports System.DirectoryServices
Imports Microsoft.VisualBasic
Imports System.IO

Namespace TimeLive
    Partial Class ctlAccountForm
        Inherits System.Web.UI.UserControl
#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region
        Dim lblExceptionText As Label
        Dim cvTimesheetPrintFooterargs As Boolean
        Dim cvExpenseSheetPrintFooterargs As Boolean
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            Me.Page.Title = ResourceHelper.GetFromResource(Me.Page.Title)
            'Me.FormView1.FindControl("TabContainer1").FindControl("TabPanel1").Visible = False
            'Me.FindControl("Image1").Visible = False
            If Not Me.IsPostBack Then
                If Me.FormView1.CurrentMode = FormViewMode.Insert Then
                    Me.Page.FindControl("Image1").Visible = False
                    'If System.Configuration.ConfigurationManager.AppSettings("SHOW_LOGIN_WITH_ACCOUNT_PAGE") = "Yes" Then
                    '    Response.Redirect("~/Default.aspx", False)
                    'End If
                    'ShowUsername()
                    'CType(Me.FormView1.FindControl("ddlTimeZoneId"), DropDownList).SelectedValue = DBUtilities.GetTimeZoneId
                    'CType(Me.FormView1.FindControl("ddlCountryId"), DropDownList).SelectedValue = DBUtilities.GetAccountCountryId

                Else
                    ShowUsername()
                    If Me.FormView1.CurrentMode = FormViewMode.Edit Then
                        lblExceptionText = Me.FormView1.FindControl("ExceptionDetails")
                    End If
                End If

            Else
                ' ''If Me.FormView1.CurrentMode = FormViewMode.Edit Then
                ' ''    CType(Me.FormView1.FindControl("lblLicenseError"), Label).Visible = False
                ' ''    CType(Me.FormView1.FindControl("lblMachineKeyError"), Label).Visible = False
                ' ''End If
            End If

        End Sub
        Protected Sub FormView1_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FormView1.DataBound

            If Me.FormView1.CurrentMode = FormViewMode.Edit Then
                If DBUtilities.IsTimeOffFeature Then
                    CType(Me.FormView1.FindControl("TabContainer1").FindControl("TabPanel5"), AjaxControlToolkit.TabPanel).Enabled = True
                Else
                    CType(Me.FormView1.FindControl("TabContainer1").FindControl("TabPanel5"), AjaxControlToolkit.TabPanel).Enabled = False
                End If

                If DBUtilities.IsExpenseFeature Then
                    CType(Me.FormView1.FindControl("TabContainer1").FindControl("TabPanel6"), AjaxControlToolkit.TabPanel).Enabled = True
                Else
                    CType(Me.FormView1.FindControl("TabContainer1").FindControl("TabPanel6"), AjaxControlToolkit.TabPanel).Enabled = False
                End If

                If DBUtilities.IsTimesheetFeature Then
                    CType(Me.FormView1.FindControl("TabContainer1").FindControl("TabPanel7"), AjaxControlToolkit.TabPanel).Enabled = True
                Else
                    CType(Me.FormView1.FindControl("TabContainer1").FindControl("TabPanel7"), AjaxControlToolkit.TabPanel).Enabled = False
                End If

                If DBUtilities.IsProjectManagementFeature Then
                    CType(Me.FormView1.FindControl("TabContainer1").FindControl("TabPanel3"), AjaxControlToolkit.TabPanel).Enabled = True
                    CType(Me.FormView1.FindControl("TabContainer1").FindControl("TabPanel4"), AjaxControlToolkit.TabPanel).Enabled = True
                Else
                    CType(Me.FormView1.FindControl("TabContainer1").FindControl("TabPanel3"), AjaxControlToolkit.TabPanel).Enabled = False
                    CType(Me.FormView1.FindControl("TabContainer1").FindControl("TabPanel4"), AjaxControlToolkit.TabPanel).Enabled = False
                End If

                If DBUtilities.IsBillingFeature Then
                    CType(Me.FormView1.FindControl("TabContainer1").FindControl("TabPanel2"), AjaxControlToolkit.TabPanel).Enabled = True
                Else
                    CType(Me.FormView1.FindControl("TabContainer1").FindControl("TabPanel2"), AjaxControlToolkit.TabPanel).Enabled = False
                End If

                Me.FormView1.Visible = AccountPagePermissionBLL.IsPageHasPermissionOf(91, 3)

                Dim MaskedEditExtenderTPScheduledEmailSendTime As New AjaxControlToolkit.MaskedEditExtender
                MaskedEditExtenderTPScheduledEmailSendTime = CType(Me.FormView1.FindControl("TabContainer1").FindControl("TabPanel10").FindControl("MaskedEditExtenderTPScheduledEmailSendTime"), AjaxControlToolkit.MaskedEditExtender)
                MaskedEditExtenderTPScheduledEmailSendTime.AcceptAMPM = LocaleUtilitiesBLL.IsAcceptAMPMForTimeentry
                ''CType(Me.FormView1.FindControl("MaskedEditExtenderTPScheduledEmailSendTime"), AjaxControlToolkit.MaskedEditExtender).AcceptAMPM = LocaleUtilitiesBLL.IsAcceptAMPMForTimeentry
                If DBUtilities.IsNotSupportedCultureFormats = True Then
                    DBUtilities.SetMaskEditExtenderCultureToUS(MaskedEditExtenderTPScheduledEmailSendTime)
                    'CType(Me.FormView1.FindControl("TPScheduledEmailSendTime"), TextBox).Text = DBUtilities.GetTimeFromDateTimeInUSCulture(LocaleUtilitiesBLL.ShowScheduledEmailSendTime)
                End If


                'CType(Me.FormView1.FindControl("CultureInfoName"), DropDownList).SelectedValue = LocaleUtilitiesBLL.GetCurrentCulture
                Dim CultureInfoName As New DropDownList
                CultureInfoName = CType(Me.FormView1.FindControl("TabContainer1").FindControl("TabPanel10").FindControl("CultureInfoName"), DropDownList)
                CultureInfoName.SelectedValue = LocaleUtilitiesBLL.GetCurrentCultureForPreference

                Dim CurrencySymbol As New DropDownList
                CurrencySymbol = CType(Me.FormView1.FindControl("TabContainer1").FindControl("TabPanel10").FindControl("CurrencySymbol"), DropDownList)
                CurrencySymbol.SelectedValue = LocaleUtilitiesBLL.GetCurrencySymbol
                'CType(Me.FormView1.FindControl("CurrencySymbol"), DropDownList).SelectedValue = LocaleUtilitiesBLL.GetCurrencySymbol

                Dim ddlShowEmployeeNameBy As New DropDownList
                ddlShowEmployeeNameBy = CType(Me.FormView1.FindControl("TabContainer1").FindControl("TabPanel10").FindControl("ddlShowEmployeeNameBy"), DropDownList)
                ddlShowEmployeeNameBy.SelectedValue = DBUtilities.GetShowEmployeeNameBy

                ''Timesheet Setup
                'CType(Me.FormView1.FindControl("ddlTimeEntryFormat"), DropDownList).SelectedValue = LocaleUtilitiesBLL.GetCurrentTimeEntryFormat
                Dim TimeEntryFormat As New DropDownList
                TimeEntryFormat = CType(Me.FormView1.FindControl("TabContainer1").FindControl("TabPanel7").FindControl("ddlTimeEntryFormat"), DropDownList)
                TimeEntryFormat.SelectedValue = LocaleUtilitiesBLL.GetCurrentTimeEntryFormat

                'CType(Me.FormView1.FindControl("SessionTimeOutTextBox"), TextBox).Text = LocaleUtilitiesBLL.GetCurrentSessionTimeout
                Dim SessionTimeOutTextBox As New TextBox
                SessionTimeOutTextBox = CType(Me.FormView1.FindControl("TabContainer1").FindControl("TabPanel10").FindControl("SessionTimeOutTextBox"), TextBox)
                SessionTimeOutTextBox.Text = LocaleUtilitiesBLL.GetCurrentSessionTimeout


                'CType(Me.FormView1.FindControl("chkShowCompletedTasksInTimeSheet"), CheckBox).Checked = LocaleUtilitiesBLL.IsShowCompletedTasksInTimeSheet
                Dim chkShowCompletedTasksInTimeSheet As New CheckBox
                chkShowCompletedTasksInTimeSheet = CType(Me.FormView1.FindControl("TabContainer1").FindControl("TabPanel7").FindControl("chkShowCompletedTasksInTimeSheet"), CheckBox)
                chkShowCompletedTasksInTimeSheet.Checked = LocaleUtilitiesBLL.IsShowCompletedTasksInTimeSheet

                Dim chkShowCompletedProjectsInTimeSheet As New CheckBox
                chkShowCompletedProjectsInTimeSheet = CType(Me.FormView1.FindControl("TabContainer1").FindControl("TabPanel7").FindControl("chkShowCompletedProjectsInTimeSheet"), CheckBox)
                chkShowCompletedProjectsInTimeSheet.Checked = LocaleUtilitiesBLL.IsShowCompletedProjectsInTimeSheet
                'CType(Me.FormView1.FindControl("chkShowCompletedProjectsInTimeSheet"), CheckBox).Checked = LocaleUtilitiesBLL.IsShowCompletedProjectsInTimeSheet

                'CType(Me.FormView1.FindControl("chkShowWorkTypeInTimeSheet"), CheckBox).Checked = DBUtilities.IsShowWorkTypeInTimeSheet
                Dim chkShowWorkTypeInTimeSheet As New CheckBox
                chkShowWorkTypeInTimeSheet = CType(Me.FormView1.FindControl("TabContainer1").FindControl("TabPanel7").FindControl("chkShowWorkTypeInTimeSheet"), CheckBox)
                chkShowWorkTypeInTimeSheet.Checked = DBUtilities.IsShowWorkTypeInTimeSheet

                'CType(Me.FormView1.FindControl("chkShowCostCenterInTimeSheet"), CheckBox).Checked = DBUtilities.IsShowCostCenterInTimeSheet
                Dim chkShowCostCenterInTimeSheet As New CheckBox
                chkShowCostCenterInTimeSheet = CType(Me.FormView1.FindControl("TabContainer1").FindControl("TabPanel7").FindControl("chkShowCostCenterInTimeSheet"), CheckBox)
                chkShowCostCenterInTimeSheet.Checked = DBUtilities.IsShowCostCenterInTimeSheet

                'CType(Me.FormView1.FindControl("chkIsShowCompanyOwnLogo"), CheckBox).Checked = LocaleUtilitiesBLL.IsShowCompanyOwnLogo
                Dim chkIsShowCompanyOwnLogo As New CheckBox
                chkIsShowCompanyOwnLogo = CType(Me.FormView1.FindControl("TabContainer1").FindControl("TabPanel10").FindControl("chkIsShowCompanyOwnLogo"), CheckBox)
                chkIsShowCompanyOwnLogo.Checked = LocaleUtilitiesBLL.IsShowCompanyOwnLogo

                Dim TPScheduledEmailSendTime As New TextBox
                TPScheduledEmailSendTime = CType(Me.FormView1.FindControl("TabContainer1").FindControl("TabPanel10").FindControl("TPScheduledEmailSendTime"), TextBox)
                ''If DBUtilities.IsNotSupportedCultureFormats <> True Then
                If LocaleUtilitiesBLL.IsAcceptAMPMForTimeentry = False Then
                    TPScheduledEmailSendTime.Text = DBUtilities.GetTimeFromDateTime(LocaleUtilitiesBLL.ShowScheduledEmailSendTime, LocaleUtilitiesBLL.GetCurrentTimeEntryFormatForTotalTime)
                Else
                    TPScheduledEmailSendTime.Text = DBUtilities.GetTimeFromDateTime(LocaleUtilitiesBLL.ShowScheduledEmailSendTime)
                End If
                ''End If

                Dim FromEmailAddressDisplayNameTextBox As New TextBox
                FromEmailAddressDisplayNameTextBox = CType(Me.FormView1.FindControl("TabContainer1").FindControl("TabPanel10").FindControl("FromEmailAddressDisplayNameTextBox"), TextBox)
                FromEmailAddressDisplayNameTextBox.Text = DBUtilities.GetFromEmailAddressDisplayName

                'CType(Me.FormView1.FindControl("txtTimesheetPrintFooter"), TextBox).Text = DBUtilities.GetTimesheetPrintFooter
                Dim txtTimesheetPrintFooter As New TextBox
                txtTimesheetPrintFooter = CType(Me.FormView1.FindControl("TabContainer1").FindControl("TabPanel7").FindControl("txtTimesheetPrintFooter"), TextBox)
                txtTimesheetPrintFooter.Text = DBUtilities.GetTimesheetPrintFooter

                'CType(Me.FormView1.FindControl("txtExpenseSheetPrintFooter"), TextBox).Text = DBUtilities.GetExpenseSheetPrintFooter
                Dim txtExpenseSheetPrintFooter As New TextBox
                txtExpenseSheetPrintFooter = CType(Me.FormView1.FindControl("TabContainer1").FindControl("TabPanel6").FindControl("txtExpenseSheetPrintFooter"), TextBox)
                txtExpenseSheetPrintFooter.Text = DBUtilities.GetExpenseSheetPrintFooter

                'CType(Me.FormView1.FindControl("FromEmailAddressTextBox"), TextBox).Text = DBUtilities.GetFromEmailAddress
                Dim FromEmailAddressTextBox As New TextBox
                FromEmailAddressTextBox = CType(Me.FormView1.FindControl("TabContainer1").FindControl("TabPanel10").FindControl("FromEmailAddressTextBox"), TextBox)
                FromEmailAddressTextBox.Text = DBUtilities.GetFromEmailAddress

                'CType(Me.FormView1.FindControl("chkLockSubmittedRecord"), CheckBox).Checked = LocaleUtilitiesBLL.IsShowLockSubmittedRecords
                Dim chkLockSubmittedRecord As New CheckBox
                chkLockSubmittedRecord = CType(Me.FormView1.FindControl("TabContainer1").FindControl("TabPanel10").FindControl("chkLockSubmittedRecord"), CheckBox)
                chkLockSubmittedRecord.Checked = LocaleUtilitiesBLL.IsShowLockSubmittedRecords

                'CType(Me.FormView1.FindControl("chkLockApprovedRecord"), CheckBox).Checked = LocaleUtilitiesBLL.IsShowLockApprovedRecords
                Dim chkLockApprovedRecord As New CheckBox
                chkLockApprovedRecord = CType(Me.FormView1.FindControl("TabContainer1").FindControl("TabPanel10").FindControl("chkLockApprovedRecord"), CheckBox)
                chkLockApprovedRecord.Checked = LocaleUtilitiesBLL.IsShowLockApprovedRecords

                'CType(Me.FormView1.FindControl("txtNumberOfBlankRowsInTimeEntry"), TextBox).Text = DBUtilities.GetNumberOfBlankRowsInTimeEntry
                Dim txtNumberOfBlankRowsInTimeEntry As New TextBox
                txtNumberOfBlankRowsInTimeEntry = CType(Me.FormView1.FindControl("TabContainer1").FindControl("TabPanel7").FindControl("txtNumberOfBlankRowsInTimeEntry"), TextBox)
                txtNumberOfBlankRowsInTimeEntry.Text = DBUtilities.GetNumberOfBlankRowsInTimeEntry

                'CType(Me.FormView1.FindControl("ddlWeekStartDay"), DropDownList).SelectedValue = DBUtilities.GetWeekStartDayInWeekTimeEntry
                'CType(Me.FormView1.FindControl("ddlUserInterfaceLanguage"), DropDownList).SelectedValue = LocaleUtilitiesBLL.GetSavedCurrentUICulture
                'CType(Me.FormView1.FindControl("ddlDefaultTimeEntryMode"), DropDownList).SelectedValue = DBUtilities.GetDefaultTimeEntryMode
                Dim ddlDefaultTimeEntryMode As New DropDownList
                ddlDefaultTimeEntryMode = CType(Me.FormView1.FindControl("TabContainer1").FindControl("TabPanel7").FindControl("ddlDefaultTimeEntryMode"), DropDownList)
                ddlDefaultTimeEntryMode.SelectedValue = DBUtilities.GetDefaultTimeEntryMode

                Dim ddlTimesheetSort As New DropDownList
                ddlTimesheetSort = CType(Me.FormView1.FindControl("TabContainer1").FindControl("TabPanel7").FindControl("ddlTimesheetSort"), DropDownList)
                ddlTimesheetSort.SelectedValue = DBUtilities.GetSortTimesheet


                Dim ddlCostCenterInTimesheetBy As New DropDownList
                ddlCostCenterInTimesheetBy = CType(Me.FormView1.FindControl("TabContainer1").FindControl("TabPanel7").FindControl("ddlCostCenterInTimesheetBy"), DropDownList)
                ddlCostCenterInTimesheetBy.SelectedValue = DBUtilities.GetCostCenterInTimesheetBy

                Dim ddlPageSize As New DropDownList
                ddlPageSize = CType(Me.FormView1.FindControl("TabContainer1").FindControl("TabPanel10").FindControl("ddlPageSize"), DropDownList)
                ddlPageSize.SelectedValue = DBUtilities.GetPageSize

                Dim chkShowClientInTimeSheet As New CheckBox
                chkShowClientInTimeSheet = CType(Me.FormView1.FindControl("TabContainer1").FindControl("TabPanel7").FindControl("chkShowClientInTimeSheet"), CheckBox)
                chkShowClientInTimeSheet.Checked = DBUtilities.GetShowClientInTimesheet

                Dim chkShowDescriptionInWeekView As New CheckBox
                chkShowDescriptionInWeekView = CType(Me.FormView1.FindControl("TabContainer1").FindControl("TabPanel7").FindControl("chkShowDescriptionInWeekView"), CheckBox)
                chkShowDescriptionInWeekView.Checked = DBUtilities.GetShowDescriptionInWeekView

                Dim InvoiceNoPrefixTextBox As New TextBox
                InvoiceNoPrefixTextBox = CType(Me.FormView1.FindControl("TabContainer1").FindControl("TabPanel2").FindControl("InvoiceNoPrefixTextBox"), TextBox)
                InvoiceNoPrefixTextBox.Text = DBUtilities.GetInvoiceNoPrefix

                Dim ProjectCodePrefixTextBox As New TextBox
                ProjectCodePrefixTextBox = CType(Me.FormView1.FindControl("TabContainer1").FindControl("TabPanel4").FindControl("ProjectCodePrefixTextBox"), TextBox)
                ProjectCodePrefixTextBox.Text = DBUtilities.GetProjectCodePrefix

                Dim ddlTimeOffTypesBy As New DropDownList
                ddlTimeOffTypesBy = CType(Me.FormView1.FindControl("TabContainer1").FindControl("TabPanel5").FindControl("ddlTimeOffTypesBy"), DropDownList)
                ddlTimeOffTypesBy.SelectedValue = DBUtilities.GetTimeOffTypesBy

                Dim ddlClockStartEndBy As New DropDownList
                ddlClockStartEndBy = CType(Me.FormView1.FindControl("TabContainer1").FindControl("TabPanel7").FindControl("ddlClockStartEndBy"), DropDownList)
                ddlClockStartEndBy.SelectedValue = DBUtilities.GetClockStartEndBy

                Dim chkShowProjectForTimeOff As New CheckBox
                chkShowProjectForTimeOff = CType(Me.FormView1.FindControl("TabContainer1").FindControl("TabPanel5").FindControl("chkShowProjectForTimeOff"), CheckBox)
                chkShowProjectForTimeOff.Checked = LocaleUtilitiesBLL.IsShowProjectForTimeOff

                Dim chkIsTimeOffStatusEditMode As New CheckBox
                chkIsTimeOffStatusEditMode = CType(Me.FormView1.FindControl("TabContainer1").FindControl("TabPanel5").FindControl("chkIsTimeOffStatusEditMode"), CheckBox)
                chkIsTimeOffStatusEditMode.Checked = LocaleUtilitiesBLL.IsTimeOffStatusEditMode

                Dim chkTimeoffHorsinDays As New CheckBox
                chkTimeoffHorsinDays = CType(Me.FormView1.FindControl("TabContainer1").FindControl("TabPanel5").FindControl("chkTimeoffHorsinDays"), CheckBox)
                chkTimeoffHorsinDays.Checked = LocaleUtilitiesBLL.IsShowTimeOffInDays

                Dim chkShowDisableProjectInReport As New CheckBox
                chkShowDisableProjectInReport = CType(Me.FormView1.FindControl("TabContainer1").FindControl("TabPanel4").FindControl("chkShowDisableProjectInReport"), CheckBox)
                chkShowDisableProjectInReport.Checked = LocaleUtilitiesBLL.ShowDisableProjectInReport

                Dim chkShowTimeOffInTimesheet As New CheckBox
                chkShowTimeOffInTimesheet = CType(Me.FormView1.FindControl("TabContainer1").FindControl("TabPanel5").FindControl("chkShowTimeOffInTimesheet"), CheckBox)
                chkShowTimeOffInTimesheet.Checked = LocaleUtilitiesBLL.IsShowTimeOffInTimesheet

                Dim chkShowElectronicSign As New CheckBox
                chkShowElectronicSign = CType(Me.FormView1.FindControl("TabContainer1").FindControl("TabPanel10").FindControl("chkShowElectronicSign"), CheckBox)
                chkShowElectronicSign.Checked = LocaleUtilitiesBLL.IsShowElectronicSign

                Dim chkShowAdditionalDepartmentInformationInEmployee As New CheckBox
                chkShowAdditionalDepartmentInformationInEmployee = CType(Me.FormView1.FindControl("TabContainer1").FindControl("TabPanel10").FindControl("chkShowAdditionalDepartmentInformationInEmployee"), CheckBox)
                chkShowAdditionalDepartmentInformationInEmployee.Checked = LocaleUtilitiesBLL.ShowAdditionalDepartmentInformationInEmployee

                If Not System.Configuration.ConfigurationManager.AppSettings("GAppsAuthentication") Is Nothing Then
                    Dim txtDomainName As New TextBox
                    txtDomainName = CType(Me.FormView1.FindControl("TabContainer1").FindControl("TabPanel10").FindControl("txtDomainName"), TextBox)
                    txtDomainName.Text = DBUtilities.GoogleAppsDomain
                End If

                Dim ChkDefaultProjectTaskSelectionInTimesheet As New CheckBox
                ChkDefaultProjectTaskSelectionInTimesheet = CType(Me.FormView1.FindControl("TabContainer1").FindControl("TabPanel7").FindControl("ChkDefaultProjectTaskSelectionInTimesheet"), CheckBox)
                ChkDefaultProjectTaskSelectionInTimesheet.Checked = LocaleUtilitiesBLL.DefaultProjectTaskSelectionInTimesheet

                Dim ChkInsertDefaultTaskNameInProject As New CheckBox
                ChkInsertDefaultTaskNameInProject = CType(Me.FormView1.FindControl("TabContainer1").FindControl("TabPanel3").FindControl("ChkInsertDefaultTaskNameInProject"), CheckBox)
                ChkInsertDefaultTaskNameInProject.Checked = LocaleUtilitiesBLL.InsertDefaultTaskNameInProject

                Dim chkShowAllInTimesheetReadOnly As New CheckBox
                chkShowAllInTimesheetReadOnly = CType(Me.FormView1.FindControl("TabContainer1").FindControl("TabPanel7").FindControl("chkShowAllInTimesheetReadOnly"), CheckBox)
                chkShowAllInTimesheetReadOnly.Checked = LocaleUtilitiesBLL.ShowAllInTimesheetReadOnly

                Dim chkShowCompletedProjectInProjectGrid As New CheckBox
                chkShowCompletedProjectInProjectGrid = CType(Me.FormView1.FindControl("TabContainer1").FindControl("TabPanel4").FindControl("chkShowCompletedProjectInProjectGrid"), CheckBox)
                chkShowCompletedProjectInProjectGrid.Checked = LocaleUtilitiesBLL.ShowCompletedProjectInProjectGrid

                Dim chkShowPercentageInTimeSheet As New CheckBox
                chkShowPercentageInTimeSheet = CType(Me.FormView1.FindControl("TabContainer1").FindControl("TabPanel7").FindControl("chkShowPercentageInTimeSheet"), CheckBox)
                chkShowPercentageInTimeSheet.Checked = LocaleUtilitiesBLL.ShowPercentageInTimesheet

                Dim chkShowCopyTimesheetButton As New CheckBox
                chkShowCopyTimesheetButton = CType(Me.FormView1.FindControl("TabContainer1").FindControl("TabPanel7").FindControl("chkShowCopyTimesheetButton"), CheckBox)
                chkShowCopyTimesheetButton.Checked = DBUtilities.ShowCopyTimesheetButton

                Dim chkShowCopyActivitiesButtonInTimesheet As New CheckBox
                chkShowCopyActivitiesButtonInTimesheet = CType(Me.FormView1.FindControl("TabContainer1").FindControl("TabPanel7").FindControl("chkShowCopyActivitiesButtonInTimesheet"), CheckBox)
                chkShowCopyActivitiesButtonInTimesheet.Checked = DBUtilities.ShowCopyActivitiesButtonInTimesheet

                Dim chkShowClientInExpenseSheet As New CheckBox
                chkShowClientInExpenseSheet = CType(Me.FormView1.FindControl("TabContainer1").FindControl("TabPanel6").FindControl("chkShowClientInExpenseSheet"), CheckBox)
                chkShowClientInExpenseSheet.Checked = LocaleUtilitiesBLL.ShowClientInExpenseSheet

                Dim chkShowTaskInExpenseSheet As New CheckBox
                chkShowTaskInExpenseSheet = CType(Me.FormView1.FindControl("TabContainer1").FindControl("TabPanel6").FindControl("chkShowTaskInExpenseSheet"), CheckBox)
                chkShowTaskInExpenseSheet.Checked = LocaleUtilitiesBLL.ShowTaskInExpenseSheet

                Dim chkShowBillingRateInInvoiceReport As New CheckBox
                chkShowBillingRateInInvoiceReport = CType(Me.FormView1.FindControl("TabContainer1").FindControl("TabPanel2").FindControl("chkShowBillingRateInInvoiceReport"), CheckBox)
                chkShowBillingRateInInvoiceReport.Checked = LocaleUtilitiesBLL.ShowBillingRateInInvoiceReport

                Dim chkShowProjectNameInInvoiceReport As New CheckBox
                chkShowProjectNameInInvoiceReport = CType(Me.FormView1.FindControl("TabContainer1").FindControl("TabPanel2").FindControl("chkShowProjectNameInInvoiceReport"), CheckBox)
                chkShowProjectNameInInvoiceReport.Checked = LocaleUtilitiesBLL.ShowProjectNameInInvoiceReport

                Dim chkShowEntryDateInInvoiceReport As New CheckBox
                chkShowEntryDateInInvoiceReport = CType(Me.FormView1.FindControl("TabContainer1").FindControl("TabPanel2").FindControl("chkShowEntryDateInInvoiceReport"), CheckBox)
                chkShowEntryDateInInvoiceReport.Checked = DBUtilities.ShowEntryDateInInvoiceReport

                Dim chkShowEmployeeNameInInvoiceReport As New CheckBox
                chkShowEmployeeNameInInvoiceReport = CType(Me.FormView1.FindControl("TabContainer1").FindControl("TabPanel2").FindControl("chkShowEmployeeNameInInvoiceReport"), CheckBox)
                chkShowEmployeeNameInInvoiceReport.Checked = LocaleUtilitiesBLL.ShowEmployeeNameInInvoiceReport

                Dim chkShowWorkTypeInInvoiceDescription As New CheckBox
                chkShowWorkTypeInInvoiceDescription = CType(Me.FormView1.FindControl("TabContainer1").FindControl("TabPanel2").FindControl("chkShowWorkTypeInInvoiceDescription"), CheckBox)
                chkShowWorkTypeInInvoiceDescription.Checked = LocaleUtilitiesBLL.ShowWorkTypeInInvoiceDescription

                Dim chkRoundOffValueInInvoice As New CheckBox
                chkRoundOffValueInInvoice = CType(Me.FormView1.FindControl("TabContainer1").FindControl("TabPanel2").FindControl("chkRoundOffValueInInvoice"), CheckBox)
                chkRoundOffValueInInvoice.Checked = LocaleUtilitiesBLL.RoundOffValueInInvoice

                Dim chkIsProjectTemplateMandatory As New CheckBox
                chkIsProjectTemplateMandatory = CType(Me.FormView1.FindControl("TabContainer1").FindControl("TabPanel4").FindControl("chkIsProjectTemplateMandatory"), CheckBox)
                chkIsProjectTemplateMandatory.Checked = LocaleUtilitiesBLL.IsProjectTemplateMandatory

                Dim chkEnablePasswordComplexity As New CheckBox
                chkEnablePasswordComplexity = CType(Me.FormView1.FindControl("TabContainer1").FindControl("TabPanel10").FindControl("chkEnablePasswordComplexity"), CheckBox)
                chkEnablePasswordComplexity.Checked = DBUtilities.EnablePasswordComplexity

                Dim chkShowClientDepartmentInProject As New CheckBox
                chkShowClientDepartmentInProject = CType(Me.FormView1.FindControl("TabContainer1").FindControl("TabPanel4").FindControl("chkShowClientDepartmentInProject"), CheckBox)
                chkShowClientDepartmentInProject.Checked = DBUtilities.ShowClientDepartmentInProject

                Dim chkAutoGenerateProjectCode As New CheckBox
                chkAutoGenerateProjectCode = CType(Me.FormView1.FindControl("TabContainer1").FindControl("TabPanel4").FindControl("chkAutoGenerateProjectCode"), CheckBox)
                chkAutoGenerateProjectCode.Checked = LocaleUtilitiesBLL.AutoGenerateProjectCode

                Dim txtDefaultTaskName As New TextBox
                txtDefaultTaskName = CType(Me.FormView1.FindControl("TabContainer1").FindControl("TabPanel3").FindControl("txtDefaultTaskName"), TextBox)
                txtDefaultTaskName.Text = LocaleUtilitiesBLL.DefaultTaskName

                Dim ddlSortTaskBy As New DropDownList
                ddlSortTaskBy = CType(Me.FormView1.FindControl("TabContainer1").FindControl("TabPanel3").FindControl("ddlSortTaskBy"), DropDownList)
                ddlSortTaskBy.Text = DBUtilities.GetSortTask

                Dim txtInvoiceFooter As New TextBox
                txtInvoiceFooter = CType(Me.FormView1.FindControl("TabContainer1").FindControl("TabPanel2").FindControl("txtInvoiceFooter"), TextBox)
                txtInvoiceFooter.Text = DBUtilities.GetInvoiceFooter

                Dim txtTimesheetOverduePeriods As New TextBox
                txtTimesheetOverduePeriods = CType(Me.FormView1.FindControl("TabContainer1").FindControl("TabPanel7").FindControl("txtTimesheetOverduePeriods"), TextBox)
                txtTimesheetOverduePeriods.Text = DBUtilities.GetSessionTimesheetOverduePeriods

                Dim ddlTimeEntryHoursFormatId As New DropDownList
                ddlTimeEntryHoursFormatId = CType(Me.FormView1.FindControl("TabContainer1").FindControl("TabPanel7").FindControl("ddlTimeEntryHoursFormatId"), DropDownList)
                ddlTimeEntryHoursFormatId.SelectedValue = DBUtilities.GetSessionTimeEntryHoursFormat.ToString

                Dim ddlInvoiceBillingTypeId As New DropDownList
                ddlInvoiceBillingTypeId = CType(Me.FormView1.FindControl("TabContainer1").FindControl("TabPanel2").FindControl("ddlInvoiceBillingTypeId"), DropDownList)
                ddlInvoiceBillingTypeId.SelectedValue = DBUtilities.GetSessionInvoiceBillingType.ToString

                Dim chkShowProjectNameInTask As New CheckBox
                chkShowProjectNameInTask = CType(Me.FormView1.FindControl("TabContainer1").FindControl("TabPanel3").FindControl("chkShowProjectNameInTask"), CheckBox)
                chkShowProjectNameInTask.Checked = LocaleUtilitiesBLL.ShowProjectNameInTask

                Dim chkShowClientNameInTask As New CheckBox
                chkShowClientNameInTask = CType(Me.FormView1.FindControl("TabContainer1").FindControl("TabPanel3").FindControl("chkShowClientNameInTask"), CheckBox)
                chkShowClientNameInTask.Checked = LocaleUtilitiesBLL.ShowClientNameInTask

                Dim chkCalculateTaskPercentageAutomatically As New CheckBox
                chkCalculateTaskPercentageAutomatically = CType(Me.FormView1.FindControl("TabContainer1").FindControl("TabPanel7").FindControl("chkCalculateTaskPercentageAutomatically"), CheckBox)
                chkCalculateTaskPercentageAutomatically.Checked = LocaleUtilitiesBLL.EnableCalculateTaskPercentageAutomatically

                Dim chkAutoAdjustTimesheet As New CheckBox
                chkAutoAdjustTimesheet = CType(Me.FormView1.FindControl("TabContainer1").FindControl("TabPanel7").FindControl("chkAutoAdjustTimesheet"), CheckBox)
                chkAutoAdjustTimesheet.Checked = LocaleUtilitiesBLL.EnableAutoResizeTimesheet

                Dim chkIncludeCurrentYearInProjectCode As New CheckBox
                chkIncludeCurrentYearInProjectCode = CType(Me.FormView1.FindControl("TabContainer1").FindControl("TabPanel4").FindControl("chkIncludeCurrentYearInProjectCode"), CheckBox)
                chkIncludeCurrentYearInProjectCode.Checked = DBUtilities.IncludeCurrentYearInProjectCode

                Dim chkAutomaticallyIncludeAdministratorInProjectTeam As New CheckBox
                chkAutomaticallyIncludeAdministratorInProjectTeam = CType(Me.FormView1.FindControl("TabContainer1").FindControl("TabPanel4").FindControl("chkAutomaticallyIncludeAdministratorInProjectTeam"), CheckBox)
                chkAutomaticallyIncludeAdministratorInProjectTeam.Checked = DBUtilities.AutomaticallyIncludeAdminitratorInProjectTeam

                Dim chkEnableOfflineTimesheet As New CheckBox
                chkEnableOfflineTimesheet = CType(Me.FormView1.FindControl("TabContainer1").FindControl("TabPanel7").FindControl("chkEnableOfflineTimesheet"), CheckBox)
                chkEnableOfflineTimesheet.Checked = DBUtilities.EnableOfflineTimesheet

                Dim ddlTaskInformation As New DropDownList
                ddlTaskInformation = CType(Me.FormView1.FindControl("TabContainer1").FindControl("TabPanel7").FindControl("ddlTaskInformation"), DropDownList)
                ddlTaskInformation.SelectedValue = DBUtilities.GetShowAdditionalTaskInformationType

                Dim ddlProjectInformation As New DropDownList
                ddlProjectInformation = CType(Me.FormView1.FindControl("TabContainer1").FindControl("TabPanel7").FindControl("ddlProjectInformation"), DropDownList)
                ddlProjectInformation.SelectedValue = DBUtilities.GetShowAdditionalProjectInformationType

                Dim chkShowProjectInTimesheet As New CheckBox
                chkShowProjectInTimesheet = CType(Me.FormView1.FindControl("TabContainer1").FindControl("TabPanel7").FindControl("chkShowProjectInTimesheet"), CheckBox)
                chkShowProjectInTimesheet.Checked = DBUtilities.GetShowProjectInTimesheet

                Dim txtPasswordExpiryPeriod As New TextBox
                txtPasswordExpiryPeriod = CType(Me.FormView1.FindControl("TabContainer1").FindControl("TabPanel10").FindControl("txtPasswordExpiryPeriod"), TextBox)
                txtPasswordExpiryPeriod.Text = DBUtilities.GetPasswordExpiryPeriod

                Dim LDAP As New LDAPUtilitiesBLL
                If LDAP.IsAspNetActiveDirectoryMembershipProvider = True Then
                    CType(Me.FormView1.FindControl("TabContainer1").FindControl("TabPanel10").FindControl("RequiredFieldValidator3"), RequiredFieldValidator).Enabled = False
                    CType(Me.FormView1.FindControl("TabContainer1").FindControl("TabPanel10").FindControl("RequiredFieldValidator2"), RequiredFieldValidator).Enabled = False
                End If

                Dim ChkShowEmployeeNameWithCode As New CheckBox
                ChkShowEmployeeNameWithCode = CType(Me.FormView1.FindControl("TabContainer1").FindControl("TabPanel10").FindControl("ChkShowEmployeeNameWithCode"), CheckBox)
                ChkShowEmployeeNameWithCode.Checked = LocaleUtilitiesBLL.IsShowEmployeeNameWithCode

                Dim ChkGoogleAuthentication As New CheckBox
                ChkGoogleAuthentication = CType(Me.FormView1.FindControl("TabContainer1").FindControl("TabPanel10").FindControl("ChkGoogleAuthentication"), CheckBox)
                ChkGoogleAuthentication.Checked = LocaleUtilitiesBLL.EnableGoogleAuthentication

                Dim ChkShowDisableEmployeesInReport As New CheckBox
                ChkShowDisableEmployeesInReport = CType(Me.FormView1.FindControl("TabContainer1").FindControl("TabPanel10").FindControl("ChkShowDisableEmployeesInReport"), CheckBox)
                ChkShowDisableEmployeesInReport.Checked = LocaleUtilitiesBLL.IsShowDisableEmployeesInReport

                Dim ChkHideProjectFromApplication As New CheckBox
                ChkHideProjectFromApplication = CType(Me.FormView1.FindControl("TabContainer1").FindControl("TabPanel10").FindControl("ChkHideProjectFromApplication"), CheckBox)
                ChkHideProjectFromApplication.Checked = DBUtilities.HideProjectFromApplication

            End If
        End Sub
        Protected Sub FormView1_ItemInserted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.FormViewInsertedEventArgs) Handles FormView1.ItemInserted
            If Not e.Exception Is Nothing Then
                Dim lblExceptionText As Label = Me.FormView1.FindControl("lblExceptionText")
                lblExceptionText.Visible = True
                lblExceptionText.Text = e.Exception.InnerException.Message
                e.ExceptionHandled = True
                e.KeepInInsertMode = True

            ElseIf Not Request.QueryString("ApplicationMode") Is Nothing Then
                Dim bll As New AccountBLL
                bll.PostInstalledAccountAdd()
                If System.Configuration.ConfigurationManager.AppSettings("AUTO_LOGIN_AFTER_ACCOUNT_ADD") <> "Yes" Then
                    If System.Configuration.ConfigurationManager.AppSettings("ApplicationMode") = "Installed" Then
                        Response.Redirect("RegistrationComplete.aspx?EMailAddress=" & CType(Me.FormView1.FindControl("EmployeeEMailAddress"), TextBox).Text, False)
                    Else
                        UIUtilities.RedirectToLoginPage()
                    End If
                Else
                    LoginIn()
                End If
            ElseIf Request.QueryString("Mode") Is Nothing Then
                If System.Configuration.ConfigurationManager.AppSettings("AUTO_LOGIN_AFTER_ACCOUNT_ADD") <> "Yes" Then
                    Response.Redirect("RegistrationComplete.aspx?EMailAddress=" & CType(Me.FormView1.FindControl("EmployeeEMailAddress"), TextBox).Text, False)
                Else
                    LoginIn()
                End If
            ElseIf Not Request.QueryString("Mode") Is Nothing Then
                Dim AccountId As Integer = CType(New TimeLiveDataSetTableAdapters.IdentityQueryTableAdapter().GetAccountLastId.Rows(0), TimeLiveDataSet.IdentityQueryRow).LastId

                'Dim LTCustomerBLL As New LTCustomerBLL
                'Dim drLTCustomer As TimeLiveDataSet.LTCustomerRow = LTCustomerBLL.GetLTCustomerByAccountId(AccountId)
                'Dim CustomerId As Integer = drLTCustomer.CustomerId

                EMailUtilities.DequeueEmail()

                Dim PaymentURL As String = LicensingBLL.GetPaymentURL(Me.Request, AccountId)
                Response.Redirect(PaymentURL, False)

            End If

        End Sub
        Protected Sub FormView1_ItemInserting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.FormViewInsertEventArgs) Handles FormView1.ItemInserting
            'Dim state As AjaxControlToolkit.NoBotState
            Dim NoBot As AjaxControlToolkit.NoBot = Me.FormView1.FindControl("NoBot2")
            If NoBot.IsValid() Then
                CType(Me.FormView1.FindControl("lblCaptcha"), Label).Visible = False
            Else
                e.Cancel = True
                CType(Me.FormView1.FindControl("lblCaptcha"), Label).Visible = True
                CType(Me.FormView1.FindControl("lblCaptcha"), Label).Text = "User appears to be a bot."
            End If
            'If System.Configuration.ConfigurationManager.AppSettings("ApplicationMode") = "Hosted" Then
            '    Dim Captcha As MSCaptcha.CaptchaControl = Me.FormView1.FindControl("ccCaptcha")
            '    Captcha.ValidateCaptcha(CType(Me.FormView1.FindControl("txtCaptcha"), TextBox).Text)
            '    If Not Captcha.UserValidated Then
            '        e.Cancel = True
            '        CType(Me.FormView1.FindControl("lblCaptcha"), Label).Visible = True
            '    Else
            '        CType(Me.FormView1.FindControl("lblCaptcha"), Label).Visible = False
            '    End If
            'Else
            '    'Dim Captcha As MSCaptcha.CaptchaControl = Me.FormView1.FindControl("ccCaptcha")
            '    'Captcha.Enabled = False
            'End If
            With dsAccountObject
                .InsertParameters("UserInterfaceLanguage").DefaultValue = CType(Me.FormView1.FindControl("ddlUserInterfaceLanguage"), DropDownList).SelectedValue
            End With
        End Sub
        Protected Sub FormView1_ItemUpdated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.FormViewUpdatedEventArgs) Handles FormView1.ItemUpdated
            System.Web.HttpContext.Current.Session.Remove("RootNode")
            UIUtilities.RedirectToAdminHomePage()
        End Sub
        Protected Sub dsTimeZone_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs)

        End Sub
        Protected Sub cmdActivateSerial_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim ActivationType As String = ""
            If CType(Me.FormView1.FindControl("rdOnlineActivation"), RadioButton).Checked = True Then
                If Me.CheckTextBoxValue(CType(Me.FormView1.FindControl("rdOnlineActivation"), RadioButton), CType(Me.FormView1.FindControl("txtLicenseKeys"), TextBox)) = True Then
                    CType(Me.FormView1.FindControl("lblLicenseError"), Label).Visible = True
                    Exit Sub
                End If
                ActivationType = "Online Activation"
            ElseIf CType(Me.FormView1.FindControl("rdManualActivation"), RadioButton).Checked = True Then
                If Me.CheckTextBoxValue(CType(Me.FormView1.FindControl("rdManualActivation"), RadioButton), CType(Me.FormView1.FindControl("MachineKeyTextBox"), TextBox)) = True Then
                    CType(Me.FormView1.FindControl("lblMachineKeyError"), Label).Visible = True
                    Exit Sub
                End If
                ActivationType = "Manual Activation"
            End If

            Dim LicensingBLL As New LicensingBLL
            If LicensingBLL.ActivateLincese(CType(Me.FormView1.FindControl("txtLicenseKeys"), TextBox).Text, ActivationType, CType(Me.FormView1.FindControl("rdOnlineActivation"), RadioButton).Checked, CType(Me.FormView1.FindControl("MachineKeyTextBox"), TextBox).Text, CType(Me.FormView1.FindControl("MachineNameTextBox"), TextBox).Text) = True Then
                Me.ShowLicenseActivationMessage(ResourceHelper.GetFromResource("License Activated Successfully."))
            Else
                Me.ShowLicenseActivationMessage("Unable To Activate License")
            End If

        End Sub
        Public Sub FormView1_ItemUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.FormViewUpdateEventArgs) Handles FormView1.ItemUpdating

            Dim AccountNameTextBox As New TextBox
            AccountNameTextBox = CType(Me.FormView1.FindControl("TabContainer1").FindControl("TabPanel9").FindControl("AccountName"), TextBox)
            e.NewValues("AccountName") = AccountNameTextBox.Text

            Dim EMailAddressTextBox As New TextBox
            EMailAddressTextBox = CType(Me.FormView1.FindControl("TabContainer1").FindControl("TabPanel9").FindControl("EMailAddressTextBox"), TextBox)
            e.NewValues("EMailAddress") = EMailAddressTextBox.Text

            Dim Address1TextBox As New TextBox
            Address1TextBox = CType(Me.FormView1.FindControl("TabContainer1").FindControl("TabPanel9").FindControl("Address1TextBox"), TextBox)
            e.NewValues("Address1") = Address1TextBox.Text

            Dim Address2TextBox As New TextBox
            Address2TextBox = CType(Me.FormView1.FindControl("TabContainer1").FindControl("TabPanel9").FindControl("Address2TextBox"), TextBox)
            e.NewValues("Address2") = Address2TextBox.Text

            Dim ZipCodeTextBox As New TextBox
            ZipCodeTextBox = CType(Me.FormView1.FindControl("TabContainer1").FindControl("TabPanel9").FindControl("ZipCodeTextBox"), TextBox)
            e.NewValues("ZipCode") = ZipCodeTextBox.Text

            Dim CityTextBox As New TextBox
            CityTextBox = CType(Me.FormView1.FindControl("TabContainer1").FindControl("TabPanel9").FindControl("CityTextBox"), TextBox)
            e.NewValues("City") = CityTextBox.Text

            Dim TelephoneTextBox As New TextBox
            TelephoneTextBox = CType(Me.FormView1.FindControl("TabContainer1").FindControl("TabPanel9").FindControl("TelephoneTextBox"), TextBox)
            e.NewValues("Telephone") = TelephoneTextBox.Text

            Dim FaxTextBox As New TextBox
            FaxTextBox = CType(Me.FormView1.FindControl("TabContainer1").FindControl("TabPanel9").FindControl("FaxTextBox"), TextBox)
            e.NewValues("Fax") = FaxTextBox.Text

            Dim ddlTimeZoneId As New DropDownList
            ddlTimeZoneId = CType(Me.FormView1.FindControl("TabContainer1").FindControl("TabPanel9").FindControl("ddlTimeZoneId"), DropDownList)
            Dim DropDownList3 As New DropDownList
            DropDownList3 = CType(Me.FormView1.FindControl("TabContainer1").FindControl("TabPanel9").FindControl("DropDownList3"), DropDownList)

            Dim txtDefaultTaskName As New TextBox
            txtDefaultTaskName = CType(Me.FormView1.FindControl("TabContainer1").FindControl("TabPanel3").FindControl("txtDefaultTaskName"), TextBox)
            e.NewValues("txtDefaultTaskName") = txtDefaultTaskName.Text

            e.NewValues("TimeZoneId") = ddlTimeZoneId.SelectedValue
            e.NewValues("CountryId") = DropDownList3.SelectedValue

            e.NewValues("ModifiedByEmployeeId") = DBUtilities.GetSessionAccountEmployeeId

        End Sub
        Protected Sub btnUpload_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim BLL As New AccountBLL
            BLL.FileUpload(txtCompanyLogo)
            BLL.UpdateIsCompanyOwnLogo(DBUtilities.GetSessionAccountId, chkIsShowCompanyOwnLogo.Checked)
            UIUtilities.RedirectToAdminHomePage()
        End Sub
        Public Function Validate() As Boolean
            Dim LDAP As New LDAPUtilitiesBLL
            Dim username As String = CType(Me.FormView1.FindControl("UsernameTextBox"), TextBox).Text
            Dim password As String = CType(Me.FormView1.FindControl("PasswordTextBox"), TextBox).Text

            If LDAP.IsValidUserNameAndPassword(username, password) = True Then
                Return True
            Else
                Return False
            End If
        End Function
        Public Sub ShowUsername()
            Dim LDAP As New LDAPUtilitiesBLL
            If Not LDAP.IsAspNetActiveDirectoryMembershipProvider = True Then
                If Me.FormView1.CurrentMode = FormViewMode.Insert Then
                    CType(Me.FormView1.FindControl("UsernameTextBox"), TextBox).ReadOnly = True
                End If
            End If
        End Sub
        Protected Sub UsernameTextBox_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
            Me.GetUserData()
        End Sub
        Public Function GetUserData() As Boolean
            Dim LDAP As New LDAPUtilitiesBLL

            If LDAP.IsAspNetActiveDirectoryMembershipProvider = True Then
                Dim Username As String = CType(Me.FormView1.FindControl("UsernameTextBox"), TextBox).Text
                Dim Admin As DirectoryEntry = LDAPUtilitiesBLL.GetUserByName(Username)
                If Not Admin Is Nothing Then
                    If Admin.Properties("givenname").Count > 0 AndAlso Not Admin.Properties("givenname").Item(0) Is Nothing Then
                        CType(Me.FormView1.FindControl("FirstNameTextBox"), TextBox).Text = Admin.Properties("givenname").Item(0)
                    End If
                    If Admin.Properties("sn").Count > 0 AndAlso Not Admin.Properties("sn").Item(0) Is Nothing Then
                        CType(Me.FormView1.FindControl("LastNameTextBox"), TextBox).Text = Admin.Properties("sn").Item(0)
                    End If
                    If Not Admin.Properties("mail").Count = 0 AndAlso Not Admin.Properties("mail").Item(0) Is Nothing Then
                        CType(Me.FormView1.FindControl("EmployeeEMailAddress"), TextBox).Text = Admin.Properties("mail").Item(0)
                    End If
                    Return True
                Else
                    Return False
                End If
            Else
                Return False
            End If

        End Function
        Public Function GetUserGroup() As Boolean
            Dim LDAP As New LDAPUtilitiesBLL

            If LDAP.IsAspNetActiveDirectoryMembershipProvider = True Then
                Dim Username As String = CType(Me.FormView1.FindControl("UsernameTextBox"), TextBox).Text
                Dim Admin As DirectoryEntry = LDAPUtilitiesBLL.GetUserByName(Username)
                If Not Admin Is Nothing Then
                    If LDAPUtilitiesBLL.IsUserTimeLiveAdministrator(Username) = True Or LDAPUtilitiesBLL.IsOpenLDAPMembershipProvider Then
                        Return True
                    Else
                        Return False
                    End If
                Else
                    Return False
                End If
            End If
        End Function
        Protected Sub CustomValidator2_ServerValidate1(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs)
            Dim LDAP As New LDAPUtilitiesBLL
            If LDAP.IsAspNetActiveDirectoryMembershipProvider = True Then
                args.IsValid = Me.GetUserGroup = True
                If LDAPUtilitiesBLL.IsOpenLDAPMembershipProvider Then
                    CType(Me.FormView1.FindControl("CustomValidator2"), CustomValidator).ErrorMessage = "Specified user not exist."
                End If
            End If
        End Sub
        Protected Sub CustomValidatorInsert_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs)
            Dim LDAP As New LDAPUtilitiesBLL

            If LDAP.IsAspNetActiveDirectoryMembershipProvider = True Then
                args.IsValid = Me.Validate = True
            End If
        End Sub
        Protected Sub EmployeeEMailAddress_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        End Sub
        Protected Sub btnChangePlanTo_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            If Me.FormView1.CurrentMode = FormViewMode.Edit Then
                LicensingBLL.ChangeHostedPlan(CType(Me.FormView1.FindControl("ddlPackage"), DropDownList).SelectedValue)
            End If
        End Sub
        Public Sub ForRenewal(ByVal drAccount As TimeLiveDataSet.AccountRow)
            If CType(Me.FormView1.FindControl("ddlPackage"), DropDownList).SelectedValue = 1 Then
                Dim bll As New AccountBLL
                bll.UpdateLicenseKey("TLHL", DBUtilities.GetSessionAccountId)
            ElseIf CType(Me.FormView1.FindControl("ddlPackage"), DropDownList).SelectedValue = 5 Then
                Response.Redirect("https://secure.avangate.com/renewal/?LICENSE=" & drAccount.LicenseId, False)
            ElseIf CType(Me.FormView1.FindControl("ddlPackage"), DropDownList).SelectedValue = 10 Then
                Response.Redirect("https://secure.avangate.com/renewal/?LICENSE=" & drAccount.LicenseId, False)
            ElseIf CType(Me.FormView1.FindControl("ddlPackage"), DropDownList).SelectedValue = 15 Then
                Response.Redirect("https://secure.avangate.com/renewal/?LICENSE=" & drAccount.LicenseId, False)
            End If
        End Sub
        Public Function GetPackage() As Integer
            Dim BLL As New AccountBLL
            Dim dr As TimeLiveDataSet.AccountRow = BLL.GetAccountByAccountId(DBUtilities.GetSessionAccountId)

            If IsDBNull(dr.Item("SystemPackageTypeId")) OrElse dr.Item("SystemPackageTypeId") = 1 Then
                Return 1
            ElseIf dr.Item("SystemPackageTypeId") = 5 Then
                Return 5
            ElseIf dr.Item("SystemPackageTypeId") = 10 Then
                Return 10
            ElseIf dr.Item("SystemPackageTypeId") = 15 Then
                Return 15
            End If

            Return Nothing

        End Function
        Public Function GetExpiryDateAsString(ByVal dtDate As String) As String

            Return LicensingBLL.GetStringFromEncryptedValue(dtDate)
        End Function
        'Protected Sub btnPayNow_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        '    Dim BLL As New AccountBLL
        '    Dim dr As TimeLiveDataSet.AccountRow = BLL.GetAccountByAccountId(DBUtilities.GetSessionAccountId)
        '    If IsDBNull(dr.Item("LicenseId")) Then
        '        If CType(Me.FormView1.FindControl("ddlPackage"), DropDownList).SelectedValue = 5 Then
        '            Response.Redirect("https://secure.avangate.com/order/checkout.php?PRODS=1331830&QTY=1&REF=" & DBUtilities.GetSessionAccountId)
        '        ElseIf CType(Me.FormView1.FindControl("ddlPackage"), DropDownList).SelectedValue = 10 Then
        '            Response.Redirect("https://secure.avangate.com/order/checkout.php?PRODS=1343185&QTY=1&REF=" & DBUtilities.GetSessionAccountId)
        '        ElseIf CType(Me.FormView1.FindControl("ddlPackage"), DropDownList).SelectedValue = 15 Then
        '            Response.Redirect("https://secure.avangate.com/order/checkout.php?PRODS=1343244&QTY=1&REF=" & DBUtilities.GetSessionAccountId)
        '        End If
        '    Else
        '        Response.Redirect("https://secure.avangate.com/renewal/LICENSE=" & dr.Item("LicenseId") & "&REF=" & DBUtilities.GetSessionAccountId)
        '    End If
        'End Sub
        Public Sub ShowLicenseActivationMessage(ByVal message As String)
            Dim strMessage As String = message
            Dim strScript As String = "alert('" & strMessage & "'); window.location = 'AccountPreferences.aspx';"
            If (Not Me.Page.ClientScript.IsStartupScriptRegistered("clientScript")) Then
                ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "clientScript", strScript, True)
            End If
        End Sub
        Protected Sub rdManualActivation_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
            If CType(Me.FormView1.FindControl("rdManualActivation"), RadioButton).Checked = True Then
                CType(Me.FormView1.FindControl("MachineKeyTextBox"), TextBox).ReadOnly = False
                CType(Me.FormView1.FindControl("txtLicenseKeys"), TextBox).ReadOnly = True
            End If
        End Sub
        Protected Sub rdOnlineActivation_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
            If CType(Me.FormView1.FindControl("rdOnlineActivation"), RadioButton).Checked = True Then
                CType(Me.FormView1.FindControl("MachineKeyTextBox"), TextBox).ReadOnly = True
                CType(Me.FormView1.FindControl("txtLicenseKeys"), TextBox).ReadOnly = False
            End If
        End Sub
        Public Function CheckTextBoxValue(ByVal checkbox As CheckBox, ByVal textbox As TextBox) As Boolean
            If checkbox.Checked = True And textbox.Text = "" Then
                Return True
            End If
        End Function
        Protected Sub btnUpdatePrintInfo_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            If cvExpenseSheetPrintFooterargs <> False Or txtExpenseSheetPrintFooter.Text = "" Then
                UpdatePrintInfo()
            End If
        End Sub
        Public Sub UpdatePrintInfo()
            Dim BLL As New AccountBLL
            BLL.btnUpdatePrintInfo(DBUtilities.GetSessionAccountId, chkShowTaskInExpenseSheet.Checked, txtExpenseSheetPrintFooter.Text, chkShowClientInExpenseSheet.Checked)
            UIUtilities.RedirectToAdminHomePage()
        End Sub
        Public Sub UpdateInvoiceInfo()
            Dim BLL As New AccountBLL
            Dim InvoiceBillingTypeId As Guid = New Guid(ddlInvoiceBillingTypeId.SelectedValue)
            BLL.btnUpdateInvoiceInfo(DBUtilities.GetSessionAccountId, InvoiceNoPrefixTextBox.Text, InvoiceBillingTypeId, chkShowBillingRateInInvoiceReport.Checked, txtInvoiceFooter.Text, chkShowProjectNameInInvoiceReport.Checked, chkShowEntryDateInInvoiceReport.Checked, chkShowEmployeeNameInInvoiceReport.Checked, chkShowWorkTypeInInvoiceDescription.Checked, chkRoundOffValueInInvoice.Checked, chkIsProjectTemplateMandatory.Checked)
            UIUtilities.RedirectToAdminHomePage()
        End Sub
        Public Sub UpdateProjectInfo()
            Dim BLL As New AccountBLL
            BLL.btnUpdateProjectInfo(DBUtilities.GetSessionAccountId, ProjectCodePrefixTextBox.Text, chkAutoGenerateProjectCode.Checked, chkShowClientDepartmentInProject.Checked, chkShowCompletedProjectInProjectGrid.Checked, chkIncludeCurrentYearInProjectCode.Checked, chkAutomaticallyIncludeAdministratorInProjectTeam.Checked, chkshowDisableProjectInReport.Checked)
            UIUtilities.RedirectToAdminHomePage()
        End Sub
        Public Sub UpdateTaskInfo()
            Dim BLL As New AccountBLL
            BLL.btnUpdateTaskInfo(DBUtilities.GetSessionAccountId, chkShowProjectNameInTask.Checked, chkShowClientNameInTask.Checked, ChkInsertDefaultTaskNameInProject.Checked, txtDefaultTaskName.Text, ddlSortTaskBy.SelectedValue)
            UIUtilities.RedirectToAdminHomePage()
        End Sub
        Public Sub UpdateGeneralPreference()
            Dim BLL As New AccountBLL
            Dim TPScheduledEmailSendTime As DateTime
            TPScheduledEmailSendTime = Now.ToShortDateString & " " & CType(Me.FormView1.FindControl("TabContainer1").FindControl("TabPanel10").FindControl("TPScheduledEmailSendTime"), TextBox).Text
            BLL.UpdateGeneralPreference(DBUtilities.GetSessionAccountId, chkEnablePasswordComplexity.Checked, chkLockSubmittedRecord.Checked, chkLockApprovedRecord.Checked, chkShowElectronicSign.Checked, txtPasswordExpiryPeriod.Text, TPScheduledEmailSendTime, SessionTimeOutTextBox.Text, ddlPageSize.SelectedValue, CultureInfoName.SelectedValue, CurrencySymbol.SelectedValue, chkShowAdditionalDepartmentInformationInEmployee.Checked, IIf(Not System.Configuration.ConfigurationManager.AppSettings("GAppsAuthentication") Is Nothing, txtDomainName.Text, ""), ChkShowEmployeeNameWithCode.Checked, chkGoogleAuthentication.Checked, ChkShowDisableEmployeesInReport.Checked, ddlClockStartEndBy.SelectedValue, ddlShowEmployeeNameBy.SelectedValue, ChkHideProjectFromApplication.Checked, False, "")
            Dim FromEmailAddressDisplayNameTextBox As New TextBox
            FromEmailAddressDisplayNameTextBox = CType(Me.FormView1.FindControl("TabContainer1").FindControl("TabPanel10").FindControl("FromEmailAddressDisplayNameTextBox"), TextBox)
            Dim FromEmailAddressTextBox As New TextBox
            FromEmailAddressTextBox = CType(Me.FormView1.FindControl("TabContainer1").FindControl("TabPanel10").FindControl("FromEmailAddressTextBox"), TextBox)
            BLL.UpdateEmailPreferences(DBUtilities.GetSessionAccountId, FromEmailAddressDisplayNameTextBox.Text, FromEmailAddressTextBox.Text)
            UIUtilities.RedirectToAdminHomePage()
        End Sub
        Public Sub UpdateTimeOff()
            Dim BLL As New AccountBLL
            BLL.btnUpdateTimeOff(DBUtilities.GetSessionAccountId, chkShowProjectForTimeOff.Checked, ddlTimeOffTypesBy.SelectedValue, chkIsTimeOffStatusEditMode.Checked, chkShowTimeOffInTimesheet.Checked, chkTimeoffHorsinDays.Checked)
            UIUtilities.RedirectToAdminHomePage()
        End Sub
        Public Sub UpdateOrganization()
            Dim BLL As New AccountBLL
            BLL.UpdateOrganization(DBUtilities.GetSessionAccountId, AccountName.Text, EMailAddressTextBox.Text, Address1TextBox.Text, Address2TextBox.Text, ZipCodeTextBox.Text, CityTextBox.Text, DropDownList3.SelectedValue, TelephoneTextBox.Text, FaxTextBox.Text, ddlTimeZoneId.SelectedValue)
            UIUtilities.RedirectToAdminHomePage()
        End Sub
        Public Sub UpdateTimesheetSetup()
            Dim BLL As New AccountBLL
            Dim TimeEntryHoursFormat As Guid
            Dim ShowClockStartEnd As Boolean
            If Not ddlTimeEntryHoursFormatId.SelectedValue = "None" Then
                TimeEntryHoursFormat = New Guid(ddlTimeEntryHoursFormatId.SelectedValue)
            Else
                TimeEntryHoursFormat = System.Guid.Empty
            End If
            If chkShowPercentageInTimesheet.Checked = True And ddlTimeEntryHoursFormatId.SelectedValue <> "074187eb-81d9-4e06-8e70-db7bc0c53784" Or ddlTimeEntryHoursFormatId.SelectedValue = "EE9CB3B1-E1A1-4346-B9FC-A3DA1C92A45E".ToLower Then
                ShowClockStartEnd = False
            Else
                ShowClockStartEnd = chkShowClockStartEnd.Checked
            End If
            'If cvTimesheetPrintFooterargs <> False Or txtTimesheetPrintFooter.Text = "" Then
            BLL.UpdateTimesheetSetup(DBUtilities.GetSessionAccountId, ShowClockStartEnd, chkShowClientInTimesheet.Checked, _
                                     chkShowDescriptionInWeekView.Checked, chkShowCompletedProjectsInTimeSheet.Checked, _
                                     chkShowCompletedTasksInTimeSheet.Checked, chkShowWorkTypeInTimeSheet.Checked, _
                                     chkShowCostCenterInTimeSheet.Checked, _
                                     chkShowAllInTimesheetReadOnly.Checked, chkShowPercentageInTimesheet.Checked, _
                                     txtNumberOfBlankRowsInTimeEntry.Text, _
                                     txtTimesheetOverduePeriods.Text, TimeEntryHoursFormat, ddlTimeEntryFormat.SelectedValue, _
                                     ddlTaskInformation.SelectedValue, ddlDefaultTimeEntryMode.SelectedValue, txtTimesheetPrintFooter.Text, _
                                     ddlTimesheetSort.SelectedValue, ddlCostCenterInTimesheetBy.SelectedValue, chkShowCopyActivitiesButtonInTimesheet.Checked, _
                                     chkShowCopyTimesheetButton.Checked, chkCalculateTaskPercentageAutomatically.Checked, ddlProjectInformation.SelectedValue, chkEnableOfflineTimesheet.Checked, ChkDefaultProjectTaskSelectionInTimesheet.Checked, chkAutoAdjustTimesheet.Checked, chkShowProjectInTimesheet.Checked)
            UIUtilities.RedirectToAdminHomePage()
            'End If
        End Sub
        Protected Sub cvTimesheetPrintFooter_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs)
            If txtTimesheetPrintFooter.Text.Length > 2000 Then
                args.IsValid = False
                cvTimesheetPrintFooterargs = False
            Else
                args.IsValid = True
                cvTimesheetPrintFooterargs = True
            End If
        End Sub
        Protected Sub cvExpenseSheetPrintFooter_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs)
            If txtExpenseSheetPrintFooter.Text.Length > 2000 Then
                args.IsValid = False
                cvExpenseSheetPrintFooterargs = False
            Else
                args.IsValid = True
                cvExpenseSheetPrintFooterargs = True
            End If
        End Sub
        Protected Sub btnRenew_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim BLL As New AccountBLL
            Dim dr As TimeLiveDataSet.AccountRow = BLL.GetAccountByAccountId(DBUtilities.GetSessionAccountId)
            If Not IsDBNull(dr.Item("LicenseId")) Then
                Response.Redirect("https://secure.avangate.com/renewal/?LICENSE=" & dr.Item("LicenseId"), False)
            End If
        End Sub
        Public Sub LoginIn()
            Dim Username As String = CType(Me.FormView1.FindControl("EmployeeEMailAddress"), TextBox).Text
            Dim Password As String = CType(Me.FormView1.FindControl("PasswordTextBox"), TextBox).Text
            Dim BLL As New AuthenticateBLL
            BLL.AuthenticateLogin(Username, Password)
            BLL.LoggedIn(Username, Password)
            If DBUtilities.IsTimeLiveMobileLogin Then
                Response.Redirect(UIUtilities.RedirectToMobileHomePage())
            Else
                Response.Redirect(UIUtilities.RedirectToHomePage())
            End If
        End Sub
        Protected Sub btnInvoice_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            UpdateInvoiceInfo()
        End Sub
        Protected Sub btnUpdateProjectInfo_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            Me.UpdateProjectInfo()
        End Sub
        Protected Sub btnUpdateTimesheetSetup_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            Me.UpdateTimesheetSetup()
        End Sub
        Protected Sub btnUpdateTimeOff_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            Me.UpdateTimeOff()
        End Sub
        Protected Sub btnUpdateTaskInfo_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            Me.UpdateTaskInfo()
        End Sub

        Protected Sub btnApplicationPreferences_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            'Me.UpdateGeneralPreference()
        End Sub

        Protected Sub btnOrganization_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            Me.UpdateOrganization()
        End Sub

        Protected Sub btnPreference_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            Me.UpdateGeneralPreference()
        End Sub

        Protected Sub btnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim BLL As New AccountBLL
            Me.UpdateOrganization()
            Me.UpdateGeneralPreference()
            Me.UpdateTimesheetSetup()
            Me.UpdateTimeOff()
            Me.UpdateTaskInfo()
            Me.UpdateProjectInfo()
            Me.UpdateInvoiceInfo()
            'If cvExpenseSheetPrintFooterargs <> False Or txtExpenseSheetPrintFooter.Text = "" Then
            UpdatePrintInfo()
            'End If
            BLL.FileUpload(txtCompanyLogo)
            BLL.UpdateIsCompanyOwnLogo(DBUtilities.GetSessionAccountId, chkIsShowCompanyOwnLogo.Checked)
        End Sub
        Protected Sub btnCancel_Click(sender As Object, e As System.EventArgs)
            Response.Redirect("~/AccountAdmin/AdminMain.aspx", False)
        End Sub
        Protected Sub btnSignup_ServerClick1(sender As Object, e As System.EventArgs) Handles btnSignup.ServerClick
            Dim BLL As New AccountBLL
            Try
                If UIUtilities.GetApplicationMode = "Installed" Then
                    If UIUtilities.IsAspNetActiveDirectoryMembershipProvider Then
                        BLL.AddNewAccount(2, CType(Me.FormView1.FindControl("txtCompanyName"), HtmlInputText).Value, "", "", "", "", 233, CType(Me.FormView1.FindControl("txtEmail"), HtmlInputText).Value, "", CType(Me.FormView1.FindControl("txtPhoneNo"), HtmlInputText).Value, "", 1, 8, CType(Me.FormView1.FindControl("txtEmail"), HtmlInputText).Value, CType(Me.FormView1.FindControl("txtPassword"), HtmlInputText).Value, _
                                          CType(Me.FormView1.FindControl("txtEmail"), HtmlInputText).Value, CType(Me.FormView1.FindControl("txtFirstName"), HtmlInputText).Value, CType(Me.FormView1.FindControl("txtLastName"), HtmlInputText).Value, "", "", "", False, False, Now.Date, Now.Date, "en-US")
                    Else
                        BLL.AddNewAccount(2, CType(Me.FormView1.FindControl("txtCompanyName"), HtmlInputText).Value, "", "", "", "", 233, CType(Me.FormView1.FindControl("txtEmail"), HtmlInputText).Value, "", CType(Me.FormView1.FindControl("txtPhoneNo"), HtmlInputText).Value, "", 1, 8, CType(Me.FormView1.FindControl("txtEmail"), HtmlInputText).Value, CType(Me.FormView1.FindControl("txtPassword"), HtmlInputText).Value, _
                                          CType(Me.FormView1.FindControl("txtEmail"), HtmlInputText).Value, CType(Me.FormView1.FindControl("txtFirstName"), HtmlInputText).Value, CType(Me.FormView1.FindControl("txtLastName"), HtmlInputText).Value, "", "", "", False, False, Now.Date, Now.Date, "en-US")
                    End If
                ElseIf UIUtilities.GetApplicationMode = "Hosted" Then
                    BLL.AddNewAccount(2, CType(Me.FormView1.FindControl("txtCompanyName"), HtmlInputText).Value, "", "", "", "", 233, CType(Me.FormView1.FindControl("txtEmail"), HtmlInputText).Value, "", CType(Me.FormView1.FindControl("txtPhoneNo"), HtmlInputText).Value, "", 1, 8, CType(Me.FormView1.FindControl("txtEmail"), HtmlInputText).Value, CType(Me.FormView1.FindControl("txtPassword"), HtmlInputText).Value, _
                      CType(Me.FormView1.FindControl("txtEmail"), HtmlInputText).Value, CType(Me.FormView1.FindControl("txtFirstName"), HtmlInputText).Value, CType(Me.FormView1.FindControl("txtLastName"), HtmlInputText).Value, "", "", "", False, False, Now.Date, Now.Date, "en-US")
                End If
            Catch ex As Exception
                Throw ex.InnerException
            End Try
        End Sub
    End Class
End Namespace
