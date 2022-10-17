<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlAccountPartyList.ascx.vb" Inherits="AccountAdmin_Controls_ctlAccountPartyList" ClientIDMode="Static" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

        <script src="<%= Page.ResolveUrl("~/js/jquery.min.js") %>"></script>
        <script src="<%= Page.ResolveUrl("~/js/jquery.actual.min.js") %>"></script>
        <script src="<%= Page.ResolveUrl("~/js/libs/validation/jquery.validate.min.js") %>"></script>
		<script src="<%= Page.ResolveUrl("~/bootstrap/js/bootstrap.min.js") %>"></script>


    <script type="text/javascript">
        function ChangeCheckBoxState(id, checkState) {
            var cb = document.getElementById(id);
            if (cb != null)
                cb.checked = checkState;
        }

        function ChangeAllCheckBoxStates(checkState) {
            // Toggles through all of the checkboxes defined in the CheckBoxIDs array
            // and updates their value to the checkState input parameter
            if (CheckBoxIDs != null) {
                for (var i = 0; i < CheckBoxIDs.length; i++)
                    ChangeCheckBoxState(CheckBoxIDs[i], checkState);
            }
        }

        function ChangeHeaderAsNeeded() {
            // Whenever a checkbox in the GridView is toggled, we need to
            // check the Header checkbox if ALL of the GridView checkboxes are
            // checked, and uncheck it otherwise
            if (CheckBoxIDs != null) {
                // check to see if all other checkboxes are checked
                for (var i = 1; i < CheckBoxIDs.length; i++) {
                    var cb = document.getElementById(CheckBoxIDs[i]);
                    if (!cb.checked) {
                        // Whoops, there is an unchecked checkbox, make sure
                        // that the header checkbox is unchecked
                        ChangeCheckBoxState(CheckBoxIDs[0], false);
                        return;
                    }
                }

                // If we reach here, ALL GridView checkboxes are checked
                ChangeCheckBoxState(CheckBoxIDs[0], true);
            }
        }

    </script>


<x:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="AccountPartyId"
    DataSourceID="dsAccountPartyObject"  AllowSorting="True" SkinID="xgridviewSkinEmployee" Caption='<%# ResourceHelper.GetFromResource("Client List") %>' CssClass="TableView" Width="98%">
    <Columns>
        <asp:BoundField DataField="AccountPartyId" HeaderText="<%$ Resources:TimeLive.Resource, Id %>" InsertVisible="False"
            ReadOnly="True" SortExpression="AccountPartyId" >
            <ItemStyle  Width="5%" HorizontalAlign="Center" />
        </asp:BoundField>
        <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Client Name %>" 
                    SortExpression="PartyName">
            <edititemtemplate>
<asp:TextBox id="TextBox1" runat="server" Text='<%# Bind("PartyName") %>' __designer:wfdid="w3"></asp:TextBox> 
</edititemtemplate>
      <headertemplate>  
<asp:LinkButton id="LinkButton3" runat="server" __designer:wfdid="w3" Text='<%# ResourceHelper.GetFromResource("Client Name") %>' 
CommandArgument="PartyName" CommandName="Sort" CausesValidation="False"></asp:LinkButton>
</headertemplate>
<itemtemplate>
<asp:Label id="Label1" runat="server" Text='<%# Bind("PartyName") %>' __designer:wfdid="w2"></asp:Label> 
</itemtemplate>
            <itemstyle horizontalalign="Left" width="25%" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, EMail Address %>" 
                    SortExpression="EMailAddress">
            <headertemplate>
<asp:LinkButton id="LinkButton4" runat="server" __designer:wfdid="w3" Text='<%# ResourceHelper.GetFromResource("EMail Address") %>' CommandArgument="EMailAddress" CommandName="Sort" CausesValidation="False"></asp:LinkButton>
</headertemplate>
            <edititemtemplate>
<asp:TextBox id="TextBox2" runat="server" Text='<%# Bind("EMailAddress") %>' __designer:wfdid="w3"></asp:TextBox> 
</edititemtemplate>
           <itemtemplate>
<asp:Label id="Label2" runat="server" Text='<%# Bind("EMailAddress") %>' __designer:wfdid="w2"></asp:Label> 
</itemtemplate>
            <itemstyle horizontalalign="Left" width="25%" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Country %>" 
                    SortExpression="Country">
            <headertemplate>
<asp:LinkButton id="LinkButton5" runat="server" Text='<%# ResourceHelper.GetFromResource("Country") %>' CommandArgument="Country" CommandName="Sort" CausesValidation="False"></asp:LinkButton>
</headertemplate>
            <edititemtemplate>
<asp:TextBox id="TextBox3" runat="server" Text='<%# Bind("Country") %>' __designer:wfdid="w9"></asp:TextBox> 
</edititemtemplate>
           <itemtemplate>
<asp:Label id="Label3" runat="server" Text='<%# Bind("Country") %>' __designer:wfdid="w8"></asp:Label> 
</itemtemplate>
            <itemstyle width="17%" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Telephone1 %>" 
                    SortExpression="Telephone1">
             <headertemplate>
