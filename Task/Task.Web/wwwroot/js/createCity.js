$(document).ready(function () {
    $.ajax({
        dataType: "json",
        url: "/Countries/GetCountries",
        method: "GET",
        data: {},
        success: SetCountries,
    });
});

function SetCountries(data) {
    $('#CountryId').empty();
    $('#CountryId').append($('<option value=""></option>'));
    for (let i in data) {
        $('#CountryId').append($('<option value="' + data[i].countryId + '">' + data[i].name + '</option>'));
    }
}