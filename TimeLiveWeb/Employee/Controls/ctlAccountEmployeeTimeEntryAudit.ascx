<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlAccountEmployeeTimeEntryAudit.ascx.vb" Inherits="Employee_Controls_ctlAccountEmployeeTimeEntryAudit" %>
<table cellpadding="2" cellspacing="2" width="100%">
    <tr>
        <td style="width: 100px; padding-top: 5px;">
          <x:GridView ID="gvAccountEmployeeTimeEntryPeriodAudit" runat="server" AutoGenerateColumns="False"
    Caption="<%$ Resources:TimeLive.Resource, Timesheet Period Audit%>"
    SkinID="xgridviewSkinEmployee" PageSize="500" AllowSorting="True" Width="71%">
    <Columns>
                    <asp:TemplateField HeaderText="Update Date">
                    <headertemplate>
<asp:Label id="Label2" runat="server" Text='<%# ResourceHelper.GetFromResource("Updated Date") %>' __designer:wfdid="w14"></asp:Label>
                        <br />
                        <asp:TextBox ID="PUD" runat="server" __designer:wfdid="w49" AutoPostBack="True" 
                            ClientIDMode="Predictable" Width="90%"></asp:TextBox>
</headertemplate>
                        <itemstyle width="10%" HorizontalAlign="Center" VerticalAlign="Middle" />
                    <itemtemplate>
<asp:Label id="Label1" runat="server" Text='<%# Bind("UpdateDate") %>' __designer:wfdid="w48"></asp:Label> 
</itemtemplate>
                </asp:TemplateField>
        <asp:BoundField DataField="PK" HeaderText="<%$ Resources:TimeLive.Resource, Id %>"
            Visible="False">
            <footerstyle horizontalalign="Center" />
        </asp:BoundField>
        <asp:TemplateField HeaderText="Field Name">
            <headertemplate>
<asp:Label id="Label22" runat="server" Text='<%# ResourceHelper.GetFromResource("Field Name") %>' __designer:wfdid="w14"></asp:Label>
                <br />
                <asp:TextBox ID="PFN" runat="server" __designer:wfdid="w16" AutoPostBack="True" 
                    ClientIDMode="Predictable" Width="90%"></asp:TextBox>
</headertemplate>
            <itemstyle width="10%" />
            <itemtemplate>
<asp:Label id="lblFieldName" runat="server" Text='<%# Bind("FieldName") %>' __designer:wfdid="w15"></asp:Label> 
</itemtemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Old Value">
            <headertemplate>
<asp:Label id="Label23" runat="server" Text='<%# ResourceHelper.GetFromResource("Old Value") %>' __designer:wfdid="w14"></asp:Label>
                <br />
                <asp:TextBox ID="POV" runat="server" __designer:wfdid="w19" AutoPostBack="True" 
                    ClientIDMode="Predictable" Width="90%"></asp:TextBox>
</headertemplate>
            <itemstyle width="18%" />
            <itemtemplate>
<asp:Label id="lblOldValue" runat="server" Text='<%# Bind("OldValue") %>' __designer:wfdid="w18"></asp:Label> 
</itemtemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="New Value">
            <headertemplate>
<asp:Label id="Label24" runat="server" Text='<%# ResourceHelper.GetFromResource("New Value") %>' __designer:wfdid="w14"></asp:Label>
                <br />
                <asp:TextBox ID="PNV" runat="server" __designer:wfdid="w22" AutoPostBack="True" 
                    ClientIDMode="Predictable" Width="90%"></asp:TextBox>
</headertemplate>
            <itemstyle width="18%" />
            <itemtemplate>
<asp:Label id="lblNewValue" runat="server" Text='<%# Bind("NewValue") %>' __designer:wfdid="w21"></asp:Label> 
</itemtemplate>
        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Updated By">
                    <edititemtemplate>
<asp:Label id="Label1" runat="server" Text='<%# Eval("EmployeeName") %>' __designer:wfdid="w52"></asp:Label> 
</edititemtemplate>
                    <headertemplate>
