<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlAccountEmployeeProfile.ascx.vb" Inherits="Controls_ctlAccountEmployeeProfile" %>
<%@ Register Assembly="eWorld.UI"
    Namespace="eWorld.UI" TagPrefix="ew" %>
    <%@ Register Assembly="DotNetOpenAuth" Namespace="DotNetOpenAuth.OpenId.RelyingParty" TagPrefix="rp" %>
<script language="javascript" type="text/javascript">
<!--

    function Table2_onclick() {

    }

    function TABLE1_onclick() {

    }

// -->
</script>
  <script type="text/javascript" language="javascript">
      function OpenGoogleLoginPopup() {
          var url = "https://accounts.google.com/o/oauth2/auth?";
          url += "scope=https://www.googleapis.com/auth/userinfo.profile https://www.googleapis.com/auth/userinfo.email&";
          url += "state=%2Fprofile&"
          url += "redirect_uri=<%=Return_url %>&"
          url += "response_type=token&"
          url += "client_id=<%=Client_ID %>";
          window.location = url;
      }
    </script>
<asp:FormView id="FormView1" runat="server" Width="95%" 
        SkinID="formviewSkinEmployee" DefaultMode="Edit" 
        DataSourceID="ObjectDataSource1" DataKeyNames="AccountEmployeeId"><EditItemTemplate>
<table border="0" id="Table1" language="javascript" onclick="return TABLE1_onclick()" cellpadding="0" cellspacing="2" style="width: 100%" class="xview">
                <tr>
                    <th class="caption" colspan="4" style="height: 21px">
                        <asp:Literal ID="Literal1" runat="server" Text='<%# ResourceHelper.GetFromResource("Personal Profile") %>' /></th>
                </tr>
                <tr>
                    <th class="FormViewSubHeader" colspan="4" style="height: 21px">
                        <asp:Literal ID="Literal2" runat="server" Text='<%# ResourceHelper.GetFromResource("Personal Information") %>' /></th>
                </tr>
                <%Dim LDAP As New LDAPUtilitiesBLL%>
                <%If LDAP.IsAspNetActiveDirectoryMembershipProvider = True Then%>
                <tr>
                    <td align="right" class="FormViewLabelCell" style="width: 20%; height: 26px">
                     
                    <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="txtUsername">
                        <asp:Literal ID="Literal4" runat="server" Text='<%# ResourceHelper.GetFromResource("User Name:") %>' /></asp:Label></td><td 
                        style="width: 30%; height: 26px" width="30%"><asp:TextBox ID="txtUsername" runat="server" MaxLength="20" Text='<%# Bind("Username") %>' Width="170px"></asp:TextBox></td><td align="right" class="FormViewLabelCell" style="width: 20%; height: 26px">
                    </td>
                    <td style="width: 30%; height: 26px">
                    </td>
                </tr>
                <%End If%>
                <tr>
                    <td class="FormViewLabelCell" style="height: 26px; width: 20%;" align="right">
                                            <SPAN 
                  class=reqasterisk>*</SPAN><asp:Label ID="Label1" runat="server" AssociatedControlID="FirstNameTextBox">
                  <asp:Literal ID="Literal5" runat="server" Text='<%# ResourceHelper.GetFromResource("First Name:") %>' /></asp:Label></td><td 
                        style="height: 26px; width: 30%;" width="30%"><asp:TextBox ID="FirstNameTextBox" runat="server" Text='<%# Bind("FirstName") %>' MaxLength="75" Width="170px"></asp:TextBox><asp:RequiredFieldValidator
                            ID="RequiredFieldValidator4" runat="server" ControlToValidate="FirstNameTextBox"
                            Display="Dynamic" ErrorMessage="*" Width="1px"></asp:RequiredFieldValidator></td><td class="FormViewLabelCell" style="height: 26px; width: 20%;" align="right">
                       
<asp:Label ID="Label2" runat="server" AssociatedControlID="MiddleNameTextBox">
                        <asp:Literal ID="Literal7" runat="server" Text='<%# ResourceHelper.GetFromResource("Middle Name:") %>' /></asp:Label></td><td style="width: 30%; height: 26px;">
                        <asp:TextBox ID="MiddleNameTextBox" runat="server" Text='<%# Bind("MiddleName") %>' MaxLength="20" Width="170px"></asp:TextBox></td></tr><tr>
                    <td class="FormViewLabelCell" style="height: 26px; width: 20%;" align="right">
                                            <SPAN 
                  class=reqasterisk>*</SPAN><asp:Label ID="Label3" runat="server" AssociatedControlID="LastNameTextBox">
                  <asp:Literal ID="Literal6" runat="server" Text='<%# ResourceHelper.GetFromResource("Last Name:") %>' /></asp:Label></td><td 
                        style="height: 26px; width: 30%;" width="30%"><asp:TextBox ID="LastNameTextBox" runat="server" Text='<%# Bind("LastName") %>' MaxLength="75" Width="170px"></asp:TextBox><asp:RequiredFieldValidator
                            ID="RequiredFieldValidator5" runat="server" ControlToValidate="LastNameTextBox"
                            Display="Dynamic" ErrorMessage="*" Width="1px"></asp:RequiredFieldValidator></td><td class="FormViewLabelCell" style="height: 26px; width: 20%;" align="right">
                                            <SPAN 
                  class=reqasterisk>*</SPAN><asp:Label ID="Label5" runat="server" AssociatedControlID="EMailAddressTextBox">
                  <asp:Literal ID="Literal8" runat="server" Text='<%# ResourceHelper.GetFromResource("Email Address:") %>' /></asp:Label></td><td style="width: 30%; height: 26px;">
                        <asp:TextBox ID="EMailAddressTextBox" runat="server" Text='<%# Bind("EMailAddress") %>' MaxLength="50" Width="170px"></asp:TextBox><asp:RequiredFieldValidator
                            ID="RequiredFieldValidator7" runat="server" ControlToValidate="EMailAddressTextBox"
                            Display="Dynamic" ErrorMessage="*" Width="8px"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="EMailAddressTextBox"
                            Display="Dynamic" ErrorMessage="Incorrect EMail Address" Font-Bold="True" Font-Names="Verdana"
                            Font-Size="X-Small" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator></td></tr><tr>
                    <td class="FormViewLabelCell" style="height: 26px; width: 20%;" align="right">
                        
