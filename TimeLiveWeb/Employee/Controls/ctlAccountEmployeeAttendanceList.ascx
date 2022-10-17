<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlAccountEmployeeAttendanceList.ascx.vb" Inherits="Employee_Controls_ctlAccountEmployeeAttendanceList" %>
<%@ Register Assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2"
    Namespace="eWorld.UI" TagPrefix="ew" %>
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc2" %>
<%@ Register Assembly="eWorld.UI"
    Namespace="eWorld.UI" TagPrefix="ew" %>

<asp:UpdatePanel ID="UP" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
<x:GridView ID="GV" runat="server" AutoGenerateColumns="False" Caption="<%$ Resources:TimeLive.Resource, Employee Attendance List %>"
    DataKeyNames="AccountEmployeeAttendanceId" DataSourceID="dsAccountEmployeeAttendanceObject"
    SkinID="xgridviewSkinEmployee" AllowSorting="True" Width="296px" Visible="False">
    <Columns>
        <asp:BoundField DataField="AccountEmployeeAttendanceId" 
            HeaderText="<%$ Resources:TimeLive.Resource, Id %>" InsertVisible="False"
            ReadOnly="True" />
        <asp:BoundField DataField="InOut" 
            HeaderText="<%$ Resources:TimeLive.Resource, In/Out %>" />
        <asp:BoundField DataField="AttendanceTime" 
            HeaderText="<%$ Resources:TimeLive.Resource, Time %>" DataFormatString="{0:t}" 
            HtmlEncode="False">
            <ItemStyle HorizontalAlign="Center" />
            <HeaderStyle HorizontalAlign="Center" />
        </asp:BoundField>
        <asp:BoundField DataField="AbsenceDescription" 
            HeaderText="<%$ Resources:TimeLive.Resource, Absent %>" >
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle HorizontalAlign="Left" />
        </asp:BoundField>
        <asp:TemplateField ShowHeader="False">
            <itemstyle horizontalalign="Center" width="25px" />
            <headerstyle horizontalalign="Center" />
            <itemtemplate>
<asp:LinkButton id="LinkButton2" runat="server" CausesValidation="False" __designer:wfdid="w16" CommandName="Select" Text="Edit"></asp:LinkButton> 
</itemtemplate>
        </asp:TemplateField>
        <asp:TemplateField ShowHeader="False">
            <ItemStyle HorizontalAlign="Center" Width="38px" />
            <HeaderStyle HorizontalAlign="Center" />
     <ItemTemplate>
<asp:LinkButton id="LinkButton1" runat="server" CausesValidation="False" __designer:wfdid="w17" CommandName="Delete" Text="Delete" OnClientClick="<%# ResourceHelper.GetDeleteMessageJavascript() %>"></asp:LinkButton> 
</ItemTemplate>
        </asp:TemplateField>
    </Columns>
</x:GridView>
<br /><div style="margin:0 5px;">
        <asp:Button ID="btnAdd" runat="server" CssClass="Insert" Text="Add" 
            Width="71px" />
            </div>
<asp:ObjectDataSource ID="dsAccountEmployeeAttendanceObject" runat="server" DeleteMethod="DeleteAccountEmployeeAttendance"
    InsertMethod="AddAccountEmployeeAttendance" OldValuesParameterFormatString="original_{0}"
    SelectMethod="GetvueEmployeeAttendanceByAttendanceDate" TypeName="AccountEmployeeAttendanceBLL"
    UpdateMethod="UpdateAccountEmployeeAttendance">
    <DeleteParameters>
        <asp:Parameter Name="Original_AccountEmployeeAttendanceId" Type="Int32" />
    </DeleteParameters>
    <UpdateParameters>
        <asp:Parameter Name="AccountId" Type="Int32" />
        <asp:Parameter Name="AccountEmployeeId" Type="Int32" />
        <asp:Parameter Name="AttendanceDate" Type="DateTime" />
        <asp:Parameter Name="AttendanceTime" Type="DateTime" />
        <asp:Parameter Name="InOut" Type="String" />
        <asp:Parameter Name="AccountAbsenceTypeId" Type="Int32" />
        <asp:Parameter Name="ModifiedOn" Type="DateTime" />
        <asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" />
        <asp:Parameter Name="Original_AccountEmployeeAttendanceId" Type="Int32" />
    </UpdateParameters>
    <SelectParameters>
        <asp:SessionParameter DefaultValue="64" Name="AccountId" SessionField="AccountId"
            Type="Int32" />
        <asp:Parameter Name="AccountEmployeeId" Type="Int32" />
        <asp:Parameter DefaultValue="01/01/9999" Name="AttendanceDate" Type="DateTime" />
    </SelectParameters>
    <InsertParameters>
        <asp:Parameter Name="AccountId" Type="Int32" />
        <asp:Parameter Name="AccountEmployeeId" Type="Int32" />
        <asp:Parameter Name="AttendanceDate" Type="DateTime" />
        <asp:Parameter Name="AttendanceTime" Type="DateTime" />
        <asp:Parameter Name="InOut" Type="String" />
        <asp:Parameter Name="AccountAbsenceTypeId" Type="Int32" />
        <asp:Parameter Name="CreatedOn" Type="DateTime" />
        <asp:Parameter Name="CreatedByEmployeeId" Type="Int32" />
        <asp:Parameter Name="ModifiedOn" Type="DateTime" />
        <asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" />
    </InsertParameters>
