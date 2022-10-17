<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlAccountApprovalForm.ascx.vb" Inherits="AccountAdmin_Controls_ctlAccountApprovalForm" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
   
        <asp:FormView ID="FormView1" runat="server" DataKeyNames="AccountApprovalTypeId"
            DataSourceID="dsAccountApprovalTypeObject" DefaultMode="Insert" SkinID="formviewSkinEmployee"
            Width="98%">
            <EditItemTemplate><table width="100%" class="xForm">
                <tr>
                    <th class="caption" colspan="2">
                        <asp:Literal ID="Literal1" runat="server" Text='<%# ResourceHelper.GetFromResource("Approval Type")%> ' /></th>
                </tr>
                <tr>
                    <th class="FormViewSubHeader" colspan="2">
                        <asp:Literal ID="Literal2" runat="server" Text='<%# ResourceHelper.GetFromResource("Approval Type")%> ' /></th>
                </tr>
                <tr>
                    <td style="width: 25%" align="right" class="formviewlabelcell">
                        

<asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="ApprovalTypeNameTextBox">
                        <asp:Literal ID="Literal3" runat="server" Text='<%# ResourceHelper.GetFromResource("Approval Type Name:")%> ' /></asp:Label></td><td style="width: 75%">
                        <asp:TextBox ID="ApprovalTypeNameTextBox" runat="server" Text='<%# Bind("ApprovalTypeName") %>' Width="450px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ApprovalTypeNameTextBox"
                            CssClass="ErrorMessage" Display="Dynamic" ErrorMessage="*" Width="1px"></asp:RequiredFieldValidator></td></tr><tr>
                    <td align="right" class="formviewlabelcell" style="width: 25%">
                        <asp:Literal ID="Literal6" runat="server" Text='<%# ResourceHelper.GetFromResource("Is Time Off Approval:")%> ' /></td>
                    <td style="width: 75%">
                        <asp:CheckBox ID="chkIsTimeOff" runat="server" 
                            Checked='<%# IIF(Isdbnull(Eval("IsTimeOffApprovalTypes")),"false",Eval("IsTimeOffApprovalTypes")) %>' 
                            Enabled='<%# IIF(Isdbnull(Eval("AccountApprovalTypeId")),"True","False") %>' /></td>
                </tr>
                <tr>
                    <td colspan="2">
                        <x:GridView ID="GridView1" runat="server" 
                            AutoGenerateColumns="False" Caption="<%$ Resources:TimeLive.Resource, Approval Path %>"
                                CssClass="xGridViewInside" DataKeyNames="AccountApprovalPathId,AccountId,AccountApprovalTypeId,SystemApproverTypeId,AccountExternalUserId,AccountEmployeeId,ApprovalPathSequence"
                                DataSourceID="dsAccountApprovalPathObject" OnRowUpdating="GridView1_RowUpdating"
                                Width="99%" 
                            OnRowDataBound="GridView1_RowDataBound"><Columns>
                <asp:TemplateField>
<itemtemplate>
        <asp:CheckBox id="chkDelete" runat="server"></asp:CheckBox> 
</itemtemplate>
               <itemstyle width="1%" horizontalalign="Center" verticalalign="Middle" /></asp:TemplateField>                            
                                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Approver Type %>" SortExpression="SystemApproverTypeId">
                                    <ItemTemplate>
                                        <asp:DropDownList ID="ddlSystemApproverTypeId" runat="server" DataSourceID="dsSystemApproverTypeObject"
                                                DataTextField="SystemApproverType" DataValueField="SystemApproverTypeId" SelectedValue='<%# Bind("SystemApproverTypeId") %>'
                                                Width="100%" AutoPostBack="True" OnSelectedIndexChanged="ddlSystemApproverTypeId_SelectedIndexChanged" AppendDataBoundItems="True">
                                            <asp:ListItem Selected="True" Value="0" Label ID="Label1" runat="server" Text="<%$ Resources:TimeLive.Resource, Select%> "></asp:ListItem><%--<asp:ListItem Selected="True" Value="0">&lt;Select&gt;</asp:ListItem>--%></asp:DropDownList><asp:ObjectDataSource ID="dsSystemApproverTypeObject" runat="server"
                                                OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="TimeLiveDataSetTableAdapters.SystemApproverTypeTableAdapter">
                                        </asp:ObjectDataSource>
                                    
</ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="31%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, External User %>" SortExpression="AccountExternalUserId">
                                    <ItemTemplate>
                                        <asp:DropDownList ID="ddlAccountExternalUserId" runat="server" AppendDataBoundItems="True"
                                                DataSourceID="dsExternalUserObject" DataTextField="EmployeeName" DataValueField="AccountEmployeeId"
                                                 Width="100%">
                                            <asp:ListItem Selected="True" Value="0" Label ID="Label2" runat="server" Text="<%$ Resources:TimeLive.Resource, Select%> "></asp:ListItem><%--<asp:ListItem Selected="True" Value="0">&lt;Select&gt;</asp:ListItem>--%></asp:DropDownList><asp:ObjectDataSource ID="dsExternalUserObject" runat="server"
                                                OldValuesParameterFormatString="original_{0}" SelectMethod="GetAccountEmployeesForExternalUser"
                                                TypeName="AccountEmployeeBLL">
                                            <SelectParameters>
                                                <asp:SessionParameter DefaultValue="64" Name="AccountId" SessionField="AccountId"
                                                        Type="Int32" />
                                            </SelectParameters>
                                        </asp:ObjectDataSource>
                                    
</ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="31%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Employee %>" SortExpression="AccountEmployeeId">
                                    <ItemTemplate>
<asp:DropDownList id="ddlAccountEmployeeId" runat="server" Width="100%" DataSourceID="dsAccountEmployeeObject" __designer:wfdid="w19" DataValueField="AccountEmployeeId" DataTextField="FullName" AppendDataBoundItems="True">
                                            <asp:ListItem Selected="True" Value="0" Label ID="Label3" runat="server" Text="<%$ Resources:TimeLive.Resource, Select%> "></asp:ListItem><%--<asp:ListItem Selected="True" Value="0">&lt;Select&gt;</asp:ListItem>--%></asp:DropDownList><asp:ObjectDataSource id="dsAccountEmployeeObject" runat="server" TypeName="AccountEmployeeBLL" SelectMethod="GetAccountEmployeesByAccountIdAndIsDisabled" OldValuesParameterFormatString="original_{0}" __designer:wfdid="w20"><SelectParameters>
