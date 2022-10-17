<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlAccountProjectMilestoneList.ascx.vb" Inherits="AccountAdmin_Controls_ctlAccountProjectMilestoneList" %>
<%@ Register Assembly="eWorld.UI"
    Namespace="eWorld.UI" TagPrefix="ew" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate>
<x:GridView id="GridView1"  DataSourceID="dsAccountProjectMilestoneObject" 
        Width="98%" DataKeyNames="AccountProjectMilestoneId,Comments,Completed" 
        AutoGenerateColumns="False" runat="server" SkinID="xgridviewSkinEmployee" 
        Caption='<%# ResourceHelper.GetFromResource("Project Milestone List") %>'>
<Columns>
    <asp:BoundField DataField="AccountProjectMilestoneId" HeaderText="<%$ Resources:TimeLive.Resource, Id %>"
        InsertVisible="False" ReadOnly="True" SortExpression="AccountProjectMilestoneId" >
        <ItemStyle HorizontalAlign="Center" Width="5%" />
    </asp:BoundField>
    <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Milestone Date %>" SortExpression="MilestoneDate" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
        <edititemtemplate>
<asp:TextBox id="TextBox2" runat="server" Text='<%# Bind("MilestoneDate") %>' __designer:wfdid="w91"></asp:TextBox>
</edititemtemplate>
        <headertemplate>
<asp:LinkButton id="LinkButton4" runat="server" Text='<%# ResourceHelper.GetFromResource("Milestone Date") %>' CommandArgument="MilestoneDate" CommandName="Sort" CausesValidation="False"></asp:LinkButton>
</headertemplate>
        <itemtemplate>
<asp:Label id="Label2" runat="server" Text='<%# Bind("MilestoneDate", "{0:d}") %>' __designer:wfdid="w90"></asp:Label>
</itemtemplate>
        <itemstyle horizontalalign="Center" Width="10%" />
    </asp:TemplateField>
    <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Milestone Description %>" SortExpression="MilestoneDescription">
        <edititemtemplate>
<asp:TextBox id="TextBox1" runat="server" Text='<%# Bind("MilestoneDescription") %>' __designer:wfdid="w88"></asp:TextBox>
</edititemtemplate>
        <headertemplate>
<asp:LinkButton id="LinkButton3" runat="server" Text='<%# ResourceHelper.GetFromResource("Milestone Description") %>' CommandArgument="MilestoneDescription" CommandName="Sort" CausesValidation="False"></asp:LinkButton>
</headertemplate>
        <itemtemplate>
<asp:Label id="Label1" runat="server" Text='<%# Bind("MilestoneDescription") %>' __designer:wfdid="w87"></asp:Label>
</itemtemplate>
        <itemstyle horizontalalign="Left" width="45%" />
    </asp:TemplateField>
            <asp:BoundField DataField="Comments" HeaderText="Comments" 
        SortExpression="Comments">
            <ItemStyle Width="30%" />
    </asp:BoundField>
        <asp:TemplateField HeaderImageUrl="~/Images/Completed.gif"  >
            <EditItemTemplate>
                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Completed") %>'></asp:TextBox>
</EditItemTemplate>
            <ItemTemplate>
                <asp:Image ID="ImageCompleted" runat="server" ImageUrl="~/Images/Completed.gif" Visible='<%# IIF(IsDBNull(Eval("Completed")),"false",Eval("Completed")) %>' />
</ItemTemplate>
            <ItemStyle HorizontalAlign="Center" Width="5%" />
        </asp:TemplateField>
    <asp:CommandField HeaderText="<%$ Resources:TimeLive.Resource, Edit_text %>" SelectText="Edit" ShowSelectButton="True" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
        <ItemStyle Width="1%" cssclass="edit_button" />
    </asp:CommandField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Delete_text %>" >
                    <ItemTemplate>