<asp:LinkButton id="LinkButton6" runat="server" Text='<%# ResourceHelper.GetFromResource("Telephone1") %>' CommandArgument="Telephone1" CommandName="Sort" CausesValidation="False"></asp:LinkButton>
</headertemplate>
            <edititemtemplate>
<asp:TextBox id="TextBox4" runat="server" Text='<%# Bind("Telephone1") %>' __designer:wfdid="w12"></asp:TextBox> 
</edititemtemplate>
           <itemtemplate>
<asp:Label id="Label4" runat="server" Text='<%# Bind("Telephone1") %>' __designer:wfdid="w11"></asp:Label> 
</itemtemplate>
            <itemstyle width="15%" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Edit_text %>" ShowHeader="False">
            <ItemTemplate>
                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Select"
                    Text="Edit" Visible='<%# not IsDBNull(Eval("AccountPartyId")) %>'></asp:LinkButton>
            
</ItemTemplate>
            <HeaderStyle HorizontalAlign="Center" />
            <ItemStyle HorizontalAlign="Center" cssclass="edit_button" Width="1%" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Delete_text %>" ShowHeader="False">
     <ItemTemplate>
 
       <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete" 
                    OnClientClick='<%# ResourceHelper.GetDeleteMessageJavascript()%>'
                    Text="Delete" Visible='<%# not  IsDBNull(Eval("AccountPartyId")) %>'/>
     
</ItemTemplate>
            <HeaderStyle HorizontalAlign="Center" />
            <ItemStyle HorizontalAlign="Center" cssclass="delete_button" Width="1%" />
        </asp:TemplateField>
        <asp:TemplateField>
            <ItemTemplate>
                <asp:HyperLink ID="HyperLink1" runat="server" 
                    NavigateUrl='<%# Eval("AccountPartyId", "~/AccountAdmin/AccountPartyContacts.aspx?AccountPartyId={0}") %>' 
                    Text="Contacts"></asp:HyperLink>
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Center" Width="4%" />
        </asp:TemplateField>
        <asp:TemplateField>
            <ItemTemplate>
                <asp:HyperLink ID="HyperLink2" runat="server" 
                    NavigateUrl='<%# Eval("AccountPartyId", "~/AccountAdmin/AccountPartyDepartments.aspx?AccountPartyId={0}") %>' 
                    Text="Departments"></asp:HyperLink>
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Center" Width="4%" />
        </asp:TemplateField>
        <asp:TemplateField>
            <HeaderTemplate>
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/Disabled.gif" ToolTip="<%$ Resources:TimeLive.Resource, Disabled_text%> " />
            </HeaderTemplate>
            <ItemTemplate>
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/Disabled.gif" Visible='<%# IIF(IsDBNull(Eval("IsDisabled")),"False",Eval("IsDisabled")) %>' ToolTip="<%$ Resources:TimeLive.Resource, Disabled_text%> " />
            </ItemTemplate>
            <itemstyle HorizontalAlign="Center" Width="1%" />
        </asp:TemplateField>
        <asp:TemplateField >
        <HeaderTemplate>
            <asp:CheckBox ID="chkCheckAll" runat="server" Width="15px"/>
        </HeaderTemplate>
        <ItemTemplate>
        <asp:CheckBox id="chkSelect" runat="server" Width="15px"></asp:CheckBox> 
        </ItemTemplate>
        <HeaderStyle  HorizontalAlign="Center" VerticalAlign="Middle" />
        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="1%" />
</asp:TemplateField>  
    </Columns>
</x:GridView>
        <table style="width: 98%">
            <tr>
                <td align="left">
                    <div style="margin:5px;">
                        <asp:Button ID="btnAdd" runat="server" Text="Add" UseSubmitBehavior="True" Width="75px" />
                        <asp:Button ID="btnDeleteSelectedItem" runat="server"  OnClick="btnDeleteSelectedItem_Click" Text="Delete Selected" Visible="False" Width="90px" />
                    </div>
                </td>
            </tr>
        </table>

