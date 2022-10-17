<%@ Page Language="VB" MasterPageFile="~/Masters/MasterPageemployee.master" AutoEventWireup="false" CodeFile="AccountEMailNotificationPreferences.aspx.vb" Inherits="Employee_AccountEMailNotificationPreferences" title="TimeLive - Email Notification Preferences" %>

<%@ Register Src="Controls/ctlAccountEMailNotificationPreferenceList.ascx" TagName="ctlAccountEMailNotificationPreferenceList"
    TagPrefix="uc1" %>
<asp:Content Content ID="C" ContentPlaceHolderID="C" Runat="Server">
    <uc1:ctlAccountEMailNotificationPreferenceList id="CtlAccountEMailNotificationPreferenceList1"
        runat="server">
    </uc1:ctlAccountEMailNotificationPreferenceList>
</asp:Content>

