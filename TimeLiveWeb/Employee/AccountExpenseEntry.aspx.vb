
Partial Class Employee_AccountExpenseEntry
    Inherits System.Web.UI.Page
    Protected Sub CtlAccountExpenseSheetList1_btnShowClick(sender As Object, e As System.EventArgs) Handles CtlAccountExpenseSheetList1.btnShowClick
        Master.SetFilterFromMasterPage()
    End Sub
End Class
