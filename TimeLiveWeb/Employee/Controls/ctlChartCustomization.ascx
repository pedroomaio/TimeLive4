<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlChartCustomization.ascx.vb" Inherits="Employee_Controls_ctlChartCustomization" %>
<style type="text/css">



.controls
{
	border-spacing:0px;
	border-collapse:collapse;
	margin-top: 0px;
	margin-left: 0px;
	margin-right: 0px;
	padding-top:0px;
	padding-bottom:0px;
	width: 100%;
	vertical-align:middle;
}

    p
{
	font-size: 9pt;
	color: #1a3b69;
        width: 86px;
    }

    .spaceright
    {}

    .style2
    {
        width: 139px;
    }

    </style>
   
     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    <table class="xFormView" style="width: 100%"><tr><td>
        <table align="left" class="xFormView" style="width: 98%">
                                <tr>
                                    <th class="caption" colspan="4">
                                        Chart Customization
                                    </th>
                                </tr>

                                            <tr>
                <th class="FormViewSubHeader" colspan="4">
                    <asp:Literal ID="Literal2" runat="server" Text="Chart Information" /></th>
            </tr>
            <tr>
                <td align="right" class="formviewlabelcell">
                                        <asp:Label ID="Label326" runat="server" Text="Chart Name:"></asp:Label>
                                    </td>
                <td align="left" class="formviewlabelcell">
                                        <asp:TextBox ID="txtChartName" runat="server" Width="150px"></asp:TextBox>
                                    </td>
                <td align="right" class="style2">
                                        <asp:Label ID="lblShowExploded" runat="server" Text="Show Exploded:"></asp:Label>
                                    </td>
                <td align="left" class="formviewlabelcell">
                                        <asp:CheckBox ID="chkShowExplode" runat="server" 
                                            Width="100px" />
                                    </td>
            </tr>
            <tr>
                <td align="right" class="formviewlabelcell">
                                        <asp:Label ID="lblChartType" runat="server" Text="Chart Type:"></asp:Label>
                                    </td>
                <td align="left" class="formviewlabelcell">
                                        <asp:DropDownList ID="ddlChartType" runat="server" AppendDataBoundItems="True" 
                                            AutoPostBack="True" DataSourceID="dsAccountChartTypeObj" 
                                            DataTextField="SystemChartTypeName" DataValueField="SystemChartTypeId" 
                                            Width="75px">
                                        </asp:DropDownList>
                </td>
                <td align="right" class="style2">
                                        <asp:Label ID="lblShowas3D" runat="server" Text="Show As 3D:"></asp:Label>
                </td>
                <td align="left" class="formviewlabelcell">
                                        <asp:CheckBox ID="chkShow3D" runat="server" Text="" Width="100px" />
                                    </td>
            </tr>
            <tr>
                <td align="right" class="formviewlabelcell">
                                        <asp:Label ID="lblCollectedThreshold" runat="server" 
                                            Text="Collect Slices (in %):"></asp:Label>
                                    </td>
                <td align="left" class="formviewlabelcell">
                                        <asp:DropDownList ID="ddlCollectedThreshold" runat="server" 
                                            CssClass="spaceright" Width="75px">
                                            <asp:ListItem Value="1">1</asp:ListItem>
                                            <asp:ListItem Value="3">3</asp:ListItem>
                                            <asp:ListItem Value="5">5</asp:ListItem>
                                            <asp:ListItem Value="6">6</asp:ListItem>
                                            <asp:ListItem Value="8">8</asp:ListItem>
                                            <asp:ListItem Value="13">13</asp:ListItem>
                                            <asp:ListItem Value="16">16</asp:ListItem>
                                            <asp:ListItem Value="20">20</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                <td align="right" class="style2">
                                        <asp:Label ID="lblShowLegend" runat="server" Text="Show Legend:"></asp:Label>
                                    </td>
                <td align="left" class="formviewlabelcell">
                                        <asp:CheckBox ID="chkShowLegend" runat="server" Text="" Width="100px" />
                                    </td>
            </tr>
            <tr>
                <td align="right" class="formviewlabelcell">
                    &nbsp;</td>
                <td align="left" class="formviewlabelcell" colspan="2" style="padding-bottom: 5px; padding-top: 5px;" >
                                        <asp:Button ID="SaveCustomized" runat="server"  
                                            Text="Save" Width="65px" />
                                        <asp:Button ID="Cancel" runat="server" Text="Cancel" Width="65px" />
                                    </td>
                <td align="left" class="formviewlabelcell">
                    &nbsp;</td>
            </tr>
            </table>
                        </td>
                    </tr>
                </table>
    </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource ID="dsAccountChartTypeObj" runat="server" 
    InsertMethod="AddAccountEmployeeCharts" 
    OldValuesParameterFormatString="original_{0}" SelectMethod="GetChartTypes" 
    TypeName="AccountEmployeeChartBLL" UpdateMethod="UpdateAccountEmployeeCharts">
    <InsertParameters>
        <asp:Parameter Name="AccountId" Type="Int32" />
        <asp:Parameter Name="AccountEmployeeId" Type="Int32" />
        <asp:Parameter DbType="Guid" Name="SystemChartTypeId" />
        <asp:Parameter DbType="Guid" Name="SystemChartId" />
        <asp:Parameter Name="IsCollectPieSlices" Type="Boolean" />
        <asp:Parameter Name="CollectedThreshold" Type="Int32" />
        <asp:Parameter Name="CollectedColor" Type="String" />
        <asp:Parameter Name="CollectedLabel" Type="String" />
        <asp:Parameter Name="CollectedLegendText" Type="String" />
        <asp:Parameter Name="IsShowExploded" Type="Boolean" />
    </InsertParameters>
    <UpdateParameters>
        <asp:Parameter Name="AccountId" Type="Int32" />
        <asp:Parameter Name="AccountEmployeeId" Type="Int32" />
        <asp:Parameter DbType="Guid" Name="SystemChartTypeId" />
        <asp:Parameter DbType="Guid" Name="Original_AccountChartId" />
        <asp:Parameter DbType="Guid" Name="SystemChartId" />
        <asp:Parameter Name="IsCollectPieSlices" Type="Boolean" />
        <asp:Parameter Name="CollectedThreshold" Type="Int32" />
        <asp:Parameter Name="CollectedColor" Type="String" />
        <asp:Parameter Name="CollectedLabel" Type="String" />
        <asp:Parameter Name="CollectedLegendText" Type="String" />
        <asp:Parameter Name="IsShowExploded" Type="Boolean" />
    </UpdateParameters>
