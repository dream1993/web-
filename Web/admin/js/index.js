$(function(){

	//页面布局
	var H = $(window).height() > 600 ? $(window).height() : 600;//视窗高度,最小600
	var W = $(window).width() > 1200 ? $(window).width() : 1200;//视窗宽度,最小1200
	$('#head').css({
		width: W
	});
	$('#main').css({
		'height': H - 60,
		'width': W
	});
	$('#main2').css({
		'height' : H - 100,
		'width' : W - 40
	});


	$('#iframe').css({
		'height': H - 102,
		'width' : W - 252
	});

	$(window).resize(function() {
		var newH = $(window).height() > 600 ? $(window).height() : 600;//视窗高度,最小600
		var newW = $(window).width() > 1200 ? $(window).width() : 1200;//视窗宽度,最小1200
		$('#head').css({
			width: newW
		});
		$('#main').css({
			'height': newH - 60,
			'width': newW
		});
		$('#main2').css({
			'height' : newH - 100,
			'width' : newW - 40
		});

		$('#iframe').css({
			'height': newH - 102,
			'width' : newW - 252
		});
	});

	



	//导航栏切换
	$('.nav li').click(function() {
		$(this).addClass('active').siblings().removeClass();
		$('dl.menu').hide().eq($('.nav li').index(this)).show();
	});

	$('dl.menu dd').click(function() {
		$(this).addClass('on').siblings().removeClass();
	});



	
});