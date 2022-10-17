Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.IO
Imports System.Drawing

<WebService(Namespace:="http://tempuri.org/")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public Class ExpenseEntries
    Inherits System.Web.Services.WebService
    Public SoapHeader As SecuredWebServiceHeader
    <WebMethod()> _
    <System.Web.Services.Protocols.SoapHeader("SoapHeader")> _
    Public Function AddExpenseEntry(ByVal objExpenseEntry As ExpenseEntry) As String
        If Not TimeLiveServices.IsUserValid(SoapHeader) Then
            Return "Please call AuthenitcateUser() first."
        End If
        Return "Hello World"
    End Function
    <WebMethod()> _
<System.Web.Services.Protocols.SoapHeader("SoapHeader")> _
    Public Function ExpenseEntryForMobileObject(ByVal objExpenseEntry As ExpenseEntryListForMobile) As String
        If Not TimeLiveServices.IsUserValid(SoapHeader) Then
            Return "Please call AuthenitcateUser() first."
        End If
        Return "Hello World"
    End Function
    <WebMethod()> _
<System.Web.Services.Protocols.SoapHeader("SoapHeader")> _
    Public Function AccountCurrencyForMobileObject(ByVal ObjCurrency As ReimbursementCurrencyForMobile) As String
        If Not TimeLiveServices.IsUserValid(SoapHeader) Then
            Return "Please call AuthenitcateUser() first."
        End If
        Return "Hello World"
    End Function
    <WebMethod()> _
<System.Web.Services.Protocols.SoapHeader("SoapHeader")> _
    Public Function AccountPaymentMethodForMobileObject(ByVal objPaymentMethodList As PaymentMethodForMobile) As String
        If Not TimeLiveServices.IsUserValid(SoapHeader) Then
            Return "Please call AuthenitcateUser() first."
        End If
        Return "Hello World"
    End Function
    <WebMethod()> _
<System.Web.Services.Protocols.SoapHeader("SoapHeader")> _
    Public Function TaxZoneForMobileObject(ByVal ObjTaxZone As TaxZoneForMobile) As String
        If Not TimeLiveServices.IsUserValid(SoapHeader) Then
            Return "Please call AuthenitcateUser() first."
        End If
        Return "Hello World"
    End Function
    <WebMethod()> _
<System.Web.Services.Protocols.SoapHeader("SoapHeader")> _
    Public Function CurrencyExchangeForMobileObject(ByVal ObjCurrency As AccountCurrencyForMobile) As String
        If Not TimeLiveServices.IsUserValid(SoapHeader) Then
            Return "Please call AuthenitcateUser() first."
        End If
        Return "Hello World"
    End Function
    <WebMethod()> _
<System.Web.Services.Protocols.SoapHeader("SoapHeader")> _
    Public Function AccountExpenseEntryForMobileObject(ByVal objExpenseEntry As AccountExpenseEntryForMobile) As String
        If Not TimeLiveServices.IsUserValid(SoapHeader) Then
            Return "Please call AuthenitcateUser() first."
        End If
        Return "Hello World"
    End Function
    <WebMethod()> _
<System.Web.Services.Protocols.SoapHeader("SoapHeader")> _
    Public Function ExpenseSheetForMobileObject(ByVal objExpenseSheet As ExpenseSheetListForMobile) As String
        If Not TimeLiveServices.IsUserValid(SoapHeader) Then
            Return "Please call AuthenitcateUser() first."
        End If
        Return "Hello World"
    End Function
    <WebMethod()> _
    <System.Web.Services.Protocols.SoapHeader("SoapHeader")> _
    Public Function ShowFieldsByExpenseNameForMobileObject(ByVal ObjShowFieldsByExpenseName As ShowFieldsByExpenseNameForMobile) As String
        If Not TimeLiveServices.IsUserValid(SoapHeader) Then
            Return "Please call AuthenitcateUser() first."
        End If
        Return "Hello World"
    End Function
    <WebMethod()> _
    <System.Web.Services.Protocols.SoapHeader("SoapHeader")> _
    Public Function CalculateAmountByExpenseForMobileObject(ByVal ObjCalculateAmount As CalculateAmountByExpenseForMobile) As String
        If Not TimeLiveServices.IsUserValid(SoapHeader) Then
            Return "Please call AuthenitcateUser() first."
        End If
        Return "Hello World"
    End Function
    <WebMethod()> _
    <System.Web.Services.Protocols.SoapHeader("SoapHeader")> _
    Public Function GetAllExpenseEntriesByDateRange(ByVal StartDate As Date, ByVal EndDate As Date) As ArrayList
        If Not TimeLiveServices.IsUserValid(SoapHeader) Then
            Throw New Exception("You are not authorized to access this.")
        End If
        Dim ExpenseEntryList As New ArrayList
        Dim objExpenseEntry As New ExpenseEntry
        Dim ExpenseEntryBLL As New AccountExpenseEntryBLL
        Dim AccountId As Integer = TimeLiveServices.GetSecurityToken(SoapHeader.AuthenticatedToken).AccountID
        Dim dtExpenseEntry As AccountExpenseEntry.vueAccountExpenseEntryForQBDataTable = ExpenseEntryBLL.GetExpenseEntriesByDateRange(AccountId, StartDate, EndDate)
        Dim drExpenseEntry As AccountExpenseEntry.vueAccountExpenseEntryForQBRow
        For Each drExpenseEntry In dtExpenseEntry.Rows
            objExpenseEntry = New ExpenseEntry
            With objExpenseEntry
                .ClientWithProject = drExpenseEntry.CustomerJob
                .EmployeeName = drExpenseEntry.EmployeeName
                .ExpenseEntryDate = drExpenseEntry.AccountExpenseEntryDate
                .Amount = drExpenseEntry.Amount
                .ExpenseName = drExpenseEntry.AccountExpenseName
                .ExpenseType = drExpenseEntry.ExpenseType
            End With
            ExpenseEntryList.Add(objExpenseEntry)
        Next
        Return ExpenseEntryList
    End Function
    <WebMethod()> _
    <System.Web.Services.Protocols.SoapHeader("SoapHeader")> _
    Public Function GetExpenseEntriesByEmployeeIdAndDateRange(ByVal AccountEmployeeId As Integer, ByVal StartDate As Date, ByVal EndDate As Date) As ArrayList
        If Not TimeLiveServices.IsUserValid(SoapHeader) Then
            Throw New Exception("You are not authorized to access this.")
        End If
        Dim ExpenseEntryList As New ArrayList
        Dim objExpenseEntry As New ExpenseEntry
        Dim ExpenseEntryBLL As New AccountExpenseEntryBLL
        Dim AccountId As Integer = TimeLiveServices.GetSecurityToken(SoapHeader.AuthenticatedToken).AccountID
        Dim dtExpenseEntry As AccountExpenseEntry.vueAccountExpenseEntryForQBDataTable = ExpenseEntryBLL.GetExpenseEntriesByEmployeeIdAndDateRange(AccountId, AccountEmployeeId, StartDate, EndDate)
        Dim drExpenseEntry As AccountExpenseEntry.vueAccountExpenseEntryForQBRow
        For Each drExpenseEntry In dtExpenseEntry.Rows
            objExpenseEntry = New ExpenseEntry
            With objExpenseEntry
                .ClientWithProject = drExpenseEntry.CustomerJob
                .EmployeeName = drExpenseEntry.EmployeeName
                .ExpenseEntryDate = drExpenseEntry.AccountExpenseEntryDate
                .Amount = drExpenseEntry.Amount
                .ExpenseName = drExpenseEntry.AccountExpenseName
                .ExpenseType = drExpenseEntry.ExpenseType
            End With
            ExpenseEntryList.Add(objExpenseEntry)
        Next
        Return ExpenseEntryList
    End Function
    <WebMethod()> _
    <System.Web.Services.Protocols.SoapHeader("SoapHeader")> _
    Public Function AddExpenseName(ByVal objExpenseName As ExpenseName) As String
        If Not TimeLiveServices.IsUserValid(SoapHeader) Then
            Return "Please call AuthenitcateUser() first."
        End If
        Return "Hello World"
    End Function
    <WebMethod()> _
    <System.Web.Services.Protocols.SoapHeader("SoapHeader")> _
    Public Function GetExpenseNames() As ArrayList
        If Not TimeLiveServices.IsUserValid(SoapHeader) Then
            Throw New Exception("You are not authorized to access this.")
        End If
        Dim ExpenseNameList As New ArrayList
        Dim objExpenseName As New ExpenseName
        Dim ExpenseNameBLL As New AccountExpenseBLL
        Dim AccountId As Integer = TimeLiveServices.GetSecurityToken(SoapHeader.AuthenticatedToken).AccountID
        Dim dtExpenseName As TimeLiveDataSet.AccountExpenseDataTable = ExpenseNameBLL.GetAccountExpensesByAccountIdAndIsDisabled(AccountId, 0)
        Dim drExpenseName As TimeLiveDataSet.AccountExpenseRow
        For Each drExpenseName In dtExpenseName.Rows
            objExpenseName = New ExpenseName
            With objExpenseName
                .ExpenseName = drExpenseName.AccountExpenseName
            End With
            ExpenseNameList.Add(objExpenseName)
        Next
        Return ExpenseNameList
    End Function
    <WebMethod()> _
    <System.Web.Services.Protocols.SoapHeader("SoapHeader")> _
    Public Function GetExpenseApprovalTypeId() As Integer
        If Not TimeLiveServices.IsUserValid(SoapHeader) Then
            Throw New Exception("You are not authorized to access this.")
        End If
        Dim objExpenseApprovalType As New AccountApprovalBLL
        Dim AccountId As Integer = TimeLiveServices.GetSecurityToken(SoapHeader.AuthenticatedToken).AccountID
        Dim nExpenseApprovalTypeId As Integer = objExpenseApprovalType.GetAccountApprovalTypesByAccountIdForTimeSheetApproval(AccountId).Rows(0).Item(0)
        Return nExpenseApprovalTypeId
    End Function
    <WebMethod()> _
