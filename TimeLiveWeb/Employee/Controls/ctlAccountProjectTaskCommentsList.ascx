<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlAccountProjectTaskCommentsList.ascx.vb" Inherits="Employee_Controls_ctlAccountProjectTaskCommentsList" %>
<%@ Register Assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2"
    Namespace="eWorld.UI" TagPrefix="ew" %>
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc2" %>
<script language="vb" runat="server">
    Sub ValidateListAndCheckUpdate(ByVal sender As Object, ByVal args As ServerValidateEventArgs)
        Dim n As Integer = 0
        Dim l As ListBox = Me.FormView1.FindControl("ListBoxEmployeesUpdate")
        If CType(Me.FormView1.FindControl("CheckBox1"), CheckBox).Checked <> True Then
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
        End If
    End Sub
</script>
 <script type="text/javascript">
     function OpenWindow() {
         window.open('ProjectAdmin/AccountProjectTaskAttachmentsPopUp.aspx', '_blank', 'height=450,width=500,scrollbars=0,location=1,toolbar=0');
     }
    </script>
<%@ Register Src="../../ProjectAdmin/Controls/ctlAccountProjectTaskAttachmentList.ascx"
    TagName="ctlAccountProjectTaskAttachmentList" TagPrefix="uc1" %>
<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<asp:UpdatePanel ID="UpdatePanel4" runat="server">
    <ContentTemplate>
        &nbsp;<asp:Button ID="btnAuditTrail" runat="server" OnClick="btnAuditTrail_Click" Text="<%$ Resources:TimeLive.Resource, Audit Trial%> " />
    </ContentTemplate>
</asp:UpdatePanel>
<asp:UpdatePanel id="UpdatePanel2" runat="server"><contenttemplate>
<asp:FormView id="FormView1" runat="server" DataKeyNames="AccountProjectTaskId" SkinID="formviewSkinEmployee" DataSourceID="dsAccountProjectTaskFormObject" Width="95%" DefaultMode="Edit">
    <EditItemTemplate>
        <table id="Table2" width="100%" class="xFormView">
            <tr>
                <th class="caption" colspan="4" style="height: 21px" width="30%">
                    <asp:Literal ID="Literal1" runat="server" Text='<%# ResourceHelper.GetFromResource("Project Task Information") %>' /></th>
            </tr>
            <tr>
                <th class="FormViewSubHeader" colspan="4" style="height: 21px" width="30%">
                    <asp:Literal ID="Literal2" runat="server" Text='<%# ResourceHelper.GetFromResource("Project Task") %>' /></th>
            </tr>
            <tr>
                        <td align="right" colspan="4" style="height: 21px; padding-top: 5px; padding-right: 5px;">
                            <asp:Button ID="btnTaskTeam" runat="server" 
                                OnClick="btnTaskTeam_Click" 
                                Text="Task Team" CommandName="Task Team" />
                        </td>
            </tr>
            <tr>
                <td align="right" class="FormViewLabelCell" style="height: 26px; width: 20%;" width="30%">
                    <SPAN class=reqasterisk>*</SPAN>
                    <asp:Literal ID="Literal3" runat="server" Text='<%# ResourceHelper.GetFromResource("Task Id:") %>' /></td>
                <td  colspan="3" style="height: 26px">
                    <asp:TextBox ID="TextBox2" runat="server" Enabled="False" Text='<%# Eval("AccountProjectTaskId") %>'
                        Width="72px"></asp:TextBox></td>
            </tr>
            <tr>
                <td align="right" class="FormViewLabelCell" style="height: 26px; width: 20%;" width="30%">
                    <asp:Literal ID="Literal4" runat="server" Text='<%# ResourceHelper.GetFromResource("Parent Task:") %>' /></td>
                <td colspan="3" style="height: 26px">
                    <asp:DropDownList ID="ddlParentAccountProjectTaskId" runat="server" AppendDataBoundItems="True"
                        DataSourceID="dsParentAccountProjectTaskObject" DataTextField="TaskName" DataValueField="AccountProjectTaskId"
                        ValidationGroup="ProjectTaskForm" Width="350px">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td align="right" class="FormViewLabelCell" style="height: 26px; width: 20%;" width="30%">
                    <asp:Literal ID="Literal5" runat="server" Text='<%# ResourceHelper.GetFromResource("Project:") %>' /></td>
                <td colspan="3" style="height: 26px">
                    <asp:DropDownList ID="ddlAccountProjectId" runat="server" AutoPostBack="True" DataSourceID="dsAccountProjectObject"
                        DataTextField="ProjectName" DataValueField="AccountProjectId" Enabled="False"
                        ValidationGroup="ProjectTaskForm" Width="350px">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td align="right" class="FormViewLabelCell" style="height: 26px; width: 20%;" 
                    width="30%">
                    <span class="reqasterisk">*</span>&nbsp;&nbsp;<asp:Literal ID="Literal9" runat="server" 
                        Text='<%# ResourceHelper.GetFromResource("Milestone:") %>' />
                </td>
                <td colspan="3" style="height: 26px">
                    <asp:DropDownList ID="ddlAccountProjectMilestoneId" runat="server" 
                        Width="350px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="right" class="FormViewLabelCell" style="height: 26px; width: 20%;" width="30%">
                    <asp:Literal ID="Literal6" runat="server" Text='<%# ResourceHelper.GetFromResource("Task Code:") %>' /></td>
                <td colspan="3" style="height: 26px">
                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("TaskCode") %>' 
                        MaxLength="15" Width="110px"></asp:TextBox></td>
            </tr>
            <tr><td style="height: 26px; width: 20%;" class="FormViewLabelCell" width="30%" align="right">
                                                    <SPAN 
                  class=reqasterisk>*</SPAN> <asp:Literal ID="Literal7" runat="server" Text='<%# ResourceHelper.GetFromResource("Task Name:") %>' /></td>
                <td colspan="3" style="height: 26px">
                    <asp:TextBox ID="TaskNameTextBox" runat="server" Text='<%# Bind("TaskName") %>' 
                        Width="336px"></asp:TextBox><asp:RequiredFieldValidator
                        ID="RequiredFieldValidator2" runat="server" ControlToValidate="TaskNameTextBox"
                        Display="Dynamic" ErrorMessage="*" Width="8px"></asp:RequiredFieldValidator></td>
            </tr>
            <tr><td style="height: 26px; width: 20%;" class="FormViewLabelCell" width="30%" align="right">
                                                    <SPAN 
                  class=reqasterisk>*</SPAN> <asp:Literal ID="Literal8" runat="server" Text='<%# ResourceHelper.GetFromResource("Task Description:") %>' /></td>
                <td colspan="3" style="height: 26px; padding-top: 6px; padding-bottom: 6px;">
                    <asp:TextBox ID="TaskDescriptionTextBox" runat="server" 
                        Text='<%# Bind("TaskDescription") %>' Width="336px" Rows="10" 
                        TextMode="MultiLine" Height="70px"></asp:TextBox><asp:RequiredFieldValidator
                        ID="RequiredFieldValidator3" runat="server" ControlToValidate="TaskDescriptionTextBox"
                        Display="Dynamic" ErrorMessage="*" Width="8px"></asp:RequiredFieldValidator></td>
            </tr>
            <tr><td class="FormViewLabelCell" width="30%" style="height: 26px; width: 20%;" align="right">
                                                    <SPAN 
                  class=reqasterisk>*</SPAN> <asp:Literal ID="Literal10" runat="server" Text='<%# ResourceHelper.GetFromResource("Task Type:") %>' /></td>
                <td style="height: 26px; width: 25%;">
                    <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="dsAccountProjectTaskTypeObject"
                        DataTextField="TaskType" DataValueField="AccountTaskTypeId" Width="122px">
                    </asp:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                        ControlToValidate="DropDownList1" Display="Dynamic" ErrorMessage="*" Width="8px"></asp:RequiredFieldValidator></td>
                <td class="FormViewLabelCell" style="height: 26px; width: 30%;" width="30%" align="right">
                    <asp:Literal ID="Literal11" runat="server" Text='<%# ResourceHelper.GetFromResource("Task Status:") %>' /></td>
                <td style="width: 25%; height: 26px">
                    <asp:DropDownList ID="DropDownList6" runat="server" DataSourceID="dsProjectTaskStatusObject" DataTextField="Status" Width="122px" DataValueField="AccountStatusId">
                    </asp:DropDownList></td>
            </tr>
            <tr><td style="height: 26px; width: 20%;" class="FormViewLabelCell" width="30%" align="right">
                <asp:Literal ID="Literal12" runat="server" Text='<%# ResourceHelper.GetFromResource("Duration:") %>' /></td>
                <td style="height: 26px; width: 30%;">
                    <asp:TextBox ID="DurationTextBox" runat="server" Text='<%# Bind("Duration") %>' 
                        Width="55px" style="text-align:right;"></asp:TextBox>&nbsp;<asp:Label 
                        ID="lblSystemDurationUnit" runat="server" Text="Hours"></asp:Label>
