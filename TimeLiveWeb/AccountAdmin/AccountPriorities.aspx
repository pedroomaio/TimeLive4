<%@ Page Language="VB" MasterPageFile="~/Masters/MasterPageEmployee.master" AutoEventWireup="false" CodeFile="AccountPriorities.aspx.vb" Inherits="AccountAdmin_AccountPriorities" title="TimeLive - Priorities" %>

<%@ Register Src="Controls/ctlAccountPriorityList.ascx" TagName="ctlAccountPriorityList"
    TagPrefix="uc1" %>

<asp:Content ID="C" ContentPlaceHolderID="C" Runat="Server">
    <uc1:ctlAccountPriorityList id="CtlAccountPriorityList1" runat="server">
    </uc1:ctlAccountPriorityList>
</asp:Content>

