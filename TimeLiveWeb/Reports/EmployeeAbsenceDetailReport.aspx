<%@ Page Language="VB" MasterPageFile="~/Masters/MasterPageEmployee.master" AutoEventWireup="false" CodeFile="EmployeeAbsenceDetailReport.aspx.vb" Inherits="Reports_EmployeeAbsenceDetailReport" title="TimeLive - Employee Absence Detail Report" %>

<%@ Register Src="ControlsViewer/ctlEmployeeAbsenceDetailReport.ascx" TagName="ctlEmployeeAbsenceDetailReport"
    TagPrefix="uc1" %>
<asp:Content Content ID="C" ContentPlaceHolderID="C" Runat="Server">
    <uc1:ctlEmployeeAbsenceDetailReport id="CtlEmployeeAbsenceDetailReport1" runat="server">
    </uc1:ctlEmployeeAbsenceDetailReport>
</asp:Content>

