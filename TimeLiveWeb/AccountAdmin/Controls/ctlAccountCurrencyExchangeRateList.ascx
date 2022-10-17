<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlAccountCurrencyExchangeRateList.ascx.vb" Inherits="AccountAdmin_Controls_ctlAccountCurrencyExchangeRateList" %>
<%@ Register Assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2"
    Namespace="eWorld.UI" TagPrefix="ew" %>

<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
<div class="fieldset" style="width: 475px; margin-left: 6px; height: 18px;" 
            align="left">
<table width="100%">
            <tr>
                <td align="left" valign="middle">
                    <asp:Label ID="Label1" runat="server" Font-Names="Tahoma" Font-Bold="True" Font-Size="11px" Text="Current Currency:"></asp:Label>
                    <asp:Label ID="lblBaseCurrency" runat="server"  Text="Label" Font-Names="Tahoma" Font-Size="11px"></asp:Label></td>
            </tr></table></div>
         <x:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Caption='<%# ResourceHelper.GetFromResource("Exchange Rate List") %>'
            DataKeyNames="AccountCurrencyExchangeRateId" DataSourceID="dsAccountCurrencyExchangeRateGridViewObject"
            SkinID="xgridviewSkinEmployee" Width="500px">
            <Columns>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Exchange Rate %>" SortExpression="ExchangeRate">
                    <EditItemTemplate>
<asp:TextBox id="TextBox1" runat="server" Text='<%# Bind("ExchangeRate") %>' __designer:wfdid="w29"></asp:TextBox> 
</EditItemTemplate>
                    <headertemplate>
<asp:Label id="lblExchangeRate" runat="server" Text='<%# ResourceHelper.GetFromResource("Exchange Rate") %>' __designer:wfdid="w30"></asp:Label>
</headertemplate>
                    <ItemTemplate>
<asp:Label id="Label1" runat="server" Text='<%# Bind("ExchangeRate","{0:N4}") %>' __designer:wfdid="w28"></asp:Label> 
</ItemTemplate>
                    <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="25%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Start Date %>" SortExpression="ExchangeRateEffectiveStartDate">
                    <edititemtemplate>
<asp:TextBox id="TextBox2" runat="server" Text='<%# Bind("ExchangeRateEffectiveStartDate") %>' __designer:wfdid="w32"></asp:TextBox> 
</edititemtemplate>
                    <headertemplate>
<asp:Label id="lblStartDate" runat="server" Text='<%# ResourceHelper.GetFromResource("Start Date") %>' __designer:wfdid="w33"></asp:Label>
</headertemplate>
                    <itemtemplate>
<asp:Label id="Label2" runat="server" Text='<%# Bind("ExchangeRateEffectiveStartDate", "{0:d}") %>' __designer:wfdid="w31"></asp:Label> 
</itemtemplate>
                    <itemstyle horizontalalign="Center" verticalalign="Middle" width="32%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, End Date %>" SortExpression="ExchangeRateEffectiveEndDate">
                    <edititemtemplate>
<asp:TextBox id="TextBox3" runat="server" Text='<%# Bind("ExchangeRateEffectiveEndDate") %>' __designer:wfdid="w35"></asp:TextBox> 
</edititemtemplate>
                    <headertemplate>
<asp:Label id="lblEndDate" runat="server" Text='<%# ResourceHelper.GetFromResource("End Date") %>' __designer:wfdid="w36"></asp:Label>
</headertemplate>
                    <itemtemplate>
<asp:Label id="Label3" runat="server" Text='<%# Bind("ExchangeRateEffectiveEndDate", "{0:d}") %>' __designer:wfdid="w34"></asp:Label> 
</itemtemplate>
                    <itemstyle horizontalalign="Center" verticalalign="Middle" width="32%" />
                </asp:TemplateField>
        <asp:CommandField HeaderText="<%$ Resources:TimeLive.Resource, Edit_Text %>" SelectText="Edit" ShowSelectButton="True" >
            <ItemStyle HorizontalAlign="Center"  cssclass="edit_button" Width="1%" />
          
        </asp:CommandField>
        <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Delete_Text %>" ShowHeader="False">
     <ItemTemplate>
