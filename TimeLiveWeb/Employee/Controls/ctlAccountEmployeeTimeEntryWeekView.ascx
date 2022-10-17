<%@ Control AutoEventWireup="false" CodeFile="ctlAccountEmployeeTimeEntryWeekView.ascx.vb" ClientIDMode="Predictable"
    Inherits="Employee_Controls_ctlAccountEmployeeTimeEntryWeekView" Language="VB" %>
<%@ Register Src="ctlStatusLegend.ascx" TagName="ctlStatusLegend" TagPrefix="uc1" %>
<%@ Register Src="ctlAccountEmployeeTimeEntryApprovalDetailsReadOnly.ascx" TagName="ctlAccountEmployeeTimeEntryApprovalDetailsReadOnly"
    TagPrefix="uc2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc2" %>
<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<%@ Register Assembly="LiveTools" Namespace="LiveTools" TagPrefix="cc1" %>
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
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.1.1/jquery.min.js"></script>
<style type="text/css">
    .ddl {
        margin-top: -15px;
    }

    .AttachmentLink {
        font-size: 11px;
        display: inline-block;
        padding: 0 2px;
        margin-top: -15px;
    }

    .circle {
        display: inline-block;
        height: 11px;
        width: 11px;
        border-radius: 55%; /* or 50% */
        background-color: blue;
        color: white;
        margin-top: -12px;
        line-height: 12px;
    }
    #WarningHolder1
    {
     width:50px;
     display: block;
     width: 20em;
     float: right;
     margin-right: 230px;
     margin-top: -5em;
     font-weight:bold;
    }
    #WarningHolder2
    { 
      display: block;
      width: 20em;
      float: right;
      margin-right: 230px;
      margin-top: -4em;
      font-weight:bold;
    }
    #WarningHolder3
    {
      display: block;
      width: 25em;
      float: right;
      margin-right: 165px;
      margin-top: -3em;
      font-weight:bold;
    }
    .Warning 
    {
     position:absolute;
     height : 50px;
     width : 60px;
     z-index: 2;
    }
    #WarningLabels {
    padding-left : 560px;
    position:absolute;
    list-style-type: none;
    }
    .WarningsHolder{
    position:absolute;
    padding-left : 520px; 
    }
