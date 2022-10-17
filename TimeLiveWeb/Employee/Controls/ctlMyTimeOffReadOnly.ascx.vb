
Partial Class Employee_Controls_ctlMyTimeOffReadOnly
    Inherits System.Web.UI.UserControl
    Dim startYear As Integer = DateTime.Today.Year

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Dim AccountEmployeeId = Me.Request.QueryString("AccountEmployeeId")
        If AccountEmployeeId IsNot Nothing Then
            Dim AccountEmployeeBLL = New AccountEmployeeBLL
            Dim emp As AccountEmployee.AccountEmployeeRow
            Dim Employee = AccountEmployeeBLL.GetAccountEmployeesByAccountEmployeeId(AccountEmployeeId)
            If Employee.Count > 0 Then
                emp = Employee.Rows(0)
                If emp.EmployeeManagerId <> DBUtilities.GetSessionAccountEmployeeId And DBUtilities.GetSessionAccountEmployeeId <> AccountEmployeeId Then
                    CType(Me.FindControl("calendar"), Panel).Visible = False
                    CType(Me.FindControl("AuthorizationPanel"), Panel).Visible = True
                End If
            End If

        End If

    End Sub


    Public Sub SetCalendarStartYear(year As Integer)
        If year < startYear Then
            startYear = year
        End If
    End Sub

    Public Function GetCalendarStartYear() As Integer
        Return DateTime.Today.Year - startYear
    End Function

End Class
