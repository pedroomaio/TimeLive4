<%@ Page Language="VB" MasterPageFile="~/Masters/MasterPageEmployee.master" AutoEventWireup="false" CodeFile="AccountTimeOffPoliciesDetail.aspx.vb" Inherits="AccountAdmin_AccountTimeOffPoliciesDetail" title="TimeLive - Policies Detail" %>

<%@ Register Src="Controls/ctlAccountTimeOffPoliciesDetail.ascx" TagName="ctlAccountTimeOffPoliciesDetail"
    TagPrefix="uc1" %>
<asp:Content Content ID="C" ContentPlaceHolderID="C" Runat="Server">
    <uc1:ctlAccountTimeOffPoliciesDetail ID="CtlAccountTimeOffPoliciesDetail1" runat="server" />
</asp:Content>

