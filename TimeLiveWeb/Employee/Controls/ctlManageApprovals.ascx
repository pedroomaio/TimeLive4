<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlManageApprovals.ascx.vb" Inherits="Employee_Controls_ctlManageApprovals" %>
<table class="xAdminOption" width="98%"><tr><td>
<table cellpadding="0" cellspacing="0" class="xAdminOption" width="98%" >
        <tbody>
            <tr>
                <th class="caption" colspan="2" style="width: 100%">
                    <asp:Literal ID="Literal1" runat="server" Text="Manage Approvals" />
                </th>
              </tr>
            <tr>
                <th class="FormViewSubHeader" colspan="2" style="width: 100%;">
                    <asp:Literal ID="Literal2" runat="server" Text="Approvals" />
                </th>
            </tr>
            <tr>
                <td colspan="2" style="width: 100%; height: 95px">
                    <table width="150" style="border:0">
                          <tr>
                            <td></td>                        
                         </tr>
                        <tr>
                         <%  If DBUtilities.IsTimesheetFeature Then%>
                            <td align="center" style="width: 14%; height: 48px;"  valign="top" >
                                  <span  runat="server" id="TimesheetApproval"></span>
                                <asp:HyperLink ID="HyperLinkProjectMilestone" runat="server" 
                                    NavigateUrl="~/ProjectAdmin/TimeSheetApproval.aspx" Width="100px">
                                    <asp:Image ID="Image3" runat="server" ImageUrl="~/Images/TimesheetApprovalActivity.png" AlternateText="Timesheet Approval" Height="48px" Width="48" />
                                        </asp:HyperLink>
                            </td>
                            <td align="center" style="width: 14%; height: 19px">
                            </td>
                            <% End If %>
                             <%  If DBUtilities.IsExpenseFeature Then%>
                            <td align="center" style="width: 14%; height: 48px;"  valign="top">
                                     <span  runat="server" id="ExpenseApproval"></span>
                                <asp:HyperLink ID="HyperLinkRoles" runat="server" NavigateUrl="~/ProjectAdmin/ExpenseApproval.aspx"
                                    Width="100px">
                                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/ExpenseApprovalActivity.png" AlternateText="Expense Approval" Height="48px" Width="48"/> 
                                </asp:HyperLink></td>
                            <td align="center" style="width: 14%; height: 19px">
                            </td>
                            <% End If %>
                            <%  If DBUtilities.IsTimeOffFeature Then%>
                            <td align="center" style="width: 14%; height: 48px;" valign="top">
                                <span  runat="server" id="TimeOffApproval"></span>
                                <asp:HyperLink ID="HyperLinkWorkingDays" runat="server" 
                                    NavigateUrl="~/Employee/MyTimeOffRequestApproval.aspx" Width="100px">
                                    <asp:Image ID="Image2" runat="server" ImageUrl="~/Images/TimeOffPolicy.png" AlternateText="Time Off Approval" />
                                         </asp:HyperLink>
                            </td>
                            <td align="center" style="width: 14%; height: 48px;">
                            </td>
                            <% End If %>
                        </tr>
                        <tr>
                         <%  If DBUtilities.IsTimesheetFeature Then%> 
                            <td align="center" class="AdministrationOptionsText" style="width: 14%; font-family:Verdana" valign="top">
                                <asp:HyperLink ID="TextHyperlinkDepartment" runat="server" NavigateUrl="~/ProjectAdmin/TimeSheetApproval.aspx"
                                    Width="100px" Text="Timesheet Approval" Height="38px"></asp:HyperLink>
                            </td> 
                            <td align="center" class="AdministrationOptionsText" style="width: 14%; height: 19px" 
                                valign="top">
                            </td>
                            <% End If %>
                            <%  If DBUtilities.IsExpenseFeature Then%>
                            <td align="center" class="AdministrationOptionsText" style="width: 14%; font-family:Verdana" 
                                valign="top">
                                <asp:HyperLink ID="TextHyperlinkRoles" runat="server" NavigateUrl="~/ProjectAdmin/ExpenseApproval.aspx"
                                    Width="100px" Text="Expense Approval"></asp:HyperLink>
                            </td> 
                            <td align="center" class="AdministrationOptionsText" style="width: 14%; height: 19px"
                                valign="top">
                            </td>
                            <% End If %>
                            <%  If DBUtilities.IsTimeOffFeature Then%>
                            <td align="center" class="AdministrationOptionsText" style="width: 14%; font-family:Verdana" 
                                valign="top">
                                <asp:HyperLink ID="TextHyperlinkWorkingDays" runat="server" NavigateUrl="~/Employee/MyTimeOffRequestApproval.aspx"
                                    Width="100px" Text="Time Off Approval"></asp:HyperLink>
                            </td> 
                            <td align="center" class="AdministrationOptionsText" style="width: 14%; height: 19px"
                                valign="top">
                            </td>
                            <% End If %>
                            <td align="center" class="AdministrationOptionsText" style="width: 14%; height: 48px" 
                                valign="top">
                            </td> 
                        </tr>
                </table>
                </td> 
                </tr> 
                </tbody>
          </table>
          </td></tr></table>