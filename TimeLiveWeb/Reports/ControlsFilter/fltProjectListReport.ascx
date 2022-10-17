<%@ Control Language="VB" AutoEventWireup="false" CodeFile="fltProjectListReport.ascx.vb" Inherits="Reports_ControlsFilter_fltProjectListReport" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <table style="width: 400px" class="xFormView">
            <tr>
                <td colspan="2" class="caption">
                    <asp:Literal ID="Literal3" runat="server" Text="<%$ Resources:TimeLive.Resource, Project List Report%> " /></td>
            </tr>
            <tr>
                <td colspan="2" class="FormViewSubHeader">
                    <asp:Literal ID="Literal1" runat="server" Text="<%$ Resources:TimeLive.Resource, Search Parameters%> " /></td>
            </tr>
            <tr>
                <td style="width: 40%" align="right" class="formViewLabelCell">
                    <asp:Literal ID="Literal2" runat="server" Text="<%$ Resources:TimeLive.Resource, Client Name:%> " /></td>
                <td style="width: 60%">
                    <asp:DropDownList ID="ddlClientName" runat="server" AppendDataBoundItems="True" DataSourceID="dsAccountClientObject"
                        DataTextField="PartyName" DataValueField="AccountPartyId" Width="180px">
                        <asp:ListItem Selected="True" Value="0" Label ID="Label1" runat="server" Text="<%$ Resources:TimeLive.Resource, ALLs%> "></asp:ListItem>
                        <%--<asp:ListItem Selected="True" Value="0">&lt;ALL&gt;</asp:ListItem>--%>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="width: 40%" align="right" class="formViewLabelCell">
                    <asp:Literal ID="Literal4" runat="server" Text="<%$ Resources:TimeLive.Resource, Active Status:%> " /></td>
                <td style="width: 60%">
                    <asp:DropDownList ID="ddlActiveStatus" runat="server" AppendDataBoundItems="True" Height="22px" Width="180px">
                        <%--<asp:ListItem Selected="True" Value="-1">&lt;ALL&gt;</asp:ListItem>--%>
                        <asp:ListItem Selected="True" Value="-1" Label ID="Label2" runat="server" Text="<%$ Resources:TimeLive.Resource, ALLs%> "></asp:ListItem>
                        <%--<asp:ListItem Value="1">Active</asp:ListItem>--%>
                        <asp:ListItem Value="1" Label ID="Label3" runat="server" Text="<%$ Resources:TimeLive.Resource, Active%> "></asp:ListItem>
                        <%--<asp:ListItem Value="0">InActive</asp:ListItem>--%>
                        <asp:ListItem Value="0" Label ID="Label4" runat="server" Text="<%$ Resources:TimeLive.Resource, InActive%> "></asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 40%" align="right" class="formViewLabelCell">
                    <asp:Literal ID="Literal5" runat="server" Text="<%$ Resources:TimeLive.Resource, Project Status:%> " /></td>
                <td style="width: 60%">
                    <asp:DropDownList ID="ddlProjectStatus" runat="server" DataSourceID="dsProjectStatusObject"
                        DataTextField="Status" DataValueField="AccountStatusId" AppendDataBoundItems="True" Height="22px" Width="180px">
                        <asp:ListItem Selected="True" Value="0" Label ID="Label5" runat="server" Text="<%$ Resources:TimeLive.Resource, ALLs%> "></asp:ListItem>
                        <%--<asp:ListItem Selected="True" Value="0">&lt;ALL&gt;</asp:ListItem>--%>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="width: 40%" align="right" class="formViewLabelCell">
                </td>
                <td style="width: 60%">
                    <asp:Button ID="btnShow" runat="server" OnClick="btnShow_Click" Text="<%$ Resources:TimeLive.Resource, Show_text%> " /></td>
            </tr>
        </table>
        <asp:ObjectDataSource ID="dsProjectStatusObject" runat="server" DeleteMethod="DeleteAccountStatus"
            InsertMethod="AddAccountStatus" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetAccountsStatusByStatusTypeId" TypeName="AccountStatusBLL" UpdateMethod="UpdateAccountStatus">
            <DeleteParameters>
                <asp:Parameter Name="Original_AccountStatusId" Type="Int32" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="AccountId" Type="Int32" />
                <asp:Parameter Name="Status" Type="String" />
                <asp:Parameter Name="StatusTypeId" Type="Int32" />
                <asp:Parameter Name="Original_AccountStatusId" Type="Int32" />
            </UpdateParameters>
            <SelectParameters>
                <asp:SessionParameter DefaultValue="64" Name="AccountId" SessionField="AccountId"
                    Type="Int32" />
                <asp:Parameter DefaultValue="3" Name="StatusTypeId" Type="Int32" />
            </SelectParameters>
            <InsertParameters>
                <asp:Parameter Name="AccountId" Type="Int32" />
                <asp:Parameter Name="Status" Type="String" />
                <asp:Parameter Name="StatusTypeId" Type="Int32" />
            </InsertParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="dsAccountClientObject" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetvueAccountPartiesByAccountId" TypeName="AccountPartyBLL">
            <SelectParameters>
                <asp:SessionParameter DefaultValue="64" Name="AccountId" SessionField="AccountId"
                    Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </ContentTemplate>
</asp:UpdatePanel>
