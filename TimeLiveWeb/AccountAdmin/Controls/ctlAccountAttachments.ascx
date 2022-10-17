<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlAccountAttachments.ascx.vb" Inherits="AccountAdmin_Controls_ctlAccountAttachments" %>
<asp:UpdatePanel ID="UpdatePanel3" runat="server">
    <ContentTemplate>
        <asp:FormView ID="FormView2" runat="server" DefaultMode="Insert" SkinID="formviewSkinEmployee"
            Width="400px">
            <InsertItemTemplate>
<table style="width: 400px" class="xFormView">
    <tr>
        <th class="caption" colspan="2">
            <asp:Literal ID="Literal1" runat="server" Text="<%$ Resources:TimeLive.Resource, Expense Information%> " /></th>
    </tr>
    <tr>
        <td style="width: 150px" align="right" class="FormViewLabelCell">
            <asp:Literal ID="Literal2" runat="server" Text="<%$ Resources:TimeLive.Resource, Expense Entry Id:%> " /></td>
        </td>
        <td style="width: 250px">
            <asp:TextBox ID="txtExpenseEntryId" runat="server" Enabled="False" Width="180px"></asp:TextBox></td>
    </tr>
    <tr>
        <td style="width: 150px" align="right" class="FormViewLabelCell">
            <asp:Literal ID="Literal3" runat="server" Text="<%$ Resources:TimeLive.Resource, Expense Name:%> " /></td>
        </td>
        <td style="width: 250px">
            <asp:TextBox ID="txtExpenseName" runat="server" Enabled="False" Width="180px"></asp:TextBox></td>
    </tr>
    <tr>
        <td align="right" class="FormViewLabelCell" style="width: 150px">
            <asp:Literal ID="Literal4" runat="server" Text="<%$ Resources:TimeLive.Resource, Amount:%> " /></td>
        </td>
        <td style="width: 250px">
            <asp:TextBox ID="txtAmount" runat="server" Enabled="False" Width="180px"></asp:TextBox></td>
    </tr>
</table>
            </InsertItemTemplate>
        </asp:FormView>
    </ContentTemplate>
</asp:UpdatePanel>
<br />
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <x:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False"
            Caption="<%$ Resources:TimeLive.Resource, Attachment List %>"  
            DataKeyNames="AccountAttachmentId" DataSourceID="dsAccountAttachmentsGridViewObject"
            SkinID="xgridviewSkinEmployee" Width="656px">
            <Columns>
                <asp:BoundField DataField="AccountAttachmentId" HeaderText="<%$ Resources:TimeLive.Resource, Id %>"  InsertVisible="False"
                    ReadOnly="True" SortExpression="AccountAttachmentId" >
                    <ItemStyle HorizontalAlign="Center" Width="60px" />
                </asp:BoundField>
                <asp:BoundField DataField="AttachmentName" HeaderText="<%$ Resources:TimeLive.Resource, Attachment Name %>"  SortExpression="AttachmentName" >
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <ItemStyle HorizontalAlign="Left" Width="270px" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, File Name %>"  SortExpression="AttachmentLocalPath" ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Middle">
                    <EditItemTemplate>
                        <asp:TextBox id="TextBox1" runat="server" Text='<%# Bind("AttachmentLocalPath") %>' __designer:wfdid="w2"></asp:TextBox> 
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:HyperLink id="FileHyperlink" runat="server" Text='<%# Eval("AttachmentLocalPath") %>' __designer:wfdid="w1"></asp:HyperLink> 
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <ItemStyle Width="270px"/>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Delete_text %>"  ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete"
                            OnClientClick='<%# ResourceHelper.GetDeleteMessageJavascript()%>'
                            Text="<img src='../images/delete.gif'/>" Visible='<%# IIF(Eval("AccountAttachmentId")=0,"false","true") %>'></asp:LinkButton>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="50px" />
                </asp:TemplateField>
            </Columns>
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
                <asp:Parameter DbType="Guid" Name="AccountEmployeeTimeEntryPeriodId" />
            </InsertParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="dsAccountAttachmentsFormViewObject" runat="server" DeleteMethod="DeleteAccountAttachments"
            InsertMethod="AddAccountAttachments" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetAccountAttachmentsByAccountAttachmentId" TypeName="AccountAttachmentsBLL">
            <DeleteParameters>
                <asp:Parameter Name="Original_AccountAttachmentId" Type="Int32" />
            </DeleteParameters>
            <SelectParameters>
                <asp:ControlParameter ControlID="GridView1" Name="AccountAttachmentId" PropertyName="SelectedValue"
                    Type="Int32" />
            </SelectParameters>
            <InsertParameters>
                <asp:Parameter Name="AccountAttachmentTypeId" Type="Int32" />
                <asp:Parameter Name="AccountExpenseEntryId" Type="Int32" />
                <asp:Parameter Name="AttachmentName" Type="String" />
                <asp:Parameter Name="AttachmentLocalPath" Type="String" />
            </InsertParameters>
        </asp:ObjectDataSource>
    </ContentTemplate>
