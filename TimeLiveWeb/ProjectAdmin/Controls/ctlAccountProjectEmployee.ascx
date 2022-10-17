<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlAccountProjectEmployee.ascx.vb" Inherits="AccountAdmin_Controls_ctlAccountProjectEmployee" %>
<%@ Register Assembly="eWorld.UI.Compatibility, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2"
    Namespace="eWorld.UI.Compatibility" TagPrefix="cc1" %>
<%@ Register Src="ctlProjectView.ascx" TagName="ctlProjectView" TagPrefix="uc1" %>
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
   <uc1:ctlProjectView ID="CtlProjectView1" runat="server" />
   
    <% Dim AccountProjectBLL as new AccountProjectBLL%>
    <% If AccountProjectBLL.GetProjectBillingRateTypeId(Request.QueryString("AccountProjectId")) = 3 Then%>
    <br />
    <div class="fieldset" style="width: 478px">
    <table class="xFormView" style="width: 500px">
        <tr>
            <td align="right" class="formviewlabelcell" style="width: 18%; font-weight:bold;">
                <asp:Literal ID="Literal4" runat="server" Text="<%$ Resources:TimeLive.Resource, Work Type:%> " /></td>
            <td align="left" style="width: 80%">
    <asp:DropDownList ID="ddlAccountWorkTypeId" runat="server" AutoPostBack="True" DataSourceID="dsAccountWorkTypeObject"
        DataTextField="AccountWorkType" DataValueField="AccountWorkTypeId" OnSelectedIndexChanged="ddlAccountWorkTypeId_SelectedIndexChanged"
        Width="200px">
    </asp:DropDownList>
                <asp:Label ID="lblWorkTypeValue" runat="server" Visible="False"></asp:Label></td>
        </tr>
    </table>
    </div> 
    <% End If%>
   <asp:CheckBox ID="chkIsSelected" runat="server" AutoPostBack="True" 
                    Checked="True" Visible="False" />
   
     <table class="xFormView" width="99%">
        <tr>
            <td align="right" width="1%" >
    <asp:UpdatePanel ID="UpdatePanel2" runat="server"><ContentTemplate>               
     <asp:Button ID="btnAddEmployeesinProject" runat="server"  
       Text="<%$ Resources:TimeLive.Resource, Add Employees in Project%> " OnClick="btnAddEmployeesinProject_Click1" 
         UseSubmitBehavior="False" />
         <asp:Button ID="Update" runat="server"  
        Text="<%$ Resources:TimeLive.Resource, Update_text%> " OnClick="Update_Click1" 
        Width="55px" UseSubmitBehavior="False" />
           <asp:Button ID="btnAddSelectedEmployees" runat="server"  
         Text="<%$ Resources:TimeLive.Resource, Add Selected Employees%> " OnClick="btnAddSelectedEmployees_Click1" 
         UseSubmitBehavior="False" />
            <asp:Button ID="btnCancel" runat="server"  
        Text="<%$ Resources:TimeLive.Resource, Cancel_text%> " OnClick="btnCancel_Click1" 
        Width="55px" UseSubmitBehavior="False" />
        </ContentTemplate></asp:UpdatePanel>  </td>
        </tr>
    </table>
    
  <x:GridView id="GridView1" runat="server" AutoGenerateColumns="False" PageSize="25" style="margin-left:0px;" DataSourceID="dsAccountProjectEmployee" SkinID="xgridviewSkinEmployee" Caption="<%$ Resources:TimeLive.Resource, Project Employee List %>" Width="99%" DataKeyNames="AccountProjectEmployeeId,AccountEmployeeId,AccountBillingRateId,StartDate,EndDate" OnDataBound="GridView1_DataBound" OnRowDataBound="GridView1_RowDataBound" EmptyDataText="<%$ Resources:TimeLive.Resource, No employee available for selection %>" ShowHeaderWhenEmpty="True" EmptyDataRowStyle-CssClass="stylecss"><Columns>
    <asp:BoundField DataField="AccountProjectId" HeaderText="<%$ Resources:TimeLive.Resource, Id %>" InsertVisible="False"
        ReadOnly="True" SortExpression="AccountProjectId" Visible="False" >
        <itemstyle width="0%" />
    </asp:BoundField>
    <asp:BoundField HeaderText="<%$ Resources:TimeLive.Resource, Employee Name %>" SortExpression="FullName" DataField="FullName" >
        <itemstyle width="200px" />
    </asp:BoundField>
    <asp:BoundField DataField="DepartmentName" HeaderText="<%$ Resources:TimeLive.Resource, Department Name %>" SortExpression="DepartmentName" >
    <ItemStyle Width="225px" />
    </asp:boundfield>
    <asp:BoundField DataField="AccountLocation" HeaderText="<%$ Resources:TimeLive.Resource, Location %>" SortExpression="AccountLocation" >
    <ItemStyle Width="225px" />
    </asp:boundfield>
    <asp:BoundField HeaderText="<%$ Resources:TimeLive.Resource, Last Name %>" SortExpression="LastName" Visible="False" >
        <itemstyle width="0%" />
    </asp:BoundField>
    <asp:BoundField DataField="AccountEmployeeId" HeaderText="AccountEmployeeId" InsertVisible="False"
        ReadOnly="True" SortExpression="AccountEmployeeId" Visible="False" >
        <itemstyle width="0%" />
    </asp:BoundField>
    <asp:BoundField DataField="AccountProjectEmployeeId" HeaderText="AccountProjectEmployeeId"
        InsertVisible="False" ReadOnly="True" SortExpression="AccountProjectEmployeeId" Visible="False" >
        <itemstyle width="0%" />
    </asp:BoundField>
    <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Role %>" Visible="False" SortExpression="Role">
        <ItemStyle Width="350px" horizontalalign="Center" verticalalign="Middle" />
        <ItemTemplate>
