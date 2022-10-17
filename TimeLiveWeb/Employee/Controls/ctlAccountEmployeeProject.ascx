<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlAccountEmployeeProject.ascx.vb" Inherits="Employee_Controls_ctlAccountEmployeeProject" %>
<%@ Register Assembly="eWorld.UI.Compatibility, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2"
    Namespace="eWorld.UI.Compatibility" TagPrefix="cc1" %>
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
    <% Dim AccountProjectBLL as new AccountProjectBLL%>
<% If AccountProjectBLL.GetProjectBillingRateTypeId(Request.QueryString("AccountProjectId")) = 3 Then%>
<% End If%>
<table class="xFormView" style="margin-left:4px"><tr><td>
<table class="xFormView" style="width: 500px; ">
    <tr>
        <th class="caption" colspan="4">
            <asp:Literal ID="Literal5" runat="server" Text="<%$ Resources:TimeLive.Resource, Employee Information%> " /></th>
    </tr>
    <tr>
        <td align="right" class="formviewlabelcell" style="width: 20%">
            <asp:Literal ID="Literal1" runat="server" Text="<%$ Resources:TimeLive.Resource, Employee Id%> " />:</td>
        <td align="left" style="width: 30%">
            <asp:TextBox ID="txtEmployeeId" runat="server" ReadOnly="True" Width="100px"></asp:TextBox>
        </td>
        <td align="right" class="formviewlabelcell" style="width: 20%">
            <asp:Literal ID="Literal2" runat="server" Text="<%$ Resources:TimeLive.Resource, Employee Code:%> " /></td>
        <td align="left" style="width: 30%">
            <asp:TextBox ID="txtEmployeeCode" runat="server" ReadOnly="True" Width="100px"></asp:TextBox></td>
    </tr>
    <tr>
        <td align="right" class="formviewlabelcell" style="width: 20%">
            <asp:Literal ID="Literal3" runat="server" Text="<%$ Resources:TimeLive.Resource, Employee Name:%> " /></td>
        <td align="left" colspan="3" style="width: 80%">
            <asp:TextBox ID="txtEmployeeName" runat="server" ReadOnly="True" Width="350px"></asp:TextBox></td>
    </tr>
</table>
</td></tr></table>
 <div class="fieldset" style="width: 478px; height: 20px; margin-left: 6px;" align="left">
    <table class="xFormView" width="480px">
        <tr>
            <td align="left" width="1%" >
                    <asp:CheckBox ID="chkIsSelected" runat="server" AutoPostBack="True" 
                    Checked="True" />
    
            </td>
            <td align="left" width="94%" style="font-weight:bold;" class="formviewlabelcell">
<%--    <asp:CheckBox ID="chkIsSelected" runat="server" AutoPostBack="True" 
                    Checked="True" />--%>
                    <asp:Label ID="Label1" runat="server" Text="Show Selected Projects"></asp:Label>
            </td>
        </tr>
    </table>
    </div>
<x:GridView id="GridView1" runat="server" AutoGenerateColumns="False" 
    PageSize="25" DataSourceID="dsAccountProjectEmployee" 
    SkinID="xgridviewSkinEmployee" Caption="Employee Project List " Width="98%" 
    DataKeyNames="AccountProjectId,AccountProjectEmployeeId" 
    OnDataBound="GridView1_DataBound" OnRowDataBound="GridView1_RowDataBound"><Columns>
        <asp:BoundField DataField="AccountProjectId" HeaderText="Id"
            InsertVisible="False" ReadOnly="True" SortExpression="AccountProjectId" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
            <itemstyle width="5%" />
        </asp:BoundField>
        <asp:BoundField DataField="ClientName" HeaderText="Client Name" 
            SortExpression="ClientName">
        <ItemStyle Width="30%" />
        </asp:BoundField>
        <asp:BoundField DataField="ProjectName" HeaderText="Project Name" SortExpression="ProjectName" >
            <itemstyle width="35%" />
        </asp:BoundField>
        <asp:BoundField DataField="ClientDepartment" HeaderText="Client Department" 
            SortExpression="ClientDepartment">
            <ItemStyle Width="23%" />
        </asp:BoundField>
        <asp:BoundField DataField="AccountEmployeeId" HeaderText="AccountEmployeeId" InsertVisible="False"
            ReadOnly="True" SortExpression="AccountEmployeeId" Visible="False">
            <itemstyle width="0%" />
        </asp:BoundField>
        <asp:BoundField DataField="AccountProjectEmployeeId" HeaderText="AccountProjectEmployeeId"
            InsertVisible="False" ReadOnly="True" SortExpression="AccountProjectEmployeeId"
            Visible="False">
            <itemstyle width="0%" />
        </asp:BoundField>
<asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Selected %>">
        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
        <ItemStyle HorizontalAlign="Center" Width="5%" verticalalign="Middle" />
        <HeaderTemplate>
            <asp:CheckBox ID="chkCheckAll" runat="server" __designer:wfdid="w109" />
        </HeaderTemplate>
    <ItemTemplate>
        <asp:CheckBox id="chkSelect" runat="server" __designer:wfdid="w109" 
            Checked='<%# IIF(Isdbnull(Eval("AccountProjectEmployeeId")),"False","True") %>'></asp:CheckBox> 
</ItemTemplate>
    </asp:TemplateField>
    </Columns>
</x:GridView>
<br />
&nbsp;<asp:Button ID="Update" runat="server" 
    Text="<%$ Resources:TimeLive.Resource, Update_text%> " Width="60px" 
    UseSubmitBehavior="False" /><br />
<asp:ObjectDataSource ID="dsAccountProjectEmployee" runat="server" OldValuesParameterFormatString="original_{0}"
    OnInserting="dsAccountProjectEmployee_Inserting" SelectMethod="GetDataByAccountEmployeeIdForEmployeeProjectList"
    TypeName="AccountProjectEmployeeBLL" 
    DeleteMethod="DeleteAccountProjectEmployeeId" 
    InsertMethod="AddAccountProjectEmployee" 
    UpdateMethod="UpdateAccountProjectEmployee">
    <SelectParameters>
        <asp:SessionParameter DefaultValue="64" Name="AccountId" SessionField="AccountId"
            Type="Int32" />
        <asp:QueryStringParameter DefaultValue="151" Name="AccountEmployeeId" QueryStringField="AccountEmployeeId"
            Type="Int32" />
        <asp:ControlParameter ControlID="chkIsSelected" Name="IsSelected" 
            PropertyName="Checked" Type="Boolean" />
    </SelectParameters>
    <DeleteParameters>
        <asp:Parameter Name="Original_AccountProjectEmployeeId" Type="Int32" />
    </DeleteParameters>
    <UpdateParameters>
        <asp:Parameter Name="AccountId" Type="Int32" />
        <asp:Parameter Name="AccountProjectId" Type="Int32" />
        <asp:Parameter Name="AccountEmployeeId" Type="Int32" />
        <asp:Parameter Name="AccountRoleId" Type="Int32" />
        <asp:Parameter Name="AccountBillingRateId" Type="Int32" />
        <asp:Parameter Name="Original_AccountProjectEmployeeId" Type="Int32" />
    </UpdateParameters>
    <InsertParameters>
        <asp:Parameter Name="AccountId" Type="Int32" />
        <asp:Parameter Name="AccountProjectId" Type="Int32" />
        <asp:Parameter Name="AccountEmployeeId" Type="Int32" />
        <asp:Parameter Name="AccountRoleId" Type="Int32" />
        <asp:Parameter Name="AccountBillingRateId" Type="Int32" />
        <asp:Parameter Name="IsWebServiceCall" Type="Boolean" />
    </InsertParameters>
</asp:ObjectDataSource>
<asp:ObjectDataSource ID="dsFilledAccountProjectEmployee" runat="server" OldValuesParameterFormatString="original_{0}"
    OnInserting="dsAccountProjectEmployee_Inserting" SelectMethod="GetFilledRowsOfAccountProjectEmployee"
    TypeName="AccountProjectEmployeeBLL">
    <SelectParameters>
        <asp:QueryStringParameter DefaultValue="1" Name="AccountProjectId" QueryStringField="AccountProjectId"
            Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>
<asp:ObjectDataSource ID="dsAccountCurrencyObject" runat="server" OldValuesParameterFormatString="original_{0}"
    SelectMethod="GetvueAccountCurrencyByAccountIdAndDisabled" TypeName="AccountCurrencyBLL">
    <SelectParameters>
        <asp:SessionParameter Name="AccountId" SessionField="AccountId" Type="Int32" />
        <asp:Parameter Name="AccountCurrencyId" Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>
