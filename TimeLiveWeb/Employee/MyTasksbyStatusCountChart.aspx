<%@ Page Title="" Language="VB" MasterPageFile="~/Masters/MasterPageEmployee.master" AutoEventWireup="false" CodeFile="MyTasksbyStatusCountChart.aspx.vb" Inherits="Employee_MyTasksbyStatusCountChart" %>
<%@ Register Src="Controls/ctlProjectTaskCount.ascx" TagName="ctlProjectTaskCount" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="C" Runat="Server">
 <uc1:ctlProjectTaskCount ID="ctlProjectTaskCount" runat="server" />
</asp:Content>

