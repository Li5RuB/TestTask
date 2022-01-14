$(document).ready(async function () {
    await $.ajax({
        dataType: "json",
        url: "/Titles/GetTitles",
        method: "GET",
        data: {},
        success: SetTitles,
    });

    await $.ajax({
        dataType: "json",
        url: "/Countries/GetCountries",
        method: "GET",
        data: {},
        success: SetCountries,
    });

    $('#Countries').change(GetSities);


    $('#TitleId option[value=' + model['title'].id + ']').prop('selected', true);
    $('#Countries option[value=' + model['city'].countryId + ']').prop('selected', true);
    await GetSities(model['city'].countryId);
    $('#CityId option[value=' + model['city'].id + ']').prop('selected', true);
});

function SetTitles(data) {
    $('#TitleId').empty();
    $('#TitleId').append($('<option value=""></option>'));
    for (let i in data) {
        $('#TitleId').append($('<option name="Title" value="' + data[i].id + '">' + data[i].name + '</option>'));
    }
}

function SetCountries(data) {
    $('#Countries').empty();
    $('#Countries').append($('<option value=""></option>'));
    for (let i in data) {
        $('#Countries').append($('<option value="' + data[i].id + '">' + data[i].name + '</option>'));
    }
}

async function GetSities(v) {
    let value = this.value || v;
    await $.ajax({
        datatype: "json",
        url: "/Countries/GetCitiesByCountry",
        method: "GET",
        data: { 'id': value },
        success: SetCities,
    });
};

function SetCities(data) {
    $('#CityId').empty();
    $('#CityId').append($('<option value=""></option>'));
    for (let i in data) {
        $('#CityId').append($('<option name="City" value="' + data[i].id + '">' + data[i].name + '</option>'));
    }
}