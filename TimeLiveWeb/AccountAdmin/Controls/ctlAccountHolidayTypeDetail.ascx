<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlAccountHolidayTypeDetail.ascx.vb" Inherits="AccountAdmin_Controls_ctlAccountHolidayTypeDetail" %>
<%@ Register Assembly="System.Web.Extensions" Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2"
    Namespace="eWorld.UI" TagPrefix="ew" %>
<%@ Register Assembly="eWorld.UI.Compatibility, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2"
    Namespace="eWorld.UI.Compatibility" TagPrefix="cc1" %>

<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
<div class="fieldset" style="width: 96%; margin-left: 6px;" align="left">
      <table class="xFormView" width="98%">
    <tr>
        <td width="75px">
            <asp:Label ID="Label5" runat="server" Text="<%$ Resources:TimeLive.Resource, Holiday Year: %>" 
            Font-Bold="True" Font-Size="11px" Width="75px" CssClass="HighlightedText"/>
        </td>
        <td width="152px" align="left">
            <asp:DropDownList ID="ddlHolidayYear" runat="server" DataSourceID="dsHolidayYearObject"
                DataTextField="HolidayDate" DataValueField="HolidayDate" Width="150px" AutoPostBack="True">
            </asp:DropDownList>
        </td>
        <td align="left">
            <asp:Button ID="btnCopyHolidays" runat="server" 
            Text="Copy Holidays to Next Year" />
        </td>
    </tr>
</table>
        </div>
<asp:ObjectDataSource id="dsHolidayYearObject" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetHolidayYearByAccountIdandAccountHolidayTypeId" TypeName="AccountHolidayTypeBLL"><SelectParameters>
<asp:SessionParameter SessionField="AccountId" Name="AccountId" Type="Int32"></asp:SessionParameter>
<asp:QueryStringParameter QueryStringField="AccountHolidayTypeId" Name="AccountHolidayTypeId"></asp:QueryStringParameter>
</SelectParameters>
</asp:ObjectDataSource><x:GridView id="GridView1" runat="server" Width="98%" DataSourceID="dsAccountHolidayTypeDetailObject" OnRowDeleted="GridView1_RowDeleted" OnRowDeleting="GridView1_RowDeleting" OnRowCommand="GridView1_RowCommand" AllowSorting="True" AutoGenerateColumns="False" Caption="<%$ Resources:TimeLive.Resource, Holiday List%>" CssClass="TableView" DataKeyNames="AccountHolidayTypeDetailId,AccountHolidayTypeId,HolidayDate,Year" SkinID="xgridviewSkinEmployee"><Columns>
<asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Year %>" SortExpression="HolidayDate"><EditItemTemplate>
<asp:TextBox id="TextBox2" runat="server" __designer:wfdid="w17" Text='<%# Bind("HolidayDate") %>'></asp:TextBox>
</EditItemTemplate>
<ItemTemplate>
<asp:Label id="Label2" runat="server" __designer:wfdid="w16" Text='<%# Bind("HolidayDate", "{0:yyyy}") %>'></asp:Label>
</ItemTemplate>

<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%"></ItemStyle>
</asp:TemplateField>
<asp:BoundField DataField="HolidayName" HeaderText="<%$ Resources:TimeLive.Resource, Holiday Name %>" SortExpression="HolidayName">
<ItemStyle Width="86%"></ItemStyle>
</asp:BoundField>
<asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Date %>" SortExpression="HolidayDate"><EditItemTemplate>
<asp:TextBox id="TextBox1" runat="server" __designer:wfdid="w19" Text='<%# Bind("HolidayDate") %>'></asp:TextBox>
</EditItemTemplate>
<ItemTemplate>
<asp:Label id="Label1" runat="server" __designer:wfdid="w18" Text='<%# Bind("HolidayDate", "{0:d}") %>'></asp:Label>
</ItemTemplate>

<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField ShowHeader="False" HeaderText="Edit"><ItemTemplate>
<asp:LinkButton id="LinkButton2" runat="server" __designer:wfdid="w20" Text="Edit" CommandName="Select" Visible='<%# IIF(Isdbnull(Eval("AccountHolidayTypeDetailId")),"False","True") %>' CausesValidation="False"></asp:LinkButton>
</ItemTemplate>

<ItemStyle HorizontalAlign="Center" CssClass="edit_button" Width="1%"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField ShowHeader="False" HeaderText="Delete"><ItemTemplate>
<asp:LinkButton id="LinkButton1" runat="server" __designer:wfdid="w21" CommandName="Delete" Visible='<%# IIF(Isdbnull(Eval("AccountHolidayTypeDetailId")),"False","True") %>' CausesValidation="False" OnClientClick="<%# ResourceHelper.GetDeleteMessageJavascript() %>"></asp:LinkButton>
</ItemTemplate>

<ItemStyle HorizontalAlign="Center" CssClass="delete_button" Width="1%"></ItemStyle>
</asp:TemplateField>
</Columns>

