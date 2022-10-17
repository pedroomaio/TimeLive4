<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlAccountEmployeeExpenseSheetApprovalDetailReadOnly.ascx.vb" Inherits="Employee_Controls_ctlAccountEmployeeExpenseSheetApprovalDetailReadOnly" %>
<%If SubmittedBy <> "" Then%>
<br />
<table class="xFormView" width="98%"><tr><td>
<table class="xFormView" width="100%" id="Name">
    <tr>
        <th class="caption" colspan="3">
            <asp:Literal ID="Literal1" runat="server" Text="<%$ Resources:TimeLive.Resource, Expense Approval Detail%> " /></th>
    </tr>
    
    <tr>
    
        <td align="right" class="HighlightedTextMedium" colspan="1" style="width: 15%">
            <asp:Literal ID="Literal2" runat="server" Text="<%$ Resources:TimeLive.Resource, Submitted By:%> " /></td>
    
        <td align="left" class="HighlightedTextMedium" colspan="2" style="width: 85%">
            <asp:Label ID="lblSubmittedBy" runat="server" ForeColor="Black" Text="EmployeeName"></asp:Label></td>
            
    </tr>    
    <tr>
    
        <td align="right" class="HighlightedTextMedium" colspan="1" style="width: 15%">
            <asp:Literal ID="Literal3" runat="server" Text="<%$ Resources:TimeLive.Resource, Submitted On:%> " /></td>
    
        <td align="left" class="HighlightedTextMedium" colspan="2" style="width: 85%">
            <asp:Label ID="lblSubmittedOn" runat="server" ForeColor="Black" Text="10/10/2010"></asp:Label></td>
 
    </tr>
    
    <tr>
        <td colspan="3">
        <div style="margin:0px 0px 0px -5px;">
         
<x:GridView ID="GridView1" runat="server" SkinID="xgridviewSkinEmployee" BorderWidth="0" DataSourceID="dsAccountEmployeeExpenseSheetApprovalDetailReadOnlyObject" AutoGenerateColumns="False" CssClass="xGridView" Width="100%">
    <Columns>
        <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Approver Name %>">
            <EditItemTemplate>
<asp:Label id="Label1" Text='<%# Eval("ApproverName") %>' runat="server" __designer:wfdid="w15"></asp:Label> 
</EditItemTemplate>
            <headertemplate>
<asp:Label id="lblApproverName" Text='<%# ResourceHelper.GetFromResource("Approver Name") %>' runat="server" __designer:wfdid="w16"></asp:Label>
</headertemplate>
            <ItemTemplate>
<asp:Label id="Label1" Text='<%# IIF(IsDBNULL(Eval("ApprovalEmployeeName")),"System",Eval("ApprovalEmployeeName") & " - " & Eval("SystemApproverType")) %>' runat="server" __designer:wfdid="w14"></asp:Label> 
</ItemTemplate>
            <itemstyle verticalalign="Middle" width="25%" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Approved On %>">
            <EditItemTemplate>
<asp:TextBox id="TextBox1" Text='<%# Bind("ApprovedOn") %>' runat="server" __designer:wfdid="w18"></asp:TextBox> 
</EditItemTemplate>
            <headertemplate>
<asp:Label id="lblApprovedOn" Text='<%# ResourceHelper.GetFromResource("Approved On") %>' runat="server" __designer:wfdid="w19"></asp:Label>
</headertemplate>
            <ItemTemplate>
<asp:Label id="Label2" Text='<%# IIf(IsDBNULL(Eval("ApprovedOn")),String.Format("{0:d}",Eval("SubmittedDate")),String.Format("{0:d}",Eval("ApprovedOn"))) %>' runat="server" __designer:wfdid="w17"></asp:Label> 
</ItemTemplate>
            <itemstyle horizontalalign="Center" verticalalign="Middle" width="12%" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Status %>">
            <headertemplate>
<asp:Label id="lblStatus" Text='<%# ResourceHelper.GetFromResource("Status") %>' runat="server" __designer:wfdid="w21"></asp:Label>
</headertemplate>
            <ItemTemplate>
<asp:Label id="lblStatus" runat="server" __designer:wfdid="w20"></asp:Label> 
</ItemTemplate>
            <itemstyle horizontalalign="Center" verticalalign="Middle" width="8%" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Comments %>">
            <edititemtemplate>
<asp:TextBox id="TextBox2" Text='<%# Bind("Comments") %>' runat="server" __designer:wfdid="w23"></asp:TextBox>
</edititemtemplate>
            <headertemplate>
<asp:Label id="lblComments" Text='<%# ResourceHelper.GetFromResource("Comments") %>' runat="server" __designer:wfdid="w24"></asp:Label>
</headertemplate>
            <itemtemplate>
<asp:Label id="Label3" Text='<%# Bind("Comments") %>' runat="server" __designer:wfdid="w22"></asp:Label>
</itemtemplate>
            <itemstyle verticalalign="Middle" width="30%" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Projects %>">
            <headertemplate>
<asp:Label id="lblProjects" Text='<%# ResourceHelper.GetFromResource("Projects") %>' runat="server" __designer:wfdid="w26"></asp:Label>
</headertemplate>
            <itemtemplate>
<asp:Label id="lblProjects" Text='<%# Eval("ProjectName") %>' runat="server" __designer:wfdid="w25" Font-Bold="False"></asp:Label> 
</itemtemplate>
            <itemstyle width="25%" />
        </asp:TemplateField>
    </Columns>
</x:GridView>
</div>
            <asp:ObjectDataSource ID="dsAccountEmployeeExpenseSheetApprovalDetailReadOnlyObject"
                runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetvueAccountEmployeeExpenseSheetApprovalDetailReadOnly"
                TypeName="AccountEmployeeExpenseSheetBLL">
                <SelectParameters>
                    <asp:Parameter Name="AccountEmployeeExpenseSheetId" Type="Object" />
                </SelectParameters>
            </asp:ObjectDataSource>
       </td>
    </tr>
</table>
</td></tr></table>
<%End If %>