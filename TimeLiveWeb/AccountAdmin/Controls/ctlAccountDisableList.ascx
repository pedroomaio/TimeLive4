<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlAccountDisableList.ascx.vb" Inherits="AccountAdmin_Controls_ctlAccountDisableList" %>

<style type="text/css">
    .style1
    {
        width: 155px;
    }
    .style2
    {
        width: 530px;
    }
</style>

<table style="width: 100%" class="xFormView">
<tr><td>
<table style="width: 96%" class="xFormView">
    <tr>
        <th colspan="6" class="caption">
            <asp:Literal ID="Literal1" runat="server" Text="<%$ Resources:TimeLive.Resource, Disable Account%> " /></th>
    </tr>
       <tr>
        <td align="left" class="formviewlabelcell" colspan="6">
            <span style="color: red; font-size: 12px; font-family: Tahoma;">
            <strong>&nbsp;&nbsp;&nbsp; *<asp:Literal ID="Literal4" runat="server" Text="<%$ Resources:TimeLive.Resource, Disabling account will stop any activities in your TimeLive account. Your employee will not be able to login in TimeLive. %> " /></td>
    </tr>
    <tr>
        <td align="right" class="formviewlabelcell">
           <asp:Literal ID="Literal2" runat="server" Text="<%$ Resources:TimeLive.Resource, Administrator Username:%> " /></td>
        <td align="left" valign="middle" class="style2">
            <asp:TextBox ID="UserNameTextBox" runat="server" Width="207px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="UserNameTextBox"
                CssClass="ErrorMessage" ErrorMessage="*"></asp:RequiredFieldValidator></td>
        <td class="formviewlabelcell">
            &nbsp;</td><td class="formviewlabelcell"></td><td class="formviewlabelcell"></td>
        <td class="formviewlabelcell">&nbsp;</td>
    </tr>
    <tr>
        <td align="right" class="formviewlabelcell">
            <asp:Literal ID="Literal3" runat="server" Text="<%$ Resources:TimeLive.Resource, Administrator Password:%> " /></td>
        <td align="left" valign="middle" class="style2">
            <asp:TextBox ID="PasswordTextBox" runat="server" Width="207px" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="PasswordTextBox"
                CssClass="ErrorMessage" ErrorMessage="*"></asp:RequiredFieldValidator></td>
        <td class="formviewlabelcell">
            &nbsp;</td><td class="formviewlabelcell"></td><td class="formviewlabelcell"></td>
        <td class="formviewlabelcell">&nbsp;</td>
    <tr>
        <td align="right" class="style1">
        </td>
        <td align="left" style="padding: 5px; margin-top: 5px; " 
            valign="middle" class="style2">
            <asp:Button ID="btnDisabled" runat="server" Text="<%$ Resources:TimeLive.Resource, Disable Account%> " Width="150px" 
            OnClientClick="return confirm('Are you sure you want to disable this account?');" />
        </td>
        <td class="formviewlabelcell">
            &nbsp;</td><td class="formviewlabelcell"></td><td class="formviewlabelcell"></td>
        <td class="formviewlabelcell">&nbsp;</td>
    </tr>
    <tr>
        <td align="right" class="style1">
            &nbsp;</td>
        <td align="left" valign="middle" colspan="1" class="style2">
            <asp:Label ID="Label1" runat="server" Font-Names="Tahoma" Font-Size="Smaller" ForeColor="Red"
                Text="<%$ Resources:TimeLive.Resource, *Invalid username or password%> " Visible="False"></asp:Label>
        </td>
        <td class="formviewlabelcell">
            &nbsp;</td><td class="formviewlabelcell">&nbsp;</td>
        <td class="formviewlabelcell">&nbsp;</td>
        <td class="formviewlabelcell">&nbsp;</td>
    </tr>
    </table>
</td></tr></table>