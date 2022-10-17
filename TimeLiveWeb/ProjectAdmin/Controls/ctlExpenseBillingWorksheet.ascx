<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlExpenseBillingWorksheet.ascx.vb" Inherits="ProjectAdmin_Controls_ctlExpenseBillingWorksheet" %>
<%@ Register Assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2"
    Namespace="eWorld.UI" TagPrefix="ew" %>

<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
      <table class="xFormView" ><tr><td>
      <table class="xFormView" style="width: 600px; height: 1px">
        <tbody>
            <tr>
                <th class="caption" colspan="2" style="height: 21px">
                    <asp:Literal ID="Literal5" runat="server" Text="<%$ Resources:TimeLive.Resource, Expense Billing Worksheet%> " /></th>
            </tr>
            <tr>
                <th class="FormViewSubHeader" colspan="2" style="height: 21px">
                    <asp:Literal ID="Literal1" runat="server" Text="<%$ Resources:TimeLive.Resource, Search Parameters%> " /></th>
            </tr>
            <tr>
                <td align="right" class="formviewlabelcell" width="100" style="height: 24px">
                    <asp:Literal ID="Literal3" runat="server" Text="<%$ Resources:TimeLive.Resource, Project:%> " /></td>
                <td align="left" style="padding-left: 3px; width: 300px; height: 24px">
                    <asp:DropDownList ID="ddlProjects" runat="server" 
                        AppendDataBoundItems="True" DataTextField="ProjectName" 
                        DataValueField="AccountProjectId" Width="325px" DataSourceID="dsProjectsObject">
                        <asp:ListItem Selected="True" Value="0" Label ID="Label10" runat="server" Text="<%$ Resources:TimeLive.Resource, Alls%> "></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="right" class="formviewlabelcell" width="100" style="height: 24px">
                    <asp:Literal ID="Literal4" runat="server" Text="<%$ Resources:TimeLive.Resource, Client Name:%> " /></td>
                <td align="left" style="padding-left: 3px; width: 300px; height: 24px">
                    <asp:DropDownList ID="ddlClients" runat="server" AppendDataBoundItems="True"
                        DataSourceID="dsClientsObject" DataTextField="PartyName" 
                        DataValueField="AccountPartyId" Width="325px">
                        <asp:ListItem Selected="True" Value="0" Label ID="Label9" runat="server" Text="<%$ Resources:TimeLive.Resource, Alls%> "></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="right" class="formviewlabelcell" width="100" style="height: 24px">
                    <asp:Literal ID="Literal2" runat="server" Text="<%$ Resources:TimeLive.Resource, Expense Name:%> " /></td>
                <td align="left" style="padding-left: 3px; width: 300px; height: 24px">
                    <asp:DropDownList ID="ddlExpense" runat="server" AppendDataBoundItems="True"
                        DataSourceID="dsExpenseObject" DataTextField="AccountExpenseName" 
                        DataValueField="AccountExpenseId" Width="325px">
                        <asp:ListItem Selected="True" Value="0" Label ID="Label8" runat="server" Text="<%$ Resources:TimeLive.Resource, Alls%> "></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="right" class="formviewlabelcell" width="100" style="height: 24px">
                    <asp:Literal ID="Literal6" runat="server" Text="<%$ Resources:TimeLive.Resource, Expense Type:%> " /></td>
                <td align="left" style="padding-left: 3px; width: 300px; height: 24px">
                    <asp:DropDownList ID="ddlExpenseType" runat="server" AppendDataBoundItems="True"
                        DataSourceID="dsExpenseTypeObject" DataTextField="ExpenseType" 
                        DataValueField="AccountExpenseTypeId" Width="325px">
                        <asp:ListItem Selected="True" Value="0" Label ID="Label7" runat="server" Text="<%$ Resources:TimeLive.Resource, Alls%> "></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                     <td align="right" class="formviewlabelcell" width="100" style="height: 24px">
                    <asp:Literal ID="Literal79" runat="server" Text="<%$ Resources:TimeLive.Resource, Billed:%> " /></td>
                         <td align="left" style="padding-left: 3px; width: 300px; height: 24px">
                    <asp:DropDownList ID="ddlBilled" runat="server" AppendDataBoundItems="True" 
                                 Width="108px">
                        <asp:ListItem Selected="True" Value="-1" Label ID="Label4" runat="server" Text="<%$ Resources:TimeLive.Resource, Both%> "></asp:ListItem>
                        <asp:ListItem Value="1" Label ID="Label5" runat="server" Text="<%$ Resources:TimeLive.Resource, Billed%> "></asp:ListItem>
                        <asp:ListItem Value="0" Label ID="Label6" runat="server" Text="<%$ Resources:TimeLive.Resource, Not Billed%> "></asp:ListItem>
                     </asp:DropDownList></td>
            </tr>
            <tr>
                <td align="right" class="formviewlabelcell" width="100" style="height: 24px">
                    <asp:Literal ID="Literal8" runat="server" Text="<%$ Resources:TimeLive.Resource, Include Date Range:%> " /></td>
                 <td align="left" style="padding-left: 5px; width: 300px; height: 24px">
                    <asp:CheckBox ID="chkIncludeDateRange" runat="server" /></td>
            </tr>
            <tr>
                <td align="right" class="formviewlabelcell" width="100" style="height: 24px">
                    <asp:Literal ID="Literal9" runat="server" Text="<%$ Resources:TimeLive.Resource, Start Date:%> " /></td>
                 <td align="left" style="padding-left: 3px; width: 300px; height: 24px">
                    <ew:calendarpopup id="StartDate" runat="server" SkinId="DatePicker" Width="55px"></ew:calendarpopup></td>
            </tr>
            <tr>
                <td align="right" class="formviewlabelcell" width="100" style="height: 24px">
                    <asp:Literal ID="Literal10" runat="server" Text="<%$ Resources:TimeLive.Resource, End Date:%> " /></td>
                <td align="left" style="padding-left: 3px; width: 300px; height: 24px">
                    <ew:calendarpopup id="EndDate" runat="server" SkinId="DatePicker" Width="55px"></ew:calendarpopup></td>
            </tr>
            <tr>
                <td align="right" class="formviewlabelcell" width="100" style="height: 24px">
                </td>
                <td style="padding: 3px; height: 24px; width: 300px;">
                    <asp:Button ID="Show" runat="server" OnClick="Show_Click" Text="<%$ Resources:TimeLive.Resource, Show_text%> " Width="68px" /></td>
            </tr>
            </tbody> 
        </table>
        </td></tr></table>
        <asp:ObjectDataSource ID="dsClientsObject" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetAccountPartiesByAccountId" TypeName="AccountPartyBLL" DeleteMethod="DeleteAccountParty" InsertMethod="AddAccountParty" UpdateMethod="UpdateAccountParty">
            <SelectParameters>
                <asp:SessionParameter DefaultValue="99" Name="AccountId" SessionField="AccountId"
                    Type="Int32" />
            </SelectParameters>
            <DeleteParameters>
                <asp:Parameter Name="original_AccountPartyId" Type="Int32" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="PartyTypeId" Type="Int16" />
                <asp:Parameter Name="AccountId" Type="Int32" />
                <asp:Parameter Name="PartyName" Type="String" />
                <asp:Parameter Name="PartyNick" Type="String" />
                <asp:Parameter Name="EMailAddress" Type="String" />
                <asp:Parameter Name="Address1" Type="String" />
                <asp:Parameter Name="Address2" Type="String" />
                <asp:Parameter Name="CountryId" Type="Int16" />
                <asp:Parameter Name="State" Type="String" />
                <asp:Parameter Name="City" Type="String" />
                <asp:Parameter Name="ZipCode" Type="String" />
                <asp:Parameter Name="Telephone1" Type="String" />
                <asp:Parameter Name="Telephone2" Type="String" />
                <asp:Parameter Name="Fax" Type="String" />
                <asp:Parameter Name="DefaultCurrencyId" Type="Int16" />
                <asp:Parameter Name="DefaultBillingRate" Type="Decimal" />
                <asp:Parameter Name="Website" Type="String" />
                <asp:Parameter Name="Notes" Type="String" />
                <asp:Parameter Name="IsDisabled" Type="Boolean" />
                <asp:Parameter Name="IsDeleted" Type="Boolean" />
                <asp:Parameter Name="CreatedOn" Type="DateTime" />
                <asp:Parameter Name="CreatedByEmployeeId" Type="Int32" />
                <asp:Parameter Name="ModifiedOn" Type="DateTime" />
                <asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" />
                <asp:Parameter Name="Original_AccountPartyId" Type="Int32" />
            </UpdateParameters>
            <InsertParameters>
                <asp:Parameter Name="AccountId" Type="Int32" />
                <asp:Parameter Name="PartyName" Type="String" />
                <asp:Parameter Name="PartyNick" Type="String" />
                <asp:Parameter Name="EMailAddress" Type="String" />
                <asp:Parameter Name="Address1" Type="String" />
                <asp:Parameter Name="Address2" Type="String" />
                <asp:Parameter Name="CountryId" Type="Int16" />
                <asp:Parameter Name="State" Type="String" />
                <asp:Parameter Name="City" Type="String" />
                <asp:Parameter Name="ZipCode" Type="String" />
                <asp:Parameter Name="Telephone1" Type="String" />
                <asp:Parameter Name="Telephone2" Type="String" />
                <asp:Parameter Name="Fax" Type="String" />
                <asp:Parameter Name="DefaultCurrencyId" Type="Int16" />
                <asp:Parameter Name="DefaultBillingRate" Type="Decimal" />
                <asp:Parameter Name="Website" Type="String" />
                <asp:Parameter Name="Notes" Type="String" />
                <asp:Parameter Name="IsDisabled" Type="Boolean" />
                <asp:Parameter Name="IsDeleted" Type="Boolean" />
                <asp:Parameter Name="CreatedOn" Type="DateTime" />
                <asp:Parameter Name="CreatedByEmployeeId" Type="Int32" />
                <asp:Parameter Name="ModifiedOn" Type="DateTime" />
                <asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" />
            </InsertParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="dsProjectsObject" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetvueAccountProjectsByAccountId" 
            TypeName="AccountProjectBLL" DeleteMethod="DeleteAccountProject" 
            InsertMethod="AddAccountProject" UpdateMethod="UpdateProjectDescription">
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
                <asp:SessionParameter Name="AccountId" SessionField="AccountId" Type="Int32" />
                <asp:Parameter Name="IsTemplate" Type="Boolean" />
            </SelectParameters>
            <DeleteParameters>
                <asp:Parameter Name="Original_AccountProjectId" Type="Int32" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="ProjectDescription" Type="String" />
                <asp:Parameter Name="Original_AccountProjectId" Type="Int32" />
            </UpdateParameters>
        </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="dsExpenseTypeObject" runat="server"
                        DeleteMethod="DeleteAccountExpenseType" InsertMethod="AddAccountExpenseType"
                        OldValuesParameterFormatString="original_{0}" SelectMethod="GetAccountExpenseTypesByAccountId"
                        TypeName="AccountExpenseTypeBLL" UpdateMethod="UpdateAccountExpenseTypes">
                        <DeleteParameters>
                            <asp:Parameter Name="Original_AccountExpenseTypeId" Type="Int32" />
                        </DeleteParameters>
                        <UpdateParameters>
                            <asp:Parameter Name="AccountId" Type="Int32" />
                            <asp:Parameter Name="ExpenseType" Type="String" />
                            <asp:Parameter Name="Original_AccountExpenseTypeId" Type="Int32" />
                        </UpdateParameters>
                        <SelectParameters>
                            <asp:SessionParameter DefaultValue="99" Name="AccountId" SessionField="AccountId"
                                Type="Int32" />
                        </SelectParameters>
                        <InsertParameters>
                            <asp:Parameter Name="AccountId" Type="Int32" />
                            <asp:Parameter Name="ExpenseType" Type="String" />
                            <asp:Parameter Name="CreatedOn" Type="DateTime" />
                            <asp:Parameter Name="CreatedByEmployeeId" Type="Int32" />
                            <asp:Parameter Name="ModifiedOn" Type="DateTime" />
                            <asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" />
                            <asp:Parameter Name="AccountTaxCodeId" Type="Int32" />
                            <asp:Parameter Name="QuantityFieldCaption" Type="String" />
                            <asp:Parameter Name="IsQuantityField" Type="Boolean" />
                            <asp:Parameter Name="AccountTaxZoneId" Type="Int32" />
                        </InsertParameters>
                    </asp:ObjectDataSource>
                <asp:ObjectDataSource ID="dsExpenseObject" runat="server" DeleteMethod="DeleteAccountExpense"
                        InsertMethod="AddAccountExpense" OldValuesParameterFormatString="original_{0}"
                        SelectMethod="GetAccountExpensesByAccountId" TypeName="AccountExpenseBLL" UpdateMethod="UpdateAccountExpense">
                        <DeleteParameters>
                            <asp:Parameter Name="Original_AccountExpenseId" Type="Int32" />
                        </DeleteParameters>
                        <UpdateParameters>
                            <asp:Parameter Name="AccountId" Type="Int32" />
                            <asp:Parameter Name="AccountExpenseName" Type="String" />
                            <asp:Parameter Name="AccountExpenseTypeId" Type="Int32" />
                            <asp:Parameter Name="Original_AccountExpenseId" Type="Int32" />
                            <asp:Parameter Name="ModifiedOn" Type="DateTime" />
                            <asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" />
                            <asp:Parameter Name="IsBillable" Type="Boolean" />
                            <asp:Parameter Name="IsDisabled" Type="Boolean" />
                        </UpdateParameters>
                        <SelectParameters>
                            <asp:SessionParameter DefaultValue="55" Name="AccountId" SessionField="AccountId"
                                Type="Int32" />
                        </SelectParameters>
                        <InsertParameters>
                            <asp:Parameter Name="AccountId" Type="Int32" />
                            <asp:Parameter Name="AccountExpenseName" Type="String" />
                            <asp:Parameter Name="AccountExpenseTypeId" Type="Int32" />
                            <asp:Parameter Name="CreatedOn" Type="DateTime" />
                            <asp:Parameter Name="CreatedByEmployeeId" Type="Int32" />
                            <asp:Parameter Name="ModifiedOn" Type="DateTime" />
                            <asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" />
                            <asp:Parameter Name="IsBillable" Type="Boolean" />
                        </InsertParameters>
                    </asp:ObjectDataSource>
    </ContentTemplate>
