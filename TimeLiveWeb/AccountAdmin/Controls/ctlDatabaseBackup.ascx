<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlDatabaseBackup.ascx.vb" Inherits="AccountAdmin_Controls_ctlDatabaseBackup" %>
<asp:Button ID="btnbackupdatabase" runat="server" Text="Backup Database" /><br />
<br />
<asp:Image ID="Image1" runat="server" ImageUrl="~/Images/AjaxUpdateStatus.gif" Visible="False" />
<asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Large" Text="Processing..."
    Visible="False"></asp:Label>
