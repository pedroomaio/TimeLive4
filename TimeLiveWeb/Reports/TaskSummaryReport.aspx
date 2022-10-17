<%@ Page Language="VB" MasterPageFile="~/Masters/MasterPageEmployee.master" AutoEventWireup="false" CodeFile="TaskSummaryReport.aspx.vb" Inherits="Reports_TaskSummaryReport" title="TimeLive - Task Summary Report" %>

<%@ Register Src="ControlsViewer/ctlTaskSummaryReport.ascx" TagName="ctlTaskSummaryReport"
    TagPrefix="uc1" %>
<asp:Content ID="C" ContentPlaceHolderID="C" Runat="Server">
    <uc1:ctlTaskSummaryReport ID="CtlTaskSummaryReport1" runat="server" />
</asp:Content>

