<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlTimeSheetApprovalSummary.ascx.vb" Inherits="ProjectAdmin_Controls_ctlTimeSheetApprovalSummary" %>

    
    
    <%--<script src="https://ajax.googleapis.com/ajax/libs/jqueryui/1.12.1/jquery-ui.min.js"></script>--%>
    
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
<script type="text/javascript">
    function ChangeCheckBoxState6(id, checkState6) {
        var cb = document.getElementById(id);
        if (cb != null)
            cb.checked = checkState6;
    }

    function ChangeAllCheckBoxStates6(checkState6) {
        // Toggles through all of the checkboxes defined in the CheckBoxIDs array
        // and updates their value to the checkState input parameter
        if (CheckBoxIDs6 != null) {
            for (var i = 0; i < CheckBoxIDs6.length; i++)
                ChangeCheckBoxState6(CheckBoxIDs6[i], checkState6);
        }
    }

</script>
<script type="text/javascript">
    function ChangeCheckBoxState7(id, checkState7) {
        var cb = document.getElementById(id);
        if (cb != null)
            cb.checked = checkState7;
    }

    function ChangeAllCheckBoxStates7(checkState7) {
        // Toggles through all of the checkboxes defined in the CheckBoxIDs array
        // and updates their value to the checkState input parameter
        if (CheckBoxIDs7 != null) {
            for (var i = 0; i < CheckBoxIDs7.length; i++)
                ChangeCheckBoxState7(CheckBoxIDs7[i], checkState7);
        }
    }

</script>
<script type="text/javascript">
    function Check(textBox, maxLength) {
        if (textBox.value.length > maxLength) {
            alert("You cannot enter more than " + maxLength + " characters.");
            textBox.value = textBox.value.substr(0, maxLength);
        }
    }
</script>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <x:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Caption='<%# ResourceHelper.GetFromResource("My Team Time Entry Approvals") %>'
            DataSourceID="dsApprovalEntriesForTeamLeadObject"
            ShowFooter="True" SkinID="xgridviewSkinEmployee"
            DataKeyNames="TimeEntryAccountEmployeeId,TimeEntryStartDate,TimeEntryEndDate,TimeEntryDate,AccountEmployeeTimeEntryPeriodId,EmployeeName,TotalMinutes,EmailAddress,TimeEntryViewType,AccountProjectId,Percentage"
            OnDataBound="GridView1_DataBound">
            <Columns>
                <asp:TemplateField SortExpression="EmployeeName" HeaderText="<%$ Resources:TimeLive.Resource, Employee Name %>">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" __designer:wfdid="w253" Text='<%# Bind("EmployeeName") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <HeaderTemplate>
                        <asp:LinkButton ID="LinkButton3" runat="server" Text='<%# ResourceHelper.GetFromResource("Employee Name") %>' CommandArgument="EmployeeName" CommandName="Sort" CausesValidation="False"></asp:LinkButton>
                    </HeaderTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="320px" />
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemTemplate>
                        <asp:HyperLink ID="lnkEmployeeName" onclick="window.open (this.href, 'popupwindow', 'width=1000,height=675,left=0,top=0,scrollbars=yes,resizable=yes'); return false;" runat="server" __designer:wfdid="w252" Text='<%# Bind("EmployeeName") %>' NavigateUrl="~/Employee/AccountEmployeeTimeEntryWeekViewReadOnly.aspx"></asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Timesheet Period %>">
                    <EditItemTemplate>
                        &nbsp; 
                    </EditItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="100px" />
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" __designer:wfdid="w248" Text='<%# Format("{0:d}",Eval("TimeEntryStartDate")) %>'></asp:Label>&nbsp;-
                        <asp:Label ID="Label2" runat="server" __designer:wfdid="w249" Text='<%# Format("{0:d}",Eval("TimeEntryEndDate")) %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Billable Hours %>">
                    <FooterTemplate>
                        <asp:Label ID="lblSumBillableTime" runat="server" __designer:wfdid="w251"></asp:Label>
                    </FooterTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="70px" />
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemTemplate>
                        <asp:Label ID="lblBillableTime" runat="server" __designer:wfdid="w250"></asp:Label>
                    </ItemTemplate>
                    <FooterStyle HorizontalAlign="Center" Width="70px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Non-billable Hours %>">
                    <FooterTemplate>
                        <asp:Label ID="lblSumNonBillableTime" runat="server" __designer:wfdid="w2"></asp:Label>
                    </FooterTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="98px" />
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemTemplate>
                        <asp:Label ID="lblNonBillableTime" runat="server" __designer:wfdid="w1"></asp:Label>
                    </ItemTemplate>
                    <FooterStyle HorizontalAlign="Center" Width="98px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Total Hours %>">
                    <FooterTemplate>
                        <asp:Label ID="lblSumTotalTime" runat="server" __designer:wfdid="w8"></asp:Label>
                    </FooterTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="70px" />
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemTemplate>
                        <asp:Label ID="lblTotalTime" runat="server" __designer:wfdid="w6"></asp:Label>
                    </ItemTemplate>
                    <FooterStyle HorizontalAlign="Center" Width="70px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Total Percentage %>" Visible="False">
                    <FooterTemplate>
                        <asp:Label ID="lblSumPercentage" runat="server" __designer:wfdid="w8"></asp:Label>
                    </FooterTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="55px" />
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemTemplate>
                        <asp:Label ID="lblPercentage" runat="server" __designer:wfdid="w6"></asp:Label>
                    </ItemTemplate>
                    <FooterStyle HorizontalAlign="Center" Width="55px" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemStyle HorizontalAlign="Center" Width="65px" />
                    <HeaderStyle HorizontalAlign="Center" />
                    <HeaderTemplate>
                        <asp:Label ID="lblApproved" runat="server" Text='<%# ResourceHelper.GetFromResource("Approved") %>'></asp:Label>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:RadioButton ID="chkTeamLead" runat="server" __designer:wfdid="w7" GroupName="TeamLead"></asp:RadioButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemStyle HorizontalAlign="Center" Width="65px" />
                    <HeaderStyle HorizontalAlign="Center" />
                    <HeaderTemplate>
                        <asp:Label ID="lblRejected" runat="server" Text='<%# ResourceHelper.GetFromResource("Rejected") %>'></asp:Label>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:RadioButton ID="chkTeamLeadRejected" runat="server" __designer:wfdid="w8" GroupName="TeamLead"></asp:RadioButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Approver's Comments%> ">
                    <ItemStyle Width="250px" />
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemTemplate>
                        &nbsp;<asp:TextBox ID="TeamLeadCommentsTextBox" runat="server" __designer:wfdid="w3" Width="91%"
                            TextMode="MultiLine" Height="45px" onkeyup="javascript:Check(this, 750);" onchange="javascript:Check(this, 750);"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="TotalMinutes" HeaderText="TotalMinutes" SortExpression="TotalMinutes"
                    Visible="False" />
                <asp:BoundField DataField="BillableTotalMinutes" HeaderText="BillableTotalMinutes"
                    SortExpression="BillableTotalMinutes" Visible="False" />
                <asp:BoundField DataField="NonBillableTotalMinutes" HeaderText="NonBillableTotalMinutes"
                    SortExpression="NonBillableTotalMinutes" Visible="False" />
            </Columns>
        </x:GridView>
        &nbsp;
       
        <asp:LinkButton ID="CheckAllTeamLead" runat="server" CssClass="FeatureHeadingIcon"
            OnClientClick="ChangeAllCheckBoxStates1(true);" Visible="False">
            <asp:Literal ID="Literal8" runat="server" Text="<%$ Resources:TimeLive.Resource, Check-All Approved%> "></asp:Literal>
        </asp:LinkButton>
        &nbsp;<asp:LinkButton
            ID="UnCheckAllTeamLead" runat="server" CssClass="FeatureHeadingIcon" OnClientClick="ChangeAllCheckBoxStates1(false);"
            Visible="False">
            <asp:Literal ID="Literal9" runat="server" Text="<%$ Resources:TimeLive.Resource, Uncheck-All Approved%> "></asp:Literal>
        </asp:LinkButton><asp:ObjectDataSource ID="dsApprovalEntriesForTeamLeadObject" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetApprovalEntriesForTeamLeadSummarize" TypeName="AccountEmployeeTimeEntryBLL">
            <SelectParameters>
                <asp:SessionParameter DefaultValue="39" Name="AccountEmployeeId" SessionField="AccountEmployeeId"
                    Type="Int32" />
                <asp:ControlParameter ControlID="ddlAccountEmployeeId" DefaultValue="39" Name="TimeEntryAccountEmployeeId"
                    PropertyName="SelectedValue" Type="Int32" />
                <asp:Parameter DefaultValue="11/02/2006" Name="TimeEntryStartDate" Type="DateTime" />
                <asp:Parameter DefaultValue="11/02/2006" Name="TimeEntryEndDate" Type="DateTime" />
                <asp:ControlParameter ControlID="chkIncludeDateRange" DefaultValue="0" Name="IncludeDateRange"
                    PropertyName="Checked" Type="Boolean" />
            </SelectParameters>
            <FilterParameters>
                <asp:Parameter DefaultValue="39" Direction="Output" Name="AccountEmployeeId" Type="Int32" />
            </FilterParameters>
        </asp:ObjectDataSource>
    </ContentTemplate>
