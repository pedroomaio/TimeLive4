    <%@ Page Language="VB" MasterPageFile="~/Masters/MasterPageEmployee.master" AutoEventWireup="false" CodeFile="AccountEmployeeProject.aspx.vb" Inherits="Employee_AccountEmployeeProject" title="TimeLive - Employee Project" Theme="SkinFile" %>
<%@ Register Src="Controls/ctlAccountEmployeeProject.ascx" TagName="ctlAccountEmployeeProject"
    TagPrefix="uc1" %>
<asp:Content Content ID="C" ContentPlaceHolderID="C" Runat="Server">
    <uc1:ctlAccountEmployeeProject ID="ctlAccountEmployeeProject" runat="server" />
</asp:Content>
