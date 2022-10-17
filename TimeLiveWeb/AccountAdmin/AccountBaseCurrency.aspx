<%@ Page Language="VB" AutoEventWireup="false" title="TimeLive - Base Currency" CodeFile="AccountBaseCurrency.aspx.vb" Inherits="AccountAdmin_AccountBaseCurrency" Theme="SkinFile"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <link href="../Styles.css" rel="stylesheet" type="text/css" />
<meta charset="utf-8">
	<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">	
	<meta name="description" content="">
	<meta name="author" content="">

	<meta name="HandheldFriendly" content="True">
	<meta name="MobileOptimized" content="320">
	<meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no">

	<!-- For all browsers -->
	<link rel="stylesheet" href="../css/reset.css?v=1">
	<link rel="stylesheet" href="../css/style.css?v=1">
	<link rel="stylesheet" href="../css/colors.css?v=1">
	<link rel="stylesheet" media="print" href="../css/print.css?v=1">
	<!-- For progressively larger displays -->
	<%--<link rel="stylesheet" media="only all and (min-width: 480px)" href="../css/480.css?v=1">--%>
	<link rel="stylesheet" media="only all and (min-width: 768px)" href="../css/768.css?v=1">
<%--	<link rel="stylesheet" media="only all and (min-width: 992px)" href="../css/992.css?v=1">
	<link rel="stylesheet" media="only all and (min-width: 1200px)" href="../css/1200.css?v=1">--%>
	<!-- For Retina displays -->
	<link rel="stylesheet" media="only all and (-webkit-min-device-pixel-ratio: 1.5), only screen and (-o-min-device-pixel-ratio: 3/2), only screen and (min-device-pixel-ratio: 1.5)" href="../css/2x.css?v=1">

	<!-- Webfonts -->	

	<!-- Additional styles -->
	<link rel="stylesheet" href="../css/styles/form.css?v=1">
	<link rel="stylesheet" href="../css/styles/switches.css?v=1">
	<link rel="stylesheet" href="../css/styles/table.css?v=1">

	<!-- DataTables -->
	<link rel="stylesheet" href="../js/libs/DataTables/jquery.dataTables.css?v=1">

	<!-- JavaScript at bottom except for Modernizr -->
	<script src="../js/libs/modernizr.custom.js"></script>

	<!-- For Modern Browsers -->
	<link rel="shortcut icon" href="../img/favicons/favicon.png">
	<!-- For everything else -->
	<link rel="shortcut icon" href="../img/favicons/favicon.ico">
	<!-- For retina screens -->
	<link rel="apple-touch-icon-precomposed" sizes="114x114" href="../img/favicons/apple-touch-icon-retina.png">
	<!-- For iPad 1-->
	<link rel="apple-touch-icon-precomposed" sizes="72x72" href="../img/favicons/apple-touch-icon-ipad.png">
	<!-- For iPhone 3G, iPod Touch and Android -->
	<link rel="apple-touch-icon-precomposed" href="../img/favicons/apple-touch-icon.png">

	<!-- iOS web-app metas -->
	<meta name="apple-mobile-web-app-capable" content="yes">
	<meta name="apple-mobile-web-app-status-bar-style" content="black">

	<!-- Startup image for web apps -->
	<link rel="apple-touch-startup-image" href="../img/splash/ipad-landscape.png" media="screen and (min-device-width: 481px) and (max-device-width: 1024px) and (orientation:landscape)">
	<link rel="apple-touch-startup-image" href="../img/splash/ipad-portrait.png" media="screen and (min-device-width: 481px) and (max-device-width: 1024px) and (orientation:portrait)">
	<link rel="apple-touch-startup-image" href="../img/splash/iphone.png" media="screen and (max-device-width: 320px)">

	<!-- Microsoft clear type rendering -->
	<meta http-equiv="cleartype" content="on">

    <style type="text/css">
    #UpdatePanel1 {
      width:200px; height:100px;
      border: 1px solid gray;
    }
    #UpdateProgress1 {
      width:200px; background-color: #FFC080;
      bottom: 0%; left: 0px; position: absolute;
    }
    </style>
    <script src="../js/developr.scroll.js"></script>
