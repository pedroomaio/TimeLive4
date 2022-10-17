<%@ Page Language="VB" MasterPageFile="~/Masters/MasterPageBase.master"  AutoEventWireup="false" CodeFile="SignUp.aspx.vb" Inherits="Home_SignUp" title="TimeLive - New Account"  %>

<%@ Register Src="Controls/ctlProductsDetail.ascx" TagName="ctlProductsDetail" TagPrefix="uc5" %>
<%@ Register Src="Controls/ctlFullFeatureListIcon.ascx" TagName="ctlFullFeatureListIcon"
    TagPrefix="uc6" %>
<%@ Register Src="Controls/ctlOfferIcon.ascx" TagName="ctlOfferIcon" TagPrefix="uc7" %>
<%@ Register Src="Controls/ctlFeaturesIcon.ascx" TagName="ctlFeaturesIcon" TagPrefix="uc4" %>
<%@ Register Src="Controls/ctlFeatures.ascx" TagName="ctlFeatures" TagPrefix="uc3" %>
<%@ Register Src="Controls/ctlOffersl.ascx" TagName="ctlOffersl" TagPrefix="uc2" %>
<%@ Register Src="Controls/ctlSignUp.ascx" TagName="ctlSignUp" TagPrefix="uc1" %>
<asp:Content ID="C2" ContentPlaceHolderID="C" Runat="Server">
	<tr>
	    <td valign=top width="100%"><uc1:ctlSignUp ID="CtlSignUp1" runat="server" /></td>
    </tr>    
</asp:Content>

