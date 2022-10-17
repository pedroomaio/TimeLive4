<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlAccountCustomFieldManage.ascx.vb" Inherits="AccountAdmin_Controls_ctlAccountCustomFieldManage" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc2" %>
<asp:UpdatePanel ID="UpdatePanel2" runat="server">
    <ContentTemplate>
      <x:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="AccountCustomFieldId,MasterCustomDataTypeId,DatabaseFieldName"
    DataSourceID="dsAccountCustomFieldManageForGridView"  AllowSorting="True" 
            SkinID="xgridviewSkinEmployee" Caption="<%$ Resources:TimeLive.Resource, Custom Field List %>" 
            Width="98%">
            <Columns>
                <asp:BoundField DataField="MasterCustomDataTypeName" 
                    HeaderText="<%$ Resources:TimeLive.Resource, Type %>" 
                    SortExpression="MasterCustomDataTypeName" >
                    <ItemStyle Width="15%" />
                </asp:BoundField>
                <asp:BoundField DataField="CustomFieldName" HeaderText="<%$ Resources:TimeLive.Resource, Name %>" 
                    SortExpression="CustomFieldName" >
                    <ItemStyle Width="30%" />
                </asp:BoundField>
                <asp:BoundField DataField="CustomFieldCaption" HeaderText="<%$ Resources:TimeLive.Resource, Caption %>" 
                    SortExpression="CustomFieldCaption" >
                    <ItemStyle Width="30%" />
                </asp:BoundField>
                <asp:BoundField DataField="DefaultValue" HeaderText="<%$ Resources:TimeLive.Resource, Default Value %>" 
                    SortExpression="DefaultValue" >
                    <ItemStyle Width="10%" />
                </asp:BoundField>
                <asp:TemplateField ConvertEmptyStringToNull="False" HeaderText="<%$ Resources:TimeLive.Resource, Required %>" 
                    SortExpression="IsRequired">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("IsRequired") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="10%" />
                </asp:TemplateField>
                <asp:CommandField HeaderText="<%$ Resources:TimeLive.Resource, Edit_text %>" 
                    SelectText="Edit" ShowSelectButton="True">
                    <ItemStyle cssclass="edit_button" HorizontalAlign="Center" 
                        VerticalAlign="Middle" Width="1%" />
                </asp:CommandField>
               <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Delete_text %>" ShowHeader="False">
     <ItemTemplate>
        <asp:LinkButton ID="LinkButton12" runat="server" CausesValidation="False" CommandName="Delete" 
                    OnClientClick='<%# ResourceHelper.GetCustomFieldMessageJavascript()%>'
                    Text="Delete" Visible='<%# Not  IsDBNull(Eval("AccountCustomFieldId")) %>'/>
</ItemTemplate>
            <HeaderStyle HorizontalAlign="Center" />
            <ItemStyle HorizontalAlign="Center" Width="1%" cssclass="delete_button" />
        </asp:TemplateField>
                <asp:TemplateField ConvertEmptyStringToNull="False">
                    <ItemTemplate>
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/Disabled.gif" 
                            ToolTip="<%$ Resources:TimeLive.Resource, Disabled_text %>" 
                            Visible='<%# IIF(IsDBNull(Eval("IsDisabled")),"False",Eval("IsDisabled")) %>' />
                    </ItemTemplate>
                    <HeaderTemplate>
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/Disabled.gif" 
                            ToolTip="<%$ Resources:TimeLive.Resource, Disabled_text %>" />
                    </HeaderTemplate>
                    <ItemStyle Width="1%" HorizontalAlign="Center"  />
                </asp:TemplateField>
            </Columns>
