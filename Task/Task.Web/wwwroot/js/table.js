$(document).ready(function () {
    let w = $('.table').width();
    $('.paging').width(w);
    $('.row').width(w);

    $("#search").keyup(function (event) {
        event.preventDefault();
        console.log(event.keyCode);
        if (event.keyCode === 13) {
            searchSortUrl += '&Search='+this.value;
            for(var key in sort){
                console.log(sort[key]);
                searchSortUrl+='&Sort['+$(sort[key]).get(0).id+']='+$(sort[key]).get(0).className.split(' ')[1].split('-')[1];
            }
            location.href = searchSortUrl
        }
    });
});