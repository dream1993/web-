$(document).ready(function () {
    var mobile = /^1[3|4|7|5|8][0-9]\d{8}$/
    var myreg = /^([a-zA-Z0-9]+[_|\_|\.]?)*[a-zA-Z0-9]+@([a-zA-Z0-9]+[_|\_|\.]?)*[a-zA-Z0-9]+\.[a-zA-Z]{2,3}$/
    $("#send").click(function () {
        if ($("#userid").val() == '') {
            alert('用户名不得为空!'); return false;
        } else if ($("#userid").val().length < 2 || $("#userid").val().length > 20) {
            alert('用户名长度在2-20位之间!'); return false;
        } else if (!/^[\u4e00-\u9fa5a-z_0-9]+$/.test($("#userid").val())) {
            alert('用户名必须为数字,中文,英文(小写),中横线,下划线!'); return false;
        }
        
        if ($('input[name=userName]').val() == '') {
            alert('请输入真实姓名!');
            return false;
        }
        if ($('input[name=passWord]').val() == '') {
            alert('密码不得为空!');
            return false;
        } else if ($('input[name=passWord]').val().length < 6) {
            alert('密码长度不得小于6位!');
            return false;
        }
        if ($('input[name=repwd]').val() != $('input[name=passWord]').val()) {
            alert('两次密码输入不一致!');
            return false;
        }
        if ($('input[name=phone]').val() == '') {
            alert('手机号码不能为空!');
            return false;
        } else if (!mobile.test($('input[name=phone]').val())) {
            alert('手机号码格式不正确!');
            return false;
        }
        if ($('input[name=mail]').val() == '') {
            alert('邮箱不能为空!');
            return false;
        } else if (!myreg.test($('input[name=mail]').val())) {
            alert('邮箱格式不正确!');
            return false;
        }
        if ($('input[name=birthday]').val() == '') {
            alert('请选择出生日期!');
            return false;
        }
        $.post("../users/users.ashx", { act: "isex", user: $("#userid").val() }, function (data) {
            if (data == "1") {
                alert("该用户名已存在")
            } else {
                $("#managerForm").submit();
            }
        })
       
    })
    $("#upsend").click(function () {
    
        if ($('input[name=userName]').val() == '') {
            alert('请输入真实姓名!');
            return false;
        }
        if ($('input[name=phone]').val() == '') {
            alert('手机号码不能为空!');
            return false;
        } else if (!mobile.test($('input[name=phone]').val())) {
            alert('手机号码格式不正确!');
            return false;
        }
        if ($('input[name=mail]').val() == '') {
            alert('邮箱不能为空!');
            return false;
        } else if (!myreg.test($('input[name=mail]').val())) {
            alert('邮箱格式不正确!');
            return false;
        }
        if ($('input[name=birthday]').val() == '') {
            alert('请选择出生日期!');
            return false;
        }
        $("#managerForm").submit();
    })
})