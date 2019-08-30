﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="add.aspx.cs" Inherits="Web.admin.message.add" %>

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
				<li><a href="default.aspx" target="iframe">系统消息管理</a></li>
				<li>新增系统消息</li>
			</ul>
			<span>
				<a href="default.aspx"  target="iframe">返回</a>
			</span>
		</div>
		<!-- 正文 -->
		<form name="managerForm" action="message.ashx?act=add" method="post">
		<table class="table level" cellpadding="1" cellspacing="1">
			<tr>
				<th>标题</th>
				<td align="left"><input type="text" name="title" /></td>
			</tr>
			<tr>
				<th>内容</th>
				<td align="left">
					<textarea name="contents" rows="5" style="width:90%;"></textarea>
				</td>
			</tr>
			<tr><td></td><td><span class="btn btn_primary"><input type="submit" name="send" value="提交" /></span><span class="message"> <%=Request["message"] %></span></td></tr>
           
		</table>
		</form>
	</div>
</body>
</html>