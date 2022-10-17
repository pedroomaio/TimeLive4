<%@ Page Language="VB" MasterPageFile="~/Masters/MasterPageEmployee.master" AutoEventWireup="false" CodeFile="TimeOffRequest.aspx.vb" Inherits="Employee_TimeOffRequest" title="Time Off Request" %>
<%@ Register Src="Controls/ctlTimeOffRequest.ascx" TagName="ctlTimeOffRequest" TagPrefix="uc1" %>
<asp:Content Content ID="C" ContentPlaceHolderID="C" Runat="Server">
    <uc1:ctlTimeOffRequest ID="CtlTimeOffRequest1" runat="server" />
</asp:Content>