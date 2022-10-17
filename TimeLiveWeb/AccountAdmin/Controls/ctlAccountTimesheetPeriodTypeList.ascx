<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlAccountTimesheetPeriodTypeList.ascx.vb" Inherits="AccountAdmin_Controls_ctlAccountTimesheetPeriodTypeList" %>
<%@ Register Assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2"
    Namespace="eWorld.UI" TagPrefix="ew" %>
<%@ Register Assembly="eWorld.UI.Compatibility, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2"
    Namespace="eWorld.UI.Compatibility" TagPrefix="cc1" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <x:GridView ID="GridView1" runat="server" SkinID="xgridviewSkinEmployee" DataSourceID="dsAccountTimesheetPeriodTypeGridViewObject" AutoGenerateColumns="False" Caption='<%# ResourceHelper.GetFromResource("Timesheet Period Types") %>' DataKeyNames="AccountTimesheetPeriodTypeId" Width="98%">
            <Columns>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Timesheet Period Type%> ">
                    <edititemtemplate>
<asp:TextBox id="TextBox1" runat="server" Text='<%# Bind("SystemTimesheetPeriodType") %>' __designer:wfdid="w114"></asp:TextBox>
</edititemtemplate>
                    <headertemplate>
<asp:Label id="lblTimesheetPeriodType" runat="server" Text='<%# ResourceHelper.GetFromResource("Timesheet Period Type") %>' __designer:wfdid="w115"></asp:Label>
</headertemplate>
                    <itemtemplate>
    <asp:Label id="Label1" runat="server" Text='<%# Bind("SystemTimesheetPeriodType") %>' __designer:wfdid="w113"></asp:Label>
</itemtemplate> <itemstyle Width="67%"/>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Initial Days Of The Period%> ">
                    <edititemtemplate>
<asp:TextBox id="TextBox2" runat="server" Text='<%# Bind("SystemInitialDaysOfThePeriod") %>' __designer:wfdid="w117"></asp:TextBox>
</edititemtemplate>
                    <headertemplate>
<asp:Label id="lblInitialDaysOfThePeriod" runat="server" Text='<%# ResourceHelper.GetFromResource("Initial Days Of The Period") %>' __designer:wfdid="w118"></asp:Label>
</headertemplate>
                    <itemtemplate>
<asp:Label id="Label2" runat="server" Text='<%# Bind("SystemInitialDaysOfThePeriod") %>' __designer:wfdid="w116"></asp:Label>
</itemtemplate> <itemstyle Width="15%" HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Initial Days Of The Month%> " HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle">
                    <edititemtemplate>
<asp:TextBox id="TextBox3" runat="server" Text='<%# Bind("InitialDayOfTheMonth") %>' __designer:wfdid="w120"></asp:TextBox>
</edititemtemplate>
                    <headertemplate>
<asp:Label id="lblInitialDayOfTheMonth" runat="server" Text='<%# ResourceHelper.GetFromResource("Initial Day Of The Month") %>' __designer:wfdid="w121"></asp:Label>
</headertemplate>
                    <itemtemplate>
<asp:Label id="Label3" runat="server" Text='<%# Bind("InitialDayOfTheMonth") %>' __designer:wfdid="w119"></asp:Label>
</itemtemplate> <itemstyle Width="14%" HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:TemplateField>
                <asp:CommandField SelectText="Edit" ShowSelectButton="True" HeaderText="Edit">
                    <itemstyle cssclass="edit_button" Width="1%" HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:CommandField>
                <asp:TemplateField>
                    <headertemplate>
<asp:Image id="Image1" runat="server" __designer:wfdid="w17" ToolTip="<%$ Resources:TimeLive.Resource, Disabled_text%> " ImageUrl="~/Images/Disabled.gif"></asp:Image>
</headertemplate>
                    <itemtemplate>
