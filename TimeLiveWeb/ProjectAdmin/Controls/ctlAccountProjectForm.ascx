<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlAccountProjectForm.ascx.vb" Inherits="ProjectAdmin_Controls_ctlAccountProjectForm" %>
<%@ Register Assembly="eWorld.UI"
    Namespace="eWorld.UI" TagPrefix="ew" %>
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc2" %>

    <asp:FormView ID="FormView1" runat="server" DataKeyNames="AccountProjectId" DataSourceID="dsAccountProjectFormObject" DefaultMode="Insert" 
            OnDataBound="FormView1_DataBound" OnItemUpdating="FormView1_ItemUpdating" SkinID="formviewSkinEmployee" Width="95%">
            <EditItemTemplate>
                <table class="xview" style="width: 100%">
                    <tr>
                        <th class="caption" colspan="2" style="height: 21px">
                            <asp:Literal ID="Literal1" runat="server" Text='<%# ResourceHelper.GetFromResource("Project Information") %>' />
                        </th>
                    </tr>
                    <tr>
                        <th class="FormViewSubHeader" colspan="2" style="height: 21px;">
                            <asp:Literal ID="Literal21" runat="server" Text='<%# ResourceHelper.GetFromResource("Project") %>' />
                        </th>
                    </tr>
                    <tr>
                        <td align="right" colspan="2" style="height: 21px; padding-top: 5px; padding-right: 5px;">
                            <asp:Button ID="btnProjectMilestone" runat="server" Text="Project Milestone" onclick="btnProjectMilestone_Click" />
                            <asp:Button ID="btnRoleWiseBillingRate" runat="server" OnClick="btnRoleWiseBillingRate_Click" Text="<%$ Resources:TimeLive.Resource, Role Wise Billing Rate%> " />
                            <asp:Button ID="btnProjectEmployees" runat="server" OnClick="btnProjectEmployees_Click" Text="<%$ Resources:TimeLive.Resource, Project Team%> " />
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="FormViewLabelCell" style="width: 30%;" valign="middle">
                            <span class="reqasterisk">*</span>
                            <asp:Literal ID="Literal3" runat="server" Text='<%# ResourceHelper.GetFromResource("Client Name") %>' />:
                        </td>
                        <td style="width: 70%; height: 26px;">
                            <asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="dsClientObject" DataTextField="PartyName" DataValueField="AccountPartyId" Width="350px"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="DropDownList2" CssClass="ErrorMessage" Display="Dynamic" ErrorMessage="*" Width="1px"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="FormViewLabelCell" style="width:30%;">
                            <asp:Label ID="Label5" runat="server" AssociatedControlID="ProjectCodeTextBox">
                            <asp:Literal ID="Literal6" runat="server" Text="Project Code:" /></asp:Label></td>
                        <td style="width: 70%; height: 26px;">
                            <asp:TextBox ID="ProjectCodeTextBox" runat="server" MaxLength="25" Text='<%# Bind("ProjectCode") %>' Width="90px"></asp:TextBox></td></tr>
                    <tr>
                        <td align="right" class="FormViewLabelCell" style="width: 30%;" valign="middle">
                            <span class="reqasterisk">*</span><asp:Label ID="Label14" runat="server" AssociatedControlID="ProjectNameTextBox">
                            <asp:Literal ID="Literal8" runat="server" Text='<%# ResourceHelper.GetFromResource("Project Name") %>' />:</asp:Label>
                        </td>
                        <td style="width: 70%; height: 26px;">
                            <asp:TextBox ID="ProjectNameTextBox" runat="server" MaxLength="50" Text='<%# Bind("ProjectName") %>' Width="336px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ProjectNameTextBox" CssClass="ErrorMessage" Display="Dynamic" ErrorMessage="*" Width="8px"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="FormViewLabelCell" style="width: 30%;" valign="middle">
                            <asp:Literal ID="Literal12" runat="server" Text='<%# ResourceHelper.GetFromResource("Project Status") %>' />:</td>
                        <td style="width: 70%; height: 26px">
                            <asp:DropDownList ID="ddlProjectStatusEdit" runat="server" DataSourceID="dsProjectStatusObject" DataTextField="Status" DataValueField="AccountStatusId" Width="208px"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="FormViewLabelCell" style="width: 30%; padding-bottom: 5px;" valign="middle">
                            <asp:Literal ID="Literal10" runat="server" Text='<%# ResourceHelper.GetFromResource("Start Date:") %>' /></td>
                        <td style="width: 70%; height: 26px; padding-bottom: 5px;">
                            <ew:CalendarPopup ID="StartDate" runat="server" PostedDate="" SelectedDate="09/27/2006 17:09:05" SelectedValue='<%# Bind("StartDate") %>' SkinId="DatePicker" UpperBoundDate="12/31/9999 23:59:59" Width="55px"></ew:CalendarPopup>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="FormViewLabelCell" style="width: 30%; padding-bottom: 5px;" valign="middle">
                            <asp:Literal ID="Literal11" runat="server" Text='<%# ResourceHelper.GetFromResource("Due Date:") %>' /></td>
                        <td style="width: 70%; height: 26px; padding-bottom: 5px;">
                            <ew:CalendarPopup ID="Deadline" runat="server" SelectedDate="09/27/2006 17:09:05" SelectedValue='<%# Bind("Deadline") %>' SkinId="DatePicker" Width="55px"></ew:CalendarPopup>
                        </td>
                    </tr>
                    <tr>
                    <td align="left" colspan="2">
                    <cc2:Accordion ID="MyAccordion" runat="server" SelectedIndex="4" HeaderCssClass="accordionHeader" HeaderSelectedCssClass="accordionHeaderSelected" ContentCssClass="accordionContent" FadeTransitions="true" FramesPerSecond="40" 
                    TransitionDuration="250" AutoSize="None" RequireOpenedPane="false" SuppressHeaderPostbacks="true">
                    <Panes>
                    <cc2:AccordionPane ID="AdvanceAccordion" runat="server" >
                    <Header><a href="" class="accordionLink">Advance Options</a></Header>
                    <Content>
                    <table class="xview" style="width: 100%; border:0">
                    <tr>
                        <td align="right" class="FormViewLabelCell" style="width:30%;">
                        <asp:Label ID="Label8" runat="server" AssociatedControlID="EstimatedDurationTextBoxEdit"><asp:Literal ID="Literal17" runat="server" Text="Duration:" /></asp:Label></td>
                        <td style="width: 70%; height: 26px; vertical-align: middle; white-space: nowrap;" valign="middle">
                            <asp:TextBox ID="EstimatedDurationTextBoxEdit" runat="server" Text='<%# Bind("EstimatedDuration") %>' style="text-align:right;" Width="55px"></asp:TextBox>&nbsp; 
                            <asp:Label ID="lblSystemDurationUnitEdit" runat="server" Text="Hours"></asp:Label>&nbsp;
                            <asp:RangeValidator ID="RangeValidatorEdit" runat="server" ControlToValidate="EstimatedDurationTextBoxEdit" CssClass="ErrorMessage" Display="Dynamic" ErrorMessage="(Invalid Duration Value)" MaximumValue="50000" MinimumValue="0" Type="Double"></asp:RangeValidator>
                        </td>
                    </tr>
                    <%If Not System.Configuration.ConfigurationManager.AppSettings("FIXED_COST") Is Nothing Then%>
                    <tr>
                        <td align="right" class="FormViewLabelCell" style="width:30%;">
                        <asp:Label ID="Label17" runat="server" AssociatedControlID="txtFixedCostEdit"><asp:Literal ID="Literal38" runat="server" Text="Fixed Cost:" /></asp:Label></td>
                        <td style="width: 70%; height: 26px;" >
                        <asp:TextBox ID="txtFixedCostEdit" runat="server" style="text-align:right;" Width="55px" Text='<%# Bind("FixedCost") %>'></asp:TextBox>
                        <asp:RangeValidator ID="RVFixedCostEdit" runat="server" ControlToValidate="txtFixedCostEdit" CssClass="ErrorMessage" Display="Dynamic" EnableClientScript="False" ErrorMessage="Value exceeds maximum number of digits." Font-Bold="False" MaximumValue="9999999" MinimumValue="0" Type="Double">
                        </asp:RangeValidator></td>
                    </tr>
                    <%End If%>
                    <tr>
                        <td align="right" class="FormViewLabelCell" style="width:30%;">
                        <asp:Label ID="lblProjectEstimatedCostEdit" runat="server" AssociatedControlID="txtProjectEstimatedCostEdit"><asp:Literal ID="LiteralProjectEstimatedCostEdit" runat="server" Text="Project Estimated Cost:" /></asp:Label></td><td style="width: 70%; height: 26px;" >
                        <asp:TextBox ID="txtProjectEstimatedCostEdit" runat="server" style="text-align:right;" Width="55px" Text='<%# Bind("ProjectEstimatedCost") %>'></asp:TextBox><asp:RangeValidator ID="RVProjectEstimatedCostEdit" runat="server" ControlToValidate="txtProjectEstimatedCostEdit" CssClass="ErrorMessage" Display="Dynamic" EnableClientScript="False" ErrorMessage="Value exceeds maximum number of digits." Font-Bold="False" MaximumValue="9999999" MinimumValue="0" Type="Double">
                        </asp:RangeValidator></td>
                    </tr>
