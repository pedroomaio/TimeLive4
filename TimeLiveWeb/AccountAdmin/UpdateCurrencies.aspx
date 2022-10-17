<%@ Page Language="VB" MasterPageFile="~/Masters/MasterPageEmployee.master" AutoEventWireup="false" CodeFile="UpdateCurrencies.aspx.vb" Inherits="AccountAdmin_UpdateCurrencies" Title="TimeLive - Update Currencies" %>

<%@ Register Src="Controls/ctlUpdateCurrencies.ascx" TagName="ctlUpdateCurrencies"
    TagPrefix="uc1" %>
<asp:Content Content ID="C" ContentPlaceHolderID="C" Runat="Server">
    <uc1:ctlUpdateCurrencies ID="CtlUpdateCurrencies1" runat="server" />
</asp:Content>

