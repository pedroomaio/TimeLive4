<%@ Control Language="vb" AutoEventWireup="false" Inherits="TimeLive.ctlAccountForm" CodeFile="ctlAccountForm.ascx.vb" %>
<%@ Register Assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2"
    Namespace="eWorld.UI" TagPrefix="ew" %>
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc2" %>
<%@ Register Assembly="eWorld.UI"
    Namespace="eWorld.UI" TagPrefix="ew" %>
    <%@ Register Assembly="MSCaptcha" Namespace="MSCaptcha" TagPrefix="cc1" %> 
<style type="text/css">
    .style1
    {
        width: 100%;
    }
    .tooltiplocal{
    display: inline;
    position: relative; 
}
.tooltiplocal:hover:after{
    background: #333;
    background: rgba(0,0,0,.8);
    border-radius: 5px;
    bottom: 26px;
    color: #fff;
    content: attr(title);
    left: 20%;
    padding: 5px 15px;
    position: absolute;
    z-index: 98;
    width: 350px; 
}
.tooltiplocal:hover:before{
    border: solid;
    border-color: #333 transparent;
    border-width: 6px 6px 0 6px;
    bottom: 20px;
    content: "";
    left: 50%;
    position: absolute;
    z-index: 99; 
}
</style>
<script type="text/javascript">
    function fncsave() {
        var clickButton = document.getElementById("<%= btnSignup.ClientID %>");
        clickButton.click();
    }
</script>
<asp:FormView id="FormView1" DefaultMode="Insert" 
    DataSourceID="dsAccountObject" SkinID="xgridviewSkinEmployee" 
    DataKeyNames="AccountId" runat="server" 
            Width="98%" HorizontalAlign="Center" CssClass="xFormView">
        <EditItemTemplate>
             <table width="100%" class="xFormView" >
              <tr>
        <th  class="caption">
            <asp:Literal ID="Literal1" runat="server" Text="<%$ Resources:TimeLive.Resource, Application Preference%> " /></th>
    </tr>
             
    <tr><td>
        <table border="0" cellpadding="2" class="xview" cellspacing="1" style="width: 100%; border:2px Solid White;" >
                                <tr>
                                <td >
                                    <aspToolkit:TabContainer 
                        ID="TabContainer1" runat="server" ActiveTabIndex="0" Width="100%" 
                        ScrollBars="Auto" UseVerticalStripPlacement="false" cssclass="MyTabStyle">                        
                        <aspToolkit:TabPanel ID="TabPanel9" runat="server" HeaderText='<%# ResourceHelper.GetFromResource("Organization") %>'>
                            <ContentTemplate>
                      <table cellpadding="2" cellspacing="1" style="width: 100%;border:2px Solid White;" class="xFormView">
                                    <tr>
                                        <th align="left" class="FormViewSubHeader" colspan="2">
                                        <asp:Literal ID="Literal4" runat="server" Text='<%# ResourceHelper.GetFromResource("Organization Information") %>' /></th>
                                    </tr>
                                    <tr>
                                        <td align="right" class="FormViewLabelCell" style="width: 28%; height: 22px;">
                                            <SPAN class=reqasterisk>*</span> 
                                            <asp:Literal ID="Literal11" runat="server" Text='<%# ResourceHelper.GetFromResource("Account Name") %>' />
                                        </td>
                                        <td style="width: 70%; height: 22px">
                                            <asp:TextBox ID="AccountName" runat="server" Text='<%# Bind("AccountName") %>' Width="340px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="AccountName"
                                            Display="Dynamic" ErrorMessage="*" Width="1px" CssClass="ErrorMessage"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="FormViewLabelCell" style="width: 28%; height: 22px">
                                            <SPAN class=reqasterisk>*</span>                  
                                            <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="EMailAddressTextBox"><asp:Literal ID="Literal12" runat="server" Text='<%# ResourceHelper.GetFromResource("Email Address:") %>' />
</asp:Label></td><td style="width: 70%; height: 22px">
                                            <asp:TextBox ID="EMailAddressTextBox" runat="server" 
                                                Text='<%# Bind("EMailAddress") %>' Width="340px"></asp:TextBox>&nbsp; <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="EMailAddressTextBox" CssClass="ErrorMessage" ErrorMessage="Invalid EMail Address" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator></td></tr><tr>
                                        <td align="right" class="FormViewLabelCell" style="width: 28%; height: 22px">
                                            <asp:Label ID="Label4" runat="server" AssociatedControlID="Address1TextBox"><asp:Literal ID="Literal6" runat="server" Text='<%# ResourceHelper.GetFromResource("Address1:") %>' />
</asp:Label></td><td style="width: 70%; height: 22px">
                                            <asp:TextBox ID="Address1TextBox" runat="server" 
                                                Text='<%# Bind("Address1") %>' Width="340px"></asp:TextBox></td></tr><tr>
                                        <td align="right" class="FormViewLabelCell" style="width: 28%; height: 22px">
                                            <asp:Label ID="Label2" runat="server" AssociatedControlID="Address2TextBox"><asp:Literal ID="Literal7" runat="server" Text='<%# ResourceHelper.GetFromResource("Address2:") %>' />
</asp:Label></td><td style="width: 70%; height: 22px">
                                            <asp:TextBox ID="Address2TextBox" runat="server" 
                                                Text='<%# Bind("Address2") %>' Width="340px"></asp:TextBox></td></tr><tr>
                                        <td align="right" class="FormViewLabelCell" style="width: 28%; height: 22px">
                                            <asp:Label ID="Label6" runat="server" AssociatedControlID="ZipCodeTextBox"><asp:Literal ID="Literal2" runat="server" Text='<%# ResourceHelper.GetFromResource("Zipcode") %>' />
</asp:Label></td><td style="width: 70%; height: 22px">
                                            <asp:TextBox ID="ZipCodeTextBox" runat="server" 
                                                Text='<%# Bind("ZipCode") %>' Width="140px"></asp:TextBox></td></tr><tr>
                                        <td align="right" class="FormViewLabelCell" style="width: 28%; height: 22px">
                                            <asp:Label ID="Label8" runat="server" AssociatedControlID="CityTextBox"><asp:Literal ID="Literal3" runat="server" Text='<%# ResourceHelper.GetFromResource("City:") %>' />
</asp:Label></td><td style="width: 70%; height: 22px">
                                            <asp:TextBox ID="CityTextBox" runat="server" 
                                                Text='<%# Bind("City") %>' Width="140px"></asp:TextBox></td></tr><tr>
                                        <td align="right" class="FormViewLabelCell" style="width: 28%; height: 22px">
                                            <SPAN class=reqasterisk>*</span><asp:Literal ID="Literal8" runat="server" Text='<%# ResourceHelper.GetFromResource("Country:") %>' />
                                        </td>
                                        <td style="width: 70%; height: 22px">
                                            <asp:DropDownList ID="DropDownList3" 
                                                runat="server" DataSourceID="dsCountryObject" DataTextField="Country" 
                                                DataValueField="CountryId"  SelectedValue='<%# Bind("CountryId") %>' 
                                                Width="152px" ></asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="FormViewLabelCell" style="width: 28%; height: 22px">
                                            <asp:Label ID="Label10" runat="server" AssociatedControlID="TelephoneTextBox"><asp:Literal ID="Literal13" runat="server" Text='<%# ResourceHelper.GetFromResource("Telephone:") %>' />
</asp:Label></td><td style="width: 70%; height: 22px">
                                            <asp:TextBox ID="TelephoneTextBox" runat="server" 
                                                Text='<%# Bind("Telephone") %>' Width="140px"></asp:TextBox></td></tr><tr>
                                        <td align="right" class="FormViewLabelCell" style="width: 28%; height: 22px">
                                            <asp:Label ID="Label12" runat="server" AssociatedControlID="FaxTextBox"><asp:Literal ID="Literal14" runat="server" Text='<%# ResourceHelper.GetFromResource("Fax:") %>' />
