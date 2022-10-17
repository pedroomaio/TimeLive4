<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlAccountProjectTaskEmployeeList.ascx.vb" Inherits="ProjectAdmin_Controls_ctlAccountProjectTaskEmployeeList" %>

<asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="True">
</asp:ScriptManager>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <x:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="dsAccountProjectTaskEmployeeObject" Width="306px" SkinID="xgridviewSkinEmployee" Caption="Project Task Employee List" DataKeyNames="AccountProjectTaskEmployeeId,AccountProjectTaskId,AccountEmployeeId">
            <Columns>
                <asp:BoundField DataField="AccountProjectTaskEmployeeId" HeaderText="AccountProjectTaskEmployeeId"
                    InsertVisible="False" ReadOnly="True" SortExpression="AccountProjectTaskEmployeeId"
                    Visible="False" />
                <asp:BoundField DataField="AccountId" HeaderText="AccountId" SortExpression="AccountId"
                    Visible="False" />
                <asp:BoundField DataField="AccountProjectId" HeaderText="AccountProjectId" SortExpression="AccountProjectId"
                    Visible="False" />
                <asp:BoundField DataField="AccountProjectTaskId" HeaderText="AccountProjectTaskId"
                    SortExpression="AccountProjectTaskId" Visible="False" />
                <asp:BoundField DataField="AccountEmployeeId" HeaderText="AccountEmployeeId" SortExpression="AccountEmployeeId"
                    Visible="False" />
                <asp:BoundField DataField="FirstName" HeaderText="First Name" SortExpression="FirstName">
                    <ItemStyle HorizontalAlign="Left" Width="200px" />
                    <HeaderStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="LastName" HeaderText="Last Name" SortExpression="LastName">
                    <ItemStyle HorizontalAlign="Left" Width="200px" />
                    <HeaderStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="TaskName" HeaderText="TaskName" SortExpression="TaskName"
                    Visible="False" />
                <asp:BoundField DataField="Login" HeaderText="Login" SortExpression="Login" Visible="False" />
                <asp:BoundField DataField="Password" HeaderText="Password" SortExpression="Password"
                    Visible="False" />
                <asp:TemplateField HeaderText="Selected">
                    <ItemStyle HorizontalAlign="Center" Width="55px" />
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemTemplate>
                        <asp:CheckBox ID="chkSelected" runat="server" Checked='<%# IIF(IsDBNull(Eval("AccountProjectTaskEmployeeId")),"false","true") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </x:GridView>
        <asp:ObjectDataSource ID="dsAccountProjectTaskEmployeeObject" runat="server" DeleteMethod="DeleteAccountProjectTaskEmployeeId"
            InsertMethod="AddAccountProjectTaskEmployee" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetAccountProjectTaskEmployeesForSelection" TypeName="AccountProjectTaskEmployeeBLL">
            <DeleteParameters>
                <asp:Parameter Name="Original_AccountProjectTaskEmployeeId" Type="Int32" />
            </DeleteParameters>
            <SelectParameters>
                <asp:QueryStringParameter DefaultValue="30" Name="AccountProjectTaskId" QueryStringField="AccountProjectTaskId"
                    Type="Int32" />
                <asp:SessionParameter DefaultValue="64" Name="AccountId" SessionField="AccountId"
                    Type="Int32" />
            </SelectParameters>
            <InsertParameters>
                <asp:Parameter Name="AccountId" Type="Int32" />
                <asp:Parameter Name="AccountProjectTaskId" Type="Int32" />
                <asp:Parameter Name="AccountEmployeeId" Type="Int32" />
            </InsertParameters>
        </asp:ObjectDataSource>
        <br />
        <asp:Button ID="Update" runat="server" Text="Update" OnClick="Update_Click" />
    </ContentTemplate>
</asp:UpdatePanel>
