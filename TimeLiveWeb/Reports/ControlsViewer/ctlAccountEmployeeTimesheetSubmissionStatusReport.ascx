<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlAccountEmployeeTimesheetSubmissionStatusReport.ascx.vb" Inherits="Reports_ControlsViewer_ctlAccountEmployeeTimesheetSubmissionStatusReport" %>
<%@ Register Assembly="DevExpress.XtraReports.v11.1.Web"
    Namespace="DevExpress.XtraReports.Web" TagPrefix="dxxr" %>
<%@ Register Assembly="eWorld.UI"
    Namespace="eWorld.UI" TagPrefix="ew" %>
<%@ Register Assembly="C1.Web.C1WebReport.2" Namespace="C1.Web.C1WebReport" TagPrefix="cc1" %>
<asp:UpdatePanel ID="UpdatePanel2" runat="server">
    <ContentTemplate>
    <table class="xFormView" style="width: 700px"><tr><td>
        <table class="xFormView" style="width: 700px">
            <tr>
                <th class="caption" colspan="2">
                    <asp:Literal ID="Literal3" runat="server" Text="<%$ Resources:TimeLive.Resource, Employee Timesheet Submission Status Report%> " /></th>
            </tr>
            <tr>
                <th class="FormViewSubHeader" colspan="2">
                    <asp:Literal ID="Literal1" runat="server" Text="<%$ Resources:TimeLive.Resource, Search Parameters%> " /></th>
            </tr>   
            <tr>
                <td align="right" class="FormViewLabelCell" style="width: 30%">
                    <asp:Literal ID="Literal2" runat="server" Text="<%$ Resources:TimeLive.Resource, Department:%> " /></td>
                <td style="width: 70%">
                    <asp:DropDownList ID="ddlDepartment" runat="server" AppendDataBoundItems="True" DataSourceID="dsDepartmentObject"
                        DataTextField="DepartmentName" DataValueField="AccountDepartmentId"
                        Width="300px">
                        <asp:ListItem Selected="True" Value="0" Label ID="Label1" runat="server" Text="<%$ Resources:TimeLive.Resource, ALLs%> "></asp:ListItem>
                        <%--<asp:ListItem Selected="True" Value="0">&lt;ALL&gt;</asp:ListItem>--%>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td align="right" class="FormViewLabelCell" style="width: 30%;">
                    <asp:Literal ID="Literal4" runat="server" Text="<%$ Resources:TimeLive.Resource, Employees:%> " /></td>
                <td align="left" style="width: 70%;">
                    <asp:DropDownList ID="ddlEmployees" runat="server" AppendDataBoundItems="True"
                        DataTextField="EmployeeNameWithCode" DataValueField="AccountEmployeeId" 
                        Width="300px">
                        <asp:ListItem Selected="True" Value="0" Label ID="Label2" runat="server" Text="<%$ Resources:TimeLive.Resource, ALLs%> "></asp:ListItem>
                        <%--<asp:ListItem Selected="True" Value="0">&lt;ALL&gt;</asp:ListItem>--%>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                    <td style="width: 30%" class="FormViewLabelCell">
                    <asp:Literal ID="Literal5" runat="server" Text="<%$ Resources:TimeLive.Resource, Start Date:%> " /></td>
                    <td style="width: 70%">
                                <ew:CalendarPopup ID="StartDate" runat="server">
                    </ew:CalendarPopup>
                    </td>
           </tr>
           <tr>
                    <td style="width: 30%" class="FormViewLabelCell">
                          <asp:Literal ID="Literal6" runat="server" Text="<%$ Resources:TimeLive.Resource, End Date:%> " /></td>
                    <td style="width: 70%">
                          <ew:CalendarPopup ID="EndDate" runat="server">
                    </ew:CalendarPopup>
                    <asp:CheckBox ID="chkIncludeDateRange" runat="server" Visible="False" Width="1px" />
                    <asp:DropDownList ID="ddlApproved" runat="server" AppendDataBoundItems="True" Visible="False">
                        <asp:ListItem Value="1">Approved</asp:ListItem>
                        <asp:ListItem Value="0">Not Approved</asp:ListItem>
                        <asp:ListItem Selected="True" Value="-1">Both</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td align="right" class="FormViewLabelCell" style="width: 30%">
                </td>
                <td align="left" style="width: 70%">
                    <asp:Button ID="Show" runat="server" OnClick="Show_Click" Text="<%$ Resources:TimeLive.Resource, Show_text%> " /></td>
            </tr>
        </table>
        </td></tr></table>
        <asp:ObjectDataSource ID="dsEmployeesObject" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetAccountEmployeesViewByAccountId" TypeName="AccountEmployeeBLL">
            <SelectParameters>
                <asp:SessionParameter DefaultValue="64" Name="AccountId" SessionField="AccountId"
                    Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="dsDepartmentObject" runat="server" DeleteMethod="DeleteAccountDepartment"
            InsertMethod="AddAccountDepartment" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetAccountDepartmentsByAccountId" TypeName="AccountDepartmentBLL"
            UpdateMethod="UpdateAccountDepartment">
            <DeleteParameters>
                <asp:Parameter Name="Original_AccountDepartmentId" Type="Int32" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="AccountId" Type="Int32" />
                <asp:Parameter Name="DepartmentCode" Type="String" />
                <asp:Parameter Name="DepartmentName" Type="String" />
                <asp:Parameter Name="original_AccountDepartmentId" Type="Int32" />
                <asp:Parameter Name="IsDisabled" Type="Boolean" />
                <asp:Parameter Name="IsDeleted" Type="Boolean" />
                <asp:Parameter Name="CreatedOn" Type="DateTime" />
                <asp:Parameter Name="ModifiedOn" Type="DateTime" />
                <asp:Parameter Name="CreatedByEmployeeId" Type="Int32" />
                <asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" />
            </UpdateParameters>
            <SelectParameters>
                <asp:SessionParameter Name="AccountId" SessionField="AccountId" Type="Int32" />
            </SelectParameters>
            <InsertParameters>
                <asp:Parameter Name="AccountId" Type="Int32" />
                <asp:Parameter Name="DepartmentCode" Type="String" />
                <asp:Parameter Name="DepartmentName" Type="String" />
                <asp:Parameter Name="CreatedByEmployeeId" Type="Int32" />
                <asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" />
            </InsertParameters>
        </asp:ObjectDataSource>
        <br />
<dxxr:reporttoolbar id="ReportToolbar1" runat="server" reportviewer="<%# ReportViewer1 %>" ClientIDMode="AutoID"
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
<br />