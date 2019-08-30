<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Web.admin.web.message._default" %>



<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <link rel="stylesheet" href="../../css/global.css">
    <link rel="stylesheet" type="text/css" href="../../css/pagination.css">
</head>

<body id="iframe-body">
    <div class="main">
        <!-- 位置导航 -->
        <div class="address">
            <ul>
                <li><a href="default.aspx" target="iframe">留言管理</a></li>
                <li>留言列表</li>
            </ul>
           
        </div>
              
        <span class="maessage"><%=Request["message"] %></span>
        <table class="table" cellpadding="1" cellspacing="1">
            <tr>
                <th>编号</th>
                <th>标题</th>
                <th>详细信息</th>
                <th>时间</th>
                <th>操作</th>
            </tr>
            <%foreach (DAL.messageData.Value rv in list)
              { %>
            <tr>
                 <td><%=rv.id %></td>
                <td><%=rv.userid %></td>
                <td><%=rv.contents %></td>
                 <td><%=rv.createTime %></td>
                    <td> <a href="javaScript:void(0);" class="del" alt="default.aspx?delid=<%=rv.id %>">删除</a></td>
            </tr>
            <%} if (list.Count <= 0)
              {  %>
            <tr>
                <td colspan="7">没有任何数据!</td>
            </tr>
            <%} %>
        </table>
        
          <%if(list.Count>0){  %>
		<%=CL.Common.page1(Request.Url.ToString(),count,page,data) %>
        <%} %>
    </div>
    <script src="http://libs.baidu.com/jquery/1.9.0/jquery.js"></script>
    <script>
        $('.del').click(function () {
            if (confirm("确定删除吗?")) {
                location.href = $(this).attr('alt');
            } else {
                return false;
            }

        });

    </script>
  
   
    </body></html>