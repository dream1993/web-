﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="update.aspx.cs" Inherits="Web.admin.web.allAgent.update" %>

<!DOCTYPE html>
<html lang="en">
<head>
	<meta charset="UTF-8">
	<link rel="stylesheet" href="../../css/global.css">
	<link rel="stylesheet" type="text/css" href="../../css/main.css">
	<link rel="stylesheet" type="text/css" href="../../css/level.css">
</head>
<body id="iframe-body">
	<div class="main">
		<!-- 位置导航 -->
		<div class="address">
			<ul>
				<li><a href="default.aspx" target="iframe">全国代理管理</a></li>
				<li>新增全国代理信息</li>
			</ul>
			<span>
				<a href="default.aspx"  target="iframe">返回</a>
			</span>
		</div>
		<!-- 正文 -->
		<form name="managerForm" action="../ajax/acticle.ashx?typeId=3&id=<%=av.id %>" method="post">
		<table class="table level" cellpadding="1" cellspacing="1">
			<tr>
				<th>姓名</th>
				<td><input type="text" name="title" value ="<%=av.title %>" /></td>
			</tr>
            <tr>
				<th>电话</th>
				<td><input type="text" name="keyword" value="<%=av.keyword %>" /></td>
			</tr>
			<tr>
				<th>省份</th>
				<td>
					<input  type="text" name="description" value="<%=av.description %>"/>
				</td>
			</tr>
            <tr>
				<th>市</th>
				<td>
					<input  type="text" name="realTitle" value="<%=av.realTitle %>"/>
				</td>
			</tr>
			<tr><td></td><td><span class="btn btn_primary"><input type="submit" name="send" value="确认修改" /></span><span class="message"> <%=Request["message"] %></span></td></tr>
		</table>
		</form>
	</div>
</body>
</html>