</x:GridView>
        <asp:ObjectDataSource ID="dsAccountCustomFieldManageForGridView" runat="server" DeleteMethod="DeleteAccountCustomField" 
            InsertMethod="AddCustomFieldManage" 
            OldValuesParameterFormatString="original_{0}" 
            SelectMethod="GetvueAccountCustomFieldByAccountIdandMasterEntityTypeIdForGrid" 
            TypeName="AccountCustomFieldBLL" UpdateMethod="UpdateCustomFieldManage">
            <InsertParameters>
                <asp:Parameter Name="AccountId" Type="Int32" />
                <asp:Parameter DbType="Guid" Name="MasterCustomDataTypeId" />
                <asp:Parameter DbType="Guid" Name="MasterEntityTypeId" />
                <asp:Parameter Name="DatabaseFieldName" Type="String" />
                <asp:Parameter Name="CustomFieldName" Type="String" />
                <asp:Parameter Name="CustomFieldCaption" Type="String" />
                <asp:Parameter Name="DefaultValue" Type="String" />
                <asp:Parameter Name="MaximumLength" Type="Int32" />
                <asp:Parameter Name="MinimumValue" Type="Int32" />
                <asp:Parameter Name="MaximumValue" Type="Int32" />
                <asp:Parameter Name="DropDownOptions" Type="String" />
                <asp:Parameter Name="IsRequired" Type="Boolean" />
                <asp:Parameter Name="IsDisabled" Type="Boolean" />
                <asp:Parameter Name="CreatedOn" Type="DateTime" />
                <asp:Parameter Name="CreatedByEmployeeId" Type="Int32" />
                <asp:Parameter Name="ModifiedOn" Type="DateTime" />
                <asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" />
            </InsertParameters>
            <SelectParameters>
                <asp:SessionParameter DefaultValue="66" Name="AccountId" 
                    SessionField="AccountId" Type="Int32" />
                <asp:QueryStringParameter DbType="Guid" 
                    DefaultValue="" Name="MasterEntityTypeId" 
                    QueryStringField="MasterEntityTypeId" />
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter DbType="Guid" Name="Original_AccountCustomFieldId" />
                <asp:Parameter Name="AccountId" Type="Int32" />
                <asp:Parameter DbType="Guid" Name="MasterCustomDataTypeId" />
                <asp:Parameter DbType="Guid" Name="MasterEntityTypeId" />
                <asp:Parameter Name="DatabaseFieldName" Type="String" />
                <asp:Parameter Name="CustomFieldName" Type="String" />
                <asp:Parameter Name="CustomFieldCaption" Type="String" />
                <asp:Parameter Name="DefaultValue" Type="String" />
                <asp:Parameter Name="MaximumLength" Type="Int32" />
                <asp:Parameter Name="MinimumValue" Type="Int32" />
                <asp:Parameter Name="MaximumValue" Type="Int32" />
                <asp:Parameter Name="DropDownOptions" Type="String" />
                <asp:Parameter Name="IsRequired" Type="Boolean" />
                <asp:Parameter Name="IsDisabled" Type="Boolean" />
                <asp:Parameter Name="CreatedOn" Type="DateTime" />
                <asp:Parameter Name="CreatedByEmployeeId" Type="Int32" />
                <asp:Parameter Name="ModifiedOn" Type="DateTime" />
                <asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" />
            </UpdateParameters>
               <DeleteParameters>
        <asp:Parameter Name="Original_AccountCustomFieldId" DbType="Guid" />
                   <asp:Parameter Name="DatabaseFieldName" Type="String" />
                   <asp:QueryStringParameter DbType="Guid" Name="MasterEntityTypeId" 
                       QueryStringField="MasterEntityTypeId" />
    </DeleteParameters>
        </asp:ObjectDataSource>
        <br />
    </ContentTemplate>
