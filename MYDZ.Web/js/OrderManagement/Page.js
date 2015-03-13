/// <summary>
/// 分页控件类
/// </summary>
Paging = function (ClassName, fun) {
    var ClassName = ClassName;
    var PageSetting = null;
    var Fun = fun;
    var Parent = "";
    var Step = 2;
    var Page = {
        prevPage: 0, //上一页页码
        currentPage: 0, //当前页码
        nextPage: 0//下一页页码
    };

    this.Control = {
        Init: function (Setting) {
            if (PageSetting == null) {
                PageSetting = Setting || {};

                var Config = {
                    PageIndex: 1,
                    MaxPageNumber: 1,
                    MaxRowNumber: 1,
                    ObjName: "div.page",
                    PreviousName: "上一页",
                    NextName: "下一页",
                    PointNumber: 2,
                    ItemNumber: 8
                };
                PageSetting = $.extend(Config, PageSetting);
            } else {
                if (Setting) {
                    PageSetting = $.extend(PageSetting, Setting);
                }
            }

            if (PageSetting.MaxPageNumber > 0) {
                this.CreateHtml();
            }
        },
        ToPage: function (Instruction) {
            var PageCount = -1;
            switch (Instruction) {
                case "prev":
                    if (Page.prevPage > 0) {
                        PageCount = Page.prevPage;
                    }
                    break;
                case "next":
                    if (Page.nextPage <= PageSetting.MaxPageNumber) {
                        PageCount = Page.nextPage;
                    }
                    break;
                default:
                    break;
            }

            if (PageCount != -1) {
                eval("" + Parent + "(" + PageCount + ")");
            }
        },
        CreateHtml: function () {
            var Inner = "";

            PageSetting.PageIndex = parseInt(PageSetting.PageIndex);

            var prevPage = PageSetting.PageIndex - 1; //上一页页码
            var nextPage = PageSetting.PageIndex + 1; //下一页页码

            Page.prevPage = prevPage;
            Page.currentPage = parseInt(PageSetting.PageIndex);
            Page.nextPage = nextPage;

            Inner += "<ul class=\"PageNav\">";

            if (prevPage < 1) {
                Inner += "<li><span><font>" + PageSetting.PreviousName + "</font></span></li>";
            }
            else {
                Inner += "<li><a href=\"javascript:" + ClassName + ".Control.ToPage(" + prevPage + ");\"><span>" + PageSetting.PreviousName + "</span></a></li>";
            }

            if (PageSetting.MaxPageNumber <= PageSetting.ItemNumber + PageSetting.PointNumber) {
                for (var i = 1; i <= PageSetting.MaxPageNumber; i++) {
                    if (PageSetting.PageIndex == i) {
                        Inner += "<li><span class=\"Current\"><font>" + i + "</font></span></li>";
                    }
                    else {
                        Inner += "<li><a href=\"javascript:" + ClassName + ".Control.ToPage(" + i + ");\"><span class=\"Number\">" + i + "</span></a></li>";
                    }
                }
            }
            else {
                if (PageSetting.PageIndex < PageSetting.ItemNumber) {
                    for (var i = 1; i <= PageSetting.ItemNumber; i++) {
                        if (PageSetting.PageIndex == i) {
                            Inner += "<li><span class=\"Current\"><font>" + i + "</font></span></li>";
                        }
                        else {
                            Inner += "<li><a href=\"javascript:" + ClassName + ".Control.ToPage(" + i + ");\"><span class=\"Number\">" + i + "</span></a></li>";
                        }
                    }

                    Inner += "<li>...</li>";

                    for (var i = PageSetting.MaxPageNumber - PageSetting.PointNumber; i < PageSetting.MaxPageNumber; i++) {
                        Inner += "<li><a href=\"javascript:" + ClassName + ".Control.ToPage(" + parseInt(i + 1) + ");\"><span class=\"Number\">" + parseInt(i + 1) + "</span></a></li>";
                    }
                }
                else {
                    if (PageSetting.PageIndex >= PageSetting.ItemNumber && PageSetting.PageIndex < PageSetting.ItemNumber + PageSetting.PointNumber) {
                        for (var i = 1; i <= PageSetting.PageIndex + Step; i++) {
                            if (PageSetting.PageIndex == i) {
                                Inner += "<li><span class=\"Current\"><font>" + i + "</font></span></li>";
                            }
                            else {
                                Inner += "<li><a href=\"javascript:" + ClassName + ".Control.ToPage(" + i + ");\"><span class=\"Number\">" + i + "</span></a></li>";
                            }
                        }

                        if (PageSetting.MaxPageNumber <= PageSetting.PageIndex + Step + PageSetting.PointNumber) {
                            for (var i = PageSetting.PageIndex + Step; i < PageSetting.MaxPageNumber; i++) {
                                Inner += "<li><a href=\"javascript:" + ClassName + ".Control.ToPage(" + parseInt(i + 1) + ");\"><span class=\"Number\">" + parseInt(i + 1) + "</span></a></li>";
                            }
                        } else {
                            Inner += "<li>...</li>";

                            for (var i = PageSetting.MaxPageNumber - PageSetting.PointNumber; i < PageSetting.MaxPageNumber; i++) {
                                Inner += "<li><a href=\"javascript:" + ClassName + ".Control.ToPage(" + parseInt(i + 1) + ");\"><span class=\"Number\">" + parseInt(i + 1) + "</span></a></li>";
                            }
                        }
                    }
                    else {
                        for (var i = 1; i <= PageSetting.PointNumber; i++) {
                            Inner += "<li><a href=\"javascript:" + ClassName + ".Control.ToPage(" + i + ");\"><span class=\"Number\">" + i + "</span></a></li>";
                        }

                        Inner += "<li>...</li>";

                        if (PageSetting.PageIndex + PageSetting.ItemNumber > PageSetting.MaxPageNumber) {
                            for (var i = PageSetting.PageIndex - PageSetting.PointNumber; i <= PageSetting.MaxPageNumber; i++) {
                                if (PageSetting.PageIndex == i) {
                                    Inner += "<li><span class=\"Current\"><font>" + i + "</font></span></li>";
                                }
                                else {
                                    Inner += "<li><a href=\"javascript:" + ClassName + ".Control.ToPage(" + i + ");\"><span class=\"Number\">" + i + "</span></a></li>";
                                }
                            }
                        }
                        else {
                            for (var i = PageSetting.PageIndex - parseInt(PageSetting.ItemNumber / 2); i <= PageSetting.PageIndex + parseInt(PageSetting.ItemNumber / 2); i++) {
                                if (PageSetting.PageIndex == i) {
                                    Inner += "<li><span class=\"Current\"><font>" + i + "</font></span></li>";
                                }
                                else {
                                    Inner += "<li><a href=\"javascript:" + ClassName + ".Control.ToPage(" + i + ");\"><span class=\"Number\">" + i + "</span></a></li>";
                                }
                            }

                            Inner += "<li>...</li>";

                            for (var i = PageSetting.MaxPageNumber - PageSetting.PointNumber; i < PageSetting.MaxPageNumber; i++) {

                                Inner += "<li><a href=\"javascript:" + ClassName + ".Control.ToPage(" + parseInt(i + 1) + ");\"><span class=\"Number\">" + parseInt(i + 1) + "</span></a></li>";
                            }
                        }
                    }
                }
            }

            if (nextPage > PageSetting.MaxPageNumber) {
                Inner += "<li><span><font>" + PageSetting.NextName + "</font></span></li>";
            } else {
                Inner += "<li><a href=\"javascript:" + ClassName + ".Control.ToPage(" + nextPage + ");\"><span>" + PageSetting.NextName + "</span></a></li>";
            }

            if (PageSetting.MaxPageNumber > 1) {
                var pi = "";

                if (nextPage > PageSetting.MaxPageNumber) {
                    pi = 1;
                } else {
                    pi = nextPage;
                }

                Inner += "<li>";
                Inner += "  <i>去第</i><i><input type='text' data-width='24' value='" + pi + "' accesskey='p' /><input type='button' hidefocus='hidefocus' onclick='" + ClassName + ".Control.ChangePage(this);' class='jumppage' title='确定' value='确定' /></i><i>页</i>";
                Inner += "</li>";
            }

            $(PageSetting.ObjName).get(0).innerHTML = "";
            $(PageSetting.ObjName).append(Inner);
        },
        //获取跳转页面页码
        ChangePage: function (obj) {
            var prev = $(obj).prev();
            var nextPage = parseInt(Page.currentPage + 1);
            if (nextPage > PageSetting.MaxPageNumber) {
                nextPage = 1;
            }

            if (prev.val().IsEmpty()) {
                prev.val(nextPage);
                return;
            }

            if (!prev.val().Trim().CheckInteger()) {
                prev.val(nextPage);
                return;
            }

            if (prev.val().Trim() == Page.currentPage) {
                prev.val(nextPage);
                return;
            }

			var num = parseInt(prev.val().Trim());
            if (num < 1 || num > PageSetting.MaxPageNumber) {
                prev.val(nextPage);
                return;
            }

            this.ToPage(parseInt(prev.val()));
        },
        //页面跳转
        ToPage: function (PageIndex) {
            if (Fun) {
                if (typeof (Fun) === "function") {
                    Fun(PageIndex);
                }
            }
        }
    };
}