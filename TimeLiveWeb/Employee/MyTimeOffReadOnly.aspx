<%@ Page Language="VB" AutoEventWireup="false" CodeFile="MyTimeOffReadOnly.aspx.vb" Inherits="Employee_MyTimeOffReadOnly" Title ="TimeOff Read Only"  %>

<%@ Register Src="Controls/ctlMyTimeOffReadOnly.ascx" TagName="ctlMyTimeOffReadOnly" TagPrefix="uc1" %>

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
<body>
     <uc1:ctlMyTimeOffReadOnly ID="ctlMyTimeOffReadOnly1" runat="server" />
</body>
