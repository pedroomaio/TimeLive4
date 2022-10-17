<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlAccountPartyContactList.ascx.vb" Inherits="AccountAdmin_Controls_ctlAccountPartyContactList" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <x:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="AccountPartyContactId"
            DataSourceID="dsAccountPartyContactGridViewObject" Caption= '<%# ResourceHelper.GetFromResource("Client Contact List") %>' SkinID="xgridviewSkinEmployee" OnRowCommand="GridView1_RowCommand" Width="98%">
            <Columns>
                <asp:BoundField DataField="AccountPartyContactId" HeaderText="<%$ Resources:TimeLive.Resource, Id %>"
                    InsertVisible="False" ReadOnly="True" SortExpression="AccountPartyContactId" >
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="6%" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, First Name %>" SortExpression="FirstName">
                    <edititemtemplate>
<asp:TextBox id="TextBox1" runat="server" Text='<%# Bind("FirstName") %>' __designer:wfdid="w16"></asp:TextBox>
</edititemtemplate>
                    <headertemplate>
<asp:LinkButton id="LinkButton1" runat="server" Text='<%# ResourceHelper.GetFromResource("First Name") %>' CommandArgument="FirstName" CommandName="Sort" CausesValidation="False"></asp:LinkButton>
</headertemplate>
                    <itemtemplate>
<asp:Label id="Label1" runat="server" Text='<%# Bind("FirstName") %>' __designer:wfdid="w15"></asp:Label>
</itemtemplate>
                    <itemstyle width="21.5%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Last Name %>" SortExpression="LastName">
                    <edititemtemplate>
<asp:TextBox id="TextBox2" runat="server" Text='<%# Bind("LastName") %>' __designer:wfdid="w19"></asp:TextBox>
</edititemtemplate>
                    <headertemplate>
<asp:LinkButton id="LinkButton2" runat="server" Text='<%# ResourceHelper.GetFromResource("Last Name") %>' CommandArgument="LastName" CommandName="Sort" CausesValidation="False"></asp:LinkButton>
</headertemplate>
                    <itemtemplate>
<asp:Label id="Label2" runat="server" Text='<%# Bind("LastName") %>' __designer:wfdid="w18"></asp:Label>
</itemtemplate>
                    <itemstyle width="21.5%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, EMail Address %>" SortExpression="EMailAddress">
                    <edititemtemplate>
<asp:TextBox id="TextBox3" runat="server" Text='<%# Bind("EMailAddress") %>' __designer:wfdid="w22"></asp:TextBox>
</edititemtemplate>
                    <headertemplate>
<asp:LinkButton id="LinkButton4" runat="server" Text='<%# ResourceHelper.GetFromResource("EMail Address") %>' CommandArgument="EMailAddress" CommandName="Sort" CausesValidation="False"></asp:LinkButton>
</headertemplate>
                    <itemtemplate>
<asp:Label id="Label3" runat="server" Text='<%# Bind("EMailAddress") %>' __designer:wfdid="w21"></asp:Label>
</itemtemplate>
                    <itemstyle width="21.5%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Location %>" SortExpression="Location">
                    <edititemtemplate>
<asp:TextBox id="TextBox4" runat="server" Text='<%# Bind("Location") %>' __designer:wfdid="w25"></asp:TextBox>
</edititemtemplate>
                    <headertemplate>
<asp:LinkButton id="LinkButton5" runat="server" Text='<%# ResourceHelper.GetFromResource("Location") %>' CommandArgument="Location" CommandName="Sort" CausesValidation="False"></asp:LinkButton>
</headertemplate>
                    <itemtemplate>