<System.Web.Services.Protocols.SoapHeader("SoapHeader")> _
    Public Function GetExpenseSheetByDateForMobile(ByVal YearWS As Integer, ByVal MonthWS As Integer, ByVal DayWS As Integer) As ArrayList
        If Not TimeLiveServices.IsUserValid(SoapHeader) Then
            Throw New Exception("You are not authorized to access this.")
        End If
        Dim ExpenseSheetArray As New ArrayList
        Dim objExpenseSheetList As New ExpenseSheetListForMobile
        Dim ExpenseSheetBll As New AccountEmployeeExpenseSheetBLL
        Dim dtDate As Date = New Date(YearWS, MonthWS, DayWS)
        Dim AccountEmployeeId As Integer = TimeLiveServices.GetSecurityToken(SoapHeader.AuthenticatedToken).AccountEmployeeId
        Dim dtExpenseSheet As AccountExpenseEntry.vueAccountEmployeeExpenseSheetDataTable = ExpenseSheetBll.GetvueAccountEmployeeExpenseSheetByAccountEmployeeIdAndDateForMobile(AccountEmployeeId, dtDate)
        Dim drExpenseSheet As AccountExpenseEntry.vueAccountEmployeeExpenseSheetRow
        For Each drExpenseSheet In dtExpenseSheet.Rows
            objExpenseSheetList = New ExpenseSheetListForMobile
            With objExpenseSheetList
                .AccountEmployeeId = drExpenseSheet.AccountEmployeeId
                If Not IsDBNull(drExpenseSheet.Item("AccountEmployeeExpenseSheetId")) Then
                    .AccountEmployeeExpenseSheetId = drExpenseSheet.AccountEmployeeExpenseSheetId.ToString
                Else
                    .AccountEmployeeExpenseSheetId = System.Guid.Empty.ToString
                End If
                If Not IsDBNull(drExpenseSheet.Item("ExpenseSheetDate")) Then
                    .ExpenseSheetDate = drExpenseSheet.ExpenseSheetDate
                Else
                    .ExpenseSheetDate = ""
                End If
                If Not IsDBNull(drExpenseSheet.Item("Description")) Then
                    .Description = drExpenseSheet.Description
                Else
                    .Description = ""
                End If
                If Not IsDBNull(drExpenseSheet.Item("CurrencyCode")) Then
                    .CurrencyCode = drExpenseSheet.CurrencyCode
                Else
                    .CurrencyCode = ""
                End If
                If Not IsDBNull(drExpenseSheet.Item("Amount")) Then
                    .Amount = Math.Round(drExpenseSheet.Item("Amount"), 2)
                Else
                    .Amount = ""
                End If
                If Not IsDBNull(drExpenseSheet.Item("Status")) Then
                    .Status = drExpenseSheet.Status
                Else
                    .Status = ""
                End If
                .IsShowClient = False
                .IsShowTask = False
            End With
            ExpenseSheetArray.Add(objExpenseSheetList)
        Next
        Return ExpenseSheetArray
    End Function
    <WebMethod()> _
