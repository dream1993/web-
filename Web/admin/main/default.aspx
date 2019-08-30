<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Web.admin.main._default" %>

<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8" />
    <title>易创网联网站管理系统</title>
    <link rel="stylesheet" href="../css/global.css">
    <link rel="stylesheet" href="../css/index.css">
</head>
<body>
    <!-- 后台首页顶部 -->
    <div id="head">
        <h1><a href="/admin/main"><img src="../images/logo.png" /><span>网站管理系统</span><div class="clear"></div></a></h1>
        <ul class="nav">
            <li class="active"><a href="../web" target="iframe">网站信息</a></li>
             <li ><a href="../web/desc/?pid=29" target="iframe">首页</a></li>
            <li ><a href="../web/pro/?pid=2" target="iframe">案例</a></li>
           <%-- <li ><a href="../web/pic/?pid=3" target="iframe">服务</a></li>--%>
            <li ><a href="../web/product/?pid=4" target="iframe">新闻</a></li>
            <li ><a href="../web/desc/?pid=5" target="iframe">关于</a></li>
            <li ><a href="../web/message" target="iframe">联系</a></li>
        <%--<li ><a href="../manager/uppwd.aspx" target="iframe">联系</a></li>--%>
            <li ><a href="../manager/uppwd.aspx" target="iframe">系统设置</a></li>
        </ul>
        <ul class="subnav">
            <li>易创网联管理员,您好!</li>
            <li><a href="/" target="_blank">前台首页</a></li>
            <li><a href="?loginout=quit">退出</a></li>
        </ul>
    </div>

    <div id="main">
        <div id="main2">
            <div id="left">
                <dl class="menu">
                    <dt><i></i>官网信息</dt>
                    <dd class="on"><a href="../web" target="iframe">官网信息</a></dd>
                 
                    <dd ><a href="../type/" target="iframe">类别管理</a></dd>
                </dl>
                  <dl class="menu">
                    <dt><i></i>首页</dt>
                    <dd class="on"><a href="../web/desc/?pid=29" target="iframe">服务</a></dd>
                 
                    <dd ><a href="../web/icase/?pid=30" target="iframe">案例</a></dd>
                       <dd ><a href="../web/icase/?pid=31" target="iframe">手机案例</a></dd>
                </dl>
                  <dl class="menu">
                    <dt><i></i>案列</dt>
                    <dd class="on"><a href="../web/pro/?pid=2" target="iframe">案列管理</a></dd>
                    <dd ><a href="../web/pro/add.aspx?pid=2" target="iframe">添加案列</a></dd>
                      <dd ><a href="../type/?pid=2" target="iframe">类别管理</a></dd>
                </dl>
             <%--      <dl class="menu">
                    <dt><i></i>服务</dt>
                    <dd class="on"><a href="../web/pic/?pid=3" target="iframe">产品管理</a></dd>
                    <dd ><a href="../web/pic/add.aspx?pid=3" target="iframe">添加产品</a></dd>
                </dl>--%>
                 <dl class="menu">
                    <dt><i></i>新闻</dt>
                     <dd class="on"><a href="../web/product/?pid=4" target="iframe">新闻管理</a></dd>
                     <dd ><a href="../web/product/add.aspx?pid=4" target="iframe">添加新闻</a></dd>
                     <dd ><a href="../type/?pid=4" target="iframe">类别管理</a></dd>
                </dl>
                 <dl class="menu">
                    <dt><i></i>关于</dt>
              <dd class="on"><a href="../web/desc/?pid=5" target="iframe">关于管理</a></dd>
                     <dd ><a href="../web/desc/add.aspx?pid=5" target="iframe">添加关于</a></dd>
                      <dd ><a href="../web/pic/?pid=32" target="iframe">合作客户</a></dd>
                     <dd ><a href="../web/desc/?pid=33" target="iframe">团队</a></dd>
                      </dl>
                 <dl class="menu">
                    <dt><i></i>联系</dt>
                  <dd class="on"><a href="../web/message" target="iframe">联系我们</a></dd>
            </dl>
                 <dl class="menu">
                    <dt><i></i>系统设置</dt>
                    <dd class="on"><a href="../manager/uppwd.aspx" target="iframe">修改密码</a></dd>
                    <dd><a href="../web/demo.aspx" target="iframe">生成静态页</a></dd>
                </dl>
            </div>
            <iframe id="iframe" src="../web/" name="iframe" frameborder="0"></iframe>
        </div>
    </div>
    <script src="http://libs.baidu.com/jquery/1.8.0/jquery.js"></script>
    <script type="text/javascript" src="../js/index.js"></script>
</body>
</html>
