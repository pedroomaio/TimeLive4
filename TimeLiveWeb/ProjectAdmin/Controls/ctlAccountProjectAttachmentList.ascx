<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlAccountProjectAttachmentList.ascx.vb" Inherits="ProjectAdmin_Controls_ctlAccountProjectAttachmentList" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <asp:FormView ID="FormView2" runat="server" DefaultMode="Insert" 
            SkinID="formviewSkinEmployee" Width="400px">
            <InsertItemTemplate>
                <table class="xview" style="width: 400px">
                    <tr>
                        <th class="caption" colspan="2">
                            <asp:Literal ID="Literal5" runat="server" 
                                Text="<%$ Resources:TimeLive.Resource, Project Information%> " />
                        </th>
                    </tr>
                    <tr>
                        <td align="right" class="FormViewLabelCell" style="width: 150px">
                            <asp:Literal ID="Literal6" runat="server" 
                                Text="<%$ Resources:TimeLive.Resource, Project Id: %>" />
                        </td>
                        </td>
                        <td style="width: 250px">
                            <asp:TextBox ID="txtProjectId" runat="server" Enabled="False" Width="180px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="FormViewLabelCell" style="width: 150px">
                            <asp:Literal ID="Literal7" runat="server" 
                                Text="<%$ Resources:TimeLive.Resource, Project Name:%> " />
                        </td>
                        </td>
                        <td style="width: 250px">
                            <asp:TextBox ID="txtProjectName" runat="server" Enabled="False" Width="180px"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </InsertItemTemplate>
        </asp:FormView>
    </ContentTemplate>
</asp:UpdatePanel>
<asp:UpdatePanel ID="UpdatePanel2" runat="server">
    <ContentTemplate>
        <br />
        <x:GridView ID="GridView1" runat="server" AllowSorting="True" 
            AutoGenerateColumns="False" 
            Caption="<%$ Resources:TimeLive.Resource, Attachment List %>" 
            DataKeyNames="AccountProjectAttachmentId" 
            DataSourceID="dsAccountProjectAttachmentObject" 
            SkinID="xgridviewSkinEmployee" Width="656px">
            <Columns>
                <asp:BoundField DataField="AccountProjectAttachmentId" 
                    HeaderText="AccountProjectAttachmentId" SortExpression="AccountProjectAttachmentId" 
                    Visible="False" ReadOnly="True"></asp:BoundField>
                <asp:BoundField DataField="AccountProjectId" 
                    HeaderText="AccountProjectId" SortExpression="AccountProjectId" 
                    Visible="False"></asp:BoundField>
                <asp:BoundField DataField="AttachmentName" 
                    HeaderText="<%$ Resources:TimeLive.Resource, Attachment Name%> " 
                    SortExpression="AttachmentName">
                    <ItemStyle HorizontalAlign="Left" Width="250px" />
                    <HeaderStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, File Name%> " 
                    SortExpression="AttachmentLocalPath">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" 
                            Text='<%# Bind("AttachmentLocalPath") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="250px" />
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemTemplate>
                        <asp:HyperLink ID="FileHyperlink" runat="server" 
                            NavigateUrl='<%# "../../Shared/FileDownload.aspx?" & LicensingBLL.GetEncryptedStringAsBase64ByUTF8("FileName=" & DBUtilities.GetSessionAccountId & "/" & Eval("AccountProjectId") & "/" & Eval("AttachmentLocalPath")) %>' 
                            Text='<%# Eval("AttachmentLocalPath") %>'></asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="CreatedOn" HeaderText="CreatedOn" 
                    SortExpression="CreatedOn" Visible="False"></asp:BoundField>
                <asp:BoundField DataField="CreatedByEmployeeId" 
                    HeaderText="CreatedByEmployeeId" SortExpression="CreatedByEmployeeId" 
                    Visible="False"></asp:BoundField>
                <asp:BoundField DataField="ModifiedOn" HeaderText="ModifiedOn" 
                    SortExpression="ModifiedOn" Visible="False"></asp:BoundField>
                <asp:BoundField DataField="ModifiedByEmployeeId" 
                    HeaderText="ModifiedByEmployeeId" SortExpression="ModifiedByEmployeeId" 
                    Visible="False"></asp:BoundField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Delete_text%> " 
                    ShowHeader="False">
                    <ItemStyle HorizontalAlign="Center" Width="38px" />
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Delete" OnClientClick="<%# ResourceHelper.GetDeleteMessageJavascript() %>"
                        Visible='<%# IIF(AccountPagePermissionBll.IsPageHasPermissionOf(28,3),True,False) %>'
                        Text="<img src='../images/delete.gif'/>" onclick="LinkButton1_Click"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </x:GridView>
        <asp:ObjectDataSource ID="dsAccountProjectAttachmentObject" runat="server" 
            InsertMethod="AddAccountProjectAttachment" 
            OldValuesParameterFormatString="original_{0}" 
            SelectMethod="GetAccountProjectAttachmentsByAccountProjectId" 
            TypeName="AccountProjectAttachmentBLL" 
            DeleteMethod="DeleteAccountProjectAttachment">
            <SelectParameters>
                <asp:QueryStringParameter DefaultValue="555" Name="AccountProjectId" 
                    QueryStringField="AccountProjectId" Type="Int32" />
                <asp:Parameter Name="NotFixTable" Type="Boolean" />
            </SelectParameters>
            <InsertParameters>
                <asp:Parameter Name="AccountProjectId" Type="Int32" />
                <asp:Parameter Name="AttachmentName" Type="String" />
                <asp:Parameter Name="AttachmentLocalPath" Type="String" />
            </InsertParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="dsAccountProjectAttachmentFormObject" runat="server" 
            DataObjectTypeName="System.Guid" DeleteMethod="DeleteAccountProjectAttachment" 
            InsertMethod="AddAccountProjectAttachment" 
            OldValuesParameterFormatString="original_{0}" 
            SelectMethod="GetAccountProjectAttachmentsByAccountProjectId" 
            TypeName="AccountProjectAttachmentBLL">
            <SelectParameters>
                <asp:QueryStringParameter DefaultValue="987" Name="AccountProjectId" 
                    QueryStringField="AccountProjectId" Type="Int32" />
                <asp:Parameter Name="NotFixTable" Type="Boolean" />
            </SelectParameters>
            <InsertParameters>
                <asp:Parameter Name="AccountProjectId" Type="Int32" />
                <asp:Parameter DefaultValue="" Name="AttachmentName" Type="String" />
                <asp:Parameter Name="AttachmentLocalPath" Type="String" />
            </InsertParameters>
        </asp:ObjectDataSource>
    </ContentTemplate>
