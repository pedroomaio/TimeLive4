<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlAccountProjectTypeList.ascx.vb" Inherits="AccountAdmin_Controls_ctlAccountProjectTypeList" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
<x:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="AccountProjectTypeId"
    DataSourceID="dsAccountProjectTypeObject" Width="98%" SkinID="xgridviewSkinEmployee" AllowSorting="True" Caption='<%# ResourceHelper.GetFromResource("Project Type List") %>'>
    <Columns>
        <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Id %>" InsertVisible="False" SortExpression="AccountProjectTypeId">
            <edititemtemplate>
<asp:Label id="Label1" runat="server" Text='<%# Eval("AccountProjectTypeId") %>' __designer:wfdid="w142"></asp:Label> 
</edititemtemplate>
            <headertemplate>
<asp:LinkButton id="LinkButton3" runat="server" Text='<%# ResourceHelper.GetFromResource("Id") %>' CommandArgument="AccountProjectTypeId" CommandName="Sort" CausesValidation="False"></asp:LinkButton>
</headertemplate>
            <itemtemplate>
<asp:Label id="Label1" runat="server" Text='<%# Bind("AccountProjectTypeId") %>' __designer:wfdid="w141"></asp:Label> 
</itemtemplate>
            <itemstyle horizontalalign="Center" width="5%" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Project Type %>" SortExpression="ProjectType">
            <edititemtemplate>
<asp:TextBox id="TextBox1" runat="server" Text='<%# Bind("ProjectType") %>' __designer:wfdid="w145"></asp:TextBox> 
</edititemtemplate>
            <headertemplate>
<asp:LinkButton id="LinkButton4" runat="server" Text='<%# ResourceHelper.GetFromResource("Project Type") %>' CommandArgument="ProjectType" CommandName="Sort" CausesValidation="False"></asp:LinkButton>
</headertemplate>
            <itemtemplate>
<asp:Label id="Label2" runat="server" Text='<%# Bind("ProjectType") %>' __designer:wfdid="w144"></asp:Label> 
</itemtemplate>
            <headerstyle horizontalalign="Left" />
            <itemstyle horizontalalign="Left" width="90%" />
        </asp:TemplateField>
        <asp:CommandField HeaderText="<%$ Resources:TimeLive.Resource, Edit_Text %>" SelectText="Edit" ShowSelectButton="True" >
            <HeaderStyle HorizontalAlign="Center" />
            <ItemStyle HorizontalAlign="Center" Width="1%" cssclass="edit_button"  />
        </asp:CommandField>
        <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Delete_text %>" ShowHeader="False">
     <ItemTemplate>
 
       <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete"
                    OnClientClick='<%# ResourceHelper.GetDeleteMessageJavascript()%>'
                    Text="<%$ Resources:TimeLive.Resource, Delete_text%> " />
     
</ItemTemplate>
            <HeaderStyle HorizontalAlign="Center" />
            <ItemStyle HorizontalAlign="Center" Width="1%" cssclass="delete_button"  />
        </asp:TemplateField>
       <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/Disabled.gif" ToolTip="<%$ Resources:TimeLive.Resource, Disabled_text%> " />
                    
</HeaderTemplate>
                    <ItemTemplate>
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/Disabled.gif" Visible='<%# IIF(IsDBNull(Eval("IsDisabled")),"false",Eval("IsDisabled")) %>' ToolTip="<%$ Resources:TimeLive.Resource, Disabled_text%> " />
                    
</ItemTemplate>
        <ItemStyle HorizontalAlign="Center" Width="1%"/>
                </asp:TemplateField>
    </Columns>
