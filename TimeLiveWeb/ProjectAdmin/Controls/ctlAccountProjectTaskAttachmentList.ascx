<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlAccountProjectTaskAttachmentList.ascx.vb" Inherits="ProjectAdmin_Controls_ctlAccountProjectTaskAttachmentList" %>
<asp:UpdatePanel ID="UpdatePanel3" runat="server">
    <ContentTemplate>
        <asp:FormView ID="FormView2" runat="server" DefaultMode="Insert" SkinID="formviewSkinEmployee"
            Width="400px">
            <InsertItemTemplate>
<table style="width: 400px" class="xview">
    <tr>
        <th class="caption" colspan="2">
            <asp:Literal ID="Literal5" runat="server" Text="<%$ Resources:TimeLive.Resource, Project Task Information%> " /></th>
    </tr>
    <tr>
        <td style="width: 150px" align="right" class="FormViewLabelCell">
            <asp:Literal ID="Literal6" runat="server" Text="<%$ Resources:TimeLive.Resource, Task Id:%> " /></td>
        </td>
        <td style="width: 250px">
            <asp:TextBox ID="txtProjectTaskId" runat="server" Enabled="False" Width="180px"></asp:TextBox></td>
    </tr>
    <tr>
        <td style="width: 150px" align="right" class="FormViewLabelCell">
            <asp:Literal ID="Literal7" runat="server" Text="<%$ Resources:TimeLive.Resource, Project Name:%> " /></td>
        </td>
        <td style="width: 250px">
            <asp:TextBox ID="txtProjectName" runat="server" Enabled="False" Width="180px"></asp:TextBox></td>
    </tr>
    <tr>
        <td align="right" class="FormViewLabelCell" style="width: 150px">
            <asp:Literal ID="Literal8" runat="server" Text="<%$ Resources:TimeLive.Resource, Task Name:%> " /></td>
        </td>
        <td style="width: 250px">
            <asp:TextBox ID="txtTaskName" runat="server" Enabled="False" Width="180px"></asp:TextBox></td>
    </tr>
</table>
            </InsertItemTemplate>
        </asp:FormView>
    </ContentTemplate>
</asp:UpdatePanel>
<br />
<asp:UpdatePanel id="UpdatePanel1" runat="server"><ContentTemplate>
<x:GridView id="GridView1" runat="server" AutoGenerateColumns="False" 
        DataSourceID="dsAccountProjectTaskAttachmentObject" 
        DataKeyNames="AccountProjectTaskAttachmentId" AllowSorting="True" Width="656px" 
        SkinID="xgridviewSkinEmployee" 
        Caption="<%$ Resources:TimeLive.Resource, Attachment List %>" 
        OnRowDataBound="GridView1_RowDataBound" OnRowCreated="GridView1_RowCreated"><Columns>
<asp:BoundField ReadOnly="True" DataField="AccountProjectTaskAttachmentId" InsertVisible="False" SortExpression="AccountProjectTaskAttachmentId" HeaderText="<%$ Resources:TimeLive.Resource, Id%> ">
<ItemStyle Width="40px" HorizontalAlign="Center"></ItemStyle>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="AccountProjectTaskId" Visible="False" SortExpression="AccountProjectTaskId" HeaderText="AccountProjectTaskId"></asp:BoundField>
<asp:BoundField DataField="AttachmentName" SortExpression="AttachmentName" HeaderText="<%$ Resources:TimeLive.Resource, Attachment Name%> ">
<ItemStyle Width="250px" HorizontalAlign="Left"></ItemStyle>

<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
</asp:BoundField>
    <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, File Name%> " SortExpression="AttachmentLocalPath">
        <EditItemTemplate>
            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("AttachmentLocalPath") %>'></asp:TextBox>
        </EditItemTemplate>
        <ItemStyle HorizontalAlign="Left" Width="250px" />
        <HeaderStyle HorizontalAlign="Left" />
        <ItemTemplate>
            <asp:HyperLink ID="FileHyperlink" runat="server" NavigateUrl='<%# "../../Shared/FileDownload.aspx?" & LicensingBLL.GetEncryptedStringAsBase64ByUTF8("FileName=" & DBUtilities.GetSessionAccountId & "/" & Eval("AccountProjectTaskId") & "/" & Eval("AttachmentLocalPath")) %>'
                Text='<%# Eval("AttachmentLocalPath") %>'></asp:HyperLink>
        </ItemTemplate>
    </asp:TemplateField>
