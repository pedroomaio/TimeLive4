<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlAccountPaymentMethodList.ascx.vb" Inherits="AccountAdmin_Controls_ctlAccountPaymentMethodList" %>
<%@ Register Assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2"
    Namespace="eWorld.UI" TagPrefix="ew" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <x:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Caption='<%# ResourceHelper.GetFromResource("Payment Method") %>' DataKeyNames="AccountPaymentMethodId" DataSourceID="dsAccountPaymentMethodGridViewObject" SkinID="xgridviewSkinEmployee" Width="98%">
            <Columns>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Id %>" InsertVisible="False" SortExpression="AccountPaymentMethodId">
                    <edititemtemplate>
<asp:Label id="Label1" runat="server" Text='<%# Eval("AccountPaymentMethodId") %>' __designer:wfdid="w230"></asp:Label>
</edititemtemplate>
                    <headertemplate>
<asp:LinkButton id="LinkButton3" runat="server" Text='<%# ResourceHelper.GetFromResource("Id") %>' CommandArgument="AccountPaymentMethodId" CommandName="Sort" CausesValidation="False"></asp:LinkButton>
</headertemplate>
                    <itemtemplate>
<asp:Label id="Label1" runat="server" Text='<%# Bind("AccountPaymentMethodId") %>' __designer:wfdid="w229"></asp:Label>
</itemtemplate>
                    <itemstyle horizontalalign="Center" verticalalign="Middle" width="5%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Payment Method %>" SortExpression="PaymentMethod">
                    <edititemtemplate>
<asp:TextBox id="TextBox1" runat="server" Text='<%# Bind("PaymentMethod") %>' __designer:wfdid="w233"></asp:TextBox>
</edititemtemplate>
                    <headertemplate>
<asp:LinkButton id="LinkButton4" runat="server" Text='<%# ResourceHelper.GetFromResource("Payment Method") %>' CommandArgument="PaymentMethod" CommandName="Sort" CausesValidation="False"></asp:LinkButton>
</headertemplate>
                    <itemtemplate>
<asp:Label id="Label2" runat="server" Text='<%# Bind("PaymentMethod") %>' __designer:wfdid="w232"></asp:Label>
</itemtemplate>
                    <itemstyle width="90%" />
                </asp:TemplateField>
                <asp:CommandField HeaderText="<%$ Resources:TimeLive.Resource, Edit_text %>" SelectText="Edit" ShowSelectButton="True">
                    <ItemStyle Width="1%" cssclass="edit_button" HorizontalAlign="Center" 
                    VerticalAlign="Middle" />
                </asp:CommandField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Delete_text %>" ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete"
                            OnClientClick='<%# ResourceHelper.GetDeleteMessageJavascript()%>'
                            Text="Delete"></asp:LinkButton>
                    
