Imports Microsoft.VisualBasic
Imports TimeLiveDataSetTableAdapters
Imports System.Data.SqlClient
Imports AccountEmployeeAttendanceTableAdapters
<System.ComponentModel.DataObject()> _
Public Class AccountEmployeeAttendanceBLL

    Private _AccountEmployeeAttendanceTableAdapter As AccountEmployeeAttendanceTableAdapter = Nothing
    Private _AccountEmployeeAttendanceApprovalTableAdapter As AccountEmployeeAttendanceApprovalTableAdapter = Nothing
    Dim strCacheKey As String
    Protected ReadOnly Property Adapter() As AccountEmployeeAttendanceTableAdapter
        Get
            If _AccountEmployeeAttendanceTableAdapter Is Nothing Then
                _AccountEmployeeAttendanceTableAdapter = New AccountEmployeeAttendanceTableAdapter()
            End If

            Return _AccountEmployeeAttendanceTableAdapter
        End Get
    End Property

    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountEmployeeAttendances() As TimeLiveDataSet.AccountEmployeeAttendanceDataTable
        Return Adapter.GetData
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountEmployeeAttendancesByAccountEmployeeAttendanceId(ByVal AccountEmployeeAttendanceId As Integer) As TimeLiveDataSet.AccountEmployeeAttendanceDataTable
        Return Adapter.GetDataByAccountEmployeeAttendanceId(AccountEmployeeAttendanceId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountEmployeeAttendancesByAccountEmployeeId(ByVal AccountEmployeeId As Integer) As TimeLiveDataSet.AccountEmployeeAttendanceDataTable
        Return Adapter.GetDataByAccountEmployeeId(AccountEmployeeId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetvueAccountEmployeeAttendanceApprovalForEmployeeManager(ByVal AttendanceAccountEmployeeId As Integer, ByVal IncludeDateRange As Boolean, ByVal StartDate As Date, ByVal EndDate As Date, ByVal AccountEmployeeId As System.Nullable(Of Integer)) As AccountEmployeeAttendance.vueAccountEmployeeAttendanceApprovalPendingDataTable
        Dim _vueAccountEmployeeAttendanceApprovalPendingTableAdapter As New vueAccountEmployeeAttendanceApprovalPendingTableAdapter
        Return _vueAccountEmployeeAttendanceApprovalPendingTableAdapter.GetApprovalEntriesForEmployeeManager(AttendanceAccountEmployeeId, IncludeDateRange, StartDate, EndDate, AccountEmployeeId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetvueAccountEmployeeAttendanceApprovalForSpecificEmployee(ByVal AttendanceAccountEmployeeId As Integer, ByVal IncludeDateRange As Boolean, ByVal StartDate As Date, ByVal EndDate As Date, ByVal AccountEmployeeId As System.Nullable(Of Integer)) As AccountEmployeeAttendance.vueAccountEmployeeAttendanceApprovalPendingDataTable
        Dim _vueAccountEmployeeAttendanceApprovalPendingTableAdapter As New vueAccountEmployeeAttendanceApprovalPendingTableAdapter
        Return _vueAccountEmployeeAttendanceApprovalPendingTableAdapter.GetApprovalEntriesForSpecificEmployee(AttendanceAccountEmployeeId, IncludeDateRange, StartDate, EndDate, AccountEmployeeId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountEmployeeAttendanceByAttendanceDate(ByVal AccountId As Integer, ByVal AccountEmployeeId As Integer, ByVal AttendanceDate As DateTime) As TimeLiveDataSet.vueAccountEmployeeAttendanceDataTable

        strCacheKey = CacheManager.GetCacheKeyForAccountEmployeeData("vueAccountEmployeeAttendanceDataTable", "GetAccountEmployeeAttendanceByAttendanceDate", "AttendanceDate" & AttendanceDate)

        If Not CacheManager.GetItemFromCache(strCacheKey) Is Nothing Then
            GetAccountEmployeeAttendanceByAttendanceDate = CacheManager.GetItemFromCache(strCacheKey)
        Else
            Dim _vueAccountEmployeeAttendanceTableAdapter As New vueAccountEmployeeAttendanceTableAdapter
            GetAccountEmployeeAttendanceByAttendanceDate = _vueAccountEmployeeAttendanceTableAdapter.GetDataByAttendanceDate(AccountId, AccountEmployeeId, AttendanceDate)
            CacheManager.AddAccountEmployeeDataInCache(GetAccountEmployeeAttendanceByAttendanceDate, strCacheKey)
        End If

        Uiutilities.FixTableForNoRecords(GetAccountEmployeeAttendanceByAttendanceDate)

        Return GetAccountEmployeeAttendanceByAttendanceDate

    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetvueEmployeeAttendanceByAttendanceDate(ByVal AccountId As Integer, ByVal AccountEmployeeId As Integer, ByVal AttendanceDate As DateTime) As TimeLiveDataSet.vueAccountEmployeeAttendanceDataTable
        Dim _vueAccountEmployeeAttendanceTableAdapter As New vueAccountEmployeeAttendanceTableAdapter
        GetvueEmployeeAttendanceByAttendanceDate = _vueAccountEmployeeAttendanceTableAdapter.GetDataByAttendanceDate(AccountId, AccountEmployeeId, AttendanceDate)
        UIUtilities.FixTableForNoRecords(GetvueEmployeeAttendanceByAttendanceDate)
        Return GetvueEmployeeAttendanceByAttendanceDate
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountEmployeeAttendancesByDate(ByVal AccountId As Integer, ByVal AccountEmployeeId As Integer, ByVal AttedanceDate As DateTime) As TimeLiveDataSet.AccountEmployeeAttendanceDataTable
        Dim dt As TimeLiveDataSet.AccountEmployeeAttendanceDataTable
        dt = Adapter.GetDataByAccountEmployeeId(AccountEmployeeId)


        'Dim col As New DataColumn

        'col.ColumnName = "IsNew"
        'col.DataType = System.Type.GetType("System.Boolean")
        'dt.Columns.Add(col)


        'Dim row As TimeLiveDataSet.AccountEmployeeAttendanceRow
        'For n As Integer = 0 To 1
        ' To 20 - dt.Rows.Count
        'row = dt.NewRow
        'row("AccountEmployeeId") = AccountEmployeeId
        'row("AttendanceDate") = AttendanceDate
        '  row("TotalTime") = #2:00:00 AM#
        '   row("IsNew") = True
        'dt.Rows.Add(row)
        'Next
        Return dt

    End Function

    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, True)> _
    Public Function AddAccountEmployeeAttendance( _
                    ByVal AccountId As System.Nullable(Of Integer), _
                    ByVal AccountEmployeeId As System.Nullable(Of Integer), _
                    ByVal AttendanceDate As System.Nullable(Of DateTime), _
                    ByVal AttendanceTime As System.Nullable(Of DateTime), _
                    ByVal InOut As String, _
                    ByVal AccountAbsenceTypeId As Integer, _
                    ByVal CreatedOn As System.Nullable(Of DateTime), _
                    ByVal CreatedByEmployeeId As System.Nullable(Of Integer), _
                    ByVal ModifiedOn As System.Nullable(Of DateTime), _
                    ByVal ModifiedByEmployeeId As System.Nullable(Of Integer) _
                    ) As Boolean
        ' Create a new ProductRow instance


        _AccountEmployeeAttendanceTableAdapter = New AccountEmployeeAttendanceTableAdapter

        Dim AccountEmployeeAttendances As New TimeLiveDataSet.AccountEmployeeAttendanceDataTable
        Dim AccountEmployeeAttendance As TimeLiveDataSet.AccountEmployeeAttendanceRow = AccountEmployeeAttendances.NewAccountEmployeeAttendanceRow

        With AccountEmployeeAttendance
            .AccountId = AccountId
            .AccountEmployeeId = AccountEmployeeId
            .AttendanceDate = AttendanceDate

            If AccountAbsenceTypeId = 0 Then
                If AttendanceTime.HasValue Then
                    .AttendanceTime = AttendanceTime
                End If
            End If

            If AccountAbsenceTypeId = 0 Then
                .InOut = InOut
            End If

            If Not AccountAbsenceTypeId = 0 Then
                .AccountAbsenceTypeId = AccountAbsenceTypeId
            End If

            .CreatedOn = Now
            .CreatedByEmployeeId = CreatedByEmployeeId
            .ModifiedOn = Now
            .ModifiedByEmployeeId = ModifiedByEmployeeId
        End With

        AccountEmployeeAttendances.AddAccountEmployeeAttendanceRow(AccountEmployeeAttendance)


        ' Add the new product
        Dim rowsAffected As Integer = Adapter.Update(AccountEmployeeAttendances)

        AfterUpdate()

        ' Return true if precisely one row was inserted, otherwise false
        Return rowsAffected = 1


    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, True)> _
    Public Function AddAccountEmployeeAttendanceApproval( _
                     ByVal AccountEmployeeAttendanceId As Integer, ByVal AttendanceApprovalTypeId As Integer, ByVal AttendanceApprovalPathId As Integer, _
                    ByVal ApprovedByEmployeeId As Integer, ByVal IsRejected As Boolean, ByVal IsApproved As Boolean, ByVal Comments As String) As Boolean

        _AccountEmployeeAttendanceApprovalTableAdapter = New AccountEmployeeAttendanceApprovalTableAdapter

        Dim dtAttendanceApproval As New AccountEmployeeAttendance.AccountEmployeeAttendanceApprovalDataTable
        Dim drAttendanceApproval As AccountEmployeeAttendance.AccountEmployeeAttendanceApprovalRow = dtAttendanceApproval.NewAccountEmployeeAttendanceApprovalRow

        With drAttendanceApproval
            '.AccountEmployeeAttendanceApprovalId = System.Guid.NewGuid
            .AccountEmployeeAttendanceId = AccountEmployeeAttendanceId
            .AttendanceApprovalTypeId = AttendanceApprovalTypeId
            .AttendanceApprovalPathId = AttendanceApprovalPathId
            .ApprovedByEmployeeId = ApprovedByEmployeeId
            .ApprovedOn = Now.Date
            .IsRejected = IsRejected
            .IsApproved = IsApproved
            .Comments = Comments
            .CreatedByEmployeeId = DBUtilities.GetSessionAccountEmployeeId
            .CreatedOn = Now
            .ModifiedByEmployeeId = DBUtilities.GetSessionAccountEmployeeId
            .ModifiedOn = Now
        End With

        dtAttendanceApproval.AddAccountEmployeeAttendanceApprovalRow(drAttendanceApproval)

        Dim rowsAffected As Integer = _AccountEmployeeAttendanceApprovalTableAdapter.Update(dtAttendanceApproval)

        Return rowsAffected = 1
    End Function
    Public Sub AfterUpdate()
        CacheManager.ClearCache("AccountEmployeeAttendanceDataTable", , , True)
    End Sub
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)> _
    Public Function UpdateAccountEmployeeAttendance( _
                    ByVal AccountId As System.Nullable(Of Integer), _
                    ByVal AccountEmployeeId As System.Nullable(Of Integer), _
                    ByVal AttendanceDate As System.Nullable(Of DateTime), _
                    ByVal AttendanceTime As DateTime, _
                    ByVal InOut As String, _
                    ByVal AccountAbsenceTypeId As Integer, _
                    ByVal ModifiedOn As System.Nullable(Of DateTime), _
                    ByVal ModifiedByEmployeeId As System.Nullable(Of Integer), _
                    ByVal Original_AccountEmployeeAttendanceId As Integer _
                    ) As Boolean

        ' Update the product record

        Dim AccountEmployeeAttendances As TimeLiveDataSet.AccountEmployeeAttendanceDataTable = Adapter.GetDataByAccountEmployeeAttendanceId(Original_AccountEmployeeAttendanceId)
        Dim AccountEmployeeAttendance As TimeLiveDataSet.AccountEmployeeAttendanceRow = AccountEmployeeAttendances.Rows(0)

        With AccountEmployeeAttendance
            ' .AccountId = AccountId
            '.AccountEmployeeId = AccountEmployeeId
            ' .AttendanceDate = AttendanceDate
            If AccountAbsenceTypeId = 0 Then
                .AttendanceTime = AttendanceTime
            End If

            If AccountAbsenceTypeId = 0 Then
                .InOut = InOut
            End If

            If Not AccountAbsenceTypeId = 0 Then
                .AccountAbsenceTypeId = AccountAbsenceTypeId
            End If

            .ModifiedOn = Now
            .ModifiedByEmployeeId = ModifiedByEmployeeId
        End With


        Dim rowsAffected As Integer = Adapter.Update(AccountEmployeeAttendance)

        AfterUpdate()

        ' Return true if precisely one row was updated, otherwise false
        Return rowsAffected = 1
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)> _
    Public Function UpdateAccountEmployeeAttendanceForApproval( _
                    ByVal AccountId As System.Nullable(Of Integer), _
                    ByVal ApprovedByAccountEmployeeId As System.Nullable(Of Integer), _
                    ByVal InApproval As Boolean, ByVal Approved As Boolean, _
                    ByVal Rejected As Boolean, _
                    ByVal Original_AccountEmployeeAttendanceId As Integer _
                    ) As Boolean

        ' Update the product record

        Dim AccountEmployeeAttendances As TimeLiveDataSet.AccountEmployeeAttendanceDataTable = Adapter.GetDataByAccountEmployeeAttendanceId(Original_AccountEmployeeAttendanceId)
        Dim AccountEmployeeAttendance As TimeLiveDataSet.AccountEmployeeAttendanceRow = AccountEmployeeAttendances.Rows(0)

        With AccountEmployeeAttendance
            .AccountId = AccountId
            .InApproval = InApproval
            .ApprovedBy = ApprovedByAccountEmployeeId
            .Approved = Approved
            .Rejected = Rejected
            .ApprovedOn = Now.Date
            .ModifiedOn = Now
        End With

        Dim rowsAffected As Integer = Adapter.Update(AccountEmployeeAttendance)

        AfterUpdate()

        ' Return true if precisely one row was updated, otherwise false
        Return rowsAffected = 1
    End Function

    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Delete, True)> _
    Public Function DeleteAccountEmployeeAttendance(ByVal Original_AccountEmployeeAttendanceId As Integer) As Boolean
        Dim rowsAffected As Integer = Adapter.Delete(Original_AccountEmployeeAttendanceId)
        AfterUpdate()
        ' Return true if precisely one row was deleted, otherwise false
        Return rowsAffected = 1
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetDataForLeaveSummaryReport(ByVal AccountId As Integer, ByVal AccountEmployeeId As Integer, ByVal IncludeDateRange As Boolean, ByVal AttendanceStartDate As Date, ByVal AttendanceEndDate As Date) As TimeLiveDataSet.vueAccountAttendanceForLeaveSummaryDataTable
        Dim _vueAccountAttendanceForLeaveSummaryTableAdapter As New vueAccountAttendanceForLeaveSummaryTableAdapter
        Return _vueAccountAttendanceForLeaveSummaryTableAdapter.GetDataForLeaveSummaryReport(AccountId, AccountEmployeeId, IncludeDateRange, AttendanceStartDate, AttendanceEndDate)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetDataForEmployeeAbsenceDetailReport(ByVal AccountId As Integer, ByVal AccountEmployeeId As Integer, ByVal IncludeDateRange As Boolean, ByVal AttendanceStartDate As Date, ByVal AttendanceEndDate As Date) As TimeLiveDataSet.vueAccountAttendanceForEmployeeAbsenceDetailDataTable
        Dim _vueAccountAttendanceForEmployeeAbsenceDetailTableAdapter As New vueAccountAttendanceForEmployeeAbsenceDetailTableAdapter
        Return _vueAccountAttendanceForEmployeeAbsenceDetailTableAdapter.GetDataForEmployeeAbsenceDetail(AccountId, AccountEmployeeId, IncludeDateRange, AttendanceStartDate, AttendanceEndDate)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetDataForEmployeeAttendanceReport(ByVal AccountId As Integer, ByVal AccountEmployees As String, ByVal AttendanceStartDate As Date, ByVal AttendanceEndDate As Date) As TimeLiveDataSet.vueAccountAttendanceForEmployeeAttendanceDataTable
        Dim _vueAccountAttendanceForEmployeeAttendanceTableAdapter As New vueAccountAttendanceForEmployeeAttendanceTableAdapter
        Return _vueAccountAttendanceForEmployeeAttendanceTableAdapter.GetDataByEmployees(AccountId, AccountEmployees, AttendanceStartDate, AttendanceEndDate)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetDataForAttendanceDetailReport(ByVal AccountId As Integer, ByVal AccountEmployeeId As Integer, ByVal AttendanceStartDate As Date, ByVal AttendanceEndDate As Date) As TimeLiveDataSet.vueAccountAttendanceForAttendanceDetailDataTable
        Dim _vueAccountAttendanceForAttendanceDetailTableAdapter As New vueAccountAttendanceForAttendanceDetailTableAdapter
        Return _vueAccountAttendanceForAttendanceDetailTableAdapter.GetDataForAttendanceDetailReport(AttendanceStartDate, AttendanceEndDate, AccountEmployeeId, AccountId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetLastAttendance(ByVal AccountId As Integer, ByVal AccountEmployeeId As Integer) As Boolean
        Dim dt As TimeLiveDataSet.AccountEmployeeAttendanceDataTable = Adapter.GetDataByLastAttendance(AccountId, AccountEmployeeId)
        Dim dr As TimeLiveDataSet.AccountEmployeeAttendanceRow
        If dt.Rows.Count > 0 Then
            dr = dt.Rows(0)
            If dr.InOut = "In" Then
                Return True
            ElseIf dr.InOut = "Out" Then
                Return False
            End If
        End If
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetLastAttendanceByAttendanceDate(ByVal AccountId As Integer, ByVal AccountEmployeeId As Integer, ByVal AttendanceDate As Date, ByVal InOut As String) As String
        Dim dt As TimeLiveDataSet.AccountEmployeeAttendanceDataTable = Adapter.GetLastAttendanceByAttendanceDate(AccountId, AccountEmployeeId, AttendanceDate)
        Dim dr As TimeLiveDataSet.AccountEmployeeAttendanceRow
        If dt.Rows.Count > 0 Then
            dr = dt.Rows(0)
            If dr.InOut = InOut Then
                Return dr.InOut
            ElseIf dr.InOut <> InOut Then
                Return dr.InOut
            End If
        End If
        Return ""
    End Function
End Class


