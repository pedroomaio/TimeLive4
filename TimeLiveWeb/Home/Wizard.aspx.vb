
Partial Class Home_Wizard
    Inherits System.Web.UI.Page

    Protected Sub btnSave_ServerClick(sender As Object, e As System.EventArgs) Handles btnSave.ServerClick
        UpdateWizard()
        RedirectToHomePage()
        'dddd
    End Sub
    Public Sub UpdateWizard()
        Dim TimeEntryHoursFormatId As Guid
        If ddlTimeEntryHoursFormatId.Value = "None" Then
            TimeEntryHoursFormatId = Guid.Empty
        Else
            TimeEntryHoursFormatId = New Guid(ddlTimeEntryHoursFormatId.Value)
        End If
        Dim accountbll As New AccountBLL
        accountbll.UpdateWizardInformation(DBUtilities.GetSessionAccountId, IIf(ddlStandardAndFormats.Value = "Default", "auto", ddlStandardAndFormats.Value), _
                                           ddlTimeZone.Value, ddlUILanguage.Value, _
                                           ddlShowEmployeeNameBy.Value, txtBlankRowsTimesheet.Value, chkShowClockStartEnd.Checked, chkShowClientInTimesheet.Checked, _
                                           TimeEntryHoursFormatId, ddlCurrency.Value, txtSMTPServer.Value, txtSMTPUsername.Value, _
                                           txtSMTPPassword.Value, txtSMTPProtNumber.Value, chkUseSSL.Checked, New Guid(ddlTimesheetPeriodTypeId.Value))
    End Sub
    Public Sub RedirectToHomePage()
        Response.Redirect(UIUtilities.RedirectToHomePage())
    End Sub
    Protected Sub Page_Init(sender As Object, e As System.EventArgs) Handles Me.Init
        If Not Me.IsPostBack Then
            'Me.ddlStandardAndFormats.DataBind()

            ddlStandardAndFormats.DataSource = dsLocaleInfo
            ddlStandardAndFormats.DataValueField = "Name"
            ddlStandardAndFormats.DataTextField = "EnglishName"
            ddlStandardAndFormats.DataBind()
            Me.ddlStandardAndFormats.Items.Add("Default")
            Me.ddlStandardAndFormats.Value = "Default"
            txtBlankRowsTimesheet.Value = "2"

            ddlTimeEntryHoursFormatId.DataSource = dsSystemTimeEntryHoursFormat
            ddlTimeEntryHoursFormatId.DataValueField = "SystemTimeEntryHoursFormatId"
            ddlTimeEntryHoursFormatId.DataTextField = "SystemTimeEntryHoursFormat"
            ddlTimeEntryHoursFormatId.DataBind()
            Me.ddlTimeEntryHoursFormatId.Items.Add("None")
            ddlTimeEntryHoursFormatId.Value = "074187eb-81d9-4e06-8e70-db7bc0c53784"
            ddlTimesheetPeriodTypeId.DataSource = dsTimesheetPeriodTypeObject
            ddlTimesheetPeriodTypeId.DataValueField = "AccountTimesheetPeriodTypeId"
            ddlTimesheetPeriodTypeId.DataTextField = "SystemTimesheetPeriodType"
            ddlTimesheetPeriodTypeId.DataBind()
            Dim bll As New AccountWorkingDayTypeBLL
            Dim dtWorkingDay As AccountWorkingDayType.AccountWorkingDayTypeDataTable = bll.GetAccountWorkingDayTypeByAccountWorkingDayTypeId(DBUtilities.GetSessionAccountWorkingDayTypeId)
            Dim drWorkingDay As AccountWorkingDayType.AccountWorkingDayTypeRow
            If dtWorkingDay.Rows.Count > 0 Then
                drWorkingDay = dtWorkingDay.Rows(0)
                ddlTimesheetPeriodTypeId.Value = drWorkingDay.AccountTimesheetPeriodTypeId.ToString()
            End If
            ddlTimeZone.DataSource = dsTimeZone
            ddlTimeZone.DataValueField = "SystemTimeZoneId"
            ddlTimeZone.DataTextField = "TimeZoneName"
            ddlTimeZone.DataBind()
            ddlTimeZone.Value = "8"
        End If
    End Sub

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnSaveHosted_ServerClick(sender As Object, e As System.EventArgs) Handles btnSaveHosted.ServerClick
        UpdateWizard()
        RedirectToHomePage()
    End Sub
End Class
