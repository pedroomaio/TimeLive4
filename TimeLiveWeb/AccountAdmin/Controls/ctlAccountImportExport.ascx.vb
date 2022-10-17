Partial Class AccountAdmin_Controls_ctlAccountImportExport
    Inherits System.Web.UI.UserControl

    Dim objDataTable As DataTable
    Dim objImportDataTable As DataTable

    Public IsImport As Boolean
    Dim tempFile As String
    'Dim StartDate As DateTime = Me.StartTimeTextBox.PostedDate
    'Dim EndDate As DateTime = Me.EndDateTextBox.PostedDate

    Protected Sub radImport_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles radImport.CheckedChanged
        IsImport = True
        Me.ProcessImportExport()
        Me.GridView1.Visible = False
        Me.lblException.Visible = True
        Me.lblException.Text = ""
        'Me.lblRowsInserted.Visible = False
    End Sub
    Public Sub ProcessImportExport()
        If radImport.Checked = True And radIIF.Checked = True Then
            Me.ddlDataSource.DataSource = New ImportExportBLL().GetAllImportableQuickbookDatasource
            Me.ddlDataSource.DataValueField = "DataName"
            Me.ddlDataSource.DataTextField = "DataName"
            Me.DropDownList1.Visible = False
            Me.ddlDataSource.DataBind()
        ElseIf radExport.Checked = True And radIIF.Checked = True Then
            Me.ddlDataSource.DataSource = New ImportExportBLL().GetAllExportableQuickbookDatasource
            Me.ddlDataSource.DataValueField = "DataName"
            Me.ddlDataSource.DataTextField = "DataName"
            Me.DropDownList1.Visible = False
            Me.ddlDataSource.DataBind()
        ElseIf radImport.Checked = True And radMicrosoftProject.Checked = True Then
            Me.ddlDataSource.DataSource = New ImportExportBLL().GetAllMicrosoftProjectDatasource
            Me.ddlDataSource.DataValueField = "DataName"
            Me.ddlDataSource.DataTextField = "DataName"
            Me.DropDownList1.Visible = False
            Me.ddlDataSource.DataBind()
        ElseIf radExport.Checked = True And radMicrosoftProject.Checked = True Then
            Me.DropDownList1.Visible = True
            Me.ddlDataSource.DataSource = New ImportExportBLL().GetAllExportableMProjectDatasource
            Me.ddlDataSource.DataValueField = "DataName"
            Me.ddlDataSource.DataTextField = "DataName"
            Me.ddlDataSource.DataBind()
        Else
            Me.ddlDataSource.DataSource = New ImportExportBLL().GetAllExportableDatasource()
            Me.ddlDataSource.DataValueField = "DataName"
            Me.ddlDataSource.DataTextField = "DataName"
            Me.ddlDataSource.DataBind()
        End If

    End Sub
    Protected Sub radExport_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles radExport.CheckedChanged
        Me.ProcessImportExport()
        Me.GridView1.Visible = False
        Me.lblException.Visible = True
        Me.lblException.Text = ""
        'Me.lblRowsInserted.Visible = False
    End Sub
    Protected Sub cmdProceed_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdProceed.Click
        Dim bll As New ImportExportBLL

        If Me.radImport.Checked And Me.txtFileUpload.HasFile Then
            Dim tempFile As String = bll.UploadFile(Me.txtFileUpload, Me.GetImportExportType)
            Me.ViewState("ImportTempFile") = tempFile
            IsImport = True

            If Me.GetImportExportType = "Quickbooks" Then
                Me.DoImport(tempFile)
            ElseIf Me.GetImportExportType = "MProject" Then
                Me.ReadAndFillColumnsMappingMProject(GetImportExportType, tempFile)
            Else
                Me.ReadAndFillColumnsMapping(GetImportExportType, tempFile)
            End If
        ElseIf Me.radExport.Checked Then
            IsImport = False
            Dim objImportExportBLL As New ImportExportBLL
            tempFile = objImportExportBLL.GetTempFileForExport(Me.GetImportExportType, False)
            If Me.GetImportExportType = "MProject" Then
                Dim AccountProjectTaskId As Integer
                Dim MProjectExportBLL As New MProjectClass
                AccountProjectTaskId = MProjectExportBLL.ExportFileforMicrosoftProject(Me.DropDownList1.SelectedValue, tempFile)
                If AccountProjectTaskId <> 0 Then
                    Dim downloadFile As String = objImportExportBLL.GetDownloadLink(tempFile)
                    Dim i As String = LicensingBLL.GetEncryptedStringAsBase64ByUTF8("FileName=" & downloadFile)
                    Response.Redirect("~/Shared/FileDownload.aspx?" & i, False)
                Else
                    Me.DropDownList1.Visible = True
                End If
            Else
                objImportExportBLL.ExportCSV(Me.ddlDataSource.SelectedValue, tempFile, Me.GetImportExportType, IIf(Me.StartTimeTextBox.PostedDate Is Nothing, Now, Me.StartTimeTextBox.PostedDate), IIf(Me.EndDateTextBox.PostedDate Is Nothing, Now, Me.EndDateTextBox.PostedDate), Me.ddlAccountEmployeeId.SelectedValue, Me.ddlAccountProjectId.SelectedValue, Me.GetWhereClause)
                Dim downloadFile As String = objImportExportBLL.GetDownloadLink(tempFile)
                Dim i As String = LicensingBLL.GetEncryptedStringAsBase64ByUTF8("FileName=" & downloadFile)
                Response.Redirect("~/Shared/FileDownload.aspx?" & i, False)
            End If
        End If
        Me.lblException.Visible = False
        Me.lblException.Text = ""
        'Me.lblRowsInserted.Visible = False
    End Sub
    Public Function GetImportExportType() As String
        If Me.radIIF.Checked Then
            Return "Quickbooks"
        ElseIf Me.radMicrosoftProject.Checked Then
            Return "MProject"
        Else
            Return "Delimited"
        End If
    End Function
    Public Sub ReadAndFillColumnsMapping(ByVal ExportType As String, ByVal tempFile As String)
        Dim objImportExportBLL As New ImportExportBLL
        objImportDataTable = objImportExportBLL.GetAllColumnMappingDataTableOfCSV(tempFile, ExportType)
        Me.cmdImport.Text = "Import Data"
        Me.cmdImport.Visible = True
        If Me.chkUpdate.Checked = True Then
            objDataTable = objImportExportBLL.GetAllColumnsOfDBForMapping(Me.ddlDataSource.SelectedValue, True)
        Else
            objDataTable = objImportExportBLL.GetAllColumnsOfDBForMapping(Me.ddlDataSource.SelectedValue, False)
        End If
        Me.GridView1.DataSource = objDataTable
        Me.GridView1.DataBind()
    End Sub
    Public Sub ReadAndFillColumnsMappingMProject(ByVal ExportType As String, ByVal tempFile As String)

        Dim objImportExportBLL As New ImportExportBLL
        objImportDataTable = objImportExportBLL.GetAllColumnMappingDataTableOfMProject(tempFile, ExportType)
        'Me.cmdImport.Text = "Import Data"
        Me.cmdImport.Visible = True

        'CType(Me.GridView1.FindControl("ddlFileColumnName"), DropDownList).DataSource = New ImportExportBLL().GetAllColumnMappingDataTableOfCSV("d:\test.csv")
        'objDataTable = objImportExportBLL.GetAllColumnsOfMProjectForMapping(Me.ddlDataSource.SelectedValue)
        'Me.GridView1.DataSource = objDataTable
        'Me.GridView1.DataBind()
        Me.GridView1.Visible = False
        Me.cmdImport.Visible = False
        lblRowsInserted.Visible = True
        lblRowsInserted.Text = " record successfully imported"
    End Sub
    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim objDropdown As DropDownList = CType(e.Row.FindControl("ddlFileColumnName"), DropDownList)
            objDropdown.DataTextField = "FileColumnName"
            objDropdown.DataValueField = "FileColumnName"
            'objDropdown.SelectedItem =
            objDropdown.DataSource = objImportDataTable
            objDropdown.DataBind()
            Me.SetSelectedValueIfExist(objDropdown, e.Row.Cells(1).Text)
        End If
    End Sub
    Public Sub SetSelectedValueIfExist(ByVal objDropdown As DropDownList, ByVal Value As String)
        For Each objDropdownValue As ListItem In objDropdown.Items
            If objDropdownValue.Text = Value Then
                objDropdown.SelectedValue = Value
                Return
            End If
        Next
    End Sub
    Dim IsUpdate As Boolean
    Public Function DoDelimiatedImport()
        Dim bll As New ImportExportBLL
        Dim dtCSVFile As DataTable = New ImportExportBLL().GetDataTableOfCSV(Me.ViewState("ImportTempFile"), Me.GetImportExportType)

        Dim Count As Integer

        Dim dtMappings As DataTable = bll.GetMappingCollectionForCSV(Me.GridView1, ddlDataSource.Text)
        If chkUpdate.Checked = True Then
            IsUpdate = True
            Count = bll.InsertRecords(dtMappings, Me.ddlDataSource.Text, Me.ViewState("ImportTempFile"), Me.GetImportExportType, Nothing, Nothing, True)
        Else
            Count = bll.InsertRecords(dtMappings, Me.ddlDataSource.Text, Me.ViewState("ImportTempFile"), Me.GetImportExportType, Nothing, Nothing, False)
        End If
        Me.IsImport = False
        Me.GridView1.DataSource = Nothing
        Me.GridView1.DataBind()
        Me.cmdImport.Visible = False
        Me.radImport.Checked = False
        Me.radExport.Checked = True
        Me.chkUpdate.Checked = False
        Return Count
    End Function
    Public Function DoQBImport(ByVal tempFile As String) As Integer
        Dim bll As New ImportExportBLL
        bll.PrepareFileForQuickbooks(tempFile, Me.ddlDataSource.Text)
        Dim dtMappings As DataTable = bll.GetQBMappedRecords(Me.ddlDataSource.Text)
        bll.InsertRecords(dtMappings, Me.ddlDataSource.Text, tempFile, "Quickbooks", True)
        Return bll.InsertRecords(dtMappings, Me.ddlDataSource.Text, tempFile, "Quickbooks", False)
    End Function
    Public Function DoMPImport(ByVal tempFile As String) As Integer
        Dim bll As New ImportExportBLL
        bll.PrepareFileForMProject(tempFile, Me.ddlDataSource.Text)
        Dim dtMappings As DataTable = bll.GetQBMappedRecords(Me.ddlDataSource.Text)
        bll.InsertRecords(dtMappings, Me.ddlDataSource.Text, tempFile, "MProject", True)
        Return bll.InsertRecords(dtMappings, Me.ddlDataSource.Text, tempFile, "MProject", False)
    End Function
    Public Sub DoImport(ByVal tempFile As String)
        Dim RecordCount As Integer
        Dim chk As Integer = 0
        Try
            If Me.GetImportExportType = "Quickbooks" Then
                RecordCount = Me.DoQBImport(tempFile)
            ElseIf Me.GetImportExportType = "MProject" Then
                RecordCount = Me.DoMPImport(tempFile)
            Else
                RecordCount = Me.DoDelimiatedImport()
            End If

        Catch ex As Exception

            lblException.Visible = True
            If Not ex.InnerException Is Nothing Then
                lblException.Text = ex.InnerException.Message
            Else
                lblException.Text = ex.Message
            End If
            Me.GridView1.Visible = False
            cmdImport.Visible = False
            chk = 1
        End Try
        If chk = 0 Then
            lblRowsInserted.Visible = True
            If IsUpdate = True Then
                lblRowsInserted.Text = RecordCount & " record successfully Updated"
            Else
                lblRowsInserted.Text = RecordCount & " record successfully imported"
            End If

            Me.GridView1.Visible = False
            cmdImport.Visible = False
        End If
    End Sub
    Protected Sub cmdImport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdImport.Click
        Me.DoImport(Me.ViewState("ImportTempFile"))
    End Sub
    Public Sub ShowExceptionAndMessage(ByVal ex As Exception)

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AccountPagePermissionBLL.SetPagePermissionForGridView(119, Me.GridView1, 0, 0)
        If Not IsPostBack Then
            Me.IsImport = False
            Me.lblException.Visible = True
            Me.rdBoth.Checked = True
            Me.radExport.Checked = True
            Me.radDelimited.Checked = True
            Me.rdApprovedBoth.Checked = True
            Me.ProcessImportExport()
            'lblRowsInserted.Visible = False
        Else
            lblRowsInserted.Visible = False
            If Me.radImport.Checked And Me.radDelimited.Checked Then
                If ddlDataSource.Text = "Employee" Or ddlDataSource.Text = "Client" Then
                    Me.chkUpdate.Visible = True
                    Me.lblchkUpdate.Visible = True
                Else
                    Me.chkUpdate.Visible = False
                    Me.lblchkUpdate.Visible = False
                    Me.chkUpdate.Checked = False
                End If
            Else
                Me.chkUpdate.Visible = False
                Me.lblchkUpdate.Visible = False
                Me.chkUpdate.Checked = False
            End If
        End If
        
        Me.DropDownList1.Visible = False
        Me.Literal9.Text = ResourceHelper.GetFromResource("CSV Import Export")
        Me.Literal1.Text = ResourceHelper.GetFromResource("Import / Export:")
        Me.Literal8.Text = ResourceHelper.GetFromResource("File Type:")
        Me.Literal2.Text = ResourceHelper.GetFromResource("Data Source:")
        Me.Literal3.Text = ResourceHelper.GetFromResource("Start Date:")
        Me.Literal4.Text = ResourceHelper.GetFromResource("End Date:")
        Me.Literal5.Text = ResourceHelper.GetFromResource("Employee:")
        Me.Literal7.Text = ResourceHelper.GetFromResource("Project:")
        Me.Literal6.Text = ResourceHelper.GetFromResource("Upload File:")
        Me.Literal10.Text = ResourceHelper.GetFromResource("Billing Type:")
        Me.lblchkUpdate.Text = ResourceHelper.GetFromResource("For Update:")
    End Sub
    Protected Sub ddlDataSource_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlDataSource.SelectedIndexChanged
        Me.GridView1.Visible = False
        Me.lblException.Visible = True
        Me.rdBoth.Checked = True
        Me.rdApprovedBoth.Checked = True
        'Me.lblRowsInserted.Visible = False
    End Sub
    Protected Sub radDelimited_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles radDelimited.CheckedChanged
        Me.ProcessImportExport()
    End Sub
    Protected Sub radIIF_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles radIIF.CheckedChanged
        Me.ProcessImportExport()
    End Sub
    Public Function GetWhereClause() As String
        If ddlDataSource.Text = "Time Entry" Then
            Dim sql As String = ""
            Dim StartDate As String = IIf(Me.StartTimeTextBox.PostedDate Is Nothing, Now, Me.StartTimeTextBox.PostedDate)
            Dim EndDate As String = IIf(Me.EndDateTextBox.PostedDate Is Nothing, Now, Me.EndDateTextBox.PostedDate)

            sql = sql & "(TimeEntryDate >= " & LocaleUtilitiesBLL.ConvertDateBaseIntoSQLQurey(StartDate) & ") AND (TimeEntryDate <= " & LocaleUtilitiesBLL.ConvertDateBaseIntoSQLQurey(EndDate) & ") "

            If ddlAccountProjectId.SelectedValue <> -1 Then
                sql = sql + " And AccountProjectId = " & ddlAccountProjectId.SelectedValue
            End If

            If ddlAccountEmployeeId.SelectedValue <> -1 Then
                sql = sql + " And AccountEmployeeId = " & ddlAccountEmployeeId.SelectedValue
            End If

            If ddlAccountLocationId.SelectedValue <> -1 Then
                sql = sql + " And AccountLocationId = " & ddlAccountLocationId.SelectedValue
            End If

            sql = sql + GetBillableType()

            sql = sql + GetApprovedStatus()

            sql = sql & " And AccountId = " & DBUtilities.GetSessionAccountId
            Return sql
        End If

        Return ""
    End Function
    Public Function GetBillableType() As String
        If Me.rdBoth.Checked = True Then
            Return " And (IsBillable = IsBillable) "
        ElseIf Me.rdBillable.Checked = True Then
            Return " And (IsBillable = 1) "
        ElseIf Me.rdNonBillable.Checked = True Then
            Return " And (IsBillable <> 1 or IsBillable is null) "
        End If
        Return ""
    End Function
    Public Function GetApprovedStatus() As String
        If Me.rdApprovedBoth.Checked = True Then
            Return " And (Approved = Approved) "
        ElseIf Me.rdApproved.Checked = True Then
            Return " And (Approved = 1) "
        ElseIf Me.rdNotApproved.Checked = True Then
            Return " And (Approved <> 1 or Approved is null) "
        End If
        Return ""
    End Function
    Protected Sub radMicrosoftProject_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles radMicrosoftProject.CheckedChanged
        Me.ProcessImportExport()
    End Sub
    Public Sub DoImportMProject(ByVal tempFile As String)
        Dim RecordCount As Integer
        Dim chk As Integer = 0
        Try
            If Me.GetImportExportType = "MProject" Then
                RecordCount = Me.DoQBImport(tempFile)
            Else
                RecordCount = Me.DoDelimiatedImport()
            End If

        Catch ex As Exception

            lblException.Visible = True
            If Not ex.InnerException Is Nothing Then
                lblException.Text = ex.InnerException.Message
            Else
                lblException.Text = ex.Message
            End If
            Me.GridView1.Visible = False
            cmdImport.Visible = False
            chk = 1
        End Try
        If chk = 0 Then
            lblRowsInserted.Visible = True
            lblRowsInserted.Text = RecordCount & " record successfully imported"
            Me.GridView1.Visible = False
            cmdImport.Visible = False
        End If
    End Sub
    Public Function DoQBImportMProject(ByVal tempFile As String) As Integer
        Dim bll As New ImportExportBLL
        bll.PrepareFileForQuickbooks(tempFile, Me.ddlDataSource.Text)
        Dim dtMappings As DataTable = bll.GetQBMappedRecords(Me.ddlDataSource.Text)
        bll.InsertRecords(dtMappings, Me.ddlDataSource.Text, tempFile, "MProject", True)
        Return bll.InsertRecords(dtMappings, Me.ddlDataSource.Text, tempFile, "MProject", False)
    End Function
    Public Function GetAllTasks()
        Dim dttaskName As TimeLiveDataSet.AccountProjectTaskDataTable = New AccountProjectTaskBLL().GetAccountProjectTasksByAccountProjectId(Me.DropDownList1.SelectedValue)
        Dim drtaskName As TimeLiveDataSet.AccountProjectTaskRow
        If dttaskName.Rows.Count > 0 Then
            drtaskName = dttaskName.Rows(0)
        End If
    End Function
    Protected Sub DropDownList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList1.SelectedIndexChanged
    End Sub
End Class
