<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlAccountCustomFields.ascx.vb" Inherits="AccountAdmin_Controls_ctlAccountCustomFields" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
                    <x:GridView ID="GridView1" runat="server" AllowSorting="True" 
                        AutoGenerateColumns="False" Caption="<%$ Resources:TimeLive.Resource, Custom Field %>" CssClass="TableView" 
                        DataSourceID="dsAccountCustomFieldForGridView" 
                        SkinID="xgridviewSkinEmployee" Width="98%" 
                        DataKeyNames="MasterEntityTypeId">
                        <Columns>
                            <asp:BoundField DataField="MasterEntityTypeName" 
                                HeaderText="<%$ Resources:TimeLive.Resource, Entity Type %>" SortExpression="MasterEntityTypeName" >
                            <HeaderStyle Width="94%" />
                            </asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# Eval("MasterEntityTypeId", "~/AccountAdmin/AccountCustomFieldManage.aspx?MasterEntityTypeId={0}") %>' Text="Manage"></asp:HyperLink>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="4%" />
                            </asp:TemplateField>
                        </Columns>
                    </x:GridView>
                    <asp:ObjectDataSource ID="dsAccountCustomFieldForGridView" runat="server" 
                        OldValuesParameterFormatString="original_{0}" 
                        SelectMethod="GetMasterEntityType" TypeName="AccountCustomFieldBLL" 
                        DataObjectTypeName="System.Guid" DeleteMethod="DeleteAccountCustomField" 
                        InsertMethod="AddCustomFieldManage" UpdateMethod="UpdateCustomFieldManage">
                        <InsertParameters>
                            <asp:Parameter Name="AccountId" Type="Int32" />
                            <asp:Parameter DbType="Guid" Name="MasterCustomDataTypeId" />
                            <asp:Parameter DbType="Guid" Name="MasterEntityTypeId" />
                            <asp:Parameter Name="DatabaseFieldName" Type="String" />
                            <asp:Parameter Name="CustomFieldName" Type="String" />
                            <asp:Parameter Name="CustomFieldCaption" Type="String" />
                            <asp:Parameter Name="DefaultValue" Type="String" />
                            <asp:Parameter Name="MaximumLength" Type="Int32" />
                            <asp:Parameter Name="MinimumValue" Type="Int32" />
                            <asp:Parameter Name="MaximumValue" Type="Int32" />
                            <asp:Parameter Name="DropDownOptions" Type="String" />
                            <asp:Parameter Name="IsRequired" Type="Boolean" />
                            <asp:Parameter Name="IsDisabled" Type="Boolean" />
                            <asp:Parameter Name="CreatedOn" Type="DateTime" />
                            <asp:Parameter Name="CreatedByEmployeeId" Type="Int32" />
                            <asp:Parameter Name="ModifiedOn" Type="DateTime" />
                            <asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" />
                        </InsertParameters>
                        <UpdateParameters>
                            <asp:Parameter DbType="Guid" Name="Original_AccountCustomFieldId" />
                            <asp:Parameter Name="AccountId" Type="Int32" />
                            <asp:Parameter DbType="Guid" Name="MasterCustomDataTypeId" />
                            <asp:Parameter DbType="Guid" Name="MasterEntityTypeId" />
                            <asp:Parameter Name="DatabaseFieldName" Type="String" />
                            <asp:Parameter Name="CustomFieldName" Type="String" />
                            <asp:Parameter Name="CustomFieldCaption" Type="String" />
                            <asp:Parameter Name="DefaultValue" Type="String" />
                            <asp:Parameter Name="MaximumLength" Type="Int32" />
                            <asp:Parameter Name="MinimumValue" Type="Int32" />
                            <asp:Parameter Name="MaximumValue" Type="Int32" />
                            <asp:Parameter Name="DropDownOptions" Type="String" />
                            <asp:Parameter Name="IsRequired" Type="Boolean" />
                            <asp:Parameter Name="IsDisabled" Type="Boolean" />
                            <asp:Parameter Name="CreatedOn" Type="DateTime" />
                            <asp:Parameter Name="CreatedByEmployeeId" Type="Int32" />
                            <asp:Parameter Name="ModifiedOn" Type="DateTime" />
                            <asp:Parameter Name="ModifiedByEmployeeId" Type="Int32" />
                        </UpdateParameters>
                    </asp:ObjectDataSource>
    </ContentTemplate>
</asp:UpdatePanel>



