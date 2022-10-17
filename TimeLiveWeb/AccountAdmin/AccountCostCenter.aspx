<%@ Page Language="VB" MasterPageFile="~/Masters/MasterPageEmployee.master" AutoEventWireup="false" CodeFile="AccountCostCenter.aspx.vb" Inherits="AccountAdmin_AccountCostCenter" title="TimeLive - Cost Center" %>
<%@ Register Src="Controls/ctlAccountCostCenterList.ascx" TagName="ctlAccountCostCenterList"
    TagPrefix="uc1" %>
    
<asp:Content Content ID="C" ContentPlaceHolderID="C" Runat="Server">
 <uc1:ctlAccountCostCenterList ID="CtlAccountCostCenterList1" runat="server" />
</asp:Content>

