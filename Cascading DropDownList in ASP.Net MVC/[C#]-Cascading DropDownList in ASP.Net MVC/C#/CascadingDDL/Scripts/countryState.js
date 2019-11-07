$(function () {

    $('#StatesDivID').hide();
    $('#SubmitID').hide();

    $('#CountriesID').change(function () {
        var URL = $('#CountryStateFormID').data('stateListAction');
        $.getJSON(URL + '/' + $('#CountriesID').val(), function (data) {
            var items = '<option>Select a State</option>';
            $.each(data, function (i, state) {
                items += "<option value='" + state.Value + "'>" + state.Text + "</option>";
                // state.Value cannot contain ' character. We are OK because state.Value = cnt++;
            });
            $('#StatesID').html(items);
            $('#StatesDivID').show();

        });
    });

    $('#StatesID').change(function () {
        $('#SubmitID').show();
    });
});