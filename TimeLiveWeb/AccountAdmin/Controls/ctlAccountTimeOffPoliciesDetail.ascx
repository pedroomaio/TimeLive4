<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlAccountTimeOffPoliciesDetail.ascx.vb" Inherits="AccountAdmin_Controls_ctlAccountTimeOffPoliciesDetail" %>
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
    <%If System.Configuration.ConfigurationManager.AppSettings("CarryForwardExpiryDate") <> "Yes" Then%>
    <style type=”text/css”>
    .hideGridColumn
    {
        display:none;
    }
    </style>
    <%End If%>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <asp:FormView ID="FormView1" runat="server" DataKeyNames="AccountTimeOffPolicyId"
            DataSourceID="dsTimeOffPoliciesDetailFormViewObject" DefaultMode="Insert" 
            Width="100%" SkinID="formviewSkinEmployee">
            <InsertItemTemplate>
                <table class="xview" width="99%">
                    <tr>
                        <th class="caption" colspan="2">
                            <asp:Literal ID="Literal4" runat="server" Text='<%# ResourceHelper.GetFromResource("Time Off Policy Information")%> ' /></th>
                    </tr>
                    
                    <tr>
                        <th class="FormViewSubHeader" colspan="2">
                            <asp:Literal ID="Literal1" runat="server" Text='<%# ResourceHelper.GetFromResource("Time Off Policy")%> ' /></th>
                    </tr>
                    <tr>
                        <td class="FormViewLabelCell" style="width: 25%;" align="right">
                           

<asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="txtTimeOffPolicy">
                            <asp:Literal ID="Literal2" runat="server" Text='<%# ResourceHelper.GetFromResource("Time Off Policy:")%> ' /></asp:Label></td><td 
                            style="width: 75%; padding-left: 3px;" align="left"><asp:TextBox ID="txtTimeOffPolicy" runat="server" Width="400px"></asp:TextBox><asp:RequiredFieldValidator
                                ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTimeOffPolicy"
                                CssClass="ErrorMessage" Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator></td></tr><tr>
                        <td colspan="2">
                            <x:GridView ID="GridView1" PageSize="500"  Font-Bold="False" 
                                runat="server" AutoGenerateColumns="False" Caption="<%$ Resources:TimeLive.Resource, Time Off Policies Detail List %>"
                                DataSourceID="dsTimeOffPoliciesDetailGridViewObject" Width="99%" 
                                CssClass="xGridViewInside" AllowSorting="True" 
                                DataKeyNames="AccountTimeOffPolicyDetailId,AccountTimeOffPolicyId,AccountTimeOffTypeId,SystemEarnPeriodId,SystemResetToZeroTypeId" 
                                OnRowDataBound="GridView1_RowDataBound" style="margin-right: 0px" 
                                ondatabound="GridView1_DataBound">
<Columns>
<asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Enabled %>" ><HeaderTemplate><asp:Label id="lblEnable" runat="server" Text='<%# ResourceHelper.GetFromResource("Enabled") %>' __designer:wfdid="w9"></asp:Label><br/><asp:CheckBox ID="chkCheckAll" 
                                            runat="server" AutoPostBack="True" Width="15px" Checked="False" /></HeaderTemplate><ItemTemplate><asp:CheckBox 
                                            ID="chkIsInclude" runat="server" Text='<%# Bind("IsInclude") %>' Checked="True" /></ItemTemplate><ItemStyle 
                                        HorizontalAlign="Center" Width="4%" /></asp:TemplateField>
                                        <asp:TemplateField 
                                        SortExpression="AccountTimeOffType" HeaderText="<%$ Resources:TimeLive.Resource, Time Off Type %>"><ItemTemplate><asp:Label ID="Label1" 
                                                runat="server" Text='<%# Bind("AccountTimeOffType") %>'></asp:Label></ItemTemplate><EditItemTemplate><asp:TextBox 
                                                ID="TextBox2" runat="server" Text='<%# Bind("AccountTimeOffType") %>'></asp:TextBox></EditItemTemplate><ItemStyle 
                                            Width="21%" /></asp:TemplateField>
                                            <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Effective Date%>">
    <itemtemplate>
<cc1:CalendarPopup id="EffectiveDateCalendarPopup" runat="server" Width="55px" Text="..." 
                                                __designer:wfdid="w73" SelectedDate=""></cc1:CalendarPopup> 
