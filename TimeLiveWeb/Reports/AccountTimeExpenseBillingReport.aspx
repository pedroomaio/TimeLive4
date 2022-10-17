<%@ Page Language="VB" MasterPageFile="~/Masters/MasterPageEmployee.master" AutoEventWireup="false" CodeFile="AccountTimeExpenseBillingReport.aspx.vb" Inherits="Reports_AccountTimeExpenseBillingReport" title="TimeLive - Account Time Expense Billing Report" %>
<%@ Register Src="ControlsViewer/AccountTimeExpenseBillingReport.ascx" TagName="AccountTimeExpenseBillingReport"
    TagPrefix="uc1" %>
<asp:Content Content ID="C" ContentPlaceHolderID="C" Runat="Server">
    <uc1:AccountTimeExpenseBillingReport ID="AccountTimeExpenseBillingReport1" runat="server" />
</asp:Content>