</asp:UpdatePanel>
<br />
<asp:UpdatePanel ID="Updatepanel2" runat="server">
    <ContentTemplate>
        <x:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" Caption='<%# ResourceHelper.GetFromResource("My Projects Time Entry Approvals") %>'
            DataKeyNames="TimeEntryAccountEmployeeId,TimeEntryStartDate,TimeEntryEndDate,TimeEntryDate,AccountEmployeeTimeEntryPeriodId,EmployeeName,TotalMinutes,EmailAddress,TimeEntryViewType,AccountProjectId,Percentage" DataSourceID="ApprovalEntriesForProjectManagerObject"
            OnRowDataBound="GridView2_RowDataBound" ShowFooter="True"
            SkinID="xgridviewSkinEmployee" OnDataBound="GridView2_DataBound">
            <Columns>
                <asp:TemplateField SortExpression="EmployeeName" HeaderText="<%$ Resources:TimeLive.Resource, Employee Name %>">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" __designer:wfdid="w256" Text='<%# Bind("EmployeeName") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <HeaderTemplate>
                        <asp:LinkButton ID="LinkButton4" runat="server" Text='<%# ResourceHelper.GetFromResource("Employee Name") %>' CommandArgument="EmployeeName" CommandName="Sort" CausesValidation="False"></asp:LinkButton>
                    </HeaderTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="320px" />
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemTemplate>
                        <asp:HyperLink ID="lnkEmployeeName" onclick="window.open (this.href, 'popupwindow', 'width=1000,height=675,left=0,top=0,scrollbars=yes'); return false;" runat="server" __designer:wfdid="w255" Text='<%# Bind("EmployeeName") %>' NavigateUrl="~/Employee/AccountEmployeeTimeEntryWeekViewReadOnly.aspx"></asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Timesheet Period %>">
                    <EditItemTemplate>
                        &nbsp;
                    </EditItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="100px" />
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" __designer:wfdid="w10" Text='<%# Format("{0:d}",Eval("TimeEntryStartDate")) %>'></asp:Label>&nbsp;-
                        <asp:Label ID="Label2" runat="server" __designer:wfdid="w11" Text='<%# Format("{0:d}",Eval("TimeEntryEndDate")) %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Billable Hours %>">
                    <FooterTemplate>
                        <asp:Label ID="lblSumBillableTime" runat="server" __designer:wfdid="w27"></asp:Label>
                    </FooterTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="70px" />
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemTemplate>
                        <asp:Label ID="lblBillableTime" runat="server" __designer:wfdid="w27"></asp:Label>
                    </ItemTemplate>
                    <FooterStyle HorizontalAlign="Center" Width="70px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Non-billable Hours %>">
                    <FooterTemplate>
                        <asp:Label ID="lblSumNonBillableTime" runat="server" __designer:wfdid="w29"></asp:Label>
                    </FooterTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="98px" />
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemTemplate>
                        <asp:Label ID="lblNonBillableTime" runat="server" __designer:wfdid="w29"></asp:Label>
                    </ItemTemplate>
                    <FooterStyle HorizontalAlign="Center" Width="98px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Total Hours %>">
                    <EditItemTemplate>
                        &nbsp; 
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:Label ID="lblSumTotalTime" runat="server" __designer:wfdid="w11"></asp:Label>
                    </FooterTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="70px" />
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemTemplate>
                        <asp:Label ID="lblTotalTime" runat="server" __designer:wfdid="w9"></asp:Label>
                    </ItemTemplate>
                    <FooterStyle HorizontalAlign="Center" Width="70px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Total Percentage" Visible="False">
                    <FooterTemplate>
                        <asp:Label ID="lblSumPercentage" runat="server" __designer:wfdid="w8"></asp:Label>
                    </FooterTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="55px" />
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemTemplate>
                        <asp:Label ID="lblPercentage" runat="server" __designer:wfdid="w6"></asp:Label>
                    </ItemTemplate>
                    <FooterStyle HorizontalAlign="Center" Width="55px" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemStyle HorizontalAlign="Center" Width="65px" />
                    <HeaderStyle HorizontalAlign="Center" />
                    <HeaderTemplate>
                        <asp:Label ID="lblApproved2" runat="server" Text='<%# ResourceHelper.GetFromResource("Approved") %>'></asp:Label>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:RadioButton ID="chkProjectManager" runat="server" GroupName="ProjectManager" __designer:wfdid="w20"></asp:RadioButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemStyle HorizontalAlign="Center" Width="65px" />
                    <HeaderStyle HorizontalAlign="Center" />
                    <HeaderTemplate>
                        <asp:Label ID="lblRejected2" runat="server" Text='<%# ResourceHelper.GetFromResource("Rejected") %>'></asp:Label>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:RadioButton ID="chkProjectManagerRejected" runat="server" GroupName="ProjectManager" __designer:wfdid="w21"></asp:RadioButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Approver's Comments %>">
                    <ItemStyle Width="250px" />
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemTemplate>
                        &nbsp;<asp:TextBox ID="ProjectManagerCommentsTextBox" runat="server" Width="91%" TextMode="MultiLine"
                            __designer:wfdid="w22" Height="45px" onkeyup="javascript:Check(this, 750);" onchange="javascript:Check(this, 750);"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="AccountEmployeeTimeEntryId" HeaderText="<%$ Resources:TimeLive.Resource, Id %>"
                    SortExpression="AccountEmployeeTimeEntryId" Visible="False" />
            </Columns>
        </x:GridView>
        &nbsp;
       
        <asp:LinkButton ID="CheckAllProjectManager" runat="server" CssClass="FeatureHeadingIcon"
            OnClientClick="ChangeAllCheckBoxStates2(true);" Visible="False">
            <asp:Literal ID="Literal10" runat="server" Text="<%$ Resources:TimeLive.Resource, Check-All Approved %> "></asp:Literal>
        </asp:LinkButton>
        <asp:LinkButton ID="UnCheckAllProjectMananger" runat="server" CssClass="FeatureHeadingIcon"
            OnClientClick="ChangeAllCheckBoxStates2(false);" Visible="False">
            <asp:Literal ID="Literal11" runat="server" Text="<%$ Resources:TimeLive.Resource, Uncheck-All Approved %> "></asp:Literal>
        </asp:LinkButton>
        <asp:ObjectDataSource ID="ApprovalEntriesForProjectManagerObject" runat="server"
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetApprovalEntriesForProjectManagerSummarize"
            TypeName="AccountEmployeeTimeEntryBLL">
            <SelectParameters>
                <asp:SessionParameter DefaultValue="39" Name="AccountEmployeeId" SessionField="AccountEmployeeId"
                    Type="Int32" />
                <asp:ControlParameter ControlID="ddlAccountEmployeeId" DefaultValue="39" Name="TimeEntryAccountEmployeeId"
                    PropertyName="SelectedValue" Type="Int32" />
                <asp:Parameter DefaultValue="11/02/2006" Name="TimeEntryStartDate" Type="DateTime" />
                <asp:Parameter DefaultValue="11/02/2006" Name="TimeEntryEndDate" Type="DateTime" />
                <asp:ControlParameter ControlID="chkIncludeDateRange" DefaultValue="0" Name="IncludeDateRange"
                    PropertyName="Checked" Type="Boolean" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </ContentTemplate>
