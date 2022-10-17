<%@ Page Language="VB"  AutoEventWireup="false" CodeFile="RegistrationComplete.aspx.vb" Inherits="Home_RegistrationComplete" title="Account Created Successfully"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
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
    <style type="text/css">
<!--
input.largerCheckbox
{
	width: 20px;
	height: 20px;	
}

//-->
</style>
</head>
<body>
    <form id="form1" runat="server">
    <table width="98%" align="center" style="height:50px" cellpadding="5px" cellspacing="5px">
        <tr style="vertical-align:middle;">
            <td style="width:100%;font-size:20px;">
            <asp:Image ID="HI" runat="server"  Height="50px"  ImageUrl="~/Images/TopHeader.png" AlternateText="TimeLive Logo" />
        </td>
        </tr>
    </table>
    <table width="98%" align="center" style="margin-top:15px" cellpadding="5px" cellspacing="5px">
        <tr style="vertical-align:middle;">
            <td style="width:100%;line-height:25px;">
                <span style="color:#006d8d;font-size:25px;">Thank you! Your TimeLive 30 Days free trial is live and ready to go.</span>
            </td>
        </tr>
    </table>
    <table width="98%" align="center" style="margin-top:15px" cellpadding="5px" cellspacing="5px">
        <tr style="vertical-align:middle;">
            <td style="width:100%;line-height:25px;">
                <span style="color:#666666;font-size:20px;">A web based software for tracking Time & Expense with Billing & Project Management feature.</span>
            </td>
        </tr>
    </table>
