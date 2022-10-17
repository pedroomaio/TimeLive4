<%@ Page Language="VB" MasterPageFile="~/Masters/MasterPageEmployee.master" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="AccountAdmin_Default" title="TimeLive - Account Administration" %>


<asp:Content Content ID="C" ContentPlaceHolderID="C" Runat="Server">
    <br />
    <table class="xFromView"><tr><td>
    <table cellpadding="0" cellspacing="0" class="FormViewTable" style="width: 632px;
        height: 1px">
        <tbody>
            <tr>
                <td class="FormviewHeader" colspan="2" style="width: 505px">
                    <asp:Literal ID="Literal1" runat="server" Text="<%$ Resources:TimeLive.Resource, Administration%> " /></td>
            </tr>
            <tr>
                <td class="AdministrationOptionsSubHeader" colspan="2" style="width: 505px; height: 21px">
                    <asp:Literal ID="Literal2" runat="server" Text="<%$ Resources:TimeLive.Resource, Organization Setup%> " /></td>
            </tr>
            <tr>
                <td colspan="2" style="width: 505px; height: 14px">
                    <table style="width: 560px">
                        <tr>
                            <td align="center" style="width: 86px; height: 32px">
                                <asp:HyperLink ID="HyperLinkLocations" runat="server" ImageUrl="~/Images/Locations.gif"
                                    NavigateUrl="~/AccountAdmin/AccountLocations.aspx" ToolTip="Locations">HyperLink</asp:HyperLink></td>
                            <td align="center" style="width: 27px; height: 19px">
                            </td>
                            <td align="center" style="width: 82px; height: 32px">
                                &nbsp;<asp:HyperLink ID="HyperLinkProjectMilestone" runat="server" ImageUrl="~/Images/Department.gif"
                                    NavigateUrl="~/AccountAdmin/AccountDepartments.aspx" ToolTip="Departments">HyperLink</asp:HyperLink></td>
                            <td align="center" style="width: 27px; height: 19px">
                            </td>
                            <td align="center" style="width: 82px; height: 32px">
                                <asp:HyperLink ID="HyperLinkRoles" runat="server" ImageUrl="~/Images/Roles.gif" NavigateUrl="~/AccountAdmin/AccountRoles.aspx"
                                    ToolTip="Roles">HyperLink</asp:HyperLink></td>
                            <td align="center" style="width: 27px; height: 19px">
                            </td>
                            <td align="center" style="width: 82px; height: 32px">
                                <asp:HyperLink ID="HyperLinkWorkingDays" runat="server" ImageUrl="~/Images/WorkingDays.gif"
                                    NavigateUrl="~/AccountAdmin/AccountWorkingDay.aspx" ToolTip="Roles">HyperLink</asp:HyperLink></td>
                            <td align="center" style="width: 27px; height: 19px">
                            </td>
                            <td align="center" style="width: 82px; height: 32px">
                                <asp:HyperLink ID="HyperLinkTaskTypes" runat="server" ImageUrl="~/Images/TaskTypes.gif"
                                    NavigateUrl="~/AccountAdmin/AccountTaskTypes.aspx" ToolTip="Task Types">HyperLink</asp:HyperLink></td>
                            <td align="center" style="width: 27px; height: 19px">
                            </td>
                            <td align="center" style="width: 82px; height: 32px">
                                <asp:HyperLink ID="HyperLink2" runat="server" ImageUrl="~/Images/Priority.gif" NavigateUrl="~/AccountAdmin/AccountPriorities.aspx"
                                    ToolTip="Task Types">HyperLink</asp:HyperLink></td>
                        </tr>
                        <tr>
                            <td align="center" class="AdministrationOptionsText" style="width: 86px; height: 32px"
                                valign="top">
                                <asp:HyperLink ID="TextHyperlinkLocation" runat="server" NavigateUrl="~/AccountAdmin/AccountLocations.aspx"
                                    ToolTip="Locations">Locations</asp:HyperLink></td>
                            <td align="center" class="AdministrationOptionsText" style="width: 27px; height: 32px"
                                valign="top">
                            </td>
                            <td align="center" class="AdministrationOptionsText" style="width: 82px; height: 32px"
                                valign="top">
                                <asp:HyperLink ID="TextHyperlinkDepartment" runat="server" NavigateUrl="~/AccountAdmin/AccountDepartments.aspx"
                                    ToolTip="Departments">Departments</asp:HyperLink></td>
                            <td align="center" class="AdministrationOptionsText" style="width: 27px; height: 32px"
                                valign="top">
                            </td>
                            <td align="center" class="AdministrationOptionsText" style="width: 82px; height: 32px"
                                valign="top">
                                <asp:HyperLink ID="TextHyperlinkRoles" runat="server" NavigateUrl="~/AccountAdmin/AccountRoles.aspx"
                                    ToolTip="Roles">Roles</asp:HyperLink></td>
                            <td align="center" class="AdministrationOptionsText" style="width: 27px; height: 32px"
                                valign="top">
                            </td>
                            <td align="center" class="AdministrationOptionsText" style="width: 82px; height: 32px"
                                valign="top">
                                <asp:HyperLink ID="TextHyperlinkWorkingDays" runat="server" NavigateUrl="~/AccountAdmin/AccountWorkingDay.aspx"
                                    ToolTip="Working Days">Working Days</asp:HyperLink></td>
                            <td align="center" class="AdministrationOptionsText" style="width: 27px; height: 32px"
                                valign="top">
                            </td>
                            <td align="center" class="AdministrationOptionsText" style="width: 82px; height: 32px"
                                valign="top">
                                <asp:HyperLink ID="TextHyperlinkTaskTypes" runat="server" NavigateUrl="~/AccountAdmin/AccountTaskTypes.aspx"
                                    ToolTip="Task Types">Task Types</asp:HyperLink></td>
                            <td align="center" class="AdministrationOptionsText" style="width: 27px; height: 19px"
                                valign="top">
                            </td>
                            <td align="center" class="AdministrationOptionsText" style="width: 82px; height: 32px"
                                valign="top">
                                <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/AccountAdmin/AccountPriorities.aspx"
                                    ToolTip="Priorities">Priorities</asp:HyperLink></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td class="AdministrationOptionsSubHeader" colspan="2" style="width: 505px; height: 22px">
                    Timesheet / Project / Billing</td>
            </tr>
            <tr>
                <td colspan="2" style="width: 505px; height: 95px">
                    <table>
                        <tr>
                            <td align="center" style="width: 82px; height: 32px">
                                &nbsp;<asp:HyperLink ID="HyperLinkBillingTypes" runat="server" ImageUrl="~/Images/BillingTypes.gif"
                                    NavigateUrl="~/AccountAdmin/AccountBillingTypes.aspx" ToolTip="Billing Types">HyperLink</asp:HyperLink></td>
                            <td align="center" style="width: 27px; height: 19px">
                            </td>
                            <td align="center" style="width: 82px; height: 32px">
                                <asp:HyperLink ID="HyperLinkAbsenceType" runat="server" ImageUrl="~/Images/AbsentType.gif"
                                    NavigateUrl="~/AccountAdmin/AccountAbsenceTypes.aspx" ToolTip="Absence Type">HyperLink</asp:HyperLink></td>
                            <td align="center" style="width: 82px; height: 32px">
                            </td>
                            <td align="center" style="width: 27px; height: 19px">
                            </td>
                            <td align="center" style="width: 82px; height: 32px">
                                <asp:HyperLink ID="HyperLinkProjectTypes" runat="server" ImageUrl="~/Images/ProjectTypes.gif"
                                    NavigateUrl="~/ProjectAdmin/AccountProjectTypes.aspx" ToolTip="Project Types">HyperLink</asp:HyperLink></td>
                            <td align="center" style="width: 27px; height: 19px">
                            </td>
                            <td align="center" style="width: 82px; height: 32px">
                                <asp:HyperLink ID="HyperLink1" runat="server" ImageUrl="~/Images/StatusTypes.gif"
                                    NavigateUrl="~/AccountAdmin/AccountStatusTypes.aspx" ToolTip="Project Types">HyperLink</asp:HyperLink></td>
                            <td align="center" style="width: 27px; height: 19px">
                            </td>
                             <td align="center" style="width: 82px; height: 32px">
                                <asp:HyperLink ID="HyperlinkAccountPreferences" runat="server" ImageUrl="~/Images/AccountSetting.gif"
                                    NavigateUrl="~/AccountAdmin/AccountPreferences.aspx" ToolTip="Account Preferences">HyperLink</asp:HyperLink></td>
                        </tr>

                        <tr>
                            <td align="center" class="AdministrationOptionsText" style="width: 82px; height: 32px"
                                valign="top">
                                <asp:HyperLink ID="TextHyperlinkBillingTypes" runat="server" NavigateUrl="~/AccountAdmin/AccountBillingTypes.aspx"
                                    ToolTip="Billing Types">Billing Types</asp:HyperLink></td>
                            <td align="center" class="AdministrationOptionsText" style="width: 27px; height: 32px"
                                valign="top">
                            </td>
                            <td align="center" class="AdministrationOptionsText" style="width: 82px; height: 32px"
                                valign="top">
                                <asp:HyperLink ID="TextHyperlinkAbsenceType" runat="server" NavigateUrl="~/AccountAdmin/AccountAbsenceTypes.aspx"
                                    ToolTip="Absence Type">Absence Type</asp:HyperLink></td>
                            <td align="center" class="AdministrationOptionsText" style="width: 82px; height: 32px"
                                valign="top">
                            </td>
                            <td align="center" class="AdministrationOptionsText" style="width: 27px; height: 32px"
                                valign="top">
                            </td>
                            <td align="center" class="AdministrationOptionsText" style="width: 82px; height: 32px"
                                valign="top">
                                <asp:HyperLink ID="TextHyperLinkProjectTypes" runat="server" NavigateUrl="~/ProjectAdmin/AccountProjectTypes.aspx"
                                    ToolTip="Project Types">Project Types</asp:HyperLink></td>
                            <td align="center" class="AdministrationOptionsText" style="width: 27px; height: 32px"
                                valign="top">
                            </td>
                            <td align="center" class="AdministrationOptionsText" style="width: 82px; height: 32px"
                                valign="top">
                                <asp:HyperLink ID="TextHyperlinkStatusTypes" runat="server" NavigateUrl="~/AccountAdmin/AccountStatusTypes.aspx"
                                    ToolTip="Status Types">Status Types</asp:HyperLink></td>
                            <td align="center" class="AdministrationOptionsText" style="width: 27px; height: 32px"
                                valign="top">
                            </td>
                            <td align="center" class="AdministrationOptionsText" style="width: 82px; height: 32px"
                                valign="top">
                                <asp:HyperLink ID="TextHyperlinkAccountPreferences" runat="server" NavigateUrl="~/AccountAdmin/AccountPreferences.aspx"
                                    ToolTip="Account Preferences">Preferences</asp:HyperLink></td>
                        </tr>
                        <tr>
                            <td align="center" style="width: 82px; height: 32px">
                                <asp:HyperLink ID="HyperLinkExpenseType" runat="server" ImageUrl="~/Images/ExpenseType.gif" NavigateUrl="~/AccountAdmin/AccountExpenseType.aspx"
                                    ToolTip="Expense Type">HyperLink</asp:HyperLink></td>
                            
                            <td align="center" class="AdministrationOptionsText" style="width: 27px; height: 32px"
                                valign="top">
                            </td>
                            <td align="center" style="width: 82px; height: 32px">
                                <asp:HyperLink ID="HyperLinkExpense" runat="server" ImageUrl="~/Images/Expense.gif" NavigateUrl="~/AccountAdmin/AccountExpense.aspx"
                                    ToolTip="Expenses">HyperLink</asp:HyperLink></td>
                            <td align="center" style="width: 82px; height: 32px">
                                <asp:HyperLink ID="HyperLink4" runat="server" ImageUrl="~/Images/Employees.gif" NavigateUrl="~/AccountAdmin/ExternalUsers.aspx"
                                    ToolTip="External Users">HyperLink</asp:HyperLink></td>
                            
                        </tr>
                        <tr>
                            <td align="center" class="AdministrationOptionsText" style="width: 82px; height: 32px"
                                valign="top">
                                <asp:HyperLink ID="TextHyperlinkAccountExpenseType" runat="server" NavigateUrl="~/AccountAdmin/AccountExpenseType.aspx"
                                    ToolTip="Expense Types">Expense Types</asp:HyperLink></td>
                            
                            <td align="center" class="AdministrationOptionsText" style="width: 27px; height: 32px"
                                valign="top">
                            </td>
                            
                            <td align="center" class="AdministrationOptionsText" style="width: 82px; height: 32px"
                                valign="top">
                                <asp:HyperLink ID="TextHyperlinkAccountExpense" runat="server" NavigateUrl="~/AccountAdmin/AccountExpense.aspx"
                                    ToolTip="Expenses">Expenses</asp:HyperLink></td>
                            <td align="center" class="AdministrationOptionsText" style="width: 82px; height: 32px"
                                valign="top">
                                <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/AccountAdmin/ExternalUsers.aspx"
                                    ToolTip="External Users">External Users</asp:HyperLink></td>
                                    
                        </tr>
                    </table>
                </td>
            </tr>
        </tbody>
    </table>
    </td></tr></table>
    <br />
</asp:Content>

