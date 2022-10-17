<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlMyReports.ascx.vb" Inherits="Reports_ControlsReports_ctlMyReports" %>
        <table class="xFormViewWithoutBorder" width="98%">
            <tr>
                <td class="caption" colspan="2">
                    <asp:Literal ID="Literal35" runat="server" Text="<%$ Resources:TimeLive.Resource, My Reports%> " />
            </tr>
             <% If AccountPagePermissionBLL.IspageHasRights(53) = True Then%>
            <tr>
                <td colspan="2">
        <asp:HyperLink ID="HyperLink29" runat="server" Height="5px" ImageUrl="~/Images/clearpixel.gif"></asp:HyperLink></td>
            </tr>
            <tr>
                <td valign="middle" style="width: 51px">
                    <asp:HyperLink ID="HyperLink22" runat="server" ImageUrl="~/Images/DetailTimeSheetReport.gif" NavigateUrl="~/Reports/DetailTimeSheetReport.aspx"
                        ToolTip="<%$ Resources:TimeLive.Resource, Detail Time Sheet Report%> " ></asp:HyperLink></td>
                <td valign="top">
                    <asp:HyperLink ID="HyperLink1" runat="server" CssClass="MyReportTableSummaryHeader"  NavigateUrl="~/Reports/DetailTimeSheetReport.aspx"
                        ToolTip="<%$ Resources:TimeLive.Resource, Detail Time Sheet Report%> " ><asp:Literal ID="Literal1" runat="server" Text="<%$ Resources:TimeLive.Resource, Detail Time Sheet Report%> " /></asp:HyperLink>
                    <asp:HyperLink ID="HyperLink33" runat="server" Height="2px" ImageUrl="~/Images/clearpixel.gif"></asp:HyperLink><br />
                    <asp:Literal ID="Literal50" runat="server" Text="<%$ Resources:TimeLive.Resource, Generates a timesheet report for a given user for a given time period. The user can select the details to be included in the report.%> " />
                    </tr>
             <%End If%>
             <% If AccountPagePermissionBLL.IspageHasRights(52) = True Then%>
            <tr>
                <td colspan="2">
        <asp:HyperLink ID="HyperLink38" runat="server" Height="12px" ImageUrl="~/Images/clearpixel.gif"></asp:HyperLink></td>
            </tr>
            <tr>
                <td valign="middle" style="width: 51px">
                    <asp:HyperLink ID="HyperLink24" runat="server" ImageUrl="~/Images/AttendanceDetailReport.gif"
                        NavigateUrl="~/Reports/AttendanceDetailReport.aspx" ToolTip="<%$ Resources:TimeLive.Resource, Attendance Detail Report%> "></asp:HyperLink></td>
                <td valign="top">
                <asp:HyperLink ID="HyperLink2" runat="server" CssClass="myreporttablesummaryheader"
                        NavigateUrl="~/Reports/AttendanceDetailReport.aspx" ToolTip="<%$ Resources:TimeLive.Resource, Attendance Detail Report%> "><asp:Literal ID="Literal2" runat="server" Text="<%$ Resources:TimeLive.Resource, Attendance Detail Report%> " /></asp:HyperLink>
                        <asp:HyperLink ID="HyperLink36" runat="server" Height="2px" ImageUrl="~/Images/clearpixel.gif"></asp:HyperLink><br />
                    <asp:Literal ID="Literal39" runat="server" Text="<%$ Resources:TimeLive.Resource, Generate Attendance detail report for a given user for a given period. User can select different parameters like employee startdate enddate.%> " />
                     </td>
            </tr>
             <%End If%>
             <% If AccountPagePermissionBLL.IspageHasRights(59) = True Then%>
            <tr>
                <td colspan="2">
        <asp:HyperLink ID="HyperLink43" runat="server" Height="12px" ImageUrl="~/Images/clearpixel.gif"></asp:HyperLink></td>
            </tr>
            <tr>
                <td valign="middle" style="width: 51px">
                    <asp:HyperLink ID="HyperLink25" runat="server" ImageUrl="~/Images/AttendanceSummaryReport.gif"
                        NavigateUrl="~/Reports/EmployeeAttendanceSummaryReport.aspx" ToolTip="<%$ Resources:TimeLive.Resource, Employee Attendance Summary Report%> "></asp:HyperLink></td>
                <td valign="top">
                <asp:HyperLink ID="HyperLink3" runat="server" 
                        NavigateUrl="~/Reports/EmployeeAttendanceSummaryReport.aspx" CssClass="myreporttablesummaryheader" ToolTip="<%$ Resources:TimeLive.Resource, Employee Attendance Summary Report%> "><asp:Literal ID="Literal3" runat="server" Text="<%$ Resources:TimeLive.Resource, Employee Attendance Summary Report%> " /></asp:HyperLink>
                    <br />
                    <asp:HyperLink ID="HyperLink40" runat="server" Height="2px" ImageUrl="~/Images/clearpixel.gif"></asp:HyperLink><br />
                    <asp:Literal ID="Literal23" runat="server" Text="<%$ Resources:TimeLive.Resource, Summary of employee attendance helpful for user and administrator to generate summary of employee attendance for payroll purpose.%> " />
                    </tr>
             <%End If%>
             <% If AccountPagePermissionBLL.IspageHasRights(55) = True Then%>
            <tr>
                <td colspan="2">
                    <asp:HyperLink ID="HyperLink46" runat="server" Height="12px" ImageUrl="~/Images/clearpixel.gif"></asp:HyperLink></td>
            </tr>
            <tr>
                <td valign="middle" style="width: 51px">
                            <asp:HyperLink ID="HyperLink28" runat="server" ImageUrl="~/Images/AbsenceDetailReport.gif"
                                NavigateUrl="~/Reports/EmployeeAbsenceDetailReport.aspx" ToolTip="<%$ Resources:TimeLive.Resource, Employee Absence Detail Report%> "></asp:HyperLink></td>
                <td valign="top">
                                <asp:HyperLink ID="HyperLink5" runat="server" CssClass="myreporttablesummaryheader" 
                                NavigateUrl="~/Reports/EmployeeAbsenceDetailReport.aspx" ToolTip="<%$ Resources:TimeLive.Resource, Employee Absence Detail Report%> "><asp:Literal ID="Literal4" runat="server" Text="<%$ Resources:TimeLive.Resource, Employee Absence Detail Report%> " /></asp:HyperLink>
                                <br />
                    <asp:HyperLink ID="HyperLink30" runat="server" Height="2px" ImageUrl="~/Images/clearpixel.gif"></asp:HyperLink><br />
                    <asp:Literal ID="Literal36" runat="server" Text="<%$ Resources:TimeLive.Resource, Detail report of employee absence in specified data range.Helpfull for payroll department to get list of absent in specified date range.%> " />
                    </tr>
             <%End If%>
             <% If AccountPagePermissionBLL.IspageHasRights(64) = True Then%>
            <tr>
                <td colspan="2">
                    <asp:HyperLink ID="HyperLink48" runat="server" Height="12px" ImageUrl="~/Images/clearpixel.gif"></asp:HyperLink></td>
            </tr>
            <tr>
                <td valign="middle" style="width: 51px">
                            <asp:HyperLink ID="HyperLink27" runat="server" ImageUrl="~/Images/LeaveSummaryReport.gif"
                                NavigateUrl="~/Reports/LeaveSummaryReport.aspx" ToolTip="<%$ Resources:TimeLive.Resource, Leave Summary Report%> "></asp:HyperLink></td>
                <td valign="top">
                <asp:HyperLink ID="HyperLink4" runat="server" CssClass="myreporttablesummaryheader" 
                                NavigateUrl="~/Reports/LeaveSummaryReport.aspx" ToolTip="<%$ Resources:TimeLive.Resource, Leave Summary Report%> "><asp:Literal ID="Literal5" runat="server" Text="<%$ Resources:TimeLive.Resource, Leave Summary Report%> " /></asp:HyperLink>
                                    <br />
                    <asp:HyperLink ID="HyperLink54" runat="server" Height="2px" ImageUrl="~/Images/clearpixel.gif"></asp:HyperLink><br />
                    <asp:Literal ID="Literal21" runat="server" Text="<%$ Resources:TimeLive.Resource, Report for generating summary of employee leaves like sick leave casual leave etc in specified range.%> " />
                    </tr>
             <%End If%>
             <% If AccountPagePermissionBLL.IspageHasRights(68) = True Then%>
            <tr>
                <td colspan="2">
                    <asp:HyperLink ID="HyperLink16" runat="server" Height="12px" ImageUrl="~/Images/clearpixel.gif"></asp:HyperLink></td>
            </tr>
            <tr>
                <td style="width: 51px" valign="middle">
                    <asp:HyperLink ID="HyperLink17" runat="server" ImageUrl="~/Images/DetailExpenseReport.gif"
                        NavigateUrl="~/Reports/DetailExpenseReport.aspx" ToolTip="<%$ Resources:TimeLive.Resource, Detail Expense Report%> "></asp:HyperLink></td>
                <td valign="top">
                    <asp:HyperLink ID="HyperLink19" runat="server" CssClass="myreporttablesummaryheader"
                        NavigateUrl="~/Reports/DetailExpenseReport.aspx" ToolTip="<%$ Resources:TimeLive.Resource, Detail Expense Report%> "><asp:Literal ID="Literal6" runat="server" Text="<%$ Resources:TimeLive.Resource, Detail Expense Report%> " /></asp:HyperLink><br />
                    <asp:HyperLink ID="HyperLink20" runat="server" Height="2px" ImageUrl="~/Images/clearpixel.gif"></asp:HyperLink><br />
                    <asp:Literal ID="Literal25" runat="server" Text="<%$ Resources:TimeLive.Resource, Generates a expense report for a given user for a given time period. The user can select the details to be included in the report.%> " />
                     </tr>
             <%End If%>
             <% If AccountPagePermissionBLL.IspageHasRights(110) = True Then%>
            <tr>
                <td colspan="2" valign="top" style="height: 14px">
                    <asp:HyperLink ID="HyperLink10" runat="server" Height="12px" ImageUrl="~/Images/clearpixel.gif"></asp:HyperLink></td>
            </tr>
            <tr>
                <td colspan="1" style="width: 51px">
                    <asp:HyperLink ID="HyperLink11" runat="server" ImageUrl="~/Images/DepartmentWiseTimesheetRepo.gif"
                        NavigateUrl="~/Reports/DepartmentWiseTimesheetReport.aspx" ToolTip="<%$ Resources:TimeLive.Resource, Department Wise Timesheet Report%> " Width="39px"></asp:HyperLink></td>
                <td colspan="2">
                    <asp:HyperLink ID="HyperLink55" runat="server" CssClass="myreporttablesummaryheader"
                        NavigateUrl="~/Reports/DepartmentWiseTimesheetReport.aspx" ToolTip="<%$ Resources:TimeLive.Resource, Department Wise Timesheet Report%> "><asp:Literal ID="Literal7" runat="server" Text="<%$ Resources:TimeLive.Resource, Department Wise Timesheet Report%> " /></asp:HyperLink><br />
                    <asp:HyperLink ID="HyperLink73" runat="server" Height="2px" ImageUrl="~/Images/clearpixel.gif"></asp:HyperLink><br />
                    <asp:Literal ID="Literal26" runat="server" Text="<%$ Resources:TimeLive.Resource, Generates a department wise timesheet report for a given user for a given time period. The user can select the details to be included in the report.%> " />
                    </tr>
             <%End If%>
             <% If AccountPagePermissionBLL.IspageHasRights(111) = True Then%>
            <tr>
                <td colspan="3">
                    <asp:HyperLink ID="HyperLink74" runat="server" Height="12px" ImageUrl="~/Images/clearpixel.gif"></asp:HyperLink></td>
            </tr>
            <tr>
                <td colspan="1" style="width: 51px">
                    <asp:HyperLink ID="HyperLink75" runat="server" ImageUrl="~/Images/TaskSummaryReport1.GIF"
                        NavigateUrl="~/Reports/TaskSummary.aspx" ToolTip="<%$ Resources:TimeLive.Resource, Task Summary Report%> "></asp:HyperLink></td>
                <td colspan="2">
                    <asp:HyperLink ID="HyperLink76" runat="server" CssClass="myreporttablesummaryheader"
                        NavigateUrl="~/Reports/TaskSummary.aspx" ToolTip="<%$ Resources:TimeLive.Resource, Task Summary Report%> "><asp:Literal ID="Literal8" runat="server" Text="<%$ Resources:TimeLive.Resource, Task Summary Report%> " /></asp:HyperLink><br />
                    <asp:HyperLink ID="HyperLink77" runat="server" Height="2px" ImageUrl="~/Images/clearpixel.gif"></asp:HyperLink><br />
                    <asp:Literal ID="Literal27" runat="server" Text="<%$ Resources:TimeLive.Resource, Generates a task summary report for a given user for a given time period. The user can select the details to be included in the report.%> " />
                    </tr>
            <%End If%>
            <% If AccountPagePermissionBLL.IspageHasRights(115) = True Then%>
            <tr>
                <td colspan="3" style="height: 9px">
                    <asp:HyperLink ID="HyperLink34" runat="server" Height="12px" ImageUrl="~/Images/clearpixel.gif"></asp:HyperLink></td>
            </tr>
            <tr>
                <td colspan="1" style="width: 51px">
                    <asp:HyperLink ID="HyperLink32" runat="server" ImageUrl="~/Images/ProjectExpenseDetailReport.gif"
                        NavigateUrl="~/Reports/ProjectExpenseDetailReport.aspx" ToolTip="<%$ Resources:TimeLive.Resource, Project Expense Detail Report%> "></asp:HyperLink></td>
                <td colspan="2">
                    <asp:HyperLink ID="HyperLink31" runat="server" CssClass="myreporttablesummaryheader"
                        NavigateUrl="~/Reports/ProjectExpenseDetailReport.aspx" ToolTip="<%$ Resources:TimeLive.Resource, Project Expense Detail Report%> "><asp:Literal ID="Literal9" runat="server" Text="<%$ Resources:TimeLive.Resource, Project Expense Detail Report%> " /></asp:HyperLink><br />
                        <asp:Literal ID="Literal28" runat="server" Text="<%$ Resources:TimeLive.Resource, Generates a project expense detail report for a given user for a given time period. The user can select the details to be included in the report.%> " />
                        </tr>
            <%End If%>
            <% If AccountPagePermissionBLL.IspageHasRights(116) = True Then%>
            <tr>
                <td colspan="3" style="height: 9px">
                    <asp:HyperLink ID="HyperLink39" runat="server" Height="12px" ImageUrl="~/Images/clearpixel.gif"></asp:HyperLink></td>
            </tr>
            <tr>
                <td colspan="1" style="width: 51px">
                    <asp:HyperLink ID="HyperLink35" runat="server" ImageUrl="~/Images/EmployeeTimesheetSubmissionReport.gif"
                        NavigateUrl="~/Reports/AccountEmployeeTimesheetSubmissionStatusReport.aspx" ToolTip="<%$ Resources:TimeLive.Resource, Employee Timesheet Submission Status Report%> "></asp:HyperLink></td>
                <td colspan="2">
                    <asp:HyperLink ID="HyperLink37" runat="server" CssClass="myreporttablesummaryheader"
                        NavigateUrl="~/Reports/AccountEmployeeTimesheetSubmissionStatusReport.aspx" ToolTip="<%$ Resources:TimeLive.Resource, Employee Timesheet Submission Status Report%> "><asp:Literal ID="Literal10" runat="server" Text="<%$ Resources:TimeLive.Resource, Employee Timesheet Submission Status Report%> " /></asp:HyperLink><br />
                        <asp:Literal ID="Literal29" runat="server" Text="<%$ Resources:TimeLive.Resource, Generates employee wise summarize report for time entries with missing entries. %> " />
                        </td>
            </tr>
            <%End If%>
            <% If AccountPagePermissionBLL.IspageHasRights(120) = True Then%>
            <tr>
                <td colspan="3" style="height: 5px">
                    <asp:HyperLink ID="HyperLink41" runat="server" Height="12px" ImageUrl="~/Images/clearpixel.gif"></asp:HyperLink></td>
            </tr>
            <tr>
                <td colspan="1" style="width: 51px">
                    <asp:HyperLink ID="HyperLink49" runat="server" ImageUrl="~/Images/ProjectActivityReport.gif"
                        NavigateUrl="~/Reports/ProjectSummaryReport.aspx" ToolTip="<%$ Resources:TimeLive.Resource, Project Activity Summary Report%> "></asp:HyperLink></td>
                <td colspan="2">
                    <asp:HyperLink ID="HyperLink52" runat="server" CssClass="myreporttablesummaryheader"
                        NavigateUrl="~/Reports/ProjectSummaryReport.aspx" ToolTip="<%$ Resources:TimeLive.Resource, Project Activity Summary Report%> "><asp:Literal ID="Literal11" runat="server" Text="<%$ Resources:TimeLive.Resource, Project Activity Summary Report%> " /></asp:HyperLink><br />
                        <asp:Literal ID="Literal30" runat="server" Text="<%$ Resources:TimeLive.Resource, Generates a employee wise project summary report with expense detail. %> " />
                        </td>
            </tr>
            <%End If%> 
        </table>
        &nbsp;
