<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlAccountEmployeeTypeList.ascx.vb" Inherits="AccountAdmin_Controls_ctlAccountEmployeeTypeList" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <x:GridView ID="GridView1" runat="server" SkinID="xgridviewSkinEmployee"  AllowSorting="True" Width="98%" AutoGenerateColumns="False" DataKeyNames="AccountEmployeeTypeId" DataSourceID="dsAccountEmployeeTypeObjectGridView" Caption='<%# ResourceHelper.GetFromResource("Employee Type List") %>'>
            <Columns>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Employee Type %>" SortExpression="AccountEmployeeType">
                    <edititemtemplate>
<asp:TextBox id="TextBox1" runat="server" __designer:wfdid="w2" Text='<%# Bind("AccountEmployeeType") %>'></asp:TextBox> 
</edititemtemplate>
                    <headertemplate>
<asp:LinkButton id="LinkButton3" runat="server" Text='<%# ResourceHelper.GetFromResource("Employee Type") %>' CausesValidation="False" CommandName="Sort" CommandArgument="AccountEmployeeType"></asp:LinkButton> 
</headertemplate>
                    <itemtemplate>
<asp:Label id="Label1" runat="server" Text='<%# Bind("AccountEmployeeType") %>'></asp:Label> 
</itemtemplate>
                    <ItemStyle Width="95%" />
                </asp:TemplateField>
                <asp:CommandField HeaderText="<%$ Resources:TimeLive.Resource, Edit_Text %>" SelectText="Edit" ShowSelectButton="True" >
                    <HeaderStyle HorizontalAlign="Left"  />
                    <ItemStyle HorizontalAlign="Center" cssclass="edit_button" Width="1%" />
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
        <asp:ObjectDataSource ID="dsAccountEmployeeTypeObjectGridView" runat="server" InsertMethod="AddAccountEmployeeType"
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetAccountEmployeeTypeByAccountId"
            TypeName="AccountEmployeeTypeBLL" UpdateMethod="UpdateAccountEmployeeType">
            <UpdateParameters>
                <asp:Parameter Name="AccountEmployeeType" Type="String" />
                <asp:Parameter Name="Original_AccountEmployeeTypeId" />
                <asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" />
                <asp:Parameter Name="IsDisabled" Type="Boolean" />
                <asp:Parameter Name="IsVendor" Type="Boolean" />
            </UpdateParameters>
            <SelectParameters>
                <asp:SessionParameter DefaultValue="1" Name="AccountId" SessionField="AccountId"
                    Type="Int32" />
            </SelectParameters>
            <InsertParameters>
                <asp:Parameter Name="AccountId" Type="Int32" />
                <asp:Parameter Name="AccountEmployeeType" Type="String" />
                <asp:Parameter Name="CreatedByEmployeeId" Type="Int32" />
                <asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" />
                <asp:Parameter Name="IsVendor" Type="Boolean" />
            </InsertParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="dsAccountEmployeeTypeFormViewObject" runat="server"
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetAccountEmployeeTypeByAccountEmployeeTypeId"
            TypeName="AccountEmployeeTypeBLL" InsertMethod="AddAccountEmployeeType" UpdateMethod="UpdateAccountEmployeeType">
            <SelectParameters>
                <asp:ControlParameter ControlID="GridView1" Name="AccountEmployeeTypeId"
                    PropertyName="SelectedValue" />
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter Name="AccountEmployeeType" Type="String" />
                <asp:Parameter Name="Original_AccountEmployeeTypeId" />
                <asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" />
                <asp:Parameter Name="IsDisabled" Type="Boolean" />
                <asp:Parameter Name="IsVendor" Type="Boolean" />
            </UpdateParameters>
            <InsertParameters>
                <asp:SessionParameter DefaultValue="55" Name="AccountId" SessionField="AccountId"
                    Type="Int32" />
                <asp:Parameter Name="AccountEmployeeType" Type="String" />
                <asp:Parameter Name="CreatedByEmployeeId" Type="Int32" />
                <asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" />
                <asp:Parameter Name="IsVendor" Type="Boolean" />
            </InsertParameters>
        </asp:ObjectDataSource>
    </ContentTemplate>
