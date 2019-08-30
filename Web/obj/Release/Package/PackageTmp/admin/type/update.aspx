<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="update.aspx.cs" Inherits="Web.admin.type.update" %>

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
				<li><a href="default.aspx?pid=<%=v.parentId%>" target="iframe">类别管理</a></li>
				<li>修改类别</li>
			</ul>
			<span>
				<a href="default.aspx?pid=<%=v.parentId %>"  target="iframe">返回</a>
			</span>
		</div>
		<!-- 正文 -->
		<form name="levelForm" action="type.ashx?id=<%=v.id %>&act=update" method="post">
		<table class="table level" cellpadding="1" cellspacing="1">
	   <tr>
				<th>所属父类</th>
				<td align="left">
                    <%=v.parentId==0?"顶级菜单":DAL.SysFunData.row(v.parentId).DisplayName %>
				</td>
			</tr>
			<tr>
				<th>类别名称</th>
				<td align="left"><input type="text" name="title" value="<%=v.title %>" /></td>
			</tr>
               <tr>
				<th>上传图片</th>
				<td align="left">
                    <a href="javascript:void(0);" id="upload" style="display:block;float:left;margin-right:10px;"><img src="<%=v.imgSrc %>" id="img" /></a>
                   <input type="hidden" name="imgSrc" id="imgSrc" value="<%=v.imgSrc %>" />

                    
                    <a href="javascript:void(0);" id="uploadpic" style="display:block;float:left;margin-right:10px;"><img src="<%=v.img %>" id="img1" /></a>
          
                    <input type="hidden" name="imgSrc1" id="imgSrc1" />
				</td>
			</tr>
		  <tr>
				<th>是否显示</th>
				<td align="left">
                    <input type="radio" name="view" value="true" <%=v.view?"checked='checked'":"" %> /> 是
                    <input type="radio" name="view" value="false" <%=!v.view?"checked='checked'":"" %>  /> 否
				</td>
			</tr>
			<tr><td></td><td  align="left"><span class="btn btn_primary"><input type="submit" name="send" value="修改类别" /></span>
              <span class="message">  <%=Request["message"] %></span></td>
                </tr>
		</table>
		</form>
	</div>
       <script src="../../js/jquery-1.8.3.min.js"></script>
    <script id="imgup" style="display:none"></script>
        <script id="imgup1" style="display:none"></script>
    <script src="../../ueditor/ueditor.config.js"></script>
    <script src="../../ueditor/ueditor.all.js"></script>
    <script src="../../ueditor/lang/zh-cn/zh-cn.js"></script>
    <script src="../js/essaypublic.js"></script>
</body>
</html>