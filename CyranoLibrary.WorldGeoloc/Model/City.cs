namespace CyranoLibrary.WorldGeoloc.Model
{
    public class City
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string CountryIso2 { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string LongName => $"{Name}({Country.Name})";
        public Country Country { get; set; } = new Country();
        public override string ToString() => $"{Name}, {Country}";
    }
}
