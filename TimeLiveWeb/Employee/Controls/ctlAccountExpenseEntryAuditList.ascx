<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlAccountExpenseEntryAuditList.ascx.vb" Inherits="Employee_Controls_ctlAccountExpenseEntryAuditList" %>
<table cellpadding="2" cellspacing="2" style="width: 100%">
    <tr>
        <td style="width: 100%">
 <x:GridView ID="gvExpenseSheetAudit" runat="server" AutoGenerateColumns="False" Caption="<%$ Resources:TimeLive.Resource, Expense Sheet Audit %>" SkinID="xgridviewSkinEmployee" 
 Width="71%" PageSize="500"><Columns>
     <asp:TemplateField SortExpression="UpdateDate" HeaderText="<%$ Resources:TimeLive.Resource, Update Date %>">
         <edititemtemplate>
<asp:TextBox runat="server" Text='<%# Bind("UpdateDate") %>' id="TextBox1"></asp:TextBox>
</edititemtemplate>
<HeaderTemplate>
<asp:Label id="lblUpdateDate" runat="server" __designer:wfdid="w9" Text='<%# ResourceHelper.GetFromResource("Update Date") %>'></asp:Label> 
</HeaderTemplate>
         <itemtemplate>
<asp:Label runat="server" Text='<%# Bind("UpdateDate") %>' id="Label1"></asp:Label>
</itemtemplate>
         <itemstyle horizontalalign="Center" width="11%" />
     </asp:TemplateField>
<asp:BoundField DataField="PK" HeaderText="<%$ Resources:TimeLive.Resource, Id %>" Visible="False">
<FooterStyle HorizontalAlign="Center"></FooterStyle>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
</asp:BoundField>
<asp:TemplateField SortExpression="FieldName" HeaderText="<%$ Resources:TimeLive.Resource, Field Name %>">
<EditItemTemplate>
<asp:TextBox id="TextBox2" runat="server" __designer:wfdid="w8" Text='<%# Bind("FieldName") %>'></asp:TextBox> 
</EditItemTemplate>
<HeaderTemplate>
<asp:Label id="lblFieldName" runat="server" __designer:wfdid="w9" Text='<%# ResourceHelper.GetFromResource("Field Name") %>'></asp:Label> 
</HeaderTemplate>
<ItemTemplate>
<asp:Label id="lblFieldName" runat="server" __designer:wfdid="w7" Text='<%# Bind("FieldName") %>'></asp:Label> 
</ItemTemplate>
    <itemstyle width="10%" />
</asp:TemplateField>
<asp:TemplateField SortExpression="OldValue" HeaderText="<%$ Resources:TimeLive.Resource, Old Value %>"> 
<EditItemTemplate>
<asp:TextBox id="TextBox3" runat="server" Text='<%# Bind("OldValue") %>' __designer:wfdid="w16"></asp:TextBox> 
</EditItemTemplate>
<HeaderTemplate>
<asp:Label id="lblOldValue" runat="server" Text='<%# ResourceHelper.GetFromResource("Old Value") %>' __designer:wfdid="w17"></asp:Label> 
 
</HeaderTemplate>
<ItemTemplate>
<asp:Label id="lblOldValue" runat="server" Text='<%# Bind("OldValue") %>' __designer:wfdid="w15"></asp:Label> 
</ItemTemplate>

<ItemStyle HorizontalAlign="Left" width="18%"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField SortExpression="NewValue" HeaderText="<%$ Resources:TimeLive.Resource, New Value %>">
<EditItemTemplate>
<asp:TextBox id="TextBox4" runat="server" Text='<%# Bind("NewValue") %>' __designer:wfdid="w19"></asp:TextBox> 
</EditItemTemplate>
<HeaderTemplate>
<asp:Label id="lblNewValue" runat="server" Text='<%# ResourceHelper.GetFromResource("New Value") %>' __designer:wfdid="w20"></asp:Label> 

</HeaderTemplate>
<ItemTemplate>
<asp:Label id="lblNewValue" runat="server" Text='<%# Bind("NewValue") %>' __designer:wfdid="w18"></asp:Label> 
</ItemTemplate>