<%--    <table width="75%" align="center" style="margin-top:20px" cellpadding="5px" cellspacing="5px">
            <tr style="vertical-align:middle;">
            <td style="width:100%;">
                <span style="font-size:18px">Be sure to remember your login credentials</span>
            </td>
        </tr>
        <tr style="vertical-align:middle;">
            <td style="width:100%;">
                <span style="font-size:18px;">Company ID:</span><span> Test Company</span><span style="font-size:18px;"> User ID:</span><span> arsalangodil@livetecs.com</span>
            </td>
        </tr>
    </table>--%>
    <table width="98%" align="center" style="height:75px;margin-top:15px;" cellpadding="5px" cellspacing="5px">
        <tr style="vertical-align:middle;background-color:#d6dadf;">
            <td style="width:90%;font-size:20px;line-height:25px">
                <span style="color:#006d8d">Select the features to evaluate. This selection can be changed later.</span>
            </td>        
            <td style="vertical-align:middle;width:10%;text-align:right;">   
                <input type="submit" id="btnST" runat="server" class="button green-gradient" value="Start Trial" style="margin-bottom:0px;height:40px;font-size:14px" />  
            </td>        
        </tr>
    </table>
    <%--style="border:1px solid #d6dadf"--%>
    <%--Feature Selection Table--%>
    <table width="98%" border="0" align="center" cellpadding="5px" cellspacing="5px">
    <%--Timesheet Management Feature Row--%>
        <tr style="vertical-align:middle;height:60px;background-color:#F6F6F6">
                    <td style="width:5%;text-align:center;border:1px solid #d6dadf">        
              <img src="../img/timesheetnew.png"/>
            </td>        
            <td style="width:30%;border:1px solid #d6dadf;line-height:25px">
                <span style="color:#006d8d;font-size:20px;">Time Tracking</span>
            </td>        
            <td style="width:60%;border:1px solid #d6dadf">        
                <span style="font-size:11px">Manage & track your employees & contractors time with easy to use options which includes Daily/Weekly/Monthly/Semi-Monthly Timesheet, customizable Multi-Level Approval Path, Email Notifications & Reminders, Validations for Minimum/Maximum hours input, Audit Trial, Automatic Timer & various different reports etc.</span>
            </td>        
            <td style="width:5%;text-align:center;border:1px solid #d6dadf">        
                <input id="chkTimesheet" runat="server" type="checkbox" class="largerCheckbox" name="checkBox" />
            </td>        
        </tr>
    <%--Expense Management Feature Row--%>
       <tr style="vertical-align:middle;height:60px;background-color:#F6F6F6">
                   <td style="width:5%;text-align:center;border:1px solid #d6dadf">        
                <img src="../img/expense.png"/>
            </td>        
            <td style="width:30%;border:1px solid #d6dadf;line-height:25px">
                <span style="color:#006d8d;font-size:20px;">Expense Tracking</span>
            </td>        
            <td style="width:60%;border:1px solid #d6dadf">        
                <span style="font-size:11px">Manage expense with easy to use Expense Sheet entry option with variety of different options available which includes customizable Multi-Level Approval Path, Email Notifications & Reminders, Validations, Reimbursement, Multi Currency, Billable/Non-Billable Expenses, Attachments & various different reports etc.</span>
            </td>        
            <td style="width:5%;text-align:center;border:1px solid #d6dadf">        
                <input id="chkExpense" runat="server" type="checkbox" class="largerCheckbox" name="checkBox" />
            </td>        
        </tr>
            <%--TimeOff Management Feature Row--%>
       <tr style="vertical-align:middle;height:60px;background-color:#F6F6F6">
                   <td style="width:5%;text-align:center;border:1px solid #d6dadf">        
                <img src="../img/timeoffnew.png"/>
            </td>        
            <td style="width:30%;border:1px solid #d6dadf;line-height:25px">
                <span style="color:#006d8d;font-size:20px;">Time-Off Tracking</span>
            </td>        
            <td style="width:60%;border:1px solid #d6dadf">        
                <span style="font-size:11px">Manage your leave balances and accruals by setting-up the Time-Off policies with different options which includes customizable Multi-Level Approval Path, Email Notifications & Reminders, Validations, & various different reports  etc.</span>
            </td>        
            <td style="width:5%;text-align:center;border:1px solid #d6dadf">        
                <input id="chkTimeOff" runat="server" type="checkbox" class="largerCheckbox" name="checkBox" />
            </td>        
        </tr>
        <%--Billing Management Feature Row--%>
       <tr style="vertical-align:middle;height:60px;background-color:#F6F6F6">
                   <td style="width:5%;text-align:center;border:1px solid #d6dadf">        
                <img src="../img/billing.png"/>
            </td>        
            <td style="width:30%;border:1px solid #d6dadf;line-height:25px">
                <span style="color:#006d8d;font-size:20px;">Billing & Invoicing</span>
            </td>        
            <td style="width:60%;border:1px solid #d6dadf">        
                <span style="font-size:11px">Generate Invoices against your clients for unbilled time & expense entries with different option includes Project / Task / Employee / Project Roles based billing rates with history, custom Logos & Footers, Billed/Unbilled log, customizable multiple taxes with formulas & various different reports etc.</span>
            </td>        
            <td style="width:5%;text-align:center;border:1px solid #d6dadf">        
                <input id="chkBilling" runat="server" type="checkbox" class="largerCheckbox" name="checkBox" />
            </td>        
        </tr>
                    <%--Project Management Feature Row--%>
       <tr style="vertical-align:middle;height:60px;background-color:#F6F6F6">
                   <td style="width:5%;text-align:center;border:1px solid #d6dadf">        
                <img src="../img/project.png"/>
            </td>        
            <td style="width:30%;border:1px solid #d6dadf;line-height:25px">
                <span style="color:#006d8d;font-size:20px;">Project Management</span>
            </td>        
            <td style="width:60%;border:1px solid #d6dadf">        
                <span style="font-size:11px">Manage your Projects with variety of useful options which includes multi-level Parent / Child Task hierarchy, Milestones, Gantt Chart, Email Notifications & Reminders, Estimations & Budgets, Project & Task Costing & various useful reports for analysis.</span>
            </td>        
            <td style="width:5%;text-align:center;border:1px solid #d6dadf">        
                <input id="chkProject" runat="server" type="checkbox" class="largerCheckbox" name="checkBox" />
            </td>        
        </tr>
         <%--Attendance Management Feature Row--%>
       <tr style="vertical-align:middle;height:60px;background-color:#F6F6F6">
                   <td style="width:5%;text-align:center;border:1px solid #d6dadf">        
                <img src="../img/attendance.png"/>
            </td>        
            <td style="width:30%;border:1px solid #d6dadf;line-height:25px">
                <span style="color:#006d8d;font-size:20px;">Attendance Management</span>
            </td>        
            <td style="width:60%;border:1px solid #d6dadf">        
                <span style="font-size:11px">Manage your employee’s attendance with simple to use In / Out entry with different reports available for reporting.</span>
            </td>        
            <td style="width:5%;text-align:center;border:1px solid #d6dadf">        
                <input id="chkAttendance" runat="server" type="checkbox" class="largerCheckbox" name="checkBox" />
            </td>        
        </tr>

    </table>

    </form>
</body>
</html>
