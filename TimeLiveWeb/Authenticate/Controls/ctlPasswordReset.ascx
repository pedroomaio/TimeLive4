<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlPasswordReset.ascx.vb" Inherits="Authenticate_Controls_ctlPasswordReset" %>
<br />
<br />
<br />
<br />
<table class="xFormView" width="100%" ><tr><td>
<table width="100%" class="xFormView" align ="center" valign ="middle">
    <tr>
        <th class="caption" colspan="2" style="height: 21px">
            <asp:Literal ID="Literal1" runat="server" Text="<%$ Resources:TimeLive.Resource, Trouble Accessing Your Account%>" /></th>
            </tr>
    <tr>
        <td align="center" colspan="2" style="height: 35px">
            <strong>Forgot your password? Enter your login email below. We sent a link to 
            reset your password to the following email addresses.</strong></td>
    </tr>
    <tr>
        <td align="right" class="FormViewLabelCell" style="width: 35%">
            <asp:Literal ID="Literal19" runat="server" Text="<%$ Resources:TimeLive.Resource, Email Address%>" />:</td>
        <td style="width: 65%">
            <asp:TextBox ID="txtEmailAddress" runat="server" Width="300px"></asp:TextBox>
            <asp:RequiredFieldValidator
                ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEmailAddress"
                CssClass="ErrorMessage" Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator></td>
    </tr>
    <tr>
        <td align="right" class="FormViewLabelCell" style="width: 35%">
        </td>
        <td style="width: 65%">
            <asp:Button ID="btnPasswordReset" runat="server" Text="<%$ Resources:TimeLive.Resource, Reset Password %>" Width="105px" /></td>
    </tr>
    <tr>
        <td colspan="2">
            <asp:Label ID="Label2" runat="server" Text="This is not a valid email address. If you would like to register please Sign Up. Thank you." Visible="False" CssClass="ErrorMessage" Width="100%">
            </asp:Label><asp:Label ID="Label1" runat="server" Text=""
                Visible="False" ForeColor="Green" Width="100%"></asp:Label></td>
    </tr>
</table>
</td></tr></table>