<br />
            <table class="xFormViewWithoutBorder" width="750">
                    <tr>
                        <td class="caption" colspan="2">
                            <asp:Literal ID="Literal22" runat="server" Text="<%$ Resources:TimeLive.Resource, Project Reports%> " /><td />
                    </tr>
                     <% If AccountPagePermissionBLL.IspageHasRights(65) = True Then%>
                    <tr>
                        <td colspan="2">
                            <asp:HyperLink ID="HyperLink57" runat="server" Height="5px" ImageUrl="~/Images/clearpixel.gif"></asp:HyperLink></td>
                    </tr>
                    <tr>
                        <td valign="middle" style="width: 5%">
                            <asp:HyperLink ID="HyperLink21" runat="server" ImageUrl="~/Images/ProjectReport.gif"
                                NavigateUrl="~/Reports/ProjectListReport.aspx" ToolTip="<%$ Resources:TimeLive.Resource, All Projects of Organization%> "></asp:HyperLink></td>
                        <td valign="top">
                            <asp:HyperLink ID="HyperLink6" runat="server" CssClass="myreporttablesummaryheader"
                                NavigateUrl="~/Reports/ProjectListReport.aspx" ToolTip="<%$ Resources:TimeLive.Resource, All Projects of Organization%> "><asp:Literal ID="Literal12" runat="server" Text="<%$ Resources:TimeLive.Resource, All Projects of Organization%> " /></asp:HyperLink>
                            <br />
                            <asp:HyperLink ID="HyperLink47" runat="server" Height="2px" ImageUrl="~/Images/clearpixel.gif"></asp:HyperLink><br />
                            <asp:Literal ID="Literal24" runat="server" Text="<%$ Resources:TimeLive.Resource, All Projects of Organization %> " />
                    </tr>
                     <%End If%>
                     <% If AccountPagePermissionBLL.IspageHasRights(56) = True Then%>
                    <tr>
                        <td colspan="2">
                            <asp:HyperLink ID="HyperLink58" runat="server" Height="12px" ImageUrl="~/Images/clearpixel.gif"></asp:HyperLink></td>
                    </tr>
                    <tr>
                        <td valign="middle" style="width: 5%">
                            <asp:HyperLink ID="HyperLink23" runat="server" ImageUrl="~/Images/TaskBillingReport.gif"
                                NavigateUrl="~/Reports/EmployeeTimeEntryReport.aspx" ToolTip="<%$ Resources:TimeLive.Resource, Task Billing By Projects/Clients%> "></asp:HyperLink></td>
                        <td valign="top">
                            <asp:HyperLink ID="HyperLink7" runat="server" CssClass="myreporttablesummaryheader"
                                NavigateUrl="~/Reports/EmployeeTimeEntryReport.aspx" ToolTip="<%$ Resources:TimeLive.Resource, Task Billing By Projects/Clients%> "><asp:Literal ID="Literal13" runat="server" Text="<%$ Resources:TimeLive.Resource, Task Billing By Projects/Clients%> " /></asp:HyperLink>
                            <br />
                            <asp:HyperLink ID="HyperLink50" runat="server" Height="2px" ImageUrl="~/Images/clearpixel.gif"></asp:HyperLink><br />
                            <asp:Literal ID="Literal31" runat="server" Text="<%$ Resources:TimeLive.Resource, Generates a employee wise project summary report with expense detail.%> " />
                             </tr>
                     <%End If%>
                     <% If AccountPagePermissionBLL.IspageHasRights(67) = True Then%>
                    <tr>
                        <td colspan="2">
                            <asp:HyperLink ID="HyperLink59" runat="server" Height="12px" ImageUrl="~/Images/clearpixel.gif"></asp:HyperLink></td>
                    </tr>
                    <tr>
                        <td valign="middle" style="width: 5%">
                            <asp:HyperLink ID="HyperLink26" runat="server" ImageUrl="~/Images/TaskSummaryReport.gif"
                                NavigateUrl="~/Reports/TaskSummaryReport.aspx" ToolTip="<%$ Resources:TimeLive.Resource, Task Status Summary Report%> "></asp:HyperLink></td>
                        <td valign="top">
                            <asp:HyperLink ID="HyperLink8" runat="server" CssClass="myreporttablesummaryheader"
                                NavigateUrl="~/Reports/TaskSummaryReport.aspx" ToolTip="<%$ Resources:TimeLive.Resource, Task Status Summary Report%> "><asp:Literal ID="Literal14" runat="server" Text="<%$ Resources:TimeLive.Resource, Task Status Summary Report%> " /></asp:HyperLink>
                            <br />
                            <asp:HyperLink ID="HyperLink51" runat="server" Height="2px" ImageUrl="~/Images/clearpixel.gif"></asp:HyperLink><br />
                            <asp:Literal ID="Literal37" runat="server" Text="<%$ Resources:TimeLive.Resource, Summary of all project tasks status. Usefull for project manager to get a high level view of whole project status.%> " />
                            </tr>
                     <%End If%>
                     <% If AccountPagePermissionBLL.IspageHasRights(63) = True Then%>
                    <tr>
                        <td colspan="2">
                            <asp:HyperLink ID="HyperLink60" runat="server" Height="12px" ImageUrl="~/Images/clearpixel.gif"></asp:HyperLink></td>
                    </tr>
                    <tr>
                        <td valign="middle" style="width: 5%; height: 56px;">
                            <asp:HyperLink ID="HyperLink18" runat="server" ImageUrl="~/Images/ExpenseReport.gif"
                                NavigateUrl="~/Reports/ExpenseByClientsReport.aspx" ToolTip="<%$ Resources:TimeLive.Resource, Expense By Client Report%> " ></asp:HyperLink></td>
                        <td valign="top" style="height: 56px">
                            <asp:HyperLink ID="HyperLink9" runat="server" CssClass="myreporttablesummaryheader"
                                NavigateUrl="~/Reports/ExpenseByClientsReport.aspx" ToolTip="<%$ Resources:TimeLive.Resource, Expense By Client Report%> " ><asp:Literal ID="Literal15" runat="server" Text="<%$ Resources:TimeLive.Resource, Expense By Client Report%> " /></asp:HyperLink>
                            <br />
                            <asp:HyperLink ID="HyperLink53" runat="server" Height="2px" ImageUrl="~/Images/clearpixel.gif"></asp:HyperLink><br />
                            <asp:Literal ID="Literal38" runat="server" Text="<%$ Resources:TimeLive.Resource, Summary of Expenses occurred on project. Can be generated based on project client employee and data range.%> " />
                            </tr>
                    <tr>
                        <td colspan="2">
                            <asp:HyperLink ID="HyperLink61" runat="server" Height="12px" ImageUrl="~/Images/clearpixel.gif"></asp:HyperLink></td>
                    </tr>
                     <%End If%>
                </table>
