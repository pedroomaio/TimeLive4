<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlProjectSummary.ascx.vb" Inherits="Reports_ControlsViewer_ctlProjectSummaryReport" %>
<%@ Register Assembly="DevExpress.XtraReports.v11.1.Web" Namespace="DevExpress.XtraReports.Web"
    TagPrefix="dxxr" %>
<%@ Register Assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24D65337282035F2"
    Namespace="eWorld.UI" TagPrefix="ew" %>
<%@ Register Assembly="C1.Web.C1WebReport.2" Namespace="C1.Web.C1WebReport" TagPrefix="cc1" %>
<asp:UpdatePanel ID="UpdatePanel2" runat="server">
    <ContentTemplate>
        <table class="xFormView" style="width: 700px">
            <tr>
                <td class="caption" colspan="2" style="height: 1px">
                    <asp:Literal ID="Literal13" runat="server" Text="<%$ Resources:TimeLive.Resource, Project Activity Summary Report%> " /></td>
            </tr>
            <tr>
                <td class="FormViewSubHeader" colspan="2">
                    <asp:Literal ID="Literal1" runat="server" Text="<%$ Resources:TimeLive.Resource, Search Parameters%> " /></td>
            </tr>
            <tr>
                <td align="right" class="FormViewLabelCellWithBorder" style="width: 30%">
                    <asp:Literal ID="Literal2" runat="server" Text="<%$ Resources:TimeLive.Resource, Projects:%> " /></td>
                <td align="left" style="width: 70%">
                    <asp:DropDownList ID="ddlProjects" runat="server" AppendDataBoundItems="True"
                        DataTextField="ProjectName" DataValueField="AccountProjectId" Height="22px" Width="186px">
                        <%--<asp:ListItem Selected="True" Value="0">&lt;ALL&gt;</asp:ListItem>--%>
                        <asp:ListItem Selected="True" Value="0" Label ID="Label1" runat="server" Text="<%$ Resources:TimeLive.Resource, ALLs%> "></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="right" class="FormViewLabelCellWithBorder" style="width: 30%;">
                    <asp:Literal ID="Literal3" runat="server" Text="<%$ Resources:TimeLive.Resource, Employees:%> " /></td>
                <td align="left" style="width: 70%;">
                    <asp:DropDownList ID="ddlEmployees" runat="server" AppendDataBoundItems="True"
                        DataTextField="EmployeeNameWithCode" DataValueField="AccountEmployeeId" Height="22px"
                        Width="186px">
                        <asp:ListItem Selected="True" Value="0" Label ID="Label2" runat="server" Text="<%$ Resources:TimeLive.Resource, ALLs%> "></asp:ListItem>
                        <%--<asp:ListItem Selected="True" Value="0">&lt;ALL&gt;</asp:ListItem>--%>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td align="right" class="FormViewLabelCellWithBorder" style="width: 30%"><asp:Literal ID="Literal6" runat="server" Text="<%$ Resources:TimeLive.Resource, Date Range:%> " /></td>
                <td align="left" style="width: 70%">
                    <table class="xTableWithoutBorder" width="100%">
                        <tr>
                            <td class="FormViewLabelCellBold" style="width: 25%">
                    <asp:Literal ID="Literal4" runat="server" Text="<%$ Resources:TimeLive.Resource, Start Date:%> " /></td>
                            <td style="width: 75%">
                                <ew:CalendarPopup ID="StartDate" runat="server" SkinId="DatePicker">
                    </ew:CalendarPopup>
                    <asp:DropDownList ID="ddlApproved" runat="server" AppendDataBoundItems="True" Visible="False" Width="45px">
                        <asp:ListItem Value="1">Approved</asp:ListItem>
                        <asp:ListItem Value="0">Not Approved</asp:ListItem>
                        <asp:ListItem Selected="True" Value="-1">Both</asp:ListItem>
                    </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td class="FormViewLabelCellBold" style="width: 25%">
                                <asp:Literal ID="Literal5" runat="server" Text="<%$ Resources:TimeLive.Resource, End Date:%> " /></td>
                            <td style="width: 75%">
                                <ew:CalendarPopup ID="EndDate" runat="server" SkinId="DatePicker">
                    </ew:CalendarPopup>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td align="right" class="FormViewLabelCellWithBorder" style="width: 30%">
                </td>
                <td align="left" style="width: 70%">
                    <asp:Button ID="Show" runat="server" OnClick="Show_Click" Text="<%$ Resources:TimeLive.Resource, Show_text%> " /></td>
            </tr>
        </table>
        <asp:ObjectDataSource ID="dsEmployeesObject" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetAccountEmployeesViewByAccountId" TypeName="AccountEmployeeBLL">
            <SelectParameters>
                <asp:SessionParameter DefaultValue="64" Name="AccountId" SessionField="AccountId"
                    Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource
            ID="dsProjectsObject" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetAccountProjectsByAccountEmployeeId" TypeName="AccountProjectBLL">
            <SelectParameters>
                <asp:SessionParameter DefaultValue="39" Name="AccountEmployeeId" SessionField="AccountEmployeeId"
                    Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <br />
