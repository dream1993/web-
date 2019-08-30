<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="update.aspx.cs" Inherits="Web.admin.web.desc.update" %>


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
                <li><a href="default.aspx?id=<%=av.typeId %>" target="iframe"><%=title %>管理</a></li>
                <li>修改<%=title %></li>
            </ul>
            <span>
                <a href="default.aspx?id=<%=av.typeId %>" target="iframe">返回</a>
            </span>
        </div>
        <!-- 正文 -->
        <form name="managerForm" action="../ajax/acticle.ashx?id=<%=av.id %>" method="post">
            <table class="table web" cellpadding="1" cellspacing="1">
                <%if(list.Count>0){ %>
                <tr>
                    <th>所属分类</th>
                    <td>
                        <select name="typeId">
                            <%foreach(DAL.typeData.Value tv in list){
                                   %>
                            <option value="<%=tv.id %>" <%=tv.id==av.typeId?"selected='selected'":"" %>><%=tv.title %></option>
                            <%} %>
                        </select>
                    </td>
                </tr>
                <%}else{ %>
                <input type="hidden" name="typeId" value="<%=pid %>">
                <%} %>
                <tr>
                    <th>标题</th>
                    <td>
                        <input type="text" name="title" value="<%=av.title %>" /></td>
                </tr>
                 <tr>
                    <th>副标题</th>
                    <td>
                        <input type="text" name="realTitle" value="<%=av.realTitle %>" /></td>
                </tr>
                   <tr>
                    <th>描述</th>
                    <td>
                  <textarea name="description" style="width:100%;height:100px;"><%=av.description %></textarea>
                        
                    </td>
                </tr>
                <tr>
                    <th>上传图片</th>
                    <td>
                        <a href="javascript:void(0);" id="uploadpic"><img src="<%=av.imgSrc %>" id="img1" /></a>
                   <input type="hidden" name="imgSrc" id="imgSrc1" value="<%=av.imgSrc %>" />
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td><span class="btn btn_primary">
                        <input type="hidden" name="returnurl" value="../desc/update.aspx?pid=<%=pid %>" />
                        <input type="submit" name="send" value="确认修改" /></span><span class="message"> <%=Request["message"] %></span></td>
                </tr>
            </table>
        </form>
    </div>
   <script src="../../../js/jquery-1.8.3.min.js"></script>
    <script src="../../../ueditor/ueditor.config.js"></script>
    <script src="../../../ueditor/ueditor.all.min.js"></script>
    <script id="imgup1" style="display:none"></script>
    <script type="text/javascript" charset="utf-8" src="../../../ueditor/lang/zh-cn/zh-cn.js"></script>
    <script src="../js/website.js"></script>
     <script src="../../js/essaypublic.js"></script>
</body>
</html>