</itemtemplate>
    <itemstyle width="9.5%" HorizontalAlign="Center" /></asp:TemplateField>
     <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Carry Forward Expiry%>" HeaderStyle-CssClass = "hideGridColumn" ItemStyle-CssClass="hideGridColumn">
    <itemtemplate>
<cc1:CalendarPopup id="CarryForwardExpiryCalendarPopup" runat="server" Width="55px" Text="..." 
                                                __designer:wfdid="w73" SelectedDate=""></cc1:CalendarPopup> 
</itemtemplate>
    <itemstyle width="9.5%" HorizontalAlign="Center" /></asp:TemplateField>
<asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Initial Set to Hours %>" ><EditItemTemplate>
<asp:TextBox 
                                                id="TextBox1" runat="server" Text='<%# Bind("InitialSetToHours") %>' 
                                                __designer:wfdid="w25" style="text-align:right;" Width="5.5%"></asp:TextBox></EditItemTemplate><ItemTemplate>
<asp:TextBox id="InitialHoursTextBox" runat="server" style="text-align:right;" Width="82.5%" Text='<%# Bind("InitialSetToHours") %>' __designer:wfdid="w23"></asp:TextBox><asp:RangeValidator id="InitialHoursRangeValidator" runat="server" ErrorMessage="Incorrect value" Display="Dynamic" ControlToValidate="InitialHoursTextBox" __designer:wfdid="w24" Type="Double" MinimumValue="0" MaximumValue="99999" Font-Size="X-Small" Font-Names="Verdana" Font-Bold="False"></asp:RangeValidator></ItemTemplate>
<ItemStyle VerticalAlign="Top" Width="6%" HorizontalAlign="Center"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Earn Hours %>"><ItemTemplate>
<asp:TextBox id="EarnHourTextBox" 
                                                runat="server" style="text-align:right;" Width="82.5%" Text='<%# Bind("EarnHours") %>' 
                                                __designer:wfdid="w26"></asp:TextBox><asp:RangeValidator id="EarnHourRangeValidator" runat="server" ErrorMessage="Incorrect value" Display="Dynamic" ControlToValidate="EarnHourTextBox" __designer:wfdid="w27" Type="Double" MinimumValue="0" MaximumValue="99999" Font-Size="X-Small" Font-Names="Verdana" Font-Bold="False"></asp:RangeValidator></ItemTemplate>
                                                <ItemStyle VerticalAlign="Top" Width="6%" HorizontalAlign="Center">
                                                </ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Earn Period %>"><ItemTemplate>
<asp:DropDownList id="ddlSystemEarnPeriodId" runat="server" Width="100%" DataSourceID="dsSystemEarnPeriodObject" __designer:wfdid="w28" AppendDataBoundItems="True" DataTextField="SystemEarnPeriod" DataValueField="SystemEarnPeriodId"><asp:ListItem Value="0">Never</asp:ListItem></asp:DropDownList><asp:ObjectDataSource id="dsSystemEarnPeriodObject" runat="server" TypeName="SystemDataBLL" SelectMethod="GetSystemEarnPeriods" OldValuesParameterFormatString="original_{0}" __designer:wfdid="w29"></asp:ObjectDataSource> 
</ItemTemplate>

<ItemStyle VerticalAlign="Top" Width="14%" HorizontalAlign="Center"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Reset at %>"><ItemTemplate>
<asp:DropDownList id="ddlSystemResetToZeroTypeId" runat="server" Width="100%" DataSourceID="dsSystemResetToZeroObject" __designer:wfdid="w65" DataValueField="SystemResetToZeroTypeId" DataTextField="SystemResetToZeroType" AppendDataBoundItems="True"><asp:ListItem Value="0">Never</asp:ListItem></asp:DropDownList><asp:ObjectDataSource id="dsSystemResetToZeroObject" runat="server" TypeName="SystemDataBLL" SelectMethod="GetSystemResetToZeroType" OldValuesParameterFormatString="original_{0}" __designer:wfdid="w66"></asp:ObjectDataSource> 
</ItemTemplate>

<ItemStyle VerticalAlign="Top" Width="14%" HorizontalAlign="Center"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Reset Hours %>"><ItemTemplate>
<asp:TextBox 
                                                id="ResetToHoursTextBox" runat="server" style="text-align:right;" Width="78%" 
                                                Text='<%# Bind("ResetToHours") %>' __designer:wfdid="w30"></asp:TextBox><asp:RangeValidator id="ResetToHoursRangeValidator" runat="server" ErrorMessage="Incorrect value" Display="Dynamic" ControlToValidate="ResetToHoursTextBox" __designer:wfdid="w31" Type="Double" MinimumValue="0" MaximumValue="99999" Font-Size="X-Small" Font-Names="Verdana" Font-Bold="False"></asp:RangeValidator></ItemTemplate>
                                                <ItemStyle VerticalAlign="Top" Width="5%" HorizontalAlign="Center"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Maximum Available %>"><EditItemTemplate>
