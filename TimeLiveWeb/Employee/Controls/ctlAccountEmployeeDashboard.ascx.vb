Imports System.Data.SqlClient
Imports AccountEmployeeDashboardTableAdapters
Imports AccountEmployeeTableAdapters
Partial Class Employee_Controls_ctlAccountEmployeeDashboard
    Inherits System.Web.UI.UserControl
    Public ListBoxValues As New ArrayList
    Protected Sub Save_Click(sender As Object, e As System.EventArgs) Handles Save.Click

        Dim bll As New AccountEmployeeDashboardBLL
        'delete listbox item from database by selecting systemid
        For i As Integer = AvailableListBox.Items.Count - 1 To 0 Step -1
            Dim SystemAccountEmployeeDashboardId As New Guid(AvailableListBox.Items(i).Value)
            Dim dt As AccountEmployeeDashboard.AccountEmployeeDashboardDataTable
            dt = bll.GetAccountEmployeeDashboardBySystemEmployeeDashboard(SystemAccountEmployeeDashboardId, DBUtilities.GetSessionAccountEmployeeId, DBUtilities.GetSessionAccountId)
            If dt.Rows.Count > 0 And Not ListBoxValues.Contains(SystemAccountEmployeeDashboardId.ToString) Then
                bll.DeleteAccountEmployeeDashboard(SystemAccountEmployeeDashboardId)
            End If
        Next
        'SelectedListBox.DataBind()
        'add listbox item from database by selecting systemid
        Dim SortOrder As Integer
        For i As Integer = SelectedListBox.Items.Count - 1 To 0 Step -1
            Dim SystemAccountEmployeeDashBoardId As New Guid(SelectedListBox.Items(i).Value)
            Dim dtAccountEmployeeDashboardId As AccountEmployeeDashboard.AccountEmployeeDashboardDataTable
            dtAccountEmployeeDashboardId = bll.GetAccountEmployeeDashboardBySystemEmployeeDashboard(SystemAccountEmployeeDashBoardId, DBUtilities.GetSessionAccountEmployeeId, DBUtilities.GetSessionAccountId)
            If dtAccountEmployeeDashboardId.Rows.Count = 0 Then
                If SystemAccountEmployeeDashBoardId = New Guid("8b8dac4f-190b-4665-a430-17e3388c9a35") Then
                    SortOrder = 8
                ElseIf SystemAccountEmployeeDashBoardId = New Guid("411219a5-ec78-40b7-9850-37385716dd9b") Then
                    SortOrder = 2
                ElseIf SystemAccountEmployeeDashBoardId = New Guid("2eb5f81a-7f80-41eb-a5ab-67f281a479e9") Then
                    SortOrder = 9
                ElseIf SystemAccountEmployeeDashBoardId = New Guid("5e21d895-5f48-45fb-82ae-792ba7061b8e") Then
                    SortOrder = 1
                ElseIf SystemAccountEmployeeDashBoardId = New Guid("eec56c67-0dbf-45e4-a3b0-9c4692ee8f9b") Then
                    SortOrder = 3
                ElseIf SystemAccountEmployeeDashBoardId = New Guid("7a44f088-4217-4456-982c-ace38b2caf16") Then
                    SortOrder = 7
                ElseIf SystemAccountEmployeeDashBoardId = New Guid("9da22d6e-4f92-4b84-8283-be6162df1910") Then
                    SortOrder = 6
                ElseIf SystemAccountEmployeeDashBoardId = New Guid("d499b170-6785-4e9a-8b92-cd3d91134e7e") Then
                    SortOrder = 10
                ElseIf SystemAccountEmployeeDashBoardId = New Guid("9e433f25-3fcb-4365-ad90-d15db881ba64") Then
                    SortOrder = 4
                ElseIf SystemAccountEmployeeDashBoardId = New Guid("9bf4dd65-512b-411f-b71d-ff2722824fc0") Then
                    SortOrder = 11
                ElseIf SystemAccountEmployeeDashBoardId = New Guid("51319439-303B-4E9A-8A90-CEB039D170DB") Then
                    SortOrder = 5
                End If
                bll.AddAccountEmployeeDashboard(DBUtilities.GetSessionAccountId, DBUtilities.GetSessionAccountEmployeeId, SystemAccountEmployeeDashBoardId, False, SortOrder)
            End If
        Next
        Response.Redirect("Default.aspx", False)
    End Sub
    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Me.Label1.Text = ResourceHelper.GetFromResource("My Settings")
        Me.Label2.Text = ResourceHelper.GetFromResource("Dashboard")
        Me.Label3.Text = ResourceHelper.GetFromResource("Available")
        Me.Label4.Text = ResourceHelper.GetFromResource("Selected")
        If Not Me.IsPostBack Then
            SelectedListBox.DataBind()
        End If
        If Not Me.IsPostBack Then
            AvailableListBox.DataBind()
        End If
        For i As Integer = SelectedListBox.Items.Count - 1 To 0 Step -1
            ListBoxValues.Add(SelectedListBox.Items(i).Value)
        Next
    End Sub

    Protected Sub Button3_Click(sender As Object, e As System.EventArgs) Handles Button3.Click
        Response.Redirect("Default.aspx", False)
    End Sub
End Class