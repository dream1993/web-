/// <reference path="jquery-1.9.1.min.js" />

$(document).ready(function () {
    var id = $("#zan").attr("val")
    $.post("/ajax/casedj.ashx", { id: id, act: "hq" }, function (data) {
        $("#zan").children("span").html(data)
    })
    $("#zan").click(function () {
        var cc = $("#zan").children("span").html();
        if ($("#zan").children("i").hasClass("on")) {
            return false;
        }
       $.post("/ajax/casedj.ashx", { id: id, act: "up" }, function (data) {
           $("#zan").children("i").addClass("on")
            $("#zan").children("span").html(parseInt(cc)+1)
        })
    })
})