<asp:BoundField DataField="CreatedOn" Visible="False" SortExpression="CreatedOn" HeaderText="CreatedOn"></asp:BoundField>
<asp:BoundField DataField="CreatedByEmployeeId" Visible="False" SortExpression="CreatedByEmployeeId" HeaderText="CreatedByEmployeeId"></asp:BoundField>
<asp:BoundField DataField="ModifiedOn" Visible="False" SortExpression="ModifiedOn" HeaderText="ModifiedOn"></asp:BoundField>
<asp:BoundField DataField="ModifiedByEmployeeId" Visible="False" SortExpression="ModifiedByEmployeeId" HeaderText="ModifiedByEmployeeId"></asp:BoundField>
        <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Delete_text%> " ShowHeader="False">
            <ItemStyle HorizontalAlign="Center" Width="38px" />
            <HeaderStyle HorizontalAlign="Center" />
     <ItemTemplate> 
       <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete"
                    OnClientClick='<%# ResourceHelper.GetDeleteMessageJavascript()%>'
                    Text="<img src='../images/delete.gif'/>" Visible='<%# Eval("AccountProjectTaskAttachmentId")>=0 %>' />
     </ItemTemplate>
        </asp:TemplateField>
</Columns>
</x:GridView><asp:ObjectDataSource id="dsAccountProjectTaskAttachmentObject" runat="server" TypeName="AccountProjectTaskAttachmentBLL" DeleteMethod="DeleteAccountProjectTaskAttachment" SelectMethod="GetAccountProjectTaskAttachmentsByAccountProjectTaskId" OldValuesParameterFormatString="original_{0}" InsertMethod="AddAccountProjectTaskAttachment"><DeleteParameters>
<asp:Parameter Type="Int32" Name="Original_AccountProjectTaskAttachmentId"></asp:Parameter>
</DeleteParameters>
<SelectParameters>
    <asp:QueryStringParameter DefaultValue="28" Name="AccountProjectTaskId" QueryStringField="AccountProjectTaskId"
        Type="Int32" />
    <asp:Parameter Name="NotFixTable" Type="Boolean" />
</SelectParameters>
    <InsertParameters>
        <asp:Parameter Name="AccountProjectTaskId" Type="Int32" />
        <asp:Parameter Name="AttachmentName" Type="String" />
        <asp:Parameter Name="AttachmentLocalPath" Type="String" />
    </InsertParameters>
</asp:ObjectDataSource> <asp:ObjectDataSource id="dsAccountProjectTaskAttachmentFormObject" runat="server" InsertMethod="AddAccountProjectTaskAttachment" TypeName="AccountProjectTaskAttachmentBLL" DeleteMethod="DeleteAccountProjectTaskAttachment" SelectMethod="GetAccountProjectTaskAttachmentsByAccountProjectTaskAttachmentId" OldValuesParameterFormatString="original_{0}"><DeleteParameters>
<asp:Parameter Type="Int32" Name="Original_AccountProjectTaskAttachmentId"></asp:Parameter>
</DeleteParameters>
<SelectParameters>
    <asp:QueryStringParameter DefaultValue="28" Name="AccountProjectTaskAttachmentId"
        QueryStringField="AccountProjectTaskId" Type="Int32" />
</SelectParameters>
<InsertParameters>
    <asp:QueryStringParameter DefaultValue="28" Name="AccountProjectTaskId" QueryStringField="AccountProjectTaskId"
        Type="Int32" />
