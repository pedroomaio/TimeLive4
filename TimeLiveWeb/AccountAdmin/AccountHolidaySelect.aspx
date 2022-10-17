<%@ Page Language="VB" MasterPageFile="~/Masters/MasterPageemployee.master" AutoEventWireup="false" CodeFile="AccountHolidaySelect.aspx.vb" Inherits="AccountAdmin_AccountHolidaySelect" title="TimeLive - Holiday Types" %>

<%@ Register Src="Controls/ctlAccountHolidaySelect.ascx" TagName="ctlAccountHolidaySelect"
    TagPrefix="uc1" %>
<asp:Content Content ID="C" ContentPlaceHolderID="C" Runat="Server">
    <uc1:ctlAccountHolidaySelect ID="ctlAccountHolidaySelect1" runat="server" />
</asp:Content>
