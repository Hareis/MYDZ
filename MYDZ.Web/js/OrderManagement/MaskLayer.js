var MyMaskLayer;

MaskLayer = function (ClassName) {
    var ClassName = ClassName;
    var MaskLayer_Id = "AL_MaskLayer_Div";
    var Element = null;

    this.Control = {
        //显示遮罩层
        Show: function (Setting) {
            Setting = Setting || {};
            var Config = {
                Event: null,
                Method: null,
                IsDelay: false,
                DelayTime: 1000,
                Opacity: 0,
                Element: null,
                Center: true,
                ToTop: false
            };

            Setting.Event = Setting.Event || Config.Event;
            Setting.IsDelay = Setting.IsDelay || Config.IsDelay;
            Setting.DelayTime = Setting.DelayTime || Config.DelayTime;
            Setting.Method = Setting.Method || Config.Method;
            Setting.Opacity = Setting.Opacity || Config.Opacity;
            Setting.Element = Setting.Element || Config.Element;
            Setting.Center = Setting.Center || Config.Center;
            Setting.ToTop = Setting.ToTop || Config.ToTop;

            this.Remove();
            var AL_MaskLayer = document.createElement("div");
            AL_MaskLayer.id = MaskLayer_Id;
            AL_MaskLayer.style.position = "absolute";
            AL_MaskLayer.style.zIndex = 200;

            _scrollWidth = Math.max(document.body.scrollWidth, document.documentElement.scrollWidth);
            _scrollHeight = Math.max(Math.max(document.body.scrollHeight, document.documentElement.scrollHeight), document.documentElement.clientHeight);

            AL_MaskLayer.style.width = _scrollWidth + "px";
            AL_MaskLayer.style.height = _scrollHeight + "px";
            AL_MaskLayer.style.top = "0px";
            AL_MaskLayer.style.left = "0px";
            AL_MaskLayer.style.background = "#fff";
            AL_MaskLayer.style.filter = "alpha(opacity=" + Setting.Opacity + ")";
            AL_MaskLayer.style.opacity = "" + Setting.Opacity / 100 + "";
            document.body.appendChild(AL_MaskLayer);

            if (Setting.Element != null) {
                Element = Setting.Element;

                if (Setting.Center) {
                    var _scrollWidth = Math.max(document.body.scrollWidth, document.documentElement.scrollWidth);
                    var top = document.documentElement.scrollTop;
                    var height = $(window).height();

                    var Size = {
                        width: $(Setting.Element).width(),
                        height: $(Setting.Element).height()
                    };
                    var obj = $(Setting.Element).get(0);
                    $(obj).css("left", (_scrollWidth - Size.width) / 2 + "px");

                    if (Setting.ToTop) {
                        top = 0;
                    }
                    $(obj).css("top", (parseInt((height - Size.height) / 2 + top)));
                }

                $(Setting.Element).show();
            }

            if (Setting.Event != null) {
                for (var i = 0; i < Setting.Event.length; i++) {
                    $(AL_MaskLayer).bind(Setting.Event[i].Data, new Function(Setting.Event[i].Method));
                }
            }

            if (Setting.IsDelay) {
                if (Setting.Method != null) {
                    window.setTimeout(Setting.Method, Setting.DelayTime);
                }
            }

            if (Setting.ToTop) {
                window.scrollTo(0, 0);
            }
        },
        //移除遮罩层
        Remove: function (status) {
            var obj = $("#" + MaskLayer_Id);
            if (obj.length > 0) {
                if (status) {
                    obj.fadeOut(
                        function () {
                            document.body.removeChild(this);
                            if (Element != null) {
                                $(Element).hide();
                                Element = null;
                            }
                        }
                    );
                } else {
                    document.body.removeChild(obj[0]);
                    if (Element != null) {
                        $(Element).hide();
                        Element = null;
                    }
                }
            }
        },
        //移除加载遮罩层
        RemoveElement: function () {
            if (Element != null) {
                $(Element).hide();
                Element = null;
            }
        }
    };
}

$(document).ready(function () {
    MyMaskLayer = new MaskLayer("MyMaskLayer");
});