<HeaderStyle BorderColor="Black"></HeaderStyle>
</x:GridView> 
    <asp:ObjectDataSource id="dsAccountHolidayTypeDetailObject" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetvueAccountHolidayTypeDetailByAccountHolidayTypeIdandHolidayYear" TypeName="AccountHolidayTypeBLL" InsertMethod="AddAccountHolidayTypeDetail" UpdateMethod="UpdateAccountHolidayTypeDetail"><UpdateParameters>
<asp:Parameter Name="Original_AccountHolidayTypeDetailId"></asp:Parameter>
<asp:Parameter Name="HolidayName" Type="String"></asp:Parameter>
<asp:Parameter Name="AccountId" Type="Int32"></asp:Parameter>
<asp:Parameter Name="Original_AccountHolidayTypeId"></asp:Parameter>
<asp:Parameter Name="HolidayDate" Type="DateTime"></asp:Parameter>
<asp:Parameter Name="Original_HolidayDate" Type="DateTime"></asp:Parameter>
</UpdateParameters>
<SelectParameters>
<asp:SessionParameter SessionField="AccountId" DefaultValue="66" Name="AccountId" Type="Int32"></asp:SessionParameter>
<asp:QueryStringParameter QueryStringField="AccountHolidayTypeId" Name="AccountHolidayTypeId"></asp:QueryStringParameter>
<asp:ControlParameter ControlID="ddlHolidayYear" PropertyName="SelectedValue" Name="Year" Type="String"></asp:ControlParameter>
</SelectParameters>
<InsertParameters>
<asp:Parameter Name="AccountHolidayTypeId"></asp:Parameter>
<asp:Parameter Name="AccountId" Type="Int32"></asp:Parameter>
<asp:Parameter Name="HolidayName" Type="String"></asp:Parameter>
<asp:Parameter Name="HolidayDate" Type="DateTime"></asp:Parameter>
</InsertParameters>
</asp:ObjectDataSource> <asp:ObjectDataSource id="dsAccountHolidayTypeDetailFormViewObject" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetAccountHolidayTypeDetailByAccountHolidayTypeDetailId" TypeName="AccountHolidayTypeBLL" InsertMethod="AddAccountHolidayTypeDetail" UpdateMethod="UpdateAccountHolidayTypeDetail" OnInserting="dsAccountHolidayTypeDetailFormViewObject_Inserting" OnInserted="dsAccountHolidayTypeDetailFormViewObject_Inserted" OnUpdated="dsAccountHolidayTypeDetailFormViewObject_Updated"><UpdateParameters>
<asp:ControlParameter ControlID="GridView1" PropertyName="SelectedValue" Name="Original_AccountHolidayTypeDetailId"></asp:ControlParameter>
<asp:Parameter Name="HolidayName" Type="String"></asp:Parameter>
<asp:SessionParameter SessionField="AccountId" DefaultValue="66" Name="AccountId" Type="Int32"></asp:SessionParameter>
<asp:Parameter Name="Original_AccountHolidayTypeId"></asp:Parameter>
<asp:Parameter Name="HolidayDate" Type="DateTime"></asp:Parameter>
<asp:Parameter Name="Original_HolidayDate" Type="DateTime"></asp:Parameter>
<asp:Parameter Name="CreatedOn" Type="DateTime"></asp:Parameter>
<asp:Parameter Name="CreatedByEmployeeId" Type="Int32"></asp:Parameter>
<asp:Parameter Name="ModifiedOn" Type="DateTime"></asp:Parameter>
<asp:Parameter Name="ModifiedByEmployeeId" Type="Int32"></asp:Parameter>
</UpdateParameters>
<SelectParameters>
<asp:ControlParameter ControlID="GridView1" PropertyName="SelectedValue" Name="AccountHolidayTypeDetailId"></asp:ControlParameter>
</SelectParameters>
<InsertParameters>
<asp:QueryStringParameter QueryStringField="AccountHolidayTypeId" Name="AccountHolidayTypeId"></asp:QueryStringParameter>
<asp:SessionParameter SessionField="AccountId" DefaultValue="66" Name="AccountId" Type="Int32"></asp:SessionParameter>
<asp:Parameter Name="HolidayName" Type="String"></asp:Parameter>
<asp:Parameter DefaultValue="" Name="HolidayDate" Type="DateTime"></asp:Parameter>
<asp:Parameter Name="CreatedOn" Type="DateTime"></asp:Parameter>
<asp:Parameter Name="CreatedByEmployeeId" Type="Int32"></asp:Parameter>
<asp:Parameter Name="ModifiedOn" Type="DateTime"></asp:Parameter>
<asp:Parameter Name="ModifiedByEmployeeId" Type="Int32"></asp:Parameter>
</InsertParameters>
</asp:ObjectDataSource> 
    </ContentTemplate>
