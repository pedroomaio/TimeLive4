<%@ Page Language="VB" AutoEventWireup="false" CodeFile="PreWizard.aspx.vb" Inherits="Home_PreWizard" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
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
    <link rel="stylesheet" href="../css/styles/modal.css?v=1"">
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
	<meta name="msapplication-tooltip" content="Cross-platform admin template.">
	<meta name="msapplication-starturl" content="http://www.display-inline.fr/demo/developr">
	<!-- These custom tasks are examples, you need to edit them to show actual pages -->
	<meta name="msapplication-task" content="name=Agenda;action-uri=http://www.display-inline.fr/demo/developr/agenda.html;icon-uri=http://www.display-inline.fr/demo/developr/img/favicons/favicon.ico">
	<meta name="msapplication-task" content="name=My profile;action-uri=http://www.display-inline.fr/demo/developr/profile.html;icon-uri=http://www.display-inline.fr/demo/developr/img/favicons/favicon.ico">
   <style type="text/css">
          .container {
    display: table;
    width:80%;
    text-align:center;
    padding-top:25px;
    margin:0 auto;
    }

  .row  {
    display: table-row;
    }

  .cell  {
    display: table-cell;
    }
    </style>
    
</head>

<body >

<form id="Form1" runat="server" >
<asp:ScriptManager ID="ScriptManager2" runat="server">
            </asp:ScriptManager>   
<table width="99%" style="height:50px" cellpadding="5px" cellspacing="5px" ><tr><td style="width:49%">
 <% If System.Configuration.ConfigurationManager.AppSettings("BugTracking") = "Yes" Then%>
    <div style="text-align:left;vertical-align:middle;"><asp:Image ID="HI" runat="server"  Height="50px"  ImageUrl="~/Images/TrakLiveLogo.png" AlternateText="TimeLive Logo" /></div> 
    <% Else%>
    <div style="text-align:left;vertical-align:middle;margin: 10px;"><asp:Image ID="Image1" runat="server"   Height="50px"  ImageUrl="~/Images/TopHeader.png" AlternateText="TimeLive Logo" /></div>
    <% End If%>
    </td><td style="width:50%;vertical-align:middle">
    <div style="text-align:right;vertical-align:inherit; "><label style="vertical-align:bottom"><b>Questions & Comments?</b> Call us at: 1 (888) 666-8154</label></div>
    </td></tr></table>
    <div style=" height:250px; background-color: #226DA9">
   <p style="text-align:center;padding-top: 25px;font-size: 45px; color:White">Let's Get Started</p>
    <p style="color:#666666; color:White;text-align:center;font-size: 16px;padding-top: 21px;"> TimeLive wizard will take you through with the basic configurations of your account.</p>
    <p style="color:#666666; color:White;text-align:center;font-size: 16px;"> Easy to setup options and configurable features lets you get started in only few minutes.</p>
   <div style="text-align: center;padding-top: 7px;">
    <button id="btnGetStarted" runat="server" type="submit" class="button green-gradient" style="width: 170px;height: 40px;font-size: 13px;">Get Started</button>
    </div>
    <div style="text-align: center;padding-top: 16px;">
    <button id="btnChatWithUs" runat="server" type="submit" class="button gray-gradient" style="width: 160px;">Chat with us!</button>
    <span style="color:White; padding-left:15px; padding-right: 15px;">or</span>
    <button id="btnRequestCall" runat="server" type="submit" class="button gray-gradient" style="width: 160px;">Request a call</button>
    </div>
      <div style="text-align: center;padding-top: 12px;">
      <a id="btnSkip" runat="server" href="#" style="color:White; text-decoration: underline;font-size: 13px">No Thanks, I'll Set It Up Manually</a>
    </div>

                </div> 
                <p style="text-align:center;padding-top: 20px;font-size: 25px">Track Time & Expense With Billing Software</p>
                <p style="text-align:center;padding-top: 2px;font-size: 13px;width: 28%;margin: 0 auto;line-height: 18px;">Features includes Time Tracking, Expense Tracking, Project Management, Time Off, Billing & Invoicing, Quickbook Integration, Mobile Applications, Multi-Language, Multi-Currency, Custom Reports, Custom Fields etc.</p>   <div class="container">
  <div class="row">

  	<div class="cell">
  		<img src="../img/timesheetnew.png" style="height: 40px;" />
  		<p style="padding-top: 10px;color: #226DA9;text-decoration: underline; font-weight:bold">Time Tracking</p>
        <p style="width: 95%;margin: 0 auto;">Track your contractor and employee’s time tracking using full featured and easy to use Time Entry tool.</p>
  	</div>
 	<div class="cell">
  		<img src="../img/expense.png" style="height: 40px;" />
  		<p style="padding-top: 10px;color: #226DA9;text-decoration: underline; font-weight:bold">Expense Tracking</p>
        <p style="width: 95%;margin: 0 auto;">Manage and monitor your project expenses with easy to use integrated TimeLive Expense management tools.</p>
  	</div>
     	<div class="cell">
  		<img src="../img/reports.png" style="height: 40px;" />
  		<p style="padding-top: 10px;color: #226DA9;text-decoration: underline; font-weight:bold">Time & Expense Billing</p>
        <p style="width: 95%;margin: 0 auto;">Easily account for billable and non-billable time and expenses. Tailor rates for individual clients, employees, and projects.</p>
  	</div>
     	<div class="cell">
  		<img src="../img/timeoffnew.png" style="height: 40px;" />
  		<p style="padding-top: 10px;color: #226DA9;text-decoration: underline; font-weight:bold">Time Off / Leaves</p>
        <p style="width: 95%;margin: 0 auto;">Time Off tracker can take care of the most complex accrual rules automatically.</p>
  	</div>

	</div>
     </div>
    <cc1:modalpopupextender id="ModalPopupExtender2" runat="server" 
	cancelcontrolid="btnCancel" 
	targetcontrolid="btnRequestCall" popupcontrolid="Panel2" 
	popupdraghandlecontrolid="PopupHeader" drag="true" 
	backgroundcssclass="ModalPopupBG">
