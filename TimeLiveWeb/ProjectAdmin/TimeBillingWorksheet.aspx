<%@ Page Language="VB" MasterPageFile="~/Masters/MasterPageEmployee.master" AutoEventWireup="false" CodeFile="TimeBillingWorksheet.aspx.vb" Inherits="ProjectAdmin_TimeBillingWorksheet" title="TimeLive - Time Billing Worksheet" %>

<%@ Register Src="Controls/ctlTimeBillingWorksheet.ascx" TagName="ctlTimeBillingWorksheet"
    TagPrefix="uc1" %>
<asp:Content Content ID="C" ContentPlaceHolderID="C" Runat="Server">
    <uc1:ctlTimeBillingWorksheet ID="ctlTimeBillingWorksheet1" runat="server" />
</asp:Content>