<asp:LinkButton id="LinkButton1" runat="server" __designer:wfdid="w13" OnClientClick="<%# ResourceHelper.GetDeleteMessageJavascript()%>" CommandName="Delete" CausesValidation="False"></asp:LinkButton> 
</ItemTemplate>
            <ItemStyle HorizontalAlign="Center"  cssclass="delete_button" Width="1%" />
        </asp:TemplateField>
            </Columns>
        </x:GridView>
        <asp:ObjectDataSource ID="dsAccountCurrencyExchangeRateGridViewObject" runat="server"
            DeleteMethod="DeleteAccountCurrencyExchangeRate" InsertMethod="AddAccountCurrencyExchangeRate"
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetAccountCurrencyExchangeRatesByAccountIdAndAccountCurrencyId"
            TypeName="AccountCurrencyExchangeRateBLL" UpdateMethod="UpdateAccountCurrencyExchangeRate">
            <DeleteParameters>
                <asp:Parameter Name="Original_AccountCurrencyExchangeRateId" Type="Int32" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="ExchangeRateEffectiveStartDate" Type="DateTime" />
                <asp:Parameter Name="ExchangeRateEffectiveEndDate" Type="DateTime" />
                <asp:Parameter Name="ExchangeRate" Type="Decimal" />
                <asp:Parameter Name="AccountId" Type="Int32" />
                <asp:Parameter Name="Original_AccountCurrencyExchangeRateId" Type="Int32" />
                <asp:Parameter Name="AccountCurrencyId" Type="Int32" />
            </UpdateParameters>
            <InsertParameters>
                <asp:Parameter Name="ExchangeRateEffectiveStartDate" Type="DateTime" />
                <asp:Parameter Name="ExchangeRateEffectiveEndDate" Type="DateTime" />
                <asp:Parameter Name="ExchangeRate" Type="Decimal" />
                <asp:Parameter Name="AccountId" Type="Int32" />
                <asp:Parameter Name="AccountCurrencyId" Type="Int32" />
            </InsertParameters>
            <SelectParameters>
                <asp:SessionParameter DefaultValue="23" Name="AccountId" SessionField="AccountId"
                    Type="Int32" />
                <asp:QueryStringParameter DefaultValue="1" Name="AccountCurrencyId" QueryStringField="AccountCurrencyId"
                    Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="dsAccountCurrencyExchangeRateFormViewObject" runat="server"
            DeleteMethod="DeleteAccountCurrencyExchangeRate" InsertMethod="AddAccountCurrencyExchangeRate"
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetAccountCurrencyExchangeRatesByAccountCurrencyExchangeRateId"
            TypeName="AccountCurrencyExchangeRateBLL" UpdateMethod="UpdateAccountCurrencyExchangeRate">
            <DeleteParameters>
                <asp:Parameter Name="Original_AccountCurrencyExchangeRateId" Type="Int32" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="ExchangeRateEffectiveStartDate" Type="DateTime" />
                <asp:Parameter Name="ExchangeRateEffectiveEndDate" Type="DateTime" />
                <asp:Parameter Name="ExchangeRate" Type="Decimal" />
                <asp:SessionParameter DefaultValue="23" Name="AccountId" SessionField="AccountId"
                    Type="Int32" />
                <asp:Parameter Name="Original_AccountCurrencyExchangeRateId" Type="Int32" />
                <asp:Parameter Name="AccountCurrencyId" Type="Int32" />
            </UpdateParameters>
            <SelectParameters>
                <asp:ControlParameter ControlID="GridView1" Name="AccountCurrencyExchangeRateId"
                    PropertyName="SelectedValue" Type="Int32" />
            </SelectParameters>
            <InsertParameters>
                <asp:Parameter Name="ExchangeRateEffectiveStartDate" Type="DateTime" />
                <asp:Parameter Name="ExchangeRateEffectiveEndDate" Type="DateTime" />
                <asp:Parameter Name="ExchangeRate" Type="Decimal" />
                <asp:SessionParameter DefaultValue="23" Name="AccountId" SessionField="AccountId"
                    Type="Int32" />
                <asp:Parameter Name="AccountCurrencyId" Type="Int32" />
            </InsertParameters>
        </asp:ObjectDataSource>
    </ContentTemplate>
