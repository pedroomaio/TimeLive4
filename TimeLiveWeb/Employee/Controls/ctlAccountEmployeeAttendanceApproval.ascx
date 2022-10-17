<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlAccountEmployeeAttendanceApproval.ascx.vb" Inherits="Employee_Controls_ctlAccountEmployeeAttendanceApproval" %>
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
    <table class="xFormView"><tr><td>
        <table width="600px" class="xFormView">
            <tr>
                <th colspan="2" class="caption">
                    <asp:Literal ID="Literal7" runat="server" Text="Attendance Approval"></asp:Literal></th>
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
                    <asp:Literal ID="Literal5" runat="server" Text="<%$ Resources:TimeLive.Resource, Include Date Range:%> "></asp:Literal></td>
                <td style="width: 250px">
                    <asp:CheckBox ID="chkIncludeDateRange" runat="server" /></td>
            </tr>
            <tr>
                <td style="width: 100px" align="right" class="FormViewLabelCell">
                    <asp:Literal ID="Literal2" runat="server" Text="<%$ Resources:TimeLive.Resource, Start Date:%> "></asp:Literal></td>
                </td>
                <td style="width: 250px">
                    <ew:CalendarPopup ID="txtStartDate" runat="server" Width="55px">
                    </ew:CalendarPopup>
                </td>
            </tr>
            <tr>
                <td style="width: 100px" align="right" class="FormViewLabelCell">
                    <asp:Literal ID="Literal3" runat="server" Text="<%$ Resources:TimeLive.Resource, End Date:%> "></asp:Literal></td>
                </td>
                <td style="width: 250px">
                    <ew:CalendarPopup ID="txtEndDate" runat="server" Width="55px">
                    </ew:CalendarPopup>
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 100px; height: 26px;" class="FormViewLabelCell">
                </td>
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
        <asp:ObjectDataSource ID="dsAttendanceApprovalEntriesForSpecificEmployee" runat="server"
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetvueAccountEmployeeAttendanceApprovalForSpecificEmployee"
            TypeName="AccountEmployeeAttendanceBLL">
            <SelectParameters>
                <asp:Parameter Name="AttendanceAccountEmployeeId" Type="Int32" />
                <asp:ControlParameter ControlID="chkIncludeDateRange" DefaultValue="0" Name="IncludeDateRange"
                    PropertyName="Checked" Type="Boolean" />
                <asp:Parameter DefaultValue="11/02/2006" Name="StartDate" Type="DateTime" />
                <asp:Parameter DefaultValue="11/02/2006" Name="EndDate" Type="DateTime" />
                <asp:SessionParameter DefaultValue="" Name="AccountEmployeeId" SessionField="AccountEmployeeId"
                    Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
        </ContentTemplate>
</asp:UpdatePanel>
<br />
&nbsp;<asp:Button ID="btnUpdate" runat="server" UseSubmitBehavior="False" Text="Update Attendance Approvals" /><br />
<br />
<asp:UpdatePanel ID="UpdatePanel2" runat="server">
    <ContentTemplate>
        <x:GridView ID="SpecificEmployeeGridView" runat="server" 
            AutoGenerateColumns="False" 
            DataSourceID="dsAttendanceApprovalEntriesForSpecificEmployee" Width="98%" 
            Caption="Specific Employee Attendance Approvals" 
            skinID="xgridviewSkinEmployee" 
            
            DataKeyNames="AccountApprovalTypeId,AccountApprovalPathId,AccountEmployeeId,IsRejected,IsApproved,ApprovalPathSequence,MaxApprovalPathSequence,AccountEmployeeAttendanceId">
            <Columns>
                <asp:BoundField DataField="FullName" HeaderText="<%$ Resources:TimeLive.Resource, Employee Name%> " SortExpression="FullName" >
                    <itemstyle width="23%" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Approved%> ">
                    <itemtemplate>
<asp:RadioButton id="rdSpecificEmployee" runat="server" __designer:wfdid="w10" GroupName="SpecificEmployee"></asp:RadioButton>
</itemtemplate>
                    <itemstyle width="5%" HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Rejected%> ">
                    <itemtemplate>
<asp:RadioButton id="rdSpecificEmployeeRejected" runat="server" __designer:wfdid="w11" GroupName="SpecificEmployee"></asp:RadioButton>
</itemtemplate>
                    <itemstyle width="5%" HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Comments%> ">
                    <itemtemplate>
<asp:TextBox id="CommentsTextBox" runat="server" Width="93%" TextMode="MultiLine" 
                            __designer:wfdid="w23" Height="45px"></asp:TextBox> 