<asp:LinkButton id="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete" ToolTip="<%$ Resources:TimeLive.Resource, Delete_text%> " Text="Delete" __designer:wfdid="w2" OnClientClick='<%# ResourceHelper.GetDeleteMessageJavascript()%>'></asp:LinkButton> 
</ItemTemplate>
                    <ItemStyle Width="1%" cssclass="delete_button" VerticalAlign="Bottom" HorizontalAlign="Center" />
                </asp:TemplateField>
        <asp:TemplateField><HeaderTemplate>
<asp:Image id="Image1" runat="server" ImageUrl="~/Images/Disabled.gif" ToolTip="<%$ Resources:TimeLive.Resource, Disabled_text%> "></asp:Image>
</HeaderTemplate>
<ItemTemplate>
<asp:Image id="Image1" runat="server" Visible='<%# IIF(IsDBNull(Eval("IsDisabled")),"false",Eval("IsDisabled")) %>' ImageUrl="~/Images/Disabled.gif" ToolTip="<%$ Resources:TimeLive.Resource, Disabled_text%> "></asp:Image>
</ItemTemplate>

<ItemStyle HorizontalAlign="Center" Width="1%"></ItemStyle>
</asp:TemplateField>
</Columns>
</x:GridView> <asp:ObjectDataSource id="dsAccountProjectMilestoneObject" 
        runat="server" TypeName="AccountProjectMilestoneBLL" 
        SelectMethod="GetAccountProjectMilestonesByAccountProjectId" 
        OldValuesParameterFormatString="original_{0}" 
        DeleteMethod="DeleteAccountProjectMilestone" 
        InsertMethod="AddAccountProjectMilestone" 
        UpdateMethod="UpdateAccountProjectMilestone">
        <DeleteParameters>
            <asp:Parameter Name="Original_AccountProjectMilestoneId" Type="Int32" />
            <asp:Parameter Name="original_Comments" Type="String" />
            <asp:Parameter Name="original_Completed" Type="Boolean" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="AccountId" Type="Int32" />
            <asp:Parameter Name="AccountProjectId" Type="Int32" />
            <asp:Parameter Name="MilestoneDescription" Type="String" />
            <asp:Parameter Name="MilestoneDate" Type="DateTime" />
            <asp:Parameter Name="CreatedOn" Type="DateTime" />
            <asp:Parameter Name="CreatedByEmployeeId" Type="Int32" />
            <asp:Parameter Name="ModifiedOn" Type="DateTime" />
            <asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" />
            <asp:Parameter Name="Comments" Type="String" />
            <asp:Parameter Name="Completed" Type="Boolean" />
            <asp:Parameter Name="IsWebServiceCall" Type="Boolean" />
            <asp:Parameter Name="IsDisabled" Type="Boolean" />
        </InsertParameters>
    <SelectParameters>
        <asp:QueryStringParameter DefaultValue="1" Name="AccountProjectId" 
            QueryStringField="AccountProjectId" Type="Int32" />
        <asp:Parameter Name="NotFixTable" Type="Boolean" />
    </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="AccountId" Type="Int32" />
            <asp:Parameter Name="AccountProjectId" Type="Int32" />
            <asp:Parameter Name="MilestoneDescription" Type="String" />
            <asp:Parameter Name="MilestoneDate" Type="DateTime" />
            <asp:Parameter Name="Original_AccountProjectMilestoneId" Type="Int32" />
            <asp:Parameter Name="CreatedOn" Type="DateTime" />
            <asp:Parameter Name="CreatedByEmployeeId" Type="Int32" />
            <asp:Parameter Name="ModifiedOn" Type="DateTime" />
            <asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" />
            <asp:Parameter Name="Comments" Type="String" />
            <asp:Parameter Name="Completed" Type="Boolean" />
            <asp:Parameter Name="IsDisabled" Type="Boolean" />
        </UpdateParameters>
