<%@ Page Language="VB" MasterPageFile="~/Masters/MasterPageEmployee.master" AutoEventWireup="false" CodeFile="ShowReport.aspx.vb" Inherits="WebReport_ShowReport" title="TimeLive - Show Report" %>
<%@ Register Src="Reports/Controls/ctlShowReport.ascx" TagName="ctlShowReport" TagPrefix="uc1" %>
<asp:Content ID="C" ContentPlaceHolderID="C" Runat="Server">
<uc1:ctlShowReport ID="CtlShowReport1" runat="server" />

</asp:Content>