&nbsp;<asp:DropDownList ID="DropDownList3" runat="server" DataSourceID="dsSystemDurationUnit"
                        DataTextField="SystemDurationUnit" DataValueField="SystemDurationUnit" 
                        SelectedValue='<%# Bind("DurationUnit") %>' Visible="False">
                    </asp:DropDownList>
                    <asp:RangeValidator ID="RangeValidator5" 
                    runat="server" ControlToValidate="DurationTextBox" CssClass="ErrorMessage" 
                    ErrorMessage="(Inv Dur Val)" MaximumValue="50000" MinimumValue="0" 
                    Type="Double" ValidationGroup="ProjectTaskForm" Width="30%"></asp:RangeValidator></td>
                <td class="FormViewLabelCell" style="height: 26px; width: 20%;" width="30%" 
                    align="right">
                    <asp:Literal ID="Literal13" runat="server" Text='<%# ResourceHelper.GetFromResource("Priority:") %>' /></td>
                <td style="width: 25%; height: 33px">
                    <asp:DropDownList ID="ddlAccountPriority" runat="server" DataSourceID="dsAccountPriorityObject" DataTextField="Priority" Width="122px" DataValueField="AccountPriorityId">
                    </asp:DropDownList></td>
            </tr>
            <tr><td style="height: 26px; width: 20%;" class="FormViewLabelCell" width="30%" align="right">
                <asp:Literal ID="Literal14" runat="server" Text='<%# ResourceHelper.GetFromResource("Completed%:") %>' /></td>
                <td style="height: 26px; width: 25%;">
                    <asp:TextBox ID="CompletedPercentTextBox" runat="server" 
                        Text='<%# Bind("CompletedPercent") %>' Width="55px" 
                        style="text-align:right;"></asp:TextBox>
                    <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="CompletedPercentTextBox"
                        CssClass="ErrorMessage" ErrorMessage="(Range 0-100)%" MaximumValue="100" MinimumValue="0"
                        Type="Integer" Display="Dynamic"></asp:RangeValidator></td>
                <td class="FormViewLabelCell" style="height: 26px; width: 30%;" width="30%" align="right">
                    <asp:Literal ID="Literal15" runat="server" Text='<%# ResourceHelper.GetFromResource("Due Date:") %>' /></td>
                <td style="width: 25%; height: 26px">
                    <ew:CalendarPopup ID="CalenderPop1" runat="server" SkinId="DatePicker" SelectedValue='<%# Bind("DeadlineDate") %>' Width="55px">
                    </ew:CalendarPopup>
                </td>
            </tr>
            <tr>
                <td align="right" class="FormViewLabelCell" style="height: 26px; width: 20%;" width="30%">
                    <asp:Literal ID="Literal16" runat="server" Text='<%# ResourceHelper.GetFromResource("All Employee Task:") %>' /></td>
                <td style="width: 25%; height: 26px">
                    <asp:CheckBox ID="CheckBox3" runat="server" Checked='<%# Bind("IsForAllEmployees") %>'  /></td>
                <td class="FormViewLabelCell" style="height: 26px; width: 30%;" width="30%" align="right">
                    <asp:Literal ID="Literal43" runat="server" Text='<%# ResourceHelper.GetFromResource("All Project Task:") %>' /></td>
                <td style="width: 25%; height: 26px">
                    <asp:CheckBox ID="CheckBox5" runat="server" Checked='<%# iif(isdbnull(eval("IsForAllProjectTask")),"False",eval("IsForAllProjectTask")) %>'
                        ValidationGroup="ProjectTaskForm" /></td>
            </tr>
            <tr>
                <td align="right" class="FormViewLabelCell" style="height: 26px; width: 20%;" width="30%">
                    <asp:Literal ID="Literal17" runat="server" Text='<%# ResourceHelper.GetFromResource("Completed:") %>' /></td>
                <td style="width: 25%; height: 26px">
                    <asp:CheckBox ID="CompletedCheckBox" runat="server" Checked='<%# Bind("Completed") %>'  /></td>
                <td class="FormViewLabelCell" style="height: 26px; width: 30%;" width="30%" align="right">
                    <asp:Literal ID="Literal18" runat="server" Text='<%# ResourceHelper.GetFromResource("Parent:") %>' /></td>
                <td style="width: 25%; height: 26px">
                    <asp:CheckBox ID="CheckBox1" runat="server" Checked='<%# Bind("IsParentTask") %>'
                        ValidationGroup="ProjectTaskForm" /></td>
            </tr>
            <tr>
                <td align="right" class="FormViewLabelCell" style="height: 26px; width: 20%;" width="30%">
                    <asp:Literal ID="Literal19" runat="server" Text='<%# ResourceHelper.GetFromResource("IsReOpen:") %>' /></td>
                <td style="width: 25%; height: 26px">
                    <asp:CheckBox ID="chkIsReOpen" runat="server" Checked='<%# iif(IsDBNull(Eval("IsReOpen")),false,Eval("IsReOpen")) %>' /></td>
                <td class="FormViewLabelCell" style="height: 26px; width: 30%;" width="30%" align="right">
                    <asp:Literal ID="Literal20" runat="server" Text='<%# ResourceHelper.GetFromResource("Billable:") %>' /></td>
                <td style="width: 25%; height: 26px">
                <asp:CheckBox ID="chkIsBillable" runat="server"
                        ValidationGroup="ProjectTaskForm" /></td>
            </tr>
            <tr>
                <th class="FormViewSubHeader" colspan="4" style="height: 21px">
                    <asp:Literal ID="Literal21" runat="server" Text='<%# ResourceHelper.GetFromResource("Assign To") %>' /></th>
            </tr>
            <tr>
                <td align="right" class="FormViewLabelCell" style="height: 26px; width: 20%;" width="30%">
                    <asp:Literal ID="Literal22" runat="server" Text='<%# ResourceHelper.GetFromResource("Assign To:") %>' /></td>
                <td colspan="3" style="height: 26px">
                    <asp:ListBox ID="ListBoxEmployeesUpdate" runat="server" DataSourceID="dsAccountProjectTask"
                        DataTextField="FullName" DataValueField="AccountEmployeeId" SelectionMode="Multiple"
                        Width="350px" 
                        OnSelectedIndexChanged="ListBoxEmployeesUpdate_SelectedIndexChanged" 
                        Height="75px"></asp:ListBox><br />
                    <asp:CustomValidator ID="CustomValidator2" runat="server" ControlToValidate="TaskDescriptionTextBox"
                        CssClass="ErrorMessage" Display="Dynamic" EnableClientScript="False" ErrorMessage="Select Assigned To:"
                        OnServerValidate="ValidateListAndCheckUpdate" ValidateEmptyText="True"></asp:CustomValidator></td>
            </tr>
            <tr><td 
                            align="left" colspan="4">
           <cc2:Accordion ID="MyAccordion" runat="server" SelectedIndex="4"
            HeaderCssClass="accordionHeader" HeaderSelectedCssClass="accordionHeaderSelected"
            ContentCssClass="accordionContent" FadeTransitions="true" FramesPerSecond="40" 
            TransitionDuration="250" AutoSize="None" RequireOpenedPane="False" 
            SuppressHeaderPostbacks="true">
           <Panes>
           <cc2:AccordionPane ID="AccordionPane3" runat="server">
                <Header><a href="" class="accordionLink">&nbsp;<asp:Literal ID="Literal63" runat="server" 
                                Text='<%# ResourceHelper.GetFromResource("Estimates") %>' /></a></Header>
                <Content>
