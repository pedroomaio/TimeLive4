<%@ Page Language="VB" MasterPageFile="~/Masters/MasterPageEmployee.master" AutoEventWireup="false" CodeFile="AuthenticationSetting.aspx.vb" Inherits="AccountAdmin_AuthenticationSetting" title="TimeLive - Authentication Setting" Theme="SkinFile"%>

<%@ Register Src="Controls/ctlAuthenticationSetting.ascx" TagName="ctlAuthenticationSetting"
    TagPrefix="uc1" %>
<asp:Content Content ID="C" ContentPlaceHolderID="C" Runat="Server">
    <uc1:ctlAuthenticationSetting ID="CtlAuthenticationSetting1" runat="server" />
</asp:Content>

