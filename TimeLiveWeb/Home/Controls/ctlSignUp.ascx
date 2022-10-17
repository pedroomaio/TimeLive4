<%@ Control Language="vb" AutoEventWireup="false" Inherits="TimeLive.ctlSignUp" CodeFile="ctlSignUp.ascx.vb" %>
<%@ Register Assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2"
    Namespace="eWorld.UI" TagPrefix="ew" %>
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc2" %>
<%@ Register Assembly="eWorld.UI"
    Namespace="eWorld.UI" TagPrefix="ew" %>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
<asp:UpdatePanel ID="UpdatePanel3" runat="server">
    <ContentTemplate>
&nbsp;<asp:FormView id="FormView1" DefaultMode="Insert" 
    DataKeyNames="AccountId" runat="server" Width="700px" HorizontalAlign=Center>
        <EditItemTemplate><table border="0" cellpadding="2" cellspacing="1" style="width: 775px;" class="xFormView">
            <tr>
                <th align="left" class="caption" colspan="4">
                    <asp:Literal ID="Literal1" runat="server" Text='<%# ResourceHelper.GetFromResource("Provide Your Information") %>' /></th>
            </tr>
            <tr>
                <th align="left" class="FormViewSubHeader" colspan="4">
                <asp:Literal ID="Literal2" runat="server" Text='<%# ResourceHelper.GetFromResource("Organization Information") %>' /></th>
            </tr>
            <tr>
                <td style="height: 22px; width: 55%;" class="FormViewLabelCell" align="right">
                    <SPAN 
                  class=reqasterisk>*</span> 
                  <asp:Literal ID="Literal11" runat="server" Text='<%# ResourceHelper.GetFromResource("Account Name") %>' /></td>
                <td colspan="3" style="height: 22px">
                    <asp:TextBox ID="AccountName" runat="server" Text='<%# Bind("AccountName") %>' Width="264px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="AccountName"
                        Display="Dynamic" ErrorMessage="*" Width="1px" CssClass="ErrorMessage"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="height: 19px; width: 55%;" class="FormViewLabelCell" align="right">
                    <SPAN 
                  class=reqasterisk>*</span> 
                  
<asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="EMailAddressTextBox">
                  <asp:Literal ID="Literal12" runat="server" Text='<%# ResourceHelper.GetFromResource("Email Address:") %>' /></asp:Label></td><td colspan="3" style="height: 19px">
                    <asp:TextBox ID="EMailAddressTextBox" runat="server" Text='<%# Bind("EMailAddress") %>'
                        Width="208px"></asp:TextBox>&nbsp; <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="EMailAddressTextBox"
                        CssClass="ErrorMessage" ErrorMessage="Invalid EMail Address" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator></td></tr><tr style="color: #000000">
                <td style="height: 23px; width: 55%;" class="FormViewLabelCell" align="right">
                   
<asp:Label ID="Label2" runat="server" AssociatedControlID="Address1TextBox">
                    <asp:Literal ID="Literal6" runat="server" Text='<%# ResourceHelper.GetFromResource("Address1:") %>' /></asp:Label></td><td colspan="3" style="height: 23px">
                    <asp:TextBox ID="Address1TextBox" runat="server" Text='<%# Bind("Address1") %>' Width="232px"></asp:TextBox></td></tr><tr>
                <td style="height: 24px; width: 55%;" class="FormViewLabelCell" align="right">
                    
<asp:Label ID="Label4" runat="server" AssociatedControlID="Address2TextBox">
                    <asp:Literal ID="Literal7" runat="server" Text='<%# ResourceHelper.GetFromResource("Address2:") %>' /></asp:Label></td><td colspan="3" style="height: 24px">
                    <asp:TextBox ID="Address2TextBox" runat="server" Text='<%# Bind("Address2") %>' Width="232px"></asp:TextBox></td></tr><tr>
                <td style="height: 24px; width: 55%;" class="FormViewLabelCell" align="right">
                   
<asp:Label ID="Label6" runat="server" AssociatedControlID="ZipCodeTextBox">
                    <asp:Literal ID="Literal8" runat="server" Text='<%# ResourceHelper.GetFromResource("Zipcode") %>' /></asp:Label></td><td colspan="3" style="height: 24px">
                    <asp:TextBox ID="ZipCodeTextBox" runat="server" Text='<%# Bind("ZipCode") %>' Width="72px"></asp:TextBox></td></tr><tr>
                <td style="height: 22px; width: 55%;" class="FormViewLabelCell" align="right">
                    
<asp:Label ID="Label8" runat="server" AssociatedControlID="CityTextBox">
                    <asp:Literal ID="Literal9" runat="server" Text='<%# ResourceHelper.GetFromResource("City:") %>' /></asp:Label></td><td colspan="3" style="height: 22px">
                    <asp:TextBox ID="CityTextBox" runat="server" Text='<%# Bind("City") %>'></asp:TextBox></td></tr><tr>
                <td style="height: 22px; width: 55%;" class="FormViewLabelCell" align="right">
                    <SPAN 
                  class=reqasterisk>*</span><asp:Literal ID="Literal10" runat="server" Text='<%# ResourceHelper.GetFromResource("Country:") %>' /></td>
                
                <td colspan="3" style="height: 22px">
                    <asp:DropDownList ID="DropDownList3" runat="server" DataSourceID="dsCountryObject"
                DataTextField="Country" DataValueField="CountryId"  SelectedValue='<%# Bind("CountryId") %>' Width="152px" >
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="height: 21px; width: 55%;" class="FormViewLabelCell" align="right">
                  
<asp:Label ID="Label10" runat="server" AssociatedControlID="TelephoneTextBox">
                  <asp:Literal ID="Literal13" runat="server" Text='<%# ResourceHelper.GetFromResource("Telephone:") %>' /></asp:Label></td><td colspan="3" style="height: 21px">
                    <asp:TextBox ID="TelephoneTextBox" runat="server" Text='<%# Bind("Telephone") %>'></asp:TextBox></td></tr><tr>
                <td style="height: 22px; width: 55%;" class="FormViewLabelCell" align="right">
                    
<asp:Label ID="Label12" runat="server" AssociatedControlID="FaxTextBox">
                    <asp:Literal ID="Literal14" runat="server" Text='<%# ResourceHelper.GetFromResource("Fax:") %>' /></asp:Label></td><td colspan="3" style="height: 22px">
                    <asp:TextBox ID="FaxTextBox" runat="server" Text='<%# Bind("Fax") %>'></asp:TextBox></td></tr><tr>
                <td align="right" class="FormViewLabelCell" style="width: 55%; height: 22px">
                    <asp:Literal ID="Literal15" runat="server" Text='<%# ResourceHelper.GetFromResource("TimeZone:") %>' /></td>
                <td colspan="3" style="height: 22px">
                    <asp:DropDownList ID="ddlTimeZoneId" runat="server" DataSourceID="dsTimeZone"
                DataTextField="TimeZoneName" DataValueField="SystemTimeZoneId"  SelectedValue='<%# Bind("TimeZoneId") %>' Width="368px" >
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <th class="FormViewSubHeader" colspan="4" style="height: 21px">
                    <asp:Literal ID="Literal3" runat="server" Text='<%# ResourceHelper.GetFromResource("Application Preferences") %>' /></th>
            </tr>
            <tr>
                <td align="right" class="FormViewLabelCell" style="width: 70%; height: 22px">
                    <asp:Literal ID="Literal94" runat="server" Text='<%# ResourceHelper.GetFromResource("Enable Password Complexity:") %>' /></td><td colspan="3" style="height: 22px">
                    <asp:CheckBox 
                        ID="chkEnablePasswordComplexity" runat="server" /></td>
            </tr>
            <tr><td 
                    align="right" class="FormViewLabelCell" style="width: 70%; height: 22px"><asp:Literal 
                    ID="Literal19" runat="server" 
                    Text='<%# ResourceHelper.GetFromResource("Lock Submitted Records") %>' /></td><td 
                    colspan="3" style="height: 22px"><asp:CheckBox ID="chkLockSubmittedRecord" 
                        runat="server" /></td></tr><tr><td align="right" 
                    class="FormViewLabelCell" style="width: 70%; height: 22px"><asp:Literal 
                    ID="Literal20" runat="server" 
                    Text='<%# ResourceHelper.GetFromResource("Lock In-Approval Records") %>' /></td><td 
                    colspan="3" style="height: 22px"><asp:CheckBox ID="chkLockApprovedRecord" 
                        runat="server" /></td></tr><tr><td 
                    align="right" class="FormViewLabelCell" style="width: 70%; height: 22px">
                    Use Electronic Signature:</td><td colspan="3" style="height: 22px"><asp:CheckBox 
                        ID="chkShowElectronicSign" runat="server" /></td></tr><tr><td align="right" 
                    class="FormViewLabelCell" style="width: 70%; height: 22px"><asp:Label 
                    ID="Label25" runat="server" AssociatedControlID="txtPasswordExpiryPeriod">  
                    <asp:Literal ID="Literal86" runat="server" 
                Text='<%# ResourceHelper.GetFromResource("Password Expiry Period") %>' /></asp:Label></td><td 
                    colspan="3" style="height: 22px"><asp:TextBox ID="txtPasswordExpiryPeriod" 
                        runat="server" Width="50px"></asp:TextBox><asp:Label ID="Labeldays" 
                        runat="server">Days</asp:Label><asp:RequiredFieldValidator 
                        ID="RequiredFieldValidator3" runat="server" 
                        ControlToValidate="txtPasswordExpiryPeriod" CssClass="ErrorMessage" 
                        Display="Dynamic" ErrorMessage="*" Width="8px"></asp:RequiredFieldValidator><asp:Label 
                        ID="LabelPEP" runat="server" ForeColor="red">(0 = No Expiry)</asp:Label><asp:RangeValidator 
                        ID="RangeValidator2" runat="server" ControlToValidate="txtPasswordExpiryPeriod" 
                        CssClass="ErrorMessage" Display="Dynamic" ErrorMessage="Numeric required" 
                        Font-Bold="False" MaximumValue="99999" MinimumValue="0" Type="Integer"></asp:RangeValidator></td></tr><tr>
                <td align="right" class="FormViewLabelCell" style="width: 70%; height: 22px">
                    <asp:Label 
                        ID="Label17" runat="server" AssociatedControlID="TPScheduledEmailSendTime">
                    <asp:Literal ID="Literal44" runat="server" 
            Text='<%# ResourceHelper.GetFromResource("Scheduled Email Sent Time") %>' /></asp:Label></td><td colspan="3" style="height: 22px">
                    <asp:TextBox 
                        ID="TPScheduledEmailSendTime" runat="server" Width="53px"></asp:TextBox><cc2:MaskedEditExtender 
                        ID="MaskedEditExtenderTPScheduledEmailSendTime" runat="server" Mask="99:99 " 
                        MaskType="Time" TargetControlID="TPScheduledEmailSendTime"></cc2:MaskedEditExtender><asp:RequiredFieldValidator 
                        ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="TPScheduledEmailSendTime" CssClass="ErrorMessage" 
                        Display="Dynamic" ErrorMessage="*" Width="8px"></asp:RequiredFieldValidator><cc2:MaskedEditValidator 
                        ID="MaskedEditValidatorEmailSentTime" runat="server" 
                        ControlExtender="MaskedEditExtenderTPScheduledEmailSendTime" 
                        ControlToValidate="TPScheduledEmailSendTime" Display="Dynamic" 
                        EmptyValueMessage="*" ErrorMessage="MaskedEditValidatorEmailSentTime" 
                        InvalidValueMessage="Invalid Time" IsValidEmpty="true" 
                        ValidationGroup="TimeEntry"></cc2:MaskedEditValidator></td></tr><% Dim LDAP As New LDAPUtilitiesBLL%><% If LDAP.IsAspNetActiveDirectoryMembershipProvider <> True Then%><% End If%><tr>
                <td align="right" class="FormViewLabelCell" style="width: 70%; height: 22px">
               
