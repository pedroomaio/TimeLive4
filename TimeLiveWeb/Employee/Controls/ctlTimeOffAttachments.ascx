
<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlTimeOffAttachments.ascx.vb" Inherits="Employee_Controls_ctlTimeOffAttachments" %>

<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <x:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False"
            Caption="<%$ Resources:TimeLive.Resource, Attachment List %>"
            DataKeyNames="TimeOffAttachmentId,TimeEntryId" DataSourceID="dsTimeOffAttachmentsGridViewObject"
            SkinID="xgridviewSkinEmployee" Width="656px">
            <Columns>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Id %>" InsertVisible="False"
                    SortExpression="AccountAttachmentId">
                    <ItemTemplate>
                        <asp:Label ID="AttachmentId" runat="server" Text='<%# Bind("TimeOffAttachmentId") %>' __designer:wfdid="w2"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="60px" />
                </asp:TemplateField>
                <asp:BoundField DataField="AttachmentName" HeaderText="<%$ Resources:TimeLive.Resource, Attachment Name %>" SortExpression="AttachmentName">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <ItemStyle HorizontalAlign="Left" Width="270px" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, File Name %>" SortExpression="AttachmentLocalPath" ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Middle">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("AttachmentLocalPath") %>' __designer:wfdid="w2"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:HyperLink ID="FileHyperlink" runat="server" Text='<%# Eval("AttachmentLocalPath") %>' __designer:wfdid="w1"></asp:HyperLink>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <ItemStyle Width="270px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Delete_text %>" ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete"
                            OnClientClick='<%# ResourceHelper.GetDeleteMessageJavascript()%>'
                            Text="<img src='../images/delete.gif'/>" Visible='<%# IIf(Me.Request.QueryString("ReadOnly") = "false", "true", "false") %>' ></asp:LinkButton>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="50px" />
                </asp:TemplateField>
            </Columns>
        </x:GridView>
        <asp:ObjectDataSource ID="dsTimeOffAttachmentsGridViewObject" runat="server" 
            OldValuesParameterFormatString="Original_{0}"
            SelectMethod="GetTimeOffAttachmentsByTimeEntryId" DeleteMethod="DeleteTimeOffAttachments"  TypeName="TimeOffAttachmentsBLL">
             <DeleteParameters>
                <asp:Parameter Name="Original_AccountAttachmentId" Type="Int32" />
            </DeleteParameters>
            <SelectParameters>
                <asp:QueryStringParameter  Name="TimeEntryId" QueryStringField="TimeEntry"
                    DbType ="Int32"  DefaultValue =""  />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="dsTimeOffAttachmentsReadOnly" runat="server" 
            SelectMethod ="GetTimeOffAttachmentsByProjectIdAndTimeOffTypeAndAccountEmployeeIdAndDate" TypeName="TimeOffAttachmentsBLL">
            <SelectParameters >
                <asp:QueryStringParameter Name ="AccountProjectId" QueryStringField ="AccountProjectId" DbType ="Int32" DefaultValue ="0"/>
                <asp:QueryStringParameter Name="AccountTimeOffType" QueryStringField ="AccountTimeOffType" DbType ="Guid" />
                <asp:QueryStringParameter Name ="StartDate" QueryStringField ="StartDate" DbType ="Date" />
                <asp:QueryStringParameter Name="AccountEmployeeId" QueryStringField ="AccountEmployeeId" DbType ="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="dsTimeOffRequestAttachments" runat ="server"  OldValuesParameterFormatString="Original_{0}"
            SelectMethod="GetTimeOffAttachmentsByTimeOffRequest" TypeName ="TimeOffAttachmentsBLL">
            <SelectParameters >
                <asp:QueryStringParameter Name="TimeOffRequestId" QueryStringField ="TimeOffRequest" DbType ="Guid" />
            </SelectParameters>

        </asp:ObjectDataSource> 
                 
    </ContentTemplate>
</asp:UpdatePanel>

<asp:UpdatePanel ID="UpdatePanel2" runat="server">
    <ContentTemplate>
        <asp:FormView ID="FormView1" runat="server" DataKeyNames="AccountAttachmentId"
            DefaultMode="Insert" SkinID="formviewSkinEmployee" Width="665px">

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
                            <span
                                class="reqasterisk">*</span>
                            <asp:Literal ID="Literal6" runat="server" Text="<%$ Resources:TimeLive.Resource, Attachment Name:%> " /></td>
                        <td style="width: 75%">
                            <asp:TextBox ID="txtAttachmentName" runat="server" ValidationGroup="Attachment" Width="250px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtAttachmentName"
                                CssClass="ErrorMessage" Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td style="width: 25%" align="right" class="FormViewLabelCell">
                            <span
                                class="reqasterisk">*</span>
                            <asp:Literal ID="Literal7" runat="server" Text="<%$ Resources:TimeLive.Resource, File Path:%> " /></td>
                        <td style="width: 75%">
                            <asp:FileUpload ID="AttachmentFileUpload" runat="server" Width="344px" /></td>
                    </tr>
                    <tr>
                        <td style="width: 25%" align="right" class="FormViewLabelCell"></td>
                        <td style="width: 75%; padding-bottom: 5px;">
                            <asp:Button ID="btnUpload" runat="server" Text="<%$ Resources:TimeLive.Resource, Upload_text%> " OnClick="btnUpload_Click" Width="68px" /></td>
                    </tr>
                </table>
            </InsertItemTemplate>

        </asp:FormView>
    </ContentTemplate>
</asp:UpdatePanel>
