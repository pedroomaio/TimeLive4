<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlShowReport.ascx.vb"
    Inherits="WebReport_Reports_Controls_ctlShowReport" %>
<%@ Register Src="../../RuntimeReport/Controls/ReportControl.ascx" TagName="ReportControl"
    TagPrefix="uc2" %>
<%@ Register Src="../../Filters/Controls/ctlLiveReportFilter.ascx" TagName="ctlLiveReportFilter"
    TagPrefix="uc1" %>

<div style="margin-left: 20px">
    <uc1:ctlLiveReportFilter ID="CtlLiveReportFilter1" runat="server"></uc1:ctlLiveReportFilter>
    <br />
    <uc2:ReportControl ID="ReportControl1" runat="server" />
</div>