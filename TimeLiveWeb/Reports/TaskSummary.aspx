<%@ Page Language="VB" MasterPageFile="~/Masters/MasterPageEmployee.master" AutoEventWireup="false" CodeFile="TaskSummary.aspx.vb" Inherits="Reports_TaskSummary" title="TimeLive - Task Summary Report" %>

<%@ Register Src="ControlsViewer/ctlTaskSummary.ascx" TagName="ctlTaskSummary" TagPrefix="uc1" %>
<asp:Content ID="C" ContentPlaceHolderID="C" Runat="Server">
    <uc1:ctlTaskSummary ID="CtlTaskSummary1" runat="server" />
</asp:Content>

        