</cc1:modalpopupextender>

<asp:panel id="Panel2" style="display: none" runat="server">
	<div class="modal" style="height: 300px;" >

                
   <div class="modal-bg" style="width: 500px;height: 290px;">
        <div class="modal-content">

<%--<div class="standard-tabs margin-bottom" id="add-tabs" style="height: 46px; font-size: 28px;text-align: left;" >
						<span>Request a Call</span>
                        <div class="tabs-content" style="min-height: 29px;border-right: 0px;border-left: 0px;border-bottom: 0px;" >
                        <span style="color: #666666;font-size:16px; line-height:27px;">A TimeLive representative will be in touch within one business day to help configure your account. If submitted outside of normal business hours, please allow for extra time.</span> 
</div>

</div>--%>
<div style="color: #666666;font-size: 27px;padding-top: 10px;text-align: left;">Request a Call</div>
<div style="border-bottom: 1px solid #e5e5e5; padding-top:20px" ></div> 
<div style="color: #666666;font-size:14px; line-height:20px;padding-top: 10px;text-align: left;">Our representative will call you back as soon as possible to assist you in configuring your account and providing answers to your questions. If submitted outside of normal business hours, please allow for extra time.</div> 
<div style="color: #666666;font-size:13px; padding-top: 30px;text-align: left; padding-bottom:10px;">Please enter a phone number where you can be reached:</div> 
<input type="text" placeholder="Phone Number" id="txtPhoneNo" runat="server" value=""  class="input validate[required]" style="width:70%;"/>
<div><label style="color: red;font-size: 11px;font-weight: bold;" id="lblerror">Please enter phone number.</label></div>
<div><label style="color: red;font-size: 11px;font-weight: bold;" id="lblvaliderror">Please enter valid phone number.</label></div>

