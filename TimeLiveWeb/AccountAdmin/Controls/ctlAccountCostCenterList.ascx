<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlAccountCostCenterList.ascx.vb" Inherits="AccountAdmin_Controls_ctlAccountCostCenterList" %>
<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <x:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="AccountCostCenterId" SkinID="xgridviewskinemployee" Caption='<%# ResourceHelper.GetFromResource("Cost Center List") %>'
            DataSourceID="dsAccountCostCenterGridViewObject" Width="98%" >
            <Columns>
                <asp:BoundField DataField="AccountCostCenterId" HeaderText="<%$ Resources:TimeLive.Resource, Id %>" InsertVisible="False"
                    ReadOnly="True" SortExpression="AccountCostCenterId">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Cost Center Code %>" SortExpression="AccountCostCenterCode">
                    <edititemtemplate>
<asp:TextBox id="TextBox1" runat="server" __designer:wfdid="w34" Text='<%# Bind("AccountCostCenterCode") %>'></asp:TextBox>
</edititemtemplate>
                    <headertemplate>
<asp:LinkButton id="LinkButton3" runat="server" Text='<%# ResourceHelper.GetFromResource("Cost Center Code") %>' CommandArgument="AccountCostCenterCode" CommandName="Sort" CausesValidation="False"></asp:LinkButton>
</headertemplate>
                    <itemtemplate>
<asp:Label id="Label1" runat="server" __designer:wfdid="w33" Text='<%# Bind("AccountCostCenterCode") %>'></asp:Label>
</itemtemplate>
                    <itemstyle width="15%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Cost Center %>" SortExpression="AccountCostCenter">
                    <edititemtemplate>
<asp:TextBox id="TextBox2" runat="server" __designer:wfdid="w38" Text='<%# Bind("AccountCostCenter") %>'></asp:TextBox> 
</edititemtemplate>
                    <headertemplate>
<asp:LinkButton id="LinkButton4" runat="server" Text='<%# ResourceHelper.GetFromResource("Cost Center") %>' CommandArgument="AccountCostCenter" CommandName="Sort" CausesValidation="False"></asp:LinkButton>
</headertemplate>
                    <itemtemplate>
<asp:Label id="Label2" runat="server" __designer:wfdid="w37" Text='<%# Bind("AccountCostCenter") %>'></asp:Label> 
</itemtemplate>
                    <itemstyle width="75%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Edit_text %>" ShowHeader="False">
                    <itemtemplate>
<asp:LinkButton id="LinkButton2" runat="server" CausesValidation="False" CommandName="Select" 
                            ToolTip="<%$ Resources:TimeLive.Resource, Edit_text %>" Text="Edit" 
                            __designer:wfdid="w1"></asp:LinkButton>
</itemtemplate>
                    <itemstyle cssclass="edit_button" width="1%" HorizontalAlign="Center" VerticalAlign="Bottom" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Delete_text %>" >
                    <ItemTemplate>
<asp:LinkButton id="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete" ToolTip="<%$ Resources:TimeLive.Resource, Delete_text%> " Text="Delete" __designer:wfdid="w2" Visible='<%# IsDBNull(Eval("MasterCostCenterId")) %>' OnClientClick='<%# ResourceHelper.GetDeleteMessageJavascript()%>'></asp:LinkButton> 
</ItemTemplate>
                    <ItemStyle Width="1%" cssclass="delete_button" VerticalAlign="Bottom" HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Disabled">
                    <HeaderTemplate>
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/Disabled.gif" ToolTip="<%$ Resources:TimeLive.Resource, Disabled_text%> " />
                    
</HeaderTemplate>
                    <ItemTemplate>
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/Disabled.gif" ToolTip="<%$ Resources:TimeLive.Resource, Disabled_text%> "
                            Visible='<%# IIF(IsDBNull(Eval("IsDisabled")),"False",Eval("IsDisabled")) %>' />
                    
</ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="1%" />
                </asp:TemplateField>
            </Columns>
        </x:GridView>
        <asp:ObjectDataSource ID="dsAccountCostCenterGridViewObject" runat="server" DeleteMethod="DeleteAccountCostCenter"
            InsertMethod="AddAccountCostCenter" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetAccountCostCenterByAccountId" TypeName="AccountCostCenterBLL"
            UpdateMethod="UpdateAccountCostCenter">
            <DeleteParameters>
                <asp:Parameter Name="Original_AccountCostCenterId" Type="Int32" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="AccountCostCenterCode" Type="String" />
                <asp:Parameter Name="AccountCostCenter" Type="String" />
                <asp:SessionParameter DefaultValue="3" Name="AccountId" SessionField="AccountId"
                    Type="Int32" />
                <asp:Parameter Name="Original_AccountCostCenterId" Type="Int32" />
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
                <asp:Parameter Name="AccountCostCenterCode" Type="String" />
                <asp:Parameter Name="AccountCostCenter" Type="String" />
                <asp:SessionParameter DefaultValue="4" Name="AccountId" SessionField="AccountId"
                    Type="Int32" />
                <asp:Parameter Name="CreatedOn" Type="DateTime" />
                <asp:Parameter Name="CreatedByEmployeeId" Type="Int32" />
                <asp:Parameter Name="ModifiedOn" Type="DateTime" />
                <asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" />
                <asp:Parameter Name="SortOrder" Type="Int32" />
            </InsertParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="dsAccountCostCenterFormViewObject" runat="server" DeleteMethod="DeleteAccountCostCenter"
            InsertMethod="AddAccountCostCenter" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetAccountCostCenterByAccountCostCenterId" TypeName="AccountCostCenterBLL"
            UpdateMethod="UpdateAccountCostCenter">
            <DeleteParameters>
                <asp:Parameter Name="Original_AccountCostCenterId" Type="Int32" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="AccountCostCenterCode" Type="String" />
                <asp:Parameter Name="AccountCostCenter" Type="String" />
                <asp:SessionParameter DefaultValue="3" Name="AccountId" SessionField="AccountId"
                    Type="Int32" />
                <asp:Parameter Name="Original_AccountCostCenterId" Type="Int32" />
                <asp:Parameter Name="ModifiedOn" Type="DateTime" />
                <asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" />
                <asp:Parameter Name="IsDisabled" Type="Boolean" />
                <asp:Parameter Name="SortOrder" Type="Int32" />
            </UpdateParameters>
            <SelectParameters>
                <asp:ControlParameter ControlID="GridView1" Name="AccountCostCenterId" PropertyName="SelectedValue"
                    Type="Int32" />
            </SelectParameters>
            <InsertParameters>
                <asp:Parameter Name="AccountCostCenterCode" Type="String" />
                <asp:Parameter Name="AccountCostCenter" Type="String" />
                <asp:SessionParameter DefaultValue="3" Name="AccountId" SessionField="AccountId"
                    Type="Int32" />
                <asp:Parameter Name="CreatedOn" Type="DateTime" />
                <asp:Parameter Name="CreatedByEmployeeId" Type="Int32" />
                <asp:Parameter Name="ModifiedOn" Type="DateTime" />
                <asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" />
                <asp:Parameter Name="SortOrder" Type="Int32" />
            </InsertParameters>
        </asp:ObjectDataSource>
    </ContentTemplate>
</asp:UpdatePanel>
<br />
<asp:UpdatePanel ID="UpdatePanel2" runat="server">
    <ContentTemplate>
        <asp:FormView ID="FormView1" runat="server" DataKeyNames="AccountCostCenterId" 
            DataSourceID="dsAccountCostCenterFormViewObject" DefaultMode="Insert" 
            SkinID="FormViewSkinEmployee" Width="450px">
            <EditItemTemplate><table width="500" class="xFormView">
                <tr>
                    <th colspan="2" class="caption">
                        <asp:Literal ID="Literal1" runat="server" Text='<%# ResourceHelper.GetFromResource("Cost Center Information")%> ' /></th>
                </tr>
                <tr>
                    <th colspan="2" class="FormViewSubHeader">
                        <asp:Literal ID="Literal2" runat="server" Text='<%# ResourceHelper.GetFromResource("Cost Center")%> ' /></th>
                </tr>
                <tr>
                    <td align="right" class="FormViewLabelCell" style="width: 200px">
                       
<asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="txtSortOrder">
                        <asp:Literal ID="Literal9" runat="server" Text="<%$ Resources:TimeLive.Resource, Sort Order:%> " /></asp:Label></td><td style="width: 300px">
                        <asp:TextBox 
                            ID="txtSortOrder" runat="server" MaxLength="10" Text='<%# Bind("SortOrder") %>'
                            style="text-align:right;" Width="25px"></asp:TextBox></td></tr><tr><td 
                        align="right" style="width: 200px; padding-top: 5px;" class="FormViewLabelCell"><span 
                        class="reqasterisk">*</span><asp:Label ID="Label4" runat="server" AssociatedControlID="CostCenterCodeTextBox">
                  <asp:Literal ID="Literal3" runat="server" Text='<%# ResourceHelper.GetFromResource("Cost Center Code:")%> ' /></asp:Label></td><td style="width: 300px"><asp:TextBox ID="CostCenterCodeTextBox" 
                            runat="server" MaxLength="7" Text='<%# Bind("AccountCostCenterCode") %>' 
                            Width="176px"></asp:TextBox><asp:RequiredFieldValidator 
                            ID="RequiredFieldValidator1" runat="server" 
                            ControlToValidate="CostCenterCodeTextBox" CssClass="ErrorMessage" 
                            ErrorMessage="*"></asp:RequiredFieldValidator></td></tr><tr><td 
                        align="right" style="width: 200px"><asp:Label ID="Label6" runat="server" 
                        AssociatedControlID="CostCenterCodeTextBox">
                  <asp:Literal ID="Literal4" runat="server" Text='<%# ResourceHelper.GetFromResource("Cost Center:")%> ' /></asp:Label></td><td style="width: 300px"><asp:TextBox ID="CostCenterTextBox" runat="server" 
                            MaxLength="50" Text='<%# Bind("AccountCostCenter") %>' Width="176px"></asp:TextBox><asp:RequiredFieldValidator 
                            ID="RequiredFieldValidator2" runat="server" 
                            ControlToValidate="CostCenterTextBox" CssClass="ErrorMessage" ErrorMessage="*"></asp:RequiredFieldValidator></td></tr><tr>
                            <td align="right" class="FormViewLabelCell" style="width: 200px"><asp:Label ID="Label7" runat="server" 
                        AssociatedControlID="CostCenterCodeTextBox">
                  <asp:Literal ID="Literal10" runat="server" Text='<%# ResourceHelper.GetFromResource("Disabled:")%> ' /></asp:Label></td><td style="width: 300px"><asp:CheckBox ID="CheckBox1" runat="server" 
                            Checked='<%# Bind("IsDisabled") %>' />
                            </td>
                            </tr>
                            <tr>
                    <td style="width: 200px" align="right" class="FormViewLabelCell">
                    </td>
                    <td style="width: 300px; padding-bottom: 5px;">
                        <asp:Button ID="btnUpdate" runat="server" Text="<%$ Resources:TimeLive.Resource, Update_text%> " CommandName="Update" Width="68px" />&nbsp <asp:Button ID="btnCancel" runat="server" Text="<%$ Resources:TimeLive.Resource, Cancel_text%> " CommandName="Cancel" ValidationGroup="Cost" Width="68px" /></td>
                </tr>
            </table>
            </EditItemTemplate>
            <InsertItemTemplate>
                <table width="500" class="xFormView">
                    <tr>
                        <th colspan="2" class="caption">
                            <asp:Literal ID="Literal5" runat="server" Text='<%# ResourceHelper.GetFromResource("Cost Center Information")%> ' /></th>
                    </tr>
                    <tr>
                        <th colspan="2" class="FormViewSubHeader">
                            <asp:Literal ID="Literal6" runat="server" Text='<%# ResourceHelper.GetFromResource("Cost Center") %>' /></th>
                    </tr>
                    <tr>
                        <td align="right" class="FormViewLabelCell" style="width: 200px">
                            
<asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="txtSortOrder">
                            <asp:Literal ID="Literal9" runat="server" Text="<%$ Resources:TimeLive.Resource, Sort Order:%> " /></asp:Label></td><td style="width: 300px">
                            <asp:TextBox 
                                ID="txtSortOrder" runat="server" MaxLength="10" Text='<%# Bind("SortOrder") %>'
                                style="text-align:right;" Width="25px"></asp:TextBox></td></tr><tr><td 
                            align="right" class="FormViewLabelCell" style="width: 200px; padding-top: 5px;"><span class="reqasterisk">*</span><asp:Label 
                            ID="Label3" runat="server" AssociatedControlID="CostCenterCodeTextBox">
                  <asp:Literal ID="Literal7" runat="server" 
                            
                Text='<%# ResourceHelper.GetFromResource("Cost Center Code:")%> ' /></asp:Label></td><td 
                            style="width: 300px"><asp:TextBox ID="CostCenterCodeTextBox" runat="server" 
                                MaxLength="7" Text='<%# Bind("AccountCostCenterCode") %>' Width="176px"></asp:TextBox><asp:RequiredFieldValidator 
                                ID="RequiredFieldValidator1" runat="server" 
                                ControlToValidate="CostCenterCodeTextBox" CssClass="ErrorMessage" 
                                ErrorMessage="*"></asp:RequiredFieldValidator></td></tr><tr><td 
                            align="right" class="FormViewLabelCell" style="width: 200px"><span 
                            class="reqasterisk">*</span><asp:Label ID="Label5" runat="server" 
                            AssociatedControlID="CostCenterTextBox">
                  <asp:Literal ID="Literal8" runat="server" 
                                Text='<%# ResourceHelper.GetFromResource("Cost Center:")%> ' /></asp:Label></td><td 
                            style="width: 300px"><asp:TextBox ID="CostCenterTextBox" runat="server" 
                                MaxLength="50" Text='<%# Bind("AccountCostCenter") %>' Width="176px"></asp:TextBox><asp:RequiredFieldValidator 
                                ID="RequiredFieldValidator2" runat="server" 
                                ControlToValidate="CostCenterTextBox" CssClass="ErrorMessage" ErrorMessage="*"></asp:RequiredFieldValidator></td></tr><tr>
                        <td style="width: 200px" align="right" class="FormViewLabelCell">
                        </td>
                        <td style="width: 300px; padding-bottom: 5px;">
                            <asp:Button ID="btnAdd" runat="server" Text="<%$ Resources:TimeLive.Resource, Add_text%> " CommandName="Insert" Width="68px" /></td>
                    </tr>
                </table>
            </InsertItemTemplate>
            <ItemTemplate>
             </ItemTemplate>
        </asp:FormView>
    </ContentTemplate>
</asp:UpdatePanel>