<System.Web.Services.Protocols.SoapHeader("SoapHeader")> _
    Public Function GetExpenseEntriesByExpenseSheetIdForMobile(ByVal AccountEmployeeExpenseSheetId As Guid) As ArrayList
        If Not TimeLiveServices.IsUserValid(SoapHeader) Then
            Throw New Exception("You are not authorized to access this.")
        End If
        Dim ExpenseEntryList As New ArrayList
        Dim objExpenseEntry As New ExpenseEntryListForMobile
        Dim ExpenseEntryBLL As New AccountExpenseEntryBLL
        Dim AccountId As Integer = TimeLiveServices.GetSecurityToken(SoapHeader.AuthenticatedToken).AccountID
        Dim dtExpenseEntry As TimeLiveDataSet.vueAccountExpenseEntryWithLastStatusForMobileDataTable = ExpenseEntryBLL.GetvueAccountExpenseEntryWithLastStatusByExpenseSheetIdForMobile(AccountId, AccountEmployeeExpenseSheetId)
        Dim drExpenseEntry As TimeLiveDataSet.vueAccountExpenseEntryWithLastStatusForMobileRow
        For Each drExpenseEntry In dtExpenseEntry.Rows
            objExpenseEntry = New ExpenseEntryListForMobile
            With objExpenseEntry
                If Not IsDBNull(drExpenseEntry.Item("AccountEmployeeExpenseSheetId")) Then
                    .AccountEmployeeExpenseSheetId = drExpenseEntry.AccountEmployeeExpenseSheetId.ToString
                Else
                    .AccountEmployeeExpenseSheetId = System.Guid.Empty.ToString
                End If
                .AccountExpenseEntryId = drExpenseEntry.AccountExpenseEntryId
                .AccountExpenseId = drExpenseEntry.AccountExpenseId
                If Not IsDBNull(drExpenseEntry.Item("AccountExpenseName")) Then
                    .AccountExpenseName = drExpenseEntry.AccountExpenseName
                Else
                    .AccountExpenseName = ""
                End If
                If Not IsDBNull(drExpenseEntry.Item("Description")) Then
                    .ExpenseEntryDescription = drExpenseEntry.Description
                Else
                    .ExpenseEntryDescription = ""
                End If
                If Not IsDBNull(drExpenseEntry.Item("Amount")) Then
                    .ExpenseEntryAmount = drExpenseEntry.Amount
                Else
                    .ExpenseEntryAmount = Nothing
                End If
                If Not IsDBNull(drExpenseEntry.Item("CurrencyCode")) Then
                    .ExpenseEntryCurrencyCode = drExpenseEntry.CurrencyCode
                Else
                    .ExpenseEntryCurrencyCode = ""
                End If
                If IsDBNull(drExpenseEntry.Item("AccountTaxCodeId")) Then
                    .AccountTaxCodeId = 0
                Else
                    .AccountTaxCodeId = drExpenseEntry.AccountTaxCodeId
                End If
                If IsDBNull(drExpenseEntry.Item("AccountTaxZoneId")) Then
                    .AccountTaxZoneId = 0
                Else
                    .AccountTaxZoneId = drExpenseEntry.AccountTaxZoneId
                End If
                If IsDBNull(drExpenseEntry.Item("AccountPaymentMethodId")) Then
                    .AccountPaymentMethodId = 0
                Else
                    .AccountPaymentMethodId = drExpenseEntry.AccountPaymentMethodId
                End If
                .AccountClientId = drExpenseEntry.AccountClientId
                .AccountProjectId = drExpenseEntry.AccountProjectId
                If IsDBNull(drExpenseEntry.Item("AccountProjectTaskId")) Then
                    .AccountProjectTaskId = 0
                Else
                    .AccountProjectTaskId = drExpenseEntry.AccountProjectTaskId
                End If
                If Not IsDBNull(drExpenseEntry.Item("NetAmount")) Then
                    .NetAmount = drExpenseEntry.NetAmount
                Else
                    .NetAmount = Nothing
                End If
                If Not IsDBNull(drExpenseEntry.Item("Reimburse")) Then
                    .Reimburse = drExpenseEntry.Reimburse
                Else
                    .Reimburse = False
                End If
                If Not IsDBNull(drExpenseEntry.Item("IsBillable")) Then
                    .Billable = drExpenseEntry.IsBillable
                Else
                    .Billable = False
                End If
                If Not IsDBNull(drExpenseEntry.Item("Quantity")) Then
                    .Quantity = drExpenseEntry.Quantity
                Else
                    .Quantity = Nothing
                End If
                If Not IsDBNull(drExpenseEntry.Item("Rate")) Then
                    .Rate = drExpenseEntry.Rate
                Else
                    .Rate = Nothing
                End If
                If Not IsDBNull(drExpenseEntry.Item("TaxAmount")) Then
                    .TaxAmount = drExpenseEntry.TaxAmount
                Else
                    .TaxAmount = Nothing
                End If
                .IsShowClient = False
                .IsShowTask = False
            End With
            ExpenseEntryList.Add(objExpenseEntry)
        Next
        Return ExpenseEntryList
    End Function
    <WebMethod()> _
<System.Web.Services.Protocols.SoapHeader("SoapHeader")> _
    Public Function GetExpenseEntriesByExpenseEntryIdForMobile(ByVal AccountExpenseEntryId As Integer) As ArrayList
        If Not TimeLiveServices.IsUserValid(SoapHeader) Then
            Throw New Exception("You are not authorized to access this.")
        End If
        Dim ExpenseEntryId As New ArrayList
        Dim objExpenseEntry As New AccountExpenseEntryForMobile
        Dim ExpenseEntryBLL As New AccountExpenseEntryBLL
        Dim dtExpenseEntry As AccountExpenseEntry.vueAccountExpenseEntryForMobileDataTable = ExpenseEntryBLL.GetvueAccountExpenseEntriesByAccountExpenseEntryIdForMobile(AccountExpenseEntryId)
        Dim drExpenseEntry As AccountExpenseEntry.vueAccountExpenseEntryForMobileRow
        For Each drExpenseEntry In dtExpenseEntry.Rows
            objExpenseEntry = New AccountExpenseEntryForMobile
            With objExpenseEntry
                .AccountId = drExpenseEntry.AccountId
                .AccountEmployeeExpenseSheetId = drExpenseEntry.AccountEmployeeExpenseSheetId.ToString
                .AccountExpenseEntryId = drExpenseEntry.AccountExpenseEntryId
                .AccountEmployeeId = drExpenseEntry.AccountEmployeeId
                If Not IsDBNull(drExpenseEntry.Item("AccountClientId")) Then
                    .AccountClientId = drExpenseEntry.AccountClientId
                Else
                    .AccountClientId = 0
                End If
                .AccountProjectId = drExpenseEntry.AccountProjectId
                If Not IsDBNull(drExpenseEntry.Item("AccountProjectTaskId")) Then
                    .AccountProjectTaskId = drExpenseEntry.AccountProjectTaskId
                Else
                    .AccountProjectTaskId = 0
                End If
                .AccountExpenseId = drExpenseEntry.AccountExpenseId
                .ExpenseSheetDescription = drExpenseEntry.ExpenseSheetDescription
                .ExpenseEntryDescription = drExpenseEntry.Description
                .AccountExpenseEntryDate = drExpenseEntry.AccountExpenseEntryDate
                .Reimburse = drExpenseEntry.Reimburse
                If Not IsDBNull(drExpenseEntry.Item("AccountPaymentMethodId")) Then
                    .PaymentMethodId = drExpenseEntry.AccountPaymentMethodId
                Else
                    .PaymentMethodId = 0
                End If
                .AccountCurrencyId = drExpenseEntry.AccountCurrencyId
                .NetAmount = drExpenseEntry.NetAmount
                If Not IsDBNull(drExpenseEntry.Item("AccountTaxZoneId")) Then
                    .AccountTaxZoneId = drExpenseEntry.AccountTaxZoneId
                Else
                    .AccountTaxZoneId = 0
                End If
                .TaxAmount = drExpenseEntry.TaxAmount
                .Amount = drExpenseEntry.Amount
                If Not IsDBNull(drExpenseEntry.Item("IsBillable")) Then
                    .Billable = drExpenseEntry.IsBillable
                Else
                    .Billable = False
                End If
                If Not IsDBNull(drExpenseEntry.Item("Quantity")) Then
                    .Quantity = drExpenseEntry.Quantity
                Else
                    .Quantity = 0
                End If
                If Not IsDBNull(drExpenseEntry.Item("Rate")) Then
                    .Rate = drExpenseEntry.Rate
                Else
                    .Rate = 0
                End If
                .IsShowClient = False
                .IsShowTask = False
            End With
            ExpenseEntryId.Add(objExpenseEntry)
        Next
        Return ExpenseEntryId
    End Function
    <WebMethod()> _