</asp:UpdatePanel>
<asp:UpdatePanel ID="UpdatePanel3" runat="server">
    <ContentTemplate>
        <asp:FormView ID="FormView1" runat="server" DataKeyNames="AccountCustomFieldId" 
            DataSourceID="dsAccountCustomFieldManageForFormView" DefaultMode="Insert" 
            SkinID="formviewSkinEmployee" Width="85%">
            <EditItemTemplate>
                <table class="xview" style="width: 100%">
                    <tr>
                        <th class="caption" colspan="2" style="height: 21px; width: 40%;" width="40%">
                            <asp:Literal ID="Literal37" runat="server" 
                                Text='<%# ResourceHelper.GetFromResource("Custom Field Information") %>' />
                        </th>
                    </tr>
                    <tr>
                        <th class="FormViewSubHeader" colspan="2" style="width: 40%; height: 21px" 
                            width="40%">
                            <asp:Literal ID="Literal38" runat="server" 
                                Text='<%# ResourceHelper.GetFromResource("Custom Field") %>' />
                        </th>
                    </tr>
                    <tr>
                        <td align="right" class="FormViewLabelCell" style="height: 26px; width: 30%;" 
                            width="40%">
                            <asp:Literal ID="Literal7" runat="server" Text="<%$ Resources:TimeLive.Resource, Data Type:%> " /></td>
                        <td style="height: 26px; width: 70%;">
                            <asp:DropDownList ID="ddlCustomDataType" runat="server" 
                                DataSourceID="dsCustomDataType" DataTextField="MasterCustomDataTypeName" 
                                DataValueField="MasterCustomDataTypeId" 
                                SelectedValue='<%# Bind("MasterCustomDataTypeId") %>' Width="188px" 
                                AppendDataBoundItems="True" AutoPostBack="True">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="FormViewLabelCell" style="height: 26px; width: 30%;" 
                            width="40%">
                            <span class="reqasterisk">*</span><asp:Literal ID="Literal1" runat="server" Text="<%$ Resources:TimeLive.Resource, Custom Field Name:%> " /></td>
                        <td style="height: 26px; width: 70%;">
                            <asp:TextBox ID="CustomFieldNameTextbox" runat="server" MaxLength="100" 
                                Text='<%# Bind("CustomFieldName") %>' Width="176px"></asp:TextBox>
                        <asp:RequiredFieldValidator
                        ID="RequiredFieldValidator5" runat="server" ControlToValidate="CustomFieldNameTextbox"
                        Display="Dynamic" ErrorMessage="*" Width="1px" CssClass="ErrorMessage"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr style="color: #000000">
                        <td align="right" class="FormViewLabelCell" style="height: 26px; width: 30%;" 
                            width="40%">
                            <span class="reqasterisk">*</span><asp:Literal ID="Literal2" runat="server" Text="<%$ Resources:TimeLive.Resource, Custom Field Caption:%> " /></td>
                        <td style="height: 26px; width: 70%;">
                            <asp:TextBox ID="CustomFieldCaptionTextBox" runat="server" MaxLength="100" 
                                Text='<%# Bind("CustomFieldCaption") %>' Width="176px"></asp:TextBox>
                        <asp:RequiredFieldValidator
                        ID="RequiredFieldValidator6" runat="server" ControlToValidate="CustomFieldCaptionTextBox"
                        Display="Dynamic" ErrorMessage="*" Width="1px" CssClass="ErrorMessage"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
<% If CType(Me.FormView1.FindControl("DefaultValueTextBox"), TextBox).Visible <> False Or CType(Me.FormView1.FindControl("ddlDefaultValue"), DropDownList).Visible <> False Then%>
                    <tr>
                        <td align="right" class="FormViewLabelCell" style="height: 26px; width: 30%;" 
                            width="40%">
                            <asp:Literal ID="Literal3" runat="server" Text="<%$ Resources:TimeLive.Resource, Default Value:%> " /></td>
                        <td style="height: 26px; width: 70%;">
                            <asp:DropDownList ID="ddlDefaultValue" runat="server" Visible="False" 
                                Width="188px">                                
                                <asp:ListItem Selected="True">None</asp:ListItem>                                
                            </asp:DropDownList>
                            <asp:TextBox ID="DefaultValueTextbox" runat="server" 
                                Text='<%# Bind("DefaultValue") %>' Width="70px"></asp:TextBox>
                            <asp:Label ID="lblDefaultValue" runat="server" ForeColor="Red" Text="Label" 
                                Visible="False"></asp:Label>
                        </td>
                    </tr>
