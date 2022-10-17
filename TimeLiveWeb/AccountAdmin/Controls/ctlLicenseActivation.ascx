<%@ Control Language="vb" AutoEventWireup="false" Inherits="TimeLive.ctlLicenseActivation" CodeFile="ctlLicenseActivation.ascx.vb" %>
<%@ Register Assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2"
    Namespace="eWorld.UI" TagPrefix="ew" %>
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc2" %>
<%@ Register Assembly="eWorld.UI"
    Namespace="eWorld.UI" TagPrefix="ew" %>
<br />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:FormView ID="FormView1" runat="server" DataKeyNames="AccountId" 
                DataSourceID="dsAccountObject" DefaultMode="Edit" SkinID="formviewSkinEmployee" 
                Width="98%">
                <EditItemTemplate>
                    <table border="0" cellpadding="0" cellspacing="0" style="width: 98%;">
                        <tr>
                            <th align="left" class="caption" colspan="3">
                            <asp:Literal ID="Literal1" runat="server" Text='<%# ResourceHelper.GetFromResource("Provide Your Information") %>' /></th>
                        </tr>
                        <%If System.Configuration.ConfigurationManager.AppSettings("DISABLE_LICENSE") <> "Yes" Then%>
                        <%If System.Configuration.ConfigurationManager.AppSettings("ApplicationMode") = "Hosted" Then %>
                        <tr>
                            <th class="FormViewSubHeader" colspan="3" style="height: 22px">
                                <asp:Literal ID="Literal67" runat="server" 
                                    Text='<%# ResourceHelper.GetFromResource("Package Plan:") %>' />
                            </th>
                        </tr>
                        <tr>
                            <td align="right" class="FormViewLabelCell" 
                                style="padding: 5px; width: 30%; height: 22px">
                                <asp:Literal ID="Literal69" runat="server" 
                                    Text='<%# ResourceHelper.GetFromResource("Package:") %>' />
                            </td>
                            <td style="width: 15%; height: 22px">
                                <asp:DropDownList ID="ddlPackage" runat="server" Width="200px">
                                    <asp:ListItem Value="1">Lite</asp:ListItem>
                                    <asp:ListItem Value="5">Basic</asp:ListItem>
                                    <asp:ListItem Value="10">Standard</asp:ListItem>
                                    <asp:ListItem Value="15">Enterprise</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td style="width: 40%; height: 22px; padding-top: 5px; padding-bottom: 5px; padding-left: 5px;">
                                <asp:Button ID="btnChangePlanTo" runat="server" OnClick="btnChangePlanTo_Click" 
                                    Text="Update Plan" Width="110px" CausesValidation="False" />
                                <asp:Button ID="btnRenew" runat="server" OnClick="btnRenew_Click" Text="Renew" 
                                    Width="110px" CausesValidation="False" />
                                <asp:Button ID="btnUpdateExisting" runat="server" CausesValidation="False" 
                                    OnClick="btnUpdateExisting_Click" Text="Update Existing Plan" 
                                    Visible="False" />
                            </td>
                        </tr>
                        <% If Not LicensingBLL.IsFreeLiteVersion(DBUtilities.GetSessionAccountId) Then%>
                        <tr>
                            <td align="right" class="FormViewLabelCell" style="width: 30%; height: 22px">
                                <asp:Literal ID="Literal63" runat="server" 
                                    Text='<%# ResourceHelper.GetFromResource("License Users Usage:") %>' />
                            </td>
                            <td colspan="2" style="height: 22px">
                                <asp:Label ID="lblNumberOfUsersForHosted" runat="server" 
                                    CssClass="ErrorMessage" Width="192px"></asp:Label>
                            </td>
                        </tr>
                        <% End If%>
                        <% If LicensingBLL.IsFreeLiteVersion(DBUtilities.GetSessionAccountId) Then%>
                        <tr><td align="center" colspan="3"><span 
                                style="color: red; font-size: 12px; font-family: Tahoma;"><strong>*<asp:Literal 
                                ID="Literal7" runat="server" 
                                Text="This is the  30 days free trial with unlimited users / all features. After 30 days, your plan will be automatically converted to Free Lite edition, valid only for 3 users and 3 projects." /></strong></span></td></tr>
                        <% End If%>
