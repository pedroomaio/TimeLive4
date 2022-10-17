Imports TimeLiveDataSetTableAdapters
<System.ComponentModel.DataObject()> _
Public Class EMailEngineBLL
    Private _SystemMasterEMailTemplateAdapter As SystemMasterEMailTemplateTableAdapter = Nothing
    Protected ReadOnly Property Adapter() As SystemMasterEMailTemplateTableAdapter
        Get
            If _SystemMasterEMailTemplateAdapter Is Nothing Then
                _SystemMasterEMailTemplateAdapter = New SystemMasterEMailTemplateTableAdapter()
            End If
            Return _SystemMasterEMailTemplateAdapter
        End Get
    End Property
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetMasterTemplates() As TimeLiveDataSet.SystemMasterEMailTemplateDataTable
        Return Adapter.GetData
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)> _
    Public Function UpdateEMailTemplate(ByVal TemplateName As String, ByVal TemplateDescription As String, ByVal TemplateContent As String, ByVal original_MasterEMailTemplateId As Integer) As Boolean

        Dim Templates As TimeLiveDataSet.SystemMasterEMailTemplateDataTable = Adapter.GetDataByMasterEMailTemplateId(original_MasterEMailTemplateId)
        Dim Template As TimeLiveDataSet.SystemMasterEMailTemplateRow = Templates.Rows(0)

        With Template
            .TemplateName = TemplateName
            .TemplateDescription = TemplateDescription
            .TemplateContent = TemplateContent
        End With


        Dim rowsAffected As Integer = Adapter.Update(Template)

        ' Return true if precisely one row was updated, otherwise false
        Return rowsAffected = 1

    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetMasterTemplatesByMasterEMailTemplateId(ByVal MasterEMailTemplateId As Integer) As TimeLiveDataSet.SystemMasterEMailTemplateDataTable
        Return Adapter.GetDataByMasterEMailTemplateId(MasterEMailTemplateId)
    End Function
    Public Function GetPageHTML(ByVal strPageName As String, ByVal args As String) As String
        'Dim stream As New System.IO.StreamWriter("c:\test.htm")
        Dim stream As New System.IO.StringWriter

        Dim wr As New System.Web.Hosting.SimpleWorkerRequest("Reports\HostedReports\" & strPageName, args, stream)
        HttpRuntime.ProcessRequest(wr)

        GetPageHTML = stream.ToString

        stream.Close()

        Return GetPageHTML
    End Function
    Public Function GetEMailBodyOfNewAccountSignup(ByVal AccountId As Integer) As String

        Dim objTemplate As TimeLiveDataSet.SystemMasterEMailTemplateRow

        objTemplate = Me.GetMasterTemplatesByMasterEMailTemplateId(1).Rows(0)

        Dim strBody As String
        strBody = Me.GetPageHTML("NewAccountSignup.aspx", "AccountId=" & AccountId)

        Dim strParsedBody As String

        strParsedBody = Replace(objTemplate.TemplateContent, "##Body##", strBody)


        Return strParsedBody

    End Function

    Public Function GetEMailBodyOfOutstandingTimeSheetReport(ByVal AccountEmployeeId As Integer) As String

        Dim objTemplate As TimeLiveDataSet.SystemMasterEMailTemplateRow

        objTemplate = Me.GetMasterTemplatesByMasterEMailTemplateId(1).Rows(0)

        Dim strBody As String
        strBody = Me.GetPageHTML("OutStandingTimeSheetReport.aspx", "AccountEmployeeId=" & AccountEmployeeId)

        Dim strParsedBody As String

        strParsedBody = Replace(objTemplate.TemplateContent, "##Body##", strBody)


        Return strParsedBody

    End Function


End Class




