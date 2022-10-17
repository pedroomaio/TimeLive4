<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlAccountEMailNotificationPreferenceList.ascx.vb" Inherits="AccountAdmin_Controls_ctlAccountEMailNotificationPreferenceList" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <table width="100%" >
            <tr>
                <td style="width: 100%">
        <x:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Caption="<%$ Resources:TimeLive.Resource, EMail Notification Preferences %>"
            DataKeyNames="AccountEMailNotificationPreferenceId,SystemEMailNotificationId,SystemEMailNotificationTypeId,IsWeekDayAllow"
            DataSourceID="dsAccountEMailNotificationPreferenceObject" PageSize="500"
            SkinID="xgridviewSkinEmployee" Width="98%" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            <Columns>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, EMail Notification %>" SortExpression="SystemEMailNotification">
                    <edititemtemplate>
<asp:TextBox id="TextBox1" runat="server" Text='<%# Bind("SystemEMailNotification") %>' __designer:wfdid="w171"></asp:TextBox> 
</edititemtemplate>
                    <headertemplate>
<asp:LinkButton id="LinkButton3" runat="server" Text='<%# ResourceHelper.GetFromResource("EMail Notification") %>' CommandArgument="SystemEMailNotification" CommandName="Sort" CausesValidation="False"></asp:LinkButton>
</headertemplate>
                    <itemtemplate>
<asp:Label id="Label7" runat="server" Text='<%#GetGlobalResourceObject("TimeLive.Web", Eval("SystemEMailNotification"))%>' __designer:wfdid="w170"></asp:Label> 
</itemtemplate>
                    <itemstyle width="81%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText= "<%$ Resources:TimeLive.Resource, Enable Disable %>" >
                    <headertemplate>
<asp:Label id="lblEnableDisable" runat="server" Text='<%# ResourceHelper.GetFromResource("Enable / Disable") %>' __designer:wfdid="w9"></asp:Label> 
</headertemplate>
                    <ItemTemplate>
<asp:CheckBox id="chkEnableDisable" runat="server" Checked='<%# IIF(Eval("Enabled")=True,True,False) %>' __designer:wfdid="w8"></asp:CheckBox> 
</ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Mon %>">
                    <itemtemplate>
<asp:CheckBox id="chkMonday" runat="server" Checked='<%# IIF(IsDBNull(Eval("Monday")),False,Eval("Monday")) %>' __designer:wfdid="w31"></asp:CheckBox>
</itemtemplate>
 <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="1%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Tue %>">
                    <itemtemplate>
<asp:CheckBox id="chkTuesday" runat="server" Checked='<%# IIF(IsDBNull(Eval("Tuesday")),False,Eval("Tuesday")) %>' __designer:wfdid="w32"></asp:CheckBox>
</itemtemplate>
 <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="1%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Wed %>">
                    <itemtemplate>
<asp:CheckBox id="chkWednesday" runat="server" Checked='<%# IIF(IsDBNull(Eval("Wednesday")),False,Eval("Wednesday")) %>' __designer:wfdid="w33"></asp:CheckBox>
</itemtemplate>
 <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="1%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Thu %>">
                    <itemtemplate>
<asp:CheckBox id="chkThursday" runat="server" Checked='<%# IIF(IsDBNull(Eval("Thursday")),False,Eval("Thursday")) %>' __designer:wfdid="w34"></asp:CheckBox>
</itemtemplate>
 <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="1%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Fri %>">
                    <itemtemplate>
<asp:CheckBox id="chkFriday" runat="server" Checked='<%# IIF(IsDBNull(Eval("Friday")),False,Eval("Friday")) %>' __designer:wfdid="w36"></asp:CheckBox>
</itemtemplate>
 <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="1%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Sat %>">
                    <itemtemplate>
<asp:CheckBox id="chkSaturday" runat="server" Checked='<%# IIF(IsDBNull(Eval("Saturday")),False,Eval("Saturday")) %>' __designer:wfdid="w38"></asp:CheckBox>
</itemtemplate>
 <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="1%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Sun %>">
                    <itemtemplate>
<asp:CheckBox id="chkSunday" runat="server" Checked='<%# IIF(IsDBNull(Eval("Sunday")),False,Eval("Sunday")) %>' __designer:wfdid="w40"></asp:CheckBox>
</itemtemplate>
 <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="1%" />
                </asp:TemplateField>
            </Columns>
        </x:GridView>
                </td>
            </tr>
            <tr>
                <td style="width: 100px">
                    <div style="margin:5px;">
                    <asp:Button ID="btnUpdateEMailNotificationPreferences" runat="server" 
                            Text="<%$ Resources:TimeLive.Resource, Update Email Notification Preferences%> " 
                            OnClick="btnUpdateEMailNotificationPreferences_Click" 
                            UseSubmitBehavior="False" />
                    </div></td>
                    
            </tr>
        </table>
<asp:ObjectDataSource ID="dsAccountEMailNotificationPreferenceObject" runat="server"
    OldValuesParameterFormatString="original_{0}" SelectMethod="GetvueAccountEMailNotificationPreferencessByAccountId"
    TypeName="AccountEMailNotificationPreferenceBLL" DeleteMethod="DeleteAccountEMailNotificationPreference" InsertMethod="AddAccountEMailNotificationPreference" UpdateMethod="UpdateAccountEMailNotificationPreference">
    <SelectParameters>
        <asp:SessionParameter DefaultValue="151" Name="AccountId" SessionField="AccountId"
            Type="Int32" />
    </SelectParameters>
    <DeleteParameters>
        <asp:Parameter Name="Original_AccountEMailNotificationPreferenceId" Type="Int32" />
    </DeleteParameters>
    <UpdateParameters>
        <asp:Parameter Name="AccountId" Type="Int32" />
        <asp:Parameter Name="AccountProjectId" Type="Int32" />
        <asp:Parameter Name="AccountEmployeeId" Type="Int32" />
        <asp:Parameter Name="SystemEMailNotificationid" Type="Int16" />
        <asp:Parameter Name="SystemEMailNotificationTypeId" Type="Int16" />
        <asp:Parameter Name="Enabled" Type="Boolean" />
        <asp:Parameter Name="Original_AccountEMailNotificationPreferenceId" Type="Int32" />
        <asp:Parameter Name="Monday" Type="Boolean" />
        <asp:Parameter Name="Tuesday" Type="Boolean" />
        <asp:Parameter Name="Wednesday" Type="Boolean" />
        <asp:Parameter Name="Thursday" Type="Boolean" />
        <asp:Parameter Name="Friday" Type="Boolean" />
        <asp:Parameter Name="Saturday" Type="Boolean" />
        <asp:Parameter Name="Sunday" Type="Boolean" />
    </UpdateParameters>
    <InsertParameters>
        <asp:Parameter Name="AccountId" Type="Int32" />
        <asp:Parameter Name="AccountProjectId" Type="Int32" />
        <asp:Parameter Name="AccountEmployeeId" Type="Int32" />
        <asp:Parameter Name="SystemEMailNotificationid" Type="Int16" />
        <asp:Parameter Name="SystemEMailNotificationTypeId" Type="Int16" />
        <asp:Parameter Name="Enabled" Type="Boolean" />
    </InsertParameters>
</asp:ObjectDataSource>
    </ContentTemplate>
</asp:UpdatePanel>
