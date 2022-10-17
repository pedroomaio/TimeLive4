Imports Microsoft.VisualBasic
Partial Class AccountAdmin_Controls_ctlAccountHolidayTypeDetail
    Inherits System.Web.UI.UserControl
    Dim IsExistingRecord As Boolean = False
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.dsAccountHolidayTypeDetailObject.SelectParameters("Year").DefaultValue = Today.Year
        btnCopyHolidays.Attributes.Add("onclick", ResourceHelper.GetCopyMessageJavascriptForHolidayType)
        'Label5.Text = ResourceHelper.GetFromResource("Holiday Year:")
        '   Dim accountsessionid = DBUtilities.GetSessionAccountHolidayTypeId
    End Sub
    Protected Sub FormView1_ItemCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.FormViewCommandEventArgs)
        If e.CommandName = "Cancel" Then
            Me.FormView1.ChangeMode(FormViewMode.Insert)
            Me.FormView1.DataBind()
        End If
    End Sub
    Protected Sub FormView1_DataBound(ByVal sender As Object, ByVal e As System.EventArgs)
        AccountPagePermissionBLL.SetPagePermission(148, Me.GridView1, Me.FormView1, "btnAdd", 3, 4)
        If Me.FormView1.CurrentMode = FormViewMode.Insert Then
            CType(Me.FormView1.FindControl("HolidayDate"), eWorld.UI.CalendarPopup).SelectedDate = LocaleUtilitiesBLL.GetCurrentDateTimeFromUserTimeZone
        End If
    End Sub
    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs)
        If e.CommandName = "Select" Then
            Me.FormView1.ChangeMode(FormViewMode.Edit)
        End If
    End Sub
    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs)
        Call New AccountHolidayTypeBLL().DeleteAccountHolidayTypeDetail(Me.GridView1.DataKeys(e.RowIndex)("AccountHolidayTypeDetailId"))
        e.Cancel = True
        Me.GridView1.DataBind()
    End Sub
    Protected Sub GridView1_RowDeleted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeletedEventArgs)
        UIUtilities.OnDeleteException(e)
        UIUtilities.AfterGridViewRowDelete(Me.FormView1)
    End Sub
    Protected Sub dsAccountHolidayTypeDetailFormViewObject_Inserting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceMethodEventArgs)
        DBUtilities.SetRowForInserting(e)
    End Sub
    Protected Sub dsAccountHolidayTypeDetailFormViewObject_Inserted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs)
        DBUtilities.AfterInsert(Me.GridView1)
    End Sub
    Protected Sub dsAccountHolidayTypeDetailFormViewObject_Updated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs)
        DBUtilities.AfterUpdate(Me.GridView1)
    End Sub
    Protected Sub dsAccountHolidayTypeDetailFormViewObject_Updating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceMethodEventArgs) Handles dsAccountHolidayTypeDetailFormViewObject.Updating
        DBUtilities.SetRowForUpdating(e)
    End Sub
    ''' <summary>
    ''' insert holiday type detail rows
    ''' </summary>
    ''' <param name="MasterHolidayTypeId"></param>
    ''' <remarks></remarks>
    Public Sub InsertHolidayTypeDetail(ByVal AccountId As Integer, ByVal AccountHolidayTypeId As Guid, ByVal Year As String)
        Dim Holidaysheet As New AccountHolidayTypeBLL
        Dim NextYear As String
        Dim NYear = Year + 1
        NextYear = Replace(NYear, ".0", "")

        Me.IsCheckCopyYearRecord(AccountId, AccountHolidayTypeId, NextYear)

        Dim dtHolidayTypeDetail As AccountHolidayType.vueAccountHolidayTypeDetailDataTable = Holidaysheet.GetvueAccountHolidayTypeDetailByAccountHolidayTypeIdandHolidayYear(AccountId, AccountHolidayTypeId, Year)
        Dim drHolidayTypeDetail As AccountHolidayType.vueAccountHolidayTypeDetailRow
        If dtHolidayTypeDetail.Rows.Count > 0 Then
            drHolidayTypeDetail = dtHolidayTypeDetail.Rows(0)
            For Each drHolidayTypeDetail In dtHolidayTypeDetail.Rows
                Dim HolidayDate As New Date(Replace(NextYear, ".0", ""), drHolidayTypeDetail.HolidayDate.Month, drHolidayTypeDetail.HolidayDate.Day, Today.Hour, Today.Minute, Today.Second)
                Holidaysheet.AddAccountHolidayTypeDetail(AccountHolidayTypeId, AccountId, drHolidayTypeDetail.HolidayName, HolidayDate, Now.Date, DBUtilities.GetSessionAccountEmployeeId, Now.Date, DBUtilities.GetSessionAccountEmployeeId)
            Next
            Response.Redirect("~/AccountAdmin/AccountHolidayTypeDetail.aspx?AccountHolidayTypeId=" & AccountHolidayTypeId.ToString)
        End If
    End Sub
    Protected Sub btnCopyHolidays_Click(sender As Object, e As System.EventArgs) Handles btnCopyHolidays.Click
        Dim AccountHolidayTypeId As New Guid(Me.Request.QueryString("AccountHolidayTypeId"))
        Me.InsertHolidayTypeDetail(DBUtilities.GetSessionAccountId, AccountHolidayTypeId, ddlHolidayYear.SelectedValue)
    End Sub
    ''' <summary>
    ''' control check and delete existing records
    ''' </summary>
    ''' <param name="row"></param>
    ''' <param name="MasterHolidayTypeId"></param>
    ''' <remarks></remarks>
    Private Sub IsCheckCopyYearRecord(ByVal AccountId As Integer, ByVal AccountHolidayTypeId As Guid, ByVal NextYear As String)
        Dim Holidaysheet As New AccountHolidayTypeBLL
        Dim dtExistingHolidayTypeDetail As AccountHolidayType.AccountHolidayTypeDetailDataTable = Holidaysheet.GetAccountHolidayTypeDetailByAccountIdAccountHolidayTypeIdandHolidayYear(AccountId, AccountHolidayTypeId, NextYear)
        Dim drExistingHolidayTypeDetail As AccountHolidayType.AccountHolidayTypeDetailRow
        If dtExistingHolidayTypeDetail.Rows.Count > 0 Then
            drExistingHolidayTypeDetail = dtExistingHolidayTypeDetail.Rows(0)
            For Each drExistingHolidayTypeDetail In dtExistingHolidayTypeDetail.Rows
                Holidaysheet.DeleteAccountHolidayTypeDetail(drExistingHolidayTypeDetail.AccountHolidayTypeDetailId)
            Next
        End If
    End Sub
    Protected Sub dsAccountHolidayTypeDetailObject_Inserted(sender As Object, e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles dsAccountHolidayTypeDetailObject.Inserted
        Me.GridView1.DataBind()
    End Sub
End Class
