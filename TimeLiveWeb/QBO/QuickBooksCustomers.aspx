<%@ Page Language="VB" AutoEventWireup="false" CodeFile="QuickBooksCustomers.aspx.vb" Inherits="QBO_QuickBooksCustomers" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head> 
<body> 
    <form id="form1" runat="server">
   <div>
        <h2>  
            QuickBooks Customer Data</h2> 
        <br />
        <button id="btnInsertIntoTimeLive" runat="server">Insert QB Customer into TimeLive</button>
        <button id="btnInsertIntoQB" runat="server">Insert TimeLive Customer into QB</button>
        <br />
        <button id="btnInsertEmployeeIntoTimeLive" runat="server">Insert QB Employee into TimeLive</button>
        <button id="btnInsertEmployeeIntoQB" runat="server">Insert TimeLive Employee into QB</button> 
                <br />
        <button id="btnInsertVendorIntoTimeLive" runat="server">Insert QB Vendor into TimeLive</button>
        <button id="btnInsertVendorIntoQB" runat="server">Insert TimeLive Vendor into QB</button> 
                        <br />
        <button id="btnInsertItemSubItemIntoTimeLive" runat="server">Insert QB Item/Sub-Item into Project/Task TimeLive</button>
        <button id="btnInsertItemSubItemIntoQB" runat="server">Insert TimeLive Project/Task into Item/Sub-Item QB</button>
         <br />
        <button id="btnInsertJobSubJobIntoTimeLive" runat="server">Insert QB Job/Sub-job into Project/Task TimeLive</button>
        <button id="btnInsertJobSubJobIntoQB" runat="server">Insert TimeLive Project/Task into Job/Sub-Job QB</button>
               <br />
        <button id="btnInsertJobItemIntoTimeLive" runat="server">Insert QB Job/Item into Project/Task TimeLive</button>
        <button id="btnInsertJobItemIntoQB" runat="server">Insert TimeLive Project/Task into Job/Item QB</button>

                <div style="overflow: auto; width: 100%" runat="server" id="GridLocation">
            <asp:GridView ID="grdQuickBooksCustomers" AutoGenerateColumns="False" runat="server"
                Width="900px" CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:TemplateField HeaderText="Customer Name">
                        <ItemTemplate>
                            <asp:Label ID="lblCustomerName" runat="server" Text='<%# Bind("DisplayName") %>'></asp:Label></ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Open Balance">
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("OpenBalance.Amount", "{0:C}") %>'></asp:Label></ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Overdue Balance">
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("OverDueBalance", "{0:C}") %>'></asp:Label></ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="NonProfit?">
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("NonProfit") %>'></asp:Label></ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
            </asp:GridView>
        </div>
        <br />
        <br />
    </div>
    <div runat="server" id="MessageLocation">
        No Customer Available.
        <br />
        <br />
        <a href="Default.aspx">Back to Home.</a>
    </div>
    </form>
</body>
</html>
