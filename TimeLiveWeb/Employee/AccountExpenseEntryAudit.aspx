<%@ Page Language="VB" MasterPageFile="~/Masters/MasterPageEmployee.master" AutoEventWireup="false" CodeFile="AccountExpenseEntryAudit.aspx.vb" Inherits="Employee_AccountExpenseEntryAudit" title="TimeLive - Expense Sheet Audit" %>

<%@ Register Src="Controls/ctlAccountExpenseEntryAuditList.ascx" TagName="ctlAccountExpenseEntryAuditList"
    TagPrefix="uc1" %>
<asp:Content Content ID="C" ContentPlaceHolderID="C" Runat="Server">
    <uc1:ctlAccountExpenseEntryAuditList ID="CtlAccountExpenseEntryAuditList1" runat="server" />
</asp:Content>

