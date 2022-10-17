<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlAccountWorkTypeList.ascx.vb" Inherits="AccountAdmin_Controls_ctlAccountWorkTypeList" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <x:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Caption= '<%# ResourceHelper.GetFromResource("Work Type List") %>'
            DataKeyNames="AccountWorkTypeId" DataSourceID="dsAccountWorkTypeGridViewObject"
            Width="98%" SkinID="xgridviewskinemployee">
            <Columns>
                <asp:TemplateField InsertVisible="False" SortExpression="AccountWorkTypeId" HeaderText="<%$ Resources:TimeLive.Resource, Id %>">
                    <edititemtemplate>
<asp:Label id="Label1" runat="server" Text='<%# Eval("AccountWorkTypeId") %>' __designer:wfdid="w57"></asp:Label> 
</edititemtemplate>
                    <headertemplate>
<asp:LinkButton id="LinkButton3" runat="server" Text='<%# ResourceHelper.GetFromResource("Id") %>' CommandArgument="AccountWorkTypeId" CommandName="Sort" CausesValidation="False"></asp:LinkButton>
</headertemplate>
                    <itemtemplate>
<asp:Label id="Label1" runat="server" Text='<%# Bind("AccountWorkTypeId") %>' __designer:wfdid="w56"></asp:Label> 
</itemtemplate>
                    <headerstyle horizontalalign="Center" verticalalign="Middle" />
                    <itemstyle horizontalalign="Center" verticalalign="Middle" width="5%" />
                </asp:TemplateField>
                <asp:TemplateField SortExpression="SortOrder" HeaderText="<%$ Resources:TimeLive.Resource, Sort Order %>">
                    <edititemtemplate>
<asp:TextBox id="TextBox1" runat="server" Text='<%# Bind("SortOrder") %>' __designer:wfdid="w66"></asp:TextBox> 
</edititemtemplate>
                    <headertemplate>
<asp:LinkButton id="LinkButton4" runat="server" Text='<%# ResourceHelper.GetFromResource("Sort Order") %>' CommandArgument="SortOrder" CommandName="Sort" CausesValidation="False"></asp:LinkButton>
</headertemplate>
                    <itemtemplate>
<asp:Label id="Label2" runat="server" Text='<%# Bind("SortOrder") %>' __designer:wfdid="w65"></asp:Label> 
</itemtemplate>
                    <itemstyle width="8%" HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:TemplateField>
                <asp:TemplateField SortExpression="AccountWorkTypeCode" HeaderText="<%$ Resources:TimeLive.Resource, Work Type Code %>">
                    <edititemtemplate>
<asp:TextBox id="TextBox2" runat="server" Text='<%# Bind("AccountWorkTypeCode") %>' __designer:wfdid="w69"></asp:TextBox> 
</edititemtemplate>
                    <headertemplate>
<asp:LinkButton id="LinkButton5" runat="server" Text='<%# ResourceHelper.GetFromResource("Work Type Code") %>' CommandArgument="AccountWorkTypeCode" CommandName="Sort" CausesValidation="False"></asp:LinkButton>
</headertemplate>
                    <itemtemplate>
<asp:Label id="Label3" runat="server" Text='<%# Bind("AccountWorkTypeCode") %>' __designer:wfdid="w68"></asp:Label> 
</itemtemplate>
                    <headerstyle horizontalalign="Center" verticalalign="Middle" />
                    <itemstyle width="13%" />
                </asp:TemplateField>
                <asp:TemplateField SortExpression="AccountWorkType" HeaderText="<%$ Resources:TimeLive.Resource, Work Type%>">
                    <edititemtemplate>
<asp:TextBox id="TextBox3" runat="server" Text='<%# Bind("AccountWorkType") %>' __designer:wfdid="w72"></asp:TextBox> 
</edititemtemplate>
                    <headertemplate>
<asp:LinkButton id="LinkButton6" runat="server" Text='<%# ResourceHelper.GetFromResource("Work Type") %>' CommandArgument="AccountWorkType" CommandName="Sort" CausesValidation="False"></asp:LinkButton>
</headertemplate>
                    <itemtemplate>
