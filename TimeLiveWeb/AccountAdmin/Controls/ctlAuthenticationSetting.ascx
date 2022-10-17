<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlAuthenticationSetting.ascx.vb" Inherits="AccountAdmin_Controls_ctlAuthenticationSetting" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <asp:FormView ID="FormView1" runat="server" DataKeyNames="AuthenticationSettingId"
            DataSourceID="dsAuthenticationSettingFormViewObject" DefaultMode="Edit" Width="500px" SkinID="formviewSkinEmployee">
            <EditItemTemplate>
                <table width="100%" class="xview">
                    <tr>
                        <td colspan="2" class="caption">
                            Authentication Mode Information</td>
                    </tr>
                    <tr>
                        <td class="FormviewSubHeader" colspan="2" >
                            Authentication Mode</td>
                    </tr>
                    <tr>
                        <td align="right" width="45%" class="FormViewlabelcell">
                            Active Directory Authentication:
                        </td>
                        <td width="55%">
                            <asp:CheckBox ID="chkActiveDirectoryAuthentication" runat="server" Checked='<%# Bind("ActiveDirectoryAuthentication") %>' OnCheckedChanged="chkActiveDirectoryAuthentication_CheckedChanged" /></td>
                    </tr>
                    <tr>
                        <td align="right" width="45%" class="FormViewlabelcell">
                            Domain:
                        </td>
                        <td width="55%">
                            <asp:TextBox ID="DomainTextBox" runat="server" Text='<%# Bind("Domain") %>'></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td align="right" width="45%" class="FormViewlabelcell">
                            DirectoryName:</td>
                        <td width="55%">
                            <asp:TextBox ID="DirectoryNameTextBox" runat="server" Text='<%# Bind("DirectoryName") %>'></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td width="45%">
                        </td>
                        <td width="55%">
                            <asp:Button ID="btnUpdate" runat="server" Text="Update" Width="68px" />
                            <asp:Button ID="Button2" runat="server" Text="Cancel" OnClick="Button2_Click" Width="68px" /></td>
                    </tr>
                </table>
            </EditItemTemplate>
            <InsertItemTemplate>
                AccountId:
                <asp:TextBox ID="AccountIdTextBox" runat="server" Text='<%# Bind("AccountId") %>'>
                </asp:TextBox><br />
                ActiveDirectoryAuthentication:
                <asp:CheckBox ID="ActiveDirectoryAuthenticationCheckBox" runat="server" Checked='<%# Bind("ActiveDirectoryAuthentication") %>' /><br />
                Domain:
                <asp:TextBox ID="DomainTextBox" runat="server" Text='<%# Bind("Domain") %>'>
                </asp:TextBox><br />
                DirectoryName:
                <asp:TextBox ID="DirectoryNameTextBox" runat="server" Text='<%# Bind("DirectoryName") %>'>
                </asp:TextBox><br />
                <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert"
                    Text="Insert">
                </asp:LinkButton>
                <asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False" CommandName="Cancel"
                    Text="Cancel">
                </asp:LinkButton>
            </InsertItemTemplate>
            <ItemTemplate>
                AuthenticationSettingId:
                <asp:Label ID="AuthenticationSettingIdLabel" runat="server" Text='<%# Eval("AuthenticationSettingId") %>'>
                </asp:Label><br />
                AccountId:
                <asp:Label ID="AccountIdLabel" runat="server" Text='<%# Bind("AccountId") %>'></asp:Label><br />
                ActiveDirectoryAuthentication:
                <asp:CheckBox ID="ActiveDirectoryAuthenticationCheckBox" runat="server" Checked='<%# Bind("ActiveDirectoryAuthentication") %>'
                    Enabled="false" /><br />
                Domain:
                <asp:Label ID="DomainLabel" runat="server" Text='<%# Bind("Domain") %>'></asp:Label><br />
                DirectoryName:
                <asp:Label ID="DirectoryNameLabel" runat="server" Text='<%# Bind("DirectoryName") %>'>
                </asp:Label><br />
                <asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" CommandName="Edit"
                    Text="Edit">
                </asp:LinkButton>
            </ItemTemplate>
        </asp:FormView>
        <asp:ObjectDataSource ID="dsAuthenticationSettingFormViewObject" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetAuthenticationByAccount" TypeName="AuthenticationBLL" UpdateMethod="UpdateAuthenticationSetting">
            <SelectParameters>
                <asp:SessionParameter Name="AccountId" SessionField="AccountId" Type="Int32" />
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter Name="Original_AccountId" Type="Int32" />
                <asp:Parameter Name="ActiveDirectoryAuthentication" Type="Double" />
                <asp:Parameter Name="Domain" Type="String" />
                <asp:Parameter Name="DirectoryName" Type="String" />
            </UpdateParameters>
        </asp:ObjectDataSource>
    </ContentTemplate>
</asp:UpdatePanel>
