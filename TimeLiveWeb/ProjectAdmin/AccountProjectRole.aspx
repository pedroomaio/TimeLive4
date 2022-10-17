<%@ Page Language="VB" MasterPageFile="~/Masters/MasterPageEmployee.master" AutoEventWireup="false" CodeFile="AccountProjectRole.aspx.vb" Inherits="ProjectAdmin_AccountProjectRole" title="TimeLive - Project Role" %>

<%@ Register Src="Controls/ctlAccountProjectRoleList.ascx" TagName="ctlAccountProjectRoleList"
    TagPrefix="uc1" %>
<asp:Content Content ID="C" ContentPlaceHolderID="C" Runat="Server">
    <uc1:ctlAccountProjectRoleList ID="CtlAccountProjectRoleList1" runat="server" />
</asp:Content>

