<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlEmployeeTimeEntry.ascx.vb" Inherits="Reports_ControlsViewer_ctlEmployeeTimeEntry" %>
<%@ Register Assembly="DevExpress.XtraReports.v11.1.Web"
    Namespace="DevExpress.XtraReports.Web" TagPrefix="dxxr" %>
<%@ Register Assembly="C1.Web.C1WebReport.2" Namespace="C1.Web.C1WebReport" TagPrefix="cc1" %>

<%@ Register Assembly="eWorld.UI"
    Namespace="eWorld.UI" TagPrefix="ew" %>

<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <table class="xFormView" style="width: 450px">
            <tr>
                <td class="caption" colspan="2">
                    <asp:Literal ID="Literal1" runat="server" Text="<%$ Resources:TimeLive.Resource, Task Billing By Projects/Clients Report%> " /></td>
            </tr>
            <tr>
                <td class="formviewsubheader" colspan="2">
                    <asp:Literal ID="Literal2" runat="server" Text="<%$ Resources:TimeLive.Resource, Search Parameters%> " /></td>
            </tr>
            <tr>
                <td align="right" class="formviewlabelcell" style="width: 40%">
                    <asp:Literal ID="Literal3" runat="server" Text="<%$ Resources:TimeLive.Resource, Clients:%> " /></td>
                <td align="left" style="width: 60%">
                    <asp:DropDownList ID="ddlClients" runat="server" AppendDataBoundItems="True" DataSourceID="dsClientsObject"
                        DataTextField="PartyName" DataValueField="AccountPartyId" Width="186px">
                        <%--<asp:ListItem Selected="True" Value="0">&lt;ALL&gt;</asp:ListItem>--%>
                        <asp:ListItem Selected="True" Value="0" Label ID="Label1" runat="server" Text="<%$ Resources:TimeLive.Resource, ALLs%> "></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="right" class="formviewlabelcell" style="width: 40%">
                    <asp:Literal ID="Literal4" runat="server" Text="<%$ Resources:TimeLive.Resource, Employees:%> " /></td>
                <td align="left" style="width: 60%">
                    <asp:DropDownList ID="ddlEmployees" runat="server" AppendDataBoundItems="True"
                        DataTextField="EmployeeNameWithCode" DataValueField="AccountEmployeeId" Height="22px"
                        Width="186px">
                        <%--'<asp:ListItem Selected="True" Value="0">&lt;ALL&gt;</asp:ListItem>--%>
                        <asp:ListItem Selected="True" Value="0" Label ID="Label2" runat="server" Text="<%$ Resources:TimeLive.Resource, ALLs%> "></asp:ListItem>
                    </asp:DropDownList>&nbsp;
                </td>
            </tr>
            <tr>
                <td align="right" class="formviewlabelcell" style="width: 40%">
                    <asp:Literal ID="Literal5" runat="server" Text="<%$ Resources:TimeLive.Resource, Projects:%> " /></td>
                <td align="left" style="width: 60%">
                    <asp:DropDownList ID="ddlProjects" runat="server" AppendDataBoundItems="True"
                        DataTextField="ProjectName" DataValueField="AccountProjectId" Height="22px" Width="186px">
                        <asp:ListItem Selected="True" Value="0" Label ID="Label3" runat="server" Text="<%$ Resources:TimeLive.Resource, ALLs%> "></asp:ListItem>
                        <%--<asp:ListItem Selected="True" Value="0">&lt;ALL&gt;</asp:ListItem>--%>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="right" class="formviewlabelcell" style="width: 40%">
                    <asp:Literal ID="Literal6" runat="server" Text="<%$ Resources:TimeLive.Resource, Project Tasks:%> " /></td>
                <td align="left" style="width: 60%">
                    <asp:DropDownList ID="ddlProjectTasks" runat="server" AppendDataBoundItems="True" DataSourceID="dsProjectTaskObject"
                        DataTextField="TaskName" DataValueField="AccountProjectTaskId" Height="22px" Width="186px">
                        <asp:ListItem Selected="True" Value="0" Label ID="Label4" runat="server" Text="<%$ Resources:TimeLive.Resource, ALLs%> "></asp:ListItem>
                        <%--<asp:ListItem Selected="True" Value="0">&lt;ALL&gt;</asp:ListItem>--%>
                    </asp:DropDownList>
                    <aspToolkit:CascadingDropDown ID="CascadingDropDown1" runat="server" Category="ProjectTask"
                        LoadingText="Loading..." ParentControlID="ddlProjects" PromptText="< All >" ServiceMethod="GetAccountProjectTasksForReport"
                        ServicePath="~/Services/ProjectService.asmx" TargetControlID="ddlProjectTasks" >
                    </aspToolkit:CascadingDropDown>
                </td>
            </tr>
            <tr>
                <td align="right" class="formviewlabelcell" style="width: 40%">
                    <asp:Literal ID="Literal7" runat="server" Text="<%$ Resources:TimeLive.Resource, Location:%> " /></td>
                <td align="left" style="width: 60%">
                    <asp:DropDownList ID="ddlLocation" runat="server" AppendDataBoundItems="True"
                        DataSourceID="dslocationobject" DataTextField="AccountLocation" DataValueField="AccountLocationId"
                        Height="22px" Width="186px">
                        <asp:ListItem Selected="True" Value="0" Label ID="Label5" runat="server" Text="<%$ Resources:TimeLive.Resource, ALLs%> "></asp:ListItem>
                        <%--<asp:ListItem Selected="True" Value="0">&lt;ALL&gt;</asp:ListItem>--%>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td align="right" class="formviewlabelcell" style="width: 40%">
                    <asp:Literal ID="Literal8" runat="server" Text="<%$ Resources:TimeLive.Resource, Submitted:%> " /></td>
                <td align="left" style="width: 60%">
                    <asp:DropDownList ID="ddlSubmitted" runat="server" AppendDataBoundItems="True">
                        <asp:ListItem Value="1" Label ID="Label7" runat="server" Text="<%$ Resources:TimeLive.Resource, Submitted%> "></asp:ListItem>
                        <%--<asp:ListItem Value="0">Not Approved</asp:ListItem>--%>
                        <asp:ListItem Value="0" Label ID="Label8" runat="server" Text="<%$ Resources:TimeLive.Resource, Not Submitted%> "></asp:ListItem>
                        <%--<asp:ListItem Selected="True" Value="-1">Both</asp:ListItem>--%>
                        <asp:ListItem Selected="True" Value="-1" Label ID="Label9" runat="server" Text="<%$ Resources:TimeLive.Resource, Both%> "></asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td align="right" class="formviewlabelcell" style="width: 40%">
                    <asp:Literal ID="Literal9" runat="server" Text="<%$ Resources:TimeLive.Resource, Billable:%> " /></td>
                <td align="left" style="width: 60%">
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
                    <asp:Literal ID="Literal10" runat="server" Text="<%$ Resources:TimeLive.Resource, Include Date Range:%> " /></td>
                <td align="left" style="width: 60%">
                    <asp:CheckBox ID="chkIncludeDateRange" runat="server" /></td>
            </tr>
            <tr>
                <td align="right" class="formviewlabelcell" style="width: 40%">
                    <asp:Literal ID="Literal11" runat="server" Text="<%$ Resources:TimeLive.Resource, Start Date:%> " /></td>
                <td align="left" style="width: 60%">
                    <ew:CalendarPopup ID="StartDate" runat="server">
                    </ew:CalendarPopup>
                </td>
            </tr>
            <tr>
                <td align="right" class="formviewlabelcell" style="width: 40%">
                    <asp:Literal ID="Literal12" runat="server" Text="<%$ Resources:TimeLive.Resource, End Date:%> " /></td>
                <td align="left" style="width: 60%">
                    <ew:CalendarPopup ID="EndDate" runat="server">
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
        <asp:ObjectDataSource ID="dsProjectsObject" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetAccountProjectsByAccountEmployeeId" TypeName="AccountProjectBLL">
            <SelectParameters>
                <asp:SessionParameter DefaultValue="39" Name="AccountEmployeeId" SessionField="AccountEmployeeId"
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
        <asp:ObjectDataSource ID="dsClientsObject" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetvueAccountPartiesByAccountId" TypeName="AccountPartyBLL">
            <SelectParameters>
                <asp:SessionParameter DefaultValue="64" Name="AccountId" SessionField="AccountId"
                    Type="Int32" />
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
        <asp:ObjectDataSource ID="dsProjectTaskObject" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetAssignedAccountProjectTasksByAccountProjectIdForReports" TypeName="AccountProjectTaskBLL">
            <SelectParameters>
                <asp:ControlParameter ControlID="ddlProjects" DefaultValue="0" Name="AccountProjectId"
                    PropertyName="SelectedValue" Type="Int32" />
                <asp:SessionParameter Name="AccountEmployeeId" SessionField="AccountEmployeeId" Type="Int32" />
                <asp:Parameter Name="AccountProjectTaskId" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <br />
