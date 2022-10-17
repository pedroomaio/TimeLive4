<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlAccountEmployeeTimeEntryPeriodList.ascx.vb" Inherits="Employee_Controls_ctlAccountEmployeeTimeEntryPeriodList" %>
<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<asp:UpdatePanel ID="UpdatePanel2" runat="server">
    <ContentTemplate>
    <table class="xFormView" width="100%" ><tr><td>
        <table class="xFormView" width="50%">
            <tr>
                <th class="caption" colspan="2">
                    <asp:Literal ID="Literal1" runat="server" Text="<%$ Resources:TimeLive.Resource, Timesheet Period List%>"></asp:Literal></th>
            </tr>
            <tr>
                <th class="FormViewSubHeader" colspan="2">
                    <asp:Literal ID="Literal2" runat="server" Text="<%$ Resources:TimeLive.Resource, Search Parameter%> "></asp:Literal></th>
            </tr>
            <tr>
                <td align="right" style="width: 25%">
                    <asp:Literal ID="Literal7" runat="server" Text="<%$ Resources:TimeLive.Resource, Employee Name:%> "></asp:Literal></td>
                <td style="width: 75%">
                    <asp:DropDownList ID="ddlEmployee" runat="server" Width="250px" OnSelectedIndexChanged="ddlEmployee_SelectedIndexChanged">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td align="right" style="width: 25%">
                    <asp:Literal ID="Literal3" runat="server" Text="<%$ Resources:TimeLive.Resource, Approval Status:%> "></asp:Literal></td>
                <td style="width: 75%" colspan="1">
                    <asp:DropDownList ID="ddlApprovalStatus" runat="server" Width="250px">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td align="right" style="width: 25%">
                    <asp:Literal ID="Literal4" runat="server" Text="<%$ Resources:TimeLive.Resource, Include Date Range:%> "></asp:Literal></td>
                <td style="width: 75%" colspan="1">
                    <asp:CheckBox ID="chkIncludeDateRange" runat="server" /></td>
            </tr>
            <tr>
                <td align="right" style="width: 25%">
                    <asp:Literal ID="Literal5" runat="server" Text="<%$ Resources:TimeLive.Resource, Start Date:%> "></asp:Literal></td>
                <td style="width: 75%" class="formviewlabelcell" colspan="1">
                    <ew:calendarpopup id="StartDateTextBox" runat="server" width="55px"></ew:calendarpopup>
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 25%">
                    <asp:Literal ID="Literal6" runat="server" Text="<%$ Resources:TimeLive.Resource, End Date:%> "></asp:Literal></td>
                <td style="width: 75%" colspan="1">
                    <ew:calendarpopup id="EndDateTextBox" runat="server" width="55px">
        </ew:calendarpopup>
                    </td>
            </tr>
            <tr>
                <td align="right" style="width: 25%">
                </td>
                <td style="width: 75%" class="formviewlabelcell" colspan="1">
                    <asp:Button ID="btnShow" runat="server" OnClick="btnShow_Click" Text="<%$ Resources:TimeLive.Resource, Show_text%> " />
                    </td>
            </tr>
            <tr>
                <td align="right" style="width: 25%">
                </td>
                <td align="right" class="formviewlabelcell" colspan="1" 
                    style="padding-bottom: 5px; padding-top: 5px; padding-right: 5px;" >
                    <asp:Button ID="btnAddTimesheet" runat="server" OnClick="btnAddTimesheet_Click" Text="Add Timesheet" /></td>
            </tr>
        </table>
        </td></tr></table>
    </ContentTemplate>
</asp:UpdatePanel>
<br />
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <x:GridView ID="GridView1" runat="server" SkinID="xgridviewSkinEmployee" 
            AutoGenerateColumns="False" DataKeyNames="AccountEmployeeTimeEntryPeriodId"
            DataSourceID="dsAccountEmployeeTimeEntryPeriodListObject" 
            CssClass="xgridview" Width="98%" AllowPaging="True" 
            Caption="<%$ Resources:TimeLive.Resource, Timesheet Period List %>">
            <Columns>
<asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Period %>">
<ItemStyle Width="150px" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
<ItemTemplate>
<asp:Label id="lblPSD" runat="server" __designer:wfdid="w8"></asp:Label>&nbsp;- <asp:Label id="lblPED" runat="server" __designer:wfdid="w8"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:BoundField DataField="TimeEntryViewType" HeaderText="<%$ Resources:TimeLive.Resource, Period Type %>">
<ItemStyle Width="150px" VerticalAlign="Middle"></ItemStyle>
</asp:BoundField>
<asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Total Duration %>">
<ItemStyle Width="100px" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
<ItemTemplate>
<asp:Label id="lblTotalDuration" runat="server" __designer:wfdid="w1"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:BoundField ReadOnly="True" DataField="TotalHours" HeaderText="<%$ Resources:TimeLive.Resource, Total Hours %>">
<ItemStyle Width="75px" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
</asp:BoundField>
<asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Timesheet Status %>">
<ItemStyle Width="100px" VerticalAlign="Middle"></ItemStyle>
<ItemTemplate>
<asp:Label id="lblTimesheetStatus" runat="server" __designer:wfdid="w13"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:BoundField HtmlEncode="False" DataFormatString="{0:d}" DataField="SubmittedDate" HeaderText="<%$ Resources:TimeLive.Resource, Submitted On %>">
<ItemStyle Width="85px" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
</asp:BoundField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Approved On %>">
                    <HeaderTemplate>
                        <asp:Label id="LABEL1" Text='<%# ResourceHelper.GetFromResource("Approved On") %>' runat="server" __designer:wfdid="w6"></asp:Label>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("ApprovedOn", "{0:d}") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("ApprovedOn") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="85px" />
                </asp:TemplateField>
<asp:BoundField HtmlEncode="False" DataFormatString="{0:d}" DataField="RejectedOn" HeaderText="<%$ Resources:TimeLive.Resource, Rejected On %>">
<ItemStyle Width="85px" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
</asp:BoundField>
<asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Open %>">
<ItemStyle Width="5px" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
<ItemTemplate>
<asp:HyperLink id="lnkEdit" runat="server" __designer:wfdid="w7">Open</asp:HyperLink> 
</ItemTemplate>
</asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Attachment %>">
                    <ItemTemplate>
<asp:HyperLink id="HyperLink1" runat="server" __designer:wfdid="w46" onclick="window.open (this.href, 'popupwindow', 'width=700,height=505,left=300,top=150,scrollbars=yes'); return false;" NavigateUrl='<%# "~/AccountAdmin/AccountAttachmentsPopUp.aspx?AccountEmployeeTimeEntryPeriodId=" & DataBinder.Eval(Container.DataItem,"AccountEmployeeTimeEntryPeriodId").tostring & "&AccountAttachmentTypeId=2"%>' ><asp:Literal ID="Literal1" runat="server" Text="<%$ Resources:TimeLive.Resource, Attachment%> " /></asp:HyperLink></ItemTemplate><ItemStyle HorizontalAlign="Left" Width="5%" />
<itemstyle HorizontalAlign="Center"  />
                </asp:TemplateField>
</Columns>
</x:GridView>
        <asp:ObjectDataSource ID="dsAccountEmployeeTimeEntryPeriodListObject" runat="server"
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetAccountEmployeeTimeEntryPeriodList"
            TypeName="AccountEmployeeTimeEntryBLL">
            <SelectParameters>
                <asp:SessionParameter Name="AccountId" SessionField="AccountId" Type="Int32" />
                <asp:Parameter Name="AccountEmployeeId" Type="Int32" />
                <asp:Parameter Name="PeriodStartDate" Type="DateTime" />
                <asp:Parameter Name="PeriodEndDate" Type="DateTime" />
                <asp:Parameter Name="IncludeDateRange" Type="Boolean" />
                <asp:Parameter Name="TimesheetApprovalStatusId" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </ContentTemplate>
</asp:UpdatePanel>
