<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlAccountProjectTaskForm.ascx.vb" Inherits="ProjectAdmin_Controls_ctlAccountProjectTaskForm" %>
<%@ Register Assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2" Namespace="eWorld.UI" TagPrefix="ew" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc2" %>
<%@ Register Src="ctlAccountProjectTaskAttachmentList.ascx" TagName="ctlAccountProjectTaskAttachmentList" TagPrefix="uc1" %>
<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<style type="text/css">
    .style6
    {
        width: 15%;
    }
    .style7
    {
        height: 26px;
        width: 15%;
    }
    .style13
    {
        height: 26px;
        width: 35%;
    }
    .style14
    {
        width: 23%;
        height: 26px;
    }
    .style15
    {
        width: 60%;
        height: 26px;
    }
    </style>
<style type="text/css">
    
    .tooltip{
    display: inline;
    position: relative;
    text-align:left;
}
.tooltip:hover:after{
    background: #333;
    background: rgba(0,0,0,.8);
    border-radius: 5px;
    bottom: 26px;
    color: #fff;
    content: attr(title);
    left: 20%;
    padding: 5px 15px;
    position: absolute;
    z-index: 10000000;
    width: 220px;
    line-height:20px;
    
}
.tooltip:hover:before{
    border: solid;
    border-color: #333 transparent;
    border-width: 6px 6px 0 6px;
    bottom: 20px;
    content: "";
    left: 50%;
    position: absolute;
    z-index: 10000000;
    line-height:20px;
}
</style>
<%--<script src="<%= Page.ResolveUrl("~/js/libs/jquery-1.7.2.min.js") %>"></script>
<script type="text/javascript">
    $(function () {
        $("#Add").click(function () {
            var ddlAccountProjectMilestoneIdinsert = $("#ddlAccountProjectMilestoneIdinsert");
            var selectedValue = ddlAccountProjectMilestoneIdinsert.val();
            if (selectedValue == null) {
                alert("Please select Milestone in Advance Option.");
                return false;
            }
        });
    });
</script>--%>
<script type="text/javascript">
    function validate() {
        var MilestoneId = document.getElementById('ddlAccountProjectMilestoneIdinsert').value;
        if (MilestoneId == "") {
            alert("Please select Milestone in Advance Option.");
            return false;
        }
    }
</script>
<script language="vb" runat="server">
    ''Form View Insert
    Sub ValidateListAndCheck(ByVal sender As Object, ByVal args As ServerValidateEventArgs)
        Dim n As Integer = 0
        Dim l As ListBox = Me.FormView1.FindControl("ListBoxEmployees")
        If CType(Me.FormView1.FindControl("CheckBox1"), CheckBox).Checked <> True Then
            If CType(Me.FormView1.FindControl("CheckBox2"), CheckBox).Checked <> True Then
                For Each s As ListItem In l.Items
                    If s.Selected = True Then
                        n = n + 1
                    End If
                    If n <> 0 Then
                        args.IsValid = True
                    Else
                        args.IsValid = False
                    End If
                Next
            End If
        End If
    End Sub
    ''Form View edit
    Sub ValidateListAndCheckUpdate(ByVal sender As Object, ByVal args As ServerValidateEventArgs)
        Dim n As Integer = 0
        Dim l As ListBox = Me.FormView1.FindControl("ListBoxEmployeesUpdate")
        'If CType(Me.FormView1.FindControl("CheckBox1"), CheckBox).Checked <> True Then
        If CType(Me.FormView1.FindControl("CheckBox3"), CheckBox).Checked <> True Then
            For Each s As ListItem In l.Items
                If s.Selected = True Then
                    n = n + 1
                End If
                If n <> 0 Then
                    args.IsValid = True
                Else
                    args.IsValid = False
                End If
            Next
        End If
        'End If
    End Sub



</script>
<asp:FormView ID="FormView1" runat="server" DataKeyNames="AccountProjectTaskId,Predecessors" DataSourceID="dsAccountProjectTaskFormObject" DefaultMode="Insert" 
            OnPageIndexChanging="FormView1_PageIndexChanging2" SkinID="formviewSkinEmployee" Width="98%">
