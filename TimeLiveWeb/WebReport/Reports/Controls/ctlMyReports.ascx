<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlMyReports.ascx.vb" Inherits="WebReport_Reports_Controls_ctlMyReports" %>
    <div>
        <table width="98%">
            <tr>
                <td align="left" style="width: 100px; height: 21px">
                <div style="margin:5px;">
        <asp:Button ID="Button1" runat="server" Text="<%$ Resources:TimeLive.Resource, Add New Report%>" 
                        PostBackUrl="~/WebReport/ReportDesign.aspx" /></td>
                        </div>
            </tr>
        </table>
        <br />
        <x:GridView ID="GridView1" PageSize="500" runat="server" DataSourceID="dsAccountReportObject" SkinID="xgridviewskinemployee" AutoGenerateColumns="False" Width="98%" DataKeyNames="AccountReportId,AccountId" Caption="<%$ Resources:TimeLive.Resource, My Reports %>">
            <Columns>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Report Name %>"><EditItemTemplate>
<asp:TextBox id="TextBox1" Text='<%# Bind("ReportName") %>' runat="server" __designer:wfdid="w4"></asp:TextBox> 
</EditItemTemplate>

<ItemStyle HorizontalAlign="Left" Width="90%"></ItemStyle>

<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
<ItemTemplate>
<TABLE class="xTableWithoutBorder" width="98%"><TBODY><TR><TD style="WIDTH: 51px" rowSpan=2><asp:ImageButton id="ReportIconImage" runat="server" Width="40px" Height="40px" PostBackUrl='<%# Eval("AccountReportId", "~/WebReport/ShowReport.aspx?AccountReportId={0}") %>' __designer:wfdid="w1" Visible="False"></asp:ImageButton></TD><TD style="HEIGHT: 21px"><asp:HyperLink id="ReportNameHyperLink" runat="server" __designer:wfdid="w10" NavigateUrl='<%# Eval("AccountReportId", "~/WebReport/ShowReport.aspx?AccountReportId={0}") %>' CssClass="bolda">[ReportNameHyperLink]</asp:HyperLink></TD></TR><TR><TD><asp:Label id="ReportDescriptionLabel" Text='<%# Eval("ReportDescription") %>' runat="server" __designer:wfdid="w11"></asp:Label></TD></TR></TBODY></TABLE>
</ItemTemplate>
</asp:TemplateField>
                <asp:TemplateField HeaderText="Test" Visible="False"></asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Customize %>" >

<ItemStyle Width="4%" horizontalalign="Center"></ItemStyle>
<ItemTemplate>
<asp:HyperLink id="CustomizeHyperLink" runat="server" __designer:wfdid="w2" Visible="False" text="<%$ Resources:TimeLive.Resource, Customize %>" NavigateUrl='<%# Eval("AccountReportId", "~/WebReport/ReportDesign.aspx?AccountReportId={0}") %>'></asp:HyperLink> 
</ItemTemplate>
</asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Permissions %>">

<ItemStyle Width="4%" horizontalalign="Center"></ItemStyle>
<ItemTemplate>
<asp:HyperLink id="PermissionHyperLink" runat="server" __designer:wfdid="w3" Visible="False" text="<%$ Resources:TimeLive.Resource, Permissions %>" NavigateUrl='<%# Eval("AccountReportId", "~/WebReport/AccountReportPermission.aspx?AccountReportId={0}") %>'></asp:HyperLink> 
</ItemTemplate>
</asp:TemplateField>

                        <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Delete_text %>" ShowHeader="False">

<ItemStyle HorizontalAlign="Center" CssClass="delete_button" Width="38px"></ItemStyle>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemTemplate>
<asp:LinkButton id="LinkButton1" runat="server" PostBackUrl='<%# Eval("AccountReportId", "~/WebReport/Reports/DeleteReport.aspx?AccountReportId={0}") %>' __designer:wfdid="w5" Visible='<%# IIF(isdbnull(Eval("AccountId")),"False","True") %>' CausesValidation="False" OnClientClick="<%# ResourceHelper.GetDeleteMessageJavascript() %>"></asp:LinkButton> 
</ItemTemplate>
</asp:TemplateField>
                <asp:TemplateField ShowHeader="False" HeaderText="<%$ Resources:TimeLive.Resource, Copy %>">
                    <itemstyle horizontalalign="Center" width="38px" />
                    <itemtemplate>
<asp:HyperLink id="CopyHyperLink" runat="server" __designer:wfdid="w4" text="<%$ Resources:TimeLive.Resource, Copy %>" NavigateUrl='<%# Eval("AccountReportId", "~/WebReport/MyReports.aspx?AccountReportId={0}&IsCopy=True") %>'></asp:HyperLink> 
</itemtemplate>
                </asp:TemplateField>
            </Columns>
        </x:GridView>
        <asp:ObjectDataSource ID="dsAccountReportObject" runat="server"
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetDataForMyReportGrid" TypeName="TimeLive.WebReport.ReportDesignBLL">
            <SelectParameters>
                <asp:SessionParameter DefaultValue="151" Name="AccountId" SessionField="AccountId"
                    Type="Int32" />
                <asp:Parameter Name="AccountRoles" Type="String" />
                <asp:Parameter Name="IsShowAll" Type="Boolean" />
                <asp:Parameter Name="ShowVisible" Type="Boolean" DefaultValue ="False"/>
            </SelectParameters>
        </asp:ObjectDataSource>
        </div>