</asp:UpdatePanel>
<br />
<asp:UpdatePanel ID="UpdatePanel2" runat="server">
    <ContentTemplate>
        <x:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
            DataSourceID="dsExpenseBillingWorksheetObject" SkinID="xgridviewSkinEmployee" Caption='<%# ResourceHelper.GetFromResource("Expense Billing Worksheet") %>'  Width="98%" DataKeyNames="AccountExpenseEntryId" OnDataBound="GridView1_DataBound">
            <Columns>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Id %>" SortExpression="AccountExpenseEntryId">
                    <edititemtemplate>
<asp:Label runat="server" Text='<%# Eval("AccountExpenseEntryId") %>' id="Label9"></asp:Label>
</edititemtemplate>
                    <itemtemplate>
<asp:Label runat="server" Text='<%# Bind("AccountExpenseEntryId") %>' id="Label14"></asp:Label>
</itemtemplate>
                    <itemstyle width="5%" HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Employee Name %>"  SortExpression="EmployeeName">
                    <edititemtemplate>
<asp:Label id="Label5" runat="server" Text='<%# Eval("EmployeeName") %>' __designer:wfdid="w65"></asp:Label> 
</edititemtemplate>
                    <headertemplate>
<asp:LinkButton id="LinkButton3" runat="server" Text='<%# ResourceHelper.GetFromResource("Employee Name") %>' CommandArgument="EmployeeName" CommandName="Sort" CausesValidation="False"></asp:LinkButton>
</headertemplate>
                    <itemtemplate>
