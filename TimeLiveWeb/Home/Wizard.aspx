<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Wizard.aspx.vb" Inherits="Home_Wizard" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml"  lang="en">
<%--class="no-js linen"--%>
<head id="Head1" runat="server">
	<meta charset="utf-8"> 
	<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">

	<title>Wizard</title>
	<meta name="description" content="">
	<meta name="author" content="">

	<!-- http://davidbcalhoun.com/2010/viewport-metatag -->
	<meta name="HandheldFriendly" content="True">
	<meta name="MobileOptimized" content="320">
	<meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no">

	<!-- For all browsers -->
	<link rel="stylesheet" href="../css/reset.css?v=1">
	<link rel="stylesheet" href="../css/style.css?v=1">
	<link rel="stylesheet" href="../css/colors.css?v=1">
	<link rel="stylesheet" media="print" href="../css/print.css?v=1">
	<!-- For progressively larger displays -->
	<link rel="stylesheet" media="only all and (min-width: 480px)" href="../css/480.css?v=1">
	<link rel="stylesheet" media="only all and (min-width: 768px)" href="../css/768.css?v=1">
	<link rel="stylesheet" media="only all and (min-width: 992px)" href="../css/992.css?v=1">
	<link rel="stylesheet" media="only all and (min-width: 1200px)" href="../css/1200.css?v=1">
	<!-- For Retina displays -->
	<link rel="stylesheet" media="only all and (-webkit-min-device-pixel-ratio: 1.5), only screen and (-o-min-device-pixel-ratio: 3/2), only screen and (min-device-pixel-ratio: 1.5)" href="../css/2x.css?v=1">

	<!-- Additional styles -->
	<link rel="stylesheet" href="../css/styles/form.css?v=1">
	<link rel="stylesheet" href="../css/styles/switches.css?v=1">

	<!-- jQuery Form Validation -->
	<link rel="stylesheet" href="../js/libs/formValidator/developr.validationEngine.css?v=1">

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

	<!-- IE9 Pinned Sites: http://msdn.microsoft.com/en-us/library/gg131029.aspx -->
	<meta name="application-name" content="Developr Admin Skin">
	<meta name="msapplication-tooltip" content="Cross-platform admin template.">
	<meta name="msapplication-starturl" content="http://www.display-inline.fr/demo/developr">
	<!-- These custom tasks are examples, you need to edit them to show actual pages -->
	<meta name="msapplication-task" content="name=Agenda;action-uri=http://www.display-inline.fr/demo/developr/agenda.html;icon-uri=http://www.display-inline.fr/demo/developr/img/favicons/favicon.ico">
	<meta name="msapplication-task" content="name=My profile;action-uri=http://www.display-inline.fr/demo/developr/profile.html;icon-uri=http://www.display-inline.fr/demo/developr/img/favicons/favicon.ico">
</head>

