
Partial Class Employee_AccountEmployeeTimeEntryWeekViewReadOnly
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If AuthenticateBLL.IsNewSession() Then
            AuthenticateBLL.DoLogout(Me.Page)
        End If
        If Me.Request.QueryString("IsPrint") = "True" Then
            CheckBox1.Checked = True
            Me.Page.Title = ResourceHelper.GetFromResource("TimeLive - Timesheet Print")
        End If
        Me.SetImageUrl()
        LocaleUtilitiesBLL.SetPageCultureSetting(Me.Page)
        Dim AccountEmployeeId As Integer = Me.Request.QueryString("AccountEmployeeId")
        Dim TimesheetPeriodType As String = Me.Request.QueryString("TimesheetPeriodType")
        Me.txtTimeEntryDate.SelectedDate = LocaleUtilitiesBLL.ConvertDateBaseToCurrentLocaleAsString(Request.QueryString("StartDate"))
        Me.CtlAccountEmployeeTimeEntryWeekViewReadOnly1.ShowDate(AccountEmployeeId, Me.txtTimeEntryDate.SelectedDate.Date, TimesheetPeriodType)
        Me.CtlAccountEmployeeTimeEntryWeekViewDescriptionReadOnly1.ShowDate(AccountEmployeeId, Me.txtTimeEntryDate.SelectedDate.Date, TimesheetPeriodType)
        Me.CtlAccountEmployeeTimeEntryWeekViewReadOnly1.SetGridViewDataSource(CheckBox1.Checked)
        Me.CtlAccountEmployeeTimeEntryWeekViewDescriptionReadOnly1.SetGridViewDataSource(CheckBox1.Checked)
        If Me.Request.QueryString("IsPrint") = "True" Then
            If Not IsPostBack Then
                Me.Page.ClientScript.RegisterStartupScript(Me.GetType, "Print", "javascript:window.print();", True)
            End If
        End If
    End Sub
    Public Sub SetImageUrl()
        If LocaleUtilitiesBLL.IsShowCompanyOwnLogo = True And LocaleUtilitiesBLL.IsLogoFileExistInSessionAccount = True Then
            imgCompanyLogo.ImageUrl = "~/Uploads/" & DBUtilities.GetSessionAccountId & "/Logo/CompanyLogo.gif"
        Else
            imgCompanyLogo.ImageUrl = "~/Images/TopHeader.png"
        End If
    End Sub

End Class
