// JavaScript Document
window.onload=function () {
    $("#return_top").click(function () {
        $('body,html').animate({ scrollTop: 0 }, 1000);
})

  // 服务页效果
  
  
 //导航条
  var headTop = $('.headTop').height();
  var head = $('#head').height()
  //$('#head').css({ 'background': 'rgba(0,0,0,0)'});
  	$(window).scroll(function () {
    	var top = $(window).scrollTop()
    	    head_stop(top);
  	})
  	if (headTop != null ) {
  	    head_stop($(window).scrollTop())
  	}
  	function head_stop(top) {
  	    if (top > headTop-head+10) {
  	        $('#head').css({ 'background': 'rgba(11,12,17,.96)','padding-top': '0' }).addClass("aaa");
  	    } else {
  	        $('.head .nav ul .hidebtn').css({'display': 'none'});
            $('.full-zh').css({'display':'none'});
  	        $('#head').css({ 'background': 'rgba(11,12,17,0)','padding-top': '10px' }).addClass("aaa");;
  	        $('.right-nav').css({
  	            '-webkit-transform': 'translate3d(140%,0,0)',
  	            'transform': 'translate3d(140%,0,0)',
  	            'transition': 'all 1s',
  	            '-webkit-transition': 'all 1s'
  	        })
  	    }
  	}
  	$('.hidebtn').on('click', function () {
		$('.full-zh').css({'display':'block'});
  	$('.right-nav').css({
	'display': 'block\0',
	
	'-webkit-transform': 'translate3d(0,0,0)',
    'transform': 'translate3d(0,0,0)',
    'transition': 'all 1s',
    '-webkit-transition': 'all 1s'})
  	})
  	$('.close-btn').on('click', function () {
	  $('.full-zh').css({'display':'none'});
  	$('.right-nav').css({'-webkit-transform': 'translate3d(140%,0,0)',
    'transform': 'translate3d(140%,0,0)',
    'transition': 'all 1s',
	'display': 'none\0',
    '-webkit-transition': 'all 1s'})
  	})
}


// 判断图片加载完成执行动画
var t_img; // 定时器
        var isLoad = true; // 控制变量
        // 判断图片加载状况，加载完成后回调
        var i = 0;
        isImgLoad(function () {
            // 加载完成
            $(".headTop").addClass("on");
           
        });

        // 判断图片加载的函数
        function isImgLoad(callback) {
            // 注意我的图片类名都是cover，因为我只需要处理cover。其它图片可以不管。
            // 查找所有封面图，迭代处理
            $('.headTop > img').each(function () {
                // 找到为0就将isLoad设为false，并退出each
                if (this.height === 0) {
                    isLoad = false;
                    return false;
                }
            });
            // 为true，没有发现为0的。加载完毕
            if (isLoad) {
                clearTimeout(t_img); // 清除定时器
                // 回调函数
                callback();
                // 为false，因为找到了没有加载完成的图，将调用定时器递归
            } else {
                isLoad = true;
                t_img = setTimeout(function () {
                    isImgLoad(callback); // 递归扫描
                }, 100); // 我这里设置的是500毫秒就扫描一次，可以自己调整
            }
        }


     
    //定义变量获取屏幕视口宽度









