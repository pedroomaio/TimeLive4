<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlAccountEmployeeTimeEntryWeekSummary.ascx.vb" Inherits="Employee_Controls_ctlAccountEmployeeTimeEntryWeekSummary" %>
<x:GridView ID="G" runat="server" AllowPaging="True" AutoGenerateColumns="False"
    Caption="<%$ Resources:TimeLive.Resource, My Open Timesheet Periods %>" 
    CssClass="xgridview" DataKeyNames="AccountEmployeeTimeEntryPeriodId"
    DataSourceID="dsWeekSummary" SkinID="xgridviewSkinEmployee" Width="98%">
    <Columns>
        <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Period%> ">
            <itemstyle horizontalalign="Center" verticalalign="Middle" width="150px" />
            <itemtemplate>
<asp:Label id="lblPSD" runat="server" __designer:wfdid="w3"></asp:Label>&nbsp;-&nbsp;<asp:Label id="lblPED" runat="server" __designer:wfdid="w2"></asp:Label> 
</itemtemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Duration%> ">
            <itemstyle horizontalalign="Center" verticalalign="Middle" width="100px" />
            <itemtemplate>
<asp:Label id="lblTotalDuration" runat="server" __designer:wfdid="w1"></asp:Label> 
</itemtemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Hours%> ">
            <EditItemTemplate>
                <asp:Label ID="Label1" runat="server" Text='<%# Eval("TotalHours", "{0:N}") %>'></asp:Label>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="Label1" runat="server" Text='<%# Bind("TotalHours", "{0:N}") %>'></asp:Label>
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="75px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Status%> ">
            <itemstyle horizontalalign="Left" verticalalign="Middle" width="125px" />
            <itemtemplate>
<asp:Label id="lblTimesheetStatus" runat="server" __designer:wfdid="w3"></asp:Label>
</itemtemplate>
        </asp:TemplateField>
    </Columns>
</x:GridView>
<asp:ObjectDataSource ID="dsWeekSummary" runat="server" OldValuesParameterFormatString="original_{0}"
    SelectMethod="GetAccountEmployeeTimeEntryPeriodList" TypeName="AccountEmployeeTimeEntryBLL">
    <SelectParameters>
        <asp:SessionParameter Name="AccountId" SessionField="AccountId" Type="Int32" />
        <asp:SessionParameter DefaultValue="39" Name="AccountEmployeeId" SessionField="AccountEmployeeId"
            Type="Int32" />
        <asp:Parameter DefaultValue="1/1/2010" Name="PeriodStartDate" Type="DateTime" />
        <asp:Parameter DefaultValue="1/7/2010" Name="PeriodEndDate" Type="DateTime" />
        <asp:Parameter DefaultValue="False" Name="IncludeDateRange" Type="Boolean" />
        <asp:Parameter DefaultValue="1" Name="TimesheetApprovalStatusId" Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>
