alert ('sdsd');



$(document).ready(function ()
    {
        var colName = $("th[name='Name']").get(0);
        var arrow = makeArrow("arrow-bottom");
        colName.classList.add("sortedAsc");
        colName.appendChild(arrow);
    })

/*
    $("#deleteBtn").on("click", function ()
    {
        var idArr = $(".IsDeleted:checked").toArray().map(function (e) {
            return e.id;
        });

        if (idArr.length)
        {
        var pageInfo = getPageInfo();
        $.post("@Url.Action("DeleteMany", "Home")", { idArr, pageInfo }, function (data){
                $(".tbody").empty().html(data);
            })
        }
    });
    
    */

    function getPageInfo() {
        var e = $(".sortedAsc").get(0);
        if (!e) {
            e = $(".sortedDesc").get(0);
            return pageInfo = { ClassName: e.getAttribute("name"), asc: false };
        }
        if (!e)  getPageInfo();
        return pageInfo = { ClassName: e.getAttribute("name"), asc: true };
    }

    $("th.colName").on("click", function (e) {
        var col = e.target;
        var arrow;
        var pageInfo = { ClassName: col.getAttribute("name"), asc: true };

        if (col.classList.contains("sortedAsc")) {
            arrow = makeArrow("arrow-top");
            col.classList.add("sortedDesc");
            pageInfo.asc = false;
        }

        else {
              arrow = makeArrow("arrow-bottom");
              col.classList.add("sortedAsc");
        }

        col.appendChild(arrow);
        $.post("@Url.Action("Sort", "Home")", pageInfo, function (data) {
            $(".tbody").empty().html(data);
        });
    })

    function makeArrow(className) {
        $(".colName").removeClass("sortedAsc").removeClass("sortedDesc");
        $("#arrow").remove();
        var arrow = document.createElement("div");
        arrow.id = "arrow";
        arrow.className = className;
        return arrow;
    }
*/