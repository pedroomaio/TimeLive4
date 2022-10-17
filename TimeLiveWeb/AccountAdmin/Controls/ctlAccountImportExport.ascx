<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlAccountImportExport.ascx.vb" Inherits="AccountAdmin_Controls_ctlAccountImportExport" %>
<%@ Register Assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2"
    Namespace="eWorld.UI" TagPrefix="ew" %>

    <table class="xFormView"><tr><td>
<table style="width: 600px" class="xFormView" >
    <tr><th class="caption" colspan="4" style="height: 21px"><asp:Literal ID="Literal9" runat="server" Text="<%$ Resources:TimeLive.Resource, CSV Import Export%> " /></th></tr>
    <tr>
        <td style="width: 150px" align="right">
            <asp:Literal ID="Literal1" runat="server" Text="<%$ Resources:TimeLive.Resource, Import / Export%> " /></td>
        <td style="width: 80px">
            <asp:RadioButton ID="radExport" runat="server" AutoPostBack="True" GroupName="ImportExport"
                Text="<%$ Resources:TimeLive.Resource, Export %>" />
            </td>                    
        <td style="width: 150px">
            <asp:RadioButton ID="radImport" runat="server" AutoPostBack="True"
                    GroupName="ImportExport" Text="<%$ Resources:TimeLive.Resource, Import %>" /></td>                    
        <td style="width: 425px">
            &nbsp;</td>                    
    </tr>
    <tr>
        <td style="width: 150px" align="right">
            <asp:Literal ID="Literal8" runat="server" Text="<%$ Resources:TimeLive.Resource, File Type: %>" /></td>
        <td style="width: 80px">
            <asp:RadioButton ID="radDelimited" runat="server" AutoPostBack="True" GroupName="ExportType"
                Text="<%$ Resources:TimeLive.Resource, CSV %>" /></td>                    
        <td style="width: 150px">
            <asp:RadioButton ID="radIIF" runat="server" AutoPostBack="True"
                    GroupName="ExportType" Text="<%$ Resources:TimeLive.Resource, Quickbooks (IIF) %>" />
            </td>                    
        <td style="width: 425px">
            <asp:RadioButton ID="radMicrosoftProject" runat="server" AutoPostBack="True"
                    GroupName="ExportType" Text="Microsoft Project" /></td>                    
    </tr>
    <tr>
        <td style="width: 150px" align="right">
            <asp:label ID="lblchkUpdate" runat="server" 
                Text="<%$ Resources:TimeLive.Resource, For Update: %>" Visible="False" /></td>
        <td style="width: 80px">
            <asp:CheckBox ID="chkUpdate" runat="server" Visible="False" />
        </td>                    
        <td style="width: 150px">
           
            </td>                    
        <td style="width: 425px">
           </td>                    
    </tr>
      <tr>
        <td style="width: 150px" align="right">
            <asp:Literal ID="Literal2" runat="server" Text="<%$ Resources:TimeLive.Resource, Data Source:%> " /></td>
        <td style="width: 425px" colspan="3">
            <asp:DropDownList ID="ddlDataSource" runat="server" Width="167px" AutoPostBack="True">
            </asp:DropDownList>
            <asp:DropDownList ID="DropDownList1" runat="server" AppendDataBoundItems="True" DataSourceID="dsProjectObject"
                DataTextField="ProjectName" DataValueField="AccountProjectId" Visible="False"
                Width="250px"></asp:DropDownList></td>
    </tr>
    <%  If Me.IsImport <> True And (Me.ddlDataSource.Text = "Expense Entry" And Me.radImport.Checked <> True) Or (Me.ddlDataSource.Text = "Time Entry" And Me.radImport.Checked <> True) Or (Me.ddlDataSource.Text = "Time Off Request" And Me.radImport.Checked <> True) Or (Me.ddlDataSource.Text = "Time Off" And Me.radImport.Checked <> True) Then%>  
    <tr>
        <td style="width: 150px;" align="right">
            <asp:Literal ID="Literal3" runat="server" Text="<%$ Resources:TimeLive.Resource, Start Date:%> " /></td>
      
        <td style="width: 425px;" colspan="3">
           <ew:CalendarPopup ID="StartTimeTextBox" runat="server" SkinId="DatePicker" 
                Width="55px">
                    </ew:CalendarPopup>
        </td>
    </tr>
    <tr>
        <td style="width: 150px;" align="right">
            <asp:Literal ID="Literal4" runat="server" Text="<%$ Resources:TimeLive.Resource, End Date:%> " /></td>
        
        <td style="width: 425px;" colspan="3">
           <ew:CalendarPopup ID="EndDateTextBox" runat="server" SkinId="DatePicker" 
                Width="55px" >
                    </ew:CalendarPopup>
        </td>
    </tr>
    <tr>
        <td style="width: 150px; " align="right">
            <asp:Literal ID="Literal5" runat="server" Text="<%$ Resources:TimeLive.Resource, Employee:%> " /></td>
        
        <td style="width: 425px; " colspan="3">
            <asp:DropDownList ID="ddlAccountEmployeeId" runat="server" Width="250px" DataSourceID="dsEmployeeObject" DataTextField="EmployeeNameWithCodeWithDisabled" DataValueField="AccountEmployeeId" AppendDataBoundItems="True">
                <asp:ListItem Value="-1">&lt;All&gt;</asp:ListItem>
            </asp:DropDownList></td>
    </tr>
    <% end if %>      <% If Me.IsImport <> True And (Me.ddlDataSource.Text = "Project Task" And Me.radImport.Checked <> True) Or (Me.ddlDataSource.Text = "Tasks Users" And Me.radImport.Checked <> True) Or (Me.ddlDataSource.Text = "Projects Team" And Me.radImport.Checked <> True) Or (Me.ddlDataSource.Text = "Projects Roles" And Me.radImport.Checked <> True) Or (Me.ddlDataSource.Text = "Time Entry" And Me.radImport.Checked <> True) Then%>
 <tr>
        <td align="right" style="width: 150px; ">
            <asp:Literal ID="Literal7" runat="server" Text="<%$ Resources:TimeLive.Resource, Project:%> " /></td>
        <td style="width: 425px; " colspan="3">
            <asp:DropDownList ID="ddlAccountProjectId" runat="server" Width="250px" DataSourceID="dsProjectObject" DataTextField="ProjectName" DataValueField="AccountProjectId" AppendDataBoundItems="True">
                <asp:ListItem Value="-1">&lt;All&gt;</asp:ListItem>
            </asp:DropDownList></td>
    </tr>
    <% End If%>      <%  If Me.IsImport <> True And (Me.ddlDataSource.Text = "Time Entry" And Me.radImport.Checked <> True) Then%>  
 <tr>
        <td align="right" style="width: 150px; ">
             <asp:Literal ID="Literal12" runat="server" Text="<%$ Resources:TimeLive.Resource, Location:%> " /> </td>
        <td style="width: 425px; " colspan="3">
            <asp:DropDownList ID="ddlAccountLocationId" runat="server" Width="250px" 
                DataSourceID="dsAccountLocationObject" DataTextField="AccountLocation" 
                DataValueField="AccountLocationId" AppendDataBoundItems="True">
                <asp:ListItem Value="-1">&lt;All&gt;</asp:ListItem>
            </asp:DropDownList></td>
    </tr>
    <% End If%>        <%  If Me.IsImport Or Me.radImport.Checked <> False Then%>
       <tr>
        <td style="width: 150px;" align="right">
            <asp:Literal ID="Literal6" runat="server" Text="<%$ Resources:TimeLive.Resource, Upload File%> " /></td>
        <td style="width: 425px;" colspan="3">
            <asp:FileUpload ID="txtFileUpload" runat="server" Width="100%" /></td>
    </tr>
    <%end if %>      <%  If Me.IsImport <> True And (Me.ddlDataSource.Text = "Time Entry" And Me.radImport.Checked <> True) Then%>  
    <tr>
        <td align="right" style="width: 150px">
            <asp:Literal ID="Literal10" runat="server" Text="<%$ Resources:TimeLive.Resource, Billing Type: %>" /></td>
        <td style="width: 425px" colspan="3">
            <asp:RadioButton ID="rdBoth" runat="server" GroupName="Billing" Text="<%$ Resources:TimeLive.Resource, Both%> " Checked="True" />
            &nbsp;
            <asp:RadioButton ID="rdBillable" runat="server" GroupName="Billing" Text="<%$ Resources:TimeLive.Resource, Billable%>" />
            &nbsp;
            <asp:RadioButton ID="rdNonBillable" runat="server" GroupName="Billing" Text="<%$ Resources:TimeLive.Resource, Non-Billable%>" /></td>
    </tr>
   
    <tr>
        <td align="right" style="width: 150px">
             <asp:Literal ID="Literal11" runat="server" Text="<%$ Resources:TimeLive.Resource, Approved Status: %>" /> </td>
        <td style="width: 425px" colspan="3">
            <asp:RadioButton ID="rdApprovedBoth" runat="server" GroupName="Approved" Text="<%$ Resources:TimeLive.Resource, Both%> " Checked="True" />
            &nbsp;
            <asp:RadioButton ID="rdApproved" runat="server" GroupName="Approved" Text="<%$ Resources:TimeLive.Resource, Approved%> "/>
            &nbsp;
            <asp:RadioButton ID="rdNotApproved" runat="server" GroupName="Approved" Text="<%$ Resources:TimeLive.Resource, Not Approved%> "/>
            </td>
    </tr>
    <% End If%>  
    <tr>
        <td style="width: 150px;" align="right">
        </td>
        <td style="width: 425px;" colspan="3">
            <asp:Button ID="cmdProceed" runat="server" 
                Text="<%$ Resources:TimeLive.Resource, Proceed_text%> " Width="68px" /></td>
    </tr>
    <tr>
        <td style="width: 150px" align="right">
        </td>
        <td style="width: 425px" colspan="3">
        </td>
    </tr>
