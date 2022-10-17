<%@ Page Language="VB" MasterPageFile="~/Masters/MasterPageEmployee.master" AutoEventWireup="false" CodeFile="AccountDisable.aspx.vb" Inherits="AccountAdmin_AccountDisable" title="TimeLive - Account Disable" %>

<%@ Register Src="Controls/ctlAccountDisableList.ascx" TagName="ctlAccountDisableList"
    TagPrefix="uc4" %>

<asp:Content Content ID="C" ContentPlaceHolderID="C" Runat="Server">
 <uc4:ctlAccountDisableList ID="CtlAccountDisableList1" runat="server" />
</asp:Content>