<asp:Label id="Label4" runat="server" Text='<%# Bind("Location") %>' __designer:wfdid="w24"></asp:Label>
</itemtemplate>
                    <itemstyle width="21.5%" />
                </asp:TemplateField>
                <asp:CommandField HeaderText="<%$ Resources:TimeLive.Resource, Edit_text %>" SelectText="Edit" ShowSelectButton="True" >
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="1%" cssclass="edit_button" />
                </asp:CommandField>
                <asp:CommandField HeaderText="<%$ Resources:TimeLive.Resource, Delete_text %>" ShowDeleteButton="True" >
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="1%" cssclass="delete_button"  />
                </asp:CommandField>
            </Columns>
        </x:GridView>
        <table style="width: 98%">
            <tr>
                <td align="left">
                    <div style="margin:5px;">
                        <asp:Button ID="btnAdd" runat="server" Text="Add" 
                            UseSubmitBehavior="False" Width="75px" />
                    </div>
                </td>
            </tr>
        </table>
        <asp:ObjectDataSource ID="dsAccountPartyContactGridViewObject" runat="server" DeleteMethod="DeleteAccountPartyContact"
            InsertMethod="AddAccountPartyContact" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetvueAccountPartyContactsByAccountPartyId" TypeName="AccountPartyContactBLL" UpdateMethod="UpdateAccountPartyContact">
            <DeleteParameters>
                <asp:Parameter Name="Original_AccountPartyContactId" Type="Int32" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="AccountPartyId" Type="Int32" />
                <asp:Parameter Name="FirstName" Type="String" />
                <asp:Parameter Name="LastName" Type="String" />
                <asp:Parameter Name="Telephone1" Type="String" />
                <asp:Parameter Name="Telephone2" Type="String" />
                <asp:Parameter Name="Fax" Type="String" />
                <asp:Parameter Name="EMailAddress" Type="String" />
                <asp:Parameter Name="State" Type="String" />
                <asp:Parameter Name="City" Type="String" />
                <asp:Parameter Name="Zip" Type="String" />
                <asp:Parameter Name="Address1" Type="String" />
                <asp:Parameter Name="Address2" Type="String" />
                <asp:Parameter Name="CountryId" Type="Int16" />
                <asp:Parameter Name="AccountPartyDepartmentId" Type="Int32" />
                <asp:Parameter Name="Location" Type="String" />
                <asp:Parameter Name="Original_AccountPartyContactId" Type="Int32" />
            </UpdateParameters>
            <InsertParameters>
                <asp:Parameter Name="AccountPartyId" Type="Int32" />
                <asp:Parameter Name="FirstName" Type="String" />
                <asp:Parameter Name="LastName" Type="String" />
                <asp:Parameter Name="Telephone1" Type="String" />
                <asp:Parameter Name="Telephone2" Type="String" />
                <asp:Parameter Name="Fax" Type="String" />
                <asp:Parameter Name="EMailAddress" Type="String" />
                <asp:Parameter Name="State" Type="String" />
                <asp:Parameter Name="City" Type="String" />
                <asp:Parameter Name="Zip" Type="String" />
                <asp:Parameter Name="Address1" Type="String" />
                <asp:Parameter Name="Address2" Type="String" />
                <asp:Parameter Name="CountryId" Type="Int16" />
                <asp:Parameter Name="AccountPartyDepartmentId" Type="Int32" />
                <asp:Parameter Name="Location" Type="String" />
            </InsertParameters>
            <SelectParameters>
                <asp:QueryStringParameter Name="AccountPartyId" QueryStringField="AccountPartyId"
                    Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="dsAccountPartyContactFormViewobject" runat="server" DeleteMethod="DeleteAccountPartyContact"
            InsertMethod="AddAccountPartyContact" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetDataByAccountPartyContactId" TypeName="AccountPartyContactBLL"
            UpdateMethod="UpdateAccountPartyContact">
            <DeleteParameters>
                <asp:Parameter Name="Original_AccountPartyContactId" Type="Int32" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:QueryStringParameter Name="AccountPartyId" QueryStringField="AccountPartyId"
                    Type="Int32" />
                <asp:Parameter Name="FirstName" Type="String" />
                <asp:Parameter Name="LastName" Type="String" />
                <asp:Parameter Name="Telephone1" Type="String" />
                <asp:Parameter Name="Telephone2" Type="String" />
                <asp:Parameter Name="Fax" Type="String" />
                <asp:Parameter Name="EMailAddress" Type="String" />
                <asp:Parameter Name="State" Type="String" />
                <asp:Parameter Name="City" Type="String" />
                <asp:Parameter Name="Zip" Type="String" />
                <asp:Parameter Name="Address1" Type="String" />
                <asp:Parameter Name="Address2" Type="String" />
                <asp:Parameter Name="CountryId" Type="Int16" />
                <asp:Parameter Name="AccountPartyDepartmentId" Type="Int32" />
                <asp:Parameter Name="Location" Type="String" />
                <asp:Parameter Name="Original_AccountPartyContactId" Type="Int32" />
            </UpdateParameters>
            <SelectParameters>
                <asp:ControlParameter ControlID="GridView1" Name="AccountPartyContactId" PropertyName="SelectedValue"
                    Type="Int32" />
            </SelectParameters>
            <InsertParameters>
                <asp:QueryStringParameter Name="AccountPartyId" QueryStringField="AccountPartyId"
                    Type="Int32" />
                <asp:Parameter Name="FirstName" Type="String" />
                <asp:Parameter Name="LastName" Type="String" />
                <asp:Parameter Name="Telephone1" Type="String" />
                <asp:Parameter Name="Telephone2" Type="String" />
                <asp:Parameter Name="Fax" Type="String" />
                <asp:Parameter Name="EMailAddress" Type="String" />
                <asp:Parameter Name="State" Type="String" />
                <asp:Parameter Name="City" Type="String" />
                <asp:Parameter Name="Zip" Type="String" />
                <asp:Parameter Name="Address1" Type="String" />
                <asp:Parameter Name="Address2" Type="String" />
                <asp:Parameter Name="CountryId" Type="Int16" />
                <asp:Parameter Name="AccountPartyDepartmentId" Type="Int32" />
                <asp:Parameter Name="Location" Type="String" />
            </InsertParameters>
        </asp:ObjectDataSource>
    </ContentTemplate>
