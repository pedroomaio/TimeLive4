<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ExpenseAttachmentReport.aspx.vb" Inherits="WebReport_ExpenseAttachmentReport" %>

<%@ Register src="Reports/Controls/ctlExpenseAttachmentReport.ascx" tagname="ctlExpenseAttachmentReport" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <uc1:ctlExpenseAttachmentReport ID="ctlExpenseAttachmentReport1" 
            runat="server" />
    
    </div>
    </form>
</body>
</html>
