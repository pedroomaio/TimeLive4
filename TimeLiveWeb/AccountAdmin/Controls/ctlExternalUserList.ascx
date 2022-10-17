<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlExternalUserList.ascx.vb" Inherits="AccountAdmin_Controls_ctlExternalUserList" %>
<%@ Register Assembly="eWorld.UI.Compatibility, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2"
    Namespace="eWorld.UI.Compatibility" TagPrefix="cc1" %>
<%@ Register Assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2"
    Namespace="eWorld.UI" TagPrefix="ew" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <x:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Caption='<%# ResourceHelper.GetFromResource("External User List") %>'
            DataKeyNames="AccountEmployeeId" DataSourceID="dsAccountEmployeeList" SkinID="xgridviewSkinEmployee"
            Width="98%">
            <Columns>
                <asp:TemplateField SortExpression="FirstName" HeaderText="<%$ Resources:TimeLive.Resource, First Name %>" >
                    <edititemtemplate>
<asp:TextBox id="TextBox1" runat="server" Text='<%# Bind("FirstName") %>' __designer:wfdid="w154"></asp:TextBox>
</edititemtemplate>
                    <headertemplate>
<asp:LinkButton id="LinkButton3" runat="server" Text='<%# ResourceHelper.GetFromResource("First Name") %>' CommandArgument="FirstName" CommandName="Sort" CausesValidation="False"></asp:LinkButton>
</headertemplate>
                    <itemtemplate>
<asp:Label id="Label1" runat="server" Text='<%# Bind("FirstName") %>' __designer:wfdid="w153"></asp:Label>
</itemtemplate>
                    <itemstyle width="20%" />
                </asp:TemplateField>
                <asp:TemplateField SortExpression="LastName" HeaderText="<%$ Resources:TimeLive.Resource, Last Name %>">
                    <edititemtemplate>
<asp:TextBox id="TextBox2" runat="server" Text='<%# Bind("LastName") %>' __designer:wfdid="w157"></asp:TextBox>
</edititemtemplate>
                    <headertemplate>
<asp:LinkButton id="LinkButton4" runat="server" Text='<%# ResourceHelper.GetFromResource("Last Name") %>' CommandArgument="LastName" CommandName="Sort" CausesValidation="False"></asp:LinkButton>
</headertemplate>
                    <itemtemplate>
<asp:Label id="Label2" runat="server" Text='<%# Bind("LastName") %>' __designer:wfdid="w156"></asp:Label>
</itemtemplate>
                    <itemstyle width="20%" />
                </asp:TemplateField>
                <asp:TemplateField SortExpression="EMailAddress" HeaderText="<%$ Resources:TimeLive.Resource, Email Address %>">
                    <edititemtemplate>
<asp:TextBox id="TextBox3" runat="server" Text='<%# Bind("EMailAddress") %>' __designer:wfdid="w160"></asp:TextBox>
</edititemtemplate>
                    <headertemplate>
<asp:LinkButton id="LinkButton5" runat="server" Text='<%# ResourceHelper.GetFromResource("Email Address") %>' CommandArgument="EMailAddress" CommandName="Sort" CausesValidation="False"></asp:LinkButton>
</headertemplate>
                    <itemtemplate>
<asp:Label id="Label3" runat="server" Text='<%# Bind("EMailAddress") %>' __designer:wfdid="w159"></asp:Label>
</itemtemplate>
                    <itemstyle width="27.5%" />
                </asp:TemplateField>
                <asp:TemplateField SortExpression="PartyName" HeaderText="<%$ Resources:TimeLive.Resource, Client Name %>">
                    <edititemtemplate>
<asp:TextBox id="TextBox4" runat="server" Text='<%# Bind("PartyName") %>' __designer:wfdid="w163"></asp:TextBox>
</edititemtemplate>
                    <headertemplate>
<asp:LinkButton id="LinkButton6" runat="server" Text='<%# ResourceHelper.GetFromResource("Client Name") %>' CommandArgument="PartyName" CommandName="Sort" CausesValidation="False"></asp:LinkButton>
</headertemplate>
                    <itemtemplate>
<asp:Label id="Label4" runat="server" Text='<%# Bind("PartyName") %>' __designer:wfdid="w162"></asp:Label>
</itemtemplate>
                    <itemstyle width="27.5%" />
                </asp:TemplateField>
                <asp:TemplateField ShowHeader="False" HeaderText="<%$ Resources:TimeLive.Resource, Edit_text %>">
                    <itemtemplate>
<asp:LinkButton id="LinkButton2" runat="server" Visible='<%# iif(Eval("AccountEmployeeId") = 0,false,true) %>' __designer:wfdid="w29" CausesValidation="False" CommandName="Select" Text="Edit"></asp:LinkButton>
</itemtemplate>
                    <itemstyle cssclass="edit_button" horizontalalign="Center" width="1%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Delete_text %>" ShowHeader="False">
                    <ItemTemplate>
<asp:LinkButton id="LinkButton1" runat="server" Visible='<%# iif(Eval("AccountEmployeeId") = 0,false,true) %>' __designer:wfdid="w30" CausesValidation="False" CommandName="Delete" OnClientClick="<%# ResourceHelper.GetDeleteMessageJavascript() %>" Text="<%$ Resources:TimeLive.Resource, Delete_text %>"></asp:LinkButton> 
</ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" Width="1%" cssclass="delete_button" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/Disabled.gif" ToolTip="<%$ Resources:TimeLive.Resource, Disabled_text%> " />
                    
</HeaderTemplate>
                    <ItemTemplate>
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/Disabled.gif" Visible='<%# IIF(IsDBNull(Eval("IsDisabled")),"false",Eval("IsDisabled")) %>' ToolTip="<%$ Resources:TimeLive.Resource, Disabled_text%> " />
                    
</ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </x:GridView>
        <asp:ObjectDataSource ID="dsAccountEmployeeList" runat="server" DeleteMethod="DeleteAccountEmployee"
            InsertMethod="AddExternalAccountEmployee" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetAccountEmployeesForExternalUser" TypeName="AccountEmployeeBLL"
            UpdateMethod="UpdateExternalAccountEmployee">
            <DeleteParameters>
                <asp:Parameter Name="Original_AccountEmployeeId" Type="Int32" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="Login" Type="String" />
                <asp:Parameter Name="Password" Type="String" />
                <asp:Parameter Name="Prefix" Type="String" />
                <asp:Parameter Name="FirstName" Type="String" />
                <asp:Parameter Name="LastName" Type="String" />
                <asp:Parameter Name="MiddleName" Type="String" />
                <asp:Parameter Name="EMailAddress" Type="String" />
                <asp:Parameter Name="AccountId" Type="Int32" />
                <asp:Parameter Name="AccountDepartmentId" Type="Int32" />
                <asp:Parameter Name="AccountRoleId" Type="Int32" />
                <asp:Parameter Name="AccountLocationId" Type="Int32" />
                <asp:Parameter Name="AddressLine1" Type="String" />
                <asp:Parameter Name="AddressLine2" Type="String" />
                <asp:Parameter Name="State" Type="String" />
                <asp:Parameter Name="City" Type="String" />
                <asp:Parameter Name="Zip" Type="String" />
                <asp:Parameter Name="CountryId" Type="Int16" />
                <asp:Parameter Name="HomePhoneNo" Type="String" />
                <asp:Parameter Name="WorkPhoneNo" Type="String" />
                <asp:Parameter Name="MobilePhoneNo" Type="String" />
                <asp:Parameter Name="BillingRateCurrencyId" Type="Int16" />
                <asp:Parameter Name="BillingTypeId" Type="Int32" />
                <asp:Parameter Name="BillingRate" Type="Decimal" />
                <asp:Parameter Name="BillingRateStartDate" Type="DateTime" />
                <asp:Parameter Name="StartDate" Type="DateTime" />
                <asp:Parameter Name="TerminationDate" Type="DateTime" />
                <asp:Parameter Name="StatusId" Type="Byte" />
                <asp:Parameter Name="IsDeleted" Type="Boolean" />
                <asp:Parameter Name="IsDisabled" Type="Boolean" />
                <asp:Parameter Name="DefaultProjectId" Type="Int32" />
                <asp:Parameter Name="TimeZoneId" Type="Byte" />
                <asp:Parameter Name="CreatedByEmployeeId" Type="Int32" />
                <asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" />
                <asp:Parameter Name="AllowedAccessFromIP" Type="String" />
                <asp:Parameter Name="EmployeeTypeId" Type="Byte" />
                <asp:Parameter Name="ExternalUserClientId" Type="Int32" />
                <asp:Parameter Name="Original_AccountEmployeeId" Type="Int32" />
            </UpdateParameters>
            <SelectParameters>
                <asp:SessionParameter DefaultValue="64" Name="AccountId" SessionField="AccountId"
                    Type="Int32" />
            </SelectParameters>
            <InsertParameters>
                <asp:Parameter Name="Password" Type="String" />
                <asp:Parameter Name="FirstName" Type="String" />
                <asp:Parameter Name="LastName" Type="String" />
                <asp:Parameter Name="EMailAddress" Type="String" />
                <asp:Parameter Name="AccountId" Type="Int32" />
                <asp:Parameter Name="AccountDepartmentId" Type="Int32" />
                <asp:Parameter Name="AccountRoleId" Type="Int32" />
                <asp:Parameter Name="AccountLocationId" Type="Int32" />
                <asp:Parameter Name="CountryId" Type="Int16" />
                <asp:Parameter Name="BillingRateCurrencyId" Type="Int16" />
                <asp:Parameter Name="BillingTypeId" Type="Int32" />
                <asp:Parameter Name="BillingRate" Type="Decimal" />
                <asp:Parameter Name="BillingRateStartDate" Type="DateTime" />
                <asp:Parameter Name="StartDate" Type="DateTime" />
                <asp:Parameter Name="DefaultProjectId" Type="Int32" />
                <asp:Parameter Name="TimeZoneId" Type="Byte" />
                <asp:Parameter Name="CreatedByEmployeeId" Type="Int32" />
                <asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" />
                <asp:Parameter Name="EmployeeTypeId" Type="Byte" />
                <asp:Parameter Name="ExternalUserClientId" Type="Int32" />
                <asp:Parameter Name="AddressLine1" Type="String" />
                <asp:Parameter Name="AddressLine2" Type="String" />
                <asp:Parameter Name="State" Type="String" />
                <asp:Parameter Name="City" Type="String" />
                <asp:Parameter Name="Zip" Type="String" />
                <asp:Parameter Name="HomePhoneNo" Type="String" />
                <asp:Parameter Name="WorkPhoneNo" Type="String" />
                <asp:Parameter Name="MobilePhoneNo" Type="String" />
                <asp:Parameter Name="MiddleName" Type="String" />
                <asp:Parameter Name="Prefix" Type="String" />
                <asp:Parameter Name="DoNotSendEMail" Type="Boolean" />
            </InsertParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DeleteMethod="DeleteAccountEmployee"
            InsertMethod="AddExternalAccountEmployee" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetAccountEmployeesByAccountEmployeeId" TypeName="AccountEmployeeBLL"
            UpdateMethod="UpdateExternalAccountEmployee">
            <DeleteParameters>
                <asp:Parameter Name="Original_AccountEmployeeId" Type="Int32" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="Login" Type="String" />
                <asp:Parameter Name="Password" Type="String" />
                <asp:Parameter Name="Prefix" Type="String" />
                <asp:Parameter Name="FirstName" Type="String" />
                <asp:Parameter Name="LastName" Type="String" />
                <asp:Parameter Name="MiddleName" Type="String" />
                <asp:Parameter Name="EMailAddress" Type="String" />
                <asp:SessionParameter DefaultValue="23" Name="AccountId" SessionField="AccountId"
                    Type="Int32" />
                <asp:Parameter Name="AccountDepartmentId" Type="Int32" />
                <asp:Parameter Name="AccountRoleId" Type="Int32" />
                <asp:Parameter Name="AccountLocationId" Type="Int32" />
                <asp:Parameter Name="AddressLine1" Type="String" />
                <asp:Parameter Name="AddressLine2" Type="String" />
                <asp:Parameter Name="State" Type="String" />
                <asp:Parameter Name="City" Type="String" />
                <asp:Parameter Name="Zip" Type="String" />
                <asp:Parameter Name="CountryId" Type="Int16" />
                <asp:Parameter Name="HomePhoneNo" Type="String" />
                <asp:Parameter Name="WorkPhoneNo" Type="String" />
                <asp:Parameter Name="MobilePhoneNo" Type="String" />
                <asp:Parameter Name="BillingRateCurrencyId" Type="Int16" />
                <asp:Parameter ConvertEmptyStringToNull="False" Name="BillingTypeId" Type="Int32" />
                <asp:Parameter Name="BillingRate" Type="Decimal" />
                <asp:Parameter Name="BillingRateStartDate" Type="DateTime" />
                <asp:Parameter Name="StartDate" Type="DateTime" />
                <asp:Parameter Name="TerminationDate" Type="DateTime" />
                <asp:Parameter Name="StatusId" Type="Byte" />
                <asp:Parameter Name="IsDeleted" Type="Boolean" />
                <asp:Parameter Name="IsDisabled" Type="Boolean" />
                <asp:Parameter Name="DefaultProjectId" Type="Int32" />
                <asp:Parameter Name="TimeZoneId" Type="Byte" />
                <asp:Parameter Name="CreatedByEmployeeId" Type="Int32" />
                <asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" />
                <asp:Parameter Name="AllowedAccessFromIP" Type="String" />
                <asp:Parameter Name="EmployeeTypeId" Type="Byte" />
                <asp:Parameter Name="ExternalUserClientId" Type="Int32" />
                <asp:Parameter Name="Original_AccountEmployeeId" Type="Int32" />
            </UpdateParameters>
            <SelectParameters>
                <asp:ControlParameter ControlID="GridView1" Name="AccountEmployeeId" PropertyName="SelectedValue"
                    Type="Int32" />
            </SelectParameters>
            <InsertParameters>
                <asp:Parameter Name="Password" Type="String" />
                <asp:Parameter Name="FirstName" Type="String" />
                <asp:Parameter Name="LastName" Type="String" />
                <asp:Parameter Name="EMailAddress" Type="String" />
                <asp:SessionParameter DefaultValue="64" Name="AccountId" SessionField="AccountId"
                    Type="Int32" />
                <asp:Parameter Name="AccountDepartmentId" Type="Int32" />
                <asp:Parameter Name="AccountRoleId" Type="Int32" />
                <asp:Parameter Name="AccountLocationId" Type="Int32" />
                <asp:Parameter Name="CountryId" Type="Int16" />
                <asp:Parameter Name="BillingRateCurrencyId" Type="Int16" />
                <asp:Parameter Name="BillingTypeId" Type="Int32" />
                <asp:Parameter Name="BillingRate" Type="Decimal" />
                <asp:Parameter Name="BillingRateStartDate" Type="DateTime" />
                <asp:Parameter Name="StartDate" Type="DateTime" />
                <asp:Parameter Name="DefaultProjectId" Type="Int32" />
                <asp:Parameter Name="TimeZoneId" Type="Byte" />
                <asp:Parameter Name="CreatedByEmployeeId" Type="Int32" />
                <asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" />
                <asp:Parameter Name="EmployeeTypeId" Type="Byte" />
                <asp:Parameter Name="ExternalUserClientId" Type="Int32" />
                <asp:Parameter Name="AddressLine1" Type="String" />
                <asp:Parameter Name="AddressLine2" Type="String" />
                <asp:Parameter Name="State" Type="String" />
                <asp:Parameter Name="City" Type="String" />
                <asp:Parameter Name="Zip" Type="String" />
                <asp:Parameter Name="HomePhoneNo" Type="String" />
                <asp:Parameter Name="WorkPhoneNo" Type="String" />
                <asp:Parameter Name="MobilePhoneNo" Type="String" />
                <asp:Parameter Name="MiddleName" Type="String" />
                <asp:Parameter Name="Prefix" Type="String" />
                <asp:Parameter Name="DoNotSendEMail" Type="Boolean" />
            </InsertParameters>
        </asp:ObjectDataSource>
    </ContentTemplate>