</asp:UpdatePanel>
<br />
<asp:UpdatePanel ID="Updatepanel4" runat="server">
    <ContentTemplate>
        <x:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" Caption="<%$ Resources:TimeLive.Resource, Specific Employee Time Entry Approvals %>"
            DataKeyNames="TimeEntryAccountEmployeeId,TimeEntryStartDate,TimeEntryEndDate,TimeEntryDate,AccountEmployeeTimeEntryPeriodId,EmployeeName,TotalMinutes,EmailAddress,TimeEntryViewType,AccountProjectId,Percentage" DataSourceID="ApprovalEntriesForSpecificEmployeeObject"
            OnRowDataBound="GridView3_RowDataBound" ShowFooter="True"
            SkinID="xgridviewSkinEmployee" OnDataBound="GridView3_DataBound">
            <Columns>
                <asp:TemplateField SortExpression="EmployeeName" HeaderText="<%$ Resources:TimeLive.Resource, Employee Name %>">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" __designer:wfdid="w259" Text='<%# Bind("EmployeeName") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <HeaderTemplate>
                        <asp:LinkButton ID="LinkButton5" runat="server" Text='<%# ResourceHelper.GetFromResource("Employee Name") %>' CommandArgument="EmployeeName" CommandName="Sort" CausesValidation="False"></asp:LinkButton>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:HyperLink ID="lnkEmployeeName" onclick="window.open (this.href, 'popupwindow', 'width=1000,height=675,left=0,top=0,scrollbars=yes'); return false;" runat="server" __designer:wfdid="w258" Text='<%# Bind("EmployeeName") %>' NavigateUrl="~/Employee/AccountEmployeeTimeEntryWeekViewReadOnly.aspx"></asp:HyperLink>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Left" Width="320px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Timesheet Period %>">
                    <ItemStyle HorizontalAlign="Center" Width="100px" />
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" __designer:wfdid="w14" Text='<%# Format("{0:d}",Eval("TimeEntryStartDate")) %>'></asp:Label>&nbsp;-
                        <asp:Label ID="Label2" runat="server" __designer:wfdid="w15" Text='<%# Format("{0:d}",Eval("TimeEntryEndDate")) %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Billable Hours %>">
                    <FooterTemplate>
                        <asp:Label ID="lblSumBillableTime" runat="server" __designer:wfdid="w44"></asp:Label>
                    </FooterTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblBillableTime" runat="server" __designer:wfdid="w44"></asp:Label>
                    </ItemTemplate>
                    <FooterStyle HorizontalAlign="Center" Width="70px" />
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" Width="70px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Non-billable Hours %>">
                    <FooterTemplate>
                        <asp:Label ID="lblSumNonBillableTime" runat="server" __designer:wfdid="w44"></asp:Label>
                    </FooterTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblNonBillableTime" runat="server" __designer:wfdid="w44"></asp:Label>
                    </ItemTemplate>
                    <FooterStyle HorizontalAlign="Center" Width="98px" />
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" Width="98px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Total Hours %>">
                    <FooterTemplate>
                        <asp:Label ID="lblSumTotalTime" runat="server" __designer:wfdid="w14"></asp:Label>
                    </FooterTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblTotalTime" runat="server" __designer:wfdid="w12"></asp:Label>
                    </ItemTemplate>
                    <FooterStyle HorizontalAlign="Center" Width="70px" />
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" Width="70px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Total Percentage" Visible="False">
                    <FooterTemplate>
                        <asp:Label ID="lblSumPercentage" runat="server" __designer:wfdid="w8"></asp:Label>
                    </FooterTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="55px" />
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemTemplate>
                        <asp:Label ID="lblPercentage" runat="server" __designer:wfdid="w6"></asp:Label>
                    </ItemTemplate>
                    <FooterStyle HorizontalAlign="Center" Width="55px" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:RadioButton ID="chkSpecificEmployee" runat="server" GroupName="SpecificEmployee" __designer:wfdid="w53"></asp:RadioButton>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" />
                    <HeaderTemplate>
                        <asp:Label ID="lblApproved3" runat="server" Text='<%# ResourceHelper.GetFromResource("Approved") %>'></asp:Label>
                    </HeaderTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="65px" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:RadioButton ID="chkSpecificEmployeeRejected" runat="server" GroupName="SpecificEmployee" __designer:wfdid="w54"></asp:RadioButton>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" />
                    <HeaderTemplate>
                        <asp:Label ID="lblRejected3" runat="server" Text='<%# ResourceHelper.GetFromResource("Rejected") %>'></asp:Label>
                    </HeaderTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="65px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Approver's Comments %>">
                    <ItemStyle Width="250px" />
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemTemplate>
                        &nbsp;<asp:TextBox ID="SpecificEmployeeCommentsTextBox" runat="server" Width="91%" TextMode="MultiLine"
                            designer:wfdid="w1" Height="45px" onkeyup="javascript:Check(this, 750);" onchange="javascript:Check(this, 750);"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="AccountEmployeeTimeEntryId" HeaderText="AccountEmployeeTimeEntryId"
                    SortExpression="AccountEmployeeTimeEntryId" Visible="False" />
            </Columns>
        </x:GridView>
        &nbsp;
       
        <asp:LinkButton ID="CheckAllSpecificEmployee" runat="server" CssClass="FeatureHeadingIcon"
            OnClientClick="ChangeAllCheckBoxStates3(true);" Visible="False">
            <asp:Literal ID="Literal12" runat="server" Text="<%$ Resources:TimeLive.Resource, Check-All Approved%> "></asp:Literal>
        </asp:LinkButton>
        <asp:LinkButton ID="UnCheckAllSpecificEmployee" runat="server" CssClass="FeatureHeadingIcon"
            OnClientClick="ChangeAllCheckBoxStates3(false);" Visible="False">
            <asp:Literal ID="Literal13" runat="server" Text="<%$ Resources:TimeLive.Resource, Uncheck-All Approved%> "></asp:Literal>
        </asp:LinkButton>
        <asp:ObjectDataSource ID="ApprovalEntriesForSpecificEmployeeObject" runat="server"
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetApprovalEntriesForSpecificEmployeeSummarize"
            TypeName="AccountEmployeeTimeEntryBLL">
            <SelectParameters>
                <asp:SessionParameter DefaultValue="39" Name="AccountEmployeeId" SessionField="AccountEmployeeId"
                    Type="Int32" />
                <asp:ControlParameter ControlID="ddlAccountEmployeeId" DefaultValue="39" Name="TimeEntryAccountEmployeeid"
                    PropertyName="SelectedValue" Type="Int32" />
                <asp:Parameter DefaultValue="11/02/2006" Name="TimeEntryStartDate" Type="DateTime" />
                <asp:Parameter DefaultValue="11/02/2006" Name="TimeEntryEndDate" Type="DateTime" />
                <asp:ControlParameter ControlID="chkIncludeDateRange" DefaultValue="0" Name="IncludeDateRange"
                    PropertyName="Checked" Type="Boolean" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </ContentTemplate>