</asp:ObjectDataSource>
<asp:ObjectDataSource ID="dsAccountEmployeechart" runat="server" 
    InsertMethod="AddAccountEmployeeCharts" 
    OldValuesParameterFormatString="original_{0}" 
    SelectMethod="GetAccountEmployeechartByAccountChartId" 
    TypeName="AccountEmployeeChartBLL" 
    UpdateMethod="UpdateAccountEmployeeChartsByAccountChatId">
    <InsertParameters>
        <asp:Parameter Name="AccountId" Type="Int32" />
        <asp:Parameter Name="AccountEmployeeId" Type="Int32" />
        <asp:Parameter DbType="Guid" Name="SystemChartTypeId" />
        <asp:Parameter DbType="Guid" Name="SystemChartId" />
        <asp:Parameter Name="IsCollectPieSlices" Type="Boolean" />
        <asp:Parameter Name="CollectedThreshold" Type="Int32" />
        <asp:Parameter Name="CollectedColor" Type="String" />
        <asp:Parameter Name="CollectedLabel" Type="String" />
        <asp:Parameter Name="CollectedLegendText" Type="String" />
        <asp:Parameter Name="IsShowExploded" Type="Boolean" />
    </InsertParameters>
    <SelectParameters>
        <asp:SessionParameter Name="AccountId" SessionField="AccountId" Type="Int32" />
        <asp:SessionParameter DbType="Guid" Name="AccountChartId" 
            SessionField="AccountChartId" />
    </SelectParameters>
    <UpdateParameters>
        <asp:Parameter Name="AccountId" Type="Int32" />
        <asp:Parameter Name="AccountEmployeeId" Type="Int32" />
        <asp:Parameter DbType="Guid" Name="SystemChartTypeId" />
        <asp:Parameter DbType="Guid" Name="Original_AccountChartId" />
        <asp:Parameter DbType="Guid" Name="SystemChartId" />
        <asp:Parameter Name="IsCollectPieSlices" Type="Boolean" />
        <asp:Parameter Name="CollectedThreshold" Type="Int32" />
        <asp:Parameter Name="CollectedColor" Type="String" />
        <asp:Parameter Name="CollectedLabel" Type="String" />
        <asp:Parameter Name="CollectedLegendText" Type="String" />
        <asp:Parameter Name="IsShowExploded" Type="Boolean" />
    </UpdateParameters>
</asp:ObjectDataSource>
<asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
            OldValuesParameterFormatString="original_{0}" 
            SelectMethod="GetAssignedOpenAccountProjectTasksByAccountEmployeeIdForChart" 
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
                <asp:SessionParameter Name="AccountEmployeeId" SessionField="AccountEmployeeId" 
                    Type="Int32" />
                <asp:SessionParameter Name="AccountId" SessionField="AccountId" 
                    Type="Int32" />
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter Name="AccountProjectId" Type="Int32" />
                <asp:Parameter Name="AccountProjectMilestoneId" Type="Int32" />
                <asp:Parameter Name="TaskStatusId" Type="Int32" />
                <asp:Parameter Name="Completed" Type="Boolean" />
            </UpdateParameters>
        </asp:ObjectDataSource>





                            
                            





