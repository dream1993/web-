
//document.getElementById("login_content").style.marginLeft = (document.documentElement.clientWidth - 510) / 2 + "px";
$(function () {
    $("#username").focus();
    if (top.location != self.location) {
        top.location = self.location;
    }
    var lj = window.location.toString();
    if (lj.lastIndexOf("?") != -1) {

        $("#username").focus();
    }

    var reg = /^.{1,30}$/;

    $(document).keydown(function (e) {
        var key = e.which;
        if (key == 13) {
            login()
        }
    });

    $("#submit").click(function () {
        login()
    });
    function login() {
        var u = $("input[name=username]");
        var p = $("input[name=password]");
        if (u.val() == '' || p.val() == '') {
            $("#ts").html("用户名或密码不能为空~");
            is_show();
            return false;
        }
    	//, type: $("input[name='shenfen']:checked").val()
        $.post("default.aspx", { userName: u.val(), passWord: p.val() }, function (data) {
        	var result = data.substring(0, 1);

            if (result == "0") {
                location.href = "/admin/main/";
                return false;
            } else if (result == "P") {
              
                $("#ts").html("密码不正确~");
                is_show();
                $("#p_t").val("");
                $("#p_t").focus();
            } else if (result == "Z") {
                $("#ts").html("账号不存在~");
                is_show();
               
                $("#username").val("");
                $("#username").focus();
            } else {
                $("#ts").html("格式不正确~");
                is_show();
              
                $("#username").focus();
            }
        });
        return false;
    }



    $(".btn").click(function () {
        is_hide();
    })


    window.onload = function () {
        $(".connect p").eq(0).animate({ "left": "0%" }, 600);
        $(".connect p").eq(1).animate({ "left": "0%" }, 400);
    }
    function is_hide() { $(".alert").animate({ "top": "-40%" }, 300) }
    function is_show() { $(".alert").show().animate({ "top": "45%" }, 300) }
})