<asp:Label ID="Label6" runat="server" AssociatedControlID="AddressLine1TextBox">
                        <asp:Literal ID="Literal9" runat="server" Text='<%# ResourceHelper.GetFromResource("Address Line 1:") %>' /></asp:Label></td><td 
                        style="height: 26px; width: 30%;" width="30%"><asp:TextBox ID="AddressLine1TextBox" runat="server" Text='<%# Bind("AddressLine1") %>' MaxLength="150" Width="170px"></asp:TextBox></td><td colspan="1" style="height: 26px; width: 20%;" class="FormViewLabelCell" align="right">
                        
<asp:Label ID="Label8" runat="server" AssociatedControlID="AddressLine2TextBox">
                        <asp:Literal ID="Literal10" runat="server" Text='<%# ResourceHelper.GetFromResource("Address Line 2:") %>' /></asp:Label></td><td colspan="1" style="width: 30%; height: 26px">
                        <asp:TextBox ID="AddressLine2TextBox" runat="server" Text='<%# Bind("AddressLine2") %>' MaxLength="150" Width="170px"></asp:TextBox></td></tr><tr>
                    <td class="FormViewLabelCell" style="height: 26px; width: 20%;" align="right">
                       

<asp:Label ID="Label10" runat="server" AssociatedControlID="StateTextBox">
                        <asp:Literal ID="Literal11" runat="server" Text='<%# ResourceHelper.GetFromResource("State:") %>' /></asp:Label></td><td 
                        style="height: 26px; width: 30%;" width="30%"><asp:TextBox ID="StateTextBox" runat="server" Text='<%# Bind("State") %>' MaxLength="20" Width="170px"></asp:TextBox></td><td colspan="1" style="height: 26px; width: 20%;" class="FormViewLabelCell" align="right">
                        
<asp:Label ID="Label12" runat="server" AssociatedControlID="CityTextBox">
                        <asp:Literal ID="Literal12" runat="server" Text='<%# ResourceHelper.GetFromResource("City:") %>' /></asp:Label></td><td colspan="1" style="width: 30%; height: 26px">
                        <asp:TextBox ID="CityTextBox" runat="server" Text='<%# Bind("City") %>' MaxLength="50" Width="170px"></asp:TextBox></td></tr><tr>
                    <td class="FormViewLabelCell" style="height: 26px; width: 20%;" align="right">
                        
<asp:Label ID="Label13" runat="server" AssociatedControlID="ZipTextBox">
                        <asp:Literal ID="Literal13" runat="server" Text='<%# ResourceHelper.GetFromResource("ZipCode") %>' /></asp:Label></td><td 
                        style="height: 26px; width: 30%;" width="30%"><asp:TextBox ID="ZipTextBox" runat="server" Text='<%# Bind("Zip") %>' MaxLength="10" Width="170px"></asp:TextBox></td><td colspan="1" style="height: 26px; width: 20%;" class="FormViewLabelCell" align="right">
                        <asp:Label 
                            ID="Label19" runat="server" AssociatedControlID="MobilePhoneNoTextBox">
                        <asp:Literal ID="Literal17" runat="server" 
                Text='<%# ResourceHelper.GetFromResource("Mobile Phone No:") %>' /></asp:Label></td><td colspan="1" style="width: 30%; height: 26px">
                        <asp:TextBox 
                            ID="MobilePhoneNoTextBox" runat="server" MaxLength="50" 
                            Text='<%# Bind("MobilePhoneNo") %>' Width="170px"></asp:TextBox></td></tr><tr>
                    <td class="FormViewLabelCell" style="height: 26px; width: 20%;" align="right">
                        
<asp:Label ID="Label15" runat="server" AssociatedControlID="HomePhoneNoTextBox">
                        <asp:Literal ID="Literal15" runat="server" Text='<%# ResourceHelper.GetFromResource("Home Phone No:") %>' /></asp:Label></td><td 
                        style="height: 26px; width: 30%;" width="30%"><asp:TextBox ID="HomePhoneNoTextBox" runat="server" Text='<%# Bind("HomePhoneNo") %>' MaxLength="20" Width="170px"></asp:TextBox></td><td class="FormViewLabelCell" colspan="1" style="height: 26px; width: 20%;" align="right">
                    <asp:Literal 
                            ID="Literal14" runat="server" 
                            Text='<%# ResourceHelper.GetFromResource("Country:") %>' /></td>
                    <td colspan="1" style="width: 30%; height: 26px">
                    <asp:DropDownList 
                            ID="DropDownList3" runat="server" DataSourceID="dsSystemCountryObject" 
                            DataTextField="Country" DataValueField="CountryId" Width="180px"></asp:DropDownList></td>
                </tr>
                <tr>
                    <td class="FormViewLabelCell" style="height: 26px; width: 20%;" align="right">
                        
<asp:Label ID="Label17" runat="server" AssociatedControlID="WorkPhoneNoTextBox">
                        <asp:Literal ID="Literal16" runat="server" Text='<%# ResourceHelper.GetFromResource("Work Phone No:") %>' /></asp:Label></td><td 
                        style="height: 26px; width: 30%;" width="30%"><asp:TextBox ID="WorkPhoneNoTextBox" runat="server" Text='<%# Bind("WorkPhoneNo") %>' MaxLength="50" Width="170px"></asp:TextBox></td><td colspan="1" style="height: 26px; width: 20%;" class="FormViewLabelCell" align="right">
                       