</itemtemplate>
                    <itemstyle width="15%" />
                </asp:TemplateField>
            </Columns>
        </x:GridView>
                &nbsp;<asp:LinkButton ID="CheckAllSpecificEmployee" runat="server" CssClass="FeatureHeadingIcon"
            OnClientClick="ChangeAllCheckBoxStates1(true);" Visible="False">
            <asp:Literal ID="Literal10" runat="server" Text="<%$ Resources:TimeLive.Resource, Check-All Approved%> "></asp:Literal></asp:LinkButton>
        &nbsp;<asp:LinkButton
                ID="UnCheckAllSpecificEmployee" runat="server" CssClass="FeatureHeadingIcon" OnClientClick="ChangeAllCheckBoxStates1(false);"
                Visible="False">
                <asp:Literal ID="Literal11" runat="server" Text="<%$ Resources:TimeLive.Resource, Uncheck-All Approved%> "></asp:Literal></asp:LinkButton>
    </ContentTemplate>
</asp:UpdatePanel>
<br />
        <asp:ObjectDataSource ID="dsAttendanceApprovalEntriesForEmployeeManager" runat="server"
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetvueAccountEmployeeAttendanceApprovalForEmployeeManager"
            TypeName="AccountEmployeeAttendanceBLL">
            <SelectParameters>
                <asp:Parameter Name="AttendanceAccountEmployeeId" Type="Int32" />
                <asp:ControlParameter ControlID="chkIncludeDateRange" DefaultValue="0" Name="IncludeDateRange"
                    PropertyName="Checked" Type="Boolean" />
                <asp:Parameter DefaultValue="10/02/2005" Name="StartDate" Type="DateTime" />
                <asp:Parameter DefaultValue="10/02/2005" Name="EndDate" Type="DateTime" />
                <asp:SessionParameter DefaultValue="" Name="AccountEmployeeId" SessionField="AccountEmployeeId"
                    Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
<asp:UpdatePanel ID="UpdatePanel3" runat="server">
    <ContentTemplate>
        <x:GridView ID="EmployeeManagerGridView" runat="server" 
            AutoGenerateColumns="False" 
            DataSourceID="dsAttendanceApprovalEntriesForEmployeeManager" Width="98%" 
            Caption="Employee Manager Attendance Approvals" 
            skinID="xgridviewSkinEmployee" 
            
            
            DataKeyNames="AccountApprovalTypeId,AccountApprovalPathId,EmployeeManagerId,IsRejected,IsApproved,ApprovalPathSequence,MaxApprovalPathSequence,AccountEmployeeAttendanceId">
            <Columns>
                <asp:BoundField DataField="FullName" HeaderText="<%$ Resources:TimeLive.Resource, Employee Name%> " SortExpression="FullName" >
                    <itemstyle width="23%" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Approved%> ">
                    <itemtemplate>
<asp:RadioButton id="rdEmployeeManager" runat="server" __designer:wfdid="w20" GroupName="EmployeeManager"></asp:RadioButton> 
</itemtemplate>
                    <itemstyle width="5%" HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Rejected%> ">
                    <itemtemplate>
<asp:RadioButton id="rdEmployeeManagerRejected" runat="server" __designer:wfdid="w21" GroupName="EmployeeManager"></asp:RadioButton> 
</itemtemplate>
                    <itemstyle width="5%" HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Comments%> ">
                    <itemtemplate>
<asp:TextBox id="CommentsTextBox" runat="server" Width="91%" TextMode="MultiLine" 
                            __designer:wfdid="w22" Height="45px"></asp:TextBox> 
</itemtemplate>
                    <HeaderStyle HorizontalAlign="Center" />
                    <itemstyle width="15%" HorizontalAlign="Center" />
                </asp:TemplateField>
            </Columns>
        </x:GridView>
        &nbsp;
                <asp:LinkButton ID="CheckAllEmployeeManager" runat="server" CssClass="FeatureHeadingIcon"
            OnClientClick="ChangeAllCheckBoxStates2(true);" Visible="False">
            <asp:Literal ID="Literal8" runat="server" Text="<%$ Resources:TimeLive.Resource, Check-All Approved%> "></asp:Literal></asp:LinkButton>
        &nbsp;<asp:LinkButton
                ID="UnCheckAllEmployeeManager" runat="server" CssClass="FeatureHeadingIcon" OnClientClick="ChangeAllCheckBoxStates2(false);"
                Visible="False">
                <asp:Literal ID="Literal9" runat="server" Text="<%$ Resources:TimeLive.Resource, Uncheck-All Approved%> "></asp:Literal></asp:LinkButton>
    </ContentTemplate>
</asp:UpdatePanel>
<br />


       
