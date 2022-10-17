<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlAccountHolidayTypes.ascx.vb" Inherits="Controls_ctlAccountHolidayTypes" %>
<%@ Register Assembly="System.Web.Extensions" Namespace="System.Web.UI" TagPrefix="asp" %>

<asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate>
<x:GridView id="GridView1" runat="server" OnRowDeleting="GridView1_RowDeleting" OnRowDeleted="GridView1_RowDeleted" OnRowCommand="GridView1_RowCommand" DataKeyNames="AccountHolidayTypeId" Width="98%" CssClass="TableView" Caption="<%$ Resources:TimeLive.Resource, Holiday Type List%>" SkinID="xgridviewSkinEmployee" AllowSorting="True" DataSourceID="dsAccountHolidayTypeGrid" AutoGenerateColumns="False"><Columns>
<asp:BoundField DataField="AccountHolidayType" HeaderText="<%$ Resources:TimeLive.Resource, Holiday Type %>" SortExpression="AccountHolidayType">
<ItemStyle Width="92%"></ItemStyle>
</asp:BoundField>
<asp:TemplateField><ItemTemplate>
<asp:HyperLink id="HyperLink1" runat="server" NavigateUrl='<%# Eval("AccountHolidayTypeId", "~/AccountAdmin/AccountHolidayTypeDetail.aspx?AccountHolidayTypeId={0}") %>' Text="<%$ Resources:TimeLive.Resource, Holidays%>" Visible='<%# IIF(Isdbnull(Eval("AccountHolidayTypeId")),"False","True") %>' __designer:wfdid="w44"></asp:HyperLink>
</ItemTemplate>

<ItemStyle HorizontalAlign="Center" Width="3%"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField ShowHeader="False" HeaderText="Edit"><ItemTemplate>
<asp:LinkButton id="LinkButton2" runat="server" Text="Edit" Visible='<%# IIF(Isdbnull(Eval("AccountHolidayTypeId")),"False","True") %>' __designer:wfdid="w45" CommandName="Select" CausesValidation="False"></asp:LinkButton>
</ItemTemplate>

<ItemStyle HorizontalAlign="Center" CssClass="edit_button" Width="1%"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField ShowHeader="False" HeaderText="Delete"><ItemTemplate>
<asp:LinkButton id="LinkButton1" runat="server" Visible='<%# IIF(Isdbnull(Eval("AccountHolidayTypeId")),"False","True") %>' __designer:wfdid="w46" CommandName="Delete" CausesValidation="False" OnClientClick="<%# ResourceHelper.GetDeleteMessageJavascript() %>"></asp:LinkButton>
</ItemTemplate>

<ItemStyle HorizontalAlign="Center" CssClass="delete_button" Width="1%"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField><HeaderTemplate>
<asp:Image id="Image1" runat="server" __designer:wfdid="w48" ImageUrl="~/Images/Disabled.gif" ToolTip="<%$ Resources:TimeLive.Resource, Disabled_text%> "></asp:Image>
</HeaderTemplate>
<ItemTemplate>
<asp:Image id="Image1" runat="server" Visible='<%# IIF(IsDBNull(Eval("IsDisabled")),"false",Eval("IsDisabled")) %>' __designer:wfdid="w47" ImageUrl="~/Images/Disabled.gif" ToolTip="<%$ Resources:TimeLive.Resource, Disabled_text%> "></asp:Image>
</ItemTemplate>

<ItemStyle HorizontalAlign="Center" Width="1%"></ItemStyle>
</asp:TemplateField>
</Columns>

<HeaderStyle BorderColor="Black"></HeaderStyle>
</x:GridView><asp:ObjectDataSource id="dsAccountHolidayTypeGrid" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetvueAccountHolidayTypeByAccountId" TypeName="AccountHolidayTypeBLL"><SelectParameters>
<asp:SessionParameter SessionField="AccountId" DefaultValue="66" Name="AccountId" Type="Int32"></asp:SessionParameter>
</SelectParameters>
</asp:ObjectDataSource> <asp:ObjectDataSource id="dsAccountHolidayTypeFormObject" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetAccountHolidayTypeByAccountHolidayTypeId" TypeName="AccountHolidayTypeBLL" OnUpdated="dsAccountHolidayTypeFormObject_Updated" InsertMethod="AddAccountHolidayType" UpdateMethod="UpdateAccountHolidayType" OnInserted="dsAccountHolidayTypeFormObject_Inserted" OnUpdating="dsAccountHolidayTypeFormObject_Updating"><UpdateParameters>
<asp:SessionParameter SessionField="AccountId" DefaultValue="55" Name="AccountId" Type="Int32"></asp:SessionParameter>
<asp:Parameter Name="Original_AccountHolidayTypeId"></asp:Parameter>
<asp:Parameter Name="AccountHolidayType" Type="String"></asp:Parameter>
<asp:Parameter Name="IsDisabled" Type="Boolean"></asp:Parameter>
<asp:Parameter Name="CreatedOn" Type="DateTime"></asp:Parameter>
<asp:Parameter Name="CreatedByEmployeeId" Type="Int32"></asp:Parameter>
<asp:Parameter Name="ModifiedOn" Type="DateTime"></asp:Parameter>
<asp:Parameter Name="ModifiedByEmployeeId" Type="Int32"></asp:Parameter>
</UpdateParameters>
<SelectParameters>
<asp:SessionParameter SessionField="AccountId" DefaultValue="66" Name="AccountId" Type="Int32"></asp:SessionParameter>
<asp:ControlParameter ControlID="GridView1" PropertyName="SelectedValue" Name="AccountHolidayTypeId"></asp:ControlParameter>
</SelectParameters>
<InsertParameters>
<asp:SessionParameter SessionField="AccountId" DefaultValue="33" Name="AccountId" Type="Int32"></asp:SessionParameter>
<asp:Parameter Name="AccountHolidayType" Type="String"></asp:Parameter>
<asp:Parameter Name="CreatedOn" Type="DateTime"></asp:Parameter>
<asp:Parameter Name="CreatedByEmployeeId" Type="Int32"></asp:Parameter>
<asp:Parameter Name="ModifiedOn" Type="DateTime"></asp:Parameter>
<asp:Parameter Name="ModifiedByEmployeeId" Type="Int32"></asp:Parameter>
</InsertParameters>
</asp:ObjectDataSource>
</ContentTemplate>
</asp:UpdatePanel><br />
<asp:UpdatePanel ID="UpdatePanel2" runat="server"><ContentTemplate>
<asp:FormView id="FormView1" runat="server" DataKeyNames="AccountHolidayTypeId" 
        Width="550px" SkinID="formviewSkinEmployee" 
        DataSourceID="dsAccountHolidayTypeFormObject" 
        OnItemCommand="FormView1_ItemCommand" DefaultMode="Insert" 
        OnDataBound="FormView1_DataBound"><EditItemTemplate>
