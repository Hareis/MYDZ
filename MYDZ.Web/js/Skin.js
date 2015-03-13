var Skin = Skin || {};

Skin.Controller = (function () {
    var CookieName = "SkinName";
    var path = "/css/theme/";
    var cssName = "style";

    //读取皮肤
    function Init() {
        var SkinName = GetCookie(CookieName);

        ValiName({ Name: SkinName, Complete:
            function (ThemeName) {
                Set(path + ThemeName + "/" + cssName + ".css");
            }
        });
    }

    //验证皮肤名称
    function ValiName(Config) {
        $.post("/PartView/ValiThemeName.html", { Name: Config.Name },
            function (data) {
                if (typeof (eval(Config.Complete)) == "function") {
                    Config.Complete(data.Name);
                }
            }
        );
    }

    //改变皮肤
    function Change(name) {
        ValiName({ Name: name, Complete:
            function (ThemeName) {
                $("body").find("link[href*=" + cssName + "]").remove();
                SetCookie(CookieName, ThemeName);
                Set(path + ThemeName + "/" + cssName + ".css");

                var ul = $(".header_theme");
                if (ul.length > 0) {
                    ul.find("li").removeClass("active");
                    ul.find("a[data-value='" + ThemeName + "']").parent().addClass("active");
                }
            }
        });
    }

    function Set(path) {
        $("<link>").attr({
            rel: "stylesheet",
            type: "text/css",
            href: path + "?Random=" + (new Date()).getTime()
        }).appendTo("body");
    }

    //读取cookie
    function GetCookie(name) {
        var nameValue = "";
        var arr, reg = new RegExp("(^| )" + name + "=([^;]*)(;|$)");
        if (arr = document.cookie.match(reg)) {
            nameValue = decodeURI(arr[2]);
        }

        return nameValue;
    }

    //写入cookie
    function SetCookie(name, value) {
        var Days = 30;
        var exp = new Date();
        exp.setTime(exp.getTime() + Days * 24 * 60 * 60 * 1000);
        document.cookie = name + "=" + escape(value) + "; path=/;expires=" + exp.toGMTString();
    }

    return {
        Init: Init,
        Change: Change,
        GetCookie: GetCookie,
        SetCookie: SetCookie
    };
})();