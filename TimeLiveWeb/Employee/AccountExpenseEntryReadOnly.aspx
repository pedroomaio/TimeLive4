<%@ Page Language="VB" AutoEventWireup="false" Title="TimeLive - Expense Entry Read-only"
    CodeFile="AccountExpenseEntryReadOnly.aspx.vb" Inherits="Employee_AccountExpenseEntryReadOnly"
    Theme="SkinFile" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Src="Controls/ctlAccountExpenseEntryReadOnly.ascx" TagName="ctlAccountExpenseEntryReadOnly"
    TagPrefix="uc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../Styles.css" rel="stylesheet" type="text/css" />
    <!-- Additional styles -->
    <link rel="stylesheet" href="../css/styles/form.css?v=1">
    <link rel="stylesheet" href="../css/styles/switches.css?v=1">
    <link rel="stylesheet" href="../css/styles/table.css?v=1">
    <%--<link rel="stylesheet" href="https://ajax.googleapis.com/ajax/libs/jqueryui/1.12.1/themes/smoothness/jquery-ui.css">--%>
    <link rel="stylesheet" href="../js/libs/tooltipster-master/dist/css/tooltipster.bundle.min.css" />
    <link rel="stylesheet" href="../js/libs/tooltipster-master/dist/css/plugins/tooltipster/sideTip/themes/tooltipster-sideTip-shadow.min.css" />
    <style type="text/css">
        #UpdatePanel1
        {
            width: 200px;
            height: 100px;
            border: 1px solid gray;
        }
        #UpdateProgress1
        {
            width: 200px;
            background-color: #FFC080;
            bottom: 0%;
            left: 0px;
            position: absolute;
        }
        .tooltip_templates
        {
            display: none;
        }
        .imgTooltip
        {
            max-width: 100%;
            height: auto;
            width: auto\9; /* ie8 */
        }
    </style>
    <script src="<%= Page.ResolveUrl("~/js/jquery.min.js") %>"></script>
    <script src="<%= Page.ResolveUrl("~/js/jquery.actual.min.js") %>"></script>
    <script src="<%= Page.ResolveUrl("~/js/libs/validation/jquery.validate.min.js") %>"></script>
    <script src="<%= Page.ResolveUrl("~/bootstrap/js/bootstrap.min.js") %>"></script>
    <script src="../js/developr.scroll.js"></script>
    <%--<script src="https://ajax.googleapis.com/ajax/libs/jqueryui/1.12.1/jquery-ui.min.js"></script>--%>
    <script src="<%= Page.ResolveUrl("~/js/libs/tooltipster-master/dist/js/tooltipster.bundle.min.js") %>"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('.tooltip').tooltipster({
                contentCloning: true,
                theme: 'tooltipster-shadow',
                trigger: 'custom',
                triggerOpen: {
                    mouseenter: true,
                    touchstart: true
                },
                triggerClose: {
                    mouseleave: false,
                    click: true,
                    scroll: false,
                    tap: true
                },
                functionBefore: function (instance, helper) {
                    var instances = $.tooltipster.instances();
                    $.each(instances, function (i, instance) {
                        instance.close();
                    });
                },
                maxWidth: $(window).width(),
                maxHeight: $(window).height(),
                side: ['left']
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <uc1:ctlAccountExpenseEntryReadOnly ID="CtlAccountExpenseEntryReadOnly2" runat="server" />
    </div>
    </form>
</body>
</html>