<EditItemTemplate>
                <table ID="Table1" class="xview" width="100%">
                    <tr>
                        <th class="caption" colspan="2" style="height: 21px">
                            <asp:Literal ID="Literal4" runat="server" Text='<%# ResourceHelper.GetFromResource("Project Task Information") %>' />
                        </th>
                    </tr>
                    <tr>
                        <th class="FormViewSubHeader" colspan="2" style="height: 21px">
                            <asp:Literal ID="Literal1" runat="server" Text='<%# ResourceHelper.GetFromResource("Basic") %>' />
                        </th>
                    </tr>
                    <tr>
                        <td align="right" colspan="2" style="height: 21px; padding-top: 5px; padding-right: 5px;">
                            <asp:Button ID="btnTaskTeam" runat="server" OnClick="btnTaskTeam_Click" Text='<%# ResourceHelper.GetFromResource("Task Team") %>' CommandName="Task Team" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="FormViewLabelCell" style="width: 23%; height: 26px">
                            <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="TaskCodeTextBoxEdit">
                            <asp:Literal ID="Literal601" runat="server" Text='<%# ResourceHelper.GetFromResource("Task Code:") %>' /></asp:Label></td><td colspan="3" style="height: 26px">
                            <asp:TextBox ID="TaskCodeTextBoxEdit" runat="server" MaxLength="15" Text='<%# Bind("TaskCode") %>' Width="110px"></asp:TextBox></td></tr><tr>
                        <td align="right" class="FormViewLabelCell" style="width: 23%; height: 26px">
                            <span class="reqasterisk">*</span><asp:Label ID="Label1" runat="server" AssociatedControlID="TaskNameTextBox">
                            <asp:Literal ID="Literal7" runat="server" Text='<%# ResourceHelper.GetFromResource("Task Name:") %>' /></asp:Label></td><td style="height: 26px">
                            <asp:TextBox ID="TaskNameTextBox" runat="server" MaxLength="100" Text='<%# Bind("TaskName") %>' Width="336px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TaskNameTextBox" Display="Dynamic" ErrorMessage="*"  Width="8px"></asp:RequiredFieldValidator></td></tr><tr>
                        <td align="right" class="FormViewLabelCell" style="width: 23%; height: 26px">
                            <asp:Label ID="Label4" runat="server" AssociatedControlID="TaskDescriptionTextBox">
                            <asp:Literal ID="Literal8" runat="server" Text='<%# ResourceHelper.GetFromResource("Task Description:") %>' /></asp:Label></td><td colspan="3" style="height: 26px">
                            <asp:TextBox ID="TaskDescriptionTextBox" runat="server" Height="70px" Rows="6" Text='<%# Bind("TaskDescription") %>' TextMode="MultiLine"  Width="336px"></asp:TextBox></td></tr><tr>
                        <td align="right" class="FormViewLabelCell" style="width: 23%; height: 26px">
                                <asp:Literal ID="Literal9" runat="server" Text='<%# ResourceHelper.GetFromResource("Task Type:") %>' />
                        </td>
                        <td colspan="3" style="height: 26px">
                            <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="dsAccountProjectTaskTypeObject" DataTextField="TaskType" DataValueField="AccountTaskTypeId"  Width="122px"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="FormViewLabelCell" style="width: 23%; height: 26px"><asp:Literal ID="Literal2" runat="server" Text='<%# ResourceHelper.GetFromResource("Start Date:") %>' />
                        </td>
                        <td class="style13">
                            <ew:CalendarPopup ID="StartDate" runat="server" SelectedValue='<%# Bind("StartDate") %>' SkinId="DatePicker" Width="55px"></ew:CalendarPopup>
                        </td>
                    </tr>
                    <tr>
                        <td class="FormViewLabelCell" style="width: 23%; height: 26px"><asp:Literal ID="Literal11" runat="server" Text='<%# ResourceHelper.GetFromResource("Due Date:") %>' />
                        </td>
                        <td class="style15"><ew:CalendarPopup ID="DeadlineDate" runat="server" SelectedValue='<%# Bind("DeadlineDate") %>' SkinId="DatePicker" Width="55px"></ew:CalendarPopup>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="FormViewLabelCell" style="width: 23%; height: 26px; padding-bottom: 41px;">
                            <a href="#" title="Use Ctrl + Left mouse click to assign resources to this task." class="tooltip">
                            <img style="vertical-align: middle;padding-bottom: 2px;" title="" src="../Images/info.png" /></a><asp:Literal 
                                ID="Literal21" runat="server" 
                                Text='<%# ResourceHelper.GetFromResource("Assign To") %>' />: </td><td style="height: 26px"><asp:ListBox ID="ListBoxEmployeesUpdate" runat="server" DataSourceID="dsAccountProjectTask" DataTextField="FullName" DataValueField="AccountEmployeeId" SelectionMode="Multiple" Width="350px"></asp:ListBox><br /><asp:CustomValidator ID="CustomValidator2" runat="server" CssClass="ErrorMessage" Display="Dynamic" EnableClientScript="False" ErrorMessage="Select Assigned To:" OnServerValidate="ValidateListAndCheckUpdate" ValidateEmptyText="True" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="FormViewLabelCell" style="width: 23%; height: 26px">
                            <a href="#" title="By checking this, this task will assign to all employees in this project." class="tooltip"><img style="vertical-align: middle;padding-bottom: 2px;" title="" src="../Images/info.png" /></a>
                            <asp:Literal ID="Literal14" runat="server" Text='<%# ResourceHelper.GetFromResource("All Employee Task:") %>' />
                        </td>
                        <td style="height: 26px"><asp:CheckBox ID="CheckBox3" runat="server" Checked='<%# Bind("IsForAllEmployees") %>'  />
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="FormViewLabelCell" style="width: 23%; height: 26px">
                            <a href="#" title="By checking this, this task will become all project's task in account." class="tooltip"><img style="vertical-align: middle;padding-bottom: 2px;" title="" src="../Images/info.png" /></a>
                            <asp:Literal ID="Literal15" runat="server" Text='<%# ResourceHelper.GetFromResource("All Project Task:") %>' />
                        </td>
                        <td style="height: 26px">
                            <asp:CheckBox ID="CheckBox5" runat="server" Checked='<%# iif(isdbnull(eval("IsForAllProjectTask")),"False",eval("IsForAllProjectTask")) %>' />
                        </td>
                    </tr>
                    <tr>
                        <td align="left" colspan="2">
                            <cc2:Accordion ID="MyAccordion" runat="server" SelectedIndex="7" HeaderCssClass="accordionHeader" HeaderSelectedCssClass="accordionHeaderSelected" ContentCssClass="accordionContent" FadeTransitions="true" FramesPerSecond="40" TransitionDuration="250" AutoSize="None" RequireOpenedPane="False" SuppressHeaderPostbacks="true" onitemcreated="MyAccordion_ItemCreated" onload="MyAccordion_Load"><Panes>
                            <cc2:AccordionPane ID="AccordionPane1" runat="server" Visible="True">
                                <Header><a href="" class="accordionLink">&nbsp;<asp:Literal ID="Literal63" runat="server" Text='<%# ResourceHelper.GetFromResource("Advance Options") %>' /></a></Header>
                                <Content><table class="xview" style="width: 99.5%; border:0">
                    <tr>
                        <td align="right" class="FormViewLabelCell" style="width: 23%; height: 26px">
                            <asp:Literal ID="Literal3" runat="server" Text='<%# ResourceHelper.GetFromResource("Parent Task:") %>' />
                        </td>
                        <td colspan="3" style="height: 26px">
                            <asp:DropDownList ID="ddlParentAccountProjectTaskId" runat="server" AppendDataBoundItems="True" DataSourceID="dsParentAccountProjectTaskObject" DataTextField="TaskName" DataValueField="AccountProjectTaskId" Width="350px"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="FormViewLabelCell" style="height: 26px; width: 23%;">
                            <asp:Literal ID="Literal5" runat="server" Text='<%# ResourceHelper.GetFromResource("Milestone:") %>' />
                        </td>
                        <td colspan="3" style="height: 26px">
                            <asp:DropDownList ID="ddlAccountProjectMilestoneId" runat="server"  Width="350px"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="FormViewLabelCell" style="width: 23%; height: 26px">
                            <asp:Literal ID="Literal22" runat="server" Text="<%$ Resources:TimeLive.Resource, Estimated Cost:%> " />
                        </td>
                        <td colspan="3" style="height: 26px">
                            <asp:DropDownList ID="ddlEstimatedCurrencyId" runat="server" DataSourceID="dsEstimatedCurrencyObject" DataTextField="CurrencyCode" DataValueField="AccountCurrencyId" Width="75px"></asp:DropDownList>&nbsp; <asp:TextBox ID="EstimatedCostTextBox" runat="server" Text='<%# Bind("EstimatedCost") %>' Width="56px" style="text-align:right;"></asp:TextBox><asp:RangeValidator ID="RangeValidator4" runat="server" ControlToValidate="EstimatedCostTextBox"  CssClass="ErrorMessage" Display="Dynamic" ErrorMessage="Numeric Required" Font-Bold="False" MaximumValue="999999999" MinimumValue="0" Type="Double"></asp:RangeValidator></td></tr><tr>
                        <td align="right" class="FormViewLabelCell" style="width: 23%; height: 26px">
                            <asp:Label ID="Label10" runat="server" AssociatedControlID="EstimatedTimeSpentTextBox">
                            <asp:Literal ID="Literal23" runat="server" Text="<%$ Resources:TimeLive.Resource, Estimated Time (Hours):%> " /></asp:Label></td><td colspan="3" style="height: 26px">
                            <asp:TextBox ID="EstimatedTimeSpentTextBox" runat="server" Text='<%# Bind("EstimatedTimeSpent") %>'  Width="56px" style="text-align:right;"></asp:TextBox>&nbsp; <asp:RangeValidator ID="RangeValidator5" runat="server" ControlToValidate="EstimatedTimeSpentTextBox"  CssClass="ErrorMessage" Display="Dynamic" ErrorMessage="(Invalid Duration Value)" MaximumValue="50000" MinimumValue="0" Type="Double" ></asp:RangeValidator></td></tr><%If Not System.Configuration.ConfigurationManager.AppSettings("FIXED_COST") Is Nothing Then%><tr>
                        <td align="right" class="FormViewLabelCell" style="width: 23%; height: 26px"><asp:Label ID="lblFixedCost" runat="server" AssociatedControlID="txtFixedCost">
                            <asp:Literal ID="Literal67" runat="server" Text="<%$ Resources:TimeLive.Resource, Fixed Cost:%> " /></asp:Label></td><td colspan="3" style="height: 26px">
                            <asp:TextBox ID="txtFixedCost" runat="server" Text='<%# Bind("FixedCost") %>'  Width="56px" style="text-align:right;"></asp:TextBox>&nbsp; <asp:RangeValidator ID="RVFixedCost" runat="server" ControlToValidate="txtFixedCost" CssClass="ErrorMessage" Display="Dynamic" ErrorMessage="(Invalid Duration Value)" MaximumValue="50000" MinimumValue="0" Type="Double" ></asp:RangeValidator></td></tr><%End If%><tr>
                        <td class="style7" align="right">
                            <asp:Label ID="Label6" runat="server" AssociatedControlID="DurationTextBox">
                            <asp:Literal ID="Literal10" runat="server" Text='<%# ResourceHelper.GetFromResource("Duration:") %>' /></asp:Label></td><td style="width: 60%; height: 26px;"><asp:TextBox ID="DurationTextBox" runat="server" MaxLength="10" Text='<%# Bind("Duration") %>' Width="55px" style="text-align:right;"></asp:TextBox><asp:Label ID="lblSystemDurationUnit" runat="server" Text="Hours"></asp:Label><asp:DropDownList ID="DropDownList3" runat="server" DataSourceID="dsSystemDurationUnit" DataTextField="SystemDurationUnit" DataValueField="SystemDurationUnit" SelectedValue='<%# Bind("DurationUnit") %>'  Visible="False" Width="30%"></asp:DropDownList>
                            <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="DurationTextBox" CssClass="ErrorMessage" ErrorMessage="(Inv Dur Val)" MaximumValue="50000" MinimumValue="0" Type="Double"  Width="30%"></asp:RangeValidator></td></tr><tr>
                        <td class="style7" align="right">
                            <a href="#" title="By checking this, this task will become parent task." class="tooltip"><img style="vertical-align: middle;padding-bottom: 2px;" title="" src="../Images/info.png" /></a><asp:Literal ID="Literal17" runat="server" Text='<%# ResourceHelper.GetFromResource("Is Parent:") %>' />
                        </td>
                        <td style="height: 26px; width: 60%;"><asp:CheckBox ID="CheckBox1" runat="server" Checked='<%# Bind("IsParentTask") %>'  />
                        </td>
                    </tr>
                    </table></Content></cc2:AccordionPane>
                    <cc2:AccordionPane ID="AccordionPane4" runat="server">
                        <Header><a href="" class="accordionLink">&nbsp;<asp:Literal ID="Literal20" runat="server" Text='<%# ResourceHelper.GetFromResource("Other Options") %>' /></a></Header><Content>
                        <table class="xview" style="width: 99.5%; border:0">
                    <tr>
                        <td align="right" class="FormViewLabelCell" style="width: 27.5%; height: 26px"><asp:Literal ID="Literal13" runat="server" Text='<%# ResourceHelper.GetFromResource("Priority:") %>' />
                        </td>
                        <td colspan="3" style="height: 26px">
                            <asp:DropDownList ID="DropDownList7" runat="server" DataSourceID="dsAccountPriorityObject" DataTextField="Priority" DataValueField="AccountPriorityId"  Width="122px"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="FormViewLabelCell" style="width: 27.5%; height: 26px"><asp:Literal ID="Literal12" runat="server" Text='<%# ResourceHelper.GetFromResource("Task Status:") %>' />
                        </td>
                        <td colspan="3" style="height: 26px"><asp:DropDownList ID="DropDownList6" runat="server" DataSourceID="dsProjectTaskStatusObject" DataTextField="Status" DataValueField="AccountStatusId" Width="122px"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="FormViewLabelCell" style="width: 27.5%; height: 26px"><asp:Label ID="Label7" runat="server" AssociatedControlID="CompletedPercentTextBox">
                            <asp:Literal ID="Literal64" runat="server" Text='<%# ResourceHelper.GetFromResource("Completed%:") %>' /></asp:Label></td><td colspan="3" style="height: 26px"><asp:TextBox ID="CompletedPercentTextBox" runat="server" Text='<%# Bind("CompletedPercent") %>'  Width="55px" style="text-align:right;"></asp:TextBox><asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="CompletedPercentTextBox" CssClass="ErrorMessage" ErrorMessage="(Range 0-100)%" MaximumValue="100" MinimumValue="0" Type="Double" ></asp:RangeValidator></td><td class="style7">&nbsp;</td><td style="width: 60%; height: 26px;">
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="FormViewLabelCell" style="width: 27.5%; height: 26px"><asp:Literal ID="Literal16" runat="server" Text='<%# ResourceHelper.GetFromResource("Completed:") %>' />
                        </td>
                        <td colspan="3" style="height: 26px"><asp:CheckBox ID="CompletedCheckBox" runat="server" Checked='<%# Bind("Completed") %>'  />
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="FormViewLabelCell" style="width: 27.5%; height: 26px">
                            <asp:Literal ID="Literal19" runat="server" Text='<%# ResourceHelper.GetFromResource("Disabled:") %>' />
                        </td>
                        <td class="style13">
                            <asp:CheckBox ID="chkIsDisabled" runat="server" Checked='<%# Bind("IsDisabled") %>' />
                        </td>
                    </tr>
                </table></Content></cc2:AccordionPane>
                <cc2:AccordionPane ID="AccordionPane2" runat="server" Visible="True">
                <Header><a href="" class="accordionLink">&nbsp;<asp:Literal ID="Literal65" runat="server" Text='<%# ResourceHelper.GetFromResource("Task Billing Rate") %>' /></a></Header><Content>
                <table class="xview" style="width: 99.8%; border:0">
                    <tr>
                        <td align="right" class="FormViewLabelCell" style="width: 27.5%; height: 26px">
                            <asp:Literal ID="Literal18" runat="server" Text='<%# ResourceHelper.GetFromResource("Billable:") %>' />
                        </td>
                        <td class="style13"><asp:CheckBox ID="chkIsBillable" runat="server"  />
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="FormViewLabelCell" style="width: 27.5%; height: 26px">
                            <asp:Literal ID="Literal25" runat="server" Text="<%$ Resources:TimeLive.Resource, Work Type:%> " />
                        </td>
                        <td colspan="3"><asp:DropDownList ID="ddlAccountWorkTypeId" runat="server" AutoPostBack="True" DataSourceID="dsAccountWorkTypeObject" DataTextField="AccountWorkType" DataValueField="AccountWorkTypeId" OnSelectedIndexChanged="ddlAccountWorkTypeId_SelectedIndexChanged" Width="100px"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="FormViewLabelCell" style="width: 27.5%; height: 26px">
                            <asp:Literal ID="Literal26" runat="server" Text="<%$ Resources:TimeLive.Resource, Employee Rate Currency:%> " />
                        </td>
                        <td class="style13">
                            <asp:DropDownList ID="ddlEmployeeRateCurrencyId" runat="server" DataSourceID="dsEmployeeRateCurrencyObject" DataTextField="CurrencyCode" DataValueField="AccountCurrencyId" Width="100px"></asp:DropDownList>
                        </td>
                        <td class="style7" align="right" ><asp:Label ID="Label11" runat="server" AssociatedControlID="EmployeeRateTextBox">
                            <asp:Literal ID="Literal27" runat="server" Text="<%$ Resources:TimeLive.Resource, Employee Rate:%> " /></asp:Label></td><td style="height: 26px; width: 60%;"><asp:TextBox ID="EmployeeRateTextBox" runat="server" ValidationGroup="Insert" Width="56px" style="text-align:right;"></asp:TextBox><asp:RangeValidator ID="RangeValidator7" runat="server" ControlToValidate="EmployeeRateTextBox" CssClass="ErrorMessage" Display="Dynamic" ErrorMessage="Numeric Required" Font-Bold="True" Font-Names="Verdana" Font-Size="X-Small" MaximumValue="999999999" MinimumValue="0" Type="Double" ></asp:RangeValidator></td></tr><tr>
                        <td align="right" class="FormViewLabelCell" style="width: 27.5%; height: 26px">
                            <asp:Literal ID="Literal28" runat="server" Text="<%$ Resources:TimeLive.Resource, Billing Rate Currency:%> " /></td><td class="style13"><asp:DropDownList ID="ddlBillingRateCurrencyId" runat="server" DataSourceID="dsBillingRateCurrencyObject" DataTextField="CurrencyCode" DataValueField="AccountCurrencyId" Width="100px"></asp:DropDownList>
                        </td>
                        <td class="style7" align="right"><asp:Label ID="Label14" runat="server" AssociatedControlID="BillingRateTextBox">
                            <asp:Literal ID="Literal29" runat="server" Text="<%$ Resources:TimeLive.Resource, Billing Rate:%> " /></asp:Label></td><td style="height: 26px; width: 60%;"><asp:TextBox ID="BillingRateTextBox" runat="server" ValidationGroup="Update" Width="56px" style="text-align:right;"></asp:TextBox><asp:RangeValidator ID="RangeValidator6" runat="server" ControlToValidate="BillingRateTextBox" CssClass="ErrorMessage" Display="Dynamic" ErrorMessage="Numeric Required" Font-Bold="True" Font-Names="Verdana" Font-Size="X-Small" MaximumValue="999999999" MinimumValue="0" Type="Double" ></asp:RangeValidator><asp:LinkButton ID="lnkBillingRateHistory" runat="server" OnClick="LinkButton1_Click" Visible='<%# IIF(IsDBNULL(Eval("AccountBillingRateId")) orelse Eval("AccountBillingRateId")=0,False,True) %>'>
                                    &nbsp;<asp:Literal ID="Literal30" runat="server" Text="<%$ Resources:TimeLive.Resource, Billing Rate History%> " /></asp:LinkButton></td></tr><tr>
                        <td align="right" class="FormViewLabelCell" style="width: 27.5%; height: 26px">
                            <asp:Literal ID="Literal31" runat="server" Text="<%$ Resources:TimeLive.Resource, Billing Rate Start Date:%> " />
                        </td>
                        <td class="style13"><ew:CalendarPopup ID="BillingRateStartDateTextBox" runat="server" SelectedValue='<%# Bind("DeadlineDate") %>' SkinId="DatePicker" Width="55px"></ew:CalendarPopup>
                        </td>
                        <td class="style7" align="right"><asp:Literal ID="Literal62" runat="server" Text="<%$ Resources:TimeLive.Resource, Billing Rate End Date:%> " />
                        </td>
                        <td style="height: 26px; width: 60%;">
                            <ew:CalendarPopup ID="BillingRateEndDateTextBox" runat="server" SelectedValue='<%# Bind("DeadlineDate") %>' SkinId="DatePicker" Width="55px"></ew:CalendarPopup>
                        </td>
                    </tr>
        </table></Content></cc2:AccordionPane>
           <cc2:AccordionPane ID="AccordionPane3" runat="server">
                <Header><a href="" class="accordionLink">&nbsp;<asp:Literal ID="Literal56" runat="server" Text='<%# ResourceHelper.GetFromResource("Task Attachment") %>' /></a></Header><Content>
                <table class="xview" style="width: 98%; border:0">
                    <tr>
                        <td align="right" class="FormViewLabelCell" style="width: 27.5%; height: 26px">
                            <asp:Literal ID="Literal68" runat="server" Text="<%$ Resources:TimeLive.Resource, Attachment Name:%> " />
                        </td>
                        <td colspan="3" style="width: 71%; height: 26px">
                            <asp:TextBox ID="AttachmentNameTextBox" runat="server" ValidationGroup="Attachment" Width="335px"></asp:TextBox></td></tr><tr>
                        <td align="right" class="FormViewLabelCell" style="width: 27.5%; height: 26px">
                            <asp:Literal ID="Literal69" runat="server" Text="<%$ Resources:TimeLive.Resource, File Path:%> " />
                        </td>
                        <td colspan="3" style="width: 71%; height: 26px">
                            <asp:FileUpload ID="AttachmentFileUpload" runat="server" Width="430px" />
                        </td>
                    </tr>
        </table></Content></cc2:AccordionPane>
        </Panes></cc2:Accordion>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" colspan="2" style="height: 26px"><asp:Table ID="CustomTableEdit" runat="server" Height="100%" Width="100%"></asp:Table>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="height: 25px; width: 23%;"></td>
                        <td style="height: 25px; padding-bottom: 5px;">
                            <asp:Button ID="btnUpdate" runat="server" CommandName="Update" Text="<%$ Resources:TimeLive.Resource, Update_text%> " Width="68px" />&nbsp;<asp:Button ID="btnCancel" runat="server" CommandName="Cancel" OnClick="btnCancel_Click" ValidationGroup="Cancel" Text="<%$ Resources:TimeLive.Resource, Cancel_text%> " Width="68px" />
                        </td>
                    </tr>
       </table>
       </EditItemTemplate>
        <InsertItemTemplate>
            <table class="xview" style="width: 98%">
                <tr>
                    <th class="caption" colspan="2" style="width: 98%; height: 21px">
                        <asp:Literal ID="Literal32" runat="server" Text='<%# ResourceHelper.GetFromResource("Add Task") %>' />
                    </th>
                </tr>
                <tr>
                    <th class="FormViewSubHeader" colspan="2" style="width: 98%; height: 21px">
                        <asp:Literal ID="Literal33" runat="server" Text='<%# ResourceHelper.GetFromResource("Basic") %>' />
                    </th>
                </tr>
