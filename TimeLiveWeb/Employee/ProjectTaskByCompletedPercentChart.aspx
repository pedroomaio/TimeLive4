<%@ Page Title="" Language="VB" MasterPageFile="~/Masters/MasterPageEmployee.master" AutoEventWireup="false" CodeFile="ProjectTaskByCompletedPercentChart.aspx.vb" Inherits="Employee_ProjectTaskByCompletedPercentChart" %>
<%@ Register Src="Controls/ctlProjectTaskByCompletedPercent.ascx" TagName="ctlProjectTaskByCompletedPercent" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="C" Runat="Server">
    <uc1:ctlProjectTaskByCompletedPercent ID="ctlProjectTaskByCompletedPercent" runat="server" />
</asp:Content>


   
