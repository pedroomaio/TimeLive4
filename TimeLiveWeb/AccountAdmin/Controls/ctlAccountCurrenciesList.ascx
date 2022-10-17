<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlAccountCurrenciesList.ascx.vb" Inherits="AccountAdmin_Controls_ctlAccountCurrenciesList" %>
<%@ Register Assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2"
    Namespace="eWorld.UI" TagPrefix="ew" %>
 <script type = "text/javascript" language='JavaScript'>

</script>
 <div class="fieldset" style="width: 35%; margin-left: 6px; height: 35px;" 
            align="left">
<table width="98%">
            <tr>
            <td class="FormViewLabelCell" align="left" style="height:20px; width: 1%; padding-right: 5px;" valign="middle">
            <asp:Label id="Label2" runat="server" 
                            Font-Bold="True" Font-Size="11px" Width="130px">
            <asp:Literal ID="Literal26" runat="server" Text="<%$ Resources:TimeLive.Resource, Current Base Currency: %>" /></asp:Label></td><td align="left" style="width: 97%; height:20px"><asp:Label ID="Label3" runat="server" Font-Size="11px"
                    Text="Label"></asp:Label><asp:HyperLink ID="HyperLink3" runat="server"
                    Font-Size="11px" ForeColor="Black" onclick= "window.open (this.href, 'popupwindow', 'width=425,height=170,left=500,top=300'); return false;" NavigateUrl="~/AccountAdmin/AccountBaseCurrency.aspx">
                    </asp:HyperLink></td></tr><tr align="left" >
            <td class="FormViewLabelCell" align="left" style="height:20px; width: 1%; padding-right: 5px;" valign="middle"><asp:Label id="Label4" runat="server" Font-Bold="True" Font-Size="11px" Width="130px">
            <asp:Literal ID="Literal27" runat="server" Text="<%$ Resources:TimeLive.Resource, Change Base Currency:%> " /></asp:Label></td><td align="left" style="width: 97%; height:20px" valign="middle"><asp:HyperLink 
                        ID="HyperLink2" runat="server" ImageUrl="~/Images/Excahnge_Rate.png" 
                    ToolTip="<%$ Resources:TimeLive.Resource, Change Base Currency %>" 
                    onclick= "window.open (this.href, 'popupwindow', 'width=425,height=170,left=500,top=300'); return false;" 
                    NavigateUrl='~/AccountAdmin/AccountBaseCurrency.aspx' ></asp:HyperLink></td></tr></table></div><asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <x:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="AccountCurrencyId"
            DataSourceID="dsAccountCurrencyGridViewObject" SkinID="xgridviewSkinEmployee" Caption='<%# ResourceHelper.GetFromResource("Currencies List") %>' Width="98%">
            <Columns>
                <asp:BoundField DataField="AccountCurrencyId" HeaderText="<%$ Resources:TimeLive.Resource, Id %>" ReadOnly="True"
                    SortExpression="AccountCurrencyId" >
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Name %>" SortExpression="Currency">
                    <edititemtemplate>
<asp:TextBox id="TextBox1" runat="server" Text='<%# Bind("Currency") %>' __designer:wfdid="w213"></asp:TextBox></edititemtemplate><headertemplate>
<asp:LinkButton id="LinkButton3" runat="server" Text='<%# ResourceHelper.GetFromResource("Name") %>' CommandArgument="Currency" CommandName="Sort" CausesValidation="False"></asp:LinkButton></headertemplate><itemtemplate>
<asp:Label id="Label2" runat="server" Text='<%# Bind("Currency") %>' __designer:wfdid="w212"></asp:Label></itemtemplate><itemstyle width="72%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Symbol %>" SortExpression="CurrencyCode">
                    <edititemtemplate>
<asp:TextBox id="TextBox2" runat="server" Text='<%# Bind("CurrencyCode") %>' __designer:wfdid="w216"></asp:TextBox></edititemtemplate><headertemplate>
<asp:LinkButton id="LinkButton4" runat="server" Text='<%# ResourceHelper.GetFromResource("Symbol") %>' CommandArgument="CurrencyCode" CommandName="Sort" CausesValidation="False"></asp:LinkButton></headertemplate><itemtemplate>
<asp:Label id="Label3" runat="server" Text='<%# Bind("CurrencyCode") %>' __designer:wfdid="w215"></asp:Label></itemtemplate><itemstyle width="5%" HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Exchange Rate %>" SortExpression="ExchangeRate">
                    <headertemplate>
