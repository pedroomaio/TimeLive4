<%@ Page Language="VB" MasterPageFile="~/Masters/MasterPageEmployee.master" AutoEventWireup="false" CodeFile="AccountEmployeeTimeEntryWeekViewTemplate.aspx.vb" Inherits="Employee_AccountEmployeeTimeEntryWeekViewTemplate" title="TimeLive - Time Entry Week View Template" %>

<%@ Register Src="Controls/ctlAccountEmployeeTimeEntryWeekViewTemplate.ascx" TagName="ctlAccountEmployeeTimeEntryWeekViewTemplate"
    TagPrefix="uc1" %>

<%@ Register Assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2"
    Namespace="eWorld.UI" TagPrefix="ew" %>
<asp:Content ID="C" ContentPlaceHolderID="C" Runat="Server">
            <uc1:ctlAccountEmployeeTimeEntryWeekViewTemplate ID="ctlAccountEmployeeTimeEntryWeekViewTemplate1"  runat="server" />
</asp:Content>

