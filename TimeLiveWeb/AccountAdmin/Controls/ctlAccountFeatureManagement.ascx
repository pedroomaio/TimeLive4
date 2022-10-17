<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlAccountFeatureManagement.ascx.vb" Inherits="AccountAdmin_Controls_ctlAccountFeatureManagement" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>      
<style type="text/css">
    input.largerCheckbox
        {
	        width: 20px;
	        height: 20px;	
        }
        .captionlogin {color: white;background: #00438d url(../img/old-browsers/colors/bg_button-icon.png) repeat-x;-webkit-background-size: 100% 100%;-moz-background-size: 100% 100%;-o-background-size: 100% 100%;-webkit-box-shadow: inset 0 1px 0 rgba(255, 255, 255, 0.35);-moz-box-shadow: inset 0 1px 0 rgba(255, 255, 255, 0.35);background-size: 100% 100%;background: -webkit-gradient(linear, left top, left bottom, from(#006aac), to(#00438d));background: -webkit-linear-gradient(top, #006aac, #00438d);background: -moz-linear-gradient(top, #006aac, #00438d);background: -ms-linear-gradient(top, #006aac, #00438d);background: -o-linear-gradient(top, #006aac, #00438d);	background: linear-gradient(top, #006aac, #00438d);	border-color: #004795;	box-shadow: inset 0 1px 0 rgba(255, 255, 255, 0.35);	margin: 0;	padding: 18px 16px;	font-size:medium;	font-weight:lighter;	text-align:left;}
</style>

<table width=98% class="captionlogin">
    <tr style="vertical-align:middle;height:50px;">
    <td style="width:100%;border:1px solid #d6dadf;line-height:25px;vertical-align:middle;padding:0px 5px 0px 5px;">
        Feature Management
        </td></tr>
        </table>
    <%--style="border:1px solid #d6dadf"--%>
    <%--Feature Selection Table--%>
    <table width="98%" border="0" align="center" cellpadding="5px" cellspacing="5px">
            <tr style="vertical-align:middle;height:35px;background-color:#d6dadf">
            <td colspan=2 style="width:35%;border:1px solid #d6dadf;line-height:25px;vertical-align:middle;padding:0px 5px 0px 5px;text-align:center;">
                <span style="color:#006d8d;font-size:13px;font-weight:bold;">Feature</span>
            </td>        
            <td style="width:60%;border:1px solid #d6dadf;line-height:25px;vertical-align:middle;padding:0px 5px 0px 5px;text-align:center;">
                <span style="color:#006d8d;font-size:13px;font-weight:bold;">Description</span>
            </td>          
            <td style="width:5%;text-align:center;border:1px solid #d6dadf;vertical-align:middle;padding:0px 5px 0px 5px;">                        
            </td>        
        </tr>

    <%--Timesheet Management Feature Row--%>
        <tr style="vertical-align:middle;height:60px;background-color:#F6F6F6">
            <td style="width:5%;text-align:center;border:1px solid #d6dadf;vertical-align:middle;padding:0px 5px 0px 5px;">        
              <img src="../img/timesheetnew.png"/>
            </td>        
            <td style="width:30%;border:1px solid #d6dadf;line-height:25px;vertical-align:middle;padding:0px 5px 0px 5px;">
                <span style="color:#006d8d;font-size:20px;">Time Tracking</span>
            </td>        
            <td style="width:60%;border:1px solid #d6dadf;vertical-align:middle;padding:0px 5px 0px 5px;">        
                <span style="font-size:11px">Manage & track your employees & contractors time with easy to use options which includes Daily/Weekly/Monthly/Semi-Monthly Timesheet, customizable Multi-Level Approval Path, Email Notifications & Reminders, Validations for Minimum/Maximum hours input, Audit Trial, Automatic Timer & various different reports etc.</span>
            </td>        
            <td style="width:5%;text-align:center;border:1px solid #d6dadf;vertical-align:middle;padding:0px 5px 0px 5px;">        
                <input id="chkTimesheet" runat="server" type="checkbox" class="largerCheckbox" name="checkBox" />
            </td>        
        </tr>
    <%--Expense Management Feature Row--%>
       <tr style="vertical-align:middle;height:60px;background-color:#F6F6F6">
                   <td style="width:5%;text-align:center;border:1px solid #d6dadf;vertical-align:middle;padding:0px 5px 0px 5px;">        
                <img src="../img/expense.png"/>
            </td>        
            <td style="width:30%;border:1px solid #d6dadf;line-height:25px;vertical-align:middle;padding:0px 5px 0px 5px;">
                <span style="color:#006d8d;font-size:20px;">Expense Tracking</span>
            </td>        
            <td style="width:60%;border:1px solid #d6dadf;vertical-align:middle;padding:0px 5px 0px 5px;">        
                <span style="font-size:11px">Manage expense with easy to use Expense Sheet entry option with variety of different options available which includes customizable Multi-Level Approval Path, Email Notifications & Reminders, Validations, Reimbursement, Multi Currency, Billable/Non-Billable Expenses, Attachments & various different reports etc.</span>
            </td>        
            <td style="width:5%;text-align:center;border:1px solid #d6dadf;vertical-align:middle;padding:0px 5px 0px 5px;">        
                <input id="chkExpense" runat="server" type="checkbox" class="largerCheckbox" name="checkBox" />
            </td>        
        </tr>
            <%--TimeOff Management Feature Row--%>
       <tr style="vertical-align:middle;height:60px;background-color:#F6F6F6">
                   <td style="width:5%;text-align:center;border:1px solid #d6dadf;vertical-align:middle;padding:0px 5px 0px 5px;">        
                <img src="../img/timeoffnew.png"/>
            </td>        
            <td style="width:30%;border:1px solid #d6dadf;line-height:25px;vertical-align:middle;padding:0px 5px 0px 5px;">
                <span style="color:#006d8d;font-size:20px;">Time-Off Tracking</span>
            </td>        
            <td style="width:60%;border:1px solid #d6dadf;vertical-align:middle;padding:0px 5px 0px 5px;">        
                <span style="font-size:11px">Manage your leave balances and accruals by setting-up the Time-Off policies with different options which includes customizable Multi-Level Approval Path, Email Notifications & Reminders, Validations, & various different reports  etc.</span>
            </td>        
            <td style="width:5%;text-align:center;border:1px solid #d6dadf;vertical-align:middle;padding:0px 5px 0px 5px;">        
                <input id="chkTimeOff" runat="server" type="checkbox" class="largerCheckbox" name="checkBox" />
            </td>        
        </tr>
        <%--Billing Management Feature Row--%>
       <tr style="vertical-align:middle;height:60px;background-color:#F6F6F6">
                   <td style="width:5%;text-align:center;border:1px solid #d6dadf;vertical-align:middle;padding:0px 5px 0px 5px;">        
                <img src="../img/billing.png"/>
            </td>        
            <td style="width:30%;border:1px solid #d6dadf;line-height:25px;vertical-align:middle;padding:0px 5px 0px 5px;">
                <span style="color:#006d8d;font-size:20px;">Billing & Invoicing</span>
            </td>        
            <td style="width:60%;border:1px solid #d6dadf;vertical-align:middle;padding:0px 5px 0px 5px;">        
                <span style="font-size:11px">Generate Invoices against your clients for unbilled time & expense entries with different option includes Project / Task / Employee / Project Roles based billing rates with history, custom Logos & Footers, Billed/Unbilled log, customizable multiple taxes with formulas & various different reports etc.</span>
            </td>        
            <td style="width:5%;text-align:center;border:1px solid #d6dadf;vertical-align:middle;padding:0px 5px 0px 5px;">        
                <input id="chkBilling" runat="server" type="checkbox" class="largerCheckbox" name="checkBox" />
            </td>        
        </tr>
                    <%--Project Management Feature Row--%>
       <tr style="vertical-align:middle;height:60px;background-color:#F6F6F6">
                   <td style="width:5%;text-align:center;border:1px solid #d6dadf;vertical-align:middle;padding:0px 5px 0px 5px;">        
                <img src="../img/project.png"/>
            </td>        
            <td style="width:30%;border:1px solid #d6dadf;line-height:25px;vertical-align:middle;padding:0px 5px 0px 5px;">
                <span style="color:#006d8d;font-size:20px;">Project Management</span>
            </td>        
            <td style="width:60%;border:1px solid #d6dadf;vertical-align:middle;padding:0px 5px 0px 5px;">        
                <span style="font-size:11px">Manage your Projects with variety of useful options which includes multi-level Parent / Child Task hierarchy, Milestones, Gantt Chart, Email Notifications & Reminders, Estimations & Budgets, Project & Task Costing & various useful reports for analysis.</span>
            </td>        
            <td style="width:5%;text-align:center;border:1px solid #d6dadf;vertical-align:middle;padding:0px 5px 0px 5px;">        
                <input id="chkProject" runat="server" type="checkbox" class="largerCheckbox" name="checkBox" />
            </td>        
        </tr>
         <%--Attendance Management Feature Row--%>
       <tr style="vertical-align:middle;height:60px;background-color:#F6F6F6">
                   <td style="width:5%;text-align:center;border:1px solid #d6dadf;vertical-align:middle;padding:0px 5px 0px 5px;">        
                <img src="../img/attendance.png"/>
            </td>        
            <td style="width:30%;border:1px solid #d6dadf;line-height:25px;vertical-align:middle;padding:0px 5px 0px 5px;">
                <span style="color:#006d8d;font-size:20px;">Attendance Management</span>
            </td>        
            <td style="width:60%;border:1px solid #d6dadf;vertical-align:middle;padding:0px 5px 0px 5px;">        
                <span style="font-size:11px">Manage your employee’s attendance with simple to use In / Out entry with different reports available for reporting.</span>
            </td>        
            <td style="width:5%;text-align:center;border:1px solid #d6dadf;vertical-align:middle;padding:0px 5px 0px 5px;">        
                <input id="chkAttendance" runat="server" type="checkbox" class="largerCheckbox" name="checkBox" />
            </td>        
        </tr>
    </table>    
        <table width="98%" align="center" style="height:75px;" cellpadding="5px" cellspacing="5px">
        <tr style="vertical-align:middle;background-color:#d6dadf;">
            <td style="width:90%;font-size:20px;line-height:25px;vertical-align:middle;padding:0px 5px 0px 5px;">
                
            </td>        
            <td style="vertical-align:middle;width:10%;text-align:right;padding:0px 5px 0px 5px;">   
                <input type="submit" id="btnST" runat="server" class="button blue-gradient" value="Update" style="margin-bottom:0px;height:40px;font-size:14px" />  
            </td>        
        </tr>
    </table>  
    </ContentTemplate>
</asp:UpdatePanel>
