    <%@ Page Language="VB" MasterPageFile="~/Masters/MasterPageEmployee.master" AutoEventWireup="false" CodeFile="AccountProjectEmployees.aspx.vb" Inherits="AccountAdmin_AccountProjectEmployees" title="TimeLive - Project Employees" Theme="SkinFile" %>
<%@ Register Src="Controls/ctlAccountProjectEmployee.ascx" TagName="ctlAccountProjectEmployee"
    TagPrefix="uc1" %>
<asp:Content Content ID="C" ContentPlaceHolderID="C" Runat="Server">
    <uc1:ctlAccountProjectEmployee ID="CtlAccountProjectEmployee" runat="server" />
</asp:Content>
