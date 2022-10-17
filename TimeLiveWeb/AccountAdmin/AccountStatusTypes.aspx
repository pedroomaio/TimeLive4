<%@ Page Language="VB" MasterPageFile="~/Masters/MasterPageEmployee.master" AutoEventWireup="false" CodeFile="AccountStatusTypes.aspx.vb" Inherits="AccountAdmin_frmAccountStatusTypes" title="TimeLive - Status" Theme="SkinFile" %>

<%@ Register Src="Controls/ctlAccountStatusList.ascx" TagName="ctlAccountStatusList"
    TagPrefix="uc1" %>
<asp:Content Content ID="C" ContentPlaceHolderID="C" Runat="Server">
    <uc1:ctlAccountStatusList ID="CtlAccountStatusList1" runat="server" />
</asp:Content>

