<%@ Page Language="VB" MasterPageFile="~/Masters/MasterPageEmployee.master" AutoEventWireup="false" CodeFile="AccountReportPermission.aspx.vb" Inherits="WebReport_Permission_AccountReportPermission" title="TimeLive - Report Permission" %>

<%@ Register Src="Permission/Controls/ctlAccountReportPermission.ascx" TagName="ctlAccountReportPermission"
    TagPrefix="uc1" %>
<asp:Content ID="C" ContentPlaceHolderID="C" Runat="Server">
    <uc1:ctlAccountReportPermission ID="CtlAccountReportPermission1" runat="server" />
</asp:Content>

