<%@ Page Language="VB" MasterPageFile="~/Masters/MasterPageEmployee.master" AutoEventWireup="false" CodeFile="frmAccountEmployeeAttendance.aspx.vb" Inherits="Employee_frmAccountEmployeeAttendance" title="Untitled Page" Theme ="SkinFile" %>

<%@ Register Src="Controls/ctlAccountEmployeeAttendanceList.ascx" TagName="ctlAccountEmployeeAttendanceList"
    TagPrefix="uc1" %>
<asp:Content Content ID="C" ContentPlaceHolderID="C" Runat="Server">
    <uc1:ctlAccountEmployeeAttendanceList ID="CtlAccountEmployeeAttendanceList1" runat="server" />
</asp:Content>

