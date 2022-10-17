<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlAccountApprovalList.ascx.vb" Inherits="AccountAdmin_Controls_ctlAccountApprovalList" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <table width="100%" id="TABLE1">
            <tr>
                <td>
                    <x:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                        DataSourceID="dsAccountApprovalObject" 
                        Caption='<%# ResourceHelper.GetFromResource("Approval Type List") %>' 
                        DataKeyNames="AccountApprovalTypeId" SkinID="xgridviewSkinEmployee" Width="98%">
                        <Columns>
                            <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Approval Type Name %>" SortExpression="ApprovalTypeName">
                                <edititemtemplate>
<asp:TextBox id="TextBox1" runat="server" Text='<%# Bind("ApprovalTypeName") %>' __designer:wfdid="w42"></asp:TextBox>
</edititemtemplate>
                                <headertemplate>
<asp:LinkButton id="LinkButton3" runat="server" Text='<%# ResourceHelper.GetFromResource("Approval Type Name") %>' CommandArgument="ApprovalTypeName" CommandName="Sort" CausesValidation="False"></asp:LinkButton>
</headertemplate>
                                <itemtemplate>
<asp:Label id="Label1" runat="server" Text='<%# Bind("ApprovalTypeName") %>' __designer:wfdid="w41"></asp:Label>
</itemtemplate>
                                <itemstyle width="88%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Time Off Approval %>" SortExpression="IsTimeOffApprovalTypes">
                                <itemtemplate>
<asp:Label id="lblIsTimeOff" runat="server" __designer:wfdid="w1"></asp:Label>
</itemtemplate>
                                <itemstyle horizontalalign="Center" Width="8%" />
                            </asp:TemplateField>
                            <asp:HyperLinkField DataNavigateUrlFields="AccountApprovalTypeId" DataNavigateUrlFormatString="~/AccountAdmin/AccountApproval.aspx?AccountApprovalTypeId={0}"
                                HeaderText="<%$ Resources:TimeLive.Resource, Edit_text %>" Text="<%$ Resources:TimeLive.Resource, Edit_text %>">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="1%"  
                                cssclass="edit_button" />
                            </asp:HyperLinkField>
                            <asp:CommandField HeaderText="<%$ Resources:TimeLive.Resource, Delete_text %>" ShowDeleteButton="True">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="1%"  
                                cssclass="delete_button"  />
                            </asp:CommandField>
                        </Columns>
                    </x:GridView>
                    <asp:ObjectDataSource ID="dsAccountApprovalObject" runat="server" OldValuesParameterFormatString="original_{0}"
                        SelectMethod="GetvueAccountApprovalsByAccountId" TypeName="AccountApprovalBLL" DeleteMethod="DeleteAccountApprovals">
                        <SelectParameters>
                            <asp:SessionParameter DefaultValue="64" Name="AccountId" SessionField="AccountId"
                                Type="Int32" />
                        </SelectParameters>
                        <DeleteParameters>
                            <asp:Parameter Name="Original_AccountApprovalTypeId" Type="Int32" />
                        </DeleteParameters>
                    </asp:ObjectDataSource>
        <br />
              <table style="width: 98%">
                     <tr>
                        <td align="right" >
                    <asp:Button ID="btnAdd" runat="server" 
                    Text="<%$ Resources:TimeLive.Resource, Add_text%>" Width="68px" 
                    UseSubmitBehavior="False" /></td>
                     </tr>
              </table>
                  </td>
            </tr>
        </table>
    </ContentTemplate>
</asp:UpdatePanel>
