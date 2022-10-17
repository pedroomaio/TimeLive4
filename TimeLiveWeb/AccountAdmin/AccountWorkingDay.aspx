<%@ Page Language="VB" MasterPageFile="~/Masters/MasterPageEmployee.master" AutoEventWireup="false" CodeFile="AccountWorkingDay.aspx.vb" Inherits="Employee_frmAccountWorkingDay" title="TimeLive - Working Days" Theme ="SkinFile" %>

<%@ Register Src="Controls/ctlAccountWorkingDayList.ascx" TagName="ctlAccountWorkingDayList"
    TagPrefix="uc1" %>
     <%@ MasterType VirtualPath="~/Masters/MasterPageEmployee.master" %>
<asp:Content Content ID="C" ContentPlaceHolderID="C" Runat="Server">
    <uc1:ctlAccountWorkingDayList id="CtlAccountWorkingDayList1" runat="server">
    </uc1:ctlAccountWorkingDayList>
</asp:Content>

