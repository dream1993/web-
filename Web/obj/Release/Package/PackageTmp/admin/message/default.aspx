<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Web.admin.message._default" %>

<!DOCTYPE html>
<html lang="en">
<head>
	<meta charset="UTF-8">
	<link rel="stylesheet" href="../css/global.css">
	<link rel="stylesheet" type="text/css" href="../css/pagination.css">
</head>

<body id="iframe-body">
	<div class="main">
		<!-- 位置导航 -->
		<div class="address">
			<ul>
				<li><a href="default.aspx" target="iframe">系统消息管理</a></li>
				<li>系统消息列表</li>
			</ul>
			<span>
				<a href="add.aspx"  target="iframe">新增系统消息</a>
			</span>
		</div>
		<!-- 正文 -->
		<table class="table" cellpadding="1" cellspacing="1">
			<tr>
				<th>#ID</th>
				<th>标题</th>
				<th>操作</th>
			</tr>
			<%foreach (DAL.sysMessageData.Value rv in list)
     { %>
			<tr>
				<td><%=rv.id %></td>
				<td><%=rv.title %></td>
				<td><a href="update.aspx?id=<%=rv.id %>" target="iframe">编辑</a> </td>
			</tr>	
            <%}if(list.Count<=0){  %>
			<tr><td colspan="7">没有任何数据!</td></tr>
			<%} %>
		</table>
		<%--<div id="page">{$page}</div>--%>
	</div>
	<script src="http://libs.baidu.com/jquery/1.9.0/jquery.js"></script>
	<script src="../js/modal.js"></script>
</body>
</html>