<% End If%>
<% If CType(Me.FormView1.FindControl("MaximumLengthTextBox"), TextBox).Visible <> False Then%>
                    <tr>
                        <td align="right" class="FormViewLabelCell" style="height: 26px; width: 30%;" 
                            width="40%">
                            <asp:Literal ID="Literal15" runat="server" Text="<%$ Resources:TimeLive.Resource, Maximum Length:%> " /></td>
                        <td style="height: 26px; width: 70%;">
                            <asp:TextBox ID="MaximumLengthTextBox" runat="server" 
                                Text='<%# Bind("MaximumLength") %>' Width="70px"></asp:TextBox>
                            <asp:RangeValidator ID="RangeValidator1" runat="server" 
                                ControlToValidate="MaximumLengthTextBox" CssClass="ErrorMessage" 
                                Display="Dynamic" ErrorMessage="Value must be between 1 to 1000" Font-Bold="False" 
                                MaximumValue="1000" MinimumValue="1" Type="Double"></asp:RangeValidator>
                        </td>
                    </tr>
<% End If%>
<% If CType(Me.FormView1.FindControl("MinimumValueTextBox"), TextBox).Visible <> False Then%>
                    <tr>
                        <td align="right" class="FormViewLabelCell" style="height: 26px; width: 30%;" 
                            width="40%">
                            <asp:Literal ID="Literal4" runat="server" Text="<%$ Resources:TimeLive.Resource, Minimum Value:%> " /></td>
                        <td style="height: 26px; width: 70%;">
                            <asp:TextBox ID="MinimumValueTextBox" runat="server" 
                                Text='<%# Bind("MinimumValue") %>' Width="70px"></asp:TextBox>
                            <asp:RangeValidator ID="RangeValidator5" runat="server" 
                                ControlToValidate="MinimumValueTextBox" CssClass="ErrorMessage" 
                                Display="Dynamic" ErrorMessage="Numeric Required" Font-Bold="False" 
                                MaximumValue="999999999" MinimumValue="0" Type="Double"></asp:RangeValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="FormViewLabelCell" style="height: 26px; width: 30%;" 
                            width="40%">
                            <asp:Literal ID="Literal5" runat="server" Text="<%$ Resources:TimeLive.Resource, Maximum Value:%> " /></td>
                        <td style="height: 26px; width: 70%;">
                            <asp:TextBox ID="MaximumValueTextBox" runat="server" 
                                Text='<%# Bind("MaximumValue") %>' Width="70px"></asp:TextBox>
                            <asp:RangeValidator ID="RangeValidator6" runat="server" 
                                ControlToValidate="MaximumValueTextBox" CssClass="ErrorMessage" 
                                Display="Dynamic" ErrorMessage="Numeric Required" Font-Bold="False" 
                                MaximumValue="999999999" MinimumValue="0" Type="Double"></asp:RangeValidator>
                        </td>
                    </tr>
<% End If%>
                    <tr>
                        <td align="right" class="FormViewLabelCell" style="height: 26px; width: 30%;" 
                            width="40%">
                            <asp:Literal ID="Literal6" runat="server" Text="<%$ Resources:TimeLive.Resource, IsRequired:%> " /></td>
                        <td style="height: 26px; width: 70%;">
                            <asp:CheckBox ID="IsRequiredCheckBox" runat="server" 
                                Checked='<%# Bind("IsRequired") %>' />
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="FormViewLabelCell" style="height: 26px; width: 30%;" 
                            width="40%">
                            <asp:Literal ID="Literal8" runat="server" Text="<%$ Resources:TimeLive.Resource, IsDisable:%> " /></td>
                        <td style="height: 26px; width: 70%;">
                            <asp:CheckBox ID="IsDisabledCheckBox" runat="server" 
                                Checked='<%# Bind("IsDisabled") %>' />
                        </td>
                    </tr>
