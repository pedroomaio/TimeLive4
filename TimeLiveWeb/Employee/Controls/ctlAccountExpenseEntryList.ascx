<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlAccountExpenseEntryList.ascx.vb"
    Inherits="Employee_Controls_ctlAccountExpenseEntryList" %>
<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<%@ Register Src="ctlStatusLegend.ascx" TagName="ctlStatusLegend" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24D65337282035F2"
    Namespace="eWorld.UI" TagPrefix="ew" %>
<%@ Register Src="ctlAccountEmployeeExpenseSheetApprovalDetailReadOnly.ascx" TagName="ctlAccountEmployeeExpenseSheetApprovalDetailReadOnly"
    TagPrefix="uc2" %>
<script runat="server">

    Protected Sub dsAccountExpenseEntryFormObject_Updating1(sender As Object, e As ObjectDataSourceMethodEventArgs)

    End Sub
</script>


<style type="text/css">
    input[type="checkbox"] {
        vertical-align: middle;
    }

    .fielddescription {
        font-weight: normal;
    }
     .circle {
        display: inline-block;
        height: 11px;
        width: 11px;
        border-radius: 55%; /* or 50% */
        background-color: blue;
        color: white;
        margin-top: -12px;
        line-height: 12px;
        font-family: Georgia !important;
        font-size : 9px !important ;
        font-weight : bold !important;
        cursor:pointer;  
        
    }

</style>

<script type="text/javascript" language='JavaScript'>

</script>

<asp:UpdatePanel ID="UpdatePanel3" runat="server">
    <ContentTemplate>
        <div class="fieldset" style="width: 95.5%; margin-left: 6px; padding-top: 8px">
            <table width="100%">
                <tr>
                    <td align="left" class="HighlightedTextMedium" style="width: 15%; height: 30px;">
                        <asp:Label ID="Label8" runat="server" Font-Bold="True" Font-Size="11px" Width="150px">
                            <asp:Literal ID="Literal7" runat="server" Text="<%$ Resources:TimeLive.Resource, Employee Name:%> " /></asp:Label></td>
                    <td align="left" class="HighlightedTextMedium" style="width: 30%">
                        <asp:DropDownList ID="ddlEmployeeName" runat="server" Width="312px" AutoPostBack="True"
                            OnSelectedIndexChanged="ddlEmployeeName_SelectedIndexChanged">
                        </asp:DropDownList>          
                        <asp:Button Id="PayBtPaymentStatus" Text="Pay Selected" runat="server" Width="100px" OnClick="PayBtPaymentStatus_Click" style="margin-bottom:10px" Visible="true"/>
                    </td>
                    <td align="right" class="HighlightedTextMedium"></td>
                </tr>
                <tr>
                    <td align="left" class="HighlightedTextMedium" style="width: 15%; height: 30px">
                        <asp:Label ID="Label14" runat="server" Font-Bold="True" Font-Size="11px" Width="150px">
                            <asp:Literal ID="Literal24" runat="server" Text="<%$ Resources:TimeLive.Resource, Description: %> " /></asp:Label></td>
                    <td align="left" class="HighlightedTextMedium">
                        <asp:TextBox ID="DescriptionTextBox" runat="server" Width="300px"></asp:TextBox>
                    </td>
                    <td align="right" class="HighlightedTextMedium" style="width: 40%">
                        <asp:Label ID="Label11" runat="server" Font-Bold="True" Font-Size="11px" Width="150px">
                            <asp:Literal ID="Literal111" runat="server" Text="<%$ Resources:TimeLive.Resource, Reimbursement Currency:%> " /></asp:Label>&nbsp;&nbsp;
                        &nbsp;<asp:DropDownList ID="ddlReimbursementCurrency" runat="server" AutoPostBack="True"
                            DataSourceID="dsReimbursementCurrencyObject" DataTextField="CurrencyCode" DataValueField="AccountCurrencyId"
                            OnSelectedIndexChanged="ddlReimbursementCurrency_SelectedIndexChanged" Width="90px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="left" class="HighlightedTextMedium" style="width: 15%; height: 35px; vertical-align: middle;">
                        <asp:Label ID="Label12" runat="server" Font-Bold="True" Font-Size="11px" Width="150px">
                            <asp:Literal ID="Literal25" runat="server" Text="<%$ Resources:TimeLive.Resource, Date:%> " /></asp:Label></td>
                    <td align="left" class="HighlightedTextMedium">
                        <asp:DropDownList ID="ddlExpenseSheetDate" runat="server" AutoPostBack="True" Width="90px" OnSelectedIndexChanged="ddlExpenseSheetDate_SelectedIndexChanged" >
                        </asp:DropDownList>
                        <asp:Button ID="btnMasterUpdate" runat="server" OnClick="btnMasterUpdate_Click" Text="<%$ Resources:TimeLive.Resource, Update%> " />
                    </td>
                    <td align="right" class="HighlightedTextMedium" style="width: 40%">
                        <asp:Label ID="Label13" runat="server" Font-Bold="True" Font-Size="11px" Width="150px">
                            <asp:Literal ID="Literal2" runat="server" Text="<%$ Resources:TimeLive.Resource, Total Reimbursement%> " /></asp:Label>&nbsp;&nbsp;
                        &nbsp;
                        <asp:TextBox Width="77px" ID="txtTotalReimbursement" runat="server" ReadOnly="True"
                            Style="text-align: right" />
                    </td>
                </tr>
                <tr>
                    <td class="HighlightedTextMedium" style="width: 15%; height: 0px; vertical-align: middle;"
                        align="left" valign="middle">
                        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="11px" Width="150px">
                            <asp:Literal ID="Literal26" runat="server" Text="<%$ Resources:TimeLive.Resource, Expense Sheet Status%> " />:</asp:Label></td>
                    <td class="HighlightedTextMedium" colspan="1" style="width: 48%" align="left" valign="middle">
                        <asp:Image ID="imgES" runat="server" ImageAlign="Middle" ImageUrl="~/Images/clearpixel.gif"
                            Width="12px" CssClass="statuslabel" />&nbsp;<asp:Label ID="lblExpenseStatus" runat="server"
                                Text="Label" CssClass="statuslabel" Width="150px" Font-Bold="true" Font-Size="11px"></asp:Label></td>
                </tr>
            </table>
        </div>
        <%--<table width="72%" class="xFormView" style="border:1px Solid #d6dadf"><tr><td>--%><asp:Table
            ID="MainCustomTable" class="xFormView" runat="server" Width="72%" Style="border: 1px Solid #d6dadf">
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Table ID="CustomTable" runat="server" Width="100%">
                    </asp:Table>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <asp:Table ID="ltrTable" runat="server" Width="100%">
        </asp:Table>
        <%--  </td></tr></table> 
                            <br />--%>
        <asp:ObjectDataSource ID="dsExpenseSheetObject" runat="server" InsertMethod="AddAccountEmployeeExpenseSheet"
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetAccountEmployeeExpenseSheetByAccountEmployeeExpenseSheetId"
            TypeName="AccountEmployeeExpenseSheetBLL" UpdateMethod="UpdateAccountEmployeeExpenseSheet"
            DataObjectTypeName="System.Guid" DeleteMethod="DeleteAccountEmployeeExpenseSheet">
            <UpdateParameters>
                <asp:Parameter Name="Description" Type="String" />
                <asp:Parameter Name="ddlExpenseSheetDate" Type="DateTime" />
                <asp:Parameter Name="Original_AccountEmployeeExpenseSheetId" DbType="Guid" />
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
            </UpdateParameters>
            <SelectParameters>
                <asp:Parameter Name="AccountEmployeeExpenseSheetId" DbType="Guid" />
            </SelectParameters>
            <InsertParameters>
                <asp:Parameter Name="AccountId" Type="Int32" />
                <asp:Parameter Name="AccountEmployeeId" Type="Int32" />
                <asp:Parameter Name="Description" Type="String" />
                <asp:Parameter Name="ddlExpenseSheetDate" Type="DateTime" />
                <asp:Parameter Name="Approved" Type="Boolean" />
                <asp:Parameter Name="Rejected" Type="Boolean" />
                <asp:Parameter Name="Submitted" Type="Boolean" />
                <asp:Parameter Name="InApproval" Type="Boolean" />
                <asp:Parameter Name="SubmittedDate" Type="DateTime" />
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
        <asp:ObjectDataSource ID="dsAccountReimbursementCurrencyFormViewObject" OldValuesParameterFormatString="original_{0}"
            runat="server" SelectMethod="GetPreferencesByAccountId" TypeName="AccountBLL">
            <SelectParameters>
                <asp:SessionParameter DefaultValue="151" Name="AccountId" SessionField="AccountId"
                    Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="dsReimbursementCurrencyObject" OldValuesParameterFormatString="original_{0}"
            runat="server" SelectMethod="GetvueAccountCurrencyByAccountIdAndDisabled" TypeName="AccountCurrencyBLL">
            <SelectParameters>
                <asp:SessionParameter DefaultValue="151" Name="AccountId" SessionField="AccountId"
                    Type="Int32" />
                <asp:Parameter Name="AccountCurrencyId" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </ContentTemplate>
