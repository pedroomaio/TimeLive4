<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlMyTasksShort.ascx.vb" Inherits="Employee_Controls_ctlMyTasksShort" EnableViewState="false" %>


<x:GridView id="G" runat="server" DataSourceID="AccountProjectTaskHierarchyObject" AutoGenerateColumns="False" Caption='<%# ResourceHelper.GetFromResource("My Task List") %>' SkinID="xgridviewSkinEmployee" Width="99%" EnableViewState="False" AllowSorting="True"><Columns>
    <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Id %>">
        <EditItemTemplate>
<asp:TextBox id="TextBox1" runat="server" Text='<%# Bind("AccountProjectTaskId") %>' __designer:wfdid="w11"></asp:TextBox> 
</EditItemTemplate>
        <ItemTemplate>
<asp:Label id="Label1" runat="server" Visible='<%# not Eval("AccountProjectTaskId") = 0 %>' Text='<%# Bind("AccountProjectTaskId") %>' __designer:wfdid="w10"></asp:Label> 
</ItemTemplate>
        <ItemStyle HorizontalAlign="Center" Width="5%" />
    </asp:TemplateField>
    <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Task Name %>">
        <headertemplate>
<asp:LinkButton id="LinkButton3" runat="server" __designer:wfdid="w20" Text='<%# ResourceHelper.GetFromResource("Task Name") %>' CausesValidation="False" CommandName="Sort" CommandArgument="TaskName"></asp:LinkButton> 
</headertemplate>
        <itemtemplate>
<asp:HyperLink id="HyperLink1" runat="server" NavigateUrl='<%# Eval("AccountProjectTaskId", IIF(AccountPagePermissionBLL.IsPageHasPermissionOf(28, 3),"~/Employee/AccountProjectTaskComments.aspx?AccountProjectTaskId={0}","~/Employee/Default.aspx")) %>' __designer:wfdid="w18" Text='<%# Eval("TaskName") %>' Visible='<%# IIF(AccountPagePermissionBLL.IsPageHasPermissionOf(28, 3),"True","False") %>'></asp:HyperLink><asp:Label id="Label2" runat="server" __designer:wfdid="w12" Text='<%# Eval("TaskName") %>' Visible='<%# IIF(AccountPagePermissionBLL.IsPageHasPermissionOf(28, 3),"False","True") %>'></asp:Label> 
</itemtemplate>
        <ItemStyle Width="30%" />
    </asp:TemplateField>
    <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Project %>">
        <edititemtemplate>
<asp:TextBox id="TextBox2" runat="server" Text='<%# Bind("ProjectName") %>' __designer:wfdid="w13"></asp:TextBox> 
</edititemtemplate>
        <headertemplate>
<asp:LinkButton id="LinkButton4" runat="server" Text='<%# ResourceHelper.GetFromResource("Project") %>' __designer:wfdid="w14" CommandArgument="ProjectCode" CommandName="Sort" CausesValidation="False"></asp:LinkButton> 
</headertemplate>
        <itemtemplate>
<asp:Label id="Label2" runat="server" Text='<%# Bind("ProjectName") %>' __designer:wfdid="w12"></asp:Label> 
</itemtemplate>
        <itemstyle width="30%" />
    </asp:TemplateField>
    <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Type %>"> 
        <edititemtemplate>
<asp:TextBox id="TextBox3" runat="server" Text='<%# Bind("TaskType") %>' __designer:wfdid="w50"></asp:TextBox>
</edititemtemplate>
        <headertemplate>
<asp:LinkButton id="LinkButton5" runat="server" Text='<%# ResourceHelper.GetFromResource("Type") %>' CommandArgument="TaskType" CommandName="Sort" CausesValidation="False"></asp:LinkButton>
</headertemplate>
        <itemtemplate>
<asp:Label id="Label3" runat="server" Text='<%# Bind("TaskType") %>' __designer:wfdid="w49"></asp:Label>
</itemtemplate>
        <itemstyle width="10%" />
    </asp:TemplateField>
    <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Priority %>">
        <edititemtemplate>
<asp:TextBox id="TextBox4" runat="server" Text='<%# Bind("Priority") %>' __designer:wfdid="w53"></asp:TextBox>
</edititemtemplate>
        <headertemplate>
<asp:LinkButton id="LinkButton6" runat="server" Text='<%# ResourceHelper.GetFromResource("Priority") %>' CommandArgument="Priority" CommandName="Sort" CausesValidation="False"></asp:LinkButton>
</headertemplate>
        <itemtemplate>
<asp:Label id="Label4" runat="server" Text='<%# Bind("Priority") %>' __designer:wfdid="w52"></asp:Label>
</itemtemplate>
        <itemstyle width="10%" Wrap="True" />
    </asp:TemplateField>
    <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Status %>">
        <edititemtemplate>
<asp:TextBox id="TextBox5" runat="server" Text='<%# Bind("TaskStatus") %>' __designer:wfdid="w56"></asp:TextBox>
</edititemtemplate>
        <headertemplate>
<asp:LinkButton id="LinkButton7" runat="server" Text='<%# ResourceHelper.GetFromResource("Status") %>' CommandArgument="TaskStatus" CommandName="Sort" CausesValidation="False"></asp:LinkButton>
</headertemplate>
        <itemtemplate>
<asp:Label id="Label5" runat="server" Text='<%# Bind("TaskStatus") %>' __designer:wfdid="w55"></asp:Label>
</itemtemplate>
        <itemstyle width="10%" />
    </asp:TemplateField>
</Columns>
</x:GridView> <asp:ObjectDataSource id="AccountProjectTaskHierarchyObject" 
        runat="server" DeleteMethod="DeleteAccountProjectType" 
        OldValuesParameterFormatString="original_{0}" 
        SelectMethod="GetAssignedOpenAccountProjectTasksByAccountEmployeeId" 
        TypeName="AccountProjectTaskBLL" InsertMethod="AddAccountProjectTask" 
        UpdateMethod="UpdateCompletedInTask">
    <DeleteParameters>
        <asp:Parameter Name="Original_AccountProjectTaskId" Type="Int32"  />
    </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="AccountProjectId" Type="Int32" />
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
        </InsertParameters>
    <SelectParameters>
        <asp:SessionParameter DefaultValue="40" Name="AccountEmployeeId" SessionField="AccountEmployeeId"
            Type="Int32" />
        <asp:SessionParameter DefaultValue="64" Name="AccountId" SessionField="AccountId"
            Type="Int32" />
    </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="AccountProjectId" Type="Int32" />
            <asp:Parameter Name="AccountProjectMilestoneId" Type="Int32" />
            <asp:Parameter Name="TaskStatusId" Type="Int32" />
            <asp:Parameter Name="Completed" Type="Boolean" />
        </UpdateParameters>
</asp:ObjectDataSource>