</asp:UpdatePanel>
<br />
<asp:UpdatePanel ID="UpdatePanel5" runat="server">
    <ContentTemplate>
        <x:GridView ID="GridView4" runat="server" AutoGenerateColumns="False" Caption='<%# ResourceHelper.GetFromResource("Specific External User Time Entry Approvals") %>'
            DataKeyNames="TimeEntryAccountEmployeeId,TimeEntryStartDate,TimeEntryEndDate,TimeEntryDate,AccountEmployeeTimeEntryPeriodId,EmployeeName,TotalMinutes,EmailAddress,TimeEntryViewType,AccountProjectId,Percentage"
            DataSourceID="dsApprovalEntriesForSpecificExternalUserObject"
            OnRowDataBound="GridView4_RowDataBound" ShowFooter="True"
            SkinID="xgridviewSkinEmployee" OnDataBound="GridView4_DataBound">
            <Columns>
                <asp:TemplateField SortExpression="EmployeeName" HeaderText="<%$ Resources:TimeLive.Resource, Employee Name %>">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" __designer:wfdid="w262" Text='<%# Bind("EmployeeName") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <HeaderTemplate>
                        <asp:LinkButton ID="LinkButton6" runat="server" Text='<%# ResourceHelper.GetFromResource("Employee Name") %>' CommandArgument="EmployeeName" CommandName="Sort" CausesValidation="False"></asp:LinkButton>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:HyperLink ID="lnkEmployeeName" onclick="window.open (this.href, 'popupwindow', 'width=1000,height=675,left=0,top=0,scrollbars=yes'); return false;" runat="server" __designer:wfdid="w261" Text='<%# Bind("EmployeeName") %>' NavigateUrl="~/Employee/AccountEmployeeTimeEntryWeekViewReadOnly.aspx"></asp:HyperLink>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Left" Width="320px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Timesheet Period %>">
                    <ItemStyle HorizontalAlign="Center" Width="100px" />
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" __designer:wfdid="w18" Text='<%# Format("{0:d}",Eval("TimeEntryStartDate")) %>'></asp:Label>&nbsp;-
                        <asp:Label ID="Label2" runat="server" __designer:wfdid="w19" Text='<%# Format("{0:d}",Eval("TimeEntryEndDate")) %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Billable Hours %>">
                    <FooterTemplate>
                        <asp:Label ID="lblSumBillableTime" runat="server" __designer:wfdid="w10"></asp:Label>
                    </FooterTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblBillableTime" runat="server" __designer:wfdid="w10"></asp:Label>
                    </ItemTemplate>
                    <FooterStyle HorizontalAlign="Center" Width="70px" />
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" Width="70px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Non-billable Hours %>">
                    <FooterTemplate>
                        <asp:Label ID="lblSumNonBillableTime" runat="server" __designer:wfdid="w10"></asp:Label>
                    </FooterTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblNonBillableTime" runat="server" __designer:wfdid="w10"></asp:Label>
                    </ItemTemplate>
                    <FooterStyle HorizontalAlign="Center" Width="98px" />
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" Width="98px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Total Hours %>">
                    <FooterTemplate>
                        <asp:Label ID="lblSumTotalTime" runat="server" __designer:wfdid="w17"></asp:Label>
                    </FooterTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblTotalTime" runat="server" __designer:wfdid="w15"></asp:Label>
                    </ItemTemplate>
                    <FooterStyle HorizontalAlign="Center" Width="70px" />
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" Width="70px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Total Percentage" Visible="False">
                    <FooterTemplate>
                        <asp:Label ID="lblSumPercentage" runat="server" __designer:wfdid="w8"></asp:Label>
                    </FooterTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="55px" />
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemTemplate>
                        <asp:Label ID="lblPercentage" runat="server" __designer:wfdid="w6"></asp:Label>
                    </ItemTemplate>
                    <FooterStyle HorizontalAlign="Center" Width="55px" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:RadioButton ID="chkSpecificExternalUser" runat="server" __designer:wfdid="w19" GroupName="SpecificExternalUser"></asp:RadioButton>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" />
                    <HeaderTemplate>
                        <asp:Label ID="lblApproved4" runat="server" Text='<%# ResourceHelper.GetFromResource("Approved") %>'></asp:Label>
                    </HeaderTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="65px" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:RadioButton ID="chkSpecificExternalUserRejected" runat="server" __designer:wfdid="w20" GroupName="SpecificExternalUser"></asp:RadioButton>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" />
                    <HeaderTemplate>
                        <asp:Label ID="lblRejected4" runat="server" Text='<%# ResourceHelper.GetFromResource("Rejected") %>'></asp:Label>
                    </HeaderTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="65px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Approver's Comments %>">
                    <ItemTemplate>
                        <asp:TextBox ID="SpecificExternalUserCommentsTextBox" runat="server" __designer:wfdid="w21"
                            TextMode="MultiLine" Width="91%" Height="45px" onkeyup="javascript:Check(this, 750);" onchange="javascript:Check(this, 750);"></asp:TextBox>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" Width="250px" />
                </asp:TemplateField>
                <asp:BoundField DataField="AccountEmployeeTimeEntryId" HeaderText="<%$ Resources:TimeLive.Resource, Id %>"
                    SortExpression="AccountEmployeeTimeEntryId" Visible="False" />
            </Columns>
        </x:GridView>
        &nbsp;
       
        <asp:LinkButton ID="CheckAllSpecificExternalUser" runat="server" CssClass="FeatureHeadingIcon"
            OnClientClick="ChangeAllCheckBoxStates4(true);" Visible="False">
            <asp:Literal ID="Literal14" runat="server" Text="<%$ Resources:TimeLive.Resource, Check-All Approved %> "></asp:Literal>
        </asp:LinkButton>
        <asp:LinkButton ID="UnCheckAllSpecificExternalUser" runat="server" CssClass="FeatureHeadingIcon"
            OnClientClick="ChangeAllCheckBoxStates4(false);" Visible="False">
            <asp:Literal ID="Literal15" runat="server" Text="<%$ Resources:TimeLive.Resource, Uncheck-All Approved %> "></asp:Literal>
        </asp:LinkButton>
        <asp:ObjectDataSource ID="dsApprovalEntriesForSpecificExternalUserObject" runat="server"
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetApprovalEntriesForSpecificExternalUserSummarize"
            TypeName="AccountEmployeeTimeEntryBLL">
            <SelectParameters>
                <asp:SessionParameter DefaultValue="39" Name="AccountEmployeeId" SessionField="AccountEmployeeId"
                    Type="Int32" />
                <asp:ControlParameter ControlID="ddlAccountEmployeeId" DefaultValue="39" Name="TimeEntryAccountEmployeeid"
                    PropertyName="SelectedValue" Type="Int32" />
                <asp:Parameter DefaultValue="11/02/2006" Name="TimeEntryStartDate" Type="DateTime" />
                <asp:Parameter DefaultValue="11/02/2006" Name="TimeEntryEndDate" Type="DateTime" />
                <asp:ControlParameter ControlID="chkIncludeDateRange" DefaultValue="0" Name="IncludeDateRange"
                    PropertyName="Checked" Type="Boolean" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </ContentTemplate>