</asp:UpdatePanel>
<br />
<asp:UpdatePanel ID="UpdatePanel2" runat="server">
    <ContentTemplate>
        <asp:FormView ID="FormView1" runat="server" DataKeyNames="AccountAttachmentId" DataSourceID="dsAccountAttachmentsFormViewObject"
            DefaultMode="Insert" SkinID="formviewSkinEmployee" Width="665px">
            <EditItemTemplate>
                AccountAttachmentId:
                <asp:Label ID="AccountAttachmentIdLabel1" runat="server" Text='<%# Eval("AccountAttachmentId") %>'>
                </asp:Label><br />
                AccountAttachmentTypeId:
                <asp:TextBox ID="AccountAttachmentTypeIdTextBox" runat="server" Text='<%# Bind("AccountAttachmentTypeId") %>'>
                </asp:TextBox><br />
                AccountExpenseEntryId:
                <asp:TextBox ID="AccountExpenseEntryIdTextBox" runat="server" Text='<%# Bind("AccountExpenseEntryId") %>'>
                </asp:TextBox><br />
                AttachmentName:
                <asp:TextBox ID="AttachmentNameTextBox" runat="server" Text='<%# Bind("AttachmentName") %>'>
                </asp:TextBox><br />
                AttachmentLocalPath:
                <asp:TextBox ID="AttachmentLocalPathTextBox" runat="server" Text='<%# Bind("AttachmentLocalPath") %>'>
                </asp:TextBox><br />
                CreatedOn:
                <asp:TextBox ID="CreatedOnTextBox" runat="server" Text='<%# Bind("CreatedOn") %>'>
                </asp:TextBox><br />
                CreatedByEmployeeId:
                <asp:TextBox ID="CreatedByEmployeeIdTextBox" runat="server" Text='<%# Bind("CreatedByEmployeeId") %>'>
                </asp:TextBox><br />
                ModifiedOn:
                <asp:TextBox ID="ModifiedOnTextBox" runat="server" Text='<%# Bind("ModifiedOn") %>'>
                </asp:TextBox><br />
                ModifiedByEmployeeId:
                <asp:TextBox ID="ModifiedByEmployeeIdTextBox" runat="server" Text='<%# Bind("ModifiedByEmployeeId") %>'>
                </asp:TextBox><br />
                <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update"
                    Text="Update">
                </asp:LinkButton>
                <asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False" CommandName="Cancel"
                    Text="Cancel">
                </asp:LinkButton>
            </EditItemTemplate>
            <InsertItemTemplate>
                <table style="width: 100%" class="xFormView">
                    <tr>
                        <th colspan="2" class="caption">
                        <asp:Literal ID="Literal1" runat="server" Text="<%$ Resources:TimeLive.Resource, Attachment Information%> " /></th>
                    </tr>
                    <tr>
                        <th colspan="2" class="FormViewSubHeader">
                            <asp:Literal ID="Literal5" runat="server" Text="<%$ Resources:TimeLive.Resource, Attachment%> " /></th>
                    </tr>
                    <tr>
                        <td style="width: 25%" align="right" class="FormViewLabelCell">
                            <SPAN 
                  class=reqasterisk>*</SPAN> <asp:Literal ID="Literal6" runat="server" Text="<%$ Resources:TimeLive.Resource, Attachment Name:%> " /></td>
                        <td style="width: 75%">
                            <asp:TextBox ID="txtAttachmentName" runat="server" ValidationGroup="Attachment" Width="250px" Text='<%# Bind("AttachmentName") %>'></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtAttachmentName"
                                CssClass="ErrorMessage" Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td style="width: 25%" align="right" class="FormViewLabelCell">
                            <SPAN 
                  class=reqasterisk>*</SPAN> <asp:Literal ID="Literal7" runat="server" Text="<%$ Resources:TimeLive.Resource, File Path:%> " /></td>
                        <td style="width: 75%">
                            <asp:FileUpload ID="AttachmentFileUpload" runat="server" Width="344px" /></td>
                    </tr>
                    <tr>
                        <td style="width: 25%" align="right" class="FormViewLabelCell">
                        </td>
                        <td style="width: 75%; padding-bottom:5px;">
                            <asp:Button ID="btnUpload" runat="server" Text="<%$ Resources:TimeLive.Resource, Upload_text%> " OnClick="btnUpload_Click" Width="68px" /></td>
                    </tr>
                </table>
            </InsertItemTemplate>
            <ItemTemplate>
                AccountAttachmentId:
                <asp:Label ID="AccountAttachmentIdLabel" runat="server" Text='<%# Eval("AccountAttachmentId") %>'>
                </asp:Label><br />
                AccountAttachmentTypeId:
                <asp:Label ID="AccountAttachmentTypeIdLabel" runat="server" Text='<%# Bind("AccountAttachmentTypeId") %>'>
                </asp:Label><br />
                AccountExpenseEntryId:
                <asp:Label ID="AccountExpenseEntryIdLabel" runat="server" Text='<%# Bind("AccountExpenseEntryId") %>'>
                </asp:Label><br />
                AttachmentName:
                <asp:Label ID="AttachmentNameLabel" runat="server" Text='<%# Bind("AttachmentName") %>'>
                </asp:Label><br />
                AttachmentLocalPath:
                <asp:Label ID="AttachmentLocalPathLabel" runat="server" Text='<%# Bind("AttachmentLocalPath") %>'>
                </asp:Label><br />
                CreatedOn:
                <asp:Label ID="CreatedOnLabel" runat="server" Text='<%# Bind("CreatedOn") %>'></asp:Label><br />
                CreatedByEmployeeId:
                <asp:Label ID="CreatedByEmployeeIdLabel" runat="server" Text='<%# Bind("CreatedByEmployeeId") %>'>
                </asp:Label><br />
                ModifiedOn:
                <asp:Label ID="ModifiedOnLabel" runat="server" Text='<%# Bind("ModifiedOn") %>'>
                </asp:Label><br />
                ModifiedByEmployeeId:
                <asp:Label ID="ModifiedByEmployeeIdLabel" runat="server" Text='<%# Bind("ModifiedByEmployeeId") %>'>
                </asp:Label><br />
                <asp:LinkButton ID="DeleteButton" runat="server" CausesValidation="False" CommandName="Delete"
                    Text="Delete">
                </asp:LinkButton>
                <asp:LinkButton ID="NewButton" runat="server" CausesValidation="False" CommandName="New"
                    Text="New">
                </asp:LinkButton>
            </ItemTemplate>
        </asp:FormView>
    </ContentTemplate>
</asp:UpdatePanel>
