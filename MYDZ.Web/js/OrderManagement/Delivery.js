var DeliveryList = null;
var DeleveryID;
//获取页面上存在的Select（即：已经设置的物流）
function GetHasDeliveryID() {
    var HasDeliveryID = [];
    $('select').each(function (i, item) {
        HasDeliveryID.push($(item).val());
    })
    return HasDeliveryID;
}
var Delivery = function () {
    var Data = null;
    this.Page = {
        Init: function () {
            this.InitEvnet();
        },
        InitEvnet: function () {
            var base = this;
            $(".table_float a.add").click(function () { base.InertRow(); });
            $(".table_bd").delegate("a.del", "click", function () { base.DeleteRow(this); });
            $(".table_bd").delegate("a.up,a.down", "click", function () { base.Sort(this); });
            $(".table_bd select").select2();
            $(".table_form button[type=submit]").click(function () { base.Save(); });

            this.VerifySort();
        },
        InertRow: function () {
            var tr = $("<tr></tr>");
            var Inner = this.InitData();
            tr.append('<td><select style="width:200px;">' + Inner.join('') + '</select></td>');
            tr.append('<td><input type="text" class="mini" style="width:120px;" /></td>');
            tr.append('<td><a hidefocus="true" href="javascript:void();" class="up up_disabled"></a><a hidefocus="true" href="javascript:void();" class="down down_disabled"></a></td>');
            tr.append('<td><a hidefocus="true" href="javascript:void();" class="del">删除</a></td>');

            $(".table_bd table tbody").append(tr);
            tr.find("select").select2();
            this.VerifySort();
        },
        InitData: function () {
            var Inner = ["<option value='0'>请选择</option>"];
            if (Data == null) {
                DeleveryID = GetHasDeliveryID();
                if (DeliveryList === null) {
                    $.ajax({
                        type: "post", url: "/OrderManagement/Logistics.html", cache: false, async: false, dataType: "json", data: {},
                        success: function (data) {
                            DeliveryList = data.List;
                        }
                    });
                }
                for (var i = 0; i < DeliveryList.length; i++) {
                    if (jQuery.inArray(DeliveryList[i].Id.toString(), DeleveryID) === -1) {
                        Inner.push("<option value='" + DeliveryList[i].Id + "'>" + DeliveryList[i].Name + "</option>");
                    }
                }
                //parseInt(DeliveryList[i].Id)
            }
            return Inner;
        },
        DeleteRow: function (obj) {
            $(obj).parents("tr:eq(0)").remove();
            this.VerifySort();
        },
        Sort: function (obj) {
            if ($(obj).hasClass("up_disabled") || $(obj).hasClass("down_disabled")) { return; }
            var isUp = $(obj).hasClass("up");
            var tr = $(obj).parents("tr:eq(0)");
            var target = isUp ? tr.prev() : tr.next();
            if (target.length <= 0) { return; }

            if (isUp) {
                tr.after(target);
            } else {
                tr.before(target);
            }
            this.VerifySort();
        },
        VerifySort: function () {
            $(".table_bd table tbody tr").each(
                function () {
                    var up = $(this).find("a.up");
                    var down = $(this).find("a.down");

                    if ($(this).next().length > 0) {
                        down.removeClass("down_disabled");
                    } else {
                        down.addClass("down_disabled");
                    }

                    if ($(this).prev().length > 0) {
                        up.removeClass("up_disabled");
                    } else {
                        up.addClass("up_disabled");
                    }
                }
            );
        },
        Verification: function () {
            var IsOk = true;
            var trs = $(".table_bd table tbody tr");
            for (var i = 0; i < trs.length; i++) {
                var tr = trs.eq(i);
                var obj = null;
                var select = tr.find("select");
                var ipt = tr.find("input.mini");

                if (select.val().Trim() == "0") {
                    obj = select;
                } else {
                    if (ipt.val().IsEmpty()) {
                        obj = ipt;
                    } else {
                        if (!ipt.val().Trim().CheckInteger()) {
                            ipt.val("");
                            obj = ipt;
                        }
                    }
                }

                if (obj != null) {
                    obj.focus();
                    tr.stop().animate({
                        "backgroundColor": "#ff5500"
                    },
                    function () {
                        tr.animate({
                            "backgroundColor": "#fff"
                        },
                    function () {
                        tr.animate({
                            "backgroundColor": "#ff5500"
                        },
                     function () {
                         tr.animate({ "backgroundColor": "#fff"
                         });
                     });
                    })
                    });
                    IsOk = false;
                    break;
                }
                select.attr("name", "LogisticsList[" + i + "].LogisticsId");
                ipt.attr("name", "LogisticsList[" + i + "].Number");
            }

            return IsOk;
        },
        Save: function () {
            if (!this.Verification()) {
                window.event.returnValue = false;
                return false;
            }
        }
    };
}

$(document).ready(
    function () {
        new Delivery().Page.Init();
        $('.mini').css("width", "120");
    }
);