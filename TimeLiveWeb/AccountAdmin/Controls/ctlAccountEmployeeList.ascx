<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlAccountEmployeeList.ascx.vb" Inherits="Controls_ctlAccountEmployeeList" %>
<%@ Register Assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24D65337282035F2" Namespace="eWorld.UI" TagPrefix="ew" %>
<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
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
    <x:GridView ID="GridView1" runat="server"  AutoGenerateColumns="False" DataKeyNames="AccountEmployeeId" DataSourceID="dsAccountEmployeeList" SkinID="xgridviewSkinEmployee" Caption="<%$ Resources:TimeLive.Resource, Employee List %>" Width="98%">
        <Columns>
            <asp:BoundField DataField="AccountEmployeeId" HeaderText="<%$ Resources:TimeLive.Resource, Id %>" InsertVisible="False" ReadOnly="True" SortExpression="AccountEmployeeId" >
                <ItemStyle HorizontalAlign="Center" Width="5%"/>
            </asp:BoundField>
            <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Code %>" SortExpression="EmployeeCode">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("EmployeeCode") %>'></asp:TextBox>
                </EditItemTemplate>
                <headertemplate>
                    <asp:LinkButton id="LinkButton2" runat="server" Text='<%# ResourceHelper.GetFromResource("Code") %>' __designer:wfdid="w3" CausesValidation="False" CommandName="Sort" CommandArgument="EmployeeCode"></asp:LinkButton> 
                </headertemplate>
                <ItemTemplate>
                    <asp:Label ID="lblEmployeeCode" runat="server" Text='<%# Bind("EmployeeCode") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="10%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, First Name %>" SortExpression="FirstName">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("FirstName") %>'></asp:TextBox>
                </EditItemTemplate>
                <headertemplate>
                    <asp:LinkButton id="LinkButton3" runat="server" Text='<%# ResourceHelper.GetFromResource("First Name") %>' __designer:wfdid="w3" CausesValidation="False" CommandName="Sort" CommandArgument="FirstName"></asp:LinkButton> 
                </headertemplate>
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("FirstName") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="15%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Last Name %>" SortExpression="LastName">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("LastName") %>'></asp:TextBox>
                </EditItemTemplate>
                <headertemplate>
                    <asp:LinkButton id="LinkButton4" runat="server" Text='<%# ResourceHelper.GetFromResource("Last Name") %>' __designer:wfdid="w3" CausesValidation="False" CommandName="Sort" CommandArgument="LastName"></asp:LinkButton> 
                </headertemplate>
                <ItemTemplate>
                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("LastName") %>'></asp:Label>
                </ItemTemplate>
                      <ItemStyle Width="15%" />
                </asp:TemplateField>
            <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Department %>" SortExpression="Department">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("Department") %>'></asp:TextBox>
                </EditItemTemplate>
                <headertemplate>
                    <asp:LinkButton id="LinkButton5" runat="server" Text='<%# ResourceHelper.GetFromResource("Department") %>' __designer:wfdid="w3" CausesValidation="False" CommandName="Sort" CommandArgument="Department"></asp:LinkButton> 
                </headertemplate>
                <ItemTemplate>
                    <asp:Label ID="lblDepartment" runat="server" Text='<%# Bind("Department") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="15%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Location %>" SortExpression="AccountLocation">
                <edititemtemplate>
                    <asp:TextBox id="TextBox1" runat="server" Text='<%# Bind("AccountLocation") %>' __designer:wfdid="w2"></asp:TextBox>
                </edititemtemplate>
                <headertemplate>
                    <asp:LinkButton id="LinkButton6" runat="server" Text='<%# ResourceHelper.GetFromResource("Location") %>' __designer:wfdid="w3" CausesValidation="False" CommandName="Sort" CommandArgument="AccountLocation"></asp:LinkButton> 
                </headertemplate>
                <itemtemplate>
                    <asp:Label id="lblLocation" runat="server" Text='<%# Bind("AccountLocation") %>' __designer:wfdid="w1"></asp:Label>
                </itemtemplate>
                <ItemStyle Width="15%" />
            </asp:TemplateField>
                <asp:CommandField HeaderText="<%$ Resources:TimeLive.Resource, Edit_text %>" SelectText="Edit" ShowSelectButton="True"  >
                    <ItemStyle HorizontalAlign="Center" cssclass="edit_button" width="1%" />
                </asp:CommandField>
            <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Delete_text %>"  ShowHeader="False">
                <ItemTemplate>
                    <asp:LinkButton id="LinkButton1" runat="server" Text="Delete" Visible='<%# IIF((Eval("AccountEmployeeId")=DBUtilities.GetSessionAccountEmployeeId),False,True) %>' __designer:wfdid="w7" CausesValidation="False" CommandName="Delete" OnClientClick="<%# ResourceHelper.GetDeleteMessageJavascript()%>"></asp:LinkButton> 
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center"  />
                <ItemStyle HorizontalAlign="Center" cssclass="delete_button" Width="1%"  />
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:HyperLink id="HyperLink1" runat="server" Text="Email Preferences" __designer:wfdid="w6" ToolTip="<%$ Resources:TimeLive.Resource, EMail Preference%> " ImageUrl="~/Images/Preferences.gif" NavigateUrl='<%# Eval("AccountEmployeeId", "~/Employee/AccountEMailNotificationPreferences.aspx?AccountEmployeeId={0}") %>'></asp:HyperLink> 
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="1%" />
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderTemplate>
                    <asp:Image id="Image1" runat="server" __designer:wfdid="w5" ToolTip="<%$ Resources:TimeLive.Resource, Disabled_text%> " ImageUrl="~/Images/Disabled.gif"></asp:Image> 
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Image id="Image1" runat="server" Visible='<%# IIF(IsDBNull(Eval("IsDisabled")),"false",Eval("IsDisabled")) %>' __designer:wfdid="w4" ToolTip="<%$ Resources:TimeLive.Resource, Disabled_text%> " ImageUrl="~/Images/Disabled.gif"></asp:Image> 
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="1%" />
            </asp:TemplateField>
            <asp:TemplateField>
                <itemtemplate>
                    <asp:HyperLink id="TimeOffStausHyperLink" runat="server" Text='<%# ResourceHelper.GetFromResource("Time Off") %>' __designer:wfdid="w206" NavigateUrl='<%# Eval("AccountEmployeeId", "~/Employee/TimeOffStatus.aspx?AccountEmployeeId={0}") %>'></asp:HyperLink>
                </itemtemplate>
                <ItemStyle HorizontalAlign="Center" Width="5%"/>
            </asp:TemplateField>
            <asp:TemplateField>
                <itemtemplate>
                    <asp:HyperLink id="EmployeeProjectHyperLink" runat="server" Text='<%# ResourceHelper.GetFromResource("Projects") %>' NavigateUrl='<%# Eval("AccountEmployeeId", "~/Employee/AccountEmployeeProject.aspx?AccountEmployeeId={0}") %>'></asp:HyperLink>
                </itemtemplate>
                    <ItemStyle HorizontalAlign="Center" Width="5%"/>
            </asp:TemplateField>
            <asp:TemplateField Visible="False">
                <itemtemplate>
                    <asp:HyperLink id="CostCenterEmployeeHyperLink" runat="server" Text='<%# ResourceHelper.GetFromResource("Cost Center") %>' NavigateUrl='<%# Eval("AccountEmployeeId", "~/Employee/AccountCostCenterEmployee.aspx?AccountEmployeeId={0}") %>'></asp:HyperLink>
                </itemtemplate>
                    <ItemStyle HorizontalAlign="Center" Width="6%"/>
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderTemplate>
                    <asp:CheckBox ID="chkCheckAll" runat="server" Width="15px" /></HeaderTemplate><ItemTemplate><asp:CheckBox ID="chkSelect" runat="server" Width="15px" /></ItemTemplate><HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="15px" /><ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="1%" /></asp:TemplateField>
</Columns>
</x:GridView>
<table style="width: 98%">
    <tr>
        <td align="left" colspan="1" height="2" rowspan="1">
        <div style="margin:5px; padding-top:5px;">
<% If AccountPagePermissionBLL.IsPageHasPermissionOf(4, 2) = True Then%>
            <asp:Button ID="btnAddEmployee" runat="server" OnClick="btnAddEmployee_Click" Text="<%$ Resources:TimeLive.Resource, Add_text %>" Width="75px" UseSubmitBehavior="False" />
<%End If%>
<% If AccountPagePermissionBLL.IsPageHasPermissionOf(4, 4) = True Then%>
            <asp:Button ID="btnDeleteSelectedItem" runat="server" OnClick="btnDeleteSelectedItem_Click" Text="Delete Selected" Visible="False" Width="90px" />
<% End If%>
        </div>
        </td>
    </tr>
</table>
<asp:ObjectDataSource ID="dsAccountEmployeeList" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetvueAccountEmployeesByAccountId" 
    TypeName="AccountEmployeeBLL" InsertMethod="AddAccountEmployee2" DeleteMethod="DeleteAccountEmployee" UpdateMethod="UpdateUsernameOfExistingEmployee">
    <DeleteParameters>
        <asp:Parameter Name="Original_AccountEmployeeId" Type="Int32" />
    </DeleteParameters>
    <InsertParameters>
        <asp:Parameter Name="Login" Type="String" />
        <asp:Parameter Name="Password" Type="String" />
        <asp:Parameter Name="Prefix" Type="String" />
        <asp:Parameter Name="FirstName" Type="String" />
        <asp:Parameter Name="LastName" Type="String" />
    </InsertParameters>
    <SelectParameters>
        <asp:SessionParameter DefaultValue="64" Name="AccountId" SessionField="AccountId" Type="Int32" />
        <asp:QueryStringParameter DefaultValue="0" Name="AccountEmployeeId" 
            QueryStringField="AccountEmployeeId" Type="Int32" />
    </SelectParameters>
    <UpdateParameters>
        <asp:Parameter Name="Original_AccountEmployeeId" Type="Int32" />
        <asp:Parameter Name="Username" Type="String" />
    </UpdateParameters>
