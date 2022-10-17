<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlAccountReportsList.ascx.vb" Inherits="AccountAdmin_Controls_ctlAccountReportsList" %>

<style>
    .SetAllActive {
    float:right;
    margin-right: 115px;
}
</style>

 <ContentTemplate>

        <x:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="AccountReportId"
            DataSourceID="dsReportTableObject" SkinID="xgridviewSkinEmployee" AllowSorting="True" Width="90%" Caption='<%# ResourceHelper.GetFromResource("Report List") %>' CssClass="tableView">
            <Columns>

                <asp:TemplateField HeaderText="Report Category">
            <EditItemTemplate>
                <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("AccountReportCategory") %>'
                    ></asp:TextBox></EditItemTemplate>
            <HeaderTemplate>
                <asp:LinkButton ID="LinkButton5" runat="server" Text="Report Category"
                    CommandArgument="AccountReportCategory" CommandName="Sort" CausesValidation="False"></asp:LinkButton></HeaderTemplate>
            <ItemTemplate>
                <asp:Label ID="Label4" runat="server" Text='<%# Bind("AccountReportCategory") %>'
                    ></asp:Label></ItemTemplate>
            <ItemStyle Font-Bold="False" HorizontalAlign="Center" Width="20%" />
        </asp:TemplateField>



                <asp:TemplateField HeaderText="Report Name">
            <EditItemTemplate>
                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("ReportName") %>'
                    ></asp:TextBox></EditItemTemplate>
            <HeaderTemplate>
                <asp:LinkButton ID="LinkButton4" runat="server" Text="Report Name"
                    CommandArgument="ReportName" CommandName="Sort" CausesValidation="False"></asp:LinkButton></HeaderTemplate>
            <ItemTemplate>
                <asp:Label ID="Label3" runat="server" Text='<%# Bind("ReportName") %>'
                    ></asp:Label></ItemTemplate>
            <ItemStyle Font-Bold="False" HorizontalAlign="Center" Width="20%" />
        </asp:TemplateField>

          <asp:TemplateField HeaderText="Active">
                 <ItemTemplate>
                     <asp:CheckBox id="visible_chkbox" runat="server" Checked='<%# IIf(Eval("Visible") = True, True, False) %>'></asp:CheckBox> 
                 </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="10%" />
                </asp:TemplateField>

            </Columns>
        </x:GridView>

                   <div style="margin:5px;">
        <asp:Button ID="Update_bt" runat="server" Text="Update" OnClick="Update_bt_Click"/>
        <asp:LinkButton ID="ActiveAll" runat="server" Text='Set all to "Active"' CssClass="SetAllActive" OnClick="ActiveAll_Click"></asp:LinkButton>
                  </div>
        </td>
        <asp:ObjectDataSource ID="dsReportTableObject" runat="server"
            OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetDataForMyReportGrid" TypeName="TimeLive.WebReport.ReportDesignBLL" >
            <SelectParameters>
                <asp:SessionParameter DefaultValue="<%=DBUtilities.GetSessionAccountId() %>" Name="AccountId" SessionField="AccountId"
                    Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </ContentTemplate>
</asp:UpdatePanel>