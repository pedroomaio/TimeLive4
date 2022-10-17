<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlAccountBillingRateList.ascx.vb" Inherits="AccountAdmin_Controls_ctlAccountBillingRateList" %>
<%@ Register Assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2"
    Namespace="eWorld.UI" TagPrefix="ew" %>
<%@ Register Assembly="eWorld.UI.Compatibility, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2"
    Namespace="eWorld.UI.Compatibility" TagPrefix="cc1" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    <table class="xFormView" width="45%"><tr><td>
        <table class="xFormView" style="width: 100%">
            <tr>
                <th class="caption" colspan="2">
                    <asp:Literal ID="Literal1" runat="server" Text="<%$ Resources:TimeLive.Resource, Project And Employee Information%> " /></th>
            </tr>
            <tr>
                <td align="right" class="formviewlabelcell" style="width: 13%">
                            <asp:Literal ID="Literal2" runat="server" Text="<%$ Resources:TimeLive.Resource, Billing Rate Type:%> " /></td>
                <td align="left" colspan="1" style="width: 50%">
                    <asp:DropDownList ID="ddlSystemBillingRateTypeId" runat="server" 
                        AppendDataBoundItems="True" Enabled="False" Width="250px">
                                <asp:ListItem Selected="True" Value="1">Employee Own Billing Rate</asp:ListItem>
                                <asp:ListItem Value="2">Project Role Billing Rate</asp:ListItem>
                        <asp:ListItem Value="3">Project Employee Billing Rate</asp:ListItem>
                        <asp:ListItem Value="4">Project Task Billing Rate</asp:ListItem>
                            </asp:DropDownList></td>
            </tr>
                        <% If ddlSystemBillingRateTypeId.SelectedValue <> 4 Then%>
            <% If ddlSystemBillingRateTypeId.SelectedValue <> 2 Then%>
            <tr>
                <td align="right" class="formviewlabelcell" style="width: 13%">
                    <asp:Literal ID="Literal3" runat="server" Text="<%$ Resources:TimeLive.Resource, Work Type:%> " /></td>
                <td align="left" colspan="1" style="width: 50%">
                    <asp:DropDownList ID="ddlAccountWorkTypeId" runat="server" Enabled="False" 
                        DataSourceID="dsAccountWorkTypeObject" DataTextField="AccountWorkType" 
                        DataValueField="AccountWorkTypeId" Width="250px">
                    </asp:DropDownList><asp:ObjectDataSource ID="dsAccountWorkTypeObject" runat="server"
                        OldValuesParameterFormatString="original_{0}" SelectMethod="GetAccountWorkTypesByAccountWorkTypeId"
                        TypeName="AccountWorkTypeBLL">
                        <SelectParameters>
                            <asp:QueryStringParameter Name="AccountWorkTypeId" QueryStringField="AccountWorkTypeId"
                                Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </td>
            </tr>
            <tr>
                <td align="right" class="formviewlabelcell" style="width: 13%">
                    <asp:Label ID="lblEmployeeName" runat="server" Font-Names="Tahoma" Font-Size="11px"
                        Text="<%$ Resources:TimeLive.Resource, Employee Name:%> " /></td>
                <td align="left" colspan="1" style="width: 50%">
                    <asp:TextBox ID="EmployeeNameTextBox" runat="server" Width="238px" 
                        ReadOnly="True"></asp:TextBox></td>
            </tr>
             <% End If%>
            <% End If%>
            <%If ddlSystemBillingRateTypeId.SelectedValue <> 1 Then%>
            <tr>
                <td align="right" class="formviewlabelcell" style="width: 13%">
                    <asp:Label ID="lblProjectName" runat="server" Font-Names="Tahoma" Font-Size="11px"
                        Text="<%$ Resources:TimeLive.Resource, Project Name:%> " /></td>
                <td align="left" style="width: 50%">
                    <asp:TextBox ID="ProjectNameTextBox" runat="server" Width="238px" 
                        ReadOnly="True"></asp:TextBox></td>
            </tr>
                        <% If ddlSystemBillingRateTypeId.SelectedValue <> 2 Then%>
            <% If ddlSystemBillingRateTypeId.SelectedValue <> 3 Then%>
            <tr>
                <td align="right" class="formviewlabelcell" style="width: 13%">
                    <asp:Label ID="lblProjectTaskName" runat="server" Font-Names="Tahoma" Font-Size="11px"
                        Text="Project Task Name:"></asp:Label></td>
                <td align="left" style="width: 50%">
                    <asp:TextBox ID="ProjectTaskTextBox" runat="server" ReadOnly="True" 
                        Width="238px"></asp:TextBox></td>
            </tr>
            <% End If%>
            <% End If%>
            <% End If%>
        </table>
        </td></tr></table>
    </ContentTemplate>