<asp:Label id="Label6" runat="server" Text='<%# Bind("EmployeeName") %>' __designer:wfdid="w64"></asp:Label> 
</itemtemplate>
                    <itemstyle width="18%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Project Name %>"  SortExpression="ProjectName">
                    <edititemtemplate>
<asp:Label id="Label7" runat="server" Text='<%# Eval("ProjectName") %>' __designer:wfdid="w68"></asp:Label> 
</edititemtemplate>
                    <headertemplate>
<asp:LinkButton id="LinkButton4" runat="server" Text='<%# ResourceHelper.GetFromResource("Project Name") %>' CommandArgument="ProjectName" CommandName="Sort" CausesValidation="False"></asp:LinkButton>
</headertemplate>
                    <itemtemplate>
<asp:Label id="Label12" runat="server" Text='<%# Bind("ProjectName") %>' __designer:wfdid="w67"></asp:Label> 
</itemtemplate>
                    <itemstyle width="18%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Expense Name (Expense Type) %>"  SortExpression="AccountExpenseName">
                    <edititemtemplate>
<asp:Label id="Label4" runat="server" Text='<%# Eval("AccountExpenseName") %>' __designer:wfdid="w72"></asp:Label><BR /><asp:Label id="Label69" runat="server" Text='<%# Eval("ExpenseType") %>' __designer:wfdid="w73"></asp:Label> 
</edititemtemplate>
                    <headertemplate>
