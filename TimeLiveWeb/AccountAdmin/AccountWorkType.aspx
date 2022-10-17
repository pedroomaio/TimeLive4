<%@ Page Language="VB" MasterPageFile="~/Masters/MasterPageEmployee.master" AutoEventWireup="false" CodeFile="AccountWorkType.aspx.vb" Inherits="AccountAdmin_AccountWorkType" title="TimeLive - Work Type" %>

<%@ Register Src="Controls/ctlAccountWorkTypeList.ascx" TagName="ctlAccountWorkTypeList"
    TagPrefix="uc1" %>
<asp:Content Content ID="C" ContentPlaceHolderID="C" Runat="Server">
    <uc1:ctlAccountWorkTypeList ID="CtlAccountWorkTypeList1" runat="server" />
</asp:Content>

