<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlAccountEmployeeTimeEntryForm.ascx.vb" Inherits="Mobile_Controls_ctlAccountEmployeeTimeEntryForm" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc2" %>
<%@ Register Assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24D65337282035F2"
    Namespace="eWorld.UI" TagPrefix="ew" %>
 <div data-role="header" data-theme="a" >
       <h1 style="text-align:left;margin-left:15px;" >Timesheet</h1>
</div>
     <div data-role="content" data-theme="d">
     
    	  <ul data-role="listview" > 
	 		<li data-role="fieldcontain"> 
			<asp:Label id="Label1" runat="server" Text="Date:" Font-Bold="True" Font-Names="Tahoma" Font-Size="11px"></asp:Label>
			<ew:CalendarPopup id="txtTimeEntryDate" CalendarWidth="200" runat="server" Width="95px" ControlDisplay="TextBoxImage" ImageUrl="~/Images/spacer.gif" Text="" Height="25px" PopupLocation="top" DisplayOffsetY="35" >
            </ew:CalendarPopup>
    		</li> 
    		<% If DBUtilities.GetShowClientInTimesheet Then %>
			<li data-role="fieldcontain" > 
            <asp:Label id="Label2" runat="server" Text="Client:" Font-Bold="True" Font-Names="Tahoma" Font-Size="11px"></asp:Label>
			<asp:DropDownList id="ddlAccountClientId" runat="server" DataSourceID="dsAccountClientObject" DataTextField="PartyName" DataValueField="AccountPartyId" AutoPostBack="True" ></asp:DropDownList>
            </li> 
            <% End If%>
			<li data-role="fieldcontain"> 
			<asp:Label id="Label3" runat="server" Text="Project:" Font-Bold="True" Font-Names="Tahoma" Font-Size="11px"></asp:Label>
			<asp:DropDownList ID="ddlAccountProjectId" runat="server" DataSourceID="dsAccountProjectObject" DataTextField="ProjectName" DataValueField="AccountProjectId" AutoPostBack="True" ></asp:DropDownList>
			</li> 
			<li data-role="fieldcontain"> 
			<asp:Label id="Label4" runat="server" Text="Task:" Font-Bold="True" Font-Names="Tahoma" Font-Size="11px"></asp:Label>
			<asp:DropDownList id="ddlAccountProjectTaskId" runat="server" DataSourceID="dsAccountProjectTasksObject" DataTextField="TaskName" DataValueField="AccountProjectTaskId" ></asp:DropDownList>
			</li> 
			 <%If DBUtilities.IsShowWorkTypeInTimeSheet Then%>
			<li data-role="fieldcontain"> 
			<asp:Label id="Label5" runat="server" Text="Work Type:" Font-Bold="True" Font-Names="Tahoma" Font-Size="11px"></asp:Label>
			<asp:DropDownList id="ddlAccountWorkTypeId" runat="server" DataSourceID="dsAccountWorkTypeObject" DataTextField="AccountWorkType" DataValueField="AccountWorkTypeId"></asp:DropDownList>
			</li> 
			<% End If%>
			<%If DBUtilities.GetClockStartEndBy = "Account" Then%>
            <% If DBUtilities.GetShowClockStartEnd Then %>
		    <li data-role="fieldcontain"> 
            <asp:Label id="Label6" runat="server" Text="Start Time:" Font-Bold="True" Font-Names="Tahoma" Font-Size="11px"></asp:Label>
			<asp:TextBox id="StartTime" runat="server" Width="70px" ValidationGroup="TimeEntry" onchange="javascript:OnTimeChange(this);"></asp:TextBox><cc2:MaskedEditExtender id="MaskedEditExtenderStartTime" runat="server" AutoCompleteValue="00:00" AutoComplete="true" AcceptAMPM="true" MaskType="Time" Mask="99:99 " TargetControlID="StartTime"></cc2:MaskedEditExtender> <cc2:MaskedEditValidator id="MaskedEditValidatorStartTime" runat="server" ValidationGroup="TimeEntry" Display="Dynamic" InvalidValueMessage="Invalid Time" EmptyValueMessage="*" IsValidEmpty="true" ControlToValidate="StartTime" ControlExtender="MaskedEditExtenderStartTime"></cc2:MaskedEditValidator>
            </li> 
			<li data-role="fieldcontain"> 
			<asp:Label id="Label7" runat="server" Text="End Time:" Font-Bold="True" Font-Names="Tahoma" Font-Size="11px"></asp:Label>
			<asp:TextBox id="EndTime" runat="server" Width="70px" ValidationGroup="TimeEntry" onchange="javascript:OnTimeChange(this);"></asp:TextBox><cc2:MaskedEditExtender id="MaskedEditExtenderEndTime" runat="server" TargetControlID="EndTime" Mask="99:99 " MaskType="Time" AcceptAMPM="true" AutoComplete="true" AutoCompleteValue="00:00"></cc2:MaskedEditExtender> <cc2:MaskedEditValidator id="MaskedEditValidatorEndTime" runat="server" ValidationGroup="TimeEntry" ControlExtender="MaskedEditExtenderEndTime" ControlToValidate="EndTime" IsValidEmpty="true" EmptyValueMessage="*" InvalidValueMessage="Invalid Time" Display="Dynamic"></cc2:MaskedEditValidator>
			</li> 
			<% End If%>
            <%Else%>
            <% If DBUtilities.ShowClockStartEndEmployee  Then %>
		    <li data-role="fieldcontain"> 
            <asp:Label id="Label10" runat="server" Text="Start Time:" Font-Bold="True" Font-Names="Tahoma" Font-Size="11px"></asp:Label>
			<asp:TextBox id="TextBox1" runat="server" Width="70px" ValidationGroup="TimeEntry" onchange="javascript:OnTimeChange(this);"></asp:TextBox><cc2:MaskedEditExtender id="MaskedEditExtender1" runat="server" AutoCompleteValue="00:00" AutoComplete="true" AcceptAMPM="true" MaskType="Time" Mask="99:99 " TargetControlID="StartTime"></cc2:MaskedEditExtender> <cc2:MaskedEditValidator id="MaskedEditValidator1" runat="server" ValidationGroup="TimeEntry" Display="Dynamic" InvalidValueMessage="Invalid Time" EmptyValueMessage="*" IsValidEmpty="true" ControlToValidate="StartTime" ControlExtender="MaskedEditExtenderStartTime"></cc2:MaskedEditValidator>
            </li> 
			<li data-role="fieldcontain"> 
			<asp:Label id="Label11" runat="server" Text="End Time:" Font-Bold="True" Font-Names="Tahoma" Font-Size="11px"></asp:Label>
			<asp:TextBox id="TextBox2" runat="server" Width="70px" ValidationGroup="TimeEntry" onchange="javascript:OnTimeChange(this);"></asp:TextBox><cc2:MaskedEditExtender id="MaskedEditExtender2" runat="server" TargetControlID="EndTime" Mask="99:99 " MaskType="Time" AcceptAMPM="true" AutoComplete="true" AutoCompleteValue="00:00"></cc2:MaskedEditExtender> <cc2:MaskedEditValidator id="MaskedEditValidator2" runat="server" ValidationGroup="TimeEntry" ControlExtender="MaskedEditExtenderEndTime" ControlToValidate="EndTime" IsValidEmpty="true" EmptyValueMessage="*" InvalidValueMessage="Invalid Time" Display="Dynamic"></cc2:MaskedEditValidator>
			</li> 
			<% End If%>
            <% End If%> 
			<li data-role="fieldcontain"> 
			<asp:Label id="Label8" runat="server" Text="Total Time:" Font-Bold="True" Font-Names="Tahoma" Font-Size="11px"></asp:Label>
			<asp:TextBox id="TotalTime" runat="server" Width="70px" ValidationGroup="TimeEntry" onchange="javascript:UpdateSum();"></asp:TextBox><cc2:MaskedEditExtender id="MaskedEditExtenderTotalTime" runat="server" TargetControlID="TotalTime" Mask="99:99 " MaskType="Time" AcceptAMPM="false" AutoComplete="true" AutoCompleteValue="00:00"></cc2:MaskedEditExtender> <cc2:MaskedEditValidator id="MaskedEditValidatorTotalTime" runat="server" ValidationGroup="TimeEntry" ControlExtender="MaskedEditExtenderTotalTime" ControlToValidate="TotalTime" IsValidEmpty="true" EmptyValueMessage="*" InvalidValueMessage="Invalid Time" Display="Dynamic"></cc2:MaskedEditValidator>
			</li> 
			<li data-role="fieldcontain"> 
			<asp:Label id="Label9" runat="server" Text="Description:" Font-Bold="True" Font-Names="Tahoma" Font-Size="11px"></asp:Label>
			<asp:TextBox id="Description" runat="server" Width="100%" Text='<%# Bind("Description") %>' Height="80px" TextMode="MultiLine" MaxLength="500"></asp:TextBox>
			</li> 
			<li data-role="fieldcontain"> 
			<asp:Button ID="btnSave" runat="server" Text="Save" UseSubmitBehavior ="false" ValidationGroup="TimeEntry" data-inline="true" />
            <asp:Button ID="btnCancel" runat="server" Text="Cancel" UseSubmitBehavior ="false" data-inline="true" />
			</li> 
		</ul>

         <%--<table >
             <tr>
                 <td align="right" style="width: 5%">
                             Date:
                         </td>
                         <td style="width: 95%">
                             Date:<br />
                          <ew:CalendarPopup id="txtTimeEntryDate" runat="server" Width="85px" ControlDisplay="TextBoxImage" ImageUrl="~/Images/spacer.gif" Text="" Height="18px" PopupLocation="Bottom" >
                        </ew:CalendarPopup>
                         </td>
                     </tr>
                     <% If DBUtilities.GetShowClientInTimesheet Then %>
                     <tr>
                         <td align="right" style="width: 5%">
                             Client: </td>
                         <td style="width: 95%">
