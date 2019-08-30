<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="add.aspx.cs" Inherits="Web.admin.web.desc.add" %>

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
                <li><a href="default.aspx?pid=<%=pid %>" target="iframe"><%=title %>管理</a></li>
                <li>新增<%=title %></li>
            </ul>
            <span>
                <a href="default.aspx?pid=<%=pid %>" target="iframe">返回</a>
            </span>
        </div>
        <!-- 正文 -->
        <form name="managerForm" action="../ajax/acticle.ashx" method="post">
            <table class="table web" cellpadding="1" cellspacing="1">
                   <%if(list.Count>0){ %>
                <tr>
                    <th>所属分类</th>
                    <td>
                        <select name="typeId">
                            <%foreach(DAL.typeData.Value tv in list){
                                   %>
                            <option value="<%=tv.id %>" <%=tv.id==pid?"selected='selected'":"" %>><%=tv.title %></option>
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
                        <input type="text" name="title" /></td>
                </tr>
                <tr>
                    <th>副标题</th>
                    <td>
                        <input type="text" name="realTitle" /></td>
                </tr>
               <tr>
                    <th>描述</th>
                    <td>
                  <textarea name="description" style="width:100%;height:100px;"></textarea>
                        
                    </td>
                </tr>
                <tr>
                    <th>上传图片</th>
                    <td>
                        <a href="javascript:void(0);" id="uploadpic">上传图片<img src="" id="img1" /></a>
                   <input type="hidden" name="imgSrc" id="imgSrc1" />
                    </td>
                </tr>
                <tr>
                    <td><input type="hidden" name="returnurl" value="../desc/add.aspx?pid=<%=pid %>" /></td>
                    <td><span class="btn btn_primary">
                        <input type="submit" name="send" value="提交" /></span><span class="message"> <%=Request["message"] %></span></td>
                </tr>
            </table>
        </form>
    </div>
    <script src="../../../js/jquery-1.8.3.min.js"></script>
    <script src="../../../ueditor/ueditor.config.js"></script>
    <script src="../../../ueditor/ueditor.all.min.js"></script>
    <script id="imgup1" style="display:none"></script>
    <script type="text/javascript" charset="utf-8" src="../../../ueditor/lang/zh-cn/zh-cn.js"></script>

     <script src="../../js/essaypublic.js"></script>
</body>
</html>