<asp:Label ID="Label16" runat="server" AssociatedControlID="SessionTimeOutTextBox">
                <asp:Literal ID="Literal24" runat="server" Text='<%# ResourceHelper.GetFromResource("Session Time Out") %>' /></asp:Label></td><td 
                    colspan="3" style="height: 22px; text-align: left;" class="FormViewLabelCell"><asp:TextBox 
                        ID="SessionTimeOutTextBox" runat="server" 
                        Width="50px" MaxLength="3"></asp:TextBox><asp:Literal 
                        ID="Literal74" runat="server" 
                        Text='<%# ResourceHelper.GetFromResource("Minutes") %>' /></td><asp:RangeValidator ID="RangeValidator4" runat="server" ControlToValidate="SessionTimeOutTextBox"
                        CssClass="ErrorMessage" Display="Dynamic" ErrorMessage="Value must be greater then 0" Font-Bold="False"
                        MaximumValue="999" MinimumValue="1" Type="Integer"></asp:RangeValidator></tr><tr><td 
                    align="right" class="FormViewLabelCell" style="width: 70%; height: 22px"><asp:Literal 
                    ID="Literal73" runat="server" 
                    Text='<%# ResourceHelper.GetFromResource("Page Size:") %>' /></td><td 
                    class="FormViewLabelCell" colspan="3" style="height: 22px; text-align: left;"><asp:DropDownList 
                        ID="ddlPageSize" runat="server" AppendDataBoundItems="True" 
                        Width="150px"><asp:ListItem>20</asp:ListItem><asp:ListItem>10</asp:ListItem><asp:ListItem>40</asp:ListItem><asp:ListItem>30</asp:ListItem><asp:ListItem>50</asp:ListItem></asp:DropDownList></td></tr><tr><td 
                    align="right" class="FormViewLabelCell" style="width: 70%; height: 22px"><asp:Literal 
                    ID="Literal22" runat="server" 
                    Text='<%# ResourceHelper.GetFromResource("Standard and Formats") %>' /></td><td 
                    class="FormViewLabelCell" colspan="3" style="height: 22px; text-align: left;"><asp:DropDownList 
                        ID="CultureInfoName" runat="server" AppendDataBoundItems="True" 
                        DataSourceID="dsLocaleInfo" DataTextField="EnglishName" DataValueField="Name" 
                        Width="368px"><asp:ListItem ID="Label103" runat="server" Label="" 
                            Text="<%$ Resources:TimeLive.Resource, Auto%> " Value="auto"></asp:ListItem><%--<asp:ListItem Value="auto">&lt;Auto&gt;</asp:ListItem>--%></asp:DropDownList></td></tr><tr><td 
                    align="right" class="FormViewLabelCell" style="width: 70%; height: 22px"><asp:Literal 
                    ID="Literal23" runat="server" 
                    Text='<%# ResourceHelper.GetFromResource("Currency Symbol") %>' /></td><td 
                    class="FormViewLabelCell" colspan="3" style="height: 22px; text-align: left;"><asp:DropDownList 
                        ID="CurrencySymbol" runat="server" AppendDataBoundItems="True" 
                        DataSourceID="dsCurrencySymbol" DataTextField="CurrencySymbol" 
                        DataValueField="CurrencySymbol" Width="368px"><asp:ListItem ID="Label100" 
                            runat="server" Label="" Text="<%$ Resources:TimeLive.Resource, Auto%> " Value="auto"></asp:ListItem><%--<asp:ListItem Value="$">&lt;Auto&gt;</asp:ListItem>--%></asp:DropDownList></td></tr><tr>
                <td align="right" class="FormViewLabelCell">
                    


<asp:Label ID="Label18" runat="server" AssociatedControlID="FromEmailAddressDisplayNameTextBox">
                    <asp:Literal ID="Literal57" runat="server" Text='<%# ResourceHelper.GetFromResource("From Email Display Name") %>' /></asp:Label></td><td>
                    <asp:TextBox ID="FromEmailAddressDisplayNameTextBox" runat="server" MaxLength="50"></asp:TextBox></td><td align="right" class="FormViewLabelCell">
                    

<asp:Label ID="Label19" runat="server" AssociatedControlID="FromEmailAddressTextBox">
                    <asp:Literal ID="Literal60" runat="server" Text='<%# ResourceHelper.GetFromResource("From Email Address") %>' />:</asp:Label></td><td>
                    <asp:TextBox ID="FromEmailAddressTextBox" runat="server" MaxLength="50"></asp:TextBox></td></tr><tr><td 
                    align="right" class="FormViewLabelCell" style="width: 70%; height: 22px">&nbsp;</td><td 
                    class="FormViewLabelCell" colspan="3" style="height: 22px; text-align: left;"><asp:Button 
                        ID="btnApplicationPreferences" runat="server" CommandName="Update" 
                        OnClick="btnApplicationPreferences_Click" 
                        Text="<%$ Resources:TimeLive.Resource, Update_text%> " /></td></tr><tr>
