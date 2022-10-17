<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlAccountProjectTaskSummary.ascx.vb" Inherits="Employee_Controls_ctlAccountProjectTaskSummary" %>

 <table width="98%" class="xFormView" >
             <tr>
                <td width="10%" >
                <asp:Label ID="Label2" runat="server" Text="<%$ Resources:TimeLive.Resource, Project Name: %>"
                Width="150px" Font-Bold="true" Font-Size="11px"></asp:Label>
                </td>   
                <td width="89%" >
                    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" 
                        DataSourceID="dsAccountProjectObject" DataTextField="ProjectName" 
                        DataValueField="AccountProjectId" Width="50%">
                    </asp:DropDownList>
                </td>
            </tr>
        </table>
        <x:GridView ID="APTS" runat="server" AllowSorting="True" 
            AutoGenerateColumns="False" Caption="All Project Task Summary" 
            DataSourceID="dsProjectTaskSummaryObject" EnableViewState="False" 
            SkinID="xgridviewSkinEmployee" Width="99%" 
    DataKeyNames="AccountProjectTaskId">

            <Columns>
                <asp:BoundField DataField="TaskName" HeaderText="Task Name" 
                    SortExpression="TaskName" >
                </asp:BoundField>
                <asp:BoundField DataField="TaskDescription" HeaderText="Task Description" 
                    SortExpression="TaskDescription" >
                </asp:BoundField>
                <asp:BoundField DataField="StartDate" HeaderText="Start Date" 
                    SortExpression="StartDate" />
                <asp:BoundField DataField="CreatedOn" HeaderText="Created On" 
                    SortExpression="CreatedOn" />
                <asp:BoundField DataField="ModifiedOn" HeaderText="Modified On" 
                    SortExpression="ModifiedOn" />
                <asp:BoundField DataField="Duration" HeaderText="Duration" 
                    SortExpression="Duration" />
                <asp:BoundField DataField="DurationUnit" HeaderText="Duration Unit" 
                    SortExpression="DurationUnit" />
                <asp:BoundField DataField="DeadlineDate" HeaderText="Deadline Date" 
                    SortExpression="DeadlineDate" />
                <asp:BoundField DataField="CompletedPercent" HeaderText="Completed Percent" 
                    SortExpression="CompletedPercent" >
                </asp:BoundField>
                <asp:BoundField DataField="EstimatedCost" HeaderText="Estimated Cost" 
                    SortExpression="EstimatedCost" />
                <asp:CheckBoxField DataField="IsForAllEmployees" HeaderText="For All Employees" 
                    SortExpression="IsForAllEmployees" />
                <asp:CheckBoxField DataField="IsForAllProjectTask" 
                    HeaderText="For All Project Task" SortExpression="IsForAllProjectTask" />
                <asp:CheckBoxField DataField="IsBillable" HeaderText="Billable" 
                    SortExpression="IsBillable" />
                <asp:CheckBoxField DataField="Completed" HeaderText="Completed" 
                    SortExpression="Completed" />
            </Columns>
        </x:GridView>
<asp:ObjectDataSource ID="dsProjectTaskSummaryObject" runat="server" 
    OldValuesParameterFormatString="original_{0}" 
    SelectMethod="GetAccountProjectTasksByAccountProjectId" 
    TypeName="AccountProjectTaskBLL" DeleteMethod="DeleteAccountProjectType" 
    InsertMethod="AddAccountProjectTask" UpdateMethod="UpdateCompletedInTask">
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
        <asp:ControlParameter ControlID="DropDownList1" Name="AccountProjectId" 
            PropertyName="SelectedValue" Type="Int32" />
    </SelectParameters>
    <UpdateParameters>
        <asp:Parameter Name="AccountProjectId" Type="Int32" />
        <asp:Parameter Name="AccountProjectMilestoneId" Type="Int32" />
        <asp:Parameter Name="TaskStatusId" Type="Int32" />
        <asp:Parameter Name="Completed" Type="Boolean" />
    </UpdateParameters>
</asp:ObjectDataSource>

        <asp:ObjectDataSource ID="dsAccountProjectObject" runat="server" 
            DeleteMethod="DeleteAccountProject" InsertMethod="AddAccountProject" 
            OldValuesParameterFormatString="original_{0}" 
            SelectMethod="GetAssignedAccountProjectsByAccountEmployeeId" 
            TypeName="AccountProjectBLL" 
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


