<%@ Control Language="VB" AutoEventWireup="false" EnableViewState="False" CodeFile="ctlAccountEmployeeTimeOffRequestApprovalDetailsReadOnly.ascx.vb" Inherits="Employee_Controls_ctlAccountEmployeeTimeOffRequestApprovalDetailsReadOnly" %>
<br />
<table class="xFormView" width="98%">
    <tr>
        <td>
            <table class="xFormView" width="100%" id="Name">
                <tr>
                    <th class="caption" colspan="3">
                        <asp:Literal ID="L" runat="server" Text="Time Off Request Approval Detail" /></th>
                </tr>                
                <tr>
                    <td align="right" class="HighlightedTextMedium" colspan="1" style="width: 15%">
                        <asp:Literal ID="Literal5" runat="server" Text="<%$ Resources:TimeLive.Resource, Time Off Type:%> " /></td>
                    <td align="left" class="HighlightedTextMedium" colspan="2" style="width: 85%">
                        <asp:Label ID="lblTimeOffType" runat="server" ForeColor="Black" Text="none"></asp:Label></td>
                </tr>
                <tr>
                    <td align="right" class="HighlightedTextMedium" colspan="1" style="width: 15%">
                        <asp:Literal ID="L2" runat="server" Text="<%$ Resources:TimeLive.Resource, Submitted By:%> " /></td>
                    <td align="left" class="HighlightedTextMedium" colspan="2" style="width: 85%">
                        <asp:Label ID="SB" runat="server" ForeColor="Black" Text="EmployeeName"></asp:Label></td>
                </tr>
                <tr>
                    <td align="right" class="HighlightedTextMedium" colspan="1" style="width: 15%">
                        <asp:Literal ID="L3" runat="server" Text="<%$ Resources:TimeLive.Resource, Submitted On:%> " /></td>
                    <td align="left" class="HighlightedTextMedium" colspan="2" style="width: 85%">
                        <asp:Label ID="LSO" runat="server" ForeColor="Black" Text="10/10/2010"></asp:Label></td>
                </tr>
                <tr>
                    <td align="right" class="HighlightedTextMedium" colspan="1" style="width: 15%">
                        <asp:Literal ID="Literal1" runat="server" Text="<%$ Resources:TimeLive.Resource, Hours Off:%> " /></td>
                    <td align="left" class="HighlightedTextMedium" colspan="2" style="width: 85%">
                        <asp:Label ID="lblHoursOff" runat="server" ForeColor="Black" Text="0"></asp:Label></td>
                </tr>
                <tr>
                    <td align="right" class="HighlightedTextMedium" colspan="1" style="width: 15%">
                        <asp:Literal ID="Literal2" runat="server" Text="<%$ Resources:TimeLive.Resource, Days Off:%> " /></td>
                    <td align="left" class="HighlightedTextMedium" colspan="2" style="width: 85%">
                        <asp:Label ID="lblDaysOff" runat="server" ForeColor="Black" Text="0"></asp:Label></td>
                </tr>
                <tr>
                    <td align="right" class="HighlightedTextMedium" colspan="1" style="width: 15%">
                        <asp:Literal ID="Literal3" runat="server" Text="<%$ Resources:TimeLive.Resource, Time Off Start Date:%> " /></td>
                    <td align="left" class="HighlightedTextMedium" colspan="2" style="width: 85%">
                        <asp:Label ID="lblStartDate" runat="server" ForeColor="Black" Text="10/10/2010"></asp:Label></td>
                </tr>
                <tr>
                    <td align="right" class="HighlightedTextMedium" colspan="1" style="width: 15%">
                        <asp:Literal ID="Literal4" runat="server" Text="<%$ Resources:TimeLive.Resource, Time Off End Date:%> " /></td>
                    <td align="left" class="HighlightedTextMedium" colspan="2" style="width: 85%">
                        <asp:Label ID="lblEndDate" runat="server" ForeColor="Black" Text="10/10/2010"></asp:Label></td>
                </tr>
                <tr>
                    <td colspan="3">
                        <div style="margin: 0px 0px 0px -5px;">
                            <x:GridView ID="A" runat="server" SkinID="xgridviewSkinEmployee" DataSourceID="dsAccountEmployeeTimeOffRequestApprovalDetailsReadOnly" AutoGenerateColumns="False"
                                Width="100%">
                                <Columns>
                                    <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Approver Name %>">
                                        <EditItemTemplate>
                                            <asp:Label ID="Label19" Text='<%# Eval("ApproverName") %>' runat="server" __designer:wfdid="w2"></asp:Label>
                                        </EditItemTemplate>
                                        <HeaderTemplate>
                                            <asp:Label ID="AN" Text='<%# ResourceHelper.GetFromResource("Approver Name") %>' runat="server" __designer:wfdid="w3"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="N" Text='<%# IIF(IsDBNULL(Eval("Approvername")),"System",Eval("ApproverName") & " - " & Eval("SystemApproverType")) %>' runat="server" __designer:wfdid="w1"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle VerticalAlign="Middle" Width="25%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Approved On %>">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TtBox1" Text='<%# Bind("ApprovedOn") %>' runat="server" __designer:wfdid="w5"></asp:TextBox>
                                        </EditItemTemplate>
                                        <HeaderTemplate>
                                            <asp:Label ID="LABEL1" Text='<%# ResourceHelper.GetFromResource("Approved On") %>' runat="server" __designer:wfdid="w6"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="A" Text='<%# IIf(IsDBNULL(Eval("ApprovedOn")),String.Format("{0:d}",Eval("RequestSubmitDate")),String.Format("{0:d}",Eval("ApprovedOn"))) %>' runat="server" __designer:wfdid="w4"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="12%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Status %>">
                                        <HeaderTemplate>
                                            <asp:Label ID="lblStatus" Text='<%# ResourceHelper.GetFromResource("Status") %>' runat="server" __designer:wfdid="w8"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="S" runat="server" __designer:wfdid="w7"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="8%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Comments %>">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox2" Text='<%# Bind("Comments") %>' runat="server" __designer:wfdid="w10"></asp:TextBox>
                                        </EditItemTemplate>
                                        <HeaderTemplate>
                                            <asp:Label ID="lblComments" Text='<%# ResourceHelper.GetFromResource("Comments") %>' runat="server" __designer:wfdid="w11"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="C" Text='<%# Bind("Comments") %>' runat="server" __designer:wfdid="w9"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle VerticalAlign="Middle" Width="30%" />
                                    </asp:TemplateField>
                                </Columns>
                            </x:GridView>
                        </div>
                </tr>
            </table>
        </td>
    </tr>
</table>
<asp:ObjectDataSource ID="dsAccountEmployeeTimeOffRequestApprovalDetailsReadOnly"
    runat="server" OldValuesParameterFormatString="original_{0}"
    SelectMethod="GetvueAccountEmployeeTimeOffRequestApprovalDetailbyAccountEmployeeTimeOffRequestId"
    TypeName="AccountEmployeeTimeOffRequestBLL">
    <SelectParameters>
        <asp:QueryStringParameter DbType="Guid" Name="AccountEmployeeTimeOffRequestId"
            QueryStringField="AccountEmployeeTimeOffRequestId" />
    </SelectParameters>
</asp:ObjectDataSource>
<br />
