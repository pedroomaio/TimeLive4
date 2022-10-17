<%@ Page Language="VB" MasterPageFile="~/Masters/MasterPageEmployee.master" AutoEventWireup="false" CodeFile="AccountCustomFieldManage.aspx.vb" Inherits="AccountAdmin_AccountCustomFieldManage" title="TimeLive - Custom Field Manage" %>

<%@ Register Src="Controls/ctlAccountCustomFieldManage.ascx" TagName="AccountCustomFieldManage"
    TagPrefix="uc1" %>
<asp:Content Content ID="C" ContentPlaceHolderID="C" Runat="Server">
    <uc1:AccountCustomFieldManage id="AccountCustomFieldManage" runat="server">
    </uc1:AccountCustomFieldManage>
</asp:Content>

