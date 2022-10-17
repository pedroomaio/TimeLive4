<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlAccountEmployeeTimeEntryDayView.ascx.vb" Inherits="Employee_Controls_ctlAccountEmployeeTimeEntryDayView" %>
<%@ Register Src="ctlStatusLegend.ascx" TagName="ctlStatusLegend" TagPrefix="uc2" %>
<%@ Register Src="ctlAccountEmployeeAttendanceList.ascx" TagName="ctlAccountEmployeeAttendanceList"
    TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc2" %>
<%@ Register Assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24D65337282035F2"
    Namespace="eWorld.UI" TagPrefix="ew" %>

<%@ Register Assembly="LiveTools" Namespace="LiveTools" TagPrefix="cc1" %>
<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.3/jquery.min.js"></script>
<script type="text/javascript">

    function EnterEvent(e, ctrl) {
        var keycode = (e.keyCode ? e.keyCode : e.which);
        if (keycode == 13) {
            return false;
        }
        else {
            return true;
        }
    }

</script>
<script type="text/javascript">
    evt = ""; // Defeat the Chrome bug
</script>
<style type="text/css">
    .ddl
    {
        margin-top:-15px;
    }
</style>
<div class="fieldset" style="width: 96%">
    <p class="button-height inline-label">
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <asp:Button ID="btnWeekView" runat="server" Width="135px" />&nbsp;<asp:Button ID="btnMyPeriods" runat="server" Text="<%$ Resources:TimeLive.Resource, Timesheet Periods%> " Width="135px" />
                <asp:Button ID="btnAudit" runat="server" Text="<%$ Resources:TimeLive.Resource, Audit%> " Visible="False" Width="135px" />
                <asp:Button ID="btnTopSave" runat="server" Text="<%$ Resources:TimeLive.Resource, Save_text%> " OnClick="Button1_Click" Width="135px" ValidationGroup="TimeEntry" OnClientClick='<%# ResourceHelper.GetSaveMessageJavascriptForDayView()%>' />
                <asp:Button ID="btnTimerTimesheet" runat="server" CssClass="DisabledButton"
                    OnClick="btnTimerTimesheet_Click" Text="<%$ Resources:TimeLive.Resource, Start Timer%> " ToolTip="<%$ Resources:TimeLive.Resource, Timer%> "
                    Visible="true" Width="135px" />
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:HyperLink ID="lnkTimesheetPeriodList" runat="server" Visible="False">[lnkTimesheetPeriodList]</asp:HyperLink><asp:HyperLink ID="lnkWeekView" runat="server" Visible="False">[lnkWeekView]</asp:HyperLink>
    </p>
    <p>
        <asp:Label ID="EmployeeNameLabel" runat="server" Text="<%$ Resources:TimeLive.Resource, Employees: %>"
            Font-Bold="true" Font-Size="11px" Width="150px"></asp:Label>

        <asp:DropDownList ID="ddlEmployee" runat="server" AutoPostBack="True" Width="300px">
        </asp:DropDownList>

    </p>
    <p>
        <asp:Label ID="Label1" runat="server" Text="<%$ Resources:TimeLive.Resource, Current Date: %>" Font-Bold="True" Font-Size="11px" Width="150px"></asp:Label>

        <asp:ImageButton ID="ImageButton1" OnClick="ImageButton1_Click" runat="server" ImageUrl="~/Images/right.gif" ToolTip="<%$ Resources:TimeLive.Resource, Previous Date%> "></asp:ImageButton>&nbsp;
       
        <asp:Label ID="lblCurrenctdate" runat="server" Text="Label" Font-Bold="True" Font-Names="Tahoma" Font-Size="11px"></asp:Label>
        <asp:ImageButton ID="ImageButton2" OnClick="ImageButton2_Click" runat="server" ImageUrl="~/Images/left.gif" ToolTip="<%$ Resources:TimeLive.Resource, Next Date%> "></asp:ImageButton>

    </p>
    <p>
        <asp:Label ID="lblCurrenctdate2" runat="server" Text="<%$ Resources:TimeLive.Resource, Time Entry Date : %>" Font-Bold="True" Font-Size="11px" Width="150px"></asp:Label>
        <ew:CalendarPopup ID="txtTimeEntryDate" runat="server" SkinID="DatePicker" Width="111px" AutoPostBack="True">
        </ew:CalendarPopup>
        <asp:Image ID="Image1" runat="server" Height="18px" ImageUrl="~/Images/Holiday.gif"
            Visible="False" Width="18px" />
    </p>
    <p>
        <asp:Label ID="Label3" runat="server" Text="<%$ Resources:TimeLive.Resource, Timesheet Status : %>" Font-Bold="true" Font-Size="11px" Width="150px"></asp:Label>
        <asp:Image ID="imgTSL" runat="server" ImageAlign="Middle" ImageUrl="~/Images/clearpixel.gif"
            Width="12px" AlternateText="Timesheet Status" CssClass="statuslabel" />&nbsp;<asp:Label ID="lblTimesheetStatus" runat="server" Text="Label" CssClass="statuslabel" Width="150px" Font-Bold="true" Font-Size="11px"></asp:Label>
    </p>
