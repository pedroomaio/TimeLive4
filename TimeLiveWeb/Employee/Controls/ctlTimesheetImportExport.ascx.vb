Imports System
Imports System.Collections
Imports System.Configuration
Imports System.Data
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.HtmlControls
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
''' <summary>
''' Controls for employee timer control 
''' </summary>
''' <remarks></remarks>
Partial Class Employee_Controls_ctlTimesheetImportExport
    Inherits System.Web.UI.UserControl
    Dim objDataTable As DataTable
    Dim objImportDataTable As DataTable
    Dim strMessage As String
    Protected Sub cmdProceed_Click(sender As Object, e As System.EventArgs) Handles cmdProceed.Click
        Dim importexportbll As New ImportExportBLL
        If txtFileUpload.HasFile Then
            Dim tempFile As String = importexportbll.UploadFile(Me.txtFileUpload, "Delimited")
            Me.ViewState("ImportTempFile") = tempFile
            Me.ReadAndFillColumnsMapping("Delimited", tempFile)
            Me.DoImport(Me.ViewState("ImportTempFile"))
            If Not strMessage Is Nothing Then
                RedirectAfterImport()
            End If
        End If
    End Sub
    Public Sub RedirectAfterImport()
        Dim Mode As String = Me.Request.QueryString("Mode")
        Dim TimeEntryAccountEmployeeId As Integer = Me.Request.QueryString("AccountEmployeeId")
        Dim strScript As String
        If Mode = "DayView" Then
            strScript = "alert('" & strMessage & "'); window.opener.location.href='AccountEmployeeTimeEntryDayView.aspx?Mode=Day&StartDate=" & Me.Request.QueryString("StartDate") & "&AccountEmployeeId=" & TimeEntryAccountEmployeeId & "'; window.close();"
        Else
            strScript = "alert('" & strMessage & "'); window.opener.location.href='AccountEmployeeTimeEntryPeriodView.aspx?Mode=Week&StartDate=" & Me.Request.QueryString("StartDate") & "&AccountEmployeeId=" & TimeEntryAccountEmployeeId & "'; window.close();"
        End If

        If (Not Me.Page.ClientScript.IsClientScriptBlockRegistered("clientScript")) Then
            ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "clientScript", strScript, True)
        End If
        strMessage = Nothing
    End Sub
    Public Sub ReadAndFillColumnsMapping(ByVal ExportType As String, ByVal tempFile As String)

        Dim objImportExportBLL As New ImportExportBLL
        objImportDataTable = objImportExportBLL.GetAllColumnMappingDataTableOfCSV(tempFile, ExportType)

        objDataTable = objImportExportBLL.GetAllColumnsOfDBForMapping("Time Entry")
        Me.GridView1.DataSource = objDataTable
        Me.GridView1.DataBind()
    End Sub
    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim objDropdown As DropDownList = CType(e.Row.FindControl("ddlFileColumnName"), DropDownList)
            objDropdown.DataTextField = "FileColumnName"
            objDropdown.DataValueField = "FileColumnName"
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
    Public Sub DoImport(ByVal tempFile As String)
        Dim RecordCount As Integer
        Dim chk As Integer = 0
        Try
            RecordCount = Me.DoDelimiatedImport()
        Catch ex As Exception
            lblException.Visible = True
            If Not ex.InnerException Is Nothing Then
                lblException.Text = ex.InnerException.Message
            Else
                lblException.Text = ex.Message
            End If
            chk = 1
        End Try
        If chk = 0 Then
            lblRowsInserted.Visible = True
            lblRowsInserted.Text = RecordCount & " record(s) imported"
            strMessage = RecordCount & " record(s) imported"
        End If
    End Sub
    Public Function DoDelimiatedImport() As Integer
        Dim bll As New ImportExportBLL
        Dim dtCSVFile As DataTable = New ImportExportBLL().GetDataTableOfCSV(Me.ViewState("ImportTempFile"), "Delimited")

        Dim Count As Integer
        Dim dtStartDate As DateTime = LocaleUtilitiesBLL.ConvertDateBaseToCurrentLocaleAsString(Me.Request.QueryString("StartDate"))
        Dim dtEndDate As DateTime = LocaleUtilitiesBLL.ConvertDateBaseToCurrentLocaleAsString(Me.Request.QueryString("EndDate"))
        System.Web.HttpContext.Current.Session.Add("OfflineTimesheetStartDate", LocaleUtilitiesBLL.ConvertDateBaseToCurrentLocaleAsString(Me.Request.QueryString("StartDate")))
        System.Web.HttpContext.Current.Session.Add("OfflineTimesheetEndDate", LocaleUtilitiesBLL.ConvertDateBaseToCurrentLocaleAsString(Me.Request.QueryString("EndDate")))
        System.Web.HttpContext.Current.Session.Add("OfflineTimesheetAccountEmployeeId", Me.Request.QueryString("AccountEmployeeId"))

        Dim dtMappings As DataTable = bll.GetMappingCollectionForCSV(Me.GridView1, "Time Entry")
        Count = bll.InsertRecords(dtMappings, "Time Entry", Me.ViewState("ImportTempFile"), "Delimited", Nothing, True)
        'Count = bll.InsertRecords(dtMappings, "Time Entry", Me.ViewState("ImportTempFile"), "Delimited", False, True)

        System.Web.HttpContext.Current.Session.Remove("OfflineTimesheetStartDate")
        System.Web.HttpContext.Current.Session.Remove("OfflineTimesheetEndDate")
        System.Web.HttpContext.Current.Session.Remove("OfflineTimesheetAccountEmployeeId")

        Me.GridView1.DataSource = Nothing
        Me.GridView1.DataBind()
        If Not System.Web.HttpContext.Current.Session("OfflineTimesheetCount") Is Nothing Then
            Count = System.Web.HttpContext.Current.Session("OfflineTimesheetCount")
        Else
            Count = 0
        End If
        System.Web.HttpContext.Current.Session.Remove("OfflineTimesheetCount")
        Return Count
    End Function
End Class