<asp:Parameter Type="String" Name="AttachmentName" DefaultValue=""></asp:Parameter>
<asp:Parameter Type="String" Name="AttachmentLocalPath"></asp:Parameter>
</InsertParameters>
</asp:ObjectDataSource>
</ContentTemplate>
</asp:UpdatePanel>
&nbsp;
<asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        &nbsp;<asp:FormView id="FormView1" runat="server" DataSourceID="dsAccountProjectTaskAttachmentFormObject" DataKeyNames="AccountProjectTaskAttachmentId" DefaultMode="Insert" SkinID="formviewSkinEmployee" Width="656px" OnPageIndexChanging="FormView1_PageIndexChanging"><EditItemTemplate>
AccountProjectTaskAttachmentId: <asp:Label Text='<%# Eval("AccountProjectTaskAttachmentId") %>' runat="server" id="AccountProjectTaskAttachmentIdLabel1" /><br />
AccountProjectTaskId: <asp:TextBox Text='<%# Bind("AccountProjectTaskId") %>' runat="server" id="AccountProjectTaskIdTextBox" /><br />
AttachmentName: <asp:TextBox Text='<%# Bind("AttachmentName") %>' runat="server" id="AttachmentNameTextBox" /><br />
AttachmentLocalPath: <asp:TextBox Text='<%# Bind("AttachmentLocalPath") %>' runat="server" id="AttachmentLocalPathTextBox" /><br />
CreatedOn: <asp:TextBox Text='<%# Bind("CreatedOn") %>' runat="server" id="CreatedOnTextBox" /><br />
CreatedByEmployeeId: <asp:TextBox Text='<%# Bind("CreatedByEmployeeId") %>' runat="server" id="CreatedByEmployeeIdTextBox" /><br />
ModifiedOn: <asp:TextBox Text='<%# Bind("ModifiedOn") %>' runat="server" id="ModifiedOnTextBox" /><br />
ModifiedByEmployeeId: <asp:TextBox Text='<%# Bind("ModifiedByEmployeeId") %>' runat="server" id="ModifiedByEmployeeIdTextBox" /><br />
<asp:LinkButton runat="server" Text="Update" CommandName="Update" id="UpdateButton" CausesValidation="True" />&nbsp;<asp:LinkButton runat="server" Text="Cancel" CommandName="Cancel" id="UpdateCancelButton" CausesValidation="False" />
</EditItemTemplate>
<InsertItemTemplate>
<TABLE style="width: 100%" class="xview"><TBODY>
<TR><Th class="caption" colSpan=2 width="20%"><asp:Literal ID="Literal4" runat="server" Text="<%$ Resources:TimeLive.Resource, Project Task Attachment Information%> " /></Th></TR>
<TR><Th class="FormViewSubHeader" colSpan=2 width="20%"><asp:Literal ID="Literal2" runat="server" Text="<%$ Resources:TimeLive.Resource, Project Task Attachment%> " /></Th></TR>
<TR><TD class="FormViewLabelCell" align="right" width="20%">            <SPAN 
                  class=reqasterisk>*</SPAN> <asp:Literal ID="Literal1" runat="server" Text="<%$ Resources:TimeLive.Resource, Attachment Name:%> " /></td>
</TD><TD style="WIDTH: 32%"><asp:TextBox id="AttachmentNameTextBox" runat="server" Text='<%# Bind("AttachmentName") %>' Width="288px" ValidationGroup="Attachment"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="AttachmentNameTextBox"
        Display="Dynamic" ErrorMessage="*" ValidationGroup="Attachment"></asp:RequiredFieldValidator></TD></TR><TR><TD class="FormViewLabelCell" align="right" width="20%">            <SPAN 
                  class=reqasterisk>*</SPAN> <asp:Literal ID="Literal3" runat="server" Text="<%$ Resources:TimeLive.Resource, File Path:%> " /></td>
                  </TD><TD style="WIDTH: 32%">
                      <asp:FileUpload ID="AttachmentFileUpload" runat="server" Width="500px" /></TD></TR>
                      <TR><TD align="right" width="20%" style="height: 26px"></TD><TD style="WIDTH: 32%; height: 26px;"><asp:Button id="Upload" runat="server" Text="<%$ Resources:TimeLive.Resource, Upload_text%> " ValidationGroup="Attachment" OnClick="Upload_Click"></asp:Button></TD></TR></TBODY></TABLE>
</InsertItemTemplate>
<ItemTemplate>
AccountProjectTaskAttachmentId: <asp:Label Text='<%# Eval("AccountProjectTaskAttachmentId") %>' runat="server" id="AccountProjectTaskAttachmentIdLabel" /><br />
AccountProjectTaskId: <asp:Label Text='<%# Bind("AccountProjectTaskId") %>' runat="server" id="AccountProjectTaskIdLabel" /><br />
AttachmentName: <asp:Label Text='<%# Bind("AttachmentName") %>' runat="server" id="AttachmentNameLabel" /><br />
AttachmentLocalPath: <asp:Label Text='<%# Bind("AttachmentLocalPath") %>' runat="server" id="AttachmentLocalPathLabel" /><br />
CreatedOn: <asp:Label Text='<%# Bind("CreatedOn") %>' runat="server" id="CreatedOnLabel" /><br />
CreatedByEmployeeId: <asp:Label Text='<%# Bind("CreatedByEmployeeId") %>' runat="server" id="CreatedByEmployeeIdLabel" /><br />
ModifiedOn: <asp:Label Text='<%# Bind("ModifiedOn") %>' runat="server" id="ModifiedOnLabel" /><br />
ModifiedByEmployeeId: <asp:Label Text='<%# Bind("ModifiedByEmployeeId") %>' runat="server" id="ModifiedByEmployeeIdLabel" /><br />
<asp:LinkButton runat="server" Text="Delete" CommandName="Delete" id="DeleteButton" CausesValidation="False" />&nbsp;<asp:LinkButton runat="server" Text="New" CommandName="New" id="NewButton" CausesValidation="False" />
</ItemTemplate>
</asp:FormView> 
    </ContentTemplate>

</asp:UpdatePanel>
<br />
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<br />
<br />
&nbsp;<br />
&nbsp;
