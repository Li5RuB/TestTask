$(document).ready(function () {
    let w = $('.table').width();
    $('.paging').width(w);
    $('.row').width(w);

    $('.close-popup').click(function (e) {
        e.preventDefault();
        $('.popup-bg').fadeOut(800);
        $('html').removeClass('no-scroll');

    });

    $('.open-popup').click(function (e) {
        e.preventDefault();
        $('.popup-body').get(0).innerText = model[this.id].comments;
        $('.popup-bg').fadeIn(800);
        $('html').addClass('no-scroll');
    });

    $("#search").keyup(function (event) {
        event.preventDefault();
        console.log(event.keyCode);
        if (event.keyCode === 13) {
            location.href = searchUrl.replace('__s__',this.value);
        }
    });
});