<asp:Label id="lblExpenseNameExpenseType" runat="server" Text='<%# ResourceHelper.GetFromResource("Expense Name (Expense Type)") %>' __designer:wfdid="w74"></asp:Label>
</headertemplate>
                    <itemtemplate>
<asp:Label id="Label4" runat="server" Text='<%# Bind("AccountExpenseName") %>' __designer:wfdid="w70"></asp:Label><BR /><asp:Label id="Label5" runat="server" Text='<%# Bind("ExpenseType") %>' __designer:wfdid="w71"></asp:Label> 
</itemtemplate>
                    <itemstyle width="10%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Description %>" >
                    <edititemtemplate>
<asp:Label id="Label8" runat="server" Text='<%# Eval("Description") %>' __designer:wfdid="w76"></asp:Label> 
</edititemtemplate>
                    <headertemplate>
<asp:LinkButton id="LinkButton5" runat="server" Text='<%# ResourceHelper.GetFromResource("Description") %>' CommandArgument="Description" CommandName="Sort" CausesValidation="False"></asp:LinkButton>
</headertemplate>
                    <itemtemplate>
<asp:Label id="Label13" runat="server" Text='<%# Bind("Description") %>' __designer:wfdid="w75"></asp:Label> 
</itemtemplate>
                    <itemstyle width="15%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Invoice Details %>" >
                    <edititemtemplate>
