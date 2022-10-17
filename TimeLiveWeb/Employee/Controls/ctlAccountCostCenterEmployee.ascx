<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlAccountCostCenterEmployee.ascx.vb" Inherits="Employee_Controls_ctlAccountCostCenterEmployee" %>
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
<x:GridView id="GridView1" runat="server" AutoGenerateColumns="False" 
    PageSize="25" DataSourceID="dsAccountCostCenterEmployee" 
    SkinID="xgridviewSkinEmployee" Caption='<%# ResourceHelper.GetFromResource("Cost Center Employee List") %>' Width="775px" 
    DataKeyNames="AccountCostCenterEmployeeId,AccountCostCenterId" OnDataBound="GridView1_DataBound" 
    OnRowDataBound="GridView1_RowDataBound"><Columns>
    <asp:TemplateField SortExpression="AccountCostCenter" HeaderText="<%$ Resources:TimeLive.Resource, Cost Center %>">
        <edititemtemplate>
            <asp:TextBox id="TextBox2" runat="server" __designer:wfdid="w38" Text='<%# Bind("AccountCostCenter") %>'></asp:TextBox> 
        </edititemtemplate>
         <headertemplate>
                <asp:LinkButton id="LinkButton4" runat="server" Text='<%# ResourceHelper.GetFromResource("Cost Center") %>' CommandArgument="AccountCostCenter" CommandName="Sort" CausesValidation="False"></asp:LinkButton>
         </headertemplate>
         <itemtemplate>
                <asp:Label id="Label2" runat="server" __designer:wfdid="w37" Text='<%# Bind("AccountCostCenter") %>'></asp:Label> 
         </itemtemplate>
                    <itemstyle width="90%" />
    </asp:TemplateField>
        <asp:BoundField DataField="AccountEmployeeId" HeaderText="AccountEmployeeId" InsertVisible="False"
            ReadOnly="True" SortExpression="AccountEmployeeId" Visible="False">
            <itemstyle width="0%" />
        </asp:BoundField>
<asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Selected %>">
        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
        <ItemStyle HorizontalAlign="Center" Width="10%" verticalalign="Middle" />
        <HeaderTemplate>
            <asp:CheckBox ID="chkCheckAll" runat="server" __designer:wfdid="w109" />
        </HeaderTemplate>
    <ItemTemplate>
        <asp:CheckBox id="chkSelect" runat="server" __designer:wfdid="w109" 
            Checked='<%# IIF(Isdbnull(Eval("AccountCostCenterEmployeeId")),"False","True") %>'></asp:CheckBox> 
</ItemTemplate>
    </asp:TemplateField>
    </Columns>
</x:GridView>
<br />
&nbsp;<asp:Button ID="Update" runat="server" 
    Text="<%$ Resources:TimeLive.Resource, Update_text%> " Width="60px" 
    UseSubmitBehavior="False" /><br />
<asp:ObjectDataSource ID="dsAccountCostCenterEmployee" runat="server" OldValuesParameterFormatString="original_{0}"
    OnInserting="dsAccountProjectEmployee_Inserting" SelectMethod="GetAccountCostCenterEmployeeByAccountIdandAccountEmployeeId"
    TypeName="AccountCostCenterBLL">
    <SelectParameters>
        <asp:SessionParameter DefaultValue="64" Name="AccountId" SessionField="AccountId"
            Type="Int32" />
        <asp:QueryStringParameter DefaultValue="151" Name="AccountEmployeeId" QueryStringField="AccountEmployeeId"
            Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>

