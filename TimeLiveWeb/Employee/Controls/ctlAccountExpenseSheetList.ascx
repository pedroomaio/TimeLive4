<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlAccountExpenseSheetList.ascx.vb"
    Inherits="Employee_Controls_ctlAccountExpenseSheetList" %>
<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<asp:UpdatePanel ID="UpdatePanel2" runat="server">
    <ContentTemplate>
        <table width="98%" class="xFormView">
            <tr>
                <td>
                    <table width="100%" class="xFormView">
                        <tr>
                            <th colspan="3" class="caption">
                                <asp:Literal ID="Literal1" runat="server" Text="<%$ Resources:TimeLive.Resource, Expense Sheet%> " />
                            </th>
                        </tr>
                        <tr>
                            <th colspan="3" class="FormViewSubHeader">
                                <asp:Literal ID="Literal2" runat="server" Text="<%$ Resources:TimeLive.Resource, Search Parameter%> " />
                            </th>
                        </tr>
                        <tr>
                            <td align="right" style="width: 20%">
                                <asp:Label ID="Label8" runat="server" Font-Bold="True" Font-Size="11px" Width="150px">
                                    <asp:Literal ID="Literal7" runat="server" Text="<%$ Resources:TimeLive.Resource, Employee Name:%> " /></asp:Label>
                            </td>
                            <td style="width: 78%" colspan="2">
                                <asp:DropDownList ID="ddlEmployeeName" runat="server" Width="250px" OnSelectedIndexChanged="ddlEmployeeName_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 20%" align="right">
                                <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="11px" Width="150px">
                                    <asp:Literal ID="Literal3" runat="server" Text="<%$ Resources:TimeLive.Resource, Approval Status:%> " /></asp:Label>
                            </td>
                            <td style="width: 78%" colspan="2">
                                <asp:DropDownList ID="ddlExpenseSheet" runat="server" Width="250px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 20%; vertical-align: top" align="right">
                                <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Size="11px" Width="150px">
                                    <asp:Literal ID="Literal4" runat="server" Text="<%$ Resources:TimeLive.Resource, Include Date Range:%> " /></asp:Label>
                            </td>
                            <td style="width: 78%; vertical-align: middle" colspan="2">
                                <asp:CheckBox ID="chkIncludeDateRange" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 20%" align="right">
                                <asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Size="11px" Width="150px">
                                    <asp:Literal ID="Literal5" runat="server" Text="<%$ Resources:TimeLive.Resource, Start Date:%> " /></asp:Label>
                            </td>
                            <td style="width: 78%" colspan="2">
                                <ew:CalendarPopup ID="StartDateTextBox" runat="server" SkinID="DatePicker" Width="55px">
                                </ew:CalendarPopup>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 20%" align="right">
                                <asp:Label ID="Label7" runat="server" Font-Bold="True" Font-Size="11px" Width="150px">
                                    <asp:Literal ID="Literal6" runat="server" Text="<%$ Resources:TimeLive.Resource, End Date:%> " /></asp:Label>
                            </td>
                            <td style="width: 78%" colspan="2">
                                <ew:CalendarPopup ID="EndDateTextBox" runat="server" SkinID="DatePicker" Width="55px">
                                </ew:CalendarPopup>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 20%">
                                &nbsp;
                            </td>
                            <td style="width: 39%; padding-bottom: 5px;">
                                <asp:Button ID="btnShow" runat="server" OnClick="btnShow_Click" Text="<%$ Resources:TimeLive.Resource, Show_text%> " />
                            </td>
                            <td style="width: 39%; padding-bottom: 5px; padding-right: 5px;" align="right">
                                <asp:Button ID="btnAdd" runat="server" Text="<%$ Resources:TimeLive.Resource, Add New Expense Sheet %>" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <br />
        <asp:ObjectDataSource ID="dsEmployeeExpenseSheetGridViewObject" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetvueAccountEmployeeExpenseSheetByAccountEmployeeIdAndApprovalStatus"
            TypeName="AccountEmployeeExpenseSheetBLL" InsertMethod="AddAccountEmployeeExpenseSheet"
            UpdateMethod="UpdateAccountEmployeeExpenseSheet">
            <SelectParameters>
                <asp:ControlParameter ControlID="ddlEmployeeName" Name="AccountEmployeeId" PropertyName="SelectedValue"
                    Type="Int32" />
                <asp:ControlParameter ControlID="ddlExpenseSheet" Name="ExpenseSheetStatusId" PropertyName="SelectedValue"
                    Type="Int32" />
                <asp:ControlParameter ControlID="chkIncludeDateRange" Name="IncludeDateRange" PropertyName="Checked"
                    Type="Boolean" />
                <asp:Parameter Name="StartDate" Type="DateTime" />
                <asp:Parameter Name="EndDate" Type="DateTime" />
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter Name="Description" Type="String" />
                <asp:Parameter Name="ExpenseSheetDate" Type="DateTime" />
                <asp:Parameter Name="Original_AccountEmployeeExpenseSheetId" Type="Object" />
            </UpdateParameters>
            <InsertParameters>
                <asp:Parameter Name="AccountId" Type="Int32" />
                <asp:Parameter Name="AccountEmployeeId" Type="Int32" />
                <asp:Parameter Name="Description" Type="String" />
                <asp:Parameter Name="ExpenseSheetDate" Type="DateTime" />
                <asp:Parameter Name="Approved" Type="Boolean" />
                <asp:Parameter Name="Rejected" Type="Boolean" />
                <asp:Parameter Name="Submitted" Type="Boolean" />
                <asp:Parameter Name="InApproval" Type="Boolean" />
                <asp:Parameter Name="SubmittedDate" Type="DateTime" />
            </InsertParameters>
        </asp:ObjectDataSource>
        <x:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Caption="<%$ Resources:TimeLive.Resource, Expense Sheet List %>"
            DataSourceID="dsEmployeeExpenseSheetGridViewObject" SkinID="xgridviewSkinEmployee"
            Width="98%" DataKeyNames="AccountEmployeeExpenseSheetId" Style="margin-left: 1px">
            <Columns>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Date %>" SortExpression="ExpenseSheetDate">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("ExpenseSheetDate") %>'
                            __designer:wfdid="w57"></asp:TextBox>
                    </EditItemTemplate>
                    <HeaderTemplate>
                        <asp:LinkButton ID="LinkButton3" runat="server" Text='<%# ResourceHelper.GetFromResource("Date") %>'
                            CommandArgument="ExpenseSheetDate" CommandName="Sort" CausesValidation="False"></asp:LinkButton>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("ExpenseSheetDate", "{0:d}") %>'
                            __designer:wfdid="w56"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="8%" HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Description %>" SortExpression="Description">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Description") %>' __designer:wfdid="w60"></asp:TextBox>
                    </EditItemTemplate>
                    <HeaderTemplate>
                        <asp:LinkButton ID="LinkButton4" runat="server" Text='<%# ResourceHelper.GetFromResource("Description") %>'
                            CommandArgument="Description" CommandName="Sort" CausesValidation="False"></asp:LinkButton>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("Description") %>' __designer:wfdid="w59"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="64%" />
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Payment Status" SortExpression="PaymentStatusId">
                    <EditItemTemplate>
                        <asp:TextBox ID="PaymentStatusTtxt" runat="server" Text='<%# Bind("PaymentStatusState") %>' __designer:wfdid="w60"></asp:TextBox>
                    </EditItemTemplate> 
                    <HeaderTemplate>
                        <asp:LinkButton ID="PaymentStatusLinkbt" runat="server" Text='Payment Status'
                            CommandArgument="Description" CommandName="Sort" CausesValidation="False"></asp:LinkButton>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="PaymentStatusLbl" runat="server" Text='<%# Bind("PaymentStatusState") %>' __designer:wfdid="w59"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="5%" />
                </asp:TemplateField>

                <asp:TemplateField SortExpression="Amount">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Amount") %>' __designer:wfdid="w64"></asp:TextBox>
                    </EditItemTemplate>
                    <HeaderTemplate>
                        <asp:LinkButton ID="lbtnAmount" runat="server" Text='<%# ResourceHelper.GetFromResource("Amount") %>'
                            CommandArgument="Amount" CommandName="Sort" CausesValidation="False"></asp:LinkButton>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblAmount" runat="server" Text='<%# Bind("Amount", "{0:N}") %>' __designer:wfdid="w63"></asp:Label>
                        <asp:Label ID="lblCurrency" runat="server" Text='<%# Bind("CurrencyCode") %>' __designer:wfdid="w62"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="15%" HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Status %>" SortExpression="Status">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("Status") %>' __designer:wfdid="w67"></asp:TextBox>
                    </EditItemTemplate>
                    <HeaderTemplate>
                        <asp:LinkButton ID="LinkButton6" runat="server" Text='<%# ResourceHelper.GetFromResource("Status") %>'
                            CommandArgument="Status" CommandName="Sort" CausesValidation="False"></asp:LinkButton>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("Status") %>' __designer:wfdid="w66"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="10%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Edit_text %>">
                    <ItemTemplate>
                        <asp:HyperLink ID="EditHyperLink" runat="server" Visible='<%# IIF(IsDbNull(Eval("AccountEmployeeExpenseSheetId")),"False","True") %>'
                            NavigateUrl='<%# Eval("AccountEmployeeExpenseSheetId", "~/Employee/AccountExpenseEntryForm.aspx?AccountEmployeeExpenseSheetId={0}") %>'
                            __designer:wfdid="w43">[EditHyperLink]</asp:HyperLink>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle CssClass="edit_button" HorizontalAlign="Center" VerticalAlign="Middle"
                        Width="1%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Delete_text %>" ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkDelete" runat="server" Text="<%$ Resources:TimeLive.Resource, Delete_text %>"
                            Visible='<%# IIF(IsDbNull(Eval("AccountEmployeeExpenseSheetId")),"False","True") %>'
                            ToolTip="<%$ Resources:TimeLive.Resource, Delete_text %>" CommandName="Delete"
                            CausesValidation="False" OnClientClick="<%# ResourceHelper.GetDeleteMessageJavascript() %>"
                            __designer:wfdid="w42"></asp:LinkButton>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="1%" CssClass="delete_button" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:HyperLink ID="CopyHyperLink" runat="server" Text="<%$ Resources:TimeLive.Resource, Copy%> "
                            Visible='<%# IIF(IsDbnull(Eval("AccountEmployeeExpenseSheetId")),"False","True") %>'
                            NavigateUrl='<%# Eval("AccountEmployeeExpenseSheetId", "~/Employee/AccountExpenseEntryForm.aspx?AccountEmployeeExpenseSheetId={0}&IsCopy=True") %>'
                            __designer:wfdid="w4"></asp:HyperLink>
                    </ItemTemplate>
                    <ItemStyle Width="2%" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:HyperLink ID="AuditHyperLink" runat="server" Text="<%$ Resources:TimeLive.Resource, Audit%> "
                            Visible='<%# IIF(IsDbnull(Eval("AccountEmployeeExpenseSheetId")),"False","True") %>'
                            NavigateUrl='<%# Eval("AccountEmployeeExpenseSheetId", "~/Employee/AccountExpenseEntryAudit.aspx?AccountEmployeeExpenseSheetId={0}") %>'
                            __designer:wfdid="w4"></asp:HyperLink>
                    </ItemTemplate>
                    <ItemStyle Width="2%" />
                </asp:TemplateField>
            </Columns>
        </x:GridView>
        &nbsp;</ContentTemplate>
</asp:UpdatePanel>
