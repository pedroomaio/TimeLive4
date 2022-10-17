
Partial Class LoginDetail
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Dim LoginCollectionKeys As ArrayList
        If Not System.Web.HttpRuntime.Cache("LoginCollectionKeys") Is Nothing Then
            LoginCollectionKeys = System.Web.HttpRuntime.Cache("LoginCollectionKeys")
            For i As Integer = 0 To LoginCollectionKeys.Count - 1
                Dim username As String = TextBox1.Text & LoginCollectionKeys(i) & vbCrLf
                Me.TextBox1.Text = username
            Next
            Me.Label3.Text = LoginCollectionKeys.Count
            If LoginCollectionKeys.Count = 0 Then
                Me.TextBox1.Text = "No data"
            End If
        Else
            Me.TextBox1.Text = "No data"
            Me.Label3.Text = 0
        End If
    End Sub
End Class
