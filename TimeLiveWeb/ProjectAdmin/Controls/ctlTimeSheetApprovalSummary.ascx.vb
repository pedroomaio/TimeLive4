
Partial Class ProjectAdmin_Controls_ctlTimeSheetApprovalSummary
    Inherits System.Web.UI.UserControl
    Dim TotalTime As Integer
    Dim BillableTime As Integer
    Dim NonBillableTime As Integer
    Dim Percentage As Double
    Dim Hours As Decimal = 0
    Dim NonBillableHours As Decimal = 0
    Dim BillableHours As Decimal = 0
    Dim DTotalTime As Decimal = 0
    Dim DBillableTime As Decimal = 0
    Dim DNonBillableTime As Decimal = 0

    Dim TotalTime1 As Integer
    Dim BillableTime1 As Integer
    Dim NonBillableTime1 As Integer
    Dim Percentage1 As Double
    Dim Hours1 As Decimal = 0
    Dim NonBillableHours1 As Decimal = 0
    Dim BillableHours1 As Decimal = 0
    Dim DTotalTime1 As Decimal = 0
    Dim DBillableTime1 As Decimal = 0
    Dim DNonBillableTime1 As Decimal = 0

    Dim TotalTime2 As Integer
    Dim BillableTime2 As Integer
    Dim NonBillableTime2 As Integer
    Dim Percentage2 As Double
    Dim Hours2 As Decimal = 0
    Dim NonBillableHours2 As Decimal = 0
    Dim BillableHours2 As Decimal = 0
    Dim DTotalTime2 As Decimal = 0
    Dim DBillableTime2 As Decimal = 0
    Dim DNonBillableTime2 As Decimal = 0

    Dim TotalTime3 As Integer
    Dim BillableTime3 As Integer
    Dim NonBillableTime3 As Integer
    Dim Percentage3 As Double
    Dim Hours3 As Decimal = 0
    Dim NonBillableHours3 As Decimal = 0
    Dim BillableHours3 As Decimal = 0
    Dim DTotalTime3 As Decimal = 0
    Dim DBillableTime3 As Decimal = 0
    Dim DNonBillableTime3 As Decimal = 0

    Dim TotalTime4 As Integer
    Dim BillableTime4 As Integer
    Dim NonBillableTime4 As Integer
    Dim Percentage4 As Double
    Dim Hours4 As Decimal = 0
    Dim NonBillableHours4 As Decimal = 0
    Dim BillableHours4 As Decimal = 0
    Dim DTotalTime4 As Decimal = 0
    Dim DBillableTime4 As Decimal = 0
    Dim DNonBillableTime4 As Decimal = 0

    Dim TotalTime5 As Integer
    Dim TotalTime6 As Integer
    Public Sub ShowDataForTimeSheetApprovalSummary(ByVal AccountEmployeeId As Integer, ByVal TimeEntryStartDate As DateTime, ByVal TimeEntryEndDate As DateTime, ByVal IncludeDateRange As Boolean)
        Me.dsApprovalEntriesForTeamLeadObject.SelectParameters("TimeEntryAccountEmployeeId").DefaultValue = AccountEmployeeId
        Me.dsApprovalEntriesForTeamLeadObject.SelectParameters("TimeEntryStartDate").DefaultValue = TimeEntryStartDate
        Me.dsApprovalEntriesForTeamLeadObject.SelectParameters("TimeEntryEndDate").DefaultValue = TimeEntryEndDate
        Me.dsApprovalEntriesForTeamLeadObject.SelectParameters("IncludeDateRange").DefaultValue = IncludeDateRange

        Me.ApprovalEntriesForProjectManagerObject.SelectParameters("TimeEntryAccountEmployeeId").DefaultValue = AccountEmployeeId
        Me.ApprovalEntriesForProjectManagerObject.SelectParameters("TimeEntryStartDate").DefaultValue = TimeEntryStartDate
        Me.ApprovalEntriesForProjectManagerObject.SelectParameters("TimeEntryEndDate").DefaultValue = TimeEntryEndDate
        Me.ApprovalEntriesForProjectManagerObject.SelectParameters("IncludeDateRange").DefaultValue = IncludeDateRange

        Me.ApprovalEntriesForSpecificEmployeeObject.SelectParameters("TimeEntryAccountEmployeeId").DefaultValue = AccountEmployeeId
        Me.ApprovalEntriesForSpecificEmployeeObject.SelectParameters("TimeEntryStartDate").DefaultValue = TimeEntryStartDate
        Me.ApprovalEntriesForSpecificEmployeeObject.SelectParameters("TimeEntryEndDate").DefaultValue = TimeEntryEndDate
        Me.ApprovalEntriesForSpecificEmployeeObject.SelectParameters("IncludeDateRange").DefaultValue = IncludeDateRange

        Me.dsApprovalEntriesForSpecificExternalUserObject.SelectParameters("TimeEntryAccountEmployeeId").DefaultValue = AccountEmployeeId
        Me.dsApprovalEntriesForSpecificExternalUserObject.SelectParameters("TimeEntryStartDate").DefaultValue = TimeEntryStartDate
        Me.dsApprovalEntriesForSpecificExternalUserObject.SelectParameters("TimeEntryEndDate").DefaultValue = TimeEntryEndDate
        Me.dsApprovalEntriesForSpecificExternalUserObject.SelectParameters("IncludeDateRange").DefaultValue = IncludeDateRange

        Me.dsApprovalEntriesForEmployeeManagerObject.SelectParameters("TimeEntryAccountEmployeeId").DefaultValue = AccountEmployeeId
        Me.dsApprovalEntriesForEmployeeManagerObject.SelectParameters("TimeEntryStartDate").DefaultValue = TimeEntryStartDate
        Me.dsApprovalEntriesForEmployeeManagerObject.SelectParameters("TimeEntryEndDate").DefaultValue = TimeEntryEndDate
        Me.dsApprovalEntriesForEmployeeManagerObject.SelectParameters("IncludeDateRange").DefaultValue = IncludeDateRange

        Me.dsApprovalEntriesForSpecificEmployeeForTimeOffObject.SelectParameters("TimeEntryAccountEmployeeId").DefaultValue = AccountEmployeeId
        Me.dsApprovalEntriesForSpecificEmployeeForTimeOffObject.SelectParameters("TimeEntryStartDate").DefaultValue = TimeEntryStartDate
        Me.dsApprovalEntriesForSpecificEmployeeForTimeOffObject.SelectParameters("TimeEntryEndDate").DefaultValue = TimeEntryEndDate
        Me.dsApprovalEntriesForSpecificEmployeeForTimeOffObject.SelectParameters("IncludeDateRange").DefaultValue = IncludeDateRange

        Me.dsApprovalEntriesForProjectManagerForTimeOffObject.SelectParameters("TimeEntryAccountEmployeeId").DefaultValue = AccountEmployeeId
        Me.dsApprovalEntriesForProjectManagerForTimeOffObject.SelectParameters("TimeEntryStartDate").DefaultValue = TimeEntryStartDate
        Me.dsApprovalEntriesForProjectManagerForTimeOffObject.SelectParameters("TimeEntryEndDate").DefaultValue = TimeEntryEndDate
        Me.dsApprovalEntriesForProjectManagerForTimeOffObject.SelectParameters("IncludeDateRange").DefaultValue = IncludeDateRange

        Me.GridView1.DataBind()
        Me.GridView2.DataBind()
        Me.GridView3.DataBind()
        Me.GridView4.DataBind()
        Me.GridView5.DataBind()
        Me.GridView6.DataBind()
        Me.GridView7.DataBind()
    End Sub
    Dim HArray() As String
    Dim BillableHArray As String
    Dim NonBillableHArray As String
    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            If DBUtilities.IsTimeEntryHoursFormat <> "Decimal" Then
                CType(e.Row.Cells(0).FindControl("lnkEmployeeName"), HyperLink).NavigateUrl = "~/Employee/AccountEmployeeTimeEntryWeekViewReadOnly.aspx?Type=TeamLead&AccountEmployeeId=" & DataBinder.Eval(e.Row.DataItem, "TimeEntryAccountEmployeeId") & "&StartDate=" & LocaleUtilitiesBLL.ConvertDateToDateBaseCulture(DataBinder.Eval(e.Row.DataItem, "TimeEntryStartDate")) & "&TimesheetPeriodType=" & DataBinder.Eval(e.Row.DataItem, "TimeEntryViewType")
                CType(e.Row.Cells(3).FindControl("lblTotalTime"), Label).Text = DBUtilities.GetDateTimeOfMinutesAsString(DataBinder.Eval(e.Row.DataItem, "TotalMinutes"))
                TotalTime += DataBinder.Eval(e.Row.DataItem, "TotalMinutes")
                CType(e.Row.Cells(4).FindControl("lblBillableTime"), Label).Text = DBUtilities.GetDateTimeOfMinutesAsString(DataBinder.Eval(e.Row.DataItem, "BillableTotalMinutes"))
                BillableTime += DataBinder.Eval(e.Row.DataItem, "BillableTotalMinutes")
                CType(e.Row.Cells(5).FindControl("lblNonBillableTime"), Label).Text = DBUtilities.GetDateTimeOfMinutesAsString(DataBinder.Eval(e.Row.DataItem, "NonBillableTotalMinutes"))
                NonBillableTime += DataBinder.Eval(e.Row.DataItem, "NonBillableTotalMinutes")
                If Not IsDBNull(DataBinder.Eval(e.Row.DataItem, "Percentage")) Then
                    CType(e.Row.Cells(5).FindControl("lblPercentage"), Label).Text = DataBinder.Eval(e.Row.DataItem, "Percentage") & "%"
                    Percentage += DataBinder.Eval(e.Row.DataItem, "Percentage")
                End If
            Else
                CType(e.Row.Cells(0).FindControl("lnkEmployeeName"), HyperLink).NavigateUrl = "~/Employee/AccountEmployeeTimeEntryWeekViewReadOnly.aspx?Type=TeamLead&AccountEmployeeId=" & DataBinder.Eval(e.Row.DataItem, "TimeEntryAccountEmployeeId") & "&StartDate=" & LocaleUtilitiesBLL.ConvertDateToDateBaseCulture(DataBinder.Eval(e.Row.DataItem, "TimeEntryStartDate")) & "&TimesheetPeriodType=" & DataBinder.Eval(e.Row.DataItem, "TimeEntryViewType")
                Dim TotalMinute As String = DBUtilities.GetDateTimeOfMinutesAsString(DataBinder.Eval(e.Row.DataItem, "TotalMinutes"))
                HArray = Split(TotalMinute, ":")
                Hours = LocaleUtilitiesBLL.ConvertTimeIntoHoursDecimalFormat(HArray(0), HArray(1))
                CType(e.Row.Cells(3).FindControl("lblTotalTime"), Label).Text = Hours
                'LocaleUtilitiesBLL.ConvertTimeIntoHoursDecimalFormat()
                DTotalTime += Hours

                Dim BillableHArray = Split(DBUtilities.GetDateTimeOfMinutesAsString(DataBinder.Eval(e.Row.DataItem, "BillableTotalMinutes")), ":")
                'BillableHArray = Split(BillableMinutes, ":")
                BillableHours = LocaleUtilitiesBLL.ConvertTimeIntoHoursDecimalFormat(BillableHArray(0), BillableHArray(1))
                CType(e.Row.Cells(4).FindControl("lblBillableTime"), Label).Text = BillableHours
                DBillableTime += BillableHours

                Dim NonBillableHArray = Split(DBUtilities.GetDateTimeOfMinutesAsString(DataBinder.Eval(e.Row.DataItem, "NonBillableTotalMinutes")), ":")
                'NonBillableHArray = Split(NonBillableMinutes, ":")
                NonBillableHours = LocaleUtilitiesBLL.ConvertTimeIntoHoursDecimalFormat(NonBillableHArray(0), NonBillableHArray(1))
                CType(e.Row.Cells(5).FindControl("lblNonBillableTime"), Label).Text = NonBillableHours
                DNonBillableTime += NonBillableHours

                If Not IsDBNull(DataBinder.Eval(e.Row.DataItem, "Percentage")) Then
                    CType(e.Row.Cells(5).FindControl("lblPercentage"), Label).Text = DataBinder.Eval(e.Row.DataItem, "Percentage") & "%"
                    Percentage += DataBinder.Eval(e.Row.DataItem, "Percentage")
                End If
            End If
        End If
        If e.Row.RowType = DataControlRowType.Footer Then
            If DBUtilities.IsTimeEntryHoursFormat <> "Decimal" Then
                CType(e.Row.Cells(3).FindControl("lblSumTotalTime"), Label).Text = DBUtilities.GetDateTimeOfMinutesAsString(TotalTime)
                CType(e.Row.Cells(5).FindControl("lblSumPercentage"), Label).Text = Percentage & "%"
                CType(e.Row.Cells(4).FindControl("lblSumBillableTime"), Label).Text = DBUtilities.GetDateTimeOfMinutesAsString(BillableTime)
                CType(e.Row.Cells(5).FindControl("lblSumNonBillableTime"), Label).Text = DBUtilities.GetDateTimeOfMinutesAsString(NonBillableTime)
            Else
                CType(e.Row.Cells(3).FindControl("lblSumTotalTime"), Label).Text = DTotalTime
                CType(e.Row.Cells(5).FindControl("lblSumPercentage"), Label).Text = Percentage & "%"
                CType(e.Row.Cells(4).FindControl("lblSumBillableTime"), Label).Text = DBillableTime
                CType(e.Row.Cells(5).FindControl("lblSumNonBillableTime"), Label).Text = DNonBillableTime
            End If
        End If
    End Sub
    Dim HArray1() As String
    Dim BillableHArray1 As String
    Dim NonBillableHArray1 As String
    Protected Sub GridView2_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then
            If DBUtilities.IsTimeEntryHoursFormat <> "Decimal" Then
                CType(e.Row.Cells(0).FindControl("lnkEmployeeName"), HyperLink).NavigateUrl = "~/Employee/AccountEmployeeTimeEntryWeekViewReadOnly.aspx?Type=ProjectManager&AccountEmployeeId=" & DataBinder.Eval(e.Row.DataItem, "TimeEntryAccountEmployeeId") & "&StartDate=" & LocaleUtilitiesBLL.ConvertDateToDateBaseCulture(DataBinder.Eval(e.Row.DataItem, "TimeEntryStartDate")) & "&TimesheetPeriodType=" & DataBinder.Eval(e.Row.DataItem, "TimeEntryViewType")
                CType(e.Row.Cells(3).FindControl("lblTotalTime"), Label).Text = DBUtilities.GetDateTimeOfMinutesAsString(DataBinder.Eval(e.Row.DataItem, "TotalMinutes"))
                TotalTime1 += DataBinder.Eval(e.Row.DataItem, "TotalMinutes")
                CType(e.Row.Cells(4).FindControl("lblBillableTime"), Label).Text = DBUtilities.GetDateTimeOfMinutesAsString(DataBinder.Eval(e.Row.DataItem, "BillableTotalMinutes"))
                BillableTime1 += DataBinder.Eval(e.Row.DataItem, "BillableTotalMinutes")
                CType(e.Row.Cells(5).FindControl("lblNonBillableTime"), Label).Text = DBUtilities.GetDateTimeOfMinutesAsString(DataBinder.Eval(e.Row.DataItem, "NonBillableTotalMinutes"))
                NonBillableTime1 += DataBinder.Eval(e.Row.DataItem, "NonBillableTotalMinutes")
                If Not IsDBNull(DataBinder.Eval(e.Row.DataItem, "Percentage")) Then
                    CType(e.Row.Cells(5).FindControl("lblPercentage"), Label).Text = DataBinder.Eval(e.Row.DataItem, "Percentage") & "%"
                    Percentage1 += DataBinder.Eval(e.Row.DataItem, "Percentage")
                End If
            Else
                CType(e.Row.Cells(0).FindControl("lnkEmployeeName"), HyperLink).NavigateUrl = "~/Employee/AccountEmployeeTimeEntryWeekViewReadOnly.aspx?Type=ProjectManager&AccountEmployeeId=" & DataBinder.Eval(e.Row.DataItem, "TimeEntryAccountEmployeeId") & "&StartDate=" & LocaleUtilitiesBLL.ConvertDateToDateBaseCulture(DataBinder.Eval(e.Row.DataItem, "TimeEntryStartDate")) & "&TimesheetPeriodType=" & DataBinder.Eval(e.Row.DataItem, "TimeEntryViewType")
                Dim TotalMinute As String = DBUtilities.GetDateTimeOfMinutesAsString(DataBinder.Eval(e.Row.DataItem, "TotalMinutes"))
                HArray1 = Split(TotalMinute, ":")
                Hours1 = LocaleUtilitiesBLL.ConvertTimeIntoHoursDecimalFormat(HArray1(0), HArray1(1))
                CType(e.Row.Cells(3).FindControl("lblTotalTime"), Label).Text = Hours1
                'LocaleUtilitiesBLL.ConvertTimeIntoHoursDecimalFormat()
                DTotalTime1 += Hours1

                Dim BillableHArray1 = Split(DBUtilities.GetDateTimeOfMinutesAsString(DataBinder.Eval(e.Row.DataItem, "BillableTotalMinutes")), ":")
                'BillableHArray = Split(BillableMinutes, ":")
                BillableHours1 = LocaleUtilitiesBLL.ConvertTimeIntoHoursDecimalFormat(BillableHArray1(0), BillableHArray1(1))
                CType(e.Row.Cells(4).FindControl("lblBillableTime"), Label).Text = BillableHours1
                DBillableTime1 += BillableHours1

                Dim NonBillableHArray1 = Split(DBUtilities.GetDateTimeOfMinutesAsString(DataBinder.Eval(e.Row.DataItem, "NonBillableTotalMinutes")), ":")
                'NonBillableHArray = Split(NonBillableMinutes, ":")
                NonBillableHours1 = LocaleUtilitiesBLL.ConvertTimeIntoHoursDecimalFormat(NonBillableHArray1(0), NonBillableHArray1(1))
                CType(e.Row.Cells(5).FindControl("lblNonBillableTime"), Label).Text = NonBillableHours1
                DNonBillableTime1 += NonBillableHours1

                If Not IsDBNull(DataBinder.Eval(e.Row.DataItem, "Percentage")) Then
                    CType(e.Row.Cells(5).FindControl("lblPercentage"), Label).Text = DataBinder.Eval(e.Row.DataItem, "Percentage") & "%"
                    Percentage1 += DataBinder.Eval(e.Row.DataItem, "Percentage")
                End If
            End If
        End If
        If e.Row.RowType = DataControlRowType.Footer Then
            If DBUtilities.IsTimeEntryHoursFormat <> "Decimal" Then
                CType(e.Row.Cells(3).FindControl("lblSumTotalTime"), Label).Text = DBUtilities.GetDateTimeOfMinutesAsString(TotalTime1)
                CType(e.Row.Cells(5).FindControl("lblSumPercentage"), Label).Text = Percentage1 & "%"
                CType(e.Row.Cells(4).FindControl("lblSumBillableTime"), Label).Text = DBUtilities.GetDateTimeOfMinutesAsString(BillableTime1)
                CType(e.Row.Cells(5).FindControl("lblSumNonBillableTime"), Label).Text = DBUtilities.GetDateTimeOfMinutesAsString(NonBillableTime1)
            Else
                CType(e.Row.Cells(3).FindControl("lblSumTotalTime"), Label).Text = DTotalTime1
                CType(e.Row.Cells(5).FindControl("lblSumPercentage"), Label).Text = Percentage1 & "%"
                CType(e.Row.Cells(4).FindControl("lblSumBillableTime"), Label).Text = DBillableTime1
                CType(e.Row.Cells(5).FindControl("lblSumNonBillableTime"), Label).Text = DNonBillableTime1
            End If
        End If
    End Sub
    Dim HArray2() As String
    Dim BillableHArray2 As String
    Dim NonBillableHArray2 As String
    Protected Sub GridView3_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then
            If DBUtilities.IsTimeEntryHoursFormat <> "Decimal" Then
                CType(e.Row.Cells(0).FindControl("lnkEmployeeName"), HyperLink).NavigateUrl = "~/Employee/AccountEmployeeTimeEntryWeekViewReadOnly.aspx?Type=SpecificEmployee&AccountEmployeeId=" & DataBinder.Eval(e.Row.DataItem, "TimeEntryAccountEmployeeId") & "&StartDate=" & LocaleUtilitiesBLL.ConvertDateToDateBaseCulture(DataBinder.Eval(e.Row.DataItem, "TimeEntryStartDate")) & "&TimesheetPeriodType=" & DataBinder.Eval(e.Row.DataItem, "TimeEntryViewType")
                CType(e.Row.Cells(3).FindControl("lblTotalTime"), Label).Text = DBUtilities.GetDateTimeOfMinutesAsString(DataBinder.Eval(e.Row.DataItem, "TotalMinutes"))
                TotalTime2 += DataBinder.Eval(e.Row.DataItem, "TotalMinutes")
                CType(e.Row.Cells(4).FindControl("lblBillableTime"), Label).Text = DBUtilities.GetDateTimeOfMinutesAsString(DataBinder.Eval(e.Row.DataItem, "BillableTotalMinutes"))
                BillableTime2 += DataBinder.Eval(e.Row.DataItem, "BillableTotalMinutes")
                CType(e.Row.Cells(5).FindControl("lblNonBillableTime"), Label).Text = DBUtilities.GetDateTimeOfMinutesAsString(DataBinder.Eval(e.Row.DataItem, "NonBillableTotalMinutes"))
                NonBillableTime2 += DataBinder.Eval(e.Row.DataItem, "NonBillableTotalMinutes")
                If Not IsDBNull(DataBinder.Eval(e.Row.DataItem, "Percentage")) Then
                    CType(e.Row.Cells(5).FindControl("lblPercentage"), Label).Text = DataBinder.Eval(e.Row.DataItem, "Percentage") & "%"
                    Percentage2 += DataBinder.Eval(e.Row.DataItem, "Percentage")
                End If
            Else
                CType(e.Row.Cells(0).FindControl("lnkEmployeeName"), HyperLink).NavigateUrl = "~/Employee/AccountEmployeeTimeEntryWeekViewReadOnly.aspx?Type=SpecificEmployee&AccountEmployeeId=" & DataBinder.Eval(e.Row.DataItem, "TimeEntryAccountEmployeeId") & "&StartDate=" & LocaleUtilitiesBLL.ConvertDateToDateBaseCulture(DataBinder.Eval(e.Row.DataItem, "TimeEntryStartDate")) & "&TimesheetPeriodType=" & DataBinder.Eval(e.Row.DataItem, "TimeEntryViewType")
                Dim TotalMinute As String = DBUtilities.GetDateTimeOfMinutesAsString(DataBinder.Eval(e.Row.DataItem, "TotalMinutes"))
                HArray2 = Split(TotalMinute, ":")
                Hours2 = LocaleUtilitiesBLL.ConvertTimeIntoHoursDecimalFormat(HArray2(0), HArray2(1))
                CType(e.Row.Cells(3).FindControl("lblTotalTime"), Label).Text = Hours2
                'LocaleUtilitiesBLL.ConvertTimeIntoHoursDecimalFormat()
                DTotalTime2 += Hours2

                Dim BillableHArray2 = Split(DBUtilities.GetDateTimeOfMinutesAsString(DataBinder.Eval(e.Row.DataItem, "BillableTotalMinutes")), ":")
                'BillableHArray = Split(BillableMinutes, ":")
                BillableHours2 = LocaleUtilitiesBLL.ConvertTimeIntoHoursDecimalFormat(BillableHArray2(0), BillableHArray2(1))
                CType(e.Row.Cells(4).FindControl("lblBillableTime"), Label).Text = BillableHours2
                DBillableTime2 += BillableHours2

                Dim NonBillableHArray2 = Split(DBUtilities.GetDateTimeOfMinutesAsString(DataBinder.Eval(e.Row.DataItem, "NonBillableTotalMinutes")), ":")
                'NonBillableHArray = Split(NonBillableMinutes, ":")
                NonBillableHours2 = LocaleUtilitiesBLL.ConvertTimeIntoHoursDecimalFormat(NonBillableHArray2(0), NonBillableHArray2(1))
                CType(e.Row.Cells(5).FindControl("lblNonBillableTime"), Label).Text = NonBillableHours2
                DNonBillableTime2 += NonBillableHours2

                If Not IsDBNull(DataBinder.Eval(e.Row.DataItem, "Percentage")) Then
                    CType(e.Row.Cells(5).FindControl("lblPercentage"), Label).Text = DataBinder.Eval(e.Row.DataItem, "Percentage") & "%"
                    Percentage2 += DataBinder.Eval(e.Row.DataItem, "Percentage")
                End If
            End If
        End If
        If e.Row.RowType = DataControlRowType.Footer Then
            If DBUtilities.IsTimeEntryHoursFormat <> "Decimal" Then
                CType(e.Row.Cells(3).FindControl("lblSumTotalTime"), Label).Text = DBUtilities.GetDateTimeOfMinutesAsString(TotalTime2)
                CType(e.Row.Cells(5).FindControl("lblSumPercentage"), Label).Text = Percentage2 & "%"
                CType(e.Row.Cells(4).FindControl("lblSumBillableTime"), Label).Text = DBUtilities.GetDateTimeOfMinutesAsString(BillableTime2)
                CType(e.Row.Cells(5).FindControl("lblSumNonBillableTime"), Label).Text = DBUtilities.GetDateTimeOfMinutesAsString(NonBillableTime2)
            Else
                CType(e.Row.Cells(3).FindControl("lblSumTotalTime"), Label).Text = DTotalTime2
                CType(e.Row.Cells(5).FindControl("lblSumPercentage"), Label).Text = Percentage2 & "%"
                CType(e.Row.Cells(4).FindControl("lblSumBillableTime"), Label).Text = DBillableTime2
                CType(e.Row.Cells(5).FindControl("lblSumNonBillableTime"), Label).Text = DNonBillableTime2
            End If
        End If
    End Sub
    Dim HArray3() As String
    Dim BillableHArray3 As String
    Dim NonBillableHArray3 As String
    Protected Sub GridView4_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then
            If DBUtilities.IsTimeEntryHoursFormat <> "Decimal" Then
                CType(e.Row.Cells(0).FindControl("lnkEmployeeName"), HyperLink).NavigateUrl = "~/Employee/AccountEmployeeTimeEntryWeekViewReadOnly.aspx?Type=SpecificExternalUser&AccountEmployeeId=" & DataBinder.Eval(e.Row.DataItem, "TimeEntryAccountEmployeeId") & "&StartDate=" & LocaleUtilitiesBLL.ConvertDateToDateBaseCulture(DataBinder.Eval(e.Row.DataItem, "TimeEntryStartDate")) & "&TimesheetPeriodType=" & DataBinder.Eval(e.Row.DataItem, "TimeEntryViewType")
                CType(e.Row.Cells(3).FindControl("lblTotalTime"), Label).Text = DBUtilities.GetDateTimeOfMinutesAsString(DataBinder.Eval(e.Row.DataItem, "TotalMinutes"))
                TotalTime3 += DataBinder.Eval(e.Row.DataItem, "TotalMinutes")
                CType(e.Row.Cells(4).FindControl("lblBillableTime"), Label).Text = DBUtilities.GetDateTimeOfMinutesAsString(DataBinder.Eval(e.Row.DataItem, "BillableTotalMinutes"))
                BillableTime3 += DataBinder.Eval(e.Row.DataItem, "BillableTotalMinutes")
                CType(e.Row.Cells(5).FindControl("lblNonBillableTime"), Label).Text = DBUtilities.GetDateTimeOfMinutesAsString(DataBinder.Eval(e.Row.DataItem, "NonBillableTotalMinutes"))
                NonBillableTime3 += DataBinder.Eval(e.Row.DataItem, "NonBillableTotalMinutes")
                If Not IsDBNull(DataBinder.Eval(e.Row.DataItem, "Percentage")) Then
                    CType(e.Row.Cells(5).FindControl("lblPercentage"), Label).Text = DataBinder.Eval(e.Row.DataItem, "Percentage") & "%"
                    Percentage3 += DataBinder.Eval(e.Row.DataItem, "Percentage")
                End If
            Else
                CType(e.Row.Cells(0).FindControl("lnkEmployeeName"), HyperLink).NavigateUrl = "~/Employee/AccountEmployeeTimeEntryWeekViewReadOnly.aspx?Type=SpecificExternalUser&AccountEmployeeId=" & DataBinder.Eval(e.Row.DataItem, "TimeEntryAccountEmployeeId") & "&StartDate=" & LocaleUtilitiesBLL.ConvertDateToDateBaseCulture(DataBinder.Eval(e.Row.DataItem, "TimeEntryStartDate")) & "&TimesheetPeriodType=" & DataBinder.Eval(e.Row.DataItem, "TimeEntryViewType")
                Dim TotalMinute As String = DBUtilities.GetDateTimeOfMinutesAsString(DataBinder.Eval(e.Row.DataItem, "TotalMinutes"))
                HArray3 = Split(TotalMinute, ":")
                Hours3 = LocaleUtilitiesBLL.ConvertTimeIntoHoursDecimalFormat(HArray3(0), HArray3(1))
                CType(e.Row.Cells(3).FindControl("lblTotalTime"), Label).Text = Hours3
                'LocaleUtilitiesBLL.ConvertTimeIntoHoursDecimalFormat()
                DTotalTime3 += Hours3

                Dim BillableHArray3 = Split(DBUtilities.GetDateTimeOfMinutesAsString(DataBinder.Eval(e.Row.DataItem, "BillableTotalMinutes")), ":")
                'BillableHArray = Split(BillableMinutes, ":")
                BillableHours3 = LocaleUtilitiesBLL.ConvertTimeIntoHoursDecimalFormat(BillableHArray3(0), BillableHArray3(1))
                CType(e.Row.Cells(4).FindControl("lblBillableTime"), Label).Text = BillableHours3
                DBillableTime3 += BillableHours3

                Dim NonBillableHArray3 = Split(DBUtilities.GetDateTimeOfMinutesAsString(DataBinder.Eval(e.Row.DataItem, "NonBillableTotalMinutes")), ":")
                'NonBillableHArray = Split(NonBillableMinutes, ":")
                NonBillableHours3 = LocaleUtilitiesBLL.ConvertTimeIntoHoursDecimalFormat(NonBillableHArray3(0), NonBillableHArray3(1))
                CType(e.Row.Cells(5).FindControl("lblNonBillableTime"), Label).Text = NonBillableHours3
                DNonBillableTime3 += NonBillableHours3

                If Not IsDBNull(DataBinder.Eval(e.Row.DataItem, "Percentage")) Then
                    CType(e.Row.Cells(5).FindControl("lblPercentage"), Label).Text = DataBinder.Eval(e.Row.DataItem, "Percentage") & "%"
                    Percentage3 += DataBinder.Eval(e.Row.DataItem, "Percentage")
                End If
            End If
        End If
        If e.Row.RowType = DataControlRowType.Footer Then
            If DBUtilities.IsTimeEntryHoursFormat <> "Decimal" Then
                CType(e.Row.Cells(3).FindControl("lblSumTotalTime"), Label).Text = DBUtilities.GetDateTimeOfMinutesAsString(TotalTime3)
                CType(e.Row.Cells(5).FindControl("lblSumPercentage"), Label).Text = Percentage3 & "%"
                CType(e.Row.Cells(4).FindControl("lblSumBillableTime"), Label).Text = DBUtilities.GetDateTimeOfMinutesAsString(BillableTime3)
                CType(e.Row.Cells(5).FindControl("lblSumNonBillableTime"), Label).Text = DBUtilities.GetDateTimeOfMinutesAsString(NonBillableTime3)
            Else
                CType(e.Row.Cells(3).FindControl("lblSumTotalTime"), Label).Text = DTotalTime3
                CType(e.Row.Cells(5).FindControl("lblSumPercentage"), Label).Text = Percentage3 & "%"
                CType(e.Row.Cells(4).FindControl("lblSumBillableTime"), Label).Text = DBillableTime3
                CType(e.Row.Cells(5).FindControl("lblSumNonBillableTime"), Label).Text = DNonBillableTime3
            End If
        End If
    End Sub
    Dim HArray4() As String
    Dim BillableHArray4 As String
    Dim NonBillableHArray4 As String
    Protected Sub GridView5_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then
            If DBUtilities.IsTimeEntryHoursFormat <> "Decimal" Then
                CType(e.Row.Cells(0).FindControl("lnkEmployeeName"), HyperLink).NavigateUrl = "~/Employee/AccountEmployeeTimeEntryWeekViewReadOnly.aspx?Type=EmployeeManager&AccountEmployeeId=" & DataBinder.Eval(e.Row.DataItem, "TimeEntryAccountEmployeeId") & "&StartDate=" & LocaleUtilitiesBLL.ConvertDateToDateBaseCulture(DataBinder.Eval(e.Row.DataItem, "TimeEntryStartDate")) & "&TimesheetPeriodType=" & DataBinder.Eval(e.Row.DataItem, "TimeEntryViewType")
                CType(e.Row.Cells(3).FindControl("lblTotalTime"), Label).Text = DBUtilities.GetDateTimeOfMinutesAsString(DataBinder.Eval(e.Row.DataItem, "TotalMinutes"))
                TotalTime4 += DataBinder.Eval(e.Row.DataItem, "TotalMinutes")
                CType(e.Row.Cells(4).FindControl("lblBillableTime"), Label).Text = DBUtilities.GetDateTimeOfMinutesAsString(DataBinder.Eval(e.Row.DataItem, "BillableTotalMinutes"))
                BillableTime4 += DataBinder.Eval(e.Row.DataItem, "BillableTotalMinutes")
                CType(e.Row.Cells(5).FindControl("lblNonBillableTime"), Label).Text = DBUtilities.GetDateTimeOfMinutesAsString(DataBinder.Eval(e.Row.DataItem, "NonBillableTotalMinutes"))
                NonBillableTime4 += DataBinder.Eval(e.Row.DataItem, "NonBillableTotalMinutes")
                If Not IsDBNull(DataBinder.Eval(e.Row.DataItem, "Percentage")) Then
                    CType(e.Row.Cells(5).FindControl("lblPercentage"), Label).Text = DataBinder.Eval(e.Row.DataItem, "Percentage") & "%"
                    Percentage4 += DataBinder.Eval(e.Row.DataItem, "Percentage")
                End If
            Else
                CType(e.Row.Cells(0).FindControl("lnkEmployeeName"), HyperLink).NavigateUrl = "~/Employee/AccountEmployeeTimeEntryWeekViewReadOnly.aspx?Type=EmployeeManager&AccountEmployeeId=" & DataBinder.Eval(e.Row.DataItem, "TimeEntryAccountEmployeeId") & "&StartDate=" & LocaleUtilitiesBLL.ConvertDateToDateBaseCulture(DataBinder.Eval(e.Row.DataItem, "TimeEntryStartDate")) & "&TimesheetPeriodType=" & DataBinder.Eval(e.Row.DataItem, "TimeEntryViewType")
                Dim TotalMinute As String = DBUtilities.GetDateTimeOfMinutesAsString(DataBinder.Eval(e.Row.DataItem, "TotalMinutes"))
                HArray4 = Split(TotalMinute, ":")
                Hours4 = LocaleUtilitiesBLL.ConvertTimeIntoHoursDecimalFormat(HArray4(0), HArray4(1))
                CType(e.Row.Cells(3).FindControl("lblTotalTime"), Label).Text = Hours4
                'LocaleUtilitiesBLL.ConvertTimeIntoHoursDecimalFormat()
                DTotalTime4 += Hours4

                Dim BillableHArray4 = Split(DBUtilities.GetDateTimeOfMinutesAsString(DataBinder.Eval(e.Row.DataItem, "BillableTotalMinutes")), ":")
                'BillableHArray = Split(BillableMinutes, ":")
                BillableHours4 = LocaleUtilitiesBLL.ConvertTimeIntoHoursDecimalFormat(BillableHArray4(0), BillableHArray4(1))
                CType(e.Row.Cells(4).FindControl("lblBillableTime"), Label).Text = BillableHours4
                DBillableTime4 += BillableHours4

                Dim NonBillableHArray4 = Split(DBUtilities.GetDateTimeOfMinutesAsString(DataBinder.Eval(e.Row.DataItem, "NonBillableTotalMinutes")), ":")
                'NonBillableHArray = Split(NonBillableMinutes, ":")
                NonBillableHours4 = LocaleUtilitiesBLL.ConvertTimeIntoHoursDecimalFormat(NonBillableHArray4(0), NonBillableHArray4(1))
                CType(e.Row.Cells(5).FindControl("lblNonBillableTime"), Label).Text = NonBillableHours4
                DNonBillableTime4 += NonBillableHours4

                If Not IsDBNull(DataBinder.Eval(e.Row.DataItem, "Percentage")) Then
                    CType(e.Row.Cells(5).FindControl("lblPercentage"), Label).Text = DataBinder.Eval(e.Row.DataItem, "Percentage") & "%"
                    Percentage4 += DataBinder.Eval(e.Row.DataItem, "Percentage")
                End If
            End If
        End If
        If e.Row.RowType = DataControlRowType.Footer Then
            If DBUtilities.IsTimeEntryHoursFormat <> "Decimal" Then
                CType(e.Row.Cells(3).FindControl("lblSumTotalTime"), Label).Text = DBUtilities.GetDateTimeOfMinutesAsString(TotalTime4)
                CType(e.Row.Cells(5).FindControl("lblSumPercentage"), Label).Text = Percentage4 & "%"
                CType(e.Row.Cells(4).FindControl("lblSumBillableTime"), Label).Text = DBUtilities.GetDateTimeOfMinutesAsString(BillableTime4)
                CType(e.Row.Cells(5).FindControl("lblSumNonBillableTime"), Label).Text = DBUtilities.GetDateTimeOfMinutesAsString(NonBillableTime4)
            Else
                CType(e.Row.Cells(3).FindControl("lblSumTotalTime"), Label).Text = DTotalTime4
                CType(e.Row.Cells(5).FindControl("lblSumPercentage"), Label).Text = Percentage4 & "%"
                CType(e.Row.Cells(4).FindControl("lblSumBillableTime"), Label).Text = DBillableTime4
                CType(e.Row.Cells(5).FindControl("lblSumNonBillableTime"), Label).Text = DNonBillableTime4
            End If
        End If
    End Sub
    Public Sub ForApproved(ByVal AccountEmployeeId As Integer, ByVal TimeEntryStartDate As DateTime, ByVal TimeEntryEndDate As DateTime, ByVal IncludeDateRange As Boolean)
        Dim TimeEntryBLL As New AccountEmployeeTimeEntryBLL

        Dim row As GridViewRow
        For Each row In Me.GridView1.Rows
            IIf(IsDBNull(CType(row.FindControl("chkTeamLead"), CheckBox).Checked), CType(row.FindControl("chkTeamLead"), CheckBox).Checked = False, CType(row.FindControl("chkTeamLead"), CheckBox).Checked)
            TimeEntryBLL.BulkTimeSheetApprovalEntriesForApproved(AccountEmployeeId, Me.GridView1.DataKeys(row.RowIndex)(0), Me.GridView1.DataKeys(row.RowIndex)(1), Me.GridView1.DataKeys(row.RowIndex)(2), CType(row.FindControl("TeamLeadCommentsTextBox"), TextBox).Text, CType(row.FindControl("chkTeamLead"), CheckBox).Checked, False, False, False, False, Me.GridView1.DataKeys(row.RowIndex)(3), Me.GridView1.DataKeys(row.RowIndex)(4), Me.GridView1.DataKeys(row.RowIndex)(5), Me.GridView1.DataKeys(row.RowIndex)(6), Me.GridView1.DataKeys(row.RowIndex)(7), Me.GridView1.DataKeys(row.RowIndex)(8))
        Next

        Dim row1 As GridViewRow
        For Each row1 In Me.GridView2.Rows
            IIf(IsDBNull(CType(row1.FindControl("chkProjectManager"), CheckBox).Checked), CType(row1.FindControl("chkProjectManager"), CheckBox).Checked = False, CType(row1.FindControl("chkProjectManager"), CheckBox).Checked)
            TimeEntryBLL.BulkTimeSheetApprovalEntriesForApproved(AccountEmployeeId, Me.GridView2.DataKeys(row1.RowIndex)(0), Me.GridView2.DataKeys(row1.RowIndex)(1), Me.GridView2.DataKeys(row1.RowIndex)(2), CType(row1.FindControl("ProjectManagerCommentsTextBox"), TextBox).Text, False, CType(row1.FindControl("chkProjectManager"), CheckBox).Checked, False, False, False, Me.GridView2.DataKeys(row1.RowIndex)(3), Me.GridView2.DataKeys(row1.RowIndex)(4), Me.GridView2.DataKeys(row1.RowIndex)(5), Me.GridView2.DataKeys(row1.RowIndex)(6), Me.GridView2.DataKeys(row1.RowIndex)(7), Me.GridView2.DataKeys(row1.RowIndex)(8))
        Next

        Dim row2 As GridViewRow
        For Each row2 In Me.GridView3.Rows
            IIf(IsDBNull(CType(row2.FindControl("chkSpecificEmployee"), CheckBox).Checked), CType(row2.FindControl("chkSpecificEmployee"), CheckBox).Checked = False, CType(row2.FindControl("chkSpecificEmployee"), CheckBox).Checked)
            TimeEntryBLL.BulkTimeSheetApprovalEntriesForApproved(AccountEmployeeId, Me.GridView3.DataKeys(row2.RowIndex)(0), Me.GridView3.DataKeys(row2.RowIndex)(1), Me.GridView3.DataKeys(row2.RowIndex)(2), CType(row2.FindControl("SpecificEmployeeCommentsTextBox"), TextBox).Text, False, False, CType(row2.FindControl("chkSpecificEmployee"), CheckBox).Checked, False, False, Me.GridView3.DataKeys(row2.RowIndex)(3), Me.GridView3.DataKeys(row2.RowIndex)(4), Me.GridView3.DataKeys(row2.RowIndex)(5), Me.GridView3.DataKeys(row2.RowIndex)(6), Me.GridView3.DataKeys(row2.RowIndex)(7), Me.GridView3.DataKeys(row2.RowIndex)(8))
        Next


        Dim row3 As GridViewRow
        For Each row3 In Me.GridView4.Rows
            IIf(IsDBNull(CType(row3.FindControl("chkSpecificExternalUser"), CheckBox).Checked), CType(row3.FindControl("chkSpecificExternalUser"), CheckBox).Checked = False, CType(row3.FindControl("chkSpecificExternalUser"), CheckBox).Checked)
            TimeEntryBLL.BulkTimeSheetApprovalEntriesForApproved(AccountEmployeeId, Me.GridView4.DataKeys(row3.RowIndex)(0), Me.GridView4.DataKeys(row3.RowIndex)(1), Me.GridView4.DataKeys(row3.RowIndex)(2), CType(row3.FindControl("SpecificExternalUserCommentsTextBox"), TextBox).Text, False, False, False, CType(row3.FindControl("chkSpecificExternalUser"), CheckBox).Checked, False, Me.GridView4.DataKeys(row3.RowIndex)(3), Me.GridView4.DataKeys(row3.RowIndex)(4), Me.GridView4.DataKeys(row3.RowIndex)(5), Me.GridView4.DataKeys(row3.RowIndex)(6), Me.GridView4.DataKeys(row3.RowIndex)(7), Me.GridView4.DataKeys(row3.RowIndex)(8))
        Next

        Dim row4 As GridViewRow
        For Each row4 In Me.GridView5.Rows
            IIf(IsDBNull(CType(row4.FindControl("chkEmployeeManager"), CheckBox).Checked), CType(row4.FindControl("chkEmployeeManager"), CheckBox).Checked = False, CType(row4.FindControl("chkEmployeeManager"), CheckBox).Checked)
            TimeEntryBLL.BulkTimeSheetApprovalEntriesForApproved(AccountEmployeeId, Me.GridView5.DataKeys(row4.RowIndex)(0), Me.GridView5.DataKeys(row4.RowIndex)(1), Me.GridView5.DataKeys(row4.RowIndex)(2), CType(row4.FindControl("EmployeeManagerCommentsTextBox"), TextBox).Text, False, False, False, False, CType(row4.FindControl("chkEmployeeManager"), CheckBox).Checked, Me.GridView5.DataKeys(row4.RowIndex)(3), Me.GridView5.DataKeys(row4.RowIndex)(4), Me.GridView5.DataKeys(row4.RowIndex)(5), Me.GridView5.DataKeys(row4.RowIndex)(6), Me.GridView5.DataKeys(row4.RowIndex)(7), Me.GridView5.DataKeys(row4.RowIndex)(8))
        Next

        Dim row5 As GridViewRow
        Dim SETimeOffBatchId As Guid = System.Guid.Empty
        For Each row5 In Me.GridView6.Rows
            If CType(row5.FindControl("chkSpecificEmployeeTimeOff"), CheckBox).Checked = True And IsDBNull(Me.GridView6.DataKeys(row5.RowIndex)("IsApproved")) Then
                TimeEntryBLL.AddTimeSheetApproval(Me.GridView6.DataKeys(row5.RowIndex)("AccountEmployeeTimeEntryId"), Me.GridView6.DataKeys(row5.RowIndex)("AccountApprovalTypeId"), Me.GridView6.DataKeys(row5.RowIndex)("AccountApprovalPathId"), Me.GridView6.DataKeys(row5.RowIndex)("AccountEmployeeId"), CType(row5.FindControl("SpecificEmployeeTimeOffCommentsTextBox"), TextBox).Text, False, True, Nothing, SETimeOffBatchId)
                If Me.GridView6.DataKeys(row5.RowIndex)("ApprovalPathSequence") = Me.GridView6.DataKeys(row5.RowIndex)("MaxApprovalPathSequence") Then
                    TimeEntryBLL.UpdateEmployeeTimeOffHours(Me.GridView6.DataKeys(row5.RowIndex)("TimeEntryAccountEmployeeId"), Me.GridView6.DataKeys(row5.RowIndex)("AccountTimeOffTypeId"), DBUtilities.GetDateTimeOfMinutesAsString(Me.GridView6.DataKeys(row5.RowIndex)("TotalMinutes")), DBUtilities.GetEmployeeNameWithCode, "Approved", "Time Sheet Approval", Me.GridView6.DataKeys(row5.RowIndex)("AccountEmployeeTimeEntryId"))
                    TimeEntryBLL.LockTimeOffTimeEntry(Me.GridView6.DataKeys(row5.RowIndex)("AccountEmployeeTimeEntryId"), True, Me.GridView6.DataKeys(row5.RowIndex)("AccountEmployeeId"), Me.GridView6.DataKeys(row5.RowIndex)("AccountEmployeeTimeEntryPeriodId"))
                End If
            ElseIf CType(row5.FindControl("chkSpecificEmployeeTimeOff"), CheckBox).Checked = False And IsDBNull(Me.GridView6.DataKeys(row5.RowIndex)("IsApproved")) Then
            ElseIf CType(row5.FindControl("chkSpecificEmployeeTimeOff"), CheckBox).Checked = True And Me.GridView6.DataKeys(row5.RowIndex)("IsApproved") = False Then
                TimeEntryBLL.AddTimeSheetApproval(Me.GridView6.DataKeys(row5.RowIndex)("AccountEmployeeTimeEntryId"), Me.GridView6.DataKeys(row5.RowIndex)("AccountApprovalTypeId"), Me.GridView6.DataKeys(row5.RowIndex)("AccountApprovalPathId"), Me.GridView6.DataKeys(row5.RowIndex)("AccountEmployeeId"), CType(row5.FindControl("SpecificEmployeeTimeOffCommentsTextBox"), TextBox).Text, False, True, Nothing, SETimeOffBatchId)
                If Me.GridView6.DataKeys(row5.RowIndex)("ApprovalPathSequence") = Me.GridView6.DataKeys(row5.RowIndex)("MaxApprovalPathSequence") Then
                    TimeEntryBLL.UpdateEmployeeTimeOffHours(Me.GridView6.DataKeys(row5.RowIndex)("TimeEntryAccountEmployeeId"), Me.GridView6.DataKeys(row5.RowIndex)("AccountTimeOffTypeId"), DBUtilities.GetDateTimeOfMinutesAsString(Me.GridView6.DataKeys(row5.RowIndex)("TotalMinutes")), Me.GridView6.DataKeys(row5.RowIndex)("AccountEmployeeTimeEntryId"))
                    TimeEntryBLL.LockTimeOffTimeEntry(Me.GridView6.DataKeys(row5.RowIndex)("AccountEmployeeTimeEntryId"), True, Me.GridView6.DataKeys(row5.RowIndex)("AccountEmployeeId"), Me.GridView6.DataKeys(row5.RowIndex)("AccountEmployeeTimeEntryPeriodId"))
                End If
            ElseIf CType(row5.FindControl("chkSpecificEmployeeTimeOff"), CheckBox).Checked = False And Me.GridView6.DataKeys(row5.RowIndex)("IsApproved") = True Then
                TimeEntryBLL.AddTimeSheetApproval(Me.GridView6.DataKeys(row5.RowIndex)("AccountEmployeeTimeEntryId"), Me.GridView6.DataKeys(row5.RowIndex)("AccountApprovalTypeId"), Me.GridView6.DataKeys(row5.RowIndex)("AccountApprovalPathId"), Me.GridView6.DataKeys(row5.RowIndex)("AccountEmployeeId"), CType(row5.FindControl("SpecificEmployeeTimeOffCommentsTextBox"), TextBox).Text, False, True, Nothing, SETimeOffBatchId)
                If Me.GridView6.DataKeys(row5.RowIndex)("ApprovalPathSequence") = Me.GridView6.DataKeys(row5.RowIndex)("MaxApprovalPathSequence") Then
                    TimeEntryBLL.UpdateEmployeeTimeOffHours(Me.GridView6.DataKeys(row5.RowIndex)("TimeEntryAccountEmployeeId"), Me.GridView6.DataKeys(row5.RowIndex)("AccountTimeOffTypeId"), DBUtilities.GetDateTimeOfMinutesAsString(Me.GridView6.DataKeys(row5.RowIndex)("TotalMinutes")), Me.GridView6.DataKeys(row5.RowIndex)("AccountEmployeeTimeEntryId"))
                    TimeEntryBLL.LockTimeOffTimeEntry(Me.GridView6.DataKeys(row5.RowIndex)("AccountEmployeeTimeEntryId"), True, Me.GridView6.DataKeys(row5.RowIndex)("AccountEmployeeId"), Me.GridView6.DataKeys(row5.RowIndex)("AccountEmployeeTimeEntryPeriodId"))
                End If
            End If
        Next

        Dim row6 As GridViewRow
        Dim EMTimeOffBatchId As Guid = System.Guid.Empty
        For Each row6 In Me.GridView7.Rows
            If CType(row6.FindControl("chkEmployeeManagerTimeOff"), CheckBox).Checked = True And IsDBNull(Me.GridView7.DataKeys(row6.RowIndex)("IsApproved")) Then
                TimeEntryBLL.AddTimeSheetApproval(Me.GridView7.DataKeys(row6.RowIndex)("AccountEmployeeTimeEntryId"), Me.GridView7.DataKeys(row6.RowIndex)("AccountApprovalTypeId"), Me.GridView7.DataKeys(row6.RowIndex)("AccountApprovalPathId"), Me.GridView7.DataKeys(row6.RowIndex)("EmployeeManagerId"), CType(row6.FindControl("EmployeeManagerTimeOffCommentsTextBox"), TextBox).Text, False, True, Nothing, EMTimeOffBatchId)
                If Me.GridView7.DataKeys(row6.RowIndex)("ApprovalPathSequence") = Me.GridView7.DataKeys(row6.RowIndex)("MaxApprovalPathSequence") Then
                    TimeEntryBLL.UpdateEmployeeTimeOffHours(Me.GridView7.DataKeys(row6.RowIndex)("TimeEntryAccountEmployeeId"), Me.GridView7.DataKeys(row6.RowIndex)("AccountTimeOffTypeId"), DBUtilities.GetDateTimeOfMinutesAsString(Me.GridView7.DataKeys(row6.RowIndex)("TotalMinutes")), DBUtilities.GetEmployeeNameWithCode, "Approved", "Time Sheet Approval", Me.GridView7.DataKeys(row6.RowIndex)("AccountEmployeeTimeEntryId"))
                    TimeEntryBLL.LockTimeOffTimeEntry(Me.GridView7.DataKeys(row6.RowIndex)("AccountEmployeeTimeEntryId"), True, Me.GridView7.DataKeys(row6.RowIndex)("EmployeeManagerId"), Me.GridView7.DataKeys(row6.RowIndex)("AccountEmployeeTimeEntryPeriodId"))
                End If
            ElseIf CType(row6.FindControl("chkEmployeeManagerTimeOff"), CheckBox).Checked = False And IsDBNull(Me.GridView7.DataKeys(row6.RowIndex)("IsApproved")) Then
            ElseIf CType(row6.FindControl("chkEmployeeManagerTimeOff"), CheckBox).Checked = True And Me.GridView7.DataKeys(row6.RowIndex)("IsApproved") = False Then
                TimeEntryBLL.AddTimeSheetApproval(Me.GridView7.DataKeys(row6.RowIndex)("AccountEmployeeTimeEntryId"), Me.GridView7.DataKeys(row6.RowIndex)("AccountApprovalTypeId"), Me.GridView7.DataKeys(row6.RowIndex)("AccountApprovalPathId"), Me.GridView7.DataKeys(row6.RowIndex)("EmployeeManagerId"), CType(row6.FindControl("EmployeeManagerTimeOffCommentsTextBox"), TextBox).Text, False, True, Nothing, EMTimeOffBatchId)
                If Me.GridView7.DataKeys(row6.RowIndex)("ApprovalPathSequence") = Me.GridView7.DataKeys(row6.RowIndex)("MaxApprovalPathSequence") Then
                    TimeEntryBLL.UpdateEmployeeTimeOffHours(Me.GridView7.DataKeys(row6.RowIndex)("TimeEntryAccountEmployeeId"), Me.GridView7.DataKeys(row6.RowIndex)("AccountTimeOffTypeId"), DBUtilities.GetDateTimeOfMinutesAsString(Me.GridView7.DataKeys(row6.RowIndex)("TotalMinutes")), Me.GridView7.DataKeys(row6.RowIndex)("AccountEmployeeTimeEntryId"))
                    TimeEntryBLL.LockTimeOffTimeEntry(Me.GridView7.DataKeys(row6.RowIndex)("AccountEmployeeTimeEntryId"), True, Me.GridView7.DataKeys(row6.RowIndex)("EmployeeManagerId"), Me.GridView7.DataKeys(row6.RowIndex)("AccountEmployeeTimeEntryPeriodId"))
                End If
            ElseIf CType(row6.FindControl("chkEmployeeManagerTimeOff"), CheckBox).Checked = False And Me.GridView7.DataKeys(row6.RowIndex)("IsApproved") = True Then
                TimeEntryBLL.AddTimeSheetApproval(Me.GridView7.DataKeys(row6.RowIndex)("AccountEmployeeTimeEntryId"), Me.GridView7.DataKeys(row6.RowIndex)("AccountApprovalTypeId"), Me.GridView7.DataKeys(row6.RowIndex)("AccountApprovalPathId"), Me.GridView7.DataKeys(row6.RowIndex)("EmployeeManagerId"), CType(row6.FindControl("EmployeeManagerTimeOffCommentsTextBox"), TextBox).Text, False, True, Nothing, EMTimeOffBatchId)
                If Me.GridView7.DataKeys(row6.RowIndex)("ApprovalPathSequence") = Me.GridView7.DataKeys(row6.RowIndex)("MaxApprovalPathSequence") Then
                    TimeEntryBLL.UpdateEmployeeTimeOffHours(Me.GridView7.DataKeys(row6.RowIndex)("TimeEntryAccountEmployeeId"), Me.GridView7.DataKeys(row6.RowIndex)("AccountTimeOffTypeId"), DBUtilities.GetDateTimeOfMinutesAsString(Me.GridView7.DataKeys(row6.RowIndex)("TotalMinutes")), Me.GridView7.DataKeys(row6.RowIndex)("AccountEmployeeTimeEntryId"))
                    TimeEntryBLL.LockTimeOffTimeEntry(Me.GridView7.DataKeys(row6.RowIndex)("AccountEmployeeTimeEntryId"), True, Me.GridView7.DataKeys(row6.RowIndex)("EmployeeManagerId"), Me.GridView7.DataKeys(row6.RowIndex)("AccountEmployeeTimeEntryPeriodId"))
                End If
            End If
        Next
    End Sub
    Public Sub ForReject(ByVal AccountEmployeeId As Integer, ByVal TimeEntryStartDate As DateTime, ByVal TimeEntryEndDate As DateTime, ByVal IncludeDateRange As Boolean)
        Dim TimeEntryBLL As New AccountEmployeeTimeEntryBLL
        Dim row As GridViewRow

        For Each row In Me.GridView1.Rows
            IIf(IsDBNull(CType(row.FindControl("chkTeamLead"), CheckBox).Checked), CType(row.FindControl("chkTeamLead"), CheckBox).Checked = False, CType(row.FindControl("chkTeamLead"), CheckBox).Checked)
            IIf(IsDBNull(CType(row.FindControl("chkTeamLeadRejected"), CheckBox).Checked), CType(row.FindControl("chkTeamLeadRejected"), CheckBox).Checked = False, CType(row.FindControl("chkTeamLeadRejected"), CheckBox).Checked)
            TimeEntryBLL.BulkTimeSheetApprovalEntriesForRejected(AccountEmployeeId, Me.GridView1.DataKeys(row.RowIndex)(0), Me.GridView1.DataKeys(row.RowIndex)(1), Me.GridView1.DataKeys(row.RowIndex)(2), CType(row.FindControl("TeamLeadCommentsTextBox"), TextBox).Text, CType(row.FindControl("chkTeamLead"), CheckBox).Checked, CType(row.FindControl("chkTeamLeadRejected"), CheckBox).Checked, False, False, False, False, False, False, False, False, Me.GridView1.DataKeys(row.RowIndex)(3), Me.GridView1.DataKeys(row.RowIndex)(4), Me.GridView1.DataKeys(row.RowIndex)(5), Me.GridView1.DataKeys(row.RowIndex)(6), Me.GridView1.DataKeys(row.RowIndex)(7), Me.GridView1.DataKeys(row.RowIndex)(8), Me.GridView1.DataKeys(row.RowIndex)(9))
        Next

        Dim row1 As GridViewRow
        For Each row1 In Me.GridView2.Rows
            IIf(IsDBNull(CType(row1.FindControl("chkProjectManager"), CheckBox).Checked), CType(row1.FindControl("chkProjectManager"), CheckBox).Checked = False, CType(row1.FindControl("chkProjectManager"), CheckBox).Checked)
            IIf(IsDBNull(CType(row1.FindControl("chkProjectManagerRejected"), CheckBox).Checked), CType(row1.FindControl("chkProjectManagerRejected"), CheckBox).Checked = False, CType(row1.FindControl("chkProjectManagerRejected"), CheckBox).Checked)
            TimeEntryBLL.BulkTimeSheetApprovalEntriesForRejected(AccountEmployeeId, Me.GridView2.DataKeys(row1.RowIndex)(0), Me.GridView2.DataKeys(row1.RowIndex)(1), Me.GridView2.DataKeys(row1.RowIndex)(2), CType(row1.FindControl("ProjectManagerCommentsTextBox"), TextBox).Text, False, False, CType(row1.FindControl("chkProjectManager"), CheckBox).Checked, CType(row1.FindControl("chkProjectManagerRejected"), CheckBox).Checked, False, False, False, False, False, False, Me.GridView2.DataKeys(row1.RowIndex)(3), Me.GridView2.DataKeys(row1.RowIndex)(4), Me.GridView2.DataKeys(row1.RowIndex)(5), Me.GridView2.DataKeys(row1.RowIndex)(6), Me.GridView2.DataKeys(row1.RowIndex)(7), Me.GridView2.DataKeys(row1.RowIndex)(8), Me.GridView2.DataKeys(row1.RowIndex)(9))
        Next

        Dim row2 As GridViewRow
        For Each row2 In Me.GridView3.Rows
            IIf(IsDBNull(CType(row2.FindControl("chkSpecificEmployee"), CheckBox).Checked), CType(row2.FindControl("chkSpecificEmployee"), CheckBox).Checked = False, CType(row2.FindControl("chkSpecificEmployee"), CheckBox).Checked)
            IIf(IsDBNull(CType(row2.FindControl("chkSpecificEmployeeRejected"), CheckBox).Checked), CType(row2.FindControl("chkSpecificEmployeeRejected"), CheckBox).Checked = False, CType(row2.FindControl("chkSpecificEmployeeRejected"), CheckBox).Checked)
            TimeEntryBLL.BulkTimeSheetApprovalEntriesForRejected(AccountEmployeeId, Me.GridView3.DataKeys(row2.RowIndex)(0), Me.GridView3.DataKeys(row2.RowIndex)(1), Me.GridView3.DataKeys(row2.RowIndex)(2), CType(row2.FindControl("SpecificEmployeeCommentsTextBox"), TextBox).Text, False, False, False, False, CType(row2.FindControl("chkSpecificEmployee"), CheckBox).Checked, CType(row2.FindControl("chkSpecificEmployeeRejected"), CheckBox).Checked, False, False, False, False, Me.GridView3.DataKeys(row2.RowIndex)(3), Me.GridView3.DataKeys(row2.RowIndex)(4), Me.GridView3.DataKeys(row2.RowIndex)(5), Me.GridView3.DataKeys(row2.RowIndex)(6), Me.GridView3.DataKeys(row2.RowIndex)(7), Me.GridView3.DataKeys(row2.RowIndex)(8), Me.GridView3.DataKeys(row2.RowIndex)(9))
        Next

        Dim row3 As GridViewRow
        For Each row3 In Me.GridView4.Rows
            IIf(IsDBNull(CType(row3.FindControl("chkSpecificExternalUser"), CheckBox).Checked), CType(row3.FindControl("chkSpecificExternalUser"), CheckBox).Checked = False, CType(row3.FindControl("chkSpecificExternalUser"), CheckBox).Checked)
            IIf(IsDBNull(CType(row3.FindControl("chkSpecificExternalUserRejected"), CheckBox).Checked), CType(row3.FindControl("chkSpecificExternalUserRejected"), CheckBox).Checked = False, CType(row3.FindControl("chkSpecificExternalUserRejected"), CheckBox).Checked)
            TimeEntryBLL.BulkTimeSheetApprovalEntriesForRejected(AccountEmployeeId, Me.GridView4.DataKeys(row3.RowIndex)(0), Me.GridView4.DataKeys(row3.RowIndex)(1), Me.GridView4.DataKeys(row3.RowIndex)(2), CType(row3.FindControl("SpecificExternalUserCommentsTextBox"), TextBox).Text, False, False, False, False, False, False, CType(row3.FindControl("chkSpecificExternalUser"), CheckBox).Checked, CType(row3.FindControl("chkSpecificExternalUserRejected"), CheckBox).Checked, False, False, Me.GridView4.DataKeys(row3.RowIndex)(3), Me.GridView4.DataKeys(row3.RowIndex)(4), Me.GridView4.DataKeys(row3.RowIndex)(5), Me.GridView4.DataKeys(row3.RowIndex)(6), Me.GridView4.DataKeys(row3.RowIndex)(7), Me.GridView4.DataKeys(row3.RowIndex)(8), Me.GridView4.DataKeys(row3.RowIndex)(9))
        Next

        Dim row4 As GridViewRow
        For Each row4 In Me.GridView5.Rows
            IIf(IsDBNull(CType(row4.FindControl("chkEmployeeManager"), CheckBox).Checked), CType(row4.FindControl("chkEmployeeManager"), CheckBox).Checked = False, CType(row4.FindControl("chkEmployeeManager"), CheckBox).Checked)
            IIf(IsDBNull(CType(row4.FindControl("chkEmployeeManagerRejected"), CheckBox).Checked), CType(row4.FindControl("chkEmployeeManagerRejected"), CheckBox).Checked = False, CType(row4.FindControl("chkEmployeeManagerRejected"), CheckBox).Checked)
            TimeEntryBLL.BulkTimeSheetApprovalEntriesForRejected(AccountEmployeeId, Me.GridView5.DataKeys(row4.RowIndex)(0), Me.GridView5.DataKeys(row4.RowIndex)(1), Me.GridView5.DataKeys(row4.RowIndex)(2), CType(row4.FindControl("EmployeeManagerCommentsTextBox"), TextBox).Text, False, False, False, False, False, False, False, False, CType(row4.FindControl("chkEmployeeManager"), CheckBox).Checked, CType(row4.FindControl("chkEmployeeManagerRejected"), CheckBox).Checked, Me.GridView5.DataKeys(row4.RowIndex)(3), Me.GridView5.DataKeys(row4.RowIndex)(4), Me.GridView5.DataKeys(row4.RowIndex)(5), Me.GridView5.DataKeys(row4.RowIndex)(6), Me.GridView5.DataKeys(row4.RowIndex)(7), Me.GridView5.DataKeys(row4.RowIndex)(8), Me.GridView5.DataKeys(row4.RowIndex)(9))
        Next

        Dim row5 As GridViewRow
        For Each row5 In Me.GridView6.Rows
            If CType(row5.FindControl("chkSpecificEmployeeTimeOffRejected"), CheckBox).Checked = True Then
                TimeEntryBLL.AddTimeSheetApproval(Me.GridView6.DataKeys(row5.RowIndex)("AccountEmployeeTimeEntryId"), Me.GridView6.DataKeys(row5.RowIndex)("AccountApprovalTypeId"), Me.GridView6.DataKeys(row5.RowIndex)("AccountApprovalPathId"), Me.GridView6.DataKeys(row5.RowIndex)("AccountEmployeeId"), CType(row5.FindControl("SpecificEmployeeTimeOffCommentsTextBox"), TextBox).Text, True, False, Nothing, System.Guid.Empty)
                TimeEntryBLL.LockTeamLeadTimeEntryRejected(Me.GridView6.DataKeys(row5.RowIndex)("AccountEmployeeTimeEntryId"), True, Me.GridView6.DataKeys(row5.RowIndex)("AccountEmployeeId"))
            End If
        Next

        Dim row6 As GridViewRow
        For Each row6 In Me.GridView7.Rows
            If CType(row6.FindControl("chkEmployeeManagerTimeOffRejected"), CheckBox).Checked = True Then
                TimeEntryBLL.AddTimeSheetApproval(Me.GridView7.DataKeys(row6.RowIndex)("AccountEmployeeTimeEntryId"), Me.GridView7.DataKeys(row6.RowIndex)("AccountApprovalTypeId"), Me.GridView7.DataKeys(row6.RowIndex)("AccountApprovalPathId"), Me.GridView7.DataKeys(row6.RowIndex)("EmployeeManagerId"), CType(row6.FindControl("EmployeeManagerTimeOffCommentsTextBox"), TextBox).Text, True, False, Nothing, System.Guid.Empty)
                TimeEntryBLL.LockTeamLeadTimeEntryRejected(Me.GridView7.DataKeys(row6.RowIndex)("AccountEmployeeTimeEntryId"), True, Me.GridView7.DataKeys(row6.RowIndex)("EmployeeManagerId"))
            End If
        Next
    End Sub
    Public Function CheckApprovalEntriesForApproved() As Boolean
        Dim row As GridViewRow
        For Each row In Me.GridView1.Rows
            If CType(row.FindControl("chkTeamLead"), CheckBox).Checked = True Then
                Return True
            End If
        Next

        Dim row1 As GridViewRow
        For Each row1 In Me.GridView2.Rows
            If CType(row1.FindControl("chkProjectManager"), CheckBox).Checked = True Then
                Return True
            End If
        Next

        Dim row2 As GridViewRow
        For Each row2 In Me.GridView3.Rows
            If CType(row2.FindControl("chkSpecificEmployee"), CheckBox).Checked = True Then
                Return True
            End If
        Next

        Dim row3 As GridViewRow
        For Each row3 In Me.GridView4.Rows
            If CType(row3.FindControl("chkSpecificExternalUser"), CheckBox).Checked = True Then
                Return True
            End If
        Next

        Dim row4 As GridViewRow
        For Each row4 In Me.GridView5.Rows
            If CType(row4.FindControl("chkEmployeeManager"), CheckBox).Checked = True Then
                Return True
            End If
        Next

        Dim row5 As GridViewRow
        For Each row5 In Me.GridView6.Rows
            If CType(row5.FindControl("chkSpecificEmployeeTimeOff"), CheckBox).Checked = True Then
                Return True
            End If
        Next

        Dim row6 As GridViewRow
        For Each row6 In Me.GridView7.Rows
            If CType(row6.FindControl("chkEmployeeManagerTimeOff"), CheckBox).Checked = True Then
                Return True
            End If
        Next

        Return False
    End Function
    Public Function CheckApprovalEntriesForReject() As Boolean
        Dim row As GridViewRow
        For Each row In Me.GridView1.Rows
            If CType(row.FindControl("chkTeamLeadRejected"), CheckBox).Checked = True Then
                Return True
            End If
        Next

        Dim row1 As GridViewRow
        For Each row1 In Me.GridView2.Rows
            If CType(row1.FindControl("chkProjectManagerRejected"), CheckBox).Checked = True Then
                Return True
            End If
        Next

        Dim row2 As GridViewRow
        For Each row2 In Me.GridView3.Rows
            If CType(row2.FindControl("chkSpecificEmployeeRejected"), CheckBox).Checked = True Then
                Return True
            End If
        Next

        Dim row3 As GridViewRow
        For Each row3 In Me.GridView4.Rows
            If CType(row3.FindControl("chkSpecificExternalUserRejected"), CheckBox).Checked = True Then
                Return True
            End If
        Next

        Dim row4 As GridViewRow
        For Each row4 In Me.GridView5.Rows
            If CType(row4.FindControl("chkEmployeeManagerRejected"), CheckBox).Checked = True Then
                Return True
            End If
        Next

        Dim row5 As GridViewRow
        For Each row5 In Me.GridView6.Rows
            If CType(row5.FindControl("chkSpecificEmployeeTimeOffRejected"), CheckBox).Checked = True Then
                Return True
            End If
        Next

        Dim row6 As GridViewRow
        For Each row6 In Me.GridView7.Rows
            If CType(row6.FindControl("chkEmployeeManagerTimeOffRejected"), CheckBox).Checked = True Then
                Return True
            End If
        Next

        Return False
    End Function

    Protected Sub GridView1_DataBound(ByVal sender As Object, ByVal e As System.EventArgs)
        'On every page visit we need to build up the CheckBoxIDs array
        For Each gvr As GridViewRow In GridView1.Rows

            'Get a programmatic reference to the CheckBox control
            Dim cb As CheckBox = CType(gvr.FindControl("chkTeamLead"), CheckBox)

            Me.Page.ClientScript.RegisterArrayDeclaration("CheckBoxIDs1", String.Concat("'", cb.ClientID, "'"))
        Next

        If Me.GridView1.Rows.Count <> 0 Then
            Me.CheckAllTeamLead.Visible = True
            Me.UnCheckAllTeamLead.Visible = True
        Else
            Me.CheckAllTeamLead.Visible = False
            Me.UnCheckAllTeamLead.Visible = False
        End If
        TotalTime = 0
        BillableTime = 0
        NonBillableTime = 0
        Percentage = 0
        Hours = 0
        NonBillableHours = 0
        BillableHours = 0
        DTotalTime = 0
        DBillableTime = 0
        DNonBillableTime = 0
    End Sub

    Protected Sub GridView2_DataBound(ByVal sender As Object, ByVal e As System.EventArgs)
        'On every page visit we need to build up the CheckBoxIDs array
        For Each gvr As GridViewRow In GridView2.Rows
            'Get a programmatic reference to the CheckBox control
            Dim cb As CheckBox = CType(gvr.FindControl("chkProjectManager"), CheckBox)

            Me.Page.ClientScript.RegisterArrayDeclaration("CheckBoxIDs2", String.Concat("'", cb.ClientID, "'"))
        Next

        If Me.GridView2.Rows.Count <> 0 Then
            Me.CheckAllProjectManager.Visible = True
            Me.UnCheckAllProjectMananger.Visible = True
        Else
            Me.CheckAllProjectManager.Visible = False
            Me.UnCheckAllProjectMananger.Visible = False
        End If
        TotalTime1 = 0
        BillableTime1 = 0
        NonBillableTime1 = 0
        Percentage1 = 0
        Hours1 = 0
        NonBillableHours1 = 0
        BillableHours1 = 0
        DTotalTime1 = 0
        DBillableTime1 = 0
        DNonBillableTime1 = 0
    End Sub

    Protected Sub GridView3_DataBound(ByVal sender As Object, ByVal e As System.EventArgs)
        'On every page visit we need to build up the CheckBoxIDs array
        For Each gvr As GridViewRow In GridView3.Rows
            'Get a programmatic reference to the CheckBox control
            Dim cb As CheckBox = CType(gvr.FindControl("chkSpecificEmployee"), CheckBox)

            Me.Page.ClientScript.RegisterArrayDeclaration("CheckBoxIDs3", String.Concat("'", cb.ClientID, "'"))
        Next

        If Me.GridView3.Rows.Count <> 0 Then
            Me.CheckAllSpecificEmployee.Visible = True
            Me.UnCheckAllSpecificEmployee.Visible = True
        Else
            Me.CheckAllSpecificEmployee.Visible = False
            Me.UnCheckAllSpecificEmployee.Visible = False
        End If
        TotalTime2 = 0
        BillableTime2 = 0
        NonBillableTime2 = 0
        Percentage2 = 0
        Hours2 = 0
        NonBillableHours2 = 0
        BillableHours2 = 0
        DTotalTime2 = 0
        DBillableTime2 = 0
        DNonBillableTime2 = 0
    End Sub

    Protected Sub GridView4_DataBound(ByVal sender As Object, ByVal e As System.EventArgs)
        'On every page visit we need to build up the CheckBoxIDs array
        For Each gvr As GridViewRow In GridView4.Rows
            'Get a programmatic reference to the CheckBox control
            Dim cb As CheckBox = CType(gvr.FindControl("chkSpecificExternalUser"), CheckBox)

            Me.Page.ClientScript.RegisterArrayDeclaration("CheckBoxIDs4", String.Concat("'", cb.ClientID, "'"))
        Next

        If Me.GridView4.Rows.Count <> 0 Then
            Me.CheckAllSpecificExternalUser.Visible = True
            Me.UnCheckAllSpecificExternalUser.Visible = True
        Else
            Me.CheckAllSpecificExternalUser.Visible = False
            Me.UnCheckAllSpecificExternalUser.Visible = False
        End If
        TotalTime3 = 0
        BillableTime3 = 0
        NonBillableTime3 = 0
        Percentage3 = 0
        Hours3 = 0
        NonBillableHours3 = 0
        BillableHours3 = 0
        DTotalTime3 = 0
        DBillableTime3 = 0
        DNonBillableTime3 = 0
    End Sub

    Protected Sub GridView5_DataBound(ByVal sender As Object, ByVal e As System.EventArgs)
        'On every page visit we need to build up the CheckBoxIDs array
        For Each gvr As GridViewRow In GridView5.Rows

            'Get a programmatic reference to the CheckBox control
            Dim cb As CheckBox = CType(gvr.FindControl("chkEmployeeManager"), CheckBox)

            Me.Page.ClientScript.RegisterArrayDeclaration("CheckBoxIDs5", String.Concat("'", cb.ClientID, "'"))
        Next

        If Me.GridView5.Rows.Count <> 0 Then
            Me.CheckAllEmployeeManager.Visible = True
            Me.UnCheckAllEmployeeManager.Visible = True
        Else
            Me.CheckAllEmployeeManager.Visible = False
            Me.UnCheckAllEmployeeManager.Visible = False
        End If
        TotalTime4 = 0
        BillableTime4 = 0
        NonBillableTime4 = 0
        Percentage4 = 0
        Hours4 = 0
        NonBillableHours4 = 0
        BillableHours4 = 0
        DTotalTime4 = 0
        DBillableTime4 = 0
        DNonBillableTime4 = 0
    End Sub
    Protected Sub GridView6_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then
            CType(e.Row.Cells(3).FindControl("lblTotalTime"), Label).Text = DBUtilities.GetDateTimeOfMinutesAsString(DataBinder.Eval(e.Row.DataItem, "TotalMinutes"))
            TotalTime5 += DataBinder.Eval(e.Row.DataItem, "TotalMinutes")
        End If
        If e.Row.RowType = DataControlRowType.Footer Then
            CType(e.Row.Cells(3).FindControl("lblSumTotalTime"), Label).Text = DBUtilities.GetDateTimeOfMinutesAsString(TotalTime5)
        End If
    End Sub

    Protected Sub GridView6_DataBound(ByVal sender As Object, ByVal e As System.EventArgs)
        'On every page visit we need to build up the CheckBoxIDs array
        For Each gvr As GridViewRow In GridView6.Rows
            'Get a programmatic reference to the CheckBox control
            Dim cb As CheckBox = CType(gvr.FindControl("chkSpecificEmployeeTimeOff"), CheckBox)

            Me.Page.ClientScript.RegisterArrayDeclaration("CheckBoxIDs6", String.Concat("'", cb.ClientID, "'"))
        Next

        If Me.GridView6.Rows.Count <> 0 Then
            Me.CheckAllSpecificEmployeeForTimeOff.Visible = True
            Me.UnCheckAllSpecificEmployeeForTimeOff.Visible = True
        Else
            Me.CheckAllSpecificEmployeeForTimeOff.Visible = False
            Me.UnCheckAllSpecificEmployeeForTimeOff.Visible = False
        End If
        TotalTime5 = 0
    End Sub

    Protected Sub GridView7_DataBound(ByVal sender As Object, ByVal e As System.EventArgs)
        'On every page visit we need to build up the CheckBoxIDs array
        For Each gvr As GridViewRow In GridView7.Rows
            'Get a programmatic reference to the CheckBox control
            Dim cb As CheckBox = CType(gvr.FindControl("chkEmployeeManagerTimeOff"), CheckBox)

            Me.Page.ClientScript.RegisterArrayDeclaration("CheckBoxIDs7", String.Concat("'", cb.ClientID, "'"))
        Next

        If Me.GridView7.Rows.Count <> 0 Then
            Me.CheckAllEmployeeManagerForTimeOff.Visible = True
            Me.UnCheckAllEmployeeManagerForTimeOff.Visible = True
        Else
            Me.CheckAllEmployeeManagerForTimeOff.Visible = False
            Me.UnCheckAllEmployeeManagerForTimeOff.Visible = False
        End If
        TotalTime6 = 0
    End Sub

    Protected Sub GridView7_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then
            CType(e.Row.Cells(4).FindControl("lblTotalTime"), Label).Text = DBUtilities.GetDateTimeOfMinutesAsString(DataBinder.Eval(e.Row.DataItem, "TotalMinutes"))
            TotalTime6 += DataBinder.Eval(e.Row.DataItem, "TotalMinutes")
            Dim TimeEntryBLL = New AccountEmployeeTimeEntryBLL
            CType(e.Row.Cells(3).FindControl("ProjectNameTxt"), Label).Text = TimeEntryBLL.GetProjectNameByTimeEntryId(DataBinder.Eval(e.Row.DataItem, "AccountEmployeeTimeEntryId"))

            SetupRowAttachmentLink(e.Row, DataBinder.Eval(e.Row.DataItem, "AccountEmployeeTimeEntryId"))
        End If

        If e.Row.RowType = DataControlRowType.Footer Then
            CType(e.Row.Cells(4).FindControl("lblSumTotalTime"), Label).Text = DBUtilities.GetDateTimeOfMinutesAsString(TotalTime6)
        End If
    End Sub

    Private Sub SetupRowAttachmentLink(row As GridViewRow, ByVal TimeEntryId As Integer)

        Dim hyperlinkControl = CType(row.Cells(4).FindControl("ATLink"), HyperLink)

        Dim TimeOffAttachmentsBLL = New TimeOffAttachmentsBLL

        Dim attachments = TimeOffAttachmentsBLL.GetTimeOffAttachmentsByTimeEntryId(TimeEntryId)
        If attachments.Count > 0 Then
            hyperlinkControl.Visible = True
            hyperlinkControl.Text = attachments.Count
            hyperlinkControl.NavigateUrl = "~/Employee/TimeOffAttachments.aspx?ReadOnly=true&" & "TimeEntry=" & TimeEntryId
            Dim att = attachments(0)
            'If Not att.TimeOffAttachmentId = 0 Then
            'If UIUtilities.IsFileAnImage(att.AttachmentLocalPath) Then
            'CType(row.FindControl("imgTooltip"), System.Web.UI.WebControls.Image).ImageUrl = "~/Shared/FileDownload.aspx?" & LicensingBLL.GetEncryptedStringAsBase64ByUTF8("FileName=" & DBUtilities.GetSessionAccountId & "/TimeOffAttachments/" & att.TimeEntryId & "/" & att.AttachmentLocalPath)
            'hyperlinkControl.CssClass = "tooltip"
            'hyperlinkControl.Attributes("data-tooltip-content") = "#" + CType(row.FindControl("tooltipContent"), Label).ClientID
            'End If
            'End If

        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        SortGridViews()

        If LocaleUtilitiesBLL.ShowPercentageInTimesheet = True And DBUtilities.IsTimeEntryHoursFormat = "Time" Then
            Me.GridView1.Columns(5).Visible = True
            Me.GridView2.Columns(5).Visible = True
            Me.GridView3.Columns(5).Visible = True
            Me.GridView4.Columns(5).Visible = True
            Me.GridView5.Columns(5).Visible = True
        ElseIf LocaleUtilitiesBLL.ShowPercentageInTimesheet = True And DBUtilities.IsTimeEntryHoursFormat = "Decimal" Then
            Me.GridView1.Columns(5).Visible = True
            Me.GridView2.Columns(5).Visible = True
            Me.GridView3.Columns(5).Visible = True
            Me.GridView4.Columns(5).Visible = True
            Me.GridView5.Columns(5).Visible = True
        End If
        If LocaleUtilitiesBLL.ShowPercentageInTimesheet = True And DBUtilities.IsTimeEntryHoursFormat = "None" Then
            Me.GridView1.Columns(2).Visible = False
            Me.GridView1.Columns(3).Visible = False
            Me.GridView1.Columns(4).Visible = False
            Me.GridView1.Columns(5).Visible = True

            Me.GridView2.Columns(2).Visible = False
            Me.GridView2.Columns(3).Visible = False
            Me.GridView2.Columns(4).Visible = False
            Me.GridView2.Columns(5).Visible = True

            Me.GridView3.Columns(2).Visible = False
            Me.GridView3.Columns(3).Visible = False
            Me.GridView3.Columns(4).Visible = False
            Me.GridView3.Columns(5).Visible = True

            Me.GridView4.Columns(2).Visible = False
            Me.GridView4.Columns(3).Visible = False
            Me.GridView4.Columns(4).Visible = False
            Me.GridView4.Columns(5).Visible = True

            Me.GridView5.Columns(2).Visible = False
            Me.GridView5.Columns(3).Visible = False
            Me.GridView5.Columns(4).Visible = False
            Me.GridView5.Columns(5).Visible = True
        End If
        If LocaleUtilitiesBLL.ShowPercentageInTimesheet = False And DBUtilities.IsTimeEntryHoursFormat = "None" Then
            Me.GridView1.Columns(2).Visible = True
            Me.GridView1.Columns(3).Visible = True
            Me.GridView1.Columns(4).Visible = True

            Me.GridView2.Columns(2).Visible = True
            Me.GridView2.Columns(3).Visible = True
            Me.GridView2.Columns(4).Visible = True

            Me.GridView3.Columns(2).Visible = True
            Me.GridView3.Columns(3).Visible = True
            Me.GridView3.Columns(4).Visible = True

            Me.GridView4.Columns(2).Visible = True
            Me.GridView4.Columns(3).Visible = True
            Me.GridView4.Columns(4).Visible = True

            Me.GridView5.Columns(2).Visible = True
            Me.GridView5.Columns(3).Visible = True
            Me.GridView5.Columns(4).Visible = True
        End If
        If LocaleUtilitiesBLL.ShowPercentageInTimesheet = False And DBUtilities.IsTimeEntryHoursFormat = "Decimal" Then
            Me.GridView1.Columns(2).Visible = True
            Me.GridView1.Columns(3).Visible = True
            Me.GridView1.Columns(4).Visible = True

            Me.GridView2.Columns(2).Visible = True
            Me.GridView2.Columns(3).Visible = True
            Me.GridView2.Columns(4).Visible = True

            Me.GridView3.Columns(2).Visible = True
            Me.GridView3.Columns(3).Visible = True
            Me.GridView3.Columns(4).Visible = True

            Me.GridView4.Columns(2).Visible = True
            Me.GridView4.Columns(3).Visible = True
            Me.GridView4.Columns(4).Visible = True

            Me.GridView5.Columns(2).Visible = True
            Me.GridView5.Columns(3).Visible = True
            Me.GridView5.Columns(4).Visible = True
        End If
        Literal6.Text = ResourceHelper.GetFromResource("Check-All Approved")
        Literal7.Text = ResourceHelper.GetFromResource("Uncheck-All Approved")
        Literal8.Text = ResourceHelper.GetFromResource("Check-All Approved")
        Literal9.Text = ResourceHelper.GetFromResource("Uncheck-All Approved")
        Literal10.Text = ResourceHelper.GetFromResource("Check-All Approved")
        Literal11.Text = ResourceHelper.GetFromResource("Uncheck-All Approved")
        Literal12.Text = ResourceHelper.GetFromResource("Check-All Approved")
        Literal13.Text = ResourceHelper.GetFromResource("Uncheck-All Approved")
        Literal14.Text = ResourceHelper.GetFromResource("Check-All Approved")
        Literal15.Text = ResourceHelper.GetFromResource("Uncheck-All Approved")
        Literal85.Text = ResourceHelper.GetFromResource("Check-All Approved")
        Literal37.Text = ResourceHelper.GetFromResource("Uncheck-All Approved")
    End Sub

    Protected Sub CheckAllEmployeeManager_Click(sender As Object, e As System.EventArgs) Handles CheckAllEmployeeManager.Click
        System.Web.HttpContext.Current.Session.Add("IsCheckAll", "1")
    End Sub

    Protected Sub CheckAllEmployeeManagerForTimeOff_Click(sender As Object, e As System.EventArgs) Handles CheckAllEmployeeManagerForTimeOff.Click
        System.Web.HttpContext.Current.Session.Add("IsCheckAll", "1")
    End Sub

    Protected Sub CheckAllProjectManager_Click(sender As Object, e As System.EventArgs) Handles CheckAllProjectManager.Click
        System.Web.HttpContext.Current.Session.Add("IsCheckAll", "1")
    End Sub

    Protected Sub CheckAllSpecificEmployee_Click(sender As Object, e As System.EventArgs) Handles CheckAllSpecificEmployee.Click
        System.Web.HttpContext.Current.Session.Add("IsCheckAll", "1")
    End Sub

    Protected Sub CheckAllSpecificEmployeeForTimeOff_Click(sender As Object, e As System.EventArgs) Handles CheckAllSpecificEmployeeForTimeOff.Click
        System.Web.HttpContext.Current.Session.Add("IsCheckAll", "1")
    End Sub

    Protected Sub CheckAllSpecificExternalUser_Click(sender As Object, e As System.EventArgs) Handles CheckAllSpecificExternalUser.Click
        System.Web.HttpContext.Current.Session.Add("IsCheckAll", "1")
    End Sub

    Protected Sub CheckAllTeamLead_Click(sender As Object, e As System.EventArgs) Handles CheckAllTeamLead.Click
        System.Web.HttpContext.Current.Session.Add("IsCheckAll", "1")
    End Sub

    Protected Sub UnCheckAllEmployeeManager_Click(sender As Object, e As System.EventArgs) Handles UnCheckAllEmployeeManager.Click
        System.Web.HttpContext.Current.Session.Add("IsUnCheckAll", "1")
    End Sub

    Protected Sub UnCheckAllEmployeeManagerForTimeOff_Click(sender As Object, e As System.EventArgs) Handles UnCheckAllEmployeeManagerForTimeOff.Click
        System.Web.HttpContext.Current.Session.Add("IsUnCheckAll", "1")
    End Sub

    Protected Sub UnCheckAllProjectMananger_Click(sender As Object, e As System.EventArgs) Handles UnCheckAllProjectMananger.Click
        System.Web.HttpContext.Current.Session.Add("IsUnCheckAll", "1")
    End Sub

    Protected Sub UnCheckAllSpecificEmployee_Click(sender As Object, e As System.EventArgs) Handles UnCheckAllSpecificEmployee.Click
        System.Web.HttpContext.Current.Session.Add("IsUnCheckAll", "1")
    End Sub

    Protected Sub UnCheckAllSpecificEmployeeForTimeOff_Click(sender As Object, e As System.EventArgs) Handles UnCheckAllSpecificEmployeeForTimeOff.Click
        System.Web.HttpContext.Current.Session.Add("IsUnCheckAll", "1")
    End Sub

    Protected Sub UnCheckAllSpecificExternalUser_Click(sender As Object, e As System.EventArgs) Handles UnCheckAllSpecificExternalUser.Click
        System.Web.HttpContext.Current.Session.Add("IsUnCheckAll", "1")
    End Sub

    Protected Sub UnCheckAllTeamLead_Click(sender As Object, e As System.EventArgs) Handles UnCheckAllTeamLead.Click
        System.Web.HttpContext.Current.Session.Add("IsUnCheckAll", "1")
    End Sub

    Private Sub SortGridViews()
        SortGridViewByEmployeeName(Me.GridView1)
        SortGridViewByEmployeeName(Me.GridView2)
        SortGridViewByEmployeeName(Me.GridView3)
        SortGridViewByEmployeeName(Me.GridView4)
        SortGridViewByEmployeeName(Me.GridView5)
    End Sub

    Private Sub SortGridViewByEmployeeName(ByVal gridView As GridView)
        If String.IsNullOrEmpty(gridView.SortExpression) Then
            gridView.Sort("EmployeeName ASC,TimeEntryStartDate", System.Web.UI.WebControls.SortDirection.Ascending)
        End If
    End Sub
End Class
