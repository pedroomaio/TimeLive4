<%@ Page Language="VB" MasterPageFile="~/Masters/MasterPageEmployee.master" AutoEventWireup="false" CodeFile="DatabaseBackup.aspx.vb" Inherits="AccountAdmin_DatabaseBackup" title="TimeLive - Database Backup" %>

<%@ Register Src="Controls/ctlDatabaseBackup.ascx" TagName="ctlDatabaseBackup"
    TagPrefix="uc1" %>
<asp:Content Content ID="C" ContentPlaceHolderID="C" Runat="Server">
    <uc1:ctlDatabaseBackup ID="ctlDatabaseBackup1" runat="server" />
</asp:Content>