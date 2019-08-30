<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Web.admin.management._default" %>

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
				<li><a href="default.aspx" target="iframe">权限管理</a></li>
				<li>权限列表</li>
			</ul>
			<span>
				<a href="add.aspx"  target="iframe">新增等级</a>
			</span>
		</div>
		<!-- 正文 -->
		<table class="table" cellpadding="1" cellspacing="1">
			<tr>
				<th>#ID</th>
				<th>权限名称</th>
				<th>权限描述</th>
                <th>分配权限</th>
				<th>操作</th>
			</tr>
			<%foreach(DAL.RoleInfoData.Value rv in list){ %>
			<tr>
				<td><%=rv.id %></td>
				<td><%=rv.RoleName %></td>
				<td><%=rv.RoleDesc %></td>
                <td><a href="roleright.aspx?roleid=<%=rv.id %>" target="iframe">分配权限</a></td>
				<td><a href="update.aspx?id=<%=rv.id %>" target="iframe">编辑</a> | <a class="del" alt="../management/level.ashx?del=<%=rv.id %>" href="javascript:void(0);">删除</a></td>
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