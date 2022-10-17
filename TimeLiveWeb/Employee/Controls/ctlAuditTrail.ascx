<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlAuditTrail.ascx.vb" Inherits="Employee_Controls_ctlAuditTrail" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <x:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            Caption='<%# ResourceHelper.GetFromResource("Audit Trial") %>' SkinID="xgridviewSkinEmployee" 
        OnRowDataBound="GridView1_RowDataBound" Width="98%">
            <Columns>
                <asp:TemplateField SortExpression="UpdateDate" HeaderText="<%$ Resources:TimeLive.Resource, Update Date %>">
                    <edititemtemplate>
<asp:TextBox id="TextBox1" runat="server" Text='<%# Bind("UpdateDate") %>' __designer:wfdid="w153"></asp:TextBox>
</edititemtemplate>
                    <headertemplate>
<asp:Label id="lblUpdateDate" runat="server" Text='<%# ResourceHelper.GetFromResource("Update Date") %>' __designer:wfdid="w155"></asp:Label>
</headertemplate>
                    <itemtemplate>
<asp:Label id="Label1" runat="server" Text='<%# Bind("UpdateDate", "{0:d}") %>' __designer:wfdid="w152"></asp:Label>
</itemtemplate>
                    <itemstyle width="125px" />
                </asp:TemplateField>
                <asp:BoundField DataField="PK" HeaderText="<%$ Resources:TimeLive.Resource, Id %>" SortExpression="PK" Visible="False">
                    <FooterStyle HorizontalAlign="Center" />
                    <ItemStyle Width="30px" HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:TemplateField SortExpression="FieldName" HeaderText="<%$ Resources:TimeLive.Resource, Field Name %>">
                    <edititemtemplate>
<asp:TextBox id="TextBox2" runat="server" Text='<%# Bind("FieldName") %>' __designer:wfdid="w157"></asp:TextBox>
</edititemtemplate>
                    <headertemplate>
<asp:Label id="lblFieldName" runat="server" Text='<%# ResourceHelper.GetFromResource("Field Name") %>' __designer:wfdid="w158"></asp:Label>
</headertemplate>
                    <itemtemplate>
<asp:Label id="Label2" runat="server" Text='<%# Bind("FieldName") %>' __designer:wfdid="w156"></asp:Label>
</itemtemplate>
                    <itemstyle width="125px" />
                </asp:TemplateField>
                <asp:TemplateField SortExpression="OldValue" HeaderText="<%$ Resources:TimeLive.Resource, Old Value %>">
                    <edititemtemplate>
<asp:TextBox id="TextBox3" runat="server" Text='<%# Bind("OldValue") %>' __designer:wfdid="w160"></asp:TextBox>
</edititemtemplate>
                    <headertemplate>
<asp:Label id="lblOldValue" runat="server" Text='<%# ResourceHelper.GetFromResource("Old Value") %>' __designer:wfdid="w161"></asp:Label>
</headertemplate>
                    <itemtemplate>
<asp:Label id="Label3" runat="server" Text='<%# Bind("OldValue") %>' __designer:wfdid="w159"></asp:Label>
</itemtemplate>
                    <itemstyle horizontalalign="Center" width="125px" />
                </asp:TemplateField>
                <asp:TemplateField SortExpression="NewValue" HeaderText="<%$ Resources:TimeLive.Resource, New Value %>">
                    <edititemtemplate>
<asp:TextBox id="TextBox4" runat="server" Text='<%# Bind("NewValue") %>' __designer:wfdid="w163"></asp:TextBox>
</edititemtemplate>
                    <headertemplate>
<asp:Label id="lblNewValue" runat="server" Text='<%# ResourceHelper.GetFromResource("New Value") %>' __designer:wfdid="w164"></asp:Label>
</headertemplate>
                    <itemtemplate>
<asp:Label id="Label4" runat="server" Text='<%# Bind("NewValue") %>' __designer:wfdid="w162"></asp:Label>
</itemtemplate>
                    <itemstyle horizontalalign="Center" width="125px" />
                </asp:TemplateField>
                <asp:TemplateField SortExpression="EmployeeName" HeaderText="<%$ Resources:TimeLive.Resource, User Name %>">
                    <edititemtemplate>
<asp:Label id="Label1" runat="server" Text='<%# Eval("EmployeeName") %>' __designer:wfdid="w166"></asp:Label>
</edititemtemplate>
                    <headertemplate>
<asp:Label id="lblUserName" runat="server" Text='<%# ResourceHelper.GetFromResource("User Name") %>' __designer:wfdid="w167"></asp:Label>
</headertemplate>
                    <itemtemplate>
<asp:Label id="Label5" runat="server" Text='<%# Bind("EmployeeName") %>' __designer:wfdid="w165"></asp:Label>
</itemtemplate>
                    <itemstyle width="175px" />
                </asp:TemplateField>
            </Columns>
        </x:GridView>
        <asp:ObjectDataSource ID="dsAuditTrailObject" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetDataByTableName" TypeName="AuditBLL">
            <SelectParameters>
                <asp:QueryStringParameter DefaultValue="98" Name="PK" QueryStringField="AccountProjectTaskId"
                    Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </ContentTemplate>
</asp:UpdatePanel>