<% If CType(Me.FormView1.FindControl("OptionTextBox"), TextBox).Visible <> False Then%>
                    <tr>
                        <td align="right" class="FormViewLabelCell" style="height: 26px; width: 30%;" 
                            valign="top" width="40%">
                            Options: </td>
                        <td style="height: 26px; width: 70%;" valign="top">
                            <table style="border:0px">
                                <tr>
                                    <td style="border-top-style:  none; border-right-style: none; border-left-style: none; border-bottom-style: none;">
                                        <asp:TextBox ID="OptionTextBox" runat="server" MaxLength="100" Width="176px"></asp:TextBox>
                                    </td>
                                    <td rowspan="2" valign="top" style="border-top-style:  none; border-right-style: none; border-left-style: none; border-bottom-style: none;">
                                  <table style="border:0px">
                                            <tr>
                                                <td height="22" valign="top" style="border-top-style:  none; border-right-style: none; border-left-style: none; border-bottom-style: none; padding-bottom:3px;">
                                                    <asp:Button ID="btnAdd" runat="server" onclick="btnAdd_Click" Text="<%$ Resources:TimeLive.Resource, Add_text%>" Width="67px" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="22" valign="top" style="border-top-style:  none; border-right-style: none; border-left-style: none; border-bottom-style: none; padding-bottom:3px;">
                                                    <asp:Button ID="btnUpdate" runat="server" onclick="btnUpdate_Click" Text="Update" Width="68px" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="22" valign="top" style="border-top-style:  none; border-right-style: none; border-left-style: none; border-bottom-style: none; padding-bottom:3px;">
                                                    <asp:Button ID="btnDelete" runat="server" onclick="btnDelete_Click" Text="Delete" Width="68px" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="border-top-style:  none; border-right-style: none; border-left-style: none; border-bottom-style: none; padding-top:5px;">
                                        <asp:ListBox ID="OptionListBox" runat="server" AutoPostBack="True" 
                                            Height="149px" width="188px" onselectedindexchanged="OptionListBox_SelectedIndexChanged">
                                        </asp:ListBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <% End If%>
                    <tr>
                        <td align="right" class="FormViewLabelCell" style="height: 26px; width: 30%;" 
                            valign="baseline" width="40%">
                            &nbsp;</td>
                        <td align="left" class="formviewlabelcell" 
                            style="padding-bottom: 5px; padding-top: 5px; height: 26px; width: 70%;" >
                                                    <asp:Button ID="Update" runat="server" CommandName="Update" 
                                Text="<%$ Resources:TimeLive.Resource, Update_text%>" Width="68px" />
                            <asp:Button ID="Cancel" runat="server" CommandName="Cancel" 
                                Text="<%$ Resources:TimeLive.Resource, Cancel_text%>" Width="68px" 
                                ValidationGroup="Custom" />
                        </td>
                    </tr>

                </table>
            </EditItemTemplate>
            <InsertItemTemplate>
                <table class="xview" style="width: 100%" width="100%">
                    <tr>
                        <th class="caption" colspan="2" style="height: 21px; width: 40%;" >
                            <asp:Literal ID="Literal40" runat="server" 
                                Text='<%# ResourceHelper.GetFromResource("Add Custom Field") %>' />
                        </th>
                    </tr>
                    <tr>
                        <th class="FormViewSubHeader" colspan="2" style="width: 40%; height: 21px" >
                            <asp:Literal ID="Literal41" runat="server" 
                                Text='<%# ResourceHelper.GetFromResource("Custom Field") %>' />
                        </th>
                    </tr>
                    <tr>
                        <td align="right" class="FormViewLabelCell" style="height: 26px; width: 30%;" >
                            <asp:Literal ID="Literal7" runat="server" Text="<%$ Resources:TimeLive.Resource, Data Type:%> " /></td>
                        <td style="height: 26px; width: 70%;">
                            <asp:DropDownList ID="ddlCustomDataType" runat="server" 
                                DataSourceID="dsCustomDataType" DataTextField="MasterCustomDataTypeName" 
                                DataValueField="MasterCustomDataTypeId" 
                                SelectedValue='<%# Bind("MasterCustomDataTypeId") %>' Width="188px" 
                                AutoPostBack="True" 
                                onselectedindexchanged="ddlCustomDataType_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="FormViewLabelCell" style="height: 26px; width: 30%;" >
                            <span class="reqasterisk">*</span><asp:Literal ID="Literal9" runat="server" Text="<%$ Resources:TimeLive.Resource, Custom Field Name:%> " /></td>
                        <td style="height: 26px; width: 70%;">
                            <asp:TextBox ID="CustomFieldNameTextbox" runat="server" MaxLength="100" 
                                Text='<%# Bind("CustomFieldName") %>' Width="176px"></asp:TextBox>
                        <asp:RequiredFieldValidator
                        ID="RequiredFieldValidator2" runat="server" ControlToValidate="CustomFieldNameTextbox"
                        Display="Dynamic" ErrorMessage="*" Width="1px" CssClass="ErrorMessage"></asp:RequiredFieldValidator>
                    <br />
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="FormViewLabelCell" style="height: 26px; width: 30%;" >
                            <span class="reqasterisk">*</span><asp:Literal ID="Literal10" runat="server" Text="<%$ Resources:TimeLive.Resource, Custom Field Caption:%> " /></td>
                        <td style="height: 26px; width: 70%;">
                            <asp:TextBox ID="CustomFieldCaptionTextBox" runat="server" MaxLength="100" 
                                Text='<%# Bind("CustomFieldCaption") %>' Width="176px"></asp:TextBox>
                        <asp:RequiredFieldValidator
                        ID="RequiredFieldValidator3" runat="server" ControlToValidate="CustomFieldCaptionTextBox"
                        Display="Dynamic" ErrorMessage="*" Width="1px" CssClass="ErrorMessage"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
