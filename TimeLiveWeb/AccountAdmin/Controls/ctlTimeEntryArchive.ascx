<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlTimeEntryArchive.ascx.vb" Inherits="AccountAdmin_Controls_ctlTimeEntryArchive" %>
<%@ Register Assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2"
    Namespace="eWorld.UI" TagPrefix="ew" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    <table class="xFormView" width="98%"><tr><td>
        <table  style="width: 600px" class="xFormView">
            <tr>
                <th class="caption" colspan="2">
                    <asp:Literal ID="Literal5" runat="server" Text="<%$ Resources:TimeLive.Resource, Time Entry Archive%> " /></th>
            </tr>
            <tr>
                <th class="FormViewSubHeader" colspan="2" style="height: 21px">
                    <asp:Literal ID="Literal1" runat="server" Text="<%$ Resources:TimeLive.Resource, Search Parameters%> " /></th>
            </tr>
            <tr>
                <td align="right" class="formviewlabelcell" style="width: 30%">
                    <asp:Literal ID="Literal2" runat="server" Text="<%$ Resources:TimeLive.Resource, Employees%> " />:</td>
                <td>
                    <asp:DropDownList ID="ddlEmployees" runat="server" AppendDataBoundItems="True" 
                        Width="80%">
                        <asp:ListItem Selected="True" Value="0" Label ID="Label5" runat="server" Text="<%$ Resources:TimeLive.Resource, All%> "></asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td align="right" class="formviewlabelcell">
                    <asp:Literal ID="Literal10" runat="server" Text="<%$ Resources:TimeLive.Resource, Client Name%> " />:</td>
                <td>
                    <asp:DropDownList ID="ddlClients" runat="server" AppendDataBoundItems="True" DataSourceID="dsClientsObject"
                        DataTextField="PartyName" DataValueField="AccountPartyId" Width="80%">
                        <asp:ListItem Selected="True" Value="0" Label ID="Label6" runat="server" Text="<%$ Resources:TimeLive.Resource, All%> "></asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td align="right" class="formviewlabelcell" >
                    <asp:Literal ID="Literal3" runat="server" Text="<%$ Resources:TimeLive.Resource, Project%> " />:</td>
                <td>
                    <asp:DropDownList ID="ddlProjects" runat="server" AppendDataBoundItems="True"
                        DataTextField="ProjectName" DataValueField="AccountProjectId" Width="80%" DataSourceID="dsProjectsObject">
                        <asp:ListItem Selected="True" Value="0" Label ID="Label7" runat="server" Text="<%$ Resources:TimeLive.Resource, All%> "></asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td align="right" class="formviewlabelcell">
                    <asp:Literal ID="Literal4" runat="server" Text="<%$ Resources:TimeLive.Resource, Project Tasks%> " />:</td>
                <td>
                    <asp:DropDownList ID="ddlProjectTasks" runat="server" AppendDataBoundItems="True"  DataSourceID = "dsProjectTaskObject"
            DataTextField = "TaskName" DataValueField = "AccountProjectTaskId" Width="80%">
                        <asp:ListItem Selected="True" Value="0"></asp:ListItem>
                    </asp:DropDownList><br />
                    <aspToolkit:CascadingDropDown ID="CascadingDropDown1" runat="server" Category="ProjectTasks"
                        LoadingText="Loading" ParentControlID="ddlProjects" PromptText="<%$ Resources:TimeLive.Resource, All%> "
                        ServiceMethod="GetAccountProjectTasksForReportByTimeSheet" ServicePath="~/Services/ProjectService.asmx"
                        TargetControlID="ddlProjectTasks">
                    </aspToolkit:CascadingDropDown>
                </td>
            </tr>
            <tr>
                <td align="right" class="formviewlabelcell" >
                    <asp:Literal ID="Literal6" runat="server" Text="<%$ Resources:TimeLive.Resource, Approved%> " />:</td>
                <td >
                    <asp:DropDownList ID="ddlApproved" runat="server" AppendDataBoundItems="True" 
                        Width="26%">
                        <asp:ListItem Value="1" Label ID="Label4" runat="server" Text="<%$ Resources:TimeLive.Resource, Approved%> "></asp:ListItem>
                        <%--<asp:ListItem Value="1">Approved</asp:ListItem>--%>
                        <asp:ListItem Value="0" Label ID="Label15" runat="server" Text="<%$ Resources:TimeLive.Resource, Not Approved%> "></asp:ListItem>
                        <%--<asp:ListItem Value="0">Not Approved</asp:ListItem>--%>
                        <asp:ListItem Selected="True" Value="-1" Label ID="Label16" runat="server" Text="<%$ Resources:TimeLive.Resource, Both%> "></asp:ListItem>
                        <%--<asp:ListItem Selected="True" Value="-1">Both</asp:ListItem>--%>
                    </asp:DropDownList></td>
            </tr>
            <tr style="display:none;">
                <td align="right" class="formviewlabelcell" >
                    <asp:Literal ID="Literal7" runat="server" Text="<%$ Resources:TimeLive.Resource, Include Date Range%> " />:</td>
                <td >
                    <asp:CheckBox ID="chkIncludeDateRange" runat="server" /></td>
            </tr>
            <tr>
                <td align="right" class="formviewlabelcell" >
                    <asp:Literal ID="Literal8" runat="server" Text="<%$ Resources:TimeLive.Resource, Start Date%> " />:</td>
                <td >
                    <ew:CalendarPopup ID="StartDate" runat="server" SkinId="DatePicker" 
                        Width="55px">
                    </ew:CalendarPopup>
                </td>
            </tr>
            <tr>
                <td align="right" class="formviewlabelcell" >
                    <asp:Literal ID="Literal9" runat="server" Text="<%$ Resources:TimeLive.Resource, End Date%> " />:</td>
                <td >
                    <ew:CalendarPopup ID="EndDate" runat="server" SkinId="DatePicker" Width="55px" >
                    </ew:CalendarPopup>
                </td>
            </tr>
            <tr>
                <td align="right" class="formviewlabelcell">
                </td>
                <td style="padding-bottom: 5px; padding-top: 5px;" >
                    <asp:Button ID="Show" runat="server" OnClick="Show_Click" Text="<%$ Resources:TimeLive.Resource, Show_text%> " Width="68px" />
                    </td>
            </tr>
        </table>
        </td></tr></table>
        <asp:ObjectDataSource ID="dsProjectsObject" runat="server" 
            DeleteMethod="DeleteAccountProject" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetvueAccountProjectsByAccountId" 
            TypeName="AccountProjectBLL" InsertMethod="AddAccountProject" 
            UpdateMethod="UpdateProjectDescription">
            <DeleteParameters>
                <asp:Parameter Name="Original_AccountProjectId" Type="Int32" />
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
                <asp:Parameter Name="ProjectPrefix" Type="String" />
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
                <asp:SessionParameter DefaultValue="False" Name="AccountId" SessionField="AccountId"
                    Type="Int32" />
                <asp:Parameter Name="IsTemplate" Type="Boolean" />
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter Name="ProjectDescription" Type="String" />
                <asp:Parameter Name="Original_AccountProjectId" Type="Int32" />
            </UpdateParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="dsProjectTaskObject" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetAssignedProjectTasksFromvueAccountProjectTask" TypeName="AccountProjectTaskBLL">
            <SelectParameters>
                <asp:ControlParameter ControlID="ddlProjects" DefaultValue="0" Name="AccountProjectId"
                    PropertyName="SelectedValue" Type="Int32" />
                <asp:ControlParameter ControlID="ddlEmployees" DefaultValue="" Name="AccountEmployeeId"
                    PropertyName="SelectedValue" Type="Int32" />
                <asp:Parameter Name="AccountProjectTaskId" Type="Int32" />
                <asp:SessionParameter Name="AccountId" SessionField="AccountId" Type="Int32" />
                <asp:Parameter DefaultValue="True" Name="Completed" Type="Boolean" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="dsClientsObject" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetvueAccountPartiesByAccountId" 
            TypeName="AccountPartyBLL">
            <SelectParameters>
                <asp:SessionParameter DefaultValue="64" Name="AccountId" SessionField="AccountId"
                    Type="Int32" />
                <asp:Parameter Name="AccountPartyId" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="dsEmployeesObject" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetAccountEmployeesViewByAccountIdWithDisabled" 
