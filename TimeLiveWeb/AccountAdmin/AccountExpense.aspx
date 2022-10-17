<%@ Page Language="VB" MasterPageFile="~/Masters/MasterPageEmployee.master" AutoEventWireup="false" CodeFile="AccountExpense.aspx.vb" Inherits="AccountAdmin_AccountExpense" title="TimeLive - Expense" %>

<%@ Register Src="Controls/ctlAccountExpenseList.ascx" TagName="ctlAccountExpenseList"
    TagPrefix="uc1" %>
<asp:Content Content ID="C" ContentPlaceHolderID="C" Runat="Server">
    <uc1:ctlAccountExpenseList ID="CtlAccountExpenseList1" runat="server" />
</asp:Content>