<asp:Label id="Label25" runat="server" Text='<%# ResourceHelper.GetFromResource("Updated By") %>' __designer:wfdid="w14"></asp:Label>
                        <br />
                        <asp:TextBox ID="PUB" runat="server" AutoPostBack="True" 
                            ClientIDMode="Predictable" Width="90%"></asp:TextBox>
</headertemplate>
                            <itemstyle width="15%" />
                    <itemtemplate>
<asp:Label id="Label5" runat="server" Text='<%# Bind("EmployeeName") %>' __designer:wfdid="w51"></asp:Label> 
</itemtemplate>
                </asp:TemplateField>
    </Columns>
</x:GridView>
<asp:ObjectDataSource ID="dsAccountEmployeeTimeEntryPeriodAudit" runat="server" OldValuesParameterFormatString="original_{0}"
    SelectMethod="GetAccountEmployeeTimeEntryPeriodAuditByPK" TypeName="AccountEmployeeTimeEntryAuditBLL">
    <SelectParameters>
        <asp:QueryStringParameter Name="AccountEmployeeTimeEntryPeriodId" QueryStringField="AccountEmployeeTimeEntryPeriodId"
            Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>
            <br />
<x:GridView ID="gvAccountEmployeeTimeEntryAudit" runat="server" AutoGenerateColumns="False"
    Caption='<%# ResourceHelper.GetFromResource("Timesheet Audit") %>'
    SkinID="xgridviewSkinEmployee" PageSize="500" AllowSorting="True"  
                Width="98%">
    <Columns>
        <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Updated Date %>">
            <headertemplate>
<asp:Label id="Label3" runat="server" Text='<%# ResourceHelper.GetFromResource("Updated Date") %>' __designer:wfdid="w31"></asp:Label>
                <br />
                <asp:TextBox ID="UD" runat="server" __designer:wfdid="w29" AutoPostBack="True" 
                    ClientIDMode="Predictable" Width="90%"></asp:TextBox>
</headertemplate>
            <itemstyle wrap="True" width="10%" HorizontalAlign="Center" VerticalAlign="Middle" />
            <itemtemplate>
<asp:Label id="Label1" runat="server" Text='<%# Bind("UpdateDate") %>' __designer:wfdid="w28"></asp:Label> 
</itemtemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Project Name %>">
            <HeaderTemplate>
                Project Name<br />
                <asp:TextBox ID="PF" runat="server" AutoPostBack="True" 
                    ClientIDMode="Predictable" Width="90%"></asp:TextBox>
            </HeaderTemplate>
            <ItemTemplate>
                <asp:Label ID="Label2" runat="server" Text='<%# Bind("ProjectName") %>'></asp:Label>
            </ItemTemplate>
            <ItemStyle Width="10%" Wrap="True" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Task Name %>">
            <HeaderTemplate>
                Task Name<br />
                <asp:TextBox ID="TF" runat="server" AutoPostBack="True" 
                    ClientIDMode="Predictable" Width="90%"></asp:TextBox>
            </HeaderTemplate>
            <ItemTemplate>
                <asp:Label ID="Label3" runat="server" Text='<%# Bind("TaskName") %>'></asp:Label>
            </ItemTemplate>
            <ItemStyle Width="10%" Wrap="True" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Total Time" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle">
            <headertemplate>
<asp:Label id="Label4" runat="server" Text='<%# ResourceHelper.GetFromResource("Total Time") %>' __designer:wfdid="w6"></asp:Label> 
                <br />
                <asp:TextBox ID="TT" runat="server" __designer:wfdid="w5" AutoPostBack="True" 
                    ClientIDMode="Predictable" Width="80%"></asp:TextBox>
</headertemplate>
            <itemstyle wrap="True" width="7%" HorizontalAlign="Center" VerticalAlign="Middle" />
            <itemtemplate>
