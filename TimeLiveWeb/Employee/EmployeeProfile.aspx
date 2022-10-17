<%@ Page Language="VB" MasterPageFile="~/Masters/MasterPageEmployee.master" AutoEventWireup="false" CodeFile="EmployeeProfile.aspx.vb" Inherits="Employee_EmployeeProfile" title="TimeLive - My Profile" %>

<%@ Register Src="Controls/ctlAccountEmployeeProfile.ascx" TagName="ctlAccountEmployeeProfile"
    TagPrefix="uc1" %>

<asp:Content ID="C" ContentPlaceHolderID="C" Runat="Server">
    <uc1:ctlAccountEmployeeProfile ID="CtlAccountEmployeeProfile1" runat="server" />
</asp:Content>