</asp:UpdatePanel>
<br />
<asp:UpdatePanel ID="UpdatePanel3" runat="server">
    <ContentTemplate>
        <asp:FormView ID="FormView1" runat="server" DataKeyNames="AccountEmployeeId" DataSourceID="ObjectDataSource1"
            DefaultMode="Insert" SkinID="formviewSkinEmployee" Width="99%">
            <EditItemTemplate>
                <table id="Table1" border="0" cellpadding="0" cellspacing="2" language="javascript"
                    style="width: 100%" class="xview">
                    <tr>
                        <th class="caption" colspan="4" style="width: 20%; height: 26px">
                            <asp:Literal ID="Literal1" runat="server" Text='<%# ResourceHelper.GetFromResource("External User Information")%> ' /></th>
                    </tr>
                    <tr>
                        <th class="FormViewSubHeader" colspan="4" style="width: 20%; height: 26px">
                            <asp:Literal ID="Literal2" runat="server" Text='<%# ResourceHelper.GetFromResource("Personal Information")%> ' /></th>
                    </tr>
                    <tr>
                        <td align="right" class="FormViewLabelCell" style="width: 20%; height: 26px">
                            <asp:Literal ID="Literal7" runat="server" Text='<%# ResourceHelper.GetFromResource("Prefix:")%> ' /></td>
                        <td style="width: 30%; height: 26px" width="40%">
                            <asp:DropDownList ID="ddlPrefix" runat="server" DataSourceID="dsSystemNamePrefixObject"
                                DataTextField="SystemNamePrefix" width="188px" 
                                DataValueField="SystemNamePrefix" >
                            </asp:DropDownList></td>
                        <td class="FormViewLabelCell" style="width: 20%; height: 26px">
                        </td>
                        <td style="width: 30%; height: 26px">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td align="right" class="FormViewLabelCell" style="width: 20%; height: 26px">
                            <span class="reqasterisk">*</span> 
<asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="FirstNameTextBox"><asp:Literal ID="Literal3" runat="server" Text='<%# ResourceHelper.GetFromResource("First Name:")%> ' /></asp:Label></td><td style="width: 30%; height: 26px" width="40%">
                            <asp:TextBox 
                                ID="FirstNameTextBox" runat="server" Text='<%# Bind("FirstName") %>'
                                ValidationGroup="Update" Width="176px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator4"
                                    runat="server" ControlToValidate="FirstNameTextBox" CssClass="ErrorMessage" Display="Dynamic"
                                    ErrorMessage="*" ValidationGroup="Insert" Width="1px"></asp:RequiredFieldValidator></td><td align="right" class="FormViewLabelCell" style="width: 20%; height: 26px">
                            
<asp:Label ID="Label5" runat="server" AssociatedControlID="MiddleNameTextBox">
                            <asp:Literal ID="Literal5" runat="server" Text='<%# ResourceHelper.GetFromResource("Middle Name:")%> ' /></asp:Label></td><td style="width: 30%; height: 26px">
                            <asp:TextBox 
                                ID="MiddleNameTextBox" runat="server" Text='<%# Bind("MiddleName") %>' 
                                Width="176px"></asp:TextBox></td></tr><tr>
                        <td align="right" class="FormViewLabelCell" style="width: 20%; height: 26px">
                            
