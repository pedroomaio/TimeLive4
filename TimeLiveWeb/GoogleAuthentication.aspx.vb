Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.IO
Imports System.Net
Imports System.Text
Imports System.Data
Partial Class GoogleAuthentication
    Inherits System.Web.UI.Page
    Public Email_address As String = ""
    Public Google_ID As String = ""
    Public firstName As String = ""
    Public LastName As String = ""
    Public Client_ID As String = ""
    Public Return_url As String = ""
    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Client_ID = System.Configuration.ConfigurationManager.AppSettings("google_clientId")
        Return_url = System.Configuration.ConfigurationManager.AppSettings("google_RedirectUrl")
        If Request.QueryString("access_token") IsNot Nothing Then
            Dim URI As [String] = "https://www.googleapis.com/oauth2/v1/userinfo?access_token=" + Request.QueryString("access_token").ToString()
            Dim webClient As New WebClient()
            Dim stream As Stream = webClient.OpenRead(URI)
            Dim b As String
            'I have not used any JSON parser because I do not want to use any extra dll/3rd party dll
            Using br As New StreamReader(stream)
                b = br.ReadToEnd()
            End Using
            b = b.Replace("id", "").Replace("email", "")
            b = b.Replace("given_name", "")
            b = b.Replace("family_name", "").Replace("link", "").Replace("picture", "")
            b = b.Replace("gender", "").Replace("locale", "").Replace(":", "")
            b = b.Replace("""", "").Replace("name", "").Replace("{", "").Replace("}", "")
            Dim ar As Array = b.Split(",".ToCharArray())
            For p As Integer = 0 To ar.Length - 1
                ar.SetValue(ar.GetValue(p).ToString().Trim(), p)
            Next
            Email_address = ar.GetValue(1).ToString()
            Google_ID = ar.GetValue(0).ToString()
            firstName = ar.GetValue(4).ToString()
            LastName = ar.GetValue(5).ToString()
            Dim EmployeeBLL As New AccountEmployeeBLL
            If DBUtilities.GetSessionEmailAddress <> "" Then
                If EmployeeBLL.GetAccountEmployeeByOpenIDClaimIdentifier(Google_ID).Rows.Count = 0 Then
                    EmployeeBLL.UpdateOpenIDClaimIdentifierByAccountEmployeeId(DBUtilities.GetSessionAccountEmployeeId, Google_ID, Email_address)
                    Response.Redirect("~/Employee/Default.aspx", False)
                Else
                    ShowMessage("Configuration Error: " & Email_address & " is linked with another timelive account.", "Employee/EmployeeProfile.aspx")
                End If
            Else
                If EmployeeBLL.SignInByClaimIdentifier(Google_ID) = False Then
                    ' CType(Me.Login1.FindControl("ErrorText"), Label).Text = "Configuration Error: Your user account is not linked with Google login. " & vbCrLf & "Please login with your livetecs account and linked your account."
                    ShowMessage("Configuration Error: Your user account is not linked with Google login. Please login with your livetecs account and linked your account.", "Default.aspx")
                End If
            End If
        End If
    End Sub
    Public Sub ShowMessage(ByVal message As String, ByVal URL As String)
        Dim strMessage As String = message
        Dim strScript As String = "alert('" & strMessage & "'); window.location = '" & URL & "';"
        If (Not Me.Page.ClientScript.IsStartupScriptRegistered("clientScript")) Then
            ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "clientScript", strScript, True)
        End If
    End Sub
End Class
