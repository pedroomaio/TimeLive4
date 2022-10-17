<%@ Page Language="VB" MasterPageFile="~/Masters/MasterPageEmployee.master" AutoEventWireup="false" CodeFile="AccountParties.aspx.vb" Inherits="AccountAdmin_frmAccountParty" title="TimeLive - Clients" Theme="SkinFile"  %>

<%@ Register Src="Controls/ctlAccountPartyList.ascx" TagName="ctlAccountPartyList"
    TagPrefix="uc1" %>
    <%@ MasterType VirtualPath="~/Masters/MasterPageEmployee.master" %>
<asp:Content Content ID="C" ContentPlaceHolderID="C" Runat="Server">
    <uc1:ctlAccountPartyList ID="CtlAccountPartyList1" runat="server" />
</asp:Content>

