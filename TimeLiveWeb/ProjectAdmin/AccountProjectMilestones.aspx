<%@ Page Language="VB" MasterPageFile="~/Masters/MasterPageEmployee.master" AutoEventWireup="false" CodeFile="AccountProjectMilestones.aspx.vb" Inherits="AccountAdmin_frmAccountProjectMilestones" title="TimeLive - Project Milestones" Theme="SkinFile" %>

<%@ Register Src="Controls/ctlAccountProjectMilestoneList.ascx" TagName="ctlAccountProjectMilestoneList"
    TagPrefix="uc1" %>
<asp:Content Content ID="C" ContentPlaceHolderID="C" Runat="Server">
    <uc1:ctlAccountProjectMilestoneList ID="CtlAccountProjectMilestoneList1" runat="server" />
</asp:Content>

