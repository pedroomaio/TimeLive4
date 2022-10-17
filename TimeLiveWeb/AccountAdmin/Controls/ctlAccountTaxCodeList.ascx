<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlAccountTaxCodeList.ascx.vb" Inherits="AccountAdmin_Controls_ctlAccountTaxCodeList" %>
<%@ Register Assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2"
    Namespace="eWorld.UI" TagPrefix="ew" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    <div class="fieldset" style="width: 96%; margin-left: 6px;" align="left"> 
<table class="xFormView" width="98%">
<tr>
<td width="50px">
            <asp:Label ID="Label15" runat="server" Text="<%$ Resources:TimeLive.Resource, Tax Zone: %>"
            Font-Bold="True" Font-Size="11px" Width="55px" CssClass="HighlightedText" 
                Height="15px" />
                </td>
<td>
<asp:DropDownList ID="ddlTaxZone" runat="server" DataSourceID="dsAccountTaxZoneObject"
                DataTextField="AccountTaxZone" DataValueField="AccountTaxZoneId" Width="150px" AutoPostBack="True">
</asp:DropDownList>
</td>
</tr>
</table>
</div>
<asp:ObjectDataSource ID="dsAccountTaxZoneObject" runat="server" OldValuesParameterFormatString="original_{0}"
    SelectMethod="GetAccountTaxZonesByAccountIdAndIsDisabled" TypeName="AccountTaxZoneBLL">
    <SelectParameters>
        <asp:SessionParameter DefaultValue="22" Name="AccountId" SessionField="AccountId"
            Type="Int32" />
        <asp:Parameter Name="AccountTaxZoneId" Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>
        <x:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="AccountTaxCodeId"
            DataSourceID="dsAccountTaxCodeGridViewObject" Width="98%" Caption='<%# ResourceHelper.GetFromResource("Tax Code") %>' SkinID="xgridviewSkinEmployee">
            <Columns>
                <asp:TemplateField InsertVisible="False" SortExpression="AccountTaxCodeId" HeaderText="<%$ Resources:TimeLive.Resource, Id %>">
                    <edititemtemplate>
<asp:Label id="Label1" runat="server" Text='<%# Eval("AccountTaxCodeId") %>' __designer:wfdid="w221"></asp:Label> 
</edititemtemplate>
                    <headertemplate>
<asp:LinkButton id="LinkButton3" runat="server" Text='<%# ResourceHelper.GetFromResource("Id") %>' CommandArgument="AccountTaxCodeId" CommandName="Sort" CausesValidation="False"></asp:LinkButton>
</headertemplate>
                    <itemtemplate>
<asp:Label id="Label1" runat="server" Text='<%# Bind("AccountTaxCodeId") %>' __designer:wfdid="w220"></asp:Label> 
</itemtemplate>
                    <itemstyle horizontalalign="Center" verticalalign="Middle" width="5%" />
                </asp:TemplateField>
                <asp:TemplateField SortExpression="TaxCode" HeaderText="<%$ Resources:TimeLive.Resource, Tax Code %>">
                    <edititemtemplate>
<asp:TextBox id="TextBox1" runat="server" Text='<%# Bind("TaxCode") %>' __designer:wfdid="w224"></asp:TextBox> 
</edititemtemplate>
                    <headertemplate>
<asp:LinkButton id="LinkButton4" runat="server" Text='<%# ResourceHelper.GetFromResource("Tax Code") %>' CommandArgument="TaxCode" CommandName="Sort" CausesValidation="False"></asp:LinkButton>
</headertemplate>
                    <itemtemplate>
<asp:Label id="Label2" runat="server" Text='<%# Bind("TaxCode") %>' __designer:wfdid="w223"></asp:Label> 
</itemtemplate>
                    <itemstyle width="75%" />
                </asp:TemplateField>
                <asp:TemplateField SortExpression="Formula" HeaderText="<%$ Resources:TimeLive.Resource, Formula %>">
                    <edititemtemplate>
<asp:TextBox id="TextBox2" runat="server" Text='<%# Bind("Formula") %>' __designer:wfdid="w227"></asp:TextBox> 
</edititemtemplate>
                    <headertemplate>
