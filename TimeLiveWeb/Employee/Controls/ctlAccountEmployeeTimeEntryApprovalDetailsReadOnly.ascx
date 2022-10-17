<%@ Control Language="VB" AutoEventWireup="false" EnableViewState="False" CodeFile="ctlAccountEmployeeTimeEntryApprovalDetailsReadOnly.ascx.vb" Inherits="Employee_Controls_ctlAccountEmployeeTimeEntryApprovalDetailsReadOnly" %>
<%If SubmittedBy <> "" Then%>
<br />
<table class="xFormView" width="98%"><tr><td>
<table class="xFormView" width="100%" id="Name">
    <tr>
        <th class="caption" colspan="3">
            <asp:Literal ID="L" runat="server" Text="<%$ Resources:TimeLive.Resource, Timesheet Approval Detail%> " /></th>
    </tr>
    <tr>
        <td align="right" class="HighlightedTextMedium" colspan="1" style="width: 15%">
            <asp:Literal ID="L2" runat="server" Text="<%$ Resources:TimeLive.Resource, Submitted By:%> " /></td>
            <td align="left" class="HighlightedTextMedium" colspan="2" style="width: 85%">
            <asp:Label ID="SB" runat="server" ForeColor="Black" Text="EmployeeName"></asp:Label></td>
    </tr>    
    <tr>
        <td align="right" class="HighlightedTextMedium" colspan="1" style="width: 15%">
            <asp:Literal ID="L3" runat="server" Text="<%$ Resources:TimeLive.Resource, Submitted On:%> " /></td>
        <td align="left" class="HighlightedTextMedium" colspan="2" style="width: 85%">
            <asp:Label ID="LSO" runat="server" ForeColor="Black" Text="10/10/2010"></asp:Label></td>
    </tr>
    <tr>
        <td colspan="3">
            <div style="margin:0px 0px 0px -5px;">
    <x:GridView ID="A" runat="server" SkinID="xgridviewSkinEmployee" DataSourceID="dsAccountEmployeeTimeEntryApprovalDetailsReadOnly" AutoGenerateColumns="False" 
        Width="100%">
    <Columns>
        <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Approver Name %>">
            <EditItemTemplate>
<asp:Label id="Label19" Text='<%# Eval("ApproverName") %>' runat="server" __designer:wfdid="w2"></asp:Label> 
</EditItemTemplate>
            <headertemplate>
<asp:Label id="AN" Text='<%# ResourceHelper.GetFromResource("Approver Name") %>' runat="server" __designer:wfdid="w3"></asp:Label>
</headertemplate>
            <ItemTemplate>
<asp:Label id="N" Text='<%# IIF(IsDBNULL(Eval("Approvername")),"System",Eval("ApproverName") & " - " & Eval("SystemApproverType")) %>' runat="server" __designer:wfdid="w1"></asp:Label> 
</ItemTemplate>
            <itemstyle verticalalign="Middle" width="25%" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Approved On %>">
            <EditItemTemplate>
<asp:TextBox id="TtBox1" Text='<%# Bind("ApprovedOn") %>' runat="server" __designer:wfdid="w5"></asp:TextBox> 
</EditItemTemplate>
            <headertemplate>
<asp:Label id="LABEL1" Text='<%# ResourceHelper.GetFromResource("Approved On") %>' runat="server" __designer:wfdid="w6"></asp:Label>
</headertemplate>
            <ItemTemplate>
<asp:Label id="A" Text='<%# IIf(IsDBNULL(Eval("ApprovedOn")),String.Format("{0:d}",Eval("SubmittedDate")),String.Format("{0:d}",Eval("ApprovedOn"))) %>' runat="server" __designer:wfdid="w4"></asp:Label> 
</ItemTemplate>
            <itemstyle horizontalalign="Center" verticalalign="Middle" width="12%" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Status %>">
            <headertemplate>
<asp:Label id="lblStatus" Text='<%# ResourceHelper.GetFromResource("Status") %>' runat="server" __designer:wfdid="w8"></asp:Label>
</headertemplate>
            <ItemTemplate>
<asp:Label id="S" runat="server" __designer:wfdid="w7"></asp:Label> 
</ItemTemplate>
            <itemstyle horizontalalign="Center" verticalalign="Middle" width="8%" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Comments %>">
            <edititemtemplate>
<asp:TextBox id="TextBox2" Text='<%# Bind("Comments") %>' runat="server" __designer:wfdid="w10"></asp:TextBox>
</edititemtemplate>
            <headertemplate>
<asp:Label id="lblComments" Text='<%# ResourceHelper.GetFromResource("Comments") %>' runat="server" __designer:wfdid="w11"></asp:Label>
</headertemplate>
            <itemtemplate>
<asp:Label id="C" Text='<%# Bind("Comments") %>' runat="server" __designer:wfdid="w9"></asp:Label>
</itemtemplate>
            <itemstyle verticalalign="Middle" width="30%" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Projects %>">
            <headertemplate>
<asp:Label id="lblProjects" Text='<%# ResourceHelper.GetFromResource("Projects") %>' runat="server" __designer:wfdid="w13"></asp:Label>
</headertemplate>
            <itemtemplate>
<asp:Label id="P" runat="server" __designer:wfdid="w12" Font-Bold="False"></asp:Label> 
</itemtemplate>
            <itemstyle width="25%" />
        </asp:TemplateField>
    </Columns>
</x:GridView>
</div>
    </tr>
</table>
</td></tr></table>
<%End If %>
<asp:ObjectDataSource ID="dsAccountEmployeeTimeEntryApprovalDetailsReadOnly" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetvueAccountEmployeeTimeEntryPeriodApprovalDetailByTimeEntryPeriodId" TypeName="AccountEmployeeTimeEntryBLL">
    <SelectParameters>
        <asp:Parameter DefaultValue="bf71d8f9-f113-4eb5-8f22-397df4a31980"
            Name="AccountEmployeeTimeEntryPeriodId" />
    </SelectParameters>
</asp:ObjectDataSource>
<br />
