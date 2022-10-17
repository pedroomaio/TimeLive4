<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlQboOnline.ascx.vb" Inherits="QBO_Controls_ctlQboOnline" %>
  <table class="xFormView"><tr><td>
<table style="width: 600px" class="xFormView" >
    <tr><th class="caption" colspan="4" style="height: 21px"><asp:Literal ID="Literal9" runat="server" Text='<%# ResourceHelper.GetFromResource("CSV Import Export")%> ' /></th></tr>
    <tr>
        <td style="width: 150px" align="right">
            <asp:Literal ID="Literal1" runat="server" Text='<%# ResourceHelper.GetFromResource("Import / Export")%> ' /></td>
        <td style="width: 80px">
            <asp:RadioButton ID="radExport" runat="server" AutoPostBack="True" GroupName="ImportExport"
                Text='<%# ResourceHelper.GetFromResource("Export")%> ' />
            </td>                    
        <td style="width: 150px">
            <asp:RadioButton ID="radImport" runat="server" AutoPostBack="True"
                    GroupName="ImportExport" Text='<%# ResourceHelper.GetFromResource("Import")%> ' /></td>                    
        <td style="width: 425px">
            &nbsp;</td>                    
    </tr>
   
    <tr>
        <td style="width: 150px" align="right">
        </td>
        <td style="width: 425px" colspan="3">
        </td>
    </tr>
</table>
</td></tr></table>