<%If DBUtilities.GetSessionAccountId = 7354 Then%>
                    <tr>
                        <td align="right" class="FormViewLabelCell" style="width:30%;">
                            <asp:Label ID="lblProjectSpent" runat="server" AssociatedControlID="txtProjectSpent"><asp:Literal ID="Literal19" runat="server" Text="Project Spent To Date:" /></asp:Label></td><td style="width: 70%; height: 26px;" >
                            <asp:TextBox ID="txtProjectSpent" runat="server" style="text-align:right;" Width="55px" ReadOnly="True"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="FormViewLabelCell" style="width:30%;">
                            <asp:Label ID="lblProjectBudgetLeft" runat="server" AssociatedControlID="txtProjectBudgetLeft"><asp:Literal ID="Literal31" runat="server" Text="Project Budget Left:" /></asp:Label></td><td style="width: 70%; height: 26px;" >
                            <asp:TextBox ID="txtProjectBudgetLeft" runat="server" style="text-align:right;" Width="55px" ReadOnly="True"></asp:TextBox></td>
                    </tr>
<%End If%>
</table></Content></cc2:AccordionPane>
<cc2:AccordionPane ID="OtherAccordion" runat="server" >
                    <Header><a href="" class="accordionLink">Other Options</a></Header><Content>
                    <table class="xview" style="width: 100%; border:0;" >
                    <tr>
                        <td align="right" class="FormViewLabelCell" style="width:30%;">
                            <asp:Label ID="Label15" runat="server" AssociatedControlID="ProjectDescriptionTextBoxEdit">
                            <asp:Literal ID="Literal9" runat="server" Text="Project Description:" /></asp:Label></td>
                        <td style="width: 70%; height: 26px; padding-top: 5px; padding-bottom: 5px;">
                            <asp:TextBox ID="ProjectDescriptionTextBoxEdit" runat="server" Height="70px" MaxLength="4000" Rows="3" Text='<%# Bind("ProjectDescription") %>' TextMode="MultiLine" Width="336px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                         <td align="right" class="FormViewLabelCell" style="width:30%;">
                            <asp:Label ID="Label16" runat="server" AssociatedControlID="ddlProjectTypeEdit">
                            <asp:Literal ID="Literal2" runat="server" Text="Project Type:" /></asp:Label></td>
                        <td style="width: 70%; height: 26px;">
                            <asp:DropDownList ID="ddlProjectTypeEdit" runat="server" DataSourceID="dsProjectTypeObject" DataTextField="ProjectType" DataValueField="AccountProjectTypeId" Width="350px"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlProjectTypeEdit" CssClass="ErrorMessage" Display="Dynamic" ErrorMessage="*" Width="1px"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="FormViewLabelCell" style="width:30%;">
                            <asp:Label ID="Label18" runat="server" AssociatedControlID="ddlAccountPartyContactIdEdit">
                            <asp:Literal ID="Literal4" runat="server" Text="Client Contact:" /></asp:Label></td>
                        <td style="width: 70%; height: 26px">
                            <asp:DropDownList ID="ddlAccountPartyContactIdEdit" runat="server" AppendDataBoundItems="True" Width="350px">
                                <asp:ListItem ID="Label2" runat="server" Label="" Text="<%$ Resources:TimeLive.Resource, Select%> " Value="0"></asp:ListItem>
                            </asp:DropDownList>
                            <aspToolkit:CascadingDropDown ID="PartyContactCascadingDropDown" runat="server" Category="Client Contact" LoadingText="Loading" ParentControlID="DropDownList2" 
                            PromptText="<%$ Resources:TimeLive.Resource, Select%> " ServiceMethod="GetAccountPartyContacts" ServicePath="~/Services/ProjectService.asmx" 
                            TargetControlID="ddlAccountPartyContactIdEdit"></aspToolkit:CascadingDropDown>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="FormViewLabelCell" style="width:30%;">
                            <asp:Label ID="Label19" runat="server" AssociatedControlID="ddlAccountPartyDepartmentIdEdit">
                            <asp:Literal ID="Literal5" runat="server" Text="Client Department:" /></asp:Label>
                            </td>
                        <td style="width: 70%; height: 26px">
                            <asp:DropDownList ID="ddlAccountPartyDepartmentIdEdit" runat="server" AppendDataBoundItems="True" Width="350px">
                                <asp:ListItem ID="Label1" runat="server" Label="" Text="<%$ Resources:TimeLive.Resource, Select%> " Value="0"></asp:ListItem>
                            </asp:DropDownList>
                            <aspToolkit:CascadingDropDown ID="PartyDepartmentCascadingDropDown" runat="server" Category="Client Department" LoadingText="Loading" ParentControlID="DropDownList2" 
                            PromptText="<%$ Resources:TimeLive.Resource, Select%> " ServiceMethod="GetAccountPartyDepartments" ServicePath="~/Services/ProjectService.asmx" 
                            TargetControlID="ddlAccountPartyDepartmentIdEdit">
                            </aspToolkit:CascadingDropDown>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="FormViewLabelCell" style="width: 30%;" valign="middle">
                            <asp:Label ID="Label20" runat="server" AssociatedControlID="ddlTeamLeadEditDropDown">
                            <asp:Literal ID="Literal13" runat="server" Text="Team Lead:" /></asp:Label>
                        </td>
                        <td style="width: 70%; height: 26px;">
                            <asp:DropDownList ID="ddlTeamLeadEditDropDown" runat="server" DataSourceID="dsEmployeeObject" DataTextField="FullName" DataValueField="AccountEmployeeId" Width="208px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="FormViewLabelCell" style="width: 30%;" valign="middle">
                            <asp:Label ID="Label21" runat="server" AssociatedControlID="ddlProjectManagerEditDropDown">
                            <asp:Literal ID="Literal14" runat="server" Text="Project Manager:" /></asp:Label>
                        </td>
                        <td style="width: 70%; height: 26px">
                            <asp:DropDownList ID="ddlProjectManagerEditDropDown" runat="server" DataSourceID="dsProjectManagerObject" DataTextField="FullName" DataValueField="AccountEmployeeId" Width="208px"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="ProjectDropdownValidator" runat="server" ControlToValidate="ddlProjectManagerEditDropDown" CssClass="ErrorMessage" Display="Dynamic" ErrorMessage="*" Width="16px"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
