<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlAccountTerminologyList.ascx.vb" Inherits="AccountAdmin_Controls_ctlAccountTerminologyList" %>
<style type="text/css">
    .style1
    {
        width: 100%;
    }
</style>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <x:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="dsAccountTerminologyGridViewObject"
            Width="98%" SkinID="xgridviewSkinEmployee" 
            Caption='<%# ResourceHelper.GetFromResource("Manage Terminology") %>' 
            DataKeyNames="AccountTerminologyId,UserDefinedName">
            <Columns>
                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Terminology Name %>" >
                    <edititemtemplate>
<asp:TextBox id="TerminologyNameTextBox" runat="server" Width="98%" __designer:wfdid="w14"></asp:TextBox> 
</edititemtemplate>
                    <itemtemplate>
<asp:TextBox id="TerminologyNameTextBox" runat="server" Width="98%" __designer:wfdid="w13"></asp:TextBox> 
</itemtemplate>
                    <ItemStyle Width="48.5%" HorizontalAlign="Center" />
                </asp:TemplateField>
<asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, User Defined Name %>"><ItemTemplate>
<asp:TextBox id="UserDefinedNameTextBox" runat="server" Width="98%" 
        Text='<%# IIF(IsDBNULL(Eval("AccountTerminologyId")) orelse Eval("AccountTerminologyId")=0,Nothing,Eval("UserDefinedName")) %>' 
        __designer:wfdid="w5"></asp:TextBox><BR /><asp:Label id="lblException" runat="server" __designer:wfdid="w6" Visible="False" CssClass="ErrorMessage"></asp:Label> 
</ItemTemplate>
    <ItemStyle Width="48.5%" />
</asp:TemplateField>
<asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Selected %>">
<ItemTemplate>
<asp:CheckBox id="chkSelect" runat="server" __designer:wfdid="w10" Checked='<%# IIF(IsDBNULL(Eval("AccountTerminologyId")) orelse Eval("AccountTerminologyId")=0,False,True) %>'></asp:CheckBox> 
</ItemTemplate>
    <itemstyle horizontalalign="Center" verticalalign="Middle" Width="1%" />
</asp:TemplateField>
</Columns>
        </x:GridView>
        <table>
            <tr>
                <td style="padding-top:7px;">
                    &nbsp;<asp:Button ID="btnUpdate" runat="server" 
                        Text="<%$ Resources:TimeLive.Resource, Update_text%>" Width="79px" />
                </td>
            </tr>
        </table>
        <asp:ObjectDataSource ID="dsAccountTerminologyGridViewObject" runat="server" 
            OldValuesParameterFormatString="original_{0}" 
            SelectMethod="GetTerminologiesByAccountId" TypeName="AccountTerminologyBLL">
            <SelectParameters>
                <asp:SessionParameter Name="AccountId" SessionField="AccountId" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </ContentTemplate>
</asp:UpdatePanel>
