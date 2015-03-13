﻿$(function () {
    //------------------------注册JS方法------------------------------------
    chooseitemcats();
    OnloadAddGoodpageData();
    Appendsku();
    uploadimg();
    // LoadImg();
    floadtdiv();
    SubmitFrom();
    FreightPayer();
    //------------------------注册JS方法------------------------------------







    //加载上传图片的方法
    function LoadImg() {
        //指示当前填充第几张图片
        var intocount = 0;
        Validform.Controller.Init({
            form: "#SubmitFrom",
            beforeSubmit: function () {
                PopWindow.Controller.Init({ type: "loading", opacity: 0 });
            },
            usePlugin: {
                swfupload: {
                    file_post_name: "fileToUpload",
                    upload_url: "/Merchandise/UploadGoodsImg.html",
                    button_image_url: "/images/upload_btn.png",
                    button_width: 70,
                    button_height: 30,
                    button_action: SWFUpload.BUTTON_ACTION.SELECT_FILE,
                    button_placeholder_id: "spanButtonPlaceholder",
                    flash_url: "/js/swfupload/swfupload.swf",
                    file_size_limit: "500kb",                         //最大2G,这里是1.9G左右大小.
                    file_types: ".jpg;.gif;.png",               //设置选择文件的类型
                    file_types_description: "WebImageFile",        //这里是描述文件类型
                    file_upload_limit: "0",                          //0代表不受上传个数的限制
                    upload_success_handler: function (file, serverData) {
                        var data = eval('(' + serverData + ')');
                        var p = $('.goodsimgsku');
                        var count = p.length;
                        for (var i = 0; i < count; i++) {
                            var target = p.eq(i).find("img").eq(0);
                            if (target.attr("src") === "") {
                                if (data.URL !== null) {
                                    target.attr("src", data.URL);
                                    break;
                                }
                            }
                        }
                    },
                    file_dialog_complete_handler: function (data) {
                        if (data > 0) {
                            PopWindow.Controller.Init({ type: "loading", opacity: 0 });
                            //此处的imgload 填的是上传控件的ID
                            swfuploadhandler.SWFUPLOAD_imgload_0.startUpload();
                        }
                    },
                    upload_complete_handler: function (data) {
                        PopWindow.Controller.Clear();
                        var progress = new FileProgress(file, this.customSettings.progressTarget);
                        progress.setComplete();
                        progress.setStatus("上传成功！");
                        progress.toggleCancel(false);
                    },
                    fileQueueError: function (file, error, message) {

                    }
                }
            }

        }).config({
            ajaxPost: true,
            callback: function (data) {
                PopWindow.Controller.Clear();
            }
        });
    }

    // 页面提交表单方法
    function SubmitFrom() {
        Validform.Controller.Init({
            form: "#SubmitFrom",
            beforeCheck: function () {

            },
            beforeSubmit: function () {
                PopWindow.Controller.Init({ type: "loading", opacity: 0 });
                GetSkuProperties();
                GetGoodsDesc();
                GetSKU();
                picpath();
            }
        }).config({
            ajaxPost: true,
            callback: function (data) {
                PopWindow.Controller.Clear();
                if (!data.ErrorMsg !== null && data.ErrorMsg !== "") {
                    PopWindow.Controller.Init({ type: "error", opacity: 0, width: 352, height: 198, title: data.ErrorMsg });
                }
            }
        });
    }

    //选择类目
    function chooseitemcats() {
        $('.itemlist').delegate('.GoodsCats', "click", function () {
            var parent = $(this).parent();
            var allparent = $(this).parents().find("ol").eq(0);
            var cids = parent.attr("data");
            var status = parent.attr("status");
            var parentcid = parent.parent().parent().attr("data");
            var SortNum = parent.parent().parent().attr("SortNum");
            if (status === "Isparent") {
                PopWindow.Controller.Init({ type: "loading", opacity: 0 });
                $.post("/Merchandise/GetItencatsByCid.html", { ParentCid: cids }, function (res) {

                    allparent.children("li").each(function (i, item) {
                        if ($(item).attr("SortNum") >= (parseInt(SortNum) + 1)) {
                            $(item).remove();
                        }
                    });
                    var html = "<li data='" + cids + "' SortNum='" + (parseInt(SortNum) + 1) + "'><ul class='tool_wrap_bd'>";
                    for (var i in res) {
                        html += "<li data='" + res[i].Cid + "' status='";
                        html += res[i].IsParent === true ? "Isparent" : "Notparent";
                        html += "'><a href=\"javascript:void(0);\" class='GoodsCats'>" + res[i].Name;
                        html += res[i].IsParent === true ? "<i style='float:right'> +</i>" : "";
                        html += "</a>";
                        html += "</li>";
                    }
                    html += "</ul></li>";
                    allparent.append(html);
                    $('.fbbutton').attr("disabled", true);
                    $("input[name=SelectItemCid]").attr("value", "");
                    $('.fbbutton').addClass("test");

                });
                PopWindow.Controller.Clear();
            } else {
                $("input[name=SelectItemCid]").val(cids);
                $('.fbbutton').attr("disabled", false);
                $('.fbbutton').removeClass("test");
            }
        });
    }
    //加载添加商品页面数据
    function OnloadAddGoodpageData() {
        $('.btn_wrap_bd select').select2();
    }

    //添加sku列
    function Appendsku() {
        $('.saleprop').click(function () {
            var status = "";
            var selectother = false;
            var html = "";
            html += "<table style='width: 600px;' cellpadding='0' cellspacing='0'><tr>";
            html += "<td>颜色</td>";
            if ($('.sale-other-prop').length > 0) {
                html += " <td>尺寸</td>";
            }
            html += "<td> <i style='color: Red;'> *</i>价格</td>";
            html += "<td><i style='color: Red;'> *</i>数量</td>";
            html += "<td>商家编号</td>";
            html += "</tr>";
            $('.sale-color-prop').each(function (i, itemone) {
                if ($(itemone).hasClass('checked')) {
                    var value1 = $(this).find('em').text();
                    if ($('.sale-other-prop').length > 0) {
                        $('.sale-other-prop').each(function (j, itemtwo) {
                            if ($(itemtwo).hasClass('checked')) {
                                var value2 = $(this).find('em').text();
                                html += " <tr>";
                                html += " <td>" + value1 + "</td>";
                                html += " <td>" + value2 + "</td>";
                                html += " <td><input type='text' class='skucss' name='Goods-sku-price' value=''/></td>";
                                html += " <td><input type='text' class='skucss' name='Goods-sku-stoken' value=''/></td>";
                                html += " <td><input type='text' class='skucss' name='Goods-sku-coding' value=''/></td> ";
                                html += " <td><input type='text' class='skucss' name='Goods-sku-SPJC' value=''/></td> ";
                                html += " <td><input type='text' class='skucss' name='Goods-sku-SPZL' value=''/></td> ";
                                html += " </tr>";
                                selectother = true;
                            }
                        });
                    }
                    else {
                        html += " <tr>";
                        html += " <td>" + value1 + "</td>";
                        html += " <td><input type='text' class='skucss' name='Goods-sku-price' value=''/></td>";
                        html += " <td><input type='text' class='skucss' name='Goods-sku-stoken' value=''/></td>";
                        html += " <td><input type='text' class='skucss' name='Goods-sku-coding' value=''/></td> ";
                        html += " <td><input type='text' class='skucss' name='Goods-sku-SPJC' value=''/></td> ";
                        html += " <td><input type='text' class='skucss' name='Goods-sku-SPZL' value=''/></td> ";
                        html += " </tr>";
                    }
                    status += "true";
                }
                else {
                    $('.Goods-Skus').empty();
                    status += "false";
                }
            });
            if (status.indexOf("true") > -1) {
                html += " </table>";
                $('.Goods-Skus').empty();
                $('.Goods-Skus').append(html);
            }
        });
    }

    function uploadimg() {
        $('.uploadgoodsimg-btn').click(function () {
            $("#fileToUpload").trigger("click");
        });
    }

    //图片编辑
    function floadtdiv() {
        var objectImg;
        $('.goodsimgsku').hover(function () {
            objectImg = null;
            var divset = $(this).position();
            var target = $('.floatdiv');
            objectImg = this;
            if ($(objectImg).find('img').eq(0).attr('src') !== "") {
                target.show();
            }
            target.css("top", parseInt(divset.top) + 74);
            target.css("left", parseInt(divset.left) + 10);
        }, function () {
            $('.floatdiv').hide();
        });
        $('.floatdiv').hover(function () {
            $('.floatdiv').show();
        }, function () {
            $('.floatdiv').hide();
        });
        var parent = $('.goodsimgsku');
        $('.floatdiv').find('a').eq(0).click(function () {
            var index = parent.index(objectImg);
            var last = parent.eq(parseInt(index)).find('img');
            if (index > 0) {
                var befor = parent.eq(parseInt(index) - 1).find('img');
                var lasturl = last.attr("src");
                var beforurl = befor.attr("src");

            } else {
                var lasturl = last.attr("src")
                var befor = parent.eq(parseInt(parent.length) - 1).find('img');
                var beforurl = befor.attr("src");
            }
            last.attr("src", beforurl);
            befor.attr("src", lasturl);
        });
        $('.floatdiv').find('a').eq(1).click(function () {
            var index = parent.index(objectImg);
            var last = parent.eq(parseInt(index)).find('img');
            if (index < parseInt(parent.length)) {
                var befor = parent.eq(parseInt(index) + 1).find('img');
                var lasturl = last.attr("src");
                var beforurl = befor.attr("src");
            } else {
                var lasturl = last.attr("src")
                var befor = parent.eq(0).find('img');
                var beforurl = befor.attr("src");
            }
            last.attr("src", beforurl);
            befor.attr("src", lasturl);
        });
        $('.floatdiv').find('a').eq(2).click(function () {
            $(objectImg).find('img').attr("src", "");
        });
    }

    function GetSkuProperties() {
        var input_str = "";
        var sku_properties = ""; //class="GoodsCats"
        $('.ListGoodsCats').find("input[type=text] .GoodsCats").each(function (i, item) {
            input_str += $(item).attr("data") + ":" + $(item).val();
        });
        $('.ListGoodsCats').find("input[type=checkbox] .GoodsCats").each(function (i, item) {
            input_str += $(item).attr("data") + ":" + $(item).val();
        });
        $('.ListGoodsCats').find("input[name=InputStr] .GoodsCats").val(input_str);

        $('.ListGoodsCats').find("select").each(function (i, item) {
            sku_properties += $(item).val();
        });
        $('.ListGoodsCats').find("input[name=SkuProperties] .GoodsCats").val(sku_properties);
    }

    function GetGoodsDesc() {
        var html = $('#edit').editable('getHTML', false, true);
        $("input[name=Desc]").val(html);
    }

    function GetSKU() {
        var sku_prices = [];
        var sku_quantities = [];
        var sku_outer_ids = [];
        $('input[name=Goods-sku-price]').each(function (i, item) {
            sku_prices.push($(item).val());
        });
        $('input[name=Goods-sku-stoken]').each(function (i, item) {
            sku_quantities.push($(item).val());
        });
        $('input[name=Goods-sku-coding]').each(function (i, item) {
            sku_outer_ids.push($(item).val());
        });
        $("input[name=SkuOuterIds]").val(sku_outer_ids.toLocaleString());
        $("input[name=SkuQuantities]").val(sku_quantities.toLocaleString());
        $("input[name=SkuPrices]").val(sku_prices.toLocaleString());
    }
    function FreightPayer() {
        $('input[name=FreightPayer]').change(function () {
            if ($('.seller:checked').length > 0) {
                $('.freight_payer-div').show();
            } else {
                $('.freight_payer-div').hide();
            }
        });
        $('input[name=playstatus]').change(function () {
            if ($('.freight-tempter-radio:checked').length > 0) {
                $('.freight-tempter').show();
            } else {
                $('.freight-tempter').hide();
            }
            if ($('.customer-price-radio:checked').length > 0) {
                $('.customer-price').show();
            } else {
                $('.customer-price').hide();
            }
        });
    }

    function picpath() {
        var pic_url = $('.goodsimgsku').eq(0).find('img').attr("src");
        $("input[name=PicPath]").val(pic_url);
        var childurl = [];
        var len = $('.goodsimgsku').length;
        for (var i = 1; i < len; i++) {
            var ulr = $('.goodsimgsku').eq(i).find('img').attr("src") + "^" + i;
            if (ulr !== "^" + i) {
                childurl.push(ulr);
            }
        }
        $("input[name=ChildPicPath]").val(childurl.toLocaleString());
    }
});