<%  If DBUtilities.IsTimesheetFeature Then%>
                    <tr>
                        <td align="right" class="FormViewLabelCell" style="width: 30%;" valign="middle">
                            <asp:Label ID="Label22" runat="server" AssociatedControlID="ddlTimeSheetApprovalTypeIdEdit">
                            <asp:Literal ID="Literal15" runat="server" Text="Timesheet Approval Type:" /></asp:Label>
                        </td>
                        <td style="width: 70%; height: 26px">
                            <asp:DropDownList ID="ddlTimeSheetApprovalTypeIdEdit" runat="server" AppendDataBoundItems="True" DataSourceID="dsTimeSheetApprovalType" DataTextField="ApprovalTypeName" DataValueField="AccountApprovalTypeId" Width="208px"><%--<asp:ListItem Selected="True" Value="0">Approval Not Required</asp:ListItem>--%>
                                <asp:ListItem ID="Label3" runat="server" Label="" Selected="True" Text="<%$ Resources:TimeLive.Resource, Approval Not Required%> " Value="0"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="TimeSheetApprovalTypeValidator" runat="server" ControlToValidate="ddlTimeSheetApprovalTypeIdEdit" CssClass="ErrorMessage" Display="Dynamic" ErrorMessage="*" Width="16px"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
<%  End If%>
<%  If DBUtilities.IsExpenseFeature Then%>
                    <tr>
                        <td align="right" class="FormViewLabelCell" style="width: 30%;" valign="middle">
                            <asp:Label ID="Label23" runat="server" AssociatedControlID="ddlExpenseApprovalTypeIdEdit">
                            <asp:Literal ID="Literal16" runat="server" Text="Expense Approval Type:" /></asp:Label></td>
                        <td style="width: 70%; height: 26px">
                            <asp:DropDownList ID="ddlExpenseApprovalTypeIdEdit" runat="server" AppendDataBoundItems="True" DataSourceID="dsExpenseApprovalType" DataTextField="ApprovalTypeName" DataValueField="AccountApprovalTypeId" Width="208px">
                                <asp:ListItem ID="Label4Edit" runat="server" Label="" Selected="True" Text="<%$ Resources:TimeLive.Resource, Approval Not Required%> " Value="0"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="ExpenseApprovalTypeValidator" runat="server" ControlToValidate="ddlExpenseApprovalTypeIdEdit" CssClass="ErrorMessage" Display="Dynamic" ErrorMessage="*" Width="16px"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
<%  End If%>
                    <tr>
                        <td align="right" class="FormViewLabelCell" style="width: 30%" valign="middle">
                            <asp:Label ID="Label24" runat="server" AssociatedControlID="chkCompletedEdit">
                            <asp:Literal ID="Literal22" runat="server" Text="Completed:" /></asp:Label>
                        </td>
                        <td style="width: 70%; height: 26px">
                            <asp:CheckBox ID="chkCompletedEdit" runat="server" Checked='<%# Bind("Completed") %>' /></td>
                    </tr>
                    <tr style="display:none;">
                        <td align="right" class="FormViewLabelCell" style="width: 30%" valign="middle">
                            <asp:Literal ID="Literal18" runat="server" Text="All Client Project:"/>
                        </td>
                        <td style="width: 70%; height: 26px">
                            <asp:CheckBox ID="chkAllClientProjectEdit" runat="server"  /></td>
                    </tr>
                    <tr>
                        <td align="right" class="FormViewLabelCell" style="width: 30%;" valign="middle">
                            <asp:Label ID="Label25" runat="server" AssociatedControlID="chkIsDisabled">
                            <asp:Literal ID="Literal23" runat="server" Text="Disabled:" /></asp:Label>
                        </td>
                        <td style="width: 70%; height: 26px">
                            <asp:CheckBox ID="chkIsDisabled" runat="server" Checked='<%# Bind("IsDisabled") %>' /></td>
                    </tr>
</table></Content></cc2:AccordionPane>
<cc2:AccordionPane ID="AccordionPane3" runat="server" >
                    <Header><a href="" class="accordionLink">Billing</a></Header><Content>
                    <table class="xview" style="width: 100%; border:0">
                    <tr>
                        <td align="right" class="FormViewLabelCell" style="width: 30%;" valign="middle">
                            <asp:Label ID="UserNameBillingLabel" runat="server" AssociatedControlID="DefaultBillingRateTextBoxEdit">
                            Default Billing Rate:</asp:Label>
                        </td>
                        <td style="width: 70%; height: 26px">
                            <asp:TextBox ID="DefaultBillingRateTextBoxEdit" runat="server" Text='<%# Bind("DefaultBillingRate") %>' style="text-align:right;" Width="55px"></asp:TextBox><br />
                            <asp:RangeValidator ID="RangeValidator1Edit" runat="server" ControlToValidate="DefaultBillingRateTextBoxEdit" CssClass="ErrorMessage" Display="Dynamic" ErrorMessage="Value exceeds maximum number of digits." Font-Bold="False" MaximumValue="9999999" MinimumValue="0" Type="Double"></asp:RangeValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="FormViewLabelCell" style="width: 30%;" valign="middle"> Project Billing Type:</td><td style="width: 70%; height: 26px;">
                            <asp:DropDownList ID="DropDownList4Edit" runat="server" DataSourceID="dsBillingTypeObject" DataTextField="BillingType" DataValueField="AccountBillingTypeId" Width="200px"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="FormViewLabelCell" style="width: 30%;" valign="middle"> 
                            Billing Rate Type:</td>
                        <td style="width: 70%; height: 26px">
                            <asp:DropDownList ID="ddlProjectBillingRateTypeIdEdit" runat="server" DataSourceID="dsSystemProjectBillingRateType" DataTextField="SystemProjectBillingRateType" DataValueField="SystemProjectBillingRateTypeId" Width="200px"></asp:DropDownList></td>
                    </tr>
                    </table> 
                    </Content>
                    </cc2:AccordionPane>
                    <cc2:AccordionPane ID="AccordionPane2" runat="server">
                    <Header><a href="" class="accordionLink">Attachment</a></Header><Content>
                    <table class="xview" style="width: 100%; border:0">
                    <tr><td align="right" class="FormViewLabelCell" style="width: 30%; height: 26px">
                        <asp:Literal ID="Literal222" runat="server" Text="<%$ Resources:TimeLive.Resource, Attachment Name:%> " /></td>
                        <td style="height: 26px"><asp:TextBox ID="AttachmentNameTextBoxEdit" runat="server" ValidationGroup="Attachment" Width="250px"></asp:TextBox></td></tr><tr><td align="right" class="FormViewLabelCell" style="width: 30%; height: 26px">
                        <asp:Literal ID="Literal37" runat="server" Text="<%$ Resources:TimeLive.Resource, File Path:%> " /></td><td style="height: 26px"><asp:FileUpload ID="AttachmentFileUploadEdit" runat="server" Width="344px" /></td>
                    </tr>
                    </table> 
                    </Content>
