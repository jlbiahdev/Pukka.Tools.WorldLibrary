using CyranoLibrary.WorldGeoloc.Model;
using CyranoLibrary.WorldGeoloc.Utils;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CyranoLibrary.WorldGeoloc
{
    public class GeoLocLibrary
    {
        private static readonly FileLoader Loader = new FileLoader();
        private static GeoLocLibrary _instance;
        private static readonly object Locker = new object();

        private GeoLocLibrary() {
        }

        public static async Task<GeoLocLibrary> GetInstanceAsync()
        {
            lock(Locker)
            {
                _instance ??= new GeoLocLibrary();
            }
            await Loader.InitializeAsync();
            return _instance;
        }

        public ICollection<City> GetCities()
        {
            return Loader.Cities;
        }

        public ICollection<Country> GetCountries()
        {
            return Loader.Countries;
        }
    }
}
