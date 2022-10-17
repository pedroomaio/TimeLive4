<%@ Page Language="VB" MasterPageFile="~/Masters/MasterPageEmployee.master" AutoEventWireup="false" CodeFile="frmAccountEmployeeTimeEntryDayView.aspx.vb" Inherits="Employee_frmAccountEmployeeTimeEntryDayView" title="TimeLive - Time Entry Day View" %>

<%@ Register Src="Controls/ctlAccountEmployeeTimeEntryDayView.ascx" TagName="ctlAccountEmployeeTimeEntryDayView"
    TagPrefix="uc1" %>
<asp:Content Content ID="C" ContentPlaceHolderID="C" Runat="Server">
    <uc1:ctlAccountEmployeeTimeEntryDayView ID="CtlAccountEmployeeTimeEntryDayView1"
        runat="server" />

</asp:Content>