<asp:Label id="lblFormula" runat="server" Text='<%# ResourceHelper.GetFromResource("Formula") %>' __designer:wfdid="w228"></asp:Label>
</headertemplate>
                    <itemtemplate>
<asp:Label id="Label3" runat="server" Text='<%# Bind("Formula") %>' __designer:wfdid="w226"></asp:Label> 
</itemtemplate>
                    <itemstyle width="15%" />
                </asp:TemplateField>
                <asp:CommandField HeaderText="<%$ Resources:TimeLive.Resource, Edit_text %>" SelectText="Edit" ShowSelectButton="True">
                    <ItemStyle Width="1%" cssclass="edit_button" HorizontalAlign="Center" />
                </asp:CommandField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Delete_text %>" ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete"
                            OnClientClick='<%# ResourceHelper.GetDeleteMessageJavascript()%>'
                            Text="Delete"></asp:LinkButton>
                    
</ItemTemplate>
                    <ItemStyle Width="1%" cssclass="delete_button" HorizontalAlign="Center" VerticalAlign="Bottom" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Disabled_text %>">
                    <HeaderTemplate>
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/Disabled.gif" ToolTip="<%$ Resources:TimeLive.Resource, Disabled_text%> " />
                    
</HeaderTemplate>
                    <ItemTemplate>
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/Disabled.gif" ToolTip="<%$ Resources:TimeLive.Resource, Disabled_text%> " Visible='<%# IIF(IsDBNull(Eval("IsDisabled")),"False",Eval("IsDisabled")) %>' />
                    
</ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="1%" />
                </asp:TemplateField>
            </Columns>
        </x:GridView>
        <asp:ObjectDataSource ID="dsAccountTaxCodeGridViewObject" runat="server" DeleteMethod="DeleteAccountTaxCode"
            InsertMethod="AddAccountTaxCode" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetAccountTaxCodesByAccountIdAndAccountTaxZoneId" TypeName="AccountTaxCodeBLL" UpdateMethod="UpdateAccountTaxCode">
            <DeleteParameters>
                <asp:Parameter Name="Original_AccountTaxCodeId" Type="Int32" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="AccountId" Type="Int32" />
                <asp:Parameter Name="TaxCode" Type="String" />
                <asp:Parameter Name="Formula" Type="String" />
                <asp:Parameter Name="Original_AccountTaxCodeId" Type="Int32" />
                <asp:Parameter Name="IsDisabled" Type="Boolean" />
            </UpdateParameters>
            <SelectParameters>
                <asp:SessionParameter DefaultValue="151" Name="AccountId" SessionField="AccountId"
                    Type="Int32" />
                <asp:Parameter DefaultValue="" Name="AccountTaxZoneId" Type="Int32" />
            </SelectParameters>
            <InsertParameters>
                <asp:Parameter Name="AccountId" Type="Int32" />
                <asp:Parameter Name="TaxCode" Type="String" />
                <asp:Parameter Name="Formula" Type="String" />
                <asp:Parameter Name="AccountTaxZoneId" Type="Int32" />
            </InsertParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="dsAccountTaxCodeFormViewObject" runat="server" DeleteMethod="DeleteAccountTaxCode"
            InsertMethod="AddAccountTaxCode" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetAccountTaxCodesByAccountTaxCodeId" TypeName="AccountTaxCodeBLL"
            UpdateMethod="UpdateAccountTaxCode">
            <DeleteParameters>
                <asp:Parameter Name="Original_AccountTaxCodeId" Type="Int32" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:SessionParameter DefaultValue="151" Name="AccountId" SessionField="AccountId"
                    Type="Int32" />
                <asp:Parameter Name="TaxCode" Type="String" />
                <asp:Parameter Name="Formula" Type="String" />
                <asp:Parameter Name="Original_AccountTaxCodeId" Type="Int32" />
                <asp:Parameter Name="IsDisabled" Type="Boolean" />
            </UpdateParameters>
            <SelectParameters>
                <asp:ControlParameter ControlID="GridView1" Name="AccountTaxCodeId" PropertyName="SelectedValue"
                    Type="Int32" />
            </SelectParameters>
            <InsertParameters>
                <asp:SessionParameter DefaultValue="123" Name="AccountId" SessionField="AccountId"
                    Type="Int32" />
                <asp:Parameter Name="TaxCode" Type="String" />
                <asp:Parameter Name="Formula" Type="String" />
                <asp:Parameter Name="AccountTaxZoneId" Type="Int32" />
            </InsertParameters>
        </asp:ObjectDataSource>
    </ContentTemplate>