<asp:UpdatePanel ID="UpdatePanel3" runat="server">
    <ContentTemplate>
        <table id="Table1" class="xview" style="width: 100%; border:0">
            <tr>
                <td class="FormViewLabelCell" style="height: 26px; width: 16%;" width="27%" >
                   <asp:Label  ID="Label10" runat="server" AssociatedControlID="EstimatedTimeSpentTextBox">
                        <asp:Literal ID="Literal23" runat="server" Text="<%$ Resources:TimeLive.Resource, Estimated Cost: %> " /></asp:Label></td><td colspan="3" style="height: 26px">
                    <asp:TextBox ID="EstimatedCostTextBox" runat="server" Text='<%# Bind("EstimatedCost") %>' style="text-align:right;" Width="55px"></asp:TextBox><asp:RangeValidator ID="RangeValidator4" runat="server" ControlToValidate="EstimatedCostTextBox"
                        CssClass="ErrorMessage" Display="Dynamic" ErrorMessage="Numeric Required"
                        Font-Bold="False" MaximumValue="50000" MinimumValue="0" Type="Double"></asp:RangeValidator></td></tr><tr>
                <td align="right" class="FormViewLabelCell" style="height: 26px; width: 16%;" width="27%">
                    <asp:Label  ID="Label2" runat="server" AssociatedControlID="EstimatedTimeSpentTextBox">
                        <asp:Literal ID="Literal24" runat="server" Text="<%$ Resources:TimeLive.Resource, Estimated Hours:%> " /></asp:Label></td><td colspan="3" style="height: 26px; width: 65%;">
                    <asp:TextBox ID="EstimatedTimeSpentTextBox" runat="server" Text='<%# Bind("EstimatedTimeSpent") %>'
                        Width="55px" style="text-align:right;"></asp:TextBox>&nbsp; <asp:RangeValidator ID="RangeValidator3" runat="server" ControlToValidate="EstimatedTimeSpentTextBox"
                        CssClass="ErrorMessage" ErrorMessage="(Invalid Duration Value)" MaximumValue="50000"
                        MinimumValue="0" Type="Double"></asp:RangeValidator></td></tr></table></ContentTemplate></asp:UpdatePanel></Content></cc2:AccordionPane></Panes></cc2:Accordion><tr><td align="right" 
                                style="height: 25px; width: 16%;"></td>
                                <td colspan="3" style="height: 26px; padding-bottom: 5px; padding-Top: 5px; padding-right: 5px;" width="30%" >
                                <asp:Button ID="Button1" runat="server" 
                        Text="<%$ Resources:TimeLive.Resource, Update_text%> " CommandName="Update"  
                        Width="55px" onclick="Button1_Click" />&nbsp;<asp:Button ID="Button2" runat="server" Text="<%$ Resources:TimeLive.Resource, Cancel_text%> " CommandName="Cancel" ValidationGroup="Cancel"
                        Width="55px" OnClick="Button2_Click"  /></td></tr>
            </td></tr>
        </table>
    </EditItemTemplate>
    <InsertItemTemplate>
        <table style="width: 100%" class="xFormView">
            <tr>
                <th class="caption" colspan="2" style="height: 21px" width="25%">
                    <asp:Literal ID="Literal25" runat="server" Text='<%# ResourceHelper.GetFromResource("Project Task Information") %>' /></th>
            </tr>
            <tr>
                <th class="FormViewSubHeader" colspan="2" style="height: 21px" width="25%">
                    <asp:Literal ID="Literal26" runat="server" Text='<%# ResourceHelper.GetFromResource("Project Task") %>' /></th>
            </tr>
            <tr>
                <td style="height: 26px; width: 30%;" class="FormViewLabelCell" width="25%" align="right">
                    <asp:Literal ID="Literal27" runat="server" Text='<%# ResourceHelper.GetFromResource("Parent Task:") %>' /></td>
                <td style="height: 26px; width: 70%;">
                    <asp:DropDownList ID="DropDownList2" runat="server" DataSource='<%# Eval("ParentAccountProjectTaskId") %>'
                        DataSourceID="dsParentAccountProjectTaskObject" DataTextField="TaskName" DataValueField="AccountProjectTaskId"
                        SelectedValue='<%# Bind("ParentAccountProjectTaskId") %>' AppendDataBoundItems="True">
                        <asp:ListItem Selectrd="True" Value="0" Label ID="Label1" runat="server" Text="<%$ Resources:TimeLive.Resource, Root Level%> "></asp:ListItem><%--<asp:ListItem Selected="True" Value="0">&lt;RootLevel&gt;</asp:ListItem>--%></asp:DropDownList></td></tr><tr>
                <td align="right" class="FormViewLabelCell" style="width: 30%; height: 26px" width="25%">
                    <asp:Literal ID="Literal28" runat="server" Text='<%# ResourceHelper.GetFromResource("Task Code:") %>' /></td>
                <td style="width: 70%; height: 26px">
                    <asp:TextBox ID="TextBox4" runat="server" 
                        Text='<%# Bind("TaskCode") %>' MaxLength="15" Width="110px"></asp:TextBox></td></tr><tr>
                <td style="height: 26px; width: 30%;" class="FormViewLabelCell" width="25%" align="right">
                                                        <SPAN 
                  class=reqasterisk>*</SPAN><asp:Literal ID="Literal29" runat="server" Text='<%# ResourceHelper.GetFromResource("Task Name:") %>' /></td>
                <td style="height: 26px; width: 70%;">
                    <asp:TextBox ID="TaskNameTextBox" runat="server" Text='<%# Bind("TaskName") %>' Width="320px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TaskNameTextBox"
                        Display="Dynamic" ErrorMessage="*" Width="8px"></asp:RequiredFieldValidator></td></tr><tr>
                <td style="height: 26px; width: 30%;" class="FormViewLabelCell" width="25%" align="right">
                                                        <SPAN 
                  class=reqasterisk>*</SPAN><asp:Literal ID="Literal30" runat="server" Text='<%# ResourceHelper.GetFromResource("Task Description") %>' /></td>
                <td style="height: 26px; width: 70%; padding-top: 6px; padding-bottom: 6px;">
                    <asp:TextBox ID="TaskDescriptionTextBox" runat="server" 
                        Text='<%# Bind("TaskDescription") %>' Width="320px" Rows="10" 
                        TextMode="MultiLine" Height="70px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TaskDescriptionTextBox"
                        Display="Dynamic" ErrorMessage="*" Width="8px"></asp:RequiredFieldValidator></td></tr><tr>
                <td align="right" class="FormViewLabelCell" style="width: 30%; height: 26px" width="25%">
                     <asp:Literal ID="Literal16" runat="server" Text='<%# ResourceHelper.GetFromResource("Milestone:") %>' /></td>
                <td style="width: 70%; height: 26px">
                    <asp:DropDownList ID="ddlAccountProjectMilestoneId" runat="server" DataSourceID="dsAccountProjectMilestone"
                        DataTextField="AccountProjectMilestoneId" DataValueField="MilestoneDescription"
                        SelectedValue='<%# Bind("AccountProjectMilestoneId") %>' Width="224px">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td class="FormViewLabelCell" width="25%" style="height: 26px; width: 30%;" align="right">
                                                        <SPAN 
                  class=reqasterisk>*</SPAN><asp:Literal ID="Literal31" runat="server" Text='<%# ResourceHelper.GetFromResource("Task Type:") %>' /></td>
                <td style="height: 26px; width: 70%;">
                    <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="dsAccountProjectTaskTypeObject"
                        DataTextField="TaskType" DataValueField="AccountTaskTypeId" SelectedValue='<%# Bind("AccountTaskTypeId") %>' Width="184px">
                    </asp:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="DropDownList1"
                        Display="Dynamic" ErrorMessage="*" Width="8px"></asp:RequiredFieldValidator></td></tr><tr>
                <td style="height: 26px; width: 30%;" class="FormViewLabelCell" width="25%" align="right">
                    <asp:Literal ID="Literal32" runat="server" Text='<%# ResourceHelper.GetFromResource("Duration:") %>' /></td>
                <td style="height: 26px; width: 70%;">
                    <asp:TextBox ID="DurationTextBox" runat="server" Text='<%# Bind("Duration") %>' Width="72px"></asp:TextBox>&nbsp;<asp:Label 
                        ID="lblSystemDurationUnit" runat="server" Text="Hours"></asp:Label>&nbsp;&nbsp;<asp:DropDownList ID="DropDownList3" runat="server" DataSourceID="dsSystemDurationUnit"
                        DataTextField="SystemDurationUnit" DataValueField="SystemDurationUnit" 
                        SelectedValue='<%# Bind("DurationUnit") %>' Visible="False">
                    </asp:DropDownList>
                    <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="DurationTextBox"
                        CssClass="ErrorMessage" ErrorMessage="(Invalid Duration Value)" MaximumValue="50000"
                        MinimumValue="0" Type="Integer"></asp:RangeValidator></td></tr><tr>
                <td style="height: 26px; width: 30%;" class="FormViewLabelCell" width="25%" align="right">
                    <asp:Literal ID="Literal33" runat="server" Text='<%# ResourceHelper.GetFromResource("Completed%:") %>' /></td>
                <td style="height: 26px; width: 70%;">
                    <asp:TextBox ID="CompletedPercentTextBox" runat="server" Text='<%# Bind("CompletedPercent") %>'></asp:TextBox><asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="CompletedPercentTextBox"
                        CssClass="ErrorMessage" ErrorMessage="(Range 0-100)%" MaximumValue="100" MinimumValue="0"
                        Type="Integer"></asp:RangeValidator></td></tr><tr>
                <td style="height: 26px; width: 30%;" class="FormViewLabelCell" width="25%" align="right">
                    <asp:Literal ID="Literal34" runat="server" Text='<%# ResourceHelper.GetFromResource("Due Date:") %>' /></td>
                <td style="height: 26px; width: 70%;">
                    <ew:CalendarPopup ID="CalendarPopup1" runat="server" SkinId="DatePicker" SelectedDate='<%# Bind("DeadlineDate") %>'
                        SelectedValue="09/30/2006 12:10:28" VisibleDate="09/30/2006 12:10:28" Width="55px">
                    </ew:CalendarPopup>
                </td>
            </tr>
            <tr>
                <td align="right" class="FormViewLabelCell" style="width: 30%; height: 26px" width="25%">
                    <asp:Literal ID="Literal35" runat="server" Text='<%# ResourceHelper.GetFromResource("Task Status:") %>' /></td>
                <td style="width: 70%; height: 26px">
                    <asp:DropDownList ID="DropDownList4" runat="server" DataSourceID="dsProjectTaskStatusObject" DataTextField="Status" DataValueField="AccountStatusId" SelectedValue='<%# Bind("TaskStatusId") %>'>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td align="right" class="FormViewLabelCell" style="width: 30%; height: 26px" width="25%">
                    <asp:Literal ID="Literal36" runat="server" Text='<%# ResourceHelper.GetFromResource("Priority:") %>' /></td>
                <td style="width: 70%; height: 26px">
                    <asp:DropDownList ID="DropDownList5" runat="server" DataSourceID="dsAccountPriorityObject" DataTextField="Priority" DataValueField="AccountPriorityId" SelectedValue='<%# Bind("AccountPriorityId") %>'>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td align="right" class="FormViewLabelCell" style="width: 30%; height: 26px" width="25%">
                    <asp:Literal ID="Literal37" runat="server" Text='<%# ResourceHelper.GetFromResource("All Employee Task:") %>' /></td>
                <td style="width: 70%; height: 26px">
                    <asp:CheckBox ID="CheckBox2" runat="server" Checked='<%# Bind("IsForAllEmployees") %>'  /></td>
            </tr>
            <tr>
                <td class="FormViewLabelCell" style="height: 26px; width: 30%;" width="25%" align="right">
                    <asp:Literal ID="Literal38" runat="server" Text='<%# ResourceHelper.GetFromResource("Completed:") %>' /></td>
                <td style="height: 26px; width: 70%;">
                    <asp:CheckBox ID="CompletedCheckBox" runat="server" Checked='<%# Bind("Completed") %>'  /></td>
            </tr>
            <tr>
                <td style="height: 26px; width: 30%;" class="FormViewLabelCell" width="25%" align="right">
                    <asp:Literal ID="Literal39" runat="server" Text='<%# ResourceHelper.GetFromResource("Parent Task:") %>' /></td>
                <td style="height: 26px; width: 70%;">
                    <asp:CheckBox ID="CheckBox1" runat="server" Checked='<%# Bind("IsParentTask") %>'  /></td>
            </tr>
            <tr>
                <td style="height: 26px; width: 30%;" width="25%" align="right">
                </td>
                <td style="height: 26px; width: 70%; padding-bottom: 5px;">
                    <asp:Button ID="Add" runat="server" CommandName="Insert" Text="<%$ Resources:TimeLive.Resource, Add_text%> " Width="55px"  /></td>
            </tr>
        </table>
    </InsertItemTemplate>
    <ItemTemplate>
        ProjectTaskId: <asp:Label ID="ProjectTaskIdLabel" runat="server" Text='<%# Eval("ProjectTaskId") %>'>
        </asp:Label><br  />AccountProjectId: <asp:Label ID="AccountProjectIdLabel" runat="server" Text='<%# Bind("AccountProjectId") %>'>
        </asp:Label><br  />ParentProjectTaskId: <asp:Label ID="ParentProjectTaskIdLabel" runat="server" Text='<%# Bind("ParentProjectTaskId") %>'>
        </asp:Label><br  />TaskName: <asp:Label ID="TaskNameLabel" runat="server" Text='<%# Bind("TaskName") %>'></asp:Label><br  />TaskDescription: <asp:Label ID="TaskDescriptionLabel" runat="server" Text='<%# Bind("TaskDescription") %>'>
        </asp:Label><br  />AccountTaskTypeId: <asp:Label ID="AccountTaskTypeIdLabel" runat="server" Text='<%# Bind("AccountTaskTypeId") %>'>
        </asp:Label><br  />Duration: <asp:Label ID="DurationLabel" runat="server" Text='<%# Bind("Duration") %>'></asp:Label><br  />CompletedPercent: <asp:Label ID="CompletedPercentLabel" runat="server" Text='<%# Bind("CompletedPercent") %>'>
        </asp:Label><br  />Completed: <asp:CheckBox ID="CompletedCheckBox" runat="server" Checked='<%# Bind("Completed") %>'
            Enabled="false"  /><br  />
        EstimatedTime: <asp:Label ID="EstimatedTimeLabel" runat="server" Text='<%# Bind("EstimatedTime") %>'>
        </asp:Label><br  /><asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" CommandName="Edit"
            Text="Edit">
        </asp:LinkButton><asp:LinkButton ID="DeleteButton" runat="server" CausesValidation="False" CommandName="Delete"
            Text="Delete">
        </asp:LinkButton><asp:LinkButton ID="NewButton" runat="server" CausesValidation="False" CommandName="New"
            Text="New">
        </asp:LinkButton></ItemTemplate></asp:FormView><asp:ObjectDataSource id="dsAccountProjectTaskTypeObject" runat="server" TypeName="AccountTaskTypeBLL" SelectMethod="GetAccountTaskTypesByAccountIdAndAccountTaskTypeId" OldValuesParameterFormatString="original_{0}" DeleteMethod="DeleteAccountTaskType" InsertMethod="AddAccountTaskType">
    <SelectParameters>
        <asp:SessionParameter DefaultValue="64" Name="AccountId" SessionField="AccountId"
            Type="Int32"  />
        <asp:Parameter Name="AccountTaskTypeId" Type="Int32" />
    </SelectParameters>
    <DeleteParameters>
        <asp:Parameter Name="Original_AccountTaskTypeId" Type="Int32"  />
    </DeleteParameters>
    <InsertParameters>
        <asp:Parameter Name="AccountId" Type="Int32"  />
        <asp:Parameter Name="TaskType" Type="String"  />
        <asp:Parameter Name="CreatedOn" Type="DateTime" />
        <asp:Parameter Name="CreatedByEmployeeId" Type="Int32" />
        <asp:Parameter Name="ModifiedOn" Type="DateTime" />
        <asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" />
    </InsertParameters>
