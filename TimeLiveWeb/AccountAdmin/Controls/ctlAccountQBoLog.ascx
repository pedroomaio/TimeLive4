<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlAccountQBoLog.ascx.vb" Inherits="AccountAdmin_Controls_ctlAccountQBoLog" %>
<table class="xFormView"  style="border-right: 0; border-left: 0; border-bottom: 0; border-top: 0;" width="100%" >
<tr><td style="border-right: 0; border-left: 0; border-bottom: 0; border-top: 0;">
        <table class="xFormView" style="border-right: 0; border-left: 0; border-bottom: 0; border-top: 0;width: 100%;">

            <tr>
                <th class="caption" >
                    <asp:Literal ID="Literal7" runat="server" Text="QuickBook Log Reports"></asp:Literal></th>
            </tr>
    <tr>
        <td colspan="2" style="text-align:left; border-right: 0; border-left: 0; border-bottom: 0; border-top: 0;" >

                            <asp:DataList ItemStyle-VerticalAlign="Top" ItemStyle-Width="33%" Width="100%" ID="RDL" runat="server" RepeatDirection="Horizontal" RepeatColumns="1" >
                                             <ItemTemplate>                                                                                                                                                                       
                                            <table style="text-align:left; border-right: 0; border-left: 0; border-bottom: 0; border-top: 0; width:100%;">
                                            <tr>
                                            <th class="FormViewSubHeader" style="text-align:left; border-right: 0; border-left: 0; border-bottom: 0; border-top: 0; width:100%; padding-left: 13px;" >
                                            <%--<span id="RDLheader" runat="server" style="color:#006d8d;font-size:13px;font-weight:bold;">RDLheader</span>--%>
                                            <a id="hypRDLHeader" runat="server" style="color:#006d8d;font-size:13px;font-weight:bold;" >A</a>

                                            <%--<h5><strong><a id="hypKnowledgebaseArticle" runat="server" class="caption" ><%# Eval("EntityName")%></a>&nbsp;</strong></h5>--%>
                                            </th>
                                            </tr>
                                            </table>
                                            <%--<span style="padding: 3px 3px 3px 18px; background-repeat: no-repeat; background-position: left center; border: 0px Solid White;color: #555555;background-color: #efeff1;font-family: tahoma;font-size: 11px;font-weight: bold;margin-top: 5px;cursor: pointer;text-align:left;"><%# Eval("EntityName")%>&nbsp;</span>--%>
                                            <asp:DataList ItemStyle-VerticalAlign="Top" ItemStyle-Width="33%" Width="100%" ID="RDLchild" runat="server"  RepeatDirection="Horizontal" RepeatColumns="1" DataSource='<%# CType(Container.Dataitem,System.Data.DataRowView).Row.GetChildRows("myrelation") %>' EnableViewState="False" style="border-right: 0; border-left: 0; border-bottom: 0; border-top: 0;" OnItemDataBound="DataList2_ItemDataBound">  
                                                                                     
                                            <ItemTemplate>
                                            <%--<p style="font-size: 13px; font-weight: normal;padding: 10px 0px 3px 15px;line-height: 19px;">Welcome! You're either connecting to QuickBooks for first time or your current connection has been expired.</p>--%>
                                            <table width="100%" style="border-right: 0; border-left: 0; border-bottom: 0; border-top: 0;">
                                            <tr>
                                            
                                            <td align="left" style="font-size: 13px; font-weight: normal;padding: 10px 0px 3px 13px;line-height: 19px;border-right: 0; border-left: 0; border-bottom: 0; border-top: 0;" >
                                            <p>
                                            <%--<asp:LinkButton ID="btnAssySn" OnClick="btnAssySn_Click"  CausesValidation="True" runat="server" ><%#DataBinder.Eval(Container.DataItem, "[""linkbutton""]")%></asp:LinkButton>--%>
                                            <span id="lnkexecuteddate" runat="server" style="font-size:11px; font-weight:bold; line-height:16px;" ><%#DataBinder.Eval(Container.DataItem, "[""ExecutedDate""]")%></span>
                                            :&nbsp;<span style="font-size:11px; font-weight:normal; line-height:16px;" ><%#DataBinder.Eval(Container.DataItem, "[""DataDisplayName""]")%></span>
                                            <span style="font-size:11px; font-weight:normal; line-height:16px;" ><%#DataBinder.Eval(Container.DataItem, "[""Message""]")%></span>
                                            .<span style="font-size:11px; font-weight:normal; line-height:16px;" ><%#DataBinder.Eval(Container.DataItem, "[""MessageDetail""]")%></span>
                                            </p>
                                            </td>  
                                            
                                            </tr>
                                            </table>                                                                                                                   
                                            
                                            </ItemTemplate>                                              
                                            </asp:DataList>                                             
                                        </ItemTemplate>                                           
                            </asp:DataList> 
            <asp:Button ID="btnAssySn" runat="server" Text="Button" style="display: none"/>

</td>
</tr>

</table>
</td>
</tr>

</table>
