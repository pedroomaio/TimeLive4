<%@ Page Language="VB" AutoEventWireup="false" CodeFile="LoginDetail.aspx.vb" Inherits="LoginDetail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login Detail</title>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Larger" >Login Detail</asp:Label>
    
        <br />
        <table class="style1">
            <tr>
                <td width="500px">
                    <asp:TextBox ID="TextBox1" runat="server" Height="673px" ReadOnly="True" 
                        TextMode="MultiLine" Width="500px"></asp:TextBox>
                </td>
                <td valign="top">
                    Login Details:
                    <asp:Label ID="Label3" runat="server" Font-Bold="True" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
