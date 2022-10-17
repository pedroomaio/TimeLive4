<%@ Page Language="VB" MasterPageFile="~/Masters/MasterPageEmployee.master" AutoEventWireup="false" CodeFile="ExpenseApproval.aspx.vb" Inherits="ProjectAdmin_ExpenseApproval" title="TimeLive - Expense Approval" %>

<%@ Register Src="Controls/ctlAccountExpenseEntryApproval.ascx" TagName="ctlAccountExpenseEntryApproval"
    TagPrefix="uc1" %>
<asp:Content Content ID="C" ContentPlaceHolderID="C" Runat="Server">
    <uc1:ctlAccountExpenseEntryApproval ID="CtlAccountExpenseEntryApproval1" runat="server" />
</asp:Content>

