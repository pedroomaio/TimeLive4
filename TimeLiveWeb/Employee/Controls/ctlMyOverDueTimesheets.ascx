<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlMyOverDueTimesheets.ascx.vb" Inherits="Employee_Controls_ctlMyOverDueTimesheets" %>


        <x:GridView ID="G" runat="server" AllowSorting="True" 
            AutoGenerateColumns="False" 
            Caption='<%# ResourceHelper.GetFromResource("My OverDue TimeSheet") %>' 
            DataSourceID="dsOverDueTimesheetGridViewObject" EnableViewState="False" 
            SkinID="xgridviewSkinEmployee" Width="99%">
        </x:GridView>
        <asp:ObjectDataSource ID="dsOverDueTimesheetGridViewObject" runat="server" 
            OldValuesParameterFormatString="original_{0}" 
            SelectMethod="GetTimesheetOverdueByAccountEmployeeId" 
            TypeName="OverDueTimesheetsBLL">
            <SelectParameters>
                <asp:SessionParameter Name="AccountId" SessionField="AccountId" Type="Int32" />
                <asp:SessionParameter Name="AccountEmployeeId" SessionField="AccountEmployeeId" 
                    Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