<asp:DropDownList id="ddlAccountRoleId" runat="server" Width="99.5%" 
                DataValueField="AccountRoleId" DataTextField="Role" 
                DataSourceID="dsAccountRoleObject" __designer:wfdid="w222"></asp:DropDownList><asp:ObjectDataSource id="dsAccountRoleObject" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetAccountRolesByAccountProjectId" TypeName="AccountRoleBLL" __designer:wfdid="w223" DeleteMethod="DeleteAccountRole">
                <SelectParameters>
                    <asp:QueryStringParameter Name="AccountProjectId" QueryStringField="AccountProjectId"
                        Type="Int32" />
                </SelectParameters>
                <DeleteParameters>
                    <asp:Parameter Name="original_AccountRoleId" Type="Int32" />
                </DeleteParameters>
            </asp:ObjectDataSource> 
</ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Employee Name %>">
        <ItemStyle Width="350px" horizontalalign="Center" verticalalign="Middle" />
        <ItemTemplate>
<asp:DropDownList id="ddlAccountEmployeeId" runat="server" Width="99.5%" 
                DataValueField="AccountEmployeeId" DataTextField="FullName" 
                DataSourceID="dsAccountEmployeeObject" __designer:wfdid="w11" 
                AppendDataBoundItems="True"><asp:ListItem Value="0"></asp:ListItem>
</asp:DropDownList><asp:ObjectDataSource id="dsAccountEmployeeObject" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetAccountEmployeesByAccountIdAndIsDisabled" TypeName="AccountEmployeeBLL" __designer:wfdid="w12"><SelectParameters>
<asp:SessionParameter SessionField="AccountId" Type="Int32" DefaultValue="64" Name="AccountId"></asp:SessionParameter>
<asp:Parameter Type="Int32" Name="AccountEmployeeId"></asp:Parameter>
</SelectParameters>
</asp:ObjectDataSource> 
</ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Billing Rate Currency %>">
        <itemstyle horizontalalign="Center" verticalalign="Middle" width="6%" />
        <itemtemplate>
