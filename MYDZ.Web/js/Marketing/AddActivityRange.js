$(function () {
    var Search = {};
    var NowPageIndex = 1;
    var GoodsTotalNum = null;
    var URL = "/Marketing/ChoiceGoods.html?"; //?Ischeckbox=true

    initpage();
    bingselect2();
    returnchecked();
    changestate();

    //初始化页面
    function initpage() {
        Sendedinfo();
        OnloadGoods(URL);
    }

    //获取从URL获得的设置
    function Sendedinfo() {
        var Ischeckbox = $("#IscheckboxA").val();
        var Iscaozuo = $("#IscaozuoA").val();
        URL += "Ischeckbox=" + Ischeckbox + "&Iscaozuo=" + Iscaozuo;
    }

    //页面初始化加载信息 
    function OnloadGoods() {
        $("#data_table-div").empty().load(URL, Search, function () {
        });
    }
    //返回选中商品
    function returnchecked() {
        $("#data_table-div").delegate("input[name=CheckboxGoods]", "change", function () {
           var parent = $(this).parent().parent();
            $(this).eq(0).attr("checked", parent.hasClass("checked") ? false : true);
        });

        var arry = [];
        $("#data_table-div").delegate("input[type='checkbox']", "change", function () {
            var name = $(this).attr("name");
            if (name === "chk_all") {
                $("input[name=CheckboxGoods]").each(function (i) {
                    var parent = $(this).parent().parent();
                    parent.toggleClass("checked");
                    this.checked = !this.checked;
                    Choose(this);
                });
            } else {
                Choose(this);
            }
           // Choose(this);
            adddata(arry);
        });

        function Choose(obj) {
            var id = obj.value;
            if (obj.checked) {
                arry.push({ id: id, text: $(obj).attr("data-out-id") });
            } else {
                arry = $.grep(arry, function (n, j) {
                    return n.id !== id;
                });
            }
        }
    }

    function adddata(arry) {

        $("#YXSP").select2("val", "");
        $("#YXSP").select2("data", arry);
    }

    //创建活动
    function createavtivitity() {
        $(".createactivitity").click(function () {
            $.post("/Marketing/AddActivityRange.html", { IdList: $("#YXSP").val(), ParticipateRange: $("input[name=canyu]").val() }, function (data) {

            })
        });
    }

    //单选按钮 参与范围
    function changestate() {
        $("input[name=canyu]").click(function () {
            var parent = $(this).parent().parent();
            parent.siblings().eq(0).toggleClass("checked");
            parent.eq(0).toggleClass("checked");
            $(this).attr("checked", parent.hasClass("checked"));
        });
    }


    //绑定select2 控件
    function bingselect2() {
        $("#YXSP").select2({
            multiple: true,
            maximumInputLength: 50,
            data: [],
            initSelection: function (element, callback) {
                var data = [];
                $(element.val().split(",")).each(function () {
                    data.push({ id: this, text: this });
                });
                callback(data);
            }
        });
    }

    //创建搜索项
    function createSearchChoice(term, data) {
        if ($(data).filter(function () { return this.text.localeCompare(term) === 0; }).length === 0) {
            return { id: term, text: term };
        }
    }

    //加载商品总数 
    function LoadTotalNum() {
        $(".selected").find(".TotalNumOnsales").html("(" + GoodsTotalNum + ")");
        $(".selected").siblings().find(".TotalNumOnsales").html("");
    }
}); 