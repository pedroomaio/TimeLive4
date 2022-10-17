<%@ Page Language="VB" MasterPageFile="~/Masters/MasterPageEmployee.master" AutoEventWireup="false" CodeFile="AccountPartyDepartments.aspx.vb" Inherits="AccountAdmin_AccountPartyDepartments" title="TimeLive - Client Departments" %>

<%@ Register Src="Controls/ctlAccountPartyDepartmentList.ascx" TagName="ctlAccountPartyDepartmentList"
    TagPrefix="uc1" %>
<%@ MasterType VirtualPath="~/Masters/MasterPageEmployee.master" %>
<asp:Content Content ID="C" ContentPlaceHolderID="C" Runat="Server">
    <uc1:ctlAccountPartyDepartmentList ID="CtlAccountPartyDepartmentList1" runat="server" />
</asp:Content>