<%If CType(Me.FormView1.FindControl("lblProjectTeamException"), Label).Visible = True Then%>
                <tr>
                    <td colspan="2" style="width: 98%; height: 26px">
                        <asp:Label ID="lblProjectTeamExceptionHeader" runat="server" Font-Bold="False" Font-Names="Verdana" Font-Size="10pt" ForeColor="Red">
                        <asp:Literal ID="Literal66" runat="server" Text="<%$ Resources:TimeLive.Resource, strmsg %>" /></asp:Label></td></tr><%End If%><%If Me.Request.QueryString("AccountProjectId") Is Nothing Then%><tr>
                    <td align="right" class="FormViewLabelCell" style="width: 30%; height: 26px">
                    <asp:Literal 
                        ID="Literal34" runat="server" Text='<%# ResourceHelper.GetFromResource("Project:") %>' />
                        </td>
                    <td style="width: 68%; height: 26px"><span><asp:DropDownList ID="ddlAccountProjectId" 
                            runat="server" DataSourceID="dsAccountProjectObjectInsert" 
                            DataTextField="ProjectName" DataValueField="AccountProjectId" Width="350px" 
                            AppendDataBoundItems="True" AutoPostBack="True" 
                            onselectedindexchanged="ddlAccountProjectId_SelectedIndexChanged1"></asp:DropDownList></span></td>
                </tr>
