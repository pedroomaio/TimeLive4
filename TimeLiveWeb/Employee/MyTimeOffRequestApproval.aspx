<%@ Page Language="VB" MasterPageFile="~/Masters/MasterPageEmployee.master" AutoEventWireup="false" CodeFile="MyTimeOffRequestApproval.aspx.vb" Inherits="Employee_MyTimeOffRequestApproval" title="Time Off Approval" %>

<%@ Register Src="Controls/ctlTimeOffRequestApproval.ascx" TagName="ctlTimeOffRequestApproval"
    TagPrefix="uc1" %>
<asp:Content Content ID="C" ContentPlaceHolderID="C" Runat="Server">
    <uc1:ctlTimeOffRequestApproval ID="CtlTimeOffRequestApproval1" runat="server" />
</asp:Content>