<asp:DropDownList id="ddlAccountClientId" runat="server" Width="50px" DataSourceID="dsAccountClientObject" DataTextField="PartyName" DataValueField="AccountPartyId" AutoPostBack="True" ></asp:DropDownList></td>
                     </tr>
                     <% End If %>
                     <tr>
                         <td align="right" style="width: 5%">
                             Projects:
                         </td>
                         <td style="width: 95%">
<asp:DropDownList ID="ddlAccountProjectId" runat="server" DataSourceID="dsAccountProjectObject"
    DataTextField="ProjectName" DataValueField="AccountProjectId" AutoPostBack="True" Width="50px">
</asp:DropDownList></td>
                     </tr>
                     <tr>
                         <td align="right" style="width: 5%">
                             Task:
                         </td>
                         <td style="width: 95%">
<asp:DropDownList id="ddlAccountProjectTaskId" Width="50px" runat="server" DataSourceID="dsAccountProjectTasksObject" DataTextField="TaskName" DataValueField="AccountProjectTaskId" ></asp:DropDownList></td>
                     </tr>
                      <% If DBUtilities.IsShowWorkTypeInTimeSheet Then %>
                     <tr>
                         <td align="right" style="width: 5%">
                             Work Type:
                         </td>
                         <td style="width: 95%">
                         <asp:DropDownList id="ddlAccountWorkTypeId" Width="50px" runat="server" DataSourceID="dsAccountWorkTypeObject" DataTextField="AccountWorkType" DataValueField="AccountWorkTypeId"></asp:DropDownList></td>
                     </tr>
                     <% End If %>
                     <% If DBUtilities.GetShowClockStartEnd Then %>
                     <tr>
                         <td align="right" style="width: 5%">
                             Start Time:
                         </td>
                         <td style="width: 95%">
