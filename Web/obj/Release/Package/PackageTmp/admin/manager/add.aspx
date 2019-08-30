<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="add.aspx.cs" Inherits="Web.admin.manager.add" %>
<!DOCTYPE html>
<html lang="en">
<head>
	<meta charset="UTF-8">
	<link rel="stylesheet" href="../css/global.css">
	<link rel="stylesheet" type="text/css" href="../css/main.css">
	<link rel="stylesheet" type="text/css" href="../css/manager.css">
</head>
<body id="iframe-body">
	<div class="main">
		<!-- 位置导航 -->
		<div class="address">
			<ul>
				<li><a href="default.aspx" target="iframe">管理员管理</a></li>
				<li>添加管理</li>
			</ul>
			<span>
				<a href="default.aspx"  target="iframe">返回</a>
			</span>
		</div>
		<!-- 正文 -->
		<form name="managerForm" action="manager.ashx?act=add" method="post">
		<table class="table manager" cellpadding="1" cellspacing="1">
			<tr>
				<th>等级</th>
				<td>
					<select name="level">
                         <option value="0">请选择等级</option>
						<%foreach(DAL.RoleInfoData.Value v in DAL.RoleInfoData.GetAllList()){ %>
                        <option value="<%=v.id %>"><%=v.RoleName %></option>
                        <%} %>
					</select><span class="error"></span>
				</td>
			</tr>
			<tr>
				<th>用户名</th>
				<td><input type="text" name="user"/><i class="loading"></i><span class="error"></span></td>
			</tr>
			<tr>
				<th>密码</th>
				<td><input type="password" name="password"/><span class="error"></span></td>
			</tr>
			<tr>
				<th>密码确认</th>
				<td><input type="password" name="notpassword"/><span class="error"></span></td>
			</tr>
			<tr><td></td><td><span class="btn btn_primary"><input type="submit" name="send" value="提交" disabled="true" /></span>
                 <span class="btn btn_default"><a href="default.aspx">取消</a></span><span class="manager"><%=Request["message"] %></span></td></tr>
		</table>
		</form>
	</div>
	<script src="http://libs.baidu.com/jquery/1.9.0/jquery.js"></script>
	<script src="../js/manager.js"></script>


    <br />
</body>
</html>