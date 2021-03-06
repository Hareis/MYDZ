﻿$(function () {


    /*------------------------------------ 页面初始化注册方法-------------------------------------------------*/
    // initpage();
    ChangeGoodStatus();
    SelectAllCheckBox();
    Searchstr();
    if ($("input[name=ErrorMsg]").val() !== "" && $("input[name=ErrorMsg]").val() !== null && $("input[name=ErrorMsg]").val() !== undefined) {
        alert($("input[name=ErrorMsg]").val());
    }
    /*--------------------------------------------------------------------------------------------------------*/

    var Search = {
    };
    var NowPageIndex = 1;
    var GoodsTotalNum = null;
    function initpage() {
        var URL = "/OrderManagement/BacklogOrders.html";
        OnloadGoods(URL);
    }

    //页面初始化加载信息
    function OnloadGoods(URL) {
        ChecknowGoodsState();
        $(".table_wrap").empty().load(URL, Search, function () {

        });
    }
    function hoverShow() {
        $(".table_wrap").delegate(".data_table_item", "mouseover", function () {
            $(this).find(".editdiv").each(
                function (i, item) {
                    var states = $(item).find(".save").is(":hidden");
                    if (states == true || states === undefined) {
                        $(item).find(".edita").css("visibility", "visible");
                    } else {

                    }
                });
        });
        $(".table_wrap").delegate(".data_table_item", "mouseout", function () {
            $(this).find(".editdiv").each(
                function (i, item) {
                    $(item).find(".edita").css("visibility", "hidden");
                }
            );
        });
    }
    //查找订单
    function Searchstr() {
        $('button[name=Search]').click(function () {
            PopWindow.Controller.Init({ type: "loading", opacity: 0 });
            Search = {};
            Search.Tid = $('.btn_wrap').find("input[name=Tid]").val();
            Search.StartCreated = $('.btn_wrap').find("input[name=StartCreated]").val();
            Search.EndCreated = $('.btn_wrap').find("input[name=EndCreated]").val();
            Search.BuyerNick = $('.btn_wrap').find("input[name=BuyerNick]").val();
            Search.PostType = "Query";
            var URL = "/OrderManagement/BacklogOrders.html";
            OnloadGoods(URL);
            PopWindow.Controller.Clear();
        });

    }


    //初始化表单
    function Initsubmitfrom() {
        var demo1 = Validform.Controller.Init({
            form: "#QueryCriteria",
            beforeSubmit: function () {
                PopWindow.Controller.Init({ type: "loading", opacity: 0 });
                Search = {};
                Search.Tid = $('.btn_wrap').find("input[name=Tid]").val();
                Search.StartCreated = $('.btn_wrap').find("input[name=StartCreated]").val();
                Search.EndCreated = $('.btn_wrap').find("input[name=EndCreated]").val();
                Search.BuyerNick = $('.btn_wrap').find("input[name=BuyerNick]").val();
                var URL = "/OrderManagement/BacklogOrders.html";
                OnloadGoods(URL);

            }
        }).config({
            ajaxPost: true,
            callback: function (data) {
                PopWindow.Controller.Clear();
            }
        });
    }

    // 初始化分页控件
    function Loadpaging() {
        PageConfig.Page = function (index) {
            ChangePageNo(index);
        }
        $(".page_box").unbind("click");
        PageConfig.PageIndex = NowPageIndex;
        $(".page_box").Pager(PageConfig);
        GoodsTotalNum = PageConfig.MaxRowNumber;
    }

    //加载商品总数
    function LoadTotalNum() {
        $(".selected").find(".TotalNumOnsales").html("(" + GoodsTotalNum + ")");
        $(".selected").siblings().find(".TotalNumOnsales").html("");
    }

    //检查当前商品状态
    function ChecknowGoodsState() {
        $('.tab .GoodStatus').each(function (i, item) {
            if ($(item).hasClass('selected')) {
                var values = $('input[name=HasShowcase]').eq(0).val();
                //Search.HasShowcase = values;
            }
        });
    }
    //加载新的页码 （例：页码1--页码2 跳转）
    function ChangePageNo(index) {
        Search.PageNo = index;
        Search.PageSize = 10;
        var URL = "/Merchandise/SHowGoodsOnsales.html";
        NowPageIndex = index;
        OnloadGoods(URL);
    }

    //更换商品显示状态
    function ChangeGoodStatus() {
        $('.tab .TradeStatus').click(function () {
            var type = $(this).attr("data");
            if (!$(this).hasClass('selected')) {
                $(this).siblings().removeClass('selected');
                $(this).addClass('selected');
            }
            $('input[name=Status]').eq(0).val(type);
            $("#table_wrap_child").empty().load("/OrderManagement/BacklogOrders.html" + " #table_wrap_child>*", { PostType: 'Change', Status: type }, function () {
                Loadcolocrtip();
                Ordermark();
            });
        });
    }

    //全选和全不选
    function SelectAllCheckBox() {
        $('input[name=chk_all]').change(function () {
            var parent = $(this).parent().parent();
            if (parent.hasClass('checked')) {
                $(this).attr("checked", false);
                ChangeGoodsId(false);
            } else {
                $(this).attr("checked", true);
                ChangeGoodsId(true);
            }
            RetunrGoodsId();
        });
    }

    //更改商品选择框状态
    function ChangeGoodsId(state) {
        $('.Trade-detail-thead-th').each(function (i, item) {
            var parent = $(item).find('input[name=order_checkbox]').eq(0).parent().parent();
            if (state == false) {
                parent.removeClass('checked');
            } else {
                parent.addClass('checked');
            }
        });
    }

    //返回选中的商品的ID（数组）
    function RetunrGoodsId() {
        var checkedList = [];
        $('table input[name=CheckboxGoods]').each(function (i, item) {
            var parent = $(item).parent().parent();
            if (parent.hasClass('checked')) {
                var goodsid = $(item).parent().parent().find("input[name=GoodsId]").eq(0).val();
                checkedList.push(goodsid);
            }
        });
        $('input[name=ListGoodId]').val(checkedList.toLocaleString());
        return checkedList;
    }

    //返回选中的商品外部ID（数组）
    function RetunrGoodsouterId() {
        var checkedList = [];
        $('table input[name=CheckboxGoods]').each(function (i, item) {
            var parent = $(item).parent().parent();
            if (parent.hasClass('checked')) {
                var goodsid = $(parent).parent().parent().find(".outerGoodsID").eq(0).html();
                checkedList.push(goodsid);
            }
        });
        return checkedList;
    }



});