</head>
<body onunload="opener.location.reload();">
    <form id="form1" runat="server">
    <div>
                <asp:FormView ID="FormView1" runat="server"
                    DefaultMode="Edit" Width="400px" DataKeyNames="AccountId" DataSourceID="dsAccountBaseCurrencyFormViewObject" SkinID="formviewSkinEmployee">
                    <EditItemTemplate>
                        <table width="400">
                            <tr>
                                <th class="caption" colspan="2">
                                    <asp:Literal ID="Literal3" runat="server" Text="<%$ Resources:TimeLive.Resource, Base Currency%> " /></th>
                            </tr>
                            <tr>
                                <td align="right" style="width: 40%">
                                    <asp:Literal ID="Literal1" runat="server" Text="<%$ Resources:TimeLive.Resource, Update existing records:%> " /></td>
                                </td>
                                <td style="width: 60%">
                                    <asp:CheckBox ID="CheckBox1" runat="server" /></td>
                            </tr>
                            <tr>
                                <td style="width: 40%" align="right">
                                    <asp:Literal ID="Literal2" runat="server" Text="<%$ Resources:TimeLive.Resource, Name:%> " /></td>
                                </td>
                                <td style="width: 60%">
                                    <asp:DropDownList ID="ddlAccountCurrencyId" runat="server" Width="200px" 
                                    DataSourceID="dsAccountCurrencyObject" DataTextField="Currency" DataValueField="AccountCurrencyId" SelectedValue='<%# Bind("AccountBaseCurrencyId") %>'>
                                    </asp:DropDownList>&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 40%" align="right">
                                </td>
                                <td style="width: 60%; padding-bottom: 5px;">
                                    <asp:Button ID="btnUpdate" runat="server" CommandName="Update" Text="<%$ Resources:TimeLive.Resource, Update_text%> " OnClick="btnUpdate_Click" /></td>
                            </tr>
                        </table>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        AccountCurrencyExchangeRateId:
                        <asp:TextBox ID="AccountCurrencyExchangeRateIdTextBox" runat="server" Text='<%# Bind("AccountCurrencyExchangeRateId") %>'>
                        </asp:TextBox><br />
                        SystemCurrencyId:
                        <asp:TextBox ID="SystemCurrencyIdTextBox" runat="server" Text='<%# Bind("SystemCurrencyId") %>'>
                        </asp:TextBox><br />
                        AccountId:
                        <asp:TextBox ID="AccountIdTextBox" runat="server" Text='<%# Bind("AccountId") %>'>
                        </asp:TextBox><br />
                        Disabled:
                        <asp:CheckBox ID="DisabledCheckBox" runat="server" Checked='<%# Bind("Disabled") %>' /><br />
                        <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert"
                            Text="Insert">
                        </asp:LinkButton>
                        <asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False" CommandName="Cancel"
                            Text="Cancel">
                        </asp:LinkButton>
                    </InsertItemTemplate>
                    <ItemTemplate>
                        AccountCurrencyId:
                        <asp:Label ID="AccountCurrencyIdLabel" runat="server" Text='<%# Eval("AccountCurrencyId") %>'>
                        </asp:Label><br />
                        AccountCurrencyExchangeRateId:
                        <asp:Label ID="AccountCurrencyExchangeRateIdLabel" runat="server" Text='<%# Bind("AccountCurrencyExchangeRateId") %>'>
                        </asp:Label><br />
                        SystemCurrencyId:
                        <asp:Label ID="SystemCurrencyIdLabel" runat="server" Text='<%# Bind("SystemCurrencyId") %>'>
                        </asp:Label><br />
                        AccountId:
                        <asp:Label ID="AccountIdLabel" runat="server" Text='<%# Bind("AccountId") %>'></asp:Label><br />
                        Disabled:
                        <asp:CheckBox ID="DisabledCheckBox" runat="server" Checked='<%# Bind("Disabled") %>'
                            Enabled="false" /><br />
                    </ItemTemplate>
                </asp:FormView>
                &nbsp;</div>
        <asp:ObjectDataSource ID="dsAccountBaseCurrencyFormViewObject" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetPreferencesByAccountId" TypeName="AccountBLL" UpdateMethod="UpdateAccountBaseCurrencyId">
            <UpdateParameters>
                <asp:SessionParameter DefaultValue="5" Name="Original_AccountId" SessionField="AccountId"
                    Type="Int32" />
                <asp:Parameter DefaultValue="" Name="AccountBaseCurrencyId" Type="Int32" />
            </UpdateParameters>
            <SelectParameters>
                <asp:SessionParameter DefaultValue="151" Name="AccountId" SessionField="AccountId"
                    Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="dsAccountCurrencyObject" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetDataByAccountIdforBaseCurrency" 
        TypeName="AccountCurrencyBLL" DeleteMethod="DeleteAccountCurrency" 
        InsertMethod="AddAccountCurrency" UpdateMethod="UpdateAccountCurrency">
            <DeleteParameters>
                <asp:Parameter Name="Original_AccountCurrencyId" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="SystemCurrencyId" Type="Int32" />
                <asp:Parameter Name="AccountId" Type="Int32" />
                <asp:Parameter Name="AccountCurrencyExchangeRateId" Type="Int32" />
                <asp:Parameter Name="Disabled" Type="Boolean" />
            </InsertParameters>
            <SelectParameters>
                <asp:SessionParameter DefaultValue="151" Name="AccountId" 
                    SessionField="AccountId" Type="Int32" />
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter Name="SystemCurrencyId" Type="Int32" />
                <asp:Parameter Name="Original_AccountCurrencyId" Type="Int32" />
                <asp:Parameter Name="AccountCurrencyExchangeRateId" Type="Int32" />
                <asp:Parameter Name="AccountId" Type="Int32" />
                <asp:Parameter Name="Disabled" Type="Boolean" />
            </UpdateParameters>
        </asp:ObjectDataSource>
    </form>
</body>
</html>