</asp:UpdatePanel>
<x:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="AccountExpenseEntryId"
    DataSourceID="dsAccountExpenseEntryObject" AllowSorting="True" SkinID="xgridviewSkinEmployee"
    Caption='<%# ResourceHelper.GetFromResource("Expense Entry List") %>' ShowFooter="True"
    Width="98%">
    <Columns>
        <asp:TemplateField HeaderText="" Visible='true'>
            <ItemTemplate>
                <asp:CheckBox ID ="PayChkBox" runat="server" checked="false" Enabled='<%# IIf(Eval("PaymentStatusId").ToString() = "2", "False", "True") %>'></asp:CheckBox>
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Center" Width="2%" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Id %>" >
            <ItemTemplate >
                <asp:Label ID ="ExpenseEntryIdLbl" runat ="server" Text ='<%# Bind("AccountExpenseEntryId") %>'></asp:Label>
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Center" Width="5%" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Date %>">
            <EditItemTemplate>
                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("AccountExpenseEntryDate") %>'
                    __designer:wfdid="w40"></asp:TextBox>
            </EditItemTemplate>
            <HeaderTemplate>
                <asp:LinkButton ID="LinkButton3" runat="server" Text='<%# ResourceHelper.GetFromResource("Date") %>'
                    CommandArgument="AccountExpenseEntryDate" CommandName="Sort" CausesValidation="False"></asp:LinkButton>
            </HeaderTemplate>
            <ItemTemplate>
                <asp:Label ID="Label3" runat="server" Text='<%# Bind("AccountExpenseEntryDate", "{0:d}") %>'
                    __designer:wfdid="w39"></asp:Label>
            </ItemTemplate>
            <ItemStyle Width="8%" HorizontalAlign="Center" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Project Name %>">
            <EditItemTemplate>
                <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("ProjectName") %>' __designer:wfdid="w43"></asp:TextBox>
            </EditItemTemplate>
            <HeaderTemplate>
                <asp:LinkButton ID="LinkButton4" runat="server" Text='<%# ResourceHelper.GetFromResource("Project Name") %>'
                    CommandArgument="ProjectName" CommandName="Sort" CausesValidation="False"></asp:LinkButton>
            </HeaderTemplate>
            <ItemTemplate>
                <asp:Label ID="Label4" runat="server" Text='<%# Bind("ProjectName") %>' __designer:wfdid="w42"></asp:Label>
            </ItemTemplate>
            <ItemStyle Width="17%" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Task Name">
            <EditItemTemplate>
                <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("TaskName") %>' __designer:wfdid="w6"></asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="Label7" runat="server" Text='<%# Bind("TaskName") %>' __designer:wfdid="w1"></asp:Label>
            </ItemTemplate>
            <ItemStyle Width="13%" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Expense Name %>">
            <EditItemTemplate>
                <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("AccountExpenseName") %>'
                    __designer:wfdid="w46"></asp:TextBox>
            </EditItemTemplate>
            <HeaderTemplate>
                <asp:LinkButton ID="LinkButton5" runat="server" Text='<%# ResourceHelper.GetFromResource("Expense Name") %>'
                    CommandArgument="AccountExpenseName" CommandName="Sort" CausesValidation="False"></asp:LinkButton>
            </HeaderTemplate>
            <ItemTemplate>
                <asp:Label ID="Label5" runat="server" Text='<%# Bind("AccountExpenseName") %>' __designer:wfdid="w45"></asp:Label>
            </ItemTemplate>
            <ItemStyle Width="15%" />
        </asp:TemplateField>

        <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Description %>">
            <EditItemTemplate>
                <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("Description") %>' __designer:wfdid="w49"></asp:TextBox>
            </EditItemTemplate>
            <HeaderTemplate>
                <asp:LinkButton ID="LinkButton6" runat="server" Text='<%# ResourceHelper.GetFromResource("Description") %>'
                    CommandArgument="Description" CommandName="Sort" CausesValidation="False"></asp:LinkButton>
            </HeaderTemplate>
            <ItemTemplate>
                <asp:Label ID="Label6" runat="server" Text='<%# Bind("Description") %>' __designer:wfdid="w48"></asp:Label>
            </ItemTemplate>
            <ItemStyle Width="21%" />
        </asp:TemplateField>

        <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Description %>">
            <EditItemTemplate>
                <asp:TextBox ID="PaymentStatusTxt" runat="server" Text='<%# Bind("PaymentStatusState") %>' __designer:wfdid="w49"></asp:TextBox>
            </EditItemTemplate>
            <HeaderTemplate>
                <asp:LinkButton ID="PaymentStatusLinkBt" runat="server" Text='Payment Status'
                    CommandArgument="Description" CommandName="Sort" CausesValidation="False"></asp:LinkButton>
            </HeaderTemplate>
            <ItemTemplate>
                <asp:Label ID="PaymentStatusLbl" runat="server" Text='<%# Bind("PaymentStatusState") %>' __designer:wfdid="w48"></asp:Label>
            </ItemTemplate>
            <ItemStyle Width="5%" />
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Net Ammount">
            <EditItemTemplate>
                <asp:TextBox ID="TxtBox_NetAmount" runat="server" Text='<%# Bind("Amount") %>' __designer:wfdid="w53"></asp:TextBox>
            </EditItemTemplate>
            <HeaderTemplate>
                <asp:LinkButton ID="linkbt_NetAmount" runat="server" Text='Net Amount'
                    CommandArgument="Amount" CommandName="Sort" CausesValidation="False"></asp:LinkButton>
            </HeaderTemplate>
            <ItemTemplate>
                <asp:Label ID="Label1" runat="server" Text='<%# Bind("Amount", "{0:N}") %>' __designer:wfdid="w52"></asp:Label>
                <asp:Label ID="Label2" runat="server" Text='<%# Eval("CurrencyCode") %>' __designer:wfdid="w51"></asp:Label>
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Right" Width="10%" />
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Ammount(base)">
            <EditItemTemplate>
                <asp:TextBox ID="TxtBox_Amountbase" runat="server" Text='<%# Bind("Amount") %>' __designer:wfdid="w53"></asp:TextBox>
            </EditItemTemplate>
            <HeaderTemplate>
                <asp:LinkButton ID="lblAmountbase" runat="server" Text='<%# ResourceHelper.GetFromResource("Amount") %>'
                    CommandName="Sort" CommandArgument="Amount" CausesValidation="False"></asp:LinkButton>
            </HeaderTemplate>
            <ItemTemplate>
                <asp:Label ID="Label_Amount_Base" runat="server" Text='' __designer:wfdid="w52"></asp:Label><asp:Label ID="lblbaseCurrency" runat="server" Text='' __designer:wfdid="w51"></asp:Label>
                <asp:Label Visible="false" ID="Lbl_Amount" runat="server" Text='<%# Bind("Amount", "{0:N}") %>' __designer:wfdid="w52"></asp:Label>
                <asp:Label Visible="false" ID="Lbl_ExchangeRate" runat="server" Text='<%# Bind("ExchangeRate") %>' __designer:wfdid="w52"></asp:Label>
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Right" Width="10%" />
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Reimburse">
            <HeaderTemplate>
                <asp:LinkButton ID="ReimburseLinkBT" runat="server" Text='Reimburse'
                    CommandArgument="Status" CommandName="Sort" CausesValidation="False"></asp:LinkButton>
            </HeaderTemplate>
            <ItemTemplate>
                <asp:CheckBox ID="ChckBoxReimburse" runat="server" Enabled="false" Checked='<%# IIf(IsDBNull(Eval("Reimburse")), False, Eval("Reimburse")) %>'></asp:CheckBox>
            </ItemTemplate>
            <ItemStyle Width="10%" HorizontalAlign="Center" />
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Billable">
            <HeaderTemplate>
                <asp:LinkButton ID="BillableLinkBT" runat="server" Text='Billable'
                    CommandArgument="Status" CommandName="Sort" CausesValidation="False"></asp:LinkButton>
            </HeaderTemplate>
            <ItemTemplate>
                <asp:CheckBox ID="ChckBoxBilliable" runat="server" Enabled="false" Checked='<%# IIf(IsDBNull(Eval("IsBillable")), False, Eval("IsBillable")) %>'></asp:CheckBox>
            </ItemTemplate>
            <ItemStyle Width="10%" HorizontalAlign="Center" />
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Destination Country">
            <HeaderTemplate>
                <asp:LinkButton ID="DestCountryLinkBT" runat="server" Text='Destination Country'
                    CommandArgument="Status" CommandName="Sort" CausesValidation="False"></asp:LinkButton>
            </HeaderTemplate>
            <ItemTemplate>
                <asp:Label ID="DestCountrylbl" runat="server" Text='<%# Bind("CustomField1") %>' __designer:wfdid="w66"></asp:Label>
            </ItemTemplate>
            <ItemStyle Width="10%" HorizontalAlign="Center" />
        </asp:TemplateField>

        <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Edit_text %>" ShowHeader="False">
            <ItemTemplate>
                <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Select"
                    Text="Edit"></asp:LinkButton>
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Center" Width="1%" CssClass="edit_button" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Delete_text %>" ShowHeader="False">
            <ItemTemplate>
                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete"
                    OnClientClick='<%# ResourceHelper.GetDeleteMessageJavascript()%>' Text="Delete" />
            </ItemTemplate>
            <HeaderStyle HorizontalAlign="Center" />
            <ItemStyle HorizontalAlign="Center" Width="1%" CssClass="delete_button" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Attachment %>">
            <ItemTemplate>
                <asp:HyperLink ID="HyperLink1" runat="server" __designer:wfdid="w46" onclick="window.open (this.href, 'popupwindow', 'width=700,height=505,left=300,top=150,scrollbars=yes'); return false;"
                    NavigateUrl='<%# "~/AccountAdmin/AccountAttachmentsPopUp.aspx?AccountExpenseEntryId=" & DataBinder.Eval(Container.DataItem, "AccountExpenseEntryId") & "&AccountEmployeeExpenseSheetId=" & DataBinder.Eval(Container.DataItem, "AccountEmployeeExpenseSheetId").ToString() & "&AccountAttachmentTypeId=1"%>'>
                    <asp:Literal ID="Literal1" runat="server" Text="<%$ Resources:TimeLive.Resource, Attachment%> " />
                </asp:HyperLink>
                <asp:Label ID="AttchCount" runat ="server" Visible="false" CssClass ="circle" Text="i"></asp:Label>
                     
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="5%" />
            <ItemStyle HorizontalAlign="Center" />
        </asp:TemplateField>
        <asp:TemplateField ShowHeader="False" Visible="False">
            <ItemTemplate>
                <asp:Image ID="imgStatus" runat="server" Width="10px" ImageAlign="AbsMiddle" __designer:wfdid="w37"
                    Visible="False"></asp:Image><br />
                <asp:Panel Style="display: none" ID="P0" title="Description" runat="server" __designer:wfdid="w38"
                    CssClass="innerPopup">
                    <asp:Label ID="lblStatus" runat="server" Width="100%" __designer:wfdid="w39" Font-Size="X-Small"
                        ForeColor="White" align="left"></asp:Label><asp:TextBox ID="DS0" runat="server" Width="350px"
                            __designer:wfdid="w40" Font-Size="X-Small" TextMode="MultiLine" Height="100px"
                            Font-Bold="False" MaxLength="500" ReadOnly="True"></asp:TextBox><br />
                    <asp:Label ID="lblStatusNote" runat="server" Width="100%" __designer:wfdid="w41"
                        Font-Size="X-Small" ForeColor="White" align="left"></asp:Label>
                </asp:Panel>
                <ajaxToolkit:PopupControlExtender ID="PopupControlExtender1" runat="server" __designer:wfdid="w42"
                    OffsetX="-350" PopupControlID="P0" TargetControlID="imgStatus">
                </ajaxToolkit:PopupControlExtender>
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Center" Width="1%" />
        </asp:TemplateField>
    </Columns>
