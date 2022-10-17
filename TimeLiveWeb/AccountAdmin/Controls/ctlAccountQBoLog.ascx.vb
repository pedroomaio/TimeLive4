Imports System.Data
Imports System.Data.SqlClient
Partial Class AccountAdmin_Controls_ctlAccountQBoLog
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        'Me.objTicketAuditLog.SelectParameters("TicketMasterId").DefaultValue = "32095b48-1514-4afe-8659-015cec790a09"
        'Create the connection and DataAdapter for the Authors table.
        Dim cnn As New SqlConnection(DBUtilities.GetConnectionString)
        Dim cmd1 As New SqlDataAdapter("select  executeddate as linkbutton, * from AccountQBOnlineLog Where AccountId = '" & DBUtilities.GetSessionAccountId & "' order by executeddate DESC ", cnn)


        'Create and fill the DataSet.
        Dim ds As New DataSet()
        cmd1.Fill(ds, "AccountQBOnlineLog")


        'Create a second DataAdapter for the Titles table.
        Dim cmd2 As New SqlDataAdapter("select EntityName as hypRDLHeader, EntityName from AccountQBOnlineLog Where AccountId = '" & DBUtilities.GetSessionAccountId & "' GROUP BY EntityName ", cnn)
        cmd2.Fill(ds, "AccountQBOnlineLogR")


        ' ''Create the relation bewtween the Authors and Titles tables.
        ds.Relations.Add("myrelation", ds.Tables("AccountQBOnlineLogR").Columns("EntityName"), ds.Tables("AccountQBOnlineLog").Columns("EntityName"), False)


        'Bind the Authors table to the parent Repeater control, and call DataBind.
        RDL.DataSource = ds.Tables("AccountQBOnlineLogR")

        RDL.DataBind()

        'Close the connection.
        cnn.Close()
    End Sub

    Protected Sub RDL_DataBinding(sender As Object, e As System.EventArgs) Handles RDL.DataBinding

    End Sub

    Protected Sub RDL_ItemCommand(source As Object, e As System.Web.UI.WebControls.DataListCommandEventArgs) Handles RDL.ItemCommand

    End Sub
    Protected Sub RDL_ItemDataBound(sender As Object, e As System.Web.UI.WebControls.DataListItemEventArgs) Handles RDL.ItemDataBound
        If Not DataBinder.Eval(e.Item.DataItem, "hypRDLHeader") Is Nothing Then
            If Not IsDBNull(DataBinder.Eval(e.Item.DataItem, "hypRDLHeader")) Then
                CType(e.Item.FindControl("hypRDLHeader"), HtmlAnchor).InnerText = DataBinder.Eval(e.Item.DataItem, "hypRDLHeader")
            End If
        End If
    End Sub
    Protected Sub DataList2_ItemDataBound(sender As Object, e As System.Web.UI.WebControls.DataListItemEventArgs) Handles RDL.ItemDataBound
        'If Not DataBinder.Eval(e.Item.DataItem, "executeddate") Is Nothing Then
        '        'CType(e.Item.FindControl("lnkexecuteddate"), HtmlGenericControl).InnerText = DataBinder.Eval(e.Item.DataItem, "executeddate")
        'End If
        '        CType(e.Item.FindControl("RDL1").FindControl("lnkexecuteddate"), HtmlGenericControl).InnerText = DataBinder.Eval(e.Item.DataItem, "executeddate")
    End Sub
    'Protected Sub btnAssySn_Click(sender As Object, e As System.EventArgs) Handles btnAssySn.Click
    '    'Me.objTicketAuditLog.SelectParameters("TicketMasterId").DefaultValue = "32095b48-1514-4afe-8659-015cec790a09"
    '    'Create the connection and DataAdapter for the Authors table.
    '    If Session.Item("groupentityname") = "1" Then

    '        Dim GroupBy As String = btnAssySn.CommandArgument
    '        Dim cnn As New SqlConnection(DBUtilities.GetConnectionString)
    '        Dim cmd1 As New SqlDataAdapter("select entityname as linkbutton, * from AccountQBOnlineLog Where AccountId = '" & DBUtilities.GetSessionAccountId & "' order by executeddate DESC ", cnn)


    '        'Create and fill the DataSet.
    '        Dim ds As New DataSet()
    '        cmd1.Fill(ds, "AccountQBOnlineLog")


    '        'Create a second DataAdapter for the Titles table.
    '        Dim cmd2 As New SqlDataAdapter("select executeddate, executeddate as hypRDLHeader from AccountQBOnlineLog Where AccountId = '" & DBUtilities.GetSessionAccountId & "' GROUP BY executeddate order by executeddate DESC ", cnn)
    '        cmd2.Fill(ds, "AccountQBOnlineLogR")


    '        ' ''Create the relation bewtween the Authors and Titles tables.
    '        ds.Relations.Add("myrelation", ds.Tables("AccountQBOnlineLogR").Columns("executeddate"), ds.Tables("AccountQBOnlineLog").Columns("executeddate"), False)


    '        'Bind the Authors table to the parent Repeater control, and call DataBind.
    '        RDL.DataSource = ds.Tables("AccountQBOnlineLogR")
    '        RDL.DataBind()

    '        'Close the connection.
    '        cnn.Close()
    '        Session.Item("groupentityname") = "0"
    '    Else
    '        'Me.objTicketAuditLog.SelectParameters("TicketMasterId").DefaultValue = "32095b48-1514-4afe-8659-015cec790a09"
    '        'Create the connection and DataAdapter for the Authors table.
    '        Dim cnn As New SqlConnection(DBUtilities.GetConnectionString)
    '        Dim cmd1 As New SqlDataAdapter("select  executeddate as linkbutton, * from AccountQBOnlineLog Where AccountId = '" & DBUtilities.GetSessionAccountId & "' order by executeddate DESC ", cnn)


    '        'Create and fill the DataSet.
    '        Dim ds As New DataSet()
    '        cmd1.Fill(ds, "AccountQBOnlineLog")


    '        'Create a second DataAdapter for the Titles table.
    '        Dim cmd2 As New SqlDataAdapter("select EntityName as hypRDLHeader, EntityName from AccountQBOnlineLog Where AccountId = '" & DBUtilities.GetSessionAccountId & "' GROUP BY EntityName ", cnn)
    '        cmd2.Fill(ds, "AccountQBOnlineLogR")


    '        ' ''Create the relation bewtween the Authors and Titles tables.
    '        ds.Relations.Add("myrelation", ds.Tables("AccountQBOnlineLogR").Columns("EntityName"), ds.Tables("AccountQBOnlineLog").Columns("EntityName"), False)


    '        'Bind the Authors table to the parent Repeater control, and call DataBind.
    '        RDL.DataSource = ds.Tables("AccountQBOnlineLogR")

    '        RDL.DataBind()

    '        'Close the connection.
    '        cnn.Close()
    '        Session.Item("groupentityname") = "1"
    '    End If

    'End Sub
End Class
