var ue = UE.getEditor('content');

var uet = UE.getEditor('imgup');
var uet1 = UE.getEditor('imgup1');
$('#uploadpic').click(function () {

    var myImage = uet1.getDialog("insertimage");
    myImage.open();

    //侦听图片上传
    uet1.addListener('beforeInsertImage', function (t, arg) {
        //将地址赋值给相应的input,只去第一张图片的路径
        $("#imgSrc1").attr("value", arg[0].src);
        //图片预览
        $('#uploadpic').html("<img src='" + arg[0].src + "' />")
    })
    
    
});
$('#upload').click(function () {

	var myImage = uet.getDialog("insertimage");
	myImage.open();
	//侦听图片上传
	uet.addListener('beforeInsertImage', function (t, arg) {
		//将地址赋值给相应的input,只去第一张图片的路径
		//$("#imgSrc").attr("value", arg[0].src);
		//图片预览
	    $('#upload').before("<a class='showpic' href='javascript:void(0)'><img src='" + arg[0].src + "'  /></a><input type='hidden' value='" + arg[0].src + "' name='pic'/>")
	})
	

});
$('#uploadq').click(function () {

	var myImage = uet.getDialog("insertimage");
	myImage.open();

	//侦听图片上传
	uet.addListener('beforeInsertImage', function (t, arg) {
		//将地址赋值给相应的input,只去第一张图片的路径
		$("#imgSrc").attr("value", arg[0].src);
		//图片预览
		$('#imgs').attr("src", arg[0].src)
	})


});
if ($("#img").attr("src") == "") { $("#img").hide(); $('#upload').html("上传图片")}
if ($("#img1").attr("src") == "") { $("#img1").hide(); $('#uploadpic').html("上传图片") }
function setContent(obj) {
    obj.setContent('');
}