<%@ Page Language="VB" MasterPageFile="~/Masters/MasterPageEmployee.master" AutoEventWireup="false" CodeFile="AccountAbsenceTypes.aspx.vb" Inherits="AccountAdmin_Controls_frmAccountAbsenceTypes" title="TimeLive - Absence Types" Theme = "SkinFile" %>

<%@ Register Src="Controls/ctlAccountAbsenceTypeList.ascx" TagName="ctlAccountAbsenceTypeList"
    TagPrefix="uc4" %>

<asp:Content Content ID="C" ContentPlaceHolderID="C" Runat="Server">
                    <uc4:ctlAccountAbsenceTypeList ID="CtlAccountAbsenceTypeList1" runat="server" />
</asp:Content>

