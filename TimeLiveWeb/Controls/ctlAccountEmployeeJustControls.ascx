<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlAccountEmployeeJustControls.ascx.vb" Inherits="Controls_ctlAccountEmployeeJustControls" %>
<div>
    <table border="0" cellpadding="0" cellspacing="0" style="width: 92%; height: 2%">
        <tr>
            <td style="width: 115px">
                Login:</td>
            <td>
                <asp:TextBox ID="LoginTextBox" runat="server" Text='<%# Bind("Login") %>'></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 115px">
                Password:</td>
            <td>
                <asp:TextBox ID="PasswordTextBox" runat="server" Text='<%# Bind("Password") %>'></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 115px; height: 19px">
                Prefix:
            </td>
            <td style="height: 19px">
                <asp:TextBox ID="PrefixTextBox" runat="server" Text='<%# Bind("Prefix") %>' Width="88px"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 115px; height: 19px">
                FirstName:
            </td>
            <td style="height: 19px">
                <asp:TextBox ID="FirstNameTextBox" runat="server" Text='<%# Bind("FirstName") %>'></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 115px; height: 19px">
                MiddleName:
            </td>
            <td style="height: 19px">
                <asp:TextBox ID="MiddleNameTextBox" runat="server" Text='<%# Bind("MiddleName") %>'></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 115px; height: 19px">
                LastName:</td>
            <td style="height: 19px">
                <asp:TextBox ID="LastNameTextBox" runat="server" Text='<%# Bind("LastName") %>'></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 115px; height: 19px">
                EMailAddress:</td>
            <td style="height: 19px">
                <asp:TextBox ID="EMailAddressTextBox" runat="server" Text='<%# Bind("EMailAddress") %>'
                    Width="200px"></asp:TextBox></td>
        </tr>
    </table>
</div>
