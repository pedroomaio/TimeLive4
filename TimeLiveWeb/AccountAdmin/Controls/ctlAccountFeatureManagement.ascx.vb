Imports TimeLiveDataSetTableAdapters
Partial Class AccountAdmin_Controls_ctlAccountFeatureManagement
    Inherits System.Web.UI.UserControl
    Dim FeatureBLL As New AccountFeatureManagementBLL
    Dim objAccountPagePermission As New AccountPagePermissionBLL

    Dim SecurityBLL As New AccountPagePermissionBLL
    Public AccountId As Integer = DBUtilities.GetSessionAccountId
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            GetFeatures()

            If LicensingBLL.IsExpenseSheetFeature = False Then
                chkExpense.Disabled = True
            End If
            If LicensingBLL.IsTimeOffFeature = False Then
                chkTimeOff.Disabled = True
            End If
            If LicensingBLL.IsTimesheetFeature = False Then
                chkTimesheet.Disabled = True
            End If

        End If

    End Sub

    Public Sub GetFeatures()        
            Dim BLL As New AccountFeatureManagementBLL
            Dim dt As AccountFeatureManagement.AccountFeaturesDataTable = BLL.GetAccountFeatureByAccountId(AccountId)
        Dim dr As AccountFeatureManagement.AccountFeaturesRow
        If dt.Rows.Count > 0 Then
            dr = dt.Rows(0)
            For Each dr In dt.Rows
                If dr.SystemFeatureId.ToString = "DB17DEB7-51A0-4400-BF3B-9094E01EF038".ToLower() Then
                    chkTimesheet.Checked = True
                End If
                If dr.SystemFeatureId.ToString = "537F44E5-EC0F-4DE6-AA29-09450961C5E9".ToLower() Then
                    chkExpense.Checked = True
                End If
                If dr.SystemFeatureId.ToString = "76AAF57E-96A4-4476-94A4-575824E9B9FA".ToLower() Then
                    chkTimeOff.Checked = True
                End If
                If dr.SystemFeatureId.ToString = "DEAA2AE5-133D-4C8A-AB0C-B89EAA76116E".ToLower() Then
                    chkBilling.Checked = True
                End If
                If dr.SystemFeatureId.ToString = "27D3A272-D849-4942-9985-7672FB582389".ToLower() Then
                    chkProject.Checked = True
                End If
                If dr.SystemFeatureId.ToString = "21E65278-AB96-42C6-A332-16CAFBBC669E".ToLower() Then
                    chkAttendance.Checked = True
                End If
            Next
        End If
    End Sub
    Public Sub UpdateFeatures()
        Dim BLL As New AccountFeatureManagementBLL
        'Timesheet Feature
        If DBUtilities.IsTimesheetFeatureByAccountId(AccountId) <> True Then
            If chkTimesheet.Checked = True Then
                BLL.AddAccountFeatures(AccountId, New System.Guid("DB17DEB7-51A0-4400-BF3B-9094E01EF038"))
            End If
        Else
            If chkTimesheet.Checked = False Then
                BLL.DeleteAccountFeatureData(AccountId, New System.Guid("DB17DEB7-51A0-4400-BF3B-9094E01EF038"))
            End If
        End If
        'Expense Feature
        If DBUtilities.IsExpenseFeatureByAccountId(AccountId) <> True Then
            If chkExpense.Checked = True Then
                BLL.AddAccountFeatures(AccountId, New System.Guid("537F44E5-EC0F-4DE6-AA29-09450961C5E9"))
            End If
        Else
            If chkExpense.Checked = False Then
                BLL.DeleteAccountFeatureData(AccountId, New System.Guid("537F44E5-EC0F-4DE6-AA29-09450961C5E9"))
            End If
        End If
        'TimeOff Feature
        If DBUtilities.IsTimeOffFeatureByAccountId(AccountId) <> True Then
            If chkTimeOff.Checked = True Then
                BLL.AddAccountFeatures(AccountId, New System.Guid("76AAF57E-96A4-4476-94A4-575824E9B9FA"))
            End If
        Else
            If chkTimeOff.Checked = False Then
                BLL.DeleteAccountFeatureData(AccountId, New System.Guid("76AAF57E-96A4-4476-94A4-575824E9B9FA"))
            End If
        End If
        'Billing Feature
        If DBUtilities.IsBillingFeatureByAccountId(AccountId) <> True Then
            If chkBilling.Checked = True Then
                BLL.AddAccountFeatures(AccountId, New System.Guid("DEAA2AE5-133D-4C8A-AB0C-B89EAA76116E"))
            End If
        Else
            If chkBilling.Checked = False Then
                BLL.DeleteAccountFeatureData(AccountId, New System.Guid("DEAA2AE5-133D-4C8A-AB0C-B89EAA76116E"))
            End If
        End If
        'Project Management Feature
        If DBUtilities.IsProjectManagementFeatureByAccountId(AccountId) <> True Then
            If chkProject.Checked = True Then
                BLL.AddAccountFeatures(AccountId, New System.Guid("27D3A272-D849-4942-9985-7672FB582389"))
            End If
        Else
            If chkProject.Checked = False Then
                BLL.DeleteAccountFeatureData(AccountId, New System.Guid("27D3A272-D849-4942-9985-7672FB582389"))
            End If
        End If
        'Attendance Feature
        If DBUtilities.IsAttendanceFeatureByAccountId(AccountId) <> True Then
            If chkAttendance.Checked = True Then
                BLL.AddAccountFeatures(AccountId, New System.Guid("21E65278-AB96-42C6-A332-16CAFBBC669E"))
            End If
        Else
            If chkAttendance.Checked = False Then
                BLL.DeleteAccountFeatureData(AccountId, New System.Guid("21E65278-AB96-42C6-A332-16CAFBBC669E"))
            End If
        End If
    End Sub
    Protected Sub btnST_ServerClick(sender As Object, e As System.EventArgs) Handles btnST.ServerClick
        UpdateFeatures()
        UIUtilities.RedirectToAdminHomePage()
    End Sub
End Class