</asp:ObjectDataSource>
<asp:ObjectDataSource ID="dsAccountEmployeeAttendanceFormObject" runat="server" DeleteMethod="DeleteAccountEmployeeAttendance"
    InsertMethod="AddAccountEmployeeAttendance" OldValuesParameterFormatString="original_{0}"
    SelectMethod="GetAccountEmployeeAttendancesByAccountEmployeeAttendanceId" TypeName="AccountEmployeeAttendanceBLL"
    UpdateMethod="UpdateAccountEmployeeAttendance" >
    <DeleteParameters>
        <asp:Parameter Name="Original_AccountEmployeeAttendanceId" Type="Int32" />
    </DeleteParameters>
    <UpdateParameters>
        <asp:SessionParameter DefaultValue="64" Name="AccountId" SessionField="AcccountId"
            Type="Int32" />
        <asp:Parameter Name="AccountEmployeeId" Type="Int32" />
        <asp:Parameter Name="AttendanceDate" Type="DateTime" />
        <asp:Parameter Name="AttendanceTime" Type="DateTime" />
        <asp:Parameter Name="InOut" Type="String" />
        <asp:Parameter Name="AccountAbsenceTypeId" Type="Int32" />
        <asp:Parameter Name="ModifiedOn" Type="DateTime" />
        <asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" />
        <asp:Parameter Name="Original_AccountEmployeeAttendanceId" Type="Int32" />
    </UpdateParameters>
    <SelectParameters>
        <asp:ControlParameter ControlID="GV" Name="AccountEmployeeAttendanceId" PropertyName="SelectedValue"
            Type="Int32" />
    </SelectParameters>
    <InsertParameters>
        <asp:SessionParameter DefaultValue="64" Name="AccountId" SessionField="AccountId"
            Type="Int32" />
        <asp:Parameter Name="AccountEmployeeId" Type="Int32" />
        <asp:Parameter Name="AttendanceDate" Type="DateTime" />
        <asp:Parameter Name="AttendanceTime" Type="DateTime" />
        <asp:Parameter Name="InOut" Type="String" />
        <asp:Parameter Name="AccountAbsenceTypeId" Type="Int32" />
        <asp:Parameter Name="CreatedOn" Type="DateTime" />
        <asp:Parameter Name="CreatedByEmployeeId" Type="Int32" />
        <asp:Parameter Name="ModifiedOn" Type="DateTime" />
        <asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" />
    </InsertParameters>
