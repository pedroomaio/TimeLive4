<%@ Page Language="VB" MasterPageFile="~/Masters/MasterPageEmployee.master" AutoEventWireup="false" CodeFile="AccountTimeOffPolicies.aspx.vb" Inherits="AccountAdmin_AccountTimeOffPolicies" title="TimeLive - Time Off Policies" %>

<%@ Register Src="Controls/ctlAccountTimeOffPoliciesList.ascx" TagName="ctlAccountTimeOffPoliciesList"
    TagPrefix="uc1" %>
<asp:Content Content ID="C" ContentPlaceHolderID="C" Runat="Server">
    <uc1:ctlAccountTimeOffPoliciesList ID="CtlAccountTimeOffPoliciesList1" runat="server" />
  </asp:Content>

