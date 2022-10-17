<%@ Page Language="VB" MasterPageFile="~/Masters/MasterPageEmployee.master" AutoEventWireup="false" CodeFile="AccountProjectTemplates.aspx.vb" Inherits="AccountAdmin_frmAccountProjectTemplates" title="TimeLive - Project Template" Theme="SkinFile" %>

<%@ Register Src="Controls/ctlAccountProjectForm.ascx" TagName="ctlAccountProjectForm"
    TagPrefix="uc2" %>

<%@ Register Src="Controls/ctlAccountProjectList.ascx" TagName="ctlAccountProjectList"
    TagPrefix="uc1" %>
 <%@ MasterType VirtualPath="~/Masters/MasterPageEmployee.master" %>
<asp:Content Content ID="C" ContentPlaceHolderID="C" Runat="Server">
    <uc1:ctlAccountProjectList ID="CtlAccountProjectList1" runat="server" />
    <uc2:ctlAccountProjectForm id="CtlAccountProjectForm1" runat="server">
    </uc2:ctlAccountProjectForm>
</asp:Content>