User Interface Language:</td><td colspan="1" style="width: 30%; height: 26px">
                        <asp:DropDownList 
                            ID="ddlUserInterfaceLanguage" runat="server" AppendDataBoundItems="True" 
                            Width="180px"><asp:ListItem Value="en-US">English (United States)</asp:ListItem><asp:ListItem 
                            Value="de-DE">German (Germany)</asp:ListItem><asp:ListItem Value="fr-FR">French (France)</asp:ListItem><asp:ListItem 
                            Value="zh-CN">Chinese (Simplified, PRC)</asp:ListItem><asp:ListItem 
                            Value="it-IT">Italian (Italy)</asp:ListItem><asp:ListItem Value="nl-NL">Dutch (Netherlands)</asp:ListItem><asp:ListItem 
                            Value="es-ES">Spanish (Spain)</asp:ListItem><asp:ListItem Value="sv-SE">Swedish (Sweden)</asp:ListItem><asp:ListItem 
                            Value="pt-PT">Portuguese (Portugal)</asp:ListItem><asp:ListItem 
                            Value="nn-NO">Norwegian, Nynorsk (Norway)</asp:ListItem></asp:DropDownList></td></tr><tr><td 
                        align="right" class="FormViewLabelCell" style="height: 26px; width: 20%;">Image:</td><td 
                        style="height: 26px; width: 30%;" width="30%"><asp:FileUpload ID="FileUpload2" 
                            runat="server" /></td><td align="right" class="FormViewLabelCell" 
                        colspan="1" style="height: 26px; width: 20%;">Show Employee Profile Picture:</td><td 
                        colspan="1" style="width: 30%; height: 26px"><asp:CheckBox 
                            ID="chkIsShowEmployeePicture" runat="server" /></td></tr><tr>
                    <td align="right" class="FormViewLabelCell" style="height: 26px; width: 20%;">
                        <asp:Literal ID="Literal18" runat="server" 
                            Text='<%# ResourceHelper.GetFromResource("TimeZone:") %>' />
                    </td>
                    <td colspan="3" style="height: 26px; ">
                        <asp:DropDownList ID="ddlTimeZoneId" 
                            runat="server" DataSourceID="dsTimeZone" 
                            DataTextField="TimeZoneName" DataValueField="SystemTimeZoneId" 
                            Width="380px"></asp:DropDownList>
                    </td>
                </tr>
                <%If DBUtilities.IsAttendanceFeature Then%>
                <tr>
                    <td align="right" class="FormViewLabelCell" style="height: 26px; width: 20%;">
                        <asp:Literal ID="Literal23" runat="server" 
                            Text='<%# ResourceHelper.GetFromResource("Enable Time In/Out Option:") %>' />
                    </td>
                   <td 
                        colspan="1" style="width: 30%; height: 26px"><asp:CheckBox 
                            ID="chkTimeinOut" runat="server" /></td>
                </tr>
                <%End If%>
                <%If LDAP.IsAspNetActiveDirectoryMembershipProvider <> True Then%>
                <tr>
                    <th class="FormViewSubHeader" style="height: 21px" colspan="4">
                        <asp:Literal ID="Literal19" runat="server" Text='<%# ResourceHelper.GetFromResource("Password") %>' /></th>
                </tr>
                    <tr>
                        <td align="right" class="FormViewLabelCell" style="width: 20%; height: 26px">
                            <span 
                                class="reqasterisk">*</span><asp:Label ID="Label25" runat="server" 
                                AssociatedControlID="CurrentPasswordTextBox">
                  <asp:Literal ID="Literal22" runat="server" 
                                Text='<%# ResourceHelper.GetFromResource("Current Password:") %>' /></asp:Label></td><td 
                            style="width: 30%; height: 26px" width="30%"><asp:TextBox 
                                ID="CurrentPasswordTextBox" runat="server" MaxLength="50" TextMode="Password" 
                                Width="170px"></asp:TextBox></td><td align="right" valign=middle class="FormViewLabelCell" colspan="1" style="width: 20%; height: 26px">
                            &nbsp;</td><td colspan="1" style="width: 30%; height: 26px" valign=middle>
                            &nbsp;</td></tr><tr><td align="right" class="FormViewLabelCell"><span class="reqasterisk">*</span><asp:Label 
                        ID="Label23" runat="server" AssociatedControlID="PasswordTextBox">
                  <asp:Literal ID="Literal20" runat="server" 
                Text='<%# ResourceHelper.GetFromResource("Password:") %>' /></asp:Label></td><td 
                        width="30%"><asp:TextBox ID="PasswordTextBox" 
                            runat="server" MaxLength="50" TextMode="Password" Width="170px"></asp:TextBox><asp:RegularExpressionValidator 
                            ID="RegularExpressionValidator2" runat="server" 
                            ControlToValidate="PasswordTextBox" Display="Dynamic" 
                            SkinID="PasswordValidator" 
                            ValidationExpression="(?=^.{8,}$)(?=.*\d)(?=.*\W+)(?![.\n]).*$"></asp:RegularExpressionValidator></td><td 
                        align="right" class="FormViewLabelCell" colspan="1" valign="middle"><span class="reqasterisk">*</span><asp:Label 
                            ID="Label24" runat="server" AssociatedControlID="VerifyPasswordTextbox">
                  <asp:Literal ID="Literal21" runat="server" 
                Text='<%# ResourceHelper.GetFromResource("Verify Password:") %>' /></asp:Label></td><td 
                        colspan="1" valign="middle"><asp:TextBox 
                            ID="VerifyPasswordTextbox" runat="server" MaxLength="50" TextMode="Password" 
                            Width="170px"></asp:TextBox><asp:CompareValidator ID="CompareValidator1" 
                            runat="server" ControlToCompare="VerifyPasswordTextbox" 
                            ControlToValidate="PasswordTextBox" CssClass="ErrorMessage" 
                            ErrorMessage="(Mismatch)" Width="35px"></asp:CompareValidator></td></tr><%End If %>
                            

    <%If 1=2 Then%>                        
                <tr>
                    <th class="FormViewSubHeader" style="height: 21px" colspan="4">
                        <asp:Literal ID="Literal3" runat="server" Text="OpenID Authentication" /></th>
                </tr><%If DBUtilities.GetOpenIDSource = "" Then%>

                 <%-- <tr>
                        <td align="right" class="FormViewLabelCell" style="width: 20%; height: 26px">
                            Authenticate with Google Apps: </td>
                            <td 
                            style="width: 30%; height: 26px" width="30%">
                            <rp:OpenIdButton runat="server" ImageUrl="~/images/social_googleApps_box.png" Text="Login with Google Apps!" ID="googleappsLoginButton"
			                Identifier="https://www.google.com/accounts/o8/id" OnLoggingIn="googleappsLoginButton_LoggingIn" OnLoggedIn="googleappsLoginButton_LoggedIn" />
                            </td>
                            <td align="right" valign=middle class="FormViewLabelCell" colspan="1" style="width: 20%; height: 26px">
                            &nbsp;</td><td colspan="1" style="width: 30%; height: 26px" valign=middle>
                            &nbsp;</td></tr>--%>
                    <tr>
                        <td align="right" class="FormViewLabelCell" style="width: 20%; height: 26px">
                            Authenticate with: </td><td 
                            style="width: 30%; height: 26px" width="30%">
                            <a href="javascript:void(0)" id="A1" onclick="OpenGoogleLoginPopup();" name="butrequest"><img style="width: 95px;" src="<%= Page.ResolveUrl("~/Images/Google_Authenticate.png")%>" /></a>
                         <%--   <rp:OpenIdButton runat="server" ImageUrl="~/images/social_google_box.png" Text="Login with Google!" ID="googleLoginButton"
			                Identifier="https://www.google.com/accounts/o8/id" OnLoggingIn="googleLoginButton_LoggingIn" OnLoggedIn="googleLoginButton_LoggedIn" />--%>
                            </td>
                            <td align="right" valign=middle class="FormViewLabelCell" colspan="1" style="width: 20%; height: 26px">
                            &nbsp;</td><td colspan="1" style="width: 30%; height: 26px" valign=middle>
                            &nbsp;</td></tr>
                        <%--    <tr>
                        <td align="right" class="FormViewLabelCell" style="width: 20%; height: 26px">
                            Authenticate with Yahoo: </td><td 
                            style="width: 30%; height: 26px" width="30%">
                            <rp:OpenIdButton runat="server" ImageUrl="~/Images/social_yahoo_box.png" Text="Login with Yahoo!" ID="yahooLoginButton"
			                Identifier="https://me.yahoo.com/" OnLoggingIn="yahooLoginButton_LoggingIn" OnLoggedIn="yahooLoginButton_LoggedIn" />
                            </td>
                            <td align="right" valign=middle class="FormViewLabelCell" colspan="1" style="width: 20%; height: 26px">
                            &nbsp;</td><td colspan="1" style="width: 30%; height: 26px" valign=middle>
                            &nbsp;</td></tr>--%>
                            <%ElseIf DBUtilities.GetOpenIDSource <> "" Then%>
                            <tr>
                            <td align="right" class="FormViewLabelCell" style="height: 26px; padding-right:5px">
                            <asp:Label ID="lblAuthentication" runat="server" Visible="false"></asp:Label>
                            </td>
                            <td style="width: 50%; height: 26px" class="style13" colspan="3">
                                <asp:Label ID="lblAuthenticate" runat="server" Font-Bold="false" Visible="false"></asp:Label><asp:Label ID="lblAuthEmailAddress" runat="server" Visible="false"></asp:Label>&nbsp;&nbsp;<asp:Label ID="lblAuthClick" runat="server" Font-Bold="false" Visible="false" Text="Click "></asp:Label><asp:LinkButton ID="btnunlink" runat="server" Text="here" onclick="btnunlink_Click" ForeColor="#FF3300" Font-Underline="True"/><asp:Label ID="lblAuthToUnlink" runat="server" Font-Bold="false" Visible="false" Text=" to Unlink."></asp:Label>
                            </td>
                            </tr>
                            <%End If%>
                            <%End If%>
                            <tr>
                    <td class="FormViewLabelCell" colspan="3" style="height: 26px">
                        &nbsp;</td><td colspan="1" style="width: 30%; height: 26px; padding-bottom: 5px;">
                        <asp:Button 
                            ID="Update" runat="server" CommandName="Update" 
                            Text="<%$ Resources:TimeLive.Resource,Update_text%> " Width="72px" 
                            onclick="Update_Click" />
                            &nbsp;<asp:Button ID="Cancel" runat="server" CommandName="Cancel" Text="<%$ Resources:TimeLive.Resource, Cancel_text%> " Width="72px" OnClick="Cancel_Click" /></td>
                </tr>
            </table>
            
