<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlAccountProjectList.ascx.vb" Inherits="AccountAdmin_Controls_ctlAccountProjectList" %>
<%@ Register Assembly="eWorld.UI"
    Namespace="eWorld.UI" TagPrefix="ew" %>
    <script type="text/javascript">
        function ChangeCheckBoxState(id, checkState) {
            var cb = document.getElementById(id);
            if (cb != null)
                cb.checked = checkState;
        }

        function ChangeAllCheckBoxStates(checkState) {
            // Toggles through all of the checkboxes defined in the CheckBoxIDs array
            // and updates their value to the checkState input parameter
            if (CheckBoxIDs != null) {
                for (var i = 0; i < CheckBoxIDs.length; i++)
                    ChangeCheckBoxState(CheckBoxIDs[i], checkState);
            }
        }

        function ChangeHeaderAsNeeded() {
            // Whenever a checkbox in the GridView is toggled, we need to
            // check the Header checkbox if ALL of the GridView checkboxes are
            // checked, and uncheck it otherwise
            if (CheckBoxIDs != null) {
                // check to see if all other checkboxes are checked
                for (var i = 1; i < CheckBoxIDs.length; i++) {
                    var cb = document.getElementById(CheckBoxIDs[i]);
                    if (!cb.checked) {
                        // Whoops, there is an unchecked checkbox, make sure
                        // that the header checkbox is unchecked
                        ChangeCheckBoxState(CheckBoxIDs[0], false);
                        return;
                    }
                }

                // If we reach here, ALL GridView checkboxes are checked
                ChangeCheckBoxState(CheckBoxIDs[0], true);
            }
        }
    </script>
    <table><tr><td style="width: 100%; padding-bottom:5px;">
  
    <ew:CollapsablePanel id="CollapsablePanelSearch" runat="server" Collapsed="True"
    ExpandText="Search" AllowSliding="True" AllowTitleExpandCollapse="True" 
    AllowTitleRowExpandCollapse="True" CollapserAlign="Left" 
    TitleStyle-CssClass="accordionHeader" TitleStyle-Font-Bold="True" 
    TitleVerticalAlignment="NotSet" Width="98%"  
    SlideLines="13" SlideSpeed="-100" style="margin-left:5px" 
    CollapseText="Search" >
    <table class="xFormView" width="99%" ><tr><td>
        <table align="left" class="xFormView" style="width: 101%">
            <tr>
                <th class="FormViewSubHeader" colspan="4">
                    <asp:Literal ID="Literal2" runat="server" Text="<%$ Resources:TimeLive.Resource, Search Parameters%> " /></th>
            </tr>
            <tr>
                      <td align="right" class="formviewlabelcell">
                             <asp:Literal ID="Literal6" runat="server" 
                        Text="<%$ Resources:TimeLive.Resource, Project Code:%> " /></td>
                <td align="left">
                 <asp:TextBox ID="txtProjectCode" runat="server" ValidationGroup="TaskSearch" 
                        Width="174px"></asp:TextBox>
                 
                </td>
                  <td align="right" class="formviewlabelcell">
                    <asp:Literal ID="Literal5" runat="server" 
                        Text="<%$ Resources:TimeLive.Resource, Client Name:%> " />
                </td>
                <td align="left">
                    <asp:DropDownList ID="ddlAccountClientId" runat="server" 
                        AppendDataBoundItems="True" ValidationGroup="TaskSearch" Width="186px" 
                        DataSourceID="dsAccountClientObject" DataTextField="PartyName" 
                        DataValueField="AccountPartyId">
                        <asp:ListItem ID="Label325" runat="server" Label="" Selected="True" 
                            Text="<%$ Resources:TimeLive.Resource, All%> " Value="0"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:ObjectDataSource ID="dsAccountClientObject" runat="server" 
                        DeleteMethod="DeleteAccountParty" InsertMethod="AddAccountParty" 
                        OldValuesParameterFormatString="original_{0}" 
                        SelectMethod="GetAccountPartiesByAccountId" TypeName="AccountPartyBLL" 
                        UpdateMethod="UpdateAccountParty">
                        <DeleteParameters>
                            <asp:Parameter Name="original_AccountPartyId" Type="Int32" />
                        </DeleteParameters>
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
                            <asp:Parameter Name="DefaultBillingRate" Type="Decimal" />
                            <asp:Parameter Name="Website" Type="String" />
                            <asp:Parameter Name="Notes" Type="String" />
                            <asp:Parameter Name="IsDisabled" Type="Boolean" />
                            <asp:Parameter Name="IsDeleted" Type="Boolean" />
                            <asp:Parameter Name="CreatedOn" Type="DateTime" />
                            <asp:Parameter Name="CreatedByEmployeeId" Type="Int32" />
                            <asp:Parameter Name="ModifiedOn" Type="DateTime" />
                            <asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" />
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
                            <asp:SessionParameter Name="AccountId" SessionField="AccountId" Type="Int32" />
                        </SelectParameters>
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
                    </asp:ObjectDataSource>
                </td>
            </tr>
            <tr>
                <td align="right" class="formviewlabelcell">
                   <asp:Literal ID="Literal4" runat="server" 
                        Text="<%$ Resources:TimeLive.Resource, Completed Status:%> " />
                  
                </td>
                <td align="left">
                <asp:DropDownList ID="ddlCompletedStatus" runat="server" 
                        AppendDataBoundItems="True" ValidationGroup="TaskSearch" Width="186px">
                        <asp:ListItem ID="Label333" runat="server" Label="" Selected="True" 
                            Text="<%$ Resources:TimeLive.Resource, All%> " Value="-1"></asp:ListItem>
                      
                        <asp:ListItem ID="Label8" runat="server" Label="" 
                            Text="<%$ Resources:TimeLive.Resource, Completed Projects%> " Value="1"></asp:ListItem>
                      
                        <asp:ListItem ID="Label9" runat="server" Label="" 
                            Text="<%$ Resources:TimeLive.Resource, Incomplete Projects%> " Value="0"></asp:ListItem>
                    </asp:DropDownList>
                
                </td>
              
                <td align="right" class="formviewlabelcell">
                    <asp:Literal ID="Literal3" runat="server" 
                        Text="<%$ Resources:TimeLive.Resource, Project Status: %>" />
                </td>
                <td align="left">
                    <asp:DropDownList ID="ddlProjectStatus" runat="server" 
                        AppendDataBoundItems="True" ValidationGroup="TaskSearch" Width="186px" 
                        DataSourceID="dsAccountProjectStatusobj" DataTextField="Status" 
                        DataValueField="AccountStatusId">
                        <asp:ListItem ID="Label7" runat="server" Label="" Selected="True" 
                            Text="<%$ Resources:TimeLive.Resource, All%> " Value="0"></asp:ListItem>
                                          </asp:DropDownList>
                    <asp:ObjectDataSource ID="dsAccountProjectStatusobj" runat="server" 
                        DeleteMethod="DeleteAccountStatus" InsertMethod="AddAccountStatus" 
                        OldValuesParameterFormatString="original_{0}" 
                        SelectMethod="GetAccountsStatusForProject" TypeName="AccountStatusBLL" 
                        UpdateMethod="UpdateAccountStatus">
                        <DeleteParameters>
                            <asp:Parameter Name="Original_AccountStatusId" Type="Int32" />
                        </DeleteParameters>
                        <InsertParameters>
                            <asp:Parameter Name="AccountId" Type="Int32" />
                            <asp:Parameter Name="Status" Type="String" />
                            <asp:Parameter Name="StatusTypeId" Type="Int32" />
                        </InsertParameters>
                        <SelectParameters>
                            <asp:SessionParameter Name="AccountId" SessionField="AccountId" Type="Int32" />
                        </SelectParameters>
                        <UpdateParameters>
                            <asp:Parameter Name="AccountId" Type="Int32" />
                            <asp:Parameter Name="Status" Type="String" />
                            <asp:Parameter Name="StatusTypeId" Type="Int32" />
                            <asp:Parameter Name="Original_AccountStatusId" Type="Int32" />
                            <asp:Parameter Name="IsDisabled" Type="Boolean" />
                        </UpdateParameters>
                    </asp:ObjectDataSource>
                </td>
            </tr>
      
            <tr>
                <td align="right" class="formviewlabelcell">
                </td>
                <td align="left" class="formviewlabelcell" colspan="2" style="padding-bottom: 5px; padding-top: 5px;" >
                    <asp:Button ID="btnShow" runat="server" Text="Show" style="width: 48px" /></td>
                <td align="left">
                </td>
            </tr>
        </table>
        </td></tr></table>
    </ew:CollapsablePanel>
    </td></tr></table>
    
                <x:GridView ID="GridView1" runat="server" AllowSorting="True" 
                    AutoGenerateColumns="False" 
                    Caption='<%# ResourceHelper.GetFromResource("Project List") %>' 
                    DataKeyNames="AccountProjectId" DataSourceID="dsAccountProjectObject" 
                    OnRowDeleted="GridView1_RowDeleted" SkinID="xgridviewSkinEmployee" 
                    Visible="False" Width="98%">
                    <Columns>
                        <asp:BoundField DataField="AccountProjectId" 
                            HeaderText="<%$ Resources:TimeLive.Resource, Id %>" InsertVisible="False" 
                            ReadOnly="True" SortExpression="AccountProjectId">
                        <ItemStyle HorizontalAlign="Center" Width="7%" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Code %>" SortExpression="ProjectCode">
                            <edititemtemplate>
                                <asp:TextBox ID="TextBox1" runat="server" __designer:wfdid="w105" 
                                    Text='<%# Bind("ProjectCode") %>'></asp:TextBox>
                            </edititemtemplate>
                            <headertemplate>
                                <asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="False" 
                                    CommandArgument="ProjectCode" CommandName="Sort" 
                                    Text='<%# ResourceHelper.GetFromResource("Code") %>'></asp:LinkButton>
                            </headertemplate>
                            <itemtemplate>
                                <asp:Label ID="Label1" runat="server" __designer:wfdid="w104" 
                                    Text='<%# Bind("ProjectCode") %>'></asp:Label>
                            </itemtemplate>
                            <itemstyle horizontalalign="Left" width="10%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Project Name %>" SortExpression="ProjectName">
                            <edititemtemplate>
                                <asp:TextBox ID="TextBox2" runat="server" __designer:wfdid="w108" 
                                    Text='<%# Bind("ProjectName") %>'></asp:TextBox>
                            </edititemtemplate>
                            <headertemplate>
                                <asp:LinkButton ID="LinkButton4" runat="server" CausesValidation="False" 
                                    CommandArgument="ProjectName" CommandName="Sort" 
                                    Text='<%# ResourceHelper.GetFromResource("Project Name") %>'></asp:LinkButton>
                            </headertemplate>
                            <itemtemplate>
                                <asp:Label ID="Label2" runat="server" __designer:wfdid="w107" 
                                    Text='<%# Bind("ProjectName") %>'></asp:Label>
                            </itemtemplate>
                            <itemstyle horizontalalign="Left" width="30%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Client Name %>" SortExpression="PartyName">
                            <edititemtemplate>
                                <asp:TextBox ID="TextBox3" runat="server" __designer:wfdid="w111" 
                                    Text='<%# Bind("PartyName") %>'></asp:TextBox>
                            </edititemtemplate>
                            <headertemplate>
                                <asp:LinkButton ID="LinkButton5" runat="server" CausesValidation="False" 
                                    CommandArgument="PartyNick" CommandName="Sort" 
                                    Text='<%# ResourceHelper.GetFromResource("Client Name") %>'></asp:LinkButton>
                            </headertemplate>
                            <itemtemplate>
                                <asp:Label ID="Label3" runat="server" __designer:wfdid="w110" 
                                    Text='<%# Bind("PartyName") %>'></asp:Label>
                            </itemtemplate>
                            <itemstyle horizontalalign="Left" width="12%" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="PartyDepartmentName" HeaderText="Client Department" 
                            SortExpression="PartyDepartmentName" />
                        <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Start Date %>" SortExpression="StartDate">
                            <edititemtemplate>
                                <asp:TextBox ID="TextBox4" runat="server" __designer:wfdid="w115" 
                                    Text='<%# Bind("StartDate") %>'></asp:TextBox>
                            </edititemtemplate>
                            <headertemplate>
                                <asp:LinkButton ID="LinkButton6" runat="server" CausesValidation="False" 
                                    CommandArgument="StartDate" CommandName="Sort" 
                                    Text='<%# ResourceHelper.GetFromResource("Start Date") %>'></asp:LinkButton>
                            </headertemplate>
                            <itemtemplate>
                                <asp:Label ID="Label4" runat="server" __designer:wfdid="w114" 
                                    Text='<%# Bind("StartDate", "{0:d}") %>'></asp:Label>
                            </itemtemplate>
                            <itemstyle horizontalalign="Center" width="10%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Status %>" 
                    SortExpression="Status">
                    <edititemtemplate>
                        <asp:TextBox ID="TextBox2" runat="server" __designer:wfdid="w96" 
                            Text='<%# Bind("ProjectStatus") %>'></asp:TextBox>
                    </edititemtemplate>
                    <headertemplate>
                        <asp:LinkButton ID="LinkButton7" runat="server" CausesValidation="False" 
                            CommandArgument="ProjectStatus" CommandName="Sort" 
                            Text='<%# ResourceHelper.GetFromResource("Status") %>'></asp:LinkButton>
                    </headertemplate>
                    <itemtemplate>
                        <asp:Label ID="Label20" runat="server" __designer:wfdid="w94" 
                            Text='<%# Bind("Status") %>'></asp:Label>
                        &nbsp;<asp:Label ID="Label332" runat="server" __designer:wfdid="w95" 
                            visible='<%# IIF(Eval("AccountProjectId") = 0,False,True)%>'></asp:Label>
                    </itemtemplate>
                    <itemstyle width="10%" />
                </asp:TemplateField>
                        <asp:CommandField HeaderText="<%$ Resources:TimeLive.Resource, Edit_text %>" 
                            SelectText="Edit" ShowSelectButton="True">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle cssclass="edit_button" HorizontalAlign="Center" Width="1%" />
                        </asp:CommandField>
                        <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Delete_text %>" 
                            ShowHeader="False">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" 
                                    CommandName="Delete" 
                                    OnClientClick="<%# ResourceHelper.GetDeleteMessageJavascript()%>" />
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle cssclass="delete_button" HorizontalAlign="Center" Width="1%" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:HyperLink ID="HyperLink5" runat="server" 
                                    NavigateUrl='<%# Eval("AccountProjectId",IIf(me.request.querystring("IsTemplate") is nothing,"~/ProjectAdmin/AccountProjectTaskGantt.aspx?AccountProjectId={0}","~/ProjectAdmin/AccountProjectTaskGantt.aspx?AccountProjectId={0}&IsTemplate=True&Source=ProjectTemplates")) %>' 
                                    Text='<%# ResourceHelper.GetFromResource("Gantt") %>'></asp:HyperLink>
                            </ItemTemplate>
                            <ItemStyle Width="3%" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:HyperLink ID="HyperLink2" runat="server" 
                                    NavigateUrl='<%# Eval("AccountProjectId",IIf(me.request.querystring("IsTemplate") is nothing,"~/ProjectAdmin/AccountProjectTasks.aspx?AccountProjectId={0}","~/ProjectAdmin/AccountProjectTasks.aspx?AccountProjectId={0}&IsTemplate=True&Source=ProjectTemplates")) %>' 
                                    Text='<%# ResourceHelper.GetFromResource("Tasks") %>'></asp:HyperLink>
                            </ItemTemplate>
                            <ItemStyle Width="3%" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:HyperLink ID="HyperLink4" runat="server" 
                                    NavigateUrl='<%# Eval("AccountProjectId",IIf(me.request.querystring("IsTemplate") is nothing,"~/ProjectAdmin/AccountProjectEmployees.aspx?AccountProjectId={0}&Selected=True","~/ProjectAdmin/AccountProjectEmployees.aspx?AccountProjectId={0}&IsTemplate=True&Source=ProjectTemplates&Selected=True")) %>' 
                                    Text='<%# ResourceHelper.GetFromResource("Team") %>'></asp:HyperLink>
                            </ItemTemplate>
                            <ItemStyle Width="3%" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:HyperLink ID="HyperLink3" runat="server" 
                                    NavigateUrl='<%# Eval("AccountProjectId", IIF(Me.Request.QueryString("IsTemplate") is Nothing,"~/ProjectAdmin/AccountProjectMilestones.aspx?AccountProjectId={0}","~/ProjectAdmin/AccountProjectMilestones.aspx?AccountProjectId={0}&IsTemplate=True&Source=ProjectTemplates")) %>' 
                                    Text='<%# ResourceHelper.GetFromResource("Milestones") %>'></asp:HyperLink>
                            </ItemTemplate>
                            <ItemStyle Width="5%" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:HyperLink ID="HyperLinkAttachment" runat="server" __designer:wfdid="w46" 
                                    NavigateUrl='<%# "~/ProjectAdmin/AccountProjectAttachmentsPopUp.aspx?AccountProjectId=" & DataBinder.Eval(Container.DataItem,"AccountProjectId") & "&AccountAttachmentTypeId=1"%>' 
                                    onclick="window.open (this.href, 'popupwindow', 'width=700,height=275,left=300,top=300,scrollbars=yes'); return false;">
                <asp:Literal ID="Literal1" runat="server" 
                    Text="<%$ Resources:TimeLive.Resource, Attachment%> " /></asp:HyperLink></ItemTemplate><ItemStyle 
                                HorizontalAlign="Left" Width="1%" /></asp:TemplateField><asp:TemplateField><ItemTemplate><asp:HyperLink 
                                ID="HyperLink1" runat="server" ImageUrl="~/Images/Preferences.gif" 
                                NavigateUrl='<%# Eval("AccountProjectId", IIF(Me.Request.QueryString("IsTemplate") Is Nothing,"~/ProjectAdmin/AccountEMailNotificationPreferences.aspx?AccountProjectId={0}","~/ProjectAdmin/AccountEMailNotificationPreferences.aspx?AccountProjectId={0}&IsTemplate=True&Source=ProjectTemplates")) %>' 
                                Text="EMail Preference" 
                                ToolTip="<%$ Resources:TimeLive.Resource, EMail Preference%> "></asp:HyperLink></ItemTemplate><ItemStyle 
                                Width="1%" /></asp:TemplateField><asp:TemplateField><HeaderTemplate><asp:Image 
                                ID="Image1" runat="server" ImageUrl="~/Images/Disabled.gif" 
                                ToolTip="<%$ Resources:TimeLive.Resource, Disabled_text%> " /></HeaderTemplate><ItemTemplate><asp:Image 
                                    ID="Image1" runat="server" ImageUrl="~/Images/Disabled.gif" 
                                    ToolTip="<%$ Resources:TimeLive.Resource, Disabled_text%> " 
                                    Visible='<%# IIF(IsDBNull(Eval("IsDisabled")),"false",Eval("IsDisabled")) %>' /></ItemTemplate><ItemStyle 
                                HorizontalAlign="Center" Width="1%" /></asp:TemplateField><asp:TemplateField><HeaderTemplate><asp:CheckBox 
                                ID="chkCheckAll" runat="server" Width="15px" /></HeaderTemplate><ItemTemplate><asp:CheckBox 
                                    ID="chkSelect" runat="server" Width="15px" /></ItemTemplate><HeaderStyle 
                                HorizontalAlign="Center" VerticalAlign="Middle" Width="15px" /><ItemStyle 
                                HorizontalAlign="Center" VerticalAlign="Middle" Width="1%" /></asp:TemplateField></Columns></x:GridView>