</table>
</td></tr></table>

<asp:ObjectDataSource ID="dsEmployeeObject" runat="server" OldValuesParameterFormatString="original_{0}"
    SelectMethod="GetAccountEmployeesViewByAccountIdWithDisabled" TypeName="AccountEmployeeBLL">
    <SelectParameters>
        <asp:SessionParameter DefaultValue="22" Name="AccountId" SessionField="AccountId"
            Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>
<asp:ObjectDataSource ID="dsProjectObject" runat="server" OldValuesParameterFormatString="original_{0}"
    SelectMethod="GetAccountProjectsByAccountIdWithoutDeletedForIsDeleted" 
    TypeName="AccountProjectBLL" DeleteMethod="DeleteAccountProject" 
    InsertMethod="AddAccountProject" UpdateMethod="UpdateProjectDescription">
    <DeleteParameters>
        <asp:Parameter Name="Original_AccountProjectId" Type="Int32" />
    </DeleteParameters>
    <InsertParameters>
        <asp:Parameter Name="AccountId" Type="Int32" />
        <asp:Parameter Name="AccountProjectTypeId" Type="Int32" />
        <asp:Parameter Name="AccountClientId" Type="Int32" />
        <asp:Parameter Name="AccountPartyContactId" Type="Int32" />
        <asp:Parameter Name="AccountPartyDepartmentId" Type="Int32" />
        <asp:Parameter Name="ProjectBillingTypeId" Type="Int32" />
        <asp:Parameter Name="ProjectName" Type="String" />
        <asp:Parameter Name="ProjectDescription" Type="String" />
        <asp:Parameter Name="StartDate" Type="DateTime" />
        <asp:Parameter Name="Deadline" Type="DateTime" />
        <asp:Parameter Name="ProjectStatusId" Type="Int32" />
        <asp:Parameter Name="LeaderEmployeeId" Type="Int32" />
        <asp:Parameter Name="ProjectManagerEmployeeId" Type="Int32" />
        <asp:Parameter Name="TimeSheetApprovalTypeId" Type="Int32" />
        <asp:Parameter Name="ExpenseApprovalTypeId" Type="Int32" />
        <asp:Parameter Name="EstimatedDuration" Type="Double" />
        <asp:Parameter Name="EstimatedDurationUnit" Type="String" />
        <asp:Parameter Name="ProjectCode" Type="String" />
        <asp:Parameter Name="DefaultBillingRate" Type="Decimal" />
        <asp:Parameter Name="ProjectBillingRateTypeId" Type="Int32" />
        <asp:Parameter Name="IsTemplate" Type="Boolean" />
        <asp:Parameter Name="IsProject" Type="Boolean" />
        <asp:Parameter Name="AccountProjectTemplateId" Type="Int32" />
        <asp:Parameter Name="CreatedOn" Type="DateTime" />
        <asp:Parameter Name="CreatedByEmployeeId" Type="Int32" />
        <asp:Parameter Name="ModifiedOn" Type="DateTime" />
        <asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" />
        <asp:Parameter Name="Completed" Type="Boolean" />
        <asp:Parameter Name="CustomField1" Type="String" />
        <asp:Parameter Name="CustomField2" Type="String" />
        <asp:Parameter Name="CustomField3" Type="String" />
        <asp:Parameter Name="CustomField4" Type="String" />
        <asp:Parameter Name="CustomField5" Type="String" />
        <asp:Parameter Name="CustomField6" Type="String" />
        <asp:Parameter Name="CustomField7" Type="String" />
        <asp:Parameter Name="CustomField8" Type="String" />
        <asp:Parameter Name="CustomField9" Type="String" />
        <asp:Parameter Name="CustomField10" Type="String" />
        <asp:Parameter Name="CustomField11" Type="String" />
        <asp:Parameter Name="CustomField12" Type="String" />
        <asp:Parameter Name="CustomField13" Type="String" />
        <asp:Parameter Name="CustomField14" Type="String" />
        <asp:Parameter Name="CustomField15" Type="String" />
    </InsertParameters>
    <SelectParameters>
        <asp:SessionParameter DefaultValue="151" Name="AccountId" SessionField="AccountId"
            Type="Int32" />
    </SelectParameters>
    <UpdateParameters>
        <asp:Parameter Name="ProjectDescription" Type="String" />
        <asp:Parameter Name="Original_AccountProjectId" Type="Int32" />
    </UpdateParameters>