TypeName="AccountEmployeeBLL">
            <SelectParameters>
                <asp:SessionParameter DefaultValue="64" Name="AccountId" SessionField="AccountId"
                    Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </ContentTemplate>
</asp:UpdatePanel>
<br />
<asp:UpdatePanel ID="UpdatePanel2" runat="server">
    <ContentTemplate>
        <x:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="AccountEmployeeTimeEntryId,AccountEmployeeId,TimeEntryStartDate,TimeEntryEndDate,TimeEntryViewType,TimeEntryDate,AccountEmployeeTimeEntryApprovalProjectId,AccountEmployeeTimeEntryPeriodId,IsTimeOff"
            DataSourceID="dsUpdateTimeEntry" SkinID="xgridviewSkinEmployee" 
            Caption="<%$ Resources:TimeLive.Resource, Time Entry Archive %>" Width="98%" 
            OnRowDeleting="GridView1_RowDeleting">
            <Columns>
                <asp:TemplateField>
                    <itemtemplate>
                    <asp:CheckBox id="chkDelete" runat="server" __designer:wfdid="w55"></asp:CheckBox> 
                    </itemtemplate>
                    <ItemStyle Width="1%" />
                </asp:TemplateField>
                <asp:BoundField DataField="EmployeeName" 
                    HeaderText="<%$ Resources:TimeLive.Resource, Employee Name %>" ReadOnly="True"
                    SortExpression="EmployeeName" ItemStyle-Width="20%" >
                <ItemStyle Width="20%" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Project Name %>" 
                    SortExpression="ProjectName">
                    <EditItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("ProjectName") %>'></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("ProjectName") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="13%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Task Name %>" 
                    SortExpression="TaskName">
                    <EditItemTemplate>
                        <asp:Label ID="Label7" runat="server" Text='<%# Eval("TaskName") %>'></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label7" runat="server" Text='<%# Bind("TaskName") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="13%" />
                </asp:TemplateField>
                <asp:BoundField DataField="TimeEntryDate" 
                    HeaderText="<%$ Resources:TimeLive.Resource,Date %>" SortExpression="TimeEntryDate" 
                    DataFormatString="{0:d}" ReadOnly="True" ItemStyle-Width="5%" >
                <ItemStyle Width="5%" HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Start Time %>" SortExpression="StartTime">
                    <EditItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("StartTime", "{0:HH:mm}") %>'></asp:Label>
 </EditItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="7%" />
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("StartTime", "{0:HH:mm}") %>'></asp:Label>
</ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, End Time %>" SortExpression="EndTime">
                    <EditItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Eval("EndTime", "{0:HH:mm}") %>'></asp:Label>
                    
</EditItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="6%" />
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("EndTime", "{0:HH:mm}") %>'></asp:Label>
                    
</ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Total Time %>" SortExpression="TotalTime">
                    <EditItemTemplate>
<asp:Label id="Label4" runat="server" Text='<%# Eval("TotalTime", "{0:HH:mm}") %>' __designer:wfdid="w6"></asp:Label> 
</EditItemTemplate>
                    <FooterTemplate>
<asp:Label id="SumTime" runat="server" Text='<%# Bind("TotalTime") %>' __designer:wfdid="w7"></asp:Label> 
</FooterTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="7%" />
                    <ItemTemplate>
<asp:Label id="Label4" runat="server" Text='<%# Bind("TotalTime", "{0:HH:mm}") %>' __designer:wfdid="w5"></asp:Label> 
</ItemTemplate>
                    <FooterStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Percentage %>" SortExpression="Percentage" 
                    Visible="False">
                    <EditItemTemplate>
                        <asp:Label ID="Label20" runat="server" __designer:wfdid="w6"></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label20" runat="server" __designer:wfdid="w5" 
                            Text='<%# Bind("Percentage") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="8%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Billing Rate %>" SortExpression="BillingRate">
                    <EditItemTemplate>
<asp:TextBox id="TextBox1" runat="server" Text='<%# Bind("BillingRate", "{0:N}") %>' Width="65px" __designer:wfdid="w9"></asp:TextBox> 
</EditItemTemplate>
                    <ItemStyle HorizontalAlign="Right" Width="7%" />
                    <ItemTemplate>
