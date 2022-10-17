<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlMyTasks.ascx.vb" Inherits="Employee_Controls_ctlMyTasks" EnableViewState="true" %>
<%@ Register Assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24D65337282035F2"
    Namespace="eWorld.UI" TagPrefix="ew" %>
<%@ Register Assembly="eWorld.UI"  Namespace="eWorld.UI" TagPrefix="ew" %>

<%@ Register Src="ctlTaskSearch.ascx" TagName="ctlTaskSearch" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
    <style type="text/css">
   
  
     .imageCrossCssClass
    {
        height:16px;
        width:16px;
        border-width:0px;
        position: relative;
        left:289px;
        /*top: 12px;
        right: 9px;*/
    }
   
    
</style>
    <script type="text/javascript">

    function ChangeCheckBoxState(id, checkState) {
        var cb = document.getElementById(id);
        if (cb != null)
            cb.checked = checkState;
    }
    function ChangeAllCheckBoxStates(checkState) {

        // Toggles through all of the checkboxes defined in the CheckBoxIDs array
        // and updates their value to the checkState input parameter
        if (CheckBoxIDs != null) {
            for (var i = 0; i < CheckBoxIDs.length; i++) {
                ChangeCheckBoxState(CheckBoxIDs[i], checkState);

            }
        }
        Session("Amount") = "1";
        //                       PageMethods.SetSessionValues();
        //                       __doPostBack('chkCheckAll', '')
    }
    function ChangeHeaderAsNeeded() {
        // Whenever a checkbox in the GridView is toggled, we need to
        // check the Header checkbox if ALL of the GridView checkboxes are
        // checked, and uncheck it otherwise
        if (CheckBoxIDs != null) {
            // check to see if all other checkboxes are checked
            for (var i = 1; i < CheckBoxIDs.length; i++) {

                var cb = document.getElementById(CheckBoxIDs[i]);
                if (!cb.checked) {
                    // Whoops, there is an unchecked checkbox, make sure
                    // that the header checkbox is unchecked
                    ChangeCheckBoxState(CheckBoxIDs[0], false);
                    return;
                }
            }

            // If we reach here, ALL GridView checkboxes are checked
            ChangeCheckBoxState(CheckBoxIDs[0], true);
        }
    }
    </script>
    
    <ew:CollapsablePanel id="CollapsablePanelSearch" runat="server" Collapsed="True"
    ExpandText="Search" AllowSliding="True" AllowTitleExpandCollapse="True" 
    AllowTitleRowExpandCollapse="True" CollapserAlign="Left" 
    TitleStyle-CssClass="accordionHeader" TitleStyle-Font-Bold="True" 
    TitleVerticalAlignment="NotSet" Width="99%"  
    SlideLines="13" SlideSpeed="-100" style="margin-left:5px" 
    CollapseText="Search" TitleLinkStyle-ForeColor="#666666" >
    
    <table class="xFormView" id="Table1" width="100%"><tr><td>
        <table align="left" class="xFormView" style="width: 100%">
            <tr>
                <th class="FormViewSubHeader" colspan="4">
                    <asp:Literal ID="Literal2" runat="server" Text="<%$ Resources:TimeLive.Resource, Search Parameters%> " /></th>
            </tr>
            <tr>
                <td align="right" class="formviewlabelcell">
                    <asp:Literal ID="Literal5" runat="server" Text="<%$ Resources:TimeLive.Resource, Project:%> " /></td>
                <td align="left">
                  <asp:DropDownList ID="ddlAccountProjectId" runat="server" AppendDataBoundItems="True" DataTextField="ProjectName" DataValueField="AccountProjectId"
                        Width="186px" ValidationGroup="TaskSearch">
                        <asp:ListItem Selected="True" Value="0" Label ID="Label325" runat="server" Text="<%$ Resources:TimeLive.Resource, All%> "></asp:ListItem>
                    </asp:DropDownList></td>
                <td align="right" class="formviewlabelcell">
                    <asp:Literal ID="Literal4" runat="server" Text="<%$ Resources:TimeLive.Resource, Task Type:%> " /></td>
                <td align="left">
                    <asp:DropDownList ID="ddlAccountTaskType" runat="server" AppendDataBoundItems="True"
                        DataSourceID="dsAccountTaskTypeId" DataTextField="TaskType" DataValueField="AccountTaskTypeId"
                        Width="186px" ValidationGroup="TaskSearch">
                        <asp:ListItem Selected="True" Value="0" Label ID="Label1" runat="server" Text="<%$ Resources:TimeLive.Resource, All%> "></asp:ListItem>
                        <%--<asp:ListItem Selected="True" Value="0">&lt;ALL&gt;</asp:ListItem>--%>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td align="right" class="formviewlabelcell">
                    <asp:Literal ID="Literal9" runat="server" Text="<%$ Resources:TimeLive.Resource, Completed Status:%> " /></td>
                <td align="left" class="formviewlabelcell">
                    <asp:DropDownList ID="ddlCompletedStatus" runat="server" AppendDataBoundItems="True"
                        Width="186px" ValidationGroup="TaskSearch">
                        <asp:ListItem Selected="True" Value="-1" Label ID="Label7" runat="server" Text="<%$ Resources:TimeLive.Resource, All%> "></asp:ListItem>
                        <asp:ListItem Value="1" Label ID="Label8" runat="server" Text="<%$ Resources:TimeLive.Resource, Completed Tasks%> "></asp:ListItem>
                        <asp:ListItem Value="0" Label ID="Label9" runat="server" Text="<%$ Resources:TimeLive.Resource, Incomplete Tasks%> "></asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td align="right" class="formviewlabelcell">
                    <aspToolkit:CascadingDropDown ID="CascadingDropDown1" runat="server" Category="ProjectMilestone"
                        LoadingText="Loading..." ParentControlID="ddlAccountProjectId" PromptText="<%$ Resources:TimeLive.Resource, All%> "
                        ServiceMethod="GetAccountProjectMileStones" TargetControlID="ddlAccountProjectMilestoneId" ServicePath="~/Services/ProjectService.asmx">
                    </aspToolkit:CascadingDropDown>
                    <asp:Literal ID="Literal6" runat="server" Text="<%$ Resources:TimeLive.Resource, Milestone:%> " />
                </td>
                <td align="left">
                    <asp:DropDownList ID="ddlAccountProjectMilestoneId" runat="server" AppendDataBoundItems="True"
                        DataSourceID="dsAccountProjectMilestone" DataTextField="MilestoneDescription"
                        DataValueField="AccountProjectMilestoneId" Width="186px" ValidationGroup="TaskSearch">
                        <asp:ListItem Selected="True" Value="0" Label ID="Label3" runat="server" Text="<%$ Resources:TimeLive.Resource, All%> "></asp:ListItem>
                        <%--<asp:ListItem Selected="True" Value="0">&lt;ALL&gt;</asp:ListItem>--%>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td align="right" class="formviewlabelcell">
                     <asp:Literal ID="Literal11" runat="server" 
                        Text="<%$ Resources:TimeLive.Resource, Include Date Range:%> " />
                    </td>
             <td align="left" class="formviewlabelcell">
                   <asp:CheckBox ID="chkIncludeDateRange" runat="server" 
                        ValidationGroup="TaskSearch" />
                    </td>
                <td align="right" class="formviewlabelcell">
                   
                    <asp:Literal ID="Literal10" runat="server" Text="<%$ Resources:TimeLive.Resource, Task Status:%> " /></td>
                <td align="left">
                    <asp:DropDownList ID="ddlAccountStatusId" runat="server" AppendDataBoundItems="True"
                        DataSourceID="dsAccountStatus" DataTextField="Status" 
                        DataValueField="AccountStatusId" Width="186px" ValidationGroup="TaskSearch">
                        <asp:ListItem Value="0" Label ID="Label10" runat="server" Text="<%$ Resources:TimeLive.Resource, All%> "></asp:ListItem>
                                    </asp:DropDownList>
                 
                   </td>
            </tr>
            <tr>
                <td align="right" class="formviewlabelcell">
                  <asp:Literal ID="Literal12" runat="server" 
                        Text="<%$ Resources:TimeLive.Resource, Start Date From:%> " />  </td>
                <td align="left" class="formviewlabelcell">
                    <ew:CalendarPopup ID="CreatedDateFrom" runat="server" SkinId="DatePicker" 
                        Width="55px">
                    </ew:CalendarPopup> </td>
                <td align="right" class="formviewlabelcell" rowspan="2">
                     <asp:Literal ID="Literal14" runat="server" 
                        Text="<%$ Resources:TimeLive.Resource, Description:%> " /></td>
                 <td align="left" rowspan="2">
                   <asp:TextBox ID="txtTaskDescription" runat="server" Height="50px" 
                        TextMode="MultiLine" ValidationGroup="TaskSearch" Width="175px"></asp:TextBox> </td>
            </tr>
            <tr>
                <td align="right" class="formviewlabelcell">
                    <asp:Literal ID="Literal13" runat="server" 
                        Text="<%$ Resources:TimeLive.Resource, Start Date Upto:%> " />
                </td>
                <td align="left" class="formviewlabelcell">
                    <ew:CalendarPopup ID="CreatedDateUpt" runat="server" SkinId="DatePicker" 
                        Width="55px">
                    </ew:CalendarPopup>
                </td>
                <td align="right" class="formviewlabelcell" rowspan="2">
                  
                </td>
                <td align="left" rowspan="2">
                  
                </td>
            </tr>
                      <tr>
                <td align="right" class="formviewlabelcell">
                </td>
                <td align="left" class="formviewlabelcell" colspan="2" style="padding-bottom: 5px; padding-top: 5px;" >
                    <asp:Button ID="btnShow" runat="server" Text="<%$ Resources:TimeLive.Resource, Show_text%> " OnClick="btnShow_Click" ValidationGroup="TaskSearch"/>
                    </td>
                <td align="left">
                </td>
            </tr>
        </table>
        </td></tr></table>
    </ew:CollapsablePanel>
      
    <asptoolkit:accordion ID="Accordion1" 
                           runat="server" SelectedIndex ="5" HeaderCssClass="accordionHeader" HeaderSelectedCssClass="accordionHeaderSelected"
                            Width="99%" Height="243px" RequireOpenedPane="False" SuppressHeaderPostbacks="False" style="padding-bottom: 5px;margin-left:5px" FramesPerSecond="30">
 <Panes>
      <aspToolkit:AccordionPane ID="AccordionPane1" runat="server">
      <Header><asp:Label ID="Label50" runat="server" 
                        Text="<%$ Resources:TimeLive.Resource, Mass Update%> " Font-Bold="True" SkinID="xFormView" ForeColor="#666666"/></Label></Header>
      <Content>
    <asp:UpdatePanel ID="UpdatePanel3" runat="server"> 
