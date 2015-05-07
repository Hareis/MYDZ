﻿/// <summary>
/// 分页控件类
/// </summary>

jQuery.fn.Pager = function (Setting) {
    var Pager = Pager || {};
    var items = this;
    var Step = 2;

    var Page = {
        prevPage: 0, //上一页页码
        currentPage: 0, //当前页码
        nextPage: 0//下一页页码
    };

    var PageSetting = {
        PageIndex: 1, //当前页数
        MaxPageNumber: 1, //总页数
        MaxRowNumber: 1, //总行数
        FirstName: "第一页", //第一页按钮名称，为空则不显示
        LastName: "最后页", //最后页按钮名称，为空则不显示
        PrevName: "上一页", //上一页按钮名称，为空则不显示上一页按钮
        NextName: "下一页", //下一页按钮名称，为空则不显示下一页按钮
        ShowMax: true, //是否显示总条数
        PointNumber: 2,
        ItemNumber: 8, //出现的页码数
        JumpBtn: true, //是否显示页面跳转文本框
        Mini: {
            Enabled: false, //是否开启简要模式
            HasPrev: false, //是否有上一页
            HasNext: false//是否有下一页
        }, //简要模式
        Page: function () { } //页面跳转回调函数
    };

    PageSetting = $.extend(PageSetting, Setting);

    Pager.Controller = (function () {
        //初始化
        function Init() {
            InitEvent();
            CreateHtml();
        }

        //初始化事件
        function InitEvent() {
            items.delegate("ul.PageNav a", "click", function () {
                var pageIndex = $(this).attr("data-index");
                PageSetting.Page(parseInt(pageIndex));
            });

            items.delegate("ul.PageNav input[type=text]", "click", function () {
                $(this).select();
            });

            items.delegate("ul.PageNav input[type=button]", "click", function () {
                var txt = $.trim($(this).prev().val());
                if (txt != "" && !isNaN(txt)) {
                    var index = parseInt(txt);
                    if (index != PageSetting.PageIndex && index > 0 && index <= PageSetting.MaxPageNumber) {
                        PageSetting.Page(index);
                    }
                }
            });
        }

        //创建HTML
        function CreateHtml() {
            items.empty();
            PageSetting.PageIndex = parseInt(PageSetting.PageIndex);
            Page.prevPage = PageSetting.PageIndex - 1; //上一页页码
            Page.currentPage = PageSetting.PageIndex;
            Page.nextPage = PageSetting.PageIndex + 1; //下一页页码

            var page_wrap = $("<div></div>").addClass("page_wrap").appendTo(items);

            var ul = $("<ul></ul>").addClass("PageNav").appendTo(page_wrap);

            if (PageSetting.Mini.Enabled) {
                if (PageSetting.Mini.HasPrev) {
                    ul.append("<li><a href=\"javascript:void(0);\" data-index=\"" + Page.prevPage + "\"><span>" + PageSetting.PrevName + "</span></a></li>");
                }

                if (PageSetting.Mini.HasNext) {
                    ul.append("<li><a href=\"javascript:void(0);\" data-index=\"" + Page.nextPage + "\"><span>" + PageSetting.NextName + "</span></a></li>");
                }

                return;
            }

            if (PageSetting.ShowMax) {
                ul.append("<li><i>共 <font>" + PageSetting.MaxRowNumber + "</font> 条数据</i></li>");
            }

            if (Page.prevPage > 0) {
                if (PageSetting.FirstName != "") {//绘制第一页
                    ul.append("<li><a href=\"javascript:void(0);\" data-index=\"1\"><span>" + PageSetting.FirstName + "</span></a></li>");
                }

                if (PageSetting.PrevName != "") {//绘制上一页
                    ul.append("<li><a href=\"javascript:void(0);\" data-index=\"" + Page.prevPage + "\"><span>" + PageSetting.PrevName + "</span></a></li>");
                }
            }

            if (PageSetting.MaxPageNumber <= PageSetting.ItemNumber + PageSetting.PointNumber) {
                for (var i = 1; i <= PageSetting.MaxPageNumber; i++) {
                    if (PageSetting.PageIndex == i) {
                        ul.append("<li><span class=\"Current\"><font>" + i + "</font></span></li>");
                    } else {
                        ul.append("<li><a href=\"javascript:void(0);\" data-index=\"" + i + "\"><span class=\"Number\">" + i + "</span></a></li>");
                    }
                }
            } else {
                if (PageSetting.PageIndex < PageSetting.ItemNumber) {
                    for (var i = 1; i <= PageSetting.ItemNumber; i++) {
                        if (PageSetting.PageIndex == i) {
                            ul.append("<li><span class=\"Current\"><font>" + i + "</font></span></li>");
                        } else {
                            ul.append("<li><a href=\"javascript:void(0);\" data-index=\"" + i + "\"><span class=\"Number\">" + i + "</span></a></li>");
                        }
                    }

                    ul.append("<li>...</li>");

                    for (var i = PageSetting.MaxPageNumber - PageSetting.PointNumber; i < PageSetting.MaxPageNumber; i++) {
                        ul.append("<li><a href=\"javascript:void(0);\" data-index=\"" + parseInt(i + 1) + "\"><span class=\"Number\">" + parseInt(i + 1) + "</span></a></li>");
                    }
                } else {
                    if (PageSetting.PageIndex >= PageSetting.ItemNumber && PageSetting.PageIndex < PageSetting.ItemNumber + PageSetting.PointNumber) {
                        for (var i = 1; i <= PageSetting.PageIndex + Step; i++) {
                            if (PageSetting.PageIndex == i) {
                                ul.append("<li><span class=\"Current\"><font>" + i + "</font></span></li>");
                            } else {
                                ul.append("<li><a href=\"javascript:void(0);\" data-index=\"" + i + "\"><span class=\"Number\">" + i + "</span></a></li>");
                            }
                        }

                        if (PageSetting.MaxPageNumber <= PageSetting.PageIndex + Step + PageSetting.PointNumber) {
                            for (var i = PageSetting.PageIndex + Step; i < PageSetting.MaxPageNumber; i++) {
                                ul.append("<li><a href=\"javascript:void(0);\" data-index=\"" + parseInt(i + 1) + "\"><span class=\"Number\">" + parseInt(i + 1) + "</span></a></li>");
                            }
                        } else {
                            ul.append("<li>...</li>");

                            for (var i = PageSetting.MaxPageNumber - PageSetting.PointNumber; i < PageSetting.MaxPageNumber; i++) {
                                ul.append("<li><a href=\"javascript:void(0);\" data-index=\"" + parseInt(i + 1) + "\"><span class=\"Number\">" + parseInt(i + 1) + "</span></a></li>");
                            }
                        }
                    } else {
                        for (var i = 1; i <= PageSetting.PointNumber; i++) {
                            ul.append("<li><a href=\"javascript:void(0);\" data-index=\"" + i + "\"><span class=\"Number\">" + i + "</span></a></li>");
                        }

                        ul.append("<li>...</li>");

                        if (PageSetting.PageIndex + PageSetting.ItemNumber > PageSetting.MaxPageNumber) {
                            for (var i = PageSetting.PageIndex - PageSetting.PointNumber; i <= PageSetting.MaxPageNumber; i++) {
                                if (PageSetting.PageIndex == i) {
                                    ul.append("<li><span class=\"Current\"><font>" + i + "</font></span></li>");
                                } else {
                                    ul.append("<li><a href=\"javascript:void(0);\" data-index=\"" + i + "\"><span class=\"Number\">" + i + "</span></a></li>");
                                }
                            }
                        } else {
                            for (var i = PageSetting.PageIndex - parseInt(PageSetting.ItemNumber / 2); i <= PageSetting.PageIndex + parseInt(PageSetting.ItemNumber / 2); i++) {
                                if (PageSetting.PageIndex == i) {
                                    ul.append("<li><span class=\"Current\"><font>" + i + "</font></span></li>");
                                } else {
                                    ul.append("<li><a href=\"javascript:void(0);\" data-index=\"" + i + "\"><span class=\"Number\">" + i + "</span></a></li>");
                                }
                            }

                            ul.append("<li>...</li>");

                            for (var i = PageSetting.MaxPageNumber - PageSetting.PointNumber; i < PageSetting.MaxPageNumber; i++) {
                                ul.append("<li><a href=\"javascript:void(0);\" data-index=\"" + parseInt(i + 1) + "\"><span class=\"Number\">" + parseInt(i + 1) + "</span></a></li>");
                            }
                        }
                    }
                }
            }

            if (Page.nextPage <= PageSetting.MaxPageNumber) {
                if (PageSetting.NextName != "") {//绘制下一页
                    ul.append("<li><a href=\"javascript:void(0);\" data-index=\"" + Page.nextPage + "\"><span>" + PageSetting.NextName + "</span></a></li>");
                }

                if (PageSetting.LastName != "") {//绘制最后页
                    ul.append("<li><a href=\"javascript:void(0);\" data-index=\"" + PageSetting.MaxPageNumber + "\"><span>" + PageSetting.LastName + "</span></a></li>");
                }
            }

            if (PageSetting.JumpBtn) {
                if (PageSetting.MaxPageNumber > 1) {
                    var pi = "";

                    if (Page.nextPage > PageSetting.MaxPageNumber) {
                        pi = 1;
                    } else {
                        pi = Page.nextPage;
                    }

                    ul.append("<li><i>跳到</i><input type='text' data-width='24' value='" + pi + "' accesskey='p' /><input type='button' title='跳转' value='跳转' /></li>");
                }
            }

        }

        Init();
    })();

    return Pager.Controller;
};