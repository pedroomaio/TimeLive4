<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlUpdateCurrencies.ascx.vb" Inherits="AccountAdmin_Controls_ctlUpdateCurrencies" %>
<%@ Register Assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2"
    Namespace="eWorld.UI" TagPrefix="ew" %>
<%@ Register Assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2"
    Namespace="eWorld.UI" TagPrefix="ew" %>
<asp:FormView ID="FormView1" runat="server" DataKeyNames="AccountId"
    DataSourceID="dsUpdateCurrenciesFormViewObject" DefaultMode="Edit" SkinID="formviewSkinEmployee">
    <EditItemTemplate>
        <table width="450" class="xview">
            <tr>
                <td class="caption" colspan="2">
                    Update Currencies</td>
            </tr>
            <tr>
                <td class="FormViewSubHeader" colspan="2">
                    Update Currencies Information</td>
            </tr>
            <tr>
                <td class="FormViewLabelCell" style="width: 260px">
                    Change all expense entries currencies to:
                </td>
                <td style="width: 190px">
                    <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="dsCurrenciesObject"
                        DataTextField="Currency" DataValueField="AccountCurrencyId" Width="180px" SelectedValue='<%# Bind("AccountCurrencyId") %>'>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="FormViewLabelCell" style="width: 260px">
                </td>
                <td style="width: 190px">
                    <asp:Button ID="btnUpdate" runat="server" CommandName="Update" Text="Update" Width="68px" /></td>
            </tr>
        </table>
    </EditItemTemplate>
</asp:FormView>
<asp:ObjectDataSource ID="dsUpdateCurrenciesFormViewObject" runat="server" OldValuesParameterFormatString="original_{0}"
    SelectMethod="GetAccountExpenseEntriesByAccountId" TypeName="AccountExpenseEntryBLL"
    UpdateMethod="UpdateCurrenciesOfExpenseEntry">
    <UpdateParameters>
        <asp:SessionParameter DefaultValue="99" Name="Original_AccountId" SessionField="AccountId"
            Type="Int32" />
        <asp:Parameter Name="AccountCurrencyId" Type="Int32" />
    </UpdateParameters>
    <SelectParameters>
        <asp:SessionParameter DefaultValue="99" Name="AccountId" SessionField="AccountId"
            Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>
<asp:ObjectDataSource ID="dsCurrenciesObject" runat="server" OldValuesParameterFormatString="original_{0}"
    SelectMethod="GetvueAccountCurrencyByAccountId" TypeName="AccountCurrencyBLL">
    <SelectParameters>
        <asp:SessionParameter DefaultValue="989" Name="AccountId" SessionField="AccountId"
            Type="Int32" />
        <asp:Parameter Name="NotFixTable" Type="Boolean" />
    </SelectParameters>
</asp:ObjectDataSource>