<asp:TextBox id="StartTime" runat="server" Width="70px" ValidationGroup="TimeEntry" onchange="javascript:OnTimeChange(this);"></asp:TextBox><cc2:MaskedEditExtender id="MaskedEditExtenderStartTime" runat="server" AutoCompleteValue="00:00" AutoComplete="true" AcceptAMPM="true" MaskType="Time" Mask="99:99 " TargetControlID="StartTime"></cc2:MaskedEditExtender> <cc2:MaskedEditValidator id="MaskedEditValidatorStartTime" runat="server" ValidationGroup="TimeEntry" Display="Dynamic" InvalidValueMessage="Invalid Time" EmptyValueMessage="*" IsValidEmpty="true" ControlToValidate="StartTime" ControlExtender="MaskedEditExtenderStartTime"></cc2:MaskedEditValidator></td>
                     </tr>
                     <tr>
                         <td align="right" style="width: 5%">
                             End Time:
                         </td>
                         <td style="width: 95%">
<asp:TextBox id="EndTime" runat="server" Width="70px" ValidationGroup="TimeEntry" onchange="javascript:OnTimeChange(this);"></asp:TextBox><cc2:MaskedEditExtender id="MaskedEditExtenderEndTime" runat="server" TargetControlID="EndTime" Mask="99:99 " MaskType="Time" AcceptAMPM="true" AutoComplete="true" AutoCompleteValue="00:00"></cc2:MaskedEditExtender> <cc2:MaskedEditValidator id="MaskedEditValidatorEndTime" runat="server" ValidationGroup="TimeEntry" ControlExtender="MaskedEditExtenderEndTime" ControlToValidate="EndTime" IsValidEmpty="true" EmptyValueMessage="*" InvalidValueMessage="Invalid Time" Display="Dynamic"></cc2:MaskedEditValidator></td>
                     </tr>
                      <% End If  %>
                     <tr>
                         <td align="right" style="width: 5%">
                             Total Time:
                         </td>
                         <td style="width: 95%">
