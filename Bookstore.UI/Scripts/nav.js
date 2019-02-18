$(document).ready(function () {
    $(window).scroll(function () {
        if ($(this).scrollTop() < 50) {
            $('navbar-fixed-top').removeClass('nav-bg');
        } else {
            $('navbar-fixed-top').addClass('nav-bg');
        }
    });
});