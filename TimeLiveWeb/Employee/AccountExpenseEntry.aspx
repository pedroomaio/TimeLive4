<%@ Page Language="VB" MasterPageFile="~/Masters/MasterPageEmployee.master" AutoEventWireup="false" CodeFile="AccountExpenseEntry.aspx.vb" Inherits="Employee_AccountExpenseEntry" title="TimeLive - My Expense Sheet" %>

<%@ Register Src="Controls/ctlAccountExpenseSheetList.ascx" TagName="ctlAccountExpenseSheetList"
    TagPrefix="uc1" %>
    <%@ MasterType VirtualPath="~/Masters/MasterPageEmployee.master" %>

<asp:Content Content ID="C" ContentPlaceHolderID="C" Runat="Server">
    <uc1:ctlAccountExpenseSheetList ID="CtlAccountExpenseSheetList1" runat="server" />
   
</asp:Content>

