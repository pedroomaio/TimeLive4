<%@ Page Language="VB" MasterPageFile="~/Masters/MasterPageBase.master" AutoEventWireup="false" CodeFile="Contact.aspx.vb" Inherits="Home_Contact" title="Time and expense management - TimeLive" %>

<%@ Register Src="Controls/ctlContactInfo.ascx" TagName="ctlContactInfo" TagPrefix="uc5" %>
<%@ Register Src="Controls/ctlSiteOptions.ascx" TagName="ctlSiteOptions" TagPrefix="uc1" %>
<%@ Register Src="Controls/ctlProductPricing.ascx" TagName="ctlProductPricing" TagPrefix="uc2" %>
<%@ Register Src="Controls/ctlProductsDetail.ascx" TagName="ctlProductsDetail" TagPrefix="uc3" %>
<%@ Register Src="Controls/ctlOfferIcon.ascx" TagName="ctlOfferIcon" TagPrefix="uc4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderLeftMenu" Runat="Server">
<uc4:ctlOfferIcon ID="CtlOfferIcon1" runat="server" />
</asp:Content>
<asp:Content ID="C" ContentPlaceHolderID="C" Runat="Server">

    <table border="0" cellpadding="0" cellspacing="5" width="100%">
        <tr>
            <td style="width: 70%" valign="top">
                <table width="100%">
                    <tr>
                        <td style="width: 5px" valign="top">
                            <img src="../Images/ProductFeature.gif" /></td>
                        <td style="width: 100%">
                            <strong>What is TimeLive?</strong>&nbsp;<br />
                            <br />
                            <span class="HomePageFeatureText">TimeLive Web timesheet suite is integrated suite for time record, time tracking and time billing software. The TimeLive suite of products deliver a time tracking solution for professional service providers. &nbsp;</span></td>
                    </tr>
                    <tr>
                        <td style="width: 5px; height: 5px" valign="top">
                        </td>
                        <td style="width: 100%; height: 5px">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" valign="top" width="100%" class="HomePageFeatureText" style="height: 146px">
                            &nbsp;<uc5:ctlContactInfo ID="CtlContactInfo1" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" valign="top" width="100%" style="height: 21px">
                        </td>
                    </tr>
                </table>
            </td>
            <td style="width: 30%">
                <uc3:ctlProductsDetail ID="CtlProductsDetail1" runat="server" />
            </td>
        </tr>
    </table>

</asp:Content>