<%End If%>
                 <tr>
                    <td align="right" class="FormViewLabelCell" style="width: 30%; height: 26px">
                        <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="TaskCodeTextBoxInsert">
                        <asp:Literal ID="Literal6" runat="server" Text='<%# ResourceHelper.GetFromResource("Task Code:") %>' /></asp:Label></td><td colspan="3" style="width: 68%; height: 26px">
                        <asp:TextBox ID="TaskCodeTextBoxInsert" runat="server" MaxLength="15" Text='<%# Bind("TaskCode") %>' Width="110px"></asp:TextBox></td></tr><tr>
                    <td align="right" class="FormViewLabelCell" style="width: 30%; height: 26px"><span class="reqasterisk">*</span><asp:Label ID="Label2" runat="server" AssociatedControlID="TaskNameTextBox" >
                        <asp:Literal ID="Literal38" runat="server" Text='<%# ResourceHelper.GetFromResource("Task Name:") %>' /></asp:Label></td><td style="width: 68%; height: 26px">
                    <asp:TextBox ID="TaskNameTextBox" runat="server" MaxLength="100" Text='<%# Bind("TaskName") %>' Width="336px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TaskNameTextBox" CssClass="ErrorMessage" Display="Dynamic" ErrorMessage="*"  Width="8px"></asp:RequiredFieldValidator></td></tr><tr>
                    <td align="right" class="FormViewLabelCell" style="width: 30%; height: 26px">
                        <asp:Label ID="Label4" runat="server" AssociatedControlID="TaskDescriptionTextBoxInsert">
                        <asp:Literal ID="Literal8" runat="server" Text='<%# ResourceHelper.GetFromResource("Task Description:") %>' /></asp:Label></td><td style="width: 68%; height: 26px">
                        <asp:TextBox ID="TaskDescriptionTextBoxInsert" runat="server" Height="70px" Rows="6" Text='<%# Bind("TaskDescription") %>' 
                                    TextMode="MultiLine"  Width="336px"></asp:TextBox></td></tr><tr>
                    <td align="right" class="FormViewLabelCell" style="width: 30%; height: 26px">
                                <asp:Literal ID="Literal9" runat="server" Text='<%# ResourceHelper.GetFromResource("Task Type:") %>' />
                    </td>
                    <td style="width: 68%; height: 26px"><asp:DropDownList ID="ddlTaskTypeInsert" runat="server" 
                                    DataSourceID="dsAccountProjectTaskTypeObject" DataTextField="TaskType" 
                                    DataValueField="AccountTaskTypeId"  
                                    Width="122px"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="FormViewLabelCell" style="width: 30%; height: 26px">
                        <asp:Literal ID="Literal41" runat="server" Text='<%# ResourceHelper.GetFromResource("Start Date:") %>' />
                    </td>
                    <td style="width: 68%; height: 26px">
                        <ew:CalendarPopup ID="StartDate" runat="server"  SkinId="DatePicker" Width="70px"><buttonstyle borderstyle="Dotted" /></ew:CalendarPopup>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="FormViewLabelCell" style="width: 30%; height: 26px"><asp:Literal 
                            ID="Literal43" runat="server" 
                            Text='<%# ResourceHelper.GetFromResource("Due Date:") %>' />
                            </td>
                            <td 
                            style="width: 68%; height: 26px"><ew:CalendarPopup ID="DeadlineDate" 
                                runat="server" SelectedDate='<%# Bind("DeadlineDate") %>' SkinId="DatePicker" 
                                Width="70px"></ew:CalendarPopup>
                                </td>
                                </tr>
                            <tr>
                            <td 
                        align="right" style="width: 30%; height: 26px; padding-bottom: 41px;">
                        <a href="#" title="Use Ctrl + Left mouse click to assign resources to this task." class="tooltip"><img style="vertical-align: middle;padding-bottom: 2px;" title="" src="../Images/info.png" /></a><asp:Literal 
                        ID="Literal52" runat="server" 
                        Text='<%# ResourceHelper.GetFromResource("Assign To") %>' />: </td><td style="width: 68%; height: 26px"><asp:ListBox ID="ListBoxEmployees" 
                            runat="server" DataSourceID="dsAccountProjectTaskInsert" 
                            DataTextField="FullName" DataValueField="AccountEmployeeId" 
                            SelectionMode="Multiple" Width="350px"></asp:ListBox><br /><asp:CustomValidator 
                            ID="CustomValidator1" runat="server" ControlToValidate="ListBoxEmployees" 
                            CssClass="ErrorMessage" Display="Dynamic" EnableClientScript="False" 
                            ErrorMessage="Select Assigned To:" OnServerValidate="ValidateListAndCheck" 
                            ValidateEmptyText="True"  />
                            </td>
                            </tr>
                            <tr>
                            <td 
                        align="right" class="FormViewLabelCell" style="width: 30%; height: 26px">
                        <a href="#" title="By checking this, this task will assign to all employee in this project." class="tooltip"><img style="vertical-align: middle;padding-bottom: 2px;" title="" src="../Images/info.png" /></a><asp:Literal 
                        ID="Literal46" runat="server" 
                        Text='<%# ResourceHelper.GetFromResource("All Employee Task:") %>' />
                        </td>
                        <td 
                            style="width: 68%; height: 26px"><asp:CheckBox ID="CheckBox2" runat="server" 
                            Checked='<%# Bind("IsForAllEmployees") %>' />
                            </td>
                            </tr>
                            <tr>
                            <td 
                        align="right" class="FormViewLabelCell" style="width: 30%; height: 26px">
                        <a href="#" title="By checking this, this task will become all project's task in account." class="tooltip"><img style="vertical-align: middle;padding-bottom: 2px;" title="" src="../Images/info.png" /></a><asp:Literal 
                            ID="Literal47" runat="server" 
                            Text='<%# ResourceHelper.GetFromResource("All Project Task:") %>' />
                            </td>
                            <td 
                            style="width: 68%; height: 26px"><asp:CheckBox ID="CheckBox1" runat="server" 
                                Checked='<%# Bind("IsForAllProjectTask") %>' Width="108px" />
                                </td>
                                </tr>
                        <tr>
                        <td align="right" class="FormViewLabelCell" style="width: 30%; height: 26px">
                                    <asp:Literal ID="Literal18" runat="server" Text='<%# ResourceHelper.GetFromResource("Billable:") %>' />
                                    </td>
                                    <td style="width: 68%; height: 26px"><asp:CheckBox ID="chkIsBillable" runat="server"  />
                        </td>
                        </tr>
                       <tr>
                       <td align="left" colspan="2">
                            <cc2:Accordion ID="MyAccordion" runat="server" SelectedIndex="7"
                            HeaderCssClass="accordionHeader" HeaderSelectedCssClass="accordionHeaderSelected"
                            ContentCssClass="accordionContent" FadeTransitions="true" FramesPerSecond="40" 
                            TransitionDuration="250" AutoSize="None" RequireOpenedPane="False" 
                            SuppressHeaderPostbacks="true">
           <Panes>
            <cc2:AccordionPane ID="AccordionPane5" runat="server" Visible="True">
                <Header><a href="" class="accordionLink">&nbsp;<asp:Literal 
                        ID="Literal70" runat="server" 
                        Text="<%$ Resources:TimeLive.Resource, Advance Options%> " /></a></Header><Content>
                <table class="xview" style="width: 99.5%; border:0">
                       <tr>
                       <td 
                        align="right" class="FormViewLabelCell" style="width: 30%; height: 26px"><asp:Literal 
                        ID="Literal35" runat="server" 
                        Text='<%# ResourceHelper.GetFromResource("Parent Task:") %>' />
                        </td>
                        <td style="width: 68%; height: 26px"><asp:DropDownList 
                            ID="ddlParentAccountProjectTaskIdinsert" runat="server" AppendDataBoundItems="True" 
                            Width="350px"></asp:DropDownList>
                            </td>
                            </tr>
                       <tr><td 
                        align="right" class="FormViewLabelCell" style="width: 30%; height: 26px"><span class="reqasterisk">*</span><asp:Literal ID="Literal36" runat="server" 
                        Text='<%# ResourceHelper.GetFromResource("Milestone:") %>' />
                        </td>
                        <td style="width: 68%; height: 26px"><asp:DropDownList 
                            ID="ddlAccountProjectMilestoneIdinsert" runat="server" 
                            Width="350px" ClientIDMode="Static"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="ddlAccountProjectMilestoneIdValidation" runat="server" ControlToValidate="ddlAccountProjectMilestoneIdinsert" CssClass="ErrorMessage" Display="Dynamic" ErrorMessage="*" Width="8px" SetFocusOnError="True"></asp:RequiredFieldValidator></td></tr><tr>
                        <td 
                        align="right" class="FormViewLabelCell" style="width: 30%; height: 26px"><asp:Literal 
                        ID="Literal54" runat="server" 
                        Text="<%$ Resources:TimeLive.Resource, Estimated Cost:%> " />
                        </td>
                        <td 
                        colspan="3" style="width: 68%; height: 26px"><asp:DropDownList ID="ddlEstimatedCurrencyId1" 
                            runat="server" DataSourceID="dsEstimatedCurrencyObjectInsert" 
                            DataTextField="CurrencyCode" DataValueField="AccountCurrencyId" Width="75px"></asp:DropDownList>&nbsp;<asp:TextBox 
                            ID="EstimatedCostTextBox1" runat="server" Text='<%# Bind("EstimatedCost") %>' 
                            Width="56px" style="text-align:right;"></asp:TextBox><asp:RangeValidator ID="RangeValidator41" 
                            runat="server" ControlToValidate="EstimatedCostTextBox1" CssClass="ErrorMessage" 
                            Display="Dynamic" ErrorMessage="Numeric Required" Font-Bold="False" 
                            MaximumValue="999999999" MinimumValue="0" Type="Double"  ></asp:RangeValidator></td></tr><tr>
                            <td 
                        align="right" class="FormViewLabelCell" style="width: 30%; height: 26px"><asp:Label 
                        ID="Label9" runat="server" AssociatedControlID="EstimatedTimeSpentTextBox1">
                    <asp:Literal ID="Literal55" runat="server" 
                                Text="<%$ Resources:TimeLive.Resource, Estimated Time (Hours):%> " /></asp:Label></td><td 
                        colspan="3" style="width: 68%; height: 26px"><asp:TextBox ID="EstimatedTimeSpentTextBox1" 
                            runat="server" Text='<%# Bind("EstimatedTimeSpent") %>' Width="56px" style="text-align:right;"></asp:TextBox>&nbsp; <asp:RangeValidator 
                            ID="RangeValidator31" runat="server" 
                            ControlToValidate="EstimatedTimeSpentTextBox1" CssClass="ErrorMessage" 
                            Display="Dynamic" ErrorMessage="(Invalid Duration Value)" MaximumValue="50000" 
                            MinimumValue="0" Type="Double" ></asp:RangeValidator></td></tr><%If Not System.Configuration.ConfigurationManager.AppSettings("FIXED_COST") Is Nothing Then%><tr>
                            <td align="right" class="FormViewLabelCell" style="width: 30%; height: 26px">
                       <asp:Label ID="lblFixedCostInsert" runat="server" AssociatedControlID="txtFixedCostInsert">
                       <asp:Literal ID="Literal671" runat="server" Text="Fixed Cost" /></asp:Label></td><td colspan="3" style="width: 68%; height: 26px">
                       <asp:TextBox ID="txtFixedCostInsert" runat="server" Text='<%# Bind("FixedCost") %>' Width="56px" style="text-align:right;">
                       </asp:TextBox>&nbsp; <asp:RangeValidator ID="RVFixedCostInsert" runat="server" ControlToValidate="txtFixedCostInsert"  CssClass="ErrorMessage" Display="Dynamic" ErrorMessage="(Invalid Duration Value)" MaximumValue="50000" MinimumValue="0" Type="Double" ></asp:RangeValidator></td></tr><%End If%><tr>
                        <td align="right" 
                        class="FormViewLabelCell" style="width: 30%; height: 26px"><asp:Literal 
                        ID="Literal24" runat="server" 
                        Text="<%$ Resources:TimeLive.Resource, Duration:%> " />
                        </td>
                       <td 
                        style="width: 68%; height: 26px;"><asp:TextBox ID="DurationTextBoxinsert" runat="server" 
                            Text='<%# Bind("Duration") %>' MaxLength="10"  Width="56px" style="text-align:right;"></asp:TextBox>&nbsp;<asp:Label 
                            ID="lblSystemDurationUnitinsert" runat="server" Text="<%$ Resources:TimeLive.Resource, Hours%> "></asp:Label><asp:DropDownList 
                            ID="DropDownList3insert" runat="server" DataSourceID="dsSystemDurationUnit" 
                            DataTextField="SystemDurationUnit" DataValueField="SystemDurationUnit" 
                            SelectedValue='<%# Bind("DurationUnit") %>' Visible="False" Width="30%"></asp:DropDownList><asp:RangeValidator 
                            ID="RangeValidator2insert" runat="server" ControlToValidate="DurationTextBoxinsert" 
                            CssClass="ErrorMessage" ErrorMessage="(Inv. Val)" MaximumValue="50000" 
                            MinimumValue="0" Type="Double" Width="30%" ></asp:RangeValidator></td></tr><tr><td 
                        align="right" class="FormViewLabelCell" style="width: 30%; height: 26px"><a href="#" title="By checking this, this task will become parent task." class="tooltip"><img style="vertical-align: middle;padding-bottom: 2px;" title="" src="../Images/info.png" /></a><asp:Literal 
                            ID="Literal49" runat="server" 
                            Text='<%# ResourceHelper.GetFromResource("Is Parent:") %>' /></td>
                       <td style="width: 68%; height: 26px">
                       <asp:CheckBox ID="CheckBox4" runat="server" 
                                Checked='<%# Bind("IsParentTask") %>' /></td>
                               </tr>
                       </table></Content></cc2:AccordionPane>
          
        </Panes>
        </cc2:Accordion>
                            <tr><td colspan="2"><asp:Table 
                            ID="CustomTable" runat="server" Height="100%" Width="100%"></asp:Table></td></tr></td></tr>
                            </tr>
                            </tr>
                            <tr><td 
                            align="right" class="FormViewLabelCell" style="width: 30%; height: 26px"></td>
                            <td 
                            style="width: 65%; height: 26px; padding-bottom: 5px; padding-top: 5px;">
                            <asp:Button ID="Add" ClientIDMode="Static" runat="server" CommandName="Insert" 
                            Text="<%$ Resources:TimeLive.Resource, Add_text%> " 
                            Width="55px" OnClientClick="return validate();"/>&nbsp;<asp:Button 
                            ID="btnCancel" runat="server" CommandName="Cancel" OnClick="btnCancel_Click" ValidationGroup="Cancel"
                            Text="<%$ Resources:TimeLive.Resource, Cancel_text%> "  
                            Width="55px" /><asp:Label ID="lblProjectTeamException" runat="server" 
                            CssClass="ErrorMessage" Visible="False"></asp:Label></td></tr></td></tr></table></InsertItemTemplate></asp:FormView><asp:ObjectDataSource ID="dsAccountWorkTypeObject" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetAccountWorkTypesByAccountIdAndIsDisabled" TypeName="AccountWorkTypeBLL">
