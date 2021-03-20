namespace CyranoLibrary.WorldGeoloc.Model
{
    public class Country
    {
        public string Iso2 { get; set; }
        public string Iso3 { get; set; }
        public string Name { get; set; }
        public override string ToString() => Name;
    }
}
