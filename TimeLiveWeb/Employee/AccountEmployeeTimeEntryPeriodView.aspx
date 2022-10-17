<%@ Page Language="VB" MasterPageFile="~/Masters/MasterPageEmployee.master" AutoEventWireup="true" CodeFile="AccountEmployeeTimeEntryPeriodView.aspx.vb" Inherits="Employee_AccountEmployeeTimeEntryPeriodView" Title="TimeLive - Time Entry Period View" ClientIDMode="Predictable" %>

<%@ Register Src="Controls/ctlAccountEmployeeTimeEntryWeekView.ascx" TagName="ctlAccountEmployeeTimeEntryWeekView"
    TagPrefix="uc1" %>
<%@ Register Src="Controls/ctlAccountEmployeeTimeEntryApprovalDetailsReadOnly.ascx" TagName="ctlAccountEmployeeTimeEntryApprovalDetailsReadOnly"
    TagPrefix="uc2" %>
<%@ Register Assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2"
    Namespace="eWorld.UI" TagPrefix="ew" %>
<asp:Content ID="C" ContentPlaceHolderID="C" runat="Server">
    <uc1:ctlAccountEmployeeTimeEntryWeekView ID="W"
        runat="server" />
    <uc2:ctlAccountEmployeeTimeEntryApprovalDetailsReadOnly ID="A"
        runat="server" />
</asp:Content>