<asp:DropDownList id="ddlBillingRateCurrencyId" runat="server" Width="100%" DataValueField="AccountCurrencyId" DataTextField="CurrencyCode" DataSourceID="dsBillingRateCurrencyObject" __designer:wfdid="w217"></asp:DropDownList><BR /><asp:ObjectDataSource id="dsBillingRateCurrencyObject" runat="server" __designer:dtid="281474976710724" OldValuesParameterFormatString="original_{0}" SelectMethod="GetvueAccountCurrencyByAccountIdAndDisabled" TypeName="AccountCurrencyBLL" __designer:wfdid="w218"><SelectParameters __designer:dtid="281474976710725">
<asp:SessionParameter SessionField="AccountId" Name="AccountId" Type="Int32" __designer:dtid="281474976710726"></asp:SessionParameter>
<asp:Parameter Name="AccountCurrencyId" Type="Int32" __designer:dtid="281474976710727"></asp:Parameter>
</SelectParameters>
</asp:ObjectDataSource> 
</itemtemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Billing Rate %>">
        <itemstyle width="6%" horizontalalign="Center" verticalalign="Middle" />
        <ItemTemplate>
<asp:TextBox id="BillingRateTextBox" runat="server" Width="55px" __designer:wfdid="w204"></asp:TextBox> 
</ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Employee Rate Currency %>">
        <itemstyle horizontalalign="Center" verticalalign="Middle" width="6%" />
        <itemtemplate>
<asp:DropDownList id="ddlEmployeeRateCurrencyId" runat="server" Width="100%" DataValueField="AccountCurrencyId" DataTextField="CurrencyCode" DataSourceID="dsEmployeeRateCurrencyObject" __designer:wfdid="w205"></asp:DropDownList><asp:ObjectDataSource id="dsEmployeeRateCurrencyObject" runat="server" __designer:dtid="281474976710724" OldValuesParameterFormatString="original_{0}" SelectMethod="GetvueAccountCurrencyByAccountIdAndDisabled" TypeName="AccountCurrencyBLL" __designer:wfdid="w206"><SelectParameters __designer:dtid="281474976710725">
<asp:SessionParameter SessionField="AccountId" Name="AccountId" Type="Int32" __designer:dtid="281474976710726"></asp:SessionParameter>
<asp:Parameter Name="AccountCurrencyId" Type="Int32" __designer:dtid="281474976710727"></asp:Parameter>
</SelectParameters>
</asp:ObjectDataSource> 
</itemtemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Employee Rate %>">
        <itemstyle width="6%" horizontalalign="Center" verticalalign="Middle" />
        <itemtemplate>
<asp:TextBox id="EmployeeRateTextBox" runat="server" Width="55px" __designer:wfdid="w207"></asp:TextBox> 
</itemtemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Start Date %>">
        <itemstyle width="11%" horizontalalign="Center" verticalalign="Middle" />
        <ItemTemplate>
<cc1:CalendarPopup id="StartDateTextBox" runat="server" Text="..." Width="70px" 
                __designer:wfdid="w209"></cc1:CalendarPopup> 
</ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, End Date %>">
        <itemstyle width="11%" horizontalalign="Center" verticalalign="Middle" />
        <ItemTemplate>
<cc1:CalendarPopup id="EndDateTextBox" runat="server" Text="..." Width="70px" 
                __designer:wfdid="w210"></cc1:CalendarPopup> 
</ItemTemplate>
    </asp:TemplateField>
