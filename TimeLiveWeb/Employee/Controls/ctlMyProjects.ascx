<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlMyProjects.ascx.vb" Inherits="AccountAdmin_Controls_ctlMyProjects" %>
<%@ Register Assembly="eWorld.UI"
    Namespace="eWorld.UI" TagPrefix="ew" %>
   
    <table><tr><td style="width: 100%; padding-bottom:5px;">
    
<ew:CollapsablePanel id="CollapsablePanelSearch" runat="server" Collapsed="True"
    ExpandText="Search" AllowSliding="True" AllowTitleExpandCollapse="True" 
    AllowTitleRowExpandCollapse="True" CollapserAlign="Left" 
    TitleStyle-CssClass="accordionHeader" TitleStyle-Font-Bold="True" 
    TitleVerticalAlignment="NotSet" Width="98%"  
    SlideLines="13" SlideSpeed="-100" style="margin-left:5px" 
    CollapseText="Search" >
    <table class="xFormView" width="98%"><tr><td>
        <table align="left" class="xFormView" style="width: 102%">
            <tr>
                <th class="FormViewSubHeader" colspan="4">
                    <asp:Literal ID="Literal2" runat="server" Text="<%$ Resources:TimeLive.Resource, Search Parameters%> " /></th>
            </tr>
            <tr>
                <td align="right" class="formviewlabelcell">
                   <asp:Literal ID="Literal1" runat="server" 
                        Text="<%$ Resources:TimeLive.Resource, Project Code:%> " />
                    <%--<asp:Literal ID="Literal7" runat="server" 
                       Text="<%$ Resources:TimeLive.Resource, Project Id:%> " />--%>
                </td>
                <td align="left">
                 <asp:TextBox ID="txtProjectCode" runat="server" ValidationGroup="TaskSearch" 
                        Width="174px"></asp:TextBox>
                   <%-- <asp:TextBox ID="txtAccountProjectId" runat="server" 
                        ValidationGroup="TaskSearch" Width="174px"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                        ControlToValidate="txtAccountProjectId" 
                        ErrorMessage="String Values Not Allowed" ValidationExpression="\d+"></asp:RegularExpressionValidator>--%>
                </td>
             
                 <td align="right" class="formviewlabelcell">
                    <asp:Literal ID="Literal5" runat="server" 
                        Text="<%$ Resources:TimeLive.Resource, Client Name:%> " />
                </td>
                <td align="left">
                    <asp:DropDownList ID="ddlAccountClientId" runat="server" 
                        AppendDataBoundItems="True" DataSourceID="dsAccountClientObject" 
                        DataTextField="PartyName" DataValueField="AccountPartyId" 
                        ValidationGroup="TaskSearch" Width="186px">
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
                   <asp:Literal ID="Literal9" runat="server" 
                        Text="<%$ Resources:TimeLive.Resource, Completed Status:%> " />
                   <%-- <asp:Literal ID="Literal6" runat="server" 
                        Text="<%$ Resources:TimeLive.Resource, Project Code:%> " />--%>
                </td>
                <td align="left">
                    <asp:DropDownList ID="ddlCompletedStatus" runat="server" 
                        AppendDataBoundItems="True" ValidationGroup="TaskSearch" Width="186px">
                        <asp:ListItem ID="Label336" runat="server" Label="" Selected="True" 
                            Text="<%$ Resources:TimeLive.Resource, All%> " Value="-1"></asp:ListItem>
                        <asp:ListItem ID="Label337" runat="server" Label="" 
                            Text="<%$ Resources:TimeLive.Resource, Completed Projects%> " Value="1"></asp:ListItem>
                        <asp:ListItem ID="Label338" runat="server" Label="" 
                            Text="<%$ Resources:TimeLive.Resource, Incomplete Projects%> " Value="0"></asp:ListItem>
                    </asp:DropDownList>
                    <%--<asp:TextBox ID="txtProjectCode" runat="server" ValidationGroup="TaskSearch" 
                        Width="174px"></asp:TextBox>--%>
                </td>
                <td align="right" class="formviewlabelcell">
                    <asp:Literal ID="Literal3" runat="server" 
                        Text="<%$ Resources:TimeLive.Resource, Project Status:%> " />
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
      <%--  <tr>
                <td align="right" class="formviewlabelcell">
                    <asp:Literal ID="Literal9" runat="server" 
                        Text="<%$ Resources:TimeLive.Resource, Completed Status:%> " />
                </td>
                <td align="left" >
                    <asp:DropDownList ID="ddlCompletedStatus" runat="server" 
                        AppendDataBoundItems="True" ValidationGroup="TaskSearch" Width="186px">
                        <asp:ListItem ID="Label336" runat="server" Label="" Selected="True" 
                            Text="<%$ Resources:TimeLive.Resource, All%> " Value="-1"></asp:ListItem>
                        <asp:ListItem ID="Label337" runat="server" Label="" 
                            Text="<%$ Resources:TimeLive.Resource, Completed Projects%> " Value="1"></asp:ListItem>
                        <asp:ListItem ID="Label338" runat="server" Label="" 
                            Text="<%$ Resources:TimeLive.Resource, Incomplete Projects%> " Value="0"></asp:ListItem>
                    </asp:DropDownList>
                </td>
                    <td align="right" class="formviewlabelcell">
                        &nbsp;</td>
                <td align="left">
                    &nbsp;</td>
            </tr>--%>
            <tr>
                <td align="right" class="formviewlabelcell">
                </td>
                <td align="left" class="formviewlabelcell" colspan="2" 
                    style="padding-bottom: 5px; padding-top: 5px;">
                    <asp:Button ID="btnShow" runat="server" style="width: 48px" 
                        Text="<%$ Resources:TimeLive.Resource, Show%> " />
                </td>
                <td align="left">
                    &nbsp;</td>
            </tr>
        </table>
        </td></tr></table>
    </ew:CollapsablePanel>
    </td></tr></table>
