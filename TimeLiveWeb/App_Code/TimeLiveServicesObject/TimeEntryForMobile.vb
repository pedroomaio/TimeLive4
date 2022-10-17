Imports Microsoft.VisualBasic

Public Class TimeEntryForMobile
    Public AccountEmployeeTimeEntryID As Integer
    Public AccountProjectID As Integer
    Public AccountProjectTaskID As Integer
    Public ProjectName As String
    Public TaskName As String
    Public Description As String = ""
    Public StartTime As String
    Public EndTime As String
    Public TotalHours As String
    Public ShowClientInTimesheet As Boolean
    Public ShowWorkTypeInTimeSheet As Boolean
    Public ShowCostCenterInTimeSheet As Boolean
    Public ShowClockStartEnd As Boolean
    Public AccountClientId As Integer
    Public ClientName As String
    Public WorkTypeName As String
    Public AccountWorkTypeID As Integer

End Class
