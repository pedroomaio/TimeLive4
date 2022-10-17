<%@ Page Language="VB" MasterPageFile="~/Masters/MasterPageemployee.master" AutoEventWireup="false" CodeFile="EmployeeAttendanceSummaryReport.aspx.vb" Inherits="Reports_EmployeeAttendanceSummaryReport" title="TimeLive - Employee Attendance Summary Report" %>

<%@ Register Src="ControlsViewer/ctlEmployeeAttendanceSummaryReport.ascx" TagName="ctlEmployeeAttendanceSummaryReport"
    TagPrefix="uc1" %>
<asp:Content Content ID="C" ContentPlaceHolderID="C" Runat="Server">
    <uc1:ctlEmployeeAttendanceSummaryReport ID="CtlEmployeeAttendanceSummaryReport1" runat="server" />
</asp:Content>

