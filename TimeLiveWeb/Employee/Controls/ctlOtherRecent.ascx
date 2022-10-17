<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlOtherRecent.ascx.vb" Inherits="Employee_Controls_ctlOtherRecent" %>
<x:GridView ID="G" runat="server" AutoGenerateColumns="False" Caption='<%# ResourceHelper.GetFromResource("My Task Summary") %>'
     DataSourceID="dsProjectTaskCount" SkinID="xgridviewSkinEmployee" Width="98%">
    <Columns>
        <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Project %>">
            <edititemtemplate>
<asp:TextBox id="TextBox1" runat="server" Text='<%# Bind("ProjectName") %>' __designer:wfdid="w10"></asp:TextBox> 
</edititemtemplate>
            <headertemplate>
<asp:LinkButton id="LinkButton3" runat="server" Text='<%# ResourceHelper.GetFromResource("Project") %>' CommandArgument="ProjectCode" CommandName="Sort" CausesValidation="False"></asp:LinkButton>
</headertemplate>
            <itemtemplate>
<asp:Label id="Label1" runat="server" Text='<%# Bind("ProjectName") %>' __designer:wfdid="w9"></asp:Label> 
</itemtemplate>
            <itemstyle width="60%" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Status %>">
            <edititemtemplate>
<asp:TextBox id="TextBox2" runat="server" Text='<%# Bind("Status") %>' __designer:wfdid="w13"></asp:TextBox> 
</edititemtemplate>
            <headertemplate>
<asp:LinkButton id="LinkButton4" runat="server" Text='<%# ResourceHelper.GetFromResource("Status") %>' CommandArgument="Status" CommandName="Sort" CausesValidation="False"></asp:LinkButton>
</headertemplate>
            <itemtemplate>
<asp:Label id="Label2" runat="server" Text='<%# Bind("Status") %>' __designer:wfdid="w12"></asp:Label> 
</itemtemplate>
            <itemstyle width="25%" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Count%>">
            <edititemtemplate>
<asp:Label id="Label1" runat="server" Text='<%# Eval("Count") %>' __designer:wfdid="w16"></asp:Label> 
</edititemtemplate>
            <headertemplate>
<asp:LinkButton id="LinkButton5" runat="server" Text='<%# ResourceHelper.GetFromResource("Count") %>' CommandArgument="Count" CommandName="Sort" CausesValidation="False"></asp:LinkButton>
</headertemplate>
            <itemtemplate>
<asp:Label id="Label3" runat="server" Text='<%# Bind("Count") %>' __designer:wfdid="w15"></asp:Label> 
</itemtemplate>
            <itemstyle horizontalalign="Center" width="12%" />
        </asp:TemplateField>
    </Columns>
</x:GridView>
<asp:ObjectDataSource ID="dsProjectTaskCount" runat="server" OldValuesParameterFormatString="original_{0}"
    SelectMethod="GetProjectTasksCountByAccountEmployeeId" TypeName="AccountProjectTaskBLL" 
    DeleteMethod="DeleteAccountProjectType" InsertMethod="AddAccountProjectTask" 
    UpdateMethod="UpdateAccountProjectTaskUpdateInformation">
    <DeleteParameters>
        <asp:Parameter Name="Original_AccountProjectTaskId" Type="Int32" />
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
        <asp:Parameter Name="original_Predecessors" Type="String" />
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
    </SelectParameters>
    <UpdateParameters>
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
</asp:ObjectDataSource>
