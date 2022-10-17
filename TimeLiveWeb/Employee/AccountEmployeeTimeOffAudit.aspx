<%@ Page Language="VB" MasterPageFile="~/Masters/MasterPageEmployee.master" AutoEventWireup="false" CodeFile="AccountEmployeeTimeOffAudit.aspx.vb" Inherits="Employee_AccountEmployeeTimeOffAudit" title="TimeLive - Time Off Audit"%>


<%@ Register Src="Controls/ctlAccountEmployeeTimeOffAudit.ascx" TagName="ctlAccountEmployeeTimeOffAudit" TagPrefix="uc1" %>
<asp:Content Content ID="C" ContentPlaceHolderID="C" Runat="Server">
    <uc1:ctlAccountEmployeeTimeOffAudit ID="ctlAccountEmployeeTimeOffAudit1" runat="server" />
</asp:Content>