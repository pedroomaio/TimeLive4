<%@ Page Language="VB" AutoEventWireup="false" CodeFile="AccountExpenseEntryApprovalAttachment.aspx.vb" Inherits="ProjectAdmin_AccountExpenseEntryApprovalAttachment" Theme="SkinFile" %>


<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<link href="../Styles.css" rel="stylesheet" type="text/css" />
    <title>TimeLive-Attachments /></td></title>
</head>
<body >
    <form id="form1" runat="server">
        <x:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False"
 DataKeyNames="AccountAttachmentId" DataSourceID="dsAccountAttachmentsGridViewObject"
            Width="656px" SkinID="xgridviewSkinEmployee" Caption="<%$ Resources:TimeLive.Resource, Attachment List%> ">
            <Columns>
                <asp:BoundField DataField="AccountAttachmentId" HeaderText="<%$ Resources:TimeLive.Resource, Id%> " InsertVisible="False"
                    ReadOnly="True" SortExpression="AccountAttachmentId" Visible="False">
                    <ItemStyle HorizontalAlign="Center" Width="40px" />
                </asp:BoundField>
                <asp:BoundField DataField="AttachmentName" HeaderText="<%$ Resources:TimeLive.Resource, Attachment Name%> " SortExpression="AttachmentName">
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="250px" />
                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, File Name%> " SortExpression="AttachmentLocalPath">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("AttachmentLocalPath") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="250px" />
                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                    <ItemTemplate>
                        <asp:HyperLink ID="FileHyperlink" runat="server" NavigateUrl='<%# "../Shared/FileDownload.aspx?" & LicensingBLL.GetEncryptedStringAsBase64ByUTF8("FileName=" & DBUtilities.GetSessionAccountId & "/" & Eval("AccountExpenseEntryId") & "/" & Eval("AttachmentLocalPath")) %>'
                            Text='<%# Eval("AttachmentLocalPath") %>' Target="_blank"></asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Delete_text%> " ShowHeader="False" Visible="False">
                    <ItemStyle HorizontalAlign="Center" Width="30px" />
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete"
                            OnClientClick='return confirm("Are you sure you want to delete this entry?");'
                            Text="Delete" Visible='<%# IIF(Eval("AccountAttachmentId")=0,"false","true") %>'></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField Visible="False"></asp:TemplateField>
            </Columns>
            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
            <HeaderStyle Font-Bold="False" />
            <AlternatingRowStyle BackColor="White" />
        </x:GridView>
        <asp:ObjectDataSource ID="dsAccountAttachmentsGridViewObject" runat="server" DeleteMethod="DeleteAccountAttachments"
            InsertMethod="AddAccountAttachments" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetAccountAttachmentsByAccountExpenseEntryId" TypeName="AccountAttachmentsBLL">
            <DeleteParameters>
                <asp:Parameter Name="Original_AccountAttachmentId" Type="Int32" />
            </DeleteParameters>
            <SelectParameters>
                <asp:QueryStringParameter DefaultValue="23" Name="AccountExpenseEntryId" QueryStringField="AccountExpenseEntryId"
                    Type="Int32" />
                <asp:QueryStringParameter DbType="Guid" DefaultValue="" 
                    Name="AccountEmployeeTimeEntryPeriodId" 
                    QueryStringField="AccountEmployeeTimeEntryPeriodId" />
                <asp:Parameter Name="NotFixTable" Type="Boolean" />
            </SelectParameters>
            <InsertParameters>
                <asp:Parameter Name="AccountAttachmentTypeId" Type="Int32" />
                <asp:Parameter Name="AccountExpenseEntryId" Type="Int32" />
                <asp:Parameter Name="AttachmentName" Type="String" />
                <asp:Parameter Name="AttachmentLocalPath" Type="String" />
            </InsertParameters>
        </asp:ObjectDataSource>
    </form>
</body>
</html>