</EditItemTemplate><ItemTemplate>
<asp:TextBox id="AvailableTextBox" runat="server" style="text-align:right;" Width="78%" 
                                                Text='<%# Bind("MaximumAvailable") %>' __designer:wfdid="w32"></asp:TextBox><asp:RangeValidator id="AvailableRangeValidator" runat="server" ErrorMessage="Incorrect value" Display="Dynamic" ControlToValidate="AvailableTextBox" __designer:wfdid="w33" Type="Double" MinimumValue="0" MaximumValue="99999" Font-Size="X-Small" Font-Names="Verdana" Font-Bold="False"></asp:RangeValidator></ItemTemplate>
                                                <ItemStyle VerticalAlign="Top" Width="5%" HorizontalAlign="Center"></ItemStyle>
</asp:TemplateField>

 <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Additional Hours %>"><Edititemtemplate>
</edititemtemplate><itemtemplate>
<asp:TextBox id="txtAdditionalHours" runat="server" style="text-align:right;" Width="78%" Text='<%# Bind("AdditionalHours") %>' __designer:wfdid="w56"></asp:TextBox>
<asp:RangeValidator id="AdditionalHoursRangeValidator" runat="server" ErrorMessage="Incorrect value" Display="Dynamic" ControlToValidate="txtAdditionalHours" __designer:wfdid="w57" Type="Double" MinimumValue="0" MaximumValue="99999" Font-Size="X-Small" Font-Names="Verdana" Font-Bold="False">
</asp:RangeValidator>
</itemtemplate>
<ItemStyle VerticalAlign="Top" Width="5%" HorizontalAlign="Center"></ItemStyle>
</asp:TemplateField>
 
</Columns>
                            </x:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="right" style="padding-bottom: 5px;padding-Right: 5px;padding-Top: 5px">
                            <asp:Button 
                                ID="btnAdd" runat="server" OnClick="btnAdd_Click" 
                                Text="<%$ Resources:TimeLive.Resource, Add_text%> " Width="68px" />
                                <asp:Button 
                            ID="btnCancel" runat="server" CommandName="Cancel" OnClick="btnCancel_Click" 
                            Text="<%$ Resources:TimeLive.Resource, Cancel_text%>" ValidationGroup="Add" 
                            Width="60px" /></td>
                    </tr>
                </table>
            </InsertItemTemplate>
            <EditItemTemplate>
                <table class="xview" width="99%">
                    <tr>
                        <th class="caption" colspan="2">
                            <asp:Literal ID="Literal5" runat="server" Text='<%# ResourceHelper.GetFromResource("Time Off Policy Information")%> ' /></th>
                    </tr>
                    <tr>
                        <th class="FormViewSubHeader" colspan="2">
                            <asp:Literal ID="Literal3" runat="server" Text='<%# ResourceHelper.GetFromResource("Time Off Policy")%> ' /></th>
                    </tr>
                    <tr>
                        <td class="FormViewLabelCell" style="width: 25%;" align="right">
                            
                    <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="txtTimeOffPolicy">
                            <asp:Literal ID="Literal6" runat="server" Text='<%# ResourceHelper.GetFromResource("Time Off Policy:")%> ' /></asp:Label></td><td style="width: 75%; padding-left: 3px;">
                            <asp:TextBox ID="txtTimeOffPolicy" runat="server" Width="400px" Text='<%# Bind("AccountTimeOffPolicy") %>'></asp:TextBox><asp:RequiredFieldValidator
                                ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTimeOffPolicy"
                                CssClass="ErrorMessage" Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator></td></tr>
                    <tr>
                        <td align="right" class="FormViewLabelCell" style="width: 25%">
                            <asp:Literal ID="Literal7" runat="server" Text='<%# ResourceHelper.GetFromResource("Disabled:")%> ' /></td>
                        <td style="width: 75%; padding-left: 5px;">
                            <asp:CheckBox ID="chkIsDisabled" runat="server" Checked='<%# Bind("IsDisabled") %>' /></td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <x:GridView ID="GridView1" PageSize="500"  Font-Bold="False" 
                                runat="server" AutoGenerateColumns="False" Caption="<%$ Resources:TimeLive.Resource, Time Off Policies Detail List %>"
                                DataSourceID="dsTimeOffPoliciesDetailGridViewObject" Width="99%" 
                                CssClass="xGridViewInside" AllowSorting="True" 
                                DataKeyNames="AccountTimeOffPolicyDetailId,AccountTimeOffPolicyId,AccountTimeOffTypeId,SystemEarnPeriodId,SystemResetToZeroTypeId" 
                                OnRowDataBound="GridView1_RowDataBound1" 
                                ondatabound="GridView1_DataBound1">
