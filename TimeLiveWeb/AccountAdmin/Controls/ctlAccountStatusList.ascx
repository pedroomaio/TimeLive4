<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlAccountStatusList.ascx.vb" Inherits="AccountAdmin_Controls_ctlAccountStatusList" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <x:GridView ID="GridView1" runat="server" Width="98%" DataSourceID="dsAccountStatusObject" AutoGenerateColumns="False" DataKeyNames="AccountStatusId" SkinID="xgridviewSkinEmployee" Caption='<%# ResourceHelper.GetFromResource("Status List") %>'>
            <Columns>
                <asp:BoundField DataField="AccountStatusId" HeaderText="<%$ Resources:TimeLive.Resource, Id %>" InsertVisible="False"
                    ReadOnly="True" SortExpression="AccountStatusId">
                    <ItemStyle Width="5%" HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Status Type %>"  SortExpression="SystemStatusType">
                    <edititemtemplate>
<asp:TextBox id="TextBox1" runat="server" Text='<%# Bind("SystemStatusType") %>' __designer:wfdid="w148"></asp:TextBox> 
</edititemtemplate>
                    <headertemplate>
<asp:LinkButton id="LinkButton3" runat="server" Text='<%# ResourceHelper.GetFromResource("Status Type") %>' CommandArgument="SystemStatusType" CommandName="Sort" CausesValidation="False"></asp:LinkButton>
</headertemplate>
                    <itemtemplate>
<asp:Label id="Label8" runat="server" Text='<%#GetGlobalResourceObject("TimeLive.Web", Eval("SystemStatusType"))%>' __designer:wfdid="w147"></asp:Label> 
</itemtemplate>
                    <headerstyle horizontalalign="Left" />
                    <itemstyle horizontalalign="Left" width="45%" />
                </asp:TemplateField>
                <asp:TemplateField SortExpression="Status" HeaderText="<%$ Resources:TimeLive.Resource, Status %>">
                    <edititemtemplate>
<asp:TextBox id="TextBox2" runat="server" __designer:wfdid="w96" Text='<%# Bind("Status") %>'></asp:TextBox> 
</edititemtemplate>
                    <headertemplate>
<asp:LinkButton id="LinkButton4" runat="server" __designer:wfdid="w97" Text='<%# ResourceHelper.GetFromResource("Status") %>' CausesValidation="False" CommandName="Sort" CommandArgument="Status"></asp:LinkButton> 
</headertemplate>
                    <itemtemplate>
<asp:Label id="Label9" runat="server" __designer:wfdid="w95" Text='<%# Bind("Status") %>'></asp:Label> 
</itemtemplate>
                    <headerstyle horizontalalign="Left" />
                    <itemstyle horizontalalign="Left" width="45%" />
                </asp:TemplateField>
                <asp:CommandField HeaderText="<%$ Resources:TimeLive.Resource, Edit_text %>" SelectText="Edit" ShowSelectButton="True">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle Width="1%" HorizontalAlign="Center" cssclass="edit_button"  />
                </asp:CommandField>
        <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Delete_text %>" ShowHeader="False">
     <ItemTemplate>
<asp:LinkButton id="LinkButton1" runat="server" __designer:wfdid="w1" Text="<%$ Resources:TimeLive.Resource, Delete_text %>" CausesValidation="False" CommandName="Delete" Visible='<%# IIF(Isdbnull(Eval("MasterAccountStatusId")),True,False) %>' OnClientClick="<%# ResourceHelper.GetDeleteMessageJavascript() %>"></asp:LinkButton> 
</ItemTemplate>
            <HeaderStyle HorizontalAlign="Center" />
            <ItemStyle HorizontalAlign="Center" Width="1%" cssclass="delete_button"  />
        </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>
<asp:Image id="Image1" runat="server" __designer:wfdid="w3" ToolTip="<%$ Resources:TimeLive.Resource, Disabled_text%> " ImageUrl="~/Images/Disabled.gif"></asp:Image> 
</HeaderTemplate>
                    <ItemTemplate>
