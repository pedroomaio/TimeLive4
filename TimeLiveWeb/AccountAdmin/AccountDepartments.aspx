<%@ Page Language="VB" AutoEventWireup="false" CodeFile="AccountDepartments.aspx.vb" Inherits="WebForms_frmAccountDepartments" MasterPageFile="~/Masters/MasterPageEmployee.master" Theme="SkinFile" Title="TimeLive - Departments" %>
<%@ Register Src="Controls/ctlAccountDepartmentList.ascx" TagName="ctlAccountDepartmentList"
    TagPrefix="uc1" %>


<asp:Content Content ID="C" ContentPlaceHolderID="C" Runat="Server">
                        <uc1:ctlAccountDepartmentList ID="CtlAccountDepartmentList1" runat="server" />


</asp:Content>
