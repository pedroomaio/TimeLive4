Imports Microsoft.VisualBasic
''' <summary>
''' Controls for holiday types
''' </summary>
''' <remarks></remarks>
Partial Class Controls_ctlAccountHolidayTypes
    Inherits System.Web.UI.UserControl
    ''' <summary>
    ''' page load
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    ''' <summary>
    ''' controls gridview row command
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs)
        If e.CommandName = "Select" Then
            Me.FormView1.ChangeMode(FormViewMode.Edit)
        End If
    End Sub
    ''' <summary>
    ''' Control form view item command
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub FormView1_ItemCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.FormViewCommandEventArgs)
        If e.CommandName = "Cancel" Then
            Me.FormView1.ChangeMode(FormViewMode.Insert)
            Me.FormView1.DataBind()
        End If
    End Sub
    ''' <summary>
    ''' Control row deleted event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub GridView1_RowDeleted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeletedEventArgs)
        UIUtilities.OnDeleteException(e)
        UIUtilities.AfterGridViewRowDelete(Me.FormView1)
    End Sub
    ''' <summary>
    ''' row deleting event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs)
        Call New AccountHolidayTypeBLL().DeleteAccountHolidayType(Me.GridView1.DataKeys(e.RowIndex)("AccountHolidayTypeId"))
        e.Cancel = True
        Me.GridView1.DataBind()
    End Sub
    ''' <summary>
    ''' controls insrted event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub dsAccountHolidayTypeFormObject_Inserted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs)
        DBUtilities.AfterInsert(Me.GridView1)
    End Sub
    ''' <summary>
    ''' updating rows
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub dsAccountHolidayTypeFormObject_Updating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceMethodEventArgs)
        DBUtilities.SetRowForUpdating(e)
        'If Not IsDBNull(Me.FormView1.DataKey("MasterHolidayTypeId")) Then
        '    '    Dim nMasterHolidayTypeId As Guid = Me.FormView1.DataItem("MasterHolidayTypeId")
        '    '    dsAccountHolidayTypeFormObject.UpdateParameters("Original_MasterHolidayTypeId").DefaultValue = nMasterHolidayTypeId.ToString
        'Else
        '    '    Dim OMaster = ""
        '    dsAccountHolidayTypeFormObject.UpdateParameters("Original_MasterHolidayTypeId").DefaultValue = System.Guid.Empty.ToString
        'End If

    End Sub
    ''' <summary>
    ''' form object updated event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub dsAccountHolidayTypeFormObject_Updated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs)
        DBUtilities.AfterUpdate(Me.GridView1)
    End Sub
    ''' <summary>
    ''' form object inserted event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub dsAccountHolidayTypeFormObject_Inserting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceMethodEventArgs) Handles dsAccountHolidayTypeFormObject.Inserting
        DBUtilities.SetRowForInserting(e)
    End Sub
    ''' <summary>
    ''' controls form view data bound event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub FormView1_DataBound(ByVal sender As Object, ByVal e As System.EventArgs)
        AccountPagePermissionBLL.SetPagePermission(147, Me.GridView1, Me.FormView1, "btnAdd", 2, 3)
    End Sub
End Class
