<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlProjectView.ascx.vb" Inherits="ProjectAdmin_Controls_ctlProjectView" %>
<table class="xFormView" style="margin-left:-3px"><tr><td>
<table class="xFormView" style="width: 500px; ">
    <tr>
        <th class="caption" colspan="4">
            <asp:Literal ID="Literal5" runat="server" Text="<%$ Resources:TimeLive.Resource, Project Information%> " /></th>
    </tr>
    <tr>
        <td align="right" class="formviewlabelcell" style="width: 20%">
            <asp:Literal ID="Literal1" runat="server" Text="<%$ Resources:TimeLive.Resource, Project Id:%> " /></td>
        <td align="left" style="width: 30%">
            <asp:TextBox ID="txtProjectId" runat="server" ReadOnly="True" Width="100px"></asp:TextBox>
        </td>
        <td align="right" class="formviewlabelcell" style="width: 20%">
            <asp:Literal ID="Literal2" runat="server" Text="<%$ Resources:TimeLive.Resource, Project Code:%> " /></td>
        <td align="left" style="width: 30%">
            <asp:TextBox ID="txtProjectCode" runat="server" ReadOnly="True" Width="100px"></asp:TextBox></td>
    </tr>
    <tr>
        <td align="right" class="formviewlabelcell" style="width: 20%">
            <asp:Literal ID="Literal3" runat="server" Text="<%$ Resources:TimeLive.Resource, Project Name:%> " /></td>
        <td align="left" colspan="3" style="width: 80%">
            <asp:TextBox ID="txtProjectName" runat="server" ReadOnly="True" Width="350px"></asp:TextBox></td>
    </tr>
</table>
</td></tr></table>
