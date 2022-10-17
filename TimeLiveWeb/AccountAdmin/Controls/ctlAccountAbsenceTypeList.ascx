<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlAccountAbsenceTypeList.ascx.vb" Inherits="AccountAdmin_Controls_ctlAccountAbsenceTypeList" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
<x:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="AccountAbsenceTypeId"
    DataSourceID="dsAccountAbsenceTypeObject" SkinID="xgridviewSkinEmployee" AllowSorting="True" Width="98%" Caption='<%# ResourceHelper.GetFromResource("Absence Type List") %>'>
    <Columns>
        <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Id %>" InsertVisible="False" SortExpression="AccountAbsenceTypeId">
            <edititemtemplate>
<asp:Label id="Label1" runat="server" Text='<%# Eval("AccountAbsenceTypeId") %>' __designer:wfdid="w130"></asp:Label>
</edititemtemplate>
            <headertemplate>
<asp:LinkButton id="LinkButton3" runat="server" Text='<%# ResourceHelper.GetFromResource("Id") %>' CommandArgument="AccountAbsenceTypeId" CommandName="Sort" CausesValidation="False"></asp:LinkButton>
</headertemplate>
            <itemtemplate>
<asp:Label id="Label2" runat="server" Text='<%# Bind("AccountAbsenceTypeId") %>' __designer:wfdid="w129"></asp:Label>
</itemtemplate>
            <headerstyle horizontalalign="Center" />
            <itemstyle horizontalalign="Center" width="5%" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Absence Description %>" SortExpression="AbsenceDescription">
            <edititemtemplate>
<asp:TextBox id="TextBox1" runat="server" Text='<%# Bind("AbsenceDescription") %>' __designer:wfdid="w133"></asp:TextBox>
</edititemtemplate>
            <headertemplate>
<asp:LinkButton id="LinkButton4" runat="server" Text='<%# ResourceHelper.GetFromResource("Absence Description") %>' CommandArgument="AbsenceDescription" CommandName="Sort" CausesValidation="False"></asp:LinkButton>
</headertemplate>
            <itemtemplate>
<asp:Label id="Label1" runat="server" Text='<%# Bind("AbsenceDescription") %>' __designer:wfdid="w132"></asp:Label>
</itemtemplate>
            <headerstyle horizontalalign="Left" />
            <itemstyle horizontalalign="Left" Width="90%" />
        </asp:TemplateField>
        <asp:CommandField HeaderText="<%$ Resources:TimeLive.Resource, Edit_Text %>" SelectText="Edit" ShowSelectButton="True">
            <HeaderStyle HorizontalAlign="Center" />
            <ItemStyle HorizontalAlign="Center" Width="1%" cssclass="edit_button" />
        </asp:CommandField>
        <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Delete_text %>" ShowHeader="False">
     <ItemTemplate>
 
       <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete"
                    OnClientClick='<%# ResourceHelper.GetDeleteMessageJavascript()%>' 
                     />
     
</ItemTemplate>
            <HeaderStyle HorizontalAlign="Center" />
            <ItemStyle HorizontalAlign="Center" Width="1%" cssclass="delete_button"  />
        </asp:TemplateField>
        <asp:TemplateField>
            <HeaderTemplate>
                <asp:Image ID="Image2" runat="server" ImageUrl="~/Images/Disabled.gif" ToolTip="<%$ Resources:TimeLive.Resource, Disabled_text%> " />
            
</HeaderTemplate>
            <ItemTemplate>
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/Disabled.gif" Visible='<%# IIF(IsDBNull(Eval("IsDisabled")),"False",Eval("IsDisabled")) %>' ToolTip="<%$ Resources:TimeLive.Resource, Disabled_text%> " />
            
</ItemTemplate>
            <ItemStyle HorizontalAlign="Center" Width="1%" />
        </asp:TemplateField>

    </Columns>
