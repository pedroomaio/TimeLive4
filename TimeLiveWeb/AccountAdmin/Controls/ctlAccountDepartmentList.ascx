<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlAccountDepartmentList.ascx.vb" Inherits="Controls_ctlAccountDepartmentList" %>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
<x:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="AccountDepartmentId"
    DataSourceID="dsAccountDepartment"  AllowSorting="True" SkinID="xgridviewSkinEmployee" Caption='<%# ResourceHelper.GetFromResource("Department List") %>' CssClass="TableView" Width="98%">
    <Columns>
        <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Id %>" InsertVisible="False" SortExpression="AccountDepartmentId">
            <edititemtemplate>
<asp:Label id="Label1" runat="server" Text='<%# Eval("AccountDepartmentId") %>' __designer:wfdid="w8"></asp:Label>
</edititemtemplate>
            <headertemplate>
<asp:LinkButton id="LinkButton4" runat="server" Text='<%# ResourceHelper.GetFromResource("Id") %>' CommandArgument="AccountDepartmentId" CommandName="Sort" CausesValidation="False"></asp:LinkButton>
</headertemplate>
            <itemtemplate>
<asp:Label id="Label1" runat="server" Text='<%# Bind("AccountDepartmentId") %>' __designer:wfdid="w7"></asp:Label>
</itemtemplate>
            <itemstyle horizontalalign="Center" width="5%" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Code %>" SortExpression="DepartmentCode">
            <edititemtemplate>
<asp:TextBox id="TextBox1" runat="server" Text='<%# Bind("DepartmentCode") %>' __designer:wfdid="w15"></asp:TextBox> 
</edititemtemplate>
            <headertemplate>
<asp:LinkButton id="LinkButton3" runat="server" Text='<%# ResourceHelper.GetFromResource("Code") %>' CommandArgument="DepartmentCode" CommandName="Sort" CausesValidation="False"></asp:LinkButton>
</headertemplate>
            <itemtemplate>
<asp:Label id="Label2" runat="server" Text='<%# Bind("DepartmentCode") %>' __designer:wfdid="w14"></asp:Label> 
</itemtemplate>
            <itemstyle width="10%" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Department Name %>" SortExpression="DepartmentName">
            <edititemtemplate>
<asp:TextBox id="TextBox2" runat="server" __designer:wfdid="w4" Text='<%# Bind("DepartmentName") %>'></asp:TextBox> 
</edititemtemplate>
            <headertemplate>
<asp:LinkButton id="LinkButton2" runat="server" __designer:wfdid="w5" Text='<%# ResourceHelper.GetFromResource("Department Name") %>' CommandArgument="DepartmentName" CommandName="Sort" CausesValidation="False"></asp:LinkButton>
</headertemplate>
            <itemtemplate>
<asp:Label id="Label3" runat="server" __designer:wfdid="w3" Text='<%# Bind("DepartmentName") %>'></asp:Label> 
</itemtemplate>
            <itemstyle width="80%" />
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
        <asp:TemplateField>
            <HeaderTemplate>
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/Disabled.gif" ToolTip="<%$ Resources:TimeLive.Resource, Disabled_text%> "  />
            
</HeaderTemplate>
            <ItemTemplate>
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/Disabled.gif" Visible='<%# IIF(IsDBNull(Eval("IsDisabled")),"false",Eval("IsDisabled")) %>' ToolTip="<%$ Resources:TimeLive.Resource, Disabled_text%> " />
            
</ItemTemplate>
                      <ItemStyle HorizontalAlign="Center"  Width="1%" />
        </asp:TemplateField>
    </Columns>
    <HeaderStyle BorderColor="Black" />
