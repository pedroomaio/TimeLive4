<%@ Page Language="VB" MasterPageFile="~/Masters/MasterPageEmployee.master" AutoEventWireup="false" CodeFile="DetailExpenseReport.aspx.vb" Inherits="Reports_DetailExpenseReport" title="TimeLive - Detail Expense Report" %>

<%@ Register Src="ControlsViewer/ctlDetailExpenseReport.ascx" TagName="ctlDetailExpenseReport"
    TagPrefix="uc1" %>
<asp:Content Content ID="C" ContentPlaceHolderID="C" Runat="Server">
    <uc1:ctlDetailExpenseReport ID="CtlDetailExpenseReport1" runat="server" />
</asp:Content>

