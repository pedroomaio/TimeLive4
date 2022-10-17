Imports Microsoft.VisualBasic
Partial Class AccountAdmin_Controls_ctlAccountHolidaySelect
    Inherits System.Web.UI.UserControl
    Dim HolidaySheet As New AccountHolidayTypeBLL
    ''' <summary>
    ''' pageload event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        btnAdd.Enabled = AccountPagePermissionBLL.IsPageHasPermissionOf(149, 2)
    End Sub
    ''' <summary>
    ''' insert rows
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim row As GridViewRow
        For Each row In Me.GridView1.Rows
            If CType(row.FindControl("chkSelected"), CheckBox).Checked = True Then
                Dim MasterHolidayTypeId = Me.GridView1.DataKeys(row.RowIndex)(0)
                Me.CheckExistingRecord(row, MasterHolidayTypeId)
            Else
                Dim MasterHolidayTypeId = Me.GridView1.DataKeys(row.RowIndex)(0)
                Dim dtMasterHoliday As AccountHolidayType.AccountHolidayTypeDataTable = New AccountHolidayTypeBLL().GetAccountHolidayTypeByAccountIdandMasterHolidayTypeId(DBUtilities.GetSessionAccountId, MasterHolidayTypeId)
                Dim drMasterHoliday As AccountHolidayType.AccountHolidayTypeRow
                If dtMasterHoliday.Rows.Count > 0 Then
                    drMasterHoliday = dtMasterHoliday.Rows(0)
                    HolidaySheet.DeleteAccountHolidayType(drMasterHoliday.AccountHolidayTypeId)
                End If
            End If
        Next
        Response.Redirect("~/AccountAdmin/AdminMain.aspx", False)
    End Sub
    ''' <summary>
    ''' select rows insert
    ''' </summary>
    ''' <param name="row"></param>
    ''' <remarks></remarks>
    Public Sub InsertHolidaySelect(ByVal row As GridViewRow)
        With dsHolidaySelectObject
            .InsertParameters("AccountId").DefaultValue = DBUtilities.GetSessionAccountId
            Dim MasterHolidayTypeId = Me.GridView1.DataKeys(row.RowIndex)(0)
            .InsertParameters("MasterHolidayTypeId").DefaultValue = Convert.ToString(MasterHolidayTypeId)
            .InsertParameters("HolidayType").DefaultValue = Me.GridView1.DataKeys(row.RowIndex)(1)
            .Insert()
            Me.InsertHolidayTypeDetail(MasterHolidayTypeId)
        End With
    End Sub
    ''' <summary>
    ''' insert holiday type detail rows
    ''' </summary>
    ''' <param name="MasterHolidayTypeId"></param>
    ''' <remarks></remarks>
    Public Sub InsertHolidayTypeDetail(ByVal MasterHolidayTypeId As Guid)
        Dim dtMasterHolidayDetail As AccountHolidayType.MasterHolidayTypeDetailDataTable = New AccountHolidayTypeBLL().GetMasterHolidayTypeDetailByMasterHolidayTypeId(MasterHolidayTypeId)
        Dim drMasterHolidayDetail As AccountHolidayType.MasterHolidayTypeDetailRow
        If dtMasterHolidayDetail.Rows.Count > 0 Then
            drMasterHolidayDetail = dtMasterHolidayDetail.Rows(0)
            For Each drMasterHolidayDetail In dtMasterHolidayDetail.Rows
                Dim HolidayDate As New Date(Today.Year, drMasterHolidayDetail.HolidayMonth, drMasterHolidayDetail.HolidayDay, Today.Hour, Today.Minute, Today.Second)
                HolidaySheet.AddAccountHolidayTypeDetailSelect(HolidaySheet.GetLastInsertedId, DBUtilities.GetSessionAccountId, drMasterHolidayDetail.MasterHolidayTypeDetailId, drMasterHolidayDetail.HolidayName, HolidayDate, Now.Date, DBUtilities.GetSessionAccountEmployeeId, Now.Date, DBUtilities.GetSessionAccountEmployeeId)
            Next
        End If
    End Sub
    ''' <summary>
    ''' inserting events
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub dsHolidaySelectObject_Inserting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceMethodEventArgs) Handles dsHolidaySelectObject.Inserting
        DBUtilities.SetRowForInserting(e)
    End Sub
    ''' <summary>
    ''' row data bound events
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then

        End If
    End Sub
    ''' <summary>
    ''' gridview data bound events
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub GridView1_DataBound(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim row As GridViewRow
        For Each row In Me.GridView1.Rows
            Dim dtMasterHoliday As AccountHolidayType.AccountHolidayTypeDataTable = New AccountHolidayTypeBLL().GetAccountHolidayTypeByAccountIdandMasterHolidayTypeId(DBUtilities.GetSessionAccountId, Me.GridView1.DataKeys(row.RowIndex).Item(0))
            Dim drMasterHoliday As AccountHolidayType.AccountHolidayTypeRow
            If dtMasterHoliday.Rows.Count > 0 Then
                drMasterHoliday = dtMasterHoliday.Rows(0)
                CType(row.Cells(1).FindControl("chkSelected"), CheckBox).Checked = True
            Else
                CType(row.Cells(1).FindControl("chkSelected"), CheckBox).Checked = False
            End If
        Next
    End Sub
    ''' <summary>
    ''' control check and delete existing records
    ''' </summary>
    ''' <param name="row"></param>
    ''' <param name="MasterHolidayTypeId"></param>
    ''' <remarks></remarks>
    Private Sub CheckExistingRecord(ByVal row As GridViewRow, ByVal MasterHolidayTypeId As Guid)
        Dim dtMasterHoliday As AccountHolidayType.AccountHolidayTypeDataTable = New AccountHolidayTypeBLL().GetAccountHolidayTypeByAccountIdandMasterHolidayTypeId(DBUtilities.GetSessionAccountId, MasterHolidayTypeId)
        Dim drMasterHoliday As AccountHolidayType.AccountHolidayTypeRow
        If dtMasterHoliday.Rows.Count > 0 Then
            drMasterHoliday = dtMasterHoliday.Rows(0)
            'HolidaySheet.DeleteAccountHolidayTypeDetailByAccountHolidayTypeId(drMasterHoliday.AccountHolidayTypeId)
            HolidaySheet.DeleteAccountHolidayType(drMasterHoliday.AccountHolidayTypeId)
            Me.InsertHolidaySelect(row)
        Else
            Me.InsertHolidaySelect(row)
        End If
    End Sub
End Class
