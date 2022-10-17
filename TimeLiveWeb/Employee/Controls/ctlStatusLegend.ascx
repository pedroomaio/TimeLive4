<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlStatusLegend.ascx.vb" Inherits="Employee_Controls_ctlStatusLegend" %>
<table class="xStatusLegend" ><tr style="height:2.5px"><td>
<table width="100%" class="xStatusLegend">

    <tr>
        <th class="FormViewSubHeader" colspan="11">
        <asp:Literal ID="Literal3" runat="server" Text="<%$ Resources:TimeLive.Resource, Status Legend%> "></asp:Literal>
        </th><td valign="bottom">&nbsp;</td>
                <td valign="bottom" style="margin-right: 6px">
            <asp:Image ID="Image1" runat="server" ImageAlign="AbsBottom" AlternateText="" ImageUrl="~/Images/NotSubmittedStatus.gif"
                Width="10px"/></td> 
                       
        <td  style="font-weight: bold; width: 100px">
            <asp:Literal ID="Literal1" runat="server" Text="<%$ Resources:TimeLive.Resource, Not Submitted%> "></asp:Literal></td>        

                        <td valign="bottom">
            <asp:Image ID="Image2" runat="server" ImageAlign="AbsBottom" AlternateText="" ImageUrl="~/Images/SubmittedStatus.gif"
                Width="10px" /></td>

        <td style="font-weight: bold; width: 70px">
            <asp:Literal ID="Literal2" runat="server" Text="<%$ Resources:TimeLive.Resource, Submitted%> "></asp:Literal></td>

        <td valign="bottom">
            <asp:Image ID="Image5" runat="server" ImageAlign="AbsBottom" AlternateText="" ImageUrl="~/Images/ApprovedStatus.gif"
                Width="10px" /></td>

        <td style="font-weight: bold; width: 65px">
            <asp:Literal ID="Literal4" runat="server" Text="<%$ Resources:TimeLive.Resource, Approved%> "></asp:Literal></td>

        <td valign="bottom">
            <asp:Image ID="Image6" runat="server" ImageAlign="AbsBottom" AlternateText="" ImageUrl="~/Images/RejectedStatus.gif"
                Width="10px" /></td>

        <td style="font-weight: bold; width: 55px">
            <asp:Literal ID="Literal5" runat="server" Text="<%$ Resources:TimeLive.Resource, Rejected%> "></asp:Literal></td>                
    </tr>
</table>
</td></tr></table>