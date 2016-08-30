$(function () {
    $("#side-menu .J_menuItem").click(function () {
        $("#side-menu .J_menuItem.current").removeClass("current");
        $(this).addClass("current")
    });

})