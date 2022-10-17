<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlLeaveSummaryReport.ascx.vb" Inherits="Reports_ControlsViewer_ctlLeaveSummaryReport" %>
<%@ Register Assembly="DevExpress.XtraReports.v11.1.Web"
    Namespace="DevExpress.XtraReports.Web" TagPrefix="dxxr" %>
<%@ Register Assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24D65337282035F2"
    Namespace="eWorld.UI" TagPrefix="ew" %>
<%@ Register Assembly="C1.Web.C1WebReport.2" Namespace="C1.Web.C1WebReport" TagPrefix="cc1" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <table class="xFormView" style="width: 400px">
            <tr>
                <td class="caption" colspan="2">
                    <asp:Literal ID="Literal1" runat="server" Text="<%$ Resources:TimeLive.Resource, Leave Summary Report%> " /></td>
            </tr>
            <tr>
                <td class="formviewsubheader" colspan="2">
                    <asp:Literal ID="Literal2" runat="server" Text="<%$ Resources:TimeLive.Resource, Search Parameters%> " /></td>
            </tr>
            <tr>
                <td align="right" class="formviewlabelcell" style="width: 40%">
                    <asp:Literal ID="Literal3" runat="server" Text="<%$ Resources:TimeLive.Resource, Employees:%> " /></td>
                <td align="left" style="width: 60%">
                    <asp:DropDownList ID="ddlEmployees" runat="server"
                        DataTextField="EmployeeNameWithCode" DataValueField="AccountEmployeeId" Height="22px"
                        Width="186px">
                    </asp:DropDownList>&nbsp;
                </td>
            </tr>
            <tr>
                <td align="right" class="formviewlabelcell" style="width: 40%">
                    <asp:Literal ID="Literal4" runat="server" Text="<%$ Resources:TimeLive.Resource, Include Date Range:%> " /></td>
                <td align="left" style="width: 60%">
                    <asp:CheckBox ID="chkIncludeDateRange" runat="server" /></td>
            </tr>
            <tr>
                <td align="right" class="formviewlabelcell" style="width: 40%">
                    <asp:Literal ID="Literal5" runat="server" Text="<%$ Resources:TimeLive.Resource, Start Date:%> " /></td>
                <td align="left" style="width: 60%">
                    <ew:CalendarPopup ID="txtStartDate" runat="server">
                    </ew:CalendarPopup>
                </td>
            </tr>
            <tr>
                <td align="right" class="formviewlabelcell" style="width: 40%">
                    <asp:Literal ID="Literal6" runat="server" Text="<%$ Resources:TimeLive.Resource, End Date:%> " /></td>
                <td align="left" style="width: 60%">
                    <ew:CalendarPopup ID="txtEndDate" runat="server">
                    </ew:CalendarPopup>
                </td>
            </tr>
            <tr>
                <td align="right" class="formviewlabelcell" style="width: 40%">
                </td>
                <td align="left" style="width: 60%">
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
        <br />
<dxxr:reporttoolbar id="ReportToolbar1" runat="server" reportviewer="<%# ReportViewer1 %>"
    showdefaultbuttons="False">
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
</dxxr:reporttoolbar>
<dxxr:reportviewer id="ReportViewer1" runat="server"></dxxr:reportviewer>
    </ContentTemplate>
</asp:UpdatePanel>