</div>
<%  If AccountPagePermissionBLL.IsPageHasPermissionOf(18, 1) = True Then%>
<x:GridView ID="BulkEditGridViewVB1" runat="server" AutoGenerateColumns="False" PageSize="500"
    DataKeyNames="AccountEmployeeTimeEntryId,AccountProjectId,AccountProjectTaskId,StartTime,EndTime,TotalTime,Description,AccountEmployeeTimeEntryApprovalProjectId,AccountEmployeeTimeEntryPeriodId,IsTimeOff,AccountTimeOffTypeId,AccountEmployeeTimeOffRequestId,Approved,Percentage,AccountWorkTypeId,AccountCostCenterId,Hours,CustomField1,CustomField2,CustomField3,CustomField4,CustomField5,CustomField6,CustomField7,CustomField8,CustomField9" DataSourceID="dsAccountEmployeeTimeEntry"
    Caption="<%$ Resources:TimeLive.Resource, Time Entry Day View %>" CssClass="xGridViewTS" ShowFooter="True" EnableViewState="False">
    <Columns>
        <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Client %>">
            <ItemTemplate>
                <asp:DropDownList ID="ddlAccountClientId" runat="server" onkeydown="return EnterEvent(event,this);" Width="400px" DataTextField="PartyName" DataValueField="AccountPartyId" __designer:wfdid="w14"></asp:DropDownList>
                <asp:Label ID="lblTimeTypesClient" runat="server" Text="Time Off" Font-Bold="True" Visible="False" __designer:wfdid="w7"></asp:Label>
                <asp:ObjectDataSource ID="dsAccountClientObject" runat="server" TypeName="AccountPartyBLL" SelectMethod="GetAccountPartiesForTimeEntryByAccountEmployeeId" OldValuesParameterFormatString="original_{0}" __designer:wfdid="w3">
                    <SelectParameters>
                        <asp:SessionParameter SessionField="AccountEmployeeID" Type="Int32" Name="AccountEmployeeId"></asp:SessionParameter>
                        <asp:Parameter DefaultValue="0" Name="AccountClientId" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="400px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Project %>">
            <ItemTemplate>
                <asp:Label ID="lblTimeOff" runat="server" Width="15%" Visible="False" CssClass="ddl" __designer:wfdid="w15"></asp:Label>
                <asp:DropDownList Width="400px" ID="ddlAccountProjectId" runat="server" __designer:wfdid="w35" onkeydown="return EnterEvent(event,this);" DataTextField="ProjectName" DataValueField="AccountProjectId"></asp:DropDownList>
                <asp:ObjectDataSource ID="dsAccountProjectsObject" runat="server"
                    DeleteMethod="DeleteAccountProject" TypeName="AccountProjectBLL"
                    SelectMethod="GetAssignedAccountProjectsByAccountEmployeeIdAndAccountProjectIdForIsDeletedClient"
                    OldValuesParameterFormatString="original_{0}" __designer:wfdid="w29"
                    InsertMethod="AddAccountProject" UpdateMethod="UpdateProjectDescription">
                    <DeleteParameters>
                        <asp:Parameter Name="Original_AccountProjectId" Type="Int32"></asp:Parameter>
                    </DeleteParameters>
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
                        <asp:Parameter Name="Deadline" Type="DateTime" />
                        <asp:Parameter Name="ProjectStatusId" Type="Int32" />
                        <asp:Parameter Name="LeaderEmployeeId" Type="Int32" />
                        <asp:Parameter Name="ProjectManagerEmployeeId" Type="Int32" />
                        <asp:Parameter Name="TimeSheetApprovalTypeId" Type="Int32" />
                        <asp:Parameter Name="ExpenseApprovalTypeId" Type="Int32" />
                        <asp:Parameter Name="EstimatedDuration" Type="Double" />
                        <asp:Parameter Name="EstimatedDurationUnit" Type="String" />
                        <asp:Parameter Name="ProjectCode" Type="String" />
                        <asp:Parameter Name="DefaultBillingRate" Type="Decimal" />
                        <asp:Parameter Name="ProjectBillingRateTypeId" Type="Int32" />
                        <asp:Parameter Name="IsTemplate" Type="Boolean" />
                        <asp:Parameter Name="IsProject" Type="Boolean" />
                        <asp:Parameter Name="AccountProjectTemplateId" Type="Int32" />
                        <asp:Parameter Name="CreatedOn" Type="DateTime" />
                        <asp:Parameter Name="CreatedByEmployeeId" Type="Int32" />
                        <asp:Parameter Name="ModifiedOn" Type="DateTime" />
                        <asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" />
                        <asp:Parameter Name="Completed" Type="Boolean" />
                        <asp:Parameter Name="CustomField1" Type="String" />
                        <asp:Parameter Name="CustomField2" Type="String" />
                        <asp:Parameter Name="CustomField3" Type="String" />
                        <asp:Parameter Name="CustomField4" Type="String" />
                        <asp:Parameter Name="CustomField5" Type="String" />
                        <asp:Parameter Name="CustomField6" Type="String" />
                        <asp:Parameter Name="CustomField7" Type="String" />
                        <asp:Parameter Name="CustomField8" Type="String" />
                        <asp:Parameter Name="CustomField9" Type="String" />
                        <asp:Parameter Name="CustomField10" Type="String" />
                        <asp:Parameter Name="CustomField11" Type="String" />
                        <asp:Parameter Name="CustomField12" Type="String" />
                        <asp:Parameter Name="CustomField13" Type="String" />
                        <asp:Parameter Name="CustomField14" Type="String" />
                        <asp:Parameter Name="CustomField15" Type="String" />
                    </InsertParameters>
                    <SelectParameters>
                        <asp:Parameter Name="AccountProjectId" Type="Int32"></asp:Parameter>
                        <asp:SessionParameter SessionField="AccountEmployeeId" DefaultValue="39" Name="AccountEmployeeId" Type="Int32"></asp:SessionParameter>
                        <asp:Parameter Name="Completed" Type="Boolean" />
                        <asp:QueryStringParameter QueryStringField="IsTemplate" Name="IsTemplate" Type="Boolean"></asp:QueryStringParameter>
                        <asp:Parameter Name="AccountId" Type="Int32" />
                    </SelectParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="ProjectDescription" Type="String" />
                        <asp:Parameter Name="Original_AccountProjectId" Type="Int32" />
                    </UpdateParameters>
                </asp:ObjectDataSource>
                <asp:ObjectDataSource ID="dsAccountProjectTasksObject" __designer:dtid="1970324836974643" runat="server" TypeName="AccountProjectTaskBLL" OldValuesParameterFormatString="original_{0}" __designer:wfdid="w37">
                    <SelectParameters __designer:dtid="1970324836974644">
                        <asp:Parameter Type="Int32" Name="AccountProjectId"></asp:Parameter>
                        <asp:SessionParameter SessionField="AccountEmployeeId" Type="Int32" DefaultValue="39" Name="AccountEmployeeId"></asp:SessionParameter>
                        <asp:Parameter Type="Int32" Name="AccountProjectTaskId"></asp:Parameter>
                    </SelectParameters>
                </asp:ObjectDataSource>
                <aspToolkit:CascadingDropDown ID="ddlAccountProjectIdCascadingDropDown" UseContextKey="true" __designer:dtid="1970324836974685" runat="server" __designer:wfdid="w38" TargetControlID="ddlAccountProjectId" LoadingText="Loading" ParentControlID="ddlAccountClientId" PromptText="Select Project" ServicePath="~/Services/ProjectService.asmx" ServiceMethod="GetAccountProjectsByClient" Category="Projects"></aspToolkit:CascadingDropDown>
            </ItemTemplate>

            <ItemStyle HorizontalAlign="left" Width="400px" VerticalAlign="Middle" Height="45px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Task %>">
            <ItemTemplate>
                <asp:DropDownList ID="ddlAccountProjectTaskId" __designer:dtid="1970324836974684" Width="400px" runat="server" DataTextField="TaskName" onkeydown="return EnterEvent(event,this);" DataValueField="AccountProjectTaskId" __designer:wfdid="w3"></asp:DropDownList>
                <asp:DropDownList ID="ddlTimeOffTypes"  __designer:dtid="1970324836974684" onkeydown="return EnterEvent(event,this);" Width="100%" runat="server" Visible="False" DataSourceID="dsTimeOffTypeObject" DataTextField="AccountTimeOffType" DataValueField="AccountTimeOffTypeId" __designer:wfdid="w4"></asp:DropDownList>

                <asp:ObjectDataSource ID="dsTimeOffTypeObject" runat="server"
                    TypeName="AccountTimeOffTypeBLL"
                    SelectMethod="GetAccountTimeOffTypesByAccountIdAccountEmployeeIdAndRequestRequired"
                    OldValuesParameterFormatString="original_{0}" __designer:wfdid="w5">
                    <SelectParameters>
                        <asp:SessionParameter Name="AccountEmployeeId" SessionField="AccountEmployeeId"
                            Type="Int32" />
                        <asp:SessionParameter SessionField="AccountId" Type="Int32" Name="AccountId"></asp:SessionParameter>
                        <asp:Parameter Type="Boolean" Name="IsTimeOffRequestRequired" DefaultValue="False"></asp:Parameter>
                        <asp:Parameter Name="AccountTimeOffTypeId" DbType="Guid"></asp:Parameter>
                    </SelectParameters>
                </asp:ObjectDataSource>
                <aspToolkit:CascadingDropDown ID="ddlAccountProjectTaskIdCascadingDropDown" __designer:dtid="1970324836974685" runat="server" __designer:wfdid="w6" TargetControlID="ddlAccountProjectTaskId" LoadingText="Loading" ParentControlID="ddlAccountProjectId" PromptText="<%$ Resources:TimeLive.Resource, Select Tasks%>" ServicePath="~/Services/ProjectService.asmx" ServiceMethod="GetAccountProjectTasksInTimeSheet" Category="Tasks"></aspToolkit:CascadingDropDown>
                <aspToolkit:CascadingDropDown ID="TT" runat="server" __designer:wfdid="w37" TargetControlID="ddlTimeOffTypes" Category="Tasks" ServiceMethod="GetAccountTimeOffTypesInTimesheet" ServicePath="~/Services/ProjectService.asmx" PromptText="<%$ Resources:TimeLive.Resource, Select Tasks%>" ParentControlID="ddlAccountProjectId" LoadingText="Loading" Enabled="True"></aspToolkit:CascadingDropDown>
            </ItemTemplate>
            <ItemStyle Width="400px" HorizontalAlign="Center" VerticalAlign="Middle" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Cost Center %>">
            <ItemTemplate>
                <asp:DropDownList ID="ddlAccountCostCenterId" Width="150px" runat="server" onkeydown="return EnterEvent(event,this);" DataSourceID="dsAccountCostCenterObject" AppendDataBoundItems="True" DataTextField="AccountCostCenter" DataValueField="AccountCostCenterId" __designer:wfdid="w7">
                    <asp:ListItem Value="0"></asp:ListItem>
                </asp:DropDownList><asp:ObjectDataSource ID="dsAccountCostCenterObject" runat="server" TypeName="AccountCostCenterBLL" SelectMethod="GetAccountCostCenterByAccountIdAndIsDisabled" OldValuesParameterFormatString="original_{0}" __designer:wfdid="w8">
                    <SelectParameters>
                        <asp:SessionParameter SessionField="AccountId" DefaultValue="151" Name="AccountId" Type="Int32"></asp:SessionParameter>
                        <asp:Parameter Name="AccountCostCenterId" Type="Int32"></asp:Parameter>
                        <asp:ControlParameter ControlID="ddlEmployee" Name="AccountEmployeeId"
                            PropertyName="SelectedValue" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="150px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Work Type %>">
            <ItemTemplate>
                <asp:DropDownList ID="ddlAccountWorkTypeId" Width="150px" runat="server" onkeydown="return EnterEvent(event,this);" DataSourceID="dsAccountWorkTypeObject" DataTextField="AccountWorkType" DataValueField="AccountWorkTypeId" __designer:wfdid="w1"></asp:DropDownList><asp:ObjectDataSource ID="dsAccountWorkTypeObject" runat="server" TypeName="AccountWorkTypeBLL" SelectMethod="GetAccountWorkTypesByAccountIdAndIsDisabled" OldValuesParameterFormatString="original_{0}" __designer:wfdid="w35">
                    <SelectParameters>
                        <asp:SessionParameter SessionField="AccountId" Type="Int32" DefaultValue="99" Name="AccountId"></asp:SessionParameter>
                        <asp:Parameter Type="Int32" Name="AccountWorkTypeId"></asp:Parameter>
                    </SelectParameters>
                </asp:ObjectDataSource>
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="150px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, StartTime %>">
            <ItemTemplate>
                <asp:TextBox ID="StartTime" runat="server" Width="50px" ValidationGroup="TimeEntry" __designer:wfdid="w3" onchange="javascript:OnTimeChange(this);"></asp:TextBox>
                <cc2:MaskedEditExtender ID="MaskedEditExtenderStartTime" runat="server" __designer:wfdid="w4" AutoCompleteValue="00:00" AutoComplete="true" AcceptAMPM="true" MaskType="Time" Mask="99:99 " TargetControlID="StartTime"></cc2:MaskedEditExtender>
                <cc2:MaskedEditValidator ID="MaskedEditValidatorStartTime" runat="server" ValidationGroup="TimeEntry" __designer:wfdid="w5" Display="Dynamic" InvalidValueMessage="Invalid Time" EmptyValueMessage="*" IsValidEmpty="true" ControlToValidate="StartTime" ControlExtender="MaskedEditExtenderStartTime"></cc2:MaskedEditValidator>
            </ItemTemplate>
            <ItemStyle Width="50px" HorizontalAlign="Center" VerticalAlign="Middle" />

        </asp:TemplateField>
        <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, EndTime %>">
            <ItemTemplate>
                <asp:TextBox ID="EndTime" runat="server" Width="50px" ValidationGroup="TimeEntry" __designer:wfdid="w47" onchange="javascript:OnTimeChange(this);"></asp:TextBox>
                <cc2:MaskedEditExtender ID="MaskedEditExtenderEndTime" runat="server" __designer:wfdid="w48" TargetControlID="EndTime" Mask="99:99 " MaskType="Time" AcceptAMPM="true" AutoComplete="true" AutoCompleteValue="00:00"></cc2:MaskedEditExtender>
                <cc2:MaskedEditValidator ID="MaskedEditValidatorEndTime" runat="server" ValidationGroup="TimeEntry" __designer:wfdid="w49" ControlExtender="MaskedEditExtenderEndTime" ControlToValidate="EndTime" IsValidEmpty="true" EmptyValueMessage="*" InvalidValueMessage="Invalid Time" Display="Dynamic"></cc2:MaskedEditValidator>
            </ItemTemplate>
            <ItemStyle Width="50px" HorizontalAlign="Center" VerticalAlign="Middle" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, TotalTime %>">
            <FooterTemplate>
                <asp:TextBox ID="sumTime" runat="server" Width="50px" __designer:wfdid="w54" ReadOnly="true"></asp:TextBox>
                <asp:TextBox ID="sumPercent" runat="server" Width="50px" __designer:wfdid="w54" ReadOnly="true"></asp:TextBox>
            </FooterTemplate>
            <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            <ItemTemplate>
                <asp:TextBox ID="TotalTime" runat="server" Width="50px" ValidationGroup="TimeEntry" __designer:wfdid="w55" onchange="javascript:UpdateSum();"></asp:TextBox><cc2:MaskedEditExtender ID="MaskedEditExtenderTotalTime" runat="server" __designer:wfdid="w56" TargetControlID="TotalTime" Mask="99:99 " MaskType="Time" AcceptAMPM="false" AutoComplete="true" AutoCompleteValue="00:00"></cc2:MaskedEditExtender>
                <cc2:MaskedEditValidator ID="MaskedEditValidatorTotalTime" runat="server" ValidationGroup="TimeEntry" __designer:wfdid="w57" ControlExtender="MaskedEditExtenderTotalTime" ControlToValidate="TotalTime" IsValidEmpty="true" EmptyValueMessage="*" InvalidValueMessage="Invalid Time" Display="Dynamic"></cc2:MaskedEditValidator>
                <asp:RangeValidator ID="rvTT" runat="server" ControlToValidate="TotalTime"
                    Display="Dynamic" ErrorMessage="Invalid Time" MaximumValue='<%# Convert.ToDouble(23.99).ToString("N", LocaleUtilitiesBLL.GetCurrentCultureInfoWithThreadCulture) %>'
                    MinimumValue="0" ValidationGroup="TimeEntry" Type="Double"></asp:RangeValidator>
                <asp:TextBox ID="Percentage" runat="server" ValidationGroup="TimeEntry"
                    Width="50px" onchange="javascript:UpdateSum();"></asp:TextBox>
                <cc2:MaskedEditExtender ID="MaskedEditExtenderPercentage" runat="server"
                    __designer:wfdid="w56" AcceptAMPM="false" AutoComplete="False" Mask="999"
                    MaskType="Number" TargetControlID="Percentage">
                </cc2:MaskedEditExtender>
                <cc2:MaskedEditValidator ID="MaskedEditValidatorPercentage" runat="server"
                    __designer:wfdid="w57" ControlExtender="MaskedEditExtenderPercentage"
                    ControlToValidate="Percentage" Display="Dynamic" EmptyValueMessage="*"
                    ErrorMessage="MaskedEditValidatorPercentage"
                    InvalidValueMessage="Invalid Percentage" IsValidEmpty="true" MaximumValue="100"
                    MaximumValueMessage="Invalid Percentage" ValidationGroup="TimeEntry"></cc2:MaskedEditValidator>
            </ItemTemplate>
            <ItemStyle Width="50px" HorizontalAlign="Center" VerticalAlign="Middle" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Description %>">
            <EditItemTemplate>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:TextBox ID="Description" runat="server" Text='<%# Bind("Description") %>' __designer:wfdid="w60" TextMode="MultiLine" MaxLength="500"></asp:TextBox>
            </ItemTemplate>

            <ItemStyle Width="200px" HorizontalAlign="Center" VerticalAlign="Middle" />
            <ControlStyle Width="200px" />
        </asp:TemplateField>
        
        <asp:BoundField DataField="AccountEmployeeTimeEntryId" HeaderText="AccountEmployeeTimeEntryId" 
            InsertVisible="False" ReadOnly="True" Visible="False" />
        
        <asp:TemplateField ShowHeader="False" Visible="False">
            <ItemTemplate>
                <asp:UpdatePanel ID="UpdatePanelDelete" runat="server" __designer:wfdid="w1" RenderMode="Inline" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:HyperLink  ID="linkTimeOffAttachment" Visible ="false"  runat ="server" Text="Attachment"  Font-Size="12px"  onclick="window.open (this.href, 'popupwindow', 'width=700,height=505,left=300,top=150,scrollbars=yes'); return false;" />
                        <br />
                        <asp:ImageButton ID="btnDelete" runat="server" Visible="False" ToolTip="Delete" OnClientClick="<%# ResourceHelper.GetDeleteMessageJavascript()%>" ImageUrl="~/Images/Delete.gif" ImageAlign="AbsMiddle" __designer:wfdid="w7" CommandName="Delete"></asp:ImageButton>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </ItemTemplate>
            <ItemStyle Width="15px" HorizontalAlign="Center" VerticalAlign="Middle" />
        </asp:TemplateField>
        <asp:TemplateField ShowHeader="False" Visible="False">
            <ItemTemplate>
                <asp:Image ID="imgStatus" runat="server" Width="10px" ImageAlign="AbsMiddle" Visible="False" __designer:wfdid="w62"></asp:Image>
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="10px" />
        </asp:TemplateField>

    </Columns>
