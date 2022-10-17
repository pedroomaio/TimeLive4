<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlAccountProjectRoleList.ascx.vb" Inherits="ProjectAdmin_Controls_ctlAccountProjectRoleList" %>
<%@ Register Assembly="eWorld.UI.Compatibility, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2"
    Namespace="eWorld.UI.Compatibility" TagPrefix="cc1" %>
<%@ Register Src="ctlProjectView.ascx" TagName="ctlProjectView" TagPrefix="uc1" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <uc1:ctlProjectView ID="CtlProjectView1" runat="server" />
        <br />
        <div class="fieldset" style="width: 480px; margin-left: 3px;" align="left">
        <table class="xFormView" style="width: 500px">
    <tr>
        <td align="right" class="formviewlabelcell" style="width: 18%; font-weight:bold;">
            <asp:Literal ID="Literal5" runat="server" Text="<%$ Resources:TimeLive.Resource, Work Type:%> " /></td>
        <td align="left" colspan="3" style="width: 80%">
            <asp:DropDownList ID="ddlAccountWorkTypeId" runat="server" AutoPostBack="True" DataSourceID="dsAccountWorkTypeObject"
                DataTextField="AccountWorkType" DataValueField="AccountWorkTypeId" OnSelectedIndexChanged="ddlAccountWorkTypeId_SelectedIndexChanged"
                Width="200px">
            </asp:DropDownList>
            <asp:Label ID="lblWorkTypeValue" runat="server" Visible="False"></asp:Label></td>
            </tr>
        </table>
        </div>
                <x:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="dsAccountProjectRoleObject" Caption='<%# ResourceHelper.GetFromResource("Project Roles") %>' SkinID="xgridviewSkinEmployee" DataKeyNames="AccountProjectRoleId,AccountProjectId,AccountRoleId,BillingTypeId,AccountBillingRateId,StartDate,EndDate" Width="98%">
            <Columns>
                <asp:TemplateField HeaderText="Role" SortExpression="Role">
                    <edititemtemplate>
<asp:TextBox id="TextBox1" runat="server" Text='<%# Bind("Role") %>' __designer:wfdid="w177"></asp:TextBox> 
</edititemtemplate>
                    <headertemplate>
<asp:Label id="lblRole" runat="server" Text='<%# ResourceHelper.GetFromResource("Role") %>' __designer:wfdid="w178"></asp:Label> 
</headertemplate>
                    <itemstyle width="250px" />
                    <itemtemplate>
<asp:Label id="Label1" runat="server" Text='<%# Bind("Role") %>' __designer:wfdid="w176"></asp:Label> 
</itemtemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Number Of Resources">
                    <headertemplate>
<asp:Label id="lblNumberOfResources" runat="server" Text='<%# ResourceHelper.GetFromResource("Number Of Resources") %>' __designer:wfdid="w111"></asp:Label> 
</headertemplate>
                    <ItemStyle Width="1%" horizontalalign="Center" verticalalign="Middle" />
                    <ItemTemplate>
<asp:TextBox id="NumberOfResourcesTextBox" runat="server" Text='<%# Bind("NumberOfResources") %>' 
                            style="text-align:right;" Width="60px" __designer:wfdid="w109"></asp:TextBox><BR /><asp:RangeValidator id="RangeValidator4" runat="server" __designer:wfdid="w110" ControlToValidate="NumberOfResourcesTextBox" CssClass="ErrorMessage" Display="Dynamic" ErrorMessage="Numeric Required" Font-Bold="False" MaximumValue="50000" MinimumValue="1" Type="Integer"></asp:RangeValidator> 
</ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Billing Rate Currency">
                    <headertemplate>
<asp:Label id="lblBillingRateCurrency" runat="server" Text='<%# ResourceHelper.GetFromResource("Billing Rate Currency") %>' __designer:wfdid="w120"></asp:Label> 
</headertemplate>
                    <itemstyle width="3%" horizontalalign="Center" verticalalign="Middle" />
                    <itemtemplate>
<asp:DropDownList id="ddlBillingRateCurrencyId" runat="server" Width="80px" 
                            DataValueField="AccountCurrencyId" DataTextField="CurrencyCode" 
                            DataSourceID="dsBillingRateCurrencyObject" __designer:wfdid="w118"></asp:DropDownList><asp:ObjectDataSource id="dsBillingRateCurrencyObject" runat="server" __designer:dtid="562949953421374" TypeName="AccountCurrencyBLL" SelectMethod="GetvueAccountCurrencyByAccountIdAndDisabled" OldValuesParameterFormatString="original_{0}" __designer:wfdid="w119"><SelectParameters __designer:dtid="562949953421375">
