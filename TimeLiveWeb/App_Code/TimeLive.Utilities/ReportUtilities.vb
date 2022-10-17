Imports Microsoft.VisualBasic

Public Class ReportUtilities

    Public Sub SetReportStyleSheet(ByVal docReport As Object)
    End Sub
    Public Shared Sub SetDefaultValuesOfFilerItem(ByVal EmployeeDropdown As DropDownList, ByVal StartDateTextbox As eWorld.UI.CalendarPopup, ByVal EndDateTextBox As eWorld.UI.CalendarPopup, ByVal ApplyDateFilterCheckbox As CheckBox)

        EmployeeDropdown.SelectedValue = DBUtilities.GetSessionAccountEmployeeId
        StartDateTextbox.SelectedDate = Now.Date
        EndDateTextBox.SelectedDate = Now.Date
        ApplyDateFilterCheckbox.Checked = True

    End Sub
    Public Shared Sub SetDefaultValuesOfFilerItemForProjectSummaryReport(ByVal EmployeeDropdown As DropDownList, ByVal StartDateTextbox As eWorld.UI.CalendarPopup, ByVal EndDateTextBox As eWorld.UI.CalendarPopup)

        EmployeeDropdown.SelectedValue = DBUtilities.GetSessionAccountEmployeeId
        StartDateTextbox.SelectedDate = Now.Date
        EndDateTextBox.SelectedDate = Now.Date
        '        ApplyDateFilterCheckbox.Checked = True

    End Sub
    Public Shared Sub SetDefaultValuesOfFilerItemForAttendanceReport(ByVal EmployeeDropdown As DropDownList, ByVal StartDateTextbox As eWorld.UI.CalendarPopup, ByVal EndDateTextBox As eWorld.UI.CalendarPopup)

        EmployeeDropdown.SelectedValue = DBUtilities.GetSessionAccountEmployeeId
        StartDateTextbox.SelectedDate = Now.Date
        EndDateTextBox.SelectedDate = Now.Date
    End Sub
    Public Shared Sub SetDefaultValuesOfFilerItemBilling(ByVal StartDateTextbox As eWorld.UI.CalendarPopup, ByVal EndDateTextBox As eWorld.UI.CalendarPopup, ByVal IncludeDateRange As CheckBox)

        StartDateTextbox.SelectedDate = Now.Date
        EndDateTextBox.SelectedDate = Now.Date
        IncludeDateRange.Checked = True

    End Sub
End Class

