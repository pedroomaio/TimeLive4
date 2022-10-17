<%@ Page Language="VB" MasterPageFile="~/Masters/MasterPageemployee.master" AutoEventWireup="false" CodeFile="AccountBillingRate.aspx.vb" Inherits="AccountAdmin_AccountBillingRate" title="TimeLive - Billing Rate" %>

<%@ Register Src="Controls/ctlAccountBillingRateList.ascx" TagName="ctlAccountBillingRateList"
    TagPrefix="uc1" %>
<asp:Content Content ID="C" ContentPlaceHolderID="C" Runat="Server">
    <uc1:ctlAccountBillingRateList ID="CtlAccountBillingRateList1" runat="server" />
</asp:Content>