<asp:SessionParameter SessionField="AccountId" Name="AccountId" Type="Int32" __designer:dtid="562949953421376"></asp:SessionParameter>
<asp:Parameter Name="AccountCurrencyId" Type="Int32" __designer:dtid="562949953421377"></asp:Parameter>
</SelectParameters>
</asp:ObjectDataSource> 
</itemtemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Billing Rate">
                    <headertemplate>
<asp:Label id="lblBillingRate" runat="server" Text='<%# ResourceHelper.GetFromResource("Billing Rate") %>' __designer:wfdid="w138"></asp:Label> 
</headertemplate>
                    <ItemStyle Width="1%" horizontalalign="Center" verticalalign="Middle" />
                    <ItemTemplate>
<asp:TextBox id="BillingRateTextBox" runat="server" Text='<%# Bind("BillingRate") %>' style="text-align:right;" Width="65px" 
                            __designer:wfdid="w136"></asp:TextBox><BR /><asp:RangeValidator id="RangeValidator3" runat="server" __designer:wfdid="w137" ControlToValidate="BillingRateTextBox" CssClass="ErrorMessage" Display="Dynamic" ErrorMessage="Numeric Required" Font-Bold="False" MaximumValue="50000" MinimumValue="0" Type="Double"></asp:RangeValidator> 
</ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Employee Rate Currency">
                    <headertemplate>
<asp:Label id="lblEmployeeRateCurrency" runat="server" Text='<%# ResourceHelper.GetFromResource("Employee Rate Currency") %>' __designer:wfdid="w126"></asp:Label> 
</headertemplate>
                    <itemstyle width="3%" horizontalalign="Center" verticalalign="Middle" />
                    <itemtemplate>
<asp:DropDownList id="ddlEmployeeRateCurrencyId" runat="server" Width="80px" 
                            DataValueField="AccountCurrencyId" DataTextField="CurrencyCode" 
                            DataSourceID="dsEmployeeRateCurrencyObject" __designer:wfdid="w124"></asp:DropDownList><asp:ObjectDataSource id="dsEmployeeRateCurrencyObject" runat="server" __designer:dtid="562949953421374" TypeName="AccountCurrencyBLL" SelectMethod="GetvueAccountCurrencyByAccountIdAndDisabled" OldValuesParameterFormatString="original_{0}" __designer:wfdid="w125"><SelectParameters __designer:dtid="562949953421375">
<asp:SessionParameter SessionField="AccountId" Name="AccountId" Type="Int32" __designer:dtid="562949953421376"></asp:SessionParameter>
<asp:Parameter Name="AccountCurrencyId" Type="Int32" __designer:dtid="562949953421377"></asp:Parameter>
</SelectParameters>
</asp:ObjectDataSource> 
</itemtemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Employee Rate">
                    <headertemplate>
<asp:Label id="lblEmployeeRate" runat="server" Text='<%# ResourceHelper.GetFromResource("Employee Rate") %>' __designer:wfdid="w141"></asp:Label> 
</headertemplate>
                    <itemstyle width="2%" horizontalalign="Center" verticalalign="Middle" />
                    <itemtemplate>
<asp:TextBox id="EmployeeRateTextBox" runat="server" Text='<%# Bind("EmployeeRate") %>' style="text-align:right;" Width="60px" 
                            __designer:wfdid="w139"></asp:TextBox><BR /><asp:RangeValidator id="rvEmployeeRate" runat="server" __designer:wfdid="w140" ControlToValidate="EmployeeRateTextBox" CssClass="ErrorMessage" Display="Dynamic" ErrorMessage="Numeric Required" Font-Bold="False" MaximumValue="50000" MinimumValue="0" Type="Double"></asp:RangeValidator> 
</itemtemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Billing Type" SortExpression="BillingType" Visible="False">
                    <headertemplate>
<asp:Label id="lblBillingType" runat="server" Text='<%# ResourceHelper.GetFromResource("Billing Type") %>' __designer:wfdid="w58"></asp:Label> 
</headertemplate>
                    <ItemStyle horizontalalign="Center" verticalalign="Middle" />
                    <ItemTemplate>