</x:GridView>
<br />
<asp:ObjectDataSource ID="dsAccountExpenseEntryObject" runat="server" DeleteMethod="DeleteAccountExpenseEntry"
    OldValuesParameterFormatString="original_{0}" SelectMethod="GetvueAccountExpenseEntryWithLastStausByEmployeeExpenseSheetId"
    TypeName="AccountExpenseEntryBLL">
    <DeleteParameters>
        <asp:Parameter Name="Original_AccountExpenseEntryId" Type="Int32" />
    </DeleteParameters>
    <SelectParameters>
        <asp:QueryStringParameter DbType="Guid" DefaultValue="" Name="AccountEmployeeExpenseSheetId"
            QueryStringField="AccountEmployeeExpenseSheetId" />
    </SelectParameters>
</asp:ObjectDataSource>
<asp:ObjectDataSource ID="dsAccountExpenseEntryFormObject" runat="server" InsertMethod="AddAccountExpenseEntry"
    OldValuesParameterFormatString="original_{0}" SelectMethod="GetAccountExpenseEntriesByAccountExpenseEntryId"
    TypeName="AccountExpenseEntryBLL" UpdateMethod="UpdateAccountExpenseEntry">
    <UpdateParameters>
        <asp:SessionParameter DefaultValue="64" Name="AccountId" SessionField="AccountId"
            Type="Int32" />
        <asp:Parameter Name="AccountExpenseEntryDate" Type="DateTime" />
        <asp:Parameter Name="Original_AccountExpenseEntryId" Type="Int32" />
        <asp:Parameter DefaultValue="" Name="AccountEmployeeId" Type="Int32" />
        <asp:Parameter Name="AccountClientId" Type="Int32" />
        <asp:Parameter Name="AccountProjectId" Type="Int32" />
        <asp:Parameter Name="AccountProjectTaskId" Type="Int32" />
        <asp:Parameter Name="AccountExpenseId" Type="Int32" />
        <asp:Parameter Name="Amount" Type="Double" />
        <asp:Parameter Name="ModifiedOn" Type="DateTime" />
        <asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" />
        <asp:Parameter Name="Description" Type="String" />
        <asp:Parameter Name="IsBillable" Type="Boolean" />
        <asp:Parameter Name="Reimburse" Type="Boolean" />
        <asp:Parameter Name="AccountCurrencyId" Type="Int32" />
        <asp:Parameter Name="Quantity" Type="Double" />
        <asp:Parameter Name="Rate" Type="Double" />
        <asp:Parameter Name="AmountBeforeTax" Type="Double" />
        <asp:Parameter Name="TaxAmount" Type="Double" />
        <asp:Parameter Name="AccountPaymentMethodId" Type="Int32" />
        <asp:Parameter Name="AccountTaxZoneId" Type="Int32" />
        <asp:Parameter Name="Rejected" Type="Boolean" />
        <asp:Parameter Name="Submitted" Type="Boolean" />
        <asp:Parameter Name="AccountEmployeeExpenseSheetId" DbType="Guid" />
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
    </UpdateParameters>
    <SelectParameters>
        <asp:ControlParameter ControlID="GridView1" Name="AccountExpenseEntryId" PropertyName="SelectedValue"
            Type="Int32" />
    </SelectParameters>
    <InsertParameters>
        <asp:SessionParameter DefaultValue="64" Name="AccountId" SessionField="AccountId"
            Type="Int32" />
        <asp:Parameter Name="AccountExpenseEntryDate" Type="DateTime" />
        <asp:Parameter DefaultValue="" Name="AccountEmployeeId" Type="Int32" />
        <asp:Parameter Name="AccountClientId" Type="Int32" />
        <asp:Parameter Name="AccountProjectId" Type="Int32" />
        <asp:Parameter Name="AccountProjectTaskId" Type="Int32" />
        <asp:Parameter Name="AccountExpenseId" Type="Int32" />
        <asp:Parameter Name="Amount" Type="Double" />
        <asp:Parameter Name="CreatedOn" Type="DateTime" />
        <asp:Parameter Name="CreatedByEmployeeId" Type="Int32" />
        <asp:Parameter Name="ModifiedOn" Type="DateTime" />
        <asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" />
        <asp:Parameter Name="Description" Type="String" />
        <asp:Parameter Name="IsBillable" Type="Boolean" />
        <asp:Parameter Name="Reimburse" Type="Boolean" />
        <asp:Parameter Name="AccountCurrencyId" Type="Int32" />
        <asp:Parameter Name="Quantity" Type="Double" />
        <asp:Parameter Name="Rate" Type="Double" />
        <asp:Parameter Name="AmountBeforeTax" Type="Double" />
        <asp:Parameter Name="TaxAmount" Type="Double" />
        <asp:Parameter Name="AccountPaymentMethodId" Type="Int32" />
        <asp:Parameter Name="ExchangeRate" Type="Double" />
        <asp:Parameter Name="AccountTaxZoneId" Type="Int32" />
        <asp:Parameter Name="Submitted" Type="Boolean" />
        <asp:Parameter Name="AccountEmployeeExpenseSheetId" DbType="Guid" />
        <asp:Parameter Name="Approved" Type="Boolean" />
        <asp:Parameter Name="Rejected" Type="Boolean" />
        <asp:Parameter Name="IsFromImportClass" Type="Boolean" />
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
<table style="width: 98%">
    <tr>
        <td align="right">
            <asp:Button ID="btnBackExpenseEntry0" runat="server" Text="Back" Width="100px" />
            <asp:Button ID="btnAddExpenseEntry" runat="server" Text="Add" Width="100px" />&nbsp;<asp:Button
                ID="btnPrint" runat="server" Text="<%$ Resources:TimeLive.Resource, Print %>"
                Width="100px" />
            <asp:Button ID="btnSubmit" runat="server" Width="100px"
                Text="<%$ Resources:TimeLive.Resource, Submit_text%> " ToolTip="<%$ Resources:TimeLive.Resource, Submit for Approval%> " />
        </td>
    </tr>