<% If Not LicensingBLL.IsFreeAccount(DBUtilities.GetSessionAccountId) Or LicensingBLL.IsPaidCustomerLicenseExpired(DBUtilities.GetSessionAccountId) Then%>
                        <tr>
                            <th class="FormViewSubHeader" colspan="3" style="height: 22px">
                                <asp:Literal ID="Literal64" runat="server" 
                                    Text='<%# ResourceHelper.GetFromResource("Account Expiry") %>' />
                            </th>
                        </tr>
                        <tr>
                            <td align="right" class="FormViewLabelCell" style="width: 30%; height: 22px">
                                <asp:Literal ID="Literal65" runat="server" 
                                    Text='<%# ResourceHelper.GetFromResource("Expiry Date:") %>' />
                            </td>
                            <td style="width: 15%; height: 22px">
                                <asp:Label ID="lblExpiryDate" runat="server" CssClass="ErrorMessage" 
                                    Text="lblExpiryDate" Width="160px"></asp:Label>
                            </td>
                            <td style="width: 40%; height: 22px">
                            </td>
                        </tr>
                         <% If LicensingBLL.IsHostedPaidCustomerLicenseExpired(DBUtilities.GetSessionAccountId) Then%>
                        <tr>
                            <td align="right" class="FormViewLabelCell" style="width: 30%; height: 22px">
                            </td>
                            <td colspan="2" style="width: 15%; height: 22px">
                                <asp:Label ID="Label26" runat="server" CssClass="ErrorMessage" 
                                    Text="(Your 30 days trial has been expired. In order to continue using TimeLive, upgrade to the paid version)"></asp:Label>
                            </td>
                        </tr>
                         <%End If %>
