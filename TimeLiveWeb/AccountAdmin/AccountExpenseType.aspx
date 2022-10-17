<%@ Page Language="VB" MasterPageFile="~/Masters/MasterPageEmployee.master" AutoEventWireup="false" CodeFile="AccountExpenseType.aspx.vb" Inherits="AccountAdmin_AccountExpenseType" title="TimeLive - Expense Type" Theme="SkinFile" %>

<%@ Register Src="Controls/ctlAccountExpenseTypeList.ascx" TagName="ctlAccountExpenseTypeList"
    TagPrefix="uc1" %>
<asp:Content Content ID="C" ContentPlaceHolderID="C" Runat="Server">
    <uc1:ctlAccountExpenseTypeList ID="CtlAccountExpenseTypeList1" runat="server" />
</asp:Content>

