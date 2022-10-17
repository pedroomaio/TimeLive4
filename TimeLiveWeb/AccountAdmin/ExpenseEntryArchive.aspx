<%@ Page Language="VB" MasterPageFile="~/Masters/MasterPageEmployee.master" AutoEventWireup="false" CodeFile="ExpenseEntryArchive.aspx.vb" Inherits="AccountAdmin_ExpenseEntryArchive" title="TimeLive - Expense Entry Archive" %>

<%@ Register Src="Controls/ctlExpenseEntryArchive.ascx" TagName="ctlExpenseEntryArchive" TagPrefix="uc1" %>
<%@ MasterType VirtualPath="~/Masters/MasterPageEmployee.master" %>

<asp:Content Content ID="C" ContentPlaceHolderID="C" Runat="Server">
    <uc1:ctlExpenseEntryArchive id="ctlExpenseEntryArchive1" runat="server">
    </uc1:ctlExpenseEntryArchive>
</asp:Content>