</asp:UpdatePanel>
<br />
<asp:UpdatePanel ID="UpdatePanel2" runat="server">
    <ContentTemplate>
        <x:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="AccountBillingRateId"
            DataSourceID="dsAccountBillingRateGridViewObject" Caption="<%$ Resources:TimeLive.Resource, Billing Rate List%> " SkinID="xgridviewSkinEmployee" Width="98%" AllowSorting="True" CssClass="TableView">
            <Columns>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Billing Rate%> " SortExpression="BillingRate">
                    <edititemtemplate>
<asp:TextBox id="TextBox1" runat="server" Text='<%# Bind("BillingRate") %>' __designer:wfdid="w155"></asp:TextBox> 
</edititemtemplate>
                    <itemtemplate>
<asp:Label id="Label3" runat="server" Text='<%# Bind("BillingRateCurrencyCode") %>' __designer:wfdid="w20"></asp:Label>&nbsp;<asp:Label id="Label1" runat="server" Text='<%# Bind("BillingRate") %>' __designer:wfdid="w154"></asp:Label> 
</itemtemplate>
                    <itemstyle horizontalalign="Right" verticalalign="Middle" width="25%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Employee Rate%> " SortExpression="EmployeeRate">
                    <edititemtemplate>
<asp:TextBox id="TextBox2" runat="server" Text='<%# Bind("EmployeeRate") %>' __designer:wfdid="w158"></asp:TextBox> 
</edititemtemplate>
                    <itemtemplate>
<asp:Label id="Label4" runat="server" Text='<%# Bind("EmployeeRateCurrencyCode") %>' __designer:wfdid="w23"></asp:Label>&nbsp;<asp:Label id="Label2" runat="server" Text='<%# Bind("EmployeeRate") %>' __designer:wfdid="w157"></asp:Label> 
</itemtemplate>
                    <itemstyle horizontalalign="Right" verticalalign="Middle" width="25%" />
                </asp:TemplateField>
                <asp:BoundField DataField="StartDate" HeaderText="<%$ Resources:TimeLive.Resource, Start Date%> " SortExpression="StartDate" DataFormatString="{0:d}" HtmlEncode="False" >
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="15%" />
                </asp:BoundField>
                <asp:BoundField DataField="EndDate" HeaderText="<%$ Resources:TimeLive.Resource, End Date%> " SortExpression="EndDate" DataFormatString="{0:d}" HtmlEncode="False" >
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="15%" />
                </asp:BoundField>
                <asp:CommandField HeaderText="<%$ Resources:TimeLive.Resource, Edit_text%> " SelectText="Edit" ShowSelectButton="True" >
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="1%" cssclass="edit_button" />
                </asp:CommandField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Delete_text%> " ShowHeader="False">
                    <itemtemplate>
