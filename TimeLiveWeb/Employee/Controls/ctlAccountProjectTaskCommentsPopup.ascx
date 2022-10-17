<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlAccountProjectTaskCommentsPopup.ascx.vb" Inherits="Employee_Controls_ctlAccountProjectTaskCommentsPopup" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <asp:FormView ID="FormView2" runat="server" 
            DataKeyNames="AccountProjectTaskCommentsId" 
            DataSourceID="dsAccountProjectTaskCommentsForm" DefaultMode="Insert" 
            SkinID="formviewSkinEmployee" Width="95%">
            <EditItemTemplate>
                AccountProjectTaskCommentsId:
                <asp:Label ID="AccountProjectTaskCommentsIdLabel1" runat="server" 
                    Text='<%# Eval("AccountProjectTaskCommentsId") %>'>
                </asp:Label>
                <br />
                AccountProjectTaskId:
                <asp:TextBox ID="AccountProjectTaskIdTextBox" runat="server" 
                    Text='<%# Bind("AccountProjectTaskId") %>'>
                </asp:TextBox>
                <br />
                Comments:
                <asp:TextBox ID="CommentsTextBox" runat="server" Text='<%# Bind("Comments") %>'>
                </asp:TextBox>
                <br />
                CreatedByEmployeeId:
                <asp:TextBox ID="CreatedByEmployeeIdTextBox" runat="server" 
                    Text='<%# Bind("CreatedByEmployeeId") %>'>
                </asp:TextBox>
                <br />
                CreatedOn:
                <asp:TextBox ID="CreatedOnTextBox" runat="server" 
                    Text='<%# Bind("CreatedOn") %>'>
                </asp:TextBox>
                <br />
                ModifiedByEmployeeId:
                <asp:TextBox ID="ModifiedByEmployeeIdTextBox" runat="server" 
                    Text='<%# Bind("ModifiedByEmployeeId") %>'>
                </asp:TextBox>
                <br />
                ModifiedOn:
                <asp:TextBox ID="ModifiedOnTextBox" runat="server" 
                    Text='<%# Bind("ModifiedOn") %>'>
                </asp:TextBox>
                <br />
                CommentsTitle:
                <asp:TextBox ID="CommentsTitleTextBox" runat="server" 
                    Text='<%# Bind("CommentsTitle") %>'>
                </asp:TextBox>
                <br />
                <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" 
                    CommandName="Update" Text="Update">
                </asp:LinkButton>
                <asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False" 
                    CommandName="Cancel" Text="Cancel">
                </asp:LinkButton>
            </EditItemTemplate>
            <InsertItemTemplate>
                <table border="0" cellpadding="0" cellspacing="0" class="xview" width="100%">
                    <tr>
                        <th class="caption" colspan="2" style="height: 24px" width="15%">
                            <asp:Literal ID="Literal38" runat="server" 
                                Text='<%# ResourceHelper.GetFromResource("Comments Information") %>' />
                        </th>
                    </tr>
                    <tr>
                        <th class="FormViewSubHeader" colspan="2" style="height: 24px" width="15%">
                            <asp:Literal ID="Literal40" runat="server" 
                                Text='<%# ResourceHelper.GetFromResource("Comments") %>' />
                        </th>
                    </tr>
                    <tr>
                        <td align="right" class="FormViewLabelCell" width="15%">
                            <span class="reqasterisk">*</span>
                            <asp:Literal ID="Literal41" runat="server" 
                                Text='<%# ResourceHelper.GetFromResource("Title:") %>' />
                        </td>
                        <td width="85%">
                            <asp:TextBox ID="CommentsTitleTextBox" runat="server" 
                                Text='<%# Bind("CommentsTitle") %>' ValidationGroup="CommentsAdd" Width="90%"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                ControlToValidate="CommentsTitleTextBox" Display="Dynamic" ErrorMessage="*" 
                                ValidationGroup="CommentsAdd" Width="0px"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="FormViewLabelCell" valign="top" width="15%">
                            <span class="reqasterisk">*</span>
                            <asp:Literal ID="Literal42" runat="server" 
                                Text='<%# ResourceHelper.GetFromResource("Comments:") %>' />
                        </td>
                        <td width="85%">
                            <asp:TextBox ID="CommentsTextBox" runat="server" Height="100px" Rows="15" 
                                Text='<%# Bind("Comments") %>' TextMode="MultiLine" 
                                ValidationGroup="CommentsAdd" Width="90%"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                                ControlToValidate="CommentsTextBox" Display="Dynamic" ErrorMessage="*" 
                                ValidationGroup="CommentsAdd" Width="0px"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td width="15%">
                        </td>
                        <td style="padding-bottom: 5px; padding-top: 5px;" width="85%">
                            <asp:Button ID="Button3" runat="server" CommandName="Insert" 
                                Text="<%$ Resources:TimeLive.Resource, Add_text%> " ValidationGroup="CommentsAdd" 
                                Width="72px" />
                        </td>
                    </tr>
                </table>
            </InsertItemTemplate>
            <ItemTemplate>
                AccountProjectTaskCommentsId:
                <asp:Label ID="AccountProjectTaskCommentsIdLabel" runat="server" 
                    Text='<%# Eval("AccountProjectTaskCommentsId") %>'>
                </asp:Label>
                <br />
                AccountProjectTaskId:
                <asp:Label ID="AccountProjectTaskIdLabel" runat="server" 
                    Text='<%# Bind("AccountProjectTaskId") %>'>
                </asp:Label>
                <br />
                Comments:
                <asp:Label ID="CommentsLabel" runat="server" Text='<%# Bind("Comments") %>'></asp:Label>
                <br />
                CreatedByEmployeeId:
                <asp:Label ID="CreatedByEmployeeIdLabel" runat="server" 
                    Text='<%# Bind("CreatedByEmployeeId") %>'>
                </asp:Label>
                <br />
                CreatedOn:
                <asp:Label ID="CreatedOnLabel" runat="server" Text='<%# Bind("CreatedOn") %>'></asp:Label>
                <br />
                ModifiedByEmployeeId:
                <asp:Label ID="ModifiedByEmployeeIdLabel" runat="server" 
                    Text='<%# Bind("ModifiedByEmployeeId") %>'>
                </asp:Label>
                <br />
                ModifiedOn:
                <asp:Label ID="ModifiedOnLabel" runat="server" Text='<%# Bind("ModifiedOn") %>'>
                </asp:Label>
                <br />
                CommentsTitle:
                <asp:Label ID="CommentsTitleLabel" runat="server" 
                    Text='<%# Bind("CommentsTitle") %>'>
                </asp:Label>
                <br />
                <asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" 
                    CommandName="Edit" Text="Edit">
                </asp:LinkButton>
                <asp:LinkButton ID="DeleteButton" runat="server" CausesValidation="False" 
                    CommandName="Delete" Text="Delete">
                </asp:LinkButton>
                <asp:LinkButton ID="NewButton" runat="server" CausesValidation="False" 
                    CommandName="New" Text="New">
                </asp:LinkButton>
            </ItemTemplate>
        </asp:FormView>
        <asp:ObjectDataSource ID="dsAccountProjectTaskCommentsForm" runat="server" 
            DeleteMethod="DeleteAccountProjectTaskComments" 
            InsertMethod="AddAccountProjectTaskComments" 
            OldValuesParameterFormatString="original_{0}" 
            SelectMethod="GetAccountProjectTaskCommentsByAccountProjectTaskCommentsId" 
            TypeName="AccountProjectTaskCommentsBLL" 
            UpdateMethod="UpdateAccountProjectTaskComments">
            <DeleteParameters>
                <asp:Parameter Name="original_AccountProjectTaskCommentsId" Type="Int32" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="Comments" Type="String" />
                <asp:Parameter Name="CommentsTitle" Type="String" />
                <asp:Parameter Name="original_AccountProjectTaskCommentsId" Type="Int32" />
                <asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" />
            </UpdateParameters>
            <SelectParameters>
                <asp:QueryStringParameter DefaultValue="34" Name="AccountProjectTaskCommentsId" 
                    QueryStringField="AccountProjectTaskId" Type="Int32" />
            </SelectParameters>
            <InsertParameters>
                <asp:QueryStringParameter DefaultValue="34" Name="AccountProjectTaskId" 
                    QueryStringField="AccountProjectTaskId" Type="Int64" />
                <asp:Parameter Name="CommentsTitle" Type="String" />
                <asp:Parameter Name="Comments" Type="String" />
                <asp:Parameter Name="CreatedOn" Type="DateTime" />
                <asp:Parameter Name="CreatedByEmployeeId" Type="Int32" />
                <asp:Parameter Name="ModifiedOn" Type="DateTime" />
                <asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" />
            </InsertParameters>
        </asp:ObjectDataSource>
    </ContentTemplate>