</asp:UpdatePanel>
<br />
<asp:UpdatePanel ID="UpdatePanel2" runat="server"><ContentTemplate>
<asp:FormView id="FormView1" runat="server" SkinID="formviewSkinEmployee" 
        DataKeyNames="AccountHolidayTypeId,AccountHolidayTypeDetailId,HolidayDate" 
        DataSourceID="dsAccountHolidayTypeDetailFormViewObject" Width="550px" 
        OnDataBound="FormView1_DataBound" OnItemCommand="FormView1_ItemCommand" 
        DefaultMode="Insert" CssClass="xview"><EditItemTemplate>
<TABLE style="WIDTH: 100%" class="xview"><TBODY><TR><Th class="caption" width="30%" colSpan=2><asp:Literal id="Literal1" runat="server" Text='<%# ResourceHelper.GetFromResource("Holiday Information")%> '></asp:Literal></Th></TR>
<TR><TH class="FormViewSubHeader" width="30%" colSpan=2><asp:Literal id="Literal3" runat="server" Text='<%# ResourceHelper.GetFromResource("Holiday")%> '>
</asp:Literal></Th></TR><TR><TD class="FormViewLabelCell" align=right width="30%"><asp:Literal id="Literal11" runat="server" Text='<%# ResourceHelper.GetFromResource("Holiday Date:")%> '></asp:Literal></TD><TD style="WIDTH: 70%; HEIGHT: 26px" width="70%">
        <ew:CalendarPopup id="HolidayDate" runat="server" 
            SelectedValue='<%# Bind("HolidayDate") %>' PostedDate="9/27/2006" 
            SkinId="DatePicker" SelectedDate="09/27/2006 17:09:05" 
            UpperBoundDate="12/31/9999 23:59:59" Width="55px"></ew:CalendarPopup></TD></TR><TR><TD class="FormViewLabelCell" align=right width="30%"><asp:Literal id="Literal4" runat="server" Text="<%$ Resources:TimeLive.Resource, Holiday Name:%>">
</asp:Literal></TD><TD style="WIDTH: 70%; HEIGHT: 26px" width="70%"><asp:TextBox id="HolidayNameTextBox" runat="server" Width="176px" Text='<%# Bind("HolidayName") %>' MaxLength="200"></asp:TextBox> <asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" Width="1px" ControlToValidate="HolidayNameTextBox" ErrorMessage="*" Display="Dynamic"></asp:RequiredFieldValidator></TD></TR><TR><TD width="30%"></TD>
<TD width="70%" style="padding-bottom: 5px;">
<asp:Button id="Button1" runat="server" Width="68px" Text="<%$ Resources:TimeLive.Resource, Update_Text%> " CommandName="Update"></asp:Button>&nbsp;<asp:Button id="Button2" runat="server" Width="68px" Text="<%$ Resources:TimeLive.Resource, Cancel_Text%> " CommandName="Cancel"></asp:Button></TD></TR></TBODY></TABLE>
</EditItemTemplate>
<InsertItemTemplate>
<TABLE style="WIDTH: 100%" class="xview"><TBODY>
<TR><Th class="caption" colSpan=2><asp:Literal id="Literal1" runat="server" Text="<%$ Resources:TimeLive.Resource, Holiday Information%>">
</asp:Literal></Th></TR>
<TR><Th class="FormViewSubHeader" colSpan=2><asp:Literal id="Literal2" runat="server" Text="<%$ Resources:TimeLive.Resource, Holiday%>">
</asp:Literal></Th></TR><TR><TD class="FormViewLabelCell" align=right colSpan=1 rowSpan=1><asp:Literal id="Literal11" runat="server" Text='<%# ResourceHelper.GetFromResource("Holiday Date:")%> '></asp:Literal></TD><TD style="WIDTH: 70%; HEIGHT: 26px">
        <ew:CalendarPopup id="HolidayDate" runat="server" 
            SelectedValue='<%# Bind("HolidayDate") %>' PostedDate="8/16/2010" 
            SkinId="DatePicker" SelectedDate="08/16/2010 13:12:05" Width="55px"></ew:CalendarPopup></TD></TR><TR><TD class="FormViewLabelCell" vAlign=middle align=right colSpan=1 rowSpan=1><asp:Literal id="Literal3" runat="server" Text="<%$ Resources:TimeLive.Resource, Holiday Name:%>">
</asp:Literal></TD><TD style="WIDTH: 70%; HEIGHT: 26px"><asp:TextBox id="HolidayNameTextBox" runat="server" Width="176px" Text='<%# Bind("HolidayName") %>' MaxLength="200"></asp:TextBox> <asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" Width="1px" ControlToValidate="HolidayNameTextBox" ErrorMessage="*" Display="Dynamic"></asp:RequiredFieldValidator></TD></TR><TR><TD></TD>
<TD style="WIDTH: 179px; padding-bottom: 5px;"><asp:Button id="btnAdd" runat="server" Width="68px" Text="<%$ Resources:TimeLive.Resource, Add_Text%> " CommandName="Insert"></asp:Button></TD></TR></TBODY></TABLE>
</InsertItemTemplate>

<InsertRowStyle BorderColor="Black" BorderWidth="1px" BorderStyle="Solid"></InsertRowStyle>
</asp:FormView> 
</ContentTemplate>
</asp:UpdatePanel>