<%End If %>
<%End If %>
<% If System.Configuration.ConfigurationManager.AppSettings("ApplicationMode") = "Installed" Then%>
                        <tr>
                            <th align="left" class="FormViewSubHeader" colspan="3" style="height: 22px">
                                <asp:Literal ID="Literal4" runat="server" 
                                    Text='<%# ResourceHelper.GetFromResource("License Activation") %>' />
                            </th>
                        </tr>
                        <tr>
                            <td align="right" class="FormViewLabelCell" style="width: 30%; height: 22px">
                                <asp:Label ID="Label22" runat="server" AssociatedControlID="txtLicenseKeys">
                    <asp:Literal ID="Literal28" runat="server" 
            Text='<%# ResourceHelper.GetFromResource("License Key") %>' /></asp:Label></td><td colspan="2" 
                                style="height: 22px"><asp:TextBox ID="txtLicenseKeys" runat="server" Text="" 
                                    Width="304px"></asp:TextBox><asp:Label ID="lblLicenseError" runat="server" 
                                    CssClass="ErrorMessage" Text="License Required" Visible="False"></asp:Label></td></tr>
                       <tr><td align="right" class="FormViewLabelCell" style="width: 30%; height: 22px"></td><td 
                                colspan="2" style="height: 22px"><asp:RadioButton ID="rdOnlineActivation" 
                                    runat="server" AutoPostBack="True" GroupName="License" 
                                    OnCheckedChanged="rdOnlineActivation_CheckedChanged" 
                                    Text='<%# ResourceHelper.GetFromResource("Online Activation") %>' /></td></tr>
                    <tr><td align="right" class="FormViewLabelCell" style="width: 30%; height: 22px"></td><td 
                                colspan="2" style="height: 22px"><asp:RadioButton ID="rdManualActivation" 
                                    runat="server" AutoPostBack="True" GroupName="License" 
                                    OnCheckedChanged="rdManualActivation_CheckedChanged" 
                                    Text='<%# ResourceHelper.GetFromResource("Manual Activation") %>' /><asp:Label 
                                    ID="lblActivationFailed" runat="server" CssClass="ErrorMessage" 
                                    Text="<%$ Resources:TimeLive.Resource, Activation Failed%>" Visible="False"></asp:Label></td></tr>
                    <tr><td align="right" class="FormViewLabelCell" style="width: 30%; height: 22px"><asp:Label 
                                ID="Label23" runat="server" AssociatedControlID="MachineNameTextBox">
                     <asp:Literal ID="Literal61" runat="server" 
                Text='<%# ResourceHelper.GetFromResource("Machine Name:") %>' /></asp:Label></td><td 
                                colspan="2" style="height: 22px"><asp:TextBox ID="MachineNameTextBox" 
                                    runat="server" ReadOnly="True" Text="" Width="304px"></asp:TextBox></td></tr><tr><td 
                                align="right" class="FormViewLabelCell" style="width: 30%; height: 22px"><asp:Label 
                                ID="Label24" runat="server" AssociatedControlID="MachineKeyTextBox">
                     <asp:Literal ID="Literal62" runat="server" 
                Text='<%# ResourceHelper.GetFromResource("Machine Key:") %>' /></asp:Label></td><td 
                                colspan="2" style="height: 22px"><asp:TextBox ID="MachineKeyTextBox" 
                                    runat="server" Text="" Width="304px"></asp:TextBox><asp:Label 
                                    ID="lblMachineKeyError" runat="server" CssClass="ErrorMessage" 
                                    Text="Machine Key Required" Visible="False"></asp:Label></td></tr>
                                    <% If not LicensingBLL.IsFreeAccount(DBUtilities.GetSessionAccountId) Then%><tr><td 
                                align="right" class="FormViewLabelCell" style="width: 30%; height: 22px"><asp:Literal 
                                ID="Literal29" runat="server" Text="License Users Usage:" /></td><td 
                                colspan="2" style="height: 22px"><asp:Label ID="lblNumberOfUsers" 
                                    runat="server" CssClass="ErrorMessage" Width="192px"></asp:Label></td></tr>
                                    <%End If%><% If LicensingBLL.IsValidLicenseActivation() = False Then%><tr><td 
                                align="right" class="FormViewLabelCell" style="width: 30%; height: 22px"><asp:Literal 
                                ID="Literal78" runat="server" 
                                Text='<%# ResourceHelper.GetFromResource("Unlimited User Support Expiry:") %>' /></td><td 
                                style="width: 15%; height: 22px"><asp:Label ID="lblExpiryDateLicense" 
                                    runat="server" CssClass="ErrorMessage" Text="lblExpiryDate" Width="160px"></asp:Label></td><td 
                                style="width: 40%; height: 22px"></td></tr>
                                 <% If LicensingBLL.IsFreeAccount(DBUtilities.GetSessionAccountId) Then%>
                                <tr><td align="right" 
                                class="FormViewLabelCell" style="width: 30%; height: 22px"></td><td 
                                colspan="2" style="width: 15%; height: 22px"><asp:Label ID="Label1" 
                                    runat="server" CssClass="ErrorMessage" 
                                    Text="(Your 30 days trial has been expired. In order to continue using TimeLive, upgrade to the paid version)"></asp:Label></td></tr>
                                    <%End If%>
                                    <%End If%><tr><td 
                                align="right" style="width: 35%; padding-bottom: 5px;"></td><td colspan="2" 
                                style="padding-bottom: 5px;"><asp:Button ID="cmdActivateSerial" runat="server" 
                                    OnClick="cmdActivateSerial_Click" 
                                    Text='<%# ResourceHelper.GetFromResource("Activate") %>' /></td></tr><%End If %>