</table>
<asp:FormView ID="FormView1" runat="server" DataKeyNames="AccountExpenseEntryId"
    DataSourceID="dsAccountExpenseEntryFormObject" DefaultMode="Insert" SkinID="formviewSkinEmployee"
    Width="72.4%" OnDataBound="FormView1_DataBound" Visible="False">
    <EditItemTemplate>
        <table width="100%" class="xview">
            <tr>
                <th class="caption" colspan="2">
                    <asp:Literal ID="Literal1" runat="server" Text='<%# ResourceHelper.GetFromResource("Expense Entry Information") %>' />
                </th>
            </tr>
            <tr>
                <th class="FormViewSubHeader" colspan="2">
                    <asp:Literal ID="Literal3" runat="server" Text='<%# ResourceHelper.GetFromResource("Expense Entry") %>' />
                </th>
            </tr>
            <%  If LocaleUtilitiesBLL.ShowClientInExpenseSheet <> False Then%>
            <tr>
                <td align="right" class="formviewlabelcell" style="width: 30%">Client Name: </td>
                <td style="width: 70%">
                    <asp:DropDownList ID="ddlClientId" runat="server" DataSourceID="dsAccountClientObject"
                        DataTextField="PartyName" DataValueField="AccountPartyId" OnSelectedIndexChanged="ddlClientId_SelectedIndexChanged"
                        Width="450px">
                    </asp:DropDownList>
                    <asp:ObjectDataSource ID="dsAccountClientObject" runat="server" OldValuesParameterFormatString="original_{0}"
                        SelectMethod="GetAccountPartiesByAccountIdAndAccountPartyId" TypeName="AccountPartyBLL">
                        <SelectParameters>
                            <asp:SessionParameter DefaultValue="69" Name="AccountId" SessionField="AccountId"
                                Type="Int32" />
                            <asp:Parameter DefaultValue="0" Name="AccountPartyId" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </td>
            </tr>
            <%  End If%>
            <tr>
                <td align="right" class="formviewlabelcell" style="width: 30%">
                    <span class="reqasterisk">*</span><asp:Literal ID="Literal4" runat="server" Text='<%# ResourceHelper.GetFromResource("Project Name:") %>' />
                </td>
                <td style="width: 70%">
                    <asp:DropDownList ID="ddlAccountProjectId" runat="server" Width="450px" OnSelectedIndexChanged="ddlAccountProjectId_SelectedIndexChanged">
                    </asp:DropDownList>
                    <aspToolkit:CascadingDropDown ID="CascadingDropDown2" runat="server" LoadingText="Loading"
                        ParentControlID="ddlClientId" PromptText="Select Project" ServiceMethod="GetAccountProjectsByClient"
                        ServicePath="~/Services/ProjectService.asmx" TargetControlID="ddlAccountProjectId"
                        Category="Project" UseContextKey="true">
                    </aspToolkit:CascadingDropDown>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlAccountProjectId"
                        CssClass="ErrorMessage" Display="Dynamic" ErrorMessage="" ValidationGroup="NetAmount">
                    </asp:RequiredFieldValidator>&nbsp;
                    <asp:ObjectDataSource
                        ID="dsAccountProjectTasksObject" runat="server" OldValuesParameterFormatString="original_{0}"
                        TypeName="AccountProjectTaskBLL">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="" Name="AccountProjectId" Type="Int32" />
                            <asp:Parameter DefaultValue="" Name="AccountEmployeeId" Type="Int32" />
                            <asp:Parameter Name="AccountProjectTaskId" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </td>
            </tr>
            <%  If LocaleUtilitiesBLL.ShowTaskInExpenseSheet = True Then%><tr>
                <td align="right" class="formviewlabelcell" style="width: 30%">Task (Optional): </td>
                <td style="width: 70%">
                    <asp:DropDownList ID="ddlAccountProjectTaskId" runat="server" DataTextField="TaskName"
                        DataValueField="AccountProjectTaskId" Width="450px">
                    </asp:DropDownList>
                    <ajaxToolkit:CascadingDropDown ID="ddlAccountProjectTaskIdCascadingDropDown" runat="server"
                        Category="Tasks" LoadingText="Loading" ParentControlID="ddlAccountProjectId"
                        PromptText="<%$ Resources:TimeLive.Resource, Select Tasks%>" ServiceMethod="GetAccountProjectTasksInExpensesheet"
                        ServicePath="~/Services/ProjectService.asmx" TargetControlID="ddlAccountProjectTaskId">
                    </ajaxToolkit:CascadingDropDown>
                </td>
            </tr>
            <%  End If%>
            <tr>
                <td align="right" class="formviewlabelcell" style="width: 30%">
                    <span class="reqasterisk">*</span><asp:Literal ID="Literal5" runat="server" Text='<%# ResourceHelper.GetFromResource("Expense Name:") %>' />
                </td>
                <td style="width: 70%">
                    <asp:DropDownList ID="ddlExpenseNameEdit" runat="server" DataSourceID="dsAccountExpenseObject"
                        DataTextField="AccountExpenseName" DataValueField="AccountExpenseId" Width="450px"
                        AutoPostBack="True" OnSelectedIndexChanged="ddlExpenseName_SelectedIndexChanged1">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlExpenseNameEdit"
                        Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td align="right" class="formviewlabelcell" style="width: 30%" valign="top">
                    <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="DescriptionTextBox">
                        <asp:Literal ID="Literal6" runat="server" Text='<%# ResourceHelper.GetFromResource("Description:") %>' /></asp:Label></td>
                <td style="width: 70%">
                    <asp:TextBox ID="DescriptionTextBox" runat="server" Height="75px" Text='<%# Bind("Description") %>'
                        TextMode="MultiLine" Width="437px"></asp:TextBox></td>
            </tr>
            <tr>
                <td align="right" class="formviewlabelcell" style="width: 30%" valign="top">
                    <asp:Literal ID="Literal23" runat="server" Text='<%# ResourceHelper.GetFromResource("Expense Entry Date:") %>' />
                </td>
                <td style="width: 70%">
                    <ew:CalendarPopup ID="txtDate" runat="server" SkinID="DatePicker" Width="62px" SelectedDate='<%# Bind("AccountExpenseEntryDate") %>'>
                    </ew:CalendarPopup>
                </td>
            </tr>
            <tr>
                <td align="right" class="formviewlabelcell" style="width: 30%">
                    <asp:Literal ID="Literal7" runat="server" Text='<%# ResourceHelper.GetFromResource("Reimburse:") %>' />
                </td>
                <td style="width: 70%">
                    <asp:CheckBox ID="chkReimburse" runat="server" Checked='<%# Bind("Reimburse") %>'
                        AutoPostBack="True" OnCheckedChanged="chkReimburse_CheckedChanged" />
                    <asp:Label ID="Label29" runat="server" CssClass="fielddescription" Text='<%# ResourceHelper.GetFromResource("ReimburseDescription") %>' />
                </td>
            </tr>
            <tr>
                <td align="right" class="formviewlabelcell" style="width: 30%">
                    <asp:Literal ID="Literal11" runat="server" Text='<%# ResourceHelper.GetFromResource("Billable:") %>' />
                </td>
                <td style="width: 70%">
                    <asp:CheckBox ID="chkIsBillable" runat="server" />
                    <asp:Label ID="Label30" runat="server" CssClass="fielddescription" Text='<%# ResourceHelper.GetFromResource("BillableDescription") %>' />
                </td>
            </tr>
            <tr>
                <td align="right" class="formviewlabelcell" style="width: 30%">
                    <asp:Literal ID="Literal8" runat="server" Text='<%# ResourceHelper.GetFromResource("Payment Method:") %>' />
                </td>
                <td style="width: 70%">
                    <asp:DropDownList ID="ddlAccountPaymentMethodId" runat="server" AppendDataBoundItems="True"
                        DataSourceID="dsAccountPaymentMethodObject" DataTextField="PaymentMethod" DataValueField="AccountPaymentMethodId"
                        Width="113px">
                        <asp:ListItem Value="0" Label ID="Label1" runat="server" Text="<%$ Resources:TimeLive.Resource, None%> "></asp:ListItem>
                        <%--<asp:ListItem Value="0">&lt;None&gt;</asp:ListItem>--%>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td align="right" class="formviewlabelcell" style="width: 30%">
                    <asp:Literal ID="Literal9" runat="server" Text='<%# ResourceHelper.GetFromResource("Currency:") %>' />
                </td>
                <td style="width: 70%">
                    <asp:DropDownList ID="ddlAccountCurrencyId" runat="server" DataSourceID="dsAccountCurrencyObject"
                        DataTextField="CurrencyCode" DataValueField="AccountCurrencyId" Width="113px"
                        AutoPostBack="True" OnSelectedIndexChanged="ddlAccountCurrencyId_SelectedIndexChanged1">
                    </asp:DropDownList>
                </td>
            </tr>
            <% If CType(Me.FormView1.FindControl("lblQuantity"), Label).Visible <> False Then%>
            <tr>
                <td align="right" class="formviewlabelcell" style="width: 30%">
                    <asp:Label ID="lblQuantity" runat="server" Text="Quantity: "></asp:Label></td>
                <td style="width: 70%">
                    <asp:TextBox ID="QuantityTextBox" runat="server" AutoPostBack="True" OnTextChanged="QuantityTextBox_TextChanged1"
                        Text='<%# Bind("Quantity") %>' Width="100px" Style="text-align: right"></asp:TextBox></td>
            </tr>
            <tr>
                <td align="right" class="formviewlabelcell" style="width: 30%">
                    <asp:Label ID="lblRate" runat="server" Text='<%# ResourceHelper.GetFromResource("Rate:") %>'></asp:Label></td>
                <td style="width: 70%">
                    <asp:TextBox ID="RateTextBox" runat="server" AutoPostBack="True" OnTextChanged="RateTextBox_TextChanged1"
                        Text='<%# Bind("Rate") %>' Width="100px" Style="text-align: right"></asp:TextBox></td>
            </tr>
            <%End If%><% If CType(Me.FormView1.FindControl("lblNetAmount"), Label).Visible <> False Then%><tr>
                <td align="right" class="formviewlabelcell" style="width: 30%">
                    <asp:Label ID="lblNetAmount" runat="server" Text='<%# ResourceHelper.GetFromResource("Net Amount:") %>'></asp:Label></td>
                <td style="width: 70%">
                    <asp:TextBox ID="NetAmountTextBox" runat="server" AutoPostBack="True" OnTextChanged="NetAmountTextBox_TextChanged1"
                        Text='<%# Bind("AmountBeforeTax") %>' Width="100px" ValidationGroup="NetAmount"
                        Style="text-align: right"></asp:TextBox><asp:Label ID="lblNetAmountNR" runat="server"
                            ForeColor="Red" Text="Numeric Required" Visible="False"></asp:Label></td>
            </tr>
            <tr>
                <td align="right" class="formviewlabelcell" style="width: 30%">
                    <asp:Literal ID="Literal10" runat="server" Text='<%# ResourceHelper.GetFromResource("Tax Zone:") %>' />
                </td>
                <td style="width: 70%">
                    <asp:DropDownList ID="ddlAccountTaxZoneId" runat="server" DataSourceID="dsAccountTaxZoneObject"
                        DataTextField="AccountTaxZone" DataValueField="AccountTaxZoneId" Width="113px"
                        AutoPostBack="True" OnSelectedIndexChanged="ddlAccountTaxZoneId_SelectedIndexChanged1">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="right" class="formviewlabelcell" style="width: 30%">
                    <asp:Label ID="lblTax" runat="server" Text='<%# ResourceHelper.GetFromResource("Tax:") %>'></asp:Label></td>
                <td style="width: 70%">
                    <asp:TextBox ID="TaxAmountTextBox" runat="server" AutoPostBack="True" OnTextChanged="TaxAmountTextBox_TextChanged1"
                        Text='<%# Bind("TaxAmount") %>' Width="100px" Style="text-align: right"></asp:TextBox></td>
            </tr>
            <%End If%><tr>
                <td align="right" class="formviewlabelcell" style="width: 30%;">
                    <span class="reqasterisk">*</span><asp:Label ID="Label10" runat="server" AssociatedControlID="AmountTextBox">
                        <asp:Literal ID="Literal22" runat="server" Text='<%# ResourceHelper.GetFromResource("Amount:") %>' /></asp:Label></td>
                <td style="width: 70%;">
                    <asp:TextBox ID="AmountTextBox" runat="server" Text='<%# Bind("Amount") %>' Width="100px"
                        OnTextChanged="AmountTextBox_TextChanged" ValidationGroup="NetAmount" AutoPostBack="True"
                        Style="text-align: right"></asp:TextBox><asp:RequiredFieldValidator ID="RFVNetAmountEdit"
                            runat="server" ControlToValidate="AmountTextBox" CssClass="ErrorMessage" Display="Dynamic"
                            ErrorMessage="*" ValidationGroup="NetAmount"></asp:RequiredFieldValidator><asp:Label
                                ID="lblAmountNR" runat="server" ForeColor="Red" Text="Numeric Required" Visible="False"></asp:Label></td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Table ID="CustomTableEdit" runat="server" Style="margin-left: 0px" Width="100%">
                    </asp:Table>
                </td>
            </tr>
            <tr>
                <td align="right" class="formviewlabelcell" style="width: 30%"></td>
                <td style="width: 70%; padding-bottom: 5px;">
                    <asp:Button ID="Button1" runat="server" CommandName="Update" Text="<%$ Resources:TimeLive.Resource, Update_text%> "
                        Width="55px" OnClick="Button1_Click" ValidationGroup="NetAmount" />
                    &nbsp;<asp:Button ID="Button2" runat="server" Text="<%$ Resources:TimeLive.Resource, Cancel_text%> "
                        Width="55px" OnClick="Button2_Click" CommandName="Cancel" />
                </td>
            </tr>
        </table>
    </EditItemTemplate>
    <InsertItemTemplate>
        <table width="100%" class="xview">
            <tr>
                <th class="caption" colspan="2">
                    <asp:Literal ID="Literal10" runat="server" Text='<%# ResourceHelper.GetFromResource("Expense Entry Information") %>' />
                </th>
            </tr>
            <tr>
                <th class="FormViewSubHeader" colspan="2">
                    <asp:Literal ID="Literal12" runat="server" Text='<%# ResourceHelper.GetFromResource("Expense Entry") %>' />
                </th>
            </tr>
            <%  If LocaleUtilitiesBLL.ShowClientInExpenseSheet <> False Then%>
            <tr>
                <td align="right" class="formviewlabelcell" style="width: 30%">Client Name: </td>
                <td style="width: 70%">
                    <asp:DropDownList ID="ddlClientId" runat="server" DataSourceID="dsAccountClientObject"
                        DataTextField="PartyName" DataValueField="AccountPartyId" Width="450px" SelectedValue='<%# Bind("AccountClientId") %>'>
                    </asp:DropDownList>
                    <asp:ObjectDataSource ID="dsAccountClientObject" runat="server" OldValuesParameterFormatString="original_{0}"
                        SelectMethod="GetAccountPartiesByAccountIdAndAccountPartyId" TypeName="AccountPartyBLL">
                        <SelectParameters>
                            <asp:SessionParameter DefaultValue="69" Name="AccountId" SessionField="AccountId"
                                Type="Int32" />
                            <asp:Parameter DefaultValue="0" Name="AccountPartyId" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </td>
            </tr>
            <%  End If%>
            <tr>
                <td align="right" class="formviewlabelcell" style="width: 30%">
                    <span class="reqasterisk">*</span><asp:Literal ID="Literal13" runat="server" Text='<%# ResourceHelper.GetFromResource("Project Name:") %>' />
                </td>
                <td style="width: 70%">
                    <asp:DropDownList ID="ddlAccountProjectId" runat="server" Width="450px" OnSelectedIndexChanged="ddlAccountProjectId_SelectedIndexChanged">
                    </asp:DropDownList>
                    <aspToolkit:CascadingDropDown ID="CascadingDropDown2" runat="server" LoadingText="Loading"
                        ParentControlID="ddlClientId" PromptText="Select Project" ServiceMethod="GetAccountProjectsByClient"
                        ServicePath="~/Services/ProjectService.asmx" TargetControlID="ddlAccountProjectId"
                        Category="Project" UseContextKey="true">
                    </aspToolkit:CascadingDropDown>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlAccountProjectId"
                        Display="None" ErrorMessage="Entering a Project Name is Required" ValidationGroup="NetAmount"></asp:RequiredFieldValidator>&nbsp;
                    <asp:ValidationSummary runat="server" ShowMessageBox="true" ShowSummary="false" ValidationGroup="NetAmount" />
                    <asp:ObjectDataSource
                        ID="dsAccountProjectTasksObject" runat="server" OldValuesParameterFormatString="original_{0}"
                        TypeName="AccountProjectTaskBLL">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="" Name="AccountProjectId" Type="Int32" />
                            <asp:Parameter DefaultValue="" Name="AccountEmployeeId" Type="Int32" />
                            <asp:Parameter Name="AccountProjectTaskId" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </td>
            </tr>
            <%  If LocaleUtilitiesBLL.ShowTaskInExpenseSheet = True Then%>
            <tr>
                <td align="right" class="formviewlabelcell" style="width: 30%">Task (Optional): </td>
                <td style="width: 70%">
                    <asp:DropDownList ID="ddlAccountProjectTaskId" runat="server" Width="450px" DataTextField="TaskName"
                        DataValueField="AccountProjectTaskId">
                    </asp:DropDownList>
                    <ajaxToolkit:CascadingDropDown ID="ddlAccountProjectTaskIdCascadingDropDown" runat="server"
                        Category="Tasks" LoadingText="Loading" ParentControlID="ddlAccountProjectId"
                        PromptText="<%$ Resources:TimeLive.Resource, Select Tasks%>" ServiceMethod="GetAccountProjectTasksInExpensesheet"
                        ServicePath="~/Services/ProjectService.asmx" TargetControlID="ddlAccountProjectTaskId">
                    </ajaxToolkit:CascadingDropDown>
                </td>
            </tr>
            <%  End If%>
            <tr>
                <td align="right" class="formviewlabelcell" style="width: 30%">
                    <span class="reqasterisk">*</span><asp:Literal ID="Literal14" runat="server" Text='<%# ResourceHelper.GetFromResource("Expense Name:") %>' />
                </td>
                <td style="width: 70%">
                    <asp:DropDownList ID="ddlExpenseName" runat="server" DataSourceID="dsAccountExpenseObjectInsert"
                        DataTextField="AccountExpenseName" DataValueField="AccountExpenseId" SelectedValue='<%# Bind("AccountExpenseId") %>'
                        Width="450px" AutoPostBack="True" OnSelectedIndexChanged="ddlExpenseName_SelectedIndexChanged">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlExpenseName"
                        Display="Dynamic" ErrorMessage="*" CssClass="ErrorMessage" ValidationGroup="NetAmount"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td align="right" class="formviewlabelcell" style="width: 30%" valign="top">
                    <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="DescriptionTextBox">
                        <asp:Literal ID="Literal15" runat="server" Text='<%# ResourceHelper.GetFromResource("Description:") %>' /></asp:Label></td>
                <td style="width: 70%">
                    <asp:TextBox ID="DescriptionTextBox" runat="server" Height="75px" Text='<%# Bind("Description") %>'
                        TextMode="MultiLine" Width="437px"></asp:TextBox></td>
            </tr>
            <tr>
                <td align="right" class="formviewlabelcell" style="width: 30%" valign="top">
                    <asp:Literal ID="Literal1" runat="server" Text='<%# ResourceHelper.GetFromResource("Expense Entry Date:") %>' />
                </td>
                <td style="width: 70%">
                    <ew:CalendarPopup ID="txtDate" runat="server" SkinID="DatePicker" Width="62px">
                    </ew:CalendarPopup>
                </td>
            </tr>
            <tr>
                <td align="right" class="formviewlabelcell" style="width: 30%">
                    <asp:Literal ID="Literal16" runat="server" Text='<%# ResourceHelper.GetFromResource("Reimburse:") %>' />
                </td>
                <td style="width: 70%">
                    <asp:CheckBox ID="chkReimburse" runat="server" Checked='<%# Bind("Reimburse") %>'
                        OnPreRender="chkReimburse_PreRender" AutoPostBack="True" OnCheckedChanged="chkReimburse_CheckedChanged" />
                    <asp:Label ID="Label27" runat="server" CssClass="fielddescription" Text='<%# ResourceHelper.GetFromResource("ReimburseDescription") %>' />
                </td>
            </tr>
            <tr>
                <td align="right" class="formviewlabelcell" style="width: 30%; height: 22px;">
                    <asp:Literal ID="Literal21" runat="server" Text='<%# ResourceHelper.GetFromResource("Billable:") %>' />
                </td>
                <td style="width: 70%; height: 22px;">
                    <asp:CheckBox ID="chkIsBillable" runat="server" Checked='<%# Bind("IsBillable") %>' />
                    <asp:Label ID="Label28" runat="server" CssClass="fielddescription" Text='<%# ResourceHelper.GetFromResource("BillableDescription") %>' />
                </td>
            </tr>
            <tr>
                <td align="right" class="formviewlabelcell" style="width: 30%">
                    <asp:Literal ID="Literal17" runat="server" Text='<%# ResourceHelper.GetFromResource("Payment Method:") %>' />
                </td>
                <td style="width: 70%">
                    <asp:DropDownList ID="ddlAccountPaymentMethodId" runat="server" AppendDataBoundItems="True"
                        DataSourceID="dsAccountPaymentMethodObjectInsert" DataTextField="PaymentMethod"
                        DataValueField="AccountPaymentMethodId" SelectedValue='<%# Bind("AccountPaymentMethodId") %>'
                        Width="113px">
                        <asp:ListItem Value="0" Label ID="Label2" runat="server" Text="<%$ Resources:TimeLive.Resource, None%> "></asp:ListItem>
                        <%--<asp:ListItem Value="0">&lt;None&gt;</asp:ListItem>--%>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td align="right" class="formviewlabelcell" style="width: 30%">
                    <asp:Literal ID="Literal18" runat="server" Text='<%# ResourceHelper.GetFromResource("Currency:") %>' />
                </td>
                <td style="width: 70%">
                    <asp:DropDownList ID="ddlAccountCurrencyId" runat="server" DataSourceID="dsAccountCurrencyObjectInsert"
                        DataTextField="CurrencyCode" DataValueField="AccountCurrencyId" SelectedValue='<%# Bind("AccountCurrencyId") %>'
                        Width="113px" AutoPostBack="True" OnSelectedIndexChanged="ddlAccountCurrencyId_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
            </tr>
            <% If CType(Me.FormView1.FindControl("lblQuantity"), Label).Visible <> False Then%>
            <tr>
                <td align="right" class="formviewlabelcell" style="width: 30%; height: 26px;">
                    <span class="reqasterisk">*</span><asp:Label ID="lblQuantity" runat="server" Text='<%# ResourceHelper.GetFromResource("Quantity:") %>'></asp:Label></td>
                <td style="width: 70%; height: 26px;">
                    <asp:TextBox ID="QuantityTextBox" runat="server" AutoPostBack="True" OnTextChanged="QuantityTextBox_TextChanged"
                        Text='<%# Bind("Quantity") %>' Width="100px" CausesValidation="True" Style="text-align: right"></asp:TextBox></td>
            </tr>
            <tr>
                <td align="right" class="formviewlabelcell" style="width: 30%; height: 26px;">
                    <asp:Label ID="lblRate" runat="server" Text='<%# ResourceHelper.GetFromResource("Rate:") %>'></asp:Label></td>
                <td style="width: 70%; height: 26px;">
                    <asp:TextBox ID="RateTextBox" runat="server" AutoPostBack="True" OnTextChanged="RateTextBox_TextChanged"
                        Text='<%# Bind("Rate") %>' Width="100px" Style="text-align: right"></asp:TextBox></td>
            </tr>
            <% End If%><% If CType(Me.FormView1.FindControl("lblNetAmount"), Label).Visible <> False Then%><tr>
                <td align="right" class="formviewlabelcell" style="width: 30%; height: 26px;">
                    <asp:Label ID="lblNetAmount" runat="server" Text='<%# ResourceHelper.GetFromResource("Net Amount:") %>'></asp:Label>&nbsp; </td>
                <td style="width: 70%; height: 26px;">
                    <asp:TextBox ID="NetAmountTextBox" runat="server" AutoPostBack="True" OnTextChanged="NetAmountTextBox_TextChanged"
                        Text='<%# Bind("AmountBeforeTax") %>' Width="100px" CausesValidation="True" ValidationGroup="NetAmount"
                        Style="text-align: right"></asp:TextBox>&nbsp;<asp:Label ID="lblNetAmountNR" runat="server"
                            ForeColor="Red" Text="Numeric Required" Visible="False"></asp:Label></td>
            </tr>
            <tr>
                <td align="right" class="formviewlabelcell" style="width: 30%; height: 24px;">
                    <asp:Literal ID="Literal19" runat="server" Text='<%# ResourceHelper.GetFromResource("Tax Zone:") %>' />
                </td>
                <td style="width: 70%; height: 24px;">
                    <asp:DropDownList ID="ddlAccountTaxZoneId" runat="server" DataSourceID="dsAccountTaxZoneObjectInsert"
                        DataTextField="AccountTaxZone" DataValueField="AccountTaxZoneId" Width="113px"
                        AutoPostBack="True" OnSelectedIndexChanged="ddlAccountTaxZoneId_SelectedIndexChanged"
                        SelectedValue='<%# Bind("AccountTaxZoneId") %>'>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="right" class="formviewlabelcell" style="width: 30%; height: 26px;">
                    <asp:Label ID="lblTax" runat="server" Text='<%# ResourceHelper.GetFromResource("Tax:") %>'></asp:Label></td>
                <td style="width: 70%; height: 26px;">
                    <asp:TextBox ID="TaxAmountTextBox" runat="server" AutoPostBack="True" OnTextChanged="TaxAmountTextBox_TextChanged"
                        Text='<%# Bind("TaxAmount") %>' Width="100px" CausesValidation="True" Style="text-align: right"></asp:TextBox></td>
            </tr>
            <%End If%><tr>
                <td align="right" class="formviewlabelcell" style="width: 30%; height: 26px;">
                    <%-- <span  class="reqasterisk" runat="server">*</span> Asterisk alteration here--%>
                    <asp:Label ID="HideAst" runat="server" CssClass="reqasterisk">*</asp:Label>
                    <asp:Label ID="Label9" runat="server" AssociatedControlID="AmountTextBox">
                        <asp:Literal ID="Literal20" runat="server" Text='<%# ResourceHelper.GetFromResource("Amount:") %>' /></asp:Label></td>
                <td style="width: 70%; height: 24px;">
                    <asp:TextBox ID="AmountTextBox" runat="server" Text='<%# Bind("Amount") %>' Width="100px"
                        CausesValidation="True" ValidationGroup="NetAmount" AutoPostBack="True" OnTextChanged="AmountTextBox_TextChanged2"
                        Style="text-align: right"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="AmountTextBox" Visible="true" ErrorMessage="*" CssClass="ErrorMessage">
                        </asp:RequiredFieldValidator><asp:Label ID="lblAmountNR"
                            runat="server" ForeColor="Red" Text="Numeric Required" Visible="False"></asp:Label></td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Table ID="CustomTable" runat="server" Height="100%" Width="100%">
                    </asp:Table>
                </td>
            </tr>
            <tr>
                <td align="right" class="formviewlabelcell" style="width: 30%"></td>
                <td style="width: 70%; padding-bottom: 5px;">
                    <asp:Button ID="btnAdd" runat="server" CommandName="Insert" Text="<%$ Resources:TimeLive.Resource, Add_text%> "
                        Width="62px" ValidationGroup="NetAmount" OnClick="btnAdd_Click" />&nbsp;
                    <asp:Button ID="btnAddCopy" runat="server" Text="Add & Copy"
                        Width="62px" ValidationGroup="NetAmount" OnClick="btnAddCopy_Click"  />&nbsp;
                    <asp:Button
                            ID="btnCancel" runat="server" CommandName="Cancel" OnClick="btnCancel_Click"
                            Text="<%$ Resources:TimeLive.Resource, Cancel%>" Width="62px" />
                </td>
            </tr>
        </table>
    </InsertItemTemplate>
    <ItemTemplate>
        AccountExpenseEntryId:
        <asp:Label ID="AccountExpenseEntryIdLabel" runat="server" Text='<%# Eval("AccountExpenseEntryId") %>'>
        </asp:Label><br />
        AccountExpenseEntryDate:
        <asp:Label ID="AccountExpenseEntryDateLabel" runat="server" Text='<%# Bind("AccountExpenseEntryDate") %>'>
        </asp:Label><br />
        AccountId:
        <asp:Label ID="AccountIdLabel" runat="server" Text='<%# Bind("AccountId") %>'></asp:Label><br />
        AccountEmployeeId:
        <asp:Label ID="AccountEmployeeIdLabel" runat="server" Text='<%# Bind("AccountEmployeeId") %>'>
        </asp:Label><br />
        AccountProjectId:
        <asp:Label ID="AccountProjectIdLabel" runat="server" Text='<%# Bind("AccountProjectId") %>'>
        </asp:Label><br />
        AccountExpenseId:
        <asp:Label ID="AccountExpenseIdLabel" runat="server" Text='<%# Bind("AccountExpenseId") %>'>
        </asp:Label><br />
        Amount:
        <asp:Label ID="AmountLabel" runat="server" Text='<%# Bind("Amount") %>'></asp:Label><br />
        CreatedOn:
        <asp:Label ID="CreatedOnLabel" runat="server" Text='<%# Bind("CreatedOn") %>'></asp:Label><br />
        CreatedByEmployeeId:
        <asp:Label ID="CreatedByEmployeeIdLabel" runat="server" Text='<%# Bind("CreatedByEmployeeId") %>'>
        </asp:Label><br />
        ModifiedOn:
        <asp:Label ID="ModifiedOnLabel" runat="server" Text='<%# Bind("ModifiedOn") %>'>
        </asp:Label><br />
        ModifiedByEmployeeId:
        <asp:Label ID="ModifiedByEmployeeIdLabel" runat="server" Text='<%# Bind("ModifiedByEmployeeId") %>'>
        </asp:Label><br />
        <asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" CommandName="Edit"
            Text="Edit">
        </asp:LinkButton><asp:LinkButton ID="DeleteButton" runat="server" CausesValidation="False"
            CommandName="Delete" Text="Delete">
        </asp:LinkButton><asp:LinkButton ID="NewButton" runat="server" CausesValidation="False"
            CommandName="New" Text="New">
        </asp:LinkButton>
    </ItemTemplate>
