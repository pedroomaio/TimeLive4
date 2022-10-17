Partial Class AccountAdmin_Controls_ctlAccountAttachments
    Inherits System.Web.UI.UserControl

    Dim AccountExpenseEntryId As Integer
    Dim AccountEmployeeTimeEntryPeriodId As Guid
    Protected Sub dsAccountAttachmentsFormViewObject_Inserted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles dsAccountAttachmentsFormViewObject.Inserted
        DBUtilities.AfterInsert(Me.GridView1)
    End Sub
    Protected Sub dsAccountAttachmentsFormViewObject_Inserting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceMethodEventArgs) Handles dsAccountAttachmentsFormViewObject.Inserting
        DBUtilities.SetRowForInserting(e)
    End Sub
    Protected Sub dsAccountAttachmentsFormViewObject_Updated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles dsAccountAttachmentsFormViewObject.Updated
        DBUtilities.AfterUpdate(Me.GridView1)
    End Sub
    Protected Sub dsAccountAttachmentsFormViewObject_Updating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceMethodEventArgs) Handles dsAccountAttachmentsFormViewObject.Updating
        DBUtilities.SetRowForInserting(e)
    End Sub
    Private Function FindControlRecursive(ByVal root As Control, ByVal id As String) As Control
        If root.ID = id Then
            Return root
        End If
        Dim c As Control
        For Each c In root.Controls
            Dim t As Control = FindControlRecursive(c, id)
            If Not t Is Nothing Then
                Return t
            End If
        Next
        Return Nothing
    End Function
    Public Function GetAccountExpenseEntryIdAndExpenseName() As Boolean

        Dim dtExpense As TimeLiveDataSet.vueAccountExpenseEntryDataTable = New AccountExpenseEntryBLL().GetvueAccountExpenseEntriesByAccountExpenseEntryId(AccountExpenseEntryId)
        Dim drExpense As TimeLiveDataSet.vueAccountExpenseEntryRow

        If dtExpense.Rows.Count > 0 Then
            drExpense = dtExpense.Rows(0)
            CType(Me.FormView2.FindControl("txtExpenseEntryId"), TextBox).Text = drExpense.AccountExpenseEntryId
            CType(Me.FormView2.FindControl("txtExpenseName"), TextBox).Text = drExpense.AccountExpenseName
            CType(Me.FormView2.FindControl("txtAmount"), TextBox).Text = drExpense.CurrencyCode & " " & drExpense.Amount
        End If
    End Function
    Public Function GetTimeEntryPeriodData() As Boolean
        Dim EmployeeTimeEntryPeriodId As Guid
        If Not Me.Request.QueryString("AccountEmployeeTimeEntryPeriodId") Is Nothing Then
            EmployeeTimeEntryPeriodId = New Guid(Me.Request.QueryString("AccountEmployeeTimeEntryPeriodId"))
        End If
        CType(Me.FormView2.FindControl("Literal1"), Literal).Text = "Timesheet Period Information"
        CType(Me.FormView2.FindControl("Literal2"), Literal).Text = "Employee Name:"
        CType(Me.FormView2.FindControl("Literal3"), Literal).Text = "Period:"
        CType(Me.FormView2.FindControl("Literal4"), Literal).Text = "Status:"

        Dim dtExpense As AccountEmployeeTimeEntry.vueAccountEmployeeTimeEntryPeriodDataTable = New AccountEmployeeTimeEntryBLL().GetvueAccountEmployeeTimeEntryPeriodByAccountEmployeeTimeEntryPeriodId(EmployeeTimeEntryPeriodId)
        Dim drExpense As AccountEmployeeTimeEntry.vueAccountEmployeeTimeEntryPeriodRow

        If dtExpense.Rows.Count > 0 Then
            drExpense = dtExpense.Rows(0)
            CType(Me.FormView2.FindControl("txtExpenseEntryId"), TextBox).Text = drExpense.TimeEntryEmployeeName
            CType(Me.FormView2.FindControl("txtExpenseName"), TextBox).Text = drExpense.TimeEntryStartDate & " - " & drExpense.TimeEntryEndDate
            CType(Me.FormView2.FindControl("txtAmount"), TextBox).Text = drExpense.AccountEmployeeId

            If drExpense.Submitted = False And drExpense.Rejected = False And drExpense.Approved = False And drExpense.InApproval = False Then
                CType(Me.FormView2.FindControl("txtAmount"), TextBox).Text = "Not Submitted"
            ElseIf drExpense.Submitted = True And drExpense.Approved = True And drExpense.Rejected = False Then
                CType(Me.FormView2.FindControl("txtAmount"), TextBox).Text = ResourceHelper.GetFromResource("Approved")
            ElseIf drExpense.Rejected = True And drExpense.Submitted = False Then
                CType(Me.FormView2.FindControl("txtAmount"), TextBox).Text = "Rejected"
            ElseIf drExpense.Submitted = True And drExpense.Rejected = False And drExpense.Approved = False And drExpense.InApproval = True Then
                CType(Me.FormView2.FindControl("txtAmount"), TextBox).Text = "Submitted"
            ElseIf drExpense.Submitted = True And drExpense.Rejected = False And drExpense.Approved = False And drExpense.InApproval = False Then
                CType(Me.FormView2.FindControl("txtAmount"), TextBox).Text = "Submitted"
            ElseIf drExpense.Submitted = False And drExpense.Approved = True Then
                CType(Me.FormView2.FindControl("txtAmount"), TextBox).Text = "Not Submitted"
            ElseIf drExpense.Submitted = False And drExpense.InApproval = True Then
                CType(Me.FormView2.FindControl("txtAmount"), TextBox).Text = "Not Submitted"
            End If
        End If
    End Function

    Public Function GetIsExpenseEntryApproved() As Boolean

        Dim dtExpense As TimeLiveDataSet.AccountExpenseEntryDataTable = New AccountExpenseEntryBLL().GetAccountExpenseEntriesByAccountExpenseEntryId(AccountExpenseEntryId)
        Dim drExpense As TimeLiveDataSet.AccountExpenseEntryRow
        If dtExpense.Rows.Count > 0 Then
            drExpense = dtExpense.Rows(0)
            If (drExpense.Approved = True And drExpense.Rejected = False) Then Return True
        End If
        Return False

    End Function
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If AuthenticateBLL.IsNewSession() Then
            AuthenticateBLL.DoLogout(Me.Page)
        End If
        If Me.Request.QueryString("AccountAttachmentTypeId") = 1 Then
            AccountExpenseEntryId = Me.Request.QueryString("AccountExpenseEntryId")
            If Me.GetIsExpenseEntryApproved() = True Then
                CType(Me.FormView1.FindControl("btnUpload"), Button).Enabled = False
            End If
            Me.GetAccountExpenseEntryIdAndExpenseName()
            Else
                Me.GetTimeEntryPeriodData()
        End If

        Dim ScriptManager As System.Web.UI.ScriptManager = Me.FindControlRecursive(Me.Page, "ScriptManager2")
        ScriptManager.RegisterPostBackControl(Me.FormView1.FindControl("btnUpload"))
    End Sub
    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        Dim strFileName As String
        If Me.Request.QueryString("AccountAttachmentTypeId") = 1 Then
            AccountExpenseEntryId = IIf(Not Request.QueryString("AccountExpenseEntryId") Is Nothing, Request.QueryString("AccountExpenseEntryId"), 64)
        Else
            AccountEmployeeTimeEntryPeriodId = New Guid(Me.Request.QueryString("AccountEmployeeTimeEntryPeriodId"))
        End If

        Dim strUploadPath As String = System.Configuration.ConfigurationManager.AppSettings("UploadFilesPath")
        Dim strRoot As String = System.Web.HttpContext.Current.Server.MapPath(strUploadPath)

        If e.CommandName = "Delete" Then
            Dim objRow As GridViewRow = Me.GridView1.Rows(e.CommandArgument)
            If Me.Request.QueryString("AccountAttachmentTypeId") = 1 Then
                strFileName = strRoot & DBUtilities.GetSessionAccountId & "\" & AccountExpenseEntryId & "\" & CType(objRow.FindControl("FileHyperlink"), HyperLink).Text
            Else
                strFileName = strRoot & DBUtilities.GetSessionAccountId & "\" & AccountEmployeeTimeEntryPeriodId.ToString & "\" & CType(objRow.FindControl("FileHyperlink"), HyperLink).Text
            End If
            If System.IO.File.Exists(strFileName) Then
                ' Try
                System.IO.File.Delete(strFileName)
                'Catch ex As Exception
                ' R 'esponse.Write(ex.Message)
                'End Try
            End If
        End If

    End Sub
    Protected Sub GridView1_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowCreated
        If e.Row.RowType = DataControlRowType.DataRow Then
            ' Retrieve the LinkButton control from the first column.
            Dim Delete As LinkButton = CType(e.Row.Cells(3).Controls(1), LinkButton)
            ' Set the LinkButton's CommandArgument property with the
            ' row's index.
            Delete.CommandArgument = e.Row.RowIndex.ToString()
        End If
    End Sub
    Dim AttachmentBll As New AccountAttachmentsBLL
    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        UIUtilities.ClearCellsForNoRecords(e.Row)
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim AttachmentLocalPath As String
            Dim strRoot1 As String
            If IsDBNull(DataBinder.Eval(e.Row.DataItem, "AttachmentLocalPath")) Then
                AttachmentLocalPath = ""
            Else
                AttachmentLocalPath = "/" & Server.UrlEncode(DataBinder.Eval(e.Row.DataItem, "AttachmentLocalPath"))
            End If
            If Me.Request.QueryString("AccountAttachmentTypeId") = 2 Then
                AccountEmployeeTimeEntryPeriodId = New Guid(Me.Request.QueryString("AccountEmployeeTimeEntryPeriodId"))
            End If

            Dim strUploadPath As String = System.Configuration.ConfigurationManager.AppSettings("UploadFilesPath")
            Dim strRoot As String = System.Web.HttpContext.Current.Server.MapPath(strUploadPath)
            If Me.Request.QueryString("AccountAttachmentTypeId") = 1 Then
                strRoot1 = strRoot & DBUtilities.GetSessionAccountId & "/" & DataBinder.Eval(e.Row.DataItem, "AccountExpenseEntryId") & AttachmentLocalPath
            Else
                strRoot1 = strRoot & DBUtilities.GetSessionAccountId & "/" & AccountEmployeeTimeEntryPeriodId.ToString & AttachmentLocalPath
            End If
            Dim DecodeStrRoot As String = Server.UrlDecode(strRoot1)

            If System.IO.File.Exists(DecodeStrRoot) Then
                Dim i As String
                If Me.Request.QueryString("AccountAttachmentTypeId") = 1 Then
                    i = LicensingBLL.GetEncryptedStringAsBase64ByUTF8("FileName=" & DBUtilities.GetSessionAccountId & "/" & DataBinder.Eval(e.Row.DataItem, "AccountExpenseEntryId") & AttachmentLocalPath)
                Else
                    i = LicensingBLL.GetEncryptedStringAsBase64ByUTF8("FileName=" & DBUtilities.GetSessionAccountId & "/" & AccountEmployeeTimeEntryPeriodId.ToString & AttachmentLocalPath)
                End If
                Dim FileName As String = "~/Shared/FileDownload.aspx?" & i
                If Not e.Row.Cells(2).FindControl("FileHyperlink") Is Nothing Then
                    CType(e.Row.Cells(2).FindControl("FileHyperlink"), HyperLink).NavigateUrl = FileName
                End If

                ''If Not e.Row.Cells(3).FindControl("LinkButton1") Is Nothing And IIf(Me.Request.QueryString("AccountAttachmentTypeId") = 1, IsAccountAttachmentsLock(), False) Then
                If Not e.Row.Cells(3).FindControl("LinkButton1") Is Nothing And IIf(Me.Request.QueryString("AccountAttachmentTypeId") = 1, IsAccountAttachmentsLock(), False) Then
                    CType(e.Row.Cells(3).FindControl("LinkButton1"), LinkButton).Enabled = False
                    CType(e.Row.Cells(3).FindControl("LinkButton1"), LinkButton).Visible = False
                End If

            Else
                If Me.Request.QueryString("AccountAttachmentTypeId") = 1 Then
                    If Not DataBinder.Eval(e.Row.DataItem, "AccountAttachmentId") = 0 Then
                        AttachmentBll.DeleteAccountAttachments(DataBinder.Eval(e.Row.DataItem, "AccountAttachmentId"))
                        Me.GridView1.DataBind()
                    End If
                End If
            End If
        End If
    End Sub
    Private Function FileNameExist() As Boolean
        For index = 0 To GridView1.Rows.Count - 1
            If CType(GridView1.Rows(index).FindControl("FileHyperlink"), HyperLink).Text = CType(Me.FormView1.FindControl("AttachmentFileUpload"), FileUpload).FileName Then
                ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType(), "alert", "alert('" + ResourceHelper.GetFromResource("TimeOff Atts Alert Message") + "');", True)
                CType(FormView1.FindControl("txtAttachmentName"), TextBox).Text = ""
                Return True
            End If
        Next
        Return False
    End Function
    Protected Sub btnUpload_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim URL As String

        If Not FileNameExist() And Not Me.GetIsExpenseEntryApproved() Then
            AccountExpenseEntryId = IIf(Not Request.QueryString("AccountExpenseEntryId") Is Nothing, Request.QueryString("AccountExpenseEntryId"), 64)

            Dim BLL As New AccountAttachmentsBLL
            If Not Me.Request.QueryString("AccountEmployeeTimeEntryPeriodId") Is Nothing Then
                BLL.FileUpload(Me.FormView1.FindControl("AttachmentFileUpload"), Me.Request.QueryString("AccountAttachmentTypeId"), 0, DBUtilities.GetSessionAccountId, CType(Me.FormView1.FindControl("txtAttachmentName"), TextBox).Text, New Guid(Me.Request.QueryString("AccountEmployeeTimeEntryPeriodId")))
            Else
                BLL.FileUpload(Me.FormView1.FindControl("AttachmentFileUpload"), Me.Request.QueryString("AccountAttachmentTypeId"), IIf(Me.Request.QueryString("AccountAttachmentTypeId") = 1, AccountExpenseEntryId, 0), DBUtilities.GetSessionAccountId, CType(Me.FormView1.FindControl("txtAttachmentName"), TextBox).Text, System.Guid.Empty)
            End If

            Me.GridView1.DataBind()

            If Me.Request.QueryString("AccountAttachmentTypeId") = 1 Then
                URL = "~/AccountAdmin/AccountAttachmentsPopUp.aspx?AccountExpenseEntryId=" & Request.QueryString("AccountExpenseEntryId") & "&AccountAttachmentTypeId=" & Me.Request.QueryString("AccountAttachmentTypeId")
            Else
                URL = "~/AccountAdmin/AccountAttachmentsPopUp.aspx?AccountEmployeeTimeEntryPeriodId=" & Me.Request.QueryString("AccountEmployeeTimeEntryPeriodId") & "&AccountAttachmentTypeId=" & Me.Request.QueryString("AccountAttachmentTypeId")
            End If
            Response.Redirect(URL, False)
        End If


    End Sub
    Protected Sub FormView1_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FormView1.DataBound
        'AccountPagePermissionBLL.SetPagePermission(108, Me.GridView1, Me.FormView1, "btnUpload", 0, 3)
        If FormView1.CurrentMode = FormViewMode.Insert Then
            If IsAccountAttachmentsLock() Then
                CType(Me.FormView1.FindControl("btnUpload"), Button).Enabled = True
            End If

        End If
    End Sub
    Public Function IsAccountAttachmentsLock() As Boolean
        Dim AccountEmployeeExpenseSheetId As Guid
        If Not Me.Request.QueryString("AccountEmployeeExpenseSheetId") Is Nothing Then
            AccountEmployeeExpenseSheetId = New Guid(Me.Request.QueryString("AccountEmployeeExpenseSheetId"))
        End If
        Dim BLL As New AccountEmployeeExpenseSheetBLL
        Dim dt As AccountExpenseEntry.AccountEmployeeExpenseSheetDataTable = BLL.GetAccountEmployeeExpenseSheetByAccountEmployeeExpenseSheetId(AccountEmployeeExpenseSheetId)
        Dim dr As AccountExpenseEntry.AccountEmployeeExpenseSheetRow
        If dt.Rows.Count > 0 Then
            dr = dt.Rows(0)
            If (LocaleUtilitiesBLL.IsShowLockSubmittedRecords And dr.Submitted = True) Or (LocaleUtilitiesBLL.IsShowLockApprovedRecords And dr.Approved = True) Then
                Return True
            End If
        End If
    End Function
End Class