<System.Web.Services.Protocols.SoapHeader("SoapHeader")> _
    Public Function GetExpenseNameByAccountIdForMobile() As ArrayList
        If Not TimeLiveServices.IsUserValid(SoapHeader) Then
            Throw New Exception("You are not authorized to access this.")
        End If
        Dim ExpenseNameArray As New ArrayList
        Dim objExpenseNameList As New ExpenseEntry
        Dim ExpenseBLL As New AccountExpenseBLL
        Dim AccountId As Integer = TimeLiveServices.GetSecurityToken(SoapHeader.AuthenticatedToken).AccountID
        Dim dtExpenseName As TimeLiveDataSet.AccountExpenseDataTable = ExpenseBLL.GetAccountExpensesByAccountIdAndIsDisabled(AccountId, 0)
        Dim drExpenseName As TimeLiveDataSet.AccountExpenseRow
        For Each drExpenseName In dtExpenseName.Rows
            objExpenseNameList = New ExpenseEntry
            With objExpenseNameList
                .AccountExpenseId = drExpenseName.AccountExpenseId
                .ExpenseName = drExpenseName.AccountExpenseName
            End With
            ExpenseNameArray.Add(objExpenseNameList)
        Next
        Return ExpenseNameArray
    End Function
    <WebMethod()> _
<System.Web.Services.Protocols.SoapHeader("SoapHeader")> _
    Public Function GetPaymentMethodsByAccountIdForMobile() As ArrayList
        If Not TimeLiveServices.IsUserValid(SoapHeader) Then
            Throw New Exception("You are not authorized to access this.")
        End If
        Dim PaymentMethodArray As New ArrayList
        Dim objPaymentMethodList As New PaymentMethodForMobile
        Dim PaymentMethodBLL As New AccountPaymentMethodBLL
        Dim AccountId As Integer = TimeLiveServices.GetSecurityToken(SoapHeader.AuthenticatedToken).AccountID
        Dim dtPaymentMethod As TimeLiveDataSet.AccountPaymentMethodDataTable = PaymentMethodBLL.GetAccountPaymentMethodByAccountIdAndIsDisabled(AccountId, 0)
        Dim drPaymentMethod As TimeLiveDataSet.AccountPaymentMethodRow
        For Each drPaymentMethod In dtPaymentMethod.Rows
            objPaymentMethodList = New PaymentMethodForMobile
            With objPaymentMethodList
                If Not IsDBNull(drPaymentMethod.Item("AccountPaymentMethodId")) Then
                    .AccountPaymentMethodId = drPaymentMethod.AccountPaymentMethodId
                Else
                    .AccountPaymentMethodId = Nothing
                End If
                If Not IsDBNull(drPaymentMethod.Item("AccountPaymentMethodId")) Then
                    .PaymentMethod = drPaymentMethod.PaymentMethod
                Else
                    .PaymentMethod = Nothing
                End If
            End With
            PaymentMethodArray.Add(objPaymentMethodList)
        Next
        Return PaymentMethodArray
    End Function
    <WebMethod()> _
<System.Web.Services.Protocols.SoapHeader("SoapHeader")> _
    Public Function GetAccountCurrenciesByAccountIdForMobile() As ArrayList
        If Not TimeLiveServices.IsUserValid(SoapHeader) Then
            Throw New Exception("You are not authorized to access this.")
        End If
        Dim CurrencyArray As New ArrayList
        Dim ObjCurrency As New ReimbursementCurrencyForMobile
        Dim CurrencyBLL As New AccountCurrencyBLL
        Dim AccountId As Integer = TimeLiveServices.GetSecurityToken(SoapHeader.AuthenticatedToken).AccountID
        Dim dtCurrency As AccountCurrency.vueAccountCurrencyDataTable = CurrencyBLL.GetvueAccountCurrencyByAccountIdAndDisabled(AccountId, 0)
        Dim drCurrency As AccountCurrency.vueAccountCurrencyRow
        For Each drCurrency In dtCurrency.Rows
            ObjCurrency = New ReimbursementCurrencyForMobile
            With ObjCurrency
                .AccountCurrencyId = drCurrency.AccountCurrencyId
                .CurrencyCode = drCurrency.CurrencyCode
            End With
            CurrencyArray.Add(ObjCurrency)
        Next
        Return CurrencyArray
    End Function
    <WebMethod()> _
<System.Web.Services.Protocols.SoapHeader("SoapHeader")> _
    Public Function GetTaxZoneByAccountId() As ArrayList
        If Not TimeLiveServices.IsUserValid(SoapHeader) Then
            Throw New Exception("You are not authorized to access this.")
        End If
        Dim TaxZoneArray As New ArrayList
        Dim ObjTaxZone As New TaxZoneForMobile
        Dim TaxZoneBLL As New AccountTaxZoneBLL
        Dim AccountId As Integer = TimeLiveServices.GetSecurityToken(SoapHeader.AuthenticatedToken).AccountID
        Dim dtTaxZone As TimeLiveDataSet.AccountTaxZoneDataTable = TaxZoneBLL.GetAccountTaxZonesByAccountIdAndIsDisabled(AccountId, 0)
        Dim drTaxZone As TimeLiveDataSet.AccountTaxZoneRow
        For Each drTaxZone In dtTaxZone.Rows
            ObjTaxZone = New TaxZoneForMobile
            With ObjTaxZone
                If Not IsDBNull(drTaxZone.Item("AccountTaxZoneId")) Then
                    .TaxZoneId = drTaxZone.AccountTaxZoneId
                Else
                    .TaxZoneId = 0
                End If
                If Not IsDBNull(drTaxZone.Item("AccountTaxZone")) Then
                    .TaxZone = drTaxZone.AccountTaxZone
                Else
                    .TaxZone = ""
                End If
            End With
            TaxZoneArray.Add(ObjTaxZone)
        Next
        Return TaxZoneArray
    End Function
    <WebMethod()> _
