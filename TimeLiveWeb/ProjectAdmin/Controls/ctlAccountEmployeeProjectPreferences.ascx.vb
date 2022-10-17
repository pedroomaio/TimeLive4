
Partial Class ProjectAdmin_Controls_ctlAccountEmployeeProjectPreferences
    Inherits System.Web.UI.UserControl
    Dim AccountEmployeeId As Integer
    Dim AccountProjectId As Integer
    Dim Original_AccountEmployeeProjectPreferencesId As Integer
    Dim dr As TimeLiveDataSet.AccountEmployeeProjectPreferencesRow


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Me.IsPostBack Then

            Me.LoadFromQueryString()

            Dim Bll As New AccountEmployeeProjectPreferencesBLL
            Dim dt As TimeLiveDataSet.AccountEmployeeProjectPreferencesDataTable

            Dim dr As TimeLiveDataSet.AccountEmployeeProjectPreferencesRow
            dt = Bll.GetDataByAccountEmployeeIdAndAccountProjectId(DBUtilities.GetSessionAccountEmployeeId, AccountProjectId)

            If dt.Rows.Count > 0 Then
                dr = dt.Rows(0)
                If Not IsDBNull(dr.SendEMailOfActivityAssignToMe) Then
                    If dr.SendEMailOfActivityAssignToMe = True Then
                        Me.chkSendEmailOfTaskAssignToMe.Checked = dr.SendEMailOfActivityAssignToMe
                    End If

                End If
                If Not IsDBNull(dr.SendEMailOfAllProjectActivities) Then
                    If dr.SendEMailOfAllProjectActivities = True Then
                        Me.chkSendEMailOfAllProjectActivities.Checked = dr.SendEMailOfAllProjectActivities
                    End If

                End If

            End If

        End If

    End Sub
    Public Sub LoadFromQueryString()

        If Not Request.QueryString("AccountProjectId") Is Nothing Then
            AccountProjectId = Request.QueryString("AccountProjectId")
        Else
            AccountProjectId = 1
        End If
    End Sub
    Public Sub CheckUpdateAndInsert()

        Dim dt As TimeLiveDataSet.AccountEmployeeProjectPreferencesRow

        Dim Bll As New AccountEmployeeProjectPreferencesBLL

        Me.LoadFromQueryString()



        If Bll.DoesPreferenceExists(DBUtilities.GetSessionAccountEmployeeId, AccountProjectId) = False Then
            Bll.AddAccountEmployeeProjectPreference(DBUtilities.GetSessionAccountEmployeeId, AccountProjectId, Me.chkSendEmailOfTaskAssignToMe.Checked, Me.chkSendEMailOfAllProjectActivities.Checked)
        Else
            dt = Bll.GetDataByAccountEmployeeIdAndAccountProjectId(DBUtilities.GetSessionAccountEmployeeId, AccountProjectId).Rows(0)
            Bll.UpdateAccountEmployeeProjectPreference(DBUtilities.GetSessionAccountEmployeeId, AccountProjectId, Me.chkSendEmailOfTaskAssignToMe.Checked, Me.chkSendEMailOfAllProjectActivities.Checked, dt.AccountEmployeeProjectPreferencesId)
        End If

    End Sub

    Protected Sub btnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.CheckUpdateAndInsert()
    End Sub

    Protected Sub btnUpdate_Click1(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.CheckUpdateAndInsert()

        Response.Redirect("~/Employee/MyProjects.aspx", False)
    End Sub
End Class
