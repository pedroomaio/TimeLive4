<%@ Page Language="VB" MasterPageFile="~/Masters/MasterPageEmployee.master" AutoEventWireup="false" CodeFile="AccountTaskTypes.aspx.vb" Inherits="AccountAdmin_AccountTaskTypes" title="TimeLive - Task Types" Theme="SkinFile" %>

<%@ Register Src="Controls/ctlAccountTaskTypeList.ascx" TagName="ctlAccountTaskTypeList"
    TagPrefix="uc1" %>
<asp:Content Content ID="C" ContentPlaceHolderID="C" Runat="Server">
    <uc1:ctlAccountTaskTypeList ID="CtlAccountTaskTypeList1" runat="server" />
</asp:Content>