<asp:DropDownList id="ddlBillingTypeId" runat="server" DataValueField="AccountBillingTypeId" DataTextField="BillingType" DataSourceID="dsBillingTypeObject" __designer:wfdid="w56" Enabled="False"></asp:DropDownList><asp:ObjectDataSource id="dsBillingTypeObject" runat="server" TypeName="AccountBillingTypeBLL" SelectMethod="GetAccountBillingTypesForProjectByAccountId" OldValuesParameterFormatString="original_{0}" __designer:wfdid="w57">
                            <SelectParameters>
                                <asp:SessionParameter DefaultValue="64" Name="AccountId" SessionField="AccountId"
                                    Type="Int32" />
                            </SelectParameters>
                        </asp:ObjectDataSource> 
</ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Selected">
                    <headertemplate>
<asp:Label id="lblSelected" runat="server" Text='<%# ResourceHelper.GetFromResource("Selected") %>' __designer:wfdid="w182"></asp:Label> 
</headertemplate>
                    <ItemStyle HorizontalAlign="Center" verticalalign="Middle" width="0.5%" />
                    <ItemTemplate>
<asp:CheckBox id="chkSelect" runat="server" __designer:wfdid="w181" Checked='<%# IIF(IsDBNull(Eval("AccountProjectRoleId")),"false",Eval("AccountProjectRoleId")) %>'></asp:CheckBox> 
</ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="AccountProjectRoleId" HeaderText="AccountProjectRoleId"
                    InsertVisible="False" ReadOnly="True" SortExpression="AccountProjectRoleId" Visible="False" >
                </asp:BoundField>
                <asp:BoundField DataField="AccountProjectId" HeaderText="AccountProjectId" ReadOnly="True"
                    SortExpression="AccountProjectId" Visible="False" InsertVisible="False" >
                </asp:BoundField>
                <asp:BoundField DataField="AccountRoleId" HeaderText="AccountRoleId" ReadOnly="True"
                    SortExpression="AccountRoleId" Visible="False" InsertVisible="False" >
                </asp:BoundField>
                <asp:TemplateField HeaderText="Start Date">
                    <headertemplate>
<asp:Label id="lblStartDate" runat="server" Text='<%# ResourceHelper.GetFromResource("Start Date") %>' __designer:wfdid="w173"></asp:Label> 
</headertemplate>
                    <itemstyle horizontalalign="Center" verticalalign="Middle" width="10.5%" />
                    <ItemTemplate>
<cc1:calendarpopup id="StartDateTextBox" runat="server" Text="..." Width="65px" __designer:wfdid="w172"></cc1:calendarpopup> 
</ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="End Date">
                    <headertemplate>
<asp:Label id="lblEndDate" runat="server" Text='<%# ResourceHelper.GetFromResource("End Date") %>' __designer:wfdid="w175"></asp:Label> 
</headertemplate>
                    <itemstyle horizontalalign="Center" verticalalign="Middle" width="10.5%" />
                    <ItemTemplate>
<cc1:calendarpopup id="EndDateTextBox" runat="server" Text="..." Width="65px" __designer:wfdid="w174"></cc1:calendarpopup> 
</ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField >
                    <headertemplate>
<asp:Label id="lblBillingRateHistory" runat="server" Text='<%# ResourceHelper.GetFromResource("History") %>' __designer:wfdid="w149"></asp:Label> 
</headertemplate>
                    <itemstyle horizontalalign="Center" verticalalign="Middle" width="2%" />
                    <ItemTemplate>
<asp:HyperLink id="HyperLink1" runat="server" Text="History" __designer:wfdid="w65" Visible='<%# IIF(IsDBNULL(Eval("AccountBillingRateId")) orelse Eval("AccountBillingRateId")=0,False,True) %>'></asp:HyperLink>
</ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </x:GridView>
        <br />
        &nbsp;<asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" Text="Update" Width="55px" UseSubmitBehavior="false" />
        <asp:ObjectDataSource ID="dsAccountProjectRoleObject" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetAccountProjectRolesForSelectionByAccountWorkTypeId" TypeName="AccountProjectRoleBLL">
            <SelectParameters>
                <asp:QueryStringParameter DefaultValue="15" Name="AccountProjectId" QueryStringField="AccountProjectId"
                    Type="Int32" />
                <asp:Parameter Name="AccountWorkTypeId" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="dsAccountWorkTypeObject" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetAccountWorkTypesByAccountId" TypeName="AccountWorkTypeBLL">
            <SelectParameters>
                <asp:SessionParameter Name="AccountId" SessionField="AccountId" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </ContentTemplate>
</asp:UpdatePanel>
