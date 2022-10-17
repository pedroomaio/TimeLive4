<%@ Page Language="VB" MasterPageFile="~/Masters/MasterPageMobileEmployee.master" AutoEventWireup="false" CodeFile="AccountEmployeeTimeEntryForm.aspx.vb" Inherits="Mobile_AccountEmployeeTimeEntryForm" Title="Timesheet"  EnableViewState="true"  %>
<%@ Register Src="Controls/ctlAccountEmployeeTimeEntryForm.ascx" TagName="ctlAccountEmployeeTimeEntryForm" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<uc1:ctlAccountEmployeeTimeEntryForm ID="ctlAccountEmployeeTimeEntryForm1" runat="server" />
</asp:Content>

