
Partial Class Employee_AccountEmployeeTimeEntryPeriodView
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Page.ClientScript.RegisterClientScriptInclude("WeekView_js", "WeekView.js")
    End Sub
End Class