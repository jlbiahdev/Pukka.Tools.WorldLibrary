using Pukka.Tools.Countries.Model;
using Pukka.Tools.Countries.Utils;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pukka.Tools.Countries
{
    public class GeoLibrary
    {
        private readonly FileLoader Loader = new FileLoader();
        private static GeoLibrary _instance;
        private static readonly object Locker = new object();

        private GeoLibrary() { }

        public static GeoLibrary GetInstance()
        {
            lock(Locker)
            {
                return _instance ??= new GeoLibrary();
            }
        }

        public async Task InitializeAsync()
        {
            await Loader.InitializeAsync();
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
