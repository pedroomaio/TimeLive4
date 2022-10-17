<%@ Page Language="VB" MasterPageFile="~/Masters/MasterPageEmployee.master" AutoEventWireup="false" CodeFile="AccountProjectTaskComments.aspx.vb" Inherits="Employee_AccountProjectTaskComments" title="TimeLive - Task Open" %>

<%@ Register Src="Controls/ctlAccountEmployeeTimeEntryDayView.ascx" TagName="ctlAccountEmployeeTimeEntryDayView"
    TagPrefix="uc1" %>
<%@ Register Src="Controls/ctlAccountProjectTaskCommentsList.ascx" TagName="ctlAccountProjectTaskCommentsList"
    TagPrefix="uc2" %>

<asp:Content ID="C" ContentPlaceHolderID="C" Runat="Server">
    <uc2:ctlAccountProjectTaskCommentsList id="CtlAccountProjectTaskCommentsList1" runat="server">
    </uc2:ctlAccountProjectTaskCommentsList>
</asp:Content>

