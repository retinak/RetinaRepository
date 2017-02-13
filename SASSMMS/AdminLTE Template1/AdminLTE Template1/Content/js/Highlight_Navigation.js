$(function () {
    setNavigation();
});

function setNavigation() {
    var path = window.location.pathname;
    path = path.replace(/\/$/, "");
    path = decodeURIComponent(path);
    $("div.list-group a").each(function () {
        var href = $(this).attr('href');
        if (path === href) {
            $(this).closest('a').addClass('gray').prepend("<i class='glyphicon glyphicon-chevron-right'></i>");
        }
    });
}
