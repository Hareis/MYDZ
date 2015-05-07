$(function () {

    //选择标签
    selecttarget();
    //加载日期控件
    Onloadlaydate();
    //是否开启全店
    isquandian();
    //初始化提交表单
    Initsubmitfrom();
    //保存活动
    SaveActivity();
    //创建活动
    CreateActivity();
    changecheckbox();
    //修改运费
    changeyunfei();
    //选择赠品
    chooicsGoods();
    //是否开启会员
    ishuiyuan();
    //删除商品
    deletegift();
    //选择不包邮地区
    choiceNotfreepost();


    // var c =10.2/1 * 100;
    // alert(c.toFixed(0));

    var iste = false;
    var formObj;
    //加载日期控件
    function Onloadlaydate() {
        options = {
            elem: '#datepicker-start', //需显示日期的元素选择器
            event: 'click', //触发事件
            format: 'YYYY-MM-DD hh:mm:ss', //日期格式
            istime: true, //是否开启时间选择
            isclear: true, //是否显示清空
            istoday: true, //是否显示今天
            issure: true, //是否显示确认
            festival: false, //是否显示节日
            min: '1900-01-01 00:00:00', //最小日期
            max: '2099-12-31 23:59:59', //最大日期
            start: laydate.now(),    //开始日期
            fixed: false, //是否固定在可视区域
            zIndex: 999, //css z-index
            choose: function (dates) { //选择好日期的回调
            }
        };
        laydate(options);
        options.elem = "#datepicker-end";
        laydate(options);
        laydate.skin('blue');
    }

    // 选择项
    function selecttarget() {
        $(".SelectItem a").click(function () {
            $("input[name=ShopMember]").empty().val($(this).parent().attr("data"));
            $(this).parent().siblings().each(function (i, item) {
                if ($(this).hasClass("current")) {
                    var html1 = $(item).text();
                    $(item).removeClass("current").html("<a href=\"javascript:void();\">" + html1 + "</a>");
                    return false;
                }
            });
            var html2 = $(this).text();
            JudgingTypes(this);
            $(this).parent().html("<span>" + html2 + "</span>").addClass("current").bind("click", function () {
                selecttarget();
            });
            return false;
        });
    }

    //判断类型
    function JudgingTypes(item) {
        var att = $(item).parent().parent().attr("data");
        switch (att) {
            case "target":
                selectmarkingtarget(item);
                break;
            case "day":
                selectmarkingday(item);
                break;
            default:
                break;
        }
    }

    //选择促销标签
    function selectmarkingtarget(item) {
        var temp = $(item);
        temp.parents(".table_item").eq(0).find("input[name=Name]").val(temp.text());
    }

    //选择促销日期间隔
    function selectmarkingday(item) {
        var temp = new Date();
        var temp1 = temp;

        //将日期类型转换为指定的格式
        var strtdate = DatetimeFormat(temp1);

        //为结束日期加上选择的间隔 例：间隔3天
        temp.setDate(temp.getDate() + parseInt($(item).parent().attr("data")));

        //将日期类型转换为指定的格式
        var enddate = DatetimeFormat(temp);

        //获取传进来的对象
        var tep = $(item);
        var parents = tep.parents(".table_item").eq(0);

        //下面是为文本框赋值
        parents.find("input[name=StartTime]").val(strtdate);
        parents.next().eq(0).find("input[name=EndTime]").val(enddate);
    }

    //是否开启全店
    function isquandian() {
        $(".kaiqiquandian label").click(function () {
            if (!$(this).hasClass("checked")) {
                $(this).addClass("checked").siblings().removeClass("checked").find("input[name=ParticipateRange]").eq(0).attr("checked", false);
                $("#CreateActivity").toggle();
                $("#SaveActivity").toggle();
                if ($(this).find("input[name=ParticipateRange]").val() == 0) {
                    $(".btn_wrap-div2").empty();
                }
            }
        });
    }
    //优惠方式
    function changecheckbox() {
        $(".way label , #youhuitiaojian label , #huodongleixing label").click(function () {
            if (!$(this).hasClass("checked")) {
                $(this).addClass("checked").siblings().removeClass("checked");
                $(this).find("input").val($(this).hasClass("checked"));
                $(this).siblings().find("input").val(!$(this).hasClass("checked"));
            }
            if ($(this).parent()[0] == $("#huodongleixing")[0]) {
                $("#huodongleixing").find("input").each(function (i, item) {
                    if ($(item).val() == "true") {
                        $("#huodongleixing").find("input[name=Type]").eq(0).val($(item).attr("data"));
                    }
                })
            }
            return false;
        });
    }
    //商品运费
    function changeyunfei() {
        $(".yunfei label").click(function () {
            var IsFreePost = $(this).parent().find("input[name=IsFreePost]").eq(0);
            if ($(this).hasClass("checked")) {
                $(this).addClass("checked").find("input[name=yunfei]").eq(0).attr("checked", true);
                $(this).siblings().removeClass("checked").find("input[name=yunfei]").eq(0).attr("checked", false);
                if ($(this).find("input[name=yunfei]").eq(0).hasClass("IsFreePost")) {
                    IsFreePost.val(true);
                } else {
                    IsFreePost.val(false);
                }
            } else {
                IsFreePost.val(false);
            }
        });
    }
    //是否开启会员
    function ishuiyuan() {
        $(".huiyuan label,.tiaojian-checkboc-label label").click(function () {
            var IsShopMember = $(this).find("input");
            if ($(this).hasClass("checked")) {
                IsShopMember.val(true);
            } else {
                IsShopMember.val(false);
            }
        });
    }
    function format(item) {
        return item.tag;
    }
    //加载运费模板
    function onloadyunfei() {
        $.get("/Marketing/ReturnYunfei.html", {}, function (data) {
            if (data != null) {
                var str = "";
                $.each(data, function (i, item) {
                    str += "<option value='" + item["TemplateId"] + "'>" + item["Name"] + "</option>"
                })
                $("#YFMB").select2("destroy");
                $("#YFMB").empty().append(str).select2();
            }
        });
    }

    function choiceNotfreepost() {
        $("#choicearea").click(function () {
            PopWindow.Controller.Init({ type: "loading", opacity: 0 });
            var temp = PopWindow.Controller.Init({
                type: "window",
                opacity: 0,
                width: 740,
                height: 555,
                url: "/Marketing/excludearea.html",
                title: "选择非包邮地区",
                Complete: function (data) {
                    if (data.result !== undefined && data.result !== null) {
                        $("#itemcount").html(data.count);
                        $("input[name=ExcludeArea]").empty().val(data);
                    }
                }
            });
        });
    }
    //选择赠品
    function chooicsGoods() {
        $(".chooicgoods").click(function () {
            var item = $(this);
            PopWindow.Controller.Init({ type: "loading", opacity: 0 });
            var temp = PopWindow.Controller.Init({
                type: "window",
                opacity: 0,
                width: 728,
                height: 555,
                url: "/Marketing/NullPageTemple.html?Iscaozuo=true",
                title: "选择赠品",
                Complete: function (data) {
                    if (data.goodsId !== undefined) {
                        var parentNext = item.parents(".table_item").next();
                        parentNext.find("input[name=GiftId]").val(data.goodsId);
                        parentNext.find("input[name=GiftUrl]").val("http://item.taobao.com/item.html?id=" + data.goodsId);
                        var temp = data.GoodOuterId === undefined ? "错误数据！" : data.GoodOuterId;
                        parentNext.find(".selected_wrap").empty().append("<li><a href='javascript:void(0);'><span><font>" + temp + "</font></span><i></i></a></li>")
                    }
                }
            });
        });
    }
    //删除赠品
    function deletegift() {
        $(".selected_wrap").delegate("li i", "click", function () {
            $(this).parent().parent().remove();
        });
    }


    function CreateActivity() {
        $("#CreateActivity").click(function () {
            iste = false;
            $("#QueryCriteria").submit();
        });

        $(".btn_wrap-div2").delegate("input[name=createactivitityinput]", "click", function () {
            $("#CreateActivity").trigger("click");
        })
    }

    function SaveActivity() {
        $("#SaveActivity").click(function () {
            iste = true;
            $("#QueryCriteria").submit();
        });
    }

    //初始化表单
    function Initsubmitfrom() {
        formObj = Validform.Controller.Init({
            form: "#QueryCriteria",
            beforeSubmit: function () {
                if (iste === true) {
                    $(".btn_wrap-div2").empty().load("/Marketing/AddActivityRange.html?Ischeckbox=true", {}, function (data) {
                    });
                    return false;
                } else {
                    PopWindow.Controller.Init({ type: "loading", opacity: 0 });
                }
            }
        }).config({
            ajaxPost: true,
            callback: function (data) {
                PopWindow.Controller.Clear();
            }
        });
    }

    //格式化为 yyyy-MM-dd hh:mm:ss
    function DatetimeFormat(date) {
        var d = date instanceof Date && date !== null ? date : new Date();
        var vYear = d.getFullYear()
        var vMon = d.getMonth() + 1
        var vDay = d.getDate();
        var h = d.getHours();
        var m = d.getMinutes();
        var se = 0; //  d.getSeconds();
        return vYear + "-" + (vMon < 10 ? "0" + vMon : vMon) + "-" + (vDay < 10 ? "0" + vDay : vDay) + " " + (h < 10 ? "0" + h : h) + ":" + (m < 10 ? "0" + m : m) + ":" + (se < 10 ? "0" + se : se);
    }

});