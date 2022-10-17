<%@ Page Language="VB" MasterPageFile="~/Masters/MasterPageEmployee.master" AutoEventWireup="false" CodeFile="AccountFeatureManagement.aspx.vb" Inherits="AccountAdmin_AccountFeatureManagement" title="TimeLive - Feature Management" %>

<%@ Register Src="Controls/ctlAccountFeatureManagement.ascx" TagName="ctlAccountFeatureManagement"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="C" Runat="Server">
    <uc1:ctlAccountFeatureManagement ID="ctlAccountFeatureManagement1" runat="server" />
</asp:Content>