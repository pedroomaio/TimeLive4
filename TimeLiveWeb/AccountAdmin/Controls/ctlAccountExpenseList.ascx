<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlAccountExpenseList.ascx.vb"
    Inherits="AccountAdmin_Controls_ctlAccountExpenseList" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <x:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="AccountExpenseId"
            DataSourceID="dsAccountExpenseObject" SkinID="xgridviewSkinEmployee" Width="98%"
            Caption='<%# ResourceHelper.GetFromResource("Expense List") %>'>
            <Columns>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Id %>" SortExpression="AccountExpenseId">
                    <EditItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("AccountExpenseId") %>' __designer:wfdid="w210"></asp:Label>
                    </EditItemTemplate>
                    <HeaderTemplate>
                        <asp:LinkButton ID="LinkButton3" runat="server" Text='<%# ResourceHelper.GetFromResource("Id") %>'
                            CommandArgument="AccountExpenseId" CommandName="Sort" CausesValidation="False"></asp:LinkButton>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("AccountExpenseId") %>' __designer:wfdid="w209"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="5%" />
                </asp:TemplateField>
                <asp:TemplateField SortExpression="AccountExpenseName" HeaderText="<%$ Resources:TimeLive.Resource, Expense Name %>">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("AccountExpenseName") %>'
                            __designer:wfdid="w191"></asp:TextBox>
                    </EditItemTemplate>
                    <HeaderTemplate>
                        <asp:LinkButton ID="LinkButton4" runat="server" Text='<%# ResourceHelper.GetFromResource("Expense Name") %>'
                            CommandArgument="AccountExpenseName" CommandName="Sort" CausesValidation="False"></asp:LinkButton>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label54" runat="server" Text='<%# Bind("AccountExpenseName") %>' __designer:wfdid="w190"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="37%" Wrap="True" />
                </asp:TemplateField>
                <asp:TemplateField SortExpression="ExpenseType" HeaderText="<%$ Resources:TimeLive.Resource, Expense Type %>">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("ExpenseType") %>' __designer:wfdid="w197"></asp:TextBox>
                    </EditItemTemplate>
                    <HeaderTemplate>
                        <asp:LinkButton ID="LinkButton6" runat="server" Text='<%# ResourceHelper.GetFromResource("Expense Type") %>'
                            CommandArgument="ExpenseType" CommandName="Sort" CausesValidation="False"></asp:LinkButton>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label55" runat="server" Text='<%# Bind("ExpenseType") %>' __designer:wfdid="w196"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="30%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Billable %>">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("IsBillable") %>' __designer:wfdid="w194"></asp:TextBox>
                    </EditItemTemplate>
                    <HeaderTemplate>
                        <asp:Label ID="lblBillable" runat="server" Text="Billable | ReadOnly"
                            __designer:wfdid="w195"></asp:Label>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" __designer:wfdid="w193"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="12%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Reimburse | ReadOnly"> <%-- HeaderText="<%$ Resources:TimeLive.Resource, Reimburse %>" --%>
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Reimburse") %>' __designer:wfdid="w194"></asp:TextBox>
                    </EditItemTemplate>
                    <%--<HeaderTemplate>
                        <asp:Label ID="lblReimburse" runat="server" Text='<%# ResourceHelper.GetFromResource("Reimburse") %>'
                            __designer:wfdid="w195"></asp:Label>
                    </HeaderTemplate>--%>
                    <ItemTemplate>
                        <asp:Label ID="lblReimburse" runat="server" __designer:wfdid="w193"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="20%" />
                </asp:TemplateField>
                <asp:CommandField HeaderText="<%$ Resources:TimeLive.Resource, Edit_Text %>" SelectText="Edit"
                    ShowSelectButton="True">
                    <ItemStyle HorizontalAlign="Center" CssClass="edit_button" Width="1%" />
                </asp:CommandField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Delete_Text %>" ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" __designer:wfdid="w13" OnClientClick="<%# ResourceHelper.GetDeleteMessageJavascript()%>"
                            CommandName="Delete" CausesValidation="False"></asp:LinkButton>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" CssClass="delete_button" Width="1%" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/Disabled.gif" ToolTip="<%$ Resources:TimeLive.Resource, Disabled_text%> " />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/Disabled.gif" Visible='<%# IIF(IsDBNull(Eval("IsDisabled")),"false",Eval("IsDisabled")) %>'
                            ToolTip="<%$ Resources:TimeLive.Resource, Disabled_text%> " />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="1%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, IsBillable %>" Visible="False">
                    <EditItemTemplate>
                        <asp:CheckBox ID="CheckBox1" runat="server" Checked='<%# Bind("IsBillable") %>' __designer:wfdid="w30">
                        </asp:CheckBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="chkBillable" runat="server" Checked='<%# IIF(isdbnull(Eval("IsBillable")),"False",Eval("IsBillable")) %>'
                            Enabled="False" __designer:wfdid="w27"></asp:CheckBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Reimburse %>" Visible="False">
                    <EditItemTemplate>
                        <asp:CheckBox ID="CheckBox2" runat="server" Checked='<%# Bind("Reimburse") %>' __designer:wfdid="w30">
                        </asp:CheckBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="chkReimburse" runat="server" Checked='<%# IIF(isdbnull(Eval("Reimburse")),"False",Eval("Reimburse")) %>'
                            Enabled="False" __designer:wfdid="w27"></asp:CheckBox>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </x:GridView>
        <asp:ObjectDataSource ID="dsAccountExpenseObject" runat="server" DeleteMethod="DeleteAccountExpense"
            InsertMethod="AddAccountExpense" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetvueAccountExpensesByAccountId" TypeName="AccountExpenseBLL"
            UpdateMethod="UpdateAccountExpense">
            <DeleteParameters>
                <asp:Parameter Name="Original_AccountExpenseId" Type="Int32" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="AccountId" Type="Int32" />
                <asp:Parameter Name="AccountExpenseName" Type="String" />
                <asp:Parameter Name="AccountExpenseTypeId" Type="Int32" />
                <asp:Parameter Name="Original_AccountExpenseId" Type="Int32" />
                <asp:Parameter Name="ModifiedOn" Type="DateTime" />
                <asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" />
                <asp:Parameter Name="IsBillable" Type="Boolean" />
                <asp:Parameter Name="IsDisabled" Type="Boolean" />
                <asp:Parameter Name="DefaultExpenseRate" Type="Double" />
                <asp:Parameter Name="DisabledEditingOfRate" Type="Boolean" />
                <asp:Parameter Name="Reimburse" Type="Boolean" />
            </UpdateParameters>
            <SelectParameters>
                <asp:SessionParameter DefaultValue="64" Name="AccountId" SessionField="AccountId"
                    Type="Int32" />
            </SelectParameters>
            <InsertParameters>
                <asp:Parameter Name="AccountId" Type="Int32" />
                <asp:Parameter Name="AccountExpenseName" Type="String" />
                <asp:Parameter Name="AccountExpenseTypeId" Type="Int32" />
                <asp:Parameter Name="CreatedOn" Type="DateTime" />
                <asp:Parameter Name="CreatedByEmployeeId" Type="Int32" />
                <asp:Parameter Name="ModifiedOn" Type="DateTime" />
                <asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" />
                <asp:Parameter Name="IsBillable" Type="Boolean" />
                <asp:Parameter Name="DefaultExpenseRate" Type="Double" />
                <asp:Parameter Name="DisabledEditingOfRate" Type="Boolean" />
                <asp:Parameter Name="Reimburse" Type="Boolean" />
            </InsertParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="dsAccountExpenseFormObject" runat="server" DeleteMethod="DeleteAccountExpense"
            InsertMethod="AddAccountExpense" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetAccountExpensesByAccountExpenseId" TypeName="AccountExpenseBLL"
            UpdateMethod="UpdateAccountExpense">
            <DeleteParameters>
                <asp:Parameter Name="Original_AccountExpenseId" Type="Int32" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:SessionParameter DefaultValue="64" Name="AccountId" SessionField="AccountId"
                    Type="Int32" />
                <asp:Parameter Name="AccountExpenseName" Type="String" />
                <asp:Parameter Name="AccountExpenseTypeId" Type="Int32" />
                <asp:Parameter Name="Original_AccountExpenseId" Type="Int32" />
                <asp:Parameter Name="ModifiedOn" Type="DateTime" />
                <asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" />
                <asp:Parameter Name="IsBillable" Type="Boolean" />
                <asp:Parameter Name="IsDisabled" Type="Boolean" />
                <asp:Parameter Name="DefaultExpenseRate" Type="Double" />
                <asp:Parameter Name="DisabledEditingOfRate" Type="Boolean" />
                <asp:Parameter Name="Reimburse" Type="Boolean" />
                <asp:Parameter Name="ReimburseIsReadOnly" Type="Boolean" />
                <asp:Parameter Name="BillableIsReadOnly" Type="Boolean" />
            </UpdateParameters>
            <SelectParameters>
                <asp:ControlParameter ControlID="GridView1" Name="AccountExpenseId" PropertyName="SelectedValue"
                    Type="Int32" />
            </SelectParameters>
            <InsertParameters>
                <asp:SessionParameter DefaultValue="64" Name="AccountId" SessionField="AccountId"
                    Type="Int32" />
                <asp:Parameter Name="AccountExpenseName" Type="String" />
                <asp:Parameter Name="AccountExpenseTypeId" Type="Int32" />
                <asp:Parameter Name="CreatedOn" Type="DateTime" />
                <asp:Parameter Name="CreatedByEmployeeId" Type="Int32" />
                <asp:Parameter Name="ModifiedOn" Type="DateTime" />
                <asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" />
                <asp:Parameter Name="IsBillable" Type="Boolean" />
                <asp:Parameter Name="DefaultExpenseRate" Type="Double" />
                <asp:Parameter Name="DisabledEditingOfRate" Type="Boolean" />
                <asp:Parameter Name="Reimburse" Type="Boolean" />
                <asp:Parameter Name="ReimburseIsReadOnly" Type="Boolean" />
                <asp:Parameter Name="BillableIsReadOnly" Type="Boolean" />
            </InsertParameters>
        </asp:ObjectDataSource>
    </ContentTemplate>