</asp:ObjectDataSource> 
<asp:ObjectDataSource id="dsAccountProjectMilestoneFormObject" runat="server" UpdateMethod="UpdateAccountProjectMilestone" TypeName="AccountProjectMilestoneBLL" SelectMethod="GetAccountProjectMilestonesByAccountProjectMilestoneId" OldValuesParameterFormatString="original_{0}" InsertMethod="AddAccountProjectMilestone" DeleteMethod="DeleteAccountProjectMilestone">
    <DeleteParameters>
        <asp:Parameter Name="Original_AccountProjectMilestoneId" Type="Int32"  />
    </DeleteParameters>
    <UpdateParameters>
        <asp:SessionParameter DefaultValue="23" Name="AccountId" SessionField="AccountId"
            Type="Int32" />
        <asp:QueryStringParameter DefaultValue="3" Name="AccountProjectId" QueryStringField="AccountProjectId"
            Type="Int32" />
        <asp:Parameter Name="MilestoneDescription" Type="String"  />
        <asp:Parameter Name="MilestoneDate" Type="DateTime"  />
        <asp:Parameter Name="Original_AccountProjectMilestoneId" Type="Int32"  />
        <asp:Parameter Name="CreatedOn" Type="DateTime" />
        <asp:Parameter Name="CreatedByEmployeeId" Type="Int32" />
        <asp:Parameter Name="ModifiedOn" Type="DateTime" />
        <asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" />
        <asp:Parameter Name="Comments" Type="String" />
        <asp:Parameter Name="Completed" Type="Boolean" />
        <asp:Parameter Name="IsDisabled" Type="Boolean" />
        
    </UpdateParameters>
    <SelectParameters>
        <asp:ControlParameter ControlID="GridView1" DefaultValue="0" 
            Name="AccountProjectMilestoneId" PropertyName="SelectedValue" Type="Int32" />
    </SelectParameters>
    <InsertParameters>
        <asp:SessionParameter DefaultValue="23" Name="AccountId" SessionField="AccountId"
            Type="Int32" />
        <asp:QueryStringParameter DefaultValue="3" Name="AccountProjectId" QueryStringField="AccountProjectId"
            Type="Int32" />
        <asp:Parameter Name="MilestoneDescription" Type="String"  />
        <asp:Parameter Name="MilestoneDate" Type="DateTime"  />
        <asp:Parameter Name="CreatedOn" Type="DateTime" />
        <asp:Parameter Name="CreatedByEmployeeId" Type="Int32" />
        <asp:Parameter Name="ModifiedOn" Type="DateTime" />
        <asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" />
        <asp:Parameter Name="Comments" Type="String" />
        <asp:Parameter Name="Completed" Type="Boolean" />
        <asp:Parameter Name="IsDisabled" Type="Boolean" />
        <asp:Parameter Name="IsWebServiceCall" Type="Boolean" />
    </InsertParameters>
</asp:ObjectDataSource>
    &nbsp;
</ContentTemplate>
</asp:UpdatePanel>

