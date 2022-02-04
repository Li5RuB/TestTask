$(document).ready(function () {

    $('.close-popup').click(function (e) {
        e.preventDefault();
        $('.popup-bg').fadeOut(200);
        $('html').removeClass('no-scroll');

    });

    $('.open-popup').click(function (e) {
        e.preventDefault();
        $('.popup-body').get(0).innerText = model.userModels[this.id].comments;
        $('.popup-bg').fadeIn(200);
        $('html').addClass('no-scroll');
    });
});