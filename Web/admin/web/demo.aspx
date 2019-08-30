<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="demo.aspx.cs" Inherits="Web.admin.web.demo" %>

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
        <div class="main-white">
            <%--<input type="button" class="btn btn-info" value="生成首页" id="index" />--%>
            <%--<input type="button" class="btn btn-info" value="生成手机首页" id="wap" />--%>
            <%--<input type="button" class="btn btn-info" value="生成关于" id="about" />--%>
            <input type="button" class="btn btn-info" value="生成案例" id="case" />
            <input type="button" class="btn btn-info" value="生成案例详情" id="case_show" />
            <input type="button" class="btn btn-info" value="生成新闻" id="news" />
            <input type="button" class="btn btn-info" value="生成新闻详情" id="news_show" />
            <%--<input type="button" class="btn btn-info" value="生成服务" id="serve" />--%>
            <%--<input type="button" class="btn btn-info" value="生成联系" id="contact" />--%>
            <%--<input type="button" class="btn btn-info" value="生成VR" id="VR" />--%>
            <input type="button" class="btn btn-info" value="全部生成" id="All" />
            <span id="data"></span>
            <img src="/admin/img/loading.gif" style="display: none" id="load" />
        </div>
    </div>
    <script src="../../js/jquery-1.9.1.min.js"></script>
    <script>
        $("#All").click(function () {

            $("#load").css("display", "block")
            //$.post("/ajax/contact.ashx", {}, function (data) { })
            //$.post("/ajax/wap.ashx", {}, function (data) { })
            //$.post("/ajax/about.ashx", {}, function (data) { })
            $.post("/ajax/case.ashx", {}, function (data) { })
            $.post("/ajax/case_show.ashx", {}, function (data) { })
            //$.post("/ajax/index.ashx", {}, function (data) { })
            $.post("/ajax/news.ashx", {}, function (data) { })
            $.post("/ajax/news_show.ashx", {}, function (data) { })
            //$.post("/ajax/serve.ashx", {}, function (data) { })
            //$.post("/ajax/VR.ashx", {}, function (data) { })
            $("#load").css("display", "none")
            $("#data").html("生成成功")
        })

        $("#contact").click(function () {
            $("#load").css("display", "block")

            $.post("/ajax/contact.ashx", {}, function (data) {
               
                $("#data").html(data)
                $("#load").css("display", "none")
            })

        })
        $("#contact").click(function () {
            $("#load").css("display", "block")

            $.post("/ajax/VR.ashx", {}, function (data) {

                $("#data").html(data)
                $("#load").css("display", "none")
            })

        })
        $("#wap").click(function () {
            $("#load").css("display", "block")

            $.post("/ajax/wap.ashx", {}, function (data) {

                $("#data").html(data)
                $("#load").css("display", "none")
            })

        })
        $("#serve").click(function () {
            $("#load").css("display", "block")

            $.post("/ajax/serve.ashx", {}, function (data) {
               $("#data").html(data)
                $("#load").css("display", "none")
            })

        })
        $("#news_show").click(function () {
            $("#load").css("display", "block")

            $.post("/ajax/news_show.ashx", {}, function (data) {
               $("#data").html(data)
                $("#load").css("display", "none")
            })

        })
        $("#news").click(function () {
            $("#load").css("display", "block")

            $.post("/ajax/news.ashx", {}, function (data) {
               $("#data").html(data)
                $("#load").css("display", "none")
            })

        })
        $("#index").click(function () {
            $("#load").css("display", "block")

            $.post("/ajax/index.ashx", {}, function (data) {
               $("#data").html(data)
                $("#load").css("display", "none")
            })

        })
        $("#about").click(function () {
            $("#load").css("display", "block")

            $.post("/ajax/about.ashx", {}, function (data) {
               $("#data").html(data)
                $("#load").css("display", "none")
            })

        })
        
        $("#case").click(function () {
            $("#load").css("display", "block")

            $.post("/ajax/case.ashx", {}, function (data) {
               $("#data").html(data)
                $("#load").css("display", "none")
            })

        })
        $("#case_show").click(function () {
            $("#load").css("display", "block")

            $.post("/ajax/case_show.ashx", {}, function (data) {
               $("#data").html(data)
                $("#load").css("display", "none")
            })

        })
    </script>
    
  
</body>
</html>
