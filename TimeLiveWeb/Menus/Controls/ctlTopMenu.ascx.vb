
Partial Class Menus_Controls_ctlTopMenu
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim MyArea As String = ResourceHelper.GetFromResource("My Area")
        MyArea = UCase(MyArea)
        Me.HyperLink1.Text = MyArea

        Dim Task As String = ResourceHelper.GetFromResource("Tasks")
        Task = UCase(Task)
        Me.HyperLink2.Text = Task

        Dim Project As String = ResourceHelper.GetFromResource("Projects")
        Project = UCase(Project)
        Me.HyperLink3.Text = Project


        Dim TimesheetDay As String = ResourceHelper.GetFromResource("Timesheet")
        TimesheetDay = UCase(TimesheetDay)
        Me.HyperLink4.Text = TimesheetDay


        Dim TimesheetWeek As String = ResourceHelper.GetFromResource("Timesheet")
        TimesheetWeek = UCase(TimesheetWeek)
        Me.HyperLink7.Text = TimesheetWeek

        Dim Expenses As String = ResourceHelper.GetFromResource("Expenses")
        Expenses = UCase(Expenses)
        Me.HyperLink5.Text = Expenses

        Dim Reports As String = ResourceHelper.GetFromResource("Reports")
        Reports = UCase(Reports)
        Me.HyperLink6.Text = Reports

    End Sub
End Class
