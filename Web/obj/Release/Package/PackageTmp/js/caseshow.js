// JavaScript Document
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
  	    if (top > 76) {
  	        $('#head').css({ 'background': 'rgba(11,12,17,.96)','padding-top': '0' }).addClass("aaa");
  	    } else {
  	        $('.head .nav ul .hidebtn').css({'display': 'none'});
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
