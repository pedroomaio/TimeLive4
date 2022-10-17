<%@ Page Language="VB" MasterPageFile="~/Masters/MasterPageEmployee.master" AutoEventWireup="false" CodeFile="AccountProjectTypes.aspx.vb" Inherits="AccountAdmin_frmAccountProjectTypes" title="TimeLive - Project Types" Theme="SkinFile" %>

<%@ Register Src="Controls/ctlAccountProjectTypeList.ascx" TagName="ctlAccountProjectTypeList"
    TagPrefix="uc1" %>

<asp:Content Content ID="C" ContentPlaceHolderID="C" Runat="Server">
    <uc1:ctlAccountProjectTypeList ID="CtlAccountProjectTypeList1" runat="server" />
                    
</asp:Content>

