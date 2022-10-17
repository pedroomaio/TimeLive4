<%@ Page Language="VB" MasterPageFile="~/Masters/MasterPageEmployee.master" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="Reports_Default" title="All Reports" %>

<%@ Register Src="ControlsViewer/ctlEmployeeTimeEntry.ascx" TagName="ctlEmployeeTimeEntry"
    TagPrefix="uc1" %>
<asp:Content Content ID="C" ContentPlaceHolderID="C" Runat="Server">
    <uc1:ctlEmployeeTimeEntry ID="CtlEmployeeTimeEntry1" runat="server" />
</asp:Content>

