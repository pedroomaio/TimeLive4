
Partial Class AccountAdmin_TimeEntryArchive
    Inherits System.Web.UI.Page
    Protected Sub CtlTimeEntryArchive1_btnShowClick(sender As Object, e As System.EventArgs) Handles CtlTimeEntryArchive1.btnShowClick
        Master.SetFilterFromMasterPage()
    End Sub
End Class