</asp:Label></td><td style="width: 70%; height: 22px">
                                            <asp:TextBox ID="FaxTextBox" runat="server" Text='<%# Bind("Fax") %>' 
                                                Width="140px"></asp:TextBox></td></tr><tr>
                                        <td align="right" class="FormViewLabelCell" style="width: 28%; height: 22px">
                                            <asp:Literal ID="Literal9" runat="server" Text='<%# ResourceHelper.GetFromResource("TimeZone:") %>' />
                                        </td>
                                        <td style="width: 70%; height: 22px">
                                            <asp:DropDownList ID="ddlTimeZoneId" 
                                                runat="server" DataSourceID="dsTimeZone" DataTextField="TimeZoneName" 
                                                DataValueField="SystemTimeZoneId"  SelectedValue='<%# Bind("TimeZoneId") %>' 
                                                Width="353px" ></asp:DropDownList>
                                        </td>
                                        </tr>
                                        </table>
                      </ContentTemplate>
                      </aspToolkit:TabPanel>
                        <aspToolkit:TabPanel ID="TabPanel10" runat="server" HeaderText='<%# ResourceHelper.GetFromResource("General Preferences") %>'>
                            <ContentTemplate>
                        <table cellpadding="2" cellspacing="1" style="width: 98%;border:2px Solid White;" class="xFormView">
                                    <tr>
                                        <th align="left" class="FormViewSubHeader" colspan="2">
                                        <asp:Literal ID="Literal20" runat="server" Text='<%# ResourceHelper.GetFromResource("General Information") %>' /></th>
                                    </tr>
                                    <tr>
                                        <td align="right" class="FormViewLabelCell" style="height: 22px">
                                            <asp:Literal ID="Literal94" runat="server" Text='<%# ResourceHelper.GetFromResource("Enable Password Complexity:") %>' />
                                        </td>
                                        <td style="height: 22px">
                                            <asp:CheckBox ID="chkEnablePasswordComplexity" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="FormViewLabelCell" style="height: 22px">
                                            <asp:Literal ID="Literal10" runat="server" Text='<%# ResourceHelper.GetFromResource("Lock Submitted Records") %>' />
                                        </td>
                                        <td style="height: 22px">
                                            <asp:CheckBox ID="chkLockSubmittedRecord" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="FormViewLabelCell" style="height: 22px">
                                            <asp:Literal ID="Literal15" runat="server" Text='<%# ResourceHelper.GetFromResource("Lock In-Approval Records") %>' />
                                        </td>
                                        <td style="height: 22px">
                                            <asp:CheckBox ID="chkLockApprovedRecord" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="FormViewLabelCell" style="height: 22px">
                                            <asp:Literal ID="Literal105" runat="server" Text='<%# ResourceHelper.GetFromResource("Use Electronic Signature:") %>' /> 
                                            </td>
                                            <td style="height: 22px">
                                            <asp:CheckBox ID="chkShowElectronicSign" runat="server" />
                                        </td>
                                    </tr>
                                     <tr>
                                        <td align="right" class="FormViewLabelCell" style="width: 38%; height: 22px">
                                            <asp:Literal ID="Literal28" runat="server" Text='<%# ResourceHelper.GetFromResource("Show Additional Department Information In Employee:") %>' />
                                        </td>
                                        <td style="width: 60%; height: 22px">
                                            <asp:CheckBox ID="chkShowAdditionalDepartmentInformationInEmployee" runat="server" />
                                        </td>
                                    </tr>
                                     <tr>
                                        <td align="right" class="FormViewLabelCell" style="width: 38%; height: 22px">
                                            <asp:Literal ID="Literal114" runat="server" Text='<%# ResourceHelper.GetFromResource("Show Employee Name With Code:") %>' />
                                        </td>
                                        <td style="width: 60%; height: 22px">
                                            <asp:CheckBox ID="ChkShowEmployeeNameWithCode" runat="server" />
                                        </td>
                                    </tr>
                                    <% If System.Configuration.ConfigurationManager.AppSettings("ApplicationMode") = "Hosted" Then%>
                                     <tr>
                                        <td align="right" class="FormViewLabelCell" style="width: 38%; height: 22px">
                                        <a href="#" title="Please make sure that the email address for each person in TimeLive is consistent with the values in your Google account." class="tooltiplocal" style="line-height:18px;text-align:left;"><img title="" style="vertical-align:middle;padding-bottom:1px;" src="../Images/info.png" /></a>
                                            <asp:Literal ID="Literal115" runat="server" Text="Enable Google Apps Authentication:" />
                                        </td>
                                        <td style="height: 22px">
                                            <asp:CheckBox ID="chkGoogleAuthentication" runat="server" />
                                            
                                            
                                        </td>
                                    </tr>
                                            <%End If %>
                                    <tr>
                                        <td align="right" class="FormViewLabelCell" style="width: 38%; height: 22px">
                                            <asp:Literal ID="Literal116" runat="server" Text="Show Disable Employees In Report:" />
                                        </td>
                                        <td style="width: 60%; height: 22px">
                                            <asp:CheckBox ID="ChkShowDisableEmployeesInReport" runat="server" />
                                        </td>
                                    </tr>
                                    <tr style="display:none;">
                                        <td align="right" class="FormViewLabelCell" style="width: 38%; height: 22px">
                                            <asp:Literal ID="Literal122" runat="server" Text="Hide Project From Application:" />
                                        </td>
                                        <td style="width: 60%; height: 22px">
                                            <asp:CheckBox ID="ChkHideProjectFromApplication" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="FormViewLabelCell" style="height: 22px">
                                            <asp:Label ID="Label16" runat="server" AssociatedControlID="txtPasswordExpiryPeriod"><asp:Literal ID="Literal86" runat="server" Text='<%# ResourceHelper.GetFromResource("Password Expiry Period") %>' />
</asp:Label></td><td style="height: 22px">
                                            <asp:TextBox ID="txtPasswordExpiryPeriod" runat="server" Width="50px"></asp:TextBox>&nbsp;<asp:Label ID="Labeldays" runat="server">Days</asp:Label><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtPasswordExpiryPeriod" CssClass="ErrorMessage" Display="Dynamic" ErrorMessage="*" Width="8px"></asp:RequiredFieldValidator>&nbsp;<asp:Label 
                                                                ID="LabelPEP" runat="server" ForeColor="Red">(0 = No Expiry)</asp:Label>&nbsp;<asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="txtPasswordExpiryPeriod" CssClass="ErrorMessage" Display="Dynamic" ErrorMessage="Numeric required" 
                                            Font-Bold="False" MaximumValue="99999" MinimumValue="0" Type="Integer"></asp:RangeValidator></td></tr><tr>
                                        <td align="right" class="FormViewLabelCell" style="height: 22px">
                                            <asp:Label ID="Label17" runat="server" AssociatedControlID="TPScheduledEmailSendTime"><asp:Literal ID="Literal19" runat="server" Text='<%# ResourceHelper.GetFromResource("Scheduled Email Sent Time") %>' />
</asp:Label></td><td style="height: 22px">
                                            <asp:TextBox ID="TPScheduledEmailSendTime" runat="server" Width="50px"></asp:TextBox><cc2:MaskedEditExtender 
                                                                ID="MaskedEditExtenderTPScheduledEmailSendTime" runat="server" Mask="99:99 " 
                                                                MaskType="Time" TargetControlID="TPScheduledEmailSendTime" 
                                                                CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" 
                                                                CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                                                                CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" 
                                                                Century="2000"></cc2:MaskedEditExtender><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TPScheduledEmailSendTime" CssClass="ErrorMessage" 
                                            Display="Dynamic" ErrorMessage="*" Width="8px"></asp:RequiredFieldValidator><cc2:MaskedEditValidator 
                                                                ID="MaskedEditValidatorEmailSentTime" runat="server" 
                                            ControlExtender="MaskedEditExtenderTPScheduledEmailSendTime" 
                                                                ControlToValidate="TPScheduledEmailSendTime" Display="Dynamic" 
                                                                EmptyValueMessage="*" ErrorMessage="MaskedEditValidatorEmailSentTime" 
                                            InvalidValueMessage="Invalid Time" ValidationGroup="TimeEntry"></cc2:MaskedEditValidator></td></tr><tr>
                                        <td align="right" class="FormViewLabelCell" style="height: 22px">
                                            <asp:Label ID="Label18" runat="server" AssociatedControlID="SessionTimeOutTextBox"><asp:Literal ID="Literal24" runat="server" Text='<%# ResourceHelper.GetFromResource("Session Time Out") %>' />
</asp:Label></td><td style="height: 22px">
                                            <asp:TextBox ID="SessionTimeOutTextBox" runat="server" Width="50px" MaxLength="3"></asp:TextBox>&nbsp;<asp:Literal ID="Literal74" runat="server" Text='<%# ResourceHelper.GetFromResource("Minutes") %>' />
                                            <asp:RangeValidator ID="RangeValidator4" runat="server" ControlToValidate="SessionTimeOutTextBox"
                                            CssClass="ErrorMessage" Display="Dynamic" ErrorMessage="Value must be greater then 0" Font-Bold="False" MaximumValue="999" MinimumValue="1" Type="Integer"></asp:RangeValidator></td></tr><tr>
                                        <td align="right" class="FormViewLabelCell" style="height: 22px">
                                            <asp:Literal ID="Literal73" runat="server" Text='<%# ResourceHelper.GetFromResource("Page Size:") %>' />
                                        </td>
                                        <td style="height: 22px">
                                            <asp:DropDownList ID="ddlPageSize" runat="server" 
                                                                AppendDataBoundItems="True" Width="62px"><asp:ListItem>20</asp:ListItem><asp:ListItem>10</asp:ListItem><asp:ListItem>40</asp:ListItem><asp:ListItem>30</asp:ListItem><asp:ListItem>50</asp:ListItem></asp:DropDownList></td></tr>
                                    <%If 1=2 Then%>
                                    <tr style="display:none;">
                                    <td align="right" class="FormViewLabelCell" style="height: 22px">
                                            <asp:Literal ID="Literal23" runat="server" Text='<%# ResourceHelper.GetFromResource("Currency Symbol") %>' />
                                    </td>
                                    <td style="height: 22px">
                                            <asp:DropDownList ID="CurrencySymbol" runat="server" 
                                            AppendDataBoundItems="True" Width="62px" DataSourceID="dsCurrencySymbol" 
                                            DataTextField="CurrencySymbol" DataValueField="CurrencySymbol" ><asp:ListItem 
                                            Value="auto"></asp:ListItem></asp:DropDownList></td></tr><tr>
                                        <td align="right" class="FormViewLabelCell" style="height: 22px">
                                            <asp:Literal ID="Literal113" runat="server" Text="Google Apps Domain Name:" />
                                        </td>
                                        <td style="height: 22px">
                                            <asp:TextBox ID="txtDomainName" runat="server" MaxLength="50" 
                                                                Width="130px"></asp:TextBox></td></tr><%End If%><tr>
                                    <td align="right" class="FormViewLabelCell" style="height: 22px">
                                            <asp:Label ID="Label19" runat="server" AssociatedControlID="FromEmailAddressDisplayNameTextBox"><asp:Literal ID="Literal57" runat="server" Text='<%# ResourceHelper.GetFromResource("From Email Display Name") %>' />
