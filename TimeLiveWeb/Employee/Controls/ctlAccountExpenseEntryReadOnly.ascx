<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlAccountExpenseEntryReadOnly.ascx.vb"
    Inherits="Employee_Controls_ctlAccountExpenseEntryReadOnly" %>
<asp:Image ID="imgCompanyLogo" Style="margin-left: 15px; padding-top: 15px; padding-bottom: 15px"
    runat="server" Height="50px" />
<div align="left">
&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp<asp:CheckBox ID="showAllchkbox" runat="server" AutoPostBack="True" Text="<%$ Resources:TimeLive.Resource, Show All%> " Font-Bold="True" /></td>
<br /><br />
</div>
<div class="fieldset" style="width: 50%; margin-left: 6px;" align="left">
    <table width="100%">
        <%--  <tr>
        <td colspan="4" valign="middle">
            </td>
    </tr>--%>
        <tr>
            <td align="left" class="HighlightedTextMedium" valign="middle" style="width: 20%;
                height: 22px;">
                <asp:Label ID="Label8" runat="server" Font-Bold="True" Font-Size="11px">
                    <asp:Literal ID="Literal3" runat="server" Text="<%$ Resources:TimeLive.Resource, Employee Name:%> " /></asp:Label>
            </td>
            <td valign="middle" class="HighlightedTextMedium" align="left" style="width: 30%;
                height: 22px;">
                <asp:Label ID="lblEmployeeName" runat="server"></asp:Label>
            </td>
            <td align="right" class="HighlightedTextMedium" style="width: 40%; height: 22px;"
                valign="middle">
                <asp:Label ID="Label11" runat="server" Font-Bold="True" Font-Size="11px" Width="150px">
                    <asp:Literal ID="RCurrencyLiteral" runat="server" Text="<%$ Resources:TimeLive.Resource, Reimbursement Currency:%> " /></asp:Label>
            </td>
            <td align="left" class="HighlightedTextMedium" style="width: 10%; height: 22px" valign="middle">
                &nbsp;<asp:Label ID="lblReimbursCurrency" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" class="HighlightedTextMedium" valign="middle" style="width: 20%;
                height: 22px">
                <asp:Label ID="Label14" runat="server" Font-Bold="True" Font-Size="11px">
                    <asp:Literal ID="Literal2" runat="server" Text="<%$ Resources:TimeLive.Resource, Description: %> " /></asp:Label>
            </td>
            <td align="left" class="HighlightedTextMedium" valign="middle" style="width: 30%;
                height: 22px">
                <asp:Label ID="lblDescription" runat="server"></asp:Label>
            </td>
            <td align="right" class="HighlightedTextMedium" style="width: 40%; height: 22px"
                valign="middle">
                <asp:Label ID="Label9" runat="server" Font-Bold="True" Font-Size="11px" Width="150px">
                    <asp:Literal ID="RTotalLiteral" runat="server" Text="<%$ Resources:TimeLive.Resource, Total Reimbursement%> "></asp:Literal></asp:Label>
            </td>
            <td align="left" class="HighlightedTextMedium" style="width: 10%; height: 22px" valign="middle">
                &nbsp;<asp:Label ID="lblReimburseAmount" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" class="HighlightedTextMedium" valign="middle" style="width: 20%;
                height: 22px">
                <asp:Label ID="Label12" runat="server" Font-Bold="True" Font-Size="11px">
                    <asp:Literal ID="Literal1" runat="server" Text="<%$ Resources:TimeLive.Resource, Date:%> "></asp:Literal></asp:Label>
            </td>
            <td align="left" class="HighlightedTextMedium" valign="middle" style="width: 30%;
                height: 22px">
                <asp:Label ID="lblDate" runat="server"></asp:Label>
            </td>
            <td align="right" class="HighlightedTextMedium" style="width: 40%; height: 22px"
                valign="middle">
            </td>
            <td align="left" class="HighlightedTextMedium" style="width: 10%; height: 22px" valign="middle">
            </td>
        </tr>
    </table>
    <asp:Table ID="CustomTable" runat="server" Width="98%" CellPadding="0" CellSpacing="0">
    </asp:Table>
