<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlAccountExpenseTypeList.ascx.vb" Inherits="AccountAdmin_Controls_ctlAccountExpenseTypeList" %>
  
  <div class="fieldset" style="width: 96%; margin-left: 6px;" align="left"> 
<table class="xFormView" width="98%">
 <tr>
<td width="50px">
<asp:Label ID="lblTaxZone" runat="server" Text="<%$ Resources:TimeLive.Resource, Tax Zone: %>"
                    Width="55px" Font-Bold="True" Font-Size="11px"/>
</td>
<td>
<asp:DropDownList ID="ddlAccountTaxZoneId" runat="server" DataSourceID="dsAccountTaxZoneObject"
                        DataTextField="AccountTaxZone" DataValueField="AccountTaxZoneId" Width="150px" AutoPostBack="True" OnSelectedIndexChanged="ddlAccountTaxZoneId_SelectedIndexChanged">
               </asp:DropDownList>
</td>
</tr>
</table>
</div>
<asp:ObjectDataSource ID="dsAccountTaxZoneObject" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetAccountTaxZonesByAccountIdAndIsDisabled" TypeName="AccountTaxZoneBLL">
            <SelectParameters>
                <asp:SessionParameter DefaultValue="99" Name="AccountId" SessionField="AccountId"
                    Type="Int32" />
                <asp:Parameter Name="AccountTaxZoneId" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
      
  <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <x:GridView ID="GridView1" runat="server" DataSourceID="dsAccountExpenseTypeObject" AutoGenerateColumns="False" DataKeyNames="AccountExpenseTypeId" AllowSorting="True" Caption="<%$ Resources:TimeLive.Resource, Expense Type List %>" SkinID="xgridviewSkinEmployee" Width="98%">
            <Columns>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Id %>" InsertVisible="False" SortExpression="AccountExpenseTypeId">
                    <edititemtemplate>
<asp:Label id="Label1" Text='<%# Eval("AccountExpenseTypeId") %>' runat="server" __designer:wfdid="w182"></asp:Label> 
</edititemtemplate>
                    <headertemplate>
<asp:LinkButton id="LinkButton3" runat="server" Text='<%# ResourceHelper.GetFromResource("Id") %>' CommandArgument="AccountExpenseTypeId" CommandName="Sort" CausesValidation="False"></asp:LinkButton>
</headertemplate>
                    <itemtemplate>
<asp:Label id="Label1" Text='<%# Bind("AccountExpenseTypeId") %>' runat="server" __designer:wfdid="w181"></asp:Label> 
</itemtemplate>
                    <itemstyle horizontalalign="Center" width="5%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Expense Type %>" SortExpression="ExpenseType">
                    <edititemtemplate>
<asp:TextBox id="TextBox1" Text='<%# Bind("ExpenseType") %>' runat="server" __designer:wfdid="w185"></asp:TextBox> 
</edititemtemplate>
                    <headertemplate>
<asp:LinkButton id="LinkButton4" runat="server" Text='<%# ResourceHelper.GetFromResource("Expense Type") %>' CommandArgument="ExpenseType" CommandName="Sort" CausesValidation="False"></asp:LinkButton>
</headertemplate>
                    <itemtemplate>
<asp:Label id="Label2" Text='<%# Bind("ExpenseType") %>' runat="server" __designer:wfdid="w184"></asp:Label> 
</itemtemplate>
                    <itemstyle horizontalalign="Left" width="47.5%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Tax Code %>" SortExpression="TaxCode">
                    <edititemtemplate>
<asp:TextBox id="TextBox2" Text='<%# Bind("TaxCode") %>' runat="server" __designer:wfdid="w188"></asp:TextBox> 
</edititemtemplate>
                    <headertemplate>
<asp:LinkButton id="LinkButton5" runat="server" Text='<%# ResourceHelper.GetFromResource("Tax Code") %>' CommandArgument="TaxCode" CommandName="Sort" CausesValidation="False"></asp:LinkButton>
</headertemplate>
                    <itemtemplate>
