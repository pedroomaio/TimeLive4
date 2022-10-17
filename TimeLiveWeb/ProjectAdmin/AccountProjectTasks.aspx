<%@ Page Language="VB" MasterPageFile="~/Masters/MasterPageEmployee.master" AutoEventWireup="false" CodeFile="AccountProjectTasks.aspx.vb" Inherits="AccountAdmin_frmAccountProjectTasks" title="TimeLive - Tasks" Theme= "SkinFile" %>
<%@ Register Src="Controls/ctlAccountProjectTaskForm.ascx" TagName="ctlAccountProjectTaskForm" TagPrefix="uc2" %>
<%@ Register Src="Controls/ctlAccountProjectTaskList.ascx" TagName="ctlAccountProjectTaskList" TagPrefix="uc1" %>
<%@ MasterType VirtualPath="~/Masters/MasterPageEmployee.master" %>
<asp:Content Content ID="C" ContentPlaceHolderID="C" Runat="Server">
    <uc1:ctlAccountProjectTaskList id="CtlAccountProjectTaskList1" runat="server" EnableViewState="true"/>
    <uc2:ctlAccountProjectTaskForm ID="CtlAccountProjectTaskForm1" runat="server" EnableViewState="true"/>
</asp:Content>

