using BingMapsRESTService.Common.JSON;
using DistanceWithinCountry.Models;
using Microsoft.Maps.MapControl.WPF;
using Microsoft.SqlServer.Types;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace DistanceWithinCountry
{
    public partial class MainWindow : Window
    {
        private List<Country> countries;
        private string sessionKey;

        public MainWindow()
        {
            InitializeComponent();

            //Generate a session key
            MyMap.CredentialsProvider.GetCredentials((c) =>
            {
                sessionKey = c.ApplicationId;
            });

            LoadCountries();
        }

        private void LoadCountries()
        {
            countries = new List<Country>();
            var fInfo = new FileInfo("Data/countries.txt");

            using (var fileStream = fInfo.OpenRead())
            {
                using (var reader = new StreamReader(fileStream))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        var data = line.Split(new char[] { '|' });

                        countries.Add(new Country()
                        {
                            Name = data[0],
                            Geom = SqlGeography.Parse(data[1]).MakeValid()
                        });
                    }
                }
            }
        }

        private async void CalculateBtn_Clicked(object sender, RoutedEventArgs e)
        {
            MyMap.Children.Clear();
            try
            {
                var r = await CalculateRoute(StartTbx.Text, EndTbx.Text);

                if (r != null &&
                    r.ResourceSets != null &&
                    r.ResourceSets.Length > 0 &&
                    r.ResourceSets[0].Resources != null &&
                    r.ResourceSets[0].Resources.Length > 0)
                {
                    Route route = r.ResourceSets[0].Resources[0] as Route;

                    double[][] routePath = route.RoutePath.Line.Coordinates;

                    var locs = new LocationCollection();

                    //Create SqlGeography from route line points.
                    SqlGeographyBuilder geomBuilder = new SqlGeographyBuilder();
                    geomBuilder.SetSrid(4326);
                    geomBuilder.BeginGeography(OpenGisGeographyType.LineString);
                    geomBuilder.BeginFigure(routePath[0][0], routePath[0][1]);

                    for (int i = 0; i < routePath.Length; i++)
                    {
                        locs.Add(new Microsoft.Maps.MapControl.WPF.Location(routePath[i][0], routePath[i][1]));
                        geomBuilder.AddLine(routePath[i][0], routePath[i][1]);
                    }

                    geomBuilder.EndFigure();
                    geomBuilder.EndGeography();

                    //Calculate distances in countries.
                    var routeGeom = geomBuilder.ConstructedGeography;

                    var sb = new StringBuilder();
                    sb.AppendFormat("Total Driving Distance: {0} KM\r\n", route.TravelDistance);

                    foreach (var c in countries)
                    {
                        if (c.Geom.STIntersects(routeGeom))
                        {
                            sb.AppendFormat("Distnance in {0}: {1:0.##} KM\r\n", c.Name, c.Geom.STIntersection(routeGeom).STLength().Value / 1000);
                        }
                    }

                    OutputTbx.Text = sb.ToString();

                    //Display route on map
                    var routeLine = new MapPolyline()
                    {
                        Locations = locs,
                        Stroke = new SolidColorBrush(Colors.Blue),
                        StrokeThickness = 5
                    };

                    MyMap.Children.Add(routeLine);

                    MyMap.SetView(locs, new Thickness(30), 0);
                }
            }
            catch (Exception ex)
            {

            }
        }

        private async Task<Response> CalculateRoute(string start, string end)
        {
            var requestURI = new Uri(string.Format("https://dev.virtualearth.net/REST/V1/Routes/Driving?wp.0={0}&wp.1={1}&rpo=Points&key={2}",
                                       Uri.EscapeDataString(start), Uri.EscapeDataString(end), sessionKey));

            using (var stream = await GetStreamAsync(requestURI))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    var ser = new DataContractJsonSerializer(typeof(Response));
                    return ser.ReadObject(stream) as Response;
                }
            }
        }

        public static Task<Stream> GetStreamAsync(Uri url)
        {
            var tcs = new TaskCompletionSource<Stream>();

            var request = HttpWebRequest.Create(url);
            request.BeginGetResponse((a) =>
            {
                try
                {
                    var r = (HttpWebRequest)a.AsyncState;
                    HttpWebResponse response = (HttpWebResponse)r.EndGetResponse(a);
                    tcs.SetResult(response.GetResponseStream());
                }
                catch (Exception ex)
                {
                    tcs.SetException(ex);
                }
            }, request);

            return tcs.Task;
        }
    }
}
