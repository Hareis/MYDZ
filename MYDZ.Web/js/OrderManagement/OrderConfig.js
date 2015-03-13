var OrderConfig = function () {
    var Data = null;
    this.Page = {
        Init: function () {
            this.InitEvnet();
        },
        InitEvnet: function () {
            var base = this;
            $(".table_form select").select2();
            $("input[type=checkbox]").change(
                function () {
                    $(this).parents("label.checkbox:eq(0)").toggleClass("checked");
                }
            );
            $("input[type=radio]").change(
                function () {
                    var name = $(this).attr("name");
                    $("input[type=radio][name=" + name + "]").parents("label.radio").removeClass("checked");
                    $(this).parents("label.radio:eq(0)").addClass("checked");
                }
            );

            $("input[type=checkbox]").change(
            function () {
                $(this).parent().parent().toggleClass("checked");
            }
            );

            $(".table_bd").delegate("a.del", "click", function () { $(this).parents("tr:eq(0)").remove(); });

            $("button[name=add]").click(function () { base.CreateItem(this); });
            $(".table_form button[type=submit]").click(function () { base.Save(); });
        },
        CreateItem: function (obj) {
            var vls = [];
            var parent = $(obj).parent();
            var ipt = parent.find("input:eq(0)");
            var select = parent.find("select");
            if (select.length == 1) {
                if (ipt.val().IsEmpty()) {
                    ipt.focus();
                    return;
                } else {
                    vls.push({ key: "0", value: ipt.val().Trim() });
                }

                if (select.val().Trim() == "0") {
                    select.prev().find("input").focus();
                    return;
                } else {
                    vls.push({ key: select.val().Trim(), value: select.find("option:selected:eq(0)").text().Trim() });
                }
                ipt.val("");
            } else {
                for (var i = 0; i < select.length; i++) {
                    var sel = select.eq(i);
                    if (sel.val().Trim() == "0") {
                        sel.prev().find("input:eq(0)").focus();
                        return;
                    } else {
                        vls.push({ key: sel.val().Trim(), value: sel.find("option:selected:eq(0)").text().Trim() });
                    }
                }
            }

            if (vls.length != 2) { return; }
            var tbody = parent.parents(".table_item:eq(0)").next().find("tbody:eq(0)");
            if (tbody.length <= 0) { return; }

            var data = [];
            tbody.find("tr").each(
                function () {
                    data.push($(this).attr("data-key").Trim());
                }
            );

            var key = vls[0].key == "0" ? vls[0].value : (vls[0].key + "," + vls[0].value);

            var test = $.grep(data, function (n, j) {
                return n == key;
            });

            if (test.length > 0) { return; }

            var tr = $("<tr data-key='" + key + "' data-value='" + (vls[1].key + "," + vls[1].value) + "' ></tr>");
            for (var i = 0; i < vls.length; i++) {
                tr.append("<td>" + vls[i].value + "</td>");
            }
            tr.append('<td><a hidefocus="true" href="javascript:void();" class="del">删除</a></td>');
            tbody.append(tr);
        },
        Verification: function () {
            var isok = true;
            var PayTime = $("input[name=PayTime]");
            if (PayTime.val().IsEmpty()) {
                PayTime.focus();
                return false;
            } else {
                if (!PayTime.val().Trim().CheckInteger()) {
                    PayTime.val("").focus();
                    return false;
                }
            }

            var count = 0;
            $("tbody").each(
                function () {
                    var data = [];
                    var tbody = $(this);
                    var id = tbody.attr("data-id");
                    if (id) {
                        $(this).find("tr").each(
                            function () {
                                var key = $(this).attr("data-key").Trim();
                                var value = $(this).attr("data-value").Trim();

                                if (key && value) {
                                    tbody.append('<input type="hidden" name="DetailList[' + count + '].EnumId" value="' + id + '" />');
                                    tbody.append('<input type="hidden" name="DetailList[' + count + '].Key" value="' + key + '" />');
                                    tbody.append('<input type="hidden" name="DetailList[' + count + '].Value" value="' + value + '" />');
                                    count++;
                                }
                            }
                        );
                    }
                }
            );

            return isok;
        },
        Save: function () {
            if (!this.Verification()) {
                window.event.returnValue = false;
                return false;
            }
        }
    };
}

$(document).ready(
    function () {
        new OrderConfig().Page.Init();
    }
);