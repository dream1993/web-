<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="add.aspx.cs" Inherits="Web.domainName.add" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <!-- IE -->
    <meta name="renderer" content="webkit" />
    <!-- 360 -->
    <meta name="format-detection" content="telephone=no" />
    <meta name="viewport" content="initial-scale=1.0,user-scalable=no,maximum-scale=1,width=device-width" />
    <meta name="format-detection" content="telephone=no" />
    <meta name="applicable-device" content="mobile" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <meta name="apple-mobile-web-app-status-bar-style" content="black" />
    <title>域名添加-易创网联</title>
    <link href="../css/style.reset.css" rel="stylesheet" />
    <link href="css/style.css" rel="stylesheet" />
</head>
<body>
    <div class="w">
        <form id="domainform">
        <table class="table domainAdd">
            <tr>
                <td colspan="2" class="center">公司信息</td>
            </tr>
            <tr>
                <th>公司名称：</th>
                <td><input type="text" name="company" id="company" required="required" /></td>
            </tr>
            <tr>
                <th>联系人：</th>
                <td> <input type="text" name="contactName" id="contactName" required="required"/></td>
            </tr>
            <tr>
                <th>电话：</th>
                <td>
                    <input type="text" name="phone" id="phone" required="required"/></td>
            </tr>
            <tr>
                <th>邮件：</th>
                <td>
                    <input type="text" name="email" id="email" required="required"/></td>
            </tr>
            <tr>
                <td colspan="2" class="center">域名空间</td>
            </tr>
            <tr>
                <th>域名：</th>
                <td>
                    <input type="text" id="domainName" name="domainName" required="required"/></td>
            </tr>
            <tr>
                <th>是否我司购买</th>
                <td>
                    <input type="radio" name="isUsDomain" checked="checked" value="true" />
                    是
                    <input type="radio" name="isUsDomain" value="false" />
                    否
                </td>
            </tr>
            <tr>
                <th>到期日期：</th>
                <td>
                    <input type="text" id="domainTime" name="domainTime" onclick="laydate()" value="<%=DateTime.Now.ToString("yyyy-MM-dd") %>"/></td>
            </tr>
            <tr>
                <th>备注：</th>
                <td>
                    <textarea id="domainRemarks" name="domainRemarks" placeholder="域名购买地址，服务商等信息"></textarea></td>
            </tr>
            <tr>
                <th>ftp信息：</th>
                <td>
                    <textarea id="ftp" name="ftp" placeholder="ftp连接地址，账号密码"></textarea>
                </td>
            </tr>
             <tr>
                <th>是否我司购买</th>
                <td>
                    <input type="radio" name="isUsFtp" checked="checked" value="true" />
                    是
                    <input type="radio" name="isUsFtp" value="false" />
                    否
                </td>
            </tr>
            <tr>
                <th>到期日期：</th>
                <td>
                    <input type="text" id="ftpTime" name="ftpTime" onclick="laydate()" value="<%=DateTime.Now.ToString("yyyy-MM-dd") %>"/></td>
            </tr>
            <tr>
                <th>数据库信息：</th>
                <td>
                    <textarea id="server" name="server" placeholder="数据库连接地址，账号密码"></textarea>
                </td>
            </tr>
             <tr>
                <th>是否我司购买</th>
                <td>
                    <input type="radio" name="isUsServer" checked="checked" value="true" />
                    是
                    <input type="radio" name="isUsServer" value="false" />
                    否
                </td>
            </tr>
            <tr>
                <th>到期日期：</th>
                <td>
                    <input type="text" id="serverTime" name="serverTime" onclick="laydate()" value="<%=DateTime.Now.ToString("yyyy-MM-dd") %>"/></td>
            </tr>
            <tr>
                <th>备注信息：</th>
                <td>
                    <textarea id="remarks" name="remarks" placeholder="如以上信息不够，请再次备注说明"></textarea>
                </td>
            </tr>
            <tr>
                <td class="center" colspan="2"><a href="javascript:void(0)" id="btnOK" class="btnok">提交</a></td>
            </tr>
        </table></form>
    </div>
    <script src="../js/jquery-1.9.1.min.js"></script>
    <script src="js/laydate/laydate.js"></script>
    <script>
        $("#btnOK").click(function () {
            if ($("#company").val() == "") {
                alert("请输入公司名称")
                return false;
            }
            if ($("#contactName").val() == "") {
                alert("请输入联系人姓名")
                return false;
            }
            if ($("#phone").val() == "") {
                alert("请输入联系人手机号码")
                return false;
            }
            if ($("#email").val() == "") {
                alert("请输入联系人邮箱")
                return false;
            }
            if ($("#domainName").val() == "") {
                alert("请输入域名")
                return false;
            }
            $("#btnOK").html("提交中...")
            $.post("ajax/domainEdit.ashx", $("#domainform").serialize(), function (data) {
                if (data == "0") {
                    alert("提交成功")
                    clearIpnut()
                } else {
                    alert(data)
                }
                $("#btnOK").html("提交")
            })
        })
        function clearIpnut() {
            $("input[type=text]").val("")
            $("textarea").val("")
        }
    </script>
</body>
</html>
