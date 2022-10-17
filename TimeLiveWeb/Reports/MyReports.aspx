<%@ Page Language="VB" MasterPageFile="~/Masters/MasterPageEmployee.master" AutoEventWireup="false" CodeFile="MyReports.aspx.vb" Inherits="Reports_MyReports" title="TimeLive - My Reports" Theme = "SkinFile" %>

<%@ Register Src="ControlsReports/ctlMyReports.ascx" TagName="ctlMyReports" TagPrefix="uc1" %>
<asp:Content ID="C" ContentPlaceHolderID="C" Runat="Server">
    <uc1:ctlMyReports ID="CtlMyReports1" runat="server" />
</asp:Content>