<br />
<asp:ObjectDataSource ID="dsAccountPartyObject" runat="server" 
    DeleteMethod="DeleteAccountParty" OldValuesParameterFormatString="original_{0}"
    SelectMethod="GetvueAccountPartiesByAccountIdForGridView" 
    TypeName="AccountPartyBLL" InsertMethod="AddAccountParty" 
    UpdateMethod="UpdateAccountParty">
    <DeleteParameters>
        <asp:Parameter Name="original_AccountPartyId" Type="Int32" />
    </DeleteParameters>
    <InsertParameters>
        <asp:Parameter Name="AccountId" Type="Int32" />
        <asp:Parameter Name="PartyName" Type="String" />
        <asp:Parameter Name="PartyNick" Type="String" />
        <asp:Parameter Name="EMailAddress" Type="String" />
        <asp:Parameter Name="Address1" Type="String" />
        <asp:Parameter Name="Address2" Type="String" />
        <asp:Parameter Name="CountryId" Type="Int16" />
        <asp:Parameter Name="State" Type="String" />
        <asp:Parameter Name="City" Type="String" />
        <asp:Parameter Name="ZipCode" Type="String" />
        <asp:Parameter Name="Telephone1" Type="String" />
        <asp:Parameter Name="Telephone2" Type="String" />
        <asp:Parameter Name="Fax" Type="String" />
        <asp:Parameter Name="DefaultBillingRate" Type="Decimal" />
        <asp:Parameter Name="Website" Type="String" />
        <asp:Parameter Name="Notes" Type="String" />
        <asp:Parameter Name="IsDisabled" Type="Boolean" />
        <asp:Parameter Name="IsDeleted" Type="Boolean" />
        <asp:Parameter Name="CreatedOn" Type="DateTime" />
        <asp:Parameter Name="CreatedByEmployeeId" Type="Int32" />
        <asp:Parameter Name="ModifiedOn" Type="DateTime" />
        <asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" />
        <asp:Parameter Name="FixedBidBillingMode" Type="Int32" />
        <asp:Parameter Name="FixedCost" Type="Double" />
        <asp:Parameter Name="IsWebServiceCall" Type="Boolean" />
        <asp:Parameter Name="CustomField1" Type="String" />
        <asp:Parameter Name="CustomField2" Type="String" />
        <asp:Parameter Name="CustomField3" Type="String" />
        <asp:Parameter Name="CustomField4" Type="String" />
        <asp:Parameter Name="CustomField5" Type="String" />
        <asp:Parameter Name="CustomField6" Type="String" />
        <asp:Parameter Name="CustomField7" Type="String" />
        <asp:Parameter Name="CustomField8" Type="String" />
        <asp:Parameter Name="CustomField9" Type="String" />
        <asp:Parameter Name="CustomField10" Type="String" />
        <asp:Parameter Name="CustomField11" Type="String" />
        <asp:Parameter Name="CustomField12" Type="String" />
        <asp:Parameter Name="CustomField13" Type="String" />
        <asp:Parameter Name="CustomField14" Type="String" />
        <asp:Parameter Name="CustomField15" Type="String" />
    </InsertParameters>
    <SelectParameters>
        <asp:SessionParameter DefaultValue="23" Name="AccountId" SessionField="AccountId"
            Type="Int32" />
        <asp:QueryStringParameter DefaultValue="0" Name="AccountPartyId" QueryStringField="AccountPartyId"
            Type="Int32" />
    </SelectParameters>
    <UpdateParameters>
        <asp:Parameter Name="PartyTypeId" Type="Int16" />
        <asp:Parameter Name="AccountId" Type="Int32" />
        <asp:Parameter Name="PartyName" Type="String" />
        <asp:Parameter Name="PartyNick" Type="String" />
        <asp:Parameter Name="EMailAddress" Type="String" />
        <asp:Parameter Name="Address1" Type="String" />
        <asp:Parameter Name="Address2" Type="String" />
        <asp:Parameter Name="CountryId" Type="Int16" />
        <asp:Parameter Name="State" Type="String" />
        <asp:Parameter Name="City" Type="String" />
        <asp:Parameter Name="ZipCode" Type="String" />
        <asp:Parameter Name="Telephone1" Type="String" />
        <asp:Parameter Name="Telephone2" Type="String" />
        <asp:Parameter Name="Fax" Type="String" />
        <asp:Parameter Name="DefaultBillingRate" Type="Decimal" />
        <asp:Parameter Name="Website" Type="String" />
        <asp:Parameter Name="Notes" Type="String" />
        <asp:Parameter Name="IsDisabled" Type="Boolean" />
        <asp:Parameter Name="IsDeleted" Type="Boolean" />
        <asp:Parameter Name="CreatedOn" Type="DateTime" />
        <asp:Parameter Name="CreatedByEmployeeId" Type="Int32" />
        <asp:Parameter Name="ModifiedOn" Type="DateTime" />
        <asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" />
        <asp:Parameter Name="Original_AccountPartyId" Type="Int32" />
        <asp:Parameter Name="FixedBidBillingMode" Type="Int32" />
        <asp:Parameter Name="FixedCost" Type="Double" />
        <asp:Parameter Name="CustomField1" Type="String" />
        <asp:Parameter Name="CustomField2" Type="String" />
        <asp:Parameter Name="CustomField3" Type="String" />
        <asp:Parameter Name="CustomField4" Type="String" />
        <asp:Parameter Name="CustomField5" Type="String" />
        <asp:Parameter Name="CustomField6" Type="String" />
        <asp:Parameter Name="CustomField7" Type="String" />
        <asp:Parameter Name="CustomField8" Type="String" />
        <asp:Parameter Name="CustomField9" Type="String" />
        <asp:Parameter Name="CustomField10" Type="String" />
        <asp:Parameter Name="CustomField11" Type="String" />
        <asp:Parameter Name="CustomField12" Type="String" />
        <asp:Parameter Name="CustomField13" Type="String" />
        <asp:Parameter Name="CustomField14" Type="String" />
        <asp:Parameter Name="CustomField15" Type="String" />
    </UpdateParameters>
</asp:ObjectDataSource>