<asp:Image id="Image1" runat="server" __designer:wfdid="w2" ToolTip="<%$ Resources:TimeLive.Resource, Disabled_text%> " Visible='<%# IIF(IsDBNull(Eval("IsDisabled")),"false",Eval("IsDisabled")) %>' ImageUrl="~/Images/Disabled.gif"></asp:Image> 
</ItemTemplate>
                <ItemStyle Width="1%" cssclass="status_button" />
                </asp:TemplateField>
            </Columns>
        </x:GridView>
        <asp:ObjectDataSource ID="dsAccountStatusObject" runat="server" DeleteMethod="DeleteAccountStatus" InsertMethod="AddAccountStatus" OldValuesParameterFormatString="original_{0}" SelectMethod="GetAccountStatusForSelectionByAccountId" TypeName="AccountStatusBLL" UpdateMethod="UpdateAccountStatus">
            <DeleteParameters>
                <asp:Parameter Name="Original_AccountStatusId" Type="Int32" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="AccountId" Type="Int32" />
                <asp:Parameter Name="Status" Type="String" />
                <asp:Parameter Name="StatusTypeId" Type="Int32" />
                <asp:Parameter Name="Original_AccountStatusId" Type="Int32" />
                <asp:Parameter Name="IsDisabled" Type="Boolean" />
            </UpdateParameters>
            <SelectParameters>
                <asp:SessionParameter DefaultValue="64" Name="AccountId" SessionField="AccountId"
                    Type="Int32" />
            </SelectParameters>
            <InsertParameters>
                <asp:Parameter Name="AccountId" Type="Int32" />
                <asp:Parameter Name="Status" Type="String" />
                <asp:Parameter Name="StatusTypeId" Type="Int32" />
            </InsertParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="dsAccountStatusFormObject" runat="server" DeleteMethod="DeleteAccountStatus" InsertMethod="AddAccountStatus" OldValuesParameterFormatString="original_{0}" SelectMethod="GetAccountsStatusByAccountStatusId" TypeName="AccountStatusBLL" UpdateMethod="UpdateAccountStatus">
            <DeleteParameters>
                <asp:Parameter Name="Original_AccountStatusId" Type="Int32" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:SessionParameter DefaultValue="64" Name="AccountId" SessionField="AccountId"
                    Type="Int32" />
                <asp:Parameter Name="Status" Type="String" />
                <asp:Parameter Name="StatusTypeId" Type="Int32" />
                <asp:Parameter Name="Original_AccountStatusId" Type="Int32" />
                <asp:Parameter Name="IsDisabled" Type="Boolean" />
            </UpdateParameters>
            <SelectParameters>
                <asp:ControlParameter ControlID="GridView1" Name="AccountStatusId" PropertyName="SelectedValue"
                    Type="Int32" />
            </SelectParameters>
            <InsertParameters>
                <asp:SessionParameter DefaultValue="64" Name="AccountId" SessionField="AccountId"
                    Type="Int32" />
                <asp:Parameter Name="Status" Type="String" />
                <asp:Parameter Name="StatusTypeId" Type="Int32" />
            </InsertParameters>
        </asp:ObjectDataSource>
    </ContentTemplate>
</asp:UpdatePanel>
<br />
<asp:UpdatePanel ID="UpdatePanel2" runat="server">
    <ContentTemplate>
        <asp:FormView ID="FormView1" runat="server" 
            DataSourceID="dsAccountStatusFormObject" DataKeyNames="AccountStatusId" 
            DefaultMode="Insert" SkinID="formviewSkinEmployee" Width="450px" 
            OnDataBound="FormView1_DataBound">
            <InsertItemTemplate>
                <table width="100%" class="xview">
                    <tr>
                        <th colspan="2" style="height: 21px" class="caption">
                            <asp:Literal ID="Literal1" runat="server" Text='<%# ResourceHelper.GetFromResource("Status Information")%> ' /></th>
                    </tr>
                    <tr>
                        <th colspan="2" class="FormViewSubHeader">
                            <asp:Literal ID="Literal2" runat="server" Text='<%# ResourceHelper.GetFromResource("Status")%> ' /></th>
                    </tr>
                    <tr>
                        <td style="width: 30%" align="right" class="FormViewLabelCell">
                                                                    <SPAN 
                  class=reqasterisk>*</SPAN> <asp:Literal ID="Literal3" runat="server" Text='<%# ResourceHelper.GetFromResource("Status Type:")%> ' /></td>
                        <td style="width: 50%">
                            <asp:DropDownList ID="DropDownList1" runat="server" 
                                SelectedValue='<%# Bind("StatusTypeId") %>' DataSourceID="dsStatusTypeObject" 
                                DataTextField="SystemStatusType" DataValueField="SystemStatusTypeId" 
                                Width="188px">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="DropDownList1"
                                Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td style="width: 30%" align="right" class="FormViewLabelCell">
                                                                    <SPAN 
                  class=reqasterisk>*</SPAN> 
<asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="StatusTextBox"><asp:Literal ID="Literal4" runat="server" Text='<%# ResourceHelper.GetFromResource("Status:")%> ' /></asp:Label></td><td style="width: 50%">
                            <asp:TextBox 
                                ID="StatusTextBox" runat="server" Text='<%# Bind("Status") %>' MaxLength="45" 
                                Width="176px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="StatusTextBox"
                                Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator></td></tr><tr>
                        <td style="width: 30%" align="right" class="formviewlabelcell">
                        </td>
                        <td style="width: 50%; padding-bottom: 5px;">
                            <asp:Button ID="Add" runat="server" CommandName="Insert" 
                                Text="<%$ Resources:TimeLive.Resource, Add_Text%> " Width="68px" /></td>
                    </tr>
                </table>
            </InsertItemTemplate>
            <EditItemTemplate><table width="100%" class="xview">
                <tr>
                    <th colspan="2" style="height: 21px" class="caption">
                        <asp:Literal ID="Literal1" runat="server" Text='<%# ResourceHelper.GetFromResource("Status Information")%> ' /></th>
                </tr>
                <tr>
                    <th colspan="2" class="FormViewSubHeader">
                        <asp:Literal ID="Literal6" runat="server" Text='<%# ResourceHelper.GetFromResource("Status")%> ' /></th>
                </tr>
                <tr>
                    <td style="width: 30%" align="right" class="formviewlabelcell">
                                                                <SPAN 
                  class=reqasterisk>*</SPAN><asp:Literal ID="Literal7" runat="server" Text='<%# ResourceHelper.GetFromResource("Status Type:")%> ' /></td>
                    <td style="width: 50%">
                        &nbsp;<asp:DropDownList ID="DropDownList1" runat="server" 
                                SelectedValue='<%# Bind("StatusTypeId") %>' DataSourceID="dsStatusTypeObject" 
                                DataTextField="SystemStatusType" DataValueField="SystemStatusTypeId" 
                                Enabled="False" Width="188px"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="DropDownList1"
                            Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator></td></tr><tr>
                    <td style="width: 30%" align="right" class="formviewlabelcell">
                                                                <SPAN 
                  class=reqasterisk>*</SPAN><asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="StatusTextBox"><asp:Literal ID="Literal8" runat="server" Text='<%# ResourceHelper.GetFromResource("Status:")%> ' /></asp:Label></td><td style="width: 50%">
                        &nbsp;<asp:TextBox 
                                ID="StatusTextBox" runat="server" Text='<%# Bind("Status") %>' MaxLength="45" 
                                Width="176px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="StatusTextBox"
                            Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator></td></tr><tr>
                    <td align="right" class="formviewlabelcell" style="width: 30%">
                    <asp:Literal ID="Literal5" runat="server" Text='<%# ResourceHelper.GetFromResource("Disabled:")%> ' /></td>
                    <td style="width: 50%">
                        <asp:CheckBox ID="CheckBox1" runat="server" 
                                Checked='<%# Bind("IsDisabled") %>' Width="168px" /></td>
                </tr>
                <tr>
                    <td style="width: 30%" align="right" class="formviewlabelcell">
                    </td>
                    <td style="width: 50%; padding-bottom: 5px;">
                        &nbsp;<asp:Button ID="Update" runat="server" CommandName="Update" 
                                Text="<%$ Resources:TimeLive.Resource, Update_Text%> " Width="68px" />&nbsp<asp:Button 
                                ID="Cancel" runat="server" CommandName="Cancel" 
                                Text="<%$ Resources:TimeLive.Resource, Cancel_Text%> " Width="68px" /></td>
                </tr>
            </table>
            </EditItemTemplate>
            <ItemTemplate>
                AccountStatusId: <asp:Label ID="AccountStatusIdLabel" runat="server" Text='<%# Eval("AccountStatusId") %>'>
                </asp:Label><br />AccountId: <asp:Label ID="AccountIdLabel" runat="server" Text='<%# Bind("AccountId") %>'></asp:Label><br />StatusTypeId: <asp:Label ID="StatusTypeIdLabel" runat="server" Text='<%# Bind("StatusTypeId") %>'>
                </asp:Label><br />Status: <asp:Label ID="StatusLabel" runat="server" Text='<%# Bind("Status") %>'></asp:Label><br /><asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" CommandName="Edit"
                    Text="Edit">
                </asp:LinkButton><asp:LinkButton ID="DeleteButton" runat="server" CausesValidation="False" CommandName="Delete"
                    Text="Delete">
                </asp:LinkButton><asp:LinkButton ID="NewButton" runat="server" CausesValidation="False" CommandName="New"
                    Text="New">
                </asp:LinkButton></ItemTemplate></asp:FormView><asp:ObjectDataSource ID="dsStatusTypeObject" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetStatusTypes" TypeName="SystemDataBLL"></asp:ObjectDataSource>
    </ContentTemplate>
</asp:UpdatePanel>
&nbsp; 