<asp:Label id="Label3" Text='<%# Bind("TaxCode") %>' runat="server" __designer:wfdid="w187"></asp:Label> 
</itemtemplate>
                    <itemstyle horizontalalign="Left" width="47.5%" />
                </asp:TemplateField>
                <asp:CommandField HeaderText="<%$ Resources:TimeLive.Resource, Edit_text %>" SelectText="Edit" ShowSelectButton="True">
                    <HeaderStyle HorizontalAlign="Center"  />
                    <ItemStyle width="1%"  cssclass="edit_button" HorizontalAlign="Center" VerticalAlign="Bottom" />
                </asp:CommandField>
        <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Delete_text %>" ShowHeader="False">
     <ItemTemplate>
 
       <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete"
                    OnClientClick='<%# ResourceHelper.GetDeleteMessageJavascript()%>'
                    Text="<%$ Resources:TimeLive.Resource, Delete_text%>" />
      
</ItemTemplate>
            <HeaderStyle HorizontalAlign="Center" />
            <ItemStyle HorizontalAlign="Center" Width="1%" VerticalAlign="Middle" cssclass="delete_button" />
        </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/Disabled.gif" ToolTip="<%$ Resources:TimeLive.Resource, Disabled_text%> " />
                    
</HeaderTemplate>
                    <ItemTemplate>
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/Disabled.gif" Visible='<%# IIF(IsDBNull(Eval("IsDisabled")),"false",Eval("IsDisabled")) %>' ToolTip="<%$ Resources:TimeLive.Resource, Disabled_text%> " />
                    
</ItemTemplate>
                    <ItemStyle Width="1%" />
                </asp:TemplateField>
            </Columns>
        </x:GridView>
        <asp:ObjectDataSource ID="dsAccountExpenseTypeObject" runat="server" DeleteMethod="DeleteAccountExpenseType" InsertMethod="AddAccountExpenseType" OldValuesParameterFormatString="original_{0}" SelectMethod="GetvueAccountExpenseTypesByAccountIdAndAccountTaxZoneId" TypeName="AccountExpenseTypeBLL" UpdateMethod="UpdateAccountExpenseType">
            <DeleteParameters>
                <asp:Parameter Name="Original_AccountExpenseTypeId" Type="Int32" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="AccountId" Type="Int32" />
                <asp:Parameter Name="ExpenseType" Type="String" />
                <asp:Parameter Name="Original_AccountExpenseTypeId" Type="Int32" />
                <asp:Parameter Name="ModifiedOn" Type="DateTime" />
                <asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" />
                <asp:Parameter Name="IsDisabled" Type="Boolean" />
                <asp:Parameter Name="AccountTaxCodeId" Type="Int32" />
                <asp:Parameter Name="IsQuantityField" Type="Boolean" />
                <asp:Parameter Name="QuantityFieldCaption" Type="String" />
            </UpdateParameters>
            <SelectParameters>
                <asp:SessionParameter DefaultValue="64" Name="AccountId" SessionField="AccountId"
                    Type="Int32" />
                <asp:Parameter Name="AccountTaxZoneId" Type="Int32" />
            </SelectParameters>
            <InsertParameters>
                <asp:Parameter Name="AccountId" Type="Int32" />
                <asp:Parameter Name="ExpenseType" Type="String" />
                <asp:Parameter Name="CreatedOn" Type="DateTime" />
                <asp:Parameter Name="CreatedByEmployeeId" Type="Int32" />
                <asp:Parameter Name="ModifiedOn" Type="DateTime" />
                <asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" />
                <asp:Parameter Name="AccountTaxCodeId" Type="Int32" />
                <asp:Parameter Name="QuantityFieldCaption" Type="String" />
                <asp:Parameter Name="IsQuantityField" Type="Boolean" />
                <asp:Parameter Name="AccountTaxZoneId" Type="Int32" />
            </InsertParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="dsAccountExpenseTypeFormObject" runat="server" DeleteMethod="DeleteAccountExpenseType"
            InsertMethod="AddAccountExpenseType" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetvueAccountExpenseTypesByAccountExpenseTypeIdAndAccountTaxZoneId" TypeName="AccountExpenseTypeBLL"
            UpdateMethod="UpdateAccountExpenseType">
            <DeleteParameters>
                <asp:Parameter Name="Original_AccountExpenseTypeId" Type="Int32" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:SessionParameter DefaultValue="64" Name="AccountId" SessionField="AccountId"
                    Type="Int32" />
                <asp:Parameter Name="ExpenseType" Type="String" />
                <asp:Parameter Name="Original_AccountExpenseTypeId" Type="Int32" />
                <asp:Parameter Name="ModifiedOn" Type="DateTime" />
                <asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" />
                <asp:Parameter Name="IsDisabled" Type="Boolean" />
                <asp:Parameter Name="AccountTaxCodeId" Type="Int32" />
                <asp:Parameter Name="IsQuantityField" Type="Boolean" />
                <asp:Parameter Name="QuantityFieldCaption" Type="String" />
                <asp:Parameter Name="AccountTaxZoneId" Type="Int32" />
            </UpdateParameters>
            <SelectParameters>
                <asp:ControlParameter ControlID="GridView1" Name="AccountExpenseTypeId" PropertyName="SelectedValue"
                    Type="Int32" />
                <asp:Parameter Name="AccountTaxZoneId" Type="Int32" />
            </SelectParameters>
            <InsertParameters>
                <asp:SessionParameter DefaultValue="64" Name="AccountId" SessionField="AccountId"
                    Type="Int32" />
                <asp:Parameter Name="ExpenseType" Type="String" />
                <asp:Parameter Name="CreatedOn" Type="DateTime" />
                <asp:Parameter Name="CreatedByEmployeeId" Type="Int32" />
                <asp:Parameter Name="ModifiedOn" Type="DateTime" />
                <asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" />
                <asp:Parameter Name="AccountTaxCodeId" Type="Int32" />
                <asp:Parameter Name="QuantityFieldCaption" Type="String" />
                <asp:Parameter Name="IsQuantityField" Type="Boolean" />
                <asp:Parameter Name="AccountTaxZoneId" Type="Int32" />
            </InsertParameters>
        </asp:ObjectDataSource>
          </ContentTemplate>
