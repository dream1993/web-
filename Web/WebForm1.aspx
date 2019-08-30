<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Web.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style>
        body{font-family:"Microsoft YaHei"}
        .title{font-size:18px;color:#333;}
        .tit{font-size:16px;color:#666;}
        .con{color:#999;font-size:12px;}
        .con span{margin-right:15px;}
    </style>
</head>
<body>
    <a href="http://www.echuangwl.com" target="_blank"><img src="images/logo.png" /></a>
    <p class="title">网站案例集</p>
    <%foreach (DAL.typeData.Value tv in DAL.typeData.list(2))
      {
          List<DAL.articleData.Value> list = DAL.articleData.table(tv.id);
          %>
    <%if (list.Count > 0)
      { %>
    <p class="tit"><%=tv.title%></p>
   <%foreach (DAL.articleData.Value av in list)
     { %>
    <%if(av.url.IndexOf("http")>-1){ %>
    <p class="con"><span><%=av.title%></span><a href="<%=av.url%>" target="_blank"><%=av.url%></a></p>
    <%} %>
    <%}
      }
      }%>
</body>
</html>