</style>
<div class="fieldset" style="width: 98%">
    <p>
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <asp:Button ID="btnDayView" runat="server" Text="<%$ Resources:TimeLive.Resource, Day View%>" Width="115px" />&nbsp<asp:Button ID="btnMyPeriods" runat="server" Text="<%$ Resources:TimeLive.Resource, Timesheet Periods%>" Width="115px" /><%If DBUtilities.GetSessionAccountId = 6455 Then%>&nbsp<asp:Button ID="btnTimesheetTemplate" runat="server" Text="Timesheet Template" Width="115px" /><%End If%>&nbsp<asp:Button ID="btnTopSave" runat="server" Text="<%$ Resources:TimeLive.Resource, Save_text%> " Width="115px" Enabled="true" Visible="true" CssClass="DisabledButton" OnClientClick='<%# ResourceHelper.GetSaveMessageJavascript()%>' OnClick="Button1_Click1" />&nbsp<asp:Button ID="btnTopSubmit" runat="server" Text="<%$ Resources:TimeLive.Resource, Submit_text%> " Width="115px" Enabled="true" Visible="true" CssClass="DisabledButton" ToolTip="Submit for Approval" OnClick="btnSubmit_Click" />&nbsp<asp:Button ID="btnTimerTimesheet" runat="server" CssClass="DisabledButton" OnClick="btnTimerTimesheet_Click" Text="<%$ Resources:TimeLive.Resource, Start Timer%>" ToolTip="<%$ Resources:TimeLive.Resource, Start Timer%>" Visible="true" Width="115px" />&nbsp<asp:Button ID="btnAudit" runat="server" Text="<%$ Resources:TimeLive.Resource, Audit%>" Visible="False" Width="115px" />
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:HyperLink ID="lnkTimesheetPeriodList" runat="server" Visible="False">[lnkTimesheetPeriodList]</asp:HyperLink><asp:HyperLink ID="lnkDayView" runat="server" Visible="False">[lnkDayView]</asp:HyperLink>
    </p>
    <p>
        <asp:Label ID="EmployeeNameLabel" runat="server" Text="<%$ Resources:TimeLive.Resource, Employees: %>"
            Width="150px" Font-Bold="true" Font-Size="11px"></asp:Label>
        <asp:DropDownList ID="ddlEmployee" runat="server" AutoPostBack="True" Width="300px">
        </asp:DropDownList>
    </p>
    <p>
        <asp:Label ID="Label2" runat="server" Text="<%$ Resources:TimeLive.Resource, Current Week: %>"
            Width="150px" Font-Bold="true" Font-Size="11px"></asp:Label>


        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/right.gif" ToolTip="<%$ Resources:TimeLive.Resource, Previous Week%> " /><asp:Label ID="lblCurrenctdate" runat="server" Font-Bold="True"
            Font-Size="11px" Text="Label"></asp:Label><asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Images/left.gif"
                ToolTip="<%$ Resources:TimeLive.Resource, Next Week%> " />
    </p>
    <p id="WarningsHolder" runat="server">
    <img src="../../img/TimeEntryWarning.png" id="Warning" runat="server" class="Warning"/>
    <ul id="WarningLabels">
        <li><asp:label runat="server" id="WarningHolder1"></asp:label></li>
        <li><asp:label runat="server" id="WarningHolder2"></asp:label></li>
        <li><asp:label runat="server" id="WarningHolder3"></asp:label></li>
        <li><asp:label runat="server" id="WarningText"></asp:label><asp:LinkButton runat="server" id="WarningLink"></asp:LinkButton></li>

    </ul>
    </p>
    <p>
        <asp:Label ID="Label1" runat="server" Text="<%$ Resources:TimeLive.Resource, Time Entry Date : %>"
            Width="150px" Font-Bold="true" Font-Size="11px"></asp:Label>
        <ew:CalendarPopup ID="txtTimeEntryDate" runat="server" SkinID="DatePicker" Width="55px" AutoPostBack="True">
        </ew:CalendarPopup>
    </p> 
    <p>
        <asp:Label ID="lblTSTotal" runat="server" Text="<%$ Resources:TimeLive.Resource, Timesheet Total :%> " Width="150px" Font-Bold="true" Font-Size="11px"></asp:Label>
        <asp:TextBox ID="txtTimesheetTotal" runat="server" Width="55px" ReadOnly="True"></asp:TextBox>
    </p>
    <p>
        <asp:Label ID="Label3" runat="server" CssClass="statuslabel" Text="<%$ Resources:TimeLive.Resource, Timesheet Status : %>" Width="150px" Font-Bold="true" Font-Size="11px"></asp:Label>
        <asp:Image ID="imgTSL" runat="server" ImageUrl="~/Images/clearpixel.gif"
            Width="12px" AlternateText="Timesheet Status" CssClass="statuslabel" />
        <asp:Label ID="lblTimesheetStatus" runat="server" Text="Label" CssClass="statuslabel" Width="150px" Font-Bold="true" Font-Size="11px"></asp:Label>
    </p>
</div>

