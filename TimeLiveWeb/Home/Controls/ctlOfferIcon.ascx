<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlOfferIcon.ascx.vb" Inherits="Home_Controls_ctlOfferIcon" %>
<table border="0" cellpadding="0" cellspacing="0" width=190px align=center class="BlockTable" >
 

    <tr>
        <td style="width: 40px" valign="top" class=block>
            <asp:Image ID="Image12" runat="server" ImageUrl="~/Images/TimeManagement3232.gif" AlternateText="<%$ Resources:TimeLive.Resource, Time Sheet%> " /></td>
        <td style="width: 318px" class="Block" valign="top" >
            <asp:HyperLink ID="HyperLink1" NavigateUrl="http://www.livetecs.com/Home/Features.aspx" runat="server" CssClass="FeatureHeadingIcon"><asp:Literal ID="Literal15" runat="server" Text="<%$ Resources:TimeLive.Resource, Time Sheet%> " /></asp:HyperLink><br />
            <asp:Literal ID="Literal1" runat="server" Text="<%$ Resources:TimeLive.Resource, Integrated timesheet in both hosted and downloadable version%> " /></td>
            </tr>
    
    
    <tr height=10px bgcolor=white>
        <td></td>
        <td valign="top"></td>
    </tr>
        
        <tr>
        <td style="width: 40px" valign="top" class=block>
            <asp:Image ID="Image14" runat="server" ImageUrl="~/Images/Expenses3232.gif" AlternateText="<%$ Resources:TimeLive.Resource, Employee Attendance%> " /></td>
        <td style="width: 318px" class="Block" valign="top" >
            <asp:HyperLink ID="HyperLink14" NavigateUrl="http://www.livetecs.com/Home/Features.aspx" runat="server" CssClass="FeatureHeadingIcon"><asp:Literal ID="Literal16" runat="server" Text="<%$ Resources:TimeLive.Resource, Employee Attendance%> " /></asp:HyperLink><br />
            <asp:Literal ID="Literal2" runat="server" Text="<%$ Resources:TimeLive.Resource, Single tool to monitor employee attendance offdays vacation leave%> " /></td>
            </tr>
    
        <tr height=10px bgcolor=white>
        <td></td>
        <td valign="top"></td>
    </tr>
    
        
     <tr>
        <td style="width: 40px" valign="top" class=block>
            <asp:Image ID="Image15" runat="server" ImageUrl="~/Images/ExpenseManagement3232.gif" AlternateText="<%$ Resources:TimeLive.Resource, Expense Management%> " /></td>
        <td style="width: 318px" class="Block" valign="top" >
            <asp:HyperLink ID="HyperLink15" NavigateUrl="http://www.livetecs.com/Home/Features.aspx" runat="server" CssClass="FeatureHeadingIcon"><asp:Literal ID="Literal17" runat="server" Text="<%$ Resources:TimeLive.Resource, Expense Management%> " /></asp:HyperLink><br />
            <asp:Literal ID="Literal3" runat="server" Text="<%$ Resources:TimeLive.Resource, Integrated module to record track and monitor project expenses%> " /></td>
            </tr>
    
  
    
    <tr height=10px bgcolor=white>
        <td></td>
        <td valign="top"></td>
    </tr>
    
        
        <tr>
        <td style="width: 40px" valign="top" class=block>
            <asp:Image ID="Image16" runat="server" ImageUrl="~/Images/ProjectManagement3232.gif" AlternateText="<%$ Resources:TimeLive.Resource, Project Management%> " /></td>
        <td style="width: 318px" class="Block" valign="top" >
            <asp:HyperLink ID="HyperLink16" NavigateUrl="http://www.livetecs.com/Home/Features.aspx" runat="server" CssClass="FeatureHeadingIcon"><asp:Literal ID="Literal18" runat="server" Text="<%$ Resources:TimeLive.Resource, Project Management%> " /></asp:HyperLink><br />
            <asp:Literal ID="Literal4" runat="server" Text="<%$ Resources:TimeLive.Resource, Integrated module to manage your projects tasks within same integrated tool.%> " /></td>
            </tr>
    
    
    <tr height=10px bgcolor=white>
        <td></td>
        <td valign="top"></td>
    </tr>            

    <tr>
        <td style="width: 40px" valign="top" class=block>
            <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/windows.gif" AlternateText="<%$ Resources:TimeLive.Resource, Windows Based%> " /></td>
        <td style="width: 318px" class="Block" valign="top" >
            <asp:HyperLink ID="HyperLink12" NavigateUrl="http://www.livetecs.com/Home/Features.aspx" runat="server" CssClass="FeatureHeadingIcon"><asp:Literal ID="Literal19" runat="server" Text="<%$ Resources:TimeLive.Resource, Windows Based%> " /></asp:HyperLink><br />
            <asp:Literal ID="Literal5" runat="server" Text="<%$ Resources:TimeLive.Resource, Windows based installable on server and local system%> " /></td>
            </tr>
    
    
    <tr height=10px bgcolor=white>
        <td></td>
        <td valign="top"></td>
    </tr>
   
    
    <tr>
        <td style="width: 1px" valign="top" class=block>
            <asp:Image ID="Image2" runat="server" ImageUrl="~/Images/domain.gif" AlternateText="<%$ Resources:TimeLive.Resource, Hosted Solution (ASP)%> " /></td>
        <td style="width: 218px" class=block valign="top" >
             <asp:HyperLink ID="HyperLink2" NavigateUrl="http://www.livetecs.com/Home/Features.aspx" runat="server" CssClass="FeatureHeadingIcon"><asp:Literal ID="Literal20" runat="server" Text="<%$ Resources:TimeLive.Resource, Hosted Solution (ASP)%> " /></asp:HyperLink><br />
            <asp:Literal ID="Literal6" runat="server" Text="<%$ Resources:TimeLive.Resource, Web based fully hosted solution (ASP Based)%> " /></td>
            </td>
    </tr>
    
    <tr height=10px bgcolor=white>
        <td></td>
        <td valign="top"></td>
    </tr>
    
    <tr>
        <td style="width: 1px" valign="top"  class=block >
            <asp:Image ID="Image3" runat="server" ImageUrl="~/Images/Downloadable.gif" AlternateText="<%$ Resources:TimeLive.Resource, Downloadable%> " /></td>
        <td style="width: 218px" class="block" valign="top">
            <asp:HyperLink ID="HyperLink3" NavigateUrl="http://www.livetecs.com/Home/Features.aspx" runat="server" CssClass="FeatureHeadingIcon"><asp:Literal ID="Literal21" runat="server" Text="<%$ Resources:TimeLive.Resource, Downloadable%> " /></asp:HyperLink><br />
            <asp:Literal ID="Literal7" runat="server" Text="<%$ Resources:TimeLive.Resource, Fully downloadable on local server or individual system for single user.%> " /></td>
            </tr>
     <tr height=10px bgcolor=white>
        <td></td>
        <td valign="top"></td>
    </tr>
    <tr>
        <td style="width: 1px" valign="top"  class=block>
            <asp:Image ID="Image4" runat="server" ImageUrl="~/Images/2472.gif" AlternateText="<%$ Resources:TimeLive.Resource, Buy Tracking%> " /></td>
        <td style="width: 218px" class="block" valign="top">
            <asp:HyperLink ID="HyperLink4" NavigateUrl="http://www.livetecs.com/Home/Features.aspx" runat="server" CssClass="FeatureHeadingIcon"><asp:Literal ID="Literal22" runat="server" Text="<%$ Resources:TimeLive.Resource, 24x7 Customer Support%> " /></asp:HyperLink><br />
            <asp:Literal ID="Literal8" runat="server" Text="<%$ Resources:TimeLive.Resource, Expert technical support at any hour via email.%> " /></td>
            </tr>
    <tr height=10px bgcolor=white>
        <td></td>
        <td valign="top"></td>
    </tr>
    <tr>
        <td style="width: 1px" valign="top"  class=block>
            <asp:Image ID="Image5" runat="server" ImageUrl="~/Images/cp2.gif" Width="32px" AlternateText="<%$ Resources:TimeLive.Resource, Time Sheet%> " /></td>
        <td style="width: 218px" class="block" valign="top">
            <asp:HyperLink ID="HyperLink5" NavigateUrl="http://www.livetecs.com/Home/Features.aspx" runat="server" CssClass="FeatureHeadingIcon"><asp:Literal ID="Literal23" runat="server" Text="<%$ Resources:TimeLive.Resource, Instant Setup%> " /></asp:HyperLink><br />
            <asp:Literal ID="Literal9" runat="server" Text="<%$ Resources:TimeLive.Resource, Both downloadable version and hosted version can be setup instantly.%> " /></td>
            </tr>
    <tr height=10px bgcolor=white>
        <td></td>
        <td valign="top"></td>
    </tr>
    <tr>
        <td style="width: 1px" valign="top"  class=block>
            <asp:Image ID="Image6" runat="server" ImageUrl="~/Images/mail.gif" Width="32px" AlternateText="<%$ Resources:TimeLive.Resource, Time Sheet%> " />
        </td>
        <td style="width: 218px" class="block" valign="top">
            <asp:HyperLink ID="HyperLink6" NavigateUrl="http://www.livetecs.com/Home/Features.aspx" runat="server" CssClass="FeatureHeadingIcon"><asp:Literal ID="Literal24" runat="server" Text="<%$ Resources:TimeLive.Resource, EMail Notification%> " /></asp:HyperLink><br />
            <asp:Literal ID="Literal10" runat="server" Text="<%$ Resources:TimeLive.Resource, Notification of events / reports via email in order to update users without signing in system%> " /></td>
            </td>
    </tr>
    <tr height=10px bgcolor=white>
        <td></td>
        <td valign="top"></td>
    </tr>

    <tr>
        <td style="width: 1px; height: 1px;" valign="top"  class=block>
            <asp:Image ID="Image8" runat="server" ImageUrl="~/Images/sd.gif" Width="32px" AlternateText="<%$ Resources:TimeLive.Resource, Team Based Collaboration%> " /></td>
        <td style="width: 218px; height: 1px;" class="block" valign="top">
            <asp:HyperLink ID="HyperLink8" NavigateUrl="http://www.livetecs.com/Home/Features.aspx" runat="server" CssClass="FeatureHeadingIcon"><asp:Literal ID="Literal25" runat="server" Text="<%$ Resources:TimeLive.Resource, Team Based Collaboration%> " /></asp:HyperLink><br />
            <asp:Literal ID="Literal11" runat="server" Text="<%$ Resources:TimeLive.Resource, Fully Team based collaboration suite%> " /></td>
            </td>
    </tr>
    <tr height=10px bgcolor=white>
        <td></td>
        <td valign="top"></td>
    </tr>
    <tr>
        <td style="width: 1px; height: 1px;" valign="top"  class=block>
            <asp:Image ID="Image9" runat="server" ImageUrl="~/Images/stats.gif" Width="32px" AlternateText="<%$ Resources:TimeLive.Resource, Track and Monitor Your bugs%> " /></td>
        <td style="width: 218px" class="block" valign="top">
            <asp:HyperLink ID="HyperLink9" NavigateUrl="http://www.livetecs.com/Home/Features.aspx" runat="server" CssClass="FeatureHeadingIcon"><asp:Literal ID="Literal26" runat="server" Text="<%$ Resources:TimeLive.Resource, Track and Monitor%> " /></asp:HyperLink><br />
            <asp:Literal ID="Literal12" runat="server" Text="<%$ Resources:TimeLive.Resource, Track and monitor your projects / tasks / timesheets / expenses / bugs with easy to use reports and graphs.%> " /></td>
            </td>
    </tr>
    <tr height=10px bgcolor=white>
        <td></td>
        <td valign="top"></td>
    </tr>
    <tr>
        <td style="width: 1px" valign="top"  class=block>
            <asp:Image ID="Image10" runat="server" ImageUrl="~/Images/30day4.gif" Width="32px" AlternateText="<%$ Resources:TimeLive.Resource, Project Management%> " /></td>
        <td style="width: 218px" class="block" valign="top">
            <asp:HyperLink ID="HyperLink10" NavigateUrl="http://www.livetecs.com/Home/Features.aspx" runat="server" CssClass="FeatureHeadingIcon"><asp:Literal ID="Literal27" runat="server" Text="<%$ Resources:TimeLive.Resource, 30 Day Money Back Guarantee%> " /></asp:HyperLink><br />
            <asp:Literal ID="Literal13" runat="server" Text="<%$ Resources:TimeLive.Resource, 100% satisfaction guaranteed or your money back%> " /></td>
            </td>
    </tr>
    <tr height=10px bgcolor=white>
        <td></td>
        <td valign="top"></td>
    </tr>
    <tr>
        <td style="width: 1px; height: 57px;" valign="top"  class=block> 
            <asp:Image ID="Image11" runat="server" ImageUrl="~/Images/program.gif" Width="32px" AlternateText="<%$ Resources:TimeLive.Resource, Customizable%> " /></td>
        <td style="width: 218px; height: 57px;" class="block" valign="top">
            <asp:HyperLink ID="HyperLink11" NavigateUrl="http://www.livetecs.com/Home/Features.aspx" runat="server" CssClass="FeatureHeadingIcon"><asp:Literal ID="Literal28" runat="server" Text="<%$ Resources:TimeLive.Resource, Customizable%> " /></asp:HyperLink><br />
            <asp:Literal ID="Literal14" runat="server" Text="<%$ Resources:TimeLive.Resource, Customer can request their personalized customization.%> " /></td>
            </td>
    </tr>
</table>