</asp:FormView>
<asp:ObjectDataSource ID="dsAccountExpenseObject" runat="server" OldValuesParameterFormatString="original_{0}"
    SelectMethod="GetAccountExpensesByAccountIdAndIsDisabled" TypeName="AccountExpenseBLL">
    <SelectParameters>
        <asp:SessionParameter DefaultValue="64" Name="AccountId" SessionField="AccountId"
            Type="Int32" />
        <asp:Parameter Name="AccountExpenseId" Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>
<asp:ObjectDataSource ID="dsAccountExpenseObjectInsert" runat="server" OldValuesParameterFormatString="original_{0}"
    SelectMethod="GetAccountExpensesByAccountIdAndIsDisabled" TypeName="AccountExpenseBLL"
    DeleteMethod="DeleteAccountExpense" InsertMethod="AddAccountExpense" UpdateMethod="UpdateAccountExpense">
    <SelectParameters>
        <asp:SessionParameter DefaultValue="64" Name="AccountId" SessionField="AccountId"
            Type="Int32" />
        <asp:Parameter Name="AccountExpenseId" Type="Int32" DefaultValue="0" />
    </SelectParameters>
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
<asp:ObjectDataSource ID="dsAccountProjectObject" runat="server" OldValuesParameterFormatString="original_{0}"
    SelectMethod="GetAssignedAccountProjectsByAccountEmployeeIdAndAccountProjectId"
    TypeName="AccountProjectBLL">
    <SelectParameters>
        <asp:Parameter DefaultValue="0" Name="AccountProjectId" Type="Int32" />
        <asp:ControlParameter ControlID="ddlEmployeeName" DefaultValue="" Name="AccountEmployeeId"
            PropertyName="SelectedValue" Type="Int32" />
        <asp:Parameter Name="IsTemplate" Type="Boolean" />
    </SelectParameters>