</asp:UpdatePanel>
<br />
<asp:UpdatePanel ID="UpdatePanel6" runat="server">
    <ContentTemplate>
        <x:GridView ID="GridView5" runat="server" AutoGenerateColumns="False" Caption='<%# ResourceHelper.GetFromResource("Employee Manager Time Entry Approvals") %>'
            DataKeyNames="TimeEntryAccountEmployeeId,TimeEntryStartDate,TimeEntryEndDate,TimeEntryDate,AccountEmployeeTimeEntryPeriodId,EmployeeName,TotalMinutes,EmailAddress,TimeEntryViewType,AccountProjectId,Percentage" DataSourceID="dsApprovalEntriesForEmployeeManagerObject"
            OnRowDataBound="GridView5_RowDataBound" ShowFooter="True"
            SkinID="xgridviewSkinEmployee" OnDataBound="GridView5_DataBound">
            <Columns>
                <asp:TemplateField SortExpression="EmployeeName" HeaderText="<%$ Resources:TimeLive.Resource, Employee Name %>">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" __designer:wfdid="w265" Text='<%# Bind("EmployeeName") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <HeaderTemplate>
                        <asp:LinkButton ID="LinkButton7" runat="server" Text='<%# ResourceHelper.GetFromResource("Employee Name") %>' CommandArgument="EmployeeName" CommandName="Sort" CausesValidation="False"></asp:LinkButton>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:HyperLink ID="lnkEmployeeName" onclick="window.open (this.href, 'popupwindow', 'width=1000,height=675,left=0,top=0,scrollbars=yes'); return false;" runat="server" __designer:wfdid="w264" Text='<%# Bind("EmployeeName") %>' NavigateUrl="~/Employee/AccountEmployeeTimeEntryWeekViewReadOnly.aspx"></asp:HyperLink>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Left" Width="320px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Timesheet Period %>">
                    <ItemStyle HorizontalAlign="Center" Width="100px" />
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" __designer:wfdid="w22" Text='<%# Format("{0:d}",Eval("TimeEntryStartDate")) %>'></asp:Label>&nbsp;-
                        <asp:Label ID="Label2" runat="server" __designer:wfdid="w23" Text='<%# Format("{0:d}",Eval("TimeEntryEndDate")) %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Billable Hours %>">
                    <FooterTemplate>
                        <asp:Label ID="lblSumBillableTime" runat="server" __designer:wfdid="w30"></asp:Label>
                    </FooterTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblBillableTime" runat="server" __designer:wfdid="w30"></asp:Label>
                    </ItemTemplate>
                    <FooterStyle HorizontalAlign="Center" Width="70px" />
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" Width="70px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Non-billable Hours %>">
                    <FooterTemplate>
                        <asp:Label ID="lblSumNonBillableTime" runat="server" __designer:wfdid="w30"></asp:Label>
                    </FooterTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblNonBillableTime" runat="server" __designer:wfdid="w30"></asp:Label>
                    </ItemTemplate>
                    <FooterStyle HorizontalAlign="Center" Width="98px" />
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" Width="98px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Total Hours %>">
                    <FooterTemplate>
                        <asp:Label ID="lblSumTotalTime" runat="server" __designer:wfdid="w20"></asp:Label>
                    </FooterTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblTotalTime" runat="server" __designer:wfdid="w18"></asp:Label>
                    </ItemTemplate>
                    <FooterStyle HorizontalAlign="Center" Width="70px" />
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" Width="70px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Total Percentage" Visible="False">
                    <FooterTemplate>
                        <asp:Label ID="lblSumPercentage" runat="server" __designer:wfdid="w8"></asp:Label>
                    </FooterTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="55px" />
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemTemplate>
                        <asp:Label ID="lblPercentage" runat="server" __designer:wfdid="w6"></asp:Label>
                    </ItemTemplate>
                    <FooterStyle HorizontalAlign="Center" Width="55px" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:RadioButton ID="chkEmployeeManager" runat="server" GroupName="EmployeeManager" __designer:wfdid="w5"></asp:RadioButton>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" />
                    <HeaderTemplate>
                        <asp:Label ID="lblApproved5" runat="server" Text='<%# ResourceHelper.GetFromResource("Approved") %>'></asp:Label>
                    </HeaderTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="65px" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:RadioButton ID="chkEmployeeManagerRejected" runat="server" GroupName="EmployeeManager" __designer:wfdid="w9"></asp:RadioButton>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" />
                    <HeaderTemplate>
                        <asp:Label ID="lblRejected5" runat="server" Text='<%# ResourceHelper.GetFromResource("Rejected") %>'></asp:Label>
                    </HeaderTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="65px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Approver's Comments %>">
                    <ItemTemplate>
                        <asp:TextBox ID="EmployeeManagerCommentsTextBox" runat="server" Width="91%" TextMode="MultiLine"
                            __designer:wfdid="w10" Height="45px" onkeyup="javascript:Check(this, 750);" onchange="javascript:Check(this, 750);"></asp:TextBox>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" Width="250px" />
                </asp:TemplateField>
                <asp:BoundField DataField="AccountEmployeeTimeEntryId" HeaderText="<%$ Resources:TimeLive.Resource, Id %>"
                    SortExpression="AccountEmployeeTimeEntryId" Visible="False" />
            </Columns>
        </x:GridView>
        &nbsp;
       
        <asp:LinkButton ID="CheckAllEmployeeManager" runat="server" CssClass="FeatureHeadingIcon"
            OnClientClick="ChangeAllCheckBoxStates5(true);" Visible="False">
            <asp:Literal ID="Literal6" runat="server" Text="<%$ Resources:TimeLive.Resource, Check-All Approved %> "></asp:Literal>
        </asp:LinkButton>
        <asp:LinkButton ID="UnCheckAllEmployeeManager" runat="server" CssClass="FeatureHeadingIcon"
            OnClientClick="ChangeAllCheckBoxStates5(false);" Visible="False">
            <asp:Literal ID="Literal7" runat="server" Text="<%$ Resources:TimeLive.Resource, Uncheck-All Approved %> "></asp:Literal>
        </asp:LinkButton><asp:ObjectDataSource ID="dsApprovalEntriesForEmployeeManagerObject" runat="server"
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetApprovalEntriesForEmployeeManagerSummarize"
            TypeName="AccountEmployeeTimeEntryBLL">
            <FilterParameters>
                <asp:Parameter DefaultValue="39" Direction="Output" Name="AccountEmployeeId" Type="Int32" />
            </FilterParameters>
            <SelectParameters>
                <asp:SessionParameter DefaultValue="39" Name="AccountEmployeeId" SessionField="AccountEmployeeId"
                    Type="Int32" />
                <asp:ControlParameter ControlID="ddlAccountEmployeeId" DefaultValue="39" Name="TimeEntryAccountEmployeeId"
                    PropertyName="SelectedValue" Type="Int32" />
                <asp:Parameter DefaultValue="11/02/2006" Name="TimeEntryStartDate" Type="DateTime" />
                <asp:Parameter DefaultValue="11/02/2006" Name="TimeEntryEndDate" Type="DateTime" />
                <asp:ControlParameter ControlID="chkIncludeDateRange" DefaultValue="0" Name="IncludeDateRange"
                    PropertyName="Checked" Type="Boolean" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </ContentTemplate>