<p>
    <asp:GridView ID="G" runat="server" AutoGenerateColumns="False"
        Caption="<%$ Resources:TimeLive.Resource, Time Entry Week View %>"
        DataSourceID="dsAccountEmployeeTimeEntriesWeek" EnableInsert="True" EnableViewState="False"
        HeaderStyle-Height="25px" InsertRowCount="1" SaveButtonID="" ShowFooter="True"
        Width="100%" CssClass="xGridViewTS">
        <Columns>
            <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Client %>">
                <HeaderTemplate>
                    <asp:Label ID="lblClient" Text='<%# ResourceHelper.GetFromResource("Client Name") %>' runat="server" __designer:wfdid="w5"></asp:Label>
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:DropDownList ID="C" Width="400px" runat="server" DataValueField="AccountPartyId"
                        DataTextField="PartyName" __designer:wfdid="w1" onkeydown="return EnterEvent(event,this);">
                    </asp:DropDownList>
                    <asp:Label ID="lblTimeTypesClient" Text="<%$ Resources:TimeLive.Resource, Time Off%>" runat="server" Visible="False" Font-Bold="True" __designer:wfdid="w2"></asp:Label><br />
                    <asp:ObjectDataSource ID="dsAccountClientObject" runat="server" TypeName="AccountPartyBLL" SelectMethod="GetAccountPartiesForTimeEntryByAccountEmployeeId" OldValuesParameterFormatString="original_{0}" __designer:wfdid="w3">
                        <SelectParameters>
                            <asp:SessionParameter SessionField="AccountEmployeeID" Type="Int32" Name="AccountEmployeeId"></asp:SessionParameter>
                            <asp:Parameter DefaultValue="0" Name="AccountClientId" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    <asp:Image ID="imgC" Width="10px" runat="server" ImageUrl="~/Images/clearpixel.gif" __designer:wfdid="w4" EnableTheming="True"></asp:Image>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="400px" VerticalAlign="Middle" Wrap="True" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Project %>">
                <HeaderTemplate>
                    <asp:Label ID="lblProject" Text='<%# ResourceHelper.GetFromResource("Project Name") %>' runat="server" __designer:wfdid="w33"></asp:Label>
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblTimeTypes" Width="15%" Text="Label" runat="server" Visible="False" CssClass="ddl" __designer:wfdid="w27"></asp:Label>
                    <asp:DropDownList ID="P" runat="server" DataValueField="AccountProjectId" onkeydown="return EnterEvent(event,this);" DataTextField="ProjectName" __designer:wfdid="w28" onkeypress="return event.keyCode != 13;"></asp:DropDownList><br />
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
                    <asp:ObjectDataSource ID="dsAccountProjectTasksObject" runat="server" TypeName="AccountProjectTaskBLL" OldValuesParameterFormatString="original_{0}" __designer:wfdid="w30">
                        <SelectParameters>
                            <asp:Parameter Type="Int32" Name="AccountProjectId"></asp:Parameter>
                            <asp:SessionParameter SessionField="AccountEmployeeId" Type="Int32" DefaultValue="39" Name="AccountEmployeeId"></asp:SessionParameter>
                            <asp:Parameter Type="Int32" Name="AccountProjectTaskId"></asp:Parameter>
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    <aspToolkit:CascadingDropDown ID="CP" runat="server" __designer:wfdid="w31" TargetControlID="P" UseContextKey="true" Category="Project" ServiceMethod="GetAccountProjectsByClient" ServicePath="~/Services/ProjectService.asmx" PromptText="Select Project" ParentControlID="C" LoadingText="Loading"></aspToolkit:CascadingDropDown>

                    <asp:Image ID="imgP" Width="10px" runat="server" ImageUrl="~/Images/clearpixel.gif" __designer:wfdid="w32" EnableTheming="True"></asp:Image>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="center" Width="400px" VerticalAlign="Middle" Height="55px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Task %>">
                <HeaderTemplate>
                    <asp:Label ID="lblProjectTask" Text='<%# ResourceHelper.GetFromResource("Project Task") %>' runat="server" __designer:wfdid="w39"></asp:Label>
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:DropDownList ID="PT" Width="400px" runat="server" DataValueField="AccountProjectTaskId" DataTextField="TaskName" __designer:wfdid="w34" onkeydown="return EnterEvent(event,this);" Enabled="False"></asp:DropDownList>
                    <asp:DropDownList ID="ddlTimeOffTypeId" Width="100%" runat="server" onkeydown="return EnterEvent(event,this);" Visible="False" DataValueField="AccountTimeOffTypeId" DataTextField="BriefExplanation" __designer:wfdid="w35" Enabled="false"></asp:DropDownList>

                    <aspToolkit:CascadingDropDown ID="TT" runat="server" __designer:wfdid="w37" TargetControlID="ddlTimeOffTypeId" Category="Tasks" ServiceMethod="GetAccountTimeOffTypesInTimesheet" ServicePath="~/Services/ProjectService.asmx" PromptText="<%$ Resources:TimeLive.Resource, Select Tasks%>" ParentControlID="P" LoadingText="Loading" Enabled="True"></aspToolkit:CascadingDropDown>
                    <aspToolkit:CascadingDropDown ID="CT" runat="server" __designer:wfdid="w37" TargetControlID="PT" Category="Tasks" ServiceMethod="GetAccountProjectTasksInTimeSheet" ServicePath="~/Services/ProjectService.asmx" PromptText="<%$ Resources:TimeLive.Resource, Select Tasks%>" ParentControlID="P" LoadingText="Loading" Enabled="True"></aspToolkit:CascadingDropDown>
                    <asp:Image ID="imgPT" Width="10px" runat="server" ImageUrl="~/Images/clearpixel.gif" __designer:wfdid="w38" EnableTheming="True"></asp:Image>
                    <asp:ObjectDataSource ID="dsTimeOffTypesObject" runat="server" TypeName="AccountTimeOffTypeBLL" SelectMethod="GetAccountTimeOffTypesByAccountIdAccountEmployeeIdAndRequestRequired" OldValuesParameterFormatString="original_{0}" __designer:wfdid="w36">
                        <SelectParameters>
                            <asp:SessionParameter Name="AccountEmployeeId" SessionField="AccountEmployeeId"
                                Type="Int32" />
                            <asp:SessionParameter SessionField="AccountId" Type="Int32" Name="AccountId"></asp:SessionParameter>
                            <asp:Parameter Type="Boolean" DefaultValue="False" Name="IsTimeOffRequestRequired"></asp:Parameter>
                            <asp:Parameter Name="AccountTimeOffTypeId" DbType="Guid"></asp:Parameter>
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="400px" VerticalAlign="Middle" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Cost Center %>">
                <HeaderTemplate>
                    <asp:Label ID="lblCostCenter" Text='<%# ResourceHelper.GetFromResource("Cost Center") %>' runat="server" __designer:wfdid="w22"></asp:Label>
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:DropDownList ID="CC" Width="150px" runat="server" DataSourceID="dsAccountCostCenterObject" onkeydown="return EnterEvent(event,this);" DataValueField="AccountCostCenterId" DataTextField="AccountCostCenter" __designer:wfdid="w19" AppendDataBoundItems="True">
                        <asp:ListItem Selected="True" Value="0"></asp:ListItem>
                    </asp:DropDownList><br />
                    <asp:ObjectDataSource ID="dsAccountCostCenterObject" runat="server"
                        TypeName="AccountCostCenterBLL"
                        SelectMethod="GetAccountCostCenterByAccountIdAndIsDisabled"
                        OldValuesParameterFormatString="original_{0}" __designer:wfdid="w20">
                        <SelectParameters>
                            <asp:SessionParameter SessionField="AccountId" DefaultValue="131" Name="AccountId" Type="Int32"></asp:SessionParameter>
                            <asp:Parameter Name="AccountCostCenterId" Type="Int32"></asp:Parameter>
                            <asp:ControlParameter ControlID="ddlEmployee" Name="AccountEmployeeId"
                                PropertyName="SelectedValue" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    <asp:Image ID="imgCC" Width="10px" runat="server" ImageUrl="~/Images/clearpixel.gif" __designer:wfdid="w21" EnableTheming="True"></asp:Image>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="150px" VerticalAlign="Middle" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Work Type %>">
                <HeaderTemplate>
                    <asp:Label ID="lblWorkType" Text='<%# ResourceHelper.GetFromResource("Work Type") %>' runat="server" __designer:wfdid="w26"></asp:Label>
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:DropDownList ID="W" Width="150px" runat="server" DataSourceID="dsAccountWorkTypeObject" DataValueField="AccountWorkTypeId" onkeydown="return EnterEvent(event,this);" DataTextField="AccountWorkType" __designer:wfdid="w23"></asp:DropDownList><br />
                    <asp:ObjectDataSource ID="dsAccountWorkTypeObject" runat="server" TypeName="AccountWorkTypeBLL" SelectMethod="GetAccountWorkTypesByAccountIdAndIsDisabled" OldValuesParameterFormatString="original_{0}" __designer:wfdid="w24">
                        <SelectParameters>
                            <asp:SessionParameter SessionField="AccountId" Type="Int32" DefaultValue="131" Name="AccountId"></asp:SessionParameter>
                            <asp:Parameter Type="Int32" Name="AccountWorkTypeId"></asp:Parameter>
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    <asp:Image ID="imgWT" Width="10px" runat="server" ImageUrl="~/Images/clearpixel.gif" __designer:wfdid="w25" EnableTheming="True"></asp:Image>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="150px" VerticalAlign="Middle" />
            </asp:TemplateField>
            <asp:TemplateField Visible="false">
                <ItemTemplate>
                    <asp:Image ID="Image1" runat="server" Width="10px" ImageUrl="~/Images/clearpixel.gif" __designer:wfdid="w5" EnableTheming="True" Height="6px"></asp:Image><br />
                    <asp:Label ID="lS" runat="server" Width="33px" Text="Start:" CssClass="FormViewLabelCell" __designer:wfdid="w6" Height="20px"></asp:Label><asp:Label ID="lE" runat="server" Width="33px" Text="End:" CssClass="FormViewLabelCell" __designer:wfdid="w7" Height="20px"></asp:Label><asp:Label ID="lT" runat="server" Width="33px" Text="Total:" CssClass="FormViewLabelCell" __designer:wfdid="w8" Height="20px"></asp:Label>
                    <asp:Label ID="lP" runat="server" Width="40px" Text="Task%:"
                        CssClass="FormViewLabelCell" __designer:wfdid="w8" Height="20px"></asp:Label><br />
                    <asp:Image ID="imgT" runat="server" Width="10px" ImageUrl="~/Images/clearpixel.gif" __designer:wfdid="w9" EnableTheming="True"></asp:Image>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="33px" VerticalAlign="Middle" />

            </asp:TemplateField>
        </Columns>
        <HeaderStyle Height="25px" />
    </asp:GridView>
