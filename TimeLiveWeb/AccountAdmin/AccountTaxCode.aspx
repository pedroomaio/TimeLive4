<%@ Page Language="VB" MasterPageFile="~/Masters/MasterPageEmployee.master" AutoEventWireup="false" CodeFile="AccountTaxCode.aspx.vb" Inherits="AccountAdmin_AccountTaxCode" title="TimeLive - Tax Code" %>

<%@ Register Src="Controls/ctlAccountTaxCodeList.ascx" TagName="ctlAccountTaxCodeList"
    TagPrefix="uc1" %>
<asp:Content Content ID="C" ContentPlaceHolderID="C" Runat="Server">
    <uc1:ctlAccountTaxCodeList ID="CtlAccountTaxCodeList1" runat="server" />
</asp:Content>