</ItemTemplate>
                    <ItemStyle Width="1%" cssclass="delete_button" HorizontalAlign="Center" 
                        VerticalAlign="Middle" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Disabled">
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
        <asp:ObjectDataSource ID="dsAccountPaymentMethodGridViewObject" runat="server" DeleteMethod="DeleteAccountPaymentMethod"
            InsertMethod="AddAccountPaymentMethod" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetAccountPaymentMethodByAccountId" TypeName="AccountPaymentMethodBLL" UpdateMethod="UpdateAccountPaymentMethod">
            <DeleteParameters>
                <asp:Parameter Name="Original_AccountPaymentMethodId" Type="Int32" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="AccountId" Type="Int32" />
                <asp:Parameter Name="PaymentMethod" Type="String" />
                <asp:Parameter Name="Original_AccountPaymentMethodId" Type="Int32" />
                <asp:Parameter Name="IsDisabled" Type="Boolean" />
            </UpdateParameters>
            <InsertParameters>
                <asp:Parameter Name="AccountId" Type="Int32" />
                <asp:Parameter Name="PaymentMethod" Type="String" />
                <asp:Parameter Name="IsDisabled" Type="Boolean" />
            </InsertParameters>
            <SelectParameters>
                <asp:SessionParameter DefaultValue="21" Name="AccountId" SessionField="AccountId"
                    Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="dsAccountPaymentMethodFormViewObject" runat="server" DeleteMethod="DeleteAccountPaymentMethod"
            InsertMethod="AddAccountPaymentMethod" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetAccountPaymentMethodByAccountPaymentMethodId" TypeName="AccountPaymentMethodBLL"
            UpdateMethod="UpdateAccountPaymentMethod">
            <DeleteParameters>
                <asp:Parameter Name="Original_AccountPaymentMethodId" Type="Int32" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:SessionParameter DefaultValue="151" Name="AccountId" SessionField="AccountId"
                    Type="Int32" />
                <asp:Parameter Name="PaymentMethod" Type="String" />
                <asp:Parameter Name="Original_AccountPaymentMethodId" Type="Int32" />
                <asp:Parameter Name="IsDisabled" Type="Boolean" />
            </UpdateParameters>
            <SelectParameters>
                <asp:ControlParameter ControlID="GridView1" Name="AccountPaymentMethodId" PropertyName="SelectedValue"
                    Type="Int32" />
            </SelectParameters>
            <InsertParameters>
                <asp:SessionParameter DefaultValue="151" Name="AccountId" SessionField="AccountId"
                    Type="Int32" />
                <asp:Parameter Name="PaymentMethod" Type="String" />
                <asp:Parameter Name="IsDisabled" Type="Boolean" />
            </InsertParameters>
        </asp:ObjectDataSource>
    </ContentTemplate>
</asp:UpdatePanel>
<br />
<asp:UpdatePanel ID="UpdatePanel2" runat="server">
    <ContentTemplate>
        <asp:FormView ID="FormView1" runat="server" DefaultMode="Insert" DataKeyNames="AccountPaymentMethodId" DataSourceID="dsAccountPaymentMethodFormViewObject" SkinID="formviewSkinEmployee" Width="450px">
            <EditItemTemplate>
                <table width="450" class="xview">
                    <tr>
                        <th class="caption" colspan="2">
                            <asp:Literal ID="Literal1" runat="server" Text='<%# ResourceHelper.GetFromResource("Payment Method Information")%> ' /></th>
                    </tr>
                    <tr>
                        <th class="FormViewSubHeader" colspan="2">
                            <asp:Literal ID="Literal2" runat="server" Text='<%# ResourceHelper.GetFromResource("Payment Method")%> ' /></th>
                    </tr>
                    <tr>
                        <td align="right" class="FormViewLabelCell" style="width: 35%">
                            <SPAN 
                  class=reqasterisk>*</SPAN> 
                  
<asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="PaymentMethodTextBox">
                  <asp:Literal ID="Literal3" runat="server" Text='<%# ResourceHelper.GetFromResource("Payment Method:")%> ' /></asp:Label></td><td style="width: 65%">
                            <asp:TextBox 
                                ID="PaymentMethodTextBox" runat="server" Text='<%# Bind("PaymentMethod") %>' 
                                Width="176px"></asp:TextBox><ew:requiredfieldvalidator
                                id="RequiredFieldValidator1" runat="server" controltovalidate="PaymentMethodTextBox"
                                cssclass="ErrorMessage" display="Dynamic" errormessage="*" ValidationGroup="I"></ew:requiredfieldvalidator></td></tr><tr>
                        <td align="right" class="FormViewLabelCell" style="width: 35%">
                            <asp:Literal ID="Literal4" runat="server" Text='<%# ResourceHelper.GetFromResource("Disabled:")%> ' /></td>
                        <td style="width: 65%">
                            <asp:CheckBox ID="chkIsDisabled" runat="server" Checked='<%# Bind("IsDisabled") %>' /></td>
                    </tr>
                    <tr>
                        <td align="right" class="FormViewLabelCell" style="width: 35%">
                        </td>
                        <td style="width: 65%; padding-bottom: 5px;">
                            <asp:Button ID="btnUpdate" runat="server" CommandName="Update" Text="<%$ Resources:TimeLive.Resource, Update_text%>" Width="68px" />&nbsp <asp:Button ID="btnCancel" runat="server" CommandName="Cancel" Text="<%$ Resources:TimeLive.Resource, Cancel_text%>" Width="68px" />
                            <asp:Label ID="lblExceptionText" runat="server" CssClass="ErrorMessage" ForeColor="Red" Text="Label" Visible="False"></asp:Label></td></tr></table></EditItemTemplate><InsertItemTemplate>
                <table width="450" class="xview">
                    <tr>
                        <th colspan="2" class="caption">
                            <asp:Literal ID="Literal2" runat="server" Text='<%# ResourceHelper.GetFromResource("Payment Method Information")%> ' /></th>
                    </tr>
                    <tr>
                        <th colspan="2" class="FormViewSubHeader">
                            <asp:Literal ID="Literal5" runat="server" Text='<%# ResourceHelper.GetFromResource("Payment Method")%> ' /></th>
                    </tr>
                    <tr>
                        <td align="right" class="FormViewLabelCell" style="width: 35%">
                            <SPAN 
                  class=reqasterisk>*</SPAN><asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="PaymentMethodTextBox">
                  <asp:Literal ID="Literal6" runat="server" Text='<%# ResourceHelper.GetFromResource("Payment Method:")%> ' /></asp:Label></td><td style="width: 65%">
                            <asp:TextBox 
                                ID="PaymentMethodTextBox" runat="server" Text='<%# Bind("PaymentMethod") %>' 
                                Width="176px"></asp:TextBox><ew:requiredfieldvalidator
                                id="RequiredFieldValidator1" runat="server" controltovalidate="PaymentMethodTextBox"
                                cssclass="ErrorMessage" display="Dynamic" errormessage="*"></ew:requiredfieldvalidator></td></tr><tr>
                        <td align="right" class="FormViewLabelCell" style="width: 35%">
                        </td>
                        <td style="width: 65%; padding-bottom: 5px;">
                            <asp:Button ID="btnAdd" runat="server" CommandName="Insert" Text="<%$ Resources:TimeLive.Resource, Add_text%> " Width="68px" /><asp:Label
                                ID="lblExceptionText" runat="server" CssClass="ErrorMessage" ForeColor="Red"
                                Text="Label" Visible="False"></asp:Label></td></tr></table></InsertItemTemplate><ItemTemplate>
                AccountPaymentMethodId: <asp:Label ID="AccountPaymentMethodIdLabel" runat="server" Text='<%# Eval("AccountPaymentMethodId") %>'>
                </asp:Label><br />AccountId: <asp:Label ID="AccountIdLabel" runat="server" Text='<%# Bind("AccountId") %>'></asp:Label><br />PaymentMethod: <asp:Label ID="PaymentMethodLabel" runat="server" Text='<%# Bind("PaymentMethod") %>'>
                </asp:Label><br />IsDisabled: <asp:CheckBox ID="IsDisabledCheckBox" runat="server" Checked='<%# Bind("IsDisabled") %>'
                    Enabled="false" /><br />
                <asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" CommandName="Edit"
                    Text="Edit">
                </asp:LinkButton><asp:LinkButton ID="DeleteButton" runat="server" CausesValidation="False" CommandName="Delete"
                    Text="Delete">
                </asp:LinkButton><asp:LinkButton ID="NewButton" runat="server" CausesValidation="False" CommandName="New"
                    Text="New">
                </asp:LinkButton></ItemTemplate></asp:FormView>&nbsp;</ContentTemplate></asp:UpdatePanel>&nbsp; 