<ContentTemplate> 
 <table class="xFormView"  id="Table2" width="100%">
 <tr>
 <td>
        <table align="left" class="xFormView" style=" width: 100%">
<tr>
<th class="FormViewSubHeader" colspan="4">
<asp:Literal ID="Literal1" runat="server" Text="<%$ Resources:TimeLive.Resource, Task Parameters%> " /></th>
</tr>
<tr>
        <td align="right" class="formviewlabelcell" style="width: 20%" >
                <asp:Literal ID="Literal18" runat="server" Text="<%$ Resources:TimeLive.Resource, Task Status:%> " />
        </td>
        <td align="left" >
                    <asp:DropDownList ID="ddlTaskStatus" runat="server" 
                        DataSourceID="dsAccountStatus" DataTextField="Status" 
                                      DataValueField="AccountStatusId" 
                AppendDataBoundItems="True" Width="186px" Height="22px">
                                      <asp:ListItem Selected="True" Value="0">Select</asp:ListItem>
                    </asp:DropDownList>
                    </td>
        <td align="right" class="formviewlabelcell">
               <asp:Label 
                        ID="Label15" runat="server" 
                   AssociatedControlID="txtCompletePercentage">
                    Task Name:</asp:Label></td><td 
            align="left">
            <asp:TextBox 
                ID="txtTaskName" runat="server" ValidationGroup="TaskSearch" 
                        Width="120px" Height="22px"></asp:TextBox></td></tr><tr>
        <td 
                    align="right" class="formviewlabelcell" ><asp:Literal ID="Literal22" runat="server" Text="<%$ Resources:TimeLive.Resource, Task Type:%> " />
        </td>
        <td align="left"><asp:DropDownList ID="ddlTaskType" runat="server" 
                        DataSourceID="dsAccountProjectTaskTypeObjectInsert" DataTextField="TaskType" 
                                      DataValueField="AccountTaskTypeId" 
                        AppendDataBoundItems="True" Width="186px" Height="22px"><asp:ListItem Selected="True" Text="Select" Value="0">Select</asp:ListItem></asp:DropDownList></td>
                <td 
                align="right" class="formviewlabelcell">
               <asp:Label 
                        ID="Label14" runat="server" AssociatedControlID="txtCompletePercentage">
                    Completed%:</asp:Label></td>
        <td 
                    align="left">  <asp:TextBox 
                ID="txtCompletePercentage" runat="server" ValidationGroup="TaskSearch" 
                        Width="120px" Height="22px"></asp:TextBox>
