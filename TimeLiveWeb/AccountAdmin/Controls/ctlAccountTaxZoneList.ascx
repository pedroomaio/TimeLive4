<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlAccountTaxZoneList.ascx.vb" Inherits="AccountAdmin_Controls_ctlAccountTaxZoneList" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <x:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="AccountTaxZoneId"
            DataSourceID="dsAccountTaxZoneGridViewObject" Width="98%" Caption='<%# ResourceHelper.GetFromResource("Tax Zone List") %>' SkinID="xgridviewSkinEmployee">
            <Columns>
                <asp:TemplateField SortExpression="AccountTaxZoneId" HeaderText="<%$ Resources:TimeLive.Resource, Id %>">
                    <edititemtemplate>
<asp:Label id="Label1" runat="server" Text='<%# Eval("AccountTaxZoneId") %>' __designer:wfdid="w236"></asp:Label>
</edititemtemplate>
                    <headertemplate>
<asp:LinkButton id="LinkButton3" runat="server" Text='<%# ResourceHelper.GetFromResource("Id") %>' CommandArgument="AccountTaxZoneId" CommandName="Sort" CausesValidation="False"></asp:LinkButton>
</headertemplate>
                    <itemtemplate>
<asp:Label id="Label1" runat="server" Text='<%# Bind("AccountTaxZoneId") %>' __designer:wfdid="w235"></asp:Label>
</itemtemplate>
                    <itemstyle width="5%" HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField SortExpression="AccountTaxZone" HeaderText="<%$ Resources:TimeLive.Resource, Tax Zone %>">
                    <edititemtemplate>
<asp:TextBox id="TextBox1" runat="server" Text='<%# Bind("AccountTaxZone") %>' __designer:wfdid="w239"></asp:TextBox>
</edititemtemplate>
                    <headertemplate>
<asp:LinkButton id="LinkButton4" runat="server" Text='<%# ResourceHelper.GetFromResource("Tax Zone") %>' CommandArgument="AccountTaxZone" CommandName="Sort" CausesValidation="False"></asp:LinkButton>
</headertemplate>
                    <itemtemplate>
<asp:Label id="Label2" runat="server" Text='<%# Bind("AccountTaxZone") %>' __designer:wfdid="w238"></asp:Label>
</itemtemplate>
                    <itemstyle width="90%" />
                </asp:TemplateField>
        <asp:CommandField HeaderText="<%$ Resources:TimeLive.Resource, Edit_Text %>" SelectText="Edit" ShowSelectButton="True" >
            <ItemStyle HorizontalAlign="Center"  cssclass="edit_button" Width="1%" />
          
        </asp:CommandField>
        <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Delete_Text %>" ShowHeader="False">
     <ItemTemplate>
<asp:LinkButton id="LinkButton1" runat="server" __designer:wfdid="w13" OnClientClick="<%# ResourceHelper.GetDeleteMessageJavascript()%>" CommandName="Delete" CausesValidation="False"></asp:LinkButton> 
</ItemTemplate>
            <ItemStyle HorizontalAlign="Center"  cssclass="delete_button" Width="1%" />
        </asp:TemplateField>
        <asp:TemplateField>
            <HeaderTemplate>
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/Disabled.gif" ToolTip="<%$ Resources:TimeLive.Resource, Disabled_text%> "  />
            
</HeaderTemplate>
            <ItemTemplate>
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/Disabled.gif" Visible='<%# IIF(IsDBNull(Eval("IsDisabled")),"false",Eval("IsDisabled")) %>' ToolTip="<%$ Resources:TimeLive.Resource, Disabled_text%> " />
            
