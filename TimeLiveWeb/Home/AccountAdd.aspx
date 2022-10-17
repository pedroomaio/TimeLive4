    <%@ Page Language="VB" AutoEventWireup="false" CodeFile="AccountAdd.aspx.vb" Inherits="Home_AccountAdd" title="TimeLive - New Account" Theme="SkinFile"  %>
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc2" %>
    <!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Src="Controls/ctlProductsDetail.ascx" TagName="ctlProductsDetail" TagPrefix="uc5" %>
<%@ Register Src="Controls/ctlFullFeatureListIcon.ascx" TagName="ctlFullFeatureListIcon"
    TagPrefix="uc6" %>
<%@ Register Src="Controls/ctlOfferIcon.ascx" TagName="ctlOfferIcon" TagPrefix="uc7" %>


<%@ Register Src="Controls/ctlFeaturesIcon.ascx" TagName="ctlFeaturesIcon" TagPrefix="uc4" %>

<%@ Register Src="Controls/ctlFeatures.ascx" TagName="ctlFeatures" TagPrefix="uc3" %>

<%@ Register Src="Controls/ctlOffersl.ascx" TagName="ctlOffersl" TagPrefix="uc2" %>


<%@ Register Src="Controls/ctlaccountform.ascx" TagName="ctlaccountform" TagPrefix="uc1" %>
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
    width: 220px;
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
<html>
<head id="Head1" runat="server">
  <!-- Bootstrap framework -->
            <link rel="stylesheet" href="<%= Page.ResolveUrl("~/bootstrap/css/bootstrap.min.css") %>" />
            <link rel="stylesheet" href="<%= Page.ResolveUrl("~/bootstrap/css/bootstrap-responsive.min.css") %>" />
<%-- <link href="../Styles.css" rel="stylesheet" type="text/css" />--%>
 <link href="../SignupStyle/style.css" rel="stylesheet" type="text/css" />
<%--  <link href="../HDStyle/blue.css" rel="stylesheet" type="text/css" />--%>
       <link rel="stylesheet" href="../css/colors.css?v=1">
       <link rel="stylesheet" href="../css/style.css?v=1">
 	<!-- For all browsers -->
	<%--<link rel="stylesheet" href="../css/reset.css?v=1">
	<link rel="stylesheet" href="../css/style.css?v=1">
	<link rel="stylesheet" href="../css/colors.css?v=1">
	<link rel="stylesheet" media="print" href="../css/print.css?v=1">--%>
	<!-- For progressively larger displays -->
	<%--<link rel="stylesheet" media="only all and (min-width: 480px)" href="../css/480.css?v=1">--%>
	<link rel="stylesheet" media="only all and (min-width: 768px)" href="../css/768.css?v=1">
<%--	<link rel="stylesheet" media="only all and (min-width: 992px)" href="../css/992.css?v=1">
	<link rel="stylesheet" media="only all and (min-width: 1200px)" href="../css/1200.css?v=1">--%>
	<!-- For Retina displays -->
	<link rel="stylesheet" media="only all and (-webkit-min-device-pixel-ratio: 1.5), only screen and (-o-min-device-pixel-ratio: 3/2), only screen and (min-device-pixel-ratio: 1.5)" href="../css/2x.css?v=1">


	<!-- Additional styles -->
<%--	<link rel="stylesheet" href="../css/styles/form.css?v=1">
	<link rel="stylesheet" href="../css/styles/switches.css?v=1">
	<link rel="stylesheet" href="../css/styles/table.css?v=1">--%>
</head>
 <body class="login_page">
   <% If System.Configuration.ConfigurationManager.AppSettings("BugTracking") = "Yes" Then%>
    <div style="text-align:center;vertical-align:middle;padding-bottom:5px"><asp:Image ID="HI" runat="server"  Height="50px"  ImageUrl="~/Images/TrakLiveLogo.png" AlternateText="TimeLive Logo" /></div> 
    <% Else%>
    <div style="text-align:center;vertical-align:middle;padding-bottom:5px"><asp:Image ID="Image1" runat="server"  Height="50px"  ImageUrl="~/Images/TopHeader.png" AlternateText="TimeLive Logo" /></div>
    <% End If%>
		<div class="login_box" style="width:500px;border: 5px solid #F6F6F6;margin:0 auto">
			<form runat="server" id="reg_form" method="post">
         <cc2:ToolkitScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true"></cc2:ToolkitScriptManager>
					<div class="captionlogin" style="font-weight:bold" >Sign Up For Your TimeLive Account</div>
				<div style="border: 1px solid #d6dadf; background-color: #F6F6F6; vertical-align: middle;padding: 5px 5px 5px 5px;line-height: 20px;font-weight: normal;font-size:11px;" 
                    height="30px">
					By filling in the form bellow and clicking the "Sign Up" button, you accept and agree to <a target="_blank" style="cursor:pointer" href="http://www.livetecs.com/terms-of-use/">Terms of Service</a> & <a target="_blank" style="cursor:pointer" href="http://www.livetecs.com/privacy-policy/">Privacy Policy.</a>
				</div>
				<div class="cnt_b" style="margin:10px 20px;width:92%; padding:5px">  
                <%If UIUtilities.IsAspNetActiveDirectoryMembershipProvider Then%>
                	<div class="row-fluid">
										<div class="span6">
											<label style="font-weight:bold;color:#666">Username<a href="#" title="Please enter a valid username." class="tooltiplocal"><img title="" src="../Images/info.png" /></a></label>
											<input runat="server" type="text" name="txtADUsername" id="txtADUsername" class="span12" onchange="myfunctions();" />
                                            <input type="button" id="btnADUsername" runat="server" class="button green-gradient" style="display: none;" />
										</div>
