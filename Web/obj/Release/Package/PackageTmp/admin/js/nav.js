$(function(){

	$('#add').click(function(){
		if ($('input[name=name]').val() == '') {
			alert('导航名称不得为空!');
			$('input[name=name]').focus();
			return false;
		}
		
		if ($('input[name=name]').val().length < 2 || $('input[name=name]').val().length > 20) {
			alert('导航名称长度在2-20位之间!');
			$('input[name=name]').focus();
			return false;
		}
		
		if(!/^[\u4e00-\u9fa5a-z_0-9]+$/.test($('input[name=name]').val())){
			alert('导航名称必须为数字,中文,英文(小写),中横线,下划线!');
			$('input[name=name]').focus();
			return false;
		}
		
	});
	
	$('#update').click(function(){
		if($('select[name=fid]').val() == $('#update').attr('fid')){
			alert('不能选择自己作为父级栏目!');
			$('select[name=fid]').focus();
			return false;
		}
		if ($('input[name=name]').val() == '') {
			alert('导航名称不得为空!');
			$('input[name=name]').focus();
			return false;
		}
		
		if ($('input[name=name]').val().length < 2 || $('input[name=name]').val().length > 20) {
			alert('导航名称长度在2-20位之间!');
			$('input[name=name]').focus();
			return false;
		}
		
		if(!/^[\u4e00-\u9fa5a-z_0-9]+$/.test($('input[name=name]').val())){
			alert('导航名称必须为数字,中文,英文(小写),中横线,下划线!');
			$('input[name=name]').focus();
			return false;
		}
	});

	$('.w2').click(function() {
		var topNav = $(this).parent('.topNav');
		var w2I = $(this).children('i.topBtn');

		topNav.siblings('dl').slideToggle('fast');

		if (w2I.attr('value') == 'true') {
			w2I.attr('value', 'false').css('background-position', '0 0');
		}else{
			w2I.attr('value', 'true').css('background-position', '0 -10px');
		}
	});

	$('#slideAll').click(function() {
		var flag = $(this).attr('flag');
		var w2I = $('.w2 i.topBtn');
		if (flag == 0) {
			$('dl.nav > dd > dl').slideDown('fast');
			$(this).attr('flag',1).text('关闭全部');
			w2I.attr('value', 'true').css('background-position', '0 -10px');
		}
		if (flag == 1) {
			$('dl.nav > dd > dl').slideUp('fast');
			$(this).attr('flag',0).text('展开全部');
			w2I.attr('value', 'false').css('background-position', '0 0');
		}
	});


});