</asp:UpdatePanel>
&nbsp;<br />
<asp:UpdatePanel ID="UpdatePanel2" runat="server">
    <ContentTemplate>
        <asp:FormView ID="FormView1" runat="server" DataKeyNames="AccountPartyContactId"
            DataSourceID="dsAccountPartyContactFormViewobject" DefaultMode="Insert" 
            SkinID="formviewSkinEmployee" Width="700px">
            <EditItemTemplate>
                <table style="width: 100%" width="100%" >
                    <tr>
                        <th class="caption" colspan="2" style="width: 40%; height: 21px" width="40%">
                            <asp:Literal ID="Literal1" runat="server" Text='<%# ResourceHelper.GetFromResource("Client Contact Information") %>' /></th>
                    </tr>
                    <tr>
                        <th class="FormViewSubHeader" colspan="2" style="width: 40%; height: 21px" width="40%">
                            <asp:Literal ID="Literal2" runat="server" Text='<%# ResourceHelper.GetFromResource("Client Contact") %>' /></th>
                    </tr>
                    <tr>
                        <td align="right" class="FormViewLabelCell" style="width: 30%; height: 26px" width="40%">
                            <span class="reqasterisk">*</span> 
<asp:Label ID="Label5" runat="server" AssociatedControlID="FirstNameTextBox">
                            <asp:Literal ID="Literal3" runat="server" Text='<%# ResourceHelper.GetFromResource("First Name:") %>' /></asp:Label></td><td style="width: 99%; height: 26px">
                            <asp:TextBox 
                                ID="FirstNameTextBox" runat="server" MaxLength="50" Text='<%# Bind("FirstName") %>'
                                Width="160px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="FirstNameTextBox"
                                CssClass="ErrorMessage" Display="Dynamic" ErrorMessage="*" Width="1px"></asp:RequiredFieldValidator></td></tr><tr>
                        <td align="right" class="FormViewLabelCell" style="width: 30%; height: 26px" width="40%">
                            <span class="reqasterisk">*</span> <asp:Label ID="Label8" runat="server" AssociatedControlID="LastNameTextBox">
                            <asp:Literal ID="Literal4" runat="server" Text='<%# ResourceHelper.GetFromResource("Last Name:") %>' /></asp:Label></td><td style="width: 99%; height: 26px">
                            <asp:TextBox 
                                ID="LastNameTextBox" runat="server" MaxLength="50" 
                                Text='<%# Bind("LastName") %>' Width="160px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="LastNameTextBox"
                                CssClass="ErrorMessage" Display="Dynamic" ErrorMessage="*" Width="1px"></asp:RequiredFieldValidator></td></tr><tr>
                        <td align="right" class="FormViewLabelCell" style="width: 30%; height: 26px" width="40%">
                            
<asp:Label ID="Label10" runat="server" AssociatedControlID="EMailAddressTextBox">
                            <asp:Literal ID="Literal5" runat="server" Text='<%# ResourceHelper.GetFromResource("Email Address:") %>' /></asp:Label></td><td style="width: 99%; height: 26px">
                            <asp:TextBox 
                                ID="EMailAddressTextBox" runat="server" MaxLength="50" Text='<%# Bind("EMailAddress") %>'
                                Width="225px"></asp:TextBox><asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="EMailAddressTextBox"
                                CssClass="ErrorMessage" Display="Dynamic" ErrorMessage="Incorrect EMail Address"
                                Font-Bold="False" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator></td></tr><tr >
                        <td align="right" class="FormViewLabelCell" style="width: 30%; height: 26px" width="40%">
                            
