<%@ Page Title="" Language="VB" MasterPageFile="~/Masters/MasterPageEmployee.master" AutoEventWireup="false" CodeFile="ChartCustomization.aspx.vb" Inherits="Employee_ChartCustomization" %>

<%@ Register Src="Controls/ctlChartCustomization.ascx" TagName="ctlChartCustomization" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="C" Runat="Server">
    <uc1:ctlChartCustomization ID="ctlChartCustomization" runat="server" />
    </asp:Content>