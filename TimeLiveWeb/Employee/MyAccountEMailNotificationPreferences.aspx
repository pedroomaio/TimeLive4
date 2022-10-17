<%@ Page Language="VB" MasterPageFile="~/Masters/MasterPageemployee.master" AutoEventWireup="false" CodeFile="MyAccountEMailNotificationPreferences.aspx.vb" Inherits="My_AccountEMailNotificationPreferences" title="TimeLive - Email Notification Preferences" %>

<%@ Register Src="Controls/ctlMyAccountEMailNotificationPreferenceList.ascx" TagName="ctlMyAccountEMailNotificationPreferenceList"
    TagPrefix="uc2" %>

<%@ Register Src="Controls/ctlAccountEMailNotificationPreferenceList.ascx" TagName="ctlAccountEMailNotificationPreferenceList"
    TagPrefix="uc1" %>
    
<asp:Content Content ID="C" ContentPlaceHolderID="C" Runat="Server">
    
    <uc2:ctlMyAccountEMailNotificationPreferenceList ID="CtlMyAccountEMailNotificationPreferenceList1"
        runat="server" />
</asp:Content>