<asp:Label id="Label4" runat="server" Text='<%# Bind("AccountWorkType") %>' __designer:wfdid="w71"></asp:Label> 
</itemtemplate>
                    <headerstyle horizontalalign="Center" verticalalign="Middle" />
                    <itemstyle width="70%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Edit_text %>" ShowHeader="False">
                    <itemtemplate>
<asp:LinkButton id="LinkButton2" runat="server" CausesValidation="False" CommandName="Select" ToolTip="<%$ Resources:TimeLive.Resource, Edit_text%> " Text="<%$ Resources:TimeLive.Resource, Edit_text%> " __designer:wfdid="w17" ></asp:LinkButton>
</itemtemplate>
                    <headerstyle horizontalalign="Center" verticalalign="Middle" />
                    <itemstyle horizontalalign="Center" verticalalign="Middle" width="1%" cssclass="edit_button" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Delete_text %>" ShowHeader="False">
                    <itemtemplate>
<asp:LinkButton id="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete" ToolTip="<%$ Resources:TimeLive.Resource, Delete_text%> " Text="<%$ Resources:TimeLive.Resource, Delete_text%> " __designer:wfdid="w81" OnClientClick='<%# ResourceHelper.GetDeleteMessageJavascript()%>'></asp:LinkButton> 
</itemtemplate>
                    <headerstyle horizontalalign="Center" verticalalign="Middle" />
                    <itemstyle horizontalalign="Center" verticalalign="Middle" width="1%" cssclass="delete_button" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Disabled_text %>">
                    <headertemplate>
<asp:Image id="Image2" runat="server" __designer:wfdid="w80" ImageUrl="~/Images/Disabled.gif" ToolTip="<%$ Resources:TimeLive.Resource, Disabled_text%> "></asp:Image> 
</headertemplate>
                    <itemtemplate>
