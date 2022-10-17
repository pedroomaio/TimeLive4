<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlTimeOffStatus.ascx.vb" Inherits="Employee_Controls_ctlTimeOffStatus" %>
<%@ Register Assembly="eWorld.UI.Compatibility, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2"
    Namespace="eWorld.UI.Compatibility" TagPrefix="cc1" %>

<style type="text/css">

    .underLine-Approved{
            box-shadow : #6CCF3A 0px -4px 0px 0px inset;
    }
       
    .underLine-Requested{
        box-shadow : #2AAAFF 0px -4px 0px 0px inset;
    }
    .underLine-Saved{
        box-shadow : Gold 0px -4px 0px 0px inset;
    }
</style>
<script type="text/javascript">
    var AVAILABLE_HIDDEN_ID = "#C_C_C_CtlTimeOffStatus1_GridView1_AvailableHidden_"
    var AVAILABLE_TEXTBOX_ID = "#C_C_C_CtlTimeOffStatus1_GridView1_AvailableTextBox_"
    var TOTAL_CONSUMED_ID = "#C_C_C_CtlTimeOffStatus1_GridView1_TotalConsumed_"
    var CARRY_FORWARD_ID = "#C_C_C_CtlTimeOffStatus1_GridView1_CarryForwardTextBox_"
    var EARNED_ID = "#C_C_C_CtlTimeOffStatus1_GridView1_EarnedTextBox_"

    function ChangedTextBoxFromEarned(element) {
            
        let carryF = $(GetElementToChangeID(CARRY_FORWARD_ID,element.id )).val()
        let consumedHours = $(GetElementToChangeID(TOTAL_CONSUMED_ID, element.id)).val()
        var available = parseInt(element.value) + parseInt(carryF) - parseInt(consumedHours)
        
        if (!isNaN(available)) {
            $(GetElementToChangeID(AVAILABLE_TEXTBOX_ID, element.id)).text(available )
            $(GetElementToChangeID(AVAILABLE_HIDDEN_ID, element.id)).val(available)
        }
    }

    function ChangedTextBoxFromCarryForward(element) {
        
        let earned = $(GetElementToChangeID(EARNED_ID, element.id)).val()
        let consumedHours = $(GetElementToChangeID(TOTAL_CONSUMED_ID, element.id)).val()
        var available = parseInt(earned) + parseInt(element.value) - parseInt(consumedHours)
        
        if (!isNaN(available)) {
            $(GetElementToChangeID(AVAILABLE_TEXTBOX_ID, element.id)).text(available)
            $(GetElementToChangeID(AVAILABLE_HIDDEN_ID, element.id)).val(available)
        }
            
    }

   
    function GetElementToChangeID(prefixe, id) {
        return prefixe + id.split("_")[6]

    }
    
</script>

