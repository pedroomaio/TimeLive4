<%@ Page Language="VB" MasterPageFile="~/Masters/MasterPageEmployee.master" AutoEventWireup="false" CodeFile="AccountCurrencyExchangeRate.aspx.vb" Inherits="AccountAdmin_AccountCurrencyExchangeRate" title="TimeLive - Exchange Rate" %>

<%@ Register Src="Controls/ctlAccountCurrencyExchangeRateList.ascx" TagName="AccountCurrencyExchangeRateList"
    TagPrefix="uc1" %>
<asp:Content Content ID="C" ContentPlaceHolderID="C" Runat="Server">
    <uc1:AccountCurrencyExchangeRateList ID="AccountCurrencyExchangeRateList1" runat="server" />
</asp:Content>

