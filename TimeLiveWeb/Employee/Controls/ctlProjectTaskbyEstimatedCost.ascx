<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlProjectTaskbyEstimatedCost.ascx.vb" Inherits="Employee_Controls_ctlProjectTaskbyEstimatedCost" %>
<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>
         <table class="xFormView" width="100%"><tr><td>
         <table class="xFormView" width="99%">
            <tr>
                <th class="caption" colspan="4" rowspan="0" >
                            My Project Task by Estimated Cost</th>
            </tr>
            <tr>
                <th class="FormViewSubHeader" width="15%" rowspan="0" >
                    <asp:Literal ID="Literal1" runat="server"  Text="Chart Type:" />
                    </th>
                <th class="FormViewSubHeader" width="20%" >
                    <asp:DropDownList ID="DropDownList1"  runat="server" AutoPostBack="True" 
                        Width="50%" >
                    <asp:ListItem>Pie</asp:ListItem>
                    <asp:ListItem>Column</asp:ListItem>
                    <asp:ListItem>Bar</asp:ListItem>
                    <asp:ListItem>Bubble</asp:ListItem>
                    <asp:ListItem>Doughnut</asp:ListItem>
                    <asp:ListItem>Area</asp:ListItem>
                    </asp:DropDownList> 
                    </th>
                <th class="FormViewSubHeader" width="20%" rowspan="0" >
                      <asp:Literal ID="Literal2" runat="server" Text="Project Name:" />
                    </th>
                <th class="FormViewSubHeader" width="35%" rowspan="0" >
                    <asp:DropDownList ID="DropDownList2"  runat="server" AutoPostBack="True" 
                        DataSourceID="dsAccountProjectObject"  DataTextField="ProjectName" 
                        DataValueField="AccountProjectId" Width="95%">
                    </asp:DropDownList>
                    </th>
            </tr>
            <tr>
                <td align="left">
                         </td>
            </tr>
            <tr>
            <td align="center" colspan="4" width="100%" rowspan="0">
            <asp:Chart ID="Chart1" runat="server" 
            DataSourceID="ObjectDataSource1" Width="350px">
            <titles>
                <asp:Title ShadowOffset="3" Name="Title1" />
            </titles>
            <legends>
                <asp:Legend Alignment="Center" Docking="Right"
                IsTextAutoFit="True" Name="Default"
                LegendStyle="column" />
            </legends>
            <Series>
                <asp:Series Name="Default" XValueMember="TaskCode" 
                    YValueMembers="EstimatedCost" ChartType="Pie" YValuesPerPoint="2">
                </asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1" BorderWidth="0">
                </asp:ChartArea>
            </ChartAreas>
        </asp:Chart>
        <asp:Label ID="LabelGC" runat="server" AssociatedControlID="DropDownList1" 
            BorderStyle="None" Font-Bold="True" Font-Names="Cambria" Font-Size="Medium" 
            Text="% Complete"></asp:Label>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
            OldValuesParameterFormatString="original_{0}" 
            SelectMethod="GetProjectTaskEstCostByAccountId" 
            TypeName="AccountProjectTaskBLL" DeleteMethod="DeleteAccountProjectType" 
                                InsertMethod="AddAccountProjectTask" 
                                UpdateMethod="UpdateAccountProjectTaskUpdateInformation">
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
                <asp:SessionParameter Name="AccountId" SessionField="AccountId" 
                    Type="Int32" />
                <asp:ControlParameter ControlID="DropDownList2" Name="AccountProjectId" 
                    PropertyName="SelectedValue" Type="Int32" />
            </SelectParameters>
            <UpdateParameters>
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
                <asp:Parameter Name="IsForAllEmployees" Type="Boolean" />
                <asp:Parameter Name="IsParentTask" Type="Boolean" />
                <asp:Parameter Name="IsReOpen" Type="Boolean" />
                <asp:Parameter Name="AccountProjectMilestoneId" Type="Int32" />
                <asp:Parameter Name="CreatedOn" Type="DateTime" />
                <asp:Parameter Name="CreatedByEmployeeId" Type="Int32" />
                <asp:Parameter Name="ModifiedOn" Type="DateTime" />
                <asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" />
                <asp:Parameter Name="EstimatedCost" Type="Double" />
                <asp:Parameter Name="EstimatedTimeSpent" Type="Double" />
                <asp:Parameter Name="EstimatedTimeSpentUnit" Type="String" />
                <asp:Parameter Name="IsBillable" Type="Boolean" />
                <asp:Parameter Name="Original_AccountProjectTaskId" Type="Int32" />
                <asp:Parameter Name="TaskCode" Type="String" />
                <asp:Parameter Name="IsForAllProjectTask" Type="Boolean" />
            </UpdateParameters>
        </asp:ObjectDataSource>
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
      </td>
      </tr>
      </table>
      </td></tr></table>