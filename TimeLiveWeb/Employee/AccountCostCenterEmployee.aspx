    <%@ Page Language="VB" MasterPageFile="~/Masters/MasterPageEmployee.master" AutoEventWireup="false" CodeFile="AccountCostCenterEmployee.aspx.vb" Inherits="Employee_AccountCostCenterEmployee" title="TimeLive - Cost Center Employee" Theme="SkinFile" %>
<%@ Register Src="Controls/ctlAccountCostCenterEmployee.ascx" TagName="ctlAccountCostCenterEmployee"
    TagPrefix="uc1" %>
<asp:Content Content ID="C" ContentPlaceHolderID="C" Runat="Server">
    <uc1:ctlAccountCostCenterEmployee ID="ctlAccountCostCenterEmployee" runat="server" />
</asp:Content>