</td>
        </tr>
<tr>
        <td align="right" class="formviewlabelcell"><asp:Literal ID="Literal21" runat="server" 
                        Text="<%$ Resources:TimeLive.Resource, Priority:%> " />
        </td>
        <td align="left"><asp:DropDownList ID="ddlPriority" runat="server" 
                        DataSourceID="dsAccountPriorityObject" DataTextField="Priority" DataValueField="AccountPriorityId" 
                        AppendDataBoundItems="True" Width="186px" Height="22px"><asp:ListItem Selected="True" Value="0">Select</asp:ListItem></asp:DropDownList></td>
        <td 
                    align="right" class="formviewlabelcell"><asp:Literal ID="Literal19" runat="server" Text="<%$ Resources:TimeLive.Resource, Duration:%> " /></td>
        <td align="left">  <asp:TextBox ID="txtDuration" runat="server" ValidationGroup="TaskSearch" 
                        Width="120px" Height="22px"></asp:TextBox>&nbsp;<asp:Literal ID="Literal25" runat="server" Text="<%$ Resources:TimeLive.Resource, Hours%>" />
        </td></tr>
<tr>
        <td align="right" class="formviewlabelcell">&nbsp; </td><td align="left"><asp:Button ID="btnUpdateSelectedItem" runat="server" OnClick="btnUpdateSelectedItem_Click" Text="Update" 
                    Visible="True" ValidationGroup="TaskUpdate" />&nbsp; </td>
        <td align="left" 
                    style="padding: 4px; margin: auto" class="formviewlabelcell" >&nbsp;</td>
        <td align="left"></td></tr>
