Imports Microsoft.VisualBasic
Imports TimeLiveDataSetTableAdapters
<System.ComponentModel.DataObject()> _
Public Class LTCustomerPaymentBLL

    Private _LTCustomerPaymentTableAdapter As LTCustomerPaymentTableAdapter = Nothing
    Protected ReadOnly Property Adapter() As LTCustomerPaymentTableAdapter
        Get
            If _LTCustomerPaymentTableAdapter Is Nothing Then
                _LTCustomerPaymentTableAdapter = New LTCustomerPaymentTableAdapter()
            End If

            Return _LTCustomerPaymentTableAdapter
        End Get
    End Property
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetLTCustomerPayments() As TimeLiveDataSet.LTCustomerPaymentDataTable
        Return Adapter.GetData
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetLTCustomerPaymentsByOrderNumber(ByVal OrderNumber As String) As TimeLiveDataSet.LTCustomerPaymentDataTable
        Return Adapter.GetDataByOrderNumber(OrderNumber)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, True)> _
    Public Function AddLTCustomerPaymentForNewAccount( _
                    ByVal HostedAccountId As System.Nullable(Of Integer), _
                    ByVal CustomerId As System.Nullable(Of Integer), _
                    ByVal TimeStamp As Date, _
                    ByVal OrderNumber As String, _
                    ByVal OrderDate As Date, _
                    ByVal Status As String, _
                    ByVal OrderAmount As Integer, _
                    ByVal FirstName As String, _
                    ByVal LastName As String, _
                    ByVal Address1 As String, _
                    ByVal Address2 As String, _
                    ByVal City As String, _
                    ByVal State As String, _
                    ByVal Country As String, _
                    ByVal PostalCode As String, _
                    ByVal Phone As String, _
                    ByVal SerialNumber As String, _
                    ByVal Quantity As System.Nullable(Of Integer), _
                    ByVal Price As System.Nullable(Of Integer))


        _LTCustomerPaymentTableAdapter = New LTCustomerPaymentTableAdapter

        Dim LTCustomerPayments As New TimeLiveDataSet.LTCustomerPaymentDataTable
        Dim LTCustomerPayment As TimeLiveDataSet.LTCustomerPaymentRow = LTCustomerPayments.NewLTCustomerPaymentRow

        With LTCustomerPayment
            .HostedAccountId = CType(New LTCustomerBLL().GetLTCustomerByCustomerId(CustomerId).Rows(0), TimeLiveDataSet.LTCustomerRow).AccountId
            .CustomerId = CustomerId
            .OrderNumber = OrderNumber
            .OrderDate = OrderDate
            .OrderAmount = OrderAmount
            .Status = Status
            .TimeStamp = Now
            .FirstName = FirstName
            .LastName = LastName
            .Address1 = Address1
            .Address2 = Address2
            .City = City
            .State = State
            .Country = Country
            .PostalCode = PostalCode
            .Phone = Phone
            .SerialNumber = SerialNumber
            .Price = Price
            .Quantity = Quantity
            .PackageTypeId = ShoppingCart.GetPackageTypeId(SerialNumber)


        End With

        LTCustomerPayments.AddLTCustomerPaymentRow(LTCustomerPayment)


        ' Add the new product
        Dim rowsAffected As Integer = Adapter.Update(LTCustomerPayments)

        If LTCustomerPayment.HostedAccountId > 0 Then
            Dim returnValue As Boolean = New AccountBLL().UpdateAccountPayment(SerialNumber, Quantity, LTCustomerPayment.HostedAccountId)
        End If

        ' Return true if precisely one row was inserted, otherwise false
        Return rowsAffected = 1

    End Function



End Class
