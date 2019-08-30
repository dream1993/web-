<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="roleright.aspx.cs" Inherits="Web.admin.management.roleright" %>

<!DOCTYPE html>
<html lang="en">
<head>
	<meta charset="UTF-8">
	<link rel="stylesheet" href="../css/global.css">
	<link rel="stylesheet" type="text/css" href="../css/main.css">
	<link rel="stylesheet" type="text/css" href="../css/level.css">
</head>
<body id="iframe-body">
	<div class="main">
		<!-- 位置导航 -->
		<div class="address">
			<ul>
				<li><a href="index.php?c=level" target="iframe">权限管理</a></li>
				<li>分配权限</li>
			</ul>
			<span>
				<a href="default.aspx"  target="iframe">返回</a>
			</span>
		</div>
		<!-- 正文 -->
		<form name="managerForm" action="level.ashx?roleid=<%=Request["roleid"] %>" method="post">
		<table class="table level" cellpadding="1" cellspacing="1">
            <%foreach(DAL.SysFunData.Value sv in DAL.SysFunData.GetAllListByRoleId(0)){ %>
			<tr>
				<th><input type="checkbox"  name="nodeid" value="<%=sv.NodeId %>" <%=mr.Where(p=>p.NodeId==sv.NodeId).Count()>0?"checked='checked'":"" %> /> <%=sv.DisplayName %></th>
				<td align="left">
                    <%foreach(DAL.SysFunData.Value v in DAL.SysFunData.GetAllListByRoleId(sv.NodeId)){
                          
                           %>
                    <input type="checkbox"  name="nodeid" value="<%=v.NodeId %>" <%=mr.Where(p=>p.NodeId==v.NodeId).Count()>0?"checked='checked'":"" %> /> <%=v.DisplayName %>
                    <%} %>
				</td>
			</tr>
		<%} %>
			<tr><td></td><td><span class="btn btn_primary"><input type="submit" name="send" value="提交" /></span><span class="message"> <%=Request["message"] %></span></td></tr>
           
		</table>
		</form>
	</div>
</body>
</html>