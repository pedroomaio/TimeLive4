Imports Microsoft.VisualBasic
Imports FileHelpers
Imports System.Reflection
Imports System.IO

Public Class ImportExportBLL
    'Dim IsUpdate As Boolean = False
    Dim AccountProjectId As Integer
    Dim ProjectName As String
    Dim EmployeeName As String
    Dim RowsCountEqual As Boolean = False
    Dim AccountEmployeeId As Integer
    Public Sub GenerateCSV(ByVal dtable As DataTable, ByVal strFilePath As String)

        Dim objChar As New Char
        objChar = ","

        Dim foptions As New FileHelpers.CsvOptions("dummy", objChar, dtable.Columns.Count)
        foptions.HeaderLines = 1
        foptions.HeaderDelimiter = objChar

        FileHelpers.CommonEngine.DataTableToCsv(dtable, strFilePath, foptions)

    End Sub
    Public Sub ExportCSV(ByVal DataName As String, ByVal strFilePath As String, ByVal ExportType As String, ByVal StartDate As DateTime, ByVal EndDate As DateTime, ByVal AccountEmployeeId As Integer, ByVal AccountProjectId As Integer, ByVal WhereClause As String, Optional ByVal OfflineTimesheet As Boolean = False)

        Dim dTable As DataTable = Me.GetDataTableFromAdapterForExport(DataName, ExportType, StartDate, EndDate, AccountEmployeeId, AccountProjectId, WhereClause, OfflineTimesheet)

        Dim i As Integer
        If ExportType = "Quickbooks" Or OfflineTimesheet = True Then
            For i = 0 To dTable.Columns.Count - 1
                dTable.Columns(i).ColumnName = dTable.Columns(i).ColumnName
            Next
        Else
            For i = 0 To dTable.Columns.Count - 1
                dTable.Columns(i).ColumnName = ResourceHelper.GetFromResource(dTable.Columns(i).ColumnName)
            Next
        End If
        Dim objChar As New Char
        objChar = GetDelimiter(ExportType)

        Dim foptions As New FileHelpers.CsvOptions("dummy", objChar, dTable.Columns.Count)
        foptions.HeaderLines = 1
        foptions.HeaderDelimiter = objChar
        ' foptions.FieldsPrefix
        If ExportType <> "Quickbooks" Then
            foptions.Encoding = System.Text.UTF8Encoding.UTF8
        End If


        FileHelpers.CommonEngine.DataTableToCsv(dTable, strFilePath, foptions)

    End Sub
    Public Sub ExportMProject(ByVal DataName As String, ByVal strFilePath As String, ByVal ExportType As String, ByVal AccountProjectId As Integer, ByVal WhereClause As String)

        Dim dTable As DataTable = Me.GetDataTableFromMProjectAdapterForExport(DataName, ExportType, AccountProjectId, WhereClause)

        Dim objChar As New Char
        objChar = GetDelimiter(ExportType)

        Dim foptions As New FileHelpers.CsvOptions("dummy", objChar, dTable.Columns.Count)
        foptions.HeaderLines = 1
        foptions.HeaderDelimiter = objChar
        ' foptions.FieldsPrefix
        FileHelpers.CommonEngine.DataTableToCsv(dTable, strFilePath, foptions)

    End Sub
    Public Function GetDelimiter(ByVal ExportType As String) As Char
        If ExportType = "Quickbooks" Then
            Return ControlChars.Tab
        ElseIf ExportType = "MProject" Then
            Return ControlChars.Tab
        Else
            Return ","
        End If
    End Function
    Public Function GetExportExtension(ByVal ExportType As String, Optional ByVal IsImport As Boolean = True) As String
        If ExportType = "Quickbooks" Then
            Return ".iif"
        ElseIf ExportType = "MProject" And IsImport = True Then
            Return ".mpp"
        ElseIf ExportType = "MProject" And IsImport = False Then
            Return ".xml"
        Else
            Return ".csv"
        End If
    End Function
    Public Sub PrepareFileForQuickbooks(ByVal File As String, ByVal DataType As String)

        ' The actual file stream, remember it can be any location        
        Dim fileStream As System.IO.StreamReader = New System.IO.StreamReader(File)
        Dim FileContents As String = ""
        Dim lineString As String = ""
        Dim DataHeader As String = Me.GetQBRecordHeader(DataType)
        While (Not fileStream.EndOfStream)
            lineString = fileStream.ReadLine()
            If lineString.Contains(DataHeader & ControlChars.Tab) Then
                FileContents = FileContents & lineString & vbNewLine
            End If
        End While
        fileStream.Close()


        'get a StreamWriter for writing the new text to the file 
        Dim writer As New StreamWriter(File)

        'write the contents 
        writer.Write(FileContents)

        'close up and dispose 
        writer.Close()
        writer.Dispose()


    End Sub
    Public Sub PrepareFileForMProject(ByVal File As String, ByVal DataType As String)

        ' The actual file stream, remember it can be any location        
        Dim fileStream As System.IO.StreamReader = New System.IO.StreamReader(File)
        Dim FileContents As String = ""
        Dim lineString As String = ""
        Dim DataHeader As String = Me.GetQBRecordHeader(DataType)
        While (Not fileStream.EndOfStream)
            lineString = fileStream.ReadLine()
            If lineString.Contains(DataHeader & ControlChars.Tab) Then
                FileContents = FileContents & lineString & vbNewLine
            End If
        End While
        fileStream.Close()


        'get a StreamWriter for writing the new text to the file 
        Dim writer As New StreamWriter(File)

        'write the contents 
        writer.Write(FileContents)

        'close up and dispose 
        writer.Close()
        writer.Dispose()

    End Sub
    Public Function GetQBRecordHeader(ByVal DataType As String) As String
        If DataType = "Client" Then
            Return "CUST"
        ElseIf DataType = "Employee" Then
            Return "EMP"
        End If
    End Function
    Public Function GetTempFileForExport(ByVal ExportType As String, Optional ByVal IsImport As Boolean = True) As String
        Dim TempFolderPath As String = AccountProjectTaskAttachmentBLL.CreateTempFolderPath()
        Dim TempFile As String = System.Guid.NewGuid.ToString & Me.GetExportExtension(ExportType, IsImport)
        Return TempFolderPath & TempFile
    End Function
    Public Function GetTempFileForDatabaseBackup() As String
        Dim TempFolderPath As String = AccountProjectTaskAttachmentBLL.CreateTempFolderPath()
        Dim TempFile As String = DBUtilities.GetSessionAccountId & ".bak"
        Return TempFolderPath & TempFile
    End Function
    Public Function GetDownloadLink(ByVal strFullPath As String) As String
        Dim dlDir As String = System.Configuration.ConfigurationManager.AppSettings("UploadFilesPath")
        GetDownloadLink = strFullPath.Replace(System.Web.HttpContext.Current.Request.MapPath(dlDir), "")
        Return GetDownloadLink
    End Function
    Public Function GetDataTableOfCSV(ByVal strFilePath As String, ByVal ExportType As String) As DataTable
        'Return FileHelpers.CommonEngine.CsvToDataTable(strFilePath, Me.GetDelimiter(ExportType))
        Return New DelimitedImportExport().PopulateDataTableFromUploadedFile(strFilePath, Me.GetDelimiter(ExportType))
    End Function
    Public Function GetDataTableOfMProject(ByVal strFilePath As String, ByVal ExportType As String) As DataTable
        Return New MprojectClass().PopulateDataTableFromUploadedFile(strFilePath, Me.GetDelimiter(ExportType))
    End Function
    Public Function GetAllColumnsOfDBForMapping(ByVal DataName As String, Optional ByVal IsUpdate As Boolean = False) As DataTable
        Dim objTable As New DataTable
        If IsUpdate = True Then
            objTable = Me.GetDataTableFromAdapterForImport(DataName, True)
        Else
            objTable = Me.GetDataTableFromAdapterForImport(DataName, False)
        End If
        objTable = Me.GetAllColumnsOfDBDataTable(objTable)
        Return objTable
    End Function
    Public Function GetAllColumnsOfMProjectForMapping(ByVal DataName As String) As DataTable
        Dim objTable As New DataTable
        objTable = Me.GetDataTableFromAdapterForImport(DataName)
        objTable = Me.GetAllColumnsOfDBDataTable(objTable)
        Return objTable
    End Function
    Public Function IsColumnIsRequired(ByVal DataName As String, ByVal DBColumnName As String) As String
        Dim dt As DataTable = Me.GetAllColumnsOfDBForMapping(DataName)
        Dim dr As DataRow() = dt.Select("DBColumnName='" & DBColumnName & "'")
        If dr.Length > 0 Then
            Return dr(0)("Required").ToString
        Else
            Return ""
        End If
    End Function
    Public Function GetAllColumnMappingDataTableOfCSV(ByVal strFilePath As String, ByVal ExportType As String) As DataTable
        Dim objTable As New DataTable
        objTable = Me.GetDataTableOfCSV(strFilePath, ExportType)
        objTable = GetAllColumnsOfCSVDataTable(objTable)
        Return objTable
    End Function
    Public Function GetAllColumnMappingDataTableOfMProject(ByVal strFilePath As String, ByVal ExportType As String) As DataTable
        Dim objTable As New DataTable
        objTable = Me.GetDataTableOfMProject(strFilePath, ExportType)
        '    objTable = GetAllColumnsOfMProjectDataTable(objTable)
        Return objTable
    End Function
    Public Function GetExportDataSourceByName(ByVal strName As String, Optional ByVal IsUpdate As Boolean = False) As DataRow
        If IsUpdate = True Then
            Return Me.GetAllExportableDatasource(True).Select("DataName='" & strName & "'")(0)
        Else
            Return Me.GetAllExportableDatasource(False).Select("DataName='" & strName & "'")(0)
        End If
    End Function
    Public Function GetAllExportableDatasourceADP(Optional ByVal IsUpdate As Boolean = False) As DataTable
        Dim objTable As New DataTable
        objTable.Columns.Add("DataName", GetType(System.String), "")
        objTable.Columns.Add("ImportAdapterName", GetType(System.String), "")
        objTable.Columns.Add("ExportAdapterName", GetType(System.String), "")
        objTable.Columns.Add("QBExportAdapterName", GetType(System.String), "")
        objTable.Columns.Add("TableName", GetType(System.String), "")
        objTable.Columns.Add("FunctionName", GetType(System.String), "")
        objTable.Columns.Add("PrimaryKey", GetType(System.String), "")
        objTable.Columns.Add("KeyField", GetType(System.String), "")
        objTable.Columns.Add("InsertClass", GetType(System.String), "")
        objTable.Columns.Add("InsertFunction", GetType(System.String), "")
        objTable.Columns.Add("ShowFilter", GetType(System.Boolean), "")
        objTable.Columns.Add("ShowProjectFilter", GetType(System.Boolean), "")
        objTable.Columns.Add("IsQuickbooksExportAllowed", GetType(System.Boolean), "")
        objTable.Columns.Add("IsQuickbooksImportAllowed", GetType(System.Boolean), "")

        Dim objRow As DataRow
        If System.Configuration.ConfigurationManager.AppSettings("BugTracking") <> "Yes" Then
            objRow = objTable.NewRow()
            objRow("DataName") = "Time Entry"
            objRow("ImportAdapterName") = "TimeLiveFileHelperTableAdapters.AccountEmployeeTimeEntryImportTableAdapter"
            objRow("ExportAdapterName") = "TimeLiveFileHelperTableAdapters.AccountEmployeeTimeEntryExportTableAdapter"
            objRow("QBExportAdapterName") = "TimeLiveFileHelperTableAdapters.AccountEmployeeTimeEntryExportQBTableAdapter"
            objRow("TableName") = "AccountEmployeeTimeEntry"
            objRow("FunctionName") = "GetData"
            objRow("PrimaryKey") = "AccountEmployeeTimeEntryId"
            objRow("KeyField") = "AccountEmployeeTimeEntryId"
            objRow("InsertClass") = "AccountEmployeeTimeEntryBLL"
            objRow("InsertFunction") = "AddAccountEmployeeTimeEntryForImportExport"
            objRow("ShowFilter") = "True"
            objRow("ShowProjectFilter") = "False"
            objTable.Rows.Add(objRow)
        End If
    End Function
    Public Function GetAllExportableDatasource(Optional ByVal IsUpdate As Boolean = False) As DataTable
        Dim objTable As New DataTable
        objTable.Columns.Add("DataName", GetType(System.String), "")
        objTable.Columns.Add("ImportAdapterName", GetType(System.String), "")
        objTable.Columns.Add("ExportAdapterName", GetType(System.String), "")
        objTable.Columns.Add("QBExportAdapterName", GetType(System.String), "")
        objTable.Columns.Add("TableName", GetType(System.String), "")
        objTable.Columns.Add("FunctionName", GetType(System.String), "")
        objTable.Columns.Add("PrimaryKey", GetType(System.String), "")
        objTable.Columns.Add("KeyField", GetType(System.String), "")
        objTable.Columns.Add("InsertClass", GetType(System.String), "")
        objTable.Columns.Add("InsertFunction", GetType(System.String), "")
        objTable.Columns.Add("ShowFilter", GetType(System.Boolean), "")
        objTable.Columns.Add("ShowProjectFilter", GetType(System.Boolean), "")
        objTable.Columns.Add("IsQuickbooksExportAllowed", GetType(System.Boolean), "")
        objTable.Columns.Add("IsQuickbooksImportAllowed", GetType(System.Boolean), "")

        Dim objRow As DataRow

        objRow = objTable.NewRow()
        objRow("DataName") = "Client"
        objRow("ImportAdapterName") = "TimeLiveFileHelperTableAdapters.AccountPartyImportTableAdapter"
        objRow("ExportAdapterName") = "TimeLiveFileHelperTableAdapters.AccountPartyExportTableAdapter"
        objRow("QBExportAdapterName") = "TimeLiveFileHelperTableAdapters.AccountPartyExportQBTableAdapter"
        objRow("TableName") = "AccountParty"
        objRow("FunctionName") = "GetData"
        objRow("PrimaryKey") = "AccountPartyId"
        objRow("KeyField") = "Name"
        objRow("InsertClass") = "AccountPartyBLL"
        If IsUpdate = True Then
            objRow("InsertFunction") = "UpdateAccountParty"
        Else
            objRow("InsertFunction") = "AddAccountParty"
        End If
        objRow("ShowFilter") = "False"
        objRow("ShowProjectFilter") = "False"
        objRow("IsQuickbooksExportAllowed") = "True"
        objRow("IsQuickbooksImportAllowed") = "True"
        objTable.Rows.Add(objRow)

        objRow = objTable.NewRow()
        objRow("DataName") = "Employee"
        objRow("ImportAdapterName") = "TimeLiveFileHelperTableAdapters.AccountEmployeeImportTableAdapter"
        objRow("ExportAdapterName") = "TimeLiveFileHelperTableAdapters.AccountEmployeeExportTableAdapter"
        objRow("QBExportAdapterName") = "TimeLiveFileHelperTableAdapters.AccountEmployeeExportQBTableAdapter"
        objRow("TableName") = "AccountEmployee"
        If LicensingBLL.IsHostedFreeCustomerLicenseExpired(DBUtilities.GetSessionAccountId) Then
            objRow("FunctionName") = "GetDataByAccountIdTop3"
        Else
            objRow("FunctionName") = "GetData"
        End If

        objRow("PrimaryKey") = "AccountEmployeeId"
        objRow("KeyField") = "Name"
        objRow("InsertClass") = "AccountEmployeeBLL"
        If IsUpdate = True Then
            objRow("InsertFunction") = "UpdateSelectedAccountEmployee"
        Else
            objRow("InsertFunction") = "AddAccountEmployee"
        End If
        objRow("ShowFilter") = "False"
        objRow("ShowProjectFilter") = "False"
        objTable.Rows.Add(objRow)

        objRow = objTable.NewRow()
        objRow("DataName") = "Department"
        objRow("ImportAdapterName") = "TimeLiveFileHelperTableAdapters.AccountDepartmentImportTableAdapter"
        objRow("ExportAdapterName") = "TimeLiveFileHelperTableAdapters.AccountDepartmentExportTableAdapter"
        objRow("TableName") = "AccountDepartment"
        objRow("FunctionName") = "GetData"
        objRow("PrimaryKey") = "AccountDepartmentId"
        objRow("KeyField") = "DepartmentName"
        objRow("InsertClass") = "AccountDepartmentBLL"
        objRow("InsertFunction") = "AddAccountDepartment"
        objRow("ShowFilter") = "False"
        objRow("ShowProjectFilter") = "False"
        objTable.Rows.Add(objRow)

        objRow = objTable.NewRow()
        objRow("DataName") = "Projects"
        objRow("ImportAdapterName") = "TimeLiveFileHelperTableAdapters.AccountProjectImportTableAdapter"
        objRow("ExportAdapterName") = "TimeLiveFileHelperTableAdapters.AccountProjectExportTableAdapter"
        objRow("TableName") = "AccountProject"
        If LicensingBLL.IsHostedFreeCustomerLicenseExpired(DBUtilities.GetSessionAccountId) Then
            objRow("FunctionName") = "GetDataByAccountIdTop3"
        Else
            objRow("FunctionName") = "GetData"
        End If

        objRow("PrimaryKey") = "AccountProjectId"
        objRow("KeyField") = "ProjectName"
        objRow("InsertClass") = "AccountProjectBLL"
        objRow("InsertFunction") = "AddAccountProject"
        objRow("ShowFilter") = "False"
        objRow("ShowProjectFilter") = "False"
        objTable.Rows.Add(objRow)
        If System.Configuration.ConfigurationManager.AppSettings("BugTracking") <> "Yes" Then
            objRow = objTable.NewRow()
            objRow("DataName") = "Time Entry"
            objRow("ImportAdapterName") = "TimeLiveFileHelperTableAdapters.AccountEmployeeTimeEntryImportTableAdapter"
            objRow("ExportAdapterName") = "TimeLiveFileHelperTableAdapters.AccountEmployeeTimeEntryExportTableAdapter"
            objRow("QBExportAdapterName") = "TimeLiveFileHelperTableAdapters.AccountEmployeeTimeEntryExportQBTableAdapter"
            objRow("TableName") = "AccountEmployeeTimeEntry"
            objRow("FunctionName") = "GetData"
            objRow("PrimaryKey") = "AccountEmployeeTimeEntryId"
            objRow("KeyField") = "AccountEmployeeTimeEntryId"
            objRow("InsertClass") = "AccountEmployeeTimeEntryBLL"
            objRow("InsertFunction") = "AddAccountEmployeeTimeEntryForImportExport"
            objRow("ShowFilter") = "True"
            objRow("ShowProjectFilter") = "False"
            objTable.Rows.Add(objRow)


            objRow = objTable.NewRow()
            objRow("DataName") = "Time Off Request"
            If LocaleUtilitiesBLL.IsShowProjectForTimeOff = True Then
                objRow("ImportAdapterName") = "TimeLiveFileHelperTableAdapters.AccountEmployeeTimeOffRequestImportTableAdapter"
                objRow("ExportAdapterName") = "TimeLiveFileHelperTableAdapters.AccountEmployeeTimeOffRequestExportTableAdapter"
            Else
                objRow("ImportAdapterName") = "TimeLiveFileHelperTableAdapters.AccountEmployeeTimeOffRequestWithoutProjectImportTableAdapter"
                objRow("ExportAdapterName") = "TimeLiveFileHelperTableAdapters.AccountEmployeeTimeOffRequestWithoutProjectExportTableAdapter"
            End If
            objRow("TableName") = "AccountEmployeeTimeOffRequest"
            objRow("FunctionName") = "GetData"
            objRow("PrimaryKey") = "AccountEmployeeTimeOffRequestId"
            objRow("KeyField") = "Name"
            objRow("InsertClass") = "AccountEmployeeTimeOffRequestBLL"
            objRow("InsertFunction") = "ImportTimeOff"
            objRow("ShowFilter") = "True"
            objRow("ShowProjectFilter") = "False"
            objTable.Rows.Add(objRow)

            objRow = objTable.NewRow()
            objRow("DataName") = "Time Off"
            objRow("ImportAdapterName") = "TimeLiveFileHelperTableAdapters.AccountEmployeeTimeOffImportTableAdapter"
            objRow("ExportAdapterName") = "TimeLiveFileHelperTableAdapters.AccountEmployeeTimeOffExportTableAdapter"
            objRow("TableName") = "AccountEmployeeTimeEntry"
            objRow("FunctionName") = "GetData"
            objRow("PrimaryKey") = "AccountEmployeeTimeEntryId"
            objRow("KeyField") = "Name"
            objRow("InsertClass") = "AccountEmployeeTimeOffRequestBLL"
            objRow("InsertFunction") = "ImportTimeOff"
            objRow("ShowFilter") = "True"
            objRow("ShowProjectFilter") = "False"
            objTable.Rows.Add(objRow)

            objRow = objTable.NewRow()
            objRow("DataName") = "Expense Entry"
            objRow("ImportAdapterName") = "TimeLiveFileHelperTableAdapters.AccountExpenseEntryImportTableAdapter"
            objRow("ExportAdapterName") = "TimeLiveFileHelperTableAdapters.AccountExpenseEntryExportTableAdapter"
            objRow("QBExportAdapterName") = "TimeLiveFileHelperTableAdapters.AccountExpenseEntryExportQBTableAdapter"
            objRow("TableName") = "AccountExpenseEntry"
            objRow("FunctionName") = "GetData"
            objRow("PrimaryKey") = "AccountExpenseEntryId"
            objRow("KeyField") = "AccountExpenseEntryId"
            objRow("InsertClass") = "AccountExpenseEntryBLL"
            objRow("InsertFunction") = "AddAccountExpenseEntryWithExpenseSheetFromImport"
            objRow("ShowFilter") = "True"
            objRow("ShowProjectFilter") = "False"
            objTable.Rows.Add(objRow)
        End If
        objRow = objTable.NewRow()
        objRow("DataName") = "Project Task"
        objRow("ImportAdapterName") = "TimeLiveFileHelperTableAdapters.AccountProjectTaskImportTableAdapter"
        objRow("ExportAdapterName") = "TimeLiveFileHelperTableAdapters.AccountProjectTaskExportTableAdapter"
        objRow("TableName") = "AccountProjectTask"
        objRow("FunctionName") = "GetData"
        objRow("PrimaryKey") = "AccountProjectTaskId"
        objRow("KeyField") = "TaskName"
        objRow("InsertClass") = "AccountProjectTaskBLL"
        objRow("InsertFunction") = "AddAccountProjectTask"
        objRow("ShowFilter") = "False"
        objRow("ShowProjectFilter") = "True"
        objTable.Rows.Add(objRow)

        objRow = objTable.NewRow()
        objRow("DataName") = "Tasks Users"
        objRow("ImportAdapterName") = "TimeLiveFileHelperTableAdapters.AccountProjectTaskEmployeeImportTableAdapter"
        objRow("ExportAdapterName") = "TimeLiveFileHelperTableAdapters.AccountProjectTaskEmployeeExportTableAdapter"
        objRow("TableName") = "AccountProjectTaskEmployee"
        objRow("FunctionName") = "GetData"
        objRow("PrimaryKey") = "AccountProjectTaskEmployeeId"
        objRow("KeyField") = "TaskName"
        objRow("InsertClass") = "AccountProjectTaskEmployeeBLL"
        objRow("InsertFunction") = "AddAccountProjectTaskEmployeeFromImportExport"
        objRow("ShowFilter") = "False"
        objRow("ShowProjectFilter") = "True"
        objTable.Rows.Add(objRow)

        objRow = objTable.NewRow()
        objRow("DataName") = "Projects Team"
        objRow("ImportAdapterName") = "TimeLiveFileHelperTableAdapters.AccountProjectEmployeeImportTableAdapter"
        objRow("ExportAdapterName") = "TimeLiveFileHelperTableAdapters.AccountProjectEmployeeExportTableAdapter"
        objRow("TableName") = "AccountProjectEmployee"
        objRow("FunctionName") = "GetData"
        objRow("PrimaryKey") = "AccountProjectEmployeeId"
        objRow("KeyField") = "ProjectName"
        objRow("InsertClass") = "AccountProjectEmployeeBLL"
        objRow("InsertFunction") = "AddDefaultAccountProjectEmplyeeByImport"
        objRow("ShowFilter") = "False"
        objRow("ShowProjectFilter") = "True"
        objTable.Rows.Add(objRow)

        objRow = objTable.NewRow()
        objRow("DataName") = "Projects Roles"
        objRow("ImportAdapterName") = "TimeLiveFileHelperTableAdapters.AccountProjectRoleImportTableAdapter"
        objRow("ExportAdapterName") = "TimeLiveFileHelperTableAdapters.AccountProjectRoleExportTableAdapter"
        objRow("TableName") = "AccountProjectRole"
        objRow("FunctionName") = "GetData"
        objRow("PrimaryKey") = "AccountProjectRoleId"
        objRow("KeyField") = "Role"
        objRow("InsertClass") = "AccountProjectRoleBLL"
        objRow("InsertFunction") = "AddDefaultAccountProjectRoleByImport"
        objRow("ShowFilter") = "False"
        objRow("ShowProjectFilter") = "True"
        objTable.Rows.Add(objRow)

        objTable.AcceptChanges()

        Return objTable


    End Function
    Public Function GetAllExportableQuickbookDatasource() As DataTable
        Dim objTable As New DataTable
        objTable.Columns.Add("DataName", GetType(System.String), "")
        objTable.Columns.Add("ImportAdapterName", GetType(System.String), "")
        objTable.Columns.Add("ExportAdapterName", GetType(System.String), "")
        objTable.Columns.Add("QBExportAdapterName", GetType(System.String), "")
        objTable.Columns.Add("TableName", GetType(System.String), "")
        objTable.Columns.Add("FunctionName", GetType(System.String), "")
        objTable.Columns.Add("PrimaryKey", GetType(System.String), "")
        objTable.Columns.Add("KeyField", GetType(System.String), "")
        objTable.Columns.Add("InsertClass", GetType(System.String), "")
        objTable.Columns.Add("InsertFunction", GetType(System.String), "")
        objTable.Columns.Add("ShowFilter", GetType(System.Boolean), "")
        objTable.Columns.Add("ShowProjectFilter", GetType(System.Boolean), "")
        objTable.Columns.Add("IsQuickbooksExportAllowed", GetType(System.Boolean), "")
        objTable.Columns.Add("IsQuickbooksImportAllowed", GetType(System.Boolean), "")

        Dim objRow As DataRow

        objRow = objTable.NewRow()
        objRow("DataName") = "Client"
        objRow("ImportAdapterName") = "TimeLiveFileHelperTableAdapters.AccountPartyImportTableAdapter"
        objRow("ExportAdapterName") = "TimeLiveFileHelperTableAdapters.AccountPartyExportTableAdapter"
        objRow("QBExportAdapterName") = "TimeLiveFileHelperTableAdapters.AccountPartyExportQBTableAdapter"
        objRow("TableName") = "AccountParty"
        objRow("FunctionName") = "GetData"
        objRow("PrimaryKey") = "AccountPartyId"
        objRow("KeyField") = "Name"
        objRow("InsertClass") = "AccountPartyBLL"
        objRow("InsertFunction") = "AddAccountParty"
        objRow("ShowFilter") = "False"
        objRow("ShowProjectFilter") = "False"
        objRow("IsQuickbooksExportAllowed") = "True"
        objRow("IsQuickbooksImportAllowed") = "True"
        objTable.Rows.Add(objRow)

        objRow = objTable.NewRow()
        objRow("DataName") = "Employee"
        objRow("ImportAdapterName") = "TimeLiveFileHelperTableAdapters.AccountEmployeeImportTableAdapter"
        objRow("ExportAdapterName") = "TimeLiveFileHelperTableAdapters.AccountEmployeeExportTableAdapter"
        objRow("QBExportAdapterName") = "TimeLiveFileHelperTableAdapters.AccountEmployeeExportQBTableAdapter"
        objRow("TableName") = "AccountEmployee"
        If LicensingBLL.IsHostedFreeCustomerLicenseExpired(DBUtilities.GetSessionAccountId) Then
            objRow("FunctionName") = "GetDataByAccountIdTop3"
        Else
            objRow("FunctionName") = "GetData"
        End If

        objRow("PrimaryKey") = "AccountEmployeeId"
        objRow("KeyField") = "Name"
        objRow("InsertClass") = "AccountEmployeeBLL"
        objRow("InsertFunction") = "AddAccountEmployee"
        objRow("ShowFilter") = "False"
        objRow("ShowProjectFilter") = "False"
        objTable.Rows.Add(objRow)

        If System.Configuration.ConfigurationManager.AppSettings("BugTracking") <> "Yes" Then
            objRow = objTable.NewRow()
            objRow("DataName") = "Time Entry"
            objRow("ImportAdapterName") = "TimeLiveFileHelperTableAdapters.AccountEmployeeTimeEntryImportTableAdapter"
            objRow("ExportAdapterName") = "TimeLiveFileHelperTableAdapters.AccountEmployeeTimeEntryExportTableAdapter"
            objRow("QBExportAdapterName") = "TimeLiveFileHelperTableAdapters.AccountEmployeeTimeEntryExportQBTableAdapter"
            objRow("TableName") = "AccountEmployeeTimeEntry"
            objRow("FunctionName") = "GetData"
            objRow("PrimaryKey") = "AccountEmployeeTimeEntryId"
            objRow("KeyField") = "AccountEmployeeTimeEntryId"
            objRow("InsertClass") = "AccountEmployeeTimeEntryBLL"
            objRow("InsertFunction") = "AddAccountEmployeeTimeEntryForImportExport"
            objRow("ShowFilter") = "True"
            objRow("ShowProjectFilter") = "False"
            objTable.Rows.Add(objRow)
        End If

        objTable.AcceptChanges()

        Return objTable


    End Function
    Public Function GetAllImportableQuickbookDatasource() As DataTable
        Dim objTable As New DataTable
        objTable.Columns.Add("DataName", GetType(System.String), "")
        objTable.Columns.Add("ImportAdapterName", GetType(System.String), "")
        objTable.Columns.Add("ExportAdapterName", GetType(System.String), "")
        objTable.Columns.Add("QBExportAdapterName", GetType(System.String), "")
        objTable.Columns.Add("TableName", GetType(System.String), "")
        objTable.Columns.Add("FunctionName", GetType(System.String), "")
        objTable.Columns.Add("PrimaryKey", GetType(System.String), "")
        objTable.Columns.Add("KeyField", GetType(System.String), "")
        objTable.Columns.Add("InsertClass", GetType(System.String), "")
        objTable.Columns.Add("InsertFunction", GetType(System.String), "")
        objTable.Columns.Add("ShowFilter", GetType(System.Boolean), "")
        objTable.Columns.Add("ShowProjectFilter", GetType(System.Boolean), "")
        objTable.Columns.Add("IsQuickbooksExportAllowed", GetType(System.Boolean), "")
        objTable.Columns.Add("IsQuickbooksImportAllowed", GetType(System.Boolean), "")

        Dim objRow As DataRow

        objRow = objTable.NewRow()
        objRow("DataName") = "Client"
        objRow("ImportAdapterName") = "TimeLiveFileHelperTableAdapters.AccountPartyImportTableAdapter"
        objRow("ExportAdapterName") = "TimeLiveFileHelperTableAdapters.AccountPartyExportTableAdapter"
        objRow("QBExportAdapterName") = "TimeLiveFileHelperTableAdapters.AccountPartyExportQBTableAdapter"
        objRow("TableName") = "AccountParty"
        objRow("FunctionName") = "GetData"
        objRow("PrimaryKey") = "AccountPartyId"
        objRow("KeyField") = "Name"
        objRow("InsertClass") = "AccountPartyBLL"
        objRow("InsertFunction") = "AddAccountParty"
        objRow("ShowFilter") = "False"
        objRow("ShowProjectFilter") = "False"
        objRow("IsQuickbooksExportAllowed") = "True"
        objRow("IsQuickbooksImportAllowed") = "True"
        objTable.Rows.Add(objRow)

        objRow = objTable.NewRow()
        objRow("DataName") = "Employee"
        objRow("ImportAdapterName") = "TimeLiveFileHelperTableAdapters.AccountEmployeeImportTableAdapter"
        objRow("ExportAdapterName") = "TimeLiveFileHelperTableAdapters.AccountEmployeeExportTableAdapter"
        objRow("QBExportAdapterName") = "TimeLiveFileHelperTableAdapters.AccountEmployeeExportQBTableAdapter"
        objRow("TableName") = "AccountEmployee"
        If LicensingBLL.IsHostedFreeCustomerLicenseExpired(DBUtilities.GetSessionAccountId) Then
            objRow("FunctionName") = "GetDataByAccountIdTop3"
        Else
            objRow("FunctionName") = "GetData"
        End If

        objRow("PrimaryKey") = "AccountEmployeeId"
        objRow("KeyField") = "Name"
        objRow("InsertClass") = "AccountEmployeeBLL"
        objRow("InsertFunction") = "AddAccountEmployee"
        objRow("ShowFilter") = "False"
        objRow("ShowProjectFilter") = "False"
        objTable.Rows.Add(objRow)

        objTable.AcceptChanges()

        Return objTable


    End Function
    Public Function GetAllMicrosoftProjectDatasource() As DataTable
        Dim objTable As New DataTable
        objTable.Columns.Add("DataName", GetType(System.String), "")
        objTable.Columns.Add("ImportAdapterName", GetType(System.String), "")
        objTable.Columns.Add("ExportAdapterName", GetType(System.String), "")
        objTable.Columns.Add("QBExportAdapterName", GetType(System.String), "")
        objTable.Columns.Add("TableName", GetType(System.String), "")
        objTable.Columns.Add("FunctionName", GetType(System.String), "")
        objTable.Columns.Add("PrimaryKey", GetType(System.String), "")
        objTable.Columns.Add("KeyField", GetType(System.String), "")
        objTable.Columns.Add("InsertClass", GetType(System.String), "")
        objTable.Columns.Add("InsertFunction", GetType(System.String), "")
        objTable.Columns.Add("ShowFilter", GetType(System.Boolean), "")
        objTable.Columns.Add("ShowProjectFilter", GetType(System.Boolean), "")
        objTable.Columns.Add("IsQuickbooksExportAllowed", GetType(System.Boolean), "")
        objTable.Columns.Add("IsQuickbooksImportAllowed", GetType(System.Boolean), "")

        Dim objRow As DataRow

        objRow = objTable.NewRow()
        objRow("DataName") = "Projects"
        objRow("ImportAdapterName") = "TimeLiveFileHelperTableAdapters.AccountProjectImportTableAdapter"
        objRow("ExportAdapterName") = "TimeLiveFileHelperTableAdapters.AccountProjectExportTableAdapter"
        objRow("TableName") = "AccountProject"
        objRow("FunctionName") = "GetData"
        objRow("PrimaryKey") = "AccountProjectId"
        objRow("KeyField") = "ProjectName"
        objRow("InsertClass") = "AccountProjectBLL"
        objRow("InsertFunction") = "AddAccountProjectWithProjectFromImport"
        objRow("ShowFilter") = "False"
        objRow("ShowProjectFilter") = "False"
        objTable.Rows.Add(objRow)

        objTable.AcceptChanges()

        Return objTable


    End Function
    Public Function GetAllExportableMProjectDatasource() As DataTable
        Dim objTable As New DataTable
        objTable.Columns.Add("DataName", GetType(System.String), "")
        objTable.Columns.Add("ImportAdapterName", GetType(System.String), "")
        objTable.Columns.Add("ExportAdapterName", GetType(System.String), "")
        objTable.Columns.Add("QBExportAdapterName", GetType(System.String), "")
        objTable.Columns.Add("TableName", GetType(System.String), "")
        objTable.Columns.Add("FunctionName", GetType(System.String), "")
        objTable.Columns.Add("PrimaryKey", GetType(System.String), "")
        objTable.Columns.Add("KeyField", GetType(System.String), "")
        objTable.Columns.Add("InsertClass", GetType(System.String), "")
        objTable.Columns.Add("InsertFunction", GetType(System.String), "")
        objTable.Columns.Add("ShowFilter", GetType(System.Boolean), "")
        objTable.Columns.Add("ShowProjectFilter", GetType(System.Boolean), "")
        objTable.Columns.Add("IsQuickbooksExportAllowed", GetType(System.Boolean), "")
        objTable.Columns.Add("IsQuickbooksImportAllowed", GetType(System.Boolean), "")

        Dim objRow As DataRow

        objRow = objTable.NewRow()
        objRow("DataName") = "Projects"
        objRow("ImportAdapterName") = "TimeLiveFileHelperTableAdapters.AccountProjectImportTableAdapter"
        objRow("ExportAdapterName") = "TimeLiveFileHelperTableAdapters.AccountProjectExportTableAdapter"
        objRow("TableName") = "AccountProject"
        objRow("FunctionName") = "GetData"
        objRow("PrimaryKey") = "AccountProjectId"
        objRow("KeyField") = "ProjectName"
        objRow("InsertClass") = "AccountProjectBLL"
        objRow("InsertFunction") = "AddAccountProject"
        objRow("ShowFilter") = "False"
        objRow("ShowProjectFilter") = "False"
        objTable.Rows.Add(objRow)

        objTable.AcceptChanges()

        Return objTable

    End Function
    Public Function GetMappedColumnValue(ByVal CSVColumnName As String, ByVal dtMappings As DataTable, ByVal DataName As String) As Object
        For Each objRow As DataRow In dtMappings.Rows
            If objRow("MappedColumn") = CSVColumnName Then
                Return objRow("OrignalFileColumn")
            End If
        Next
        Return "Select"

    End Function
    Public Function GetCSVColumnOfDBColumn(ByVal DBColumnName As String, ByVal dtMappings As DataTable, ByVal DataName As String, Optional ByVal IsUpdate As Boolean = False) As String
        For Each objRow As DataRow In dtMappings.Rows
            If IsUpdate = True Then
                If Me.GetForeignColumnName(objRow("MappedColumn"), DataName, True) = DBColumnName Then
                    Return objRow("OrignalFileColumn")
                End If
            Else
                If Me.GetForeignColumnName(objRow("MappedColumn"), DataName, False) = DBColumnName Then
                    Return objRow("OrignalFileColumn")
                End If
            End If
        Next
        Return "Select"

    End Function
    Public Function IsRequired(ByVal DBColumnName As String, ByVal dtMappings As DataTable, ByVal DataName As String) As String
        For Each objRow As DataRow In dtMappings.Rows
            If Me.GetForeignColumnName(objRow("OrignalFileColumn"), DataName) = DBColumnName Then
                Return objRow("IsRequired")
            End If
        Next
        Return ""

    End Function
    Public Function GetRequiredColumnName(ByVal DBColumnName As String, ByVal dtMappings As DataTable, ByVal DataName As String) As String
        For Each objRow As DataRow In dtMappings.Rows
            If Me.GetForeignColumnName(objRow("OrignalFileColumn"), DataName) = DBColumnName Then
                Return objRow("OrignalFileColumn")
            End If
        Next
        Return ""

    End Function
    Public Function CreateMappingTable() As DataTable

        Dim dtMappings As New DataTable
        dtMappings.Columns.Add("OrignalFileColumn", GetType(System.String), "")
        dtMappings.Columns.Add("MappedColumn", GetType(System.String), "")
        dtMappings.Columns.Add("IsRequired", GetType(System.String), "")
        Return dtMappings

    End Function
    Public Sub AddMappingRow(ByVal MappingTable As DataTable, ByVal OrignalFileColumn As String, ByVal MappedColumn As String, Optional ByVal IsRequired As String = "")

        Dim row As DataRow = MappingTable.NewRow
        MappingTable.Rows.Add(row)
        row("OrignalFileColumn") = OrignalFileColumn
        row("MappedColumn") = MappedColumn
        row("IsRequired") = IsRequired

    End Sub
    Public Function GetMappingCollectionForCSV(ByVal objGridView As GridView, ByVal DataName As String) As DataTable

        Dim dtMappings As New DataTable
        dtMappings = Me.CreateMappingTable

        For Each objGridViewRow As GridViewRow In objGridView.Rows
            If objGridViewRow.RowType = DataControlRowType.DataRow Then
                Me.AddMappingRow(dtMappings, CType(objGridViewRow.Cells(2).FindControl("ddlFileColumnName"), DropDownList).SelectedValue, objGridViewRow.Cells(1).Text, objGridViewRow.Cells(3).Text)
            End If
        Next
        Return dtMappings

    End Function
    Public Function GetQBMappedRecords(ByVal DataName As String) As DataTable

        Dim dtMappings As New DataTable
        dtMappings = Me.CreateMappingTable

        If DataName = "Client" Then
            Me.AddMappingRow(dtMappings, "NAME", "PartyName", "Required")
            Me.AddMappingRow(dtMappings, "COMPANYNAME", "PartyName")
            Me.AddMappingRow(dtMappings, "EMAIL", "EMailAddress")
            Me.AddMappingRow(dtMappings, "BADDR1", "Address1")
            Me.AddMappingRow(dtMappings, "BADDR2", "Address2")
            Me.AddMappingRow(dtMappings, "PHONE1", "Telephone1")
            Me.AddMappingRow(dtMappings, "PHONE2", "Telephone2")
            Me.AddMappingRow(dtMappings, "PHONE2", "Telephone2")
            Me.AddMappingRow(dtMappings, "FAXNUM", "Fax")
            Me.AddMappingRow(dtMappings, "NOTEPAD", "Notes")
        End If

        If DataName = "Employee" Then
            Me.AddMappingRow(dtMappings, "FIRSTNAME", "FirstName")
            Me.AddMappingRow(dtMappings, "MIDINIT", "PartyName")
            Me.AddMappingRow(dtMappings, "LASTNAME", "LastName")
            Me.AddMappingRow(dtMappings, "ADDR1", "Address1")
            Me.AddMappingRow(dtMappings, "ADDR2", "Address2")
            Me.AddMappingRow(dtMappings, "PHONE1", "WorkPhoneNo")
            Me.AddMappingRow(dtMappings, "PHONE2", "MobilePhoneNo")
            Me.AddMappingRow(dtMappings, "EMAIL", "EMailAddress")
        End If

        Return dtMappings

    End Function
    Public Sub SetEmployeesParameterForOfflineTimesheet(OfflineTimesheet As Boolean)
        If OfflineTimesheet Then
            Dim EmployeeId As Integer = System.Web.HttpContext.Current.Session("OfflineTimesheetAccountEmployeeId")
            AccountEmployeeId = EmployeeId
            Dim dt As AccountEmployee.AccountEmployeeDataTable = New AccountEmployeeBLL().GetAccountEmployeesByAccountEmployeeId(AccountEmployeeId)
            EmployeeName = dt.Rows(0)("FirstName") & " " & dt.Rows(0)("LastName")
        End If
    End Sub
    Dim Count As Integer
    Public Function InsertRecords(ByVal dtMappings As DataTable, ByVal DataName As String, ByVal strFilePath As String, ByVal ExportType As String, ByVal TestMode As Boolean, Optional OfflineTimesheet As Boolean = False, Optional ByVal IsUpdate As Boolean = False)
        Dim MappedColumn As String
        Dim dtCSVFile As DataTable = Me.GetDataTableOfCSV(strFilePath, ExportType)
        Dim objDataDefination As DataRow
        If IsUpdate = True Then
            objDataDefination = Me.GetExportDataSourceByName(DataName, True)
        Else
            objDataDefination = Me.GetExportDataSourceByName(DataName, False)
        End If

        Dim InsertClassObject As Object
        Dim objExecutingAssembly As Assembly = Assembly.GetExecutingAssembly
        Dim objType As Type = objExecutingAssembly.GetType(objDataDefination("InsertClass"))
        Dim objMethodInfo As MethodInfo = objType.GetMethod(objDataDefination("InsertFunction"))
        Dim objParameterInfo As ParameterInfo() = objMethodInfo.GetParameters()
        Dim objParameters(objParameterInfo.Length) As Object
        Dim CSVRowsCount As Integer = 0
        SetEmployeesParameterForOfflineTimesheet(OfflineTimesheet)
        For Each objRow As DataRow In dtCSVFile.Rows
            If DataName = "Projects" Or DataName = "Employee" Then
                If LicensingBLL.IsHostedFreeCustomerLicenseExpired(DBUtilities.GetSessionAccountId) Then
                    Dim bll As New AccountProjectBLL
                    If bll.IsCheckProjectRowsForLicense(DBUtilities.GetSessionAccountId) Then
                        Return CSVRowsCount
                    End If
                End If
            End If

            CSVRowsCount += 1
            If TestMode = False Then
                If CSVRowsCount = dtCSVFile.Rows.Count Then
                    RowsCountEqual = True
                End If
            End If
            InsertClassObject = objExecutingAssembly.CreateInstance(objDataDefination("InsertClass"))
            ReDim objParameters(objParameterInfo.Length - 1)
            For n As Integer = 0 To objParameterInfo.Length - 1
                If IsUpdate = True Then
                    MappedColumn = Me.GetCSVColumnOfDBColumn(objParameterInfo(n).Name, dtMappings, DataName, True)
                    objParameters(n) = Me.GetDefaultValue(objParameterInfo(n).Name, dtMappings, DataName, objRow, OfflineTimesheet, True)
                    'objParameters(n) = Me.GetDefaultValue(objParameterInfo(n).Name, dtMappings, DataName, objRow, OfflineTimesheet, True)
                Else
                    MappedColumn = Me.GetCSVColumnOfDBColumn(objParameterInfo(n).Name, dtMappings, DataName, False)
                    objParameters(n) = Me.GetDefaultValue(objParameterInfo(n).Name, dtMappings, DataName, objRow, OfflineTimesheet, False)
                    objParameters(n) = Me.GetDefaultValue(objParameterInfo(n).Name, dtMappings, DataName, objRow, OfflineTimesheet, False)
                End If
                If Me.IsRequired(objParameterInfo(n).Name, dtMappings, DataName) = "Required" Then
                    If MappedColumn = "Select" Then
                        Throw New Exception("Field " & GetRequiredColumnName(objParameterInfo(n).Name, dtMappings, DataName) & " is required")
                    End If
                End If
                If IsUpdate = False Then
                    CheckImportValidation(objParameterInfo(n).Name, objRow, DataName)
                End If
                If MappedColumn <> "Select" Then
                    If Not Me.GetForeignColumn(objParameterInfo(n).Name, objRow(MappedColumn), DataName) Is Nothing Then
                        objParameters(n) = Me.GetForeignColumn(objParameterInfo(n).Name, objRow(MappedColumn), DataName)
                    ElseIf objRow(MappedColumn) <> "" Then
                        objParameters(n) = Me.GetTypedValue(objRow(MappedColumn), objParameterInfo(n))
                    End If
                Else
                End If
            Next
            If IsUpdate = True Then
                System.Web.HttpContext.Current.Session.Add("IsUpdateImport", "1")
                objMethodInfo.Invoke(InsertClassObject, objParameters)
                System.Web.HttpContext.Current.Session.Remove("IsUpdateImport")
            Else
                objMethodInfo.Invoke(InsertClassObject, objParameters)
            End If
            If CSVRowsCount = 3 Then
                If DataName = "Projects" Or DataName = "Employee" Then
                    If LicensingBLL.IsHostedFreeCustomerLicenseExpired(DBUtilities.GetSessionAccountId) Then
                        Return CSVRowsCount
                    End If
                End If
            End If
        Next
        Return dtCSVFile.Rows.Count
    End Function
    Public Function GetCSVColumnValueOfDBColumn(ByVal FileRow As DataRow, ByVal DBColumnName As String, ByVal dtMappings As DataTable, ByVal DataName As String) As Object
        Dim MappedColumn As String = Me.GetCSVColumnOfDBColumn(DBColumnName, dtMappings, DataName)
        If MappedColumn <> "Select" Then
            Return FileRow(MappedColumn)
        Else
            Return ""
        End If

    End Function
    Public Function GetTypedValue(ByVal Value As Object, ByVal _ParameterInfo As ParameterInfo) As Object
        Dim NewValue As Integer
        If _ParameterInfo.ParameterType.ToString = "System.DateTime" Then
            Dim resultDate As Date
            If Date.TryParse(Value, resultDate) Then
                Return resultDate
            Else
                Throw New Exception("Invalid Date Format " & Value & ". Make sure that TimeLive culture settings is same which is in importing file")
            End If

            Return Convert.ToDateTime(Value)
        ElseIf _ParameterInfo.ParameterType.ToString = "System.Nullable`1[System.DateTime]" Then
            Dim resultDate As Date
            If Date.TryParse(Value, resultDate) Then
                Return resultDate
            Else
                Throw New Exception("Invalid Date Format " & Value & ". Make sure that TimeLive culture settings is same which is in importing file")
            End If

            Return Convert.ToDateTime(Value)
        ElseIf _ParameterInfo.ParameterType.ToString = "System.Int32" And Value <> "" Then
            Integer.TryParse(Value, NewValue)
            Return Convert.ToInt32(NewValue)
        ElseIf _ParameterInfo.ParameterType.ToString = "System.Int32" And Value = "" Then
            Return Nothing
        ElseIf _ParameterInfo.ParameterType.ToString = "System.Nullable`1[System.Int32]" And Value = "" Then
            Return 0
        ElseIf _ParameterInfo.ParameterType.ToString = "System.Nullable`1[System.Int32]" And Value <> "" Then
            Return Convert.ToInt32(Value)
        ElseIf _ParameterInfo.ParameterType.ToString = "System.Boolean" And Value = "" Then
            Return Nothing
        ElseIf _ParameterInfo.ParameterType.ToString = "System.Boolean" And Value <> "" Then
            Return Convert.ToBoolean(Value)
        ElseIf _ParameterInfo.ParameterType.ToString = "System.Nullable`1[System.Boolean]" And Value <> "" Then
            Return Convert.ToBoolean(Value)
        ElseIf _ParameterInfo.ParameterType.ToString = "System.Double" And Value = "" Then
            Return Nothing
        ElseIf _ParameterInfo.ParameterType.ToString = "System.Double" And Value <> "" Then
            Double.TryParse(Value, NewValue)
            Return Convert.ToDouble(Value)
        Else
            Return Value
        End If
    End Function
    Public Function UploadFile(ByVal txtFileUpload As System.Web.UI.WebControls.FileUpload, ByVal ExportType As String) As String
        Dim tempFile As String
        Dim objImportExportBLL As New ImportExportBLL
        tempFile = objImportExportBLL.GetTempFileForExport(ExportType)
        txtFileUpload.SaveAs(tempFile)
        Return tempFile
    End Function
    Public Function CheckImportValidation(ByVal ParameterName As String, ByVal ParameterValue As System.Data.DataRow, ByVal DataName As String) As Object
        If ParameterName = "PartyName" And DataName = "Client" Then
            Dim dt As TimeLiveFileHelper.AccountPartyExportDataTable = New TimeLiveFileHelperTableAdapters.AccountPartyExportTableAdapter().GetDataByPartyName(DBUtilities.GetSessionAccountId, ParameterValue("PartyName"))
            Dim dr As TimeLiveFileHelper.AccountPartyExportRow
            If dt.Rows.Count > 0 Then
                dr = dt.Rows(0)
                If ParameterValue("PartyName") = dr.PartyName Then
                    Throw New Exception("Error in importing: client """ + ParameterValue("PartyName") + """ already exist")
                End If
            End If
        End If
        If ParameterName = "ProjectName" And DataName = "Projects" Then
            Dim dt As TimeLiveFileHelper.AccountProjectDataTable = New TimeLiveFileHelperTableAdapters.AccountProjectTableAdapter().GetProjectNameByProjectNameAndPartyName(DBUtilities.GetSessionAccountId, ParameterValue("ProjectName"), ParameterValue("PartyName"))
            Dim dr As TimeLiveFileHelper.AccountProjectRow
            If dt.Rows.Count > 0 Then
                dr = dt.Rows(0)
                'If ParameterValue("ProjectName") = dr.ProjectName Then
                Throw New Exception("Error in importing: project """ + ParameterValue("ProjectName") + """ for this client """ + ParameterValue("PartyName") + """ already exist")
                'End If
            End If
        End If
        If ParameterName = "TaskName" And DataName = "Project Task" Then
            Dim dt As TimeLiveFileHelper.vueAccountProjectTaskDataTable = New TimeLiveFileHelperTableAdapters.vueAccountProjectTaskTableAdapter().GetTaskNameByTaskNameAndProjectName(DBUtilities.GetSessionAccountId, ParameterValue("TaskName"), ParameterValue("ProjectName"))
            Dim dr As TimeLiveFileHelper.vueAccountProjectTaskRow
            If dt.Rows.Count > 0 Then
                dr = dt.Rows(0)
                'If ParameterValue("TaskName") = dr.TaskName Then
                Throw New Exception("Error in importing: task """ + ParameterValue("TaskName") + """ in this project """ + ParameterValue("ProjectName") + """ already exist")
                'End If
            End If
        End If
    End Function
    Public Function GetForeignColumn(ByVal ParameterName As String, ByVal ParameterValue As Object, ByVal DataName As String) As Object
        If ParameterName = "CountryId" Then
            Dim dt As TimeLiveFileHelper.SystemCountryDataTable = New TimeLiveFileHelperTableAdapters.SystemCountryTableAdapter().GetDataByCountry(ParameterValue)
            If dt.Rows.Count > 0 Then
                Return dt.Rows(0)("CountryId")
            Else
                Return Convert.ToInt16(DBUtilities.GetCurrencyId())
            End If

        ElseIf ParameterName = "AccountLocationId" Then
            Dim dt As TimeLiveFileHelper.AccountLocationDataTable = New TimeLiveFileHelperTableAdapters.AccountLocationTableAdapter().GetDataAccountLocation(DBUtilities.GetSessionAccountId, ParameterValue)
            If dt.Rows.Count > 0 Then
                Return dt.Rows(0)("AccountLocationId")
            Else
                Return New TimeLiveFileHelperTableAdapters.AccountLocationTableAdapter().GetDataByAccountId(DBUtilities.GetSessionAccountId).Rows(0)("AccountLocationId")
            End If

        ElseIf ParameterName = "AccountDepartmentId" Then
            Dim dt As TimeLiveFileHelper.AccountDepartmentDataTable = New TimeLiveFileHelperTableAdapters.AccountDepartmentTableAdapter().GetDataByDepartmentName(DBUtilities.GetSessionAccountId, ParameterValue)
            If dt.Rows.Count > 0 Then
                Return dt.Rows(0)("AccountDepartmentId")
            Else
                Return New TimeLiveFileHelperTableAdapters.AccountDepartmentTableAdapter().GetDataByAccountId(DBUtilities.GetSessionAccountId).Rows(0)("AccountDepartmentId")
            End If

        ElseIf ParameterName = "AccountRoleId" Then
            Dim dt As TimeLiveFileHelper.AccountRoleDataTable = New TimeLiveFileHelperTableAdapters.AccountRoleTableAdapter().GetDataByRole(DBUtilities.GetSessionAccountId, ParameterValue)
            If dt.Rows.Count > 0 Then
                Return dt.Rows(0)("AccountRoleId")
            Else
                Return New TimeLiveFileHelperTableAdapters.AccountRoleTableAdapter().GetDataByAccountId(DBUtilities.GetSessionAccountId).Rows(0)("AccountRoleId")
            End If

        ElseIf ParameterName = "AccountClientId" Then
            Dim dt As TimeLiveFileHelper.AccountPartyExportDataTable = New TimeLiveFileHelperTableAdapters.AccountPartyExportTableAdapter().GetDataByPartyName(DBUtilities.GetSessionAccountId, ParameterValue)
            If dt.Rows.Count > 0 Then
                Return dt.Rows(0)("AccountPartyId")

            Else
                Throw New Exception("Error in importing: client """ + ParameterValue + """ not exist")
            End If

        ElseIf ParameterName = "ProjectStatusId" Then
            Dim dt As TimeLiveFileHelper.AccountStatusDataTable
            dt = New TimeLiveFileHelperTableAdapters.AccountStatusTableAdapter().GetDataByStatus(DBUtilities.GetSessionAccountId, ParameterValue)
            If dt.Rows.Count > 0 Then
                Return dt.Rows(0)("AccountStatusId")
            Else
                dt = New TimeLiveFileHelperTableAdapters.AccountStatusTableAdapter().GetDataByAccountIdForProject(DBUtilities.GetSessionAccountId)
                Return dt.Rows(0)("AccountStatusId")
            End If

        ElseIf ParameterName = "LeaderEmployeeId" Then
            If ParameterValue = "" Then
                Throw New Exception("Error in importing: Field ""LeaderName"" is required.")
            End If
            Dim dt As TimeLiveFileHelper.vueAccountEmployeeDataTable = New TimeLiveFileHelperTableAdapters.vueAccountEmployeeTableAdapter().GetDataByEmployeeName(DBUtilities.GetSessionAccountId, ParameterValue)
            If dt.Rows.Count > 0 Then
                Return dt.Rows(0)("AccountEmployeeId")
            Else
                Return DBUtilities.GetSessionAccountEmployeeId
            End If

        ElseIf ParameterName = "ProjectManagerEmployeeId" Then
            If ParameterValue = "" Then
                Throw New Exception("Error in importing: Field ""ProjectManagerName"" is required.")
            End If
            Dim dt As TimeLiveFileHelper.vueAccountEmployeeDataTable = New TimeLiveFileHelperTableAdapters.vueAccountEmployeeTableAdapter().GetDataByEmployeeName(DBUtilities.GetSessionAccountId, ParameterValue)
            If dt.Rows.Count > 0 Then
                Return dt.Rows(0)("AccountEmployeeId")
            Else
                Return DBUtilities.GetSessionAccountEmployeeId
            End If

        ElseIf ParameterName = "TimeSheetApprovalTypeId" Then
            If ParameterValue = "" Then
                Return 0
            End If
            Dim dt As TimeLiveFileHelper.AccountApprovalTypeDataTable
            dt = New TimeLiveFileHelperTableAdapters.AccountApprovalTypeTableAdapter().GetDataByAccountIdAndApprovalTypeName(DBUtilities.GetSessionAccountId, ParameterValue)
            If dt.Rows.Count > 0 Then
                Return dt.Rows(0)("AccountApprovalTypeId")
            Else
                Throw New Exception("Error in importing: Timesheet Approval Type """ + ParameterValue + """ not exist")
            End If

        ElseIf ParameterName = "ExpenseApprovalTypeId" Then
            If ParameterValue = "" Then
                Return 0
            End If
            Dim dt As TimeLiveFileHelper.AccountApprovalTypeDataTable
            dt = New TimeLiveFileHelperTableAdapters.AccountApprovalTypeTableAdapter().GetDataByAccountIdAndApprovalTypeName(DBUtilities.GetSessionAccountId, ParameterValue)
            If dt.Rows.Count > 0 Then
                Return dt.Rows(0)("AccountApprovalTypeId")
            Else
                Throw New Exception("Error in importing: Expense Approval Type """ + ParameterValue + """ not exist")
            End If

        ElseIf ParameterName = "TimeOffApprovalTypeId" Then
            If ParameterValue = "" Then
                Return 0
            End If
            Dim dt As TimeLiveFileHelper.AccountApprovalTypeDataTable
            dt = New TimeLiveFileHelperTableAdapters.AccountApprovalTypeTableAdapter().GetDataByAccountIdAndApprovalTypeNameForTimeOff(DBUtilities.GetSessionAccountId, ParameterValue)
            If dt.Rows.Count > 0 Then
                Return dt.Rows(0)("AccountApprovalTypeId")
            Else
                Throw New Exception("Error in importing: Time Off Approval Type """ + ParameterValue + """ not exist")
            End If

        ElseIf ParameterName = "EmployeeManagerId" Then
            If ParameterValue = "" Then
                Return 0
            End If
            Dim dt As TimeLiveFileHelper.vueAccountEmployeeDataTable = New TimeLiveFileHelperTableAdapters.vueAccountEmployeeTableAdapter().GetDataByEmployeeName(DBUtilities.GetSessionAccountId, ParameterValue)
            If dt.Rows.Count > 0 Then
                Return dt.Rows(0)("AccountEmployeeId")
            Else
                Return 0
            End If

        ElseIf ParameterName = "AccountEmployeeId" Then
            Dim dt As TimeLiveFileHelper.vueAccountEmployeeDataTable = New TimeLiveFileHelperTableAdapters.vueAccountEmployeeTableAdapter().GetDataByEmailAddress(DBUtilities.GetSessionAccountId, ParameterValue)
            If dt.Rows.Count > 0 Then
                AccountEmployeeId = dt.Rows(0)("AccountEmployeeId")
                EmployeeName = dt.Rows(0)("EmployeeName")
                Return dt.Rows(0)("AccountEmployeeId")
            Else
                Throw New Exception("Error in importing: employee """ + ParameterValue + """ not exist")
            End If

        ElseIf ParameterName = "AccountProjectId" Then
            If DataName = "Projects Team" Or DataName = "Project Task" Then
                ParameterValue = Replace(ParameterValue, "'", "''")
                Dim dt As TimeLiveFileHelper.AccountProjectDataTable = New TimeLiveFileHelperTableAdapters.AccountProjectTableAdapter().GetDataByProjectName(DBUtilities.GetSessionAccountId, ParameterValue)
                If dt.Rows.Count > 0 Then
                    AccountProjectId = Convert.ToInt32(dt.Rows(0)("AccountProjectId"))
                    ProjectName = ParameterValue
                    Return Convert.ToInt32(dt.Rows(0)("AccountProjectId"))
                Else
                    Throw New Exception("Error in importing: project """ + ParameterValue + """ not exist")
                End If
            Else
                Dim objProjectBll As New AccountProjectBLL
                ParameterValue = Replace(ParameterValue, "'", "''")
                Dim dt As TimeLiveDataSet.AccountProjectDataTable = objProjectBll.GetAssignedAccountProjectsByAccountEmployeeIdAndAccountProjectIdForProjectsForImportExport(0, AccountEmployeeId, LocaleUtilitiesBLL.IsShowCompletedProjectsInTimeSheet, False, DBUtilities.GetSessionAccountId, ParameterValue)
                If dt.Rows.Count > 0 Then
                    AccountProjectId = Convert.ToInt32(dt.Rows(0)("AccountProjectId"))
                    ProjectName = ParameterValue
                    Return Convert.ToInt32(dt.Rows(0)("AccountProjectId"))
                Else
                    Throw New Exception("Error in importing: project """ + ParameterValue + """ not exist for this employee """ + EmployeeName + """")
                End If
            End If
        ElseIf ParameterName = "AccountProjectTaskId" Then
            Dim dt As TimeLiveFileHelper.vueAccountProjectTaskDataTable
            If AccountProjectId <> 0 Then
                If DataName = "Tasks Users" Then
                    dt = New TimeLiveFileHelperTableAdapters.vueAccountProjectTaskTableAdapter().GetDataByAccountProjectIdAndTaskName(DBUtilities.GetSessionAccountId, AccountProjectId, ParameterValue)
                    If dt.Rows.Count > 0 Then
                        Return Convert.ToInt32(dt.Rows(0)("AccountProjectTaskId"))
                    Else
                        Throw New Exception("Error in importing: task """ + ParameterValue + """ not exist in this project """ + ProjectName + """")
                    End If
                Else
                    If Not Me.GetAssignedAccountProjectTaskId(AccountProjectId, DBUtilities.GetSessionAccountId, ParameterValue, AccountEmployeeId) = Nothing Then
                        Return Me.GetAssignedAccountProjectTaskId(AccountProjectId, DBUtilities.GetSessionAccountId, ParameterValue, AccountEmployeeId)
                    Else
                        Throw New Exception("Error in importing: task """ + ParameterValue + """ not exist in this project """ + ProjectName + """ for this employee """ + EmployeeName + """")
                    End If
                End If
            Else
                dt = New TimeLiveFileHelperTableAdapters.vueAccountProjectTaskTableAdapter().GetDataByTaskName(DBUtilities.GetSessionAccountId, ParameterValue)
                If dt.Rows.Count > 0 Then
                    Return Convert.ToInt32(dt.Rows(0)("AccountProjectTaskId"))
                Else
                    Throw New Exception("Error in importing: task """ + ParameterValue + """ not exist")
                End If
            End If

        ElseIf ParameterName = "AccountPartyId" Then
            Dim dt As TimeLiveFileHelper.AccountPartyExportDataTable = New TimeLiveFileHelperTableAdapters.AccountPartyExportTableAdapter().GetDataByPartyName(DBUtilities.GetSessionAccountId, ParameterValue)
            If dt.Rows.Count > 0 Then
                Return dt.Rows(0)("AccountPartyId")
            Else
                Throw New Exception("Error in importing: party name """ + ParameterValue + """ not exist")
            End If

        ElseIf ParameterName = "AccountWorkTypeId" Then
            If ParameterValue = "" Then
                ParameterValue = New TimeLiveDataSetTableAdapters.AccountWorkTypeTableAdapter().GetDataByAccountIdAndAccountWorkType(DBUtilities.GetSessionAccountId).Rows(0)("AccountWorkType")
            End If
            Dim dt As TimeLiveFileHelper.AccountWorkTypeDataTable = New TimeLiveFileHelperTableAdapters.AccountWorkTypeTableAdapter().GetDataByAccountWorkType(DBUtilities.GetSessionAccountId, ParameterValue)
            If dt.Rows.Count > 0 Then
                Return dt.Rows(0)("AccountWorkTypeId")
            Else
                Return New TimeLiveDataSetTableAdapters.AccountWorkTypeTableAdapter().GetDataByAccountIdAndAccountWorkType(DBUtilities.GetSessionAccountId).Rows(0)("AccountWorkTypeId")
            End If

        ElseIf ParameterName = "AccountExpenseId" Then
            Dim dt As TimeLiveFileHelper.AccountExpenseDataTable = New TimeLiveFileHelperTableAdapters.AccountExpenseTableAdapter().GetDataByAccountExpenseName(DBUtilities.GetSessionAccountId, ParameterValue)
            If dt.Rows.Count > 0 Then
                Return dt.Rows(0)("AccountExpenseId")
            Else
                Throw New Exception("Error in importing: expense """ + ParameterValue + """ not exist")
            End If

        ElseIf ParameterName = "AccountCurrencyId" Then
            If ParameterValue = "" Then
                ParameterValue = New TimeLiveFileHelperTableAdapters.vueAccountCurrencyTableAdapter().GetDataByAccountId(DBUtilities.GetSessionAccountId).Rows(0)("CurrencyCode")
            End If
            Dim dt As TimeLiveFileHelper.vueAccountCurrencyDataTable = New TimeLiveFileHelperTableAdapters.vueAccountCurrencyTableAdapter().GetDataByCurrencyCode(DBUtilities.GetSessionAccountId, ParameterValue)
            If dt.Rows.Count > 0 Then
                Return dt.Rows(0)("AccountCurrencyId")
            Else
                Return New TimeLiveFileHelperTableAdapters.vueAccountCurrencyTableAdapter().GetDataByAccountId(DBUtilities.GetSessionAccountId).Rows(0)("AccountCurrencyId")
            End If

        ElseIf ParameterName = "AccountTaxZoneId" Then
            Dim dt As TimeLiveFileHelper.AccountTaxZoneDataTable = New TimeLiveFileHelperTableAdapters.AccountTaxZoneTableAdapter().GetDataByAccountTaxZone(DBUtilities.GetSessionAccountId, ParameterValue)
            If dt.Rows.Count > 0 Then
                Return dt.Rows(0)("AccountTaxZoneId")
            Else
                Throw New Exception("Error in importing: tax zone """ + ParameterValue + """ not exist")
            End If

        ElseIf ParameterName = "AccountPaymentMethodId" And ParameterValue <> "" Then
            Dim dt As TimeLiveFileHelper.AccountPaymentMethodDataTable = New TimeLiveFileHelperTableAdapters.AccountPaymentMethodTableAdapter().GetDataByPaymentMethod(DBUtilities.GetSessionAccountId, ParameterValue)
            If dt.Rows.Count > 0 Then
                Return dt.Rows(0)("AccountPaymentMethodId")
            Else
                Throw New Exception("Error in importing: payment method """ + ParameterValue + """ not exist")
            End If

        ElseIf ParameterName = "ParentAccountProjectTaskId" And ParameterValue <> "" Then
            Dim dt As TimeLiveFileHelper.vueAccountProjectTaskDataTable
            If AccountProjectId <> 0 Then
                dt = New TimeLiveFileHelperTableAdapters.vueAccountProjectTaskTableAdapter().GetParentTaskByTaskNameAndProjectId(AccountProjectId, ParameterValue)
                If dt.Rows.Count > 0 Then
                    Return Convert.ToInt32(dt.Rows(0)("AccountProjectTaskId"))
                Else
                    Throw New Exception("Error in importing: parent task """ + ParameterValue + """ not exist")
                End If
            Else
                dt = New TimeLiveFileHelperTableAdapters.vueAccountProjectTaskTableAdapter().GetDataByTaskName(DBUtilities.GetSessionAccountId, ParameterValue)
                If dt.Rows.Count > 0 Then
                    Return Convert.ToInt32(dt.Rows(0)("AccountProjectTaskId"))
                Else
                    Throw New Exception("Error in importing: parent task """ + ParameterValue + """ not exist")
                End If
            End If
        ElseIf ParameterName = "AccountTaskTypeId" Then
            Dim dt As TimeLiveFileHelper.AccountTaskTypeDataTable
            dt = New TimeLiveFileHelperTableAdapters.AccountTaskTypeTableAdapter().GetDataByTaskType(DBUtilities.GetSessionAccountId, ParameterValue)
            If dt.Rows.Count > 0 Then
                Return dt.Rows(0)("AccountTaskTypeId")
            Else
                Return New TimeLiveFileHelperTableAdapters.AccountTaskTypeTableAdapter().GetDataByAccountId(DBUtilities.GetSessionAccountId).Rows(0)("AccountTaskTypeId")
            End If

        ElseIf ParameterName = "TaskStatusId" Then
            Dim dt As TimeLiveFileHelper.AccountStatusDataTable
            dt = New TimeLiveFileHelperTableAdapters.AccountStatusTableAdapter().GetDataByStatusForTask(DBUtilities.GetSessionAccountId, ParameterValue)
            If dt.Rows.Count > 0 Then
                Return dt.Rows(0)("AccountStatusId")
            Else
                Return New TimeLiveFileHelperTableAdapters.AccountStatusTableAdapter().GetDataByAccountId(DBUtilities.GetSessionAccountId).Rows(0)("AccountStatusId")
            End If

        ElseIf ParameterName = "AccountPriorityId" Then
            Dim dt As TimeLiveFileHelper.AccountPriorityDataTable
            dt = New TimeLiveFileHelperTableAdapters.AccountPriorityTableAdapter().GetDataByPriority(DBUtilities.GetSessionAccountId, ParameterValue)
            If dt.Rows.Count > 0 Then
                Return dt.Rows(0)("AccountPriorityId")
            Else
                Return New TimeLiveFileHelperTableAdapters.AccountPriorityTableAdapter().GetDataByAccountId(DBUtilities.GetSessionAccountId).Rows(0)("AccountPriorityId")
            End If

        ElseIf ParameterName = "AccountTimeOffTypeId" Then
            Dim dt As TimeLiveFileHelper.AccountTimeOffTypeDataTable
            dt = New TimeLiveFileHelperTableAdapters.AccountTimeOffTypeTableAdapter().GetDataByAccountTimeOffType(DBUtilities.GetSessionAccountId, ParameterValue)
            If dt.Rows.Count > 0 Then
                Return dt.Rows(0)("AccountTimeOffTypeId")
            Else
                Return New TimeLiveFileHelperTableAdapters.AccountTimeOffTypeTableAdapter().GetDataByAccountId(DBUtilities.GetSessionAccountId).Rows(0)("AccountTimeOffTypeId")
            End If

        ElseIf ParameterName = "AccountProjectMilestoneId" Then
            Dim dt As TimeLiveFileHelper.AccountProjectMilestoneDataTable
            If ParameterValue <> "" And AccountProjectId <> 0 Then
                dt = New TimeLiveFileHelperTableAdapters.AccountProjectMilestoneTableAdapter().GetDataByAccountProjectIdAndAccountId(DBUtilities.GetSessionAccountId, AccountProjectId, ParameterValue)
                If dt.Rows.Count > 0 Then
                    Return Convert.ToInt32(dt.Rows(0)("AccountProjectMilestoneId"))
                Else
                    dt = New TimeLiveFileHelperTableAdapters.AccountProjectMilestoneTableAdapter().GetDataByAccountProjectId(AccountProjectId)
                    If dt.Rows.Count > 0 Then
                        Return Convert.ToInt32(dt.Rows(0)("AccountProjectMilestoneId"))
                    Else
                        Dim AccountProjectMilestones As New AccountProjectMilestoneBLL
                        AccountProjectMilestones.AddAccountProjectMilestone(DBUtilities.GetSessionAccountId, AccountProjectId, System.Web.HttpContext.GetGlobalResourceObject("TimeLive.Web", "Default Milestone"), Date.Now, Date.Now, DBUtilities.GetSessionAccountEmployeeId, Date.Now, DBUtilities.GetSessionAccountEmployeeId, "", False)
                        Return Convert.ToInt32(New TimeLiveFileHelperTableAdapters.AccountProjectMilestoneTableAdapter().GetDataByAccountProjectId(AccountProjectId).Rows(0)("AccountProjectMilestoneId"))
                    End If
                End If
            End If

        ElseIf ParameterName = "ProjectBillingRateTypeId" Then
            Dim dt As TimeLiveFileHelper.SystemProjectBillingRateTypeDataTable = New TimeLiveFileHelperTableAdapters.SystemProjectBillingRateTypeTableAdapter().GetData(ParameterValue)
            If dt.Rows.Count > 0 Then
                Return dt.Rows(0)("SystemProjectBillingRateTypeId")
            Else
                Throw New Exception("Error in importing: project billing rate type """ + ParameterValue + """ not exist")
            End If

        ElseIf ParameterName = "Prefix" Then
            If ParameterValue = "" Then
                Return "Mr."
            Else
                If ParameterValue <> "Mr." Or ParameterValue <> "Mrs." Or ParameterValue <> "Miss" Then
                    Return "Mr."
                End If
            End If
        ElseIf ParameterName = "IsBillable" Then
            If System.Boolean.TryParse(ParameterValue, True) = False Then
                Return Convert.ToBoolean("True")
            ElseIf ParameterValue <> "" Then
                Return Convert.ToBoolean(ParameterValue)
            End If
        ElseIf ParameterName = "IsActive" Then
            If System.Boolean.TryParse(ParameterValue, True) = False Then
                Return Convert.ToBoolean("False")
            ElseIf ParameterValue <> "" Then
                Return Convert.ToBoolean(ParameterValue)
            End If
        ElseIf ParameterName = "Approved" Then
            If System.Boolean.TryParse(ParameterValue, True) = False Then
                Return Convert.ToBoolean("False")
            ElseIf ParameterValue <> "" Then
                Return Convert.ToBoolean(ParameterValue)
            End If
        ElseIf ParameterName = "Rejected" Then
            If System.Boolean.TryParse(ParameterValue, True) = False Then
                Return Convert.ToBoolean("False")
            ElseIf ParameterValue <> "" Then
                Return Convert.ToBoolean(ParameterValue)
            End If
        ElseIf ParameterName = "Submitted" Then
            If System.Boolean.TryParse(ParameterValue, True) = False Then
                Return Convert.ToBoolean("False")
            ElseIf ParameterValue <> "" Then
                Return Convert.ToBoolean(ParameterValue)
            End If

        ElseIf ParameterName = "Completed" Then
            If System.Boolean.TryParse(ParameterValue, True) = False Then
                Return Convert.ToBoolean("False")
            ElseIf ParameterValue <> "" Then
                Return Convert.ToBoolean(ParameterValue)
            End If
        ElseIf ParameterName = "IsParentTask" Then
            If System.Boolean.TryParse(ParameterValue, True) = False Then
                Return Convert.ToBoolean("False")
            ElseIf ParameterValue <> "" Then
                Return Convert.ToBoolean(ParameterValue)
            End If
        ElseIf ParameterName = "IsForAllEmployees" Then
            If System.Boolean.TryParse(ParameterValue, True) = False Then
                Return Convert.ToBoolean("False")
            ElseIf ParameterValue <> "" Then
                Return Convert.ToBoolean(ParameterValue)
            End If
        ElseIf ParameterName = "IsReOpen" Then
            If System.Boolean.TryParse(ParameterValue, True) = False Then
                Return Convert.ToBoolean("False")
            ElseIf ParameterValue <> "" Then
                Return Convert.ToBoolean(ParameterValue)
            End If
        ElseIf ParameterName = "IsTemplate" Then
            If System.Boolean.TryParse(ParameterValue, True) = False Then
                Return Convert.ToBoolean("False")
            ElseIf ParameterValue <> "" Then
                Return Convert.ToBoolean(ParameterValue)
            End If
        ElseIf ParameterName = "IsForAllProjectTask" Then
            If System.Boolean.TryParse(ParameterValue, True) = False Then
                Return Convert.ToBoolean("False")
            ElseIf ParameterValue <> "" Then
                Return Convert.ToBoolean(ParameterValue)
            End If
        ElseIf ParameterName = "DurationUnit" Then
            If ParameterValue = "" Then
                Return "Days"
            End If
        ElseIf ParameterName = "EstimatedDurationUnit" Then
            If ParameterValue = "" Then
                Return "Days"
            End If
        ElseIf ParameterName = "BillingTypeId" Then
            Dim dt As TimeLiveFileHelper.AccountBillingTypeDataTable = New TimeLiveFileHelperTableAdapters.AccountBillingTypeTableAdapter().GetDataByBillingType(DBUtilities.GetSessionAccountId)
            Return dt.Rows(0)("AccountBillingTypeId")

        ElseIf ParameterName = "AccountWorkingDayTypeId" Then
            Dim dt As TimeLiveFileHelper.AccountWorkingDayTypeDataTable = New TimeLiveFileHelperTableAdapters.AccountWorkingDayTypeTableAdapter().GetDataByWorkingDayType(DBUtilities.GetSessionAccountId, ParameterValue)
            If dt.Rows.Count > 0 Then
                Return dt.Rows(0)("AccountWorkingDayTypeId")
            Else
                Return New TimeLiveFileHelperTableAdapters.AccountWorkingDayTypeTableAdapter().GetDataByAccountId(DBUtilities.GetSessionAccountId).Rows(0)("AccountWorkingDayTypeId")
            End If
        ElseIf ParameterName = "AccountHolidayTypeId" Then
            Dim dt As TimeLiveFileHelper.AccountHolidayTypeDataTable = New TimeLiveFileHelperTableAdapters.AccountHolidayTypeTableAdapter().GetDataByHolidayType(DBUtilities.GetSessionAccountId, ParameterValue)
            If dt.Rows.Count > 0 Then
                Return dt.Rows(0)("AccountHolidayTypeId")
            Else
                Return New TimeLiveFileHelperTableAdapters.AccountWorkingDayTypeTableAdapter().GetDataByAccountId(DBUtilities.GetSessionAccountId).Rows(0)("AccountWorkingDayTypeId")
            End If

        ElseIf ParameterName = "AccountTimeOffPolicyId" Then
            Dim dt As TimeLiveFileHelper.AccountTimeOffPolicyDataTable = New TimeLiveFileHelperTableAdapters.AccountTimeOffPolicyTableAdapter().GetDataByAccountTimeOffPolicy(DBUtilities.GetSessionAccountId, ParameterValue)
            If dt.Rows.Count > 0 Then
                Return dt.Rows(0)("AccountTimeOffPolicyId")
                'Else
                '    Return New TimeLiveFileHelperTableAdapters.AccountTimeOffPolicyTableAdapter().GetDataByAccountId(DBUtilities.GetSessionAccountId).Rows(0)("AccountTimeOffPolicyId")
            End If

        ElseIf ParameterName = "EmployeePayTypeId" Then
            Dim dt As TimeLiveFileHelper.AccountEmployeeTypeDataTable = New TimeLiveFileHelperTableAdapters.AccountEmployeeTypeTableAdapter().GetDataByAccountEmployeeType(DBUtilities.GetSessionAccountId, ParameterValue)
            If dt.Rows.Count > 0 Then
                Return dt.Rows(0)("AccountEmployeeTypeId")
            Else
                Return New TimeLiveFileHelperTableAdapters.AccountEmployeeTypeTableAdapter().GetDataByAccountId(DBUtilities.GetSessionAccountId).Rows(0)("AccountEmployeeTypeId")
            End If

        ElseIf ParameterName = "AccountProjectTypeId" Then
            Dim dt As TimeLiveFileHelper.AccountProjectTypeDataTable = New TimeLiveFileHelperTableAdapters.AccountProjectTypeTableAdapter().GetDataByProjectType(DBUtilities.GetSessionAccountId, ParameterValue)
            If dt.Rows.Count > 0 Then
                Return dt.Rows(0)("AccountProjectTypeId")
            Else
                Return New TimeLiveFileHelperTableAdapters.AccountProjectTypeTableAdapter().GetData(DBUtilities.GetSessionAccountId).Rows(0)("AccountProjectTypeId")
            End If

        ElseIf ParameterName = "AccountCostCenterId" Then
            Dim dt As TimeLiveFileHelper.AccountCostCenterDataTable = New TimeLiveFileHelperTableAdapters.AccountCostCenterTableAdapter().GetDataByAccountCostCenter(DBUtilities.GetSessionAccountId, ParameterValue)
            If dt.Rows.Count > 0 Then
                Return dt.Rows(0)("AccountCostCenterId")
            Else
                Return New TimeLiveFileHelperTableAdapters.AccountCostCenterTableAdapter().GetData(DBUtilities.GetSessionAccountId).Rows(0)("AccountCostCenterId")
            End If

        ElseIf ParameterName = "AccountWorkingDayTypeId" Then
            Dim dt As TimeLiveFileHelper.AccountWorkingDayTypeDataTable = New TimeLiveFileHelperTableAdapters.AccountWorkingDayTypeTableAdapter().GetDataByWorkingDayType(DBUtilities.GetSessionAccountId, ParameterValue)
            If dt.Rows.Count > 0 Then
                Return dt.Rows(0)("AccountWorkingDayTypeId")
            Else
                Return New TimeLiveFileHelperTableAdapters.AccountWorkingDayTypeTableAdapter().GetDataByAccountId(DBUtilities.GetSessionAccountId).Rows(0)("AccountWorkingDayTypeId")
            End If
        ElseIf ParameterName = "AccountHolidayTypeId" Then
            Dim dt As TimeLiveFileHelper.AccountHolidayTypeDataTable = New TimeLiveFileHelperTableAdapters.AccountHolidayTypeTableAdapter().GetDataByHolidayType(DBUtilities.GetSessionAccountId, ParameterValue)
            If dt.Rows.Count > 0 Then
                Return dt.Rows(0)("AccountHolidayTypeId")
            Else
                Return New TimeLiveFileHelperTableAdapters.AccountHolidayTypeTableAdapter().GetDataByAccountId(DBUtilities.GetSessionAccountId).Rows(0)("AccountHolidayTypeId")
            End If

        ElseIf ParameterName = "AccountTimeOffPolicyId" Then
            Dim dt As TimeLiveFileHelper.AccountTimeOffPolicyDataTable = New TimeLiveFileHelperTableAdapters.AccountTimeOffPolicyTableAdapter().GetDataByAccountTimeOffPolicy(DBUtilities.GetSessionAccountId, ParameterValue)
            If dt.Rows.Count > 0 Then
                Return dt.Rows(0)("AccountTimeOffPolicyId")
            Else
                Return New TimeLiveFileHelperTableAdapters.AccountTimeOffPolicyTableAdapter().GetDataByAccountId(DBUtilities.GetSessionAccountId).Rows(0)("AccountTimeOffPolicyId")
            End If

        ElseIf ParameterName = "EmployeePayTypeId" Then
            Dim dt As TimeLiveFileHelper.AccountEmployeeTypeDataTable = New TimeLiveFileHelperTableAdapters.AccountEmployeeTypeTableAdapter().GetDataByAccountEmployeeType(DBUtilities.GetSessionAccountId, ParameterValue)
            If dt.Rows.Count > 0 Then
                Return dt.Rows(0)("AccountEmployeeTypeId")
            Else
                Return New TimeLiveFileHelperTableAdapters.AccountEmployeeTypeTableAdapter().GetDataByAccountId(DBUtilities.GetSessionAccountId).Rows(0)("AccountEmployeeTypeId")
            End If
        End If
    End Function
    Public Function GetForeignColumnName(ByVal ParameterName As String, ByVal DataName As String, Optional ByVal IsUpdate As Boolean = False) As String
        If ParameterName = "Country" Then
            Return "CountryId"
        ElseIf ParameterName = "AccountLocation" Then
            Return "AccountLocationId"
        ElseIf ParameterName = "DepartmentName" And DataName <> "Department" Then
            Return "AccountDepartmentId"
        ElseIf ParameterName = "Role" Then
            Return "AccountRoleId"
        ElseIf ParameterName = "PartyName" And DataName = "Projects" Then
            Return "AccountClientId"
        ElseIf ParameterName = "PartyName" And DataName = "Time Entry" Then
            Return "AccountPartyId"
        ElseIf ParameterName = "Status" Then
            Return "ProjectStatusId"
        ElseIf ParameterName = "LeaderName" Then
            Return "LeaderEmployeeId"
        ElseIf ParameterName = "ProjectManagerName" Then
            Return "ProjectManagerEmployeeId"
        ElseIf ParameterName = "EMailAddress" And DataName = "Time Entry" Then
            Return "AccountEmployeeId"
        ElseIf ParameterName = "EMailAddress" And DataName = "Expense Entry" Then
            Return "AccountEmployeeId"
        ElseIf ParameterName = "EMailAddress" And DataName = "Tasks Users" Then
            Return "AccountEmployeeId"
        ElseIf ParameterName = "EMailAddress" And DataName = "Projects Team" Then
            Return "AccountEmployeeId"
        ElseIf ParameterName = "EMailAddress" And DataName = "Projects Roles" Then
            Return "AccountEmployeeId"
        ElseIf ParameterName = "ProjectName" And DataName <> "Projects" Then
            Return "AccountProjectId"
        ElseIf ParameterName = "TaskName" And DataName <> "Project Task" Then
            Return "AccountProjectTaskId"
        ElseIf ParameterName = "AccountWorkType" Then
            Return "AccountWorkTypeId"
        ElseIf ParameterName = "AccountExpenseName" Then
            Return "AccountExpenseId"
        ElseIf ParameterName = "CurrencyCode" Then
            Return "AccountCurrencyId"
        ElseIf ParameterName = "AccountTaxZone" Then
            Return "AccountTaxZoneId"
        ElseIf ParameterName = "PaymentMethod" Then
            Return "AccountPaymentMethodId"
        ElseIf ParameterName = "ParentTaskName" Then
            Return "ParentAccountProjectTaskId"
        ElseIf ParameterName = "TaskType" Then
            Return "AccountTaskTypeId"
        ElseIf ParameterName = "TaskStatus" Then
            Return "TaskStatusId"
        ElseIf ParameterName = "Priority" Then
            Return "AccountPriorityId"
        ElseIf ParameterName = "MilestoneDescription" Then
            Return "AccountProjectMilestoneId"
        ElseIf ParameterName = "ProjectBillingRateType" Then
            Return "ProjectBillingRateTypeId"
        ElseIf ParameterName = "BillingType" Then
            Return "BillingTypeId"
        ElseIf ParameterName = "NetAmount" Then
            Return "AmountBeforeTax"
        ElseIf ParameterName = "AccountWorkingDayType" Then
            Return "AccountWorkingDayTypeId"
        ElseIf ParameterName = "AccountHolidayType" Then
            Return "AccountHolidayTypeId"
        ElseIf ParameterName = "AccountEmployeeType" Then
            Return "EmployeePayTypeId"
        ElseIf ParameterName = "AccountTimeOffPolicy" Then
            Return "AccountTimeOffPolicyId"
        ElseIf ParameterName = "ProjectType" Then
            Return "AccountProjectTypeId"
        ElseIf ParameterName = "AccountCostCenter" Then
            Return "AccountCostCenterId"
        ElseIf ParameterName = "EmployeeManager" Then
            Return "EmployeeManagerId"
        ElseIf ParameterName = "EMailAddress" And DataName = "Time Off Request" Then
            Return "AccountEmployeeId"
        ElseIf ParameterName = "EMailAddress" And DataName = "Time Off" Then
            Return "AccountEmployeeId"
        ElseIf ParameterName = "AccountTimeOffType" Then
            Return "AccountTimeOffTypeId"
        ElseIf ParameterName = "TimesheetApprovalTypeName" Then
            Return "TimeSheetApprovalTypeId"
        ElseIf ParameterName = "ExpenseApprovalTypeName" Then
            Return "ExpenseApprovalTypeId"
        ElseIf ParameterName = "TimeOffApprovalType" Then
            Return "TimeOffApprovalTypeId"
        ElseIf ParameterName = "AccountPartyId" And DataName = "Client" And IsUpdate = True Then
            Return "Original_AccountPartyId"
        ElseIf ParameterName = "AccountEmployeeId" And DataName = "Employee" And IsUpdate = True Then
            Return "Original_AccountEmployeeId"
        Else
            Return ParameterName
        End If
    End Function
    Public Function GetDefaultValue(ByVal ParameterName As String, ByVal dtMappings As DataTable, ByVal DataName As String, ByVal objRow As DataRow, OfflineTimesheet As Boolean, Optional ByVal IsUpdate As Boolean = False) As Object
        If ParameterName = "AccountId" Then
            Return DBUtilities.GetSessionAccountId
        ElseIf ParameterName = "CreatedOn" Or ParameterName = "ModifiedOn" Or ParameterName = "DeadlineDate" Then
            Return Now
        ElseIf ParameterName = "CreatedByEmployeeId" Or ParameterName = "ModifiedByEmployeeId" Or ParameterName = "LeaderEmployeeId" Or ParameterName = "ProjectManagerEmployeeId" Then
            Return DBUtilities.GetSessionAccountEmployeeId
        ElseIf ParameterName = "IsDisabled" Then
            Return False
        ElseIf ParameterName = "IsDeleted" Then
            Return False
        ElseIf ParameterName = "DefaultCurrencyId" Then
            Dim returnValue As Nullable(Of Short)
            returnValue = 1
            Return returnValue
        ElseIf ParameterName = "BillingRateCurrencyId" Then
            Dim returnValue As Nullable(Of Short)
            returnValue = 1
            Return returnValue
        ElseIf ParameterName = "CreatedByEmployeeId" Then
            Return DBUtilities.GetSessionAccountEmployeeId
        ElseIf ParameterName = "CreatedByEmployeeId" Then
            Return DBUtilities.GetSessionAccountEmployeeId
        ElseIf ParameterName = "CreatedByEmployeeId" Then
            Return DBUtilities.GetSessionAccountEmployeeId
        ElseIf ParameterName = "TimeZoneId" Then
            Return DBUtilities.GetTimeZoneId
        ElseIf ParameterName = "ProjectStatusId" Then
            Dim dt As TimeLiveFileHelper.AccountStatusDataTable
            dt = New TimeLiveFileHelperTableAdapters.AccountStatusTableAdapter().GetDataByAccountIdForProject(DBUtilities.GetSessionAccountId)
            Return dt.Rows(0)("AccountStatusId")
        ElseIf ParameterName = "AccountProjectTypeId" Then
            Return New TimeLiveFileHelperTableAdapters.AccountProjectTypeTableAdapter().GetData(DBUtilities.GetSessionAccountId()).Rows(0)("AccountProjectTypeId")
        ElseIf ParameterName = "ProjectBillingTypeId" Then
            Return New TimeLiveFileHelperTableAdapters.AccountBillingTypeTableAdapter().GetProjectDataByAccountId(DBUtilities.GetSessionAccountId()).Rows(0)("AccountBillingTypeId")
            'ElseIf ParameterName = "TimeSheetApprovalTypeId" Then
            '    Return 0
            'ElseIf ParameterName = "ExpenseApprovalTypeId" Then
            '    Return 0
        ElseIf ParameterName = "PartyNick" Then
            Return ""
        ElseIf ParameterName = "CountryId" Then
            Dim returnValue As Nullable(Of Short)
            returnValue = DBUtilities.GetAccountCountryId
            Return returnValue
        ElseIf ParameterName = "EMailAddress" Then
            If DataName = "Client" And IsUpdate = True Then
                Return ""
            Else
                Dim EmailAddress As String = Me.GetCSVColumnValueOfDBColumn(objRow, "FirstName", dtMappings, DataName) & Me.GetCSVColumnValueOfDBColumn(objRow, "LastName", dtMappings, DataName) & "@dummy.com"
                Return EmailAddress
            End If
        ElseIf ParameterName = "Username" Then
            Dim EmailAddress As String = Me.GetCSVColumnValueOfDBColumn(objRow, "FirstName", dtMappings, DataName) & Me.GetCSVColumnValueOfDBColumn(objRow, "LastName", dtMappings, DataName) & "@dummy.com"
            Return EmailAddress
        ElseIf ParameterName = "Password" Then
            Return ""
        ElseIf ParameterName = "AccountLocationId" Then
            Return New TimeLiveFileHelperTableAdapters.AccountLocationTableAdapter().GetDataByAccountId(DBUtilities.GetSessionAccountId).Rows(0)("AccountLocationId")
        ElseIf ParameterName = "AccountDepartmentId" Then
            Return New TimeLiveFileHelperTableAdapters.AccountDepartmentTableAdapter().GetDataByAccountId(DBUtilities.GetSessionAccountId).Rows(0)("AccountDepartmentId")

        ElseIf ParameterName = "AccountRoleId" Then
            Return New TimeLiveFileHelperTableAdapters.AccountRoleTableAdapter().GetDataByAccountId(DBUtilities.GetSessionAccountId).Rows(0)("AccountRoleId")
        ElseIf ParameterName = "ProjectBillingRateTypeId" Then
            Return 1 ' Use Employee Own Billing Rate
        ElseIf ParameterName = "ProjectDescription" Or ParameterName = "ProjectCode" Then
            Return ""
        ElseIf ParameterName = "StartDate" Or ParameterName = "Deadline" Then
            Return Now.Date
        ElseIf ParameterName = "AccountWorkTypeId" Then
            Return New TimeLiveDataSetTableAdapters.AccountWorkTypeTableAdapter().GetDataByAccountIdAndAccountWorkType(DBUtilities.GetSessionAccountId).Rows(0)("AccountWorkTypeId")
        ElseIf ParameterName = "AccountCurrencyId" Then
            Return New TimeLiveFileHelperTableAdapters.vueAccountCurrencyTableAdapter().GetDataByAccountId(DBUtilities.GetSessionAccountId).Rows(0)("AccountCurrencyId")
        ElseIf ParameterName = "AccountPaymentMethodId" Then
            Dim returnValue As Nullable(Of Integer)
            returnValue = 0
            Return returnValue
        ElseIf ParameterName = "AccountTaskTypeId" Then
            Return New TimeLiveFileHelperTableAdapters.AccountTaskTypeTableAdapter().GetDataByAccountId(DBUtilities.GetSessionAccountId).Rows(0)("AccountTaskTypeId")
        ElseIf ParameterName = "AccountPriorityId" Then
            Return New TimeLiveFileHelperTableAdapters.AccountPriorityTableAdapter().GetDataByAccountId(DBUtilities.GetSessionAccountId).Rows(0)("AccountPriorityId")
        ElseIf ParameterName = "AccountProjectMilestoneId" Then
            If AccountProjectId <> 0 Then
                Dim dt As TimeLiveFileHelper.AccountProjectMilestoneDataTable
                dt = New TimeLiveFileHelperTableAdapters.AccountProjectMilestoneTableAdapter().GetDataByAccountProjectId(AccountProjectId)
                If dt.Rows.Count > 0 Then
                    Return Convert.ToInt32(dt.Rows(0)("AccountProjectMilestoneId"))
                Else
                    Dim AccountProjectMilestones As New AccountProjectMilestoneBLL
                    AccountProjectMilestones.AddAccountProjectMilestone(DBUtilities.GetSessionAccountId, AccountProjectId, System.Web.HttpContext.GetGlobalResourceObject("TimeLive.Web", "Default Milestone"), Date.Now, Date.Now, DBUtilities.GetSessionAccountEmployeeId, Date.Now, DBUtilities.GetSessionAccountEmployeeId, "", False)
                    Return Convert.ToInt32(New TimeLiveFileHelperTableAdapters.AccountProjectMilestoneTableAdapter().GetDataByAccountProjectId(AccountProjectId).Rows(0)("AccountProjectMilestoneId"))
                End If
            End If
        ElseIf ParameterName = "TaskStatusId" Then
            Return New TimeLiveFileHelperTableAdapters.AccountStatusTableAdapter().GetDataByAccountId(DBUtilities.GetSessionAccountId).Rows(0)("AccountStatusId")
        ElseIf ParameterName = "EstimatedCurrencyId" Then
            Return New TimeLiveFileHelperTableAdapters.vueAccountCurrencyTableAdapter().GetDataByAccountId(DBUtilities.GetSessionAccountId).Rows(0)("AccountCurrencyId")
        ElseIf ParameterName = "DurationUnit" Or ParameterName = "EstimatedDurationUnit" Then
            Return "Days"
        ElseIf ParameterName = "Prefix" Then
            Return "Mr."
        ElseIf ParameterName = "AccountCostCenterId" Then
            Return New TimeLiveFileHelperTableAdapters.AccountCostCenterTableAdapter().GetData(DBUtilities.GetSessionAccountId).Rows(0)("AccountCostCenterId")
        ElseIf ParameterName = "RowsCountEqual" Then
            Return RowsCountEqual
        ElseIf ParameterName = "OfflineTimesheet" Then
            Return OfflineTimesheet
        ElseIf ParameterName = "UserInterfaceLanguage" Then
            Return LocaleUtilitiesBLL.GetCurrentUICulture
        Else
            Return Nothing
        End If
    End Function
    Public Function GetAllColumnsOfDBDataTable(ByVal dtTable As DataTable) As DataTable
        Dim objTable As New DataTable
        objTable.Columns.Add("DBColumnName", GetType(System.String), "")
        objTable.Columns.Add("FileColumnName", GetType(System.String), "")
        objTable.Columns.Add("Required", GetType(System.String), "")

        Dim objRow As DataRow
        For Each objColumn As DataColumn In dtTable.Columns

            objRow = objTable.NewRow()
            objRow("DBColumnName") = objColumn.ColumnName
            objRow("FileColumnName") = ""
            objRow("Required") = IIf(objColumn.AllowDBNull = False, "Required", "")

            objTable.Rows.Add(objRow)
        Next

        objTable.AcceptChanges()

        Return objTable


    End Function
    Public Function GetAllColumnsOfCSVDataTable(ByVal dtTable As DataTable) As DataTable
        Dim objTable As New DataTable
        objTable.Columns.Add("DBColumnName", GetType(System.String), "")
        objTable.Columns.Add("FileColumnName", GetType(System.String), "")

        Dim objRow As DataRow
        For Each objColumn As DataColumn In dtTable.Columns

            objRow = objTable.NewRow()
            objRow("DBColumnName") = ""
            objRow("FileColumnName") = objColumn.ColumnName

            objTable.Rows.Add(objRow)
        Next

        objTable.AcceptChanges()

        Return objTable


    End Function
    'Public Function GetAllColumnsOfMProjectDataTable(ByVal dtTable As DataTable) As DataTable
    '    Dim objTable As New DataTable
    '    objTable.Columns.Add("DBColumnName", GetType(System.String), "")
    '    objTable.Columns.Add("FileColumnName", GetType(System.String), "")

    '    Dim objRow As DataRow
    '    For Each objColumn As DataColumn In dtTable.Columns

    '        objRow = objTable.NewRow()
    '        objRow("DBColumnName") = ""
    '        objRow("FileColumnName") = objColumn.ColumnName

    '        objTable.Rows.Add(objRow)
    '    Next

    '    objTable.AcceptChanges()

    '    Return objTable


    'End Function
    Public Function GetDataTableFromAdapterForImport(ByVal strDataSource As String, Optional ByVal IsUpdate As Boolean = False) As DataTable
        Dim assem As Assembly = Assembly.GetExecutingAssembly
        Dim objType As String
        If IsUpdate = True Then
            objType = Me.GetExportDataSourceByName(strDataSource, True)("ExportAdapterName")
        Else
            objType = Me.GetExportDataSourceByName(strDataSource, True)("ImportAdapterName")
        End If
        Dim ins As Object = assem.CreateInstance(objType)
        Dim dt As DataTable = ins.GetData(DBUtilities.GetSessionAccountId)
        Return dt
    End Function
    Public Function GetDataTableFromAdapterForExport(ByVal strDataSource As String, ByVal ExportType As String, ByVal StartDate As DateTime, ByVal EndDate As DateTime, ByVal AccountEmployeeId As Integer, ByVal ProjectId As String, ByVal WhereClause As String, Optional ByVal OfflineTimesheet As Boolean = False) As DataTable

        Dim assem As Assembly = Assembly.GetExecutingAssembly
        Dim objType As String
        If ExportType = "Quickbooks" Then
            objType = Me.GetExportDataSourceByName(strDataSource)("QBExportAdapterName")
        Else
            objType = Me.GetExportDataSourceByName(strDataSource)("ExportAdapterName")
        End If
        Dim ins As Object = assem.CreateInstance(objType)
        Dim ShowFilter As Boolean = Me.GetExportDataSourceByName(strDataSource)("ShowFilter")
        Dim ShowProjectFilter As Boolean = Me.GetExportDataSourceByName(strDataSource)("ShowProjectFilter")
        Dim dt As DataTable
        If strDataSource = "Time Entry" Then
            Return GetDataTableByExportTypeForTimeEntry(ExportType, WhereClause, OfflineTimesheet)
        Else
            If ShowFilter = True Then
                If AccountEmployeeId = -1 Then
                    dt = ins.GetDataByAll(DBUtilities.GetSessionAccountId, StartDate, EndDate)
                    Return dt
                Else
                    dt = ins.GetData(DBUtilities.GetSessionAccountId, StartDate, EndDate, AccountEmployeeId)
                    Return dt
                End If
            ElseIf ShowProjectFilter = True Then
                If ProjectId = -1 Then
                    dt = ins.GetDataByAll(DBUtilities.GetSessionAccountId)
                    Return dt
                Else
                    dt = ins.GetData(DBUtilities.GetSessionAccountId, ProjectId)
                    Return dt
                End If
            Else
                If strDataSource = "Projects" Or strDataSource = "Employee" Then
                    If LicensingBLL.IsHostedFreeCustomerLicenseExpired(DBUtilities.GetSessionAccountId) Then
                        dt = ins.GetDataByAccountIdTop3(DBUtilities.GetSessionAccountId)
                    Else
                        dt = ins.GetData(DBUtilities.GetSessionAccountId)
                    End If
                Else
                    dt = ins.GetData(DBUtilities.GetSessionAccountId)
                End If

                Return dt
            End If
        End If
    End Function
    Public Function GetDataTableFromMProjectAdapterForExport(ByVal strDataSource As String, ByVal ExportType As String, ByVal ProjectId As String, ByVal WhereClause As String) As DataTable

        Dim assem As Assembly = Assembly.GetExecutingAssembly
        Dim objType As String
        If ExportType = "MProject" Then
            objType = Me.GetExportDataSourceByName(strDataSource)("MPExportAdapterName")
        End If
        Dim ins As Object = assem.CreateInstance(objType)
        Dim ShowFilter As Boolean = Me.GetExportDataSourceByName(strDataSource)("ShowFilter")
        Dim ShowProjectFilter As Boolean = Me.GetExportDataSourceByName(strDataSource)("ShowProjectFilter")
        Dim dt As DataTable
        If strDataSource = "Time Entry" Then
            Return GetDataTableByExportTypeForTimeEntry(ExportType, WhereClause)
        Else
            If ProjectId = -1 Then
                dt = ins.GetDataByAll(DBUtilities.GetSessionAccountId)
                Return dt
            Else
                dt = ins.GetData(DBUtilities.GetSessionAccountId, ProjectId)
                Return dt
            End If
            Return dt
        End If
    End Function
    Public Function GetDataTableByExportTypeForTimeEntry(ByVal ExportType As String, ByVal WhereClause As String, Optional ByVal OfflineTimesheet As Boolean = False) As DataTable
        If ExportType = "Quickbooks" Then
            Return New TimeLiveFileHelperTableAdapters.AccountEmployeeTimeEntryExportQBTableAdapter().GetDataByAccountId(WhereClause)
        Else
            If OfflineTimesheet Then
                Return New TimeLiveFileHelperTableAdapters.AccountEmployeeTimeEntryExportForOfflineTimesheetTableAdapter().GetDataByAccountIdForOfflineTimesheet(WhereClause)
            Else
                If DBUtilities.IsTimeEntryHoursFormat = "Decimal" Then
                    Return New TimeLiveFileHelperTableAdapters.AccountEmployeeTimeEntryExportTableAdapter().GetDecimalDataByAccountId(WhereClause)
                Else
                    Return New TimeLiveFileHelperTableAdapters.AccountEmployeeTimeEntryExportTableAdapter().GetDataByAccountId(WhereClause)
                End If

            End If
        End If
    End Function
    Public Function RecursivelyDeleteOneDayOldCSVFiles()
        Dim directory As String = System.Configuration.ConfigurationManager.AppSettings("UploadFilesPath")
        Dim strRoot As String = System.Web.Hosting.HostingEnvironment.MapPath(directory)
        'System.Web.HttpContext.Current.Request.MapPath(directory)
        Me.DeleteCSVFile(strRoot)
    End Function
    Public Function DeleteCSVFile(ByVal dir As String) As Boolean
        Try
            If Not System.IO.Directory.Exists(dir) Then
                Exit Function
            Else
                Dim names As String() = Directory.GetFiles(dir, "*.csv*", SearchOption.AllDirectories)
                For Each file As String In names
                    If DateDiff("d", FileDateTime(file), Now) >= 1 Then
                        System.IO.File.Delete(file)
                    End If
                Next
            End If
        Catch ex As Exception
        End Try
    End Function
    Public Function GetAssignedAccountProjectTaskId(ByVal AccountProjectId As Integer, ByVal AccountId As Integer, ByVal TaskName As String, ByVal AccountEmployeeId As Integer) As Integer
        Dim objTaskBll As New AccountProjectTaskBLL
        Dim dt As TimeLiveDataSet.AccountProjectTaskTimesheetDataTable = objTaskBll.GetAssignedProjectTasksForImportExport(AccountProjectId, AccountEmployeeId, 0, AccountId, LocaleUtilitiesBLL.IsShowCompletedTasksInTimeSheet, TaskName)
        Dim dr As TimeLiveDataSet.AccountProjectTaskTimesheetRow
        If dt.Rows.Count > 0 Then
            dr = dt.Rows(0)
            Return Convert.ToInt32(dr.AccountProjectTaskId)
        End If
        Return Nothing
    End Function
    Public Function GetProjectNameByAccountProjectId(ByVal AccountProjectId As Integer) As String
        Dim dt As TimeLiveDataSet.AccountProjectDataTable = New AccountProjectBLL().GetAccountProjectsByAccountProjectId(AccountProjectId)
        If dt.Rows.Count > 0 Then
            Return dt.Rows(0)("ProjectName")
        End If
    End Function
    Public Function GetEmployeeNameByAccountEmployeeId(ByVal AccountEmployeeId As Integer) As String
        Dim dt As AccountEmployee.AccountEmployeeDataTable = New AccountEmployeeBLL().GetAccountEmployeesByAccountEmployeeId(AccountEmployeeId)
        If dt.Rows.Count > 0 Then
            Return dt.Rows(0)("FirstName")
        End If
    End Function

End Class