<asp:UpdatePanel ID="UpdatePanel1" runat="server" >
    <ContentTemplate>
        <div class="fieldset" style="width: 96%; margin-left: 6px; height: 16px;" align="left">
            <table width="100%">
                <tr>
                    <td width="50px">
                        <asp:Label ID="Label15" runat="server" Text="<%$ Resources:TimeLive.Resource, Employee Name: %>"
                            Font-Bold="True" Font-Size="11px" Width="95px" CssClass="HighlightedText" />
                    </td>
                    <td>
                        <asp:Label ID="lblEmployeeName" runat="server" Text="<%$ Resources:TimeLive.Resource, Employee Name: %>"
                            Font-Size="11px" Width="80%" CssClass="HighlightedText" />
                    </td>
                </tr>
            </table>
        </div>
        <x:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Caption="<%$ Resources:TimeLive.Resource, Time Off Status %>"
            DataSourceID ="dsTimeOffStatusGridViewObject" Width="98%"
            SkinID="xgridviewSkinEmployee"
            DataKeyNames="AccountEmployeeTimeOffId,AccountTimeOffTypeId,AccountTimeOffPolicyId">
            <Columns>
                <asp:TemplateField SortExpression="AccountTimeOffType" HeaderText="<%$ Resources:TimeLive.Resource, Time Off Type%>" >
                    <ItemTemplate>
                        <asp:HyperLink ID="hlAccountTimeOffType" runat="server" Text='<%# Bind("AccountTimeOffType") %>' NavigateUrl='<%# Eval("AccountTimeOffTypeId", "~/Employee/AccountEmployeeTimeOffAudit.aspx?AccountTimeOffTypeId={0}&AccountEmployeeId=" & Me.Request.QueryString("AccountEmployeeId")) %>'></asp:HyperLink>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="30%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Earned Hours%> " ItemStyle-HorizontalAlign="Right" ItemStyle-VerticalAlign="Middle">
                    <ItemTemplate>
                        <asp:Label ID="lblEarned" runat="server"
                            Text='<%# Bind("Earned") %>'></asp:Label>
                        <asp:TextBox ID="EarnedTextBox" Text='<%# Bind("Earned") %>' runat="server"  onChange="javascript: ChangedTextBoxFromEarned(this)" Style="text-align: right;" Width="70%" __designer:wfdid="w15" Visible='<%# IIF(IsDBNull(Eval("AccountEmployeeTimeOffId")), "false", "true") %>'></asp:TextBox>
                        <asp:RangeValidator ID="RangeValidator2" runat="server" __designer:wfdid="w16" Display="Dynamic" CssClass="ErrorMessage" ControlToValidate="EarnedTextBox" Type="Integer" MinimumValue="-99999" MaximumValue="99999" ErrorMessage="Incorrect Value"></asp:RangeValidator>
                        
                    </ItemTemplate>
                    <ItemStyle Width="5%" />
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Carry Forward%> " ItemStyle-HorizontalAlign="Right" ItemStyle-VerticalAlign="Middle">
                    <ItemTemplate>
                        <asp:TextBox ID="CarryForwardTextBox" Text='<%# Bind("CarryForward") %>' runat="server" onChange="javascript: ChangedTextBoxFromCarryForward(this)" Style="text-align: right ;" Width="70%" __designer:wfdid="w15" Visible='<%# IIF(IsDBNull(Eval("AccountEmployeeTimeOffId")), "false", "true") %>'></asp:TextBox>
                        <asp:RangeValidator ID="RangeValidator3" runat="server" __designer:wfdid="w16" Display="Dynamic" CssClass="ErrorMessage" ControlToValidate="CarryForwardTextBox" Type="Integer" MinimumValue="-99999" MaximumValue="99999" ErrorMessage="Incorrect Value"></asp:RangeValidator>
                    </ItemTemplate>
                    <ItemStyle Width="5%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Saved Hours%> "  ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" HeaderStyle-CssClass ="underLine-Saved ">
                    <ItemTemplate>
                        <asp:Label ID="lblSaved" runat="server" Text='<%# Bind("SavedHours") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="5%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Submitted Hours%> " ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" HeaderStyle-CssClass ="underLine-Requested ">
                    <ItemTemplate>
                        <asp:Label ID="lblSubmitted" runat="server" Text='<%# Bind("RequestedHours") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="5%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Approved Hours %> "  ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" HeaderStyle-CssClass ="underLine-Approved ">
                    <ItemTemplate>
                        <asp:Label ID="lblApproved" runat="server" Text='<%# Bind("ApprovedHours") %>'></asp:Label>
                        <asp:HiddenField ID="ApprovedHidden"  runat="server" Value ='<%# Bind("ApprovedHours") %>'/>
                    </ItemTemplate>
                    <ItemStyle Width="5%" />
                </asp:TemplateField>
                 
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Total Form%> "  HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" >
                    <ItemTemplate>
                        <asp:Label ID="lblConsume" runat="server" Text='<%# Eval("SavedHours") + Eval("RequestedHours") + Eval("ApprovedHours")%> '></asp:Label>
                        <asp:HiddenField  ID="TotalConsumed" runat ="server"  Value ='<%# Eval("RequestedHours") + Eval("SavedHours") + Eval("ApprovedHours")  %>'/>
                    </ItemTemplate>
                    <ItemStyle Width="5%" />
                </asp:TemplateField>
               
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Available Form%> " ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" HeaderStyle-Width="10%">
                    <ItemTemplate>
                        <asp:Label ID="lblAvailable" runat="server" Text='<%# Bind("Available") %>'></asp:Label>
                        <asp:Label ID="AvailableTextBox" Text='<%# Bind("Available") %>' runat="server"  Style="text-align: center;" __designer:wfdid="w15" ReadOnly="true" Visible='<%# IIF(IsDBNull(Eval("AccountEmployeeTimeOffId")), "false", "true") %>'></asp:Label>
                        <asp:HiddenField runat="server" ID ="AvailableHidden" Value='<%# Bind("Available") %>'/>
                    </ItemTemplate>
                    <ItemStyle Width="5%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Last Earned Date%> ">

                    <ItemTemplate>
                        <asp:Label ID="lblLastEarnedDate" runat="server" Text='<%# Bind("LastEarnedDate", "{0:d}") %>' SelectedDate="LastEarnedDate"></asp:Label>

                        <cc1:CalendarPopup
                            ID="LastEarnedDateCalendarPopup" runat="server" Nullable="True" PostedDate=""
                            SkinID="DatePicker" Text="..." VisibleDate="" Width="64.5px">
                        </cc1:CalendarPopup>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="10%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Last Reset Date%>">
                    <ItemTemplate>
                        <asp:Label ID="lblLastResetDate" runat="server" Text='<%# Bind("LastResetDate", "{0:d}") %>' SelectedDate="LastResetDate"></asp:Label>
                        <cc1:CalendarPopup
                            ID="LastResetDateCalendarPopup" runat="server" Nullable="True" PostedDate=""
                            SkinID="DatePicker" Text="..." VisibleDate="" Width="64.5px">
                        </cc1:CalendarPopup>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="10%" />
                </asp:TemplateField>

            </Columns>
        </x:GridView>
        <asp:ObjectDataSource ID="dsTimeOffStatusGridViewObject" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetvueAccountEmployeeTimeOffByAccountEmployeeIdAndRequestRequired" TypeName="AccountEmployeeTimeOffBLL">
            <SelectParameters>
                <asp:QueryStringParameter Name="AccountEmployeeId" QueryStringField="AccountEmployeeId"
                    Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <br />
        &nbsp;<asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click"
            Text="<%$ Resources:TimeLive.Resource, Update Time Off%> "
            UseSubmitBehavior="False" />
        <%--<asp:Button ID="btnResetButton" runat="server" 
    Text="<%$ Resources:TimeLive.Resource, Reset Policy%> " OnClick="btnResetButton_Click" />--%>
        <asp:Button ID="btnEmployeeTimeOffAudit" runat="server"
            Text="<%$ Resources:TimeLive.Resource, Time Off Audit%> " OnClick="btnEmployeeTimeOffAudit_Click" />
        <%--  <asp:Button ID="btnEdit" runat="server" Text="Edit" />
        <asp:Button ID="btnCancel" runat="server" Text="Cancel" />--%>
    </ContentTemplate>
</asp:UpdatePanel>
