<%@ Page Language="VB" MasterPageFile="~/Masters/MasterPageEmployee.master" AutoEventWireup="false" CodeFile="AccountExpenseEntryForm.aspx.vb" Inherits="Employee_AccountExpenseEntryForm" title="TimeLive - My Expense Entries" %>
<%@ Register Src="Controls/ctlAccountExpenseEntryList.ascx" TagName="ctlAccountExpenseEntryList"
    TagPrefix="uc1" %>
<asp:Content Content ID="C" ContentPlaceHolderID="C" Runat="Server">
 <uc1:ctlAccountExpenseEntryList ID="CtlAccountExpenseEntryList1" runat="server" />
</asp:Content>

