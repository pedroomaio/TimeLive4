<%@ Page Language="VB" MasterPageFile="~/Masters/MasterPageEmployee.master" AutoEventWireup="false" CodeFile="AccountAttachments.aspx.vb" Inherits="AccountAdmin_AccountAttachments" title="TimeLive - Attachments" %>

<%@ Register Src="Controls/ctlAccountAttachments.ascx" TagName="ctlAccountAttachments"
    TagPrefix="uc1" %>
<asp:Content Content ID="C" ContentPlaceHolderID="C" Runat="Server">
    <uc1:ctlAccountAttachments ID="CtlAccountAttachments1" runat="server" />
</asp:Content>

