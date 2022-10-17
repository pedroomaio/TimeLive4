<%@ Page Language="VB" MasterPageFile="~/Masters/MasterPageEmployee.master" AutoEventWireup="false" CodeFile="MyReports.aspx.vb" Inherits="WebReport_MyReports" title="TimeLive - My Reports" EnableViewState="true"  %>
<%@ Register Src="Reports/Controls/ctlMyReports.ascx" TagName="ctlMyReports" TagPrefix="uc1" %>
<asp:Content ID="C" ContentPlaceHolderID="C" Runat="Server">
    <uc1:ctlMyReports ID="CtlMyReports1" runat="server" />



</asp:Content>


