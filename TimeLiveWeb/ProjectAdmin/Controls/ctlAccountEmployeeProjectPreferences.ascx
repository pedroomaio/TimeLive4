<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlAccountEmployeeProjectPreferences.ascx.vb" Inherits="ProjectAdmin_Controls_ctlAccountEmployeeProjectPreferences" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
                <table width="350" class="xview">
                    <tr>
                        <th class="caption" colspan="2" style="width: 40%; height: 21px">
                            Employee Project Preferences</th>
                    </tr>
                    <tr>
                        <th class="FormViewSubHeader" colspan="2" style="width: 40%; height: 21px">
                            Update Preferences</th>
                    </tr>
                    <tr>
                        <td align="right" class="FormViewLabelCell" style="width: 30%">
                            Send Email Of Tasks Assign To Me :</td>
                        <td style="width: 35%">
                            <asp:CheckBox ID="chkSendEmailOfTaskAssignToMe" runat="server" Checked='<%# iif(IsDBNull(Eval("SendEMailOfTaskAssignToMe")),false,Eval("SendEMailOfTaskAssignToMe")) %>' /></td>
                    </tr>
                    <tr>
                        <td align="right" class="FormViewLabelCell" style="width: 65%">
                            Send Email Of All Project Activities :</td>
                        <td style="width: 35%">
                            <asp:CheckBox ID="chkSendEMailOfAllProjectActivities" runat="server" Checked='<%# iif(IsDBNull(Eval("SendEMailOfAllProjectActivities")),false,Eval("SendEMailOfAllProjectActivities")) %>' /></td>
                    </tr>
                    <tr>
                        <td align="right" class="FormViewLabelCell" style="width: 65%">
                        </td>
                        <td style="width: 35%">
                            <asp:Button ID="btnUpdate" runat="server" Text="Update" Width="50px" OnClick="btnUpdate_Click1" /></td>
                    </tr>
                </table>
    </ContentTemplate>
</asp:UpdatePanel>