</cc2:AccordionPane></Panes>
</cc2:Accordion> 
                    <tr>
                        <td colspan="2"><asp:Table ID="CustomTableEdit" runat="server" Height="100%" Width="100%"></asp:Table></td></tr>
                    <tr>
                        <td align="right" style="width: 30%;"></td>
                        <td style="width: 70%; height: 26px; padding-bottom: 5px;">
                            <asp:Button ID="Update" runat="server" CommandName="Update" OnClick="Update_Click" Text="<%$ Resources:TimeLive.Resource, Update_text%> " Width="55px" />&nbsp;
                            <asp:Button ID="Cancel" runat="server" CommandName="Cancel" OnClick="Cancel_Click" Text="<%$ Resources:TimeLive.Resource, Cancel_text%> " Width="55px" />
                        </td>
                    </tr>
</table></EditItemTemplate>
<InsertItemTemplate>
                    <table class="xview" style="width: 100%">
                    <tr>
                        <th class="caption" colspan="2" style="height: 21px"><asp:Literal ID="Literal20" runat="server" Text='<%# ResourceHelper.GetFromResource("Project Information") %>' /></th></tr>
                    <tr>
                        <th class="FormViewSubHeader" colspan="2" style="height: 21px"><asp:Literal ID="Literal21" runat="server" Text='<%# ResourceHelper.GetFromResource("Basic") %>' /></th>
                    </tr>
                    <tr>
                        <td align="right" class="FormViewLabelCell" style="width:30%;">
                            <asp:Label ID="Label5" runat="server" AssociatedControlID="ProjectCodeTextBox">
                            <asp:Literal ID="Literal6" runat="server" Text="Project Code:" /></asp:Label></td>
                        <td style="width: 70%; height: 26px;">
                            <asp:TextBox ID="ProjectCodeTextBox" runat="server" MaxLength="25" Text='<%# Bind("ProjectCode") %>' Width="90px"></asp:TextBox></td></tr>
                    <tr>
                        <td align="right" class="FormViewLabelCell" style="width: 30%;" valign="middle"><span class="reqasterisk">*</span><asp:Literal ID="Literal24" runat="server" Text='<%# ResourceHelper.GetFromResource("Client Name:") %>' /></td><td style="width: 70%; height: 26px;">
                            <asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="dsClientObjectInsert" DataTextField="PartyName" DataValueField="AccountPartyId" SelectedValue='<%# Bind("AccountClientId") %>' Width="350px"></asp:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="DropDownList2" Display="Dynamic" ErrorMessage="*" Width="1px"></asp:RequiredFieldValidator></td></tr><tr><td align="right" class="FormViewLabelCell" style="width: 30%; padding-bottom: 5px;"><span class="reqasterisk">*</span><asp:Label ID="Label7" runat="server" AssociatedControlID="ProjectNameTextBox">
                            <asp:Literal ID="Literal29" runat="server" Text='<%# ResourceHelper.GetFromResource("Project Name:") %>' /></asp:Label></td>
                        <td style="width: 70%; height: 26px; padding-bottom: 5px;"><asp:TextBox ID="ProjectNameTextBox" runat="server" MaxLength="50" Text='<%# Bind("ProjectName") %>' Width="336px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ProjectNameTextBox" Display="Dynamic" ErrorMessage="*" Width="8px"></asp:RequiredFieldValidator></td></tr>
                    <tr>
                        <td align="right" class="FormViewLabelCell" style="width: 30%;" valign="middle">
                             <asp:Literal ID="Literal33" runat="server" Text="<%$ Resources:TimeLive.Resource, Project Status:%> " /></td><td style="width: 70%; height: 26px">
                             <asp:DropDownList ID="DropDownList6" runat="server" Width="200px"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="FormViewLabelCell" style="width: 30%;" valign="middle">Start Date:</td><td style="width: 70%; height: 26px;">
                        <ew:CalendarPopup ID="StartDate" runat="server" PostedDate="" SelectedValue='<%# Bind("StartDate") %>' SkinId="DatePicker" Width="55px"></ew:CalendarPopup></td>
                    </tr>
                    <tr>
                        <td align="right" class="FormViewLabelCell" style="width: 30%; padding-bottom: 5px; padding-top: 5px;" valign="middle"><asp:Literal ID="Literal32" runat="server" Text='<%# ResourceHelper.GetFromResource("Due Date:") %>' /></td>
                        <td style="width: 70%; height: 26px; padding-bottom: 5px; padding-top: 5px;"><ew:CalendarPopup ID="Deadline" runat="server" PostedDate="" SelectedValue='<%# Bind("Deadline") %>' SkinId="DatePicker" Width="55px"></ew:CalendarPopup></td>
                    </tr>
                    
                    <tr>
                        <td align="left" colspan="2">
<% If DBUtilities.IsProjectManagementFeature = True Then%>
                    <cc2:Accordion ID="MyAccordion" runat="server" ContentCssClass="accordionContent" FadeTransitions="true" FramesPerSecond="40" HeaderCssClass="accordionHeader" HeaderSelectedCssClass="accordionHeaderSelected" RequireOpenedPane="false" 
                                    SelectedIndex="7" SuppressHeaderPostbacks="true" TransitionDuration="250">
                        <Panes>
<cc2:AccordionPane ID="AccordionPane4" runat="server">
                        <Header><a class="accordionLink" href="">Advance Options</a></Header><Content>
                        <table class="xview" style="width: 100%; border:0">
<%If Me.Request.QueryString("IsTemplate") <> "True" Then%>
                    <tr>
                        <td align="right" class="FormViewLabelCell" style="width: 30%;" valign="middle">Project Template:</td>
                        <td style="width: 70%; height: 26px">
                            <asp:DropDownList ID="ddlAccountProjectTemplateId" runat="server" AppendDataBoundItems="True" AutoPostBack="True" OnSelectedIndexChanged="ddlAccountProjectTemplateId_SelectedIndexChanged" Width="350px">
                            <asp:ListItem ID="Label4" runat="server" Label="" Text="<%$ Resources:TimeLive.Resource, Select%> " Value="0"></asp:ListItem><%--<asp:ListItem Value="0">&lt;Select&gt;</asp:ListItem>--%></asp:DropDownList>
                         </td>
                     </tr>
