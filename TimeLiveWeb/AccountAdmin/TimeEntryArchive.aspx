<%@ Page Language="VB" MasterPageFile="~/Masters/MasterPageEmployee.master" AutoEventWireup="false" CodeFile="TimeEntryArchive.aspx.vb" Inherits="AccountAdmin_TimeEntryArchive" title="TimeLive - Time Entry Archive" %>

<%@ Register Src="Controls/ctlTimeEntryArchive.ascx" TagName="ctlTimeEntryArchive"
    TagPrefix="uc1" %>
   <%@ MasterType VirtualPath="~/Masters/MasterPageEmployee.master" %>
<asp:Content Content ID="C" ContentPlaceHolderID="C" Runat="Server">
    <uc1:ctlTimeEntryArchive ID="CtlTimeEntryArchive1" runat="server" />
     
</asp:Content>

