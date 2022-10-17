<%@ Page Language="VB" MasterPageFile="~/Masters/MasterPageEmployee.master" AutoEventWireup="false" CodeFile="AccountEmployeeDashboard.aspx.vb" Title="Dashboard Setting" Inherits="Employee_AccountEmployeeDashboard" %>

<%@ Register src="Controls/ctlAccountEmployeeDashboard.ascx" tagname="ctlAccountEmployeeDashboard" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="C" Runat="Server">
            <uc1:ctlAccountEmployeeDashboard ID="ctlAccountEmployeeDashboard1" 
                runat="server" />
</asp:Content>

