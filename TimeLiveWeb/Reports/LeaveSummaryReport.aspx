<%@ Page Language="VB" MasterPageFile="~/Masters/MasterPageEmployee.master" AutoEventWireup="false" CodeFile="LeaveSummaryReport.aspx.vb" Inherits="Reports_LeaveSummaryReport" title="TimeLive - Leave Summary Report" %>

<%@ Register Src="ControlsViewer/ctlLeaveSummaryReport.ascx" TagName="ctlLeaveSummaryReport"
    TagPrefix="uc1" %>
<asp:Content ID="C" ContentPlaceHolderID="C" Runat="Server">
    <uc1:ctlLeaveSummaryReport ID="CtlLeaveSummaryReport1" runat="server" />
</asp:Content>

