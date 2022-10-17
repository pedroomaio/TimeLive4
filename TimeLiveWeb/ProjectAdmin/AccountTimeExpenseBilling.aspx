<%@ Page Language="VB" MasterPageFile="~/Masters/MasterPageEmployee.master" AutoEventWireup="false" CodeFile="AccountTimeExpenseBilling.aspx.vb" Inherits="ProjectAdmin_AccountTimeExpenseBilling" title="TimeLive - Time Expense Billing" %>

<%@ Register Src="Controls/ctlAccountTimeExpenseBilling.ascx" TagName="ctlAccountTimeExpenseBilling"
    TagPrefix="uc1" %>
<asp:Content Content ID="C" ContentPlaceHolderID="C" Runat="Server">
    <uc1:ctlAccountTimeExpenseBilling ID="ctlAccountTimeExpenseBilling" runat="server" />
</asp:Content>