</asp:UpdatePanel>
<asp:UpdatePanel ID="UpdatePanel3" runat="server">
    <ContentTemplate>
        <asp:FormView ID="FormView1" runat="server" 
            DataKeyNames="AccountProjectAttachmentId" 
            DataSourceID="dsAccountProjectAttachmentFormObject" DefaultMode="Insert" 
            OnPageIndexChanging="FormView1_PageIndexChanging" SkinID="formviewSkinEmployee" 
            Width="656px">
            <EditItemTemplate>
                <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" 
                    CommandName="Update" Text="Update" />
                &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" 
                    CausesValidation="False" CommandName="Cancel" Text="Cancel" />
            </EditItemTemplate>
            <InsertItemTemplate>
                <table class="xview" style="width: 100%">
                    <tbody>
                        <tr>
                            <td class="caption" colspan="2" width="20%">
                                <asp:Literal ID="Literal4" runat="server" 
                                    Text="Project Attachment Information" />
                            </td>
                        </tr>
                        <tr>
                            <td class="FormViewSubHeader" colspan="2" width="20%">
                                <asp:Literal ID="Literal2" runat="server" 
                                    Text="Project Attachment" />
                            </td>
                        </tr>
                        <tr>
                            <td align="right" class="FormViewLabelCell" width="20%">
                                <span class="reqasterisk">*</span>
                                <asp:Literal ID="Literal1" runat="server" 
                                    Text="<%$ Resources:TimeLive.Resource, Attachment Name:%> " />
                            </td>
                            </TD>
                            <td style="WIDTH: 32%">
                                <asp:TextBox ID="AttachmentNameTextBox" runat="server" 
                                    Text='<%# Bind("AttachmentName") %>' ValidationGroup="Attachment" 
                                    Width="288px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                    ControlToValidate="AttachmentNameTextBox" Display="Dynamic" ErrorMessage="*" 
                                    ValidationGroup="Attachment"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" class="FormViewLabelCell" width="20%">
                                <span class="reqasterisk">*</span>
                                <asp:Literal ID="Literal3" runat="server" 
                                    Text="<%$ Resources:TimeLive.Resource, File Path:%> " />
                            </td>
                            </TD>
                            <td style="WIDTH: 32%">
                                <asp:FileUpload ID="AttachmentFileUpload" runat="server" Width="500px" />
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="height: 26px" width="20%">
                            </td>
                            <td style="WIDTH: 32%; height: 26px;">
                                <asp:Button ID="Upload" runat="server" 
                                    Text="<%$ Resources:TimeLive.Resource, Upload_text%> " 
                                    ValidationGroup="Attachment" />
                            </td>
                        </tr>
                    </tbody>
                </table>
            </InsertItemTemplate>
            <ItemTemplate>
                <asp:LinkButton ID="DeleteButton" runat="server" CausesValidation="False" 
                    CommandName="Delete" Text="Delete" />
                &nbsp;<asp:LinkButton ID="NewButton" runat="server" CausesValidation="False" 
                    CommandName="New" Text="New" />
            </ItemTemplate>
        </asp:FormView>
    </ContentTemplate>
</asp:UpdatePanel>

