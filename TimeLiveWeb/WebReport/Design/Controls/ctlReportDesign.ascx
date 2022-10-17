<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlReportDesign.ascx.vb" Inherits="WebReport_Design_Controls_ctlReportDesign" EnableViewState="true"  %>
<%@ Register Assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2"
    Namespace="eWorld.UI" TagPrefix="ew" %>
<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<asp:Wizard ID="ReportWizard" runat="server" ActiveStepIndex="1" Width="98%">
    <WizardSteps>
        <asp:WizardStep  runat="server" StepType="Start">
            <asp:FormView ID="FormView1" runat="server" DataSourceID="dsReportDefinationObject"
                DefaultMode="Insert" Width="100%" DataKeyNames="AccountId,IsConsolidated,ReportName,ReportDescription" SkinID="formviewSkinEmployee">
                <EditItemTemplate>
                <table class="xFormView" width = "100%" style="border: none;"><tr><td>
                    <table width="100%" class="xFormView">
                        <tr>
                            <th class="caption" colspan="2" >
                                <asp:Literal ID="Literal1" runat="server" Text="<%$ Resources:TimeLive.Resource, Report Definition Information%> " /></th>
                        </tr>
                        <tr>
                            <th colspan="2" style="height: 21px" class="FormViewSubHeader">
                                <asp:Literal ID="Literal2" runat="server" Text="<%$ Resources:TimeLive.Resource, Report Definition%> " /></th>
                        </tr>
                        <tr>
                            <td align="right" style="width: 25%" class="FormViewLabelCell">
                                <asp:Literal ID="Literal3" runat="server" Text="<%$ Resources:TimeLive.Resource, Report Name:%> " /></td>
                            <td style="width: 75%">
                                <asp:TextBox ID="ReportNameTextBox" runat="server"
                                    Width="300px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ReportNameTextBox"
                                    Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator></td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 25%" class="FormViewLabelCell">
                                <asp:Literal ID="Literal4" runat="server" Text="<%$ Resources:TimeLive.Resource, Report Description:%> " />
                            </td>
                            <td style="width: 75%">
                                <asp:TextBox ID="ReportDescriptionTextBox" runat="server"
                                    Width="300px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ReportDescriptionTextBox"
                                    Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator></td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 25%" class="FormViewLabelCell">
                                <asp:Literal ID="Literal5" runat="server" Text="<%$ Resources:TimeLive.Resource, Report Category:%> " />
                            </td>
                            <td style="width: 75%">
                                <asp:DropDownList ID="ddlReportCategory" runat="server" Width="312px" 
                                    DataSourceID="dsAccountReportCategoryObject" 
                                    DataTextField="AccountReportCategory" DataValueField="AccountReportCategoryId" 
                                    SelectedValue='<%# Bind("AccountReportCategoryId") %>'>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlReportCategory"
                                    Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator>
                                <asp:ObjectDataSource ID="dsAccountReportCategoryObject" runat="server" OldValuesParameterFormatString="original_{0}"
                            SelectMethod="GetAccountReportCategoryByAccountId" TypeName="TimeLive.WebReport.ReportDesignBLL">
                                    <SelectParameters>
                                        <asp:Parameter DefaultValue="151" Name="AccountId" Type="Int32" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 25%; height: 24px;" class="FormViewLabelCell">
                                <asp:Literal ID="Literal6" runat="server" Text="<%$ Resources:TimeLive.Resource, Upload Report Icon:%> " /></td>
                            <td style="width: 75%; height: 24px;">
                                <asp:FileUpload ID="ReportIconPathTextBox" runat="server" Width="395px" />
                            </td>
                        </tr>
                        <tr>
                            <td align="right" class="FormViewLabelCell" style="width: 25%; height: 24px">
                                <asp:Literal ID="Literal22" runat="server" Text="<%$ Resources:TimeLive.Resource, Show Company Logo: %>" /></td>
                            <td style="width: 75%; height: 24px">
                                <asp:CheckBox ID="chkShowCompanyLogo" runat="server" /></td>
                        </tr>
                        <tr>
                            <td align="right" class="FormViewLabelCell" style="width: 25%; height: 24px">
                                <asp:Literal ID="Literal26" runat="server" Text="<%$ Resources:TimeLive.Resource, Report Title:%> " /></td>
                            <td style="width: 75%; height: 24px">
                                <asp:TextBox ID="ReportTitleTextBox" runat="server" MaxLength="100" Width="300px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td align="right" class="FormViewLabelCell" style="width: 25%; height: 24px" valign="top">
                                <asp:Literal ID="Literal27" runat="server" Text="<%$ Resources:TimeLive.Resource, Report Header:%> " /></td>
                            <td style="width: 75%; height: 24px; padding-top: 8px; padding-bottom: 8px;">
                                <asp:TextBox ID="ReportHeaderTextBox" runat="server" MaxLength="2000" Width="600px" Height="150px" TextMode="MultiLine"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td align="right" class="FormViewLabelCell" style="width: 25%; height: 24px" valign="top">
                                <asp:Literal ID="Literal28" runat="server" Text="<%$ Resources:TimeLive.Resource, Report Footer:%> " /></td>
                            <td style="width: 75%; height: 24px; padding-top: 5px; padding-bottom: 12px;">
                                <asp:TextBox ID="ReportFooterTextBox" runat="server" MaxLength="2000" Width="600px" Height="150px" TextMode="MultiLine"></asp:TextBox></td>
                        </tr>
                    </table>
                    </td></tr></table>
                </EditItemTemplate>
                <InsertItemTemplate>
                <table class="xFormView" width = "100%" style="border: none;"><tr><td>
                    <table width="100%" class="xFormView">
                        <tr>
                             <th class="caption" colspan="2" >
                                 <asp:Literal ID="Literal1" runat="server" Text="<%$ Resources:TimeLive.Resource, Report Definition Information%> " /></th>
                        </tr>
                        <tr>
                            <th colspan="2" style="height: 21px" class="FormViewSubHeader">
                                 <asp:Literal ID="Literal7" runat="server" Text="<%$ Resources:TimeLive.Resource, Report Definition%> " /></th>
                        </tr>
                        <tr>
                            <td align="right" style="width: 25%" class="FormViewLabelCell">
                                 <asp:Literal ID="Literal8" runat="server" Text="<%$ Resources:TimeLive.Resource, Report Name:%> " /></td>
                            <td style="width: 75%">
                                <asp:TextBox ID="ReportNameTextBox" runat="server" Width="300px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ReportNameTextBox"
                                    Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator></td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 25%" class="FormViewLabelCell">
                                <asp:Literal ID="Literal9" runat="server" Text="<%$ Resources:TimeLive.Resource, Report Description:%>"/>
                            </td>
                            <td style="width: 75%">
                                <asp:TextBox ID="ReportDescriptionTextBox" runat="server" Width="300px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ReportDescriptionTextBox"
                                    Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator></td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 25%" class="FormViewLabelCell">
                                <asp:Literal ID="Literal10" runat="server" Text="<%$ Resources:TimeLive.Resource, Report Category:%> " />
                            </td>
                            <td style="width: 75%">
                                <asp:DropDownList ID="ddlReportCategory" runat="server" Width="300px" DataSourceID="dsAccountReportCategoryObject" DataTextField="AccountReportCategory" DataValueField="AccountReportCategoryId">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlReportCategory"
                                    Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator>
                                <asp:ObjectDataSource ID="dsAccountReportCategoryObject" runat="server" OldValuesParameterFormatString="original_{0}"
                            SelectMethod="GetAccountReportCategoryByAccountId" TypeName="TimeLive.WebReport.ReportDesignBLL">
                                    <SelectParameters>
                                        <asp:Parameter DefaultValue="151" Name="AccountId" Type="Int32" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 25%; height: 24px;" class="FormViewLabelCell">
                                <asp:Literal ID="Literal11" runat="server" Text="<%$ Resources:TimeLive.Resource, Upload Report Icon:%> " /></td>
                            <td style="width: 75%; height: 24px;">
                                <asp:FileUpload ID="ReportIconPathTextBox" runat="server" Width="395px" />
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 25%; height: 24px" class="FormViewLabelCell">
                            </td>
                            <td style="width: 75%; height: 24px" >
                                <asp:RadioButton ID="rdDetailed" runat="server" GroupName="ReportType" Text="<%$ Resources:TimeLive.Resource, Detailed%>" />&nbsp;<asp:RadioButton
                                    ID="rdConsolidated" runat="server" GroupName="ReportType" Text="<%$ Resources:TimeLive.Resource, Consolidated%>" /></td>
                        </tr>
                        <tr>
                            <td align="right" class="FormViewLabelCell" style="width: 25%; height: 24px">
                                <asp:Literal ID="Literal21" runat="server" Text="<%$ Resources:TimeLive.Resource, Show Company Logo: %>" /></td>
                            <td style="width: 75%; height: 24px">
                                <asp:CheckBox ID="chkShowCompanyLogo" runat="server" /></td>
                        </tr>
                        <tr>
                            <td align="right" class="FormViewLabelCell" style="width: 25%; height: 24px">
                                <asp:Literal ID="Literal23" runat="server" Text="<%$ Resources:TimeLive.Resource, Report Title: %>" /></td>
                            <td style="width: 75%; height: 24px">
                                <asp:TextBox ID="ReportTitleTextBox" runat="server" MaxLength="100" Width="300px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td align="right" class="FormViewLabelCell" style="width: 25%; height: 24px" valign="top">
                                <asp:Literal ID="Literal24" runat="server" Text="<%$ Resources:TimeLive.Resource, Report Header: %>" /></td>
                            <td style="width: 75%; height: 24px; padding-top: 8px; padding-bottom: 8px;">
                                <asp:TextBox ID="ReportHeaderTextBox" runat="server" MaxLength="2000" Width="600px" Height="150px" TextMode="MultiLine"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td align="right" class="FormViewLabelCell" style="width: 25%; height: 24px" valign="top">
                                <asp:Literal ID="Literal25" runat="server" Text="<%$ Resources:TimeLive.Resource, Report Footer: %>" /></td>
                            <td style="width: 75%; height: 24px; padding-top: 5px; padding-bottom: 12px;">
                                <asp:TextBox ID="ReportFooterTextBox" runat="server" MaxLength="2000" Width="600px" Height="150px" TextMode="MultiLine"></asp:TextBox></td>
                        </tr>
                    </table>
                    </td></tr></table>
                </InsertItemTemplate>
            </asp:FormView>
            <asp:ObjectDataSource ID="dsReportDefinationObject" runat="server" OldValuesParameterFormatString="original_{0}"
                SelectMethod="GetAccountReportByAccountReportId" TypeName="TimeLive.WebReport.ReportDesignBLL">
                <SelectParameters>
                    <asp:QueryStringParameter Name="AccountReportId" QueryStringField="AccountReportId" />
                </SelectParameters>
            </asp:ObjectDataSource>
        </asp:WizardStep>
        <asp:WizardStep  runat="server" StepType="Step" >
        <table class="xFormView" width="100%"><tr><td>
        <table class="xFormView" width="100%">
            <tr>
            <th colspan="2" class="caption">
                    <asp:Literal ID="Literal1" runat="server" Text="<%$ Resources:TimeLive.Resource, Report Information %>" /></th>
            </tr>
            <tr>
            <td class="FormViewSubHeader" style="width: 18%;" align="right" >
                  <asp:Literal ID="Literal12" runat="server" Text="<%$ Resources:TimeLive.Resource, Report Name: %>" />
            </td>
            <td style="width: 80%;" class="FormViewSubHeader" >
                  <asp:TextBox ID="ReportNameTextBox" runat="server" Width="300px" ReadOnly="True"></asp:TextBox></td>
            </tr>
            <%--<tr>
                    <th colspan="2" class="FormViewSubHeader">
                        <asp:Literal ID="Literal13" runat="server" Text="<%$ Resources:TimeLive.Resource, Report DataSource %>" /></th>
                </tr>--%>
                 <tr>
                    <td align="right" style="width: 18%;" class="FormViewSubHeader">
                         <asp:Literal ID="Literal14" runat="server" Text="<%$ Resources:TimeLive.Resource, Report Datasource: %>" />
                    </td>
                    <td style="width: 80%;">
                        <asp:DropDownList ID="ddlSystemReportDataSourceId" runat="server" Width="312px" 
                            DataSourceID="dsSystemReportDatasourceObject" 
                            DataTextField="ReportDataSourceName" DataValueField="SystemReportDataSourceId" 
                            AutoPostBack="True">
                        </asp:DropDownList>
                        <asp:ObjectDataSource ID="dsSystemReportDatasourceObject" runat="server" OldValuesParameterFormatString="original_{0}"
                            SelectMethod="GetSystemReportDataSource" TypeName="TimeLive.WebReport.ReportDesignBLL" DataObjectTypeName="System.Guid" DeleteMethod="DeleteAccountReport">
                        </asp:ObjectDataSource>
                    </td>
                </tr>
       </table>
       </td></tr></table>
       <br />
       <x:GridView ID="GridView1" runat="server" 
       Caption="<%$ Resources:TimeLive.Resource, Report Column %>" SkinID="xgridviewSkinEmployee" AutoGenerateColumns="False" DataSourceID="dsAccountReportColumnObject" 
       DataKeyNames="AccountReportColumnId,SystemReportDataSourceFieldId,SystemReportDataSourceFieldColumnOrder,AccountReportId,Caption,SystemReportCalculationTypeId,SystemReportDataSourceFieldCaption,DefaultAvailable,IsAllowSummaryCalculation,SystemReportDataSourceField,IsFormulaField,ColumnFormula" 
       Width="99.5%" PageSize="500">
                            <Columns>
                                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Select %>">
                                    <ItemTemplate>
