<%@ Page Language="VB" MasterPageFile="~/Masters/MasterPageEmployee.master" AutoEventWireup="false" CodeFile="TimeSheetApproval.aspx.vb" Inherits="ProjectAdmin_TimeSheetApproval" title="TimeLive - Time Sheet Approval" Theme ="SkinFile" %>

<%@ Register Src="Controls/ctlTimeSheetApprovalSummary.ascx" TagName="ctlTimeSheetApprovalSummary"
    TagPrefix="uc2" %>

<%@ Register Assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2"
    Namespace="eWorld.UI" TagPrefix="ew" %>

<asp:Content Content ID="C" ContentPlaceHolderID="C" Runat="Server">
    <script src="../js/libs/jquery-1.7.2.min.js"></script>
    <script type="text/javascript">

        $(document).ready(function() {
            $(function () {
                $('.xGridView input:radio').click(function () {
                    var $radio = $(this);

                    // if this was previously checked
                    if ($radio.data('waschecked') == true) {
                        $radio.prop('checked', false);
                        $radio.data('waschecked', false);
                    }
                    else
                        $radio.data('waschecked', true);

                    // remove was checked from other radios
                    $radio.siblings('.xGridView input:radio').data('waschecked', false);
                });
            });
        });
        
    </script>

    <table width="98%">
        <tr>
            <td colspan="2">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                    <table class="xFormView" ><tr><td>
                        <table class="xFormView" style="width: 600px; height: 1px">
                            <tbody>
                                <tr>
                                    <th class="caption" colspan="2" style="height: 21px">
                                        <asp:Literal ID="Literal3" runat="server" Text="<%$ Resources:TimeLive.Resource, Time Sheet Approval%> "></asp:Literal></th>
                                </tr>
                                <tr>
                                    <th class="FormViewSubHeader" colspan="2" style="height: 21px">
                                        <asp:Literal ID="Literal4" runat="server" Text="<%$ Resources:TimeLive.Resource, Search Parameters%> "></asp:Literal></th>
                                </tr>
                                <tr>
                                    <td align="right" class="formviewlabelcell" width="100" style="height: 24px">
                                        <asp:Literal ID="Literal7" runat="server" Text="<%$ Resources:TimeLive.Resource, Employee Name:%> " /></td>
                                    <td style="height: 24px" width="300">
                                        <asp:DropDownList ID="ddlAccountEmployeeId" runat="server" 
                                            Width="260px" AppendDataBoundItems="True">
                                            <asp:ListItem Value="0" Selected="True" Text="<%$ Resources:TimeLive.Resource, ALLs%> "></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                             <tr>
                               <td align="right" class="FormViewLabelCell">
                                   <asp:Literal ID="Literal2" runat="server" Text="<%$ Resources:TimeLive.Resource, Include Date Range:%> "></asp:Literal></td>
                               <td style="width: 250px">
                                  <asp:CheckBox ID="chkIncludeDateRange" runat="server" /></td>
                             </tr>
                                <tr>
                                    <td align="right" class="formviewlabelcell">
                                        <asp:Literal ID="Literal5" runat="server" Text="<%$ Resources:TimeLive.Resource, Start Date:%> "></asp:Literal></td>
                                    <td style="height: 21px" width="300">
                                        <ew:calendarpopup id="txtTimeEntryStartDate" runat="server" SkinId="DatePicker" upperbounddate="9999-12-31" Width="55px">
            </ew:calendarpopup>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" class="formviewlabelcell">
                                        <asp:Literal ID="Literal1" runat="server" Text="<%$ Resources:TimeLive.Resource, End Date:%> "></asp:Literal></td>
                                    <td style="height: 21px" width="300">
                                        <ew:calendarpopup id="txtTimeEntryEndDate" runat="server" SkinId="DatePicker" upperbounddate="9999-12-31" Width="55px">
            </ew:calendarpopup>
                                    </td>
                                </tr>
                                <% If 1<>1 Then%>
                                <tr>
                                    <td align="right" class="formviewlabelcell">
                                        <asp:Literal ID="Literal8" runat="server" Text="<%$ Resources:TimeLive.Resource, Summarized:%> "></asp:Literal></td>
                                    </td>
                                    <td style="height: 21px" width="300">
                                        <asp:CheckBox ID="chkSummarized" runat="server" OnCheckedChanged="chkSummarized_CheckedChanged" /></td>
                                </tr>
                                <%End If%>
                                <tr>
                                    <td align="right" class="formviewlabelcell">
                                    </td>
                                    <td style="width: 300px; height: 21px; padding-bottom: 5px; padding-top: 5px;" >
                                        <asp:Button ID="btnShow" runat="server" Text="<%$ Resources:TimeLive.Resource, Show_text%> "
                                            Width="50px" OnClick="btnShow_Click" /></td>
                                </tr>
                            </tbody>
                        </table>
                        </td></tr></table>
                        <br />
                        <asp:ObjectDataSource ID="dsAccountEmployeeObject" runat="server" OldValuesParameterFormatString="original_{0}"
                            SelectMethod="GetEmployeesForTimeEntryApproval" TypeName="AccountEmployeeTimeEntryBLL">
                            <SelectParameters>
                                <asp:SessionParameter DefaultValue="129" Name="ApproverEmployeeId" SessionField="AccountEmployeeId"
                                    Type="Int32" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                        &nbsp;<asp:Button ID="btnUpdate1" runat="server" OnClick="btnUpdate1_Click" Text="<%$ Resources:TimeLive.Resource, Update Time Entry Approvals%> "/>
                        <br />
                        <br />
                        <uc2:ctlTimeSheetApprovalSummary ID="CtlTimeSheetApprovalSummary1" runat="server" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
       </table>
   


</asp:Content>

