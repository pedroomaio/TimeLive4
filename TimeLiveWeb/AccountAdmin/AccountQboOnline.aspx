<%@ Page Language="VB" MasterPageFile="~/Masters/MasterPageEmployee.master" AutoEventWireup="false" CodeFile="AccountQboOnline.aspx.vb" Inherits="AccountAdmin_AccountQboOnline" Title="TimeLive - QuickBooks Online Integration" %>

<%@ Register Src="Controls/ctlQboOnline.ascx" TagName="ctlQboOnline"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="C" Runat="Server">
 <uc1:ctlQboOnline id="ctlQboOnline1"
        runat="server">
    </uc1:ctlQboOnline>
</asp:Content>

