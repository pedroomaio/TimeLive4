<%@ Page Language="VB" MasterPageFile="~/Masters/MasterPageEmployee.master" AutoEventWireup="false" CodeFile="ReportDesign.aspx.vb" Inherits="WebReport_ReportDesign" title="TimeLive - Report Design" ValidateRequest="false"  %>

<%@ Register Src="Design/Controls/ctlReportDesign.ascx" TagName="ctlReportDesign"
    TagPrefix="uc1" %>
<asp:Content ID="C" ContentPlaceHolderID="C" Runat="Server">
    <uc1:ctlReportDesign ID="CtlReportDesign1" runat="server" />
</asp:Content>

