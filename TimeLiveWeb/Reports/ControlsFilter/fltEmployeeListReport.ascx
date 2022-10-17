<%@ Control Language="VB" AutoEventWireup="false" CodeFile="fltEmployeeListReport.ascx.vb" Inherits="Reports_ControlsReports_fltEmployeeListReport" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <table class="xFormView" style="width: 350px">
            <tr>
                <td class="caption" colspan="2">
                    <asp:Literal ID="Literal3" runat="server" Text="<%$ Resources:TimeLive.Resource, Employee List Report%> " /></td>
            </tr>
            <tr>
                <td class="formviewsubheader" colspan="2">
                    <asp:Literal ID="Literal1" runat="server" Text="<%$ Resources:TimeLive.Resource, Search Parameters%> " /></td>
            </tr>
            <tr>
                <td align="right" class="formviewlabelcell" style="width: 30%">
                    <asp:Literal ID="Literal2" runat="server" Text="<%$ Resources:TimeLive.Resource, Location:%> " /></td>
                <td align="left" style="width: 75%">
                    <asp:DropDownList ID="ddlLocation" runat="server" DataSourceID="dsLocationObject"
                        Width="186px" AppendDataBoundItems="True" DataTextField="AccountLocation" DataValueField="AccountLocationId">
                        <asp:ListItem Selected="True" Value="0" Label ID="Label1" runat="server" Text="<%$ Resources:TimeLive.Resource, ALLs%> "></asp:ListItem>
                        <%--<asp:ListItem Selected="True" Value="0">&lt;ALL&gt;</asp:ListItem>--%>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td align="right" class="formviewlabelcell" style="width: 30%;">
                    <asp:Literal ID="Literal4" runat="server" Text="<%$ Resources:TimeLive.Resource, Department:%> " /></td>
                <td align="left" style="width: 75%;">
                    <asp:DropDownList ID="ddlDepartment" runat="server" DataSourceID="dsDepartmentObject"
                        Height="22px" Width="186px" AppendDataBoundItems="True" DataTextField="DepartmentName" DataValueField="AccountDepartmentId">
                        <asp:ListItem Selected="True" Value="0" Label ID="Label2" runat="server" Text="<%$ Resources:TimeLive.Resource, ALLs%> "></asp:ListItem>
                        <%--<asp:ListItem Selected="True" Value="0">&lt;ALL&gt;</asp:ListItem>--%>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="right" class="formviewlabelcell" style="width: 30%">
                    <asp:Literal ID="Literal5" runat="server" Text="<%$ Resources:TimeLive.Resource, Role:%> " /></td>
                <td align="left" style="width: 75%">
                    <asp:DropDownList ID="ddlRole" runat="server" DataSourceID="dsRole"
                        Height="22px" Width="186px" AppendDataBoundItems="True" DataTextField="Role" DataValueField="AccountRoleId">
                        <asp:ListItem Selected="True" Value="0" Label ID="Label3" runat="server" Text="<%$ Resources:TimeLive.Resource, ALLs%> "></asp:ListItem>
                        <%--<asp:ListItem Selected="True" Value="0">&lt;ALL&gt;</asp:ListItem>--%>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td align="right" class="formviewlabelcell" style="width: 30%">
                </td>
                <td align="left" style="width: 75%">
                    <asp:Button ID="Show" runat="server" Text="<%$ Resources:TimeLive.Resource, Show_text%> " OnClick="Show_Click" /></td>
            </tr>
        </table>
        <asp:ObjectDataSource ID="dsLocationObject" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetAccountLocationsByAccountId" TypeName="AccountLocationBLL">
            <SelectParameters>
                <asp:SessionParameter DefaultValue="64" Name="AccountId" SessionField="AccountId"
                    Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="dsDepartmentObject" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetAccountDepartmentsByAccountId" TypeName="AccountDepartmentBLL">
            <SelectParameters>
                <asp:SessionParameter DefaultValue="64" Name="AccountId" SessionField="AccountId"
                    Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource><asp:ObjectDataSource ID="dsRole" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetAccountRolesByAccountId" TypeName="AccountRoleBLL">
            <SelectParameters>
                <asp:SessionParameter DefaultValue="64" Name="AccountId" SessionField="AccountId"
                    Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </ContentTemplate>
</asp:UpdatePanel>