</asp:UpdatePanel>
&nbsp;
<br />
<asp:UpdatePanel ID="UpdatePanel2" runat="server">
    <ContentTemplate>
        <asp:FormView ID="FormView1" runat="server" DataKeyNames="AccountCurrencyExchangeRateId"
            DataSourceID="dsAccountCurrencyExchangeRateFormViewObject" DefaultMode="Insert"
            SkinID="formviewSkinEmployee" Width="505px">
            <EditItemTemplate>
                <table width="503" class="xview">
                    <tr>
                        <th class="caption" colspan="2">
                            <asp:Literal ID="Literal1" runat="server" Text='<%# ResourceHelper.GetFromResource("Exchange Rate Information") %>' /></th>
                    </tr>
                    <tr>
                        <th class="FormViewSubHeader" colspan="2">
                           <asp:Literal ID="Literal2" runat="server" Text='<%# ResourceHelper.GetFromResource("Exchange Rate") %>' /></th>
                    </tr>
                    <tr>
                        <td colspan="2" align="left">
                            &nbsp;<asp:Label ID="Label2" runat="server" Font-Names="Tahoma" Font-Size="11px" Text="<%$ Resources:TimeLive.Resource, Value 1 Base Currency Unit X New Currency Units%> "></asp:Label></td>
                            <%--<asp:ListItem Label ID="Label2" runat="server" Font-Names="Tahoma" Font-Size="11px" Text="<%$ Resources:TimeLive.Resource, Value 1 Base Currency Unit X New Currency Units%> "></asp:ListItem>--%>
                    </tr>
                    <tr>
                        <td align="right" class="FormViewLabelCell" style="width: 45%">
                             <SPAN 
                  class=reqasterisk>*</SPAN> <asp:Literal ID="Literal3" runat="server" Text='<%# ResourceHelper.GetFromResource("Exchange Rate:") %>' /></td>
                        </td>
                        <td style="width: 55%">
                            <asp:TextBox ID="ExchangeRateTextBox" runat="server" 
                                Text='<%# Bind("ExchangeRate") %>' style="text-align:right;" Width="55px"></asp:TextBox><asp:RequiredFieldValidator
                                ID="RequiredFieldValidator2" runat="server" ControlToValidate="ExchangeRateTextBox"
                                CssClass="ErrorMessage" Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td align="right" class="FormViewLabelCell" style="width: 45%;">
                            <asp:Literal ID="Literal4" runat="server" Text='<%# ResourceHelper.GetFromResource("Start Date:") %>' /></td>
                        </td>
                        <td style="width: 55%;">
                            <ew:calendarpopup id="StartDateTextBox" runat="server" SkinId="DatePicker" 
                                posteddate="" selecteddate='<%# Bind("ExchangeRateEffectiveStartDate") %>'
                                selectedvalue="06/30/2008 21:16:14" upperbounddate="12/31/9999 23:59:59" 
                                visibledate="06/30/2008 21:16:14" Width="55px"></ew:calendarpopup>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="FormViewLabelCell" style="width: 45%">
                            <asp:Literal ID="Literal5" runat="server" Text='<%# ResourceHelper.GetFromResource("End Date:") %>' /></td>
                        </td>
                        <td style="width: 55%">
                            <ew:calendarpopup id="EndDateTextBox" runat="server" 
                                SkinId="DatePicker" posteddate="" selecteddate='<%# Bind("ExchangeRateEffectiveEndDate") %>'
                                selectedvalue="06/30/2008 21:16:14" upperbounddate="12/31/9999 23:59:59" 
                                visibledate="06/30/2008 21:16:14" Width="55px">
                        </ew:CalendarPopup>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="FormViewLabelCell" style="width: 45%">
                            <asp:Literal ID="Literal6" runat="server" Text="<%$ Resources:TimeLive.Resource, Update all record within this range%> " />:</td>
                        </td>
                        <td style="width: 55%">
                            <asp:CheckBox ID="chkUpdateExpenseEntry" runat="server" /></td>
                    </tr>
                    <tr>
                        <td align="right" class="FormViewLabelCell" style="width: 45%">
                        </td>
                        <td style="width: 55%; padding-bottom: 5px;">
                            <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="<%$ Resources:TimeLive.Resource, Update_text%> " Width="68px" />&nbsp;<asp:Button
                                ID="CancelButton" runat="server" CommandName="Cancel" Text="<%$ Resources:TimeLive.Resource, Cancel_text%> " Width="68px" /></td>
                    </tr>
                </table>
            </EditItemTemplate>
            <InsertItemTemplate><table width="503" class="xview">
                <tr>
                    <th class="caption" colspan="2">
                        <asp:Literal ID="Literal6" runat="server" Text='<%# ResourceHelper.GetFromResource("Exchange Rate Information") %>' /></th>
                </tr>
                <tr>
                    <th class="FormViewSubHeader" colspan="2">
                        <asp:Literal ID="Literal7" runat="server" Text='<%# ResourceHelper.GetFromResource("Exchange Rate") %>' /></th>
                </tr>
                <tr>
                    <td colspan="2" align="Left">
                        &nbsp;<asp:Label ID="Label2" runat="server" Font-Names="Tahoma" Font-Size="11px" Text="<%$ Resources:TimeLive.Resource, Value 1 Base Currency Unit X New Currency Units%> "></asp:Label></td>
                </tr>
                <tr>
                    <td align="right" class="FormViewLabelCell" style="width: 30%">
                         <SPAN 
                  class=reqasterisk>*</SPAN> <asp:Literal ID="Literal8" runat="server" Text='<%# ResourceHelper.GetFromResource("Exchange Rate:") %>' /></td>
                    </td>
                    <td style="width: 70%">
                        <asp:TextBox ID="ExchangeRateTextBox" runat="server" Text='<%# Bind("ExchangeRate") %>'
                            style="text-align:right;" Width="55px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator2"
                                runat="server" ControlToValidate="ExchangeRateTextBox" CssClass="ErrorMessage"
                                Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td align="right" class="FormViewLabelCell" style="width: 30%;">
                        <asp:Literal ID="Literal9" runat="server" Text='<%# ResourceHelper.GetFromResource("Start Date:") %>' /></td>
                    </td>
                    <td style="width: 70%;">
                        <ew:calendarpopup id="StartDateTextBox" runat="server" SkinId="DatePicker"
                                selectedvalue="06/30/2008 21:16:14" visibledate="06/30/2008 21:16:14" 
                            Width="55px">
                        </ew:CalendarPopup>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="style1">
                        <asp:Literal ID="Literal10" runat="server" Text='<%# ResourceHelper.GetFromResource("End Date:") %>' /></td>
                    </td>
                    <td class="style2">
                        <ew:calendarpopup id="EndDateTextBox" runat="server" SkinId="DatePicker"
                                selectedvalue="06/30/2008 21:16:14" visibledate="06/30/2008 21:16:14" 
                            Width="55px">
                        </ew:CalendarPopup>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="FormViewLabelCell" style="width: 30%">
                    </td>
                    <td style="width: 70%; padding-bottom: 5px; padding-Top: 5px;">
                        <asp:Button ID="AddButton" runat="server" CommandName="Insert" Text="<%$ Resources:TimeLive.Resource, Add_text%> " Width="68px" /></td>
                </tr>
            </table>
            </InsertItemTemplate>
            <ItemTemplate>
                AccountCurrencyExchangeRateId:
                <asp:Label ID="AccountCurrencyExchangeRateIdLabel" runat="server" Text='<%# Eval("AccountCurrencyExchangeRateId") %>'>
                </asp:Label><br />
                ExchangeRateEffectiveStartDate:
                <asp:Label ID="ExchangeRateEffectiveStartDateLabel" runat="server" Text='<%# Bind("ExchangeRateEffectiveStartDate") %>'>
                </asp:Label><br />
                ExchangeRateEffectiveEndDate:
                <asp:Label ID="ExchangeRateEffectiveEndDateLabel" runat="server" Text='<%# Bind("ExchangeRateEffectiveEndDate") %>'>
                </asp:Label><br />
                ExchangeRate:
                <asp:Label ID="ExchangeRateLabel" runat="server" Text='<%# Bind("ExchangeRate") %>'>
                </asp:Label><br />
                AccountId:
                <asp:Label ID="AccountIdLabel" runat="server" Text='<%# Bind("AccountId") %>'></asp:Label><br />
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
    </ContentTemplate>
</asp:UpdatePanel>
&nbsp;
