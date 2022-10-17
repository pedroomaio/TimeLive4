<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlAccountBillingTypeList.ascx.vb" Inherits="AccountAdmin_Controls_ctlAccountBillingTypes" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
<x:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="AccountBillingTypeId"
    DataSourceID="dsAccountBillingTypeObject" SkinID="xgridviewSkinEmployee" AllowSorting="True" Caption='<%# ResourceHelper.GetFromResource("Billing Type List") %>' Width="98%">
    <Columns>
        <asp:BoundField DataField="AccountBillingTypeId" HeaderText="<%$ Resources:TimeLive.Resource, Id %>" InsertVisible="False"
            ReadOnly="True" SortExpression="AccountBillingTypeId" >
            <ItemStyle HorizontalAlign="Center" Width="5%" />
        </asp:BoundField>
        <asp:TemplateField SortExpression="BillingType" HeaderText="<%$ Resources:TimeLive.Resource, Billing Type %>">
            <edititemtemplate>
<asp:TextBox id="TextBox1" runat="server" Text='<%# Bind("BillingType") %>' __designer:wfdid="w121"></asp:TextBox> 
</edititemtemplate>
            <headertemplate>
<asp:LinkButton id="LinkButton3" runat="server" Text='<%# ResourceHelper.GetFromResource("Billing Type") %>' CommandArgument="BillingType" CommandName="Sort" CausesValidation="False"></asp:LinkButton>
</headertemplate>
            <itemtemplate>
<asp:Label id="Label56" runat="server" Text='<%# Bind("BillingType") %>' __designer:wfdid="w120"></asp:Label> 
</itemtemplate>
            <ItemStyle Width="45%" />
        </asp:TemplateField>
        <asp:TemplateField SortExpression="SystemBillingCategory" HeaderText="<%$ Resources:TimeLive.Resource, Billing Category %>">
            <edititemtemplate>
<asp:TextBox id="TextBox2" runat="server" Text='<%# Bind("SystemBillingCategory") %>' __designer:wfdid="w127"></asp:TextBox> 
</edititemtemplate>
            <headertemplate>
<asp:LinkButton id="LinkButton4" runat="server" Text='<%# ResourceHelper.GetFromResource("Billing Category") %>' CommandArgument="SystemBillingCategory" CommandName="Sort" CausesValidation="False"></asp:LinkButton>
</headertemplate>
            <itemtemplate>
<asp:Label id="Label57" runat="server" Text='<%#GetGlobalResourceObject("TimeLive.Web", Eval("SystemBillingCategory"))%>' __designer:wfdid="w126"></asp:Label> 
</itemtemplate>
            <ItemStyle Width="45%" />
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
<asp:ObjectDataSource ID="dsAccountBillingTypeObject" runat="server" DeleteMethod="DeleteAccountBillingType"
    InsertMethod="AddAccountBillingType" OldValuesParameterFormatString="original_{0}"
    SelectMethod="GetAccountBillingTypesForSelection" TypeName="AccountBillingTypeBLL"
    UpdateMethod="UpdateAccountBillingType">
    <DeleteParameters>
        <asp:Parameter Name="Original_AccountBillingTypeId" Type="Int32" />
    </DeleteParameters>
    <UpdateParameters>
        <asp:Parameter Name="AccountId" Type="Int32" />
        <asp:Parameter Name="BillingType" Type="String" />
        <asp:Parameter Name="BillingCategoryId" Type="Int32" />
        <asp:Parameter Name="original_AccountBillingTypeId" Type="Int32" />
        <asp:Parameter Name="CreatedOn" Type="DateTime" />
        <asp:Parameter Name="CreatedByEmployeeId" Type="Int32" />
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
        <asp:Parameter Name="BillingType" Type="String" />
        <asp:Parameter Name="BillingCategoryId" Type="Int32" />
        <asp:Parameter Name="CreatedOn" Type="DateTime" />
        <asp:Parameter Name="CreatedByEmployeeId" Type="Int32" />
        <asp:Parameter Name="ModifiedOn" Type="DateTime" />
        <asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" />
    </InsertParameters>
