<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlAccountHolidaySelect.ascx.vb" Inherits="AccountAdmin_Controls_ctlAccountHolidaySelect" %>
<%@ Register Assembly="System.Web.Extensions" Namespace="System.Web.UI" TagPrefix="asp" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate>
<x:GridView id="GridView1" runat="server" AllowSorting="True" 
        AutoGenerateColumns="False" 
        Caption="<%$ Resources:TimeLive.Resource, Holiday List%>" CssClass="TableView" 
        DataSourceID="dsHolidaySelectObject" SkinID="xgridviewSkinEmployee" Width="98%" 
        DataKeyNames="MasterHolidayTypeId,HolidayType" 
        OnRowDataBound="GridView1_RowDataBound" OnDataBound="GridView1_DataBound"><Columns>
<asp:BoundField DataField="HolidayType" HeaderText="<%$ Resources:TimeLive.Resource, Holidays%>" SortExpression="HolidayType">
<ItemStyle Width="95%"></ItemStyle>
</asp:BoundField>
<asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Selected_text %>"><ItemTemplate>
<asp:CheckBox id="chkSelected" runat="server" __designer:wfdid="w5"></asp:CheckBox> 
</ItemTemplate>

<ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
</asp:TemplateField>
</Columns>

<HeaderStyle BorderColor="Black"></HeaderStyle>
</x:GridView>
        <table style="width: 98%">
            <tbody>
                <tr>
                    <td align="left" style="padding-top:5px;">&nbsp;<asp:Button id="btnAdd" onclick="btnAdd_Click" runat="server" 
        Width="60px" Text="<%$ Resources:TimeLive.Resource, Update_text%>" 
        UseSubmitBehavior="False"></asp:Button></td>
                </tr>
            </tbody>
        </table><asp:ObjectDataSource id="dsHolidaySelectObject" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetvueMasterHolidaySelect" TypeName="AccountHolidayTypeBLL" InsertMethod="AddAccountHolidaySelect"><InsertParameters>
<asp:Parameter Name="AccountId" Type="Int32"></asp:Parameter>
<asp:Parameter Name="MasterHolidayTypeId"></asp:Parameter>
<asp:Parameter Name="HolidayType" Type="String"></asp:Parameter>
<asp:Parameter Name="CreatedOn" Type="DateTime"></asp:Parameter>
<asp:Parameter Name="CreatedByEmployeeId" Type="Int32"></asp:Parameter>
<asp:Parameter Name="ModifiedOn" Type="DateTime"></asp:Parameter>
<asp:Parameter Name="ModifiedByEmployeeId" Type="Int32"></asp:Parameter>
</InsertParameters>
</asp:ObjectDataSource> 
</ContentTemplate>
</asp:UpdatePanel>
