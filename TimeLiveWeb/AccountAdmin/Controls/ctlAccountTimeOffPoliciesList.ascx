<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlAccountTimeOffPoliciesList.ascx.vb" Inherits="AccountAdmin_Controls_ctlAccountTimeOffPoliciesList" %>
<style type="text/css">
    .style1
    {
        width: 98%;
    }
</style>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
               <table width="98%">
            <tr>
                <td>
        <x:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="AccountTimeOffPolicyId"
            DataSourceID="dsAccountTimeOffPolicyGridViewObject" Width="98%" 
                        SkinID="xgridviewSkinEmployee" AllowSorting="True" 
                        Caption="<%$ Resources:TimeLive.Resource, Time Off Policy List %>">
            <Columns>
                <asp:BoundField DataField="AccountTimeOffPolicy" HeaderText="<%$ Resources:TimeLive.Resource, Time Off Policy%>" SortExpression="AccountTimeOffPolicy">
                    <ItemStyle Width="95%" />
                </asp:BoundField>
                <asp:TemplateField ShowHeader="False" HeaderText="Edit">
                    <itemstyle cssclass="edit_button" horizontalalign="Center" width="1%" VerticalAlign="Bottom" />
                    <headerstyle horizontalalign="Center" />
                    <itemtemplate>
<asp:LinkButton id="LinkButton2" runat="server" Text="<%$ Resources:TimeLive.Resource, Edit_text%>" CommandName="Select" CausesValidation="False" __designer:wfdid="w108" PostBackUrl='<%# Eval("AccountTimeOffPolicyId", "~/AccountAdmin/AccountTimeOffPoliciesDetail.aspx?AccountTimeOffPolicyId={0}") %>'></asp:LinkButton>
</itemtemplate>
                </asp:TemplateField>
        <asp:TemplateField ShowHeader="False" HeaderText="Delete">
            <ItemStyle HorizontalAlign="Center" Width="1%" cssclass="delete_button"  VerticalAlign="Bottom" />
            <HeaderStyle HorizontalAlign="Center" />
     <ItemTemplate>
<asp:LinkButton id="LinkButton1" runat="server" OnClientClick="<%# ResourceHelper.GetDeleteMessageJavascript()%>" CommandName="Delete" CausesValidation="False" __designer:wfdid="w105"></asp:LinkButton> 
</ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField>
            <HeaderTemplate>
<asp:Image id="Image2" runat="server" __designer:wfdid="w107" ToolTip="<%$ Resources:TimeLive.Resource, Disabled_text%> " ImageUrl="~/Images/Disabled.gif"></asp:Image> 
</HeaderTemplate>
            <ItemStyle HorizontalAlign="Center" Width="1%" />
            <ItemTemplate>
<asp:Image id="Image1" runat="server" __designer:wfdid="w106" ToolTip="<%$ Resources:TimeLive.Resource, Disabled_text%> " Visible='<%# IIF(IsDBNull(Eval("IsDisabled")),"False",Eval("IsDisabled")) %>' ImageUrl="~/Images/Disabled.gif"></asp:Image> 
</ItemTemplate>
        </asp:TemplateField>
            </Columns>
        </x:GridView>
        <br />
                    <table width="98.5%">
                        <tr>
                            <td align="right">
                                <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" 
                                    Text="<%$ Resources:TimeLive.Resource, Add_text %>" Width="68px" 
                                    UseSubmitBehavior="False" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <asp:ObjectDataSource ID="dsAccountTimeOffPolicyGridViewObject" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetAccountTimeOffPolicyByAccountId" TypeName="AccountTimeOffPolicyBLL">
            <SelectParameters>
                <asp:SessionParameter Name="AccountId" SessionField="AccountId" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </ContentTemplate>
</asp:UpdatePanel>
