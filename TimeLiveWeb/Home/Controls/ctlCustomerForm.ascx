<%@ Control Language="vb" AutoEventWireup="false" Inherits="TimeLive.ctlCustomerForm" CodeFile="ctlCustomerForm.ascx.vb" %>

<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<br /><br />    
<asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate>
<asp:FormView id="FormView1" DefaultMode="Insert" DataSourceID="dsCustomer" DataKeyNames="AccountId" runat="server" Width="640px" HorizontalAlign=Center>
        <EditItemTemplate><table border="0" cellpadding="2" cellspacing="1" style="width: 100%; height: 31%; border-right: black 1px solid; border-top: black 1px solid; border-left: black 1px solid; border-bottom: black 1px solid;">
            <tr>
                <th class="FormViewHeader" colspan="2" style="height: 22px" width="30%" align="left">
                    Provide your information</th>
            </tr>
            <tr>
                <th class="FormViewSubHeader" colspan="2" style="height: 22px" width="30%" align="left">
                    Account Information</th>
            </tr>
            <tr>
                <td style="height: 22px; width: 30%;" class="FormViewLabelCell" align="right">
                    <SPAN 
                  class=reqasterisk>*</span> Account Name:
                </td>
                <td style="width: 70%; height: 22px;">
                    <asp:TextBox ID="AccountName" runat="server" Text='<%# Bind("AccountName") %>' Width="264px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="AccountName"
                        Display="Dynamic" ErrorMessage="*" Width="1px" CssClass="ErrorMessage"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="height: 19px; width: 30%;" class="FormViewLabelCell" align="right">
                    <SPAN 
                  class=reqasterisk>*</span> Email Address:</td>
                <td style="width: 70%; height: 19px">
                    <asp:TextBox ID="EMailAddressTextBox" runat="server" Text='<%# Bind("EMailAddress") %>'
                        Width="208px"></asp:TextBox>&nbsp;
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="EMailAddressTextBox"
                        CssClass="ErrorMessage" ErrorMessage="Invalid EMail Address" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator></td>
            </tr>
            <tr style="color: #000000">
                <td style="height: 23px; width: 30%;" class="FormViewLabelCell" align="right">
                    Address1:</td>
                <td style="width: 70%; height: 23px;">
                    <asp:TextBox ID="Address1TextBox" runat="server" Text='<%# Bind("Address1") %>' Width="232px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="height: 24px; width: 30%;" class="FormViewLabelCell" align="right">
                    Address2:</td>
                <td style="width: 70%; height: 24px;">
                    <asp:TextBox ID="Address2TextBox" runat="server" Text='<%# Bind("Address2") %>' Width="232px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="height: 24px; width: 30%;" class="FormViewLabelCell" align="right">
                    Zip Code:
                </td>
                <td style="width: 70%; height: 24px;">
                    <asp:TextBox ID="ZipCodeTextBox" runat="server" Text='<%# Bind("ZipCode") %>' Width="72px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="height: 22px; width: 30%;" class="FormViewLabelCell" align="right">
                    City:</td>
                <td style="width: 70%; height: 22px">
                    <asp:TextBox ID="CityTextBox" runat="server" Text='<%# Bind("City") %>'></asp:TextBox></td>
            </tr>
            <tr>
                <td style="height: 22px; width: 30%;" class="FormViewLabelCell" align="right">
                    <SPAN 
                  class=reqasterisk>*</span> Country:
                </td>
                <td style="width: 70%; height: 22px">
                    <asp:DropDownList ID="DropDownList3" runat="server" DataSourceID="dsCountryObject"
                DataTextField="Country" DataValueField="CountryId"  SelectedValue='<%# Bind("CountryId") %>' Width="152px" >
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="height: 21px; width: 30%;" class="FormViewLabelCell" align="right">
                    Telephone:</td>
                <td style="width: 70%; height: 21px">
                    <asp:TextBox ID="TelephoneTextBox" runat="server" Text='<%# Bind("Telephone") %>'></asp:TextBox></td>
            </tr>
            <tr>
                <td style="height: 22px; width: 30%;" class="FormViewLabelCell" align="right">
                    Fax</td>
                <td style="width: 70%; height: 22px">
                    <asp:TextBox ID="FaxTextBox" runat="server" Text='<%# Bind("Fax") %>'></asp:TextBox></td>
            </tr>
            <tr>
                <td style="height: 22px; width: 30%;" class="FormViewLabelCell" align="right">
                    Default Currency:</td>
                <td style="width: 70%; height: 22px">
                    <asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="dsCurrencyObject"
                DataTextField="CurrencyCode" DataValueField="CurrencyId"  SelectedValue='<%# Bind("DefaultCurrencyId") %>' Width="152px" >
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="right" class="FormViewLabelCell" style="width: 30%; height: 22px">
                    Time Zone:</td>
                <td style="width: 70%; height: 22px">
                    <asp:DropDownList ID="ddlTimeZoneId" runat="server" DataSourceID="dsTimeZone"
                DataTextField="TimeZoneName" DataValueField="SystemTimeZoneId"  SelectedValue='<%# Bind("TimeZoneId") %>' Width="368px" >
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td align="right" class="FormViewLabelCell" style="width: 30%; height: 22px">
                    Show Clock Start/End:</td>
                <td style="width: 70%; height: 22px">
                    <asp:CheckBox ID="chkShowClockStartEnd" runat="server" Checked='<%# Bind("ShowClockStartEnd") %>' /></td>
            </tr>
            <tr>
                <td align="right" class="FormViewLabelCell" style="width: 30%; height: 22px">
                    License Keys:</td>
                <td style="width: 70%; height: 22px">
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("LicenseKey") %>' Width="304px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="height: 22px; width: 30%;" align="right">
                </td>
                <td style="width: 70%; height: 22px">
                    <asp:Button ID="Button1" runat="server"  Text="Update" CommandName="Update"  /></td>
            </tr>
        </table>

        </EditItemTemplate>
        <InsertItemTemplate>
            <table border="0" cellpadding="2" cellspacing="1" style="width: 100%; height: 31%; border-right: black 1px solid; border-top: black 1px solid; border-left: black 1px solid; border-bottom: black 1px solid;">
                <tr>
                    <th class="FormViewHeader" colspan="2" style="height: 22px" width="30%" align="left">
                        Provide your information</th>
                </tr>
               <tr>
                <th class="FormViewSubHeader" colspan="2" style="height: 22px" width="30%" align="left">
                    Account Information</th>
            </tr>
                <tr>
                    <td align="right" class="FormViewLabelCell" style="height: 22px" width="30%">
                        * Product:</td>
                    <td style="width: 70%; height: 22px">
                        <asp:DropDownList ID="ddlCustomerRequestTypeId" runat="server" DataSourceID="dsCustomerRequestType"
                DataTextField="CustomerRequestType" DataValueField="CustomerRequestTypeId"  SelectedValue='<%# Bind("CustomerRequestTypeId") %>' Width="328px" >
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="height: 22px;" class="FormViewLabelCell" width="30%" align="right">
                        <SPAN 
                  class=reqasterisk>*</SPAN> Organization Name:
                    </td>
                    <td style="width: 70%; height: 22px;">
                  <asp:TextBox id="AccountName" runat="server" Text='<%# Bind("CustomerName") %>' Width="264px" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="AccountName"
                            Display="Dynamic" ErrorMessage="*" Width="1px"></asp:RequiredFieldValidator>
                        </td>
                </tr>
                <tr>
                    <td style="height: 23px;" class="FormViewLabelCell" width="30%" align="right">
                        Address1:</td>
                    <td style="width: 70%; height: 23px;">
            <asp:TextBox ID="Address1TextBox" runat="server" Text='<%# Bind("Address1") %>' Width="232px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="height: 24px;" class="FormViewLabelCell" width="30%" align="right">
                        Address2:</td>
                    <td style="width: 70%; height: 24px;">
            <asp:TextBox ID="Address2TextBox" runat="server" Text='<%# Bind("Address2") %>' Width="232px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="height: 24px;" class="FormViewLabelCell" width="30%" align="right">
                        Zip Code:
                    </td>
                    <td style="width: 70%; height: 24px;">
            <asp:TextBox ID="ZipCodeTextBox" runat="server" Text='<%# Bind("ZipCode") %>' Width="72px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td align="right" class="FormViewLabelCell" style="height: 22px" width="30%">
                        State:
                    </td>
                    <td style="width: 70%; height: 22px">
                        <asp:TextBox ID="StateTextBox" runat="server" Text='<%# Bind("State") %>'></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="height: 22px" class="FormViewLabelCell" width="30%" align="right">
                        City:</td>
                    <td style="width: 70%; height: 22px">
            <asp:TextBox ID="CityTextBox" runat="server" Text='<%# Bind("City") %>'></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="height: 22px" class="FormViewLabelCell" width="30%" align="right">
                        <SPAN 
                  class=reqasterisk>*</SPAN>
                        Country:
                    </td>
                    <td style="width: 70%; height: 22px"><asp:DropDownList ID="ddlCountryId" runat="server" DataSourceID="dsCountryObject"
                DataTextField="Country" DataValueField="CountryId"  SelectedValue='<%# Bind("CountryId") %>' Width="152px" >
                    </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="height: 20px" class="FormViewLabelCell" width="30%" align="right">
                        Telephone:</td>
                    <td style="width: 70%; height: 20px">
            <asp:TextBox ID="TelephoneTextBox" runat="server" Text='<%# Bind("Telephone") %>'></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="height: 22px" class="FormViewLabelCell" width="30%" align="right">
                        Fax</td>
                    <td style="width: 70%; height: 22px">
            <asp:TextBox ID="FaxTextBox" runat="server" Text='<%# Bind("Fax") %>'></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="height: 22px" class="FormViewLabelCell" width="30%" align="right">
                        Prefix:
                    </td>
                    <td style="width: 70%; height: 22px">
                        <asp:DropDownList ID="DropDownList6" runat="server" DataSourceID="dsSystemNamePrefixObject"
                            DataTextField="SystemNamePrefix" DataValueField="SystemNamePrefix" SelectedValue='<%# Bind("Prefix") %>'>
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td style="height: 22px" class="FormViewLabelCell" width="30%" align="right">
                        <SPAN 
                  class=reqasterisk>*</SPAN>
                        First Name:
                    </td>
                    <td style="width: 70%; height: 22px">
                        <asp:TextBox ID="FirstNameTextBox" runat="server" Text='<%# Bind("FirstName") %>' Width="184px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="FirstNameTextBox"
                            Display="Dynamic" ErrorMessage="*" Width="1px"></asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td style="height: 22px" class="FormViewLabelCell" width="30%" align="right">
                        Middle Name:
                    </td>
                    <td style="width: 70%; height: 22px">
                        <asp:TextBox ID="MiddleNameTextBox" runat="server" Text='<%# Bind("MiddleName") %>' ></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="height: 22px" class="FormViewLabelCell" width="30%" align="right">
                        <SPAN 
                  class=reqasterisk>*</SPAN>
                        Last Name:</td>
                    <td style="width: 70%; height: 22px">
                        <asp:TextBox ID="LastNameTextBox" runat="server" Text='<%# Bind("LastName") %>' Width="184px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="LastNameTextBox"
                            Display="Dynamic" ErrorMessage="*" Width="1px"></asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td style="height: 22px" class="FormViewLabelCell" width="30%" align="right">
                        <SPAN 
                  class=reqasterisk>*</SPAN>
                        Email Address:</td>
                    <td style="width: 70%; height: 22px">
                        <asp:TextBox ID="EmployeeEMailAddress" runat="server" Text='<%# Bind("EMailAddress") %>'
                            Width="200px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="EmployeeEMailAddress"
                            Display="Dynamic" ErrorMessage="*" Width="1px"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="EmployeeEMailAddress"
                            CssClass="ErrorMessage" ErrorMessage="Invalid EMail Address" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator></td>
                </tr>
                <tr>
                    <td style="height: 22px" width="30%" align="right">
                    </td>
                    <td style="width: 70%; height: 22px">
                        <asp:Button ID="Button1" runat="server"  Text="Signup" CommandName="Insert"  /></td>
                </tr>
            </table>
        </InsertItemTemplate>
        <ItemTemplate>
            AccountId:
            <asp:Label ID="AccountIdLabel" runat="server" Text='<%# Eval("AccountId") %>'></asp:Label><br  />
            AccountTypeId:
            <asp:Label ID="AccountTypeIdLabel" runat="server" Text='<%# Bind("AccountTypeId") %>'>
            </asp:Label><br  />
            AccountLogin:
            <asp:Label ID="AccountLoginLabel" runat="server" Text='<%# Bind("AccountLogin") %>'>
            </asp:Label><br  />
            AccountName:
            <asp:Label ID="AccountNameLabel" runat="server" Text='<%# Bind("AccountName") %>'>
            </asp:Label><br  />
            Address1:
            <asp:Label ID="Address1Label" runat="server" Text='<%# Bind("Address1") %>'></asp:Label><br  />
            Address2:
            <asp:Label ID="Address2Label" runat="server" Text='<%# Bind("Address2") %>'></asp:Label><br  />
            ZipCode:
            <asp:Label ID="ZipCodeLabel" runat="server" Text='<%# Bind("ZipCode") %>'></asp:Label><br  />
            EMailAddress:
            <asp:Label ID="EMailAddressLabel" runat="server" Text='<%# Bind("EMailAddress") %>'>
            </asp:Label><br  />
            Telephone:
            <asp:Label ID="TelephoneLabel" runat="server" Text='<%# Bind("Telephone") %>'></asp:Label><br  />
            Fax:
            <asp:Label ID="FaxLabel" runat="server" Text='<%# Bind("Fax") %>'></asp:Label><br  />
            DefaultCurrencyId:
            <asp:Label ID="DefaultCurrencyIdLabel" runat="server" Text='<%# Bind("DefaultCurrencyId") %>'>
            </asp:Label><br  />
            IsDisabled:
            <asp:CheckBox ID="IsDisabledCheckBox" runat="server" Checked='<%# Bind("IsDisabled") %>'
                Enabled="false"  /><br  />
            IsDeleted:
            <asp:CheckBox ID="IsDeletedCheckBox" runat="server" Checked='<%# Bind("IsDeleted") %>'
                Enabled="false"  /><br  />
            StatusId:
            <asp:Label ID="StatusIdLabel" runat="server" Text='<%# Bind("StatusId") %>'></asp:Label><br  />
            CreatedOn:
            <asp:Label ID="CreatedOnLabel" runat="server" Text='<%# Bind("CreatedOn") %>'></asp:Label><br  />
            ModifiedOn:
            <asp:Label ID="ModifiedOnLabel" runat="server" Text='<%# Bind("ModifiedOn") %>'>
            </asp:Label><br  />
            City:
            <asp:Label ID="CityLabel" runat="server" Text='<%# Bind("City") %>'></asp:Label><br  />
            CountryId:
            <asp:Label ID="CountryIdLabel" runat="server" Text='<%# Bind("CountryId") %>'></asp:Label><br  />
            <asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" CommandName="Edit"
                Text="Edit">
            </asp:LinkButton>
            <asp:LinkButton ID="DeleteButton" runat="server" CausesValidation="False" CommandName="Delete"
                Text="Delete">
            </asp:LinkButton>
            <asp:LinkButton ID="NewButton" runat="server" CausesValidation="False" CommandName="New"
                Text="New">
            </asp:LinkButton>
        </ItemTemplate>
    </asp:FormView> &nbsp; &nbsp;&nbsp;
    <asp:ObjectDataSource ID="dsCustomerRequestType" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetCustomerRequestType" TypeName="SystemDataBLL"></asp:ObjectDataSource>
    <asp:ObjectDataSource id="dsCountryObject" runat="server" TypeName="SystemDataBLL" SelectMethod="GetCountries" OldValuesParameterFormatString="original_{0}">
    </asp:ObjectDataSource> <asp:ObjectDataSource id="dsCustomer" runat="server" TypeName="LTCustomerBLL" SelectMethod="GetLTCustomerByCustomerId" InsertMethod="AddLTCustomer" OldValuesParameterFormatString="original_{0}">
        <InsertParameters>
            <asp:Parameter Name="AccountId" Type="Int32" />
            <asp:Parameter Name="CustomerName" Type="String" />
            <asp:Parameter Name="Prefix" Type="String" />
            <asp:Parameter Name="FirstName" Type="String" />
            <asp:Parameter Name="MiddleName" Type="String" />
            <asp:Parameter Name="LastName" Type="String" />
            <asp:Parameter Name="Address1" Type="String"  />
            <asp:Parameter Name="Address2" Type="String"  />
            <asp:Parameter Name="ZipCode" Type="String"  />
            <asp:Parameter Name="State" Type="String" />
            <asp:Parameter Name="City" Type="String"  />
            <asp:Parameter Name="CountryId" Type="Int16"  />
            <asp:Parameter Name="EMailAddress" Type="String"  />
            <asp:Parameter Name="Telephone" Type="String"  />
            <asp:Parameter Name="Fax" Type="String"  />
            <asp:Parameter Name="CustomerRequestTypeId" Type="Byte" />
        </InsertParameters>
        <SelectParameters>
            <asp:Parameter Name="CustomerId" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource> &nbsp;
        <asp:ObjectDataSource ID="dsSystemNamePrefixObject" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetNamePrefix" TypeName="SystemDataBLL"></asp:ObjectDataSource>
</ContentTemplate>
</asp:UpdatePanel>
    &nbsp;<p></P>
<p>
    &nbsp; &nbsp;&nbsp;
</p>
<p>
    &nbsp; &nbsp;
</p>
