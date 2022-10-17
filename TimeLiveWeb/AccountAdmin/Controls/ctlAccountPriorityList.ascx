<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlAccountPriorityList.ascx.vb" Inherits="AccountAdmin_Controls_ctlAccountPriorityList" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <x:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="AccountPriorityId"
            DataSourceID="dsAccountPriorityObject"  SkinID="xgridviewSkinEmployee" AllowSorting="True" Width="98%" Caption='<%# ResourceHelper.GetFromResource("Priority List") %>' CssClass="tableView">
            <Columns>
                <asp:TemplateField InsertVisible="False" SortExpression="AccountPriorityId" HeaderText="<%$ Resources:TimeLive.Resource, Id %>">
                    <edititemtemplate>
<asp:Label id="Label1" runat="server" Text='<%# Eval("AccountPriorityId") %>' __designer:wfdid="w61"></asp:Label>
</edititemtemplate>
                    <headertemplate>
<asp:LinkButton id="LinkButton3" runat="server" Text='<%# ResourceHelper.GetFromResource("Id") %>' CommandArgument="AccountPriorityId" CommandName="Sort" CausesValidation="False"></asp:LinkButton>
</headertemplate>
                    <itemtemplate>
<asp:Label id="Label1" runat="server" Text='<%# Bind("AccountPriorityId") %>' __designer:wfdid="w60"></asp:Label>
</itemtemplate>
                    <itemstyle horizontalalign="Center" width="5%" />
                </asp:TemplateField>
                <asp:TemplateField SortExpression="Priority" HeaderText="<%$ Resources:TimeLive.Resource, Priority %>" >
                    <edititemtemplate>
<asp:TextBox id="TextBox1" runat="server" Text='<%# Bind("Priority") %>' __designer:wfdid="w64"></asp:TextBox>
</edititemtemplate>
                    <headertemplate>
<asp:LinkButton id="LinkButton4" runat="server" Text='<%# ResourceHelper.GetFromResource("Priority") %>' CommandArgument="Priority" CommandName="Sort" CausesValidation="False"></asp:LinkButton>
</headertemplate>
                    <itemtemplate>
<asp:Label id="Label2" runat="server" Text='<%# Bind("Priority") %>' __designer:wfdid="w63"></asp:Label>
</itemtemplate>
                    <headerstyle horizontalalign="Left" wrap="True" />
                    <itemstyle width="90%" />
                </asp:TemplateField>
                <asp:CommandField HeaderText="<%$ Resources:TimeLive.Resource, Edit_text %>" SelectText="Edit" ShowSelectButton="True" >
                    <ItemStyle HorizontalAlign="Center" cssclass="edit_button" Width="1%"/>
                </asp:CommandField>
        <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Delete_text %>" ShowHeader="False">
     <ItemTemplate>
 
       <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete"
                    OnClientClick='<%# ResourceHelper.GetDeleteMessageJavascript()%>'
                    Text="<%$ Resources:TimeLive.Resource, Delete_text%> " />
     
</ItemTemplate>
            <HeaderStyle HorizontalAlign="Center" />
            <ItemStyle HorizontalAlign="Center" cssclass="delete_button" Width="1%"  />
        </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/Disabled.gif" ToolTip="<%$ Resources:TimeLive.Resource, Disabled_text%> " />
                    
</HeaderTemplate>
                    <ItemTemplate>
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/Disabled.gif" Visible='<%# IIF(IsDBNull(Eval("IsDisabled")),"false",Eval("IsDisabled")) %>' ToolTip="<%$ Resources:TimeLive.Resource, Disabled_text%> " />
                    
</ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="1%"/>
                </asp:TemplateField>
            </Columns>
        </x:GridView>
        <asp:ObjectDataSource ID="dsAccountPriorityObject" runat="server" DeleteMethod="DeleteAccountPriority" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetAccountPrioritiesByAccountId" TypeName="AccountPriorityBLL" InsertMethod="AddAccountPriority" UpdateMethod="UpdateAccountPriority">
            <DeleteParameters>
                <asp:Parameter Name="original_AccountPriorityId" Type="Int32" />
            </DeleteParameters>
            <SelectParameters>
                <asp:SessionParameter DefaultValue="99" Name="AccountId" SessionField="AccountId"
                    Type="Int32" />
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter Name="AccountId" Type="Int32" />
                <asp:Parameter Name="Priority" Type="String" />
                <asp:Parameter Name="PriorityOrder" Type="Byte" />
                <asp:Parameter Name="Original_AccountPriorityId" Type="Int32" />
                <asp:Parameter Name="IsDisabled" Type="Boolean" />
            </UpdateParameters>
            <InsertParameters>
                <asp:Parameter Name="AccountId" Type="Int32" />
                <asp:Parameter Name="Priority" Type="String" />
                <asp:Parameter Name="PriorityOrder" Type="Byte" />
            </InsertParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="dsAccountPriorityFormObject" runat="server" DeleteMethod="DeleteAccountPriority" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetAccountPrioritiesByAccountPriorityId" TypeName="AccountPriorityBLL" InsertMethod="AddAccountPriority" UpdateMethod="UpdateAccountPriority" OnInserting="dsAccountPriorityFormObject_Inserting">
            <DeleteParameters>
                <asp:Parameter Name="original_AccountPriorityId" Type="Int32" />
            </DeleteParameters>
            <SelectParameters>
                <asp:ControlParameter ControlID="GridView1" Name="AccountPriorityId" PropertyName="SelectedValue"
                    Type="Int32" />
            </SelectParameters>
            <UpdateParameters>
                <asp:SessionParameter DefaultValue="64" Name="AccountId" SessionField="AccountId"
                    Type="Int32" />
                <asp:Parameter Name="Priority" Type="String" />
                <asp:Parameter Name="PriorityOrder" Type="Byte" />
                <asp:Parameter Name="Original_AccountPriorityId" Type="Int32" />
                <asp:Parameter Name="IsDisabled" Type="Boolean" />
            </UpdateParameters>
            <InsertParameters>
                <asp:SessionParameter DefaultValue="64" Name="AccountId" SessionField="AccountId"
                    Type="Int32" />
                <asp:Parameter Name="Priority" Type="String" />
                <asp:Parameter Name="PriorityOrder" Type="Byte" />
            </InsertParameters>
        </asp:ObjectDataSource>
    </ContentTemplate>
</asp:UpdatePanel>
&nbsp;<asp:UpdatePanel ID="UpdatePanel2" runat="server">
    <ContentTemplate>
        <asp:FormView ID="FormView1" runat="server" DataKeyNames="AccountPriorityId" DataSourceID="dsAccountPriorityFormObject"
            DefaultMode="Insert" SkinID="formviewSkinEmployee" Width="450px" 
            OnDataBound="FormView1_DataBound">
            <EditItemTemplate>
                <table  width="100%" class="xview">
                    <tr>
                        <th class="caption" colspan="2" style="width: 20%; height: 21px">
                            <asp:Literal ID="Literal5" runat="server" Text='<%# ResourceHelper.GetFromResource("Priority Information")%> ' /></th>
                    </tr>
                    <tr>
                        <th class="FormViewSubHeader" colspan="2" style="width: 20%; height: 21px">
                            <asp:Literal ID="Literal1" runat="server" Text='<%# ResourceHelper.GetFromResource("Priority")%> ' /></th>
                    </tr>
                    <tr>
                        <td class="FormViewLabelCell" style="width: 30%; height: 26px;" align="right">
                            <SPAN 
                  class=reqasterisk>*</SPAN> 
                  
<asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="AccountPriorityTextBox">
                  <asp:Literal ID="Literal3" runat="server" Text='<%# ResourceHelper.GetFromResource("Priority:")%> ' /></asp:Label></td><td style="width: 75%; height: 26px;">
                            <asp:TextBox 
                                ID="AccountPriorityTextBox" runat="server" Text='<%# Bind("Priority") %>' 
                                MaxLength="50" Width="176px"></asp:TextBox><asp:RequiredFieldValidator
                                ID="RequiredFieldValidator1" runat="server" ControlToValidate="AccountPriorityTextBox"
                                Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator></td></tr><tr>
                        <td align="right" class="FormViewLabelCell" style="width: 30%; height: 26px">
                                                        <SPAN 
                  class=reqasterisk>*</SPAN><asp:Label ID="Label3" runat="server" AssociatedControlID="PriorityTextBox">
                  <asp:Literal ID="Literal4" runat="server" Text='<%# ResourceHelper.GetFromResource("Priority Order:")%> ' /></asp:Label></td><td style="width: 75%; height: 26px">
                            <asp:TextBox 
                                ID="PriorityTextBox" runat="server" MaxLength="50" 
                                Text='<%# Bind("PriorityOrder") %>' Width="176px"></asp:TextBox><asp:RequiredFieldValidator
                                ID="RequiredFieldValidator3" runat="server" ControlToValidate="PriorityTextBox"
                                Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="PriorityTextBox"
                                CssClass="ErrorMessage" Display="Dynamic" ErrorMessage="Numeric Required" MaximumValue="255"
                                MinimumValue="0" Type="Integer"></asp:RangeValidator></td></tr><tr>
                        <td align="right" class="FormViewLabelCell" style="width: 30%; height: 26px">
                            <asp:Literal ID="Literal2" runat="server" Text="<%$ Resources:TimeLive.Resource, Disabled_text%> " />: </td><td style="width: 75%; height: 26px">
                            <asp:CheckBox ID="CheckBox1" runat="server" Checked='<%# Bind("IsDisabled") %>' /></td>
                    </tr>
                    
                    <tr>
                        <td style="width: 30%; height: 26px;">
                        </td>
                        <td style="width: 75%; height: 26px; padding-bottom: 5px;">
                            <asp:Button ID="Update" runat="server" CommandName="Update" Text="<%$ Resources:TimeLive.Resource, Update_text%> " Width="68px" />
                            <asp:Button ID="Cancel" runat="server" CommandName="Cancel" Text="<%$ Resources:TimeLive.Resource, Cancel_text%> " Width="68px" ValidationGroup="CANCEL!" /></td>
                    </tr>
                </table>
            </EditItemTemplate>
            <InsertItemTemplate>
                <table width="100%" class="xview">
                    <tr>
                        <th class="caption" colspan="2" style="height: 21px" width="30%">
                            <asp:Literal ID="Literal2" runat="server" Text='<%# ResourceHelper.GetFromResource("Priority Information")%> ' /></th>
                    </tr>
                    <tr>
                        <th class="FormViewSubHeader" colspan="2" style="height: 21px" width="30%">
                            <asp:Literal ID="Literal6" runat="server" Text='<%# ResourceHelper.GetFromResource("Priority")%> ' /></th>
                    </tr>
                    <tr>
                        <td class="FormViewLabelCell" style="height: 26px;" width="30%" align="right">
                            <SPAN 
                  class=reqasterisk>*</SPAN><asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="AccountPriorityTextBox">
                  <asp:Literal ID="Literal1" runat="server" Text='<%# ResourceHelper.GetFromResource("Priority:")%> ' /></asp:Label></td><td style="width: 75%; height: 26px;">
                            <asp:TextBox 
                                ID="AccountPriorityTextBox" runat="server" Text='<%# Bind("Priority") %>' 
                                MaxLength="50" Width="176px"></asp:TextBox><asp:RequiredFieldValidator
                                ID="RequiredFieldValidator1" runat="server" ControlToValidate="AccountPriorityTextBox"
                                Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator></td></tr><tr>
                        <td align="right" class="FormViewLabelCell" style="height: 26px" width="30%">
                                                        <SPAN  class=reqasterisk>*</SPAN><asp:Label ID="Label4" runat="server" AssociatedControlID="PriorityOrderTextBox"><asp:Literal ID="Literal3" runat="server" Text='<%# ResourceHelper.GetFromResource("Priority Order:")%> ' /></asp:Label></td><td style="width: 75%; height: 26px">
                            <asp:TextBox 
                                ID="PriorityOrderTextBox" runat="server" MaxLength="50" 
                                Text='<%# Bind("PriorityOrder") %>' Width="176px"></asp:TextBox><asp:RequiredFieldValidator
                                ID="RequiredFieldValidator2" runat="server" ControlToValidate="PriorityOrderTextBox"
                                Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="PriorityOrderTextBox"
                                CssClass="ErrorMessage" Display="Dynamic" ErrorMessage="Numeric Required" MaximumValue="255"
                                MinimumValue="0" Type="Integer"></asp:RangeValidator></td></tr><tr>
                        <td style="height: 26px;" width="30%">
                        </td>
                        <td style="width: 75%; height: 26px; padding-bottom: 5px;">
                            <asp:Button ID="Add" runat="server" CommandName="Insert" Text="<%$ Resources:TimeLive.Resource, Add_text%> " Width="68px" /></td>
                    </tr>
                </table>
            </InsertItemTemplate>
            <ItemTemplate>
                AccountPriorityId: <asp:Label ID="AccountPriorityIdLabel" runat="server" Text='<%# Eval("AccountPriorityId") %>'>
                </asp:Label><br />AccountId: <asp:Label ID="AccountIdLabel" runat="server" Text='<%# Bind("AccountId") %>'></asp:Label><br />AccountPriority: <asp:Label ID="AccountPriorityLabel" runat="server" Text='<%# Bind("Priority") %>'>
                </asp:Label><br /><asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" CommandName="Edit"
                    Text="Edit">
                </asp:LinkButton><asp:LinkButton ID="DeleteButton" runat="server" CausesValidation="False" CommandName="Delete"
                    Text="Delete">
                </asp:LinkButton><asp:LinkButton ID="NewButton" runat="server" CausesValidation="False" CommandName="New"
                    Text="New">
                </asp:LinkButton></ItemTemplate></asp:FormView></ContentTemplate></asp:UpdatePanel>&nbsp; 