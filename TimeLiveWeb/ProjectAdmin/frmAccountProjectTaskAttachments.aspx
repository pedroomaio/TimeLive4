<%@ Page Language="VB" MasterPageFile="~/Masters/MasterPageEmployee.master" AutoEventWireup="false" CodeFile="frmAccountProjectTaskAttachments.aspx.vb" Inherits="ProjectAdmin_frmAccountProjectTaskAttachments" title="Untitled Page" Theme="SkinFile" %>

<%@ Register Src="Controls/ctlAccountProjectTaskAttachmentList.ascx" TagName="ctlAccountProjectTaskAttachmentList"
    TagPrefix="uc1" %>
<asp:Content Content ID="C" ContentPlaceHolderID="C" Runat="Server">
    <uc1:ctlAccountProjectTaskAttachmentList ID="CtlAccountProjectTaskAttachmentList1"
        runat="server" />
</asp:Content>

