var dimgCount = 0;
$('#J_selectImage').click(function () {
    var myImage = uet.getDialog("insertimage");
    myImage.open();
    //侦听图片上传
    uet.addListener('beforeInsertImage', function (t, arg) {
        $.each(arg, function (index, val) {
            $('#J_selectImage').before('<a class="dimg upload"><img src="' + val.src + '" /><img  class="close" style="display: none;" value="' + val.src + '" src="/admin/img/close.png" onclick="delimg(this)"  name="close"><input type="hidden" name="pic" value="' + val.src + '"/></a>');
        });
        arg.length = 0;//清空当前数组，否则再下次上传时，会重复上传
        dt();
    });
});
dt();
function dt(){
    $(".dimg").hover(function () {
        $(this).find(".close").css("display", "block")
    }, function () {
        $(".close").css("display", "none")
    })
}
function delimg(obj) {
    $(obj).parent().remove();
    $.post("/ajax/delfile.ashx", { img: $(obj).attr("value") }, function (data) {
        if (data == 0) {
            
        } else {
            alert(data)
        }
    })
}

function after_before(add) {

    var objnew = $("#imageView").find(".on");
    var i = parseInt(objnew.attr("index")) + parseInt(add)
    if (i < 0 || dimgCount <= i) {
        return false;
    }
    var obj = $(".dimg[index='" + i + "']")
    var html = obj.html();
    obj.html(objnew.html())
    obj.addClass("on")
    objnew.removeClass("on")
    objnew.html(html)
    dt()
}
$("#imageView .dimg").live("click",function () {

    $("#imageView .dimg").attr("class", "dimg")
    $(this).addClass("on")
})

function indexDimg() {
    $("#imageView .dimg").each(function (data) {
        dimgCount = data;
        $(this).attr("index", data);
    })
    dimgCount = dimgCount + 1;
}
