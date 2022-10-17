<%@ Page Language="VB" MasterPageFile="~/Masters/MasterPageEmployee.master" AutoEventWireup="false" CodeFile="LocationListReport.aspx.vb" Inherits="Reports_LocationListReport" title="TimeLive - All Locations Report" %>

<%@ Register Src="ControlsViewer/ctlLocationListReport.ascx" TagName="ctlLocationListReport"
    TagPrefix="uc1" %>
<asp:Content ID="C" ContentPlaceHolderID="C" Runat="Server">
    <uc1:ctlLocationListReport ID="CtlLocationListReport1" runat="server" />
</asp:Content>

