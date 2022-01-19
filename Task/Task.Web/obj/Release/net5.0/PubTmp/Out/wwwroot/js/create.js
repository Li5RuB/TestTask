$(document).ready(function () {
    $.ajax({
        dataType: "json",
        url: "/Titles/GetTitles",
        method: "GET",
        data: {},
        success: SetTitles,
    });

    $.ajax({
        dataType: "json",
        url: "/Countries/GetCountries",
        method: "GET",
        data: {},
        success: SetCountries,
    });

    $('#Countries').change(function () {
        let value = this.value;
        $.ajax({
            datatype: "json",
            url: "/Cities/GetCitiesByCountryId",
            method: "GET",
            data: { 'id': value },
            success: SetCities,
        })
    });
});

function SetTitles(data) {
    $('#TitleId').empty();
    $('#TitleId').append($('<option value=""></option>'));
    for (let i in data) {
        $('#TitleId').append($('<option name="Title" value="' + data[i].titleId + '">' + data[i].name + '</option>'));
    }
}

function SetCountries(data) {
    $('#Countries').empty();
    $('#Countries').append($('<option value=""></option>'));
    for (let i in data) {
        $('#Countries').append($('<option value="' + data[i].countryId + '">' + data[i].name + '</option>'));
    }
}

function SetCities(data) {
    $('#CityId').empty();
    $('#CityId').append($('<option value=""></option>'));
    for (let i in data) {
        $('#CityId').append($('<option name="City" value="' + data[i].cityId + '">' + data[i].name + '</option>'));
    }
}