<%  If AccountPagePermissionBLL.IsPageHasPermissionOf(136, 1) = True Or AccountPagePermissionBLL.IsPageHasPermissionOf(113, 1) = True Or AccountPagePermissionBLL.IsPageHasPermissionOf(147, 1) = True Or AccountPagePermissionBLL.IsPageHasPermissionOf(149, 1) = True Or AccountPagePermissionBLL.IsPageHasPermissionOf(1, 1) = True Or AccountPagePermissionBLL.IsPageHasPermissionOf(118, 1) = True Or AccountPagePermissionBLL.IsPageHasPermissionOf(122, 1) = True Then%> 
                    <th class="FormViewSubHeader" style="height: 21px" colspan="4" align="left">
                    <asp:Literal ID="Literal100" runat="server" Text='<%# ResourceHelper.GetFromResource("Timesheet Setup") %>' /></th>
                    </tr><tr><td 
                    align="right" class="FormViewLabelCell" style="width: 70%; height: 22px"><asp:Literal 
                    ID="Literal16" runat="server" 
                    Text='<%# ResourceHelper.GetFromResource("Show Clock Start/End") %>' /></td><td 
                    colspan="3" style="height: 22px"><asp:CheckBox ID="chkShowClockStartEnd" 
                        runat="server" Checked='<%# Bind("ShowClockStartEnd") %>' /></td></tr><tr><td 
                    align="right" class="FormViewLabelCell" style="width: 70%; height: 22px"><asp:Literal 
                    ID="Literal76" runat="server" 
                    Text='<%# ResourceHelper.GetFromResource("Show Client In Timesheet:") %>' /></td><td 
                    colspan="3" style="height: 22px"><asp:CheckBox ID="chkShowClientInTimesheet" 
                        runat="server" /></td></tr><tr><td align="right" 
                    class="FormViewLabelCell" style="width: 70%; height: 22px"><asp:Literal 
                    ID="Literal17" runat="server" 
                    Text='<%# ResourceHelper.GetFromResource("Show Description In Week View:") %>' /></td><td 
                    colspan="3" style="height: 22px"><asp:CheckBox 
                        ID="chkShowDescriptionInWeekView" runat="server" /></td></tr><tr><td 
                    align="right" class="FormViewLabelCell" style="width: 70%; height: 22px"><asp:Literal 
                    ID="Literal80" runat="server" 
                    Text='<%# ResourceHelper.GetFromResource("Show Completed Project In Timesheet:") %>' /></td><td 
                    colspan="3" style="height: 22px"><asp:CheckBox 
                        ID="chkShowCompletedProjectsInTimeSheet" runat="server" /></td></tr><tr><td 
                    align="right" class="FormViewLabelCell" style="width: 70%; height: 22px"><asp:Literal 
                    ID="Literal25" runat="server" 
                    Text='<%# ResourceHelper.GetFromResource("Show Completed Task In Timesheet:") %>' /></td><td 
                    colspan="3" style="height: 22px"><asp:CheckBox 
                        ID="chkShowCompletedTasksInTimeSheet" runat="server" /></td></tr><tr><td 
                    align="right" class="FormViewLabelCell" style="width: 70%; height: 22px"><asp:Literal 
                    ID="Literal26" runat="server" 
                    Text='<%# ResourceHelper.GetFromResource("Show Work Type In Timesheet") %>' /></td><td 
                    colspan="3" style="height: 22px"><asp:CheckBox ID="chkShowWorkTypeInTimeSheet" 
                        runat="server" /></td></tr><tr><td align="right" 
                    class="FormViewLabelCell" style="width: 70%; height: 22px"><asp:Literal 
                    ID="Literal27" runat="server" 
                    Text='<%# ResourceHelper.GetFromResource("Show COst Center In Timesheet") %>' /></td><td 
                    colspan="3" style="height: 22px"><asp:CheckBox 
                        ID="chkShowCostCenterInTimeSheet" runat="server" /></td></tr><tr><td 
                    align="right" class="FormViewLabelCell" style="width: 70%; height: 22px">
                    <asp:Literal ID="Literal85" runat="server" Text='<%# ResourceHelper.GetFromResource("Show TimeOff In Timesheet:") %>' /></td>
                    <td 
                    colspan="3" style="height: 22px"><asp:CheckBox ID="chkShowTimeOffInTimesheet" 
                        runat="server" /></td></tr><tr><td align="right" 
                    class="FormViewLabelCell" style="width: 70%; height: 22px">Show Copy Timesheet Button:</td><td 
                    colspan="3" style="height: 22px"><asp:CheckBox ID="chkShowCopyTimesheetButton" 
                        runat="server" /></td></tr><tr><td align="right" 
                    class="FormViewLabelCell" style="width: 70%; height: 22px">Show Copy Activities Button In Timesheet:</td><td 
                    colspan="3" style="height: 22px"><asp:CheckBox 
                        ID="chkShowCopyActivitiesButtonInTimesheet" runat="server" /></td></tr><tr><td align="right" 
                    class="FormViewLabelCell" style="width: 70%; height: 22px"><asp:Literal 
                    ID="Literal88" runat="server" 
                    Text='<%# ResourceHelper.GetFromResource("Show ShowAll in Approval Popup:") %>' /></td><td 
                    colspan="3" style="height: 22px"><asp:CheckBox 
                        ID="chkShowAllInTimesheetReadOnly" runat="server" /></td></tr><tr><td 
                    align="right" class="FormViewLabelCell" style="width: 70%; height: 22px">
                    Show Task Percentage In Timesheet:</td><td colspan="3" style="height: 22px"><asp:CheckBox 
                        ID="chkShowPercentageInTimesheet" runat="server" /></td></tr><tr><td align="right" 
                    class="FormViewLabelCell" style="width: 70%; height: 22px">Calculate Task Percentage Automatically:</td><td 
                    colspan="3" style="height: 22px"><asp:CheckBox 
                        ID="chkCalculateTaskPercentageAutomatically" runat="server" /></td></tr><tr><td align="right" 
                    class="FormViewLabelCell" style="width: 70%; height: 22px"><asp:Label 
                    ID="Label14" runat="server" 
                    AssociatedControlID="txtNumberOfBlankRowsInTimeEntry">  
                    <asp:Literal ID="Literal18" runat="server" 
                                        Text='<%# ResourceHelper.GetFromResource("No Of Blank Rows In Timesheet") %>' /></asp:Label></td><td 
                    colspan="3" style="height: 22px"><asp:TextBox 
                        ID="txtNumberOfBlankRowsInTimeEntry" runat="server" Width="50px"></asp:TextBox><asp:RangeValidator 
                        ID="RangeValidator1" runat="server" 
                        ControlToValidate="txtNumberOfBlankRowsInTimeEntry" CssClass="ErrorMessage" 
                        Display="Dynamic" ErrorMessage="Must be between 1 and 15" Font-Bold="False" 
                        MaximumValue="15" MinimumValue="1" Type="Integer" 
                        ValidationGroup="UpdateTimesheet"></asp:RangeValidator></td></tr><tr>
                        <td align="right" class="FormViewLabelCell" style="width: 70%; height: 22px">
                        <asp:Literal ID="Literal93" runat="server" Text='<%# ResourceHelper.GetFromResource("Timesheet Periods Overdue:") %>' /></td>
                        <td colspan="3" style="height: 22px"><asp:TextBox ID="txtTimesheetOverduePeriods" 
                        runat="server" Width="50px"></asp:TextBox><asp:RangeValidator 
                        ID="RangeValidator5" runat="server" 
                        ControlToValidate="txtTimesheetOverduePeriods" CssClass="ErrorMessage" 
                        Display="Dynamic" ErrorMessage="Must be between 1 and 10" Font-Bold="False" 
                        MaximumValue="10" MinimumValue="0" Type="Integer" 
                                ValidationGroup="UpdateTimesheet"></asp:RangeValidator><asp:RequiredFieldValidator 
                        ID="RequiredFieldValidator4" runat="server" 
                        ControlToValidate="txtTimesheetOverduePeriods" CssClass="ErrorMessage" 
                        Display="Dynamic" ErrorMessage="*" Width="8px"></asp:RequiredFieldValidator></td></tr><tr><td 
                    align="right" class="FormViewLabelCell" style="width: 70%; height: 22px">
                    <asp:Literal ID="Literal92" runat="server" Text='<%# ResourceHelper.GetFromResource("Time Entry Hours Format:") %>' /></td>
                    <td colspan="3" style="height: 22px"><asp:DropDownList 
                        ID="ddlTimeEntryHoursFormatId" runat="server" AppendDataBoundItems="True" 
                        DataSourceID="dsSystemTimeEntryHoursFormat" 
                        DataTextField="SystemTimeEntryHoursFormat" 
                        DataValueField="SystemTimeEntryHoursFormatId"><asp:ListItem Value="None">&lt;None&gt;</asp:ListItem></asp:DropDownList></td></tr><tr><td 
                    align="right" class="FormViewLabelCell" style="width: 70%; height: 22px">
                    <asp:Literal ID="Literal91" runat="server" Text='<%# ResourceHelper.GetFromResource("Time Entry Clock Format:") %>' /></td>
                    <td colspan="3" style="height: 22px"><asp:DropDownList ID="ddlTimeEntryFormat" 
                        runat="server" AppendDataBoundItems="True"><asp:ListItem Value="HH:mm">HH:MM</asp:ListItem><asp:ListItem 
                            Value="hh:mm tt">HH:MM AM/PM</asp:ListItem></asp:DropDownList></td></tr><tr><td 
                    align="right" class="FormViewLabelCell" style="width: 70%; height: 22px"><asp:Literal 
                    ID="Literal79" runat="server" 
                    Text='<%# ResourceHelper.GetFromResource("Show Additional Task Information Type:") %>' /></td><td 
                    colspan="3" style="height: 22px"><asp:DropDownList ID="ddlTaskInformation" 
                        runat="server" Width="150px"><asp:ListItem 
                            Text="<%$ Resources:TimeLive.Resource, None%> " Value="0"></asp:ListItem><asp:ListItem 
                            Text="<%$ Resources:TimeLive.Resource, Parent Task Name%> " Value="1"></asp:ListItem><asp:ListItem 
                            Text="<%$ Resources:TimeLive.Resource, Parent Task Code%> " Value="2"></asp:ListItem><asp:ListItem 
                            Text="<%$ Resources:TimeLive.Resource, Task Code%> " Value="3"></asp:ListItem></asp:DropDownList></td></tr><tr><td 
                    align="right" class="FormViewLabelCell" style="width: 70%; height: 22px"><asp:Literal 
                    ID="Literal72" runat="server" 
                    Text='<%# ResourceHelper.GetFromResource("Default Time Entry Mode:") %>' /></td><td 
                    colspan="3" style="height: 22px"><asp:DropDownList ID="ddlDefaultTimeEntryMode" 
                        runat="server" AppendDataBoundItems="True" Width="150px"><asp:ListItem 
                            Text="<%$ Resources:TimeLive.Resource, Day View%> " Value="Day View"></asp:ListItem><asp:ListItem 
                            Text="<%$ Resources:TimeLive.Resource, Period View%> " Value="Period View"></asp:ListItem></asp:DropDownList></td></tr><tr><td 
                    align="right" class="FormViewLabelCell" style="width: 70%; height: 22px">Sort Timesheet By:</td><td 
                    colspan="3" style="height: 22px"><asp:DropDownList ID="ddlTimesheetSort" 
                        runat="server" AppendDataBoundItems="True" Width="150px"><asp:ListItem 
                            Text="Default" Value="Default"></asp:ListItem><asp:ListItem 
                            Text="Client" Value="Client"></asp:ListItem></asp:DropDownList></td></tr><tr><td 
                    align="right" class="FormViewLabelCell" style="width: 70%; height: 22px">Show Cost Center In Timesheet By:</td><td 
                    colspan="3" style="height: 22px"><asp:DropDownList 
                        ID="ddlCostCenterInTimesheetBy" runat="server" AppendDataBoundItems="True" 
                        Width="150px"><asp:ListItem Text="Account" Value="Account"></asp:ListItem><asp:ListItem 
                            Text="Employee" Value="Employee"></asp:ListItem></asp:DropDownList></td></tr><tr><td 
                    align="right" class="FormViewLabelCell" style="width: 70%; height: 22px" 
                    valign="top"><asp:Label 
                    ID="Label20" runat="server" AssociatedControlID="txtTimesheetPrintFooter">
                    <asp:Literal ID="Literal83" runat="server" 
                Text='<%# ResourceHelper.GetFromResource("Timesheet Print Footer:") %>' /></asp:Label></td><td 
                    colspan="3" style="height: 22px"><asp:TextBox ID="txtTimesheetPrintFooter" 
                        runat="server" Height="75px" MaxLength="2000" TextMode="MultiLine" 
                        ValidationGroup="vgPrintFooter" Width="500px"></asp:TextBox><br /><asp:CustomValidator 
                        ID="cvTimesheetPrintFooter" runat="server" 
                        ControlToValidate="txtTimesheetPrintFooter" CssClass="ErrorMessage" 
                        Display="Dynamic" 
                        ErrorMessage="Value must be less than or equal to 2000 characters." 
                        OnServerValidate="cvTimesheetPrintFooter_ServerValidate" 
                        ValidationGroup="UpdateTimesheet"></asp:CustomValidator></td></tr><tr><td 
                    align="right" class="FormViewLabelCell" style="width: 70%; height: 22px">&nbsp;</td><td 
                    colspan="3" style="height: 22px"><asp:Button ID="btnUpdateTimesheetSetup" 
                        runat="server" OnClick="btnUpdateTimesheetSetup_Click" 
                        Text="<%$ Resources:TimeLive.Resource, Update_text%> " 
                        ValidationGroup="UpdateTimesheet" style="height: 26px" /></td></tr><tr>