</asp:ObjectDataSource> <asp:ObjectDataSource id="dsParentAccountProjectTaskObject" runat="server" TypeName="AccountProjectTaskBLL" SelectMethod="GetParentAccountProjectTasksByAccountProjectId" OldValuesParameterFormatString="original_{0}" DeleteMethod="DeleteAccountProjectType">
    <SelectParameters>
        <asp:QueryStringParameter DefaultValue="1" Name="AccountProjectId" QueryStringField="AccountProjectId"
            Type="Int32"  />
        <asp:Parameter Name="ParentAccountProjectTaskId" Type="Int32" />
    </SelectParameters>
    <DeleteParameters>
        <asp:Parameter Name="Original_AccountProjectTaskId" Type="Int32"  />
    </DeleteParameters>
</asp:ObjectDataSource> <asp:ObjectDataSource id="dsSystemDurationUnit" runat="server" TypeName="SystemDataBLL" SelectMethod="GetDurationUnit" OldValuesParameterFormatString="original_{0}"></asp:ObjectDataSource> <asp:ObjectDataSource id="dsProjectTaskStatusObject" runat="server" TypeName="AccountStatusBLL" SelectMethod="GetAccountsStatusForTaskByAccountStatusId" OldValuesParameterFormatString="original_{0}" DeleteMethod="DeleteAccountStatus" InsertMethod="AddAccountStatus">
            <SelectParameters>
                <asp:SessionParameter DefaultValue="64" Name="AccountId" SessionField="AccountId"
                    Type="Int32" />
                <asp:Parameter Name="AccountStatusId" Type="Int32" />
            </SelectParameters>
    <DeleteParameters>
        <asp:Parameter Name="Original_AccountStatusId" Type="Int32" />
    </DeleteParameters>
    <InsertParameters>
        <asp:Parameter Name="AccountId" Type="Int32" />
        <asp:Parameter Name="Status" Type="String" />
        <asp:Parameter Name="StatusTypeId" Type="Int32" />
    </InsertParameters>
        </asp:ObjectDataSource> <asp:ObjectDataSource id="dsAccountPriorityObject" runat="server" TypeName="AccountPriorityBLL" SelectMethod="GetAccountPrioritiesByAccountIdAndAccountPriorityId" OldValuesParameterFormatString="original_{0}" DeleteMethod="DeleteAccountPriority">
            <SelectParameters>
                <asp:SessionParameter DefaultValue="64" Name="AccountId" SessionField="AccountId"
                    Type="Int32"  />
                <asp:Parameter Name="AccountPriorityId" Type="Int32" />
            </SelectParameters>
            <DeleteParameters>
                <asp:Parameter Name="Original_AccountPriorityId" Type="Int32" />
            </DeleteParameters>
        </asp:ObjectDataSource> 
    <asp:ObjectDataSource ID="dsAccountProjectTask" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetAccountProjectEmployeesByAccountProjectIdAsView" TypeName="AccountProjectEmployeeBLL">
        <SelectParameters>
            <asp:Parameter DefaultValue="1" Name="AccountProjectId" Type="Int32" />
            <asp:Parameter Name="AccountProjectTaskId" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="dsAccountProjectTaskFormObject" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetAccountProjectTypesByAccountProjectTaskId" TypeName="AccountProjectTaskBLL"
        UpdateMethod="UpdateAccountProjectTaskUpdateInformation" 
        OnSelecting="dsAccountProjectTaskFormObject_Selecting">
        <UpdateParameters>
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
            <asp:Parameter Name="IsReOpen" Type="Boolean" />
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
            <asp:Parameter Name="TaskCode" Type="String" />
            <asp:Parameter Name="IsForAllProjectTask" Type="Boolean" />
        </UpdateParameters>
        <SelectParameters>
            <asp:QueryStringParameter DefaultValue="34" Name="AccountProjectTaskId" QueryStringField="AccountProjectTaskId"
                Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="dsAccountProjectMilestone" runat="server" DeleteMethod="DeleteAccountProjectMilestone"
        InsertMethod="AddAccountProjectMilestone" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetAccountProjectMilestonesByAccountProjectTaskId" TypeName="AccountProjectMilestoneBLL"
        UpdateMethod="UpdateAccountProjectMilestone">
        <DeleteParameters>
            <asp:Parameter Name="Original_AccountProjectMilestoneId" Type="Int32" />
        </DeleteParameters>
        <UpdateParameters>
            <asp:Parameter Name="AccountId" Type="Int32" />
            <asp:Parameter Name="AccountProjectId" Type="Int32" />
            <asp:Parameter Name="MilestoneDescription" Type="String" />
            <asp:Parameter Name="MilestoneDate" Type="DateTime" />
            <asp:Parameter Name="Original_AccountProjectMilestoneId" Type="Int32" />
            <asp:Parameter Name="CreatedOn" Type="DateTime" />
            <asp:Parameter Name="CreatedByEmployeeId" Type="Int32" />
            <asp:Parameter Name="ModifiedOn" Type="DateTime" />
            <asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" />
        </UpdateParameters>
        <SelectParameters>
            <asp:QueryStringParameter DefaultValue="1" Name="AccountProjectTaskId" QueryStringField="AccountProjectTaskId"
                Type="Int32" />
            <asp:Parameter Name="AccountProjectMilestoneId" Type="Int32" DefaultValue="0" />
        </SelectParameters>
        <InsertParameters>
            <asp:Parameter Name="AccountId" Type="Int32" />
            <asp:Parameter Name="AccountProjectId" Type="Int32" />
            <asp:Parameter Name="MilestoneDescription" Type="String" />
            <asp:Parameter Name="MilestoneDate" Type="DateTime" />
            <asp:Parameter Name="CreatedOn" Type="DateTime" />
            <asp:Parameter Name="CreatedByEmployeeId" Type="Int32" />
            <asp:Parameter Name="ModifiedOn" Type="DateTime" />
            <asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" />
        </InsertParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="dsAccountProjectObject" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetAccountProjectsByAccountId" TypeName="AccountProjectBLL">
        <SelectParameters>
            <asp:SessionParameter DefaultValue="64" Name="AccountId" SessionField="AccountId"
                Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