<asp:TextBox id="TotalTime" runat="server" Width="70px" ValidationGroup="TimeEntry" onchange="javascript:UpdateSum();"></asp:TextBox><cc2:MaskedEditExtender id="MaskedEditExtenderTotalTime" runat="server" TargetControlID="TotalTime" Mask="99:99 " MaskType="Time" AcceptAMPM="false" AutoComplete="true" AutoCompleteValue="00:00"></cc2:MaskedEditExtender> <cc2:MaskedEditValidator id="MaskedEditValidatorTotalTime" runat="server" ValidationGroup="TimeEntry" ControlExtender="MaskedEditExtenderTotalTime" ControlToValidate="TotalTime" IsValidEmpty="true" EmptyValueMessage="*" InvalidValueMessage="Invalid Time" Display="Dynamic"></cc2:MaskedEditValidator></td>
                     </tr>
                     <tr>
                         <td align="right" style="width: 5%">
                             Description:
                         </td>
                         <td style="width: 95%">
<asp:TextBox id="Description" runat="server" Width="100%" Text='<%# Bind("Description") %>' Height="80px" TextMode="MultiLine" MaxLength="500"></asp:TextBox></td>
                     </tr>
                     <tr>
                         <td align="right" style="width: 5%">
                         </td>
                         <td style="width: 95%">
                             <asp:Button ID="btnSave" runat="server" Text="Save" UseSubmitBehavior ="false" data-inline="true" />
                             <asp:Button ID="btnCancel" runat="server" Text="Cancel" UseSubmitBehavior ="false" data-inline="true" /></td>
                     </tr>
                 </table>--%>
                 <asp:ObjectDataSource id="dsAccountClientObject" runat="server" TypeName="AccountPartyBLL" SelectMethod="GetAccountPartiesForTimeEntryByAccountEmployeeId" OldValuesParameterFormatString="original_{0}"><SelectParameters>
<asp:SessionParameter SessionField="AccountEmployeeId" Type="Int32" Name="AccountEmployeeId"></asp:SessionParameter>
                     <asp:Parameter Name="AccountClientId" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource> <asp:ObjectDataSource ID="dsAccountProjectObject" runat="server" OldValuesParameterFormatString="original_{0}"
    SelectMethod="GetAccountProjectsForMobile"
    TypeName="AccountProjectBLL">
    <SelectParameters>
        <asp:Parameter Name="AccountProjectId" Type="Int32" />
        <asp:SessionParameter Name="AccountEmployeeId" SessionField="AccountEmployeeId" Type="Int32" />
        <asp:ControlParameter ControlID="ddlAccountClientId" Name="AccountClientId" PropertyName="SelectedValue"
            Type="Int32" />
        <asp:SessionParameter Name="AccountId" SessionField="AccountId" Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>
<asp:ObjectDataSource id="dsAccountProjectTasksObject" runat="server" TypeName="AccountProjectTaskBLL" OldValuesParameterFormatString="original_{0}" SelectMethod="GetAssignedProjectTasksFromvueAccountProjectTask"><SelectParameters>
<asp:ControlParameter PropertyName="SelectedValue" Type="Int32" Name="AccountProjectId" ControlID="ddlAccountProjectId"></asp:ControlParameter>
<asp:SessionParameter SessionField="AccountEmployeeId" Type="Int32" DefaultValue="39" Name="AccountEmployeeId"></asp:SessionParameter>
    <asp:Parameter Name="AccountProjectTaskId" Type="Int32" />
    <asp:SessionParameter DefaultValue="" Name="AccountId" SessionField="AccountId" Type="Int32" />
    <asp:Parameter Name="Completed" Type="Boolean" />
</SelectParameters>
</asp:ObjectDataSource>
 
           
<asp:ObjectDataSource id="dsAccountWorkTypeObject" runat="server" TypeName="AccountWorkTypeBLL" SelectMethod="GetAccountWorkTypesByAccountIdAndIsDisabled" OldValuesParameterFormatString="original_{0}"><SelectParameters>
<asp:SessionParameter SessionField="AccountId" Type="Int32" DefaultValue="99" Name="AccountId"></asp:SessionParameter>
<asp:Parameter Type="Int32" Name="AccountWorkTypeId"></asp:Parameter>
</SelectParameters>
</asp:ObjectDataSource> 
 
           
</div> 

 <script language="javascript">
    // This function should iterate through all the TextBoxes and get the values 
