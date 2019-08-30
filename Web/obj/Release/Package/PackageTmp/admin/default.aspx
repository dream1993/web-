<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Web.admin._default" %>

<!DOCTYPE html>
<html lang="en" class="no-js">

    <head>

        <meta charset="utf-8">
        <title>欢迎登录网站管理系统</title>
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
        <meta name="description" content="">
        <meta name="author" content="">

        <!-- CSS -->
        <link rel="stylesheet" href="style/reset.css">
        <link rel="stylesheet" href="style/supersized.css">
        <link rel="stylesheet" href="style/style.css">

        <!-- HTML5 shim, for IE6-8 support of HTML5 elements -->
        <!--[if lt IE 9]>
            <script src="http://html5shim.googlecode.com/svn/trunk/html5.js"></script>
        <![endif]-->

    </head>

    <body oncontextmenu="return false">
        <img src="img/logo.png" class="ilogo" />
        <div class="page-container">
            <h1>欢迎登录网站管理系统</h1>
            <form action="" method="post">
				<div>
					<input type="text" name="username" class="username" placeholder="用户名" autocomplete="off"/>
				</div>
                <div>
					<input type="password" name="password" class="password" placeholder="密码" oncontextmenu="return false" <%--onpaste="return false" --%>/>
                </div>
                
                <button id="submit" type="button">登 录</button>
            </form>
            <div class="connect">
                <p>In the future, we will be grateful for our own！</p>
				<p style="margin-top:20px;">将来的我们，一定会感激现在拼命的自己！</p>
            </div>
        </div>
		<div class="alert" style="display:none">
			<h2>消息</h2>
			<div class="alert_con">
				<p id="ts"></p>
				<p style="line-height:70px"><a class="btn">确定</a></p>
			</div>
		</div>
        <!-- Javascript -->
		<script src="http://apps.bdimg.com/libs/jquery/1.6.4/jquery.min.js" type="text/javascript"></script>
        <script src="js/supersized.3.2.7.min.js"></script>
        <script src="js/supersized-init.js"></script>
        <script src="js/login.js"></script>

    </body>

</html>