// Write your Javascript code.
function GAPI_Load() {
    gapi.client.setApiKey("AIzaSyAEHiELaQJI9Sd10X8rl4qd2_OknWCXw0Y");
}
function searchMovie(movieName) {
    var qSearch = movieName + " trailer";
    gapi.client.load('youtube', 'v3', function () {
        var request = gapi.client.youtube.search.list({
            q: qSearch,
            part: 'snippet',
            maxResults: 1
        });
        // Send the request to the API server,
        // and invoke onSearchRepsonse() with the response.
        request.execute(function (response) {
            var str = JSON.stringify(response.result);
            var trailerId = response.items[0].id.videoId;
            showVideo(trailerId);
        });
    });
}
function showVideo(trailerId) {
    var videoEl = document.getElementById("trailer");
    videoEl.innerHTML = "<iframe width='560' height='315'  frameborder='0' src='https://www.youtube.com/embed/" + trailerId + "' allowfullscreen></iframe>";
}

function post(path, params, method) {
    method = method || "post"; // Set method to post by default if not specified.

    // The rest of this code assumes you are not using a library.
    // It can be made less wordy if you use one.
    var form = document.createElement("form");
    form.setAttribute("method", method);
    form.setAttribute("action", path);

    for (var key in params) {
        if (params.hasOwnProperty(key)) {
            var hiddenField = document.createElement("input");
            hiddenField.setAttribute("type", "hidden");
            hiddenField.setAttribute("name", key);
            hiddenField.setAttribute("value", params[key]);

            form.appendChild(hiddenField);
        }
    }

    document.body.appendChild(form);
    form.submit();
}

$(document).ready(function () {
    $('#characterLeft').text('140 characters left');
    $('#message').keydown(function () {
        var max = 140;
        var len = $(this).val().length;
        if (len >= max) {
            $('#characterLeft').text('You have reached the limit');
            $('#characterLeft').addClass('red');
            $('#btnSubmit').addClass('disabled');
        }
        else {
            var ch = max - len;
            $('#characterLeft').text(ch + ' characters left');
            $('#btnSubmit').removeClass('disabled');
            $('#characterLeft').removeClass('red');
        }
    });
});
