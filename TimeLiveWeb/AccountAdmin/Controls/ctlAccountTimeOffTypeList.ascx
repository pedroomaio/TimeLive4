<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlAccountTimeOffTypeList.ascx.vb"
    Inherits="AccountAdmin_Controls_ctlAccountTimeOffTypeList" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <x:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="AccountTimeOffTypeId"
            DataSourceID="dsAccountTimeOffTypeGridViewObject" Caption="<%$ Resources:TimeLive.Resource, Time Off Types List %>"
            Width="98%" SkinID="xgridviewSkinEmployee" AllowSorting="True">
            <Columns>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Color%> " ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                    <ItemTemplate>
                        <asp:Panel ID="pnlColor" runat="server" BackColor='<%# UIUtilities.ConvertFromHexToColor(Eval("Color").ToString()) %>' style="width: 10px; height: 10px;"></asp:Panel>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="AccountTimeOffType" HeaderText="<%$ Resources:TimeLive.Resource, Time off types %>"
                    SortExpression="AccountTimeOffType">
                    <ItemStyle Width="83%" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Request Required %>"
                    SortExpression="IsTimeOffRequestRequired">
                    <ItemTemplate>
                        <asp:Label ID="lblTimeOffRequest" runat="server" __designer:wfdid="w78"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="12%" HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Paid%>" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                    <ItemTemplate>
                        <asp:Label ID="lblPaid" runat="server" Text='<%#IIf(Boolean.Parse(Eval("Paid").ToString()), "Yes", "No")%>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="7%" HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, ScheduleWeekends%>" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                    <ItemTemplate>
                        <asp:Label ID="lblScheduleWeekends" runat="server" Text='<%#IIf(Boolean.Parse(Eval("ScheduleWeekends").ToString()), "Yes", "No")%>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="7%" HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Order%>" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                    <ItemTemplate>
                        <asp:Label ID="lblDisplayOrder" runat="server" Text='<%# Bind("DisplayOrder") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="7%" HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:CommandField HeaderText="<%$ Resources:TimeLive.Resource, Edit_Text %>" SelectText="Edit"
                    ShowSelectButton="True">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" Width="1%" CssClass="edit_button" />
                </asp:CommandField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Delete_text %>" ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete"
                            OnClientClick='<%# ResourceHelper.GetDeleteMessageJavascript()%>' />
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" Width="1%" CssClass="delete_button" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:Image ID="Image2" runat="server" ImageUrl="~/Images/Disabled.gif" ToolTip="<%$ Resources:TimeLive.Resource, Disabled_text%> " />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/Disabled.gif" Visible='<%# IIF(IsDBNull(Eval("IsDisabled")),"False",Eval("IsDisabled")) %>'
                            ToolTip="<%$ Resources:TimeLive.Resource, Disabled_text%> " />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="1%" />
                </asp:TemplateField>
            </Columns>
        </x:GridView>
        <asp:ObjectDataSource ID="dsAccountTimeOffTypeGridViewObject" runat="server" InsertMethod="AddAccountTimeOffTypes"
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetAccountTimeOffTypesByAccountIdForGridView"
            TypeName="AccountTimeOffTypeBLL" UpdateMethod="UpdateAccountTimeOffTypes">
            <UpdateParameters>
                <asp:Parameter Name="AccountTimeOffType" Type="String" />
                <asp:Parameter Name="IsTimeOffRequestRequired" Type="Boolean" />
                <asp:Parameter Name="Original_AccountTimeOffTypeId" />
                <asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" />
                <asp:Parameter Name="IsDisabled" Type="Boolean" />
            </UpdateParameters>
            <SelectParameters>
                <asp:SessionParameter Name="AccountId" SessionField="AccountId" Type="Int32" />
            </SelectParameters>
            <InsertParameters>
                <asp:Parameter Name="AccountId" Type="Int32" />
                <asp:Parameter Name="AccountTimeOffType" Type="String" />
                <asp:Parameter Name="IsTimeOffRequestRequired" Type="Boolean" />
                <asp:Parameter Name="CreatedByEmployeeId" Type="Int32" />
                <asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" />
            </InsertParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="dsAccountTimeOffTypeFormViewObject" runat="server" InsertMethod="AddAccountTimeOffTypes"
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetAccountTimeOffTypesByAccountTimeOffTypeId"
            TypeName="AccountTimeOffTypeBLL" UpdateMethod="UpdateAccountTimeOffTypes">
            <UpdateParameters>
                <asp:Parameter Name="AccountTimeOffType" Type="String" />
                <asp:Parameter Name="IsTimeOffRequestRequired" Type="Boolean" />
                <asp:Parameter Name="Original_AccountTimeOffTypeId" />
                <asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" />
                <asp:Parameter Name="IsDisabled" Type="Boolean" />
                <asp:Parameter Name="Paid" Type="Boolean" />
                <asp:Parameter Name="Color" Type="String" />
                <asp:Parameter Name="BriefExplanation" Type="String" />
                <asp:Parameter Name="ScheduleWeekends" Type="Boolean" />
                <asp:Parameter Name="DisplayOrder" Type ="Int32" />
            </UpdateParameters>
            <SelectParameters>
                <asp:ControlParameter ControlID="GridView1" Name="AccountTimeOffTypeId" PropertyName="SelectedValue" />
            </SelectParameters>
            <InsertParameters>
                <asp:SessionParameter Name="AccountId" SessionField="AccountId" Type="Int32" />
                <asp:Parameter Name="AccountTimeOffType" Type="String" />
                <asp:Parameter Name="IsTimeOffRequestRequired" Type="Boolean" />
                <asp:Parameter Name="CreatedByEmployeeId" Type="Int32" />
                <asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" />
                <asp:Parameter Name="Paid" Type="Boolean" />
                <asp:Parameter Name="Color" Type="String" />
                <asp:Parameter Name="BriefExplanation" Type="String" />
                <asp:Parameter Name="DisplayOrder" Type ="Int32" />
                <asp:Parameter Name="ScheduleWeekends" Type="Boolean" />
            </InsertParameters>
        </asp:ObjectDataSource>
    </ContentTemplate>