<SelectParameters>
                <asp:SessionParameter DefaultValue="99" Name="AccountId" SessionField="AccountId"
                    Type="Int32" />
                <asp:Parameter Name="AccountWorkTypeId" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
<asp:ObjectDataSource ID="dsAccountProjectTaskTypeObject" runat="server" OldValuesParameterFormatString="original_{0}"
    SelectMethod="GetAccountTaskTypesByAccountIdAndAccountTaskTypeId" TypeName="AccountTaskTypeBLL" DeleteMethod="DeleteAccountTaskType" InsertMethod="AddAccountTaskType" UpdateMethod="UpdateAccountTaskType">
    <DeleteParameters>
        <asp:Parameter Name="Original_AccountTaskTypeId" Type="Int32" />
    </DeleteParameters>
    <UpdateParameters>
        <asp:Parameter Name="AccountId" Type="Int32" />
        <asp:Parameter Name="TaskType" Type="String" />
        <asp:Parameter Name="Original_AccountTaskTypeId" Type="Int32" />
        <asp:Parameter Name="CreatedOn" Type="DateTime" />
        <asp:Parameter Name="CreatedByEmployeeId" Type="Int32" />
        <asp:Parameter Name="ModifiedOn" Type="DateTime" />
        <asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" />
        <asp:Parameter Name="IsDisabled" Type="Boolean" />
    </UpdateParameters>
    <SelectParameters>
        <asp:SessionParameter DefaultValue="64" Name="AccountId" SessionField="AccountId"
            Type="Int32" />
        <asp:Parameter Name="AccountTaskTypeId" Type="Int32" />
    </SelectParameters>
    <InsertParameters>
        <asp:Parameter Name="AccountId" Type="Int32" />
        <asp:Parameter Name="TaskType" Type="String" />
        <asp:Parameter Name="CreatedOn" Type="DateTime" />
        <asp:Parameter Name="CreatedByEmployeeId" Type="Int32" />
        <asp:Parameter Name="ModifiedOn" Type="DateTime" />
        <asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" />
    </InsertParameters>
