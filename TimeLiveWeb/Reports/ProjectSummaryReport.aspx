<%@ Page Language="VB" MasterPageFile="~/Masters/MasterPageEmployee.master" AutoEventWireup="false" CodeFile="ProjectSummaryReport.aspx.vb" Inherits="Reports_ProjectSummaryReport" title="TimeLive - Project Activity Summary Report" %>

<%@ Register Src="ControlsViewer/ctlProjectSummary.ascx" TagName="ctlProjectSummary"
    TagPrefix="uc2" %>

<asp:Content ID="C" ContentPlaceHolderID="C" Runat="Server">
    <uc2:ctlProjectSummary ID="CtlProjectSummary1" runat="server" />
</asp:Content>

