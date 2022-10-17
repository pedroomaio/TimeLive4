<%@ Page Language="VB" MasterPageFile="~/Masters/MasterPageEmployee.master" AutoEventWireup="false" CodeFile="AccountApprovals.aspx.vb" Inherits="AccountAdmin_AccountApprovals" title="TimeLive - Approvals" %>

<%@ Register Src="Controls/ctlAccountApprovalList.ascx" TagName="ctlAccountApprovalList"
    TagPrefix="uc1" %>
<asp:Content Content ID="C" ContentPlaceHolderID="C" Runat="Server">
    <uc1:ctlAccountApprovalList id="CtlAccountApprovalList1" runat="server">
    </uc1:ctlAccountApprovalList>
</asp:Content>