</asp:Label></td><td style="height: 22px">
                                            <asp:TextBox ID="FromEmailAddressDisplayNameTextBox" runat="server" MaxLength="50" Width="130px"></asp:TextBox></td></tr><tr>
                                    <td align="right" class="FormViewLabelCell" style="height: 22px">
                                    <asp:Literal ID="Literal106" runat="server" Text='<%# ResourceHelper.GetFromResource("From Email Address") %>' />: </td><td style="height: 22px">
                                            <asp:TextBox ID="FromEmailAddressTextBox" runat="server" MaxLength="50" Width="130px"></asp:TextBox></td></tr><tr>
                                        <td align="right" class="FormViewLabelCell" style="height: 22px">
                                            <asp:Literal ID="Literal22" runat="server" Text='<%# ResourceHelper.GetFromResource("Standard and Formats") %>' />
                                        </td>
                                        <td style="height: 22px">
                                            <asp:DropDownList ID="CultureInfoName" runat="server" AppendDataBoundItems="True" DataSourceID="dsLocaleInfo" DataTextField="EnglishName" DataValueField="Name" Width="300px"><asp:ListItem 
                                                                    Value="auto"></asp:ListItem></asp:DropDownList></td></tr><tr>
                                     <td align="right" class="FormViewLabelCell" style="height: 22px">
                                            <asp:Literal ID="Literal121" runat="server" Text="Show Employee Name By:" /> </td>
                                     <td style="height: 22px">
                                            <asp:DropDownList ID="ddlShowEmployeeNameBy" runat="server" AppendDataBoundItems="True" Width="300px">
                                            <asp:ListItem Text="First Name And Last Name" Value="1"></asp:ListItem><asp:ListItem Text="Last Name And First Name" Value="2"></asp:ListItem></asp:DropDownList></td></tr><tr>
                                        <td align="right" class="FormViewLabelCell" style="height: 22px">
                                            <asp:Literal ID="Literal30" runat="server" Text='<%# ResourceHelper.GetFromResource("Company Own Logo") %>' />
                                        </td>
                                        <td style="height: 22px">
                                            <asp:FileUpload ID="txtCompanyLogo" runat="server" Width="98%" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="FormViewLabelCell" style="height: 22px">
                                            <asp:Literal ID="Literal31" runat="server" Text='<%# ResourceHelper.GetFromResource("Show Company Own Logo") %>' />
                                        </td>
                                        <td style="height: 22px">
                                            <asp:CheckBox ID="chkIsShowCompanyOwnLogo" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="FormViewLabelCell" style="height: 22px">
                                            </td><td style="height: 22px">
                                            <asp:Label ID="lblLogoSize" runat="server" ForeColor="Red" Text="Logo size (Width 180px Height 50px)"></asp:Label></td></tr></table></ContentTemplate></aspToolkit:TabPanel><aspToolkit:TabPanel ID="TabPanel2" runat="server" HeaderText='<%# ResourceHelper.GetFromResource("Invoice Setup") %>'>
                        <ContentTemplate>
                          <table cellpadding="2" cellspacing="1" style="width: 100%;border:2px Solid White;" class="xFormView">
                                <tr>
                                        <th align="left" class="FormViewSubHeader" colspan="2">
                                        <asp:Literal ID="Literal29" runat="server" Text='<%# ResourceHelper.GetFromResource("Invoice Information") %>' /></th>
                                    </tr>
                                    <tr>
                                        <td align="right" class="FormViewLabelCell" style="width: 30%; height: 22px">
                                            <asp:Literal ID="Literal97" runat="server" Text='<%# ResourceHelper.GetFromResource("SHow Project Name In Invoice Report:") %>' />
                                        </td>
                                        <td style="width: 65%; height: 22px">
                                            <asp:CheckBox ID="chkShowProjectNameInInvoiceReport" runat="server" />
                                        </td>
                                    </tr>     
                                    <tr>
                                        <td align="right" class="FormViewLabelCell" style="width: 30%; height: 22px">
                                            <asp:Literal ID="Literal98" runat="server" Text='<%# ResourceHelper.GetFromResource("Show Billing Rate In Invoice Report:") %>' />
                                        </td>
                                        <td style="width: 65%; height: 22px">
                                            <asp:CheckBox ID="chkShowBillingRateInInvoiceReport" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="FormViewLabelCell" style="width: 30%; height: 22px">
                                        <asp:Literal ID="Literal40" runat="server" Text='<%# ResourceHelper.GetFromResource("Show Entry Date In Invoice Report:") %>' />
                                             </td><td style="width: 65%; height: 22px">
                                            <asp:CheckBox ID="chkShowEntryDateInInvoiceReport" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="FormViewLabelCell" style="width: 30%; height: 22px">
                                        <asp:Literal ID="Literal46" runat="server" Text='<%# ResourceHelper.GetFromResource("Show Employee Name In Invoice Report:") %>' />
                                             </td><td style="width: 65%; height: 22px">
                                            <asp:CheckBox ID="chkShowEmployeeNameInInvoiceReport" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="FormViewLabelCell" style="width: 30%; height: 22px">
                                        <asp:Literal ID="Literal107" runat="server" Text='<%# ResourceHelper.GetFromResource("Show Work Type In Invoice Description:") %>'/>
                                            </td><td style="width: 65%; height: 22px">
                                           <asp:CheckBox ID="chkShowWorkTypeInInvoiceDescription" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="FormViewLabelCell" style="width: 30%; height: 22px">
                                        <asp:Literal ID="Literal111" runat="server" Text='<%# ResourceHelper.GetFromResource("Round-Off Tax Value In Invoice:") %>'/>
                                            </td><td style="width: 65%; height: 22px">
                                           <asp:CheckBox ID="chkRoundOffValueInInvoice" runat="server" />
                                        </td>
                                    </tr>
                                   
                                    <tr>
                                        <td align="right" class="FormViewLabelCell" style="width: 30%; height: 22px">
                                            <asp:Label ID="Label15" runat="server" AssociatedControlID="InvoiceNoPrefixTextBox"><asp:Literal ID="Literal77" runat="server" Text='<%# ResourceHelper.GetFromResource("Invoice No Prefix:") %>' />
                                        </asp:Label></td><td style="width: 65%; height: 22px">
                                            <asp:TextBox ID="InvoiceNoPrefixTextBox" runat="server" MaxLength="5" Width="150px"></asp:TextBox></td></tr><tr>
                                        <td align="right" class="FormViewLabelCell" style="width: 30%; height: 22px">
                                            <asp:Literal ID="Literal99" runat="server" Text='<%# ResourceHelper.GetFromResource("Invoice Billing Type:") %>' />
                                        </td>
                                        <td style="width: 65%; height: 22px">
                                            <asp:DropDownList ID="ddlInvoiceBillingTypeId" runat="server" AppendDataBoundItems="True" DataSourceID="dsSystemInvoiceBillingType" DataTextField="InvoiceBillingType" DataValueField="InvoiceBillingTypeId" Width="163px"></asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="FormViewLabelCell" style="width: 30%; height: 22px">
                                            <asp:Literal ID="Literal21" runat="server" Text='<%# ResourceHelper.GetFromResource("Invoice Footer:") %>' />
                                        </td>
                                        <td style="width: 65%; height: 22px; padding-bottom: 5px">
                                            <asp:TextBox ID="txtInvoiceFooter" runat="server" Height="140px" MaxLength="2000" TextMode="MultiLine" Width="495px"></asp:TextBox></table></ContentTemplate></aspToolkit:TabPanel><aspToolkit:TabPanel ID="TabPanel3" runat="server" HeaderText='<%# ResourceHelper.GetFromResource("Task Setup") %>'>
                            <ContentTemplate>
                          <table cellpadding="2" cellspacing="1" style="width: 100%;border:2px Solid White;" class="xFormView">
                                    <tr>
                                        <th align="left" class="FormViewSubHeader" colspan="2">
                                        <asp:Literal ID="Literal44" runat="server" Text='<%# ResourceHelper.GetFromResource("Task Information") %>' /></th>
                                    </tr>
                                    <tr>
                                        <td align="right" class="FormViewLabelCell" style="width: 30%; height: 22px">
                                            <asp:Literal ID="Literal95" runat="server" Text='<%# ResourceHelper.GetFromResource("Show Project Name In Task:") %>' />
                                        </td>
                                        <td style="width: 70%; height: 22px">
                                            <asp:CheckBox ID="chkShowProjectNameInTask" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="FormViewLabelCell" style="width: 30%; height: 22px">
                                            <asp:Literal ID="Literal64" runat="server" Text='<%# ResourceHelper.GetFromResource("Show Client Name In Task:") %>' />
                                            </td><td style="width: 70%; height: 22px">
                                            <asp:CheckBox ID="chkShowClientNameInTask" runat="server" />
                                        </td>
                                    </tr>