</p>

<p>
    <asp:Label ID="Label4" runat="server" Text="<%$ Resources:TimeLive.Resource, Description: %>"
        Width="150px" Font-Bold="True"></asp:Label>
</p>
<p>
    <asp:TextBox ID="txtPeriodDescription" runat="server" Height="75px" TextMode="MultiLine"
        Width="35%"></asp:TextBox>
</p>

<p>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Button ID="WeekButton1" runat="server" Text="<%$ Resources:TimeLive.Resource, Save_text%> " Width="104px" Enabled="true" Visible="true" CssClass="DisabledButton" OnClientClick='<%# ResourceHelper.GetSaveMessageJavascript()%>' />&nbsp<asp:Button ID="btnSubmit" runat="server" Text="<%$ Resources:TimeLive.Resource, Submit_text%> " Width="104px" Enabled="true" Visible="true" CssClass="DisabledButton" ToolTip="Submit for Approval" />
            <br />
            <asp:Label ID="lblPermissionMessage" runat="server" Font-Bold="True" Font-Size="Large"
                Text="Non-working day." Visible="False"></asp:Label>
            <br />
            <%--<%If DBUtilities.ShowCopyTimesheetButton = "True" Or DBUtilities.ShowCopyActivitiesButtonInTimesheet = "True" Then%>--%>
            <asp:Label ID="lblCopyFrom" runat="server" Text="<%$ Resources:TimeLive.Resource, Copy From%>" Font-Bold="True"></asp:Label>
            <ew:CalendarPopup ID="CopyFromCalendarPopup" runat="server" SkinID="DatePicker" Width="80px">
            </ew:CalendarPopup>
            &nbsp;<asp:Button ID="btnCopy" runat="server" Text="<%$ Resources:TimeLive.Resource, Copy Timesheet%> "></asp:Button>&nbsp;<asp:Button ID="btnCopyActivities" runat="server" Text="<%$ Resources:TimeLive.Resource, Copy Activities%> "></asp:Button>
            <%If DBUtilities.GetSessionAccountId = 6455 Then%>
            <asp:Button ID="btnCopyFromTemplate" runat="server"
                Text="Copy From Template"></asp:Button>
            <%End If %>
            <asp:Button ID="btnPrint" runat="server"
                Text="<%$ Resources:TimeLive.Resource, Print%> " Width="75px" />
            <%If DBUtilities.EnableOfflineTimesheet = "True" Then%>
            <asp:Button ID="btnExportOfflineTimesheet" runat="server" Enabled="true"
                Text="<%$ Resources:TimeLive.Resource, Export Offline Timesheet%> " CssClass="DisabledButton" ToolTip="Export Offline Timesheet"
                Visible="true" Width="150px" />
            <asp:Button ID="btnImportOfflineTimesheet" runat="server" Enabled="true"
                Text="<%$ Resources:TimeLive.Resource, Import Offline Timesheet%> " CssClass="DisabledButton" ToolTip="Import Offline Timesheet"
                Visible="true" Width="150px" />
            <%End If%>
            <%If DBUtilities.GetSessionAccountId = 6373 Then%>
            <asp:Button ID="btnAttachment" runat="server"
                Text="<%$ Resources:TimeLive.Resource, Attachment%> " Width="75px"
                Visible="False" />
            <%End If%>
        </ContentTemplate>
    </asp:UpdatePanel>