</asp:ObjectDataSource>
<asp:ObjectDataSource ID="dsAccountBillingTypeFormObject" runat="server" DeleteMethod="DeleteAccountBillingType"
    InsertMethod="AddAccountBillingType" OldValuesParameterFormatString="original_{0}"
    SelectMethod="GetAccountBillingTypesByAccountBillingTypeId" TypeName="AccountBillingTypeBLL"
    UpdateMethod="UpdateAccountBillingType">
    <DeleteParameters>
        <asp:Parameter Name="Original_AccountBillingTypeId" Type="Int32" />
    </DeleteParameters>
    <UpdateParameters>
        <asp:SessionParameter DefaultValue="23" Name="AccountId" SessionField="AccountId"
            Type="Int32" />
        <asp:Parameter Name="BillingType" Type="String" />
        <asp:Parameter Name="BillingCategoryId" Type="Int32" />
        <asp:Parameter Name="Original_AccountBillingTypeId" Type="Int32" />
        <asp:Parameter Name="CreatedOn" Type="DateTime" />
        <asp:Parameter Name="CreatedByEmployeeId" Type="Int32" />
        <asp:Parameter Name="ModifiedOn" Type="DateTime" />
        <asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" />
        <asp:Parameter Name="IsDisabled" Type="Boolean" />
    </UpdateParameters>
    <SelectParameters>
        <asp:ControlParameter ControlID="GridView1" Name="AccountBillingTypeId" PropertyName="SelectedValue"
            Type="Int32" />
    </SelectParameters>
    <InsertParameters>
        <asp:SessionParameter DefaultValue="23" Name="AccountId" SessionField="AccountId"
            Type="Int32" />
        <asp:Parameter Name="BillingType" Type="String" />
        <asp:Parameter Name="BillingCategoryId" Type="Int32" />
        <asp:Parameter Name="CreatedOn" Type="DateTime" />
        <asp:Parameter Name="CreatedByEmployeeId" Type="Int32" />
        <asp:Parameter Name="ModifiedOn" Type="DateTime" />
        <asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" />
    </InsertParameters>
</asp:ObjectDataSource>
    </ContentTemplate>
</asp:UpdatePanel>
&nbsp;<br />
<asp:UpdatePanel ID="UpdatePanel2" runat="server">
    <ContentTemplate>
<asp:FormView ID="FormView1" runat="server" DataKeyNames="AccountBillingTypeId" DataSourceID="dsAccountBillingTypeFormObject"
    DefaultMode="Insert" SkinID="formviewSkinEmployee" Width="550px" 
            OnDataBound="FormView1_DataBound">
    <EditItemTemplate>
        <table style="width: 100%" >
            <tr>
                <th class="caption" colspan="2" style="height: 21px">
                    <asp:Literal ID="Literal1" runat="server" Text='<%# ResourceHelper.GetFromResource("Billing Type Information")%> ' /></th>
            </tr>
            <tr>
                <th class="FormViewSubHeader" colspan="2" style="height: 21px">
                    <asp:Literal ID="Literal2" runat="server" Text='<%# ResourceHelper.GetFromResource("Billing Type")%> ' /></th>
            </tr>
            <tr>
                <td style="width: 30%; height: 26px;" class="FormViewLabelCell" align="right">
                                        <SPAN 
                  class=reqasterisk>*</SPAN> 
                  
<asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="BillingTypeTextBox">
                  <asp:Literal ID="Literal5" runat="server" Text='<%# ResourceHelper.GetFromResource("Billing Type:")%> ' /></asp:Label></td><td style="width: 60%; height: 26px;">
        <asp:TextBox 
                        ID="BillingTypeTextBox" runat="server" Text='<%# Bind("BillingType") %>' 
                        Width="176px" MaxLength="50"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
            ControlToValidate="BillingTypeTextBox" Display="Dynamic" ErrorMessage="*" Width="16px"></asp:RequiredFieldValidator></td></tr><tr>
                <td align="right" class="FormViewLabelCell" style="width: 30%; height: 26px">
                                                            <SPAN 
                  class=reqasterisk>*</SPAN><asp:Literal ID="Literal6" runat="server" Text='<%# ResourceHelper.GetFromResource("Billing Category:")%> ' /></td>
                <td style="width: 60%; height: 26px">
                    <asp:DropDownList ID="DropDownList1" 
                        runat="server" DataSourceID="dsBillingCategoryObject"
                        DataTextField="SystemBillingCategory" DataValueField="SystemBillingCategoryId"
                        SelectedValue='<%# Bind("BillingCategoryId") %>' Width="188px"></asp:DropDownList></td>
            </tr>
            <tr>
                <td align="right" class="FormViewLabelCell" style="width: 30%; height: 26px">
                    <asp:Literal ID="Literal3" runat="server" Text='<%# ResourceHelper.GetFromResource("Disabled:")%> ' /></td>
                <td style="width: 60%; height: 26px">
                    <asp:CheckBox ID="CheckBox1" runat="server" Checked='<%# Bind("IsDisabled") %>' /></td>
            </tr>
            <tr>
                <td style="width: 30%; height: 26px" align="right">
                </td>
                <td style="width: 60%; padding-bottom: 5px;">
                    <asp:Button ID="Button3" runat="server" CommandName="Update" Text="<%$ Resources:TimeLive.Resource, Update_text%> " Width="68px"  />&nbsp<asp:Button ID="Button4" runat="server" CommandName="Cancel" Text="<%$ Resources:TimeLive.Resource, Cancel_text%> " Width="68px" /></td>
            </tr>
        </table><asp:ObjectDataSource ID="dsBillingCategoryObject" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetBillingCategories" TypeName="SystemDataBLL"></asp:ObjectDataSource>
    </EditItemTemplate>
    <InsertItemTemplate>
        <table style="width: 100%" >
            <tr>
                <th class="caption" colspan="2" width="25%" style="height: 21px">
                    <asp:Literal ID="Literal1" runat="server" Text='<%# ResourceHelper.GetFromResource("Billing Type Information")%> ' /></th>
            </tr>
            <tr>
                <th class="FormViewSubHeader" colspan="2" style="height: 21px" width="25%">
                    <asp:Literal ID="Literal4" runat="server" Text='<%# ResourceHelper.GetFromResource("Billing Type")%> ' /></th>
            </tr>
            <tr>
                <td class="FormViewLabelCell" style="width: 30%; height: 26px;" align="right">
                                        <SPAN 
                  class=reqasterisk>*</SPAN><asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="BillingTypeTextBox">
                  <asp:Literal ID="Literal7" runat="server" Text='<%# ResourceHelper.GetFromResource("Billing Type:")%> ' /></asp:Label></td><td width="60%">
                    <asp:TextBox 
                        ID="BillingTypeTextBox" runat="server" Text='<%# Bind("BillingType") %>' 
                        Width="176px" MaxLength="50"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="BillingTypeTextBox"
                        ErrorMessage="*" Width="1px" Display="Dynamic"></asp:RequiredFieldValidator></td></tr><tr>
                <td align="right" class="FormViewLabelCell" style="width: 30%; height: 26px">
                                        <SPAN 
                  class=reqasterisk>*</SPAN><asp:Literal ID="Literal8" runat="server" Text='<%# ResourceHelper.GetFromResource("Billing Category:")%> ' /></td>
                <td width="60%">
                    <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="dsBillingCategoryObject"
                        DataTextField="SystemBillingCategory" DataValueField="SystemBillingCategoryId"
                        SelectedValue='<%# Bind("BillingCategoryId") %>' Width="188px"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="height: 26px; width: 30%;" align="right">
                </td>
                <td style="height: 26px; padding-bottom: 5px;" width="60%">
                    <asp:Button ID="btnAdd" runat="server" CommandName="Insert"
                        Text="<%$ Resources:TimeLive.Resource, Add_text%> " Width="68px" />
                    </td>
            </tr>
        </table>
        <asp:ObjectDataSource ID="dsBillingCategoryObject" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetBillingCategories" TypeName="SystemDataBLL"></asp:ObjectDataSource>
    </InsertItemTemplate>
    <ItemTemplate>
        AccountBillingTypeId: <asp:Label ID="AccountBillingTypeIdLabel" runat="server" Text='<%# Eval("AccountBillingTypeId") %>'>
        </asp:Label><br />AccountId: <asp:Label ID="AccountIdLabel" runat="server" Text='<%# Bind("AccountId") %>'></asp:Label><br />BillingType: <asp:Label ID="BillingTypeLabel" runat="server" Text='<%# Bind("BillingType") %>'>
        </asp:Label><br /><asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" CommandName="Edit"
            Text="Edit">
        </asp:LinkButton><asp:LinkButton ID="DeleteButton" runat="server" CausesValidation="False" CommandName="Delete"
            Text="Delete">
        </asp:LinkButton><asp:LinkButton ID="NewButton" runat="server" CausesValidation="False" CommandName="New"
            Text="New">
        </asp:LinkButton></ItemTemplate></asp:FormView></ContentTemplate></asp:UpdatePanel><br />