function UpdateSum() {      
        var tBox; 
        var sumTextBox;
        
        // clear the sum variable 
       var sumMinutes = 0; 
        // Iterate through all the TextBoxes
        tBox = document.getElementsByTagName("INPUT"); 
        var IsMinutes = false;
        for(i = 0; i< (tBox.length - 2) ; i++) 
        {                   
           if(tBox[i].type == "text") 
           {
              if(tBox[i].id.indexOf('sumTime') > 0) {
                sumTextBox =  tBox[i];
              }
              if(tBox[i].id.indexOf('TotalTime') > 0) 
              {
                // The Number function forces the JavaScript to recognizes the input as a number 
                textValue = tBox[i].value;
                if (textValue.indexOf(':') > 0) {
                   IsMinutes = true;
                }
                minutesValue = GetTotalMinutesOfTime(textValue);
                sumMinutes += Number(minutesValue);
                }       
            } 
        }       
    var h = Math.floor(sumMinutes / 60);
    if (sumTextBox != null) {
        sumTextBox.value =  padl(h,2,'0')
        if (IsMinutes == true) {
            sumTextBox.value = sumTextBox.value + ':' + padl((sumMinutes - (h * 60)),2,'0');
         }
    }
}
function padl(n, w, c) {
    n = String(n);
    while (n.length < w)
        n = c + n;
    return n;
}
function GetTimeFromMinutes(minutes, IsMinutes) {
    var h = Math.floor(minutes / 60);
    valueToReturn = padl(h,2,'0');
    if (IsMinutes == true) {
        valueToReturn = valueToReturn + ':' + padl((minutes - (h * 60)),2,'0');
    }
    return  valueToReturn
}
function GetTotalMinutesOfTime(timeValue) {

    if (timeValue == '') {
        return 0;
    }
    if (timeValue.substring(1,2) == '_') {
        timeValue = '0' + timeValue.substring(0,1) + timeValue.substring(2) 
    }
    timeValue = timeValue.replace('_','0')
    minutesValue = timeValue.substring(0,2) * 60 
    if (timeValue.indexOf(':') > 0) {
            minutesValue = parseInt(minutesValue) + Number(timeValue.substring(3,6))
    }
    if (timeValue.indexOf('PM') > 0) {
        if (timeValue.indexOf('12') != -1) {
            if (timeValue.indexOf('12') != 3) {
            minutesValue = minutesValue - (12 * 60); 
            }
        }
        minutesValue = minutesValue + (12 * 60);           
     }
     if (timeValue.indexOf('AM') > 0) {
        if (timeValue.indexOf('12') != -1) {
            if (timeValue.indexOf('12') != 3) {
            minutesValue = minutesValue - (12 * 60); 
            }
        }
     }
    return minutesValue ;
}
function OnTimeChange(targetObject) {
    targetId = targetObject.id;
    if (targetId.indexOf("StartTime") > 0 )  {
        StartTime = targetObject.value;
        otherId = targetId.replace("StartTime","EndTime") ;
        otherobj = window.document.getElementById(otherId);
        EndTime = otherobj.value;
        TotalTimeId = targetId.replace("StartTime","TotalTime") ;
    }
    else
    {
        EndTime = targetObject.value;
        otherId = targetId.replace("EndTime","StartTime") ; 
        otherobj = window.document.getElementById(otherId);
        StartTime = otherobj.value;
        TotalTimeId = targetId.replace("EndTime","TotalTime") ;
    }
    objEndTime = window.document.getElementById(TotalTimeId);
    minStartTime = GetTotalMinutesOfTime(StartTime);
    minEndTime = GetTotalMinutesOfTime(EndTime);
    if (minEndTime == 0) {
        return
     }
    if (minStartTime > minEndTime) {
        minEndTime = minEndTime + (24*60)
        }
    minTotalTime = minEndTime - minStartTime ;
    if (StartTime.indexOf(':') > 0) {
        IsMinutes = true;
     } else {
        IsMinutes = false;
     }
    strTotalTime = GetTimeFromMinutes(minTotalTime, IsMinutes);
    objEndTime.value = strTotalTime;
    UpdateSum() ;
    }   
    
function replaceAll( str, from, to ) {
    var idx = str.indexOf( from );
    while ( idx > -1 ) {
        str = str.replace( from, to ); 
        idx = str.indexOf( from );
    }
    return str;
}
    </script>