Imports Microsoft.VisualBasic
Imports TimeLiveDataSetTableAdapters
<System.ComponentModel.DataObject()> _
Public Class LTCustomerBLL

    Private _LTCustomerTableAdapter As LTCustomerTableAdapter = Nothing
    Protected ReadOnly Property Adapter() As LTCustomerTableAdapter
        Get
            If _LTCustomerTableAdapter Is Nothing Then
                _LTCustomerTableAdapter = New LTCustomerTableAdapter()
            End If

            Return _LTCustomerTableAdapter
        End Get
    End Property
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetLTCustomers() As TimeLiveDataSet.LTCustomerDataTable
        Return Adapter.GetData
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetLTCustomerByCustomerId(ByVal CustomerId As Integer) As TimeLiveDataSet.LTCustomerDataTable
        Return Adapter.GetDataByCustomerId(CustomerId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetLTCustomerByAccountId(ByVal AccountId As Integer) As TimeLiveDataSet.LTCustomerRow
        Return Adapter.GetDataByAccountId(AccountId).Rows(0)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, True)> _
    Public Function AddLTCustomerForNewAccount(ByVal AccountId As Integer) As Integer

        Return Me.Adapter.InsertCustomer(AccountId)

    End Function

    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, True)> _
        Public Function AddLTCustomer( _
                    ByVal AccountId As System.Nullable(Of Integer), _
                    ByVal CustomerName As String, _
                    ByVal Prefix As String, _
                    ByVal FirstName As String, _
                    ByVal MiddleName As String, _
                    ByVal LastName As String, _
                    ByVal Address1 As String, _
                    ByVal Address2 As String, _
                    ByVal ZipCode As String, _
                    ByVal State As String, _
                    ByVal City As String, _
                    ByVal CountryId As System.Nullable(Of Short), _
                    ByVal EMailAddress As String, _
                    ByVal Telephone As String, _
                    ByVal Fax As String, _
                    ByVal CustomerRequestTypeId As System.Nullable(Of Byte) _
                    ) As Integer

        Try


            Dim LTCustomers As New TimeLiveDataSet.LTCustomerDataTable
            Dim LTCustomer As TimeLiveDataSet.LTCustomerRow = LTCustomers.NewLTCustomerRow

            With LTCustomer
                If AccountId.HasValue Then
                    .AccountId = AccountId
                End If
                .CustomerName = CustomerName
                .Prefix = Prefix
                .FirstName = FirstName
                .LastName = LastName
                .Address1 = Address1
                .Address2 = Address2
                .ZipCode = ZipCode
                .State = State
                .City = City
                .CountryId = CountryId
                .EMailAddress = EMailAddress
                .Telephone = Telephone
                .Fax = Fax
                .CustomerRequestTypeId = CustomerRequestTypeId


            End With

            LTCustomers.AddLTCustomerRow(LTCustomer)


            ' Add the new product
            Dim rowsAffected As Integer = Adapter.Update(LTCustomers)


            Me.PostAddCustomer(LTCustomer, Me.GetLastId())


            ' Return true if precisely one row was inserted, otherwise false
            Return rowsAffected = 1

        Catch ex As Exception
            Throw ex
        End Try


    End Function
    Public Function GetLastId() As Integer
        Return CType(New IdentityQueryTableAdapter().GetLTCustomerLastId.Rows(0), TimeLiveDataSet.IdentityQueryRow).LastId
    End Function

    Public Sub PostAddCustomer(ByVal LTCustomer As TimeLiveDataSet.LTCustomerRow, ByVal CustomerId As Integer)

        Dim Country As String = CType(New SystemDataBLL().GetCountryByCountryId(LTCustomer.CountryId), TimeLiveDataSet.SystemCountryRow).Country

        If LTCustomer.CustomerRequestTypeId = 1 Then
            Me.SendDownloadEMail(LTCustomer)
            UIUtilities.RedirectToRegistrationComplete(LTCustomer.EMailAddress)
        ElseIf LTCustomer.CustomerRequestTypeId = 2 Then
            Me.SendDownloadEMail(LTCustomer)
            With LTCustomer
                ShoppingCart.SubmitPaymentRequest(20, CustomerId, 1, .CustomerName, .FirstName, .LastName, .Address1, .Address2, .City, .State, Country, .EMailAddress, .Telephone, .ZipCode)
            End With
        ElseIf LTCustomer.CustomerRequestTypeId = 3 Then
            Me.SendPrepopulatedDemoEMail(LTCustomer)
            UIUtilities.RedirectToRegistrationComplete(LTCustomer.EMailAddress)
        End If


    End Sub

    Public Sub SendDownloadEMail(ByVal LTCustomer As TimeLiveDataSet.LTCustomerRow)

        EMailUtilities.SendEMail("Welcome To TimeLive", "TimeLiveDownload", GetPreparedNameValueForDownload(LTCustomer), LTCustomer.EMailAddress, , , EMailUtilities.TIMELIVE_DOWNLOAD_INFORMATION_FROM, EMailUtilities.EMAIL_FROM_TIMELIVE_SALES, True)
        EMailUtilities.DequeueEmail()

    End Sub
    Public Sub SendBuildDownloadRequestEMail()

        EMailUtilities.SendEMail("Build download request", "TimeLiveBuildDownloadRequest", Nothing, EMailUtilities.EMAIL_TO_TIMELIVE_SALES, , , EMailUtilities.TIMELIVE_DOWNLOAD_INFORMATION_FROM, EMailUtilities.EMAIL_FROM_TIMELIVE_SALES)
        EMailUtilities.DequeueEmail()

    End Sub
    Public Sub SendPrepopulatedDemoEMail(ByVal LTCustomer As TimeLiveDataSet.LTCustomerRow)

        EMailUtilities.SendEMail("Welcome To TimeLive", "DemoRequest", GetPreparedNameValueForDownload(LTCustomer), LTCustomer.EMailAddress, , , EMailUtilities.TIMELIVE_DEMO_REQUEST_FROM, EMailUtilities.EMAIL_FROM_TIMELIVE_SALES, True)
        EMailUtilities.DequeueEmail()

    End Sub

    Public Function GetPreparedNameValueForDownload(ByVal LTCustomer As TimeLiveDataSet.LTCustomerRow) As StringDictionary


        Dim dict As New StringDictionary

        dict.Add("[FirstName]", LTCustomer.FirstName)
        dict.Add("[LastName]", LTCustomer.LastName)
        Return dict

    End Function


End Class