</asp:ObjectDataSource>
<asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
    InsertMethod="AddNewAccountEmployee" OldValuesParameterFormatString="original_{0}" 
    SelectMethod="GetAccountEmployeesByAccountEmployeeId" 
    TypeName="AccountEmployeeBLL" UpdateMethod="UpdateSelectedAccountEmployee">
    <InsertParameters>
        <asp:Parameter Name="Username" Type="String" />
        <asp:Parameter Name="Password" Type="String" />
        <asp:Parameter Name="FirstName" Type="String" />
        <asp:Parameter Name="LastName" Type="String" />
        <asp:Parameter Name="EMailAddress" Type="String" />
        <asp:Parameter Name="EmployeeCode" Type="String" />
        <asp:SessionParameter DefaultValue="64" Name="AccountId" SessionField="AccountId" Type="Int32" />
        <asp:Parameter Name="AccountDepartmentId" Type="Int32" />
        <asp:Parameter Name="AccountRoleId" Type="Int32" />
        <asp:Parameter Name="AccountLocationId" Type="Int32" />
        <asp:Parameter Name="CountryId" Type="Int16" />
        <asp:Parameter Name="BillingTypeId" Type="Int32" />
        <asp:Parameter Name="StartDate" Type="DateTime" />
        <asp:Parameter Name="DefaultProjectId" Type="Int32" />
        <asp:Parameter Name="EmployeeManagerId" Type="Int32" />
        <asp:Parameter Name="TimeZoneId" Type="Byte" />
        <asp:Parameter Name="CreatedByEmployeeId" Type="Int32" />
        <asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" />
        <asp:Parameter Name="EmployeePayTypeId" DbType="Guid" />
        <asp:Parameter Name="StatusId" Type="Int32" />
        <asp:Parameter Name="JobTitle" Type="String" />
        <asp:Parameter Name="HiredDate" Type="DateTime" />
        <asp:Parameter Name="TerminationDate" Type="DateTime" />
        <asp:Parameter Name="AccountWorkingDayTypeId" DbType="Guid" />
        <asp:Parameter Name="AccountTimeOffPolicyId" DbType="Guid" />
        <asp:Parameter Name="TimeOffApprovalTypeId" Type="Int32" />
        <asp:Parameter Name="AccountHolidayTypeId" DbType="Guid" />
        <asp:Parameter Name="IsForcePasswordChange" Type="Boolean" />
        <asp:Parameter Name="UserInterfaceLanguage" Type="String" />
        <asp:Parameter Name="IsShowEmployeeProfilePicture" Type="Boolean" />
        <asp:Parameter Name="IsTimeInOutAvailable" Type="Boolean" />
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
        <asp:Parameter Direction="InputOutput" Name="CustomField1" Type="String" />
        <asp:Parameter Direction="InputOutput" Name="CustomField2" Type="String" />
        <asp:Parameter Direction="InputOutput" Name="CustomField3" Type="String" />
        <asp:Parameter Direction="InputOutput" Name="CustomField4" Type="String" />
        <asp:Parameter Direction="InputOutput" Name="CustomField5" Type="String" />
        <asp:Parameter Direction="InputOutput" Name="CustomField6" Type="String" />
        <asp:Parameter Direction="InputOutput" Name="CustomField7" Type="String" />
        <asp:Parameter Direction="InputOutput" Name="CustomField8" Type="String" />
        <asp:Parameter Direction="InputOutput" Name="CustomField9" Type="String" />
        <asp:Parameter Direction="InputOutput" Name="CustomField10" Type="String" />
        <asp:Parameter Direction="InputOutput" Name="CustomField11" Type="String" />
        <asp:Parameter Direction="InputOutput" Name="CustomField12" Type="String" />
        <asp:Parameter Direction="InputOutput" Name="CustomField13" Type="String" />
        <asp:Parameter Direction="InputOutput" Name="CustomField14" Type="String" />
        <asp:Parameter Direction="InputOutput" Name="CustomField15" Type="String" />
    </InsertParameters>
    <UpdateParameters>
        <asp:Parameter Name="Login" Type="String" />
        <asp:Parameter Name="Username" Type="String" />
        <asp:Parameter Name="Password" Type="String" />
        <asp:Parameter Name="Prefix" Type="String" />
        <asp:Parameter Name="FirstName" Type="String" />
        <asp:Parameter Name="LastName" Type="String" />
        <asp:Parameter Name="MiddleName" Type="String" />
        <asp:Parameter Name="EMailAddress" Type="String" />
        <asp:Parameter Name="EmployeeCode" Type="String" />
        <asp:SessionParameter DefaultValue="23" Name="AccountId" SessionField="AccountId" Type="Int32" />
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
        <asp:Parameter Name="BillingTypeId" Type="Int32" ConvertEmptyStringToNull="False" />
        <asp:Parameter Name="StartDate" Type="DateTime" />
        <asp:Parameter Name="TerminationDate" Type="DateTime" />
        <asp:Parameter Name="StatusId" Type="Int32" />
        <asp:Parameter Name="IsDeleted" Type="Boolean" />
        <asp:Parameter Name="IsDisabled" Type="Boolean" />
        <asp:Parameter Name="DefaultProjectId" Type="Int32" />
        <asp:Parameter Name="TimeZoneId" Type="Byte" />
        <asp:Parameter Name="CreatedByEmployeeId" Type="Int32" />
        <asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" />
        <asp:Parameter Name="AllowedAccessFromIP" Type="String" />
        <asp:Parameter Name="Original_AccountEmployeeId" Type="Int32" />
        <asp:Parameter Name="EmployeeManagerId" Type="Int32" />
        <asp:Parameter Name="EmployeePayTypeId" DbType="Guid" />
        <asp:Parameter Name="JobTitle" Type="String" />
        <asp:Parameter Name="HiredDate" Type="DateTime" />
        <asp:Parameter Name="AccountWorkingDayTypeId" DbType="Guid" />
        <asp:Parameter Name="AccountTimeOffPolicyId" DbType="Guid" />
        <asp:Parameter Name="TimeOffApprovalTypeId" Type="Int32" />
        <asp:Parameter Name="AccountHolidayTypeId" DbType="Guid" />
        <asp:Parameter Name="IsForcePasswordChange" Type="Boolean" />
        <asp:Parameter Name="UserInterfaceLanguage" Type="String" />
        <asp:Parameter Name="IsShowEmployeeProfilePicture" Type="Boolean" />
        <asp:Parameter Name="IsTimeInOutAvailable" Type="Boolean" />
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
        <asp:ControlParameter ControlID="GridView1" Name="AccountEmployeeId" PropertyName="SelectedValue" Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>
<asp:FormView id="FormView1" runat="server" Width="95%" SkinID="formviewSkinEmployee" DataSourceID="ObjectDataSource1" DataKeyNames="AccountEmployeeId" DefaultMode="Insert" Visible="False">
    <EditItemTemplate>
<table border="0" id="Table3" cellpadding="0" cellspacing="2" style="width: 100%" >
    <tbody>
    <tr>
        <th class="caption" colspan="4">
            <asp:Literal ID="Literal1" runat="server" Text='<%# ResourceHelper.GetFromResource("Employee Information") %>'></asp:Literal>
        </th>
    </tr>
    <tr>
        <th class="FormViewSubHeader" colspan="4">
            <asp:Literal ID="Literal2" runat="server" Text='<%# ResourceHelper.GetFromResource("Personal Information") %>'></asp:Literal>
        </th>
    </tr>
    <tr>
        <td align="right" class="FormViewLabelCell" style="WIDTH: 20%">
            <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="EmployeeCodeTextBox"> <asp:Literal ID="Literal3" runat="server" Text='<%# ResourceHelper.GetFromResource("Employee Code:") %>'></asp:Literal></asp:Label>
        </td>
        <td colspan="3">
            <asp:TextBox ID="EmployeeCodeTextBox" runat="server" MaxLength="50" OnPreRender="UsernameTextBox_PreRender" Text='<%# Bind("EmployeeCode") %>' ValidationGroup="Insert" Width="168px"></asp:TextBox>
        </td>
    </tr>
<% Dim LDAP As New LDAPUtilitiesBLL%>
<% If LDAP.IsAspNetActiveDirectoryMembershipProvider = True Then%>
    <tr>
        <td align="right" class="FormViewLabelCell" style="WIDTH: 20%">
            <span class="reqasterisk">*</span><asp:Label ID="Label4" runat="server" AssociatedControlID="UsernameTextBox"> <asp:Label ID="lblUsername" runat="server" Text='<%# ResourceHelper.GetFromResource("User Name:") %>'></asp:Label></asp:Label>
        </td>
        <td colspan="3">
            <asp:TextBox ID="UsernameTextBox" runat="server" OnPreRender="UsernameTextBox_PreRender" ValidationGroup="Insert" Width="168px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="UsernameTextBox" CssClass="ErrorMessage" Display="Dynamic" ErrorMessage="*" ValidationGroup="Edit" Width="1px"></asp:RequiredFieldValidator><asp:Button ID="btnGetUserData" runat="server" onclick="btnGetUserData_Click" Text="<%$ Resources:TimeLive.Resource, Get_text%> " Width="50px" />
            <asp:CustomValidator ID="CustomValidator1" runat="server" CssClass="ErrorMessage" Display="Dynamic" ErrorMessage="Specified user not exist" OnServerValidate="CustomValidator1_ServerValidate"></asp:CustomValidator>
        </td>
    </tr>