</asp:UpdatePanel>
<br />
<asp:UpdatePanel ID="UpdatePanel3" runat="server">
    <ContentTemplate>
        <x:GridView ID="GridView6" runat="server" AutoGenerateColumns="False" Caption="Specific Employee Time Off Approvals"
            DataKeyNames="AccountEmployeeTimeEntryId,AccountApprovalTypeId,AccountApprovalPathId,IsReject,IsApproved,AccountEmployeeId,ApprovalPathSequence,MaxApprovalPathSequence,AccountTimeOffTypeId,TotalMinutes,TimeEntryAccountEmployeeId,AccountEmployeeTimeEntryPeriodId"
            DataSourceID="dsApprovalEntriesForSpecificEmployeeForTimeOffObject" OnDataBound="GridView6_DataBound"
            OnRowDataBound="GridView6_RowDataBound" ShowFooter="True" SkinID="xgridviewSkinEmployee">
            <Columns>
                <asp:BoundField DataField="EmployeeName" HeaderText="Employee Name" SortExpression="EmployeeName" />
                <asp:BoundField DataField="TimeEntryDate" DataFormatString="{0:d}" HeaderText="Date"
                    HtmlEncode="False" HeaderStyle-HorizontalAlign="Center">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" Width="13px" />
                </asp:BoundField>
                <asp:BoundField DataField="AccountTimeOffType" HeaderText="Time Off Type" />
                <asp:BoundField DataField="Available" HeaderText="<%$ Resources:TimeLive.Resource, Available%> ">
                    <ItemStyle Width="3%" HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="Total Hours">
                    <FooterTemplate>
                        <asp:Label ID="lblSumTotalTime" runat="server" __designer:wfdid="w10"></asp:Label>
                    </FooterTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblTotalTime" runat="server" __designer:wfdid="w3"></asp:Label>
                    </ItemTemplate>
                    <FooterStyle HorizontalAlign="Center" Width="70px" />
                    <ItemStyle HorizontalAlign="Center" Width="70px" />
                </asp:TemplateField>
                <asp:BoundField DataField="Description" HeaderText="Description" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:RadioButton ID="chkSpecificEmployeeTimeOff" runat="server" __designer:wfdid="w8" GroupName="SpecificEmployeeTimeOff"></asp:RadioButton>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" />
                    <HeaderTemplate>
                        <asp:Label ID="lblApproved6" runat="server" Text='<%# ResourceHelper.GetFromResource("Approved") %>'></asp:Label>
                    </HeaderTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="70px" />

                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:RadioButton ID="chkSpecificEmployeeTimeOffRejected" runat="server" __designer:wfdid="w9" GroupName="SpecificEmployeeTimeOff"></asp:RadioButton>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" />
                    <HeaderTemplate>
                        <asp:Label ID="lblRejected6" runat="server" Text='<%# ResourceHelper.GetFromResource("Rejected") %>'></asp:Label>
                    </HeaderTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="70px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Comments">
                    <ItemTemplate>
                        <asp:TextBox ID="SpecificEmployeeTimeOffCommentsTextBox" runat="server" __designer:wfdid="w5"
                            TextMode="MultiLine" Width="93%" Height="45px"></asp:TextBox>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
            </Columns>
        </x:GridView>
        &nbsp;
       
        <asp:LinkButton ID="CheckAllSpecificEmployeeForTimeOff" runat="server" CssClass="FeatureHeadingIcon"
            OnClientClick="ChangeAllCheckBoxStates6(true);" Visible="False">
            <asp:Literal ID="Literal1" runat="server" Text="<%$ Resources:TimeLive.Resource, Check-All Approved %>"></asp:Literal>
        </asp:LinkButton>
        <asp:LinkButton ID="UnCheckAllSpecificEmployeeForTimeOff" runat="server" CssClass="FeatureHeadingIcon"
            OnClientClick="ChangeAllCheckBoxStates6(false);" Visible="False">
            <asp:Literal ID="Literal2" runat="server" Text="<%$ Resources:TimeLive.Resource, Uncheck-All Approved %>"></asp:Literal>
        </asp:LinkButton>
        <asp:ObjectDataSource ID="dsApprovalEntriesForSpecificEmployeeForTimeOffObject" runat="server"
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetApprovalEntriesSpecificEmployeeForTimeOff"
            TypeName="AccountEmployeeTimeEntryBLL">
            <FilterParameters>
                <asp:Parameter DefaultValue="39" Direction="Output" Name="AccountEmployeeId" Type="Int32" />
            </FilterParameters>
            <SelectParameters>
                <asp:SessionParameter DefaultValue="39" Name="AccountEmployeeId" SessionField="AccountEmployeeId"
                    Type="Int32" />
                <asp:ControlParameter ControlID="ddlAccountEmployeeId" DefaultValue="39" Name="TimeEntryAccountEmployeeId"
                    PropertyName="SelectedValue" Type="Int32" />
                <asp:Parameter DefaultValue="11/02/2006" Name="TimeEntryStartDate" Type="DateTime" />
                <asp:Parameter DefaultValue="11/02/2006" Name="TimeEntryEndDate" Type="DateTime" />
                <asp:ControlParameter ControlID="chkIncludeDateRange" DefaultValue="0" Name="IncludeDateRange"
                    PropertyName="Checked" Type="Boolean" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </ContentTemplate>
