<%@ Page Language="VB" MasterPageFile="~/Masters/MasterPageEmployee.master" AutoEventWireup="false"
    CodeFile="AccountTimeOffTypes.aspx.vb" Inherits="AccountAdmin_AccountTimeOffTypes"
    Title="TimeLive - Time Off Types" %>

<%@ Register Src="Controls/ctlAccountTimeOffTypeList.ascx" TagName="ctlAccountTimeOffTypeList"
    TagPrefix="uc1" %>
<asp:Content ID="phCustomHeaderStylesAndScripts" ContentPlaceHolderID="phCustomHeaderStylesAndScripts"
    runat="server">
    <script src="../js/libs/bootstrap/jquery-1.9.1.min.js" type="text/javascript"></script>
    <script src="../js/libs/jscolor/jscolor.min.js" type="text/javascript"></script>

    <script type="text/javascript">
        function pageLoad() { jscolor.installByClassName("jscolor"); }  
    </script>
</asp:Content>
<asp:Content Content ID="C" ContentPlaceHolderID="C" runat="Server">
    <uc1:ctlAccountTimeOffTypeList ID="CtlAccountTimeOffTypeList1" runat="server" />
</asp:Content>
<asp:Content ID="phCustomFooterStylesAndScripts" ContentPlaceHolderID="phCustomFooterStylesAndScripts"
    runat="server">
    <script type="text/javascript" src="../js/setup.js"></script>
</asp:Content>