<asp:Label id="Label5" runat="server" Text='<%# Bind("BillingRate", "{0:N}") %>' __designer:wfdid="w8"></asp:Label> 
</ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Submitted %>">
                    <edititemtemplate>
<asp:CheckBox id="chkSubmitted" runat="server" __designer:wfdid="w26" Checked='<%# Bind("Submitted") %>'></asp:CheckBox>
</edititemtemplate>
                    <itemstyle horizontalalign="Center" Width="5%" />
                    <itemtemplate>
<asp:CheckBox id="CheckBox1" runat="server" __designer:wfdid="w25" Enabled="false" Checked='<%# Bind("Submitted") %>'></asp:CheckBox>
</itemtemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Approved %>">
                    <edititemtemplate>
<asp:CheckBox id="chkApproved" runat="server" __designer:wfdid="w24" Checked='<%# Bind("Approved") %>'></asp:CheckBox>
</edititemtemplate>
                    <itemstyle horizontalalign="Center" Width="5%" />
                    <itemtemplate>
<asp:CheckBox id="CheckBox2" runat="server" __designer:wfdid="w23" Enabled="false" Checked='<%# Bind("Approved") %>'></asp:CheckBox>
</itemtemplate>
                </asp:TemplateField>
            <asp:CommandField HeaderText="<%$ Resources:TimeLive.Resource, Edit_text %>" ShowEditButton="True" EditImageUrl="~/Images/edit.gif" >
                    <ItemStyle HorizontalAlign="Center"  Width="1%" />
            </asp:CommandField>
        <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Delete_Text %>" ShowHeader="False">
     <ItemTemplate>
<asp:LinkButton id="LinkButton1" runat="server" __designer:wfdid="w13" OnClientClick="<%# ResourceHelper.GetDeleteMessageJavascript()%>" CommandName="Delete" CausesValidation="False"></asp:LinkButton> 
</ItemTemplate>
            <ItemStyle HorizontalAlign="Center"  cssclass="delete_button" Width="1%" />
        </asp:TemplateField>
                <asp:TemplateField SortExpression="AccountEmployeeTimeEntryId" Visible="False">
                    <edititemtemplate>
<asp:Label id="Label5" runat="server" Text='<%# Eval("AccountEmployeeTimeEntryId") %>' __designer:wfdid="w2"></asp:Label> 
</edititemtemplate>
                    <itemtemplate>
