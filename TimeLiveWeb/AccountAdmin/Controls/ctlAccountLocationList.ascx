<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlAccountLocationList.ascx.vb" Inherits="AccountAdmin_Controls_ctlAccountLocationList" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <x:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="AccountLocationId"
            DataSourceID="dsAccountLocationObject"  SkinID="xgridviewSkinEmployee" AllowSorting="True" Width="98%" Caption='<%# ResourceHelper.GetFromResource("Location List") %>' CssClass="tableView">
            <Columns>
                <asp:BoundField DataField="AccountLocationId" HeaderText="<%$ Resources:TimeLive.Resource, Id %>" InsertVisible="False"
                    ReadOnly="True" SortExpression="AccountLocationId" >
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle Width="5%" HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Location %>" SortExpression="AccountLocation">
                    <edititemtemplate>
<asp:TextBox id="TextBox1" runat="server" Text='<%# Bind("AccountLocation") %>' __designer:wfdid="w31"></asp:TextBox>
</edititemtemplate>
                    <headertemplate>

<asp:LinkButton id="LinkButton2" runat="server" Text='<%# ResourceHelper.GetFromResource("Location") %>' CommandArgument="AccountLocation" CommandName="Sort" CausesValidation="False"></asp:LinkButton>
</headertemplate>
                    <itemtemplate>
<asp:Label id="Label1" runat="server" Text='<%# Bind("AccountLocation") %>' __designer:wfdid="w30"></asp:Label>
</itemtemplate>
                    <headerstyle horizontalalign="Left" wrap="True" />
                    <itemstyle width="90%" />
                </asp:TemplateField>
                <asp:CommandField HeaderText="<%$ Resources:TimeLive.Resource, Edit_Text %>" SelectText="Edit" ShowSelectButton="True" >
                    <HeaderStyle />                    
                    <ItemStyle cssclass="edit_button" Width="1%" HorizontalAlign="Center" 
                        VerticalAlign="Middle" />                    
                </asp:CommandField>
        <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Delete_Text %>" ShowHeader="False">
     <ItemTemplate>
 
       <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete"
                    OnClientClick='<%# ResourceHelper.GetDeleteMessageJavascript()%>'
                    Text="<%$ Resources:TimeLive.Resource, Delete_Text%> " />
     
</ItemTemplate>
            <HeaderStyle HorizontalAlign="Center" />
            <ItemStyle HorizontalAlign="Center" Width="1%" cssclass="delete_button" />
        </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/Disabled.gif" ToolTip="<%$ Resources:TimeLive.Resource, Disabled_text%> " />
                    
</HeaderTemplate>
                    <ItemTemplate>
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/Disabled.gif" Visible='<%# IIF(IsDBNull(Eval("IsDisabled")),"false",Eval("IsDisabled")) %>' ToolTip="<%$ Resources:TimeLive.Resource, Disabled_text%> " />
                    
</ItemTemplate>
<ItemStyle HorizontalAlign="Center" Width="1%" />
                </asp:TemplateField>
            </Columns>
        </x:GridView>
        <asp:ObjectDataSource ID="dsAccountLocationObject" runat="server" DeleteMethod="DeleteAccountLocation"
            InsertMethod="AddAccountLocation" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetAccountLocationsByAccountId" TypeName="AccountLocationBLL" UpdateMethod="UpdateAccountLocation">
            <DeleteParameters>
                <asp:Parameter Name="original_AccountLocationId" Type="Int32" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="AccountId" Type="Int32" />
                <asp:Parameter Name="AccountLocation" Type="String" />
                <asp:Parameter Name="original_AccountLocationId" Type="Int32" />
                <asp:Parameter Name="ModifiedOn" Type="DateTime" />
                <asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" />
                <asp:Parameter Name="IsDisabled" Type="Boolean" />
            </UpdateParameters>
            <SelectParameters>
                <asp:SessionParameter DefaultValue="23" Name="AccountId" SessionField="AccountId"
                    Type="Int32" />
            </SelectParameters>
            <InsertParameters>
                <asp:Parameter Name="AccountId" Type="Int32" />
                <asp:Parameter Name="AccountLocation" Type="String" />
                <asp:Parameter Name="CreatedByEmployeeId" Type="Int32" />
                <asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" />
            </InsertParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="dsAccountLocationFormObject" runat="server" DeleteMethod="DeleteAccountLocation"
            InsertMethod="AddAccountLocation" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetAccountLocationsByAccountLocationId" TypeName="AccountLocationBLL"
            UpdateMethod="UpdateAccountLocation">
            <DeleteParameters>
                <asp:Parameter Name="original_AccountLocationId" Type="Int32" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:SessionParameter DefaultValue="23" Name="AccountId" SessionField="AccountId"
                    Type="Int32" />
                <asp:Parameter Name="AccountLocation" Type="String" />
                <asp:Parameter Name="original_AccountLocationId" Type="Int32" />
                <asp:Parameter Name="ModifiedOn" Type="DateTime" />
                <asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" />
                <asp:Parameter Name="IsDisabled" Type="Boolean" />
            </UpdateParameters>
            <SelectParameters>
                <asp:ControlParameter ControlID="GridView1" Name="AccountLocationId" PropertyName="SelectedValue"
                    Type="Int32" />
            </SelectParameters>
            <InsertParameters>
                <asp:SessionParameter DefaultValue="23" Name="AccountId" SessionField="AccountId"
                    Type="Int32" />
                <asp:Parameter Name="AccountLocation" Type="String" />
                <asp:Parameter Name="CreatedByEmployeeId" Type="Int32" />
                <asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" />
            </InsertParameters>
        </asp:ObjectDataSource>
    </ContentTemplate>