<%--										<div class="span6">
											<label style="font-weight:bold;color:#666">Email Address</label>
											<input runat="server" type="text" name="txtADEmail" id="txtADEmail" class="span12" onblur="emailaddressChecker(this.value)"/>
										</div>--%>
								</div>   
               <%End If%>            
									<div class="row-fluid">
										<div class="span6">
											<label style="font-weight:bold;color:#666">First Name</label>
						                    <input runat="server" type="text" name="txtFirstName" id="txtFirstName" class="span12" />
										</div>
										<div class="span6">
											<label style="font-weight:bold;color:#666">Last Name</label>
											<input runat="server" type="text" name="txtLastName" id="txtLastName" class="span12" />
										</div>
								</div>                
              <div class="row-fluid">
										<div class="span6">
											<label style="font-weight:bold;color:#666">Company Name</label>
											 <input runat="server" type="text" id="txtCompanyName" name="txtCompanyName" class="span12" />
										</div>
										<div class="span6">
											<label style="font-weight:bold;color:#666">Phone no</label>
                                              <input runat="server" type="text" id="txtPhoneNo" name="txtPhoneNo" class="span12"/>
										</div>
								</div>    

                                <div class="row-fluid">
										<div class="span6" id="emailsection">
											<label style="font-weight:bold;color:#666">Email Address <a href="#" title="Please enter a valid email address as a welcome email will be sent to you." class="tooltiplocal"><img title="" src="../Images/info.png" /></a></label>
											<input runat="server" type="text" id="txtEmail" name="txtEmail" class="span12" onblur="emailaddressChecker(this.value)"/>
                                            <div id="emailvalidation"></div>
										</div>
										<div class="span6">
											<label style="font-weight:bold;color:#666">Password</label>
											<input runat="server" id="txtPassword" name="txtPassword" type="password" class="span12"/>
										</div>
								</div> 

                                <% If System.Configuration.ConfigurationManager.AppSettings("ApplicationMode") = "Hosted" Then %>
                                  <div class="row-fluid">
										<div class="span12" id="subdomainsection">
											<label style="font-weight:bold;color:#666">Choose Your TimeLive URL <a href="#" title="The subdomain you choose will determine the web address at which you and your team will log into your TimeLive account." class="tooltiplocal"><img title="" src="../Images/info.png" /></a></label>
                                             <asp:TextBox ID="txtSubDomain" runat="server" class="span6" onblur="subdomainChecker(this.value)"></asp:TextBox><span id="span3" style="font-size:11px;" runat="server">.livetecs.com</span>
                                            <cc2:FilteredTextBoxExtender ID="ftbe" runat="server" TargetControlID="txtSubDomain" FilterType="Numbers, LowercaseLetters, UppercaseLetters"/>
											<%--<input runat="server" type="text" id="subdomain" name="subdomain" class="span6" />.visbordesk.com--%>
                                            <div id="subdomainvalidation"></div>
										</div>
								</div>   
                                <%End if  %>     
                                
                                <input type="hidden" id="emailval" name="emailval" />
                                <input type="hidden" id="subdomainval" name="subdomainval" />
                                
                  
			    </div>
				<div id="test123" class="btm_b clearfix" style="text-align:right;padding:5px 17px 5px 5px;line-height: 20px;height:30px">
                 <%--<asp:Button ID="btnSignU12321p" runat="server" style="font-size:18px; width:100px; height:35px"  cssclass="btn pull-right btn-success" Text="Sign Up"/>--%>
                 <input type="submit" id="btnsignup" runat="server" class="button green-gradient" value="Sign Up"/>
                </div>
                
				

                <%--</ContentTemplate></asp:UpdatePanel>   --%>
			</form>
           
		</div>
      <div style="padding:4px"></div>
          <div class="links_b links_btm clearfix">
				<span id="span1" style="font-size:11px;" runat="server">TimeLive Powered By Livetecs LLC</span>				
			</div>
                <div class="links_b links_btm clearfix">
				<span id="span2" style="font-size:11px;" runat="server">Copyright 2007 - 2015 Livetecs LLC. All rights reserved.</span>				
			</div>
                                 
        <script src="<%= Page.ResolveUrl("~/js/jquery.min.js") %>"></script>
        <script src="<%= Page.ResolveUrl("~/js/jquery.actual.min.js") %>"></script>
        <script src="<%= Page.ResolveUrl("~/js/libs/validation/jquery.validate.min.js") %>"></script>
		<script src="<%= Page.ResolveUrl("~/bootstrap/js/bootstrap.min.js") %>"></script>
       
      <script type ="text/javascript">
          function subdomainChecker(subdomain) {

              //initiate the Ajax page method call
              //alert(username);
              var contextArray = subdomain;
              if (subdomain != "")
              PageMethods.IsSubDomainAvailable(subdomain, OnSucceeded, onError, contextArray);
          }
          function validateEmail(email) {
              var re = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
              return re.test(email);
          } 
          function emailaddressChecker(emailaddress) {

              //initiate the Ajax page method call
              //alert(username);
              var contextArray = emailaddress;
              if (emailaddress != "" && validateEmail(emailaddress))
              PageMethods.IsEmailAddressAvailable(emailaddress, OnSucceeded, onError, contextArray);
          }
          function OnSucceeded(result, userContext, methodName) {
              //alert(userContext);
              var lbl = document.getElementById("subdomainvalidation");
              if (methodName == "IsSubDomainAvailable") {
                  if (result == true) {
                      document.getElementById("subdomainsection").className = "span12 f_error";
                      lbl.innerHTML = "<label class='error'>" + userContext + ".livetecs.com is not available</label>";
                      document.getElementById("subdomainval").value = "true";
                  }
                  else {
                      document.getElementById("subdomainsection").className = "span12 f_success";
                      lbl.innerHTML = "<span style='display:block;font-size:11px;font-weight:700;color:DarkGreen'>" + userContext + ".livetecs.com is available</span>";
                      //document.getElementById("btnSignUp").disabled = false;
                      document.getElementById("subdomainval").value = "false";
                  }
              }
              var lbl = document.getElementById("emailvalidation");
              if (methodName == "IsEmailAddressAvailable") {
                  if (result == true) {
                      //lbl.innerHTML = "<span style='color: Red;font-size: 11px;font-weight: bold;'>Specified email already exist</span>";
                      document.getElementById("emailsection").className = "span6 f_error";
                      //d.className = d.className + " f_error";
                      lbl.innerHTML = "<label class='error'>Specified email already exist.</label>";
                      document.getElementById("emailval").value = "true";
                  }
                  else {
                      document.getElementById("emailsection").className = "span6 f_success";
                      lbl.innerHTML = "<label span style='display:block;font-size:11px;font-weight:700;color:DarkGreen''>email is available.</label>";
                      document.getElementById("emailval").value = "false";
                  }
              }
          }
          function onError(results, currentContext, methodName) {
              //alert(results);
          }
          function ValidateOnButton() {
              if (document.getElementById("emailval").value == true) {
                  return (true);
              } else {
                  return (false);
              }
          }
    </script> 
     <script>
            $(document).ready(function () {

                //* validation
                $('#reg_form').validate({
                    onkeyup: false,
                    errorClass: 'error',
                    validClass: 'valid',
                    rules: {
                    txtFirstName: { required: true },
                    txtLastName: { required: true },
                    txtEmail: { required: true, email: true },
                    txtCompanyName: { required: true },
                    txtSubDomain: { required: true },
                    txtPassword: { required: true },
                    txtADEmail: { required: true },
                    txtADUsername: { required: true },
                    },
                    highlight: function (element) {
                        $(element).closest('div').addClass("f_error");
                    },
                    unhighlight: function (element) {
                        $(element).closest('div').removeClass("f_error");
                    },
                    errorPlacement: function (error, element) {
                        $(element).closest('div').append(error);
                    }
                });
//                 $('#test123').on({
//            click: function (e) {

//            if( $('#emailval').val() == "true"){
//                 e.preventDefault();
//                    $('#emailval').attr('onclick','').unbind('click');
//               alert("test");
//               return false;
//               }
//            }
//        }, '#btnsignup');
$('#btnsignup').click(function(event){
if( $('#emailval').val() == "true"){
event.preventDefault();
}
if( $('#subdomainval').val() == "true"){
event.preventDefault();
}
});
            });
        </script>

<script>
    function myfunctions() {
        var clickButton = document.getElementById("<%= btnADUsername.ClientID %>");
    clickButton.click();
}
</script>    

    </body>
</html>
 