</x:GridView>
<asp:ObjectDataSource ID="dsAccountAbsenceTypeObject" runat="server" DeleteMethod="DeleteAccountAbsenceType"
    InsertMethod="AddAccountAbsenceType" OldValuesParameterFormatString="original_{0}"
    SelectMethod="GetAccountAbsenceTypesByAccountId" TypeName="AccountAbsenceTypeBLL"
    UpdateMethod="UpdateAccountAbsenceType">
    <DeleteParameters>
        <asp:Parameter Name="original_AccountAbsenceTypeId" Type="Int32" />
    </DeleteParameters>
    <UpdateParameters>
        <asp:Parameter Name="AccountId" Type="Int32" />
        <asp:Parameter Name="AbsenceDescription" Type="String" />
        <asp:Parameter Name="original_AccountAbsenceTypeId" Type="Int32" />
        <asp:Parameter Name="CreatedOn" Type="DateTime" />
        <asp:Parameter Name="CreatedByEmployeeId" Type="Int32" />
        <asp:Parameter Name="ModifiedOn" Type="DateTime" />
        <asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" />
        <asp:Parameter Name="IsDisabled" Type="Boolean" />
    </UpdateParameters>
    <SelectParameters>
        <asp:SessionParameter DefaultValue="23" Name="AccountId" SessionField="AccountId"
            Type="Int32" />
    </SelectParameters>
    <InsertParameters>
        <asp:Parameter Name="AccountId" Type="Int32" />
        <asp:Parameter Name="AbsenceDescription" Type="String" />
        <asp:Parameter Name="CreatedOn" Type="DateTime" />
        <asp:Parameter Name="CreatedByEmployeeId" Type="Int32" />
        <asp:Parameter Name="ModifiedOn" Type="DateTime" />
        <asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" />
    </InsertParameters>
</asp:ObjectDataSource>
<asp:ObjectDataSource ID="dsAccountAbsenceTypeFormObject" runat="server" DeleteMethod="DeleteAccountAbsenceType"
    InsertMethod="AddAccountAbsenceType" OldValuesParameterFormatString="original_{0}"
    SelectMethod="GetAccountAbsenceTypesByAccountAbsenceTypeId" TypeName="AccountAbsenceTypeBLL"
    UpdateMethod="UpdateAccountAbsenceType" OnInserting="dsAccountAbsenceTypeFormObject_Inserting" OnUpdating="dsAccountAbsenceTypeFormObject_Updating">
    <DeleteParameters>
        <asp:Parameter Name="original_AccountAbsenceTypeId" Type="Int32" />
    </DeleteParameters>
    <UpdateParameters>
        <asp:SessionParameter DefaultValue="23" Name="AccountId" SessionField="AccountId"
            Type="Int32" />
        <asp:Parameter Name="AbsenceDescription" Type="String" />
        <asp:Parameter Name="original_AccountAbsenceTypeId" Type="Int32" />
        <asp:Parameter Name="CreatedOn" Type="DateTime" />
        <asp:Parameter Name="CreatedByEmployeeId" Type="Int32" />
        <asp:Parameter Name="ModifiedOn" Type="DateTime" />
        <asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" />
        <asp:Parameter Name="IsDisabled" Type="Boolean" />
    </UpdateParameters>
    <SelectParameters>
        <asp:ControlParameter ControlID="GridView1" Name="AccountAbsenceTypeId" PropertyName="SelectedValue"
            Type="Int32" />
    </SelectParameters>
    <InsertParameters>
        <asp:SessionParameter DefaultValue="23" Name="AccountId" SessionField="AccountId"
            Type="Int32" />
        <asp:Parameter Name="AbsenceDescription" Type="String" />
        <asp:Parameter Name="CreatedOn" Type="DateTime" />
        <asp:Parameter Name="CreatedByEmployeeId" Type="Int32" />
        <asp:Parameter Name="ModifiedOn" Type="DateTime" />
        <asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" />
    </InsertParameters>
</asp:ObjectDataSource>
    </ContentTemplate>
</asp:UpdatePanel>
<br />
<asp:UpdatePanel ID="UpdatePanel2" runat="server">
    <ContentTemplate>
<asp:FormView ID="FormView1" runat="server" DataKeyNames="AccountAbsenceTypeId" DataSourceID="dsAccountAbsenceTypeFormObject"
    DefaultMode="Insert" SkinID="formviewSkinEmployee" Width="400px" 
            OnDataBound="FormView1_DataBound">
    <EditItemTemplate>
        <table style="width: 100%" class="xview">
            <tr>
                <th class="caption" colspan="2" style="width: 40%;Height:21px">
                    <asp:Literal ID="Literal1" runat="server" Text='<%# ResourceHelper.GetFromResource("Absence Type Information")%> ' /></th>
            </tr>
            <tr>
                <th class="FormViewSubHeader" colspan="2" style="width: 40%;Height:21px">
                    <asp:Literal ID="Literal2" runat="server" Text='<%# ResourceHelper.GetFromResource("Absence Type")%> ' /></th>
            </tr>
            <tr>
                <td class="FormViewLabelCell" width="40%" style="width: 30%; height: 26px" align="right">
                    <SPAN 
                  class=reqasterisk>*</SPAN> 
                  
<asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="AbsenceDescriptionTextBox">
                  <asp:Literal ID="Literal5" runat="server" Text='<%# ResourceHelper.GetFromResource("Absence Description:")%> ' /></asp:Label></td><td width="60%" style="width: 70%; height: 26px">
        <asp:TextBox 
                        ID="AbsenceDescriptionTextBox" runat="server" 
                        Text='<%# Bind("AbsenceDescription") %>' MaxLength="50" Width="176px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
            ControlToValidate="AbsenceDescriptionTextBox" Display="Dynamic" ErrorMessage="*"
            Width="0px"></asp:RequiredFieldValidator></td></tr><tr>
                <td align="right" class="FormViewLabelCell" style="width: 30%; height: 26px" width="40%">
                    <asp:Literal ID="Literal3" runat="server" Text='<%# ResourceHelper.GetFromResource("Disabled:")%> ' /></td>
                <td style="width: 70%; height: 26px" width="60%">
                    <asp:CheckBox ID="CheckBox1" 
                        runat="server" Checked='<%# Bind("IsDisabled") %>' 
                        oncheckedchanged="CheckBox1_CheckedChanged" /></td>
            </tr>
            <tr>
                <td align="right" style="width: 40%; height: 26px" width="60%">
                </td>
                <td style="height: 26px; width: 70%; padding-bottom: 5px;" width="60%">
                    <asp:Button ID="Button2" runat="server" CommandName="Update" Text="<%$ Resources:TimeLive.Resource, Update_text%> "  Width="68px" />
                    <asp:Button ID="Button3" runat="server" CommandName="Cancel" Text="<%$ Resources:TimeLive.Resource, Cancel_text%> "  Width="68px" /></td>
            </tr>
        </table>
    </EditItemTemplate>
    <InsertItemTemplate>
        <table style="width: 100%" class="xview">
            <tr>
                <th class="caption" colspan="2" style="height: 21px" width="40%">
                    <asp:Literal ID="Literal2" runat="server" Text='<%# ResourceHelper.GetFromResource("Absence Type Information")%> ' /></th>
            </tr>
            <tr>
                <th class="FormViewSubHeader" colspan="2" style="height: 21px" width="40%">
                    <asp:Literal ID="Literal4" runat="server" Text='<%# ResourceHelper.GetFromResource("Absence Type")%> ' /></th>
            </tr>
            <tr>
                <td style="height: 26px; width: 30%;" class="FormViewLabelCell" width="40%" align="right">
                    <SPAN 
                  class=reqasterisk>*</SPAN><asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="AbsenceDescriptionTextBox">
<asp:Literal ID="Literal6" runat="server" Text='<%# ResourceHelper.GetFromResource("Absence Description:")%> ' /></asp:Label></td><td style="height: 26px; width: 70%;" colspan="1" rowspan="1">
                    <asp:TextBox 
                        ID="AbsenceDescriptionTextBox" runat="server" 
                        Text='<%# Bind("AbsenceDescription") %>' MaxLength="50" Width="176px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="AbsenceDescriptionTextBox"
                        ErrorMessage="*" Width="0px" Display="Dynamic"></asp:RequiredFieldValidator></td></tr><tr>
                <td width="40%" align="right">
                </td>
                <td style="width: 70%; padding-bottom: 5px;">
                    <asp:Button ID="btnAdd" runat="server" CommandName="Insert" Text="<%$ Resources:TimeLive.Resource, Add_text%> " Width="68px" /></td>
            </tr>
        </table>
    </InsertItemTemplate>
    <ItemTemplate>
        AccountAbsenceTypeId: <asp:Label ID="AccountAbsenceTypeIdLabel" runat="server" Text='<%# Eval("AccountAbsenceTypeId") %>'>
        </asp:Label><br />AccountId: <asp:Label ID="AccountIdLabel" runat="server" Text='<%# Bind("AccountId") %>'></asp:Label><br />AbsenceDescription: <asp:Label ID="AbsenceDescriptionLabel" runat="server" Text='<%# Bind("AbsenceDescription") %>'>
        </asp:Label><br /><asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" CommandName="Edit"
            Text="Edit">
        </asp:LinkButton><asp:LinkButton ID="DeleteButton" runat="server" CausesValidation="False" CommandName="Delete"
            Text="Delete">
        </asp:LinkButton><asp:LinkButton ID="NewButton" runat="server" CausesValidation="False" CommandName="New"
            Text="New">
        </asp:LinkButton></ItemTemplate></asp:FormView></ContentTemplate></asp:UpdatePanel>