<%End If %>
                     <tr>
                        <td align="right" class="FormViewLabelCell" style="width: 30%;" valign="middle">Duration:</td><td style="width: 70%; height: 26px; vertical-align: middle; white-space:nowrap;">
                            <asp:TextBox ID="EstimatedDurationTextBox" runat="server" Text='<%# Bind("EstimatedDuration") %>' style="text-align:right;" Width="55px"></asp:TextBox>&nbsp;<asp:Label ID="lblSystemDurationUnit" runat="server" Text="Hours"></asp:Label>&nbsp; <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="EstimatedDurationTextBox" CssClass="ErrorMessage" Display="Dynamic" EnableClientScript="False" ErrorMessage="(Invalid Duration Value)" MaximumValue="50000" MinimumValue="0" Type="Double"></asp:RangeValidator></td>
                     </tr>
                     <%If Not System.Configuration.ConfigurationManager.AppSettings("FIXED_COST") Is Nothing Then%>
                        <tr>
                            <td align="right" class="FormViewLabelCell" style="width: 30%;" valign="middle"><asp:Label ID="Label11" runat="server" AssociatedControlID="txtFixedCost">
                            <asp:Literal ID="Literal36" runat="server" Text="Fixed Cost:" /></asp:Label></td><td style="width: 70%; height: 26px">
                            <asp:TextBox ID="txtFixedCost" runat="server" style="text-align:right;" Width="55px" Text='<%# Bind("FixedCost") %>' ></asp:TextBox><br />
                            <asp:RangeValidator ID="RVFixedCost" runat="server" ControlToValidate="txtFixedCost" CssClass="ErrorMessage" Display="Dynamic" EnableClientScript="False" ErrorMessage="Value exceeds maximum number of digits." Font-Bold="False" MaximumValue="9999999" MinimumValue="0" Type="Double"></asp:RangeValidator></td>
                        </tr>
                        <%End if%>
                         <tr>
                            <td align="right" class="FormViewLabelCell" style="width: 30%;" valign="middle"><asp:Label ID="lblProjectEstimatedCost" runat="server" AssociatedControlID="txtProjectEstimatedCost">
                            <asp:Literal ID="LiteralProjectEstimatedCost" runat="server" Text="Project Estimated Cost:" /></asp:Label></td><td style="width: 70%; height: 26px">
                            <asp:TextBox ID="txtProjectEstimatedCost" runat="server" style="text-align:right;" Width="55px" Text='<%# Bind("ProjectEstimatedCost") %>' ></asp:TextBox><br /><asp:RangeValidator ID="RVProjectEstimatedCost" runat="server" ControlToValidate="txtProjectEstimatedCost" CssClass="ErrorMessage" Display="Dynamic" EnableClientScript="False" ErrorMessage="Value exceeds maximum number of digits." Font-Bold="False" MaximumValue="9999999" MinimumValue="0" Type="Double"></asp:RangeValidator></td>
                        </tr>
</table></Content></cc2:AccordionPane>
                        </Panes></cc2:Accordion>
