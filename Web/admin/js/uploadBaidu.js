$(function(){
	

	var ue = UE.getEditor('baidu');
	var uet = UE.getEditor('baidu2');

	$('#uploadBtn').click(function() {
		var myImage = uet.getDialog("insertimage");
		myImage.open();

		//侦听图片上传
		uet.addListener('beforeInsertImage', function (t, arg) {
			//将地址赋值给相应的input,只去第一张图片的路径
			$("#ajaxImg").attr("value", arg[0].src);
			//图片预览
			$("#uploadBtn").attr("src", arg[0].src);
		})


	});
	
	
	
});