<asp:Image id="Image11" runat="server" __designer:wfdid="w15" ToolTip="<%$ Resources:TimeLive.Resource, Disabled_text%> " Visible='<%# IIF(IsDBNull(Eval("IsDisabled")),"False",Eval("IsDisabled")) %>' ImageUrl="~/Images/Disabled.gif"></asp:Image> 
</itemtemplate><itemstyle Width="1%" HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:TemplateField>
            </Columns>
        </x:GridView>
        <asp:ObjectDataSource ID="dsAccountTimesheetPeriodTypeGridViewObject" runat="server" InsertMethod="AddAccountTimesheetPeriodType" OldValuesParameterFormatString="original_{0}" SelectMethod="GetvueAccountTimesheetPeriodTypesByAccountId" TypeName="AccountTimesheetPeriodTypeBLL" UpdateMethod="UpdateAccountTimesheetPeriodType">
            <UpdateParameters>
                <asp:Parameter Name="AccountId" Type="Int32" />
                <asp:Parameter Name="SystemTimesheetPeriodTypeId" Type="Int16" />
                <asp:Parameter Name="SystemInitialDaysOfThePeriodId" Type="Int16" />
                <asp:Parameter Name="InitialDayOfTheMonth" Type="Int16" />
                <asp:Parameter Name="ModifiedOn" Type="DateTime" />
                <asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" />
                <asp:Parameter Name="IsDisabled" Type="Boolean" />
                <asp:Parameter Name="Original_AccountTimesheetPeriodTypeId" />
            </UpdateParameters>
            <SelectParameters>
                <asp:SessionParameter Name="AccountId" SessionField="AccountId" Type="Int32" />
            </SelectParameters>
            <InsertParameters>
                <asp:Parameter Name="AccountId" Type="Int32" />
                <asp:Parameter Name="SystemTimesheetPeriodTypeId" Type="Int16" />
                <asp:Parameter Name="SystemInitialDaysOfThePeriodId" Type="Int16" />
                <asp:Parameter Name="InitialDayOfTheMonth" Type="Int16" />
                <asp:Parameter Name="CreatedOn" Type="DateTime" />
                <asp:Parameter Name="CreatedByEmployeeId" Type="Int32" />
                <asp:Parameter Name="ModifiedOn" Type="DateTime" />
                <asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" />
            </InsertParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="dsAccountTimesheetPeriodTypeFormViewObject" runat="server" InsertMethod="AddAccountTimesheetPeriodType" OldValuesParameterFormatString="original_{0}" SelectMethod="GetAccountTimesheetPeriodTypesByAccountTimesheetPeriodTypeId" TypeName="AccountTimesheetPeriodTypeBLL" UpdateMethod="UpdateAccountTimesheetPeriodType">
            <UpdateParameters>
                <asp:SessionParameter Name="AccountId" SessionField="AccountId" Type="Int32" />
                <asp:Parameter Name="SystemTimesheetPeriodTypeId" Type="Int16" />
                <asp:Parameter Name="SystemInitialDaysOfThePeriodId" Type="Int16" />
                <asp:Parameter Name="InitialDayOfTheMonth" Type="Int16" />
                <asp:Parameter Name="ModifiedOn" Type="DateTime" />
                <asp:SessionParameter Name="ModifiedByEmployeeId" SessionField="AccountEmployeeId"
                    Type="Int32" />
                <asp:Parameter Name="IsDisabled" Type="Boolean" />
                <asp:Parameter Name="Original_AccountTimesheetPeriodTypeId" />
            </UpdateParameters>
            <SelectParameters>
                <asp:ControlParameter ControlID="GridView1" Name="AccountTimesheetPeriodTypeId"
                    PropertyName="SelectedValue" />
            </SelectParameters>
            <InsertParameters>
                <asp:SessionParameter Name="AccountId" SessionField="AccountId" Type="Int32" />
                <asp:Parameter Name="SystemTimesheetPeriodTypeId" Type="Int16" />
                <asp:Parameter Name="SystemInitialDaysOfThePeriodId" Type="Int16" />
                <asp:Parameter Name="InitialDayOfTheMonth" Type="Int16" />
                <asp:Parameter Name="CreatedOn" Type="DateTime" />
                <asp:SessionParameter Name="CreatedByEmployeeId" SessionField="AccountEmployeeId"
                    Type="Int32" />
                <asp:Parameter Name="ModifiedOn" Type="DateTime" />
                <asp:SessionParameter Name="ModifiedByEmployeeId" SessionField="AccountEmployeeId"
                    Type="Int32" />
            </InsertParameters>
        </asp:ObjectDataSource>
    </ContentTemplate>
