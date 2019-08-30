<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="update.aspx.cs" Inherits="Web.admin.manager.update" %>

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
				<li>修改</li>
			</ul>
			<span>
				<a href="default.aspx"  target="iframe">返回</a>
			</span>
		</div>
		<!-- 正文 -->
		<form name="managerForm" action="manager.ashx?act=update&id=<%=Request["id"] %>" method="post">
			<table class="table manager" cellpadding="1" cellspacing="1">
                <tr>
				<th>用户名</th>
				<td><%=av.userid %></td>
			</tr>
			<tr>
				<th>等级</th>
				<td>
					<select name="level">
						<%foreach(DAL.RoleInfoData.Value v in DAL.RoleInfoData.GetAllList()){ %>
                        <option value="<%=v.id %>" <%=v.id==av.role?"selected='selected'":"" %>><%=v.RoleName %></option>
                        <%} %>
					</select><span class="error"></span>
				</td>
			</tr>
			
			<tr><td></td><td><span class="btn btn_primary"><input type="submit" name="send" value="提交" /></span> <span class="btn btn_default"><a href="default.aspx">取消</a></span><span class="manager"><%=Request["message"] %></span></td></tr>
		</table>
		</form>
	</div>
	<script src="http://libs.baidu.com/jquery/1.9.0/jquery.js"></script>
	<script src="../js/manager.js"></script>
</body>
</html>