<%If DBUtilities.GetSessionAccountId = 6455 Then%>
                                    <tr>
                                        <td align="right" class="FormViewLabelCell" style="width: 38%; height: 22px">
                                            <asp:Literal ID="Literal109" runat="server" Text='<%# ResourceHelper.GetFromResource("Insert Default Task Name In Project:") %>' />
                                        </td>
                                        <td style="width: 60%; height: 22px">
                                            <asp:CheckBox ID="ChkInsertDefaultTaskNameInProject" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                    <td align="right" class="FormViewLabelCell" style="height: 22px">
                                    <asp:Literal ID="Literal110" runat="server" Text='<%# ResourceHelper.GetFromResource("Default Task Name") %>' />: </td><td style="height: 22px">
                                            <asp:TextBox ID="txtDefaultTaskName" runat="server" MaxLength="50" Width="130px"></asp:TextBox></td></tr><%End If%><tr>
                                    <td align="right" class="FormViewLabelCell" style="width: 35%; height: 22px">
                                        <asp:Literal ID="Literal117" runat="server" Text="Sort Task By:" /> </td><td style="width: 63%; height: 22px">
                                        <asp:DropDownList ID="ddlSortTaskBy" runat="server" AppendDataBoundItems="True" Width="150px"><asp:ListItem Text="Task Id" Value="TaskId"></asp:ListItem><asp:ListItem Text="Deadline Date" Value="DeadlineDate"></asp:ListItem></asp:DropDownList></td></tr></table></ContentTemplate></aspToolkit:TabPanel><aspToolkit:TabPanel ID="TabPanel4" runat="server" HeaderText='<%# ResourceHelper.GetFromResource("Project Setup") %>'>
                            <ContentTemplate>
                         <table cellpadding="2" cellspacing="1" style="width: 100%;border:2px Solid White;" class="xFormView">
                                    <tr>
                                        <th align="left" class="FormViewSubHeader" colspan="2">
                                        <asp:Literal ID="Literal47" runat="server" Text='<%# ResourceHelper.GetFromResource("Project Information") %>' /></th>
                                    </tr>
                                    <tr>
                                        <td align="right" class="FormViewLabelCell" style="width: 30%; height: 22px">
                                            <asp:Literal ID="Literal96" runat="server" Text='<%# ResourceHelper.GetFromResource("Auto Generate Project Code:") %>' />
                                        </td>
                                        <td style="width: 70%; height: 22px">
                                            <asp:CheckBox ID="chkAutoGenerateProjectCode" runat="server" />
                                        </td>
                                    </tr> 
                                    <tr>
                                        <td align="right" class="FormViewLabelCell" style="width: 30%; height: 22px">
                                            <asp:Literal ID="Literal65" runat="server" Text='<%# ResourceHelper.GetFromResource("Show Completed Project In Project List:") %>' /> </td><td style="width: 70%; height: 22px">
                                            <asp:CheckBox ID="chkShowCompletedProjectInProjectGrid" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="FormViewLabelCell" style="width: 30%; height: 22px">
                                           <asp:Literal ID="Literal67" runat="server" Text='<%# ResourceHelper.GetFromResource("Show Client Department In Project:") %>' /> </td><td style="width: 70%; height: 22px">
                                            <asp:CheckBox ID="chkShowClientDepartmentInProject" runat="server" />
                                    <tr>
                                        <td align="right" class="FormViewLabelCell" style="width: 30%; height: 22px">
                                            <asp:Literal ID="Literal69" runat="server" Text='<%# ResourceHelper.GetFromResource("Include Current Year In Project Code:") %>' /> </td><td style="width: 70%; height: 22px">
                                            <asp:CheckBox ID="chkIncludeCurrentYearInProjectCode" runat="server" />
                                        </td>
                                    </tr>
                                    <tr><td align="right" class="FormViewLabelCell" style="width: 38%; height: 22px">Automatically Include Administrator In Project Team:</td><td 
                                                                    style="width: 70%; height: 22px"><asp:CheckBox 
                                                                    ID="chkAutomaticallyIncludeAdministratorInProjectTeam" runat="server" /></td></tr>
                                    <tr><td align="right" class="FormViewLabelCell" style="width: 38%; height: 22px">Show Disable Project In Report:</td><td 
                                                                    style="width: 70%; height: 22px"><asp:CheckBox 
                                                                    ID="chkShowDisableProjectInReport" runat="server" /></td></tr>
                                     <tr>
                                        <td align="right" class="FormViewLabelCell" style="width: 30%; height: 22px">
                                        <asp:Literal ID="Literal112" runat="server" Text='<%# ResourceHelper.GetFromResource("Project Template Mandatory:") %>'/>
                                            </td><td style="width: 65%; height: 22px">
                                           <asp:CheckBox ID="chkIsProjectTemplateMandatory" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="FormViewLabelCell" style="width: 30%; height: 22px">
                                            <asp:Literal ID="Literal75" runat="server" Text='<%# ResourceHelper.GetFromResource("Project Code Prefix:") %>' /> </td><td style="width: 70%; height: 22px">
                                            <asp:TextBox ID="ProjectCodePrefixTextBox" runat="server" MaxLength="25" Width="120px"></asp:TextBox></td></tr></table></ContentTemplate></aspToolkit:TabPanel>
