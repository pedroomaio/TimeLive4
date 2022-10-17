<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlAccountEMailNotificationPreferenceList.ascx.vb" Inherits="ProjectAdmin_Controls_ctlAccountEMailNotificationPreferenceList" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <table width="100%">
            <tr>
                <td style="width: 100%">
        <x:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Caption='<%# ResourceHelper.GetFromResource("EMail Notification Preferences") %>'
            DataKeyNames="AccountEMailNotificationPreferenceId,SystemEMailNotificationId,SystemEMailNotificationTypeId"
            DataSourceID="dsAccountEMailNotificationPreferenceObject"
            SkinID="xgridviewSkinEmployee" Width="98%" PageSize="25">
            <Columns>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, EMail Notification %>" SortExpression="SystemEMailNotification">
                    <edititemtemplate>
<asp:TextBox id="TextBox1" runat="server" Text='<%# Bind("SystemEMailNotification") %>' __designer:wfdid="w59"></asp:TextBox> 
</edititemtemplate>
                    <headertemplate>
<asp:Label id="lblEmailNotification" runat="server" Text='<%# ResourceHelper.GetFromResource("EMail Notification") %>' __designer:wfdid="w60"></asp:Label>
</headertemplate>
                    <itemtemplate>
<asp:Label id="Label7" runat="server" Text='<%#GetGlobalResourceObject("TimeLive.Web", Eval("SystemEMailNotification"))%>' __designer:wfdid="w58"></asp:Label> 
</itemtemplate>
                    <itemstyle width="90%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Enable Disable %>" >
                    <headertemplate>
<asp:Label id="lblEnableDisable" runat="server" Text='<%# ResourceHelper.GetFromResource("Enable / Disable") %>' __designer:wfdid="w62"></asp:Label>
</headertemplate>
                    <ItemTemplate>
<asp:CheckBox id="chkEnableDisable" runat="server" __designer:wfdid="w61" Checked='<%# IIF(Eval("Enabled")=True,True,False) %>'></asp:CheckBox> 
</ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="8%" />
                </asp:TemplateField>
            </Columns>
        </x:GridView>
                </td>
            </tr>
            <tr>
                <td style="width: 100px; padding-top: 5px";>
                    &nbsp;<asp:Button ID="btnUpdateEMailNotificationPreferences" runat="server" Text="<%$ Resources:TimeLive.Resource, Update Email Notification Preferences%>" OnClick="btnUpdateEMailNotificationPreferences_Click" /></td>
            </tr>
        </table>
<asp:ObjectDataSource ID="dsAccountEMailNotificationPreferenceObject" runat="server"
    OldValuesParameterFormatString="original_{0}" SelectMethod="GetvueAccountEMailNotificationPreferencessByAccountProjectId"
    TypeName="AccountEMailNotificationPreferenceBLL">
    <SelectParameters>
        <asp:QueryStringParameter Name="AccountProjectId" 
            QueryStringField="AccountProjectId" Type="Int32" />
        <asp:SessionParameter Name="AccountId" SessionField="AccountId" Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>
    </ContentTemplate>
</asp:UpdatePanel>
<br />