<asp:Label id="lblTotalTime" runat="server" __designer:wfdid="w32"></asp:Label> 
</itemtemplate>
        </asp:TemplateField>
        <asp:BoundField DataField="PK" HeaderText="<%$ Resources:TimeLive.Resource, Id %>"
            Visible="False">
            <itemstyle wrap="True" />
            <footerstyle horizontalalign="Center" />
        </asp:BoundField>
        <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Field Name%>">
            <headertemplate>
<asp:Label id="Label7" runat="server" Text='<%# ResourceHelper.GetFromResource("Field Name") %>' __designer:wfdid="w37"></asp:Label>
                <br />
                <asp:TextBox ID="FN" runat="server" __designer:wfdid="w36" AutoPostBack="True" 
                    ClientIDMode="Predictable" Width="85%"></asp:TextBox>
</headertemplate>
            <itemstyle wrap="True" width="10%" />
            <itemtemplate>
<asp:Label id="lblFieldName" runat="server" Text='<%# Bind("FieldName") %>' __designer:wfdid="w35"></asp:Label> 
</itemtemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Old Value %>">
            <headertemplate>
<asp:Label id="Label8" runat="server" Text='<%# ResourceHelper.GetFromResource("Old Value") %>' __designer:wfdid="w40"></asp:Label>
                <br />
                <asp:TextBox ID="OV" runat="server" __designer:wfdid="w39" 
                    ClientIDMode="Predictable" AutoPostBack="True" Width="90%"></asp:TextBox>
</headertemplate>
            <itemstyle wrap="True" width="18%" HorizontalAlign="Center" VerticalAlign="Middle" />
            <itemtemplate>
<asp:Label id="lblOldValue" runat="server" Text='<%# Bind("OldValue") %>' __designer:wfdid="w38"></asp:Label> 
</itemtemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, New Value %>">
            <headertemplate>
<asp:Label id="Label9" runat="server" Text='<%# ResourceHelper.GetFromResource("New Value") %>' __designer:wfdid="w43"></asp:Label>
                <br />
                <asp:TextBox ID="NV" runat="server" __designer:wfdid="w42" AutoPostBack="True" 
                    ClientIDMode="Predictable" Width="90%"></asp:TextBox>
</headertemplate>
            <itemstyle wrap="True" width="18%" HorizontalAlign="Center" VerticalAlign="Middle" />
            <itemtemplate>
<asp:Label id="lblNewValue" runat="server" Text='<%# Bind("NewValue") %>' __designer:wfdid="w41"></asp:Label> 
</itemtemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Employee Name %>">
            <edititemtemplate>
<asp:Label id="Label1" runat="server" Text='<%# Eval("EmployeeName") %>' __designer:wfdid="w45"></asp:Label> 
</edititemtemplate>
            <headertemplate>
<asp:Label id="Label10" runat="server" Text='<%# ResourceHelper.GetFromResource("Updated By") %>' __designer:wfdid="w47"></asp:Label>
                <br />
                <asp:TextBox ID="UB" runat="server" AutoPostBack="True" 
                    ClientIDMode="Predictable" Width="90%"></asp:TextBox>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                </asp:UpdatePanel>
</headertemplate>
            <itemstyle wrap="True" width="15%" />
            <itemtemplate>
<asp:Label id="Label5" runat="server" Text='<%# Bind("EmployeeName") %>' __designer:wfdid="w44"></asp:Label> 
</itemtemplate>
        </asp:TemplateField>
    </Columns>
</x:GridView>
<asp:ObjectDataSource ID="dsAccountEmployeeTimeEntryAudt" runat="server" OldValuesParameterFormatString="original_{0}"
    SelectMethod="GetAccountEmployeeTimeEntryAuditByPK" TypeName="AccountEmployeeTimeEntryAuditBLL">
    <SelectParameters>
        <asp:QueryStringParameter Name="AccountEmployeeTimeEntryPeriodId" QueryStringField="AccountEmployeeTimeEntryPeriodId"
            Type="Object" />
    </SelectParameters>
</asp:ObjectDataSource>
        </td>
    </tr>
</table>