<Columns>
                                                  <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Enabled %>"><EditItemTemplate><asp:CheckBox 
                                            ID="chkIsInclude" runat="server" Checked="True" /></EditItemTemplate><HeaderTemplate>
                                            <asp:Label id="lblEnable" runat="server" Text='<%# ResourceHelper.GetFromResource("Enabled") %>' __designer:wfdid="w9"></asp:Label></br><asp:CheckBox 
                                                          ID="chkCheckAll" runat="server" AutoPostBack="True" Width="15px" /></HeaderTemplate><ItemTemplate><asp:CheckBox 
                                            ID="chkIsInclude" runat="server" Checked="True" /></ItemTemplate><ItemStyle 
                                        HorizontalAlign="Center" Width="4%" /></asp:TemplateField>
                                        <asp:BoundField DataField="AccountTimeOffType" HeaderText="<%$ Resources:TimeLive.Resource, Time Off Type %>" SortExpression="AccountTimeOffType" >
                                        <itemstyle 
                                        width="21%" /></asp:BoundField>
<asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Effective Date%>">
<ItemTemplate>
<cc1:CalendarPopup id="EffectiveDateCalendarPopup" runat="server" Width="55px" Text="..." 
                                                __designer:wfdid="w83" SelectedDate=""></cc1:CalendarPopup> 
</ItemTemplate>
<ItemStyle Width="9.5%" HorizontalAlign="Center"></ItemStyle>
</asp:TemplateField>
 <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Carry Forward Expiry%>"  HeaderStyle-CssClass = "hideGridColumn" ItemStyle-CssClass="hideGridColumn">
    <itemtemplate>
<cc1:CalendarPopup id="CarryForwardExpiryCalendarPopup" runat="server" Width="55px" Text="..." 
                                                __designer:wfdid="w73" SelectedDate=""></cc1:CalendarPopup> 
</itemtemplate>
    <itemstyle width="9.5%" HorizontalAlign="Center" /></asp:TemplateField>
                                    <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Initial Set to Hours %>">
                                        <edititemtemplate>
<asp:TextBox id="TextBox1" runat="server" 
                                                Text='<%# Bind("InitialSetToHours") %>' __designer:wfdid="w45" style="text-align:right;" Width="5.5%"></asp:TextBox></edititemtemplate><itemtemplate>
<asp:TextBox 
                                                id="InitialHoursTextBox" runat="server" style="text-align:right;" Width="82.5%" 
                                                Text='<%# Bind("InitialSetToHours") %>' __designer:wfdid="w43"></asp:TextBox><asp:RangeValidator id="InitialHoursRangeValidator" runat="server" ErrorMessage="Incorrect value" Display="Dynamic" ControlToValidate="InitialHoursTextBox" __designer:wfdid="w44" Type="Double" MinimumValue="0" MaximumValue="99999" Font-Size="X-Small" Font-Names="Verdana" Font-Bold="False"></asp:RangeValidator></itemtemplate>
                                                <itemstyle verticalalign="Top" width="6%" HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Earn Hours %>">
                                        <itemtemplate>
<asp:TextBox id="EarnHourTextBox" runat="server" style="text-align:right;" Width="82.5%" 
                                                Text='<%# Bind("EarnHours") %>' __designer:wfdid="w46"></asp:TextBox><asp:RangeValidator id="EarnHourRangeValidator" runat="server" ErrorMessage="Incorrect value" Display="Dynamic" ControlToValidate="EarnHourTextBox" __designer:wfdid="w47" Type="Double" MinimumValue="0" MaximumValue="99999" Font-Size="X-Small" Font-Names="Verdana" Font-Bold="False"></asp:RangeValidator></itemtemplate>
                                                <itemstyle width="6%" verticalalign="Top" HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Earn Period %>">
                                        <itemtemplate>
