<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlPasswordConfirm.ascx.vb" Inherits="Authenticate_Controls_ctlPasswordConfirm" %>
<br />
<br />
<br />
<br />
<br />
<br />
<br />
<br />
<br />
<table width="100%" class="xFormView">
<tr>
<td>
<table width="100%" class="xFormView">

    <tr>
        <th class="caption" colspan="2" style="height: 21px"  valign="middle" align="center"  >
            TimeLive - You must change your password.</th>
    </tr>

    <tr>
        <td align="right" class="FormViewLabelCell" style="width: 65px; height: 30px">
            New Password:
        </td>
        <td style="width: 65%">
            <asp:TextBox ID="txtNewPassword" runat="server" Width="200px" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtNewPassword"
                CssClass="ErrorMessage" Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtNewPassword"
                Display="Dynamic" SkinID="PasswordValidator" ValidationExpression="(?=^.{8,}$)(?=.*\d)(?=.*\W+)(?![.\n]).*$"></asp:RegularExpressionValidator></td>
    </tr>
    <tr>
        <td align="right" class="FormViewLabelCell" style="width: 65px; height: 30px">
            Re-Type Password:
        </td>
        <td style="width: 65%">
            <asp:TextBox ID="txtReTypePassword" runat="server" Width="200px" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtReTypePassword"
                CssClass="ErrorMessage" Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtReTypePassword"
                                ControlToValidate="txtNewPassword" CssClass="ErrorMessage" ErrorMessage="(Mismatch)" Display="Dynamic"></asp:CompareValidator>
                               </td>
    </tr>
    <tr>
        <td align="right" class="FormViewLabelCell" style="width: 35%">
        </td>
        <td style="width: 65%">
            <asp:Button ID="btnPassword" runat="server" Text="Change Password And Login" /></td>
    </tr>
    </table>
</td>
</tr>
<table>