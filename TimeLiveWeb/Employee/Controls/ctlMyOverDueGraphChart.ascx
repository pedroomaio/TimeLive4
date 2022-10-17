<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlMyOverDueGraphChart.ascx.vb" Inherits="Employee_Controls_ctlMyOverDueGraphChart" %>
<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>


    <table class="xFormView" width="98%">
            <tr>
                <th class="caption">
                           My OverDue 
                           Timesheets</th>
            </tr>
            <tr>
                <th class="FormViewSubHeader">
                    <asp:Literal ID="Literal2" runat="server" Text="Chart Type" />
                    :<asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" 
            Width="70px" SkinID="xgridviewSkinEmployee">
            <asp:ListItem>Pie</asp:ListItem>
            <asp:ListItem>Column</asp:ListItem>
            <asp:ListItem>Bar</asp:ListItem>
            <asp:ListItem>Bubble</asp:ListItem>
            <asp:ListItem>Doughnut</asp:ListItem>
            <asp:ListItem>Area</asp:ListItem>
        </asp:DropDownList></th>
            </tr>
            <tr>
            <td align="center" width="100%">
                       <asp:Chart ID="Chart1" runat="server" 
    DataSourceID="ObjectDataSource1" Width="350px" Height="350px">
            <titles>
                <asp:Title ShadowOffset="3" Name="Title1" />
            </titles>
            <legends>
                <asp:Legend Alignment="Center" Docking="Right"
                IsTextAutoFit="True" Name="Default"
                LegendStyle="column" />
            </legends>
            <Series>
                <asp:Series Name="Default" XValueMember="SystemTimesheetPeriodType" 
                    YValueMembers="TimesheetOverdueAfterDays" ChartType="Pie" 
                    YValuesPerPoint="2">
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
            SelectMethod="GetDataByEmployeeId" 
            
            TypeName="MyOverDueTimesheetsTableAdapters.VueTimesheetOverDueTableAdapter">
            <SelectParameters>
                <asp:SessionParameter Name="AccountId" SessionField="AccountId" Type="Int32" />
                <asp:SessionParameter Name="AccountEmployeeId" SessionField="AccountEmployeeId" 
                    Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
            </td></tr>
      </table>