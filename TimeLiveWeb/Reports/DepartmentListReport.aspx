<%@ Page Language="VB" MasterPageFile="~/Masters/MasterPageEmployee.master" AutoEventWireup="false" CodeFile="DepartmentListReport.aspx.vb" Inherits="Reports_DepartmentListReport" title="TimeLive - All Departments Report" %>

<%@ Register Src="ControlsViewer/ctlDepartmentListReport.ascx" TagName="ctlDepartmentListReport"
    TagPrefix="uc1" %>
<asp:Content Content ID="C" ContentPlaceHolderID="C" Runat="Server">
    <uc1:ctlDepartmentListReport ID="CtlDepartmentListReport1" runat="server" />
</asp:Content>