<asp:ObjectDataSource ID="dsAccountPartyForm" runat="server"
    InsertMethod="AddAccountParty" OldValuesParameterFormatString="original_{0}"
    SelectMethod="GetAccountPartiesByAccountPartyId" TypeName="AccountPartyBLL" 
            UpdateMethod="UpdateAccountParty" 
    DeleteMethod="DeleteAccountParty">
    <UpdateParameters>
        <asp:Parameter Name="PartyTypeId" Type="Int16" />
        <asp:SessionParameter DefaultValue="" Name="AccountId" SessionField="AccountId" 
            Type="Int32" />
        <asp:Parameter Name="PartyName" Type="String" />
        <asp:Parameter Name="PartyNick" Type="String" />
        <asp:Parameter Name="EMailAddress" Type="String" />
        <asp:Parameter Name="Address1" Type="String" />
        <asp:Parameter Name="Address2" Type="String" />
        <asp:Parameter Name="CountryId" Type="Int16" />
        <asp:Parameter Name="State" Type="String" />
        <asp:Parameter Name="City" Type="String" />
        <asp:Parameter Name="ZipCode" Type="String" />
        <asp:Parameter Name="Telephone1" Type="String" />
        <asp:Parameter Name="Telephone2" Type="String" />
        <asp:Parameter Name="Fax" Type="String" />
        <asp:Parameter Name="DefaultBillingRate" Type="Decimal" />
        <asp:Parameter Name="Website" Type="String" />
        <asp:Parameter Name="Notes" Type="String" />
        <asp:Parameter Name="IsDisabled" Type="Boolean" />
        <asp:Parameter Name="IsDeleted" Type="Boolean" />
        <asp:Parameter Name="CreatedOn" Type="DateTime" />
        <asp:Parameter Name="CreatedByEmployeeId" Type="Int32" />
        <asp:Parameter Name="ModifiedOn" Type="DateTime" />
        <asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" />
        <asp:Parameter Name="Original_AccountPartyId" Type="Int32" />
        <asp:Parameter Name="FixedBidBillingMode" Type="Int32" />
        <asp:Parameter Name="FixedCost" Type="Double" />
        <asp:Parameter Name="CustomField1" Type="String" />
        <asp:Parameter Name="CustomField2" Type="String" />
        <asp:Parameter Name="CustomField3" Type="String" />
        <asp:Parameter Name="CustomField4" Type="String" />
        <asp:Parameter Name="CustomField5" Type="String" />
        <asp:Parameter Name="CustomField6" Type="String" />
        <asp:Parameter Name="CustomField7" Type="String" />
        <asp:Parameter Name="CustomField8" Type="String" />
        <asp:Parameter Name="CustomField9" Type="String" />
        <asp:Parameter Name="CustomField10" Type="String" />
        <asp:Parameter Name="CustomField11" Type="String" />
        <asp:Parameter Name="CustomField12" Type="String" />
        <asp:Parameter Name="CustomField13" Type="String" />
        <asp:Parameter Name="CustomField14" Type="String" />
        <asp:Parameter Name="CustomField15" Type="String" />
    </UpdateParameters>
    <SelectParameters>
        <asp:ControlParameter ControlID="GridView1" Name="AccountPartyId" PropertyName="SelectedValue"
            Type="Int32" />
    </SelectParameters>
    <DeleteParameters>
        <asp:Parameter Name="original_AccountPartyId" Type="Int32" />
    </DeleteParameters>
    <InsertParameters>
        <asp:SessionParameter DefaultValue="23" Name="AccountId" SessionField="AccountId"
            Type="Int32" />
        <asp:Parameter Name="PartyName" Type="String" />
        <asp:Parameter Name="PartyNick" Type="String" />
        <asp:Parameter Name="EMailAddress" Type="String" />
        <asp:Parameter Name="Address1" Type="String" />
        <asp:Parameter Name="Address2" Type="String" />
        <asp:Parameter Name="CountryId" Type="Int16" />
        <asp:Parameter Name="State" Type="String" />
        <asp:Parameter Name="City" Type="String" />
        <asp:Parameter Name="ZipCode" Type="String" />
        <asp:Parameter Name="Telephone1" Type="String" />
        <asp:Parameter Name="Telephone2" Type="String" />
        <asp:Parameter Name="Fax" Type="String" />
        <asp:Parameter Name="DefaultBillingRate" Type="Decimal" />
        <asp:Parameter Name="Website" Type="String" />
        <asp:Parameter Name="Notes" Type="String" />
        <asp:Parameter Name="IsDisabled" Type="Boolean" />
        <asp:Parameter Name="IsDeleted" Type="Boolean" />
        <asp:Parameter Name="CreatedOn" Type="DateTime" />
        <asp:Parameter Name="CreatedByEmployeeId" Type="Int32" />
        <asp:Parameter Name="ModifiedOn" Type="DateTime" />
        <asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" />
        <asp:Parameter Name="FixedBidBillingMode" Type="Int32" />
        <asp:Parameter Name="FixedCost" Type="Double" />
        <asp:Parameter Name="IsWebServiceCall" Type="Boolean" />
        <asp:Parameter Name="CustomField1" Type="String" />
        <asp:Parameter Name="CustomField2" Type="String" />
        <asp:Parameter Name="CustomField3" Type="String" />
        <asp:Parameter Name="CustomField4" Type="String" />
        <asp:Parameter Name="CustomField5" Type="String" />
        <asp:Parameter Name="CustomField6" Type="String" />
        <asp:Parameter Name="CustomField7" Type="String" />
        <asp:Parameter Name="CustomField8" Type="String" />
        <asp:Parameter Name="CustomField9" Type="String" />
        <asp:Parameter Name="CustomField10" Type="String" />
        <asp:Parameter Name="CustomField11" Type="String" />
        <asp:Parameter Name="CustomField12" Type="String" />
        <asp:Parameter Name="CustomField13" Type="String" />
        <asp:Parameter Name="CustomField14" Type="String" />
        <asp:Parameter Name="CustomField15" Type="String" />
    </InsertParameters>
