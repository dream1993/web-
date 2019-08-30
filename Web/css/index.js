/// <reference path="jquery-1.9.1.min.js" />
$("#fp-nav a").removeClass("active").eq(0).addClass("active")
$("#fp-nav").append('<div class="xiahua"><div class="xiahuak"><a href="#service"><i></i></a></div></div>')
//首页banner
var zh = 0;
var zw = 0;
var liwidth = 0;
//var licount = $("#indexBanner  li").length;

$(function () {
    //alert($(window).width()+","+$(window).height())
    bannerimg();
    $(".nav a").hover(function () {
        $(this).children(".en").animate({ "top": "-14px" }, 300)
        $(this).children(".cn").animate({ "top": "0px" }, 300)
    }, function () {
        $(this).children(".en").animate({ "top": "0px" }, 300)
        $(this).children(".cn").animate({ "top": "13px" }, 300)
    })
    setInterval(function () {
        $(".sdts span").animate({ "top": "15px" }, 500)
        $(".sdts span").animate({ "top": "8px" }, 500)
    }, 1000);

})

function bannerimg() {
    // $("body").css("overflow-x", "hidden");
    zh = $(window).height();
    zw = $(window).width();

    if (2*zh < zw) {
        // img.css({ "left": "0", "top": (zh - imgh) / 2 + "px", "width": zw + "px", "height": imgh + "px"})
        $("body").removeClass("height").addClass("width");
    } else {
        // img.css({ "left": (zw - imgw) / 2 + "px", "top": "0", "width": imgw + "px", "height": zh + "px"})
        $("body").removeClass("width").addClass("height");
    }
}

$(window).resize(function () {
    bannerimg();
})
//var t_img; // 定时器
//var isLoad = true; // 控制变量
//// 判断图片加载状况，加载完成后回调
//var i = 0;
//isImgLoad(function () {
//    // 加载完成
//});
//// 判断图片加载的函数
//function isImgLoad(callback) {
//    // 注意我的图片类名都是cover，因为我只需要处理cover。其它图片可以不管。
//    // 查找所有封面图，迭代处理
//    $('.banner > img').each(function () {
//        // 找到为0就将isLoad设为false，并退出each
//        if (this.height === 0) {
//            isLoad = false;
//            return false;
//        }
//    });
//    // 为true，没有发现为0的。加载完毕
//    if (isLoad) {
//        clearTimeout(t_img); // 清除定时器
//        // 回调函数
//        callback();
//        // 为false，因为找到了没有加载完成的图，将调用定时器递归
//    } else {
//        isLoad = true;
//        t_img = setTimeout(function () {
//            isImgLoad(callback); // 递归扫描
//        }, 500); // 我这里设置的是500毫秒就扫描一次，可以自己调整
//    }
//}