<asp:CheckBox id="chkSelect" runat="server" __designer:wfdid="w13"></asp:CheckBox> 
</ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="5%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Report Column %>" SortExpression="SystemReportDataSourceField">
                                    <EditItemTemplate>
<asp:TextBox id="TextBox1" runat="server" Text='<%# Bind("SystemReportDataSourceField") %>' __designer:wfdid="w15"></asp:TextBox> 
</EditItemTemplate>
                                    <ItemTemplate>
<asp:Label id="lblReportColumn" Width="100%" runat="server" Text='<%# Eval("SystemReportDataSourceField") %>' __designer:wfdid="w14"></asp:Label> 
</ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" Width="25%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Caption %>" SortExpression="SystemReportDataSourceFieldCaption">
                                    <EditItemTemplate>
&nbsp; 
</EditItemTemplate>
                                    <ItemTemplate>
<asp:TextBox id="CaptionTextBox" Width="95%" runat="server" MaxLength="50" __designer:wfdid="w48"></asp:TextBox><asp:RequiredFieldValidator id="RequiredFieldValidator6" runat="server" __designer:wfdid="w49" ControlToValidate="CaptionTextBox" Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator> 
</ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="25%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Group %>">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkGroup" runat="server" />
                                    
</ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" Width="5%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Show Summary %>">
                                    <ItemTemplate>