<% End If%>
    <tr>
        <td align="right" class="FormViewLabelCell" style="WIDTH: 20%">
            <span class="reqasterisk">*</span><asp:Label ID="Label5" runat="server" AssociatedControlID="FirstNameTextBox"> <asp:Literal ID="Literal5" runat="server" Text='<%# ResourceHelper.GetFromResource("First Name:") %>'></asp:Literal></asp:Label>
        </td>
        <td style="WIDTH: 30%" width="40%">
            <asp:TextBox ID="FirstNameTextBox" runat="server" Text='<%# Bind("FirstName") %>' ValidationGroup="Edit" Width="168px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="FirstNameTextBox" CssClass="ErrorMessage" Display="Dynamic" ErrorMessage="*" ValidationGroup="Edit" Width="1px"></asp:RequiredFieldValidator>
        </td>
        <td align="right" class="FormViewLabelCell" style="WIDTH: 20%">
            <asp:Label ID="Label21" runat="server" AssociatedControlID="MiddleNameTextBox"> <asp:Literal ID="Literal6" runat="server" Text='<%# ResourceHelper.GetFromResource("Middle Name:") %>'></asp:Literal></asp:Label>
        </td>
        <td style="WIDTH: 30%">
            <asp:TextBox ID="MiddleNameTextBox" runat="server" Text='<%# Bind("MiddleName") %>' ValidationGroup="Edit" Width="168px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right" class="FormViewLabelCell" style="WIDTH: 20%">
            <span class="reqasterisk">*</span><asp:Label ID="Label7" runat="server" AssociatedControlID="LastNameTextBox"> <asp:Literal ID="Literal7" runat="server" Text='<%# ResourceHelper.GetFromResource("Last Name:") %>'></asp:Literal></asp:Label>
        </td>
        <td style="WIDTH: 30%" width="40%">
            <asp:TextBox ID="LastNameTextBox" runat="server" Text='<%# Bind("LastName") %>' ValidationGroup="Edit" Width="168px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="LastNameTextBox" CssClass="ErrorMessage" Display="Dynamic" ErrorMessage="*" ValidationGroup="Edit" Width="1px"></asp:RequiredFieldValidator>
        </td>
        <td align="right" class="FormViewLabelCell" style="WIDTH: 20%">
            <asp:Label ID="Label11" runat="server" AssociatedControlID="AddressLine1TextBox"><asp:Literal ID="Literal8" runat="server" Text='<%# ResourceHelper.GetFromResource("Address Line 1:") %>'></asp:Literal></asp:Label>
        </td>
        <td style="WIDTH: 30%">
            <asp:TextBox ID="AddressLine1TextBox" runat="server" Text='<%# Bind("AddressLine1") %>' ValidationGroup="Edit" Width="168px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right" class="FormViewLabelCell" style="WIDTH: 20%">
            <asp:Label ID="Label22" runat="server" AssociatedControlID="AddressLine2TextBox">
                <asp:Literal ID="Literal9" runat="server" Text='<%# ResourceHelper.GetFromResource("Address Line 2:") %>'></asp:Literal>
            </asp:Label>
        </td>
        <td style="WIDTH: 30%" width="40%">
            <asp:TextBox ID="AddressLine2TextBox" runat="server" Text='<%# Bind("AddressLine2") %>' ValidationGroup="Edit" Width="168px"></asp:TextBox>
        </td>
        <td align="right" class="FormViewLabelCell" colspan="1" style="WIDTH: 20%">
            <asp:Label ID="Label13" runat="server" AssociatedControlID="StateTextBox">
                <asp:Literal ID="Literal10" runat="server" Text='<%# ResourceHelper.GetFromResource("State:") %>'></asp:Literal>
            </asp:Label>
        </td>
        <td colspan="1" style="WIDTH: 30%">
               <asp:TextBox ID="StateTextBox" runat="server" Text='<%# Bind("State") %>' ValidationGroup="Edit" Width="168px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right" class="FormViewLabelCell" style="WIDTH: 20%">
            <asp:Label ID="Label24" runat="server" AssociatedControlID="CityTextBox"><asp:Literal ID="Literal11" runat="server" Text='<%# ResourceHelper.GetFromResource("City:") %>'></asp:Literal>
            </asp:Label>
        </td>
        <td style="WIDTH: 30%" width="40%">
            <asp:TextBox ID="CityTextBox" runat="server" Text='<%# Bind("City") %>' ValidationGroup="Edit" Width="168px"></asp:TextBox>
        </td>
        <td align="right" class="FormViewLabelCell" colspan="1" style="WIDTH: 20%">
            <asp:Label ID="Label15" runat="server" AssociatedControlID="ZipTextBox"><asp:Literal ID="Literal12" runat="server" Text='<%# ResourceHelper.GetFromResource("ZipCode") %>'></asp:Literal>
            </asp:Label>
        </td>
        <td colspan="1" style="WIDTH: 30%">
            <asp:TextBox ID="ZipTextBox" runat="server" Text='<%# Bind("Zip") %>' ValidationGroup="Edit" Width="168px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right" class="FormViewLabelCell" style="WIDTH: 20%"><asp:Literal ID="Literal13" runat="server" Text='<%# ResourceHelper.GetFromResource("Country:") %>'></asp:Literal></td>
        <td style="WIDTH: 30%" width="40%">
            <asp:DropDownList ID="ddlCountryId" runat="server" DataSourceID="dsSystemCountryObject" DataTextField="Country" DataValueField="CountryId" SelectedValue='<%# Bind("CountryId") %>' ValidationGroup="Edit" Width="180px"></asp:DropDownList>
        </td>
        <td align="right" class="FormViewLabelCell" colspan="1" style="WIDTH: 20%">
            <asp:Label ID="Label17" runat="server" AssociatedControlID="HomePhoneNoTextBox"><asp:Literal ID="Literal14" runat="server" Text='<%# ResourceHelper.GetFromResource("Home Phone No:") %>'></asp:Literal></asp:Label>
        </td>
        <td colspan="1" style="WIDTH: 30%">
            <asp:TextBox ID="HomePhoneNoTextBox" runat="server" Text='<%# Bind("HomePhoneNo") %>' ValidationGroup="Edit" Width="168px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right" class="FormViewLabelCell" style="WIDTH: 20%">
            <asp:Label ID="Label18" runat="server" AssociatedControlID="WorkPhoneNoTextBox"> <asp:Literal ID="Literal15" runat="server" Text='<%# ResourceHelper.GetFromResource("Work Phone No:") %>'></asp:Literal></asp:Label>
        </td>
        <td style="WIDTH: 30%" width="40%">
            <asp:TextBox ID="WorkPhoneNoTextBox" runat="server" Text='<%# Bind("WorkPhoneNo") %>' ValidationGroup="Edit" Width="168px"></asp:TextBox>
        </td>
        <td align="right" class="FormViewLabelCell" colspan="1" style="WIDTH: 20%">
            <asp:Label ID="Label27" runat="server" AssociatedControlID="MobilePhoneNoTextBox"> <asp:Literal ID="Literal16" runat="server" Text='<%# ResourceHelper.GetFromResource("Mobile Phone No:") %>'></asp:Literal></asp:Label>
        </td>
        <td colspan="1" style="WIDTH: 30%">
            <asp:TextBox ID="MobilePhoneNoTextBox" runat="server" Text='<%# Bind("MobilePhoneNo") %>' ValidationGroup="Edit" Width="168px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right" class="FormViewLabelCell" style="WIDTH: 20%">
            <asp:Literal ID="Literal17" runat="server" Text='<%# ResourceHelper.GetFromResource("TimeZone:") %>'></asp:Literal>
        </td>
        <td style="WIDTH: 30%" width="40%">
            <asp:DropDownList ID="ddlTimeZoneId" runat="server" DataSourceID="dsTimeZone" DataTextField="TimeZoneName" DataValueField="SystemTimeZoneId" SelectedValue='<%# Bind("TimeZoneId") %>' ValidationGroup="Edit" Width="98%"></asp:DropDownList>
        </td>
        <td align="right" class="FormViewLabelCell" colspan="1" style="WIDTH: 20%">&nbsp;</td>
        <td colspan="1" style="WIDTH: 30%">&nbsp;</td>
    </tr>
    <%If DBUtilities.IsAttendanceFeature Then%>
    <tr>
        <td align="right" class="FormViewLabelCell" style="height: 26px; width: 20%;">
            <asp:Literal ID="Literal44" runat="server" Text='<%# ResourceHelper.GetFromResource("Enable Time In/Out Option:") %>' />
        </td>
        <td colspan="1" style="width: 30%; height: 26px"><asp:CheckBox ID="chkTimeinOut" runat="server" /></td>
    </tr>
    <%End If%>
    <tr>
        <th class="FormViewSubHeader" colspan="4"><asp:Literal ID="Literal18" runat="server" Text='<%# ResourceHelper.GetFromResource("Login / Employee Information") %>'></asp:Literal>
        </th>
    </tr>
    <tr>
        <td align="right" class="FormViewLabelCell" style="WIDTH: 20%">
            <span class="reqasterisk">*</span><asp:Label ID="Label28" runat="server" AssociatedControlID="EMailAddressTextBox"> 
            <asp:Literal ID="Literal19" runat="server" Text='<%# ResourceHelper.GetFromResource("Login Email Address:") %>'></asp:Literal></asp:Label>
        </td>
        <td colspan="3" style="">
            <asp:TextBox ID="EMailAddressTextBox" runat="server" OnTextChanged="EMailAddressTextBox_TextChanged" Text='<%# Bind("EMailAddress") %>' ValidationGroup="Edit" Width="168px"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="EMailAddressTextBox" CssClass="ErrorMessage" Display="Dynamic" ErrorMessage="Incorrect EMail Address" Font-Bold="True" Font-Names="Verdana" Font-Size="X-Small" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="Edit"></asp:RegularExpressionValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="EMailAddressTextBox" CssClass="ErrorMessage" Display="Dynamic" ErrorMessage="*" ValidationGroup="Edit" Width="8px"></asp:RequiredFieldValidator><asp:Label ID="lblExceptionText" runat="server" CssClass="ErrorMessage" Text="Login Already Exist" Visible="False"></asp:Label>
        </td>
    </tr>
<% If LDAP.IsAspNetActiveDirectoryMembershipProvider <> True Then%>
    <tr>
        <td align="right" class="FormViewLabelCell" style="WIDTH: 20%">
            <span class="reqasterisk">*</span><asp:Label ID="Label30" runat="server" AssociatedControlID="PasswordTextBox"> <asp:Literal ID="Literal20" runat="server" Text='<%# ResourceHelper.GetFromResource("Password:") %>'></asp:Literal></asp:Label>
        </td>
        <td style="WIDTH: 30%" width="40%">
            <asp:TextBox ID="PasswordTextBox" runat="server" Text='<%# Bind("Password") %>' TextMode="Password" ValidationGroup="Edit" Width="168px"></asp:TextBox>&nbsp;
            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="PasswordTextBox" Display="Dynamic" SkinID="PasswordValidator" ValidationExpression="(?=^.{8,}$)(?=.*\d)(?=.*\W+)(?![.\n]).*$"></asp:RegularExpressionValidator>
        </td>
        <td align="right" class="FormViewLabelCell" colspan="1" style="WIDTH: 20%" valign="middle">
            <span class="reqasterisk">*</span><asp:Label ID="Label31" runat="server" AssociatedControlID="VerifyPasswordTextbox"> <asp:Literal ID="Literal21" runat="server" Text='<%# ResourceHelper.GetFromResource("Verify Password:") %>'></asp:Literal></asp:Label>
        </td>
        <td colspan="1" style="WIDTH: 30%" valign="middle">
            <asp:TextBox ID="VerifyPasswordTextbox" runat="server" TextMode="Password" ValidationGroup="Edit" Width="168px"></asp:TextBox>&nbsp;
            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="VerifyPasswordTextbox" ControlToValidate="PasswordTextBox" CssClass="ErrorMessage" Display="Dynamic" ErrorMessage="(Mismatch)" ValidationGroup="Edit"></asp:CompareValidator>
        </td>
    </tr>
