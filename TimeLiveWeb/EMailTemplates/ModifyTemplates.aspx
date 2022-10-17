<%@ Page Language="VB" MasterPageFile="~/Masters/MasterPageBase.master" AutoEventWireup="false" CodeFile="ModifyTemplates.aspx.vb" Inherits="EMailTemplates_ModifyTemplates" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderLeftMenu" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderBody" Runat="Server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="MasterEMailTemplateId"
        DataSourceID="ObjectDataSource1">
        <Columns>
            <asp:BoundField DataField="MasterEMailTemplateId" HeaderText="MasterEMailTemplateId"
                ReadOnly="True" SortExpression="MasterEMailTemplateId" />
            <asp:BoundField DataField="TemplateDescription" HeaderText="TemplateDescription"
                SortExpression="TemplateDescription" />
            <asp:TemplateField HeaderText="TemplateContent" SortExpression="TemplateContent">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Rows="5" Text='<%# Bind("TemplateContent") %>'
                        TextMode="MultiLine" Width="400px"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("TemplateContent") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="TemplateName" HeaderText="TemplateName" SortExpression="TemplateName" />
            <asp:CommandField ShowEditButton="True" />
        </Columns>
    </asp:GridView>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetMasterTemplates" TypeName="EMailEngineBLL" UpdateMethod="UpdateEMailTemplate">
        <UpdateParameters>
            <asp:Parameter Name="TemplateName" Type="String" />
            <asp:Parameter Name="TemplateDescription" Type="String" />
            <asp:Parameter Name="TemplateContent" Type="String" />
            <asp:Parameter Name="original_MasterEMailTemplateId" Type="Int32" />
        </UpdateParameters>
    </asp:ObjectDataSource>
    &nbsp;
</asp:Content>

