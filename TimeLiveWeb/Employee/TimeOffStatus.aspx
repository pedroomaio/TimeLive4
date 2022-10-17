<%@ Page Language="VB" MasterPageFile="~/Masters/MasterPageEmployee.master" AutoEventWireup="false" CodeFile="TimeOffStatus.aspx.vb" Inherits="Employee_TimeOffStatus" title="TimeLive - Time Off Status" %>

<%@ Register Src="Controls/ctlTimeOffStatus.ascx" TagName="ctlTimeOffStatus" TagPrefix="uc1" %>
<asp:Content Content ID="C" ContentPlaceHolderID="C" Runat="Server">
    <uc1:ctlTimeOffStatus ID="CtlTimeOffStatus1" runat="server" />
</asp:Content>

