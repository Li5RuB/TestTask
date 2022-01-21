$(document).ready(function () {
    let w = $('.table').width();
    $('.paging').width(w);
    $('.row').width(w);

    $("#search").keyup(function (event) {
        event.preventDefault();
        console.log(event.keyCode);
        if (event.keyCode === 13) {
            location.href = searchUrl.replace('__s__', this.value);
        }
    });
});