<% If CType(Me.FormView1.FindControl("DefaultValueTextBox"), TextBox).Visible <> False Or CType(Me.FormView1.FindControl("ddlDefaultValue"), DropDownList).Visible <> False Then%>
                    <tr>
                        <td align="right" class="FormViewLabelCell" style="height: 26px; width: 30%;" >
                            <asp:Literal ID="Literal11" runat="server" Text="<%$ Resources:TimeLive.Resource, Default Value:%> " /></td>
                        <td style="height: 26px; width: 70%;">
                            <asp:DropDownList ID="ddlDefaultValue" runat="server" Visible="False" 
                                Width="188px">
                                <asp:ListItem Selected="True">None</asp:ListItem>
                            </asp:DropDownList>
                            <asp:TextBox ID="DefaultValueTextBox" runat="server" 
                                Text='<%# Bind("DefaultValue") %>' Width="70px"></asp:TextBox>
                            <asp:Label ID="lblDefaultValue" runat="server" ForeColor="Red" Text="Label" 
                                Visible="False"></asp:Label>
                        </td>
                    </tr>
<% End If%>
 <% If CType(Me.FormView1.FindControl("MaximumLengthTextBox"), TextBox).Visible <> False Then%>
                    <tr>
                        <td align="right" class="FormViewLabelCell" style="height: 26px; width: 30%;" >
                            Maximum Length:</td>
                        <td style="height: 26px; width: 70%;">
                            <asp:TextBox ID="MaximumLengthTextBox" runat="server" 
                                Text='<%# Bind("MaximumLength") %>' Width="70px"></asp:TextBox>
                            <asp:RangeValidator ID="RangeValidator1" runat="server" 
                                ControlToValidate="MaximumLengthTextBox" CssClass="ErrorMessage" 
                                Display="Dynamic" ErrorMessage="Value must be between 1 to 1000" Font-Bold="False" 
                                MaximumValue="1000" MinimumValue="1" Type="Double"></asp:RangeValidator>
                        </td>
                    </tr>
