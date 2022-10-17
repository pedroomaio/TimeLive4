<%@ Page Language="VB" AutoEventWireup="false" CodeFile="GoogleCallBack.aspx.vb" Inherits="GoogleCallBack" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
       <script type="text/javascript" language="javascript">
           try {
               // First, parse the query string
               var params = {}, queryString = location.hash.substring(1),
    regex = /([^&=]+)=([^&]*)/g, m;
               while (m = regex.exec(queryString)) {
                   params[decodeURIComponent(m[1])] = decodeURIComponent(m[2]);
               }
               var ss = queryString.split("&")
               window.location = "Default.aspx?" + ss[1];

           } catch (exp) {
               alert(exp.message + " here 1");
           }
        </script>
    </div>
    </form>
</body>
</html>
