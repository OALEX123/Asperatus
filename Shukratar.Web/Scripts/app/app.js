$(function () {
    var scrollToTop = $("#scroll-to-top");

    scrollToTop.on("click", function() {
        $("html,body").scrollTop(0);
    });

});

function copyToClipboard(text) {
    window.prompt("Copy to clipboard: Ctrl+C, Enter", text);
}