<asp:DropDownList id="ddlGroupSummary" Width="100%" runat="server" DataSourceID="dsSystemReportCalculationTypeObjectForGroupSummary" DataValueField="SystemReportCalculationTypeId" DataTextField="CalculationType" __designer:wfdid="w9" AppendDataBoundItems="True">
                                            <asp:ListItem Value="0" Selected="True">&lt;None&gt;</asp:ListItem>
                                        </asp:DropDownList> 
</ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle Width="10%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Formula %>">
                                    <itemtemplate>
<asp:TextBox id="FormulaTextBox" Width="86%" runat="server" __designer:wfdid="w11"></asp:TextBox>
<%  If System.Configuration.ConfigurationManager.AppSettings("SHOW_HELP_ICON") <> "No" Then%>
<asp:HyperLink id="imgFormula" runat="server" __designer:wfdid="w5" ImageUrl="~/Images/Help.gif" Target="_blank" NavigateUrl="http://www.livetecs.com/timelivehelp/Default.htm#Understanding_Formula_Columns.htm">[imgFormula]</asp:HyperLink>
<%End If%>
</itemtemplate>
                                    <headerstyle horizontalalign="Left" />
                                    <itemstyle width="25%" />
                                </asp:TemplateField>
                            </Columns>
                        </x:GridView>
                        <asp:ObjectDataSource ID="dsAccountReportColumnObject" runat="server" OldValuesParameterFormatString="original_{0}"
                            SelectMethod="GetSystemReportDataSourceFieldBySystemReportDataSourceIdAndAccountReportId" TypeName="TimeLive.WebReport.ReportDesignBLL">
                            <SelectParameters>
                                <asp:Parameter Name="SystemReportDataSourceId" />
                                <asp:Parameter DefaultValue="" Name="AccountReportId" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                        <asp:ObjectDataSource ID="dsSystemReportCalculationTypeObjectForGroupSummary" runat="server"
                            DataObjectTypeName="System.Guid" DeleteMethod="DeleteAccountReport" OldValuesParameterFormatString="original_{0}"
                            SelectMethod="GetSystemReportCalculationTypes" TypeName="TimeLive.WebReport.ReportDesignBLL">
                        </asp:ObjectDataSource>
        </asp:WizardStep>
        <asp:WizardStep runat="server" StepType="Finish">
