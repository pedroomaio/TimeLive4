
Partial Class Authenticate_Controls_ctlPasswordConfirm
    Inherits System.Web.UI.UserControl

    Protected Sub btnPassword_Click(sender As Object, e As System.EventArgs) Handles btnPassword.Click
        Dim EmployeeBll As New AccountEmployeeBLL
        Dim NewPassword As String = txtNewPassword.Text
        Dim PasswordVerificationCode As Guid = System.Guid.Empty
        If Not Me.Request.QueryString("Code") Is Nothing Then
            PasswordVerificationCode = New Guid(Me.Request.QueryString("Code"))
        End If
        Dim dt As AccountEmployee.AccountEmployeeDataTable = EmployeeBll.GetAccountEmployeesByPasswordVerificationCode(PasswordVerificationCode)
        Dim dr As AccountEmployee.AccountEmployeeRow
        If dt.Rows.Count > 0 Then
            dr = dt.Rows(0)
            EmployeeBll.UpdatePasswordReset(dr.EMailAddress, NewPassword)
            EmployeeBll.UpdatePasswordVerificationCodeNULLByAccountEmployeeId(dr.AccountEmployeeId)
            'EmployeeBll.SendPasswordResetEMail(dr.EMailAddress, NewPassword)
            ShowPasswordChangedMessage("Your password has been successfully changed. Please login with your new password.")
        Else
            ShowPasswordChangedMessage("The link you received in email is expired, or you may already have used it.")
        End If
    End Sub
    Public Sub ShowPasswordChangedMessage(message As String)
        Dim strMessage As String = message
        Dim strScript As String = "alert('" & strMessage & "'); window.location.href = '../Default.aspx';"
        If (Not Me.Page.ClientScript.IsStartupScriptRegistered("clientScript")) Then
            ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "clientScript", strScript, True)
        End If
    End Sub

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Dim EmployeeBll As New AccountEmployeeBLL
        Dim PasswordVerificationCode As Guid = System.Guid.Empty
        If Not Me.Request.QueryString("Code") Is Nothing Then
            PasswordVerificationCode = New Guid(Me.Request.QueryString("Code"))
        End If
        Dim dt As AccountEmployee.AccountEmployeeDataTable = EmployeeBll.GetAccountEmployeesByPasswordVerificationCode(PasswordVerificationCode)
        If dt.Rows.Count = 0 Then
            ShowPasswordChangedMessage("The link you received in email is expired, or you may already have used it.")
        End If
    End Sub
End Class
