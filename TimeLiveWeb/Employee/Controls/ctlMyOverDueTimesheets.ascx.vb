
Partial Class Employee_Controls_ctlMyOverDueTimesheets
    Inherits System.Web.UI.UserControl
    Dim TimesheetPeriodDaysArray As ArrayList
    Dim TotalFields As Integer
    Dim dtcolumn As New TemplateField
    Public Sub SetColumn()
        DateTimeUtilities.SetDataInVariableForGetWorkingDays(DBUtilities.GetSessionAccountEmployeeId)
        TimesheetPeriodDaysArray = DateTimeUtilities.GetWorkingDaysPeriodStartDateAndPeriodEndDate(DBUtilities.GetSessionAccountEmployeeId, Now.Date, Now.Date, Now.Date)
        For n As Integer = 0 To TimesheetPeriodDaysArray.Count - 1
            Dim dtcolumn As New TemplateField
            dtcolumn.ItemTemplate = New ItemTemplate("OverdueColumn" & n, "")
            Me.G.Columns.Add(dtcolumn)
        Next
        Dim dtMinimumcolumn As New TemplateField
        dtMinimumcolumn.HeaderText = "Minimum Hours"
        dtMinimumcolumn.ItemTemplate = New ItemTemplate("MinimumHours", "")
        Me.G.Columns.Add(dtMinimumcolumn)

        Dim dtTotalHourscolumn As New TemplateField
        dtTotalHourscolumn.HeaderText = "Total Hours"
        dtTotalHourscolumn.ItemTemplate = New ItemTemplate("TotalHours", "")
        Me.G.Columns.Add(dtTotalHourscolumn)

        Dim dtStatuscolumn As New TemplateField
        dtStatuscolumn.HeaderText = "Timesheet Status"
        dtStatuscolumn.ItemTemplate = New ItemTemplate("TimesheetStatus", "")
        Me.G.Columns.Add(dtStatuscolumn)

        TotalFields = TimesheetPeriodDaysArray.Count
    End Sub

    Protected Sub Page_Init(sender As Object, e As System.EventArgs) Handles Me.Init
        SetColumn()
    End Sub

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub G_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles G.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            For n As Integer = 0 To TotalFields - 1
                If IsDBNull(DataBinder.Eval(e.Row.DataItem, "OverdueColumn" & n)) Then
                    Me.G.Columns(n).HeaderText = LocaleUtilitiesBLL.GetDayInCurrentLocale(TimesheetPeriodDaysArray(n))
                End If
                If Not e.Row.FindControl("OverdueColumn" & n) Is Nothing And Not IsDBNull(DataBinder.Eval(e.Row.DataItem, "OverdueColumn" & n)) Then
                    Dim Value As String() = Split(DataBinder.Eval(e.Row.DataItem, "OverdueColumn" & n), "+")
                    Me.G.Columns(n).HeaderText = Value(0)
                    CType(e.Row.FindControl("OverdueColumn" & n), Label).Text = Value(1)
                End If
            Next
            If Not IsDBNull(DataBinder.Eval(e.Row.DataItem, "MinimumHours")) Then
                CType(e.Row.FindControl("MinimumHours"), Label).Text = DataBinder.Eval(e.Row.DataItem, "MinimumHours")
            End If
            If Not IsDBNull(DataBinder.Eval(e.Row.DataItem, "TotalHours")) Then
                CType(e.Row.FindControl("TotalHours"), Label).Text = DataBinder.Eval(e.Row.DataItem, "TotalHours")
            End If
            If Not IsDBNull(DataBinder.Eval(e.Row.DataItem, "TimesheetStatus")) Then
                CType(e.Row.FindControl("TimesheetStatus"), Label).Text = DataBinder.Eval(e.Row.DataItem, "TimesheetStatus")
            End If
        End If
    End Sub
End Class
