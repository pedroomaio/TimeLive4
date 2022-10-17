<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlTaskSummary.ascx.vb" Inherits="Reports_ControlsViewer_ctlTaskSummary" %>
<%@ Register Assembly="DevExpress.XtraReports.v11.1.Web"
    Namespace="DevExpress.XtraReports.Web" TagPrefix="dxxr" %>
<%@ Register Assembly="C1.Web.C1WebReport.2" Namespace="C1.Web.C1WebReport" TagPrefix="cc1" %>
<%@ Register Assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2"
    Namespace="eWorld.UI" TagPrefix="ew" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <table class="xFormView" style="width: 350px">
            <tr>
                <td class="caption" colspan="2">
                    <asp:Literal ID="Literal1" runat="server" Text="<%$ Resources:TimeLive.Resource, Task Summary Report%> " /></td>
            </tr>
            <tr>
                <td class="formviewsubheader" colspan="2" style="height: 21px">
                    <asp:Literal ID="Literal2" runat="server" Text="<%$ Resources:TimeLive.Resource, Search Parameters%> " /></td>
            </tr>
            <tr>
                <td align="right" class="formviewlabelcell" style="width: 40%; height: 21px">
                    <asp:Literal ID="Literal3" runat="server" Text="<%$ Resources:TimeLive.Resource, Employees:%> " /></td>
                <td style="width: 60%; height: 21px">
                    <asp:DropDownList ID="ddlEmployees" runat="server" AppendDataBoundItems="True"
                        DataTextField="EmployeeNameWithCode" DataValueField="AccountEmployeeId" Height="22px"
                        Width="186px">
                        <%--<asp:ListItem Selected="True" Value="0">&lt;ALL&gt;</asp:ListItem>--%>
                        <asp:ListItem Selected="True" Value="0" Label ID="Label1" runat="server" Text="<%$ Resources:TimeLive.Resource, ALLs%> "></asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td align="right" class="formviewlabelcell" style="width: 40%; height: 21px">
                    <asp:Literal ID="Literal4" runat="server" Text="<%$ Resources:TimeLive.Resource, Clients:%> " /></td>
                <td style="width: 60%; height: 21px">
                    <asp:DropDownList ID="ddlClients" runat="server" AppendDataBoundItems="True" DataSourceID="dsClientsObject"
                        DataTextField="PartyName" DataValueField="AccountPartyId" Width="186px">
                        <%--<asp:ListItem Selected="True" Value="0">&lt;ALL&gt;</asp:ListItem>--%>
                        <asp:ListItem Selected="True" Value="0" Label ID="Label2" runat="server" Text="<%$ Resources:TimeLive.Resource, ALLs%> "></asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td align="right" class="formviewlabelcell" style="width: 40%">
                    <asp:Literal ID="Literal5" runat="server" Text="<%$ Resources:TimeLive.Resource, Projects:%> " /></td>
                <td style="width: 60%">
                    <asp:DropDownList ID="ddlProjects" runat="server" AppendDataBoundItems="True"
                        DataTextField="ProjectName" DataValueField="AccountProjectId" Height="22px" Width="186px">
                        <asp:ListItem Selected="True" Value="0" Label ID="Label3" runat="server" Text="<%$ Resources:TimeLive.Resource, ALLs%> "></asp:ListItem>
                        <%--<asp:ListItem Selected="True" Value="0">&lt;ALL&gt;</asp:ListItem>--%>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td align="right" class="formviewlabelcell" style="width: 40%; height: 21px">
                    <asp:Literal ID="Literal6" runat="server" Text="<%$ Resources:TimeLive.Resource, Project Tasks:%> " /></td>
                <td style="width: 60%; height: 21px">
                    <asp:DropDownList ID="ddlProjectTasks" runat="server" AppendDataBoundItems="True"
                        DataSourceID="dsProjectTaskObject" DataTextField="TaskName" DataValueField="AccountProjectTaskId"
                        Height="22px" Width="186px">
                        <asp:ListItem Selected="True" Value="0" Label ID="Label4" runat="server" Text="<%$ Resources:TimeLive.Resource, ALLs%> "></asp:ListItem>
                        <%--<asp:ListItem Selected="True" Value="0">&lt;ALL&gt;</asp:ListItem>--%>
                    </asp:DropDownList><br />
                    <aspToolkit:CascadingDropDown ID="CascadingDropDown1" runat="server" Category="ProjectTasks"
                        LoadingText="Loading" ParentControlID="ddlProjects" PromptText="< All >"
                        ServiceMethod="GetAccountProjectTasksForReport" ServicePath="~/Services/ProjectService.asmx"
                        TargetControlID="ddlProjectTasks">
                    </aspToolkit:CascadingDropDown>
                </td>
            </tr>
            <tr>
                <td align="right" class="formviewlabelcell" style="width: 40%">
                    <asp:Literal ID="Literal7" runat="server" Text="<%$ Resources:TimeLive.Resource, Location:%> " /></td>
                <td style="width: 60%">
                    <asp:DropDownList ID="ddlLocation" runat="server" AppendDataBoundItems="True"
                        DataSourceID="dslocationobject" DataTextField="AccountLocation" DataValueField="AccountLocationId"
                        Height="22px" Width="186px">
                        <asp:ListItem Selected="True" Value="0" Label ID="Label5" runat="server" Text="<%$ Resources:TimeLive.Resource, ALLs%> "></asp:ListItem>
                        <%--<asp:ListItem Selected="True" Value="0">&lt;ALL&gt;</asp:ListItem>--%>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td align="right" class="formviewlabelcell" style="width: 40%">
                    <asp:Literal ID="Literal8" runat="server" Text="<%$ Resources:TimeLive.Resource, Approved:%> " /></td>
                <td style="width: 60%">
                    <asp:DropDownList ID="ddlApproved" runat="server" AppendDataBoundItems="True">
                        <asp:ListItem Value="1" Label ID="Label7" runat="server" Text="<%$ Resources:TimeLive.Resource, Approved%> "></asp:ListItem>
                        <%--<asp:ListItem Value="0">Not Approved</asp:ListItem>--%>
                        <asp:ListItem Value="0" Label ID="Label8" runat="server" Text="<%$ Resources:TimeLive.Resource, Not Approved%> "></asp:ListItem>
                        <%--<asp:ListItem Selected="True" Value="-1">Both</asp:ListItem>--%>
                        <asp:ListItem Selected="True" Value="-1" Label ID="Label9" runat="server" Text="<%$ Resources:TimeLive.Resource, Both%> "></asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td align="right" class="formviewlabelcell" style="width: 40%">
                    <asp:Literal ID="Literal9" runat="server" Text="<%$ Resources:TimeLive.Resource, Submitted:%> " /></td>
                <td style="width: 60%">
                    <asp:DropDownList ID="ddlSubmitted" runat="server" AppendDataBoundItems="True">
                        <asp:ListItem Value="1" Label ID="Label10" runat="server" Text="<%$ Resources:TimeLive.Resource, Submitted%> "></asp:ListItem>
                        <%--<asp:ListItem Value="0">Not Approved</asp:ListItem>--%>
                        <asp:ListItem Value="0" Label ID="Label11" runat="server" Text="<%$ Resources:TimeLive.Resource, Not Submitted%> "></asp:ListItem>
                        <%--<asp:ListItem Selected="True" Value="-1">Both</asp:ListItem>--%>
                        <asp:ListItem Selected="True" Value="-1" Label ID="Label12" runat="server" Text="<%$ Resources:TimeLive.Resource, Both%> "></asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td align="right" class="formviewlabelcell" style="width: 40%">
                    <asp:Literal ID="Literal10" runat="server" Text="<%$ Resources:TimeLive.Resource, Billable:%> " /></td>
                <td style="width: 60%">
                    <asp:DropDownList ID="ddlBillable" runat="server" AppendDataBoundItems="True">
                        <asp:ListItem Value="1" Label ID="Label13" runat="server" Text="<%$ Resources:TimeLive.Resource, Billable%> "></asp:ListItem>
                        <%--<asp:ListItem Value="0">Not Approved</asp:ListItem>--%>
                        <asp:ListItem Value="0" Label ID="Label14" runat="server" Text="<%$ Resources:TimeLive.Resource, Un Billable%> "></asp:ListItem>
                        <%--<asp:ListItem Selected="True" Value="-1">Both</asp:ListItem>--%>
                        <asp:ListItem Selected="True" Value="-1" Label ID="Label15" runat="server" Text="<%$ Resources:TimeLive.Resource, Both%> "></asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td align="right" class="formviewlabelcell" style="width: 40%">
                    <asp:Literal ID="Literal11" runat="server" Text="<%$ Resources:TimeLive.Resource, Include Date Range:%> " /></td>
                <td style="width: 60%">
                    <asp:CheckBox ID="chkIncludeDateRange" runat="server" /></td>
            </tr>
            <tr>
                <td align="right" class="formviewlabelcell" style="width: 40%">
                    <asp:Literal ID="Literal12" runat="server" Text="<%$ Resources:TimeLive.Resource, Start Date:%> " /></td>
                <td style="width: 60%">
                    <ew:CalendarPopup ID="txtStartDate" runat="server">
                    </ew:CalendarPopup>
                </td>
            </tr>
            <tr>
                <td align="right" class="formviewlabelcell" style="width: 40%">
                    <asp:Literal ID="Literal13" runat="server" Text="<%$ Resources:TimeLive.Resource, End Date:%> " /></td>
                <td style="width: 60%">
                    <ew:CalendarPopup ID="txtEndDate" runat="server">
                    </ew:CalendarPopup>
                </td>
            </tr>
            <tr>
                <td align="right" class="formviewlabelcell" style="width: 40%; height: 26px">
                </td>
                <td style="width: 60%; height: 26px">
                    <asp:Button ID="Show" runat="server" OnClick="Show_Click" Text="<%$ Resources:TimeLive.Resource, Show_text%> "  /></td>
            </tr>
        </table>
        <asp:ObjectDataSource ID="dsProjectsObject" runat="server" DeleteMethod="DeleteAccountProject"
            InsertMethod="AddAccountProject" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetAccountProjectsByAccountEmployeeId" TypeName="AccountProjectBLL"
            UpdateMethod="UpdateProjectDescription">
            <DeleteParameters>
                <asp:Parameter Name="Original_AccountProjectId" Type="Int32" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="ProjectDescription" Type="String" />
                <asp:Parameter Name="Original_AccountProjectId" Type="Int32" />
            </UpdateParameters>
            <SelectParameters>
                <asp:SessionParameter Name="AccountEmployeeId" SessionField="AccountEmployeeId" Type="Int32" />
            </SelectParameters>
            <InsertParameters>
                <asp:Parameter Name="AccountId" Type="Int32" />
                <asp:Parameter Name="AccountProjectTypeId" Type="Int32" />
                <asp:Parameter Name="AccountClientId" Type="Int32" />
                <asp:Parameter Name="AccountPartyContactId" Type="Int32" />
                <asp:Parameter Name="AccountPartyDepartmentId" Type="Int32" />
                <asp:Parameter Name="ProjectBillingTypeId" Type="Int32" />
                <asp:Parameter Name="ProjectName" Type="String" />
                <asp:Parameter Name="ProjectDescription" Type="String" />
                <asp:Parameter Name="StartDate" Type="DateTime" />
                <asp:Parameter Name="DeadLine" Type="DateTime" />
                <asp:Parameter Name="ProjectStatusId" Type="Int32" />
                <asp:Parameter Name="LeaderEmployeeId" Type="Int32" />
                <asp:Parameter Name="ProjectManagerEmployeeId" Type="Int32" />
                <asp:Parameter Name="TimeSheetApprovalTypeId" Type="Int32" />
                <asp:Parameter Name="ExpenseApprovalTypeId" Type="Int32" />
                <asp:Parameter Name="EstimatedDuration" Type="Int32" />
                <asp:Parameter Name="EstimatedDurationUnit" Type="String" />
                <asp:Parameter Name="ProjectCode" Type="String" />
                <asp:Parameter Name="DefaultBillingRate" Type="Decimal" />
                <asp:Parameter Name="ProjectBillingRateTypeId" Type="Int32" />
                <asp:Parameter Name="CreatedOn" Type="DateTime" />
                <asp:Parameter Name="CreatedByEmployeeId" Type="Int32" />
                <asp:Parameter Name="ModifiedOn" Type="DateTime" />
                <asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" />
            </InsertParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="dsProjectTaskObject" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetAssignedAccountProjectTasksByAccountProjectIdForReports" TypeName="AccountProjectTaskBLL">
            <SelectParameters>
                <asp:ControlParameter ControlID="ddlProjects" DefaultValue="0" Name="AccountProjectId"
                    PropertyName="SelectedValue" Type="Int32" />
                <asp:SessionParameter DefaultValue="39" Name="AccountEmployeeId" SessionField="AccountEmployeeId"
                    Type="Int32" />
                <asp:Parameter Name="AccountProjectTaskId" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="dslocationobject" runat="server" DeleteMethod="DeleteAccountLocation"
            InsertMethod="AddAccountLocation" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetAccountLocationsByAccountId" TypeName="AccountLocationBLL" UpdateMethod="UpdateAccountLocation">
            <DeleteParameters>
                <asp:Parameter Name="original_AccountLocationId" Type="Int32" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="AccountId" Type="Int32" />
                <asp:Parameter Name="AccountLocation" Type="String" />
                <asp:Parameter Name="original_AccountLocationId" Type="Int32" />
                <asp:Parameter Name="ModifiedOn" Type="DateTime" />
                <asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" />
                <asp:Parameter Name="IsDisabled" Type="Boolean" />
            </UpdateParameters>
            <SelectParameters>
                <asp:SessionParameter DefaultValue="64" Name="AccountId" SessionField="AccountId"
                    Type="Int32" />
            </SelectParameters>
            <InsertParameters>
                <asp:Parameter Name="AccountId" Type="Int32" />
                <asp:Parameter Name="AccountLocation" Type="String" />
                <asp:Parameter Name="CreatedByEmployeeId" Type="Int32" />
                <asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" />
            </InsertParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="dsClientsObject" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetvueAccountPartiesByAccountId" TypeName="AccountPartyBLL">
            <SelectParameters>
                <asp:SessionParameter DefaultValue="64" Name="AccountId" SessionField="AccountId"
                    Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="dsEmployeesObject" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetAccountEmployeesViewByAccountId" TypeName="AccountEmployeeBLL">
            <SelectParameters>
                <asp:SessionParameter DefaultValue="64" Name="AccountId" SessionField="AccountId"
                    Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <br />
<dxxr:ReportToolbar ID="ReportToolbar1" runat="server" ReportViewer="<%# ReportViewer1 %>"
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
&nbsp;&nbsp;