<dxxr:ReportToolbar ID="ReportToolbar1" runat="server" ShowDefaultButtons="False" ReportViewer="<%# ReportViewer1 %>"><Items><dxxr:ReportToolbarButton ItemKind='Search' ToolTip='Display the search window' /><dxxr:ReportToolbarSeparator /><dxxr:ReportToolbarButton ItemKind='PrintReport' ToolTip='Print the report' /><dxxr:ReportToolbarButton ItemKind='PrintPage' ToolTip='Print the current page' /><dxxr:ReportToolbarSeparator /><dxxr:ReportToolbarButton Enabled='False' ItemKind='FirstPage' ToolTip='First Page' /><dxxr:ReportToolbarButton Enabled='False' ItemKind='PreviousPage' ToolTip='Previous Page' /><dxxr:ReportToolbarLabel Text='Page' /><dxxr:ReportToolbarComboBox ItemKind='PageNumber' Width='65px'></dxxr:ReportToolbarComboBox><dxxr:ReportToolbarLabel Text='of' /><dxxr:ReportToolbarTextBox IsReadOnly='True' ItemKind='PageCount' /><dxxr:ReportToolbarButton ItemKind='NextPage' ToolTip='Next Page' /><dxxr:ReportToolbarButton ItemKind='LastPage' ToolTip='Last Page' /><dxxr:ReportToolbarSeparator /><dxxr:ReportToolbarButton ItemKind='SaveToDisk' ToolTip='Export a report and save it to the disk' /><dxxr:ReportToolbarButton ItemKind='SaveToWindow' ToolTip='Export a report and show it in a new window' /><dxxr:ReportToolbarComboBox ItemKind='SaveFormat' Width='70px'><Elements><dxxr:ListElement Text='Pdf' Value='pdf' /><dxxr:ListElement Text='Xls' Value='xls' /><dxxr:ListElement Text='Rtf' Value='rtf' /><dxxr:ListElement Text='Mht' Value='mht' /><dxxr:ListElement Text='Text' Value='txt' /><dxxr:ListElement Text='Csv' Value='csv' /><dxxr:ListElement Text='Image' Value='png' /></Elements></dxxr:ReportToolbarComboBox></Items><Styles><LabelStyle><Margins MarginLeft='3px' MarginRight='3px' /></LabelStyle></Styles></dxxr:ReportToolbar>
<dxxr:ReportViewer ID="ReportViewer1" runat="server">
</dxxr:ReportViewer>
    </ContentTemplate>
</asp:UpdatePanel>
<br />
&nbsp;<br />

