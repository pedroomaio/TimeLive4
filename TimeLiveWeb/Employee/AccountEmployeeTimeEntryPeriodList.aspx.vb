
Partial Class Employee_AccountEmployeeTimeEntryPeriodList
    Inherits System.Web.UI.Page
    Protected Sub CtlAccountEmployeeTimeEntryPeriodList1_btnShowClick(sender As Object, e As System.EventArgs) Handles CtlAccountEmployeeTimeEntryPeriodList1.btnShowClick
        Master.SetFilterFromMasterPage()
    End Sub
End Class
