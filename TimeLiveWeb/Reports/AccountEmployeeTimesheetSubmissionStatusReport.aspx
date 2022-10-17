<%@ Page Language="VB" MasterPageFile="~/Masters/MasterPageEmployee.master" AutoEventWireup="false" CodeFile="AccountEmployeeTimesheetSubmissionStatusReport.aspx.vb" Inherits="Reports_AccountEmployeeTimesheetSubmissionStatusReport" title="TimeLive - Account Employee Timesheet Submission Status Report" %>

<%@ Register Src="ControlsViewer/ctlAccountEmployeeTimesheetSubmissionStatusReport.ascx"
    TagName="ctlAccountEmployeeTimesheetSubmissionStatusReport" TagPrefix="uc1" %>
<asp:Content Content ID="C" ContentPlaceHolderID="C" Runat="Server">
    <uc1:ctlAccountEmployeeTimesheetSubmissionStatusReport ID="CtlAccountEmployeeTimesheetSubmissionStatusReport1"
        runat="server" />
</asp:Content>