</table>
</td>
</tr>
</table>
 </ContentTemplate>
 </asp:UpdatePanel>
 </Content>
 </aspToolkit:AccordionPane>
 </Panes>
 </asptoolkit:accordion>
   
    <asp:ObjectDataSource ID="dsddlAccountModule" runat="server" 
            OldValuesParameterFormatString="original_{0}" 
            SelectMethod="GetAccountModuleViewBySystemModuleandAccountEmployeeId" 
            TypeName="AccountModuleBLL">
            <SelectParameters>
                <asp:Parameter DbType="Guid" 
                    DefaultValue="25fd0146-f5da-4c6c-8915-abbab9852108" Name="SystemModuleId" />
            </SelectParameters>
        </asp:ObjectDataSource>
       
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" RenderMode="Inline">
    <ContentTemplate>
   <tr>
   <td align="right" style="padding-bottom: 3px;padding-right: 8px;">
 <span id="HeaderSpan" runat="server" style="position: relative;right: 6px;top: 32px;">
      <asp:ImageButton ID="ImgBtn_delete" runat="server" AlternateText="Delete View" style="border-width:0px;width: 20px;"
                                CausesValidation="False" OnClientClick="javascript:return confirm('Are you sure?');" 
                                CommandName="delete" OnClick="ImgBtn_delete_Click"
                                ImageUrl="~/Images/delete-file.png" 
           ToolTip="Delete View"   />
      <asp:ImageButton ID="ImgBtnEdit" runat="server" 
           AlternateText="Show/Hide Columns" style="border-width:0px;width: 20px;"
                                ImageUrl="~/Images/editfile.png" CausesValidation="False" 
                                CommandName="Edit" ToolTip="Show/Hide Columns" />
       
        <%--   <asp:ImageButton ID="ImgBtn_Add" runat="server" AlternateText="Add" 
                                CausesValidation="False" 
                                CommandName="insert"
                                ImageUrl="~/Images/add21.png"   />--%>
       <asp:DropDownList ID="ddlAccountModuleView" runat="server" 
             DataSourceID = "dsddlAccountModule" DataTextField = "AccountModuleViewName" DataValueField = "AccountModuleViewId"  
             Width="105" Height="20" AppendDataBoundItems="True" AutoPostBack="True">
           <%-- <asp:ListItem Value="0">Add New View...</asp:ListItem>--%>
         </asp:DropDownList>
        </span>
   </td>
   </tr>
    <x:GridView ID="GridView1" runat="server" AllowSorting="True" style="padding-bottom: 5px; padding-top: 5px" 
            AutoGenerateColumns="False" ShowHeaderWhenEmpty = "True" EmptyDataText = "There are no items to display."
             Caption='<%# ResourceHelper.GetFromResource("My Task List")%>' OnPageIndexChanging="GridView1_PageIndexChanging" 
            DataSourceID="AccountProjectTaskHierarchyObject" 
            SkinID="xgridviewSkinEmployee" EnableViewState="false"
            Width="99%" DataKeyNames="AccountProjectTaskId" AllowPaging="True">
            <Columns>
           </Columns>
        </x:GridView>
    <cc1:modalpopupextender id="ModalPopupExtender2" runat="server" 
	TargetControlID = "ImgBtnEdit"
	 popupcontrolid="Panel2" 
	
    popupdraghandlecontrolid="Pane" drag="false" 
	backgroundcssclass="ModalPopupBG">
