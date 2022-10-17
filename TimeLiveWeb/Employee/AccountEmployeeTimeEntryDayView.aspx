<%@ Page Language="VB" MasterPageFile="~/Masters/MasterPageEmployee.master" AutoEventWireup="false" CodeFile="AccountEmployeeTimeEntryDayView.aspx.vb" Inherits="Employee_AccountEmployeeTimeEntryDayView" title="TimeLive - Time Entry Day View" %>

<%@ Register Src="Controls/ctlAccountEmployeeTimeEntryDayView.ascx" TagName="ctlAccountEmployeeTimeEntryDayView"
    TagPrefix="uc1" %>

<%@ Register Assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2"
    Namespace="eWorld.UI" TagPrefix="ew" %>
<asp:Content ID="C" ContentPlaceHolderID="C" Runat="Server">
            <uc1:ctlAccountEmployeeTimeEntryDayView ID="CtlAccountEmployeeTimeEntryDayView1"  runat="server" />
</asp:Content>

