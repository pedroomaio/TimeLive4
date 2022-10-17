Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Xml

<WebService(Namespace:="http://tempuri.org/")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public Class ExpenseApproval
    Inherits System.Web.Services.WebService

    Public SoapHeader As SecuredWebServiceHeader
    <WebMethod()> _
    <System.Web.Services.Protocols.SoapHeader("SoapHeader")> _
    Public Function ExpenseApproval(ByVal objExpenseApproval As ExpenseApprovalObject) As String
        If Not TimeLiveServices.IsUserValid(SoapHeader) Then
            Return "Please call AuthenitcateUser() first."
        End If
        Return "Hello World"
    End Function
    <WebMethod()> _
    <System.Web.Services.Protocols.SoapHeader("SoapHeader")> _
    Public Function GetExpenseApprovalEntries() As ArrayList
        If Not TimeLiveServices.IsUserValid(SoapHeader) Then
            Throw New Exception("You are not authorized to access this.")
        End If
        Dim ExpenseApprovalArrayList As New ArrayList
        Dim objExpenseApproval As New ExpenseApprovalObject
        Dim ExpenseEntryBLL As New AccountExpenseEntryBLL
        Dim AccountId As Integer = TimeLiveServices.GetSecurityToken(SoapHeader.AuthenticatedToken).AccountID
        Dim AccountEmployeeId As Integer = TimeLiveServices.GetSecurityToken(SoapHeader.AuthenticatedToken).AccountEmployeeId
        Dim TotalHours As String = "00:00"
        Dim dtExpenseApproval As AccountExpenseEntry.vueAccountExpenseEntryApprovalPendingSummaryDataTable = ExpenseEntryBLL.GetApprovalEntriesSummarizedForMobile(AccountEmployeeId, 0, Now.Date, Now.Date, False)
        Dim drExpenseApproval As AccountExpenseEntry.vueAccountExpenseEntryApprovalPendingSummaryRow
        For Each drExpenseApproval In dtExpenseApproval.Rows
            objExpenseApproval = New ExpenseApprovalObject
            With objExpenseApproval
                .EmployeeName = drExpenseApproval.EmployeeName
                .ExpenseSheetDate = drExpenseApproval.ExpenseSheetDate
                .ExpenseSheetDescription = drExpenseApproval.Description
                .ExpenseSheetAmount = drExpenseApproval.Amount
                .AccountEmployeeExpenseSheetId = drExpenseApproval.AccountEmployeeExpenseSheetId
                .ExpenseEntryAccountEmployeeId = drExpenseApproval.ExpenseEntryAccountEmployeeId
            End With
            ExpenseApprovalArrayList.Add(objExpenseApproval)
        Next
        Return ExpenseApprovalArrayList
    End Function
    <WebMethod()> _
    <System.Web.Services.Protocols.SoapHeader("SoapHeader")> _
    Public Function UpdateExpenseApprovals(ApprovalList As ArrayList) As String
        If Not TimeLiveServices.IsUserValid(SoapHeader) Then
            Throw New Exception("You are not authorized to access this.")
        End If
        Try
            Dim ExpenseApprovalArrayList As New ArrayList
            Dim objExpenseApproval As New ExpenseApprovalObject
            Dim ExpenseEntryBLL As New AccountExpenseEntryBLL


            Dim AccountId As Integer = TimeLiveServices.GetSecurityToken(SoapHeader.AuthenticatedToken).AccountID
            Dim AccountEmployeeId As Integer = TimeLiveServices.GetSecurityToken(SoapHeader.AuthenticatedToken).AccountEmployeeId
            ''For i As Integer = 0 To ApprovalList.Count - 1
            ''    'Dim nodetest = ApprovalList.Item(i)
            ''    'Dim systemapprovertypeid = nodetest(0).firstchild.value
            ''    'Dim ExpenseSheetId As New Guid(nodetest(1).firstchild.value.ToString)
            ''    'Dim IsApprove = nodetest(2).firstchild.value
            ''    'Dim IsReject = nodetest(3).firstchild.value

            ''    'expenseentrybll.bul

            ''    'ExpenseEntryBLL.BulkExpenseEntryApprovalEntriesForApprovedForMobile(ExpenseSheetId, IsApprove, "", "", 0, False, Now.Date, Now.Date, AccountEmployeeId, 0)
            ''    ''ExpenseEntryBLL.BulkExpenseEntryApprovalEntriesForApproved(ExpenseSheetId, , AccountEmployeeId, dremployee.FirstName & " " & dremployee.LastName, AccountEmployeeId, dremployee.EMailAddress, drAccountEmployeeTimeEntryPeriod.TimeEntryStartDate, drAccountEmployeeTimeEntryPeriod.TimeEntryEndDate, TimeEntryPeriodId, "MObile Test", 0, IsApprove, IsReject, systemapprovertypeid)

            ''Next
            Return "Record Updated"
        Catch ex As Exception
            Return ex.Message
        End Try

    End Function
End Class