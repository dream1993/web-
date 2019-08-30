/// <reference path="G:\王龙武项目\项目集\后台模板\Web\Web\js/jquery-1.8.3.min.js" />
$(window).ready(function () {

	$('#nav').change(function () {
		personChange($(this).val());
	});
	function personChange(navVal) {
		if (navVal != -1) {
			$('#protype + i').css('display', 'block');
			//$('#protype').css('display', 'block');
			var html = '  <option value="-1">====请选择二级分类====</option>';
			$.ajax({
				url: '../goods/goods.ashx',
				type: 'post',
				dataType: 'json',
				data: { 'id': navVal, "act": "type" },
				success: function (data) {
					var json = eval(JSON.stringify(data));
					//因为上面为list集合
					for (var i = 0; i < json.length; i++) {
						// alert(json[i].id + "Name:" + json[i].title);
						var av = json[i];
						html += '<option value=' + av.id + '>' + av.title + '</option>';
					};
					$('#protype').html(html)
					$('#protype').css("display", "inline-block")
					$('#protype + i').css('display', 'none');
				}
			})
		}
	}
	//百度编辑器及图片上传
	var ue = UE.getEditor('baidu');
	var uet = UE.getEditor('baidu2');

	$('#uploadBtn').click(function () {
		var myImage = uet.getDialog("insertimage");
		myImage.open();
		//侦听图片上传
		uet.addListener('beforeInsertImage', function (t, arg) {
			$.each(arg, function (index, val) {
				$('#pics').append('<div class="pics"><img src="' + val.src + '" /><span><i class="delPics" title="删除图片"></i></span><input type="hidden" name="pics[]" value="' + val.src + '"/></div>');
			});
			arg.length = 0;//清空当前数组，否则再下次上传时，会重复上传
		});
	});

	$('.pics').live('mouseenter', function () {
		$(this).children('span').animate({ 'height': '24px' }, 'fast');
	});
	$('.pics').live('mouseleave', function () {
		$(this).children('span').animate({ 'height': '0' }, 'fast');
	});
	$('i.delPics').live('click', function () {
		$(this).parent('span').parent('.pics').remove();
	});


	//商品分类及品牌二级联动

	$('#protype').change(function () {
		var typeid = $(this).val();
		if (typeid != -1) {
			$(".berfohtml").parent().removeAttr("style")
			$.post('../goods/goods.ashx', { typeid: typeid, act: "before" }, function (data) {
				$(".berfohtml").html(data);
			})
		}
	})
	$("input[type='checkbox']").live("click",function () {
		var obj = $(this);

		if (obj.attr("flag")=="True")
		{
			if (obj.is(":checked")) {
				obj.parent().append("<input type='text' placeholder='金额（默认为产品金额）' class='add'  name='price"+obj.attr("val")+"' />");
			} else {
				obj.parent().find(".add").remove()
			}
		}
		
	})

	$("#send").click(function () {
		if ($("#protype").val() == "-1") {
			alert("请选择商品分类！")
			return false;
		}
		var b = true;
		$("input[name='typename']").each(function (data) {
			var obj = $(this);
			if (!$("input[name='type" + data + "']").is(":checked")) {
				alert("请至少选择一个"+obj.val()+"的属性")
				b = false;
				return false;
			}
		})
		if (!b) {
			return false;
		}
		if ($("#title").val() == "") {
			alert("请输入商品名称！")
			return false;
		}
		if ($("#description").val() == "") {
			alert("请输入商品描述！")
			return false;
		}
		if ($("#price").val() == "") {
			alert("请输入商品价格！")
			return false;
		}
		if ($("#pics").html() == "") {
			alert("请至少上传一张商品图片！")
			return false;
		}
		$("#serchtitle").val($("#nav").find("option:selected").text() + $("#protype").find("option:selected").text() + $("#title").val());
		alert($("#serchtitle").val())
		$("#managerForm").submit();
	})

});