/// <reference path="jquery-1.9.1.min.js" />
var flag = true;
var html = '<div class="message_ts" style="z-index:999;position:fixed;top:50%;left:50%;width:300px;height:130px;border:1px solid #ccc;background:#fff;margin-left:-150px;margin-top:-65px;"><div style="height:93px;line-height:25px;padding:0 10px;text-align:center;"><img src="/img/logo.png" style="width:48px;margin-top:13px;"/><br/>';
var html1 = '</div><p style="margin:0;text-align:right;padding:5px 10px;border-top:1px solid #ccc"><a onclick="btnclose(this)" href="javascript:void(0)" id="btnclose" style="display:inline-block;color:#aaa;width:60px;height:25px;text-align:center;line-height:25px;border:1px solid #ccc;">确 定</a></p></div>';
var leftSeconds = 3;//倒计时时间10秒  
var intervalId;
$(document).ready(function () {
    $("#btnok").click(function () {

        var myreg = /^([a-zA-Z0-9]+[_|\_|\.]?)*[a-zA-Z0-9]+@([a-zA-Z0-9]+[_|\_|\.]?)*[a-zA-Z0-9]+\.[a-zA-Z]{2,3}$/;
        var mobile = /^1[3|4|5|7|8][0-9]\d{8}$/;
        if ($("#name").val() == "") {
            $("#ts").html("请输入您的姓名！");
            ints()
            return false;
        }
        if ($("#phone").val() == "") {
            $("#ts").html("请输入您的手机号码！");
            ints()
            return false;
        }
        if (!mobile.test($("#phone").val())) {
            $("#ts").html("您的手机号码格式不正确！");
            ints()
            return false;
        }
        if ($("#qq").val() == "") {
            $("#ts").html("请输入您的QQ！");
            ints()
            return false;
        }
        if ($("#email").val() == "") {
            $("#ts").html("请输入您的邮箱！");
            ints()
            return false;
        }
        if (!myreg.test($("#email").val())) {
            $("#ts").html("您的邮箱格式不正确！");
            ints()
            return false;
        }
        if ($("#contents").val() == "") {
            $("#ts").html("请输入您的需求！");
            ints()
            return false;
        }
        if (flag == false) {
            return false;
        }
        flag = false;

        $.post("/ajax/message.ashx", $("#form").serialize(), function (data) {
            if (data == "0") {
                $("body").append(html + '感谢您的咨询！我们会尽快与您联系。' + html1)
flag = true;
            } else {
                $("body").append(html + '提交失败，您也可以通过右侧的QQ与我们在线交谈！' + html1)
                flag = true;
            }
            ints()
        })

    })
  
})

//$("#btnclose").live("click", function () {
//    $(this).parent().parent().remove();
//})
function btnclose(obj) {

    $(".message_ts").remove();
    $("#form input").val("")
    $("#contents").val("")
    $("#ts").html("");
}


function ints() {
    intervalId = setInterval("CountDown()", 1000);//调用倒计时的方法  
};
function CountDown() {//倒计时方法  

    if (leftSeconds <= 0) {
        $("#ts").html("");
        clearInterval(intervalId); //取消由 setInterval() 设置的 timeout  
        leftSeconds = 3;
        return;
    }
    leftSeconds--;
    
}