<% End If%>
                        </td></tr>
                        <tr>
                        <td colspan="2"><asp:Table ID="CustomTable" runat="server" Height="100%" Width="100%"></asp:Table></td></tr>
                        <tr><td align="right" style="width: 30%; height: 26px;"></td>
                        <td style="padding-bottom: 5px; width: 70%;">
                        <asp:Button ID="Add" runat="server" CommandName="Insert" OnClick="Add_Click" Text="<%$ Resources:TimeLive.Resource, Add_text%> " Width="64px" />&nbsp; 
                        <asp:Button ID="Cancel" runat="server" CommandName="Cancel" OnClick="Cancel_Click" Text="<%$ Resources:TimeLive.Resource, Cancel_text%> " ValidationGroup="Add" Width="64px" />
                        <asp:CustomValidator ID="CustomValidator3" runat="server" CssClass="ErrorMessage" Display="Dynamic" ErrorMessage="Project Template field is required." OnServerValidate="CustomValidator3_ServerValidate" Width="230px" Enabled="False">
                        </asp:CustomValidator>
                        </td></tr>
                        </td></tr></table>
                        </InsertItemTemplate>
    </asp:FormView>
    <asp:ObjectDataSource ID="dsProjectTypeObject" runat="server" OldValuesParameterFormatString="original_{0}"
    SelectMethod="GetAccountProjectTypesByAccountIdAndIsDisabled" TypeName="AccountProjectTypeBLL" DeleteMethod="DeleteAccountProjectType" InsertMethod="AddAccountProjectType" UpdateMethod="UpdateAccountProjectType">
    <DeleteParameters>
        <asp:Parameter Name="Original_AccountProjectTypeId" Type="Int32" />
    </DeleteParameters>
    <UpdateParameters>
        <asp:Parameter Name="AccountId" Type="Int32" />
        <asp:Parameter Name="ProjectType" Type="String" />
        <asp:Parameter Name="Original_AccountProjectTypeId" Type="Int32" />
        <asp:Parameter Name="CreatedOn" Type="DateTime" />
        <asp:Parameter Name="CreatedByEmployeeId" Type="Int32" />
        <asp:Parameter Name="ModifiedOn" Type="DateTime" />
        <asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" />
        <asp:Parameter Name="IsDisabled" Type="Boolean" />
    </UpdateParameters>
    <SelectParameters>
        <asp:SessionParameter DefaultValue="64" Name="AccountId" SessionField="AccountId"
            Type="Int32" />
        <asp:Parameter Name="AccountProjectTypeId" Type="Int32" />
    </SelectParameters>
    <InsertParameters>
        <asp:Parameter Name="AccountId" Type="Int32" />
        <asp:Parameter Name="ProjectType" Type="String" />
        <asp:Parameter Name="CreatedOn" Type="DateTime" />
        <asp:Parameter Name="CreatedByEmployeeId" Type="Int32" />
        <asp:Parameter Name="ModifiedOn" Type="DateTime" />
        <asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" />
    </InsertParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="dsAccountProjectTemplatesObject" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetvueAccountProjectsTemplateByAccountId" TypeName="AccountProjectBLL" DeleteMethod="DeleteAccountProject" 
    InsertMethod="AddAccountProject" UpdateMethod="UpdateProjectDescription">
    <DeleteParameters>
    <asp:Parameter Name="Original_AccountProjectId" Type="Int32" /></DeleteParameters>
    <InsertParameters>
        <asp:Parameter Name="AccountId" Type="Int32" /><asp:Parameter Name="AccountProjectTypeId" Type="Int32" />
        <asp:Parameter Name="AccountClientId" Type="Int32" /><asp:Parameter Name="AccountPartyContactId" Type="Int32" />
        <asp:Parameter Name="AccountPartyDepartmentId" Type="Int32" /><asp:Parameter Name="ProjectBillingTypeId" Type="Int32" />
        <asp:Parameter Name="ProjectName" Type="String" /><asp:Parameter Name="ProjectDescription" Type="String" /><asp:Parameter Name="StartDate" Type="DateTime" /><asp:Parameter Name="Deadline" Type="DateTime" />
        <asp:Parameter Name="ProjectStatusId" Type="Int32" /><asp:Parameter Name="LeaderEmployeeId" Type="Int32" /><asp:Parameter Name="ProjectManagerEmployeeId" Type="Int32" /><asp:Parameter Name="TimeSheetApprovalTypeId" Type="Int32" />
        <asp:Parameter Name="ExpenseApprovalTypeId" Type="Int32" /><asp:Parameter Name="EstimatedDuration" Type="Double" /><asp:Parameter Name="EstimatedDurationUnit" Type="String" />
        <asp:Parameter Name="ProjectCode" Type="String" /><asp:Parameter Name="DefaultBillingRate" Type="Decimal" /><asp:Parameter Name="ProjectBillingRateTypeId" Type="Int32" /><asp:Parameter Name="IsTemplate" Type="Boolean" />
        <asp:Parameter Name="IsProject" Type="Boolean" /><asp:Parameter Name="AccountProjectTemplateId" Type="Int32" /><asp:Parameter Name="CreatedOn" Type="DateTime" />
        <asp:Parameter Name="CreatedByEmployeeId" Type="Int32" /><asp:Parameter Name="ModifiedOn" Type="DateTime" /><asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" />
        <asp:Parameter Name="Completed" Type="Boolean" /><asp:Parameter Name="ProjectPrefix" Type="String" /><asp:Parameter Name="CustomField1" Type="String" /><asp:Parameter Name="CustomField2" Type="String" />
        <asp:Parameter Name="CustomField3" Type="String" /><asp:Parameter Name="CustomField4" Type="String" /><asp:Parameter Name="CustomField5" Type="String" /><asp:Parameter Name="CustomField6" Type="String" /><asp:Parameter Name="CustomField7" Type="String" /><asp:Parameter Name="CustomField8" Type="String" /><asp:Parameter Name="CustomField9" Type="String" /><asp:Parameter Name="CustomField10" Type="String" /><asp:Parameter Name="CustomField11" Type="String" /><asp:Parameter Name="CustomField12" Type="String" /><asp:Parameter Name="CustomField13" Type="String" /><asp:Parameter Name="CustomField14" Type="String" /><asp:Parameter Name="CustomField15" Type="String" />
    </InsertParameters>
    <SelectParameters>
        <asp:SessionParameter DefaultValue="151" Name="AccountId" SessionField="AccountId" Type="Int32" />
    </SelectParameters>
    <UpdateParameters><asp:Parameter Name="ProjectDescription" Type="String" />
        <asp:Parameter Name="Original_AccountProjectId" Type="Int32" />
    </UpdateParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="dsProjectTypeObjectInsert" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetAccountProjectTypesByAccountIdAndIsDisabled" TypeName="AccountProjectTypeBLL" 
        DeleteMethod="DeleteAccountProjectType" InsertMethod="AddAccountProjectType" UpdateMethod="UpdateAccountProjectType">
    <DeleteParameters>
        <asp:Parameter Name="Original_AccountProjectTypeId" Type="Int32" />
    </DeleteParameters>
    <UpdateParameters>
        <asp:Parameter Name="AccountId" Type="Int32" />
        <asp:Parameter Name="ProjectType" Type="String" />
        <asp:Parameter Name="Original_AccountProjectTypeId" Type="Int32" />
        <asp:Parameter Name="CreatedOn" Type="DateTime" />
        <asp:Parameter Name="CreatedByEmployeeId" Type="Int32" />
        <asp:Parameter Name="ModifiedOn" Type="DateTime" />
        <asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" />
        <asp:Parameter Name="IsDisabled" Type="Boolean" />
    </UpdateParameters>
    <SelectParameters>
        <asp:SessionParameter DefaultValue="64" Name="AccountId" SessionField="AccountId" Type="Int32" />
        <asp:Parameter Name="AccountProjectTypeId" Type="Int32" DefaultValue="0" />
    </SelectParameters>
    <InsertParameters>
        <asp:Parameter Name="AccountId" Type="Int32" />
        <asp:Parameter Name="ProjectType" Type="String" />
        <asp:Parameter Name="CreatedOn" Type="DateTime" />
        <asp:Parameter Name="CreatedByEmployeeId" Type="Int32" />
        <asp:Parameter Name="ModifiedOn" Type="DateTime" />
        <asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" />
    </InsertParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="dsAccountProjectFormObject" runat="server" DeleteMethod="DeleteAccountProject"
            InsertMethod="AddAccountProject" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetAccountProjectsByAccountProjectId" TypeName="AccountProjectBLL"
            UpdateMethod="UpdateAccountProject" OnSelecting="dsAccountProjectFormObject_Selecting">
            <DeleteParameters>
                <asp:Parameter Name="Original_AccountProjectId" Type="Int32" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:SessionParameter DefaultValue="23" Name="AccountId" SessionField="AccountId"
                    Type="Int32" />
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
                <asp:Parameter Name="EstimatedDuration" Type="Double" />
                <asp:Parameter Name="EstimatedDurationUnit" Type="String" />
                <asp:Parameter Name="ProjectCode" Type="String" />
                <asp:Parameter Name="DefaultBillingRate" Type="Decimal" />
                <asp:Parameter Name="ProjectBillingRateTypeId" Type="Int32" />
                <asp:QueryStringParameter DefaultValue="False" Name="IsTemplate" QueryStringField="IsTemplate" Type="Boolean" />
                <asp:Parameter Name="IsProject" Type="Boolean" />
                <asp:Parameter Name="AccountProjectTemplateId" Type="Int32" />
                <asp:Parameter Name="CreatedOn" Type="DateTime" />
                <asp:Parameter Name="CreatedByEmployeeId" Type="Int32" />
                <asp:Parameter Name="ModifiedOn" Type="DateTime" />
                <asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" />
                <asp:Parameter Name="Original_AccountProjectId" Type="Int32" />
                <asp:Parameter Name="IsDisabled" Type="Boolean" />
                <asp:Parameter Name="Completed" Type="Boolean" />
                <asp:Parameter Name="ProjectPrefix" Type="String" />
                <asp:Parameter Name="IsForAllClientProject" Type="Boolean" />
                <asp:Parameter Name="ProjectEstimatedCost" Type="Double" />
                <asp:Parameter 
                    Name="FixedCost" Type="Double" /><asp:Parameter Name="CustomField1" Type="String" />
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
                <asp:Parameter Name="CustomField15" Type="String" /></UpdateParameters>
            <SelectParameters>
                <asp:Parameter DefaultValue="1" Name="AccountProjectId" Type="Int32" />
            </SelectParameters>
            <InsertParameters>
                <asp:SessionParameter DefaultValue="23" Name="AccountId" SessionField="AccountId"
                    Type="Int32" />
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
                <asp:Parameter Name="EstimatedDuration" Type="Double" />
                <asp:Parameter Name="EstimatedDurationUnit" Type="String" />
                <asp:Parameter Name="ProjectCode" Type="String" />
                <asp:Parameter Name="DefaultBillingRate" Type="Decimal" />
                <asp:Parameter Name="ProjectBillingRateTypeId" Type="Int32" />
                <asp:QueryStringParameter DefaultValue="False" Name="IsTemplate" QueryStringField="IsTemplate" Type="Boolean" />
                <asp:Parameter Name="IsProject" Type="Boolean" />
                <asp:Parameter Name="AccountProjectTemplateId" Type="Int32" />
                <asp:Parameter Name="CreatedOn" Type="DateTime" />
                <asp:Parameter Name="CreatedByEmployeeId" Type="Int32" />
                <asp:Parameter Name="ModifiedOn" Type="DateTime" />
                <asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" />
                <asp:Parameter Name="Completed" Type="Boolean" />
                <asp:Parameter Name="ProjectPrefix" Type="String" />
                <asp:Parameter Name="IsForAllClientProject" Type="Boolean" />
                <asp:Parameter Name="ProjectEstimatedCost" Type="Double" />
                <asp:Parameter 
                    Name="FixedCost" Type="Double" /><asp:Parameter Name="IsWebServiceCall" Type="Boolean" />
                <asp:Parameter Name="CustomField1" Type="String" />
                <asp:Parameter Name="CustomField2" 
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
<asp:ObjectDataSource ID="dsClientObject" 
    runat="server" OldValuesParameterFormatString="original_{0}"
    SelectMethod="GetAccountPartiesByAccountIdAndAccountPartyId" 
    TypeName="AccountPartyBLL" DeleteMethod="DeleteAccountParty" 
    InsertMethod="AddAccountParty" UpdateMethod="UpdateAccountParty"><DeleteParameters><asp:Parameter 
            Name="original_AccountPartyId" Type="Int32" /></DeleteParameters><InsertParameters><asp:Parameter 
            Name="AccountId" Type="Int32" /><asp:Parameter Name="PartyName" 
            Type="String" /><asp:Parameter Name="PartyNick" Type="String" /><asp:Parameter 
            Name="EMailAddress" Type="String" /><asp:Parameter Name="Address1" 
            Type="String" /><asp:Parameter Name="Address2" Type="String" /><asp:Parameter 
            Name="CountryId" Type="Int16" /><asp:Parameter Name="State" Type="String" /><asp:Parameter 
            Name="City" Type="String" /><asp:Parameter Name="ZipCode" Type="String" /><asp:Parameter 
            Name="Telephone1" Type="String" /><asp:Parameter Name="Telephone2" 
            Type="String" /><asp:Parameter Name="Fax" Type="String" /><asp:Parameter 
            Name="DefaultBillingRate" Type="Decimal" /><asp:Parameter Name="Website" 
            Type="String" /><asp:Parameter Name="Notes" Type="String" /><asp:Parameter 
            Name="IsDisabled" Type="Boolean" /><asp:Parameter Name="IsDeleted" 
            Type="Boolean" /><asp:Parameter Name="CreatedOn" Type="DateTime" /><asp:Parameter 
            Name="CreatedByEmployeeId" Type="Int32" /><asp:Parameter Name="ModifiedOn" 
            Type="DateTime" /><asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" /><asp:Parameter 
            Name="CustomField1" Type="String" /><asp:Parameter Name="CustomField2" 
            Type="String" /><asp:Parameter Name="CustomField3" Type="String" /><asp:Parameter 
            Name="CustomField4" Type="String" /><asp:Parameter Name="CustomField5" 
            Type="String" /><asp:Parameter Name="CustomField6" Type="String" /><asp:Parameter 
            Name="CustomField7" Type="String" /><asp:Parameter Name="CustomField8" 
            Type="String" /><asp:Parameter Name="CustomField9" Type="String" /><asp:Parameter 
            Name="CustomField10" Type="String" /><asp:Parameter Name="CustomField11" 
            Type="String" /><asp:Parameter Name="CustomField12" Type="String" /><asp:Parameter 
            Name="CustomField13" Type="String" /><asp:Parameter Name="CustomField14" 
            Type="String" /><asp:Parameter Name="CustomField15" Type="String" /></InsertParameters><SelectParameters>
        <asp:SessionParameter DefaultValue="64" Name="AccountId" SessionField="AccountId"
            Type="Int32" />
        <asp:Parameter Name="AccountPartyId" Type="Int32" />
    </SelectParameters>
