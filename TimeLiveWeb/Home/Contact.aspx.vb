
Partial Class Home_Contact
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim meta As New HtmlMeta

        meta = New HtmlMeta
        meta.Name = "description"
        meta.Content = "Time and expense management, TimeLive - Web-based timesheet tool, online time tracking solution, Web timesheet, " & _
                        "On-Demand employee timesheet, Time and Billing, online timesheet and expense software, timesheet solution"

        Page.Header.Controls.Add(meta)
    End Sub
End Class