<TABLE style="WIDTH: 100%" class="xview"><TBODY>
<TR><TH class="caption" width="30%" colSpan=2><asp:Literal id="Literal1" runat="server" Text='<%# ResourceHelper.GetFromResource("Holiday Type Information")%> '></asp:Literal></TH></TR>
<TR><Th class="FormViewSubHeader" width="30%" colSpan=2><asp:Literal id="Literal3" runat="server" Text='<%# ResourceHelper.GetFromResource("Holiday Type")%> '></asp:Literal></Th></TR>
<TR><TD class="FormViewLabelCell" align=right width="30%">
<asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="HolidayTypeNameTextBox">
<asp:Literal id="Literal4" runat="server" Text="<%$ Resources:TimeLive.Resource, Holiday Type:%>"></asp:Literal></asp:Label></TD>
<TD width="70%"><asp:TextBox id="HolidayTypeNameTextBox" runat="server" Width="176px" Text='<%# Bind("AccountHolidayType") %>' MaxLength="200"></asp:TextBox> <asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" Width="1px" Display="Dynamic" ErrorMessage="*" ControlToValidate="HolidayTypeNameTextBox"></asp:RequiredFieldValidator></TD></TR><TR><TD style="HEIGHT: 26px" class="FormViewLabelCell" align=right width="30%"><asp:Literal id="Literal5" runat="server" Text="<%$ Resources:TimeLive.Resource, Disabled:%> "></asp:Literal></TD><TD width="70%"><asp:CheckBox id="IsDisabledCheckBox" runat="server" Width="168px" Checked='<%# Bind("IsDisabled") %>'></asp:CheckBox></TD></TR><TR><TD width="30%"></TD>
<TD width="70%" style="padding-bottom: 5px;"><asp:Button id="Button1" runat="server" Width="68px" Text="<%$ Resources:TimeLive.Resource, Update_Text%> " CommandName="Update"></asp:Button>&nbsp
<asp:Button id="Button2" runat="server" Width="68px" Text="<%$ Resources:TimeLive.Resource, Cancel_Text%> " CommandName="Cancel"></asp:Button></TD></TR></TBODY></TABLE>
</EditItemTemplate>
<InsertItemTemplate>
<TABLE style="WIDTH: 100%" class="xview"><TBODY>
<TR><Th class="caption" colSpan=2>
<asp:Literal id="Literal1" runat="server" Text='<%# ResourceHelper.GetFromResource("Holiday Type Information")%> '></asp:Literal></asp:Label></TH></TR>
<TR><TH class="FormViewSubHeader" colSpan=2><asp:Literal id="Literal2" runat="server" Text='<%# ResourceHelper.GetFromResource("Holiday Type")%> '></asp:Literal></TH></TR>
<TR><TD class="FormViewLabelCell" align=right colSpan=1 rowSpan=1>
<asp:Label ID="Label1" runat="server" AssociatedControlID="HolidayTypeNameTextBox">
<asp:Literal id="Literal3" runat="server" Text="<%$ Resources:TimeLive.Resource, Holiday Type:%>"></asp:Literal></TD></asp:Label><TD><asp:TextBox id="HolidayTypeNameTextBox" runat="server" Width="176px" Text='<%# Bind("AccountHolidayType") %>' MaxLength="200"></asp:TextBox> 
<asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" Width="1px" Display="Dynamic" ErrorMessage="*" ControlToValidate="HolidayTypeNameTextBox"></asp:RequiredFieldValidator></TD></TR><TR><TD></TD>
<TD style="padding-bottom: 5px;"><asp:Button id="btnAdd" runat="server" Width="68px" Text="<%$ Resources:TimeLive.Resource, Add_Text%> " CommandName="Insert"></asp:Button></TD></TR></TBODY></TABLE>
</InsertItemTemplate>
<InsertRowStyle BorderColor="Black" BorderWidth="1px" BorderStyle="Solid"></InsertRowStyle>
</asp:FormView> 
</ContentTemplate>
</asp:UpdatePanel>