<UpdateParameters><asp:Parameter Name="PartyTypeId" Type="Int16" /><asp:Parameter 
            Name="AccountId" Type="Int32" /><asp:Parameter Name="PartyName" 
            Type="String" /><asp:Parameter Name="PartyNick" Type="String" /><asp:Parameter 
            Name="EMailAddress" Type="String" /><asp:Parameter Name="Address1" 
            Type="String" /><asp:Parameter Name="Address2" Type="String" /><asp:Parameter 
            Name="CountryId" Type="Int16" /><asp:Parameter Name="State" Type="String" /><asp:Parameter 
            Name="City" Type="String" /><asp:Parameter Name="ZipCode" Type="String" /><asp:Parameter 
            Name="Telephone1" Type="String" /><asp:Parameter Name="Telephone2" 
            Type="String" /><asp:Parameter Name="Fax" Type="String" /><asp:Parameter 
            Name="DefaultBillingRate" Type="Decimal" /><asp:Parameter Name="Website" 
            Type="String" /><asp:Parameter Name="Notes" Type="String" /><asp:Parameter 
            Name="IsDisabled" Type="Boolean" /><asp:Parameter Name="IsDeleted" 
            Type="Boolean" /><asp:Parameter Name="CreatedOn" Type="DateTime" /><asp:Parameter 
            Name="CreatedByEmployeeId" Type="Int32" /><asp:Parameter Name="ModifiedOn" 
            Type="DateTime" /><asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" /><asp:Parameter 
            Name="Original_AccountPartyId" Type="Int32" /><asp:Parameter 
            Name="CustomField1" Type="String" /><asp:Parameter Name="CustomField2" 
            Type="String" /><asp:Parameter Name="CustomField3" Type="String" /><asp:Parameter 
            Name="CustomField4" Type="String" /><asp:Parameter Name="CustomField5" 
            Type="String" /><asp:Parameter Name="CustomField6" Type="String" /><asp:Parameter 
            Name="CustomField7" Type="String" /><asp:Parameter Name="CustomField8" 
            Type="String" /><asp:Parameter Name="CustomField9" Type="String" /><asp:Parameter 
            Name="CustomField10" Type="String" /><asp:Parameter Name="CustomField11" 
            Type="String" /><asp:Parameter Name="CustomField12" Type="String" /><asp:Parameter 
            Name="CustomField13" Type="String" /><asp:Parameter Name="CustomField14" 
            Type="String" /><asp:Parameter Name="CustomField15" Type="String" /></UpdateParameters></asp:ObjectDataSource>
            <asp:ObjectDataSource ID="dsClientObjectInsert" runat="server" OldValuesParameterFormatString="original_{0}"
    SelectMethod="GetAccountPartiesByAccountIdAndAccountPartyId" TypeName="AccountPartyBLL" DeleteMethod="DeleteAccountParty" InsertMethod="AddAccountParty" UpdateMethod="UpdateAccountParty">
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
        <asp:Parameter Name="AccountPartyId" Type="Int32" DefaultValue="0" />
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
<asp:ObjectDataSource ID="dsEmployeeObject" runat="server" OldValuesParameterFormatString="original_{0}"
    SelectMethod="GetAccountEmployeesByAccountIdAndIsDisabled" TypeName="AccountEmployeeBLL">
    <SelectParameters>
        <asp:SessionParameter DefaultValue="64" Name="AccountId" SessionField="AccountId"
            Type="Int32" />
        <asp:Parameter Name="AccountEmployeeId" Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource><asp:ObjectDataSource ID="dsProjectManagerObject" runat="server" OldValuesParameterFormatString="original_{0}"
    SelectMethod="GetAccountEmployeesByAccountIdAndIsDisabled" TypeName="AccountEmployeeBLL">
    <SelectParameters>
        <asp:SessionParameter DefaultValue="64" Name="AccountId" SessionField="AccountId"
            Type="Int32" />
        <asp:Parameter Name="AccountEmployeeId" Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>
        <asp:ObjectDataSource ID="dsEmployeeObjectInsert" runat="server" OldValuesParameterFormatString="original_{0}"
    SelectMethod="GetAccountEmployeesByAccountIdAndIsDisabled" TypeName="AccountEmployeeBLL" DeleteMethod="DeleteAccountEmployee" InsertMethod="AddAccountEmployee2" UpdateMethod="UpdateUsernameOfExistingEmployee">
            <DeleteParameters>
                <asp:Parameter Name="Original_AccountEmployeeId" Type="Int32" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="Original_AccountEmployeeId" Type="Int32" />
                <asp:Parameter Name="Username" Type="String" />
            </UpdateParameters>
            <SelectParameters>
                <asp:SessionParameter DefaultValue="64" Name="AccountId" SessionField="AccountId"
            Type="Int32" />
                <asp:Parameter DefaultValue="0" Name="AccountEmployeeId" Type="Int32" />
            </SelectParameters>
            <InsertParameters>
                <asp:Parameter Name="Login" Type="String" />
                <asp:Parameter Name="Password" Type="String" />
                <asp:Parameter Name="Prefix" Type="String" />
                <asp:Parameter Name="FirstName" Type="String" />
                <asp:Parameter Name="LastName" Type="String" />
            </InsertParameters>
