<%@ Page Language="VB" MasterPageFile="~/Masters/MasterPageEmployee.master" AutoEventWireup="false" CodeFile="AccountCurrencies.aspx.vb" Inherits="AccountAdmin_AccountCurrencies" title="TimeLive - Currencies" %>

<%@ Register Src="Controls/ctlAccountCurrenciesList.ascx" TagName="ctlAccountCurrenciesList" TagPrefix="uc1" %>
<asp:Content Content ID="C" ContentPlaceHolderID="C" Runat="Server">
    <uc1:ctlAccountCurrenciesList ID="CtlAccountCurrenciesList1" runat="server" />
</asp:Content>