<asp:DropDownList id="ddlSystemEarnPeriodId" runat="server" Width="100%" DataSourceID="dsSystemEarnPeriodObject" __designer:wfdid="w50" AppendDataBoundItems="True" DataTextField="SystemEarnPeriod" DataValueField="SystemEarnPeriodId"><asp:ListItem Value="0">Never</asp:ListItem></asp:DropDownList><asp:ObjectDataSource id="dsSystemEarnPeriodObject" runat="server" TypeName="SystemDataBLL" SelectMethod="GetSystemEarnPeriods" OldValuesParameterFormatString="original_{0}" __designer:wfdid="w51"></asp:ObjectDataSource> 
</itemtemplate>
                                        <itemstyle width="14%" verticalalign="Top" HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Reset At %>">
                                        <itemtemplate>
<asp:DropDownList id="ddlSystemResetToZeroTypeId" runat="server" Width="100%" DataSourceID="dsSystemResetToZeroObject" __designer:wfdid="w52" AppendDataBoundItems="True" DataTextField="SystemResetToZeroType" DataValueField="SystemResetToZeroTypeId"><asp:ListItem Value="0">Never</asp:ListItem></asp:DropDownList><asp:ObjectDataSource id="dsSystemResetToZeroObject" runat="server" TypeName="SystemDataBLL" SelectMethod="GetSystemResetToZeroType" OldValuesParameterFormatString="original_{0}" __designer:wfdid="w53"></asp:ObjectDataSource> 
</itemtemplate>
                                        <itemstyle width="14%" verticalalign="Top" HorizontalAlign="Center"/>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Reset Hours %>">
                                        <itemtemplate>
<asp:TextBox id="ResetToHoursTextBox" runat="server" style="text-align:right;" Width="78%" 
                                                Text='<%# Bind("ResetToHours") %>' __designer:wfdid="w54"></asp:TextBox><asp:RangeValidator id="ResetToHoursRangeValidator" runat="server" ErrorMessage="Incorrect value" Display="Dynamic" ControlToValidate="ResetToHoursTextBox" __designer:wfdid="w55" Type="Double" MinimumValue="0" MaximumValue="99999" Font-Size="X-Small" Font-Names="Verdana" Font-Bold="False"></asp:RangeValidator>
                                                </itemtemplate><itemstyle width="5%" verticalalign="Top" HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Maximum Available %>">
                                        <edititemtemplate>
</edititemtemplate><itemtemplate>
<asp:TextBox id="AvailableTextBox" runat="server" style="text-align:right;" Width="78%" 
Text='<%# Bind("MaximumAvailable") %>' __designer:wfdid="w56"></asp:TextBox><asp:RangeValidator id="AvailableRangeValidator" runat="server" ErrorMessage="Incorrect value" Display="Dynamic" ControlToValidate="AvailableTextBox" __designer:wfdid="w57" Type="Double" MinimumValue="0" MaximumValue="99999" Font-Size="X-Small" Font-Names="Verdana" Font-Bold="False"></asp:RangeValidator>
</itemtemplate><itemstyle width="5%" verticalalign="Top" HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Additional Hours %>"><Edititemtemplate>
</edititemtemplate><itemtemplate>
<asp:TextBox id="txtAdditionalHours" runat="server" style="text-align:right;" Width="78%" Text='<%# Bind("AdditionalHours") %>' __designer:wfdid="w56"></asp:TextBox>
<asp:RangeValidator id="AdditionalHoursRangeValidator" runat="server" ErrorMessage="Incorrect value" Display="Dynamic" ControlToValidate="txtAdditionalHours" __designer:wfdid="w57" Type="Double" MinimumValue="0" MaximumValue="99999" Font-Size="X-Small" Font-Names="Verdana" Font-Bold="False">
</asp:RangeValidator>
</itemtemplate>
<ItemStyle VerticalAlign="Top" Width="5%" HorizontalAlign="Center"></ItemStyle>
</asp:TemplateField>                   

</Columns>
                            </x:GridView>
