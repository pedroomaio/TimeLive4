<%@ Page Language="VB" MasterPageFile="~/Masters/MasterPageEmployee.master"AutoEventWireup="false" CodeFile="AccountProjectTaskEmployees.aspx.vb" Inherits="ProjectAdmin_AccountProjectTaskEmployees" title="TimeLive - Tasks" Theme= "SkinFile" %>

<%@ Register src="Controls/ctlAccountProjectTastEmployees.ascx" tagname="ctlAccountProjectTastEmployees" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="C" Runat="Server">
            <uc1:ctlAccountProjectTastEmployees ID="ctlAccountProjectTastEmployees" 
                runat="server" />
</asp:Content>