</asp:ObjectDataSource>
<asp:ObjectDataSource ID="dsAccountProjectObjectInsert" runat="server" OldValuesParameterFormatString="original_{0}"
    SelectMethod="GetAssignedAccountProjectsByAccountEmployeeIdAndAccountProjectIdForIsDeleted"
    TypeName="AccountProjectBLL" DeleteMethod="DeleteAccountProject" InsertMethod="AddAccountProject"
    UpdateMethod="UpdateProjectDescription">
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
        <asp:Parameter DefaultValue="67" Name="AccountEmployeeId" Type="Int32" />
        <asp:QueryStringParameter DefaultValue="" Name="IsTemplate" QueryStringField="IsTemplate"
            Type="Boolean" />
    </SelectParameters>
    <UpdateParameters>
        <asp:Parameter Name="ProjectDescription" Type="String" />
        <asp:Parameter Name="Original_AccountProjectId" Type="Int32" />
    </UpdateParameters>
</asp:ObjectDataSource>
<asp:ObjectDataSource ID="dsAccountCurrencyObject" runat="server" DeleteMethod="DeleteAccountCurrency"
    InsertMethod="AddAccountCurrency" OldValuesParameterFormatString="original_{0}"
    SelectMethod="GetvueAccountCurrencyByAccountIdAndDisabled" TypeName="AccountCurrencyBLL"
    UpdateMethod="UpdateAccountCurrency">
    <DeleteParameters>
        <asp:Parameter Name="Original_AccountCurrencyId" Type="Int32" />
    </DeleteParameters>
    <UpdateParameters>
        <asp:Parameter Name="SystemCurrencyId" Type="Int32" />
        <asp:Parameter Name="Original_AccountCurrencyId" Type="Int32" />
        <asp:Parameter Name="AccountCurrencyExchangeRateId" Type="Int32" />
        <asp:Parameter Name="AccountId" Type="Int32" />
        <asp:Parameter Name="Disabled" Type="Boolean" />
    </UpdateParameters>
    <SelectParameters>
        <asp:SessionParameter DefaultValue="151" Name="AccountId" SessionField="AccountId"
            Type="Int32" />
        <asp:Parameter Name="AccountCurrencyId" Type="Int32" />
    </SelectParameters>
    <InsertParameters>
        <asp:Parameter Name="SystemCurrencyId" Type="Int32" />
        <asp:Parameter Name="AccountId" Type="Int32" />
        <asp:Parameter Name="AccountCurrencyExchangeRateId" Type="Int32" />
        <asp:Parameter Name="Disabled" Type="Boolean" />
    </InsertParameters>
