<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Web.admin.web.news._default" %>


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
                <li><a href="default.aspx?pid=<%=pid %>" target="iframe"><%=title %>管理</a></li>
                <li><%=title %>列表</li>
            </ul>
            <span>
                <a href="add.aspx?pid=<%=pid %>" target="iframe">新增<%=title %></a>
            </span>
        </div>
        <div style="margin-bottom:15px;">
            <form name="from" method="get" action="default.aspx?pid=<%=pid %>">
            <%if(tlist.Count>0){ %>
               <select name="tid">
                   <option value="<%=pid %>">请选择分类</option>
                            <%foreach(DAL.typeData.Value tv in tlist){
                                   %>
                            <option value="<%=tv.id %>" <%=tv.id==tid?"selected='selected'":"" %>><%=tv.title %></option>
                            <%} %>
                        </select>
            <%} %>
            <input type="text" name="title" placeholder="请输入标题关键字" value="<%=Request["title"] %>" />
            <input type="submit" value="查询" /></form>
        </div>
        <!-- 正文 -->
        <span class="maessage"><%=Request["message"] %></span>
        <table class="table" cellpadding="1" cellspacing="1">
            <tr>

                <th>标题</th>
                <th>所属分类</th>
                <th>置顶</th>
                <th>排序</th>
                <th>操作</th>
            </tr>
            <%foreach (DAL.articleData.Value rv in list)
              { %>
            <tr>
                <td><%=rv.title %></td>
                <td><%=DAL.typeData.row(rv.typeId).title %></td>
                <td>
                    <a href="../ajax/artzd.ashx?id=<%=rv.id %>&fine=<%=rv.fine %>">
                    <img alt="置顶"  src="../../img/fine/<%=rv.fine %>.png"  />
</a>
                </td>
                 <td >
                         <input name="sort" id='<%=rv.id %>' value="<%=rv.sort %>" val="<%=rv.sort %>" size="5" maxlength="5" onkeyup="this.value=this.value.replace(/\D/g,'')" onclick="this.value = ''" onblur="sort(this)" style="padding: 0px 5px; margin: 0px;" />
                        </td>
                <td><a href="update.aspx?id=<%=rv.id %>&pid=<%=pid %>" target="iframe">编辑</a> | <a href="javaScript:void(0);" class="del" alt="../ajax/acticle.ashx?delid=<%=rv.id %>&cc=<%=pid %>&returnurl=../news">删除</a></td>
            </tr>
            <%} if (list.Count <= 0)
              {  %>
            <tr>
                <td colspan="7">没有任何数据!</td>
            </tr>
            <%} %>
        </table>
         <%if(list.Count>0){  %>
		<%=CL.Common.page1(Request.Url.ToString(),count,page,data) %>
        <%} %>
        <%--<div id="page">{$page}</div>--%>
    </div>
    <script src="http://libs.baidu.com/jquery/1.9.0/jquery.js"></script>

    <script src="../../js/modal.js"></script>
    <script>

        var sort = function (sort) {
            if (sort.value != "") {
                if (sort.value != sort.getAttribute("val")) {
                    $.post("../ajax/artzd.ashx", { id: sort.getAttribute("id"), sort: sort.value }, function (data) {
                        window.location.href = "default.aspx?id=1";
                    });
                }
            }
            else {
                sort.value = sort.getAttribute("val");
            }
        }
    </script>
    </body></html>