<asp:UpdatePanel ID="U" runat="server">
    <ContentTemplate>
<x:GridView ID="G" runat="server" AutoGenerateColumns="False" DataKeyNames="AccountProjectId,ProjectManagerEmployeeId,LeaderEmployeeId" ShowHeaderWhenEmpty = "True" EmptyDataText = "There are no items to display."
    DataSourceID="dsAccountProjectObject" SkinID="xgridviewSkinEmployee" AllowSorting="True" Caption='<%# ResourceHelper.GetFromResource("Project List") %>' Width="98%" OnDataBound="GridView1_DataBound">
    <Columns>
        <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Id %>" InsertVisible="False" SortExpression="AccountProjectId">
            <EditItemTemplate>
                <asp:Label ID="Label1" runat="server" Text='<%# Eval("AccountProjectId") %>'></asp:Label>
            
</EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="Label1" runat="server" Text='<%# Bind("AccountProjectId") %>' Visible='<%# not Eval("AccountProjectId") = 0 %>'></asp:Label>
            
</ItemTemplate>
            <ItemStyle HorizontalAlign="Center" Width="20px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Code %>" SortExpression="ProjectCode">
            <edititemtemplate>
<asp:TextBox id="TextBox1" runat="server" Text='<%# Bind("ProjectCode") %>' __designer:wfdid="w118"></asp:TextBox> 
</edititemtemplate>
            <headertemplate>
<asp:LinkButton id="LinkButton3" runat="server" Text='<%# ResourceHelper.GetFromResource("Code") %>' CommandArgument="ProjectCode" CommandName="Sort" CausesValidation="False"></asp:LinkButton>
</headertemplate>
            <itemtemplate>
