<%@ Page Language="VB" MasterPageFile="~/Masters/MasterPageEmployee.master" AutoEventWireup="false" CodeFile="AccountApproval.aspx.vb" Inherits="AccountAdmin_AccountApproval" title="TimeLive - Approval" %>

<%@ Register Src="Controls/ctlAccountApprovalForm.ascx" TagName="ctlAccountApprovalForm"
    TagPrefix="uc1" %>
<asp:Content Content ID="C" ContentPlaceHolderID="C" Runat="Server">
    <uc1:ctlAccountApprovalForm id="CtlAccountApprovalForm1" runat="server">
    </uc1:ctlAccountApprovalForm>
</asp:Content>

