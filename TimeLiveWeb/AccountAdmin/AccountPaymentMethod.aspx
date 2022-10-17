<%@ Page Language="VB" MasterPageFile="~/Masters/MasterPageEmployee.master" AutoEventWireup="false" CodeFile="AccountPaymentMethod.aspx.vb" Inherits="AccountAdmin_AccountPaymentMethod" title="TimeLive - Payment Method" %>

<%@ Register Src="Controls/ctlAccountPaymentMethodList.ascx" TagName="ctlAccountPaymentMethodList"
    TagPrefix="uc1" %>
<asp:Content Content ID="C" ContentPlaceHolderID="C" Runat="Server">
    <uc1:ctlAccountPaymentMethodList ID="CtlAccountPaymentMethodList1" runat="server" />
</asp:Content>