</x:GridView>
<asp:ObjectDataSource ID="dsAccountEmployeeTimeEntry" runat="server"
    InsertMethod="AddAccountEmployeeTimeEntry" OldValuesParameterFormatString="original_{0}"
    SelectMethod="GetAccountEmployeeTimeEntriesByDate" TypeName="AccountEmployeeTimeEntryBLL"
    UpdateMethod="UpdateAccountEmployeeTimeEntry"
    DeleteMethod="DeleteAccountEmployeeTimeEntry">
    <UpdateParameters>
        <asp:Parameter Name="AccountEmployeeId" Type="Int32" />
        <asp:Parameter Name="TimeEntryDate" Type="DateTime" />
        <asp:Parameter Name="StartTime" Type="String" />
        <asp:Parameter Name="EndTime" Type="String" />
        <asp:Parameter Name="TotalTime" Type="String" />
        <asp:Parameter Name="AccountProjectId" Type="Int32" />
        <asp:Parameter Name="AccountProjectTaskId" Type="Int32" />
        <asp:Parameter Name="Description" Type="String" />
        <asp:Parameter Name="Approved" Type="Boolean" />
        <asp:Parameter Name="TeamLeadApproved" Type="Boolean" />
        <asp:Parameter Name="ProjectManagerApproved" Type="Boolean" />
        <asp:Parameter Name="AdministratorApproved" Type="Boolean" />
        <asp:Parameter Name="ModifiedOn" Type="DateTime" />
        <asp:Parameter Name="Original_AccountEmployeeTimeEntryId" Type="Int32" />
        <asp:Parameter Name="AccountPartyId" Type="Int32" />
        <asp:Parameter Name="Submitted" Type="Boolean" />
        <asp:Parameter Name="AccountWorkTypeId" Type="Int32" />
        <asp:Parameter Name="AccountCostCenterId" Type="Int32" />
        <asp:Parameter Name="TimesheetPeriodType" Type="String" />
        <asp:Parameter Name="PeriodStartDate" Type="DateTime" />
        <asp:Parameter Name="PeriodEndDate" Type="DateTime" />
        <asp:Parameter Name="AccountEmployeeTimeEntryPeriodId" DbType="Guid" />
        <asp:Parameter Name="IsTimeOff" Type="Boolean" />
        <asp:Parameter Name="AccountTimeOffTypeId" DbType="Guid" />
        <asp:Parameter Name="AccountEmployeeTimeEntryApprovalProjectId" DbType="Guid" />
        <asp:Parameter Name="Percentage" Type="Double" />
        <asp:Parameter Name="CustomField1" Type="String" />
        <asp:Parameter Name="CustomField2" Type="String" />
        <asp:Parameter Name="CustomField3" Type="String" />
        <asp:Parameter Name="CustomField4" Type="String" />
        <asp:Parameter Name="CustomField5" Type="String" />
        <asp:Parameter Name="CustomField6" Type="String" />
        <asp:Parameter Name="CustomField7" Type="String" />
        <asp:Parameter Name="CustomField8" Type="String" />
        <asp:Parameter Name="CustomField9" Type="String" />
        <asp:Parameter Name="CustomField10" Type="String" />
        <asp:Parameter Name="CustomField11" Type="String" />
        <asp:Parameter Name="CustomField12" Type="String" />
        <asp:Parameter Name="CustomField13" Type="String" />
        <asp:Parameter Name="CustomField14" Type="String" />
        <asp:Parameter Name="CustomField15" Type="String" />
    </UpdateParameters>
    <DeleteParameters>
        <asp:Parameter Name="Original_AccountEmployeeTimeEntryId" Type="Int32" />
        <asp:Parameter Name="Original_TimeEntryViewType" Type="Object" />
        <asp:Parameter Name="Original_AccountEmployeeId" Type="Int32" />
        <asp:Parameter Name="Original_TimeEntryStartDate" Type="Object" />
        <asp:Parameter Name="Original_TimeEntryEndDate" Type="Object" />
        <asp:Parameter Name="Original_AccountEmployeeTimeEntryApprovalProjectId"
            Type="Object" />
        <asp:Parameter Name="Original_AccountEmployeeTimeEntryPeriodId" Type="Object" />
        <asp:Parameter Name="Original_TimeEntryDate" Type="DateTime" />
    </DeleteParameters>
    <InsertParameters>
        <asp:Parameter Name="AccountEmployeeId" Type="Int32" />
        <asp:Parameter Name="TimeEntryDate" Type="DateTime" />
        <asp:Parameter Name="StartTime" Type="String" />
        <asp:Parameter Name="EndTime" Type="String" />
        <asp:Parameter Name="TotalTime" Type="String" />
        <asp:Parameter Name="AccountProjectId" Type="Int32" />
        <asp:Parameter Name="AccountProjectTaskId" Type="Int32" />
        <asp:Parameter Name="Description" Type="String" />
        <asp:Parameter Name="Approved" Type="Boolean" />
        <asp:Parameter Name="CreatedOn" Type="DateTime" />
        <asp:Parameter Name="ModifiedOn" Type="DateTime" />
        <asp:Parameter Name="AccountPartyId" Type="Int32" />
        <asp:Parameter Name="Submitted" Type="Boolean" />
        <asp:Parameter Name="AccountWorkTypeId" Type="Int32" />
        <asp:Parameter Name="AccountCostCenterId" Type="Int32" />
        <asp:Parameter Name="TimesheetPeriodType" Type="String" />
        <asp:Parameter Name="PeriodStartDate" Type="DateTime" />
        <asp:Parameter Name="PeriodEndDate" Type="DateTime" />
        <asp:Parameter Name="AccountEmployeeTimeEntryPeriodId" DbType="Guid" />
        <asp:Parameter Name="IsTimeOff" Type="Boolean" />
        <asp:Parameter Name="AccountTimeOffTypeId" DbType="Guid" />
        <asp:Parameter Name="AccountEmployeeTimeOffRequestId" DbType="Guid" />
        <asp:Parameter Name="AccountEmployeeTimeEntryApprovalProjectId" DbType="Guid" />
        <asp:Parameter Name="Percentage" Type="Double" />
        <asp:Parameter Name="CustomField1" Type="String" />
        <asp:Parameter Name="CustomField2" Type="String" />
        <asp:Parameter Name="CustomField3" Type="String" />
        <asp:Parameter Name="CustomField4" Type="String" />
        <asp:Parameter Name="CustomField5" Type="String" />
        <asp:Parameter Name="CustomField6" Type="String" />
        <asp:Parameter Name="CustomField7" Type="String" />
        <asp:Parameter Name="CustomField8" Type="String" />
        <asp:Parameter Name="CustomField9" Type="String" />
        <asp:Parameter Name="CustomField10" Type="String" />
        <asp:Parameter Name="CustomField11" Type="String" />
        <asp:Parameter Name="CustomField12" Type="String" />
        <asp:Parameter Name="CustomField13" Type="String" />
        <asp:Parameter Name="CustomField14" Type="String" />
        <asp:Parameter Name="CustomField15" Type="String" />
    </InsertParameters>
    <SelectParameters>
        <asp:Parameter DefaultValue="39" Name="AccountEmployeeId" Type="Int32" />
        <asp:Parameter DefaultValue="8/29/2006" Name="TimeEntryDate" Type="DateTime" />
        <asp:Parameter DefaultValue="" Name="IsCopy" Type="Boolean" />
    </SelectParameters>
