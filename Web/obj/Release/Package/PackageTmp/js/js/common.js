/// <reference path="jquery-1.9.1.min.js" />

$(document).ready(function () {
    $(".nav a").hover(function () {
        $(this).children(".en").animate({ "top": "-13px" }, 300)
        $(this).children(".cn").animate({ "top": "0px" }, 300)
    }, function () {
        $(this).children(".en").animate({ "top": "0px" }, 300)
        $(this).children(".cn").animate({ "top": "13px" }, 300)
    })
    var pt;
    $("#head a .cn").each(function () {
        if ($(this).position().top == 0) {
            pt = $(this);
        }
    })
    $("#nav").click(function () {
        $(this).parent().find("ul").slideToggle()
    })
    var wh = $(window).height() - $(".contact_foot_bg").height();
    var fh = $(".contact_foot_bg").position().top;
    if (wh > fh) {
        $(".contact_foot_bg").css({ "position": "fixed", "left": "0", "bottom": "0","width":"100%" })
    }
    if ($(window).scrollTop() > 0) {
        $(".head_bg").css({ "display": "block" })
        $("#head a span").css("color", "#000")
    } else {
        $(".head_bg").css({ "display": "none" })
        $("#head a span").removeAttr("style")
    }
    
   

    var bannerH = $(".banner").height();
    var bh = bannerH - 100 < 0 ? 0 : bannerH - 100;
    $(".tophead").click(function () {
        $("body,html").animate({ scrollTop: 0 }, 300)
    })
 
    $(window).scroll(function () {
        var s_top = $(window).scrollTop();
     
        if (s_top > bh) {
            console.log(s_top)
            $(".head_bg").fadeIn(100)
            $("#head a span").css("color", "#000")
           
            $(".head .nav #nav span,.head .nav #nav").css("border-color", "#999")
        } if (s_top <= bh) {
            console.log(s_top)
            $(".head_bg").fadeOut(50)
           
            $("#head a span").removeAttr("style")
        }
        pt.css("color", "#00c0ff")
    })
})
function caseMenu(obj) {
    $(obj).parent().find(".case_n").slideToggle();
}
function caseMenuclose(obj) {
    $(obj).parent().parent().slideToggle();
}