</asp:ObjectDataSource>
<asp:FormView ID="FormView1" runat="server" DataKeyNames="AccountPartyId" DataSourceID="dsAccountPartyForm"
    DefaultMode="Insert" Width="40%" SkinID="formviewSkinEmployee" OnItemInserting="FormView1_ItemInserting" OnItemUpdated="FormView1_ItemUpdated">
    <EditItemTemplate><table style="width: 100%" class="xview">
        <tr>
            <th class="caption" colspan="2" style="height: 21px; width: 40%;" width="40%">
                <asp:Literal ID="Literal1" runat="server" Text='<%# ResourceHelper.GetFromResource("Clients Information") %>' /></th>
        </tr>
        <tr>
            <th class="FormViewSubHeader" colspan="2" style="width: 40%; height: 21px" width="40%">
                <asp:Literal ID="Literal2" runat="server" Text='<%# ResourceHelper.GetFromResource("Clients") %>' /></th>
        </tr>
        <tr>
            <td class="FormViewLabelCell" style="height: 26px; width: 30%;" width="40%" align="right">
                                    <SPAN 
                  class=reqasterisk>*</SPAN>
<asp:Label ID="UserNameLabel" runat="server" 

AssociatedControlID="PartyNameTextBox"> <asp:Literal ID="Literal3" runat="server" Text='<%# ResourceHelper.GetFromResource("Client Name:") %>' /></asp:Label></td><td style="height: 26px; width: 70%;">
                <asp:TextBox 
                    ID="PartyNameTextBox" runat="server" Text='<%# Bind("PartyName") %>' 
                    Width="225px" MaxLength="200"></asp:TextBox><asp:RequiredFieldValidator
                    ID="RequiredFieldValidator1" runat="server" ControlToValidate="PartyNameTextBox"
                    Display="Dynamic" ErrorMessage="*" Width="1px"></asp:RequiredFieldValidator></td></tr><tr>
            <td class="FormViewLabelCell" style="height: 26px; width: 30%;" width="40%" align="right">
                                    <asp:Label ID="Label5" runat="server" AssociatedControlID="PartyNickTextBox">
                  <asp:Literal ID="Literal4" runat="server" Text='<%# ResourceHelper.GetFromResource("Client Nick:") %>' /></asp:Label></td><td style="height: 26px; width: 70%;">
                <asp:TextBox 
                    ID="PartyNickTextBox" runat="server" Text='<%# Bind("PartyNick") %>' 
                    MaxLength="50" Width="225px"></asp:TextBox></td></tr><tr>
            <td class="FormViewLabelCell" style="height: 26px; width: 30%;" width="40%" align="right">
                                    
                                    
<asp:Label ID="Label8" runat="server" AssociatedControlID="EMailAddressTextBox">
                                    <asp:Literal ID="Literal5" runat="server" Text='<%# ResourceHelper.GetFromResource("Email Address:") %>' /></asp:Label></td><td style="height: 26px; width: 70%;">
                <asp:TextBox 
                    ID="EMailAddressTextBox" runat="server" Text='<%# Bind("EMailAddress") %>' 
                    Width="225px" MaxLength="50"></asp:TextBox><asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="EMailAddressTextBox"
                    CssClass="ErrorMessage" Display="Dynamic" ErrorMessage="Incorrect EMail Address"
                    Font-Bold="False" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator></td></tr><tr>
            <td class="FormViewLabelCell" style="height: 26px; width: 30%;" width="40%" align="right">
                <asp:Label ID="Label10" runat="server" AssociatedControlID="Address1TextBox">
                <asp:Literal ID="Literal6" runat="server" Text='<%# ResourceHelper.GetFromResource("Address1:") %>' /></asp:Label></td><td style="height: 26px; width: 70%;">
                <asp:TextBox ID="Address1TextBox" runat="server" Text='<%# Bind("Address1") %>' Width="225px" MaxLength="250"></asp:TextBox></td></tr><tr>
            <td class="FormViewLabelCell" style="height: 26px; width: 30%;" width="40%" align="right">
                