</asp:ObjectDataSource>

<script language="javascript">
    // This function should iterate through all the TextBoxes and get the values 
    function UpdateSum() {
        var tBox;
        var deli;
        var sumTextBox;
        var sumPTextBox;
        // clear the sum variable 
        var sumMinutes = 0;
        var sumPercents = 0;
        // Iterate through all the TextBoxes
        tBox = document.getElementsByTagName("INPUT");
        var IsMinutes = false;
        for (i = 0; i < (tBox.length - 2) ; i++) {
            if (tBox[i].type == "text") {
                if (tBox[i].id.indexOf('sumTime') > 0) {
                    sumTextBox = tBox[i];
                }
                if (tBox[i].id.indexOf('TotalTime') > 0) {
                    // The Number function forces the JavaScript to recognizes the input as a number 
                    textValue = tBox[i].value;
                    if (textValue.indexOf(':') > 0) {
                        IsMinutes = true;
                        deli = ':'
                    }
                    if (deli == ':') {
                        minutesValue = GetTotalMinutesOfTime(textValue);
                        sumMinutes += Number(minutesValue);
                    }
                    if (deli != ':') {
                        sumMinutes += Number(textValue.replace(',', '.'));
                    }
                }
                if (tBox[i].id.indexOf('sumPercent') > 0) {
                    sumPTextBox = tBox[i];
                }
                if (tBox[i].id.indexOf('Percentage') > 0) {
                    // The Number function forces the JavaScript to recognizes the input as a number 
                    ptextValue = tBox[i].value;
                    percentsVal = ptextValue;
                    sumPercents += Number(percentsVal);
                }
            }
        }
        if (deli == ':') {
            var h = Math.floor(sumMinutes / 60);
        }
        var pt = Math.floor(sumPercents);
        if (sumTextBox != null) {
            if (deli == ':') {
                sumTextBox.value = padl(h, 2, '0')
                if (IsMinutes == true) {
                    sumTextBox.value = sumTextBox.value + ':' + padl((sumMinutes - (h * 60)), 2, '0');
                }
            }
            if (deli != ':') {
                sumTextBox.value = parseFloat(sumMinutes).toFixed(2);
            }
            if (sumPTextBox != null) {
                sumPTextBox.value = pt + '%';
            }
        }
    }
    function padl(n, w, c) {
        n = String(n);
        while (n.length < w)
            n = c + n;
        return n;
    }
    function GetTimeFromMinutes(minutes, IsMinutes) {
        var h = Math.floor(minutes / 60);
        valueToReturn = padl(h, 2, '0');
        if (IsMinutes == true) {
            valueToReturn = valueToReturn + ':' + padl((minutes - (h * 60)), 2, '0');
        }
        return valueToReturn
    }
    function GetTotalMinutesOfTime(timeValue) {

        if (timeValue == '') {
            return 0;
        }
        if (timeValue.substring(1, 2) == '_') {
            timeValue = '0' + timeValue.substring(0, 1) + timeValue.substring(2)
        }
        timeValue = timeValue.replace('_', '0')
        minutesValue = timeValue.substring(0, 2) * 60
        if (timeValue.indexOf(':') > 0) {
            minutesValue = parseInt(minutesValue) + Number(timeValue.substring(3, 6))
        }
        if (timeValue.indexOf('PM') > 0) {
            if (timeValue.indexOf('12') != -1) {
                if (timeValue.indexOf('12') != 3) {
                    minutesValue = minutesValue - (12 * 60);
                }
            }
            minutesValue = minutesValue + (12 * 60);
        }
        if (timeValue.indexOf('AM') > 0) {
            if (timeValue.indexOf('12') != -1) {
                if (timeValue.indexOf('12') != 3) {
                    minutesValue = minutesValue - (12 * 60);
                }
            }
        }
        return minutesValue;
    }
    function OnTimeChange(targetObject) {
        targetId = targetObject.id;
        if (targetId.indexOf("StartTime") > 0) {
            StartTime = targetObject.value;
            otherId = targetId.replace("StartTime", "EndTime");
            otherobj = window.document.getElementById(otherId);
            EndTime = otherobj.value;
            TotalTimeId = targetId.replace("StartTime", "TotalTime");
        }
        else {
            EndTime = targetObject.value;
            otherId = targetId.replace("EndTime", "StartTime");
            otherobj = window.document.getElementById(otherId);
            StartTime = otherobj.value;
            TotalTimeId = targetId.replace("EndTime", "TotalTime");
        }
        objEndTime = window.document.getElementById(TotalTimeId);
        minStartTime = GetTotalMinutesOfTime(StartTime);
        minEndTime = GetTotalMinutesOfTime(EndTime);
        if (minEndTime == 0) {
            return
        }
        if (minStartTime > minEndTime) {
            minEndTime = minEndTime + (24 * 60)
        }
        minTotalTime = minEndTime - minStartTime;
        if (StartTime.indexOf(':') > 0) {
            IsMinutes = true;
        } else {
            IsMinutes = false;
        }
        strTotalTime = GetTimeFromMinutes(minTotalTime, IsMinutes);
        objEndTime.value = strTotalTime;
        UpdateSum();
    }

    function replaceAll(str, from, to) {
        var idx = str.indexOf(from);
        while (idx > -1) {
            str = str.replace(from, to);
            idx = str.indexOf(from);
        }
        return str;
    }
    </script>