<asp:Label ID="Label12" runat="server" AssociatedControlID="Address1TextBox">
                            <asp:Literal ID="Literal6" runat="server" Text='<%# ResourceHelper.GetFromResource("Address1:") %>' /></asp:Label></td><td style="width: 99%; height: 26px">
                            <asp:TextBox 
                                ID="Address1TextBox" runat="server" MaxLength="150" Text='<%# Bind("Address1") %>'
                                Width="225px"></asp:TextBox></td></tr><tr><trlivetecs live="" 
                            support=""><td align="right" class="FormViewLabelCell" 
                            style="width: 30%; height: 26px" width="40%"><asp:Label ID="Label14" 
                                runat="server" AssociatedControlID="Address2TextBox"> <asp:Literal 
                                ID="Literal7" runat="server" 
                                Text='<%# ResourceHelper.GetFromResource("Address2:") %>' /></asp:Label></td></td><td 
                            style="width: 99%; height: 26px"><asp:TextBox ID="Address2TextBox" 
                                runat="server" MaxLength="150" Text='<%# Bind("Address2") %>' Width="225px"></asp:TextBox></td></trlivetecs></tr><tr><trlivetecs 
                            live="" support=""><td align="right" class="FormViewLabelCell" 
                            style="width: 30%; height: 26px" width="40%"><asp:Literal ID="Literal8" 
                                runat="server" Text='<%# ResourceHelper.GetFromResource("Country:") %>' /></td><td 
                            style="width: 99%; height: 26px"><asp:DropDownList ID="ddlCountryId" 
                                runat="server" DataSourceID="dsCountryObject" DataTextField="Country" 
                                DataValueField="CountryId" SelectedValue='<%# Bind("CountryId") %>' 
                                Width="165px"></asp:DropDownList></td></trlivetecs></tr><tr><trlivetecs 
                            live="" support=""><td align="right" class="FormViewLabelCell" 
                            style="width: 30%; height: 26px" width="40%"><asp:Label ID="Label15" 
                                runat="server" AssociatedControlID="StateTextBox"> <asp:Literal 
                                ID="Literal9" runat="server" 
                                Text='<%# ResourceHelper.GetFromResource("State:") %>' /></asp:Label></td><td 
                            style="width: 99%; height: 26px"><asp:TextBox ID="StateTextBox" runat="server" 
                                MaxLength="20" Text='<%# Bind("State") %>' Width="160px"></asp:TextBox></td></trlivetecs></tr><tr><trlivetecs 
                            live="" support=""><td align="right" class="FormViewLabelCell" 
                            style="width: 30%; height: 26px" width="40%"><asp:Label ID="Label18" 
                                runat="server" AssociatedControlID="CityTextBox"> <asp:Literal 
                                ID="Literal10" runat="server" 
                                Text='<%# ResourceHelper.GetFromResource("City:") %>' /></asp:Label></td></td><td 
                            style="width: 99%; height: 26px"><asp:TextBox ID="CityTextBox" runat="server" 
                                MaxLength="50" Text='<%# Bind("City") %>' Width="160px"></asp:TextBox></td></trlivetecs></tr><tr><trlivetecs 
                            live="" support=""><td align="right" class="FormViewLabelCell" 
                            style="width: 30%; height: 26px" width="40%"><asp:Label ID="Label19" 
                                runat="server" AssociatedControlID="ZipCodeTextBox"> <asp:Literal 
                                ID="Literal11" runat="server" 
                                Text='<%# ResourceHelper.GetFromResource("ZipCode:") %>' /></asp:Label></td></td><td 
                            style="width: 99%; height: 26px"><asp:TextBox ID="ZipCodeTextBox" 
                                runat="server" MaxLength="10" Text='<%# Bind("Zip") %>' Width="160px"></asp:TextBox></td></trlivetecs></tr><tr><trlivetecs 
                            live="" support=""><td align="right" class="FormViewLabelCell" 
                            style="width: 30%; height: 26px" width="40%"><asp:Label ID="Label22" 
                                runat="server" AssociatedControlID="Telephone1TextBox"> <asp:Literal 
                                ID="Literal12" runat="server" 
                                Text='<%# ResourceHelper.GetFromResource("Telephone1:") %>' /></asp:Label></td></td><td 
                            style="width: 99%; height: 26px"><asp:TextBox ID="Telephone1TextBox" 
                                runat="server" MaxLength="25" Text='<%# Bind("Telephone1") %>' Width="160px"></asp:TextBox></td></trlivetecs></tr><tr><trlivetecs 
                            live="" support=""><td align="right" class="FormViewLabelCell" 
                            style="width: 30%; height: 26px" width="40%"><asp:Label ID="Label24" 
                                runat="server" AssociatedControlID="Telephone2TextBox"> <asp:Literal 
                                ID="Literal13" runat="server" 
                                Text='<%# ResourceHelper.GetFromResource("Telephone2:") %>' /></asp:Label></td></td><td 
                            style="width: 99%; height: 26px"><asp:TextBox ID="Telephone2TextBox" 
                                runat="server" MaxLength="25" Text='<%# Bind("Telephone2") %>' Width="160px"></asp:TextBox></td></trlivetecs></tr><tr><trlivetecs 
                            live="" support=""><td align="right" class="FormViewLabelCell" 
                            style="width: 30%; height: 26px" width="40%"><asp:Label ID="Label25" 
                                runat="server" AssociatedControlID="FaxTextBox"> <asp:Literal 
                                ID="Literal14" runat="server" 
                                Text='<%# ResourceHelper.GetFromResource("Fax:") %>' />:</asp:Label></td></td><td 
                            style="width: 99%; height: 26px"><asp:TextBox ID="FaxTextBox" runat="server" 
                                MaxLength="25" Text='<%# Bind("Fax") %>' Width="160px"></asp:TextBox></td></trlivetecs></tr><tr><trlivetecs 
                            live="" support=""><td align="right" class="FormViewLabelCell" 
                            style="width: 30%; height: 26px" width="40%"><asp:Literal ID="Literal15" 
                                runat="server" 
                                Text='<%# ResourceHelper.GetFromResource("Client Department:") %>' /></td><td 
                            style="width: 99%; height: 26px"><asp:DropDownList 
                                ID="ddlAccountPartyDepartmentId" runat="server" AppendDataBoundItems="True" 
                                DataSourceID="dsAccountPartDepartmentObject" 
                                DataTextField="PartyDepartmentCode" DataValueField="AccountPartyDepartmentId" 
                                SelectedValue='<%# Bind("AccountPartyDepartmentId") %>' Width="165px"><asp:ListItem 
                                    ID="Label7" runat="server" Label="" 
                                    Text="<%$ Resources:TimeLive.Resource, Select%> " Value="0"></asp:ListItem><%--<asp:ListItem Value="0">&lt;Select&gt;</asp:ListItem>--%></asp:DropDownList></td></trlivetecs></tr><tr><trlivetecs 
                            live="" support=""><td align="right" class="FormViewLabelCell" 
                            style="width: 30%; height: 26px" valign="top" width="40%"><asp:Label 
                                ID="Label27" runat="server" AssociatedControlID="LocationTextBox"> <asp:Literal 
                                ID="Literal16" runat="server" 
                                Text='<%# ResourceHelper.GetFromResource("Location:") %>' /></asp:Label></td><td 
                            style="width: 99%; height: 26px"><asp:TextBox ID="LocationTextBox" 
                                runat="server" MaxLength="50" Rows="4" Text='<%# Bind("Location") %>' 
                                Width="160px"></asp:TextBox></td></trlivetecs></tr><tr><trlivetecs 
                            live="" support=""><td align="right" class="FormViewLabelCell" 
                            style="width: 30%; height: 26px" valign="baseline" width="40%"></td><td 
                            style="width: 99%; height: 26px; padding-bottom: 5px;"><asp:Button 
                                ID="btnUpdate" runat="server" CommandName="Update" 
                                Text="<%$ Resources:TimeLive.Resource, Update_text%> " Width="50px" />
                                <asp:Button 
                                ID="btnCancel" runat="server" CommandName="Cancel" 
                                Text="<%$ Resources:TimeLive.Resource, Cancel_text%> " Width="50px" /></td></trlivetecs></tr></table>
            </EditItemTemplate>
            <InsertItemTemplate>
                <table style="width: 100%" width="100%">
                    <tr>
                        <th class="caption" colspan="2" style="width: 40%; height: 21px" width="40%">
                            <asp:Literal ID="Literal1" runat="server" Text='<%# ResourceHelper.GetFromResource("Client Contact Information") %>' /></th>
                    </tr>
                    <tr>
                        <th class="FormViewSubHeader" colspan="2" style="width: 40%; height: 21px" width="40%">
                            <asp:Literal ID="Literal17" runat="server" Text='<%# ResourceHelper.GetFromResource("Client Contact") %>' /></th>
                    </tr>
                    <tr>
                        <td align="right" class="FormViewLabelCell" style="width: 30%; height: 26px" width="40%">
                            
                            <span class="reqasterisk">*</span> <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="FirstNameTextBox">
                            <asp:Literal ID="Literal18" runat="server" Text='<%# ResourceHelper.GetFromResource("First Name:") %>' /></asp:Label></td><td style="width: 99%; height: 26px">
                            <asp:TextBox 
                                ID="FirstNameTextBox" runat="server" MaxLength="50" Text='<%# Bind("FirstName") %>'
                                Width="160px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="FirstNameTextBox"
                                CssClass="ErrorMessage" Display="Dynamic" ErrorMessage="*" Width="1px"></asp:RequiredFieldValidator></td></tr><tr>
                        <td align="right" class="FormViewLabelCell" style="width: 30%; height: 26px" width="40%">
                           
                            <span class="reqasterisk">*</span> <asp:Label ID="Label6" runat="server" AssociatedControlID="LastNameTextBox">
                            <asp:Literal ID="Literal19" runat="server" Text='<%# ResourceHelper.GetFromResource("Last Name:") %>' /></asp:Label></td><td style="width: 99%; height: 26px">
                            <asp:TextBox 
                                ID="LastNameTextBox" runat="server" MaxLength="50" 
                                Text='<%# Bind("LastName") %>' Width="160px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="LastNameTextBox"
                                CssClass="ErrorMessage" Display="Dynamic" ErrorMessage="*" Width="1px"></asp:RequiredFieldValidator></td></tr><tr>
                        <td align="right" class="FormViewLabelCell" style="width: 30%; height: 26px" width="40%">
                            
