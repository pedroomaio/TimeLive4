<%@ Page Language="VB" MasterPageFile="~/Masters/MasterPageMobileEmployee.master" AutoEventWireup="false" CodeFile="AccountEmployeeTimeEntryPeriodView.aspx.vb" Inherits="Mobile_AccountEmployeeTimeEntryPeriodView" title="Period View" %>

<%@ Register Src="Controls/ctlAccountEmployeeTimeEntryPeriodViewList.ascx" TagName="ctlAccountEmployeeTimeEntryPeriodViewList"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:ctlAccountEmployeeTimeEntryPeriodViewList ID="CtlAccountEmployeeTimeEntryPeriodViewList1"
        runat="server" />
</asp:Content>

