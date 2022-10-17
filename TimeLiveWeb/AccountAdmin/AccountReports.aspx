<%@ Page Language="VB" MasterPageFile="~/Masters/MasterPageEmployee.master" AutoEventWireup="false" CodeFile="AccountReports.aspx.vb" Inherits="AccountAdmin_frmAccountReports" title="TimeLive - Reports" Theme="SkinFile" %>

<%@ Register Src="Controls/ctlAccountReportsList.ascx" TagName="ctlAccountReportsList"
    TagPrefix="uc3" %>

<asp:Content Content ID="C" ContentPlaceHolderID="C" Runat="Server">
    <uc3:ctlAccountReportsList ID="ctlAccountReportsList1" runat="server" />
    <br />
                    &nbsp;<br />
</asp:Content>