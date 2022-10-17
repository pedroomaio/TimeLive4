<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlDueGraphChart.ascx.vb" Inherits="Employee_ctlDueGraphChart" %>
<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>


    <table class="xFormView" width="98%">
            <tr>
                <th class="caption">
                            My Due 
                            Timesheets</th>
            </tr>
            <tr>
                <th class="FormViewSubHeader">
                    <asp:Literal ID="Literal2" runat="server" Text="Chart Type" />:<asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" 
            Width="70px" >
            <asp:ListItem>Pie</asp:ListItem>
            <asp:ListItem>Column</asp:ListItem>
            <asp:ListItem>Bar</asp:ListItem>
            <asp:ListItem>Bubble</asp:ListItem>
            <asp:ListItem>Doughnut</asp:ListItem>
            <asp:ListItem>Area</asp:ListItem>
        </asp:DropDownList></th>
            </tr>
             <tr>
                <td align="center">
                <asp:Chart ID="Chart1" runat="server" 
    DataSourceID="dsDueGraphChartobj" Width="350px" Height="350px">
            <titles>
                <asp:Title ShadowOffset="3" Name="Title1" />
            </titles>
            <legends>
                <asp:Legend Alignment="Center" Docking="Right"
                IsTextAutoFit="True" Name="Default"
                LegendStyle="column" />
            </legends>
            <Series>
                <asp:Series Name="Default" ChartType="Pie" YValuesPerPoint="2" 
                    XValueMember="SystemTimesheetPeriodType" 
                    YValueMembers="TimesheetOverduePeriods">
                </asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1" BorderWidth="0">
                </asp:ChartArea>
            </ChartAreas>
        </asp:Chart>
         <asp:Label ID="Label1" runat="server" AssociatedControlID="DropDownList1" 
            BorderStyle="None" Font-Bold="True" Font-Names="Cambria" Font-Size="Medium" 
            Text="% Complete"></asp:Label>
        <asp:ObjectDataSource ID="dsDueGraphChartobj" runat="server" 
            OldValuesParameterFormatString="original_{0}" 
            SelectMethod="GetOverDueTimesheetByAccountandEmployeeId" 
            TypeName="MyOverDueTimesheetsTableAdapters.vueTimesheetDueTableAdapter">
            <SelectParameters>
                <asp:SessionParameter Name="AccountId" SessionField="AccountId" Type="Int32" />
                <asp:SessionParameter Name="AccountEmployeeId" SessionField="AccountEmployeeId" 
                    Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
        </td> 
        </tr> 
      </table>
           
 
