<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlAccountProjectTastEmployees.ascx.vb" Inherits="ProjectAdmin_Controls_ctlAccountProjectTastEmployees" %>
<%@ Register src="ctlProjectView.ascx" tagname="ctlProjectView" tagprefix="uc1" %>
<%@ Register assembly="eWorld.UI.Compatibility, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2" namespace="eWorld.UI.Compatibility" tagprefix="cc1" %>
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
     <style type="text/css">

    .stylecss
    {
        width: 168px;
        height: 16px;
        color: #1a3b69;
        margin: 0px;
        padding: 0px;
        font-size:14px;
        text-align: center;
        font-weight: bold;
    }
    </style>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate>
   <table class="xFormView" style="margin-left:1px"><tr><td>
<table class="xFormView" style="width: 500px; ">
    <tr>
        <th class="caption" colspan="4">
            <asp:Literal ID="Literal5" runat="server" Text="<%$ Resources:TimeLive.Resource, Task Information%> " /></th>
    </tr>
    <tr>
        <td align="right" class="formviewlabelcell" style="width: 20%">
            <asp:Literal ID="Literal1" runat="server" Text="<%$ Resources:TimeLive.Resource, Task Id:%> " /></td>
        <td align="left" style="width: 30%">
            <asp:TextBox ID="txtTaskId" runat="server" ReadOnly="True" Width="100px"></asp:TextBox>
        </td>
        <td align="right" class="formviewlabelcell" style="width: 20%">
            <asp:Literal ID="Literal2" runat="server" Text="<%$ Resources:TimeLive.Resource, Task Code:%> " /></td>
        <td align="left" style="width: 30%">
            <asp:TextBox ID="txtTaskCode" runat="server" ReadOnly="True" Width="100px"></asp:TextBox></td>
    </tr>
    <tr>
        <td align="right" class="formviewlabelcell" style="width: 20%">
            <asp:Literal ID="Literal3" runat="server" Text="<%$ Resources:TimeLive.Resource, Task Name:%> " /></td>
        <td align="left" colspan="3" style="width: 80%">
            <asp:TextBox ID="txtTaskName" runat="server" ReadOnly="True" Width="350px"></asp:TextBox></td>
    </tr>
