<%@ Page Language="VB" MasterPageFile="~/Masters/MasterPageEmployee.master" AutoEventWireup="false" CodeFile="EmployeeProjectPreferences.aspx.vb" Inherits="ProjectAdmin_EmployeeProjectPreferences" title="Employee Project Preferences" theme="SkinFile"%>

<%@ Register Src="Controls/ctlAccountEmployeeProjectPreferences.ascx" TagName="ctlAccountEmployeeProjectPreferences"
    TagPrefix="uc1" %>
<asp:Content Content ID="C" ContentPlaceHolderID="C" Runat="Server">
    <uc1:ctlAccountEmployeeProjectPreferences ID="CtlAccountEmployeeProjectPreferences1"
        runat="server" />
</asp:Content>

