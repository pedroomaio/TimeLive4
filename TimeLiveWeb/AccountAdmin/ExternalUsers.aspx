<%@ Page Language="VB" MasterPageFile="~/Masters/MasterPageEmployee.master" AutoEventWireup="false" CodeFile="ExternalUsers.aspx.vb" Inherits="AccountAdmin_ExternalUsers" title="TimeLive - External Users" %>

<%@ Register Src="Controls/ctlExternalUserList.ascx" TagName="ctlExternalUserList"
    TagPrefix="uc1" %>
<asp:Content Content ID="C" ContentPlaceHolderID="C" Runat="Server">
    <uc1:ctlExternalUserList id="CtlExternalUserList1" runat="server">
    </uc1:ctlExternalUserList>
</asp:Content>