<System.Web.Services.Protocols.SoapHeader("SoapHeader")> _
    Public Function GetExpenseTypeNameByExpenseTypeIdForMobile(ByVal AccountExpenseTypeId As Integer) As ArrayList
        If Not TimeLiveServices.IsUserValid(SoapHeader) Then
            Throw New Exception("You are not authorized to access this.")
        End If
        Dim ExpenseEntryList As New ArrayList
        Dim objExpenseType As New ExpenseType
        Dim ExpenseTypeBLL As New AccountExpenseTypeBLL
        Dim dtExpenseEntry As TimeLiveDataSet.vueAccountExpenseTypeDataTable = ExpenseTypeBLL.GetvueAccountExpenseTypesByAccountExpenseTypeId(AccountExpenseTypeId)
        Dim drExpenseEntry As TimeLiveDataSet.vueAccountExpenseTypeRow
        For Each drExpenseEntry In dtExpenseEntry.Rows
            objExpenseType = New ExpenseType
            With objExpenseType
                .ExpenseEntryType = drExpenseEntry.ExpenseType
            End With
            ExpenseEntryList.Add(objExpenseType)
        Next
        Return ExpenseEntryList
    End Function
    <WebMethod()> _
<System.Web.Services.Protocols.SoapHeader("SoapHeader")> _
    Public Function GetTaxZoneByTaxZoneId(ByVal AccountId As Integer, ByVal AccountTaxZoneId As Integer) As ArrayList
        If Not TimeLiveServices.IsUserValid(SoapHeader) Then
            Throw New Exception("You are not authorized to access this.")
        End If
        Dim TaxZoneId As New ArrayList
        Dim ObjTaxZone As New TaxZoneForMobile
        Dim TaxZoneBLL As New AccountTaxZoneBLL
        Dim dtTaxZone As TimeLiveDataSet.AccountTaxZoneDataTable = TaxZoneBLL.GetAccountTaxZonesByAccountIdAndIsDisabled(AccountId, AccountTaxZoneId)
        Dim drTaxZone As TimeLiveDataSet.AccountTaxZoneRow
        For Each drTaxZone In dtTaxZone.Rows
            ObjTaxZone = New TaxZoneForMobile
            With ObjTaxZone
                .TaxZoneId = drTaxZone.AccountTaxZoneId
                .TaxZone = drTaxZone.AccountTaxZone
            End With
            TaxZoneId.Add(ObjTaxZone)
        Next
        Return TaxZoneId
    End Function
    <WebMethod()> _
<System.Web.Services.Protocols.SoapHeader("SoapHeader")> _
    Public Function GetTaxCodeByTaxCodeId(ByVal AccountId As Integer) As ArrayList
        If Not TimeLiveServices.IsUserValid(SoapHeader) Then
            Throw New Exception("You are not authorized to access this.")
        End If
        Dim TaxCodeId As New ArrayList
        Dim ObjTaxCode As New TaxCodeForMobile
        Dim TaxCodeBLL As New AccountTaxCodeBLL
        Dim dtTaxCode As TimeLiveDataSet.AccountTaxCodeDataTable = TaxCodeBLL.GetAccountTaxCodeByAccountId(AccountId)
        Dim drTaxCode As TimeLiveDataSet.AccountTaxCodeRow
        For Each drTaxCode In dtTaxCode.Rows
            ObjTaxCode = New TaxCodeForMobile
            With ObjTaxCode
                .TaxCodeId = drTaxCode.AccountTaxCodeId
                .TaxCode = drTaxCode.TaxCode
            End With
            TaxCodeId.Add(ObjTaxCode)
        Next
        Return TaxCodeId
    End Function
    <WebMethod()> _
<System.Web.Services.Protocols.SoapHeader("SoapHeader")> _
    Public Function GetExpenseNameByExpenseIdForMobile(ByVal AccountExpenseId As Integer) As ArrayList
        If Not TimeLiveServices.IsUserValid(SoapHeader) Then
            Throw New Exception("You are not authorized to access this.")
        End If
        Dim ExpenseEntryId As New ArrayList
        Dim objExpenseEntryList As New ExpenseEntry
        Dim ExpenseEntryBLL As New AccountExpenseEntryBLL
        Dim AccountId As Integer = TimeLiveServices.GetSecurityToken(SoapHeader.AuthenticatedToken).AccountID
        Dim dtExpenseEntry As TimeLiveDataSet.vueAccountExpenseEntryDataTable = ExpenseEntryBLL.GetvueAccountExpenseEntriesByAccountIdAndAccountExpenseId(AccountId, AccountExpenseId)
        Dim drExpenseEntry As TimeLiveDataSet.vueAccountExpenseEntryRow
        For Each drExpenseEntry In dtExpenseEntry.Rows
            objExpenseEntryList = New ExpenseEntry
            With objExpenseEntryList
                .ExpenseName = drExpenseEntry.AccountExpenseName
                .AccountExpenseId = drExpenseEntry.AccountExpenseId
            End With
            ExpenseEntryId.Add(objExpenseEntryList)
        Next
        Return ExpenseEntryId
    End Function
    <WebMethod()> _
<System.Web.Services.Protocols.SoapHeader("SoapHeader")> _
    Public Function GetReimbursementCurrencyByAccountIdForMobile() As ArrayList
        If Not TimeLiveServices.IsUserValid(SoapHeader) Then
            Throw New Exception("You are not authorized to access this.")
        End If
        Dim ReimbursementCurrencyId As New ArrayList
        Dim ObjReimbursementCurrency As New ReimbursementCurrencyForMobile
        Dim CurrencyBLL As New AccountCurrencyBLL
        Dim AccountId As Integer = TimeLiveServices.GetSecurityToken(SoapHeader.AuthenticatedToken).AccountID
        Dim dtReimbursementCurrency As AccountCurrency.vueAccountCurrencyDataTable = CurrencyBLL.GetvueAccountCurrencyByAccountIdAndDisabled(AccountId, 0)
        Dim drReimbursementCurrency As AccountCurrency.vueAccountCurrencyRow
        For Each drReimbursementCurrency In dtReimbursementCurrency.Rows
            ObjReimbursementCurrency = New ReimbursementCurrencyForMobile
            With ObjReimbursementCurrency
                .AccountCurrencyId = drReimbursementCurrency.AccountCurrencyId
                .CurrencyCode = drReimbursementCurrency.CurrencyCode
            End With
            ReimbursementCurrencyId.Add(ObjReimbursementCurrency)
        Next
        Return ReimbursementCurrencyId
    End Function
    <WebMethod()> _
<System.Web.Services.Protocols.SoapHeader("SoapHeader")> _
    Public Function GetAccountCurrencyByAccountCurrencyIdForMobile(ByVal AccountCurrencyId As Integer) As ArrayList
        If Not TimeLiveServices.IsUserValid(SoapHeader) Then
            Throw New Exception("You are not authorized to access this.")
        End If
        Dim CurrencyId As New ArrayList
        Dim ObjCurrency As New AccountCurrencyForMobile
        Dim CurrencyBLL As New AccountCurrencyBLL
        Dim dtCurrency As AccountCurrency.vueAccountCurrencyDataTable = CurrencyBLL.GetvueAccountCurrencyByAccountCurrencyId(AccountCurrencyId)
        Dim drReimbursementCurrency As AccountCurrency.vueAccountCurrencyRow
        For Each drReimbursementCurrency In dtCurrency.Rows
            ObjCurrency = New AccountCurrencyForMobile
            With ObjCurrency
                If Not IsDBNull(drReimbursementCurrency.Item("AccountCurrencyExchangeRateId")) Then
                    .ExchangeRateId = drReimbursementCurrency.AccountCurrencyExchangeRateId
                Else
                    .ExchangeRateId = Nothing
                End If
            End With
            CurrencyId.Add(ObjCurrency)
        Next
        Return CurrencyId
    End Function
    <WebMethod()> _