</x:GridView>
<asp:ObjectDataSource ID="dsAccountDepartment" runat="server" OldValuesParameterFormatString="original_{0}"
    SelectMethod="GetAccountDepartmentsByAccountId" TypeName="AccountDepartmentBLL" DeleteMethod="DeleteAccountDepartment" UpdateMethod="UpdateAccountDepartment" InsertMethod="AddAccountDepartment">
    <SelectParameters>
        <asp:SessionParameter DefaultValue="23" Name="AccountId" SessionField="AccountId"
            Type="Int32" />
    </SelectParameters>
    <DeleteParameters>
        <asp:Parameter Name="Original_AccountDepartmentId" Type="Int32" />
    </DeleteParameters>
    <UpdateParameters>
        <asp:Parameter Name="AccountId" Type="Int32" />
        <asp:Parameter Name="DepartmentCode" Type="String" />
        <asp:Parameter Name="DepartmentName" Type="String" />
        <asp:Parameter Name="original_AccountDepartmentId" Type="Int32" />
        <asp:Parameter Name="IsDisabled" Type="Boolean" />
        <asp:Parameter Name="IsDeleted" Type="Boolean" />
        <asp:Parameter Name="CreatedOn" Type="DateTime" />
        <asp:Parameter Name="ModifiedOn" Type="DateTime" />
        <asp:Parameter Name="CreatedByEmployeeId" Type="Int32" />
        <asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" />
    </UpdateParameters>
    <InsertParameters>
        <asp:Parameter Name="AccountId" Type="Int32" />
        <asp:Parameter Name="DepartmentCode" Type="String" />
        <asp:Parameter Name="DepartmentName" Type="String" />
        <asp:Parameter Name="CreatedByEmployeeId" Type="Int32" />
        <asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" />
    </InsertParameters>
</asp:ObjectDataSource>
<asp:ObjectDataSource ID="dsAccountDepartmentObject" runat="server"
    OldValuesParameterFormatString="original_{0}" SelectMethod="GetAccountDepartmentsByAccountDepartmentId"
    TypeName="AccountDepartmentBLL" UpdateMethod="UpdateAccountDepartment" DeleteMethod="DeleteAccountDepartment" InsertMethod="AddAccountDepartment">
    <SelectParameters>
        <asp:ControlParameter ControlID="GridView1" Name="AccountDepartmentId" PropertyName="SelectedValue"
            Type="Int32" />
    </SelectParameters>
    <UpdateParameters>
        <asp:SessionParameter DefaultValue="23" Name="AccountId" SessionField="AccountId"
            Type="Int32" />
        <asp:Parameter Name="DepartmentCode" Type="String" />
        <asp:Parameter Name="DepartmentName" Type="String" />
        <asp:Parameter Name="original_AccountDepartmentId" Type="Int32" />
        <asp:Parameter Name="IsDisabled" Type="Boolean" />
        <asp:Parameter Name="IsDeleted" Type="Boolean" />
        <asp:Parameter Name="CreatedOn" Type="DateTime" />
        <asp:Parameter Name="ModifiedOn" Type="DateTime" />
        <asp:Parameter Name="CreatedByEmployeeId" Type="Int32" />
        <asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" />
    </UpdateParameters>
    <DeleteParameters>
        <asp:Parameter Name="Original_AccountDepartmentId" Type="Int32" />
    </DeleteParameters>
    <InsertParameters>
        <asp:SessionParameter DefaultValue="23" Name="AccountId" SessionField="AccountId"
            Type="Int32" />
        <asp:Parameter DefaultValue="" Name="DepartmentCode" Type="String" />
        <asp:Parameter Name="DepartmentName" Type="String" />
        <asp:Parameter Name="CreatedByEmployeeId" Type="Int32" />
        <asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" />
    </InsertParameters>
</asp:ObjectDataSource>

    </ContentTemplate>
</asp:UpdatePanel>
<br />
<asp:UpdatePanel ID="UpdatePanel2" runat="server">
    <ContentTemplate>
