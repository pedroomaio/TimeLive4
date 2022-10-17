Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Configuration
Partial Class Masters_site
    Inherits System.Web.UI.MasterPage
    Protected Sub Page_Load(sender As Object, e As EventArgs)
        ' Get tokens from the AppSettings in config files
        Dim applicationToken As String = ConfigurationManager.AppSettings("applicationToken")
        Dim consumerKey As String = ConfigurationManager.AppSettings("consumerKey")
        Dim consumerSecret As String = ConfigurationManager.AppSettings("consumerSecret")
        ' Check whether the keys are null or empty.
        If String.IsNullOrWhiteSpace(applicationToken) OrElse String.IsNullOrWhiteSpace(consumerKey) OrElse String.IsNullOrWhiteSpace(consumerSecret) Then
            ' Show Error message
            Me.errorDiv.Visible = True
            Me.mainContetntDiv.Visible = False
        Else
            ' Show main content
            Me.errorDiv.Visible = False
            Me.mainContetntDiv.Visible = True
        End If

        If Session("FriendlyName") IsNot Nothing Then
            Me.friendlyName.Text = Session("FriendlyName").ToString()
        End If

        ' Read value from session and check flag which decides the display of blue dot menu
        Dim flag As Object = Session("Flag")
        If flag IsNot Nothing Then
            Dim flagValue As Boolean = Convert.ToBoolean(flag.ToString())
            If flagValue Then
                ' Show BlueDot widget
                Me.blueDotDiv.Visible = True
                Me.logoutview.Style.Add(HtmlTextWriterStyle.MarginRight, "125px")
            Else
                ' Disable BlueDot widget
                Me.blueDotDiv.Visible = False
                Me.logoutview.Style.Add(HtmlTextWriterStyle.MarginRight, "0px")
            End If
        Else
            ' Disable BlueDot widget
            Me.blueDotDiv.Visible = False
            Me.logoutview.Style.Add(HtmlTextWriterStyle.MarginRight, "0px")
        End If
    End Sub
End Class