</cc1:modalpopupextender>

    <asp:panel id="Panel2" style="display: none" runat="server">
	<div class="modal" style="height: 445px;width: 400px;">

                
    <div id="Pane" class="modal-bar">
        <h>Show/Hide Column</h>
          <asp:ImageButton ID="imgCancel" runat="server" AlternateText="Cancel" 
                                CausesValidation="False" 
                                CommandName="Cancel" 
                                ImageUrl="~/img/cross_button.png"  CssClass="imageCrossCssClass" />
         </div>
        
        <div class="modal-bg" style="width: 390px;height: 396px;">
        <div class="modal-content" style="width: 415px;min-width: 200px; min-height: 16px; position: relative; max-width: 1352px; max-height: 415px;height: 413px;margin-top: -15px;margin-left: -10px;margin-right: -10px;overflow-y:auto">

     <div class="standard-tabs margin-bottom" id="add-tabs" style="width: 399;height: 365px; font-weight: bold; font-size: 11px;padding-top: 0px;padding-left: 10px;padding-right: 10px;">
   <body>
    <br />
    <table style="width: 386px; height: 32px;">
                <tr >
                <td style="padding-top: 3px;width: 75px;"><span class="reqasterisk">*</span><label id="lblViewName" runat ="server">View Name:</label></td>
                <td align="left" style="width: 115px;">
                <asp:TextBox ID="txtAddView" Width="100px" runat="server" ></asp:TextBox>
               
                </td>
                <td  align="left" style="width: 190px;padding-top: 3px;">
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
            ControlToValidate="txtAddView" Display="Dynamic" ErrorMessage="View name cannot be empty"
            Width="0px"></asp:RequiredFieldValidator>
                </td>
                </tr>
              <%--   <asp:DropDownList ID="ddlAccountModuleView" runat="server" 
            DataSourceID="dsddlAccountModule" DataTextField="AccountModuleViewName" 
            DataValueField="AccountModuleViewId" AutoPostBack="True">
        </asp:DropDownList>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
            OldValuesParameterFormatString="original_{0}" 
            SelectMethod="GetAccountModuleViewBySystemModuleandAccountEmployeeId" 
            TypeName="AccountModuleBLL">
            <SelectParameters>
                <asp:Parameter DbType="Guid" 
                    DefaultValue="25fd0146-f5da-4c6c-8915-abbab9852108" Name="SystemModuleId" />
            </SelectParameters>
        </asp:ObjectDataSource>--%>    
    </table>
    <table style="width: 398px;height: 349px;">
   <tr>
            <td class="FormViewSubHeader" align="center" style="height: 16px;">
                <asp:Label ID="Label2" runat="server"></asp:Label>
            </td>
            <td class="FormViewSubHeader" align="center" >
                <asp:Label ID="Label5" runat="server" Visible="False"></asp:Label>
            </td>
            <td class="FormViewSubHeader" align="center" style="height: 16px;">
                <asp:Label ID="Label4" runat="server"></asp:Label>
            </td>
            <td class="FormViewSubHeader" align="center" >
                <asp:Label ID="Label6" runat="server" Visible="False"></asp:Label>
            </td>
        </tr>
   <tr>
   <td style="width: 180px;padding-right: 7px;">
   
   <asp:ListBox ID="AvailableListBox" runat="server" SelectionMode="Multiple"  style="width: 180px; height: 200px;padding-top: 2px;border-right-width: 1px;padding-bottom: 2px;border-left-width: 1px;padding-right: 2px;padding-left: 2px;margin-top: 2px;margin-bottom: 2px;overflow: auto;" Font-Size="12px" Font-Names="Tahoma"></asp:ListBox>

              
    </td>
   <td style="width: 13px;padding-top: 69px;">
        <span title="Add"> <ew:ListTransfer ID="LtMoveRight" runat="server" 
                    ImageUrl="~/img/Arrowright_smblack.png" Text="<%$ Resources:TimeLive.Resource, Move Right%>" 
                    TransferFromID="AvailableListBox" TransferToID="SelectedListBox" 
                    TransferType="Control" MakeCopy="false" ClientIDMode="Static" ToolTip="Add"  /></span>
                <br />
              <br />
         <span title="Remove"><ew:ListTransfer ID="LtMoveLeft" runat="server" 
                    ImageUrl="~/img/Arrowleft_smblack.png" Text="<%$ Resources:TimeLive.Resource, Move Left%>" 
                    TransferFromID="SelectedListBox" TransferToID="AvailableListBox" 
                    MakeCopy="false" TransferType="Control" ToolTip="Remove"  /></span>
   </td>
   <td style="width: 180px;padding-left: 7px;">
      <asp:ListBox ID="SelectedListBox" runat="server" SelectionMode="Multiple"  style="width: 180px; height: 180px;padding-top: 2px;border-right-width: 1px;padding-bottom: 2px;border-left-width: 1px;padding-right: 2px;padding-left: 2px;margin-top: 2px;margin-bottom: 2px;overflow: auto;" Font-Size="12px" Font-Names="Tahoma" ></asp:ListBox>
      <span style="padding-left: 73px;" title="Move Up"> <ew:ListTransfer ID="LtMoveUp" runat ="server" 
                Text = "<%$ Resources:TimeLive.Resource, Move Up %>" TransferType="Up" 
                TransferFromID="SelectedListBox" ImageUrl="~/img/Arrowup_smblack.png" 
                     ClientIDMode="Static" ToolTip="Move Up" /></span>
      <span title="Move Down"><ew:ListTransfer ID="LtMoveDown" runat ="server" 
                Text = "<%$ Resources:TimeLive.Resource, Move Down %>" TransferType="Down" 
                TransferFromID="SelectedListBox" ImageUrl="~/img/Arrowdown_smblack.png" 
                     ClientIDMode="Static" ToolTip="Move Down" /></span>
     </td>
  
 </tr>
   <tr>
 <td style="padding-bottom: 55px;" colspan="3">
  <asp:label id="lblnotice" runat ="server" Text="* The <b>Task Name<b> field is mandatory."> </asp:label>
 </td>
 </tr>
    </table>
  
</body>
</div>
<div class="custom-vscrollbar" style="display: none; opacity: 0;"><div></div></div></div>
        </div>
     <div style="background-color:#f5f5f6; border-top:solid 1px #dddddd;margin-top: -40px;margin-left: -12px;padding-top: 2px;margin-right: -11px;height:36px;width:132px;padding-left: 291px;/* top: -22px; *//* padding-bottom: 20px; */" >     
						<asp:Button ID="btnOkay" runat="server" Text="<%$ Resources:TimeLive.Resource, Apply%>" OnClick="btnOkay_Click" style="width:40px;margin-top: 3px;" CommandName="Insert"  />
                        <asp:Button ID="btnReset" runat="server" Text="<%$ Resources:TimeLive.Resource, Reset%>" style="width:40px;margin-top: 3px;" CommandName="Reset" />
                         <asp:Button ID="btnAddView" runat="server" Text="<%$ Resources:TimeLive.Resource, Add View%>" CommandName="insert" Visible="False" style="width:50px;margin-left: 58px;margin-top: 3px;" />
     </div>
           </div>
           <div class="modal-resize-nw"></div><div class="modal-resize-n"></div>
    <div class="modal-resize-ne"></div><div class="modal-resize-e"></div><div class="modal-resize-se"></div>
    <div class="modal-resize-s"></div><div class="modal-resize-sw"></div><div class="modal-resize-w"></div></div>
</asp:panel>
 </ContentTemplate>