</EditItemTemplate>
<InsertItemTemplate>
                <table border="0" id="Table3" language="javascript" onclick="return TABLE1_onclick()" cellpadding="0" cellspacing="2" style="width: 100%" class="xview">
                    <tr>
                        <th class="caption" colspan="4" style="height: 26px; width: 20%;">
                            <asp:Literal ID="Literal21" runat="server" Text='<%# ResourceHelper.GetFromResource("Personal Profile") %>' /></th>
                    </tr>
                    <tr>
                        <th class="FormViewSubHeader" colspan="4" style="height: 26px; width: 20%;">
                            <asp:Literal ID="Literal22" runat="server" Text='<%# ResourceHelper.GetFromResource("Personal Information") %>' /></th>
                    </tr>
                    <tr>
                        <td class="FormViewLabelCell" style="height: 26px; width: 20%;" align="right">
                                                <SPAN 
                  class=reqasterisk>*</SPAN><asp:Literal ID="Literal24" runat="server" Text='<%# ResourceHelper.GetFromResource("First Name:") %>' /></td>
                        <td style="height: 26px; width: 30%;" width="40%">
                            <asp:TextBox ID="FirstNameTextBox" runat="server" Text='<%# Bind("FirstName") %>' MaxLength="75"></asp:TextBox><asp:RequiredFieldValidator
                                ID="RequiredFieldValidator4" runat="server" ControlToValidate="FirstNameTextBox"
                                Display="Dynamic" ErrorMessage="*" Width="1px"></asp:RequiredFieldValidator></td><td class="FormViewLabelCell" style="height: 26px; width: 20%;" align="right">
                            
<asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="MiddleNameTextBox">
                            <asp:Literal ID="Literal25" runat="server" Text='<%# ResourceHelper.GetFromResource("Middle Name:") %>' /></asp:Label></td><td style="width: 30%; height: 26px;">
                            <asp:TextBox ID="MiddleNameTextBox" runat="server" Text='<%# Bind("MiddleName") %>' MaxLength="20"></asp:TextBox></td></tr><tr>
                        <td class="FormViewLabelCell" style="height: 26px; width: 20%;" align="right">
                                                <SPAN 
                  class=reqasterisk>*</SPAN><asp:Label ID="Label4" runat="server" AssociatedControlID="LastNameTextBox">
                  <asp:Literal ID="Literal26" runat="server" Text='<%# ResourceHelper.GetFromResource("Last Name:") %>' /></asp:Label></td><td style="height: 26px; width: 30%;" width="40%">
                            <asp:TextBox ID="LastNameTextBox" runat="server" Text='<%# Bind("LastName") %>' MaxLength="75"></asp:TextBox><asp:RequiredFieldValidator
                                ID="RequiredFieldValidator5" runat="server" ControlToValidate="LastNameTextBox"
                                Display="Dynamic" ErrorMessage="*" Width="1px"></asp:RequiredFieldValidator></td><td class="FormViewLabelCell" style="height: 26px; width: 20%;" align="right">
                                                <SPAN 
                  class=reqasterisk>*</SPAN><asp:Literal ID="Literal27" runat="server" Text='<%# ResourceHelper.GetFromResource("Email Address") %>' /></td>
                        <td style="width: 30%; height: 26px;">
                            <asp:TextBox ID="EMailAddressTextBox" runat="server" Text='<%# Bind("EMailAddress") %>' MaxLength="50"></asp:TextBox><asp:RequiredFieldValidator
                                ID="RequiredFieldValidator7" runat="server" ControlToValidate="EMailAddressTextBox"
                                Display="Dynamic" ErrorMessage="*" Width="8px"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="EMailAddressTextBox"
                                Display="Dynamic" ErrorMessage="Incorrect EMail Address" Font-Bold="True" Font-Names="Verdana"
                                Font-Size="X-Small" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator></td></tr><tr>
                        <td class="FormViewLabelCell" style="height: 26px; width: 20%;" align="right">
                            
<asp:Label ID="Label7" runat="server" AssociatedControlID="AddressLine1TextBox">
                            <asp:Literal ID="Literal28" runat="server" Text='<%# ResourceHelper.GetFromResource("Address Line 1:") %>' /></asp:Label></td><td style="height: 26px; width: 30%;" width="40%">
                            <asp:TextBox ID="AddressLine1TextBox" runat="server" Text='<%# Bind("AddressLine1") %>' MaxLength="150"></asp:TextBox></td><td colspan="1" style="height: 26px; width: 20%;" class="FormViewLabelCell" align="right">
                            
<asp:Label ID="Label9" runat="server" AssociatedControlID="AddressLine2TextBox">
                            <asp:Literal ID="Literal29" runat="server" Text='<%# ResourceHelper.GetFromResource("Address Line 2:") %>' /></asp:Label></td><td colspan="1" style="width: 30%; height: 26px">
                            <asp:TextBox ID="AddressLine2TextBox" runat="server" Text='<%# Bind("AddressLine2") %>' MaxLength="150"></asp:TextBox></td></tr><tr>
                        <td class="FormViewLabelCell" style="height: 26px; width: 20%;" align="right">
                            

<asp:Label ID="Label11" runat="server" AssociatedControlID="StateTextBox">
                            <asp:Literal ID="Literal30" runat="server" Text='<%# ResourceHelper.GetFromResource("State:") %>' /></asp:Label></td><td style="height: 26px; width: 30%;" width="40%">
                            <asp:TextBox ID="StateTextBox" runat="server" Text='<%# Bind("State") %>' MaxLength="20"></asp:TextBox></td><td colspan="1" style="height: 26px; width: 20%;" class="FormViewLabelCell" align="right">
                            <asp:Literal ID="Literal31" runat="server" Text='<%# ResourceHelper.GetFromResource("City") %>' /></td>
                        <td colspan="1" style="width: 30%; height: 26px">
                            <asp:TextBox ID="CityTextBox" runat="server" Text='<%# Bind("City") %>' MaxLength="50"></asp:TextBox></td></tr><tr>
                        <td class="FormViewLabelCell" style="height: 26px; width: 20%;" align="right">
                            
<asp:Label ID="Label14" runat="server" AssociatedControlID="ZipTextBox">
                            <asp:Literal ID="Literal32" runat="server" Text='<%# ResourceHelper.GetFromResource("ZipCode") %>' /></asp:Label></td><td style="height: 26px; width: 30%;" width="40%">
                            <asp:TextBox ID="ZipTextBox" runat="server" Text='<%# Bind("Zip") %>' MaxLength="10"></asp:TextBox></td><td colspan="1" style="height: 26px; width: 20%;" class="FormViewLabelCell" align="right">
                            <asp:Literal ID="Literal33" runat="server" Text='<%# ResourceHelper.GetFromResource("Country:") %>' /></td>
                        <td colspan="1" style="width: 30%; height: 26px">
                            <asp:DropDownList ID="DropDownList3" runat="server" DataSourceID="dsSystemCountryObject"
                                DataTextField="Country" DataValueField="CountryId" SelectedValue='<%# Bind("CountryId") %>'>
                            </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td class="FormViewLabelCell" style="height: 26px; width: 20%;" align="right">
                            
