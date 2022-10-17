<%@ Control ClassName="ctlLiveReportFilter"  Language="VB" AutoEventWireup="false" CodeFile="ctlLiveReportFilter.ascx.vb" Inherits="WebReport_ctlLiveReportFilter" %>
<asp:Button ID="btnShow" runat="server"  />
<asp:HiddenField id="hdnFieldValues" runat="server"/> 
<%--<asp:Table ID="TableForHeader" runat="server" Width="700px" CssClass="xFormView">
</asp:Table>--%>
<script src="../js/libs/jquery-1.7.2.min.js"></script>
<script type="text/javascript">
        
        $(document).ready(function() {
            $(function () {
                $('.UndoChecked input:radio').click(function () {
                    var $radio = $(this);

                    // if this was previously checked
                    if ($radio.data('waschecked') == true) {
                        $radio.prop('checked', false);
                        $radio.data('waschecked', false);
                    }
                    else
                        $radio.data('waschecked', true);

                    // remove was checked from other radios
                    $radio.siblings('.UndoChecked input:radio').data('waschecked', false);
                });
            });
        });
        
</script>


<table class="xFormView" style=" border-bottom:1px Solid #d6dadf">
    <tr>
        <td>
            <asp:Table ID="FilterTable"  runat="server">
</asp:Table></td>
    </tr>
</table>