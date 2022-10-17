Namespace TimeLive

    Partial Class ctlCustomerForm
        Inherits System.Web.UI.UserControl

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region
        Dim lblExceptionText As Label


        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            If Not Me.IsPostBack Then
                If Me.FormView1.CurrentMode = FormViewMode.Insert Then
                    CType(Me.FormView1.FindControl("ddlCountryId"), DropDownList).SelectedValue = DBUtilities.GetAccountCountryId
                    CType(Me.FormView1.FindControl("ddlCustomerRequestTypeId"), DropDownList).SelectedValue = Me.Request.QueryString("CustomerRequestTypeId")
                End If
            End If

        End Sub

        Protected Sub FormView1_ItemInserted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.FormViewInsertedEventArgs) Handles FormView1.ItemInserted
        End Sub

        Protected Sub FormView1_ItemUpdated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.FormViewUpdatedEventArgs) Handles FormView1.ItemUpdated
        End Sub

        Protected Sub dsTimeZone_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs)

        End Sub
    End Class

End Namespace
