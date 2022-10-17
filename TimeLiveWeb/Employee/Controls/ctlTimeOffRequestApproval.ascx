<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlTimeOffRequestApproval.ascx.vb" Inherits="Employee_Controls_ctlTimeOffRequestApproval" %>
<%@ Register Assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24D65337282035F2"
    Namespace="eWorld.UI" TagPrefix="ew" %>
<script type="text/javascript">
    function ChangeCheckBoxState1(id, checkState1) {
        var cb = document.getElementById(id);
        if (cb != null)
            cb.checked = checkState1;
    }

    function ChangeAllCheckBoxStates1(checkState1) {
        // Toggles through all of the checkboxes defined in the CheckBoxIDs array
        // and updates their value to the checkState input parameter
        if (CheckBoxIDs1 != null) {
            for (var i = 0; i < CheckBoxIDs1.length; i++)
                ChangeCheckBoxState1(CheckBoxIDs1[i], checkState1);
        }
    }

</script>
<script type="text/javascript">
    function ChangeCheckBoxState2(id, checkState2) {
        var cb = document.getElementById(id);
        if (cb != null)
            cb.checked = checkState2;
    }

    function ChangeAllCheckBoxStates2(checkState2) {
        // Toggles through all of the checkboxes defined in the CheckBoxIDs array
        // and updates their value to the checkState input parameter
        if (CheckBoxIDs2 != null) {
            for (var i = 0; i < CheckBoxIDs2.length; i++)
                ChangeCheckBoxState2(CheckBoxIDs2[i], checkState2);
        }
    }

</script>
<script type="text/javascript">
    function ChangeCheckBoxState3(id, checkState3) {
        var cb = document.getElementById(id);
        if (cb != null)
            cb.checked = checkState3;
    }

    function ChangeAllCheckBoxStates3(checkState3) {
        // Toggles through all of the checkboxes defined in the CheckBoxIDs array
        // and updates their value to the checkState input parameter
        if (CheckBoxIDs3 != null) {
            for (var i = 0; i < CheckBoxIDs3.length; i++)
                ChangeCheckBoxState3(CheckBoxIDs3[i], checkState3);
        }
    }

</script>
<script type="text/javascript">
    function ChangeCheckBoxState4(id, checkState4) {
        var cb = document.getElementById(id);
        if (cb != null)
            cb.checked = checkState4;
    }

    function ChangeAllCheckBoxStates4(checkState4) {
        // Toggles through all of the checkboxes defined in the CheckBoxIDs array
        // and updates their value to the checkState input parameter
        if (CheckBoxIDs4 != null) {
            for (var i = 0; i < CheckBoxIDs4.length; i++)
                ChangeCheckBoxState4(CheckBoxIDs4[i], checkState4);
        }
    }

</script>
<script type="text/javascript">
    function ChangeCheckBoxState5(id, checkState5) {
        var cb = document.getElementById(id);
        if (cb != null)
            cb.checked = checkState5;
    }

    function ChangeAllCheckBoxStates5(checkState5) {
        // Toggles through all of the checkboxes defined in the CheckBoxIDs array
        // and updates their value to the checkState input parameter
        if (CheckBoxIDs5 != null) {
            for (var i = 0; i < CheckBoxIDs5.length; i++)
                ChangeCheckBoxState5(CheckBoxIDs5[i], checkState5);
        }
    }

