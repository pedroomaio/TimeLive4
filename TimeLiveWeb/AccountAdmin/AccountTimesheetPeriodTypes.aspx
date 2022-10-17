<%@ Page Language="VB" MasterPageFile="~/Masters/MasterPageEmployee.master" AutoEventWireup="false" CodeFile="AccountTimesheetPeriodTypes.aspx.vb" Inherits="AccountAdmin_AccountTimesheetPeriodTypes" title="TimeLive - Timesheet Period Types" %>

<%@ Register Src="Controls/ctlAccountTimesheetPeriodTypeList.ascx" TagName="ctlAccountTimesheetPeriodTypeList"
    TagPrefix="uc2" %>

<asp:Content Content ID="C" ContentPlaceHolderID="C" Runat="Server">
    <uc2:ctlAccountTimesheetPeriodTypeList ID="CtlAccountTimesheetPeriodTypeList1" runat="server" />
</asp:Content>