</contenttemplate>
</asp:UpdatePanel>
           <cc2:Accordion ID="MyAccordion1" runat="server" SelectedIndex="4"
            HeaderCssClass="accordionHeader" HeaderSelectedCssClass="accordionHeaderSelected"
            ContentCssClass="accordionContent" FadeTransitions="true" FramesPerSecond="40" 
            TransitionDuration="250" AutoSize="None" RequireOpenedPane="False" 
            SuppressHeaderPostbacks="true" width="95%">
           <Panes>
           <cc2:AccordionPane ID="AccordionPane1" runat="server">
                <Header><a href="" class="accordionLink">&nbsp;Comments</a></Header><Content>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>

<%--  <table class="xFormView"  id="Table2" width="100%">
 <tr>
 <td>--%>
 <x:GridView ID="GridView1" runat="server" DataSourceID="dsAccountProjectTaskCommens" AutoGenerateColumns="False" DataKeyNames="AccountProjectTaskCommentsId" 
        SkinID="xgridviewSkinEmployee" Width="99%" Caption= '<%# ResourceHelper.GetFromResource("Comments List") %>' CaptionAlign="Left" OnRowDataBound="GridView1_RowDataBound">
            <Columns>
                <asp:BoundField DataField="AccountProjectTaskCommentsId" HeaderText="AccountProjectTaskCommentsId"
                    InsertVisible="False" ReadOnly="True"
                    Visible="False" />
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Comments%> ">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("CommentsTitle") %>'></asp:TextBox></EditItemTemplate><ItemTemplate>
                        <table class="xFormView" height="100%" width="100%" >
                            <tr>
                                <td  style="width: 10%; font-weight: bold; font-size:11px;">
                                    <asp:Literal ID="Literal38" runat="server" Text="<%$ Resources:TimeLive.Resource, Title:%> " /></td>
                                <td style="width: 90%; font-size:11px;" colspan="3">
                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("CommentsTitle") %>' Width="100%"></asp:Label></td></tr><tr>
                                <td style="width: 10%; height: 21px; font-weight: bold; font-size:11px;">
                                <asp:Literal ID="Literal3" runat="server" Text="<%$ Resources:TimeLive.Resource, Comments By:%> " /></td>
                                <td style="width: 90%; height: 21px; font-size:11px;">
                                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("FirstName") &  " " & Eval("LastName") %>' Width="100%"></asp:Label></td></tr><tr><td style="width: 10%; height: 21px; font-weight: bold; font-size:11px;">
                                <asp:Literal ID="Literal5" runat="server" Text="<%$ Resources:TimeLive.Resource, Time:%> " /></td>
                                <td style="width: 90%; height: 21px; font-size:11px;">
                                    <asp:Label ID="Label4" runat="server" Text='<%# Eval("CreatedOn") %>' Width="100%"></asp:Label></td></tr><tr>
                                <td style="width: 10%; font-weight: bold; font-size:11px;">
                                    <asp:Literal ID="Literal23" runat="server" Text="<%$ Resources:TimeLive.Resource, Comments:%> " /></td>
                                <td style="width: 90%; height: 21px; font-size:11px;">
                                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("Comments") %>' Width="100%" ></asp:Label></td></tr></table></ItemTemplate></asp:TemplateField></Columns></x:GridView><%-- </td>
