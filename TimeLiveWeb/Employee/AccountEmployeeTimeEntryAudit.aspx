<%@ Page Language="VB" MasterPageFile="~/Masters/MasterPageEmployee.master" AutoEventWireup="false" CodeFile="AccountEmployeeTimeEntryAudit.aspx.vb" Inherits="Employee_AccountEmployeeTimeEntryAudit" title="TimeLive - Timesheet Audit" Theme="SkinFile" %>

<%@ Register Src="Controls/ctlAccountEmployeeTimeEntryAudit.ascx" TagName="ctlAccountEmployeeTimeEntryAudit"
    TagPrefix="uc1" %>
<asp:Content ID="C" ContentPlaceHolderID="C" Runat="Server">
    <uc1:ctlAccountEmployeeTimeEntryAudit ID="CtlAccountEmployeeTimeEntryAudit1" runat="server" />
</asp:Content>

