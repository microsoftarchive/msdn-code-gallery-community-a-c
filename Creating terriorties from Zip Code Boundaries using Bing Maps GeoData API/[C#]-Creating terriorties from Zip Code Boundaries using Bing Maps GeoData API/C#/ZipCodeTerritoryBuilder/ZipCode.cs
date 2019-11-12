namespace ZipCodeTerritoryBuilder
{
    public class ZipCode
    {
        public ZipCode(string name, double lat, double lon)
        {
            Name = name;
            Location = new Coordinate(lat, lon);
        }

        public string Name { get; set; }

        public Coordinate Location { get; set; }
    }
}
