<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlAccountEmployeeTimeEntryDayViewList.ascx.vb" Inherits="Mobile_Controls_ctlAccountEmployeeTimeEntryDayViewList" %>
<%@ Register Assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24D65337282035F2"
    Namespace="eWorld.UI" TagPrefix="ew" %>
 <div data-role="header" data-theme="a" >
       <h1 style="text-align:left;margin-left:15px;" > Day View</h1>
</div>
     <div data-role="content" data-theme="d"> 
     <table>
     <tr>
     <td align="left" colspan="2">
     <asp:LinkButton ID="lblPeriodView" runat="server" >Period View</asp:LinkButton></td>
     </tr>
      <tr>
     <td align="left" colspan="2">
     <asp:Label ID="Label2" runat="server" Text="Timesheet Total:" Font-Bold="True" Font-Names="Tahoma" Font-Size="11px" ></asp:Label>
     <asp:Label ID="lblTotalTime" runat="server" Text="00:00" Font-Names="Tahoma" Font-Size="11px"></asp:Label></td>
    </tr>
       <tr>
     <td>
     <asp:Label ID="Label3" runat="server" Text="Timesheet Status:" Font-Bold="True" Font-Names="Tahoma" Font-Size="11px" ></asp:Label></td>
     <td align="left"  >
     &nbsp;<asp:Image ID="imgTSL" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/clearpixel.gif"
     Width="10px" AlternateText="Timesheet Status" />
     
     <asp:Label ID="lblTimesheetStatus" runat="server" Text="Label" Font-Names="Tahoma" Font-Size="11px"></asp:Label></td>
    </tr>
     <tr><td valign="top">
     <asp:Label id="Label1" runat="server" Text="Time Entry Date:" Font-Bold="True" Font-Names="Tahoma" Font-Size="11px"></asp:Label>
     </td><td>
     <ew:CalendarPopup id="txtTimeEntryDate" CalendarWidth="200" runat="server" Width="95px" ControlDisplay="TextBoxImage" ImageUrl="~/Images/spacer.gif" Text="" AutoPostBack="True" Height="20px" PopupLocation="bottom"  DisplayOffsetX="-45" DisplayOffsetY="-16">
     </ew:CalendarPopup>
     </td>
     </tr>
    </table>
     <asp:Repeater ID="R" runat="server" DataSourceID="dsAccountEmployeeTimeEntry" >
     <HeaderTemplate>
     <ul data-filter="true" data-inset="True" data-role="listview"  data-split-theme="d" data-split-icon="delete" data-theme="d" >
     </HeaderTemplate>
     <ItemTemplate>
     <li>
     <asp:LinkButton ID="lnkDayView" style="font-size:8pt " postbackurl='<%# Eval("AccountEmployeeTimeEntryId", "~/Mobile/AccountEmployeeTimeEntryForm.aspx?ViewType=DayView&AccountEmployeeTimeEntryId={0}") %>' Text='<%# Eval("TaskName") & " - " & LocaleUtilitiesBLL.ConvertStringToTimeEntryTotalTimeFormat(Eval("TotalTime"))%>' tooltip='<%# Eval("TaskName") & " - " & LocaleUtilitiesBLL.ConvertStringToTimeEntryTotalTimeFormat(Eval("TotalTime"))%>' runat="server" > </asp:LinkButton>
     <asp:LinkButton ID="lnkDelete" OnClientClick="<%# ResourceHelper.GetDeleteMessageJavascript()%>" postbackurl='<%# Eval("AccountEmployeeTimeEntryId", "~/Mobile/AccountEmployeeTimeEntryPeriodView.aspx?IsDelete=True&AccountEmployeeTimeEntryId={0}") %>' Text="Delete" runat="server" > </asp:LinkButton>                
     </li>
     </ItemTemplate>
     <FooterTemplate>
     </ul>
     </FooterTemplate>
      </asp:Repeater>
     <asp:Button ID="btnAdd" runat="server" Text="Add" UseSubmitBehavior="False" data-inline="true"/>
     <asp:ObjectDataSource ID="dsAccountEmployeeTimeEntry" runat="server"
            InsertMethod="AddAccountEmployeeTimeEntry" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetAccountEmployeeTimeEntriesByDateForMobile" TypeName="AccountEmployeeTimeEntryBLL"
            UpdateMethod="UpdateAccountEmployeeTimeEntry">
            <UpdateParameters>
                <asp:Parameter Name="AccountEmployeeId" Type="Int32" />
                <asp:Parameter Name="TimeEntryDate" Type="DateTime" />
                <asp:Parameter Name="StartTime" Type="String" />
                <asp:Parameter Name="EndTime" Type="String" />
                <asp:Parameter Name="TotalTime" Type="String" />
                <asp:Parameter Name="AccountProjectId" Type="Int32" />
                <asp:Parameter Name="AccountProjectTaskId" Type="Int32" />
                <asp:Parameter Name="Description" Type="String" />
                <asp:Parameter Name="Approved" Type="Boolean" />
                <asp:Parameter Name="TeamLeadApproved" Type="Boolean" />
                <asp:Parameter Name="ProjectManagerApproved" Type="Boolean" />
                <asp:Parameter Name="AdministratorApproved" Type="Boolean" />
                <asp:Parameter Name="ModifiedOn" Type="DateTime" />
                <asp:Parameter Name="Original_AccountEmployeeTimeEntryId" Type="Int32" />
                <asp:Parameter Name="AccountPartyId" Type="Int32" />
                <asp:Parameter Name="Submitted" Type="Boolean" />
                <asp:Parameter Name="AccountWorkTypeId" Type="Int32" />
                <asp:Parameter Name="AccountCostCenterId" Type="Int32" />
                <asp:Parameter Name="TimesheetPeriodType" Type="String" />
                <asp:Parameter Name="PeriodStartDate" Type="DateTime" />
                <asp:Parameter Name="PeriodEndDate" Type="DateTime" />
                <asp:Parameter Name="AccountEmployeeTimeEntryPeriodId" />
                <asp:Parameter Name="IsTimeOff" Type="Boolean" />
                <asp:Parameter Name="AccountTimeOffTypeId" />
                <asp:Parameter Name="AccountEmployeeTimeEntryApprovalProjectId" />
            </UpdateParameters>
            <InsertParameters>
                <asp:Parameter Name="AccountEmployeeId" Type="Int32" />
                <asp:Parameter Name="TimeEntryDate" Type="DateTime" />
                <asp:Parameter Name="StartTime" Type="String" />
                <asp:Parameter Name="EndTime" Type="String" />
                <asp:Parameter Name="TotalTime" Type="String" />
                <asp:Parameter Name="AccountProjectId" Type="Int32" />
                <asp:Parameter Name="AccountProjectTaskId" Type="Int32" />
                <asp:Parameter Name="Description" Type="String" />
                <asp:Parameter Name="Approved" Type="Boolean" />
                <asp:Parameter Name="CreatedOn" Type="DateTime" />
                <asp:Parameter Name="ModifiedOn" Type="DateTime" />
                <asp:Parameter Name="AccountPartyId" Type="Int32" />
                <asp:Parameter Name="Submitted" Type="Boolean" />
                <asp:Parameter Name="AccountWorkTypeId" Type="Int32" />
                <asp:Parameter Name="AccountCostCenterId" Type="Int32" />
                <asp:Parameter Name="TimesheetPeriodType" Type="String" />
                <asp:Parameter Name="PeriodStartDate" Type="DateTime" />
                <asp:Parameter Name="PeriodEndDate" Type="DateTime" />
                <asp:Parameter Name="AccountEmployeeTimeEntryPeriodId" />
                <asp:Parameter Name="IsTimeOff" Type="Boolean" />
                <asp:Parameter Name="AccountTimeOffTypeId" />
                <asp:Parameter Name="AccountEmployeeTimeOffRequestId" />
                <asp:Parameter Name="AccountEmployeeTimeEntryApprovalProjectId" />
            </InsertParameters>
            <SelectParameters>
                <asp:SessionParameter DefaultValue="" Name="AccountEmployeeId" SessionField="AccountEmployeeId"
                    Type="Int32" />
                <asp:Parameter DefaultValue="8/29/2006" Name="TimeEntryDate" Type="DateTime" />
                <asp:Parameter DefaultValue="" Name="IsCopy" Type="Boolean" />
                <asp:Parameter DefaultValue="True" Name="IsFromMobile" Type="Boolean" />
            </SelectParameters>
        </asp:ObjectDataSource>
       </div>                       

 