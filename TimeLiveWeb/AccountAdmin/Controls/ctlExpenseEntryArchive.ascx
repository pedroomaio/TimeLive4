<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlExpenseEntryArchive.ascx.vb" Inherits="AccountAdmin_Controls_ctlExpenseEntryArchive" %>
<%@ Register Assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2"
    Namespace="eWorld.UI" TagPrefix="ew" %>


<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <table class="xFormView">
            <tr>
                <asp:HiddenField ID="hdfield" runat="server" Value="" ClientIDMode="Static"/>
                <td>
                    <table style="width: 850px;" class="xFormView">
                        <tr>
                            <th class="caption" colspan="2">
                                <asp:Literal ID="Literal5" runat="server" Text="<%$ Resources:TimeLive.Resource, Expense Entry Archive%> " /></th>
                        </tr>
                        <tr>
                            <th class="FormViewSubHeader" colspan="2">
                                <asp:Literal ID="Literal1" runat="server" Text="<%$ Resources:TimeLive.Resource, Search Parameters%> " /></th>
                        </tr>
                        <tr>
                            <td align="right" class="formviewlabelcell" style="width: 30%">
                                <asp:Literal ID="Literal2" runat="server" Text="<%$ Resources:TimeLive.Resource, Employees:%> " /></td>
                            <td align="left" style="width: 256px; padding-left: 3px">
                                <asp:DropDownList ID="ddlEmployees" runat="server" AppendDataBoundItems="True"
                                    Width="45%">
                                    <asp:ListItem Selected="True" Value="0" ID="Label15" runat="server" Text="<%$ Resources:TimeLive.Resource, All%> "></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" class="formviewlabelcell">
                                <asp:Literal ID="Literal6" runat="server" Text="<%$ Resources:TimeLive.Resource, Approved%> " />:</td>
                            <td align="left" style="width: 256px; padding-left: 3px">
                                <asp:DropDownList ID="ddlApproved" runat="server" AppendDataBoundItems="True"
                                    Width="108px">
                                    <%--<asp:ListItem Value="1">Approved</asp:ListItem>--%>
                                    <asp:ListItem Value="1" ID="Label4" runat="server" Text="<%$ Resources:TimeLive.Resource, Approved%> "></asp:ListItem>
                                    <%--<asp:ListItem Value="0">Not Approved</asp:ListItem>--%>
                                    <asp:ListItem Value="0" ID="Label5" runat="server" Text="<%$ Resources:TimeLive.Resource, Not Approved%> "></asp:ListItem>
                                    <%--<asp:ListItem Selected="True" Value="-1">Both</asp:ListItem>--%>
                                    <asp:ListItem Selected="True" Value="-1" ID="Label6" runat="server" Text="<%$ Resources:TimeLive.Resource, Both%> "></asp:ListItem>
                                </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td align="right" class="formviewlabelcell">
                                <asp:Literal ID="ExpesesTypeLiteral" runat="server" Text="Expense types" />:</td>
                            <td>
                                <asp:ListBox AppendDataBoundItems="true" ID="ListBoxExpenseType" SelectionMode="Multiple" runat="server" ClientIDMode="Static" DataSourceID="dsAccountExpenseObject" DataTextField="ExpenseType" DataValueField="AccountExpenseTypeId" Style="height: 100px; width: 240px"></asp:ListBox>
                                <asp:Button ID="Btn_Right_Transfer" ClientIDMode="Static" runat="server" Text=">>" Font-Size="Smaller" CssClass="button blue-gradient glossy" Style="left: 19px; bottom: 20px;" OnClientClick="RightButton(); return false;" />
                                <asp:Button ID="Btn_Left_Transfer" ClientIDMode="Static" runat="server" Text="<<" Font-Size="Smaller" CssClass="button blue-gradient glossy" Style="right: 19px; top: 20px;" OnClientClick="LeftButton(); return false;" />
                                <asp:ListBox ID="ListBoxExpenseType2" ClientIDMode="Static" runat="server" SelectionMode="Multiple" Style="height: 100px; width: 240px"></asp:ListBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" class="formviewlabelcell">
                                <asp:Literal ID="Literal3" runat="server" Text="Payment status" />:</td>
                            <td>
                                <asp:DropDownList ID="PaymentStatusddl" runat="server" DataSourceID="dsPaymentStatusObject" DataTextField="State" DataValueField="Id"></asp:DropDownList>
                            </td>
                        </tr>                       
                        <tr>
                            <td align="right">
                                <asp:Literal ID="Literal8" runat="server" Text="<%$ Resources:TimeLive.Resource, Include Date Range:%>  " />
                            </td>
                            <td align="left" style="width: 256px; padding-left: 3px">
                                <asp:CheckBox ID="chkIncludeDateRange" runat="server" /></td>
                        </tr>
                        <tr>
                            <td align="right" class="formviewlabelcell">
                                <asp:Literal ID="Literal9" runat="server" Text="<%$ Resources:TimeLive.Resource, Start Date%> " />:</td>
                            <td align="left" style="width: 256px; padding-left: 3px">
                                <ew:CalendarPopup ID="StartDate" runat="server" SkinID="DatePicker"
                                    Width="55px">
                                </ew:CalendarPopup>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" class="formviewlabelcell">
                                <asp:Literal ID="Literal10" runat="server" Text="<%$ Resources:TimeLive.Resource, End Date%> " />:</td>
                            <td align="left" style="width: 256px; padding-left: 3px">
                                <ew:CalendarPopup ID="EndDate" runat="server" SkinID="DatePicker" Width="55px"></ew:CalendarPopup>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" class="formviewlabelcell">
                                <asp:Literal ID="Literal4" runat="server" Text="Search For" />:</td>
                            <td>
                                <asp:RadioButton runat="server" GroupName="SearchForRadios" ID="SheetRadio" Text="Expense Sheet" Checked="true" />
                                <asp:RadioButton runat="server" GroupName="SearchForRadios" ID="EntryRadio" Text="Expense Entry" />
                            </td>
                        </tr>
                        <tr>
                            <td align="right" class="formviewlabelcell"></td>
                            <td align="left" class="formviewlabelcell" style="padding-bottom: 5px; padding-left: 3px; padding-top: 5px;">
                                <asp:Button ID="Show" runat="server" OnClick="Show_Click" Text="<%$ Resources:TimeLive.Resource, Show_text%> " Width="68px" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <asp:ObjectDataSource ID="dsClientsObject" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetAccountPartiesByAccountId" TypeName="AccountPartyBLL">
            <SelectParameters>
                <asp:SessionParameter DefaultValue="99" Name="AccountId" SessionField="AccountId"
                    Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="dsEmployeesObject" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetAccountEmployeesViewByAccountIdWithDisabled" TypeName="AccountEmployeeBLL">
            <SelectParameters>
                <asp:SessionParameter DefaultValue="64" Name="AccountId" SessionField="AccountId"
                    Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>

        <asp:ObjectDataSource ID="dsAccountExpenseObject" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetAccountExpenseTypesByAccountId" TypeName="AccountExpenseTypeBLL">
            <SelectParameters>
                <asp:SessionParameter DefaultValue="64" Name="AccountId" SessionField="AccountId"
                    Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>

        <asp:ObjectDataSource ID="dsPaymentStatusObject" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetPaymentStatus" TypeName="PaymentStatusBLL">
            <SelectParameters>
            </SelectParameters>
        </asp:ObjectDataSource>

        <asp:ObjectDataSource ID="dsProjectsObject" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetvueAccountProjectsByAccountId"
            TypeName="AccountProjectBLL" DeleteMethod="DeleteAccountProject"
            InsertMethod="AddAccountProject" UpdateMethod="UpdateProjectDescription">
            <SelectParameters>
                <asp:SessionParameter Name="AccountId" SessionField="AccountId" Type="Int32" />
            </SelectParameters>
            <DeleteParameters>
                <asp:Parameter Name="Original_AccountProjectId" Type="Int32" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="ProjectDescription" Type="String" />
                <asp:Parameter Name="Original_AccountProjectId" Type="Int32" />
            </UpdateParameters>
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
                <asp:Parameter Name="DeadLine" Type="DateTime" />
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
        </asp:ObjectDataSource>
    </ContentTemplate>
