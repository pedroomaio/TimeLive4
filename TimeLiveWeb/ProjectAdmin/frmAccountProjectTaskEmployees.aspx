<%@ Page Language="VB" MasterPageFile="~/Masters/MasterPageEmployee.master" AutoEventWireup="false" CodeFile="frmAccountProjectTaskEmployees.aspx.vb" Inherits="ProjectAdmin_frmAccountProjectTaskEmployees" title="Untitled Page" Theme="SkinFile" %>

<%@ Register Src="Controls/ctlAccountProjectTaskEmployeeList.ascx" TagName="ctlAccountProjectTaskEmployeeList"
    TagPrefix="uc1" %>
<asp:Content Content ID="C" ContentPlaceHolderID="C" Runat="Server">
    <uc1:ctlAccountProjectTaskEmployeeList ID="CtlAccountProjectTaskEmployeeList1" runat="server" />
</asp:Content>