</script>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <table class="xFormView">
            <tr>
                <td>
                    <table width="600px" class="xFormView">
                        <tr>
                            <th colspan="2" class="caption">
                                <asp:Literal ID="Literal7" runat="server" Text="<%$ Resources:TimeLive.Resource, Time Off Approval%> "></asp:Literal></th>
                        </tr>
                        <tr>
                            <th colspan="2" class="FormViewSubHeader">
                                <asp:Literal ID="Literal6" runat="server" Text="<%$ Resources:TimeLive.Resource, Search Parameters%> "></asp:Literal></th>
                        </tr>
                        <tr>
                            <td style="width: 100px" align="right" class="FormViewLabelCell">
                                <asp:Literal ID="Literal4" runat="server" Text="<%$ Resources:TimeLive.Resource, Employee Name:%> "></asp:Literal></td>
                            <td style="width: 250px">
                                <asp:DropDownList ID="ddlAccountEmployeeId" runat="server" AppendDataBoundItems="True"
                                    Width="260px">
                                    <asp:ListItem Selected="True" Value="0">&lt;ALL&gt;</asp:ListItem>
                                </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td style="width: 100px" align="right" class="FormViewLabelCell">
                                <asp:Literal ID="Literal1" runat="server" Text="<%$ Resources:TimeLive.Resource, Time Off Types:%> "></asp:Literal></td>
                </td>
                <td style="width: 250px">
                    <asp:DropDownList ID="ddlTimeOffTypeId" runat="server" DataSourceID="dsTimeOffTypeObject"
                        DataTextField="AccountTimeOffType" DataValueField="AccountTimeOffTypeId" Width="260px" AppendDataBoundItems="True">
                        <asp:ListItem Selected="True" Value="0">&lt;ALL&gt;</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 100px" align="right" class="FormViewLabelCell">
                    <asp:Literal ID="Literal5" runat="server" Text="<%$ Resources:TimeLive.Resource, Include Date Range:%> "></asp:Literal></td>
                <td style="width: 250px">
                    <asp:CheckBox ID="chkIncludeDateRange" runat="server" /></td>
            </tr>
            <tr>
                <td style="width: 100px" align="right" class="FormViewLabelCell">
                    <asp:Literal ID="Literal2" runat="server" Text="<%$ Resources:TimeLive.Resource, Time Off Start Date:%> "></asp:Literal></td>
                </td>
                <td style="width: 250px">
                    <ew:CalendarPopup ID="txtStartDate" runat="server" Width="55px">
                    </ew:CalendarPopup>
                </td>
            </tr>
            <tr>
                <td style="width: 100px" align="right" class="FormViewLabelCell">
                    <asp:Literal ID="Literal3" runat="server" Text="<%$ Resources:TimeLive.Resource, Time Off End Date:%> "></asp:Literal></td>
                </td>
                <td style="width: 250px">
                    <ew:CalendarPopup ID="txtEndDate" runat="server" Width="55px">
                    </ew:CalendarPopup>
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 100px; height: 26px;" class="FormViewLabelCell"></td>
                <td style="width: 250px; height: 26px; padding-bottom: 5px; padding-top: 5px;">
                    <asp:Button ID="btnShow" runat="server" Text="<%$ Resources:TimeLive.Resource, Show_text%> " OnClick="btnShow_Click" /></td>
            </tr>
        </table>
        </td></tr></table>
        <asp:ObjectDataSource ID="dsAccountEmployeeObject" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetEmployeesForTimeOffApproval" TypeName="AccountEmployeeBLL">
            <SelectParameters>
                <asp:SessionParameter DefaultValue="129" Name="ApproverEmployeeId" SessionField="AccountEmployeeId"
                    Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="dsTimeOffTypeObject" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetAccountTimeOffTypesByAccountIdAndIsDisabled" TypeName="AccountTimeOffTypeBLL">
            <SelectParameters>
                <asp:SessionParameter Name="AccountId" SessionField="AccountId" Type="Int32" />
                <asp:Parameter Name="AccountTimeOffTypeId" Type="Object" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="dsTimeOffApprovalEntriesForSpecificEmployee" runat="server"
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetvueAccountEmployeeTimeOffRequestApprovalForSpecificEmployee"
            TypeName="AccountEmployeeTimeOffRequestBLL">
            <SelectParameters>
                <asp:Parameter Name="AccountTimeOffTypeId" DbType="Guid" />
                <asp:ControlParameter ControlID="ddlAccountEmployeeId" Name="TimeOffAccountEmployeeId"
                    PropertyName="SelectedValue" Type="Int32" />
                <asp:ControlParameter ControlID="chkIncludeDateRange" DefaultValue="0" Name="IncludeDateRange"
                    PropertyName="Checked" Type="Boolean" />
                <asp:Parameter DefaultValue="11/02/2006" Name="StartDate" Type="DateTime" />
                <asp:Parameter DefaultValue="11/02/2006" Name="EndDate" Type="DateTime" />
                <asp:SessionParameter DefaultValue="" Name="AccountEmployeeId" SessionField="AccountEmployeeId"
                    Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="dsTimeOffApprovalEntriesForEmployeeManager" runat="server"
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetvueAccountEmployeeTimeOffRequestApprovalForEmployeeManager"
            TypeName="AccountEmployeeTimeOffRequestBLL">
            <SelectParameters>
                <asp:Parameter Name="AccountTimeOffTypeId" DbType="Guid" />
                <asp:ControlParameter ControlID="ddlAccountEmployeeId" DefaultValue="" Name="TimeOffAccountEmployeeId"
                    PropertyName="SelectedValue" Type="Int32" />
                <asp:ControlParameter ControlID="chkIncludeDateRange" DefaultValue="0" Name="IncludeDateRange"
                    PropertyName="Checked" Type="Boolean" />
                <asp:Parameter DefaultValue="10/02/2005" Name="StartDate" Type="DateTime" />
                <asp:Parameter DefaultValue="10/02/2005" Name="EndDate" Type="DateTime" />
                <asp:SessionParameter DefaultValue="" Name="AccountEmployeeId" SessionField="AccountEmployeeId"
                    Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="dsTimeOffApprovalEntriesForProjectManager"
            runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetvueAccountEmployeeTimeOffRequestApprovalForProjectManager"
            TypeName="AccountEmployeeTimeOffRequestBLL">
            <SelectParameters>
                <asp:Parameter Name="AccountTimeOffTypeId" DbType="Guid" />
                <asp:ControlParameter ControlID="ddlAccountEmployeeId" DefaultValue=""
                    Name="TimeOffAccountEmployeeId" PropertyName="SelectedValue" Type="Int32" />
                <asp:ControlParameter ControlID="chkIncludeDateRange" DefaultValue="0"
                    Name="IncludeDateRange" PropertyName="Checked" Type="Boolean" />
                <asp:Parameter DefaultValue="10/02/2005" Name="StartDate" Type="DateTime" />
                <asp:Parameter DefaultValue="10/02/2005" Name="EndDate" Type="DateTime" />
                <asp:SessionParameter DefaultValue="" Name="AccountEmployeeId"
                    SessionField="AccountEmployeeId" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="dsTimeOffApprovalEntriesForTeamLead" runat="server"
            OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetvueAccountEmployeeTimeOffRequestApprovalForTeamLead"
            TypeName="AccountEmployeeTimeOffRequestBLL">
            <SelectParameters>
                <asp:Parameter Name="AccountTimeOffTypeId" DbType="Guid" />
                <asp:ControlParameter ControlID="ddlAccountEmployeeId" DefaultValue=""
                    Name="TimeOffAccountEmployeeId" PropertyName="SelectedValue" Type="Int32" />
                <asp:ControlParameter ControlID="chkIncludeDateRange" DefaultValue="0"
                    Name="IncludeDateRange" PropertyName="Checked" Type="Boolean" />
                <asp:Parameter DefaultValue="10/02/2005" Name="StartDate" Type="DateTime" />
                <asp:Parameter DefaultValue="10/02/2005" Name="EndDate" Type="DateTime" />
                <asp:SessionParameter DefaultValue="" Name="AccountEmployeeId"
                    SessionField="AccountEmployeeId" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </ContentTemplate>
