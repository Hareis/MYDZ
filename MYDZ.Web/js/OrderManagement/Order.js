var CurrentPage = null;
var Order = function () {
    var Config = {
        PageIndex: parseInt(jQuery.trim($("input[name=PageIndex]").val())),
        ShopId: parseInt(jQuery.trim($("input[name=ShopId]").val())),
        LogisId: parseInt(jQuery.trim($("input[name=LogisId]").val())),
        StatusId: parseInt(jQuery.trim($("input[name=StatusId]").val())),
        CateId: parseInt(jQuery.trim($("input[name=CateId]").val())),
        RefundId: parseInt(jQuery.trim($("input[name=RefundId]").val())),
        FreeId: parseInt(jQuery.trim($("input[name=FreeId]").val())),
        FlagId: parseInt(jQuery.trim($("input[name=FlagId]").val())),
        SortId: parseInt(jQuery.trim($("input[name=SortId]").val())),
        PrintId: parseInt(jQuery.trim($("input[name=PrintId]").val())),
        InvoiceId: parseInt(jQuery.trim($("input[name=InvoiceId]").val())),
        UserNick: jQuery.trim($("input[name=UserNick]").val()),
        OutNumber: jQuery.trim($("input[name=OutNumber]").val()),
        Code: jQuery.trim($("input[name=Code]").val()),
        Name: jQuery.trim($("input[name=Name]").val()),
        CName: jQuery.trim($("input[name=CName]").val()),
        Province: jQuery.trim($("input[name=Province]").val()),
        City: jQuery.trim($("input[name=City]").val()),
        District: jQuery.trim($("input[name=District]").val()),
        Tel: jQuery.trim($("input[name=Tel]").val()),
        Mobile: jQuery.trim($("input[name=Mobile]").val()),
        Addr: jQuery.trim($("input[name=Addr]").val()),
        Msg: jQuery.trim($("input[name=Msg]").val()),
        SDetail: jQuery.trim($("input[name=SDetail]").val()),
        ODetail: jQuery.trim($("input[name=ODetail]").val()),
        CStart: jQuery.trim($("input[name=CStart]").val()),
        CEnd: jQuery.trim($("input[name=CEnd]").val()),
        PStart: jQuery.trim($("input[name=PStart]").val()),
        PEnd: jQuery.trim($("input[name=PEnd]").val()),
        IStart: jQuery.trim($("input[name=IStart]").val()),
        IEnd: jQuery.trim($("input[name=IEnd]").val()),
        MaxPage: 0,
        MaxRow: 0,
        PostType: ""
    };

    var BarTop = 289;
    var diaglog = $("div.dialogContainer");
    var TmpTable = null;
    var ShowIdList = [0, 1, 2, 7, 16];
    var TmpOrderNumber = null;
    var TmpOrderObj = null;

    this.Page = {
        Init: function () {
            this.InitData();
            this.InitEvnet();
        },
        InitData: function () {
            var base = this;
            Config.PostType = "Onload";
            $.ajax({ type: "get", url: "/OrderManagement/BacklogOrders.html", data: "", async: false, success: function (data) {
                if (data.Result === true) {
                    alert("asd");
                }
            }
            });
            $.post("/OrderManagement/BacklogOrders.html", Config,
                function (data) {
                    var div = $("<div></div>").append(data);
                    var PageIndex = div.find("input[name=PageIndex]");
                    var MaxRow = div.find("input[name=MaxRow]");
                    var MaxPage = div.find("input[name=MaxPage]");
                    var MPrint = div.find("input[name=MPrint]");
                    var NPrint = div.find("input[name=NPrint]");
                    var YPrint = div.find("input[name=YPrint]");
                    Config.PageIndex = parseInt($.trim(PageIndex.val()));
                    Config.MaxRow = parseInt($.trim(MaxRow.val()));
                    Config.MaxPage = parseInt($.trim(MaxPage.val()));

                    var splist = $("div.tab li span");
                    splist.eq(0).html($.trim(MPrint.val()));
                    splist.eq(1).html($.trim(NPrint.val()));
                    splist.eq(2).html($.trim(YPrint.val()));

                    PageIndex.add(MaxRow).add(MaxPage).add(NPrint).add(YPrint).remove();

                    $(".DataTable").append(div.html());

                    if (CurrentPage == null) {
                        CurrentPage = new Paging("CurrentPage",
                            function (pageIndex) {
                                Config.PageIndex = pageIndex;
                                base.Jump();
                            });
                    };

                    CurrentPage.Control.Init({
                        PageIndex: Config.PageIndex,
                        MaxPageNumber: Config.MaxPage,
                        MaxRow: Config.MaxRow
                    });

                    if (Config.PageIndex >= Config.MaxPage) {
                        $(".pageMoreWrap").hide();
                    } else {
                        $(".pageMoreWrap").show();
                    }
                }
            , "html");
        },
        InitEvnet: function () {
            var base = this;
            this.GetShowIdList();
            var bdlist = $(".btn_wrap_bd");
            bdlist.each(function (index) { if ($.inArray(index, ShowIdList) === -1) { $(this).hide(); } });
            BarTop = $("div.body_wrap").offset().top;

            $("a.sync").click(
                function () {
                    var isok = false;
                    $.post("/OrderManagement/CheckLogis.html", {},
                        function (data) {
                            isok = data.status;
                        }
                    ).done(
                        function () {
                            if (isok) {
                                $(this).prev().hide();
                                $(this).hide().next().show();
                                //判断用户是否已经设置物流，true 再执行下面的
                                $.post("/OrderManagement/RequestOrder.html", {},
                                    function (data) {
                                        window.location.href = "/OrderManagement/OrderIndex.html";
                                    }
                                );
                            } else {
                                layer.alert({ title: "温馨提示", width: 300, msg: "未设置物流信息，点此去<a href='/OrderManagement/Delivery.html' style='color:blue;'>设置</a>", icon: 3 });
                            }
                        }
                    );
                }
            );

            $("a.userdown").click(
                function () {
                    base.ShowMaskLayer();
                    diaglog.attr({ "data-id": "9", "data-param": "a.userdown" }).find(".dialogContainer-hd").html("按用户名下载订单").end().find("tbody").empty().append('<tr><td class="left" style="width:90px;">订单编码列表：</td><td><input type="text" style="width:270px;" name="ud_list" value="" /></td></tr><tr><td colspan="2"><span style="padding-left:10px;">小提示：多个订单编码中间用英文逗号 “,” 分隔</span></td></tr>');
                    base.ShowDialog();
                }
            );

            $(".btn_wrap_open span").click(
                function () {
                    if ($(this).hasClass("btn_wrap_close")) {
                        $(this).removeClass("btn_wrap_close").html("收起");
                        bdlist.show();
                    } else {
                        $(this).addClass("btn_wrap_close").html("展开");
                        bdlist.each(function (index) { if ($.inArray(index, ShowIdList) == -1) { $(this).hide(); } });
                    }
                    BarTop = $("div.body_wrap").offset().top;
                }
            );

            $("div.DataTable").delegate(".detail_wrap", "mouseover",
                function () {
                    $(this).find("div.detail_div").show();
                }
            ).delegate(".detail_wrap", "mouseout",
                function () {
                    $(this).find("div.detail_div").hide();
                }
            );

            /* 全选*/
            $(document).delegate("input[type=checkbox]", "change",
                function () {
                    var name = $(this).attr("name");
                    if (name === "chk_all") {
                        var checked = this.checked;
                        // $(this).parent().parent().addClass(checked ? "checked" : "");
                        $("input[type=checkbox]").not("[name=chk_all]").each(
                            function () {
                                this.checked = checked;
                                if (checked) {
                                    $(this).parents("label.checkbox:eq(0)").addClass("checked");
                                } else {
                                    $(this).parents("label.checkbox:eq(0)").removeClass("checked");
                                }
                            }
                        );
                    }

                    // $(this).parents("label.checkbox:eq(0)").toggleClass("checked");
                }
            );

            $(document).delegate("input[type=radio]", "change",
                function () {
                    var name = $(this).attr("name");
                    $("input[type=radio][name=" + name + "]").parents("label.radio").removeClass("checked");
                    $(this).parents("label.radio:eq(0)").addClass("checked");
                }
            );

            $("button[name=Search]").click(function () { base.ToSearch(); });
            $(".btn_wrap_item li a").click(function () { base.ToStatus(this); });
            $(".sortbar li a").click(function () { base.ToSort(this); });
            $(".pageMoreWrap a").click(function () { base.SyncLoad(); });

            $(window).bind("scroll",
                function () {
                    var top = $(window).scrollTop();
                    if (BarTop < top) {
                        $(".body_wrap").addClass("body_wrap_fix").find(".tools li.right a").attr("rel", "1").html("回顶部");
                    } else {
                        $(".body_wrap").removeClass("body_wrap_fix").find(".tools li.right a").attr("rel", "0").html("去底部");
                    }
                }
            );

            $(document).bind("click",
                function () {
                    TmpOrderNumber = null;
                    TmpOrderObj = null;
                    $(".invoice_choose_wrap").remove();
                }
            )

            $(".tools li.right a").click(
                function () {
                    var id = parseInt($(this).attr("rel"));
                    if (id) {
                        $('body,html').animate({ scrollTop: 0 }, 500);
                    } else {
                        $('body,html').animate({ scrollTop: $(document).height() }, 500);
                    }
                }
            );

            $("div.tab li a").click(
                function () {
                    if ($(this).hasClass("selected")) { return; }
                    Config.PageIndex = 1;
                    var index =$(this).parent().find("a").index(this);
                    Config.PrintId = index;
                    base.Jump();
                }
            );

            $(document).delegate("a[name=close]", "click",
                function () {
                    var clsobj = this;
                    layer.confirm({ title: "温馨提示", icon: 2, msg: "您确定要关闭该笔交易吗？", close:
                        function (type) {
                            if (type != 1) { return; }
                            var number = $(clsobj).attr("data-number");
                            var obj = $(clsobj).parents("table.ot:eq(0)");

                            $.post("/OrderManagement/ChangeStatus.html", { Number: number, Status: 6 },
                            function (data) {
                                if (data.Status) {
                                    obj.fadeOut(function () { $(this).remove(); });
                                }
                            });
                        }
                    });
                }
            );

            $(document).delegate("a[name=ChangeInvoice]", "click",
                function (e) {
                    $(".invoice_choose_wrap").remove();
                    var number = $(this).attr("data-number");
                    TmpOrderNumber = number;
                    TmpOrderObj = $(this).parents("table.ot:eq(0)");
                    var click = parseInt($(this).attr("data-click"));
                    if (click != 0 && click != 1) { return; }
                    var div = $("<div></div>").addClass("invoice_choose_wrap");
                    var ul = $("<ul></ul>").appendTo(div);
                    ul.append('<li><a ' + (click == 1 ? "class='click'" : "") + ' href="javascript:void();" data="1"><span>有发货单</span></a></li>');
                    ul.append('<li><a ' + (click == 0 ? "class='click'" : "") + ' href="javascript:void();" data="0"><span>无发货单</span></a></li>');

                    $("body").append(div);

                    var size = $(this).offset();
                    var div_height = div.height();
                    var div_width = div.width();
                    div.css({ height: "0px", left: size.left - (div_width - $(this).width()) / 2, top: size.top }).show();

                    div.animate({
                        height: div_height,
                        top: size.top - (div_height - $(this).height()) / 2
                    });

                    base.stopPropagation(e);
                    return false;
                }
            );

            $(document).delegate("div.invoice_choose_wrap li a", "click",
                function (e) {
                    if (TmpOrderNumber != null) {
                        if (!$(this).hasClass("click")) {
                            var obj = this;
                            $.post("/OrderManagement/ChangeInvoice.html", { Num: TmpOrderNumber, State: $(this).attr("data") },
                                function (data) {
                                    if (data.Status) {
                                        TmpOrderObj.fadeOut(function () { $(this).remove(); TmpOrderObj = null; });
                                    }
                                }
                            );

                            TmpOrderNumber = null;
                            $(obj).parents("div.invoice_choose_wrap:eq(0)").remove();
                        }

                        base.stopPropagation(e);
                        return false;
                    }
                }
            )

            $(document).delegate("div.flag", "click",
                function () {
                    base.ShowMaskLayer();
                    var number = $(this).attr("data-number");
                    var text = $(this).attr("data-text");
                    var flag = parseInt($(this).attr("data-flag"));

                    var Inner = [];
                    var FlagList = [{ id: 0, name: "灰旗" }, { id: 1, name: "红旗" }, { id: 2, name: "黄旗" }, { id: 3, name: "绿旗" }, { id: 4, name: "蓝旗" }, { id: 5, name: "紫旗"}];
                    Inner.push('<tr><td class="left">旗帜：</td><td>');
                    for (var i = 0; i < FlagList.length; i++) {
                        Inner.push('<label class="radio' + (FlagList[i].id == flag ? " checked" : "") + '"><span><input name="detailFlag" type="radio" ' + (FlagList[i].id == flag ? " checked" : "") + ' value="' + FlagList[i].id + '" hidefocus="true"></span><em>' + FlagList[i].name + '</em></label>	');
                    }
                    Inner.push('</td></tr>');
                    Inner.push('<tr><td class="left">备注：</td><td><textarea style="width:280px;height:50px;">' + text + '</textarea></td></tr>');
                    diaglog.attr({ "data-id": "1", "data-param": number }).find(".dialogContainer-hd").html("订单备注管理").end().find("tbody").empty().append(Inner.join(''));
                    TmpTable = $(this).parents("table.ot:eq(0)");
                    base.ShowDialog();
                }
            );

            $(document).delegate("a[name=consignee]", "click",
                function () {
                    base.ShowMaskLayer();
                    var number = $(this).attr("data-number");
                    TmpTable = $(this).parents("table.ot:eq(0)");
                    $.get("/OrderManagement/Consignee.html", { param: number },
                        function (data) {
                            diaglog.attr({ "data-id": "2", "data-param": number }).find(".dialogContainer-hd").html("收货人管理").end().find("tbody").empty().append(data);
                            base.ShowDialog();
                        }
                    , "html");
                }
            );

            $(document).delegate("a[name=logistics]", "click",
                function () {
                    base.ShowMaskLayer();
                    var number = $(this).attr("data-number");
                    var id = $(this).attr("data-id");
                    TmpTable = $(this).parents("table.ot:eq(0)");
                    $.get("/OrderManagement/ShopConsignee.html", {},
                        function (data) {
                            diaglog.attr({ "data-id": "3", "data-param": number }).find(".dialogContainer-hd").html("物流管理").end().find("tbody").empty().append(data);
                            base.ShowDialog();
                        }
                    , "html");
                }
            );

            $(document).delegate("a[name=Delivery]", "click",
                function () {
                    base.ShowMaskLayer();
                    var number = $(this).attr("data-number");
                    var id = $(this).attr("data-id");
                    TmpTable = $(this).parents("table.ot:eq(0)");
                    $.get("/OrderManagement/OrderSend.html", { param: id },
                        function (data) {
                            diaglog.attr({ "data-id": "5", "data-param": number }).find(".dialogContainer-hd").html("订单发货").end().find("tbody").empty().append(data);
                            base.ShowDialog();
                        }
                    , "html");
                }
            );

            $(document).delegate("a[name=dev_rang]", "click",
                function () {
                    base.ShowMaskLayer();

                    var number = $(this).attr("data-number");
                    var cash = $(this).attr("data-cash");
                    TmpTable = $(this).parents("table.ot:eq(0)");
                    $.get("/OrderManagement/Rang.html", { param: (number + "," + cash) },
                        function (data) {
                            diaglog.attr({ "data-id": "6", "data-param": number }).find(".dialogContainer-hd").html("物流公司").end().find("tbody").empty().append(data);
                            base.ShowDialog();
                        }
                    , "html");
                }
            );

            $(document).delegate("a[name=audit]", "click",
                function (evt) {
                    var tmp = $("div.audit_wrap");
                    if (tmp.length > 0) { tmp.fadeOut(function () { $(this).remove(); }); }
                    TmpTable = $(this).parents("table.ot:eq(0)");
                    var number = $(this).attr("data-number");
                    var div = $("<div></div>").addClass("audit_wrap");
                    div.append('<ul><li><a href="javascript:void();" data-id="3" data-number="' + number + '"><span>审核已付款</span></a></li><li><a href="javascript:void();" data-id="1" data-number="' + number + '"><span>审核未付款</span></a></li></ul>');
                    $("body").append(div);

                    var div_height = div.height();
                    var div_width = div.width();
                    var a_height = $(this).height();
                    var a_width = $(this).width();
                    var size = $(this).offset();

                    div.css({ height: "0px", left: size.left - (div_width - a_width) / 2, top: size.top }).show();
                    div.animate({
                        height: div_height,
                        top: size.top - (div_height - a_height) / 2
                    });

                    base.stopPropagation(evt);
                }
            );

            $(document).delegate(".audit_wrap a", "click",
                function () {
                    $.post("/OrderManagement/ChangeStatus.html", { Number: $(this).attr("data-number"), Status: $(this).attr("data-id") },
                        function (data) {
                            if (data.Status) {
                                if (TmpTable != null) {
                                    TmpTable.fadeOut(function () { $(this).remove(); });
                                }
                            }
                        }
                    );
                }
            );

            $(document).bind("click",
                function () {
                    var tmp = $("div.audit_wrap");
                    if (tmp.length > 0) { tmp.fadeOut(function () { $(this).remove(); }); }
                }
            )

            $("a.merge_order").click(function () { base.ToMergeOrder(); });

            $(".dialogContainer-ft,.dialogContainer-tool a.cancel").click(function () { base.HideDialog(); });
            $(".dialogContainer-tool a.save").click(function () { base.HideDialog(true); });

            $("a.batch_print").click(function () { base.ToBatchSender(); });
            $("a.batch_deliver").click(function () { base.ToBatchDeliver(); });
            $("a.batch_sender").click(function () { base.ToBatchSender(true); });
            $("a.batch_logistics").click(function () { base.ToBatchLogistics(this); });
        },
        GetShowIdList: function () {
            if (Config.ShopId > 0) { ShowIdList.push(0); }
            if (Config.CateId > 0) { ShowIdList.push(3); }
            if (Config.RefundId > 0) { ShowIdList.push(4); }
            if (Config.FreeId > 0) { ShowIdList.push(5); }
            if (Config.FlagId > 0) { ShowIdList.push(6); }
            if (Config.InvoiceId > 0) { ShowIdList.push(7); }

            if (Config.Code.length > 0 || Config.Name.length > 0) { ShowIdList.push(9); }
            if (Config.CName.length > 0 || Config.Province.length > 0 || Config.City.length > 0) { ShowIdList.push(10); }
            if (Config.District.length > 0 || Config.Tel.length > 0 || Config.Mobile.length > 0) { ShowIdList.push(11); }
            if (Config.Addr.length > 0) { ShowIdList.push(12); }
            if (Config.Msg.length > 0 || Config.SDetail.length > 0 || Config.ODetail.length > 0) { ShowIdList.push(13); }
            if (Config.CStart.length > 0 || Config.CEnd.length > 0) { ShowIdList.push(14); }
            if (Config.PStart.length > 0 || Config.PEnd.length > 0) { ShowIdList.push(15); }
            if (Config.IStart.length > 0 || Config.IEnd.length > 0) { ShowIdList.push(16); }

            /*
            if (!jQuery.isEmptyObject(Config.Code) || !jQuery.isEmptyObject(Config.Name)) { ShowIdList.push(9); }
            if (!jQuery.isEmptyObject(Config.CName) || !jQuery.isEmptyObject(Config.Province) || !jQuery.isEmptyObject(Config.City)) { ShowIdList.push(10); }
            if (!jQuery.isEmptyObject(Config.District) || !jQuery.isEmptyObject(Config.Tel) || !jQuery.isEmptyObject(Config.Mobile)) { ShowIdList.push(11); }
            if (!jQuery.isEmptyObject(Config.Addr)) { ShowIdList.push(12); }
            if (!jQuery.isEmptyObject(Config.Msg) || !jQuery.isEmptyObject(Config.SDetail) || !jQuery.isEmptyObject(Config.ODetail)) { ShowIdList.push(13); }
            if (!jQuery.isEmptyObject(Config.CStart) || !jQuery.isEmptyObject(Config.CEnd)) { ShowIdList.push(14); }
            if (!jQuery.isEmptyObject(Config.PStart) || !jQuery.isEmptyObject(Config.PEnd)) { ShowIdList.push(15); }
            if (!jQuery.isEmptyObject(Config.IStart) || !jQuery.isEmptyObject(Config.IEnd)) { ShowIdList.push(16); }
            */
        },
        ToMergeOrder: function () {
            if (Config.StatusId != 4 && Config.StatusId != 5) {
                layer.alert({ width: 510, icon: 3, title: "温馨提示", msg: "只有选择订单状态为“等待卖家确认或等待卖家发货”,才能合并订单" });
                return;
            }

            var IdList = [];
            $("input[name=order_chs]").each(function () { if (this.checked) { IdList.push(this.value); } });
            if (IdList.length <= 0) { layer.alert({ title: "温馨提示", msg: "请选择您要合并的订单项", icon: 3 }); return; }
            if (IdList.length < 2) { layer.alert({ title: "温馨提示", width: 320, msg: "至少选择两笔以上的订单才能合并订单", icon: 3 }); return; }
            var param = "nums=" + IdList.join("@")
            $.post("/OrderManagement/UrlEncrypt.html", { ParamList: param },
                function (data, textStatus) {
                    if (!jQuery.isEmptyObject(data)) {
                        var url = "/OrderManagement/MergeOrder.html?param=" + data;
                        var div = $("<div></div>").addClass("frame_wrap");
                        div.append('<iframe width="100%" height="40" scrolling="no" frameborder="0" allowtransparency="true" src="' + url + '"></iframe>');
                        $("body").append(div);
                        MyMaskLayer.Control.Show({ "Opacity": 40 });
                        var width = $(window).width();
                        var height = $(window).height();
                        var top = $(document).scrollTop();
                        div.css({ left: (width - div.width()) / 2, top: (height - div.height()) / 2 + top }).fadeIn();
                    }
                }, "text"
            );
        },
        ToBatchDeliver: function () {
            var base = this;
            if (Config.LogisId == 0) { layer.alert({ title: "温馨提示", width: 280, msg: "请选择您要批量发货的物流方式", icon: 3 }); return; }
            if (!(Config.LogisId == 38 || Config.LogisId == 37 || Config.LogisId == 36 || Config.LogisId == 35 || Config.LogisId == 33 || Config.LogisId == 30 || Config.LogisId == 28 || Config.LogisId == 29 || Config.LogisId == 32 || Config.LogisId == 14)) {
                layer.alert({ title: "温馨提示", width: 280, msg: "该物流暂时不支持自动联想单号", icon: 3 });
                return;
            }

            if (!(Config.StatusId == 4 || Config.StatusId == 5)) {
                layer.alert({ title: "温馨提示", width: 720, msg: "状态为‘买家已付款，等待卖家确认’或‘买家已付款，等待卖家发货’下的订单，才能批量打印发货", icon: 3 });
                return;
            }

            var IdList = [];
            $("input[name=order_chs]").each(function () { if (this.checked) { IdList.push(this.value); } });
            if (IdList.length <= 0) { layer.alert({ title: "温馨提示", width: 250, msg: "请选择您要批量操作的订单", icon: 3 }); return; }

            this.ShowMaskLayer();
            $.get("/OrderManagement/DeliverNum.html", { param: Config.LogisId },
                function (data) {
                    diaglog.attr({ "data-id": "8", "data-param": IdList.join('@') }).find(".dialogContainer-hd").html("批量发货管理").end().find("tbody").empty().append(data);
                    base.ShowDialog();
                }
            , "html");
        },
        ToBatchSender: function (state) {
            var base = this;
            if (Config.LogisId == 0) { layer.alert({ title: "温馨提示", width: 280, msg: "请选择您要打印订单的物流方式", icon: 3 }); return; }
            if (state) {
                if (!(Config.LogisId == 38 || Config.LogisId == 37 || Config.LogisId == 36 || Config.LogisId == 35 || Config.LogisId == 33 || Config.LogisId == 30 || Config.LogisId == 28 || Config.LogisId == 29 || Config.LogisId == 32 || Config.LogisId == 14 || Config.LogisId == 51 || Config.LogisId == 34)) {
                    layer.alert({ title: "温馨提示", width: 280, msg: "该物流暂时不支持自动联想单号", icon: 3 });
                    return;
                }

                if (!(Config.StatusId == 4 || Config.StatusId == 5)) {
                    layer.alert({ title: "温馨提示", width: 720, msg: "状态为‘买家已付款，等待卖家确认’或‘买家已付款，等待卖家发货’下的订单，才能批量打印发货", icon: 3 });
                    return;
                }
            }

            var IdList = [];
            $("input[name=order_chs]").each(function () { if (this.checked) { IdList.push(this.value); } });

            if (IdList.length <= 0) { layer.alert({ title: "温馨提示", width: 250, msg: "请选择您要批量操作的订单", icon: 3 }); return; }

            if (state && Config.LogisId != 38) {
                base.ShowMaskLayer();
                $.get("/OrderManagement/DeliverNum.html", { param: Config.LogisId },
                    function (data) {
                        diaglog.attr({ "data-id": "4", "data-param": IdList.join('@') }).find(".dialogContainer-hd").html("批量打印发货管理").end().find("tbody").empty().append(data);
                        base.ShowDialog();
                    }
                , "html");
            } else {
                this.ToPrintSender(IdList.join('@'), (state ? 1 : 0));
            }
        },
        ShowMaskLayer: function () {
            var div = $("div.PageOnLoad");
            var left = ($(window).width() - div.width()) / 2;
            var top = ($(window).height() - div.height()) / 2 + $(document).scrollTop();
            MyMaskLayer.Control.Show({ "Opacity": 40, "Element": "div.PageOnLoad" });
            div.css({ left: left + "px", top: top + "px" });
        },
        ShowDialog: function () {
            MyMaskLayer.Control.RemoveElement();
            var width = $(window).width();
            var height = $(window).height();
            var top = $(document).scrollTop();
            diaglog.css({ left: (width - diaglog.width()) / 2, top: (height - diaglog.height()) / 2 + top }).fadeIn(
                function () {
                    var rang_wrap = $("div.rang_wrap");
                    if (rang_wrap.length > 0) {
                        var nicesx = $("div.rang_wrap").niceScroll({ touchbehavior: false, cursorcolor: "#424242", cursoropacitymax: 0.6, cursorwidth: 4 });
                    }
                }
            );
        },
        HideDialog: function (state) {
            var base = this;
            if (state) {
                var id = parseInt(diaglog.attr("data-id"));
                var param = diaglog.attr("data-param");
                if (id == 1) {
                    var fid = $("input[name='detailFlag']:checked").val();
                    var txt = diaglog.find("textarea").val();
                    $.post("/OrderManagement/EDetail.html", { Number: param, fid: fid, txt: txt },
                        function (data) {
                            if (data.Status) {
                                if (TmpTable != null) {
                                    TmpTable.fadeOut(function () { $(this).remove(); });
                                }
                            }
                        }
                    );
                } else {
                    if (id == 2) {
                        var c_name = $.trim(diaglog.find("input[name=c_name]").val());
                        var c_phone = $.trim(diaglog.find("input[name=c_phone]").val());
                        var c_mobile = $.trim(diaglog.find("input[name=c_mobile]").val());
                        var c_code = $.trim(diaglog.find("input[name=c_code]").val());
                        var c_pro = $.trim(diaglog.find("input[name=c_pro]").val());
                        var c_city = $.trim(diaglog.find("input[name=c_city]").val());
                        var c_dis = $.trim(diaglog.find("input[name=c_dis]").val());
                        var c_addr = $.trim(diaglog.find("input[name=c_addr]").val());
                        if (jQuery.isEmptyObject(c_name)) { layer.alert({ title: "温馨提示", msg: "请输入收货人姓名", icon: 3 }); return; }
                        if (jQuery.isEmptyObject(c_phone) && jQuery.isEmptyObject(c_mobile)) { layer.alert({ title: "温馨提示", width: 280, msg: "收货人电话和手机必须填写一项", icon: 3 }); return; }
                        if (!jQuery.isEmptyObject(c_phone)) { if (!c_phone.CheckPhone()) { layer.alert({ title: "温馨提示", msg: "收货人电话格式输入错误", icon: 3 }); return; } }
                        if (!jQuery.isEmptyObject(c_mobile)) { if (!c_mobile.CheckMoblieNo()) { layer.alert({ title: "温馨提示", msg: "收货人手机格式输入错误", icon: 3 }); return; } }
                        if (!jQuery.isEmptyObject(c_code)) { if (!c_code.CheckPostCode()) { layer.alert({ title: "温馨提示", msg: "收货人邮编输入错误", icon: 3 }); return; } }
                        if (jQuery.isEmptyObject(c_pro)) { layer.alert({ title: "温馨提示", msg: "请输入收货人所在省", icon: 3 }); return; }
                        if (jQuery.isEmptyObject(c_city)) { layer.alert({ title: "温馨提示", msg: "请输入收货人所在市", icon: 3 }); return; }
                        if (jQuery.isEmptyObject(c_addr)) { layer.alert({ title: "温馨提示", msg: "请输入收货人地址", icon: 3 }); return; }
                        var CData = { OrdersNumber: param, Name: c_name, Phone: c_phone, Mobile: c_mobile, PostCode: c_code, Provice: c_pro, City: c_city, District: c_dis, ConsigneeAddress: c_addr };
                        $.post("/OrderManagement/Consignee.html", CData,
                            function (data) {
                                if (data.Status) {
                                    if (TmpTable != null) {
                                        TmpTable.fadeOut(function () { $(this).remove(); });
                                    }
                                }
                            }
                        );
                    } else {
                        if (id == 3) {
                            var lid = $.trim(diaglog.find("select").val());
                            if (lid == "0") { layer.alert({ title: "温馨提示", msg: "请选择物流", icon: 3 }); return; }
                            $.post("/OrderManagement/ShopConsignee.html", { Number: param, Lid: lid },
                                function (data) {
                                    if (data.Status) {
                                        if (TmpTable != null) {
                                            TmpTable.fadeOut(function () { $(this).remove(); });
                                        }
                                    }
                                }
                            );
                        } else {
                            if (id == 4 || id == 5 || id == 8) {
                                var tempObj = diaglog.find("input[name=initialNum]");
                                var reg = tempObj.attr("data-reg");
                                var num = $.trim(tempObj.val());
                                if (jQuery.isEmptyObject(num)) { layer.alert({ title: "温馨提示", msg: "请输入初始单号", icon: 3 }); return; }
                                if (!jQuery.isEmptyObject(reg)) {
                                    if (!new RegExp("(" + reg + ")").test(num)) { layer.alert({ title: "温馨提示", msg: "物流单号格式输入错误", icon: 3 }); return; }
                                }
                                if (id == 4) {
                                    base.ToPrintSender(param, 1, num);
                                } else {
                                    if (id == 5) {
                                        $.post("/OrderManagement/OrderSend.html", { ParamList: "" + param + "," + num + "" },
                                            function (data) {
                                                if (!data.Status) {
                                                    layer.alert({ title: "温馨提示", width: 300, msg: "订单发货失败,请刷新后重试..", icon: 3 });
                                                }
                                                if (TmpTable != null) {
                                                    TmpTable.fadeOut(function () { $(this).remove(); });
                                                }
                                            }
                                        );
                                    } else {
                                        if (id == 8) {
                                            base.BatchDeliver(param, num);
                                        }
                                    }
                                }
                            } else {
                                if (id == 7) {
                                    var lid = $.trim(diaglog.find("select").val());
                                    if (lid == "0") { layer.alert({ title: "温馨提示", msg: "请选择物流", icon: 3 }); return; }
                                    $.post("/OrderManagement/BatchLogistics.html", { IdList: param, lid: lid },
                                        function (data) {
                                            if (!data.Status) {
                                                layer.alert({ title: "温馨提示", width: 300, msg: "修改物流失败,请刷新后重试..", icon: 3 });
                                            }
                                            window.location.href = window.location.href;
                                        }
                                    );
                                } else {
                                    if (id == 9) {
                                        var ud_list = $.trim(diaglog.find("input[name=ud_list]").val());
                                        if (jQuery.isEmptyObject(ud_list)) { layer.alert({ title: "温馨提示", msg: "请输入订单编码", icon: 3 }); return; }
                                        $(param).hide().next().hide().next().show();
                                        $.post("/OrderManagement/UserDown.html", { IdList: ud_list },
                                            function (data) {
                                                window.location.href = window.location.href;
                                            }
                                        )
                                    }
                                }
                            }
                        }
                    }
                }
            }

            diaglog.fadeOut();
            $("div.nicescroll-rails").remove();
            MyMaskLayer.Control.Remove();
        },
        BatchDeliver: function (numlist, num) {
            var param = "nums=" + numlist + ",id=" + Config.LogisId + ",num=" + num;
            $.post("/OrderManagement/UrlEncrypt.html", { ParamList: param },
                function (data, textStatus) {
                    if (!jQuery.isEmptyObject(data)) {
                        var url = "/OrderManagement/BatchDeliver.html?param=" + data;
                        var div = $("<div></div>").addClass("frame_wrap");
                        div.append('<iframe width="100%" height="295" scrolling="no" frameborder="0" allowtransparency="true" src="' + url + '"></iframe>');
                        $("body").append(div);
                        MyMaskLayer.Control.Show({ "Opacity": 40 });
                        var width = $(window).width();
                        var height = $(window).height();
                        var top = $(document).scrollTop();
                        div.css({ left: (width - div.width()) / 2, top: (height - div.height()) / 2 + top }).fadeIn();
                    }
                }, "text"
            );
        },
        ToPrintSender: function (numlist, state, num) {
            var param = "";
            if (num) {
                param = "nums=" + numlist + ",state=" + state + ",id=" + Config.LogisId + ",num=" + num;
            } else {
                param = "nums=" + numlist + ",state=" + state + ",id=" + Config.LogisId;
            }
            $.post("/OrderManagement/UrlEncrypt.html", { ParamList: param },
                function (data, textStatus) {
                    if (!jQuery.isEmptyObject(data)) {
                        var url = "/OrderManagement/PrintSender.html?param=" + data;
                        var div = $("<div></div>").addClass("frame_wrap");
                        div.append('<iframe width="100%" height="40" scrolling="no" frameborder="0" allowtransparency="true" src="' + url + '"></iframe>');
                        $("body").append(div);
                        MyMaskLayer.Control.Show({ "Opacity": 40 });
                        var width = $(window).width();
                        var height = $(window).height();
                        var top = $(document).scrollTop();
                        div.css({ left: (width - div.width()) / 2, top: (height - div.height()) / 2 + top }).fadeIn();
                    }
                }, "text"
            );
        },
        ToBatchLogistics: function (obj) {
            var base = this;
            var id = $(obj).attr("data-id");
            var IdList = [];
            $("input[name=order_chs]").each(function () { if (this.checked) { IdList.push(this.value); } });
            if (IdList.length <= 0) { layer.alert({ title: "温馨提示", width: 250, msg: "请选择您要批量操作的订单", icon: 3 }); return; }

            this.ShowMaskLayer();
            $.get("/OrderManagement/BatchLogistics.html", { param: id },
                function (data) {
                    diaglog.attr({ "data-id": "7", "data-param": IdList.join(',') }).find(".dialogContainer-hd").html("批量设置物流").end().find("tbody").empty().append(data);
                    base.ShowDialog();
                }
            , "html");
        },  
        SyncLoad: function () {
            if (Config.PageIndex >= Config.MaxPage) {
                $(".pageMoreWrap").hide();
                return;
            }
            Config.PageIndex += 1;
            this.InitData();
        },
        ToStatus: function (obj) {
            Config.PageIndex = 1;
            $(obj).parent().siblings().find("a").removeClass("current").end().addClass("current");
            var rels = $(obj).attr("rel").split(',');

            switch (parseInt(rels[0])) {
                case 0:
                    Config.ShopId = parseInt(rels[1]);
                    break;
                case 1:
                    Config.LogisId = parseInt(rels[1]);
                    break;
                case 2:
                    Config.StatusId = parseInt(rels[1]);
                    break;
                case 3:
                    Config.CateId = parseInt(rels[1]);
                    break;
                case 4:
                    Config.RefundId = parseInt(rels[1]);
                    break;
                case 5:
                    Config.FreeId = parseInt(rels[1]);
                    break;
                case 6:
                    Config.FlagId = parseInt(rels[1]);
                    break;
                case 7:
                    Config.InvoiceId = parseInt(rels[1]);
                    break;
            }

            this.Jump();
        },
        ToSearch: function () {
            Config.PageIndex = 1;
            var UserNick = $("input[name=UserNick]");
            Config.UserNick = $.trim(UserNick.val());
            $.data(UserNick, "UserNick", Config.UserNick);

            var OutNumber = $("input[name=OutNumber]");
            Config.OutNumber = $.trim(OutNumber.val());
            $.data(OutNumber, "OutNumber", Config.OutNumber);

            var Name = $("input[name=Name]");
            Config.Name = $.trim(Name.val());
            $.data(Name, "Name", Config.Name);

            var CName = $("input[name=CName]");
            Config.CName = $.trim(CName.val());
            $.data(CName, "CName", Config.CName);

            var City = $("input[name=City]");
            Config.City = $.trim(City.val());
            $.data(City, "City", Config.City);

            var District = $("input[name=District]");
            Config.District = $.trim(District.val());
            $.data(District, "District", Config.District);

            var Tel = $("input[name=Tel]");
            Config.Tel = $.trim(Tel.val());
            $.data(Tel, "Tel", Config.Tel);

            var Mobile = $("input[name=Mobile]");
            Config.Mobile = $.trim(Mobile.val());
            $.data(Mobile, "Mobile", Config.Mobile);

            var Addr = $("input[name=Addr]");
            Config.Addr = $.trim(Addr.val());
            $.data(Addr, "Addr", Config.Addr);

            var Province = $("input[name=Province]");
            Config.Province = $.trim(Province.val());
            $.data(Province, "Province", Config.Province);

            var Msg = $("input[name=Msg]");
            Config.Msg = $.trim(Msg.val());
            $.data(Msg, "Msg", Config.Msg);

            var SDetail = $("input[name=SDetail]");
            Config.SDetail = $.trim(SDetail.val());
            $.data(SDetail, "SDetail", Config.SDetail);

            var ODetail = $("input[name=ODetail]");
            Config.ODetail = $.trim(ODetail.val());
            $.data(ODetail, "ODetail", Config.ODetail);

            var CStart = $("input[name=CStart]");
            Config.CStart = $.trim(CStart.val());
            $.data(CStart, "CStart", Config.CStart);

            var CEnd = $("input[name=CEnd]");
            Config.CEnd = $.trim(CEnd.val());
            $.data(CEnd, "CEnd", Config.CEnd);

            var PStart = $("input[name=PStart]");
            Config.PStart = $.trim(PStart.val());
            $.data(PStart, "PStart", Config.PStart);

            var PEnd = $("input[name=PEnd]");
            Config.PEnd = $.trim(PEnd.val());
            $.data(PEnd, "PEnd", Config.PEnd);

            var IStart = $("input[name=IStart]");
            Config.IStart = $.trim(IStart.val());
            $.data(IStart, "IStart", Config.IStart);

            var IEnd = $("input[name=IEnd]");
            Config.IEnd = $.trim(IEnd.val());
            $.data(IEnd, "IEnd", Config.IEnd);

            //var Province = $("input[name=Province]");
            //Config.Province = $.trim(Province.val());
            //$.data(Province, "Province", Config.Province);
            //Config.OutNumber = $.trim($("input[name=OutNumber]").val());
            //Config.Code = $.trim($("input[name=Code]").val());
            //Config.Name = $.trim($("input[name=Name]").val());
            //Config.CName = $.trim($("input[name=CName]").val());
            //Config.Province = $.trim($("input[name=Province]").val());
            //Config.City = $.trim($("input[name=City]").val());
            //Config.District = $.trim($("input[name=District]").val());
            //Config.Tel = $.trim($("input[name=Tel]").val());
            //Config.Mobile = $.trim($("input[name=Mobile]").val());
            //Config.Addr = $.trim($("input[name=Addr]").val());
            //Config.Msg = $.trim($("input[name=Msg]").val());
            //Config.SDetail = $.trim($("input[name=SDetail]").val());
            //Config.ODetail = $.trim($("input[name=ODetail]").val());
            //Config.CStart = $.trim($("input[name=CStart]").val());
            //Config.CEnd = $.trim($("input[name=CEnd]").val());
            //Config.PStart = $.trim($("input[name=PStart]").val());
            //Config.PEnd = $.trim($("input[name=PEnd]").val());
            //Config.IStart = $.trim($("input[name=IStart]").val());
            //Config.IEnd = $.trim($("input[name=IEnd]").val());
            //$.data(Config, "Config", Config);

            this.Jump();
        },
        ToSort: function (obj) {
            var index = $(".sortbar li a").index(obj) * 2;
            if ($(obj).hasClass("sortcurrent")) {
                if (!$(obj).find("i").hasClass("down")) {
                    index = index + 1;
                }
            }
            Config.SortId = index;
            Config.PageIndex = 1;
            this.Jump();
        },
        MosaicUrl: function () {
            var Url = [];
            if (Config.PageIndex != 0) { Url.push("PageIndex=" + Config.PageIndex); }
            if (Config.ShopId != 0) { Url.push("ShopId=" + Config.ShopId); }
            if (Config.LogisId != 0) { Url.push("LogisId=" + Config.LogisId); }
            if (Config.StatusId != 0) { Url.push("StatusId=" + Config.StatusId); }
            if (Config.CateId != 0) { Url.push("CateId=" + Config.CateId); }
            if (Config.RefundId != 0) { Url.push("RefundId=" + Config.RefundId); }
            if (Config.FreeId != 0) { Url.push("FreeId=" + Config.FreeId); }
            if (Config.FlagId != 0) { Url.push("FlagId=" + Config.FlagId); }
            if (Config.SortId != 0) { Url.push("SortId=" + Config.SortId); }
            if (Config.PrintId != 0) { Url.push("PrintId=" + Config.PrintId); }
            if (Config.InvoiceId != 0) { Url.push("InvoiceId=" + Config.InvoiceId); }
            if (!jQuery.isEmptyObject(Config.UserNick)) { Url.push("UserNick=" + Config.UserNick); }
            if (!jQuery.isEmptyObject(Config.OutNumber)) { Url.push("OutNumber=" + Config.OutNumber); }
            if (!jQuery.isEmptyObject(Config.Code)) { Url.push("Code=" + Config.Code); }
            if (!jQuery.isEmptyObject(Config.Name)) { Url.push("Name=" + Config.Name); }
            if (!jQuery.isEmptyObject(Config.CName)) { Url.push("CName=" + Config.CName); }
            if (!jQuery.isEmptyObject(Config.Province)) { Url.push("Province=" + Config.Province); }
            if (!jQuery.isEmptyObject(Config.City)) { Url.push("City=" + Config.City); }
            if (!jQuery.isEmptyObject(Config.District)) { Url.push("District=" + Config.District); }
            if (!jQuery.isEmptyObject(Config.Tel)) { Url.push("Tel=" + Config.Tel); }
            if (!jQuery.isEmptyObject(Config.Mobile)) { Url.push("Mobile=" + Config.Mobile); }
            if (!jQuery.isEmptyObject(Config.Addr)) { Url.push("Addr=" + Config.Addr); }
            if (!jQuery.isEmptyObject(Config.Msg)) { Url.push("Msg=" + Config.Msg); }
            if (!jQuery.isEmptyObject(Config.SDetail)) { Url.push("SDetail=" + Config.SDetail); }
            if (!jQuery.isEmptyObject(Config.ODetail)) { Url.push("ODetail=" + Config.ODetail); }
            if (!jQuery.isEmptyObject(Config.CStart) && Config.CStart.CheckDateTime()) { Url.push("CStart=" + Config.CStart); }
            if (!jQuery.isEmptyObject(Config.CEnd) && Config.CEnd.CheckDateTime()) { Url.push("CEnd=" + Config.CEnd); }
            if (!jQuery.isEmptyObject(Config.PStart) && Config.PStart.CheckDateTime()) { Url.push("PStart=" + Config.PStart); }
            if (!jQuery.isEmptyObject(Config.PEnd) && Config.PEnd.CheckDateTime()) { Url.push("PEnd=" + Config.PEnd); }
            if (!jQuery.isEmptyObject(Config.IStart) && Config.IStart.CheckDateTime()) { Url.push("IStart=" + Config.IStart); }
            if (!jQuery.isEmptyObject(Config.IEnd) && Config.IEnd.CheckDateTime()) { Url.push("IEnd=" + Config.IEnd); }

            return Url.join(',');
        },
        Jump: function () {

            var url = this.MosaicUrl();
            $.post("/OrderManagement/UrlEncrypt.html", { ParamList: url },
            function (data, textStatus) {
                if (!jQuery.isEmptyObject(data)) {
                    window.location.href = "/OrderManagement/OrderIndex.html?param=" + data;
                }
            }, "text"
            );
        },
        //防止事件冒泡
        stopPropagation: function (e) {
            e = e || window.event;
            if (e.stopPropagation) { //W3C阻止冒泡方法
                e.stopPropagation();
            } else {
                e.cancelBubble = true; //IE阻止冒泡方法
            }
        }
    };
}

$(document).ready(
    function () {
        new Order().Page.Init();
    }
);