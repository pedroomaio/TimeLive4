Imports Microsoft.VisualBasic
Imports AccountExpenseEntryTableAdapters

<System.ComponentModel.DataObject()> _
Public Class AccountEmployeeExpenseSheetBLL

    Private _AccountEmployeeExpenseSheetTableAdapter As AccountEmployeeExpenseSheetTableAdapter = Nothing

    Protected ReadOnly Property Adapter() As AccountEmployeeExpenseSheetTableAdapter
        Get
            If _AccountEmployeeExpenseSheetTableAdapter Is Nothing Then
                _AccountEmployeeExpenseSheetTableAdapter = New AccountEmployeeExpenseSheetTableAdapter()
            End If
            Return _AccountEmployeeExpenseSheetTableAdapter
        End Get

    End Property

    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountEmployeeExpenseSheetByAccountEmployeeId(ByVal AccountEmployeeId As Integer) As AccountExpenseEntry.AccountEmployeeExpenseSheetDataTable
        Return Adapter.GetDataByAccountEmployeeId(AccountEmployeeId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountEmployeeExpenseSheetByAccountIdAndDatabaseFieldName(ByVal AccountId As Integer, ByVal DatabaseFieldName As String) As AccountExpenseEntry.AccountEmployeeExpenseSheetDataTable
        Return Adapter.GetDataByAccountIdAndDatabaseFieldName(AccountId, DatabaseFieldName)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountEmployeeExpenseSheetByAccountEmployeeIdAndExpenseSheetDate(ByVal AccountEmployeeId As Integer, ByVal ExpenseSheetDate As DateTime) As AccountExpenseEntry.AccountEmployeeExpenseSheetDataTable
        Return Adapter.GetDataByAccountEmployeeIdAndExpenseSheetDate(AccountEmployeeId, ExpenseSheetDate)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountEmployeeExpenseSheetByAccountEmployeeExpenseSheetId(ByVal AccountEmployeeExpenseSheetId As Guid) As AccountExpenseEntry.AccountEmployeeExpenseSheetDataTable
        Return Adapter.GetDataByAccountEmployeeExpenseSheetId(AccountEmployeeExpenseSheetId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetvueAccountEmployeeExpenseSheetByAccountEmployeeId(ByVal AccountEmployeeId As Integer) As AccountExpenseEntry.vueAccountEmployeeExpenseSheetDataTable
        Dim _vueAccountEmployeeExpenseSheetTableAdapter As New vueAccountEmployeeExpenseSheetTableAdapter
        GetvueAccountEmployeeExpenseSheetByAccountEmployeeId = _vueAccountEmployeeExpenseSheetTableAdapter.GetDataByAccountEmployeeId(AccountEmployeeId)
        UIUtilities.FixTableForNoRecords(GetvueAccountEmployeeExpenseSheetByAccountEmployeeId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetvueAccountEmployeeExpenseSheetByAccountEmployeeExpenseSheetId(ByVal AccountEmployeeExpenseSheetId As Guid) As AccountExpenseEntry.vueAccountEmployeeExpenseSheetDataTable
        Dim _vueAccountEmployeeExpenseSheetTableAdapter As New vueAccountEmployeeExpenseSheetTableAdapter
        GetvueAccountEmployeeExpenseSheetByAccountEmployeeExpenseSheetId = _vueAccountEmployeeExpenseSheetTableAdapter.GetDataByAccountEmployeeExpenseSheetId(AccountEmployeeExpenseSheetId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetvueAccountEmployeeExpenseSheetApprovalDetailReadOnly(ByVal AccountEmployeeExpenseSheetId As Guid) As AccountExpenseEntry.vueAccountEmployeeExpenseSheetApprovalDetailDataTable
        Dim _vueAccountEmployeeExpenseSheetTableAdapter As New vueAccountEmployeeExpenseSheetTableAdapter
        Dim _vueAccountEmployeeExpenseSheetApprovalDetailTableAdapter As New vueAccountEmployeeExpenseSheetApprovalDetailTableAdapter
        Return _vueAccountEmployeeExpenseSheetApprovalDetailTableAdapter.GetDataByAccountEmployeeExpenseSheetId(AccountEmployeeExpenseSheetId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetvueAccountEmployeeExpenseSheetByAccountEmployeeIdAndApprovalStatus(ByVal AccountEmployeeId As Integer, ByVal ExpenseSheetStatusId As Integer, ByVal IncludeDateRange As Boolean, ByVal StartDate As Date, ByVal EndDate As Date) As AccountExpenseEntry.vueAccountEmployeeExpenseSheetDataTable
        Dim _vueAccountEmployeeExpenseSheetTableAdapter As New vueAccountEmployeeExpenseSheetTableAdapter
        GetvueAccountEmployeeExpenseSheetByAccountEmployeeIdAndApprovalStatus = _vueAccountEmployeeExpenseSheetTableAdapter.GetDataByAccountEmployeeIdAndApprovalStatus(AccountEmployeeId, ExpenseSheetStatusId, IncludeDateRange, StartDate, EndDate)
        UIUtilities.FixTableForNoRecords(GetvueAccountEmployeeExpenseSheetByAccountEmployeeIdAndApprovalStatus)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetvueAccountEmployeeExpenseSheetByAccountEmployeeIdAndDateForMobile(ByVal AccountEmployeeId As Integer, ByVal ExpenseSheetDate As Date) As AccountExpenseEntry.vueAccountEmployeeExpenseSheetDataTable
        Dim _vueAccountEmployeeExpenseSheetTableAdapter As New vueAccountEmployeeExpenseSheetTableAdapter
        GetvueAccountEmployeeExpenseSheetByAccountEmployeeIdAndDateForMobile = _vueAccountEmployeeExpenseSheetTableAdapter.GetDataByAccountEmployeeIdAndDateForMobile(AccountEmployeeId, ExpenseSheetDate)
        'UIUtilities.FixTableForNoRecords(GetvueAccountEmployeeExpenseSheetByAccountEmployeeIdAndDateForMobile)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountEmployeeExpenseSheetByAccountIdAndDescription(ByVal AccountId As Integer, ByVal Description As String) As AccountExpenseEntry.AccountEmployeeExpenseSheetDataTable
        Return Adapter.GetDataByAccountIDAndDescription(Description, AccountId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, True)> _
    Public Function AddAccountEmployeeExpenseSheet( _
                ByVal AccountId As Integer, ByVal AccountEmployeeId As Integer, ByVal Description As String, ByVal ExpenseSheetDate As DateTime, _
                ByVal Approved As Boolean, ByVal Rejected As Boolean, ByVal Submitted As Boolean, ByVal InApproval As Boolean, _
                ByVal SubmittedDate As Date, Optional ByVal CustomField1 As String = "", _
                Optional ByVal CustomField2 As String = "", _
                Optional ByVal CustomField3 As String = "", _
                Optional ByVal CustomField4 As String = "", _
                Optional ByVal CustomField5 As String = "", _
                Optional ByVal CustomField6 As String = "", _
                Optional ByVal CustomField7 As String = "", _
                Optional ByVal CustomField8 As String = "", _
                Optional ByVal CustomField9 As String = "", _
                Optional ByVal CustomField10 As String = "", _
                Optional ByVal CustomField11 As String = "", _
                Optional ByVal CustomField12 As String = "", _
                Optional ByVal CustomField13 As String = "", _
                Optional ByVal CustomField14 As String = "", _
                Optional ByVal CustomField15 As String = "") As Guid

        _AccountEmployeeExpenseSheetTableAdapter = New AccountEmployeeExpenseSheetTableAdapter

        Dim dtExpenseSheet As New AccountExpenseEntry.AccountEmployeeExpenseSheetDataTable
        Dim drExpenseSheet As AccountExpenseEntry.AccountEmployeeExpenseSheetRow = dtExpenseSheet.NewAccountEmployeeExpenseSheetRow
        Dim AccountEmployeeExpenseSheetId As Guid = System.Guid.NewGuid

        With drExpenseSheet
            .AccountEmployeeExpenseSheetId = AccountEmployeeExpenseSheetId
            .AccountId = AccountId
            .AccountEmployeeId = AccountEmployeeId
            .Description = Description
            .ExpenseSheetDate = ExpenseSheetDate.Date
            .Approved = Approved
            .Rejected = Rejected
            .Submitted = Submitted
            .InApproval = InApproval
            .CreatedByEmployeeId = DBUtilities.GetSessionAccountEmployeeId
            .CreatedOn = Now.Date
            .ModifiedByEmployeeId = DBUtilities.GetSessionAccountEmployeeId
            .ModifiedOn = Now.Date
            If Submitted = True Then
                .SubmittedDate = SubmittedDate
            End If
            If CustomField1 <> "" Then
                .CustomField1 = CustomField1
            Else
                .Item("CustomField1") = System.DBNull.Value
            End If
            If CustomField2 <> "" Then
                .CustomField2 = CustomField2
            Else
                .Item("CustomField2") = System.DBNull.Value
            End If
            If CustomField3 <> "" Then
                .CustomField3 = CustomField3
            Else
                .Item("CustomField3") = System.DBNull.Value
            End If
            If CustomField4 <> "" Then
                .CustomField4 = CustomField4
            Else
                .Item("CustomField4") = System.DBNull.Value
            End If
            If CustomField5 <> "" Then
                .CustomField5 = CustomField5
            Else
                .Item("CustomField5") = System.DBNull.Value
            End If
            If CustomField6 <> "" Then
                .CustomField6 = CustomField6
            Else
                .Item("CustomField6") = System.DBNull.Value
            End If
            If CustomField7 <> "" Then
                .CustomField7 = CustomField7
            Else
                .Item("CustomField7") = System.DBNull.Value
            End If
            If CustomField8 <> "" Then
                .CustomField8 = CustomField8
            Else
                .Item("CustomField8") = System.DBNull.Value
            End If
            If CustomField9 <> "" Then
                .CustomField9 = CustomField9
            Else
                .Item("CustomField9") = System.DBNull.Value
            End If
            If CustomField10 <> "" Then
                .CustomField10 = CustomField10
            Else
                .Item("CustomField10") = System.DBNull.Value
            End If
            If CustomField11 <> "" Then
                .CustomField11 = CustomField11
            Else
                .Item("CustomField11") = System.DBNull.Value
            End If
            If CustomField12 <> "" Then
                .CustomField12 = CustomField12
            Else
                .Item("CustomField12") = System.DBNull.Value
            End If
            If CustomField13 <> "" Then
                .CustomField13 = CustomField13
            Else
                .Item("CustomField13") = System.DBNull.Value
            End If
            If CustomField14 <> "" Then
                .CustomField14 = CustomField14
            Else
                .Item("CustomField14") = System.DBNull.Value
            End If
            If CustomField15 <> "" Then
                .CustomField15 = CustomField15
            Else
                .Item("CustomField15") = System.DBNull.Value
            End If
            .PaymentStatusId = 0
        End With

        dtExpenseSheet.AddAccountEmployeeExpenseSheetRow(drExpenseSheet)

        Dim rowsAffected As Integer = Adapter.Update(dtExpenseSheet)
        Return AccountEmployeeExpenseSheetId
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)> _
    Public Function UpdateAccountEmployeeExpenseSheet( _
            ByVal Description As String, ByVal ExpenseSheetDate As DateTime, ByVal Original_AccountEmployeeExpenseSheetId As Guid, _
            Optional ByVal CustomField1 As String = "", _
            Optional ByVal CustomField2 As String = "", _
            Optional ByVal CustomField3 As String = "", _
            Optional ByVal CustomField4 As String = "", _
            Optional ByVal CustomField5 As String = "", _
            Optional ByVal CustomField6 As String = "", _
            Optional ByVal CustomField7 As String = "", _
            Optional ByVal CustomField8 As String = "", _
            Optional ByVal CustomField9 As String = "", _
            Optional ByVal CustomField10 As String = "", _
            Optional ByVal CustomField11 As String = "", _
            Optional ByVal CustomField12 As String = "", _
            Optional ByVal CustomField13 As String = "", _
            Optional ByVal CustomField14 As String = "", _
            Optional ByVal CustomField15 As String = "") As Boolean

        Dim dtExpenseSheet As AccountExpenseEntry.AccountEmployeeExpenseSheetDataTable = Adapter.GetDataByAccountEmployeeExpenseSheetId(Original_AccountEmployeeExpenseSheetId)
        Dim drExpenseSheet As AccountExpenseEntry.AccountEmployeeExpenseSheetRow = dtExpenseSheet.Rows(0)

        With drExpenseSheet
            .Description = Description
            .ExpenseSheetDate = ExpenseSheetDate.Date
            .ModifiedByEmployeeId = DBUtilities.GetSessionAccountEmployeeId
            .ModifiedOn = Now.Date
            If CustomField1 <> "" Then
                .CustomField1 = CustomField1
            Else
                .Item("CustomField1") = System.DBNull.Value
            End If
            If CustomField2 <> "" Then
                .CustomField2 = CustomField2
            Else
                .Item("CustomField2") = System.DBNull.Value
            End If
            If CustomField3 <> "" Then
                .CustomField3 = CustomField3
            Else
                .Item("CustomField3") = System.DBNull.Value
            End If
            If CustomField4 <> "" Then
                .CustomField4 = CustomField4
            Else
                .Item("CustomField4") = System.DBNull.Value
            End If
            If CustomField5 <> "" Then
                .CustomField5 = CustomField5
            Else
                .Item("CustomField5") = System.DBNull.Value
            End If
            If CustomField6 <> "" Then
                .CustomField6 = CustomField6
            Else
                .Item("CustomField6") = System.DBNull.Value
            End If
            If CustomField7 <> "" Then
                .CustomField7 = CustomField7
            Else
                .Item("CustomField7") = System.DBNull.Value
            End If
            If CustomField8 <> "" Then
                .CustomField8 = CustomField8
            Else
                .Item("CustomField8") = System.DBNull.Value
            End If
            If CustomField9 <> "" Then
                .CustomField9 = CustomField9
            Else
                .Item("CustomField9") = System.DBNull.Value
            End If
            If CustomField10 <> "" Then
                .CustomField10 = CustomField10
            Else
                .Item("CustomField10") = System.DBNull.Value
            End If
            If CustomField11 <> "" Then
                .CustomField11 = CustomField11
            Else
                .Item("CustomField11") = System.DBNull.Value
            End If
            If CustomField12 <> "" Then
                .CustomField12 = CustomField12
            Else
                .Item("CustomField12") = System.DBNull.Value
            End If
            If CustomField13 <> "" Then
                .CustomField13 = CustomField13
            Else
                .Item("CustomField13") = System.DBNull.Value
            End If
            If CustomField14 <> "" Then
                .CustomField14 = CustomField14
            Else
                .Item("CustomField14") = System.DBNull.Value
            End If
            If CustomField15 <> "" Then
                .CustomField15 = CustomField15
            Else
                .Item("CustomField15") = System.DBNull.Value
            End If
        End With

        Dim rowsAffected As Integer = Adapter.Update(dtExpenseSheet)
        Return rowsAffected = 1
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Delete, True)> _
    Public Function DeleteAccountEmployeeExpenseSheet(ByVal Original_AccountEmployeeExpenseSheetId As Guid) As Boolean
        Dim rowsAffected As Integer = Adapter.Delete(Original_AccountEmployeeExpenseSheetId)

        Return rowsAffected = 1
    End Function
    Public Sub UpdateMasterSubmitted(ByVal Submitted As Boolean, ByVal AccountEmployeeExpenseSheetId As Guid)
        Adapter.UpdateSubmitted(Submitted, AccountEmployeeExpenseSheetId)
    End Sub
    Public Sub UpdateMasterRejected(ByVal Rejected As Boolean, ByVal AccountEmployeeExpenseSheetId As Guid)
        Adapter.UpdateRejected(Rejected, AccountEmployeeExpenseSheetId)
    End Sub
    Public Sub UpdateRejectedByEmployeeId(ByVal RejectedByEmployeeId As Integer, ByVal AccountEmployeeExpenseSheetId As Guid)
        Adapter.UpdateRejectedByEmployeeId(Now.Date, RejectedByEmployeeId, AccountEmployeeExpenseSheetId)
    End Sub
    Public Sub UpdateApproved(ByVal Approved As Boolean, ByVal AccountEmployeeExpenseSheetId As Guid)
        Adapter.UpdateApproved(Approved, AccountEmployeeExpenseSheetId)
    End Sub
    Public Sub UpdateApprovedByEmployeeId(ByVal ApprovedByEmployeeId As Integer, ByVal AccountEmployeeExpenseSheetId As Guid)
        Adapter.UpdateApprovedOn(Now.Date, ApprovedByEmployeeId, AccountEmployeeExpenseSheetId)
    End Sub
    Public Sub UpdateSubmittedDate(ByVal SubmittedDate As Date, ByVal AccountEmployeeExpenseSheetId As Guid)
        Adapter.UpdateSubmittedDate(SubmittedDate, AccountEmployeeExpenseSheetId)
    End Sub
    Public Sub UpdateInApproval(ByVal InApproval As Boolean, ByVal AccountEmployeeExpenseSheetId As Guid)
        Adapter.UpdateInApproval(InApproval, AccountEmployeeExpenseSheetId)
    End Sub
    Public Sub UpdateExpenseArchiveMaster(ByVal Original_AccountEmployeeExpenseSheetId As Guid, _
    ByVal Approved As Boolean, ByVal Submitted As Boolean)

        Dim dt As AccountExpenseEntry.AccountEmployeeExpenseSheetDataTable = Adapter.GetDataByAccountEmployeeExpenseSheetId(Original_AccountEmployeeExpenseSheetId)
        Dim dr As AccountExpenseEntry.AccountEmployeeExpenseSheetRow = dt.Rows(0)

        With dr
            .ModifiedOn = Now
            .Approved = Approved
            .Submitted = Submitted
            If Submitted = True Then
                .Rejected = False
            End If
        End With

        Dim rowsAffected As Integer = Adapter.Update(dt)
    End Sub
    Public Function GetAccountEmployeeExpenseSheetIdByAccountIDAndDescription(ByVal AccountId As Integer, ByVal Description As String) As Guid
        Dim dt As AccountExpenseEntry.AccountEmployeeExpenseSheetDataTable = Adapter.GetDataByAccountIDAndDescription(Description, AccountId)
        Dim dr As AccountExpenseEntry.AccountEmployeeExpenseSheetRow
        If dt.Rows.Count > 0 Then
            dr = dt.Rows(0)
            Return dr.AccountEmployeeExpenseSheetId
        End If
    End Function
    Public Function GetAccountEmployeeExpenseSheetIdByAccountEmployeeIdDescriptionAndDate(ByVal AccountEmployeeId As Integer, ByVal Description As String, ByVal ExpenseSheetDate As Date) As Guid
        Dim dt As AccountExpenseEntry.AccountEmployeeExpenseSheetDataTable = Adapter.GetDataByAccountEmployeeIdDescriptionAndExpenseSheetDate(Description, AccountEmployeeId, ExpenseSheetDate)
        Dim dr As AccountExpenseEntry.AccountEmployeeExpenseSheetRow
        If dt.Rows.Count > 0 Then
            dr = dt.Rows(0)
            Return dr.AccountEmployeeExpenseSheetId
        End If
    End Function
    Public Function IsExpenseSheetExistsByAccountIDAndDescription(ByVal AccountID As Integer, ByVal Description As String)
        If Adapter.GetDataByAccountIDAndDescription(Description, AccountID).Rows.Count > 0 Then
            Return True
        End If
    End Function
    Public Function IsExpenseSheetExistsByAccountEmployeeIdADescriptionAndDate(ByVal AccountEmployeeId As Integer, ByVal Description As String, ByVal ExpenseSheetDate As Date)
        If Adapter.GetDataByAccountEmployeeIdDescriptionAndExpenseSheetDate(Description, AccountEmployeeId, ExpenseSheetDate).Rows.Count > 0 Then
            Return True
        End If
    End Function
    Public Sub InsertAccountEmployeeExpenseSheetByExpenseSheetId(ByVal AccountEmployeeExpenseSheetId As Guid, ByVal NewExpenseSheetId As Guid)
        Adapter.InsertExpenseSheetByExpenseSheetId(AccountEmployeeExpenseSheetId, NewExpenseSheetId, DBUtilities.GetSessionAccountEmployeeId, Now.Date)
    End Sub
End Class

