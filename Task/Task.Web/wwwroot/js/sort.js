$(document).ready(function(){
    $('.sort').on('click',function(e){
        e.preventDefault();
        sortByField(this)
    });
});

async function sortByField(e){
    await ChangeSwitch(e);
    searchSortUrl += '&Search='+lastSearch;
    if(!sort.includes("#"+e.id)){
        sort.push("#"+e.id);   
        console.log("inc");
    }
    console.log(sort);
    for(var key in sort){
        console.log(sort[key]);
        searchSortUrl+='&Sort['+$(sort[key]).get(0).id+']='+$(sort[key]).get(0).className.split(' ')[1].split('-')[1];
    }
    console.log(searchSortUrl);
    location.href = searchSortUrl;
}

function ChangeSwitch(e){
    if (e.className === 'sort '|| e.className === 'sort'){
        $(e).addClass('sorted-asc');
    }else {
        $(e).toggleClass('sorted-asc sorted-desc');
    }
}