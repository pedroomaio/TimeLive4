
Partial Class AccountAdmin_Controls_ctlAccountTerminologyList
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AccountPagePermissionBLL.SetPagePermissionForGridViewAndButton(123, Me.GridView1, btnUpdate)
    End Sub

    Protected Sub btnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        Me.UpdateTerminology()
    End Sub
    Public Sub UpdateTerminology()
        Dim row As GridViewRow
        Dim TerminologyBLL As New AccountTerminologyBLL

        For Each row In Me.GridView1.Rows
            Try
                If CType(row.FindControl("chkSelect"), CheckBox).Checked = True And Not IsNumeric(Me.GridView1.DataKeys(row.RowIndex).Item(0)) Then
                    ValidateUserDefinedTextBox(row)
                    TerminologyBLL.AddAccountTerminology(DBUtilities.GetSessionAccountId, CType(row.FindControl("UserDefinedNameTextBox"), TextBox).Text, DBUtilities.GetSessionAccountEmployeeId, DBUtilities.GetSessionAccountEmployeeId, CType(row.FindControl("TerminologyNameTextBox"), TextBox).Text)
                ElseIf CType(row.FindControl("chkSelect"), CheckBox).Checked = True And IsNumeric(Me.GridView1.DataKeys(row.RowIndex).Item(0)) Then
                    ValidateUserDefinedTextBox(row)
                    TerminologyBLL.UpdateAccountTerminology(Me.GridView1.DataKeys(row.RowIndex).Item(0), CType(row.FindControl("UserDefinedNameTextBox"), TextBox).Text, DBUtilities.GetSessionAccountEmployeeId, CType(row.FindControl("TerminologyNameTextBox"), TextBox).Text)
                ElseIf CType(row.FindControl("chkSelect"), CheckBox).Checked = False And IsNumeric(Me.GridView1.DataKeys(row.RowIndex).Item(0)) Then
                    TerminologyBLL.DeleteAccountTerminology(Me.GridView1.DataKeys(row.RowIndex).Item(0))
                End If
            Catch ex As Exception
                CType(row.FindControl("lblException"), Label).Visible = True
                CType(row.FindControl("lblException"), Label).Text = ex.Message
                Exit Sub
            End Try
        Next
        UIUtilities.RedirectToAdminHomePage()
    End Sub
    Public Function IsDataChanged(ByVal row As GridViewRow) As Boolean
        Dim OldUserDefinedName As String = IIf(IsDBNull(Me.GridView1.DataKeys(row.RowIndex).Item(1)), "", Me.GridView1.DataKeys(row.RowIndex).Item(1))
        If OldUserDefinedName <> CType(row.FindControl("UserDefinedNameTextBox"), TextBox).Text Then
            Return True
        End If
        Return False
    End Function
    Public Sub ValidateUserDefinedTextBox(ByVal row As GridViewRow)
        If CType(row.FindControl("UserDefinedNameTextBox"), TextBox).Text = "" Then
            Throw New Exception("*")
        End If
    End Sub
    Public Function ValidateUserDefinedNameInsert(ByVal AccountId As Integer, ByVal UserDefinedName As String) As Boolean
        Dim BLL As New AccountTerminologyBLL
        If BLL.GetAccountTerminologyByAccountIdAndUserDefinedName(AccountId, UserDefinedName).Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Function ValidateUserDefinedNameUpdate(ByVal AccountTerminologyId As Integer, ByVal AccountId As Integer, ByVal UserDefinedName As String) As Boolean
        Dim BLL As New AccountTerminologyBLL
        If BLL.GetAccountTerminologyByAccountIdAndUserDefinedNameAndAccountTerminologyId(AccountTerminologyId, AccountId, UserDefinedName).Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Sub ValidateUniqueUserDefinedNameForInsert(ByVal row As GridViewRow, ByVal AccountId As Integer, ByVal UserDefinedName As String)
        If ValidateUserDefinedNameInsert(AccountId, UserDefinedName) = True Then
            Throw New Exception("User Defined Name already exist")
        End If
    End Sub
    Public Sub ValidateUniqueUserDefinedNameForUpdate(ByVal row As GridViewRow, ByVal AccountTerminologyId As Integer, ByVal AccountId As Integer, ByVal UserDefinedName As String)
        If ValidateUserDefinedNameUpdate(AccountTerminologyId, AccountId, UserDefinedName) = True Then
            Throw New Exception("User Defined Name already exist")
        End If
    End Sub
    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            If Not IsDBNull(DataBinder.Eval(e.Row.DataItem, "TerminologyName")) Then
                CType(e.Row.Cells(2).FindControl("TerminologyNameTextBox"), TextBox).Text = DataBinder.Eval(e.Row.DataItem, "TerminologyName")
            End If
        End If
    End Sub
End Class