</asp:UpdatePanel>
<br />
<asp:UpdatePanel ID="UpdatePanel2" runat="server">
    <ContentTemplate>
        <asp:FormView ID="FormView1" runat="server" DataKeyNames="AccountTaxCodeId" DataSourceID="dsAccountTaxCodeFormViewObject"
            DefaultMode="Insert" Width="500px" SkinID="formviewSkinEmployee">
            <EditItemTemplate><table width="500" class="xview">
                <tr>
                    <th colspan="2" class="caption">
                        <asp:Literal ID="Literal5" runat="server" Text='<%# ResourceHelper.GetFromResource("Tax Code Information")%> ' />
                </tr>
                <tr>
                    <th colspan="2" style="height: 21px" class="FormViewSubHeader">
                    <asp:Literal ID="Literal1" runat="server" Text='<%# ResourceHelper.GetFromResource("Tax Code")%> ' />
                </tr>
                <tr>
                    <td style="width: 35%" align="right" class="FormViewLabelCell">
                        <SPAN 
                  class=reqasterisk>*</SPAN> 
                  
<asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="TaxCodeTextBox">
                  <asp:Literal ID="Literal2" runat="server" Text='<%# ResourceHelper.GetFromResource("Tax Code:")%> ' /></asp:Label></td><td style="width: 68%">
                        <asp:TextBox 
                            ID="TaxCodeTextBox" runat="server" Text='<%# Bind("TaxCode") %>' Width="176px"></asp:TextBox><ew:requiredfieldvalidator
                            id="RequiredFieldValidator1" runat="server" controltovalidate="TaxCodeTextBox"
                            cssclass="ErrorMessage" display="Dynamic" errormessage="*"></ew:requiredfieldvalidator></td></tr><tr>
                    <td style="width: 35%; height: 26px;" align="right" class="FormViewLabelCell">
                        <SPAN 
                  class=reqasterisk>*</SPAN><asp:Label ID="Label4" runat="server" AssociatedControlID="FormulaTextBox">
                  <asp:Literal ID="Literal3" runat="server" Text='<%# ResourceHelper.GetFromResource("Formula:")%> ' /></asp:Label></td><td style="width: 68%; height: 26px;">
                        <asp:TextBox 
                            ID="FormulaTextBox" runat="server" Text='<%# Bind("Formula") %>' Width="176px"></asp:TextBox><ew:requiredfieldvalidator
                            id="RequiredFieldValidator2" runat="server" controltovalidate="FormulaTextBox"
                            cssclass="ErrorMessage" display="Dynamic" errormessage="*"></ew:requiredfieldvalidator></td></tr><tr>
                    <td align="right" class="FormViewLabelCell" style="width: 35%">
                        <asp:Literal ID="Literal4" runat="server" Text='<%# ResourceHelper.GetFromResource("Disabled:")%> ' /></td>
                    <td style="width: 68%">
                        <asp:CheckBox ID="CheckBox1" runat="server" Checked='<%# Bind("IsDisabled") %>' /></td>
                </tr>
                <tr>
                    <td style="width: 35%; height: 26px;" align="right" class="FormViewLabelCell">
                    </td>
                    <td style="width: 68%; height: 26px; padding-bottom: 5px;">
                        <asp:Button ID="btnUpdate" runat="server" CommandName="Update" Text="<%$ Resources:TimeLive.Resource, Update_text%> " Width="68px" />&nbsp<asp:Button ID="btnCancel" runat="server" CommandName="Cancel" Text="<%$ Resources:TimeLive.Resource, Cancel_text%> " Width="68px" ValidationGroup="I" /><asp:Label
                            ID="lblExceptionText" runat="server" CssClass="ErrorMessage" ForeColor="Red"
                            Text="Label" Visible="False"></asp:Label></td></tr></table></EditItemTemplate><InsertItemTemplate>
                <table width="500" class="xview">
                    <tr>
                        <th colspan="2" class="caption">
                            <asp:Literal ID="Literal4" runat="server" Text='<%# ResourceHelper.GetFromResource("Tax Code Information")%> ' /></th>
                    </tr>
                    <tr>
                        <th colspan="2" style="height: 21px" class="FormViewSubHeader">
                            <asp:Literal ID="Literal6" runat="server" Text='<%# ResourceHelper.GetFromResource("Tax Code")%> ' /></th>
                    </tr>
                    <tr>
                        <td style="width: 35%" align="right" class="FormViewLabelCell">
                            <SPAN 
                  class=reqasterisk>*</SPAN><asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="TaxCodeTextBox">
                  <asp:Literal ID="Literal7" runat="server" Text='<%# ResourceHelper.GetFromResource("Tax Code:")%> ' /></asp:Label></td><td style="width: 65%">
                            <asp:TextBox 
                                ID="TaxCodeTextBox" runat="server" Text='<%# Bind("TaxCode") %>' Width="176px"></asp:TextBox><ew:requiredfieldvalidator
                                id="RequiredFieldValidator1" runat="server" controltovalidate="TaxCodeTextBox"
                                cssclass="ErrorMessage" display="Dynamic" errormessage="*"></ew:requiredfieldvalidator></td></tr><tr>
                        <td style="width: 35%" align="right" class="FormViewLabelCell">
                            <SPAN 
                  class=reqasterisk>*</SPAN><asp:Label ID="Label5" runat="server" AssociatedControlID="FormulaTextBox">
                  <asp:Literal ID="Literal8" runat="server" Text='<%# ResourceHelper.GetFromResource("Formula:")%> ' /></asp:Label></td><td style="width: 65%">
                            <asp:TextBox 
                                ID="FormulaTextBox" runat="server" Text='<%# Bind("Formula") %>' Width="176px"></asp:TextBox><ew:requiredfieldvalidator
                                id="RequiredFieldValidator3" runat="server" controltovalidate="FormulaTextBox"
                                cssclass="ErrorMessage" display="Dynamic" errormessage="*"></ew:requiredfieldvalidator></td></tr><tr>
                        <td style="width: 35%" align="right" class="FormViewLabelCell">
                        </td>
                        <td style="width: 65%; padding-bottom: 5px;">
                            <asp:Button ID="btnAdd" runat="server" CommandName="Insert" Text="<%$ Resources:TimeLive.Resource, Add_text%> " Width="68px" /><asp:Label
                                ID="lblExceptionText" runat="server" CssClass="ErrorMessage" ForeColor="Red"
                                Text="Label" Visible="False"></asp:Label></td></tr></table></InsertItemTemplate><ItemTemplate>
                AccountTaxCodeId: <asp:Label ID="AccountTaxCodeIdLabel" runat="server" Text='<%# Eval("AccountTaxCodeId") %>'>
                </asp:Label><br />AccountId: <asp:Label ID="AccountIdLabel" runat="server" Text='<%# Bind("AccountId") %>'></asp:Label><br />TaxCode: <asp:Label ID="TaxCodeLabel" runat="server" Text='<%# Bind("TaxCode") %>'></asp:Label><br />Formula: <asp:Label ID="FormulaLabel" runat="server" Text='<%# Bind("Formula") %>'></asp:Label><br />IsDisabled: <asp:CheckBox ID="IsDisabledCheckBox" runat="server" Checked='<%# Bind("IsDisabled") %>'
                    Enabled="false" /><br />
                <asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" CommandName="Edit"
                    Text="Edit">
                </asp:LinkButton><asp:LinkButton ID="DeleteButton" runat="server" CausesValidation="False" CommandName="Delete"
                    Text="Delete">
                </asp:LinkButton><asp:LinkButton ID="NewButton" runat="server" CausesValidation="False" CommandName="New"
                    Text="New">
                </asp:LinkButton></ItemTemplate></asp:FormView></ContentTemplate></asp:UpdatePanel>