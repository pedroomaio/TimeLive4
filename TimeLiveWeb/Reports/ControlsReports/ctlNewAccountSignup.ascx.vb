
Public Class Reports_ControlsReports_ctlNewAccountSignup
    Inherits System.Web.UI.UserControl

    Public dr As AccountEmployee.vueAccountEmployeeRow


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim dt As AccountEmployee.vueAccountEmployeeDataTable
        dt = New AccountEmployeeBLL().GetAccountEmployeesViewByAccountId(Request.QueryString("AccountId"))

        dr = dt.Rows(0)

    End Sub
End Class
