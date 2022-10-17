<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlTimeOffStatusReadOnly.ascx.vb" Inherits="Employee_Controls_ctlTimeOffStatusReadOnly" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <div id="timeOffStatusTable">
            <x:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Caption="<%$ Resources:TimeLive.Resource, Time Off Status %>"
                DataKeyNames="AccountEmployeeTimeOffId" 
                SkinID="xgridviewSkinEmployee" Width="1300px">
                <Columns>
                    <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Color%> " ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                        <ItemTemplate>
                            <asp:Panel ID="pnlColor" runat="server" BackColor='<%# UIUtilities.ConvertFromHexToColor(Eval("Color").ToString()) %>' style="width: 10px; height: 10px;"></asp:Panel>
                        </ItemTemplate>
                        <ItemStyle Width ="4%" />
                    </asp:TemplateField>

                    <asp:BoundField DataField="AccountTimeOffType" HeaderText="<%$ Resources:TimeLive.Resource, Time Off Type%> ">
                        <ItemStyle Width="10%" Wrap="false" />
                    </asp:BoundField>

                    <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Description %>" ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Middle" >
                        <ItemTemplate>
                            <asp:Label ID="lblDescription" runat="server" Text='<%# Bind("BriefExplanation") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="80%"  Wrap="false" />
                    </asp:TemplateField>
                    
              
                    <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Paid%>" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                        <ItemTemplate>
                            <asp:Label ID="lblPaid" runat="server" Text='<%# UIUtilities.ConvertFromBoolToString(Eval("Paid")) %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="7%" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, ScheduleWeekends%>" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                        <ItemTemplate>
                            <asp:Label ID="lblScheduleWeekends" runat="server" Text='<%# UIUtilities.ConvertFromBoolToString(Eval("ScheduleWeekends")) %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="7%"  />
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="   ">

                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Earned%> " ItemStyle-HorizontalAlign="Right" ItemStyle-VerticalAlign="Middle">
                        <ItemTemplate>
                            <asp:Label ID="lblEarned" runat="server" Text='<%# Bind("Earned") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="7%"  />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Carry Forward%> " ItemStyle-HorizontalAlign="Right" ItemStyle-VerticalAlign="Middle">
                        <ItemTemplate>
                            <asp:Label ID="lblCarryForward" runat="server" Text='<%# Bind("CarryForward") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="7%"  />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Scheduled (Saved)  %>" ItemStyle-HorizontalAlign="Right" ItemStyle-VerticalAlign="Middle" HeaderStyle-CssClass="underLine-Saved">
                        <ItemTemplate>
                            <asp:Label ID="lblSaved" runat="server" Text='<%# Bind("SavedHours") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="7%" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Scheduled (Submitted)  %>" ItemStyle-HorizontalAlign="Right" ItemStyle-VerticalAlign="Middle" HeaderStyle-CssClass="underLine-Requested">
                        <ItemTemplate>
                            <asp:Label ID="lblRequested" runat="server" Text='<%# Bind("RequestedHours") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="7%" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Scheduled (Approved) %> " ItemStyle-HorizontalAlign="Right" ItemStyle-VerticalAlign="Middle" HeaderStyle-CssClass ="underLine-Approved">
                        <ItemTemplate>
                            <asp:Label  ID="lblApproved" runat="server" Text='<%# Bind("ApprovedHours") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="7%"   />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Available%> " ItemStyle-HorizontalAlign="Right" ItemStyle-VerticalAlign="Middle">
                        <ItemTemplate>
                            <asp:Label ID="lblAvailable" runat="server" Text='<%# Bind("Available") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="7%" Font-Bold="true"/>
                    </asp:TemplateField>
                </Columns>
            </x:GridView>
        </div>
       
        <asp:ObjectDataSource ID="dsTimeOffStatusGridViewObject" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetvueAccountEmployeeTimeOffByAccountEmployeeIdAndRequestRequired" TypeName="AccountEmployeeTimeOffBLL">
            <SelectParameters>
                <asp:SessionParameter Name="AccountEmployeeId" SessionField="AccountEmployeeId" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>

         <asp:ObjectDataSource ID="dsTimeOffStatusGridViewObjectQueryString" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetvueAccountEmployeeTimeOffByAccountEmployeeIdAndRequestRequired" TypeName="AccountEmployeeTimeOffBLL">
            <SelectParameters>
                <asp:QueryStringParameter  Name="AccountEmployeeId" QueryStringField ="AccountEmployee" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>

    </ContentTemplate>
</asp:UpdatePanel>
