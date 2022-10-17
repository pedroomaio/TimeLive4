<%@ Page Title="Manage Approval" Language="VB" MasterPageFile="~/Masters/MasterPageEmployee.master" AutoEventWireup="false" CodeFile="ManageApproval.aspx.vb" Inherits="Employee_ManageApproval" %>
<%@ Register Src="Controls/ctlManageApprovals.ascx" TagName="ctlManageApprovals"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="C" Runat="Server">
 <uc1:ctlManageApprovals ID="ctlManageApprovals1" runat="server" />
</asp:Content>