<asp:Label ID="Label11" runat="server" AssociatedControlID="Address2TextBox">
                <asp:Literal ID="Literal7" runat="server" Text='<%# ResourceHelper.GetFromResource("Address2:") %>' /></asp:Label></td><td style="height: 26px; width: 70%;">
                <asp:TextBox ID="Address2TextBox" runat="server" Text='<%# Bind("Address2") %>' Width="225px" MaxLength="250"></asp:TextBox></td></tr><tr>
            <td class="FormViewLabelCell" style="height: 26px; width: 30%;" width="40%" align="right">
                <asp:Literal ID="Literal8" runat="server" Text='<%# ResourceHelper.GetFromResource("Country:") %>' /></td>
            <td style="height: 26px; width: 70%;">
                <asp:DropDownList ID="ddlCountryId" 
                    runat="server" DataSourceID="dsCountryObject"
                        DataTextField="Country" DataValueField="CountryId" 
                    SelectedValue='<%# Bind("CountryId") %>' Width="172px"></asp:DropDownList></td>
        </tr>
        <tr>
            <td class="FormViewLabelCell" style="height: 26px; width: 30%;" width="40%" align="right">
                <asp:Literal ID="Literal9" runat="server" Text='<%# ResourceHelper.GetFromResource("State:") %>' /></td>
            <td style="height: 26px; width: 70%;">
                <asp:TextBox ID="StateTextBox" runat="server" 
                    Text='<%# Bind("State") %>' MaxLength="20" Width="160px"></asp:TextBox></td></tr><tr>
            <td class="FormViewLabelCell" style="height: 26px; width: 30%;" width="40%" align="right">
                
<asp:Label ID="Label14" runat="server" AssociatedControlID="CityTextBox">
                <asp:Literal ID="Literal10" runat="server" Text='<%# ResourceHelper.GetFromResource("City:") %>' /></asp:Label></td><td style="height: 26px; width: 70%;">
                <asp:TextBox 
                    ID="CityTextBox" runat="server" Text='<%# Bind("City") %>' MaxLength="50" 
                    Width="160px"></asp:TextBox></td></tr><tr>
            <td class="FormViewLabelCell" style="height: 26px; width: 30%;" width="40%" align="right">
                <asp:Literal ID="Literal11" runat="server" Text='<%# ResourceHelper.GetFromResource("ZipCode") %>' /></td>
            <td style="height: 26px; width: 70%;">
                <asp:TextBox ID="ZipCodeTextBox" 
                    runat="server" Text='<%# Bind("ZipCode") %>' Width="160px" MaxLength="50"></asp:TextBox></td></tr><tr>
            <td class="FormViewLabelCell" style="height: 26px; width: 30%;" width="40%" align="right">
                
<asp:Label ID="Label16" runat="server" AssociatedControlID="Telephone1TextBox">
                <asp:Literal ID="Literal12" runat="server" Text='<%# ResourceHelper.GetFromResource("Telephone1:") %>' /></asp:Label></td><td style="height: 26px; width: 70%;">
                <asp:TextBox 
                    ID="Telephone1TextBox" runat="server" Text='<%# Bind("Telephone1") %>' 
                    Width="160px" MaxLength="50"></asp:TextBox></td></tr><tr>
            <td class="FormViewLabelCell" style="height: 26px; width: 30%;" width="40%" align="right">
                
<asp:Label ID="Label17" runat="server" AssociatedControlID="Telephone2TextBox">
                <asp:Literal ID="Literal13" runat="server" Text='<%# ResourceHelper.GetFromResource("Telephone2:") %>' /></asp:Label></td><td style="height: 26px; width: 70%;">
                <asp:TextBox 
                    ID="Telephone2TextBox" runat="server" Text='<%# Bind("Telephone2") %>' 
                    Width="160px" MaxLength="50"></asp:TextBox></td></tr><tr>
            <td class="FormViewLabelCell" style="height: 26px; width: 30%;" width="40%" align="right">
                
<asp:Label ID="Label21" runat="server" AssociatedControlID="FaxTextBox">
                <asp:Literal ID="Literal14" runat="server" Text='<%# ResourceHelper.GetFromResource("Fax:") %>' /></asp:Label></td><td>
                <asp:TextBox 
                    ID="FaxTextBox" runat="server" Text='<%# Bind("Fax") %>' Width="160px" 
                    MaxLength="50"></asp:TextBox></td></tr><tr>
            <td class="FormViewLabelCell" style="height: 26px; width: 30%;" width="40%" align="right">
               
<asp:Label ID="Label22" runat="server" AssociatedControlID="DefaultBillingRateTextBox">
                <asp:Literal ID="Literal16" runat="server" Text='<%# ResourceHelper.GetFromResource("Default Billing Rate:") %>' /></asp:Label></td><td style="height: 26px; width: 70%;">
                <asp:TextBox 
                    ID="DefaultBillingRateTextBox" runat="server" 
                    Text='<%# Bind("DefaultBillingRate") %>' Width="160px"></asp:TextBox><br /><asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="DefaultBillingRateTextBox"
                    Display="Dynamic" ErrorMessage="Numeric Required" Font-Bold="False" Type="Double" MaximumValue="999999999" MinimumValue="0" CssClass="ErrorMessage"></asp:RangeValidator></td></tr><tr>
            <td class="FormViewLabelCell" style="height: 26px; width: 30%;" width="40%" align="right">
                
