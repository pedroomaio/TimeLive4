<%@ Page Language="VB" MasterPageFile="~/Masters/MasterPageEmployee.master" AutoEventWireup="false"
    CodeFile="MyTimeOff.aspx.vb" Inherits="Employee_MyTimeOff" Title="TimeLive - My Time Off" %>

<%@ Register Src="Controls/ctlMyTimeOff.ascx" TagName="ctlMyTimeOff" TagPrefix="uc1" %>
<asp:Content ID="phCustomHeaderStylesAndScripts" ContentPlaceHolderID="phCustomHeaderStylesAndScripts" runat="server">
    <style type="text/css">
        .xGridView .row:before, .row:after
        {
            display: none;
        }
        
        .calendar table.month tr td .day-content
        {
            border-radius: 0px !important;
        }
        
        div[id$="StartDateTextBox_calendar"]
        {
            top: 140px !important;
            left: 280px !important;
        }
        div[id$="EndDateTextBox_calendar"]
        {
            top: 170px !important;
            left: 280px !important;
        }
        
        span[class$="DateTextBox"] input[id$="textBox"]
        {
            width: 100px !important;
        }
        #open-menu > span { height:29px; width:78.59px;}

        #open-menu4 > span {height:29px; width:123px;}
        .underLine-Approved{
            box-shadow : #6CCF3A 0px -4px 0px 0px inset;
        }
        .underLine-Reject{
            box-shadow : #FF4A19 0px -4px 0px 0px inset;
        }
        .underLine-Requested{
            box-shadow : #2AAAFF 0px -4px 0px 0px inset;
        }
        .underLine-Saved{
            box-shadow : Gold 0px -4px 0px 0px inset;
        }
        
    </style>
    <link href="../Content/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../Content/bootstrap-datepicker.min.css" rel="stylesheet" type="text/css" />
    <link href="../Content/bootstrap-theme.min.css" rel="stylesheet" type="text/css" />
    <link href="../Content/bootstrap-year-calendar.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../css/reset.css" type="text/css">
    <script src="../js/libs/bootstrap/jquery-1.9.1.min.js" type="text/javascript"></script>
    <script src="../js/libs/bootstrap/bootstrap.min.js" type="text/javascript"></script>
    <script src="../js/libs/bootstrap-datepicker/bootstrap-datepicker.min.js" type="text/javascript"></script>
    <script src="../js/libs/bootstrap-year-calendar/bootstrap-year-calendar.js" type="text/javascript"></script>
    <script src="../js/libs/bootstrap/bootstrap-popover.js" type="text/javascript"></script>

    <script src="../js/libs/jsPDF/jspdf.min.js" type="text/javascript"></script>
    <script src="../js/libs/jsPDF/html2canvas.js" type="text/javascript"></script>

</asp:Content>
<asp:Content  ID="C" ContentPlaceHolderID="C" runat="Server">
    <uc1:ctlMyTimeOff ID="CtlMyTimeOff1" runat="server" />
</asp:Content>
<asp:Content ID="phCustomFooterStylesAndScripts" ContentPlaceHolderID="phCustomFooterStylesAndScripts"
    runat="server">
    <script src="../js/setup.js"></script>
</asp:Content>
