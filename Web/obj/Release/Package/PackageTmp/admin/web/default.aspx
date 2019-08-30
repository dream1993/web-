<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Web.admin.web._default" %>


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
                <li><a href="index.php?c=level" target="iframe">官网信息管理</a></li>
            </ul>
            
        </div>
        <!-- 正文 -->
   
            <table class="table web" cellpadding="1" cellspacing="1">

                <tr>
                    <th>网站标题：
                    </th>
                    <td>
                        <input type="text" class="form-control" id="title" runat="server" maxlength="255" />
                    </td>
                </tr>
                <tr>
                    <th>网站描述：
                    </th>
                    <td>
                        <input type="text" class="form-control" id="description" runat="server" maxlength="255" />
                    </td>
                </tr>
                <tr>
                    <th>网站关键字：
                    </th>
                    <td>
                        <input type="text" class="form-control" id="keywords" runat="server" maxlength="255" />
                    </td>
                </tr>
                <tr>
                    <th>网站网址：
                    </th>
                    <td>
                        <input type="text" class="form-control" id="weburl" runat="server" maxlength="255" />
                    </td>
                </tr>
                <tr>
                    <th>联系电话一：
                    </th>
                    <td>
                        <input type="text" class="form-control" id="tel" runat="server" maxlength="255" />
                    </td>
                </tr>
                <tr>
                    <th>联系电话二：
                    </th>
                    <td>
                        <input type="text" class="form-control" id="tel1" runat="server" maxlength="255" />
                    </td>
                </tr>
        
                <tr>
                    <th>传真：
                    </th>
                    <td>
                        <input type="text" class="form-control" id="fax" runat="server" maxlength="255" />
                    </td>
                </tr>
              
                <tr>
                    <th>邮箱：
                    </th>
                    <td>
                        <input type="text" class="form-control" id="mail" runat="server" maxlength="255" />
                    </td>
                </tr>
                <tr>
                    <th>联系QQ：
                    </th>
                    <td>
                        <input type="text" class="form-control" id="QQ1" runat="server" />
                    </td>
                </tr>
                       <tr >
                    <th>QQ2：
                    </th>
                    <td>
                        <input type="text" class="form-control" id="QQ2" runat="server" />
                    </td>
                </tr>
                  <tr>
                    <th>联系地址：
                    </th>
                    <td>
                        <input type="text" class="form-control" id="address" runat="server" maxlength="255" />
                    </td>
                </tr>
                <tr>
                    <th>版权信息：
                    </th>
                    <td>

                        <script id="content" type="text/plain" style="width: 100%; height: 300px;"><%=copyright %></script>
                    </td>
                </tr>
                <tr>
                    <th width="120">统计代码：</th>
                    <td>
                        <textarea id="code" class="form-control" runat="server"></textarea>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div id="loading">
                        </div>
                    </td>
                    <td>
                        <button id="go" class="btn btn-info">
                            完成确认</button>
                        <div class="fright"></div>
                    </td>
                </tr>
            </table>
  
    </div>
    <script src="../../js/jquery-1.9.1.min.js"></script>
    <script src="../../ueditor/ueditor.config.js"></script>
    <script src="../../ueditor/ueditor.all.min.js"></script>
   
    <script type="text/javascript" charset="utf-8" src="../../ueditor/lang/zh-cn/zh-cn.js"></script>
    <script src="js/website.js"></script>
</body>
</html>
