<%@ Page Language="VB" MasterPageFile="~/Masters/MasterPageEmployee.master" AutoEventWireup="false" CodeFile="AccountBillingTypes.aspx.vb" Inherits="AccountAdmin_frmAccountBillingTypes" title="TimeLive - Billing Types" Theme="SkinFile" %>

<%@ Register Src="Controls/ctlAccountBillingTypeList.ascx" TagName="ctlAccountBillingTypeList"
    TagPrefix="uc1" %>
<asp:Content Content ID="C" ContentPlaceHolderID="C" Runat="Server">
                    <uc1:ctlAccountBillingTypeList ID="CtlAccountBillingTypeList1" runat="server" />
   
</asp:Content>

