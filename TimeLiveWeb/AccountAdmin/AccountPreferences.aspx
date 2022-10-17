<%@ Page Language="VB" MasterPageFile="~/Masters/MasterPageemployee.master" AutoEventWireup="false" CodeFile="AccountPreferences.aspx.vb" Inherits="AccountAdmin_AccountPreferences" title="TimeLive - Application Preferences" Theme="SkinFile" %>

<%@ Register Src="../Home/Controls/ctlaccountform.ascx" TagName="ctlaccountform"
    TagPrefix="uc1" %>
<asp:Content Content ID="C" ContentPlaceHolderID="C" Runat="Server">
    <uc1:ctlaccountform ID="Ctlaccountform1" runat="server" />
</asp:Content>