</asp:UpdatePanel>
<br />
<asp:UpdatePanel ID="UpdatePanel2" runat="server">
    <ContentTemplate>
        <x:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="AccountEmployeeExpenseSheetId"
            DataSourceID="dsUpdateExpenseEntryArchive" SkinID="xgridviewSkinEmployee" Caption="<%$ Resources:TimeLive.Resource, Expense Entry Archive %>" Width="98%" OnRowDataBound="GridView1_RowDataBound">
            <columns>
                <asp:TemplateField>
                    <itemtemplate>
<asp:CheckBox id="chkDelete" runat="server" __designer:wfdid="w3"></asp:CheckBox> 
</itemtemplate>
                    <ItemStyle Width="1%" />
                </asp:TemplateField>
                <asp:TemplateField SortExpression="EmployeeName" HeaderText="<%$ Resources:TimeLive.Resource, Employee Name %>">
                    <itemstyle width="30%" />
                    <itemtemplate>
<asp:LinkButton id="lnkEmployeeName" OnClick="lnkEmployeeName_Click" runat="server" Text='<%# Bind("EmployeeName") %>' NavigateUrl='<%# Eval("AccountEmployeeExpenseSheetId", "~/Employee/AccountExpenseEntryReadOnly.aspx?AccountEmployeeExpenseSheetId={0}&IsFromArchive=True") %>'  __designer:wfdid="w6"></asp:LinkButton>
</itemtemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="ExpenseSheetDate" DataFormatString="{0:d}" HeaderText="<%$ Resources:TimeLive.Resource, Date %>"
                    HtmlEncode="False" SortExpression="ExpenseSheetDate" ReadOnly="True">
                    <itemstyle horizontalalign="Center" width="7%" />
                </asp:BoundField>
                <asp:BoundField DataField="Description" HeaderText="<%$ Resources:TimeLive.Resource, Description %>" ReadOnly="True"
                    SortExpression="Description" >
                    <itemstyle horizontalalign="Left" width="40%" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Amount %>" SortExpression="Amount">
                    <EditItemTemplate>