<asp:LinkButton id="LinkButton1" runat="server" Text="Delete" CausesValidation="False" CommandName="Delete" __designer:wfdid="w8" OnClientClick='<%# ResourceHelper.GetDeleteMessageJavascript()%>'></asp:LinkButton> 
</itemtemplate>
                    <itemstyle cssclass="delete_button" horizontalalign="Center" verticalalign="Middle"
                        width="1%" />
                </asp:TemplateField>
            </Columns>
        </x:GridView>
        <asp:ObjectDataSource ID="dsAccountBillingRateGridViewObject" runat="server" DeleteMethod="DeleteAccountBillingRate"
            InsertMethod="AddAccountBillingRate" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetAccountBillingRates" TypeName="AccountBillingRateBLL" UpdateMethod="UpdateAccountBillingRate">
            <DeleteParameters>
                <asp:Parameter Name="Original_AccountBillingRateId" Type="Int32" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="AccountId" Type="Int32" />
                <asp:Parameter Name="SystemBillingRateTypeId" Type="Int16" />
                <asp:Parameter Name="AccountProjectEmployeeId" Type="Int64" />
                <asp:Parameter Name="AccountProjectRoleId" Type="Int32" />
                <asp:Parameter Name="AccountEmployeeId" Type="Int32" />
                <asp:Parameter Name="BillingRate" Type="Decimal" />
                <asp:Parameter Name="StartDate" Type="DateTime" />
                <asp:Parameter Name="EndDate" Type="DateTime" />
                <asp:Parameter Name="AccountProjectTaskId" Type="Int32" />
                <asp:Parameter Name="AccountWorkTypeId" Type="Int32" />
                <asp:Parameter Name="EmployeeRate" Type="Decimal" />
                <asp:Parameter Name="BillingRateCurrencyId" Type="Int32" />
                <asp:Parameter Name="EmployeeRateCurrencyId" Type="Int32" />
                <asp:Parameter Name="Original_AccountBillingRateId" Type="Int32" />
            </UpdateParameters>
            <InsertParameters>
                <asp:Parameter Name="AccountId" Type="Int32" />
                <asp:Parameter Name="SystemBillingRateTypeId" Type="Int16" />
                <asp:Parameter Name="AccountProjectEmployeeId" Type="Int64" />
                <asp:Parameter Name="AccountProjectRoleId" Type="Int32" />
                <asp:Parameter Name="AccountEmployeeId" Type="Int32" />
                <asp:Parameter Name="AccountProjectTaskId" Type="Int32" />
                <asp:Parameter Name="BillingRate" Type="Decimal" />
                <asp:Parameter Name="StartDate" Type="DateTime" />
                <asp:Parameter Name="EndDate" Type="DateTime" />
                <asp:Parameter Name="AccountWorkTypeId" Type="Int32" />
                <asp:Parameter Name="EmployeeRate" Type="Decimal" />
                <asp:Parameter Name="BillingRateCurrencyId" Type="Int32" />
                <asp:Parameter Name="EmployeeRateCurrencyId" Type="Int32" />
            </InsertParameters>
        </asp:ObjectDataSource><asp:ObjectDataSource ID="dsAccountEmployeeBillingRate" runat="server" DeleteMethod="DeleteAccountBillingRate"
            InsertMethod="AddAccountBillingRate" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetAccountBillingRatesByAccountEmployeeId" TypeName="AccountBillingRateBLL" UpdateMethod="UpdateAccountBillingRate">
            <DeleteParameters>
                <asp:Parameter Name="Original_AccountBillingRateId" Type="Int32" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="AccountId" Type="Int32" />
                <asp:Parameter Name="SystemBillingRateTypeId" Type="Int16" />
                <asp:Parameter Name="AccountProjectEmployeeId" Type="Int64" />
                <asp:Parameter Name="AccountProjectRoleId" Type="Int32" />
                <asp:Parameter Name="AccountEmployeeId" Type="Int32" />
                <asp:Parameter Name="BillingRate" Type="Decimal" />
                <asp:Parameter Name="StartDate" Type="DateTime" />
                <asp:Parameter Name="EndDate" Type="DateTime" />
                <asp:Parameter Name="AccountProjectTaskId" Type="Int32" />
                <asp:Parameter Name="AccountWorkTypeId" Type="Int32" />
                <asp:Parameter Name="EmployeeRate" Type="Decimal" />
                <asp:Parameter Name="BillingRateCurrencyId" Type="Int32" />
                <asp:Parameter Name="EmployeeRateCurrencyId" Type="Int32" />
                <asp:Parameter Name="Original_AccountBillingRateId" Type="Int32" />
            </UpdateParameters>
            <SelectParameters>
                <asp:QueryStringParameter Name="AccountEmployeeId" QueryStringField="AccountEmployeeId"
                    Type="Int32" />
                <asp:QueryStringParameter Name="AccountWorkTypeId" QueryStringField="AccountWorkTypeId"
                    Type="Int32" />
            </SelectParameters>
            <InsertParameters>
                <asp:Parameter Name="AccountId" Type="Int32" />
                <asp:Parameter Name="SystemBillingRateTypeId" Type="Int16" />
                <asp:Parameter Name="AccountProjectEmployeeId" Type="Int64" />
                <asp:Parameter Name="AccountProjectRoleId" Type="Int32" />
                <asp:Parameter Name="AccountEmployeeId" Type="Int32" />
                <asp:Parameter Name="AccountProjectTaskId" Type="Int32" />
                <asp:Parameter Name="BillingRate" Type="Decimal" />
                <asp:Parameter Name="StartDate" Type="DateTime" />
                <asp:Parameter Name="EndDate" Type="DateTime" />
                <asp:Parameter Name="AccountWorkTypeId" Type="Int32" />
                <asp:Parameter Name="EmployeeRate" Type="Decimal" />
                <asp:Parameter Name="BillingRateCurrencyId" Type="Int32" />
                <asp:Parameter Name="EmployeeRateCurrencyId" Type="Int32" />
            </InsertParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="dsAccountProjectRoleBillingRate" runat="server" DeleteMethod="DeleteAccountBillingRate"
            InsertMethod="AddAccountBillingRate" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetAccountBillingRatesByAccountProjectRoleId" TypeName="AccountBillingRateBLL" UpdateMethod="UpdateAccountBillingRate">
            <DeleteParameters>
                <asp:Parameter Name="Original_AccountBillingRateId" Type="Int32" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="AccountId" Type="Int32" />
                <asp:Parameter Name="SystemBillingRateTypeId" Type="Int16" />
                <asp:Parameter Name="AccountProjectEmployeeId" Type="Int64" />
                <asp:Parameter Name="AccountProjectRoleId" Type="Int32" />
                <asp:Parameter Name="AccountEmployeeId" Type="Int32" />
                <asp:Parameter Name="BillingRate" Type="Decimal" />
                <asp:Parameter Name="StartDate" Type="DateTime" />
                <asp:Parameter Name="EndDate" Type="DateTime" />
                <asp:Parameter Name="AccountProjectTaskId" Type="Int32" />
                <asp:Parameter Name="AccountWorkTypeId" Type="Int32" />
                <asp:Parameter Name="EmployeeRate" Type="Decimal" />
                <asp:Parameter Name="BillingRateCurrencyId" Type="Int32" />
                <asp:Parameter Name="EmployeeRateCurrencyId" Type="Int32" />
                <asp:Parameter Name="Original_AccountBillingRateId" Type="Int32" />
            </UpdateParameters>
            <SelectParameters>
                <asp:QueryStringParameter Name="AccountProjectRoleId" QueryStringField="AccountProjectRoleId"
                    Type="Int32" />
                <asp:QueryStringParameter Name="AccountWorkTypeId" QueryStringField="AccountWorkTypeId"
                    Type="Int32" />
            </SelectParameters>
            <InsertParameters>
                <asp:Parameter Name="AccountId" Type="Int32" />
                <asp:Parameter Name="SystemBillingRateTypeId" Type="Int16" />
                <asp:Parameter Name="AccountProjectEmployeeId" Type="Int64" />
                <asp:Parameter Name="AccountProjectRoleId" Type="Int32" />
                <asp:Parameter Name="AccountEmployeeId" Type="Int32" />
                <asp:Parameter Name="AccountProjectTaskId" Type="Int32" />
                <asp:Parameter Name="BillingRate" Type="Decimal" />
                <asp:Parameter Name="StartDate" Type="DateTime" />
                <asp:Parameter Name="EndDate" Type="DateTime" />
                <asp:Parameter Name="AccountWorkTypeId" Type="Int32" />
                <asp:Parameter Name="EmployeeRate" Type="Decimal" />
                <asp:Parameter Name="BillingRateCurrencyId" Type="Int32" />
                <asp:Parameter Name="EmployeeRateCurrencyId" Type="Int32" />
            </InsertParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="dsAccountProjectEmployeeBillingRate" runat="server" DeleteMethod="DeleteAccountBillingRate"
            InsertMethod="AddAccountBillingRate" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetAccountBillingRatesByAccountProjectEmployeeId" TypeName="AccountBillingRateBLL" UpdateMethod="UpdateAccountBillingRate">
            <DeleteParameters>
                <asp:Parameter Name="Original_AccountBillingRateId" Type="Int32" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="AccountId" Type="Int32" />
                <asp:Parameter Name="SystemBillingRateTypeId" Type="Int16" />
                <asp:Parameter Name="AccountProjectEmployeeId" Type="Int64" />
                <asp:Parameter Name="AccountProjectRoleId" Type="Int32" />
                <asp:Parameter Name="AccountEmployeeId" Type="Int32" />
                <asp:Parameter Name="BillingRate" Type="Decimal" />
                <asp:Parameter Name="StartDate" Type="DateTime" />
                <asp:Parameter Name="EndDate" Type="DateTime" />
                <asp:Parameter Name="AccountProjectTaskId" Type="Int32" />
                <asp:Parameter Name="AccountWorkTypeId" Type="Int32" />
                <asp:Parameter Name="EmployeeRate" Type="Decimal" />
                <asp:Parameter Name="BillingRateCurrencyId" Type="Int32" />
                <asp:Parameter Name="EmployeeRateCurrencyId" Type="Int32" />
                <asp:Parameter Name="Original_AccountBillingRateId" Type="Int32" />
            </UpdateParameters>
            <SelectParameters>
                <asp:QueryStringParameter Name="AccountProjectEmployeeId" QueryStringField="AccountProjectEmployeeId"
                    Type="Int64" />
                <asp:QueryStringParameter Name="AccountWorkTypeId" QueryStringField="AccountWorkTypeId"
                    Type="Int32" />
            </SelectParameters>
            <InsertParameters>
                <asp:Parameter Name="AccountId" Type="Int32" />
                <asp:Parameter Name="SystemBillingRateTypeId" Type="Int16" />
                <asp:Parameter Name="AccountProjectEmployeeId" Type="Int64" />
                <asp:Parameter Name="AccountProjectRoleId" Type="Int32" />
                <asp:Parameter Name="AccountEmployeeId" Type="Int32" />
                <asp:Parameter Name="AccountProjectTaskId" Type="Int32" />
                <asp:Parameter Name="BillingRate" Type="Decimal" />
                <asp:Parameter Name="StartDate" Type="DateTime" />
                <asp:Parameter Name="EndDate" Type="DateTime" />
                <asp:Parameter Name="AccountWorkTypeId" Type="Int32" />
                <asp:Parameter Name="EmployeeRate" Type="Decimal" />
                <asp:Parameter Name="BillingRateCurrencyId" Type="Int32" />
                <asp:Parameter Name="EmployeeRateCurrencyId" Type="Int32" />
            </InsertParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="dsAccountProjectTaskBillingRate" runat="server" DeleteMethod="DeleteAccountBillingRate"
            InsertMethod="AddAccountBillingRate" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetAccountBillingRatesByAccountProjectTaskId" TypeName="AccountBillingRateBLL" UpdateMethod="UpdateAccountBillingRate">
            <DeleteParameters>
                <asp:Parameter Name="Original_AccountBillingRateId" Type="Int32" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="AccountId" Type="Int32" />
                <asp:Parameter Name="SystemBillingRateTypeId" Type="Int16" />
                <asp:Parameter Name="AccountProjectEmployeeId" Type="Int64" />
                <asp:Parameter Name="AccountProjectRoleId" Type="Int32" />
                <asp:Parameter Name="AccountEmployeeId" Type="Int32" />
                <asp:Parameter Name="BillingRate" Type="Decimal" />
                <asp:Parameter Name="StartDate" Type="DateTime" />
                <asp:Parameter Name="EndDate" Type="DateTime" />
                <asp:Parameter Name="AccountProjectTaskId" Type="Int32" />
                <asp:Parameter Name="AccountWorkTypeId" Type="Int32" />
                <asp:Parameter Name="EmployeeRate" Type="Decimal" />
                <asp:Parameter Name="BillingRateCurrencyId" Type="Int32" />
                <asp:Parameter Name="EmployeeRateCurrencyId" Type="Int32" />
                <asp:Parameter Name="Original_AccountBillingRateId" Type="Int32" />
            </UpdateParameters>
            <SelectParameters>
                <asp:QueryStringParameter Name="AccountProjectTaskId" QueryStringField="AccountProjectTaskId"
                    Type="Int32" />
                <asp:QueryStringParameter Name="AccountWorkTypeId" QueryStringField="AccountWorkTypeId"
                    Type="Int32" />
            </SelectParameters>
            <InsertParameters>
                <asp:Parameter Name="AccountId" Type="Int32" />
                <asp:Parameter Name="SystemBillingRateTypeId" Type="Int16" />
                <asp:Parameter Name="AccountProjectEmployeeId" Type="Int64" />
                <asp:Parameter Name="AccountProjectRoleId" Type="Int32" />
                <asp:Parameter Name="AccountEmployeeId" Type="Int32" />
                <asp:Parameter Name="AccountProjectTaskId" Type="Int32" />
                <asp:Parameter Name="BillingRate" Type="Decimal" />
                <asp:Parameter Name="StartDate" Type="DateTime" />
                <asp:Parameter Name="EndDate" Type="DateTime" />
                <asp:Parameter Name="AccountWorkTypeId" Type="Int32" />
                <asp:Parameter Name="EmployeeRate" Type="Decimal" />
                <asp:Parameter Name="BillingRateCurrencyId" Type="Int32" />
                <asp:Parameter Name="EmployeeRateCurrencyId" Type="Int32" />
            </InsertParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="dsAccountBillingRateFormViewObject" runat="server" DeleteMethod="DeleteAccountBillingRate"
            InsertMethod="AddAccountBillingRate" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetAccountBillingRatesByAccountBillingRateId" TypeName="AccountBillingRateBLL"
            UpdateMethod="UpdateAccountBillingRate">
            <DeleteParameters>
                <asp:Parameter Name="Original_AccountBillingRateId" Type="Int32" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="AccountId" Type="Int32" />
                <asp:Parameter Name="SystemBillingRateTypeId" Type="Int16" />
                <asp:Parameter Name="AccountProjectEmployeeId" Type="Int64" />
                <asp:Parameter Name="AccountProjectRoleId" Type="Int32" />
                <asp:Parameter Name="AccountEmployeeId" Type="Int32" />
                <asp:Parameter Name="BillingRate" Type="Decimal" />
                <asp:Parameter Name="StartDate" Type="DateTime" />
                <asp:Parameter Name="EndDate" Type="DateTime" />
                <asp:Parameter Name="AccountProjectTaskId" Type="Int32" />
                <asp:Parameter Name="AccountWorkTypeId" Type="Int32" />
                <asp:Parameter Name="EmployeeRate" Type="Decimal" />
                <asp:Parameter Name="BillingRateCurrencyId" Type="Int32" />
                <asp:Parameter Name="EmployeeRateCurrencyId" Type="Int32" />
                <asp:Parameter Name="Original_AccountBillingRateId" Type="Int32" />
            </UpdateParameters>
            <SelectParameters>
                <asp:ControlParameter ControlID="GridView1" Name="AccountBillingRateId" PropertyName="SelectedValue"
                    Type="Int32" />
            </SelectParameters>
            <InsertParameters>
                <asp:SessionParameter DefaultValue="64" Name="AccountId" SessionField="AccountId"
                    Type="Int32" />
                <asp:Parameter DefaultValue="" Name="SystemBillingRateTypeId" Type="Int16" />
                <asp:Parameter Name="AccountProjectEmployeeId" Type="Int64" />
                <asp:Parameter Name="AccountProjectRoleId" Type="Int32" />
                <asp:Parameter Name="AccountEmployeeId" Type="Int32" />
                <asp:Parameter Name="AccountProjectTaskId" Type="Int32" />
                <asp:Parameter Name="BillingRate" Type="Decimal" />
                <asp:Parameter Name="StartDate" Type="DateTime" />
                <asp:Parameter Name="EndDate" Type="DateTime" />
                <asp:Parameter Name="AccountWorkTypeId" Type="Int32" />
                <asp:Parameter Name="EmployeeRate" Type="Decimal" />
                <asp:Parameter Name="BillingRateCurrencyId" Type="Int32" />
                <asp:Parameter Name="EmployeeRateCurrencyId" Type="Int32" />
            </InsertParameters>
        </asp:ObjectDataSource>
    </ContentTemplate>
