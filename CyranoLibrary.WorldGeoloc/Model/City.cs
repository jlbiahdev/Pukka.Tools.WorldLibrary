namespace CyranoLibrary.WorldGeoloc.Model
{
    public class City
    {
        public string Name { get; set; }
        public string CountryIso2 { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public Country Country { get; set; } = new Country();
        public override string ToString() => $"{Name}, {Country}";
    }
}