<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <br />
        <asp:Label ID="lblCopyFrom" runat="server" Font-Bold="True" Text="<%$ Resources:TimeLive.Resource, Copy From%> " Visible ="false" ></asp:Label>&nbsp;<ew:CalendarPopup ID="CopyFromCalendarPopup" runat="server" SkinID="DatePicker" Width="80px" Visible ="false" >
        </ew:CalendarPopup>
        <asp:Button ID="btnCopy" runat="server" Text="<%$ Resources:TimeLive.Resource, Copy Timesheet%> " Visible="false" ></asp:Button>
        <asp:Button ID="btnCopyActivities" runat="server" Text="<%$ Resources:TimeLive.Resource, Copy Activities%> " Visible="false"  />
        <asp:Button ID="btnSubmit" runat="server" Text="<%$ Resources:TimeLive.Resource, Submit_text%> " Width="88px" ValidationGroup="TimeEntry" ToolTip="<%$ Resources:TimeLive.Resource, Submit for Approval%> " Visible="False" />
        <asp:Button ID="btnSave" runat="server" Text="<%$ Resources:TimeLive.Resource, Save_text%> " OnClick="Button1_Click" Width="88px" ValidationGroup="TimeEntry" OnClientClick='<%# ResourceHelper.GetSaveMessageJavascriptForDayView()%>' />
    </ContentTemplate>
</asp:UpdatePanel>
<asp:Label ID="lblPermissionMessage" runat="server" Font-Bold="True" Font-Size="Large"
    Text="Non-working day." Visible="False"></asp:Label>
<br />

<br />
<div style="text-align: left">
    <uc2:ctlStatusLegend ID="CtlStatusLegend1" runat="server" />
    &nbsp;
</div>
<br />
<%If DBUtilities.GetShowClientInTimesheet = False And DBUtilities.IsShowCostCenterInTimeSheet = False And DBUtilities.IsShowWorkTypeInTimeSheet = False And DBUtilities.GetShowClockStartEnd = False Then%>
<%Else%>

<% End If %>
<% End If %>
<%  If DBUtilities.IsAttendanceFeature Then%>
<uc1:ctlAccountEmployeeAttendanceList ID="CtlAccountEmployeeAttendanceList1" runat="server" />
<br />
<%  End If%>

<script language="javascript">
</script>
