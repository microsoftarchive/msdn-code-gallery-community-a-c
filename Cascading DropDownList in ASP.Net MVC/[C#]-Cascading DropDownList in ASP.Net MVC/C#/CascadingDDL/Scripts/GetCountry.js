$(function () {
    var URL = $('#CountryStateFormID').data('countryListAction');
     $.getJSON(URL, function (data) {
        var items = "<option>Select a Country</option>";
        $.each(data, function (i, country) {
            if (country.Value.indexOf("\'") > -1) {
                s = country.Value + " " + country.Text;
                alert(s + ": Country.Value cannot contain \'")
            }
            items += "<option value='" + country.Value + "'>" + country.Text + "</option>";
        });
        $('#CountriesID').html(items);
    });
});