<asp:Label id="Label6" runat="server" Text='<%# Bind("AccountEmployeeTimeEntryId") %>' __designer:wfdid="w1"></asp:Label> 
</itemtemplate>
                </asp:TemplateField>
            </Columns>
        </x:GridView>
        <br />
            <table style="width: 99%">
                <tr>
                    <td style=" padding-left:5px" align="left">
        <asp:LinkButton ID="CheckAll" runat="server" CssClass="FeatureHeadingIcon"
            OnClientClick="ChangeAllCheckBoxStates1(true);" Visible="False" OnClick="CheckAll_Click">
            <asp:Literal ID="Literal19" runat="server" Text="<%$ Resources:TimeLive.Resource, Check-All %>"></asp:Literal></asp:LinkButton>
                        <asp:LinkButton
                ID="UnCheckAll" runat="server" CssClass="FeatureHeadingIcon" OnClientClick="ChangeAllCheckBoxStates1(false);"
                Visible="False" OnClick="UnCheckAll_Click">
                <asp:Literal ID="Literal20" runat="server" Text="<%$ Resources:TimeLive.Resource, Uncheck-All %>"></asp:Literal></asp:LinkButton></td>
                    <td style=" padding-right:5px" align="right">
                        <asp:Button ID="btnDeleteSelectedItem" runat="server" Text="<%$ Resources:TimeLive.Resource, Delete Selected%>"
            Width="90px" OnClick="btnDeleteSelectedItem_Click" Visible="False" /></td>
                </tr>
            </table>
    <asp:ObjectDataSource ID="dsUpdateTimeEntry" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetDataForDetailTimeSheetReportForTimeSheetArchive" TypeName="AccountEmployeeTimeEntryBLL" UpdateMethod="UpdateTimeEntrArchive" DeleteMethod="DeleteAccountEmployeeTimeEntry" >
            <SelectParameters>
                <asp:SessionParameter Name="AccountId" SessionField="AccountId" Type="Int32" />
                <asp:ControlParameter ControlID="ddlEmployees" DefaultValue="129" Name="AccountEmployees"
                    PropertyName="SelectedValue" Type="String" />
                <asp:ControlParameter ControlID="ddlProjects" DefaultValue="0" Name="AccountProjectId"
                    PropertyName="SelectedValue" Type="Int32" />
                <asp:ControlParameter ControlID="ddlProjectTasks" DefaultValue="0" Name="AccountProjectTaskId"
                    PropertyName="SelectedValue" Type="Int64" />
                <asp:ControlParameter ControlID="ddlClients" DefaultValue="0" Name="AccountPartyId"
                    PropertyName="SelectedValue" Type="Int32" />
                <asp:ControlParameter ControlID="chkIncludeDateRange" DefaultValue="False" Name="IncludeDateRange"
                    PropertyName="Checked" Type="Boolean" />
                <asp:Parameter DefaultValue="11/02/2008" Name="TimeEntryStartDate" Type="DateTime" />
                <asp:Parameter DefaultValue="11/02/2008" Name="TimeEntryEndDate" Type="DateTime" />
                <asp:ControlParameter ControlID="ddlApproved" DefaultValue="-1" Name="Approval" PropertyName="SelectedValue"
                    Type="String" />
                <asp:Parameter DefaultValue="-1" Name="Billable" Type="String" />
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter Name="Original_AccountEmployeeTimeEntryId" Type="Int32" />
                <asp:Parameter Name="Approved" Type="Boolean" />
                <asp:Parameter Name="BillingRate" Type="Decimal" />
                <asp:Parameter Name="Submitted" Type="Boolean" />
                <asp:Parameter Name="original_IsTimeOff" Type="Boolean" />
                <asp:Parameter DbType="Guid" Name="original_AccountEmployeeTimeOffRequestId" />
                <asp:Parameter Name="Original_TimeEntryDate" Type="DateTime" />
                <asp:Parameter Name="Original_AccountEmployeeId" Type="Int32" />
                <asp:Parameter Name="Original_TimeEntryStartDate" Type="Object" />
                <asp:Parameter Name="Original_TimeEntryEndDate" Type="Object" />
                <asp:Parameter Name="Original_TimeEntryViewType" Type="String" />
                <asp:Parameter Name="Original_AccountEmployeeTimeEntryApprovalProjectId" Type="Object" />
                <asp:Parameter Name="Original_AccountEmployeeTimeEntryPeriodId" Type="Object" />
            </UpdateParameters>
        <DeleteParameters>
            <asp:Parameter Name="Original_AccountEmployeeTimeEntryId" Type="Int32" />
            <asp:Parameter Name="Original_TimeEntryViewType" Type="Object" />
            <asp:Parameter Name="Original_AccountEmployeeId" Type="Int32" />
            <asp:Parameter Name="Original_TimeEntryStartDate" Type="Object" />
            <asp:Parameter Name="Original_TimeEntryEndDate" Type="Object" />
            <asp:Parameter Name="Original_AccountEmployeeTimeEntryApprovalProjectId" Type="Object" />
            <asp:Parameter Name="Original_AccountEmployeeTimeEntryPeriodId" Type="Object" />
            <asp:Parameter Name="Original_TimeEntryDate" Type="DateTime" />
            <asp:Parameter Name="Original_IsTimeOff" Type="Boolean" />
            <asp:Parameter Name="Original_AccountEmployeeTimeOffRequestId" Type="Object" />
        </DeleteParameters>
        </asp:ObjectDataSource>
    </ContentTemplate>
</asp:UpdatePanel>