</asp:ObjectDataSource>
<asp:ObjectDataSource ID="dsAccountCurrencyObjectInsert" runat="server" DeleteMethod="DeleteAccountCurrency"
    InsertMethod="AddAccountCurrency" OldValuesParameterFormatString="original_{0}"
    SelectMethod="GetvueAccountCurrencyByAccountIdAndDisabled" TypeName="AccountCurrencyBLL"
    UpdateMethod="UpdateAccountCurrency">
    <DeleteParameters>
        <asp:Parameter Name="Original_AccountCurrencyId" Type="Int32" />
    </DeleteParameters>
    <UpdateParameters>
        <asp:Parameter Name="SystemCurrencyId" Type="Int32" />
        <asp:Parameter Name="Original_AccountCurrencyId" Type="Int32" />
        <asp:Parameter Name="AccountCurrencyExchangeRateId" Type="Int32" />
        <asp:Parameter Name="AccountId" Type="Int32" />
        <asp:Parameter Name="Disabled" Type="Boolean" />
    </UpdateParameters>
    <SelectParameters>
        <asp:SessionParameter DefaultValue="151" Name="AccountId" SessionField="AccountId"
            Type="Int32" />
        <asp:Parameter DefaultValue="0" Name="AccountCurrencyId" Type="Int32" />
    </SelectParameters>
    <InsertParameters>
        <asp:Parameter Name="SystemCurrencyId" Type="Int32" />
        <asp:Parameter Name="AccountId" Type="Int32" />
        <asp:Parameter Name="AccountCurrencyExchangeRateId" Type="Int32" />
        <asp:Parameter Name="Disabled" Type="Boolean" />
    </InsertParameters>
