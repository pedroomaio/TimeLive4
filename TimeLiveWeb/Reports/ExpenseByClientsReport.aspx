<%@ Page Language="VB" MasterPageFile="~/Masters/MasterPageemployee.master" AutoEventWireup="false" CodeFile="ExpenseByClientsReport.aspx.vb" Inherits="Reports_ExpenseByClientsReport" title="TimeLive - Expense By Clients Report" %>

<%@ Register Src="ControlsViewer/ctlExpenseByClientReport.ascx" TagName="ctlExpenseByClientReport"
    TagPrefix="uc1" %>
<asp:Content Content ID="C" ContentPlaceHolderID="C" Runat="Server">
    <uc1:ctlExpenseByClientReport ID="CtlExpenseByClientReport1" runat="server" />
</asp:Content>

