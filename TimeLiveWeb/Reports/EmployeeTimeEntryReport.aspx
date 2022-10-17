<%@ Page Language="VB" MasterPageFile="~/Masters/MasterPageEmployee.master" AutoEventWireup="false" CodeFile="EmployeeTimeEntryReport.aspx.vb" Inherits="Reports_EmployeeTimeEntryReport" title="TimeLive - Task Billing By Projects/Clients" Theme ="SkinFile" %>

<%@ Register Src="ControlsViewer/ctlEmployeeTimeEntry.ascx" TagName="ctlEmployeeTimeEntry"
    TagPrefix="uc1" %>
<asp:Content Content ID="C" ContentPlaceHolderID="C" Runat="Server">
    <uc1:ctlEmployeeTimeEntry id="CtlEmployeeTimeEntry1" runat="server">
    </uc1:ctlEmployeeTimeEntry>
</asp:Content>