</asp:ObjectDataSource>
<asp:ObjectDataSource ID="dsAccountProjectTaskTypeObjectInsert" runat="server" OldValuesParameterFormatString="original_{0}"
    SelectMethod="GetAccountTaskTypesByAccountIdAndAccountTaskTypeId" TypeName="AccountTaskTypeBLL" DeleteMethod="DeleteAccountTaskType" InsertMethod="AddAccountTaskType" UpdateMethod="UpdateAccountTaskType">
            <DeleteParameters>
                <asp:Parameter Name="Original_AccountTaskTypeId" Type="Int32" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="AccountId" Type="Int32" />
                <asp:Parameter Name="TaskType" Type="String" />
                <asp:Parameter Name="Original_AccountTaskTypeId" Type="Int32" />
                <asp:Parameter Name="CreatedOn" Type="DateTime" />
                <asp:Parameter Name="CreatedByEmployeeId" Type="Int32" />
                <asp:Parameter Name="ModifiedOn" Type="DateTime" />
                <asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" />
                <asp:Parameter Name="IsDisabled" Type="Boolean" />
            </UpdateParameters>
            <SelectParameters>
                <asp:SessionParameter DefaultValue="64" Name="AccountId" SessionField="AccountId"
            Type="Int32" />
                <asp:Parameter Name="AccountTaskTypeId" Type="Int32" DefaultValue="0" />
            </SelectParameters>
            <InsertParameters>
                <asp:Parameter Name="AccountId" Type="Int32" />
                <asp:Parameter Name="TaskType" Type="String" />
                <asp:Parameter Name="CreatedOn" Type="DateTime" />
                <asp:Parameter Name="CreatedByEmployeeId" Type="Int32" />
                <asp:Parameter Name="ModifiedOn" Type="DateTime" />
                <asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" />
            </InsertParameters>
</asp:ObjectDataSource>
<asp:ObjectDataSource ID="dsParentAccountProjectTaskObject" runat="server" OldValuesParameterFormatString="original_{0}"
    SelectMethod="GetParentAccountProjectTasksByAccountProjectId" TypeName="AccountProjectTaskBLL" DeleteMethod="DeleteAccountProjectType">
    <DeleteParameters>
        <asp:Parameter Name="Original_AccountProjectTaskId" Type="Int32" />
    </DeleteParameters>
    <SelectParameters>
        <asp:Parameter DefaultValue="1" Name="AccountProjectId" Type="Int32" />
        <asp:Parameter Name="ParentAccountProjectTaskId" Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>
<asp:ObjectDataSource ID="dsSystemDurationUnit" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetDurationUnit" TypeName="SystemDataBLL"></asp:ObjectDataSource>
<asp:ObjectDataSource ID="dsProjectTaskStatusObject" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetAccountsStatusForTaskByAccountStatusId" TypeName="AccountStatusBLL" DeleteMethod="DeleteAccountStatus" InsertMethod="AddAccountStatus" UpdateMethod="UpdateAccountStatus">
            <DeleteParameters>
                <asp:Parameter Name="Original_AccountStatusId" Type="Int32" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="AccountId" Type="Int32" />
                <asp:Parameter Name="Status" Type="String" />
                <asp:Parameter Name="StatusTypeId" Type="Int32" />
                <asp:Parameter Name="Original_AccountStatusId" Type="Int32" />
                <asp:Parameter Name="IsDisabled" Type="Boolean" />
            </UpdateParameters>
            <SelectParameters>
                <asp:SessionParameter DefaultValue="64" Name="AccountId" SessionField="AccountId"
                    Type="Int32" />
                <asp:Parameter Name="AccountStatusId" Type="Int32" />
            </SelectParameters>
            <InsertParameters>
                <asp:Parameter Name="AccountId" Type="Int32" />
                <asp:Parameter Name="Status" Type="String" />
                <asp:Parameter Name="StatusTypeId" Type="Int32" />
            </InsertParameters>
        </asp:ObjectDataSource>