<asp:TemplateField><HeaderTemplate><asp:CheckBox 
                                ID="chkCheckAll" runat="server" Width="15px" /></HeaderTemplate><ItemTemplate><asp:CheckBox 
                                    ID="chkSelect" runat="server" Width="15px" /></ItemTemplate><HeaderStyle 
                                HorizontalAlign="Center" VerticalAlign="Middle" Width="15px" /><ItemStyle 
                                HorizontalAlign="Center" VerticalAlign="Middle" Width="1%" /></asp:TemplateField>
    <asp:TemplateField >
        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
        <itemstyle horizontalalign="Center" verticalalign="Middle" width="3%" />
        <ItemTemplate>
<asp:HyperLink id="HyperLink1" runat="server" Text="History" __designer:wfdid="w226" Visible='<%# IIF(IsDBNULL(Eval("AccountBillingRateId")) orelse Eval("AccountBillingRateId")=0,False,True) %>'></asp:HyperLink> 
</ItemTemplate>
    </asp:TemplateField>
</Columns>
</x:GridView> 
 
      <asp:ObjectDataSource id="dsAccountProjectEmployee" runat="server" 
        TypeName="AccountProjectEmployeeBLL" 
        SelectMethod="GetAccountProjectEmployeesForSelectionByAccountWorkTypeId" 
        OldValuesParameterFormatString="original_{0}" 
        OnInserting="dsAccountProjectEmployee_Inserting" 
        DeleteMethod="DeleteAccountProjectEmployeeId" 
        InsertMethod="AddAccountProjectEmployee" 
        UpdateMethod="UpdateAccountProjectEmployee">
        <DeleteParameters>
            <asp:Parameter Name="Original_AccountProjectEmployeeId" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="AccountId" Type="Int32" />
            <asp:Parameter Name="AccountProjectId" Type="Int32" />
            <asp:Parameter Name="AccountEmployeeId" Type="Int32" />
            <asp:Parameter Name="AccountRoleId" Type="Int32" />
            <asp:Parameter Name="AccountBillingRateId" Type="Int32" />
            <asp:Parameter Name="IsWebServiceCall" Type="Boolean" />
        </InsertParameters>
        <SelectParameters>
            <asp:SessionParameter DefaultValue="64" Name="AccountId" SessionField="AccountId"
                Type="Int32" />
            <asp:QueryStringParameter DefaultValue="1" Name="AccountProjectId" QueryStringField="AccountProjectId"
                Type="Int32" />
            <asp:Parameter Name="AccountWorkTypeId" Type="Int32" />
            <asp:ControlParameter ControlID="chkIsSelected" DefaultValue="" 
                Name="IsSelected" PropertyName="Checked" Type="Boolean" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="AccountId" Type="Int32" />
            <asp:Parameter Name="AccountProjectId" Type="Int32" />
            <asp:Parameter Name="AccountEmployeeId" Type="Int32" />
            <asp:Parameter Name="AccountRoleId" Type="Int32" />
            <asp:Parameter Name="AccountBillingRateId" Type="Int32" />
            <asp:Parameter Name="Original_AccountProjectEmployeeId" Type="Int32" />
        </UpdateParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource id="dsFilledAccountProjectEmployee" runat="server" TypeName="AccountProjectEmployeeBLL" SelectMethod="GetFilledRowsOfAccountProjectEmployee" OldValuesParameterFormatString="original_{0}" OnInserting="dsAccountProjectEmployee_Inserting">
        <SelectParameters>
            <asp:QueryStringParameter DefaultValue="1" Name="AccountProjectId" QueryStringField="AccountProjectId"
                Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="dsAccountWorkTypeObject" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetAccountWorkTypesByAccountId" TypeName="AccountWorkTypeBLL">
        <SelectParameters>
            <asp:SessionParameter Name="AccountId" SessionField="AccountId" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="dsAccountCurrencyObject" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetvueAccountCurrencyByAccountIdAndDisabled" TypeName="AccountCurrencyBLL">
        <SelectParameters>
            <asp:SessionParameter Name="AccountId" SessionField="AccountId" Type="Int32" />
            <asp:Parameter Name="AccountCurrencyId" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
</ContentTemplate>
</asp:UpdatePanel>
