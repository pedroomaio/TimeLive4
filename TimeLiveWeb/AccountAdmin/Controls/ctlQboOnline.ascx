<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlQboOnline.ascx.vb" Inherits="AccountAdmin_Controls_ctlQboOnline" ClientIDMode="Static" %>
<%@ Register Assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2"
    Namespace="eWorld.UI" TagPrefix="ew" %>
<%@ Register assembly="eWorld.UI" namespace="eWorld.UI" tagprefix="ew" %>
<style type="text/css">
    input.largerCheckbox
        {
	        width: 20px;
	        height: 20px;	
        }
         .withBorder
        {
	       border:1px solid #d6dadf;
        }
           .withoutBottomBorder
        {
	       border-top: 1px solid #d6dadf;
	       border-right :1px solid #d6dadf;
	       border-left :1px solid #d6dadf;
        }
        .captionlogin {color: white;background: #00438d url(../img/old-browsers/colors/bg_button-icon.png) repeat-x;-webkit-background-size: 100% 100%;-moz-background-size: 100% 100%;-o-background-size: 100% 100%;-webkit-box-shadow: inset 0 1px 0 rgba(255, 255, 255, 0.35);-moz-box-shadow: inset 0 1px 0 rgba(255, 255, 255, 0.35);background-size: 100% 100%;background: -webkit-gradient(linear, left top, left bottom, from(#006aac), to(#00438d));background: -webkit-linear-gradient(top, #006aac, #00438d);background: -moz-linear-gradient(top, #006aac, #00438d);background: -ms-linear-gradient(top, #006aac, #00438d);background: -o-linear-gradient(top, #006aac, #00438d);	background: linear-gradient(top, #006aac, #00438d);	border-color: #004795;	box-shadow: inset 0 1px 0 rgba(255, 255, 255, 0.35);	margin: 0;	padding: 18px 16px;	font-size:medium;	font-weight:lighter;	text-align:left;}
</style>
<asp:UpdatePanel ID="UPQB" runat="server">
<ContentTemplate>

             <table width="98%" class="xFormView" id="tblMain" runat="server" >
             
             
    <tr><td>
        <table border="0" cellpadding="2" class="xview" cellspacing="1" style="width: 100%;" >
         <tr>
        <th  class="caption">
            <asp:Literal ID="Literal1" runat="server" Text="QuickBooks Online Integration" /></th>
    </tr>
          <tr id="GetConnectedTR" runat="server">
                <th class="FormViewSubHeader" style="height: 21px">
                    <asp:Literal ID="Literal3" runat="server" Text="Get Connected to QuickBooks" /></th>
            </tr>
     <tr id="WelcomeTR" runat="server">
        <td  >
        <p style="font-size: 13px; font-weight: normal;padding: 10px 0px 3px 15px;line-height: 19px;">Welcome! You're either connecting to QuickBooks for first time or your current connection has been expired.</p>
           </td>
               
    </tr>
     <tr id="ConnectToIntuitTR" runat="server">
        <td  >
        <div style="padding:8px">
             <div style="padding: 10px 7.5px;background-color: #efeee6;border: 1px solid #d9d7c4;text-align: center;">
                <ipp:connecttointuit></ipp:connecttointuit>
            </div></div></td>
               
    </tr>
                                <tr>
                                <td >
 <aspToolkit:TabContainer 
                        ID="TBQuickBooks" runat="server" ActiveTabIndex="0" Width="100%" 
                        ScrollBars="Auto" UseVerticalStripPlacement="false" cssclass="MyTabStyle">
                        <aspToolkit:TabPanel ID="TabPanel9" runat="server" HeaderText="Export TimeLive to QuickBooks">
                            <ContentTemplate>
                   
                    <table width="100%" border="0" align="center" cellpadding="5px" cellspacing="5px">
                                      <tr style="vertical-align:middle;height:35px;background-color:#d6dadf">
            <td style="width:35%;border:1px solid #d6dadf;line-height:25px;vertical-align:middle;padding:0px 5px 0px 5px;text-align:center;">
                <span style="color:#006d8d;font-size:13px;font-weight:bold;">Entitiy</span>
            </td>        
            <td style="width:60%;border:1px solid #d6dadf;line-height:25px;vertical-align:middle;padding:0px 5px 0px 5px;text-align:center;">
                <span style="color:#006d8d;font-size:13px;font-weight:bold;">Description</span>
            </td>          
            <td style="width:5%;text-align:center;border:1px solid #d6dadf;vertical-align:middle;padding:0px 5px 0px 5px;">                        
            </td>        
        </tr>
        <tr style="vertical-align:middle;height:60px;background-color:#F6F6F6">
            <td style="width:30%;border:1px solid #d6dadf;line-height:25px;vertical-align:middle;padding:0px 5px 0px 5px;">
                <span style="color:#006d8d;font-size:20px;font-weight:normal;">Clients</span>
            </td>        
            <td style="width:60%;border:1px solid #d6dadf;vertical-align:middle;padding:0px 5px 0px 5px;">        
                <span style="font-size:11px; font-weight:normal; line-height:16px;">Transfer Timelive Client into QuickBooks Customer.</span>
            </td>        
            <td style="width:5%;text-align:center;border:1px solid #d6dadf;vertical-align:middle;padding:0px 5px 0px 5px;">        
                <input id="chkClientExport" runat="server" type="checkbox" class="largerCheckbox" />
                &nbsp;</input></td>        
        </tr>
                <tr style="vertical-align:middle;height:60px;background-color:#F6F6F6">
            <td style="width:30%;border:1px solid #d6dadf;line-height:25px;vertical-align:middle;padding:0px 5px 0px 5px;">
                <span style="color:#006d8d;font-size:20px;font-weight:normal;">Employees</span>
            </td>        
            <td style="width:60%;border:1px solid #d6dadf;vertical-align:middle;padding:0px 5px 0px 5px;">        
                <span style="font-size:11px; font-weight:normal; line-height:16px;">Transfer Timelive Employee into QuickBooks Employee.</span>
            </td>        
            <td style="width:5%;text-align:center;border:1px solid #d6dadf;vertical-align:middle;padding:0px 5px 0px 5px;">        
                <input id="chkEmployeesExport" runat="server" type="checkbox" class="largerCheckbox" />
                &nbsp;</input></td>        
        </tr>
                 <tr style="vertical-align:middle;height:60px;background-color:#F6F6F6">
            <td style="width:30%;border:1px solid #d6dadf;line-height:25px;vertical-align:middle;padding:0px 5px 0px 5px;">
                <span style="color:#006d8d;font-size:20px;font-weight:normal;">Vendors</span>
            </td>        
            <td style="width:60%;border:1px solid #d6dadf;vertical-align:middle;padding:0px 5px 0px 5px;">        
                <span style="font-size:11px; font-weight:normal; line-height:16px;">If you have Vendors that work for you as a contractors, and also want to track their time for export to QuickBooks, check this box. This will export vendor from TimeLive into QuickBooks.</span>
            </td>        
            <td style="width:5%;text-align:center;border:1px solid #d6dadf;vertical-align:middle;padding:0px 5px 0px 5px;">        
                <input id="chkVendorsExport" runat="server" type="checkbox" class="largerCheckbox" />
                &nbsp;</input></td>        
        </tr>
        <tr style="vertical-align:middle;height:60px;background-color:#F6F6F6">
            <td style="width:30%;line-height:25px;vertical-align:middle;padding:0px 5px 0px 5px;" 
                class="withBorder" id="withBorder1" >
                <span style="color:#006d8d;font-size:20px;font-weight:normal;">Project / Task</span>
            </td>        
            <td style="width:60%;vertical-align:middle;padding:0px 5px 0px 5px;" class="withBorder" id="withBorder2" >        
                <span style="font-size:11px; font-weight:normal; line-height:16px;">Transfer Timelive Project/Task into QuickBooks Job/Item.</span>
               </td>        
            <td style="width:5%;text-align:center;vertical-align:middle;padding:0px 5px 0px 5px;" class="withBorder" id="withBorder3" >        
                <input id="chkProjectTaskExport" runat="server" type="checkbox" class="largerCheckbox" />
                &nbsp;</input></td>        
        </tr>
           <tr id="trProjectTaskExport" style="vertical-align:middle;background-color:#F6F6F6;visibility:hidden">
            <td style="width:30%;border-left:1px solid #d6dadf;border-right:1px solid #d6dadf;border-bottom:1px solid #d6dadf;line-height:25px;vertical-align:middle;padding:0px 5px 0px 5px;">
              <div>
                <span style="padding-right:20px;"><asp:RadioButton ID="rdJobItem" runat="server" 
                GroupName="ProjectTask" Checked="True" Text="Job / Items"/></span>
                <span style="padding-right:20px;"><asp:RadioButton ID="rdJobSubJob" runat="server" GroupName="ProjectTask" Text="Job / Sub-Job" /></span> 
                <span><asp:RadioButton ID="rdItemSubItem" runat="server" GroupName="ProjectTask" Text="Item / Sub-Item" /></span>
              </div>
            </td>        
            <td style="width:60%;border-left:1px solid #d6dadf;border-right:1px solid #d6dadf;border-bottom:1px solid #d6dadf;vertical-align:middle;padding:0px 5px 0px 5px;">
              
            </td>        
            <td style="width:5%;text-align:center;border-left:1px solid #d6dadf;border-right:1px solid #d6dadf;border-bottom:1px solid #d6dadf;vertical-align:middle;padding:0px 5px 0px 5px;">        
            </td>        
        </tr>
         <tr style="vertical-align:middle;height:60px;background-color:#F6F6F6">
            <td style="width:30%;line-height:25px;vertical-align:middle;padding:0px 5px 0px 5px;" 
                 class="withBorder" id="tsWithBorder1" >
                <span style="color:#006d8d;font-size:20px;font-weight:normal;">Time Entries</span>
            </td>        
            <td style="width:60%;vertical-align:middle;padding:0px 5px 0px 5px;" class="withBorder" id="tsWithBorder2" >        
                <span style="font-size:11px; font-weight:normal; line-height:16px;">Transfer Timelive Time Entries into QuickBooks Time Activity.</span>
            </td>        
            <td style="width:5%;text-align:center;vertical-align:middle;padding:0px 5px 0px 5px;" class="withBorder" id="tsWithBorder3" >        
                <input id="chkTimeEntryExport" runat="server" type="checkbox" class="largerCheckbox" />
                &nbsp;</input></td>        
        </tr>
         <tr id="trTimeEntryExport" style="vertical-align:middle;background-color:#F6F6F6">
            <td style="width:30%;border-left:1px solid #d6dadf;border-right:1px solid #d6dadf;border-bottom:1px solid #d6dadf;line-height:25px;vertical-align:middle;padding:0px 5px 0px 5px;">
              <span>Employees: </span>
              <asp:DropDownList ID="ddlEmployees" runat="server" Width="200px" class="selectdrop"></asp:DropDownList>
              <div style="padding:4px 0px 0px 0px;">
              <span>From Date: </span>
              <ew:CalendarPopup ID="StartTimeTextBox" runat="server" SkinId="DatePicker" 
                      Width="55px" SelectedDate="10/03/2015 15:40:25" 
                      SelectedValue="10/03/2015 15:40:25" VisibleDate="10/03/2015 15:40:25"></ew:CalendarPopup>
              </div>
              <div style="padding:4px 0px 0px 0px;">
              <span>Upto Date:   </span>
              <ew:CalendarPopup ID="EndTimeTextBox" runat="server" SkinId="DatePicker" 
                      Width="55px" SelectedDate="10/03/2015 15:40:25" 
                      SelectedValue="10/03/2015 15:40:25" VisibleDate="10/03/2015 15:40:25"></ew:CalendarPopup>
              </div>
            </td>        
            <td style="width:60%;border-left:1px solid #d6dadf;border-right:1px solid #d6dadf;border-bottom:1px solid #d6dadf;vertical-align:middle;padding:0px 5px 0px 5px;">
              
            </td>        
            <td style="width:5%;text-align:center;border-left:1px solid #d6dadf;border-right:1px solid #d6dadf;border-bottom:1px solid #d6dadf;vertical-align:middle;padding:0px 5px 0px 5px;">        
            </td>        
        </tr>

                                    <tr>
                                     <td colspan="3" 
                                            style="height: 22px; text-align:right;padding: 6px 4px 6px 0px;border: 1px solid #d6dadf;">
                                       <asp:Button ID="btnExport" runat="server" Text="Export " style="width: 100px;height: 45px;" />
                                       <div><asp:Label ID="lblExceptionExport" runat="server" CssClass="ErrorMessage" Font-Bold="True" Font-Names="Tahoma" Font-Size="Medium"></asp:Label></div>
                                        </td>
                                    </tr>

                           </table> 
                          
                            </ContentTemplate>
                      </aspToolkit:TabPanel>
                       <aspToolkit:TabPanel ID="TabPanel1" runat="server" HeaderText="Import QuickBooks to TimeLive">
                            <ContentTemplate>
                            
                      <table width="100%" border="0" align="center" cellpadding="5px" cellspacing="5px">
                                      <tr style="vertical-align:middle;height:35px;background-color:#d6dadf">
            <td colspan=2 style="width:35%;border:1px solid #d6dadf;line-height:25px;vertical-align:middle;padding:0px 5px 0px 5px;text-align:center;">
                <span style="color:#006d8d;font-size:13px;font-weight:bold;">Entitiy</span>
            </td>        
            <td style="width:60%;border:1px solid #d6dadf;line-height:25px;vertical-align:middle;padding:0px 5px 0px 5px;text-align:center;">
                <span style="color:#006d8d;font-size:13px;font-weight:bold;">Description</span>
            </td>          
            <td style="width:5%;text-align:center;border:1px solid #d6dadf;vertical-align:middle;padding:0px 5px 0px 5px;">                        
            </td>        
        </tr>
        <tr style="vertical-align:middle;height:60px;background-color:#F6F6F6">
          <%--  <td style="width:5%;text-align:center;border:1px solid #d6dadf;vertical-align:middle;padding:0px 5px 0px 5px;">        
              <img src="../img/timesheetnew.png"/>
            </td>  --%>      
            <td  colspan="2" style="width:30%;border:1px solid #d6dadf;line-height:25px;vertical-align:middle;padding:0px 5px 0px 5px;">
                <span style="color:#006d8d;font-size:20px;font-weight:normal;">Customers</span>
            </td>        
            <td style="width:60%;border:1px solid #d6dadf;vertical-align:middle;padding:0px 5px 0px 5px;">        
                <span style="font-size:11px; font-weight:normal; line-height:16px;">Transfer QuickBooks Customer into TimeLive Client.</span>
            </td>        
            <td style="width:5%;text-align:center;border:1px solid #d6dadf;vertical-align:middle;padding:0px 5px 0px 5px;">        
                <input id="chkCustomersImport" runat="server" type="checkbox" class="largerCheckbox" name="checkBox" />
            </td>        
        </tr>
                <tr style="vertical-align:middle;height:60px;background-color:#F6F6F6">
<%--            <td style="width:5%;text-align:center;border:1px solid #d6dadf;vertical-align:middle;padding:0px 5px 0px 5px;">        
              <img src="../img/expense.png"/>
            </td>   --%>     
            <td colspan="2" style="width:30%;border:1px solid #d6dadf;line-height:25px;vertical-align:middle;padding:0px 5px 0px 5px;">
                <span style="color:#006d8d;font-size:20px;font-weight:normal;">Employees</span>
            </td>        
            <td style="width:60%;border:1px solid #d6dadf;vertical-align:middle;padding:0px 5px 0px 5px;">        
                <span style="font-size:11px; font-weight:normal; line-height:16px;">Transfer QuickBooks Employee into TimeLive Employee.</span>
            </td>        
            <td style="width:5%;text-align:center;border:1px solid #d6dadf;vertical-align:middle;padding:0px 5px 0px 5px;">        
                <input id="chkEmployeesImport" runat="server" type="checkbox" class="largerCheckbox" name="checkBox" />
            </td>        
        </tr>
                 <tr style="vertical-align:middle;height:60px;background-color:#F6F6F6">
          <%--  <td style="width:5%;text-align:center;border:1px solid #d6dadf;vertical-align:middle;padding:0px 5px 0px 5px;">        
              <img src="../img/timeoffnew.png"/>
            </td>    --%>    
            <td   colspan="2" style="width:30%;border:1px solid #d6dadf;line-height:25px;vertical-align:middle;padding:0px 5px 0px 5px;">
                <span style="color:#006d8d;font-size:20px;font-weight:normal;">Vendors</span>
            </td>        
            <td style="width:60%;border:1px solid #d6dadf;vertical-align:middle;padding:0px 5px 0px 5px;">        
                <span style="font-size:11px; font-weight:normal; line-height:16px;">If you have Vendors that work for you as a contractors, and also want to track their time for export to QuickBooks, check this box. This will export vendor from QuickBooks into TimeLive.</span>
            </td>        
            <td style="width:5%;text-align:center;border:1px solid #d6dadf;vertical-align:middle;padding:0px 5px 0px 5px;">        
                <input id="chkVendorsImport" runat="server" type="checkbox" class="largerCheckbox" name="checkBox" />
            </td>        
        </tr>
        <tr style="vertical-align:middle;height:60px;background-color:#F6F6F6">
         <%--   <td style="width:5%;text-align:center;border:1px solid #d6dadf;vertical-align:middle;padding:0px 5px 0px 5px;">        
              <img src="../img/billing.png"/>
            </td> --%>       
            <td colspan="2" style="width:30%;line-height:25px;vertical-align:middle;padding:0px 5px 0px 5px;" class="withBorder" id="withBorderImport1" >
                <span style="color:#006d8d;font-size:20px;font-weight:normal;">Job / Item</span>
            </td>        
            <td style="width:60%;vertical-align:middle;padding:0px 5px 0px 5px;" class="withBorder" id="withBorderImport2" >        
                <span style="font-size:11px; font-weight:normal; line-height:16px;">Transfer QuickBooks Job/Item into Timelive Project/Task.</span>
               <%-- <div>
                <span style="padding-right:20px;"><asp:RadioButton ID="rdJobItem" runat="server" 
                                                GroupName="ProjectTask" Checked="True" Text="Job / Items"/></span>
                                       <span style="padding-right:20px;"><asp:RadioButton ID="rdJobSubJob" runat="server" GroupName="ProjectTask" Text="Job / Sub-Job" /></span> 
                                       <span><asp:RadioButton ID="rdItemSubItem" runat="server" GroupName="ProjectTask" Text="Item / Sub-Item" /></span></div>--%>
            </td>        
            <td style="width:5%;text-align:center;vertical-align:middle;padding:0px 5px 0px 5px;" class="withBorder" id="withBorderImport3" >        
                <input id="chkProjectTaskImport" runat="server" type="checkbox" class="largerCheckbox" name="checkBox" />
            </td>        
        </tr>
           <tr id="trProjectTaskImport" style="vertical-align:middle;background-color:#F6F6F6" runat="server">
         <%--   <td style="width:5%;text-align:center;border:0px solid #d6dadf;vertical-align:middle;padding:0px 5px 0px 5px;">        
            </td>  --%>      
            <td colspan="2" style="width:30%;border-left:1px solid #d6dadf;border-right:1px solid #d6dadf;border-bottom:1px solid #d6dadf;line-height:25px;vertical-align:middle;padding:0px 5px 0px 5px;">
              <div>
<%--                <span style="padding-right:20px;"><asp:RadioButton ID="rdJobItemImport" runat="server" 
                                                GroupName="ProjectTask" Checked="True" Text="Job / Items"/></span>--%>
                                       <span style="padding-right:20px;"><asp:RadioButton ID="rdJobSubJobImport" runat="server" GroupName="ProjectTask" Text="Job / Sub-Job" /></span> 
                                       <span><asp:RadioButton ID="rdItemSubItemImport" runat="server" GroupName="ProjectTask" Text="Item / Sub-Item" /></span></div>
            </td>        
            <td style="width:60%;border-left:1px solid #d6dadf;border-right:1px solid #d6dadf;border-bottom:1px solid #d6dadf;vertical-align:middle;padding:0px 5px 0px 5px;">
              
            </td>        
            <td style="width:5%;text-align:center;border-left:1px solid #d6dadf;border-right:1px solid #d6dadf;border-bottom:1px solid #d6dadf;vertical-align:middle;padding:0px 5px 0px 5px;">        
            </td>        
        </tr>
                                    <tr>
                                     <td colspan="4" style="height: 22px; text-align:right;padding: 6px 4px 6px 0px;border: 1px solid #d6dadf;">
                                       <%--<button id="btnImport" runat="server" type="submit" class="button green-gradient" style="width: 100px;height: 45px;">Import</button>--%>
                                       <asp:Button ID="btnImport" runat="server" Text="Import " style="width: 100px;height: 45px;" />
                                       <div><asp:Label ID="lblExceptionImport" runat="server" CssClass="ErrorMessage" Font-Bold="True" Font-Names="Tahoma" Font-Size="Medium"></asp:Label></div>
                                        </td>
                                    </tr>

                           </table> 
                            </ContentTemplate>
                      </aspToolkit:TabPanel>
                      </aspToolkit:TabContainer> 
                      </td> </tr>  <tr>
                                        <th style="text-align:right; padding-left:10px;" class="FormViewSubHeader">
                                        <span style="font-size:11px; font-weight: 200;">LOG REPORT:</span>
                                        <a onclick="javascript:window.open(this.href,'mywin','width=1000,height=600,left=230,top=100,scrollbars=yes');return false;" style="font-size:11px; font-weight: 800; color:#006d8d; padding-right:5px" href="./AccountQBoLog.aspx">VIEW</a>
                                         <span style="font-size:11px; font-weight: 200;">STATUS:</span> 
                                         <span style="font-size:11px; font-weight: 800; color:red; padding-right:5px" id="lblstatusred" runat="server"></span>
                                         <span style="font-size:11px; font-weight: 800; color:green; padding-right:5px" id="lblstatusgreen" runat="server"></span>
                                        </th>
                                    </tr></table> 
                      </td> </tr> </table> 
                      </ContentTemplate>
</asp:UpdatePanel>
<script src="<%= Page.ResolveUrl("~/js/libs/jquery-1.7.2.min.js") %>"></script>
<script>
    function pageLoad() {
        $('#trProjectTaskExport').hide();
        if ($('#chkTimeEntryExport')[0].checked == true) {
            $('#trTimeEntryExport').show();
            $('#tsWithBorder1').removeClass('withBorder');
            $('#tsWithBorder1').addClass('withoutBottomBorder');
            $('#tsWithBorder2').removeClass('withBorder');
            $('#tsWithBorder2').addClass('withoutBottomBorder');
            $('#tsWithBorder3').removeClass('withBorder');
            $('#tsWithBorder3').addClass('withoutBottomBorder');
        }
        else {
            $('#trTimeEntryExport').hide();
        }
        if ($('#chkProjectTaskImport')[0].checked == true) {
            $('#trProjectTaskImport').show();
            $('#withBorderImport1').removeClass('withBorder');
            $('#withBorderImport1').addClass('withoutBottomBorder');
            $('#withBorderImport2').removeClass('withBorder');
            $('#withBorderImport2').addClass('withoutBottomBorder');
            $('#withBorderImport3').removeClass('withBorder');
            $('#withBorderImport3').addClass('withoutBottomBorder');
        }
        else {
            $('#trProjectTaskImport').hide();
        }
        $('#chkTimeEntryExport').on('click', function () {
            if (this.checked == true) {
                $('#trTimeEntryExport').show();
                $('#tsWithBorder1').removeClass('withBorder');
                $('#tsWithBorder1').addClass('withoutBottomBorder');
                $('#tsWithBorder2').removeClass('withBorder');
                $('#tsWithBorder2').addClass('withoutBottomBorder');
                $('#tsWithBorder3').removeClass('withBorder');
                $('#tsWithBorder3').addClass('withoutBottomBorder');
            }
            else {
                $('#trTimeEntryExport').hide();
            }
        });
        $('#chkProjectTaskImport').on('click', function () {
            if (this.checked == true) {
                $('#trProjectTaskImport').show();
                $('#withBorderImport1').removeClass('withBorder');
                $('#withBorderImport1').addClass('withoutBottomBorder');
                $('#withBorderImport2').removeClass('withBorder');
                $('#withBorderImport2').addClass('withoutBottomBorder');
                $('#withBorderImport3').removeClass('withBorder');
                $('#withBorderImport3').addClass('withoutBottomBorder');
            }
            else {
                $('#trProjectTaskImport').hide();
            }
        });
    };
	</script>