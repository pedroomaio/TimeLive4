<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlAccountTaskTypeList.ascx.vb" Inherits="AccountAdmin_Controls_ctlAccountTaskTypeList" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
<x:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="AccountTaskTypeId"
    DataSourceID="dsAccountTaskTypeObject" SkinID="xgridviewSkinEmployee" AllowSorting="True" Caption='<%# ResourceHelper.GetFromResource("Task Type List") %>' Width="98%" >
    <Columns>
        <asp:TemplateField InsertVisible="False" SortExpression="AccountTaskTypeId" HeaderText="<%$ Resources:TimeLive.Resource, Id %>">
            <edititemtemplate>
<asp:Label id="Label1" runat="server" Text='<%# Eval("AccountTaskTypeId") %>' __designer:wfdid="w55"></asp:Label> 
</edititemtemplate>
            <headertemplate>
<asp:LinkButton id="LinkButton3" runat="server" Text='<%# ResourceHelper.GetFromResource("Id") %>' CommandArgument="AccountTaskTypeId" CommandName="Sort" CausesValidation="False"></asp:LinkButton>
</headertemplate>
            <itemtemplate>
<asp:Label id="Label1" runat="server" Text='<%# Bind("AccountTaskTypeId") %>' __designer:wfdid="w54"></asp:Label> 
</itemtemplate>
            <itemstyle horizontalalign="Center" width="5%" />
        </asp:TemplateField>
        <asp:TemplateField SortExpression="TaskType" HeaderText="<%$ Resources:TimeLive.Resource, Task Type %>">
            <edititemtemplate>
<asp:TextBox id="TextBox1" runat="server" Text='<%# Bind("TaskType") %>' __designer:wfdid="w58"></asp:TextBox> 
</edititemtemplate>
            <headertemplate>
<asp:LinkButton id="LinkButton4" runat="server" Text='<%# ResourceHelper.GetFromResource("Task Type") %>' CommandArgument="TaskType" CommandName="Sort" CausesValidation="False"></asp:LinkButton>
</headertemplate>
            <itemtemplate>
<asp:Label id="Label2" runat="server" Text='<%# Bind("TaskType") %>' __designer:wfdid="w57"></asp:Label> 
</itemtemplate>
            <headerstyle horizontalalign="Left" />
            <itemstyle horizontalalign="Left" width="90%" />
        </asp:TemplateField>
        <asp:CommandField HeaderText="<%$ Resources:TimeLive.Resource, Edit_text %>" SelectText="Edit" ShowSelectButton="True" >
            <HeaderStyle HorizontalAlign="Center" />
            <ItemStyle HorizontalAlign="Center" Width="1%" cssclass="edit_button" />
        </asp:CommandField>
        <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Delete_text %>" ShowHeader="False">
     <ItemTemplate>
<asp:LinkButton id="LinkButton1" runat="server" Text="<%$ Resources:TimeLive.Resource, Delete_text %>" OnClientClick="<%# ResourceHelper.GetDeleteMessageJavascript() %>" CommandName="Delete" CausesValidation="False" __designer:wfdid="w5" Visible="<%# iif(me.gridview1.rows.count <= 0,0,1) %>"></asp:LinkButton> 
</ItemTemplate>
            <HeaderStyle HorizontalAlign="Center" />
            <ItemStyle HorizontalAlign="Center" Width="1%"  cssclass="delete_button"/>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Disabled: %>">
            <HeaderTemplate>
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/Disabled.gif" ToolTip="<%$ Resources:TimeLive.Resource, Disabled_text%> " />
            
</HeaderTemplate>
            <ItemTemplate>
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/Disabled.gif" Visible='<%# IIF(IsDBNull(Eval("IsDisabled")),"False",Eval("IsDisabled")) %>' ToolTip="<%$ Resources:TimeLive.Resource, Disabled_text%> " />
            
</ItemTemplate>
            <ItemStyle HorizontalAlign="Center" Width="1%" />
        </asp:TemplateField>
    </Columns>