<%End If%>
    <tr>
        <td align="right" class="FormViewLabelCell" style="WIDTH: 20%">
            <asp:Label ID="Label35" runat="server" AssociatedControlID="TextBox2"> <asp:Literal ID="Literal76" runat="server" Text='<%# ResourceHelper.GetFromResource("Job Title:") %>' /></asp:Label></td><td style="WIDTH: 30%" width="40%"><asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("JobTitle") %>' Width="168px"></asp:TextBox></td><td align="right" class="FormViewLabelCell" colspan="1" style="WIDTH: 20%" valign="middle"><span class="reqasterisk">*</span><asp:Literal ID="Literal23" runat="server" Text='<%# ResourceHelper.GetFromResource("Department:") %>' /></td>
        <td colspan="1" style="WIDTH: 30%" valign="middle"><asp:DropDownList ID="ddlAccountDepartmentId" runat="server" DataSourceID="dsAccountDepartmentObject" DataTextField="DepartmentName" DataValueField="AccountDepartmentId" ValidationGroup="Edit" Width="180px"></asp:DropDownList></td>
    </tr>
    <tr>
        <td align="right" class="FormViewLabelCell" style=" width: 20%;">
            <span class="reqasterisk">*</span> <asp:Literal ID="Literal22" runat="server" Text='<%# ResourceHelper.GetFromResource("Role:") %>' />
        </td>
        <td style=" width: 30%;" width="40%">
            <asp:DropDownList ID="ddlAccountRoleId" runat="server" DataSourceID="dsAccountRoleObject" DataTextField="Role" DataValueField="AccountRoleId" ValidationGroup="Edit" Width="180px"></asp:DropDownList>
        </td>
        <td align="right" class="FormViewLabelCell" colspan="1" style=" width: 20%;">
            <asp:Literal ID="Literal25" runat="server" Text='<%# ResourceHelper.GetFromResource("Employee Manager:") %>' /></td>
        <td colspan="1" style="width: 30%"><asp:DropDownList ID="ddlEmployeeManagerId" runat="server" AppendDataBoundItems="True" DataSourceID="dsEmployeeManagerObject" DataTextField="FullName" DataValueField="AccountEmployeeId" Width="180px"><asp:ListItem ID="Label9" runat="server" Label="" Selected="True" Text="<%$ Resources:TimeLive.Resource, None%> " Value="0"></asp:ListItem></asp:DropDownList></td></tr><tr>
        <td align="right" class="FormViewLabelCell" style=" width: 20%;"><span class="reqasterisk">*</span> <asp:Literal ID="Literal24" runat="server" Text='<%# ResourceHelper.GetFromResource("Location:")%>' /></td>
        <td style=" width: 30%;" width="40%">
            <asp:DropDownList ID="ddlAccountLocationId" runat="server" DataSourceID="dsAccountLocation" DataTextField="AccountLocation" DataValueField="AccountLocationId" ValidationGroup="Edit" Width="180px"></asp:DropDownList>
        </td>
        <td align="right" class="FormViewLabelCell" colspan="1" style=" width: 20%;">
            <asp:Literal ID="Literal73" runat="server" Text='<%# ResourceHelper.GetFromResource("Employee Status:") %>' /></td>
        <td colspan="1" style="width: 30%">
            <asp:DropDownList ID="ddlEmployeeStatusId" runat="server" DataSourceID="dsEmployeeStatusObject" DataTextField="Status" DataValueField="AccountStatusId" Width="180px"></asp:DropDownList></td>
    </tr>
    <tr>
        <td align="right" class="FormViewLabelCell" style="width: 20%">
            <asp:Literal ID="Literal72" runat="server" Text='<%# ResourceHelper.GetFromResource("Employee Type:") %>' />
        </td>
        <td style="width: 30%" width="40%">
            <asp:DropDownList ID="ddlEmployeeTypeId" runat="server" DataSourceID="dsEmployeeTypeObject" DataTextField="AccountEmployeeType" DataValueField="AccountEmployeeTypeId" Width="180px"></asp:DropDownList>
        </td>
        <td align="right" class="FormViewLabelCell" colspan="1" style="width: 20%">
            <asp:Literal ID="Literal81" runat="server" Text='<%# ResourceHelper.GetFromResource("Working Day Type:") %>' /></td>
        <td colspan="1" style="width: 30%">
            <asp:DropDownList ID="ddlWorkingDayTypeId" runat="server" DataSourceID="dsWorkingDayTypeObject" DataTextField="AccountWorkingDayType" DataValueField="AccountWorkingDayTypeId" Width="180px"></asp:DropDownList><asp:RequiredFieldValidator ID="RFVWorkingDayType" runat="server" ControlToValidate="ddlWorkingDayTypeId" CssClass="ErrorMessage" Display="Dynamic" ErrorMessage="*" ValidationGroup="Insert" Width="16px"></asp:RequiredFieldValidator></td></tr><tr>
        <td align="right" class="FormViewLabelCell" style="width: 20%">
            <asp:Literal ID="Literal82" runat="server" Text='<%# ResourceHelper.GetFromResource("Employee Time Of Policy:") %>' /></td>
        <td style="width: 30%" width="40%">
            <asp:DropDownList ID="ddlEmployeePolicyId" runat="server" AppendDataBoundItems="True" DataSourceID="dsEmployeePolicyObject" DataTextField="AccountTimeOffPolicy" DataValueField="AccountTimeOffPolicyId" Width="180px"><asp:ListItem Value="0">None</asp:ListItem></asp:DropDownList></td><td align="right" class="FormViewLabelCell" colspan="1" style="width: 20%">
            <asp:Literal ID="Literal83" runat="server" Text='<%# ResourceHelper.GetFromResource("Time Off Approval Type:") %>' /></td>
        <td colspan="1" style="width: 30%">
            <asp:DropDownList ID="ddlTimeOffApprovalTypeId" runat="server" AppendDataBoundItems="True" DataSourceID="dsTimeOffApprovalTypeObject" DataTextField="ApprovalTypeName" DataValueField="AccountApprovalTypeId" Width="180px"><asp:ListItem Value="0">Approval Not Required</asp:ListItem></asp:DropDownList></td></tr><tr>
        <td align="right" class="FormViewLabelCell" style="width: 20%">
            <asp:Literal ID="Literal85" runat="server" Text='<%# ResourceHelper.GetFromResource("Holiday Type:") %>' /></td>
        <td style="width: 30%" width="40%">
            <asp:DropDownList ID="ddlHolidayTypeId" runat="server" AppendDataBoundItems="True" DataSourceID="dsHolidayTypeObject" DataTextField="AccountHolidayType" DataValueField="AccountHolidayTypeId" Width="180px"><asp:ListItem Value="0">None</asp:ListItem></asp:DropDownList></td><td align="right" class="FormViewLabelCell" colspan="1" style="width: 20%">
            <asp:Literal ID="Literal40" runat="server" Text='<%# ResourceHelper.GetFromResource("User Interface Language:") %>' /></td>
        <td colspan="1" style="width: 30%">
            <asp:DropDownList ID="ddlUserInterfaceLanguage" runat="server" AppendDataBoundItems="True" Width="180px"><asp:ListItem Value="en-US">English (United States)</asp:ListItem><asp:ListItem Value="de-DE">German (Germany)</asp:ListItem><asp:ListItem Value="fr-FR">French (France)</asp:ListItem><asp:ListItem Value="zh-CN">Chinese (Simplified, PRC)</asp:ListItem><asp:ListItem Value="it-IT">Italian (Italy)</asp:ListItem><asp:ListItem Value="nl-NL">Dutch (Netherlands)</asp:ListItem><asp:ListItem Value="es-ES">Spanish (Spain)</asp:ListItem><asp:ListItem Value="sv-SE">Swedish (Sweden)</asp:ListItem><asp:ListItem Value="pt-PT">Portuguese (Portugal)</asp:ListItem><asp:ListItem Value="nn-NO">Norwegian, Nynorsk (Norway)</asp:ListItem></asp:DropDownList></td></tr><tr>
        <td align="right" class="FormViewLabelCell" style="width: 20%"><asp:Literal ID="Literal74" runat="server" Text='<%# ResourceHelper.GetFromResource("Hired Date:") %>' /></td>
        <td style="width: 30%" width="40%"><ew:CalendarPopup ID="HiredDateCalendarPopup" runat="server" SelectedDate="" SelectedValue="07/14/2009 17:21:36" SkinId="DatePicker" Text="..." UpperBoundDate="12/31/9999 23:59:59" VisibleDate="" Width="73px"></ew:CalendarPopup></td>
        <td align="right" class="FormViewLabelCell" colspan="1" style="width: 20%"><asp:Literal ID="Literal75" runat="server" Text='<%# ResourceHelper.GetFromResource("Termination Date:") %>' /></td><td colspan="1" style="width: 30%"><ew:CalendarPopup ID="TerminationDateCalendarPopup" runat="server" Nullable="True" PostedDate="" SkinId="DatePicker" Text="..." VisibleDate="" Width="73px"></ew:CalendarPopup></td>
    </tr>
    <tr>
        <td align="right" class="FormViewLabelCell" style="width: 20%">
            <asp:Literal ID="Literal26" runat="server" Text='<%# ResourceHelper.GetFromResource("Disabled:") %>' />
        </td>
        <td style="width: 30%" width="40%">
            <asp:CheckBox ID="chkIsDisabled" runat="server" Checked='<%# Bind("IsDisabled") %>' Enabled='<%# IIF((Eval("AccountEmployeeId")=DBUtilities.GetSessionAccountEmployeeId),False,True) %>' />
        </td>
        <td align="right" class="FormViewLabelCell" colspan="1" style="width: 20%">
<% If LDAP.IsAspNetActiveDirectoryMembershipProvider <> True Then%>  
                            <asp:Literal ID="Literal4" runat="server" Text='<%# ResourceHelper.GetFromResource("Force Password Change:") %>' />
<% End If%>  
        </td>
        <td colspan="1" style="width: 30%">
<% If LDAP.IsAspNetActiveDirectoryMembershipProvider <> True Then%>  
            <asp:CheckBox ID="chkForcePasswordChange" runat="server" Checked='<%# Bind("IsForcePasswordChange") %>' />
