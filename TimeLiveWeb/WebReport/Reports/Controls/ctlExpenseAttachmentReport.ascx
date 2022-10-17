<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlExpenseAttachmentReport.ascx.vb" Inherits="WebReport_Reports_Controls_ctlExpenseAttachmentReport" %>
<div style=" vertical-align:top ">
<asp:DataList ID="ExpenseAttachmentRepeater" runat="server" RepeatDirection="Horizontal" RepeatColumns="1">
    <HeaderTemplate><table><tr></HeaderTemplate>
        <ItemTemplate>                     
                                     <td>  <asp:image id="img1" runat="server" Height="250px" widh="250px"></asp:image>
                                      
                                     
                                      <%--<asp:HyperLink id="img2" runat="server" Height="300px" widh="300px"></asp:HyperLink>--%>
                                      </td>
        </ItemTemplate>
                
    <FooterTemplate></tr>
                                      </table></FooterTemplate>
</asp:DataList>
  </div>