<ItemStyle HorizontalAlign="Left" width="18%"></ItemStyle>
</asp:TemplateField>
         <asp:TemplateField SortExpression="UpdateBy" HeaderText="<%$ Resources:TimeLive.Resource, Updated By %>">
             <EditItemTemplate>
                 <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("UpdateBy") %>'></asp:TextBox>
             </EditItemTemplate>
             <HeaderTemplate>
<asp:Label id="lblUpdateBy" runat="server" Text='<%# ResourceHelper.GetFromResource("Update By") %>' __designer:wfdid="w20"></asp:Label> 

</HeaderTemplate>
             <ItemTemplate>
                 <asp:Label ID="Label2" runat="server" Text='<%# Bind("UpdateBy") %>'></asp:Label>
             </ItemTemplate>
             <ItemStyle HorizontalAlign="Left" Width="14%" />
         </asp:TemplateField>
</Columns>
</x:GridView>
         <asp:ObjectDataSource ID="dsAccountEmployeeExpenseSheetAuditGridViewObject" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetAccountEmployeeExpenseSheetAuditByEmployeeExpenseSheetId" TypeName="AccountExpenseEntryAuditBLL">
            <SelectParameters>
                <asp:QueryStringParameter Name="AccountEmployeeExpenseSheetId" QueryStringField="AccountEmployeeExpenseSheetId"
                    Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
            <br />
<x:gridview id="gvExpenseEntryAudit" runat="server" autogeneratecolumns="False" caption="<%$ Resources:TimeLive.Resource, Expense Entry Audit %>"  skinid="xgridviewSkinEmployee"
    width="98%" PageSize="500"><Columns>
        <asp:TemplateField SortExpression="UpdateDate" HeaderText="<%$ Resources:TimeLive.Resource, Update Date %>">
            <edititemtemplate>
<asp:TextBox runat="server" Text='<%# Bind("UpdateDate") %>' id="TextBox1"></asp:TextBox>
</edititemtemplate>
<HeaderTemplate>
<asp:Label id="lblUpdateDate" runat="server" __designer:wfdid="w9" Text='<%# ResourceHelper.GetFromResource("Update Date") %>'></asp:Label>
</HeaderTemplate>
            <itemtemplate>
<asp:Label runat="server" Text='<%# Bind("UpdateDate") %>' id="Label1"></asp:Label>
</itemtemplate>
            <itemstyle horizontalalign="Center" width="11%" />
        </asp:TemplateField>
        <asp:TemplateField SortExpression="ProjectName" HeaderText="<%$ Resources:TimeLive.Resource, Project Name %>">
            <EditItemTemplate>
                <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("ProjectName") %>'></asp:TextBox>
            </EditItemTemplate>
            <HeaderTemplate>
<asp:Label id="lblProjectName" runat="server" Text='<%# ResourceHelper.GetFromResource("Project Name") %>' __designer:wfdid="w4"></asp:Label> 
</HeaderTemplate>
            <ItemTemplate>
                <asp:Label ID="Label2" runat="server" Text='<%# Bind("ProjectName") %>'></asp:Label>
            </ItemTemplate>
            <ItemStyle Width="10%" />
        </asp:TemplateField>
        <asp:TemplateField SortExpression="AccountExpenseName" HeaderText="<%$ Resources:TimeLive.Resource, Expense Name %>">
            <EditItemTemplate>
                <asp:TextBox ID="TextBox6" runat="server" 
                    Text='<%# Bind("AccountExpenseName") %>'></asp:TextBox>
            </EditItemTemplate>
            <HeaderTemplate>
<asp:Label id="lblExpenseName" runat="server" Text='<%# ResourceHelper.GetFromResource("Expense Name") %>' __designer:wfdid="w4"></asp:Label> 
</HeaderTemplate>
            <ItemTemplate>
                <asp:Label ID="Label3" runat="server" Text='<%# Bind("AccountExpenseName") %>'></asp:Label>
            </ItemTemplate>
            <ItemStyle Width="10%" />
        </asp:TemplateField>
        <asp:TemplateField SortExpression="Amount" HeaderText="<%$ Resources:TimeLive.Resource, Amount %>">
            <EditItemTemplate>
                <asp:TextBox ID="TextBox8" runat="server" Text='<%# Bind("Amount") %>'></asp:TextBox>
            </EditItemTemplate>
             <headertemplate>