<asp:UpdatePanel ID="UpdatePanel2" runat="server"><ContentTemplate>
<asp:FormView id="FormView1" DataSourceID="dsAccountProjectMilestoneFormObject" DataKeyNames="AccountProjectMilestoneId" runat="server" DefaultMode="Insert" SkinID="formviewSkinEmployee" Width="550px" OnDataBound="FormView1_DataBound">
<EditItemTemplate>
        <table style="width: 100%" class="xview">
            <tr>
                <th class="caption" colspan="2">
                                        <asp:Literal ID="Literal1" runat="server" Text='<%# ResourceHelper.GetFromResource("Project Milestone Information") %>' /></th>
            </tr>
            <tr>
                <th class="FormViewSubHeader" colspan="2">
                                        <asp:Literal ID="Literal2" runat="server" Text='<%# ResourceHelper.GetFromResource("Project Milestone") %>' /></th>
            </tr>
            <tr>
                <td style="height: 26px; width: 30%;" class="FormViewLabelCell" align="right" valign="middle">
                                                        <span class="reqasterisk">*</span><asp:Literal ID="Literal45" runat="server" 
                                                            Text='<%# ResourceHelper.GetFromResource("Milestone Date:") %>' />
                </td><td style="width: 70%; height: 26px">
                    <ew:CalendarPopup ID="CalendarPopup1" runat="server" 
                        SelectedValue='<%# Bind("MilestoneDate") %>' SkinId="DatePicker" 
                        Width="55px">
                    </ew:CalendarPopup>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                        ControlToValidate="CalendarPopup1" Display="Dynamic" ErrorMessage="*" 
                        Width="1px"></asp:RequiredFieldValidator>
                </td></tr><tr>
                <td align="right" class="FormViewLabelCell" style="height: 26px; width: 30%;" 
                    valign="middle"><span class="reqasterisk">*</span> &nbsp;<asp:Label 
                        ID="UserNameLabel" runat="server" 
                        AssociatedControlID="MilestoneDescriptionTextBox">
                  <asp:Literal ID="Literal3" runat="server" 
                        Text='<%# ResourceHelper.GetFromResource("Milestone Description:") %>' /></asp:Label></td><td 
                    style="width: 70%; height: 26px;"><asp:TextBox ID="MilestoneDescriptionTextBox" 
                        runat="server" MaxLength="50" Text='<%# Bind("MilestoneDescription") %>' 
                        Width="300px"></asp:TextBox><asp:RequiredFieldValidator 
                        ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="MilestoneDescriptionTextBox" Display="Dynamic" ErrorMessage="*" 
                        Width="8px"></asp:RequiredFieldValidator></td></tr><tr>
                <td align="right" class="FormViewLabelCell" style="height: 26px; width: 30%;" 
                    valign="top">
                    Comments:</td><td style="width: 70%; height: 26px;">
                    <asp:TextBox ID="MilestoneCommentsTextBox" runat="server" Height="61px" 
                        MaxLength="250" Text='<%# Bind("Comments") %>' TextMode="MultiLine" 
                        Width="300px"></asp:TextBox></td></tr><tr>
                <td align="right" class="FormViewLabelCell" style="width: 30%; height: 26px;" 
                    valign="middle">
                    Completed:</td><td style="width: 70%; height: 26px;">
                    <asp:CheckBox ID="chkCompleted" runat="server" />
                </td>
            </tr>
            <tr><td style="HEIGHT: 26px" class="FormViewLabelCell" align=right width="30%">
            <asp:Literal id="Literal5" runat="server" Text="<%$ Resources:TimeLive.Resource, Disabled:%> "></asp:Literal></td><td width="70%">
            <asp:CheckBox id="IsDisabledCheckBox" runat="server" Width="168px" ></asp:CheckBox></td></tr>
            <tr>
                <td style="height: 26px; width: 30%;" align="right">
                </td>
                <td style="width: 70%; height: 26px; padding-bottom: 5px;">
                    <asp:Button ID="Button1" 
                        runat="server" CommandName="Update" 
                        Text="<%$ Resources:TimeLive.Resource, Update_text%> " Width="68px" 
                        onclick="Button1_Click" />&nbsp;<asp:Button ID="Button2" runat="server" 
                        CommandName="Cancel" Text="<%$ Resources:TimeLive.Resource, Cancel_text%> " 
                        Width="68px" onclick="Button2_Click" /></td>
            </tr>
        </table>
    
