<%@ Page Language="VB" MasterPageFile="~/Masters/MasterPageEmployee.master" AutoEventWireup="false" CodeFile="DepartmentWiseTimesheetReport.aspx.vb" Inherits="Reports_DepartmentWiseTimesheetReport" title="TimeLive - Department Wise Timesheet Report" %>

<%@ Register Src="ControlsViewer/ctlDepartmentWiseTimesheetReport.ascx" TagName="ctlDepartmentWiseTimesheetReport"
    TagPrefix="uc1" %>



<asp:Content Content ID="C" ContentPlaceHolderID="C" Runat="Server">
    <uc1:ctlDepartmentWiseTimesheetReport ID="CtlDepartmentWiseTimesheetReport1" runat="server" />

</asp:Content>