<asp:Label id="Label121" runat="server" Text="Invoice No:" __designer:wfdid="w84"></asp:Label> <asp:Label id="Label1" runat="server" Text='<%# Eval("InvoiceNumber") %>' __designer:wfdid="w85"></asp:Label><BR /><asp:Label id="Label13" runat="server" Text="Invoice Date:" __designer:wfdid="w86"></asp:Label> <asp:Label id="Label15" runat="server" Text='<%# Eval("InvoiceDate", "{0:d}") %>' __designer:wfdid="w87"></asp:Label><BR /><asp:Label id="Label14" runat="server" Text="PO Number:" __designer:wfdid="w88"></asp:Label>&nbsp; <asp:Label id="Label16" runat="server" Text='<%# Eval("PONumber") %>' __designer:wfdid="w89"></asp:Label> 
</edititemtemplate>
                    <headertemplate>
<asp:Label id="lblInvoiceDetail" runat="server" Text='<%# ResourceHelper.GetFromResource("Invoice Detail") %>' __designer:wfdid="w90"></asp:Label>
</headertemplate>
                    <itemtemplate>
<asp:Label id="Label7" runat="server" Text="Invoice No:" __designer:wfdid="w78"></asp:Label> <asp:Label id="Label1" runat="server" Text='<%# Bind("InvoiceNumber") %>' __designer:wfdid="w79"></asp:Label><BR /><asp:Label id="Label8" runat="server" Text="Invoice Date:" __designer:wfdid="w80"></asp:Label> <asp:Label id="Label10" runat="server" Text='<%# Bind("InvoiceDate", "{0:d}") %>' __designer:wfdid="w81"></asp:Label><BR /><asp:Label id="Label9" runat="server" Text="PO Number:" __designer:wfdid="w82"></asp:Label> <asp:Label id="Label11" runat="server" Text='<%# Bind("PONumber") %>' __designer:wfdid="w83"></asp:Label> 
</itemtemplate>
                    <itemstyle width="20%" />
                </asp:TemplateField>
                                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Amount %>" >
                    <EditItemTemplate>
