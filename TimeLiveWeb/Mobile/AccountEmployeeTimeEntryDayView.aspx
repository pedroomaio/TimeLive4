<%@ Page Language="VB" MasterPageFile="~/Masters/MasterPageMobileEmployee.master" AutoEventWireup="false" CodeFile="AccountEmployeeTimeEntryDayView.aspx.vb" Inherits="Mobile_AccountEmployeeTimeEntryDayView" Title ="Day View" %>
<%@ Register Src="Controls/ctlAccountEmployeeTimeEntryDayViewList.ascx" TagName="ctlAccountEmployeeTimeEntryDayViewList" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:ctlAccountEmployeeTimeEntryDayViewList ID="ctlAccountEmployeeTimeEntryDayViewList1" runat="server" />
</asp:Content>



 