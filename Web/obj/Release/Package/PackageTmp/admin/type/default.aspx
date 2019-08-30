<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Web.admin.type._default" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <link rel="stylesheet" href="../css/global.css">
    <link rel="stylesheet" href="../css/nav.css">
    <link rel="stylesheet" type="text/css" href="../css/pagination.css">
</head>
<body id="iframe-body">
    <div class="main">
        <!-- 位置导航 -->
        <div class="address">
            <ul>
                <li><a href="default.aspx?pid=<%=pid %>" target="iframe">类别管理</a></li>
                <li>类别列表</li>
            </ul>
            <span>
                <a href="add.aspx?pid=<%=pid %>" target="iframe">新增</a>
            </span>
        </div>
        <!-- 正文 -->
        <form method="post">
            <!-- 导航 -->
            <dl class="nav">
                <dt>
                    <div class="dttitle tableL">类别管理 | <a id="slideAll" flag="0" href="javascript:void(0);">展开全部</a></div>
                    <span class="tableR">操作</span>
                </dt>
                <%foreach (DAL.typeData.Value v in BLL.type.list(pid))
                  { %>

                <!--顶级栏目-->
                <dd>
                    <div class="topNav">
                        <a class="tableL textC w2" href="#"><i class="topBtn" value="false"></i></a>
                        <div class="content w98 tableR">
                            <span class="name tableL w50"><%=v.title %></span>
                            <div class="tableL textL w50">
                                <a href="add.aspx?pid=<%=v.id %>" target="iframe">添加二级栏目</a> | 
							
                                <%--<a class="del" alt="<%=v.NodeId %>" href="javascript:void(0);">删除</a>--%> 
							
                                <a href="update.aspx?id=<%=v.id %>" target="iframe">修改</a> | 
							
                                
                            </div>
                        </div>
                    </div>
                    <dl>
                         <%foreach (DAL.typeData.Value cv in BLL.type.list(v.id))
                          { %>

                        <!--二级栏目-->
                        <dd>
                            <span class="tableL textC w2"><i class="subBtn"></i></span>
                            <div class="content w98 tableR">
                                <span class="name tableL w50"><%=cv.title %></span>
                                <div class="tableL textL w50">
                                    <%--<a class="del" alt="../sysfun/sysfun.ashx?delid=<%=cv.NodeId %>" href="javascript:void(0);">删除</a> |--%> 
								
                                     
							
                                <a href="update.aspx?id=<%=cv.id %>" target="iframe">修改</a> | 
							
                               
                                </div>
                            </div>
                        </dd>
                        <%} %>
                    </dl>
                </dd>
                <%} %>
            </dl>
        </form>
        <%--<div id="page">{$page}</div>--%>
    </div>
    <script src="http://libs.baidu.com/jquery/1.9.0/jquery.js"></script>
    <script src="../js/nav.js"></script>
    <script src="../js/modal.js"></script>
</body>
</html>
