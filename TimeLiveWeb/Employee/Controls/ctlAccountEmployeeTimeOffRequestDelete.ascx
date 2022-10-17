<%@ Control Language="VB" AutoEventWireup="false" EnableViewState="False" CodeFile="ctlAccountEmployeeTimeOffRequestDelete.ascx.vb" Inherits="Employee_Controls_ctlAccountEmployeeTimeOffRequestDelete" %>

<br />
<br />
<div style="display:table; margin-left:auto ; margin-right:auto"  >
    <div style="display: table-row; " >
        <div style="display: table-cell; vertical-align: middle ;  " >
            <asp:Literal runat="server"  ID="Literal1" Text ="<%$ Resources:TimeLive.Resource, Delete TimeOff %>"></asp:Literal>
        </div>
         <asp:HiddenField runat ="server" ID="TimeOffRequesId" Value ="none" />
    </div>
    

</div>
<br />
<br />
<div style="display:table; margin-left:auto ; margin-right:auto">
    <div style="display: table-row; " >
        <div style="display: table-cell; vertical-align: middle;" >
            <asp:Button ID="BtnDelete" runat="server" OnClick ="TimeOffRequestDelete" OnClientClick="disableDeleteButtons();" UseSubmitBehavior ="false"
                Text="<%$ Resources:TimeLive.Resource, Delete_text%> " Width="68px" />&nbsp;
        </div> 
        <div style="display: table-cell; vertical-align: middle;" >
             <asp:Button ID="BtnDeleteCancel" runat="server" Text="<%$ Resources:TimeLive.Resource, Cancel_text%> "
                ValidationGroup="1" Width="68px" data-dismiss="modal"  OnClientClick="return false;" /><br />
        </div>
    </div>
</div>
<br />
<br />
<!--
    
    -->
