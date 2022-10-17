<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlProjectTaskByCompletedPercent.ascx.vb" Inherits="Employee_Controls_ctlProjectTaskByGraph" %>
<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<style type="text/css">


    p
{
	font-size: 9pt;
	color: #1a3b69;
}

    .style3
    {
        width: 168px;
        height: 16px;
        font-size: 9pt;
        color: #1a3b69;
        text-align: right;
        margin: 0px;
        padding: 0px;
    }
    </style>
    <table class="xFormView" width="100%"><tr><td>
    <table class="xFormView" width="99%">
            <tr>
                <th class="caption" colspan="2">
                    <asp:Label ID="lbl2" runat="server" Text="My Tasks By Completed %"></asp:Label> </th>
            </tr>
           <tr>
                <th class="FormViewSubHeader" colspan="2" style="text-align: right" 
                    align="right" valign="bottom">
                            <asp:ImageButton ID="ImgBtn_Edit" runat="server" AlternateText="Edit" 
                                NavigateUrl="~/Employee/ChartCustomization.aspx" CausesValidation="False" 
                                CommandName="Edit" Height="16px" 
                                ImageUrl="~/Images/edit.gif" SkinID="GridEditButton" Width="16px" />
                </th>
            </tr>
           <tr>
            <td align="center" colspan="2">
                <asp:CHART ID="Chart1" runat="server" BorderColor="#1A3B69" 
                    BorderWidth="2px" DataSourceID="ObjectDataSource1" Height="350px" 
                    ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)" onclick="Chart1_Click"
                    Width="400px" ViewStateContent="All" 
                    BackImageAlignment="Left">
                    <legends>
                        <asp:Legend BackColor="Transparent" Font="Trebuchet MS, 8pt, style=Bold" 
                            IsEquallySpacedItems="True" IsTextAutoFit="False" Name="Default" 
                            TitleFont="Microsoft Sans Serif, 8pt, style=Bold" IsDockedInsideChartArea="True" Alignment="Near" MaximumAutoSize="30">
                        </asp:Legend>
                    </legends>
                    <series>
                        <asp:Series BorderColor="64, 64, 64, 64" ChartArea="Area1" 
                            ShadowOffset="4" Color="180, 65, 140, 240" IsValueShownAsLabel = "False"
                            
                            CustomProperties="DoughnutRadius=25, PieDrawingStyle=Concave, CollectedLabel=Other, MinimumRelativePieSize=20" 
                            Font="Trebuchet MS, 8.25pt, style=Bold" Label="#PERCENT{P1}" 
                            MarkerStyle="Circle" Name="Default" XValueType="Auto"  YValueType="Auto"  XValueMember="TaskName" 
                            YValueMembers="CompletedPercent" IsXValueIndexed="True" 
                            BorderDashStyle="Solid" ChartType="Pie">
                        </asp:Series>
                    </series>
                    <chartareas>
                        <asp:ChartArea Name="Area1" 
                           Area3DStyle-Enable3D="True" Area3DStyle-WallWidth="20">
                            <area3dstyle  Enable3D="True"/>
                            <axisy LineColor="Silver">
                                
                                <MajorGrid Enabled="True" LineColor="64, 64, 64, 64" />
                                </axisy>
                            <axisx LineColor="Silver">
                                
                                <MajorGrid Enabled="True" LineColor="64, 64, 64, 64" />
                            </axisx>
                        </asp:ChartArea>
                    </chartareas>
                </asp:CHART>
          </td>
            </tr>
            <tr>
            <td align="right" style="text-align: center" class="style3" colspan="2">
                                <asp:Label ID="LabelGC" runat="server" Text="% Complete"></asp:Label>
                                <asp:Label ID="lblerror" runat="server" Font-Size="14px" 
                                    Text="No Data Available"></asp:Label>
            </td></tr>
            <tr>
            <td class="style5" align="center">
                <asp:Label ID="Label1" runat="server" 
                    Text="Click on chart for more information"></asp:Label>
            </td>
            <td align="right">
                <asp:HyperLink ID="hypBack" runat="server" 
                                    NavigateUrl="~/Employee/Default.aspx?IsDetail=0" 
                    Text="Back" style="text-align: right"></asp:HyperLink>
            </td></tr>
            </table>
      </td></tr></table>
      <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
            OldValuesParameterFormatString="original_{0}" 
            SelectMethod="GetAssignedAccountProjectTasksForCompletedPercentageChart" 
            TypeName="AccountEmployeeChartBLL">
            <SelectParameters>
                <asp:SessionParameter Name="AccountEmployeeId" SessionField="AccountEmployeeId" 
                    Type="Int32" />
                <asp:SessionParameter Name="AccountId" SessionField="AccountId" 
                    Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
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
            <script type="text/javascript">
                function onSliceClicked(pointIndex) {
                    var objSeries = document.Form1.elements["SeriesTooltip"];
                    var objLegend = document.Form1.elements["LegendTooltip"];

                    var parameters = "seriesTooltip=" + objSeries.options[objSeries.selectedIndex].value;
                    parameters = parameters + "&legendTooltip=" + objLegend.options[objLegend.selectedIndex].value;

                    document.Form1.elements["Chart1"].ImageUrl = "ImageMapToolTipsChart.aspx?" + parameters;

                    document.images["Chart1"].src = document.Form1.elements["Chart1"].ImageUrl;
                } 
			 
		</script>