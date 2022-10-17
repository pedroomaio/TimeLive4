<%@ Page Language="VB" MasterPageFile="~/Masters/MasterPageEmployee.master" AutoEventWireup="false" CodeFile="MyProjects.aspx.vb" Inherits="Employee_MyProjects" title="My Projects" EnableViewState="false" %>
<%@ Register Src="Controls/ctlMyProjects.ascx" TagName="ctlMyProjects" TagPrefix="uc1" %>
 <%@ MasterType VirtualPath="~/Masters/MasterPageEmployee.master" %>
<asp:Content ID="C" ContentPlaceHolderID="C" Runat="Server">
    <uc1:ctlMyProjects ID="CtlMyProjects1" runat="server" />
</asp:Content>