</asp:ObjectDataSource>
<asp:ObjectDataSource ID="dsAccountPaymentMethodObject" runat="server" OldValuesParameterFormatString="original_{0}"
    SelectMethod="GetAccountPaymentMethodByAccountIdAndIsDisabled" TypeName="AccountPaymentMethodBLL">
    <SelectParameters>
        <asp:SessionParameter DefaultValue="151" Name="AccountId" SessionField="AccountId"
            Type="Int32" />
        <asp:Parameter Name="AccountPaymentMethodId" Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>
<asp:ObjectDataSource ID="dsAccountPaymentMethodObjectInsert" runat="server" OldValuesParameterFormatString="original_{0}"
    SelectMethod="GetAccountPaymentMethodByAccountIdAndIsDisabled" TypeName="AccountPaymentMethodBLL">
    <SelectParameters>
        <asp:SessionParameter DefaultValue="151" Name="AccountId" SessionField="AccountId"
            Type="Int32" />
        <asp:Parameter DefaultValue="0" Name="AccountPaymentMethodId" Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>
<asp:ObjectDataSource ID="dsAccountTaxZoneObject" runat="server" OldValuesParameterFormatString="original_{0}"
    SelectMethod="GetAccountTaxZonesByAccountIdAndIsDisabled" TypeName="AccountTaxZoneBLL">
    <SelectParameters>
        <asp:SessionParameter DefaultValue="3" Name="AccountId" SessionField="AccountId"
            Type="Int32" />
        <asp:Parameter Name="AccountTaxZoneId" Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>
<asp:ObjectDataSource ID="dsAccountTaxZoneObjectInsert" runat="server" OldValuesParameterFormatString="original_{0}"
    SelectMethod="GetAccountTaxZonesByAccountIdAndIsDisabled" TypeName="AccountTaxZoneBLL">
    <SelectParameters>
        <asp:SessionParameter DefaultValue="3" Name="AccountId" SessionField="AccountId"
            Type="Int32" />
        <asp:Parameter DefaultValue="0" Name="AccountTaxZoneId" Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>
<uc1:ctlStatusLegend ID="CtlStatusLegend1" runat="server" />
<uc2:ctlAccountEmployeeExpenseSheetApprovalDetailReadOnly ID="CW2" runat="server" />
