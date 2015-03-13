﻿var Validform = Validform || {};

Validform.Controller = (function () {

    function Init(Setting) {

        var ValidformSetting = {
            form: "", //表单,
            beforeSubmit: function () { }, //提交表单之前的操作
            usePlugin: {}, //插件
            callback: function () { } //回调
        };

        ValidformSetting = $.extend(ValidformSetting, Setting);

        var form = $(ValidformSetting.form);
        form.delegate(".msg_info", "click", function () { $(this).fadeOut(); })

        return form.Validform({
            tiptype: function (msg, o, cssctl) {
                if (!o.obj.is("form")) {
                    var objtip = o.obj.parent().find(".Validform_checktip");
                    cssctl(objtip, o.type);
                    objtip.text(msg);
                    var infoObj = o.obj.parent().find(".msg_info");

                    if (o.type == 2) {
                        infoObj.fadeOut(200);
                    } else {
                        ShowMsg(o.obj, infoObj);
                    }
                }
            },
            tipSweep: true,
            showAllError: true,
            postonce: true,
            usePlugin: ValidformSetting.usePlugin,
            callback: ValidformSetting.callback,
            beforeSubmit: ValidformSetting.beforeSubmit
        });
    }

    function ShowMsg(obj, infoObj, msg) {
        if (msg) {
            obj.parent().find(".Validform_checktip").text(msg);
        }

        if (infoObj == null) {
            infoObj = obj.parent().find(".msg_info");
        }

        var infoWidth = infoObj.outerWidth();
        var objWidth = obj.outerWidth();

        var infoHeight = infoObj.outerHeight() + infoObj.find("i").outerHeight() / 2 + 2;
        var left = obj.position().left, top = obj.position().top;

        infoObj.css({
            left: left + objWidth - infoWidth,
            top: top - infoHeight - 10
        }).show().animate({
            top: top - infoHeight
        }, 200);
    }

    return {
        Init: Init,
        ShowMsg: ShowMsg
    };
})();