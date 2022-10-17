<%@ Page Language="VB" AutoEventWireup="false" title="TimeLive - Time Entry Week View Read-only" CodeFile="AccountEmployeeTimeEntryWeekViewReadOnly.aspx.vb" Inherits="Employee_AccountEmployeeTimeEntryWeekViewReadOnly" Theme="SkinFile"%>

<%@ Register Src="Controls/ctlAccountEmployeeTimeEntryWeekViewDescriptionReadOnly.ascx"
    TagName="ctlAccountEmployeeTimeEntryWeekViewDescriptionReadOnly" TagPrefix="uc2" %>

<%@ Register Src="Controls/ctlAccountEmployeeTimeEntryWeekViewReadOnly.ascx" TagName="ctlAccountEmployeeTimeEntryWeekViewReadOnly"
    TagPrefix="uc1" %>
<%@ Register Assembly="eWorld.UI"
    Namespace="eWorld.UI" TagPrefix="ew" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <link href="../Styles.css" rel="stylesheet" type="text/css" />

    <link rel="stylesheet" href="../js/libs/tooltipster-master/dist/css/tooltipster.bundle.min.css" />
    <link rel="stylesheet" href="../js/libs/tooltipster-master/dist/css/plugins/tooltipster/sideTip/themes/tooltipster-sideTip-shadow.min.css" />
    <style type="text/css">
        
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
        <table class="xFormView" width="99%">
            <tr>
                <td align="left" >
                    &nbsp; &nbsp;
                    <asp:Image ID="imgCompanyLogo" runat="server" Height="50px" /></td>
            </tr>
        <%If Me.Request.QueryString("IsPrint") <> "True" Then%>
        <%  If LocaleUtilitiesBLL.ShowAllInTimesheetReadOnly = True Then %>
            <tr>
                <td align="left" >
                    &nbsp; &nbsp;
                    <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="True" Text="<%$ Resources:TimeLive.Resource, Show All%> " Font-Bold="True" /></td>
            </tr>
           
        <%End If %>
        <%End If %>
         <tr>
                <td align="center" >
        <uc1:ctlAccountEmployeeTimeEntryWeekViewReadOnly ID="CtlAccountEmployeeTimeEntryWeekViewReadOnly1"
            runat="server" />
                </td>
            </tr>
            <tr>
                <td align="left" >
                    <br />
        <uc2:ctlAccountEmployeeTimeEntryWeekViewDescriptionReadOnly ID="CtlAccountEmployeeTimeEntryWeekViewDescriptionReadOnly1"
            runat="server" />
                </td>
            </tr>
        </table>
    </div>
    <ew:calendarpopup id="txtTimeEntryDate" runat="server" SkinId="DatePicker" UpperBoundDate="2010-11-13" Width="104px" Visible="False"></ew:calendarpopup>
    </form>
</body>
</html>
