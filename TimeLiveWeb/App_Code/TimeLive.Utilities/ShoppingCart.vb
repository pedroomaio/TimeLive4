Imports Microsoft.VisualBasic

Public Class ShoppingCart

    Public Const TIME_LIVE_HOSTED_BASIC_SHOPPING_CART_URL = "https://store5.esellerate.net/store/checkout/CustomLayout.aspx?s=STR6521630860&pc=5hS4gjrE&page=OnePageCart.htm"
    Public Const POST_TO_PAYMENT_URL = "https://secure.esellerate.net/secure/prefill.aspx"

    Public Shared Function GetShoppingCartURL(ByVal PackageType As String)

        If PackageType = "5" Then
            Return TIME_LIVE_HOSTED_BASIC_SHOPPING_CART_URL
        Else
            Return TIME_LIVE_HOSTED_BASIC_SHOPPING_CART_URL
        End If

    End Function


    Public Shared Sub PostPurchaseRequest(ByVal PackageTypeId As Short, _
    ByVal CustomerId As Integer, _
        ByVal Quantity As Integer, _
        ByVal BillingCompany As String, _
        ByVal BillingFirstName As String, _
        ByVal BillingLastName As String, _
        ByVal BillingAddress1 As String, _
        ByVal BillingAddress2 As String, _
        ByVal BillingCity As String, _
        ByVal BillingState As String, _
        ByVal BillingCountry As String, _
        ByVal BillingEMail As String, _
        ByVal BillingPhone As String, _
        ByVal BillingZip As String _
        )

        Dim drPackageType As TimeLiveDataSet.SystemPackageTypeRow
        drPackageType = New SystemDataBLL().GetPackageTypeByPackageTypeId(PackageTypeId)


        Dim myremotepost As RemotePost = New RemotePost
        myremotepost.Url = POST_TO_PAYMENT_URL

        myremotepost.Add("s", drPackageType.StoreCode)
        If Not System.Configuration.ConfigurationManager.AppSettings("StorePreviewKey") Is Nothing Then
            If Not System.Configuration.ConfigurationManager.AppSettings("StorePreviewKey") = "" Then

                myremotepost.Add("pc", System.Configuration.ConfigurationManager.AppSettings("StorePreviewKey"))

            End If
        End If
        myremotepost.Add("cmd", "BUY")

        myremotepost.Add("_cartitem0.skurefnum", drPackageType.SKUReference)
        myremotepost.Add("_cartitem0.quantity", Quantity)

        myremotepost.Add("_Shopper.BillingCompany", BillingCompany)
        myremotepost.Add("_Shopper.BillingFirstName", BillingFirstName)
        myremotepost.Add("_Shopper.BillingLastName", BillingLastName)

        myremotepost.Add("_Shopper.BillingAddress1", BillingAddress1)
        myremotepost.Add("_Shopper.BillingAddress2", BillingAddress2)
        myremotepost.Add("_Shopper.BillingCity", BillingCity)
        myremotepost.Add("_Shopper.BillingState", BillingState)
        myremotepost.Add("_Shopper.BillingCountry", BillingCountry)
        myremotepost.Add("_Shopper.BillingEmail", BillingEMail)
        myremotepost.Add("_Shopper.BillingEmailRetype", BillingEMail)
        myremotepost.Add("_Shopper.BillingPhone", BillingPhone)
        myremotepost.Add("_Shopper.BillingZip", BillingZip)
        myremotepost.Add("_Custom.Data0", CustomerId)

        myremotepost.Post()

    End Sub
    Public Shared Sub SubmitPaymentRequest(ByVal PackageTypeId As Short, _
    ByVal CustomerId As Integer, _
        ByVal Quantity As Integer, _
        ByVal BillingCompany As String, _
        ByVal BillingFirstName As String, _
        ByVal BillingLastName As String, _
        ByVal BillingAddress1 As String, _
        ByVal BillingAddress2 As String, _
        ByVal BillingCity As String, _
        ByVal BillingState As String, _
        ByVal BillingCountry As String, _
        ByVal BillingEMail As String, _
        ByVal BillingPhone As String, _
        ByVal BillingZip As String)

        Dim url As String = "http:\\www.livetecs.com\Home\SubmitPaymentRequest.aspx?Mode=" & PackageTypeId & "&Quantity=1&CustomerId=" & CustomerId & "&AccountName=" & BillingCompany & "&FirstName=" & BillingFirstName & "&LastName=" & BillingLastName & "&Address1=" & BillingAddress1 & "&Address2=" & BillingAddress2 & "&City=" & BillingCity & "&State=" & BillingState & "&Country=" & BillingCountry & "&EMailAddress=" & BillingEMail & "&Telephone=" & BillingPhone & "&ZipCode=" & BillingZip
        System.Web.HttpContext.Current.Response.Redirect(url, False)

    End Sub

    Public Shared Sub OldPostToPaymentSiteOld()
        Dim myremotepost As RemotePost = New RemotePost
        myremotepost.Url = POST_TO_PAYMENT_URL

        myremotepost.Add("s", "STR6521630860")
        myremotepost.Add("pc", "DPH8oP7T")
        myremotepost.Add("cmd", "BUY")

        myremotepost.Add("_cartitem0.skurefnum", "SKU38643965858")
        myremotepost.Add("pc", "DPH8oP7T")
        myremotepost.Add("_cartitem0.quantity", "1")

        myremotepost.Add("_Shopper.BillingCompany", "Vaporware Inc.")
        myremotepost.Add("_Shopper.BillingFirstName", "John")
        myremotepost.Add("_Shopper.BillingLastName", "Doe")

        myremotepost.Add("_Shopper.BillingAddress1", "Vaporware Inc.")
        myremotepost.Add("_Shopper.BillingAddress2", "John")
        myremotepost.Add("_Shopper.BillingCity", "Doe")
        myremotepost.Add("_Shopper.BillingState", "Vaporware Inc.")
        myremotepost.Add("_Shopper.BillingCountry", "John")
        myremotepost.Add("_Shopper.BillingEmail", "Doe")
        myremotepost.Add("_Shopper.BillingEmailRetype", "Doe")
        myremotepost.Add("_Shopper.BillingPhone", "Doe")
        myremotepost.Add("_Shopper.BillingZip", "Doe")
        myremotepost.Add("_Shopper.BillingPhone", "Doe")
        myremotepost.Add("_Custom.Data0", "Doe")

        myremotepost.Post()
    End Sub

    Public Shared Function GetPackageTypeId(ByVal SerialNumber As String) As Short
        If SerialNumber.Substring(0, 4) = "TLHB" Then
            Return 5
        ElseIf SerialNumber.Substring(0, 4) = "TLHS" Then
            Return 10
        ElseIf SerialNumber.Substring(0, 4) = "TLHE" Then
            Return 15
        ElseIf SerialNumber.Substring(0, 4) = "TLIE" Then
            Return 20
        Else
            Return 0
        End If
    End Function


End Class

