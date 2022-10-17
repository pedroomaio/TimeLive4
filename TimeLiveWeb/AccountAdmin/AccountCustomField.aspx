<%@ Page Language="VB" MasterPageFile="~/Masters/MasterPageEmployee.master" AutoEventWireup="false" CodeFile="AccountCustomField.aspx.vb" Inherits="AccountAdmin_AccountCustomField" title="TimeLive - Custom Field" %>
<%@ Register Src="Controls/ctlAccountCustomFields.ascx" TagName="ctlAccountCustomFields"
    TagPrefix="uc1" %>
    <asp:Content Content ID="C" ContentPlaceHolderID="C" Runat="Server">
                        <uc1:ctlAccountCustomFields ID="ctlAccountCustomFields1" runat="server" />
</asp:Content>