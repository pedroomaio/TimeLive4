<%@ Page Language="VB" MasterPageFile="~/Masters/MasterPageEmployee.master" AutoEventWireup="false" CodeFile="EmployeeListReport.aspx.vb" Inherits="Reports_EmployeeListReport" title="TimeLive - All Employees Report" %>

<%@ Register Src="ControlsViewer/ctlEmployeeListReport.ascx" TagName="ctlEmployeeListReport"
    TagPrefix="uc1" %>
<asp:Content Content ID="C" ContentPlaceHolderID="C" Runat="Server">
    <uc1:ctlEmployeeListReport ID="CtlEmployeeListReport1" runat="server" />
</asp:Content>