<% End If%>
 <% If CType(Me.FormView1.FindControl("MinimumValueTextBox"), TextBox).Visible <> False Then%>
                    <tr>
                        <td align="right" class="FormViewLabelCell" style="height: 26px; width: 30%;" >
                            <asp:Literal ID="Literal12" runat="server" Text="<%$ Resources:TimeLive.Resource, Minimum Value:%> " /></td>
                        <td style="height: 26px; width: 70%;">
                            <asp:TextBox ID="MinimumValueTextBox" runat="server" 
                                Text='<%# Bind("MinimumValue") %>' Width="70px"></asp:TextBox>
                            <asp:RangeValidator ID="RangeValidator2" runat="server" 
                                ControlToValidate="MinimumValueTextBox" CssClass="ErrorMessage" 
                                Display="Dynamic" ErrorMessage="Numeric Required" Font-Bold="False" 
                                MaximumValue="999999999" MinimumValue="0" Type="Double"></asp:RangeValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="FormViewLabelCell" style="height: 26px; width: 30%;" >
                            <asp:Literal ID="Literal13" runat="server" Text="<%$ Resources:TimeLive.Resource, Maximum Value:%> " /></td>
                        <td style="height: 26px; width: 70%;">
                            <asp:TextBox ID="MaximumValueTextBox" runat="server" 
                                Text='<%# Bind("MaximumValue") %>' Width="70px"></asp:TextBox>
                            <asp:RangeValidator ID="RangeValidator3" runat="server" 
                                ControlToValidate="MaximumValueTextBox" CssClass="ErrorMessage" 
                                Display="Dynamic" ErrorMessage="Numeric Required" Font-Bold="False" 
                                MaximumValue="999999999" MinimumValue="0" Type="Double"></asp:RangeValidator>
                        </td>
                    </tr>
<% End If%>
                    <tr>
                        <td align="right" class="FormViewLabelCell" style="height: 26px; width: 30%;" >
                            <asp:Literal ID="Literal14" runat="server" Text="<%$ Resources:TimeLive.Resource, IsRequired:%> " /></td>
                        <td style="height: 26px; width: 70%;">
                            <asp:CheckBox ID="IsRequiredCheckBox" runat="server" 
                                Checked='<%# Bind("IsRequired") %>' />
                        </td>
                    </tr>
<% If CType(Me.FormView1.FindControl("OptionTextBox"), TextBox).Visible <> False Then%>
                    <tr>
                        <td align="right" class="FormViewLabelCell" valign="top" width="30%">
                            Options: </td>
                        <td style="height: 26px; width: 70%;">
                            <table style="border: 0px">
                                <tr>
                                    <td style="border-top-style:  none; border-right-style: none; border-left-style: none; border-bottom-style: none; padding-bottom: 5px;">
                                        <asp:TextBox ID="OptionTextBox" runat="server" MaxLength="100" Width="176px"></asp:TextBox>
                                    </td>
                                    <td rowspan="2" valign="top" style="border-top-style:  none; border-right-style: none; border-left-style: none; border-bottom-style: none;">
                                        <table style="border: 0px">
                                            <tr>
                                                <td valign="top" style="border-top-style:  none; border-right-style: none; border-left-style: none; border-bottom-style: none; padding-bottom: 3px;">
                                                    <asp:Button ID="btnAdd" runat="server" onclick="btnAdd_Click" Text="<%$ Resources:TimeLive.Resource, Add_text%>" Width="68px" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td valign="top" style="border-top-style:  none; border-right-style: none; border-left-style: none; border-bottom-style: none; padding-bottom: 3px;">
                                                    <asp:Button ID="btnUpdate" runat="server" onclick="btnUpdate_Click" Text="Update" Width="68px" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td valign="top" style="border-top-style:  none; border-right-style: none; border-left-style: none; border-bottom-style: none; padding-bottom: 3px;">
                                                    <asp:Button ID="btnDelete" runat="server" onclick="btnDelete_Click" Text="Delete" Width="68px" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="border-top-style:  none; border-right-style: none; border-left-style: none; border-bottom-style: none;">
                                        <asp:ListBox ID="OptionListBox" runat="server" AutoPostBack="True" 
                                            Height="149px" width="188px" onselectedindexchanged="OptionListBox_SelectedIndexChanged">
                                        </asp:ListBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <% End If%>
                    <tr>
                        <td align="right" class="FormViewLabelCell" style="height: 26px; width: 30%;" 
                            valign="baseline" >
                            </td>
                            <td align="left" class="formviewlabelcell" 
                            style="padding-bottom: 5px; padding-top: 5px; height: 26px; width: 70%;" >
                              <asp:Button ID="Add" runat="server" CommandName="Insert" 
                                Text="<%$ Resources:TimeLive.Resource, Add_text%>" Width="68px" />
                            <asp:Button ID="btnCancel" runat="server" CommandName="Cancel" 
                                Text="<%$ Resources:TimeLive.Resource, Cancel_text%>" Width="68px" 
                                ValidationGroup="Custom" onclick="btnCancel_Click" />
                        </td>
                    </tr>
                 </table>
            </InsertItemTemplate>
            </asp:FormView>
    </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
    id="dsAccountCustomFieldManageForFormView" runat="server" 
            OldValuesParameterFormatString="original_{0}" 
    SelectMethod="GetAccountCustomFieldByAccountIdandAccountCustomFieldId" 
    TypeName="AccountCustomFieldBLL" InsertMethod="AddCustomFieldManage" 
    UpdateMethod="UpdateCustomFieldManage">
    <InsertParameters>
        <asp:SessionParameter Name="AccountId" SessionField="AccountId" Type="Int32" />
        <asp:Parameter DbType="Guid" Name="MasterCustomDataTypeId" />
        <asp:QueryStringParameter DbType="Guid" 
            DefaultValue="13dbff37-a092-4ae2-a919-775cbed0edc0" Name="MasterEntityTypeId" 
            QueryStringField="MasterEntityTypeId" />
        <asp:Parameter Name="DatabaseFieldName" Type="String" />
        <asp:Parameter Name="CustomFieldName" Type="String" />
        <asp:Parameter Name="CustomFieldCaption" Type="String" />
        <asp:Parameter Name="DefaultValue" Type="String" />
        <asp:Parameter Name="MaximumLength" Type="Int32" />
        <asp:Parameter Name="MinimumValue" Type="Int32" />
        <asp:Parameter Name="MaximumValue" Type="Int32" />
        <asp:Parameter Name="DropDownOptions" Type="String" />
        <asp:Parameter Name="IsRequired" Type="Boolean" />
        <asp:Parameter Name="IsDisabled" Type="Boolean" />
        <asp:Parameter Name="CreatedOn" Type="DateTime" />
        <asp:Parameter Name="CreatedByEmployeeId" Type="Int32" />
        <asp:Parameter Name="ModifiedOn" Type="DateTime" />
        <asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" />
    </InsertParameters>
    <SelectParameters>