<asp:Label ID="Label24" runat="server" AssociatedControlID="WebsiteTextBox">
                <asp:Literal ID="Literal17" runat="server" Text='<%# ResourceHelper.GetFromResource("Website:") %>' /></asp:Label></td><td style="height: 26px; width: 70%;">
                <asp:TextBox 
                    ID="WebsiteTextBox" runat="server" Text='<%# Bind("Website") %>' Width="160px" 
                    MaxLength="100"></asp:TextBox></td></tr><tr><td align="right" 
                class="FormViewLabelCell" style="height: 26px; width: 30%;" valign="top" 
                width="40%"><asp:Label ID="Label26" runat="server" 
                AssociatedControlID="NotesTextBox">
                <asp:Literal ID="Literal18" runat="server" 
                Text='<%# ResourceHelper.GetFromResource("Notes:") %>' /></asp:Label></td><td 
                style="height: 26px; width: 70%;"><asp:TextBox ID="NotesTextBox" runat="server" 
                    Height="50px" MaxLength="500" Rows="4" Text='<%# Bind("Notes") %>' 
                    TextMode="MultiLine" Width="225px"></asp:TextBox></td></tr>
<%--<% If 1 = 2 Then%><tr><td class="FormViewLabelCell" 
                style="height: 26px; width: 30%;" width="40%" align="right" valign="top">Fixed Bid Billing Mode:</td><td 
                style="width: 70%; height: 26px"><asp:DropDownList ID="ddlFixedBidBillingMode" 
                    runat="server" Width="172px" 
                    SelectedValue='<%# Bind("FixedBidBillingMode") %>'><asp:ListItem Value="0">None</asp:ListItem><asp:ListItem 
                        Value="1">Fixed Bid Client</asp:ListItem><asp:ListItem Value="2">Fixed Bid Project</asp:ListItem><asp:ListItem 
                        Value="3">Fixed Bid Task</asp:ListItem></asp:DropDownList></td></tr><tr><td align="right" class="FormViewLabelCell" style="height: 26px; width: 30%;" 
                valign="top" width="40%">Fixed Bid Cost:</td><td 
                style="height: 26px; width: 70%;"><span><asp:TextBox ID="txtFixedBidCost" 
                    runat="server" style="text-align:right;" Width="55px" 
                    Text='<%# Bind("FixedCost") %>'></asp:TextBox></span></td></tr>
<%End If%>--%>
<tr>
            <td class="FormViewLabelCell" style="height: 26px; width: 30%;" width="40%" align="right">
                <asp:Literal ID="Literal19" runat="server" Text='<%# ResourceHelper.GetFromResource("Disabled:") %>' /></td>
            <td style="width: 70%; height: 26px">
                <asp:CheckBox ID="CheckBox1" runat="server" Checked='<%# Bind("IsDisabled") %>' ValidationGroup="edit" /></td>
        </tr>
        <tr><td class="FormViewSubHeader" colspan="2"><asp:Table ID="CustomTableEdit" 
                    runat="server" Height="100%" Width="100%"></asp:Table></td></tr><tr><td 
                align="right" class="FormViewLabelCell" style="height: 26px; width: 30%;" 
                valign="baseline" width="40%"></td><td 
                style="height: 26px; width: 70%; padding-bottom: 5px;"><asp:Button ID="Update" 
                    runat="server" CommandName="Update" OnClick="Update_Click" 
                    Text="<%$ Resources:TimeLive.Resource, Update_text%>" Width="68px" />&nbsp;<asp:Button 
                    ID="Cancel" runat="server" CommandName="Cancel" OnClick="Cancel_Click" 
                    Text="<%$ Resources:TimeLive.Resource, Cancel_text%>" Width="68px" /></td></tr></table>
    </EditItemTemplate>
    <InsertItemTemplate>
        <table width="100%" style="width: 100%" class="xview">
            <tr>
                <th class="caption" colspan="2" style="height: 21px; width: 40%;" width="40%">
                    <asp:Literal ID="Literal1" runat="server" Text='<%# ResourceHelper.GetFromResource("Add Client") %>' /></th>
            </tr>
            <tr>
                <th class="FormViewSubHeader" colspan="2" style="width: 40%; height: 21px" width="40%">
                    <asp:Literal ID="Literal20" runat="server" Text='<%# ResourceHelper.GetFromResource("Clients") %>' /></th>
            </tr>
            <tr>
                <td class="FormViewLabelCell" style="height: 26px; width: 30%;" width="40%" align="right">
                    <SPAN class=reqasterisk>*</SPAN><asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="PartyNameTextBox"><asp:Literal ID="Literal21" runat="server" Text='<%# ResourceHelper.GetFromResource("Client Name:") %>' /></asp:Label></td><td style="height: 26px; width: 70%;">
                    <asp:TextBox ID="PartyNameTextBox" runat="server" Text='<%# Bind("PartyName") %>' Width="225px" MaxLength="200"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="PartyNameTextBox" Display="Dynamic" ErrorMessage="*" Width="1px" CssClass="ErrorMessage"></asp:RequiredFieldValidator></td></tr><tr>
                <td colspan="2">
                <asp:Table ID="CustomTable" runat="server" style="margin-left: 0px" Width="100%"></asp:Table></td>
            <tr>
                <td align="right" class="FormViewLabelCell" style="height: 26px; width: 30%;" valign="baseline" width="40%"></td><td style="padding-bottom: 5px; padding-top: 5px; height: 26px; width: 70%;" >
                    <asp:Button ID="Add" runat="server" CommandName="Insert" OnClick="Add_Click" Text="<%$ Resources:TimeLive.Resource, Add_text%>" Width="68px" />&nbsp; <asp:Button ID="btnCancel" runat="server" CommandName="Cancel" OnClick="btnCancel_Click" Text="<%$ Resources:TimeLive.Resource, Cancel_text%>" ValidationGroup="Add" Width="68px" /></td></tr></table>
    </InsertItemTemplate>
