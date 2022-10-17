Partial Class Employee_Controls_ctlAccountCostCenterEmployee
    Inherits System.Web.UI.UserControl
    Dim IsEmployeeUpdate As Boolean
    ''' <summary>
    ''' gridview databound event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub GridView1_DataBound(ByVal sender As Object, ByVal e As System.EventArgs)
        If Me.GridView1.Rows.Count <> 0 Then
            'Me.CheckAll.Visible = True
            'Me.UnCheckAll.Visible = True
            Me.Update.Visible = True
        Else
            'Me.CheckAll.Visible = False
            'Me.UnCheckAll.Visible = False
            Me.Update.Visible = False
        End If
        'TODO: CheckAll function
        'Each time the data is bound to the grid we need to build up the CheckBoxIDs array

        'Get the header CheckBox
        If Me.GridView1.Rows.Count <> 0 Then
            Dim cbHeader As CheckBox = CType(GridView1.HeaderRow.FindControl("chkCheckAll"), CheckBox)
            'Run the ChangeCheckBoxState client-side function whenever the
            'header checkbox is checked/unchecked
            cbHeader.Attributes("onclick") = "ChangeAllCheckBoxStates(this.checked);"
            For Each gvr As GridViewRow In GridView1.Rows
                'Get a programmatic reference to the CheckBox control
                Dim cb As CheckBox = CType(gvr.FindControl("chkselect"), CheckBox)
                'Add the CheckBox's ID to the client-side CheckBoxIDs array
                ScriptManager.RegisterArrayDeclaration(Me, "CheckBoxIDs", String.Concat("'", cb.ClientID, "'"))
            Next
        End If
    End Sub
    ''' <summary>
    ''' grdiview rowdatabound event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)

    End Sub
    ''' <summary>
    ''' gridview pageindex event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        Me.UpdateCostCenterEmployee()
        Me.GridView1.PageIndex = e.NewPageIndex
    End Sub
    ''' <summary>
    ''' set gridview row updating event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub GridView1_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles GridView1.RowUpdating

    End Sub
    ''' <summary>
    ''' set objectdatasource row inserting event 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub dsAccountProjectEmployee_Inserting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceMethodEventArgs)
        'e.InputParameters("AccountBillingRateId") = 7
    End Sub
    ''' <summary>
    ''' set show not found message
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ShowNotFoundMessage()

    End Sub
    ''' <summary>
    ''' Page load event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AccountPagePermissionBLL.SetPagePermissionForGridViewAndButton(152, Me.GridView1, Me.Update)
        If Me.IsPostBack Then
            'Me.UpdateProjectEmployees()
        End If
        ''Me.Update.Enabled = AccountPagePermissionBLL.SetPagePermissionForGridViewAndButton(152, Me.GridView1, Me.Update)
    End Sub
    ''' <summary>
    ''' Update records
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub Update_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Update.Click
        IsEmployeeUpdate = True
        Me.UpdateCostCenterEmployee()
    End Sub
    ''' <summary>
    ''' Update records.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub UpdateCostCenterEmployee()
        Dim CostCenterEmployeeBLL As New AccountCostCenterBLL
        Dim row As GridViewRow
        Try
            For Each row In Me.GridView1.Rows
                If CType(row.FindControl("chkSelect"), CheckBox).Checked = True And IsDBNull(Me.GridView1.DataKeys(row.RowIndex).Item(0)) Then
                    CostCenterEmployeeBLL.AddAccountCostCenterEmployee(Me.GridView1.DataKeys(row.RowIndex)(1), DBUtilities.GetSessionAccountId, Me.Request.QueryString("AccountEmployeeId"))
                ElseIf CType(row.FindControl("chkSelect"), CheckBox).Checked = False And Not IsDBNull(Me.GridView1.DataKeys(row.RowIndex).Item(0)) Then
                    CostCenterEmployeeBLL.DeleteAccountCostCenterEmployee(Me.GridView1.DataKeys(row.RowIndex).Item(0))
                End If
            Next
        Catch ex As Exception
            Throw ex
        End Try
        If IsEmployeeUpdate = True Then
            Response.Redirect("~/AccountAdmin/AccountEmployees.aspx", False)
        End If
    End Sub
End Class