</div>
<x:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False"
    Caption='<%# ResourceHelper.GetFromResource("Expense Entry List") %>' DataKeyNames="AccountExpenseEntryId"
    DataSourceID="dsAccountExpenseEntryObject" ShowFooter="True" SkinID="xgridviewSkinEmployee"
    Width="98%" PageSize="500">
    <Columns>
        <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Date %>">
            <EditItemTemplate>
                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("AccountExpenseEntryDate") %>'
                    __designer:wfdid="w69"></asp:TextBox></EditItemTemplate>
            <HeaderTemplate>
                <asp:LinkButton ID="LinkButton4" runat="server" Text='<%# ResourceHelper.GetFromResource("Date") %>'
                    CommandArgument="AccountExpenseEntryDate" CommandName="Sort" CausesValidation="False"></asp:LinkButton></HeaderTemplate>
            <ItemTemplate>
                <asp:Label ID="Label3" runat="server" Text='<%# Bind("AccountExpenseEntryDate", "{0:d}") %>'
                    __designer:wfdid="w68"></asp:Label></ItemTemplate>
            <ItemStyle Font-Bold="True" HorizontalAlign="Center" Width="7%" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Project Name %>">
            <EditItemTemplate>
                <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("ProjectName") %>' __designer:wfdid="w72"></asp:TextBox></EditItemTemplate>
            <HeaderTemplate>
                <asp:LinkButton ID="LinkButton5" runat="server" Text='<%# ResourceHelper.GetFromResource("Project Name") %>'
                    CommandArgument="ProjectName" CommandName="Sort" CausesValidation="False"></asp:LinkButton></HeaderTemplate>
            <ItemTemplate>
                <asp:Label ID="Label4" runat="server" Text='<%# Bind("ProjectName") %>' __designer:wfdid="w71"></asp:Label></ItemTemplate>
            <ItemStyle Font-Bold="True" HorizontalAlign="Left" Width="14%" />
        </asp:TemplateField>
        <asp:BoundField DataField="TaskName" HeaderText="Task Name">
            <ItemStyle Width="9%" />
        </asp:BoundField>
        <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Expense Name %>">
            <EditItemTemplate>
                <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("AccountExpenseName") %>'
                    __designer:wfdid="w18"></asp:TextBox></EditItemTemplate>
            <HeaderTemplate>
                <asp:LinkButton ID="LinkButton6" runat="server" Text='<%# ResourceHelper.GetFromResource("Expense Name") %>'
                    __designer:wfdid="w19" CausesValidation="False" CommandName="Sort" CommandArgument="AccountExpenseName"></asp:LinkButton></HeaderTemplate>
            <ItemTemplate>
                <asp:Label ID="Label5" runat="server" Text='<%# Bind("AccountExpenseName") %>' __designer:wfdid="w17"></asp:Label></ItemTemplate>
            <ItemStyle Font-Bold="True" HorizontalAlign="Left" Width="13%" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Description %>">
            <EditItemTemplate>
                <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("Description") %>' __designer:wfdid="w45"></asp:TextBox></EditItemTemplate>
            <HeaderTemplate>
                <asp:LinkButton ID="LinkButton7" runat="server" Text='<%# ResourceHelper.GetFromResource("Description") %>'
                    __designer:wfdid="w46" CausesValidation="False" CommandName="Sort" CommandArgument="Description"></asp:LinkButton></HeaderTemplate>
            <ItemTemplate>
                <asp:Label ID="Label6" runat="server" Text='<%# Bind("Description") %>' __designer:wfdid="w44"></asp:Label></ItemTemplate>
            <ItemStyle Font-Bold="True" HorizontalAlign="Left" Width="14%" />
        </asp:TemplateField>
        <%--<asp:TemplateField HeaderText="Payment Method">
            <edititemtemplate>