<% End If%>  
        </td>
    </tr>

    <tr id="Billingratetr" runat="server">
        <th class="FormViewSubHeader" colspan="4">
        <asp:Literal ID="Literal27" runat="server" Text='<%# ResourceHelper.GetFromResource("Billing Rate") %>' /></th>
    </tr>
    <tr id="billingtypetr" runat="server">
        <td align="right" class="FormViewLabelCell" style="width: 20%; height: 24px;">
            <asp:Literal ID="Literal28" runat="server" Text='<%# ResourceHelper.GetFromResource("Work Type:") %>' /></td>
        <td style="width: 30%; height: 24px;" width="40%">
            <asp:DropDownList ID="ddlAccountWorkTypeId" runat="server" AutoPostBack="True" DataSourceID="dsAccountWorkTypeObject" DataTextField="AccountWorkType" DataValueField="AccountWorkTypeId" OnSelectedIndexChanged="ddlAccountWorkTypeId_SelectedIndexChanged" Width="120px"></asp:DropDownList>
        </td>
        <td align="right" class="FormViewLabelCell" colspan="1" style="width: 20%; height: 24px;">
            <asp:Literal ID="Literal35" runat="server" Text='<%# ResourceHelper.GetFromResource("Billing Type:") %>' />
        </td>
        <td colspan="1" style="width: 30%; height: 24px;">
            <asp:DropDownList ID="dllBillingTypeEdit" runat="server" AppendDataBoundItems="True" DataSourceID="dsAccountBillingTypeObject" DataTextField="BillingType" DataValueField="AccountBillingTypeId" Enabled="False" Width="120px">
                <asp:ListItem ID="Label1" runat="server" Label="" Text="<%$ Resources:TimeLive.Resource, None%> "></asp:ListItem></asp:DropDownList></td>
    </tr>
    <tr id="employeecurrencytr" runat="server">
        <td align="right" class="FormViewLabelCell" style="width: 20%; height: 24px;">
            <asp:Literal ID="Literal29" runat="server" Text='<%# ResourceHelper.GetFromResource("Employee Rate Currency:") %>' /></td>
        <td style="width: 30%; height: 24px;" width="40%">
            <asp:DropDownList ID="ddlEmployeeRateCurrencyId" runat="server" DataSourceID="dsEmployeeRateCurrencyObject" DataTextField="CurrencyCode" DataValueField="AccountCurrencyId" Width="120px"></asp:DropDownList></td>
        <td align="right" class="FormViewLabelCell" colspan="1" style="width: 20%; height: 24px;">
            <asp:Label ID="Label36" runat="server" AssociatedControlID="EmployeeRateTextBox"> 
            <asp:Literal ID="Literal30" runat="server" Text='<%# ResourceHelper.GetFromResource("Employee Rate:") %>' /></asp:Label></td><td colspan="1" style="width: 30%; height: 24px;">
            <asp:TextBox ID="EmployeeRateTextBox" runat="server" Width="106px" style="text-align:right;"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="EmployeeRateTextBox" CssClass="ErrorMessage" Display="Dynamic" ErrorMessage="*" Width="16px"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeValidator3" runat="server" ControlToValidate="EmployeeRateTextBox" CssClass="ErrorMessage" Display="Dynamic" ErrorMessage="Numeric Required" Font-Bold="True" Font-Names="Verdana" Font-Size="X-Small" MaximumValue="999999999" MinimumValue="0" Type="Double" ></asp:RangeValidator></td>
    </tr>
    <tr id="billingcurrencytr" runat="server">
        <td align="right" class="FormViewLabelCell" style="width: 20%;">
            <asp:Literal ID="Literal31" runat="server" Text='<%# ResourceHelper.GetFromResource("Billing Rate Currency:") %>' />
        </td>
        <td style=" width: 30%;" width="40%">
            <asp:DropDownList ID="ddlBillingRateCurrencyId" runat="server" DataSourceID="dsBillingRateCurrencyObject" DataTextField="CurrencyCode" DataValueField="AccountCurrencyId" Width="120px"></asp:DropDownList>
        </td>
        <td align="right" class="FormViewLabelCell" colspan="1" style=" width: 20%;">
            <asp:Label ID="Label38" runat="server" AssociatedControlID="BillingRateTextBox">
            <asp:Literal ID="Literal32" runat="server" Text='<%# ResourceHelper.GetFromResource("Billing Rate:") %>' /></asp:Label></td><td colspan="1" style="width: 30%">
            <asp:TextBox ID="BillingRateTextBox" runat="server" Width="106px" style="text-align:right;"></asp:TextBox>&nbsp; 
            <asp:LinkButton ID="lnkBillingRateHistory" runat="server" OnClick="LinkButton1_Click" Visible='<%# IIF(IsDBNULL(Eval("AccountBillingRateId")) orelse Eval("AccountBillingRateId")=0,False,True) %>'>
            <asp:Literal ID="Literal71" runat="server" Text="<%$ Resources:TimeLive.Resource, Billing Rate History%> " />
            </asp:LinkButton><br />
            <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="BillingRateTextBox" CssClass="ErrorMessage" Display="Dynamic" ErrorMessage="Numeric Required" Font-Bold="True" Font-Names="Verdana" Font-Size="X-Small" MaximumValue="999999999" MinimumValue="0" Type="Double" ></asp:RangeValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="BillingRateTextBox" CssClass="ErrorMessage" Display="Dynamic" ErrorMessage="*" Width="16px"></asp:RequiredFieldValidator></td>
    </tr>
    <tr id="billingdatetr" runat="server">
        <td align="right" class="FormViewLabelCell" style=" width: 20%;">
            <asp:Literal ID="Literal33" runat="server" Text='<%# ResourceHelper.GetFromResource("Billing Rate Start Date:") %>' />
        </td>
        <td style=" width: 30%;" width="40%">
            <ew:CalendarPopup ID="BillingRateStartDate" runat="server" Nullable="True" SkinId="DatePicker" Text="..." UpperBoundDate="12/31/9999 23:59:59" Width="73px"></ew:CalendarPopup>
        </td>
        <td align="right" class="FormViewLabelCell" colspan="1" style=" width: 20%;">
            <asp:Literal ID="Literal34" runat="server" Text='<%# ResourceHelper.GetFromResource("Billing Rate End Date:") %>' />
        </td>
        <td colspan="1" style="width: 30%">
            <ew:CalendarPopup ID="BillingRateEndDateTextBox" runat="server" Nullable="True" PostedDate="" SelectedDate="" SkinId="DatePicker" Text="..." VisibleDate="" Width="73px"></ew:CalendarPopup>
        </td>
    </tr>

    <tr>
        <th class="FormViewSubHeader" colspan="4"><asp:Literal ID="Literal36" runat="server" Text='<%# ResourceHelper.GetFromResource("Advanced") %>' /></th>
    </tr>
    <tr>
        <td align="right" class="FormViewLabelCell" style="width: 20%"><asp:Literal ID="Literal37" runat="server" Text='<%# ResourceHelper.GetFromResource("Access Allowed From IP:") %>' /></td>
        <td style="width: 30%" width="40%"><asp:TextBox ID="AccessAllowedFromIPTextBox" runat="server" Text='<%# Bind("AllowedAccessFromIP") %>' Width="168px"></asp:TextBox></td><td align="right" class="FormViewLabelCell" colspan="1" style="width: 20%"></td>
        <td colspan="1" style="width: 30%"></td>
    </tr>
    <tr>
        <th class="FormViewSubHeader" colspan="4"><asp:Literal ID="Literal86" runat="server" Text='<%# ResourceHelper.GetFromResource("Electronic Signature") %>' /></th>
    </tr>
    <tr>
        <td align="right" class="FormViewLabelCell" style="width: 20%"><asp:Literal ID="Literal87" runat="server" Text='<%# ResourceHelper.GetFromResource("Electronic Signature:") %>' /></td>
        <td width="50%" colspan="2"><asp:FileUpload ID="txtElectronicSign" runat="server" Width="539px"/></td><td colspan="1" style="width: 30%"></td>
    </tr>
    <tr>
        <td align="right" class="FormViewLabelCell" style="width: 20%">&nbsp;</td><td colspan="2" width="50%"><asp:Label ID="lblESignSize" runat="server" ForeColor="Red" Text="Electronic signature size (Width 180px Height 50px)"></asp:Label></td><td colspan="1" style="width: 30%">&nbsp;</td></tr><tr>
        <th class="FormViewSubHeader" colspan="4"><asp:Literal ID="Literal96" runat="server" Text='<%# ResourceHelper.GetFromResource("Profile Picture") %>' /></th>
    </tr>
    <tr>
        <td align="right" class="FormViewLabelCell" style="width: 20%"><asp:Literal ID="Literal88" runat="server" Text='<%# ResourceHelper.GetFromResource("Show Employee Profile Picture:") %>' /></td>
        <td colspan="2" width="50%"><asp:CheckBox ID="chkIsShowEmployeePicture" runat="server" /></td><td colspan="1" style="width: 30%">&nbsp;</td></tr><tr>
        <td align="right" class="FormViewLabelCell" style="width: 20%"><asp:Literal ID="Literal89" runat="server" Text='<%# ResourceHelper.GetFromResource("Image:") %>' /></td><td colspan="2" width="50%"><asp:FileUpload ID="FileUpload1" runat="server" Width="539px" /></td><td colspan="1" style="width: 30%">&nbsp;</td></tr><tr>
        <td align="right" class="FormViewLabelCell" style="width: 20%">&nbsp;</td><td colspan="2" width="50%"><asp:Label ID="lblImage" runat="server" ForeColor="Red" Text="Image size (Width 64px Height 64px)"></asp:Label></td><td colspan="1" style="width: 30%">&nbsp;</td></tr><tr>
        <td colspan="4"><asp:Table ID="CustomTableEdit" runat="server" Width="100%"></asp:Table></td>
    </tr>
    <tr>
        <td class="FormViewLabelCell" colspan="3">&nbsp;</td><td colspan="1" style="width: 30%; padding-bottom: 5px;">
            <asp:Button ID="Update" runat="server" CommandName="Update" OnClick="Update_Click1" Text="<%$ Resources:TimeLive.Resource, Update_text%> " ValidationGroup="Edit" Width="68px" />&nbsp; <asp:Button ID="Cancel" runat="server" CommandName="Cancel" OnClick="Cancel_Click" Text="<%$ Resources:TimeLive.Resource, Cancel_text%> " ValidationGroup="Edit" Width="68px" /><br />
            <asp:CustomValidator ID="CustomValidator2" runat="server" CssClass="ErrorMessage" Display="Dynamic" ErrorMessage="Invalid username or password" OnServerValidate="CustomValidator2_ServerValidate" ValidationGroup="Edit"></asp:CustomValidator></td></tr></tbody></table></EditItemTemplate><InsertItemTemplate>
    <table style="WIDTH: 100%" id="Table1" ><tbody>
    <tr>
        <th style="WIDTH: 20%" class="caption" colspan="4"><asp:Literal id="Literal37" runat="server" Text='<%# ResourceHelper.GetFromResource("Add Employee") %>'> </asp:Literal></th></tr><%--    <tr>
        <th style="WIDTH: 20%" class="FormViewSubHeader" colspan=4><asp:Literal id="Literal38" runat="server" Text='<%# ResourceHelper.GetFromResource("Personal Information") %>'> </asp:Literal></th>
    </tr>--%><%--    <tr>
        <td style="WIDTH: 20%" class="FormViewLabelCell" align="right">
            <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="EmployeeCodeTextBox"> <asp:Literal id="Literal39" runat="server" Text='<%# ResourceHelper.GetFromResource("Employee Code:") %>'> </asp:Literal></asp:Label></td><td colspan=3><asp:TextBox id="EmployeeCodeTextBox" runat="server" Width="168px" Text='<%# Bind("EmployeeCode") %>' MaxLength="50" ValidationGroup="Insert" OnPreRender="UsernameTextBox_PreRender"></asp:TextBox></td>
    </tr>--%><tr>
        <th style="WIDTH: 20%" class="FormViewSubHeader" colspan="4"><asp:Literal ID="Literal54" runat="server" Text='<%# ResourceHelper.GetFromResource("Login / Employee Information") %>'></asp:Literal></th></tr><% Dim LDAP As New LDAPUtilitiesBLL%><% If LDAP.IsAspNetActiveDirectoryMembershipProvider = True Then%><tr>
        <td style="WIDTH: 20%" class="FormViewLabelCell" align="right">
            <span class="reqasterisk">*</span> <asp:Label ID="Label3" runat="server" AssociatedControlID="UsernameTextBox"> 
            <asp:Label id="lblUsername" runat="server" Text='<%# ResourceHelper.GetFromResource("Username:") %>'></asp:Label></asp:Label></td><td colspan="3">
            <asp:TextBox ID="UsernameTextBox" runat="server" Width="168px" Text='<%# Bind("Username") %>' ValidationGroup="Insert" OnPreRender="UsernameTextBox_PreRender"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="UsernameTextBox" CssClass="ErrorMessage" Display="Dynamic" ErrorMessage="*" ValidationGroup="Insert" Width="1px"></asp:RequiredFieldValidator>&nbsp; <asp:Button ID="btnGetUserData" onclick="btnGetUserData_Click" runat="server" Width="50px" Text="Get"></asp:Button>
            <asp:CustomValidator id="CustomValidator1" runat="server" OnServerValidate="CustomValidator1_ServerValidate" ErrorMessage="Specified user not exist" Display="Dynamic" CssClass="ErrorMessage"></asp:CustomValidator></td></tr><% End If%><tr>
        <td align="right" class="FormViewLabelCell" style="WIDTH: 20%"><span class="reqasterisk">*</span> <asp:Label ID="Label29" runat="server" AssociatedControlID="EMailAddressTextBox"> 
            <asp:Literal ID="Literal55" runat="server" Text='<%# ResourceHelper.GetFromResource("Login Email Address:") %>'></asp:Literal></asp:Label></td><td colspan="3"><asp:TextBox ID="EMailAddressTextBox" runat="server" OnTextChanged="EMailAddressTextBox_TextChanged" Text='<%# Bind("EMailAddress") %>' ValidationGroup="Insert" Width="168px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="EMailAddressTextBox" CssClass="ErrorMessage" Display="Dynamic" ErrorMessage="*" ValidationGroup="Insert" Width="8px"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="EMailAddressTextBox" CssClass="ErrorMessage" Display="Dynamic" ErrorMessage="Incorrect EMail Address" Font-Bold="True" Font-Names="Verdana" Font-Size="X-Small" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="Insert"></asp:RegularExpressionValidator><asp:Label ID="lblExceptionText" runat="server" CssClass="ErrorMessage" Text="Login Already Exist" Visible="False"></asp:Label></td></tr><tr>
        <td style="WIDTH: 20%" class="FormViewLabelCell" align="right">
            <span class="reqasterisk">*</span> <asp:Label ID="Label6" runat="server" AssociatedControlID="FirstNameTextBox">
            <asp:Literal id="Literal41" runat="server" Text='<%# ResourceHelper.GetFromResource("First Name:") %>'></asp:Literal></asp:Label></td><td style="WIDTH: 30%" width="40%">
            <asp:TextBox id="FirstNameTextBox" runat="server" Width="168px" Text='<%# Bind("FirstName") %>' ValidationGroup="Insert"></asp:TextBox><asp:RequiredFieldValidator id="RequiredFieldValidator4" runat="server" Width="1px" ValidationGroup="Insert" ErrorMessage="*" Display="Dynamic" CssClass="ErrorMessage" ControlToValidate="FirstNameTextBox"></asp:RequiredFieldValidator></td><td style="WIDTH: 20%" class="FormViewLabelCell" align="right">
            <span class="reqasterisk">*</span> <asp:Label ID="Label2" runat="server" AssociatedControlID="LastNameTextBox">
            <asp:Literal id="Literal39" runat="server" Text='<%# ResourceHelper.GetFromResource("Last Name:") %>'></asp:Literal></asp:Label></td><td style="WIDTH: 30%">
            <asp:TextBox ID="LastNameTextBox" runat="server" Text='<%# Bind("LastName") %>' ValidationGroup="Insert" Width="168px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="LastNameTextBox" CssClass="ErrorMessage" Display="Dynamic" ErrorMessage="*" ValidationGroup="Insert" Width="1px"></asp:RequiredFieldValidator></td></tr><% If LDAP.IsAspNetActiveDirectoryMembershipProvider <> True Then%><tr>
        <td style="WIDTH: 20%" class="FormViewLabelCell" align="right"><span class="reqasterisk">*</span> <asp:Label ID="Label32" runat="server" AssociatedControlID="PasswordTextBox"> 
            <asp:Literal id="Literal56" runat="server" Text='<%# ResourceHelper.GetFromResource("Password:") %>'></asp:Literal></asp:Label></td><td style="WIDTH: 30%" width="40%">
            <asp:TextBox id="PasswordTextBox" runat="server" Text='<%# Bind("Password") %>' ValidationGroup="Insert" TextMode="Password" Width="168px"></asp:TextBox><asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" Width="16px" ValidationGroup="Insert" ErrorMessage="*" Display="Dynamic" CssClass="ErrorMessage" ControlToValidate="PasswordTextBox"></asp:RequiredFieldValidator><asp:RegularExpressionValidator id="RegularExpressionValidator2" runat="server" SkinID="PasswordValidator" ControlToValidate="PasswordTextBox" ValidationExpression="(?=^.{8,}$)(?=.*\d)(?=.*\W+)(?![.\n]).*$" Display="Dynamic"></asp:RegularExpressionValidator></td><td style="WIDTH: 20%" class="FormViewLabelCell" valign="middle" align="right" colspan="1"><span class="reqasterisk">*</span> <asp:Label ID="Label33" runat="server" AssociatedControlID="VerifyPasswordTextbox">
            <asp:Literal id="Literal57" runat="server" Text='<%# ResourceHelper.GetFromResource("Verify Password:") %>'></asp:Literal>
            </asp:Label></td><td style="WIDTH: 30%" valign="middle" colspan="1">
            <asp:TextBox id="VerifyPasswordTextbox" runat="server" ValidationGroup="Insert" TextMode="Password" Width="168px"></asp:TextBox><asp:RequiredFieldValidator id="RequiredFieldValidator3" runat="server" ValidationGroup="Insert" ErrorMessage="*" Display="Dynamic" CssClass="ErrorMessage" ControlToValidate="VerifyPasswordTextbox"></asp:RequiredFieldValidator><asp:CompareValidator id="CompareValidator1" runat="server" ValidationGroup="Insert" ErrorMessage="(Mismatch)" CssClass="ErrorMessage" ControlToValidate="PasswordTextBox" ControlToCompare="VerifyPasswordTextbox"></asp:CompareValidator></td></tr><%End If%><tr>
        <td style="WIDTH: 20%" class="FormViewLabelCell" align="right"><span class="reqasterisk">*</span> <asp:Label ID="Label34" runat="server" AssociatedControlID="ddlAccountRoleId"> 
            <asp:Literal ID="Literal42" runat="server" Text='<%# ResourceHelper.GetFromResource("Role:") %>'></asp:Literal></asp:Label></td><td style="WIDTH: 30%" width="40%">
            <asp:DropDownList ID="ddlAccountRoleId" runat="server" DataSourceID="dsAccountRoleObjectInsert" DataTextField="Role" DataValueField="AccountRoleId" SelectedValue='<%# Bind("AccountRoleId") %>' Width="180px"></asp:DropDownList>
        </td>
        <td style="WIDTH: 20%" class="FormViewLabelCell" align="right" colspan="1">
            <span class="reqasterisk">*</span> <asp:Label ID="Label8" runat="server" AssociatedControlID="ddlAccountDepartmentId">
            <asp:Literal id="Literal43" runat="server" Text='<%# ResourceHelper.GetFromResource("Department:") %>'></asp:Literal></asp:Label></td><td style="WIDTH: 30%" colspan="1">
            <asp:DropDownList ID="ddlAccountDepartmentId" runat="server" DataSourceID="dsAccountDepartmentObjectInsert" DataTextField="DepartmentName" DataValueField="AccountDepartmentId" SelectedValue='<%# Bind("AccountDepartmentId") %>' Width="180px"></asp:DropDownList>
        </td>
    </tr>

    <tr>
        <td align="right" class="FormViewLabelCell" style="WIDTH: 20%"><span class="reqasterisk">*</span> <asp:Literal ID="Literal38" runat="server" Text='<%# ResourceHelper.GetFromResource("Hired Date:") %>'></asp:Literal></td><td style="WIDTH: 30%" width="40%">
            <ew:CalendarPopup ID="HiredDateCalendarPopup" runat="server" PostedDate="" SelectedValue='<%# Bind("StartDate") %>' SkinID="DatePicker" Width="73px"></ew:CalendarPopup>
        </td>
        <td align="right" class="FormViewLabelCell" colspan="1" style="WIDTH: 20%">

        </td>
        <td colspan="1" style="WIDTH: 30%">
            
        </td>
    </tr>
