Imports System.Linq
Imports System.Web.Services


Partial Class Employee_Controls_ctlMyTimeOff
    Inherits System.Web.UI.UserControl

    Dim startYear As Integer = DateTime.Today.Year
    Dim AE As New AccountEmployeeTableAdapters.AccountEmployeeTableAdapter
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        VerifyQueryString()
        Dim EmployeeId = IIf(Me.Request.QueryString("AccountEmployee") IsNot Nothing, Me.Request.QueryString("AccountEmployee"), DBUtilities.GetSessionAccountEmployeeId)

        If Not Me.IsPostBack Then
            'AccountEmployeeBLL.SetDataForEmployeeDropdown(18, ddlEmployeeName)
            AccountEmployeeBLL.SetDataForEmployeeDropdown(142, ddlEmployeeName)
            ddlEmployeeName.SelectedValue = EmployeeId
        End If
        name_label.Text = AE.GetEmployeeManagerNameByAccountEmployeeId(EmployeeId)
    End Sub
    Private Sub VerifyQueryString()
        Dim success = True
        If Me.Request.QueryString("AccountEmployee") IsNot Nothing Then
            Try
                Integer.Parse(Me.Request.QueryString("AccountEmployee"))
                success = VerifyIfEmployeeWasPermissions()
            Catch ex As Exception
                success = False
            End Try
        End If

        If Not success Then
            Me.Response.Redirect("~/Employee/MyTimeOff.aspx")
        End If
    End Sub
    Private Function VerifyIfEmployeeWasPermissions() As Boolean

        Dim AccountEmployees = AccountEmployeeBLL.GetDataForEmployeeDropdown(142)

        For Each row In AccountEmployees
            If Me.Request.QueryString("AccountEmployee") = row.AccountEmployeeId Then
                Return True
                Exit For
            End If
        Next
        Return False
    End Function
    Public Function SetCalendarStartYear(year As Integer) As Boolean
        If year < startYear Then
            startYear = year
        End If
    End Function

    Public Function GetCalendarStartYear() As Integer
        Return DateTime.Today.Year - startYear
    End Function

    Protected Sub ddlEmployeeName_SelectedIndexChanged(sender As Object, e As EventArgs)
        Me.Response.Redirect("~/Employee/MyTimeOff.aspx?AccountEmployee=" & ddlEmployeeName.SelectedValue)
    End Sub


End Class