<asp:Label id="Label2" runat="server" Text='<%# Eval("CurrencyCode") %>' __designer:wfdid="w3"></asp:Label> <asp:Label id="Label1" runat="server" Text='<%# Eval("Amount", "{0:N}") %>' __designer:wfdid="w4"></asp:Label> 
</EditItemTemplate>
                    <ItemStyle HorizontalAlign="Right" width="10%" />
                    <ItemTemplate>
<asp:Label id="Label2" runat="server" Text='<%# Eval("CurrencyCode") %>' __designer:wfdid="w1"></asp:Label> <asp:Label id="Label1" runat="server" Text='<%# Eval("Amount", "{0:N}") %>' __designer:wfdid="w2"></asp:Label> 
</ItemTemplate>
                </asp:TemplateField>
                <asp:CheckBoxField DataField="Submitted" HeaderText="<%$ Resources:TimeLive.Resource, Submitted %>" >
                    <ItemStyle HorizontalAlign="Center" Width="5%" />
                </asp:CheckBoxField>
                <asp:CheckBoxField DataField="Approved" HeaderText="<%$ Resources:TimeLive.Resource, Approved %>"  >
                    <ItemStyle HorizontalAlign="Center" Width="5%" />
                </asp:CheckBoxField>
                    <asp:TemplateField HeaderText="Ready to pay" ItemStyle-HorizontalAlign ="Center" HeaderStyle-Wrap="false">
                    <itemstyle width="8%"/>
                    <itemtemplate>
                <asp:Label id="ReadyToPayLbl" runat="server" Text='0/0' __designer:wfdid="w6"></asp:Label>
                </itemtemplate>
               </asp:TemplateField>
                <asp:TemplateField HeaderText="Paid" ItemStyle-HorizontalAlign ="Center">
                    <itemstyle width="8%" />
                    <itemtemplate>
                <asp:Label id="PaidLbl" runat="server" Text='0/0' __designer:wfdid="w6"></asp:Label>
                </itemtemplate>
                </asp:TemplateField>

            <asp:CommandField HeaderText="<%$ Resources:TimeLive.Resource, Edit_text %>" ShowEditButton="True" EditImageUrl="~/Images/edit.gif">
                    <ItemStyle HorizontalAlign="Center"  Width="1%"/>
            </asp:CommandField>

        <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Delete_Text %>" ShowHeader="False">
     <ItemTemplate>