</asp:UpdatePanel>
<br />
&nbsp;<asp:Button ID="btnUpdate" runat="server" UseSubmitBehavior="False" Text="<%$ Resources:TimeLive.Resource, Update Time Off Approvals%> " /><br />
<br />
<asp:UpdatePanel ID="UpdatePanel2" runat="server">
    <ContentTemplate>
        <x:GridView ID="SpecificEmployeeGridView" runat="server"
            AutoGenerateColumns="False"
            DataSourceID="dsTimeOffApprovalEntriesForSpecificEmployee" Width="98%"
            Caption="<%$ Resources:TimeLive.Resource, Specific Employee Time Off Approvals %>"
            SkinID="xgridviewSkinEmployee"
            DataKeyNames="AccountEmployeeTimeOffRequestId,AccountApprovalTypeId,AccountApprovalPathId,AccountEmployeeId,IsRejected,IsApproved,ApprovalPathSequence,MaxApprovalPathSequence,HoursOff,AccountTimeOffTypeId,TimeOffAccountEmployeeId,StartDate">
            <Columns>
                <asp:BoundField DataField="FullName" HeaderText="<%$ Resources:TimeLive.Resource, Employee Name%> " SortExpression="FullName">
                    <ItemStyle Width="23%" />
                </asp:BoundField>
                <asp:BoundField DataField="AccountTimeOffType" HeaderText="<%$ Resources:TimeLive.Resource, Time Off Type%> " SortExpression="AccountTimeOffType">
                    <ItemStyle Width="14%" />
                </asp:BoundField>
                <asp:BoundField DataField="Description" HeaderText="<%$ Resources:TimeLive.Resource, Description%> " SortExpression="Description">
                    <ItemStyle Width="13%" />
                </asp:BoundField>
                <%-- <asp:BoundField DataField="Available" HeaderText="<%$ Resources:TimeLive.Resource, Available%> " >
                     <itemstyle width="4%" horizontalalign="Right" />
                </asp:BoundField>--%>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Available%> " ItemStyle-HorizontalAlign="Right" ItemStyle-VerticalAlign="Middle">
                    <ItemTemplate>
                        <asp:Label ID="lblAvailableSpecificEmployee" runat="server" Text='<%# Bind("Available") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="4%" />
                </asp:TemplateField>
                <asp:BoundField DataField="DayOff" HeaderText="<%$ Resources:TimeLive.Resource, Day Off%> ">
                    <ItemStyle Width="4%" HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="HoursOff" HeaderText="<%$ Resources:TimeLive.Resource, Hours Off%> ">
                    <ItemStyle Width="4%" HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="StartDate" HeaderText="<%$ Resources:TimeLive.Resource, Start Date%> " DataFormatString="{0:d}" HtmlEncode="False">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle Width="6%" HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="EndDate" HeaderText="<%$ Resources:TimeLive.Resource, End Date%> " DataFormatString="{0:d}" HtmlEncode="False">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle Width="6%" HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:TemplateField >
                    <HeaderStyle Width ="65px" />
                    <HeaderTemplate >
                        <asp:Label runat="server" Text ='<%# ResourceHelper.GetFromResource("Attachment") %>'> </asp:Label>
                    </HeaderTemplate>
                    <ItemTemplate >
                        <asp:HyperLink  ID="ATLink" Visible="false"  Text ="<%$ Resources:TimeLive.Resource,Attachment %>" runat ="server" NavigateUrl ="~/Employee/TimeOffAttachments.aspx"  onclick="window.open (this.href, 'popupwindow', 'width=680,height=250,left=300,top=300'); return false;" >[ATLink]</asp:HyperLink>
                           
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Font-Bold ="true"  />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Approved%> ">
                    <ItemTemplate>
                        <asp:RadioButton ID="rdSpecificEmployee" runat="server" __designer:wfdid="w10" GroupName="SpecificEmployee"></asp:RadioButton>
                    </ItemTemplate>
                    <ItemStyle Width="5%" HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Rejected%> ">
                    <ItemTemplate>
                        <asp:RadioButton ID="rdSpecificEmployeeRejected" runat="server" __designer:wfdid="w11" GroupName="SpecificEmployee"></asp:RadioButton>
                    </ItemTemplate>
                    <ItemStyle Width="5%" HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Comments%> ">
                    <ItemTemplate>
                        <asp:TextBox ID="CommentsTextBox" runat="server" Width="93%" TextMode="MultiLine"
                            __designer:wfdid="w23" Height="45px"></asp:TextBox>
                    </ItemTemplate>
                    <ItemStyle Width="15%" />
                </asp:TemplateField>
            </Columns>
        </x:GridView>
        &nbsp;<asp:LinkButton ID="CheckAllSpecificEmployee" runat="server" CssClass="FeatureHeadingIcon"
            OnClientClick="ChangeAllCheckBoxStates1(true);" Visible="False">
            <asp:Literal ID="Literal10" runat="server" Text="<%$ Resources:TimeLive.Resource, Check-All Approved%> "></asp:Literal>
        </asp:LinkButton>
        &nbsp;<asp:LinkButton
            ID="UnCheckAllSpecificEmployee" runat="server" CssClass="FeatureHeadingIcon" OnClientClick="ChangeAllCheckBoxStates1(false);"
            Visible="False">
            <asp:Literal ID="Literal11" runat="server" Text="<%$ Resources:TimeLive.Resource, Uncheck-All Approved%> "></asp:Literal>
        </asp:LinkButton>
    </ContentTemplate>