</table>
</td></tr></table>
    <asp:CheckBox ID="chkIsSelected" runat="server" AutoPostBack="True" 
                    Checked="True" Visible="False" />
  <table class="xFormView" width="98.5%">
        <tr>
            <td align="right" width="1%" >
                <asp:UpdatePanel ID="UpdatePanel2" runat="server"><ContentTemplate>               
     <asp:Button ID="btnAddEmployeesinTask" runat="server"  
       Text="<%$ Resources:TimeLive.Resource, Add Employees in Task%> " OnClick="btnAddEmployeesinTask_Click1" 
         UseSubmitBehavior="False" />
         <asp:Button ID="Update" runat="server" CommandName="Update" Text="<%$ Resources:TimeLive.Resource, Update_text%> "
    Width="55px" />
   
          <%-- <asp:Button ID="btnAddSelectedEmployees" runat="server"  
        Text="<%$ Resources:TimeLive.Resource, Add Selected Employees%> " OnClick="btnAddSelectedEmployees_Click1" 
         UseSubmitBehavior="False" />--%>
         <asp:Button ID="btnCancel" runat="server"  
        Text="<%$ Resources:TimeLive.Resource, Cancel_text%> " OnClick="btnCancel_Click1" 
        Width="55px" UseSubmitBehavior="False" />
            </ContentTemplate></asp:UpdatePanel>   </td>
        </tr>
    </table>
  <x:GridView id="GridView1" runat="server" AutoGenerateColumns="False" PageSize="25" EmptyDataText="<%$ Resources:TimeLive.Resource, No employee available for selection %>" ShowHeaderWhenEmpty="True" EmptyDataRowStyle-CssClass="stylecss"
            DataSourceID="ObjectDataSource1" SkinID="xgridviewSkinEmployee" 
            Caption='<%# ResourceHelper.GetFromResource("Task Employee List") %>'
    Width="98%" 
    
            DataKeyNames="AccountProjectTaskEmployeeId,AccountProjectId,AccountProjectTaskId,AccountEmployeeId" ><Columns>
            <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Employee Name %>" SortExpression="FullName">
                <headertemplate>
                        <asp:LinkButton ID="LinkButton3" runat="server" __designer:wfdid="w3" 
                            CausesValidation="False" CommandArgument="TaskName" CommandName="Sort" 
                            Text='<%# ResourceHelper.GetFromResource("Employee Name") %>'></asp:LinkButton></headertemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("FullName") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("FullName") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="300px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Project Name %>" SortExpression="ProjectName">
                <headertemplate>
                        <asp:Label ID="Label30" runat="server" __designer:wfdid="w3" 
                            CausesValidation="False" CommandArgument="TaskName" CommandName="Sort" 
                            Text='<%# ResourceHelper.GetFromResource("Project Name") %>'></asp:Label></headertemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("ProjectName") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label30" runat="server" Text='<%# Bind("ProjectName") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="250px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Task Name %>" SortExpression="TaskName">
                <headertemplate>
                        <asp:Label ID="Label130" runat="server" __designer:wfdid="w3" 
                            CausesValidation="False" CommandArgument="TaskName" CommandName="Sort" 
                            Text='<%# ResourceHelper.GetFromResource("Task Name") %>'></asp:Label></headertemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("TaskName") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label130" runat="server" Text='<%# Bind("TaskName") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="250px" />
            </asp:TemplateField>
    <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Selected %>">
        <ItemStyle HorizontalAlign="Center" Width="15px" verticalalign="Middle" />
        <HeaderTemplate>
            <asp:CheckBox ID="chkCheckAll" runat="server" Width="15px" __designer:wfdid="w109" />
        </HeaderTemplate>
    <ItemTemplate>
        <asp:CheckBox id="chkSelect" runat="server"  Width="15px" __designer:wfdid="w109" 
            Checked='<%# IIF(Isdbnull(Eval("AccountProjectTaskEmployeeId")),"False","True") %>'></asp:CheckBox> 
</ItemTemplate>
    </asp:TemplateField>
</Columns>
</x:GridView> 
  
  <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
    DeleteMethod="DeleteAccountProjectTaskEmployeeId" 
    InsertMethod="AddAccountProjectTaskEmployee" 
    OldValuesParameterFormatString="original_{0}" 
    SelectMethod="GetAssignedAccountProjectTaskEmployees" 
    TypeName="AccountProjectTaskEmployeeBLL" 
    UpdateMethod="UpdateAccountProjectTaskEmployee">
    <DeleteParameters>
        <asp:Parameter Name="Original_AccountProjectTaskEmployeeId" Type="Int32" />
    </DeleteParameters>
    <InsertParameters>
        <asp:Parameter Name="AccountId" Type="Int32" />
        <asp:Parameter Name="AccountProjectId" Type="Int32" />
        <asp:Parameter Name="AccountProjectTaskId" Type="Int32" />
        <asp:Parameter Name="AccountEmployeeId" Type="Int32" />
        <asp:Parameter Name="AllocationUnits" Type="Decimal" />
    </InsertParameters>
    <SelectParameters>
        <asp:QueryStringParameter DefaultValue="" Name="AccountProjectId" 
            QueryStringField="AccountProjectId" Type="Int32" />
        <asp:QueryStringParameter DefaultValue="" Name="AccountProjectTaskId" 
            QueryStringField="AccountProjectTaskId" Type="Int32" />
        <asp:ControlParameter ControlID="chkIsSelected" DefaultValue="True" 
            Name="IsSelected" PropertyName="Checked" Type="Boolean" />
    </SelectParameters>
    <UpdateParameters>
        <asp:Parameter Name="AccountProjectTaskEmployeeId" Type="Int32" />
        <asp:Parameter Name="AllocationUnits" Type="Decimal" />
    </UpdateParameters>
</asp:ObjectDataSource>
</ContentTemplate>
</asp:UpdatePanel>