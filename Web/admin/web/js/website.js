var ue = UE.getEditor('content');
var html = '<div class="message_ts" style="z-index:999;position:fixed;top:50%;left:50%;width:300px;height:130px;border:1px solid #ccc;background:#fff;margin-left:-150px;margin-top:-65px;"><div style="height:93px;line-height:25px;padding:0 10px;text-align:center;"><img src="/img/logo.png" style="width:48px;margin-top:13px;"/><br/>';
var html1 = '</div><p style="margin:0;text-align:right;padding:5px 10px;border-top:1px solid #ccc"><a onclick="btnclose(this)" href="javascript:void(0)" id="btnclose" style="display:inline-block;color:#aaa;width:60px;height:25px;text-align:center;line-height:25px;border:1px solid #ccc;">确 定</a></p></div>';

$("#go").click(function () {
	$.post("ajax/website.ashx", { title: $("#title").val(), description: $("#description").val(), keywords: $("#keywords").val(), copyright: ue.getContent(), mail: $("#mail").val(), tel: $("#tel").val(), address: $("#address").val(), code: $("#code").val(), tel1: $("#tel1").val(), QQ1: $("#QQ1").val(), QQ2: $("#QQ2").val(), fax: $("#fax").val(), weburl: $("#weburl").val() }, function (data) {
		if (data == "0") {
		    $("body").append(html + '修改信息成功。' + html1)
			
			return false;
		}
		$("body").append(html + data + html1)
	});
});
function btnclose(obj) {
    $(".message_ts").remove();
}