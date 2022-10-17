<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlMyAccountEMailNotificationPreferenceList.ascx.vb" Inherits="Employee_Controls_ctlMyAccountEMailNotificationPreferenceList" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <table width="100%">
            <tr>
                <td style="width: 100%">
        <x:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Caption="My EMail Notification Preferences"
            DataKeyNames="AccountEMailNotificationPreferenceId,SystemEMailNotificationId,SystemEMailNotificationTypeId"
            DataSourceID="dsAccountEMailNotificationPreferenceObject"
            SkinID="xgridviewSkinEmployee" Width="98%" PageSize="500">
            <Columns>
                <asp:TemplateField SortExpression="SystemEMailNotification" HeaderText="<%$ Resources:TimeLive.Resource, EMail Notification %>">
                    <edititemtemplate>
<asp:TextBox id="TextBox1" runat="server" Text='<%# Bind("SystemEMailNotification") %>' __designer:wfdid="w133"></asp:TextBox> 
</edititemtemplate>
                    <headertemplate>
<asp:Label id="lblEmailNotification" runat="server" Text='<%# ResourceHelper.GetFromResource("EMail Notification") %>' __designer:wfdid="w136"></asp:Label>
</headertemplate>
                    <itemtemplate>
<asp:Label id="Label7" runat="server" Text='<%#GetGlobalResourceObject("TimeLive.Web", Eval("SystemEMailNotification"))%>' __designer:wfdid="w132"></asp:Label> 
</itemtemplate>
                    <itemstyle width="90%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Enable Disable %>">
                    <headertemplate>
<asp:Label id="lblEnableDisable" runat="server" Text='<%# ResourceHelper.GetFromResource("Enable / Disable") %>' __designer:wfdid="w138"></asp:Label>
</headertemplate>
                    <ItemTemplate>
<asp:CheckBox id="chkEnableDisable" runat="server" __designer:wfdid="w137" Checked='<%# IIF(IsDBNull(Eval("Enabled")),False,Eval("Enabled"))%>'></asp:CheckBox> 
</ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="8%" />
                </asp:TemplateField>
            </Columns>
        </x:GridView>
                </td>
            </tr>
        </table>
<asp:ObjectDataSource ID="dsAccountEMailNotificationPreferenceObject" runat="server"
    OldValuesParameterFormatString="original_{0}" SelectMethod="GetvueAccountEMailNotificationPreferencessByAccountEmployeeId"
    TypeName="AccountEMailNotificationPreferenceBLL">
    <SelectParameters>
        <asp:SessionParameter Name="AccountEmployeeId" SessionField="AccountEmployeeId" Type="Int32" />
        <asp:SessionParameter Name="AccountId" SessionField="AccountId" Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>
            <tr>
                <td style="width: 100px">
                    <div style="margin:5px;">
                    <asp:Button ID="btnUpdateEMailNotificationPreferences" runat="server" 
            OnClick="btnUpdateEMailNotificationPreferences_Click" 
            Text="<%$ Resources:TimeLive.Resource, Update EMail Notification Preferences%> " />
            </div></td>
                    
            </tr>
    </ContentTemplate>
</asp:UpdatePanel>
<br />
