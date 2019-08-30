  <%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Web.admin.manager._default" %>

<!DOCTYPE html>
<html lang="en">
<head>
	<meta charset="UTF-8">
	<link rel="stylesheet" href="../css/global.css">
	<link rel="stylesheet" type="text/css" href="../css/main.css">
	<link rel="stylesheet" type="text/css" href="../css/pagination.css">
</head>
<body id="iframe-body">
	<div class="main">
		<!-- 位置导航 -->
		<div class="address">
			<ul>
				<li><a href="index.php?c=manager&m=show" target="iframe">管理员管理</a></li>
				<li>管理员管理</li>
			</ul>
			<span>
				<a href="add.aspx"  target="iframe">新增管理</a>
			</span>
		</div>
        <span class="message"><%=Request["message"] %></span>
		<!-- 正文 -->
		<table class="table" cellpadding="1" cellspacing="1">
			<tr>
				<th>用户名</th>
				<th>等级</th>
				
				<th>最后登录IP</th>
				<th>最后登录时间</th>
				<th>注册时间</th>
				<th>操作</th>
			</tr>
			<%foreach(DAL.adminData.Value av in list){ %>
			<tr>
				<td><%=av.userid %></td>
				<td><%=DAL.RoleInfoData.row(av.role).RoleName %></td>
				<td><%=av.loginIp %></td>
				<td><%=av.loginTime %></td>
				<td><%=av.createTime %></td>
				<td><a href="update.aspx?id=<%=av.id %>" target="iframe">编辑</a> | <a href="manager.ashx?id=<%=av.id %>&act=cz" target="iframe">重置密码</a> | <a class="del" alt="../manager/manager.ashx?id=<%=av.id %>&act=del" href="javascript:void(0);">删除</a></td>
			</tr>	
			<%}if(list.Count<=0){ %>

			<tr><td colspan="7">没有任何数据!</td></tr>
			<%} %>
		</table>
	
	</div>
	<script src="http://libs.baidu.com/jquery/1.9.0/jquery.js"></script>
	<script src="../js/modal.js"></script>
</body>
</html>