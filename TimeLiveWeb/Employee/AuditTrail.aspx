<%@ Page Language="VB" MasterPageFile="~/Masters/MasterPageEmployee.master" AutoEventWireup="false" CodeFile="AuditTrail.aspx.vb" Inherits="Employee_AuditTrail" title="Audit Trail" theme="SkinFile"%>

<%@ Register Src="Controls/ctlAuditTrail.ascx" TagName="ctlAuditTrail" TagPrefix="uc1" %>
<asp:Content Content ID="C" ContentPlaceHolderID="C" Runat="Server">
    <uc1:ctlAuditTrail ID="CtlAuditTrail1" runat="server" />
</asp:Content>