</tr>
</table>   --%><asp:ObjectDataSource ID="dsAccountProjectTaskCommens" runat="server" DeleteMethod="DeleteAccountProjectTaskComments" OldValuesParameterFormatString="original_{0}" SelectMethod="GetAccountProjectTaskCommentssByAccountProjectTaskId" TypeName="AccountProjectTaskCommentsBLL" InsertMethod="AddAccountProjectTaskComments" UpdateMethod="UpdateAccountProjectTaskComments">
            <DeleteParameters>
                <asp:Parameter Name="original_AccountProjectTaskCommentsId" Type="Int32" />
            </DeleteParameters>
            <SelectParameters>
                <asp:QueryStringParameter DefaultValue="34" Name="AccountProjectTaskId" QueryStringField="AccountProjectTaskId"
                    Type="Int64" />
                <asp:Parameter Name="NotFixTable" Type="Boolean" />
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter Name="Comments" Type="String" />
                <asp:Parameter Name="CommentsTitle" Type="String" />
                <asp:Parameter Name="original_AccountProjectTaskCommentsId" Type="Int32" />
                <asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" />
            </UpdateParameters>
            <InsertParameters>
                <asp:Parameter Name="AccountProjectTaskId" Type="Int64" />
                <asp:Parameter Name="CommentsTitle" Type="String" />
                <asp:Parameter Name="Comments" Type="String" />
                <asp:Parameter Name="CreatedOn" Type="DateTime" />
                <asp:Parameter Name="CreatedByEmployeeId" Type="Int32" />
                <asp:Parameter Name="ModifiedOn" Type="DateTime" />
                <asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" />
            </InsertParameters>
        </asp:ObjectDataSource>
        <br />
        &nbsp;<asp:Button ID="btnAddComments" runat="server" Text="Add Comments" />
        <asp:ObjectDataSource ID="dsAccountProjectTaskCommentsForm" runat="server" DeleteMethod="DeleteAccountProjectTaskComments" InsertMethod="AddAccountProjectTaskComments" OldValuesParameterFormatString="original_{0}" SelectMethod="GetAccountProjectTaskCommentsByAccountProjectTaskCommentsId" TypeName="AccountProjectTaskCommentsBLL" UpdateMethod="UpdateAccountProjectTaskComments" OnSelecting="dsAccountProjectTaskCommentsForm_Selecting">
            <DeleteParameters>
                <asp:Parameter Name="original_AccountProjectTaskCommentsId" Type="Int32" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="Comments" Type="String" />
                <asp:Parameter Name="CommentsTitle" Type="String" />
                <asp:Parameter Name="original_AccountProjectTaskCommentsId" Type="Int32" />
                <asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" />
            </UpdateParameters>
            <SelectParameters>
                <asp:QueryStringParameter DefaultValue="34" Name="AccountProjectTaskCommentsId" QueryStringField="AccountProjectTaskId"
                    Type="Int32" />
            </SelectParameters>
            <InsertParameters>
                <asp:QueryStringParameter DefaultValue="34" Name="AccountProjectTaskId" QueryStringField="AccountProjectTaskId"
                    Type="Int64" />
                <asp:Parameter Name="CommentsTitle" Type="String" />
                <asp:Parameter Name="Comments" Type="String" />
                <asp:Parameter Name="CreatedOn" Type="DateTime" />
                <asp:Parameter Name="CreatedByEmployeeId" Type="Int32" />
                <asp:Parameter Name="ModifiedOn" Type="DateTime" />
                <asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" />
            </InsertParameters>
        </asp:ObjectDataSource>

    </ContentTemplate>