</div>


   </div>
             
    <div style="background-color:#f5f5f6; border-top:solid 1px #dddddd;margin-top: -73px;margin-left: -12px;padding-top: 12px;margin-right: -11px;height: 59px;text-align: right;padding-right: 5px;" >     
    <button id="btnCancel" runat="server" type="submit" class="button gray-gradient" style="width: 100px;height: 45px;font-size: 13px;margin-right: 10px;">Cancel Request</button>
    <button id="btnFinalRequest" runat="server" type="submit" class="button green-gradient" style="width: 100px;height: 45px;font-size: 13px;">Request a Call</button>
    <button id="btnSendEmail" runat="server" type="submit" class="button green-gradient" style="width: 100px;height: 45px;font-size: 13px; display:none">Request a Call</button>
    </div>
           </div>
           <div class="modal-resize-nw"></div><div class="modal-resize-n"></div>
    <div class="modal-resize-ne"></div><div class="modal-resize-e"></div><div class="modal-resize-se"></div>
    <div class="modal-resize-s"></div><div class="modal-resize-sw"></div><div class="modal-resize-w"></div>
</asp:panel> 

    <%--<span ><img src="../Images/TimesheetPeriodTypes.gif"  /></span>--%>
    <%--<br /><span ><label>test</label></span>--%>
    
  <%--  <span style="padding-left:100px;"><img src="../Images/TimesheetPeriodTypes.gif"  /></span>
    <span style="padding-left:100px;"><img src="../Images/TimesheetPeriodTypes.gif"  /></span>
    <span style="padding-left:100px;"><img src="../Images/TimesheetPeriodTypes.gif"  /></span>--%>
   
 <%--   <div style="text-align:center;">
    <span ><label>Time Tracking</label></span>
    <span style="padding-left:100px;"><label>Expense Tracking</label></span>
    <span style="padding-left:100px;"><label>Time & Expense Billing</label></span>
    <span style="padding-left:100px;"><label>Time Off / Leaves</label></span>
    </div>--%>
	</form>
    <%--  <script type="text/javascript">
          function isvalidphoneno() {

              var uid;
              var temp = document.getElementById("<%=txtPhoneNo.ClientID %>");
              uid = temp.value;
              var re;
              re = /^[0-9]+$/;
              var digits = /\d(10)/;
              if (uid == "") {
                  var error = document.getElementById("<%=ErrorText.ClientID %>");
                  error.innertext = "Please enter phone no";
                  return;
              }
              else if (re.test(uid)) {
                  return "";
              }

              else {
                  return ("Phoneno should be digits only" + "\n");
              }
          }
    </script>--%>
      <script src="<%= Page.ResolveUrl("~/js/jquery.min.js") %>"></script>
        <script src="<%= Page.ResolveUrl("~/js/jquery.actual.min.js") %>"></script>
          <script>
              $(document).ready(function () {
                  $('#lblerror').hide();
                  $('#lblvaliderror').hide();
                  $('#btnFinalRequest').click(function (event) {
                      if ($('#txtPhoneNo').val() != "") {
                          var re;
                          re = /^[0-9]+$/;
                          var digits = /\d(10)/;
                          if (re.test($('#txtPhoneNo').val())) {
                              $('#btnSendEmail').click();
                              return (true);
                          }
                          $('#lblvaliderror').show();
                          $('#lblerror').hide();
                          event.preventDefault();
                      }
                      else {
                          $('#lblerror').show();
                          $('#lblvaliderror').hide();
                          event.preventDefault();
                      }
                  });
              });
        </script>
</body>
</html>
<%--  <div style="text-align:center; background-color: white;width: 70%;margin-left: 208px; border:10px solid #f7f7f7; display:none">

  
	<div style="text-align:center">
    
    <div style="padding-bottom: 10px;">
    <button id="btnSkip" runat="server" type="submit" class="button green-gradient" style="width: 289px;height: 44px;font-size: 17px;">No Thanks, I'll Set It Up Manually</button>
    </div>
    <div>
    <button id="btnLiveChat" runat="server" type="submit" class="button green-gradient mid-margin-right" style="width: 289px;height: 44px;font-size: 17px;">Livechat With Us!</button>
    </div>
    </div>
                </div>--%>