<asp:Label ID="Label9" runat="server" AssociatedControlID="EMailAddressTextBox">
                            <asp:Literal ID="Literal20" runat="server" Text='<%# ResourceHelper.GetFromResource("Email Address:") %>' /></asp:Label></td><td style="width: 99%; height: 26px">
                            <asp:TextBox 
                                ID="EMailAddressTextBox" runat="server" MaxLength="50" Text='<%# Bind("EMailAddress") %>'
                                Width="225px"></asp:TextBox><asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="EMailAddressTextBox"
                                CssClass="ErrorMessage" Display="Dynamic" ErrorMessage="Incorrect EMail Address"
                                Font-Bold="False" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator></td></tr><tr >
                        <td align="right" class="FormViewLabelCell" style="width: 30%; height: 26px" width="40%">
                            
<asp:Label ID="Label11" runat="server" AssociatedControlID="Address1TextBox">
                            <asp:Literal ID="Literal21" runat="server" Text='<%# ResourceHelper.GetFromResource("Address1:") %>' /></asp:Label></td><td style="width: 99%; height: 26px">
                            <asp:TextBox 
                                ID="Address1TextBox" runat="server" MaxLength="150" Text='<%# Bind("Address1") %>'
                                Width="225px"></asp:TextBox></td></tr><tr><trlivetecs live="" 
                            support=""></trlivetecs><td align="right" class="FormViewLabelCell" 
                            style="width: 30%; height: 26px" width="40%"><asp:Label ID="Label13" 
                                runat="server" AssociatedControlID="Address2TextBox"> <asp:Literal 
                                ID="Literal22" runat="server" 
                                Text='<%# ResourceHelper.GetFromResource("Address2:") %>' /></asp:Label></td></td><td 
                            style="width: 99%; height: 26px"><asp:TextBox ID="Address2TextBox" 
                                runat="server" MaxLength="150" Text='<%# Bind("Address2") %>' Width="225px"></asp:TextBox></td></tr><tr><trlivetecs 
                            live="" support=""></trlivetecs><td align="right" class="FormViewLabelCell" 
                            style="width: 30%; height: 26px" width="40%"><asp:Literal ID="Literal23" 
                                runat="server" Text='<%# ResourceHelper.GetFromResource("Country:") %>' /></td><td 
                            style="width: 99%; height: 26px"><asp:DropDownList ID="ddlCountryId" 
                                runat="server" DataSourceID="dsCountryObject" DataTextField="Country" 
                                DataValueField="CountryId" SelectedValue='<%# Bind("CountryId") %>' 
                                Width="175px"></asp:DropDownList></td></tr><tr><trlivetecs live="" 
                            support=""></trlivetecs><td align="right" class="FormViewLabelCell" 
                            style="width: 30%; height: 26px" width="40%"><asp:Label ID="Label16" 
                                runat="server" AssociatedControlID="StateTextBox"> <asp:Literal 
                                ID="Literal24" runat="server" 
                                Text='<%# ResourceHelper.GetFromResource("State:") %>' /></asp:Label></td><td 
                            style="width: 99%; height: 26px"><asp:TextBox ID="StateTextBox" runat="server" 
                                MaxLength="20" Text='<%# Bind("State") %>' Width="160px"></asp:TextBox></td></tr><tr><trlivetecs 
                            live="" support=""></trlivetecs><td align="right" class="FormViewLabelCell" 
                            style="width: 30%; height: 26px" width="40%"><asp:Label ID="Label17" 
                                runat="server" AssociatedControlID="CityTextBox"> <asp:Literal 
                                ID="Literal25" runat="server" 
                                Text='<%# ResourceHelper.GetFromResource("City:") %>' /></asp:Label></td></td><td 
                            style="width: 99%; height: 26px"><asp:TextBox ID="CityTextBox" runat="server" 
                                MaxLength="50" Text='<%# Bind("City") %>' Width="160px"></asp:TextBox></td></tr><tr><trlivetecs 
                            live="" support=""></trlivetecs><td align="right" class="FormViewLabelCell" 
                            style="width: 30%; height: 26px" width="40%"><asp:Label ID="Label20" 
                                runat="server" AssociatedControlID="ZipCodeTextBox"> <asp:Literal 
                                ID="Literal26" runat="server" 
                                Text='<%# ResourceHelper.GetFromResource("ZipCode:") %>' /></asp:Label></td></td><td 
                            style="width: 99%; height: 26px"><asp:TextBox ID="ZipCodeTextBox" 
                                runat="server" MaxLength="10" Text='<%# Bind("Zip") %>' Width="160px"></asp:TextBox></td></tr><tr><trlivetecs 
                            live="" support=""></trlivetecs><td align="right" class="FormViewLabelCell" 
                            style="width: 30%; height: 26px" width="40%"><asp:Label ID="Label21" 
                                runat="server" AssociatedControlID="Telephone1TextBox"> <asp:Literal 
                                ID="Literal27" runat="server" 
                                Text='<%# ResourceHelper.GetFromResource("Telephone1:") %>' /></asp:Label></td></td><td 
                            style="width: 99%; height: 26px"><asp:TextBox ID="Telephone1TextBox" 
                                runat="server" MaxLength="25" Text='<%# Bind("Telephone1") %>' Width="160px"></asp:TextBox></td></tr><tr><trlivetecs 
                            live="" support=""></trlivetecs><td align="right" class="FormViewLabelCell" 
                            style="width: 30%; height: 26px" width="40%"><asp:Label ID="Label23" 
                                runat="server" AssociatedControlID="Telephone2TextBox"> <asp:Literal 
                                ID="Literal30" runat="server" 
                                Text='<%# ResourceHelper.GetFromResource("Telephone2:") %>' /></asp:Label></td></td><td 
                            style="width: 99%; height: 26px"><asp:TextBox ID="Telephone2TextBox" 
                                runat="server" MaxLength="25" Text='<%# Bind("Telephone2") %>' Width="160px"></asp:TextBox></td></tr><tr><trlivetecs 
                            live="" support=""></trlivetecs><td align="right" class="FormViewLabelCell" 
                            style="width: 30%; height: 26px" width="40%"><asp:Label ID="Label26" 
                                runat="server" AssociatedControlID="FaxTextBox"> <asp:Literal 
                                ID="Literal29" runat="server" 
                                Text='<%# ResourceHelper.GetFromResource("Fax:") %>' /></asp:Label></td></td><td 
                            style="width: 99%; height: 26px"><asp:TextBox ID="FaxTextBox" runat="server" 
                                MaxLength="25" Text='<%# Bind("Fax") %>' Width="160px"></asp:TextBox></td></tr><tr><trlivetecs 
                            live="" support=""></trlivetecs><td align="right" class="FormViewLabelCell" 
                            style="width: 30%; height: 26px" width="40%"><asp:Literal ID="Literal15" 
                                runat="server" 
                                Text='<%# ResourceHelper.GetFromResource("Client Department:") %>' /></td><td 
                            style="width: 99%; height: 26px"><asp:DropDownList 
                                ID="ddlAccountPartyDepartmentId" runat="server" AppendDataBoundItems="True" 
                                DataSourceID="dsAccountPartDepartmentObject" 
                                DataTextField="PartyDepartmentCode" DataValueField="AccountPartyDepartmentId" 
                                SelectedValue='<%# Bind("AccountPartyDepartmentId") %>' Width="175px"><asp:ListItem 
                                    ID="Label1" runat="server" Label="" 
                                    Text="<%$ Resources:TimeLive.Resource, Select%> " Value="0"></asp:ListItem><%--<asp:ListItem Value="0">&lt;Select&gt;</asp:ListItem>--%></asp:DropDownList></td></tr><tr><trlivetecs 
                            live="" support=""></trlivetecs><td align="right" class="FormViewLabelCell" 
                            style="width: 30%; height: 26px" valign="top" width="40%"><asp:Label 
                                ID="Label28" runat="server" AssociatedControlID="LocationTextBox"> <asp:Literal 
                                ID="Literal28" runat="server" 
                                Text='<%# ResourceHelper.GetFromResource("Location:") %>' /></asp:Label></td><td 
                            style="width: 99%; height: 26px"><asp:TextBox ID="LocationTextBox" 
                                runat="server" MaxLength="50" Rows="4" Text='<%# Bind("Location") %>' 
                                Width="160px"></asp:TextBox></td></tr><tr><trlivetecs live="" 
                            support=""></trlivetecs><td align="right" class="FormViewLabelCell" 
                            style="width: 30%; height: 26px" valign="baseline" width="40%"></td><td 
                            style="width: 99%; height: 26px; padding-bottom: 5px;"><asp:Button ID="Add" 
                                runat="server" CommandName="Insert" 
                                Text="<%$ Resources:TimeLive.Resource, Add_text%> " Width="68px" /></td></tr></table>
            </InsertItemTemplate>
            <ItemTemplate>
                AccountPartyContactId: <asp:Label ID="AccountPartyContactIdLabel" runat="server" Text='<%# Eval("AccountPartyContactId") %>'>
                </asp:Label><br />AccountPartyId: <asp:Label ID="AccountPartyIdLabel" runat="server" Text='<%# Bind("AccountPartyId") %>'>
                </asp:Label><br />ContactPerson: <asp:Label ID="ContactPersonLabel" runat="server" Text='<%# Bind("ContactPerson") %>'>
                </asp:Label><br />Department: <asp:Label ID="DepartmentLabel" runat="server" Text='<%# Bind("Department") %>'>
                </asp:Label><br />Telephone1: <asp:Label ID="Telephone1Label" runat="server" Text='<%# Bind("Telephone1") %>'>
                </asp:Label><br />Telephone2: <asp:Label ID="Telephone2Label" runat="server" Text='<%# Bind("Telephone2") %>'>
                </asp:Label><br />Fax: <asp:Label ID="FaxLabel" runat="server" Text='<%# Bind("Fax") %>'></asp:Label><br />EMailAddress: <asp:Label ID="EMailAddressLabel" runat="server" Text='<%# Bind("EMailAddress") %>'>
                </asp:Label><br /><asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" CommandName="Edit"
                    Text="Edit">
                </asp:LinkButton><asp:LinkButton ID="DeleteButton" runat="server" CausesValidation="False" CommandName="Delete"
                    Text="Delete">
                </asp:LinkButton><asp:LinkButton ID="NewButton" runat="server" CausesValidation="False" CommandName="New"
                    Text="New">
                </asp:LinkButton></ItemTemplate></asp:FormView><asp:ObjectDataSource ID="dsAccountPartDepartmentObject" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetDataByAccountPartyId" TypeName="AccountPartyDepartmentBLL">
            <SelectParameters>
                <asp:QueryStringParameter Name="AccountPartyId" QueryStringField="AccountPartyId"
                    Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="dsCountryObject" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetCountries" TypeName="SystemDataBLL"></asp:ObjectDataSource>
    </ContentTemplate>
</asp:UpdatePanel>