</asp:UpdatePanel>
&nbsp;&nbsp;
<br />
<asp:UpdatePanel ID="UpdatePanel2" runat="server">
    <ContentTemplate>
        <%If Me.FormView1.CurrentMode = FormViewMode.Edit Then%>
        <asp:FormView ID="FormView1" runat="server" SkinID="formviewSkinEmployee" DataSourceID="dsAccountTimesheetPeriodTypeFormViewObject" DataKeyNames="AccountTimesheetPeriodTypeId" DefaultMode="Insert" Width="450px">
            <EditItemTemplate><table width="100%" class="xview">
                <tr>
                    <th colspan="2" class="caption">
                        <asp:Literal ID="Literal1" runat="server" Text='<%# ResourceHelper.GetFromResource("Timesheet Period Type Information")%> ' /></th>
                </tr>
                <tr>
                    <th colspan="2" class="FormViewSubHeader">
                        <asp:Literal ID="Literal2" runat="server" Text='<%# ResourceHelper.GetFromResource("Timesheet Period Type")%> ' /></th>
                </tr>
                <tr>
                    <td style="width: 40%" align="right" class="FormViewLabelCell" valign="middle">
                        <SPAN 
                  class=reqasterisk>*</SPAN> <asp:Literal ID="Literal3" runat="server" Text='<%# ResourceHelper.GetFromResource("Timesheet Period Type:")%> ' /></td>
                    <td style="width: 60%">
                        <asp:DropDownList ID="ddlTimesheetPeriodType" runat="server" DataSourceID="dsSystemTimesheetPeriodTypeObject"
                                DataTextField="SystemTimesheetPeriodType" DataValueField="SystemTimesheetPeriodTypeId" Width="95px" AutoPostBack="True" OnSelectedIndexChanged="ddlTimesheetPeriodType_SelectedIndexChanged" SelectedValue='<%# Bind("SystemTimesheetPeriodTypeId") %>' Enabled="False">
                        </asp:DropDownList>
                    </td>
                </tr>
                <%If CType(Me.FormView1.FindControl("ddlInitialDaysOfThePeriod"), DropDownList).Visible = True Then%>
                <tr>
                    <td style="width: 40%" align="right" class="FormViewLabelCell" valign="middle">
                        <SPAN 
                  class=reqasterisk>*</SPAN> <asp:Literal ID="Literal4" runat="server" Text='<%# ResourceHelper.GetFromResource("Initial Days Of The Period:")%> ' /></td>
                    <td style="width: 60%">
                        <asp:DropDownList ID="ddlInitialDaysOfThePeriod" runat="server" DataSourceID="dsInitialDaysOfThePeriodObject"
                                DataTextField="SystemInitialDaysOfThePeriod" 
                            DataValueField="SystemInitialDaysOfThePeriodId" Width="95px" Visible="False" 
                            AppendDataBoundItems="True">
                            <asp:ListItem Selected="True" Value="0">&lt;Select&gt;</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <%End If %>
                <%If CType(Me.FormView1.FindControl("txtInitialDayOfTheMonth"), TextBox).Visible = True Then%>
                <tr>
                    <td style="width: 40%" align="right" class="FormViewLabelCell" valign="middle">
                        <SPAN 
                  class=reqasterisk>*</SPAN> <asp:Literal ID="Literal5" runat="server" Text='<%# ResourceHelper.GetFromResource("Initial Day Of The Month:")%> ' /></td>
                    <td style="width: 60%">
                        <asp:TextBox ID="txtInitialDayOfTheMonth" runat="server" Width="80px" 
                            Visible="False" Text='<%# Bind("InitialDayOfTheMonth") %>'></asp:TextBox></td>
                </tr>
                <%End If %>
                <tr>
                    <td align="right" class="FormViewLabelCell" style="width: 40%" valign="middle">
                        <asp:Literal ID="Literal10" runat="server" Text='<%# ResourceHelper.GetFromResource("IsDisabled:")%> ' /></td>
                    <td style="width: 60%">
                <asp:CheckBox ID="chkIsDisabled" runat="server" Checked='<%# Bind("IsDisabled") %>' Enabled='<%# IIF(NOT IsDbnull(Eval("MasterTimesheetPeriodTypeId")),"False","True") %>' /></td>
                </tr>
                <tr>
                    <td align="right" class="FormViewLabelCell" style="width: 40%" valign="middle">
                    </td>
                    <td style="width: 60%; padding-bottom: 5px; padding-top: 5px;">
                        <asp:Button ID="btnUpdate" runat="server" CommandName="Update" Text="<%$ Resources:TimeLive.Resource, Update_text %>" Width="68px" />&nbsp<asp:Button
                            ID="btnCancel" runat="server" CausesValidation="False" CommandName="Cancel" Text="<%$ Resources:TimeLive.Resource, Cancel_text %>"
                            Width="68px" /></td>
                </tr>
            </table>
            </EditItemTemplate>
            <InsertItemTemplate>
                <table width="100%" class="xview">
                    <tr>
                        <th colspan="2" class="caption">
                            <asp:Literal ID="Literal1" runat="server" Text="<%$ Resources:TimeLive.Resource, Update_text %>" /></th>
                    </tr>
                    <tr>
                        <th colspan="2" class="FormViewSubHeader">
                            <asp:Literal ID="Literal6" runat="server" Text='<%# ResourceHelper.GetFromResource("Timesheet Period Type")%> ' /></th>
                    </tr>
                    <tr>
                        <td style="width: 40%" align="right" class="FormViewLabelCell" valign="middle">
                            <SPAN 
                  class=reqasterisk>*</SPAN> <asp:Literal ID="Literal7" runat="server" Text='<%# ResourceHelper.GetFromResource("Timesheet Period Type:")%> ' /></td>
                        <td style="width: 60%">
                            <asp:DropDownList ID="ddlTimesheetPeriodType" runat="server" DataSourceID="dsSystemTimesheetPeriodTypeObject"
                                DataTextField="SystemTimesheetPeriodType" DataValueField="SystemTimesheetPeriodTypeId" Width="95px" AutoPostBack="True" OnSelectedIndexChanged="ddlTimesheetPeriodType_SelectedIndexChanged" SelectedValue='<%# Bind("SystemTimesheetPeriodTypeId") %>'>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <%If CType(Me.FormView1.FindControl("ddlInitialDaysOfThePeriod"), DropDownList).Visible = True Then%>
                    <tr>
                        <td style="width: 40%" align="right" class="FormViewLabelCell" valign="middle">
                            <SPAN 
                  class=reqasterisk>*</SPAN> <asp:Literal ID="Literal8" runat="server" Text='<%# ResourceHelper.GetFromResource("Initial Days Of The Period:")%> ' /></td>
                        <td style="width: 60%">
                            <asp:DropDownList ID="ddlInitialDaysOfThePeriod" runat="server" DataSourceID="dsInitialDaysOfThePeriodObject"
                                DataTextField="SystemInitialDaysOfThePeriod" 
                                DataValueField="SystemInitialDaysOfThePeriodId" Width="95px" Visible="False" 
                                SelectedValue='<%# Bind("SystemInitialDaysOfThePeriodId") %>' 
                                AppendDataBoundItems="True">
                                <asp:ListItem Selected="True" Value="0">&lt;Select&gt;</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <%End If%>
                    <%If CType(Me.FormView1.FindControl("txtInitialDayOfTheMonth"), TextBox).Visible = True Then%>
                    <tr>
                        <td style="width: 40%" align="right" class="FormViewLabelCell" valign="middle">
                            <SPAN 
                  class=reqasterisk>*</SPAN> <asp:Literal ID="Literal9" runat="server" Text='<%# ResourceHelper.GetFromResource("Initial Day Of The Month:")%> ' /></td>
                        <td style="width: 60%">
                            <asp:TextBox ID="txtInitialDayOfTheMonth" runat="server" Width="80px" 
                                Visible="False" Text='<%# Bind("InitialDayOfTheMonth") %>'></asp:TextBox></td>
                    </tr>
                    <%End If%>
                    <tr>
                        <td align="right" class="FormViewLabelCell" style="width: 40%" valign="middle">
                        </td>
                        <td style="width: 60%">
                            <asp:Button ID="btnAdd" runat="server" CommandName="Insert" Text="<%$ Resources:TimeLive.Resource, Add_text %>" Width="68px" /></td>
                    </tr>
                </table>
            </InsertItemTemplate>
            <ItemTemplate>
                AccountTimesheetPeriodTypeId:
                <asp:Label ID="AccountTimesheetPeriodTypeIdLabel" runat="server" Text='<%# Eval("AccountTimesheetPeriodTypeId") %>'>
                </asp:Label><br />
                AccountId:
                <asp:Label ID="AccountIdLabel" runat="server" Text='<%# Bind("AccountId") %>'></asp:Label><br />
                SystemTimesheetPeriodTypeId:
                <asp:Label ID="SystemTimesheetPeriodTypeIdLabel" runat="server" Text='<%# Bind("SystemTimesheetPeriodTypeId") %>'>
                </asp:Label><br />
                SystemInitialDaysOfThePeriodId:
                <asp:Label ID="SystemInitialDaysOfThePeriodIdLabel" runat="server" Text='<%# Bind("SystemInitialDaysOfThePeriodId") %>'>
                </asp:Label><br />
                InitialDayOfTheMonth:
                <asp:Label ID="InitialDayOfTheMonthLabel" runat="server" Text='<%# Bind("InitialDayOfTheMonth") %>'>
                </asp:Label><br />
                EffectiveDate:
                <asp:Label ID="EffectiveDateLabel" runat="server" Text='<%# Bind("EffectiveDate") %>'>
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
                IsDisabled:
                <asp:CheckBox ID="IsDisabledCheckBox" runat="server" Checked='<%# Bind("IsDisabled") %>'
                    Enabled="false" /><br />
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
        <%End If%>
        <asp:ObjectDataSource ID="dsSystemTimesheetPeriodTypeObject" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetSystemTimesheetPeriodTypes" TypeName="AccountTimesheetPeriodTypeBLL">
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="dsInitialDaysOfThePeriodObject" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetSystemInitialDaysOfThePeriod" TypeName="AccountTimesheetPeriodTypeBLL">
        </asp:ObjectDataSource>
    </ContentTemplate>
</asp:UpdatePanel>