</asp:UpdatePanel>
&nbsp;<asp:UpdatePanel ID="UpdatePanel2" runat="server">
    <ContentTemplate>
        <asp:FormView ID="FormView1" runat="server" DataKeyNames="AccountLocationId" DataSourceID="dsAccountLocationFormObject"
            DefaultMode="Insert" SkinID="formviewSkinEmployee" Width="416px" OnDataBound="FormView1_DataBound">
            <EditItemTemplate> 
                <table  width="100%" class="xview">
                    <tr>
                        <th class="caption" colspan="2" style="width: 20%; height: 21px">
                            <asp:Literal ID="Literal1" runat="server" Text='<%# ResourceHelper.GetFromResource("Location Information")%> ' /></th>
                    </tr>
                    <tr>
                        <th class="FormViewSubHeader" colspan="2" style="width: 20%; height: 21px">
                            <asp:Literal ID="Literal2" runat="server" Text='<%# ResourceHelper.GetFromResource("Location")%> ' /></th>
                    </tr>
                    <tr>
                        <td class="FormViewLabelCell" style="width: 30%; height: 26px;" align="right">
                            <SPAN 
                  class=reqasterisk>*</SPAN><asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="AccountLocationTextBox">
                  <asp:Literal ID="Literal4" runat="server" Text='<%# ResourceHelper.GetFromResource("Location:")%> ' /></asp:Label></td><td style="width: 75%; height: 26px;">
                            <asp:TextBox 
                                ID="AccountLocationTextBox" runat="server" 
                                Text='<%# Bind("AccountLocation") %>' MaxLength="50" Width="176px"></asp:TextBox><asp:RequiredFieldValidator
                                ID="RequiredFieldValidator1" runat="server" ControlToValidate="AccountLocationTextBox"
                                Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator></td></tr><tr>
                        <td class="FormViewLabelCell" style="width: 30%; height: 26px" align="right">
                            <asp:Literal ID="Literal5" runat="server" Text="<%$ Resources:TimeLive.Resource, Disabled:%> " /></td>
                        <td style="width: 75%; height: 26px">
                            <asp:CheckBox ID="CheckBox1" runat="server" Checked='<%# Bind("IsDisabled") %>'/></td>
                    </tr>
                    <tr>
                        <td style="width: 20%; height: 26px;">
                        </td>
                        <td style="width: 75%; height: 26px; padding-bottom: 5px;">
                            <asp:Button ID="Update" runat="server" CommandName="Update" Text="<%$ Resources:TimeLive.Resource, Update_text%> " Width="68px" />
                            <asp:Button ID="Cancel" runat="server" CommandName="Cancel" Text="<%$ Resources:TimeLive.Resource, Cancel_text%> " Width="68px" /></td>
                    </tr>
                </table>
            </EditItemTemplate>
            <InsertItemTemplate>
                <table width="100%" class="xview">
                    <tr>
                        <th class="caption" colspan="2" style="height: 21px" width="30%">
                            <asp:Literal ID="Literal1" runat="server" Text='<%# ResourceHelper.GetFromResource("Location Information")%> ' /></th>
                    </tr>
                    <tr>
                        <th class="FormViewSubHeader" colspan="2" style="height: 21px" width="30%">
                        <asp:Literal ID="Literal3" runat="server" Text='<%# ResourceHelper.GetFromResource("Location")%> ' /></th>
                    </tr>
                    <tr>
                        <td class="FormViewLabelCell" style="height: 26px;" width="30%" align="right">
                            <SPAN 
                  class=reqasterisk>*</SPAN><asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="AccountLocationTextBox">
                  <asp:Literal ID="Literal2" runat="server" Text='<%# ResourceHelper.GetFromResource("Location:")%> ' /></asp:Label></td><td style="width: 75%; height: 26px;">
                            <asp:TextBox 
                                ID="AccountLocationTextBox" runat="server" 
                                Text='<%# Bind("AccountLocation") %>' MaxLength="50" Width="176px"></asp:TextBox><asp:RequiredFieldValidator
                                ID="RequiredFieldValidator1" runat="server" ControlToValidate="AccountLocationTextBox"
                                Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator></td></tr><tr>
                        <td style="height: 26px;" class="formviewlabelcell" width="30%">
                        </td>
                        <td style="width: 75%; height: 26px; padding-bottom: 5px;">
                            <asp:Button ID="Add" runat="server" CommandName="Insert" Text="<%$ Resources:TimeLive.Resource, Add_text%> " Width="68px" /></td>
                    </tr>
                </table>
            </InsertItemTemplate>
            <ItemTemplate>
                AccountLocationId: <asp:Label ID="AccountLocationIdLabel" runat="server" Text='<%# Eval("AccountLocationId") %>'>
                </asp:Label><br />AccountId: <asp:Label ID="AccountIdLabel" runat="server" Text='<%# Bind("AccountId") %>'></asp:Label><br />AccountLocation: <asp:Label ID="AccountLocationLabel" runat="server" Text='<%# Bind("AccountLocation") %>'>
                </asp:Label><br /><asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" CommandName="Edit"
                    Text="Edit">
                </asp:LinkButton><asp:LinkButton ID="DeleteButton" runat="server" CausesValidation="False" CommandName="Delete"
                    Text="Delete">
                </asp:LinkButton><asp:LinkButton ID="NewButton" runat="server" CausesValidation="False" CommandName="New"
                    Text="New">
                </asp:LinkButton></ItemTemplate></asp:FormView></ContentTemplate></asp:UpdatePanel>