<asp:TextBox id="TextBox8" runat="server" Text='<%# Bind("PaymentMethod") %>' __designer:wfdid="w38"></asp:TextBox></edititemtemplate><itemtemplate>
<asp:Label id="Label11" runat="server" Text='<%# Bind("PaymentMethod") %>' __designer:wfdid="w37"></asp:Label></itemtemplate><itemstyle font-bold="True" horizontalalign="Left" width="5%" />
        </asp:TemplateField>--%>
        <asp:TemplateField HeaderText="Billable">
            <EditItemTemplate>
                <asp:TextBox ID="txtIsBillable" runat="server" Text='<%# Bind("IsBillable") %>' __designer:wfdid="w38"></asp:TextBox></EditItemTemplate>
            <ItemTemplate>
                <%#IIf(Eval("IsBillable").ToString() = "", "", IIf(Eval("IsBillable").ToString() = "1", "Yes", "No"))%></ItemTemplate>
            <ItemStyle Font-Bold="True" HorizontalAlign="Left" Width="5%" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Reimburse">
            <EditItemTemplate>
                <asp:TextBox ID="txtReimburse" runat="server" Text='<%# Bind("Reimburse") %>' __designer:wfdid="w38"></asp:TextBox></EditItemTemplate>
            <ItemTemplate>
                <%#IIf(Eval("Reimburse").ToString() = "", "", IIf(Eval("Reimburse").ToString() = "1", "Yes", "No"))%></ItemTemplate>
            <ItemStyle Font-Bold="True" HorizontalAlign="Left" Width="5%" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Quantity">
            <EditItemTemplate>
                <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("Quantity") %>' __designer:wfdid="w36"></asp:TextBox></EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="Label7" runat="server" Text='<%# Bind("QuantityFieldCaption") %>'
                    __designer:wfdid="w34"></asp:Label><asp:Label ID="Label10" runat="server" Text='<%# Bind("Quantity") %>'
                        __designer:wfdid="w35"></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Right" Width="8%" />
        </asp:TemplateField>
        <asp:BoundField DataField="Rate" HeaderText="Rate">
            <ItemStyle HorizontalAlign="Right" Width="5%" />
        </asp:BoundField>
        <asp:TemplateField HeaderText="Net Amount">
            <ItemTemplate>
                <asp:Label ID="lblNetAmount" runat="server" Text='<%# Bind("NetAmount", "{0:N}") %>'
                    __designer:wfdid="w41"></asp:Label>
                <asp:Label ID="lblNetAmountCurrency" runat="server" Text='<%# Eval("CurrencyCode") %>'
                    __designer:wfdid="w40"></asp:Label>
            </ItemTemplate>
            <FooterStyle Font-Bold="True" />
            <ItemStyle HorizontalAlign="Right" Width="5%" />
        </asp:TemplateField>
        <%--<asp:BoundField DataField="TaxCode" HeaderText="Tax Code">
            <ItemStyle HorizontalAlign="Right" Width="5%" />
        </asp:BoundField>
        <asp:BoundField DataField="TaxAmount" HeaderText="Tax Amount" DataFormatString="{0:N}">
            <FooterStyle Font-Bold="True" />
            <ItemStyle HorizontalAlign="Right" Width="4%" />
        </asp:BoundField>--%>
        <asp:TemplateField>
            <%-- HeaderText="<%$ Resources:TimeLive.Resource, Net Amount %>" --%>
            <HeaderTemplate>
                <asp:LinkButton ID="lbtnHeaderAmount" runat="server" Text='<%# ResourceHelper.GetFromResource("Amount") %>'
                    __designer:wfdid="w43" CausesValidation="False" CommandName="Sort" CommandArgument="Amount"></asp:LinkButton>
            </HeaderTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Amount") %>' __designer:wfdid="w42"></asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
                <%--<asp:Label ID="Label2" runat="server" Text='<%# Eval("CurrencyCode") %>' __designer:wfdid="w40"></asp:Label>
                <asp:Label ID="Label1" runat="server" Text='<%# Bind("Amount", "{0:N}") %>' __designer:wfdid="w41"></asp:Label>--%>
                <asp:Label ID="lblConvertedAmount" runat="server" __designer:wfdid="w41"></asp:Label>
                <asp:Label ID="lblConvertedCurrencyCode" runat="server" __designer:wfdid="w40"></asp:Label>
            </ItemTemplate>
            <FooterStyle Font-Bold="True" />
            <ItemStyle HorizontalAlign="Right" Width="9%" Font-Bold="False" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Payment Status">
            <ItemTemplate>
                <asp:Label ID="PaymentStatuslbl" runat="server" Text='<%# Bind("PaymentStatusState") %>'
                    __designer:wfdid="w41"></asp:Label>
            </ItemTemplate>
            <FooterStyle Font-Bold="True" />
            <ItemStyle HorizontalAlign="Right" Width="5%" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Attachments %>">
            <ItemTemplate>
                <asp:HyperLink ID="AttachmentHyperLink" onclick="window.open (this.href, 'popupwindow', 'width=680,height=250,left=300,top=300'); return false;"
                    runat="server" __designer:wfdid="w39"
                    NavigateUrl='<%# Eval("AccountExpenseEntryId", "~/ProjectAdmin/AccountExpenseEntryApprovalAttachment.aspx?AccountExpenseEntryId={0}&AccountAttachmentTypeId=1") %>'>[AttachmentHyperLink]</asp:HyperLink>
                <div class="tooltip_templates">
                    <asp:Label ID="tooltipContent" runat="server">
                        <asp:Image ID="imgTooltip" runat="server" CssClass="imgTooltip" />
                    </asp:Label>
                </div>
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Center" />
        </asp:TemplateField>
    </Columns>
</x:GridView>
<asp:TextBox ID="txtExpenseSheetFooter" Style="overflow: hidden; margin-left: 6px;
    padding-top: 15px; vertical-align: bottom" runat="server" BorderStyle="None"
    BorderWidth="0px" Height="125px" ReadOnly="True" TextMode="MultiLine" Width="97%"
    Font-Bold="True"></asp:TextBox>