<asp:Label id="lblExchangeRate" runat="server" Text='<%# ResourceHelper.GetFromResource("Exchange Rate") %>' __designer:wfdid="w219"></asp:Label></headertemplate><ItemTemplate>
<asp:Label id="Label1" runat="server" Text='<%# Bind("ExchangeRate", "{0:N4}") %>' __designer:wfdid="w218"></asp:Label></ItemTemplate><ItemStyle 
                        Width="9%" HorizontalAlign="Right" /></asp:TemplateField>
                <asp:CommandField HeaderText="<%$ Resources:TimeLive.Resource, Edit_Text %>" SelectText="Edit" ShowSelectButton="True" >
                    <HeaderStyle />                    
                    <ItemStyle cssclass="edit_button" Width="1%" HorizontalAlign="Center" 
                        VerticalAlign="Middle" />                    
                </asp:CommandField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Delete_text %>">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton2" runat="server" CommandName="Delete" Tooltip="<%$ Resources:TimeLive.Resource, Delete_text%> " OnClientClick='<%# ResourceHelper.GetDeleteMessageJavascript()%>'>Delete</asp:LinkButton></ItemTemplate><ItemStyle Width="1%" cssclass="delete_button" HorizontalAlign="Center"   />
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/Disabled.gif" ToolTip="<%$ Resources:TimeLive.Resource, Disabled_text%> " />
                    
</HeaderTemplate>
                    <ItemTemplate>
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/Disabled.gif" ToolTip="<%$ Resources:TimeLive.Resource, Disabled_text%> "
                            Visible='<%# IIF(IsDBNull(Eval("Disabled")),"false",Eval("Disabled")) %>' />
                    
</ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="1%" />
                </asp:TemplateField>
<asp:TemplateField><ItemTemplate>
<asp:HyperLink id="HyperLink1" runat="server" NavigateUrl='<%# Eval("AccountCurrencyId", "~/AccountAdmin/AccountCurrencyExchangeRate.aspx?AccountCurrencyId={0}") %>' Text="History" ></asp:HyperLink></ItemTemplate><ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
</asp:TemplateField>
            </Columns>
        </x:GridView>
        <asp:ObjectDataSource ID="dsAccountCurrencyGridViewObject" runat="server" DeleteMethod="DeleteAccountCurrency"
            InsertMethod="AddAccountCurrency" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetvueAccountCurrencyByAccountId" TypeName="AccountCurrencyBLL" UpdateMethod="UpdateAccountCurrency">
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
            <InsertParameters>
                <asp:Parameter Name="SystemCurrencyId" Type="Int32" />
                <asp:Parameter Name="AccountId" Type="Int32" />
                <asp:Parameter Name="AccountCurrencyExchangeRateId" Type="Int32" />
                <asp:Parameter Name="Disabled" Type="Boolean" />
            </InsertParameters>
            <SelectParameters>
                <asp:SessionParameter DefaultValue="23" Name="AccountId" SessionField="AccountId"
                    Type="Int32" />
                <asp:Parameter Name="NotFixTable" Type="Boolean" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="dsAccountCurrencyFormViewObject" runat="server" DeleteMethod="DeleteAccountCurrency"
            InsertMethod="AddAccountCurrency" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetAccountCurrencyByAccountCurrencyId" TypeName="AccountCurrencyBLL"
            UpdateMethod="UpdateAccountCurrency">
            <DeleteParameters>
                <asp:Parameter Name="Original_AccountCurrencyId" Type="Int32" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="SystemCurrencyId" Type="Int32" />
                <asp:Parameter Name="Original_AccountCurrencyId" Type="Int32" />
                <asp:Parameter Name="AccountCurrencyExchangeRateId" Type="Int32" />
                <asp:SessionParameter DefaultValue="151" Name="AccountId" SessionField="AccountId"
                    Type="Int32" />
                <asp:Parameter Name="Disabled" Type="Boolean" />
            </UpdateParameters>
            <SelectParameters>
                <asp:ControlParameter ControlID="GridView1" Name="AccountCurrencyId" PropertyName="SelectedValue"
                    Type="Int32" />
            </SelectParameters>
            <InsertParameters>
                <asp:Parameter Name="SystemCurrencyId" Type="Int32" />
                <asp:SessionParameter DefaultValue="23" Name="AccountId" SessionField="AccountId"
                    Type="Int32" />
                <asp:Parameter Name="AccountCurrencyExchangeRateId" Type="Int32" />
                <asp:Parameter Name="Disabled" Type="Boolean" />
            </InsertParameters>
        </asp:ObjectDataSource>
    </ContentTemplate>
