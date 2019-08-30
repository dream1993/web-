/// <reference path="G:\王龙武项目\项目集\2016\Web\Web\js/jquery-1.8.3.min.js" />
$(function(){
	$('table.manager span.btn_primary').css({
		'background-color': '#ccc',
		'background-image': 'none',
		'border-color': '#DDD'
	});
	$('table.manager span.btn_primary input[name=send]').css({
		'cursor' : 'not-allowed'
	});
	

	var userTag = $('input[name=user]');

	$(userTag).bind('input propertychange', function() { 
		checkUser();
	});

	$('input[name=password]').bind('input propertychange', function() { 
		checkPass();
	});

	$('input[name=notpassword]').bind('input propertychange', function() { 
		checkNotPass();
	});


	$('select[name=level]').change(function() {
		checkLevel();
	});


	function checkUser() {
		if ($(userTag).val() == '') {
			$(userTag).siblings('span.error').css('display', 'inline').text('用户名不得为空!');
		}else if ($(userTag).val().length < 2 || $(userTag).val().length > 20) {
			$(userTag).siblings('span.error').css('display', 'inline').text('用户名长度在2-20位之间!');
		}else if(!/^[\u4e00-\u9fa5a-z_0-9]+$/.test($(userTag).val())){
			$(userTag).siblings('span.error').css('display', 'inline').text('管理员用户名必须为数字,中文,英文(小写),中横线,下划线!');
		}else{
			$(userTag).siblings('span.error').css('display', 'inline').html('<img src="/img/right.png" />');
			checkSpanNN();
		}
	}

	function checkPass(){
		if ($('input[name=password]').val() == '') {
			$('input[name=password]').siblings('span.error').css('display', 'inline').text('密码不得为空!');
			return false;
		}else if ($('input[name=password]').val().length < 6) {
			$('input[name=password]').siblings('span.error').css('display', 'inline').text('密码长度不得小于6位!');
			return false;
		}else{
			$('input[name=password]').siblings('span.error').css('display', 'inline').html('<img src="/img/right.png" />');
			checkSpanNN();
		}
	}

	function checkNotPass() {
		if ($('input[name=password]').val() != $('input[name=notpassword]').val()) {
			$('input[name=notpassword]').siblings('span.error').css('display', 'inline').text('两次输入密码不一致!');
			return false;
		}else{
			$('input[name=notpassword]').siblings('span.error').css('display', 'inline').html('<img src="/img/right.png" />');
			checkSpanNN();
		}
	}

	function checkLevel() {
		if ($('select[name=level]').val() == 0) {
			$('select[name=level]').siblings('span.error').css('display', 'inline').text('管理员权限为必选项');
			return false;
		}else{
			$('select[name=level]').siblings('span.error').css('display', 'inline').html('<img src="/img/right.png" />');
			checkSpanNN();
		}
	}

	function checkSpanNN() {
		var State = true;
		$('span.error').each(function() {
			if ($(this).html().indexOf("img")<0) {
				
				State = false;
				$('input[name=send]').css('cursor', 'not-allowed');
				return false;
			}
		});

		if (State) {
			$('input[name=send]').removeAttr('disabled').css('cursor', 'pointer');
			$('.btn_primary').css({
				'background-image' : '-moz-linear-gradient(top,#44b549 0,#44b549 100%)',
				'background-image' : '-webkit-gradient(linear,0 0,0 100%,from(#44b549),to(#44b549))',
				'background-image' : '-webkit-linear-gradient(top,#44b549 0,#44b549 100%)',
				'background-image' : '-o-linear-gradient(top,#44b549 0,#44b549 100%)',
				'background-image' : 'linear-gradient(to bottom,#44b549 0,#44b549 100%)',
				'border-color' : '#44b549'
			});
		}
	}



	$('input[name=user]').blur(function() {
		var userTag = $('input[name=user]');
		var userValue = userTag.val();
		var userSpan = $(userTag).siblings('span.error');

		$('i.loading').css('display', 'inline-block');
		$.post("../manager/manager.ashx", { user: userValue, act: "isex" }, function (data) {
			$('i.loading').css('display', 'none');
			if (data == 1) {
				$(userTag).siblings('span.error').css('display', 'inline').text('用户名被占用!');
			}
		})
		//$.ajax({
		//	url: '../manager/manager.ashx',
		//	type: 'post',
		//	dataType: 'json',
		//	data: {user : userValue,act:"isex"},
		//	success : function(data){
		//		$('i.loading').css('display', 'none');
		//		if(data == 1){
		//			$(userTag).siblings('span.error').css('display', 'inline').text('用户名被占用!');
		//		}
		//	}
		//});
	});



});