<br />
                <table class="xFormViewWithoutBorder" width="750">
                    <tr>
                        <td class="caption" colspan="2">
                            <asp:Literal ID="Literal17" runat="server" Text="<%$ Resources:TimeLive.Resource, Administrator / Project Reports%> " />
                    </tr>
                     <% If AccountPagePermissionBLL.IspageHasRights(45) = True Then%>
                    <tr>
                        <td colspan="2">
                            <asp:HyperLink ID="HyperLink62" runat="server" Height="5px" ImageUrl="~/Images/clearpixel.gif"></asp:HyperLink></td>
                    </tr>
                    <tr>
                        <td style="width: 5%" valign="middle">
                            <asp:HyperLink ID="HyperLink63" runat="server" ImageUrl="~/Images/LocationReport.gif"
                                NavigateUrl="~/Reports/LocationListReport.aspx" ></asp:HyperLink></td>
                        <td valign="top">
                        <asp:HyperLink ID="HyperLink12" runat="server" CssClass="myreporttablesummaryheader" 
                                NavigateUrl="~/Reports/LocationListReport.aspx"></asp:HyperLink>
                                <br />
                            <asp:HyperLink ID="HyperLink105" runat="server" Height="2px" ImageUrl="~/Images/clearpixel.gif"></asp:HyperLink><br />
                            <asp:Literal ID="Literal33" runat="server"/>
                    </tr>
                     <%End If%>
                     <% If AccountPagePermissionBLL.IspageHasRights(43) = True Then%>
                    <tr>
                        <td colspan="2">
                            <asp:HyperLink ID="HyperLink65" runat="server" Height="12px" ImageUrl="~/Images/clearpixel.gif"></asp:HyperLink></td>
                    </tr>
                    <tr>
                        <td style="width: 5%" valign="middle">
                            <asp:HyperLink ID="HyperLink64" runat="server" ImageUrl="~/Images/DepartmentsReport.gif"
                                NavigateUrl="~/Reports/DepartmentListReport.aspx" ToolTip="<%$ Resources:TimeLive.Resource, All Departments Report%> "></asp:HyperLink></td>
                        <td valign="top">
                            <asp:HyperLink ID="HyperLink13" runat="server" CssClass="myreporttablesummaryheader"  
                                NavigateUrl="~/Reports/DepartmentListReport.aspx" ToolTip="<%$ Resources:TimeLive.Resource, All Departments Report%> "><asp:Literal ID="Literal18" runat="server" Text="<%$ Resources:TimeLive.Resource, All Department Report%> " /></asp:HyperLink>
                                <br />
                            <asp:HyperLink ID="HyperLink42"
                                    runat="server" Height="2px" ImageUrl="~/Images/clearpixel.gif"></asp:HyperLink><br />
                            <asp:Literal ID="Literal34" runat="server" Text="<%$ Resources:TimeLive.Resource, All Departments of Organization%> " />
                    </tr>
                     <%End If%>
                     <% If AccountPagePermissionBLL.IspageHasRights(41) = True Then%>
                    <tr>
                        <td colspan="2" style="height: 18px">
                            <asp:HyperLink ID="HyperLink66" runat="server" Height="12px" ImageUrl="~/Images/clearpixel.gif"></asp:HyperLink></td>
                    </tr>
                    <tr>
                        <td style="width: 5%" valign="middle">
                            <asp:HyperLink ID="HyperLink67" runat="server" ImageUrl="~/Images/ClientsReport.gif" NavigateUrl="~/Reports/AccountClientsReport.aspx"
                                ToolTip="<%$ Resources:TimeLive.Resource, All Client Report%> "></asp:HyperLink></td>
                        <td valign="top">
                                <asp:HyperLink ID="HyperLink14"  CssClass="myreporttablesummaryheader"  runat="server"  NavigateUrl="~/Reports/AccountClientsReport.aspx"
                                ToolTip="<%$ Resources:TimeLive.Resource, All Client Report%> "><asp:Literal ID="Literal19" runat="server" Text="<%$ Resources:TimeLive.Resource, All Client Report%> " /></asp:HyperLink>
                                <br />
                            <asp:HyperLink ID="HyperLink44"
                                    runat="server" Height="2px" ImageUrl="~/Images/clearpixel.gif"></asp:HyperLink><br />
                            <asp:Literal ID="Literal32" runat="server" Text="<%$ Resources:TimeLive.Resource, All Clients of Organization%> " />
                    </tr>
                     <%End If%>
                     <% If AccountPagePermissionBLL.IspageHasRights(50) = True Then%>
                    <tr>
                        <td colspan="2">
                            <asp:HyperLink ID="HyperLink68" runat="server" Height="12px" ImageUrl="~/Images/clearpixel.gif"></asp:HyperLink></td>
                    </tr>
                    <tr>
                        <td style="width: 5%" valign="middle">
                            <asp:HyperLink ID="HyperLink69" runat="server" ImageUrl="~/Images/EmployeeReport.gif"
                                NavigateUrl="~/Reports/EmployeeListReport.aspx" ToolTip="<%$ Resources:TimeLive.Resource, All Employees Of Organization%> "></asp:HyperLink></td>
                        <td valign="top">
                                <asp:HyperLink ID="HyperLink15" runat="server" CssClass="myreporttablesummaryheader"  
                                NavigateUrl="~/Reports/EmployeeListReport.aspx" ToolTip="<%$ Resources:TimeLive.Resource, All Employees Of Organization%> "><asp:Literal ID="Literal40" runat="server" Text="<%$ Resources:TimeLive.Resource, All Employees of Organization%> " /></asp:HyperLink>
                                <br />
                            <asp:HyperLink ID="HyperLink45"
                                    runat="server" Height="2px" ImageUrl="~/Images/clearpixel.gif"></asp:HyperLink><br />
                            <asp:Literal ID="Literal20" runat="server" Text="<%$ Resources:TimeLive.Resource, All Employees Of Organization%> " />
                    </tr>
                     <%End If%>
                    <tr>
                        <td colspan="2">
                            </td>
                    </tr>
                </table>
            <br />

