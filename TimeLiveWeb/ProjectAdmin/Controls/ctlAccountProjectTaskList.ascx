<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlAccountProjectTaskList.ascx.vb" Inherits="AccountAdmin_Controls_ctlAccountProjectTaskList" %>
<%@ Register Assembly="eWorld.UI"
    Namespace="eWorld.UI" TagPrefix="ew" %>
        <x:GridView ID="GridView1" runat="server" AllowSorting="True" 
            AutoGenerateColumns="False" 
            Caption='<%# ResourceHelper.GetFromResource("Project Task List") %>' 
            DataKeyNames="AccountProjectTaskId" 
            DataSourceID="AccountProjectTaskHierarchyObject" 
            OnDataBound="GridView1_DataBound" OnRowDeleted="GridView1_RowDeleted" 
            SkinID="xgridviewSkinEmployee" Width="98%">
            <Columns>
                <asp:BoundField DataField="AccountProjectTaskId" 
                    HeaderText="<%$ Resources:TimeLive.Resource, Id %>" 
                    SortExpression="AccountProjectTaskId">
                <HeaderStyle HorizontalAlign="Left" />
                <ItemStyle HorizontalAlign="Left" Width="1%" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Task Code %>" SortExpression="TaskCode">
                    <edititemtemplate>
                        <asp:TextBox ID="TextBox4" runat="server" __designer:wfdid="w26" 
                            Text='<%# Bind("TaskCode") %>'></asp:TextBox>
                    </edititemtemplate>
                    <headertemplate>
                        <asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="False" 
                            CommandArgument="TaskCode" CommandName="Sort" 
                            Text='<%# ResourceHelper.GetFromResource("Task Code") %>'></asp:LinkButton>
                    </headertemplate>
                    <itemtemplate>
                        <asp:Label ID="Label2" runat="server" __designer:wfdid="w25" 
                            Text='<%# Bind("TaskCode") %>'></asp:Label>
                    </itemtemplate>
                    <itemstyle horizontalalign="Center" verticalalign="Middle" width="8%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Task Name %>" 
                    SortExpression="TaskName">
                    <headertemplate>
                        <asp:LinkButton ID="LinkButton120" runat="server" __designer:wfdid="w3" 
                            CausesValidation="False" CommandArgument="TaskName" CommandName="Sort" 
                            Text='<%# ResourceHelper.GetFromResource("Task Name") %>'></asp:LinkButton></headertemplate>
                    <ItemTemplate>
                        <table cellpadding="0" cellspacing="0" class="xTableWithoutBorder">
                            <tr>
              <%--  <td>
                </td>--%>
                                <td <%#IIf(DataBinder.Eval(Container.DataItem, "IsParentTask"),"class=ParentTaskStyle","")%>>
                                    <asp:Image ID="Image9" runat="server" ImageUrl="~/Images/clearpixel.gif" 
                                        width='<%#Int32.Parse(DataBinder.Eval(Container.DataItem, "Depth")) * 20 %>' />
            <%#DataBinder.Eval(Container.DataItem, "TaskName")%>
            
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle Width="44%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Client Name %>" SortExpression="PartyName">
                    <edititemtemplate>
                        <asp:TextBox ID="txtPartyName" runat="server" __designer:wfdid="w26" 
                            Text='<%# Bind("PartyName") %>'></asp:TextBox>
                    </edititemtemplate>
                    <headertemplate>
                        <asp:LinkButton ID="lnkPartyName" runat="server" CausesValidation="False" 
                            CommandArgument="PartyName" CommandName="Sort" 
                            Text='<%# ResourceHelper.GetFromResource("Client Name") %>'></asp:LinkButton>
                    </headertemplate>
                    <itemtemplate>
                        <asp:Label ID="lblPartyName" runat="server" __designer:wfdid="w25" 
                            Text='<%# Bind("PartyName") %>'></asp:Label>
                    </itemtemplate>
                    <itemstyle verticalalign="Middle" width="1%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Project Name %>"  SortExpression="ProjectName">
                    <edititemtemplate>
                        <asp:TextBox ID="txtProjectName" runat="server" __designer:wfdid="w26" 
                            Text='<%# Bind("ProjectName") %>'></asp:TextBox>
                    </edititemtemplate>
                    <headertemplate>
                        <asp:LinkButton ID="lnkProjectName" runat="server" CausesValidation="False" 
                            CommandArgument="ProjectName" CommandName="Sort" 
                            Text='<%# ResourceHelper.GetFromResource("Project Name") %>'></asp:LinkButton>
                    </headertemplate>
                    <itemtemplate>
                        <asp:Label ID="lblProjectName" runat="server" __designer:wfdid="w25" 
                            Text='<%# Bind("ProjectName") %>'></asp:Label>
                    </itemtemplate>
                    <itemstyle verticalalign="Middle" width="2%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Assigned By %>" 
                    SortExpression="CreatedByFirstName">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" 
                            Text='<%# Bind("CreatedByFirstName") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("CreatedByFirstName") %>'></asp:Label>
                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("CreatedByLastName") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="10%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Start Date %>" SortExpression="StartDate">
                    <HeaderTemplate>
                        <asp:LinkButton ID="LinkButton19" runat="server" CausesValidation="False" 
                            CommandArgument="StartDate" CommandName="Sort" 
                            Text='<%# ResourceHelper.GetFromResource("Start Date") %>'></asp:LinkButton>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label19" runat="server" __designer:wfdid="w38" 
                            Text='<%# Bind("StartDate", "{0:d}") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="6%" HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Due Date %>" SortExpression="DeadlineDate">
                    <edititemtemplate>
                        <asp:TextBox ID="TextBox5" runat="server" __designer:wfdid="w39" 
                            Text='<%# Bind("DeadlineDate") %>'></asp:TextBox>
                    </edititemtemplate>
                    <headertemplate>
                        <asp:LinkButton ID="LinkButton4" runat="server" CausesValidation="False" 
                            CommandArgument="DeadlineDate" CommandName="Sort" 
                            Text='<%# ResourceHelper.GetFromResource("Due Date") %>'></asp:LinkButton>
                    </headertemplate>
                    <itemtemplate>
                        <asp:Label ID="Label5" runat="server" __designer:wfdid="w38" 
                            Text='<%# Bind("DeadlineDate", "{0:d}") %>'></asp:Label>
                    </itemtemplate>
                    <ItemStyle Width="6%" HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Status %>" SortExpression="TaskStatus">
                    <edititemtemplate>
                        <asp:TextBox ID="TextBox6" runat="server" __designer:wfdid="w33" 
                            Text='<%# Bind("TaskStatus") %>'></asp:TextBox>
                    </edititemtemplate>
                    <headertemplate>
                        <asp:LinkButton ID="LinkButton5" runat="server" CausesValidation="False" 
                            CommandArgument="TaskStatus" CommandName="Sort" 
                            Text='<%# ResourceHelper.GetFromResource("Status") %>'></asp:LinkButton>
                    </headertemplate>
                    <itemtemplate>
                        <asp:Label ID="Label6" runat="server" __designer:wfdid="w32" 
                            Text='<%# Bind("TaskStatus") %>'></asp:Label>
                    </itemtemplate>
                    <itemstyle width="6%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Priority %>" SortExpression="Priority">
                    <edititemtemplate>
                        <asp:TextBox ID="TextBox7" runat="server" __designer:wfdid="w36" 
                            Text='<%# Bind("Priority") %>'></asp:TextBox>
                    </edititemtemplate>
                    <headertemplate>
                        <asp:LinkButton ID="LinkButton6" runat="server" CausesValidation="False" 
                            CommandArgument="Priority" CommandName="Sort" 
                            Text='<%# ResourceHelper.GetFromResource("Priority") %>'></asp:LinkButton>
                    </headertemplate>
                    <itemtemplate>
                        <asp:Label ID="Label7" runat="server" __designer:wfdid="w35" 
                            Text='<%# Bind("Priority") %>'></asp:Label>
                    </itemtemplate>
                    <headerstyle horizontalalign="Center" />
                    <itemstyle horizontalalign="Left" Width="6%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderImageUrl="~/Images/Completed.gif">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Completed") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/Completed.gif" 
                            Visible='<%# IIF(IsDBNull(Eval("Completed")),"false",Eval("Completed")) %>' />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="2%" />
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
                            OnClientClick="<%# ResourceHelper.GetDeleteMessageJavascript()%>" 
                            Text="Delete" />
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle cssclass="delete_button" HorizontalAlign="Center" Width="1%" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:HyperLink ID="HyperLink1" runat="server" __designer:wfdid="w46" 
                            NavigateUrl='<%# "~/ProjectAdmin/AccountProjectTaskAttachmentsPopUp.aspx?AccountProjectTaskId=" & DataBinder.Eval(Container.DataItem,"AccountProjectTaskId") & "&AccountAttachmentTypeId=1"%>' 
                            onclick="window.open (this.href, 'popupwindow', 'width=680,height=305,left=300,top=300,scrollbars=yes'); return false;">
            <asp:Literal ID="Literal1" runat="server" Text="<%$ Resources:TimeLive.Resource, Attachment%> " /></asp:HyperLink></ItemTemplate><ItemStyle 
                        HorizontalAlign="Center" Width="1%" /></asp:TemplateField><asp:TemplateField><HeaderTemplate><asp:Image 
                        ID="Image2" runat="server" ImageUrl="~/Images/Disabled.gif" 
                        Tooltip="<%$ Resources:TimeLive.Resource, Disabled_text%> " /></HeaderTemplate><ItemTemplate><asp:Image 
                            ID="Image2" runat="server" ImageUrl="~/Images/Disabled.gif" 
                            Tooltip="<%$ Resources:TimeLive.Resource, Disabled_text%> " 
                            Visible='<%# IIF(IsDBNull(Eval("IsDisabled")),"false",Eval("IsDisabled")) %>' /></ItemTemplate><ItemStyle 
                        HorizontalAlign="Center" Width="2%" /></asp:TemplateField></Columns></x:GridView><table 
            style="width: 100%"><tr><td align="left">
            <br />&nbsp;<asp:Button ID="btnAddTask" runat="server" OnClick="btnAddTask_Click" Text="Add" UseSubmitBehavior="False" Width="75px" /></td></tr></table>
            <asp:ObjectDataSource ID="AccountProjectTaskHierarchyObject"
    runat="server" DeleteMethod="DeleteAccountProjectType" InsertMethod="AddAccountProjectTask"
    OldValuesParameterFormatString="original_{0}" SelectMethod="GetAccountProjectTaskHierarchyCached"
    TypeName="AccountProjectTaskBLL" UpdateMethod="UpdateAccountProjectTask">
    <DeleteParameters>
        <asp:Parameter Name="Original_AccountProjectTaskId" Type="Int32" />
    </DeleteParameters>
    <UpdateParameters>
        <asp:Parameter Name="AccountProjectId" Type="Int32" />
        <asp:Parameter Name="ParentAccountProjectTaskId" Type="Int32" />
        <asp:Parameter Name="TaskName" Type="String" />
        <asp:Parameter Name="TaskDescription" Type="String" />
        <asp:Parameter Name="AccountTaskTypeId" Type="Int32" />
        <asp:Parameter Name="Duration" Type="Int32" />
        <asp:Parameter Name="DurationUnit" Type="String" />
        <asp:Parameter Name="CompletedPercent" Type="Int32" />
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
    </UpdateParameters>
    <SelectParameters>
        <asp:QueryStringParameter DefaultValue="1" Name="AccountProjectId" QueryStringField="AccountProjectId"
            Type="Int64" />
    
    </SelectParameters>
    <InsertParameters>
        <asp:Parameter Name="AccountProjectId" Type="Int32" />
        <asp:Parameter Name="ParentAccountProjectTaskId" Type="Int32" />
        <asp:Parameter Name="TaskName" Type="String" />
        <asp:Parameter Name="TaskDescription" Type="String" />
        <asp:Parameter Name="AccountTaskTypeId" Type="Int32" />
        <asp:Parameter Name="Duration" Type="Int32" />
        <asp:Parameter Name="DurationUnit" Type="String" />
        <asp:Parameter Name="CompletedPercent" Type="Int32" />
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
 </InsertParameters>
</asp:ObjectDataSource>
