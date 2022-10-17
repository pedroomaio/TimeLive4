<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlAccountEmployeeDashboard.ascx.vb" Inherits="Employee_Controls_ctlAccountEmployeeDashboard" %>
<%@ Register assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2" namespace="eWorld.UI" tagprefix="ew" %>


<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
<body>
    <br />
    <table class="xFormView"><tr><td>
    <table class="xFormView" border="0" >
        <tr>
            <th class="caption" colspan="4">
                <asp:Label ID="Label1" runat="server"></asp:Label>
            </th>
        </tr>
        <tr>
            <th class="FormViewSubHeader" colspan="4">
                <asp:Label ID="Label2" runat="server"></asp:Label>
            </th>
        </tr>
      <%--  <tr>
            <td class="FormViewSubHeader" colspan="4">
                </td>
        </tr>--%>
        <tr>
            <th class="FormViewSubHeader" align="center" >
                <asp:Label ID="Label3" runat="server"></asp:Label>
            </th>
            <th class="FormViewSubHeader" align="center" colspan="2" dir="ltr" 
                valign="bottom">
                </th>
            <th class="FormViewSubHeader" align="center">
                <asp:Label ID="Label4" runat="server"></asp:Label>
            </th>
        </tr>
        <%--<tr>
            <th class="FormViewSubHeader">

                </th>
            <th class="FormViewSubHeader" colspan="2">

                </th>
            <th class="FormViewSubHeader">

                </th>
        </tr>--%>
        <tr>
            <th class="FormViewSubheader" style="width: 275px" height="280%" width="280%">
                <asp:ListBox ID="AvailableListBox" runat="server" 
                    DataSourceID="ObjectSystemEmployeeDashboardListBox" 
                    DataTextField="SystemEmployeeDashboardName" 
                    DataValueField="SystemEmployeeDashboardId" Height="350px" Rows="8" 
                    SelectionMode="Multiple" Width="280px" CssClass="listbox"></asp:ListBox>

            </th>
            <th valign="middle" class="FormViewSubHeader" align="center">
                <ew:ListTransfer ID="LtMoveRight" runat="server" 
                    ImageUrl="~/Images/rightArrow.gif" Text="Move Right" 
                    TransferFromID="AvailableListBox" TransferToID="SelectedListBox" 
                    TransferType="Control" ClientIDMode="Static" />
                <br />
                <br />
                <ew:ListTransfer ID="LtMoveLeft" runat="server" 
                    ImageUrl="~/Images/LeftArrow.gif" Text="Move Left" 
                    TransferFromID="SelectedListBox" TransferToID="AvailableListBox" 
                    TransferType="Control" />
            </th>

        <th valign="top" align="justify">
           <%-- <ew:ListTransfer ID="ListTransfer1" runat ="server" 
                Text = "<%$ Resources:TimeLive.Resource, Move Up %>" TransferType="Up" 
                TransferFromID="SelectedListBox" ImageUrl="~/Images/UpArrow.gif" 
                Visible="False" />
            <br />
            <br />
            <ew:ListTransfer ID="ListTransfer2" runat ="server" 
                Text = "<%$ Resources:TimeLive.Resource, Move Down %>" TransferType="Down" 
                TransferFromID="SelectedListBox" ImageUrl="~/Images/DownArrow.gif" 
                Visible="False" />--%>
        </th>
            <th class="style1" valign="top" height="280%">
                <asp:ListBox ID="SelectedListBox" runat="server" 
                    DataSourceID="ObjectAccountEmployeeDashboardListBox" 
                    DataTextField="SystemEmployeeDashboardName" 
                    DataValueField="SystemEmployeeDashboardId" Height="350px" Rows="8" 
                    SelectionMode="Multiple" Width="280px" CssClass="listbox"></asp:ListBox>

            </th>
        </tr>
    </table>
    </td></tr></table>
    <table style="width: 626px">
                <tr>
                    <td width="98%" align="right">
                        <asp:Button ID="Save" runat="server" CommandName="Update" 
                            Text="<%$ Resources:TimeLive.Resource, Update_text%> " Width="68px" />
                        <asp:Button ID="Button3" runat="server" CommandName="Cancel" 
                            Text="<%$ Resources:TimeLive.Resource, Cancel_text%> " Width="68px" />
                    </td>
                </tr>
    </table>
    <body>

        <asp:ObjectDataSource 
                ID="ObjectSystemEmployeeDashboardListBox" runat="server" 
                OldValuesParameterFormatString="original_{0}" 
                SelectMethod="GetSystemEmployeeDashboard" 
                TypeName="AccountEmployeeDashboardBLL" DataObjectTypeName="System.Guid" 
                DeleteMethod="DeleteAccountEmployeeDashboard" 
                UpdateMethod="UpdateAccountEmployeeDashboard">
                <UpdateParameters>
                    <asp:Parameter Name="AccountId" Type="Int32" />
                    <asp:Parameter Name="AccountEmployeeId" Type="Int32" />
                    <asp:Parameter DbType="Guid" Name="SystemEmployeeDashboardId" />
                    <asp:Parameter DbType="Guid" Name="Original_AccountEmployeeDashboardId" />
                    <asp:Parameter Name="SortOrder" Type="Int32" />
                </UpdateParameters>
            </asp:ObjectDataSource>
            <asp:ObjectDataSource ID="ObjectAccountEmployeeDashboardListBox0" runat="server" 
                InsertMethod="AddAccountEmployeeDashboard" 
                OldValuesParameterFormatString="original_{0}" 
                SelectMethod="GetDataByEmployeeId" 
                TypeName="AccountEmployeeDashboardBLL" 
                UpdateMethod="UpdateAccountEmployeeDashboard" 
                DataObjectTypeName="System.Guid" 
                DeleteMethod="DeleteAccountEmployeeDashboard">
                <InsertParameters>
                    <asp:Parameter Name="AccountId" Type="Int32" />
                    <asp:Parameter Name="AccountEmployeeId" Type="Int32" />
                    <asp:Parameter DbType="Guid" Name="SystemEmployeeDashboardId" />
                    <asp:Parameter Name="IsPanelView" Type="Boolean" />
                    <asp:Parameter Name="SortOrder" Type="Int32" />
                </InsertParameters>
                <SelectParameters>
                    <asp:SessionParameter Name="AccountId" SessionField="AccountId" Type="Int32" />
                    <asp:SessionParameter Name="AccountEmployeeId" SessionField="AccountEmployeeId" 
                        Type="Int32" />
                    <asp:Parameter DefaultValue="True" Name="IsPanelView" Type="Boolean" />
                </SelectParameters>
                <UpdateParameters>
                    <asp:Parameter Name="AccountId" Type="Int32" />
                    <asp:Parameter Name="AccountEmployeeId" Type="Int32" />
                    <asp:Parameter DbType="Guid" Name="SystemEmployeeDashboardId" />
                    <asp:Parameter DbType="Guid" Name="Original_AccountEmployeeDashboardId" />
                    <asp:Parameter Name="SortOrder" Type="Int32" />
                </UpdateParameters>
            </asp:ObjectDataSource>
              <asp:ObjectDataSource ID="ObjectAccountEmployeeDashboardListBox" 
        runat="server" DataObjectTypeName="System.Guid" 
        DeleteMethod="DeleteAccountEmployeeDashboard" 
        InsertMethod="AddAccountEmployeeDashboard" 
        OldValuesParameterFormatString="original_{0}" 
        SelectMethod="GetDataByEmployeeId" TypeName="AccountEmployeeDashboardBLL" 
        UpdateMethod="UpdateAccountEmployeeDashboard">
                  <InsertParameters>
                      <asp:Parameter Name="AccountId" Type="Int32" />
                      <asp:Parameter Name="AccountEmployeeId" Type="Int32" />
                      <asp:Parameter DbType="Guid" Name="SystemEmployeeDashboardId" />
                      <asp:Parameter Name="IsPanelView" Type="Boolean" />
                      <asp:Parameter Name="SortOrder" Type="Int32" />
                  </InsertParameters>
                  <SelectParameters>
                      <asp:SessionParameter DefaultValue="151" Name="AccountId" 
                          SessionField="AccountId" Type="Int32" />
                      <asp:SessionParameter DefaultValue="" Name="AccountEmployeeId" 
                          SessionField="AccountEmployeeId" Type="Int32" />
                      <asp:Parameter DefaultValue="False" Name="IsPanelView" Type="Boolean" />
                  </SelectParameters>
                  <UpdateParameters>
                      <asp:Parameter Name="AccountId" Type="Int32" />
                      <asp:Parameter Name="AccountEmployeeId" Type="Int32" />
                      <asp:Parameter DbType="Guid" Name="SystemEmployeeDashboardId" />
                      <asp:Parameter DbType="Guid" Name="Original_AccountEmployeeDashboardId" />
                      <asp:Parameter Name="SortOrder" Type="Int32" />
                  </UpdateParameters>
    </asp:ObjectDataSource>
              </ContentTemplate>
    </asp:UpdatePanel>

             