<asp:SessionParameter SessionField="AccountId" DefaultValue="66" Name="AccountId" Type="Int32"></asp:SessionParameter>
                <asp:ControlParameter ControlID="GridView1" DbType="Guid" 
            Name="AccountCustomFieldId" PropertyName="SelectedValue" />
    </SelectParameters>
    <UpdateParameters>
        <asp:ControlParameter ControlID="GridView1" DbType="Guid" 
            Name="Original_AccountCustomFieldId" PropertyName="SelectedValue" />
        <asp:SessionParameter Name="AccountId" SessionField="AccountId" Type="Int32" />
        <asp:Parameter DbType="Guid" Name="MasterCustomDataTypeId" />
        <asp:Parameter DbType="Guid" DefaultValue="" Name="MasterEntityTypeId" />
        <asp:Parameter Name="DatabaseFieldName" Type="String" />
        <asp:Parameter Name="CustomFieldName" Type="String" />
        <asp:Parameter Name="CustomFieldCaption" Type="String" />
        <asp:Parameter Name="DefaultValue" Type="String" />
        <asp:Parameter Name="MaximumLength" Type="Int32" />
        <asp:Parameter Name="MinimumValue" Type="Int32" />
        <asp:Parameter Name="MaximumValue" Type="Int32" />
        <asp:Parameter Name="DropDownOptions" Type="String" />
        <asp:Parameter Name="IsRequired" Type="Boolean" />
        <asp:Parameter Name="IsDisabled" Type="Boolean" />
        <asp:Parameter Name="CreatedOn" Type="DateTime" />
        <asp:Parameter Name="CreatedByEmployeeId" Type="Int32" />
        <asp:Parameter Name="ModifiedOn" Type="DateTime" />
        <asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" />
    </UpdateParameters>
</asp:ObjectDataSource> 
<asp:ObjectDataSource ID="dsCustomDataType" runat="server" OldValuesParameterFormatString="original_{0}"
    SelectMethod="GetMasterCustomDataType" TypeName="AccountCustomFieldBLL"></asp:ObjectDataSource>
 
        
     