<table class="xFormView" width="80%"><tr><td>
       <table class="xFormView" style="width: 100%">
    <tr>
        <th colspan="2" class="caption">
            <asp:Literal ID="Literal15" runat="server" Text="<%$ Resources:TimeLive.Resource, Report Information %>" /></th>
    </tr>
    <tr>
        <th class="FormViewSubHeader" style="width: 100px" >
            <asp:Literal ID="Literal16" runat="server" Text="<%$ Resources:TimeLive.Resource, Report Name: %>" />
        </th>
        <th style="width: 600px" class="FormViewSubHeader" >
            <asp:TextBox ID="reportNameTextBox1" runat="server" Width="100%" ReadOnly="True"></asp:TextBox></th>
    </tr>
</table>
</td></tr></table>
<br />
<table class="xFormView" width="80%"><tr><td>
        <table class="xFormView" border="0" width="100%" style=" border: none;">
            <tr>
                <th class="caption" colspan="2">
                    <asp:Literal ID="Literal17" runat="server" Text="<%$ Resources:TimeLive.Resource, Column Order %>" /></th>
                <td colspan="1">
                </td>
                <th class="caption" colspan="2">
                     <asp:Literal ID="Literal18" runat="server" Text="<%$ Resources:TimeLive.Resource, Group Order %>" /></th>
            </tr>
    <tr>
        <th class="FormViewSubHeader" colspan="2">
            <asp:Literal ID="Literal19" runat="server" Text="<%$ Resources:TimeLive.Resource, Selection %>" /></th>
        <td colspan="1">
        </td>
        <th class="FormViewSubHeader" colspan="2">
             <asp:Literal ID="Literal20" runat="server" Text="<%$ Resources:TimeLive.Resource, Selection %>" /></th>
    </tr>
    <tr>
       

        <th class="FormViewSubheader" style="width: 40%">
            <asp:ListBox ID="SelectedListBox" runat="server" Height="280px" Rows="8" 
                Width="100%" CssClass="listbox"></asp:ListBox></th>
        <th valign="top" class="FormViewSubHeader" style="vertical-align:top; padding-top: 5px;">
            <ew:ListTransfer ID="ListTransfer1" runat ="server" Text = "<%$ Resources:TimeLive.Resource, Move Up %>" TransferType="Up" TransferFromID="SelectedListBox" ImageUrl="~/Images/UpArrow.gif" />
            <br />
            <br />
            <ew:ListTransfer ID="ListTransfer2" runat ="server" Text = "<%$ Resources:TimeLive.Resource, Move Down %>" TransferType="Down" TransferFromID="SelectedListBox" ImageUrl="~/Images/DownArrow.gif" />
           
        </th>
        <td style="width: 271px" valign="top">
        </td>
        <th class="FormViewSubheader" valign="top" style="width: 40%">
            <asp:ListBox ID="ReportGroupListBox" runat="server" Height="280px" Rows="8" 
                Width="100%" CssClass="listbox">
            </asp:ListBox>
        </th>
        <th class="FormViewSubHeader" valign="top" style="vertical-align:top; padding-top: 5px;">
            <ew:ListTransfer ID="ListTransfer3" runat ="server" Text = "<%$ Resources:TimeLive.Resource, Move Up %>" TransferType="Up" TransferFromID="ReportGroupListBox" ImageUrl="~/Images/UpArrow.gif" />
            <br />
            <br />
            <ew:ListTransfer ID="ListTransfer4" runat ="server" Text = "<%$ Resources:TimeLive.Resource, Move Down %>" TransferType="Down" TransferFromID="ReportGroupListBox" ImageUrl="~/Images/DownArrow.gif" />
        </th>
    </tr>
    <tr><td colspan="5" style=" text-align:right; padding-top:5px;">
     <asp:Button ID="FinishPreviousButton" runat="server" CausesValidation="False" CommandName="MovePrevious"
            Text="Previous" Width="68px" />
            <asp:Button ID="FinishButton" runat="server" CommandName="MoveComplete" 
            Text="Finish" Width="68px" />
    </td></tr>
</table>
</td></tr></table>
</asp:WizardStep>

</WizardSteps>
    <StepNavigationTemplate>
    <div style="padding-top: 5px;" >
        <asp:Button ID="StepPreviousButton" runat="server" CausesValidation="False" CommandName="MovePrevious"
            Text="Previous" Width="68px" />
        <asp:Button ID="StepNextButton" runat="server" CommandName="MoveNext" Text="Next" Width="68px" />
        </div>
    </StepNavigationTemplate>
       <StartNavigationTemplate>
     <asp:Button ID="StartNextButton" runat="server" CommandName="MoveNext" Text="Next"  Width="68px"/>
    </StartNavigationTemplate>
    <FinishNavigationTemplate>
     </FinishNavigationTemplate>
</asp:Wizard>