<%--    <tr>
        <td style="WIDTH: 20%" class="FormViewLabelCell" align="right">
            <span class="reqasterisk">*</span>
        </td>
        <td style="WIDTH: 30%" width="40%">
            
        </td>
        <td style="WIDTH: 20%" class="FormViewLabelCell" align="right" colspan="1">
            <asp:Literal ID="Literal81" runat="server" Text='<%# ResourceHelper.GetFromResource("Working Day Type:") %>'></asp:Literal></td><td style="WIDTH: 30%" colspan="1">

    </tr>--%>
<%--    <tr>
        <td style="WIDTH: 20%" class="FormViewLabelCell" align="right">
            <asp:Literal id="Literal82" runat="server" Text='<%# ResourceHelper.GetFromResource("Employee Time Of Policy:") %>'></asp:Literal></td>
        <td style="width: 30%" width="40%">
            <asp:DropDownList ID="ddlEmployeePolicyId" runat="server" AppendDataBoundItems="True" DataSourceID="dsEmployeePolicyObjectInsert" DataTextField="AccountTimeOffPolicy" DataValueField="AccountTimeOffPolicyId" Width="180px"><asp:ListItem Value="0">None</asp:ListItem></asp:DropDownList>
        </td>
        <td align="right" class="FormViewLabelCell" colspan="1" style="width: 20%">
            <asp:Literal ID="Literal84" runat="server" Text='<%# ResourceHelper.GetFromResource("Time Off Approval Type:") %>' /></td>
        <td colspan="1" style="width: 30%">
            <asp:DropDownList ID="ddlTimeOffApprovalTypeId" runat="server" AppendDataBoundItems="True" DataSourceID="dsTimeOffApprovalTypeObject" DataTextField="ApprovalTypeName" DataValueField="AccountApprovalTypeId" SelectedValue='<%# Bind("TimeOffApprovalTypeId") %>' Width="180px">
            <asp:ListItem Selected="True" Value="0">Approval Not Required</asp:ListItem></asp:DropDownList>
        </td>
    </tr>--%>
    <tr>
        <td colspan="4">
            <asp:Table ID="CustomTable" runat="server" Width="100%"></asp:Table>
        </td>
    </tr>
    <tr>
        <td align="right" class="FormViewLabelCell" colspan="3" style="width: 20%">&nbsp;</td><td colspan="1" style="WIDTH: 30%; padding-bottom: 5px;">
            <asp:Button ID="Add" runat="server" CommandName="Insert" OnClick="Add_Click" Text="<%$ Resources:TimeLive.Resource, Add_text%> " ValidationGroup="Insert" Width="68px" />&nbsp; <asp:Button ID="Cancel" runat="server" CommandName="Cancel" OnClick="Cancel_Click" Text="<%$ Resources:TimeLive.Resource, Cancel_text%> " ValidationGroup="Add" Width="68px" />
            <asp:CustomValidator ID="CustomValidator2" runat="server" CssClass="ErrorMessage" Display="Dynamic" ErrorMessage="Specified user not exist" OnServerValidate="CustomValidator2_ServerValidate" ValidationGroup="Insert"></asp:CustomValidator></td></tr></tbody></table></InsertItemTemplate></asp:FormView><asp:ObjectDataSource id="dsAccountEmployeeObject" runat="server" UpdateMethod="UpdateAccountEmployee" DeleteMethod="DeleteAccountEmployee" InsertMethod="AddAccountEmployee" TypeName="AccountEmployeeBLL" SelectMethod="GetAccountEmployees" OldValuesParameterFormatString="original_{0}">
    <InsertParameters>
        <asp:Parameter Name="Username" Type="String" />
        <asp:Parameter Name="Password" Type="String" />
        <asp:Parameter Name="FirstName" Type="String" />
        <asp:Parameter Name="LastName" Type="String" />
        <asp:Parameter Name="EMailAddress" Type="String" />
        <asp:Parameter Name="EmployeeCode" Type="String" />
        <asp:Parameter Name="AccountId" Type="Int32" />
        <asp:Parameter Name="AccountDepartmentId" Type="Int32" />
        <asp:Parameter Name="AccountRoleId" Type="Int32" />
        <asp:Parameter Name="AccountLocationId" Type="Int32" />
        <asp:Parameter Name="CountryId" Type="Int16" />
        <asp:Parameter Name="BillingTypeId" Type="Int32" />
        <asp:Parameter Name="StartDate" Type="DateTime" />
        <asp:Parameter Name="DefaultProjectId" Type="Int32" />
        <asp:Parameter Name="EmployeeManagerId" Type="Int32" />
        <asp:Parameter Name="TimeZoneId" Type="Byte" />
        <asp:Parameter Name="CreatedByEmployeeId" Type="Int32" />
        <asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" />
        <asp:Parameter Name="EmployeePayTypeId" />
        <asp:Parameter Name="StatusId" Type="Int32" />
        <asp:Parameter Name="JobTitle" Type="String" />
        <asp:Parameter Name="HiredDate" Type="DateTime" />
        <asp:Parameter Name="TerminationDate" Type="DateTime" />
        <asp:Parameter Name="AccountWorkingDayTypeId" />
        <asp:Parameter Name="AccountTimeOffPolicyId" />
        <asp:Parameter Name="TimeOffApprovalTypeId" Type="Int32" />
        <asp:Parameter Name="AccountHolidayTypeId" />
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
        <asp:Parameter Name="EmployeeCode" Type="String" />
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
        <asp:Parameter Name="BillingTypeId" Type="Int32" />
        <asp:Parameter Name="StartDate" Type="DateTime" />
        <asp:Parameter Name="TerminationDate" Type="DateTime" />
        <asp:Parameter Name="StatusId" Type="Int32" />
        <asp:Parameter Name="IsDeleted" Type="Boolean" />
        <asp:Parameter Name="IsDisabled" Type="Boolean" />
        <asp:Parameter Name="DefaultProjectId" Type="Int32" />
        <asp:Parameter Name="EmployeeManagerId" Type="Int32" />
        <asp:Parameter Name="TimeZoneId" Type="Byte" />
        <asp:Parameter Name="CreatedByEmployeeId" Type="Int32" />
        <asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" />
        <asp:Parameter Name="AllowedAccessFromIP" Type="String" />
        <asp:Parameter Name="Original_AccountEmployeeId" Type="Int32" />
        <asp:Parameter Name="EmployeePayTypeId" />
        <asp:Parameter Name="JobTitle" Type="String" />
        <asp:Parameter Name="HiredDate" Type="DateTime" />
        <asp:Parameter Name="AccountWorkingDayTypeId" />
        <asp:Parameter Name="AccountTimeOffPolicyId" />
        <asp:Parameter Name="TimeOffApprovalTypeId" Type="Int32" />
        <asp:Parameter Name="AccountHolidayTypeId" />
    </UpdateParameters>