</asp:UpdatePanel>
<br />
<asp:UpdatePanel ID="UpdatePanel2" runat="server">
    <ContentTemplate>
        <asp:FormView ID="FormView1" runat="server" DataSourceID="dsAccountExpenseFormObject"
            DataKeyNames="AccountExpenseId" DefaultMode="Insert" Width="550px" SkinID="formviewSkinEmployee"
            OnDataBound="FormView1_DataBound" OnModeChanging="FormView1_ModeChanging" OnModeChanged="FormView1_ModeChanged" OnItemInserting="FormView1_ItemInserting">
            <EditItemTemplate>
                <table width="100%" class="xview">
                    <tr>
                        <th colspan="20" class="caption">
                            <asp:Literal ID="Literal1" runat="server" Text='<%# ResourceHelper.GetFromResource("Expense Information")%> ' />
                        </th>
                    </tr>
                    <tr>
                        <th colspan="20" class="FormViewSubHeader">
                            <asp:Literal ID="Literal2" runat="server" Text='<%# ResourceHelper.GetFromResource("Expense")%> ' />
                        </th>
                    </tr>
                    <tr>
                        <td align="right" class="formviewlabelcell">
                            <span class="reqasterisk">*</span>
                            <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="AccountExpenseNameTextBox">
                                <asp:Literal ID="Literal3" runat="server" Text='<%# ResourceHelper.GetFromResource("Expense Name:")%> ' /></asp:Label>
                        </td>
                        <td colspan="20">
                            <asp:TextBox ID="AccountExpenseNameTextBox" runat="server" Text='<%# Bind("AccountExpenseName") %>'
                                MaxLength="100" Width="176px"></asp:TextBox><asp:RequiredFieldValidator ID="ddlExpenseType"
                                    runat="server" ControlToValidate="AccountExpenseNameTextBox" Display="Dynamic"
                                    ErrorMessage="*"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="formviewlabelcell">
                            <span class="reqasterisk">*</span><asp:Literal ID="Literal4" runat="server" Text='<%# ResourceHelper.GetFromResource("Expense Type:")%> ' />
                        </td>
                        <td colspan="20">
                            <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="dsAccountExpenseTypeObject"
                                DataTextField="ExpenseType" DataValueField="AccountExpenseTypeId" Width="188px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="formviewlabelcell">
                            <asp:Label ID="Label3" runat="server" AssociatedControlID="ExpenseRateTextBox">
                                <asp:Literal ID="Literal11" runat="server" Text='<%# ResourceHelper.GetFromResource("Default Expense Rate:")%> ' /></asp:Label>
                        </td>
                        <td colspan="20">
                            <asp:TextBox ID="ExpenseRateTextBox" runat="server" MaxLength="100" Text='<%# Bind("DefaultExpenseRate") %>'
                                Style="text-align: right;" Width="79px"></asp:TextBox>&nbsp;<asp:RangeValidator ID="ExpenseRateRangeValidator"
                                    runat="server" ControlToValidate="ExpenseRateTextBox" ErrorMessage="Value must be in numeric"
                                    MaximumValue="99999" MinimumValue="0" Type="Double"></asp:RangeValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="formviewlabelcell">
                            <asp:Literal ID="Literal12" runat="server" Text='<%# ResourceHelper.GetFromResource("Disabled Editing Of Rate:")%> ' />
                        </td>
                        <td colspan="20">
                            <asp:CheckBox ID="chkDisabledRate" runat="server" Checked='<%# Bind("DisabledEditingOfRate") %>' />
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="formviewlabelcell">
                            <asp:Literal ID="Literal5" runat="server" Text='<%# ResourceHelper.GetFromResource("Billable:")%> ' />
                        </td>
                        <td>
                            <asp:CheckBox ID="chkBillable" runat="server" />
                        </td>
                        <td align="left" style="width:0px;">
                            <asp:Literal ID="Literal16" runat="server" Text='ReadOnly:' />
                        </td>
                        <td style="width:250px">
                            <asp:CheckBox ID="chkBillableIsReadOnly" runat="server" Checked="true" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="formviewlabelcell">
                            <asp:Literal ID="ltlReimburse" runat="server" Text='<%# ResourceHelper.GetFromResource("Reimburse:")%> ' />
                        </td>
                        <td>
                            <asp:CheckBox ID="chkReimburse" runat="server"/>
                        </td>
                        <td align="left" style="width:20px;">
                            <asp:Literal ID="Literal15" runat="server" Text='ReadOnly:' />
                        </td>
                        <td>
                            <asp:CheckBox ID="chkReimburseIsReadOnly" runat="server" checked="true"/>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="formviewlabelcell">
                            <asp:Literal ID="Literal6" runat="server" Text='<%# ResourceHelper.GetFromResource("Disabled:")%> ' />
                        </td>
                        <td colspan="20">
                            <asp:CheckBox ID="chkIsDisabled" runat="server" Checked='<%# Bind("IsDisabled") %>' />
                        </td>             
                    </tr>     
                </table>
                <div style="padding-left:150px; padding-top:5px;">
                <asp:Button ID="Button1" runat="server" Text="<%$ Resources:TimeLive.Resource, Update_Text%> "
                                CommandName="Update" Width="68px" />&nbsp;
                            <asp:Button ID="Button2" runat="server" Text="<%$ Resources:TimeLive.Resource, Cancel_Text%> "
                                CommandName="Cancel" Width="68px" />
                    </div>
            </EditItemTemplate>
            <InsertItemTemplate>
                <table class="xview" style="width: 98%">
                    <tr>
                        <th colspan="20" class="caption">
                            <asp:Literal ID="Literal1" runat="server" Text='<%# ResourceHelper.GetFromResource("Expense Information")%> ' />
                        </th>
                    </tr>
                    <tr>
                        <th colspan="20" class="FormViewSubHeader">
                            <asp:Literal ID="Literal7" runat="server" Text='<%# ResourceHelper.GetFromResource("Expense")%> ' />
                        </th>
                    </tr>
                    <tr>
                        <td align="right" class="formviewlabelcell">
                            <span class="reqasterisk">*</span><asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="AccountExpenseNameTextBox">
                                <asp:Literal ID="Literal8" runat="server" Text='<%# ResourceHelper.GetFromResource("Expense Name:")%> ' /></asp:Label>
                        </td>
                        <td colspan="20">
                            <asp:TextBox ID="AccountExpenseNameTextBox" runat="server" Text='<%# Bind("AccountExpenseName") %>'
                                MaxLength="100" Width="176px"></asp:TextBox><asp:RequiredFieldValidator ID="ddlExpenseType"
                                    runat="server" ControlToValidate="AccountExpenseNameTextBox" Display="Dynamic"
                                    ErrorMessage="*"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="formviewlabelcell">
                            <span class="reqasterisk">*</span><asp:Literal ID="Literal9" runat="server" Text='<%# ResourceHelper.GetFromResource("Expense Type:")%> ' />
                        </td>
                        <td colspan="20">
                            <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="dsAccountExpenseTypeObject"
                                DataTextField="ExpenseType" DataValueField="AccountExpenseTypeId" SelectedValue='<%# Bind("AccountExpenseTypeId") %>'
                                Width="188px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="formviewlabelcell">
                            <asp:Label ID="Label4" runat="server" AssociatedControlID="ExpenseRateTextBox">
                                <asp:Literal ID="Literal11" runat="server" Text='<%# ResourceHelper.GetFromResource("Default Expense Rate:")%> ' /></asp:Label>
                        </td>
                        <td colspan="20">
                            <asp:TextBox ID="ExpenseRateTextBox" runat="server" MaxLength="100" Text='<%# Bind("DefaultExpenseRate") %>'
                                Style="text-align: right;" Width="79px"></asp:TextBox>&nbsp;<asp:RangeValidator ID="ExpenseRateRangeValidator"
                                    runat="server" ControlToValidate="ExpenseRateTextBox" ErrorMessage="Value must be in numeric"
                                    MaximumValue="99999" MinimumValue="0" Type="Double"></asp:RangeValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="formviewlabelcell">
                            <asp:Literal ID="Literal12" runat="server" Text='<%# ResourceHelper.GetFromResource("Disabled Editing Of Rate:")%> ' />
                        </td>
                        <td colspan="20">
                            <asp:CheckBox ID="chkDisabledRate" runat="server" Checked='<%# Bind("DisabledEditingOfRate") %>' />
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="formviewlabelcell">
                            <asp:Literal ID="Literal10" runat="server" Text='<%# ResourceHelper.GetFromResource("Billable:")%> ' />
                        </td>
                        <td>
                            <asp:CheckBox ID="chkBillable" runat="server" Checked='<%# Bind("IsBillable") %>' />
                        </td>
                        <td style="width:20px; margin-right:100px;" align="left">
                            <asp:Literal ID="Literal13" runat="server" Text='ReadOnly:' />
                        </td>
                        <td>
                             <asp:CheckBox ID="chkBillableIsReadOnly" runat="server" Checked="true" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="formviewlabelcell">
                            <asp:Literal ID="ltlReimburse" runat="server" Text='<%# ResourceHelper.GetFromResource("Reimburse:")%> ' />
                        </td>
                        <td>
                            <asp:CheckBox ID="chkReimburse" runat="server" Checked='<%# Bind("Reimburse") %>' />
                        </td>
                        <td style="width:0px;" align="left">
                            <asp:Literal ID="Literal14" runat="server" Text='ReadOnly:' />
                        </td>
                        <td style="width:250px">
                            <asp:CheckBox ID="chkReimburseIsReadOnly" runat="server" checked="true"/>
                        </td>
                    </tr>
                </table>
                <div style="padding-left:190px; padding-top:5px;">
                     <asp:Button ID="btnAdd" runat="server" Text="<%$ Resources:TimeLive.Resource, Add_text %> "
                                CommandName="Insert" Width="68px" />
                </div>
            </InsertItemTemplate>
            <ItemTemplate>
                AccountExpenseId:
                <asp:Label ID="AccountExpenseIdLabel" runat="server" Text='<%# Eval("AccountExpenseId") %>'>
                </asp:Label><br />
                AccountExpenseName:
                <asp:Label ID="AccountExpenseNameLabel" runat="server" Text='<%# Bind("AccountExpenseName") %>'>
                </asp:Label><br />
                AccountExpenseTypeId:
                <asp:Label ID="AccountExpenseTypeIdLabel" runat="server" Text='<%# Bind("AccountExpenseTypeId") %>'>
                </asp:Label><br />
                AccountId:
                <asp:Label ID="AccountIdLabel" runat="server" Text='<%# Bind("AccountId") %>'></asp:Label><br />
                CreatedOn:
                <asp:Label ID="CreatedOnLabel" runat="server" Text='<%# Bind("CreatedOn") %>'></asp:Label><br />
                CreatedByEmployeeId:
                <asp:Label ID="CreatedByEmployeeIdLabel" runat="server" Text='<%# Bind("CreatedByEmployeeId") %>'>
                </asp:Label><br />
                ModifiedOn:
                <asp:Label ID="ModifiedOnLabel" runat="server" Text='<%# Bind("ModifiedOn") %>'>
                </asp:Label><br />
                ModifiedByEmployeeId:
                <asp:Label ID="ModifiedByEmployeeIdLabel" runat="server" Text='<%# Bind("ModifiedByEmployeeId") %>'>
                </asp:Label><br />
                <asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" CommandName="Edit"
                    Text="Edit">
                </asp:LinkButton><asp:LinkButton ID="DeleteButton" runat="server" CausesValidation="False"
                    CommandName="Delete" Text="Delete">
                </asp:LinkButton><asp:LinkButton ID="NewButton" runat="server" CausesValidation="False"
                    CommandName="New" Text="New">
                </asp:LinkButton></ItemTemplate>
        </asp:FormView>
        <asp:ObjectDataSource ID="dsAccountExpenseTypeObject" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetAccountExpenseTypesByAccountIdandIsDisabled" TypeName="AccountExpenseTypeBLL">
            <SelectParameters>
                <asp:SessionParameter DefaultValue="64" Name="AccountId" SessionField="AccountId"
                    Type="Int32" />
                <asp:Parameter DefaultValue="0" Name="AccountExpenseTypeId" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </ContentTemplate>
</asp:UpdatePanel>