<aspToolkit:TabPanel ID="TabPanel5" runat="server" HeaderText='<%# ResourceHelper.GetFromResource("Time Off Setup") %>'>
<ContentTemplate>
                         <table cellpadding="2" cellspacing="1" style="width: 100%;border:2px Solid White;" class="xFormView">
                                    <tr>
                                        <th align="left" class="FormViewSubHeader" colspan="2">
                                        <asp:Literal ID="Literal61" runat="server" Text='<%# ResourceHelper.GetFromResource("Time Off Information") %>' /></th>
                                    </tr>
                                    <tr>
                                        <td align="right" class="FormViewLabelCell" style="width: 35%; height: 22px">
                                            <asp:Literal ID="Literal85" runat="server" Text='<%# ResourceHelper.GetFromResource("Show TimeOff In Timesheet:") %>' />
                                        </td>
                                        <td style="width: 63%; height: 22px">
                                            <asp:CheckBox ID="chkShowTimeOffInTimesheet" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="FormViewLabelCell" style="width: 30%; height: 22px">
                                            <asp:Literal ID="Literal101" runat="server" Text='<%# ResourceHelper.GetFromResource("Show Project For TimeOff:") %>' />
                                        </td>
                                        <td style="width: 70%; height: 22px">
                                            <asp:CheckBox ID="chkShowProjectForTimeOff" runat="server" />
                                        </td>
                                    </tr>
                                     <tr>
                                        <td align="right" class="FormViewLabelCell" style="width: 35%; height: 22px">
                                            <asp:Literal ID="Literal32" runat="server" Text='<%# ResourceHelper.GetFromResource("Show Time Off In Days:") %>' />
                                        </td>
                                        <td style="width: 63%; height: 22px">
                                            <asp:CheckBox ID="chkTimeoffHorsinDays" runat="server" />
                                        </td>
                                    </tr>
                                     <tr>
                                        <td align="right" class="FormViewLabelCell" style="width: 30%; height: 22px">
                                            <asp:Literal ID="Literal119" runat="server" Text='<%# ResourceHelper.GetFromResource("TimeOff Status Edit Mode:") %>' />
                                        </td>
                                        <td style="width: 70%; height: 22px">
                                            <asp:CheckBox ID="chkIsTimeOffStatusEditMode" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                    <td align="right" class="FormViewLabelCell" style="width: 35%; height: 22px">
                                    <asp:Literal ID="Literal203" runat="server" Text='<%# ResourceHelper.GetFromResource("Show TimeOff Types By:") %>' /> 
                                    </td>
                                    <td style="width: 63%; height: 22px">
                                    <asp:DropDownList ID="ddlTimeOffTypesBy" runat="server" AppendDataBoundItems="True" Width="150px">
                                    <asp:ListItem Text="Account" Value="Account">
                                    </asp:ListItem><asp:ListItem Text="Employee" Value="Employee"></asp:ListItem></asp:DropDownList></td></tr></table></ContentTemplate></aspToolkit:TabPanel><aspToolkit:TabPanel ID="TabPanel6" runat="server" HeaderText='<%# ResourceHelper.GetFromResource("Expense Setup") %>'>
                            <ContentTemplate>
                         <table cellpadding="2" cellspacing="1" style="width: 100%;border:2px Solid White;" class="xFormView">
                                    <tr>
                                        <th align="left" class="FormViewSubHeader" colspan="2">
                                        <asp:Literal ID="Literal62" runat="server" Text='<%# ResourceHelper.GetFromResource("Expense Information") %>' /></th>
                                    </tr>
                                    <tr>
                                        <td align="right" class="FormViewLabelCell" style="width: 30%; height: 22px">
                                            <asp:Literal ID="Literal60" runat="server" Text='<%# ResourceHelper.GetFromResource("Show Client In Expense Sheet:") %>' />
                                        </td>
                                        <td style="width: 70%; height: 22px">
                                            <asp:CheckBox ID="chkShowClientInExpenseSheet" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="FormViewLabelCell" style="width: 30%; height: 22px">
                                            <asp:Literal ID="Literal87" runat="server" Text='<%# ResourceHelper.GetFromResource("Show Task In Expense Sheet:") %>' />
                                        </td>
                                        <td style="width: 70%; height: 22px">
                                            <asp:CheckBox ID="chkShowTaskInExpenseSheet" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="FormViewLabelCell" style="width: 30%; height: 22px">
                                            <asp:Label ID="Label21" runat="server" AssociatedControlID="txtExpenseSheetPrintFooter">
                                            <asp:Literal ID="Literal81" runat="server" Text='<%# ResourceHelper.GetFromResource("Expense Sheet Print Footer:") %>' /></asp:Label></td><td style="width: 70%; height: 22px; padding-bottom: 5px">
                                            <asp:TextBox ID="txtExpenseSheetPrintFooter" runat="server" Height="140px" TextMode="MultiLine"
                                            Width="550px" ValidationGroup="vgPrintFooter" MaxLength="2000"></asp:TextBox><br /><asp:CustomValidator ID="cvExpenseSheetPrintFooter" runat="server" ControlToValidate="txtExpenseSheetPrintFooter"
                                            CssClass="ErrorMessage" ErrorMessage="Value must be less than or equal to 2000 characters."
                                            OnServerValidate="cvExpenseSheetPrintFooter_ServerValidate" ValidationGroup="vgPrintFooter" Display="Dynamic"></asp:CustomValidator></td></tr></table></ContentTemplate></aspToolkit:TabPanel><aspToolkit:TabPanel ID="TabPanel7" runat="server" HeaderText='<%# ResourceHelper.GetFromResource("Timesheet Setup") %>'>
                            <ContentTemplate>
                         <table cellpadding="2" cellspacing="1" style="width: 100%;border:2px Solid White;" class="xFormView">
                                    <tr>
                                        <th align="left" class="FormViewSubHeader" colspan="2">
                                        <asp:Literal ID="Literal63" runat="server" Text='<%# ResourceHelper.GetFromResource("Timesheet Information") %>' /></th>
                                    </tr>
                                    <tr>
                                        <td align="right" class="FormViewLabelCell" style="width: 35%; height: 22px">
                                            <asp:Literal ID="Literal16" runat="server" Text='<%# ResourceHelper.GetFromResource("Show Clock Start/End") %>' />
                                        </td>
                                        <td style="width: 63%; height: 22px">
                                            <asp:CheckBox ID="chkShowClockStartEnd" runat="server" Checked='<%# Bind("ShowClockStartEnd") %>' />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="FormViewLabelCell" style="width: 35%; height: 22px">
                                            <asp:Literal ID="Literal76" runat="server" Text='<%# ResourceHelper.GetFromResource("Show Client In Timesheet:") %>' />
                                        </td>
                                        <td style="width: 63%; height: 22px">
                                            <asp:CheckBox ID="chkShowClientInTimesheet" runat="server" />
                                        </td>
                                    </tr>
                                    <tr style="display:none;">
                                        <td align="right" class="FormViewLabelCell" style="width: 35%; height: 22px">
                                            <asp:Literal ID="Literal124" runat="server" Text="Show Project In Timesheet:" />
                                        </td>
                                        <td style="width: 63%; height: 22px">
                                            <asp:CheckBox ID="chkShowProjectInTimesheet" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="FormViewLabelCell" style="width: 35%; height: 22px">
                                            <asp:Literal ID="Literal17" runat="server" Text='<%# ResourceHelper.GetFromResource("Show Description In Week View:") %>' />
                                        </td>
                                        <td style="width: 63%; height: 22px">
                                            <asp:CheckBox ID="chkShowDescriptionInWeekView" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="FormViewLabelCell" style="width: 35%; height: 22px">
                                            <asp:Literal ID="Literal80" runat="server" Text='<%# ResourceHelper.GetFromResource("Show Completed Project In Timesheet:") %>' />
                                        </td>
                                        <td style="width: 63%; height: 22px">
                                            <asp:CheckBox ID="chkShowCompletedProjectsInTimeSheet" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="FormViewLabelCell" style="width: 35%; height: 22px">
                                            <asp:Literal ID="Literal25" runat="server" Text='<%# ResourceHelper.GetFromResource("Show Completed Task In Timesheet:") %>' />
                                        </td>
                                        <td style="width: 63%; height: 22px">
                                            <asp:CheckBox ID="chkShowCompletedTasksInTimeSheet" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="FormViewLabelCell" style="width: 35%; height: 22px">
                                            <asp:Literal ID="Literal26" runat="server" Text='<%# ResourceHelper.GetFromResource("Show Work Type In Timesheet") %>' />
                                        </td>
                                        <td style="width: 63%; height: 22px">
                                            <asp:CheckBox ID="chkShowWorkTypeInTimeSheet" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="FormViewLabelCell" style="width: 35%; height: 22px">
                                            <asp:Literal ID="Literal27" runat="server" Text='<%# ResourceHelper.GetFromResource("Show COst Center In Timesheet") %>' />
                                        </td>
                                        <td style="width: 63%; height: 22px">
                                            <asp:CheckBox ID="chkShowCostCenterInTimeSheet" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="FormViewLabelCell" style="width: 35%; height: 22px">
                                            <asp:Literal ID="Literal78" runat="server" Text='<%# ResourceHelper.GetFromResource("Show Copy Timesheet Button:") %>' /></td><td style="width: 63%; height: 22px">
                                            <asp:CheckBox ID="chkShowCopyTimesheetButton" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="FormViewLabelCell" style="width: 35%; height: 22px">
                                            <asp:Literal ID="Literal82" runat="server" Text='<%# ResourceHelper.GetFromResource("Show Copy Activities Button In Timesheet:") %>' /> </td><td style="width: 63%; height: 22px">
                                            <asp:CheckBox ID="chkShowCopyActivitiesButtonInTimesheet" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="FormViewLabelCell" style="width: 35%; height: 22px">
                                            <asp:Literal ID="Literal84" runat="server" Text='<%# ResourceHelper.GetFromResource("Enable Offline Timesheet:") %>' /> </td><td style="width: 63%; height: 22px">
                                            <asp:CheckBox ID="chkEnableOfflineTimesheet" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="FormViewLabelCell" style="width: 35%; height: 22px">
                                            <asp:Literal ID="Literal18" runat="server" Text='<%# ResourceHelper.GetFromResource("Show ShowAll in Approval Popup:") %>' />
                                        </td>
                                        <td style="width: 63%; height: 22px">
                                            <asp:CheckBox ID="chkShowAllInTimesheetReadOnly" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="FormViewLabelCell" style="width: 35%; height: 22px">
                                            <asp:Literal ID="Literal88" runat="server" Text='<%# ResourceHelper.GetFromResource("Show Task Percentage In Timesheet:") %>' /> </td><td style="width: 63%; height: 22px">
                                            <asp:CheckBox ID="chkShowPercentageInTimesheet" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="FormViewLabelCell" style="width: 35%; height: 22px">
                                            <asp:Literal ID="Literal89" runat="server" Text='<%# ResourceHelper.GetFromResource("Calculate Task Percentage Automatically:") %>' /> </td><td style="width: 63%; height: 22px">
                                            <asp:CheckBox ID="chkCalculateTaskPercentageAutomatically" runat="server" />
                                        </td>
                                    </tr>
<%If DBUtilities.GetSessionAccountId = 6455 Then%>
                                     <tr>
                                        <td align="right" class="FormViewLabelCell" style="width: 38%; height: 22px">
                                            <asp:Literal ID="Literal108" runat="server" Text='<%# ResourceHelper.GetFromResource("Default Project/Task Selection In Timesheet:") %>' />
                                        </td>
                                        <td style="width: 60%; height: 22px">
                                            <asp:CheckBox ID="ChkDefaultProjectTaskSelectionInTimesheet" runat="server" />
                                        </td>
                                    </tr>
