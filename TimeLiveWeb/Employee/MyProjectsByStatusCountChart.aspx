<%@ Page Title="" Language="VB" MasterPageFile="~/Masters/MasterPageEmployee.master" AutoEventWireup="false" CodeFile="MyProjectsByStatusCountChart.aspx.vb" Inherits="Employee_MyProjectsByStatusCountChart" %>

<%@ Register Src="Controls/ctlMyProjectsGraphChart.ascx" TagName="ctlMyProjectsGraphChart" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="C" Runat="Server">
    <uc1:ctlMyProjectsGraphChart ID="ctlMyProjectsGraphChart" runat="server" />
</asp:Content>