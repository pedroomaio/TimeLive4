<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlLogin.ascx.vb" Inherits="Auth_Controls_ctlLogin" %>
<%@ Register Assembly="DotNetOpenAuth" Namespace="DotNetOpenAuth.OpenId.RelyingParty"
    TagPrefix="rp" %>
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
<asp:Login ID="Login1" runat="server" Width="430px">
    <LayoutTemplate>
        <table cellpadding="0" cellspacing="0">
            <tr>
                <td align="left">
                    <asp:Image ID="imgCompanyOwnLogo" runat="server" Height="50px" ImageUrl="~/Images/TopHeader.jpg"
                        AlternateText="CompanyLogo" />
                </td>
            </tr>
        </table>
        <table cellpadding="0" cellspacing="0" class="xFormView" width="375" style="border: 5px solid #F6F6F6;">
            <tr>
                <td>
                    <table cellpadding="0" cellspacing="0" class="xFormView" width="375" style="border: 1px solid #d6dadf;">
                        <tr>
                            <th class="captionLogin" colspan="3">
                                <asp:Literal ID="TimeLiveLogin" runat="server" Text="<%$ Resources:TimeLive.Resource, Xtracker Login%>" />
                            </th>
                        </tr>
                        <tr id="trBeforeError" runat="server">
                            <td align="right" style="vertical-align: middle" width="35%">
                                &nbsp;
                            </td>
                            <td width="60%">
                                &nbsp;
                            </td>
                            <td width="5%">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <p class="message red-gradient small-margin-bottom" style="font-weight: normal;"
                                    id="ErrorText" runat="server" visible="false">
                                </p>
                                <p class="message red-gradient small-margin-bottom" style="font-weight: normal;"
                                    id="FailureText1" runat="server" visible="false">
                                    <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                </p>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="vertical-align: middle" width="35%">
                                <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName" Font-Bold="False">
                                    <asp:Literal ID="Literal2" runat="server" Text="<%$ Resources:TimeLive.Resource, Username:%> " /></asp:Label></td><td width="60%">
                                <asp:TextBox ID="UserName" runat="server" CssClass="txtBox" Width="95%"></asp:TextBox><asp:RequiredFieldValidator
                                    ID="UserNameRequired" runat="server" ControlToValidate="UserName" CssClass="ErrorMessage"
                                    Display="Dynamic" ErrorMessage="User Name is required." ToolTip="<%$ Resources:TimeLive.Resource, Username is required.%> "
                                    ValidationGroup="ctl00$Login1">*</asp:RequiredFieldValidator></td><td width="5%">
                                &nbsp; </td></tr><tr>
                            <td align="right" style="vertical-align: middle" valign="middle" width="35%">
                                <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password" Font-Bold="False">
                                    <asp:Literal ID="Literal3" runat="server" Text="<%$ Resources:TimeLive.Resource, Password:%> " /></asp:Label></td><td width="60%">
                                <asp:TextBox ID="Password" runat="server" CssClass="txtBox" TextMode="Password" Width="95%"></asp:TextBox></td><td width="5%">
                                &nbsp; </td></tr><tr>
                            <td align="right" style="vertical-align: middle" valign="middle" width="35%">
                                <asp:Label ID="UIL" runat="server" AssociatedControlID="ddlUserInterfaceLanguage"
                                    Font-Bold="False">
                                    <asp:Literal ID="Literal1" runat="server" Text="UI Language:" /></asp:Label></td><td width="60%">
                                <asp:DropDownList ID="ddlUserInterfaceLanguage" runat="server" AppendDataBoundItems="True"
                                    Width="100%">
                                    <asp:ListItem Value="0">Use Default Language</asp:ListItem><asp:ListItem Value="en-US">English (United States)</asp:ListItem><asp:ListItem Value="de-DE">German (Germany)</asp:ListItem><asp:ListItem Value="fr-FR">French (France)</asp:ListItem><asp:ListItem Value="zh-CN">Chinese (Simplified, PRC)</asp:ListItem><asp:ListItem Value="it-IT">Italian (Italy)</asp:ListItem><asp:ListItem Value="nl-NL">Dutch (Netherlands)</asp:ListItem><asp:ListItem Value="es-ES">Spanish (Spain)</asp:ListItem><asp:ListItem Value="sv-SE">Swedish (Sweden)</asp:ListItem><asp:ListItem Value="pt-PT">Portuguese (Portugal)</asp:ListItem><asp:ListItem Value="nn-NO">Norwegian, Nynorsk (Norway)</asp:ListItem></asp:DropDownList></td><td width="5%">
                                &nbsp; </td></tr><tr>
                            <td align="right" style="vertical-align: middle" valign="middle" width="35%">
                                &nbsp; </td><td width="60%">
                                &nbsp; </td><td width="5%">
                                &nbsp; </td></tr><tr>
                            <td align="right" width="35%">
                                &nbsp; </td><td align="right" width="60%">
                                <asp:Button ID="Button2" runat="server" CssClass="go" Text="Sign Up" /><asp:Button
                                    ID="Button1" runat="server" CommandName="Login" CssClass="go" Text="<%$ Resources:TimeLive.Resource, Login%> "
                                    ValidationGroup="ctl00$Login1" />
                            </td>
                            <td align="right" width="5%">
                                &nbsp; </td></tr><tr id="GAAR" runat="server">
                            <td align="right" width="35%">
                                &nbsp; </td><td align="right" width="60%" style="vertical-align: middle; font-weight: normal;">
                                <%--<asp:Literal ID="Literal6" runat="server" Text="Sign in with:" />--%>
                                <a href="javascript:void(0)" title="Sign in with Google" id="googleLoginButton" runat="server"
                                    onclick="OpenGoogleLoginPopup();" name="butrequest" style="margin-right: -5px;">
                                    <img src="<%= Page.ResolveUrl("~/Images/Google_New.png")%>" style="width: 95px;" /></a>
                                <%--<rp:OpenIdButton runat="server" ImageUrl="~/Images/social_google_box.png" Text="Google!" ID="googleLoginButton"
			                Identifier="https://www.google.com/accounts/o8/id" OnLoggingIn="googleLoginButton_LoggingIn" OnLoggedIn="googleLoginButton_LoggedIn" />--%>
                                <%--<rp:OpenIdButton runat="server" ImageUrl="~/Images/social_yahoo_box.png" Text="Yahoo!" ID="yahooLoginButton"
			                Identifier="https://me.yahoo.com/" OnLoggingIn="yahooLoginButton_LoggingIn" OnLoggedIn="yahooLoginButton_LoggedIn"  />--%>
                                <%--<rp:OpenIdButton runat="server" ImageUrl="~/Images/social_googleApps_box.png" Text="Google Apps!" ID="googleappsLoginButton"
			                Identifier="https://www.google.com/accounts/o8/id" OnLoggingIn="googleappsLoginButton_LoggingIn" OnLoggedIn="googleappsLoginButton_LoggedIn" />--%>
                            </td>
                            <td align="right" width="5%">
                                &nbsp; </td></tr><tr>
                            <td align="right" colspan="3">
                                <%--<asp:Label ID="ErrorText" 
                             runat="server" CssClass="ErrorMessage"></asp:Label>--%>
                            </td>
                        </tr>
                        <%--<tr>
                            <td align="right" colspan="3" style="border: 1px solid #d6dadf; background-color: #F6F6F6;
                                vertical-align: middle;" height="30px" valign="middle">
                                <a href="Authenticate/PasswordReset.aspx" target="_blank" style="color: #000000;
                                    text-decoration: underline;">
                                    <asp:Literal ID="Literal5" runat="server" Text="<%$ Resources:TimeLive.Resource, Forgot Your Password? Click Here%> " /></a>&nbsp;&nbsp;
                            </td>
                        </tr>--%>
                    </table>
                </td>
            </tr>
        </table>
        <table cellpadding="0" cellspacing="0" align="center" class="xFormView" width="375">
            <tr>
                <td align="right" width="0px">
                  &nbsp; </td><td width="50%">
					XTracker v1.2 <asp:Label Style="display:none" ID="VersionLabel" runat="server" Font-Underline="True" Width="75px"/>
                </td>
                <td width="0px">
                    <asp:Image Style="display:none" ID="Image2" runat="server" ImageUrl="~/Images/Help.gif" Height="15px" />
                </td>
                <td width="50%" align="right">Follow <a href="https://apps.xpand-it.com/jirasd/servicedesk/customer/portal/2/group/9" target="_blank" style="text-decoration: underline;
                        color: #000000"><asp:Literal ID="Literal4" runat="server" Text="<%$ Resources:TimeLive.Resource, Help%>" /></a> for support </td></tr></table><table cellpadding="0" cellspacing="0" align="center" class="xFormView" width="375" style="display:none">
            <tr>
                <td align="center">
                    <asp:Label ID="Label1" runat="server" Font-Bold="False">
                        <asp:Literal ID="CopyRightText" runat="server" Text="<%$ Resources:TimeLive.Resource, Copyright 2007 - 2009 Livetecs LLC. All rights reserved.%> " /></asp:Label><asp:Label
                            ID="Label2" runat="server" Font-Bold="False"></asp:Label></td></tr></table></LayoutTemplate></asp:Login><p>
    <br />
</p>
