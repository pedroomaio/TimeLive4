<%@ Page Title="" Language="VB" MasterPageFile="~/Masters/MasterPageEmployee.master" AutoEventWireup="false" CodeFile="MyTasksByDuration(Chart).aspx.vb" Inherits="Employee_MyTasksByDuration_Chart_" %>

<%@ Register Src="Controls/ctlAccountProjectTaskByDuration.ascx" TagName="ctlAccountProjectTaskByDuration" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="C" Runat="Server">
 <uc1:ctlAccountProjectTaskByDuration ID="ctlAccountProjectTaskByDuration" runat="server" />
 </asp:Content>

