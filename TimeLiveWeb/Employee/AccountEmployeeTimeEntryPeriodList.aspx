<%@ Page Language="VB" MasterPageFile="~/Masters/MasterPageEmployee.master" AutoEventWireup="false" CodeFile="AccountEmployeeTimeEntryPeriodList.aspx.vb" Inherits="Employee_AccountEmployeeTimeEntryPeriodList" title="TimeLive - Timesheet Period List" Theme="SkinFile" %>

<%@ Register Src="Controls/ctlAccountEmployeeTimeEntryPeriodList.ascx" TagName="ctlAccountEmployeeTimeEntryPeriodList"
    TagPrefix="uc1" %>
    <%@ MasterType VirtualPath="~/Masters/MasterPageEmployee.master" %>
<asp:Content Content ID="C" ContentPlaceHolderID="C" Runat="Server">
    <uc1:ctlAccountEmployeeTimeEntryPeriodList ID="CtlAccountEmployeeTimeEntryPeriodList1"
        runat="server" />
</asp:Content>