</asp:UpdatePanel>
           </Content>
           </cc2:AccordionPane>
           <cc2:AccordionPane ID="AccordionPane2" runat="server">
                <Header><a href="" class="accordionLink">&nbsp;Attachment</a></Header><Content>
<asp:UpdatePanel ID="UpdatePanel5" runat="server">
    <ContentTemplate>
        <x:GridView ID="GridView2" runat="server" AllowSorting="True" 
            AutoGenerateColumns="False" 
            Caption="<%$ Resources:TimeLive.Resource, Attachment List %>" 
            DataKeyNames="AccountProjectTaskAttachmentId" 
            DataSourceID="dsAccountProjectTaskAttachmentObject" 
            SkinID="xgridviewSkinEmployee" Width="656px">
            <Columns>
                <asp:BoundField DataField="AccountProjectTaskAttachmentId" 
                    HeaderText="<%$ Resources:TimeLive.Resource, Id%> " InsertVisible="False" 
                    ReadOnly="True" SortExpression="AccountProjectTaskAttachmentId">
                <ItemStyle HorizontalAlign="Center" Width="40px" />
                <HeaderStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="AccountProjectTaskId" 
                    HeaderText="AccountProjectTaskId" SortExpression="AccountProjectTaskId" 
                    Visible="False" />
                <asp:BoundField DataField="AttachmentName" 
                    HeaderText="<%$ Resources:TimeLive.Resource, Attachment Name%> " 
                    SortExpression="AttachmentName">
                <ItemStyle HorizontalAlign="Left" Width="250px" />
                <HeaderStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, File Name%> " 
                    SortExpression="AttachmentLocalPath">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox5" runat="server" 
                            Text='<%# Bind("AttachmentLocalPath") %>'></asp:TextBox></EditItemTemplate><ItemStyle HorizontalAlign="Left" Width="250px" />
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemTemplate>
                        <asp:HyperLink ID="FileHyperlink" runat="server" 
                            NavigateUrl='<%# "../../Shared/FileDownload.aspx?" & LicensingBLL.GetEncryptedStringAsBase64ByUTF8("FileName=" & DBUtilities.GetSessionAccountId & "/" & Eval("AccountProjectTaskId") & "/" & Eval("AttachmentLocalPath")) %>' 
                            Text='<%# Eval("AttachmentLocalPath") %>'></asp:HyperLink></ItemTemplate></asp:TemplateField><asp:BoundField DataField="CreatedOn" HeaderText="CreatedOn" 
                    SortExpression="CreatedOn" Visible="False" />
                <asp:BoundField DataField="CreatedByEmployeeId" 
                    HeaderText="CreatedByEmployeeId" SortExpression="CreatedByEmployeeId" 
                    Visible="False" />
                <asp:BoundField DataField="ModifiedOn" HeaderText="ModifiedOn" 
                    SortExpression="ModifiedOn" Visible="False" />
                <asp:BoundField DataField="ModifiedByEmployeeId" 
                    HeaderText="ModifiedByEmployeeId" SortExpression="ModifiedByEmployeeId" 
                    Visible="False" />
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Delete_text%> " 
                    ShowHeader="False">
                    <ItemStyle HorizontalAlign="Center" Width="38px" />
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" 
                            CommandName="Delete" 
                            OnClientClick="<%# ResourceHelper.GetDeleteMessageJavascript()%>" Text="<img src='../images/delete.gif'/>"
                            Visible='<%# Eval("AccountProjectTaskAttachmentId")>=0 %>' /></ItemTemplate></asp:TemplateField></Columns></x:GridView><asp:ObjectDataSource ID="dsAccountProjectTaskAttachmentObject" runat="server" 
            DeleteMethod="DeleteAccountProjectTaskAttachment" 
            InsertMethod="AddAccountProjectTaskAttachment" 
            OldValuesParameterFormatString="original_{0}" 
            SelectMethod="GetAccountProjectTaskAttachmentsByAccountProjectTaskId" 
            TypeName="AccountProjectTaskAttachmentBLL">
            <DeleteParameters>
                <asp:Parameter Name="Original_AccountProjectTaskAttachmentId" Type="Int32" />
            </DeleteParameters>
            <SelectParameters>
                <asp:QueryStringParameter DefaultValue="28" Name="AccountProjectTaskId" 
                    QueryStringField="AccountProjectTaskId" Type="Int32" />
                <asp:Parameter Name="NotFixTable" Type="Boolean" />
            </SelectParameters>
            <InsertParameters>
                <asp:Parameter Name="AccountProjectTaskId" Type="Int32" />
                <asp:Parameter Name="AttachmentName" Type="String" />
                <asp:Parameter Name="AttachmentLocalPath" Type="String" />
            </InsertParameters>
        </asp:ObjectDataSource>
        <br />
        &nbsp;<asp:Button ID="btnAddAttachment" runat="server" Text="Add Attachment" 
             />    
    </ContentTemplate>
</asp:UpdatePanel>
        </Content>
        </cc2:AccordionPane>
</Panes>
</cc2:Accordion>