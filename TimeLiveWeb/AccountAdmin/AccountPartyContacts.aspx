<%@ Page Language="VB" MasterPageFile="~/Masters/MasterPageEmployee.master" AutoEventWireup="false" CodeFile="AccountPartyContacts.aspx.vb" Inherits="AccountAdmin_AccountPartyContacts" title="TimeLive - Client Contacts" %>

<%@ Register Src="Controls/ctlAccountPartyContactList.ascx" TagName="ctlAccountPartyContactList"
    TagPrefix="uc1" %>
<%@ MasterType VirtualPath="~/Masters/MasterPageEmployee.master" %>
<asp:Content Content ID="C" ContentPlaceHolderID="C" Runat="Server">
    <uc1:ctlAccountPartyContactList ID="CtlAccountPartyContactList1" runat="server" />
</asp:Content>

