<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlTimeOffRequest.ascx.vb"
    Inherits="Employee_Controls_ctlTimeOffRequest" %>
<%@ Register Assembly="eWorld.UI.Compatibility" Namespace="eWorld.UI.Compatibility"
    TagPrefix="cc2" %>
<%@ Register Assembly="eWorld.UI.Compatibility, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2"
    Namespace="eWorld.UI.Compatibility" TagPrefix="cc1" %>
<style type="text/css">
    .style1 {
        height: 23px;
    }
</style>


<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <asp:FormView ID="FormView1" runat="server" DataKeyNames="AccountEmployeeTimeOffRequestId"
            DataSourceID="dsEmployeeTimeOffRequestFormViewObject" DefaultMode="Insert" Width="600px"
            SkinID="formviewSkinEmployee">
            <InsertItemTemplate>
                <table width="100%" class="xformview">
                    <tr>
                        <th colspan="2" class="caption">
                            <asp:Literal ID="Literal1" runat="server" Text='<%# ResourceHelper.GetFromResource("Time Off Request Information") %>' />
                        </th>
                    </tr>
                    <tr>
                        <th colspan="2" class="FormViewSubHeader">
                            <asp:Literal ID="Literal2" runat="server" Text='<%# ResourceHelper.GetFromResource("Time Off Request") %>' />
                        </th>
                    </tr>
                    <asp:Panel  Id="DivRequest" runat="server">
                        <tr>
                            <td align="left" class="style1" colspan="2">&nbsp;&nbsp; Time Off Available:
                           
                                <asp:Label ID="lblAvailableTimeOff" runat="server" Font-Bold="True" Text="Label"></asp:Label>
                            </td>
                        </tr>

                        <tr>
                            <td align="right" class="FormViewLabelCell" style="width: 30%">
                                <asp:Literal ID="Literal3" runat="server" Text='<%# ResourceHelper.GetFromResource("Time Off Type:") %>' />
                            </td>
                            <td style="width: 70%">
                                <asp:DropDownList ID="ddlTimeOffTypeId" runat="server" AutoPostBack="True" DataSourceID="dsTimeOffTypesObject"
                                    DataTextField="AccountTimeOffType" DataValueField="AccountTimeOffTypeId" OnSelectedIndexChanged="ddlTimeOffTypeId_SelectedIndexChanged"
                                    SelectedValue='<%# Bind("AccountTimeOffTypeId") %>' Width="212px" CssClass="TimeOffTypeDropDown">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlTimeOffTypeId"
                                    CssClass="ErrorMessage" Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 30%" align="right" class="FormViewLabelCell">
                                <asp:Literal ID="Literal4" runat="server" Text='<%# ResourceHelper.GetFromResource("Begin Date:") %>' />
                            </td>
                            <td style="width: 70%">
                                <cc1:CalendarPopup ID="StartDateTextBox" runat="server" SelectedDate='<%# Bind("StartDate") %>'
                                    AutoPostBack="True" OnDateChanged="StartDateTextBox_DateChanged" CssClass="StartDateTextBox"
                                    Width="55px">
                                </cc1:CalendarPopup>
                            </td>
                            <tr>
                                <td align="right" class="FormViewLabelCell" style="width: 30%">
                                    <asp:Literal ID="Literal5" runat="server" Text='<%# ResourceHelper.GetFromResource("End Date:") %>' />
                                </td>
                                <td style="width: 70%">
                                    <cc1:CalendarPopup ID="EndDateTextBox" runat="server" AutoPostBack="True" OnDateChanged="EndDateTextBox_DateChanged"
                                        SelectedDate='<%# Bind("EndDate") %>' CssClass="EndDateTextBox" Width="55px">
                                    </cc1:CalendarPopup>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="FormViewLabelCell" style="width: 30%">
                                    <asp:Label ID="Label2" runat="server" AssociatedControlID="DaysOffTextBox">
                                        <asp:Literal ID="Literal6" runat="server" Text='<%# ResourceHelper.GetFromResource("Days Off:") %>' /></asp:Label>
                                </td>
                                <td style="width: 70%">
                                    <asp:TextBox ID="DaysOffTextBox" runat="server" AutoPostBack="True" OnTextChanged="DaysOffTextBox_TextChanged"
                                        Style="text-align: right;" Text='<%# Bind("DayOff") %>' Width="55px"></asp:TextBox><asp:RequiredFieldValidator
                                            ID="RequiredFieldValidator2" runat="server" ControlToValidate="DaysOffTextBox"
                                            CssClass="ErrorMessage" Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator><asp:RangeValidator
                                                ID="RangeValidator1" runat="server" ControlToValidate="DaysOffTextBox" CssClass="ErrorMessage"
                                                Display="Dynamic" ErrorMessage="Invalid value" MaximumValue="99999999" MinimumValue="0"
                                                Type="Double"></asp:RangeValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="FormViewLabelCell" style="width: 30%">
                                    <asp:Label ID="Label4" runat="server" AssociatedControlID="HoursOffTextBox">
                                        <asp:Literal ID="Literal7" runat="server" Text='<%# ResourceHelper.GetFromResource("Hours Off:") %>' /></asp:Label>
                                </td>
                                <td style="width: 70%">
                                    <asp:TextBox ID="HoursOffTextBox" runat="server" AutoPostBack="True" OnTextChanged="HoursOffTextBox_TextChanged"
                                        Style="text-align: right;" Text='<%# Bind("HoursOff") %>' Width="55px">
                                </asp:TextBox>
                                    <asp:RequiredFieldValidator
                                        ID="RequiredFieldValidator3" runat="server" ControlToValidate="HoursOffTextBox"
                                        CssClass="ErrorMessage" Display="Dynamic" ErrorMessage="*">
                                    </asp:RequiredFieldValidator>
                                    <asp:RangeValidator
                                        ID="RangeValidator2" runat="server" ControlToValidate="HoursOffTextBox" CssClass="ErrorMessage"
                                        Display="Dynamic" ErrorMessage="This request must include at least one working day."
                                        MaximumValue="99999999" MinimumValue="0.1">
                                </asp:RangeValidator>
                                    <asp:RangeValidator
                                        ID="RangeValidator4" runat="server" ControlToValidate="HoursOffTextBox" CssClass="ErrorMessage"
                                        Display="Dynamic" ErrorMessage="Invalid value" MaximumValue="99999999" MinimumValue="0"
                                        Type="Double">
                                </asp:RangeValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="FormViewLabelCell" style="width: 30%">Project Name:</td>
                                <td style="width: 70%">
                                    <asp:DropDownList ID="ddlProjectName" runat="server" AppendDataBoundItems="True" autoPostBack="True"
                                        DataSourceID="dsAccountProjectObject" DataTextField="ProjectName" DataValueField="AccountProjectId"
                                        SelectedValue='<%# Bind("AccountProjectId") %>' Width="212px" OnSelectedIndexChanged="ddlProjectName_SelectedIndexChanged">
                                         
                                    </asp:DropDownList>
                                    
                                </td>
                            </tr>
                            
                            <tr>
                                <td align="right" class="FormViewLabelCell" style="width: 30%;" valign="top">
                                    <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="DescriptionTextBox">
                                        <asp:Literal ID="Literal8" runat="server" Text='<%# ResourceHelper.GetFromResource("Description:") %>' /></asp:Label>
                                </td>
                                <td style="width: 70%; padding-bottom: 5px;">
                                    <asp:TextBox ID="DescriptionTextBox" runat="server" Height="70px" MaxLength="1000"
                                        Rows="5" Text='<%# Bind("Description") %>' TextMode="MultiLine" Width="200px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="Center" colspan="2">
                                    <asp:Label ID="lblErrorMessage" runat="server" Font-Bold="true" Text=" "></asp:Label>
                                </td>
                            </tr>

                            <tr>
                                <asp:HiddenField ID="ActionType" runat="server" Value="Insert"></asp:HiddenField>
                            </tr>
                            <tr>
                                <asp:HiddenField ID="AccountEmployeeTimeOffRequestId" runat="server" Value="none" />
                            </tr>

                            <tr>
                                <td align="right" class="FormViewLabelCell" style="width: 30%"></td>
                                <td style="width: 70%; padding-bottom: 5px;">
                                    <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" OnClientClick="disableButton()" UseSubmitBehavior="false"
                                        Text="<%$ Resources:TimeLive.Resource, Save_text%> " Width="68px" />&nbsp;
                               
                                    <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="<%$ Resources:TimeLive.Resource, Cancel_text%> "
                                        ValidationGroup="1" Width="68px" data-dismiss="modal" OnClientClick="return false;" /><br />
                                </td>
                            </tr>
                        </tr>
                    </asp:Panel>
                    <asp:Panel  Id="SaveIsOk" runat="server" Visible="false"  >
                        <tr>
                            <td align="center" style="width: 70%; padding-bottom: 5px; padding-top:10px;" >
                               
                                <div style="display:table; margin-left:auto ; margin-right:auto"  >
                                    
                                    <div style="display: table-row; " >
                                        <div style="display: table-cell; vertical-align: middle;" >
                                             <asp:Literal runat="server"  ID="Literal16" Text ="<%$ Resources:TimeLive.Resource, Save_Succeffuly%> "></asp:Literal>
                                        </div>
                                    </div>
                                   <div style="display: table-row; " >
                                        <div style="display: table-cell; vertical-align: middle;" >
                                             <asp:Button ID="btnOk" runat="server" OnClick="Ok_Click" OnClientClick="closeModalWindow();"
                                                    Text="Ok" Width="68px" />
                                        </div>
                                    </div>
                                </div>
                            </td>
                        </tr>
                    </asp:Panel>

                    <asp:Panel ID="SaveIsNotOk" runat="server" Visible="false">
                         <tr>
                            <td align="center" style="width: 70%; padding-bottom: 5px; padding-top:10px;">
                                
                                <div style="display:table; margin-left:auto ; margin-right:auto"  >
                                    
                                    <div style="display: table-row; " >
                                        <div style="display: table-cell; vertical-align: middle ;  " >
                                            <asp:Literal runat="server"  ID="Literal18" Text ="<%$ Resources:TimeLive.Resource, Save_Not_Succeffuly%> "></asp:Literal>
                                        </div>
                                    </div>  
                                    <div style="display: table-row; " >
                                        <div style="display: table-row; " >
                                            <div style="display: table-cell; vertical-align: middle ;  " >
                                                <asp:Button ID="btnBack" runat="server" OnClick="Back_Click" OnClientClick="openModelWindow()" 
                                                    Text="<%$ Resources:TimeLive.Resource, Back_text%> " Width="68px" />&nbsp;
                                            </div>
                                            <div style="display: table-cell; vertical-align: middle ;  " >
                                                 <asp:Button ID="Button2" runat="server" OnClick="Back_Click" Text="<%$ Resources:TimeLive.Resource, Cancel_text%> "
                                                        ValidationGroup="1" Width="68px"  OnClientClick="closeModalWindow();" /><br />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </td>
                            
                        </tr>
                    
                     
                    </asp:Panel>
                </table>
            </InsertItemTemplate>
            <EditItemTemplate>
                <table width="100%" class="xformview">
                    <tr>
                        <th colspan="2" class="caption">
                            <asp:Literal ID="Literal1" runat="server" Text='<%# ResourceHelper.GetFromResource("Time Off Request Information") %>' />
                        </th>
                    </tr>
                    <tr>
                        <th colspan="2" class="FormViewSubHeader">
                            <asp:Literal ID="Literal9" runat="server" Text='<%# ResourceHelper.GetFromResource("Time Off Request") %>' />
                        </th>
                    </tr>
                    <tr>
                        <td class="FormViewSubHeader" colspan="2">&nbsp;&nbsp; Time Off Available:
                           
                            <asp:Label ID="lblAvailableTimeOff" runat="server" Font-Bold="True" Text="Label"
                                Width="70px"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 30%" align="right" class="FormViewLabelCell">
                            <asp:Literal ID="Literal10" runat="server" Text='<%# ResourceHelper.GetFromResource("Time Off Type:") %>' />
                        </td>
                        <td style="width: 70%">
                            <asp:DropDownList ID="ddlTimeOffTypeId" runat="server" Width="212px" DataSourceID="dsTimeOffTypesObject"
                                DataTextField="AccountTimeOffType" DataValueField="AccountTimeOffTypeId">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlTimeOffTypeId"
                                CssClass="ErrorMessage" Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="FormViewLabelCell" style="width: 30%">
                            <asp:Literal ID="Literal11" runat="server" Text='<%# ResourceHelper.GetFromResource("Begin Date:") %>' />
                        </td>
                        <td style="width: 70%">
                            <cc1:CalendarPopup ID="StartDateTextBox" runat="server" AutoPostBack="True" OnDateChanged="StartDateTextBox_DateChanged"
                                SelectedDate='<%# Bind("StartDate") %>' Width="55px">
                            </cc1:CalendarPopup>
                        </td>
                        <tr>
                            <td style="width: 30%" align="right" class="FormViewLabelCell">
                                <asp:Literal ID="Literal12" runat="server" Text='<%# ResourceHelper.GetFromResource("End Date:") %>' />
                            </td>
                            <td style="width: 70%">
                                <cc1:CalendarPopup ID="EndDateTextBox" runat="server" SelectedDate='<%# Bind("EndDate") %>'
                                    AutoPostBack="True" OnDateChanged="EndDateTextBox_DateChanged" Width="55px">
                                </cc1:CalendarPopup>
                            </td>
                        </tr>
                    <tr>
                        <td style="width: 30%" align="right" class="FormViewLabelCell">
                            <asp:Label ID="Label1" runat="server" AssociatedControlID="DaysOffTextBox">
                                <asp:Literal ID="Literal13" runat="server" Text='<%# ResourceHelper.GetFromResource("Days Off:") %>' /></asp:Label>
                        </td>
                        <td style="width: 70%">
                            <asp:TextBox ID="DaysOffTextBox" runat="server" Text='<%# Bind("DayOff") %>' Width="55px"
                                Style="text-align: right;" AutoPostBack="True" OnTextChanged="DaysOffTextBox_TextChanged1"></asp:TextBox><asp:RequiredFieldValidator
                                    ID="RequiredFieldValidator2" runat="server" ControlToValidate="DaysOffTextBox"
                                    CssClass="ErrorMessage" Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator><asp:RangeValidator
                                        ID="RangeValidator3" runat="server" ControlToValidate="DaysOffTextBox" CssClass="ErrorMessage"
                                        Display="Dynamic" ErrorMessage="Invalid value" MaximumValue="99999999" MinimumValue="0"
                                        Type="Double"></asp:RangeValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 30%" align="right" class="FormViewLabelCell">
                            <asp:Label ID="Label3" runat="server" AssociatedControlID="HoursOffTextBox">
                                <asp:Literal ID="Literal14" runat="server" Text='<%# ResourceHelper.GetFromResource("Hours Off:") %>' /></asp:Label>
                        </td>
                        <td style="width: 70%">
                            <asp:TextBox ID="HoursOffTextBox" runat="server" Text='<%# Bind("HoursOff") %>' Width="55px"
                                Style="text-align: right;" AutoPostBack="True" OnTextChanged="HoursOffTextBox_TextChanged1">
                                </asp:TextBox>
                            <asp:RequiredFieldValidator
                                ID="RequiredFieldValidator4" runat="server" ControlToValidate="HoursOffTextBox"
                                CssClass="ErrorMessage" Display="Dynamic" ErrorMessage="*">
                                </asp:RequiredFieldValidator>
                            <asp:RangeValidator
                                ID="RangeValidator2" runat="server" ControlToValidate="HoursOffTextBox" CssClass="ErrorMessage"
                                Display="Dynamic" ErrorMessage="This request must include at least one working day."
                                MaximumValue="99999999" MinimumValue='<%# Convert.ToDouble(0.1).ToString("N", LocaleUtilitiesBLL.GetCurrentCultureInfoWithThreadCulture) %>'
                                Type="Double">
                                </asp:RangeValidator>
                            <asp:RangeValidator ID="RangeValidator5" runat="server"
                                ControlToValidate="HoursOffTextBox" CssClass="ErrorMessage" Display="Dynamic"
                                ErrorMessage="Invalid value" MaximumValue="99999999" MinimumValue="0" Type="Double">
                                </asp:RangeValidator>
                        </td>
                    </tr>
                    <% If LocaleUtilitiesBLL.IsShowProjectForTimeOff Then%><tr>
                        <td align="right" class="FormViewLabelCell" style="width: 30%">Project Name:
                            </td>
                        <td style="width: 70%">
                            <asp:DropDownList ID="ddlProjectName" runat="server" Width="212px" DataSourceID="dsAccountProjectObject"
                                DataTextField="ProjectName" DataValueField="AccountProjectId" AppendDataBoundItems="True">
                                <asp:ListItem Selected="True" Value="0">&lt;None&gt;</asp:ListItem>
                            </asp:DropDownList>
                            &nbsp;
                               
                            <asp:Label ID="ProjectNameValid" runat="server" Text="Project Name Field is Required"
                                ForeColor="Red">
                                </asp:Label>
                        </td>
                    </tr>
                    <% End If%><tr>
                        <td style="width: 30%" align="right" class="FormViewLabelCell" valign="top">
                            <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="DescriptionTextBox">
                                <asp:Literal ID="Literal15" runat="server" Text='<%# ResourceHelper.GetFromResource("Description:") %>' /></asp:Label>
                        </td>
                        <td style="width: 70%">
                            <asp:TextBox ID="DescriptionTextBox" runat="server" MaxLength="1000" Rows="5" Text='<%# Bind("Description") %>'
                                TextMode="MultiLine" Width="200px" Height="70px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 30%" align="right" class="FormViewLabelCell"></td>
                        <td style="width: 70%; padding-bottom: 5px;">
                            <asp:Button ID="btnUpdate" runat="server" Text="<%$ Resources:TimeLive.Resource, Update_text%> "
                                CommandName="Update" Width="68px" />&nbsp;
                               
                            <asp:Button ID="btnCancel" runat="server"
                                Text="<%$ Resources:TimeLive.Resource, Cancel_text%> " OnClick="btnCancel_Click"
                                ValidationGroup="1" Width="68px" data-dismiss="modal" OnClientClick="return false;" />
                            <br />
                        </td>
                    </tr>
                </table>
            </EditItemTemplate>
        </asp:FormView>
        <asp:ObjectDataSource ID="dsEmployeeTimeOffRequestFormViewObject" runat="server"
            InsertMethod="AddAccountEmployeeTimeOffRequest" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetAccountEmployeeTimeOffRequestByEmployeeRequestId" TypeName="AccountEmployeeTimeOffRequestBLL"
            UpdateMethod="UpdateAccountEmployeeTimeOffRequest">
            <SelectParameters>
                <asp:Parameter Name="AccountEmployeeTimeOffRequestId" DbType="Guid" />
            </SelectParameters>
            <InsertParameters>
                <asp:SessionParameter Name="AccountId" SessionField="AccountId" Type="Int32" />
                <asp:SessionParameter Name="AccountEmployeeId" SessionField="AccountEmployeeId" Type="Int32" />
                <asp:Parameter Name="AccountTimeOffTypeId" DbType="Guid" />
                <asp:Parameter Name="HoursOff" Type="Double" />
                <asp:Parameter Name="StartDate" Type="DateTime" />
                <asp:Parameter Name="EndDate" Type="DateTime" />
                <asp:Parameter Name="Description" Type="String" />
                <asp:Parameter Name="DayOff" Type="Double" />
                <asp:Parameter Name="AccountProjectId" Type="Int32" />
                <asp:Parameter Name="Approved" Type="Boolean" />
                <asp:Parameter Name="AuditSource" Type="String" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="AccountTimeOffTypeId" DbType="Guid" />
                <asp:Parameter Name="HoursOff" Type="Double" />
                <asp:Parameter Name="StartDate" Type="DateTime" />
                <asp:Parameter Name="EndDate" Type="DateTime" />
                <asp:Parameter Name="Description" Type="String" />
                <asp:Parameter Name="DayOff" Type="Double" />
                <asp:Parameter Name="Original_AccountEmployeeTimeOffRequestId" DbType="Guid" />
                <asp:Parameter Name="AccountProjectId" Type="Int32" />
            </UpdateParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="dsTimeOffTypesObject" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetAccountTimeOffTypesByAccountIdAccountEmployeeIdAndRequestRequired"
            TypeName="AccountTimeOffTypeBLL" DataObjectTypeName="System.Guid" DeleteMethod="DeleteAccountTimeOffTypes"
            InsertMethod="AddAccountTimeOffTypes" UpdateMethod="UpdateAccountTimeOffTypes">
            <InsertParameters>
                <asp:Parameter Name="AccountId" Type="Int32" />
                <asp:Parameter Name="AccountTimeOffType" Type="String" />
                <asp:Parameter Name="IsTimeOffRequestRequired" Type="Boolean" />
                <asp:Parameter Name="CreatedByEmployeeId" Type="Int32" />
                <asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" />
            </InsertParameters>
            <SelectParameters>
                <asp:SessionParameter Name="AccountEmployeeId" SessionField="AccountEmployeeId" Type="Int32" />
                <asp:SessionParameter Name="AccountId" SessionField="AccountId" Type="Int32" />
                <asp:Parameter Name="IsTimeOffRequestRequired" DefaultValue="True" Type="Boolean" />
                <asp:Parameter DefaultValue="" Name="AccountTimeOffTypeId" DbType="Guid" />
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter Name="AccountTimeOffType" Type="String" />
                <asp:Parameter Name="IsTimeOffRequestRequired" Type="Boolean" />
                <asp:Parameter DbType="Guid" Name="Original_AccountTimeOffTypeId" />
                <asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" />
                <asp:Parameter Name="IsDisabled" Type="Boolean" />
            </UpdateParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="dsAccountProjectObject" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetTimeOffInternalProjects"
            TypeName="AccountProjectBLL" >
           
        </asp:ObjectDataSource>
    </ContentTemplate>
</asp:UpdatePanel>

