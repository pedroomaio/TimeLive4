<%@ Page Language="VB" MasterPageFile="~/Masters/MasterPageEmployee.master" AutoEventWireup="false" CodeFile="AccountEmployeeType.aspx.vb" Inherits="AccountAdmin_AccountEmployeeType" title="TimeLive - Employee Types" %>

<%@ Register Src="Controls/ctlAccountEmployeeTypeList.ascx" TagName="ctlAccountEmployeeTypeList"
    TagPrefix="uc1" %>
<asp:Content Content ID="C" ContentPlaceHolderID="C" Runat="Server">
    <uc1:ctlAccountEmployeeTypeList ID="CtlAccountEmployeeTypeList1" runat="server" />
</asp:Content>

