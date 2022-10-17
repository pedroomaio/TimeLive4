<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlAccountEmployeeTimeOffAudit.ascx.vb" Inherits="Employee_Controls_ctlAccountEmployeeTimeOffAudit" %>


<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
 <div class="fieldset" style="width: 96%; margin-left: 6px; height: 16px;" align="left"> 
<table width="100%">
<tr>
<td width="50px" >
            <asp:Label ID="Label15" runat="server" Text="<%$ Resources:TimeLive.Resource, Employee Name: %>"
            Font-Bold="True" Font-Size="11px" Width="95px" CssClass="HighlightedText"/>
                </td>
<td>
<asp:Label ID="lblEmployeeName" runat="server" Text="<%$ Resources:TimeLive.Resource, Employee Name: %>" 
Font-Size="11px" Width="80%" CssClass="HighlightedText"/>
</td>
</tr>
</table>
</div>
<x:GridView ID="TimeOffAuditGridView" runat="server" AutoGenerateColumns="False" Caption="<%$ Resources:TimeLive.Resource, Employee Time Off Audit %>"
            DataSourceID="ObjEmployeeTimeOffAudit" Width="98%" 
        SkinID="xgridviewSkinEmployee" DataKeyNames="AccountEmployeeTimeOffAuditId">
    <Columns>
             <asp:BoundField DataField="ExecutedDate" HeaderText="<%$ Resources:TimeLive.Resource, Executed Date%> " DataFormatString="{0:d}" HtmlEncode="False" SortExpression="ExecutedDate">
                    <ItemStyle Width="9%" horizontalalign="Center" />
                </asp:BoundField>
             <asp:TemplateField SortExpression="TimeOffType" 
                    HeaderText="Time Off Type">
                     <ItemTemplate>
                         <asp:Label ID="lblAccountTimeOffType" runat="server" Text='<%# Bind("TimeOffType") %>'></asp:Label>
                     </ItemTemplate>
                     <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="9%" />
                </asp:TemplateField>
             <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Earned%> " ItemStyle-HorizontalAlign="Right" ItemStyle-VerticalAlign="Middle">
                    <ItemTemplate>
                     <asp:Label ID="lblEarned" runat="server" 
                            Text='<%# Bind("EarnedHours") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="5%" />
                </asp:TemplateField>
             <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Consumed%> " ItemStyle-HorizontalAlign="Right" ItemStyle-VerticalAlign="Middle">
                    <ItemTemplate>
                     <asp:Label ID="lblConsume" runat="server" Text='<%# Bind("ConsumeHours") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="5%" />
                </asp:TemplateField>
             <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Available%> " ItemStyle-HorizontalAlign="Right" ItemStyle-VerticalAlign="Middle">
                    <ItemTemplate>
                     <asp:Label ID="lblAvailable" runat="server" 
                            Text='<%# Bind("AvailableHours") %>'></asp:Label>
                   </ItemTemplate>
                   <ItemStyle Width="5%" />
                </asp:TemplateField>
             <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Carry Forward%> " ItemStyle-HorizontalAlign="Right" ItemStyle-VerticalAlign="Middle">
                    <ItemTemplate>
                     <asp:Label ID="lblCarryForward" runat="server" Text='<%# Bind("CarryForward") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="8%" />
                </asp:TemplateField>
             <asp:BoundField DataField="LastEarnedDate" HeaderText="<%$ Resources:TimeLive.Resource, Last Earned Date%> " DataFormatString="{0:d}" HtmlEncode="False">
                    <ItemStyle Width="7%" horizontalalign="Center" />
              </asp:BoundField>
             <asp:BoundField DataField="LastResetDate" HeaderText="<%$ Resources:TimeLive.Resource, Last Reset Date%> " DataFormatString="{0:d}" HtmlEncode="False">
                    <ItemStyle Width="7%" horizontalalign="Center" />
                </asp:BoundField>
             <asp:BoundField DataField="AuditPeriodType" HeaderText="<%$ Resources:TimeLive.Resource, Audit Period Type%> " ItemStyle-HorizontalAlign="Left">
                    <itemstyle width="10%" />
                </asp:BoundField>
             <asp:BoundField DataField="AuditAction" HeaderText="<%$ Resources:TimeLive.Resource, Audit Action%> " ItemStyle-HorizontalAlign="Left">
                    <itemstyle width="15%" />
                </asp:BoundField>
             <asp:BoundField DataField="ExecutionType" HeaderText="<%$ Resources:TimeLive.Resource, Execution Type%> " ItemStyle-HorizontalAlign="Left">
                    <itemstyle width="9%" />
                </asp:BoundField>
             <asp:BoundField DataField="AuditSource" HeaderText="<%$ Resources:TimeLive.Resource, Audit Source%> " ItemStyle-HorizontalAlign="Left">
                    <itemstyle width="9%" />
                </asp:BoundField>
    </Columns>
</x:GridView>
<asp:ObjectDataSource ID="ObjEmployeeTimeOffAudit" runat="server" 
    OldValuesParameterFormatString="original_{0}" 
    SelectMethod="GetvueAccountEmployeeTimeOffAuditByAccountEmployeeIdandAccountTimeOffTypeId" 
    TypeName="AccountEmployeeTimeOffBLL" 
        InsertMethod="UpdatePolicyIdByEmployeePolicyChanged">
    <InsertParameters>
        <asp:Parameter Name="AccountEmployeeId" Type="Int32" />
        <asp:Parameter DbType="Guid" Name="AccountTimeOffPolicyId" />
        <asp:Parameter DbType="Guid" Name="Original_AccountTimeOffPolicyId" />
    </InsertParameters>
    <SelectParameters>
        <asp:QueryStringParameter Name="AccountEmployeeId" 
            QueryStringField="AccountEmployeeId" Type="Int32" />
        <asp:QueryStringParameter DbType="Guid" Name="AccountTimeOffTypeId" 
            QueryStringField="AccountTimeOffTypeId" />
    </SelectParameters>
</asp:ObjectDataSource>
</ContentTemplate>
</asp:UpdatePanel>
