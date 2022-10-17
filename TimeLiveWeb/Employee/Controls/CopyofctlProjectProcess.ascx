<%@ Control Language="VB" AutoEventWireup="false" CodeFile="CopyofctlProjectProcess.ascx.vb" Inherits="Employee_Controls_CopyofctlProjectProcess" %>

<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <table width="98%" class="xFormView">
            <tr>
                <td width="20%">
                    Project Name:</td>
                <td width="78%" align="left">
                    <asp:DropDownList ID="ddlProjectName" runat="server" AutoPostBack="True" 
                        DataSourceID="dsAccountProjectObject" DataTextField="ProjectName" 
                        DataValueField="AccountProjectId" Width="40%" AppendDataBoundItems="True">
                    </asp:DropDownList>
                </td>
            </tr>
        </table>
        <asp:ObjectDataSource ID="dsAccountProjectObject" runat="server" 
            OldValuesParameterFormatString="original_{0}" 
            SelectMethod="GetAssignedAccountProjectsByAccountEmployeeId" TypeName="AccountProjectBLL" 
            DeleteMethod="DeleteAccountProject" InsertMethod="AddAccountProject" 
            UpdateMethod="UpdateProjectDescription">
            <DeleteParameters>
                <asp:Parameter Name="Original_AccountProjectId" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="AccountId" Type="Int32" />
                <asp:Parameter Name="AccountProjectTypeId" Type="Int32" />
                <asp:Parameter Name="AccountClientId" Type="Int32" />
                <asp:Parameter Name="AccountPartyContactId" Type="Int32" />
                <asp:Parameter Name="AccountPartyDepartmentId" Type="Int32" />
                <asp:Parameter Name="ProjectBillingTypeId" Type="Int32" />
                <asp:Parameter Name="ProjectName" Type="String" />
                <asp:Parameter Name="ProjectDescription" Type="String" />
                <asp:Parameter Name="StartDate" Type="DateTime" />
                <asp:Parameter Name="Deadline" Type="DateTime" />
                <asp:Parameter Name="ProjectStatusId" Type="Int32" />
                <asp:Parameter Name="LeaderEmployeeId" Type="Int32" />
                <asp:Parameter Name="ProjectManagerEmployeeId" Type="Int32" />
                <asp:Parameter Name="TimeSheetApprovalTypeId" Type="Int32" />
                <asp:Parameter Name="ExpenseApprovalTypeId" Type="Int32" />
                <asp:Parameter Name="EstimatedDuration" Type="Double" />
                <asp:Parameter Name="EstimatedDurationUnit" Type="String" />
                <asp:Parameter Name="ProjectCode" Type="String" />
                <asp:Parameter Name="DefaultBillingRate" Type="Decimal" />
                <asp:Parameter Name="ProjectBillingRateTypeId" Type="Int32" />
                <asp:Parameter Name="IsTemplate" Type="Boolean" />
                <asp:Parameter Name="IsProject" Type="Boolean" />
                <asp:Parameter Name="AccountProjectTemplateId" Type="Int32" />
                <asp:Parameter Name="CreatedOn" Type="DateTime" />
                <asp:Parameter Name="CreatedByEmployeeId" Type="Int32" />
                <asp:Parameter Name="ModifiedOn" Type="DateTime" />
                <asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" />
                <asp:Parameter Name="Completed" Type="Boolean" />
                <asp:Parameter Name="CustomField1" Type="String" />
                <asp:Parameter Name="CustomField2" Type="String" />
                <asp:Parameter Name="CustomField3" Type="String" />
                <asp:Parameter Name="CustomField4" Type="String" />
                <asp:Parameter Name="CustomField5" Type="String" />
                <asp:Parameter Name="CustomField6" Type="String" />
                <asp:Parameter Name="CustomField7" Type="String" />
                <asp:Parameter Name="CustomField8" Type="String" />
                <asp:Parameter Name="CustomField9" Type="String" />
                <asp:Parameter Name="CustomField10" Type="String" />
                <asp:Parameter Name="CustomField11" Type="String" />
                <asp:Parameter Name="CustomField12" Type="String" />
                <asp:Parameter Name="CustomField13" Type="String" />
                <asp:Parameter Name="CustomField14" Type="String" />
                <asp:Parameter Name="CustomField15" Type="String" />
            </InsertParameters>
            <SelectParameters>
                <asp:SessionParameter Name="AccountEmployeeId" SessionField="AccountEmployeeId" 
                    Type="Int32" />
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter Name="ProjectDescription" Type="String" />
                <asp:Parameter Name="Original_AccountProjectId" Type="Int32" />
            </UpdateParameters>
        </asp:ObjectDataSource>
        <table>
            <tr>
                <td colspan="2" align="center" >
                    Project Task By Progress - Execs</td>
            </tr>
            <tr>
                <td width="20%">
                    Chart Type:</td>
                <td width="78%">
                    <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" 
                        Width="70px">
                        <asp:ListItem>Pie</asp:ListItem>
                        <asp:ListItem>Column</asp:ListItem>
                        <asp:ListItem>Bar</asp:ListItem>
                        <asp:ListItem>Bubble</asp:ListItem>
                        <asp:ListItem>Doughnut</asp:ListItem>
                        <asp:ListItem>Area</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Chart ID="Chart2" runat="server" DataSourceID="dsAccountProjectTaskObject" 
                        Width="400px">
                        <titles>
                            <asp:Title Name="Title1" ShadowOffset="3" />
                        </titles>
                        <legends>
                            <asp:Legend Alignment="Center" Docking="Right" IsTextAutoFit="True" 
                                LegendStyle="column" Name="Default" />
                        </legends>
                        <series>
                            <asp:Series ChartType="Pie" Name="Default" XValueMember="CompletedPercent" 
                                YValueMembers="CompletedPercent">
                            </asp:Series>
                        </series>
                        <chartareas>
                            <asp:ChartArea BorderWidth="0" Name="ChartArea1">
                            </asp:ChartArea>
                        </chartareas>
                    </asp:Chart>
                    <br />
                    <asp:Label ID="Label2" runat="server" AssociatedControlID="DropDownList2" 
                        BorderStyle="None" Font-Bold="True" Font-Names="Cambria" Font-Size="Medium" 
                        Text="% Complete"></asp:Label>
                    <asp:ObjectDataSource ID="dsAccountProjectTaskObject" runat="server" 
                        DeleteMethod="DeleteAccountProjectType" InsertMethod="AddAccountProjectTask" 
                        OldValuesParameterFormatString="original_{0}" 
                        SelectMethod="GetAssignedAccountProjectTasksByAccountProjectId" 
                        TypeName="AccountProjectTaskBLL" UpdateMethod="UpdateCompletedInTask">
                        <DeleteParameters>
                            <asp:Parameter Name="Original_AccountProjectTaskId" Type="Int32" />
                        </DeleteParameters>
                        <InsertParameters>
                            <asp:Parameter Name="AccountProjectId" Type="Int32" />
                            <asp:Parameter Name="ParentAccountProjectTaskId" Type="Int32" />
                            <asp:Parameter Name="TaskName" Type="String" />
                            <asp:Parameter Name="TaskDescription" Type="String" />
                            <asp:Parameter Name="AccountTaskTypeId" Type="Int32" />
                            <asp:Parameter Name="Duration" Type="Double" />
                            <asp:Parameter Name="DurationUnit" Type="String" />
                            <asp:Parameter Name="CompletedPercent" Type="Double" />
                            <asp:Parameter Name="Completed" Type="Boolean" />
                            <asp:Parameter Name="DeadlineDate" Type="DateTime" />
                            <asp:Parameter Name="TaskStatusId" Type="Int32" />
                            <asp:Parameter Name="AccountPriorityId" Type="Int32" />
                            <asp:Parameter Name="AccountProjectMilestoneId" Type="Int32" />
                            <asp:Parameter Name="IsForAllEmployees" Type="Boolean" />
                            <asp:Parameter Name="IsParentTask" Type="Boolean" />
                            <asp:Parameter Name="CreatedOn" Type="DateTime" />
                            <asp:Parameter Name="CreatedByEmployeeId" Type="Int32" />
                            <asp:Parameter Name="ModifiedOn" Type="DateTime" />
                            <asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" />
                            <asp:Parameter Name="EstimatedCost" Type="Double" />
                            <asp:Parameter Name="EstimatedTimeSpent" Type="Double" />
                            <asp:Parameter Name="EstimatedTimeSpentUnit" Type="String" />
                            <asp:Parameter Name="IsBillable" Type="Boolean" />
                            <asp:Parameter Name="TaskCode" Type="String" />
                            <asp:Parameter Name="AccountBillingRateId" Type="Int32" />
                            <asp:Parameter Name="IsForAllProjectTask" Type="Boolean" />
                            <asp:Parameter Name="EstimatedCurrencyId" Type="Int32" />
                            <asp:Parameter Name="StartDate" Type="DateTime" />
                            <asp:Parameter Name="original_Predecessors" Type="String" />
                            <asp:Parameter Name="CustomField1" Type="String" />
                            <asp:Parameter Name="CustomField2" Type="String" />
                            <asp:Parameter Name="CustomField3" Type="String" />
                            <asp:Parameter Name="CustomField4" Type="String" />
                            <asp:Parameter Name="CustomField5" Type="String" />
                            <asp:Parameter Name="CustomField6" Type="String" />
                            <asp:Parameter Name="CustomField7" Type="String" />
                            <asp:Parameter Name="CustomField8" Type="String" />
                            <asp:Parameter Name="CustomField9" Type="String" />
                            <asp:Parameter Name="CustomField10" Type="String" />
                            <asp:Parameter Name="CustomField11" Type="String" />
                            <asp:Parameter Name="CustomField12" Type="String" />
                            <asp:Parameter Name="CustomField13" Type="String" />
                            <asp:Parameter Name="CustomField14" Type="String" />
                            <asp:Parameter Name="CustomField15" Type="String" />
                        </InsertParameters>
                        <SelectParameters>
                            <asp:ControlParameter ControlID="ddlProjectName" DefaultValue="1" 
                                Name="AccountProjectId" PropertyName="SelectedValue" Type="Int32" />
                            <asp:SessionParameter Name="AccountEmployeeId" SessionField="AccountEmployeeId" 
                                Type="Int32" />
                        </SelectParameters>
                        <UpdateParameters>
                            <asp:Parameter Name="AccountProjectId" Type="Int32" />
                            <asp:Parameter Name="AccountProjectMilestoneId" Type="Int32" />
                            <asp:Parameter Name="TaskStatusId" Type="Int32" />
                            <asp:Parameter Name="Completed" Type="Boolean" />
                        </UpdateParameters>
                    </asp:ObjectDataSource>
                </td>
            </tr>
        </table>
    </ContentTemplate>
</asp:UpdatePanel>



