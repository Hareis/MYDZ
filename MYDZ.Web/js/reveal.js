window.layer = {
    //普通对话框
    alert: function (options) {
        options = options ? options : {};
        options.type = 1;
        this.create(options);
    },
    //询问框
    confirm: function (options) {
        options = options ? options : {};
        options.type = 2;
        this.create(options);
    },
    //创建骨架
    create: function (options) {
        var defaults = {
            width: 230,
            height: 130,
            title: '', //标题
            msg: '', //内容
            type: 1, //1 普通对话框,2询问框,默认普通对话框
            icon: 0, //0不显示,1警告，2询问，3错误，4正确,默认不显示
            btns: ["确定", "取消"], //按钮文本
            mask: true, //是否显示遮罩层
            animate: "down", //动画效果,none无动画，fade渐隐渐现，pop左上到中间,down至上而下弹出，默认down
            close: function () { } //关闭弹窗回调函数
        };

        var options = $.extend({}, defaults, options);

        if (options.mask) {
            MyMaskLayer.Control.Show({ "Opacity": 40 });
        }

        var div = $("<div></div>").addClass("layer_wrap").css({ width: options.width, height: options.height });
        var main = $("<div></div>").addClass("layer_wrap_main").css({ width: options.width, height: options.height }).appendTo(div);
        var bg = $("<div></div>").addClass("layer_wrap_bg").css({ width: options.width + 12, height: options.height + 12 }).appendTo(div);
        var bd = $("<div></div>").addClass("layer_wrap_bd").css({ width: options.width }).appendTo(main);
        var title = $("<h2></h2>").addClass("layer_wrap_title").css({ width: options.width }).appendTo(main);
        var a = $("<a></a>").addClass("layer_wrap_close").attr("href", "javascript:void();").appendTo(main);
        var btn = $("<span></span>").addClass("layer_wrap_btn").appendTo(main);
        title.append("<em>" + options.title + "</em>");

        if (options.icon > 0) {
            bd.append('<span class="layer_wrap_icon icon_' + options.icon + '"></span>');
        }
        bd.append('<span class="layer_wrap_text" style="' + (options.icon <= 0 ? "padding-left:20px;width:" + parseInt(options.width - 40) + "px;" : "width:" + parseInt(options.width - 75) + "px;") + '">' + options.msg + '</span>');

        if (options.type == 1) {
            btn.append('<a href="javascript:void();" class="layer_wrap_btn_yes">' + options.btns[0] + '</a>');
        } else {
            btn.append('<a href="javascript:void();" class="layer_wrap_btn_no">' + options.btns[1] + '</a><a href="javascript:void();" class="layer_wrap_btn_yes">' + options.btns[0] + '</a>');
        }

        btn.find("a").add(a).click(
            function () {
                var type = $(this).hasClass("layer_wrap_btn_yes") ? 1 : $(this).hasClass("layer_wrap_btn_no") ? 2 : $(this).hasClass("layer_wrap_close") ? 3 : 4;
                $(this).parents(".layer_wrap").fadeOut(
                    function () {
                        $(this).remove();
                        if (typeof (eval(options.close)) == "function") {
                            options.close(type);
                        }
                    }
                );

                if (options.mask) {
                    MyMaskLayer.Control.Remove(true);
                }
            }
        );

        var top = $(document).scrollTop();
        var size = { left: ($(window).width() - options.width - 12) / 2, top: ($(window).height() - options.height - 12) / 2 };
        $("body").append(div);
        switch (options.animate) {
            case "fade":
                div.css(size).fadeIn();
                break;
            case "pop":
                div.css({ top: -(options.width + 12) }).show().animate(size);
                break;
            case "down":
                div.css({ top: -(options.width + 12), left: size.left }).show().animate(size);
                break;
            case "none":
            default:
                div.css(size).show();
        }

    }
}