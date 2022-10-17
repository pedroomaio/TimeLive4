<%@ Control AutoEventWireup="false" CodeFile="ctlAccountEmployeeTimeEntryWeekViewTemplate.ascx.vb"  ClientIDMode="Predictable" 
    Inherits="Employee_Controls_ctlAccountEmployeeTimeEntryWeekViewTemplate" Language="VB" %>
<%@ Register Src="ctlStatusLegend.ascx" TagName="ctlStatusLegend" TagPrefix="uc1" %>
    <%@ Register Src="ctlAccountEmployeeTimeEntryApprovalDetailsReadOnly.ascx" TagName="ctlAccountEmployeeTimeEntryApprovalDetailsReadOnly"
    TagPrefix="uc2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc2" %>
<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<%@ Register Assembly="LiveTools" Namespace="LiveTools" TagPrefix="cc1" %>

<script type="text/javascript">
    evt = ""; // Defeat the Chrome bug
</script>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <x:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                        Caption="Week View Template" 
                        DataKeyNames="AccountEmployeeTimeEntryTemplateId" 
                        DataSourceID="dsAccountTimeExpenseBillingTimesheetObject" 
                        OnDataBound="GridView1_DataBound" OnRowDataBound="GridView1_RowDataBound" 
                        OnRowDeleting="GridView1_RowDeleting" SkinID="xgridviewSkinEmployee" 
                        Width="98%">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:DropDownList ID="C" runat="server" __designer:wfdid="w1" 
                                        DataSourceID="dsAccountClientObject" DataTextField="PartyName" 
                                        DataValueField="AccountPartyId" Width="100%">
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="dsAccountClientObject" runat="server" 
                                        __designer:wfdid="w3" OldValuesParameterFormatString="original_{0}" 
                                        SelectMethod="GetAccountPartiesForTimeEntryByAccountEmployeeId" 
                                        TypeName="AccountPartyBLL">
                                        <SelectParameters>
                                            <asp:SessionParameter Name="AccountEmployeeId" SessionField="AccountEmployeeID" 
                                                Type="Int32" />
                                            <asp:Parameter Name="AccountClientId" Type="Int32" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Project Name %>">
                                <ItemTemplate>
                                    <asp:DropDownList ID="P" runat="server" __designer:wfdid="w28" 
                                        DataTextField="ProjectName" DataValueField="AccountProjectId" Width="100%">
                                    </asp:DropDownList>
                                    <cc2:CascadingDropDown ID="CP" runat="server" __designer:wfdid="w31" 
                                        Category="Project" LoadingText="Loading" ParentControlID="C" 
                                        PromptText="Select Project" ServiceMethod="GetAccountProjectsByClient" 
                                        ServicePath="~/Services/ProjectService.asmx" TargetControlID="P">
                                    </cc2:CascadingDropDown>
                                    <asp:ObjectDataSource ID="dsAccountProjectsObject" runat="server" 
                                        __designer:wfdid="w29" DeleteMethod="DeleteAccountProject" 
                                        InsertMethod="AddAccountProject" OldValuesParameterFormatString="original_{0}" 
                                        SelectMethod="GetAssignedAccountProjectsByAccountEmployeeIdAndAccountProjectIdForIsDeletedClient" 
                                        TypeName="AccountProjectBLL" UpdateMethod="UpdateProjectDescription">
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
                                            <asp:Parameter Name="AccountProjectId" Type="Int32" />
                                            <asp:SessionParameter DefaultValue="39" Name="AccountEmployeeId" 
                                                SessionField="AccountEmployeeId" Type="Int32" />
                                            <asp:Parameter Name="Completed" Type="Boolean" />
                                            <asp:QueryStringParameter Name="IsTemplate" QueryStringField="IsTemplate" 
                                                Type="Boolean" />
                                            <asp:Parameter Name="AccountId" Type="Int32" />
                                        </SelectParameters>
                                        <UpdateParameters>
                                            <asp:Parameter Name="ProjectDescription" Type="String" />
                                            <asp:Parameter Name="Original_AccountProjectId" Type="Int32" />
                                        </UpdateParameters>
                                    </asp:ObjectDataSource>
                                    <asp:ObjectDataSource ID="dsAccountProjectTasksObject" runat="server" 
                                        __designer:wfdid="w30" OldValuesParameterFormatString="original_{0}" 
                                        TypeName="AccountProjectTaskBLL">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="P" DefaultValue="9" Name="AccountProjectId" 
                                                PropertyName="Text" Type="Int32" />
                                            <asp:SessionParameter DefaultValue="39" Name="AccountEmployeeId" 
                                                SessionField="AccountEmployeeId" Type="Int32" />
                                            <asp:Parameter Name="AccountProjectTaskId" Type="Int32" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                                </ItemTemplate>
                                <itemstyle horizontalalign="Left" width="20%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Task Name %>">
                                <ItemTemplate>
                                    <asp:DropDownList ID="PT" runat="server" __designer:wfdid="w34" 
                                        DataTextField="TaskName" DataValueField="AccountProjectTaskId" Width="100%">
                                    </asp:DropDownList>
                                    <cc2:CascadingDropDown ID="CT" runat="server" __designer:wfdid="w37" 
                                        Category="Tasks" LoadingText="Loading" ParentControlID="P" 
                                        PromptText="<%$ Resources:TimeLive.Resource, Select Tasks%>" 
                                        ServiceMethod="GetAccountProjectTasksInTimeSheet" 
                                        ServicePath="~/Services/ProjectService.asmx" TargetControlID="PT">
                                    </cc2:CascadingDropDown>
                                </ItemTemplate>
                                <itemstyle horizontalalign="Left" width="20%" />
                            </asp:TemplateField>
                        </Columns>
                    </x:GridView>
                    <table style="width: 626px">
                <tr>
                    <td width="98%" align="Left" style="padding-top: 5px; padding-left: 5px;">
                        <asp:Button ID="btnSave" runat="server" Text="Save" Width="68px" />
                    </td>
                </tr>
                    </table>                    
                    <asp:ObjectDataSource ID="dsAccountTimeExpenseBillingTimesheetObject" 
                        runat="server" InsertMethod="AddAccountEmployeeTimeEntryTemplate" 
                        OldValuesParameterFormatString="original_{0}" 
                        SelectMethod="GetDataByAccountEmployeeId" 
                        TypeName="AccountEmployeeTimeEntryTemplate" 
                        UpdateMethod="UpdateAccountEmployeeTimeEntryTemplate">
                        <InsertParameters>
                            <asp:Parameter Name="AccountEmployeeId" Type="Int32" />
                            <asp:Parameter Name="AccountProjectId" Type="Int32" />
                            <asp:Parameter Name="AccountProjectTaskId" Type="Int32" />
                            <asp:Parameter Name="AccountId" Type="Int32" />
                        </InsertParameters>
                        <SelectParameters>
                            <asp:SessionParameter Name="AccountEmployeeId" SessionField="AccountEmployeeId" 
                                Type="Int32" />
                        </SelectParameters>
                        <UpdateParameters>
                            <asp:Parameter DbType="Guid" 
                                Name="AccountEmployeeTimeEntryTemplateId" />
                            <asp:Parameter Name="AccountEmployeeId" Type="Int32" />
                            <asp:Parameter Name="AccountProjectId" Type="Int32" />
                            <asp:Parameter Name="AccountProjectTaskId" Type="Int32" />
                            <asp:Parameter Name="AccountId" Type="Int32" />
                        </UpdateParameters>
                    </asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="dsAccountProjectObjectTimesheet" runat="server" 
                        DeleteMethod="DeleteAccountProject" InsertMethod="AddAccountProject" 
                        OldValuesParameterFormatString="original_{0}" 
                        SelectMethod="GetAssignedAccountProjectsByAccountEmployeeIdAndAccountProjectIdForIsDeletedClient" 
                        TypeName="AccountProjectBLL" UpdateMethod="UpdateProjectDescription">
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
                            <asp:Parameter DefaultValue="0" Name="AccountProjectId" Type="Int32" />
                            <asp:SessionParameter DefaultValue="" Name="AccountEmployeeId" 
                                SessionField="AccountEmployeeId" Type="Int32" />
                            <asp:Parameter Name="Completed" Type="Boolean" />
                            <asp:Parameter DefaultValue="False" Name="IsTemplate" Type="Boolean" />
                            <asp:Parameter Name="AccountId" Type="Int32" />
                        </SelectParameters>
                        <UpdateParameters>
                            <asp:Parameter Name="ProjectDescription" Type="String" />
                            <asp:Parameter Name="Original_AccountProjectId" Type="Int32" />
                        </UpdateParameters>
                    </asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="dsAccountProjectObject" runat="server" 
                        OldValuesParameterFormatString="original_{0}" 
                        SelectMethod="GetAccountClientByAccountProjectIdandIsDisabled" 
                        TypeName="AccountProjectBLL">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="" Name="AccountClientId" Type="Int32" />
                            <asp:Parameter DefaultValue="0" Name="AccountProjectId" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="dsAccountClientObjectEdit" runat="server" 
                        OldValuesParameterFormatString="original_{0}" 
                        SelectMethod="GetAccountPartiesByAccountIdAndAccountPartyId" 
                        TypeName="AccountPartyBLL">
                        <SelectParameters>
                            <asp:SessionParameter DefaultValue="39" Name="AccountId" 
                                SessionField="AccountId" Type="Int32" />
                            <asp:Parameter DefaultValue="" Name="AccountPartyId" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" 
                        InsertMethod="UpdateAccountExpenseEntryBillStatus" 
                        OldValuesParameterFormatString="original_{0}" 
                        SelectMethod="GetAccountExpenseEntryByAccountProjectIdandAccountExpenseId" 
                        TypeName="AccountTimeExpenseBillingBLL">
                        <SelectParameters>
                            <asp:Parameter Name="AccountProjectId" Type="Int32" />
                            <asp:Parameter Name="AccountExpenseId" Type="Int32" />
                            <asp:Parameter Name="ExpenseEntryStartDate" Type="DateTime" />
                            <asp:Parameter Name="ExpenseEntryEndDate" Type="DateTime" />
                        </SelectParameters>
                        <InsertParameters>
                            <asp:Parameter Name="AccountTimeExpenseBillingExpenseId" />
                            <asp:Parameter Name="AccountProjectId" Type="Int32" />
                            <asp:Parameter Name="AccountExpenseId" Type="Int32" />
                            <asp:Parameter Name="Billed" Type="Boolean" />
                            <asp:Parameter Name="ExpenseEntryStartDate" Type="DateTime" />
                            <asp:Parameter Name="ExpenseEntryEndDate" Type="DateTime" />
                        </InsertParameters>
                    </asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
                        InsertMethod="UpdateAccountEmployeeTimeEntryBillStatus" 
                        OldValuesParameterFormatString="original_{0}" 
                        SelectMethod="GetAccountEmployeeTimeEntryByAccountTimeExpenseBillingTimesheeetId" 
                        TypeName="AccountTimeExpenseBillingBLL">
                        <SelectParameters>
                            <asp:Parameter Name="AccountProjectId" Type="Int32" />
                            <asp:Parameter Name="AccountProjectTaskId" Type="Int32" />
                            <asp:Parameter Name="AccountTimeExpenseBillingTimesheetId" Type="Int32" />
                            <asp:Parameter Name="TimeEntryStartDate" Type="DateTime" />
                            <asp:Parameter Name="TimeEntryEndDate" Type="DateTime" />
                        </SelectParameters>
                        <InsertParameters>
                            <asp:Parameter Name="AccountProjectId" Type="Int32" />
                            <asp:Parameter Name="AccountProjectTaskId" Type="Int32" />
                            <asp:Parameter Name="AccountTimeExpenseBillingTimesheetId" />
                            <asp:Parameter Name="Billed" Type="Boolean" />
                            <asp:Parameter Name="TimeEntryStartDate" Type="DateTime" />
                            <asp:Parameter Name="TimeEntryEndDate" Type="DateTime" />
                        </InsertParameters>
                    </asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="dsAccountTimeExpenseBillingExpenseObject" 
                        runat="server" InsertMethod="AddAccountTimeExpenseBillingExpense" 
                        OldValuesParameterFormatString="original_{0}" 
                        SelectMethod="GetvueAccountTimeExpenseBillingExpenseByAccountTimeExpenseBillingId" 
                        TypeName="AccountTimeExpenseBillingBLL" 
                        UpdateMethod="UpdateAccountTimeExpenseBillingExpense">
                        <SelectParameters>
                            <asp:Parameter DbType="Guid" Name="AccountTimeExpenseBillingId" />
                        </SelectParameters>
                        <UpdateParameters>
                            <asp:Parameter DbType="Guid" 
                                Name="Original_AccountTimeExpenseBillingExpenseId" />
                            <asp:Parameter DbType="Guid" Name="AccountTimeExpenseBillingId" />
                            <asp:Parameter Name="AccountId" Type="Int32" />
                            <asp:Parameter Name="AccountProjectId" Type="Int32" />
                            <asp:Parameter Name="AccountExpenseId" Type="Int32" />
                            <asp:Parameter Name="AccountExpenseTypeId" Type="Int32" />
                            <asp:Parameter Name="Description" Type="String" />
                            <asp:Parameter Name="ActualExpenseAmount" Type="Double" />
                            <asp:Parameter Name="BilledExpenseAmount" Type="Double" />
                            <asp:Parameter Name="AccountTaxCodeId1" Type="Int32" />
                            <asp:Parameter Name="AccountTaxCodeId2" Type="Int32" />
                            <asp:Parameter Name="TaxCode1" Type="Double" />
                            <asp:Parameter Name="TaxCode2" Type="Double" />
                            <asp:Parameter Name="AccountExpenseEntryId" Type="Int32" />
                        </UpdateParameters>
                        <InsertParameters>
                            <asp:Parameter DbType="Guid" Name="AccountTimeExpenseBillingId" />
                            <asp:Parameter Name="AccountId" Type="Int32" />
                            <asp:Parameter Name="AccountProjectId" Type="Int32" />
                            <asp:Parameter Name="AccountExpenseTypeId" Type="Int32" />
                            <asp:Parameter Name="AccountExpenseId" Type="Int32" />
                            <asp:Parameter Name="Description" Type="String" />
                            <asp:Parameter Name="ActualExpenseAmount" Type="Double" />
                            <asp:Parameter Name="BilledExpenseAmount" Type="Double" />
                            <asp:Parameter Name="AccountTaxCodeId1" Type="Int32" />
                            <asp:Parameter Name="AccountTaxCodeId2" Type="Int32" />
                            <asp:Parameter Name="TaxCode1" Type="Double" />
                            <asp:Parameter Name="TaxCode2" Type="Double" />
                            <asp:Parameter Name="AccountExpenseEntryId" Type="Int32" />
                        </InsertParameters>
                    </asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="dsAccountTimeExpenseBillingObject" runat="server" 
                        InsertMethod="AddAccountTimeExpenseBilling" 
                        OldValuesParameterFormatString="original_{0}" 
                        SelectMethod="GetAccountTimeExpenseBillingByAccountIdAndAccountTimeExpenseBillingId" 
                        TypeName="AccountTimeExpenseBillingBLL" 
                        UpdateMethod="UpdateAccountTimeExpenseBilling">
                        <SelectParameters>
                            <asp:SessionParameter DefaultValue="57" Name="AccountId" 
                                SessionField="AccountId" Type="Int32" />
                            <asp:Parameter DbType="Guid" Name="AccountTimeExpenseBillingId" />
                        </SelectParameters>
                        <InsertParameters>
                            <asp:SessionParameter DefaultValue="53" Name="AccountId" 
                                SessionField="AccountId" Type="Int32" />
                            <asp:Parameter Name="AccountClientId" Type="Int32" />
                            <asp:Parameter Name="AccountProjectId" Type="Int32" />
                            <asp:Parameter Name="AccountCurrencyId" Type="Int32" />
                            <asp:Parameter Name="Description" Type="String" />
                            <asp:Parameter Name="BillingCycleStartDate" Type="DateTime" />
                            <asp:Parameter Name="BillingCycleEndDate" Type="DateTime" />
                            <asp:Parameter Name="InvoiceDate" Type="DateTime" />
                            <asp:Parameter Name="InvoiceNo" Type="String" />
                            <asp:Parameter Name="PONumber" Type="String" />
                            <asp:Parameter Name="SubTotal" Type="Double" />
                            <asp:Parameter Name="TaxCode1" Type="Double" />
                            <asp:Parameter Name="TaxCode2" Type="Double" />
                            <asp:Parameter Name="GrandTotal" Type="Double" />
                            <asp:Parameter Name="IsPaid" Type="Boolean" />
                            <asp:Parameter Name="Terms" Type="String" />
                            <asp:Parameter Name="BankDetails" Type="String" />
                            <asp:Parameter Name="ParentAccountProjectTaskId" Type="Int32" />
                            <asp:Parameter Name="GroupTimesheetBillingListBy" Type="String" />
                            <asp:Parameter Name="GroupExpenseBillingListBy" Type="String" />
                        </InsertParameters>
                        <UpdateParameters>
                            <asp:Parameter DbType="Guid" Name="Original_AccountTimeExpenseBillingId" />
                            <asp:Parameter Name="AccountId" Type="Int32" />
                            <asp:Parameter Name="AccountClientId" Type="Int32" />
                            <asp:Parameter Name="AccountProjectId" Type="Int32" />
                            <asp:Parameter Name="AccountCurrencyId" Type="Int32" />
                            <asp:Parameter Name="Description" Type="String" />
                            <asp:Parameter Name="BillingCycleStartDate" Type="DateTime" />
                            <asp:Parameter Name="BillingCycleEndDate" Type="DateTime" />
                            <asp:Parameter Name="InvoiceDate" Type="DateTime" />
                            <asp:Parameter Name="InvoiceNo" Type="String" />
                            <asp:Parameter Name="PONumber" Type="String" />
                            <asp:Parameter Name="SubTotal" Type="Double" />
                            <asp:Parameter Name="TaxCode1" Type="Double" />
                            <asp:Parameter Name="TaxCode2" Type="Double" />
                            <asp:Parameter Name="GrandTotal" Type="Double" />
                            <asp:Parameter Name="Terms" Type="String" />
                            <asp:Parameter Name="BankDetails" Type="String" />
                            <asp:Parameter Name="ParentAccountProjectTaskId" Type="Int32" />
                            <asp:Parameter Name="GroupTimesheetBillingListBy" Type="String" />
                            <asp:Parameter Name="GroupExpenseBillingListBy" Type="String" />
                        </UpdateParameters>
                    </asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="dsAccountTimeExpenseBilling" runat="server" 
                        InsertMethod="AddAccountTimeExpenseBilling" 
                        OldValuesParameterFormatString="original_{0}" 
                        SelectMethod="GetAccountTimeExpenseBillingByAccountIdAndAccountTimeExpenseBillingId" 
                        TypeName="AccountTimeExpenseBillingBLL" 
                        UpdateMethod="UpdateAccountTimeExpenseBilling">
                        <UpdateParameters>
                            <asp:Parameter DbType="Guid" Name="Original_AccountTimeExpenseBillingId" />
                            <asp:Parameter Name="AccountId" Type="Int32" />
                            <asp:Parameter Name="AccountClientId" Type="Int32" />
                            <asp:Parameter Name="AccountProjectId" Type="Int32" />
                            <asp:Parameter Name="AccountCurrencyId" Type="Int32" />
                            <asp:Parameter Name="Description" Type="String" />
                            <asp:Parameter Name="BillingCycleStartDate" Type="DateTime" />
                            <asp:Parameter Name="BillingCycleEndDate" Type="DateTime" />
                            <asp:Parameter Name="InvoiceDate" Type="DateTime" />
                            <asp:Parameter Name="InvoiceNo" Type="String" />
                            <asp:Parameter Name="PONumber" Type="String" />
                            <asp:Parameter Name="SubTotal" Type="Double" />
                            <asp:Parameter Name="TaxCode1" Type="Double" />
                            <asp:Parameter Name="TaxCode2" Type="Double" />
                            <asp:Parameter Name="GrandTotal" Type="Double" />
                            <asp:Parameter Name="Terms" Type="String" />
                            <asp:Parameter Name="BankDetails" Type="String" />
                            <asp:Parameter Name="ParentAccountProjectTaskId" Type="Int32" />
                            <asp:Parameter Name="GroupTimesheetBillingListBy" Type="String" />
                            <asp:Parameter Name="GroupExpenseBillingListBy" Type="String" />
                        </UpdateParameters>
                        <SelectParameters>
                            <asp:SessionParameter DefaultValue="55" Name="AccountId" 
                                SessionField="AccountId" Type="Int32" />
                            <asp:Parameter DbType="Guid" Name="AccountTimeExpenseBillingId" />
                        </SelectParameters>
                        <InsertParameters>
                            <asp:Parameter Name="AccountId" Type="Int32" />
                            <asp:Parameter Name="AccountClientId" Type="Int32" />
                            <asp:Parameter Name="AccountProjectId" Type="Int32" />
                            <asp:Parameter Name="AccountCurrencyId" Type="Int32" />
                            <asp:Parameter Name="Description" Type="String" />
                            <asp:Parameter Name="BillingCycleStartDate" Type="DateTime" />
                            <asp:Parameter Name="BillingCycleEndDate" Type="DateTime" />
                            <asp:Parameter Name="InvoiceDate" Type="DateTime" />
                            <asp:Parameter Name="InvoiceNo" Type="String" />
                            <asp:Parameter Name="PONumber" Type="String" />
                            <asp:Parameter Name="SubTotal" Type="Double" />
                            <asp:Parameter Name="TaxCode1" Type="Double" />
                            <asp:Parameter Name="TaxCode2" Type="Double" />
                            <asp:Parameter Name="GrandTotal" Type="Double" />
                            <asp:Parameter Name="IsPaid" Type="Boolean" />
                            <asp:Parameter Name="Terms" Type="String" />
                            <asp:Parameter Name="BankDetails" Type="String" />
                            <asp:Parameter Name="ParentAccountProjectTaskId" Type="Int32" />
                            <asp:Parameter Name="GroupTimesheetBillingListBy" Type="String" />
                            <asp:Parameter Name="GroupExpenseBillingListBy" Type="String" />
                        </InsertParameters>
                    </asp:ObjectDataSource>
                </ContentTemplate>
            </asp:UpdatePanel>
            


