<%@ Page Language="VB" MasterPageFile="~/Masters/MasterPageemployee.master" AutoEventWireup="false" CodeFile="AccountLicenseActivation.aspx.vb" Inherits="AccountAdmin_AccountLicenseActivation" title="TimeLive - license Activation" Theme="SkinFile" %>

<%@ Register Src="Controls/ctlLicenseActivation.ascx" TagName="ctlLicenseActivation"
    TagPrefix="uc1" %>
<asp:Content Content ID="C" ContentPlaceHolderID="C" Runat="Server">
    <uc1:ctlLicenseActivation ID="ctlLicenseActivation1" runat="server" />
</asp:Content>