</x:GridView>
<asp:ObjectDataSource ID="dsAccountTaskTypeObject" runat="server" DeleteMethod="DeleteAccountTaskType"
    InsertMethod="AddAccountTaskType" OldValuesParameterFormatString="original_{0}"
    SelectMethod="GetAccountTaskTypesByAccountId" TypeName="AccountTaskTypeBLL" UpdateMethod="UpdateAccountTaskType">
    <DeleteParameters>
        <asp:Parameter Name="Original_AccountTaskTypeId" Type="Int32" />
    </DeleteParameters>
    <UpdateParameters>
        <asp:Parameter Name="AccountId" Type="Int32" />
        <asp:Parameter Name="TaskType" Type="String" />
        <asp:Parameter Name="Original_AccountTaskTypeId" Type="Int32" />
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
        <asp:Parameter Name="TaskType" Type="String" />
        <asp:Parameter Name="CreatedOn" Type="DateTime" />
        <asp:Parameter Name="CreatedByEmployeeId" Type="Int32" />
        <asp:Parameter Name="ModifiedOn" Type="DateTime" />
        <asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" />
    </InsertParameters>
</asp:ObjectDataSource>
<asp:ObjectDataSource ID="dsAccountTaskTypeFormObject" runat="server" DeleteMethod="DeleteAccountTaskType"
    InsertMethod="AddAccountTaskType" OldValuesParameterFormatString="original_{0}"
    SelectMethod="GetAccountTaskTypesByAccountTaskTypeId" TypeName="AccountTaskTypeBLL"
    UpdateMethod="UpdateAccountTaskType">
    <DeleteParameters>
        <asp:Parameter Name="Original_AccountTaskTypeId" Type="Int32" />
    </DeleteParameters>
    <UpdateParameters>
        <asp:SessionParameter DefaultValue="23" Name="AccountId" SessionField="AccountId"
            Type="Int32" />
        <asp:Parameter Name="TaskType" Type="String" />
        <asp:Parameter Name="Original_AccountTaskTypeId" Type="Int32" />
        <asp:Parameter Name="CreatedOn" Type="DateTime" />
        <asp:Parameter Name="CreatedByEmployeeId" Type="Int32" />
        <asp:Parameter Name="ModifiedOn" Type="DateTime" />
        <asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" />
        <asp:Parameter Name="IsDisabled" Type="Boolean" />
    </UpdateParameters>
    <SelectParameters>
        <asp:ControlParameter ControlID="GridView1" Name="AccountTaskTypeId" PropertyName="SelectedValue"
            Type="Int32" />
    </SelectParameters>
    <InsertParameters>
        <asp:SessionParameter DefaultValue="23" Name="AccountId" SessionField="AccountId"
            Type="Int32" />
        <asp:Parameter Name="TaskType" Type="String" />
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
<asp:FormView ID="FormView1" runat="server" DataKeyNames="AccountTaskTypeId" DataSourceID="dsAccountTaskTypeFormObject"
    DefaultMode="Insert" SkinID="formviewSkinEmployee" Width="450px" 
            OnDataBound="FormView1_DataBound">
    <EditItemTemplate>
        <table style="width: 100%" class="xFormView">
            <tr>
                <th class="caption" colspan="2" style="height: 21px">
                    <asp:Literal ID="Literal1" runat="server" Text='<%# ResourceHelper.GetFromResource("Task Type Information") %>' /></th>
            </tr>
            <tr>
                <th class="FormViewSubHeader" colspan="2" style="height: 21px">
                    <asp:Literal ID="Literal2" runat="server" Text='<%# ResourceHelper.GetFromResource("Task Type") %>' /></th>
            </tr>
            <tr>
                <td style="height: 26px; width: 30%;" class="FormViewLabelCell" align="right">
                                        <SPAN 
                  class=reqasterisk>*</SPAN> 
                  
<asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="TaskTypeTextBox">
                  <asp:Literal ID="Literal5" runat="server" Text='<%# ResourceHelper.GetFromResource("Task Type:") %>' /></asp:Label></td><td 
                    style="width: 70%; height: 26px;" width="80%"><asp:TextBox ID="TaskTypeTextBox" 
                        runat="server" Text='<%# Bind("TaskType") %>' MaxLength="50" Width="176px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TaskTypeTextBox"
                        Display="Dynamic" ErrorMessage="*" Width="8px"></asp:RequiredFieldValidator></td></tr><tr>
                <td align="right" class="FormViewLabelCell" style="width: 30%; height: 26px">
                    <asp:Literal ID="Literal3" runat="server" Text="<%$ Resources:TimeLive.Resource, Disabled:%> " /></td>
                <td style="width: 70%; height: 26px">
                    <asp:CheckBox ID="chkIsDisabled" 
                        runat="server" Checked='<%# Bind("IsDisabled") %>' /></td>
            </tr>
            <tr>
                <td style="height: 26px; width: 30%;" align="right">
                </td>
                <td style="width: 70%; height: 26px; padding-bottom: 5px;">
                    <asp:Button ID="Button1" runat="server" Text="<%$ Resources:TimeLive.Resource, Update_text%> " CommandName="Update" OnClick="Button1_Click" Width="68px" />&nbsp<asp:Button 
                        ID="Button2" runat="server" Text="<%$ Resources:TimeLive.Resource, Cancel_text%> " 
                        CommandName="Cancel" Width="68px" /></td>
            </tr>
        </table>
    </EditItemTemplate>
    <InsertItemTemplate>
        <table style="width: 100%" class="xFormView">
            <tr>
                <th class="caption" colspan="2" style="height: 21px">
                  <asp:Literal ID="Literal3" runat="server" Text='<%# ResourceHelper.GetFromResource("Task Type Information") %>' /></th>
            </tr>
            <tr>
                <th class="FormViewSubHeader" colspan="2" style="height: 21px">
                    <asp:Literal ID="Literal4" runat="server" Text='<%# ResourceHelper.GetFromResource("Task Type") %>' /></th>
            </tr>
            <tr>
                <td style="height: 26px; width: 30%;" class="FormViewLabelCell" align="right">
                                        <SPAN 
                  class=reqasterisk>*</SPAN><asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="TaskTypeTextBox">
<asp:Literal ID="Literal2" runat="server" Text='<%# ResourceHelper.GetFromResource("Task Type:") %>' /></asp:Label></td><td style="width: 70%; height: 26px;">
                    <asp:TextBox 
                        ID="TaskTypeTextBox" runat="server" Text='<%# Bind("TaskType") %>' 
                        MaxLength="50" Width="176px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TaskTypeTextBox"
                        Display="Dynamic" ErrorMessage="*" Width="8px"></asp:RequiredFieldValidator></td></tr><tr>
                <td style="height: 26px; width: 30%;" align="right">
                </td>
                <td style="width: 70%; height: 26px; padding-bottom: 5px;">
                    <asp:Button ID="Add" runat="server" CommandName="Insert" Text="<%$ Resources:TimeLive.Resource, Add_text%> " Width="68px" /></td>
            </tr>
        </table>
    </InsertItemTemplate>
    <ItemTemplate>
        AccountTaskTypeId: <asp:Label ID="AccountTaskTypeIdLabel" runat="server" Text='<%# Eval("AccountTaskTypeId") %>'>
        </asp:Label><br />TaskType: <asp:Label ID="TaskTypeLabel" runat="server" Text='<%# Bind("TaskType") %>'></asp:Label><br />AccountId: <asp:Label ID="AccountIdLabel" runat="server" Text='<%# Bind("AccountId") %>'></asp:Label><br /><asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" CommandName="Edit"
            Text="Edit">
        </asp:LinkButton><asp:LinkButton ID="DeleteButton" runat="server" CausesValidation="False" CommandName="Delete"
            Text="Delete">
        </asp:LinkButton><asp:LinkButton ID="NewButton" runat="server" CausesValidation="False" CommandName="New"
            Text="New">
        </asp:LinkButton></ItemTemplate></asp:FormView></ContentTemplate></asp:UpdatePanel>