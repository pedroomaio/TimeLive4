<%@ Page Language="VB" MasterPageFile="~/Masters/MasterPageEmployee.master" AutoEventWireup="false" CodeFile="AccountEmployeeTimeEntry.aspx.vb" Inherits="Employee_AccountEmployeeTimeEntry" title="TimeLive - TimeEntry" Theme="SkinFile" %>

<%@ Register Assembly="eWorld.UI"
    Namespace="eWorld.UI" TagPrefix="ew" %>

<%@ Register Assembly="eWorld.UI"
    Namespace="eWorld.UI" TagPrefix="ew" %>

<%@ Register Src="Controls/ctlAccountEmployeeTimeEntryDayView.ascx" TagName="ctlAccountEmployeeTimeEntryDayView"
    TagPrefix="uc1" %>
<%@ Register Src="Controls/ctlAccountEmployeeTimeEntryWeekView.ascx" TagName="ctlAccountEmployeeTimeEntryWeekView"
    TagPrefix="uc2" %>


<asp:Content ID="C" ContentPlaceHolderID="C" Runat="Server">
    <br />
    <table border="0" cellpadding="0" cellspacing="0" width="98%">
        <tr>
            <td >


    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td style="width: 50%" >
g
            </td>
            <td style="width: 50%" align=right >
                    <asp:Menu ID="Menu1" runat="server" OnMenuItemClick="Menu1_MenuItemClick" Orientation="Horizontal" BackColor="#F7F6F3" DynamicHorizontalOffset="2" Font-Names="Tahoma" Font-Size="0.8em" ForeColor="#7C6F57" StaticSubMenuIndent="10px" BorderStyle="Solid" BorderWidth="1px" Font-Bold="True">
                    <Items>
                    <asp:MenuItem Text="DayView" Value="DayView" ></asp:MenuItem>
                    <asp:MenuItem Text="WeekView" Value="WeekView" Selected="True"></asp:MenuItem>
                </Items>
                <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" BorderColor="#FEC219" BorderWidth="1px" ForeColor="#505050" />
                <DynamicHoverStyle BackColor="#7C6F57" ForeColor="White" />
                <DynamicMenuStyle BackColor="#F7F6F3" />
                <StaticSelectedStyle BackColor="#5D7B9D" ForeColor="#505050" />
                <DynamicSelectedStyle BackColor="#5D7B9D" />
                <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
                <StaticHoverStyle BackColor="#7C6F57" ForeColor="White" />
                <StaticMenuStyle BackColor="#FFF0C6" />
                </asp:Menu>
            </td>
        </tr>
    </table>
            </td>
        </tr>
        <tr>
            <td style="width: 100%; height: 19px" >
     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
                        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%; height: 1px; border-right: black 1px solid; border-top: black 1px solid; border-left: black 1px solid; border-bottom: black 1px solid;" >
                    <tr>
                        <td style="width: 134px; height: 21px" class="FormViewSubHeader">
                            TimeEntry Date:</td>
                        <td style="width: 163px; height: 21px">
                            <ew:calendarpopup id="txtTimeEntryDate" runat="server" SkinId="DatePicker" UpperBoundDate="2010-11-13" Width="104px"></ew:calendarpopup>
                        </td>
                        <td style="width: 100px; height: 21px">
                            <asp:Button ID="btnShow" runat="server" Text="Show" OnClick="btnShow_Click" />
                        </td>
                        <td width="60%"></td>
                    </tr>
                    <tr>
                        <td colspan=4>
    <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0" EnableTheming="True" OnActiveViewChanged="MultiView1_ActiveViewChanged">
        <asp:View ID="TimeEntryDayView" runat="server">
            <uc1:ctlAccountEmployeeTimeEntryDayView ID="CtlAccountEmployeeTimeEntryDayView1"
                runat="server" EnableViewState="true" />
        </asp:View>
        <asp:View ID="TimeEntryWeekView" runat="server">
            <uc2:ctlAccountEmployeeTimeEntryWeekView ID="CtlAccountEmployeeTimeEntryWeekView1"
                runat="server" />
        </asp:View>
    </asp:MultiView>
                        
                        </td>
                    </tr>
                </table>
           </ContentTemplate>
    </asp:UpdatePanel>

            </td>
        </tr>
    </table>

    <br />
    &nbsp;
    <br />

 
</asp:Content>