<asp:Label ID="Label16" runat="server" AssociatedControlID="HomePhoneNoTextBox">
                            <asp:Literal ID="Literal34" runat="server" Text='<%# ResourceHelper.GetFromResource("Home Phone No:") %>' /></asp:Label></td><td style="height: 26px; width: 30%;" width="40%">
                            <asp:TextBox ID="HomePhoneNoTextBox" runat="server" Text='<%# Bind("HomePhoneNo") %>' MaxLength="20"></asp:TextBox></td><td class="FormViewLabelCell" colspan="1" style="height: 26px; width: 20%;" align="right">
                        </td>
                        <td colspan="1" style="width: 30%; height: 26px">
                        </td>
                    </tr>
                    <tr>
                        <td class="FormViewLabelCell" style="height: 26px; width: 20%;" align="right">
                            
<asp:Label ID="Label18" runat="server" AssociatedControlID="WorkPhoneNoTextBox">
                            <asp:Literal ID="Literal35" runat="server" Text='<%# ResourceHelper.GetFromResource("Work Phone No:") %>' /></asp:Label></td><td style="height: 26px; width: 30%;" width="40%">
                            <asp:TextBox ID="WorkPhoneNoTextBox" runat="server" Text='<%# Bind("WorkPhoneNo") %>' MaxLength="50"></asp:TextBox></td><td colspan="1" style="height: 26px; width: 20%;" class="FormViewLabelCell" align="right">
                            