<%End If%>
                                    <tr>
                                        <td align="right" class="FormViewLabelCell" style="width: 35%; height: 22px">
                                            <asp:Literal ID="Literal120" runat="server" Text="Auto Adjust Timesheet:" /> </td><td style="width: 63%; height: 22px">
                                            <asp:CheckBox ID="chkAutoAdjustTimesheet" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="FormViewLabelCell" style="width: 35%; height: 22px">
                                            <asp:Label ID="Label14" runat="server" AssociatedControlID="txtNumberOfBlankRowsInTimeEntry"><asp:Literal ID="Literal72" runat="server" Text='<%# ResourceHelper.GetFromResource("No Of Blank Rows In Timesheet") %>' />
</asp:Label></td><td style="width: 63%; height: 22px">
                                            <asp:TextBox ID="txtNumberOfBlankRowsInTimeEntry" runat="server" Width="50px"></asp:TextBox><asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtNumberOfBlankRowsInTimeEntry" CssClass="ErrorMessage" 
                                            Display="Dynamic" ErrorMessage="Must be between 1 and 15" Font-Bold="False" MaximumValue="15" MinimumValue="1" Type="Integer" 
                                            ValidationGroup="UpdateTimesheet"></asp:RangeValidator></td></tr><tr>
                                        <td align="right" class="FormViewLabelCell" style="width: 35%; height: 22px">
                                            <asp:Literal ID="Literal93" runat="server" Text='<%# ResourceHelper.GetFromResource("Timesheet Periods Overdue:") %>' /></td>
                                        </td>
                                        <td style="width: 63%; height: 22px">
                                            <asp:TextBox ID="txtTimesheetOverduePeriods" runat="server" Width="50px"></asp:TextBox><asp:RangeValidator ID="RangeValidator5" runat="server" ControlToValidate="txtTimesheetOverduePeriods" CssClass="ErrorMessage" Display="Dynamic" ErrorMessage="Must be between 1 and 10" Font-Bold="False" 
                                            MaximumValue="10" MinimumValue="0" Type="Integer" ValidationGroup="UpdateTimesheet"></asp:RangeValidator><asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtTimesheetOverduePeriods" CssClass="ErrorMessage" 
                                            Display="Dynamic" ErrorMessage="*" Width="8px"></asp:RequiredFieldValidator></td></tr><tr>
                                    <td align="right" class="FormViewLabelCell" style="width: 35%; height: 22px">
                                    <asp:Literal ID="Literal118" runat="server" Text='<%# ResourceHelper.GetFromResource("Show Clock Start/End By:") %>' /> 
                                    </td>
                                    <td style="width: 63%; height: 22px">
                                   <%-- <asp:UpdatePanel ID="UpdatePanel2" runat="server">
    <ContentTemplate>--%>

                                    <asp:DropDownList ID="ddlClockStartEndBy" runat="server" AppendDataBoundItems="True" Width="150px" AutoPostBack="True">
                                    <asp:ListItem Text="Account" Value="Account">
                                    </asp:ListItem><asp:ListItem Text="Employee" Value="Employee"></asp:ListItem></asp:DropDownList><%--  </ContentTemplate>
</asp:UpdatePanel>--%></td></tr><tr>
                                        <td align="right" class="FormViewLabelCell" style="width: 35%; height: 22px">
                                            <asp:Literal ID="Literal92" runat="server" Text='<%# ResourceHelper.GetFromResource("Time Entry Hours Format:") %>' /></td>
                                        </td>
                                        <td style="width: 63%; height: 22px">
                                            <asp:DropDownList ID="ddlTimeEntryHoursFormatId" runat="server" Width="150px" AppendDataBoundItems="True" DataSourceID="dsSystemTimeEntryHoursFormat" DataTextField="SystemTimeEntryHoursFormat" DataValueField="SystemTimeEntryHoursFormatId"><asp:ListItem Value="None">&lt;None&gt;</asp:ListItem></asp:DropDownList></td></tr><tr>
                                        <td align="right" class="FormViewLabelCell" style="width: 35%; height: 22px">
                                            <asp:Literal ID="Literal91" runat="server" Text='<%# ResourceHelper.GetFromResource("Time Entry Clock Format:") %>' /></td>
                                        </td>
                                        <td style="width: 63%; height: 22px">
                                            <asp:DropDownList ID="ddlTimeEntryFormat" runat="server" Width="150px" AppendDataBoundItems="True"><asp:ListItem Value="HH:mm">HH:MM</asp:ListItem><asp:ListItem Value="hh:mm tt">HH:MM AM/PM</asp:ListItem></asp:DropDownList></td></tr><tr>
                                        <td align="right" class="FormViewLabelCell" style="width: 35%; height: 22px">
                                            <asp:Literal ID="Literal100" runat="server" Text='<%# ResourceHelper.GetFromResource("Show Additional Task Information Type:") %>' />
                                        </td>
                                        <td style="width: 63%; height: 22px">
                                            <asp:DropDownList ID="ddlTaskInformation" runat="server" Width="150px"><asp:ListItem 
                                            Text="<%$ Resources:TimeLive.Resource, None%> " Value="0"></asp:ListItem><asp:ListItem 
                                            Text="<%$ Resources:TimeLive.Resource, Parent Task Name%> " Value="1"></asp:ListItem><asp:ListItem 
                                            Text="<%$ Resources:TimeLive.Resource, Parent Task Code%> " Value="2"></asp:ListItem><asp:ListItem 
                                            Text="<%$ Resources:TimeLive.Resource, Task Code%> " Value="3"></asp:ListItem></asp:DropDownList></td></tr><tr>
                                        <td align="right" class="FormViewLabelCell" style="width: 35%; height: 22px">
                                            <asp:Literal ID="Literal90" runat="server" Text='<%# ResourceHelper.GetFromResource("Show Additional Project Information Type in Timesheet:") %>' /> </td><td style="width: 63%; height: 22px">
                                            <asp:DropDownList ID="ddlProjectInformation" runat="server" Width="150px"><asp:ListItem 
                                            Text="<%$ Resources:TimeLive.Resource, None%> " Value="0"></asp:ListItem><asp:ListItem 
                                            Text="<%$ Resources:TimeLive.Resource, Project Code%> " Value="1"></asp:ListItem></asp:DropDownList></td></tr><tr><td align="right" class="FormViewLabelCell" style="width: 35%; height: 22px">
                                            <asp:Literal ID="Literal79" runat="server" Text='<%# ResourceHelper.GetFromResource("Default Time Entry Mode:") %>' />
                                            </td><td style="width: 63%; height: 22px"><asp:DropDownList ID="ddlDefaultTimeEntryMode" runat="server" AppendDataBoundItems="True" Width="150px">
                                            <asp:ListItem 
                                                Value="Day View"></asp:ListItem><asp:ListItem Value="Period View"></asp:ListItem></asp:DropDownList></td></tr><tr>
                                        <td align="right" class="FormViewLabelCell" style="width: 35%; height: 22px">
                                            <asp:Literal ID="Literal102" runat="server" Text='<%# ResourceHelper.GetFromResource("Sort Timesheet By:") %>' /> </td><td style="width: 63%; height: 22px">
                                            <asp:DropDownList ID="ddlTimesheetSort" runat="server" AppendDataBoundItems="True" Width="150px"><asp:ListItem Text="Default" Value="Default"></asp:ListItem><asp:ListItem Text="Client" Value="Client"></asp:ListItem></asp:DropDownList></td></tr><tr>
                                        <td align="right" class="FormViewLabelCell" style="width: 35%; height: 22px">
                                            <asp:Literal ID="Literal103" runat="server" Text='<%# ResourceHelper.GetFromResource("Show Cost Center In Timesheet By:") %>' /> </td><td style="width: 63%; height: 22px">
                                            <asp:DropDownList ID="ddlCostCenterInTimesheetBy" runat="server" AppendDataBoundItems="True" Width="150px"><asp:ListItem Text="Account" Value="Account"></asp:ListItem><asp:ListItem Text="Employee" Value="Employee"></asp:ListItem></asp:DropDownList></td></tr><tr>
                                        <td align="right" class="FormViewLabelCell" style="width: 35%; height: 22px">
                                            <asp:Label ID="Label20" runat="server" AssociatedControlID="txtTimesheetPrintFooter"><asp:Literal ID="Literal83" runat="server" Text='<%# ResourceHelper.GetFromResource("Timesheet Print Footer:") %>' />