</EditItemTemplate>
<InsertItemTemplate>
        <table style="width: 100%" class="xview">
            <tr>
                <th class="caption" colspan="2" style="height: 21px">
                     <asp:Literal ID="Literal4" runat="server" Text='<%# ResourceHelper.GetFromResource("Project Milestone Information") %>' /></th>
            </tr>
            <tr>
                <th class="FormViewSubHeader" colspan="2" style="height: 21px">
                     <asp:Literal ID="Literal5" runat="server" Text='<%# ResourceHelper.GetFromResource("Project Milestone") %>' /></th>
            </tr>
            <tr>
                <td 
                    align="right" class="FormViewLabelCell" style="width: 30%;" valign="middle"><span class="reqasterisk">*</span><asp:Literal ID="Literal7" runat="server" 
                        Text='<%# ResourceHelper.GetFromResource("Milestone Date:") %>' />
                </td>
                <td style="width: 70%"><ew:CalendarPopup ID="CalendarPopup1" runat="server" 
                        SelectedValue='<%# Bind("MilestoneDate") %>' SkinId="DatePicker" 
                        Width="55px"></ew:CalendarPopup>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                        ControlToValidate="CalendarPopup1" Display="Dynamic" ErrorMessage="*" 
                        Width="1px"></asp:RequiredFieldValidator></td></tr><tr><td 
                    align="right" class="FormViewLabelCell" style="width: 30%;" valign="middle"><span 
                    class="reqasterisk">*</span><asp:Label ID="UserNameLabel" runat="server" 
                    AssociatedControlID="MilestoneDescriptionTextBox">
                  <asp:Literal ID="Literal6" runat="server" 
                Text='<%# ResourceHelper.GetFromResource("Milestone Description:") %>' /></asp:Label></td><td 
                    style="width: 70%"><asp:TextBox ID="MilestoneDescriptionTextBox" runat="server" 
                        MaxLength="50" Text='<%# Bind("MilestoneDescription") %>' Width="300px"></asp:TextBox><asp:RequiredFieldValidator 
                        ID="RequiredFieldValidator3" runat="server" 
                        ControlToValidate="MilestoneDescriptionTextBox" Display="Dynamic" 
                        ErrorMessage="*" Width="8px"></asp:RequiredFieldValidator></td></tr><tr>
                <td 
                    align="right" class="FormViewLabelCell" style="width: 30%;" valign="top">Comments:</td><td 
                    style="width: 70%; padding-bottom: 5px;"><asp:TextBox ID="MilestoneCommentsTextBox" runat="server" Height="61px" 
                        MaxLength="250" Text='<%# Bind("Comments") %>' TextMode="MultiLine" 
                        Width="300px"></asp:TextBox></td></tr><tr>
                <td align="right" 
                    style="width: 30%"></td>
                <td style="width: 75%; padding-bottom: 5px;">
                    <asp:Button ID="Add" runat="server" CommandName="Insert" Text="<%$ Resources:TimeLive.Resource, Add_text%> " Width="55px" /></td>
            </tr>
        </table>
    
</InsertItemTemplate>
<ItemTemplate>
        AccountProjectMilestoneId: <asp:Label ID="AccountProjectMilestoneIdLabel" runat="server" Text='<%# Eval("AccountProjectMilestoneId") %>'>
        </asp:Label><br  />AccountId: <asp:Label ID="AccountIdLabel" runat="server" Text='<%# Bind("AccountId") %>'></asp:Label><br  />AccountProjectId: <asp:Label ID="AccountProjectIdLabel" runat="server" Text='<%# Bind("AccountProjectId") %>'>
        </asp:Label><br  />MilestoneDescription: <asp:Label ID="MilestoneDescriptionLabel" runat="server" Text='<%# Bind("MilestoneDescription") %>'>
        </asp:Label><br  />MilestoneDate: <asp:Label ID="MilestoneDateLabel" runat="server" Text='<%# Bind("MilestoneDate") %>'>
        </asp:Label><br  /><asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" CommandName="Edit"
            Text="Edit">
        </asp:LinkButton><asp:LinkButton ID="DeleteButton" runat="server" CausesValidation="False" CommandName="Delete"
            Text="Delete">
        </asp:LinkButton><asp:LinkButton ID="NewButton" runat="server" CausesValidation="False" CommandName="New"
            Text="New">
        </asp:LinkButton></ItemTemplate></asp:FormView></ContentTemplate></asp:UpdatePanel>