</asp:UpdatePanel>
<br />
<asp:UpdatePanel ID="UpdatePanel2" runat="server">
    <ContentTemplate>
        <asp:FormView ID="FormView1" runat="server" 
            DataKeyNames="AccountCurrencyId" DataSourceID="dsAccountCurrencyFormViewObject"
            DefaultMode="Insert" SkinID="formviewSkinEmployee" Width="450px" 
            style="margin-right: 0px"><EditItemTemplate>
                <table width="450" class="xview">
                    <tr>
                        <th colspan="2" class="caption">
                            <asp:Literal ID="Literal3" runat="server" Text='<%# ResourceHelper.GetFromResource("Currencies Information")%> ' /></th>
                    </tr>
                    <tr>
                        <th colspan="2" class="FormViewSubHeader">
                            <asp:Literal ID="Literal1" runat="server" Text='<%# ResourceHelper.GetFromResource("Currencies")%> ' /></th>
                    </tr>
                    <tr>
                        <td style="width: 35%" align="right" class="FormViewLabelCell">
                             <SPAN 
                  class=reqasterisk>*</SPAN><asp:Literal ID="Literal2" runat="server" Text='<%# ResourceHelper.GetFromResource("Name:")%> ' /></td>
                        <td style="width: 65%">
                            <asp:DropDownList ID="NameDropDownList" runat="server" DataSourceID="dsCurrenciesObject"
                                DataTextField="CurrencyWithCode" DataValueField="CurrencyId" SelectedValue='<%# Bind("SystemCurrencyId") %>'
                                Width="220px">
                            </asp:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                ControlToValidate="NameDropDownList" CssClass="ErrorMessage" Display="Dynamic"
                                ErrorMessage="*"></asp:RequiredFieldValidator></td></tr><tr>
                        <td style="width: 35%" align="right" class="FormViewLabelCell">
                             <SPAN 
                  class=reqasterisk>*</SPAN><asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="ExchangeRateTextBox"><asp:Literal ID="Literal4" runat="server" Text='<%# ResourceHelper.GetFromResource("Exchange Rate:")%> ' /></asp:Label></td><td style="width: 65%">
                            <asp:TextBox 
                                ID="ExchangeRateTextBox" runat="server" style="text-align:right;" Width="80px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                                    runat="server" ControlToValidate="ExchangeRateTextBox" CssClass="ErrorMessage"
                                    Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator><asp:RangeValidator
                                        ID="RangeValidator1" runat="server" ControlToValidate="ExchangeRateTextBox" CssClass="ErrorMessage"
                                        Display="Dynamic" ErrorMessage="Numeric Required" MaximumValue="500000" MinimumValue="0"
                                        Type="Double"></asp:RangeValidator><asp:CustomValidator
                                ID="NetAmountCustomValidatorEdit" runat="server" CssClass="ErrorMessage" Display="Dynamic"
                                ErrorMessage="Value must be > 0" OnServerValidate="NetAmountCustomValidatorEdit_ServerValidate" ></asp:CustomValidator>&nbsp;</td></tr><tr>
                        <td style="width: 35%" align="right" class="FormViewLabelCell">
                            Is Disabled: </td><td style="width: 65%">
                            <asp:CheckBox ID="DisabledCheckBox" runat="server" Checked='<%# Bind("Disabled") %>' /></td>
                    </tr>
                    <tr>
                        <td style="width: 35%" align="right">
                        </td>
                        <td style="width: 65%; padding-bottom: 5px;">
                            <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="<%$ Resources:TimeLive.Resource, Update_Text%> " Width="68px" />&nbsp;<asp:Button
                                ID="CancelButton" runat="server" CommandName="Cancel" Text="<%$ Resources:TimeLive.Resource, Cancel_Text%> " Width="68px" />
                            <asp:Label ID="lblExceptionText" runat="server" CssClass="ErrorMessage" Text="Currency Already Exist"
                                Visible="False"></asp:Label></td></tr></table></EditItemTemplate><InsertItemTemplate>
                <table width="100%" class="xview">
                    <tr>
                        <th class="caption" colspan="2">
                            <asp:Literal ID="Literal5" runat="server" Text='<%# ResourceHelper.GetFromResource("Currencies Information")%> ' /></th>
                    </tr>
                    <tr>
                        <th class="FormViewSubHeader" colspan="2">
                            <asp:Literal ID="Literal6" runat="server" Text='<%# ResourceHelper.GetFromResource("Currencies")%> ' /></th>
                    </tr>
                    <tr>
                        <td class="FormViewLabelCell" style="width: 35%" align="right">
                             <SPAN 
                  class=reqasterisk>*</SPAN><asp:Literal ID="Literal7" runat="server" Text='<%# ResourceHelper.GetFromResource("Name:")%> ' /></td>
                        <td style="width: 65%">
                            <asp:DropDownList ID="NameDropDownList" runat="server" DataSourceID="dsCurrenciesObject"
                                DataTextField="CurrencyWithCode" DataValueField="CurrencyId"
                                Width="220px" SelectedValue='<%# Bind("SystemCurrencyId") %>'>
                            </asp:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                ControlToValidate="NameDropDownList" CssClass="ErrorMessage" Display="Dynamic"
                                ErrorMessage="*"></asp:RequiredFieldValidator></td></tr><tr>
                        <td class="FormViewLabelCell" style="width: 35%" align="right">
                             <SPAN 
                  class=reqasterisk>*</SPAN><asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="ExchangeRateTextBox"><asp:Literal ID="Literal8" runat="server" Text='<%# ResourceHelper.GetFromResource("Exchange Rate:")%> ' /></asp:Label></td><td style="width: 65%">
                            <asp:TextBox 
                                ID="ExchangeRateTextBox" runat="server" style="text-align:right;" Width="80px"></asp:TextBox><asp:RequiredFieldValidator
                                ID="RequiredFieldValidator1" runat="server" ControlToValidate="ExchangeRateTextBox"
                                CssClass="ErrorMessage" Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="ExchangeRateTextBox"
                                CssClass="ErrorMessage" Display="Dynamic" ErrorMessage="Numeric Required" MaximumValue="500000"
                                MinimumValue="0" Type="Double"></asp:RangeValidator><asp:CustomValidator
                                ID="NetAmountCustomValidator" runat="server" CssClass="ErrorMessage" Display="Dynamic"
                                ErrorMessage="Value must be > 0" OnServerValidate="NetAmountCustomValidator_ServerValidate" ></asp:CustomValidator></td></tr><tr>
                        <td class="FormViewLabelCell" style="width: 35%;" align="right">
                        </td>
                        <td style="width: 65%; padding-bottom: 5px;">
                            <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="<%$ Resources:TimeLive.Resource, Add_text%> " Width="68px" />
                            <asp:Label ID="lblExceptionText" runat="server" CssClass="ErrorMessage" Text="Currency Already Exist"
                                Visible="False"></asp:Label></td></tr></table></InsertItemTemplate><ItemTemplate>
                AccountCurrencyId: <asp:Label ID="AccountCurrencyIdLabel" runat="server" Text='<%# Eval("AccountCurrencyId") %>'>
                </asp:Label><br />SystemCurrencyId: <asp:Label ID="SystemCurrencyIdLabel" runat="server" Text='<%# Bind("SystemCurrencyId") %>'>
                </asp:Label><br />Disabled: <asp:CheckBox ID="DisabledCheckBox" runat="server" Checked='<%# Bind("Disabled") %>'
                    Enabled="false" /><br />
                <asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" CommandName="Edit"
                    Text="Edit">
                </asp:LinkButton><asp:LinkButton ID="DeleteButton" runat="server" CausesValidation="False" CommandName="Delete"
                    Text="Delete">
                </asp:LinkButton><asp:LinkButton ID="NewButton" runat="server" CausesValidation="False" CommandName="New"
                    Text="New">
                </asp:LinkButton></ItemTemplate></asp:FormView><asp:ObjectDataSource ID="dsCurrenciesObject" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetCurrenciesWithCode" TypeName="SystemDataBLL"></asp:ObjectDataSource>
    </ContentTemplate>
</asp:UpdatePanel>
