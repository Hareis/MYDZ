var PopWindow = PopWindow || {};

PopWindow.Controller = (function () {
    var fun = null;

    function Init(Config) {
        Config = $.extend({
            type: "prompt", //弹出窗口类型,prompt:提示,success:成功,error:错误,loading:加载,html:Html代码,window:页面,confirm:询问
            prefix: "pop_", //前缀
            hideMode: "auto", //隐藏方式 auto:自动隐藏,click:点击隐藏
            autoTime: 2000, //自动隐藏的时间，以毫秒为单位
            mask: true, //是否显示全屏遮罩层
            background: "#000000", //遮罩层背景颜色
            opacity: 0.4, //遮罩层透明度
            width: 698, //宽度
            height: 460, //高度
            title: "", //标题
            url: "", //iframe地址
            html: "", //html内容
            Complete: function () { } //完成回调函数
        }, Config || {});

        if (Config.mask) {
            ShowLayer({ background: Config.background, opacity: Config.opacity });
        }

        Create(Config);
    }

    //显示遮罩层
    function ShowLayer(Config) {
        var layer = $("<div></div>").addClass("mask_layer");
        var _scrollWidth = Math.max(document.body.scrollWidth, document.documentElement.scrollWidth);
        var _scrollHeight = Math.max(Math.max(document.body.scrollHeight, document.documentElement.scrollHeight), document.documentElement.clientHeight);
        layer.css({ width: _scrollWidth, height: _scrollHeight, background: Config.background, opacity: Config.opacity });
        $("body").append(layer);
    }

    //创建窗口
    function Create(Config) {
        switch (Config.type) {
            case "prompt":
            case "success":
            case "error":
            case "loading":
                var pop = $("<div></div>").addClass(Config.prefix + Config.type);
                if (Config.type == "loading" && Config.title == "") { Config.title = "加载中，请稍后..."; }
                pop.append("<s></s><span>" + Config.title + "</span>");
                $("body").append(pop);
                pop.css({ left: (document.documentElement.clientWidth - pop.outerWidth()) / 2, top: (document.documentElement.clientHeight - pop.outerHeight()) / 2 });

                if (Config.type != "loading") {
                    if (Config.hideMode == "auto") {
                        setTimeout(function () { $("." + Config.prefix + Config.type).remove(); $(".mask_layer").remove(); Config.Complete(); }, Config.autoTime);
                    } else {
                        pop.click(
                            function () {
                                $(this).remove(); $(".mask_layer").remove(); Config.Complete();
                            }
                        );
                    }
                }
                break;
            case "confirm":
                var confirm = $("<div></div>").addClass(Config.prefix + Config.type);
                confirm.append("<s></s><span>" + Config.title + "</span>");
                confirm.append("<div><a href='javascript:void();' class='" + Config.prefix + "ok'>确定</a><a href='javascript:void();' class='" + Config.prefix + "cancel'>取消</a></div>");
                $("body").append(confirm);
                confirm.css({ left: (document.documentElement.clientWidth - confirm.outerWidth()) / 2, top: (document.documentElement.clientHeight - confirm.outerHeight()) / 2 });
                confirm.find("div a").click(
                    function () {
                        if ($(this).hasClass("" + Config.prefix + "ok")) {
                            confirm.remove(); $(".mask_layer").remove(); Config.Complete({ status: true });
                        } else {
                            confirm.remove(); $(".mask_layer").remove(); Config.Complete({ status: false });
                        }
                    }
                );
                break;
            case "html":
                fun = Config.Complete;
                var window = $("<div></div>").addClass(Config.prefix + Config.type);
                var H2 = $("<h2></h2>").addClass(Config.prefix + "title").appendTo(window);
                H2.append("<span>" + Config.title + "</span>");
                H2.append("<div class='" + Config.prefix + "handle'><a href='javascript:void();' title='关闭'>关闭</a></div>");
                var content = $("<div></div>").addClass(Config.prefix + "content").appendTo(window);
                content.append(Config.html);

                var maxWidth = Config.width + 2;
                var maxHeight = Config.height + 55 + 2;

                window.css({
                    width: Config.width,
                    height: Config.height + 55,
                    left: (document.documentElement.clientWidth - maxWidth) / 2,
                    top: (document.documentElement.clientHeight - maxHeight) / 2
                });
                $("body").append(window);
                window.draggable({
                    handle: "h2." + Config.prefix + "title",
                    cancel: "div." + Config.prefix + "window h2." + Config.prefix + "title span,div." + Config.prefix + "window h2." + Config.prefix + "title div." + Config.prefix + "handle a"
                });
                window.find("div." + Config.prefix + "handle a").click(
                    function () {
                        Clear({ status: "cancel" });
                    }
                );

                break;
            case "window":
                fun = Config.Complete;
                var window_wrap = $("<div></div>").addClass(Config.prefix + Config.type)
                var window = $("<div></div>").addClass(Config.prefix + Config.type + "_bg").appendTo(window_wrap);
                var H2 = $("<h2></h2>").addClass(Config.prefix + "title").appendTo(window);
                H2.append("<span>" + Config.title + "</span>");
                H2.append("<div class='" + Config.prefix + "handle'><a href='javascript:void();' title='关闭'>关闭</a></div>");
                var content = $("<div></div>").addClass(Config.prefix + "content").appendTo(window);
                var frame = $("<iframe></iframe").attr("src", Config.url).css({ width: Config.width, height: Config.height }).appendTo(content);
                var maxWidth = Config.width + 16;
                var maxHeight = Config.height + 16 + 55;

                window_wrap.css({
                    width: Config.width + 16,
                    height: Config.height + 16 + 55,
                    left: (document.documentElement.clientWidth - maxWidth) / 2,
                    top: (document.documentElement.clientHeight - maxHeight) / 2
                });
                $("body").append(window_wrap);

                window_wrap.draggable({
                    handle: "h2." + Config.prefix + "title",
                    cancel: "div." + Config.prefix + "window h2." + Config.prefix + "title span,div." + Config.prefix + "window h2." + Config.prefix + "title div." + Config.prefix + "handle a"
                });

                window_wrap.find("div." + Config.prefix + "handle a").click(
                    function () {
                        Clear({ status: "cancel" });
                    }
                );

                Init({ type: "loading", mask: false, title: "正在加载页面，请稍后..." });

                frame.load(
                    function () {
                        var obj = this;
                        $("div." + Config.prefix + "loading").fadeOut(
                            function () {
                                $(obj).animate({ opacity: 1 });
                            }
                        );
                    }
                );

                break;
        }
    }

    //清除所有弹出层
    function Clear(data) {
        $(".mask_layer").remove();
        $("div[class^='pop_']").remove();
        if (data) {
            if (typeof (eval(fun)) == "function") {
                fun(data);
            }
        }
    }

    //修改弹出层标题
    function UpdateTitle(Config) {
        Config = $.extend({
            type: "prompt", //弹出窗口类型,prompt:提示,success:成功,error:错误,loading:加载,html:Html代码,window:页面
            prefix: "pop_", //前缀
            title: "", //标题
            Complete: function () { } //完成回调函数
        }, Config || {});

        switch (Config.type) {
            case "prompt":
            case "success":
            case "error":
            case "loading":
                $("div." + Config.prefix + Config.type + " span").html(Config.title);
                break;
            case "html":
            case "window":
                $("div." + Config.prefix + Config.type + " h2." + Config.prefix + "title span").html(Config.title);
                break;
        }

        Config.Complete();
    }

    return {
        Init: Init,
        Clear: Clear,
        UpdateTitle: UpdateTitle
    };
})();
