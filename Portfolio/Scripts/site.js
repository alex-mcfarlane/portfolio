var filter = new Filter("filter", "project");

var header = $('header');
$(window).scroll(function () {
    if ($(window).scrollTop() > 1) {
        header.addClass('inverted');
    } else {
        header.removeClass('inverted');
    }
})