<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlDetailTimeSheetReport.ascx.vb" Inherits="Reports_ControlsViewer_ctlDetailTimeSheetReport" %>
<%@ Register Assembly="DevExpress.XtraReports.v11.1.Web"
    Namespace="DevExpress.XtraReports.Web" TagPrefix="dxxr" %>
<%@ Register Assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24D65337282035F2"
    Namespace="eWorld.UI" TagPrefix="ew" %>
<%@ Register Assembly="C1.Web.C1WebReport.2" Namespace="C1.Web.C1WebReport" TagPrefix="cc1" %>
<asp:UpdatePanel ID="UpdatePanel2" runat="server">
    <ContentTemplate>
        <table class="xFormView" style="width: 450px">
            <tr>
                <td class="caption" colspan="2">
                <asp:Literal ID="Literal3" runat="server" Text="<%$ Resources:TimeLive.Resource, Detail TimeSheet Report%> " /></td>
            </tr>
            <tr>
                <td class="formviewsubheader" colspan="2">
                <asp:Literal ID="Literal1" runat="server" Text="<%$ Resources:TimeLive.Resource, Search Parameters%> " /></td>
            </tr>
            <tr>
                <td align="right" class="formviewlabelcell" style="width: 40%; height: 24px;">
                <asp:Literal ID="Literal2" runat="server" Text="<%$ Resources:TimeLive.Resource, Employees:%> " /></td>
                <td align="left" style="width: 60%; height: 24px;">
                    &nbsp;<asp:DropDownList ID="ddlEmployees" runat="server" AppendDataBoundItems="True"
                        DataTextField="EmployeeNameWithCode" DataValueField="AccountEmployeeId" Height="22px"
                        Width="186px">
                        <%--<asp:ListItem Selected="True" Value="0">&lt;ALL&gt;</asp:ListItem>--%>
                        <asp:ListItem Selected="True" Value="0" Label ID="Label1" runat="server" Text="<%$ Resources:TimeLive.Resource, ALLs%> "></asp:ListItem>
                    </asp:DropDownList>&nbsp;
                </td>
            </tr>
            <tr>
                <td align="right" class="formviewlabelcell" style="width: 40%">
                <asp:Literal ID="Literal4" runat="server" Text="<%$ Resources:TimeLive.Resource, Projects:%> " /></td>
                <td align="left" style="width: 60%">
                    &nbsp;<asp:DropDownList ID="ddlProjects" runat="server" AppendDataBoundItems="True"
                        DataTextField="ProjectName" DataValueField="AccountProjectId" Height="22px" Width="186px">
                        <%--<asp:ListItem Selected="True" Value="0">&lt;ALL&gt;</asp:ListItem>--%>
                        <asp:ListItem Selected="True" Value="0" Label ID="Label2" runat="server" Text="<%$ Resources:TimeLive.Resource, ALLs%> "></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="right" class="formviewlabelcell" style="width: 40%">
                <asp:Literal ID="Literal5" runat="server" Text="<%$ Resources:TimeLive.Resource, Project Tasks:%> " /></td>
                <td align="left" style="width: 60%">
                    &nbsp;<asp:DropDownList ID="ddlProjectTasks" runat="server"
                        DataSourceID="dsProjectTaskObject" DataTextField="TaskName" DataValueField="AccountProjectTaskId"
                        Height="22px" Width="186px">
                    </asp:DropDownList>
                    <aspToolkit:CascadingDropDown ID="CascadingDropDown1" runat="server" Category="Tasks"
                        LoadingText="Loading" ParentControlID="ddlProjects" PromptText="< All >"
                        ServiceMethod="GetAccountProjectTasksForReport" TargetControlID="ddlProjectTasks" ServicePath="~/Services/ProjectService.asmx">
                    </aspToolkit:CascadingDropDown>
                </td>
            </tr>
            <tr>
                <td align="right" class="formviewlabelcell" style="width: 40%">
                 <asp:Literal ID="Literal6" runat="server" Text="<%$ Resources:TimeLive.Resource, Clients:%> " /></td>
                <td align="left" style="width: 60%">
                    &nbsp;<asp:DropDownList ID="ddlClients" runat="server" AppendDataBoundItems="True" DataSourceID="dsClientsObject"
                        DataTextField="PartyNick" DataValueField="AccountPartyId" Height="22px" Width="186px">
                        <%--<asp:ListItem Selected="True" Value="0">&lt;ALL&gt;</asp:ListItem>--%>
                        <asp:ListItem Selected="True" Value="0" Label ID="Label4" runat="server" Text="<%$ Resources:TimeLive.Resource, ALLs%> "></asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td align="right" class="formviewlabelcell" style="width: 40%">
                   <asp:Literal ID="Literal7" runat="server" Text="<%$ Resources:TimeLive.Resource, Department:%> " /></td>
                <td align="left" style="width: 60%">
                    &nbsp;<asp:DropDownList ID="ddlDepartment" runat="server" AppendDataBoundItems="True"
                        DataTextField="DepartmentName" DataValueField="AccountDepartmentId" Height="22px"
                        Width="186px" DataSourceID="dsDepartmentObject">
                        <%--<asp:ListItem Selected="True" Value="0">&lt;ALL&gt;</asp:ListItem>--%>
                        <asp:ListItem Selected="True" Value="0" Label ID="Label5" runat="server" Text="<%$ Resources:TimeLive.Resource, ALLs%> "></asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td align="right" class="formviewlabelcell" style="width: 40%">
                <asp:Literal ID="Literal8" runat="server" /></td>
                <td align="left" style="width: 60%">
                    &nbsp;<asp:DropDownList ID="ddlLocation" runat="server" AppendDataBoundItems="True" DataSourceID="dslocationobject"
                        DataTextField="AccountLocation" DataValueField="AccountLocationId" Height="22px" Width="186px">
                        <%--<asp:ListItem Selected="True" Value="0">&lt;ALL&gt;</asp:ListItem>--%>
                        <asp:ListItem Selected="True" Value="0" Label ID="Label6" runat="server" Text="<%$ Resources:TimeLive.Resource, ALLs%> "></asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td align="right" class="formviewlabelcell" style="width: 40%">
                    <asp:Literal ID="Literal9" runat="server" Text="<%$ Resources:TimeLive.Resource, Approved:%> " /></td>
                <td align="left" style="width: 60%">
                    &nbsp;<asp:DropDownList ID="ddlApproved" runat="server" AppendDataBoundItems="True">
                        <%--<asp:ListItem Value="1">Approved</asp:ListItem>--%>
                        <asp:ListItem Value="1" Label ID="Label7" runat="server" Text="<%$ Resources:TimeLive.Resource, Approved%> "></asp:ListItem>
                        <%--<asp:ListItem Value="0">Not Approved</asp:ListItem>--%>
                        <asp:ListItem Value="0" Label ID="Label8" runat="server" Text="<%$ Resources:TimeLive.Resource, Not Approved%> "></asp:ListItem>
                        <%--<asp:ListItem Selected="True" Value="-1">Both</asp:ListItem>--%>
                        <asp:ListItem Selected="True" Value="-1" Label ID="Label9" runat="server" Text="<%$ Resources:TimeLive.Resource, Both%> "></asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td align="right" class="formviewlabelcell" style="width: 40%">
                    <asp:Literal ID="Literal10" runat="server" Text="<%$ Resources:TimeLive.Resource, Submitted:%> " /></td>
                <td align="left" style="width: 60%">
                    &nbsp;<asp:DropDownList ID="ddlSubmitted" runat="server" AppendDataBoundItems="True">
                        <asp:ListItem Value="1" Label ID="Label10" runat="server" Text="<%$ Resources:TimeLive.Resource, Submitted%> "></asp:ListItem>
                        <%--<asp:ListItem Value="0">Not Approved</asp:ListItem>--%>
                        <asp:ListItem Value="0" Label ID="Label11" runat="server" Text="<%$ Resources:TimeLive.Resource, Not Submitted%> "></asp:ListItem>
                        <%--<asp:ListItem Selected="True" Value="-1">Both</asp:ListItem>--%>
                        <asp:ListItem Selected="True" Value="-1" Label ID="Label12" runat="server" Text="<%$ Resources:TimeLive.Resource, Both%> "></asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td align="right" class="formviewlabelcell" style="width: 40%">
                    <asp:Literal ID="Literal11" runat="server" Text="<%$ Resources:TimeLive.Resource, Billable:%> " /></td>
                <td align="left" style="width: 60%">
                    &nbsp;<asp:DropDownList ID="ddlBillable" runat="server" AppendDataBoundItems="True">
                        <asp:ListItem Value="1" Label ID="Label13" runat="server" Text="<%$ Resources:TimeLive.Resource, Billable%> "></asp:ListItem>
                        <%--<asp:ListItem Value="0">Not Approved</asp:ListItem>--%>
                        <asp:ListItem Value="0" Label ID="Label14" runat="server" Text="<%$ Resources:TimeLive.Resource, Un Billable%> "></asp:ListItem>
                        <%--<asp:ListItem Selected="True" Value="-1">Both</asp:ListItem>--%>
                        <asp:ListItem Selected="True" Value="-1" Label ID="Label15" runat="server" Text="<%$ Resources:TimeLive.Resource, Both%> "></asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td align="right" class="formviewlabelcell" style="width: 40%">
                    <asp:Literal ID="Literal12" runat="server" Text="<%$ Resources:TimeLive.Resource, Include Date Range:%> " /></td>
                <td align="left" style="width: 60%">
                    <asp:CheckBox ID="chkIncludeDateRange" runat="server" /></td>
            </tr>
            <tr>
                <td align="right" class="formviewlabelcell" style="width: 40%">
                    <asp:Literal ID="Literal13" runat="server" Text="<%$ Resources:TimeLive.Resource, Start Date:%> " /></td>
                <td align="left" style="width: 60%">
                    &nbsp;<ew:CalendarPopup ID="StartDate" runat="server">
                    </ew:CalendarPopup>
                </td>
            </tr>
            <tr>
                <td align="right" class="formviewlabelcell" style="width: 40%">
                    <asp:Literal ID="Literal14" runat="server" Text="<%$ Resources:TimeLive.Resource, End Date:%> " /></td>
                <td align="left" style="width: 60%">
                    &nbsp;<ew:CalendarPopup ID="EndDate" runat="server">
                    </ew:CalendarPopup>
                </td>
            </tr>
            <tr>
                <td align="right" class="formviewlabelcell" style="width: 40%">
                </td>
                <td align="left" style="width: 60%">
                    &nbsp;<asp:Button ID="Show" runat="server" OnClick="Show_Click" Text="<%$ Resources:TimeLive.Resource, Show_text%> " /></td>
            </tr>
        </table>
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
        <asp:ObjectDataSource ID="dsEmployeesObject" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetAccountEmployeesViewByAccountId" TypeName="AccountEmployeeBLL">
            <SelectParameters>
                <asp:SessionParameter DefaultValue="64" Name="AccountId" SessionField="AccountId"
                    Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="dsProjectsObject" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetAccountProjectsByAccountEmployeeId" TypeName="AccountProjectBLL">
            <SelectParameters>
                <asp:SessionParameter DefaultValue="39" Name="AccountEmployeeId" SessionField="AccountEmployeeId"
                    Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource><asp:ObjectDataSource ID="dsDepartmentObject" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetAccountDepartmentsByAccountIdAndIsDisabled" TypeName="AccountDepartmentBLL">
            <SelectParameters>
                <asp:SessionParameter DefaultValue="64" Name="AccountId" SessionField="AccountId"
                    Type="Int32" />
                <asp:Parameter Name="AccountDepartmentId" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="dsClientsObject" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetAccountPartiesByAccountId" TypeName="AccountPartyBLL" DeleteMethod="DeleteAccountParty" InsertMethod="AddAccountParty" UpdateMethod="UpdateAccountParty">
            <DeleteParameters>
                <asp:Parameter Name="original_AccountPartyId" Type="Int32" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="PartyTypeId" Type="Int16" />
                <asp:Parameter Name="AccountId" Type="Int32" />
                <asp:Parameter Name="PartyName" Type="String" />
                <asp:Parameter Name="PartyNick" Type="String" />
                <asp:Parameter Name="EMailAddress" Type="String" />
                <asp:Parameter Name="Address1" Type="String" />
                <asp:Parameter Name="Address2" Type="String" />
                <asp:Parameter Name="CountryId" Type="Int16" />
                <asp:Parameter Name="State" Type="String" />
                <asp:Parameter Name="City" Type="String" />
                <asp:Parameter Name="ZipCode" Type="String" />
                <asp:Parameter Name="Telephone1" Type="String" />
                <asp:Parameter Name="Telephone2" Type="String" />
                <asp:Parameter Name="Fax" Type="String" />
                <asp:Parameter Name="DefaultCurrencyId" Type="Int16" />
                <asp:Parameter Name="DefaultBillingRate" Type="Decimal" />
                <asp:Parameter Name="Website" Type="String" />
                <asp:Parameter Name="Notes" Type="String" />
                <asp:Parameter Name="IsDisabled" Type="Boolean" />
                <asp:Parameter Name="IsDeleted" Type="Boolean" />
                <asp:Parameter Name="CreatedOn" Type="DateTime" />
                <asp:Parameter Name="CreatedByEmployeeId" Type="Int32" />
                <asp:Parameter Name="ModifiedOn" Type="DateTime" />
                <asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" />
                <asp:Parameter Name="Original_AccountPartyId" Type="Int32" />
            </UpdateParameters>
            <SelectParameters>
                <asp:SessionParameter DefaultValue="64" Name="AccountId" SessionField="AccountId"
                    Type="Int32" />
            </SelectParameters>
            <InsertParameters>
                <asp:Parameter Name="AccountId" Type="Int32" />
                <asp:Parameter Name="PartyName" Type="String" />
                <asp:Parameter Name="PartyNick" Type="String" />
                <asp:Parameter Name="EMailAddress" Type="String" />
                <asp:Parameter Name="Address1" Type="String" />
                <asp:Parameter Name="Address2" Type="String" />
                <asp:Parameter Name="CountryId" Type="Int16" />
                <asp:Parameter Name="State" Type="String" />
                <asp:Parameter Name="City" Type="String" />
                <asp:Parameter Name="ZipCode" Type="String" />
                <asp:Parameter Name="Telephone1" Type="String" />
                <asp:Parameter Name="Telephone2" Type="String" />
                <asp:Parameter Name="Fax" Type="String" />
                <asp:Parameter Name="DefaultCurrencyId" Type="Int16" />
                <asp:Parameter Name="DefaultBillingRate" Type="Decimal" />
                <asp:Parameter Name="Website" Type="String" />
                <asp:Parameter Name="Notes" Type="String" />
                <asp:Parameter Name="IsDisabled" Type="Boolean" />
                <asp:Parameter Name="IsDeleted" Type="Boolean" />
                <asp:Parameter Name="CreatedOn" Type="DateTime" />
                <asp:Parameter Name="CreatedByEmployeeId" Type="Int32" />
                <asp:Parameter Name="ModifiedOn" Type="DateTime" />
                <asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" />
            </InsertParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="dslocationobject" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetAccountLocationsByAccountId" TypeName="AccountLocationBLL" DeleteMethod="DeleteAccountLocation" InsertMethod="AddAccountLocation" UpdateMethod="UpdateAccountLocation">
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
<dxxr:reportviewer id="ReportViewer1" runat="server" 
    ></dxxr:reportviewer>
        
    </ContentTemplate>
</asp:UpdatePanel>
&nbsp; &nbsp;<br />


