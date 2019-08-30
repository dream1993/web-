<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Web.admin.web.allAgent._default" %>


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
				<li><a href="default.aspx" target="iframe">全国代理管理</a></li>
				<li>代理列表</li>
			</ul>
			<span>
				<a href="add.aspx"  target="iframe">新增代理</a>
			</span>
		</div>
		<!-- 正文 -->
        <span class="maessage"><%=Request["message"] %></span>
		<table class="table" cellpadding="1" cellspacing="1">
			<tr>
			
				<th>姓名</th>
				<th>电话</th>
                <th>省份</th>
				<th>市</th>
				<th>操作</th>
			</tr>
			<%foreach (DAL.articleData.Value rv in list)
     { %>
			<tr>
				<td><%=rv.title %></td>
				<td><%=rv.keyword %></td>
                <td><%=rv.description %></td>
				<td><%=rv.realTitle %></td>
				<td><a href="update.aspx?id=<%=rv.id %>" target="iframe">编辑</a> | <a href="javaScript:void(0);" class="del" alt="../ajax/acticle.ashx?delid=<%=rv.id %>" >删除</a></td>
			</tr>	
            <%}if(list.Count<=0){  %>
			
			<tr><td colspan="7">没有任何数据!</td></tr>
			<%} %>
		</table>
		<%--<div id="page">{$page}</div>--%>
	</div>
	<script src="http://libs.baidu.com/jquery/1.9.0/jquery.js"></script>
	<script src="../../js/modal.js"></script>