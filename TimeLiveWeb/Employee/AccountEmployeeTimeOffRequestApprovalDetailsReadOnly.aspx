<%@ Page Language="VB" AutoEventWireup="false" CodeFile="AccountEmployeeTimeOffRequestApprovalDetailsReadOnly.aspx.vb" Inherits="Employee_AccountEmployeeTimeOffRequestApprovalDetailsReadOnly" title="TimeLive - Time Off Request Approval Detail" %>

<%@ Register Src="Controls/ctlAccountEmployeeTimeOffRequestApprovalDetailsReadOnly.ascx"
    TagName="ctlAccountEmployeeTimeOffRequestApprovalDetailsReadOnly" TagPrefix="uc2" %>

<%@ Register Assembly="eWorld.UI"
    Namespace="eWorld.UI" TagPrefix="ew" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<link href="../Styles.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <uc2:ctlAccountEmployeeTimeOffRequestApprovalDetailsReadOnly ID="ctlAccountEmployeeTimeOffRequestApprovalDetailsReadOnly1"
            runat="server" />
    </div>
    </form>
</body>
</html>