</asp:UpdatePanel>
<br />
<asp:UpdatePanel ID="UpdatePanel3" runat="server">
    <ContentTemplate>
        <x:GridView ID="EmployeeManagerGridView" runat="server"
            AutoGenerateColumns="False"
            DataSourceID="dsTimeOffApprovalEntriesForEmployeeManager" Width="98%"
            Caption="<%$ Resources:TimeLive.Resource, Employee Manager Time Off Approvals %>"
            SkinID="xgridviewSkinEmployee"
            DataKeyNames="AccountEmployeeTimeOffRequestId,AccountApprovalTypeId,AccountApprovalPathId,EmployeeManagerId,IsRejected,IsApproved,ApprovalPathSequence,MaxApprovalPathSequence,HoursOff,AccountTimeOffTypeId,TimeOffAccountEmployeeId,StartDate">
            <Columns>
                
                <asp:TemplateField SortExpression="FullName" HeaderText="<%$ Resources:TimeLive.Resource, Employee Name %>">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" __designer:wfdid="w265" Text='<%# Bind("FullName") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <HeaderTemplate>
                        <asp:LinkButton ID="LinkButton7" runat="server" Text='<%# ResourceHelper.GetFromResource("Employee Name") %>' CommandArgument="FullName" CommandName="Sort" CausesValidation="False"></asp:LinkButton>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:HyperLink ID="lnkEmployeeName" onclick="window.open (this.href, 'popupwindow', 'width=1250,height=500,left=0,top=0,scrollbars=yes'); return false;" runat="server" __designer:wfdid="w264" Text='<%# Bind("FullName") %>' ></asp:HyperLink>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Left" Width="320px" />
                </asp:TemplateField>
                <asp:BoundField DataField="AccountTimeOffType" HeaderText="<%$ Resources:TimeLive.Resource, Time Off Type%> " SortExpression="AccountTimeOffType">
                    <ItemStyle Width="14%" />
                </asp:BoundField>
                <asp:BoundField DataField="Description" HeaderText="<%$ Resources:TimeLive.Resource, Description%> " SortExpression="Description">
                    <ItemStyle Width="13%" />
                </asp:BoundField>
                <%-- <asp:BoundField DataField="Available" HeaderText="<%$ Resources:TimeLive.Resource, Available%> " >
                     <itemstyle width="4%" horizontalalign="Right" />
                </asp:BoundField>--%>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Available%> " ItemStyle-HorizontalAlign="Right" ItemStyle-VerticalAlign="Middle">
                    <ItemTemplate>
                        <asp:Label ID="lblAvailableEmployeeManager" runat="server" Text='<%# Bind("Available") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="4%" />
                </asp:TemplateField>
                <asp:BoundField DataField="DayOff" HeaderText="<%$ Resources:TimeLive.Resource, Day Off%> ">
                    <ItemStyle Width="4%" HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="HoursOff" HeaderText="<%$ Resources:TimeLive.Resource, Hours Off%> ">
                    <ItemStyle Width="4%" HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="StartDate" HeaderText="<%$ Resources:TimeLive.Resource, Start Date%> " DataFormatString="{0:d}" HtmlEncode="False">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle Width="6%" HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="EndDate" HeaderText="<%$ Resources:TimeLive.Resource, End Date%> " DataFormatString="{0:d}" HtmlEncode="False">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle Width="6%" HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:TemplateField >
                    <HeaderStyle Width ="65px" />
                    <HeaderTemplate >
                        <asp:Label runat="server" Text ='<%# ResourceHelper.GetFromResource("Attachment") %>'> </asp:Label>
                    </HeaderTemplate>
                    <ItemTemplate >
                        <asp:HyperLink  ID="ATLink" Visible="false"  Text ="<%$ Resources:TimeLive.Resource,Attachment %>" runat ="server" NavigateUrl ="~/Employee/TimeOffAttachments.aspx"  onclick="window.open (this.href, 'popupwindow', 'width=680,height=250,left=300,top=300'); return false;" >[ATLink]</asp:HyperLink>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Font-Bold ="true"  />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Approved%> ">
                    <ItemTemplate>
                        <asp:RadioButton ID="rdEmployeeManager" runat="server" __designer:wfdid="w20" GroupName="EmployeeManager"></asp:RadioButton>
                    </ItemTemplate>
                    <ItemStyle Width="5%" HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Rejected%> ">
                    <ItemTemplate>
                        <asp:RadioButton ID="rdEmployeeManagerRejected" runat="server" __designer:wfdid="w21" GroupName="EmployeeManager"></asp:RadioButton>
                    </ItemTemplate>
                    <ItemStyle Width="5%" HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Comments%> ">
                    <ItemTemplate>
                        <asp:TextBox ID="CommentsTextBox" runat="server" Width="91%" TextMode="MultiLine"
                            __designer:wfdid="w22" Height="45px"></asp:TextBox>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle Width="15%" HorizontalAlign="Center" />
                </asp:TemplateField>
            </Columns>
        </x:GridView>
        &nbsp;
                <asp:LinkButton ID="CheckAllEmployeeManager" runat="server" CssClass="FeatureHeadingIcon"
                    OnClientClick="ChangeAllCheckBoxStates2(true);" Visible="False">
                    <asp:Literal ID="Literal8" runat="server" Text="<%$ Resources:TimeLive.Resource, Check-All Approved%> "></asp:Literal>
        </asp:LinkButton>
        &nbsp;<asp:LinkButton
            ID="UnCheckAllEmployeeManager" runat="server" CssClass="FeatureHeadingIcon" OnClientClick="ChangeAllCheckBoxStates2(false);"
            Visible="False">
            <asp:Literal ID="Literal9" runat="server" Text="<%$ Resources:TimeLive.Resource, Uncheck-All Approved%> "></asp:Literal>
        </asp:LinkButton>
    </ContentTemplate>