</asp:UpdatePanel>
<br />
<asp:UpdatePanel ID="UpdatePanel2" runat="server">
    <ContentTemplate>
        <asp:FormView ID="FormView1" runat="server" SkinID="formviewSkinEmployee" DataKeyNames="AccountEmployeeTypeId" DataSourceID="dsAccountEmployeeTypeFormViewObject" DefaultMode="Insert" Width="400px">
            <InsertItemTemplate>
                <table width="100%" class="xview">
                    <tr>
                        <th colspan="2" class="caption">
                             <asp:Literal ID="Literal1" runat="server" Text='<%# ResourceHelper.GetFromResource("Employee Type Information")%> ' /></th>
                    </tr>
                    <tr>
                        <th colspan="2" class="FormViewSubHeader">
                             <asp:Literal ID="Literal2" runat="server" Text='<%# ResourceHelper.GetFromResource("Employee Type")%> ' /></th>
                    </tr>
                    <tr>
                    <td style="height: 26px;" class="FormViewLabelCell" align="right" width="40%">
                    <SPAN class=reqasterisk>*</SPAN>  
                    <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="txtEmployeeType">
                    <asp:Literal ID="Literal4" runat="server" Text='<%# ResourceHelper.GetFromResource("Employee Type:")%> ' /></asp:Label></td><td style="height: 26px;" width="60%">
                         <asp:TextBox 
                                ID="txtEmployeeType" runat="server"  Width="176px" MaxLength="50" 
                                Text='<%# Bind("AccountEmployeeType") %>'></asp:TextBox><asp:RequiredFieldValidator
                         ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEmployeeType"
                         CssClass="ErrorMessage" Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator></td></tr><tr>
                        <td align="right" class="FormViewLabelCell" style="width: 30%">
                            IsVendor:</td><td style="width: 70%">
                            <asp:CheckBox ID="IsVendorCheckBox" runat="server" Checked='<%# Bind("IsVendor") %>' /></td>
                    </tr>
                    <tr>
                        <td align="right" class="FormViewLabelCell" style="width: 30%">
                        </td>
                        <td style="width: 70%; padding-bottom: 5px;">
                            <asp:Button ID="btnAdd" runat="server" CommandName="Insert" 
                                Text="<%$ Resources:TimeLive.Resource, Add_text%> " Width="68px" /></td>
                    </tr>
                </table>
            </InsertItemTemplate>
            <EditItemTemplate><table width="100%" class="xview">
                <tr>
                    <th colspan="2" class="caption">
                        <asp:Literal ID="Literal1" runat="server" Text='<%# ResourceHelper.GetFromResource("Employee Type Information")%> ' /></th>
                </tr>
                <tr>
                    <th colspan="2" class="FormViewSubHeader">
                        <asp:Literal ID="Literal5" runat="server" Text='<%# ResourceHelper.GetFromResource("Employee Type")%> ' /></th>
                </tr>
                <tr>
                    <td style="height: 26px;" class="FormViewLabelCell" align="right" width="40%">
                       <SPAN class=reqasterisk>*</SPAN><asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="txtEmployeeType">
                    <asp:Literal ID="Literal6" runat="server" Text='<%# ResourceHelper.GetFromResource("Employee Type:")%> ' /></asp:Label></td><td style="width: 60%">
                        <asp:TextBox 
                                ID="txtEmployeeType" runat="server" Width="176px" MaxLength="50" 
                                Text='<%# Bind("AccountEmployeeType") %>'></asp:TextBox><asp:RequiredFieldValidator
                            ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEmployeeType"
                            CssClass="ErrorMessage" Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator></td></tr><tr>
                    <td align="right" class="FormViewLabelCell" style="width: 30%;">
                        IsVendor:</td><td style="width: 70%;">
                        <asp:CheckBox ID="IsVendorCheckBox" runat="server" /></td>
                </tr>
                <tr>
                    <td align="right" class="FormViewLabelCell" style="width: 30%">
                    <asp:Literal ID="Literal3" runat="server" Text="<%$ Resources:TimeLive.Resource, Disabled:%> " /></td>
                    <td style="width: 70%">
                    <asp:CheckBox ID="CheckBox1" runat="server" Checked='<%# Bind("IsDisabled") %>' Enabled='<%# IIF(NOT IsDbnull(Eval("MasterEmployeeTypeId")),"False","True") %>' /></td>
                </tr>
                <tr>
                    <td align="right" style="width: 30%" class="FormViewLabelCell">
                    </td>
                    <td style="width: 70%; padding-bottom: 5px;">
                        <asp:Button ID="btnUpdate" runat="server" CommandName="Update" 
                                Text="<%$ Resources:TimeLive.Resource, Update_text%> " Width="68px" />&nbsp<asp:Button 
                                ID="btnCancel" runat="server" CommandName="Cancel" Text="Cancel" 
                                ValidationGroup="Cancel1" Width="68px" /></td>
                </tr>
            </table>
            </EditItemTemplate>
        </asp:FormView>
        &nbsp;&nbsp;&nbsp;</ContentTemplate></asp:UpdatePanel>