</asp:ObjectDataSource> 
<asp:ObjectDataSource id="dsSystemCurrencyObject" runat="server" TypeName="SystemDataBLL" SelectMethod="GetCurrencies" OldValuesParameterFormatString="original_{0}">
</asp:ObjectDataSource> <asp:ObjectDataSource id="dsAccountDepartmentObject" runat="server" TypeName="AccountDepartmentBLL" SelectMethod="GetAccountDepartmentsByAccountIdAndIsDisabled" OldValuesParameterFormatString="original_{0}">
    <SelectParameters>
        <asp:SessionParameter DefaultValue="64" Name="AccountId" SessionField="AccountId"
            Type="Int32" />
        <asp:Parameter DefaultValue="" Name="AccountDepartmentId" Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource><asp:ObjectDataSource id="dsAccountDepartmentObjectInsert" runat="server" UpdateMethod="UpdateAccountDepartment" DeleteMethod="DeleteAccountDepartment" InsertMethod="AddAccountDepartment" TypeName="AccountDepartmentBLL" SelectMethod="GetAccountDepartmentsByAccountIdAndIsDisabled" OldValuesParameterFormatString="original_{0}">
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
    <SelectParameters>
        <asp:SessionParameter DefaultValue="64" Name="AccountId" SessionField="AccountId"
            Type="Int32" />
        <asp:Parameter DefaultValue="0" Name="AccountDepartmentId" Type="Int32" />
    </SelectParameters>
    <InsertParameters>
        <asp:Parameter Name="AccountId" Type="Int32" />
        <asp:Parameter Name="DepartmentCode" Type="String" />
        <asp:Parameter Name="DepartmentName" Type="String" />
        <asp:Parameter Name="CreatedByEmployeeId" Type="Int32" />
        <asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" />
    </InsertParameters>
</asp:ObjectDataSource> <asp:ObjectDataSource id="dsSystemNamePrefixObject" runat="server" TypeName="SystemDataBLL" SelectMethod="GetNamePrefix" OldValuesParameterFormatString="original_{0}"></asp:ObjectDataSource> <asp:ObjectDataSource id="dsAccountRoleObject" runat="server" UpdateMethod="UpdateAccountRole" DeleteMethod="DeleteAccountRole" InsertMethod="AddAccountRole" TypeName="AccountRoleBLL" SelectMethod="GetvueAccountRolesByIsSystemRoleAndIsDisabled" OldValuesParameterFormatString="original_{0}">
    <DeleteParameters>
        <asp:Parameter Name="original_AccountRoleId" Type="Int32" />
    </DeleteParameters>
    <UpdateParameters>
        <asp:Parameter Name="AccountId" Type="Int32" />
        <asp:Parameter Name="Role" Type="String" />
        <asp:Parameter Name="original_AccountRoleId" Type="Int32" />
        <asp:Parameter Name="IsDisabled" Type="Boolean" />
        <asp:Parameter Name="IsDeleted" Type="Boolean" />
        <asp:Parameter Name="CreatedOn" Type="DateTime" />
        <asp:Parameter Name="CreatedByEmployeeId" Type="Int32" />
        <asp:Parameter Name="ModifiedOn" Type="DateTime" />
        <asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" />
        <asp:Parameter Name="LDAPRole" Type="String" />
    </UpdateParameters>
    <SelectParameters>
        <asp:SessionParameter DefaultValue="64" Name="AccountId" SessionField="AccountId"
            Type="Int32" />
        <asp:Parameter Name="AccountRoleId" Type="Int32" />
    </SelectParameters>
    <InsertParameters>
        <asp:Parameter Name="AccountId" Type="Int32" />
        <asp:Parameter Name="Role" Type="String" />
        <asp:Parameter Name="CreatedByEmployeeId" Type="Int32" />
        <asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" />
        <asp:Parameter Name="LDAPRole" Type="String" />
    </InsertParameters>
</asp:ObjectDataSource> <asp:ObjectDataSource id="dsAccountRoleObjectInsert" runat="server" UpdateMethod="UpdateAccountRole" DeleteMethod="DeleteAccountRole" InsertMethod="AddAccountRole" TypeName="AccountRoleBLL" SelectMethod="GetvueAccountRolesByIsSystemRoleAndIsDisabled" OldValuesParameterFormatString="original_{0}">
            <DeleteParameters>
                <asp:Parameter Name="original_AccountRoleId" Type="Int32" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="AccountId" Type="Int32" />
                <asp:Parameter Name="Role" Type="String" />
                <asp:Parameter Name="original_AccountRoleId" Type="Int32" />
                <asp:Parameter Name="IsDisabled" Type="Boolean" />
                <asp:Parameter Name="IsDeleted" Type="Boolean" />
                <asp:Parameter Name="CreatedOn" Type="DateTime" />
                <asp:Parameter Name="CreatedByEmployeeId" Type="Int32" />
                <asp:Parameter Name="ModifiedOn" Type="DateTime" />
                <asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" />
                <asp:Parameter Name="LDAPRole" Type="String" />
            </UpdateParameters>
            <SelectParameters>
                <asp:SessionParameter DefaultValue="64" Name="AccountId" SessionField="AccountId"
            Type="Int32" />
                <asp:Parameter Name="AccountRoleId" Type="Int32" DefaultValue="0" />
            </SelectParameters>
            <InsertParameters>
                <asp:Parameter Name="AccountId" Type="Int32" />
                <asp:Parameter Name="Role" Type="String" />
                <asp:Parameter Name="CreatedByEmployeeId" Type="Int32" />
                <asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" />
                <asp:Parameter Name="LDAPRole" Type="String" />
            </InsertParameters>