<body class="full-page-wizard" style="background-color:#f7f7f7">
<table width="99%" style="height:0px"><tr><td style="width:49%; height:0px">
 <% If System.Configuration.ConfigurationManager.AppSettings("BugTracking") = "Yes" Then%>
    <div style="text-align:left;vertical-align:middle; height:0px;"><asp:Image ID="HI" runat="server"  Height="50px"  ImageUrl="~/Images/TrakLiveLogo.png" AlternateText="TimeLive Logo" /></div> 
    <% Else%>
    <div style="text-align:left;vertical-align:middle; height:0px; margin-top:-10px"><asp:Image ID="Image1" runat="server"  Height="50px"  ImageUrl="~/Images/TopHeader.png" AlternateText="TimeLive Logo" /></div>
    <% End If%>
    </td><td style="width:50%; height:0px; vertical-align:middle">
    <div style="text-align:right;vertical-align:inherit; height:10px;"><label style="vertical-align:bottom"><b>Questions & Comments?</b> Call us at: 1 (888) 666-8154</label></div>
    </td></tr></table>
	<form id="Form1" class="block wizard same-height" runat="server">
   
		<h3 class="block-title">Let's Get Started</h3>

		<fieldset class="wizard-fieldset fields-list">

			<legend class="legend">General</legend>

			<div class="field-block">
				<h4>Step 1 : General Information about your company.</h4>
			</div>

			<div class="field-block">
				<label for="ddlStandardAndFormats" class="label"><b>Standard and Formats</b></label>
				<%--<asp:DropDownList ID="CultureInfoName" runat="server" AppendDataBoundItems="True" DataSourceID="dsLocaleInfo" DataTextField="EnglishName" DataValueField="Name" Width="300px"><asp:ListItem 
                Value="auto"></asp:ListItem></asp:DropDownList>--%>
                <select name="country" class="select" id="ddlStandardAndFormats" runat="server"  style="width:450px;">
                <option value="auto">auto</option>
                </select> 
                <asp:ObjectDataSource ID="dsLocaleInfo" runat="server" OldValuesParameterFormatString="original_{0}"
                SelectMethod="GetAllCultureInfo" TypeName="LocaleUtilitiesBLL">
                </asp:ObjectDataSource>
                <small class="input-info" style="width: 455px;">The selected option will be used to display Date & Time formats. Set it to “Default” to use the settings of your browser.</small>
			</div>

			<div class="field-block">
				<label for="ddlTimeZone" class="label"><b>Time Zone</b></label>
				<select id="ddlTimeZone" name="country" class="select" runat="server" style="width:450px;"></select> 
                <asp:ObjectDataSource id="dsTimeZone" runat="server" TypeName="SystemDataBLL" SelectMethod="GetTimeZones" OldValuesParameterFormatString="original_{0}">
                </asp:ObjectDataSource>
                <small class="input-info" style="width: 455px;">Time Zone settings will be used to send notifications emails at the specified scheduled time per employee. Time Zone settings can be different for every individual employee.</small>
			</div>

		    <div class="field-block">
				<label for="ddlCurrency" class="label"><b>Base Currency</b></label>
				<%--<input type="text" name="last_name" id="Text1" value="" class="input validate[required]">--%>
                <select id="ddlCurrency" name="country" class="select" runat="server" datasourceid="dsCurrenciesObject" datatextfield="CurrencyWithCode" datavaluefield="CurrencyId" style="width:450px;"></select> 
                <asp:ObjectDataSource ID="dsCurrenciesObject" runat="server" OldValuesParameterFormatString="original_{0}"
                SelectMethod="GetCurrenciesWithCode" TypeName="SystemDataBLL"></asp:ObjectDataSource>
                <small class="input-info" style="width: 455px;">The Base Currency will be the default currency of your organization. You can add up other currencies with conversion rates to use TimeLive for multiple currencies.</small>
			</div>

          

            <div class="field-block">
				<label for="ddlUILanguage" class="label"><b>UI Language</b></label>
                	<select id="ddlUILanguage" runat="server" name="country" class="select" style="width:450px;">
					<option value="en-US">English (United States)</option>
					<option value="de-DE">German (Germany)</option>
					<option value="fr-FR">French (France)</option>
					<option value="zh-CN">Chinese (Simplified, PRC)</option>
					<option value="it-IT">Italian (Italy)</option>
					<option value="nl-NL">Dutch (Netherlands)</option>
                    <option value="es-ES">Spanish (Spain)</option>
					<option value="sv-SE">Swedish (Sweden)</option>
					<option value="pt-PT">Portuguese (Portugal)</option>
                    <option value="nn-NO">Norwegian, Nynorsk (Norway)</option>
                    </select> 
                    <small class="input-info" style="width: 455px;">This will be default language to be used for every individual employee. You can setup different language settings for every individual employee.</small>
			</div>
              <div class="field-block">
				<label for="ddlShowEmployeeNameBy" class="label"><b>Show Employee Name By</b></label>
                <select name="country" id="ddlShowEmployeeNameBy" runat="server" class="select" style="width:450px;">
				<option value="1">First Name And Last Name</option>
				<option value="2">Last Name And First Name</option>
                </select> 
                <small class="input-info" style="width: 455px;">This setting will be used to display the name of your Employees/Contractors/Approvers etc in TimeLive.</small>
			</div>
                <div class="field-block">
                    <small class="input-info" style="font-size:10.5px;color:Red;">NOTE: You can modify these settings at any stage using preferences options available in “Admin Options”.</small>
			    </div>
		</fieldset>

		<fieldset class="wizard-fieldset fields-list">

			<legend class="legend">Timesheet Setup</legend>
            <div class="field-block">
				<h4>Step 2: Timesheet Settings</h4>
			</div>
                <div class="field-block">
				<label for="txtBlankRowsTimesheet" class="label"><b>Blank Rows in Timesheet</b></label>
				<%--<input type="checkbox" name="notifications[]" id="Checkbox1" value="mention" class="checkbox">--%>
                <input type="text" name="mail" id="txtBlankRowsTimesheet" runat="server" value="" class="input validate[required],min[2],max[15]" style="width:50px;">
                <small class="input-info" style="width: 541px;">Open empty timesheet with the specified number of empty rows available there. Also, while using timesheet, you can add up additional rows as well by filling up rows and saving the timesheet.</small>
			</div>
			<div class="field-block">
				<label for="chkShowClockStartEnd" class="label"><b>Show Clock Start/End</b></label>
				<%--<input type="checkbox" name="notifications[]" id="Checkbox1" value="mention" class="checkbox">--%>
                <%--<input type="checkbox" name="newsletter" id="Checkbox2" value="1" class="switch" checked data-text-on="YES" data-text-off="NO">--%>
                <input type="checkbox" name="switch-medium-1" id="chkShowClockStartEnd" runat="server" class="switch medium mid-margin-right" value="1" data-text-on="YES" data-text-off="NO">
                <small class="input-info" style="width: 541px;">Enable this option if you want your employees to input Start & End Time against the activity to record duration. By disabling this option, employees will only have to put the duration of the activity.</small>
			</div>
            <div class="field-block">
				<label for="chkShowClientInTimesheet" class="label"><b>Show Client in Timesheet</b></label>
				<%--<input type="checkbox" name="notifications[]" id="Checkbox1" value="mention" class="checkbox">--%>
                <input type="checkbox" name="switch-medium-1" id="chkShowClientInTimesheet" runat="server" class="switch medium mid-margin-right" value="1" data-text-on="YES" data-text-off="NO">
                <small class="input-info" style="width: 541px;">Enable this option if you want your employees to select “Client” first to select Project & Task. By disabling this option, Timesheet will only display you the Project & Task dropdown list for selection.</small>
			</div>
         
			<div class="field-block">
				<label for="ddlTimeEntryHoursFormatId" class="label"><b>Time Entry Format</b></label>
                <select id="ddlTimeEntryHoursFormatId" name="country" class="select" runat="server" style="width:115px;" >
                <option value="None">None</option></select> 
           <%--     <select name="country" id="ddlTimeEntryFormat" runat="server" style="width:115px;" class="select">
				<option value="HH:mm">HH:MM</option>
				<option value="hh:mm tt">HH:MM AM/PM</option>
                </select> --%>
                <asp:ObjectDataSource 
                ID="dsSystemTimeEntryHoursFormat" runat="server" OldValuesParameterFormatString="original_{0}"
                SelectMethod="GetSystemTimeEntryHoursFormat" TypeName="SystemDataBLL"></asp:ObjectDataSource>
                <small class="input-info" style="width: 541px;">TimeLive supports two types of Time Entry input. One is Time Entry which would be the standard time format and other one is “Decimal” input.</small>
			</div>

            	<div class="field-block">
				<label class="label"><b>Timesheet Period Type</b></label>
                <select id="ddlTimesheetPeriodTypeId" name="country" class="select" runat="server" style="width:115px;"></select> 
                <%--<select id="ddlWeekStartDay" name="country" class="select" runat="server" datasourceid="dsWeekStartDayObject" datatextfield="WorkingDay" datavaluefield="WorkingDayNo" style="width:115px;"></select> --%>
                <asp:ObjectDataSource ID="dsTimesheetPeriodTypeObject" runat="server"
                OldValuesParameterFormatString="original_{0}" SelectMethod="GetvueAccountTimesheetPeriodTypesByAccountIdandIsDisabled"
                TypeName="AccountTimesheetPeriodTypeBLL">
                <SelectParameters>
                <asp:SessionParameter Name="AccountId" SessionField="AccountId" Type="Int32" />
                <asp:Parameter DefaultValue="00000000-0000-0000-0000-000000000000"
                Name="AccountTimesheetPeriodTypeId" />
                </SelectParameters>
                </asp:ObjectDataSource>
