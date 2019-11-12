$(document).ready(function () {
    var sessionId;
    $("#timeLabel").hide();
    $("#time").hide();
    $.getJSON("/api/cinemas/", function (result) {
        var location = $("#location");
        $.each(result, function () {
            location.append($("<option/>").val(this.cineplexID).text(this.location));
        });
        $('#location').trigger('change');
    });
    $('#location').change(function (e) {
        var cinemaId = this.value;
        var movies = $("#movies");
        movies.empty();
        $.getJSON("/api/sessions/location/" + cinemaId, function (result) {
            $.each(result, function (index, value) {
                $.getJSON("/api/movies/" + value.movieID, function (data) {
                    movies.append($("<option/>").val(value.sessionID).text(data.title));
                });
            });
        });
    });
    $('#movies').change(function(e) {
        sessionId = this.value;
        var time = $("#time");
        time.empty();
        $.getJSON("/api/sessions/" + sessionId, function (result) {
            time.append($("<option/>").text(result.timeRunning));
        });
        $("#timeLabel").show();
        $("#time").show();
    });
    $('#bookSession').click(function (e) {
        alert("Booking: " + sessionId);
        post('/Cart/Add/', { id: sessionId });
    });
});