</asp:ObjectDataSource> <asp:ObjectDataSource id="dsSystemCountryObject" runat="server" TypeName="SystemDataBLL" SelectMethod="GetCountries" OldValuesParameterFormatString="original_{0}"></asp:ObjectDataSource> <asp:ObjectDataSource id="dsEmployeeStatusObject" runat="server" TypeName="AccountStatusBLL" SelectMethod="GetAccountsStatusForEmployeeByIsDisabled" OldValuesParameterFormatString="original_{0}">
            <SelectParameters>
                <asp:SessionParameter Name="AccountId" SessionField="AccountId" Type="Int32" />
                <asp:Parameter Name="AccountStatusId" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource> <asp:ObjectDataSource id="dsEmployeeStatusObjectInsert" runat="server" TypeName="AccountStatusBLL" SelectMethod="GetAccountsStatusForEmployeeByIsDisabled" OldValuesParameterFormatString="original_{0}">
            <SelectParameters>
                <asp:SessionParameter Name="AccountId" SessionField="AccountId" Type="Int32" />
                <asp:Parameter DefaultValue="0" Name="AccountStatusId" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource> <asp:ObjectDataSource id="dsEmployeeTypeObject" runat="server" TypeName="AccountEmployeeTypeBLL" SelectMethod="GetAccountEmployeeTypeByAccountIdAndIsDisabled" OldValuesParameterFormatString="original_{0}">
            <SelectParameters>
                <asp:SessionParameter Name="AccountId" SessionField="AccountId" Type="Int32" />
                <asp:Parameter Name="AccountEmployeeTypeId" />
            </SelectParameters>
        </asp:ObjectDataSource> <asp:ObjectDataSource id="dsEmployeeTypeObjectInsert" runat="server" TypeName="AccountEmployeeTypeBLL" SelectMethod="GetAccountEmployeeTypeByAccountIdAndIsDisabled" OldValuesParameterFormatString="original_{0}">
            <SelectParameters>
                <asp:SessionParameter Name="AccountId" SessionField="AccountId" Type="Int32" />
                <asp:Parameter Name="AccountEmployeeTypeId" />
            </SelectParameters>
        </asp:ObjectDataSource> <asp:ObjectDataSource id="dsTimeZone" runat="server" TypeName="SystemDataBLL" SelectMethod="GetTimeZones" OldValuesParameterFormatString="original_{0}">
        </asp:ObjectDataSource> <asp:ObjectDataSource id="dsProjectObject" runat="server" TypeName="AccountProjectBLL" SelectMethod="GetAccountProjectsByAccountProjectId" OldValuesParameterFormatString="original_{0}">
            <SelectParameters>
                <asp:Parameter DefaultValue="3" Name="AccountProjectId" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource> <asp:ObjectDataSource id="dsAccountWorkTypeObject" runat="server" TypeName="AccountWorkTypeBLL" SelectMethod="GetAccountWorkTypesByAccountIdAndIsDisabled" OldValuesParameterFormatString="original_{0}">
                                <SelectParameters>
                                    <asp:SessionParameter DefaultValue="99" Name="AccountId" SessionField="AccountId"
                                        Type="Int32" />
                                    <asp:Parameter Name="AccountWorkTypeId" Type="Int32" />
                                </SelectParameters>
                            </asp:ObjectDataSource> <asp:ObjectDataSource id="dsAccountLocation" runat="server" TypeName="AccountLocationBLL" SelectMethod="GetAccountLocationsByAccountIdAndAccountLocationId" OldValuesParameterFormatString="original_{0}">
            <SelectParameters>
                <asp:SessionParameter DefaultValue="64" Name="AccountId" SessionField="AccountId"
                    Type="Int32" />
                <asp:Parameter Name="AccountLocationId" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource><asp:ObjectDataSource id="dsAccountLocationInsert" runat="server" UpdateMethod="UpdateAccountLocation" DeleteMethod="DeleteAccountLocation" InsertMethod="AddAccountLocation" TypeName="AccountLocationBLL" SelectMethod="GetAccountLocationsByAccountIdAndAccountLocationId" OldValuesParameterFormatString="original_{0}">
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
            <SelectParameters>
                <asp:SessionParameter DefaultValue="64" Name="AccountId" SessionField="AccountId"
                    Type="Int32" />
                <asp:Parameter Name="AccountLocationId" Type="Int32" DefaultValue="0" />
            </SelectParameters>
            <InsertParameters>
                <asp:Parameter Name="AccountId" Type="Int32" />
                <asp:Parameter Name="AccountLocation" Type="String" />
                <asp:Parameter Name="CreatedByEmployeeId" Type="Int32" />
                <asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" />
            </InsertParameters>
        </asp:ObjectDataSource> <asp:ObjectDataSource id="dsAccountBillingTypeObject" runat="server" TypeName="AccountBillingTypeBLL" SelectMethod="GetAccountBillingTypesByMasterBillingTypeId" OldValuesParameterFormatString="original_{0}">
            <SelectParameters>
                <asp:SessionParameter DefaultValue="64" Name="AccountId" SessionField="AccountId"
                    Type="Int32" />
                <asp:Parameter DefaultValue="1" Name="MasterAccountBillingTypeId" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource> <asp:ObjectDataSource id="dsAccountBillingTypeObjectInsert" runat="server" TypeName="AccountBillingTypeBLL" SelectMethod="GetAccountBillingTypesForEmployeeByAccountIdAndIsDisabled" OldValuesParameterFormatString="original_{0}">
            <SelectParameters>
                <asp:SessionParameter DefaultValue="64" Name="AccountId" SessionField="AccountId"
                    Type="Int32" />
                <asp:Parameter DefaultValue="0" Name="AccountBillingTypeId" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource><asp:ObjectDataSource id="dsEmployeeManagerObject" runat="server" UpdateMethod="UpdateUsernameOfExistingEmployee" DeleteMethod="DeleteAccountEmployee" InsertMethod="AddAccountEmployee2" TypeName="AccountEmployeeBLL" SelectMethod="GetAccountEmployeesByAccountIdAndIsDisabled" OldValuesParameterFormatString="original_{0}">
            <DeleteParameters>
                <asp:Parameter Name="Original_AccountEmployeeId" Type="Int32" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="Original_AccountEmployeeId" Type="Int32" />
                <asp:Parameter Name="Username" Type="String" />
            </UpdateParameters>
            <SelectParameters>
                <asp:SessionParameter DefaultValue="151" Name="AccountId" SessionField="AccountId"
                    Type="Int32" />
                <asp:Parameter Name="AccountEmployeeId" Type="Int32" />
            </SelectParameters>
            <InsertParameters>
                <asp:Parameter Name="Login" Type="String" />
                <asp:Parameter Name="Password" Type="String" />
                <asp:Parameter Name="Prefix" Type="String" />
                <asp:Parameter Name="FirstName" Type="String" />
                <asp:Parameter Name="LastName" Type="String" />
            </InsertParameters>
        </asp:ObjectDataSource> <asp:ObjectDataSource id="dsEmployeeManagerObjectInsert" runat="server" UpdateMethod="UpdateUsernameOfExistingEmployee" DeleteMethod="DeleteAccountEmployee" InsertMethod="AddAccountEmployee2" TypeName="AccountEmployeeBLL" SelectMethod="GetAccountEmployeesByAccountIdAndIsDisabled" OldValuesParameterFormatString="original_{0}">
            <DeleteParameters>
                <asp:Parameter Name="Original_AccountEmployeeId" Type="Int32" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="Original_AccountEmployeeId" Type="Int32" />
                <asp:Parameter Name="Username" Type="String" />
            </UpdateParameters>
            <SelectParameters>
                <asp:SessionParameter DefaultValue="151" Name="AccountId" SessionField="AccountId"
                    Type="Int32" />
                <asp:Parameter DefaultValue="0" Name="AccountEmployeeId" Type="Int32" />
            </SelectParameters>
            <InsertParameters>
                <asp:Parameter Name="Login" Type="String" />
                <asp:Parameter Name="Password" Type="String" />
                <asp:Parameter Name="Prefix" Type="String" />
                <asp:Parameter Name="FirstName" Type="String" />
                <asp:Parameter Name="LastName" Type="String" />
            </InsertParameters>
        </asp:ObjectDataSource> <asp:ObjectDataSource id="dsAccountCurrencyObjectInsert" runat="server" TypeName="AccountCurrencyBLL" SelectMethod="GetvueAccountCurrencyByAccountIdAndDisabled" OldValuesParameterFormatString="original_{0}">
            <SelectParameters>
                <asp:SessionParameter DefaultValue="151" Name="AccountId" SessionField="AccountId"
                    Type="Int32" />
                <asp:Parameter DefaultValue="0" Name="AccountCurrencyId" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource> <asp:ObjectDataSource id="dsEmployeeRateCurrencyObject" runat="server" TypeName="AccountCurrencyBLL" SelectMethod="GetvueAccountCurrencyByAccountIdAndDisabled" OldValuesParameterFormatString="original_{0}">
            <SelectParameters>
                <asp:SessionParameter DefaultValue="151" Name="AccountId" SessionField="AccountId"
                    Type="Int32" />
                <asp:Parameter Name="AccountCurrencyId" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource><asp:ObjectDataSource id="dsBillingRateCurrencyObject" runat="server" TypeName="AccountCurrencyBLL" SelectMethod="GetvueAccountCurrencyByAccountIdAndDisabled" OldValuesParameterFormatString="original_{0}">
            <SelectParameters>
                <asp:SessionParameter DefaultValue="151" Name="AccountId" SessionField="AccountId"
                    Type="Int32" />
                <asp:Parameter Name="AccountCurrencyId" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource> <asp:ObjectDataSource id="dsWorkingDayTypeObject" runat="server" TypeName="AccountWorkingDayTypeBLL" SelectMethod="GetAccountWorkingDayTypeByAccountIdAndIsDisabled" OldValuesParameterFormatString="original_{0}">
            <SelectParameters>
                <asp:SessionParameter Name="AccountId" SessionField="AccountId" Type="Int32" />
                <asp:Parameter Name="AccountWorkingDayTypeId" Type="Object" />
            </SelectParameters>
        </asp:ObjectDataSource><asp:ObjectDataSource id="dsWorkingDayTypeObjectInserted" runat="server" TypeName="AccountWorkingDayTypeBLL" SelectMethod="GetAccountWorkingDayTypeByAccountIdAndIsDisabled" OldValuesParameterFormatString="original_{0}">
            <SelectParameters>
                <asp:SessionParameter Name="AccountId" SessionField="AccountId" Type="Int32" />
                <asp:Parameter Name="AccountWorkingDayTypeId" Type="Object" />
            </SelectParameters>
        </asp:ObjectDataSource><asp:ObjectDataSource id="dsEmployeePolicyObjectInsert" runat="server" TypeName="AccountTimeOffPolicyBLL" SelectMethod="GetAccountTimeOffPolicyByAccountIdAndIsDisabled" OldValuesParameterFormatString="original_{0}">
            <SelectParameters>
                <asp:SessionParameter Name="AccountId" SessionField="AccountId" Type="Int32" />
                <asp:Parameter DefaultValue="00000000-0000-0000-0000-000000000000" Name="AccountTimeOffPolicyId" />
            </SelectParameters>
        </asp:ObjectDataSource> <asp:ObjectDataSource id="dsEmployeePolicyObject" runat="server" TypeName="AccountTimeOffPolicyBLL" SelectMethod="GetAccountTimeOffPolicyByAccountIdAndIsDisabled" OldValuesParameterFormatString="original_{0}">
            <SelectParameters>
                <asp:SessionParameter Name="AccountId" SessionField="AccountId" Type="Int32" />
                <asp:Parameter Name="AccountTimeOffPolicyId" />
            </SelectParameters>
        </asp:ObjectDataSource> <asp:ObjectDataSource id="dsTimeOffApprovalTypeObject" runat="server" TypeName="AccountApprovalBLL" SelectMethod="GetAccountApprovalTypesByAccountIdForTimeOffApproval" OldValuesParameterFormatString="original_{0}">
            <SelectParameters>
                <asp:SessionParameter Name="AccountId" SessionField="AccountId" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource> <asp:ObjectDataSource id="dsHolidayTypeObject" runat="server" TypeName="AccountHolidayTypeBLL" SelectMethod="GetAccountHolidayTypeByAccountId" OldValuesParameterFormatString="original_{0}"><SelectParameters>
<asp:SessionParameter SessionField="AccountId" DefaultValue="66" Name="AccountId" Type="Int32"></asp:SessionParameter>
            <asp:Parameter DefaultValue="00000000-0000-0000-0000-000000000000"
                Name="AccountHolidayTypeId" />
</SelectParameters>
</asp:ObjectDataSource>