using CyranoLibrary.WorldGeoloc.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CyranoLibrary.WorldGeoloc.Utils
{
    internal class FileLoader
    {
        ICollection<City> _cities;
        internal ICollection<City> Cities
        {
            get
            {
                if (_cities == null)
                {
                    throw new NullReferenceException("City list is not initialized yet");
                }

                return _cities;
            }
        }

        ICollection<Country> _countries;
        internal ICollection<Country> Countries {
            get
            {
                if (_countries == null)
                {
                    throw new NullReferenceException("Country list is not initialized yet");
                }

                return _countries;
            }
        }

        internal async Task InitializeAsync()
        {
            _countries = await GetCountriesAsync();
            _cities = await GetCitiesAsync();

            _cities.ToList().ForEach(c => c.Country = _countries.FirstOrDefault(k => k.Iso2 == c.CountryIso2));
        }

        private async Task<ICollection<Country>> GetCountriesAsync()
        {
            var output = await Task.Run(() => JsonFileLoader.ReadAsObject<Country>(@"Data\countries.json"));

            return output;
        }

        private async Task<ICollection<City>> GetCitiesAsync()
        {
            var output = await Task.Run(() => JsonFileLoader.ReadAsObject<City>(@"Data\cities.json"));

            return output;
        }
    }
}
