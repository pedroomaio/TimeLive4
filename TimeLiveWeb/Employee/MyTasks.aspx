<%@ Page Language="VB" MasterPageFile="~/Masters/MasterPageEmployee.master" AutoEventWireup="false" CodeFile="MyTasks.aspx.vb" Inherits="Employee_frmMyTasks" title="TimeLive - My Tasks" %>
<%@ Register Src="Controls/ctlMyReportedTasks.ascx" TagName="ctlMyReportedTasks"
    TagPrefix="uc3" %>
<%@ Register Src="../ProjectAdmin/Controls/ctlAccountProjectTaskForm.ascx" TagName="ctlAccountProjectTaskForm"
    TagPrefix="uc2" %>
<%@ Register Src="Controls/ctlMyTasks.ascx" TagName="ctlMyTasks" TagPrefix="uc1" %>
<%@ MasterType VirtualPath="~/Masters/MasterPageEmployee.master" %>
<asp:Content Content ID="C" ContentPlaceHolderID="C" Runat="Server">
    <uc1:ctlMyTasks ID="CtlMyTasks1" runat="server" />
    <uc2:ctlAccountProjectTaskForm ID="CtlAccountProjectTaskForm1" runat="server" />
</asp:Content>

