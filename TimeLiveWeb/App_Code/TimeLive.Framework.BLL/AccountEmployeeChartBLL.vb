Imports Microsoft.VisualBasic
Imports AccountEmployeeChartTableAdapters
Imports System.Web
<System.ComponentModel.DataObject()> _
Public Class AccountEmployeeChartBLL
    Private _AccountEmployeeChartsTableAdapter As AccountEmployeeChartsTableAdapter = Nothing
    Private _SystemChartTypeTableAdapter As SystemChartTypeTableAdapter = Nothing
    Private _VueAccountEmployeeChartTableAdapter As VueAccountEmployeeChartTableAdapter = Nothing
    Private _vueAccountProjectsForMyProjectsTableAdapter As vueAccountProjectsForMyProjectsTableAdapter = Nothing
    Protected ReadOnly Property vueMyProjectsAdapter As vueAccountProjectsForMyProjectsTableAdapter
        Get
            If _vueAccountProjectsForMyProjectsTableAdapter Is Nothing Then
                _vueAccountProjectsForMyProjectsTableAdapter = New vueAccountProjectsForMyProjectsTableAdapter
            End If
            Return _vueAccountProjectsForMyProjectsTableAdapter
        End Get
    End Property
    Protected ReadOnly Property SystemChartTypeAdapter As SystemChartTypeTableAdapter
        Get
            If _SystemChartTypeTableAdapter Is Nothing Then
                _SystemChartTypeTableAdapter = New SystemChartTypeTableAdapter
            End If
            Return _SystemChartTypeTableAdapter
        End Get
    End Property
    Protected ReadOnly Property ChartsAdapter As AccountEmployeeChartsTableAdapter
        Get
            If _AccountEmployeeChartsTableAdapter Is Nothing Then
                _AccountEmployeeChartsTableAdapter = New AccountEmployeeChartsTableAdapter
            End If
            Return _AccountEmployeeChartsTableAdapter
        End Get
    End Property
    Protected ReadOnly Property VueAccountEmployeeChartAdapter As VueAccountEmployeeChartTableAdapter
        Get
            If _VueAccountEmployeeChartTableAdapter Is Nothing Then
                _VueAccountEmployeeChartTableAdapter = New VueAccountEmployeeChartTableAdapter
            End If
            Return _VueAccountEmployeeChartTableAdapter
        End Get
    End Property
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetvueMyProjectsByAccountEmployeeId(ByVal AccountEmployeeId As Integer) As AccountEmployeeChart.vueAccountProjectsForMyProjectsDataTable
        Return vueMyProjectsAdapter.GetvueMyProjectByAccountEmployeeId(AccountEmployeeId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetProjectStatusCountByAccountProject(ByVal AccountId As Integer, ByVal AccountEmployeeId As Integer) As AccountEmployeeChart.vueAccountProjectsDataTable
        Dim _vueProjectAdapterForChart As New vueAccountProjectsTableAdapter
        Return _vueProjectAdapterForChart.GetProjectStatusCountByAccountIdAndAccountEmployeeIdForChart(AccountId, AccountEmployeeId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAssignedAccountProjectTasksForChart(ByVal AccountEmployeeId As Integer, ByVal AccountId As Integer) As AccountEmployeeChart.vueAccountProjectTaskDataTable
        Dim _vueAccountProjectTaskTableAdapter As New vueAccountProjectTaskTableAdapter
        Return _vueAccountProjectTaskTableAdapter.GetAssignedAccountProjectTasksForDurationChart(AccountId, AccountEmployeeId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAssignedAccountProjectTasksForCompletedPercentageChart(ByVal AccountEmployeeId As Integer, ByVal AccountId As Integer) As AccountEmployeeChart.vueAccountProjectTaskDataTable
        Dim _vueAccountProjectTaskTableAdapter As New vueAccountProjectTaskTableAdapter
        Return _vueAccountProjectTaskTableAdapter.GetAssignedAccountProjectTasksForCompletePercentageChart(AccountId, AccountEmployeeId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetvueAccountEmployeeChart() As AccountEmployeeChart.VueAccountEmployeeChartDataTable
        Return VueAccountEmployeeChartAdapter.GetVueAccountEmployeeChart
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetvueAccountEmployeeChartByAccountIdAndAccountEmployeeId(ByVal AccountId As Integer, ByVal AccountEmployeeId As Integer) As AccountEmployeeChart.VueAccountEmployeeChartDataTable
        Return VueAccountEmployeeChartAdapter.GetDataByAccountIdAndAccountEmployeeId(AccountId, AccountEmployeeId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetChartTypes() As AccountEmployeeChart.SystemChartTypeDataTable
        Return SystemChartTypeAdapter.GetChartTypes
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountEmployeeChartsBySystemChartId(ByVal AccountId As Integer, ByVal AccountEmployeeId As Integer, ByVal SystemChartId As Guid) As AccountEmployeeChart.AccountEmployeeChartsDataTable
        Return ChartsAdapter.GetAccountEmployeeChartsByAccountIdAccountEmployeeIdSystemChartId(AccountId, AccountEmployeeId, SystemChartId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetvueAccountEmployeeChartsBySystemChartId(ByVal AccountId As Integer, ByVal AccountEmployeeId As Integer, ByVal SystemChartId As Guid) As AccountEmployeeChart.VueAccountEmployeeChartDataTable
        Return VueAccountEmployeeChartAdapter.GetDataByAccountIdAccountEmployeeIdAndSystemChartId(AccountId, AccountEmployeeId, SystemChartId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountEmployeechartByAccountChartId(ByVal AccountId As Integer, ByVal AccountChartId As Guid) As AccountEmployeeChart.AccountEmployeeChartsDataTable
        Return ChartsAdapter.GetAccountEmployeechartByAccountChartId(AccountChartId, AccountId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, True)> _
    Public Function AddAccountEmployeeCharts(ByVal AccountId As Integer, ByVal AccountEmployeeId As Integer, _
                                             ByVal SystemChartTypeId As Guid, ByVal SystemChartId As Guid, _
                                             ByVal IsCollectPieSlices As Boolean, ByVal CollectedThreshold As Integer, _
                                             ByVal CollectedColor As String, ByVal CollectedLabel As String, _
                                             ByVal CollectedLegendText As String, ByVal IsShowExploded As Boolean, ByVal IsShowLegend As Boolean, _
                                             ByVal IsShowas3D As Boolean, ByVal DoughnutRadius As Integer, ByVal DrawingStyle As String, ByVal LabelStyle As String, _
                                             ByVal PointWidth As Double, ByVal RotationAngle As Integer, ByVal PointsGap As Integer, _
                                             ByVal LabelsPlacement As String, ByVal MinPointHeight As Integer, ByVal StandardPalette As String, ByVal CustomPalette As String, _
                                             ByVal IsHideSupplementalChart As Boolean, ByVal CollectedPercentage As Integer, ByVal SupplementalChartSize As String, ByVal IsCollectSmallSegments As Boolean) As Boolean

        Dim dtAccountEmployeeCharts As New AccountEmployeeChart.AccountEmployeeChartsDataTable
        Dim drAccountEmployeeCharts As AccountEmployeeChart.AccountEmployeeChartsRow = dtAccountEmployeeCharts.NewAccountEmployeeChartsRow
        With drAccountEmployeeCharts
            .AccountId = AccountId
            .AccountEmployeeId = AccountEmployeeId
            .SystemChartTypeId = SystemChartTypeId
            .AccountChartId = System.Guid.NewGuid
            .CreatedOn = Now
            .CreatedByEmployeeId = DBUtilities.GetSessionAccountEmployeeId()
            .ModifiedOn = Now
            .ModifiedByEmployeeId = DBUtilities.GetSessionAccountEmployeeId()
            .SystemChartId = SystemChartId
            .IsCollectPieSlices = IsCollectPieSlices
            .CollectedThreshold = CollectedThreshold
            .CollectedColor = CollectedColor
            .CollectedLabel = CollectedLabel
            .CollectedLegendText = CollectedLegendText
            .IsShowExploded = IsShowExploded
            .IsShowLegend = IsShowLegend
            .IsShowas3D = IsShowas3D
            .DoughnutRadius = DoughnutRadius
            .DrawingStyle = DrawingStyle
            .LabelStyle = LabelStyle
            .PointWidth = PointWidth
            .RotationAngle = RotationAngle
            .PointsGap = PointsGap
            .LabelsPlacement = LabelsPlacement
            .MinPointHeight = MinPointHeight
            .StandardPalette = StandardPalette
            .CustomPalette = CustomPalette
            .IsHideSupplementalChart = IsHideSupplementalChart
            .CollectedPercentage = CollectedPercentage
            .SupplementalChartSize = SupplementalChartSize
            .IsCollectSmallSegments = IsCollectSmallSegments
        End With
        dtAccountEmployeeCharts.AddAccountEmployeeChartsRow(drAccountEmployeeCharts)
        Dim rowsAffected As Integer = ChartsAdapter.Update(dtAccountEmployeeCharts)
        Return rowsAffected = 1
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)> _
    Public Function UpdateAccountEmployeeCharts(ByVal AccountId As Integer, _
    ByVal AccountEmployeeId As Integer, ByVal SystemChartTypeId As Guid, ByVal Original_AccountChartId As Guid, _
    ByVal SystemChartId As Guid, ByVal IsCollectPieSlices As Boolean, ByVal CollectedThreshold As Integer, _
    ByVal CollectedColor As String, ByVal CollectedLabel As String, ByVal CollectedLegendText As String, _
    ByVal IsShowExploded As Boolean, ByVal IsShowLegend As Boolean, ByVal IsShowas3D As Boolean, ByVal DoughnutRadius As Integer, _
    ByVal DrawingStyle As String, ByVal LabelStyle As String, ByVal PointWidth As Double,
    ByVal RotationAngle As Integer, ByVal PointsGap As Integer, ByVal LabelsPlacement As String, ByVal MinPointHeight As Integer, _
    ByVal StandardPalette As String, ByVal CustomPalette As String, _
    ByVal IsHideSupplementalChart As Boolean, ByVal CollectedPercentage As Integer, ByVal SupplementalChartSize As String, ByVal IsCollectSmallSegments As Boolean) As Boolean

        Dim dtAccountEmployeeCharts As AccountEmployeeChart.AccountEmployeeChartsDataTable = ChartsAdapter.GetDataByAccountChartId(Original_AccountChartId)
        Dim drAccountEmployeeCharts As AccountEmployeeChart.AccountEmployeeChartsRow = dtAccountEmployeeCharts.Rows(0)

        With drAccountEmployeeCharts
            .AccountId = AccountId
            .AccountEmployeeId = AccountEmployeeId
            .SystemChartTypeId = SystemChartTypeId
            .AccountChartId = Original_AccountChartId
            .CreatedOn = Now
            .CreatedByEmployeeId = DBUtilities.GetSessionAccountEmployeeId()
            .ModifiedOn = Now
            .ModifiedByEmployeeId = DBUtilities.GetSessionAccountEmployeeId()
            .SystemChartId = SystemChartId
            .IsCollectPieSlices = IsCollectPieSlices
            .CollectedThreshold = CollectedThreshold
            .CollectedColor = CollectedColor
            .CollectedLabel = CollectedLabel
            .CollectedLegendText = CollectedLegendText
            .IsShowExploded = IsShowExploded
            .IsShowLegend = IsShowLegend
            .IsShowas3D = IsShowas3D
            .DoughnutRadius = DoughnutRadius
            .DrawingStyle = DrawingStyle
            .LabelStyle = LabelStyle
            .PointWidth = PointWidth
            .RotationAngle = RotationAngle
            .PointsGap = PointsGap
            .LabelsPlacement = LabelsPlacement
            .MinPointHeight = MinPointHeight
            .StandardPalette = StandardPalette
            .CustomPalette = CustomPalette
            .IsHideSupplementalChart = IsHideSupplementalChart
            .CollectedPercentage = CollectedPercentage
            .SupplementalChartSize = SupplementalChartSize
            .IsCollectSmallSegments = IsCollectSmallSegments
        End With

        Dim rowsAffected As Integer = ChartsAdapter.Update(dtAccountEmployeeCharts)
        Return rowsAffected = 1
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Delete, True)> _
    Public Function DeleteAccountEmployeeChart(ByVal Original_AccountChartId As Guid) As Boolean
        Dim rowsAffected As Integer = ChartsAdapter.Delete(Original_AccountChartId)
        ' Return true if precisely one row was deleted, otherwise false
        Return rowsAffected = 1
    End Function
    Public Sub InsertDefault(ByVal AccountId As Integer)
        ChartsAdapter.InsertDefault(AccountId)
        If System.Configuration.ConfigurationManager.AppSettings("BugTracking") = "Yes" Then
            Me.ChangeChartNameForBugTracking(AccountId)
        End If
    End Sub
    Public Sub InsertDefaultForEmployee(ByVal AccountId As Integer, ByVal AccountEmployeeId As Integer)
        ChartsAdapter.InsertDefaultForEmployeee(AccountId, AccountEmployeeId)
        If System.Configuration.ConfigurationManager.AppSettings("BugTracking") = "Yes" Then
            Me.ChangeChartNameForBugTracking(AccountId)
        End If
    End Sub
    Public Sub ChangeChartNameForBugTracking(ByVal AccountId As Integer, Optional ByVal AccountEmployeeId As Integer = 0)
        Dim EmployeeBLL As New AccountEmployeeBLL
        Dim dtChartName As AccountEmployeeChart.VueAccountEmployeeChartDataTable = Me.GetvueAccountEmployeeChartByAccountIdAndAccountEmployeeId(AccountId, IIf(AccountEmployeeId = 0, EmployeeBLL.GetLastInsertedId, AccountEmployeeId))
        Dim drChartName As AccountEmployeeChart.VueAccountEmployeeChartRow
        For Each drChartName In dtChartName.Rows
            If drChartName.AccountChartName = "My Tasks by Duration" Then
                Me.UpdateAccountEmployeeChartsForSelectedField(AccountId, IIf(AccountEmployeeId = 0, EmployeeBLL.GetLastInsertedId, AccountEmployeeId), drChartName.SystemChartTypeId, drChartName.AccountChartId, drChartName.SystemChartId, "My Bugs by Duration", drChartName.IsShowExploded, drChartName.IsShowLegend, drChartName.IsShowas3D, drChartName.CollectedThreshold)
            ElseIf drChartName.AccountChartName = "My Tasks by Status Count" Then
                Me.UpdateAccountEmployeeChartsForSelectedField(AccountId, IIf(AccountEmployeeId = 0, EmployeeBLL.GetLastInsertedId, AccountEmployeeId), drChartName.SystemChartTypeId, drChartName.AccountChartId, drChartName.SystemChartId, "My Bugs by Status Count", drChartName.IsShowExploded, drChartName.IsShowLegend, drChartName.IsShowas3D, drChartName.CollectedThreshold)
            ElseIf drChartName.AccountChartName = "My Tasks By Completed %" Then
                Me.UpdateAccountEmployeeChartsForSelectedField(AccountId, IIf(AccountEmployeeId = 0, EmployeeBLL.GetLastInsertedId, AccountEmployeeId), drChartName.SystemChartTypeId, drChartName.AccountChartId, drChartName.SystemChartId, "My Bugs By Completed %", drChartName.IsShowExploded, drChartName.IsShowLegend, drChartName.IsShowas3D, drChartName.CollectedThreshold)
            End If
        Next

    End Sub
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)> _
    Public Function UpdateAccountEmployeeChartsForSelectedField(ByVal AccountId As Integer, _
    ByVal AccountEmployeeId As Integer, ByVal SystemChartTypeId As Guid, ByVal Original_AccountChartId As Guid, _
    ByVal SystemChartId As Guid, ByVal AccountChartName As String, _
    ByVal IsShowExploded As Boolean, ByVal IsShowLegend As Boolean, ByVal IsShowas3D As Boolean, ByVal CollectedThreshold As Integer) As Boolean

        Dim dtAccountEmployeeCharts As AccountEmployeeChart.AccountEmployeeChartsDataTable = ChartsAdapter.GetDataByAccountChartId(Original_AccountChartId)
        Dim drAccountEmployeeCharts As AccountEmployeeChart.AccountEmployeeChartsRow = dtAccountEmployeeCharts.Rows(0)

        With drAccountEmployeeCharts
            .AccountId = AccountId
            .AccountEmployeeId = AccountEmployeeId
            .SystemChartTypeId = SystemChartTypeId
            .AccountChartId = Original_AccountChartId
            .CreatedOn = Now
            .CreatedByEmployeeId = DBUtilities.GetSessionAccountEmployeeId()
            .ModifiedOn = Now
            .ModifiedByEmployeeId = DBUtilities.GetSessionAccountEmployeeId()
            .SystemChartId = SystemChartId
            .IsShowExploded = IsShowExploded
            .AccountChartName = AccountChartName
            .IsShowLegend = IsShowLegend
            .IsShowas3D = IsShowas3D
            .CollectedThreshold = CollectedThreshold
        End With

        Dim rowsAffected As Integer = ChartsAdapter.Update(dtAccountEmployeeCharts)
        Return rowsAffected = 1
    End Function
End Class