</asp:UpdatePanel>
<br />
<asp:UpdatePanel ID="UpdatePanel3" runat="server">
    <ContentTemplate>
        <asp:FormView ID="FormView1" runat="server" DataKeyNames="AccountBillingRateId" DataSourceID="dsAccountBillingRateFormViewObject"
            DefaultMode="Insert" SkinID="formviewSkinEmployee" Width="45%">
            <EditItemTemplate>
                <table width="100%" class="xview">
                    <tr>
                        <th class="caption" colspan="2">
                           <asp:Literal ID="Literal1" runat="server" Text="<%$ Resources:TimeLive.Resource, Billing Rate Information%> " /></th>
                    </tr>
                    <tr>
                        <th class="FormViewSubHeader" colspan="2">
                            <asp:Literal ID="Literal4" runat="server" Text="<%$ Resources:TimeLive.Resource, Billing Rate%> " /></th>
                    </tr>
                    <tr>
                        <td align="right" class="formviewlabelcell" style="width: 50%">
                            <asp:Literal ID="Literal5" runat="server" Text="<%$ Resources:TimeLive.Resource, Billing Rate Currency:%> " /></td>
                        </td>
                        <td align="left" style="width: 50%">
                            <asp:DropDownList ID="ddlBillingRateCurrencyId" runat="server" DataSourceID="dsAccountCurrencyObject"
                                DataTextField="CurrencyCode" DataValueField="AccountCurrencyId" 
                                SelectedValue='<%# Bind("BillingRateCurrencyId") %>' Width="67px">
                            </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td align="right" class="formviewlabelcell" style="width: 50%">
                            <asp:Literal ID="Literal6" runat="server" Text="<%$ Resources:TimeLive.Resource, Billing Rate:%> " /></td>
                        <td align="left" style="width: 50%">
                            <asp:TextBox ID="BillingRateTextBox" runat="server" style="text-align:right;"
                                Text='<%# Bind("BillingRate") %>' Width="55px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td align="right" class="formviewlabelcell" style="width: 50%">
                            <asp:Literal ID="Literal7" runat="server" Text="<%$ Resources:TimeLive.Resource, Employee Rate Currency:%> " /></td>
                        </td>
                        <td align="left" style="width: 50%">
                            <asp:DropDownList ID="ddlEmployeeRateCurrencyId" runat="server" DataSourceID="dsAccountCurrencyObject"
                                DataTextField="CurrencyCode" DataValueField="AccountCurrencyId" 
                                SelectedValue='<%# Bind("EmployeeRateCurrencyId") %>' Width="67px">
                            </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td align="right" class="formviewlabelcell" style="width: 50%">
                            <asp:Literal ID="Literal8" runat="server" Text="<%$ Resources:TimeLive.Resource, Employee Rate:%> " /></td>
                        <td align="left" style="width: 50%">
                            <asp:TextBox ID="EmployeeRateTextBox" runat="server" style="text-align:right;"
                                Text='<%# Bind("EmployeeRate") %>' Width="55px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td align="right" class="formviewlabelcell" style="width: 50%">
                            <asp:Literal ID="Literal9" runat="server" Text="<%$ Resources:TimeLive.Resource, Start Date:%> " /></td>
                        <td align="left" style="width: 50%">
                            <ew:CalendarPopup ID="StartDateTextBox" runat="server" 
                                SkinId="DatePicker" SelectedDate='<%# Bind("StartDate") %>' Width="55px"
                                >
                            </ew:CalendarPopup>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="formviewlabelcell" style="width: 50%">
                            <asp:Literal ID="Literal10" runat="server" Text="<%$ Resources:TimeLive.Resource, End Date:%> " /></td>
                        <td align="left" style="width: 50%">
                            <ew:CalendarPopup ID="EndDateTextBox" runat="server" SkinId="DatePicker" 
                                SelectedDate='<%# Bind("EndDate") %>' Width="55px">
                                  </ew:CalendarPopup>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="formviewlabelcell" style="width: 50%">
                            <asp:Literal ID="Literal11" runat="server" Text="<%$ Resources:TimeLive.Resource, Update all records within this range:%> " /></td>
                        <td align="left" style="width: 50%">
                            <asp:CheckBox ID="chkUpdateBillingRate" runat="server" /></td>
                    </tr>
                    <tr>
                        <td align="right" class="formviewlabelcell" style="width: 50%">
                        </td>
                        <td align="left" style="width: 50%; padding-bottom: 5px;">
                            <asp:Button ID="btnUpdate" runat="server" CommandName="Update" Text="<%$ Resources:TimeLive.Resource, Update_text%> " Width="50px" />
                      <asp:Button ID="btnCancel" runat="server" CommandName="Cancel" Text="<%$ Resources:TimeLive.Resource, Cancel_text%> " Width="50px" /></td>
                    </tr>
                </table>
            </EditItemTemplate>
            <InsertItemTemplate>
                <table width="100%" class="xview">
                    <tr>
                        <th class="caption" colspan="2">
                            <asp:Literal ID="Literal10" runat="server" Text="<%$ Resources:TimeLive.Resource, Billing Rate Information%> " /></th>
                    </tr>
                    <tr>
                        <th class="FormViewSubHeader" colspan="2">
                            <asp:Literal ID="Literal12" runat="server" Text="<%$ Resources:TimeLive.Resource, Billing Rate%> " /></th>
                    </tr>
                    <tr>
                        <td align="right" class="formviewlabelcell" style="width: 50%">
                            <asp:Literal ID="Literal13" runat="server" Text="<%$ Resources:TimeLive.Resource, Billing Rate Currency:%> " /></td>
                        </td>
                        <td align="left" style="width: 50%">
                            <asp:DropDownList ID="ddlBillingRateCurrencyId" runat="server" DataSourceID="dsAccountCurrencyObject"
                                DataTextField="CurrencyCode" DataValueField="AccountCurrencyId" 
                                SelectedValue='<%# Bind("BillingRateCurrencyId") %>' Width="67px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="formviewlabelcell" style="width: 50%">
                            <asp:Literal ID="Literal14" runat="server" Text="<%$ Resources:TimeLive.Resource, Billing Rate:%> " /></td>
                        <td align="left" style="width: 50%">
                            <asp:TextBox ID="BillingRateTextBox" runat="server" style="text-align:right;"
                                Text='<%# Bind("BillingRate") %>' Width="55px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td align="right" class="formviewlabelcell" style="width: 50%">
                            <asp:Literal ID="Literal15" runat="server" Text="<%$ Resources:TimeLive.Resource, Employee Rate Currency:%> " /></td>
                        </td>
                        <td align="left" style="width: 50%">
                            <asp:DropDownList ID="ddlEmployeeRateCurrencyId" runat="server" DataSourceID="dsAccountCurrencyObject"
                                DataTextField="CurrencyCode" DataValueField="AccountCurrencyId" 
                                SelectedValue='<%# Bind("EmployeeRateCurrencyId") %>' Width="67px">
                            </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td align="right" class="formviewlabelcell" style="width: 50%">
                            <asp:Literal ID="Literal16" runat="server" Text="<%$ Resources:TimeLive.Resource, Employee Rate:%> " /></td>
                        <td align="left" style="width: 50%">
                            <asp:TextBox ID="EmployeeRateTextBox" runat="server" style="text-align:right;"
                                Text='<%# Bind("EmployeeRate") %>' Width="55px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td align="right" class="formviewlabelcell" style="width: 50%">
                            <asp:Literal ID="Literal17" runat="server" Text="<%$ Resources:TimeLive.Resource, Start Date:%> " /></td>
                        <td align="left" style="width: 50%">
                            <ew:CalendarPopup ID="StartDateTextBox" runat="server" 
                                SkinId="DatePicker" SelectedDate='<%# Bind("StartDate") %>' Width="55px">
                            </ew:CalendarPopup>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="formviewlabelcell" style="width: 50%">
                            <asp:Literal ID="Literal18" runat="server" Text="<%$ Resources:TimeLive.Resource, End Date:%> " /></td>
                        <td align="left" style="width: 50%">
                            <ew:CalendarPopup ID="EndDateTextBox" runat="server" SkinId="DatePicker" 
                                SelectedDate='<%# Bind("EndDate") %>' Width="55px"
                                >
                            </ew:CalendarPopup>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="formviewlabelcell" style="width: 50%">
                            <asp:Literal ID="Literal19" runat="server" Text="<%$ Resources:TimeLive.Resource, Update all records within this range:%> " /></td>
                        <td align="left" style="width: 50%">
                            <asp:CheckBox ID="chkUpdateBillingRate" runat="server" /></td>
                    </tr>
                    <tr>
                        <td align="right" class="formviewlabelcell" style="width: 50%">
                        </td>
                        <td align="left" style="width: 50%; padding-bottom: 5px;">
                            <asp:Button ID="btnAdd" runat="server" CommandName="Insert" Text="<%$ Resources:TimeLive.Resource, Add_text%> " Width="50px" /></td>
                    </tr>
                </table>
            </InsertItemTemplate>
            <ItemTemplate>
                AccountBillingRateId:
                <asp:Label ID="AccountBillingRateIdLabel" runat="server" Text='<%# Eval("AccountBillingRateId") %>'>
                </asp:Label><br />
                AccountId:
                <asp:Label ID="AccountIdLabel" runat="server" Text='<%# Bind("AccountId") %>'></asp:Label><br />
                SystemBillingRateTypeId:
                <asp:Label ID="SystemBillingRateTypeIdLabel" runat="server" Text='<%# Bind("SystemBillingRateTypeId") %>'>
                </asp:Label><br />
                AccountProjectEmployeeId:
                <asp:Label ID="AccountProjectEmployeeIdLabel" runat="server" Text='<%# Bind("AccountProjectEmployeeId") %>'>
                </asp:Label><br />
                AccountProjectRoleId:
                <asp:Label ID="AccountProjectRoleIdLabel" runat="server" Text='<%# Bind("AccountProjectRoleId") %>'>
                </asp:Label><br />
                BillingRate:
                <asp:Label ID="BillingRateLabel" runat="server" Text='<%# Bind("BillingRate") %>'>
                </asp:Label><br />
                StartDate:
                <asp:Label ID="StartDateLabel" runat="server" Text='<%# Bind("StartDate") %>'></asp:Label><br />
                EndDate:
                <asp:Label ID="EndDateLabel" runat="server" Text='<%# Bind("EndDate") %>'></asp:Label><br />
                <asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" CommandName="Edit"
                    Text="Edit">
                </asp:LinkButton>
                <asp:LinkButton ID="DeleteButton" runat="server" CausesValidation="False" CommandName="Delete"
                    Text="Delete">
                </asp:LinkButton>
                <asp:LinkButton ID="NewButton" runat="server" CausesValidation="False" CommandName="New"
                    Text="New">
                </asp:LinkButton>
            </ItemTemplate>
        </asp:FormView>
        <asp:ObjectDataSource ID="dsAccountCurrencyObject" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetvueAccountCurrencyByAccountIdAndDisabled" TypeName="AccountCurrencyBLL">
            <SelectParameters>
                <asp:SessionParameter Name="AccountId" SessionField="AccountId" Type="Int32" />
                <asp:Parameter Name="AccountCurrencyId" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </ContentTemplate>
</asp:UpdatePanel>
