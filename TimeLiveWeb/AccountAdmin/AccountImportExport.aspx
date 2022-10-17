<%@ Page Language="VB" AutoEventWireup="false" CodeFile="AccountImportExport.aspx.vb" MasterPageFile="~/Masters/MasterPageEmployee.master"  Inherits="AccountAdmin_AccountImportExport" title="TimeLive - Import Export"%>

<%@ Register Src="Controls/ctlAccountImportExport.ascx" TagName="ctlAccountImportExport"
    TagPrefix="uc1" %>

<asp:Content Content ID="C" ContentPlaceHolderID="C" Runat="Server">
        <uc1:ctlAccountImportExport ID="CtlAccountImportExport1" runat="server" />
</asp:Content>