<%  End If%> 
<%  If AccountPagePermissionBLL.IsPageHasPermissionOf(6, 1) = True Or AccountPagePermissionBLL.IsPageHasPermissionOf(5, 1) = True Or AccountPagePermissionBLL.IsPageHasPermissionOf(107, 1) = True Or AccountPagePermissionBLL.IsPageHasPermissionOf(106, 1) = True Or AccountPagePermissionBLL.IsPageHasPermissionOf(117, 1) = True Or AccountPagePermissionBLL.IsPageHasPermissionOf(114, 1) = True Then%>
                <th class="FormViewSubHeader" colspan="4" style="height: 22px">
                    <asp:Literal ID="Literal82" runat="server" Text='<%# ResourceHelper.GetFromResource("Expense Setup") %>' /></th>
            </tr>
            <tr>
                <td align="right" class="FormViewLabelCell" style="width: 55%; height: 22px"><asp:Literal 
                        ID="Literal87" runat="server" 
                        Text='<%# ResourceHelper.GetFromResource("Show Task In Expense Sheet:") %>' /></td><td colspan="3" style="height: 22px">
                    <asp:CheckBox 
                        ID="chkShowTaskInExpenseSheet" runat="server" /></td></tr><tr>
                <td align="right" class="FormViewLabelCell" style="width: 55%; height: 22px" valign="top">
                    
<asp:Label ID="Label21" runat="server" AssociatedControlID="txtExpenseSheetPrintFooter">
                    <asp:Literal ID="Literal81" runat="server" Text='<%# ResourceHelper.GetFromResource("Expense Sheet Print Footer:") %>' /></asp:Label></td><td colspan="3" style="height: 22px">
                    <asp:TextBox ID="txtExpenseSheetPrintFooter" runat="server" Height="75px" TextMode="MultiLine"
                        Width="500px" ValidationGroup="vgPrintFooter" MaxLength="2000"></asp:TextBox><br /><asp:CustomValidator ID="cvExpenseSheetPrintFooter" runat="server" ControlToValidate="txtTimesheetPrintFooter"
                        CssClass="ErrorMessage" ErrorMessage="Value must be less than or equal to 2000 characters."
                        OnServerValidate="cvExpenseSheetPrintFooter_ServerValidate" ValidationGroup="vgPrintFooter" Display="Dynamic"></asp:CustomValidator></td></tr><tr>
                <td align="right" class="FormViewLabelCell" style="width: 55%; height: 22px" valign="top">
                </td>
                <td colspan="3" style="height: 22px">
                    <asp:Button ID="btnUpdatePrintInfo" runat="server"  Text="<%$ Resources:TimeLive.Resource, Update_text%> " OnClick="btnUpdatePrintInfo_Click" ValidationGroup="vgPrintFooter"  /></td></tr>
