$(function(){

//管理员删除弹窗
$('.del').click(function() {
	if (confirm("确定删除吗?")) {
		location.href = $(this).attr('alt');
	}else{
		return false;
	}

});


});