Imports System.Net.Mail
Partial Class Home_PreWizard
    Inherits System.Web.UI.Page

    Protected Sub btnChatWithUs_ServerClick(sender As Object, e As System.EventArgs) Handles btnChatWithUs.ServerClick
        Dim url As String = "http://livechat.livetecs.com"
        Dim s As String = "window.open('" & url + "', 'popup_window', 'width=571,height=665,left=400,resizable=yes');"
        ClientScript.RegisterStartupScript(Me.GetType(), "script", s, True)
    End Sub
    'ssss
    Protected Sub btnGetStarted_ServerClick(sender As Object, e As System.EventArgs) Handles btnGetStarted.ServerClick
        Response.Redirect("~/Home/Wizard.aspx", False)
    End Sub

    Protected Sub btnSkip_ServerClick(sender As Object, e As System.EventArgs) Handles btnSkip.ServerClick
        Dim account As New AccountBLL
        account.UpdateIsWizardSkipByAccountId(DBUtilities.GetSessionAccountId)
        Response.Redirect("~/Employee/Default.aspx", False)
    End Sub
    Protected Sub btnSendEmail_ServerClick(sender As Object, e As System.EventArgs) Handles btnSendEmail.ServerClick
        Dim smtpClient As New SmtpClient

        smtpClient.Credentials = New System.Net.NetworkCredential("AKIAJB2TL4MSVCHO72DQ", "AupN/iC9wKvqUevfNcKfms6TXGqAkpB6HLVCnfLcLy5G")
        smtpClient.Host = "email-smtp.us-west-2.amazonaws.com"
        smtpClient.Port = 587
        'smtpClient.UseDefaultCredentials = True
        'smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network
        smtpClient.EnableSsl = True
        Dim mail As New MailMessage()

        'Setting From , To and CC
        mail.From = New MailAddress("noreply@livetecs.com", "Timelive")
        mail.[To].Add(New MailAddress("notifications@livetecs.com"))
        mail.Subject = "Customer request for call"
        mail.Body = "EmailAddress: " & DBUtilities.GetSessionEmailAddress & System.Environment.NewLine & "Employee Name: " & DBUtilities.GetSessionEmployeeName & System.Environment.NewLine & "Phone Number: " & txtPhoneNo.Value
        mail.IsBodyHtml = False
        smtpClient.Send(mail)
    End Sub
    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Dim FileName As String
        Dim registerKey As String
        FileName = System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/Analytics.txt")
        If System.IO.File.Exists(FileName) Then
            registerKey = System.IO.File.ReadAllText(FileName)
            If registerKey <> "" Then
                If Not Page.ClientScript.IsStartupScriptRegistered("key1") Then
                    Page.ClientScript.RegisterStartupScript([GetType](), "key1", registerKey)
                End If
            End If
        End If
    End Sub
End Class
