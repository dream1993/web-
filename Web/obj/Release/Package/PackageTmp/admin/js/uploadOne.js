$(function() {

	//用于只上传一张图片的情况
	$('#uploadOneBtn').click(function() {
		$('#ajax-form').children('input[name=file]').click();
		$('#ajax-form').children('input[name=file]').change(function() {
			$('#ajax-form').ajaxSubmit({
				url : 'index.php?c=call&m=uploadOneImg',
				type : 'post',
				success : function(data){
					var newPaht = eval('('+data+')')['thumbnail_path'];
					$('#uploadOneBtn').attr('src', newPaht);
					$('#ajaxImg').val(newPaht);
				}
			});
		});
	});



});




