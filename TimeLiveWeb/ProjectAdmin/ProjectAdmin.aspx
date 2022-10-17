<%@ Page Language="VB" MasterPageFile="~/Masters/MasterPageEmployee.master" AutoEventWireup="false" CodeFile="ProjectAdmin.aspx.vb" Inherits="ProjectAdmin_ProjectAdmin" title="TimeLive - Project Admin" %>

<%@ Register Src="Controls/ctlProjectAdmin.ascx" TagName="ctlProjectAdmin" TagPrefix="uc1" %>

<asp:Content ID="C" ContentPlaceHolderID="C" Runat="Server">
    <uc1:ctlProjectAdmin ID="CtlProjectAdmin1" runat="server" />
</asp:Content>