<%--                <asp:ObjectDataSource ID="dsWeekStartDayObject" runat="server" OldValuesParameterFormatString="original_{0}"
                SelectMethod="GetWorkingDays" TypeName="SystemDataBLL">
                </asp:ObjectDataSource>--%>
                <small class="input-info" style="width: 541px;">TimeLive supports Daily/Weekly/Bi-Weekly/Semi-monthly/Monthly period type. For eg, if you select “Weekly”, the timesheet will be displayed in week view and employees will have to submit it on a week-to-week basis.</small>
			</div>
            <div class="field-block">
                <small class="input-info" style="font-size:10.5px;color:Red;">NOTE: You can modify these settings at any stage using preferences options available in “Admin Options”.</small>
			</div>
            <% If System.Configuration.ConfigurationManager.AppSettings("ApplicationMode") <> "Installed" Then%>
              <div class="field-block wizard-controls align-right">

				<button id="btnSaveHosted" runat="server" type="submit" class="button green-gradient mid-margin-right" style="width:70px;">
					<%--<span class="button-icon"></span>
                    <span class="icon-tick"></span>--%>
					Save
				</button>

			</div>
            <% End If %>
		</fieldset>
         <% If System.Configuration.ConfigurationManager.AppSettings("ApplicationMode") = "Installed" Then %>
		<fieldset class="wizard-fieldset fields-list">

			<legend class="legend">SMTP Settings</legend>
            <div class="field-block">
				<h4>Step 3: SMTP Settings</h4>
			</div>
			<div class="field-block">
				<label for="txtSMTPServer" class="label"><b>SMTP Server</b></label>
				<input type="text" name="mail" id="txtSMTPServer" runat="server" value="" class="input"/>
                <small class="input-info">The IP address or host name of the SMTP server. For example: smtp.google.com</small>
			</div>

			<div class="field-block">
				<label for="txtSMTPUsername" class="label"><b>SMTP Username</b></label>
				<input type="text" name="twitter" id="txtSMTPUsername" runat="server" value="" class="input"/>
                <small class="input-info">The username Timelive will use to authenticate with the SMTP server. For example: johnbenson@gmail.com</small>
			</div>

			<div class="field-block">
				<label for="txtSMTPPassword" class="label"><b>SMTP Password</b></label>
				<input type="text" name="mobile" id="txtSMTPPassword" runat="server" value="" class="input"/>
                <small class="input-info">The password Timelive will use to authenticate with the SMTP server. For example: demo</small>
			</div>
            		
            <div class="field-block">
				<label for="txtSMTPProtNumber" class="label"><b>SMTP Port Number</b></label>
				<input type="text" name="mobile" id="txtSMTPProtNumber" runat="server" value="" class="input"/>
                <small class="input-info">The port number of the SMTP server, usually port 25. For example: 587</small>
			</div>	
            <div class="field-block">
				<label for="chkUseSSL" class="label"><b>Use SSL / TLS</b></label>
				<input type="checkbox" name="switch-medium-1" id="chkUseSSL" runat="server" class="switch medium mid-margin-right" data-text-off="NO" data-text-on="YES" />
                <small class="input-info">Enable this option if your SMTP use SSL/TLS.</small>
			</div>
            <div class="field-block">
                <small class="input-info" style="font-size:10.5px;color:Red;">NOTE: These SMTP settings will be used to sent notifications/reminder emails from TimeLive. If you do not provide these, you’ll not get any of the emails sent by TimeLive.</small>
			</div>
            <div class="field-block wizard-controls align-right">

				<button id="btnSave" runat="server" type="submit" class="button green-gradient mid-margin-right" style="width:70px;">
					<%--<span class="button-icon"></span>
                    <span class="icon-tick"></span>--%>
					Save
				</button>

			</div>
		</fieldset>
        <% End if %>
		<%--<fieldset class="wizard-fieldset fields-list">

			<legend class="legend">Preferences</legend>

			<div class="field-block">
				<label for="newsletter" class="label"><b>Subscribe to newsletter</b></label>
				<input type="checkbox" name="newsletter" id="newsletter" value="1" class="switch" checked data-text-on="YES" data-text-off="NO">
			</div>

			<div class="field-block">
				<label for="newsletter_html" class="label"><b>Newsletter format</b></label>
				<input type="checkbox" name="newsletter_html" id="newsletter_html" value="1" class="switch wide orange-active" checked data-text-on="HTML" data-text-off="TEXT">
				<small class="input-info">If you are not sure, use HTML</small>
			</div>

			<div class="field-block">
				<span class="label"><b>Mail notifications</b></span>
				<input type="checkbox" name="notifications[]" id="notifications_mention" value="mention" class="checkbox"> <label for="notifications_mention">When I am mentioned</label><br>
				<input type="checkbox" name="notifications[]" id="notifications_message" value="message" class="checkbox"> <label for="notifications_message">When someone sends me a message</label><br>
				<input type="checkbox" name="notifications[]" id="notifications_reply" value="reply" class="checkbox"> <label for="notifications_reply">When someone replies to one of my messages</label><br>
				<input type="checkbox" name="notifications[]" id="notifications_reviewed" value="reviewed" class="checkbox"> <label for="notifications_reviewed">When a new review is published on one of my products</label>
			</div>

			<div class="field-block wizard-controls align-right">

				<button type="submit" class="button glossy mid-margin-right">
					<span class="button-icon"><span class="icon-tick"></span></span>
					Save
				</button>

			</div>

		</fieldset>--%>
	</form>

	<!-- JavaScript at the bottom for fast page loading -->