<asp:Label id="Label2" runat="server" Text='<%# Eval("CurrencyCode") %>' __designer:wfdid="w93"></asp:Label> <asp:Label id="Label3" runat="server" Text='<%# Eval("ExpenseAmount", "{0:N}") %>' __designer:wfdid="w94"></asp:Label> 
</EditItemTemplate>
                                    <headertemplate>
<asp:Label id="lblAmount" runat="server" Text='<%# ResourceHelper.GetFromResource("Amount") %>' __designer:wfdid="w95"></asp:Label>
</headertemplate>
                    <ItemTemplate>
<asp:Label id="Label2" runat="server" Text='<%# Eval("CurrencyCode") %>' __designer:wfdid="w91"></asp:Label> <asp:Label id="Label3" runat="server" Text='<%# Eval("ExpenseAmount", "{0:N}") %>' __designer:wfdid="w92"></asp:Label> 
</ItemTemplate>
                    <ItemStyle HorizontalAlign="Right" width="10%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Billed %>">
                    <edititemtemplate>
<asp:CheckBox id="CheckBox1" runat="server" __designer:wfdid="w97" Checked='<%# Bind("Billed") %>'></asp:CheckBox> 
</edititemtemplate>
                    <headertemplate>
<asp:Label id="lblBilled" runat="server" Text='<%# ResourceHelper.GetFromResource("Billed") %>' __designer:wfdid="w98"></asp:Label>
</headertemplate>
                    <itemtemplate>
<asp:CheckBox id="CheckBox1" runat="server" __designer:wfdid="w96" Checked='<%# Bind("Billed") %>' Enabled="false"></asp:CheckBox> 
</itemtemplate>
                    <itemstyle horizontalalign="Center" verticalalign="Middle" width="1%" />
                </asp:TemplateField>
                <asp:CommandField HeaderText="<%$ Resources:TimeLive.Resource, Edit_text %>" ShowEditButton="True" EditImageUrl="~/Images/edit.gif" >
                    <itemstyle horizontalalign="Center" verticalalign="Middle" width="1%" />
                </asp:CommandField>
            </Columns>
        </x:GridView>
        <asp:ObjectDataSource ID="dsExpenseBillingWorksheetObject" runat="server"
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetDataByAccountIdAndEmployeesForExpenseBillingWorksheet"
            TypeName="AccountTimeExpenseBillingBLL" UpdateMethod="UpdateExpenseBillingWorksheet" DeleteMethod="DeleteAccountExpenseEntry" InsertMethod="UpdateAccountExpenseEntryBillStatus">
            <UpdateParameters>
                <asp:Parameter Name="Original_AccountExpenseEntryId" Type="Int32" />
                <asp:Parameter Name="Billed" Type="Boolean" />
            </UpdateParameters>
            <SelectParameters>
                <asp:SessionParameter DefaultValue="12" Name="AccountId" SessionField="AccountId"
                    Type="Int32" />
                <asp:Parameter Name="AccountClientId" Type="Int32" />
                <asp:Parameter Name="AccountProjectId" Type="Int32" />
                <asp:Parameter Name="AccountExpenseId" Type="Int32" />
                <asp:Parameter Name="AccountExpenseTypeId" Type="Int32" />
                <asp:Parameter Name="ExpenseEntryStartDate" Type="DateTime" />
                <asp:Parameter Name="ExpenseEntryEndDate" Type="DateTime" />
                <asp:Parameter Name="Billed" Type="String" />
                <asp:Parameter Name="IncludeDateRange" Type="Boolean" />
            </SelectParameters>
            <DeleteParameters>
                <asp:Parameter Name="Original_AccountExpenseEntryId" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="AccountTimeExpenseBillingExpenseId" />
                <asp:Parameter Name="AccountProjectId" Type="Int32" />
                <asp:Parameter Name="AccountExpenseId" Type="Int32" />
                <asp:Parameter Name="Billed" Type="Boolean" />
                <asp:Parameter Name="ExpenseEntryStartDate" Type="DateTime" />
                <asp:Parameter Name="ExpenseEntryEndDate" Type="DateTime" />
            </InsertParameters>
        </asp:ObjectDataSource>
    </ContentTemplate>
</asp:UpdatePanel>