</asp:UpdatePanel>
<br />
<asp:UpdatePanel ID="UpdatePanel7" runat="server">
    <ContentTemplate>
         <x:GridView ID="GridView7" runat="server" AutoGenerateColumns="False" Caption="<%$ Resources: TimeLive.Resource, Project Manager Time Off Approvals%>"
            DataKeyNames="AccountEmployeeTimeEntryId,AccountApprovalTypeId,AccountApprovalPathId,IsReject,IsApproved,AccountEmployeeId,ApprovalPathSequence,MaxApprovalPathSequence,EmployeeManagerId,AccountTimeOffTypeId,TotalMinutes,TimeEntryAccountEmployeeId,AccountEmployeeTimeEntryPeriodId"
            DataSourceID="dsApprovalEntriesForProjectManagerForTimeOffObject" OnDataBound="GridView7_DataBound"
            OnRowDataBound="GridView7_RowDataBound" ShowFooter="True" SkinID="xgridviewSkinEmployee">
            <Columns>
                <asp:BoundField DataField="EmployeeName" HeaderText="Employee Name" SortExpression="EmployeeName" />
                <asp:BoundField DataField="TimeEntryDate" DataFormatString="{0:d}" HeaderText="Date"
                    HtmlEncode="False" HeaderStyle-HorizontalAlign="Center">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" Width="13px" />
                </asp:BoundField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:Label ID="ProjectNameLbl" runat="server" Text='<%# ResourceHelper.GetFromResource("Project Name") %>'></asp:Label>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="ProjectNameTxt" runat="server"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:BoundField DataField="AccountTimeOffType" HeaderText="Time Off Type" />

                <asp:TemplateField HeaderText="Total Hours">
                    <FooterTemplate>
                        <asp:Label ID="lblSumTotalTime" runat="server" __designer:wfdid="w14"></asp:Label>
                    </FooterTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="70px" />
                    <FooterStyle HorizontalAlign="Center" />
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemTemplate>
                        <asp:Label ID="lblTotalTime" runat="server" __designer:wfdid="w12"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Description" HeaderText="Description" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:RadioButton ID="chkEmployeeManagerTimeOff" runat="server" __designer:wfdid="w6" GroupName="EmployeeManagerTimeOff"></asp:RadioButton>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="65px" />
                    <HeaderStyle HorizontalAlign="Center" />
                    <HeaderTemplate>
                        <asp:Label ID="lblApproved7" runat="server" Text='<%# ResourceHelper.GetFromResource("Approved") %>'></asp:Label>
                    </HeaderTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:RadioButton ID="chkEmployeeManagerTimeOffRejected" runat="server" __designer:wfdid="w7" GroupName="EmployeeManagerTimeOff"></asp:RadioButton>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="65px" />
                    <HeaderStyle HorizontalAlign="Center" />
                    <HeaderTemplate>
                        <asp:Label ID="lblRejected7" runat="server" Text='<%# ResourceHelper.GetFromResource("Rejected") %>'></asp:Label>
                    </HeaderTemplate>
                </asp:TemplateField>
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
                <asp:TemplateField HeaderText="Comments">
                    <ItemTemplate>
                        <asp:TextBox ID="EmployeeManagerTimeOffCommentsTextBox" runat="server" TextMode="MultiLine" Width="93%"
                            __designer:wfdid="w8" Height="45px"></asp:TextBox>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
            </Columns>
        </x:GridView>
        &nbsp;
       
        <asp:LinkButton ID="CheckAllEmployeeManagerForTimeOff" runat="server" CssClass="FeatureHeadingIcon"
            OnClientClick="ChangeAllCheckBoxStates7(true);" Visible="False">
            <asp:Literal ID="Literal85" runat="server" Text="<%$ Resources:TimeLive.Resource, Check-All Approved %>"></asp:Literal>
        </asp:LinkButton>
        <asp:LinkButton ID="UnCheckAllEmployeeManagerForTimeOff" runat="server" CssClass="FeatureHeadingIcon"
            OnClientClick="ChangeAllCheckBoxStates7(false);" Visible="False">
            <asp:Literal ID="Literal37" runat="server" Text="<%$ Resources:TimeLive.Resource, Uncheck-All Approved %>"></asp:Literal>
        </asp:LinkButton>
        <asp:ObjectDataSource ID="dsApprovalEntriesForProjectManagerForTimeOffObject"
            runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetApprovalEntriesForProjectManagerTimeOff"
            TypeName="AccountEmployeeTimeEntryBLL">
            
            <SelectParameters>
                <asp:SessionParameter DefaultValue="39" Name="ProjectManagerId" SessionField="AccountEmployeeId"
                    Type="Int32" />
                <asp:ControlParameter ControlID="ddlAccountEmployeeId" DefaultValue="39" Name="TimeEntryAccountEmployeeId"
                    PropertyName="SelectedValue" Type="Int32" />
                <asp:Parameter DefaultValue="11/02/2006" Name="TimeEntryStartDate" Type="DateTime" />
                <asp:Parameter DefaultValue="11/02/2006" Name="TimeEntryEndDate" Type="DateTime" />
                <asp:ControlParameter ControlID="chkIncludeDateRange" DefaultValue="0" Name="IncludeDateRange"
                    PropertyName="Checked" Type="Boolean" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </ContentTemplate>
</asp:UpdatePanel>
