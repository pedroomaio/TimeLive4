<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlAccountTimeExpenseBilling.ascx.vb" Inherits="ProjectAdmin_Controls_ctlAccountTimeExpenseBilling" %>
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
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <table width="98%" id="TABLE1">
            <tr>
                <td>
        <x:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Caption='<%# ResourceHelper.GetFromResource("Time Expense Invoice List") %>' SkinID="xgridviewSkinEmployee" DataKeyNames="AccountTimeExpenseBillingId,IsPaid"
            DataSourceID="dsAccountTimeExpenseBillingObject" Width="100%" OnRowDataBound="GridView1_RowDataBound" >
            <Columns>
                <asp:TemplateField >
                    <headertemplate>
                        <asp:CheckBox ID="chkCheckAll" runat="server" Text="Paid" __designer:wfdid="w109" />
</headertemplate>
                    <itemtemplate>
                        <asp:CheckBox id="chkpaid" runat="server" Visible='<%# IIF(Isdbnull(Eval("AccountTimeExpenseBillingId")),"False","True") %>' __designer:wfdid="w1" Checked='<%# iif(IsDBNull(Eval("IsPaid")),false,Eval("IsPaid")) %>'></asp:CheckBox> 
</itemtemplate>
                    <HeaderStyle />
                    <itemstyle width="1%" VerticalAlign="Middle" HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Client Name %>" SortExpression="AccountClientId">
                    <edititemtemplate>
<asp:TextBox id="TextBox2" runat="server" Text='<%# Bind("PartyName") %>' __designer:wfdid="w4"></asp:TextBox>
</edititemtemplate>
                    <headertemplate>
<asp:LinkButton id="LinkButton3" runat="server" Text='<%# ResourceHelper.GetFromResource("Client Name") %>' CommandArgument="PartyName" CommandName="Sort" CausesValidation="False"></asp:LinkButton>
</headertemplate>
                    <itemtemplate>
<asp:Label id="Label4" runat="server" Text='<%# Bind("PartyName") %>' __designer:wfdid="w3"></asp:Label>
</itemtemplate>
                    <itemstyle width="30%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Invoice No. %>" SortExpression="InvoiceNumber">
                    <edititemtemplate>
<asp:TextBox id="TextBox3" runat="server" Text='<%# Bind("InvoiceNumber") %>' __designer:wfdid="w13"></asp:TextBox>
</edititemtemplate>
                    <headertemplate>
<asp:LinkButton id="LinkButton4" runat="server" Text='<%# ResourceHelper.GetFromResource("Invoice No.") %>' CommandArgument="InvoiceNumber" CommandName="Sort" CausesValidation="False"></asp:LinkButton>
</headertemplate>
                    <itemtemplate>
<asp:Label id="Label5" runat="server" Text='<%# Bind("InvoiceNumber") %>' __designer:wfdid="w12"></asp:Label>
</itemtemplate>
                    <itemstyle width="8%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Invoice Date %>" SortExpression="InvoiceDate">
                    <edititemtemplate>
<asp:TextBox id="TextBox4" runat="server" Text='<%# Bind("InvoiceDate") %>' __designer:wfdid="w16"></asp:TextBox>
</edititemtemplate>
                    <headertemplate>
<asp:LinkButton id="LinkButton5" runat="server" Text='<%# ResourceHelper.GetFromResource("Invoice Date") %>' CommandArgument="InvoiceDate" CommandName="Sort" CausesValidation="False"></asp:LinkButton>
</headertemplate>
                    <itemtemplate>
<asp:Label id="Label6" runat="server" Text='<%# Bind("InvoiceDate", "{0:d}") %>' __designer:wfdid="w15"></asp:Label>
</itemtemplate>
                    <itemstyle width="12%" HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Description %>" SortExpression="Description">
                    <edititemtemplate>
<asp:TextBox id="TextBox5" runat="server" Text='<%# Bind("Description") %>' __designer:wfdid="w19"></asp:TextBox>
</edititemtemplate>
                    <headertemplate>
<asp:LinkButton id="LinkButton6" runat="server" Text='<%# ResourceHelper.GetFromResource("Description") %>' CommandArgument="Description" CommandName="Sort" CausesValidation="False"></asp:LinkButton>
</headertemplate>
                    <itemtemplate>
<asp:Label id="Label7" runat="server" Text='<%# Bind("Description") %>' __designer:wfdid="w18"></asp:Label>
</itemtemplate>
                    <itemstyle width="40%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Amount %>" SortExpression="GrandTotal">
                    <edititemtemplate>
<asp:TextBox id="TextBox1" runat="server" Text='<%# Bind("CurrencyCode") %>' __designer:wfdid="w23"></asp:TextBox> 
</edititemtemplate>
                    <headertemplate>
<asp:Label id="lblAmount" runat="server" Text='<%# ResourceHelper.GetFromResource("Amount") %>' __designer:wfdid="w24"></asp:Label>
</headertemplate>
                    <itemtemplate>
<asp:Label id="Label2" runat="server" Text='<%# Bind("CurrencyCode") %>' __designer:wfdid="w21"></asp:Label>&nbsp;<asp:Label id="Label3" runat="server" Text='<%# Bind("GrandTotal", "{0:N}") %>' __designer:wfdid="w22"></asp:Label> 
</itemtemplate>
                    <itemstyle HorizontalAlign="Right" width="5%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Edit_text %>">
                    <itemtemplate>
