Imports System.Collections.Generic
Imports System.Configuration
Imports System.Globalization
Imports System.Linq
Imports System.Web
Imports Intuit.Ipp.Core
Imports Intuit.Ipp.Security
Imports Intuit.Ipp.DataService
Imports Intuit.Ipp.Data
Imports Intuit.Ipp.QueryFilter
Imports Intuit.Ipp.Retry
Imports Intuit.Ipp.Exception
Imports Intuit.Ipp.Diagnostics
Imports Intuit.Ipp.Core.Configuration

Partial Class AccountAdmin_Controls_ctlQboOnline
    Inherits System.Web.UI.UserControl
    Private realmId As [String], accessToken As [String], accessTokenSecret As [String], consumerKey As [String], consumerSecret As [String]
    Private dataSourcetype As IntuitServicesType
    Private oauthValidator As OAuthRequestValidator
    Private serviceContext As ServiceContext
    Private dataService As DataService
    Dim ExecutedDate As Date

    Protected Sub Page_Init(sender As Object, e As System.EventArgs) Handles Me.Init

    End Sub
    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If HttpContext.Current.Session("realm") IsNot Nothing Or (HttpContext.Current.Session("accessToken") IsNot Nothing AndAlso HttpContext.Current.Session("InvalidAccessToken") Is Nothing) Then
            'connected to Qbo Online
            ConnectToIntuitTR.Visible = False
            WelcomeTR.Visible = False
            GetConnectedTR.Visible = False
            Me.lblstatusred.Visible = False
            Me.lblstatusgreen.Visible = True
            Me.lblstatusgreen.InnerHtml = "CONNECTED"
        Else
            Me.lblstatusred.InnerHtml = "NOT CONNECTED"
            ConnectToIntuitTR.Visible = True
            TBQuickBooks.Visible = False
            WelcomeTR.Visible = True
            GetConnectedTR.Visible = True
            tblMain.Width = "50%"
        End If
        'connectToIntuitDiv.Visible = False
        'connect.Visible = False
        'Me.lblstatusred.Visible = False
        'Me.lblstatusgreen.Visible = True
        'Me.lblstatusgreen.InnerHtml = "CONNECTED"
        'connecttext.Visible = False
        If Not Me.IsPostBack Then
            Dim EmployeeBLL As New AccountEmployeeBLL
            Dim dv As New DataView(EmployeeBLL.GetEmployeeForQB(DBUtilities.GetSessionAccountId))
            Me.ddlEmployees.DataSource = dv
            Me.ddlEmployees.DataTextField = "FullName"
            Me.ddlEmployees.DataValueField = "AccountEmployeeId"
            'Me.ddlEmployees.SelectedIndex = 0
            Me.ddlEmployees.SelectedValue = DBUtilities.GetSessionAccountEmployeeId
            Me.ddlEmployees.DataBind()
        End If
    End Sub
    Public Function GetNameForLog(entity As IEntity) As String
        Dim EntityName As String = entity.GetType.Name
        If EntityName = "Customer" Then
            Dim EntityCustomer As Customer = entity
            Return EntityCustomer.DisplayName()
        End If
        If EntityName = "Employee" Then
            Dim EntityEmployee As Intuit.Ipp.Data.Employee = entity
            Return EntityEmployee.DisplayName()
        End If
        If EntityName = "Vendor" Then
            Dim EntityVendor As Vendor = entity
            Return EntityVendor.DisplayName()
        End If
        If EntityName = "Item" Then
            Dim EntityItem As Item = entity
            Return EntityItem.Name()
        End If
        If EntityName = "TimeActivity" Then
            Dim EntityItem As TimeActivity = entity
            Return EntityItem.Description
        End If
        Return ""
    End Function
    Public Sub Insert(commonService As DataService, entity As IEntity, DisplayName As String, EntityName As String)

        Try
            commonService.Add(entity)
            Dim logbll As New AccountQBOnlineBLL
            logbll.AddAccountQBOnlineLog(DBUtilities.GetSessionAccountId, DBUtilities.GetSessionAccountEmployeeId, ExecutedDate, EntityName, entity.GetType.Name, DisplayName, "", "Transferred Successfully", "")
        Catch ex As Exception

            Dim errorList = DirectCast(DirectCast(ex, Intuit.Ipp.Exception.IdsException).InnerException, Intuit.Ipp.Exception.IdsException).InnerExceptions

            For Each idsError As IdsError In errorList
                Console.WriteLine("ErrorCode:{0}, Message:{1}, Element:{2}, Detail:{3}", idsError.ErrorCode, idsError.Message, idsError.Element, idsError.Detail)
                Dim logbll As New AccountQBOnlineBLL
                logbll.AddAccountQBOnlineLog(DBUtilities.GetSessionAccountId, DBUtilities.GetSessionAccountEmployeeId, ExecutedDate, EntityName, entity.GetType.Name, DisplayName, idsError.ErrorCode, idsError.Message, idsError.Detail)
            Next
           
        End Try

    End Sub
    Public Function SetQBParameters() As Boolean
        If HttpContext.Current.Session("realm") IsNot Nothing Then
            realmId = HttpContext.Current.Session("realm").ToString()
            accessToken = HttpContext.Current.Session("accessToken").ToString()
            accessTokenSecret = HttpContext.Current.Session("accessTokenSecret").ToString()
            consumerKey = ConfigurationManager.AppSettings("consumerKey").ToString(CultureInfo.InvariantCulture)
            consumerSecret = ConfigurationManager.AppSettings("consumerSecret")
            dataSourcetype = If(HttpContext.Current.Session("dataSource").ToString().ToLower() = "qbd", IntuitServicesType.QBD, IntuitServicesType.QBO)

            oauthValidator = New OAuthRequestValidator(accessToken, accessTokenSecret, consumerKey, consumerSecret)

            serviceContext = New ServiceContext(realmId, dataSourcetype, oauthValidator)
            'serviceContext.IppConfiguration.BaseUrl.Qbo = "https://sandbox-quickbooks.api.intuit.com/"
            serviceContext.IppConfiguration.Logger.RequestLog.EnableRequestResponseLogging = True
            'serviceContext.IppConfiguration.Logger.RequestLog.ServiceRequestLoggingLocation = "C:\IdsLogs"
            serviceContext.IppConfiguration.Logger.CustomLogger = New TraceLogger()
            serviceContext.IppConfiguration.Message.Response.SerializationFormat = SerializationFormat.Json
            dataService = New DataService(serviceContext)
            Return True
        End If
        Return False
    End Function
    Public Sub AddQBTimeActivityIntoTimeLiveTimeEntry()
        If SetQBParameters() Then
            Dim qboTimeActivityempty = New TimeActivity()
            Dim qboTimeActivityfull = dataService.FindAll(qboTimeActivityempty, 1, 100).ToList()
            For Each qboTimeActivities In qboTimeActivityfull

            Next
        End If
    End Sub
    Public Sub AddQBCustomerIntoTimeLiveClient()
        If SetQBParameters() Then
            Dim qboCustomerempty = New Customer()
            Dim qboCustomersfull = dataService.FindAll(qboCustomerempty, 1, 100).ToList()

            For Each qboCustomers In qboCustomersfull
                If Not qboCustomers.Job Then
                    Dim EmailAddress As String = ""
                    Dim CustomerName As String = ""
                    Dim Telephone1 As String = ""
                    Dim Telephone2 As String = ""
                    Dim Address1 As String = ""
                    Dim Address2 As String = ""
                    If qboCustomers.PrimaryEmailAddr IsNot Nothing AndAlso qboCustomers.PrimaryEmailAddr.Address <> "" Then
                        EmailAddress = qboCustomers.PrimaryEmailAddr.Address
                    End If
                    If qboCustomers.DisplayName <> "" Then
                        CustomerName = qboCustomers.DisplayName
                    End If
                    If qboCustomers.PrimaryPhone IsNot Nothing AndAlso qboCustomers.PrimaryPhone.FreeFormNumber <> "" Then
                        Telephone1 = qboCustomers.PrimaryPhone.FreeFormNumber

                    End If
                    If qboCustomers.Mobile IsNot Nothing AndAlso qboCustomers.Mobile.FreeFormNumber <> "" Then
                        Telephone2 = qboCustomers.Mobile.FreeFormNumber
                    End If
                    Dim client As New AccountPartyBLL()
                    Dim dtClient As TimeLiveDataSet.AccountPartyDataTable = client.GetClientsByName(DBUtilities.GetSessionAccountId, CustomerName)
                    If dtClient.Rows.Count > 0 Then
                    Else
                        client.AddAccountParty(DBUtilities.GetSessionAccountId, CustomerName, "", EmailAddress, Address1, Address2, 233, "", "", "", Telephone1, Telephone2, _
                                              "", 0, "", "", False, False, Now, DBUtilities.GetSessionAccountEmployeeId, Now, DBUtilities.GetSessionAccountEmployeeId, 0, 0)
                    End If
                End If
            Next
        End If
    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub AddTimeLiveClientIntoQBCustomer()
        If SetQBParameters() Then
            Dim client As New AccountPartyBLL()
            Dim dtClient As TimeLiveDataSet.AccountPartyDataTable = client.GetAccountPartiesByAccountIdForQB(DBUtilities.GetSessionAccountId)
            Dim drClient As TimeLiveDataSet.AccountPartyRow
            For Each drClient In dtClient.Rows
                Dim entity As New Customer
                entity.DisplayName = drClient.PartyName
                entity.Job = False
                If Not IsDBNull(drClient.Item("EMailAddress")) Then
                    Dim emailadd As New EmailAddress
                    emailadd.Address = drClient.EMailAddress
                    entity.PrimaryEmailAddr = emailadd
                End If
                If Not IsDBNull(drClient.Item("Telephone1")) Then
                    Dim phn As New TelephoneNumber
                    phn.FreeFormNumber = drClient.Telephone1
                    entity.PrimaryPhone = phn
                End If
                Insert(dataService, entity, drClient.PartyName, "Client")
            Next
        End If
    End Sub
    Public Sub AddQBEmployeeIntoTimeLiveEmployee()
        If SetQBParameters() Then
            Dim qboEmployeeempty = New Intuit.Ipp.Data.Employee()
            Dim qboEmployeesfull = dataService.FindAll(qboEmployeeempty, 1, 100).ToList()

            For Each qboEmployees In qboEmployeesfull
                Dim EmailAddress As String = ""
                Dim CustomerName As String = ""
                Dim FirstName As String = ""
                Dim LastName As String = ""
                Dim Telephone1 As String = ""
                Dim Telephone2 As String = ""
                Dim Address1 As String = ""
                Dim Address2 As String = ""
                Dim City As String = ""
                Dim Country As String = ""
                Dim State As String = ""
                Dim PostalCode As String = ""
                Dim HiredDate As Date
                If qboEmployees.PrimaryEmailAddr IsNot Nothing AndAlso qboEmployees.PrimaryEmailAddr.Address <> "" Then
                    EmailAddress = qboEmployees.PrimaryEmailAddr.Address
                Else
                    If qboEmployees.GivenName <> "" And qboEmployees.FamilyName <> "" Then
                        EmailAddress = qboEmployees.GivenName + "" + qboEmployees.FamilyName + "@dummy.com"
                    ElseIf qboEmployees.DisplayName <> "" Then
                        EmailAddress = Replace(qboEmployees.DisplayName, " ", "") + "@dummy.com"
                    End If
                End If
                If qboEmployees.GivenName <> "" Then
                    FirstName = qboEmployees.GivenName
                End If
                If qboEmployees.FamilyName <> "" Then
                    LastName = qboEmployees.FamilyName
                End If
                If qboEmployees.DisplayName <> "" And FirstName = "" Then
                    FirstName = qboEmployees.DisplayName
                End If
                If qboEmployees.DisplayName <> "" And LastName = "" Then
                    LastName = qboEmployees.DisplayName
                End If
                If qboEmployees.PrimaryPhone IsNot Nothing AndAlso qboEmployees.PrimaryPhone.FreeFormNumber <> "" Then
                    Telephone1 = qboEmployees.PrimaryPhone.FreeFormNumber
                End If
                If qboEmployees.Mobile IsNot Nothing AndAlso qboEmployees.Mobile.FreeFormNumber <> "" Then
                    Telephone2 = qboEmployees.Mobile.FreeFormNumber
                End If
                If qboEmployees.PrimaryAddr IsNot Nothing AndAlso qboEmployees.PrimaryAddr.Line1 <> "" Then
                    Address1 = qboEmployees.PrimaryAddr.Line1
                End If
                If qboEmployees.PrimaryAddr IsNot Nothing AndAlso qboEmployees.PrimaryAddr.Country <> "" Then
                    Country = qboEmployees.PrimaryAddr.Country
                End If
                If qboEmployees.PrimaryAddr IsNot Nothing AndAlso qboEmployees.PrimaryAddr.City <> "" Then
                    City = qboEmployees.PrimaryAddr.City
                End If
                If qboEmployees.PrimaryAddr IsNot Nothing AndAlso qboEmployees.PrimaryAddr.CountrySubDivisionCode <> "" Then
                    State = qboEmployees.PrimaryAddr.CountrySubDivisionCode
                End If
                If qboEmployees.PrimaryAddr IsNot Nothing AndAlso qboEmployees.PrimaryAddr.PostalCode <> "" Then
                    PostalCode = qboEmployees.PrimaryAddr.PostalCode
                End If
                Date.TryParse(qboEmployees.HiredDate, HiredDate)
                Dim nDepartmentId As Integer = New AccountDepartmentBLL().GetDepartmentIdForQB(DBUtilities.GetSessionAccountId)
                Dim objAccountRoles As New AccountRoleBLL
                Dim nRoleId As Integer = objAccountRoles.GetAccountRolesByAccountIdAndMasterAccountRoleId(DBUtilities.GetSessionAccountId, 2).Rows(0).Item(0)
                Dim nLocationId As Integer = New AccountLocationBLL().GetLocationIdForQB(DBUtilities.GetSessionAccountId)
                Dim nEmployeeTypeId As Guid = New AccountEmployeeTypeBLL().GetDefaultAccountEmployeeTypeId(DBUtilities.GetSessionAccountId)
                Dim nEmployeeStatusId As Integer = New AccountStatusBLL().GetDefaultAccountStatusId(DBUtilities.GetSessionAccountId)
                Dim nWorkingDayTypeId As Guid = New AccountWorkingDayTypeBLL().InsertDefault(DBUtilities.GetSessionAccountId, 0)
                Dim nBillingTypeId As Integer = New AccountBillingTypeBLL().GetAccountBillingTypesByMasterBillingTypeId(DBUtilities.GetSessionAccountId, 1).Rows(0).Item(0)


                Dim objEmployee As New AccountEmployeeBLL()
                Dim dtEmployee As AccountEmployee.AccountEmployeeDataTable = objEmployee.GetAccountEmployeesByEmployeeNameAndEmailAddress(DBUtilities.GetSessionAccountId, FirstName + " " + LastName, EmailAddress)
                If dtEmployee.Rows.Count > 0 Then

                Else
                    objEmployee.AddAccountEmployee(EmailAddress, EmailAddress, FirstName, LastName, EmailAddress, "", DBUtilities.GetSessionAccountId, _
                                                   nDepartmentId, nRoleId, nLocationId, 233, nBillingTypeId, Now.Date, -1, 0, 6, DBUtilities.GetSessionAccountEmployeeId, _
                                                   DBUtilities.GetSessionAccountEmployeeId, nEmployeeTypeId, nEmployeeStatusId, _
                            "", HiredDate, Now.Date, nWorkingDayTypeId, System.Guid.Empty, 0, System.Guid.Empty, False, "", False, False, Address1, Address2, _
                            State, City, PostalCode, Telephone1, Telephone2, "", "", "", True)

                End If
            Next
        End If
    End Sub
    Public Sub AddTimeLiveEmployeeIntoQBEmployee()
        If SetQBParameters() Then
            Dim objemployee As New AccountEmployeeBLL
            Dim dtEmployee As AccountEmployee.vueAccountEmployeeForQBDataTable = objemployee.GetEmployeeForQB(DBUtilities.GetSessionAccountId)
            Dim drEmployee As AccountEmployee.vueAccountEmployeeForQBRow
            For Each drEmployee In dtEmployee.Rows
                If drEmployee.Item("IsVendor").ToString() = "False" Or drEmployee.Item("IsVendor").ToString() = "" Then
                    Dim entity As New Intuit.Ipp.Data.Employee()
                    entity.EmployeeNumber = drEmployee.AccountEmployeeId
                    entity.DisplayName = drEmployee.FullName
                    entity.GivenName = drEmployee.FirstName
                    If Not IsDBNull(drEmployee.Item("MiddleName")) Then
                        entity.MiddleName = drEmployee.MiddleName
                    End If
                    entity.FamilyName = drEmployee.LastName
                    If Not IsDBNull(drEmployee.Item("EMailAddress")) Then
                        Dim emailadd As New EmailAddress
                        emailadd.Address = drEmployee.EMailAddress
                        entity.PrimaryEmailAddr = emailadd
                    End If
                    If Not IsDBNull(drEmployee.Item("WorkPhoneNo")) Then
                        Dim phn As New TelephoneNumber
                        phn.FreeFormNumber = drEmployee.WorkPhoneNo
                        entity.PrimaryPhone = phn
                    End If
                    If Not IsDBNull(drEmployee.Item("MobilePhoneNo")) Then
                        Dim phn As New TelephoneNumber
                        phn.FreeFormNumber = drEmployee.MobilePhoneNo
                        entity.Mobile = phn
                    End If
                    Dim phyadd As New PhysicalAddress
                    If Not IsDBNull(drEmployee.Item("AddressLine1")) Then
                        phyadd.Line1 = drEmployee.AddressLine1
                    End If
                    If Not IsDBNull(drEmployee.Item("State")) Then
                        phyadd.CountrySubDivisionCode = drEmployee.State
                    End If
                    If Not IsDBNull(drEmployee.Item("City")) Then
                        phyadd.City = drEmployee.City
                    End If
                    If Not IsDBNull(drEmployee.Item("Zip")) Then
                        phyadd.PostalCode = drEmployee.Zip
                    End If
                    entity.PrimaryAddr = phyadd
                    If Not IsDBNull(drEmployee.Item("HiredDate")) Then
                        entity.HiredDate = drEmployee.HiredDate
                    End If
                    Me.Insert(dataService, entity, drEmployee.FullName, "Employee")
                    '.Address1, .Address2, .City, .Country, .PostalCode, .State, .HiredDate, .Mobile, .Phone)
                End If
            Next
        End If
    End Sub
    Public Sub AddTimeLiveVendorIntoQBVendor()
        If SetQBParameters() Then
            Dim objemployee As New AccountEmployeeBLL
            Dim dtEmployee As AccountEmployee.vueAccountEmployeeForQBDataTable = objemployee.GetEmployeeForQB(DBUtilities.GetSessionAccountId)
            Dim drEmployee As AccountEmployee.vueAccountEmployeeForQBRow
            For Each drEmployee In dtEmployee.Rows
                If Not IsDBNull(drEmployee.Item("IsVendor")) AndAlso drEmployee.Item("IsVendor").ToString = "True" Then
                    Dim entity As New Intuit.Ipp.Data.Vendor()
                    'entity.EmployeeNumber = drEmployee.AccountEmployeeId
                    entity.DisplayName = drEmployee.FullName
                    entity.GivenName = drEmployee.FirstName
                    If Not IsDBNull(drEmployee.Item("MiddleName")) Then
                        entity.MiddleName = drEmployee.MiddleName
                    End If
                    entity.FamilyName = drEmployee.LastName
                    If Not IsDBNull(drEmployee.Item("EMailAddress")) Then
                        Dim emailadd As New EmailAddress
                        emailadd.Address = drEmployee.EMailAddress
                        entity.PrimaryEmailAddr = emailadd
                    End If
                    If Not IsDBNull(drEmployee.Item("WorkPhoneNo")) Then
                        Dim phn As New TelephoneNumber
                        phn.FreeFormNumber = drEmployee.WorkPhoneNo
                        entity.PrimaryPhone = phn
                    End If
                    If Not IsDBNull(drEmployee.Item("MobilePhoneNo")) Then
                        Dim phn As New TelephoneNumber
                        phn.FreeFormNumber = drEmployee.MobilePhoneNo
                        entity.Mobile = phn
                    End If
                    Dim phyadd As New PhysicalAddress
                    If Not IsDBNull(drEmployee.Item("AddressLine1")) Then
                        phyadd.Line1 = drEmployee.AddressLine1
                    End If
                    If Not IsDBNull(drEmployee.Item("State")) Then
                        phyadd.CountrySubDivisionCode = drEmployee.State
                    End If
                    If Not IsDBNull(drEmployee.Item("City")) Then
                        phyadd.City = drEmployee.City
                    End If
                    If Not IsDBNull(drEmployee.Item("Zip")) Then
                        phyadd.PostalCode = drEmployee.Zip
                    End If
                    entity.BillAddr = phyadd
                    'If Not IsDBNull(drEmployee.Item("HiredDate")) Then
                    '    entity.HiredDate = drEmployee.HiredDate
                    'End If
                    Me.Insert(dataService, entity, drEmployee.FullName, "Vendor")
                    '.Address1, .Address2, .City, .Country, .PostalCode, .State, .HiredDate, .Mobile, .Phone)
                End If
            Next


        End If
    End Sub
    Public Sub AddQBVendorIntoTimeLiveVendor()
        If SetQBParameters() Then
            Dim qboVendorempty = New Vendor()

            Dim qboVendorsfull = dataService.FindAll(qboVendorempty, 1, 100).ToList()

            For Each qboVendors In qboVendorsfull
                Dim EmailAddress As String = ""
                Dim CustomerName As String = ""
                Dim FirstName As String = ""
                Dim LastName As String = ""
                Dim Telephone1 As String = ""
                Dim Telephone2 As String = ""
                Dim Address1 As String = ""
                Dim Address2 As String = ""
                Dim City As String = ""
                Dim Country As String = ""
                Dim State As String = ""
                Dim PostalCode As String = ""
                Dim HiredDate As Date = Now.Date
                If qboVendors.PrimaryEmailAddr IsNot Nothing AndAlso qboVendors.PrimaryEmailAddr.Address <> "" Then
                    EmailAddress = qboVendors.PrimaryEmailAddr.Address
                Else
                    If qboVendors.GivenName <> "" And qboVendors.FamilyName <> "" Then
                        EmailAddress = qboVendors.GivenName + "" + qboVendors.FamilyName + "@dummy.com"
                    ElseIf qboVendors.DisplayName <> "" Then
                        EmailAddress = Replace(qboVendors.DisplayName, " ", "") + "@dummy.com"
                    End If
                End If
                If qboVendors.GivenName <> "" Then
                    FirstName = qboVendors.GivenName
                End If
                If qboVendors.FamilyName <> "" Then
                    LastName = qboVendors.FamilyName
                End If
                If qboVendors.DisplayName <> "" And FirstName = "" Then
                    FirstName = qboVendors.DisplayName
                End If
                If qboVendors.DisplayName <> "" And LastName = "" Then
                    LastName = qboVendors.DisplayName
                End If
                If qboVendors.PrimaryPhone IsNot Nothing AndAlso qboVendors.PrimaryPhone.FreeFormNumber <> "" Then
                    Telephone1 = qboVendors.PrimaryPhone.FreeFormNumber
                End If
                If qboVendors.Mobile IsNot Nothing AndAlso qboVendors.Mobile.FreeFormNumber <> "" Then
                    Telephone2 = qboVendors.Mobile.FreeFormNumber
                End If
                If qboVendors.BillAddr IsNot Nothing AndAlso qboVendors.BillAddr.Line1 <> "" Then
                    Address1 = qboVendors.BillAddr.Line1
                End If
                If qboVendors.BillAddr IsNot Nothing AndAlso qboVendors.BillAddr.Country <> "" Then
                    Country = qboVendors.BillAddr.Country
                End If
                If qboVendors.BillAddr IsNot Nothing AndAlso qboVendors.BillAddr.City <> "" Then
                    City = qboVendors.BillAddr.City
                End If
                If qboVendors.BillAddr IsNot Nothing AndAlso qboVendors.BillAddr.CountrySubDivisionCode <> "" Then
                    State = qboVendors.BillAddr.CountrySubDivisionCode
                End If
                If qboVendors.BillAddr IsNot Nothing AndAlso qboVendors.BillAddr.PostalCode <> "" Then
                    PostalCode = qboVendors.BillAddr.PostalCode
                End If
                Dim nDepartmentId As Integer = New AccountDepartmentBLL().GetDepartmentIdForQB(DBUtilities.GetSessionAccountId)
                Dim objAccountRoles As New AccountRoleBLL
                Dim nRoleId As Integer = objAccountRoles.GetAccountRolesByAccountIdAndMasterAccountRoleId(DBUtilities.GetSessionAccountId, 2).Rows(0).Item(0)
                Dim nLocationId As Integer = New AccountLocationBLL().GetLocationIdForQB(DBUtilities.GetSessionAccountId)
                Dim nEmployeeTypeId As Guid = New AccountEmployeeTypeBLL().GetDefaultVendorAccountEmployeeTypeId(DBUtilities.GetSessionAccountId)
                Dim nEmployeeStatusId As Integer = New AccountStatusBLL().GetDefaultAccountStatusId(DBUtilities.GetSessionAccountId)
                Dim nWorkingDayTypeId As Guid = New AccountWorkingDayTypeBLL().InsertDefault(DBUtilities.GetSessionAccountId, 0)
                Dim nBillingTypeId As Integer = New AccountBillingTypeBLL().GetAccountBillingTypesByMasterBillingTypeId(DBUtilities.GetSessionAccountId, 1).Rows(0).Item(0)


                Dim objEmployee As New AccountEmployeeBLL()
                Dim dtEmployee As AccountEmployee.AccountEmployeeDataTable = objEmployee.GetAccountEmployeesByEmployeeNameAndEmailAddress(DBUtilities.GetSessionAccountId, FirstName + " " + LastName, EmailAddress)
                If dtEmployee.Rows.Count > 0 Then

                Else
                    objEmployee.AddAccountEmployee(EmailAddress, EmailAddress, FirstName, LastName, EmailAddress, "", DBUtilities.GetSessionAccountId, _
                                                   nDepartmentId, nRoleId, nLocationId, 233, nBillingTypeId, Now.Date, -1, 0, 6, DBUtilities.GetSessionAccountEmployeeId, _
                                                   DBUtilities.GetSessionAccountEmployeeId, nEmployeeTypeId, nEmployeeStatusId, _
                            "", HiredDate, Now.Date, nWorkingDayTypeId, System.Guid.Empty, 0, System.Guid.Empty, False, "", False, False, Address1, Address2, _
                            State, City, PostalCode, Telephone1, Telephone2, "", "", "", True)

                End If
            Next
        End If
    End Sub
    Public Sub AddTimeLiveProjectTaskIntoQBItemSubItem()
        If SetQBParameters() Then
            'For Item --------------------------------
            Dim ItemId As Integer
            Dim ItemQS As QueryService(Of Item) = New QueryService(Of Item)(serviceContext)
            Dim ProjectBLL As New AccountProjectBLL()
            Dim dtProject As TimeLiveDataSet.vueAccountProjectsDataTable = ProjectBLL.GetAccountProjectsForGridView(DBUtilities.GetSessionAccountId, False, "-1", 0, "1")
            Dim drProject As TimeLiveDataSet.vueAccountProjectsRow
            For Each drProject In dtProject.Rows
                Dim Item As New Intuit.Ipp.Data.Item()
                Item.Name = drProject.ProjectName
                If Not IsDBNull(drProject.Item("ProjectDescription")) Then
                    Item.Description = drProject.ProjectDescription
                End If
                Item.IncomeAccountRef = New ReferenceType() With {.Value = "1"}
                Item.TrackQtyOnHand = False
                Me.Insert(dataService, Item, drProject.ProjectName, "Project / Task")
            Next
            'For Sub-Item --------------------------------
            Dim TaskBLL As New AccountProjectTaskBLL
            Dim dtTask As DataTable = TaskBLL.GetTasksForWSByAccountId(DBUtilities.GetSessionAccountId)
            Dim drTask As DataRow

            For Each drTask In dtTask.Rows
                Dim SubItem As New Intuit.Ipp.Data.Item()
                If Not IsDBNull(drTask.Item("ParentAccountProjectTaskId")) Then
                    Dim dr() As DataRow = dtTask.Select("AccountProjectTaskId = " & drTask.Item("ParentAccountProjectTaskId"))
                    If dr.Length > 0 Then
                        Dim ItemQueryResult = ItemQS.ExecuteIdsQuery("SELECT * FROM Item WHERE Name = '" & dr(0).Item("TaskName") & "'")
                        If ItemQueryResult.Count > 0 Then
                            ItemId = ItemQueryResult.Item(0).Id
                            If ItemQueryResult.Count > 1 Then
                                For Each i As Item In ItemQueryResult
                                    If i.FullyQualifiedName = drTask.Item("ItemParent") Then
                                        ItemId = i.Id
                                    End If
                                Next
                            End If
                        Else
                            Throw New Exception("Item """ & dr(0).Item("TaskName") & """ doesn't exist.")
                            Exit Sub
                        End If
                    End If
                Else
                    Dim ItemQueryResult = ItemQS.ExecuteIdsQuery("SELECT * FROM Item WHERE Name = '" & drTask.Item("ProjectName") & "'")
                    If ItemQueryResult.Count > 0 Then
                        ItemId = ItemQueryResult.Item(0).Id
                    Else
                        Throw New Exception("Item """ & drTask.Item("ProjectName") & """ doesn't exist.")
                        Exit Sub
                    End If

                End If
                SubItem.Name = drTask.Item("TaskName")
                If Not IsDBNull(drTask.Item("TaskDescription")) Then
                    SubItem.Description = drTask.Item("TaskDescription")
                End If
                SubItem.IncomeAccountRef = New ReferenceType() With {.Value = "1"}
                SubItem.TrackQtyOnHand = False
                SubItem.ParentRef = New ReferenceType() With {.Value = ItemId.ToString()}
                SubItem.SubItem = True
                SubItem.SubItemSpecified = True
                Me.Insert(dataService, SubItem, drTask.Item("TaskName"), "Project / Task")

            Next
        End If
    End Sub
    Public Sub AddQBItemSubItemIntoTimeLiveProjectTask()
        If SetQBParameters() Then
            Dim qboItemempty = New Item()
            Dim ProjectName As String = ""
            Dim qboItemFull = dataService.FindAll(qboItemempty).ToList()
            For Each qboItemempty In qboItemFull
                If Not qboItemempty.SubItem Then
                    ProjectName = qboItemempty.Name
                    Dim ProjectDescription As String
                    If qboItemempty.Description <> "" Then
                        ProjectDescription = qboItemempty.Description
                    Else
                        ProjectDescription = qboItemempty.Name
                    End If
                    Dim ProjectBLL As New AccountProjectBLL
                    Dim dtProject As TimeLiveDataSet.AccountProjectDataTable = ProjectBLL.GetAccountProjectsByProjectName(DBUtilities.GetSessionAccountId, qboItemempty.Name)
                    If dtProject.Rows.Count > 0 Then
                    Else
                        ProjectBLL.AddAccountProject(DBUtilities.GetSessionAccountId, GetProjectTypeId, GetClientId, 0, 0, GetProjectBillingTypeId, _
                                                     qboItemempty.Name, ProjectDescription, Now.Date, Now.AddMonths(1).Date, GetProjectStatusId, GetTeamLeadId, _
                                                     GetProjectManagerId, 0, 0, 1, "Months", qboItemempty.Name, 0, GetProjectBillingRateTypeId, False, True, 0, Now.Date, DBUtilities.GetSessionAccountEmployeeId, _
                                                     Now, DBUtilities.GetSessionAccountEmployeeId, False, "", False, 0, 0)
                    End If
                Else
                    Dim TaskName As String = qboItemempty.Name
                    Dim FullyQualifiedName As String = qboItemempty.FullyQualifiedName
                    Dim TaskBLL As New AccountProjectTaskBLL
                    Dim dtTask As TimeLiveDataSet.vueAccountProjectTaskDataTable = TaskBLL.GetAccountProjectTaskByAccountIdAndTaskName(DBUtilities.GetSessionAccountId, TaskName)
                    If dtTask.Rows.Count > 0 Then
                    Else
                        Dim Qname() As String = Split(qboItemempty.FullyQualifiedName, ":")
                        Dim nProjectId As Integer = GetProjectId(ProjectName)
                        Dim nParentTaskId As Integer
                        Dim ParentTaskName As String
                        If qboItemempty.Level > 1 Then
                            ParentTaskName = Qname.GetValue(qboItemempty.Level - 1)
                            nParentTaskId = GetParentTaskId(ParentTaskName)
                            UpdateIsParentInTask(nParentTaskId, True)
                        Else
                            nParentTaskId = 0
                        End If
                        Dim nProjectMilestoneId As Integer = GetProjectMilestoneIdByProjectId(nProjectId)
                        Dim nTaskTypeId As Integer = GetTaskTypeId()
                        Dim nTaskStatusId As Integer = GetTaskStatusId()
                        Dim nPriorityId As Integer = GetTaskPriorityId()
                        Dim nCurrencyId As Integer = GetCurrencyId()
                        TaskBLL.AddAccountProjectTask(nProjectId, nParentTaskId, TaskName, TaskName, _
                               nTaskTypeId, 1, "Months", 0, _
                               0, Now.AddMonths(1).Date, nTaskStatusId, nPriorityId, _
                               nProjectMilestoneId, False, False, Now.Date, GetTeamLeadId, Now.Date, GetTeamLeadId, 0, 0, "", _
                               True, TaskName, 0, False, nCurrencyId, Now.Date, 0)
                    End If


                End If
            Next
        End If
    End Sub
    Public Sub AddQBJobSubJobIntoTimeLiveProjectTask()
        If SetQBParameters() Then
            Dim qboProjectempty = New Customer()
            Dim qboProjectfull = dataService.FindAll(qboProjectempty).ToList()

            For Each qboProjects In qboProjectfull
                If qboProjects.Job Then
                    Dim Qname() As String = Split(qboProjects.FullyQualifiedName, ":")

                    If qboProjects.Level = 1 Then
                        Dim nClientId As Integer = GetClientIdByName(Qname(0))
                        Dim ProjectName As String = ""
                        If qboProjects.DisplayName <> "" Then
                            ProjectName = qboProjects.DisplayName
                        End If
                        Dim ProjectBLL As New AccountProjectBLL
                        Dim dtProject As TimeLiveDataSet.AccountProjectDataTable = ProjectBLL.GetAccountProjectsByProjectName(DBUtilities.GetSessionAccountId, ProjectName)
                        If dtProject.Rows.Count > 0 Then
                        Else
                            ProjectBLL.AddAccountProject(DBUtilities.GetSessionAccountId, GetProjectTypeId, nClientId, 0, 0, GetProjectBillingTypeId, _
                                                          ProjectName, ProjectName, Now.Date, Now.AddMonths(1).Date, GetProjectStatusId, GetTeamLeadId, _
                                                         GetProjectManagerId, 0, 0, 1, "Months", ProjectName, 0, GetProjectBillingRateTypeId, False, True, 0, Now.Date, _
                                                         DBUtilities.GetSessionAccountEmployeeId, Now, DBUtilities.GetSessionAccountEmployeeId, False, "", False, 0, 0)
                        End If
                    ElseIf qboProjects.Level > 1 Then
                        Dim TaskName As String = qboProjects.DisplayName
                        Dim FullyQualifiedName As String = qboProjects.FullyQualifiedName
                        Dim TaskBLL As New AccountProjectTaskBLL
                        Dim dtTask As TimeLiveDataSet.vueAccountProjectTaskDataTable = TaskBLL.GetAccountProjectTaskByAccountIdAndTaskName(DBUtilities.GetSessionAccountId, TaskName)
                        If dtTask.Rows.Count > 0 Then
                        Else

                            Dim nProjectId As Integer = GetProjectId(Qname(1))
                            Dim nParentTaskId As Integer
                            Dim ParentTaskName As String
                            If qboProjects.Level > 2 Then
                                ParentTaskName = Qname.GetValue(qboProjects.Level - 1)
                                nParentTaskId = GetParentTaskId(ParentTaskName)
                                UpdateIsParentInTask(nParentTaskId, True)
                            Else
                                nParentTaskId = 0
                            End If
                            Dim nProjectMilestoneId As Integer = GetProjectMilestoneIdByProjectId(nProjectId)
                            Dim nTaskTypeId As Integer = GetTaskTypeId()
                            Dim nTaskStatusId As Integer = GetTaskStatusId()
                            Dim nPriorityId As Integer = GetTaskPriorityId()
                            Dim nCurrencyId As Integer = GetCurrencyId()
                            TaskBLL.AddAccountProjectTask(nProjectId, nParentTaskId, TaskName, TaskName, _
                                   nTaskTypeId, 1, "Months", 0, _
                                   0, Now.AddMonths(1).Date, nTaskStatusId, nPriorityId, _
                                   nProjectMilestoneId, False, False, Now.Date, GetTeamLeadId, Now.Date, GetTeamLeadId, 0, 0, "", _
                                   True, TaskName, 0, False, nCurrencyId, Now.Date, 0)
                        End If

                    End If



                End If
            Next
        End If
    End Sub
    Public Sub AddTimeLiveProjectTaskIntoQBJobSubJob()
        If SetQBParameters() Then
            Dim JobId As Integer
            Dim CustomerQS As QueryService(Of Customer) = New QueryService(Of Customer)(serviceContext)
            'For Job -------------------------
            Dim ProjectBLL As New AccountProjectBLL()
            Dim dtProject As TimeLiveDataSet.vueAccountProjectsDataTable = ProjectBLL.GetAccountProjectsForGridView(DBUtilities.GetSessionAccountId, False, "-1", 0, "1")
            Dim drProject As TimeLiveDataSet.vueAccountProjectsRow
            For Each drProject In dtProject.Rows
                Dim job As New Customer
                job.DisplayName = drProject.ProjectName
                job.Job = True
                job.JobSpecified = True
                Dim QueryResult = CustomerQS.ExecuteIdsQuery("SELECT * FROM Customer WHERE FullyQualifiedName = '" & drProject.PartyName & "'")
                If QueryResult.Count > 0 Then
                    job.ParentRef = New ReferenceType() With {.Value = QueryResult.Item(0).Id}
                Else
                    Throw New Exception("Client """ & drProject.PartyName & """ doesn't exist.")
                    Exit Sub
                End If
                Insert(dataService, job, drProject.ProjectName, "Project / Task")
            Next

            'For Sub-Job --------------------------------
            Dim TaskBLL As New AccountProjectTaskBLL
            Dim dtTask As DataTable = TaskBLL.GetTasksForWSByAccountId(DBUtilities.GetSessionAccountId)
            Dim drTask As DataRow
            For Each drTask In dtTask.Rows
                Dim SubJob As New Intuit.Ipp.Data.Customer()
                Dim QueryResult = CustomerQS.ExecuteIdsQuery("SELECT * FROM Customer WHERE FullyQualifiedName = '" & drTask.Item("JobParent") & "'")
                If QueryResult.Count > 0 Then
                    JobId = QueryResult.Item(0).Id
                Else
                    Throw New Exception("Task """ & drTask.Item("JobParent") & """ doesn't exist.")
                    Exit Sub
                End If
                SubJob.DisplayName = drTask.Item("TaskName")
                SubJob.Job = True
                SubJob.JobSpecified = True
                SubJob.ParentRef = New ReferenceType() With {.Value = JobId.ToString()}
                Me.Insert(dataService, SubJob, drTask.Item("TaskName"), "Project / Task")
            Next
        End If
    End Sub
    Public Sub AddTimeLiveProjectTaskIntoQBJobItem()
        If SetQBParameters() Then
            Dim ItemId As Integer
            'For Job -------------------------
            Dim ProjectBLL As New AccountProjectBLL()
            Dim dtProject As TimeLiveDataSet.vueAccountProjectsDataTable = ProjectBLL.GetAccountProjectsForGridView(DBUtilities.GetSessionAccountId, False, "-1", 0, "1")
            Dim drProject As TimeLiveDataSet.vueAccountProjectsRow
            For Each drProject In dtProject.Rows
                Dim job As New Customer
                job.DisplayName = drProject.ProjectName
                job.Job = True
                job.JobSpecified = True
                Dim CustomerQS As QueryService(Of Customer) = New QueryService(Of Customer)(serviceContext)
                Dim QueryResult = CustomerQS.ExecuteIdsQuery("SELECT * FROM Customer WHERE FullyQualifiedName = '" & drProject.PartyName & "'")
                If QueryResult.Count > 0 Then
                    job.ParentRef = New ReferenceType() With {.Value = QueryResult.Item(0).Id}
                Else
                    Throw New Exception("Client """ & drProject.PartyName & """ doesn't exist.")
                    Exit Sub
                End If
                Insert(dataService, job, drProject.ProjectName, "Project / Task")
            Next
            'For Item --------------------------------
            Dim TaskBLL As New AccountProjectTaskBLL
            Dim dtTask As DataTable = TaskBLL.GetTasksForWSByAccountId(DBUtilities.GetSessionAccountId)
            Dim drTask As DataRow

            For Each drTask In dtTask.Rows
                Dim SubItem As New Intuit.Ipp.Data.Item()
                If Not IsDBNull(drTask.Item("ParentAccountProjectTaskId")) Then
                    Dim dr() As DataRow = dtTask.Select("AccountProjectTaskId = " & drTask.Item("ParentAccountProjectTaskId"))
                    If dr.Length > 0 Then
                        Dim ItemQS As QueryService(Of Item) = New QueryService(Of Item)(serviceContext)
                        Dim ItemQueryResult = ItemQS.ExecuteIdsQuery("SELECT * FROM Item WHERE Name = '" & dr(0).Item("TaskName") & "'")
                        If ItemQueryResult.Count > 0 Then
                            ItemId = ItemQueryResult.Item(0).Id
                            If ItemQueryResult.Count > 1 Then
                                For Each i As Item In ItemQueryResult
                                    If i.FullyQualifiedName = drTask.Item("JobItemParent") Then
                                        ItemId = i.Id
                                    End If
                                Next
                            End If
                        Else
                            Throw New Exception("Item """ & dr(0).Item("TaskName") & """ doesn't exist.")
                            Exit Sub
                        End If
                    End If
                Else
                    ItemId = 0
                End If
                SubItem.Name = drTask.Item("TaskName")
                If Not IsDBNull(drTask.Item("TaskDescription")) Then
                    SubItem.Description = drTask.Item("TaskDescription")
                End If
                SubItem.IncomeAccountRef = New ReferenceType() With {.Value = "1"}
                SubItem.TrackQtyOnHand = False
                If ItemId <> 0 Then
                    SubItem.ParentRef = New ReferenceType() With {.Value = ItemId.ToString()}
                    SubItem.SubItem = True
                    SubItem.SubItemSpecified = True
                End If
                Me.Insert(dataService, SubItem, drTask.Item("TaskName"), "Project / Task")
            Next
        End If
    End Sub
    Public Function GetProjectTypeId() As Integer
        Dim objProjectType As New AccountProjectTypeBLL
        Dim nProjectTypeId As Integer
        Try
            nProjectTypeId = objProjectType.GetAccountProjectTypesByAccountIdAndIsDisabled(DBUtilities.GetSessionAccountId, 0).Rows(0).Item(0)
        Catch ex As Exception
            If ex.Message = "There is no row at position 0." Then
                Throw New Exception("Project Type not exist.")
            Else
                Throw ex
            End If
        End Try
        Return nProjectTypeId
    End Function
    Public Function GetProjectBillingTypeId() As Integer
        Dim objProjectBillingType As New AccountBillingTypeBLL
        Dim nProjectBillingTypeId As Integer
        Try
            nProjectBillingTypeId = objProjectBillingType.GetAccountBillingTypesForProjectByAccountIdAndIsDisabled(DBUtilities.GetSessionAccountId, 0).Rows(0).Item(0)
        Catch ex As Exception
            If ex.Message = "There is no row at position 0." Then
                Throw New Exception("Project Billing Type not exist.")
            Else
                Throw ex
            End If
        End Try
        Return nProjectBillingTypeId
    End Function
    Public Function GetProjectStatusId() As Integer
        Dim objProjectStatus As New AccountStatusBLL
        Dim nProjectStatusId As Integer
        Try
            nProjectStatusId = objProjectStatus.GetAccountsStatusForProjectByIsDisabled(DBUtilities.GetSessionAccountId, 0).Rows(0).Item(0)
        Catch ex As Exception
            If ex.Message = "There is no row at position 0." Then
                Throw New Exception("Project Status not exist.")
            Else
                Throw ex
            End If
        End Try
        Return nProjectStatusId
    End Function
    Public Function GetTeamLeadId() As Integer
        Dim objTeamLead As New AccountEmployeeBLL
        Dim nTeamLeadId As Integer = objTeamLead.GetAccountEmployeesByAccountIdAndIsDisabled(DBUtilities.GetSessionAccountId, 0).Rows(0).Item(0)
        Return nTeamLeadId
    End Function
    Public Function GetProjectManagerId() As Integer
        Dim objProjectManager As New AccountEmployeeBLL
        Dim nProjectManagerId As Integer = objProjectManager.GetAccountEmployeesByAccountIdAndIsDisabled(DBUtilities.GetSessionAccountId, 0).Rows(0).Item(0)
        Return nProjectManagerId
    End Function
    Public Function GetProjectBillingRateTypeId() As Integer
        Dim objProjectBillingRateType As New SystemDataBLL
        Dim nProjectBillingRateTypeId As Integer
        Try
            nProjectBillingRateTypeId = objProjectBillingRateType.GetProjectBillingRateTypeForQB().Rows(3).Item(0)
        Catch ex As Exception
            If ex.Message = "There is no row at position 0." Then
                Throw New Exception("Project Billing Rate Type not exist.")
            Else
                Throw ex
            End If
        End Try
        Return nProjectBillingRateTypeId
    End Function
    Public Function GetClientId() As Integer
        Dim objClient As New AccountPartyBLL
        Dim nClientId As Integer
        Try
            nClientId = objClient.GetAccountPartiesByAccountId(DBUtilities.GetSessionAccountId).Rows(0).Item(0)
        Catch ex As Exception
            If ex.Message = "There is no row at position 0." Then
                Throw New Exception("Client not exist.")
            Else
                Throw ex
            End If
        End Try
        Return nClientId
    End Function
    Public Function GetProjectMilestoneIdByProjectId(ByVal AccountProjectId As Integer) As Integer
        Dim objProjectMilestone As New AccountProjectMilestoneBLL
        Dim nProjectMilestoneId As Integer
        Try
            nProjectMilestoneId = objProjectMilestone.GetAccountProjectMilestonesByProjectId(AccountProjectId).Rows(0).Item(0)
        Catch ex As Exception
            If ex.Message = "There is no row at position 0." Then
                Throw New Exception("Project Milestone not exist.")
            Else
                Throw ex
            End If
        End Try
        Return nProjectMilestoneId
    End Function
    Public Function GetTaskTypeId() As Integer
        Dim objTaskType As New AccountTaskTypeBLL
        Dim nTaskTypeId As Integer = objTaskType.GetAccountTaskTypesByAccountId(DBUtilities.GetSessionAccountId).Rows(0).Item(0)
        Return nTaskTypeId
    End Function
    Public Function GetTaskStatusId() As Integer
        Dim objTaskStatus As New AccountStatusBLL
        Dim nTaskStatusId As Integer = objTaskStatus.GetAccountsStatusForTaskByAccountStatusId(DBUtilities.GetSessionAccountId, 0).Rows(0).Item(0)
        Return nTaskStatusId
    End Function
    Public Function GetTaskPriorityId() As Integer
        Dim objTaskPriority As New AccountPriorityBLL
        Dim nTaskPriorityId As Integer = objTaskPriority.GetAccountPrioritiesByAccountIdAndAccountPriorityId(DBUtilities.GetSessionAccountId, 0).Rows(0).Item(0)
        Return nTaskPriorityId
    End Function
    Public Function GetCurrencyId() As Integer
        Dim objCurrency As New AccountCurrencyBLL
        Dim nCurrencyId As Integer = objCurrency.GetAccountCurrencyByAccountId(DBUtilities.GetSessionAccountId).Rows(0).Item(0)
        Return nCurrencyId
    End Function
    Public Function GetProjectId(ByVal ProjectName As String) As Integer
        Dim objProject As New AccountProjectBLL
        Dim nProjectId As Integer
        Try
            nProjectId = objProject.GetAccountProjectsByProjectName(DBUtilities.GetSessionAccountId, ProjectName).Rows(0).Item(0)
        Catch ex As Exception
            If ex.Message = "There is no row at position 0." Then
                Throw New Exception("Project " & """" & ProjectName & """" & " not exist.")
            Else
                Throw ex
            End If
        End Try
        Return nProjectId
    End Function
    Public Function GetParentTaskId(ByVal ParentTaskName As String) As Integer
        Dim objParentTask As New AccountProjectTaskBLL
        Dim nParentTaskId As Integer
        Try
            nParentTaskId = objParentTask.GetAccountProjectTaskByAccountIdAndTaskName(DBUtilities.GetSessionAccountId, ParentTaskName).Rows(0).Item(0)
        Catch ex As Exception
            If ex.Message = "There is no row at position 0." Then
                Throw New Exception("Parent Task " & """" & ParentTaskName & """" & " not exist.")
            Else
                Throw ex
            End If
        End Try
        Return nParentTaskId
    End Function
    Public Sub UpdateIsParentInTask(ByVal AccountProjectTaskId As Integer, ByVal IsParent As Boolean)
        Dim objParentTask As New AccountProjectTaskBLL
        objParentTask.UpdateIsParentInAccountProjectTask(AccountProjectTaskId, IsParent)
    End Sub
    Public Function GetClientIdByName(ByVal ClientName As String) As Integer
        Dim objClient As New AccountPartyBLL
        Dim nClientId As Integer
        Try
            nClientId = objClient.GetClientsByName(DBUtilities.GetSessionAccountId, ClientName).Rows(0).Item(0)
        Catch ex As Exception
            If ex.Message = "There is no row at position 0." Then
                Throw New Exception("Client " & """" & ClientName & """" & " not exist.")
            Else
                Throw ex
            End If
        End Try
        Return nClientId
    End Function
    Public Sub AddQBJobItemIntoTimeLiveProjectTask()
        'Not used function right now.
        If SetQBParameters() Then
            Dim qboProjectempty = New Customer()
            Dim qboProjectfull = dataService.FindAll(qboProjectempty).ToList()

            For Each qboProjects In qboProjectfull
                If qboProjects.Job Then
                    Dim Qname() As String = Split(qboProjects.FullyQualifiedName, ":")

                    If qboProjects.Level = 1 Then
                        Dim nClientId As Integer = GetClientIdByName(Qname(0))
                        Dim ProjectName As String = ""
                        If qboProjects.DisplayName <> "" Then
                            ProjectName = qboProjects.DisplayName
                        End If
                        Dim ProjectBLL As New AccountProjectBLL
                        Dim dtProject As TimeLiveDataSet.AccountProjectDataTable = ProjectBLL.GetAccountProjectsByProjectName(DBUtilities.GetSessionAccountId, ProjectName)
                        If dtProject.Rows.Count > 0 Then
                        Else
                            ProjectBLL.AddAccountProject(DBUtilities.GetSessionAccountId, GetProjectTypeId, nClientId, 0, 0, GetProjectBillingTypeId, _
                                                          ProjectName, ProjectName, Now.Date, Now.AddMonths(1).Date, GetProjectStatusId, GetTeamLeadId, _
                                                         GetProjectManagerId, 0, 0, 1, "Months", ProjectName, 0, GetProjectBillingRateTypeId, False, True, 0, Now.Date, _
                                                         DBUtilities.GetSessionAccountEmployeeId, Now, DBUtilities.GetSessionAccountEmployeeId, False, "", False, 0, 0)
                        End If
                    End If

                End If
            Next

            Dim qboItemempty = New Item()
            Dim ProjectName1 As String = ""
            Dim qboItemFull = dataService.FindAll(qboItemempty).ToList()
            For Each qboItemempty In qboItemFull
                If qboItemempty.SubItem Then
                    Dim TaskName As String = qboItemempty.Name
                    Dim FullyQualifiedName As String = qboItemempty.FullyQualifiedName
                    Dim TaskBLL As New AccountProjectTaskBLL
                    Dim dtTask As TimeLiveDataSet.vueAccountProjectTaskDataTable = TaskBLL.GetAccountProjectTaskByAccountIdAndTaskName(DBUtilities.GetSessionAccountId, TaskName)
                    If dtTask.Rows.Count > 0 Then
                    Else
                        Dim Qname() As String = Split(qboItemempty.FullyQualifiedName, ":")
                        Dim nProjectId As Integer = GetProjectId(ProjectName1)
                        Dim nParentTaskId As Integer
                        Dim ParentTaskName As String
                        If qboItemempty.Level > 1 Then
                            ParentTaskName = Qname.GetValue(qboItemempty.Level - 1)
                            nParentTaskId = GetParentTaskId(ParentTaskName)
                            UpdateIsParentInTask(nParentTaskId, True)
                        Else
                            nParentTaskId = 0
                        End If
                        Dim nProjectMilestoneId As Integer = GetProjectMilestoneIdByProjectId(nProjectId)
                        Dim nTaskTypeId As Integer = GetTaskTypeId()
                        Dim nTaskStatusId As Integer = GetTaskStatusId()
                        Dim nPriorityId As Integer = GetTaskPriorityId()
                        Dim nCurrencyId As Integer = GetCurrencyId()
                        TaskBLL.AddAccountProjectTask(nProjectId, nParentTaskId, TaskName, TaskName, _
                               nTaskTypeId, 1, "Months", 0, _
                               0, Now.AddMonths(1).Date, nTaskStatusId, nPriorityId, _
                               nProjectMilestoneId, False, False, Now.Date, GetTeamLeadId, Now.Date, GetTeamLeadId, 0, 0, "", _
                               True, TaskName, 0, False, nCurrencyId, Now.Date, 0)
                    End If


                End If
            Next
        End If
    End Sub
    Public Sub AddTimeEntryInQB()
        If SetQBParameters() Then
            Dim TimeEntryBLL As New AccountEmployeeTimeEntryBLL
            Dim dtTimeEntry As AccountEmployeeTimeEntry.vueAccountEmployeeTimeEntryForQBDataTable = TimeEntryBLL.GetTimeEntriesByAccountEmployeeIdAndDateRange(DBUtilities.GetSessionAccountId, ddlEmployees.SelectedValue, StartTimeTextBox.PostedDate, EndTimeTextBox.PostedDate)
            Dim drTimeEntry As AccountEmployeeTimeEntry.vueAccountEmployeeTimeEntryForQBRow
            For Each drTimeEntry In dtTimeEntry.Rows
                AddTimeEntryInQBJobItem(drTimeEntry)
                'AddTimeEntryInQBJobSubJob(drTimeEntry)
                'AddTimeEntryInQBItemSubItem(drTimeEntry)
            Next
        End If
    End Sub
    Public Function GetQBCustomerIdByFullyQualifiedName(CustomerName As String) As String
        Dim CustomerQS As QueryService(Of Customer) = New QueryService(Of Customer)(serviceContext)
        Dim CustomerQueryResult = CustomerQS.ExecuteIdsQuery("SELECT * FROM Customer WHERE FullyQualifiedName = '" & CustomerName & "'")
        If CustomerQueryResult.Count > 0 Then
            Return CustomerQueryResult.Item(0).Id
        Else
            Throw New Exception("Customer """ & CustomerName & """ doesn't exist.")
            Exit Function
        End If
    End Function
    Public Function GetQBItemIdByNameAndFullyQualifiedName(Name As String, FullyQualifiedName As String) As String
        Dim ItemId As String
        Dim ItemQS As QueryService(Of Item) = New QueryService(Of Item)(serviceContext)
        Dim ItemQueryResult = ItemQS.ExecuteIdsQuery("SELECT * FROM Item WHERE Name = '" & Name & "'")
        If ItemQueryResult.Count > 0 Then
            ItemId = ItemQueryResult.Item(0).Id
            If ItemQueryResult.Count > 1 Then
                For Each i As Item In ItemQueryResult
                    If i.FullyQualifiedName = FullyQualifiedName Then
                        ItemId = i.Id
                    End If
                Next
            End If
        Else
            Throw New Exception("Item """ & Name & """ doesn't exist.")
            Exit Function
        End If
        Return ItemId
    End Function
    Public Function GetQBEmployeeOrVendorIdByDisplayName(DisplayName As String, IsVendor As Boolean) As String
        If IsVendor Then
            Dim VendorQS As QueryService(Of Intuit.Ipp.Data.Vendor) = New QueryService(Of Intuit.Ipp.Data.Vendor)(serviceContext)
            Dim VendorQueryResult = VendorQS.ExecuteIdsQuery("SELECT * FROM Vendor WHERE DisplayName = '" & DisplayName & "'")
            If VendorQueryResult.Count > 0 Then
                Return VendorQueryResult(0).Id
            Else
                Throw New Exception("Vendor """ & DisplayName & """ doesn't exist.")
                Exit Function
            End If
        Else
            Dim EmployeeQS As QueryService(Of Intuit.Ipp.Data.Employee) = New QueryService(Of Intuit.Ipp.Data.Employee)(serviceContext)
            Dim EmployeeQueryResult = EmployeeQS.ExecuteIdsQuery("SELECT * FROM Employee WHERE DisplayName = '" & DisplayName & "'")
            If EmployeeQueryResult.Count > 0 Then
                Return EmployeeQueryResult(0).Id
            Else
                Throw New Exception("Employee """ & DisplayName & """ doesn't exist.")
                Exit Function
            End If
        End If
    End Function
    Public Sub AddAccountEmployeeTimeEntry(drTimeEntry As AccountEmployeeTimeEntry.vueAccountEmployeeTimeEntryForQBRow, ItemId As String, CustomerId As String, EmployeeId As String)
        Dim entity As New TimeActivity
        If Not IsDBNull(drTimeEntry.Item("TimeEntryDescription")) Then
            entity.Description = drTimeEntry.TimeEntryDescription
        End If
        If drTimeEntry.IsVendor Then
            entity.NameOf = TimeActivityTypeEnum.Vendor
            entity.ItemElementName = ItemChoiceType5.VendorRef
        Else
            entity.NameOf = TimeActivityTypeEnum.Employee
            entity.ItemElementName = ItemChoiceType5.EmployeeRef
        End If
        entity.NameOfSpecified = True

        entity.ItemRef = New ReferenceType() With {.Value = ItemId}
        entity.CustomerRef = New ReferenceType() With {.Value = CustomerId}
        entity.AnyIntuitObject = New ReferenceType() With {.Value = EmployeeId, .type = IIf(drTimeEntry.IsVendor, objectNameEnumType.Vendor, objectNameEnumType.Employee)}
        entity.TxnDate = drTimeEntry.TimeEntryDate
        entity.TxnDateSpecified = True
        entity.Hours = drTimeEntry.TotalTime.Hour
        entity.HoursSpecified = True
        entity.Minutes = drTimeEntry.TotalTime.Minute
        entity.MinutesSpecified = True
        If Not IsDBNull(drTimeEntry.Item("IsBillable")) AndAlso drTimeEntry.Item("IsBillable").ToString() = "True" Then
            entity.BillableStatus = BillableStatusEnum.Billable
            entity.BillableStatusSpecified = True
            entity.HourlyRate = 0
            entity.HourlyRateSpecified = True
        End If
        Dim DisplayName As String = IIf(drTimeEntry.IsVendor, "Vendor Name: ", "Employee Name: ") & drTimeEntry.EmployeeName & " - Project Name: " & drTimeEntry.ProjectName & " - Task Name: " & drTimeEntry.TaskName & " - Entry Date: " & drTimeEntry.TimeEntryDate & " - Total Time: " & drTimeEntry.TotalTime.Hour & ":" & drTimeEntry.TotalTime.Minute
        Insert(dataService, entity, DisplayName, "Time Entries")
    End Sub
    Public Sub AddTimeEntryInQBJobItem(drTimeEntry As AccountEmployeeTimeEntry.vueAccountEmployeeTimeEntryForQBRow)
        Dim TaskWithParent As String = New AccountProjectTaskBLL().GetTaskNameForWSByAccountProjectTaskId(drTimeEntry.AccountProjectId, drTimeEntry.AccountProjectTaskId)
        Dim CustomerId As String = GetQBCustomerIdByFullyQualifiedName(drTimeEntry.PartyName & ":" & drTimeEntry.ProjectName)
        Dim ItemId As String = GetQBItemIdByNameAndFullyQualifiedName(drTimeEntry.TaskName, TaskWithParent)
        Dim EmployeeId As String = GetQBEmployeeOrVendorIdByDisplayName(drTimeEntry.EmployeeName, drTimeEntry.IsVendor)
        AddAccountEmployeeTimeEntry(drTimeEntry, ItemId, CustomerId, EmployeeId)
    End Sub
    Public Sub AddTimeEntryInQBJobSubJob(drTimeEntry As AccountEmployeeTimeEntry.vueAccountEmployeeTimeEntryForQBRow)
        Dim TaskWithParent As String = New AccountProjectTaskBLL().GetTaskNameForWSByAccountProjectTaskId(drTimeEntry.AccountProjectId, drTimeEntry.AccountProjectTaskId)
        Dim CustomerId As String = GetQBCustomerIdByFullyQualifiedName(drTimeEntry.PartyName & ":" & drTimeEntry.ProjectName & ":" & TaskWithParent)
        AddNoneItemInQB()
        Dim ItemId As String = GetQBItemIdByNameAndFullyQualifiedName("<None>", "<None>")
        Dim EmployeeId As String = GetQBEmployeeOrVendorIdByDisplayName(drTimeEntry.EmployeeName, drTimeEntry.IsVendor)
        AddAccountEmployeeTimeEntry(drTimeEntry, ItemId, CustomerId, EmployeeId)
    End Sub
    Public Sub AddTimeEntryInQBItemSubItem(drTimeEntry As AccountEmployeeTimeEntry.vueAccountEmployeeTimeEntryForQBRow)
        Dim TaskWithParent As String = New AccountProjectTaskBLL().GetTaskNameForWSByAccountProjectTaskId(drTimeEntry.AccountProjectId, drTimeEntry.AccountProjectTaskId)
        Dim CustomerId As String = GetQBCustomerIdByFullyQualifiedName(drTimeEntry.PartyName)
        Dim ItemId As String = GetQBItemIdByNameAndFullyQualifiedName(drTimeEntry.TaskName, TaskWithParent)
        Dim EmployeeId As String = GetQBEmployeeOrVendorIdByDisplayName(drTimeEntry.EmployeeName, drTimeEntry.IsVendor)
        AddAccountEmployeeTimeEntry(drTimeEntry, ItemId, CustomerId, EmployeeId)
    End Sub
    Protected Sub btnExport_Click(sender As Object, e As System.EventArgs) Handles btnExport.Click
        Try
            ExecutedDate = Now
            If chkClientExport.Checked Then
                AddTimeLiveClientIntoQBCustomer()
            End If
            If chkEmployeesExport.Checked Then
                AddTimeLiveEmployeeIntoQBEmployee()
            End If
            If chkVendorsExport.Checked Then
                AddTimeLiveVendorIntoQBVendor()
            End If
            If chkProjectTaskExport.Checked Then
                AddProjectTaskInQB()
            End If
            If chkTimeEntryExport.Checked Then
                AddTimeEntryInQB()
            End If
            'AddQBTimeActivityIntoTimeLiveTimeEntry()
            UIUtilities.ShowMessage("Record(s) transferred successfully", Me.Page)
        Catch ex As Exception
            ShowException(ex, True)
        End Try
    End Sub
    Public Sub AddProjectTaskInQB()
        AddTimeLiveProjectTaskIntoQBJobItem()
        'If rdJobItem.Checked Then
        '    AddTimeLiveProjectTaskIntoQBJobItem()
        'ElseIf rdItemSubItem.Checked Then
        '    AddTimeLiveProjectTaskIntoQBItemSubItem()
        'ElseIf rdJobSubJob.Checked Then
        '    AddTimeLiveProjectTaskIntoQBJobSubJob()
        'End If
    End Sub
    Public Sub AddNoneItemInQB()
        Dim Item As New Intuit.Ipp.Data.Item()
        Item.Name = "<None>"
        Item.IncomeAccountRef = New ReferenceType() With {.Value = "1"}
        Item.TrackQtyOnHand = False
        Me.Insert(dataService, Item, "<None>", "Project / Task")
    End Sub

    Protected Sub btnImport_Click(sender As Object, e As System.EventArgs) Handles btnImport.Click
        Try
            ExecutedDate = Now
            If chkCustomersImport.Checked Then
                AddQBCustomerIntoTimeLiveClient()
            End If
            If chkEmployeesImport.Checked Then
                AddQBEmployeeIntoTimeLiveEmployee()
            End If
            If chkVendorsImport.Checked Then
                AddQBVendorIntoTimeLiveVendor()
            End If
            If chkProjectTaskImport.Checked Then
                If rdJobSubJobImport.Checked Then
                    AddQBJobSubJobIntoTimeLiveProjectTask()
                ElseIf rdItemSubItemImport.Checked Then
                    AddQBItemSubItemIntoTimeLiveProjectTask()
                End If
            End If
            UIUtilities.ShowMessage("Record(s) transferred successfully", Me.Page)
        Catch ex As Exception
            ShowException(ex, False)
        End Try
    End Sub
    Public Sub ShowMessage(ByVal message As String)
        Dim strMessage As String = message
        Dim strScript As String = "alert('" & strMessage & "'); window.location = 'AccountQboOnline.aspx';"
        If (Not Me.Page.ClientScript.IsStartupScriptRegistered("clientScript")) Then
            ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "clientScript", strScript, True)
        End If
    End Sub
    Public Sub ShowException(ex As Exception, IsExport As Boolean)
        Dim ErrorMessage As String
        If Not ex.InnerException Is Nothing Then
            ErrorMessage = ex.InnerException.Message
        Else
            ErrorMessage = ex.Message
        End If
        If IsExport Then
            lblExceptionExport.Text = ErrorMessage
            lblExceptionExport.Visible = True
        Else
            lblExceptionImport.Text = ErrorMessage
            lblExceptionImport.Visible = True
        End If
    End Sub


    'Public Function ProcessEntityValidationError(entity As TEntity, idsEx As Intuit.Ipp.Exception.IdsException) As ActionConfirmation(Of TEntity)
    '    Dim message As New StringBuilder("ERROR: There were entity validation errors during the save process!")
    '    'DbEntityValidationException eve = (DbEntityValidationException)ex;
    '    Dim errorList = DirectCast(DirectCast(idsEx, Intuit.Ipp.Exception.IdsException).InnerException, Intuit.Ipp.Exception.IdsException).InnerExceptions

    '    message.Append("<ul>")
    '    For Each [error] As var In errorList
    '        message.Append("<li>")
    '        message.Append(String.Format("Error {0} - {1}: {2}", [error].ErrorCode, [error].Message, [error].Detail))

    '        message.Append("</li>")
    '    Next
    '    message.Append("</ul>")

    '    Return CRUDMessage(False, "save", entity, message.ToString())
    'End Function
End Class
