<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlAccountEmployeeTimeOffRequestSubmit.ascx.vb" Inherits="Employee_Controls_ctlAccountEmployeeTimeOffRequestSubmit" %>


<br />
<br />
<div style="display:table; margin-left:auto ; margin-right:auto"  >
    <div style="display: table-row; " >
        <div style="display: table-cell; vertical-align: middle ;  " >
            <asp:Literal runat="server"  ID="ltlSubmitTimeOff" Text ="<%$ Resources:TimeLive.Resource, Submit TimeOff %>"></asp:Literal>
        </div>
         <asp:HiddenField runat ="server" ID="TimeOffRequesId" Value ="none" />
    </div>
    

</div>
<br />
<br />
<div style="display:table; margin-left:auto ; margin-right:auto">
    <div style="display: table-row; " >
        <div style="display: table-cell; vertical-align: middle;" >
            <asp:Button ID="BtnSubmitTimeOff" runat="server" OnClick ="TimeOffRequestSubmit" OnClientClick="disableSubmitButtons();" UseSubmitBehavior ="false"
                Text="<%$ Resources:TimeLive.Resource, Submit_text%> " Width="68px" />&nbsp;
        </div> 
        <div style="display: table-cell; vertical-align: middle;" >
             <asp:Button ID="BtnSubmitCancel" runat="server" Text="<%$ Resources:TimeLive.Resource, Cancel_text%> "
                ValidationGroup="1" Width="68px" data-dismiss="modal"  OnClientClick="return false;" /><br />
        </div>
    </div>
</div>
<br />
<br />