<%@ Page Language="VB" MasterPageFile="~/Masters/MasterPageEmployee.master" AutoEventWireup="false" CodeFile="ProjectExpenseDetailReport.aspx.vb" Inherits="Reports_ProjectExpenseDetailReport" title="TimeLive - Project Expense Detail Report" %>

<%@ Register Src="ControlsViewer/ctlProjectExpenseDetailReport.ascx" TagName="ctlProjectExpenseDetailReport"
    TagPrefix="uc1" %>
<asp:Content ID="C" ContentPlaceHolderID="C" Runat="Server">
    <uc1:ctlProjectExpenseDetailReport id="CtlProjectExpenseDetailReport1" runat="server">
    </uc1:ctlProjectExpenseDetailReport>
</asp:Content>