</x:GridView>
<asp:ObjectDataSource ID="dsAccountProjectTypeObject" runat="server" DeleteMethod="DeleteAccountProjectType"
    InsertMethod="AddAccountProjectType" OldValuesParameterFormatString="original_{0}"
    SelectMethod="GetAccountProjectTypesByAccountId" TypeName="AccountProjectTypeBLL"
    UpdateMethod="UpdateAccountProjectType">
    <DeleteParameters>
        <asp:Parameter Name="Original_AccountProjectTypeId" Type="Int32" />
    </DeleteParameters>
    <UpdateParameters>
        <asp:Parameter Name="AccountId" Type="Int32" />
        <asp:Parameter Name="ProjectType" Type="String" />
        <asp:Parameter Name="original_AccountProjectTypeId" Type="Int32" />
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
        <asp:Parameter Name="ProjectType" Type="String" />
        <asp:Parameter Name="CreatedOn" Type="DateTime" />
        <asp:Parameter Name="CreatedByEmployeeId" Type="Int32" />
        <asp:Parameter Name="ModifiedOn" Type="DateTime" />
        <asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" />
    </InsertParameters>
</asp:ObjectDataSource>
<asp:ObjectDataSource ID="dsAccountProjectTypeFormObject" runat="server" DeleteMethod="DeleteAccountProjectType"
    InsertMethod="AddAccountProjectType" OldValuesParameterFormatString="original_{0}"
    SelectMethod="GetAccountProjectTypesByAccountProjectTypeId" TypeName="AccountProjectTypeBLL"
    UpdateMethod="UpdateAccountProjectType">
    <DeleteParameters>
        <asp:Parameter Name="Original_AccountProjectTypeId" Type="Int32" />
    </DeleteParameters>
    <UpdateParameters>
        <asp:SessionParameter DefaultValue="23" Name="AccountId" SessionField="AccountId"
            Type="Int32" />
        <asp:Parameter Name="ProjectType" Type="String" />
        <asp:Parameter Name="Original_AccountProjectTypeId" Type="Int32" />
        <asp:Parameter Name="CreatedOn" Type="DateTime" />
        <asp:Parameter Name="CreatedByEmployeeId" Type="Int32" />
        <asp:Parameter Name="ModifiedOn" Type="DateTime" />
        <asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" />
        <asp:Parameter Name="IsDisabled" Type="Boolean" />
    </UpdateParameters>
    <SelectParameters>
        <asp:ControlParameter ControlID="GridView1" Name="AccountProjectTypeId" PropertyName="SelectedValue"
            Type="Int32" />
    </SelectParameters>
    <InsertParameters>
        <asp:SessionParameter DefaultValue="23" Name="AccountId" SessionField="AccountId"
            Type="Int32" />
        <asp:Parameter Name="ProjectType" Type="String" />
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
<asp:FormView ID="FormView1" runat="server" DataKeyNames="AccountProjectTypeId" DataSourceID="dsAccountProjectTypeFormObject"
    DefaultMode="Insert" SkinID="formviewSkinEmployee" Width="400px" OnDataBound="FormView1_DataBound">
    <EditItemTemplate>
        <table style="width: 100%" class="xFormView">
            <tr>
                <th class="caption" colspan="2" style="width: 40%; height: 21px">
                    <asp:Literal ID="Literal5" runat="server" Text='<%# ResourceHelper.GetFromResource("Project Type Information")%> ' /></th>
            </tr>
            <tr>
                <th class="FormViewSubHeader" colspan="2" style="width: 40%; height: 21px">
                    <asp:Literal ID="Literal1" runat="server" Text='<%# ResourceHelper.GetFromResource("Project Type")%> ' /></th>
            </tr>
            <tr>
                <td style="height: 26px; width: 30%;" class="FormViewLabelCell" align="right">
                                                        <SPAN 
                  class=reqasterisk>*</SPAN> 
                  
<asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="ProjectTypeTextBox">
                  <asp:Literal ID="Literal3" runat="server" Text='<%# ResourceHelper.GetFromResource("Project Type:")%> ' /></asp:Label></td><td style="width: 70%; height: 26px;">
        <asp:TextBox 
                        ID="ProjectTypeTextBox" runat="server" Text='<%# Bind("ProjectType") %>' 
                        MaxLength="100" Width="176px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
            ControlToValidate="ProjectTypeTextBox" Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator></td></tr><tr>
                <td align="right" class="FormViewLabelCell" style="width: 30%; height: 26px">
                    <asp:Literal ID="Literal2" runat="server" Text='<%# ResourceHelper.GetFromResource("Disabled:")%> ' /></td>
                <td style="width: 70%; height: 26px">
                    <asp:CheckBox ID="CheckBox1" runat="server" Checked='<%# Bind("IsDisabled") %>' /></td>
            </tr>
            <tr>
                <td style="height: 26px; width: 30%;" align="right">
                </td>
                <td style="width: 70%; height: 26px; padding-bottom: 5px;">
                    <asp:Button ID="Button1" 
                        runat="server" CommandName="Update" 
                        Text="<%$ Resources:TimeLive.Resource, Update_Text%> " Width="68px" />&nbsp<asp:Button 
                        ID="Button2" runat="server" CommandName="Cancel"
                            Text="<%$ Resources:TimeLive.Resource, Cancel_Text%> " Width="68px" /></td>
            </tr>
        </table>
    </EditItemTemplate>
    <InsertItemTemplate>
        <table style="width: 100%" class="xFormView">
            <tr>
                <th class="caption" colspan="2" style="width: 40%; height: 21px">
                    <asp:Literal ID="Literal5" runat="server" Text='<%# ResourceHelper.GetFromResource("Project Type Information")%> ' /></th>
            </tr>
            <tr>
                <th class="FormViewSubHeader" colspan="2" style="width: 40%; height: 21px">
                    <asp:Literal ID="Literal1" runat="server" Text='<%# ResourceHelper.GetFromResource("Project Type")%> ' /></th>
            </tr>
            <tr>
                <td style="height: 26px; width: 30%;" class="FormViewLabelCell" align="right">
                                                        <SPAN 
                  class=reqasterisk>*</SPAN><asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="ProjectTypeTextBox">
                  <asp:Literal ID="Literal4" runat="server" Text='<%# ResourceHelper.GetFromResource("Project Type:")%> ' /></asp:Label></td></td><td style="width: 70%; height: 26px;">
                    <asp:TextBox 
                        ID="ProjectTypeTextBox" runat="server" Text='<%# Bind("ProjectType") %>' 
                        MaxLength="100" Width="176px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ProjectTypeTextBox"
                        Display="Dynamic" ErrorMessage="*" Width="8px"></asp:RequiredFieldValidator></td></tr><tr>
                <td style="height: 26px; width: 30%;" align="right">
                </td>
                <td style="width: 70%; height: 26px; padding-bottom: 5px;">
                    <asp:Button ID="Add" 
                        runat="server" CommandName="Insert" 
                        Text="<%$ Resources:TimeLive.Resource, Add_Text%> " Width="68px" /></td>
            </tr>
        </table>
    </InsertItemTemplate>
    <ItemTemplate>
        AccountProjectTypeId: <asp:Label ID="AccountProjectTypeIdLabel" runat="server" Text='<%# Eval("AccountProjectTypeId") %>'>
        </asp:Label><br />AccountId: <asp:Label ID="AccountIdLabel" runat="server" Text='<%# Bind("AccountId") %>'></asp:Label><br />ProjectType: <asp:Label ID="ProjectTypeLabel" runat="server" Text='<%# Bind("ProjectType") %>'>
        </asp:Label><br /><asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" CommandName="Edit"
            Text="Edit">
        </asp:LinkButton><asp:LinkButton ID="DeleteButton" runat="server" CausesValidation="False" CommandName="Delete"
            Text="Delete">
        </asp:LinkButton><asp:LinkButton ID="NewButton" runat="server" CausesValidation="False" CommandName="New"
            Text="New">
        </asp:LinkButton></ItemTemplate></asp:FormView></ContentTemplate></asp:UpdatePanel>&nbsp; &nbsp;&nbsp; 