</asp:UpdatePanel>
<br />
<asp:UpdatePanel ID="UpdatePanel4" runat="server">
    <ContentTemplate>
        <x:GridView ID="ProjectManagerGridView" runat="server"
            AutoGenerateColumns="False"
            DataSourceID="dsTimeOffApprovalEntriesForProjectManager" Width="98%"
            Caption="<%$ Resources:TimeLive.Resource, Project Manager Time Off Approvals %>"
            SkinID="xgridviewSkinEmployee"
            DataKeyNames="AccountEmployeeTimeOffRequestId,AccountApprovalTypeId,AccountApprovalPathId,ProjectManagerId,IsRejected,IsApproved,ApprovalPathSequence,MaxApprovalPathSequence,HoursOff,AccountTimeOffTypeId,TimeOffAccountEmployeeId,StartDate">
            <Columns>
                <asp:BoundField DataField="FullName" HeaderText="<%$ Resources:TimeLive.Resource, Employee Name%> " SortExpression="FullName">
                    <ItemStyle Width="23%" />
                </asp:BoundField>
                <asp:BoundField DataField="AccountTimeOffType" HeaderText="<%$ Resources:TimeLive.Resource, Time Off Type%> " SortExpression="AccountTimeOffType">
                    <ItemStyle Width="14%" />
                </asp:BoundField>
                <asp:BoundField DataField="Description" HeaderText="<%$ Resources:TimeLive.Resource, Description%> " SortExpression="Description">
                    <ItemStyle Width="13%" />
                </asp:BoundField>
                <%--  <asp:BoundField DataField="Available" HeaderText="<%$ Resources:TimeLive.Resource, Available%> " >
                     <itemstyle width="4%" horizontalalign="Right" />
                </asp:BoundField>--%>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Available%> " ItemStyle-HorizontalAlign="Right" ItemStyle-VerticalAlign="Middle">
                    <ItemTemplate>
                        <asp:Label ID="lblAvailableProjectManager" runat="server" Text='<%# Bind("Available") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="4%" />
                </asp:TemplateField>
                <asp:BoundField DataField="DayOff" HeaderText="<%$ Resources:TimeLive.Resource, Day Off%> ">
                    <ItemStyle Width="4%" HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="HoursOff" HeaderText="<%$ Resources:TimeLive.Resource, Hours Off%> ">
                    <ItemStyle Width="4%" HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="StartDate" HeaderText="<%$ Resources:TimeLive.Resource, Start Date%> " DataFormatString="{0:d}" HtmlEncode="False">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle Width="6%" HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="EndDate" HeaderText="<%$ Resources:TimeLive.Resource, End Date%> " DataFormatString="{0:d}" HtmlEncode="False">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle Width="6%" HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Approved%> ">
                    <ItemTemplate>
                        <asp:RadioButton ID="rdProjectManager" runat="server" __designer:wfdid="w20" GroupName="EmployeeManager"></asp:RadioButton>
                    </ItemTemplate>
                    <ItemStyle Width="5%" HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Rejected%> ">
                    <ItemTemplate>
                        <asp:RadioButton ID="rdProjectManagerRejected" runat="server" __designer:wfdid="w21" GroupName="EmployeeManager"></asp:RadioButton>
                    </ItemTemplate>
                    <ItemStyle Width="5%" HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Comments%> ">
                    <ItemTemplate>
                        <asp:TextBox ID="CommentsTextBox" runat="server" Width="91%" TextMode="MultiLine"
                            __designer:wfdid="w22" Height="45px"></asp:TextBox>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle Width="15%" HorizontalAlign="Center" />
                </asp:TemplateField>
            </Columns>
        </x:GridView>
        &nbsp;
            <asp:LinkButton ID="CheckAllProjectManager" runat="server" CssClass="FeatureHeadingIcon"
                OnClientClick="ChangeAllCheckBoxStates3(true);" Visible="False">
                <asp:Literal ID="Literal12" runat="server" Text="<%$ Resources:TimeLive.Resource, Check-All Approved%> "></asp:Literal>
        </asp:LinkButton>
        &nbsp;
            <asp:LinkButton ID="UnCheckAllProjectManager" runat="server" CssClass="FeatureHeadingIcon" OnClientClick="ChangeAllCheckBoxStates3(false);"
                Visible="False">
                <asp:Literal ID="Literal13" runat="server" Text="<%$ Resources:TimeLive.Resource, Uncheck-All Approved%> "></asp:Literal>
        </asp:LinkButton>
    </ContentTemplate>