<asp:Label id="L2" runat="server" Text='<%# Bind("ProjectCode") %>' __designer:wfdid="w117"></asp:Label> 
</itemtemplate>
            <itemstyle horizontalalign="Left" width="85px" />
        </asp:TemplateField>
        <asp:TemplateField SortExpression="ProjectName" HeaderText="<%$ Resources:TimeLive.Resource, Project Name %>">
            <headertemplate>
                <asp:LinkButton id="LinkButton11" runat="server" Text='<%# ResourceHelper.GetFromResource("Project Name") %>' CommandArgument="ProjectName" CommandName="Sort" CausesValidation="False"></asp:LinkButton> 
            </headertemplate>
            <itemtemplate>
                <asp:HyperLink id="HyperLink1" runat="server" Text='<%# Eval("ProjectName") %>' 
                onclick="window.open (this.href, 'popupwindow', 'width=700,height=275,left=300,top=300,scrollbars=yes'); return false;" NavigateUrl='<%# Eval("AccountProjectId", IIF(AccountPagePermissionBll.IsPageHasPermissionOf(28,3),"~/ProjectAdmin/AccountProjectAttachmentsPopUp.aspx?AccountProjectId={0}","~/ProjectAdmin/AccountProjectAttachmentsPopUp.aspx?AccountProjectId={0}" & "&AccountAttachmentTypeId=1")) %>' ></asp:HyperLink>
            </itemtemplate>
                <ItemStyle Width="160px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Client Name %>" SortExpression="PartyName">
            <edititemtemplate>
<asp:TextBox id="TextBox3" runat="server" Text='<%# Bind("PartyName") %>' __designer:wfdid="w124"></asp:TextBox> 
</edititemtemplate>
            <headertemplate>
<asp:LinkButton id="L5" runat="server" Text='<%# ResourceHelper.GetFromResource("Client Name") %>' CommandArgument="PartyName" CommandName="Sort" CausesValidation="False"></asp:LinkButton>
</headertemplate>
            <itemtemplate>
<asp:Label id="L4" runat="server" Text='<%# Bind("PartyName") %>' __designer:wfdid="w123"></asp:Label> 
</itemtemplate>
            <itemstyle horizontalalign="Left" width="170px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Description %>" SortExpression="ProjectDescription">
            <headertemplate>
<asp:LinkButton id="LinkButton6" runat="server" Text='<%# ResourceHelper.GetFromResource("Description") %>' CommandArgument="ProjectDescription" CommandName="Sort" CausesValidation="False"></asp:LinkButton>
</headertemplate>
            <ItemTemplate>
<asp:Label id="D" runat="server" __designer:wfdid="w2" Text='<%# Eval("ProjectDescription") %>'></asp:Label>
</ItemTemplate>
            <ItemStyle Width="320px" />
        </asp:TemplateField>
         <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Status %>" 
                    SortExpression="Status">
                    <edititemtemplate>
                        <asp:TextBox ID="TextBox2" runat="server" __designer:wfdid="w96" 
                            Text='<%# Bind("ProjectStatus") %>'></asp:TextBox>
                    </edititemtemplate>
                    <headertemplate>
                        <asp:LinkButton ID="LinkButton7" runat="server" CausesValidation="False" 
                            CommandArgument="Status" CommandName="Sort" 
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
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Gantt %>">
            <headertemplate>
<asp:Label id="lblTaskGantt" runat="server" __designer:wfdid="w16" Text='<%# ResourceHelper.GetFromResource("Gantt") %>'></asp:Label> 
</headertemplate>
            <ItemTemplate>
 <asp:HyperLink ID="HyperLinkGantt" runat="server" NavigateUrl='<%# Eval("AccountProjectId", "~/ProjectAdmin/AccountProjectTaskGantt.aspx?AccountProjectId={0}&Source=MyProjects") %>'
                    Text='<%# ResourceHelper.GetFromResource("Gantt") %>'></asp:HyperLink>
</ItemTemplate>
            <HeaderStyle Width="10px" />
            <ItemStyle Width="10px" HorizontalAlign="Center" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Task %>">
            <headertemplate>
<asp:Label id="lblTask" runat="server" __designer:wfdid="w16" Text='<%# ResourceHelper.GetFromResource("Task") %>'></asp:Label> 
</headertemplate>
            <ItemTemplate>
<asp:HyperLink id="H2" runat="server" __designer:wfdid="w128" 
                    NavigateUrl='<%# Eval("AccountProjectId", "~/ProjectAdmin/AccountProjectTasks.aspx?AccountProjectId={0}&Source=MyProjects") %>' 
                    Text='<%# ResourceHelper.GetFromResource("Task") %>'></asp:HyperLink> 
</ItemTemplate>
            <HeaderStyle Width="10px" />
            <ItemStyle Width="10px" HorizontalAlign="Center" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Manage %>">
            <headertemplate>
