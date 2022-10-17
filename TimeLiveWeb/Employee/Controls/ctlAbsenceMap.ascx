<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlAbsenceMap.ascx.vb" Inherits="Employee_Controls_ctlAbsenceMap" %>
<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
       <table width="100%"  class="xFormView" style="margin-top: 20px;">
           <tr>
               <td>
                    <table width="60%" style="min-width:800px" class="xFormView" >
                        <tr>
                            <th colspan="2" class="caption">
                                <asp:Literal ID="Literal1" runat="server" Text="<%$ Resources:TimeLive.Resource, Absence Map%> "/>
                            </th>
                        </tr>
                        <tr>
                            <th colspan="2" class="FormViewSubHeader">
                                <asp:Literal ID="Literal2" runat="server" Text="<%$ Resources:TimeLive.Resource, Search Parameters%> " />
                            </th>
                        </tr>
                        <tr>
                            <td align="right" style="width: 20%">
                                <asp:Label ID="Label8" runat="server" Font-Bold="True" Font-Size="11px" Width="150px">
                                    <asp:Literal ID="Literal7" runat="server" Text="<%$ Resources:TimeLive.Resource, Business Unit:%> "/></asp:Label></td><td style="width: 78%"><asp:DropDownList ID="ddlDepartmens" runat="server" Width="250px"  AppendDataBoundItems=True DataSourceId ="dsDepartments" DataTextField ="DepartmentName" DataValueField ="AccountDepartmentId"  AutoPostBack="True">
                                    <asp:ListItem Text ="<All>" Value ="0"></asp:ListItem></asp:DropDownList></td></tr><tr>
                            <td style ="width :20%" align="right" >

                                <asp:Literal ID="EmployeNameddl" runat="server" Text="<%$ Resources:TimeLive.Resource, Employees:%>" ></asp:Literal></td><td style="width :90% " >
                                <asp:ListBox ID="ddlEmployeesDepertment" SelectionMode="Multiple" runat="server" ClientIDMode="Static" DataSourceID="dsEmployeesDepartment" DataTextField="EmployeeNameWithCode" DataValueField="AccountEmployeeId" Style="height: 100px; width: 240px"></asp:ListBox>
                                <asp:Button ID="Btn_Right_Transfer" ClientIDMode="Static" runat="server" Text=">>" Font-Size="Smaller" CssClass="button blue-gradient glossy RigthTransferBt" Style="left: 19px; bottom: 20px;" OnClientClick="RightButton(); return false;" />
                                <asp:Button ID="Btn_Left_Transfer" ClientIDMode="Static" runat="server" Text="<<" Font-Size="Smaller" CssClass="button blue-gradient glossy LeftTransferBt" Style="right: 19px; top: 20px;" OnClientClick="LeftButton(); return false;" />
                                <asp:ListBox ID="ddlEmployeesDepertment2" ClientIDMode="Static" runat="server" SelectionMode="Multiple" Style="height: 100px; width: 240px"></asp:ListBox>
                                <asp:HiddenField ID="hdfield" runat="server" Value="" ClientIDMode ="Static"  />
                               
                               
                            </td>
                        </tr>              


                        <tr>
                            <td style="width: 20%" align="right">
                                <asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Size="11px" Width="150px">
                                 <asp:Literal ID="Literal5" runat="server" Text="<%$ Resources:TimeLive.Resource, Start Date:%> " /></asp:Label>
                            </td>
                            <td style="width: 78%" colspan="2">
                                <ew:CalendarPopup ID="StartDateTextBox" runat="server" SkinID="DatePicker" Width="68px" >
                                </ew:CalendarPopup>
                                
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 20%" align="right">
                                <asp:Label ID="Label7" runat="server" Font-Bold="True" Font-Size="11px" Width="150px">
                                    &nbsp
                                    <asp:Literal ID="Literal6" runat="server" Text="<%$ Resources:TimeLive.Resource, End Date:%> " /></asp:Label>
                            </td>
                            <td style="width: 78%" colspan="2">
                                <ew:CalendarPopup ID="EndDateTextBox" runat="server" SkinID="DatePicker" Width="68px" >
                                </ew:CalendarPopup>
                            </td>
                        </tr>
                        <tr>
                            <td style ="width :20%" align="right" >
                                <asp:Literal ID="LocationLtl" runat ="server" Text="<%$ Resources:TimeLive.Resource, Location:%>"></asp:Literal></td><td >

                                <asp:RadioButtonList  BorderStyle="None" AppendDataBoundItems=True  ID="chkLocation" runat="server" RepeatDirection="Horizontal" AutoPostBack ="true" DataSourceId ="dsLocations" DataTextField="AccountLocation" DataValueField ="AccountLocationId">
                                    <asp:ListItem Text="All" Value="0" Selected="True" ></asp:ListItem></asp:RadioButtonList></td></tr><tr>
                            <td align="right" style="width: 20%">
                                &nbsp; </td><td style="width: 39%; padding-bottom: 5px;">
                                <asp:Button ID="btnShow" runat="server" OnClick ="btnShow_Click" Text="<%$ Resources:TimeLive.Resource, Show_text%> " />
                            </td>
                        </tr>
                    </table>
               </td>
               <td>
                   <x:GridView runat="server" DataSourceID="dsTimeOffStatusGridViewObject" AutoGenerateColumns="False" Width ="300px" HeaderStyle-ForeColor ="white"  HeaderStyle-BackColor ="#004795" CssClass ="absenceTimeOffTypeLegend">
                       <Columns>
                           <asp:TemplateField HeaderText="<%$ Resources:TimeLive.Resource, Color%> " ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" ItemStyle-Height="8px">
                               
                               <ItemTemplate>
                                    <asp:Panel ID="pnlColor" runat="server" BackColor='<%# UIUtilities.ConvertFromHexToColor(Eval("Color").ToString()) %>' style="width: 10px; height: 10px;"></asp:Panel>
                                </ItemTemplate>
                                <ItemStyle Width ="4%"/>
                            </asp:TemplateField>

                            <asp:BoundField DataField="AccountTimeOffType" HeaderText="<%$ Resources:TimeLive.Resource, Time Off Type%> " ItemStyle-Height="8px">
                                <ItemStyle Width="10%" Wrap="false" />
                            </asp:BoundField>
                       </Columns>
                       
                   </x:GridView>
               </td> 
           </tr>

       </table>
        <asp:ObjectDataSource ID="dsTimeOffStatusGridViewObject" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetAccountTimeOffTypesByAccountIdAndRequestRequired" TypeName="AccountTimeOffTypeBLL">
            <SelectParameters>
                <asp:SessionParameter Name="AccountId" SessionField="AccountId" Type="Int32" DefaultValue="354"/>
                <asp:Parameter Name="AccountTimeOffTypeId" Type="Single" />
                <asp:Parameter Name="RequestRequired" Type ="Boolean" DefaultValue ="true" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="dsDepartments" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetAccountDepartmentsByAccountIdAndIsDisabled"
            TypeName="AccountDepartmentBLL" > 
            <SelectParameters >
                <asp:SessionParameter Name="AccountId" SessionField="AccountId" Type ="Int32" DefaultValue="354"/>
                <asp:SessionParameter Name="AccountDepartmentId"  Type ="Int32" DefaultValue="0"/>
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="dsEmployeesDepartment" runat="server" OldValuesParameterFormatString="original_{0}" 
            SelectMethod="GetAccountEmployeesByLocationAndDepartmentAndIsNotDisabled" TypeName ="AccountEmployeeBLL">
            <SelectParameters >
                <asp:SessionParameter Name="AccountId" SessionField="AccountId" Type ="Int32" DefaultValue="354"/>
                <asp:ControlParameter ControlID="chkLocation" Name="AccountLocationId" Type ="Int32" DefaultValue ="309" />
                <asp:ControlParameter ControlID="ddlDepartmens" Name="AccountDepartmentId" PropertyName="SelectedValue"  Type="String"/>
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="dsLocations" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetAccountLocationsByAccountIdAndIsNotDisabled"
            TypeName="AccountLocationBLL" > 
            <SelectParameters >
                <asp:Parameter Name="AccountId" Type ="Int32" DefaultValue="354"/>
            </SelectParameters>
        </asp:ObjectDataSource>
    <ContentTemplate>
        <br />
        <br />

        <a id="List" href="#List" style="white-space:pre-line">
        <asp:Table Id="AbsenceMapTable" runat="server" class="xGridViewTS2" >
           
        </asp:Table>
       </a>
    </ContentTemplate>
    
