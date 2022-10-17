<%@ Page Language="VB" MasterPageFile="~/Masters/MasterPageEmployee.master" AutoEventWireup="false" CodeFile="AccountTerminology.aspx.vb" Inherits="AccountAdmin_AccountTerminology" title="TimeLive - Manage Terminology" %>

<%@ Register Src="Controls/ctlAccountTerminologyList.ascx" TagName="ctlAccountTerminologyList"
    TagPrefix="uc1" %>
<asp:Content Content ID="C" ContentPlaceHolderID="C" Runat="Server">
    <uc1:ctlAccountTerminologyList ID="CtlAccountTerminologyList1" runat="server" />
</asp:Content>

