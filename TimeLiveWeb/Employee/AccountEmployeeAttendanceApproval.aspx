<%@ Page Language="VB" MasterPageFile="~/Masters/MasterPageEmployee.master" AutoEventWireup="false" CodeFile="AccountEmployeeAttendanceApproval.aspx.vb" Inherits="Employee_AccountEmployeeAttendanceApproval" title="Attendance Approval" %>

<%@ Register Src="Controls/ctlAccountEmployeeAttendanceApproval.ascx" TagName="ctlAccountEmployeeAttendanceApproval"
    TagPrefix="uc1" %>
<asp:Content Content ID="C" ContentPlaceHolderID="C" Runat="Server">
    <uc1:ctlAccountEmployeeAttendanceApproval ID="ctlAccountEmployeeAttendanceApproval1" runat="server" />
</asp:Content>