</ItemTemplate>
                      <ItemStyle HorizontalAlign="Center"  Width="1%" />
        </asp:TemplateField>
            </Columns>
        </x:GridView>
        <asp:ObjectDataSource ID="dsAccountTaxZoneGridViewObject" runat="server" DeleteMethod="DeleteAccountTaxZone"
            InsertMethod="AddAccountTaxZone" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetAccountTaxZonesByAccountId" TypeName="AccountTaxZoneBLL" UpdateMethod="UpdateAccountTaxZone">
            <DeleteParameters>
                <asp:Parameter Name="Original_AccountTaxZoneId" Type="Int32" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="AccountId" Type="Int32" />
                <asp:Parameter Name="AccountTaxZone" Type="String" />
                <asp:Parameter Name="CreatedOn" Type="DateTime" />
                <asp:Parameter Name="CreatedByEmployeeId" Type="Int32" />
                <asp:Parameter Name="ModifiedOn" Type="DateTime" />
                <asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" />
                <asp:Parameter Name="IsDisabled" Type="Boolean" />
                <asp:Parameter Name="Original_AccountTaxZoneId" Type="Int32" />
            </UpdateParameters>
            <SelectParameters>
                <asp:SessionParameter DefaultValue="99" Name="AccountId" SessionField="AccountId"
                    Type="Int32" />
            </SelectParameters>
            <InsertParameters>
                <asp:Parameter Name="AccountId" Type="Int32" />
                <asp:Parameter Name="AccountTaxZone" Type="String" />
                <asp:Parameter Name="CreatedOn" Type="DateTime" />
                <asp:Parameter Name="CreatedByEmployeeId" Type="Int32" />
                <asp:Parameter Name="ModifiedOn" Type="DateTime" />
                <asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" />
            </InsertParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="dsAccountTaxZoneFormViewObject" runat="server" DeleteMethod="DeleteAccountTaxZone"
            InsertMethod="AddAccountTaxZone" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetAccountTaxZonesByAccountTaxZoneId" TypeName="AccountTaxZoneBLL"
            UpdateMethod="UpdateAccountTaxZone">
            <DeleteParameters>
                <asp:Parameter Name="Original_AccountTaxZoneId" Type="Int32" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:SessionParameter DefaultValue="2" Name="AccountId" SessionField="AccountId"
                    Type="Int32" />
                <asp:Parameter Name="AccountTaxZone" Type="String" />
                <asp:Parameter Name="CreatedOn" Type="DateTime" />
                <asp:Parameter Name="CreatedByEmployeeId" Type="Int32" />
                <asp:Parameter Name="ModifiedOn" Type="DateTime" />
                <asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" />
                <asp:Parameter Name="IsDisabled" Type="Boolean" />
                <asp:Parameter Name="Original_AccountTaxZoneId" Type="Int32" />
            </UpdateParameters>
            <SelectParameters>
                <asp:ControlParameter ControlID="GridView1" Name="AccountTaxZoneId" PropertyName="SelectedValue"
                    Type="Int32" />
            </SelectParameters>
            <InsertParameters>
                <asp:SessionParameter DefaultValue="99" Name="AccountId" SessionField="AccountId"
                    Type="Int32" />
                <asp:Parameter Name="AccountTaxZone" Type="String" />
                <asp:Parameter Name="CreatedOn" Type="DateTime" />
                <asp:Parameter Name="CreatedByEmployeeId" Type="Int32" />
                <asp:Parameter Name="ModifiedOn" Type="DateTime" />
                <asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" />
            </InsertParameters>
        </asp:ObjectDataSource>
    </ContentTemplate>
</asp:UpdatePanel>
<br />
<asp:UpdatePanel ID="UpdatePanel2" runat="server">
    <ContentTemplate>
        <asp:FormView ID="FormView1" runat="server" DataKeyNames="AccountTaxZoneId" DataSourceID="dsAccountTaxZoneFormViewObject"
            DefaultMode="Insert"  SkinID="formviewSkinEmployee" Width="400px">
            <EditItemTemplate>
                <table width="400" class="xFormView">
                    <tr>
                        <th class="caption" colspan="2">
                        <asp:Literal ID="Literal5" runat="server" Text='<%# ResourceHelper.GetFromResource("Tax Zone Information")%> ' />
                    </th>
                    <tr>
                        <th class="FormViewSubHeader" colspan="2">
                        <asp:Literal ID="Literal1" runat="server" Text='<%# ResourceHelper.GetFromResource("Tax Zone")%> ' />
                    </th>
                    <tr>
                        <td align="right" class="FormViewLabelCell" style="width: 150px">
                            <SPAN 
                  class=reqasterisk>*</SPAN> 
                  
<asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="TaxZoneTextBox">
                  <asp:Literal ID="Literal2" runat="server" Text='<%# ResourceHelper.GetFromResource("Tax Zone:")%> ' /></asp:Label></td><td style="width: 250px">
                            <asp:TextBox 
                                ID="TaxZoneTextBox" runat="server" Text='<%# Bind("AccountTaxZone") %>' 
                                Width="176px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TaxZoneTextBox"
                                CssClass="ErrorMessage" Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator></td></tr><tr>
                        <td align="right" class="FormViewLabelCell" style="width: 150px">
                            <asp:Literal ID="Literal7" runat="server" Text='<%# ResourceHelper.GetFromResource("Is Disabled")%> ' /></td>
                        </td>
                        <td style="width: 250px">
                            <asp:CheckBox ID="IsDisabledCheckBox" runat="server" Checked='<%# Bind("IsDisabled") %>' /></td>
                    </tr>
                    <tr>
                        <td align="right" class="FormViewLabelCell" style="width: 150px">
                        </td>
                        <td style="width: 250px; padding-bottom: 5px;">
                            <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="<%$ Resources:TimeLive.Resource, Update_text%> " Width="68px" />&nbsp<asp:Button
                                ID="CancelButton" runat="server" CommandName="Cancel" Text="<%$ Resources:TimeLive.Resource, Cancel_text%> " Width="68px" /><asp:Label
                                    ID="lblExceptionText" runat="server" ForeColor="Red" Text="Label" Visible="False" CssClass="ErrorMessage"></asp:Label></td></tr></table></EditItemTemplate><InsertItemTemplate>
                <table class="xFormView" width="400">
                    <tr>
                        <th class="caption" colspan="2">
                            <asp:Literal ID="Literal3" runat="server" Text='<%# ResourceHelper.GetFromResource("Tax Zone Information")%> ' />
                    </th>
                    <tr>
                        <th class="FormViewSubHeader" colspan="2">
                            <asp:Literal ID="Literal4" runat="server" Text='<%# ResourceHelper.GetFromResource("Tax Zone")%> ' />
                    </th>
                    <tr>
                        <td align="right" class="FormViewLabelCell" style="width: 150px">
                             <SPAN 
                  class=reqasterisk>*</SPAN><asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="TaxZoneTextBox">
                  <asp:Literal ID="Literal6" runat="server" Text='<%# ResourceHelper.GetFromResource("Tax Zone:")%> ' /></asp:Label></td><td style="width: 250px">
                            <asp:TextBox 
                                        ID="TaxZoneTextBox" runat="server" Text='<%# Bind("AccountTaxZone") %>' 
                                        Width="176px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TaxZoneTextBox"
                                CssClass="ErrorMessage" Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator></td></tr><tr>
                        <td align="right" class="FormViewLabelCell" style="width: 150px">
                        </td>
                        <td style="width: 250px; padding-bottom: 5px;">
                            <asp:Button ID="ADDButton" runat="server" CommandName="Insert" Text="<%$ Resources:TimeLive.Resource, Add_text%> " Width="68px" /><asp:Label
                                ID="lblExceptionText" runat="server" ForeColor="Red" Text="Label" Visible="False" CssClass="ErrorMessage"></asp:Label></td></tr></table></InsertItemTemplate><ItemTemplate>
                AccountTaxZoneId: <asp:Label ID="AccountTaxZoneIdLabel" runat="server" Text='<%# Eval("AccountTaxZoneId") %>'>
                </asp:Label><br />AccountId: <asp:Label ID="AccountIdLabel" runat="server" Text='<%# Bind("AccountId") %>'></asp:Label><br />AccountTaxZone: <asp:Label ID="AccountTaxZoneLabel" runat="server" Text='<%# Bind("AccountTaxZone") %>'>
                </asp:Label><br />CreatedOn: <asp:Label ID="CreatedOnLabel" runat="server" Text='<%# Bind("CreatedOn") %>'></asp:Label><br />CreatedByEmployeeId: <asp:Label ID="CreatedByEmployeeIdLabel" runat="server" Text='<%# Bind("CreatedByEmployeeId") %>'>
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
                </asp:LinkButton></ItemTemplate></asp:FormView>&nbsp;</ContentTemplate></asp:UpdatePanel>&nbsp; 