</asp:UpdatePanel>

        <asp:FormView ID="FormView1" runat="server" 
            DataKeyNames="AccountProjectTaskAttachmentId" 
            DataSourceID="dsAccountProjectTaskAttachmentFormObject" DefaultMode="Insert" 
            SkinID="formviewSkinEmployee" Width="656px">
            <EditItemTemplate>
                AccountProjectTaskAttachmentId:
                <asp:Label ID="AccountProjectTaskAttachmentIdLabel1" runat="server" 
                    Text='<%# Eval("AccountProjectTaskAttachmentId") %>' />
                <br />
                AccountProjectTaskId:
                <asp:TextBox ID="AccountProjectTaskIdTextBox0" runat="server" 
                    Text='<%# Bind("AccountProjectTaskId") %>' />
                <br />
                AttachmentName:
                <asp:TextBox ID="AttachmentNameTextBox" runat="server" 
                    Text='<%# Bind("AttachmentName") %>' />
                <br />
                AttachmentLocalPath:
                <asp:TextBox ID="AttachmentLocalPathTextBox" runat="server" 
                    Text='<%# Bind("AttachmentLocalPath") %>' />
                <br />
                CreatedOn:
                <asp:TextBox ID="CreatedOnTextBox0" runat="server" 
                    Text='<%# Bind("CreatedOn") %>' />
                <br />
                CreatedByEmployeeId:
                <asp:TextBox ID="CreatedByEmployeeIdTextBox0" runat="server" 
                    Text='<%# Bind("CreatedByEmployeeId") %>' />
                <br />
                ModifiedOn:
                <asp:TextBox ID="ModifiedOnTextBox0" runat="server" 
                    Text='<%# Bind("ModifiedOn") %>' />
                <br />
                ModifiedByEmployeeId:
                <asp:TextBox ID="ModifiedByEmployeeIdTextBox0" runat="server" 
                    Text='<%# Bind("ModifiedByEmployeeId") %>' />
                <br />
                <asp:LinkButton ID="UpdateButton0" runat="server" CausesValidation="True" 
                    CommandName="Update" Text="Update" />
                &nbsp;<asp:LinkButton ID="UpdateCancelButton0" runat="server" 
                    CausesValidation="False" CommandName="Cancel" Text="Cancel" />
            </EditItemTemplate>
            <InsertItemTemplate>
                <TABLE class="xview" style="width: 100%">
                    <tbody>
                        <tr>
                            <th class="caption" colspan="2" width="20%">
                                <asp:Literal ID="Literal4" runat="server" 
                                    Text="<%$ Resources:TimeLive.Resource, Project Task Attachment Information%> " />
                            </th>
                        </tr>
                        <tr>
                            <th class="FormViewSubHeader" colspan="2" width="20%">
                                <asp:Literal ID="Literal2" runat="server" 
                                    Text="<%$ Resources:TimeLive.Resource, Project Task Attachment%> " />
                            </th>
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
                                    Text='<%# Bind("AttachmentName") %>' ValidationGroup="Attachment" Width="288px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
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
                            <td style="WIDTH: 32%; padding-right: 5px;">
                                <asp:FileUpload ID="AttachmentFileUpload" runat="server" Width="500px" />
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="height: 26px" width="20%">
                            </td>
                            <td style="WIDTH: 32%; height: 26px; padding-bottom: 5px;">
                                <asp:Button ID="Upload" runat="server" OnClick="Upload_Click" 
                                    Text="<%$ Resources:TimeLive.Resource, Upload_text%> " 
                                    ValidationGroup="Attachment" />
                            </td>
                        </tr>
                    </tbody>
                </TABLE>
            </InsertItemTemplate>
            <ItemTemplate>
                AccountProjectTaskAttachmentId:
                <asp:Label ID="AccountProjectTaskAttachmentIdLabel" runat="server" 
                    Text='<%# Eval("AccountProjectTaskAttachmentId") %>' />
    <br />
                AccountProjectTaskId:
                <asp:Label ID="AccountProjectTaskIdLabel0" runat="server" 
                    Text='<%# Bind("AccountProjectTaskId") %>' />
    <br />
                AttachmentName:
                <asp:Label ID="AttachmentNameLabel" runat="server" 
                    Text='<%# Bind("AttachmentName") %>' />
    <br />
                AttachmentLocalPath:
                <asp:Label ID="AttachmentLocalPathLabel" runat="server" 
                    Text='<%# Bind("AttachmentLocalPath") %>' />
    <br />
                CreatedOn:
                <asp:Label ID="CreatedOnLabel0" runat="server" 
                    Text='<%# Bind("CreatedOn") %>' />
                <br />
                CreatedByEmployeeId:
                <asp:Label ID="CreatedByEmployeeIdLabel0" runat="server" 
                    Text='<%# Bind("CreatedByEmployeeId") %>' />
    <br />
                ModifiedOn:
                <asp:Label ID="ModifiedOnLabel0" runat="server" 
                    Text='<%# Bind("ModifiedOn") %>' />
                <br />
                ModifiedByEmployeeId:
                <asp:Label ID="ModifiedByEmployeeIdLabel0" runat="server" 
                    Text='<%# Bind("ModifiedByEmployeeId") %>' />
    <br />
                <asp:LinkButton ID="DeleteButton0" runat="server" CausesValidation="False" 
                    CommandName="Delete" Text="Delete" />
                &nbsp;<asp:LinkButton ID="NewButton0" runat="server" CausesValidation="False" 
                    CommandName="New" Text="New" />
            </ItemTemplate>
        </asp:FormView>
        <asp:ObjectDataSource ID="dsAccountProjectTaskAttachmentFormObject" 
            runat="server" DeleteMethod="DeleteAccountProjectTaskAttachment" 
            InsertMethod="AddAccountProjectTaskAttachment" 
            OldValuesParameterFormatString="original_{0}" 
            SelectMethod="GetAccountProjectTaskAttachmentsByAccountProjectTaskAttachmentId" 
            TypeName="AccountProjectTaskAttachmentBLL">
            <DeleteParameters>
                <asp:Parameter Name="Original_AccountProjectTaskAttachmentId" Type="Int32" />
            </DeleteParameters>
            <SelectParameters>
                <asp:QueryStringParameter DefaultValue="28" 
                    Name="AccountProjectTaskAttachmentId" QueryStringField="AccountProjectTaskId" 
                    Type="Int32" />
            </SelectParameters>
            <InsertParameters>
                <asp:QueryStringParameter DefaultValue="28" Name="AccountProjectTaskId" 
                    QueryStringField="AccountProjectTaskId" Type="Int32" />
                <asp:Parameter DefaultValue="" Name="AttachmentName" Type="String" />
                <asp:Parameter Name="AttachmentLocalPath" Type="String" />
            </InsertParameters>
        </asp:ObjectDataSource>