<asp:ObjectDataSource ID="dsProjectTaskStatusObjectInsert" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetAccountsStatusForTaskByAccountStatusId" TypeName="AccountStatusBLL" DeleteMethod="DeleteAccountStatus" InsertMethod="AddAccountStatus" UpdateMethod="UpdateAccountStatus">
            <DeleteParameters>
                <asp:Parameter Name="Original_AccountStatusId" Type="Int32" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="AccountId" Type="Int32" />
                <asp:Parameter Name="Status" Type="String" />
                <asp:Parameter Name="StatusTypeId" Type="Int32" />
                <asp:Parameter Name="Original_AccountStatusId" Type="Int32" />
                <asp:Parameter Name="IsDisabled" Type="Boolean" />
            </UpdateParameters>
            <SelectParameters>
                <asp:SessionParameter DefaultValue="64" Name="AccountId" SessionField="AccountId"
                    Type="Int32" />
                <asp:Parameter Name="AccountStatusId" Type="Int32" DefaultValue="0" />
            </SelectParameters>
            <InsertParameters>
                <asp:Parameter Name="AccountId" Type="Int32" />
                <asp:Parameter Name="Status" Type="String" />
                <asp:Parameter Name="StatusTypeId" Type="Int32" />
            </InsertParameters>
        </asp:ObjectDataSource>
<asp:ObjectDataSource 
    ID="dsAccountProjectMilestone" runat="server" 
    DeleteMethod="DeleteAccountProjectMilestone" OldValuesParameterFormatString="original_{0}"
    SelectMethod="GetAccountProjectMilestonesByAccountProjectIdForMilestoneCompleted" 
    TypeName="AccountProjectMilestoneBLL"><DeleteParameters>
                <asp:Parameter Name="Original_AccountProjectMilestoneId" Type="Int32" />
            <asp:Parameter 
                    Name="original_Comments" Type="String" /><asp:Parameter 
                    Name="original_Completed" Type="Boolean" /></DeleteParameters>
            <SelectParameters>
                <asp:Parameter Name="AccountProjectId" Type="Int32" 
                    DefaultValue="" /><asp:Parameter 
                    Name="AccountProjectMilestoneId" Type="Int32" DefaultValue="0" /></SelectParameters>
            </asp:ObjectDataSource>
<asp:ObjectDataSource ID="dsAccountPriorityObject" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetAccountPrioritiesByAccountIdAndAccountPriorityId" TypeName="AccountPriorityBLL">
            <SelectParameters>
                <asp:SessionParameter DefaultValue="64" Name="AccountId" SessionField="AccountId"
                    Type="Int32" />
                <asp:Parameter Name="AccountPriorityId" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
<asp:ObjectDataSource ID="dsAccountPriorityObjectInsert" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetAccountPrioritiesByAccountIdAndAccountPriorityId" TypeName="AccountPriorityBLL" DeleteMethod="DeleteAccountPriority" InsertMethod="AddAccountPriority" UpdateMethod="UpdateAccountPriority">
<DeleteParameters>
                <asp:Parameter Name="Original_AccountPriorityId" Type="Int32" />
            </DeleteParameters>
<UpdateParameters>
                <asp:Parameter Name="AccountId" Type="Int32" />
                <asp:Parameter Name="Priority" Type="String" />
                <asp:Parameter Name="PriorityOrder" Type="Byte" />
                <asp:Parameter Name="Original_AccountPriorityId" Type="Int32" />
                <asp:Parameter Name="IsDisabled" Type="Boolean" />
            </UpdateParameters>
<SelectParameters>
                <asp:SessionParameter DefaultValue="64" Name="AccountId" SessionField="AccountId"
                    Type="Int32" />
                <asp:Parameter Name="AccountPriorityId" Type="Int32" DefaultValue="0" />
            </SelectParameters>
<InsertParameters>
                <asp:Parameter Name="AccountId" Type="Int32" />
                <asp:Parameter Name="Priority" Type="String" />
                <asp:Parameter Name="PriorityOrder" Type="Byte" />
            </InsertParameters>
        </asp:ObjectDataSource>
<asp:ObjectDataSource ID="dsAccountProjectTask" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetAccountProjectEmployeesByAccountProjectIdAsView" TypeName="AccountProjectEmployeeBLL">
            <SelectParameters>
                <asp:Parameter DefaultValue="1" Name="AccountProjectId" Type="Int32" />
                <asp:Parameter Name="AccountProjectTaskId" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
<asp:ObjectDataSource ID="dsAccountProjectTaskInsert" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetAccountProjectEmployeesByAccountProjectIdAsView" TypeName="AccountProjectEmployeeBLL">
<SelectParameters>
                <asp:Parameter DefaultValue="1" Name="AccountProjectId" Type="Int32" />
                <asp:Parameter Name="AccountProjectTaskId" Type="Int32" DefaultValue="0" />
            </SelectParameters>
        </asp:ObjectDataSource>