<table 
                    style="width: 98%"><tr>
                    <td align="left"><div style="margin:5px; padding-top:5px;">
<% If AccountPagePermissionBLL.IsPageHasPermissionOf(31, 2) = True Then%>
                    <asp:Button 
                            ID="btnAddProject" runat="server" OnClick="btnAddProject_Click1" 
                            Text="<%$ Resources:TimeLive.Resource, Add_text %>" UseSubmitBehavior="False" 
                            Width="75px" />
                            <%End IF%>
<% If AccountPagePermissionBLL.IsPageHasPermissionOf(31, 4) = True Then %>
                            &nbsp;<asp:Button ID="btnDeleteSelectedItem" runat="server" 
                            OnClick="btnDeleteSelectedItem_Click" 
                            Text="Delete Selected" Visible="False" 
                            Width="90px" />
<% End If%>
                        <asp:ObjectDataSource ID="dsAccountProjectObject" 
                            runat="server" DeleteMethod="DeleteAccountProject" 
                            SelectMethod ="GetAccountProjectsForGridView" OldValuesParameterFormatString="original_{0}" 
                            TypeName="AccountProjectBLL" InsertMethod="AddAccountProject"><DeleteParameters><asp:Parameter 
                                    Name="Original_AccountProjectId" Type="Int32" /></DeleteParameters>
                                    <InsertParameters><asp:Parameter Name="AccountId" Type="Int32" /><asp:Parameter 
                                    Name="AccountProjectTypeId" Type="Int32" /><asp:Parameter 
                                    Name="AccountClientId" Type="Int32" /><asp:Parameter 
                                    Name="AccountPartyContactId" Type="Int32" /><asp:Parameter 
                                    Name="AccountPartyDepartmentId" Type="Int32" /><asp:Parameter 
                                    Name="ProjectBillingTypeId" Type="Int32" /><asp:Parameter 
                                    Name="ProjectName" Type="String" /><asp:Parameter Name="ProjectDescription" 
                                    Type="String" /><asp:Parameter Name="StartDate" Type="DateTime" /><asp:Parameter 
                                    Name="Deadline" Type="DateTime" /><asp:Parameter Name="ProjectStatusId" 
                                    Type="Int32" /><asp:Parameter Name="LeaderEmployeeId" Type="Int32" /><asp:Parameter 
                                    Name="ProjectManagerEmployeeId" Type="Int32" /><asp:Parameter 
                                    Name="TimeSheetApprovalTypeId" Type="Int32" /><asp:Parameter 
                                    Name="ExpenseApprovalTypeId" Type="Int32" /><asp:Parameter 
                                    Name="EstimatedDuration" Type="Double" /><asp:Parameter 
                                    Name="EstimatedDurationUnit" Type="String" /><asp:Parameter 
                                    Name="ProjectCode" Type="String" /><asp:Parameter Name="DefaultBillingRate" 
                                    Type="Decimal" /><asp:Parameter Name="ProjectBillingRateTypeId" 
                                    Type="Int32" /><asp:Parameter Name="IsTemplate" Type="Boolean" /><asp:Parameter 
                                    Name="IsProject" Type="Boolean" /><asp:Parameter 
                                    Name="AccountProjectTemplateId" Type="Int32" /><asp:Parameter 
                                    Name="CreatedOn" Type="DateTime" /><asp:Parameter 
                                    Name="CreatedByEmployeeId" Type="Int32" /><asp:Parameter Name="ModifiedOn" 
                                    Type="DateTime" /><asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" /><asp:Parameter 
                                    Name="Completed" Type="Boolean" /><asp:Parameter Name="ProjectPrefix" 
                                    Type="String" /><asp:Parameter Name="IsForAllClientProject" 
                                    Type="Boolean" /><asp:Parameter Name="ProjectEstimatedCost" Type="Double" /><asp:Parameter 
                                    Name="FixedCost" Type="Double" /><asp:Parameter Name="IsWebServiceCall" 
                                    Type="Boolean" /><asp:Parameter Name="CustomField1" Type="String" /><asp:Parameter 
                                    Name="CustomField2" Type="String" /><asp:Parameter Name="CustomField3" 
                                    Type="String" /><asp:Parameter Name="CustomField4" Type="String" /><asp:Parameter 
                                    Name="CustomField5" Type="String" /><asp:Parameter Name="CustomField6" 
                                    Type="String" /><asp:Parameter Name="CustomField7" Type="String" /><asp:Parameter 
                                    Name="CustomField8" Type="String" /><asp:Parameter Name="CustomField9" 
                                    Type="String" /><asp:Parameter Name="CustomField10" Type="String" /><asp:Parameter 
                                    Name="CustomField11" Type="String" /><asp:Parameter Name="CustomField12" 
                                    Type="String" /><asp:Parameter Name="CustomField13" Type="String" /><asp:Parameter 
                                    Name="CustomField14" Type="String" /><asp:Parameter Name="CustomField15" 
                                    Type="String" /></InsertParameters><SelectParameters><asp:SessionParameter 
                                    DefaultValue="64" Name="AccountId" SessionField="AccountId" Type="Int32" /><asp:QueryStringParameter 
                                    DefaultValue="False" Name="IsTemplate" QueryStringField="IsTemplate" 
                                    Type="Boolean" /><asp:ControlParameter ControlID="ddlCompletedStatus" 
                                    Name="Completed" PropertyName="SelectedValue" Type="String" />
                                <asp:Parameter Name="ProjectStatusId" Type="Int32" />
                                <asp:Parameter Name="Disabled" Type="String" />
                                <asp:Parameter Name="AccountClientId" Type="Int32" />
                                <asp:Parameter Name="AccountProjectId" Type="Int32" />
                                <asp:Parameter Name="ProjectCode" Type="String" />
                               
                                <asp:Parameter 
                                    Name="IsProjectAdd" Type="Boolean" /></SelectParameters></asp:ObjectDataSource></div></td></tr></table>
<%--</ContentTemplate>
</asp:UpdatePanel>--%>
