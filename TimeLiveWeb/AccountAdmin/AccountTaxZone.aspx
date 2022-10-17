<%@ Page Language="VB" MasterPageFile="~/Masters/MasterPageEmployee.master" AutoEventWireup="false" CodeFile="AccountTaxZone.aspx.vb" Inherits="AccountAdmin_AccountTaxZone" title="TimeLive - Tax Zone" %>

<%@ Register Src="Controls/ctlAccountTaxZoneList.ascx" TagName="ctlAccountTaxZoneList"
    TagPrefix="uc1" %>
<asp:Content Content ID="C" ContentPlaceHolderID="C" Runat="Server">
    <uc1:ctlAccountTaxZoneList ID="CtlAccountTaxZoneList1" runat="server" />
</asp:Content>