<asp:Label id="lblAmount" runat="server" Text='<%# ResourceHelper.GetFromResource("Amount") %>' __designer:wfdid="w6"></asp:Label> 
                </headertemplate>
            <ItemTemplate>
                <asp:Label ID="lblAmount" runat="server" Text='<%# Bind("Amount", "{0:N}") %>'></asp:Label>
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Right" Width="5%" />
        </asp:TemplateField>
        <asp:BoundField DataField="PK" HeaderText="<%$ Resources:TimeLive.Resource, Id %>" Visible="False">
        </asp:BoundField>
        <asp:TemplateField SortExpression="FieldName" HeaderText="<%$ Resources:TimeLive.Resource, Field Name %>">
<EditItemTemplate>
<asp:TextBox id="TextBox2" runat="server" Text='<%# Bind("FieldName") %>' __designer:wfdid="w3"></asp:TextBox> 
</EditItemTemplate>
<HeaderTemplate>
<asp:Label id="lblFieldName" runat="server" Text='<%# ResourceHelper.GetFromResource("Field Name") %>' __designer:wfdid="w4"></asp:Label> 
</HeaderTemplate>
<ItemTemplate >
<asp:Label id="lblFieldName" runat="server" Text='<%# Bind("FieldName") %>' __designer:wfdid="w2"></asp:Label> 
</ItemTemplate>
    <itemstyle width="10%" />
</asp:TemplateField>
        <asp:TemplateField SortExpression="OldValue" HeaderText="<%$ Resources:TimeLive.Resource, Old Value %>">
<EditItemTemplate>
<asp:TextBox id="TextBox3" runat="server" Text='<%# Bind("OldValue") %>' __designer:wfdid="w6"></asp:TextBox> 
</EditItemTemplate>
<HeaderTemplate>
<asp:Label id="lblOldValue" runat="server" Text='<%# ResourceHelper.GetFromResource("Old Value") %>' __designer:wfdid="w7"></asp:Label> 
</HeaderTemplate>
<ItemTemplate>
<asp:Label id="lblOldValue" runat="server" Text='<%# Bind("OldValue") %>' __designer:wfdid="w5"></asp:Label> 
</ItemTemplate>

<ItemStyle HorizontalAlign="Left" width="19%"></ItemStyle>
</asp:TemplateField>
        <asp:TemplateField SortExpression="NewValue" HeaderText="<%$ Resources:TimeLive.Resource, New Value %>">
<EditItemTemplate>
<asp:TextBox id="TextBox4" runat="server" Text='<%# Bind("NewValue") %>' __designer:wfdid="w9"></asp:TextBox> 
</EditItemTemplate>
<HeaderTemplate>
<asp:Label id="lblNewValue" runat="server" Text='<%# ResourceHelper.GetFromResource("New Value") %>' __designer:wfdid="w10"></asp:Label> 
</HeaderTemplate>
<ItemTemplate>
<asp:Label id="lblNewValue" runat="server" Text='<%# Bind("NewValue") %>' __designer:wfdid="w8"></asp:Label> 
</ItemTemplate>

<ItemStyle HorizontalAlign="Left" width="19%"></ItemStyle>
</asp:TemplateField>
        <asp:TemplateField SortExpression="UpdatedBy" HeaderText="<%$ Resources:TimeLive.Resource, Updated By %>">
            <EditItemTemplate>
                <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("UpdatedBy") %>'></asp:TextBox>
            </EditItemTemplate>
            <HeaderTemplate>
<asp:Label id="lblUpdatedBy" runat="server" Text='<%# ResourceHelper.GetFromResource("Updated By") %>' __designer:wfdid="w10"></asp:Label> 
</HeaderTemplate>
            <ItemTemplate>
                <asp:Label ID="Label4" runat="server" Text='<%# Bind("UpdatedBy") %>'></asp:Label>
            </ItemTemplate>
            <ItemStyle Width="14%" />
        </asp:TemplateField>
</Columns>
</x:gridview>
<asp:ObjectDataSource ID="dsAccountExpenseEntryAuditGridViewObject" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetAccountExpenseEntryAuditByEmployeeExpenseSheetId" TypeName="AccountExpenseEntryAuditBLL">
    <SelectParameters>
        <asp:QueryStringParameter Name="AccountEmployeeExpenseSheetId" QueryStringField="AccountEmployeeExpenseSheetId" />
    </SelectParameters>
</asp:ObjectDataSource>
        </td>
    </tr>
</table>
