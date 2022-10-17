
Partial Class Masters_MasterPageBaseTimeEntry
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Me.Page.Request.Url.ToString.Contains("Default") Then
            Dim meta As New HtmlMeta
            meta.Name = "keywords"
            meta.Content = "Timelive, web based time tracking tool, online timesheet, web based timesheet,  " & _
                           "On-Demand timesheet, time tracking, time tracking software, web based employee attendance, " & _
                           "hosted, downloadable, " & _
                           "asp, " & _
                           "free, " & _
                           "timesheet software,web based timesheet,billing and time tracking software,employee time tracking,employee time tracking software,employee timesheet,online timesheet,project time tracking,project time tracking software,time sheet tracking,time tracking program,timesheet,timesheet management,web based time sheet,web based time tracking,web based time tracking software,web timesheet"
            Page.Header.Controls.Add(meta)
        End If
        Me.SetImageUrl()
    End Sub

    Public Function IsLogoFileExist() As Boolean

        Dim strUploadPath As String = System.Configuration.ConfigurationManager.AppSettings("UploadFilesPath")

        Dim strRoot As String = System.Web.HttpContext.Current.Server.MapPath(strUploadPath)
        If Not System.IO.Directory.Exists(strRoot) Then
            Return False
        End If
        Dim strAccountPath As String = strRoot & DBUtilities.GetSessionAccountId & "\"
        If Not System.IO.Directory.Exists(strAccountPath) Then
            Return False
        End If
        Dim strLogoPath As String = strAccountPath & "Logo" & "\"
        If Not System.IO.Directory.Exists(strLogoPath) Then
            Return False
        End If
        Dim strFilePath As String = strLogoPath & "CompanyLogo.gif"
        If Not System.IO.File.Exists(strFilePath) Then
            Return False
        Else
            Return True
        End If
    End Function
    Public Sub SetImageUrl()
        If LocaleUtilitiesBLL.IsShowCompanyOwnLogo = True And IsLogoFileExist() = True Then
            H.ImageUrl = ("~/Uploads/" & DBUtilities.GetSessionAccountId & "/Logo/CompanyLogo.gif")
        Else
            H.ImageUrl = "~/Images/TopHeader.jpg"
        End If
    End Sub
End Class