</asp:UpdatePanel>
    <br />
    <div style="margin:0 5px;">
                    <asp:Button ID="btnAddTask" runat="server" OnClick="btnAddTask_Click"
                    Text="<%$ Resources:TimeLive.Resource, Add_text %>" Width="75px" 
                        UseSubmitBehavior="False" />
                    </div>           
    <asp:ObjectDataSource id="AccountProjectTaskHierarchyObject" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetAccountProjectTasksForTaskSearch" TypeName="AccountProjectTaskBLL" >
    <SelectParameters>
        <asp:Parameter DefaultValue="-1" Name="AccountProjectTaskId" Type="Int64" />
        <asp:Parameter Name="AccountProjects" Type="String" />
        <asp:Parameter DefaultValue="0" Name="AccountTaskTypeId" Type="Int32" />
        <asp:Parameter DefaultValue="0" Name="ReportedBy" Type="Int32" />
        <asp:Parameter DefaultValue="0" Name="IncludeDateRange" Type="String" />
        <asp:Parameter Name="CreatedDateFrom" Type="DateTime" DefaultValue="11/01/2006" />
        <asp:Parameter Name="CreatedDateUpto" Type="DateTime" DefaultValue="11/01/2007" />
        <asp:Parameter DefaultValue="39" Name="AssignedTo" Type="Int32" />
        <asp:Parameter DefaultValue="0" Name="TaskStatusId" Type="Int32" />
        <asp:Parameter DefaultValue="0" Name="CompletedStatus" Type="String" />
        <asp:Parameter Name="Description" Type="String" />
        <asp:SessionParameter DefaultValue="64" Name="AccountId" SessionField="AccountId"
            Type="Int32" />
        <asp:Parameter DefaultValue="" Name="AccountProjectMilestoneId" Type="Int32" />
        <asp:SessionParameter DefaultValue="" Name="AccountEmployeeId" SessionField="AccountEmployeeId"
            Type="Int32" />
        <asp:Parameter Name="IsTaskAdd" Type="Boolean" />
    </SelectParameters>