</asp:Label></td><td style="width: 63%; height: 22px; padding-bottom: 5px">
                                            <asp:TextBox ID="txtTimesheetPrintFooter" runat="server" Height="140px" 
                                                        MaxLength="2000" TextMode="MultiLine" ValidationGroup="vgPrintFooter" 
                                                        Width="495px"></asp:TextBox><br /><asp:CustomValidator ID="cvTimesheetPrintFooter" runat="server" ControlToValidate="txtTimesheetPrintFooter" CssClass="ErrorMessage" Display="Dynamic" ErrorMessage="Value must be less than or equal to 2000 characters." OnServerValidate="cvTimesheetPrintFooter_ServerValidate" ValidationGroup="UpdateTimesheet"></asp:CustomValidator></td></tr></table></ContentTemplate></aspToolkit:TabPanel></aspToolkit:TabContainer></td></tr></table></td></tr><tr><td align="right" valign="top" style="padding-bottom: 4px"> 
        <asp:Button runat="server" Text="Update" ID="btnUpdate" 
    OnClick="btnUpdate_Click" Width="85px"></asp:Button>&nbsp;<asp:Button runat="server" 
                         Text="Cancel" ID="btnCancel" 
    Width="85px" onclick="btnCancel_Click"></asp:Button>&nbsp;&nbsp;</td></tr></table></EditItemTemplate><InsertItemTemplate>
      
                        
                         <table style="margin:0 auto;border:0px;padding:0px 0px 0px 0px"><tr><td>
    <asp:Image ID="imgCompanyOwnLogo" runat="server"  Height="50px"  ImageUrl="~/Images/TopHeader.png" AlternateText="CompanyLogo" />       
    </td></tr></table>
            <table cellpadding="0" cellspacing="0" class="xFormView" width="500" 
    
    
    style="border: 5px solid #F6F6F6;margin:0 auto">
    <tr>

    <td>
        <table cellpadding="0" cellspacing="0" class="xFormView" width="500" 
    
    
    style="border: 1px solid #d6dadf;margin:0 auto;font-family:Verdana">
            <tr>
                <th class="captionLogin" colspan="2">
                    <label style="font-weight:bold">Sign Up For Your TimeLive Account</label>
                </th>
            </tr>   
            <tr><td 
                         colspan="2" 
                    style="border: 1px solid #d6dadf; background-color: #F6F6F6; vertical-align: middle;padding: 5px 5px 5px 5px;line-height: 20px;font-weight: normal;font-size:11px;" 
                    height="30px" valign="middle">By filling in the form bellow and clicking the "Sign Up" button, you accept and agree to <a target="_blank" style="cursor:pointer" href="http://www.livetecs.com/terms-of-use/">Terms of Service</a> & <a target="_blank" style="cursor:pointer" href="http://www.livetecs.com/privacy-policy/">Privacy Policy.</a></td></tr>
                    <%If UIUtilities.IsAspNetActiveDirectoryMembershipProvider Then%>
                               <tr>
                     <td style="padding:15px 15px 15px 15px"><p class="block-label button-height">
						<label id="lblADUsername" for="block-label-1" class="label" style="font-size:11px;cursor:auto">Username</label>
						<input id="txtADUsername" runat="server" type="text" name="block-label-1" class="input" style="width:200px" value=""/>
					</p></td><td style="padding:15px 15px 15px 15px"><p class="block-label button-height">
						<label id="lblADEmail" for="block-label-1" class="label" style="font-size:11px;cursor:auto">Email Address</label>
						<input id="txtADEmail" runat="server" type="password" name="block-label-1" class="input" style="width:200px" value=""/>
					</p></td></tr>
                    <%End If%>
                 <tr>                
                     <td style="padding:15px 15px 15px 15px">
                  
                         						<p class="block-label button-height">
						<label id="lblFirstName" for="block-label-1" class="label" style="font-size:11px;cursor:auto">First Name</label>
						<input id="txtFirstName" runat="server" type="text" name="block-label-1" class="input" style="width:200px" value=""/>
					</p></td><td style="padding:15px 15px 15px 15px"><p class="block-label button-height">
						<label id="lblLastName" for="block-label-1" class="label" style="font-size:11px;cursor:auto">Last Name</label>
						<input id="txtLastName" runat="server" type="text" name="block-label-1" class="input" style="width:200px" value=""/>
					</p></td></tr>
                         <tr>
                     <td style="padding:15px 15px 15px 15px"><p class="block-label button-height">
						<label id="lblCompanyName" for="block-label-1" class="label" style="font-size:11px;cursor:auto">Company Name</label>
						<input id="txtCompanyName" runat="server" type="text" name="block-label-1" class="input" style="width:200px" value=""/>
					</p></td><td style="padding:15px 15px 15px 15px"><p class="block-label button-height">
						<label id="lblPhoneNo" for="block-label-1" class="label" style="font-size:11px;cursor:auto">Phone Number</label>
						<input id="txtPhoneNo" runat="server" type="text" name="block-label-1" class="input" style="width:200px" value=""/>
					</p></td></tr>
                         <tr>
                     <td style="padding:15px 15px 15px 15px"><p class="block-label button-height">
						<label id="lblEmail" for="block-label-1" class="label" style="font-size:11px;cursor:auto">Email Address <a href="#" title="Please enter a valid email address as a welcome email will be sent to you." class="tooltip"><img title="" src="../Images/info.png" /></a></label>
						<input id="txtEmail" runat="server" type="text" name="block-label-1" class="input" style="width:200px" value=""/>
					</p></td><td style="padding:15px 15px 15px 15px"><p class="block-label button-height">
						<label id="lblPassword" for="block-label-1" class="label" style="font-size:11px;cursor:auto">Password</label>
						<input id="txtPassword" runat="server" type="password" name="block-label-1" class="input" style="width:200px" value=""/>
					</p></td></tr>
                    <%If UIUtilities.GetApplicationMode = "Installed" Then%>
        <tr>
                     <td style="padding:15px 15px 15px 15px" colspan="2"><p class="block-label button-height">
						<label id="lblURL" for="block-label-1" class="label" style="font-size:11px;cursor:auto">Choose Your TimeLive URL <a href="#" title="The subdomain you choose will determine the web address at which you and your team will log into your TimeLive account." class="tooltip"><img title="" src="../Images/info.png" /></a></label>
						<input id="txtURL" runat="server" type="text" name="block-label-1" class="input" style="width:200px" value=""/><label style="font-size:11px;vertical-align:-webkit-baseline-middle">.livetecs.com</label>
					</p></td></tr>
                    <%End If%>
                    <tr><td 
                         colspan="2" 
                    style="border: 1px solid #d6dadf; background-color: #F6F6F6; text-align:right;padding:5px 17px 5px 5px;line-height: 20px;" 
                    height="30px"><a runat="server" id="btnSignup" href="javascript:void(0)" class="button green-gradient" onclick="fncsave()" >Sign Up</a></td></tr>
            
               </table></td></tr></table>
                    <table 
    cellpadding="0" cellspacing="0" align="center" class="xFormView" width="500" style="margin:0 auto;border:0px;padding:0px 0px 0px 0px;line-height:15px"><tr><td align="center"><asp:Label 
                    ID="Label3" runat="server" Font-Bold="False"><asp:Literal 
                                    ID="Literal5" runat="server" 
                                    
                        Text="TimeLive Powered By Livetecs LLC" /></asp:Label><asp:Label 
                    ID="Label5" runat="server" Font-Bold="False"></asp:Label></td></tr><tr><td align="center"><asp:Label 
                    ID="Label1" runat="server" Font-Bold="False"><asp:Literal 
                                    ID="CopyRightText" runat="server" 
                                    
                        Text="Copyright 2007 - 2015 Livetecs LLC. All rights reserved." /></asp:Label><asp:Label 
                    ID="Label2222" runat="server" Font-Bold="False"></asp:Label></td></tr></table>
        


                        </InsertItemTemplate><ItemTemplate>
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
            <asp:Literal ID="Literal95" runat="server" Text='<%# ResourceHelper.GetFromResource("IsDeleted_text") %>' /> <asp:CheckBox ID="IsDeletedCheckBox" runat="server" Checked='<%# Bind("IsDeleted") %>'
                Enabled="false"  /><br  />
            <asp:Literal ID="Literal104" runat="server" Text='<%# ResourceHelper.GetFromResource("StatusId:") %>' /> <asp:Label ID="StatusIdLabel" runat="server" Text='<%# Bind("StatusId") %>'></asp:Label><br  />CreatedOn: <asp:Label ID="CreatedOnLabel" runat="server" Text='<%# Bind("CreatedOn") %>'></asp:Label><br  />ModifiedOn: <asp:Label ID="ModifiedOnLabel" runat="server" Text='<%# Bind("ModifiedOn") %>'>
            </asp:Label><br  /><asp:Literal ID="Literal66" runat="server" Text="<%$ Resources:TimeLive.Resource, City%> " />
            <asp:Label ID="CityLabel" runat="server" Text='<%# Bind("City") %>'></asp:Label><br  />Country: <asp:Label ID="CountryIdLabel" runat="server" Text='<%# Bind("CountryId") %>'></asp:Label><br  /><asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" CommandName="Edit"
                Text="<%$ Resources:TimeLive.Resource, Edit_text%> ">
            </asp:LinkButton><asp:LinkButton ID="DeleteButton" runat="server" CausesValidation="False" CommandName="Delete"
                Text="<%$ Resources:TimeLive.Resource, Delete_text%> ">
            </asp:LinkButton><asp:LinkButton ID="NewButton" runat="server" CausesValidation="False" CommandName="New"
                Text="<%$ Resources:TimeLive.Resource, New_text%> ">
