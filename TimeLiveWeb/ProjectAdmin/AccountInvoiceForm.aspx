<%@ Page Language="VB" MasterPageFile="~/Masters/MasterPageemployee.master" AutoEventWireup="false" CodeFile="AccountInvoiceForm.aspx.vb" Inherits="ProjectAdmin_AccountInvoiceForm" title="TimeLive - Account Invoice Form" %>

<%@ Register Src="Controls/ctlAccountInvoiceForm.ascx" TagName="ctlAccountInvoiceForm"
    TagPrefix="uc1" %>
<asp:Content Content ID="C" ContentPlaceHolderID="C" Runat="Server">
    <uc1:ctlAccountInvoiceForm id="CtlAccountInvoiceForm"
        runat="server">
    </uc1:ctlAccountInvoiceForm>
</asp:Content>