<asp:SessionParameter SessionField="AccountId" DefaultValue="64" Name="AccountId" Type="Int32"></asp:SessionParameter>
<asp:Parameter Name="AccountEmployeeId" Type="Int32"></asp:Parameter>
</SelectParameters>
</asp:ObjectDataSource> 
</ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="30%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Sequence" SortExpression="ApprovalPathSequence">
                                    <ItemTemplate>
                                        <asp:DropDownList ID="ddlApprovalPathSequence" runat="server" AppendDataBoundItems="True" Width="99%"><asp:ListItem Value="1">1st</asp:ListItem><asp:ListItem Value="2">2nd</asp:ListItem><asp:ListItem Value="3">3rd</asp:ListItem><asp:ListItem Value="4">4th</asp:ListItem><asp:ListItem Value="5">5th</asp:ListItem></asp:DropDownList></ItemTemplate><ItemStyle HorizontalAlign="Center" Width="8%" /></asp:TemplateField>
                                <asp:TemplateField HeaderText="AccountApprovalPathId" InsertVisible="False" SortExpression="AccountApprovalPathId" Visible="False">
                                    <EditItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("AccountApprovalPathId") %>'></asp:Label></EditItemTemplate><ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("AccountApprovalPathId") %>'></asp:Label></ItemTemplate><ItemStyle Width="0%" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="AccountId" HeaderText="AccountId" SortExpression="AccountId" Visible="False" >
                                    <ItemStyle Width="0%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="AccountApprovalTypeId" HeaderText="AccountApprovalTypeId"
                                        SortExpression="AccountApprovalTypeId" Visible="False" >
                                    <ItemStyle Width="0%" />
                                </asp:BoundField>
                            </Columns>
                        </x:GridView>
                    </td>
                </tr>
                <tr>
                    <td align="left" colspan="1">
                        &nbsp&nbsp<asp:LinkButton ID="CheckAll" runat="server" CssClass="FeatureHeadingIcon" OnClick="CheckAll_Click"
                            OnClientClick="ChangeAllCheckBoxStates1(true);">
                            <asp:Literal ID="Literal19" runat="server" Text="<%$ Resources:TimeLive.Resource, Check-All %>"></asp:Literal>
                        </asp:LinkButton>
                        <asp:LinkButton ID="UnCheckAll" runat="server" CssClass="FeatureHeadingIcon"
                            OnClick="UnCheckAll_Click" OnClientClick="ChangeAllCheckBoxStates1(false);">
                            <asp:Literal ID="Literal20" runat="server" Text="<%$ Resources:TimeLive.Resource, Uncheck-All %>"></asp:Literal>
                        </asp:LinkButton></td><td align="right" style="padding-bottom: 6px; padding-top: 5px; padding-right: 5px;"><asp:Button 
                            ID="btnDelete" runat="server" OnClick="btnDelete_Click" 
                            Text="<%$ Resources:TimeLive.Resource, Delete Selected%> " Width="80px" />
                            <asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" Text="<%$ Resources:TimeLive.Resource, Update_text%> " Width="68px" /></td>
                </tr>
            </table>
            </EditItemTemplate>
            <InsertItemTemplate>
                <table width="100%" class="xview">
                    <tr>
                        <th class="caption" colspan="2">
                            <asp:Literal ID="Literal1" runat="server" Text='<%# ResourceHelper.GetFromResource("Approval Type")%> ' /></th>
                    </tr>
                    <tr>
                        <th class="FormViewSubHeader" colspan="2">
                            <asp:Literal ID="Literal4" runat="server" Text='<%# ResourceHelper.GetFromResource("Approval Type")%> ' /></th>
                    </tr>
                    <tr>
                        <td style="width: 25%" align="right" class="formviewlabelcell">
                            
            <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="ApprovalTypeNameTextBox">
                            <asp:Literal ID="Literal5" runat="server" Text='<%# ResourceHelper.GetFromResource("Approval Type Name:")%> ' /></asp:Label></td><td style="width: 75%">
                            <asp:TextBox ID="ApprovalTypeNameTextBox" runat="server" Text='<%# Bind("ApprovalTypeName") %>' Width="450px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ApprovalTypeNameTextBox"
                                CssClass="ErrorMessage" Display="Dynamic" ErrorMessage="*" Width="1px"></asp:RequiredFieldValidator></td></tr><tr>
                        <td align="right" class="formviewlabelcell" style="width: 25%">
                            <asp:Literal ID="Literal3" runat="server" Text='<%# ResourceHelper.GetFromResource("Is Time Off Approval:")%> ' />
                        </td>
                        <td style="width: 75%">
                            <asp:CheckBox ID="chkIsTimeOff" runat="server" Checked='<%# Bind("IsTimeOffApprovalTypes") %>' /></td>
                    </tr>
                    <tr>
                        <td colspan="2">
                      <x:GridView ID="GridView1" runat="server" 
                            AutoGenerateColumns="False" Caption="<%$ Resources:TimeLive.Resource, Approval Path %>"
                                CssClass="xGridViewInside" DataKeyNames="AccountApprovalPathId,AccountId,AccountApprovalTypeId,SystemApproverTypeId,AccountExternalUserId,AccountEmployeeId,ApprovalPathSequence"
                                DataSourceID="dsAccountApprovalPathObject" OnRowUpdating="GridView1_RowUpdating"
                                Font-Bold="False" Width="99%" 
                            OnRowDataBound="GridView1_RowDataBound">
                                <Columns>
                                    <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Approver Type %>" SortExpression="SystemApproverTypeId">
                                        <ItemTemplate>
                                            <asp:DropDownList ID="ddlSystemApproverTypeId" runat="server" DataSourceID="dsSystemApproverTypeObject"
                                                DataTextField="SystemApproverType" DataValueField="SystemApproverTypeId" SelectedValue='<%# Bind("SystemApproverTypeId") %>'
                                                Width="100%" AutoPostBack="True" OnSelectedIndexChanged="ddlSystemApproverTypeId_SelectedIndexChanged" AppendDataBoundItems="True">
                                                <asp:ListItem Selected="True" Value="0" Label ID="Label4" runat="server" Text="<%$ Resources:TimeLive.Resource, Select%> "></asp:ListItem><%--<asp:ListItem Selected="True" Value="0">&lt;Select&gt;</asp:ListItem>--%></asp:DropDownList><asp:ObjectDataSource ID="dsSystemApproverTypeObject" runat="server"
                                                OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="TimeLiveDataSetTableAdapters.SystemApproverTypeTableAdapter">
                                            </asp:ObjectDataSource>
                                        
</ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="31%" /></asp:TemplateField>
                                    <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, External User %>" SortExpression="AccountExternalUserId">
                                        <ItemTemplate>
                                            <asp:DropDownList ID="ddlAccountExternalUserId" runat="server" AppendDataBoundItems="True"
                                                DataSourceID="dsExternalUserObject" DataTextField="EmployeeName" DataValueField="AccountEmployeeId"
                                                SelectedValue='<%# Bind("AccountExternalUserId") %>' Width="100%">
                                                <asp:ListItem Selected="True" Value="0" Label ID="Label7" runat="server" Text="<%$ Resources:TimeLive.Resource, Select%> "></asp:ListItem><%--<asp:ListItem Selected="True" Value="0">&lt;Select&gt;</asp:ListItem>--%></asp:DropDownList><asp:ObjectDataSource ID="dsExternalUserObject" runat="server"
                                                OldValuesParameterFormatString="original_{0}" SelectMethod="GetAccountEmployeesForExternalUser"
                                                TypeName="AccountEmployeeBLL">
                                                <SelectParameters>
                                                    <asp:SessionParameter DefaultValue="64" Name="AccountId" SessionField="AccountId"
                                                        Type="Int32" />
                                                </SelectParameters>
                                            </asp:ObjectDataSource>
                                        
</ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="31%" /></asp:TemplateField>
                                    <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Employee %>" SortExpression="AccountEmployeeId">
                                        <ItemTemplate>
<asp:DropDownList id="ddlAccountEmployeeId" runat="server" Width="100%" DataSourceID="dsAccountEmployeeObject" __designer:wfdid="w9" SelectedValue='<%# Bind("AccountEmployeeId") %>' DataValueField="AccountEmployeeId" DataTextField="FullName" AppendDataBoundItems="True">
                                                <asp:ListItem Selected="True" Value="0" Label ID="Label5" runat="server" Text="<%$ Resources:TimeLive.Resource, Select%> "></asp:ListItem><%--<asp:ListItem Selected="True" Value="0">&lt;Select&gt;</asp:ListItem>--%></asp:DropDownList><asp:ObjectDataSource id="dsAccountEmployeeObject" runat="server" TypeName="AccountEmployeeBLL" SelectMethod="GetAccountEmployeesByAccountIdAndIsDisabled" OldValuesParameterFormatString="original_{0}" __designer:wfdid="w10"><SelectParameters>