</asp:LinkButton></ItemTemplate></asp:FormView><a runat="server" id="btnSignup" href="javascript:void(0)" class="button green-gradient" style="display:none">Sign Up</a>
            
            
            <br />
<div style="text-align: center">
    <asp:ObjectDataSource id="ObjectDataSource1" 
        runat="server" TypeName="AccountBLL" SelectMethod="GetAccounts" 
        OldValuesParameterFormatString="original_{0}" 
        DataObjectTypeName="System.Web.UI.WebControls.FileUpload" 
        DeleteMethod="FileUpload" UpdateMethod="UpdateApplicationVersion" 
        InsertMethod="AddAccountForActiveDirectory"><InsertParameters><asp:Parameter 
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
                Name="UserInterfaceLanguage" Type="String" /></InsertParameters><UpdateParameters>
            <asp:Parameter Name="Version" Type="String" />
            <asp:Parameter Name="AccountId" Type="Int32" />
        </UpdateParameters>
    </asp:ObjectDataSource> <asp:ObjectDataSource ID="dsTimeZone" runat="server" OldValuesParameterFormatString="original_{0}"
                            SelectMethod="GetTimeZones" TypeName="SystemDataBLL" OnSelecting="dsTimeZone_Selecting"></asp:ObjectDataSource>
                            <asp:ObjectDataSource ID="dsLocaleInfo" runat="server" OldValuesParameterFormatString="original_{0}"
                            SelectMethod="GetAllCultureInfo" TypeName="LocaleUtilitiesBLL" OnSelecting="dsTimeZone_Selecting">
                            </asp:ObjectDataSource>
                            <asp:ObjectDataSource ID="dsCurrencySymbol" runat="server" OldValuesParameterFormatString="original_{0}"
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
    </asp:ObjectDataSource>
     <asp:ObjectDataSource id="dsAccountTypeObject" runat="server" TypeName="SystemDataBLL" SelectMethod="GetAccountTypes" OldValuesParameterFormatString="original_{0}">
            </asp:ObjectDataSource> 
            <asp:ObjectDataSource id="dsCountryObject" runat="server" TypeName="SystemDataBLL" SelectMethod="GetCountries" OldValuesParameterFormatString="original_{0}">
    </asp:ObjectDataSource>
     <asp:ObjectDataSource id="dsAccountObject" 
        runat="server" TypeName="AccountBLL" SelectMethod="GetAccountViewAsAccountId" 
        InsertMethod="AddNewAccount" OldValuesParameterFormatString="original_{0}" 
        UpdateMethod="UpdateAccount"><InsertParameters>
            <asp:Parameter Name="AccountTypeId" Type="Int16" />
            <asp:Parameter Name="AccountName" Type="String" />
            <asp:Parameter Name="Address1" Type="String" />
            <asp:Parameter Name="Address2" Type="String" />
            <asp:Parameter Name="ZipCode" Type="String" />
            <asp:Parameter Name="City" Type="String" />
            <asp:Parameter Name="CountryId" Type="Int16" />
            <asp:Parameter Name="EMailAddress" Type="String" />
            <asp:Parameter Name="EmployeeCode" Type="String" />
            <asp:Parameter Name="Telephone" Type="String" />
            <asp:Parameter Name="Fax" Type="String" />
            <asp:Parameter Name="DefaultCurrencyId" Type="Int16" />
            <asp:Parameter Name="TimeZoneId" Type="Byte" />
            <asp:Parameter Name="EmployeeLogin" Type="String" />
            <asp:Parameter Name="EmployeePassword" Type="String" />
            <asp:Parameter Name="EmployeeEMailAddress" Type="String" />
            <asp:Parameter Name="EmployeeFirstName" Type="String" />
            <asp:Parameter Name="EmployeeLastName" Type="String" />
            <asp:Parameter Name="EmployeePrefix" Type="String" />
            <asp:Parameter Name="EmployeeMiddleName" Type="String" />
            <asp:Parameter Name="State" Type="String" />
            <asp:Parameter Name="IsDisabled" Type="Boolean" />
            <asp:Parameter Name="IsDeleted" Type="Boolean" />
            <asp:Parameter Name="CreatedOn" Type="DateTime" />
            <asp:Parameter Name="ModifiedOn" Type="DateTime" />
            <asp:Parameter Name="UserInterfaceLanguage" Type="String" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="AccountName" Type="String" />
            <asp:Parameter Name="Address1" Type="String" />
            <asp:Parameter Name="Address2" Type="String" />
            <asp:Parameter Name="ZipCode" Type="String" />
            <asp:Parameter Name="City" Type="String" />
            <asp:Parameter Name="CountryId" Type="Int16" />
            <asp:Parameter Name="EMailAddress" Type="String" />
            <asp:Parameter Name="Telephone" Type="String" />
            <asp:Parameter Name="Fax" Type="String" />
            <asp:Parameter Name="DefaultCurrencyId" Type="Int16" />
            <asp:Parameter Name="ShowClockStartEnd" Type="Boolean" />
            <asp:Parameter Name="TimeEntryFormat" Type="String" />
            <asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" />
            <asp:Parameter Name="original_AccountId" Type="Int32" />
            <asp:Parameter Name="TimeZoneId" Type="Byte" />
            <asp:Parameter Name="CultureInfoName" Type="String" />
            <asp:Parameter Name="CurrencySymbol" Type="String" />
            <asp:Parameter Name="AccountSessionTimeout" Type="Int32" />
            <asp:Parameter Name="ShowCompletedTasksInTimeSheet" Type="Boolean" />
            <asp:Parameter Name="ScheduledEmailSendTime" Type="DateTime" />
            <asp:Parameter Name="LockSubmittedRecords" Type="Boolean" />
            <asp:Parameter Name="LockApprovedRecords" Type="Boolean" />
            <asp:Parameter Name="ShowWorkTypeInTimeSheet" Type="Boolean" />
            <asp:Parameter Name="NumberOfBlankRowsInTimeEntry" Type="Int16" />
            <asp:Parameter Name="ShowCostCenterInTimeSheet" Type="Boolean" />
            <asp:Parameter Name="UserInterfaceLanguage" Type="String" />
            <asp:Parameter Name="DefaultTimeEntryMode" Type="String" />
            <asp:Parameter Name="PageSize" Type="Int32" />
            <asp:Parameter Name="ShowClientInTimesheet" Type="Boolean" />
            <asp:Parameter Name="ShowDescriptionInWeekView" Type="Boolean" />
            <asp:Parameter Name="InvoiceNoPrefix" Type="String" />
            <asp:Parameter Name="ShowAdditionalTaskInformationType" Type="Int32" />
            <asp:Parameter Name="ShowCompletedProjectsInTimeSheet" Type="Boolean" />
            <asp:Parameter Name="ShowProjectForTimeOff" Type="Boolean" />
            <asp:Parameter Name="ShowTimeOffInTimesheet" Type="Boolean" />
            <asp:Parameter Name="PasswordExpiryPeriod" Type="Int32" />
            <asp:Parameter Name="ShowAllInTimesheetReadOnly" Type="Boolean" />
            <asp:Parameter Name="ShowTaskInExpenseSheet" Type="Boolean" />
        <asp:Parameter 
                DbType="Guid" Name="InvoiceBillingTypeId" /><asp:Parameter 
                Name="ShowBillingRateInInvoiceReport" Type="Boolean" /><asp:Parameter 
                Name="InvoiceFooter" Type="String" /><asp:Parameter 
                Name="TimesheetOverduePeriods" Type="Int16" /><asp:Parameter 
                Name="ShowPercentageInTimesheet" Type="Boolean" /><asp:Parameter 
                DbType="Guid" Name="TimeEntryHoursFormatId" /><asp:Parameter 
                Name="EnablePasswordComplexity" Type="Boolean" /><asp:Parameter 
                Name="IsShowElectronicSign" Type="Boolean" /></UpdateParameters>
        <SelectParameters>
            <asp:SessionParameter DefaultValue="99" Name="AccountId" SessionField="AccountId"
                Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource> 
    <asp:ObjectDataSource id="dsCurrencyObject" runat="server" TypeName="SystemDataBLL" SelectMethod="GetCurrencies" OldValuesParameterFormatString="original_{0}">
    </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="dsSystemNamePrefixObject" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetNamePrefix" TypeName="SystemDataBLL"></asp:ObjectDataSource>
            <asp:ObjectDataSource id="dsWeekStartDayObject" runat="server" TypeName="AccountWorkingDayBLL" SelectMethod="GetAccountWorkingDaysResourceByAccountId" OldValuesParameterFormatString="original_{0}" DeleteMethod="DeleteAccountWorkingDayId" InsertMethod="AddAccountWorkingDay">
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
            SelectMethod="GetSystemTimeEntryHoursFormat" TypeName="SystemDataBLL"></asp:ObjectDataSource>&nbsp;&nbsp;&nbsp;</div>