<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlAccountEmployeeFormShort.ascx.vb" Inherits="Controls_ctlAccountEmployeeFormShort" %>
<asp:FormView ID="FormView1" runat="server" DataKeyNames="AccountEmployeeId" DataSourceID="dsAccountEmployeeObject" DefaultMode="Insert">
    <EditItemTemplate>
        AccountEmployeeId:
        <asp:Label ID="AccountEmployeeIdLabel1" runat="server" Text='<%# Eval("AccountEmployeeId") %>'>
        </asp:Label><br />
        Login:
        <asp:TextBox ID="LoginTextBox" runat="server" Text='<%# Bind("Login") %>'>
        </asp:TextBox><br />
        Password:
        <asp:TextBox ID="PasswordTextBox" runat="server" Text='<%# Bind("Password") %>'>
        </asp:TextBox><br />
        Prefix:
        <asp:TextBox ID="PrefixTextBox" runat="server" Text='<%# Bind("Prefix") %>'>
        </asp:TextBox><br />
        FirstName:
        <asp:TextBox ID="FirstNameTextBox" runat="server" Text='<%# Bind("FirstName") %>'>
        </asp:TextBox><br />
        LastName:
        <asp:TextBox ID="LastNameTextBox" runat="server" Text='<%# Bind("LastName") %>'>
        </asp:TextBox><br />
        MiddleName:
        <asp:TextBox ID="MiddleNameTextBox" runat="server" Text='<%# Bind("MiddleName") %>'>
        </asp:TextBox><br />
        EMailAddress:
        <asp:TextBox ID="EMailAddressTextBox" runat="server" Text='<%# Bind("EMailAddress") %>'>
        </asp:TextBox><br />
        AccountId:
        <asp:TextBox ID="AccountIdTextBox" runat="server" Text='<%# Bind("AccountId") %>'>
        </asp:TextBox><br />
        AccountDepartmentId:
        <asp:TextBox ID="AccountDepartmentIdTextBox" runat="server" Text='<%# Bind("AccountDepartmentId") %>'>
        </asp:TextBox><br />
        AccountRoleId:
        <asp:TextBox ID="AccountRoleIdTextBox" runat="server" Text='<%# Bind("AccountRoleId") %>'>
        </asp:TextBox><br />
        AddressLine1:
        <asp:TextBox ID="AddressLine1TextBox" runat="server" Text='<%# Bind("AddressLine1") %>'>
        </asp:TextBox><br />
        AddressLine2:
        <asp:TextBox ID="AddressLine2TextBox" runat="server" Text='<%# Bind("AddressLine2") %>'>
        </asp:TextBox><br />
        State:
        <asp:TextBox ID="StateTextBox" runat="server" Text='<%# Bind("State") %>'>
        </asp:TextBox><br />
        City:
        <asp:TextBox ID="CityTextBox" runat="server" Text='<%# Bind("City") %>'>
        </asp:TextBox><br />
        Zip:
        <asp:TextBox ID="ZipTextBox" runat="server" Text='<%# Bind("Zip") %>'>
        </asp:TextBox><br />
        CountryId:
        <asp:TextBox ID="CountryIdTextBox" runat="server" Text='<%# Bind("CountryId") %>'>
        </asp:TextBox><br />
        HomePhoneNo:
        <asp:TextBox ID="HomePhoneNoTextBox" runat="server" Text='<%# Bind("HomePhoneNo") %>'>
        </asp:TextBox><br />
        WorkPhoneNo:
        <asp:TextBox ID="WorkPhoneNoTextBox" runat="server" Text='<%# Bind("WorkPhoneNo") %>'>
        </asp:TextBox><br />
        MobilePhoneNo:
        <asp:TextBox ID="MobilePhoneNoTextBox" runat="server" Text='<%# Bind("MobilePhoneNo") %>'>
        </asp:TextBox><br />
        BillingRateCurrencyId:
        <asp:TextBox ID="BillingRateCurrencyIdTextBox" runat="server" Text='<%# Bind("BillingRateCurrencyId") %>'>
        </asp:TextBox><br />
        BillingRate:
        <asp:TextBox ID="BillingRateTextBox" runat="server" Text='<%# Bind("BillingRate") %>'>
        </asp:TextBox><br />
        BillingRateStateDate:
        <asp:TextBox ID="BillingRateStateDateTextBox" runat="server" Text='<%# Bind("BillingRateStateDate") %>'>
        </asp:TextBox><br />
        StartDate:
        <asp:TextBox ID="StartDateTextBox" runat="server" Text='<%# Bind("StartDate") %>'>
        </asp:TextBox><br />
        TerminationDate:
        <asp:TextBox ID="TerminationDateTextBox" runat="server" Text='<%# Bind("TerminationDate") %>'>
        </asp:TextBox><br />
        StatusId:
        <asp:TextBox ID="StatusIdTextBox" runat="server" Text='<%# Bind("StatusId") %>'>
        </asp:TextBox><br />
        IsDeleted:
        <asp:CheckBox ID="IsDeletedCheckBox" runat="server" Checked='<%# Bind("IsDeleted") %>' /><br />
        IsDisabled:
        <asp:CheckBox ID="IsDisabledCheckBox" runat="server" Checked='<%# Bind("IsDisabled") %>' /><br />
        DefaultProjectId:
        <asp:TextBox ID="DefaultProjectIdTextBox" runat="server" Text='<%# Bind("DefaultProjectId") %>'>
        </asp:TextBox><br />
        TimeZoneId:
        <asp:TextBox ID="TimeZoneIdTextBox" runat="server" Text='<%# Bind("TimeZoneId") %>'>
        </asp:TextBox><br />
        <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update"
            Text="Update">
        </asp:LinkButton>
        <asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False" CommandName="Cancel"
            Text="Cancel">
        </asp:LinkButton>
    </EditItemTemplate>
    <InsertItemTemplate>
        <table border="0" cellpadding="0" cellspacing="0" style="width: 92%; height: 2%">
            <tr>
                <td style="width: 115px">
                    Login:</td>
                <td style="width: 201px">
                    <asp:TextBox ID="LoginTextBox" runat="server" Text='<%# Bind("Login") %>'></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 115px">
                    Password:</td>
                <td style="width: 201px">
                    <asp:TextBox ID="PasswordTextBox" runat="server" Text='<%# Bind("Password") %>'></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 115px; height: 19px">
                    Prefix:
                </td>
                <td style="height: 19px; width: 201px;">
                    <asp:TextBox ID="PrefixTextBox" runat="server" Text='<%# Bind("Prefix") %>' Width="88px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 115px; height: 19px">
                    FirstName:
                </td>
                <td style="height: 19px; width: 201px;">
                    <asp:TextBox ID="FirstNameTextBox" runat="server" Text='<%# Bind("FirstName") %>'></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 115px; height: 19px">
                    MiddleName:
                </td>
                <td style="height: 19px; width: 201px;">
                    <asp:TextBox ID="MiddleNameTextBox" runat="server" Text='<%# Bind("MiddleName") %>'></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 115px; height: 19px">
                    LastName:</td>
                <td style="height: 19px; width: 201px;">
                    <asp:TextBox ID="LastNameTextBox" runat="server" Text='<%# Bind("LastName") %>'></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 115px; height: 19px">
                    EMailAddress:</td>
                <td style="height: 19px; width: 201px;">
                    <asp:TextBox ID="EMailAddressTextBox" runat="server" Text='<%# Bind("EMailAddress") %>' Width="200px"></asp:TextBox></td>
            </tr>
        </table>
        <br />
        &nbsp;
    </InsertItemTemplate>
    <ItemTemplate>
        AccountEmployeeId:
        <asp:Label ID="AccountEmployeeIdLabel" runat="server" Text='<%# Eval("AccountEmployeeId") %>'>
        </asp:Label><br />
        Login:
        <asp:Label ID="LoginLabel" runat="server" Text='<%# Bind("Login") %>'></asp:Label><br />
        Password:
        <asp:Label ID="PasswordLabel" runat="server" Text='<%# Bind("Password") %>'></asp:Label><br />
        Prefix:
        <asp:Label ID="PrefixLabel" runat="server" Text='<%# Bind("Prefix") %>'></asp:Label><br />
        FirstName:
        <asp:Label ID="FirstNameLabel" runat="server" Text='<%# Bind("FirstName") %>'></asp:Label><br />
        LastName:
        <asp:Label ID="LastNameLabel" runat="server" Text='<%# Bind("LastName") %>'></asp:Label><br />
        MiddleName:
        <asp:Label ID="MiddleNameLabel" runat="server" Text='<%# Bind("MiddleName") %>'>
        </asp:Label><br />
        EMailAddress:
        <asp:Label ID="EMailAddressLabel" runat="server" Text='<%# Bind("EMailAddress") %>'>
        </asp:Label><br />
        AccountId:
        <asp:Label ID="AccountIdLabel" runat="server" Text='<%# Bind("AccountId") %>'></asp:Label><br />
        AccountDepartmentId:
        <asp:Label ID="AccountDepartmentIdLabel" runat="server" Text='<%# Bind("AccountDepartmentId") %>'>
        </asp:Label><br />
        AccountRoleId:
        <asp:Label ID="AccountRoleIdLabel" runat="server" Text='<%# Bind("AccountRoleId") %>'>
        </asp:Label><br />
        AddressLine1:
        <asp:Label ID="AddressLine1Label" runat="server" Text='<%# Bind("AddressLine1") %>'>
        </asp:Label><br />
        AddressLine2:
        <asp:Label ID="AddressLine2Label" runat="server" Text='<%# Bind("AddressLine2") %>'>
        </asp:Label><br />
        State:
        <asp:Label ID="StateLabel" runat="server" Text='<%# Bind("State") %>'></asp:Label><br />
        City:
        <asp:Label ID="CityLabel" runat="server" Text='<%# Bind("City") %>'></asp:Label><br />
        Zip:
        <asp:Label ID="ZipLabel" runat="server" Text='<%# Bind("Zip") %>'></asp:Label><br />
        CountryId:
        <asp:Label ID="CountryIdLabel" runat="server" Text='<%# Bind("CountryId") %>'></asp:Label><br />
        HomePhoneNo:
        <asp:Label ID="HomePhoneNoLabel" runat="server" Text='<%# Bind("HomePhoneNo") %>'>
        </asp:Label><br />
        WorkPhoneNo:
        <asp:Label ID="WorkPhoneNoLabel" runat="server" Text='<%# Bind("WorkPhoneNo") %>'>
        </asp:Label><br />
        MobilePhoneNo:
        <asp:Label ID="MobilePhoneNoLabel" runat="server" Text='<%# Bind("MobilePhoneNo") %>'>
        </asp:Label><br />
        BillingRateCurrencyId:
        <asp:Label ID="BillingRateCurrencyIdLabel" runat="server" Text='<%# Bind("BillingRateCurrencyId") %>'>
        </asp:Label><br />
        BillingRate:
        <asp:Label ID="BillingRateLabel" runat="server" Text='<%# Bind("BillingRate") %>'>
        </asp:Label><br />
        BillingRateStateDate:
        <asp:Label ID="BillingRateStateDateLabel" runat="server" Text='<%# Bind("BillingRateStateDate") %>'>
        </asp:Label><br />
        StartDate:
        <asp:Label ID="StartDateLabel" runat="server" Text='<%# Bind("StartDate") %>'></asp:Label><br />
        TerminationDate:
        <asp:Label ID="TerminationDateLabel" runat="server" Text='<%# Bind("TerminationDate") %>'>
        </asp:Label><br />
        StatusId:
        <asp:Label ID="StatusIdLabel" runat="server" Text='<%# Bind("StatusId") %>'></asp:Label><br />
        IsDeleted:
        <asp:CheckBox ID="IsDeletedCheckBox" runat="server" Checked='<%# Bind("IsDeleted") %>'
            Enabled="false" /><br />
        IsDisabled:
        <asp:CheckBox ID="IsDisabledCheckBox" runat="server" Checked='<%# Bind("IsDisabled") %>'
            Enabled="false" /><br />
        DefaultProjectId:
        <asp:Label ID="DefaultProjectIdLabel" runat="server" Text='<%# Bind("DefaultProjectId") %>'>
        </asp:Label><br />
        TimeZoneId:
        <asp:Label ID="TimeZoneIdLabel" runat="server" Text='<%# Bind("TimeZoneId") %>'>
        </asp:Label><br />
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
</asp:FormView>
<asp:ObjectDataSource ID="dsAccountEmployeeObject" runat="server" DeleteMethod="Delete"
    InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData"
    TypeName="TimeLiveDataSetTableAdapters.AccountEmployeeTableAdapter" UpdateMethod="Update">
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
        <asp:Parameter Name="AddressLine1" Type="String" />
        <asp:Parameter Name="AddressLine2" Type="String" />
        <asp:Parameter Name="State" Type="Int16" />
        <asp:Parameter Name="City" Type="String" />
        <asp:Parameter Name="Zip" Type="String" />
        <asp:Parameter Name="CountryId" Type="Int16" />
        <asp:Parameter Name="HomePhoneNo" Type="String" />
        <asp:Parameter Name="WorkPhoneNo" Type="String" />
        <asp:Parameter Name="MobilePhoneNo" Type="String" />
        <asp:Parameter Name="BillingRateCurrencyId" Type="Int16" />
        <asp:Parameter Name="BillingRate" Type="Decimal" />
        <asp:Parameter Name="BillingRateStateDate" Type="DateTime" />
        <asp:Parameter Name="StartDate" Type="DateTime" />
        <asp:Parameter Name="TerminationDate" Type="DateTime" />
        <asp:Parameter Name="StatusId" Type="Byte" />
        <asp:Parameter Name="IsDeleted" Type="Boolean" />
        <asp:Parameter Name="IsDisabled" Type="Boolean" />
        <asp:Parameter Name="DefaultProjectId" Type="Int32" />
        <asp:Parameter Name="TimeZoneId" Type="Int16" />
        <asp:Parameter Name="Original_AccountEmployeeId" Type="Int32" />
    </UpdateParameters>
    <InsertParameters>
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
        <asp:Parameter Name="AddressLine1" Type="String" />
        <asp:Parameter Name="AddressLine2" Type="String" />
        <asp:Parameter Name="State" Type="Int16" />
        <asp:Parameter Name="City" Type="String" />
        <asp:Parameter Name="Zip" Type="String" />
        <asp:Parameter Name="CountryId" Type="Int16" />
        <asp:Parameter Name="HomePhoneNo" Type="String" />
        <asp:Parameter Name="WorkPhoneNo" Type="String" />
        <asp:Parameter Name="MobilePhoneNo" Type="String" />
        <asp:Parameter Name="BillingRateCurrencyId" Type="Int16" />
        <asp:Parameter Name="BillingRate" Type="Decimal" />
        <asp:Parameter Name="BillingRateStateDate" Type="DateTime" />
        <asp:Parameter Name="StartDate" Type="DateTime" />
        <asp:Parameter Name="TerminationDate" Type="DateTime" />
        <asp:Parameter Name="StatusId" Type="Byte" />
        <asp:Parameter Name="IsDeleted" Type="Boolean" />
        <asp:Parameter Name="IsDisabled" Type="Boolean" />
        <asp:Parameter Name="DefaultProjectId" Type="Int32" />
        <asp:Parameter Name="TimeZoneId" Type="Int16" />
    </InsertParameters>
</asp:ObjectDataSource>
