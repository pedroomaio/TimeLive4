<%@ Page Language="VB" MasterPageFile="~/Masters/MasterPageBase.master"  AutoEventWireup="false" CodeFile="CustomerRequest.aspx.vb" Inherits="Home_CustomerRequest" title="TimeLive - New Account"  %>

<%@ Register Src="Controls/ctlCustomerForm.ascx" TagName="ctlCustomerForm" TagPrefix="uc8" %>

<%@ Register Src="Controls/ctlProductsDetail.ascx" TagName="ctlProductsDetail" TagPrefix="uc5" %>
<%@ Register Src="Controls/ctlFullFeatureListIcon.ascx" TagName="ctlFullFeatureListIcon"
    TagPrefix="uc6" %>
<%@ Register Src="Controls/ctlOfferIcon.ascx" TagName="ctlOfferIcon" TagPrefix="uc7" %>


<%@ Register Src="Controls/ctlFeaturesIcon.ascx" TagName="ctlFeaturesIcon" TagPrefix="uc4" %>

<%@ Register Src="Controls/ctlFeatures.ascx" TagName="ctlFeatures" TagPrefix="uc3" %>

<%@ Register Src="Controls/ctlOffersl.ascx" TagName="ctlOffersl" TagPrefix="uc2" %>


<%@ Register Src="Controls/ctlaccountform.ascx" TagName="ctlaccountform" TagPrefix="uc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderLeftMenu" Runat="Server">

    <table border="0" cellpadding="0" cellspacing="0" width="95%">
        <tr>
            <td align="center" style="height: 166px">
                <uc7:ctlOfferIcon ID="CtlOfferIcon1" runat="server" />
                &nbsp;</td>
        </tr>
        <tr>
            <td align="center">
                <br />
            </td>
        </tr>
        <tr>
            <td align="center" style="height: 196px">
                &nbsp;</td>
        </tr>
    </table>
    <br />
    <br />
    <br />

</asp:Content>
<asp:Content ID="C" ContentPlaceHolderID="C" Runat="Server">
    <uc8:ctlCustomerForm ID="CtlCustomerForm1" runat="server" />
    
</asp:Content>

