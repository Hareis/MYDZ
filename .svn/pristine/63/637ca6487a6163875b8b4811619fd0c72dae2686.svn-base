var Deliver = function () {
    this.Page = {
        Init: function () {
            $("div.DataTable").delegate(".detail_wrap", "mouseover",
                function () {
                    $(this).find("div.detail_div").show();
                }
            ).delegate(".detail_wrap", "mouseout",
                function () {
                    $(this).find("div.detail_div").hide();
                }
            );
        }
    };
}

$(document).ready(
    function () {
        new Deliver().Page.Init();
    }
);