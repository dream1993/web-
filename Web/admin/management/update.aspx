<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="update.aspx.cs" Inherits="Web.admin.management.update" %>

<!DOCTYPE html>
<html lang="en">
<head>
	<meta charset="UTF-8">
	<link rel="stylesheet" href="../css/global.css">
	<link rel="stylesheet" type="text/css" href="../css/level.css">
</head>
<body id="iframe-body">
	<div class="main">
		<!-- 位置导航 -->
		<div class="address">
			<ul>
				<li><a href="default.aspx" target="iframe">权限管理</a></li>
				<li>修改权限</li>
			</ul>
			<span>
				<a href="default.aspx"  target="iframe">返回</a>
			</span>
		</div>
		<!-- 正文 -->
		<form name="levelForm" action="level.ashx?id=<%=v.id %>" method="post">
		<table class="table level" cellpadding="1" cellspacing="1">
			<tr>
				<th>权限名称</th>
				<td><input type="text" name="RoleName" value="<%=v.RoleName %>" /></td>
			</tr>
			<tr>
				<th>权限描述</th>
				<td>
					<input type="text" name="RoleDesc" value="<%=v.RoleDesc %>" />
				</td>
			</tr>
			<tr><td></td><td><span class="btn btn_primary"><input type="submit" name="send" value="修改权限" /></span>
              <span class="message">  <%=Request["message"] %></span></td>
                </tr>
		</table>
		</form>
	</div>
</body>
</html>