Partial Class MasterPageEmployee
    Inherits System.Web.UI.MasterPage
    Public Sub SetFilterFromMasterPage()
        Master.SetFilters()
    End Sub
    Public Sub HideFilterFromMasterPage()
        Master.HideFilters()
    End Sub
End Class