<asp:SessionParameter SessionField="AccountId" DefaultValue="64" Name="AccountId" Type="Int32"></asp:SessionParameter>
<asp:Parameter DefaultValue="0" Name="AccountEmployeeId" Type="Int32"></asp:Parameter>
</SelectParameters>
</asp:ObjectDataSource> 
</ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="30%" /></asp:TemplateField>
                                    <asp:TemplateField HeaderText="Sequence" SortExpression="ApprovalPathSequence">
                                        <ItemTemplate>
                                            <asp:DropDownList ID="ddlApprovalPathSequence" runat="server" AppendDataBoundItems="True"
                                                SelectedValue='<%# Bind("ApprovalPathSequence") %>' Width="99%"><asp:ListItem Value="1">1st</asp:ListItem><asp:ListItem Value="2">2nd</asp:ListItem><asp:ListItem Value="3">3rd</asp:ListItem><asp:ListItem Value="4">4th</asp:ListItem><asp:ListItem Value="5">5th</asp:ListItem></asp:DropDownList></ItemTemplate><ItemStyle 
                                            HorizontalAlign="Center" Width="8%" /></asp:TemplateField>
                                    <asp:TemplateField HeaderText="AccountApprovalPathId" InsertVisible="False" SortExpression="AccountApprovalPathId" Visible="False">
                                        <EditItemTemplate>
                                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("AccountApprovalPathId") %>'></asp:Label></EditItemTemplate><ItemTemplate>
                                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("AccountApprovalPathId") %>'></asp:Label></ItemTemplate><ItemStyle Width="0%" />
                                        </asp:TemplateField>
                                            <asp:BoundField DataField="AccountId" HeaderText="AccountId" SortExpression="AccountId" Visible="False" />
                                    <asp:BoundField DataField="AccountApprovalTypeId" HeaderText="AccountApprovalTypeId"
                                        SortExpression="AccountApprovalTypeId" Visible="False" />
                                </Columns>
                            </x:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" colspan="2" style="padding-bottom: 5px; padding-Top: 5px; padding-right:5px;">
                            <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="<%$ Resources:TimeLive.Resource, Add_text%> " Width="68px" /></td>
                    </tr>
                </table>
            </InsertItemTemplate>
            <ItemTemplate>
                AccountApproverTypeId: <asp:Label ID="AccountApproverTypeIdLabel" runat="server" Text='<%# Eval("AccountApproverTypeId") %>'>
                </asp:Label><br />ApproverTypeName: <asp:Label ID="ApproverTypeNameLabel" runat="server" Text='<%# Bind("ApproverTypeName") %>'>
                </asp:Label><br />AccountId: <asp:Label ID="AccountIdLabel" runat="server" Text='<%# Bind("AccountId") %>'></asp:Label><br />MasterApprovalTypeId: <asp:Label ID="MasterApprovalTypeIdLabel" runat="server" Text='<%# Bind("MasterApprovalTypeId") %>'>
                </asp:Label><br /><asp:LinkButton ID="NewButton" runat="server" CausesValidation="False" CommandName="New"
                    Text="New">
                </asp:LinkButton></ItemTemplate></asp:FormView><asp:ObjectDataSource ID="dsAccountApprovalTypeObject" runat="server" InsertMethod="AddAccountApprovalType"
            OldValuesParameterFormatString="original_{0}" OnInserting="dsAccountApprovalTypeObject_Inserting"
            SelectMethod="GetAccountApprovalTypesByAccountApprovalTypeId" TypeName="AccountApprovalBLL" UpdateMethod="UpdateAccountApprovalType" DeleteMethod="DeleteAccountApprovals">
            <InsertParameters>
                <asp:Parameter Name="ApprovalTypeName" Type="String" />
                <asp:Parameter Name="AccountId" Type="Int32" />
                <asp:Parameter Name="MasterAccountApprovalTypeId" Type="Int32" />
                <asp:Parameter Name="IsTimeOffApprovalTypes" Type="Boolean" />
            </InsertParameters>
            <SelectParameters>
                <asp:Parameter Name="AccountApprovalTypeId" Type="Int32" />
                <asp:SessionParameter DefaultValue="64" Name="AccountId" SessionField="AccountId"
                    Type="Int32" />
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter Name="ApprovalTypeName" Type="String" />
                <asp:Parameter Name="AccountId" Type="Int32" />
                <asp:Parameter Name="MasterAccountApprovalTypeId" Type="Int32" />
                <asp:Parameter Name="Original_AccountApprovalTypeId" Type="Int32" />
                <asp:Parameter Name="IsTimeOffApprovalTypes" Type="Boolean" />
            </UpdateParameters>
            <DeleteParameters>
                <asp:Parameter Name="Original_AccountApprovalTypeId" Type="Int32" />
            </DeleteParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="dsAccountApprovalPathObject" runat="server" InsertMethod="AddAccountApprovalPath"
            OldValuesParameterFormatString="original_{0}" OnInserting="dsAccountApprovalPathObject_Inserting"
            SelectMethod="GetAccountApprovalPathsByAccountApprovalTypeId" TypeName="AccountApprovalBLL" UpdateMethod="UpdateAccountApprovalPath" DeleteMethod="DeleteAccountApprovalPath">
            <InsertParameters>
                <asp:SessionParameter DefaultValue="64" Name="AccountId" SessionField="AccountId"
                    Type="Int32" />
                <asp:Parameter Name="AccountApprovalTypeId" Type="Int32" />
                <asp:Parameter Name="SystemApproverTypeId" Type="Int16" />
                <asp:Parameter Name="AccountExternalUserId" Type="Int32" />
                <asp:Parameter Name="AccountEmployeeId" Type="Int32" />
                <asp:Parameter Name="ApprovalPathSequence" Type="String" />
            </InsertParameters>
            <SelectParameters>
                <asp:Parameter Name="AccountApprovalTypeId" Type="Int32" />
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter Name="AccountId" Type="Int32" />
                <asp:Parameter Name="AccountApprovalTypeId" Type="Int32" />
                <asp:Parameter Name="SystemApproverTypeId" Type="Int16" />
                <asp:Parameter Name="AccountExternalUserId" Type="Int32" />
                <asp:Parameter Name="AccountEmployeeId" Type="Int32" />
                <asp:Parameter Name="ApprovalPathSequence" Type="String" />
                <asp:Parameter Name="Original_AccountApprovalPathId" Type="Int32" />
            </UpdateParameters>
            <DeleteParameters>
                <asp:Parameter Name="Original_AccountApprovalPathId" Type="Int32" />
            </DeleteParameters>
        </asp:ObjectDataSource>
    </ContentTemplate>
</asp:UpdatePanel>
