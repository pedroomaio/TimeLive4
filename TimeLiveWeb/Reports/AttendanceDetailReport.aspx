<%@ Page Language="VB" MasterPageFile="~/Masters/MasterPageEmployee.master" AutoEventWireup="false" CodeFile="AttendanceDetailReport.aspx.vb" Inherits="Reports_AttendanceDetailReport" title="TimeLive - Attendance Detail Report" %>

<%@ Register Src="ControlsViewer/ctlAttendanceDetailReport.ascx" TagName="ctlAttendanceDetailReport"
    TagPrefix="uc1" %>
<asp:Content Content ID="C" ContentPlaceHolderID="C" Runat="Server">
    <uc1:ctlAttendanceDetailReport ID="CtlAttendanceDetailReport1" runat="server" />
</asp:Content>

