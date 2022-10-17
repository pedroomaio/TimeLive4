<%@ Page Language="VB" MasterPageFile="~/Masters/MasterPageEmployee.master" AutoEventWireup="false" CodeFile="ProjectListReport.aspx.vb" Inherits="Reports_ProjectListReport" title="TimeLive - All Projects Report" %>

<%@ Register Src="ControlsViewer/ctlProjectListReport.ascx" TagName="ctlProjectListReport"
    TagPrefix="uc1" %>
<asp:Content ID="C" ContentPlaceHolderID="C" Runat="Server">
    <uc1:ctlProjectListReport ID="CtlProjectListReport1" runat="server" />
</asp:Content>

