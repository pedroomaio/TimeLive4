<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlAccountEmployeeTimeEntryPeriodViewList.ascx.vb" Inherits="Mobile_Controls_ctlAccountEmployeeTimeEntryPeriodViewList" %>
<%@ Register Assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24D65337282035F2"
    Namespace="eWorld.UI" TagPrefix="ew" %>
   <div data-role="header" data-theme="a" data-position="inline">
       <h1 style="text-align:left;margin-left:15px;" ><asp:Label ID="lblheader" runat="server" Text=""></asp:Label></h1>
    </div>
     <div data-role="content" data-theme="d"> 
       <table >

       <tr>
               <td align="left" colspan="2">
        <asp:LinkButton ID="lblDayView" runat="server" >Day View</asp:LinkButton>
               </td>
           </tr>
                  <tr>
    <td align="left" colspan="2">
    <asp:Label ID="lblPeriodDate" runat="server" Text="Period Date" Font-Bold="True"  Font-Names="Tahoma" Font-Size="11px" ></asp:Label>
    </td>
    </tr>
        <tr>
    <td align="left" colspan="2">
    <asp:Label ID="Label1" runat="server" Text="Timesheet Total:" Font-Bold="True" Font-Names="Tahoma" Font-Size="11px" ></asp:Label>
    <asp:Label ID="lblTotalTime" runat="server" Text="00:00" Font-Names="Tahoma" Font-Size="11px"></asp:Label></td>
    </tr>
         <tr>
        <td valign="top">
            <asp:Label ID="Label3" runat="server" Text="Timesheet Status:" Font-Bold="True" Font-Names="Tahoma" Font-Size="11px" ></asp:Label></td>
        <td align="left"  valign="top">
    &nbsp; <asp:Image ID="imgTSL" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/clearpixel.gif"
    Width="10px" AlternateText="Timesheet Status" />
    <asp:Label ID="lblTimesheetStatus" runat="server" Text="Label" Font-Names="Tahoma" Font-Size="11px"></asp:Label></td>
    </tr>


               <tr><td valign="top" >
      <asp:Label id="lblCurrenctdate2" runat="server" Text="Time Entry Date:" Font-Bold="True" Font-Names="Tahoma" Font-Size="11px"></asp:Label></td>
      <td>
      <ew:CalendarPopup id="txtTimeEntryDate" CalendarWidth="200"  runat="server" Width="95px" ControlDisplay="TextBoxImage" ImageUrl="~/Images/spacer.gif" Text="" AutoPostBack="True" PopupLocation="Bottom" Height="20px" DisplayOffsetX="-45" DisplayOffsetY="-16" >
            </ew:CalendarPopup>
      </td>
      </tr>
    </table>
    <asp:Repeater ID="R" runat="server" DataSourceID="dsAccountEmployeeTimeEntry">
         <HeaderTemplate>
                 <ul data-filter="true" data-inset="true" data-role="listview"  data-split-theme="d" data-split-icon="delete" data-theme="d" >
             </HeaderTemplate>
                 <ItemTemplate>
                    <li >
                    <asp:LinkButton ID="lnkWeekView" style="font-size:8pt " postbackurl='<%# Eval("AccountEmployeeTimeEntryId", "~/Mobile/AccountEmployeeTimeEntryForm.aspx?ViewType=PeriodView&AccountEmployeeTimeEntryId={0}") %>' Text='<%#Eval("TimeEntryDate") & " - " & Eval("TaskName") & " - " & LocaleUtilitiesBLL.ConvertStringToTimeEntryTotalTimeFormat(Eval("TotalTime"))%>' ToolTip='<%#Eval("TimeEntryDate") & " - " & Eval("TaskName") & " - " & LocaleUtilitiesBLL.ConvertStringToTimeEntryTotalTimeFormat(Eval("TotalTime"))%>'  runat="server" > </asp:LinkButton>
                  <asp:LinkButton ID="lnkDelete" OnClientClick="<%# ResourceHelper.GetDeleteMessageJavascript()%>" postbackurl='<%# Eval("AccountEmployeeTimeEntryId", "~/Mobile/AccountEmployeeTimeEntryPeriodView.aspx?IsDelete=True&AccountEmployeeTimeEntryId={0}") %>' Text="Delete" runat="server" > </asp:LinkButton>                
                  </li>       
             </ItemTemplate>
           <FooterTemplate>
        </ul>
            </FooterTemplate>
      </asp:Repeater>
     
   <asp:Button ID="btnAdd" runat="server" Text="Add" UseSubmitBehavior="False" data-inline="true"/>
    <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click"  UseSubmitBehavior="False" data-inline="true"/>
         <asp:ObjectDataSource ID="dsAccountEmployeeTimeEntry" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetAccountEmployeeTimeEntriesForPeriodView" TypeName="AccountEmployeeTimeEntryBLL">
            <SelectParameters>
                <asp:SessionParameter DefaultValue="" Name="AccountEmployeeId" SessionField="AccountEmployeeId"
                    Type="Int32" />
                <asp:Parameter Name="TimeEntryStartDate" Type="DateTime" />
                <asp:Parameter Name="TimeEntryEndDate" Type="DateTime" />
                <asp:Parameter Name="AccountEmployeeTimeEntryPeriodId" DbType="Guid" />
                <asp:Parameter DefaultValue="" Name="IsCopy" Type="Boolean" />
                <asp:Parameter Name="CopyToStartDate" Type="DateTime" />
                <asp:Parameter Name="CopyToEndDate" Type="DateTime" />
                <asp:Parameter DefaultValue="True" Name="IsFromMobileTimeSheet" Type="Boolean" />
                <asp:Parameter DefaultValue="False" Name="IsFromTemplate" Type="Boolean" />
            </SelectParameters>
        </asp:ObjectDataSource>
       </div>