<% End If%>
                                     <tr>
                            <th align="left" class="FormViewSubHeader" colspan="3" style="height: 22px">
                                <asp:Literal 
                                    ID="Literal2" runat="server" 
                                    Text='<%# ResourceHelper.GetFromResource("Disable Account") %>' /></th>
                        </tr></tr><tr><td align="center" colspan="3"><span 
                                style="color: red; font-size: 12px; font-family: Tahoma;"><strong>*<asp:Literal 
                                ID="Literal3" runat="server" 
                                Text="<%$ Resources:TimeLive.Resource, Disabling account will stop any activities in your TimeLive account. Your employee will not be able to login in TimeLive. %> " /></strong></span></td></tr>
                                <tr><td 
                                align="right" style="width: 35%; "><asp:Literal 
                                ID="Literal5" runat="server" 
                                Text="<%$ Resources:TimeLive.Resource, Administrator Username:%> " /></td><td 
                                colspan="2"><asp:TextBox ID="UserNameTextBox" 
                                    runat="server" Width="207px"></asp:TextBox><asp:RequiredFieldValidator 
                                    ID="RequiredFieldValidator1" runat="server" ControlToValidate="UserNameTextBox" 
                                    CssClass="ErrorMessage" ErrorMessage="*"></asp:RequiredFieldValidator></td></tr><tr><td 
                                align="right" style="width: 35%; padding-bottom: 5px;"><asp:Literal 
                                ID="Literal6" runat="server" 
                                Text="<%$ Resources:TimeLive.Resource, Administrator Password:%> " /></td><td 
                                colspan="2" style="padding-bottom: 5px;"><asp:TextBox ID="PasswordTextBox" 
                                    runat="server" TextMode="Password" Width="207px"></asp:TextBox><asp:RequiredFieldValidator 
                                    ID="RequiredFieldValidator2" runat="server" ControlToValidate="PasswordTextBox" 
                                    CssClass="ErrorMessage" ErrorMessage="*"></asp:RequiredFieldValidator></td></tr><tr><td 
                                align="right" style="width: 35%; padding-bottom: 5px;">&nbsp;</td><td 
                                colspan="2" style="padding-bottom: 5px;"><asp:Button ID="btnDisabled" 
                                    runat="server" 
                                    OnClientClick="return confirm('Are you sure you want to disable this account?');" 
                                    Text="<%$ Resources:TimeLive.Resource, Disable Account%> " Width="150px" 
                                    onclick="btnDisabled_Click" /></td></tr><tr><td 
                                align="right" style="width: 35%; padding-bottom: 5px;">&nbsp;</td><td 
                                colspan="2" style="padding-bottom: 5px;"><asp:Label ID="Label2" runat="server" 
                                    Font-Names="Tahoma" Font-Size="Smaller" ForeColor="Red" 
                                    Text="<%$ Resources:TimeLive.Resource, *Invalid username or password%> " 
                                    Visible="False"></asp:Label></td></tr></table></EditItemTemplate></asp:FormView><asp:ObjectDataSource ID="dsAccountObject" 
                    runat="server" InsertMethod="AddNewAccount" 
                    OldValuesParameterFormatString="original_{0}" 
                    SelectMethod="GetAccountViewAsAccountId" TypeName="AccountBLL" 
                    UpdateMethod="UpdateAccount"><InsertParameters><asp:Parameter Name="AccountTypeId" 
                            Type="Int16" /><asp:Parameter Name="AccountName" Type="String" /><asp:Parameter 
                            Name="Address1" Type="String" /><asp:Parameter Name="Address2" 
                            Type="String" /><asp:Parameter Name="ZipCode" Type="String" /><asp:Parameter 
                            Name="City" Type="String" /><asp:Parameter Name="CountryId" Type="Int16" /><asp:Parameter 
                            Name="EMailAddress" Type="String" /><asp:Parameter Name="EmployeeCode" 
                            Type="String" /><asp:Parameter Name="Telephone" Type="String" /><asp:Parameter 
                            Name="Fax" Type="String" /><asp:Parameter Name="DefaultCurrencyId" 
                            Type="Int16" /><asp:Parameter Name="TimeZoneId" Type="Byte" /><asp:Parameter 
                            Name="EmployeeLogin" Type="String" /><asp:Parameter Name="EmployeePassword" 
                            Type="String" /><asp:Parameter Name="EmployeeEMailAddress" Type="String" /><asp:Parameter 
                            Name="EmployeeFirstName" Type="String" /><asp:Parameter 
                            Name="EmployeeLastName" Type="String" /><asp:Parameter 
                            Name="EmployeePrefix" Type="String" /><asp:Parameter 
                            Name="EmployeeMiddleName" Type="String" /><asp:Parameter Name="State" 
                            Type="String" /><asp:Parameter Name="IsDisabled" Type="Boolean" /><asp:Parameter 
                            Name="IsDeleted" Type="Boolean" /><asp:Parameter Name="CreatedOn" 
                            Type="DateTime" /><asp:Parameter Name="ModifiedOn" Type="DateTime" /><asp:Parameter 
                            Name="UserInterfaceLanguage" Type="String" /></InsertParameters><UpdateParameters><asp:Parameter 
                            Name="AccountName" Type="String" /><asp:Parameter Name="Address1" 
                            Type="String" /><asp:Parameter Name="Address2" Type="String" /><asp:Parameter 
                            Name="ZipCode" Type="String" /><asp:Parameter Name="City" Type="String" /><asp:Parameter 
                            Name="CountryId" Type="Int16" /><asp:Parameter Name="EMailAddress" 
                            Type="String" /><asp:Parameter Name="Telephone" Type="String" /><asp:Parameter 
                            Name="Fax" Type="String" /><asp:Parameter Name="DefaultCurrencyId" 
                            Type="Int16" /><asp:Parameter Name="ShowClockStartEnd" Type="Boolean" /><asp:Parameter 
                            Name="TimeEntryFormat" Type="String" /><asp:Parameter 
                            Name="ModifiedByEmployeeId" Type="Int32" /><asp:Parameter 
                            Name="original_AccountId" Type="Int32" /><asp:Parameter Name="TimeZoneId" 
                            Type="Byte" /><asp:Parameter Name="CultureInfoName" Type="String" /><asp:Parameter 
                            Name="CurrencySymbol" Type="String" /><asp:Parameter 
                            Name="AccountSessionTimeout" Type="Int32" /><asp:Parameter 
                            Name="ShowCompletedTasksInTimeSheet" Type="Boolean" /><asp:Parameter 
                            Name="ScheduledEmailSendTime" Type="DateTime" /><asp:Parameter 
                            Name="LockSubmittedRecords" Type="Boolean" /><asp:Parameter 
                            Name="LockApprovedRecords" Type="Boolean" /><asp:Parameter 
                            Name="ShowWorkTypeInTimeSheet" Type="Boolean" /><asp:Parameter 
                            Name="NumberOfBlankRowsInTimeEntry" Type="Int16" /><asp:Parameter 
                            Name="ShowCostCenterInTimeSheet" Type="Boolean" /><asp:Parameter 
                            Name="UserInterfaceLanguage" Type="String" /><asp:Parameter 
                            Name="DefaultTimeEntryMode" Type="String" /><asp:Parameter Name="PageSize" 
                            Type="Int32" /><asp:Parameter Name="ShowClientInTimesheet" Type="Boolean" /><asp:Parameter 
                            Name="ShowDescriptionInWeekView" Type="Boolean" /><asp:Parameter 
                            Name="InvoiceNoPrefix" Type="String" /><asp:Parameter 
                            Name="ShowAdditionalTaskInformationType" Type="Int32" /><asp:Parameter 
                            Name="ShowCompletedProjectsInTimeSheet" Type="Boolean" /><asp:Parameter 
                            Name="ShowProjectForTimeOff" Type="Boolean" /><asp:Parameter 
                            Name="ShowTimeOffInTimesheet" Type="Boolean" /><asp:Parameter 
                            Name="PasswordExpiryPeriod" Type="Int32" /><asp:Parameter 
                            Name="ShowAllInTimesheetReadOnly" Type="Boolean" /><asp:Parameter 
                            Name="ShowTaskInExpenseSheet" Type="Boolean" /><asp:Parameter DbType="Guid" 
                            Name="InvoiceBillingTypeId" /><asp:Parameter 
                            Name="ShowBillingRateInInvoiceReport" Type="Boolean" /><asp:Parameter 
                            Name="InvoiceFooter" Type="String" /><asp:Parameter 
                            Name="TimesheetOverduePeriods" Type="Int16" /><asp:Parameter 
                            Name="ShowPercentageInTimesheet" Type="Boolean" /><asp:Parameter 
                            DbType="Guid" Name="TimeEntryHoursFormatId" /><asp:Parameter 
                            Name="EnablePasswordComplexity" Type="Boolean" /><asp:Parameter 
                            Name="IsShowElectronicSign" Type="Boolean" /></UpdateParameters><SelectParameters><asp:SessionParameter 
                            DefaultValue="99" Name="AccountId" SessionField="AccountId" Type="Int32" /></SelectParameters></asp:ObjectDataSource>

                            </ContentTemplate></asp:UpdatePanel>