<System.Web.Services.Protocols.SoapHeader("SoapHeader")> _
<System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetvueAccountCurrencyByAccountIdAndDisabled(ByVal AccountId As Integer, ByVal AccountCurrencyId As Integer) As AccountCurrency.vueAccountCurrencyDataTable
        Dim _vueAccountCurrencyTableAdapter As New AccountCurrencyTableAdapters.vueAccountCurrencyTableAdapter
        Return _vueAccountCurrencyTableAdapter.GetDataByAccountIdAndDisabled(AccountId, AccountCurrencyId)
    End Function
    <WebMethod()> _
<System.Web.Services.Protocols.SoapHeader("SoapHeader")> _
    Public Function AddExpenseSheetForMobile(ByVal Description As String, _
                ByVal ExpenseSheetDate As DateTime, _
                ByVal Approved As Boolean, ByVal Rejected As Boolean, ByVal Submitted As Boolean, ByVal InApproval As Boolean, _
                ByVal SubmittedDate As Date) As Guid
        If Not TimeLiveServices.IsUserValid(SoapHeader) Then
            Throw New Exception("You are not authorized to access this.")
        End If
        Dim ExpenseSheetBll As New AccountEmployeeExpenseSheetBLL
        Dim AccountId As Integer = TimeLiveServices.GetSecurityToken(SoapHeader.AuthenticatedToken).AccountID
        Dim AccountEmployeeId As Integer = TimeLiveServices.GetSecurityToken(SoapHeader.AuthenticatedToken).AccountEmployeeId
        Dim ExpenseSheetId As Guid
        ExpenseSheetId = ExpenseSheetBll.AddAccountEmployeeExpenseSheet(AccountId, AccountEmployeeId, Description, ExpenseSheetDate, Approved, Rejected, Submitted, InApproval, SubmittedDate)
        Return ExpenseSheetId
    End Function
    <WebMethod()> _
<System.Web.Services.Protocols.SoapHeader("SoapHeader")> _
    Public Sub UpdateExpenseSheetForMobile(ByVal Description As String, ByVal ExpenseSheetDate As DateTime, ByVal Original_AccountEmployeeExpenseSheetId As Guid)
        If Not TimeLiveServices.IsUserValid(SoapHeader) Then
            Throw New Exception("You are not authorized to access this.")
        End If
        Dim ExpenseSheetBll As New AccountEmployeeExpenseSheetBLL
        Dim AccountId As Integer = TimeLiveServices.GetSecurityToken(SoapHeader.AuthenticatedToken).AccountID
        Dim AccountEmployeeId As Integer = TimeLiveServices.GetSecurityToken(SoapHeader.AuthenticatedToken).AccountEmployeeId
        ExpenseSheetBll.UpdateAccountEmployeeExpenseSheet(Description, ExpenseSheetDate, Original_AccountEmployeeExpenseSheetId)
    End Sub
    <WebMethod()> _
<System.Web.Services.Protocols.SoapHeader("SoapHeader")> _
    Public Sub AddExpenseEntryForMobile( _
                ByVal YearWS As Integer, ByVal MonthWS As Integer, ByVal DayWS As Integer, ByVal AccountClientId As Integer, ByVal AccountProjectId As Integer, ByVal AccountProjectTaskId As Integer, ByVal AccountExpenseId As Integer, ByVal Amount As Double, ByVal Description As String, ByVal IsBillable As Boolean, ByVal Reimburse As Boolean, _
                ByVal AccountCurrencyId As Integer, ByVal Quantity As Double, ByVal Rate As Double, ByVal AmountBeforeTax As Double, ByVal TaxAmount As Double, ByVal AccountPaymentMethodId As System.Nullable(Of Integer), _
                ByVal ExchangeRate As Double, ByVal AccountTaxZoneId As Integer, ByVal Submitted As Boolean, ByVal AccountEmployeeExpenseSheetId As String)
        If Not TimeLiveServices.IsUserValid(SoapHeader) Then
            Throw New Exception("You are not authorized to access this.")
        End If
        Dim AccountExpenseEntryDate As Date = New Date(YearWS, MonthWS, DayWS)
        Dim ExpenseEntryBll As New AccountExpenseEntryBLL
        Dim AccountId As Integer = TimeLiveServices.GetSecurityToken(SoapHeader.AuthenticatedToken).AccountID
        Dim AccountEmployeeId As Integer = TimeLiveServices.GetSecurityToken(SoapHeader.AuthenticatedToken).AccountEmployeeId
        Dim expensesheetid As Guid
        If AccountEmployeeExpenseSheetId = "" Or AccountEmployeeExpenseSheetId = "nothing" Then
            expensesheetid = AddExpenseSheetForMobile(" ", _
                            AccountExpenseEntryDate, _
                            False, False, False, False, _
                            Now.Date)
        Else
            Dim OldExpenseSheetId As New Guid(AccountEmployeeExpenseSheetId)
            expensesheetid = OldExpenseSheetId
        End If
        ExpenseEntryBll.AddAccountExpenseEntryForMobile(AccountId, AccountExpenseEntryDate, AccountEmployeeId, AccountClientId, AccountProjectId, AccountProjectTaskId, AccountExpenseId, Amount, Now, AccountEmployeeId, Now, AccountEmployeeId, Description, IsBillable, Reimburse, AccountCurrencyId, Quantity, Rate, AmountBeforeTax, TaxAmount, AccountPaymentMethodId, ExchangeRate, AccountTaxZoneId, Submitted, expensesheetid, False, False, False)
    End Sub
    <WebMethod()> _
<System.Web.Services.Protocols.SoapHeader("SoapHeader")> _
    Public Sub UpdateExpenseEntryForMobile(ByVal YearWS As Integer, ByVal MonthWS As Integer, ByVal DayWS As Integer, ByVal Original_AccountExpenseEntryId As Integer, _
    ByVal AccountClientId As Integer, ByVal AccountProjectId As Integer, ByVal AccountProjectTaskId As Integer, ByVal AccountExpenseId As Integer, ByVal Amount As Double, _
    ByVal ModifiedOn As DateTime, ByVal ModifiedByEmployeeId As Integer, ByVal Description As String, _
    ByVal IsBillable As Boolean, ByVal Reimburse As Boolean, ByVal AccountCurrencyId As Integer, _
    ByVal Quantity As Double, ByVal Rate As Double, ByVal AmountBeforeTax As Double, ByVal TaxAmount As Double, ByVal AccountPaymentMethodId As System.Nullable(Of Integer), _
    ByVal AccountTaxZoneId As Integer, ByVal AccountEmployeeExpenseSheetId As Guid)
        If Not TimeLiveServices.IsUserValid(SoapHeader) Then
            Throw New Exception("You are not authorized to access this.")
        End If
        Dim AccountExpenseEntryDate As Date = New Date(YearWS, MonthWS, DayWS)
        Dim ExpenseEntryBll As New AccountExpenseEntryBLL
        Dim AccountId As Integer = TimeLiveServices.GetSecurityToken(SoapHeader.AuthenticatedToken).AccountID
        Dim AccountEmployeeId As Integer = TimeLiveServices.GetSecurityToken(SoapHeader.AuthenticatedToken).AccountEmployeeId
        ExpenseEntryBll.UpdateAccountExpenseEntryForMobile(AccountId, AccountExpenseEntryDate, Original_AccountExpenseEntryId, AccountEmployeeId, AccountClientId, AccountProjectId, AccountProjectTaskId, AccountExpenseId, Amount, Now, AccountEmployeeId, Description, IsBillable, Reimburse, AccountCurrencyId, Quantity, Rate, AmountBeforeTax, TaxAmount, AccountPaymentMethodId, AccountTaxZoneId, AccountEmployeeExpenseSheetId)
    End Sub
    <WebMethod()> _
