var MasterPage;
var Master = function (ClassName) {
    var ClassName = ClassName;
    this.Page = {
        Init: function () {
            this.InitEvent();
        },
        //初始化事件
        InitEvent: function () {
            var base = this;
            $("a.tool_ico_stretch").live("click",
                function () {
                    $(this).toggleClass("tool_ico_stretch_selected").parents("ul:eq(0)").next().slideToggle();
                }
            );

            $("a[name=Favorite]").click(function () { base.AddFavorite(); });
        },
        AddFavorite: function () {
            var a = "\u0068\u0074\u0074\u0070\u003a\u002f\u002f\u006f\u0072\u0064\u0065\u0072\u002e\u006d\u006f\u0079\u0075\u006e\u006f\u006e\u006c\u0069\u006e\u0065\u002e\u0063\u006f\u006d\u002f", b = "\u9b54\u4e91\u79d1\u6280\u002d\u8ba2\u5355\u5904\u7406";
            document.all ? window.external.AddFavorite(a, b) : window.sidebar && window.sidebar.addPanel ? window.sidebar.addPanel(b, a, "") : alert("\u5bf9\u4e0d\u8d77\uff0c\u60a8\u7684\u6d4f\u89c8\u5668\u4e0d\u652f\u6301\u6b64\u64cd\u4f5c!\n\u8bf7\u60a8\u4f7f\u7528\u83dc\u5355\u680f\u6216Ctrl+D\u6536\u85cf\u672c\u7ad9\u3002");
        }
    };
}

$(document).ready(
    function () {
        MasterPage = new Master("MasterPage");
        MasterPage.Page.Init();
    }
);