<asp:Label ID="Label20" runat="server" AssociatedControlID="MobilePhoneNoTextBox">
                            <asp:Literal ID="Literal36" runat="server" Text='<%# ResourceHelper.GetFromResource("Mobile Phone No:") %>' /></asp:Label></td><td colspan="1" style="width: 30%; height: 26px">
                            <asp:TextBox ID="MobilePhoneNoTextBox" runat="server" Text='<%# Bind("MobilePhoneNo") %>' MaxLength="50"></asp:TextBox></td></tr><tr>
                        <th class="FormViewSubHeader" style="height: 26px; width: 20%;" colspan="4">
                            <asp:Literal ID="Literal37" runat="server" Text='<%# ResourceHelper.GetFromResource("Login") %>' /></th>
                    </tr>
                    <tr>
                        <td class="FormViewLabelCell" style="height: 26px; width: 20%;" align="right">
                                                <SPAN 
                  class=reqasterisk>*</SPAN><asp:Literal ID="Literal38" runat="server" Text='<%# ResourceHelper.GetFromResource("Login:") %>' /></td>
                        <td style="height: 26px; width: 30%;" width="40%">
                            <asp:TextBox ID="LoginTextBox" runat="server" Text='<%# Bind("Login") %>' MaxLength="50"></asp:TextBox><asp:RequiredFieldValidator
                                ID="RequiredFieldValidator1" runat="server" ControlToValidate="LoginTextBox"
                                Display="Dynamic" ErrorMessage="*" Width="1px"></asp:RequiredFieldValidator></td><td colspan="1" style="height: 26px; width: 20%;" class="FormViewLabelCell" align="right">
                                                 </td>
                        <td colspan="1" style="width: 30%; height: 26px">
                            </td>
                    </tr>
                    <tr>
                        <td align="right" class="FormViewLabelCell" style="width: 20%; height: 26px">
                            <SPAN 
                  class=reqasterisk>*</SPAN><asp:Label ID="Label21" runat="server" AssociatedControlID="PasswordTextBox">
                  <asp:Literal ID="Literal39" runat="server" Text='<%# ResourceHelper.GetFromResource("Password:") %>' /></asp:Label></td><td style="width: 30%; height: 26px" width="40%">
                            <asp:TextBox ID="PasswordTextBox" runat="server" Text='<%# Bind("Password") %>' TextMode="Password" MaxLength="50"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="PasswordTextBox"
                                Display="Dynamic" ErrorMessage="*" Width="16px"></asp:RequiredFieldValidator></td><td align="right" valign=middle class="FormViewLabelCell" colspan="1" style="width: 20%; height: 26px">
                            <SPAN 
                  class=reqasterisk>*</SPAN><asp:Label ID="Label22" runat="server" AssociatedControlID="VerifyPasswordTextbox">
                  <asp:Literal ID="Literal40" runat="server" Text='<%# ResourceHelper.GetFromResource("Verify Password:") %>' /></asp:Label></td><td colspan="1" style="width: 30%; height: 26px" valign=middle>
                            <asp:TextBox ID="VerifyPasswordTextbox" runat="server" TextMode="Password" MaxLength="50"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="VerifyPasswordTextbox"
                                Display="Dynamic" ErrorMessage="*" ></asp:RequiredFieldValidator><asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="VerifyPasswordTextbox"
                                ControlToValidate="PasswordTextBox" CssClass="ErrorMessage" ErrorMessage="(Mismatch)"></asp:CompareValidator></td></tr><tr>
                        <td class="FormViewLabelCell" style="height: 26px; width: 20%;" align="right">
                                                <SPAN 
                  class=reqasterisk>*</SPAN><asp:Literal ID="Literal41" runat="server" Text='<%# ResourceHelper.GetFromResource("Role:") %>' /></td>
                        <td style="height: 26px; width: 30%;" width="40%">
                            <asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="dsAccountRoleObject"
                                DataTextField="Role" DataValueField="AccountRoleId" SelectedValue='<%# Bind("AccountRoleId") %>' >
                            </asp:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server"
                                ControlToValidate="DropDownList2" Display="Dynamic" ErrorMessage="*" Width="8px"></asp:RequiredFieldValidator></td><td colspan="1" style="height: 26px; width: 20%;" class="FormViewLabelCell" align="right">
                                                <SPAN 
                  class=reqasterisk>*</SPAN><asp:Literal ID="Literal42" runat="server" Text='<%# ResourceHelper.GetFromResource("Department:") %>' /></td>
                        <td colspan="1" style="width: 30%; height: 26px">
                            <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="dsAccountDepartmentObject"
                                DataTextField="DepartmentName" DataValueField="AccountDepartmentId" SelectedValue='<%# Bind("AccountDepartmentId") %>'>
                            </asp:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server"
                                ControlToValidate="DropDownList1" Display="Dynamic" ErrorMessage="*" Width="1px"></asp:RequiredFieldValidator>&nbsp;</td></tr><tr>
                        <td class="FormViewLabelCell" style="height: 26px; width: 20%;" align="right">
                            <asp:Literal ID="Literal43" runat="server" Text='<%# ResourceHelper.GetFromResource("Location:") %>' /></td>
                        <td style="height: 26px; width: 30%;" width="40%">
                            <asp:DropDownList ID="DropDownList5" runat="server" DataSourceID="dsAccountLocation"
                                DataTextField="AccountLocation" DataValueField="AccountLocationId" SelectedValue='<%# Bind("AccountLocationId") %>' >
                            </asp:DropDownList>
                        </td>
                        <td class="FormViewLabelCell" colspan="1" style="height: 26px; width: 20%;" align="right">
                        </td>
                        <td colspan="1" style="width: 30%; height: 26px">
                        </td>
                    </tr>
                    <tr>
                        <th class="FormViewSubHeader" style="height: 26px; width: 20%;" colspan="4">
                            <asp:Literal ID="Literal44" runat="server" Text='<%# ResourceHelper.GetFromResource("Billing Rate") %>' /></th>
                    </tr>
                    <tr>
                        <td class="FormViewLabelCell" style="height: 26px; width: 20%;" align="right">
                            <asp:Literal ID="Literal45" runat="server" Text='<%# ResourceHelper.GetFromResource("Currency") %>' /></td>
                        <td style="height: 26px; width: 30%;" width="40%">
                            <asp:DropDownList ID="DropDownList4" runat="server" DataSourceID="dsSystemCurrencyObject"
                                DataTextField="CurrencyCode" DataValueField="CurrencyId" SelectedValue='<%# Bind("BillingRateCurrencyId") %>'>
                            </asp:DropDownList></td>
                        <td class="FormViewLabelCell" colspan="1" style="height: 26px; width: 20%;" align="right">
                            <asp:Literal ID="Literal46" runat="server" Text='<%# ResourceHelper.GetFromResource("Billing Type:") %>' /></td>
                        <td colspan="1" style="width: 30%; height: 26px">
                            <asp:DropDownList ID="DropDownList7" runat="server" DataSourceID="dsAccountBillingTypeObject"
                                DataTextField="BillingType" DataValueField="AccountBillingTypeId">
                            </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td class="FormViewLabelCell" style="height: 26px; width: 20%;" align="right">
                            <asp:Literal ID="Literal47" runat="server" Text='<%# ResourceHelper.GetFromResource("Billing Rate:") %>' /></td>
                        <td style="height: 26px; width: 30%;" width="40%">
                            <asp:TextBox ID="BillingRateTextBox" runat="server" Text='<%# Bind("BillingRate") %>'
                                Width="56px"></asp:TextBox><asp:RangeValidator ID="RangeValidator1" runat="server"
                                    ControlToValidate="BillingRateTextBox" CssClass="ErrorMessage" Display="Dynamic"
                                    ErrorMessage="Numeric Required" Font-Bold="True" Font-Names="Verdana" Font-Size="X-Small"
                                    MaximumValue="50000" MinimumValue="0" Type="Double"></asp:RangeValidator></td><td class="FormViewLabelCell" colspan="1" style="height: 26px; width: 20%;" align="right">
                            <asp:Literal ID="Literal48" runat="server" Text='<%# ResourceHelper.GetFromResource("Billing Rate Start Date:") %>' /></td>
                        <td colspan="1" style="width: 30%; height: 26px">
                            <ew:CalendarPopup ID="CalendarPopup1" runat="server" SkinId="DatePicker" PostedDate="" SelectedValue="09/26/2006 23:33:48" Text="..." UpperBoundDate="12/31/9999 23:59:59" Nullable="True">
                            </ew:CalendarPopup>
                        </td>
                    </tr>
                    <tr>
                        <td class="FormViewLabelCell" colspan="3" style="height: 26px; width: 20%;">
                            &nbsp;</td><td colspan="1" style="width: 30%; height: 26px; padding-bottom: 5px;">
                            <asp:Button ID="Add" runat="server" CommandName="Insert" Text="<%$ Resources:TimeLive.Resource, Add_text%> " Width="50px" /></td>
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
                </asp:LinkButton></ItemTemplate></asp:FormView><asp:ObjectDataSource id="dsAccountEmployeeObject" runat="server" InsertMethod="AddAccountEmployee2" UpdateMethod="UpdateSelectedAccountEmployee" DeleteMethod="DeleteAccountEmployee" TypeName="AccountEmployeeBLL" SelectMethod="GetAccountEmployees" OldValuesParameterFormatString="original_{0}">
    <DeleteParameters>
        <asp:Parameter Name="Original_AccountEmployeeId" Type="Int32" />
    </DeleteParameters>
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
    <InsertParameters>
        <asp:Parameter Name="Login" Type="String" />
        <asp:Parameter Name="Password" Type="String" />
        <asp:Parameter Name="Prefix" Type="String" />
        <asp:Parameter Name="FirstName" Type="String" />
        <asp:Parameter Name="LastName" Type="String" />
    </InsertParameters>
</asp:ObjectDataSource> <asp:ObjectDataSource id="ObjectDataSource1" runat="server" 
        InsertMethod="AddAccountEmployee2" UpdateMethod="UpdateEmployeeProfile" 
        DeleteMethod="DeleteAccountEmployee" TypeName="AccountEmployeeBLL" 
        SelectMethod="GetAccountEmployeesByAccountEmployeeId" 
        OldValuesParameterFormatString="original_{0}"><DeleteParameters>
