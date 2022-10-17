
Partial Class Masters_MasterPageBase
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Me.Page.Request.Url.ToString.Contains("Default") Then
            Dim meta As New HtmlMeta
            meta.Name = "keywords"
            meta.Content = "Timelive, web based time tracking tool, online timesheet, web based timesheet,  " &
                           "On-Demand timesheet, time tracking, time tracking software, web based employee attendance, " &
                           "hosted, downloadable, " &
                           "asp, " &
                           "free, " &
                           "timesheet software,web based timesheet,billing and time tracking software,employee time tracking,employee time tracking software,employee timesheet,online timesheet,project time tracking,project time tracking software,time sheet tracking,time tracking program,timesheet,timesheet management,web based time sheet,web based time tracking,web based time tracking software,web timesheet"
            Page.Header.Controls.Add(meta)
        End If

        'If DBUtilities.IsProjectManagementFeature = True Then
        'If Me.Page.Request.Url.ToString.Contains("AccountProjects.aspx") Then
        'Me.AnchorProjectGanttView.Visible = True
        'Else
        'Me.AnchorProjectGanttView.Visible = False
        'End If
        'Else
        'Me.AnchorProjectGanttView.Visible = False
        'End If

        If AccountPagePermissionBLL.IsPageHasPermissionOf(80, 2) Then
            ShowTimeInOutAvailable()
        Else
            Anchortimein.Visible = False
            AnchortimeOut.Visible = False
        End If
        Me.SetImageUrl()
        Me.name.Text = Session("AccountEmployeeFullName")
        Me.nametop.Text = "Welcome, " & Session("AccountEmployeeFullName") & " (" & Session("Role") & ")"
        Me.nametop2.Text = "Welcome, " & Session("AccountEmployeeFullName") & " (" & Session("Role") & ")"
        Me.nametop3.Text = "Welcome, " & Session("AccountEmployeeFullName") & " (" & Session("Role") & ")"
        Me.RoleLabel.Text = Session("Role")
        EncodeNewMenuURL()
        SetFilterResult()


        Dim ApprovalCount As Integer
        Dim ExpenseCount As New AccountExpenseEntryBLL
        Dim TimeOffCount As New AccountEmployeeTimeOffRequestBLL
        Dim TimeEntryCount As New AccountEmployeeTimeEntryBLL
        ApprovalCount = ExpenseCount.GetApprovalCount(DBUtilities.GetSessionAccountEmployeeId) + TimeOffCount.GetTimeOffApprovalCount(DBUtilities.GetSessionAccountEmployeeId) + TimeEntryCount.GetTimesheetApprovalCount(DBUtilities.GetSessionAccountEmployeeId)
        If ApprovalCount = 0 Then
            Me.ApprovalMain.Attributes.Add("Class", "notify-approval")
            Me.ApprovalMainWithin.Attributes.Add("Class", "notify-approval")
        Else
            Me.ApprovalMain.Attributes.Add("Class", "notify-badge")
            Me.ApprovalMainWithin.Attributes.Add("Class", "notify-badge")
            Me.ApprovalMain.InnerText = ApprovalCount.ToString()
            Me.ApprovalMainWithin.InnerText = ApprovalCount.ToString()
        End If
        Dim Time As New AccountEmployeeTimeEntryBLL
        Dim Total = Time.GetMissingEntrysPeriods(DBUtilities.GetSessionAccountEmployeeId)

        If Total.Rows.Count >= 1 Then
            If Total.Rows(0)("Total") <= 0 Then
                Me.RejectedMain.Attributes.Add("Class", "notify-approval")
                Me.RejectedOnPage.Attributes.Add("Class", "notify-approval")
            Else
                Me.RejectedMain.Attributes.Add("Class", "notify-rejected")
                Me.RejectedOnPage.Attributes.Add("Class", "notify-rejected")
                Me.RejectedMain.InnerText = Total.Rows(0)("Total").ToString()
                Me.RejectedOnPage.InnerText = Total.Rows(0)("Total").ToString()
            End If
        Else
            Me.RejectedMain.Visible = False
            Me.RejectedOnPage.Visible = False
        End If
    End Sub

    Public Shared Function GetPage(ByVal objPage As Page) As String
        Dim ThisPage As String = objPage.AppRelativeVirtualPath
        Dim SlashPos As Integer = InStrRev(ThisPage, "/")
        Dim PageName As String = Right(ThisPage, Len(ThisPage) - SlashPos)
        Dim ThisFolder As String = objPage.AppRelativeTemplateSourceDirectory
        Dim SlashPos1 As String = Right(ThisFolder, Len(ThisFolder) - 2)
        Dim FolderName As String = Left(SlashPos1, Len(SlashPos1) - 1)
        Return PageName
    End Function
    Public Function IsLogoFileExist() As Boolean

        Dim strUploadPath As String = System.Configuration.ConfigurationManager.AppSettings("UploadFilesPath")

        Dim strRoot As String = System.Web.HttpContext.Current.Server.MapPath(strUploadPath)
        If Not System.IO.Directory.Exists(strRoot) Then
            Return False
        End If
        Dim strAccountPath As String = strRoot & DBUtilities.GetSessionAccountId & "\"
        If Not System.IO.Directory.Exists(strAccountPath) Then
            Return False
        End If
        Dim strLogoPath As String = strAccountPath & "Logo" & "\"
        If Not System.IO.Directory.Exists(strLogoPath) Then
            Return False
        End If
        Dim strFilePath As String = strLogoPath & "CompanyLogo.gif"
        If Not System.IO.File.Exists(strFilePath) Then
            Return False
        Else
            Return True
        End If
    End Function
    Public Sub SetImageUrl()
        Dim EmployeeBll As New AccountEmployeeBLL
        If LocaleUtilitiesBLL.IsShowEmployeeProfilePicture Then
            Me.I.ImageUrl = EmployeeBll.GetProfilePictureUrl
        End If
        If LocaleUtilitiesBLL.IsShowCompanyOwnLogo = True And IsLogoFileExist() = True Then
            HI.ImageUrl = ("~/Uploads/" & DBUtilities.GetSessionAccountId & "/Logo/CompanyLogo.gif")
        Else
            If System.Configuration.ConfigurationManager.AppSettings("BugTracking") = "Yes" Then
                HI.ImageUrl = "~/Images/TrakLiveLogo.png"
            Else
                HI.ImageUrl = "~/Images/TopHeader.png"
            End If
        End If
    End Sub
    ''' <summary>
    ''' Manage site menu home URL
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function EncodeSiteMenuTitle() As String
        Dim pbll As New AccountPagePermissionBLL
        If AccountPagePermissionBLL.IsPageHasPermissionOf(25, 1) = True Then
            Return "~/Employee/Default.aspx"
        Else
            'H1.Enabled = False
        End If
        Return ""
    End Function
    ''' <summary>
    ''' Return title
    ''' </summary>
    ''' <param name="PageTitle"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function EncodeMenuTitle(ByVal PageTitle As String) As String
        ''If System.Configuration.ConfigurationManager.AppSettings("DisableSchedule1") <> "Yes" Then
        If DBUtilities.HideProjectFromApplication = True Then
            If PageTitle = "Projects" Then
                PageTitle = "Tasks"
                Return ResourceHelper.GetFromResource(PageTitle)
            Else
                Return ResourceHelper.GetFromResource(PageTitle)
            End If
        Else
            Return ResourceHelper.GetFromResource(PageTitle)
        End If
    End Function
    ''' <summary>
    ''' return dayview and period view
    ''' </summary>
    ''' <param name="URL"></param>
    ''' <param name="PageTitle"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function EncodeMenuURL(ByVal URL As String, ByVal PageTitle As String) As String
        If PageTitle = "My Timesheet" Then
            If DBUtilities.GetDefaultTimeEntryMode = "Day View" Then
                Return "~/Employee/AccountEmployeeTimeEntryDayView.aspx"
            Else
                Return "~/Employee/AccountEmployeeTimeEntryPeriodView.aspx"
            End If
        End If
        Return URL
    End Function
    Public Function EncodeNewMenuURL() As String
        If DBUtilities.GetDefaultTimeEntryMode = "Day View" Then
            TimesheetLink.HRef = "../Employee/AccountEmployeeTimeEntryDayView.aspx"
            TimesheetLink1.HRef = "../Employee/AccountEmployeeTimeEntryDayView.aspx"
        Else
            TimesheetLink.HRef = "../Employee/AccountEmployeeTimeEntryPeriodView.aspx"
            TimesheetLink1.HRef = "../Employee/AccountEmployeeTimeEntryPeriodView.aspx"
        End If
        Return ""
    End Function
    Public Function IsMenuPage(Id As Integer) As Boolean
        If DBUtilities.IsBillingFeature = True Then
            If Id = 4 Or Id = 8 Or Id = 31 Or Id = 101 Or Id = 134 Then
                Return True
            End If
        Else
            If Id = 4 Or Id = 8 Or Id = 31 Or Id = 101 Then
                Return True
            End If
        End If
        Return False
    End Function
    Protected Sub Page_PreRender(sender As Object, e As System.EventArgs) Handles Me.PreRender
        Me.Page.Header.Controls.Add(New LiteralControl(String.Format("<meta http-equiv='refresh' content='{0};url={1}'>", (System.Web.HttpContext.Current.Session.Timeout * 60), UIUtilities.GetSessionExpiredURL(Me.Page))))
    End Sub
    Dim AttendanceBll As New AccountEmployeeAttendanceBLL
    Dim AttendanceDate As DateTime = LocaleUtilitiesBLL.GetCurrentDateTimeFromUserTimeZone
    Public Sub TimeInAttendance()
        Dim TimeIn As String = "In"
        If AttendanceBll.GetLastAttendanceByAttendanceDate(DBUtilities.GetSessionAccountId, DBUtilities.GetSessionAccountEmployeeId, AttendanceDate.Date, TimeIn) = "" Then
            AttendanceBll.AddAccountEmployeeAttendance(DBUtilities.GetSessionAccountId, DBUtilities.GetSessionAccountEmployeeId, AttendanceDate.Date, AttendanceDate, "In", Nothing, Now, DBUtilities.GetSessionAccountEmployeeId, Now, DBUtilities.GetSessionAccountEmployeeId)
            AttendanceValidationMessage("Attendance: Time in at ", AttendanceDate.ToString)
        ElseIf AttendanceBll.GetLastAttendanceByAttendanceDate(DBUtilities.GetSessionAccountId, DBUtilities.GetSessionAccountEmployeeId, AttendanceDate.Date, TimeIn) = "In" Then
            AttendanceValidationMessage("Attendance: Already time in at ", AttendanceDate.ToString)
        Else
            AttendanceBll.AddAccountEmployeeAttendance(DBUtilities.GetSessionAccountId, DBUtilities.GetSessionAccountEmployeeId, AttendanceDate.Date, AttendanceDate, "In", Nothing, Now, DBUtilities.GetSessionAccountEmployeeId, Now, DBUtilities.GetSessionAccountEmployeeId)
            AttendanceValidationMessage("Attendance: Time in at ", AttendanceDate.ToString)
        End If
    End Sub
    Public Sub TimeOutAttendance()
        Dim TimeOut As String = "Out"
        If AttendanceBll.GetLastAttendanceByAttendanceDate(DBUtilities.GetSessionAccountId, DBUtilities.GetSessionAccountEmployeeId, AttendanceDate.Date, TimeOut) = "" Then
            AttendanceValidationMessage("Attendance: No time in found for today ", ",Please time in first")
        ElseIf AttendanceBll.GetLastAttendanceByAttendanceDate(DBUtilities.GetSessionAccountId, DBUtilities.GetSessionAccountEmployeeId, AttendanceDate.Date, TimeOut) = "Out" Then
            AttendanceValidationMessage("Attendance: Already time out at ", AttendanceDate.ToString)
        Else
            AttendanceBll.AddAccountEmployeeAttendance(DBUtilities.GetSessionAccountId, DBUtilities.GetSessionAccountEmployeeId, AttendanceDate.Date, AttendanceDate, "Out", Nothing, Now, DBUtilities.GetSessionAccountEmployeeId, Now, DBUtilities.GetSessionAccountEmployeeId)
            AttendanceValidationMessage("Attendance: Time out at ", AttendanceDate.ToString)
        End If
    End Sub
    Protected Sub Anchortimein_ServerClick(sender As Object, e As System.EventArgs) Handles Anchortimein.ServerClick
        TimeInAttendance()
    End Sub
    Protected Sub AnchortimeOut_ServerClick(sender As Object, e As System.EventArgs) Handles AnchortimeOut.ServerClick
        TimeOutAttendance()
    End Sub
    Public Sub ShowTimeInOutAvailable()
        Dim EmployeeBll As New AccountEmployeeBLL
        If EmployeeBll.GetTimeInOutStatus() = True Then
            Anchortimein.Visible = True
            AnchortimeOut.Visible = True
        Else
            Anchortimein.Visible = False
            AnchortimeOut.Visible = False
        End If
    End Sub
    Public Sub AttendanceValidationMessage(strmsg As String, msg As String)
        Dim strMessage As String = strmsg
        Dim strScript As String = "alert('" & strMessage & " " & msg & "'); "
        If (Not Me.Page.ClientScript.IsStartupScriptRegistered("clientScript")) Then
            ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "clientScript", strScript, True)
        End If
    End Sub
    Public Sub SetFilterResult()
        HideFilterResult()
        'If System.Web.HttpContext.Current.Session("IsGridViewVisible") = 1 Then
        Dim filter As New AccountFilterModuleBLL
        Dim result As Hashtable = filter.GetFilterResult(Page)
        Dim n As Integer = 0
        If result.Count > 0 Then
            FilterResult.Visible = True
            For Each keys As String In result.Keys
                Dim lblcaption As Label = Me.FindControl("lblCaption" & n)
                lblcaption.Text = keys & ":"
                Dim lbltext As Label = Me.FindControl("lblText" & n)
                lbltext.Text = result(keys)
                Me.FindControl("tbl" & n).Visible = True
                n += 1
            Next
        End If
        'End If
    End Sub

    Protected Sub btnClearFilter_ServerClick(sender As Object, e As System.EventArgs) Handles btnClearFilter.ServerClick
        Dim filter As New AccountFilterModuleBLL
        filter.ResetFilters(Page, Page)
        System.Web.HttpContext.Current.Session.Add("ResetFilter", 1)
        Response.Redirect(Request.RawUrl, False)
    End Sub
    Public Sub HideFilterResult()
        FilterResult.Visible = False
        tbl0.Visible = False
        tbl1.Visible = False
        tbl2.Visible = False
        tbl3.Visible = False
        tbl4.Visible = False
        tbl5.Visible = False
        tbl6.Visible = False
        tbl7.Visible = False
        tbl8.Visible = False
        tbl9.Visible = False
        tbl10.Visible = False
        tbl11.Visible = False
        tbl12.Visible = False
        tbl13.Visible = False
        tbl14.Visible = False
        tbl15.Visible = False
        tbl16.Visible = False
        tbl17.Visible = False
        tbl18.Visible = False
        tbl19.Visible = False
        tbl20.Visible = False
        tbl21.Visible = False
        tbl22.Visible = False
        tbl23.Visible = False
        tbl24.Visible = False
        tbl25.Visible = False
    End Sub
    Public Function GetCurrentURL() As String
        Return UIUtilities.GetSitePrefixBySubDomain(DBUtilities.GetSessionAccountId)
    End Function
End Class