</asp:FormView>
<asp:ObjectDataSource ID="dsCurrencyObject" runat="server" OldValuesParameterFormatString="original_{0}"
    SelectMethod="GetCurrencies" TypeName="SystemDataBLL"></asp:ObjectDataSource>
<asp:ObjectDataSource ID="dsCountryObject" runat="server" OldValuesParameterFormatString="original_{0}"
    SelectMethod="GetCountries" TypeName="SystemDataBLL"></asp:ObjectDataSource>

<cc1:modalpopupextender id="ModalPopupExtender2" runat="server" 
	cancelcontrolid="btnCancel" 
	targetcontrolid="btnAdd" popupcontrolid="Panel2" 
	popupdraghandlecontrolid="PopupHeader" drag="true" 
	backgroundcssclass="ModalPopupBG">
</cc1:modalpopupextender>

<asp:panel id="Panel2" style="display: none" runat="server">
	<div class="modal" style="height: 240px;" >

                
    <div class="modal-bar">
        <h>Create New Client</h></div><div class="modal-bg" style="width: 400px;height: 190px;">
        <div class="modal-content" style="min-width: 200px; min-height: 16px; position: relative; max-width: 1352px; max-height: 415px;height: 185px;margin-top: -15px;margin-left: -10px;margin-right: -10px;overflow-y:auto">

<div class="standard-tabs margin-bottom" id="add-tabs" style="height: 46px; font-weight: bold; font-size: 11px;" >
						<ul class="tabs">
							<li class="active"><a href="#tab-1">Basic</a></li><li id="Tab2li" runat="server"><a href="#tab-2">Custom Fields</a></li></ul><div class="tabs-content" style="min-height: 29px;border-right: 0px;border-left: 0px;border-bottom: 0px;" >

							<div id="tab-1" class="with-padding" style="margin-top: 5px;">

<div class="row-fluid">
        <div class="span6" style="display:inline-block;width: 25%;">
            <span style="color: #666666;text-align:right;font-size:11px;font-weight: bold;">Client Name:</span> </div><div id="partyname" class="span6" style="display:inline-block;">
            <asp:TextBox ID="PartyNameTextBox" runat="server" Width="250px" MaxLength="200"></asp:TextBox></div></div><div id="partynamediv" style="text-align: center;">
    
</div>
</div>
<div id="tab-2" class="with-padding">
<asp:FormView ID="FormView2" runat="server" DataKeyNames="AccountPartyId" DataSourceID="dsAccountPartyForm"
    DefaultMode="Insert" Width="100%" >
    <InsertItemTemplate>
        <table class="xFormView" style="width: 100%;border: 0;">
        <tr><td>
                <asp:Table ID="CustomTable" runat="server" class="xFormView"  Width="100%"></asp:Table></td>
        </tr>
        </table> 
    </InsertItemTemplate>
</asp:FormView>
    </div>
</div>
</div>


    <div class="custom-vscrollbar" style="display: none; opacity: 0;"><div></div></div></div>
             
        </div>
    <div style="background-color:#f5f5f6; border-top:solid 1px #dddddd;margin-top: -40px;margin-left: -12px;padding-top: 2px;margin-right: -11px;height:36px;width:434px;/* top: -22px; *//* padding-bottom: 20px; */" >     
						<asp:Button ID="btnOkay" runat="server" Text="Add Client" OnClick="btnOkay_Click"  style="width:68px;margin-left: 3px;margin-top: 3px;"/>
                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" Width="68px" />
    </div>
           </div>
           <div class="modal-resize-nw"></div><div class="modal-resize-n"></div>
    <div class="modal-resize-ne"></div><div class="modal-resize-e"></div><div class="modal-resize-se"></div>
    <div class="modal-resize-s"></div><div class="modal-resize-sw"></div><div class="modal-resize-w"></div></div>
</asp:panel>


    <script type="text/javascript">
        $(document).ready(function () {
            $('#<%=btnOkay.ClientID %>').click(function (event) {
                if ($('#PartyNameTextBox').val() == "") {
                    if (!$("#partyname").hasClass("f_error")) {
                        $("#partyname").addClass("f_error");
                        $("#partynamediv").append("<label id='partynameerror' class='error' style='width: 81%;padding-top: 4px;'>This field is required.</label>");
                        $("#partynamediv").addClass("f_error");

                    }
                    $('#PartyNameTextBox').focus();
                    event.preventDefault();
                }
            });
        });
</script>