<asp:Label ID="Label6" runat="server" AssociatedControlID="LastNameTextBox">
                            <span class="reqasterisk">*</span> <asp:Literal ID="Literal6" runat="server" Text='<%# ResourceHelper.GetFromResource("Last Name:")%> '  /></asp:Label></td><td style="width: 30%; height: 26px" width="40%">
                            <asp:TextBox 
                                ID="LastNameTextBox" runat="server" Text='<%# Bind("LastName") %>' 
                                ValidationGroup="Update" Width="176px"></asp:TextBox><asp:RequiredFieldValidator
                                ID="RequiredFieldValidator5" runat="server" ControlToValidate="LastNameTextBox"
                                CssClass="ErrorMessage" Display="Dynamic" ErrorMessage="*" ValidationGroup="Insert"
                                Width="1px"></asp:RequiredFieldValidator></td><td align="right" class="FormViewLabelCell" style="width: 20%; height: 26px">
                            
                        <span 
                                class="reqasterisk">*</span> <asp:Literal ID="Literal8" runat="server" 
                                Text='<%# ResourceHelper.GetFromResource("External User Client:")%> ' /></td>
                        <td style="width: 30%; height: 26px">
                        <asp:DropDownList ID="ddlExternalUserClientId" 
                                runat="server" DataSourceID="dsClientObject" DataTextField="PartyName" 
                                DataValueField="AccountPartyId" Width="188px"></asp:DropDownList><asp:RequiredFieldValidator 
                                ID="RequiredFieldValidator1" runat="server" 
                                ControlToValidate="ddlExternalUserClientId" CssClass="ErrorMessage" 
                                Display="Dynamic" ErrorMessage="*" ValidationGroup="Insert" Width="1px"></asp:RequiredFieldValidator></td></tr><tr>
                        <td align="right" class="FormViewLabelCell" style="width: 20%; height: 26px">
                            <asp:Literal ID="Literal25" runat="server" Text='<%# ResourceHelper.GetFromResource("TimeZone:")%> '  /></td><td colspan="3" style="height: 26px">
                            <asp:DropDownList 
                                ID="ddlTimeZoneId" runat="server" DataSourceID="dsTimeZone" DataTextField="TimeZoneName"
                                DataValueField="SystemTimeZoneId" Width="350px"></asp:DropDownList></td>
                    </tr>
                    <tr>
                        <th class="FormViewSubHeader" colspan="4" style="width: 20%; height: 26px">
                            <asp:Literal ID="Literal9" runat="server" Text='<%# ResourceHelper.GetFromResource("Login:")%> '  /></th>
                    </tr>
                    <tr>
                        <td align="right" class="FormViewLabelCell" style="width: 20%; height: 26px">
                            
<asp:Label 
                                ID="Label8" runat="server" AssociatedControlID="EMailAddressTextBox">
                            <span class="reqasterisk">* </span><asp:Literal 
                                ID="Literal10" runat="server" 
                                Text='<%# ResourceHelper.GetFromResource("Login Email Address:")%> '  /></asp:Label></td><td style="width: 30%; height: 26px" width="40%">
                            <asp:TextBox 
                                ID="EMailAddressTextBox" runat="server" Text='<%# Bind("EMailAddress") %>' 
                                ValidationGroup="Update" Width="176px"></asp:TextBox><asp:RequiredFieldValidator 
                                ID="RequiredFieldValidator7" runat="server" 
                                ControlToValidate="EMailAddressTextBox" CssClass="ErrorMessage" 
                                Display="Dynamic" ErrorMessage="*" ValidationGroup="Insert" Width="8px"></asp:RequiredFieldValidator><asp:RegularExpressionValidator 
                                ID="RegularExpressionValidator1" runat="server" 
                                ControlToValidate="EMailAddressTextBox" CssClass="ErrorMessage" 
                                Display="Dynamic" ErrorMessage="Incorrect EMail Address" Font-Bold="True" 
                                Font-Names="Verdana" Font-Size="X-Small" 
                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                                ValidationGroup="Update"></asp:RegularExpressionValidator><asp:Label 
                                ID="lblExceptionText" runat="server" CssClass="ErrorMessage" 
                                Text="Login Already Exist" Visible="False"></asp:Label>&nbsp; </td><td 
                            align="right" class="FormViewLabelCell" colspan="1" 
                            style="width: 20%; height: 26px">&nbsp;</td><td colspan="1" 
                            style="width: 30%; height: 26px"><asp:DropDownList 
                                ID="ddlAccountRoleId" runat="server" DataSourceID="dsAccountRoleObject" 
                                DataTextField="Role" DataValueField="AccountRoleId" 
                                SelectedValue='<%# Bind("AccountRoleId") %>' Width="188px" Visible="False"></asp:DropDownList></td></tr><tr><td 
                            align="right" class="FormViewLabelCell" style="width: 20%; height: 26px"><asp:Label 
                            ID="Label10" runat="server" AssociatedControlID="PasswordTextBox">
                            <span class="reqasterisk">*</span> <asp:Literal ID="Literal20" runat="server" Text='<%# ResourceHelper.GetFromResource("Password:")%> '  /></asp:Label></td><td 
                            style="width: 30%; height: 26px" width="40%"><asp:TextBox ID="PasswordTextBox" 
                                runat="server" Text='<%# Bind("Password") %>' TextMode="Password" 
                                ValidationGroup="Update" Width="176px"></asp:TextBox><asp:RequiredFieldValidator 
                                ID="RequiredFieldValidator2" runat="server" ControlToValidate="PasswordTextBox" 
                                CssClass="ErrorMessage" Display="Dynamic" ErrorMessage="*" 
                                ValidationGroup="Insert" Width="16px"></asp:RequiredFieldValidator><asp:RegularExpressionValidator 
                                ID="RegularExpressionValidator2" runat="server" 
                                ControlToValidate="PasswordTextBox" Display="Dynamic" 
                                SkinID="PasswordValidator" 
                                ValidationExpression="(?=^.{8,}$)(?=.*\d)(?=.*\W+)(?![.\n]).*$" 
                                ValidationGroup="Update"></asp:RegularExpressionValidator></td><td 
                            align="right" class="FormViewLabelCell" colspan="1" 
                            style="width: 20%; height: 26px" ><asp:Label ID="Label11" 
                                runat="server" AssociatedControlID="VerifyPasswordTextbox">
                            <span class="reqasterisk">*</span> <asp:Literal ID="Literal21" runat="server" Text='<%# ResourceHelper.GetFromResource("Verify Password:")%> '  /></asp:Label></td><td 
                            colspan="1" style="width: 30%; height: 26px"><asp:TextBox 
                                ID="VerifyPasswordTextbox" runat="server" TextMode="Password" 
                                ValidationGroup="Update" Width="176px"></asp:TextBox><asp:CompareValidator 
                                ID="CompareValidator1" runat="server" ControlToCompare="VerifyPasswordTextbox" 
                                ControlToValidate="PasswordTextBox" CssClass="ErrorMessage" 
                                ErrorMessage="(Mismatch)" ValidationGroup="Update"></asp:CompareValidator></td></tr><tr>
                        <td align="right" class="FormViewLabelCell" style="width: 20%; height: 26px">
                            <asp:Literal 
                                ID="Literal24" runat="server" 
                                Text='<%# ResourceHelper.GetFromResource("Disabled:")%> ' /></td>
                        <td style="width: 30%; height: 26px" width="40%">
                            <asp:CheckBox ID="CheckBox1" 
                                runat="server" Checked='<%# Bind("IsDisabled") %>' /></td>
                        <td align="right" class="FormViewLabelCell" 
                            colspan="1" style="width: 20%; height: 26px" >&nbsp;</td><td 
                            colspan="1" style="width: 30%; height: 26px">&nbsp;</td></tr><tr>
                        <td class="FormViewLabelCell" colspan="3" style="width: 20%; height: 26px; padding-bottom: 5px;">
                            &nbsp;</td><td colspan="1" style="width: 30%; height: 26px; padding-bottom: 5px;">
                            <asp:Button ID="Update" runat="server" CommandName="Update" Text="<%$ Resources:TimeLive.Resource, Update_text%> " ValidationGroup="Update"
                                Width="68px" />&nbsp;<asp:Button ID="Cancel" runat="server" CommandName="Cancel" Text="<%$ Resources:TimeLive.Resource, Cancel_text%> " ValidationGroup="Cancel"
                                Width="68px" /></td>
                    </tr>
                </table>
            </EditItemTemplate>
            <InsertItemTemplate>
                            <table id="Table2" border="0" cellpadding="0" cellspacing="2" language="javascript"
                    style="width: 100%" class="xview">
                    <tr>
                        <th class="caption" colspan="4" style="width: 20%; height: 26px">
                        <asp:Literal ID="Literal1" runat="server" Text='<%# ResourceHelper.GetFromResource("External User Information")%> '  /></th>
                    </tr>
                    <tr>
                        <th class="FormViewSubHeader" colspan="4" style="width: 20%; height: 26px">
                        <asp:Literal ID="Literal4" runat="server" Text='<%# ResourceHelper.GetFromResource("Personal Information")%> '  /></th>
                    </tr>
                    <tr>
                        <td align="right" class="FormViewLabelCell" style="width: 20%; height: 26px">
                            <asp:Literal ID="Literal23" runat="server" Text='<%# ResourceHelper.GetFromResource("Prefix:")%> '  /></td>
                        <td style="width: 30%; height: 26px" width="40%">
                            <asp:DropDownList ID="ddlPrefix" 
                                            runat="server" DataSourceID="dsSystemNamePrefixObject"
                                DataTextField="SystemNamePrefix" width="188px" DataValueField="SystemNamePrefix" 
                                            SelectedValue='<%# Bind("Prefix") %>'></asp:DropDownList></td>
                        <td class="FormViewLabelCell" style="width: 20%; height: 26px">
                        </td>
                        <td style="width: 30%; height: 26px">
                            &nbsp;</td></tr><tr>
                        <td align="right" class="FormViewLabelCell" style="width: 20%; height: 26px">
                            <span class="reqasterisk">*</span> <asp:Literal ID="Literal11" runat="server" Text='<%# ResourceHelper.GetFromResource("First Name:")%> '  /></td>
                        <td style="width: 30%; height: 26px" width="40%">
                            <asp:TextBox ID="FirstNameTextBox" 
                                            runat="server" Text='<%# Bind("FirstName") %>'
                                ValidationGroup="Insert" Width="176px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator4"
                                    runat="server" ControlToValidate="FirstNameTextBox" CssClass="ErrorMessage" Display="Dynamic"
                                    ErrorMessage="*" ValidationGroup="Insert" Width="1px"></asp:RequiredFieldValidator></td><td align="right" class="FormViewLabelCell" style="width: 20%; height: 26px">
                            
<asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="MiddleNameTextBox">
                            <asp:Literal ID="Literal12" runat="server" Text='<%# ResourceHelper.GetFromResource("Middle Name:")%> '  /></asp:Label></td><td style="width: 30%; height: 26px">
                            <asp:TextBox 
                                            ID="MiddleNameTextBox" runat="server" Text='<%# Bind("MiddleName") %>' 
                                            Width="176px"></asp:TextBox></td></tr><tr>
                        <td align="right" class="FormViewLabelCell" style="width: 20%; height: 26px">
                           
<asp:Label ID="Label7" runat="server" AssociatedControlID="LastNameTextBox">
                            <span class="reqasterisk">*</span> <asp:Literal ID="Literal13" runat="server" Text='<%# ResourceHelper.GetFromResource("Last Name:")%> ' /></asp:Label></td><td style="width: 30%; height: 26px" width="40%">
                            <asp:TextBox 
                                            ID="LastNameTextBox" runat="server" Text='<%# Bind("LastName") %>' 
                                            ValidationGroup="Insert" Width="176px"></asp:TextBox><asp:RequiredFieldValidator
                                ID="RequiredFieldValidator5" runat="server" ControlToValidate="LastNameTextBox"
                                CssClass="ErrorMessage" Display="Dynamic" ErrorMessage="*" ValidationGroup="Insert"
                                Width="1px"></asp:RequiredFieldValidator></td><td align="right" class="FormViewLabelCell" style="width: 20%; height: 26px">
                            
                        <span 
                                            class="reqasterisk">*</span> <asp:Literal ID="Literal14" runat="server" 
                                            Text='<%# ResourceHelper.GetFromResource("External User Client:")%> ' /></td>
                        <td style="width: 30%; height: 26px">
                        <asp:DropDownList ID="ddlExternalUserClientId" 
                                            runat="server" DataSourceID="dsClientObjectInsert" DataTextField="PartyName" 
                                            DataValueField="AccountPartyId" 
                                            SelectedValue='<%# Bind("ExternalUserClientId") %>' Width="188px"></asp:DropDownList><asp:RequiredFieldValidator 
                                            ID="RequiredFieldValidator1" runat="server" 
                                            ControlToValidate="ddlExternalUserClientId" CssClass="ErrorMessage" 
                                            Display="Dynamic" ErrorMessage="*" ValidationGroup="Insert" Width="1px"></asp:RequiredFieldValidator></td></tr><tr>
                        <td align="right" class="FormViewLabelCell" style="width: 20%; height: 26px">
                            <asp:Literal ID="Literal26" runat="server" Text='<%# ResourceHelper.GetFromResource("TimeZone:")%> '  /></td><td colspan="3" style="height: 26px">
                            <asp:DropDownList 
                                            ID="ddlTimeZoneId" runat="server" DataSourceID="dsTimeZone" DataTextField="TimeZoneName"
                                DataValueField="SystemTimeZoneId" Width="350px" 
                                            SelectedValue='<%# Bind("TimeZoneId") %>'></asp:DropDownList></td>
                    </tr>
                    <tr>
                        <th class="FormViewSubHeader" colspan="4" style="width: 20%; height: 26px">
                            <asp:Literal ID="Literal15" runat="server" Text='<%# ResourceHelper.GetFromResource("Login")%> '  /></th>
                    </tr>
                    <tr>
                        <td align="right" class="FormViewLabelCell" style="width: 20%; height: 26px">
                            <asp:Label 
                                            ID="Label9" runat="server" AssociatedControlID="EMailAddressTextBox">
                            <span class="reqasterisk">* </span><asp:Literal 
                ID="Literal16" runat="server" 
                Text='<%# ResourceHelper.GetFromResource("Login Email Address:")%> '  /></asp:Label></td><td style="width: 30%; height: 26px" width="40%">
                            <asp:TextBox 
                                            ID="EMailAddressTextBox" runat="server" Text='<%# Bind("EMailAddress") %>' 
                                            ValidationGroup="Insert" Width="176px"></asp:TextBox><asp:RequiredFieldValidator 
                                            ID="RequiredFieldValidator7" runat="server" 
                                            ControlToValidate="EMailAddressTextBox" CssClass="ErrorMessage" 
                                            Display="Dynamic" ErrorMessage="*" ValidationGroup="Insert" Width="8px"></asp:RequiredFieldValidator><asp:RegularExpressionValidator 
                                            ID="RegularExpressionValidator1" runat="server" 
                                            ControlToValidate="EMailAddressTextBox" CssClass="ErrorMessage" 
                                            Display="Dynamic" ErrorMessage="Incorrect EMail Address" Font-Bold="True" 
                                            Font-Names="Verdana" Font-Size="X-Small" 
                                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                                            ValidationGroup="Insert"></asp:RegularExpressionValidator><asp:Label 
                                            ID="lblExceptionText" runat="server" CssClass="ErrorMessage" 
                                            Text="Login Already Exist" Visible="False"></asp:Label></td><td align="right" class="FormViewLabelCell" colspan="1" style="width: 20%; height: 26px"
                            >
                            &nbsp;</td><td colspan="1" style="width: 30%; height: 26px" >
                            <asp:DropDownList 
                                            ID="ddlAccountRoleId" runat="server" DataSourceID="dsAccountRoleObject" 
                                            DataTextField="Role" DataValueField="AccountRoleId" 
                                            SelectedValue='<%# Bind("AccountRoleId") %>' Width="188px" Visible="False"></asp:DropDownList></td></tr><tr><td 
                                        align="right" class="FormViewLabelCell" style="width: 20%; height: 26px"><span 
                                        class="reqasterisk">*</span> <asp:Literal ID="Literal19" runat="server" 
                                        Text='<%# ResourceHelper.GetFromResource("Password:")%> ' /></td><td 
                                        style="width: 30%; height: 26px" width="40%"><asp:TextBox ID="PasswordTextBox" 
                                            runat="server" Text='<%# Bind("Password") %>' TextMode="Password" 
                                            ValidationGroup="Insert" Width="176px"></asp:TextBox><asp:RequiredFieldValidator 
                                            ID="RequiredFieldValidator2" runat="server" ControlToValidate="PasswordTextBox" 
                                            CssClass="ErrorMessage" Display="Dynamic" ErrorMessage="*" 
                                            ValidationGroup="Insert" Width="16px"></asp:RequiredFieldValidator><asp:RegularExpressionValidator 
                                            ID="RegularExpressionValidator2" runat="server" 
                                            ControlToValidate="PasswordTextBox" Display="Dynamic" 
                                            SkinID="PasswordValidator" 
                                            ValidationExpression="(?=^.{8,}$)(?=.*\d)(?=.*\W+)(?![.\n]).*$" 
                                            ValidationGroup="Insert"></asp:RegularExpressionValidator></td><td 
                                        align="right" class="FormViewLabelCell" colspan="1" 
                                        style="width: 20%; height: 26px"><span class="reqasterisk">*</span><asp:Literal 
                                            ID="Literal17" runat="server" 
                                            Text='<%# ResourceHelper.GetFromResource("Verify Password:")%> ' /></td><td 
                                        colspan="1" style="width: 30%; height: 26px"><asp:TextBox 
                                            ID="VerifyPasswordTextbox" runat="server" TextMode="Password" 
                                            ValidationGroup="Insert" Width="176px"></asp:TextBox><asp:RequiredFieldValidator 
                                            ID="RequiredFieldValidator3" runat="server" 
                                            ControlToValidate="VerifyPasswordTextbox" CssClass="ErrorMessage" 
                                            Display="Dynamic" ErrorMessage="*" ValidationGroup="Insert"></asp:RequiredFieldValidator><asp:CompareValidator 
                                            ID="CompareValidator1" runat="server" ControlToCompare="VerifyPasswordTextbox" 
                                            ControlToValidate="PasswordTextBox" CssClass="ErrorMessage" 
                                            ErrorMessage="(Mismatch)" ValidationGroup="Insert"></asp:CompareValidator></td></tr><tr>
                        <td class="FormViewLabelCell" colspan="3" style="width: 20%; height: 26px">
                            &nbsp;</td><td align="left" class="formviewlabelcell" 
                                        style="padding-bottom: 5px; padding-top: 5px;" ><asp:Button ID="Add" runat="server" CommandName="Insert" Text="<%$ Resources:TimeLive.Resource, Add_text%> " ValidationGroup="Insert"
                                Width="68px" />
                                <asp:Button ID="Cancel" runat="server" CommandName="Cancel" 
                                            onclick="Cancel_Click" Text="Cancel" ValidationGroup="Cancel" Width="68px" /></td>
                    </tr>
                </table>
            </InsertItemTemplate>
            <ItemTemplate>
                AccountEmployeeId: <asp:Label ID="AccountEmployeeIdLabel" runat="server" Text='<%# Eval("AccountEmployeeId") %>'>
                </asp:Label><br />Login: <asp:Label ID="LoginLabel" runat="server" Text='<%# Bind("Login") %>'></asp:Label><br />Password: <asp:Label ID="PasswordLabel" runat="server" Text='<%# Bind("Password") %>'></asp:Label><br />FirstName: <asp:Label ID="FirstNameLabel" runat="server" Text='<%# Bind("FirstName") %>'></asp:Label><br />LastName: <asp:Label ID="LastNameLabel" runat="server" Text='<%# Bind("LastName") %>'></asp:Label><br />MiddleName: <asp:Label ID="MiddleNameLabel" runat="server" Text='<%# Bind("MiddleName") %>'>
                </asp:Label><br />EMailAddress: <asp:Label ID="EMailAddressLabel" runat="server" Text='<%# Bind("EMailAddress") %>'>
                </asp:Label><br />AccountId: <asp:Label ID="AccountIdLabel" runat="server" Text='<%# Bind("AccountId") %>'></asp:Label><br />AccountDepartmentId: <asp:Label ID="AccountDepartmentIdLabel" runat="server" Text='<%# Bind("AccountDepartmentId") %>'>
                </asp:Label><br />AccountRoleId: <asp:Label ID="AccountRoleIdLabel" runat="server" Text='<%# Bind("AccountRoleId") %>'>
                </asp:Label><br />AddressLine1: <asp:Label ID="AddressLine1Label" runat="server" Text='<%# Bind("AddressLine1") %>'>
                </asp:Label><br />AddressLine2: <asp:Label ID="AddressLine2Label" runat="server" Text='<%# Bind("AddressLine2") %>'>
                </asp:Label><br />State: <asp:Label ID="StateLabel" runat="server" Text='<%# Bind("State") %>'></asp:Label><br />City: <asp:Label ID="CityLabel" runat="server" Text='<%# Bind("City") %>'></asp:Label><br />Zip: <asp:Label ID="ZipLabel" runat="server" Text='<%# Bind("Zip") %>'></asp:Label><br />CountryId: <asp:Label ID="CountryIdLabel" runat="server" Text='<%# Bind("CountryId") %>'></asp:Label><br />HomePhoneNo: <asp:Label ID="HomePhoneNoLabel" runat="server" Text='<%# Bind("HomePhoneNo") %>'>
                </asp:Label><br />WorkPhoneNo: <asp:Label ID="WorkPhoneNoLabel" runat="server" Text='<%# Bind("WorkPhoneNo") %>'>
                </asp:Label><br />MobilePhoneNo: <asp:Label ID="MobilePhoneNoLabel" runat="server" Text='<%# Bind("MobilePhoneNo") %>'>
                </asp:Label><br />BillingRateCurrencyId: <asp:Label ID="BillingRateCurrencyIdLabel" runat="server" Text='<%# Bind("BillingRateCurrencyId") %>'>
                </asp:Label><br />BillingRate: <asp:Label ID="BillingRateLabel" runat="server" Text='<%# Bind("BillingRate") %>'>
                </asp:Label><br />StartDate: <asp:Label ID="StartDateLabel" runat="server" Text='<%# Bind("StartDate") %>'></asp:Label><br />TerminationDate: <asp:Label ID="TerminationDateLabel" runat="server" Text='<%# Bind("TerminationDate") %>'>
                </asp:Label><br />StatusId: <asp:Label ID="StatusIdLabel" runat="server" Text='<%# Bind("StatusId") %>'></asp:Label><br />IsDeleted: <asp:CheckBox ID="IsDeletedCheckBox" runat="server" Checked='<%# Bind("IsDeleted") %>'
                    Enabled="false" /><br />
                IsDisabled: <asp:CheckBox ID="IsDisabledCheckBox" runat="server" Checked='<%# Bind("IsDisabled") %>'
                    Enabled="false" /><br />
                DefaultProjectId: <asp:Label ID="DefaultProjectIdLabel" runat="server" Text='<%# Bind("DefaultProjectId") %>'>
                </asp:Label><br />TimeZoneId: <asp:Label ID="TimeZoneIdLabel" runat="server" Text='<%# Bind("TimeZoneId") %>'>
                </asp:Label><br />State1: <asp:Label ID="State1Label" runat="server" Text='<%# Bind("State1") %>'></asp:Label><br />Prefix: <asp:Label ID="PrefixLabel" runat="server" Text='<%# Bind("Prefix") %>'></asp:Label><br />BillingRateStartDate: <asp:Label ID="BillingRateStartDateLabel" runat="server" Text='<%# Bind("BillingRateStartDate") %>'>
                </asp:Label><br /><asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" CommandName="Edit"
                    Text="Edit">
                </asp:LinkButton><asp:LinkButton ID="DeleteButton" runat="server" CausesValidation="False" CommandName="Delete"
                    Text="Delete">
                </asp:LinkButton><asp:LinkButton ID="NewButton" runat="server" CausesValidation="False" CommandName="New"
                    Text="New">
                </asp:LinkButton></ItemTemplate></asp:FormView><asp:ObjectDataSource ID="dsAccountEmployeeObject" runat="server" DeleteMethod="DeleteAccountEmployee"
            InsertMethod="AddAccountEmployee" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetAccountEmployees" TypeName="AccountEmployeeBLL" UpdateMethod="UpdateAccountEmployee">
            <InsertParameters>
                <asp:Parameter Name="Password" Type="String" />
                <asp:Parameter Name="FirstName" Type="String" />
                <asp:Parameter Name="LastName" Type="String" />
                <asp:Parameter Name="EMailAddress" Type="String" />
                <asp:Parameter Name="AccountId" Type="Int32" />
                <asp:Parameter Name="AccountDepartmentId" Type="Int32" />
                <asp:Parameter Name="AccountRoleId" Type="Int32" />
                <asp:Parameter Name="AccountLocationId" Type="Int32" />
                <asp:Parameter Name="CountryId" Type="Int16" />
                <asp:Parameter Name="BillingRateCurrencyId" Type="Int16" />
                <asp:Parameter Name="BillingTypeId" Type="Int32" />
                <asp:Parameter Name="BillingRate" Type="Decimal" />
                <asp:Parameter Name="BillingRateStartDate" Type="DateTime" />
                <asp:Parameter Name="StartDate" Type="DateTime" />
                <asp:Parameter Name="DefaultProjectId" Type="Int32" />
                <asp:Parameter Name="TimeZoneId" Type="Byte" />
                <asp:Parameter Name="CreatedByEmployeeId" Type="Int32" />
                <asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" />
                <asp:Parameter Name="AddressLine1" Type="String" />
                <asp:Parameter Name="AddressLine2" Type="String" />
                <asp:Parameter Name="State" Type="String" />
                <asp:Parameter Name="City" Type="String" />
                <asp:Parameter Name="Zip" Type="String" />
                <asp:Parameter Name="HomePhoneNo" Type="String" />
                <asp:Parameter Name="WorkPhoneNo" Type="String" />
                <asp:Parameter Name="MobilePhoneNo" Type="String" />
                <asp:Parameter Name="MiddleName" Type="String" />
                <asp:Parameter Name="Prefix" Type="String" />
                <asp:Parameter Name="DoNotSendEMail" Type="Boolean" />
            </InsertParameters>
            <DeleteParameters>
                <asp:Parameter Name="Original_AccountEmployeeId" Type="Int32" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="Login" Type="String" />
                <asp:Parameter Name="Password" Type="String" />
                <asp:Parameter Name="Prefix" Type="String" />
                <asp:Parameter Name="FirstName" Type="String" />
                <asp:Parameter Name="LastName" Type="String" />
                <asp:Parameter Name="MiddleName" Type="String" />
                <asp:Parameter Name="EMailAddress" Type="String" />
                <asp:Parameter Name="AccountId" Type="Int32" />
                <asp:Parameter Name="AccountDepartmentId" Type="Int32" />
                <asp:Parameter Name="AccountRoleId" Type="Int32" />
                <asp:Parameter Name="AccountLocationId" Type="Int32" />
                <asp:Parameter Name="AddressLine1" Type="String" />
                <asp:Parameter Name="AddressLine2" Type="String" />
                <asp:Parameter Name="State" Type="String" />
                <asp:Parameter Name="City" Type="String" />
                <asp:Parameter Name="Zip" Type="String" />
                <asp:Parameter Name="CountryId" Type="Int16" />
                <asp:Parameter Name="HomePhoneNo" Type="String" />
                <asp:Parameter Name="WorkPhoneNo" Type="String" />
                <asp:Parameter Name="MobilePhoneNo" Type="String" />
                <asp:Parameter Name="BillingRateCurrencyId" Type="Int16" />
                <asp:Parameter Name="BillingTypeId" Type="Int32" />
                <asp:Parameter Name="BillingRate" Type="Decimal" />
                <asp:Parameter Name="BillingRateStartDate" Type="DateTime" />
                <asp:Parameter Name="StartDate" Type="DateTime" />
                <asp:Parameter Name="TerminationDate" Type="DateTime" />
                <asp:Parameter Name="StatusId" Type="Byte" />
                <asp:Parameter Name="IsDeleted" Type="Boolean" />
                <asp:Parameter Name="IsDisabled" Type="Boolean" />
                <asp:Parameter Name="DefaultProjectId" Type="Int32" />
                <asp:Parameter Name="TimeZoneId" Type="Byte" />
                <asp:Parameter Name="CreatedByEmployeeId" Type="Int32" />
                <asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" />
                <asp:Parameter Name="AllowedAccessFromIP" Type="String" />
                <asp:Parameter Name="Original_AccountEmployeeId" Type="Int32" />
            </UpdateParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="dsSystemCurrencyObject" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetCurrencies" TypeName="SystemDataBLL"></asp:ObjectDataSource>
        <asp:ObjectDataSource ID="dsClientObject" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetAccountPartiesByAccountIdAndAccountPartyId" TypeName="AccountPartyBLL">
            <SelectParameters>
                <asp:SessionParameter DefaultValue="64" Name="AccountId" SessionField="AccountId"
                    Type="Int32" />
                <asp:Parameter Name="AccountPartyId" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource><asp:ObjectDataSource ID="dsClientObjectInsert" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetAccountPartiesByAccountIdAndAccountPartyId" TypeName="AccountPartyBLL" DeleteMethod="DeleteAccountParty" InsertMethod="AddAccountParty" UpdateMethod="UpdateAccountParty">
            <DeleteParameters>
                <asp:Parameter Name="original_AccountPartyId" Type="Int32" />
            </DeleteParameters>
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
                <asp:Parameter Name="DefaultCurrencyId" Type="Int16" />
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
            </UpdateParameters>
            <SelectParameters>
                <asp:SessionParameter DefaultValue="64" Name="AccountId" SessionField="AccountId"
                    Type="Int32" />
                <asp:Parameter Name="AccountPartyId" Type="Int32" DefaultValue="0" />
            </SelectParameters>
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
                <asp:Parameter Name="DefaultCurrencyId" Type="Int16" />
                <asp:Parameter Name="DefaultBillingRate" Type="Decimal" />
                <asp:Parameter Name="Website" Type="String" />
                <asp:Parameter Name="Notes" Type="String" />
                <asp:Parameter Name="IsDisabled" Type="Boolean" />
                <asp:Parameter Name="IsDeleted" Type="Boolean" />
                <asp:Parameter Name="CreatedOn" Type="DateTime" />
                <asp:Parameter Name="CreatedByEmployeeId" Type="Int32" />
                <asp:Parameter Name="ModifiedOn" Type="DateTime" />
                <asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" />
            </InsertParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="dsAccountDepartmentObject" runat="server" DeleteMethod="DeleteAccountDepartment"
            InsertMethod="AddAccountDepartment" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetAccountDepartmentsByAccountId" TypeName="AccountDepartmentBLL"
            UpdateMethod="UpdateAccountDepartment">
            <SelectParameters>
                <asp:SessionParameter DefaultValue="64" Name="AccountId" SessionField="AccountId"
                    Type="Int32" />
            </SelectParameters>
            <DeleteParameters>
                <asp:Parameter Name="Original_AccountDepartmentId" Type="Int32" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="AccountId" Type="Int32" />
                <asp:Parameter Name="DepartmentCode" Type="String" />
                <asp:Parameter Name="DepartmentName" Type="String" />
                <asp:Parameter Name="original_AccountDepartmentId" Type="Int32" />
                <asp:Parameter Name="IsDisabled" Type="Boolean" />
                <asp:Parameter Name="IsDeleted" Type="Boolean" />
                <asp:Parameter Name="CreatedOn" Type="DateTime" />
                <asp:Parameter Name="ModifiedOn" Type="DateTime" />
                <asp:Parameter Name="CreatedByEmployeeId" Type="Int32" />
                <asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" />
            </UpdateParameters>
            <InsertParameters>
                <asp:Parameter Name="AccountId" Type="Int32" />
                <asp:Parameter Name="DepartmentCode" Type="String" />
                <asp:Parameter Name="DepartmentName" Type="String" />
                <asp:Parameter Name="CreatedByEmployeeId" Type="Int32" />
                <asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" />
            </InsertParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="dsSystemNamePrefixObject" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetNamePrefix" TypeName="SystemDataBLL"></asp:ObjectDataSource>
        <asp:ObjectDataSource ID="dsAccountRoleObject" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetAccountRoleForExternalUser" TypeName="AccountRoleBLL">
            <SelectParameters>
                <asp:SessionParameter Name="AccountId" SessionField="AccountId" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="dsSystemCountryObject" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetCountries" TypeName="SystemDataBLL"></asp:ObjectDataSource>
        <asp:ObjectDataSource ID="dsTimeZone" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetTimeZones" TypeName="SystemDataBLL"></asp:ObjectDataSource>
        <asp:ObjectDataSource ID="dsProjectObject" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetAccountProjectsByAccountProjectId" TypeName="AccountProjectBLL">
            <SelectParameters>
                <asp:Parameter DefaultValue="3" Name="AccountProjectId" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="dsAccountLocation" runat="server" DeleteMethod="DeleteAccountLocation"
            InsertMethod="AddAccountLocation" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetAccountLocationsByAccountId" TypeName="AccountLocationBLL" UpdateMethod="UpdateAccountLocation">
            <SelectParameters>
                <asp:SessionParameter DefaultValue="64" Name="AccountId" SessionField="AccountId"
                    Type="Int32" />
            </SelectParameters>
            <DeleteParameters>
                <asp:Parameter Name="original_AccountLocationId" Type="Int32" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="AccountId" Type="Int32" />
                <asp:Parameter Name="AccountLocation" Type="String" />
                <asp:Parameter Name="original_AccountLocationId" Type="Int32" />
                <asp:Parameter Name="ModifiedOn" Type="DateTime" />
                <asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" />
                <asp:Parameter Name="IsDisabled" Type="Boolean" />
            </UpdateParameters>
            <InsertParameters>
                <asp:Parameter Name="AccountId" Type="Int32" />
                <asp:Parameter Name="AccountLocation" Type="String" />
                <asp:Parameter Name="CreatedByEmployeeId" Type="Int32" />
                <asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" />
            </InsertParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="dsAccountBillingTypeObject" runat="server" DeleteMethod="DeleteAccountBillingType"
            InsertMethod="AddAccountBillingType" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetAccountBillingTypesForEmployeeByAccountId" TypeName="AccountBillingTypeBLL"
            UpdateMethod="UpdateAccountBillingType">
            <SelectParameters>
                <asp:SessionParameter DefaultValue="64" Name="AccountId" SessionField="AccountId"
                    Type="Int32" />
            </SelectParameters>
            <DeleteParameters>
                <asp:Parameter Name="Original_AccountBillingTypeId" Type="Int32" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="AccountId" Type="Int32" />
                <asp:Parameter Name="BillingType" Type="String" />
                <asp:Parameter Name="BillingCategoryId" Type="Int32" />
                <asp:Parameter Name="Original_AccountBillingTypeId" Type="Int32" />
                <asp:Parameter Name="CreatedOn" Type="DateTime" />
                <asp:Parameter Name="CreatedByEmployeeId" Type="Int32" />
                <asp:Parameter Name="ModifiedOn" Type="DateTime" />
                <asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" />
            </UpdateParameters>
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
    </ContentTemplate>
</asp:UpdatePanel>