<asp:Label id="lblManage" runat="server" __designer:wfdid="w18" Text='<%# ResourceHelper.GetFromResource("Manage") %>'></asp:Label> 
</headertemplate>
            <ItemTemplate>
<asp:HyperLink id="H1" runat="server" NavigateUrl='<%# "~/ProjectAdmin/ProjectAdmin.aspx?AccountProjectId=" & Eval("AccountProjectId") & "&Source=MyProjects" %>' __designer:wfdid="w13" ToolTip="<%$ Resources:TimeLive.Resource, Manage Project %>" ImageUrl="~/Images/ProjectAdmin.gif" Visible="False">[HyperLink1]</asp:HyperLink> 
</ItemTemplate>
            <ControlStyle Width="45px" />
            <HeaderStyle Width="10px" />
            <ItemStyle Width="10px" HorizontalAlign="Center" />
        </asp:TemplateField>
        <asp:TemplateField>
            <ItemTemplate>
<asp:HyperLink id="H3" runat="server" NavigateUrl='<%# Eval("AccountProjectId", "~/ProjectAdmin/AccountEMailNotificationPreferences.aspx?AccountProjectId={0}&Source=MyProjects") %>' Visible='<%# IIF(Eval("AccountProjectId")=0,False,True) %>' __designer:wfdid="w10" Text="EMail Preference" ToolTip="<%$ Resources:TimeLive.Resource, EMail Preference%> " ImageUrl="~/Images/Preferences.gif"></asp:HyperLink> 
</ItemTemplate>
        <ItemStyle HorizontalAlign="Center" Width="10px" />
        </asp:TemplateField>
    </Columns>
</x:GridView>
<asp:ObjectDataSource ID="dsAccountProjectObject" runat="server" OldValuesParameterFormatString="original_{0}"
    SelectMethod="GetAssignedAccountProjectsByAccountEmployeeId" 
            TypeName="AccountProjectBLL" DeleteMethod="DeleteAccountProject" 
            InsertMethod="AddAccountProject" UpdateMethod="UpdateProjectDescription">
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
        <asp:Parameter Name="IsWebServiceCall" Type="Boolean" />
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
        <asp:SessionParameter DefaultValue="39" Name="AccountEmployeeId" SessionField="AccountEmployeeId"
            Type="Int32" />
        <asp:Parameter Name="Completed" Type="String" DefaultValue="0"/>
        <asp:Parameter Name="ProjectStatusId" Type="Int32" />
        <asp:Parameter Name="Disabled" Type="String" DefaultValue="1"/>
        <asp:Parameter Name="AccountClientId" Type="Int32" />
        <asp:Parameter Name="AccountProjectId" Type="Int32" />
        <asp:Parameter Name="ProjectCode" Type="String" />
    </SelectParameters>
    <UpdateParameters>
        <asp:Parameter Name="ProjectDescription" Type="String" />
        <asp:Parameter Name="Original_AccountProjectId" Type="Int32" />
    </UpdateParameters>
</asp:ObjectDataSource>
        
    </ContentTemplate>
</asp:UpdatePanel>
    <asp:ObjectDataSource ID="dsAccountStatus" runat="server" DeleteMethod="DeleteAccountStatus"
            InsertMethod="AddAccountStatus" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetAccountsStatusForTask" 
    TypeName="AccountStatusBLL" UpdateMethod="UpdateAccountStatus">
            <DeleteParameters>
                <asp:Parameter Name="Original_AccountStatusId" Type="Int32" />
            </DeleteParameters>
            <SelectParameters>
                <asp:SessionParameter DefaultValue="64" Name="AccountId" SessionField="AccountId"
                    Type="Int32" />
            </SelectParameters>
            <InsertParameters>
                <asp:Parameter Name="AccountId" Type="Int32" />
                <asp:Parameter Name="Status" Type="String" />
                <asp:Parameter Name="StatusTypeId" Type="Int32" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="AccountId" Type="Int32" />
                <asp:Parameter Name="Status" Type="String" />
                <asp:Parameter Name="StatusTypeId" Type="Int32" />
                <asp:Parameter Name="Original_AccountStatusId" Type="Int32" />
                <asp:Parameter Name="IsDisabled" Type="Boolean" />
            </UpdateParameters>
        </asp:ObjectDataSource>
    