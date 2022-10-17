<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlAccountEmployeeTimeEntryWeekViewDescriptionReadOnly.ascx.vb" Inherits="Employee_Controls_ctlAccountEmployeeTimeEntryWeekViewDescriptionReadOnly" %>
<style type="text/css">
    .style1
    {
        width: 100%;
    }
</style>
<asp:GridView ID="GridView1" runat="server" DataSourceID="dsAccountEmployeeTimeEntryApprovalWeekViewDescriptionReadOnly" 
AutoGenerateColumns="False" CssClass="xGridViewInside" AllowSorting="True" 
Caption="<%$ Resources:TimeLive.Resource, Comments List %>" Width="99%" PageSize="500">
    <Columns>
        <asp:TemplateField SortExpression="ProjectName" HeaderText="<%$ Resources:TimeLive.Resource, Project Name %>">
            <EditItemTemplate>
                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("ProjectName") %>'></asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="Label1" runat="server" Text='<%# Bind("ProjectName") %>'></asp:Label>
            </ItemTemplate>
            <ControlStyle Font-Bold="True" />
            <ItemStyle Font-Bold="True" HorizontalAlign="Left" VerticalAlign="Middle" Width="20%" />
            <HeaderTemplate>
                <asp:Label ID="lblProjectName" runat="server" Text='<%# ResourceHelper.GetFromResource("Project Name") %>'></asp:Label>
            </HeaderTemplate>
        </asp:TemplateField>
        <asp:TemplateField SortExpression="TaskName" HeaderText="<%$ Resources:TimeLive.Resource, Task Name %>">
            <EditItemTemplate>
                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("TaskName") %>'></asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="Label2" runat="server" Text='<%# Bind("TaskName") %>'></asp:Label>
            </ItemTemplate>
            <ControlStyle Font-Bold="True" />
            <ItemStyle Font-Bold="True" HorizontalAlign="Left" VerticalAlign="Middle" Width="20%" />
            <HeaderTemplate>
                <asp:Label ID="lblTaskName" runat="server" Text='<%# ResourceHelper.GetFromResource("Task Name") %>'></asp:Label>
            </HeaderTemplate>
        </asp:TemplateField>
        <asp:TemplateField SortExpression="TimeEntryDate" HeaderText="<%$ Resources:TimeLive.Resource, Date %>">
            <EditItemTemplate>
                <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("TimeEntryDate") %>'></asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="Label3" runat="server" Text='<%# Bind("TimeEntryDate", "{0:d}") %>'></asp:Label>
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="8%" />
            <HeaderTemplate>
                <asp:Label ID="lblTimeEntryDate" runat="server" Text='<%# ResourceHelper.GetFromResource("Date") %>'></asp:Label>
            </HeaderTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Total Time" SortExpression="TotalTime">
            <EditItemTemplate>
                <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("TotalTime") %>'></asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="lblTotalTime" runat="server" Text='<%# Bind("TotalTime") %>'></asp:Label>
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Center" Wrap="true"  Width="7%"/>
        </asp:TemplateField>
        <asp:TemplateField SortExpression="Description" HeaderText="<%$ Resources:TimeLive.Resource, Description %>">
            <EditItemTemplate>
                <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("Description") %>'></asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="Label4" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="50%" />
            <HeaderTemplate>
                <asp:Label ID="lblDescription" runat="server" Text='<%# ResourceHelper.GetFromResource("Description") %>'></asp:Label>
            </HeaderTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
<asp:TextBox ID="lblTimesheetPrintFooter" runat="server" BorderStyle="None" BorderWidth="0px"
    Font-Bold="True" Height="125px" ReadOnly="True" Style="overflow: hidden" TextMode="MultiLine"
    Width="99%"></asp:TextBox>
    <br />
    <br />
    <br />
<%If LocaleUtilitiesBLL.IsShowElectronicSign = True And LocaleUtilitiesBLL.IsElectronicSignExistInSessionAccount = True Then%>
    <asp:Table runat="server" Width="100%" Height="100%" BorderStyle="None" align="center" 
    BorderColor="White" CssClass="xTableWithoutBorder">
    <asp:TableRow ID="TableRow1" runat="server" Width="100%" BorderStyle="None" 
        BorderColor="White">
        <asp:TableCell runat="server"><tr><td Class="caption" style="Width:100%" colspan="2"><b>Electronic Signature</b></td>
        </tr></asp:TableCell>
        <asp:TableCell runat="server"><tr><td align="left" style="Width:15%"><b>Signed By:</b></td>
        <td align="left" style="Width:85%"><b><asp:Label ID="lblSignedBy" runat="server"></asp:Label></b></td></tr></asp:TableCell>
        <asp:TableCell runat="server"><tr><td align="left" style="Width:15%"><b>Signature:</b></td>
        <td align="left" style="Width:85%"> <asp:Image ID="imgElectronicSignature" runat="server" Height = "50px" align="left" ImageAlign="Top" />
        </td></tr></asp:TableCell>
        <asp:TableCell runat="server"><tr><td align="left" style="Width:15%"><b>Timestamp:</b></td>            
        <td align="left" style="Width:85%"><asp:Label ID="lblTimestamp" runat="server"></asp:Label></td></tr></asp:TableCell>
    </asp:TableRow>
</asp:Table>
<%End If%>
<asp:ObjectDataSource ID="dsAccountEmployeeTimeEntryApprovalWeekViewDescriptionReadOnly"
    runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetAccountEmployeeTimeEntriesByDateRangeForDescriptionReadOnlyView" TypeName="AccountEmployeeTimeEntryBLL">
    <SelectParameters>
        <asp:Parameter DefaultValue="964" Name="AccountEmployeeId" Type="Int32" />
        <asp:Parameter DefaultValue="" Name="TimeEntryStartDate" Type="DateTime" />
        <asp:Parameter Name="TimeEntryEndDate" Type="DateTime" />
    </SelectParameters>
</asp:ObjectDataSource>

<asp:ObjectDataSource ID="dsAccountEmployeeTimeEntryApprovalWeekViewDescriptionReadOnlyForRelevantProject"
    runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetAccountEmployeeTimeEntriesByDateRangeForDescriptionReadOnlyViewForRelevantProject" TypeName="AccountEmployeeTimeEntryBLL">
    <SelectParameters>
        <asp:Parameter DefaultValue="964" Name="AccountEmployeeId" Type="Int32" />
        <asp:Parameter DefaultValue="" Name="TimeEntryStartDate" Type="DateTime" />
        <asp:Parameter Name="TimeEntryEndDate" Type="DateTime" />
        <asp:SessionParameter DefaultValue="" Name="ViewerAccountEmployeeId" SessionField="AccountEmployeeId"
            Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>