</asp:UpdatePanel>
<br />
<asp:UpdatePanel ID="UpdatePanel5" runat="server">
    <ContentTemplate>
        <x:GridView ID="TeamLeadGridView" runat="server"
            AutoGenerateColumns="False"
            DataSourceID="dsTimeOffApprovalEntriesForTeamLead" Width="98%"
            Caption="<%$ Resources:TimeLive.Resource, Team Lead Time Off Approvals %>"
            SkinID="xgridviewSkinEmployee"
            DataKeyNames="AccountEmployeeTimeOffRequestId,AccountApprovalTypeId,AccountApprovalPathId,TeamLeadId,IsRejected,IsApproved,ApprovalPathSequence,MaxApprovalPathSequence,HoursOff,AccountTimeOffTypeId,TimeOffAccountEmployeeId,StartDate">
            <Columns>
                <asp:BoundField DataField="FullName" HeaderText="<%$ Resources:TimeLive.Resource, Employee Name%> " SortExpression="FullName">
                    <ItemStyle Width="23%" />
                </asp:BoundField>
                <asp:BoundField DataField="AccountTimeOffType" HeaderText="<%$ Resources:TimeLive.Resource, Time Off Type%> " SortExpression="AccountTimeOffType">
                    <ItemStyle Width="14%" />
                </asp:BoundField>
                <asp:BoundField DataField="Description" HeaderText="<%$ Resources:TimeLive.Resource, Description%> " SortExpression="Description">
                    <ItemStyle Width="13%" />
                </asp:BoundField>
                <%--<asp:BoundField DataField="Available" HeaderText="<%$ Resources:TimeLive.Resource, Available%> " >
                     <itemstyle width="4%" horizontalalign="Right" />
                </asp:BoundField>--%>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Available%> " ItemStyle-HorizontalAlign="Right" ItemStyle-VerticalAlign="Middle">
                    <ItemTemplate>
                        <asp:Label ID="lblAvailableTeamLead" runat="server" Text='<%# Bind("Available") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="4%" />
                </asp:TemplateField>
                <asp:BoundField DataField="DayOff" HeaderText="<%$ Resources:TimeLive.Resource, Day Off%> ">
                    <ItemStyle Width="4%" HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="HoursOff" HeaderText="<%$ Resources:TimeLive.Resource, Hours Off%> ">
                    <ItemStyle Width="4%" HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="StartDate" HeaderText="<%$ Resources:TimeLive.Resource, Start Date%> " DataFormatString="{0:d}" HtmlEncode="False">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle Width="6%" HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="EndDate" HeaderText="<%$ Resources:TimeLive.Resource, End Date%> " DataFormatString="{0:d}" HtmlEncode="False">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle Width="6%" HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Approved%> ">
                    <ItemTemplate>
                        <asp:RadioButton ID="rdTeamLead" runat="server" __designer:wfdid="w20" GroupName="EmployeeManager"></asp:RadioButton>
                    </ItemTemplate>
                    <ItemStyle Width="5%" HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Rejected%> ">
                    <ItemTemplate>
                        <asp:RadioButton ID="rdTeamLeadRejected" runat="server" __designer:wfdid="w21" GroupName="EmployeeManager"></asp:RadioButton>
                    </ItemTemplate>
                    <ItemStyle Width="5%" HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Comments%> ">
                    <ItemTemplate>
                        <asp:TextBox ID="CommentsTextBox" runat="server" Width="91%" TextMode="MultiLine"
                            __designer:wfdid="w22" Height="45px"></asp:TextBox>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle Width="15%" HorizontalAlign="Center" />
                </asp:TemplateField>
            </Columns>
        </x:GridView>
        &nbsp;
        <asp:LinkButton ID="CheckAllTeamLead" runat="server" CssClass="FeatureHeadingIcon"
            OnClientClick="ChangeAllCheckBoxStates4(true);" Visible="False">
            <asp:Literal ID="Literal14" runat="server" Text="<%$ Resources:TimeLive.Resource, Check-All Approved%> "></asp:Literal>
        </asp:LinkButton>
        &nbsp;<asp:LinkButton
            ID="UnCheckAllTeamLead" runat="server" CssClass="FeatureHeadingIcon" OnClientClick="ChangeAllCheckBoxStates4(false);"
            Visible="False">
            <asp:Literal ID="Literal15" runat="server" Text="<%$ Resources:TimeLive.Resource, Uncheck-All Approved%> "></asp:Literal>
        </asp:LinkButton>
    </ContentTemplate>
</asp:UpdatePanel>

<script src="../js/libs/jquery-1.7.2.min.js"></script>
<script type="text/javascript">

    $(document).ready(function () {
        $(function () {
            $('.xGridView input:radio').click(function () {
                var $radio = $(this);

                // if this was previously checked
                if ($radio.data('waschecked') == true) {
                    $radio.prop('checked', false);
                    $radio.data('waschecked', false);
                }
                else
                    $radio.data('waschecked', true);

                // remove was checked from other radios
                $radio.siblings('.xGridView input:radio').data('waschecked', false);
            });
        });
    });

</script>
