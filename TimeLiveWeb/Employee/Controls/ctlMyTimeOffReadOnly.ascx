<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlMyTimeOffReadOnly.ascx.vb" Inherits="Employee_Controls_ctlMyTimeOffReadOnly" %>


<script type="text/javascript">
    var holidays = [
        <%
    Dim dtHolidays As AccountHolidayType.vueAccountEmployeeHolidayTypesWithDetailDataTable = New AccountHolidayTypeBLL().GetvueAccountEmployeeHolidayTypesWithDetailByAccountEmployeeId(DBUtilities.GetSessionAccountEmployeeId)
    For Each drHoliday In dtHolidays %>
        { date: newDate('<%= DirectCast(drHoliday("HolidayDate"), DateTime).ToString("yyyy-MM-dd") %>'), name: '<%= drHoliday("HolidayName") %>' },
        <% Next %>
    ];

    var dataSource = [
        <%
    Dim items = dsEmployeeTimeOffRequestGridViewObject.Select()
    For Each item As DataRowView In items
        Dim row = DirectCast(item.Row, AccountEmployeeTimeOffRequest.vueAccountEmployeeTimeOffRequestRow)
        If row("AccountEmployeeId") <> 0 Then%>
            {
                accountEmployeeTimeOffRequestId: '<%= row("AccountEmployeeTimeOffRequestId") %>',
                accountTimeOffTypeId: '<%= row("AccountTimeOffTypeId") %>',
                accountTimeOffType: '<%= row("AccountTimeOffType") %>',
                startDate: newDate('<%= DirectCast(row("StartDate"), DateTime).ToString("yyyy-MM-dd") %>'),
                endDate: newDate('<%= DirectCast(row("EndDate"), DateTime).ToString("yyyy-MM-dd") %>'),
                status: '<%= row("ApprovalStatus") %>',
                color: '<%= row("Color")%>',
                statusColor: getStatusColor('<%= row("ApprovalStatus") %>'),
                name: '<%= row("AccountTimeOffType") %>',
                scheduleWeekends: <%= DirectCast(row("ScheduleWeekends"), Boolean).ToString().ToLower() %>,
                projectId: '<%= row("AccountProjectId")%>',
                description:'<%= row("Description")%>'
            },
            <% SetCalendarStartYear(DirectCast(row("StartDate"), DateTime).Year) %>
        <% End If
            Next %>
        ];
    var calendar;
    $(function () {
        var currentYear = new Date().getFullYear();

       calendar = $('#calendar').calendar({
            allowOverlap: false,
            enableContextMenu: true,
            enableRangeSelection: true,
            minDate: new Date(currentYear-<%= GetCalendarStartYear() %>, 0, 1),
            maxDate: new Date(currentYear+1, 11, 31),
            style: "background",
            dataSource: dataSource,
            customDayRenderer: function(element, date) {
                
                if (date.getDay() == 6 || date.getDay() == 0) {
                    $(element).css('background', '#C0C0C0');
                } 
                $.each(this.dataSource, function(index, value) {
                    if (value.startDate <= date && value.endDate >= date) {
                        if ((date.getDay() == 6 || date.getDay() == 0) && !value.scheduleWeekends) {
                            (element).css('background', '#C0C0C0');
                        }
                        else {
                            $(element).css('box-shadow', value.statusColor + ' 0px -4px 0px 0px inset');
                            $(element).css('background', value.color);
                            $(element).val(value.scheduleWeekends) 
                        }                            
                    }
                });

                $.each(holidays, function(index, value) {
                    if (value.date.getTime() === date.getTime() && $(element).val() !== true) {
                        $(element).css('background', '#dee5ef');
                        $(element).css('box-shadow','none');
                    }
                });
            },
           
            mouseOnDay: function (e) {
                var content = '';
                if (e.events.length > 0) {
                    for (var i in e.events) {
                        
                        content += '<div class="event-tooltip-content">'
                            + '<div class="event-name" style="color:' + e.events[i].color + '">' + e.events[i].accountTimeOffType + '</div>'
                            + '<div class="event-status" style="color:' + e.events[i].statusColor + '">' + e.events[i].status + '</div>'
                        + '</div>';
                         
                        $.each(holidays, function(index, value) {
                            if (value.date.getTime() === e.date.getTime() ) {
                                content = '<div class="event-tooltip-content">'
                                            + '<div class="event-name" style="color:#006aac" ><center><b>Holiday</b><center></div>'
                                            + '<div class="event-status" >' + value.name + '</div>'
                                        + '</div>';
                            }});
                        showPopHover(e.element,content)
                    }
                   
                }else{
                     $.each(holidays, function(index, value) {
                         if (value.date.getTime() === e.date.getTime()) {
                             content += '<div class="event-tooltip-content">'
                                         + '<div class="event-name" style="color:#006aac" ><center><b>Holiday</b><center></div>'
                                         + '<div class="event-status" >' + value.name + '</div>'
                                     + '</div>';
                             showPopHover(e.element,content)
                         }
                    });
                }
            },
            mouseOutDay: function (e) {
                if (e.events.length > 0) {
                    $(e.element).popover('hide');
                }else{
                    $.each(holidays, function(index, value) {
                        if (value.date.getTime() === e.date.getTime()) {
                            $(e.element).popover('hide');
                        }
                    });
                }
            },
        });
    });
    
    function showPopHover(element,content){
         
        $(element).popover({
            trigger: 'manual',
            container: 'body',
            html: true,
            content: content
        });

        $(element).popover('show');
    }
    
    function getStatusColor(status) {
        switch (status) {
            case "Approved":
                return "#6CCF3A";
            case "Rejected":
                return "#FF4A19";
            case "Submitted":
                return "#2AAAFF";
            default:
                return "GOLD";
        }
    }

    function newDate(value) {
        var date = new Date(value);
        date.setHours(0,0,0,0);
        return date;
    }
</script>


<asp:ObjectDataSource ID="dsEmployeeTimeOffRequestGridViewObject" runat="server"
    OldValuesParameterFormatString="original_{0}" SelectMethod="GetvueAccountEmployeeTimeOffRequestByAccountIdAndAccountEmployeeId"
    TypeName="AccountEmployeeTimeOffRequestBLL" >
           
    <SelectParameters>
        <asp:SessionParameter Name="AccountId" SessionField="AccountId" Type="Int32" />
        <asp:QueryStringParameter Name="AccountEmployeeId" QueryStringField ="AccountEmployeeId" Type="Int32" />
    </SelectParameters>
         
</asp:ObjectDataSource>

<asp:Panel id="calendar" style="overflow: hidden;" runat="server" ClientIDMode="Static">
</asp:Panel>
<asp:Panel ID="AuthorizationPanel" runat ="server" Visible="false" >
    <center>
        <h1 style ="padding-top :10px; font-size :16px">You dont have permissions to acess to this page</h1>
    </center>
    
</asp:Panel> 