<System.Web.Services.Protocols.SoapHeader("SoapHeader")> _
    Public Function ShowFieldsByExpenseForMobile(ByVal AccountExpenseId As Integer) As ArrayList
        If Not TimeLiveServices.IsUserValid(SoapHeader) Then
            Throw New Exception("You are not authorized to access this.")
        End If
        Dim ShowFieldsByExpenseName As New ArrayList
        Dim ObjShowFieldsByExpenseName As New ShowFieldsByExpenseNameForMobile
        Dim dtExpense As TimeLiveDataSet.AccountExpenseDataTable = New AccountExpenseBLL().GetAccountExpensesByAccountExpenseId(AccountExpenseId)
        Dim drExpense As TimeLiveDataSet.AccountExpenseRow
        If dtExpense.Rows.Count > 0 Then
            drExpense = dtExpense.Rows(0)
            Dim dtExpenseType As TimeLiveDataSet.vueAccountExpenseTypeDataTable = New AccountExpenseTypeBLL().GetvueAccountExpenseTypesByAccountExpenseTypeId(drExpense.AccountExpenseTypeId)
            Dim drExpenseType As TimeLiveDataSet.vueAccountExpenseTypeRow
            'For Each drExpense In dtExpense.Rows
            If dtExpenseType.Rows.Count > 0 Then
                drExpenseType = dtExpenseType.Rows(0)
                ObjShowFieldsByExpenseName = New ShowFieldsByExpenseNameForMobile
                With ObjShowFieldsByExpenseName
                    If drExpenseType.IsQuantityField = True Then
                        .ShowQuantityCaption = "Quantity"
                        .ShowRate = True
                        .ShowQuantity = True
                    Else
                        .ShowRate = False
                        .ShowQuantity = False
                    End If
                    If Not IsDBNull(drExpenseType.Item("AccountTaxCodeId")) Then
                        .TaxCodeCaption = "TaxCode"
                        .ShowTaxCode = True
                        .ShowNetAmount = True
                        .ShowTaxZone = True
                    Else
                        .ShowTaxCode = False
                        .ShowNetAmount = False
                        .ShowTaxZone = False
                    End If
                End With
            End If
        End If
        ShowFieldsByExpenseName.Add(ObjShowFieldsByExpenseName)
        Return ShowFieldsByExpenseName
        'Next
    End Function
    <WebMethod()> _
<System.Web.Services.Protocols.SoapHeader("SoapHeader")> _
    Public Function CalculateAmountByExpenseForMobile(ByVal AccountExpenseId As Integer, ByVal AccountTaxZoneId As Integer, ByVal Quantity As Double, ByVal Rate As Double, ByVal TaxAmount As Double, ByVal NetAmount As Double, ByVal Amount As Double) As ArrayList
        If Not TimeLiveServices.IsUserValid(SoapHeader) Then
            Throw New Exception("You are not authorized to access this.")
        End If
        Dim CalculateAmount As New ArrayList
        Dim ObjCalculateAmount As New CalculateAmountByExpenseForMobile
        Dim dtExpense As TimeLiveDataSet.AccountExpenseDataTable = New AccountExpenseBLL().GetAccountExpensesByAccountExpenseId(AccountExpenseId)
        Dim drExpense As TimeLiveDataSet.AccountExpenseRow
        If dtExpense.Rows.Count > 0 Then
            drExpense = dtExpense.Rows(0)
            Dim dtExpenseType As TimeLiveDataSet.vueAccountExpenseTypeDataTable = New AccountExpenseTypeBLL().GetvueAccountExpenseTypesByAccountExpenseTypeIdAndAccountTaxZoneId(drExpense.AccountExpenseTypeId, AccountTaxZoneId)
            Dim drExpenseType As TimeLiveDataSet.vueAccountExpenseTypeRow
            If dtExpenseType.Rows.Count > 0 Then
                drExpenseType = dtExpenseType.Rows(0)
                If drExpenseType.IsQuantityField Then
                    ObjCalculateAmount.Amount = Quantity * Rate
                    ObjCalculateAmount.TaxAmount = 0
                    ObjCalculateAmount.NetAmount = 0
                ElseIf Not IsDBNull(drExpenseType.Item("AccountTaxCodeId")) Then
                    ObjCalculateAmount.Amount = NetAmount + 10
                    ObjCalculateAmount.NetAmount = NetAmount
                    ObjCalculateAmount.TaxAmount = 10
                Else
                    ObjCalculateAmount.Amount = Amount
                    ObjCalculateAmount.TaxAmount = 0
                    ObjCalculateAmount.NetAmount = 0
                End If
            End If
        End If
        CalculateAmount.Add(ObjCalculateAmount)
        Return CalculateAmount
    End Function
    <WebMethod()> _
<System.Web.Services.Protocols.SoapHeader("SoapHeader")> _
    Public Function SubmitExpenseSheetAndEntry(ByVal AccountEmployeeExpenseSheetId As String) As String
        If Not TimeLiveServices.IsUserValid(SoapHeader) Then
            Throw New Exception("You are not authorized to access this.")
        End If
        Try
            Dim ExpenseEntryBLL As New AccountExpenseEntryBLL
            Dim ExpenseSheetId As New Guid(AccountEmployeeExpenseSheetId)
            ExpenseEntryBLL.UpdateAccountEmployeeExpenseSheetAndEntriesForMobile(AccountEmployeeExpenseSheetId)
            Return "Record Updated"
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
    <WebMethod()> _
