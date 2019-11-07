# CinemaPlex
ASP.net Core Cinema Application for Booking Movies and providing a general Cinema Website.

# Front-End Demo

## Homepage:
![Quick Booking](https://i.imgur.com/UkPXCDt.png)

## Movies:
![All Movies](https://i.imgur.com/2a7R2G3.png)
![Details](https://i.imgur.com/4OsBGyN.png)

## Session: 
![Session](https://i.imgur.com/L2B0VoZ.png)

## Cart
![Cart](https://i.imgur.com/ZcaAQ7b.png)
![Book Seats](https://i.imgur.com/Ol6fTru.png)

## Cinemas:
![Cinemas](https://i.imgur.com/EqibvCs.png)
![Cinema Details])(https://i.imgur.com/F5Cya0g.png)

## Login:
![Login One-Click](https://i.imgur.com/kqwef51.png)

# Launching CinemaPlex

## Recommended:

Use Visual Studio 2015 on Microsoft, either community or enterprise edition - and then run the app using F5.

~/wwwroot/js/site.js -> Change Line 3 to your google API Key for Youtube.

~/Views/Cinemas/Details.cshtml -> Change Line 78 to your google API Key for Google Maps.

~/web.config -> Change connectionStrings (Line 14/15) with your SQL Connection String.

~/appsettings.json -> Modify Lines 3 with your SQL Connection String.

~/Data/ApplicationDbContext.cs -> Modify Lines 45-50 with your SQL Connection String.

~/Startup.cs -> Modify Lines 88/89 With Facebook AppId & AppSecret.

Run the cinemaplex-db-script.sql file on your DB and run your application from Visual Studio.

Make sure the application can connect to the Database with Entity Framework.

# API Demo

	   `$.getJSON("/api/sessions/location/" + cinemaId, function (result) {
            $.each(result, function (index, value) {
                $.getJSON("/api/movies/" + value.movieID, function (data) {
                    movies.append($("<option/>").val(value.sessionID).text(data.title));
                });
            });
        });`
		
In the above JavaScript code we are using the /api/session/location/1->5 in order to retrieve all the Movie Sessions
Listed inside each location.

We then do a for each loop with Jquery and get the respective value of Movies title values as well as their Session ID's and append them to our 
View.
