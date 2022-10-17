<%@ Page Language="VB" AutoEventWireup="false" CodeFile="AccountClientsReport.aspx.vb"  MasterPageFile="~/Masters/MasterPageEmployee.master" Inherits="Reports_AccountClientsReport" title = "TimeLive - All Clients Report" %>

<%@ Register Src="ControlsViewer/ctlClientListReport.ascx" TagName="ctlClientListReport"
    TagPrefix="uc1" %>

<asp:Content Content ID="C" ContentPlaceHolderID="C" Runat="Server">
        <uc1:ctlClientListReport  ID="CtlClientListReport1" runat="server" />

</asp:Content>