<asp:Image id="Image1" runat="server" __designer:wfdid="w79" ImageUrl="~/Images/Disabled.gif" ToolTip="<%$ Resources:TimeLive.Resource, Disabled_text%> " Visible='<%# IIF(IsDBNull(Eval("IsDisabled")),"False",Eval("IsDisabled")) %>'></asp:Image> 
</itemtemplate>
                    <headerstyle horizontalalign="Center" verticalalign="Middle" />
                    <itemstyle horizontalalign="Center" verticalalign="Middle" width="1%" />
                </asp:TemplateField>
            </Columns>
        </x:GridView>
        <asp:ObjectDataSource ID="dsAccountWorkTypeGridViewObject" runat="server" DeleteMethod="DeleteAccountWorkType"
            InsertMethod="AddAccountWorkType" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetAccountWorkTypesByAccountIdWorkType" TypeName="AccountWorkTypeBLL" UpdateMethod="UpdateAccountWorkType">
            <DeleteParameters>
                <asp:Parameter Name="Original_AccountWorkTypeId" Type="Int32" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="AccountWorkTypeCode" Type="String" />
                <asp:Parameter Name="AccountWorkType" Type="String" />
                <asp:Parameter Name="AccountId" Type="Int32" />
                <asp:Parameter Name="Original_AccountWorkTypeId" Type="Int32" />
                <asp:Parameter Name="ModifiedOn" Type="DateTime" />
                <asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" />
                <asp:Parameter Name="IsDisabled" Type="Boolean" />
                <asp:Parameter Name="SortOrder" Type="Int32" />
            </UpdateParameters>
            <SelectParameters>
                <asp:SessionParameter DefaultValue="99" Name="AccountId" SessionField="AccountId"
                    Type="Int32" />
            </SelectParameters>
            <InsertParameters>
                <asp:Parameter Name="AccountWorkTypeCode" Type="String" />
                <asp:Parameter Name="AccountWorkType" Type="String" />
                <asp:Parameter Name="AccountId" Type="Int32" />
                <asp:Parameter Name="CreatedOn" Type="DateTime" />
                <asp:Parameter Name="CreatedByEmployeeId" Type="Int32" />
                <asp:Parameter Name="ModifiedOn" Type="DateTime" />
                <asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" />
                <asp:Parameter Name="SortOrder" Type="Int32" />
            </InsertParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="dsAccountWorkTypeFormViewObject" runat="server" DeleteMethod="DeleteAccountWorkType"
            InsertMethod="AddAccountWorkType" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetAccountWorkTypesByAccountWorkTypeId" TypeName="AccountWorkTypeBLL"
            UpdateMethod="UpdateAccountWorkType">
            <DeleteParameters>
                <asp:Parameter Name="Original_AccountWorkTypeId" Type="Int32" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="AccountWorkTypeCode" Type="String" />
                <asp:Parameter Name="AccountWorkType" Type="String" />
                <asp:SessionParameter Name="AccountId" SessionField="AccountId" Type="Int32" />
                <asp:Parameter Name="Original_AccountWorkTypeId" Type="Int32" />
                <asp:Parameter Name="ModifiedOn" Type="DateTime" />
                <asp:SessionParameter Name="ModifiedByEmployeeId" SessionField="AccountEmployeeId"
                    Type="Int32" />
                <asp:Parameter Name="IsDisabled" Type="Boolean" />
                <asp:Parameter Name="SortOrder" Type="Int32" />
            </UpdateParameters>
            <SelectParameters>
                <asp:ControlParameter ControlID="GridView1" Name="AccountWorkTypeId" PropertyName="SelectedValue"
                    Type="Int32" />
            </SelectParameters>
            <InsertParameters>
                <asp:Parameter Name="AccountWorkTypeCode" Type="String" />
                <asp:Parameter Name="AccountWorkType" Type="String" />
                <asp:SessionParameter Name="AccountId" SessionField="AccountId" Type="Int32" />
                <asp:Parameter Name="CreatedOn" Type="DateTime" />
                <asp:SessionParameter Name="CreatedByEmployeeId" SessionField="AccountEmployeeId"
                    Type="Int32" />
                <asp:Parameter Name="ModifiedOn" Type="DateTime" />
                <asp:SessionParameter Name="ModifiedByEmployeeId" SessionField="AccountEmployeeId"
                    Type="Int32" />
                <asp:Parameter Name="SortOrder" Type="Int32" />
            </InsertParameters>
        </asp:ObjectDataSource>
    </ContentTemplate>
</asp:UpdatePanel>
<br />
<asp:UpdatePanel ID="UpdatePanel2" runat="server">
    <ContentTemplate>
        <asp:FormView ID="FormView1" runat="server" DataKeyNames="AccountWorkTypeId" 
            DataSourceID="dsAccountWorkTypeFormViewObject" SkinID="formviewskinemployee"
            DefaultMode="Insert" Width="450px">
            <EditItemTemplate>
                <table class="xview" width="100%">
                    <tr>
                        <th colspan="2" class="caption">
                        <asp:Literal ID="Literal1" runat="server" Text='<%# ResourceHelper.GetFromResource("Work Type List:")%> ' /></th>
                    </tr>
                    <tr>
                        <th colspan="2" class="FormViewSubHeader">
                        <asp:Literal ID="Literal2" runat="server" Text='<%# ResourceHelper.GetFromResource("Work Type:")%> ' /></th>
                    </tr>
                    <tr>
                        <td class="FormViewLabelCell" style="width: 40%">
                            
<asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="txtSortOrder">
                            <asp:Literal ID="Literal9" runat="server" Text='<%# ResourceHelper.GetFromResource("Sort Order:")%> ' /></asp:Label></td><td style="width: 60%">
                            <asp:TextBox 
                                ID="txtSortOrder" runat="server" MaxLength="10" Text='<%# Bind("SortOrder") %>'
                                style="text-align:right;" Width="78px"></asp:TextBox></td></tr><tr>
                        <td style="width: 40%" class="FormViewLabelCell">
                            <SPAN 
                  class=reqasterisk>*</SPAN><asp:Label ID="Label5" runat="server" AssociatedControlID="AccountWorkTypeCodeTextBox">
                  <asp:Literal ID="Literal3" runat="server" Text='<%# ResourceHelper.GetFromResource("Work Type Code:")%> ' /></asp:Label></td><td style="width: 60%">
                <asp:TextBox 
                                ID="AccountWorkTypeCodeTextBox" runat="server" 
                                Text='<%# Bind("AccountWorkTypeCode") %>' Width="176px" MaxLength="3"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="AccountWorkTypeCodeTextBox"
                                Display="Dynamic" ErrorMessage="*" Width="0px"></asp:RequiredFieldValidator></td></tr><tr>
                        <td style="width: 40%" class="FormViewLabelCell">
                            <SPAN 
                  class=reqasterisk>*</SPAN><asp:Label ID="Label8" runat="server" AssociatedControlID="AccountWorkTypeTextBox">
                  <asp:Literal ID="Literal4" runat="server" Text='<%# ResourceHelper.GetFromResource("Work Type:")%> ' /></asp:Label></td><td style="width: 60%">
                <asp:TextBox 
                                ID="AccountWorkTypeTextBox" runat="server" 
                                Text='<%# Bind("AccountWorkType") %>' Width="176px" MaxLength="50"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="AccountWorkTypeTextBox"
                                Display="Dynamic" ErrorMessage="*" Width="0px"></asp:RequiredFieldValidator></td></tr><tr>
                        <td style="width: 40%" class="FormViewLabelCell">
                        <asp:Literal ID="Literal5" runat="server" Text='<%# ResourceHelper.GetFromResource("Disabled:")%> ' /></td>
                        <td style="width: 60%">
                <asp:CheckBox ID="IsDisabledCheckBox" runat="server" Checked='<%# Bind("IsDisabled") %>' Enabled='<%# IIF(isdbnull(Eval("SystemWorkTypeId")),"True","False") %>' /></td>
                    </tr>
                    <tr>
                        <td style="width: 40%">
                        </td>
                        <td style="width: 60%; padding-bottom: 6px;">
                            <asp:Button ID="btnUpdate" runat="server" CommandName="Update" Text="<%$ Resources:TimeLive.Resource, Update_Text%> " Width="68px" />&nbsp<asp:Button
                                ID="btnCancel" runat="server" CommandName="Cancel" Text="<%$ Resources:TimeLive.Resource, Cancel_Text%> " Width="68px" /></td>
                    </tr>
                </table>
            </EditItemTemplate>
            <InsertItemTemplate>
                <table class="xview" width="100%">
                    <tr>
                        <th class="caption" colspan="2">
                        <asp:Literal ID="Literal5" runat="server" Text='<%# ResourceHelper.GetFromResource("Work Type Information")%> ' /></th>
                    </tr>
                    <tr>
                        <th class="FormViewSubHeader" colspan="2">
                            <asp:Literal ID="Literal6" runat="server" Text='<%# ResourceHelper.GetFromResource("Working Type")%> ' /></th>
                    </tr>
                    <tr>
                        <td class="FormViewLabelCell" style="width: 40%">
                           
<asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="txtSortOrder">
                            <asp:Literal ID="Literal9" runat="server" Text='<%# ResourceHelper.GetFromResource("Sort Order:")%> ' /></asp:Label></td><td style="width: 60%">
                            <asp:TextBox 
                                ID="txtSortOrder" runat="server" MaxLength="10" Text='<%# Bind("SortOrder") %>'
                                style="text-align:right;" Width="78px"></asp:TextBox></td></tr><tr>
                        <td style="width: 40%" class="FormViewLabelCell">
                            <SPAN 
                  class=reqasterisk>*</SPAN><asp:Label ID="Label6" runat="server" AssociatedControlID="AccountWorkTypeCodeTextBox">
                   <asp:Literal ID="Literal7" runat="server" Text='<%# ResourceHelper.GetFromResource("Work Type Code:")%> ' /></asp:Label></td><td style="width: 60%">
                            <asp:TextBox 
                                ID="AccountWorkTypeCodeTextBox" runat="server" 
                                Text='<%# Bind("AccountWorkTypeCode") %>' Width="176px" MaxLength="3"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="AccountWorkTypeCodeTextBox"
                                Display="Dynamic" ErrorMessage="*" Width="0px"></asp:RequiredFieldValidator></td></tr><tr>
                        <td style="width: 40%" class="FormViewLabelCell">
                            <SPAN 
                  class=reqasterisk>*</SPAN><asp:Label ID="Label7" runat="server" AssociatedControlID="AccountWorkTypeTextBox">
                  <asp:Literal ID="Literal8" runat="server" Text='<%# ResourceHelper.GetFromResource("Work Type:")%> ' /></asp:Label></td><td style="width: 60%">
                            <asp:TextBox 
                                ID="AccountWorkTypeTextBox" runat="server" 
                                Text='<%# Bind("AccountWorkType") %>' Width="176px" MaxLength="50"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="AccountWorkTypeTextBox"
                                Display="Dynamic" ErrorMessage="*" Width="0px"></asp:RequiredFieldValidator></td></tr><tr>
                        <td style="width: 40%">
                        </td>
                        <td style="width: 60%; padding-bottom: 5px;">
                            <asp:Button ID="btnAdd" runat="server" Text="<%$ Resources:TimeLive.Resource, Add_Text%> " Width="68px" CommandName="Insert" /></td>
                    </tr>
                </table>
            </InsertItemTemplate>
            <ItemTemplate>
                AccountWorkTypeId: <asp:Label ID="AccountWorkTypeIdLabel" runat="server" Text='<%# Eval("AccountWorkTypeId") %>'>
                </asp:Label><br />AccountWorkTypeCode: <asp:Label ID="AccountWorkTypeCodeLabel" runat="server" Text='<%# Bind("AccountWorkTypeCode") %>'>
                </asp:Label><br />AccountWorkType: <asp:Label ID="AccountWorkTypeLabel" runat="server" Text='<%# Bind("AccountWorkType") %>'>
                </asp:Label><br />SystemWorkTypeId: <asp:Label ID="SystemWorkTypeIdLabel" runat="server" Text='<%# Bind("SystemWorkTypeId") %>'>
                </asp:Label><br />AccountId: <asp:Label ID="AccountIdLabel" runat="server" Text='<%# Bind("AccountId") %>'></asp:Label><br />CreatedOn: <asp:Label ID="CreatedOnLabel" runat="server" Text='<%# Bind("CreatedOn") %>'></asp:Label><br />CreatedByEmployeeId: <asp:Label ID="CreatedByEmployeeIdLabel" runat="server" Text='<%# Bind("CreatedByEmployeeId") %>'>
                </asp:Label><br />ModifiedOn: <asp:Label ID="ModifiedOnLabel" runat="server" Text='<%# Bind("ModifiedOn") %>'>
                </asp:Label><br />ModifiedByEmployeeId: <asp:Label ID="ModifiedByEmployeeIdLabel" runat="server" Text='<%# Bind("ModifiedByEmployeeId") %>'>
                </asp:Label><br />IsDisabled: <asp:CheckBox ID="IsDisabledCheckBox" runat="server" Checked='<%# Bind("IsDisabled") %>'
                    Enabled="false" /><br />
                <asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" CommandName="Edit"
                    Text="Edit">
                </asp:LinkButton><asp:LinkButton ID="DeleteButton" runat="server" CausesValidation="False" CommandName="Delete"
                    Text="Delete">
                </asp:LinkButton><asp:LinkButton ID="NewButton" runat="server" CausesValidation="False" CommandName="New"
                    Text="New">
                </asp:LinkButton></ItemTemplate></asp:FormView>&nbsp;</ContentTemplate></asp:UpdatePanel>