</asp:UpdatePanel>
    <br>
  <asp:UpdatePanel ID="UpdatePanel2" runat="server">
    <ContentTemplate>
        <asp:FormView ID="FormView1" runat="server" DataKeyNames="AccountExpenseTypeId" DataSourceID="dsAccountExpenseTypeFormObject"
            DefaultMode="Insert" Width="450px" SkinID="formviewSkinEmployee" OnDataBound="FormView1_DataBound">
            <EditItemTemplate><table width="450" class="xview">
                <tr>
                    <th class="caption" colspan="2" style="height: 21px">
                        <asp:Literal ID="Literal1" runat="server" Text='<%# ResourceHelper.GetFromResource("Expense Type Information")%> ' /></th>
                </tr>
                <tr>
                    <th class="FormViewSubHeader" colspan="2" style="height: 21px">
                    <asp:Literal ID="Literal2" runat="server" Text='<%# ResourceHelper.GetFromResource("Expense Type")%> ' /></th>
                </tr>
                <tr>
                    <td align="right" class="FormViewLabelCell" style="width: 40%">
                        <SPAN 
                  class=reqasterisk>*</span> 
                  
<asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="ExpenseTypeTextBox">
                  <asp:Literal ID="Literal8" runat="server" Text='<%# ResourceHelper.GetFromResource("Expense Type:")%> ' /></asp:Label></td></td><td style="width: 60%">
                        <asp:TextBox 
                            ID="ExpenseTypeTextBox" runat="server" Text='<%# Bind("ExpenseType") %>' 
                            MaxLength="50" Width="176px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ExpenseTypeTextBox"
                            Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator></td></tr><tr>
                    <td align="right" class="FormViewLabelCell" style="width: 40%">
                        <asp:Literal ID="Literal9" runat="server" Text='<%# ResourceHelper.GetFromResource("Tax Code:")%> ' /></td>
                    </td>
                    <td style="width: 60%">
                        <asp:DropDownList ID="ddlAccountTaxCodeId" runat="server" DataSourceID="dsAccountTaxCodeObject"
                            DataTextField="TaxCode" DataValueField="AccountTaxCodeId" Width="187px" 
                            AppendDataBoundItems="True"><asp:ListItem Value="0" Label ID="Label1" runat="server" Text="<%$ Resources:TimeLive.Resource, None%> "></asp:ListItem><%--<asp:ListItem Value="0">&lt;None&gt;</asp:ListItem>--%></asp:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlAccountTaxCodeId"
                            CssClass="ErrorMessage" Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator></td></tr><tr>
                    <td align="right" class="FormViewLabelCell" style="width: 40%">
                        <asp:Literal ID="Literal10" runat="server" Text='<%# ResourceHelper.GetFromResource("Show Quantity:")%> ' /></td>
                    </td>
                    <td style="width: 60%">
                        <asp:CheckBox ID="CheckBox2" runat="server" AutoPostBack="True" OnCheckedChanged="CheckBox2_CheckedChanged" /></td>
                </tr>
                <tr>
                    <td align="right" class="FormViewLabelCell" style="width: 40%">
                       <SPAN 
                  class=reqasterisk>*</span><asp:Literal ID="Literal11" runat="server" Text='<%# ResourceHelper.GetFromResource("Quantity Caption:")%> ' /></td>
                    </td>
                    <td style="width: 60%">
                        <asp:TextBox ID="TextBox1" runat="server" 
                            Text='<%# Bind("QuantityFieldCaption") %>' style="text-align:right;" 
                            Width="78px"></asp:TextBox><asp:CustomValidator ID="CustomValidator1" runat="server" CssClass="ErrorMessage"
                            Display="Dynamic" ErrorMessage="*" OnServerValidate="CustomValidator1_ServerValidate1"></asp:CustomValidator></td></tr><tr>
                    <td align="right" class="FormViewLabelCell" style="width: 40%;">
                        <asp:Literal ID="Literal3" runat="server" Text="<%$ Resources:TimeLive.Resource, Disabled:%> " /></td>
                    </td>
                    <td style="width: 60%;">
                        <asp:CheckBox ID="CheckBox1" runat="server" Checked='<%# Bind("IsDisabled") %>' /></td>
                </tr>
                <tr>
                    <td style="width: 40%">
                    </td>
                    <td style="width: 60%; padding-bottom: 5px;">
                        <asp:Button ID="Button1" runat="server" CommandName="Update" Text="<%$ Resources:TimeLive.Resource, Update_text%> " Width="68px" />&nbsp<asp:Button ID="Button2" runat="server" CommandName="Cancel" Text="<%$ Resources:TimeLive.Resource, Cancel_text%> " Width="68px" /></td>
                </tr>
            </table>
            </EditItemTemplate>
            <InsertItemTemplate>
                <table width="450" class="xview">
                    <tr>
                        <th class="caption" colspan="2" style="height: 21px">
                    <asp:Literal ID="Literal1" runat="server" Text='<%# ResourceHelper.GetFromResource("Expense Type Information")%> ' /></th>
                    </tr>
                    <tr>
                        <th class="FormViewSubHeader" colspan="2" style="height: 21px">
                            <asp:Literal ID="Literal4" runat="server" Text='<%# ResourceHelper.GetFromResource("Expense Type")%> ' /></th>
                    </tr>
                    <tr>
                        <td align="right" class="FormViewLabelCell" style="width: 40%">
                            <SPAN 
                  class=reqasterisk>*</span><asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="ExpenseTypeTextBox">
                  <asp:Literal ID="Literal12" runat="server" Text='<%# ResourceHelper.GetFromResource("Expense Type:")%> ' /></asp:Label></td></td><td style="width: 60%">
                            <asp:TextBox 
                                ID="ExpenseTypeTextBox" runat="server" Text='<%# Bind("ExpenseType") %>' 
                                MaxLength="50" Width="176px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ExpenseTypeTextBox"
                                Display="Dynamic" ErrorMessage="*" CssClass="ErrorMessage"></asp:RequiredFieldValidator></td></tr><tr>
                        <td align="right" class="FormViewLabelCell" style="width: 40%">
                            <asp:Literal ID="Literal5" runat="server" Text='<%# ResourceHelper.GetFromResource("Tax Code:")%> ' /></td>
                        </td>
                        <td style="width: 60%">
                            <asp:DropDownList ID="ddlAccountTaxCodeId" runat="server" DataSourceID="dsAccountTaxCodeObject"
                                DataTextField="TaxCode" DataValueField="AccountTaxCodeId"
                                Width="187px" AppendDataBoundItems="True"><asp:ListItem Selected="True" Value="0" Label ID="Label2" runat="server" Text="<%$ Resources:TimeLive.Resource, None%> "></asp:ListItem><%--<asp:ListItem Selected="True" Value="0">&lt;None&gt;</asp:ListItem>--%></asp:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                ControlToValidate="ddlAccountTaxCodeId" CssClass="ErrorMessage" Display="Dynamic"
                                ErrorMessage="*"></asp:RequiredFieldValidator></td></tr><tr>
                        <td align="right" class="FormViewLabelCell" style="width: 40%">
                            <asp:Literal ID="Literal6" runat="server" Text='<%# ResourceHelper.GetFromResource("Show Quantity:")%> ' /></td>
                        </td>
                        <td style="width: 60%">
                            <asp:CheckBox ID="QuantityCheckBox" runat="server" Checked='<%# iif(isdbnull(eval("IsQuantityField")),"False",eval("IsQuantityField")) %>' AutoPostBack="True" OnCheckedChanged="QuantityCheckBox_CheckedChanged" /></td>
                    </tr>
                    <tr>
                        <td align="right" class="FormViewLabelCell" style="width: 40%">
                           <SPAN 
                  class=reqasterisk>*</span><asp:Literal ID="Literal7" runat="server" Text='<%# ResourceHelper.GetFromResource("Quantity Caption:")%> ' /></td>
                        </td>
                        <td style="width: 60%">
                            <asp:TextBox ID="QuantityTextBox" runat="server" 
                                Text='<%# Bind("QuantityFieldCaption") %>' Enabled="False" 
                                style="text-align:right;" Width="78px"></asp:TextBox><asp:CustomValidator ID="CustomValidator1" runat="server" CssClass="ErrorMessage"
                                Display="Dynamic" ErrorMessage="*" OnServerValidate="CustomValidator1_ServerValidate"></asp:CustomValidator></td></tr><tr>
                        <td style="width: 40%">
                        </td>
                        <td style="width: 60%; padding-bottom: 5px;">
                            <asp:Button ID="btnAdd" runat="server" CommandName="Insert" Text="<%$ Resources:TimeLive.Resource, Add_text%> " Width="68px" /></td>
                    </tr>
                </table>
            </InsertItemTemplate>
            <ItemTemplate>
                AccountExpenseTypeId: <asp:Label ID="AccountExpenseTypeIdLabel" runat="server" Text='<%# Eval("AccountExpenseTypeId") %>'>
                </asp:Label><br />ExpenseType: <asp:Label ID="ExpenseTypeLabel" runat="server" Text='<%# Bind("ExpenseType") %>'>
                </asp:Label><br />AccountId: <asp:Label ID="AccountIdLabel" runat="server" Text='<%# Bind("AccountId") %>'></asp:Label><br />CreatedOn: <asp:Label ID="CreatedOnLabel" runat="server" Text='<%# Bind("CreatedOn") %>'></asp:Label><br />ModifiedOn: <asp:Label ID="ModifiedOnLabel" runat="server" Text='<%# Bind("ModifiedOn") %>'>
                </asp:Label><br />CreatedByEmployeeId: <asp:Label ID="CreatedByEmployeeIdLabel" runat="server" Text='<%# Bind("CreatedByEmployeeId") %>'>
                </asp:Label><br />ModifiedByEmployeeId: <asp:Label ID="ModifiedByEmployeeIdLabel" runat="server" Text='<%# Bind("ModifiedByEmployeeId") %>'>
                </asp:Label><br /><asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" CommandName="Edit"
                    Text="Edit">
                </asp:LinkButton><asp:LinkButton ID="DeleteButton" runat="server" CausesValidation="False" CommandName="Delete"
                    Text="Delete">
                </asp:LinkButton><asp:LinkButton ID="NewButton" runat="server" CausesValidation="False" CommandName="New"
                    Text="New">
                </asp:LinkButton></ItemTemplate></asp:FormView><asp:ObjectDataSource ID="dsAccountTaxCodeObject" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetAccountTaxCodesByAccountIdAndAccountTaxZoneIdForDropDown" TypeName="AccountTaxCodeBLL">
            <SelectParameters>
                <asp:SessionParameter DefaultValue="151" Name="AccountId" SessionField="AccountId"
                    Type="Int32" />
                <asp:Parameter DefaultValue="" Name="AccountTaxZoneId" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </ContentTemplate>
</asp:UpdatePanel>