</asp:ObjectDataSource>
    <asp:ObjectDataSource ID="dsAccountTaskTypeId" runat="server" DeleteMethod="DeleteAccountTaskType"
            InsertMethod="AddAccountTaskType" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetAccountTaskTypesByAccountId" TypeName="AccountTaskTypeBLL" UpdateMethod="UpdateAccountTaskType">
            <DeleteParameters>
                <asp:Parameter Name="Original_AccountTaskTypeId" Type="Int32" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="AccountId" Type="Int32" />
                <asp:Parameter Name="TaskType" Type="String" />
                <asp:Parameter Name="Original_AccountTaskTypeId" Type="Int32" />
                <asp:Parameter Name="CreatedOn" Type="DateTime" />
                <asp:Parameter Name="CreatedByEmployeeId" Type="Int32" />
                <asp:Parameter Name="ModifiedOn" Type="DateTime" />
                <asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" />
            </UpdateParameters>
            <SelectParameters>
                <asp:SessionParameter DefaultValue="64" Name="AccountId" SessionField="AccountId"
                    Type="Int32" />
            </SelectParameters>
            <InsertParameters>
                <asp:Parameter Name="AccountId" Type="Int32" />
                <asp:Parameter Name="TaskType" Type="String" />
                <asp:Parameter Name="CreatedOn" Type="DateTime" />
                <asp:Parameter Name="CreatedByEmployeeId" Type="Int32" />
                <asp:Parameter Name="ModifiedOn" Type="DateTime" />
                <asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" />
            </InsertParameters>
        </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="dsAccountEmployee" runat="server" DeleteMethod="DeleteAccountEmployee"
            InsertMethod="AddAccountEmployee2" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetAccountEmployeesViewByAccountId" TypeName="AccountEmployeeBLL"
            UpdateMethod="UpdateAccountEmployee">
            <DeleteParameters>
                <asp:Parameter Name="Original_AccountEmployeeId" Type="Int32" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="Login" Type="String" />
                <asp:Parameter Name="Password" Type="String" />
                <asp:Parameter Name="Prefix" Type="String" />
                <asp:Parameter Name="FirstName" Type="String" />
                <asp:Parameter Name="LastName" Type="String" />
                <asp:Parameter Name="MiddleName" Type="String" />
                <asp:Parameter Name="EMailAddress" Type="String" />
                <asp:Parameter Name="AccountId" Type="Int32" />
                <asp:Parameter Name="AccountDepartmentId" Type="Int32" />
                <asp:Parameter Name="AccountRoleId" Type="Int32" />
                <asp:Parameter Name="AccountLocationId" Type="Int32" />
                <asp:Parameter Name="AddressLine1" Type="String" />
                <asp:Parameter Name="AddressLine2" Type="String" />
                <asp:Parameter Name="State" Type="String" />
                <asp:Parameter Name="City" Type="String" />
                <asp:Parameter Name="Zip" Type="String" />
                <asp:Parameter Name="CountryId" Type="Int16" />
                <asp:Parameter Name="HomePhoneNo" Type="String" />
                <asp:Parameter Name="WorkPhoneNo" Type="String" />
                <asp:Parameter Name="MobilePhoneNo" Type="String" />
                <asp:Parameter Name="BillingRateCurrencyId" Type="Int16" />
                <asp:Parameter Name="BillingTypeId" Type="Int32" />
                <asp:Parameter Name="BillingRate" Type="Decimal" />
                <asp:Parameter Name="BillingRateStartDate" Type="DateTime" />
                <asp:Parameter Name="StartDate" Type="DateTime" />
                <asp:Parameter Name="TerminationDate" Type="DateTime" />
                <asp:Parameter Name="StatusId" Type="Byte" />
                <asp:Parameter Name="IsDeleted" Type="Boolean" />
                <asp:Parameter Name="IsDisabled" Type="Boolean" />
                <asp:Parameter Name="DefaultProjectId" Type="Int32" />
                <asp:Parameter Name="TimeZoneId" Type="Int16" />
                <asp:Parameter Name="CreatedByEmployeeId" Type="Int32" />
                <asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" />
                <asp:Parameter Name="Original_AccountEmployeeId" Type="Int32" />
            </UpdateParameters>
            <SelectParameters>
                <asp:SessionParameter DefaultValue="64" Name="AccountId" SessionField="AccountId"
                    Type="Int32" />
            </SelectParameters>
            <InsertParameters>
                <asp:Parameter Name="Login" Type="String" />
                <asp:Parameter Name="Password" Type="String" />
                <asp:Parameter Name="Prefix" Type="String" />
                <asp:Parameter Name="FirstName" Type="String" />
                <asp:Parameter Name="LastName" Type="String" />
            </InsertParameters>
        </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="dsAccountTaskType" runat="server"></asp:ObjectDataSource>
    <asp:ObjectDataSource 
    ID="dsAccountProject" runat="server" DeleteMethod="DeleteAccountProject" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetAccountProjectsByAccountId" 
    TypeName="AccountProjectBLL"><DeleteParameters>
                <asp:Parameter Name="Original_AccountProjectId" Type="Int32" />
            </DeleteParameters>
            <SelectParameters>
                <asp:SessionParameter DefaultValue="64" Name="AccountId" SessionField="AccountId"
                    Type="Int32" />
            </SelectParameters>
            </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="dsAccountStatus" runat="server" DeleteMethod="DeleteAccountStatus"
            InsertMethod="AddAccountStatus" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetAccountsStatusForTask" 
    TypeName="AccountStatusBLL" UpdateMethod="UpdateAccountStatus">
            <DeleteParameters>
                <asp:Parameter Name="Original_AccountStatusId" Type="Int32" />
            </DeleteParameters>
            <SelectParameters>
                <asp:SessionParameter DefaultValue="64" Name="AccountId" SessionField="AccountId"
                    Type="Int32" />
            </SelectParameters>
            <InsertParameters>
                <asp:Parameter Name="AccountId" Type="Int32" />
                <asp:Parameter Name="Status" Type="String" />
                <asp:Parameter Name="StatusTypeId" Type="Int32" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="AccountId" Type="Int32" />
                <asp:Parameter Name="Status" Type="String" />
                <asp:Parameter Name="StatusTypeId" Type="Int32" />
                <asp:Parameter Name="Original_AccountStatusId" Type="Int32" />
                <asp:Parameter Name="IsDisabled" Type="Boolean" />
            </UpdateParameters>
        </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="dsAccountProjectMilestone" runat="server" DeleteMethod="DeleteAccountProjectMilestone"
            InsertMethod="AddAccountProjectMilestone" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetAccountProjectMilestonesByAccountProjectId" TypeName="AccountProjectMilestoneBLL"
            UpdateMethod="UpdateAccountProjectMilestone">
            <DeleteParameters>
                <asp:Parameter Name="Original_AccountProjectMilestoneId" Type="Int32" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="AccountId" Type="Int32" />
                <asp:Parameter Name="AccountProjectId" Type="Int32" />
                <asp:Parameter Name="MilestoneDescription" Type="String" />
                <asp:Parameter Name="MilestoneDate" Type="DateTime" />
                <asp:Parameter Name="Original_AccountProjectMilestoneId" Type="Int32" />
                <asp:Parameter Name="CreatedOn" Type="DateTime" />
                <asp:Parameter Name="CreatedByEmployeeId" Type="Int32" />
                <asp:Parameter Name="ModifiedOn" Type="DateTime" />
                <asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" />
            </UpdateParameters>
            <SelectParameters>
                <asp:ControlParameter ControlID="ddlAccountProjectId" DefaultValue="1" Name="AccountProjectId"
                    PropertyName="SelectedValue" Type="Int32" />
                <asp:Parameter Name="NotFixTable" Type="Boolean" />
            </SelectParameters>
            <InsertParameters>
                <asp:Parameter Name="AccountId" Type="Int32" />
                <asp:Parameter Name="AccountProjectId" Type="Int32" />
                <asp:Parameter Name="MilestoneDescription" Type="String" />
                <asp:Parameter Name="MilestoneDate" Type="DateTime" />
                <asp:Parameter Name="CreatedOn" Type="DateTime" />
                <asp:Parameter Name="CreatedByEmployeeId" Type="Int32" />
                <asp:Parameter Name="ModifiedOn" Type="DateTime" />
                <asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" />
            </InsertParameters>
        </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="dsAccountPriorityObject" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetAccountPrioritiesByAccountId" 
    TypeName="AccountPriorityBLL" DeleteMethod="DeleteAccountPriority" 
    InsertMethod="AddAccountPriority" UpdateMethod="UpdateAccountPriority">
            <DeleteParameters>
                <asp:Parameter Name="Original_AccountPriorityId" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="AccountId" Type="Int32" />
                <asp:Parameter Name="Priority" Type="String" />
                <asp:Parameter Name="PriorityOrder" Type="Byte" />
            </InsertParameters>
            <SelectParameters>
                <asp:SessionParameter DefaultValue="64" Name="AccountId" SessionField="AccountId"
                    Type="Int32" />
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter Name="AccountId" Type="Int32" />
                <asp:Parameter Name="Priority" Type="String" />
                <asp:Parameter Name="PriorityOrder" Type="Byte" />
                <asp:Parameter Name="Original_AccountPriorityId" Type="Int32" />
                <asp:Parameter Name="IsDisabled" Type="Boolean" />
            </UpdateParameters>
        </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="dsAccountPriorityObjectInsert" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetAccountPrioritiesByAccountIdAndAccountPriorityId" TypeName="AccountPriorityBLL" DeleteMethod="DeleteAccountPriority" InsertMethod="AddAccountPriority" UpdateMethod="UpdateAccountPriority">
            <DeleteParameters>
                <asp:Parameter Name="Original_AccountPriorityId" Type="Int32" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="AccountId" Type="Int32" />
                <asp:Parameter Name="Priority" Type="String" />
                <asp:Parameter Name="PriorityOrder" Type="Byte" />
                <asp:Parameter Name="Original_AccountPriorityId" Type="Int32" />
                <asp:Parameter Name="IsDisabled" Type="Boolean" />
            </UpdateParameters>
            <SelectParameters>
                <asp:SessionParameter DefaultValue="64" Name="AccountId" SessionField="AccountId"
                    Type="Int32" />
                <asp:Parameter Name="AccountPriorityId" Type="Int32" DefaultValue="0" />
            </SelectParameters>
            <InsertParameters>
                <asp:Parameter Name="AccountId" Type="Int32" />
                <asp:Parameter Name="Priority" Type="String" />
                <asp:Parameter Name="PriorityOrder" Type="Byte" />
            </InsertParameters>
        </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="dsAccountProjectTaskTypeObjectInsert" runat="server" OldValuesParameterFormatString="original_{0}"
    SelectMethod="GetAccountTaskTypesByAccountIdAndAccountTaskTypeId" TypeName="AccountTaskTypeBLL" DeleteMethod="DeleteAccountTaskType" InsertMethod="AddAccountTaskType" UpdateMethod="UpdateAccountTaskType">
            <DeleteParameters>
                <asp:Parameter Name="Original_AccountTaskTypeId" Type="Int32" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="AccountId" Type="Int32" />
                <asp:Parameter Name="TaskType" Type="String" />
                <asp:Parameter Name="Original_AccountTaskTypeId" Type="Int32" />
                <asp:Parameter Name="CreatedOn" Type="DateTime" />
                <asp:Parameter Name="CreatedByEmployeeId" Type="Int32" />
                <asp:Parameter Name="ModifiedOn" Type="DateTime" />
                <asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" />
                <asp:Parameter Name="IsDisabled" Type="Boolean" />
            </UpdateParameters>
            <SelectParameters>
                <asp:SessionParameter DefaultValue="64" Name="AccountId" SessionField="AccountId"
            Type="Int32" />
                <asp:Parameter Name="AccountTaskTypeId" Type="Int32" DefaultValue="0" />
            </SelectParameters>
            <InsertParameters>
                <asp:Parameter Name="AccountId" Type="Int32" />
                <asp:Parameter Name="TaskType" Type="String" />
                <asp:Parameter Name="CreatedOn" Type="DateTime" />
                <asp:Parameter Name="CreatedByEmployeeId" Type="Int32" />
                <asp:Parameter Name="ModifiedOn" Type="DateTime" />
                <asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" />
            </InsertParameters>
</asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjSystemModuleFields" runat="server" 
                   
                    TypeName="AccountModuleBLL" OldValuesParameterFormatString="original_{0}" 
                    
    SelectMethod="GetSystemModuleFieldsBySystemModuleIdandIsDefaultAdd">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="False" Name="IsDefaultAdd" Type="Boolean" />
                        <asp:Parameter DbType="Guid" DefaultValue="25fd0146-f5da-4c6c-8915-abbab9852108" Name="SystemModuleId" />
                    </SelectParameters>
                </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjvueSystemModuleFields" runat="server" 
                    SelectMethod="GetvueSystemModuleFieldsBySystemModuleIdAndAccountModuleViewIsNull"
                    TypeName="AccountModuleBLL" OldValuesParameterFormatString="original_{0}">
                    <SelectParameters>
                        <asp:Parameter DbType="Guid" DefaultValue="25fd0146-f5da-4c6c-8915-abbab9852108" Name="SystemModuleId" />
                          <asp:ControlParameter ControlID="ddlAccountModuleView" DbType="Guid" 
                              Name="AccountModuleViewId" PropertyName="SelectedValue" />
                    </SelectParameters>
                </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjAccountModuleFields" runat="server" 
                    SelectMethod="GetSystemModuleFieldsBySystemModuleIdandIsDefaultAdd"
                    TypeName="AccountModuleBLL" OldValuesParameterFormatString="original_{0}">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="True" Name="IsDefaultAdd" Type="Boolean" />
                       <asp:Parameter DbType="Guid" DefaultValue="25fd0146-f5da-4c6c-8915-abbab9852108" Name="SystemModuleId" />
                    </SelectParameters>
                </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjvueAccountModuleFields" runat="server" 
                    SelectMethod="GetvueAccountModuleFieldsByAccountModuleViewIdAndSystemModuleId"
                    TypeName="AccountModuleBLL" OldValuesParameterFormatString="original_{0}">
                    <SelectParameters>
                          <asp:Parameter DbType="Guid" DefaultValue="25fd0146-f5da-4c6c-8915-abbab9852108" Name="SystemModuleId" />
                          <asp:ControlParameter ControlID="ddlAccountModuleView" DbType="Guid" 
                              Name="AccountModuleViewId" PropertyName="SelectedValue" />
                    </SelectParameters>
                </asp:ObjectDataSource>
  