</td>
</tr>
                    <tr>
                        <td colspan="2" align="right" style="padding-bottom: 5px;padding-Right: 5px;padding-Top: 5px">
                            <asp:Button 
                                ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" 
                                Text="<%$ Resources:TimeLive.Resource, Update_Text%> " Width="68px" />
                                 <asp:Button 
                                ID="btnCancel" runat="server" CommandName="Cancel" onclick="btnCancel_Click1" 
                                Text="<%$ Resources:TimeLive.Resource, Cancel_text%>" Width="68px" /></td>
                    </tr>
                </table>
            </EditItemTemplate>
        </asp:FormView>
        <asp:ObjectDataSource ID="dsTimeOffPoliciesDetailFormViewObject" runat="server"
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetAccountTimeOffPolicyByAccountTimeOffPolicyId"
            TypeName="AccountTimeOffPolicyBLL" DataObjectTypeName="System.Guid" 
            DeleteMethod="DeleteAccountTimeOffPolicy" 
            InsertMethod="UpdateAccountTimeOffPolicyDetail" 
            UpdateMethod="UpdateAccountTimeOffPolicy"><InsertParameters><asp:Parameter 
                    DbType="Guid" Name="AccountTimeOffPolicyDetailId" /><asp:Parameter 
                    DbType="Guid" Name="AccountTimeOffPolicyId" /><asp:Parameter DbType="Guid" 
                    Name="AccountTimeOffTypeId" /><asp:Parameter DbType="Guid" 
                    Name="SystemEarnPeriodId" /><asp:Parameter DbType="Guid" 
                    Name="SystemResetToZeroTypeId" /><asp:Parameter Name="InitialSetToHours" 
                    Type="Double" /><asp:Parameter Name="ResetToHours" Type="Decimal" /><asp:Parameter 
                    Name="EarnHours" Type="Decimal" /><asp:Parameter Name="MaximumAvailable" 
                    Type="Decimal" /><asp:Parameter Name="EffectiveDate" Type="DateTime" /><asp:Parameter 
                    Name="IsInclude" Type="Boolean" /></InsertParameters><SelectParameters>
                <asp:Parameter   
                    Name="AccountTimeOffPolicyId" DbType="Guid" /></SelectParameters>
        <UpdateParameters><asp:Parameter Name="AccountTimeOffPolicy" Type="String" /><asp:Parameter 
                    DbType="Guid" Name="Original_AccountTimeOffPolicyId" /><asp:Parameter 
                    Name="ModifiedByEmployeeId" Type="Int32" /><asp:Parameter Name="IsDisabled" 
                    Type="Boolean" /></UpdateParameters></asp:ObjectDataSource>
        <asp:ObjectDataSource 
            ID="dsTimeOffPoliciesDetailGridViewObject" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetvueAccountTimeOffPolicyDetailByAccountTimeOffPolicyId" 
            TypeName="AccountTimeOffPolicyBLL" DataObjectTypeName="System.Guid" 
            DeleteMethod="DeleteAccountTimeOffPolicy" 
            InsertMethod="UpdateAccountTimeOffPolicyDetail" 
            UpdateMethod="UpdateAccountTimeOffPolicy"><InsertParameters><asp:Parameter 
                    DbType="Guid" Name="AccountTimeOffPolicyDetailId" /><asp:Parameter 
                    DbType="Guid" Name="AccountTimeOffPolicyId" /><asp:Parameter DbType="Guid" 
                    Name="AccountTimeOffTypeId" /><asp:Parameter DbType="Guid" 
                    Name="SystemEarnPeriodId" /><asp:Parameter DbType="Guid" 
                    Name="SystemResetToZeroTypeId" /><asp:Parameter Name="InitialSetToHours" 
                    Type="Double" /><asp:Parameter Name="ResetToHours" Type="Decimal" /><asp:Parameter 
                    Name="EarnHours" Type="Decimal" /><asp:Parameter Name="MaximumAvailable" 
                    Type="Decimal" /><asp:Parameter Name="EffectiveDate" Type="DateTime" /><asp:Parameter 
                    Name="IsInclude" Type="Boolean" /></InsertParameters><SelectParameters>
                <asp:SessionParameter Name="AccountId" SessionField="AccountId" Type="Int32" />
                <asp:Parameter 
                    DbType="Guid" Name="AccountTimeOffPolicyId" /></SelectParameters>
        <UpdateParameters><asp:Parameter Name="AccountTimeOffPolicy" Type="String" /><asp:Parameter 
                    DbType="Guid" Name="Original_AccountTimeOffPolicyId" /><asp:Parameter 
                    Name="ModifiedByEmployeeId" Type="Int32" /><asp:Parameter Name="IsDisabled" 
                    Type="Boolean" /></UpdateParameters></asp:ObjectDataSource>
    </ContentTemplate>
</asp:UpdatePanel>