</asp:ObjectDataSource>
<asp:ObjectDataSource ID="dsBillingTypeObject" runat="server" OldValuesParameterFormatString="original_{0}"
    SelectMethod="GetAccountBillingTypesForProjectByAccountIdAndIsDisabled" TypeName="AccountBillingTypeBLL">
    <SelectParameters>
        <asp:SessionParameter DefaultValue="64" Name="AccountId" SessionField="AccountId"
            Type="Int32" />
        <asp:Parameter Name="AccountBillingTypeId" Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource><asp:ObjectDataSource ID="dsBillingTypeObjectInsert" runat="server" OldValuesParameterFormatString="original_{0}"
    SelectMethod="GetAccountBillingTypesForProjectByAccountIdAndIsDisabled" TypeName="AccountBillingTypeBLL" DeleteMethod="DeleteAccountBillingType" InsertMethod="AddAccountBillingType" UpdateMethod="UpdateAccountBillingType">
    <DeleteParameters>
        <asp:Parameter Name="Original_AccountBillingTypeId" Type="Int32" />
    </DeleteParameters>
    <UpdateParameters>
        <asp:Parameter Name="AccountId" Type="Int32" />
        <asp:Parameter Name="BillingType" Type="String" />
        <asp:Parameter Name="BillingCategoryId" Type="Int32" />
        <asp:Parameter Name="Original_AccountBillingTypeId" Type="Int32" />
        <asp:Parameter Name="CreatedOn" Type="DateTime" />
        <asp:Parameter Name="CreatedByEmployeeId" Type="Int32" />
        <asp:Parameter Name="ModifiedOn" Type="DateTime" />
        <asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" />
        <asp:Parameter Name="IsDisabled" Type="Boolean" />
    </UpdateParameters>
    <SelectParameters>
        <asp:SessionParameter DefaultValue="64" Name="AccountId" SessionField="AccountId"
            Type="Int32" />
        <asp:Parameter Name="AccountBillingTypeId" Type="Int32" DefaultValue="0" />
    </SelectParameters>
    <InsertParameters>
        <asp:Parameter Name="AccountId" Type="Int32" />
        <asp:Parameter Name="BillingType" Type="String" />
        <asp:Parameter Name="BillingCategoryId" Type="Int32" />
        <asp:Parameter Name="CreatedOn" Type="DateTime" />
        <asp:Parameter Name="CreatedByEmployeeId" Type="Int32" />
        <asp:Parameter Name="ModifiedOn" Type="DateTime" />
        <asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" />
    </InsertParameters>
</asp:ObjectDataSource>
        <asp:ObjectDataSource ID="dsDurationObject" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetDurationUnit" TypeName="SystemDataBLL"></asp:ObjectDataSource>
        <asp:ObjectDataSource ID="dsProjectStatusObject" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetAccountsStatusForProjectByIsDisabled" TypeName="AccountStatusBLL">
            <SelectParameters>
                <asp:SessionParameter DefaultValue="64" Name="AccountId" SessionField="AccountId"
                    Type="Int32" />
                <asp:Parameter Name="AccountStatusId" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="dsProjectStatusObjectInsert" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetAccountsStatusForProjectByIsDisabled" TypeName="AccountStatusBLL" DeleteMethod="DeleteAccountStatus" InsertMethod="AddAccountStatus" UpdateMethod="UpdateAccountStatus">
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
        <asp:ObjectDataSource ID="dsAccountProjectEmployees" runat="server" DeleteMethod="DeleteAccountProjectEmployeeId"
            InsertMethod="AddAccountProjectEmployee" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetAccountProjectEmployeesForSelection" TypeName="AccountProjectEmployeeBLL">
            <DeleteParameters>
                <asp:Parameter Name="Original_AccountProjectEmployeeId" Type="Int32" />
            </DeleteParameters>
            <SelectParameters>
                <asp:SessionParameter DefaultValue="64" Name="AccountId" SessionField="AccountId"
                    Type="Int32" />
                <asp:QueryStringParameter DefaultValue="1" Name="AccountProjectId" QueryStringField="AccountProjectId"
                    Type="Int32" />
            </SelectParameters>
            <InsertParameters>
                <asp:Parameter Name="AccountId" Type="Int32" />
                <asp:Parameter Name="AccountProjectId" Type="Int32" />
                <asp:Parameter Name="AccountEmployeeId" Type="Int32" />
            </InsertParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="dsSystemProjectBillingRateType" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetProjectBillingRateType" TypeName="SystemDataBLL"></asp:ObjectDataSource>
        <asp:ObjectDataSource ID="dsTimeSheetApprovalType" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetAccountApprovalTypesByAccountIdForTimeSheetApproval" TypeName="AccountApprovalBLL">
            <SelectParameters>
                <asp:SessionParameter DefaultValue="64" Name="AccountId" SessionField="AccountId"
                    Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="dsExpenseApprovalType" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetAccountApprovalTypesByAccountIdForTimeSheetApproval" TypeName="AccountApprovalBLL">
            <SelectParameters>
                <asp:SessionParameter DefaultValue="64" Name="AccountId" SessionField="AccountId"
                    Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
