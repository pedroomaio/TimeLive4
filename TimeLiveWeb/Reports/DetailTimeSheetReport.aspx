<%@ Page Language="VB" MasterPageFile="~/Masters/MasterPageWithoutLeftNavigation.master" AutoEventWireup="false" CodeFile="DetailTimeSheetReport.aspx.vb" Inherits="Reports_DetailTimeSheetReport" title="TimeLive - Detail TimeSheet Report" %>

<%@ Register Src="ControlsViewer/ctlDetailTimeSheetReport.ascx" TagName="ctlDetailTimeSheetReport"
    TagPrefix="uc1" %>
<asp:Content ID="C1" ContentPlaceHolderID="CB" Runat="Server">
    <uc1:ctlDetailTimeSheetReport id="CtlDetailTimeSheetReport1" runat="server">
    </uc1:ctlDetailTimeSheetReport>
</asp:Content>