<br />
<br />
<br />
<%If LocaleUtilitiesBLL.IsShowElectronicSign = True And LocaleUtilitiesBLL.IsElectronicSignExistInSessionAccount = True Then%>
<asp:Table ID="Table1" runat="server" Style="margin-left: 6px" Width="100%" Height="100%"
    BorderStyle="None" align="center" BorderColor="White" CssClass="xTableWithoutBorder">
    <asp:TableRow ID="TableRow1" runat="server" Width="100%" BorderStyle="None" BorderColor="White">
        <asp:TableCell ID="TableCell1" runat="server"><tr><td Class="caption" style="Width:100%; padding-top: 15px; padding-bottom: 15px;" colspan="2"><b>Electronic Signature</b></td>
        </tr></asp:TableCell><asp:TableCell ID="TableCell2" runat="server">
            <tr>
                <td align="left" style="width: 15%; padding-top: 10px; padding-bottom: 15px;">
                    <b>Signed By:</b>
                </td>
                <td align="left" style="width: 85%; padding-top: 10px;">
                    <b>
                        <asp:Label ID="lblSignedBy" runat="server"></asp:Label></b>
                </td>
            </tr>
        </asp:TableCell>
        <asp:TableCell ID="TableCell3" runat="server">
            <tr>
                <td align="left" style="width: 15%; padding-top: 10px; padding-bottom: 15px;">
                    <b>Signature:</b>
                </td>
                <td align="left" style="width: 85%">
                    <asp:Image ID="imgElectronicSignature" runat="server" Height="50px" align="left"
                        ImageAlign="Top" />
                </td>
            </tr>
        </asp:TableCell><asp:TableCell ID="TableCell4" runat="server">
            <tr>
                <td align="left" style="width: 15%; padding-top: 10px; padding-bottom: 15px;">
                    <b>Timestamp:</b>
                </td>
                <td align="left" style="width: 85%; padding-top: 10px;">
                    <asp:Label ID="lblTimestamp" runat="server" Font-Bold="True"></asp:Label>
                </td>
            </tr>
        </asp:TableCell>
    </asp:TableRow>
</asp:Table>
<%End If%>
<asp:ObjectDataSource ID="dsAccountExpenseEntryObject" runat="server" OldValuesParameterFormatString="original_{0}"
    SelectMethod="GetvueAccountExpenseEntriesReadOnly" TypeName="AccountExpenseEntryBLL">
    <SelectParameters>
        <asp:QueryStringParameter Name="AccountEmployeeId" QueryStringField="AccountEmployeeId"
            Type="Int32" />
        <asp:QueryStringParameter Name="AccountEmployeeExpenseSheetId" QueryStringField="AccountEmployeeExpenseSheetId"
            Type="Object" />
        <asp:QueryStringParameter Name="ApprovalType" QueryStringField="ApprovalType" Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>

<asp:ObjectDataSource ID="dsAccountExpenseEntryFromArchive" runat="server" OldValuesParameterFormatString="original_{0}"
    SelectMethod="GetDataForEntryArchivePopUp" TypeName="AccountExpenseEntryBLL" OnSelecting="dsAccountExpenseEntryFromArchive_Selecting">
    <SelectParameters>
    </SelectParameters>
</asp:ObjectDataSource>

<asp:ObjectDataSource ID="dsAccountExpenseEntryFromArchiveFiltred" runat="server" OldValuesParameterFormatString="original_{0}"
    SelectMethod="GetDataForEntryArchivePopUpFiltred" TypeName="AccountExpenseEntryBLL" OnSelecting="dsAccountExpenseEntryFromArchiveFiltred_Selecting">
    <SelectParameters>
    </SelectParameters>
</asp:ObjectDataSource>

<asp:ObjectDataSource ID="dsAccountExpenseEntryForPrintObject" runat="server" OldValuesParameterFormatString="original_{0}"
    SelectMethod="GetvueAccountExpenseEntryWithLastStausByEmployeeExpenseSheetId"
    TypeName="AccountExpenseEntryBLL" InsertMethod="AddExpenseApproval">
    <SelectParameters>
        <asp:QueryStringParameter Name="AccountEmployeeExpenseSheetId" QueryStringField="AccountEmployeeExpenseSheetId"
            Type="Object" />
    </SelectParameters>
    <InsertParameters>
        <asp:Parameter Name="AccountExpenseEntryId" Type="Int32" />
        <asp:Parameter Name="ExpenseApprovalTypeId" Type="Int32" />
        <asp:Parameter Name="ExpenseApprovalPathId" Type="Int32" />
        <asp:Parameter Name="ApprovedByEmployeeId" Type="Int32" />
        <asp:Parameter Name="Comments" Type="String" />
        <asp:Parameter Name="IsRejected" Type="Boolean" />
        <asp:Parameter Name="IsApproved" Type="Boolean" />
    </InsertParameters>
</asp:ObjectDataSource>
