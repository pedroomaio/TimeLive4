Imports ReportFilterCascadingTableAdapters
Public Class ReportFilterCascadingBLL
    Private _AccountProjectTaskTableAdapter As New AccountProjectTaskTableAdapter

    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountProjectTasksByAccountProjectIdCascading(ByVal AccountProjectId As Integer) As ReportFilterCascading.AccountProjectTaskDataTable
        GetAccountProjectTasksByAccountProjectIdCascading = _AccountProjectTaskTableAdapter.GetDataByAccountProjectId(AccountProjectId)
        Return GetAccountProjectTasksByAccountProjectIdCascading
    End Function
End Class