</p>
<p>
</p>


<p>
    <uc1:ctlStatusLegend ID="SL" runat="server" />
    <uc2:ctlAccountEmployeeTimeEntryApprovalDetailsReadOnly ID="CW2"
        runat="server" />
</p>


<asp:ObjectDataSource ID="dsAccountEmployeeTimeEntriesWeek" runat="server"
    InsertMethod="AddAccountEmployeeTimeEntry" OldValuesParameterFormatString="original_{0}"
    SelectMethod="GetAccountEmployeeTimeEntriesForPeriodView" TypeName="AccountEmployeeTimeEntryBLL"
    UpdateMethod="UpdateAccountEmployeeTimeEntry" DeleteMethod="DeleteAccountEmployeeTimeEntry">
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
        <asp:Parameter Name="AccountEmployeeTimeEntryApprovalProjectId"
            DbType="Guid" />
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
    <SelectParameters>
        <asp:Parameter DefaultValue="39" Name="AccountEmployeeId" Type="Int32" />
        <asp:Parameter DefaultValue="11/1/2006" Name="TimeEntryStartDate" Type="DateTime" />
        <asp:Parameter DefaultValue="11/7/2006" Name="TimeEntryEndDate" Type="DateTime" />
        <asp:Parameter Name="AccountEmployeeTimeEntryPeriodId" DbType="Guid" />
        <asp:Parameter Name="IsCopy" Type="Boolean" />
        <asp:Parameter Name="CopyToStartDate" Type="DateTime" />
        <asp:Parameter Name="CopyToEndDate" Type="DateTime" />
        <asp:Parameter Name="IsFromMobileTimeSheet" Type="Boolean" />
        <asp:Parameter Name="IsFromTemplate" Type="Boolean" />
    </SelectParameters>
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
        <asp:Parameter Name="AccountEmployeeTimeEntryApprovalProjectId"
            DbType="Guid" />
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
    <DeleteParameters>
        <asp:Parameter Name="Original_AccountEmployeeTimeEntryId" Type="Int32" />
        <asp:Parameter Name="Original_TimeEntryViewType" Type="Object" />
        <asp:Parameter Name="Original_AccountEmployeeId" Type="Int32" />
        <asp:Parameter Name="Original_TimeEntryStartDate" Type="Object" />
        <asp:Parameter Name="Original_TimeEntryEndDate" Type="Object" />
        <asp:Parameter Name="Original_AccountEmployeeTimeEntryApprovalProjectId" Type="Object" />
        <asp:Parameter Name="Original_AccountEmployeeTimeEntryPeriodId" Type="Object" />
        <asp:Parameter Name="Original_TimeEntryDate" Type="DateTime" />
    </DeleteParameters>
</asp:ObjectDataSource>

