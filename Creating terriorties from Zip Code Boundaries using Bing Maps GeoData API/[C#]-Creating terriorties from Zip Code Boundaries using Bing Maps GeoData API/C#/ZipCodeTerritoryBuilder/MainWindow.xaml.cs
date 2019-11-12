using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Windows;
using Microsoft.SqlServer.Types;

namespace ZipCodeTerritoryBuilder
{
    public partial class MainWindow : Window
    {
        private const string safeCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789_-";

        private List<ZipCode> zipCodes = new List<ZipCode>()
        {
            new ZipCode("92585", 33.743804, -117.170074),
            new ZipCode("92548", 33.760585, -117.110504),
            new ZipCode("92545", 33.731361, -117.040473),
            new ZipCode("92586", 33.706493, -117.199897),
            new ZipCode("92587", 33.696273, -117.248764),
            new ZipCode("92584", 33.660408, -117.176239),
            new ZipCode("92596", 33.640609, -117.072479)
        };

        private string geoDataUri = "https://platform.bing.com/geo/spatial/v1/public/geodata?spatialFilter=GetBoundary({0},{1},1,'Postcode1',1,0,'en','us')&$format=json&key={2}";

        private string bingMapsKey = "Your_Bing_Maps_Key";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void CreateTerritoryClicked(object sender, RoutedEventArgs e)
        {
             Output.Text = CombineZipCodes(zipCodes);
        }

        private string CombineZipCodes(List<ZipCode> zipCodes)
        {
            SqlGeography territory = null;            

            for (int i = 0; i < zipCodes.Count; i++)
            {
                try {
                    var g = GetZipcodeBoundary(zipCodes[i]);

                    if (territory == null)
                    {
                        territory = g;
                    }
                    else
                    {
                        territory.STUnion(g);
                    }
                }
                catch (Exception ex){
                    MessageBox.Show(ex.Message);
                }
            }

            if(territory != null && territory != SqlGeography.Null)
            {
                return territory.ToString();
            }

            return string.Empty;
        }

        private SqlGeography GetZipcodeBoundary(ZipCode zip)
        {
            var request = new Uri(string.Format(geoDataUri, zip.Location.Latitude, zip.Location.Longitude, bingMapsKey));

            var wc = new WebClient();
            using (var s = wc.OpenRead(request))
            {
                var serializer = new DataContractJsonSerializer(typeof(Response));
                var r = serializer.ReadObject(s) as Response;

                if (r != null &&
                    r.ResultSet != null &&
                    r.ResultSet.Results != null &&
                    r.ResultSet.Results.Length > 0)
                {
                    SqlGeography boundary = null;
                    List<Coordinate> cc;

                    for (var k = 0; k < r.ResultSet.Results.Length; k++)
                    {
                        foreach (var p in r.ResultSet.Results[k].Primitives)
                        {
                            var rings = p.Shape.Split(new char[] { ',' });

                            var sb = new StringBuilder("Polygon(");

                            //Skip first result as it is just a version number and not a ring.
                            for (int i = 1; i < rings.Length; i++)
                            {
                                if (TryParseEncodedValue(rings[i], out cc))
                                {
                                    sb.Append("(");

                                    for (int x = 0; x < cc.Count; x++)
                                    {
                                        sb.AppendFormat("{0} {1},", cc[x].Longitude, cc[x].Latitude);
                                    }

                                    sb.Length--;

                                    sb.Append(")");
                                }
                            }

                            sb.Append(")");

                            var g = SqlGeography.STGeomFromText(new SqlChars(new SqlString(sb.ToString())), 4326);

                            if (boundary == null)
                            {
                                boundary = g;
                            }
                            else
                            {
                                boundary.STUnion(g);
                            }                                    
                        }
                    }

                    return boundary.MakeValid();
                }
            }

            return null;
        }

        private static bool TryParseEncodedValue(string value, out List<Coordinate> parsedValue)
        {
            parsedValue = null;
            var list = new List<Coordinate>();
            int index = 0;
            int xsum = 0, ysum = 0;

            while (index < value.Length)        // While we have more data,
            {
                long n = 0;                     // initialize the accumulator
                int k = 0;                      // initialize the count of bits

                while (true)
                {
                    if (index >= value.Length)  // If we ran out of data mid-number
                        return false;           // indicate failure.

                    int b = safeCharacters.IndexOf(value[index++]);

                    if (b == -1)                // If the character wasn't on the valid list,
                        return false;           // indicate failure.

                    n |= ((long)b & 31) << k;   // mask off the top bit and append the rest to the accumulator
                    k += 5;                     // move to the next position
                    if (b < 32) break;          // If the top bit was not set, we're done with this number.
                }

                // The resulting number encodes an x, y pair in the following way:
                //
                //  ^ Y
                //  |
                //  14
                //  9 13
                //  5 8 12
                //  2 4 7 11
                //  0 1 3 6 10 ---> X

                // determine which diagonal it's on
                int diagonal = (int)((Math.Sqrt(8 * n + 5) - 1) / 2);

                // subtract the total number of points from lower diagonals
                n -= diagonal * (diagonal + 1L) / 2;

                // get the X and Y from what's left over
                int ny = (int)n;
                int nx = diagonal - ny;

                // undo the sign encoding
                nx = (nx >> 1) ^ -(nx & 1);
                ny = (ny >> 1) ^ -(ny & 1);

                // undo the delta encoding
                xsum += nx;
                ysum += ny;

                // position the decimal point
                list.Add(new Coordinate(ysum * 0.00001, xsum * 0.00001));
            }

            parsedValue = list;
            return true;
        }

        private void CopyToClipboardClicked(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(Output.Text);
        }
    }
}
