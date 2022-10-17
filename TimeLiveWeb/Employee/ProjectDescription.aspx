<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ProjectDescription.aspx.vb" Inherits="Employee_ProjectDescription" Theme="SkinFile" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<link href="../Styles.css" rel="stylesheet" type="text/css" />
    <title>TimeLive - Projects</title>
</head>
<body onunload="opener.location.reload();">
    <form id="form1" runat="server">
    
    <div>
        </div>
        <asp:FormView ID="FormView1" runat="server" DataSourceID="dsProjectDescriptionObject"
            DefaultMode="Edit" SkinID="formviewSkinEmployee" Width="400px">
            <EditItemTemplate>
                <table width="400">
                    <tr>
                        <td class="FormViewSubHeader" colspan="2" rowspan="1">
                            
                            <asp:Literal ID="Literal5" runat="server" Text="<%$ Resources:TimeLive.Resource, Project Description%> " /></td>
                    </tr>
                    <tr>
                        <td align="right" class="FormViewLabelCell" style="width: 35%" valign="top">
                            <asp:Literal ID="Literal1" runat="server" Text="<%$ Resources:TimeLive.Resource, Discription:%> " /></td>
                        </td>
                        <td style="width: 65%">
                            <asp:TextBox ID="ProjectDescriptionTextBox" runat="server" Text='<%# Bind("ProjectDescription") %>' Height="50px" TextMode="MultiLine" Width="243px"></asp:TextBox><asp:RequiredFieldValidator
                                ID="RequiredFieldValidator1" runat="server" ControlToValidate="ProjectDescriptionTextBox"
                                CssClass="ErrorMessage" Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td class="FormViewLabelCell">
                        </td>
                        <td>
                        
                            <asp:Button ID="btnUpdate" runat="server" CommandName="Update" Text="<%$ Resources:TimeLive.Resource, Update_text%> " OnClientClick="window.close()" />
                                                 
                            </td>
                    </tr>
                </table>
            </EditItemTemplate>
        </asp:FormView>
        <asp:ObjectDataSource ID="dsProjectDescriptionObject" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetAccountProjectsByAccountProjectId" TypeName="AccountProjectBLL"
            UpdateMethod="UpdateProjectDescription" DeleteMethod="DeleteAccountProject" InsertMethod="AddAccountProject">
            <UpdateParameters>
                <asp:Parameter Name="ProjectDescription" Type="String" />
                <asp:QueryStringParameter DefaultValue="9" Name="Original_AccountProjectId" QueryStringField="AccountProjectId"
                    Type="Int32" />
            </UpdateParameters>
            <SelectParameters>
                <asp:QueryStringParameter DefaultValue="9" Name="AccountProjectId" QueryStringField="AccountProjectId"
                    Type="Int32" />
            </SelectParameters>
            <DeleteParameters>
                <asp:Parameter Name="Original_AccountProjectId" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="AccountId" Type="Int32" />
                <asp:Parameter Name="AccountProjectTypeId" Type="Int32" />
                <asp:Parameter Name="AccountClientId" Type="Int32" />
                <asp:Parameter Name="AccountPartyContactId" Type="Int32" />
                <asp:Parameter Name="AccountPartyDepartmentId" Type="Int32" />
                <asp:Parameter Name="ProjectBillingTypeId" Type="Int32" />
                <asp:Parameter Name="ProjectName" Type="String" />
                <asp:Parameter Name="ProjectDescription" Type="String" />
                <asp:Parameter Name="StartDate" Type="DateTime" />
                <asp:Parameter Name="DeadLine" Type="DateTime" />
                <asp:Parameter Name="ProjectStatusId" Type="Int32" />
                <asp:Parameter Name="LeaderEmployeeId" Type="Int32" />
                <asp:Parameter Name="ProjectManagerEmployeeId" Type="Int32" />
                <asp:Parameter Name="TimeSheetApprovalTypeId" Type="Int32" />
                <asp:Parameter Name="ExpenseApprovalTypeId" Type="Int32" />
                <asp:Parameter Name="EstimatedDuration" Type="Int32" />
                <asp:Parameter Name="EstimatedDurationUnit" Type="String" />
                <asp:Parameter Name="ProjectCode" Type="String" />
                <asp:Parameter Name="DefaultBillingRate" Type="Decimal" />
                <asp:Parameter Name="ProjectBillingRateTypeId" Type="Int32" />
                <asp:Parameter Name="CreatedOn" Type="DateTime" />
                <asp:Parameter Name="CreatedByEmployeeId" Type="Int32" />
                <asp:Parameter Name="ModifiedOn" Type="DateTime" />
                <asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" />
            </InsertParameters>
        </asp:ObjectDataSource>
    </form>
</body>
</html>