<asp:FormView ID="FormView1" runat="server" DataKeyNames="AccountDepartmentId" DataSourceID="dsAccountDepartmentObject"
    DefaultMode="Insert" SkinID="formviewSkinEmployee" Width="550px" CellPadding="0">
    <EditItemTemplate>
        <table style="width: 100%">
            <tr>
                <th class="caption" colspan="2" style="height: 21px" width="30%">
                    <asp:Literal ID="Literal1" runat="server" Text='<%# ResourceHelper.GetFromResource("Department Information")%> ' /></th>
            </tr>
            <tr>
                <th class="FormViewSubHeader" colspan="2" style="height: 21px" width="30%">
                    <asp:Literal ID="Literal3" runat="server" Text='<%# ResourceHelper.GetFromResource("Department")%> ' /></th>
            </tr>
            <tr>
                <td style="height: 26px;" class="FormViewLabelCell" align="right" width="30%">
                    <SPAN
                  class=reqasterisk>*</SPAN><asp:Label ID="DepartmentCodeLabel" runat="server" AssociatedControlID="DepartmentCodeTextBox"><asp:Literal ID="Literal6" runat="server" Text='<%# ResourceHelper.GetFromResource("Department Code:")%> ' /></asp:Label></td><td style="height: 26px;" width="70%">
                    <asp:TextBox 
                        ID="DepartmentCodeTextBox" runat="server" Text='<%# Bind("DepartmentCode") %>' 
                        Width="176px" MaxLength="10"></asp:TextBox><asp:RequiredFieldValidator
                        ID="RequiredFieldValidator2" runat="server" ControlToValidate="DepartmentCodeTextBox" Display="Dynamic"
                        ErrorMessage="*" Width="1px"></asp:RequiredFieldValidator></td></tr><tr>
                <td style="height: 26px;" class="FormViewLabelCell" align="right" width="30%">
                    <SPAN 
                  class=reqasterisk>*</SPAN><asp:Label ID="DepartmentNameLabel" runat="server" AssociatedControlID="DepartmentNameTextBox"><asp:Literal ID="Literal4" runat="server" Text='<%# ResourceHelper.GetFromResource("Department Name:")%> ' /></asp:Label></td><td style="height: 26px;" width="70%">
        <asp:TextBox 
                        ID="DepartmentNameTextBox" runat="server" Text='<%# Bind("DepartmentName") %>' 
                        Width="176px" MaxLength="200"></asp:TextBox><asp:RequiredFieldValidator
            ID="RequiredFieldValidator3" runat="server" ControlToValidate="DepartmentNameTextBox"
            Display="Dynamic" ErrorMessage="*" Width="1px"></asp:RequiredFieldValidator></td></tr><tr>
                <td 
                    class="FormViewLabelCell" align="right" width="30%"><asp:Literal ID="Literal5" runat="server" Text="<%$ Resources:TimeLive.Resource, Disabled:%> " /></td>
                <td width="70%">
        <asp:CheckBox ID="IsDisabledCheckBox" runat="server" 
                        Checked='<%# Bind("IsDisabled") %>' Width="168px"/></td>
            </tr>
            <tr>
                <td width="30%">
                </td>
                <td width="70%" style="padding-bottom: 5px;">
                    <asp:Button ID="Button1" runat="server" CommandName="Update" Text="<%$ Resources:TimeLive.Resource, Update_Text%> " Width="68px" />&nbsp<asp:Button ID="Button2" runat="server" CommandName="Cancel" Text="<%$ Resources:TimeLive.Resource, Cancel_Text%> " Width="68px"/></td>
            </tr>
        </table>
    </EditItemTemplate>
    <InsertItemTemplate>
        <table style="width: 100%"><tr>
                <th class="caption" colspan="2" style="height: 21px">
                    <asp:Literal ID="Literal1" runat="server" Text='<%# ResourceHelper.GetFromResource("Department Information")%> ' /></th>
            </tr>
            <tr>
                <th class="FormViewSubHeader" colspan="2" style="height: 21px">
                <asp:Literal ID="Literal2" runat="server" Text='<%# ResourceHelper.GetFromResource("Department")%> ' /></th>
                    
            </tr>
            <tr>
                <td class="FormViewLabelCell" style="width: 30%; height: 26px;" colspan="1" rowspan="1" align="right">
                    <SPAN
                  class=reqasterisk>*</SPAN><asp:Label 
                        ID="DepartmentCodeLabel" runat="server" 
                        AssociatedControlID="DepartmentCodeTextBox"><asp:Literal ID="Literal5" runat="server" Text='<%# ResourceHelper.GetFromResource("Department Code:")%> ' /></asp:Label></td><td style="width: 70%; height: 26px;">
                    <asp:TextBox 
                        ID="DepartmentCodeTextBox" runat="server" Text='<%# Bind("DepartmentCode") %>' 
                        Width="176px" MaxLength="10" CssClass="input"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="DepartmentCodeTextBox"
                        ErrorMessage="*" Display="Dynamic" Width="1px"></asp:RequiredFieldValidator></td></tr><tr>
                <td style="width: 30%; height: 26px;" class="FormViewLabelCell" colspan="1" rowspan="1" align="right">
                    <SPAN 
                  class=reqasterisk>*</SPAN><asp:Label ID="DepartmentNameLabel" runat="server" 
                        AssociatedControlID="DepartmentNameTextBox" CssClass="h6"><asp:Literal ID="Literal3" runat="server" Text='<%# ResourceHelper.GetFromResource("Department Name:")%> ' /></asp:Label></td><td style="width: 70%; height: 26px;">
                    <asp:TextBox 
                        ID="DepartmentNameTextBox" runat="server" Text='<%# Bind("DepartmentName") %>' 
                        Width="176px" MaxLength="200" CssClass="input"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="DepartmentNameTextBox"
                        ErrorMessage="*" Display="Dynamic" Width="1px"></asp:RequiredFieldValidator></td></tr><tr>
                <td style="width: 94px; height: 32px;">
                </td>
                <td style="width: 70%; height: 26px; padding-bottom: 5px;">
                    <asp:Button ID="btnAdd" runat="server" 
                        CommandName="Insert" Text="<%$ Resources:TimeLive.Resource, Add_Text%> " 
                        CssClass="button blue-gradient" Width="68px"/></td>
            </tr>
        </table>
    </InsertItemTemplate>
    <ItemTemplate>
        AccountDepartmentId: <asp:Label ID="AccountDepartmentIdLabel" runat="server" Text='<%# Eval("AccountDepartmentId") %>'>
        </asp:Label><br />AccountId: <asp:Label ID="AccountIdLabel" runat="server" Text='<%# Bind("AccountId") %>'></asp:Label><br />DepartmentName: <asp:Label ID="DepartmentNameLabel" runat="server" Text='<%# Bind("DepartmentName") %>'>
        </asp:Label><br />IsDisabled: <asp:CheckBox ID="IsDisabledCheckBox" runat="server" Checked='<%# Bind("IsDisabled") %>'
            Enabled="false" /><br />
        IsDeleted: <asp:CheckBox ID="IsDeletedCheckBox" runat="server" Checked='<%# Bind("IsDeleted") %>'
            Enabled="false" /><br />
        CreatedOn: <asp:Label ID="CreatedOnLabel" runat="server" Text='<%# Bind("CreatedOn") %>'></asp:Label><br />ModifiedOn: <asp:Label ID="ModifiedOnLabel" runat="server" Text='<%# Bind("ModifiedOn") %>'>
        </asp:Label><br />CreatedByEmployeeId: <asp:Label ID="CreatedByEmployeeIdLabel" runat="server" Text='<%# Bind("CreatedByEmployeeId") %>'>
        </asp:Label><br />ModifiedByEmployeeId: <asp:Label ID="ModifiedByEmployeeIdLabel" runat="server" Text='<%# Bind("ModifiedByEmployeeId") %>'>
        </asp:Label><br /><asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" CommandName="Edit"
            Text="Edit">
        </asp:LinkButton><asp:LinkButton ID="DeleteButton" runat="server" CausesValidation="False" CommandName="Delete"
            Text="Delete">
        </asp:LinkButton><asp:LinkButton ID="NewButton" runat="server" CausesValidation="False" CommandName="New"
            Text="New">
        </asp:LinkButton></ItemTemplate><InsertRowStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
</asp:FormView>
        </ContentTemplate></asp:UpdatePanel>