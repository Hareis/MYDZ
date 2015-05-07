$(function () {

    var Search = {};
    var NowPageIndex = 1;
    var GoodsTotalNum = 0;
    var URL = "/Marketing/LoadProduct.html";

    //加载商品数据
    OnloadGoods();
    //查找商品数据
    SearchProduct();
    //单选
   // ReturnGoodsId();
    //多选
   // ReturnGoodsIds();
    //操作商品
    chooisegood();


    //设置
    function loadSet() {
        //隐藏 全选栏
        var Ischeckbox = $("#IscheckboxB").val();
        var Iscaozuo = $("#IscaozuoB").val();
        if (Ischeckbox == "true") {
        } else {
            $(".Ischeckbox").hide();
        }
        //隐藏 操作栏
        if (Iscaozuo == "true") {
        } else {
            $(".Iscaozuo").hide();
        }
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

    //加载新的页码 （例：页码1--页码2 跳转）
    function ChangePageNo(index) {
        Search.PageNo = index;
        Search.PageSize = 10;
        NowPageIndex = index;
        OnloadGoods();
    }

    //页面初始化加载信息 
    function OnloadGoods() {
        $("#data_table-div-goods").empty().load(URL, Search, function (data) {
            Loadpaging();
            LoadTotalNum();
            //加载设置
            loadSet();
        });
    }

    //加载商品总数 
    function LoadTotalNum() {
        $(".selected").find(".TotalNumOnsales").html("(" + GoodsTotalNum + ")");
        $(".selected").siblings().find(".TotalNumOnsales").empty();
    }

    //查找商品
    function SearchProduct() {
        $("input[name=searchbutton]").click(function () {
            Search.Q = $("input[name=input-text-title]").val();
            Search.OuterId = $("input[name=input-text-outerid]").val();
            OnloadGoods();
        });
    }

    //选择商品
    function chooisegood() {
        $("#data_table-div-goods").delegate(".Choice", "click", function () {
            var chooiceGoodsdata = {};
            chooiceGoodsdata.goodsId = $(this).parents("tr").find("input[name=CheckboxGoods]").val();
            chooiceGoodsdata.GoodOuterId = $(this).parents("tr").find("input[name=CheckboxGoods]").attr("data-out-id");
            window.parent.PopWindow.Controller.Clear(chooiceGoodsdata);
        });
    }
  /*
    //单选
    function ReturnGoodsId() {
        $("#data_table-div-goods").delegate("input[name=CheckboxGoods]", "change", function () {
            var parent = $(this).parent().parent();
            $(this).eq(0).attr("checked", parent.hasClass("checked") ? false : true);
        });

    }
    //全选反选
    function ReturnGoodsIds() {
        $("#data_table-div-goods").delegate("input[name=chk_all]", "change", function () {
            $("input[name=CheckboxGoods]").each(function (i, item) {
                //var parent = $(this).parent().parent();
                if ($(item).attr("checked") == "checked")
                    $(this).attr("checked", false);
                else
                    $(this).attr("checked", true);
            });
        });
    }*/

});