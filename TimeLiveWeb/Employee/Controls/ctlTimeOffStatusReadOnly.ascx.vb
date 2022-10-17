Imports System.Globalization

Partial Class Employee_Controls_ctlTimeOffStatusReadOnly
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Me.Request.QueryString("AccountEmployee") IsNot Nothing Then
            GridView1.DataSourceID = "dsTimeOffStatusGridViewObjectQueryString"
        Else
            GridView1.DataSourceID = "dsTimeOffStatusGridViewObject"
        End If

    End Sub
    Public Function ConvertFromHexToColor(hex As String) As Color
        Dim colorcode As String = hex
        Dim argb As Integer = Int32.Parse(colorcode.Replace("#", ""), NumberStyles.HexNumber)
        Dim clr As Color = Color.FromArgb(argb)
        Return clr
    End Function

    Public Function ConvertFromBoolToString(bool As Boolean) As String
        If bool = True Then
            Return "Y"
        Else Return "N"
        End If 
    End Function

End Class