<script>
    function EditArray() {
        var s = $('#ddlEmployeesDepertment2 option').map(function () {
            return this.text.toString() + "," + this.value.toString();;
        }).get().join(';');
        $('#hdfield').val(s);
    }

    function RightButton()
    {
        $val = $("#ddlEmployeesDepertment").val();

        for (x in $val) {
            var fromItem = $("#ddlEmployeesDepertment option[value=" + $val[x] + "]");
            if ($("#ddlEmployeesDepertment2:has(option[value=" + $val[x] + "])").length > 0) {
                fromItem.val(fromItem.val() + "-2").text(fromItem.text() + " -2")
            };
            $("#ddlEmployeesDepertment2").append(fromItem);
        };
        $("#ddlEmployeesDepertment2 option[value=0]").appendTo($("#ddlEmployeesDepertment2"));
        EditArray();
    }

    function LeftButton() {
        $val = $("#ddlEmployeesDepertment2").val();

        for (x in $val) {
            var fromItem = $("#ddlEmployeesDepertment2 option[value=" + $val[x] + "]");
            if ($("#ddlEmployeesDepertment:has(option[value=" + $val[x] + "])").length > 0) {
                fromItem.val(fromItem.val() + "-2").text(fromItem.text() + " -2")
            };
            $("#ddlEmployeesDepertment").append(fromItem);
        };
        $("#ddlEmployeesDepertment option[value=0]").appendTo($("#ddlEmployeesDepertment"));
        EditArray();
    }

    function LoadValues() {
        debugger;
        var stringHdinField = $('#hdfield').val();
        var FirstSplit = stringHdinField.split(';');
        var Final = "";

        FirstSplit.forEach(function (x) {
            Final = Final + "," + x.split(',')[1];
        });

        Final = Final.substring(1);

        var FinalArray = Final.split(',');

        for (x in FinalArray) {
            var fromItem = $("#ddlEmployeesDepertment option[value=" + FinalArray[x] + "]");
            if ($("#ddlEmployeesDepertment2:has(option[value=" + FinalArray[x] + "])").length > 0) {
                fromItem.val(fromItem.val() + "-2").text(fromItem.text() + " -2")
            };
            $("#ddlEmployeesDepertment2").append(fromItem);
        };
        $("#ddlEmployeesDepertment2 option[value=0]").appendTo($("#ddlEmployeesDepertment2"));
        EditArray();

    }
</script>