<%  End If%>
<%  If AccountPagePermissionBLL.IsPageHasPermissionOf(138, 1) = True Or AccountPagePermissionBLL.IsPageHasPermissionOf(139, 1) = True Then%> 
                </tr><tr><th class="FormViewSubHeader" style="height: 22px" colspan="4">Time Off Setup</th><tr><td 
                    align="right" class="FormViewLabelCell" style="width: 70%; height: 22px"><asp:Literal 
                    ID="Literal101" runat="server" 
                    Text='<%# ResourceHelper.GetFromResource("Show Project For TimeOff:") %>' /></td><td 
                    colspan="3" style="height: 22px"><asp:CheckBox ID="chkShowProjectForTimeOff" 
                        runat="server" /></td></tr><tr><td align="right" class="FormViewLabelCell" 
                        style="width: 70%; height: 22px">&nbsp;</td><td colspan="3" style="height: 22px"><asp:Button 
                            ID="btnUpdateTimeOff" runat="server" onclick="btnUpdateTimeOff_Click" 
                            Text="<%$ Resources:TimeLive.Resource, Update_text%> " /></td></tr><tr><%  End If%><%  If AccountPagePermissionBLL.IsPageHasPermissionOf(12, 1) = True Or AccountPagePermissionBLL.IsPageHasPermissionOf(76, 1) = True Or AccountPagePermissionBLL.IsPageHasPermissionOf(33, 1) = True Or AccountPagePermissionBLL.IsPageHasPermissionOf(103, 1) = True Then%>
                            <th 
                        class="FormViewSubHeader" colspan="4" style="height: 22px"><asp:Literal 
                        ID="Literal90" runat="server" 
                        Text='<%# ResourceHelper.GetFromResource("Project Setup") %>' /></th></tr><tr><td 
                        align="right" class="FormViewLabelCell" style="width: 70%; height: 22px"><asp:Literal 
                        ID="Literal96" runat="server" 
                        Text='<%# ResourceHelper.GetFromResource("Auto Generate Project Code:") %>' /></td><td 
                        colspan="3" style="height: 22px"><asp:CheckBox ID="chkAutoGenerateProjectCode" 
                            runat="server" /></td></tr><tr><td align="right" 
                        style="height: 22px; width: 55%;">Show Completed Project In Project List:</td><td 
                        colspan="3" style="height: 22px"><asp:CheckBox 
                            ID="chkShowCompletedProjectInProjectGrid" runat="server" /></td></tr><tr><td 
                        align="right" style="height: 22px; width: 55%;">Show Client Department In Project:</td><td 
                        colspan="3" style="height: 22px"><asp:CheckBox 
                            ID="chkShowClientDepartmentInProject" runat="server" /></td></tr><tr><td 
                        align="right" style="height: 22px; width: 55%;"></td><td colspan="3" 
                        style="height: 22px"><asp:Button ID="btnUpdateProjectInfo" runat="server" 
                            onclick="btnUpdateProjectInfo_Click" 
                            Text="<%$ Resources:TimeLive.Resource, Update_text%> " /></td></tr><tr><%  End If%><%  If AccountPagePermissionBLL.IsPageHasPermissionOf(12, 1) = True Or AccountPagePermissionBLL.IsPageHasPermissionOf(76, 1) = True Or AccountPagePermissionBLL.IsPageHasPermissionOf(33, 1) = True Or AccountPagePermissionBLL.IsPageHasPermissionOf(103, 1) = True Then%>
                            <th 
                        class="FormViewSubHeader" colspan="4" style="height: 22px"><asp:Literal 
                        ID="Literal84" runat="server" 
                        Text='<%# ResourceHelper.GetFromResource("Task Setup") %>' /></th></tr><tr><td 
                        align="right" class="FormViewLabelCell" style="width: 70%; height: 22px"><asp:Literal 
                        ID="Literal95" runat="server" 
                        Text='<%# ResourceHelper.GetFromResource("Show Project Name In Task:") %>' /></td><td 
                        colspan="3" style="height: 22px"><asp:CheckBox ID="chkShowProjectNameInTask" 
                            runat="server" /></td></tr><tr><td 
                        align="right" style="height: 22px; width: 55%;">Show Client Name In Task:</td><td 
                        colspan="3" style="height: 22px"><asp:CheckBox ID="chkShowClientNameInTask" 
                            runat="server" /></td></tr><tr><td 
                        align="right" style="height: 22px; width: 55%;"></td><td colspan="3" 
                        style="height: 22px"><asp:Button ID="btnUpdateTaskInfo" runat="server" 
                            onclick="btnUpdateTaskInfo_Click" 
                            Text="<%$ Resources:TimeLive.Resource, Update_text%> " /></td></tr><tr><%  End If%><%  If AccountPagePermissionBLL.IsPageHasPermissionOf(2, 1) = True Then%>
                            <th 
                        class="FormViewSubHeader" colspan="4" style="height: 22px"><asp:Literal 
                        ID="Literal89" runat="server" 
                        Text='<%# ResourceHelper.GetFromResource("Invoice Setup") %>' /></th></tr><tr><td 
                        align="right" class="FormViewLabelCell" style="width: 70%; height: 22px"><asp:Label 
                        ID="Label15" runat="server" AssociatedControlID="InvoiceNoPrefixTextBox">
                    <asp:Literal ID="Literal77" runat="server" 
                Text='<%# ResourceHelper.GetFromResource("Invoice No Prefix:") %>' /></asp:Label></td><td 
                        class="FormViewLabelCell" colspan="3" style="height: 22px; text-align: left"><asp:TextBox 
                            ID="InvoiceNoPrefixTextBox" runat="server" MaxLength="5" Width="91px"></asp:TextBox></td></tr><tr><td 
                        align="right" class="FormViewLabelCell" style="width: 70%; height: 22px"><asp:Literal 
                        ID="Literal97" runat="server" 
                        Text='<%# ResourceHelper.GetFromResource("SHow Project Name In Invoice Report:") %>' /></td><td 
                        colspan="3" style="height: 22px"><asp:CheckBox 
                            ID="chkShowProjectNameInInvoiceReport" runat="server" /></td></tr><tr><td 
                        align="right" class="FormViewLabelCell" style="width: 70%; height: 22px"><asp:Literal 
                        ID="Literal98" runat="server" 
                        Text='<%# ResourceHelper.GetFromResource("Show Billing Rate In Invoice Report:") %>' /></td><td 
                        colspan="3" style="height: 22px"><asp:CheckBox 
                            ID="chkShowBillingRateInInvoiceReport" runat="server" /></td></tr><tr><td 
                        align="right" class="FormViewLabelCell" style="width: 70%; height: 22px">Show Entry Date In Invoice Report:</td><td 
                        colspan="3" style="height: 22px"><asp:CheckBox 
                            ID="chkShowEntryDateInInvoiceReport" runat="server" /></td></tr><tr><td 
                        align="right" class="FormViewLabelCell" style="width: 70%; height: 22px">Show Employee Name In Invoice Report:</td><td 
                        colspan="3" style="height: 22px"><asp:CheckBox 
                            ID="chkShowEmployeeNameInInvoiceReport" runat="server" /></td></tr><tr><td 
                        align="right" class="FormViewLabelCell" style="width: 70%; height: 22px"><asp:Literal 
                        ID="Literal99" runat="server" 
                        Text='<%# ResourceHelper.GetFromResource("Invoice Billing Type:") %>' /></td><td 
                        colspan="3" style="height: 22px"><asp:DropDownList ID="ddlInvoiceBillingTypeId" 
                            runat="server" AppendDataBoundItems="True" 
                            DataSourceID="dsSystemInvoiceBillingType" DataTextField="InvoiceBillingType" 
                            DataValueField="InvoiceBillingTypeId" Width="150px"></asp:DropDownList></td></tr><tr><td 
                        align="right" style="height: 22px; width: 55%;" valign="top"><asp:Literal ID="Literal21" 
                        runat="server" 
                        Text='<%# ResourceHelper.GetFromResource("Invoice Footer:") %>' /></td><td 
                        colspan="3" style="height: 22px"><asp:TextBox ID="txtInvoiceFooter" 
                            runat="server" Height="75px" MaxLength="2000" TextMode="MultiLine" 
                            Width="500px"></asp:TextBox></td></tr><tr><td align="right" 
                        style="height: 22px; width: 55%;"></td><td colspan="3" style="height: 22px"><asp:Button 
                            ID="btnInvoice" runat="server" onclick="btnInvoice_Click" 
                            Text="<%$ Resources:TimeLive.Resource, Update_text%> " /></td></tr><tr><%  End If%><%If System.Configuration.ConfigurationManager.AppSettings("DISABLE_LICENSE") <> "Yes" Then%><%If System.Configuration.ConfigurationManager.AppSettings("ApplicationMode") = "Hosted" Then %><tr><th 
                        class="FormViewSubHeader" colspan="4" style="height: 22px"><asp:Literal 
                        ID="Literal67" runat="server" 
                        Text='<%# ResourceHelper.GetFromResource("Package Plan:") %>' /></th></tr><tr><td 
                            align="right" class="FormViewLabelCell" style="width: 55%; height: 22px"><asp:Literal 
                            ID="Literal69" runat="server" 
                            Text='<%# ResourceHelper.GetFromResource("Package:") %>' /></td><td 
                            style="width: 15%; height: 22px"><asp:DropDownList ID="ddlPackage" 
                                runat="server" Width="200px"><asp:ListItem Value="1">Lite</asp:ListItem><asp:ListItem 
                                    Value="5">Basic</asp:ListItem><asp:ListItem Value="10">Standard</asp:ListItem><asp:ListItem 
                                    Value="15">Enterprise</asp:ListItem></asp:DropDownList></td><td 
                            style="width: 40%; height: 22px"><asp:Button ID="btnChangePlanTo" 
                                runat="server" OnClick="btnChangePlanTo_Click" Text="Update Plan" 
                                Width="110px" /><asp:Button ID="btnRenew" runat="server" 
                                OnClick="btnRenew_Click" Text="Renew" Width="110px" /></td></tr><tr><td 
                            align="right" class="FormViewLabelCell" style="width: 55%; height: 22px"><asp:Literal 
                            ID="Literal63" runat="server" 
                            Text='<%# ResourceHelper.GetFromResource("License Users Usage:") %>' /></td><td 
                            colspan="3" style="height: 22px"><asp:Label ID="lblNumberOfUsersForHosted" 
                                runat="server" CssClass="ErrorMessage" Width="192px"></asp:Label></td></tr><tr><th 
                            class="FormViewSubHeader" colspan="4" style="height: 22px"><asp:Literal 
                            ID="Literal64" runat="server" 
                            Text='<%# ResourceHelper.GetFromResource("Account Expiry") %>' /></th></tr><tr><td 
                            align="right" class="FormViewLabelCell" style="width: 55%; height: 22px"><asp:Literal 
                            ID="Literal65" runat="server" 
                            Text='<%# ResourceHelper.GetFromResource("Expiry Date:") %>' /></td><td 
                            style="width: 15%; height: 22px"><asp:Label ID="lblExpiryDate" runat="server" 
                                CssClass="ErrorMessage" Text="lblExpiryDate" Width="160px"></asp:Label></td><td 
                            style="width: 40%; height: 22px"></td></tr><tr><td align="right" 
                            class="FormViewLabelCell" style="width: 55%; height: 22px"></td><td 
                            colspan="3" style="width: 15%; height: 22px"><asp:Label ID="Label26" 
                                runat="server" CssClass="ErrorMessage" 
                                Text="<%$ Resources:TimeLive.Resource, TimeLive supports unlimited users support up to 30 days. After 30 days it converts to 5 users free account%> "></asp:Label></td></tr><%End If %><% If System.Configuration.ConfigurationManager.AppSettings("ApplicationMode") = "Installed" Then%><tr><th 
                            align="left" class="FormViewSubHeader" colspan="4" style="height: 22px"><asp:Literal 
                            ID="Literal4" runat="server" 
                            Text='<%# ResourceHelper.GetFromResource("License Activation") %>' /></th></tr><tr><td 
                            align="right" class="FormViewLabelCell" style="width: 55%; height: 22px"><asp:Label 
                            ID="Label22" runat="server" AssociatedControlID="txtLicenseKeys">
                    <asp:Literal ID="Literal28" runat="server" 
            Text='<%# ResourceHelper.GetFromResource("License Key") %>' /></asp:Label></td><td 
                            colspan="3" style="height: 22px"><asp:TextBox ID="txtLicenseKeys" 
                                runat="server" Text="" Width="304px"></asp:TextBox><asp:Label 
                                ID="lblLicenseError" runat="server" CssClass="ErrorMessage" 
                                Text="License Required" Visible="False"></asp:Label></td></tr><tr><td 
                            align="right" class="FormViewLabelCell" style="width: 55%; height: 22px"></td><td 
                            colspan="3" style="height: 22px"><asp:RadioButton ID="rdOnlineActivation" 
                                runat="server" AutoPostBack="True" GroupName="License" 
                                OnCheckedChanged="rdOnlineActivation_CheckedChanged" 
                                Text='<%# ResourceHelper.GetFromResource("Online Activation") %>' /></td></tr><tr><td 
                            align="right" class="FormViewLabelCell" style="width: 55%; height: 22px"></td><td 
                            colspan="3" style="height: 22px"><asp:RadioButton ID="rdManualActivation" 
                                runat="server" AutoPostBack="True" GroupName="License" 
                                OnCheckedChanged="rdManualActivation_CheckedChanged" 
                                Text='<%# ResourceHelper.GetFromResource("Manual Activation") %>' /><asp:Label 
                                ID="lblActivationFailed" runat="server" CssClass="ErrorMessage" 
                                Text="<%$ Resources:TimeLive.Resource, Activation Failed%>" Visible="False"></asp:Label></td></tr><tr><td 
                            align="right" class="FormViewLabelCell" style="width: 55%; height: 22px"><asp:Label 
                            ID="Label23" runat="server" AssociatedControlID="MachineNameTextBox">
                     <asp:Literal ID="Literal61" runat="server" 
                Text='<%# ResourceHelper.GetFromResource("Machine Name:") %>' /></asp:Label></td><td 
                            colspan="3" style="height: 22px"><asp:TextBox ID="MachineNameTextBox" 
                                runat="server" ReadOnly="True" Text="" Width="304px"></asp:TextBox></td></tr><tr><td 
                            align="right" class="FormViewLabelCell" style="width: 55%; height: 22px"><asp:Label 
                            ID="Label24" runat="server" AssociatedControlID="MachineKeyTextBox">
                     <asp:Literal ID="Literal62" runat="server" 
                Text='<%# ResourceHelper.GetFromResource("Machine Key:") %>' /></asp:Label></td><td 
                            colspan="3" style="height: 22px"><asp:TextBox ID="MachineKeyTextBox" 
                                runat="server" Text="" Width="304px"></asp:TextBox><asp:Label 
                                ID="lblMachineKeyError" runat="server" CssClass="ErrorMessage" 
                                Text="Machine Key Required" Visible="False"></asp:Label></td></tr><tr><td 
                            align="right" class="FormViewLabelCell" style="width: 55%; height: 22px"><asp:Literal 
                            ID="Literal29" runat="server" Text="License Users Usage:" /></td><td 
                            colspan="3" style="height: 22px"><asp:Label ID="lblNumberOfUsers" 
                                runat="server" CssClass="ErrorMessage" Width="192px"></asp:Label></td></tr><% If LicensingBLL.IsValidLicenseActivation() = False Then%><tr><td 
                            align="right" class="FormViewLabelCell" style="width: 55%; height: 22px"><asp:Literal 
                            ID="Literal78" runat="server" 
                            Text='<%# ResourceHelper.GetFromResource("Unlimited User Support Expiry:") %>' /></td><td 
                            style="width: 15%; height: 22px"><asp:Label ID="lblExpiryDateLicense" 
                                runat="server" CssClass="ErrorMessage" Text="lblExpiryDate" Width="160px"></asp:Label></td><td 
                            style="width: 40%; height: 22px"></td></tr><tr><td align="right" 
                            class="FormViewLabelCell" style="width: 55%; height: 22px"></td><td 
                            colspan="3" style="width: 15%; height: 22px"><asp:Label ID="Label1" 
                                runat="server" CssClass="ErrorMessage" 
                                Text="<%$ Resources:TimeLive.Resource, TimeLive supports unlimited users support up to 30 days. After 30 days it converts to 5 users free account%> "></asp:Label></td></tr><%End If%><tr><td 
                            align="right" style="width: 35%;"></td><td colspan="3"><asp:Button 
                                ID="cmdActivateSerial" runat="server" OnClick="cmdActivateSerial_Click" 
                                Text='<%# ResourceHelper.GetFromResource("Activate") %>' /></td></tr><%End If %><%End If %><tr><th 
                            align="left" class="FormViewSubHeader" colspan="4" style="height: 22px"><asp:Literal 
                            ID="Literal5" runat="server" 
                            Text='<%# ResourceHelper.GetFromResource("Upload Own Company Logo") %>' /></th></tr><tr><td 
                            align="right" class="formviewlabelcell" style="width: 55%; height: 22px"><asp:Literal 
                            ID="Literal30" runat="server" 
                            Text='<%# ResourceHelper.GetFromResource("Company Own Logo") %>' /></td><td 
                            colspan="3" style="height: 22px"><asp:FileUpload ID="txtCompanyLogo" 
                                runat="server" Width="100%" /></td></tr><tr><td align="right" 
                            class="formviewlabelcell" style="width: 55%; height: 22px"><asp:Literal 
                            ID="Literal31" runat="server" 
                            Text='<%# ResourceHelper.GetFromResource("Show Company Own Logo") %>' /></td><td 
                            colspan="3" style="height: 22px"><asp:CheckBox ID="chkIsShowCompanyOwnLogo" 
                                runat="server" /><asp:Literal ID="Literal75" runat="server" 
                                Text='<%# ResourceHelper.GetFromResource("Show Company Own Logo") %>' /><asp:Label 
                                ID="lblLogoSize" runat="server" ForeColor="Red" 
                                Text="Logo size (Width 180px Height 50px)"></asp:Label></td></tr><tr><td 
                            align="right" style="width: 55%; height: 22px"></td><td colspan="3" 
                            style="height: 22px"><asp:Button ID="btnUpload" runat="server" 
                                OnClick="btnUpload_Click" Text="<%$ Resources:TimeLive.Resource, Update_Text%> " /></td></tr></tr></tr></table>

        </EditItemTemplate>
        <InsertItemTemplate>
            <table border="0" cellpadding="2" cellspacing="1" style="width: 100%; height: 31%; border-right: black 1px solid; border-top: black 1px solid; border-left: black 1px solid; border-bottom: black 1px solid;" class="xFormView">
                <tr>
                    <th class="caption" colspan="2" width="30%" align="left">
                        <asp:Literal ID="Literal1" runat="server" Text="Provide Your Information" /></th>
                </tr>
                <tr>
                    <th class="FormViewSubHeader" colspan="2" style="height: 22px" width="30%" align="left">
                        <asp:Literal 
                            ID="Literal5" runat="server" Text="Registration Form" /></th>
                </tr>
                <tr>
                    <td style="height: 22px;" class="FormViewLabelCell" width="30%" align="right">
                        Account Name:</td><td style="width: 65%; height: 22px;">
                  <asp:DropDownList 
                            ID="DropDownList4" runat="server" DataSourceID="AccountObjectDataSource" 
                            DataTextField="AccountName" DataValueField="AccountId" Width="200px" 
                            onselectedindexchanged="DropDownList4_SelectedIndexChanged" 
                            AutoPostBack="True"></asp:DropDownList>
                        <asp:HyperLink ID="HyperLink1" runat="server" 
                            NavigateUrl="~/Home/AccountAdd.aspx">Create New Account</asp:HyperLink>
                        <asp:ObjectDataSource 
                            ID="AccountObjectDataSource" runat="server" 
                            DataObjectTypeName="System.Web.UI.WebControls.FileUpload" 
                            DeleteMethod="FileUpload" InsertMethod="AddAccountForActiveDirectory" 
                            OldValuesParameterFormatString="original_{0}" SelectMethod="GetAccounts" 
                            TypeName="AccountBLL" UpdateMethod="UpdateAccountReimbursementCurrencyId"><InsertParameters><asp:Parameter 
                                    Name="AccountTypeId" Type="Int16" /><asp:Parameter Name="AccountName" 
                                    Type="String" /><asp:Parameter Name="Address1" Type="String" /><asp:Parameter 
                                    Name="Address2" Type="String" /><asp:Parameter Name="ZipCode" 
                                    Type="String" /><asp:Parameter Name="City" Type="String" /><asp:Parameter 
                                    Name="CountryId" Type="Int16" /><asp:Parameter Name="EMailAddress" 
                                    Type="String" /><asp:Parameter Name="EmployeeCode" Type="String" /><asp:Parameter 
                                    Name="Telephone" Type="String" /><asp:Parameter Name="Fax" Type="String" /><asp:Parameter 
                                    Name="DefaultCurrencyId" Type="Int16" /><asp:Parameter Name="TimeZoneId" 
                                    Type="Byte" /><asp:Parameter Name="EmployeeLogin" Type="String" /><asp:Parameter 
                                    Name="EmployeePassword" Type="String" /><asp:Parameter 
                                    Name="EmployeeEMailAddress" Type="String" /><asp:Parameter 
                                    Name="EmployeeFirstName" Type="String" /><asp:Parameter 
                                    Name="EmployeeLastName" Type="String" /><asp:Parameter 
                                    Name="EmployeePrefix" Type="String" /><asp:Parameter 
                                    Name="EmployeeMiddleName" Type="String" /><asp:Parameter Name="State" 
                                    Type="String" /><asp:Parameter Name="IsDisabled" Type="Boolean" /><asp:Parameter 
                                    Name="IsDeleted" Type="Boolean" /><asp:Parameter Name="CreatedOn" 
                                    Type="DateTime" /><asp:Parameter Name="ModifiedOn" Type="DateTime" /><asp:Parameter 
                                    Name="UserInterfaceLanguage" Type="String" /></InsertParameters><UpdateParameters><asp:Parameter 
                                    Name="Original_AccountId" Type="Int32" /><asp:Parameter 
                                    Name="AccountReimbursementCurrencyId" Type="Int32" /></UpdateParameters></asp:ObjectDataSource></td></tr><%Dim LDAP As New LDAPUtilitiesBLL%>
                <%If LDAP.IsAspNetActiveDirectoryMembershipProvider = True Then%>
                <tr>
                    <td align="right" class="FormViewLabelCell" style="height: 22px" width="30%">
                        <asp:Label ID="lblUsername" runat="server" Text="Login: "></asp:Label></td><td style="width: 65%; height: 22px">
                        <asp:TextBox 
                            ID="UsernameTextBox" runat="server" Text='<%# Bind("EmployeeLogin") %>'
                            Width="190px" OnTextChanged="UsernameTextBox_TextChanged" 
                            AutoPostBack="True"></asp:TextBox><br /><asp:CustomValidator ID="CustomValidator2" runat="server" CssClass="ErrorMessage"
                            Display="Dynamic" ErrorMessage="Specified user not exist or it is not the member of 'TimeLiveAdministrator' group." OnServerValidate="CustomValidator2_ServerValidate1"></asp:CustomValidator></td></tr><%End If %><tr>
                    <td align="right" class="FormViewLabelCell" style="height: 22px" width="30%">
                        <SPAN class=reqasterisk>*</SPAN><asp:Literal ID="Literal70" runat="server" Text="Email Address:" /></td>
                        <td style="width: 65%; height: 22px">
                        <asp:TextBox ID="EmployeeEMailAddress" 
                            runat="server" Text='<%# Bind("EmployeeEMailAddress") %>'
                            Width="190px" OnTextChanged="EmployeeEMailAddress_TextChanged"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="EmployeeEMailAddress"
                            Display="Dynamic" ErrorMessage="*" Width="1px"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="EmployeeEMailAddress"
                            CssClass="ErrorMessage" ErrorMessage="Invalid EMail Address" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="Dynamic"></asp:RegularExpressionValidator><asp:Label ID="lblExceptionText" runat="server" CssClass="ErrorMessage" Text="Login Already Exist"
                            Visible="False"></asp:Label><%If LDAP.IsAspNetActiveDirectoryMembershipProvider <> True Then%><%End IF %></td></tr><tr>
                    <td style="height: 22px" class="FormViewLabelCell" width="30%" align="right">
                        <SPAN 
                  class=reqasterisk>*</SPAN><asp:Literal ID="Literal45" runat="server" Text="Password:" /></td>
                    <td style="width: 65%; height: 22px">
                        <asp:TextBox ID="PasswordTextBox" 
                            runat="server" Text='<%# Bind("EmployeePassword") %>' TextMode="Password" 
                            Width="190px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="PasswordTextBox"
                            Display="Dynamic" ErrorMessage="*" Width="1px"></asp:RequiredFieldValidator></td></tr><tr>
                    <td style="height: 22px" class="FormViewLabelCell" width="30%" align="right">
                        <SPAN 
                  class=reqasterisk>*</SPAN><asp:Literal ID="Literal46" runat="server" Text="Verify:" /></td>
                    <td style="width: 65%; height: 22px">
                        <asp:TextBox ID="VerifyPasswordTextBox" 
                            runat="server"  TextMode="Password" Width="190px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="PasswordTextBox"
                            Display="Dynamic" ErrorMessage="*" Width="1px"></asp:RequiredFieldValidator><asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="VerifyPasswordTextbox"
                                ControlToValidate="PasswordTextBox" CssClass="ErrorMessage" ErrorMessage="(Mismatch)"></asp:CompareValidator></td></tr><tr>
                    <td style="height: 22px" class="FormViewLabelCell" width="30%" align="right">
                        <SPAN 
                  class=reqasterisk>*</SPAN><asp:Literal ID="Literal48" runat="server" Text="First Name:" /></td>
                    <td style="width: 65%; height: 22px">
                        <asp:TextBox ID="FirstNameTextBox" 
                            runat="server" Text='<%# Bind("EmployeeFirstName") %>' Width="190px" 
                            MaxLength="75"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="FirstNameTextBox"
                            Display="Dynamic" ErrorMessage="*" Width="1px"></asp:RequiredFieldValidator></td></tr><tr>
                    <td style="height: 22px" class="FormViewLabelCell" width="30%" align="right">
                        <SPAN 
                  class=reqasterisk>*</SPAN><asp:Literal ID="Literal50" runat="server" Text="Last Name:" /></td>
                    <td style="width: 65%; height: 22px">
                        <asp:TextBox ID="LastNameTextBox" 
                            runat="server" Text='<%# Bind("EmployeeLastName") %>' Width="190px" 
                            MaxLength="75"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="LastNameTextBox"
                            Display="Dynamic" ErrorMessage="*" Width="1px"></asp:RequiredFieldValidator></td></tr><tr><td 
                        align="right" class="FormViewLabelCell" style="height: 22px" width="30%">Role:</td><td 
                        style="width: 65%; height: 22px"><asp:DropDownList ID="ddlAccountRoleId" 
                            runat="server" DataSourceID="dsAccountRoleObjectInsert" DataTextField="Role" 
                            DataValueField="AccountRoleId" 
                            Width="200px" AutoPostBack="True"></asp:DropDownList></td></tr><tr><td align="right" 
                        class="FormViewLabelCell" style="height: 22px" width="30%"><asp:Literal 
                        ID="Literal38" runat="server" Text="Country:" /></td><td 
                        style="width: 65%; height: 22px"><asp:DropDownList ID="ddlCountryId" 
                            runat="server" DataSourceID="dsCountryObject" DataTextField="Country" 
                            DataValueField="CountryId" SelectedValue='<%# Bind("CountryId") %>' 
                            Width="200px"></asp:DropDownList></td></tr><tr><td align="right" 
                        class="FormViewLabelCell" style="height: 22px" width="30%"><asp:Literal 
                        ID="Literal42" runat="server" Text="TimeZone:" /></td><td 
                        style="width: 65%; height: 22px"><asp:DropDownList ID="ddlTimeZoneId" 
                            runat="server" DataSourceID="dsTimeZone" DataTextField="TimeZoneName" 
                            DataValueField="SystemTimeZoneId" SelectedValue='<%# Bind("TimeZoneId") %>' 
                            Width="368px"></asp:DropDownList></td></tr><tr>
                    <td style="height: 22px" width="30%" align="right">
                    </td>
                    <td style="width: 65%; height: 22px">
                        <asp:Button ID="Button1" runat="server"  
                            Text="<%$ Resources:TimeLive.Resource, Sign Up%> " CommandName="Insert" 
                            onclick="Button1_Click"  /><asp:CustomValidator ID="CustomValidatorInsert" runat="server" CssClass="ErrorMessage"
                            Display="Dynamic" ErrorMessage="Invalid username or password" OnServerValidate="CustomValidatorInsert_ServerValidate"></asp:CustomValidator></td></tr></table></InsertItemTemplate><ItemTemplate>
            <asp:Literal ID="Literal43" runat="server" Text="<%$ Resources:TimeLive.Resource, Account Id %> " />
            <asp:Label ID="AccountIdLabel" runat="server" Text='<%# Eval("AccountId") %>'></asp:Label><br  /><asp:Literal ID="Literal51" runat="server" Text="<%$ Resources:TimeLive.Resource, Account Type Id %> " />
            <asp:Label ID="AccountTypeIdLabel" runat="server" Text='<%# Bind("AccountTypeId") %>'>
            </asp:Label><br  /><asp:Literal ID="Literal52" runat="server" Text="<%$ Resources:TimeLive.Resource, Account Login %> " />
            <asp:Label ID="AccountLoginLabel" runat="server" Text='<%# Bind("AccountLogin") %>'>
            </asp:Label><br  /><asp:Literal ID="Literal53" runat="server" Text="<%$ Resources:TimeLive.Resource, Account Name %> " />
            <asp:Label ID="AccountNameLabel" runat="server" Text='<%# Bind("AccountName") %>'>
            </asp:Label><br  /><asp:Literal ID="Literal54" runat="server" Text="<%$ Resources:TimeLive.Resource, Address1%> " />
            <asp:Label ID="Address1Label" runat="server" Text='<%# Bind("Address1") %>'></asp:Label><br  /><asp:Literal ID="Literal55" runat="server" Text="<%$ Resources:TimeLive.Resource, Address2%> " />
            <asp:Label ID="Address2Label" runat="server" Text='<%# Bind("Address2") %>'></asp:Label><br  /><asp:Literal ID="Literal56" runat="server" Text="<%$ Resources:TimeLive.Resource, Zipcode%> " />
            <asp:Label ID="ZipCodeLabel" runat="server" Text='<%# Bind("ZipCode") %>'></asp:Label><br  />EMail Address: <asp:Label ID="EMailAddressLabel" runat="server" Text='<%# Bind("EMailAddress") %>'>
            </asp:Label><br  /><asp:Literal ID="Literal58" runat="server" Text="<%$ Resources:TimeLive.Resource, Telephone %> " />
            <asp:Label ID="TelephoneLabel" runat="server" Text='<%# Bind("Telephone") %>'></asp:Label><br  /><asp:Literal ID="Literal59" runat="server" Text="<%$ Resources:TimeLive.Resource, Fax %> " />
            <asp:Label ID="FaxLabel" runat="server" Text='<%# Bind("Fax") %>'></asp:Label><br  />Default Currency Id: <asp:Label ID="DefaultCurrencyIdLabel" runat="server" Text='<%# Bind("DefaultCurrencyId") %>'>
            </asp:Label><br  />IsDisabled <asp:CheckBox ID="IsDisabledCheckBox" runat="server" Checked='<%# Bind("IsDisabled") %>'
                Enabled="false"  /><br  />
            IsDeleted_text <asp:CheckBox ID="IsDeletedCheckBox" runat="server" Checked='<%# Bind("IsDeleted") %>'
                Enabled="false"  /><br  />
            StatusId: <asp:Label ID="StatusIdLabel" runat="server" Text='<%# Bind("StatusId") %>'></asp:Label><br  />CreatedOn: <asp:Label ID="CreatedOnLabel" runat="server" Text='<%# Bind("CreatedOn") %>'></asp:Label><br  />ModifiedOn: <asp:Label ID="ModifiedOnLabel" runat="server" Text='<%# Bind("ModifiedOn") %>'>
            </asp:Label><br  /><asp:Literal ID="Literal66" runat="server" Text="<%$ Resources:TimeLive.Resource, City%> " />
            <asp:Label ID="CityLabel" runat="server" Text='<%# Bind("City") %>'></asp:Label><br  />Country: <asp:Label ID="CountryIdLabel" runat="server" Text='<%# Bind("CountryId") %>'></asp:Label><br  /><asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" CommandName="Edit"
                Text="<%$ Resources:TimeLive.Resource, Edit_text%> ">
            </asp:LinkButton><asp:LinkButton ID="DeleteButton" runat="server" CausesValidation="False" CommandName="Delete"
                Text="<%$ Resources:TimeLive.Resource, Delete_text%> ">
            </asp:LinkButton><asp:LinkButton ID="NewButton" runat="server" CausesValidation="False" CommandName="New"
                Text="<%$ Resources:TimeLive.Resource, New_text%> ">
            </asp:LinkButton></ItemTemplate></asp:FormView>
            </ContentTemplate>
            </asp:UpdatePanel><br />
    <div style="text-align: center">
    <asp:ObjectDataSource id="ObjectDataSource1" runat="server" TypeName="AccountBLL" SelectMethod="GetAccounts" OldValuesParameterFormatString="original_{0}" DataObjectTypeName="System.Web.UI.WebControls.FileUpload" DeleteMethod="FileUpload" UpdateMethod="UpdateApplicationVersion">
        <UpdateParameters>
            <asp:Parameter Name="Version" Type="String" />
            <asp:Parameter Name="AccountId" Type="Int32" />
        </UpdateParameters>
    </asp:ObjectDataSource> <asp:ObjectDataSource ID="dsTimeZone" runat="server" OldValuesParameterFormatString="original_{0}"
                            SelectMethod="GetTimeZones" TypeName="SystemDataBLL" OnSelecting="dsTimeZone_Selecting"></asp:ObjectDataSource><asp:ObjectDataSource ID="dsLocaleInfo" runat="server" OldValuesParameterFormatString="original_{0}"
                            SelectMethod="GetAllCultureInfo" TypeName="LocaleUtilitiesBLL" OnSelecting="dsTimeZone_Selecting">
                            </asp:ObjectDataSource><asp:ObjectDataSource ID="dsCurrencySymbol" runat="server" OldValuesParameterFormatString="original_{0}"
                            SelectMethod="GetAllCultureCurrencySymbolInfo" TypeName="LocaleUtilitiesBLL" OnSelecting="dsTimeZone_Selecting">
                            </asp:ObjectDataSource>
                    <asp:ObjectDataSource id="dsAccountEmployee" runat="server" TypeName="TimeLiveDataSetTableAdapters.AccountEmployeeTableAdapter" SelectMethod="GetData" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}">
        <InsertParameters>
            <asp:Parameter Name="Login" Type="String"  />
            <asp:Parameter Name="Password" Type="String"  />
            <asp:Parameter Name="Prefix" Type="String"  />
            <asp:Parameter Name="FirstName" Type="String"  />
            <asp:Parameter Name="LastName" Type="String"  />
            <asp:Parameter Name="MiddleName" Type="String"  />
            <asp:Parameter Name="EMailAddress" Type="String"  />
            <asp:Parameter Name="AccountId" Type="Int32"  />
            <asp:Parameter Name="AccountDepartmentId" Type="Int32"  />
            <asp:Parameter Name="AccountRoleId" Type="Int32"  />
            <asp:Parameter Name="AddressLine1" Type="String"  />
            <asp:Parameter Name="AddressLine2" Type="String"  />
            <asp:Parameter Name="State" Type="Int16"  />
            <asp:Parameter Name="City" Type="String"  />
            <asp:Parameter Name="Zip" Type="String"  />
            <asp:Parameter Name="CountryId" Type="Int16"  />
            <asp:Parameter Name="HomePhoneNo" Type="String"  />
            <asp:Parameter Name="WorkPhoneNo" Type="String"  />
            <asp:Parameter Name="MobilePhoneNo" Type="String"  />
            <asp:Parameter Name="BillingRateCurrencyId" Type="Int16"  />
            <asp:Parameter Name="BillingRate" Type="Decimal"  />
            <asp:Parameter Name="BillingRateStateDate" Type="DateTime"  />
            <asp:Parameter Name="StartDate" Type="DateTime"  />
            <asp:Parameter Name="TerminationDate" Type="DateTime"  />
            <asp:Parameter Name="StatusId" Type="Byte"  />
            <asp:Parameter Name="IsDeleted" Type="Boolean"  />
            <asp:Parameter Name="IsDisabled" Type="Boolean"  />
            <asp:Parameter Name="DefaultProjectId" Type="Int32"  />
            <asp:Parameter Name="TimeZoneId" Type="Int16"  />
        </InsertParameters>
    </asp:ObjectDataSource> <asp:ObjectDataSource id="dsAccountTypeObject" runat="server" TypeName="SystemDataBLL" SelectMethod="GetAccountTypes" OldValuesParameterFormatString="original_{0}">
            </asp:ObjectDataSource> <asp:ObjectDataSource id="dsCountryObject" runat="server" TypeName="SystemDataBLL" SelectMethod="GetCountries" OldValuesParameterFormatString="original_{0}">
    </asp:ObjectDataSource> <asp:ObjectDataSource id="dsAccountObject" 
        runat="server" TypeName="AccountEmployeeBLL" SelectMethod="GetAccountEmployeesByAccountEmployeeId" 
        InsertMethod="AddAccountEmployee" 
        OldValuesParameterFormatString="original_{0}" 
        DeleteMethod="DeleteAccountEmployee"><DeleteParameters><asp:Parameter 
                Name="Original_AccountEmployeeId" Type="Int32" /></DeleteParameters><InsertParameters>
            <asp:Parameter 
                Name="Username" Type="String" /><asp:Parameter Name="Password" 
                Type="String" /><asp:Parameter Name="FirstName" Type="String" /><asp:Parameter 
                Name="LastName" Type="String" /><asp:Parameter Name="EMailAddress" Type="String" />
            <asp:Parameter Name="EmployeeCode" Type="String" />
            <asp:Parameter 
                Name="AccountId" Type="Int32" /><asp:Parameter Name="AccountDepartmentId" 
                Type="Int32" /><asp:Parameter Name="AccountRoleId" Type="Int32" /><asp:Parameter 
                Name="AccountLocationId" Type="Int32" /><asp:Parameter Name="CountryId" Type="Int16" />
            <asp:Parameter 
                Name="BillingTypeId" Type="Int32" /><asp:Parameter Name="StartDate" 
                Type="DateTime" /><asp:Parameter Name="DefaultProjectId" Type="Int32" /><asp:Parameter 
                Name="EmployeeManagerId" Type="Int32" /><asp:Parameter Name="TimeZoneId" Type="Byte" />
            <asp:Parameter 
                Name="CreatedByEmployeeId" Type="Int32" /><asp:Parameter 
                Name="ModifiedByEmployeeId" Type="Int32" /><asp:Parameter DbType="Guid" 
                Name="EmployeePayTypeId" /><asp:Parameter Name="StatusId" Type="Int32" /><asp:Parameter 
                Name="JobTitle" Type="String" /><asp:Parameter Name="HiredDate" 
                Type="DateTime" /><asp:Parameter Name="TerminationDate" Type="DateTime" /><asp:Parameter 
                DbType="Guid" Name="AccountWorkingDayTypeId" /><asp:Parameter DbType="Guid" 
                Name="AccountTimeOffPolicyId" /><asp:Parameter Name="TimeOffApprovalTypeId" 
                Type="Int32" /><asp:Parameter DbType="Guid" Name="AccountHolidayTypeId" /><asp:Parameter 
                Name="IsForcePasswordChange" Type="Boolean" /><asp:Parameter Name="UserInterfaceLanguage" Type="String" />
        <asp:Parameter 
                Name="AddressLine1" Type="String" /><asp:Parameter Name="AddressLine2" 
                Type="String" /><asp:Parameter Name="State" Type="String" />
            <asp:Parameter Name="City" Type="String" />
            <asp:Parameter Name="Zip" 
                Type="String" /><asp:Parameter Name="HomePhoneNo" Type="String" /><asp:Parameter 
                Name="WorkPhoneNo" Type="String" /><asp:Parameter Name="MobilePhoneNo" 
                Type="String" /><asp:Parameter Name="MiddleName" Type="String" /><asp:Parameter 
                Name="Prefix" Type="String" /><asp:Parameter Name="DoNotSendEMail" 
                Type="Boolean" /><asp:Parameter Name="CustomField1" Type="String" 
                Direction="InputOutput" /><asp:Parameter Direction="InputOutput" 
                Name="CustomField2" Type="String" /><asp:Parameter Direction="InputOutput" 
                Name="CustomField3" Type="String" /><asp:Parameter Direction="InputOutput" 
                Name="CustomField4" Type="String" /><asp:Parameter Direction="InputOutput" 
                Name="CustomField5" Type="String" /><asp:Parameter Direction="InputOutput" 
                Name="CustomField6" Type="String" /><asp:Parameter Direction="InputOutput" 
                Name="CustomField7" Type="String" /><asp:Parameter Direction="InputOutput" 
                Name="CustomField8" Type="String" /><asp:Parameter Direction="InputOutput" 
                Name="CustomField9" Type="String" /><asp:Parameter Direction="InputOutput" 
                Name="CustomField10" Type="String" /><asp:Parameter Direction="InputOutput" 
                Name="CustomField11" Type="String" /><asp:Parameter Direction="InputOutput" 
                Name="CustomField12" Type="String" /><asp:Parameter Direction="InputOutput" 
                Name="CustomField13" Type="String" /><asp:Parameter Direction="InputOutput" 
                Name="CustomField14" Type="String" /><asp:Parameter Direction="InputOutput" 
                Name="CustomField15" Type="String" /></InsertParameters>
        <SelectParameters>
            <asp:Parameter Name="AccountEmployeeId" Type="Int32" /></SelectParameters>
    </asp:ObjectDataSource> <asp:ObjectDataSource id="dsCurrencyObject" runat="server" TypeName="SystemDataBLL" SelectMethod="GetCurrencies" OldValuesParameterFormatString="original_{0}">
    </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="dsSystemNamePrefixObject" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetNamePrefix" TypeName="SystemDataBLL"></asp:ObjectDataSource><asp:ObjectDataSource id="dsWeekStartDayObject" runat="server" TypeName="AccountWorkingDayBLL" SelectMethod="GetAccountWorkingDaysResourceByAccountId" OldValuesParameterFormatString="original_{0}" DeleteMethod="DeleteAccountWorkingDayId" InsertMethod="AddAccountWorkingDay">
                <SelectParameters>
                    <asp:SessionParameter DefaultValue="151" Name="AccountId" SessionField="AccountId"
                        Type="Int32" />
                </SelectParameters>
                <DeleteParameters>
                    <asp:Parameter Name="Original_AccountWorkingDayId" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="AccountId" Type="Int32" />
                    <asp:Parameter Name="WorkingDayNo" Type="Int32" />
                </InsertParameters>
            </asp:ObjectDataSource>
        <asp:ObjectDataSource 
        ID="dsSystemInvoiceBillingType" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetInvoiceBillingType" TypeName="SystemDataBLL"></asp:ObjectDataSource><asp:ObjectDataSource 
        ID="dsSystemTimeEntryHoursFormat" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetSystemTimeEntryHoursFormat" TypeName="SystemDataBLL"></asp:ObjectDataSource>
        <asp:ObjectDataSource 
        id="dsAccountRoleObjectInsert" runat="server" UpdateMethod="UpdateAccountRole" 
        DeleteMethod="DeleteAccountRole" InsertMethod="AddAccountRole" 
        TypeName="AccountRoleBLL" SelectMethod="GetvueAccountRolesByIsSystemRoleAndIsDisabled" 
        OldValuesParameterFormatString="original_{0}"><DeleteParameters>
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
                <asp:Parameter DefaultValue="64" Name="AccountId" Type="Int32" />
                <asp:Parameter Name="AccountRoleId" Type="Int32" />
            </SelectParameters>
            <InsertParameters>
                <asp:Parameter Name="AccountId" Type="Int32" />
                <asp:Parameter Name="Role" Type="String" />
                <asp:Parameter Name="CreatedByEmployeeId" Type="Int32" />
                <asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" />
                <asp:Parameter Name="LDAPRole" Type="String" />
            </InsertParameters>
</asp:ObjectDataSource> &nbsp;&nbsp;&nbsp;</div>