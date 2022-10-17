<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlMyDueTimesheets.ascx.vb" Inherits="Employee_Controls_ctlMyDueTimesheets" %>


        <asp:GridView ID="DueGV" runat="server" AllowSorting="True" 
            AutoGenerateColumns="False" 
            Caption='<%# ResourceHelper.GetFromResource("My Due TimeSheet") %>' 
            DataSourceID="dsDueGridViewObject" EnableViewState="False" 
            CssClass="xGridViewDB" Width="99%">
        </asp:GridView>
        <asp:ObjectDataSource ID="dsDueGridViewObject" runat="server" 
            OldValuesParameterFormatString="original_{0}" 
            SelectMethod="GetTimesheetDueByAccountEmployeeId" 
            TypeName="OverDueTimesheetsBLL">
            <SelectParameters>
                <asp:SessionParameter Name="AccountId" SessionField="AccountId" Type="Int32" />
                <asp:SessionParameter Name="AccountEmployeeId" SessionField="AccountEmployeeId" 
                    Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>









