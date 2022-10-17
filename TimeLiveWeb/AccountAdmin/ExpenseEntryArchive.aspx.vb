
Partial Class AccountAdmin_ExpenseEntryArchive
    Inherits System.Web.UI.Page
    Protected Sub ctlExpenseEntryArchive1_btnShowClick(sender As Object, e As System.EventArgs) Handles ctlExpenseEntryArchive1.btnShowClick
        Master.SetFilterFromMasterPage()
    End Sub
End Class