</asp:ObjectDataSource>
<asp:ObjectDataSource ID="dsAccountLocationObject" runat="server" 
    OldValuesParameterFormatString="original_{0}" 
    SelectMethod="GetAccountLocationsByAccountId" TypeName="AccountLocationBLL">
    <SelectParameters>
        <asp:SessionParameter Name="AccountId" SessionField="AccountId" Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>
<br />
<asp:Label ID="lblException" Text="" runat="server" CssClass="ErrorMessage" Font-Bold="True"
    Font-Names="Tahoma" Font-Size="Medium"></asp:Label><asp:Label
        ID="lblRowsInserted" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="Medium"
        ForeColor="Blue"></asp:Label><br />

<asp:GridView ID="GridView1" runat="server"  AutoGenerateColumns=False cssclass="xGridView" Caption="Column Mapping" Width="98%">
    <Columns>
        <asp:BoundField HeaderText="TimeLive Column" />
        <asp:BoundField DataField="DBColumnName" HeaderText="TimeLive Column" />
        <asp:TemplateField HeaderText="FileColumnName">
            <EditItemTemplate>
                &nbsp;
            </EditItemTemplate>
            <ItemTemplate>
                &nbsp;<asp:DropDownList ID="ddlFileColumnName" runat="server" Width="98%" AppendDataBoundItems="True">
                    <asp:ListItem>Select</asp:ListItem>
                </asp:DropDownList>
                        </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField DataField="Required" HeaderText="Required" />
    </Columns>
</asp:GridView>
<br />
<asp:Button ID="cmdImport" runat="server" Text="Start" Visible="False" Width="68px" />