<dxxr:ReportToolbar ID="ReportToolbar1" runat="server" ReportViewer="<%# ReportViewer1 %>" ClientIDMode="AutoID"
    ShowDefaultButtons="False">
<Styles>
<LabelStyle>
<Margins MarginLeft="3px" MarginRight="3px"></Margins>
</LabelStyle>
</Styles>
<Items>
<dxxr:ReportToolbarButton ToolTip="Display the search window" ItemKind="Search"></dxxr:ReportToolbarButton>
<dxxr:ReportToolbarSeparator></dxxr:ReportToolbarSeparator>
<dxxr:ReportToolbarButton ToolTip="Print the report" ItemKind="PrintReport"></dxxr:ReportToolbarButton>
<dxxr:ReportToolbarButton ToolTip="Print the current page" ItemKind="PrintPage"></dxxr:ReportToolbarButton>
<dxxr:ReportToolbarSeparator></dxxr:ReportToolbarSeparator>
<dxxr:ReportToolbarButton Enabled="False" ToolTip="First Page" ItemKind="FirstPage"></dxxr:ReportToolbarButton>
<dxxr:ReportToolbarButton Enabled="False" ToolTip="Previous Page" ItemKind="PreviousPage"></dxxr:ReportToolbarButton>
<dxxr:ReportToolbarLabel Text="Page"></dxxr:ReportToolbarLabel>
<dxxr:ReportToolbarComboBox ItemKind="PageNumber" Width="65px"></dxxr:ReportToolbarComboBox>
<dxxr:ReportToolbarLabel Text="of"></dxxr:ReportToolbarLabel>
<dxxr:ReportToolbarTextBox IsReadOnly="True" ItemKind="PageCount"></dxxr:ReportToolbarTextBox>
<dxxr:ReportToolbarButton ToolTip="Next Page" ItemKind="NextPage"></dxxr:ReportToolbarButton>
<dxxr:ReportToolbarButton ToolTip="Last Page" ItemKind="LastPage"></dxxr:ReportToolbarButton>
<dxxr:ReportToolbarSeparator></dxxr:ReportToolbarSeparator>
<dxxr:ReportToolbarButton ToolTip="Export a report and save it to the disk" ItemKind="SaveToDisk"></dxxr:ReportToolbarButton>
<dxxr:ReportToolbarButton ToolTip="Export a report and show it in a new window" ItemKind="SaveToWindow"></dxxr:ReportToolbarButton>
<dxxr:ReportToolbarComboBox ItemKind="SaveFormat" Width="70px"><Elements>
<dxxr:ListElement Value="pdf" Text="Pdf"></dxxr:ListElement>
<dxxr:ListElement Value="xls" Text="Xls"></dxxr:ListElement>
<dxxr:ListElement Value="rtf" Text="Rtf"></dxxr:ListElement>
<dxxr:ListElement Value="mht" Text="Mht"></dxxr:ListElement>
<dxxr:ListElement Value="txt" Text="Text"></dxxr:ListElement>
<dxxr:ListElement Value="csv" Text="Csv"></dxxr:ListElement>
<dxxr:ListElement Value="png" Text="Image"></dxxr:ListElement>
</Elements>
</dxxr:ReportToolbarComboBox>
</Items>
</dxxr:ReportToolbar>
<dxxr:ReportViewer ID="ReportViewer1" runat="server">
</dxxr:ReportViewer>
    </ContentTemplate>
</asp:UpdatePanel>
&nbsp;<br />