<asp:LinkButton id="LinkButton1" runat="server" __designer:wfdid="w13" OnClientClick="<%# ResourceHelper.GetDeleteMessageJavascript()%>" CommandName="Delete" CausesValidation="False"></asp:LinkButton> 
</ItemTemplate>
            <ItemStyle HorizontalAlign="Center"  cssclass="delete_button" Width="1%" />
        </asp:TemplateField>
            </columns>
        </x:GridView>
        <br />
        <div style="text-align: right">
            <table style="width: 98.5%">
                <tr>
                    <td align="left" style="width: 256px; padding-left: 5px;">
                        <asp:LinkButton ID="CheckAll" runat="server" CssClass="FeatureHeadingIcon"
                            OnClientClick="ChangeAllCheckBoxStates1(true);" Visible="False" OnClick="CheckAll_Click">
                            <asp:Literal ID="Literal19" runat="server" Text="<%$ Resources:TimeLive.Resource, Check-All %>"></asp:Literal>
                        </asp:LinkButton>
                        <asp:LinkButton
                            ID="UnCheckAll" runat="server" CssClass="FeatureHeadingIcon" OnClientClick="ChangeAllCheckBoxStates1(false);"
                            Visible="False" OnClick="UnCheckAll_Click">
                            <asp:Literal ID="Literal20" runat="server" Text="<%$ Resources:TimeLive.Resource, Uncheck-All %>"></asp:Literal>
                        </asp:LinkButton></td>

                    <td align="right">
                        <asp:Button ID="btnReadyToPaySelected" runat="server" Text="Ready to pay Selected"
                            Width="118px" Visible="false" OnClick="btnReadyToPaySelected_Click"/></td>
                    <td align="right">
                        <asp:Button ID="btnPaidSelected" runat="server" Text="Paid Selected"
                            Width="118px" Visible="false" OnClick="btnPaidSelected_Click" /></td>
                    <td align="right" style="width:150px">
                        <asp:Button ID="btnDeleteSelectedItem" runat="server" Text="<%$ Resources:TimeLive.Resource, Delete Selected%>"
                            Width="118px" OnClick="btnDeleteSelectedItem_Click" Visible="false" /></td>
                </tr>
            </table>
        </div>
        <asp:ObjectDataSource ID="dsUpdateExpenseEntryArchive" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetDataForExpenseEntryArchive" TypeName="AccountExpenseEntryBLL"
            UpdateMethod="UpdateExpenseEntryArchive">
            <UpdateParameters>
                <asp:Parameter Name="Original_AccountEmployeeExpenseSheetId" Type="Object" />
                <asp:Parameter Name="Approved" Type="Boolean" />
                <asp:Parameter Name="Submitted" Type="Boolean" />
                <asp:Parameter Name="EmployeeName" Type="String" />
            </UpdateParameters>
            <SelectParameters>
                <asp:SessionParameter DefaultValue="" Name="AccountId" SessionField="AccountId" Type="Int32" />
                <asp:ControlParameter ControlID="ddlEmployees" DefaultValue="" Name="AccountEmployees"
                    PropertyName="SelectedValue" Type="String" />
                <asp:ControlParameter ControlID="chkIncludeDateRange" Name="IncludeDateRange" PropertyName="Checked"
                    Type="Boolean" />
                <asp:Parameter Name="AccountExpenseEntryStartDate" Type="DateTime" DefaultValue="11/02/2008" />
                <asp:Parameter Name="AccountExpenseEntryEndDate" Type="DateTime" DefaultValue="11/02/2008" />
                <asp:ControlParameter ControlID="ddlApproved" DefaultValue="" Name="Approval" PropertyName="SelectedValue"
                    Type="String" />
                <asp:ControlParameter ControlID="PaymentStatusddl" Name="PaymentStatus" PropertyName="SelectedValue"
                    Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </ContentTemplate>
</asp:UpdatePanel>

<script src="../../js/jquery.min.js"></script>

<script>

        
    function RightButton()
    {
        $val = $("#ListBoxExpenseType").val();
        console.log("Going " + $val.toString());

        for (x in $val) {
            var fromItem = $("#ListBoxExpenseType option[value=" + $val[x] + "]");
            if ($("#ListBoxExpenseType2:has(option[value=" + $val[x] + "])").length > 0) {
                fromItem.val(fromItem.val() + "-2").text(fromItem.text() + " -2")
            };
            $("#ListBoxExpenseType2").append(fromItem);
        };
        $("#ListBoxExpenseType2 option[value=0]").appendTo($("#ListBoxExpenseType2"));
        EditArray();
    }

    function LeftButton()
    {
            $val = $("#ListBoxExpenseType2").val();
            console.log("Return " + $val.toString());

            for (x in $val) {
                var fromItem = $("#ListBoxExpenseType2 option[value=" + $val[x] + "]");
                if ($("#ListBoxExpenseType:has(option[value=" + $val[x] + "])").length > 0) {
                    fromItem.val(fromItem.val() + "-2").text(fromItem.text() + " -2")
                };
                $("#ListBoxExpenseType").append(fromItem);
            };
            $("#ListBoxExpenseType option[value=0]").appendTo($("#ListBoxExpenseType"));
            EditArray();
    }

    function EditArray() {
        var s = $('#ListBoxExpenseType2 option').map(function () {
            return this.value;
        }).get().join(',');
        $('#hdfield').val(s);
    }

</script>