<asp:Parameter Name="Original_AccountEmployeeId" Type="Int32"></asp:Parameter>
</DeleteParameters>
<UpdateParameters>
<asp:Parameter Name="Password" Type="String"></asp:Parameter>
<asp:Parameter Name="Prefix" Type="String"></asp:Parameter>
<asp:Parameter Name="FirstName" Type="String"></asp:Parameter>
<asp:Parameter Name="LastName" Type="String"></asp:Parameter>
<asp:Parameter Name="MiddleName" Type="String"></asp:Parameter>
<asp:Parameter Name="EMailAddress" Type="String"></asp:Parameter>
<asp:SessionParameter SessionField="AccountId" DefaultValue="23" Name="AccountId" Type="Int32"></asp:SessionParameter>
<asp:Parameter Name="AddressLine1" Type="String"></asp:Parameter>
<asp:Parameter Name="AddressLine2" Type="String"></asp:Parameter>
<asp:Parameter Name="State" Type="String"></asp:Parameter>
<asp:Parameter Name="City" Type="String"></asp:Parameter>
<asp:Parameter Name="Zip" Type="String"></asp:Parameter>
<asp:Parameter Name="CountryId" Type="Int16"></asp:Parameter>
<asp:Parameter Name="HomePhoneNo" Type="String"></asp:Parameter>
<asp:Parameter Name="WorkPhoneNo" Type="String"></asp:Parameter>
<asp:Parameter Name="MobilePhoneNo" Type="String"></asp:Parameter>
<asp:Parameter Name="StatusId" Type="Int32"></asp:Parameter>
<asp:Parameter Name="TimeZoneId" Type="Byte"></asp:Parameter>
<asp:Parameter Name="CreatedByEmployeeId" Type="Int32"></asp:Parameter>
<asp:Parameter Name="ModifiedByEmployeeId" Type="Int32"></asp:Parameter>
<asp:Parameter Name="Original_AccountEmployeeId" Type="Int32"></asp:Parameter>
<asp:Parameter Name="Notes" Type="String"></asp:Parameter>
<asp:Parameter Name="Username" Type="String"></asp:Parameter>
    <asp:Parameter Name="ModifiedOn" Type="DateTime" />
    <asp:Parameter Name="UserInterfaceLanguage" Type="String" />
<asp:Parameter 
            Name="IsTimeInOutAvailable" Type="Boolean" />
<asp:Parameter 
            Name="IsShowEmployeeProfilePicture" Type="Boolean" /></UpdateParameters>

<SelectParameters>
<asp:SessionParameter SessionField="AccountEmployeeId" DefaultValue="39" Name="AccountEmployeeId" Type="Int32"></asp:SessionParameter>
</SelectParameters>
<InsertParameters>
<asp:Parameter Name="Login" Type="String"></asp:Parameter>
<asp:Parameter Name="Password" Type="String"></asp:Parameter>
<asp:Parameter Name="Prefix" Type="String"></asp:Parameter>
<asp:Parameter Name="FirstName" Type="String"></asp:Parameter>
<asp:Parameter Name="LastName" Type="String"></asp:Parameter>
</InsertParameters>
</asp:ObjectDataSource> <asp:ObjectDataSource id="dsSystemCurrencyObject" runat="server" TypeName="SystemDataBLL" SelectMethod="GetCurrencies" OldValuesParameterFormatString="original_{0}"></asp:ObjectDataSource> <asp:ObjectDataSource id="dsAccountDepartmentObject" runat="server" InsertMethod="AddAccountDepartment" UpdateMethod="UpdateAccountDepartment" DeleteMethod="DeleteAccountDepartment" TypeName="AccountDepartmentBLL" SelectMethod="GetAccountDepartmentsByAccountId" OldValuesParameterFormatString="original_{0}">
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
</asp:ObjectDataSource> <asp:ObjectDataSource id="dsSystemNamePrefixObject" runat="server" TypeName="SystemDataBLL" SelectMethod="GetNamePrefix" OldValuesParameterFormatString="original_{0}"></asp:ObjectDataSource> <asp:ObjectDataSource id="dsAccountRoleObject" runat="server" InsertMethod="AddAccountRole" UpdateMethod="UpdateAccountRole" DeleteMethod="DeleteAccountRole" TypeName="AccountRoleBLL" SelectMethod="GetAccountRolesByAccountId" OldValuesParameterFormatString="original_{0}">
    <SelectParameters>
        <asp:SessionParameter DefaultValue="64" Name="AccountId" SessionField="AccountId"
            Type="Int32" />
    </SelectParameters>
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
    </UpdateParameters>
    <InsertParameters>
        <asp:Parameter Name="AccountId" Type="Int32" />
        <asp:Parameter Name="Role" Type="String" />
        <asp:Parameter Name="CreatedByEmployeeId" Type="Int32" />
        <asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" />
    </InsertParameters>
</asp:ObjectDataSource> <asp:ObjectDataSource id="dsSystemCountryObject" runat="server" TypeName="SystemDataBLL" SelectMethod="GetCountries" OldValuesParameterFormatString="original_{0}"></asp:ObjectDataSource> <asp:ObjectDataSource id="dsTimeZone" runat="server" TypeName="SystemDataBLL" SelectMethod="GetTimeZones" OldValuesParameterFormatString="original_{0}"></asp:ObjectDataSource> <asp:ObjectDataSource id="dsProjectObject" runat="server" TypeName="AccountProjectBLL" SelectMethod="GetAccountProjectsByAccountProjectId" OldValuesParameterFormatString="original_{0}">
            <SelectParameters>
                <asp:Parameter DefaultValue="3" Name="AccountProjectId" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource> <asp:ObjectDataSource id="dsAccountLocation" runat="server" InsertMethod="AddAccountLocation" UpdateMethod="UpdateAccountLocation" DeleteMethod="DeleteAccountLocation" TypeName="AccountLocationBLL" SelectMethod="GetAccountLocationsByAccountId" OldValuesParameterFormatString="original_{0}">
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
        </asp:ObjectDataSource> <asp:ObjectDataSource id="dsAccountBillingTypeObject" runat="server" InsertMethod="AddAccountBillingType" UpdateMethod="UpdateAccountBillingType" DeleteMethod="DeleteAccountBillingType" TypeName="AccountBillingTypeBLL" SelectMethod="GetAccountBillingTypesForEmployeeByAccountId" OldValuesParameterFormatString="original_{0}">
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
