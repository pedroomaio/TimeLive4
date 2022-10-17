Partial Class WebReport_Reports_Controls_ctlMyReports
    Inherits System.Web.UI.UserControl
    Dim ReportBLL As New TimeLive.WebReport.ReportDesignBLL

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Response.Redirect("~/WebReport/ReportDesign.aspx", False)
    End Sub
    Public Sub ShowImage(ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        If Not IsDBNull(DataBinder.Eval(e.Row.DataItem, "ReportIconPath")) Then
            CType(e.Row.Cells(0).FindControl("ReportIconImage"), ImageButton).Visible = True
            Dim ImageURL As String
            Dim strIconPath As String = System.Web.HttpContext.Current.Server.MapPath("~" & DataBinder.Eval(e.Row.DataItem, "ReportIconPath"))
            If System.IO.File.Exists(strIconPath) Then
                ImageURL = "~" & DataBinder.Eval(e.Row.DataItem, "ReportIconPath")
            Else
                ImageURL = "~/Uploads/" & DBUtilities.GetSessionAccountId & "/ReportIcon/" & DataBinder.Eval(e.Row.DataItem, "ReportIconPath")
            End If
            CType(e.Row.Cells(0).FindControl("ReportIconImage"), ImageButton).ImageUrl = ImageURL
        Else
            If Not IsDBNull(DataBinder.Eval(e.Row.DataItem, "AccountReportId")) Then
                Dim SystemReportDataSourceId As Guid = ReportBLL.GetSystemReportDataSourceId(GetAccountReportId(DataBinder.Eval(e.Row.DataItem, "AccountReportId")))
                CType(e.Row.Cells(0).FindControl("ReportIconImage"), ImageButton).Visible = True
                CType(e.Row.Cells(0).FindControl("ReportIconImage"), ImageButton).ImageUrl = "~" & ReportBLL.GetDefaultIconPath(SystemReportDataSourceId)
            End If
        End If
    End Sub
    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand

    End Sub

    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            If IsDBNull(DataBinder.Eval(e.Row.DataItem, "AccountReportId")) Then
                e.Row.Cells(2).FindControl("CustomizeHyperLink").Visible = False
                e.Row.Cells(3).FindControl("PermissionHyperLink").Visible = False
                e.Row.Cells(4).FindControl("ReportIconImage").Visible = False
                CType(e.Row.Cells(0).FindControl("ReportNameHyperLink"), HyperLink).Visible = False
            Else
                IsCurrentReportHasPermissionOf(e)
                Dim bll As New ObjectPermissionBLL
            End If
            Me.ShowImage(e)

            If Not IsDBNull(DataBinder.Eval(e.Row.DataItem, "ReportPageName")) Then
                CType(e.Row.Cells(0).FindControl("ReportNameHyperLink"), HyperLink).NavigateUrl = "~/Reports/" & DataBinder.Eval(e.Row.DataItem, "ReportPageName") & "?AccountReportId=" & GetAccountReportId(DataBinder.Eval(e.Row.DataItem, "AccountReportId")).ToString
                CType(e.Row.Cells(0).FindControl("ReportIconImage"), ImageButton).PostBackUrl = "~/Reports/" & DataBinder.Eval(e.Row.DataItem, "ReportPageName") & "?AccountReportId=" & GetAccountReportId(DataBinder.Eval(e.Row.DataItem, "AccountReportId")).ToString
                e.Row.Cells(2).FindControl("CustomizeHyperLink").Visible = False
                e.Row.Cells(5).FindControl("CopyHyperLink").Visible = False
            End If
            SetNameByResource(e)
            If Not IsDBNull(DataBinder.Eval(e.Row.DataItem, "ReportName")) Then
                CType(e.Row.Cells(0).FindControl("ReportIconImage"), ImageButton).AlternateText = DataBinder.Eval(e.Row.DataItem, "ReportName")
            Else
                CType(e.Row.Cells(0).FindControl("ReportIconImage"), ImageButton).AlternateText = ""
            End If
        End If
    End Sub


    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting
       
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CopyReportAndRedirectToMyReports()
        SetPermissions()
        PopulatedGridViewData()
        Dim helper As New GridViewHelper(Me.GridView1)
        helper.RegisterGroup("AccountReportCategorySequence", True, True)
        helper.ApplyGroupSort()

    End Sub
    Public Sub CopyReportAndRedirectToMyReports()
        If Me.Request.QueryString("IsCopy") = "True" Then
            Dim BLL As New TimeLive.WebReport.ReportDesignBLL
            Dim AccountReportId As New Guid(Me.Request.QueryString("AccountReportId"))
            Dim NewReportId As Guid = BLL.CopyReportByReportId(AccountReportId)
            Response.Redirect("~/WebReport/ShowReport.aspx?AccountReportId=" & NewReportId.ToString, False)
        End If
    End Sub
    Public Sub SetPermissions()
        AccountPagePermissionBLL.SetPagePermissionForGridView(124, Me.GridView1, 2, 4)
        AccountPagePermissionBLL.SetPagePermissionForGridView(124, Me.GridView1, 3, 4)
        AccountPagePermissionBLL.SetPagePermissionForAddButton(124, Me.Button1)
        Me.GridView1.Columns(5).Visible = AccountPagePermissionBLL.IsPageHasPermissionOf(124, 2)
        If GridView1.Visible = False Then
            Button1.Visible = False
        End If
    End Sub
    Public Sub PopulatedGridViewData()
        Dim bll As New TimeLive.WebReport.ReportDesignBLL

        If AccountPagePermissionBLL.IsPageHasPermissionOfShowAllData(124) = True Then
            Me.dsAccountReportObject.SelectParameters("IsShowAll").DefaultValue = True
        ElseIf AccountPagePermissionBLL.IsPageHasPermissionOfShowMyData(124) = True Then
            Me.dsAccountReportObject.SelectParameters("IsShowAll").DefaultValue = False
            Me.dsAccountReportObject.SelectParameters("AccountRoles").DefaultValue = GetRoles()
        Else
            Me.dsAccountReportObject.SelectParameters("IsShowAll").DefaultValue = False
            Me.dsAccountReportObject.SelectParameters("AccountRoles").DefaultValue = GetRoles()
        End If

        GridView1.DataBind()
    End Sub
    Public Function GetRoles() As String
        Dim AccountRoles() As String = System.Web.Security.Roles.Provider.GetRolesForUser(System.Web.HttpContext.Current.Session("UserName"))

        Dim strRoles As String = ""
        For n As Integer = 0 To AccountRoles.Length - 1
            strRoles = strRoles & "'" & AccountRoles(n) & "'"
            If n + 1 <> AccountRoles.Length Then
                strRoles = strRoles + ","
            End If
        Next
        Return strRoles
    End Function
    Public Sub IsCurrentReportHasPermissionOf(ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        Dim AccountRoles() As String = System.Web.Security.Roles.Provider.GetRolesForUser(System.Web.HttpContext.Current.Session("UserName"))
        Dim strRoles As String = ""
        Dim AccountRoleId As Integer
        For n As Integer = 0 To AccountRoles.Length - 1
            strRoles = strRoles & AccountRoles(n)
            Dim BLL As New TimeLive.WebReport.ReportDesignBLL
            AccountRoleId = BLL.GetAccountRoleIdByRole(strRoles)
            If Not BLL.GetObjectPermissionDataRowByRole(GetAccountReportId(DataBinder.Eval(e.Row.DataItem, "AccountReportId")), AccountRoleId) Is Nothing Then
                Dim dr As dsObjectPermission.AccountObjectPermissionRow
                dr = BLL.GetObjectPermissionDataRowByRole(GetAccountReportId(DataBinder.Eval(e.Row.DataItem, "AccountReportId")), AccountRoleId)
                If dr.AllowCustomization = True Then
                    Me.GridView1.Columns(2).Visible = True
                    e.Row.Cells(2).FindControl("CustomizeHyperLink").Visible = True
                    e.Row.Cells(3).FindControl("PermissionHyperLink").Visible = True
                End If
            End If
            If AccountPagePermissionBLL.IsPageHasPermissionOf(124, 3) Then
                e.Row.Cells(2).FindControl("CustomizeHyperLink").Visible = True
                e.Row.Cells(3).FindControl("PermissionHyperLink").Visible = True
            End If
            strRoles = ""
        Next
    End Sub
    Public Function GetAccountReportId(ByVal strReportID As String) As Guid
        Dim AccountReportId As New Guid(strReportID)
        Return AccountReportId
    End Function
    Public Sub SetNameByResource(ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        If Not IsDBNull(DataBinder.Eval(e.Row.DataItem, "AccountReportId")) Then
            CType(e.Row.Cells(0).FindControl("ReportNameHyperLink"), HyperLink).Text = ResourceHelper.GetFromResource(DataBinder.Eval(e.Row.DataItem, "ReportName"))
            CType(e.Row.Cells(0).FindControl("ReportDescriptionLabel"), Label).Text = ResourceHelper.GetFromResource(DataBinder.Eval(e.Row.DataItem, "ReportDescription"))
            CType(e.Row.Cells(0).FindControl("ReportIconImage"), ImageButton).ToolTip = ResourceHelper.GetFromResource(DataBinder.Eval(e.Row.DataItem, "ReportName"))
        End If
    End Sub
End Class
