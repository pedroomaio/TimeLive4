<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlProductPricing.ascx.vb" Inherits="Home_Controls_ctlProductPricing" %>

<table id="TABLE1" class="BlockTable" language="javascript" style="border-right: 1px solid" width="100%" >
    <tbody>
        <tr class="blockheader">
            <td  style="width: 170px; height: 52px;" >
                Product</td>
            <td style="height: 52px">
                Number
                <br />
                of 
                <br />
                Users</td>
            <td style="height: 52px">
                Storage 
                <br />
                Space</td>
            <td style="height: 52px">
                Price</td>
            <td style="height: 52px">
                Mode</td>
            <td style="height: 52px">
            </td>
        </tr>
        <tr class="blockheadergroup">
            <td colspan="5" style="height: 21px">
                Hosted Versions</td>
            <td colspan="1" style="height: 21px">
            </td>
        </tr>
        <tr>
            <td style="width: 170px;height: 21px">
                TimeLive Lite (Hosted)
            </td>
            <td>
                5</td>
            <td>
                Unlimited</td>
            <td>
                Free</td>
            <td>
                Free</td>
            <td>
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Home/AccountAdd.aspx"  CssClass="AdditionalLink">Signup</asp:HyperLink></td>
        </tr>
        <tr>
            <td style="width: 170px; height: 21px">
                TimeLive Basic (Hosted)</td>
            <td>
                10</td>
            <td>
                Unlimited</td>
            <td>
                US$ 10</td>
            <td>
                Per month
            </td>
            <td> 
                <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Home/AccountAdd.aspx?Mode=5"  CssClass="AdditionalLink">Signup</asp:HyperLink>
             </td>
        </tr>
        <tr>
            <td style="width: 170px; height: 21px">
                TimeLive Standard (Hosted)</td>
            <td>
                25</td>
            <td>
                Unlimited</td>
            <td>
                US$ 15
            </td>
            <td>
                Per month
            </td>
            <td>
                <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/Home/AccountAdd.aspx?Mode=10"  CssClass="AdditionalLink">Signup</asp:HyperLink>
                </td>
        </tr>
        <tr>
            <td style="width: 170px; height: 21px">
                TimeLive Enterprise (Hosted)</td>
            <td>
                Unlimited</td>
            <td>
                Unlimited</td>
            <td>
                US$ 25</td>
            <td>
                Per month</td>
            <td>
                <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/Home/AccountAdd.aspx?Mode=15"  CssClass="AdditionalLink">Signup</asp:HyperLink>
            </td>
        </tr>
        <tr class="blockheadergroup">
            <td colspan="5" style="height: 21px">
                Downloadable Version</td>
            <td colspan="1" style="height: 21px">
            </td>
        </tr>
        <tr>
            <td style="width: 170px; height: 20px">
                TimeLive Lite</td>
            <td style="height: 20px">
                5</td>
            <td style="height: 20px">
                Unlimited</td>
            <td style="height: 20px">
                Free</td>
            <td style="height: 20px">
                Free</td>
            <td style="height: 20px">
                <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/Home/CustomerRequest.aspx?CustomerRequestTypeId=1"  CssClass="AdditionalLink">Download</asp:HyperLink>
                
                </td>
        </tr>
        <tr>
            <td style="width: 170px; height: 20px">
                TimeLive Enterprise</td>
            <td style="height: 20px">
                Unlimited</td>
            <td style="height: 20px">
                Unlimited</td>
            <td style="height: 20px">
                US$ 100</td>
            <td style="height: 20px">
                One Time Fees</td>
            <td style="height: 20px">
                <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="~/Home/CustomerRequest.aspx?CustomerRequestTypeId=2"  CssClass="AdditionalLink">Purchase</asp:HyperLink>
                </td>
        </tr>
        <tr>
            <td style="width: 170px; height: 20px">
                TimeLive Enterprise (Source Code)<br />
                Developed in ASP.net, VB.net and SQL Server 2005</td>
            <td style="height: 20px">
                Unlimited</td>
            <td style="height: 20px">
                Unlimited</td>
            <td style="height: 20px">
                US$ 250</td>
            <td style="height: 20px">
                One Time Fees</td>
            <td style="height: 20px">
                <asp:HyperLink ID="HyperLink7" runat="server" CssClass="AdditionalLink" NavigateUrl="http://store.eSellerate.net/s.asp?s=STR6521630860&Cmd=BUY&SKURefnum=SKU70698390238">Purchase</asp:HyperLink></td>
        </tr>

    </tbody>
</table>