<System.Web.Services.Protocols.SoapHeader("SoapHeader")> _
    Public Function AddAttachment(ByVal AccountExpenseEntryId As Integer, ByVal ExpenseAttachment As Byte(), ByVal FileName As String) As String
        If Not TimeLiveServices.IsUserValid(SoapHeader) Then
            Throw New Exception("You are not authorized to access this.")
        End If
        Try
            Dim ExpenseEntryBLL As New AccountExpenseEntryBLL
            Dim AccountId As Integer = TimeLiveServices.GetSecurityToken(SoapHeader.AuthenticatedToken).AccountID
            Dim AccountEmployeeId As Integer = TimeLiveServices.GetSecurityToken(SoapHeader.AuthenticatedToken).AccountEmployeeId
            'Dim ExpenseSheetId As New Guid(AccountEmployeeExpenseSheetId)
            'ExpenseEntryBLL.UpdateAccountEmployeeExpenseSheetAndEntriesForMobile(AccountEmployeeExpenseSheetId)
            SaveData(AccountExpenseEntryId, FileName, ExpenseAttachment, AccountEmployeeId, AccountId)

            Return "Record Updated"
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
    Protected Function SaveData(ID As Integer, FileName As String, Data As Byte(), AccountEmployeeId As Integer, AccountId As Integer) As Boolean
        Dim BLL As New AccountAttachmentsBLL
        ''BLL.FileUpload(
        If FileName = "" Then
            Return True
        End If

        Dim Writer As BinaryWriter = Nothing
        Dim Array() As String = Split(FileName, ".")

        Dim strAccountAttachmentsPath As String
        Dim strUploadPath As String = System.Configuration.ConfigurationManager.AppSettings("UploadFilesPath")
        Dim strRoot As String = System.Web.HttpContext.Current.Server.MapPath(strUploadPath)
        Dim AttachmentLocalPath As String = FileName
        If Not System.IO.Directory.Exists(strRoot) Then
            System.IO.Directory.CreateDirectory(strRoot)
        End If
        Dim strAccountPath As String = strRoot & AccountId & "\"
        If Not System.IO.Directory.Exists(strAccountPath) Then
            System.IO.Directory.CreateDirectory(strAccountPath)
        End If

        strAccountAttachmentsPath = strAccountPath & ID & "\"

        If Not System.IO.Directory.Exists(strAccountAttachmentsPath) Then
            System.IO.Directory.CreateDirectory(strAccountAttachmentsPath)
        End If
        Dim FileToSave As String = strAccountAttachmentsPath & FileName
        'objFileUpload.SaveAs(FileToSave)
        Dim AttachmentBLL As New AccountAttachmentsBLL
        AttachmentBLL.AddAccountAttachments(1, ID, Array(0), FileName, System.Guid.Empty, AccountEmployeeId, AccountEmployeeId)

        Try
            ' Create a new stream to write to the file
            'Writer = New BinaryWriter(File.OpenWrite(FileToSave))
            File.WriteAllBytes(FileToSave, Data)
            ' Writer raw data                
            'Writer.Write(Data)
            'Writer.Flush()
            'Writer.Close()
        Catch

            Return False
        End Try

        Return True
    End Function
    '    <WebMethod()> _
    '<System.Web.Services.Protocols.SoapHeader("SoapHeader")> _
    '    Public Sub AddAccountAttachmentsForMobile(ByVal Description As String, _
    '                ByVal ExpenseSheetDate As DateTime, _
    '                ByVal Approved As Boolean, ByVal Rejected As Boolean, ByVal Submitted As Boolean, ByVal InApproval As Boolean, _
    '                ByVal SubmittedDate As Date)
    '        If Not TimeLiveServices.IsUserValid(SoapHeader) Then
    '            Throw New Exception("You are not authorized to access this.")
    '        End If
    '        Dim AttachmentsBLL As New AccountAttachmentsBLL
    '        Dim AccountId As Integer = TimeLiveServices.GetSecurityToken(SoapHeader.AuthenticatedToken).AccountID
    '        Dim AccountEmployeeId As Integer = TimeLiveServices.GetSecurityToken(SoapHeader.AuthenticatedToken).AccountEmployeeId
    '        'ExpenseSheetBll.AddAccountEmployeeExpenseSheet(AccountId, AccountEmployeeId, Description, ExpenseSheetDate, Approved, Rejected, Submitted, InApproval, SubmittedDate)
    '    End Sub
    '    <WebMethod()> _
    '<System.Web.Services.Protocols.SoapHeader("SoapHeader")> _
    '    Public Sub AddAccountAttachmentsForMobile(ByVal AccountExpenseEntryId As Integer, ByVal AccountEmployeeTimeEntryPeriodId As Integer, ByVal AccountAttachmentTypeId As Integer)
    '        Dim URL As String
    '        Dim AccountId As Integer = TimeLiveServices.GetSecurityToken(SoapHeader.AuthenticatedToken).AccountID
    '        Dim AccountEmployeeId As Integer = TimeLiveServices.GetSecurityToken(SoapHeader.AuthenticatedToken).AccountEmployeeId

    '        AccountExpenseEntryId = IIf(Not AccountExpenseEntryId.ToString Is Nothing, AccountExpenseEntryId, 64)

    '        Dim BLL As New AccountAttachmentsBLL
    '        If Not AccountEmployeeTimeEntryPeriodId.ToString Is Nothing Then
    '            BLL.FileUpload(Me.FormView1.FindControl("AttachmentFileUpload"), Me.Request.QueryString("AccountAttachmentTypeId"), 0, AccountId, CType(Me.FormView1.FindControl("txtAttachmentName"), TextBox).Text, New Guid(Me.Request.QueryString("AccountEmployeeTimeEntryPeriodId")))
    '        Else
    '            BLL.FileUpload(Me.FormView1.FindControl("AttachmentFileUpload"), Me.Request.QueryString("AccountAttachmentTypeId"), AccountExpenseEntryId , AccountExpenseEntryId, 0),AccountId, CType(Me.FormView1.FindControl("txtAttachmentName"), TextBox).Text, System.Guid.Empty)
    '        End If

    '        If AccountAttachmentTypeId = 1 Then
    '            URL = "~/AccountAdmin/AccountAttachmentsPopUp.aspx?AccountExpenseEntryId=" & Request.QueryString("AccountExpenseEntryId") & "&AccountAttachmentTypeId=" & Me.Request.QueryString("AccountAttachmentTypeId")
    '        Else
    '            URL = "~/AccountAdmin/AccountAttachmentsPopUp.aspx?AccountEmployeeTimeEntryPeriodId=" & Me.Request.QueryString("AccountEmployeeTimeEntryPeriodId") & "&AccountAttachmentTypeId=" & Me.Request.QueryString("AccountAttachmentTypeId")
    '        End If
    '        Response.Redirect(URL, False)
    '    End Sub
    '    <WebMethod()> _
    '<System.Web.Services.Protocols.SoapHeader("SoapHeader")> _
    '    Public Sub AddAccountAttachmentsForMobile(ByVal FileUpload As FileUpload)
    '        If Not TimeLiveServices.IsUserValid(SoapHeader) Then
    '            Throw New Exception("You are not authorized to access this.")
    '        End If
    '        System.IO.File.Create("FileUpload")
    '    End Sub

    ''    <WebMethod()> _
    ''<System.Web.Services.Protocols.SoapHeader("SoapHeader")> _
    ''    Public Function convertbytetostream() As String
    ''        If Not TimeLiveServices.IsUserValid(SoapHeader) Then
    ''            Throw New Exception("You are not authorized to access this.")
    ''        End If
    ''        Try
    ''            Dim ExpenseEntryBLL As New AccountExpenseEntryBLL
    ''            ExpenseEntryBLL.byteArrayToImage()
    ''            Return "Record Updated"
    ''        Catch ex As Exception
    ''            Return ex.Message
    ''        End Try
    ''    End Function
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