</asp:UpdatePanel>
<br />
<asp:UpdatePanel ID="UpdatePanel2" runat="server">
    <ContentTemplate>
        <asp:FormView ID="FormView1" SkinID="formviewSkinEmployee" runat="server" DataKeyNames="AccountTimeOffTypeId"
            DataSourceID="dsAccountTimeOffTypeFormViewObject" DefaultMode="Insert" Width="500px">
            <EditItemTemplate>
                <table class="xview" width="100%">
                    <tr>
                        <th class="caption" colspan="2">
                            <asp:Literal ID="Literal5" runat="server" Text='<%# ResourceHelper.GetFromResource("Time Off Types Information")%> ' />
                        </th>
                    </tr>
                    <tr>
                        <th class="FormViewSubHeader" colspan="2">
                            <asp:Literal ID="Literal1" runat="server" Text='<%# ResourceHelper.GetFromResource("Time Off Types")%> ' />
                        </th>
                    </tr>
                    <tr>
                        <td align="right" class="FormViewLabelCell" style="width: 35%">
                            <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="txtTimeOffType">
                                <asp:Literal ID="Literal2" runat="server" Text='<%# ResourceHelper.GetFromResource("Time Off Types")%> ' />:</asp:Label>
                        </td>
                        <td style="width: 65%">
                            <asp:TextBox ID="txtTimeOffType" runat="server" MaxLength="50" Text='<%# Bind("AccountTimeOffType") %>'
                                Width="176px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                                    runat="server" ControlToValidate="txtTimeOffType" CssClass="ErrorMessage" Display="Dynamic"
                                    ErrorMessage="*"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="FormViewLabelCell" style="width: 35%">
                            <asp:Literal ID="Literal3" runat="server" Text='<%# ResourceHelper.GetFromResource("Time Off Request Required:")%> ' />
                        </td>
                        <td style="width: 65%">
                            <asp:CheckBox ID="chkTimeOffRequired" runat="server" Checked='<%# Bind("IsTimeOffRequestRequired") %>' />
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="FormViewLabelCell" style="width: 35%">
                            <asp:Literal ID="Literal12" runat="server" Text='<%# ResourceHelper.GetFromResource("Paid:") %>' />
                        </td>
                        <td style="width: 65%">
                            <asp:CheckBox ID="chkPaid" runat="server" Checked='<%# Bind("Paid") %>' />
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="FormViewLabelCell" style="width: 35%">
                            <asp:Literal ID="Literal13" runat="server" Text='<%# ResourceHelper.GetFromResource("Color:") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="txtSelectedColor" runat="server" Text='<%# Bind("Color") %>'></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="FormViewLabelCell" style="width: 35%">
                            <asp:Literal ID="Literal14" runat="server" Text='<%# ResourceHelper.GetFromResource("Brief Explanation:") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="txtExplanation" runat="server" MaxLength="50" Text='<%# Bind("BriefExplanation") %>'
                                Width="176px" Height="50px" TextMode="MultiLine">
                            </asp:TextBox>
                        </td>
                    </tr>
                     <tr>
                        <td align="right" class="FormViewLabelCell" style="width: 35%">
                            <asp:Literal ID="Literal16" runat="server" Text="<%$ Resources:TimeLive.Resource,Display Order:%>" />
                        </td>
                        <td style="width: 65%">
                             <asp:TextBox Width ="5%" ID="txtDisplayOrder" runat="server" Text='<%# Bind("DisplayOrder") %>'></asp:TextBox>
                            <asp:RangeValidator ID="RangeValidator2" runat="server" __designer:wfdid="w16" Display="Dynamic" CssClass="ErrorMessage" ControlToValidate="txtDisplayOrder" Type="Integer" MinimumValue="0" MaximumValue="99999" ErrorMessage="Incorrect Value"></asp:RangeValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3"
                                    runat="server" ControlToValidate="txtDisplayOrder" CssClass="ErrorMessage" Display="Dynamic"
                                    ErrorMessage="*"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="FormViewLabelCell" style="width: 35%">
                            <asp:Literal ID="Literal15" runat="server" Text='<%# ResourceHelper.GetFromResource("ScheduleWeekends:") %>' />
                        </td>
                        <td style="width: 65%">
                            <asp:CheckBox ID="CheckBox1" runat="server" Checked='<%# Bind("ScheduleWeekends") %>' />
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="FormViewLabelCell" style="width: 35%">
                            <asp:Literal ID="Literal4" runat="server" Text='<%# ResourceHelper.GetFromResource("Disabled:")%> ' />
                        </td>
                        <td style="width: 65%">
                            <asp:CheckBox ID="DisabledCheckBox" runat="server" Checked='<%# Bind("IsDisabled") %>' />
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="FormViewLabelCell" style="width: 35%">
                        </td>
                        <td style="width: 65%; padding-bottom: 5px;">
                            <asp:Button ID="btnUpdate" runat="server" CommandName="Update" Text="<%$ Resources:TimeLive.Resource, Update_text%> "
                                Width="68px" />&nbsp;<asp:Button ID="btnCancel" runat="server" CommandName="Cancel"
                                    Text="<%$ Resources:TimeLive.Resource, Cancel_text%> " Width="68px" />
                        </td>
                    </tr>
                </table>
            </EditItemTemplate>
            <InsertItemTemplate>
                <table class="xview" width="100%">
                    <tr>
                        <th class="caption" colspan="2">
                            <asp:Literal ID="Literal4" runat="server" Text='<%# ResourceHelper.GetFromResource("Time Off Types Information")%> ' />
                        </th>
                    </tr>
                    <tr>
                        <th class="FormViewSubHeader" colspan="2">
                            <asp:Literal ID="Literal6" runat="server" Text='<%# ResourceHelper.GetFromResource("Time Off Types")%> ' />
                        </th>
                    </tr>
                    <tr>
                        <td align="right" class="FormViewLabelCell" style="width: 35%">
                            <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="txtTimeOffType">
                                <asp:Literal ID="Literal7" runat="server" Text='<%# ResourceHelper.GetFromResource("Time Off Types:")%> ' /></asp:Label>
                        </td>
                        <td style="width: 65%">
                            <asp:TextBox ID="txtTimeOffType" runat="server" MaxLength="50" Text='<%# Bind("AccountTimeOffType") %>'
                                Width="176px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTimeOffType"
                                CssClass="ErrorMessage" Display="Dynamic" ErrorMessage="*">
                            </asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="FormViewLabelCell" style="width: 35%">
                            <asp:Literal ID="Literal8" runat="server" Text='<%# ResourceHelper.GetFromResource("Time Off Request Required:")%> ' />
                        </td>
                        <td style="width: 65%">
                            <asp:CheckBox ID="chkTimeOffRequired" runat="server" Checked='<%# Bind("IsTimeOffRequestRequired") %>' />
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="FormViewLabelCell" style="width: 35%">
                            <asp:Literal ID="Literal9" runat="server" Text='<%# ResourceHelper.GetFromResource("Paid:") %>' />
                        </td>
                        <td style="width: 65%">
                            <asp:CheckBox ID="chkPaid" runat="server" Checked='<%# Bind("Paid") %>' />
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="FormViewLabelCell" style="width: 35%">
                            <asp:Literal ID="Literal10" runat="server" Text='<%# ResourceHelper.GetFromResource("Color:") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="txtSelectedColor" runat="server" Text='<%# Bind("Color") %>'></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="FormViewLabelCell" style="width: 35%">
                            <asp:Literal ID="Literal11" runat="server" Text='<%# ResourceHelper.GetFromResource("Brief Explanation:") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="txtExplanation" runat="server" MaxLength="50" Text='<%# Bind("BriefExplanation") %>'
                                Width="176px" Height="50px" TextMode="MultiLine">
                            </asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtExplanation"
                                CssClass="ErrorMessage" Display="Dynamic" ErrorMessage="*">
                            </asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="FormViewLabelCell" style="width: 35%">
                            <asp:Literal ID="Literal16" runat="server" Text='<%$ Resources:TimeLive.Resource,Display Order:%>' />
                        </td>
                        <td style="width: 65%">
                             <asp:TextBox Width ="5%" ID="txtDisplayOrder" runat="server" Text='<%# Bind("DisplayOrder") %>'></asp:TextBox>
                            <asp:RangeValidator ID="RangeValidator2" runat="server" __designer:wfdid="w16" Display="Dynamic" CssClass="ErrorMessage" ControlToValidate="txtDisplayOrder" Type="Integer" MinimumValue="0" MaximumValue="99999" ErrorMessage="Incorrect Value"></asp:RangeValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4"
                                    runat="server" ControlToValidate="txtDisplayOrder" CssClass="ErrorMessage" Display="Dynamic"
                                    ErrorMessage="*"></asp:RequiredFieldValidator>
                         </td>
                    </tr>
                    <tr>
                        <td align="right" class="FormViewLabelCell" style="width: 35%">
                            <asp:Literal ID="Literal15" runat="server" Text='<%# ResourceHelper.GetFromResource("ScheduleWeekends:") %>' />
                        </td>
                        <td style="width: 65%">
                            <asp:CheckBox ID="CheckBox1" runat="server" Checked='<%# Bind("ScheduleWeekends") %>' />
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="FormViewLabelCell" style="width: 35%">
                        </td>
                        <td style="width: 65%; padding-bottom: 5px;">
                            <asp:Button ID="btnAdd" runat="server" CommandName="Insert" Text="<%$ Resources:TimeLive.Resource, Add_text%> "
                                Width="68px" />
                        </td>
                    </tr>
                </table>
            </InsertItemTemplate>
        </asp:FormView>
    </ContentTemplate>
</asp:UpdatePanel>