</asp:ObjectDataSource>
        <asp:FormView ID="FormView1" runat="server" DataKeyNames="AccountEmployeeAttendanceId"
    DataSourceID="dsAccountEmployeeAttendanceFormObject" DefaultMode="Insert" 
            SkinID="formviewSkinEmployee" Width="350px" Visible="False">
    <EditItemTemplate><table width="100%" class="xview">
        <tr>
            <th class="caption" colspan="2" style="height: 21px">
                <asp:Literal ID="Literal1" runat="server" Text="<%$ Resources:TimeLive.Resource, Employee Attendance Information%> " /></th>
        </tr>
        <tr>
            <th class="FormViewSubHeader" colspan="2" style="height: 21px">
                <asp:Literal ID="Literal2" runat="server" Text="<%$ Resources:TimeLive.Resource, Employee Attendance%> " /></th>
        </tr>
        <tr>
            <td style="width: 30%; height: 26px;" align="right" class="FormViewLabelCell">
                <SPAN 
                  class=reqasterisk>*</span> <asp:Literal ID="Literal3" runat="server" Text="<%$ Resources:TimeLive.Resource, In/Out:%> " /></td>
            <td style="width: 70%; height: 26px;">
                <asp:DropDownList ID="DropDownList1" runat="server" 
                    SelectedValue='<%# Bind("InOut") %>' Width="60%">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>In</asp:ListItem>
                    <asp:ListItem>Out</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td align="right" class="FormViewLabelCell" style="width: 30%; height: 26px">
                <SPAN 
                  class=reqasterisk>*</span> <asp:Literal ID="Literal4" runat="server" Text="<%$ Resources:TimeLive.Resource, Time:%> " /></td>
            <td style="width: 70%; height: 26px">
                <asp:TextBox ID="AttendanceTime" runat="server"
                    ValidationGroup="EmployeeAttendance" Width="53px"></asp:TextBox><cc2:MaskedEditExtender ID="MaskedEditExtenderAttendanceTime"
                            runat="server" AcceptAMPM="true" Mask="99:99 " MaskType="Time" TargetControlID="AttendanceTime">
                    </cc2:MaskedEditExtender>
                <cc2:MaskedEditValidator ID="MaskedEditValidatorStartTime" runat="server" ControlExtender="MaskedEditExtenderAttendanceTime"
                    ControlToValidate="AttendanceTime" Display="Dynamic" EmptyValueMessage="*" ErrorMessage="MaskedEditValidatorAttendanceTime"
                    InvalidValueMessage="Invalid Time" IsValidEmpty="true" CssClass="ErrorMessage" ValidationGroup="EmployeeAttendance"></cc2:MaskedEditValidator>
            </td>
        </tr>
        <tr>
            <td align="right" class="FormViewLabelCell" style="width: 30%; height: 26px">
                <SPAN 
                  class=reqasterisk>*</span> <asp:Literal ID="Literal5" runat="server" Text="<%$ Resources:TimeLive.Resource, Absence:%> " /></td>
            <td style="width: 70%; height: 26px">
                <asp:DropDownList ID="ddlAccountAbsenceTypeId" runat="server" DataSourceID="dsAccountAbsenceTypeObject"
                        DataTextField="AbsenceDescription" 
                    DataValueField="AccountAbsenceTypeId" AppendDataBoundItems="True" Width="60%">
                    <asp:ListItem Selected="True" Value="0">Present</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td style="width: 30%; height: 26px;" align="right">
            </td>
            <td style="width: 70%; height: 26px; padding-bottom: 5px;">
                <asp:Button ID="Update" runat="server" CommandName="Update" Text="<%$ Resources:TimeLive.Resource, Update_text%> " Width="50px" />
                <asp:Button ID="Cancel" runat="server" CommandName="Cancel" Text="<%$ Resources:TimeLive.Resource, Cancel_text%> " Width="50px" /></td>
        </tr>
    </table>
    </EditItemTemplate>
    <InsertItemTemplate>
        <table width="100%" class="xview">
            <tr>
                <th class="caption" colspan="2" style="height: 21px">
                   <asp:Literal ID="Literal5" runat="server" Text="<%$ Resources:TimeLive.Resource, Employee Attendance Information%> " /></th>
            </tr>
            <tr>
                <th class="FormViewSubHeader" colspan="2" style="height: 21px">
                    <asp:Literal ID="Literal6" runat="server" Text="<%$ Resources:TimeLive.Resource, Employee Attendance%> " /></th>
            </tr>
            <tr>
                <td style="width: 30%; height: 26px;" align="right" class="FormViewLabelCell">
                    <SPAN 
                  class=reqasterisk>*</span> <asp:Literal ID="Literal7" runat="server" Text="<%$ Resources:TimeLive.Resource, In/Out:%> " /></td>
                <td style="width: 70%; height: 26px;">
                    <asp:DropDownList ID="DropDownList1" runat="server" 
                        SelectedValue='<%# Bind("InOut") %>' Width="60%">
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem>In</asp:ListItem>
                        <asp:ListItem>Out</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td align="right" class="FormViewLabelCell" style="width: 30%; height: 26px">
                    <SPAN 
                  class=reqasterisk>*</span> <asp:Literal ID="Literal8" runat="server" Text="<%$ Resources:TimeLive.Resource, Time:%> " /></td>
                <td style="width: 70%; height: 26px">
                    <asp:TextBox ID="AttendanceTime" runat="server" 
                        Text='<%# Bind("AttendanceTime") %>'
                        ValidationGroup="EmployeeAttendance" Width="53px"></asp:TextBox><cc2:MaskedEditExtender ID="MaskedEditExtenderAttendanceTime"
                            runat="server" AcceptAMPM="true" Mask="99:99 " MaskType="Time" TargetControlID="AttendanceTime" AutoCompleteValue="00:00">
                        </cc2:MaskedEditExtender>
                    <cc2:MaskedEditValidator ID="MaskedEditValidatorAttendanceTime" runat="server"
                        ControlExtender="MaskedEditExtenderAttendanceTime" ControlToValidate="AttendanceTime"
                        Display="Dynamic" EmptyValueMessage="*" ErrorMessage="MaskedEditValidatorAttendanceTime"
                        InvalidValueMessage="Invalid Time" IsValidEmpty="true" ValidationGroup="EmployeeAttendance" CssClass="ErrorMessage"></cc2:MaskedEditValidator></td>
            </tr>
            <tr>
                <td align="right" class="FormViewLabelCell" style="width: 30%; height: 26px">
                    <SPAN 
                  class=reqasterisk>*</span> <asp:Literal ID="Literal9" runat="server" Text="<%$ Resources:TimeLive.Resource, Absence:%> " /></td>
                <td style="width: 70%; height: 26px">
                    <asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="dsAccountAbsenceTypeObjectInsert"
                        DataTextField="AbsenceDescription" DataValueField="AccountAbsenceTypeId" 
                        SelectedValue='<%# Bind("AccountAbsenceTypeId") %>' AppendDataBoundItems="True" 
                        Width="60%">
                        <asp:ListItem Selected="True" Value="0">Present</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 30%; height: 26px;" align="right">
                </td>
                <td style="width: 70%; height: 26px; padding-bottom: 5px;">
                    <asp:Button ID="Button1" runat="server" CommandName="Insert" 
                        Text="<%$ Resources:TimeLive.Resource, Add_text%> " Width="50px" />
                    <asp:Button ID="Cancel" runat="server" CommandName="Cancel" 
                        onclick="Cancel_Click" Text="<%$ Resources:TimeLive.Resource, Cancel_text%> " 
                        Width="50px" />
                </td>
            </tr>
        </table>
    </InsertItemTemplate>
    <ItemTemplate>
        AccountEmployeeAttendanceId:
        <asp:Label ID="AccountEmployeeAttendanceIdLabel" runat="server" Text='<%# Eval("AccountEmployeeAttendanceId") %>'>
        </asp:Label><br />
        AccountId:
        <asp:Label ID="AccountIdLabel" runat="server" Text='<%# Bind("AccountId") %>'></asp:Label><br />
        AccountEmployeeId:
        <asp:Label ID="AccountEmployeeIdLabel" runat="server" Text='<%# Bind("AccountEmployeeId") %>'>
        </asp:Label><br />
        AttendanceDate:
        <asp:Label ID="AttendanceDateLabel" runat="server" Text='<%# Bind("AttendanceDate") %>'>
        </asp:Label><br />
        AttendanceTime:
        <asp:Label ID="AttendanceTimeLabel" runat="server" Text='<%# Bind("AttendanceTime") %>'>
        </asp:Label><br />
        InOut:
        <asp:Label ID="InOutLabel" runat="server" Text='<%# Bind("InOut") %>'></asp:Label><br />
        CreatedByEmployeeId:
        <asp:Label ID="CreatedByEmployeeIdLabel" runat="server" Text='<%# Bind("CreatedByEmployeeId") %>'>
        </asp:Label><br />
        CreatedOn:
        <asp:Label ID="CreatedOnLabel" runat="server" Text='<%# Bind("CreatedOn") %>'></asp:Label><br />
        ModifiedByEmployeeId:
        <asp:Label ID="ModifiedByEmployeeIdLabel" runat="server" Text='<%# Bind("ModifiedByEmployeeId") %>'>
        </asp:Label><br />
        ModifiedOn:
        <asp:Label ID="ModifiedOnLabel" runat="server" Text='<%# Bind("ModifiedOn") %>'>
        </asp:Label><br />
        <asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" CommandName="Edit"
            Text="Edit">
        </asp:LinkButton>
        <asp:LinkButton ID="DeleteButton" runat="server" CausesValidation="False" CommandName="Delete"
            Text="Delete">
        </asp:LinkButton>
        <asp:LinkButton ID="NewButton" runat="server" CausesValidation="False" CommandName="New"
            Text="New">
        </asp:LinkButton>
    </ItemTemplate>
</asp:FormView>

&nbsp;<br />
        <asp:ObjectDataSource ID="dsAccountAbsenceTypeObject" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetAccountAbsenceTypesByAccountIdAndIsDisabled" TypeName="AccountAbsenceTypeBLL">
            <SelectParameters>
                <asp:SessionParameter DefaultValue="64" Name="AccountId" SessionField="AccountId"
                    Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource><asp:ObjectDataSource ID="dsAccountAbsenceTypeObjectInsert" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetAccountAbsenceTypesByAccountIdAndIsDisabled" TypeName="AccountAbsenceTypeBLL">
            <SelectParameters>
                <asp:SessionParameter DefaultValue="64" Name="AccountId" SessionField="AccountId"
                    Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>   
         </ContentTemplate>
</asp:UpdatePanel>

