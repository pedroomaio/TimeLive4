
Partial Class Orders_SubmitPaymentRequest
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ShoppingCart.PostPurchaseRequest(Request.QueryString("Mode"), _
                Request.QueryString("CustomerId"), _
                Request.QueryString("Quantity"), _
                Request.QueryString("AccountName"), _
                Request.QueryString("FirstName"), _
                Request.QueryString("LastName"), _
                Request.QueryString("Address1"), _
                Request.QueryString("Address2"), _
                Request.QueryString("City"), _
                Request.QueryString("State"), _
                Request.QueryString("Country"), _
                Request.QueryString("EMailAddress"), _
                Request.QueryString("Telephone"), _
                Request.QueryString("ZipCode") _
                )
    End Sub
End Class
