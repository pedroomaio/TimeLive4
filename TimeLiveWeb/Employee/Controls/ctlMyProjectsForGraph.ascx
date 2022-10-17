<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlMyProjectsForGraph.ascx.vb" Inherits="Employee_Controls_ctlMyProjectsForGraph" %>

<x:GridView id="MPGV" runat="server" DataSourceID="dsObjectMyProjectGridView" 
            AutoGenerateColumns="False" 
            Caption='<%# ResourceHelper.GetFromResource("My Projects") %>' 
            SkinID="xgridviewSkinEmployee" Width="99%" EnableViewState="False" 
            AllowSorting="True" >
    <Columns>
        <asp:BoundField DataField="ProjectCode" HeaderText="Code" 
             >
        <ItemStyle Width="8%" />
        </asp:BoundField>
        <asp:BoundField DataField="ProjectName" HeaderText="Project Name" 
             >
        <ItemStyle  Width="30%" />
        </asp:BoundField>
        <asp:BoundField DataField="PartyName" HeaderText="Client Name">
        <ItemStyle Width="20%" />
        </asp:BoundField>
        <asp:BoundField DataField="StartDate" HeaderText="Start Date" 
            DataFormatString="{0:d}" >
        <ItemStyle HorizontalAlign="Center" Width="9%" />
        </asp:BoundField>
        <asp:BoundField DataField="Deadline" HeaderText="Deadline" 
             DataFormatString="{0:d}" >
        <ItemStyle HorizontalAlign="Center" Width="8%" />
        </asp:BoundField>
        <asp:TemplateField HeaderText="Schedule Status" >
            <EditItemTemplate>
                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Status") %>'></asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="Label1" runat="server" Text='<%# Bind("Status") %>'></asp:Label>
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="12%" />
        </asp:TemplateField>
        <asp:BoundField DataField="Status" HeaderText="Status" 
             >
        <ItemStyle HorizontalAlign="Left" Width="9%" />
        </asp:BoundField>
    </Columns>
</x:GridView> 
<asp:ObjectDataSource ID="dsObjectMyProjectGridView" runat="server" 
    OldValuesParameterFormatString="original_{0}" 
    SelectMethod="GetAssignedAccountProjectsByAccountEmployeeId" TypeName="AccountProjectBLL" 
    DeleteMethod="DeleteAccountProject" InsertMethod="AddAccountProject" 
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
        <asp:SessionParameter DefaultValue="232" Name="AccountEmployeeId" 
            SessionField="AccountEmployeeId" Type="Int32" />
        <asp:Parameter Name="Completed" Type="String" />
        <asp:Parameter Name="ProjectStatusId" Type="Int32" />
        <asp:Parameter Name="Disabled" Type="String" />
        <asp:Parameter Name="AccountClientId" Type="Int32" />
        <asp:Parameter Name="AccountProjectId" Type="Int32" />
        <asp:Parameter Name="ProjectCode" Type="String" />
    </SelectParameters>
    <UpdateParameters>
        <asp:Parameter Name="ProjectDescription" Type="String" />
        <asp:Parameter Name="Original_AccountProjectId" Type="Int32" />
    </UpdateParameters>
</asp:ObjectDataSource>