<asp:HyperLink id="HyperLink1" runat="server" Visible='<%# IIF(Isdbnull(Eval("AccountTimeExpenseBillingId")),"False","True") %>' __designer:wfdid="w25" NavigateUrl='<%# Eval("AccountTimeExpenseBillingId", "~/ProjectAdmin/AccountInvoiceForm.aspx?AccountTimeExpenseBillingId={0}") %>'></asp:HyperLink> 
</itemtemplate>
                    <headerstyle horizontalalign="Center" width="1%" />
                    <itemstyle horizontalalign="Center" verticalalign="Middle" cssclass="edit_button" width="1%" />
                </asp:TemplateField>
        <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Delete_text %>" ShowHeader="False">
     <ItemTemplate>
<asp:LinkButton id="LinkButton1" runat="server" OnClientClick="<%# ResourceHelper.GetDeleteMessageJavascript() %>" Visible='<%# IIF(Isdbnull(Eval("AccountTimeExpenseBillingId")),"False","True") %>' __designer:wfdid="w3" CausesValidation="False" CommandName="Delete"></asp:LinkButton> 
</ItemTemplate>
            <HeaderStyle HorizontalAlign="Center" width="1%" />
            <ItemStyle HorizontalAlign="Center" cssclass="delete_button" width="1%"/>
        </asp:TemplateField>
        <asp:TemplateField>
            <HeaderTemplate>
<asp:Image id="Image1" runat="server" ToolTip="<%$ Resources:TimeLive.Resource, Disabled_text%> " ImageUrl="~/Images/Disabled.gif" __designer:wfdid="w11"></asp:Image> 
</HeaderTemplate>
            <ItemTemplate>
<asp:Image id="Image2" runat="server" ToolTip="<%$ Resources:TimeLive.Resource, Disabled_text%> " ImageUrl="~/Images/Disabled.gif" Visible='<%# IIF(IsDBNull(Eval("IsDisabled")),"false",Eval("IsDisabled")) %>' __designer:wfdid="w10"></asp:Image> 
</ItemTemplate>
            <ItemStyle HorizontalAlign="Center" width="1%" />
        </asp:TemplateField>
                <asp:TemplateField>
                    <headertemplate>
<asp:Label id="lblPrint" runat="server" Text='<%# ResourceHelper.GetFromResource("Print") %>' __designer:wfdid="w27"></asp:Label>
</headertemplate>
                    <itemtemplate>
<asp:HyperLink id="HyperLink2" runat="server" Visible='<%# IIF(Isdbnull(Eval("AccountTimeExpenseBillingId")),"False","True") %>' Text='<%# ResourceHelper.GetFromResource("Print") %>' __designer:wfdid="w26" NavigateUrl='<%# Eval("AccountTimeExpenseBillingId", "~/Reports/AccountTimeExpenseBillingReport.aspx?AccountTimeExpenseBillingId={0}") %>'></asp:HyperLink> 
</itemtemplate>
                    <itemstyle width="2%" HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="AccountTimeExpenseBillingId" SortExpression="AccountTimeExpenseBillingId"
                    Visible="False">
                    <edititemtemplate>
<asp:Label id="Label1" runat="server" Text='<%# Eval("AccountTimeExpenseBillingId") %>' __designer:wfdid="w13"></asp:Label> 
</edititemtemplate>
                    <itemtemplate>
<asp:Label id="Label1" runat="server" Text='<%# Bind("AccountTimeExpenseBillingId") %>' __designer:wfdid="w12"></asp:Label> 
</itemtemplate>
                    <itemstyle width="0%" />
                </asp:TemplateField>
            </Columns>
        </x:GridView>
        <br />
              <table style="width: 100%">
                     <tr>
                        <td align="right" style="width: 100%">
                            <asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" Text="<%$ Resources:TimeLive.Resource, Update %>" Width="75px" Visible="False" />
                            <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="<%$ Resources:TimeLive.Resource, Add_text %>" Width="75px" /></td>
                     </tr>
              </table>
        <asp:ObjectDataSource ID="dsAccountTimeExpenseBillingObject" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetvueAccountTimeExpenseBillingByAccountId" TypeName="AccountTimeExpenseBillingBLL" InsertMethod="AddAccountTimeExpenseBilling" UpdateMethod="UpdateAccountTimeExpenseBilling" DataObjectTypeName="System.Guid" DeleteMethod="DeleteAccountTimeExpenseBilling">
            <SelectParameters>
                <asp:SessionParameter DefaultValue="98" Name="AccountId" SessionField="AccountId"
                    Type="Int32" />
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter Name="Original_AccountTimeExpenseBillingId" />
                <asp:Parameter Name="AccountId" Type="Int32" />
                <asp:Parameter Name="AccountClientId" Type="Int32" />
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
            </UpdateParameters>
            <InsertParameters>
                <asp:Parameter Name="AccountId" Type="Int32" />
                <asp:Parameter Name="AccountClientId" Type="Int32" />
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
            </InsertParameters>
        </asp:ObjectDataSource>
    </td>
            </tr>
        </table>
    </ContentTemplate>
</asp:UpdatePanel>