<asp:ObjectDataSource 
    ID="dsAccountProjectTaskFormObject" runat="server"
    InsertMethod="AddAccountProjectTask" OldValuesParameterFormatString="original_{0}"
    SelectMethod="GetAccountProjectTypesByAccountProjectTaskId" TypeName="AccountProjectTaskBLL"
    UpdateMethod="UpdateAccountProjectTask" 
    DeleteMethod="DeleteAccountProjectType"><UpdateParameters>
        <asp:QueryStringParameter DefaultValue="3" Name="AccountProjectId" QueryStringField="AccountProjectId"
            Type="Int32" />
        <asp:Parameter Name="ParentAccountProjectTaskId" Type="Int32" />
        <asp:Parameter Name="TaskName" Type="String" />
        <asp:Parameter Name="TaskDescription" Type="String" />
        <asp:Parameter Name="AccountTaskTypeId" Type="Int32" />
        <asp:Parameter Name="Duration" Type="Double" />
        <asp:Parameter Name="DurationUnit" Type="String" />
        <asp:Parameter Name="CompletedPercent" Type="Double" />
        <asp:Parameter Name="Completed" Type="Boolean" />
        <asp:Parameter Name="DeadlineDate" Type="DateTime" />
        <asp:Parameter Name="TaskStatusId" Type="Int32" />
        <asp:Parameter Name="AccountPriorityId" Type="Int32" />
        <asp:Parameter Name="IsForAllEmployees" Type="Boolean" />
        <asp:Parameter Name="IsParentTask" Type="Boolean" />
        <asp:Parameter Name="AccountProjectMilestoneId" Type="Int32" />
        <asp:Parameter Name="CreatedOn" Type="DateTime" />
        <asp:Parameter Name="CreatedByEmployeeId" Type="Int32" />
        <asp:Parameter Name="ModifiedOn" Type="DateTime" />
        <asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" />
        <asp:Parameter Name="EstimatedCost" Type="Double" />
        <asp:Parameter Name="EstimatedTimeSpent" Type="Double" />
        <asp:Parameter Name="EstimatedTimeSpentUnit" Type="String" />
        <asp:Parameter Name="IsBillable" Type="Boolean" />
        <asp:Parameter Name="Original_AccountProjectTaskId" Type="Int32" />
        <asp:Parameter Name="IsDisabled" Type="Boolean" />
        <asp:Parameter Name="TaskCode" Type="String" />
        <asp:Parameter Name="IsForAllProjectTask" Type="Boolean" />
        <asp:Parameter Name="EstimatedCurrencyId" Type="Int32" />
        <asp:Parameter Name="StartDate" Type="DateTime" />
        <asp:Parameter 
            Name="FixedCost" Type="Double" /><asp:Parameter Name="original_Predecessors" Type="String" /><asp:Parameter 
            Name="CustomField1" Type="String" /><asp:Parameter Name="CustomField2" 
            Type="String" /><asp:Parameter Name="CustomField3" Type="String" /><asp:Parameter 
            Name="CustomField4" Type="String" /><asp:Parameter Name="CustomField5" 
            Type="String" /><asp:Parameter Name="CustomField6" Type="String" /><asp:Parameter 
            Name="CustomField7" Type="String" /><asp:Parameter Name="CustomField8" 
            Type="String" /><asp:Parameter Name="CustomField9" Type="String" /><asp:Parameter 
            Name="CustomField10" Type="String" /><asp:Parameter Name="CustomField11" 
            Type="String" /><asp:Parameter Name="CustomField12" Type="String" /><asp:Parameter 
            Name="CustomField13" Type="String" /><asp:Parameter Name="CustomField14" 
            Type="String" /><asp:Parameter Name="CustomField15" Type="String" /></UpdateParameters>
    <SelectParameters>
        <asp:Parameter DefaultValue="34" Name="AccountProjectTaskId" Type="Int32" />
    </SelectParameters>
    <DeleteParameters><asp:Parameter Name="Original_AccountProjectTaskId" 
            Type="Int32" /></DeleteParameters><InsertParameters>
        <asp:QueryStringParameter DefaultValue="3" Name="AccountProjectId" QueryStringField="AccountProjectId"
            Type="Int32" />
        <asp:Parameter Name="ParentAccountProjectTaskId" Type="Int32" />
        <asp:Parameter Name="TaskName" Type="String" />
        <asp:Parameter Name="TaskDescription" Type="String" />
        <asp:Parameter Name="AccountTaskTypeId" Type="Int32" />
        <asp:Parameter Name="Duration" Type="Double" />
        <asp:Parameter Name="DurationUnit" Type="String" />
        <asp:Parameter Name="CompletedPercent" Type="Double" />
        <asp:Parameter Name="Completed" Type="Boolean" />
        <asp:Parameter Name="DeadlineDate" Type="DateTime" />
        <asp:Parameter Name="TaskStatusId" Type="Int32" />
        <asp:Parameter Name="AccountPriorityId" Type="Int32" />
        <asp:Parameter Name="AccountProjectMilestoneId" Type="Int32" />
        <asp:Parameter Name="IsForAllEmployees" Type="Boolean" />
        <asp:Parameter Name="IsParentTask" Type="Boolean" />
        <asp:Parameter Name="CreatedOn" Type="DateTime" />
        <asp:Parameter Name="CreatedByEmployeeId" Type="Int32" />
        <asp:Parameter Name="ModifiedOn" Type="DateTime" />
        <asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" />
        <asp:Parameter Name="EstimatedCost" Type="Double" />
        <asp:Parameter Name="EstimatedTimeSpent" Type="Double" />
        <asp:Parameter Name="EstimatedTimeSpentUnit" Type="String" />
        <asp:Parameter Name="IsBillable" Type="Boolean" />
        <asp:Parameter Name="TaskCode" Type="String" />
        <asp:Parameter Name="AccountBillingRateId" Type="Int32" />
        <asp:Parameter Name="IsForAllProjectTask" Type="Boolean" />
        <asp:Parameter Name="EstimatedCurrencyId" Type="Int32" />
        <asp:Parameter Name="StartDate" Type="DateTime" />
        <asp:Parameter 
            Name="FixedCost" Type="Double" /><asp:Parameter Name="IsWebServiceCall" Type="Boolean" />
        <asp:Parameter Name="original_Predecessors" Type="String" />
        <asp:Parameter Name="CustomField1" Type="String" /><asp:Parameter Name="CustomField2" 
            Type="String" /><asp:Parameter Name="CustomField3" Type="String" /><asp:Parameter 
            Name="CustomField4" Type="String" /><asp:Parameter Name="CustomField5" 
            Type="String" /><asp:Parameter Name="CustomField6" Type="String" /><asp:Parameter 
            Name="CustomField7" Type="String" /><asp:Parameter Name="CustomField8" 
            Type="String" /><asp:Parameter Name="CustomField9" Type="String" /><asp:Parameter 
            Name="CustomField10" Type="String" /><asp:Parameter Name="CustomField11" 
            Type="String" /><asp:Parameter Name="CustomField12" Type="String" /><asp:Parameter 
            Name="CustomField13" Type="String" /><asp:Parameter Name="CustomField14" 
            Type="String" /><asp:Parameter Name="CustomField15" Type="String" /></InsertParameters>
    </asp:ObjectDataSource>
<asp:ObjectDataSource ID="dsAccountProjectObject" runat="server" OldValuesParameterFormatString="original_{0}"
    SelectMethod="GetAssignedAccountProjectsByAccountEmployeeIdAndAccountProjectId" TypeName="AccountProjectBLL" DeleteMethod="DeleteAccountProject" InsertMethod="AddAccountProject" UpdateMethod="UpdateProjectDescription">
    <SelectParameters>
        <asp:Parameter Name="AccountProjectId" Type="Int32" />
        <asp:SessionParameter DefaultValue="99" Name="AccountEmployeeId" SessionField="AccountEmployeeId"
            Type="Int32" />
        <asp:QueryStringParameter Name="IsTemplate" QueryStringField="IsTemplate" Type="Boolean" />
    </SelectParameters>
    <DeleteParameters>
        <asp:Parameter Name="Original_AccountProjectId" Type="Int32" />
    </DeleteParameters>
    <UpdateParameters>
        <asp:Parameter Name="ProjectDescription" Type="String" />
        <asp:Parameter Name="Original_AccountProjectId" Type="Int32" />
    </UpdateParameters>
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
        <asp:Parameter Name="IsTemplate" Type="Boolean" />
        <asp:Parameter Name="IsProject" Type="Boolean" />
        <asp:Parameter Name="AccountProjectTemplateId" Type="Int32" />
        <asp:Parameter Name="CreatedOn" Type="DateTime" />
        <asp:Parameter Name="CreatedByEmployeeId" Type="Int32" />
        <asp:Parameter Name="ModifiedOn" Type="DateTime" />
        <asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" />
    </InsertParameters>
</asp:ObjectDataSource>
<asp:ObjectDataSource ID="dsAccountProjectObjectInsert" 
    runat="server" OldValuesParameterFormatString="original_{0}"
    
    SelectMethod="GetAssignedAccountProjectsByAccountEmployeeIdAndAccountProjectId" 
    TypeName="AccountProjectBLL"><SelectParameters>
        <asp:SessionParameter 
            DefaultValue="0" Name="AccountId" SessionField="AccountId" Type="Int32" /><asp:Parameter DefaultValue="0" Name="AccountProjectId" Type="Int32" />
        <asp:SessionParameter DefaultValue="99" Name="AccountEmployeeId" SessionField="AccountEmployeeId"
            Type="Int32" />
        <asp:QueryStringParameter DefaultValue="" Name="IsTemplate" QueryStringField="IsTemplate"
            Type="Boolean" />
    </SelectParameters>
</asp:ObjectDataSource>
<asp:ObjectDataSource ID="dsAccountCurrencyObjectInsert" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetvueAccountCurrencyByAccountIdAndDisabled" TypeName="AccountCurrencyBLL">
            <SelectParameters>
                <asp:SessionParameter Name="AccountId" SessionField="AccountId" Type="Int32" />
                <asp:Parameter DefaultValue="0" Name="AccountCurrencyId" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
<asp:ObjectDataSource ID="dsBillingRateCurrencyObject" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetvueAccountCurrencyByAccountIdAndDisabled" TypeName="AccountCurrencyBLL">
<SelectParameters>
                <asp:SessionParameter Name="AccountId" SessionField="AccountId" Type="Int32" />
                <asp:Parameter Name="AccountCurrencyId" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
<asp:ObjectDataSource ID="dsEmployeeRateCurrencyObject" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetvueAccountCurrencyByAccountIdAndDisabled" TypeName="AccountCurrencyBLL">
            <SelectParameters>
                <asp:SessionParameter Name="AccountId" SessionField="AccountId" Type="Int32" />
                <asp:Parameter Name="AccountCurrencyId" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
<asp:ObjectDataSource ID="dsEstimatedCurrencyObject" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetvueAccountCurrencyByAccountIdAndDisabled" TypeName="AccountCurrencyBLL">
            <SelectParameters>
                <asp:SessionParameter Name="AccountId" SessionField="AccountId" Type="Int32" />
                <asp:Parameter Name="AccountCurrencyId" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
<asp:ObjectDataSource ID="dsEstimatedCurrencyObjectInsert" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetvueAccountCurrencyByAccountIdAndDisabled" TypeName="AccountCurrencyBLL">
            <SelectParameters>
                <asp:SessionParameter Name="AccountId" SessionField="AccountId" Type="Int32" />
                <asp:Parameter DefaultValue="0" Name="AccountCurrencyId" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