<%--     <script type="text/javascript">
         function ShowHideTimeEntryFormat(id) {

             //            document.getElementById('ddlTimeEntryFormat').style.display = 'none !important';

             document.getElementById(id).style.display = 'none';

         }
    </script>--%>
	<!-- Scripts -->
	<script src="../js/libs/jquery-1.7.2.min.js"></script>
	 <script src="../js/setup.js"></script>

	<!-- Template functions -->
	<script src="../js/developr.input.js"></script>
	<script src="../js/developr.message.js"></script>
	<script src="../js/developr.notify.js"></script>
	<script src="../js/developr.scroll.js"></script>
	<script src="../js/developr.tooltip.js"></script>
	<script src="../js/developr.wizard.js"></script>
   
	<!-- jQuery Form Validation -->
	<script src="../js/libs/formValidator/jquery.validationEngine.js?v=1"></script>
	<script src="../js/libs/formValidator/languages/jquery.validationEngine-en.js?v=1"></script>

	<script>

	    $(document).ready(function () {
	        $('#txtBlankRowsTimesheet').on('change', function () {
	            if (this.value < 2 || this.value > 15)
	                $('#btnSaveHosted').hide();
                else
                    $('#btnSaveHosted').show();
	        });
	        //$('#ddlTimeEntryFormat').attr('style', 'background: black !important');
	        // Elements
	        var form = $('.wizard'),

	        // If layout is centered
				centered;

	        // Handle resizing (mostly for debugging)
	        function handleWizardResize() {
	            centerWizard(false);
	        };

	        // Register and first call
	        $(window).bind('normalized-resize', handleWizardResize);

	        /*
	        * Center function
	        * @param boolean animate whether or not to animate the position change
	        * @return void
	        */
	        function centerWizard(animate) {
	            form[animate ? 'animate' : 'css']({ marginTop: Math.max(0, Math.round(($.template.viewportHeight - 30 - form.outerHeight()) / 2)) + 'px' });
	        };

	        // Initial vertical adjust
	        centerWizard(false);

	        // Refresh position on change step
	        form.on('wizardchange', function () { centerWizard(true); });

	        // Validation
	        if ($.validationEngine) {
	            form.validationEngine();
	        }

	    });

	</script>
    <script type="text/javascript">
        function ShowHideTimeEntryFormat(id) {

            //            document.getElementById('ddlTimeEntryFormat').style.display = 'none !important';

            document.getElementById(id).style.display = 'none';

        }
    </script>
</body>
</html>
