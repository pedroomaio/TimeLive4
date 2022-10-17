<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlLocationListReport.ascx.vb" Inherits="Reports_ControlsViewer_ctlLocationListReport" %>
<%@ Register Assembly="DevExpress.XtraReports.v11.1.Web"
    Namespace="DevExpress.XtraReports.Web" TagPrefix="dxxr" %>
<%@ Register Assembly="C1.Web.C1WebReport.2" Namespace="C1.Web.C1WebReport" TagPrefix="cc1" %>

<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>

<dxxr:ReportToolbar ID="ReportToolbar1" runat="server" ShowDefaultButtons="False" >
<Items><dxxr:ReportToolbarButton ItemKind='Search' ToolTip='Display the search window' />
<dxxr:ReportToolbarSeparator /><dxxr:ReportToolbarButton ItemKind='PrintReport' ToolTip='Print the report' /><dxxr:ReportToolbarButton ItemKind='PrintPage' ToolTip='Print the current page' /><dxxr:ReportToolbarSeparator /><dxxr:ReportToolbarButton Enabled='False' ItemKind='FirstPage' ToolTip='First Page' /><dxxr:ReportToolbarButton Enabled='False' ItemKind='PreviousPage' ToolTip='Previous Page' /><dxxr:ReportToolbarLabel Text='Page' /><dxxr:ReportToolbarComboBox ItemKind='PageNumber' Width='65px'></dxxr:ReportToolbarComboBox><dxxr:ReportToolbarLabel Text='of' /><dxxr:ReportToolbarTextBox IsReadOnly='True' ItemKind='PageCount' /><dxxr:ReportToolbarButton ItemKind='NextPage' ToolTip='Next Page' /><dxxr:ReportToolbarButton ItemKind='LastPage' ToolTip='Last Page' /><dxxr:ReportToolbarSeparator /><dxxr:ReportToolbarButton ItemKind='SaveToDisk' ToolTip='Export a report and save it to the disk' /><dxxr:ReportToolbarButton ItemKind='SaveToWindow' ToolTip='Export a report and show it in a new window' /><dxxr:ReportToolbarComboBox ItemKind='SaveFormat' Width='70px'><Elements><dxxr:ListElement Text='Pdf' Value='pdf' /><dxxr:ListElement Text='Xls' Value='xls' /><dxxr:ListElement Text='Rtf' Value='rtf' /><dxxr:ListElement Text='Mht' Value='mht' /><dxxr:ListElement Text='Text' Value='txt' /><dxxr:ListElement Text='Csv' Value='csv' /><dxxr:ListElement Text='Image' Value='png' /></Elements></dxxr:ReportToolbarComboBox></Items><Styles><LabelStyle><Margins MarginLeft='3px' MarginRight='3px' /></LabelStyle></Styles></dxxr:ReportToolbar>
<dxxr:ReportViewer ID="ReportViewer1" runat="server" >
</dxxr:ReportViewer>
    </ContentTemplate>
</asp:UpdatePanel>
